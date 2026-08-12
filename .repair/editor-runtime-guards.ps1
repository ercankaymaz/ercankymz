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

$draftPath = 'Decompiled/buCadCamRes/buCadCamResVer5/Editor/Drafting2D.cs'
if (Test-Path -LiteralPath $draftPath) {
    $draft = [IO.File]::ReadAllText($draftPath)
    $draftOriginal = $draft

    # The sketch line continuation command stores the previous generated entity
    # in click-state. A corrupted/stale state can contain a different Entity type;
    # the decompiled explicit cast throws before ExtendLine's null guard can help.
    $oldLineCast = 'clsInit.appEditor2.ExtendLine((Line) Drafting2D.points[Drafting2D.points.Count - 2].Entity, Drafting2D.points[Drafting2D.points.Count - 1])'
    $newLineCast = 'clsInit.appEditor2.ExtendLine(Drafting2D.points[Drafting2D.points.Count - 2].Entity as Line, Drafting2D.points[Drafting2D.points.Count - 1])'
    if ($draft.Contains($oldLineCast)) {
        $draft = $draft.Replace($oldLineCast, $newLineCast)
        "FIX editor sketch line continuation stale-entity cast: $draftPath" | Tee-Object -Append $log
    }

    # The recovered array safety limit counted only cells. A large source
    # selection multiplies every non-origin cell and can create orders of
    # magnitude more entities than the intended 10k editor cap. Count actual
    # clones, and reject a zero mouse step that would stack all copies exactly.
    $oldArraySafety = @'
      if ((long) columns * rows * levels > 10000L)
        throw new InvalidOperationException("Array entity count is greater than the safe editor limit.");
      Vector3D mouseStep = new Vector3D(Drafting2D.points[0].Pnt3D, Drafting2D.points[1].Pnt3D);
      clsInit.appEditor2.UndoBuffer();
      List<Entity> sources = new List<Entity>(this.selEntities);
'@
    $newArraySafety = @'
      long cellCount = (long)columns * rows * levels;
      List<Entity> sources = new List<Entity>(this.selEntities);
      long generatedEntityCount = Math.Max(0L, cellCount - 1L) * sources.Count;
      if (generatedEntityCount > 10000L)
        throw new InvalidOperationException("Generated array entity count is greater than the safe editor limit.");
      Vector3D mouseStep = new Vector3D(Drafting2D.points[0].Pnt3D, Drafting2D.points[1].Pnt3D);
      if (clsVar.varInterface.ArrayLineerVar.MoveByMouse && cellCount > 1L && Drafting2D.points[0].Pnt3D.DistanceTo(Drafting2D.points[1].Pnt3D) <= 1E-09)
        throw new InvalidOperationException("Array reference step must be greater than zero.");
      clsInit.appEditor2.UndoBuffer();
'@
    if ($draft.Contains($oldArraySafety)) {
        $draft = $draft.Replace($oldArraySafety, $newArraySafety)
        "FIX editor array actual clone-count and zero-step guards: $draftPath" | Tee-Object -Append $log
    }

    if ($draft -ne $draftOriginal) {
        [IO.File]::WriteAllText($draftPath, $draft, [Text.UTF8Encoding]::new($false))
        $patched++
    } else {
        "NO_MATCH_OR_ALREADY_FIXED drafting runtime: $draftPath" | Tee-Object -Append $log
    }
} else {
    "MISS $draftPath" | Tee-Object -Append $log
}

"Patched editor runtime files: $patched" | Tee-Object -Append $log
