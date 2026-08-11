$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/project-normalize.txt'
Remove-Item $log -ErrorAction Ignore

$langFixes = 0
$frameworkFixes = 0
$netstandardFixes = 0
$windowsTfmFixes = 0
$resourceDedupeFixes = 0
$projectReferenceFixes = 0
$binaryRelinkFixes = 0
$plainBinaryRelinkFixes = 0
$nullableFixes = 0
$changedProjects = 0

$allProjects = @(Get-ChildItem -Recurse -Filter *.csproj -File)
$projectMap = @{}
foreach ($project in $allProjects) {
    try {
        [xml]$mapXml = [IO.File]::ReadAllText($project.FullName)
        $assemblyNode = $mapXml.SelectSingleNode('//*[local-name()="AssemblyName"]')
        $assemblyName = if ($null -ne $assemblyNode -and -not [string]::IsNullOrWhiteSpace($assemblyNode.InnerText)) { $assemblyNode.InnerText.Trim() } else { [IO.Path]::GetFileNameWithoutExtension($project.Name) }
        if (-not [string]::IsNullOrWhiteSpace($assemblyName)) {
            $key = $assemblyName.ToLowerInvariant()
            if (-not $projectMap.ContainsKey($key)) { $projectMap[$key] = $project.FullName }
        }
    } catch {
        "MAP XMLERR $($project.FullName): $($_.Exception.Message)" | Tee-Object -Append $log
    }
}
"Decompiled project map entries: $($projectMap.Count)" | Tee-Object -Append $log

$binaryMap = @{}
Get-ChildItem -Recurse -Filter *.dll -File | Where-Object {
    $_.FullName -notmatch '\\(bin|obj)\\'
} | ForEach-Object {
    $key = $_.BaseName.ToLowerInvariant()
    if (-not $binaryMap.ContainsKey($key)) {
        $binaryMap[$key] = $_.FullName
    }
}
"Repository binary map entries: $($binaryMap.Count)" | Tee-Object -Append $log

$sourceFirstAssemblies = New-Object 'System.Collections.Generic.HashSet[string]' ([System.StringComparer]::OrdinalIgnoreCase)
@('buClass','buCore','buControls','buEyeBase','buCadCamRes','buMW','CMDMarbleCNC','CmdLangAPI') | ForEach-Object { [void]$sourceFirstAssemblies.Add($_) }

# Some recovered projects lost HintPath completely for vendor assemblies. Do not
# convert every plain Reference (System.*, framework/GAC references must stay intact).
# Relink only the known CAD/CAM vendor references that are expected from bootstrap.
$plainBinaryRelinkAssemblies = New-Object 'System.Collections.Generic.HashSet[string]' ([System.StringComparer]::OrdinalIgnoreCase)
@('mwInterop') | ForEach-Object { [void]$plainBinaryRelinkAssemblies.Add($_) }

