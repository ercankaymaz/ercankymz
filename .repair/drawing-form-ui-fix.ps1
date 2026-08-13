$ErrorActionPreference = 'Stop'
$path = 'Decompiled/buCadCamRes/buCadCamResVer5/Forms/F_Drawing.cs'
if (-not (Test-Path -LiteralPath $path)) { exit 2 }
$text = [IO.File]::ReadAllText($path)
$text = $text.Replace('mnu_viewright.Text = buLangTranslate.preDef.Top + " " + buLangTranslate.preDef.View;', 'mnu_viewright.Text = buLangTranslate.preDef.Right + " " + buLangTranslate.preDef.View;')
foreach ($control in @('btn_ok','btn_cancel','btn_undo')) {
  $add = "`t`t$control.Click += clsInit.appCommand.ViewportButtonsClick;"
  $remove = "`t`t$control.Click -= clsInit.appCommand.ViewportButtonsClick;"
  if ($text.Contains($add) -and -not $text.Contains($remove)) {
    $text = $text.Replace($add, $remove + [Environment]::NewLine + $add)
  }
}
[IO.File]::WriteAllText($path, $text, [Text.UTF8Encoding]::new($false))
