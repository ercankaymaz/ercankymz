$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot

function Read-Source([string]$relative) {
    $path = Join-Path $root $relative
    if (-not (Test-Path $path)) { throw "Source missing: $relative" }
    return [IO.File]::ReadAllText($path)
}

function Write-Source([string]$relative, [string]$text) {
    $path = Join-Path $root $relative
    [IO.File]::WriteAllText($path, $text, (New-Object Text.UTF8Encoding($false)))
}

function Replace-Exact([string]$text, [string]$old, [string]$new, [int]$expected, [string]$name) {
    $count = ([regex]::Matches($text, [regex]::Escape($old))).Count
    if ($count -ne $expected) {
        throw "Patch '$name' expected $expected occurrence(s), found $count. Source version does not match expected baseline."
    }
    return $text.Replace($old, $new)
}

function Replace-InSection([string]$text, [string]$sectionStart, [string]$sectionEnd, [string]$old, [string]$new, [int]$expected, [string]$name) {
    $start = $text.IndexOf($sectionStart, [StringComparison]::Ordinal)
    if ($start -lt 0) { throw "Patch '$name': start marker not found: $sectionStart" }
    $end = $text.IndexOf($sectionEnd, $start + $sectionStart.Length, [StringComparison]::Ordinal)
    if ($end -lt 0) { throw "Patch '$name': end marker not found: $sectionEnd" }
    $section = $text.Substring($start, $end - $start)
    $section = Replace-Exact $section $old $new $expected $name
    return $text.Substring(0, $start) + $section + $text.Substring($end)
}

function Replace-InMethodBranch([string]$text, [string]$methodStart, [string]$methodEnd, [string]$branchStart, [string]$branchEnd, [string]$old, [string]$new, [int]$expected, [string]$name) {
    $mStart = $text.IndexOf($methodStart, [StringComparison]::Ordinal)
    if ($mStart -lt 0) { throw "Patch '$name': method start not found" }
    $mEnd = $text.IndexOf($methodEnd, $mStart + $methodStart.Length, [StringComparison]::Ordinal)
    if ($mEnd -lt 0) { throw "Patch '$name': method end not found" }
    $method = $text.Substring($mStart, $mEnd - $mStart)
    $bStart = $method.IndexOf($branchStart, [StringComparison]::Ordinal)
    if ($bStart -lt 0) { throw "Patch '$name': branch start not found" }
    $bEnd = $method.IndexOf($branchEnd, $bStart + $branchStart.Length, [StringComparison]::Ordinal)
    if ($bEnd -lt 0) { throw "Patch '$name': branch end not found" }
    $branch = $method.Substring($bStart, $bEnd - $bStart)
    $branch = Replace-Exact $branch $old $new $expected $name
    $method = $method.Substring(0, $bStart) + $branch + $method.Substring($bEnd)
    return $text.Substring(0, $mStart) + $method + $text.Substring($mEnd)
}

# -----------------------------------------------------------------------------
# Drafting2D: Fillet / Chamfer pick-point direction fixes.
# Each curve must be compared to the click point used to select that same curve.
# The first-curve arc reversal test must also inspect the first curve, not curve 2.
# -----------------------------------------------------------------------------
$draftRel = 'buCadCamRes/buCadCamResVer5/Editor/Drafting2D.cs'
$draft = Read-Source $draftRel
$draft = Replace-Exact $draft `
    'Point3D.Distance(this.point3D_2, firstSelectedEntity1.EndPoint)' `
    'Point3D.Distance(this.point3D_1, firstSelectedEntity1.EndPoint)' 2 'Drafting2D first pick point'
$draft = Replace-Exact $draft `
    'Point3D.Distance(this.point3D_1, secondSelectedEntity1.StartPoint)' `
    'Point3D.Distance(this.point3D_2, secondSelectedEntity1.StartPoint)' 2 'Drafting2D second pick point'
$draft = Replace-Exact $draft `
    '(num2 >= num1 ? 0 : (secondSelectedEntity1 is Arc ? 1 : (secondSelectedEntity1 is EllipticalArc ? 1 : 0))) != 0)' `
    '(num2 >= num1 ? 0 : (firstSelectedEntity1 is Arc ? 1 : (firstSelectedEntity1 is EllipticalArc ? 1 : 0))) != 0)' 2 'Drafting2D first curve type'
Write-Source $draftRel $draft

