$ErrorActionPreference = 'Continue'
New-Item -ItemType Directory -Force build-logs | Out-Null
$out = 'build-logs/core-dependency-manifest.txt'
Remove-Item $out -ErrorAction Ignore

$coreProjects = @(
    'Decompiled/buClass/buClass.csproj',
    'Decompiled/buCore/buCore.csproj',
    'Decompiled/buControls/buControls.csproj',
    'Decompiled/buEyeBase/buEyeBase.csproj',
    'Decompiled/buMW/buMW.csproj',
    'Decompiled/buCadCamRes/buCadCamRes.csproj',
    'Decompiled/CMDMarbleCNC/CMDMarbleCNC.csproj'
)

# Versions validated from the original binaries supplied for this CAD/CAM application.
# These checks prevent a physically present but ABI-incompatible vendor DLL from hiding
# behind a successful HintPath resolution and later producing misleading CS0012 errors.
$expectedVersions = @{
    'mwInterop' = '2025.12.1.2'
    'devDept.Eyeshot.v2026' = '2026.1.187.0'
    'devDept.Eyeshot.Control.Win.v2026' = '2026.1.187.0'
    'devDept.Eyeshot.x86.v2026' = '2026.1.187.0'
}

$binaryMap = @{}
Get-ChildItem -Recurse -Filter *.dll -File | Where-Object { $_.FullName -notmatch '\\(bin|obj)\\' } | ForEach-Object {
    if (-not $binaryMap.ContainsKey($_.BaseName)) { $binaryMap[$_.BaseName] = $_.FullName }
}

$projectMap = @{}
Get-ChildItem -Recurse -Filter *.csproj -File | ForEach-Object {
    try {
        [xml]$x = [IO.File]::ReadAllText($_.FullName)
        $n = $x.SelectSingleNode('//*[local-name()="AssemblyName"]')
        $name = if ($null -ne $n -and $n.InnerText.Trim()) { $n.InnerText.Trim() } else { $_.BaseName }
        if (-not $projectMap.ContainsKey($name)) { $projectMap[$name] = $_.FullName }
    } catch { }
}

$missing = New-Object System.Collections.Generic.List[string]
$resolvedBinary = New-Object System.Collections.Generic.List[string]
$resolvedProject = New-Object System.Collections.Generic.List[string]
$versionMismatch = New-Object System.Collections.Generic.List[string]

function Test-BinaryIdentity([string]$simpleName, [string]$path, [string]$projectPath) {
    try {
        $an = [Reflection.AssemblyName]::GetAssemblyName($path)
        $actualName = $an.Name
        $actualVersion = $an.Version.ToString()
        "IDENTITY $simpleName => $actualName, Version=$actualVersion :: $path" | Add-Content $out
        if ($actualName -ne $simpleName) {
            $versionMismatch.Add("ASSEMBLY_NAME_MISMATCH :: $projectPath :: expected=$simpleName :: actual=$actualName :: $path")
        }
        if ($expectedVersions.ContainsKey($simpleName)) {
            $expected = [string]$expectedVersions[$simpleName]
            if ($actualVersion -ne $expected) {
                $versionMismatch.Add("ASSEMBLY_VERSION_MISMATCH :: $projectPath :: $simpleName :: expected=$expected :: actual=$actualVersion :: $path")
            } else {
                "VERSION_OK $simpleName $actualVersion" | Add-Content $out
            }
        }
    } catch {
        $versionMismatch.Add("ASSEMBLY_IDENTITY_UNREADABLE :: $projectPath :: $simpleName :: $path :: $($_.Exception.Message)")
    }
}

'CAD/CAM core dependency manifest' | Set-Content $out
"Repository binaries: $($binaryMap.Count)" | Add-Content $out
"Repository projects: $($projectMap.Count)" | Add-Content $out
"Expected critical versions: $($expectedVersions.Count)" | Add-Content $out

