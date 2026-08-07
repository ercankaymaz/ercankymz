$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot

function ReadSource([string]$relative) {
  $p = Join-Path $root $relative
  if (-not (Test-Path $p)) { throw "Source missing: $relative" }
  return [IO.File]::ReadAllText($p)
}
function WriteSource([string]$relative,[string]$text) {
  $p = Join-Path $root $relative
  [IO.File]::WriteAllText($p,$text,(New-Object Text.UTF8Encoding($false)))
}
function ReplaceExact([string]$text,[string]$old,[string]$new,[int]$expected,[string]$name) {
  $count = ([regex]::Matches($text,[regex]::Escape($old))).Count
  if ($count -ne $expected) { throw "$name: expected $expected occurrence(s), found $count" }
  return $text.Replace($old,$new)
}
function PatchSection([string]$text,[string]$startMark,[string]$endMark,[scriptblock]$patch,[string]$name) {
  $a=$text.IndexOf($startMark,[StringComparison]::Ordinal)
  if($a -lt 0){throw "$name: start marker missing"}
  $b=$text.IndexOf($endMark,$a+$startMark.Length,[StringComparison]::Ordinal)
  if($b -lt 0){throw "$name: end marker missing"}
  $part=$text.Substring($a,$b-$a)
  $part=& $patch $part
  return $text.Substring(0,$a)+$part+$text.Substring($b)
}

# Drafting2D Fillet/Chamfer selection-direction logic.
$rel='buCadCamRes/buCadCamResVer5/Editor/Drafting2D.cs'
$t=ReadSource $rel
$t=ReplaceExact $t 'Point3D.Distance(this.point3D_2, firstSelectedEntity1.EndPoint)' 'Point3D.Distance(this.point3D_1, firstSelectedEntity1.EndPoint)' 2 'Draft first click distance'
$t=ReplaceExact $t 'Point3D.Distance(this.point3D_1, secondSelectedEntity1.StartPoint)' 'Point3D.Distance(this.point3D_2, secondSelectedEntity1.StartPoint)' 2 'Draft second click distance'
$t=ReplaceExact $t '(num2 >= num1 ? 0 : (secondSelectedEntity1 is Arc ? 1 : (secondSelectedEntity1 is EllipticalArc ? 1 : 0))) != 0)' '(num2 >= num1 ? 0 : (firstSelectedEntity1 is Arc ? 1 : (firstSelectedEntity1 is EllipticalArc ? 1 : 0))) != 0)' 2 'Draft first curve type'
WriteSource $rel $t

$rel='buCadCamRes/buCadCamResVer5/clsCommand.cs'
$t=ReadSource $rel
$t=ReplaceExact $t 'ccVars.Action == actionTypeBU.eventFillet && e.Button == MouseButtons.Right | e.Button == MouseButtons.Left' 'ccVars.Action == actionTypeBU.eventFillet && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)' 1 'Fillet mouse precedence'
$t=ReplaceExact $t 'ccVars.Action == actionTypeBU.eventChamfer && e.Button == MouseButtons.Right | e.Button == MouseButtons.Left' 'ccVars.Action == actionTypeBU.eventChamfer && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)' 1 'Chamfer mouse precedence'
$t=ReplaceExact $t 'ccVars.Action == actionTypeBU.eventConnect && e.Button == MouseButtons.Right | e.Button == MouseButtons.Left' 'ccVars.Action == actionTypeBU.eventConnect && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)' 1 'Connect mouse precedence'

foreach($m in @(
  @{S='  public void Fillet(Point3D pntEnd)';E='  public void Chamfer(Point3D pntEnd)';N='Fillet'},
  @{S='  public void Chamfer(Point3D pntEnd)';E='  public void Connect(Point3D pntEnd)';N='Chamfer'}
)){
  $t=PatchSection $t $m.S $m.E {
    param($method)
    $bs=$method.IndexOf('else if (subIndex1 >= 0 & subIndex2 == -1)',[StringComparison]::Ordinal)
    if($bs -lt 0){throw "$($m.N): target branch missing"}
    $be=$method.IndexOf('    this.OsnapCalculation',$bs,[StringComparison]::Ordinal)
    if($be -lt 0){throw "$($m.N): branch end missing"}
    $branch=$method.Substring($bs,$be-$bs)
    $branch=ReplaceExact $branch 'ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] = buVector5.CopyEntities((Entity) curve1, entityDataSet1);' 'ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] = buVector5.CopyEntities((Entity) curve2, entData);' 1 "$($m.N) second entity ownership"
    $branch=ReplaceExact $branch 'curve2.StartPoint' 'curve1.StartPoint' 2 "$($m.N) composite start reference"
    $branch=ReplaceExact $branch 'curve2.EndPoint' 'curve1.EndPoint' 2 "$($m.N) composite end reference"
    $branch=ReplaceExact $branch 'refEntities.Add((Entity) curve2);' 'refEntities.Add((Entity) curve1);' 1 "$($m.N) composite rebuilt curve"
    return $method.Substring(0,$bs)+$branch+$method.Substring($be)
  } $m.N
}

