using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSingleCutV2 : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties Properties = new FormProperties();

	public bool isHorizontal = false;

	public bool isDialog = false;

	private IContainer icontainer_0 = null;

	public buButton btn_minimise;

	public buButton btn_maximize;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_cancel;

	public Panel pnl_base;

	public Panel pnl_data;

	public buButton btn_itemsinglecutok;

	public buSpin spn_signlecutAAngle;

	public buSpin spn_signlecutlength;

	public buSpin spn_signlecutCAngle;

	public F_MarbleSingleCutV2()
	{
		Class186.smethod_325(this);
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
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLanguage();
	}

	public void LoadLanguage()
	{
		btn_cancel.Text = buLangTranslate.preDef.Cancel;
		btn_itemsinglecutok.Text = buLangTranslate.preDef.Ok;
		spn_signlecutAAngle.Caption.Caption = "A " + buLangTranslate.preDef.Angle;
		spn_signlecutCAngle.Caption.Caption = "C " + buLangTranslate.preDef.Angle;
		spn_signlecutlength.Caption.Caption = buLangTranslate.preDef.Length;
		Text = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Cutting;
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
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (!isDialog)
			{
				return;
			}
			if (control.Name == btn_itemsinglecutok.Name)
			{
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
			if (control.Name == btn_close.Name)
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
			if (control.Name == btn_maximize.Name)
			{
				base.WindowState = FormWindowState.Maximized;
			}
			if (control.Name == btn_minimise.Name)
			{
				base.WindowState = FormWindowState.Normal;
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
