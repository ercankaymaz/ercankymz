using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.ClassForm;

public class F_MouseKeyboardConfig : Form
{
	public MouseKeyboardConfigration Value = new MouseKeyboardConfigration();

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal ComboBox comboBox_0;

	internal Label label_0;

	internal ComboBox comboBox_1;

	internal Label label_1;

	public Button btn_cancel;

	public Button btn_ok;

	public F_MouseKeyboardConfig()
	{
		Class76.smethod_621(this);
	}

	public void Init()
	{
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Value.Button.GetType(), ref EnumItems);
		for (int i = 0; i <= EnumItems.Count - 1; i++)
		{
			comboBox_0.Items.Add(EnumItems[i].ToString());
		}
		EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Value.Key.GetType(), ref EnumItems);
		for (int j = 0; j <= EnumItems.Count - 1; j++)
		{
			comboBox_1.Items.Add(EnumItems[j].ToString());
		}
		comboBox_0.SelectedIndex = Convert.ToInt32(Value.Button);
		comboBox_1.SelectedIndex = Convert.ToInt32(Value.Key);
		Class76.smethod_19(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		EnumConverter enumConverter = new EnumConverter(Value.Button.GetType());
		Value.Button = (mouseButtons)enumConverter.ConvertFromString(comboBox_0.Text);
		enumConverter = new EnumConverter(Value.Key.GetType());
		Value.Key = (modifierKeys)enumConverter.ConvertFromString(comboBox_1.Text);
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
