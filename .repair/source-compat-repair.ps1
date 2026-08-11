$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/source-compat-repairs.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0
$vendorProjectRefsRemoved = 0

# Core assemblies are intentionally rebuilt from repaired source. A very small set of
# third-party assemblies is also source-built because we have explicit, verified
# decompiler-compatibility repairs for them. Everything else remains binary-first.
$coreAssemblies = New-Object 'System.Collections.Generic.HashSet[string]' ([System.StringComparer]::OrdinalIgnoreCase)
@('buClass','buCore','buControls','buEyeBase','buCadCamRes','buMW','CMDMarbleCNC','CmdLangAPI','Newtonsoft.Json','ImageProcessor') | ForEach-Object { [void]$coreAssemblies.Add($_) }

# Repair known decompiler source-compatibility artifacts.
$targets = @(
    'Decompiled/Newtonsoft.Json/Newtonsoft/Json/Linq/JContainer.cs',
    'Decompiled/buCadCamRes/buCadCamResVer5/clsCommand.cs'
)

foreach ($relativePath in $targets) {
    if (-not (Test-Path -LiteralPath $relativePath)) {
        "SKIP missing source: $relativePath" | Tee-Object -Append $log
        continue
    }

    $text = [IO.File]::ReadAllText($relativePath)
    $original = $text

    if ($relativePath -like '*JContainer.cs') {
        # Decompiled nullable metadata loses the `default` constraint required when
        # overriding an unconstrained generic T? member. Without it the compiler
        # treats T? as Nullable<T>, producing CS0453 + CS0508.
        $old = 'public override IEnumerable<T?> Values<T>()'
        $new = 'public override IEnumerable<T?> Values<T>() where T : default'
        if ($text.Contains($old) -and -not $text.Contains($new)) {
            $text = $text.Replace($old, $new)
            "FIX Newtonsoft JContainer Values<T> nullable override constraint" | Tee-Object -Append $log
        }
    }

    if ($relativePath -like '*clsCommand.cs') {
        # A decompiled interpolated string was emitted as a standalone expression
        # statement. C# only permits invocation/assignment-like expression statements;
        # preserve the intended layer description by assigning the value to `str`.
        $old = '$"{str} , {Layers[index].Tufting.StitchMode.ToString()} , P: {Layers[index].Tufting.PileHeight.ToString("f1")} , S: {Layers[index].Tufting.StitchLength.ToString("f1")}";'
        $new = 'str = $"{str} , {Layers[index].Tufting.StitchMode.ToString()} , P: {Layers[index].Tufting.PileHeight.ToString("f1")} , S: {Layers[index].Tufting.StitchLength.ToString("f1")}";'
        if ($text.Contains($old) -and -not $text.Contains($new)) {
            $text = $text.Replace($old, $new)
            "FIX clsCommand invalid standalone interpolated string" | Tee-Object -Append $log
        }
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($relativePath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    }
}

# project-normalize may map missing HintPath references to decompiled projects. Keep
# that behavior only for the repaired/source-build allowlist above. For every other
# auxiliary/vendor assembly, replace the generated ProjectReference with a plain
# assembly Reference. If a real DLL is present MSBuild can resolve it; if absent we get
# one honest missing-reference error instead of compiling broken third-party output.
Get-ChildItem -Recurse -Filter *.csproj -File | ForEach-Object {
    $project = $_
    try {
        [xml]$xml = [IO.File]::ReadAllText($project.FullName)
        $changed = $false
        $projectRefs = @($xml.SelectNodes('//*[local-name()="ProjectReference"]'))
        foreach ($projectRef in $projectRefs) {
            $include = [string]$projectRef.GetAttribute('Include')
            if ([string]::IsNullOrWhiteSpace($include)) { continue }

            $targetPath = [IO.Path]::GetFullPath((Join-Path $project.DirectoryName $include))
            $assemblyName = [IO.Path]::GetFileNameWithoutExtension($targetPath)

            # Prefer the target project's explicit AssemblyName when available before
            # applying the allowlist decision; project folder and AssemblyName can differ.
            if (Test-Path -LiteralPath $targetPath -PathType Leaf) {
                try {
                    [xml]$targetXml = [IO.File]::ReadAllText($targetPath)
                    $assemblyNode = $targetXml.SelectSingleNode('//*[local-name()="AssemblyName"]')
                    if ($null -ne $assemblyNode -and -not [string]::IsNullOrWhiteSpace($assemblyNode.InnerText)) {
                        $assemblyName = $assemblyNode.InnerText.Trim()
                    }
                } catch { }
            }

            if ($coreAssemblies.Contains($assemblyName)) { continue }
            if ([string]::IsNullOrWhiteSpace($assemblyName)) { continue }

            $reference = $xml.CreateElement('Reference', $projectRef.NamespaceURI)
            $reference.SetAttribute('Include', $assemblyName)
            [void]$projectRef.ParentNode.ReplaceChild($reference, $projectRef)
            $vendorProjectRefsRemoved++
            $changed = $true
            "FIX vendor ProjectReference -> assembly Reference: $($project.FullName) :: $assemblyName" | Tee-Object -Append $log
        }

        if ($changed) {
            [IO.File]::WriteAllText($project.FullName, $xml.OuterXml, [Text.UTF8Encoding]::new($false))
        }
    } catch {
        "PROJECT XMLERR $($project.FullName): $($_.Exception.Message)" | Tee-Object -Append $log
    }
}

"Patched compatibility sources: $patched" | Tee-Object -Append $log
"Vendor ProjectReferences removed: $vendorProjectRefsRemoved" | Tee-Object -Append $log
