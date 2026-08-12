$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/five-axis-gcode-guards.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buCadCamRes/buCadCamResVer5/Marble/FiveAxisPathSafety.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "FAIL missing 5-axis G-code validator: $path" | Tee-Object $log
    exit 2
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# The controller-independent validator cannot safely prove programmed XYZ when
# work/machine coordinate selection or implicit canned-cycle motion is active.
# Decimal variants (G54.1, G43.1, G68.2, etc.) must not slip through exact-value
# checks either, so reject the complete controller-dependent ranges fail-closed.
$pattern = '(?s)  private static string GetUnsupportedGCodeReason\(double code, bool cmdG51DisableScaling\)\s*\{.*?\n  \}'
$replacement = @'
  private static string GetUnsupportedGCodeReason(double code, bool cmdG51DisableScaling)
  {
    if (code >= 2.0 && code < 4.0)
      return "arc extrema are not proven by endpoint-only validation";
    if (code >= 5.0 && code < 6.0)
      return "spline/NURBS extrema are not proven by endpoint-only validation";
    if (code >= 10.0 && code < 11.0)
      return "programmable coordinate/tool-data mutation requires controller-specific proof";
    if (code >= 28.0 && code < 29.0 || code >= 30.0 && code < 31.0)
      return "the controller reference-return endpoint is not present in the program";
    if (code >= 41.0 && code < 43.0)
      return "cutter compensation can move the tool outside the programmed path";
    if (code >= 43.0 && code < 45.0)
      return "tool-length compensation requires a verified controller tool table and kinematic model";
    if (code == 51.0 && !cmdG51DisableScaling)
      return "only the exact controller-approved 'G51 D0' scaling-disable block is supported";
    if (code >= 52.0 && code < 60.0)
      return "machine/work coordinate selection or local offset mutation is not modeled by this validator";
    if (code >= 68.0 && code < 69.0 || code >= 92.0 && code < 93.0)
      return "coordinate transformation or offset mutation requires controller-specific proof";
    if (code >= 73.0 && code < 77.0 || code >= 81.0 && code < 90.0)
      return "canned-cycle or implicit retract motion is not expanded into explicit validated points";
    return null;
  }
'@

$match = [regex]::Match($text, $pattern)
if (-not $match.Success) {
    throw 'FiveAxisPathSafety.GetUnsupportedGCodeReason was not found.'
}
if ($match.Value -notmatch 'machine/work coordinate selection' -or $match.Value -notmatch 'canned-cycle') {
    $text = $text.Remove($match.Index, $match.Length).Insert($match.Index, $replacement.TrimEnd("`r", "`n"))
    "FIX reject unmodeled work offsets, compensation variants and canned cycles: $path" | Tee-Object -Append $log
} else {
    "OK hardened controller-dependent G-code rejection already present" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
}

$verified = [IO.File]::ReadAllText($path)
foreach ($required in @(
    'machine/work coordinate selection or local offset mutation is not modeled',
    'canned-cycle or implicit retract motion is not expanded',
    'spline/NURBS extrema are not proven',
    'code >= 52.0 && code < 60.0',
    'code >= 81.0 && code < 90.0')) {
    if (-not $verified.Contains($required)) {
        throw "5-axis G-code safety regression: missing '$required'"
    }
}

"Five-axis G-code guard audit OK" | Tee-Object -Append $log
