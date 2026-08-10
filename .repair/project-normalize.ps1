$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/project-normalize.txt'
Remove-Item $log -ErrorAction Ignore

$langFixes = 0
$windowsTfmFixes = 0
$resourceDedupeFixes = 0
$changedProjects = 0

Get-ChildItem -Recurse -Filter *.csproj -File | ForEach-Object {
    $path = $_.FullName
    $text = [IO.File]::ReadAllText($path)
    $original = $text

    # Decompiled projects currently contain C# 15.0, which is not accepted by
    # the compiler on the Windows runner. 'latest' keeps modern decompiled syntax
    # enabled without hard-coding an unavailable language version.
    $before = $text
    $text = [regex]::Replace($text, '<LangVersion>\s*15(?:\.0)?\s*</LangVersion>', '<LangVersion>latest</LangVersion>', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)
    if ($text -ne $before) {
        $langFixes++
        "FIX LangVersion 15 -> latest: $path" | Tee-Object -Append $log
    }

    # SDK-style WinForms/WPF projects targeting net5+ require a Windows TFM.
    if ($text -match '<UseWindowsForms>\s*True\s*</UseWindowsForms>' -or $text -match '<UseWPF>\s*True\s*</UseWPF>' -or $text -match 'Sdk="Microsoft\.NET\.Sdk\.WindowsDesktop"') {
        foreach ($tfm in @('net5.0','net6.0','net7.0','net8.0','net9.0','net10.0')) {
            $plain = "<TargetFramework>$tfm</TargetFramework>"
            $windows = "<TargetFramework>$tfm-windows</TargetFramework>"
            if ($text.Contains($plain)) {
                $text = $text.Replace($plain, $windows)
                $windowsTfmFixes++
                "FIX Windows target framework $tfm -> $tfm-windows: $path" | Tee-Object -Append $log
            }
        }
    }

    # Decompilers can emit the same explicit EmbeddedResource Include repeatedly.
    # Remove exact duplicate Include lines while preserving the first declaration.
    $newline = if ($text.Contains("`r`n")) { "`r`n" } else { "`n" }
    $lines = $text -split "`r?`n"
    $seenEmbedded = New-Object 'System.Collections.Generic.HashSet[string]' ([System.StringComparer]::OrdinalIgnoreCase)
    $rebuilt = New-Object System.Collections.Generic.List[string]
    foreach ($line in $lines) {
        $trimmed = $line.Trim()
        if ($trimmed -match '^<EmbeddedResource\s+Include="[^"]+"[^>]*?/?>$') {
            if (-not $seenEmbedded.Add($trimmed)) {
                $resourceDedupeFixes++
                "FIX duplicate EmbeddedResource: $path :: $trimmed" | Tee-Object -Append $log
                continue
            }
        }
        $rebuilt.Add($line)
    }
    $text = [string]::Join($newline, $rebuilt)

    if ($text -ne $original) {
        [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
        $changedProjects++
    }
}

"Changed projects: $changedProjects" | Tee-Object -Append $log
"LangVersion fixes: $langFixes" | Tee-Object -Append $log
"Windows TFM fixes: $windowsTfmFixes" | Tee-Object -Append $log
"Duplicate EmbeddedResource fixes: $resourceDedupeFixes" | Tee-Object -Append $log