# -----------------------------------------------------------------------------
# clsCommand: event precedence, Fillet/Chamfer composite replacement,
# Connect metadata, transform selection continuity, scale guards, offset guards.
# -----------------------------------------------------------------------------
$cmdRel = 'buCadCamRes/buCadCamResVer5/clsCommand.cs'
$cmd = Read-Source $cmdRel

$cmd = Replace-Exact $cmd `
    'ccVars.Action == actionTypeBU.eventFillet && e.Button == MouseButtons.Right | e.Button == MouseButtons.Left' `
    'ccVars.Action == actionTypeBU.eventFillet && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)' 1 'Fillet mouse precedence'
$cmd = Replace-Exact $cmd `
    'ccVars.Action == actionTypeBU.eventChamfer && e.Button == MouseButtons.Right | e.Button == MouseButtons.Left' `
    'ccVars.Action == actionTypeBU.eventChamfer && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)' 1 'Chamfer mouse precedence'
$cmd = Replace-Exact $cmd `
    'ccVars.Action == actionTypeBU.eventConnect && e.Button == MouseButtons.Right | e.Button == MouseButtons.Left' `
    'ccVars.Action == actionTypeBU.eventConnect && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)' 1 'Connect mouse precedence'

foreach ($method in @(
    @{ Start='  public void Fillet(Point3D pntEnd)'; End='  public void Chamfer(Point3D pntEnd)'; Name='Fillet' },
    @{ Start='  public void Chamfer(Point3D pntEnd)'; End='  public void Connect(Point3D pntEnd)'; Name='Chamfer' }
)) {
    $cmd = Replace-InMethodBranch $cmd $method.Start $method.End `
        'else if (subIndex1 >= 0 & subIndex2 == -1)' '    }' `
        'ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] = buVector5.CopyEntities((Entity) curve1, entityDataSet1);' `
        'ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] = buVector5.CopyEntities((Entity) curve2, entData);' 1 "$($method.Name) whole second entity"

    $cmd = Replace-InMethodBranch $cmd $method.Start $method.End `
        'else if (subIndex1 >= 0 & subIndex2 == -1)' '    }' `
        'curve2.StartPoint' 'curve1.StartPoint' 2 "$($method.Name) first composite start point"
    $cmd = Replace-InMethodBranch $cmd $method.Start $method.End `
        'else if (subIndex1 >= 0 & subIndex2 == -1)' '    }' `
        'curve2.EndPoint' 'curve1.EndPoint' 2 "$($method.Name) first composite end point"
    $cmd = Replace-InMethodBranch $cmd $method.Start $method.End `
        'else if (subIndex1 >= 0 & subIndex2 == -1)' '    }' `
        'refEntities.Add((Entity) curve2);' 'refEntities.Add((Entity) curve1);' 1 "$($method.Name) first composite rebuild curve"
}

$cmd = Replace-InSection $cmd '  public void Connect(Point3D pntEnd)' '  public void Explode(bool AddNewEntity)' `
    'ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] = buVector5.CopyEntities(((Entity) curve2).DeepClone<Entity>(), entData1);' `
    'ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] = buVector5.CopyEntities(((Entity) curve2).DeepClone<Entity>(), entData2);' 1 'Connect second entity metadata'

$cmd = Replace-InSection $cmd '  public void RotateClick(Point3D pntBase)' '  public void Mirror(' `
    "      ccVars.UndoDont = true;`r`n      entity.Rotate" `
    "      ccVars.UndoDont = true;`r`n      this.OsnapDeleteByEntityName(clsInit.cVector5.GetEntityName(entity));`r`n      entity.Rotate" 1 'RotateClick remove stale osnap'
$cmd = Replace-InSection $cmd '  public void RotateClick(Point3D pntBase)' '  public void Mirror(' `
    "      entity.Regen(0.01);`r`n      Added.Add" `
    "      entity.Regen(0.01);`r`n      this.OsnapCalculation(entity);`r`n      Added.Add" 1 'RotateClick recalc osnap'

$cmd = Replace-InSection $cmd '  public void Mirror(' '  public void Exchange()' `
    "        this.AddEntity(Ent, OsnapCalc);`r`n      }`r`n    }`r`n    if (DeleteOriginal)" `
    "        this.AddEntity(Ent, OsnapCalc);`r`n      }`r`n      Added.Add(ccVars.SelectionOP.Selections[index].Index);`r`n    }`r`n    if (DeleteOriginal)" 1 'Mirror repeat selection indices'

$cmd = Replace-InSection $cmd '  public void Scale(' '  public void Offset(Point3D pntEnd)' `
    'double factor = !(buNumeric.IsNumeric(num.ToString()) & num != 0.0) ? fixedPoint.DistanceTo(pntEnd) / fixedPoint.DistanceTo(ccVars.SelectionOP.SelectionBoxMax) : fixedPoint.DistanceTo(pntEnd) / num;' `
    "double scaleBaseDistance = fixedPoint.DistanceTo(ccVars.SelectionOP.SelectionBoxMax);`r`n    double factor = buNumeric.IsNumeric(num.ToString()) && Math.Abs(num) > 1E-12 ? fixedPoint.DistanceTo(pntEnd) / num : (Math.Abs(scaleBaseDistance) > 1E-12 ? fixedPoint.DistanceTo(pntEnd) / scaleBaseDistance : 1.0);" 1 'Scale zero denominator guard'
$cmd = Replace-InSection $cmd '  public void Scale(' '  public void Offset(Point3D pntEnd)' `
    "        this.CreateEntity(refEntity, ref Ent);`r`n        Ent.Scale(fixedPoint, factor);`r`n        this.AddEntity(Ent);" `
    "        this.CreateEntity(refEntity, ref Ent);`r`n        if (Ent != null)`r`n        {`r`n          Ent.Scale(fixedPoint, factor);`r`n          this.AddEntity(Ent);`r`n        }" 1 'Scale null entity keep-ratio'
$cmd = Replace-InSection $cmd '  public void Scale(' '  public void Offset(Point3D pntEnd)' `
    "        this.CreateEntity(refEntity, ref Ent);`r`n        Ent.Scale(fixedPoint, sx, sy, sz);`r`n        this.AddEntity(Ent);" `
    "        this.CreateEntity(refEntity, ref Ent);`r`n        if (Ent != null)`r`n        {`r`n          Ent.Scale(fixedPoint, sx, sy, sz);`r`n          this.AddEntity(Ent);`r`n        }" 1 'Scale null entity xyz'

$cmd = Replace-Exact $cmd `
    'double factor = !(buNumeric.IsNumeric(num.ToString()) & num != 0.0) ? point3D.DistanceTo(Points) / point3D.DistanceTo(ccVars.SelectionOP.SelectionBoxMax) : point3D.DistanceTo(Points) / num;' `
    "double scaleBaseDistance = point3D.DistanceTo(ccVars.SelectionOP.SelectionBoxMax);`r`n      double factor = buNumeric.IsNumeric(num.ToString()) && Math.Abs(num) > 1E-12 ? point3D.DistanceTo(Points) / num : (Math.Abs(scaleBaseDistance) > 1E-12 ? point3D.DistanceTo(Points) / scaleBaseDistance : 1.0);" 1 'Dynamic scale zero denominator guard'

foreach ($arr in @('curveArray3','curveArray4','curveArray5','curveArray6','curveArray7','curveArray8','curveArray9','curveArray10')) {
    $cmd = Replace-Exact $cmd "if ($arr != null)" "if ($arr != null && $arr.Length > 0)" 1 "Offset array guard $arr"
}
$cmd = Replace-Exact $cmd 'if (curveArray != null)' 'if (curveArray != null && curveArray.Length > 0)' 1 'Dynamic offset array guard'

Write-Source $cmdRel $cmd

$report = @(
    'CAD/CAM patch applied successfully.',
    'Drafting2D: Fillet/Chamfer click-point and first-curve direction checks corrected.',
    'clsCommand: Fillet/Chamfer/Connect mouse precedence corrected.',
    'clsCommand: composite Fillet/Chamfer branch curve/metadata ownership corrected.',
    'clsCommand: Connect second entity metadata corrected.',
    'clsCommand: RotateClick osnap cache refresh added.',
    'clsCommand: Mirror command repetition selection restored.',
    'clsCommand: Scale zero-denominator and null-entity guards added.',
    'clsCommand: Offset result array length guards added.'
)
$report | Set-Content (Join-Path $root 'CADCAM_PATCH_REPORT.txt') -Encoding UTF8
$report | ForEach-Object { Write-Host $_ -ForegroundColor Green }
