using System.ComponentModel;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class IntegerUpDownEditor : NumericUpDownEditor<IntegerUpDown, int?>
{
	protected override IntegerUpDown CreateEditor()
	{
		return new PropertyGridEditorIntegerUpDown();
	}

	protected override void SetControlProperties(PropertyItem propertyItem)
	{
		base.SetControlProperties(propertyItem);
		SetMinMaxFromRangeAttribute(propertyItem.PropertyDescriptor, TypeDescriptor.GetConverter(typeof(int)));
	}
}
