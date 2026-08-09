using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit;

public class TabItemEventArgs : RoutedEventArgs
{
	public TabItem TabItem { get; private set; }

	public TabItemEventArgs(TabItem tabItem)
	{
		TabItem = tabItem;
	}
}
