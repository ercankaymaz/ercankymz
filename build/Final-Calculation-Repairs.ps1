$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$utf8 = New-Object Text.UTF8Encoding($false)

function Get-Text([string]$rel) {
    $p = Join-Path $root $rel
    if (-not (Test-Path $p)) { throw "Missing source: $rel" }
    return [IO.File]::ReadAllText($p)
}
function Set-Text([string]$rel,[string]$text) {
    [IO.File]::WriteAllText((Join-Path $root $rel),$text,$utf8)
}
function Replace-Required([string]$text,[string]$old,[string]$new,[string]$name,[int]$expected=1) {
    $count = ([regex]::Matches($text,[regex]::Escape($old))).Count
    if ($count -ne $expected) { throw "${name}: expected $expected occurrence(s), found $count" }
    Write-Host "$name ($count)" -ForegroundColor Green
    return $text.Replace($old,$new)
}
function Replace-Optional([string]$text,[string]$old,[string]$new,[string]$name) {
    $count = ([regex]::Matches($text,[regex]::Escape($old))).Count
    if ($count -gt 0) {
        Write-Host "$name ($count)" -ForegroundColor Green
        return $text.Replace($old,$new)
    }
    return $text
}
function Replace-InSection([string]$text,[string]$startMarker,[string]$endMarker,[string]$old,[string]$new,[string]$name,[int]$expected=1) {
    $start = $text.IndexOf($startMarker,[StringComparison]::Ordinal)
    if ($start -lt 0) { throw "${name}: start marker not found" }
    $end = $text.IndexOf($endMarker,$start + $startMarker.Length,[StringComparison]::Ordinal)
    if ($end -lt 0) { throw "${name}: end marker not found" }
    $section = $text.Substring($start,$end-$start)
    $count = ([regex]::Matches($section,[regex]::Escape($old))).Count
    if ($count -ne $expected) { throw "${name}: expected $expected in section, found $count" }
    $section = $section.Replace($old,$new)
    Write-Host "$name ($count)" -ForegroundColor Green
    return $text.Substring(0,$start) + $section + $text.Substring($end)
}

# -----------------------------------------------------------------------------
# Remaining decompiler compile artifacts.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/buDialogExtenders/FileDialogControlBase.cs'
$t=Get-Text $rel
if (-not $t.Contains('internal void RaiseFilterChanged(')) {
    $anchor='  public FileDialogControlBase() => Class5.smethod_29(this);'
    $method=@'
  internal void RaiseFilterChanged(IWin32Window sender, int index)
  {
    FilterChangedEventHandler handler = this.EventFilterChanged;
    if (handler != null)
      handler(sender, index);
  }

'@
    $t=Replace-Required $t $anchor ($method+$anchor) 'FileDialog filter event raiser'
}
Set-Text $rel $t

$rel='buCadCamRes/ns8/Class5.cs'
$t=Get-Text $rel
$eventOld=@'
    if (fileDialogControlBase_0.EventFilterChanged == null)
      return;
    fileDialogControlBase_0.EventFilterChanged(iwin32Window_0, int_0);
'@
$eventNew=@'
    fileDialogControlBase_0.RaiseFilterChanged(iwin32Window_0, int_0);
'@
$t=Replace-Required $t $eventOld $eventNew 'FileDialog event invocation repair'
Set-Text $rel $t

