using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Jewellary;

public class F_AdvancedSettings : Form
{
	public static List<string> Captions = new List<string>();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public JewelVar ParJewel = new JewelVar();

	public DialogResult Result = DialogResult.None;

	private IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Button button_0;

	internal Button button_1;

	internal Label label_0;

	internal CheckBox checkBox_0;

	internal Panel panel_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal Label label_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_3;

	internal Label label_5;

	internal NumericUpDown numericUpDown_4;

	internal Label label_6;

	internal NumericUpDown numericUpDown_5;

	internal Label label_7;

	internal NumericUpDown numericUpDown_6;

	internal Label label_8;

	internal ComboBox comboBox_0;

	internal Label label_9;

	internal ComboBox comboBox_1;

	internal Label label_10;

	internal ComboBox comboBox_2;

	internal Label label_11;

	internal Panel panel_2;

	internal NumericUpDown numericUpDown_7;

	internal Label label_12;

	internal NumericUpDown numericUpDown_8;

	internal Label label_13;

	internal NumericUpDown numericUpDown_9;

	internal Label label_14;

	internal NumericUpDown numericUpDown_10;

	internal Label label_15;

	internal NumericUpDown numericUpDown_11;

	internal Label label_16;

	internal Label label_17;

	internal Button button_2;

	internal Button button_3;

	internal Label label_18;

	internal NumericUpDown numericUpDown_12;

	internal Label label_19;

	internal NumericUpDown numericUpDown_13;

	internal Label label_20;

	internal NumericUpDown numericUpDown_14;

	internal Label label_21;

	internal NumericUpDown numericUpDown_15;

	internal Label label_22;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	public F_AdvancedSettings()
	{
		Class76.smethod_818(this);
	}

	public void Init()
	{
		numericUpDown_1.Value = (decimal)ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset;
		numericUpDown_0.Value = (decimal)ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceSpeed;
		numericUpDown_12.Value = (decimal)ParJewel.JewelCamProp.Leave5AxisSpeed;
		numericUpDown_6.Value = (decimal)ParJewel.JewelMode.RingRotateCenterX;
		numericUpDown_5.Value = (decimal)ParJewel.JewelMode.RingRotateCenterZ;
		numericUpDown_4.Value = (decimal)ParJewel.JewelMode.BraceletRotateCenterX;
		numericUpDown_3.Value = (decimal)ParJewel.JewelMode.BraceletRotateCenterZ;
		numericUpDown_15.Value = (decimal)ParJewel.JewelCamProp.AirZ;
		numericUpDown_14.Value = (decimal)ParJewel.JewelCamProp.SafeAbsZ;
		numericUpDown_13.Value = (decimal)ParJewel.JewelCamProp.SafeIncZ;
		checkBox_1.Checked = ParJewel.JewelCamProp.ZSafeAbsoluteMode;
		checkBox_2.Checked = ParJewel.JewelCamProp.BValueEffectedByZDepth;
		numericUpDown_11.Value = (decimal)ParJewel.JewelMode.SpindleSpeed;
		numericUpDown_10.Value = (decimal)ParJewel.JewelMode.EngravingSpeed;
		numericUpDown_8.Value = (decimal)ParJewel.JewelMode.DiamondCutSpeed1;
		numericUpDown_7.Value = (decimal)ParJewel.JewelMode.DiamondCutSpeed2;
		numericUpDown_9.Value = (decimal)ParJewel.JewelMode.LatheSpeed;
		checkBox_0.Checked = ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceEnable;
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(ParJewel.JewelMode.CamCoreMoveUpType, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(ParJewel.JewelMode.CamCoreMoveUpType), ref comboBox_1);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(ParJewel.SortNextGRoupRules, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(ParJewel.SortNextGRoupRules), ref comboBox_0);
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(ParJewel.JewelScaleProp.Method, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(ParJewel.JewelScaleProp.Method), ref comboBox_2);
		button_1.BackColor = Color.Silver;
		button_0.BackColor = Color.Silver;
		if (ParJewel.JewelMode.MaterialMode == jewelMaterialType.Ring)
		{
			button_1.BackColor = Color.Cyan;
		}
		if (ParJewel.JewelMode.MaterialMode == jewelMaterialType.Bracelet)
		{
			button_0.BackColor = Color.Cyan;
		}
		Class76.smethod_65(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		button_1.BackColor = Color.Silver;
		button_0.BackColor = Color.Silver;
		if (control.Name == button_1.Name)
		{
			ParJewel.JewelMode.MaterialMode = jewelMaterialType.Ring;
		}
		if (control.Name == button_0.Name)
		{
			ParJewel.JewelMode.MaterialMode = jewelMaterialType.Bracelet;
		}
		if (ParJewel.JewelMode.MaterialMode == jewelMaterialType.Ring)
		{
			button_1.BackColor = Color.Cyan;
		}
		if (ParJewel.JewelMode.MaterialMode == jewelMaterialType.Bracelet)
		{
			button_0.BackColor = Color.Cyan;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset = (double)numericUpDown_1.Value;
		ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceSpeed = (double)numericUpDown_0.Value;
		ParJewel.JewelCamProp.Leave5AxisSpeed = (double)numericUpDown_12.Value;
		ParJewel.JewelMode.RingRotateCenterX = (double)numericUpDown_6.Value;
		ParJewel.JewelMode.RingRotateCenterZ = (double)numericUpDown_5.Value;
		ParJewel.JewelMode.BraceletRotateCenterX = (double)numericUpDown_4.Value;
		ParJewel.JewelMode.BraceletRotateCenterZ = (double)numericUpDown_3.Value;
		ParJewel.JewelMode.SpindleSpeed = (double)numericUpDown_11.Value;
		ParJewel.JewelMode.EngravingSpeed = (double)numericUpDown_10.Value;
		ParJewel.JewelMode.DiamondCutSpeed1 = (double)numericUpDown_8.Value;
		ParJewel.JewelMode.DiamondCutSpeed2 = (double)numericUpDown_7.Value;
		ParJewel.JewelMode.LatheSpeed = (double)numericUpDown_9.Value;
		ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceEnable = checkBox_0.Checked;
		ParJewel.JewelCamProp.BValueEffectedByZDepth = checkBox_2.Checked;
		ParJewel.JewelCamProp.AirZ = (double)numericUpDown_15.Value;
		ParJewel.JewelCamProp.SafeAbsZ = (double)numericUpDown_14.Value;
		ParJewel.JewelCamProp.SafeIncZ = (double)numericUpDown_13.Value;
		ParJewel.JewelCamProp.ZSafeAbsoluteMode = checkBox_1.Checked;
		ParJewel.JewelMode.CamCoreMoveUpType = (CamMoveUpType)buGeneral.EnumValueFromInt(ParJewel.JewelMode.CamCoreMoveUpType, comboBox_1.SelectedIndex);
		ParJewel.JewelScaleProp.Method = (jewelScaleMehod)buGeneral.EnumValueFromInt(ParJewel.JewelScaleProp.Method, comboBox_2.SelectedIndex);
		ParJewel.SortNextGRoupRules = (SortingNextGroupFindRulesType)buGeneral.EnumValueFromInt(ParJewel.SortNextGRoupRules, comboBox_0.SelectedIndex);
		Result = DialogResult.OK;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
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
