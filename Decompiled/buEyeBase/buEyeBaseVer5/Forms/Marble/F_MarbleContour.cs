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

public class F_MarbleContour : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MarbleItemSettings varSettings = new MarbleItemSettings();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public buSpin spn_InnerCutSafeDistance;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buSpin spn_OutterCutSafeDistance;

	internal buGround buGround_0;

	public buCheckBox chk_concavecuttingNone;

	public buCheckBox chk_DontAddExtensionEntities;

	public buSpin spn_CutSawDistanceOverlap;

	internal buSeparator buSeparator_0;

	public buLabel lbl_concavetype;

	public buSpin spn_ConcaveMillingStepDown;

	public buCheckBox chk_concexcuttingWaterjet;

	public buCheckBox chk_concexcuttingmilling;

	public buLabel lbl_convexcuttingtype;

	public buCheckBox chk_concexcuttingNone;

	public buCheckBox chk_concavecuttingWaterjet;

	public buCheckBox chk_concavecuttingMilling;

	public buButton btn_close;

	public buButton btn_advancedsettings;

	public F_MarbleContour()
	{
		Class186.smethod_497(this);
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
		chk_concavecuttingMilling.Check = false;
		chk_concavecuttingNone.Check = false;
		chk_concavecuttingWaterjet.Check = false;
		if (varSettings.settingMarbleCam.ConcaveCuttingType != MarbleConcaveCuttingType.Milling)
		{
			if (varSettings.settingMarbleCam.ConcaveCuttingType != MarbleConcaveCuttingType.WaterJet)
			{
				chk_concavecuttingNone.Check = true;
			}
			else
			{
				chk_concavecuttingWaterjet.Check = true;
			}
		}
		else
		{
			chk_concavecuttingMilling.Check = true;
		}
		chk_concexcuttingmilling.Check = false;
		chk_concexcuttingNone.Check = false;
		chk_concexcuttingWaterjet.Check = false;
		if (varSettings.settingMarbleCam.ConvexCuttingType != MarbleConcaveCuttingType.Milling)
		{
			if (varSettings.settingMarbleCam.ConvexCuttingType != MarbleConcaveCuttingType.WaterJet)
			{
				chk_concexcuttingNone.Check = true;
			}
			else
			{
				chk_concexcuttingWaterjet.Check = true;
			}
		}
		else
		{
			chk_concexcuttingmilling.Check = true;
		}
		spn_ConcaveMillingStepDown.Value = varSettings.settingMarbleCam.MillingStepDown;
		spn_CutSawDistanceOverlap.Value = varSettings.settingMarbleCam.CutSawDistanceOverlap;
		spn_InnerCutSafeDistance.Value = varSettings.settingMarbleCam.InnerCutSafeDistance;
		spn_OutterCutSafeDistance.Value = varSettings.settingMarbleCam.OutterCutSafeDistance;
		Class186.smethod_313(this);
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
			if (!(control.Name == chk_concavecuttingMilling.Name))
			{
				if (!(control.Name == chk_concavecuttingWaterjet.Name))
				{
					if (!(control.Name == chk_concavecuttingNone.Name))
					{
						if (!(control.Name == chk_concexcuttingmilling.Name))
						{
							if (!(control.Name == chk_concexcuttingWaterjet.Name))
							{
								if (!(control.Name == chk_concexcuttingNone.Name))
								{
									if (control.Name == btn_advancedsettings.Name)
									{
										F_MarbleContourAdvancedSettings f_MarbleContourAdvancedSettings = new F_MarbleContourAdvancedSettings();
										f_MarbleContourAdvancedSettings.varOperation = new MarbleItemSettings(varSettings);
										f_MarbleContourAdvancedSettings.Properties.FormCloseMode = FormCloseModeType.Dispose;
										f_MarbleContourAdvancedSettings.Properties.FormPosition = FormStartPosition.CenterParent;
										f_MarbleContourAdvancedSettings.Init();
										f_MarbleContourAdvancedSettings.ShowDialog();
										if (f_MarbleContourAdvancedSettings.Properties.Result == DialogResult.OK)
										{
											varSettings = new MarbleItemSettings(f_MarbleContourAdvancedSettings.varOperation);
										}
									}
									if (control.Name == btn_ok.Name)
									{
										Class186.smethod_512(this);
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
									if ((control.Name == btn_cancel.Name) | (control.Name == btn_close.Name))
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
								else
								{
									chk_concexcuttingmilling.Check = false;
									chk_concexcuttingWaterjet.Check = false;
									chk_concexcuttingNone.Check = true;
								}
							}
							else
							{
								chk_concexcuttingmilling.Check = false;
								chk_concexcuttingWaterjet.Check = true;
								chk_concexcuttingNone.Check = false;
							}
						}
						else
						{
							chk_concexcuttingmilling.Check = true;
							chk_concexcuttingWaterjet.Check = false;
							chk_concexcuttingNone.Check = false;
						}
					}
					else
					{
						chk_concavecuttingMilling.Check = false;
						chk_concavecuttingNone.Check = true;
						chk_concavecuttingWaterjet.Check = false;
					}
				}
				else
				{
					chk_concavecuttingMilling.Check = false;
					chk_concavecuttingNone.Check = false;
					chk_concavecuttingWaterjet.Check = true;
				}
			}
			else
			{
				chk_concavecuttingMilling.Check = true;
				chk_concavecuttingNone.Check = false;
				chk_concavecuttingWaterjet.Check = false;
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
		buCheckBox buCheckBox2 = sender as buCheckBox;
		chk_concavecuttingNone.Check = false;
		chk_DontAddExtensionEntities.Check = false;
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
