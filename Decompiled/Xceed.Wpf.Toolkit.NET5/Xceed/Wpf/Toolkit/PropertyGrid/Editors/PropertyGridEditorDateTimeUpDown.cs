using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorDateTimeUpDown : DateTimeUpDown
{
	static PropertyGridEditorDateTimeUpDown()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorDateTimeUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorDateTimeUpDown)));
	}
}