$rel='buCadCamRes/buCadCamResVer5/clsCommand.cs'
$t=Get-Text $rel
$t=Replace-InSection $t '  public void CreateEntity(Entity refEntity, ref Entity Ent)' '  public void AddTempEntity(Entity Ent)' '      case Ellipse _:' '      case Ellipse ellipseEntity when ellipseEntity.GetType() == typeof(Ellipse):' 'CreateEntity ellipse subtype ordering'
$t=Replace-InSection $t '  public void CreateEntity(Entity refEntity, ref Entity Ent)' '  public void AddTempEntity(Entity Ent)' '      case Text _:' '      case Text textEntity when textEntity.GetType() == typeof(Text):' 'CreateEntity text/dimension ordering'
$t=Replace-InSection $t '  public void Offset(Point3D pntEnd)' '  public void Explode(bool AddNewEntity)' '                case Circle _:' '                case Circle circleEntity when circleEntity.GetType() == typeof(Circle):' 'Offset circle/arc ordering'
$t=Replace-InSection $t '  public void Offset(Point3D pntEnd)' '  public void Explode(bool AddNewEntity)' '                case Ellipse _:' '                case Ellipse ellipseEntity when ellipseEntity.GetType() == typeof(Ellipse):' 'Offset ellipse/elliptical-arc ordering'
$t=Replace-InSection $t '  public void Explode(bool AddNewEntity)' '  public void MoveUpDown(' '          case Ellipse _:' '          case Ellipse ellipseEntity when ellipseEntity.GetType() == typeof(Ellipse):' 'Explode ellipse/elliptical-arc ordering'
$t=Replace-InSection $t '  public void GetEntityInfo(Entity Ent, ref string sInfo)' '  public void' '        case Ellipse _:' '        case Ellipse ellipseEntity when ellipseEntity.GetType() == typeof(Ellipse):' 'EntityInfo ellipse ordering'
$t=Replace-InSection $t '  public void GetEntityInfo(Entity Ent, ref string sInfo)' '  public void' '        case CylindricalSurface _:' '        case CylindricalSurface cylinderEntity when cylinderEntity.GetType() == typeof(CylindricalSurface):' 'EntityInfo conical ordering'
$t=Replace-InSection $t '  public void GetEntityInfo(Entity Ent, ref string sInfo)' '  public void' '        case RevolvedSurface _:' '        case RevolvedSurface revolvedEntity when revolvedEntity.GetType() == typeof(RevolvedSurface):' 'EntityInfo toroidal ordering'
Set-Text $rel $t

# The earlier compatibility pass pointed these fields at the old buCore runtime.
# The rebuilt buClass contains the canonical language lists used by the source.
$rel='buCadCamRes/buCadCamResVer5/Marble/clsMarble.cs'
$t=Get-Text $rel
$t=$t.Replace('buMarbleCalc.LangMarbleMessage','buMarble.LangMarbleMessage')
$t=$t.Replace('buMarbleCalc.LangMarbleCaptions','buMarble.LangMarbleCaptions')
Set-Text $rel $t

# Second buEntity-shadow block in Profile mirror path.
$rel='buCadCamRes/buCadCamResVer5/Profile/clsProfile.cs'
$t=Get-Text $rel
$mirrorOld=@'
            buEntity buEntity = (buEntity) null;
            buEntity.Copy(mirroredOP.EntityMultiXYPlane[index], ref buEntity);
            clsInit.cVector5.Mirror(BasePoint, MirrorPoint, planeMirror, ref buEntity);
            entitiesList.Entities.Add(buEntity);
'@
$mirrorNew=@'
            buEntity mirroredEntity = (buEntity) null;
            buEntity.Copy(mirroredOP.EntityMultiXYPlane[index], ref mirroredEntity);
            clsInit.cVector5.Mirror(BasePoint, MirrorPoint, planeMirror, ref mirroredEntity);
            entitiesList.Entities.Add(mirroredEntity);
'@
$t=Replace-Required $t $mirrorOld $mirrorNew 'Profile mirror entity shadow repair'
Set-Text $rel $t

