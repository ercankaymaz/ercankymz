using System.ComponentModel;
using System.Windows.Forms;
using DevAge.ComponentModel.Converter;
using DevAge.Windows.Forms;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class RichTextBox : EditorControlBase
{
	public new DevAgeRichTextBox Control => (DevAgeRichTextBox)base.Control;

	public RichTextBox()
		: base(typeof(RichText))
	{
		base.TypeConverter = new RichTextTypeConverter();
	}

	protected override Control CreateControl()
	{
		DevAgeRichTextBox devAgeRichTextBox = new DevAgeRichTextBox();
		devAgeRichTextBox.BorderStyle = BorderStyle.None;
		devAgeRichTextBox.AutoSize = false;
		devAgeRichTextBox.Validator = this;
		return devAgeRichTextBox;
	}

	protected override void OnStartingEdit(CellContext cellContext, Control editorControl)
	{
		base.OnStartingEdit(cellContext, editorControl);
		DevAgeRichTextBox devAgeRichTextBox = (DevAgeRichTextBox)editorControl;
		devAgeRichTextBox.WordWrap = cellContext.Cell.View.WordWrap;
		devAgeRichTextBox.SelectionStart = 0;
		devAgeRichTextBox.SelectionLength = 0;
	}

	public override void SetEditValue(object editValue)
	{
		Control.Value = editValue as RichText;
		Control.SelectAll();
	}

	public override object GetEditedValue()
	{
		return Control.Value;
	}

	protected override void OnSendCharToEditor(char key)
	{
		Control.Text = key.ToString();
		if (Control.Text != null)
		{
			Control.SelectionStart = Control.Text.Length;
		}
	}
}
