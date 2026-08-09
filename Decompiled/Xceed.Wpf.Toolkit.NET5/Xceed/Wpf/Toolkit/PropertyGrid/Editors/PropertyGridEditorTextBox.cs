using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorTextBox : WatermarkTextBox
{
	static PropertyGridEditorTextBox()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorTextBox)));
	}
}
