using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorComboBox : ComboBox
{
	static PropertyGridEditorComboBox()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorComboBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorComboBox)));
	}
}
