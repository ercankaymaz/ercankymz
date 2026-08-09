using System.ComponentModel;

namespace Xceed.Wpf.Toolkit.Primitives;

public class ItemSelectionChangingEventArgs : CancelEventArgs
{
	public bool NewIsSelected { get; private set; }

	public object Item { get; private set; }

	public ItemSelectionChangingEventArgs(object item, bool isSelected)
	{
		Item = item;
		NewIsSelected = isSelected;
	}
}
