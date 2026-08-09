using System.ComponentModel;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class ByteUpDownEditor : NumericUpDownEditor<ByteUpDown, byte?>
{
	protected override ByteUpDown CreateEditor()
	{
		return new PropertyGridEditorByteUpDown();
	}

	protected override void SetControlProperties(PropertyItem propertyItem)
	{
		base.SetControlProperties(propertyItem);
		SetMinMaxFromRangeAttribute(propertyItem.PropertyDescriptor, TypeDescriptor.GetConverter(typeof(byte)));
	}
}
