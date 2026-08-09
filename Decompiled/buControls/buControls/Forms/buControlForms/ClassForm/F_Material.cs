using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.ColorPicker;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.ClassForm;

public class F_Material : Form
{
	public MaterialBase varMaterial = new MaterialBase();

	public DialogResult Result = DialogResult.None;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buTextBox buTextBox_0;

	internal buSpin buSpin_0;

	internal buLabel buLabel_0;

	internal buComboBox buComboBox_0;

	internal buSpin buSpin_1;

	internal buSpin buSpin_2;

	internal buSpin buSpin_3;

	internal buSpin buSpin_4;

	internal buColorComboBox buColorComboBox_0;

	internal buButton buButton_2;

	internal buButton buButton_3;

	public F_Material()
	{
		Class76.smethod_729(this);
	}

	public void Init()
	{
		buSpin_3.Value = varMaterial.Size.Depth;
		buSpin_0.Value = varMaterial.Size.Depth;
		buSpin_4.Value = varMaterial.Size.Depth;
		buSpin_2.Value = varMaterial.Size.Depth;
		buSpin_1.Value = varMaterial.Size.Depth;
		buColorComboBox_0.Color = varMaterial.Display.SkinColor;
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(varMaterial.Shapes, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(varMaterial.Shapes), ref buComboBox_0);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == buButton_2.Name)
		{
			Class76.smethod_502(this);
			Result = DialogResult.OK;
			Dispose();
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((control.Name == buButton_1.Name) | (control.Name == buButton_3.Name))
		{
			Result = DialogResult.Cancel;
			Dispose();
		}
		if (control.Name == buButton_0.Name)
		{
			base.WindowState = FormWindowState.Minimized;
		}
	}

	internal void method_2(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(buGround_0.Controls, result, e.Shift);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (((sender.GetType() == typeof(buSpin)) | (sender.GetType() == typeof(buTextBox))) && AppBool.TouchPad)
		{
			buControlCommands.ShowKeyPad(this, control);
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
