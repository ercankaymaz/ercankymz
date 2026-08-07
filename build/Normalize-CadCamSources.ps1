$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$targets = @(
    'buCadCamRes/buCadCamResVer5/Editor/Drafting2D.cs',
    'buCadCamRes/buCadCamResVer5/clsCommand.cs'
)
foreach ($relative in $targets) {
    $path = Join-Path $root $relative
    if (-not (Test-Path $path)) { throw "Source missing: $relative" }
    $text = [IO.File]::ReadAllText($path)
    $text = $text.Replace("`r`n", "`n").Replace("`r", "`n").Replace("`n", "`r`n")
    [IO.File]::WriteAllText($path, $text, (New-Object Text.UTF8Encoding($false)))
    Write-Host "Normalized CRLF: $relative"
}
