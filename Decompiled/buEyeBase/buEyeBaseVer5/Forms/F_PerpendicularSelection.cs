using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_PerpendicularSelection : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public bool Vertical = false;

	public bool Horizontal = false;

	public bool Angle = false;

	public string strRemoveCaption = "Do You Want to Remove Item";

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	public F_PerpendicularSelection()
	{
		Class186.smethod_224(this);
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
		PropertiesForm.Result = DialogResult.None;
		Class186.smethod_175(this);
		checkBox_0.Checked = Horizontal;
		checkBox_1.Checked = Vertical;
		checkBox_2.Checked = Angle;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			Class186.smethod_79(this);
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
		if (control.Name == btn_cancel.Name)
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
	}

	internal void method_1(object sender, FormClosingEventArgs e)
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
