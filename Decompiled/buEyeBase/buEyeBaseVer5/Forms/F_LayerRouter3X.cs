using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_LayerRouter3X : Form
{
	public static List<string> Captions = new List<string>();

	public LayerBase5 layer = new LayerBase5();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal CheckBox checkBox_0;

	internal Label label_1;

	internal TextBox textBox_0;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal CheckBox checkBox_1;

	public Button btn_cancel;

	public Button btn_ok;

	internal ComboBox comboBox_0;

	internal Label label_5;

	internal Label label_6;

	internal NumericUpDown numericUpDown_1;

	internal Label label_7;

	public F_LayerRouter3X()
	{
		Class186.smethod_653(this);
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
		label_7.BackColor = layer.LayerColor;
		label_7.Text = buImage5.GetColorKnownName(layer.LayerColor);
		label_7.ForeColor = buImage5.InvertColorNoGray(layer.LayerColor);
		numericUpDown_0.Value = (decimal)layer.LayerThickness;
		numericUpDown_1.Value = layer.Transparency;
		textBox_0.Text = layer.Name;
		checkBox_0.Checked = layer.Enable;
		checkBox_1.Checked = layer.Lock;
		comboBox_0.Enabled = true;
		if (layer.Router3AX != null)
		{
			List<string> EnumItems = new List<string>();
			buFunctions.GetEnumTypeValues(layer.Router3AX.Purpose, ref EnumItems);
			comboBox_0.Items.Clear();
			for (int i = 0; i <= EnumItems.Count - 1; i++)
			{
				comboBox_0.Items.Add(EnumItems[i]);
			}
			if (layer.Router3AX != null)
			{
				comboBox_0.Text = layer.Router3AX.Purpose.ToString();
			}
		}
		if (comboBox_0.Items.Count == 0)
		{
			comboBox_0.Enabled = false;
		}
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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
		string callMethod = "Layer LoadLanguage";
		try
		{
			if (Captions.Count > 6)
			{
				Text = Captions[0];
				label_2.Text = Captions[1];
				label_3.Text = Captions[2];
				label_4.Text = Captions[3];
				label_1.Text = Captions[4];
				label_0.Text = Captions[5];
				label_5.Text = Captions[9];
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

	internal void method_1(object sender, EventArgs e)
	{
		if (numericUpDown_0.Value > 0m)
		{
			layer.LayerThickness = (float)numericUpDown_0.Value;
		}
		layer.Transparency = (int)numericUpDown_1.Value;
		layer.LayerColor = label_7.BackColor;
		layer.Enable = checkBox_0.Checked;
		layer.Lock = checkBox_1.Checked;
		layer.Name = textBox_0.Text;
		if (layer.Router3AX != null)
		{
			layer.Router3AX.Purpose = (Router3AXLayerPurpose)buFunctions.EnumValueFromString(layer.Router3AX.Purpose, comboBox_0.Text);
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

	internal void method_2(object sender, EventArgs e)
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

	internal void method_3(object sender, EventArgs e)
	{
		ColorDialogBox.ShowDialog(label_7.BackColor);
		if (ColorDialogBox.Result == DialogResult.OK)
		{
			label_7.BackColor = ColorDialogBox.Color;
			label_7.ForeColor = buImage5.InvertColorNoGray(label_7.BackColor);
			label_7.Text = buImage5.GetColorKnownName(label_7.BackColor);
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
