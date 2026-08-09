using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using ns27;

namespace buControls.Forms.WinControlForms.Tufting;

public class F_YarnSettings : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<TuftingYarn> Yarns = new List<TuftingYarn>();

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal ImageList imageList_0;

	public Button btn_cancel;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal Button button_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal Panel panel_0;

	internal Label label_3;

	internal TextBox textBox_0;

	internal ListBox listBox_0;

	internal Button button_2;

	public Button btn_ok;

	public F_YarnSettings()
	{
		Class76.smethod_647(this);
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
		listBox_0.Items.Clear();
		for (int i = 0; i <= Yarns.Count - 1; i++)
		{
			listBox_0.Items.Add(Yarns[i].Name);
		}
		if (Yarns.Count > 0)
		{
			listBox_0.SelectedIndex = 0;
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
		if (control.Name == button_2.Name && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Yarns.Count - 1)))
		{
			if (textBox_0.Text.Trim().Length > 0)
			{
				Yarns[listBox_0.SelectedIndex].Name = textBox_0.Text.Trim();
			}
			Yarns[listBox_0.SelectedIndex].HundredMeterPerGram = (double)numericUpDown_0.Value;
			Yarns[listBox_0.SelectedIndex].Kat = (double)numericUpDown_1.Value;
			listBox_0.Items[listBox_0.SelectedIndex] = Yarns[listBox_0.SelectedIndex].Name;
		}
		if (control.Name == button_1.Name && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Yarns.Count - 1)))
		{
			Yarns.RemoveAt(listBox_0.SelectedIndex);
			listBox_0.Items.RemoveAt(listBox_0.SelectedIndex);
		}
		if (control.Name == button_0.Name)
		{
			TuftingYarn value = new TuftingYarn();
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.Text = "Yarn";
			f_ClassViewerDialog.Value = value;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog(this);
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				Yarns.Add((TuftingYarn)f_ClassViewerDialog.Value);
				listBox_0.Items.Add(((TuftingYarn)f_ClassViewerDialog.Value).Name);
			}
		}
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
	}

	internal void method_2(object sender, EventArgs e)
	{
		new Control();
		if (PropertiesForm.Inited)
		{
			PropertiesForm.Inited = true;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Yarns.Count - 1))
		{
			textBox_0.Text = Yarns[listBox_0.SelectedIndex].Name;
			numericUpDown_0.Value = (decimal)Yarns[listBox_0.SelectedIndex].HundredMeterPerGram;
			numericUpDown_1.Value = (decimal)Yarns[listBox_0.SelectedIndex].Kat;
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
