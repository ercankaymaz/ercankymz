using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Cam;

public class F_CamSequence : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<string> SourceList = new List<string>();

	public List<string> TargetList = new List<string>();

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ListBox listBox_0;

	internal ListBox listBox_1;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	public F_CamSequence()
	{
		Class186.smethod_473(this);
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
		listBox_0.Items.Clear();
		for (int i = 0; i <= SourceList.Count - 1; i++)
		{
			listBox_0.Items.Add(SourceList[i]);
		}
		listBox_1.Items.Clear();
		for (int j = 0; j <= TargetList.Count - 1; j++)
		{
			listBox_1.Items.Add(TargetList[j]);
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
			Class186.smethod_581(this);
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
		if (control.Name == button_0.Name && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= listBox_0.Items.Count - 1)))
		{
			string text = listBox_0.Items[listBox_0.SelectedIndex].ToString();
			bool flag = false;
			for (int i = 0; i <= listBox_1.Items.Count - 1; i++)
			{
				if (text == listBox_1.Items[i].ToString())
				{
					flag = true;
				}
			}
			if (!flag)
			{
				listBox_1.Items.Add(text);
			}
		}
		if (control.Name == button_1.Name && ((listBox_1.SelectedIndex >= 0) & (listBox_1.SelectedIndex <= listBox_1.Items.Count - 1)) && buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[132]) == DialogResult.Yes)
		{
			listBox_1.Items.RemoveAt(listBox_1.SelectedIndex);
		}
		if (control.Name == button_2.Name && ((listBox_1.Items.Count >= 0) & (listBox_1.SelectedIndex > 0) & (listBox_1.SelectedIndex <= listBox_1.Items.Count - 1)))
		{
			int selectedIndex = listBox_1.SelectedIndex;
			string item = listBox_1.Items[selectedIndex].ToString();
			listBox_1.Items.RemoveAt(selectedIndex);
			selectedIndex--;
			listBox_1.Items.Insert(selectedIndex, item);
			listBox_1.SelectedIndex = selectedIndex;
		}
		if (control.Name == button_3.Name && ((listBox_1.Items.Count >= 0) & (listBox_1.SelectedIndex <= listBox_1.Items.Count - 2) & (listBox_1.SelectedIndex <= listBox_1.Items.Count - 1)))
		{
			int selectedIndex2 = listBox_1.SelectedIndex;
			string item2 = listBox_1.Items[selectedIndex2].ToString();
			listBox_1.Items.RemoveAt(selectedIndex2);
			selectedIndex2++;
			listBox_1.Items.Insert(selectedIndex2, item2);
			listBox_1.SelectedIndex = selectedIndex2;
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
