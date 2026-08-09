using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_NewProfile : Form
{
	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	public ProfileNewType SelectedType = ProfileNewType.Rectangle;

	public LeftRightType XDirRefType = LeftRightType.Left;

	public bool RightProfile = false;

	public List<Entity> PreviewEnts = new List<Entity>();

	public string ItemName = "";

	public string ItemLength = "";

	public double ItemWidth = 100.0;

	public double ItemHeight = 100.0;

	public double ItemThickness = 2.0;

	public double ItemRadius = 100.0;

	public double ItemDiameter = 100.0;

	public int StandartProfileIndex = -1;

	public int MaxClamper = 4;

	private Design design_0 = null;

	private Timer timer_0 = null;

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_0;

	internal ListBox listBox_0;

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

	internal Panel panel_9;

	internal Label label_10;

	internal Label label_11;

	internal Label label_12;

	internal Label label_13;

	internal Label label_14;

	internal Label label_15;

	internal Label label_16;

	internal Label label_17;

	internal Panel panel_10;

	public NumericUpDown spn_supportblocky2W;

	public NumericUpDown spn_supportblockzW;

	public NumericUpDown spn_supportblocky1W;

	public NumericUpDown spn_supportblocky2H;

	public NumericUpDown spn_supportblockzH;

	public NumericUpDown spn_supportblocky1H;

	public NumericUpDown spn_rightangle;

	public NumericUpDown spn_leftangle;

	public RadioButton radio_rightholder;

	public RadioButton radio_leftholder;

	internal Label label_18;

	internal NumericUpDown numericUpDown_8;

	public CheckBox chk_multilymirror;

	public NumericUpDown spn_multiplyspace;

	public Label lbl_multiplyspace;

	public NumericUpDown spn_multiplycount;

	public Label lbl_multiplycount;

	public CheckBox chk_multiplyprofile;

	public F_NewProfile()
	{
		Class186.smethod_397(this);
	}

	public void Init()
	{
		bool_0 = false;
		if (design_0 == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref design_0);
			design_0.Dock = DockStyle.Fill;
			panel_9.Controls.Add(design_0);
		}
		radio_rightholder.Enabled = RightProfile;
		if (!RightProfile)
		{
			XDirRefType = LeftRightType.Left;
		}
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
		numericUpDown_8.Value = MaxClamper;
		listBox_0.SelectedIndex = 0;
		if (timer_0 == null)
		{
			timer_0 = new Timer();
			timer_0.Interval = 20;
			timer_0.Tick += Init_Tick;
		}
		timer_0.Enabled = true;
	}

	public void Init_Tick(object sender, EventArgs e)
	{
		if (design_0.IsHandleCreated)
		{
			UpdateByProfileType(0);
			timer_0.Enabled = false;
		}
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
			if (design_0.IsHandleCreated)
			{
				design_0.Entities.Clear();
				design_0.Entities.Add(CompositeCurve.CreateRectangle(ItemWidth, ItemHeight));
				if (ItemThickness > 0.0)
				{
					CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(ItemWidth - ItemThickness * 2.0, ItemHeight - ItemThickness * 2.0);
					compositeCurve.Translate(ItemThickness, ItemThickness);
					design_0.Entities.Add(compositeCurve);
				}
				design_0.SetView(viewType.Top);
				design_0.ZoomFit();
				design_0.ZoomOut(10);
				design_0.Invalidate();
			}
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
		if (design_0.IsHandleCreated)
		{
			design_0.Entities.Clear();
			design_0.Entities.Add(new Circle(new Point3D(), ItemWidth / 2.0));
			if (ItemThickness > 0.0)
			{
				design_0.Entities.Add(new Circle(new Point3D(), ItemWidth / 2.0 - ItemThickness));
			}
			design_0.SetView(viewType.Top);
			design_0.ZoomFit();
			design_0.ZoomOut(10);
			design_0.Invalidate();
		}
		SelectedType = ProfileNewType.Circle;
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
			PreviewEnts.Clear();
			PreviewEnts = new List<Entity>();
			buVector5.CopyEntities(design_0.Entities, ref PreviewEnts);
			MaxClamper = (int)numericUpDown_8.Value;
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
