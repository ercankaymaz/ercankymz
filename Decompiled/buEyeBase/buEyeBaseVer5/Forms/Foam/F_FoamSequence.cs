using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamSequence : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public FoamSequenceHor SequenceHor = FoamSequenceHor.HorizontalStartThenEnd;

	public FoamSequenceVer SequenceVer = FoamSequenceVer.VerticalStartThenEnd;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal PictureBox pictureBox_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal PictureBox pictureBox_1;

	internal Label label_0;

	internal Panel panel_0;

	internal Panel panel_1;

	internal Label label_1;

	internal PictureBox pictureBox_2;

	internal PictureBox pictureBox_3;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal ImageList imageList_2;

	internal PictureBox pictureBox_4;

	internal RadioButton radioButton_4;

	public F_FoamSequence()
	{
		Class186.smethod_169(this);
		pictureBox_0.Image = imageList_1.Images[0];
		pictureBox_1.Image = imageList_1.Images[1];
		pictureBox_4.Image = imageList_1.Images[2];
		pictureBox_3.Image = imageList_2.Images[0];
		pictureBox_2.Image = imageList_2.Images[1];
	}

	public void Init()
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
		ControlUpdate();
		LoadLanguage();
		if (SequenceHor != FoamSequenceHor.HorizontalStartThenEnd)
		{
			if (SequenceHor != FoamSequenceHor.HorizontalStartThenStart)
			{
				if (SequenceHor == FoamSequenceHor.HorizontalStartThenStartDirect)
				{
					radioButton_4.Checked = true;
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
		if (SequenceVer != FoamSequenceVer.VerticalStartThenEnd)
		{
			if (SequenceVer == FoamSequenceVer.VerticalStartThenStart)
			{
				radioButton_2.Checked = true;
			}
		}
		else
		{
			radioButton_3.Checked = true;
		}
		label_1.Text = buCall.buFoamCalc_0.SequenceToExplanation(SequenceVer);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			if (Captions.Count >= 9)
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

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
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
		Control control = new Control();
		control = (Control)sender;
		if (!(control.Name == btn_ok.Name))
		{
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
		}
		else
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
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (radioButton_0.Checked)
		{
			SequenceHor = FoamSequenceHor.HorizontalStartThenEnd;
			label_0.Text = buCall.buFoamCalc_0.SequenceToExplanation(SequenceHor);
		}
		if (radioButton_1.Checked)
		{
			SequenceHor = FoamSequenceHor.HorizontalStartThenStart;
			label_0.Text = buCall.buFoamCalc_0.SequenceToExplanation(SequenceHor);
		}
		if (radioButton_4.Checked)
		{
			SequenceHor = FoamSequenceHor.HorizontalStartThenStartDirect;
			label_0.Text = buCall.buFoamCalc_0.SequenceToExplanation(SequenceHor);
		}
		if (radioButton_3.Checked)
		{
			SequenceVer = FoamSequenceVer.VerticalStartThenEnd;
			label_0.Text = buCall.buFoamCalc_0.SequenceToExplanation(SequenceVer);
		}
		if (radioButton_2.Checked)
		{
			SequenceVer = FoamSequenceVer.VerticalStartThenStart;
			label_0.Text = buCall.buFoamCalc_0.SequenceToExplanation(SequenceVer);
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
