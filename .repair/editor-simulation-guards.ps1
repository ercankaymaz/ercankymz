$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/editor-simulation-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buCadCamRes/buCadCamResVer5/Editor/clsEditorV2.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# Simulation can be stepped manually before Init()/Start was called. Sim_Tick
# dereferences timSim in its completion path, which can otherwise throw.
$oldTick = @'
  public void Sim_Tick(object sender, EventArgs e)
  {
    if (this.sortedEntitiesSimPoints.Count > 0 && this.sortedEntitiesSimIndex >= 0 && this.sortedEntitiesSimIndex <= this.sortedEntitiesSimPoints.Count - 1)
'@
$newTick = @'
  public void Sim_Tick(object sender, EventArgs e)
  {
    if (this.timSim == null)
      this.Init();
    if (this.sortedEntitiesSimPoints.Count > 0 && this.sortedEntitiesSimIndex >= 0 && this.sortedEntitiesSimIndex <= this.sortedEntitiesSimPoints.Count - 1)
'@
if ($text.Contains($oldTick)) {
    $text = $text.Replace($oldTick, $newTick)
    "FIX editor simulation timer initialization guard: $path" | Tee-Object -Append $log
}

# Start/stop can be called before Init as well. Both methods dereference timSim
# directly, including the no-path branch in Start, so protect both entry points.
$oldStart = @'
  public void cmdSimStart()
  {
    this.CreateSimPointsFromSortedEntities();
'@
$newStart = @'
  public void cmdSimStart()
  {
    if (this.timSim == null)
      this.Init();
    this.CreateSimPointsFromSortedEntities();
'@
if ($text.Contains($oldStart)) {
    $text = $text.Replace($oldStart, $newStart)
    "FIX editor simulation start timer initialization guard: $path" | Tee-Object -Append $log
}

$oldStop = @'
  public void cmdSimStop()
  {
    this.timSim.Enabled = false;
'@
$newStop = @'
  public void cmdSimStop()
  {
    if (this.timSim == null)
      this.Init();
    this.timSim.Enabled = false;
'@
if ($text.Contains($oldStop)) {
    $text = $text.Replace($oldStop, $newStop)
    "FIX editor simulation stop timer initialization guard: $path" | Tee-Object -Append $log
}

# The simulation marker mesh was always rendered at Z=0 while its text label
# used the CAM point Z. This makes 3D/5-axis visualization disagree with the
# actual Pnt6DSimMove position. Translate the generated tool marker to CAM Z.
$oldMesh = '        Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) outer, Plane.XY, true).ExtrudeAsMesh(5.0, 0.1, Mesh.natureType.RichSmooth);'
$newMesh = @'
        Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) outer, Plane.XY, true).ExtrudeAsMesh(5.0, 0.1, Mesh.natureType.RichSmooth);
        mesh.Translate(0.0, 0.0, entitiesSimPoint.Z);
'@
if ($text.Contains($oldMesh) -and -not $text.Contains('mesh.Translate(0.0, 0.0, entitiesSimPoint.Z);')) {
    $text = $text.Replace($oldMesh, $newMesh.TrimEnd("`r", "`n"))
    "FIX editor simulation tool marker follows CAM Z: $path" | Tee-Object -Append $log
}

# AddPoint may receive a hit Entity that is not an ICurve (point/text/mesh/etc.).
# The decompiled direct cast throws InvalidCastException and aborts the command.
$oldAddPointHit = @'
      if (start.Entity != null)
      {
        double t = 0.0;
        ((ICurve) start.Entity).ClosestPointTo(new Point3D(start.Position.X, start.Position.Y), out t);
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointAt(point, start.Entity, 0.5);
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointOn(point, start.Entity);
      }
'@
$newAddPointHit = @'
      if (start.Entity is ICurve hitCurve)
      {
        double t = 0.0;
        hitCurve.ClosestPointTo(new Point3D(start.Position.X, start.Position.Y), out t);
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointAt(point, start.Entity, 0.5);
        clsItem.frmEditorV2.viewport.CurrentSketch.AddConstraintPointOn(point, start.Entity);
      }
'@
if ($text.Contains($oldAddPointHit)) {
    $text = $text.Replace($oldAddPointHit, $newAddPointHit)
    "FIX editor AddPoint non-curve hit InvalidCastException guard: $path" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    $patched++
} else {
    "NO_MATCH_OR_ALREADY_FIXED editor simulation/runtime: $path" | Tee-Object -Append $log
}

"Patched editor simulation/runtime files: $patched" | Tee-Object -Append $log
