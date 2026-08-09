using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_NotchCamSettings : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public camParameters5 CamPar = new camParameters5();

	internal IContainer icontainer_0 = null;

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

	internal Label label_5;

	internal Label label_6;

	public NumericUpDown spn_dissafe;

	internal Panel panel_2;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal Panel panel_3;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	internal PictureBox pictureBox_3;

	internal Label label_7;

	internal PictureBox pictureBox_4;

	internal Label label_8;

	internal Label label_9;

	public NumericUpDown spn_toolpersentage;

	internal Label label_10;

	public NumericUpDown spn_spindlespeed;

	internal CheckBox checkBox_0;

	public F_NotchCamSettings()
	{
		Class186.smethod_260(this);
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
		spn_toolpersentage.Value = (decimal)CamPar.Notch.NotchCutPersentage;
		spn_dissafe.Value = (decimal)CamPar.Distances.Safe;
		spn_spindlespeed.Value = (decimal)CamPar.Speeds.SpindleSpeed;
		checkBox_0.Checked = CamPar.Speeds.SpindleEnable;
		if (CamPar.Notch.NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
		{
			radioButton_3.Checked = true;
			radioButton_2.Checked = false;
		}
		if (CamPar.Notch.NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
		{
			radioButton_3.Checked = false;
			radioButton_2.Checked = true;
		}
		if (CamPar.Notch.NotchCutType == ProfileNotchCutType.BySawAndMilling)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
		}
		if (CamPar.Notch.NotchCutType == ProfileNotchCutType.BySaw)
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
		}
		if (CamPar.Notch.CutDirection == UpDownDirectionType.UpToDown)
		{
			radioButton_5.Checked = true;
			radioButton_4.Checked = false;
		}
		if (CamPar.Notch.CutDirection == UpDownDirectionType.DownToUp)
		{
			radioButton_5.Checked = false;
			radioButton_4.Checked = true;
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
			Class186.smethod_191(this);
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
