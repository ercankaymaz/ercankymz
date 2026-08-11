$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/five-axis-professional-guards.txt'
Remove-Item $log -ErrorAction Ignore

$sourcePath = 'Decompiled/buCadCamRes/buCadCamResVer5/Marble/clsMarble.cs'
$validatorPath = 'Decompiled/buCadCamRes/buCadCamResVer5/Marble/FiveAxisPathSafety.cs'
$toolFormPath = 'Decompiled/buCadCamRes/buCadCamResVer5/Forms/F_Tool.cs'
$filesPath = 'Decompiled/buCadCamRes/buCadCamResVer5/clsFiles.cs'
$settingsVerifierPath = '.repair/verify-cmd-settings.py'

if (-not (Test-Path -LiteralPath $sourcePath -PathType Leaf)) {
    "FAIL missing 5-axis marble source: $sourcePath" | Tee-Object $log
    exit 2
}
if ((Get-Item -LiteralPath $sourcePath).Length -eq 0) {
    "FAIL empty 5-axis marble source: $sourcePath" | Tee-Object $log
    exit 2
}
if (-not (Test-Path -LiteralPath $validatorPath -PathType Leaf)) {
    "FAIL missing final path validator: $validatorPath" | Tee-Object $log
    exit 2
}
if (-not (Test-Path -LiteralPath $toolFormPath -PathType Leaf)) {
    "FAIL missing XYZ/ABC limits UI: $toolFormPath" | Tee-Object $log
    exit 2
}
if (-not (Test-Path -LiteralPath $filesPath -PathType Leaf)) {
    "FAIL missing machine-profile startup loader: $filesPath" | Tee-Object $log
    exit 2
}
if (-not (Test-Path -LiteralPath $settingsVerifierPath -PathType Leaf)) {
    "FAIL missing deployed Settings verifier: $settingsVerifierPath" | Tee-Object $log
    exit 2
}

python $settingsVerifierPath . 2>&1 | Tee-Object -Append $log
if ($LASTEXITCODE -ne 0) {
    "FAIL deployed CMD Settings audit" | Tee-Object -Append $log
    exit 2
}

$text = [IO.File]::ReadAllText($sourcePath)
$original = $text
$methodPattern = '(?s)public int doEngrave5DCamCalc\s*\(.*?(?=\r?\n\s*public void doAddItemSawMilling\s*\()'
$methodMatch = [regex]::Match($text, $methodPattern)
if (-not $methodMatch.Success) {
    "FAIL doEngrave5DCamCalc method was not found" | Tee-Object $log
    exit 3
}
$method = $methodMatch.Value

function Replace-RequiredLiteral {
    param(
        [string]$Value,
        [string]$OldValue,
        [string]$NewValue,
        [string]$Label
    )

    if ($Value.Contains($NewValue)) {
        "OK already repaired: $Label" | Tee-Object -Append $log | Out-Null
        return $Value
    }
    if (-not $Value.Contains($OldValue)) {
        throw "Required 5-axis repair anchor not found: $Label"
    }
    "FIX $Label" | Tee-Object -Append $log | Out-Null
    return $Value.Replace($OldValue, $NewValue)
}

# Five-axis link moves must use the operation's configured clearance rather than zero.
$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamMeshParalel5AXPars.MachParam.LinkParams.AirMoveSafetyDistance = 0.0;' `
    'clsMW.varMWCamMeshParalel5AXPars.MachParam.LinkParams.AirMoveSafetyDistance = Math.Max(marbleCam.setCam.Distances.Safe, marbleCam.setCam.Distances.Rapid);' `
    '5AX parallel clearance distance'
$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamMeshContantZ5AXPars.MachParam.LinkParams.AirMoveSafetyDistance = 0.0;' `
    'clsMW.varMWCamMeshContantZ5AXPars.MachParam.LinkParams.AirMoveSafetyDistance = Math.Max(marbleCam.setCam.Distances.Safe, marbleCam.setCam.Distances.Rapid);' `
    '5AX constant-Z clearance distance'
$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamGeodesicPars.MachParam.LinkParams.AirMoveSafetyDistance = 0.0;' `
    'clsMW.varMWCamGeodesicPars.MachParam.LinkParams.AirMoveSafetyDistance = Math.Max(marbleCam.setCam.Distances.Safe, marbleCam.setCam.Distances.Rapid);' `
    '5AX geodesic clearance distance'

$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamMeshParalel5AXPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;' `
    'clsMW.varMWCamMeshParalel5AXPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = true;' `
    '5AX parallel clearance enforcement'
$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamMeshContantZ5AXPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;' `
    'clsMW.varMWCamMeshContantZ5AXPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = true;' `
    '5AX constant-Z clearance enforcement'
$method = Replace-RequiredLiteral $method `
    'clsMW.varMWCamGeodesicPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;' `
    'clsMW.varMWCamGeodesicPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = true;' `
    '5AX geodesic clearance enforcement'

# The recovered method selected CamTriMesh5AXType but read the 3-axis field later.
$method = Replace-RequiredLiteral $method `
    'MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts' `
    'MWCalcoptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ParallelCuts' `
    '5AX parallel strategy result selector'
$method = Replace-RequiredLiteral $method `
    'MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ' `
    'MWCalcoptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ConstantZ' `
    '5AX constant-Z strategy result selector'
