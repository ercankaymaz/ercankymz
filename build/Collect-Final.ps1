$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$out = Join-Path $root 'FINAL_DLLS'
New-Item -ItemType Directory -Force -Path $out | Out-Null

$names = @(
  'CmdLangAPI.dll','buCore.dll','buFile.dll','buClass.dll','buComm.dll','buPowerNest.dll',
  'buOpcDlls.dll','buOpcUA.dll','buMotion.dll','buEyeBase.dll','buMW.dll','buControls.dll',
  'buMarble.dll','buCadCamRes.dll','CMDMarbleCNC.exe'
)

$manifest = @()
foreach ($name in $names) {
  $candidate = Get-ChildItem -Path $root -Recurse -File -Filter $name |
    Where-Object { $_.FullName -match '\\(bin|Release|Debug)\\' -and $_.FullName -notmatch '\\FINAL_DLLS\\' } |
    Sort-Object LastWriteTime -Descending |
    Select-Object -First 1
  if ($candidate) {
    Copy-Item $candidate.FullName (Join-Path $out $name) -Force
    $hash = (Get-FileHash $candidate.FullName -Algorithm SHA256).Hash
    $manifest += [pscustomobject]@{ File=$name; Source=$candidate.FullName.Substring($root.Length+1); Size=$candidate.Length; SHA256=$hash }
  }
}

$manifest | ConvertTo-Json -Depth 3 | Set-Content (Join-Path $out 'manifest.json') -Encoding UTF8
$manifest | Format-Table -AutoSize | Out-String | Set-Content (Join-Path $out 'manifest.txt') -Encoding UTF8
