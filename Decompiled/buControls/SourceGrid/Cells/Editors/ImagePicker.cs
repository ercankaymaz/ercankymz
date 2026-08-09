using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevAge.ComponentModel.Validator;
using DevAge.Drawing;
using DevAge.Windows.Forms;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class ImagePicker : EditorControlBase
{
	public static readonly ImagePicker Default = new ImagePicker();

	public new DevAge.Windows.Forms.TextBoxUITypeEditor Control => (DevAge.Windows.Forms.TextBoxUITypeEditor)base.Control;

	public ImagePicker()
		: base(typeof(byte[]))
	{
	}

	protected override Control CreateControl()
	{
		DevAge.Windows.Forms.TextBoxUITypeEditor textBoxUITypeEditor = new DevAge.Windows.Forms.TextBoxUITypeEditor();
		textBoxUITypeEditor.BorderStyle = DevAge.Drawing.BorderStyle.None;
		textBoxUITypeEditor.Validator = new ValidatorTypeConverter(typeof(System.Drawing.Image));
		return textBoxUITypeEditor;
	}

	public override object GetEditedValue()
	{
		object value = Control.Value;
		if (value != null)
		{
			if (!(value is System.Drawing.Image))
			{
				if (!(value is byte[]))
				{
					throw new SourceGridException("Invalid edited value, expected byte[] or Image");
				}
				return value;
			}
			ValidatorTypeConverter validatorTypeConverter = new ValidatorTypeConverter(typeof(System.Drawing.Image));
			return validatorTypeConverter.ValueToObject(value, typeof(byte[]));
		}
		return null;
	}

	public override void SetEditValue(object editValue)
	{
		Control.Value = editValue;
		Control.TextBox.SelectAll();
	}

	public override string ValueToDisplayString(object p_Value)
	{
		return null;
	}

	protected override void OnSendCharToEditor(char key)
	{
	}
}
