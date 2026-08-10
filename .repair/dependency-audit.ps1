$ErrorActionPreference = 'Continue'
New-Item -ItemType Directory -Force build-logs | Out-Null
$out = 'build-logs/dependency-audit.txt'
Remove-Item $out -ErrorAction Ignore

$projects = @(Get-ChildItem -Recurse -Filter *.csproj -File)
$missing = New-Object System.Collections.Generic.List[string]
$managed = New-Object System.Collections.Generic.List[object]

"CAD/CAM dependency audit" | Tee-Object $out
"Projects: $($projects.Count)" | Tee-Object -Append $out

foreach ($project in $projects) {
    "`n===== $($project.FullName) =====" | Add-Content $out
    try {
        [xml]$xml = [IO.File]::ReadAllText($project.FullName)
        $ns = New-Object Xml.XmlNamespaceManager($xml.NameTable)
        $ns.AddNamespace('msb', 'http://schemas.microsoft.com/developer/msbuild/2003')
        $nodes = @($xml.SelectNodes('//msb:Reference[msb:HintPath]', $ns))
        if ($nodes.Count -eq 0) {
            # SDK-style/no-namespace fallback.
            $nodes = @($xml.SelectNodes('//Reference[HintPath]'))
        }
        foreach ($ref in $nodes) {
            $hintNode = if ($ref.HintPath) { $ref.HintPath } else { $ref.SelectSingleNode('msb:HintPath', $ns) }
            $hint = [string]$hintNode.InnerText
            if ([string]::IsNullOrWhiteSpace($hint)) { continue }
            $full = [IO.Path]::GetFullPath((Join-Path $project.DirectoryName $hint))
            $include = [string]$ref.Include
            if (Test-Path -LiteralPath $full -PathType Leaf) {
                $file = Get-Item -LiteralPath $full
                $version = 'native-or-unreadable'
                $assemblyName = $null
                try {
                    $an = [Reflection.AssemblyName]::GetAssemblyName($full)
                    $assemblyName = $an.Name
                    $version = $an.Version.ToString()
                    $managed.Add([pscustomobject]@{ Project=$project.FullName; Include=$include; Path=$full; Assembly=$assemblyName; Version=$version })
                } catch {}
                "OK   $include => $hint | $($file.Length) bytes | $version" | Add-Content $out
            } else {
                $line = "MISS $include => $hint"
                $line | Add-Content $out
                $missing.Add("$($project.FullName) :: $include :: $hint")
            }
        }
    } catch {
        "XMLERR $($_.Exception.Message)" | Add-Content $out
    }
}

"`n===== Critical CAD/CAM binaries =====" | Add-Content $out
$criticalNames = @('mwInterop','mwEntities','devDept.Eyeshot.v2026','devDept.Eyeshot.Control.Win.v2026','devDept.Eyeshot.x86.v2026','buClass','buCore','buMW','buEyeBase')
foreach ($name in $criticalNames) {
    $hits = @($managed | Where-Object { $_.Assembly -eq $name -or $_.Include -like "$name*" })
    if ($hits.Count -eq 0) {
        "NOT_REFERENCED $name" | Add-Content $out
    } else {
        $versions = @($hits | Select-Object -ExpandProperty Version -Unique)
        "REFERENCED $name versions=[$($versions -join ', ')] count=$($hits.Count)" | Add-Content $out
    }
}

"`n===== Duplicate managed assembly versions =====" | Add-Content $out
$managed | Group-Object Assembly | Where-Object { $_.Name -and (@($_.Group.Version | Select-Object -Unique).Count -gt 1) } | ForEach-Object {
    $versions = @($_.Group.Version | Select-Object -Unique)
    "VERSION_CONFLICT $($_.Name): $($versions -join ', ')" | Add-Content $out
}

"`nMissing HintPath references: $($missing.Count)" | Tee-Object -Append $out
$missing | ForEach-Object { "  $_" | Add-Content $out }

# This is a diagnostic gate: unresolved binary HintPath references make a validated DLL impossible.
if ($missing.Count -gt 0) { exit 2 }
