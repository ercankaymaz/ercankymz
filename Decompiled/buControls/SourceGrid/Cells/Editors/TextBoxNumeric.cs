using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevAge.Windows.Forms;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TextBoxNumeric : TextBox
{
	public new DevAgeTextBox Control => base.Control;

	public TextBoxNumeric(Type p_Type)
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
}
