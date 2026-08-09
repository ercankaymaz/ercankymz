using System.ComponentModel;

namespace Xceed.Wpf.AvalonDock.Layout.Serialization;

public class LayoutSerializationCallbackEventArgs : CancelEventArgs
{
	public LayoutContent Model { get; private set; }

	public object Content { get; set; }

	public LayoutSerializationCallbackEventArgs(LayoutContent model, object previousContent)
	{
		base.Cancel = false;
		Model = model;
		Content = previousContent;
	}
}
