using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_SelectedPlanes : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public List<Entity> PreviewEnts = new List<Entity>();

	public List<SelectedPlaneInfo> Planes = new List<SelectedPlaneInfo>();

	public UCSObjectData UcsData = new UCSObjectData();

	public double PlaneThickess = 4.0;

	public int SelectedPlane = -1;

	public double Increment = 1.0;

	public string pathString = Application.StartupPath;

	internal Design design_0 = null;

	private Timer timer_0 = new Timer();

	internal Point3D point3D_0 = new Point3D();

	internal Point3D point3D_1 = new Point3D();

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_0;

	internal ListBox listBox_0;

	internal ImageList imageList_1;

	internal Panel panel_0;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Label label_0;

	internal Panel panel_1;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	internal Button button_9;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal Button button_10;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal NumericUpDown numericUpDown_5;

	internal Label label_5;

	internal Button button_11;

	internal ImageList imageList_2;

	internal Button button_12;

	internal Button button_13;

	internal Button button_14;

	internal Button button_15;

	internal Button button_16;

	internal Button button_17;

	internal Button button_18;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	public F_SelectedPlanes()
	{
		Class186.smethod_130(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		if (design_0 == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = true;
			eyeCreateProps.ShowOrigin = false;
			eyeCreateProps.ShowOriginCaption = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref design_0);
			design_0.Dock = DockStyle.Fill;
			panel_0.Controls.Add(design_0);
		}
		timer_0.Tick += timer_0_Tick;
		timer_0.Interval = 100;
		timer_0.Enabled = true;
		Class186.smethod_660(this);
		Class186.smethod_330(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		listBox_0.Items.Clear();
		if (SelectedPlane >= 0 && SelectedPlane <= listBox_0.Items.Count - 1)
		{
			listBox_0.SelectedIndex = SelectedPlane;
		}
		for (int i = 0; i <= PreviewEnts.Count - 1; i++)
		{
			Entity entity = buVector5.CopyEntities(PreviewEnts[i]);
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Profile;
			entity.EntityData = customData;
			design_0.Entities.Add(entity);
		}
		buCall.buVector5_0.BoxSizeCalculate(PreviewEnts, ref point3D_0, ref point3D_1);
		design_0.ActiveViewport.ViewCubeIcon.Visible = false;
		design_0.SetView(viewType.vcFrontFaceTopLeft);
		design_0.ZoomFit();
		design_0.ZoomOut(2);
		design_0.Invalidate();
		for (int j = 0; j <= Planes.Count - 1; j++)
		{
			Class186.smethod_96(false, Planes[j], this);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		PropertiesForm.Inited = false;
		design_0.Entities.ClearSelection();
		if ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= design_0.Entities.Count - 1))
		{
			for (int i = 0; i <= design_0.Entities.Count - 1; i++)
			{
				if (design_0.Entities[i].EntityData != null && design_0.Entities[i].EntityData is CustomData)
				{
					CustomData customData = design_0.Entities[i].EntityData as CustomData;
					if (customData.RefIndex == listBox_0.SelectedIndex)
					{
						design_0.Entities[i].Selected = true;
					}
				}
			}
			numericUpDown_0.Value = (decimal)Planes[listBox_0.SelectedIndex].Angle;
			numericUpDown_1.Value = (decimal)Planes[listBox_0.SelectedIndex].pntPlane.X;
			numericUpDown_2.Value = (decimal)Planes[listBox_0.SelectedIndex].pntPlane.Y;
			numericUpDown_3.Value = (decimal)Planes[listBox_0.SelectedIndex].pntPlane.Z;
			SelectedPlane = listBox_0.SelectedIndex;
		}
		design_0.Invalidate();
		PropertiesForm.Inited = true;
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == button_0.Name)
		{
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_1.Name)
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_10.Name)
		{
			if (panel_1.Visible)
			{
				panel_1.Visible = false;
			}
			else
			{
				panel_1.Visible = true;
			}
		}
		if (control.Name == button_9.Name)
		{
			SelectedPlaneInfo selectedPlaneInfo_ = new SelectedPlaneInfo();
			Class186.smethod_354(true, Planes.Count, this, ref selectedPlaneInfo_, ProfilePlaneDef.Top0);
			Planes.Add(selectedPlaneInfo_);
			Class186.smethod_96(false, selectedPlaneInfo_, this);
			panel_1.Visible = false;
		}
		if (control.Name == button_8.Name)
		{
			SelectedPlaneInfo selectedPlaneInfo_2 = new SelectedPlaneInfo();
			Class186.smethod_354(true, Planes.Count, this, ref selectedPlaneInfo_2, ProfilePlaneDef.Back45);
			Planes.Add(selectedPlaneInfo_2);
			Class186.smethod_96(false, selectedPlaneInfo_2, this);
			panel_1.Visible = false;
		}
		if (control.Name == button_7.Name)
		{
			SelectedPlaneInfo selectedPlaneInfo_3 = new SelectedPlaneInfo();
			Class186.smethod_354(true, Planes.Count, this, ref selectedPlaneInfo_3, ProfilePlaneDef.Back90);
			Planes.Add(selectedPlaneInfo_3);
			Class186.smethod_96(false, selectedPlaneInfo_3, this);
			panel_1.Visible = false;
		}
		if (control.Name == button_6.Name)
		{
			SelectedPlaneInfo selectedPlaneInfo_4 = new SelectedPlaneInfo();
			Class186.smethod_354(true, Planes.Count, this, ref selectedPlaneInfo_4, ProfilePlaneDef.Front45);
			Planes.Add(selectedPlaneInfo_4);
			Class186.smethod_96(false, selectedPlaneInfo_4, this);
			panel_1.Visible = false;
		}
		if (control.Name == button_5.Name)
		{
			SelectedPlaneInfo selectedPlaneInfo_5 = new SelectedPlaneInfo();
			Class186.smethod_354(true, Planes.Count, this, ref selectedPlaneInfo_5, ProfilePlaneDef.Front90);
			Planes.Add(selectedPlaneInfo_5);
			Class186.smethod_96(false, selectedPlaneInfo_5, this);
			panel_1.Visible = false;
		}
		if (control.Name == button_11.Name)
		{
			numericUpDown_0.Value -= (decimal)Increment;
		}
		if (control.Name == button_12.Name)
		{
			numericUpDown_0.Value += (decimal)Increment;
		}
		if (control.Name == button_14.Name)
		{
			numericUpDown_1.Value -= (decimal)Increment;
		}
		if (control.Name == button_13.Name)
		{
			numericUpDown_1.Value += (decimal)Increment;
		}
		if (control.Name == button_16.Name)
		{
			numericUpDown_2.Value -= (decimal)Increment;
		}
		if (control.Name == button_15.Name)
		{
			numericUpDown_2.Value += (decimal)Increment;
		}
		if (control.Name == button_18.Name)
		{
			numericUpDown_3.Value -= (decimal)Increment;
		}
		if (control.Name == button_17.Name)
		{
			numericUpDown_3.Value += (decimal)Increment;
		}
		if (control.Name == label_9.Name)
		{
			Increment = 0.1;
			Class186.smethod_660(this);
		}
		if (control.Name == label_10.Name)
		{
			Increment = 0.5;
			Class186.smethod_660(this);
		}
		if (control.Name == label_8.Name)
		{
			Increment = 1.0;
			Class186.smethod_660(this);
		}
		if (control.Name == label_7.Name)
		{
			Increment = 5.0;
			Class186.smethod_660(this);
		}
		if (control.Name == label_6.Name)
		{
			Increment = 10.0;
			Class186.smethod_660(this);
		}
		if (control.Name == button_2.Name && buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[97]) == DialogResult.Yes && ((SelectedPlane >= 0) & (SelectedPlane <= Planes.Count - 1)))
		{
			Class186.smethod_591(SelectedPlane, false, this);
		}
		if (control.Name == button_3.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = pathString;
			openFileDialog.Filter = "buCad/Cam Plane File (*.buplane)|*.buplane";
			openFileDialog.FilterIndex = 1;
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				pathString = buFile5.GetPath(openFileDialog.FileName);
				buFile5.OpenPlaneFile(openFileDialog.FileName, ref Planes);
				timer_0_Tick(null, null);
			}
		}
		if (control.Name == button_4.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = pathString;
			saveFileDialog.Filter = "buCad/Cam Plane File (*.buplane)|*.buplane";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				buFile5.SavePlaneFile(saveFileDialog.FileName, Planes);
				pathString = buFile5.GetPath(saveFileDialog.FileName);
			}
		}
	}

	internal void method_3(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited && ((SelectedPlane >= 0) & (SelectedPlane <= Planes.Count - 1)))
		{
			PropertiesForm.Inited = false;
			SelectedPlaneInfo selectedPlaneInfo_ = Planes[SelectedPlane];
			selectedPlaneInfo_.pntPlane.X = (double)numericUpDown_1.Value;
			selectedPlaneInfo_.pntPlane.Y = (double)numericUpDown_2.Value;
			selectedPlaneInfo_.pntPlane.Z = (double)numericUpDown_3.Value;
			selectedPlaneInfo_.Angle = (double)numericUpDown_0.Value;
			ProfilePlaneDef profilePlaneDef_ = selectedPlaneInfo_.PlaneType;
			int index = selectedPlaneInfo_.Index;
			Class186.smethod_354(false, index, this, ref selectedPlaneInfo_, profilePlaneDef_);
			Class186.smethod_591(SelectedPlane, true, this);
			Class186.smethod_96(true, selectedPlaneInfo_, this);
			PropertiesForm.Inited = true;
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
