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

public class F_MarbleProfileSettings : Form
{
	public FormProperties Properties = new FormProperties();

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

	public F_MarbleProfileSettings()
	{
		Class186.smethod_159(this);
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
		chk_roughperpendicularA.Check = varProfileCut.RoughPerpendicularA;
		Class186.smethod_420(this);
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
				Class186.smethod_56(this);
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
