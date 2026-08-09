using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls;
using buControls.Controls;
using buControls.DialogBox;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCamSettings : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public marbleCamPars Settings = new marbleCamPars();

	public MarbleProgramSettings SettingsProgram = new MarbleProgramSettings();

	public List<MarbleOperationSequence> Sequences = new List<MarbleOperationSequence>();

	public int indexMat = -1;

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_millinghead;

	public buButton btn_milling;

	public buButton btn_saw;

	public buButton btn_strategy;

	public buTab buTab_Main;

	public TabPage tabPage_mainpage;

	public TabPage tabPage_sawmain;

	public TabPage tabPage_millihmain;

	internal TabPage tabPage_0;

	internal Panel panel_0;

	internal buLabel buLabel_0;

	internal RadioButton radioButton_0;

	internal Panel panel_1;

	internal buLabel buLabel_1;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	public buSpin spn_sawplungespeed;

	public buSpin spn_sawstraightcutfirststep;

	public buSpin spn_sawsafedistance;

	public buSpin spn_sawcircularcutfirststep;

	public buSpin spn_sawrapiddistance;

	public buSpin spn_sawstraightcutfirstspeed;

	public buSpin spn_sawcircularcutFwdspeed;

	public buSpin spn_sawcircularcutstep;

	public buSpin spn_sawstraightcutstep;

	public buSpin spn_sawcircularcutfirstspeed;

	public buSpin spn_sawstraightcuttingsFwdspeed;

	internal buLabel buLabel_2;

	public buSpin spn_millingdrillspeed;

	public buSpin spn_millingfirstcutstep;

	public buSpin spn_millingcutspeed;

	public buSpin spn_millingplungespeed;

	public buSpin spn_millingfirstcutspeed;

	public buSpin spn_millingcutstep;

	internal buLabel buLabel_3;

	public buSpin spn_millingheadfirstcutstep;

	public buSpin spn_millingheaddrillspeed;

	public buSpin spn_millingheadcutspeed;

	public buSpin spn_millingheadplungespeed;

	public buSpin spn_millingheadfirstcutspeed;

	public buSpin spn_millingheadcutstep;

	internal buLabel buLabel_4;

	public buSpin spn_sawplungefirstspeed;

	public buSpin spn_millingplungefirstspeed;

	public buSpin spn_millingheadplungefirstspeed;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal PictureBox pictureBox_0;

	internal buLabel buLabel_5;

	internal buLabel buLabel_6;

	internal buLabel buLabel_7;

	internal RadioButton radioButton_6;

	internal RadioButton radioButton_7;

	internal TabPage tabPage_1;

	public buTab buTab_command_settings;

	public TabPage tabPage_saw;

	public TabPage tabPage_mlling;

	internal TabPage tabPage_2;

	internal buListBox buListBox_0;

	internal buTextBox buTextBox_0;

	public buButton btn_material;

	public buButton btn_matsave;

	internal buTextBox buTextBox_1;

	internal RadioButton radioButton_8;

	internal RadioButton radioButton_9;

	internal RadioButton radioButton_10;

	internal RadioButton radioButton_11;

	internal RadioButton radioButton_12;

	internal PictureBox pictureBox_1;

	public buSpin spn_matsawplungespeed;

	public buSpin spn_matsawcircularcutFwdspeed;

	public buSpin spn_matsawstraightcutfirststep;

	public buSpin spn_matsawcircularcutstep;

	public buSpin spn_matsawcircularcutfirststep;

	public buSpin spn_matsawcircularcutfirstspeed;

	public buSpin spn_matsawstraightcutfirstspeed;

	public buSpin spn_matsawstraightcuttingsFwdspeed;

	public buSpin spn_matsawstraightcutstep;

	public buSpin spn_matmillingdrillspeed;

	public buSpin spn_matmillingfirstcutstep;

	public buSpin spn_matmillingcutstep;

	public buSpin spn_matmillingfirstcutspeed;

	public buSpin spn_matmillingplungespeed;

	public buSpin spn_matmillingcutspeed;

	public buSpin spn_matmillingheadfirstcutstep;

	public buSpin spn_matmillingheadcutstep;

	public buSpin spn_matmillingheaddrillspeed;

	public buSpin spn_matmillingheadfirstcutspeed;

	public buSpin spn_matmillingheadcutspeed;

	public buSpin spn_matmillingheadplungespeed;

	public buButton btn_matapply;

	internal buLabel buLabel_8;

	internal buLabel buLabel_9;

	public buSpin spn_sawcircularcutBwdspeed;

	public buSpin spn_sawstraightcuttingsBwdspeed;

	internal buLabel buLabel_10;

	internal buLabel buLabel_11;

	internal buLabel buLabel_12;

	internal buLabel buLabel_13;

	internal buLabel buLabel_14;

	internal buLabel buLabel_15;

	internal buLabel buLabel_16;

	internal buLabel buLabel_17;

	internal buLabel buLabel_18;

	public buSpin spn_matsawstraightcuttingsBwdspeed;

	internal buLabel buLabel_19;

	public buSpin spn_matsawcircularcutBwdspeed;

	internal buLabel buLabel_20;

	public buSpin spn_matsawplungefirstspeed;

	internal buLabel buLabel_21;

	internal buLabel buLabel_22;

	internal buLabel buLabel_23;

	public buSpin spn_matmillingplungefirstspeed;

	public buSpin spn_matmillingheadplungefirstspeed;

	internal buLabel buLabel_24;

	internal buLabel buLabel_25;

	internal buLabel buLabel_26;

	public buButton btn_sequence;

	internal Panel panel_2;

	internal RadioButton radioButton_13;

	internal buLabel buLabel_27;

	internal RadioButton radioButton_14;

	internal buLabel buLabel_28;

	public buSpin spn_millingsafedistance;

	public buSpin spn_millingrapiddistance;

	internal buLabel buLabel_29;

	public buSpin spn_millingheadsafedistance;

	public buSpin spn_millingheadrapiddistance;

	internal TabPage tabPage_3;

	internal Panel panel_3;

	public buCheckBox chk_millingcuttings;

	public buCheckBox chk_cornercuttingbyhole;

	public buCheckBox chk_cornercuttigbymilling;

	public buCheckBox chk_sawcuttings;

	internal buLabel buLabel_30;

	internal Panel panel_4;

	internal RadioButton radioButton_15;

	internal RadioButton radioButton_16;

	internal buLabel buLabel_31;

	internal RadioButton radioButton_17;

	internal buSeparator buSeparator_0;

	internal buLabel buLabel_32;

	public buCheckBox chk_automagnet;

	public buCheckBox chk_HorizontalLeftToRight;

	public buCheckBox chk_VerticalBackToFront;

	public buCheckBox chk_OutsideContourLeadInOutForArc;

	public buCheckBox chk_circularfirst;

	public buCheckBox chk_insidefirst;

	public buCheckBox chk_A45First;

	public buCheckBox chk_autowater;

	internal Panel panel_5;

	internal RadioButton radioButton_18;

	internal buLabel buLabel_33;

	internal RadioButton radioButton_19;

	internal Panel panel_6;

	internal RadioButton radioButton_20;

	internal buLabel buLabel_34;

	internal RadioButton radioButton_21;

	internal Panel panel_7;

	internal RadioButton radioButton_22;

	internal buLabel buLabel_35;

	internal RadioButton radioButton_23;

	public buSpin spn_OutsideContourLeadOut;

	public buSpin spn_OutsideContourLeadIn;

	public buSpin spn_outsidecutcornerdis;

	public buSpin spn_insidecutcornerdis;

	public buCheckBox chk_OutsideArcCuttingByMilling;

	public buSpin spn_OutsideArcCuttingMinDiameterBySaw;

	public buCheckBox chk_LastStepAtSameTime;

	public buSpin spn_Inside0DegreeExtraOffset;

	public buSpin spn_Inside45DegreeExtraOffset;

	public buCheckBox chk_DontMoveSafeForForwardBackwardDirection;

	internal TabPage tabPage_4;

	public buSpin spn_MaxAllowedAngleA;

	public buSpin spn_AngleCLimit;

	public buSpin spn_AngleCMax;

	public buSpin spn_AngleCMin;

	internal buLabel buLabel_36;

	public buCheckBox chk_isFirstCutSafeDistance;

	public buSpin spn_RegenDeviatation;

	public buSpin spn_CutTolerance;

	public buCheckBox chk_ToolPathPointDistributionMode;

	public buCheckBox chk_MoveZCAAxesToSafeDistance;

	public buSpin spn_JobFinishZPostion;

	public buButton btn_advanced;

	public buButton btn_options;

	internal Panel panel_8;

	internal RadioButton radioButton_24;

	internal RadioButton radioButton_25;

	internal buLabel buLabel_37;

	internal RadioButton radioButton_26;

	public buButton btn_matload;

	internal Panel panel_9;

	internal RadioButton radioButton_27;

	internal RadioButton radioButton_28;

	internal buLabel buLabel_38;

	internal RadioButton radioButton_29;

	internal buLabel buLabel_39;

	public buSpin spn_sawleavespeed;

	internal buLabel buLabel_40;

	public buSpin spn_millingdrillleavespeed;

	internal buLabel buLabel_41;

	public buSpin spn_millingheaddrillleavespeed;

	public buButton btn_helpme;

	public buCheckBox chk_CutSameDirection;

	public buCheckBox chk_CommonPathCalculation;

	public buSpin spn_drilltargetZ;

	public buSpin spn_convexcornerextraoffset;

	public buSpin spn_concavecornerextraoffset;

	public F_MarbleCamSettings()
	{
		Class186.smethod_752(this);
	}

	public void Init(int Index)
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
		buTab_Main.ItemSize = new Size(1, 1);
		AppBool.HelpMe = false;
		radioButton_14.Checked = false;
		radioButton_13.Checked = false;
		if (Settings.CuttingDirection != CamCuttingDirectionType.Forward)
		{
			radioButton_13.Checked = true;
		}
		else
		{
			radioButton_14.Checked = true;
		}
		radioButton_4.Checked = false;
		radioButton_0.Checked = false;
		radioButton_6.Checked = false;
		radioButton_5.Checked = false;
		if (Settings.ConcaveCuttingType != MarbleConcaveCuttingType.Milling)
		{
			if (Settings.ConcaveCuttingType != MarbleConcaveCuttingType.Drill)
			{
				if (Settings.ConcaveCuttingType != MarbleConcaveCuttingType.WaterJet)
				{
					radioButton_5.Checked = true;
				}
				else
				{
					radioButton_0.Checked = true;
				}
			}
			else
			{
				radioButton_6.Checked = true;
			}
		}
		else
		{
			radioButton_4.Checked = true;
		}
		radioButton_7.Checked = false;
		radioButton_2.Checked = false;
		radioButton_1.Checked = false;
		radioButton_3.Checked = false;
		if (Settings.ConvexCuttingType != MarbleConcaveCuttingType.Milling)
		{
			if (Settings.ConvexCuttingType != MarbleConcaveCuttingType.Drill)
			{
				if (Settings.ConvexCuttingType != MarbleConcaveCuttingType.WaterJet)
				{
					radioButton_3.Checked = true;
				}
				else
				{
					radioButton_1.Checked = true;
				}
			}
			else
			{
				radioButton_7.Checked = true;
			}
		}
		else
		{
			radioButton_2.Checked = true;
		}
		radioButton_17.Checked = false;
		radioButton_16.Checked = false;
		radioButton_15.Checked = false;
		if (Settings.ConcaveDrillType != MarbleConcaveDrillType.OneDrill)
		{
			if (Settings.ConcaveDrillType != MarbleConcaveDrillType.ThreeDrill)
			{
				radioButton_15.Checked = true;
			}
			else
			{
				radioButton_16.Checked = true;
			}
		}
		else
		{
			radioButton_17.Checked = true;
		}
		radioButton_19.Checked = false;
		radioButton_18.Checked = false;
		if (Settings.DefaultDrillTool != MarbleMillingToolType.Milling)
		{
			radioButton_18.Checked = true;
		}
		else
		{
			radioButton_19.Checked = true;
		}
		radioButton_23.Checked = false;
		radioButton_22.Checked = false;
		if (Settings.DefaultMillingTool != MarbleMillingToolType.Milling)
		{
			radioButton_22.Checked = true;
		}
		else
		{
			radioButton_23.Checked = true;
		}
		radioButton_25.Checked = false;
		radioButton_26.Checked = false;
		radioButton_24.Checked = false;
		if (Settings.DefaultCornerCleanTool != MarbleCornerCleanToolType.Milling)
		{
			if (Settings.DefaultCornerCleanTool != MarbleCornerCleanToolType.Waterjet)
			{
				radioButton_25.Checked = true;
			}
			else
			{
				radioButton_24.Checked = true;
			}
		}
		else
		{
			radioButton_26.Checked = true;
		}
		radioButton_21.Checked = false;
		radioButton_20.Checked = false;
		if (Settings.StepType != MarbleStepType.Level)
		{
			radioButton_20.Checked = true;
		}
		else
		{
			radioButton_21.Checked = true;
		}
		radioButton_27.Checked = false;
		radioButton_28.Checked = false;
		radioButton_29.Checked = false;
		if (Settings.ConcaveArcOffsetType != MarbleConcaveArcOffsetCalculationType.ChangeAngleA)
		{
			if (Settings.ConcaveArcOffsetType != MarbleConcaveArcOffsetCalculationType.ExtraOffset)
			{
				radioButton_29.Checked = true;
			}
			else
			{
				radioButton_28.Checked = true;
			}
		}
		else
		{
			radioButton_27.Checked = true;
		}
		spn_sawcircularcutstep.Value = Settings.SawForwardCircularStepDownDistance;
		spn_sawcircularcutfirststep.Value = Settings.SawForwardCircularStepFirstDownDistance;
		spn_sawstraightcutfirststep.Value = Settings.SawForwardStepFirstDownDistance;
		spn_sawstraightcutstep.Value = Settings.SawForwardStepDownDistance;
		spn_sawcircularcutFwdspeed.Value = Settings.SawForwardCircularCuttingVelocity;
		spn_sawcircularcutBwdspeed.Value = Settings.SawBackwardCircularCuttingVelocity;
		spn_sawstraightcuttingsFwdspeed.Value = Settings.SawForwardCuttingVelocity;
		spn_sawstraightcuttingsBwdspeed.Value = Settings.SawBackwardCuttingVelocity;
		spn_sawcircularcutfirstspeed.Value = Settings.SawForwardCircularFirstCuttingVelocity;
		spn_sawstraightcutfirstspeed.Value = Settings.SawForwardFirstCuttingVelocity;
		spn_sawleavespeed.Value = Settings.SawLeaveVelocity;
		spn_sawplungefirstspeed.Value = Settings.SawPlungeFirstVelocity;
		spn_sawplungespeed.Value = Settings.SawPlungeVelocity;
		spn_sawrapiddistance.Value = Settings.SawRapidDistance;
		spn_sawsafedistance.Value = Settings.SawSafeDistance;
		spn_millingcutstep.Value = Settings.MillingStepDown;
		spn_millingfirstcutstep.Value = Settings.MillingFirstStepDown;
		spn_millingcutspeed.Value = Settings.MillingCuttingVelocity;
		spn_millingfirstcutspeed.Value = Settings.MillingFirstCuttingVelocity;
		spn_millingplungespeed.Value = Settings.MillingPlungeVelocity;
		spn_millingplungefirstspeed.Value = Settings.MillingPlungeFirstVelocity;
		spn_millingdrillspeed.Value = Settings.MillingDrillVelocity;
		spn_millingdrillleavespeed.Value = Settings.MillingDrillLeaveVelocity;
		spn_millingsafedistance.Value = Settings.MillingSafeDistance;
		spn_millingrapiddistance.Value = Settings.MillingRapidDistance;
		spn_millingheadcutstep.Value = Settings.MillingHeadStepDown;
		spn_millingheadfirstcutstep.Value = Settings.MillingHeadFirstStepDown;
		spn_millingheadcutspeed.Value = Settings.MillingHeadCuttingVelocity;
		spn_millingheadfirstcutspeed.Value = Settings.MillingHeadFirstCuttingVelocity;
		spn_millingheaddrillspeed.Value = Settings.MillingHeadDrillVelocity;
		spn_millingheaddrillleavespeed.Value = Settings.MillingHeadDrillLeaveVelocity;
		spn_millingheadplungespeed.Value = Settings.MillingHeadPlungeVelocity;
		spn_millingheadplungefirstspeed.Value = Settings.MillingHeadPlungeFirstVelocity;
		spn_millingheadsafedistance.Value = Settings.MillingHeadSafeDistance;
		spn_millingheadrapiddistance.Value = Settings.MillingHeadRapidDistance;
		chk_sawcuttings.Check = Settings.UseSawCuttings;
		chk_cornercuttigbymilling.Check = Settings.UseCornerByMilling;
		chk_cornercuttingbyhole.Check = Settings.UseCornerByDrill;
		chk_millingcuttings.Check = Settings.UseMillingCuttings;
		chk_autowater.Check = Settings.AutoWaterOpenClose;
		chk_circularfirst.Check = Settings.isCircularFirst;
		chk_insidefirst.Check = Settings.isInsideFirst;
		chk_A45First.Check = Settings.isA45First;
		chk_automagnet.Check = SettingsProgram.AutoMagnet;
		chk_CutSameDirection.Check = Settings.CutSameDirection;
		chk_CommonPathCalculation.Check = Settings.CommonPathCalculation;
		chk_OutsideContourLeadInOutForArc.Check = Settings.OutsideContourLeadInOutForArc;
		chk_HorizontalLeftToRight.Check = Settings.HorizontalLeftToRight;
		chk_VerticalBackToFront.Check = Settings.VerticalBackToFront;
		chk_DontMoveSafeForForwardBackwardDirection.Check = Settings.DontMoveSafeForForwardBackwardDirection;
		chk_OutsideArcCuttingByMilling.Check = Settings.OutsideArcCuttingByMilling;
		chk_LastStepAtSameTime.Check = Settings.LastStepAtSameTime;
		spn_OutsideContourLeadIn.Value = Settings.OutsideContourLeadIn;
		spn_OutsideContourLeadOut.Value = Settings.OutsideContourLeadOut;
		spn_OutsideArcCuttingMinDiameterBySaw.Value = Settings.OutsideArcCuttingMinDiameterBySaw;
		spn_Inside0DegreeExtraOffset.Value = Settings.Inside0DegreeExtraOffset;
		spn_Inside45DegreeExtraOffset.Value = Settings.Inside45DegreeExtraOffset;
		spn_insidecutcornerdis.Value = Settings.InnerCutSafeDistance;
		spn_outsidecutcornerdis.Value = Settings.OutterCutSafeDistance;
		spn_drilltargetZ.Value = Settings.TargetZDrill;
		spn_concavecornerextraoffset.Value = Settings.ConcaveCornerExtraOffset;
		spn_convexcornerextraoffset.Value = Settings.ConvexCornerExtraOffset;
		spn_AngleCMax.Value = Settings.AngleCMax;
		spn_AngleCMin.Value = Settings.AngleCMin;
		spn_AngleCLimit.Value = Settings.AngleCLimit;
		spn_MaxAllowedAngleA.Value = Settings.MaxAllowedAngleA;
		spn_CutTolerance.Value = Settings.CutTolerance;
		spn_RegenDeviatation.Value = Settings.RegenDeviation;
		spn_JobFinishZPostion.Value = Settings.JobFinishZPostion;
		radioButton_0.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.WaterJet;
		radioButton_1.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.WaterJet;
		radioButton_24.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.WaterJet;
		radioButton_25.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable;
		radioButton_18.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable;
		radioButton_22.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable;
		radioButton_26.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
		radioButton_19.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
		radioButton_23.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
		Class186.smethod_196(this);
		for (int i = 0; i <= buListBox_0.Items.Count - 1; i++)
		{
			if (buListBox_0.Items[i].ToString().Trim() == Settings.MaterialName)
			{
				buListBox_0.SelectedIndex = i;
				break;
			}
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_675(this);
		if (!PropertiesForm.VisualUpdated)
		{
			InitVisual();
		}
		MenuButtonColors(Index);
		pictureBox_0.Image = null;
		buLabel_6.Text = "";
	}

	public void InitVisual()
	{
		FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
		if (fileInfo.Exists)
		{
			Control.ControlCollection controlCollection = null;
			controlCollection = buGround1.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = tabPage_saw.Controls;
			controlCollection = hmiUICommands.SetVisualItem(tabPage_saw.Controls);
			controlCollection = tabPage_mlling.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = tabPage_2.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = tabPage_1.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = tabPage_mainpage.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = tabPage_sawmain.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = tabPage_millihmain.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = tabPage_0.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = tabPage_3.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = tabPage_4.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = panel_5.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = panel_4.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = panel_7.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = panel_6.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = panel_0.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = panel_1.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = panel_2.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = panel_3.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = panel_8.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = panel_9.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
		}
		PropertiesForm.VisualUpdated = true;
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

	public void Apply()
	{
		Settings.SawForwardCircularStepDownDistance = spn_sawcircularcutstep.Value;
		Settings.SawForwardCircularStepFirstDownDistance = spn_sawcircularcutfirststep.Value;
		Settings.SawForwardStepFirstDownDistance = spn_sawstraightcutfirststep.Value;
		Settings.SawForwardStepDownDistance = spn_sawstraightcutstep.Value;
		Settings.SawForwardCircularCuttingVelocity = spn_sawcircularcutFwdspeed.Value;
		Settings.SawBackwardCircularCuttingVelocity = spn_sawcircularcutBwdspeed.Value;
		Settings.SawForwardCuttingVelocity = spn_sawstraightcuttingsFwdspeed.Value;
		Settings.SawBackwardCuttingVelocity = spn_sawstraightcuttingsBwdspeed.Value;
		Settings.SawForwardCircularFirstCuttingVelocity = spn_sawcircularcutfirstspeed.Value;
		Settings.SawForwardFirstCuttingVelocity = spn_sawstraightcutfirstspeed.Value;
		Settings.SawPlungeFirstVelocity = spn_sawplungefirstspeed.Value;
		Settings.SawPlungeVelocity = spn_sawplungespeed.Value;
		Settings.SawLeaveVelocity = spn_sawleavespeed.Value;
		Settings.SawRapidDistance = spn_sawrapiddistance.Value;
		Settings.SawSafeDistance = spn_sawsafedistance.Value;
		Settings.MillingStepDown = spn_millingcutstep.Value;
		Settings.MillingFirstStepDown = spn_millingfirstcutstep.Value;
		Settings.MillingCuttingVelocity = spn_millingcutspeed.Value;
		Settings.MillingFirstCuttingVelocity = spn_millingfirstcutspeed.Value;
		Settings.MillingPlungeVelocity = spn_millingplungespeed.Value;
		Settings.MillingPlungeFirstVelocity = spn_millingplungefirstspeed.Value;
		Settings.MillingDrillVelocity = spn_millingdrillspeed.Value;
		Settings.MillingDrillLeaveVelocity = spn_millingdrillleavespeed.Value;
		Settings.MillingSafeDistance = spn_millingsafedistance.Value;
		Settings.MillingRapidDistance = spn_millingrapiddistance.Value;
		Settings.MillingHeadStepDown = spn_millingheadcutstep.Value;
		Settings.MillingHeadFirstStepDown = spn_millingheadfirstcutstep.Value;
		Settings.MillingHeadCuttingVelocity = spn_millingheadcutspeed.Value;
		Settings.MillingHeadFirstCuttingVelocity = spn_millingheadfirstcutspeed.Value;
		Settings.MillingHeadDrillVelocity = spn_millingheaddrillspeed.Value;
		Settings.MillingHeadDrillLeaveVelocity = spn_millingheaddrillleavespeed.Value;
		Settings.MillingHeadPlungeVelocity = spn_millingheadplungespeed.Value;
		Settings.MillingHeadPlungeFirstVelocity = spn_millingheadplungefirstspeed.Value;
		Settings.MillingHeadSafeDistance = spn_millingheadsafedistance.Value;
		Settings.MillingHeadRapidDistance = spn_millingheadrapiddistance.Value;
		Settings.UseSawCuttings = chk_sawcuttings.Check;
		Settings.UseCornerByMilling = chk_cornercuttigbymilling.Check;
		Settings.UseCornerByDrill = chk_cornercuttingbyhole.Check;
		Settings.UseMillingCuttings = chk_millingcuttings.Check;
		Settings.AutoWaterOpenClose = chk_autowater.Check;
		Settings.isCircularFirst = chk_circularfirst.Check;
		Settings.isInsideFirst = chk_insidefirst.Check;
		Settings.isA45First = chk_A45First.Check;
		SettingsProgram.AutoMagnet = chk_automagnet.Check;
		Settings.OutsideContourLeadInOutForArc = chk_OutsideContourLeadInOutForArc.Check;
		Settings.HorizontalLeftToRight = chk_HorizontalLeftToRight.Check;
		Settings.VerticalBackToFront = chk_VerticalBackToFront.Check;
		Settings.DontMoveSafeForForwardBackwardDirection = chk_DontMoveSafeForForwardBackwardDirection.Check;
		Settings.OutsideArcCuttingByMilling = chk_OutsideArcCuttingByMilling.Check;
		Settings.LastStepAtSameTime = chk_LastStepAtSameTime.Check;
		Settings.OutsideContourLeadIn = spn_OutsideContourLeadIn.Value;
		Settings.OutsideContourLeadOut = spn_OutsideContourLeadOut.Value;
		Settings.OutsideArcCuttingMinDiameterBySaw = spn_OutsideArcCuttingMinDiameterBySaw.Value;
		Settings.Inside0DegreeExtraOffset = spn_Inside0DegreeExtraOffset.Value;
		Settings.Inside45DegreeExtraOffset = spn_Inside45DegreeExtraOffset.Value;
		Settings.InnerCutSafeDistance = spn_insidecutcornerdis.Value;
		Settings.OutterCutSafeDistance = spn_outsidecutcornerdis.Value;
		Settings.CutSameDirection = chk_CutSameDirection.Check;
		Settings.CommonPathCalculation = chk_CommonPathCalculation.Check;
		Settings.TargetZDrill = spn_drilltargetZ.Value;
		Settings.ConcaveCornerExtraOffset = spn_concavecornerextraoffset.Value;
		Settings.ConvexCornerExtraOffset = spn_convexcornerextraoffset.Value;
		Settings.AngleCMax = spn_AngleCMax.Value;
		Settings.AngleCMin = spn_AngleCMin.Value;
		Settings.AngleCLimit = spn_AngleCLimit.Value;
		Settings.MaxAllowedAngleA = spn_MaxAllowedAngleA.Value;
		Settings.CutTolerance = spn_CutTolerance.Value;
		Settings.RegenDeviation = spn_RegenDeviatation.Value;
		Settings.JobFinishZPostion = spn_JobFinishZPostion.Value;
		if (!radioButton_14.Checked)
		{
			Settings.CuttingDirection = CamCuttingDirectionType.ForwardBackward;
		}
		else
		{
			Settings.CuttingDirection = CamCuttingDirectionType.Forward;
		}
		if (!radioButton_2.Checked)
		{
			if (!radioButton_1.Checked)
			{
				if (!radioButton_7.Checked)
				{
					Settings.ConvexCuttingType = MarbleConcaveCuttingType.None;
				}
				else
				{
					Settings.ConvexCuttingType = MarbleConcaveCuttingType.Drill;
				}
			}
			else
			{
				Settings.ConvexCuttingType = MarbleConcaveCuttingType.WaterJet;
			}
		}
		else
		{
			Settings.ConvexCuttingType = MarbleConcaveCuttingType.Milling;
		}
		if (!radioButton_4.Checked)
		{
			if (!radioButton_0.Checked)
			{
				if (!radioButton_6.Checked)
				{
					Settings.ConcaveCuttingType = MarbleConcaveCuttingType.None;
				}
				else
				{
					Settings.ConcaveCuttingType = MarbleConcaveCuttingType.Drill;
				}
			}
			else
			{
				Settings.ConcaveCuttingType = MarbleConcaveCuttingType.WaterJet;
			}
		}
		else
		{
			Settings.ConcaveCuttingType = MarbleConcaveCuttingType.Milling;
		}
		if (!radioButton_17.Checked)
		{
			if (!radioButton_16.Checked)
			{
				Settings.ConcaveDrillType = MarbleConcaveDrillType.FiveDrill;
			}
			else
			{
				Settings.ConcaveDrillType = MarbleConcaveDrillType.ThreeDrill;
			}
		}
		else
		{
			Settings.ConcaveDrillType = MarbleConcaveDrillType.OneDrill;
		}
		if (!radioButton_19.Checked)
		{
			Settings.DefaultDrillTool = MarbleMillingToolType.MillingHead;
		}
		else
		{
			Settings.DefaultDrillTool = MarbleMillingToolType.Milling;
		}
		if (!radioButton_23.Checked)
		{
			Settings.DefaultMillingTool = MarbleMillingToolType.MillingHead;
		}
		else
		{
			Settings.DefaultMillingTool = MarbleMillingToolType.Milling;
		}
		if (!radioButton_26.Checked)
		{
			if (!radioButton_24.Checked)
			{
				Settings.DefaultCornerCleanTool = MarbleCornerCleanToolType.MillingHead;
			}
			else
			{
				Settings.DefaultCornerCleanTool = MarbleCornerCleanToolType.Waterjet;
			}
		}
		else
		{
			Settings.DefaultCornerCleanTool = MarbleCornerCleanToolType.Milling;
		}
		if (!radioButton_21.Checked)
		{
			Settings.StepType = MarbleStepType.Region;
		}
		else
		{
			Settings.StepType = MarbleStepType.Level;
		}
		if (!radioButton_27.Checked)
		{
			if (!radioButton_28.Checked)
			{
				Settings.ConcaveArcOffsetType = MarbleConcaveArcOffsetCalculationType.NoCalculation;
			}
			else
			{
				Settings.ConcaveArcOffsetType = MarbleConcaveArcOffsetCalculationType.ExtraOffset;
			}
		}
		else
		{
			Settings.ConcaveArcOffsetType = MarbleConcaveArcOffsetCalculationType.ChangeAngleA;
		}
	}

	public void MenuButtonColors(int PageIndex)
	{
		buTab_Main.SelectedIndex = PageIndex;
		Control.ControlCollection controls = buGround1.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (PageIndex == 0)
		{
			btn_strategy = buControlCommands.SetButtonColorAll(btn_strategy, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 1)
		{
			btn_options = buControlCommands.SetButtonColorAll(btn_options, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 2)
		{
			btn_advanced = buControlCommands.SetButtonColorAll(btn_advanced, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 3)
		{
			btn_saw = buControlCommands.SetButtonColorAll(btn_saw, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 4)
		{
			btn_milling = buControlCommands.SetButtonColorAll(btn_milling, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 5)
		{
			btn_millinghead = buControlCommands.SetButtonColorAll(btn_millinghead, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 6)
		{
			btn_material = buControlCommands.SetButtonColorAll(btn_material, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_helpme.Name)
			{
				AppBool.HelpMe = true;
			}
			if (control.Name == btn_ok.Name)
			{
				Apply();
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
			if ((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name))
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
			if (control.Name == btn_sequence.Name)
			{
				F_MarbleCuttingSequence f_MarbleCuttingSequence = new F_MarbleCuttingSequence();
				f_MarbleCuttingSequence.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
				f_MarbleCuttingSequence.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_MarbleCuttingSequence.Sequences.Clear();
				for (int i = 0; i <= Sequences.Count - 1; i++)
				{
					f_MarbleCuttingSequence.Sequences.Add(Sequences[i]);
				}
				f_MarbleCuttingSequence.Init();
				f_MarbleCuttingSequence.ShowDialog();
				if (f_MarbleCuttingSequence.PropertiesForm.Result == DialogResult.OK)
				{
					Sequences.Clear();
					for (int j = 0; j <= f_MarbleCuttingSequence.Sequences.Count - 1; j++)
					{
						Sequences.Add(f_MarbleCuttingSequence.Sequences[j]);
					}
				}
			}
			if (control.Name == btn_matapply.Name)
			{
				Class186.smethod_577(this);
			}
			if (control.Name == btn_matload.Name)
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo2 = new buDialogMessageBoxYesNo();
				buDialogMessageBoxYesNo2.StartPosition = FormStartPosition.CenterScreen;
				buDialogMessageBoxYesNo2.Init(buLangTranslate.preDef.Parameter, buLangTranslate.preSentencesMarble.DoYouWantToLoadMaterialParametersToActualParameters);
				buDialogMessageBoxYesNo2.ShowDialog();
				if (buDialogMessageBoxYesNo2.Result != DialogResult.Yes)
				{
					return;
				}
				spn_sawcircularcutstep.Value = spn_matsawcircularcutstep.Value;
				spn_sawcircularcutfirststep.Value = spn_matsawcircularcutfirststep.Value;
				spn_sawstraightcutstep.Value = spn_matsawstraightcutstep.Value;
				spn_sawstraightcutfirststep.Value = spn_matsawstraightcutfirststep.Value;
				spn_sawcircularcutFwdspeed.Value = spn_matsawcircularcutFwdspeed.Value;
				spn_sawcircularcutBwdspeed.Value = spn_matsawcircularcutBwdspeed.Value;
				spn_sawcircularcutfirstspeed.Value = spn_matsawcircularcutfirstspeed.Value;
				spn_sawstraightcutfirstspeed.Value = spn_matsawstraightcutfirstspeed.Value;
				spn_sawstraightcuttingsFwdspeed.Value = spn_matsawstraightcuttingsFwdspeed.Value;
				spn_sawstraightcuttingsBwdspeed.Value = spn_matsawstraightcuttingsBwdspeed.Value;
				spn_sawplungespeed.Value = spn_matsawplungespeed.Value;
				spn_sawplungefirstspeed.Value = spn_matsawplungefirstspeed.Value;
				spn_sawplungefirstspeed.Value = spn_matsawplungefirstspeed.Value;
				spn_millingcutstep.Value = spn_matmillingcutstep.Value;
				spn_millingfirstcutstep.Value = spn_matmillingfirstcutstep.Value;
				spn_millingcutspeed.Value = spn_matmillingcutspeed.Value;
				spn_millingfirstcutspeed.Value = spn_matmillingfirstcutspeed.Value;
				spn_millingplungespeed.Value = spn_matmillingplungespeed.Value;
				spn_millingplungefirstspeed.Value = spn_matmillingplungefirstspeed.Value;
				spn_millingdrillspeed.Value = spn_matmillingdrillspeed.Value;
				spn_millingheadcutspeed.Value = spn_matmillingheadcutspeed.Value;
				spn_millingheadcutstep.Value = spn_matmillingheadcutstep.Value;
				spn_millingheadfirstcutspeed.Value = spn_matmillingheadfirstcutspeed.Value;
				spn_millingheadfirstcutstep.Value = spn_matmillingheadfirstcutstep.Value;
				spn_millingheaddrillspeed.Value = spn_matmillingdrillspeed.Value;
				spn_millingheadplungespeed.Value = spn_matmillingplungespeed.Value;
				spn_millingheadplungefirstspeed.Value = spn_matmillingplungefirstspeed.Value;
			}
			if (control.Name == btn_matsave.Name && ((indexMat >= 0) & (indexMat <= buMarbleCalc.MaterialList.Count - 1)))
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = AppPath.Materials;
				saveFileDialog.Filter = "Marble Material Files (*.bumarblemats) |*.bumarblemats";
				saveFileDialog.FilterIndex = 1;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					ArrayList arrayList = new ArrayList();
					arrayList.AddRange(buMarbleCalc.MaterialList[indexMat].Parameters.ToDefAll("", 0, SerilizationMode5.MultiLine));
					buFile5.SaveToFile(arrayList, saveFileDialog.FileName);
					buCall.buMarbleCalc_0.GetMaterialListFromFiles(AppPath.Materials, ref buMarbleCalc.MaterialList);
					Class186.smethod_196(this);
				}
			}
			if (control.Name == btn_strategy.Name)
			{
				MenuButtonColors(0);
			}
			if (control.Name == btn_options.Name)
			{
				MenuButtonColors(1);
			}
			if (control.Name == btn_advanced.Name)
			{
				MenuButtonColors(2);
			}
			if (control.Name == btn_saw.Name)
			{
				MenuButtonColors(3);
			}
			if (control.Name == btn_milling.Name)
			{
				MenuButtonColors(4);
			}
			if (control.Name == btn_millinghead.Name)
			{
				MenuButtonColors(5);
			}
			if (control.Name == btn_material.Name)
			{
				MenuButtonColors(6);
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
		indexMat = buListBox_0.SelectedIndex;
		Class186.smethod_640(this);
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = sender as Control;
		List<string> FileNames = new List<string>();
		string text = "---------------";
		if (control is buControl)
		{
			buControl buControl2 = control as buControl;
			if (buControl2.Aux.HelpRefKey != null && buControl2.Aux.HelpRefKey.Length > 0)
			{
				if (AppBool.HelpMe)
				{
					AppBool.HelpMe = false;
					buFile5.GetFilesWithKeywordWithExtension(AppPath.HelpVideo, buControl2.Aux.HelpRefKey, "mp4", ref FileNames);
					if (FileNames.Count <= 0)
					{
					}
				}
				buFile5.GetFilesWithKeyword(AppPath.HelpImages, buControl2.Aux.HelpRefKey, ref FileNames);
				if (FileNames.Count > 0)
				{
					pictureBox_0.Image = Image.FromFile(FileNames[0]);
					string controlText = buControlCommands.GetControlText(control);
					if (controlText.Length > 0)
					{
						buLabel_6.Text = controlText + Environment.NewLine + text + Environment.NewLine;
					}
					return;
				}
			}
		}
		if (!(control.Name == radioButton_6.Name))
		{
			if (!(control.Name == radioButton_4.Name))
			{
				if (!(control.Name == radioButton_6.Name))
				{
					if (!(control.Name == radioButton_5.Name))
					{
						if (!(control.Name == radioButton_7.Name))
						{
							if (!(control.Name == radioButton_2.Name))
							{
								if (!(control.Name == radioButton_3.Name))
								{
									if (!((control.Name == radioButton_19.Name) | (control.Name == radioButton_23.Name) | (control.Name == radioButton_26.Name)))
									{
										if (!((control.Name == radioButton_18.Name) | (control.Name == radioButton_22.Name) | (control.Name == radioButton_25.Name)))
										{
											if (!(control.Name == radioButton_14.Name))
											{
												if (!(control.Name == radioButton_13.Name))
												{
													if (!(control.Name == radioButton_21.Name))
													{
														if (!(control.Name == radioButton_20.Name))
														{
															if (!(control.Name == radioButton_27.Name))
															{
																if (!(control.Name == radioButton_28.Name))
																{
																	if (!(control.Name == radioButton_29.Name))
																	{
																		if (!(control.Name == radioButton_17.Name))
																		{
																			if (!(control.Name == radioButton_16.Name))
																			{
																				if (!(control.Name == radioButton_15.Name))
																				{
																					buLabel_6.Text = buLangTranslate.preSentences.NoInformatonAvailable + Environment.NewLine + text;
																					pictureBox_0.Image = null;
																					return;
																				}
																				buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0035", ref FileNames);
																				if (FileNames.Count > 0)
																				{
																					pictureBox_0.Image = Image.FromFile(FileNames[0]);
																					string controlText2 = buControlCommands.GetControlText(control);
																					if (controlText2.Length > 0)
																					{
																						buLabel_6.Text = controlText2 + Environment.NewLine + text + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcNoOffset;
																					}
																				}
																				return;
																			}
																			buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0036", ref FileNames);
																			if (FileNames.Count > 0)
																			{
																				pictureBox_0.Image = Image.FromFile(FileNames[0]);
																				string controlText3 = buControlCommands.GetControlText(control);
																				if (controlText3.Length > 0)
																				{
																					buLabel_6.Text = controlText3 + Environment.NewLine + text + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcNoOffset;
																				}
																			}
																			return;
																		}
																		buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0034", ref FileNames);
																		if (FileNames.Count > 0)
																		{
																			pictureBox_0.Image = Image.FromFile(FileNames[0]);
																			string controlText4 = buControlCommands.GetControlText(control);
																			if (controlText4.Length > 0)
																			{
																				buLabel_6.Text = controlText4 + Environment.NewLine + text + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcNoOffset;
																			}
																		}
																		return;
																	}
																	buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0033", ref FileNames);
																	if (FileNames.Count > 0)
																	{
																		pictureBox_0.Image = Image.FromFile(FileNames[0]);
																		string controlText5 = buControlCommands.GetControlText(control);
																		if (controlText5.Length > 0)
																		{
																			buLabel_6.Text = controlText5 + Environment.NewLine + text + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcNoOffset;
																		}
																	}
																	return;
																}
																buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0032", ref FileNames);
																if (FileNames.Count > 0)
																{
																	pictureBox_0.Image = Image.FromFile(FileNames[0]);
																	string controlText6 = buControlCommands.GetControlText(control);
																	if (controlText6.Length > 0)
																	{
																		buLabel_6.Text = controlText6 + Environment.NewLine + text + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcOffset;
																	}
																}
																return;
															}
															buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0031", ref FileNames);
															if (FileNames.Count > 0)
															{
																pictureBox_0.Image = Image.FromFile(FileNames[0]);
																string controlText7 = buControlCommands.GetControlText(control);
																if (controlText7.Length > 0)
																{
																	buLabel_6.Text = controlText7 + Environment.NewLine + text + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcAAngle;
																}
															}
															return;
														}
														buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0014", ref FileNames);
														if (FileNames.Count > 0)
														{
															pictureBox_0.Image = Image.FromFile(FileNames[0]);
															string controlText8 = buControlCommands.GetControlText(control);
															if (controlText8.Length > 0)
															{
																buLabel_6.Text = controlText8 + Environment.NewLine + text;
															}
														}
														return;
													}
													buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0013", ref FileNames);
													if (FileNames.Count > 0)
													{
														pictureBox_0.Image = Image.FromFile(FileNames[0]);
														string controlText9 = buControlCommands.GetControlText(control);
														if (controlText9.Length > 0)
														{
															buLabel_6.Text = controlText9 + Environment.NewLine + text;
														}
													}
													return;
												}
												buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0012", ref FileNames);
												if (FileNames.Count > 0)
												{
													pictureBox_0.Image = Image.FromFile(FileNames[0]);
													string controlText10 = buControlCommands.GetControlText(control);
													if (controlText10.Length > 0)
													{
														buLabel_6.Text = controlText10 + Environment.NewLine + text;
													}
												}
												return;
											}
											buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0011", ref FileNames);
											if (FileNames.Count > 0)
											{
												pictureBox_0.Image = Image.FromFile(FileNames[0]);
												string controlText11 = buControlCommands.GetControlText(control);
												if (controlText11.Length > 0)
												{
													buLabel_6.Text = controlText11 + Environment.NewLine + text;
												}
											}
											return;
										}
										buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0010", ref FileNames);
										if (FileNames.Count > 0)
										{
											pictureBox_0.Image = Image.FromFile(FileNames[0]);
											string controlText12 = buControlCommands.GetControlText(control);
											if (controlText12.Length > 0)
											{
												buLabel_6.Text = controlText12 + Environment.NewLine + text;
											}
										}
										return;
									}
									buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0008", ref FileNames);
									if (FileNames.Count > 0)
									{
										pictureBox_0.Image = Image.FromFile(FileNames[0]);
										string controlText13 = buControlCommands.GetControlText(control);
										if (controlText13.Length > 0)
										{
											buLabel_6.Text = controlText13 + Environment.NewLine + text;
										}
									}
									return;
								}
								buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0038", ref FileNames);
								if (FileNames.Count > 0)
								{
									pictureBox_0.Image = Image.FromFile(FileNames[0]);
									string controlText14 = buControlCommands.GetControlText(control);
									if (controlText14.Length > 0)
									{
										buLabel_6.Text = controlText14 + Environment.NewLine + text;
									}
								}
								return;
							}
							buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0037", ref FileNames);
							if (FileNames.Count > 0)
							{
								pictureBox_0.Image = Image.FromFile(FileNames[0]);
								string controlText15 = buControlCommands.GetControlText(control);
								if (controlText15.Length > 0)
								{
									buLabel_6.Text = controlText15 + Environment.NewLine + text;
								}
							}
							return;
						}
						buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0039", ref FileNames);
						if (FileNames.Count > 0)
						{
							pictureBox_0.Image = Image.FromFile(FileNames[0]);
							string controlText16 = buControlCommands.GetControlText(control);
							if (controlText16.Length > 0)
							{
								buLabel_6.Text = controlText16 + Environment.NewLine + text;
							}
						}
						return;
					}
					buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0007", ref FileNames);
					if (FileNames.Count > 0)
					{
						pictureBox_0.Image = Image.FromFile(FileNames[0]);
						string controlText17 = buControlCommands.GetControlText(control);
						if (controlText17.Length > 0)
						{
							buLabel_6.Text = controlText17 + Environment.NewLine + text;
						}
					}
					return;
				}
				buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0005", ref FileNames);
				if (FileNames.Count > 0)
				{
					pictureBox_0.Image = Image.FromFile(FileNames[0]);
					string controlText18 = buControlCommands.GetControlText(control);
					if (controlText18.Length > 0)
					{
						buLabel_6.Text = controlText18 + Environment.NewLine + text;
					}
				}
				return;
			}
			buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0004", ref FileNames);
			if (FileNames.Count > 0)
			{
				pictureBox_0.Image = Image.FromFile(FileNames[0]);
				string controlText19 = buControlCommands.GetControlText(control);
				if (controlText19.Length > 0)
				{
					buLabel_6.Text = controlText19 + Environment.NewLine + text;
				}
			}
			return;
		}
		buFile5.GetFilesWithKeyword(AppPath.HelpImages, "H0003", ref FileNames);
		if (FileNames.Count > 0)
		{
			pictureBox_0.Image = Image.FromFile(FileNames[0]);
			string controlText20 = buControlCommands.GetControlText(control);
			if (controlText20.Length > 0)
			{
				buLabel_6.Text = controlText20 + Environment.NewLine + text + Environment.NewLine + buLangTranslate.preCaptionMarble.ConcaveCornerByDrillMilling;
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
