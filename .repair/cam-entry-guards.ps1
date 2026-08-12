$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/cam-entry-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buCore/buCore/buCamCalc.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# Surface-read grid storage was declared without initialization, while the wireframe
# calculation evaluates pntTeachGrids.Count. Keep the shared collection valid even
# before a teaching/import step has populated it.
$oldTeach = 'public static List<List<Pnt3D>> pntTeachGrids;'
$newTeach = 'public static List<List<Pnt3D>> pntTeachGrids = new List<List<Pnt3D>>();'
if ($text.Contains($oldTeach)) {
    $text = $text.Replace($oldTeach, $newTeach)
    "FIX initialize shared surface-read teaching grid collection: $path" | Tee-Object -Append $log
}

# Basic grinding contour dereferences Tool/camPars/simPars/calcCam immediately and
# later uses Entities.Count. Reject invalid service-call state at the public boundary.
$oldContour = @'
	public void CalculateGrindingContour(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, camParameters camPars, SimulationBase simPars, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
'@
$newContour = @'
	public void CalculateGrindingContour(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, camParameters camPars, SimulationBase simPars, ref camBase calcCam)
	{
		try
		{
			if (Entities == null || Tool == null || Tool.Geometry == null || camPars == null || simPars == null || calcCam == null)
				throw new InvalidOperationException("Grinding contour requires entities, tool geometry, CAM parameters, simulation parameters and output CAM state.");
			Pnt3D pnt3D = new Pnt3D();
'@
if ($text.Contains($oldContour)) {
    $text = $text.Replace($oldContour, $newContour)
    "FIX CalculateGrindingContour public input contract: $path" | Tee-Object -Append $log
}

# Saw grinding is kinematic and operation dependent; all of those inputs are used
# before any natural null-safe branch exists.
$oldSaw = @'
	public void CalculateGrindingContourSaw(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, camParameters camPars, GrindingOperations Operation, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
'@
$newSaw = @'
	public void CalculateGrindingContourSaw(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, camParameters camPars, GrindingOperations Operation, ref camBase calcCam)
	{
		try
		{
			if (Entities == null || Kinematic == null || Tool == null || Tool.Geometry == null || camPars == null || Operation == null || calcCam == null)
				throw new InvalidOperationException("Grinding saw contour requires entities, kinematics, tool geometry, CAM parameters, operation parameters and output CAM state.");
			Pnt3D pnt3D = new Pnt3D();
'@
if ($text.Contains($oldSaw)) {
    $text = $text.Replace($oldSaw, $newSaw)
    "FIX CalculateGrindingContourSaw public input contract: $path" | Tee-Object -Append $log
}

$oldHole = @'
	public void CalculateGrindingHole(Pnt3D RefPoint, KinematicBase Kinematic, ToolBase Tool, camParameters camPars, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
'@
$newHole = @'
	public void CalculateGrindingHole(Pnt3D RefPoint, KinematicBase Kinematic, ToolBase Tool, camParameters camPars, ref camBase calcCam)
	{
		try
		{
			if (RefPoint == null || Tool == null || Tool.Geometry == null || camPars == null || calcCam == null)
				throw new InvalidOperationException("Grinding hole requires a reference point, tool geometry, CAM parameters and output CAM state.");
			Pnt3D pnt3D = new Pnt3D();
'@
if ($text.Contains($oldHole)) {
    $text = $text.Replace($oldHole, $newHole)
    "FIX CalculateGrindingHole public input contract: $path" | Tee-Object -Append $log
}

# Any malformed inner entity group must be skipped before Count/index access. This
# exact shape appears in more than one recovered CAM loop and is safe to harden globally.
$oldEntityGroup = 'if (Entities[i].Count > 0)'
$newEntityGroup = 'if (Entities[i] != null && Entities[i].Count > 0)'
if ($text.Contains($oldEntityGroup)) {
    $text = $text.Replace($oldEntityGroup, $newEntityGroup)
    "FIX null inner CAM entity groups before Count/index access: $path" | Tee-Object -Append $log
}

# Wire-frame surface-read selection used eager bitwise operators. Besides evaluating
# every term unnecessarily, an uninitialized/null teaching-grid collection caused an
# NRE even when ApplySurfaceReadData was false. Make the condition short-circuit and
# null-safe, while requiring the operation model before dereferencing it.
$oldWireEntry = @'
	public void CalculateMarbleWireFrameWithSaw(List<List<eEntities>> Entities, List<List<eEntities>> ReCalculatedEntities, KinematicBase Kinematic, ToolBase Tool, marbleOperation Operation, marbleCamParameters CamMarblePars, camParameters camPar, EntitiesResolution Resolution, ref camBase calcCam)
	{
		try
		{
			List<List<eEntities>> CopiedEnt = new List<List<eEntities>>();
			if (!(Operation.ApplySurfaceReadData & (Operation.SurfaceReadDevideLength > 0.0) & (pntTeachGrids.Count > 0)))
'@
$newWireEntry = @'
	public void CalculateMarbleWireFrameWithSaw(List<List<eEntities>> Entities, List<List<eEntities>> ReCalculatedEntities, KinematicBase Kinematic, ToolBase Tool, marbleOperation Operation, marbleCamParameters CamMarblePars, camParameters camPar, EntitiesResolution Resolution, ref camBase calcCam)
	{
		try
		{
			if (Entities == null || Operation == null || Tool == null || Tool.Geometry == null || CamMarblePars == null || camPar == null || Resolution == null || calcCam == null)
				throw new InvalidOperationException("Marble wire-frame saw calculation requires entities, operation, tool geometry, CAM parameters, resolution and output CAM state.");
			List<List<eEntities>> CopiedEnt = new List<List<eEntities>>();
			if (!(Operation.ApplySurfaceReadData && Operation.SurfaceReadDevideLength > 0.0 && pntTeachGrids != null && pntTeachGrids.Count > 0))
'@
if ($text.Contains($oldWireEntry)) {
    $text = $text.Replace($oldWireEntry, $newWireEntry)
    "FIX CalculateMarbleWireFrameWithSaw null/eager surface-read input path: $path" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    $patched = 1
} else {
    "NO_MATCH_OR_ALREADY_FIXED $path" | Tee-Object -Append $log
}

"Patched CAM entry files: $patched" | Tee-Object -Append $log
