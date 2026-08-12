$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/editor-runtime-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$editorPath = 'Decompiled/buCadCamRes/buCadCamResVer5/Editor/clsEditorV2.cs'
if (Test-Path -LiteralPath $editorPath) {
    $text = [IO.File]::ReadAllText($editorPath)
    $original = $text

    # A duplicate/zero-length second point makes AddLine return null. The next
    # click then calls ExtendLine(null, end), and the decompiled implementation
    # dereferences other.EndPoint. Guard the public command boundary.
    $oldExtend = @'
  public Line ExtendLine(Line other, UClick end)
  {
    Line line;
'@
    $newExtend = @'
  public Line ExtendLine(Line other, UClick end)
  {
    if (other == null || end == null)
      return null;
    Line line;
'@
    if ($text.Contains($oldExtend)) {
        $text = $text.Replace($oldExtend, $newExtend)
        "FIX editor ExtendLine null/duplicate-point guard: $editorPath" | Tee-Object -Append $log
    }

    # Polyline callers normally provide valid click objects, but malformed
    # command state can leave a null entry. Avoid dereferencing it while
    # converting the click list to geometry.
    $oldPoly = @'
    List<Point3D> points = new List<Point3D>();
    for (int index = 0; index <= refPoints.Count - 1; ++index)
      points.Add(new Point3D(refPoints[index].Position.X, refPoints[index].Position.Y));
'@
    $newPoly = @'
    List<Point3D> points = new List<Point3D>();
    for (int index = 0; index <= refPoints.Count - 1; ++index)
    {
      if (refPoints[index] == null)
        continue;
      points.Add(new Point3D(refPoints[index].Position.X, refPoints[index].Position.Y));
    }
'@
    if ($text.Contains($oldPoly)) {
        $text = $text.Replace($oldPoly, $newPoly)
        "FIX editor polyline null click-state guard: $editorPath" | Tee-Object -Append $log
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($editorPath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    } else {
        "NO_MATCH_OR_ALREADY_FIXED editor runtime: $editorPath" | Tee-Object -Append $log
    }
} else {
    "MISS $editorPath" | Tee-Object -Append $log
}

"Patched editor runtime files: $patched" | Tee-Object -Append $log
