using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevAge.Windows.Forms;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TextBox : EditorControlBase
{
	public new DevAgeTextBox Control => (DevAgeTextBox)base.Control;

	public TextBox(Type p_Type)
		: base(p_Type)
	{
	}

	protected override Control CreateControl()
	{
		DevAgeTextBox devAgeTextBox = new DevAgeTextBox();
		devAgeTextBox.BorderStyle = BorderStyle.None;
		devAgeTextBox.AutoSize = false;
		devAgeTextBox.Validator = this;
		return devAgeTextBox;
	}

	protected override void OnStartingEdit(CellContext cellContext, Control editorControl)
	{
		base.OnStartingEdit(cellContext, editorControl);
		DevAgeTextBox devAgeTextBox = (DevAgeTextBox)editorControl;
		devAgeTextBox.WordWrap = cellContext.Cell.View.WordWrap;
		devAgeTextBox.TextAlign = Utilities.ContentToHorizontalAlignment(cellContext.Cell.View.TextAlignment);
		devAgeTextBox.SelectionStart = 0;
		devAgeTextBox.SelectionLength = 0;
	}

	public override void SetEditValue(object editValue)
	{
		Control.Value = editValue;
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
