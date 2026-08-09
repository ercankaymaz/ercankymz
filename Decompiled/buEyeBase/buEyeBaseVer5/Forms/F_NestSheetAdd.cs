using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_NestSheetAdd : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public buNestingSheet Sheet = new buNestingSheet();

	public bool ShowItemNo = false;

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal Button button_0;

	internal Button button_1;

	internal Label label_0;

	internal TextBox textBox_0;

	internal NumericUpDown numericUpDown_0;

	internal Panel panel_0;

	internal Panel panel_1;

	internal Label label_1;

	internal Label label_2;

	internal Panel panel_2;

	internal Label label_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_3;

	internal Label label_5;

	internal Label label_6;

	internal NumericUpDown numericUpDown_2;

	internal Panel panel_4;

	internal Label label_7;

	internal NumericUpDown numericUpDown_3;

	internal Panel panel_5;

	internal Label label_8;

	internal TextBox textBox_1;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	internal Label label_12;

	internal Label label_13;

	internal Label label_14;

	public F_NestSheetAdd()
	{
		buFunctions.CultureSettings();
		Class186.smethod_825(this);
	}

	public void Init()
	{
		Result = DialogResult.None;
		panel_5.Visible = ShowItemNo;
		LoadLanguage();
	}

	public void LoadLanguage()
	{
		string callMethod = "SheetAdd LoadLanguage";
		try
		{
			if (Captions.Count >= 8)
			{
				Text = Captions[0];
				label_0.Text = Captions[1];
				label_2.Text = Captions[2];
				label_4.Text = Captions[3];
				label_6.Text = Captions[4];
				label_7.Text = Captions[5];
				button_0.Text = Captions[6];
				button_1.Text = Captions[7];
				label_8.Text = Captions[8];
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
		if (control.Name == button_0.Name)
		{
			Sheet.MaterialData.Width = (double)numericUpDown_0.Value;
			Sheet.MaterialData.Height = (double)numericUpDown_1.Value;
			Sheet.MaterialData.Thickness = (double)numericUpDown_2.Value;
			Sheet.MaterialData.Quantity = (int)numericUpDown_3.Value;
			Sheet.Remain = (int)numericUpDown_3.Value;
			Sheet.MaterialData.Name = textBox_0.Text;
			Sheet.MaterialData.ItemNo = textBox_1.Text;
			buCall.buNestingCalc_0.SheetRectangle(Sheet.MaterialData.Width, Sheet.MaterialData.Height, ref Sheet);
			if (Sheet.MaterialData.Quantity <= 0)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[37]);
				return;
			}
			if (Sheet.MaterialData.Width <= 0.0)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[38]);
				return;
			}
			if (Sheet.MaterialData.Height <= 0.0)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[39]);
				return;
			}
			if ((Sheet.MaterialData.Thickness <= 0.0) & panel_3.Visible)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[40]);
				return;
			}
			Result = DialogResult.OK;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Close)
			{
				Close();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_1.Name)
		{
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Close)
			{
				Close();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, FormClosingEventArgs e)
	{
		if (Result != DialogResult.OK)
		{
			e.Cancel = true;
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
			if (FormCloseMode == FormCloseModeType.Close)
			{
				Close();
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
