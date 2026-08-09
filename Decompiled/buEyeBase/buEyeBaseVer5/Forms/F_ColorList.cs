using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_ColorList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<Color> ColorList = new List<Color>();

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	internal Label label_12;

	internal Label label_13;

	internal Label label_14;

	internal Label label_15;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_16;

	internal Label label_17;

	internal Label label_18;

	internal Label label_19;

	internal Label label_20;

	internal Label label_21;

	internal Label label_22;

	internal Label label_23;

	internal Label label_24;

	internal Label label_25;

	internal Label label_26;

	internal Label label_27;

	internal Label label_28;

	internal Label label_29;

	internal Label label_30;

	internal Label label_31;

	public F_ColorList()
	{
		Class186.smethod_518(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		for (int i = 0; i <= base.Controls.Count - 1; i++)
		{
			if (base.Controls[i] is Label && base.Controls[i].Tag != null && buNumeric5.IsNumeric(base.Controls[i].Tag.ToString()))
			{
				int num = -1;
				num = int.Parse(base.Controls[i].Tag.ToString());
				if ((num >= 0) & (num <= buImage5.ColorList.Count - 1))
				{
					base.Controls[i].BackColor = buImage5.ColorList[num];
					base.Controls[i].ForeColor = buImage5.InvertColorNoGray(buImage5.ColorList[num]);
					base.Controls[i].Text = buImage5.GetColorKnownName(buImage5.ColorList[num]);
				}
			}
		}
		PropertiesForm.Inited = false;
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

	internal void method_1(object sender, EventArgs e)
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
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Tag == null || !buNumeric5.IsNumeric(control.Tag.ToString()))
		{
			return;
		}
		int num = -1;
		num = int.Parse(control.Tag.ToString());
		if ((num >= 0) & (num <= buImage5.ColorList.Count - 1))
		{
			ColorDialogBox.ShowDialog(buImage5.ColorList[num]);
			if (ColorDialogBox.Result == DialogResult.OK)
			{
				buImage5.ColorList[num] = ColorDialogBox.Color;
				control.BackColor = ColorDialogBox.Color;
				control.ForeColor = buImage5.InvertColorNoGray(control.BackColor);
				control.Text = buImage5.GetColorKnownName(control.BackColor);
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
