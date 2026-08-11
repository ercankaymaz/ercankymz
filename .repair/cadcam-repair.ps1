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

    # Prevent a zero delta between generated Z levels from producing Infinity in
    # ForwardBackward marble step interpolation. Duplicate levels are safely skipped.
    $marbleStepPattern = 'double\s+num2\s*=\s*num1\s*-\s*doubleList\[index\];\s*double\s+num3\s*=\s*BackwardStep\s*/\s*num2;'
    if ([regex]::IsMatch($text, $marbleStepPattern)) {
        $marbleStepReplacement = @'
      double num2 = num1 - doubleList[index];
      if (Math.Abs(num2) <= 1E-9)
      {
        num1 = doubleList[index];
        continue;
      }
      double num3 = BackwardStep / num2;
'@
        $text = [regex]::Replace($text, $marbleStepPattern, $marbleStepReplacement)
        "FIX marble ForwardBackward zero-delta division: $path" | Tee-Object -Append $log
    }

    # Decompiled marble CAM bug: this expression modifies a temporary Pnt6DSim copy,
    # leaving the actual simulation point unchanged. Pnt6DSim is a reference type, so
    # mutating the list element directly keeps CAM and simulation Z offsets synchronized.
    $simZPattern = 'new\s+Pnt6DSim\(Cam\.CamPoints\[index5\]\.SimilationPoint\.SimDetailedPoints\[index6\]\)\.Z\s*-=?\s*Tool\.Geometry\.Diameter\s*/\s*2\.0;'
    if ([regex]::IsMatch($text, $simZPattern)) {
        $text = [regex]::Replace($text, $simZPattern, 'Cam.CamPoints[index5].SimilationPoint.SimDetailedPoints[index6].Z -= Tool.Geometry.Diameter / 2.0;')
        "FIX marble CAM simulation Z temporary-copy bug: $path" | Tee-Object -Append $log
    }

    # Guard zero-size imported geometry dimensions against Infinity/NaN scaling.
    $beforeScale = $text
    $text = $text.Replace('Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleWidth / num)', '(Math.Abs(num) > 1E-9 ? Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleWidth / num) : 1.0)')
    $text = $text.Replace('Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleHeight / num2)', '(Math.Abs(num2) > 1E-9 ? Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleHeight / num2) : 1.0)')
    $text = $text.Replace('Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleDepth / num3)', '(Math.Abs(num3) > 1E-9 ? Math.Abs(buMarbleCalc.varMarbleRunSettings.ScaleDepth / num3) : 1.0)')
    if ($text -ne $beforeScale) {
        "FIX zero-size geometry scale guard: $path" | Tee-Object -Append $log
    }

    # Preserve existing buNumeric edge-case outputs while removing invalid arithmetic.
    # Count<=1 currently appends LastValue in GetValueList...; keep that behavior but
    # avoid calculating a denominator of zero/negative count first.
    if ($path -like '*\buCore\buCore\buNumeric.cs') {
        $beforeNumeric = $text

        $equationOld = @'
			double num = 1.0;
			if (!(Math.Abs(X1 - X2) < 1E-10))
			{
				num = (Y2 - Y1) / (X2 - X1);
				X3 = (Y3 - Y1) / num + X1;
			}
			else
			{
				X3 = X1;
			}
'@
        $equationNew = @'
			double deltaX = X2 - X1;
			double deltaY = Y2 - Y1;
			if (Math.Abs(deltaX) < 1E-10 || Math.Abs(deltaY) < 1E-10)
			{
				X3 = X1;
			}
			else
			{
				double slope = deltaY / deltaX;
				X3 = (Y3 - Y1) / slope + X1;
			}
'@
        if ($text.Contains($equationOld)) {
            $text = $text.Replace($equationOld, $equationNew)
            "FIX buNumeric EquationLineer zero-X/zero-Y slope division: $path" | Tee-Object -Append $log
        }

        $countOld = @'
	{
		double num = LastValue - FirstValue;
		double num2 = num / ((double)Count - 1.0);
'@
        $countNew = @'
	{
		if (Count <= 1)
		{
			ValueList.Add(LastValue);
			return;
		}
		double num = LastValue - FirstValue;
		double num2 = num / ((double)Count - 1.0);
'@
        if ($text.Contains($countOld) -and $text.Contains('GetValueListFromMinMaxByCount')) {
            $text = $text.Replace($countOld, $countNew)
            "FIX buNumeric GetValueListFromMinMaxByCount Count<=1 division: $path" | Tee-Object -Append $log
        }

        $divideOld = @'
	{
		Values.Clear();
		double num = (EndValue - StartValue) / (double)(DevideCount - 1);
'@
        $divideNew = @'
	{
		Values.Clear();
		if (DevideCount <= 1)
		{
			Values.Add(StartValue);
			Values.Add(EndValue);
			return;
		}
		double num = (EndValue - StartValue) / (double)(DevideCount - 1);
'@
        if ($text.Contains($divideOld) -and $text.Contains('DevideMinMaxValueByNumber')) {
            $text = $text.Replace($divideOld, $divideNew)
            "FIX buNumeric DevideMinMaxValueByNumber divide-count 0/1: $path" | Tee-Object -Append $log
        }

        if ($text -ne $beforeNumeric) {
            "FIX buNumeric edge-case arithmetic guards applied: $path" | Tee-Object -Append $log
        }
    }

    # C# 14 introduces 'field' as a contextual keyword inside property accessors.
    # The decompiled ImageProcessor Rational<T>.MaxValue getter uses a local named
    # field, which is then parsed as the backing-field keyword. Rename only that
    # exact decompiler construct; behavior remains identical.
    if ($path -like '*\ImageProcessor\Imaging\MetaData\Rational.cs') {
        $beforeImageProcessor = $text
        $text = $text.Replace('FieldInfo field = typeof(T).GetField("MaxValue", BindingFlags.Static | BindingFlags.Public);', 'FieldInfo fieldInfo = typeof(T).GetField("MaxValue", BindingFlags.Static | BindingFlags.Public);')
        $text = $text.Replace('if (field != null)', 'if (fieldInfo != null)')
        $text = $text.Replace('Convert.ToDecimal(field.GetValue(null))', 'Convert.ToDecimal(fieldInfo.GetValue(null))')
        if ($text -ne $beforeImageProcessor) {
            "FIX ImageProcessor C#14 field keyword conflict: $path" | Tee-Object -Append $log
        }
    }

    if ($text -ne $original) {
        [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
        $patchedCount++
    }
}

"Patched C# files: $patchedCount" | Tee-Object -Append $log
