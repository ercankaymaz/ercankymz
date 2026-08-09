using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Cam;

public class F_CamSettings1 : Form
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

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_9;

	internal NumericUpDown numericUpDown_0;

	internal Label label_10;

	public NumericUpDown spn_stepcount;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal Panel panel_2;

	internal Panel panel_3;

	internal RadioButton radioButton_4;

	internal Label label_11;

	internal RadioButton radioButton_5;

	internal RadioButton radioButton_6;

	internal Panel panel_4;

	internal RadioButton radioButton_7;

	internal Label label_12;

	internal RadioButton radioButton_8;

	internal RadioButton radioButton_9;

	internal Label label_13;

	internal Label label_14;

	public NumericUpDown spn_finishoffset;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal CheckBox checkBox_2;

	internal Label label_15;

	internal Label label_16;

	public NumericUpDown spn_dissmallsafe;

	internal Label label_17;

	public NumericUpDown spn_dissafe;

	internal Label label_18;

	internal CheckBox checkBox_3;

	public NumericUpDown spn_velleave;

	internal Label label_19;

	internal PictureBox pictureBox_4;

	internal Label label_20;

	public NumericUpDown spn_leadin;

	internal Label label_21;

	public NumericUpDown spn_leadout;

	public F_CamSettings1()
	{
		Class186.smethod_757(this);
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
		spn_vellfeed.Value = (decimal)CamPar.Speeds.Feed;
		spn_velplunge.Value = (decimal)CamPar.Speeds.Plunge;
		spn_velleave.Value = (decimal)CamPar.Speeds.Leave;
		spn_finishvelocity.Value = (decimal)CamPar.Speeds.Finish;
		spn_areaclearancevelocity.Value = (decimal)CamPar.Speeds.Pocket;
		spn_dissafe.Value = (decimal)CamPar.Distances.Safe;
		spn_dissmallsafe.Value = (decimal)CamPar.Distances.Rapid;
		spn_finishoffset.Value = (decimal)CamPar.Offsets.FinishOffset;
		spn_stepcount.Value = CamPar.Steps.NumberOfSlice;
		numericUpDown_0.Value = (decimal)CamPar.Pockets.StepOverPersentage;
		spn_leadin.Value = (decimal)CamPar.LeadIn.Length;
		spn_leadout.Value = (decimal)CamPar.LeadOut.Length;
		checkBox_1.Checked = CamPar.Pockets.Enable;
		checkBox_3.Checked = CamPar.Operations.FinishEnable;
		checkBox_0.Checked = CamPar.Steps.Enable;
		checkBox_2.Checked = CamPar.Strategy.OpenContourTwoDirectionCut;
		checkBox_3.Checked = CamPar.Speeds.FinishEnable;
		if (CamPar.Pockets.PocketInOut != InToOutType.OutToIn)
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
			Class186.smethod_116(this);
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
