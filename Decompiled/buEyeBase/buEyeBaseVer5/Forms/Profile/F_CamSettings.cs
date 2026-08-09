using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_CamSettings : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public camParameters5 CamPar = new camParameters5();

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Label label_0;

	public NumericUpDown spn_areaclearancevelocity;

	internal Label label_1;

	public NumericUpDown spn_finishvelocity;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	public NumericUpDown spn_velplunge;

	internal Label label_5;

	public NumericUpDown spn_vellfeed;

	internal Label label_6;

	internal Label label_7;

	internal Panel panel_1;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal PictureBox pictureBox_3;

	internal Label label_8;

	public NumericUpDown spn_stepstep;

	internal Label label_9;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal PictureBox pictureBox_4;

	internal Label label_10;

	internal Label label_11;

	internal NumericUpDown numericUpDown_0;

	internal Label label_12;

	public NumericUpDown spn_stepcount;

	internal CheckBox checkBox_0;

	internal Label label_13;

	internal CheckBox checkBox_1;

	internal Label label_14;

	internal CheckBox checkBox_2;

	internal Label label_15;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal Panel panel_2;

	internal Panel panel_3;

	internal RadioButton radioButton_4;

	internal Label label_16;

	internal RadioButton radioButton_5;

	internal RadioButton radioButton_6;

	internal PictureBox pictureBox_5;

	internal Panel panel_4;

	internal RadioButton radioButton_7;

	internal Label label_17;

	internal RadioButton radioButton_8;

	internal RadioButton radioButton_9;

	internal Label label_18;

	internal Label label_19;

	public NumericUpDown spn_finishoffset;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal CheckBox checkBox_3;

	internal Label label_20;

	internal Label label_21;

	public NumericUpDown spn_dissmallsafe;

	internal Label label_22;

	public NumericUpDown spn_dissafe;

	public NumericUpDown spn_disapproach;

	internal Label label_23;

	internal Label label_24;

	public NumericUpDown spn_spindlespeed;

	internal CheckBox checkBox_4;

	internal Label label_25;

	internal CheckBox checkBox_5;

	internal Label label_26;

	internal Label label_27;

	internal PictureBox pictureBox_6;

	internal Panel panel_5;

	internal RadioButton radioButton_10;

	internal RadioButton radioButton_11;

	internal RadioButton radioButton_12;

	internal Label label_28;

	public NumericUpDown spn_overlap;

	internal Label label_29;

	internal PictureBox pictureBox_7;

	internal Label label_30;

	public NumericUpDown spn_depthup;

	internal Label label_31;

	public F_CamSettings()
	{
		Class186.smethod_328(this);
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
		spn_spindlespeed.Value = (decimal)CamPar.Speeds.SpindleSpeed;
		spn_vellfeed.Value = (decimal)CamPar.Speeds.Feed;
		spn_velplunge.Value = (decimal)CamPar.Speeds.Plunge;
		spn_finishvelocity.Value = (decimal)CamPar.Speeds.Finish;
		spn_areaclearancevelocity.Value = (decimal)CamPar.Speeds.AreaClearance;
		spn_disapproach.Value = (decimal)CamPar.Distances.FirstApproach;
		spn_dissafe.Value = (decimal)CamPar.Distances.Safe;
		spn_dissmallsafe.Value = (decimal)CamPar.Distances.Rapid;
		spn_finishoffset.Value = (decimal)CamPar.Offsets.FinishOffset;
		spn_depthup.Value = (decimal)CamPar.Operations.DepthUp;
		spn_stepstep.Value = (decimal)CamPar.Steps.Step;
		spn_stepcount.Value = CamPar.Steps.Count;
		numericUpDown_0.Value = (decimal)CamPar.Pockets.StepOverPersentage;
		checkBox_1.Checked = CamPar.Operations.AreaClearanceEnable;
		checkBox_2.Checked = CamPar.Operations.FinishEnable;
		checkBox_0.Checked = CamPar.Steps.Enable;
		checkBox_3.Checked = CamPar.Strategy.OpenContourTwoDirectionCut;
		checkBox_2.Checked = CamPar.Speeds.FinishEnable;
		checkBox_1.Checked = CamPar.Speeds.AreaClearanceEnable;
		checkBox_5.Checked = CamPar.LeadIn.Enable;
		checkBox_4.Checked = CamPar.LeadOut.Enable;
		spn_overlap.Value = (decimal)CamPar.Operations.Overlap;
		if (CamPar.Pockets.PocketType != CamPocketType.WfbRghtOffset)
		{
			if (CamPar.Pockets.PocketType != CamPocketType.WfbRghtParallel)
			{
				radioButton_10.Checked = true;
				radioButton_12.Checked = false;
				radioButton_11.Checked = false;
			}
			else
			{
				radioButton_10.Checked = false;
				radioButton_12.Checked = false;
				radioButton_11.Checked = true;
			}
		}
		else
		{
			radioButton_10.Checked = false;
			radioButton_12.Checked = true;
			radioButton_11.Checked = false;
		}
		if (CamPar.Operations.AreaClearanceDirection != InToOutType.OutToIn)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
		}
		else
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
		}
		if (CamPar.Operations.Direction == ClockDirectionType.CW)
		{
			radioButton_3.Checked = true;
			radioButton_2.Checked = false;
		}
		if (CamPar.Operations.Direction == ClockDirectionType.CCW)
		{
			radioButton_3.Checked = false;
			radioButton_2.Checked = true;
		}
		if (CamPar.Offsets.ClosedContour == CamClosedContourType.Inner)
		{
			radioButton_5.Checked = false;
			radioButton_4.Checked = false;
			radioButton_6.Checked = true;
		}
		if (CamPar.Offsets.ClosedContour == CamClosedContourType.Outter)
		{
			radioButton_5.Checked = false;
			radioButton_4.Checked = true;
			radioButton_6.Checked = false;
		}
		if (CamPar.Offsets.ClosedContour == CamClosedContourType.Center)
		{
			radioButton_5.Checked = true;
			radioButton_4.Checked = false;
			radioButton_6.Checked = false;
		}
		if (CamPar.Offsets.OpenContour != CamOpenContourType.Center)
		{
			if (CamPar.Offsets.OpenContour != CamOpenContourType.Left)
			{
				radioButton_8.Checked = false;
				radioButton_9.Checked = false;
				radioButton_7.Checked = true;
			}
			else
			{
				radioButton_8.Checked = false;
				radioButton_9.Checked = true;
				radioButton_7.Checked = false;
			}
		}
		else
		{
			radioButton_8.Checked = true;
			radioButton_9.Checked = false;
			radioButton_7.Checked = false;
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
			if (Captions.Count >= 1)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class186.smethod_230(this);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
