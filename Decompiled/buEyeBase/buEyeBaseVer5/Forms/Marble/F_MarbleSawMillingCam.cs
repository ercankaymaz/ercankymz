using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawMillingCam : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleSawMillingPars varSettings = new marbleSawMillingPars();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_finishsurfoffset;

	public buSpin spn_finishzdownstep;

	public buSpin spn_finishstepang;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buSpin spn_finishzsafedis;

	public buCheckBox chk_finishzigzag;

	public buSpin spn_finishapproachdis;

	internal buTab buTab_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	public buSpin spn_roughzsafedis;

	public buSpin spn_roughapproachsafe;

	public buSpin spn_roughsurfoffset;

	public buCheckBox chk_rougjzigzag;

	public buSpin spn_roughtopoffset;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	public buSpin spn_finishbwdcuttingfeed;

	public buSpin spn_finishfwdcutfeed;

	public buSpin spn_finishplungefeed;

	public buSpin spn_roughbwdcuttingfeed;

	public buSpin spn_roughfwdcuttingfeed;

	public buSpin spn_roughplungefeed;

	public buSpin spn_roughbottomoffset;

	public buCheckBox chk_finishreverseC;

	public buCheckBox chk_roughreverseC;

	public buSpin spn_finishbottomoffset;

	public buSpin spn_finishtopoffet;

	public buSpin spn_roughzdownstep;

	public buSpin spn_roughstepoverXY;

	internal buLabel buLabel_2;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal TabPage tabPage_2;

	internal buLabel buLabel_3;

	public buSpin spn_offsetedgeoffsey;

	public buCheckBox chk_offsetcutedges;

	public buCheckBox chk_offsetcutoutside;

	public buCheckBox chk_offsetcutinside;

	public buSpin spn_offsetzdownstep;

	public buSpin spn_offsetoutsideoffset;

	public buSpin spn_offsetinsideoffset;

	public buCheckBox chk_offsetreverseC;

	public buSpin spn_offsetleadoutangle;

	public buSpin spn_offsetleadinangle;

	public buSpin spn_offsetbackwardcuttingspeed;

	public buSpin spn_offsetforwardcuttingspeed;

	public buSpin spn_offsetplungefeed;

	public buSpin spn_offsetsafedistance;

	public buSpin spn_offsetstepangle;

	public buSpin spn_offsetminZHeight;

	public buCheckBox chk_offsetzigzag;

	public buSpin spn_offsetAAngle;

	public buCheckBox chk_finishmoveupsafe;

	internal buPanel buPanel_0;

	internal buPanel buPanel_1;

	public buButton btn_closeadvanced;

	public buButton btn_color;

	public buSpin spn_singlelayerdepth;

	public buCheckBox chk_singlelayer;

	public buCheckBox chk_splinenebale;

	public buSpin spn_resolution;

	internal buLabel buLabel_4;

	public buSpin spn_curvedegree;

	public buButton btn_advanced;

	public F_MarbleSawMillingCam()
	{
		Class186.smethod_264(this);
	}

	public void Init(MarbleCamType CamType)
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		PropertiesForm.Result = DialogResult.None;
		if (CamType != MarbleCamType.SawMillingVerticalFinish)
		{
			if (CamType != MarbleCamType.SawMillingVerticalRough)
			{
				buTab_0.SelectedIndex = 0;
				buTab_0.ItemSize = new Size(120, 30);
			}
			else
			{
				buTab_0.SelectedIndex = 1;
				buTab_0.ItemSize = new Size(1, 1);
			}
		}
		else
		{
			buTab_0.SelectedIndex = 0;
			buTab_0.ItemSize = new Size(1, 1);
		}
		spn_finishzsafedis.Value = varSettings.SawMillingFinishVerSafeDistance;
		spn_finishsurfoffset.Value = varSettings.SawMillingFinishVerSurfaceOffset;
		spn_finishstepang.Value = varSettings.SawMillingFinishVerAngleStep;
		spn_finishapproachdis.Value = varSettings.SawMillingFinishVerApproach;
		spn_finishplungefeed.Value = varSettings.SawMillingFinishVerPlungeFeed;
		spn_finishfwdcutfeed.Value = varSettings.SawMillingFinishVerForwardCuttingFeed;
		spn_finishzdownstep.Value = varSettings.SawMillingFinishVerZDownStep;
		spn_finishbwdcuttingfeed.Value = varSettings.SawMillingFinishVerBackwardCuttingFeed;
		spn_finishtopoffet.Value = varSettings.SawMillingFinishVerTopOffset;
		spn_finishbottomoffset.Value = varSettings.SawMillingFinishVerBottomOffset;
		chk_finishzigzag.Check = varSettings.SawMillingFinishVerZigzag;
		chk_finishreverseC.Check = varSettings.SawMillingFinishVerReverseC;
		spn_roughzsafedis.Value = varSettings.SawMillingRoughVerSafeDistance;
		spn_roughsurfoffset.Value = varSettings.SawMillingRoughVerSurfaceOffset;
		spn_roughtopoffset.Value = varSettings.SawMillingRoughVerTopOffset;
		spn_roughapproachsafe.Value = varSettings.SawMillingRoughVerApproach;
		spn_roughplungefeed.Value = varSettings.SawMillingRoughVerPlungeFeed;
		spn_roughfwdcuttingfeed.Value = varSettings.SawMillingRoughVerForwardCuttingFeed;
		spn_roughbwdcuttingfeed.Value = varSettings.SawMillingRoughVerBackwardCuttingFeed;
		spn_roughbottomoffset.Value = varSettings.SawMillingRoughVerBottomOffset;
		spn_roughzdownstep.Value = varSettings.SawMillingRoughVerZDownStep;
		spn_roughstepoverXY.Value = varSettings.SawMillingRoughVerXYOffset;
		chk_rougjzigzag.Check = varSettings.SawMillingRoughVerZigzag;
		chk_roughreverseC.Check = varSettings.SawMillingRoughVerReverseC;
		if (varSettings.SawMillingRoughVerAreaMode == MarbleCamAreaMode.Region)
		{
			radioButton_0.Checked = true;
		}
		if (varSettings.SawMillingRoughVerAreaMode == MarbleCamAreaMode.Level)
		{
			radioButton_1.Checked = true;
		}
		if (CamType == MarbleCamType.SawMillingVerticalRough)
		{
			spn_curvedegree.Value = varSettings.SawMillingRoughVerCurvatureDegree;
			spn_resolution.Value = varSettings.SawMillingRoughVerCutTolerance;
			chk_splinenebale.Check = varSettings.SawMillingRoughVerSplineEnable;
			chk_singlelayer.Check = varSettings.SawMillingRoughVerUseSingleLayer;
			spn_singlelayerdepth.Value = varSettings.SawMillingRoughVerSingleLayerDepth;
		}
		btn_color.Display.BackColor = varSettings.SawMillingCamColor;
		btn_color.ButtonDownDisplay.BackColor = varSettings.SawMillingCamColor;
		btn_color.ButtonOverDisplay.BackColor = varSettings.SawMillingCamColor;
		Class186.smethod_709(this);
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
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
				Class186.smethod_679(this);
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if ((control.Name == btn_cancel.Name) | (control.Name == buButton_0.Name))
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if (control.Name == btn_advanced.Name)
			{
				if (buPanel_1.Visible)
				{
					buPanel_1.Visible = false;
				}
				else
				{
					buPanel_1.Visible = true;
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
