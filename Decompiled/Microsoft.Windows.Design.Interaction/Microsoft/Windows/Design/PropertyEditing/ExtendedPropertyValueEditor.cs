using System.Windows;

namespace Microsoft.Windows.Design.PropertyEditing;

public class ExtendedPropertyValueEditor : PropertyValueEditor
{
	private DataTemplate _extendedEditorTemplate;

	public DataTemplate ExtendedEditorTemplate
	{
		get
		{
			return _extendedEditorTemplate;
		}
		set
		{
			_extendedEditorTemplate = value;
		}
	}

	public ExtendedPropertyValueEditor()
		: this(null, null)
	{
	}

	public ExtendedPropertyValueEditor(DataTemplate extendedEditorTemplate, DataTemplate inlineEditorTemplate)
		: base(inlineEditorTemplate)
	{
		_extendedEditorTemplate = extendedEditorTemplate;
	}

	internal override DataTemplate GetPropertyValueEditor(PropertyContainerEditMode mode)
	{
		DataTemplate obj = base.GetPropertyValueEditor(mode);
		if (obj == null)
		{
			if (mode != PropertyContainerEditMode.ExtendedPinned && mode != PropertyContainerEditMode.ExtendedPopup)
			{
				return null;
			}
			obj = _extendedEditorTemplate;
		}
		return obj;
	}
}
