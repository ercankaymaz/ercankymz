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

public class F_MarbleProfileCurveCam : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleProfileCurveCutPars varProfileCurveCut = new marbleProfileCurveCutPars();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_finishsurfoffset;

	public buSpin spn_finishminZ;

	public buSpin spn_finishstepang;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buSpin spn_finishsafedis;

	public buCheckBox chk_finishzigzag;

	public buSpin spn_finishrapiddis;

	internal buTab buTab_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	public buSpin spn_roughsafedis;

	public buSpin spn_roughrapiddis;

	public buSpin spn_roughsurfoffset;

	public buCheckBox chk_rougjzigzag;

	public buSpin spn_roughstepang;

	public buSpin spn_roughminZ;

	public buSpin spn_finishcoffset;

	public buSpin spn_roughcoffset;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	public buCheckBox chk_finishperpendicularA;

	public buSpin spn_finishbwdcuttingfeed;

	public buSpin spn_finishfwdcutfeed;

	public buSpin spn_finishplungefeed;

	public buCheckBox chk_roughperpendicularA;

	public buSpin spn_roughbwdcuttingfeed;

	public buSpin spn_roughfwdcuttingfeed;

	public buSpin spn_roughplungefeed;

	public buSpin spn_roughleadout;

	public buSpin spn_roughleadin;

	public buSpin spn_finishleadout;

	public buSpin spn_finishleadin;

	public buSpin spn_finishverticaldevidedis;

	public buSpin spn_roughverticaldevidelen;

	public buCheckBox chk_finishreverseC;

	public buCheckBox chk_roughreverseC;

	public buSpin spn_roughtopoffet;

	public buSpin spn_roughoutsideoffset;

	public buSpin spn_roughinsideoffset;

	public buSpin spn_roughbottomoffset;

	public buSpin spn_finishoutsideoffset;

	public buSpin spn_finishinsideoffset;

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

	public F_MarbleProfileCurveCam()
	{
		Class186.smethod_17(this);
	}

	public void Init(int CamIndex)
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
		if (CamIndex != 0)
		{
			if (CamIndex != 1)
			{
				if (CamIndex != 2)
				{
					buTab_0.SelectedIndex = 0;
					buTab_0.ItemSize = new Size(120, 30);
				}
				else
				{
					buTab_0.SelectedIndex = 2;
					buTab_0.ItemSize = new Size(1, 1);
				}
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
		spn_finishcoffset.Value = varProfileCurveCut.FinishCOffsetAngle;
		spn_finishsafedis.Value = varProfileCurveCut.FinishSafeDis;
		spn_finishsurfoffset.Value = varProfileCurveCut.FinishSurfOffset;
		spn_finishstepang.Value = varProfileCurveCut.FinishAngleStep;
		spn_finishminZ.Value = varProfileCurveCut.FinishMinZ;
		spn_finishrapiddis.Value = varProfileCurveCut.FinishRapid;
		spn_finishplungefeed.Value = varProfileCurveCut.FinishPlungeFeed;
		spn_finishfwdcutfeed.Value = varProfileCurveCut.FinishCutForwardFeed;
		spn_finishbwdcuttingfeed.Value = varProfileCurveCut.FinishCutBackwardFeed;
		spn_finishverticaldevidedis.Value = varProfileCurveCut.FinishVerticalDevideLen;
		spn_finishleadin.Value = varProfileCurveCut.FinishLeadInAngle;
		spn_finishleadout.Value = varProfileCurveCut.FinishLeadOutAngle;
		chk_finishzigzag.Check = varProfileCurveCut.FinishZigzagMode;
		chk_finishperpendicularA.Check = varProfileCurveCut.FinishPerpendicularA;
		chk_finishreverseC.Check = varProfileCurveCut.FinishReverseCAngle;
		chk_finishmoveupsafe.Check = varProfileCurveCut.FinishMoveUpSafe;
		spn_finishtopoffet.Value = varProfileCurveCut.FinishTopOffset;
		spn_finishbottomoffset.Value = varProfileCurveCut.FinishBottomOffset;
		spn_finishinsideoffset.Value = varProfileCurveCut.FinishInsideOffset;
		spn_finishoutsideoffset.Value = varProfileCurveCut.FinishOutsideOffset;
		spn_roughcoffset.Value = varProfileCurveCut.RoughCOffsetAngle;
		spn_roughsafedis.Value = varProfileCurveCut.RoughSafeDis;
		spn_roughsurfoffset.Value = varProfileCurveCut.RoughSurfOffset;
		spn_roughstepang.Value = varProfileCurveCut.RoughAngleStep;
		spn_roughminZ.Value = varProfileCurveCut.RoughMinZ;
		spn_roughrapiddis.Value = varProfileCurveCut.RoughRapid;
		spn_roughplungefeed.Value = varProfileCurveCut.RoughPlungeFeed;
		spn_roughfwdcuttingfeed.Value = varProfileCurveCut.RoughCutBackwardFeed;
		spn_roughbwdcuttingfeed.Value = varProfileCurveCut.RoughCutBackwardFeed;
		spn_roughverticaldevidelen.Value = varProfileCurveCut.RoughVerticalDevideLen;
		spn_roughleadin.Value = varProfileCurveCut.RoughLeadInAngle;
		spn_roughleadout.Value = varProfileCurveCut.RoughLeadOutAngle;
		spn_roughtopoffet.Value = varProfileCurveCut.RoughTopOffset;
		spn_roughbottomoffset.Value = varProfileCurveCut.RoughBottomOffset;
		spn_roughinsideoffset.Value = varProfileCurveCut.RoughInsideOffset;
		spn_roughoutsideoffset.Value = varProfileCurveCut.RoughOutsideOffset;
		spn_roughzdownstep.Value = varProfileCurveCut.RoughZForwardDownStep;
		spn_roughstepoverXY.Value = varProfileCurveCut.RoughStepover;
		chk_roughperpendicularA.Check = varProfileCurveCut.RoughPerpendicularA;
		chk_rougjzigzag.Check = varProfileCurveCut.RoughZigzagMode;
		chk_roughreverseC.Check = varProfileCurveCut.RoughReverseCAngle;
		if (varProfileCurveCut.RoughAreaMode == MarbleCamAreaMode.Region)
		{
			radioButton_0.Checked = true;
		}
		if (varProfileCurveCut.RoughAreaMode == MarbleCamAreaMode.Level)
		{
			radioButton_1.Checked = true;
		}
		spn_offsetsafedistance.Value = varProfileCurveCut.OffsetSafeDis;
		spn_offsetstepangle.Value = varProfileCurveCut.OffsetAngleStep;
		spn_offsetminZHeight.Value = varProfileCurveCut.OffsetMinZ;
		spn_offsetplungefeed.Value = varProfileCurveCut.OffsetPlungeFeed;
		spn_offsetforwardcuttingspeed.Value = varProfileCurveCut.OffsetCutBackwardFeed;
		spn_offsetbackwardcuttingspeed.Value = varProfileCurveCut.OffsetCutBackwardFeed;
		spn_offsetleadinangle.Value = varProfileCurveCut.OffsetLeadInAngle;
		spn_offsetleadoutangle.Value = varProfileCurveCut.OffsetLeadOutAngle;
		spn_offsetinsideoffset.Value = varProfileCurveCut.OffsetInsideOffset;
		spn_offsetoutsideoffset.Value = varProfileCurveCut.OffsetOutsideOffset;
		spn_offsetzdownstep.Value = varProfileCurveCut.OffsetZForwardDownStep;
		spn_offsetedgeoffsey.Value = varProfileCurveCut.OffsetEdgeOffset;
		chk_offsetzigzag.Check = varProfileCurveCut.OffsetZigzagMode;
		chk_offsetreverseC.Check = varProfileCurveCut.OffsetReverseCAngle;
		chk_offsetcutedges.Check = varProfileCurveCut.OffsetCutEdges;
		chk_offsetcutinside.Check = varProfileCurveCut.OffsetCutInisde;
		chk_offsetcutoutside.Check = varProfileCurveCut.OffsetCutOutside;
		spn_offsetAAngle.Value = varProfileCurveCut.OffsetInnerCutAAngle;
		Class186.smethod_560(this);
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
				Class186.smethod_418(this);
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
