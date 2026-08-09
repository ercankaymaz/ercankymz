using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileMirror : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public ProfileMirror MirrorData = new ProfileMirror();

	public bool YDirectionFrontBack = false;

	internal IContainer icontainer_0 = null;

	public Label label4;

	public NumericUpDown spn_dis;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal Panel panel_1;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal Panel panel_2;

	public Panel panel4;

	internal RadioButton radioButton_5;

	internal RadioButton radioButton_6;

	internal CheckBox checkBox_0;

	public F_ProfileMirror()
	{
		Class186.smethod_164(this);
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
		checkBox_0.Checked = YDirectionFrontBack;
		spn_dis.Value = (decimal)MirrorData.MirrorDistance;
		if (MirrorData.MirrorAxis != MirrorAxisXYType.X)
		{
			radioButton_3.Checked = false;
			radioButton_4.Checked = true;
		}
		else
		{
			radioButton_3.Checked = true;
			radioButton_4.Checked = false;
		}
		if (MirrorData.MirrorLocation != MinCenterMaxType.Min)
		{
			if (MirrorData.MirrorLocation != MinCenterMaxType.Center)
			{
				if (MirrorData.MirrorLocation == MinCenterMaxType.Max)
				{
					radioButton_1.Checked = false;
					radioButton_2.Checked = false;
					radioButton_0.Checked = true;
				}
			}
			else
			{
				radioButton_1.Checked = false;
				radioButton_2.Checked = true;
				radioButton_0.Checked = false;
			}
		}
		else
		{
			radioButton_1.Checked = true;
			radioButton_2.Checked = false;
			radioButton_0.Checked = false;
		}
		if (MirrorData.Mode != MirrorModeType.FromCenter)
		{
			radioButton_5.Checked = false;
			radioButton_6.Checked = true;
			panel_2.Enabled = true;
		}
		else
		{
			radioButton_5.Checked = true;
			radioButton_6.Checked = false;
			panel_2.Enabled = false;
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
			Class186.smethod_335(this);
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

	internal void method_2(object sender, EventArgs e)
	{
		if (!radioButton_5.Checked)
		{
			panel_2.Enabled = true;
		}
		else
		{
			panel_2.Enabled = false;
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
