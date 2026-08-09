using System;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms.Dialog;

public class F_DialogYesNo : Form
{
	public string Caption = "";

	public string Message = "";

	public DialogResult Result = DialogResult.None;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buLabel buLabel_0;

	internal buButton buButton_1;

	public F_DialogYesNo()
	{
		Class76.smethod_685(this);
	}

	public void ShowDialog(string message, string caption = "")
	{
		Text = Caption;
		buGround_0.Text = Caption;
		if (caption.Length > 0)
		{
			Text = caption;
			buGround_0.Text = caption;
		}
		buLabel_0.Text = message;
		ShowDialog();
	}

	public void ShowDialog(string message, IWin32Window owner, string caption = "")
	{
		Text = Caption;
		buGround_0.Text = Caption;
		if (caption.Length > 0)
		{
			Text = caption;
			buGround_0.Text = caption;
		}
		buLabel_0.Text = message;
		ShowDialog(owner);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buButton_0.Name)
		{
			Result = DialogResult.Yes;
		}
		if (control.Name == buButton_1.Name)
		{
			Result = DialogResult.No;
		}
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
