using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Diemaker;

public class F_SelectAlParts : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DiemakerSelectAllParts SelectAllVar = new DiemakerSelectAllParts();

	public Color colorActive = Color.DarkGray;

	public Color colorPassive = Color.WhiteSmoke;

	public bool EnablePt1 = false;

	private bool bool_0 = false;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal CheckBox checkBox_3;

	internal ComboBox comboBox_0;

	internal CheckBox checkBox_4;

	internal CheckBox checkBox_5;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal Button button_4;

	internal Button button_5;

	public F_SelectAlParts()
	{
		Class76.smethod_374(this);
	}

	public void Init()
	{
		bool_0 = false;
		button_2.BackColor = colorPassive;
		button_1.BackColor = colorPassive;
		button_0.BackColor = colorPassive;
		button_3.BackColor = colorPassive;
		button_2.Enabled = EnablePt1;
		if (SelectAllVar.PtValue <= 1.0)
		{
			button_2.BackColor = colorActive;
		}
		if (SelectAllVar.PtValue == 2.0)
		{
			button_1.BackColor = colorActive;
		}
		if (SelectAllVar.PtValue == 3.0)
		{
			button_0.BackColor = colorActive;
		}
		if (SelectAllVar.PtValue >= 4.0)
		{
			button_3.BackColor = colorActive;
		}
		checkBox_0.Checked = SelectAllVar.SelectAll;
		checkBox_5.Checked = SelectAllVar.SelectHeight;
		checkBox_3.Checked = SelectAllVar.SelectAngle;
		checkBox_2.Checked = SelectAllVar.SelectHorizontal;
		checkBox_4.Checked = SelectAllVar.SelectNegative;
		checkBox_1.Checked = SelectAllVar.SelectVertical;
		Result = DialogResult.Cancel;
		bool_0 = true;
		Class76.smethod_506(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Result != DialogResult.OK)
		{
			e.Cancel = true;
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
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		button_2.BackColor = colorPassive;
		button_1.BackColor = colorPassive;
		button_0.BackColor = colorPassive;
		button_3.BackColor = colorPassive;
		if (control.Name == button_2.Name)
		{
			button_2.BackColor = colorActive;
			SelectAllVar.PtValue = 1.0;
		}
		if (control.Name == button_1.Name)
		{
			button_1.BackColor = colorActive;
			SelectAllVar.PtValue = 2.0;
		}
		if (control.Name == button_0.Name)
		{
			button_0.BackColor = colorActive;
			SelectAllVar.PtValue = 3.0;
		}
		if (control.Name == button_3.Name)
		{
			button_3.BackColor = colorActive;
			SelectAllVar.PtValue = 4.0;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (bool_0 && checkBox_0.Checked)
		{
			checkBox_3.Checked = false;
			checkBox_5.Checked = false;
			checkBox_2.Checked = false;
			checkBox_4.Checked = false;
			checkBox_1.Checked = false;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (bool_0 && checkBox_1.Checked)
		{
			checkBox_0.Checked = false;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (bool_0 && checkBox_2.Checked)
		{
			checkBox_0.Checked = false;
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (bool_0 && checkBox_3.Checked)
		{
			checkBox_0.Checked = false;
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		if (bool_0 && checkBox_4.Checked)
		{
			checkBox_0.Checked = false;
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		if (bool_0 && checkBox_5.Checked)
		{
			checkBox_0.Checked = false;
		}
	}

	internal void method_8(object sender, EventArgs e)
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

	internal void method_9(object sender, EventArgs e)
	{
		SelectAllVar.SelectAll = checkBox_0.Checked;
		SelectAllVar.SelectHeight = checkBox_5.Checked;
		SelectAllVar.SelectAngle = checkBox_3.Checked;
		SelectAllVar.SelectHorizontal = checkBox_2.Checked;
		SelectAllVar.SelectNegative = checkBox_4.Checked;
		SelectAllVar.SelectVertical = checkBox_1.Checked;
		if (!checkBox_3.Checked & !checkBox_5.Checked & !checkBox_2.Checked & !checkBox_4.Checked & !checkBox_1.Checked)
		{
			SelectAllVar.SelectAll = true;
		}
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
