using System.ComponentModel;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class TextBlockEditor : TypeEditor<TextBlock>
{
	private TypeConverter _typeConverter;

	public TextBlockEditor()
	{
	}

	public TextBlockEditor(TypeConverter typeConverter)
	{
		_typeConverter = typeConverter;
	}

	protected override TextBlock CreateEditor()
	{
		return new PropertyGridEditorTextBlock();
	}

	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = TextBlock.TextProperty;
	}
}
