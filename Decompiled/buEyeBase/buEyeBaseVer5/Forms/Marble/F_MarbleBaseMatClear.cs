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

public class F_MarbleBaseMatClear : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleMatrialCleanPars varMaterialClean = new marbleMatrialCleanPars();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_safedis;

	public buSpin spn_operationz;

	public buSpin spn_baseheight;

	public buCheckBox chk_zigzag;

	public buSpin spn_basewidth;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	internal ImageList imageList_1;

	public buSpin spn_stepdistance;

	public buSpin spn_cuttingfeed;

	public buSpin spn_plunfefeed;

	public buSpin spn_spindlespeed;

	public buSpin spn_startY;

	public buSpin spn_startX;

	public buSpin spn_rapiddis;

	public buSpin spn_zdownstep;

	public buCheckBox chk_toolmillinghead;

	public buCheckBox chk_toolsaw;

	public buCheckBox chk_toolmilling;

	public buSpin spn_starthegiht;

	public buSpin spn_cangle;

	public F_MarbleBaseMatClear()
	{
		Class186.smethod_409(this);
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
		spn_startX.Value = varMaterialClean.StartX;
		spn_startY.Value = varMaterialClean.StartY;
		spn_baseheight.Value = varMaterialClean.BaseHegiht;
		spn_basewidth.Value = varMaterialClean.BaseWidth;
		spn_operationz.Value = varMaterialClean.OperationZ;
		spn_safedis.Value = varMaterialClean.SafeDistance;
		spn_rapiddis.Value = varMaterialClean.RapidDistance;
		spn_stepdistance.Value = varMaterialClean.StepDistance;
		spn_cuttingfeed.Value = varMaterialClean.CuttingFeed;
		spn_plunfefeed.Value = varMaterialClean.PlungeFeed;
		spn_spindlespeed.Value = varMaterialClean.SpindleSpeed;
		spn_zdownstep.Value = varMaterialClean.ZDownStep;
		spn_starthegiht.Value = varMaterialClean.StartHeight;
		spn_cangle.Value = varMaterialClean.CAxisAngle;
		chk_zigzag.Check = varMaterialClean.ZigzagMode;
		chk_toolmilling.Check = false;
		chk_toolmillinghead.Check = false;
		chk_toolsaw.Check = false;
		if (buMarbleCalc.varMarbleRunSettings.selectedType.selectedTool != MarbleToolType.Milling)
		{
			if (buMarbleCalc.varMarbleRunSettings.selectedType.selectedTool != MarbleToolType.MillingHead)
			{
				chk_toolsaw.Check = true;
			}
			else
			{
				chk_toolmillinghead.Check = true;
			}
		}
		else
		{
			chk_toolmilling.Check = true;
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		Class186.smethod_606(this);
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
			if (control.Name == chk_toolmilling.Name)
			{
				chk_toolmilling.Check = true;
				chk_toolmillinghead.Check = false;
				chk_toolsaw.Check = false;
				buMarbleCalc.varMarbleRunSettings.selectedType.selectedTool = MarbleToolType.Milling;
			}
			if (control.Name == chk_toolmillinghead.Name)
			{
				chk_toolmilling.Check = false;
				chk_toolmillinghead.Check = true;
				chk_toolsaw.Check = false;
				buMarbleCalc.varMarbleRunSettings.selectedType.selectedTool = MarbleToolType.MillingHead;
			}
			if (control.Name == chk_toolsaw.Name)
			{
				chk_toolmilling.Check = false;
				chk_toolmillinghead.Check = false;
				chk_toolsaw.Check = true;
				buMarbleCalc.varMarbleRunSettings.selectedType.selectedTool = MarbleToolType.Saw;
			}
			if (control.Name == btn_ok.Name)
			{
				Class186.smethod_367(this);
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

	internal void method_3(object sender, EventArgs e)
	{
		if (!Properties.Inited)
		{
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
