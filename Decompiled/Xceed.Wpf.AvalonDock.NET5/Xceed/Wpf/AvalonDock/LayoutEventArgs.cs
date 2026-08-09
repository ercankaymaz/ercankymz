using System;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock;

internal class LayoutEventArgs : EventArgs
{
	public LayoutRoot LayoutRoot { get; private set; }

	public LayoutEventArgs(LayoutRoot layoutRoot)
	{
		LayoutRoot = layoutRoot;
	}
}
