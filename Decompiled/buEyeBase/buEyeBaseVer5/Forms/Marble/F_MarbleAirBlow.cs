using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleAirBlow : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleAirDryPars varAirDry = new marbleAirDryPars();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buSpin spn_airblowheight;

	public buCheckBox chk_onlyparts;

	public buCheckBox chk_allblock;

	public buCheckBox chk_vertical;

	public buCheckBox chk_horizontal;

	public buSpin spn_stepdistance;

	public buSpin spn_rapiddistance;

	public F_MarbleAirBlow()
	{
		Class186.smethod_104(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		spn_airblowheight.Value = varAirDry.Height;
		spn_stepdistance.Value = varAirDry.StepDistance;
		spn_rapiddistance.Value = varAirDry.RapidDistance;
		if (varAirDry.PartType == MarbleAirDryPartType.Block)
		{
			chk_onlyparts.Check = false;
			chk_allblock.Check = true;
		}
		if (varAirDry.PartType == MarbleAirDryPartType.OnlyPart)
		{
			chk_onlyparts.Check = true;
			chk_allblock.Check = false;
		}
		if (varAirDry.Direction == HorizontalVertical.Horizontal)
		{
			chk_horizontal.Check = true;
			chk_vertical.Check = false;
		}
		if (varAirDry.Direction == HorizontalVertical.Vertical)
		{
			chk_horizontal.Check = false;
			chk_vertical.Check = true;
		}
		Class186.smethod_659(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_ok.Name)
			{
				Class186.smethod_725(this);
				Properties.Result = DialogResult.OK;
				if (Properties.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (Properties.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if ((control.Name == btn_cancel.Name) | (control.Name == buButton_0.Name))
			{
				Properties.Result = DialogResult.Cancel;
				if (Properties.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (Properties.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
	}

	internal void method_3(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
			f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
			if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
			{
				buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
			}
		}
	}

	internal void method_4(object object_0, bool bool_0)
	{
		if (!Properties.Inited)
		{
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (Properties.Inited)
		{
			buCheckBox buCheckBox2 = sender as buCheckBox;
			if (buCheckBox2.Name == chk_allblock.Name)
			{
				chk_allblock.Check = true;
				chk_onlyparts.Check = false;
			}
			if (buCheckBox2.Name == chk_onlyparts.Name)
			{
				chk_allblock.Check = false;
				chk_onlyparts.Check = true;
			}
			if (buCheckBox2.Name == chk_horizontal.Name)
			{
				chk_horizontal.Check = true;
				chk_vertical.Check = false;
			}
			if (buCheckBox2.Name == chk_vertical.Name)
			{
				chk_horizontal.Check = false;
				chk_vertical.Check = true;
			}
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
