using System;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Profile;

public class F_DepthParameter : Form
{
	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	public ProfileDepth Depth = new ProfileDepth();

	private bool bool_0 = false;

	private IContainer icontainer_0 = null;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal ImageList imageList_0;

	internal Panel panel_0;

	internal Label label_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	public F_DepthParameter()
	{
		Class76.smethod_191(this);
	}

	public void Init()
	{
		numericUpDown_1.Value = (decimal)Depth.SafeMoveAbsolute;
		numericUpDown_0.Value = (decimal)Depth.SafeMoveRelative;
		checkBox_1.Checked = Depth.SaveMoveAbsouluteEnable;
		checkBox_0.Checked = Depth.SaveMoveRelativeEnable;
		if (Depth.Type == ProfileDepthModeType.EachLayerStep)
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
		}
		if (Depth.Type == ProfileDepthModeType.SelectedLayer)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
		}
		bool_0 = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	internal void method_1(object sender, FormClosingEventArgs e)
	{
		if (bool_0 && Result != DialogResult.OK)
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

	internal void method_2(object sender, EventArgs e)
	{
		Apply();
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

	internal void method_3(object sender, EventArgs e)
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

	public void Apply()
	{
		Depth.SafeMoveAbsolute = (double)numericUpDown_1.Value;
		Depth.SafeMoveRelative = (double)numericUpDown_0.Value;
		Depth.SaveMoveAbsouluteEnable = checkBox_1.Checked;
		Depth.SaveMoveRelativeEnable = checkBox_0.Checked;
		if (radioButton_0.Checked)
		{
			Depth.Type = ProfileDepthModeType.EachLayerStep;
		}
		if (radioButton_1.Checked)
		{
			Depth.Type = ProfileDepthModeType.SelectedLayer;
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
