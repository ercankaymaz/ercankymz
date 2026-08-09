using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class CheckBoxEditor : TypeEditor<CheckBox>
{
	protected override CheckBox CreateEditor()
	{
		return new PropertyGridEditorCheckBox();
	}

	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = ToggleButton.IsCheckedProperty;
	}
}
