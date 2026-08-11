$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/ellipse-guards.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buCore/buCore/buVector.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
} else {
    $text = [IO.File]::ReadAllText($path)
    $original = $text
    $marker = '// REPAIR: ellipse numeric input guard'

    if (-not $text.Contains($marker)) {
        # The validated PR #1 IL repair established the exact contract:
        # EllipseWithCenter is void with seven parameters; parameter 0 is center,
        # parameters 1/2 are radii, parameter 3 is numeric orientation and parameter
        # 6 is the output vertex list. The output list must be reset even for invalid
        # input so stale geometry cannot escape from a previous calculation.
        $pattern = '(?ms)(?<head>\b(?:public|internal|private|protected)\s+(?:static\s+)?void\s+EllipseWithCenter\s*\((?<params>[^\)]*)\)\s*\{)'
        $m = [regex]::Match($text, $pattern)
        if ($m.Success) {
            $parts = @($m.Groups['params'].Value -split ',')
            if ($parts.Count -eq 7) {
                $names = @()
                foreach ($part in $parts) {
                    $pm = [regex]::Match($part.Trim(), '([A-Za-z_][A-Za-z0-9_]*)\s*$')
                    if (-not $pm.Success) { $names = @(); break }
                    $names += $pm.Groups[1].Value
                }
                if ($names.Count -eq 7) {
                    $center = $names[0]
                    $radius1 = $names[1]
                    $radius2 = $names[2]
                    $numeric3 = $names[3]
                    $vertices = $names[6]
                    $guard = @"

        $marker
        if ($vertices == null)
        {
            $vertices = new List<Pnt3D>();
        }
        $vertices.Clear();
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
                }
            }
        }
    } else {
        # Upgrade an earlier PR #2 guard that validated input but did not reset the
        # output list. This preserves the PR #1 contract and prevents stale vertices.
        $methodPattern = '(?ms)(?<head>\b(?:public|internal|private|protected)\s+(?:static\s+)?void\s+EllipseWithCenter\s*\((?<params>[^\)]*)\)\s*\{)(?<body>.*?)(?=\n\s*(?:public|internal|private|protected)\s+)'
        $mm = [regex]::Match($text, $methodPattern)
        if ($mm.Success) {
            $parts = @($mm.Groups['params'].Value -split ',')
            if ($parts.Count -eq 7) {
                $pm = [regex]::Match($parts[6].Trim(), '([A-Za-z_][A-Za-z0-9_]*)\s*$')
                if ($pm.Success) {
                    $vertices = $pm.Groups[1].Value
                    $body = $mm.Groups['body'].Value
                    if ($body -notmatch [regex]::Escape("$vertices.Clear();")) {
                        $insertAfter = $marker
                        $upgrade = "$marker`r`n        if ($vertices == null)`r`n        {`r`n            $vertices = new List<Pnt3D>();`r`n        }`r`n        $vertices.Clear();"
                        $body = $body.Replace($insertAfter, $upgrade)
                        $text = $text.Remove($mm.Groups['body'].Index, $mm.Groups['body'].Length).Insert($mm.Groups['body'].Index, $body)
                    }
                }
            }
        }
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
        "FIX EllipseWithCenter finite radii plus stale output vertex contract: $path" | Tee-Object -Append $log
    } elseif ($text.Contains($marker)) {
        "OK EllipseWithCenter guard already present: $path" | Tee-Object -Append $log
    } else {
        "MISS EllipseWithCenter/7 source signature: $path" | Tee-Object -Append $log
    }
}

# PR #1 verified that ProfileOperationEllipse Width/Height are full dimensions,
# while EllipseWithCenter expects radii. Apply the exact validated source repair.
$camPath = 'Decompiled/buCore/buCore/buCamCalc.cs'
if (Test-Path -LiteralPath $camPath) {
    $text = [IO.File]::ReadAllText($camPath)
    $original = $text
    $old = 'buAppCalc.cVector.EllipseWithCenter(Center, ((ProfileOperationEllipse) P).Width, ((ProfileOperationEllipse) P).Height, ((ProfileOperationEllipse) P).Angle, new WorkPlane(), buSystem.EntitiesResolution, ref pnt3DList2);'
    $new = 'buAppCalc.cVector.EllipseWithCenter(Center, ((ProfileOperationEllipse) P).Width / 2.0, ((ProfileOperationEllipse) P).Height / 2.0, ((ProfileOperationEllipse) P).Angle, new WorkPlane(), buSystem.EntitiesResolution, ref pnt3DList2);'
    if ($text.Contains($old)) {
        $text = $text.Replace($old, $new)
        [IO.File]::WriteAllText($camPath, $text, [Text.UTF8Encoding]::new($false))
        "FIX ProfileOperationEllipse Width/Height converted from full dimensions to radii: $camPath" | Tee-Object -Append $log
    } elseif ($text.Contains($new)) {
        "OK ProfileOperationEllipse radius conversion already present: $camPath" | Tee-Object -Append $log
    } else {
        "NO_MATCH ProfileOperationEllipse radius conversion: $camPath" | Tee-Object -Append $log
    }
} else {
    "MISS $camPath" | Tee-Object -Append $log
}
