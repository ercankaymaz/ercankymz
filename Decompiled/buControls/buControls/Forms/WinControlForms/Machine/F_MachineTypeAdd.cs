using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Machine;

public class F_MachineTypeAdd : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public MachineType Machine = new MachineType();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal Label label_1;

	internal TextBox textBox_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	public F_MachineTypeAdd()
	{
		Class76.smethod_606(this);
	}

	public void Init()
	{
		Result = DialogResult.Cancel;
		numericUpDown_0.Value = Machine.ID;
		numericUpDown_1.Value = Machine.ToolCount;
		textBox_0.Text = Machine.Name;
		Class76.smethod_178(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Result != DialogResult.OK)
		{
			e.Cancel = true;
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.OK;
		Machine.ID = Convert.ToInt32(numericUpDown_0.Value);
		Machine.ToolCount = Convert.ToInt32(numericUpDown_1.Value);
		Machine.Name = textBox_0.Text;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
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
