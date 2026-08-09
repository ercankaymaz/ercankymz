using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms.Holes;

public class F_CabinetSettings : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public DrillRuntimeSettings Settings = new DrillRuntimeSettings();

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal Label label_0;

	internal TextBox textBox_0;

	internal TextBox textBox_1;

	internal Label label_1;

	internal TextBox textBox_2;

	internal Label label_2;

	internal Button button_0;

	internal Button button_1;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal CheckBox checkBox_2;

	internal Label label_6;

	internal CheckBox checkBox_3;

	internal Button button_2;

	internal TextBox textBox_3;

	internal Label label_7;

	internal TextBox textBox_4;

	internal Label label_8;

	internal Label label_9;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_10;

	internal Label label_11;

	internal CheckBox checkBox_4;

	internal Label label_12;

	internal ComboBox comboBox_0;

	public F_CabinetSettings()
	{
		Class186.smethod_220(this);
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
		if (Settings.ErpFileType != drillErpFileType.Cabinet)
		{
			if (Settings.ErpFileType != drillErpFileType.Corpus)
			{
				if (Settings.ErpFileType == drillErpFileType.Cyncly)
				{
					comboBox_0.SelectedIndex = 2;
				}
			}
			else
			{
				comboBox_0.SelectedIndex = 1;
			}
		}
		else
		{
			comboBox_0.SelectedIndex = 0;
		}
		ControlUpdate();
		LoadLanguage();
		textBox_0.Text = Settings.CabinetReferanceKey;
		textBox_4.Text = Settings.CabinetAutoFileExtension;
		textBox_1.Text = Settings.CabinetpathImport;
		textBox_2.Text = Settings.CabinetpathExport;
		textBox_3.Text = Settings.CabinetpathDeleted;
		checkBox_1.Checked = Settings.CabinetShowInfo;
		checkBox_0.Checked = Settings.CabinetSubFolder;
		checkBox_3.Checked = Settings.CabinetMirrorIfNoClamperSideAvailable;
		checkBox_2.Checked = Settings.CabinetMirrorIfSlotClamperSide;
		checkBox_4.Checked = Settings.CabinetAutoCycleDeleteAndMove;
		numericUpDown_1.Value = Settings.CabinetAutoCycleTickDelayMs;
		numericUpDown_0.Value = Settings.CabinetAutoCycleTickMs;
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
		Settings.CabinetReferanceKey = textBox_0.Text;
		Settings.CabinetpathImport = textBox_1.Text;
		Settings.CabinetpathExport = textBox_2.Text;
		Settings.CabinetpathDeleted = textBox_3.Text;
		Settings.CabinetShowInfo = checkBox_1.Checked;
		Settings.CabinetSubFolder = checkBox_0.Checked;
		Settings.CabinetMirrorIfNoClamperSideAvailable = checkBox_3.Checked;
		Settings.CabinetMirrorIfSlotClamperSide = checkBox_2.Checked;
		Settings.CabinetAutoFileExtension = textBox_4.Text;
		Settings.CabinetAutoCycleDeleteAndMove = checkBox_4.Checked;
		Settings.CabinetAutoCycleTickDelayMs = (int)numericUpDown_1.Value;
		Settings.CabinetAutoCycleTickMs = (int)numericUpDown_0.Value;
		if (comboBox_0.SelectedIndex != 0)
		{
			if (comboBox_0.SelectedIndex != 1)
			{
				if (comboBox_0.SelectedIndex == 2)
				{
					Settings.ErpFileType = drillErpFileType.Cyncly;
				}
			}
			else
			{
				Settings.ErpFileType = drillErpFileType.Corpus;
			}
		}
		else
		{
			Settings.ErpFileType = drillErpFileType.Cabinet;
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
		if (!(control.Name == btn_ok.Name))
		{
			if (!(control.Name == btn_cancel.Name))
			{
				if (control.Name == button_0.Name)
				{
					FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
					folderBrowserDialog.SelectedPath = Settings.CabinetpathImport;
					if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
					{
						Settings.CabinetpathImport = folderBrowserDialog.SelectedPath;
						textBox_1.Text = Settings.CabinetpathImport;
					}
				}
				if (control.Name == button_1.Name)
				{
					FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog();
					folderBrowserDialog2.SelectedPath = Settings.CabinetpathExport;
					if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
					{
						Settings.CabinetpathExport = folderBrowserDialog2.SelectedPath;
						textBox_2.Text = Settings.CabinetpathExport;
					}
				}
				if (control.Name == button_2.Name)
				{
					FolderBrowserDialog folderBrowserDialog3 = new FolderBrowserDialog();
					folderBrowserDialog3.SelectedPath = Settings.CabinetpathDeleted;
					if (folderBrowserDialog3.ShowDialog() == DialogResult.OK)
					{
						Settings.CabinetpathDeleted = folderBrowserDialog3.SelectedPath;
						textBox_3.Text = Settings.CabinetpathDeleted;
					}
				}
			}
			else
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
