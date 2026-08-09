using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Location;

public class F_ObjectLocation : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	internal Color color_0 = Color.LightBlue;

	internal Color color_1 = Color.Gainsboro;

	public ObjectAlignment Alingnment = ObjectAlignment.MiddleLeft;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_bottomright;

	public Button btn_middleright;

	public Button btn_topright;

	public Button btn_bottomleft;

	public Button btn_middleleft;

	public Button btn_topleft;

	public Button btn_bottomcenter;

	public Button btn_middlecenter;

	public Button btn_topcenter;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	public F_ObjectLocation()
	{
		Class186.smethod_114(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		Properties.Result = DialogResult.None;
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		base.AutoScaleMode = Properties.ScaleFromMode;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		Class186.smethod_527(this);
		Properties.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_topleft.Name)
		{
			Alingnment = ObjectAlignment.TopLeft;
			Class186.smethod_527(this);
			Properties.Result = DialogResult.OK;
		}
		if (control.Name == btn_topcenter.Name)
		{
			Alingnment = ObjectAlignment.TopCenter;
			Class186.smethod_527(this);
			Properties.Result = DialogResult.OK;
		}
		if (control.Name == btn_topright.Name)
		{
			Alingnment = ObjectAlignment.TopRight;
			Class186.smethod_527(this);
			Properties.Result = DialogResult.OK;
		}
		if (control.Name == btn_middleleft.Name)
		{
			Alingnment = ObjectAlignment.MiddleLeft;
			Class186.smethod_527(this);
			Properties.Result = DialogResult.OK;
		}
		if (control.Name == btn_middlecenter.Name)
		{
			Alingnment = ObjectAlignment.MiddleCenter;
			Class186.smethod_527(this);
			Properties.Result = DialogResult.OK;
		}
		if (control.Name == btn_middleright.Name)
		{
			Alingnment = ObjectAlignment.MiddleRight;
			Class186.smethod_527(this);
			Properties.Result = DialogResult.OK;
		}
		if (control.Name == btn_bottomleft.Name)
		{
			Alingnment = ObjectAlignment.BottomLeft;
			Class186.smethod_527(this);
			Properties.Result = DialogResult.OK;
		}
		if (control.Name == btn_bottomcenter.Name)
		{
			Alingnment = ObjectAlignment.BottomCenter;
			Class186.smethod_527(this);
			Properties.Result = DialogResult.OK;
		}
		if (control.Name == btn_bottomright.Name)
		{
			Alingnment = ObjectAlignment.BottomRight;
			Class186.smethod_527(this);
			Properties.Result = DialogResult.OK;
		}
		if (Properties.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
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
