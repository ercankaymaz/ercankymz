using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.ColorPicker;
using ns27;

namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelLayer : Form
{
	public static List<string> Captions = new List<string>();

	public LayerBase Layer = new LayerBase();

	public List<ToolBase> Tools = new List<ToolBase>();

	public List<JewelVar> Modes = new List<JewelVar>();

	public DialogResult Result = DialogResult.None;

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal buColorComboBox buColorComboBox_0;

	internal CheckBox checkBox_0;

	internal Label label_1;

	internal TextBox textBox_0;

	internal Label label_2;

	internal Label label_3;

	public Button btn_cancel;

	public Button btn_ok;

	internal ComboBox comboBox_0;

	internal Label label_4;

	internal Label label_5;

	internal NumericUpDown numericUpDown_1;

	internal ComboBox comboBox_1;

	internal Label label_6;

	public F_JewelLayer()
	{
		Class76.smethod_202(this);
	}

	public void Init()
	{
		buColorComboBox_0.Color = Layer.LayerColor;
		numericUpDown_0.Value = (decimal)Layer.LayerThickness;
		textBox_0.Text = Layer.Name;
		checkBox_0.Checked = Layer.Enable;
		if (Layer.Jewelary != null)
		{
			numericUpDown_1.Value = (decimal)Layer.Jewelary.Depth;
			comboBox_1.Enabled = true;
		}
		comboBox_0.Enabled = true;
		comboBox_1.Items.Clear();
		if (Modes != null)
		{
			for (int i = 0; i <= Modes.Count - 1; i++)
			{
				comboBox_1.Items.Add(Modes[i].ModeName);
			}
			comboBox_1.Text = Layer.Jewelary.JewelMode.ModeName;
			if (Layer.Jewelary.JewelMode.ModeName.Trim().Length == 0 && Modes.Count > 0)
			{
				comboBox_1.Text = Modes[0].ModeName;
			}
		}
		if (comboBox_1.Items.Count == 0)
		{
			comboBox_1.Enabled = false;
		}
		comboBox_0.Items.Clear();
		ToolBase toolBase = null;
		for (int j = 0; j <= Tools.Count - 1; j++)
		{
			if ((Layer.ToolSelected.Data.No == Tools[j].Data.No) & (Layer.ToolSelected.Data.Name == Tools[j].Data.Name))
			{
				toolBase = new ToolBase(Tools[j]);
			}
			comboBox_0.Items.Add("T" + Tools[j].Data.No + " - " + Tools[j].Data.Name);
		}
		if (toolBase == null)
		{
			if (Tools.Count > 0)
			{
				comboBox_0.Text = "T" + Tools[0].Data.No + " - " + Tools[0].Data.Name;
			}
		}
		else
		{
			comboBox_0.Text = "T" + toolBase.Data.No + " - " + toolBase.Data.Name;
		}
		if (comboBox_0.Items.Count == 0)
		{
			comboBox_0.Enabled = false;
		}
		LoadLanguage();
	}

	public void LoadLanguage()
	{
		string callMethod = "Layer LoadLanguage";
		try
		{
			if (Captions.Count > 6)
			{
				Text = Captions[0];
				label_2.Text = Captions[1];
				label_3.Text = Captions[2];
				label_1.Text = Captions[4];
				label_0.Text = Captions[5];
				label_5.Text = Captions[8];
				label_4.Text = Captions[9];
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
			Layer.LayerThickness = (float)numericUpDown_0.Value;
		}
		Layer.LayerColor = buColorComboBox_0.Color;
		Layer.Enable = checkBox_0.Checked;
		Layer.Name = textBox_0.Text;
		if ((comboBox_0.SelectedIndex >= 0) & (comboBox_0.SelectedIndex <= Tools.Count - 1))
		{
			Layer.ToolSelected = new ToolBase(Tools[comboBox_0.SelectedIndex]);
		}
		if (Layer.Jewelary != null)
		{
			if ((comboBox_1.SelectedIndex >= 0) & (comboBox_1.SelectedIndex <= Modes.Count - 1))
			{
				Layer.Jewelary.JewelMode = new JewelVar(Modes[comboBox_1.SelectedIndex]);
				Layer.Jewelary.ModeName = Layer.Jewelary.JewelMode.ModeName;
				Layer.Jewelary.ModeIndex = comboBox_1.SelectedIndex;
			}
			Layer.Jewelary.Depth = (double)numericUpDown_1.Value;
		}
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		Dispose();
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
