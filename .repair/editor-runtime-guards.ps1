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

    # Offset-by-mouse at exactly the source curve generates a zero-offset clone.
    # Manual zero offset does the same. Do not create coincident duplicate CAD
    # entities, and use the committed click rather than mutable mouse-preview state
    # when choosing the manual offset side.
    $oldMouseOffset = @'
        double amount = curve.PointAt(t).DistanceTo(Drafting2D.points[0].Pnt3D);
        ICurve[] positiveOffsets = curve.Offset(amount, Vector3D.AxisZ, true);
'@
    $newMouseOffset = @'
        double amount = curve.PointAt(t).DistanceTo(Drafting2D.points[0].Pnt3D);
        if (double.IsNaN(amount) || double.IsInfinity(amount) || amount <= 1E-09)
          continue;
        ICurve[] positiveOffsets = curve.Offset(amount, Vector3D.AxisZ, true);
'@
    if ($draft.Contains($oldMouseOffset)) {
        $draft = $draft.Replace($oldMouseOffset, $newMouseOffset)
        "FIX editor mouse-offset zero/non-finite duplicate guard: $draftPath" | Tee-Object -Append $log
    }

    $oldManualOffset = @'
        double offsetValue = clsVar.varEditorRuntimeSet.OffsetValue;
        ICurve[] positiveOffsets = curve.Offset(offsetValue, Vector3D.AxisZ, true);
'@
    $newManualOffset = @'
        double offsetValue = clsVar.varEditorRuntimeSet.OffsetValue;
        if (double.IsNaN(offsetValue) || double.IsInfinity(offsetValue) || Math.Abs(offsetValue) <= 1E-09)
          continue;
        ICurve[] positiveOffsets = curve.Offset(offsetValue, Vector3D.AxisZ, true);
'@
    if ($draft.Contains($oldManualOffset)) {
        $draft = $draft.Replace($oldManualOffset, $newManualOffset)
        $draft = $draft.Replace('positive.Project(this.current, out t)', 'positive.Project(Drafting2D.points[0].Pnt3D, out t)')
        $draft = $draft.Replace('positive.PointAt(t).DistanceTo(this.current)', 'positive.PointAt(t).DistanceTo(Drafting2D.points[0].Pnt3D)')
        $draft = $draft.Replace('negative.Project(this.current, out t)', 'negative.Project(Drafting2D.points[0].Pnt3D, out t)')
        $draft = $draft.Replace('negative.PointAt(t).DistanceTo(this.current)', 'negative.PointAt(t).DistanceTo(Drafting2D.points[0].Pnt3D)')
        "FIX editor manual-offset zero/non-finite and committed-click side selection: $draftPath" | Tee-Object -Append $log
    }

    # EventTrim dereferences Entities[index] after checking only index == -1.
    # int_0 is cursor-derived mutable state and can become stale after an edit.
    $oldTrimIndex = @'
      int index = this.int_0[0];
      if (index == -1)
        return;
      Entity entity = this.Entities[index];
'@
    $newTrimIndex = @'
      int index = this.int_0[0];
      if (index < 0 || index >= this.Entities.Count)
        return;
      Entity entity = this.Entities[index];
'@
    if ($draft.Contains($oldTrimIndex)) {
        $draft = $draft.Replace($oldTrimIndex, $newTrimIndex)
        "FIX editor trim stale entity-index bounds guard: $draftPath" | Tee-Object -Append $log
    }

    # Break accepts any Entity, casts it to ICurve and immediately calls Project.
    # Non-curve selections must be rejected before that dereference.
    $oldBreakCurve = @'
    ICurve curve = selEntity as ICurve;
    ICurve lower = (ICurve) null;
    ICurve upper = (ICurve) null;
    double t;
    if (curve.Project(refPoint, out t))
'@
    $newBreakCurve = @'
    ICurve curve = selEntity as ICurve;
    if (curve == null || refPoint == null)
      return;
    ICurve lower = (ICurve) null;
    ICurve upper = (ICurve) null;
    double t;
    if (curve.Project(refPoint, out t))
'@
    if ($draft.Contains($oldBreakCurve)) {
        $draft = $draft.Replace($oldBreakCurve, $newBreakCurve)
        "FIX editor break non-curve/null point guard: $draftPath" | Tee-Object -Append $log
    }

    # Validate the cursor-derived entity index before handing it to Extend. The
    # original code checked it only after the external command returned.
    $oldExtendIndex = @'
        Entity entityExtended = (Entity) null;
        clsVar.varEditorRuntimeSet.ExtendLength = clsItem.frmEditorV2.spn_extndlen.Value;
        clsInit.appCommand.Extend(clsItem.frmEditorV2.viewport.Entities, this.int_0[0], this.current, clsVar.varEditorRuntimeSet.ExtendLength, ref entityExtended);
'@
    $newExtendIndex = @'
        int extendIndex = this.int_0[0];
        if (extendIndex < 0 || extendIndex >= this.Entities.Count || this.current == null)
        {
          this.ClearAllPreviousCommandData();
          return;
        }
        Entity entityExtended = (Entity) null;
        clsVar.varEditorRuntimeSet.ExtendLength = clsItem.frmEditorV2.spn_extndlen.Value;
        if (double.IsNaN(clsVar.varEditorRuntimeSet.ExtendLength) || double.IsInfinity(clsVar.varEditorRuntimeSet.ExtendLength) || Math.Abs(clsVar.varEditorRuntimeSet.ExtendLength) <= 1E-09)
        {
          this.ClearAllPreviousCommandData();
          return;
        }
        clsInit.appCommand.Extend(clsItem.frmEditorV2.viewport.Entities, extendIndex, this.current, clsVar.varEditorRuntimeSet.ExtendLength, ref entityExtended);
'@
    if ($draft.Contains($oldExtendIndex)) {
        $draft = $draft.Replace($oldExtendIndex, $newExtendIndex)
        $draft = $draft.Replace('if (this.int_0[0] >= 0 & this.int_0[0] <= this.Entities.Count - 1)`n            this.Entities.RemoveAt(this.int_0[0]);', 'if (extendIndex >= 0 && extendIndex < this.Entities.Count)`n            this.Entities.RemoveAt(extendIndex);')
        "FIX editor extend bounds/current/non-finite length guards: $draftPath" | Tee-Object -Append $log
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
