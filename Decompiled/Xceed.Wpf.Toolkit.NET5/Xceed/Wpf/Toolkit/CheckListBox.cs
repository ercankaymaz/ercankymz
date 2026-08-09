using System.Windows;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public class CheckListBox : SelectAllSelector
{
	static CheckListBox()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckListBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(CheckListBox)));
	}
}
