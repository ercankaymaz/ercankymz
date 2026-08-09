using System;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class MaskedTextBoxEditor : TypeEditor<MaskedTextBox>
{
	public string Mask { get; set; }

	public Type ValueDataType { get; set; }

	protected override MaskedTextBox CreateEditor()
	{
		return new PropertyGridEditorMaskedTextBox();
	}

	protected override void SetControlProperties(PropertyItem propertyItem)
	{
		base.Editor.ValueDataType = ValueDataType;
		base.Editor.Mask = Mask;
	}

	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = ValueRangeTextBox.ValueProperty;
	}
}
