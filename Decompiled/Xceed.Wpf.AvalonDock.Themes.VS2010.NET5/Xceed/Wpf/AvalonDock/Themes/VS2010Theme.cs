using System;

namespace Xceed.Wpf.AvalonDock.Themes;

public class VS2010Theme : Theme
{
	public override Uri GetResourceUri()
	{
		string text = "Xceed.Wpf.AvalonDock.Themes.VS2010";
		text += ".NET5";
		return new Uri("/" + text + ";component/Theme.xaml", UriKind.Relative);
	}
}