# -----------------------------------------------------------------------------
# buCore: robust tilted-saw projection and known 45-degree path-length defects.
# -----------------------------------------------------------------------------
$rel='buCore/buCore/buCamCalc.cs'
$t=Get-Text $rel
if (-not $t.Contains('private static double ProjectLengthByA(')) {
    $anchor='  public buCamCalc()'
    $helper=@'
  private static double ProjectLengthByA(double delta, double angleA)
  {
    if (double.IsNaN(delta) || double.IsInfinity(delta) || double.IsNaN(angleA) || double.IsInfinity(angleA))
      throw new ArgumentOutOfRangeException("Invalid saw projection input.");
    double cosine = Math.Cos(buConversion.DegreeToRadian(angleA));
    if (Math.Abs(cosine) < 1E-6)
      throw new ArgumentOutOfRangeException("angleA", "Saw angle is too close to 90 degrees for a finite projected move.");
    double result = delta / cosine;
    if (double.IsNaN(result) || double.IsInfinity(result))
      throw new ArithmeticException("Invalid saw projected length.");
    return result;
  }

'@
    $t=Replace-Required $t $anchor ($helper+$anchor) 'Saw projection guard'
}
$projectionPattern='(?m)^(?<indent>\s*)(?<lhs>(?:double\s+\w+|\w+)\s*=\s*)(?<delta>.+?)\s*/\s*Math\.Cos\(buConversion\.DegreeToRadian\((?<angle>[A-Za-z0-9_\.]+\.A)\)\);\s*$'
$projectionCount=([regex]::Matches($t,$projectionPattern)).Count
if ($projectionCount -lt 10) { throw "Expected multiple A-axis projection divisions, found $projectionCount" }
$t=[regex]::Replace($t,$projectionPattern,'${indent}${lhs}ProjectLengthByA(${delta}, ${angle});')
Write-Host "Protected A-axis projection divisions: $projectionCount" -ForegroundColor Green

# CalculateGrindingContourSaw had correct projected lengths calculated but then ignored.
$t=Replace-Required $t 'buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe1 - pnt3D5.Z, ref calcPoint1);' 'buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), num21, ref calcPoint1);' 'Grinding saw first projected approach'
$t=Replace-Required $t 'buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe1 - pnt3D5.Z, ref calcPoint2);' 'buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), num21, ref calcPoint2);' 'Grinding saw second projected approach'
$t=Replace-Required $t 'buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe2 - pnt3D6.Z, ref calcPoint3);' 'buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), num22, ref calcPoint3);' 'Grinding saw projected step-up leave'
$t=Replace-Required $t 'buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe2 - pnt3D6.Z, ref calcPoint4);' 'buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), num21, ref calcPoint4);' 'Grinding saw projected safe leave'

# Older saw-wireframe path had one unprojected plunge despite calculating Length1.
$t=Replace-Required $t 'buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Distance.Safe, ref calcPoint);' 'buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Length1, ref calcPoint);' 'Wireframe saw projected plunge'

# Profile ellipse Width/Height are full dimensions; EllipseWithCenter expects radii.
$t=Replace-Required $t 'buAppCalc.cVector.EllipseWithCenter(Center, ((ProfileOperationEllipse) P).Width, ((ProfileOperationEllipse) P).Height, ((ProfileOperationEllipse) P).Angle, new WorkPlane(), buSystem.EntitiesResolution, ref pnt3DList2);' 'buAppCalc.cVector.EllipseWithCenter(Center, ((ProfileOperationEllipse) P).Width / 2.0, ((ProfileOperationEllipse) P).Height / 2.0, ((ProfileOperationEllipse) P).Angle, new WorkPlane(), buSystem.EntitiesResolution, ref pnt3DList2);' 'Profile ellipse diameter/radius correction'
Set-Text $rel $t

