using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Diemaker;

public class F_RuleSettings : Form
{
	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public double RuleHeight = 15.0;

	public Color colorActive = Color.DarkGray;

	public Color colorPassive = Color.WhiteSmoke;

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public F_RuleSettings()
	{
		Class76.smethod_454(this);
	}

	public void Init()
	{
		Result = DialogResult.None;
		numericUpDown_0.Value = (decimal)RuleHeight;
		Class76.smethod_694(this);
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
		RuleHeight = (double)numericUpDown_0.Value;
		Result = DialogResult.OK;
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
