using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using devDept.Eyeshot.Control;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_Material : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MaterialBase5 Material = new MaterialBase5();

	public Design viewportLayout;

	public string pathTool = Application.StartupPath;

	private IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal TabPage tabPage_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal TabPage tabPage_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal TabPage tabPage_3;

	internal NumericUpDown numericUpDown_5;

	internal Label label_5;

	internal NumericUpDown numericUpDown_6;

	internal Label label_6;

	internal Label label_7;

	internal TextBox textBox_0;

	internal Label label_8;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

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

	internal TabPage tabPage_4;

	internal Button button_0;

	public Panel pnl_model;

	public F_Material()
	{
		Class186.smethod_228(this);
	}

	public void Init()
	{
		numericUpDown_1.Value = (decimal)Material.Size.Width;
		numericUpDown_0.Value = (decimal)Material.Size.Height;
		numericUpDown_2.Value = (decimal)Material.Radius;
		numericUpDown_4.Value = (decimal)Material.MajorRadius;
		numericUpDown_3.Value = (decimal)Material.MinorRadius;
		numericUpDown_6.Value = (decimal)Material.Size.Depth;
		numericUpDown_5.Value = (decimal)Material.Angle;
		numericUpDown_11.Value = (decimal)Material.StartPoint.X;
		numericUpDown_10.Value = (decimal)Material.StartPoint.Y;
		numericUpDown_9.Value = (decimal)Material.StartPoint.Z;
		button_0.BackColor = Material.Display.SkinColor;
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
		Properties.Result = DialogResult.None;
		listBox_0.Items.Clear();
		for (int i = 0; i <= Material.Points.Count - 1; i++)
		{
			listBox_0.Items.Add(Material.Points[i].X.ToString("f1") + " , " + Material.Points[i].Y.ToString("f1"));
		}
		Class186.smethod_787(this);
		Class186.smethod_127(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Class186.smethod_26(this);
		Properties.Result = DialogResult.OK;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Properties.Result = DialogResult.Cancel;
		Dispose();
	}

	internal void method_2(object sender, EventArgs e)
	{
		Material.Points.Add(new Point3D((double)numericUpDown_8.Value, (double)numericUpDown_7.Value));
		listBox_0.Items.Add(Material.Points[Material.Points.Count - 1].X.ToString("f1") + " , " + Material.Points[Material.Points.Count - 1].Y.ToString("f1"));
		Class186.smethod_127(this);
	}

	internal void method_3(object sender, EventArgs e)
	{
		if ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Material.Points.Count - 1))
		{
			Material.Points.RemoveAt(listBox_0.SelectedIndex);
			listBox_0.Items.RemoveAt(listBox_0.SelectedIndex);
			Class186.smethod_127(this);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (tabControl_0.SelectedIndex == 0)
		{
			Material.Shapes = MaterialShapes.Rectangle;
		}
		if (tabControl_0.SelectedIndex == 1)
		{
			Material.Shapes = MaterialShapes.Circle;
		}
		if (tabControl_0.SelectedIndex == 2)
		{
			Material.Shapes = MaterialShapes.Ellipse;
		}
		if (tabControl_0.SelectedIndex == 3)
		{
			Material.Shapes = MaterialShapes.Irregular;
		}
		if (tabControl_0.SelectedIndex == 4)
		{
			Material.Shapes = MaterialShapes.FromFile;
		}
		Class186.smethod_26(this);
		Class186.smethod_127(this);
	}

	internal void method_5(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (Properties.Inited)
		{
			if (control.Name == numericUpDown_1.Name)
			{
				Material.Size.Width = (double)numericUpDown_1.Value;
			}
			if (control.Name == numericUpDown_0.Name)
			{
				Material.Size.Height = (double)numericUpDown_0.Value;
			}
			if (control.Name == numericUpDown_4.Name)
			{
				Material.MajorRadius = (double)numericUpDown_4.Value;
			}
			if (control.Name == numericUpDown_3.Name)
			{
				Material.MinorRadius = (double)numericUpDown_3.Value;
			}
			if (control.Name == numericUpDown_2.Name)
			{
				Material.Radius = (double)numericUpDown_2.Value;
			}
			if (control.Name == numericUpDown_6.Name)
			{
				Material.Size.Depth = (double)numericUpDown_6.Value;
			}
			if (control.Name == numericUpDown_5.Name)
			{
				Material.Angle = (double)numericUpDown_5.Value;
			}
			Class186.smethod_127(this);
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		ColorDialogBox.ShowDialog(button_0.BackColor);
		if (ColorDialogBox.Result == DialogResult.OK)
		{
			button_0.BackColor = ColorDialogBox.Color;
			button_0.ForeColor = buImage5.InvertColorNoGray(button_0.BackColor);
			button_0.Text = buImage5.GetColorKnownName(button_0.BackColor);
			Material.Display.SkinColor = ColorDialogBox.Color;
			Class186.smethod_127(this);
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
