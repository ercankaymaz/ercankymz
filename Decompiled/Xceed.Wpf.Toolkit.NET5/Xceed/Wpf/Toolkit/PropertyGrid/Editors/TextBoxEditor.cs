using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class TextBoxEditor : TypeEditor<WatermarkTextBox>
{
	protected override WatermarkTextBox CreateEditor()
	{
		return new PropertyGridEditorTextBox();
	}

	protected override void SetControlProperties(PropertyItem propertyItem)
	{
		DisplayAttribute attribute = PropertyGridUtilities.GetAttribute<DisplayAttribute>(propertyItem.PropertyDescriptor);
		if (attribute != null)
		{
			base.Editor.Watermark = attribute.GetPrompt();
		}
	}

	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = TextBox.TextProperty;
	}
}
