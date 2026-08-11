$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/marble-runtime-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buCore/buCore/AppCalc/buMarbleCalc.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
} else {
    $text = [IO.File]::ReadAllText($path)
    $original = $text

    # Avoid evaluating BackwardStep / deltaZ before the branch that actually needs it.
    # For deltaZ == 0 the old decompiled code created +/-Infinity even though num3 was
    # unused in the first branch. Moving the calculation into the else branch preserves
    # all valid results and prevents non-finite intermediate CAM values.
    $oldHeight = @'
				double num2 = num - CalculatedHeight[k];
				double num3 = BackwardStep / num2;
				if (!(num2 >= ForwardStep + BackwardStep))
				{
					list.Add(CalculatedHeight[k]);
				}
				else
				{
					list.Add(num2 * num3 + CalculatedHeight[k]);
'@
    $newHeight = @'
				double num2 = num - CalculatedHeight[k];
				if (!(num2 >= ForwardStep + BackwardStep))
				{
					list.Add(CalculatedHeight[k]);
				}
				else
				{
					double num3 = BackwardStep / num2;
					list.Add(num2 * num3 + CalculatedHeight[k]);
'@
    if ($text.Contains($oldHeight)) {
        $text = $text.Replace($oldHeight, $newHeight)
        "FIX MarbleItemHeightByDirection deferred zero-delta division: $path" | Tee-Object -Append $log
    }

    # The calculation dereferences OperationPars/CamParameters and Items before any
    # validation. Invalid numeric inputs later flow directly into trigonometric and
    # step-down calculations. As this API already returns bool, reject invalid inputs
    # deterministically instead of throwing or creating NaN/Infinity geometry.
    $oldEntry = @'
	public bool MarbleItemEntitiesCalculation(Pnt3D StartPoint, Pnt3D EndPoint, double MaterialThickness, double ToolThickness, double PitchAngle, double TangentAngle, bool Perpendicular, marbleOperation OperationPars, List<marbleCutItems> Items, ref List<List<eEntities>> CalcEntities, ref List<Quad3D> ItemSlices)
	{
		try
		{
'@
    $newEntry = @'
	public bool MarbleItemEntitiesCalculation(Pnt3D StartPoint, Pnt3D EndPoint, double MaterialThickness, double ToolThickness, double PitchAngle, double TangentAngle, bool Perpendicular, marbleOperation OperationPars, List<marbleCutItems> Items, ref List<List<eEntities>> CalcEntities, ref List<Quad3D> ItemSlices)
	{
		try
		{
			if (StartPoint == null || EndPoint == null || OperationPars == null || OperationPars.CamParameters == null || Items == null || Items.Count == 0)
			{
				return false;
			}
			if (double.IsNaN(MaterialThickness) || double.IsInfinity(MaterialThickness) || MaterialThickness < 0.0 ||
				double.IsNaN(ToolThickness) || double.IsInfinity(ToolThickness) || ToolThickness < 0.0 ||
				double.IsNaN(PitchAngle) || double.IsInfinity(PitchAngle) ||
				double.IsNaN(TangentAngle) || double.IsInfinity(TangentAngle) ||
				double.IsNaN(OperationPars.TargetZ) || double.IsInfinity(OperationPars.TargetZ))
			{
				return false;
			}
'@
    if ($text.Contains($oldEntry)) {
        $text = $text.Replace($oldEntry, $newEntry)
        "FIX MarbleItemEntitiesCalculation null/non-finite input validation: $path" | Tee-Object -Append $log
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    }
}

# Surface-read preprocessing in CalculateMarbleWireFrameWithSaw assumes every
# entity group converts to at least one point, then indexes Points[Count-1] and
# Entities[i][0]. Degenerate/empty groups can violate both assumptions.
$camPath = 'Decompiled/buCore/buCore/buCamCalc.cs'
if (-not (Test-Path -LiteralPath $camPath)) {
    "MISS $camPath" | Tee-Object -Append $log
} else {
    $camText = [IO.File]::ReadAllText($camPath)
    $camOriginal = $camText

    $oldGroup = @'
				for (int i = 0; i <= Entities.Count - 1; i++)
				{
					List<eEntities> list = new List<eEntities>();
					List<Pnt3D> Points = new List<Pnt3D>();
'@
    $newGroup = @'
				for (int i = 0; i <= Entities.Count - 1; i++)
				{
					if (Entities[i] == null || Entities[i].Count == 0)
					{
						continue;
					}
					List<eEntities> list = new List<eEntities>();
					List<Pnt3D> Points = new List<Pnt3D>();
'@
    if ($camText.Contains($oldGroup)) {
        $camText = $camText.Replace($oldGroup, $newGroup)
        "FIX CalculateMarbleWireFrameWithSaw empty entity-group guard: $camPath" | Tee-Object -Append $log
    }

    $oldPoints = @'
					buAppCalc.cVector.EntitiesToPoint(Entities[i], entitiesResolution, ref Points);
					Points[Points.Count - 1] = new Pnt3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, 5.0);
'@
    $newPoints = @'
					buAppCalc.cVector.EntitiesToPoint(Entities[i], entitiesResolution, ref Points);
					if (Points == null || Points.Count == 0)
					{
						continue;
					}
					Points[Points.Count - 1] = new Pnt3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, 5.0);
'@
    if ($camText.Contains($oldPoints)) {
        $camText = $camText.Replace($oldPoints, $newPoints)
        "FIX CalculateMarbleWireFrameWithSaw empty point-conversion guard: $camPath" | Tee-Object -Append $log
    }

    if ($camText -ne $camOriginal) {
        [IO.File]::WriteAllText($camPath, $camText, [Text.UTF8Encoding]::new($false))
        $patched++
    }
}

"Patched marble runtime files: $patched" | Tee-Object -Append $log
