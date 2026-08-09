using System;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_PlaneList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public SelectedPlaneInfo Plane = new SelectedPlaneInfo();

	public Point3D pntMinProfile = new Point3D();

	public Point3D pntMaxProfile = new Point3D();

	public UCSObjectData VarUcs = new UCSObjectData();

	public double PlaneThinkness = 4.0;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	public F_PlaneList()
	{
		Class186.smethod_28(this);
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
		Class186.smethod_714(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == button_0.Name)
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
		if (control.Name == button_5.Name)
		{
			buCall.buProfileCalc_0.CreatePlane(ProfilePlaneDef.Top0, 0, Create: true, pntMinProfile, pntMaxProfile, PlaneThinkness, VarUcs, ref Plane);
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
		if (control.Name == button_4.Name)
		{
			new SelectedPlaneInfo();
			buCall.buProfileCalc_0.CreatePlane(ProfilePlaneDef.Back45, 0, Create: true, pntMinProfile, pntMaxProfile, PlaneThinkness, VarUcs, ref Plane);
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
		if (control.Name == button_3.Name)
		{
			buCall.buProfileCalc_0.CreatePlane(ProfilePlaneDef.Back90, 0, Create: true, pntMinProfile, pntMaxProfile, PlaneThinkness, VarUcs, ref Plane);
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
		if (control.Name == button_2.Name)
		{
			buCall.buProfileCalc_0.CreatePlane(ProfilePlaneDef.Front45, 0, Create: true, pntMinProfile, pntMaxProfile, PlaneThinkness, VarUcs, ref Plane);
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
			buCall.buProfileCalc_0.CreatePlane(ProfilePlaneDef.Front90, 0, Create: true, pntMinProfile, pntMaxProfile, PlaneThinkness, VarUcs, ref Plane);
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
	}

	internal void method_2(object sender, FormClosingEventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
