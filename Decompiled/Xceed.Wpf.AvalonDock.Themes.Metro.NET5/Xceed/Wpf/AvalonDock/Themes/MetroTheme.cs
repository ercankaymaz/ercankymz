using System;

namespace Xceed.Wpf.AvalonDock.Themes;

public class MetroTheme : Theme
{
	public override Uri GetResourceUri()
	{
		string text = "Xceed.Wpf.AvalonDock.Themes.Metro";
		text += ".NET5";
		return new Uri("/" + text + ";component/Theme.xaml", UriKind.Relative);
	}
}
