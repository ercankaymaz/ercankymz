using System;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Plane;

public class F_PlaneBasePntAngLen : Form
{
	public FormProperties Properties = new FormProperties();

	public WorkPlane Plane = new WorkPlane();

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_3;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	internal CheckBox checkBox_0;

	internal Label label_4;

	internal Label label_5;

	internal CheckBox checkBox_1;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal Label label_6;

	internal NumericUpDown numericUpDown_4;

	public F_PlaneBasePntAngLen()
	{
		Class76.smethod_483(this);
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
		if (Plane.UseCenterPoint)
		{
			numericUpDown_2.Value = (decimal)Plane.MiddlePoint.Y;
			numericUpDown_3.Value = (decimal)Plane.MiddlePoint.Z;
		}
		else
		{
			numericUpDown_2.Value = (decimal)Plane.BasePoint.Y;
			numericUpDown_3.Value = (decimal)Plane.BasePoint.Z;
		}
		numericUpDown_1.Value = (decimal)Plane.Angles.A;
		numericUpDown_0.Value = (decimal)Plane.Lenght;
		checkBox_0.Checked = Plane.UseCenterPoint;
		checkBox_1.Checked = Plane.isCircular;
		numericUpDown_4.Value = (decimal)Plane.CircularAngle;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
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
			Class76.smethod_118(this);
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

	internal void method_1(object sender, FormClosingEventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