foreach ($projectPath in $coreProjects) {
    if (-not (Test-Path -LiteralPath $projectPath)) {
        $missing.Add("PROJECT_MISSING :: $projectPath")
        continue
    }
    "`n===== $projectPath =====" | Add-Content $out
    $dir = Split-Path -Parent (Resolve-Path $projectPath)
    try {
        [xml]$xml = [IO.File]::ReadAllText((Resolve-Path $projectPath))
        foreach ($pr in @($xml.SelectNodes('//*[local-name()="ProjectReference"]'))) {
            $inc = [string]$pr.GetAttribute('Include')
            $full = [IO.Path]::GetFullPath((Join-Path $dir $inc))
            if (Test-Path -LiteralPath $full -PathType Leaf) {
                $resolvedProject.Add("$projectPath :: $inc :: $full")
                "PROJECT_OK $inc => $full" | Add-Content $out
            } else {
                $missing.Add("PROJECT_REF_MISSING :: $projectPath :: $inc :: $full")
                "PROJECT_MISS $inc => $full" | Add-Content $out
            }
        }

        foreach ($ref in @($xml.SelectNodes('//*[local-name()="Reference"]'))) {
            $include = [string]$ref.GetAttribute('Include')
            if ([string]::IsNullOrWhiteSpace($include)) { continue }
            $simple = ($include.Split(',')[0]).Trim()
            $hintNode = $ref.SelectSingleNode('./*[local-name()="HintPath"]')
            if ($null -ne $hintNode -and -not [string]::IsNullOrWhiteSpace($hintNode.InnerText)) {
                $hint = [string]$hintNode.InnerText
                $full = if ([IO.Path]::IsPathRooted($hint)) { [IO.Path]::GetFullPath($hint) } else { [IO.Path]::GetFullPath((Join-Path $dir $hint)) }
                if (Test-Path -LiteralPath $full -PathType Leaf) {
                    $resolvedBinary.Add("$projectPath :: $simple :: $full")
                    "BINARY_OK $simple => $full" | Add-Content $out
                    Test-BinaryIdentity $simple $full $projectPath
                } elseif ($binaryMap.ContainsKey($simple)) {
                    $alt = [string]$binaryMap[$simple]
                    $resolvedBinary.Add("$projectPath :: $simple :: $alt")
                    "BINARY_ALT $simple => $alt" | Add-Content $out
                    Test-BinaryIdentity $simple $alt $projectPath
                } elseif ($projectMap.ContainsKey($simple)) {
                    $missing.Add("BINARY_REQUIRED_OR_SOURCE :: $projectPath :: $simple :: source=$($projectMap[$simple])")
                    "BINARY_MISS_SOURCE_EXISTS $simple => $($projectMap[$simple])" | Add-Content $out
                } else {
                    $missing.Add("BINARY_MISSING :: $projectPath :: $simple :: $full")
                    "BINARY_MISS $simple => $full" | Add-Content $out
                }
            } else {
                # Framework/GAC references are intentionally not marked missing here.
                "ASSEMBLY_REFERENCE $simple" | Add-Content $out
            }
        }
    } catch {
        $missing.Add("XML_ERROR :: $projectPath :: $($_.Exception.Message)")
    }
}

"`n===== SUMMARY =====" | Add-Content $out
"Resolved project refs: $($resolvedProject.Count)" | Add-Content $out
"Resolved binary refs: $($resolvedBinary.Count)" | Add-Content $out
"Actionable unresolved refs: $($missing.Count)" | Add-Content $out
"Identity/version mismatches: $($versionMismatch.Count)" | Add-Content $out
$missing | Sort-Object -Unique | ForEach-Object { "  $_" | Add-Content $out }
$versionMismatch | Sort-Object -Unique | ForEach-Object { "  $_" | Add-Content $out }

if ($missing.Count -gt 0 -or $versionMismatch.Count -gt 0) { exit 2 }
