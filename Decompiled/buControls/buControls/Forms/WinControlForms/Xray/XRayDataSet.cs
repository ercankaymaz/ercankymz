using System;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Xray;

public class XRayDataSet : Form
{
	public XRayData XRayVar = new XRayData();

	public FormProperties Properties = new FormProperties();

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal NumericUpDown numericUpDown_5;

	internal Label label_5;

	internal NumericUpDown numericUpDown_6;

	internal Label label_6;

	internal NumericUpDown numericUpDown_7;

	internal Label label_7;

	internal NumericUpDown numericUpDown_8;

	internal Label label_8;

	internal NumericUpDown numericUpDown_9;

	internal Label label_9;

	internal NumericUpDown numericUpDown_10;

	internal Label label_10;

	internal CheckBox checkBox_0;

	internal RadioButton radioButton_0;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal RadioButton radioButton_1;

	internal Panel panel_0;

	internal ImageList imageList_0;

	internal Button button_0;

	internal Button button_1;

	internal NumericUpDown numericUpDown_11;

	internal Label label_11;

	internal NumericUpDown numericUpDown_12;

	internal Label label_12;

	public XRayDataSet()
	{
		Class76.smethod_785(this);
	}

	public void Init()
	{
		try
		{
			numericUpDown_10.Value = (decimal)XRayVar.Bottom;
			numericUpDown_3.Value = (decimal)XRayVar.FlipH;
			numericUpDown_6.Value = (decimal)XRayVar.FlipV;
			numericUpDown_5.Value = (decimal)XRayVar.Frames;
			numericUpDown_0.Value = (decimal)XRayVar.Kv;
			numericUpDown_9.Value = (decimal)XRayVar.Left;
			numericUpDown_1.Value = (decimal)XRayVar.Ma;
			numericUpDown_7.Value = (decimal)XRayVar.Right;
			numericUpDown_4.Value = (decimal)XRayVar.Rot;
			numericUpDown_2.Value = (decimal)XRayVar.Time;
			numericUpDown_8.Value = (decimal)XRayVar.Top;
			numericUpDown_11.Value = (decimal)XRayVar.GrayAuto;
			numericUpDown_12.Value = (decimal)XRayVar.FeedVel;
			if (XRayVar.Focus != XRayFocus.Large)
			{
				radioButton_0.Checked = false;
				radioButton_1.Checked = true;
			}
			else
			{
				radioButton_0.Checked = true;
				radioButton_1.Checked = false;
			}
			checkBox_1.Checked = XRayVar.Image;
			checkBox_2.Checked = XRayVar.Video;
			checkBox_0.Checked = XRayVar.XRay;
		}
		catch (Exception)
		{
		}
	}

	public void Apply()
	{
		XRayVar.Bottom = (double)numericUpDown_10.Value;
		XRayVar.FlipH = (double)numericUpDown_3.Value;
		XRayVar.FlipV = (double)numericUpDown_6.Value;
		XRayVar.Frames = (double)numericUpDown_5.Value;
		XRayVar.Kv = (double)numericUpDown_0.Value;
		XRayVar.Left = (double)numericUpDown_9.Value;
		XRayVar.Ma = (double)numericUpDown_1.Value;
		XRayVar.Right = (double)numericUpDown_7.Value;
		XRayVar.Rot = (double)numericUpDown_4.Value;
		XRayVar.Time = (double)numericUpDown_2.Value;
		XRayVar.Top = (double)numericUpDown_8.Value;
		XRayVar.GrayAuto = (double)numericUpDown_11.Value;
		XRayVar.FeedVel = (double)numericUpDown_12.Value;
		XRayVar.Image = checkBox_1.Checked;
		XRayVar.Video = checkBox_2.Checked;
		XRayVar.XRay = checkBox_0.Checked;
		if (!radioButton_0.Checked)
		{
			XRayVar.Focus = XRayFocus.Small;
		}
		else
		{
			XRayVar.Focus = XRayFocus.Large;
		}
	}

	internal void method_0(object sender, EventArgs e)
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

	internal void method_1(object sender, EventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
