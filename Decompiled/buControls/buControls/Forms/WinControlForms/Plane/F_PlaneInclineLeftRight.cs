using System;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Plane;

public class F_PlaneInclineLeftRight : Form
{
	public FormProperties Properties = new FormProperties();

	public ProfilePlaneData Plane = new ProfilePlaneData();

	public Pnt3D PlanePoint = new Pnt3D();

	public double Angle = 45.0;

	public double Length = 100.0;

	public planeInclineType PlaneType = planeInclineType.Distance;

	public LeftRightLocationType Direction = LeftRightLocationType.Right;

	public double ProfileW = 100.0;

	public double ProfileH = 0.0;

	private IContainer icontainer_0 = null;

	internal PictureBox pictureBox_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal Label label_2;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Label label_3;

	internal Label label_4;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal Label label_5;

	internal PictureBox pictureBox_1;

	internal Label label_6;

	internal NumericUpDown numericUpDown_2;

	internal Label label_7;

	internal NumericUpDown numericUpDown_3;

	internal ImageList imageList_2;

	internal Label label_8;

	internal NumericUpDown numericUpDown_4;

	internal Label label_9;

	internal NumericUpDown numericUpDown_5;

	public F_PlaneInclineLeftRight()
	{
		Class76.smethod_243(this);
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
		numericUpDown_0.Value = (decimal)PlanePoint.Y;
		numericUpDown_1.Value = (decimal)PlanePoint.Z;
		numericUpDown_2.Value = (decimal)PlanePoint.Y;
		numericUpDown_3.Value = (decimal)PlanePoint.Z;
		numericUpDown_5.Value = (decimal)Angle;
		numericUpDown_4.Value = (decimal)Length;
		label_3.Text = "W= " + ProfileW.ToString("f2");
		label_4.Text = "H= " + ProfileH.ToString("f2");
		if (Direction == LeftRightLocationType.Left)
		{
			radioButton_0.Checked = true;
			pictureBox_0.Image = imageList_1.Images[0];
			pictureBox_1.Image = imageList_2.Images[0];
		}
		if (Direction == LeftRightLocationType.Right)
		{
			radioButton_1.Checked = true;
			pictureBox_0.Image = imageList_1.Images[1];
			pictureBox_1.Image = imageList_2.Images[1];
		}
		if (PlaneType == planeInclineType.Distance)
		{
			tabControl_0.SelectedIndex = 0;
		}
		if (PlaneType == planeInclineType.Angle)
		{
			tabControl_0.SelectedIndex = 1;
		}
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
			Class76.smethod_658(this);
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

	internal void method_2(object sender, EventArgs e)
	{
		if (Properties.Inited)
		{
			if (tabControl_0.SelectedIndex == 0)
			{
				PlaneType = planeInclineType.Distance;
			}
			if (tabControl_0.SelectedIndex == 1)
			{
				PlaneType = planeInclineType.Angle;
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (Properties.Inited)
		{
			if (control.Name == radioButton_0.Name)
			{
				pictureBox_0.Image = imageList_1.Images[0];
				Direction = LeftRightLocationType.Left;
			}
			if (control.Name == radioButton_1.Name)
			{
				pictureBox_0.Image = imageList_1.Images[1];
				Direction = LeftRightLocationType.Right;
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
