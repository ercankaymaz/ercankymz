using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawCornerClean : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public marbleSawMillingPars varSawMilling = new marbleSawMillingPars();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buSpin spn_bottomoffset;

	public buSpin spn_topoffset;

	public buSpin spn_xyoffset;

	public buSpin spn_XYapproachStep;

	public buSpin spn_cuttngforwardfeed;

	public buSpin spn_plungefeed;

	public buSpin spn_zdownstep;

	public buSpin spn_safedistanceZ;

	public buCheckBox chk_zigzag;

	public buSpin spn_xysafedis;

	public buSpin spn_cuttngbackwardfeed;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal buLabel buLabel_0;

	public buSpin spn_curvedegree;

	internal RadioButton radioButton_3;

	public buButton btn_advanced;

	internal buPanel buPanel_0;

	internal buLabel buLabel_1;

	public buCheckBox chk_uselastcurvature;

	public buSpin spn_resolution;

	public buCheckBox chk_splinenebale;

	public buSpin spn_singlelayerdepth;

	public buCheckBox chk_singlelayer;

	public buButton btn_color;

	public buButton btn_closeadvanced;

	public buCheckBox chk_trimtoborder;

	public F_MarbleSawCornerClean()
	{
		Class186.smethod_552(this);
	}

	public void Init(FormStartPosition formPos = FormStartPosition.CenterScreen, FormCloseModeType CloseMode = FormCloseModeType.Invisible)
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
		PropertiesForm.FormPosition = formPos;
		PropertiesForm.FormCloseMode = CloseMode;
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		buPanel_0.Visible = false;
		spn_bottomoffset.Value = varSawMilling.SawMillingVerCornerBottomOffset;
		spn_cuttngbackwardfeed.Value = varSawMilling.SawMillingVerCornerBackwardCuttingFeed;
		spn_cuttngforwardfeed.Value = varSawMilling.SawMillingVerCornerForwardCuttingFeed;
		spn_plungefeed.Value = varSawMilling.SawMillingVerCornerPlungeFeed;
		spn_safedistanceZ.Value = varSawMilling.SawMillingVerCornerSafeDistanceZ;
		spn_topoffset.Value = varSawMilling.SawMillingVerCornerTopOffset;
		spn_XYapproachStep.Value = varSawMilling.SawMillingVerCornerXYAproachStep;
		spn_xyoffset.Value = varSawMilling.SawMillingVerCornerXYOffset;
		spn_xysafedis.Value = varSawMilling.SawMillingVerCornerSafeDistanceXY;
		spn_zdownstep.Value = varSawMilling.SawMillingVerCornerZDownStep;
		spn_curvedegree.Value = varSawMilling.SawMillingVerCornerCurvatureDegree;
		chk_zigzag.Check = varSawMilling.SawMillingVerCornerZigzag;
		spn_resolution.Value = varSawMilling.SawMillingVerCornerCutTolerance;
		chk_uselastcurvature.Check = varSawMilling.SawMillingVerCornerUseLastContour;
		chk_splinenebale.Check = varSawMilling.SawMillingVerCornerSplineEnable;
		chk_trimtoborder.Check = varSawMilling.SawMillingVerCornerTrimToBorder;
		chk_singlelayer.Check = varSawMilling.SawMillingVerCornerUseSingleLayer;
		spn_singlelayerdepth.Value = varSawMilling.SawMillingVerCornerSingleLayerDepth;
		btn_color.Display.BackColor = varSawMilling.SawMillingCamColor;
		btn_color.ButtonDownDisplay.BackColor = varSawMilling.SawMillingCamColor;
		btn_color.ButtonOverDisplay.BackColor = varSawMilling.SawMillingCamColor;
		radioButton_2.Checked = false;
		radioButton_1.Checked = false;
		radioButton_0.Checked = false;
		if (varSawMilling.SawMillingVerCornerMode != MarbleSawCornerCleanMode.FullCurvature)
		{
			if (varSawMilling.SawMillingVerCornerMode != MarbleSawCornerCleanMode.FitLine)
			{
				if (varSawMilling.SawMillingVerCornerMode != MarbleSawCornerCleanMode.FitCircular)
				{
					radioButton_2.Checked = true;
				}
				else
				{
					radioButton_3.Checked = true;
				}
			}
			else
			{
				radioButton_1.Checked = true;
			}
		}
		else
		{
			radioButton_0.Checked = true;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_629(this);
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
				Class186.smethod_704(this);
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
			if (control.Name == btn_cancel.Name)
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
				if (buPanel_0.Visible)
				{
					buPanel_0.Visible = false;
				}
				else
				{
					buPanel_0.Visible = true;
				}
			}
			if (control.Name == btn_closeadvanced.Name)
			{
				buPanel_0.Visible = false;
			}
			if (control.Name == btn_color.Name)
			{
				new ColorDialogBox();
				Color cColor = varSawMilling.SawMillingCamColor;
				if (ColorDialogBox.ShowDialog(ref cColor) == DialogResult.OK)
				{
					varSawMilling.SawMillingCamColor = cColor;
					btn_color.Display.BackColor = cColor;
					btn_color.ButtonDownDisplay.BackColor = cColor;
					btn_color.ButtonOverDisplay.BackColor = cColor;
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
