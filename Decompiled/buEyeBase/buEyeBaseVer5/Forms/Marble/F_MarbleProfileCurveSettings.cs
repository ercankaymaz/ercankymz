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

public class F_MarbleProfileCurveSettings : Form
{
	public FormProperties Properties = new FormProperties();

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

	public F_MarbleProfileCurveSettings()
	{
		Class186.smethod_301(this);
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
		chk_roughperpendicularA.Check = varProfileCurveCut.RoughPerpendicularA;
		chk_rougjzigzag.Check = varProfileCurveCut.RoughZigzagMode;
		Class186.smethod_514(this);
		Properties.Inited = true;
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
				Class186.smethod_308(this);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
