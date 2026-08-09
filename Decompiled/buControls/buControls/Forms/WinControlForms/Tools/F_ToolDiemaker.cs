using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Tools;

public class F_ToolDiemaker : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public ToolBase Value = new ToolBase();

	internal IContainer icontainer_0 = null;

	public Button btn_ok;

	internal ImageList imageList_0;

	public Button btn_cancel;

	internal ComboBox comboBox_0;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_3;

	internal Label label_5;

	internal TextBox textBox_0;

	internal CheckBox checkBox_0;

	internal Label label_6;

	internal Label label_7;

	internal CheckBox checkBox_1;

	internal Label label_8;

	internal CheckBox checkBox_2;

	internal Label label_9;

	internal CheckBox checkBox_3;

	internal Label label_10;

	internal NumericUpDown numericUpDown_4;

	internal Label label_11;

	internal Label label_12;

	internal Label label_13;

	internal Label label_14;

	internal Label label_15;

	internal CheckBox checkBox_4;

	internal CheckBox checkBox_5;

	internal CheckBox checkBox_6;

	internal CheckBox checkBox_7;

	internal CheckBox checkBox_8;

	internal Label label_16;

	internal NumericUpDown numericUpDown_5;

	public F_ToolDiemaker()
	{
		Class76.smethod_497(this);
	}

	public void Init(ToolBase tool)
	{
		Value = new ToolBase(tool);
		textBox_0.Text = Value.Data.Name;
		numericUpDown_3.Value = Value.Data.No;
		numericUpDown_2.Value = (decimal)Value.Diemaker.NickDiameter;
		numericUpDown_1.Value = (decimal)Value.Diemaker.Width;
		numericUpDown_5.Value = (decimal)Value.Diemaker.BridgeHeight;
		numericUpDown_0.Value = (decimal)Value.Diemaker.ID;
		numericUpDown_4.Value = (decimal)Value.Diemaker.PositionOffset;
		checkBox_0.Checked = Value.Diemaker.Cutting;
		checkBox_1.Checked = Value.Diemaker.Creasing;
		checkBox_2.Checked = Value.Diemaker.Perfo;
		checkBox_3.Checked = Value.Diemaker.CutCrease;
		checkBox_7.Checked = Value.Diemaker.Pt1;
		checkBox_6.Checked = Value.Diemaker.Pt2;
		checkBox_5.Checked = Value.Diemaker.Pt3;
		checkBox_4.Checked = Value.Diemaker.Pt4;
		checkBox_8.Checked = Value.Diemaker.Pt6;
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Value.Diemaker.Mode, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Value.Diemaker.Mode), ref comboBox_0);
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDiemaker LoadLanguage";
		try
		{
			if (Captions.Count >= 15)
			{
				Text = Captions[0];
				label_5.Text = Captions[1];
				label_4.Text = Captions[2];
				label_0.Text = Captions[3];
				label_6.Text = Captions[4];
				label_7.Text = Captions[5];
				label_8.Text = Captions[6];
				label_9.Text = Captions[7];
				label_1.Text = Captions[8];
				label_2.Text = Captions[9];
				label_16.Text = Captions[10];
				label_10.Text = Captions[11];
				label_3.Text = Captions[12];
				btn_ok.Text = Captions[13];
				btn_cancel.Text = Captions[14];
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
		Value.Data.Name = textBox_0.Text;
		Value.Data.No = (int)numericUpDown_3.Value;
		Value.Diemaker.NickDiameter = (double)numericUpDown_2.Value;
		Value.Diemaker.Width = (double)numericUpDown_1.Value;
		Value.Diemaker.BridgeHeight = (double)numericUpDown_5.Value;
		Value.Diemaker.PositionOffset = (double)numericUpDown_4.Value;
		Value.Diemaker.ID = (int)numericUpDown_0.Value;
		Value.Diemaker.Cutting = checkBox_0.Checked;
		Value.Diemaker.Creasing = checkBox_1.Checked;
		Value.Diemaker.Perfo = checkBox_2.Checked;
		Value.Diemaker.CutCrease = checkBox_3.Checked;
		Value.Diemaker.Pt1 = checkBox_7.Checked;
		Value.Diemaker.Pt2 = checkBox_6.Checked;
		Value.Diemaker.Pt3 = checkBox_5.Checked;
		Value.Diemaker.Pt4 = checkBox_4.Checked;
		Value.Diemaker.Pt6 = checkBox_8.Checked;
		Value.Diemaker.Mode = (DiemakerToolModeType)buGeneral.EnumValueFromInt(Value.Diemaker.Mode, comboBox_0.SelectedIndex);
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
