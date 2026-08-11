$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/miter-corner-geometry-guards.txt'
Remove-Item $log -ErrorAction Ignore
$patched = 0

$path = 'Decompiled/buCore/buCore/buVector.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "MISS $path" | Tee-Object -Append $log
    exit 0
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# Verified in PR #1: corner modification must project the trim by the LAST edge's
# own A orientation. The decompiled code reused a value derived from the first edge.
$repairs = @(
    @(
        'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - num3, StartPointType.Start, ref ModifiedLastEntity);',
        'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - ModifyLength / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A)), StartPointType.Start, ref ModifiedLastEntity);',
        'corner last-edge A compensation start/num3'
    ),
    @(
        'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - num3, StartPointType.End, ref ModifiedLastEntity);',
        'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - ModifyLength / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A)), StartPointType.End, ref ModifiedLastEntity);',
        'corner last-edge A compensation end/num3'
    ),
    @(
        'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - num4, StartPointType.Start, ref ModifiedLastEntity);',
        'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - ModifyLength / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A)), StartPointType.Start, ref ModifiedLastEntity);',
        'corner last-edge A compensation start/num4'
    ),
    @(
        'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - num4, StartPointType.End, ref ModifiedLastEntity);',
        'this.EntityUpdateByLength(eEntities.CopyEntity(LastEntity), LastEntity.geoLength - ModifyLength / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A)), StartPointType.End, ref ModifiedLastEntity);',
        'corner last-edge A compensation end/num4'
    ),
    @(
        'double CutLength2 = CutLength1 / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A));',
        'double CutLength2 = num2 / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A));',
        'remove double A compensation normal'
    ),
    @(
        'double CutLength3 = CutLength1 / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A));',
        'double CutLength3 = num2 / Math.Cos(buConversion.DegreeToRadian(LastEntity.Orientation.A));',
        'remove double A compensation reverse'
    )
)

foreach ($repair in $repairs) {
    $old = $repair[0]
    $new = $repair[1]
    $name = $repair[2]
    if ($text.Contains($old)) {
        $text = $text.Replace($old, $new)
        "FIX $name: $path" | Tee-Object -Append $log
    } elseif ($text.Contains($new)) {
        "OK already fixed $name: $path" | Tee-Object -Append $log
    } else {
        "NO_MATCH $name: $path" | Tee-Object -Append $log
    }
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
    $patched = 1
}
"Patched miter/corner files: $patched" | Tee-Object -Append $log
