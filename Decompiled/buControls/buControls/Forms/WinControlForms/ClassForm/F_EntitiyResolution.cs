using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.ClassForm;

public class F_EntitiyResolution : Form
{
	public EntityResolution Value = new EntityResolution();

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	public Button btn_cancel;

	public Button btn_ok;

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

	public F_EntitiyResolution()
	{
		Class76.smethod_274(this);
	}

	public void Init()
	{
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Value.ResolutionTypes, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Value.ResolutionTypes), ref comboBox_0);
		numericUpDown_1.Value = Value.GeometricCount;
		numericUpDown_3.Value = (decimal)Value.dt;
		numericUpDown_0.Value = (decimal)Value.GeometricLength;
		numericUpDown_2.Value = (decimal)Value.LnRatio;
		comboBox_0.SelectedIndex = Convert.ToInt32(Value.ResolutionTypes);
		Class76.smethod_110(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		EnumConverter enumConverter = new EnumConverter(Value.ResolutionTypes.GetType());
		Value.ResolutionTypes = (EntityResolutionType)enumConverter.ConvertFromString(comboBox_0.Text);
		Value.dt = (double)numericUpDown_3.Value;
		Value.GeometricCount = (int)numericUpDown_1.Value;
		Value.GeometricLength = (double)numericUpDown_0.Value;
		Value.LnRatio = (double)numericUpDown_2.Value;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
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
