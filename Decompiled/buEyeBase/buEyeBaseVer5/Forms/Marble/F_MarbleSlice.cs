using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSlice : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties Properties = new FormProperties();

	private IContainer icontainer_0 = null;

	public buSpin spn_itemEA;

	public buSpin spn_itemSA;

	public buSpin spn_itemcount;

	public buSpin spn_itemwidth;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buLabel lbl_length;

	public buLabel lbl_ea;

	public buLabel lbl_sa;

	public buLabel lbl_count;

	public Panel pnl_base;

	public Panel pnl_data;

	public buSpin spn_itemlength;

	public buButton btn_cancel;

	public buCheckBox chk_vertical;

	public buCheckBox chk_horizontal;

	public Panel pnl_viewport;

	public F_MarbleSlice()
	{
		Class186.smethod_165(this);
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
		lbl_count.Text = buLangTranslate.preDef.Count;
		lbl_ea.Text = buLangTranslate.preDef.EndAngle;
		lbl_length.Text = buLangTranslate.preDef.Length;
		lbl_sa.Text = buLangTranslate.preDef.StartAngle;
		btn_cancel.Text = buLangTranslate.preDef.Open;
		btn_ok.Text = buLangTranslate.preDef.Ok;
		chk_horizontal.Text = buLangTranslate.preDef.Horizontal;
		chk_vertical.Text = buLangTranslate.preDef.Vertical;
		Text = buLangTranslate.preDef.Slice;
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
			Control control = sender as Control;
			if (control.Name == btn_ok.Name)
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
