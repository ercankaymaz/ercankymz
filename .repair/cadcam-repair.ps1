$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/cadcam-logic-repairs.txt'
Remove-Item $log -ErrorAction Ignore
$patchedCount = 0

Get-ChildItem -Recurse -Filter *.cs -File | ForEach-Object {
    $path = $_.FullName
    $text = [IO.File]::ReadAllText($path)
    $original = $text

    # Single-cut: persist the requested cut length before geometry calculation.
    $singleCutPattern = 'this\.doAddItemSingleCut\(new Point3D\(\),\s*buMarbleForms\.frmSingle\.spn_angleA\.Value,\s*buMarbleForms\.frmSingle\.spn_angleC\.Value,\s*false,\s*-1,\s*false\);\s*buMarbleCalc\.varOperation\.settingSliceCut\.CutLengthSingle\s*=\s*buMarbleForms\.frmSingle\.spn_lengthVer\.Value;'
    if ([regex]::IsMatch($text, $singleCutPattern)) {
        $replacement = @'
                double requestedSingleCutLength = buMarbleForms.frmSingle.spn_lengthVer.Value;
                if (double.IsNaN(requestedSingleCutLength) || double.IsInfinity(requestedSingleCutLength) || requestedSingleCutLength <= 0.0)
                {
                    MessageBox.Show("Cut length must be greater than zero.", "Marble CAM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                buMarbleCalc.varOperation.settingSliceCut.CutLengthSingle = requestedSingleCutLength;
                this.doAddItemSingleCut(new Point3D(), buMarbleForms.frmSingle.spn_angleA.Value, buMarbleForms.frmSingle.spn_angleC.Value, false, -1, false);
'@
        $text = [regex]::Replace($text, $singleCutPattern, $replacement, 1)
        "FIX SingleCut stale-length/order: $path" | Tee-Object -Append $log
    }

    # Culture-safe coordinate parsing for imported/digitizer geometry.
    $coordPattern = 'Point3D\s+item4\s*=\s*new Point3D\(Convert\.ToDouble\(array\[0\]\),\s*Convert\.ToDouble\(array\[1\]\)\);'
    if ([regex]::IsMatch($text, $coordPattern)) {
        $coordReplacement = @'
                                    double parsedX;
                                    double parsedY;
                                    bool parsedXOk = double.TryParse(array[0], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out parsedX) ||
                                                     double.TryParse(array[0], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out parsedX);
                                    bool parsedYOk = double.TryParse(array[1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out parsedY) ||
                                                     double.TryParse(array[1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out parsedY);
                                    if (!parsedXOk || !parsedYOk || double.IsNaN(parsedX) || double.IsNaN(parsedY) || double.IsInfinity(parsedX) || double.IsInfinity(parsedY))
                                    {
                                        continue;
                                    }
                                    Point3D item4 = new Point3D(parsedX, parsedY);
'@
        $text = [regex]::Replace($text, $coordPattern, $coordReplacement)
        "FIX culture-safe CAD coordinate parsing: $path" | Tee-Object -Append $log
    }

    # Guard zero-size imported geometry dimensions against Infinity/NaN scaling.
    $beforeScale = $text
    $text = $text.Replace('Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleWidth / num)', '(Math.Abs(num) > 1E-9 ? Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleWidth / num) : 1.0)')
    $text = $text.Replace('Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleHeight / num2)', '(Math.Abs(num2) > 1E-9 ? Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleHeight / num2) : 1.0)')
    $text = $text.Replace('Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleDepth / num3)', '(Math.Abs(num3) > 1E-9 ? Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleDepth / num3) : 1.0)')
    if ($text -ne $beforeScale) {
        "FIX zero-size geometry scale guard: $path" | Tee-Object -Append $log
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
        $patchedCount++
    }
}

"Patched C# files: $patchedCount" | Tee-Object -Append $log
