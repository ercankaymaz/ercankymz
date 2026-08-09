using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.ColorPicker;
using ns27;

namespace buControls.Forms.WinControlForms.ClassForm;

public class F_DrawPropertiesType : Form
{
	public drawPropertiesType Value = new drawPropertiesType();

	public List<drawingPattern> Patterns = new List<drawingPattern>();

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	public Button btn_cancel;

	public Button btn_ok;

	internal buColorComboBox buColorComboBox_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal Label label_1;

	internal ComboBox comboBox_0;

	public F_DrawPropertiesType()
	{
		Class76.smethod_570(this);
	}

	public void Init()
	{
		buColorComboBox_0.Color = Value.Color;
		numericUpDown_0.Value = (decimal)Value.Thickness;
		comboBox_0.Items.Clear();
		for (int i = 0; i <= Patterns.Count - 1; i++)
		{
			comboBox_0.Items.Add(Patterns[i].Name);
		}
		Class76.smethod_156(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (numericUpDown_0.Value > 0m)
		{
			Value.Thickness = (float)numericUpDown_0.Value;
		}
		Value.Color = buColorComboBox_0.Color;
		for (int i = 0; i <= Patterns.Count - 1; i++)
		{
			if (Patterns[i].Name == comboBox_0.Text)
			{
				Value.Pattern = new drawingPattern(Patterns[i]);
			}
		}
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
