using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Viewer;
using ns27;

namespace buControls.Forms.WinControlForms.Profile;

public class F_NewProfile : Form
{
	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	public ProfileNewType SelectedType = ProfileNewType.Rectangle;

	public List<eEntities> PreviewEnts = new List<eEntities>();

	public string ItemName = "";

	public string ItemLength = "";

	public double ItemWidth = 100.0;

	public double ItemHeight = 100.0;

	public double ItemThickness = 2.0;

	public double ItemRadius = 100.0;

	public double ItemDiameter = 100.0;

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_0;

	internal ListBox listBox_0;

	internal buViewer buViewer_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Panel panel_0;

	internal Panel panel_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal Panel panel_2;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal Panel panel_3;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal Panel panel_4;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal Panel panel_5;

	internal NumericUpDown numericUpDown_5;

	internal Label label_5;

	internal Panel panel_6;

	internal NumericUpDown numericUpDown_6;

	internal Label label_6;

	internal Panel panel_7;

	internal NumericUpDown numericUpDown_7;

	internal Label label_7;

	internal CheckBox checkBox_0;

	internal ImageList imageList_1;

	internal CheckBox checkBox_1;

	internal Panel panel_8;

	internal Label label_8;

	internal Label label_9;

	public ComboBox cmb_length;

	public TextBox txt_name;

	public F_NewProfile()
	{
		Class76.smethod_206(this);
	}

	public void Init()
	{
		bool_0 = false;
		cmb_length.Items.Clear();
		cmb_length.Items.Add(100);
		cmb_length.Items.Add(500);
		cmb_length.Items.Add(800);
		cmb_length.Items.Add(1000);
		cmb_length.Items.Add(1200);
		cmb_length.Items.Add(1500);
		cmb_length.Items.Add(2000);
		cmb_length.Items.Add(3000);
		cmb_length.Items.Add(4000);
		cmb_length.Items.Add(5000);
		cmb_length.Items.Add(6000);
		listBox_0.Items.Clear();
		listBox_0.Items.Add("Rectangle");
		listBox_0.Items.Add("Circle");
		listBox_0.SelectedIndex = 0;
		bool_0 = true;
		numericUpDown_0.Value = (decimal)ItemWidth;
		numericUpDown_1.Value = (decimal)ItemHeight;
		numericUpDown_2.Value = (decimal)ItemThickness;
		listBox_0.SelectedIndex = 0;
		UpdateByProfileType(0);
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		bool_0 = false;
		UpdateByProfileType(listBox_0.SelectedIndex);
		bool_0 = true;
	}

	public void UpdateByProfileType(int Index)
	{
		panel_0.Visible = false;
		panel_1.Visible = false;
		panel_2.Visible = false;
		panel_3.Visible = false;
		panel_7.Visible = false;
		panel_6.Visible = false;
		panel_5.Visible = false;
		panel_4.Visible = false;
		if (Index == 0)
		{
			panel_0.Visible = true;
			panel_1.Visible = true;
			panel_2.Visible = true;
			label_0.Text = "Width";
			label_1.Text = "Height";
			label_2.Text = "Thickness";
			numericUpDown_0.Value = (decimal)ItemWidth;
			numericUpDown_1.Value = (decimal)ItemHeight;
			numericUpDown_2.Value = (decimal)ItemThickness;
			PreviewEnts.Clear();
			List<Pnt3D> Vertices = new List<Pnt3D>();
			buControlCoreClass.cVector.RectangleCenter(new Pnt3D(ItemWidth / 2.0, ItemHeight / 2.0), ItemWidth, ItemHeight, new WorkPlane(), ref Vertices);
			for (int i = 1; i <= Vertices.Count - 1; i++)
			{
				eEntities item = new eLine(new Pnt3D(Vertices[i - 1]), new Pnt3D(Vertices[i]));
				PreviewEnts.Add(item);
			}
			if (ItemThickness > 0.0)
			{
				Vertices = new List<Pnt3D>();
				buControlCoreClass.cVector.RectangleCenter(new Pnt3D(ItemWidth / 2.0, ItemHeight / 2.0), ItemWidth - ItemThickness * 2.0, ItemHeight - ItemThickness * 2.0, new WorkPlane(), ref Vertices);
				for (int j = 1; j <= Vertices.Count - 1; j++)
				{
					eEntities item2 = new eLine(new Pnt3D(Vertices[j - 1]), new Pnt3D(Vertices[j]));
					PreviewEnts.Add(item2);
				}
			}
			buViewer_0.Entities.Clear();
			buViewer_0.AddEntities(PreviewEnts);
			buViewer_0.DrawEntities();
			buViewer_0.ZoomFit();
			buViewer_0.ZoomOut();
			SelectedType = ProfileNewType.Rectangle;
		}
		if (Index != 1)
		{
			return;
		}
		panel_0.Visible = true;
		panel_1.Visible = true;
		label_0.Text = "Diameter";
		label_1.Text = "Thickness";
		numericUpDown_0.Value = (decimal)ItemDiameter;
		numericUpDown_1.Value = (decimal)ItemThickness;
		PreviewEnts.Clear();
		List<Pnt3D> Vertices2 = new List<Pnt3D>();
		buControlCoreClass.cVector.CircleWithCenter(new Pnt3D(ItemDiameter / 2.0, ItemDiameter / 2.0), ItemDiameter / 2.0, new WorkPlane(), new EntityResolution(), ref Vertices2);
		for (int k = 1; k <= Vertices2.Count - 1; k++)
		{
			eEntities item3 = new eLine(new Pnt3D(Vertices2[k - 1]), new Pnt3D(Vertices2[k]));
			PreviewEnts.Add(item3);
		}
		if (ItemThickness > 0.0)
		{
			Vertices2 = new List<Pnt3D>();
			buControlCoreClass.cVector.CircleWithCenter(new Pnt3D(ItemDiameter / 2.0, ItemDiameter / 2.0), ItemDiameter / 2.0 - ItemThickness, new WorkPlane(), new EntityResolution(), ref Vertices2);
			for (int l = 1; l <= Vertices2.Count - 1; l++)
			{
				eEntities item4 = new eLine(new Pnt3D(Vertices2[l - 1]), new Pnt3D(Vertices2[l]));
				PreviewEnts.Add(item4);
			}
		}
		buViewer_0.Entities.Clear();
		buViewer_0.AddEntities(PreviewEnts);
		buViewer_0.DrawEntities();
		buViewer_0.ZoomFit();
		buViewer_0.ZoomOut();
		SelectedType = ProfileNewType.Rectangle;
	}

	public void UpdateData(int Index)
	{
		if (Index == 0)
		{
			ItemWidth = (double)numericUpDown_0.Value;
			ItemHeight = (double)numericUpDown_1.Value;
			ItemThickness = (double)numericUpDown_2.Value;
		}
		if (Index == 1)
		{
			ItemDiameter = (double)numericUpDown_0.Value;
			ItemThickness = (double)numericUpDown_1.Value;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			UpdateByProfileType(listBox_0.SelectedIndex);
			ItemLength = cmb_length.Text;
			ItemName = txt_name.Text;
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
		if (control.Name == button_1.Name)
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
	}

	internal void method_3(object sender, FormClosingEventArgs e)
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

	internal void method_4(object sender, EventArgs e)
	{
		if (bool_0)
		{
			UpdateData(listBox_0.SelectedIndex);
			UpdateByProfileType(listBox_0.SelectedIndex);
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
