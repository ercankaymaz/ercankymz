using System.Windows.Controls;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PasswordEditor : TypeEditor<WatermarkPasswordBox>
{
	protected override WatermarkPasswordBox CreateEditor()
	{
		return new PropertyGridEditorWatermarkPasswordBox();
	}

	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = TextBox.TextProperty;
	}

	protected override IValueConverter CreateValueConverter()
	{
		return new PasswordToStringConverter(base.Editor);
	}
}
