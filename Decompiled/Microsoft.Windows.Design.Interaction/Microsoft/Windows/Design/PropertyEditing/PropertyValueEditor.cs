using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.PropertyEditing;

public class PropertyValueEditor
{
	private DataTemplate _inlineEditorTemplate;

	public DataTemplate InlineEditorTemplate
	{
		get
		{
			return _inlineEditorTemplate;
		}
		set
		{
			_inlineEditorTemplate = value;
		}
	}

	public PropertyValueEditor()
	{
	}

	public PropertyValueEditor(DataTemplate inlineEditorTemplate)
	{
		_inlineEditorTemplate = inlineEditorTemplate;
	}

	internal virtual DataTemplate GetPropertyValueEditor(PropertyContainerEditMode mode)
	{
		if (mode != PropertyContainerEditMode.Inline)
		{
			return null;
		}
		return _inlineEditorTemplate;
	}

	public static EditorAttribute CreateEditorAttribute(PropertyValueEditor editor)
	{
		if (editor == null)
		{
			throw new ArgumentNullException("editor");
		}
		return CreateEditorAttribute(editor.GetType());
	}

	public static EditorAttribute CreateEditorAttribute(Type propertyValueEditorType)
	{
		if ((object)propertyValueEditorType == null)
		{
			throw new ArgumentNullException("propertyValueEditorType");
		}
		if (!typeof(PropertyValueEditor).IsAssignableFrom(propertyValueEditorType))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ArgIncorrectType, new object[2]
			{
				"propertyValueEditorType",
				typeof(PropertyValueEditor).Name
			}));
		}
		return new EditorAttribute(propertyValueEditorType, typeof(PropertyValueEditor));
	}
}
