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

public class F_MarbleProfileCam : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleProfileCutPars varProfileCut = new marbleProfileCutPars();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_finishsurfoffset;

	public buSpin spn_finishminZ;

	public buSpin spn_finishstepdistance;

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

	public buSpin spn_roughminZ;

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

	public buSpin spn_finishverticaldevide;

	public buSpin spn_finishleadout;

	public buSpin spn_finishleadin;

	public buSpin spn_roughverticaldevidelen;

	public buSpin spn_roughleadout;

	public buSpin spn_roughleadin;

	public buSpin spn_roughstepoverXY;

	public buSpin spn_roughzdownstep;

	internal buLabel buLabel_2;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	public buSpin spn_roughoutsideoffset;

	public buSpin spn_roughinsideoffset;

	public buSpin spn_roughbottomoffset;

	public buSpin spn_roughtopoffet;

	public buCheckBox chk_roughreverseC;

	public buCheckBox chk_finishmoveupsafe;

	public buSpin spn_finishoutsideoffset;

	public buSpin spn_finishinsideoffset;

	public buSpin spn_finishbottomoffset;

	public buSpin spn_finishtopoffet;

	public buCheckBox chk_finishreverseC;

	public buCheckBox chk_roughmoveupsafedis;

	internal TabPage tabPage_2;

	public buSpin spn_offsetAAngle;

	public buCheckBox chk_offsetzigzag;

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

	internal buLabel buLabel_3;

	public F_MarbleProfileCam()
	{
		Class186.smethod_237(this);
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
		spn_finishsafedis.Value = varProfileCut.FinishSafeDis;
		spn_finishsurfoffset.Value = varProfileCut.FinishSurfOffset;
		spn_finishstepdistance.Value = varProfileCut.FinishStep;
		spn_finishminZ.Value = varProfileCut.FinishMinZ;
		spn_finishrapiddis.Value = varProfileCut.FinishRapid;
		spn_finishplungefeed.Value = varProfileCut.FinishPlungeFeed;
		spn_finishfwdcutfeed.Value = varProfileCut.FinishCutForwardFeed;
		spn_finishbwdcuttingfeed.Value = varProfileCut.FinishCutBackwardFeed;
		spn_finishverticaldevide.Value = varProfileCut.FinishVerticalDevideLen;
		spn_finishleadin.Value = varProfileCut.FinishLeadIn;
		spn_finishleadout.Value = varProfileCut.FinishLeadOut;
		chk_finishzigzag.Check = varProfileCut.FinishZigzagMode;
		chk_finishperpendicularA.Check = varProfileCut.FinishPerpendicularA;
		chk_finishreverseC.Check = varProfileCut.FinishReverseCAngle;
		chk_finishmoveupsafe.Check = varProfileCut.FinishMoveUpSafe;
		spn_finishtopoffet.Value = varProfileCut.FinishTopOffset;
		spn_finishbottomoffset.Value = varProfileCut.FinishBottomOffset;
		spn_finishinsideoffset.Value = varProfileCut.FinishInsideOffset;
		spn_finishoutsideoffset.Value = varProfileCut.FinishOutsideOffset;
		spn_roughsafedis.Value = varProfileCut.RoughSafeDis;
		spn_roughsurfoffset.Value = varProfileCut.RoughSurfOffset;
		spn_roughminZ.Value = varProfileCut.RoughMinZ;
		spn_roughrapiddis.Value = varProfileCut.RoughRapid;
		spn_roughplungefeed.Value = varProfileCut.RoughPlungeFeed;
		spn_roughfwdcuttingfeed.Value = varProfileCut.RoughCutBackwardFeed;
		spn_roughbwdcuttingfeed.Value = varProfileCut.RoughCutBackwardFeed;
		spn_roughverticaldevidelen.Value = varProfileCut.RoughVerticalDevideLen;
		spn_roughleadin.Value = varProfileCut.RoughLeadIn;
		spn_roughleadout.Value = varProfileCut.RoughLeadOut;
		chk_rougjzigzag.Check = varProfileCut.RoughZigzagMode;
		chk_roughmoveupsafedis.Check = varProfileCut.RoughMoveUpSafeDistance;
		chk_roughperpendicularA.Check = varProfileCut.RoughPerpendicularA;
		spn_roughtopoffet.Value = varProfileCut.RoughTopOffset;
		spn_roughbottomoffset.Value = varProfileCut.RoughBottomOffset;
		spn_roughinsideoffset.Value = varProfileCut.RoughInsideOffset;
		spn_roughoutsideoffset.Value = varProfileCut.RoughOutsideOffset;
		spn_roughzdownstep.Value = varProfileCut.RoughZForwardDownStep;
		spn_roughstepoverXY.Value = varProfileCut.RoughStepover;
		varProfileCut.RoughZigzagMode = chk_rougjzigzag.Check;
		varProfileCut.RoughPerpendicularA = chk_roughperpendicularA.Check;
		chk_roughreverseC.Check = varProfileCut.RoughReverseCAngle;
		if (varProfileCut.RoughAreaMode == MarbleCamAreaMode.Region)
		{
			radioButton_0.Checked = true;
		}
		if (varProfileCut.RoughAreaMode == MarbleCamAreaMode.Level)
		{
			radioButton_1.Checked = true;
		}
		spn_offsetsafedistance.Value = varProfileCut.OffsetSafeDis;
		spn_offsetstepangle.Value = varProfileCut.OffsetAngleStep;
		spn_offsetminZHeight.Value = varProfileCut.OffsetMinZ;
		spn_offsetplungefeed.Value = varProfileCut.OffsetPlungeFeed;
		spn_offsetforwardcuttingspeed.Value = varProfileCut.OffsetCutBackwardFeed;
		spn_offsetbackwardcuttingspeed.Value = varProfileCut.OffsetCutBackwardFeed;
		spn_offsetleadinangle.Value = varProfileCut.OffsetLeadIn;
		spn_offsetleadoutangle.Value = varProfileCut.OffsetLeadOut;
		spn_offsetinsideoffset.Value = varProfileCut.OffsetInsideOffset;
		spn_offsetoutsideoffset.Value = varProfileCut.OffsetOutsideOffset;
		spn_offsetzdownstep.Value = varProfileCut.OffsetZForwardDownStep;
		spn_offsetedgeoffsey.Value = varProfileCut.OffsetEdgeOffset;
		chk_offsetzigzag.Check = varProfileCut.OffsetZigzagMode;
		chk_offsetreverseC.Check = varProfileCut.OffsetReverseCAngle;
		chk_offsetcutedges.Check = varProfileCut.OffsetCutEdges;
		chk_offsetcutinside.Check = varProfileCut.OffsetCutInisde;
		chk_offsetcutoutside.Check = varProfileCut.OffsetCutOutside;
		spn_offsetAAngle.Value = varProfileCut.OffsetInnerCutAAngle;
		Class186.smethod_700(this);
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
				Class186.smethod_609(this);
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
