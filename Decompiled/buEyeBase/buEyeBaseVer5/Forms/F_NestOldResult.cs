using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_NestOldResult : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<string> NestedResultList = new List<string>();

	public string selectedItem = "";

	public string JobFolder = Application.StartupPath;

	public string FileExtension = "bunesting";

	public buNestingVar Settings = new buNestingVar();

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_close;

	public Button btn_select;

	internal ListBox listBox_0;

	internal TextBox textBox_0;

	internal Label label_0;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal RadioButton radioButton_0;

	internal Panel panel_0;

	internal Label label_1;

	internal Panel panel_1;

	internal RadioButton radioButton_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal CheckBox checkBox_3;

	internal CheckBox checkBox_4;

	public Button btn_preview;

	public event OkCommandWithDataEventHandler PreviewPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public F_NestOldResult()
	{
		Class186.smethod_730(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		LoadLanguage();
		listBox_0.Items.Clear();
		for (int i = 0; i <= NestedResultList.Count - 1; i++)
		{
			listBox_0.Items.Add(NestedResultList[i]);
		}
		checkBox_0.Checked = Settings.Runtime.OldResultImportNestedResult;
		checkBox_2.Checked = Settings.Runtime.OldResultImportNestingParts;
		checkBox_1.Checked = Settings.Runtime.OldResultImportNestingSheets;
		checkBox_3.Checked = Settings.Runtime.OldResultImportNestingClearParts;
		checkBox_4.Checked = Settings.Runtime.OldResultImportNestingClearSheets;
		if (Settings.Runtime.OldResultLocation != nestOldResultPosition.ToJob)
		{
			radioButton_1.Checked = false;
			radioButton_0.Checked = true;
		}
		else
		{
			radioButton_1.Checked = true;
			radioButton_0.Checked = false;
		}
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "NestOnlineCalculation LoadLanguage";
		try
		{
			if (Captions.Count >= 6)
			{
				Text = Captions[0];
				label_0.Text = Captions[1];
				label_1.Text = Captions[2];
				label_3.Text = Captions[3];
				checkBox_0.Text = Captions[4];
				label_5.Text = Captions[5];
				checkBox_1.Text = Captions[6];
				checkBox_4.Text = Captions[7];
				label_4.Text = Captions[8];
				checkBox_2.Text = Captions[9];
				checkBox_3.Text = Captions[10];
				label_2.Text = Captions[11];
				radioButton_0.Text = Captions[12];
				radioButton_1.Text = Captions[13];
				btn_preview.Text = Captions[14];
				btn_select.Text = Captions[15];
				btn_close.Text = Captions[16];
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
		if (control.Name == btn_select.Name)
		{
			selectedItem = listBox_0.Items[listBox_0.SelectedIndex].ToString();
			Settings.Runtime.OldResultImportNestedResult = checkBox_0.Checked;
			Settings.Runtime.OldResultImportNestingParts = checkBox_2.Checked;
			Settings.Runtime.OldResultImportNestingSheets = checkBox_1.Checked;
			Settings.Runtime.OldResultImportNestingClearParts = checkBox_3.Checked;
			Settings.Runtime.OldResultImportNestingClearSheets = checkBox_4.Checked;
			if (!radioButton_1.Checked)
			{
				Settings.Runtime.OldResultLocation = nestOldResultPosition.ToDrawing;
			}
			else
			{
				Settings.Runtime.OldResultLocation = nestOldResultPosition.ToJob;
			}
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
		if (control.Name == btn_close.Name)
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
		if (control.Name == btn_preview.Name && okCommandWithDataEventHandler_0 != null && ((listBox_0.SelectedIndex >= 0) & (listBox_0.Items.Count > 0)))
		{
			selectedItem = JobFolder + "\\" + listBox_0.Items[listBox_0.SelectedIndex].ToString() + "." + FileExtension;
			okCommandWithDataEventHandler_0(selectedItem);
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
