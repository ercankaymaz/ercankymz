using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls;
using buControls.DialogBox;
using buCore;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_LayerConvertToTufting : Form
{
	public LayerBase5 layer = new LayerBase5();

	public List<TuftingYarn> Yarns = new List<TuftingYarn>();

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal ComboBox comboBox_0;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal CheckBox checkBox_0;

	internal Label label_2;

	internal TextBox textBox_0;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	public Button btn_cancel;

	public Button btn_ok;

	internal ComboBox comboBox_1;

	internal Label label_6;

	internal Label label_7;

	internal NumericUpDown numericUpDown_1;

	internal Label label_8;

	internal NumericUpDown numericUpDown_2;

	internal Label label_9;

	internal ComboBox comboBox_2;

	internal Label label_10;

	internal NumericUpDown numericUpDown_3;

	internal Label label_11;

	internal CheckBox checkBox_1;

	internal Label label_12;

	internal TextBox textBox_1;

	internal Label label_13;

	internal NumericUpDown numericUpDown_4;

	public F_LayerConvertToTufting()
	{
		Class186.smethod_608(this);
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
		LayerBase5 layerBase = new LayerBase5();
		label_9.BackColor = layer.LayerColor;
		label_9.Text = buImage5.GetColorKnownName(layer.LayerColor);
		label_9.ForeColor = buImage5.InvertColorNoGray(layer.LayerColor);
		numericUpDown_0.Value = (decimal)layer.LayerThickness;
		numericUpDown_2.Value = layer.Transparency;
		numericUpDown_1.Value = (decimal)layer.Tufting.PileHeight;
		numericUpDown_3.Value = (decimal)layer.Tufting.StitchLength;
		numericUpDown_4.Value = (decimal)layer.Tufting.TuftingThickness;
		textBox_0.Text = layer.Name;
		textBox_1.Text = layer.Defination;
		checkBox_0.Checked = layer.Enable;
		checkBox_1.Checked = layer.Lock;
		comboBox_0.Enabled = true;
		comboBox_1.Enabled = true;
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(layerBase.Tufting.MixerMode, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(layer.Tufting.MixerMode), ref comboBox_2);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(layerBase.Tufting.StitchMode, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(layer.Tufting.StitchMode), ref comboBox_0);
		comboBox_1.Items.Clear();
		for (int i = 0; i <= Yarns.Count - 1; i++)
		{
			comboBox_1.Items.Add(Yarns[i].Name);
		}
		comboBox_1.Text = layer.Tufting.YarnType.Name;
		if ((comboBox_1.Text.Length == 0) & (comboBox_1.Items.Count > 0))
		{
			comboBox_1.SelectedIndex = 0;
		}
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "Layer LoadLanguage";
		try
		{
			if (Captions.Count > 6)
			{
				Text = Captions[0];
				label_3.Text = Captions[1];
				label_4.Text = Captions[2];
				label_2.Text = Captions[4];
				label_1.Text = Captions[5];
				label_0.Text = Captions[6];
				label_5.Text = Captions[7];
				label_7.Text = Captions[8];
				label_6.Text = Captions[9];
				btn_ok.Text = Captions[10];
				btn_cancel.Text = Captions[11];
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
		if (numericUpDown_0.Value > 0m)
		{
			layer.LayerThickness = (float)numericUpDown_0.Value;
		}
		layer.Transparency = (int)numericUpDown_2.Value;
		layer.LayerColor = label_9.BackColor;
		layer.Enable = checkBox_0.Checked;
		layer.Name = textBox_0.Text;
		layer.Defination = textBox_1.Text;
		layer.Tufting.PileHeight = (double)numericUpDown_1.Value;
		layer.Tufting.StitchLength = (double)numericUpDown_3.Value;
		layer.Tufting.TuftingThickness = (double)numericUpDown_4.Value;
		layer.Tufting.YarnType = new TuftingYarn(Yarns[comboBox_1.SelectedIndex]);
		layer.Tufting.MixerMode = (tuftingMixerModeType)comboBox_2.SelectedIndex;
		layer.Tufting.StitchMode = (tuftingStitchModeType)comboBox_0.SelectedIndex;
		layer.Lock = checkBox_1.Checked;
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

	internal void method_1(object sender, EventArgs e)
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

	internal void method_2(object sender, EventArgs e)
	{
		ColorDialogBox.ShowDialog(label_9.BackColor);
		if (ColorDialogBox.Result == DialogResult.OK)
		{
			label_9.BackColor = ColorDialogBox.Color;
			label_9.ForeColor = buImage5.InvertColorNoGray(label_9.BackColor);
			label_9.Text = buImage5.GetColorKnownName(label_9.BackColor);
		}
	}

	internal void method_3(object sender, FormClosingEventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
