using System.ComponentModel;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock;

public class DocumentClosingEventArgs : CancelEventArgs
{
	public LayoutDocument Document { get; private set; }

	public DocumentClosingEventArgs(LayoutDocument document)
	{
		Document = document;
	}
}
