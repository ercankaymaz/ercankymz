using System.ComponentModel;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class DoubleUpDownEditor : NumericUpDownEditor<DoubleUpDown, double?>
{
	protected override DoubleUpDown CreateEditor()
	{
		return new PropertyGridEditorDoubleUpDown();
	}

	protected override void SetControlProperties(PropertyItem propertyItem)
	{
		base.SetControlProperties(propertyItem);
		base.Editor.AllowInputSpecialValues = AllowedSpecialValues.Any;
		SetMinMaxFromRangeAttribute(propertyItem.PropertyDescriptor, TypeDescriptor.GetConverter(typeof(double)));
	}
}
