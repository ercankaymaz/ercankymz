using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleColumns : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MarbleItemSettings varSettings = new MarbleItemSettings();

	public string strMessageRoughtFinish = "Rought and  Finish Both Can't be Enabled";

	public string strMessageRoughtFinishSelect = "Rought or Finish One of them must be Selected";

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public buSpin spn_safedistance;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buSpin spn_plungespeed;

	public buSpin spn_cutspeed;

	internal buGround buGround_0;

	internal buButton buButton_0;

	public buSpin spn_radiustopdistance;

	public buSpin spn_baseheight;

	public buSpin spn_zstep;

	public buCheckBox chk_zigzag;

	public F_MarbleColumns()
	{
		Class186.smethod_584(this);
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
		spn_cutspeed.Value = varSettings.settingColoumnsCut.ColoumsCutFeed;
		spn_plungespeed.Value = varSettings.settingColoumnsCut.ColoumsPlungeFeed;
		spn_safedistance.Value = varSettings.settingColoumnsCut.ColoumsSafeDistance;
		spn_radiustopdistance.Value = varSettings.settingColoumnsCut.ColoumsRadiusTopDistance;
		spn_baseheight.Value = varSettings.settingColoumnsCut.ColoumsBaseHeight;
		spn_zstep.Value = varSettings.settingColoumnsCut.ColoumsZStep;
		chk_zigzag.Check = varSettings.settingColoumnsCut.ColoumsZigzagMode;
		Class186.smethod_554(this);
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
				Class186.smethod_573(this);
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
			if (control.Name == btn_cancel.Name)
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
		try
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
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
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
