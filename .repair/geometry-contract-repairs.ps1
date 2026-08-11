$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/geometry-contract-repairs.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

# PR #1 verified contract: EllipseWithCenter receives radii, and its output list
# must not preserve stale vertices when the requested ellipse is invalid.
$vectorPath = 'Decompiled/buCore/buCore/buVector.cs'
if (Test-Path -LiteralPath $vectorPath) {
    $text = [IO.File]::ReadAllText($vectorPath)
    $original = $text

    # Upgrade the PR #2 guard if it has already been inserted by cam-math-guards.
    $oldGuard = @'
if (Center == null || double.IsNaN(MajorRadius) || double.IsInfinity(MajorRadius) ||
			double.IsNaN(MinorRadius) || double.IsInfinity(MinorRadius) ||
			double.IsNaN(Angle) || double.IsInfinity(Angle) ||
			MajorRadius <= 1E-09 || MinorRadius <= 1E-09)
			return;
'@
    $newGuard = @'
if (Vertices == null)
			Vertices = new List<Pnt3D>();
		Vertices.Clear();
		if (Center == null || double.IsNaN(MajorRadius) || double.IsInfinity(MajorRadius) ||
			double.IsNaN(MinorRadius) || double.IsInfinity(MinorRadius) ||
			double.IsNaN(Angle) || double.IsInfinity(Angle) ||
			MajorRadius <= 1E-09 || MinorRadius <= 1E-09)
			return;
'@
    if ($text.Contains($oldGuard)) {
        $text = $text.Replace($oldGuard, $newGuard)
        "FIX EllipseWithCenter stale output vertices on invalid geometry: $vectorPath" | Tee-Object -Append $log
    }

    # Fallback for the original decompiled source shape from the validated PR #1 repair.
    $oldBody = @'
    try
    {
      this.EllipseArcWithCenter(Center, MajorRadius, MinorRadius, 0.0, 360.0, Angle, Plane, EntResolution, ref Vertices);
'@
    $newBody = @'
    try
    {
      if (Vertices == null)
        Vertices = new List<Pnt3D>();
      Vertices.Clear();
      if (Center == null || double.IsNaN(MajorRadius) || double.IsInfinity(MajorRadius) || double.IsNaN(MinorRadius) || double.IsInfinity(MinorRadius) || double.IsNaN(Angle) || double.IsInfinity(Angle) || MajorRadius <= 1E-9 || MinorRadius <= 1E-9)
        return;
      this.EllipseArcWithCenter(Center, MajorRadius, MinorRadius, 0.0, 360.0, Angle, Plane, EntResolution, ref Vertices);
'@
    if ($text.Contains($oldBody)) {
        $text = $text.Replace($oldBody, $newBody)
        "FIX EllipseWithCenter finite radii and stale output contract: $vectorPath" | Tee-Object -Append $log
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($vectorPath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    } else {
        "NO_MATCH_OR_ALREADY_FIXED EllipseWithCenter contract: $vectorPath" | Tee-Object -Append $log
    }
} else {
    "MISS $vectorPath" | Tee-Object -Append $log
}

# PR #1 verified contract: ProfileOperationEllipse Width/Height are full dimensions,
# whereas buVector.EllipseWithCenter expects MajorRadius/MinorRadius.
$camPath = 'Decompiled/buCore/buCore/buCamCalc.cs'
if (Test-Path -LiteralPath $camPath) {
    $text = [IO.File]::ReadAllText($camPath)
    $original = $text
    $old = 'buAppCalc.cVector.EllipseWithCenter(Center, ((ProfileOperationEllipse) P).Width, ((ProfileOperationEllipse) P).Height, ((ProfileOperationEllipse) P).Angle, new WorkPlane(), buSystem.EntitiesResolution, ref pnt3DList2);'
    $new = 'buAppCalc.cVector.EllipseWithCenter(Center, ((ProfileOperationEllipse) P).Width / 2.0, ((ProfileOperationEllipse) P).Height / 2.0, ((ProfileOperationEllipse) P).Angle, new WorkPlane(), buSystem.EntitiesResolution, ref pnt3DList2);'
    if ($text.Contains($old)) {
        $text = $text.Replace($old, $new)
        "FIX ProfileOperationEllipse full dimensions converted to radii: $camPath" | Tee-Object -Append $log
    }
    if ($text -ne $original) {
        [IO.File]::WriteAllText($camPath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    } else {
        "NO_MATCH_OR_ALREADY_FIXED ProfileOperationEllipse radii: $camPath" | Tee-Object -Append $log
    }
} else {
    "MISS $camPath" | Tee-Object -Append $log
}

"Patched geometry contract files: $patched" | Tee-Object -Append $log
