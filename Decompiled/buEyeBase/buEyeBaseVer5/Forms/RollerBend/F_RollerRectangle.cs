using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.RollerBend;

public class F_RollerRectangle : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties Properties = new FormProperties();

	public new double Width = 1000.0;

	public new double Height = 800.0;

	public double Radius = 300.0;

	public double Length = 1000.0;

	public double Thickness = 5.0;

	public bool isHorizontal = false;

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public Panel pnl_base;

	public buSpin spn_radius;

	public buSpin spn_length;

	public buSpin spn_thickness;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buSpin spn_hegiht;

	public buSpin spn_width;

	public F_RollerRectangle()
	{
		Class186.smethod_131(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		spn_width.Value = Width;
		spn_hegiht.Value = Height;
		spn_radius.Value = Radius;
		spn_length.Value = Length;
		spn_thickness.Value = Thickness;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		Class186.smethod_484(this);
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

	public void Apply()
	{
		Width = spn_width.Value;
		Height = spn_hegiht.Value;
		Radius = spn_radius.Value;
		Length = spn_length.Value;
		Thickness = spn_thickness.Value;
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_ok.Name)
			{
				Apply();
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
			if ((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name))
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
		catch (Exception)
		{
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
