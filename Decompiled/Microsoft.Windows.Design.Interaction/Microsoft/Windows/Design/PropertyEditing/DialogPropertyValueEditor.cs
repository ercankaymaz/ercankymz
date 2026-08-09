using System.Windows;

namespace Microsoft.Windows.Design.PropertyEditing;

public class DialogPropertyValueEditor : PropertyValueEditor
{
	private DataTemplate _dialogEditorTemplate;

	public DataTemplate DialogEditorTemplate
	{
		get
		{
			return _dialogEditorTemplate;
		}
		set
		{
			_dialogEditorTemplate = value;
		}
	}

	public DialogPropertyValueEditor()
		: this(null, null)
	{
	}

	public DialogPropertyValueEditor(DataTemplate dialogEditorTemplate, DataTemplate inlineEditorTemplate)
		: base(inlineEditorTemplate)
	{
		_dialogEditorTemplate = dialogEditorTemplate;
	}

	public virtual void ShowDialog(PropertyValue propertyValue, IInputElement commandSource)
	{
	}

	internal override DataTemplate GetPropertyValueEditor(PropertyContainerEditMode mode)
	{
		DataTemplate obj = base.GetPropertyValueEditor(mode);
		if (obj == null)
		{
			if (mode != PropertyContainerEditMode.Dialog)
			{
				return null;
			}
			obj = _dialogEditorTemplate;
		}
		return obj;
	}
}