# -----------------------------------------------------------------------------
# buVector: miter/corner modification used the first edge angle twice, and one
# branch projected an already-projected length a second time.
# -----------------------------------------------------------------------------
$rel='buCore/buCore/buVector.cs'
$t=Get-Text $rel
$t=Replace-Required $t 'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - num3, StartPointType.Start, ref ModifiedLastEntity);' 'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - ModifyLength / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A)), StartPointType.Start, ref ModifiedLastEntity);' 'Corner modify last-edge A compensation 1'
$t=Replace-Required $t 'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - num3, StartPointType.End, ref ModifiedLastEntity);' 'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - ModifyLength / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A)), StartPointType.End, ref ModifiedLastEntity);' 'Corner modify last-edge A compensation 2'
$t=Replace-Required $t 'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - num4, StartPointType.Start, ref ModifiedLastEntity);' 'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - ModifyLength / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A)), StartPointType.Start, ref ModifiedLastEntity);' 'Corner modify last-edge A compensation 3'
$t=Replace-Required $t 'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - num4, StartPointType.End, ref ModifiedLastEntity);' 'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - ModifyLength / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A)), StartPointType.End, ref ModifiedLastEntity);' 'Corner modify last-edge A compensation 4'
$t=Replace-Required $t 'double CutLength2 = CutLength1 / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A));' 'double CutLength2 = num2 / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A));' 'Remove double A compensation normal'
$t=Replace-Required $t 'double CutLength3 = CutLength1 / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A));' 'double CutLength3 = num2 / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A));' 'Remove double A compensation reverse'

