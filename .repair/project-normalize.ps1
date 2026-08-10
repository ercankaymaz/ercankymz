$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/project-normalize.txt'
Remove-Item $log -ErrorAction Ignore

$langFixes = 0
$windowsTfmFixes = 0
$resourceDedupeFixes = 0
$projectReferenceFixes = 0
$changedProjects = 0

$allProjects = @(Get-ChildItem -Recurse -Filter *.csproj -File)
$projectMap = @{}

# Build an assembly-name -> decompiled project map before changing any project.
foreach ($project in $allProjects) {
    try {
        [xml]$mapXml = [IO.File]::ReadAllText($project.FullName)
        $assemblyNode = $mapXml.SelectSingleNode('//*[local-name()="AssemblyName"]')
        $assemblyName = if ($null -ne $assemblyNode -and -not [string]::IsNullOrWhiteSpace($assemblyNode.InnerText)) {
            $assemblyNode.InnerText.Trim()
        } else {
            [IO.Path]::GetFileNameWithoutExtension($project.Name)
        }
        if (-not [string]::IsNullOrWhiteSpace($assemblyName)) {
            $key = $assemblyName.ToLowerInvariant()
            if (-not $projectMap.ContainsKey($key)) {
                $projectMap[$key] = $project.FullName
            }
        }
    } catch {
        "MAP XMLERR $($project.FullName): $($_.Exception.Message)" | Tee-Object -Append $log
    }
}

"Decompiled project map entries: $($projectMap.Count)" | Tee-Object -Append $log

foreach ($project in $allProjects) {
    $path = $project.FullName
    $text = [IO.File]::ReadAllText($path)
    $original = $text

    $before = $text
    $text = [regex]::Replace($text, '<LangVersion>\s*15(?:\.0)?\s*</LangVersion>', '<LangVersion>latest</LangVersion>', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)
    if ($text -ne $before) {
        $langFixes++
        "FIX LangVersion 15 -> latest: $path" | Tee-Object -Append $log
    }

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

    try {
        [xml]$projXml = $text
        $refNodes = @($projXml.SelectNodes('//*[local-name()="Reference" and *[local-name()="HintPath"]]'))
        $xmlChanged = $false
        foreach ($ref in $refNodes) {
            $hintNode = $ref.SelectSingleNode('./*[local-name()="HintPath"]')
            if ($null -eq $hintNode) { continue }
            $hint = [string]$hintNode.InnerText
            if ([string]::IsNullOrWhiteSpace($hint)) { continue }

            $resolvedDll = [IO.Path]::GetFullPath((Join-Path $project.DirectoryName $hint))
            if (Test-Path -LiteralPath $resolvedDll -PathType Leaf) { continue }

            $include = [string]$ref.GetAttribute('Include')
            if ([string]::IsNullOrWhiteSpace($include)) { continue }
            $assemblyKey = ($include.Split(',')[0]).Trim().ToLowerInvariant()
            if (-not $projectMap.ContainsKey($assemblyKey)) { continue }

            $targetProject = [string]$projectMap[$assemblyKey]
            if ([string]::Equals($targetProject, $path, [StringComparison]::OrdinalIgnoreCase)) { continue }

            $relativeProject = [IO.Path]::GetRelativePath($project.DirectoryName, $targetProject).Replace('/', '\')
            $newRef = $projXml.CreateElement('ProjectReference', $ref.NamespaceURI)
            $newRef.SetAttribute('Include', $relativeProject)
            [void]$ref.ParentNode.ReplaceChild($newRef, $ref)
            $projectReferenceFixes++
            $xmlChanged = $true
            "FIX missing HintPath -> ProjectReference: $path :: $include :: $relativeProject" | Tee-Object -Append $log
        }
        if ($xmlChanged) {
            $text = $projXml.OuterXml
        }
    } catch {
        "REFERENCE XMLERR ${path}: $($_.Exception.Message)" | Tee-Object -Append $log
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
        $changedProjects++
    }
}

"Changed projects: $changedProjects" | Tee-Object -Append $log
"LangVersion fixes: $langFixes" | Tee-Object -Append $log
"Windows TFM fixes: $windowsTfmFixes" | Tee-Object -Append $log
"Duplicate EmbeddedResource fixes: $resourceDedupeFixes" | Tee-Object -Append $log
"HintPath -> ProjectReference fixes: $projectReferenceFixes" | Tee-Object -Append $log
