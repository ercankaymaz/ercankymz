using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Plane;

public class F_SetCadCamPlane : Form
{
	public WorkPlane Plane = new WorkPlane();

	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	public Button btn_planefreesettings;

	public Button btn_planefree;

	public Button btn_planezy;

	public Button btn_planeyz;

	public Button btn_planeyx;

	public Button btn_planexy;

	public Button btn_planezx;

	public Button btn_planexz;

	internal Panel panel_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	public F_SetCadCamPlane()
	{
		Class76.smethod_94(this);
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
		btn_planeyx.BackColor = Color.Gainsboro;
		btn_planexy.BackColor = Color.Gainsboro;
		btn_planeyz.BackColor = Color.Gainsboro;
		btn_planezy.BackColor = Color.Gainsboro;
		btn_planexz.BackColor = Color.Gainsboro;
		btn_planezx.BackColor = Color.Gainsboro;
		btn_planefree.BackColor = Color.Gainsboro;
		if (Plane.PlaneName != planeNames.Top)
		{
			if (Plane.PlaneName != planeNames.Bottom)
			{
				if (Plane.PlaneName != planeNames.Front)
				{
					if (Plane.PlaneName != planeNames.Back)
					{
						if (Plane.PlaneName != planeNames.Left)
						{
							if (Plane.PlaneName != planeNames.Right)
							{
								btn_planefree.BackColor = Color.Gold;
							}
							else
							{
								btn_planezy.BackColor = Color.Gold;
							}
						}
						else
						{
							btn_planeyz.BackColor = Color.Gold;
						}
					}
					else
					{
						btn_planezx.BackColor = Color.Gold;
					}
				}
				else
				{
					btn_planexz.BackColor = Color.Gold;
				}
			}
			else
			{
				btn_planeyx.BackColor = Color.Gold;
			}
		}
		else
		{
			btn_planexy.BackColor = Color.Gold;
		}
		numericUpDown_2.Value = (decimal)Plane.Normalies.X;
		numericUpDown_1.Value = (decimal)Plane.Normalies.Y;
		numericUpDown_0.Value = (decimal)Plane.Normalies.Z;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
			if (Captions.Count >= 1)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		btn_planeyx.BackColor = Color.Gainsboro;
		btn_planexy.BackColor = Color.Gainsboro;
		btn_planeyz.BackColor = Color.Gainsboro;
		btn_planezy.BackColor = Color.Gainsboro;
		btn_planexz.BackColor = Color.Gainsboro;
		btn_planezx.BackColor = Color.Gainsboro;
		btn_planefree.BackColor = Color.Gainsboro;
		if (control.Name == btn_planexy.Name)
		{
			Plane.Normalies = new Vec3D(0.0, 0.0, 1.0);
			btn_planexy.BackColor = Color.Gold;
			Plane.PlaneName = planeNames.Top;
			Plane.PlaneType = planeType.XY;
		}
		if (control.Name == btn_planeyx.Name)
		{
			Plane.Normalies = new Vec3D(0.0, 0.0, -1.0);
			btn_planeyx.BackColor = Color.Gold;
			Plane.PlaneName = planeNames.Bottom;
			Plane.PlaneType = planeType.YZ;
		}
		if (control.Name == btn_planezy.Name)
		{
			Plane.Normalies = new Vec3D(-1.0, 0.0, 0.0);
			btn_planezy.BackColor = Color.Gold;
			Plane.PlaneName = planeNames.Right;
			Plane.PlaneType = planeType.ZY;
		}
		if (control.Name == btn_planeyz.Name)
		{
			Plane.Normalies = new Vec3D(1.0, 0.0, 0.0);
			btn_planeyz.BackColor = Color.Gold;
			Plane.PlaneName = planeNames.Left;
			Plane.PlaneType = planeType.YZ;
		}
		if (control.Name == btn_planezx.Name)
		{
			Plane.Normalies = new Vec3D(0.0, 1.0, 0.0);
			btn_planezx.BackColor = Color.Gold;
			Plane.PlaneName = planeNames.Back;
			Plane.PlaneType = planeType.ZX;
		}
		if (control.Name == btn_planexz.Name)
		{
			Plane.Normalies = new Vec3D(0.0, -1.0, 0.0);
			btn_planexz.BackColor = Color.Gold;
			Plane.PlaneName = planeNames.Front;
			Plane.PlaneType = planeType.XZ;
		}
		if (control.Name == btn_planefree.Name)
		{
			Plane.Normalies = new Vec3D((double)numericUpDown_2.Value, (double)numericUpDown_1.Value, (double)numericUpDown_0.Value);
			Plane.PlaneName = planeNames.Free;
			btn_planefree.BackColor = Color.Gold;
			Plane.PlaneType = planeType.Angle;
		}
		if (control.Name == btn_planefreesettings.Name)
		{
			if (!panel_0.Visible)
			{
				panel_0.Visible = true;
			}
			else
			{
				panel_0.Visible = false;
			}
		}
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
			Class76.smethod_844(this);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
