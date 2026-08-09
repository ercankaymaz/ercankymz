using System;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.ModuleWorks;

public class F_MwTriangleMeshRough : Form
{
	public FormProperties Properties = new FormProperties();

	private IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Label label_0;

	internal Panel panel_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_5;

	internal Panel panel_2;

	internal Label label_6;

	internal Button button_0;

	internal NumericUpDown numericUpDown_4;

	internal Label label_7;

	internal Panel panel_3;

	internal Button button_1;

	internal NumericUpDown numericUpDown_5;

	internal NumericUpDown numericUpDown_6;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal Label label_8;

	internal Panel panel_4;

	internal NumericUpDown numericUpDown_7;

	internal RadioButton radioButton_4;

	internal Label label_9;

	internal RadioButton radioButton_5;

	internal RadioButton radioButton_6;

	internal Panel panel_5;

	internal Label label_10;

	internal RadioButton radioButton_7;

	internal RadioButton radioButton_8;

	internal Panel panel_6;

	internal RadioButton radioButton_9;

	internal Label label_11;

	internal Panel panel_7;

	internal CheckBox checkBox_0;

	internal Button button_2;

	internal CheckBox checkBox_1;

	internal Button button_3;

	internal CheckBox checkBox_2;

	internal Button button_4;

	internal CheckBox checkBox_3;

	internal Button button_5;

	internal CheckBox checkBox_4;

	internal Button button_6;

	internal CheckBox checkBox_5;

	internal Label label_12;

	internal NumericUpDown numericUpDown_8;

	internal Label label_13;

	internal CheckBox checkBox_6;

	internal Panel panel_8;

	internal Label label_14;

	internal RadioButton radioButton_10;

	internal RadioButton radioButton_11;

	internal PictureBox pictureBox_0;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_15;

	internal Label label_16;

	public F_MwTriangleMeshRough()
	{
		Class76.smethod_458(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
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

	internal void method_1(object sender, EventArgs e)
	{
		Apply();
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

	internal void method_2(object sender, EventArgs e)
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

	public void UpdateControlFromType()
	{
	}

	public void Apply()
	{
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
