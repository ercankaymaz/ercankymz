using System;

namespace Xceed.Wpf.AvalonDock.Layout;

public class LayoutElementEventArgs : EventArgs
{
	public LayoutElement Element { get; private set; }

	public LayoutElementEventArgs(LayoutElement element)
	{
		Element = element;
	}
}
