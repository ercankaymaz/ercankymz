using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Tufting;

public class F_TuftingFill : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public TuftingSettings Settings = new TuftingSettings();

	public List<string> LayerNames = new List<string>();

	public int SelectedLayerIndex = 0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	internal Panel panel_0;

	internal Label label_0;

	internal Button button_0;

	public Button btn_ok;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal ComboBox comboBox_0;

	internal Label label_1;

	internal RadioButton radioButton_3;

	public F_TuftingFill()
	{
		Class76.smethod_474(this);
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
		comboBox_0.Items.Clear();
		for (int i = 0; i <= LayerNames.Count - 1; i++)
		{
			comboBox_0.Items.Add(LayerNames[i]);
		}
		if ((comboBox_0.Items.Count > 0) & (SelectedLayerIndex <= comboBox_0.Items.Count - 1))
		{
			comboBox_0.SelectedIndex = SelectedLayerIndex;
		}
		if (Settings.FillType != tuftingFillOffsetType.Contour)
		{
			if (Settings.FillType != tuftingFillOffsetType.Spiral)
			{
				if (Settings.FillType != tuftingFillOffsetType.Straight)
				{
					if (Settings.FillType == tuftingFillOffsetType.Trace)
					{
						radioButton_3.Checked = true;
					}
				}
				else
				{
					radioButton_0.Checked = true;
				}
			}
			else
			{
				radioButton_2.Checked = true;
			}
		}
		else
		{
			radioButton_1.Checked = true;
		}
		ControlUpdate();
		LoadLanguage();
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
		if (control.Name == btn_ok.Name)
		{
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
			SelectedLayerIndex = comboBox_0.SelectedIndex;
			if (!radioButton_1.Checked)
			{
				if (!radioButton_2.Checked)
				{
					if (!radioButton_0.Checked)
					{
						if (radioButton_3.Checked)
						{
							Settings.FillType = tuftingFillOffsetType.Trace;
						}
					}
					else
					{
						Settings.FillType = tuftingFillOffsetType.Straight;
					}
				}
				else
				{
					Settings.FillType = tuftingFillOffsetType.Spiral;
				}
			}
			else
			{
				Settings.FillType = tuftingFillOffsetType.Contour;
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
		if (!(control.Name == button_0.Name))
		{
			return;
		}
		if (!radioButton_2.Checked)
		{
			if (!radioButton_0.Checked)
			{
				if (!radioButton_3.Checked)
				{
					if (radioButton_1.Checked)
					{
						F_TuftingCounterSettings f_TuftingCounterSettings = new F_TuftingCounterSettings();
						f_TuftingCounterSettings.Settings = new TuftingSettings(Settings);
						f_TuftingCounterSettings.Init();
						f_TuftingCounterSettings.ShowDialog();
						if (f_TuftingCounterSettings.PropertiesForm.Result == DialogResult.OK)
						{
							Settings = new TuftingSettings(f_TuftingCounterSettings.Settings);
						}
					}
				}
				else
				{
					F_TuftingTraceSettings f_TuftingTraceSettings = new F_TuftingTraceSettings();
					f_TuftingTraceSettings.Settings = new TuftingSettings(Settings);
					f_TuftingTraceSettings.Init();
					f_TuftingTraceSettings.ShowDialog();
					if (f_TuftingTraceSettings.PropertiesForm.Result == DialogResult.OK)
					{
						Settings = new TuftingSettings(f_TuftingTraceSettings.Settings);
					}
				}
			}
			else
			{
				F_TuftingStraightSettings f_TuftingStraightSettings = new F_TuftingStraightSettings();
				f_TuftingStraightSettings.Settings = new TuftingSettings(Settings);
				f_TuftingStraightSettings.Init();
				f_TuftingStraightSettings.ShowDialog();
				if (f_TuftingStraightSettings.PropertiesForm.Result == DialogResult.OK)
				{
					Settings = new TuftingSettings(f_TuftingStraightSettings.Settings);
				}
			}
		}
		else
		{
			F_TuftingSpiralSettings f_TuftingSpiralSettings = new F_TuftingSpiralSettings();
			f_TuftingSpiralSettings.Settings = new TuftingSettings(Settings);
			f_TuftingSpiralSettings.Init();
			f_TuftingSpiralSettings.ShowDialog();
			if (f_TuftingSpiralSettings.PropertiesForm.Result == DialogResult.OK)
			{
				Settings = new TuftingSettings(f_TuftingSpiralSettings.Settings);
			}
		}
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
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
