using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.ColorPicker;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Tools;

public class F_ToolTypeSaw : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public ToolBase Value = new ToolBase();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ComboBox comboBox_0;

	internal Label label_0;

	internal Label label_1;

	internal buColorComboBox buColorComboBox_0;

	internal Label label_2;

	internal buColorComboBox buColorComboBox_1;

	internal Label label_3;

	internal NumericUpDown numericUpDown_0;

	internal Label label_4;

	internal NumericUpDown numericUpDown_1;

	internal Label label_5;

	internal NumericUpDown numericUpDown_2;

	internal Label label_6;

	internal NumericUpDown numericUpDown_3;

	internal Label label_7;

	internal NumericUpDown numericUpDown_4;

	internal Label label_8;

	internal NumericUpDown numericUpDown_5;

	internal Label label_9;

	internal TextBox textBox_0;

	internal Label label_10;

	internal ComboBox comboBox_1;

	internal Label label_11;

	internal buColorComboBox buColorComboBox_2;

	internal ComboBox comboBox_2;

	internal Label label_12;

	public F_ToolTypeSaw()
	{
		Class76.smethod_153(this);
	}

	public void Init(ToolBase tool)
	{
		Value = new ToolBase(tool);
		textBox_0.Text = Value.Data.Name;
		numericUpDown_5.Value = Value.Data.No;
		numericUpDown_4.Value = (decimal)Value.Geometry.Thickness;
		numericUpDown_3.Value = (decimal)Value.Geometry.Diameter;
		numericUpDown_2.Value = (decimal)Value.CamData.SpindleSpeed;
		numericUpDown_1.Value = (decimal)Value.CamData.FeedSpeed;
		numericUpDown_0.Value = (decimal)Value.CamData.PlungeSpeed;
		buColorComboBox_2.Color = Value.Display.Solid.SkinColor;
		buColorComboBox_1.Color = Value.Display.CamColor;
		buColorComboBox_0.Color = Value.Display.UpperCamColor;
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Value.CamData.SpindleDirection, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Value.CamData.SpindleDirection), ref comboBox_1);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Value.Purpose, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Value.Purpose), ref comboBox_0);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Value.Geometry.GeometryType, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Value.Geometry.GeometryType), ref comboBox_2);
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolTypeSaw LoadLanguage";
		try
		{
			if (Captions.Count >= 16)
			{
				Text = Captions[0];
				label_9.Text = Captions[1];
				label_8.Text = Captions[2];
				label_7.Text = Captions[3];
				label_6.Text = Captions[4];
				label_5.Text = Captions[5];
				label_11.Text = Captions[6];
				label_4.Text = Captions[7];
				label_3.Text = Captions[8];
				label_10.Text = Captions[9];
				label_2.Text = Captions[10];
				label_1.Text = Captions[11];
				label_0.Text = Captions[12];
				label_12.Text = Captions[13];
				btn_ok.Text = Captions[14];
				btn_cancel.Text = Captions[15];
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
		Value.Data.No = (int)numericUpDown_5.Value;
		Value.Geometry.Thickness = (double)numericUpDown_4.Value;
		Value.Geometry.Diameter = (double)numericUpDown_3.Value;
		Value.CamData.SpindleSpeed = (double)numericUpDown_2.Value;
		Value.CamData.FeedSpeed = (double)numericUpDown_1.Value;
		Value.CamData.PlungeSpeed = (double)numericUpDown_0.Value;
		Value.Geometry.GeometryType = (ToolType)buGeneral.EnumValueFromInt(Value.Geometry.GeometryType, comboBox_2.SelectedIndex);
		Value.Purpose = (ToolPurpose)buGeneral.EnumValueFromInt(Value.Purpose, comboBox_0.SelectedIndex);
		Value.CamData.SpindleDirection = (ClockDirectionType)buGeneral.EnumValueFromInt(Value.CamData.SpindleDirection, comboBox_1.SelectedIndex);
		Value.Display.Solid.SkinColor = buColorComboBox_2.Color;
		Value.Display.CamColor = buColorComboBox_1.Color;
		Value.Display.UpperCamColor = buColorComboBox_0.Color;
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
