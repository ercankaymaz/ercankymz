using System;

namespace Xceed.Wpf.AvalonDock.Layout;

public class ChildrenTreeChangedEventArgs : EventArgs
{
	public ChildrenTreeChange Change { get; private set; }

	public ChildrenTreeChangedEventArgs(ChildrenTreeChange change)
	{
		Change = change;
	}
}
