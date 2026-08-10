$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/source-compat-repairs.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$targets = @(
    'Decompiled/Newtonsoft.Json/Newtonsoft/Json/Linq/JContainer.cs'
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

    if ($text -ne $original) {
        [IO.File]::WriteAllText($relativePath, $text, [Text.UTF8Encoding]::new($false))
        $patched++
    }
}

"Patched compatibility sources: $patched" | Tee-Object -Append $log
