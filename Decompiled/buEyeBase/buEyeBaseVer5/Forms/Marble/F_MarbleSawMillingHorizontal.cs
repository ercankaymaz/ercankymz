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

public class F_MarbleSawMillingHorizontal : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MarbleCamMode CamMode = MarbleCamMode.Finish;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buSpin spn_startzoffset;

	public buSpin spn_endzoffset;

	public buSpin spn_scaleheight;

	public buSpin spn_scalewidth;

	public buCheckBox chk_keepratio;

	public buSpin spn_baseheight;

	public buSpin spn_minz;

	public F_MarbleSawMillingHorizontal()
	{
		Class186.smethod_696(this);
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
		spn_scaleheight.Value = buMarbleCalc.varMarbleRunSettings.ScaleHeight;
		spn_scalewidth.Value = buMarbleCalc.varMarbleRunSettings.ScaleWidth;
		spn_baseheight.Value = buMarbleCalc.varMarbleRunSettings.ScaleBaseHeight;
		chk_keepratio.Check = buMarbleCalc.varMarbleRunSettings.ScaleKeepRatio;
		if (CamMode != MarbleCamMode.Rough)
		{
			spn_startzoffset.Value = buMarbleCalc.varOperation.settingSawMilling.SawMillingFinishHorStartOffset;
			spn_endzoffset.Value = buMarbleCalc.varOperation.settingSawMilling.SawMillingFinishHorEndOffset;
			spn_minz.Value = buMarbleCalc.varOperation.settingSawMilling.SawMillingFinishHorMinZValue;
		}
		else
		{
			spn_startzoffset.Value = buMarbleCalc.varOperation.settingSawMilling.SawMillingRoughHorTopOffset;
			spn_endzoffset.Value = buMarbleCalc.varOperation.settingSawMilling.SawMillingRoughHorBottomOffset;
			spn_minz.Value = buMarbleCalc.varOperation.settingSawMilling.SawMillingRoughHorMinZValue;
		}
		Class186.smethod_134(this);
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
				Class186.smethod_559(this);
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
