using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorEnumCheckComboBox : CheckComboBox
{
	static PropertyGridEditorEnumCheckComboBox()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorEnumCheckComboBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorEnumCheckComboBox)));
	}
}
