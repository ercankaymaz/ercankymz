using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Profile;

public class F_NotchCamSettings : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public ProfileOperationData OperationData = new ProfileOperationData();

	public camParameters CamPar = new camParameters();

	private IContainer icontainer_0 = null;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	internal Panel panel_0;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal Label label_0;

	internal Panel panel_1;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Label label_1;

	public NumericUpDown spn_vellfeed;

	internal Label label_2;

	public NumericUpDown spn_velplunge;

	internal Label label_3;

	internal Label label_4;

	public NumericUpDown spn_disair;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	public NumericUpDown spn_dissafe;

	internal Panel panel_2;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	public F_NotchCamSettings()
	{
		Class76.smethod_12(this);
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
		spn_disair.Value = (decimal)CamPar.Distances.Air;
		spn_dissafe.Value = (decimal)CamPar.Distances.Safe;
		if (OperationData.NotchData.NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
		{
			radioButton_3.Checked = true;
			radioButton_2.Checked = false;
		}
		if (OperationData.NotchData.NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
		{
			radioButton_3.Checked = false;
			radioButton_2.Checked = true;
		}
		if (OperationData.NotchData.NotchCutType == ProfileNotchCutType.BySawAndMilling)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
		}
		if (OperationData.NotchData.NotchCutType == ProfileNotchCutType.BySaw)
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
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
			Class76.smethod_16(this);
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
