using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorTextBlock : TextBlock
{
	static PropertyGridEditorTextBlock()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorTextBlock)));
	}
}
