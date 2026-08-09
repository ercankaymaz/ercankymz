using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorDecimalUpDown : DecimalUpDown
{
	static PropertyGridEditorDecimalUpDown()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorDecimalUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorDecimalUpDown)));
	}
}
