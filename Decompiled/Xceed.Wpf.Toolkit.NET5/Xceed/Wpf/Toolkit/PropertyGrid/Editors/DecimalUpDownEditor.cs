using System.ComponentModel;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class DecimalUpDownEditor : NumericUpDownEditor<DecimalUpDown, decimal?>
{
	protected override DecimalUpDown CreateEditor()
	{
		return new PropertyGridEditorDecimalUpDown();
	}

	protected override void SetControlProperties(PropertyItem propertyItem)
	{
		base.SetControlProperties(propertyItem);
		SetMinMaxFromRangeAttribute(propertyItem.PropertyDescriptor, TypeDescriptor.GetConverter(typeof(decimal)));
	}
}
