using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_PostProcessorSelect : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<FileEventArg> PostNameList = new List<FileEventArg>();

	public string ExistingPostName = "";

	public string pathPost = Application.StartupPath;

	private int int_0 = -1;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal ListBox listBox_0;

	public Button btn_open;

	public F_PostProcessorSelect()
	{
		Class186.smethod_603(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		int_0 = -1;
		listBox_0.Items.Clear();
		for (int i = 0; i <= PostNameList.Count - 1; i++)
		{
			if (PostNameList[i].JustFileName.Trim() == ExistingPostName)
			{
				int_0 = i;
			}
			listBox_0.Items.Add(PostNameList[i].JustFileName);
		}
		if (int_0 >= 0)
		{
			listBox_0.SelectedIndex = int_0;
		}
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "NestSheetPart LoadLanguage";
		try
		{
			if (Captions.Count >= 33)
			{
				Text = Captions[0];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	public void Apply()
	{
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		if ((sender.GetType() == typeof(Control)) | (sender.GetType() == typeof(Button)))
		{
			control = (Control)sender;
			_ = control.Name;
		}
		if (sender.GetType() == typeof(ToolStripMenuItem))
		{
			_ = ((ToolStripMenuItem)sender).Name;
		}
		if (control.Name == button_0.Name)
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
		if (control.Name == button_1.Name)
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
		if (control.Name == btn_open.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = pathPost;
			openFileDialog.Filter = "Kinematic File (*.bupost)|*.bupost";
			openFileDialog.Multiselect = false;
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				pathPost = buFile5.GetPath(openFileDialog.FileName);
				ExistingPostName = buFile5.getFileName(openFileDialog.FileName);
				method_0(button_0, e);
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited && listBox_0.SelectedIndex >= 0)
		{
			int_0 = listBox_0.SelectedIndex;
			ExistingPostName = listBox_0.Items[int_0].ToString();
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
