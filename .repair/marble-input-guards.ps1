$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/marble-input-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buCore/buCore/AppCalc/buMarbleCalc.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# MarbleItemHeightByDirection is a public calculation entry point and is used by
# several CAM flows. Do not assume UI validation has already happened.
$oldHeightEntry = @'
	public void MarbleItemHeightByDirection(CamCuttingDirectionType CutDir, HeightStepCalculationType StepType, double ForwardStep, double BackwardStep, double StartZ, double EndZ, Pnt3D StartPoint, Pnt3D EndPoint, ref List<Pnt3D> CalcPoints)
	{
		try
		{
			List<double> CalculatedHeight = new List<double>();
			CalcPoints.Clear();
'@
$newHeightEntry = @'
	public void MarbleItemHeightByDirection(CamCuttingDirectionType CutDir, HeightStepCalculationType StepType, double ForwardStep, double BackwardStep, double StartZ, double EndZ, Pnt3D StartPoint, Pnt3D EndPoint, ref List<Pnt3D> CalcPoints)
	{
		try
		{
			if (CalcPoints == null)
				CalcPoints = new List<Pnt3D>();
			else
				CalcPoints.Clear();
			if (StartPoint == null || EndPoint == null ||
				double.IsNaN(StartZ) || double.IsInfinity(StartZ) || double.IsNaN(EndZ) || double.IsInfinity(EndZ) ||
				double.IsNaN(ForwardStep) || double.IsInfinity(ForwardStep) || double.IsNaN(BackwardStep) || double.IsInfinity(BackwardStep))
				return;
			if ((CutDir == CamCuttingDirectionType.Forward && ForwardStep <= 1E-09) ||
				(CutDir == CamCuttingDirectionType.Backward && BackwardStep <= 1E-09) ||
				(CutDir == CamCuttingDirectionType.ForwardBackward && (ForwardStep <= 1E-09 || BackwardStep <= 1E-09)))
				return;
			List<double> CalculatedHeight = new List<double>();
'@
if ($text.Contains($oldHeightEntry)) {
    $text = $text.Replace($oldHeightEntry, $newHeightEntry)
    "FIX MarbleItemHeightByDirection null/non-finite/zero-step input guards: $path" | Tee-Object -Append $log
}

# ItemSlices is an output accumulator in existing call sites, so preserve any
# existing contents; only create it when a caller supplied null.
$oldCalcInit = @'
			CalcEntities = new List<List<eEntities>>();
			if (OperationPars.CamParameters.FirstEnterDistance > 0.0)
'@
$newCalcInit = @'
			CalcEntities = new List<List<eEntities>>();
			if (ItemSlices == null)
				ItemSlices = new List<Quad3D>();
			if (double.IsNaN(OperationPars.CamParameters.FirstEnterDistance) || double.IsInfinity(OperationPars.CamParameters.FirstEnterDistance) ||
				double.IsNaN(OperationPars.CamParameters.LastOutDistance) || double.IsInfinity(OperationPars.CamParameters.LastOutDistance) ||
				double.IsNaN(OperationPars.CamParameters.ForwardStepDownDistance) || double.IsInfinity(OperationPars.CamParameters.ForwardStepDownDistance) ||
				double.IsNaN(OperationPars.CamParameters.BackwardStepDownDistance) || double.IsInfinity(OperationPars.CamParameters.BackwardStepDownDistance))
				return false;
			for (int validateItemIndex = 0; validateItemIndex < Items.Count; ++validateItemIndex)
			{
				marbleCutItems cutItem = Items[validateItemIndex];
				if (cutItem == null || cutItem.Count <= 0 ||
					double.IsNaN(cutItem.Length) || double.IsInfinity(cutItem.Length) || cutItem.Length <= 1E-09 ||
					double.IsNaN(cutItem.StartAngle) || double.IsInfinity(cutItem.StartAngle) ||
					double.IsNaN(cutItem.EndAngle) || double.IsInfinity(cutItem.EndAngle))
					return false;
			}
			if (OperationPars.CamParameters.FirstEnterDistance > 0.0)
'@
if ($text.Contains($oldCalcInit)) {
    $text = $text.Replace($oldCalcInit, $newCalcInit)
    "FIX MarbleItemEntitiesCalculation item/output/parameter validation: $path" | Tee-Object -Append $log
}

# The decompiled code contains boolean bitwise operators in list-history tests.
# cam-math-guards already converts the known forward/perpendicular patterns, but
# assert the repaired short-circuit form here so a future decompile regression
# cannot reintroduce eager list[-1] evaluation.
$unsafeForward = 'if ((i > 0) | ((j > 0) & (list[list.Count - 1].Orientation.A != Items[i].StartAngle)))'
$safeForward = 'if ((i > 0) || ((j > 0) && (list[list.Count - 1].Orientation.A != Items[i].StartAngle)))'
if ($text.Contains($unsafeForward)) {
    $text = $text.Replace($unsafeForward, $safeForward)
    "FIX eager forward list-history evaluation: $path" | Tee-Object -Append $log
}
$unsafePerpendicular = 'if ((i > 0) | ((k > 0) & (list[list.Count - 1].Orientation.A != Items[i].StartAngle)))'
$safePerpendicular = 'if ((i > 0) || ((k > 0) && (list[list.Count - 1].Orientation.A != Items[i].StartAngle)))'
if ($text.Contains($unsafePerpendicular)) {
    $text = $text.Replace($unsafePerpendicular, $safePerpendicular)
    "FIX eager perpendicular list-history evaluation: $path" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    $patched = 1
} else {
    "NO_MATCH_OR_ALREADY_FIXED $path" | Tee-Object -Append $log
}

"Patched marble input files: $patched" | Tee-Object -Append $log
