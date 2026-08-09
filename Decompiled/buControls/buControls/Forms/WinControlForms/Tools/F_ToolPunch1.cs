using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Tools;

public class F_ToolPunch1 : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<ToolBase> Tools = new List<ToolBase>();

	public ToolAreaVisible ToolVarVisible = new ToolAreaVisible();

	internal IContainer icontainer_0 = null;

	internal PictureBox pictureBox_0;

	internal Panel panel_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal TextBox textBox_0;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal ComboBox comboBox_0;

	internal NumericUpDown numericUpDown_2;

	internal Panel panel_1;

	internal TextBox textBox_1;

	internal NumericUpDown numericUpDown_3;

	internal NumericUpDown numericUpDown_4;

	internal ComboBox comboBox_1;

	internal NumericUpDown numericUpDown_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	internal Panel panel_2;

	internal TextBox textBox_2;

	internal NumericUpDown numericUpDown_6;

	internal NumericUpDown numericUpDown_7;

	internal ComboBox comboBox_2;

	internal NumericUpDown numericUpDown_8;

	internal Label label_12;

	internal Label label_13;

	internal Label label_14;

	internal Label label_15;

	internal Label label_16;

	internal Label label_17;

	internal Panel panel_3;

	internal TextBox textBox_3;

	internal NumericUpDown numericUpDown_9;

	internal NumericUpDown numericUpDown_10;

	internal ComboBox comboBox_3;

	internal NumericUpDown numericUpDown_11;

	internal Label label_18;

	internal Label label_19;

	internal Label label_20;

	internal Label label_21;

	internal Panel panel_4;

	internal TextBox textBox_4;

	internal NumericUpDown numericUpDown_12;

	internal NumericUpDown numericUpDown_13;

	internal ComboBox comboBox_4;

	internal NumericUpDown numericUpDown_14;

	internal Label label_22;

	internal Label label_23;

	internal Label label_24;

	internal Label label_25;

	internal Panel panel_5;

	internal TextBox textBox_5;

	internal NumericUpDown numericUpDown_15;

	internal NumericUpDown numericUpDown_16;

	internal ComboBox comboBox_5;

	internal NumericUpDown numericUpDown_17;

	internal Label label_26;

	internal Label label_27;

	internal Label label_28;

	internal Label label_29;

	internal Label label_30;

	internal Label label_31;

	internal Panel panel_6;

	internal TextBox textBox_6;

	internal NumericUpDown numericUpDown_18;

	internal NumericUpDown numericUpDown_19;

	internal ComboBox comboBox_6;

	internal NumericUpDown numericUpDown_20;

	internal Label label_32;

	internal Label label_33;

	internal Label label_34;

	internal Label label_35;

	internal Label label_36;

	internal Label label_37;

	internal Panel panel_7;

	internal TextBox textBox_7;

	internal NumericUpDown numericUpDown_21;

	internal NumericUpDown numericUpDown_22;

	internal ComboBox comboBox_7;

	internal NumericUpDown numericUpDown_23;

	internal Label label_38;

	internal Label label_39;

	internal Label label_40;

	internal Label label_41;

	internal Label label_42;

	internal Label label_43;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public F_ToolPunch1()
	{
		Class76.smethod_682(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		ArrayList arrayList = new ArrayList();
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		if (Tools.Count < 8)
		{
			for (int i = 0; i < 8 - Tools.Count; i++)
			{
				Tools.Add(new ToolBase());
			}
		}
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tools[0].Geometry.FlatGeometry, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tools[0].Geometry.FlatGeometry), ref comboBox_2);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tools[1].Geometry.FlatGeometry, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tools[1].Geometry.FlatGeometry), ref comboBox_4);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tools[2].Geometry.FlatGeometry, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tools[2].Geometry.FlatGeometry), ref comboBox_5);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tools[3].Geometry.FlatGeometry, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tools[3].Geometry.FlatGeometry), ref comboBox_0);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tools[4].Geometry.FlatGeometry, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tools[4].Geometry.FlatGeometry), ref comboBox_3);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tools[5].Geometry.FlatGeometry, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tools[5].Geometry.FlatGeometry), ref comboBox_7);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tools[6].Geometry.FlatGeometry, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tools[6].Geometry.FlatGeometry), ref comboBox_1);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tools[7].Geometry.FlatGeometry, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tools[7].Geometry.FlatGeometry), ref comboBox_6);
		textBox_2.Text = Tools[0].Data.Name;
		textBox_4.Text = Tools[1].Data.Name;
		textBox_5.Text = Tools[2].Data.Name;
		textBox_0.Text = Tools[3].Data.Name;
		textBox_3.Text = Tools[4].Data.Name;
		textBox_7.Text = Tools[5].Data.Name;
		textBox_1.Text = Tools[6].Data.Name;
		textBox_6.Text = Tools[7].Data.Name;
		numericUpDown_8.Value = (decimal)Tools[0].Geometry.SizeWidth;
		numericUpDown_14.Value = (decimal)Tools[1].Geometry.SizeWidth;
		numericUpDown_17.Value = (decimal)Tools[2].Geometry.SizeWidth;
		numericUpDown_2.Value = (decimal)Tools[3].Geometry.SizeWidth;
		numericUpDown_11.Value = (decimal)Tools[4].Geometry.SizeWidth;
		numericUpDown_23.Value = (decimal)Tools[5].Geometry.SizeWidth;
		numericUpDown_5.Value = (decimal)Tools[6].Geometry.SizeWidth;
		numericUpDown_20.Value = (decimal)Tools[7].Geometry.SizeWidth;
		numericUpDown_7.Value = (decimal)Tools[0].Geometry.SizeDepth;
		numericUpDown_13.Value = (decimal)Tools[1].Geometry.SizeDepth;
		numericUpDown_16.Value = (decimal)Tools[2].Geometry.SizeDepth;
		numericUpDown_1.Value = (decimal)Tools[3].Geometry.SizeDepth;
		numericUpDown_10.Value = (decimal)Tools[4].Geometry.SizeDepth;
		numericUpDown_22.Value = (decimal)Tools[5].Geometry.SizeDepth;
		numericUpDown_4.Value = (decimal)Tools[6].Geometry.SizeDepth;
		numericUpDown_19.Value = (decimal)Tools[7].Geometry.SizeDepth;
		numericUpDown_6.Value = (decimal)Tools[0].Geometry.PositionAngle;
		numericUpDown_12.Value = (decimal)Tools[1].Geometry.PositionAngle;
		numericUpDown_15.Value = (decimal)Tools[2].Geometry.PositionAngle;
		numericUpDown_0.Value = (decimal)Tools[3].Geometry.PositionAngle;
		numericUpDown_9.Value = (decimal)Tools[4].Geometry.PositionAngle;
		numericUpDown_21.Value = (decimal)Tools[5].Geometry.PositionAngle;
		numericUpDown_3.Value = (decimal)Tools[6].Geometry.PositionAngle;
		numericUpDown_18.Value = (decimal)Tools[7].Geometry.PositionAngle;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
			if (Captions.Count >= 67)
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

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!Properties.Inited)
		{
			return;
		}
		if (control.Name == btn_ok.Name)
		{
			Class76.smethod_68(this);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