$t=PatchSection $t '  public void Connect(Point3D pntEnd)' '  public void Explode(bool AddNewEntity)' {
  param($x)
  ReplaceExact $x 'ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] = buVector5.CopyEntities(((Entity) curve2).DeepClone<Entity>(), entData1);' 'ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] = buVector5.CopyEntities(((Entity) curve2).DeepClone<Entity>(), entData2);' 1 'Connect second metadata'
} 'Connect'

$t=PatchSection $t '  public void RotateClick(Point3D pntBase)' '  public void Mirror(' {
  param($x)
  $x=ReplaceExact $x "      ccVars.UndoDont = true;`r`n      entity.Rotate" "      ccVars.UndoDont = true;`r`n      this.OsnapDeleteByEntityName(clsInit.cVector5.GetEntityName(entity));`r`n      entity.Rotate" 1 'RotateClick osnap delete'
  ReplaceExact $x "      entity.Regen(0.01);`r`n      Added.Add" "      entity.Regen(0.01);`r`n      this.OsnapCalculation(entity);`r`n      Added.Add" 1 'RotateClick osnap recalc'
} 'RotateClick'

$t=PatchSection $t '  public void Mirror(' '  public void Exchange()' {
  param($x)
  ReplaceExact $x "        this.AddEntity(Ent, OsnapCalc);`r`n      }`r`n    }`r`n    if (DeleteOriginal)" "        this.AddEntity(Ent, OsnapCalc);`r`n      }`r`n      Added.Add(ccVars.SelectionOP.Selections[index].Index);`r`n    }`r`n    if (DeleteOriginal)" 1 'Mirror repeat selection'
} 'Mirror'

$t=PatchSection $t '  public void Scale(' '  public void Offset(Point3D pntEnd)' {
  param($x)
  $x=ReplaceExact $x 'double factor = !(buNumeric.IsNumeric(num.ToString()) & num != 0.0) ? fixedPoint.DistanceTo(pntEnd) / fixedPoint.DistanceTo(ccVars.SelectionOP.SelectionBoxMax) : fixedPoint.DistanceTo(pntEnd) / num;' "double scaleBaseDistance = fixedPoint.DistanceTo(ccVars.SelectionOP.SelectionBoxMax);`r`n    double factor = buNumeric.IsNumeric(num.ToString()) && Math.Abs(num) > 1E-12 ? fixedPoint.DistanceTo(pntEnd) / num : (Math.Abs(scaleBaseDistance) > 1E-12 ? fixedPoint.DistanceTo(pntEnd) / scaleBaseDistance : 1.0);" 1 'Scale divide by zero'
  $x=ReplaceExact $x "        this.CreateEntity(refEntity, ref Ent);`r`n        Ent.Scale(fixedPoint, factor);`r`n        this.AddEntity(Ent);" "        this.CreateEntity(refEntity, ref Ent);`r`n        if (Ent != null)`r`n        {`r`n          Ent.Scale(fixedPoint, factor);`r`n          this.AddEntity(Ent);`r`n        }" 1 'Scale ratio null entity'
  ReplaceExact $x "        this.CreateEntity(refEntity, ref Ent);`r`n        Ent.Scale(fixedPoint, sx, sy, sz);`r`n        this.AddEntity(Ent);" "        this.CreateEntity(refEntity, ref Ent);`r`n        if (Ent != null)`r`n        {`r`n          Ent.Scale(fixedPoint, sx, sy, sz);`r`n          this.AddEntity(Ent);`r`n        }" 1 'Scale xyz null entity'
} 'Scale'

$t=ReplaceExact $t 'double factor = !(buNumeric.IsNumeric(num.ToString()) & num != 0.0) ? point3D.DistanceTo(Points) / point3D.DistanceTo(ccVars.SelectionOP.SelectionBoxMax) : point3D.DistanceTo(Points) / num;' "double scaleBaseDistance = point3D.DistanceTo(ccVars.SelectionOP.SelectionBoxMax);`r`n      double factor = buNumeric.IsNumeric(num.ToString()) && Math.Abs(num) > 1E-12 ? point3D.DistanceTo(Points) / num : (Math.Abs(scaleBaseDistance) > 1E-12 ? point3D.DistanceTo(Points) / scaleBaseDistance : 1.0);" 1 'Dynamic scale divide by zero'

foreach($a in @('curveArray3','curveArray4','curveArray5','curveArray6','curveArray7','curveArray8','curveArray9','curveArray10')){
  $t=ReplaceExact $t "if ($a != null)" "if ($a != null && $a.Length > 0)" 1 "Offset guard $a"
}
$t=ReplaceExact $t 'if (curveArray != null)' 'if (curveArray != null && curveArray.Length > 0)' 1 'Dynamic offset guard'
WriteSource $rel $t

@(
 'PATCH_OK',
 'Fillet/Chamfer pick direction corrected',
 'Fillet/Chamfer composite ownership corrected',
 'Connect metadata corrected',
 'Fillet/Chamfer/Connect mouse precedence corrected',
 'Rotate osnap refresh corrected',
 'Mirror repeat-selection corrected',
 'Scale denominator/null guards added',
 'Offset empty-result guards added'
) | Set-Content (Join-Path $root 'CADCAM_PATCH_REPORT.txt') -Encoding UTF8
Write-Host 'CAD/CAM deterministic patches applied successfully.' -ForegroundColor Green
