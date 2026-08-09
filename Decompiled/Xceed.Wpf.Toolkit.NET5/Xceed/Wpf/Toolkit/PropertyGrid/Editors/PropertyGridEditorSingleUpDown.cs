using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorSingleUpDown : SingleUpDown
{
	static PropertyGridEditorSingleUpDown()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorSingleUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorSingleUpDown)));
	}
}
