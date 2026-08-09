using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorColorPicker : ColorPicker
{
	static PropertyGridEditorColorPicker()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorColorPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorColorPicker)));
	}
}
