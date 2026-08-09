using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.UserFiles.buCad;
using buControls.DialogBox;
using ns27;

namespace buControls.Forms.WinControlForms.CAM;

public class F_CamSettings : Form
{
	public FormProperties Properties = new FormProperties();

	public setCam varCam = new setCam();

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal CheckBox checkBox_3;

	internal CheckBox checkBox_4;

	internal CheckBox checkBox_5;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal CheckBox checkBox_6;

	internal Button button_7;

	internal CheckBox checkBox_7;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal NumericUpDown numericUpDown_4;

	internal NumericUpDown numericUpDown_5;

	internal NumericUpDown numericUpDown_6;

	internal NumericUpDown numericUpDown_7;

	public F_CamSettings()
	{
		Class76.smethod_677(this);
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
		base.AutoScaleMode = Properties.ScaleFromMode;
		checkBox_0.Checked = varCam.ShowCamG0Drawings;
		checkBox_1.Checked = varCam.ShowCamG1Drawings;
		checkBox_6.Checked = varCam.ShowCamLeadinDrawings;
		checkBox_7.Checked = varCam.ShowCamLeadOutDrawings;
		checkBox_4.Checked = varCam.ShowCamLeaveDrawings;
		checkBox_2.Checked = varCam.ShowCamMarkDrawings;
		checkBox_3.Checked = varCam.ShowCamOtherDrawings;
		checkBox_5.Checked = varCam.ShowCamPlungeDrawings;
		button_0.BackColor = varCam.CamG0Draw.Color;
		button_1.BackColor = varCam.CamG1Draw.Color;
		button_6.BackColor = varCam.CamLeadinDraw.Color;
		button_7.BackColor = varCam.CamLeadOutDraw.Color;
		button_4.BackColor = varCam.CamLeaveDraw.Color;
		button_2.BackColor = varCam.CamMarkDraw.Color;
		button_5.BackColor = varCam.CamOtherDraw.Color;
		button_3.BackColor = varCam.CamPlungeDraw.Color;
		numericUpDown_0.Value = (decimal)varCam.CamG0Draw.Thickness;
		numericUpDown_1.Value = (decimal)varCam.CamG1Draw.Thickness;
		numericUpDown_6.Value = (decimal)varCam.CamLeadinDraw.Thickness;
		numericUpDown_5.Value = (decimal)varCam.CamLeadOutDraw.Thickness;
		numericUpDown_7.Value = (decimal)varCam.CamLeaveDraw.Thickness;
		numericUpDown_3.Value = (decimal)varCam.CamMarkDraw.Thickness;
		numericUpDown_4.Value = (decimal)varCam.CamOtherDraw.Thickness;
		numericUpDown_2.Value = (decimal)varCam.CamPlungeDraw.Thickness;
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		Class76.smethod_387(this);
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class76.smethod_0(this);
			Properties.Result = DialogResult.OK;
			Dispose();
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

	internal void method_2(object sender, EventArgs e)
	{
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			ColorDialogBox.ShowDialog(button_0.BackColor);
			if (ColorDialogBox.Result == DialogResult.OK)
			{
				button_0.BackColor = ColorDialogBox.Color;
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
