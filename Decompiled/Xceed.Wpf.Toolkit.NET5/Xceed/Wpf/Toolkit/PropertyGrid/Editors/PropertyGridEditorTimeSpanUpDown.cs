using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorTimeSpanUpDown : TimeSpanUpDown
{
	static PropertyGridEditorTimeSpanUpDown()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorTimeSpanUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorTimeSpanUpDown)));
	}
}
