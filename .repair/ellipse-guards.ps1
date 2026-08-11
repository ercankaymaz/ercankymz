$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/ellipse-guards.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buCore/buCore/buVector.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text
$marker = '// REPAIR: ellipse numeric input guard'

if ($text.Contains($marker)) {
    "OK ellipse guard already present: $path" | Tee-Object -Append $log
    exit 0
}

# The previous validated IL repair for buCore.dll established the exact contract:
# EllipseWithCenter is void with seven parameters; parameter 0 is the center,
# parameters 1/2 are ellipse radii and parameter 3 is a numeric orientation value.
# Invalid values must return before EllipseArcWithCenter creates geometry.
$pattern = '(?ms)(?<head>\b(?:public|internal|private|protected)\s+(?:static\s+)?void\s+EllipseWithCenter\s*\((?<params>[^\)]*)\)\s*\{)'
$m = [regex]::Match($text, $pattern)
if (-not $m.Success) {
    "MISS EllipseWithCenter/7 source signature: $path" | Tee-Object -Append $log
    exit 0
}

$parts = @($m.Groups['params'].Value -split ',')
if ($parts.Count -ne 7) {
    "MISS EllipseWithCenter expected 7 parameters, found $($parts.Count): $path" | Tee-Object -Append $log
    exit 0
}

$names = @()
foreach ($part in $parts) {
    $pm = [regex]::Match($part.Trim(), '([A-Za-z_][A-Za-z0-9_]*)\s*$')
    if (-not $pm.Success) {
        "MISS EllipseWithCenter parameter name parse: $part" | Tee-Object -Append $log
        exit 0
    }
    $names += $pm.Groups[1].Value
}

$center = $names[0]
$radius1 = $names[1]
$radius2 = $names[2]
$numeric3 = $names[3]

$guard = @"

        $marker
        if ($center == null ||
            double.IsNaN($radius1) || double.IsInfinity($radius1) ||
            double.IsNaN($radius2) || double.IsInfinity($radius2) ||
            double.IsNaN($numeric3) || double.IsInfinity($numeric3) ||
            $radius1 <= 1E-9 || $radius2 <= 1E-9)
        {
            return;
        }
"@

$replacement = $m.Groups['head'].Value + $guard
$text = $text.Remove($m.Index, $m.Length).Insert($m.Index, $replacement)

if ($text -eq $original -or -not $text.Contains($marker)) {
    throw 'Ellipse guard insertion did not change the source as expected.'
}

[IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
"FIX EllipseWithCenter NaN/Infinity/null/non-positive radius guard: $path" | Tee-Object -Append $log
