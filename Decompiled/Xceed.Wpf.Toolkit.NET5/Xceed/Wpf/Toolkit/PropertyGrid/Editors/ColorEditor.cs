namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class ColorEditor : TypeEditor<ColorPicker>
{
	protected override ColorPicker CreateEditor()
	{
		return new PropertyGridEditorColorPicker();
	}

	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = ColorPicker.SelectedColorProperty;
	}
}
