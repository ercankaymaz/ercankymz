using System.Windows.Controls;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutCachePaneControl : TabControl
{
	static LayoutCachePaneControl()
	{
	}

	protected override void OnSelectionChanged(SelectionChangedEventArgs e)
	{
		if (base.SelectedIndex < 0)
		{
			e.Handled = true;
		}
		base.OnSelectionChanged(e);
	}
}
