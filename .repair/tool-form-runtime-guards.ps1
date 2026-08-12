$ErrorActionPreference = 'Stop'
New-Item -ItemType Directory -Force build-logs | Out-Null
$log = 'build-logs/tool-form-runtime-guards.txt'
Remove-Item $log -ErrorAction Ignore

$path = 'Decompiled/buCadCamRes/buCadCamResVer5/Forms/F_Tool.cs'
if (-not (Test-Path -LiteralPath $path)) {
    "FAIL missing tool form: $path" | Tee-Object $log
    exit 2
}

$text = [IO.File]::ReadAllText($path)
$original = $text

# tabControl_1 is later reduced to the page matching the selected ToolType.
# Init can be called again on the same form instance after that reduction. If we
# clear list_0 and recache the current TabPages, the master 14-page list is lost
# and TabPAgeVisibility() can later index beyond the shortened list. Capture the
# master page set only once; subsequent Init calls must preserve it.
$oldTabs = @'
    this.TopMost = this.Properties.TopMost;
    for (int index = 0; index <= this.tabControl_1.TabPages.Count - 1; ++index)
      this.list_0.Add(this.tabControl_1.TabPages[index]);
'@
$newTabs = @'
    this.TopMost = this.Properties.TopMost;
    if (this.list_0.Count == 0)
    {
      for (int index = 0; index <= this.tabControl_1.TabPages.Count - 1; ++index)
        this.list_0.Add(this.tabControl_1.TabPages[index]);
    }
'@
if ($text.Contains($oldTabs)) {
    $text = $text.Replace($oldTabs, $newTabs)
    "FIX F_Tool preserve master tab cache across repeated Init calls" | Tee-Object -Append $log
}

# Recovered/persisted tool files can contain non-finite or out-of-range numeric
# values. Direct NumericUpDown.Value assignments throw during form initialization.
# Route every Tool-backed assignment through a finite, clamped setter.
if ($text -notmatch 'private void SetSafeToolNumericValue\(') {
    $anchor = '  public void Init()'
    if (-not $text.Contains($anchor)) { throw 'F_Tool Init anchor not found.' }
    $helper = @'
  private void SetSafeToolNumericValue(NumericUpDown control, double value, string fieldName)
  {
    if (control == null)
      return;
    double safe = value;
    if (double.IsNaN(safe) || double.IsInfinity(safe))
    {
      safe = (double) control.Minimum;
      buLogVer5.addToList(nameof (F_Tool), nameof (SetSafeToolNumericValue), "ToolInput", "NonFinite", fieldName);
    }
    safe = Math.Max((double) control.Minimum, Math.Min((double) control.Maximum, safe));
    control.Value = (decimal) safe;
  }

'@
    $text = $text.Replace($anchor, $helper + $anchor)
}

$pattern = 'this\.(numericUpDown_\d+)\.Value\s*=\s*\(Decimal\)\s*(this\.Tool\.[^;]+);'
$matches = [regex]::Matches($text, $pattern)
$replaced = 0
for ($i = $matches.Count - 1; $i -ge 0; --$i) {
    $m = $matches[$i]
    $control = $m.Groups[1].Value
    $expr = $m.Groups[2].Value
    $field = $expr.Substring('this.Tool.'.Length)
    $replacement = 'this.SetSafeToolNumericValue(this.' + $control + ', (double) ' + $expr + ', "' + $field + '");'
    $text = $text.Remove($m.Index, $m.Length).Insert($m.Index, $replacement)
    $replaced++
}
if ($replaced -gt 0) {
    "FIX F_Tool Tool-backed NumericUpDown assignments hardened: $replaced" | Tee-Object -Append $log
}

if ($text -ne $original) {
    [IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
}

$verified = [IO.File]::ReadAllText($path)
if ($verified -notmatch 'if \(this\.list_0\.Count == 0\)') { throw 'F_Tool master tab cache guard regression.' }
if ($verified -match 'this\.list_0\.Clear\(\);') { throw 'F_Tool tab cache must not be cleared after visibility filtering.' }
if ($verified -notmatch 'private void SetSafeToolNumericValue\(') { throw 'F_Tool safe numeric helper regression.' }
if ([regex]::IsMatch($verified, $pattern)) { throw 'Unsafe Tool-backed NumericUpDown assignment remains.' }

"Tool form runtime guard audit OK" | Tee-Object -Append $log