# Ellipse generator must not emit NaN/Infinity or negative-radius geometry.
$ellipseAnchor=@'
    try
    {
      this.EllipseArcWithCenter(Center, MajorRadius, MinorRadius, 0.0, 360.0, Angle, Plane, EntResolution, ref Vertices);
'@
$ellipseNew=@'
    try
    {
      if (Vertices == null)
        Vertices = new List<Pnt3D>();
      Vertices.Clear();
      if (Center == null || double.IsNaN(MajorRadius) || double.IsInfinity(MajorRadius) || double.IsNaN(MinorRadius) || double.IsInfinity(MinorRadius) || double.IsNaN(Angle) || double.IsInfinity(Angle) || MajorRadius <= 1E-9 || MinorRadius <= 1E-9)
        return;
      this.EllipseArcWithCenter(Center, MajorRadius, MinorRadius, 0.0, 360.0, Angle, Plane, EntResolution, ref Vertices);
'@
$t=Replace-Required $t $ellipseAnchor $ellipseNew 'Ellipse finite positive-radius guard'
Set-Text $rel $t

# -----------------------------------------------------------------------------
# buNumeric: prevent divide-by-zero and malformed point/value lists from bad input.
# -----------------------------------------------------------------------------
$rel='buCore/buCore/buNumeric.cs'
$t=Get-Text $rel
$eqOld=@'
      if (Math.Abs(X1 - X2) < 1E-10)
      {
        X3 = X1;
      }
      else
      {
        double num = (Y2 - Y1) / (X2 - X1);
        X3 = (Y3 - Y1) / num + X1;
      }
'@
$eqNew=@'
      if (Math.Abs(X1 - X2) < 1E-10 || Math.Abs(Y2 - Y1) < 1E-10)
      {
        X3 = X1;
      }
      else
      {
        double num = (Y2 - Y1) / (X2 - X1);
        X3 = (Y3 - Y1) / num + X1;
        if (double.IsNaN(X3) || double.IsInfinity(X3))
          X3 = X1;
      }
'@
$t=Replace-Required $t $eqOld $eqNew 'Linear interpolation finite guard'
$countOld=@'
    double num1 = (LastValue - FirstValue) / ((double) Count - 1.0);
    for (double num2 = 0.0; num2 <= (double) Count - 2.0; ++num2)
      ValueList.Add(FirstValue + num1 * num2);
    ValueList.Add(LastValue);
'@
$countNew=@'
    if (ValueList == null || Count <= 0)
      return;
    if (Count == 1)
    {
      ValueList.Add(FirstValue);
      return;
    }
    double num1 = (LastValue - FirstValue) / ((double) Count - 1.0);
    for (double num2 = 0.0; num2 <= (double) Count - 2.0; ++num2)
      ValueList.Add(FirstValue + num1 * num2);
    ValueList.Add(LastValue);
'@
$t=Replace-Required $t $countOld $countNew 'Count interpolation guard'
$divideOld=@'
    Values.Clear();
    double num1 = (EndValue - StartValue) / (double) (DevideCount - 1);
    double num2 = StartValue;
    Values.Add(StartValue);
    for (int index = 0; index <= DevideCount - 3; ++index)
    {
      num2 += num1;
      Values.Add(num2);
    }
    Values.Add(EndValue);
'@
$divideNew=@'
    if (Values == null)
      Values = new List<double>();
    Values.Clear();
    if (DevideCount <= 0)
      return;
    Values.Add(StartValue);
    if (DevideCount == 1)
      return;
    double num1 = (EndValue - StartValue) / (double) (DevideCount - 1);
    double num2 = StartValue;
    for (int index = 0; index <= DevideCount - 3; ++index)
    {
      num2 += num1;
      Values.Add(num2);
    }
    Values.Add(EndValue);
'@
$t=Replace-Required $t $divideOld $divideNew 'Divide-count guard'
Set-Text $rel $t

# -----------------------------------------------------------------------------
# Router 3-axis vector-to-BC conversion discarded vector normalization.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/buCadCamResVer5/Router3AX/clsRouter3AX.cs'
$t=Get-Text $rel
$ijkOld=@'
    Math.Sqrt(I * I + J * J + K * K);
    double d = Math.Asin(I);
    double num1 = Math.Cos(d);
    double num2 = Math.Atan2(J / num1, K / num1);
    B_deg = d * 180.0 / Math.PI;
    C_deg = num2 * 180.0 / Math.PI;
'@
$ijkNew=@'
    double length = Math.Sqrt(I * I + J * J + K * K);
    if (double.IsNaN(length) || double.IsInfinity(length) || length <= 1E-12)
    {
      B_deg = 0.0;
      C_deg = 0.0;
      return;
    }
    double normalizedI = I / length;
    double normalizedJ = J / length;
    double normalizedK = K / length;
    normalizedI = Math.Max(-1.0, Math.Min(1.0, normalizedI));
    double d = Math.Asin(normalizedI);
    double c = Math.Atan2(normalizedJ, normalizedK);
    B_deg = d * 180.0 / Math.PI;
    C_deg = c * 180.0 / Math.PI;
'@
$t=Replace-Required $t $ijkOld $ijkNew 'Router IJK normalization'
Set-Text $rel $t

# -----------------------------------------------------------------------------
# Vacuum: use the selected vacuum material/items consistently and never continue
# with an old selected index when the click did not belong to a material.
# -----------------------------------------------------------------------------
$rel='buCadCamRes/buCadCamResVer5/Marble/clsMarble.cs'
$t=Get-Text $rel
$foundOld=@'
    if (FoundMat != null)
      clsInit.cMarble.FindItemsInsideMaterials(FoundMat, this.activeJob.Items, ref FoundItems);
    else
      FoundMat = this.activeJob.Material;
    double width = FoundMat.Size.Width;
    double height = FoundMat.Size.Height;
    if (FoundItems.Count > 0)
      clsInit.cMarble.GetBoxSizeJobItems(FoundItems, ref point3D3, ref point3D2);
'@
$foundNew=@'
    if (FoundMat == null)
      FoundMat = this.activeJob.Material;
    if (FoundMat == null)
      return;
    clsInit.cMarble.FindItemsInsideMaterials(FoundMat, this.activeJob.Items, ref FoundItems);
    point3D3 = buVector5.ToPoint3D(FoundMat.BoxMinPoint);
    point3D2 = buVector5.ToPoint3D(FoundMat.BoxMaxPoint);
    double width = Math.Abs(point3D2.X - point3D3.X);
    double height = Math.Abs(point3D2.Y - point3D3.Y);
    if (FoundItems.Count > 0)
      clsInit.cMarble.GetBoxSizeJobItems(FoundItems, ref point3D3, ref point3D2);
'@
$t=Replace-Required $t $foundOld $foundNew 'Vacuum selected material bounds'

$vacStart=$t.IndexOf('  public void GetVacuumLineByMouse(',[StringComparison]::Ordinal)
$vacEnd=$t.IndexOf('  public void VacuumAdd(',$vacStart,[StringComparison]::Ordinal)
if($vacStart -lt 0 -or $vacEnd -lt 0){throw 'Vacuum line method markers not found'}
$vac=$t.Substring($vacStart,$vacEnd-$vacStart)
$vac=$vac.Replace('for (int index1 = 0; index1 <= this.activeJob.Items.Count - 1; ++index1)','for (int index1 = 0; index1 <= FoundItems.Count - 1 && !flag; ++index1)')
$vac=$vac.Replace('this.activeJob.Items[index1]','FoundItems[index1]')
$vac=$vac.Replace('for (int index2 = 0; index2 <= FoundItems[index1].CamList.Count - 1; ++index2)','for (int index2 = 0; index2 <= FoundItems[index1].CamList.Count - 1 && !flag; ++index2)')
$vac=$vac.Replace('for (int index3 = 0; index3 <= FoundItems[index1].CamList[index2].WireEntities.Count - 1; ++index3)','for (int index3 = 0; index3 <= FoundItems[index1].CamList[index2].WireEntities.Count - 1 && !flag; ++index3)')
$vac=$vac.Replace('for (int index4 = 0; index4 <= FoundItems[index1].CamList[index2].WireEntities[index3].Count - 1; ++index4)','for (int index4 = 0; index4 <= FoundItems[index1].CamList[index2].WireEntities[index3].Count - 1 && !flag; ++index4)')
$t=$t.Substring(0,$vacStart)+$vac+$t.Substring($vacEnd)

$selectOld=@'
      int index1 = -1;
      for (int index2 = 0; index2 <= this.activeJob.VacuumMaterials.Count - 1; ++index2)
      {
        MaterialBase5 vacuumMaterial = this.activeJob.VacuumMaterials[index2];
        if (clsInit.cVector5.IsPointInsideBoxsize(pntClick, vacuumMaterial.BoxMinPoint, vacuumMaterial.BoxMaxPoint, Plane.XY))
          index1 = index2;
      }
      if (index1 >= 0)
'@
$selectNew=@'
      int index1 = -1;
      double smallestArea = double.MaxValue;
      for (int index2 = 0; index2 <= this.activeJob.VacuumMaterials.Count - 1; ++index2)
      {
        MaterialBase5 vacuumMaterial = this.activeJob.VacuumMaterials[index2];
        if (clsInit.cVector5.IsPointInsideBoxsize(pntClick, vacuumMaterial.BoxMinPoint, vacuumMaterial.BoxMaxPoint, Plane.XY))
        {
          double area = Math.Abs(vacuumMaterial.Size.Width * vacuumMaterial.Size.Height);
          if (area < smallestArea)
          {
            smallestArea = area;
            index1 = index2;
          }
        }
      }
      if (index1 < 0)
        return;
      if (index1 >= 0)
'@
$t=Replace-Required $t $selectOld $selectNew 'Vacuum material deterministic selection'
Set-Text $rel $t

$report = @(
  'FINAL CALCULATION REPAIRS APPLIED',
  '45-degree saw: projected approach/leave lengths now use A-angle compensated values.',
  'Saw paths: near-90-degree cosine divisions are rejected instead of generating Infinity/huge moves.',
  'Miter/corner modify: last-edge A angle is used and double cosine compensation removed.',
  'Profile ellipse: UI width/height converted to radii for core ellipse generation.',
  'Ellipse generator: invalid/NaN/negative radii rejected.',
  'Numeric interpolation: zero-count/one-count and zero-slope divisions guarded.',
  'Router IJK->BC: input vector normalized and zero-vector guarded.',
  'Vacuum: selected material bounds/items are used consistently and stale selection is rejected.',
  'Compiler artifacts: event invocation, switch subtype ordering, language fields and Profile mirror shadow repaired.'
)
$reportPath=Join-Path $root 'CALCULATION_REPAIR_REPORT.txt'
$report | Set-Content $reportPath -Encoding UTF8
$report | ForEach-Object { Write-Host $_ -ForegroundColor Cyan }
