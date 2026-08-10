$ErrorActionPreference = 'Continue'
New-Item -ItemType Directory -Force build-logs | Out-Null
$out = 'build-logs/inventory.txt'
Remove-Item $out -ErrorAction Ignore

$files = @(Get-ChildItem -Recurse -Filter *.cs -File)
$projects = @(Get-ChildItem -Recurse -Filter *.csproj -File)
$solutions = @(Get-ChildItem -Recurse -Filter *.sln -File)

$formCount = @(Select-String -Path $files.FullName -Pattern 'class\s+\w+\s*:\s*(Form|UserControl)' -ErrorAction SilentlyContinue).Count
$clickCount = @(Select-String -Path $files.FullName -SimpleMatch '.Click +=' -ErrorAction SilentlyContinue).Count
$valueChangedCount = @(Select-String -Path $files.FullName -SimpleMatch '.ValueChanged +=' -ErrorAction SilentlyContinue).Count
$convertDoubleCount = @(Select-String -Path $files.FullName -SimpleMatch 'Convert.ToDouble(' -ErrorAction SilentlyContinue).Count

('C# files: {0}' -f $files.Count) | Tee-Object $out
('CSPROJ files: {0}' -f $projects.Count) | Tee-Object -Append $out
('SLN files: {0}' -f $solutions.Count) | Tee-Object -Append $out
('Form/UserControl classes: {0}' -f $formCount) | Tee-Object -Append $out
('Click handlers: {0}' -f $clickCount) | Tee-Object -Append $out
('ValueChanged handlers: {0}' -f $valueChangedCount) | Tee-Object -Append $out
('Convert.ToDouble uses: {0}' -f $convertDoubleCount) | Tee-Object -Append $out
'Solutions/projects:' | Tee-Object -Append $out
$solutions | ForEach-Object { $_.FullName } | Tee-Object -Append $out
$projects | ForEach-Object { $_.FullName } | Tee-Object -Append $out

Select-String -Path $files.FullName -Pattern 'catch\s*(\([^)]*\))?\s*\{\s*\}' -ErrorAction SilentlyContinue |
    Select-Object -First 300 |
    ForEach-Object { '{0}:{1}: {2}' -f $_.Path, $_.LineNumber, $_.Line.Trim() } |
    Set-Content build-logs/empty-catches.txt

Select-String -Path $files.FullName -Pattern '/\s*(Count|num\w*)' -ErrorAction SilentlyContinue |
    Select-Object -First 300 |
    ForEach-Object { '{0}:{1}: {2}' -f $_.Path, $_.LineNumber, $_.Line.Trim() } |
    Set-Content build-logs/division-candidates.txt
