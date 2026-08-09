using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.ColorPicker;
using buControls.Viewer;
using ns27;

namespace buControls.Forms.WinControlForms.Materials;

public class F_Material : Form
{
	public MaterialBase Material = new MaterialBase();

	public DialogResult Result = DialogResult.None;

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal PictureBox pictureBox_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal TabPage tabPage_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal PictureBox pictureBox_1;

	internal TabPage tabPage_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal PictureBox pictureBox_2;

	internal TabPage tabPage_3;

	internal NumericUpDown numericUpDown_5;

	internal Label label_5;

	internal NumericUpDown numericUpDown_6;

	internal Label label_6;

	internal Label label_7;

	internal TextBox textBox_0;

	internal buColorComboBox buColorComboBox_0;

	internal Label label_8;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal buViewer buViewer_0;

	public Button btn_add;

	public Button btn_remove;

	internal NumericUpDown numericUpDown_7;

	internal Label label_9;

	internal NumericUpDown numericUpDown_8;

	internal Label label_10;

	internal ListBox listBox_0;

	internal NumericUpDown numericUpDown_9;

	internal NumericUpDown numericUpDown_10;

	internal NumericUpDown numericUpDown_11;

	internal Label label_11;

	internal NumericUpDown numericUpDown_12;

	internal Label label_12;

	public F_Material()
	{
		Class76.smethod_628(this);
	}

	public void Init()
	{
		numericUpDown_1.Value = (decimal)Material.Width;
		numericUpDown_0.Value = (decimal)Material.Height;
		numericUpDown_2.Value = (decimal)Material.Radius;
		numericUpDown_4.Value = (decimal)Material.MajorRadius;
		numericUpDown_3.Value = (decimal)Material.MinorRadius;
		numericUpDown_6.Value = (decimal)Material.Thickness;
		numericUpDown_5.Value = (decimal)Material.Angle;
		numericUpDown_11.Value = (decimal)Material.StartPoint.X;
		numericUpDown_10.Value = (decimal)Material.StartPoint.Y;
		numericUpDown_9.Value = (decimal)Material.StartPoint.Z;
		buColorComboBox_0.Color = Material.Display.SkinColor;
		numericUpDown_12.Value = Material.Display.SkinTransperancy;
		textBox_0.Text = Material.Name;
		if (Material.Shapes == MaterialShapes.Rectangle)
		{
			tabControl_0.SelectedIndex = 0;
		}
		if (Material.Shapes == MaterialShapes.Circle)
		{
			tabControl_0.SelectedIndex = 1;
		}
		if (Material.Shapes == MaterialShapes.Ellipse)
		{
			tabControl_0.SelectedIndex = 2;
		}
		if (Material.Shapes == MaterialShapes.Irregular)
		{
			tabControl_0.SelectedIndex = 3;
		}
		Result = DialogResult.None;
		listBox_0.Items.Clear();
		for (int i = 0; i <= Material.Points.Count - 1; i++)
		{
			listBox_0.Items.Add(Material.Points[i].X.ToString("f1") + " , " + Material.Points[i].Y.ToString("f1"));
		}
		Class76.smethod_591(this);
		Class76.smethod_416(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Class76.smethod_226(this);
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		Dispose();
	}

	internal void method_2(object sender, EventArgs e)
	{
		Material.Points.Add(new Pnt3D((double)numericUpDown_8.Value, (double)numericUpDown_7.Value));
		listBox_0.Items.Add(Material.Points[Material.Points.Count - 1].X.ToString("f1") + " , " + Material.Points[Material.Points.Count - 1].Y.ToString("f1"));
		Class76.smethod_416(this);
	}

	internal void method_3(object sender, EventArgs e)
	{
		if ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Material.Points.Count - 1))
		{
			Material.Points.RemoveAt(listBox_0.SelectedIndex);
			listBox_0.Items.RemoveAt(listBox_0.SelectedIndex);
			Class76.smethod_416(this);
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
