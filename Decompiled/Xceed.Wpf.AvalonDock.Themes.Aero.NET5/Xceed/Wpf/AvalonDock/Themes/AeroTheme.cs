using System;

namespace Xceed.Wpf.AvalonDock.Themes;

public class AeroTheme : Theme
{
	public override Uri GetResourceUri()
	{
		string text = "Xceed.Wpf.AvalonDock.Themes.Aero";
		text += ".NET5";
		return new Uri("/" + text + ";component/Theme.xaml", UriKind.Relative);
	}
}