$method = Replace-RequiredLiteral $method `
    'MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Geodesic' `
    'MWCalcoptions.CamTriMesh5AXType == CamTriangularMesh5AxType.Geodesic' `
    '5AX geodesic strategy result selector'

# Remove the decompiler-produced duplicate ModuleWorks error-dialog block.
$resultErrorPattern = '(?s)if\s*\(\(Result\s*==\s*null\s*\?\s*0\s*:\s*\(Result\.Errors\.Count\s*>\s*0\s*\?\s*1\s*:\s*0\)\)\s*!=\s*0\)\s*\{\s*F_ErrorList\s+fErrorList\s*=\s*new F_ErrorList\(\);\s*fErrorList\.Init\(Result\.Errors\);\s*int\s+num\d+\s*=\s*\(int\)\s*fErrorList\.ShowDialog\(\);\s*clsInit\.appCommand\.Reset\(\);\s*return\s+-2;\s*\}'
$resultErrorMatches = [regex]::Matches($method, $resultErrorPattern)
if ($resultErrorMatches.Count -gt 1) {
    for ($i = $resultErrorMatches.Count - 1; $i -ge 1; --$i) {
        $duplicate = $resultErrorMatches[$i]
        $method = $method.Remove($duplicate.Index, $duplicate.Length)
    }
    "FIX duplicate 5AX ModuleWorks error blocks: removed $($resultErrorMatches.Count - 1)" | Tee-Object -Append $log
} else {
    "OK single 5AX ModuleWorks error block" | Tee-Object -Append $log
}

# Replace the empty C-axis envelope check with an equivalent-angle resolver that
# preserves continuity and stays inside the recovered machine's +/-370 degree range.
$emptyCEnvelopePattern = 'if\s*\(point\.P9\.C\s*>\s*370\.0\s*\|\|\s*point\.P9\.C\s*<\s*-370\.0\)\s*;'
if ([regex]::IsMatch($method, $emptyCEnvelopePattern)) {
    $cEnvelopeReplacement = @'
if (point.P9.C > 370.0 || point.P9.C < -370.0)
          {
            double normalizedC = point.P9.C % 360.0;
            double bestC = normalizedC;
            double bestCDelta = Math.Abs(bestC - num7);
            for (int turn = -1; turn <= 1; ++turn)
            {
              double candidateC = normalizedC + turn * 360.0;
              if (candidateC < -370.0 || candidateC > 370.0)
                continue;
              double candidateDelta = Math.Abs(candidateC - num7);
              if (candidateDelta < bestCDelta)
              {
                bestC = candidateC;
                bestCDelta = candidateDelta;
              }
            }
            point.P9.C = bestC;
          }
'@
    $method = [regex]::Replace($method, $emptyCEnvelopePattern, $cEnvelopeReplacement, 1)
    "FIX empty C-axis envelope check" | Tee-Object -Append $log
} elseif ($method -notmatch 'double\s+normalizedC\s*=\s*point\.P9\.C\s*%\s*360\.0') {
    throw 'Required C-axis envelope repair anchor was not found.'
} else {
    "OK C-axis envelope resolver already present" | Tee-Object -Append $log
}

$text = $text.Remove($methodMatch.Index, $methodMatch.Length).Insert($methodMatch.Index, $method)

# Make the final path validator a mandatory gate immediately before postprocessing.
if ($text -notmatch 'FiveAxisPathSafety\.ValidateAndNormalize\(Job\.Cams\);') {
    $gcodePattern = '(?m)^(?<indent>\s*)strGCodes\s*=\s*"";\s*\r?\n(?<callindent>\s*)clsInit\.cGcodeCreate\.CreatGCode\(Job\.Cams,\s*Post,\s*ref\s+strGCodes\);'
    $gcodeMatch = [regex]::Match($text, $gcodePattern)
    if (-not $gcodeMatch.Success) {
        throw 'G-code final validation insertion point was not found.'
    }
    $replacement = $gcodeMatch.Groups['indent'].Value + 'strGCodes = "";' + [Environment]::NewLine +
        $gcodeMatch.Groups['callindent'].Value + 'FiveAxisPathSafety.ValidateAndNormalize(Job.Cams);' + [Environment]::NewLine +
        $gcodeMatch.Groups['callindent'].Value + 'clsInit.cGcodeCreate.CreatGCode(Job.Cams, Post, ref strGCodes);' + [Environment]::NewLine +
        $gcodeMatch.Groups['callindent'].Value + 'FiveAxisPathSafety.ValidateGCode(strGCodes);'
    $text = $text.Remove($gcodeMatch.Index, $gcodeMatch.Length).Insert($gcodeMatch.Index, $replacement)
    "FIX mandatory final 5AX path validation gate" | Tee-Object -Append $log
} else {
    "OK final 5AX path validation gate already present" | Tee-Object -Append $log
    if ($text -notmatch 'FiveAxisPathSafety\.ValidateGCode\(strGCodes\);') {
        $postPattern = '(?m)^(?<indent>\s*)clsInit\.cGcodeCreate\.CreatGCode\(Job\.Cams,\s*Post,\s*ref\s+strGCodes\);'
        $postMatch = [regex]::Match($text, $postPattern)
        if (-not $postMatch.Success) {
            throw 'G-code text validation insertion point was not found.'
        }
        $postReplacement = $postMatch.Value + [Environment]::NewLine +
            $postMatch.Groups['indent'].Value + 'FiveAxisPathSafety.ValidateGCode(strGCodes);'
        $text = $text.Remove($postMatch.Index, $postMatch.Length).Insert($postMatch.Index, $postReplacement)
        "FIX final postprocessor text validation gate" | Tee-Object -Append $log
    }
}

# Commit only validated G-code to the job cache. Any exception must clear both
# the caller-visible ref string and the cached job state.
if ($text -notmatch 'Job\.GCode\s*=\s*strGCodes;') {
    $validatedOutputPattern = '(?m)^(?<indent>\s*)FiveAxisPathSafety\.ValidateGCode\(strGCodes\);'
    $validatedOutputMatch = [regex]::Match($text, $validatedOutputPattern)
    if (-not $validatedOutputMatch.Success) {
        throw 'Validated G-code cache insertion point was not found.'
    }
    $validatedOutputReplacement = $validatedOutputMatch.Value + [Environment]::NewLine +
        $validatedOutputMatch.Groups['indent'].Value + 'Job.GCode = strGCodes;' + [Environment]::NewLine +
        $validatedOutputMatch.Groups['indent'].Value + 'Job.isGCodeCreated = true;'
    $text = $text.Remove($validatedOutputMatch.Index, $validatedOutputMatch.Length).Insert($validatedOutputMatch.Index, $validatedOutputReplacement)
    "FIX validated G-code cache commit" | Tee-Object -Append $log
}

$createGCodeMethodPattern = '(?s)public void doCreateGCode\s*\(.*?(?=\r?\n\s*public void SetMillingCamParameter\s*\()'
$createGCodeMethodMatch = [regex]::Match($text, $createGCodeMethodPattern)
if (-not $createGCodeMethodMatch.Success) {
    throw 'doCreateGCode method was not found for fail-closed output handling.'
}
$createGCodeMethod = $createGCodeMethodMatch.Value
if ($createGCodeMethod -notmatch 'strGCodes\s*=\s*"";\s*\r?\n\s*if\s*\(Job\s*!=\s*null\)') {
    $createCatchPattern = '(?m)^(?<indent>\s*)catch\s*\(Exception ex\)\s*\r?\n\s*\{\s*\r?\n'
    $createCatchMatch = [regex]::Match($createGCodeMethod, $createCatchPattern)
    if (-not $createCatchMatch.Success) {
        throw 'doCreateGCode catch block was not found.'
    }
    $catchIndent = $createCatchMatch.Groups['indent'].Value
    $bodyIndent = $catchIndent + '  '
    $createCatchReplacement = $createCatchMatch.Value +
        $bodyIndent + 'strGCodes = "";' + [Environment]::NewLine +
        $bodyIndent + 'if (Job != null)' + [Environment]::NewLine +
        $bodyIndent + '{' + [Environment]::NewLine +
        $bodyIndent + '  Job.GCode = "";' + [Environment]::NewLine +
        $bodyIndent + '  Job.isGCodeCreated = false;' + [Environment]::NewLine +
        $bodyIndent + '}' + [Environment]::NewLine
    $createGCodeMethod = $createGCodeMethod.Remove($createCatchMatch.Index, $createCatchMatch.Length).Insert($createCatchMatch.Index, $createCatchReplacement)
    $text = $text.Remove($createGCodeMethodMatch.Index, $createGCodeMethodMatch.Length).Insert($createGCodeMethodMatch.Index, $createGCodeMethod)
    "FIX failed G-code output invalidation" | Tee-Object -Append $log
}

if ($text -notmatch 'string\.IsNullOrWhiteSpace\(this\.activeJob\.GCode\)') {
    $showCachePattern = '(?m)^(?<indent>\s*)if\s*\(!this\.activeJob\.isGCodeCreated\)\s*\r?\n\s*this\.doCreateGCode\(this\.activeJob,\s*ref\s+strGCodes\);'
    $showCacheMatch = [regex]::Match($text, $showCachePattern)
    if (-not $showCacheMatch.Success) {
        throw 'cmdShowGcode cache flow insertion point was not found.'
    }
    $showIndent = $showCacheMatch.Groups['indent'].Value
    $showCacheReplacement = $showIndent + 'if (!this.activeJob.isGCodeCreated || string.IsNullOrWhiteSpace(this.activeJob.GCode))' + [Environment]::NewLine +
        $showIndent + '  this.doCreateGCode(this.activeJob, ref strGCodes);' + [Environment]::NewLine +
        $showIndent + 'else' + [Environment]::NewLine +
        $showIndent + '  strGCodes = this.activeJob.GCode;' + [Environment]::NewLine +
        $showIndent + 'if (string.IsNullOrWhiteSpace(strGCodes))' + [Environment]::NewLine +
        $showIndent + '  return;'
    $text = $text.Remove($showCacheMatch.Index, $showCacheMatch.Length).Insert($showCacheMatch.Index, $showCacheReplacement)
    "FIX G-code viewer cache flow" | Tee-Object -Append $log
}

# Bind every cached program to the exact verified XYZ/ABC profile revision.
# This also forces programs loaded from older job files to be regenerated.
if ($text -notmatch 'private long gCodeSafetyRevision\s*=\s*-1L;') {
    $cacheFieldAnchor = '  public MarbleJob tempJob = (MarbleJob) null;'
    if (-not $text.Contains($cacheFieldAnchor)) {
        throw 'Marble G-code safety cache field insertion point was not found.'
    }
    $cacheFields = $cacheFieldAnchor + [Environment]::NewLine +
        '  private MarbleJob gCodeSafetyJob = (MarbleJob) null;' + [Environment]::NewLine +
        '  private long gCodeSafetyRevision = -1L;'
    $text = $text.Replace($cacheFieldAnchor, $cacheFields)
    "FIX profile-revision-bound G-code cache fields" | Tee-Object -Append $log
}
if ($text -notmatch 'private long simulationSafetyRevision\s*=\s*-1L;') {
    $simulationFieldAnchor = '  private long gCodeSafetyRevision = -1L;'
    if (-not $text.Contains($simulationFieldAnchor)) {
        throw 'Simulation safety cache field insertion point was not found.'
    }
    $simulationFields = $simulationFieldAnchor + [Environment]::NewLine +
        '  private MarbleJob simulationSafetyJob = (MarbleJob) null;' + [Environment]::NewLine +
        '  private long simulationSafetyRevision = -1L;'
    $text = $text.Replace($simulationFieldAnchor, $simulationFields)
    "FIX profile-revision-bound simulation cache fields" | Tee-Object -Append $log
}

$showMethodPattern = '(?s)  public void cmdShowGcode\s*\(\)\s*\{.*?(?=\r?\n  public void cmdCreateGCode\s*\(\))'
$showMethodMatch = [regex]::Match($text, $showMethodPattern)
if (-not $showMethodMatch.Success) {
    throw 'cmdShowGcode method was not found for profile-revision cache binding.'
}
$canonicalShowMethod = @'
  public void cmdShowGcode()
  {
    if (this.activeJob == null)
      return;
    string strGCodes = "";
    if (!this.activeJob.CamCalculated)
      this.doCamCalculateMarbleJob(ref this.activeJob);
    if (!this.activeJob.CamCalculated)
      return;

    long currentSafetyRevision = FiveAxisPathSafety.ConfigurationRevision;
    bool cacheMatchesSafetyProfile = object.ReferenceEquals(this.gCodeSafetyJob, this.activeJob) &&
                                     this.gCodeSafetyRevision == currentSafetyRevision;
    if (!cacheMatchesSafetyProfile)
    {
      this.activeJob.GCode = "";
      this.activeJob.isGCodeCreated = false;
    }

    if (!this.activeJob.isGCodeCreated || string.IsNullOrWhiteSpace(this.activeJob.GCode))
      this.doCreateGCode(this.activeJob, ref strGCodes);
    else
    {
      try
      {
        FiveAxisPathSafety.ValidateGCode(this.activeJob.GCode);
        if (currentSafetyRevision != FiveAxisPathSafety.ConfigurationRevision)
          throw new InvalidOperationException("XYZ/ABC machine limits changed while cached G-code was being checked.");
        strGCodes = this.activeJob.GCode;
      }
      catch (Exception ex)
      {
        buLogVer5.addToLog(this.string_0, nameof (cmdShowGcode), "Cached G-code rejected", ex.Message, 0.0, 0.0, true);
        this.activeJob.GCode = "";
        this.activeJob.isGCodeCreated = false;
        this.gCodeSafetyJob = (MarbleJob) null;
        this.gCodeSafetyRevision = -1L;
        this.doCreateGCode(this.activeJob, ref strGCodes);
      }
    }
    if (string.IsNullOrWhiteSpace(strGCodes))
      return;
    F_Notepad fNotepad = new F_Notepad();
    fNotepad.Init(strGCodes);
    fNotepad.Show();
    if (clsItem.FrmProgress == null)
      return;
    clsItem.FrmProgress.Visible = false;
  }
'@
if ($showMethodMatch.Value -notmatch 'cacheMatchesSafetyProfile' -or
    $showMethodMatch.Value -notmatch 'Cached G-code rejected') {
    $text = $text.Remove($showMethodMatch.Index, $showMethodMatch.Length).Insert($showMethodMatch.Index, $canonicalShowMethod)
    "FIX cached G-code profile revision and revalidation flow" | Tee-Object -Append $log
}

$startSimulationPattern = '(?s)  public void cmdStartSimulation\s*\(\)\s*\{.*?(?=\r?\n  public void cmdStopSimulation\s*\(\))'
$startSimulationMatch = [regex]::Match($text, $startSimulationPattern)
if (-not $startSimulationMatch.Success) {
    throw 'cmdStartSimulation method was not found for profile-revision binding.'
}
$canonicalStartSimulation = @'
  public void cmdStartSimulation()
  {
    if (this.activeJob == null)
      return;
    try
    {
      if (!this.activeJob.CamCalculated)
        this.doCamCalculateMarbleJob(ref this.activeJob);
      if (!this.activeJob.CamCalculated)
        throw new InvalidOperationException("CAM calculation did not complete; simulation cannot start.");

      long currentSafetyRevision = FiveAxisPathSafety.ConfigurationRevision;
      bool simulationMatchesSafetyProfile = object.ReferenceEquals(this.simulationSafetyJob, this.activeJob) &&
                                            this.simulationSafetyRevision == currentSafetyRevision;
      if (!simulationMatchesSafetyProfile)
      {
        this.activeJob.isSimulationDone = false;
        this.SimIndex = -1;
        this.SimItemIndex = -1;
        this.SimToolIndex = -1;
      }
      if (!this.activeJob.isSimulationDone)
        this.doSimulationCalculate(ref this.activeJob);
      if (!object.ReferenceEquals(this.simulationSafetyJob, this.activeJob) ||
          this.simulationSafetyRevision != FiveAxisPathSafety.ConfigurationRevision)
        throw new InvalidOperationException("Simulation does not match the active XYZ/ABC machine limits.");
    }
    catch (Exception ex)
    {
      this.timSim.Enabled = false;
      if (clsItem.FrmProgress != null)
        clsItem.FrmProgress.Visible = false;
      buLogVer5.addToLog(this.string_0, nameof (cmdStartSimulation), "Simulation rejected", ex.Message, 0.0, 0.0, true);
      buString5.MessageBoxWarning("Simulation cannot start: " + ex.Message);
      return;
    }

    if (this.SimIndex == -1)
    {
      clsMarble.lastSimToolPurpose = ToolPurpose.None;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StopAnimation();
      this.DeleteSimulationEntities();
      this.DrawSimulationEntities(false, true, true, MarbleToolType.Saw);
      if (!ccVars.Pages[ccVars.PageIndex].Form.viewportcad.IsAnimationRunning)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartAnimation();
      this.SimToolIndex = 0;
      this.SimIndex = 0;
      this.SimItemIndex = 0;
      this.timSim.Enabled = true;
    }
    else
      this.timSim.Enabled = true;
  }
'@
if ($startSimulationMatch.Value -notmatch 'simulationMatchesSafetyProfile' -or
    $startSimulationMatch.Value -notmatch 'Simulation rejected') {
    $text = $text.Remove($startSimulationMatch.Index, $startSimulationMatch.Length).Insert($startSimulationMatch.Index, $canonicalStartSimulation)
    "FIX simulation profile revision and fail-closed start flow" | Tee-Object -Append $log
}

$simulationCalculatePattern = '(?s)  public void doSimulationCalculate\s*\(ref MarbleJob Job\)\s*\{.*?(?=\r?\n  public void doCreateGCode\s*\()'
$simulationCalculateMatch = [regex]::Match($text, $simulationCalculatePattern)
if (-not $simulationCalculateMatch.Success) {
    throw 'doSimulationCalculate method was not found for profile validation.'
}
$simulationCalculateMethod = $simulationCalculateMatch.Value
if ($simulationCalculateMethod -notmatch 'Cannot calculate simulation for a null marble job') {
    $simulationStartAnchor = @'
  public void doSimulationCalculate(ref MarbleJob Job)
  {
'@
    if (-not $simulationCalculateMethod.Contains($simulationStartAnchor)) {
        throw 'doSimulationCalculate validation insertion point was not found.'
    }
    $simulationStartReplacement = $simulationStartAnchor + [Environment]::NewLine +
        '    if (Job == null)' + [Environment]::NewLine +
        '      throw new InvalidOperationException("Cannot calculate simulation for a null marble job.");' + [Environment]::NewLine +
        '    if (Job.Cams == null || Job.Cams.Count == 0)' + [Environment]::NewLine +
        '      throw new InvalidOperationException("Cannot calculate simulation without CAM paths.");' + [Environment]::NewLine +
        '    long safetyRevision = FiveAxisPathSafety.ConfigurationRevision;' + [Environment]::NewLine +
        '    FiveAxisPathSafety.ValidateAndNormalize(Job.Cams);' + [Environment]::NewLine +
        '    if (safetyRevision != FiveAxisPathSafety.ConfigurationRevision)' + [Environment]::NewLine +
        '      throw new InvalidOperationException("XYZ/ABC machine limits changed during simulation validation.");' + [Environment]::NewLine +
        '    if (!object.ReferenceEquals(this.simulationSafetyJob, Job) || this.simulationSafetyRevision != safetyRevision)' + [Environment]::NewLine +
        '      Job.isSimulationDone = false;' + [Environment]::NewLine
    $simulationCalculateMethod = $simulationCalculateMethod.Replace($simulationStartAnchor, $simulationStartReplacement)
}
if ($simulationCalculateMethod -notmatch 'ReferenceEquals\(this\.simulationSafetyJob, Job\)') {
    $simulationRevisionAnchor = '      throw new InvalidOperationException("XYZ/ABC machine limits changed during simulation validation.");'
    if (-not $simulationCalculateMethod.Contains($simulationRevisionAnchor)) {
        throw 'doSimulationCalculate cache invalidation insertion point was not found.'
    }
    $simulationRevisionReplacement = $simulationRevisionAnchor + [Environment]::NewLine +
        '    if (!object.ReferenceEquals(this.simulationSafetyJob, Job) || this.simulationSafetyRevision != safetyRevision)' + [Environment]::NewLine +
        '      Job.isSimulationDone = false;'
    $simulationCalculateMethod = $simulationCalculateMethod.Replace($simulationRevisionAnchor, $simulationRevisionReplacement)
}
if ($simulationCalculateMethod -notmatch 'Simulation produced no verified motion points') {
    $simulationCompleteAnchor = '    Job.isSimulationDone = true;'
    if (-not $simulationCalculateMethod.Contains($simulationCompleteAnchor)) {
        throw 'doSimulationCalculate completion validation insertion point was not found.'
    }
    $simulationCompleteReplacement = @'
    bool hasSimulationMove = false;
    for (int camIndex = 0; camIndex < Job.Cams.Count; ++camIndex)
    {
      camTp simulationCam = Job.Cams[camIndex];
      if (simulationCam != null && simulationCam.Enable && simulationCam.SimilationPoint != null &&
          simulationCam.SimilationPoint.SimMove != null && simulationCam.SimilationPoint.SimMove.Count > 0)
      {
        hasSimulationMove = true;
        break;
      }
    }
    if (!hasSimulationMove)
      throw new InvalidOperationException("Simulation produced no verified motion points.");
    if (safetyRevision != FiveAxisPathSafety.ConfigurationRevision)
      throw new InvalidOperationException("XYZ/ABC machine limits changed during simulation calculation.");
    Job.isSimulationDone = true;
    this.simulationSafetyJob = Job;
    this.simulationSafetyRevision = safetyRevision;
'@
    $simulationCalculateMethod = $simulationCalculateMethod.Replace($simulationCompleteAnchor, $simulationCompleteReplacement)
}
if ($simulationCalculateMethod -ne $simulationCalculateMatch.Value) {
    $text = $text.Remove($simulationCalculateMatch.Index, $simulationCalculateMatch.Length).Insert($simulationCalculateMatch.Index, $simulationCalculateMethod)
    "FIX simulation path validation and verified-motion completion gate" | Tee-Object -Append $log
}

$revisionCreateMethodPattern = '(?s)  public void doCreateGCode\s*\(MarbleJob Job,\s*ref string strGCodes\)\s*\{.*?(?=\r?\n  public void SetMillingCamParameter\s*\()'
$revisionCreateMethodMatch = [regex]::Match($text, $revisionCreateMethodPattern)
if (-not $revisionCreateMethodMatch.Success) {
    throw 'doCreateGCode method was not found for profile-revision cache binding.'
}
$canonicalCreateMethod = @'
  public void doCreateGCode(MarbleJob Job, ref string strGCodes)
  {
    string str = nameof (doCreateGCode);
    try
    {
      if (Job == null)
        throw new InvalidOperationException("Cannot generate G-code for a null marble job.");
      long safetyRevision = FiveAxisPathSafety.ConfigurationRevision;
      PostProcessor Post = new PostProcessor(ccVars.PostActive);
      if (buMarbleCalc.varOperation.settingMarbleCam.MoveZCAAxesToSafeDistance)
      {
        Post.EndLines.Insert(0, (object) "M50");
        Post.EndLines.Insert(1, (object) "G0 A0");
        Post.EndLines.Insert(2, (object) ("G0 Z" + buMarbleCalc.varOperation.settingMarbleCam.JobFinishZPostion.ToString()));
        Post.EndLines.Insert(3, (object) "G0 C0");
      }
      strGCodes = "";
      FiveAxisPathSafety.ValidateAndNormalize(Job.Cams);
      if (safetyRevision != FiveAxisPathSafety.ConfigurationRevision)
        throw new InvalidOperationException("XYZ/ABC machine limits changed during CAM validation. Recalculate the job.");
      clsInit.cGcodeCreate.CreatGCode(Job.Cams, Post, ref strGCodes);
      FiveAxisPathSafety.ValidateGCode(strGCodes);
      if (safetyRevision != FiveAxisPathSafety.ConfigurationRevision)
        throw new InvalidOperationException("XYZ/ABC machine limits changed during G-code validation. Regenerate the program.");
      Job.GCode = strGCodes;
      Job.isGCodeCreated = true;
      this.gCodeSafetyJob = Job;
      this.gCodeSafetyRevision = safetyRevision;
    }
    catch (Exception ex)
    {
      strGCodes = "";
      if (Job != null)
      {
        Job.GCode = "";
        Job.isGCodeCreated = false;
      }
      if (object.ReferenceEquals(this.gCodeSafetyJob, Job))
      {
        this.gCodeSafetyJob = (MarbleJob) null;
        this.gCodeSafetyRevision = -1L;
      }
      buLogVer5.addToLog(this.string_0, str, "Error", ex.Message, 0.0, 0.0, true);
      buException.throwException(ex, str, true, "");
    }
  }
'@
if ($revisionCreateMethodMatch.Value -notmatch 'safetyRevision\s*=\s*FiveAxisPathSafety\.ConfigurationRevision' -or
    $revisionCreateMethodMatch.Value -notmatch '"Error", ex\.Message') {
    $text = $text.Remove($revisionCreateMethodMatch.Index, $revisionCreateMethodMatch.Length).Insert($revisionCreateMethodMatch.Index, $canonicalCreateMethod)
    "FIX profile-stable CAM and G-code validation transaction" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($sourcePath, $text, [Text.UTF8Encoding]::new($false))
}

# Fail the build if any repaired critical signature regresses.
$finalMethod = [regex]::Match($text, $methodPattern).Value
$regressions = New-Object System.Collections.Generic.List[string]
$validatorText = [IO.File]::ReadAllText($validatorPath)
$toolFormText = [IO.File]::ReadAllText($toolFormPath)
$filesText = [IO.File]::ReadAllText($filesPath)
if ($finalMethod -match '5AXPars\.MachParam\.LinkParams\.AirMoveSafetyDistance\s*=\s*0\.0') { $regressions.Add('zero 5AX clearance') }
if ($finalMethod -match '5AXPars\.MachParam\..*UseAirMoveSafetyDistanceFlg\s*=\s*false') { $regressions.Add('disabled 5AX clearance') }
if ($finalMethod -match 'CamTriMeshType\s*==\s*CamTriangularMeshType\.(ParallelCuts|ConstantZ|Geodesic)') { $regressions.Add('3-axis enum used in 5-axis method') }
if ($finalMethod -match $emptyCEnvelopePattern) { $regressions.Add('empty C-axis envelope check') }
if ($text -notmatch 'FiveAxisPathSafety\.ValidateAndNormalize\(Job\.Cams\);') { $regressions.Add('missing final path gate') }
if ($text -notmatch 'FiveAxisPathSafety\.ValidateGCode\(strGCodes\);') { $regressions.Add('missing postprocessor text gate') }
if ($text -notmatch 'Job\.GCode\s*=\s*strGCodes;') { $regressions.Add('validated G-code is not committed to the job') }
if ($text -notmatch 'Job\.isGCodeCreated\s*=\s*true;') { $regressions.Add('validated G-code state is not committed') }
if ($text -notmatch 'strGCodes\s*=\s*"";\s*\r?\n\s*if\s*\(Job\s*!=\s*null\)') { $regressions.Add('failed G-code output is not cleared') }
if ($validatorText -notmatch 'HasConfiguredMachineEnvelope') { $regressions.Add('machine envelope is not fail-closed') }
if ($validatorText -notmatch 'ProfileSync') { $regressions.Add('active machine profile is not thread-safe') }
if ($validatorText -notmatch 'Cannot validate incremental') { $regressions.Add('unknown incremental axis motion is not fail-closed') }
if ($validatorText -notmatch 'ConfigurationRevision') { $regressions.Add('machine profile changes do not invalidate cached G-code') }
if ($validatorText -notmatch 'blockUnitScale\s*=\s*25\.4') { $regressions.Add('G20 inch coordinates are not normalized to machine units') }
if ($validatorText -notmatch "axis == 'X' \|\| axis == 'Y' \|\| axis == 'Z'") { $regressions.Add('G20 incorrectly scales rotary axes') }
if ($validatorText -notmatch 'G90 and G91 conflict') { $regressions.Add('conflicting distance modes are not rejected') }
if ($validatorText -notmatch 'Unterminated G-code comment') { $regressions.Add('malformed G-code comments are not rejected') }
if ($validatorText -notmatch 'ClearConfiguration') { $regressions.Add('invalid machine profile cannot fail closed') }
if ($validatorText -notmatch 'profile\.XMin\s*>=\s*profile\.XMax') { $regressions.Add('zero-travel XYZ machine profile is accepted') }
if ($validatorText -notmatch 'totalParsedAxisWordCount\s*==\s*0') { $regressions.Add('motionless G-code is accepted as a production program') }
if ($validatorText -notmatch '65536L') { $regressions.Add('machine profile input has no size bound') }
if ($validatorText -notmatch 'GCodeAxisMarkerPattern') { $regressions.Add('malformed or symbolic axis words are not rejected') }
if ($validatorText -notmatch 'GCodeScalarMarkerPattern') { $regressions.Add('malformed or symbolic feed/spindle words are not rejected') }
if ($validatorText -notmatch 'non-positive feed') { $regressions.Add('postprocessor feed is not validated') }
if ($validatorText -notmatch 'negative spindle speed') { $regressions.Add('postprocessor spindle speed is not validated') }
if ($validatorText -notmatch 'Duplicate machine-profile key') { $regressions.Add('duplicate machine profile keys are not rejected') }
if ($validatorText -notmatch 'CreateEffectiveProfile') { $regressions.Add('per-tool XYZ/ABC envelope is not enforced') }
if ($validatorText -notmatch 'CAM entry is null') { $regressions.Add('null CAM entries are silently skipped') }
if ($validatorText -notmatch 'CAM segment is null') { $regressions.Add('null CAM segments are silently skipped') }
if ($validatorText -notmatch 'CAM contains motion but has no verified tool') { $regressions.Add('CAM motion can bypass verified tool limits') }
if ($validatorText -notmatch 'MaxGCodeCharacters') { $regressions.Add('G-code input has no total size bound') }
if ($validatorText -notmatch 'MaxGCodeLineCharacters') { $regressions.Add('G-code block length is unbounded') }
if ($validatorText -notmatch 'GetUnsupportedGCodeReason') { $regressions.Add('unsafe controller-dependent G-codes are not rejected') }
if ($validatorText -notmatch 'arc extrema are not proven') { $regressions.Add('endpoint-only validation accepts unproven arcs') }
if ($validatorText -notmatch 'GCodeGMarkerPattern') { $regressions.Add('symbolic or malformed G words can bypass validation') }
if ($validatorText -notmatch 'GCodeUnsupportedAxisMarkerPattern') { $regressions.Add('unconfigured U/V/W axes can bypass the XYZ/ABC envelope') }
if ($validatorText -notmatch 'duplicate \{0\}-axis words') { $regressions.Add('ambiguous duplicate axis words are accepted') }
if ($validatorText -notmatch 'tool envelope contains a non-finite value') { $regressions.Add('infinite per-tool envelopes are accepted') }
if ($validatorText -notmatch 'CurrentVersion\s*=\s*"2"') { $regressions.Add('machine profile format is not integrity-versioned') }
if ($validatorText -notmatch 'ComputeSha256') { $regressions.Add('machine profile has no checksum verification') }
if ($validatorText -notmatch 'ValidateGCodeAxisRange') { $regressions.Add('G-code XYZ/ABC envelope is not enforced') }
if ($validatorText -notmatch 'class\s+FiveAxisSafetyProfileStore') { $regressions.Add('machine envelope persistence is missing') }
if ($validatorText -notmatch 'TryLoadFromSettings') { $regressions.Add('active Settings trees are not audited recursively') }
if ($validatorText -notmatch 'ReadMachineProfile') { $regressions.Add('Machine.prm soft limits are ignored') }
if ($validatorText -notmatch 'ReadPlcProfile') { $regressions.Add('PLCSettings.par axis limits are ignored') }
if ($validatorText -notmatch 'IntersectProfiles') { $regressions.Add('application and PLC limits are not intersected fail-closed') }
if ($validatorText -notmatch 'setDataLimitNegative') { $regressions.Add('controller data limits are ignored') }
if ($validatorText -notmatch 'ApplyProgramCamLimits') { $regressions.Add('Program.prm CAM limits are ignored') }
if ($validatorText -notmatch 'IsInactiveSettingsDirectory') { $regressions.Add('Old/Backup/Temp settings can become active') }
if ($validatorText -notmatch 'ValidateKinematicAndPost') { $regressions.Add('kinematic and post axis mappings are not cross-checked') }
if ($validatorText -notmatch 'ValidateKinematicGeometry') { $regressions.Add('kinematic pivot/base vectors are not validated') }
if ($validatorText -notmatch 'ValidateMarbleSafetySettings') { $regressions.Add('Marble machine-limit and RTCP settings are ignored') }
if ($validatorText -notmatch 'CmdG51DisableScalingPattern') { $regressions.Add('exact CMD G51 D0 dialect block is not recognized') }
if ($validatorText -notmatch 'CmdG20JumpPattern') { $regressions.Add('CMD G20 L/K jump is misread as inch mode') }
if ($validatorText -notmatch 'GCodeDMarkerPattern') { $regressions.Add('unexpected D words can bypass controller dialect validation') }
if ($toolFormText -notmatch 'TryValidateAxisLimits') { $regressions.Add('XYZ/ABC UI min-max validation is missing') }
if ($toolFormText -notmatch 'SaveMachineLimitsClick') { $regressions.Add('XYZ/ABC machine-profile save UI is missing') }
if ($toolFormText -notmatch 'LoadMachineLimitsClick') { $regressions.Add('XYZ/ABC machine-profile load UI is missing') }
if ($toolFormText -notmatch 'SetAxisLimitValue') { $regressions.Add('safe legacy axis-limit loading is missing') }
if ($toolFormText -notmatch 'AxisLimitControlValidated') { $regressions.Add('legacy axis-limit review flow is missing') }
if ($toolFormText -notmatch 'Saved machine limits cannot be activated') { $regressions.Add('UI can activate a profile it cannot represent') }
if ($toolFormText -notmatch 'AppSecurity\.PasswordLevel\s*<\s*2') { $regressions.Add('machine limits can be changed without administrator authorization') }
if ($toolFormText -notmatch 'FiveAxisSafety", "SaveFailed"') { $regressions.Add('machine profile UI failures are not logged') }
if ($toolFormText -notmatch 'maxCuttingTiltDeltaControl') { $regressions.Add('cutting tilt delta is not configurable in the Limits UI') }
if ($toolFormText -notmatch 'Maximum cutting tilt delta must be greater than 0') { $regressions.Add('cutting tilt delta UI validation is missing') }
if ($filesText -notmatch 'FiveAxisSafetyProfileStore\.TryLoadFromSettings') { $regressions.Add('audited Settings tree is not loaded at startup') }
if ($filesText -notmatch 'FiveAxisPathSafety\.ClearConfiguration') { $regressions.Add('invalid startup profile does not disable production G-code') }
if ($filesText -notmatch 'ApplyMachineScopedCadCamSettings') { $regressions.Add('machine Settings post and kinematic are not made active') }
if ($filesText -notmatch 'Kinematic5Axis\.bukinematic') { $regressions.Add('active machine kinematic file is not loaded') }
if ($filesText -notmatch 'postMachine\.bupost') { $regressions.Add('active machine postprocessor file is not loaded') }
if ($filesText -notmatch 'AppPath\.MachineSettingsCam.*MachineConfig\.prm') { $regressions.Add('machine-scoped MachineConfig.prm is ignored') }
if ($text -notmatch 'private long gCodeSafetyRevision\s*=\s*-1L;') { $regressions.Add('G-code cache has no machine-profile revision') }
if ($text -notmatch 'cacheMatchesSafetyProfile') { $regressions.Add('cached G-code is not invalidated after profile change') }
if ($text -notmatch 'Cached G-code rejected') { $regressions.Add('rejected cached G-code has no diagnostic record') }
if ($text -notmatch 'machine limits changed during G-code validation') { $regressions.Add('profile changes during G-code creation are not fail-closed') }
if ($text -notmatch 'private long simulationSafetyRevision\s*=\s*-1L;') { $regressions.Add('simulation cache has no machine-profile revision') }
if ($text -notmatch 'simulationMatchesSafetyProfile') { $regressions.Add('cached simulation is not invalidated after profile change') }
if ($text -notmatch 'Simulation produced no verified motion points') { $regressions.Add('empty simulation is marked complete') }
if ($text -notmatch 'Simulation rejected') { $regressions.Add('simulation safety rejection is not logged') }

"5-axis regression count: $($regressions.Count)" | Tee-Object -Append $log
$regressions | ForEach-Object { "FAIL $_" | Tee-Object -Append $log }
if ($regressions.Count -gt 0) { exit 4 }

"PASS professional 5-axis source guards" | Tee-Object -Append $log
