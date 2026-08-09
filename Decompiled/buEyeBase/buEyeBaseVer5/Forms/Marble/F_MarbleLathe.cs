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

public class F_MarbleLathe : Form
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

	public buCheckBox chk_maxtomin;

	public buSpin spn_plungespeed;

	public buSpin spn_cutspeed;

	internal buGround buGround_0;

	internal buButton buButton_0;

	public buCheckBox chk_midtoright;

	public buCheckBox chk_midtoleft;

	public buCheckBox chk_mintomax;

	public buSpin spn_radiustopdistance;

	internal buSeparator buSeparator_0;

	public buCheckBox chk_caxisfollowdirection;

	public buLabel lbl_direction;

	public F_MarbleLathe()
	{
		Class186.smethod_580(this);
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
		chk_maxtomin.Check = false;
		chk_midtoleft.Check = false;
		chk_midtoright.Check = false;
		chk_mintomax.Check = false;
		if (varSettings.settingLatheCut.LatheDirection != MarbleLatheDirection.MaxToMin)
		{
			if (varSettings.settingLatheCut.LatheDirection != MarbleLatheDirection.MinToMax)
			{
				if (varSettings.settingLatheCut.LatheDirection != MarbleLatheDirection.MidToLeftThenRight)
				{
					chk_midtoright.Check = true;
				}
				else
				{
					chk_midtoleft.Check = true;
				}
			}
			else
			{
				chk_mintomax.Check = true;
			}
		}
		else
		{
			chk_maxtomin.Check = true;
		}
		spn_cutspeed.Value = varSettings.settingLatheCut.LatheCutFeed;
		spn_plungespeed.Value = varSettings.settingLatheCut.LathePlungeFeed;
		spn_safedistance.Value = varSettings.settingLatheCut.LatheSafeDistance;
		spn_radiustopdistance.Value = varSettings.settingLatheCut.LatheRadiusTopDistance;
		chk_caxisfollowdirection.Check = varSettings.settingLatheCut.LatheCAxisFollowDirection;
		Class186.smethod_565(this);
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
				Class186.smethod_442(this);
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

	internal void method_3(object object_0, bool bool_0)
	{
	}

	internal void method_4(object sender, EventArgs e)
	{
		buCheckBox buCheckBox2 = sender as buCheckBox;
		chk_maxtomin.Check = false;
		chk_midtoleft.Check = false;
		chk_midtoright.Check = false;
		chk_mintomax.Check = false;
		buCheckBox2.Check = true;
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