foreach ($project in $allProjects) {
    $path = $project.FullName
    $text = [IO.File]::ReadAllText($path)
    $original = $text

    $before = $text
    $text = [regex]::Replace($text, '<LangVersion>\s*15(?:\.0)?\s*</LangVersion>', '<LangVersion>latest</LangVersion>', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)
    if ($text -ne $before) { $langFixes++; "FIX LangVersion 15 -> latest: $path" | Tee-Object -Append $log }

    if ($project.Name -ieq 'Newtonsoft.Json.csproj' -and $text -notmatch '<Nullable>') {
        $text = $text.Replace('<GenerateAssemblyInfo>False</GenerateAssemblyInfo>', "<GenerateAssemblyInfo>False</GenerateAssemblyInfo>`n    <Nullable>enable</Nullable>")
        $nullableFixes++
        "FIX nullable context for Newtonsoft.Json: $path" | Tee-Object -Append $log
    }

    $before = $text
    $text = [regex]::Replace($text, '<TargetFramework>\s*net(?:40|45|451|452|46|461|462|47|471|472)\s*</TargetFramework>', '<TargetFramework>net48</TargetFramework>', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)
    if ($text -ne $before) { $frameworkFixes++; "FIX .NET Framework target -> net48: $path" | Tee-Object -Append $log }

    $before = $text
    $text = [regex]::Replace($text, '<TargetFramework>\s*netstandard(?:1\.[0-6]|2\.0)\s*</TargetFramework>', '<TargetFramework>net48</TargetFramework>', [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)
    if ($text -ne $before) { $netstandardFixes++; "FIX recovered netstandard target -> net48: $path" | Tee-Object -Append $log }

    if ($text -match '<UseWindowsForms>\s*True\s*</UseWindowsForms>' -or $text -match '<UseWPF>\s*True\s*</UseWPF>' -or $text -match 'Sdk="Microsoft\.NET\.Sdk\.WindowsDesktop"') {
        foreach ($tfm in @('net5.0','net6.0','net7.0','net8.0','net9.0','net10.0')) {
            $plain = "<TargetFramework>$tfm</TargetFramework>"
            $windows = "<TargetFramework>$tfm-windows</TargetFramework>"
            if ($text.Contains($plain)) { $text = $text.Replace($plain, $windows); $windowsTfmFixes++; "FIX Windows target framework $tfm -> $tfm-windows: $path" | Tee-Object -Append $log }
        }
    }

    $newline = if ($text.Contains("`r`n")) { "`r`n" } else { "`n" }
    $lines = $text -split "`r?`n"
    $seenEmbedded = New-Object 'System.Collections.Generic.HashSet[string]' ([System.StringComparer]::OrdinalIgnoreCase)
    $rebuilt = New-Object System.Collections.Generic.List[string]
    foreach ($line in $lines) {
        $trimmed = $line.Trim()
        if ($trimmed -match '^<EmbeddedResource\s+Include="[^"]+"[^>]*?/?>$' -and -not $seenEmbedded.Add($trimmed)) {
            $resourceDedupeFixes++; "FIX duplicate EmbeddedResource: $path :: $trimmed" | Tee-Object -Append $log; continue
        }
        $rebuilt.Add($line)
    }
    $text = [string]::Join($newline, $rebuilt)

    try {
        [xml]$projXml = $text
        $xmlChanged = $false

        # Repair missing/broken HintPath references.
        $refNodes = @($projXml.SelectNodes('//*[local-name()="Reference" and *[local-name()="HintPath"]]'))
        foreach ($ref in $refNodes) {
            $hintNode = $ref.SelectSingleNode('./*[local-name()="HintPath"]')
            if ($null -eq $hintNode) { continue }
            $hint = [string]$hintNode.InnerText
            if ([string]::IsNullOrWhiteSpace($hint)) { continue }

            try {
                $resolvedDll = if ([IO.Path]::IsPathRooted($hint)) {
                    [IO.Path]::GetFullPath($hint)
                } else {
                    [IO.Path]::GetFullPath((Join-Path $project.DirectoryName $hint))
                }
            } catch {
                "REFERENCE BADPATH ${path}: $hint :: $($_.Exception.Message)" | Tee-Object -Append $log
                continue
            }
            if (Test-Path -LiteralPath $resolvedDll -PathType Leaf) { continue }

            $include = [string]$ref.GetAttribute('Include')
            if ([string]::IsNullOrWhiteSpace($include)) { continue }
            $assemblyName = ($include.Split(',')[0]).Trim()
            $assemblyKey = $assemblyName.ToLowerInvariant()
            $preferSource = $sourceFirstAssemblies.Contains($assemblyName)

            if (-not $preferSource -and $binaryMap.ContainsKey($assemblyKey)) {
                $binaryPath = [string]$binaryMap[$assemblyKey]
                $relativeDll = [IO.Path]::GetRelativePath($project.DirectoryName, $binaryPath).Replace('/', '\')
                $hintNode.InnerText = $relativeDll
                $binaryRelinkFixes++
                $xmlChanged = $true
                "FIX missing HintPath -> recovered binary: $path :: $include :: $relativeDll" | Tee-Object -Append $log
                continue
            }

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

        # Repair decompiler-lost HintPath for selected vendor references (mwInterop).
        $plainRefs = @($projXml.SelectNodes('//*[local-name()="Reference" and not(*[local-name()="HintPath"])]'))
        foreach ($ref in $plainRefs) {
            $include = [string]$ref.GetAttribute('Include')
            if ([string]::IsNullOrWhiteSpace($include)) { continue }
            $assemblyName = ($include.Split(',')[0]).Trim()
            if (-not $plainBinaryRelinkAssemblies.Contains($assemblyName)) { continue }
            $assemblyKey = $assemblyName.ToLowerInvariant()
            if (-not $binaryMap.ContainsKey($assemblyKey)) {
                "WARN plain vendor reference has no bootstrap binary: $path :: $assemblyName" | Tee-Object -Append $log
                continue
            }
            $binaryPath = [string]$binaryMap[$assemblyKey]
            $relativeDll = [IO.Path]::GetRelativePath($project.DirectoryName, $binaryPath).Replace('/', '\')
            $hintNode = $projXml.CreateElement('HintPath', $ref.NamespaceURI)
            $hintNode.InnerText = $relativeDll
            [void]$ref.AppendChild($hintNode)
            $plainBinaryRelinkFixes++
            $xmlChanged = $true
            "FIX plain vendor Reference -> HintPath: $path :: $assemblyName :: $relativeDll" | Tee-Object -Append $log
        }

        if ($xmlChanged) { $text = $projXml.OuterXml }
    } catch {
        "REFERENCE XMLERR ${path}: $($_.Exception.Message)" | Tee-Object -Append $log
    }

    if ($text -ne $original) { [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false)); $changedProjects++ }
}

"Changed projects: $changedProjects" | Tee-Object -Append $log
"LangVersion fixes: $langFixes" | Tee-Object -Append $log
"Nullable context fixes: $nullableFixes" | Tee-Object -Append $log
".NET Framework -> net48 fixes: $frameworkFixes" | Tee-Object -Append $log
"netstandard -> net48 fixes: $netstandardFixes" | Tee-Object -Append $log
"Windows TFM fixes: $windowsTfmFixes" | Tee-Object -Append $log
"Duplicate EmbeddedResource fixes: $resourceDedupeFixes" | Tee-Object -Append $log
"Recovered binary relinks: $binaryRelinkFixes" | Tee-Object -Append $log
"Plain vendor binary relinks: $plainBinaryRelinkFixes" | Tee-Object -Append $log
"HintPath -> ProjectReference fixes: $projectReferenceFixes" | Tee-Object -Append $log
