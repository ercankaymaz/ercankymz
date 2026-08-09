using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Diemaker;

public class F_BridgeProps : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public double BridgeHeight = 15.0;

	public Color colorActive = Color.DarkGray;

	public Color colorPassive = Color.WhiteSmoke;

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Button button_0;

	internal Label label_0;

	internal Button button_1;

	internal Button button_2;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public F_BridgeProps()
	{
		Class76.smethod_623(this);
	}

	public void Init()
	{
		Result = DialogResult.None;
		button_0.BackColor = colorPassive;
		button_2.BackColor = colorPassive;
		button_1.BackColor = colorPassive;
		if (BridgeHeight <= 12.0)
		{
			button_0.BackColor = colorActive;
		}
		if ((BridgeHeight > 12.0) & (BridgeHeight <= 15.0))
		{
			button_2.BackColor = colorActive;
		}
		if (BridgeHeight > 15.0)
		{
			button_1.BackColor = colorActive;
		}
		Class76.smethod_556(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
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

	internal void method_1(object sender, EventArgs e)
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

	internal void method_2(object sender, EventArgs e)
	{
		button_0.BackColor = colorActive;
		button_2.BackColor = colorPassive;
		button_1.BackColor = colorPassive;
		BridgeHeight = 12.0;
	}

	internal void method_3(object sender, EventArgs e)
	{
		button_0.BackColor = colorPassive;
		button_2.BackColor = colorActive;
		button_1.BackColor = colorPassive;
		BridgeHeight = 15.0;
	}

	internal void method_4(object sender, EventArgs e)
	{
		button_0.BackColor = colorPassive;
		button_2.BackColor = colorPassive;
		button_1.BackColor = colorActive;
		BridgeHeight = 18.0;
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
