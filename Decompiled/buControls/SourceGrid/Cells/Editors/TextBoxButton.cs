using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevAge.Drawing;
using DevAge.Windows.Forms;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TextBoxButton : EditorControlBase
{
	public new DevAgeTextBoxButton Control => (DevAgeTextBoxButton)base.Control;

	public TextBoxButton(Type p_Type)
		: base(p_Type)
	{
	}

	protected override Control CreateControl()
	{
		DevAgeTextBoxButton devAgeTextBoxButton = new DevAgeTextBoxButton();
		devAgeTextBoxButton.BorderStyle = DevAge.Drawing.BorderStyle.None;
		devAgeTextBoxButton.Validator = this;
		return devAgeTextBoxButton;
	}

	protected override void OnStartingEdit(CellContext cellContext, Control editorControl)
	{
		base.OnStartingEdit(cellContext, editorControl);
		DevAgeTextBoxButton devAgeTextBoxButton = (DevAgeTextBoxButton)editorControl;
		devAgeTextBoxButton.TextBox.SelectionStart = 0;
		devAgeTextBoxButton.TextBox.SelectionLength = 0;
	}

	public override void SetEditValue(object editValue)
	{
		Control.Value = editValue;
		Control.TextBox.SelectAll();
	}

	public override object GetEditedValue()
	{
		return Control.Value;
	}

	protected override void OnSendCharToEditor(char key)
	{
		Control.TextBox.Text = key.ToString();
		if (Control.TextBox.Text != null)
		{
			Control.TextBox.SelectionStart = Control.TextBox.Text.Length;
		}
	}
}
