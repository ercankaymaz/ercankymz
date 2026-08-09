using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.Library;

public class F_LibraryProps : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public LibraryProps Properties = new LibraryProps();

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	internal TextBox textBox_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal TextBox textBox_1;

	internal Label label_2;

	public F_LibraryProps()
	{
		Class76.smethod_462(this);
	}

	public void Init(LibraryProps properties)
	{
		bool_0 = false;
		Result = DialogResult.None;
		bool_0 = true;
		Class76.smethod_222(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (bool_0)
		{
			Class76.smethod_81(this);
			Result = DialogResult.OK;
		}
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		Dispose();
	}

	internal void method_2(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(base.Controls, result, e.Shift);
		}
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
