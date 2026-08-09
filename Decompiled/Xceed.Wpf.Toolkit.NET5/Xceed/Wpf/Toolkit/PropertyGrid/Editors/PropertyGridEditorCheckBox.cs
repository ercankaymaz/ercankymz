using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorCheckBox : CheckBox
{
	static PropertyGridEditorCheckBox()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorCheckBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorCheckBox)));
	}
}
