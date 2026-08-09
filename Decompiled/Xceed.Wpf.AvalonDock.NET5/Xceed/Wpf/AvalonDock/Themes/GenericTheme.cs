using System;

namespace Xceed.Wpf.AvalonDock.Themes;

public class GenericTheme : Theme
{
	public override Uri GetResourceUri()
	{
		string text = "Xceed.Wpf.AvalonDock.NET5";
		return new Uri("/" + text + ";component/Themes/generic.xaml", UriKind.Relative);
	}
}
