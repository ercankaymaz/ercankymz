using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using DevAge.Drawing;
using DevAge.Windows.Forms;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TextBoxUITypeEditor : TextBoxButton
{
	public new DevAge.Windows.Forms.TextBoxUITypeEditor Control => (DevAge.Windows.Forms.TextBoxUITypeEditor)base.Control;

	public TextBoxUITypeEditor(Type p_Type)
		: base(p_Type)
	{
	}

	protected override Control CreateControl()
	{
		DevAge.Windows.Forms.TextBoxUITypeEditor textBoxUITypeEditor = new DevAge.Windows.Forms.TextBoxUITypeEditor();
		textBoxUITypeEditor.BorderStyle = DevAge.Drawing.BorderStyle.None;
		textBoxUITypeEditor.Validator = this;
		object editor = TypeDescriptor.GetEditor(base.ValueType, typeof(UITypeEditor));
		UITypeEditor uITypeEditor = null;
		if (textBoxUITypeEditor != null)
		{
			uITypeEditor = (UITypeEditor)editor;
		}
		textBoxUITypeEditor.UITypeEditor = uITypeEditor;
		return textBoxUITypeEditor;
	}
}
