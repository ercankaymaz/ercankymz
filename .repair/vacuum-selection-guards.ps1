$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/vacuum-selection-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buCadCamRes/buCadCamResVer5/Marble/clsMarble.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# Use the selected material consistently. The decompiled path previously found
# items only when FoundMat was already non-null, then silently fell back to the
# active material while keeping stale FoundItems/bounds from the earlier state.
$foundOld = @'
    if (FoundMat != null)
      clsInit.cMarble.FindItemsInsideMaterials(FoundMat, this.activeJob.Items, ref FoundItems);
    else
      FoundMat = this.activeJob.Material;
    double width = FoundMat.Size.Width;
    double height = FoundMat.Size.Height;
    if (FoundItems.Count > 0)
      clsInit.cMarble.GetBoxSizeJobItems(FoundItems, ref point3D3, ref point3D2);
'@
$foundNew = @'
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
if ($text.Contains($foundOld)) {
    $text = $text.Replace($foundOld, $foundNew)
    "FIX vacuum selected material bounds/items consistency: $path" | Tee-Object -Append $log
}

# Within GetVacuumLineByMouse, iterate only the material-filtered item set and
# stop nested scans as soon as the hit is found. This prevents a hit belonging
# to a different material from overwriting the selected vacuum line.
$vacStart = $text.IndexOf('  public void GetVacuumLineByMouse(', [StringComparison]::Ordinal)
if ($vacStart -ge 0) {
    $vacEnd = $text.IndexOf('  public void VacuumAdd(', $vacStart, [StringComparison]::Ordinal)
    if ($vacEnd -gt $vacStart) {
        $vac = $text.Substring($vacStart, $vacEnd - $vacStart)
        $vacOriginal = $vac
        $vac = $vac.Replace('for (int index1 = 0; index1 <= this.activeJob.Items.Count - 1; ++index1)', 'for (int index1 = 0; index1 <= FoundItems.Count - 1 && !flag; ++index1)')
        $vac = $vac.Replace('this.activeJob.Items[index1]', 'FoundItems[index1]')
        $vac = $vac.Replace('for (int index2 = 0; index2 <= FoundItems[index1].CamList.Count - 1; ++index2)', 'for (int index2 = 0; index2 <= FoundItems[index1].CamList.Count - 1 && !flag; ++index2)')
        $vac = $vac.Replace('for (int index3 = 0; index3 <= FoundItems[index1].CamList[index2].WireEntities.Count - 1; ++index3)', 'for (int index3 = 0; index3 <= FoundItems[index1].CamList[index2].WireEntities.Count - 1 && !flag; ++index3)')
        $vac = $vac.Replace('for (int index4 = 0; index4 <= FoundItems[index1].CamList[index2].WireEntities[index3].Count - 1; ++index4)', 'for (int index4 = 0; index4 <= FoundItems[index1].CamList[index2].WireEntities[index3].Count - 1 && !flag; ++index4)')
        if ($vac -ne $vacOriginal) {
            $text = $text.Substring(0, $vacStart) + $vac + $text.Substring($vacEnd)
            "FIX GetVacuumLineByMouse filtered-item traversal and early stop: $path" | Tee-Object -Append $log
        }
    }
}

# If multiple vacuum materials overlap, choose the smallest containing material
# deterministically. If none contains the click, return immediately instead of
# continuing with a stale selected index from a previous interaction.
$selectOld = @'
      int index1 = -1;
      for (int index2 = 0; index2 <= this.activeJob.VacuumMaterials.Count - 1; ++index2)
      {
        MaterialBase5 vacuumMaterial = this.activeJob.VacuumMaterials[index2];
        if (clsInit.cVector5.IsPointInsideBoxsize(pntClick, vacuumMaterial.BoxMinPoint, vacuumMaterial.BoxMaxPoint, Plane.XY))
          index1 = index2;
      }
      if (index1 >= 0)
'@
$selectNew = @'
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
if ($text.Contains($selectOld)) {
    $text = $text.Replace($selectOld, $selectNew)
    "FIX vacuum material deterministic selection and stale-index rejection: $path" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    $patched = 1
} else {
    "NO_MATCH_OR_ALREADY_FIXED vacuum selection contracts: $path" | Tee-Object -Append $log
}

"Patched vacuum files: $patched" | Tee-Object -Append $log
