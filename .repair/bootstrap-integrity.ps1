$ErrorActionPreference = 'Continue'
New-Item -ItemType Directory -Force build-logs | Out-Null
$out = 'build-logs/bootstrap-integrity.txt'
Remove-Item $out -ErrorAction Ignore

$expected = [ordered]@{
    'Basler.Pylon.dll' = '682F2F73B0C7266831EEB66C1F67354ACCE34BD3FEEC9387D3337D46655DB9C5'
    'buComm.dll' = '51D02206C5397DEAC813CE49449DF731DEEA83ACD26D8098F820FFCEB02DF634'
    'buFile.dll' = 'A4CD0702F575B121DD7A8623824A8B246A7934310195E62E2A07396F7CDC29AF'
    'buPowerNest.dll' = '2ABB2FB713EF5D6E62E1A8B315F2E29ADF1B588FA29C4F1A03792590BFF7A0F7'
    'ComponentFactory.Krypton.Ribbon.dll' = '4705734593E406C57AA9C52D56EEE558D284842C631C68247CAED6EF331D1487'
    'ComponentFactory.Krypton.Toolkit.dll' = 'FCF583AB31C89B84A5AA3A7C0A79CF9226BA11F60FDBDF380F2E43C44C59AEF0'
    'devDept.Eyeshot.Control.Win.v2026.dll' = '378D5DF35AE8903768E9BA593D20877B45BC3410B194D7FB6F1C1BD6B2892552'
    'devDept.Eyeshot.v2026.dll' = '9A46458D0DBE9690F02F654B0B43FA8FC2BB0B1F056B01CE13A23B98DC34FF22'
    'devDept.Eyeshot.x86.v2026.dll' = '7F2BC0DF18DF196841A3C8C0BB634311D10F6C7BDCA67B876B03D5D83E16DDF9'
    'hasp_net_windows.dll' = 'AD09FA54BF9603203C222482A1597935C14076169456BFD14E1BB237FE5C5E8D'
    'mwEntities.dll' = 'E5B5D718C07A91AE7EDFE80302CD0F3709A6137E4EE009CC49E08593BDF4DC62'
    'mwInterop.dll' = '828E2E2B92BBB6313A9416FED79BC43C96195DF6B9F709EC03C2569DDD9D3F8C'
    'System.Windows.Forms.Ribbon.dll' = 'B557EF0DD18706B4EA7DAC1F84E2D0700734AE666EF11597DF8D453DA44D6C14'
}

$roots = @('.repair/bootstrap-original') | Where-Object { Test-Path -LiteralPath $_ }
$failures = New-Object System.Collections.Generic.List[string]

'CAD/CAM original vendor bootstrap integrity audit' | Set-Content $out
"Expected files: $($expected.Count)" | Add-Content $out

foreach ($name in $expected.Keys) {
    $candidates = @()
    foreach ($root in $roots) {
        $candidates += @(Get-ChildItem -LiteralPath $root -Recurse -File -Filter $name -ErrorAction SilentlyContinue)
    }
    if ($candidates.Count -eq 0) {
        $failures.Add("MISSING $name")
        "MISSING $name" | Add-Content $out
        continue
    }

    # The original PR #1 artifact has a single canonical file for each expected name.
    $file = $candidates | Select-Object -First 1
    $actual = (Get-FileHash -LiteralPath $file.FullName -Algorithm SHA256).Hash.ToUpperInvariant()
    $wanted = ([string]$expected[$name]).ToUpperInvariant()
    if ($actual -ne $wanted) {
        $failures.Add("HASH_MISMATCH $name expected=$wanted actual=$actual path=$($file.FullName)")
        "HASH_MISMATCH $name expected=$wanted actual=$actual path=$($file.FullName)" | Add-Content $out
    } else {
        "OK $name sha256=$actual size=$($file.Length) path=$($file.FullName)" | Add-Content $out
    }
}

"Failures: $($failures.Count)" | Add-Content $out
$failures | ForEach-Object { "  $_" | Add-Content $out }

if ($failures.Count -gt 0) { exit 2 }
