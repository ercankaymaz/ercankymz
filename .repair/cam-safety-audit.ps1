$ErrorActionPreference = 'Continue'
New-Item -ItemType Directory -Force build-logs | Out-Null
$out = 'build-logs/cam-safety-audit.txt'
Remove-Item $out -ErrorAction Ignore

$files = @(Get-ChildItem -Recurse -Filter *.cs -File)
$findings = New-Object System.Collections.Generic.List[object]

function Add-Finding([string]$severity, [string]$kind, $match) {
    $findings.Add([pscustomobject]@{
        Severity = $severity
        Kind = $kind
        Path = $match.Path
        Line = $match.LineNumber
        Code = $match.Line.Trim()
    })
}

$rules = @(
    @{ Severity='HIGH'; Kind='TRIG_DIVISION_SIN'; Pattern='/\s*Math\.Sin\s*\(' },
    @{ Severity='HIGH'; Kind='TRIG_DIVISION_COS'; Pattern='/\s*Math\.Cos\s*\(' },
    @{ Severity='HIGH'; Kind='STEPDOWN_DIVISION'; Pattern='Math\.Ceiling\s*\([^\r\n]*/\s*\w+\s*\)' },
    @{ Severity='HIGH'; Kind='VERTICES_FIXED_INDEX'; Pattern='Vertices\s*\[[1-9]\d*\]' },
    @{ Severity='HIGH'; Kind='QUADS_FIXED_INDEX'; Pattern='Quads\s*\[[1-9]\d*\]' },
    @{ Severity='MEDIUM'; Kind='LAST_VERTEX_WITHOUT_VISIBLE_GUARD'; Pattern='Vertice\s*\[\s*[^\]]+\.Count\s*-\s*1\s*\]' },
    @{ Severity='MEDIUM'; Kind='LIST_LAST_WITHOUT_VISIBLE_GUARD'; Pattern='\[[^\]]+\.Count\s*-\s*1\]' },
    @{ Severity='MEDIUM'; Kind='CONVERT_TO_INT_AFTER_DIVISION'; Pattern='Convert\.ToInt32\s*\(\s*Math\.(Ceiling|Floor|Round)' },
    @{ Severity='LOW'; Kind='EMPTY_CATCH'; Pattern='catch\s*(\([^)]*\))?\s*\{\s*\}' }
)

foreach ($rule in $rules) {
    $matches = @(Select-String -Path $files.FullName -Pattern $rule.Pattern -ErrorAction SilentlyContinue)
    foreach ($m in $matches) { Add-Finding $rule.Severity $rule.Kind $m }
}

"Professional CAM safety audit" | Tee-Object $out
"C# files scanned: $($files.Count)" | Tee-Object -Append $out
"HIGH: $(@($findings | Where-Object Severity -eq 'HIGH').Count)" | Tee-Object -Append $out
"MEDIUM: $(@($findings | Where-Object Severity -eq 'MEDIUM').Count)" | Tee-Object -Append $out
"LOW: $(@($findings | Where-Object Severity -eq 'LOW').Count)" | Tee-Object -Append $out

$findings | Sort-Object Severity, Path, Line | ForEach-Object {
    "[$($_.Severity)] $($_.Kind) :: $($_.Path):$($_.Line) :: $($_.Code)" | Add-Content $out
}

# Target known marble CAM patterns separately to make first build actionable.
"`n===== Marble CAM known-risk signatures =====" | Add-Content $out
$known = @(
    'MaterialThickness\s*/\s*Math\.Sin',
    'Tool\.Geometry\.Thickness\s*/\s*Math\.Cos',
    'Items\[[^\]]+\]\.Length\s*/\s*Math\.(Sin|Cos)',
    'Convert\.ToInt32\(Math\.Ceiling\([^\r\n]*/[^\r\n]+\)\)',
    'LeadInEntitiy\.Vertice\[0\]',
    'LeadOutEntitiy\.Vertice\[[^\]]+\.Count\s*-\s*1\]',
    'CalcPoints2\[index\]'
)
foreach ($pattern in $known) {
    Select-String -Path $files.FullName -Pattern $pattern -ErrorAction SilentlyContinue | ForEach-Object {
        "$($_.Path):$($_.LineNumber): $($_.Line.Trim())" | Add-Content $out
    }
}
