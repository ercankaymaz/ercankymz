using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.DialogBox;

public class DialogBoxMultiText : Form
{
	public string Caption = "Data";

	public DialogResult Result = DialogResult.None;

	public string Value = "";

	private IContainer icontainer_0 = null;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_0;

	internal TextBox textBox_0;

	internal ImageList imageList_0;

	public DialogBoxMultiText()
	{
		Class76.smethod_707(this);
	}

	public void Init(string Text)
	{
		Value = Text;
		label_0.Text = Caption;
		textBox_0.Text = Text;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Value = textBox_0.Text;
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		Dispose();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
