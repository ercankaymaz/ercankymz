using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Plane;

public class F_PlaneSelection : Form
{
	public ProfilePlaneData Plane = new ProfilePlaneData();

	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal Panel panel_0;

	internal PictureBox pictureBox_0;

	internal Label label_0;

	public NumericUpDown spn_planeegillen;

	public Button btn_planeegiksettings;

	public Button btn_planeegik;

	public Button btn_planeleft;

	public Button btn_planeright;

	public Button btn_planebottom;

	internal Label label_1;

	public Button btn_planetop;

	public Button btn_cancel;

	public Button btn_ok;

	public F_PlaneSelection()
	{
		Class76.smethod_426(this);
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
		btn_planebottom.BackColor = Color.LightGray;
		btn_planetop.BackColor = Color.LightGray;
		btn_planeright.BackColor = Color.LightGray;
		btn_planeleft.BackColor = Color.LightGray;
		btn_planeegik.BackColor = Color.LightGray;
		if (Plane.PlaneSelectedName == planeNames.Top)
		{
			btn_planetop.BackColor = Color.Gold;
		}
		if (Plane.PlaneSelectedName == planeNames.Bottom)
		{
			btn_planebottom.BackColor = Color.Gold;
		}
		if (Plane.PlaneSelectedName == planeNames.Left)
		{
			btn_planeleft.BackColor = Color.Gold;
		}
		if (Plane.PlaneSelectedName == planeNames.Right)
		{
			btn_planeright.BackColor = Color.Gold;
		}
		if (Plane.PlaneSelectedName == planeNames.Free)
		{
			btn_planeegik.BackColor = Color.Gold;
		}
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

	internal void method_0(object sender, FormClosingEventArgs e)
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

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		btn_planebottom.BackColor = Color.LightGray;
		btn_planetop.BackColor = Color.LightGray;
		btn_planeright.BackColor = Color.LightGray;
		btn_planeleft.BackColor = Color.LightGray;
		btn_planeegik.BackColor = Color.LightGray;
		if (control.Name == btn_planetop.Name)
		{
			btn_planebottom.BackColor = Color.LightGray;
			btn_planetop.BackColor = Color.LightGray;
			btn_planeright.BackColor = Color.LightGray;
			btn_planeleft.BackColor = Color.LightGray;
			btn_planeegik.BackColor = Color.LightGray;
			Plane.PlaneSelectedName = planeNames.Top;
			btn_planetop.BackColor = Color.Gold;
		}
		if (control.Name == btn_planebottom.Name)
		{
			btn_planebottom.BackColor = Color.LightGray;
			btn_planetop.BackColor = Color.LightGray;
			btn_planeright.BackColor = Color.LightGray;
			btn_planeleft.BackColor = Color.LightGray;
			btn_planeegik.BackColor = Color.LightGray;
			Plane.PlaneSelectedName = planeNames.Top;
			btn_planebottom.BackColor = Color.Gold;
		}
		if (control.Name == btn_planeleft.Name)
		{
			btn_planebottom.BackColor = Color.LightGray;
			btn_planetop.BackColor = Color.LightGray;
			btn_planeright.BackColor = Color.LightGray;
			btn_planeleft.BackColor = Color.LightGray;
			btn_planeegik.BackColor = Color.LightGray;
			Plane.PlaneSelectedName = planeNames.Top;
			btn_planeleft.BackColor = Color.Gold;
		}
		if (control.Name == btn_planeright.Name)
		{
			btn_planebottom.BackColor = Color.LightGray;
			btn_planetop.BackColor = Color.LightGray;
			btn_planeright.BackColor = Color.LightGray;
			btn_planeleft.BackColor = Color.LightGray;
			btn_planeegik.BackColor = Color.LightGray;
			Plane.PlaneSelectedName = planeNames.Top;
			btn_planeright.BackColor = Color.Gold;
		}
		if (control.Name == btn_planeegik.Name)
		{
			btn_planebottom.BackColor = Color.LightGray;
			btn_planetop.BackColor = Color.LightGray;
			btn_planeright.BackColor = Color.LightGray;
			btn_planeleft.BackColor = Color.LightGray;
			btn_planeegik.BackColor = Color.LightGray;
			Plane.PlaneSelectedName = planeNames.Top;
			btn_planeegik.BackColor = Color.Gold;
		}
		if (control.Name == btn_planeegik.Name)
		{
			btn_planebottom.BackColor = Color.LightGray;
			btn_planetop.BackColor = Color.LightGray;
			btn_planeright.BackColor = Color.LightGray;
			btn_planeleft.BackColor = Color.LightGray;
			btn_planeegik.BackColor = Color.LightGray;
			Plane.PlaneSelectedName = planeNames.Top;
			btn_planeegik.BackColor = Color.Gold;
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
			Class76.smethod_611(this);
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
