using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Layer;

public class F_Layer : Form
{
	public static List<string> Captions = new List<string>();

	public LayerBase Value = new LayerBase();

	public List<drawingPattern> Patterns = new List<drawingPattern>();

	public List<ToolBase> Tools = new List<ToolBase>();

	public DialogResult Result = DialogResult.None;

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

	internal CheckBox checkBox_1;

	internal Label label_6;

	internal TextBox textBox_1;

	public Button btn_cancel;

	public Button btn_ok;

	internal ComboBox comboBox_1;

	internal Label label_7;

	internal Label label_8;

	internal NumericUpDown numericUpDown_1;

	internal Label label_9;

	internal NumericUpDown numericUpDown_2;

	internal Label label_10;

	public F_Layer()
	{
		Class76.smethod_609(this);
	}

	public void Init(List<drawingPattern> pattern, List<ToolBase> tool)
	{
		label_10.BackColor = Value.LayerColor;
		label_10.Text = buImage.GetColorKnownName(Value.LayerColor);
		label_10.ForeColor = buImage.InvertColorNoGray(Value.LayerColor);
		numericUpDown_0.Value = (decimal)Value.LayerThickness;
		numericUpDown_2.Value = Value.Transparency;
		textBox_0.Text = Value.Name;
		textBox_1.Text = Value.Tag;
		checkBox_0.Checked = Value.Enable;
		checkBox_1.Checked = Value.Lock;
		comboBox_0.Enabled = true;
		comboBox_1.Enabled = true;
		Patterns.Clear();
		Tools.Clear();
		if (pattern != null)
		{
			for (int i = 0; i <= pattern.Count - 1; i++)
			{
				Patterns.Add(new drawingPattern(pattern[i]));
			}
		}
		for (int j = 0; j <= tool.Count - 1; j++)
		{
			Tools.Add(new ToolBase(tool[j]));
		}
		comboBox_0.Items.Clear();
		if (Patterns == null)
		{
			comboBox_0.Enabled = false;
		}
		else
		{
			for (int k = 0; k <= Patterns.Count - 1; k++)
			{
				comboBox_0.Items.Add(Patterns[k].Name);
			}
			comboBox_0.Text = Value.Pattern.Name;
			if (comboBox_0.Items.Count == 0)
			{
				comboBox_0.Enabled = false;
			}
		}
		comboBox_1.Items.Clear();
		for (int l = 0; l <= Tools.Count - 1; l++)
		{
			comboBox_1.Items.Add("T" + Tools[l].Data.No + " - " + Tools[l].Data.Name);
		}
		comboBox_1.Text = "T" + Value.Cam.CamTool.Data.No + " - " + Value.Cam.CamTool.Data.Name;
		if (comboBox_1.Items.Count == 0)
		{
			comboBox_1.Enabled = false;
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
				label_3.Text = Captions[1];
				label_4.Text = Captions[2];
				label_5.Text = Captions[3];
				label_2.Text = Captions[4];
				label_1.Text = Captions[5];
				label_0.Text = Captions[6];
				label_6.Text = Captions[7];
				label_8.Text = Captions[8];
				label_7.Text = Captions[9];
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
			Value.LayerThickness = (float)numericUpDown_0.Value;
		}
		Value.Transparency = (int)numericUpDown_2.Value;
		Value.LayerColor = label_10.BackColor;
		Value.Enable = checkBox_0.Checked;
		Value.Lock = checkBox_1.Checked;
		Value.Name = textBox_0.Text;
		Value.Tag = textBox_1.Text;
		for (int i = 0; i <= Patterns.Count - 1; i++)
		{
			if (Patterns[i].Name == comboBox_0.Text)
			{
				Value.Pattern = new drawingPattern(Patterns[i]);
			}
		}
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		Dispose();
	}

	internal void method_2(object sender, EventArgs e)
	{
		ColorDialogBox.ShowDialog(label_10.BackColor);
		if (ColorDialogBox.Result == DialogResult.OK)
		{
			label_10.BackColor = ColorDialogBox.Color;
			label_10.ForeColor = buImage.InvertColorNoGray(label_10.BackColor);
			label_10.Text = buImage.GetColorKnownName(label_10.BackColor);
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
