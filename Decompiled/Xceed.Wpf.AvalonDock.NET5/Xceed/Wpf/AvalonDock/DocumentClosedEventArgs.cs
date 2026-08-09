using System;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock;

public class DocumentClosedEventArgs : EventArgs
{
	public LayoutDocument Document { get; private set; }

	public DocumentClosedEventArgs(LayoutDocument document)
	{
		Document = document;
	}
}
