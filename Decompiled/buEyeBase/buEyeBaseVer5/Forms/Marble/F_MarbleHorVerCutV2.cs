using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHorVerCutV2 : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties Properties = new FormProperties();

	public bool isHorizontal = false;

	public bool isDialog = false;

	internal IContainer icontainer_0 = null;

	public buSpin spn_itemlength;

	public buSpin spn_itemEA5;

	public buSpin spn_itemSA5;

	public buSpin spn_itemcount5;

	public buSpin spn_itemlen5;

	public buSpin spn_itemEA4;

	public buSpin spn_itemSA4;

	public buSpin spn_itemcount4;

	public buSpin spn_itemlen4;

	public buSpin spn_itemEA3;

	public buSpin spn_itemSA3;

	public buSpin spn_itemcount3;

	public buSpin spn_itemlen3;

	public buSpin spn_itemEA2;

	public buSpin spn_itemSA2;

	public buSpin spn_itemcount2;

	public buSpin spn_itemlen2;

	public buSpin spn_itemEA1;

	public buSpin spn_itemSA1;

	public buSpin spn_itemcount1;

	public buSpin spn_itemlen1;

	public buButton btn_minimise;

	public buButton btn_maximize;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_open;

	public buButton btn_itemdown;

	public buButton btn_itemup;

	public buButton btn_itemok;

	public buButton btn_cancel;

	public buLabel lbl_length;

	public buLabel lbl_5;

	public buLabel lbl_4;

	public buLabel lbl_3;

	public buLabel lbl_2;

	public buLabel lbl_1;

	public buLabel lbl_ea;

	public buLabel lbl_sa;

	public buLabel lbl_count;

	public buLabel lbl_7;

	public buSpin spn_itemEA7;

	public buSpin spn_itemSA7;

	public buSpin spn_itemcount7;

	public buSpin spn_itemlen7;

	public buLabel lbl_6;

	public buSpin spn_itemEA6;

	public buSpin spn_itemSA6;

	public buSpin spn_itemcount6;

	public buSpin spn_itemlen6;

	public Panel pnl_base;

	public buButton btn_itemclearall;

	public buSpin spn_angle;

	public buButton btn_save;

	internal buLabel buLabel_0;

	public TextBox txt_info;

	public Panel pnl_data;

	public buSpin spn_xoffset;

	public buSpin spn_yoffset;

	public buButton btn_itemstartpos;

	public buButton btn_itemendpos;

	public buButton btn_addtolist;

	public buCheckBox chk_horlefttop;

	public buCheckBox chk_horleftbottom;

	public Panel pnl_viewport;

	public buCheckBox chk_cutend;

	public buCheckBox chk_cutstart;

	public ImageList IC32;

	public buLabel lbl_EAimg1;

	public buLabel lbl_EAimg7;

	public buLabel lbl_SAimg7;

	public buLabel lbl_EAimg6;

	public buLabel lbl_SAimg6;

	public buLabel lbl_EAimg5;

	public buLabel lbl_SAimg5;

	public buLabel lbl_EAimg4;

	public buLabel lbl_SAimg4;

	public buLabel lbl_EAimg3;

	public buLabel lbl_SAimg3;

	public buLabel lbl_EAimg2;

	public buLabel lbl_SAimg2;

	public buLabel lbl_SAimg1;

	public buCheckBox chk_reversecutdir;

	public F_MarbleHorVerCutV2()
	{
		Class186.smethod_474(this);
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
		buLabel_0.Text = buLangTranslate.preDef.Information;
		lbl_length.Text = buLangTranslate.preDef.Width;
		lbl_sa.Text = buLangTranslate.preDef.StartAngle;
		btn_addtolist.Text = buLangTranslate.preDef.AddToList;
		btn_cancel.Text = buLangTranslate.preDef.Cancel;
		btn_itemendpos.Text = buLangTranslate.preDef.EndPoint;
		btn_itemok.Text = buLangTranslate.preDef.Ok;
		btn_itemstartpos.Text = buLangTranslate.preDef.StartPoint;
		btn_open.Text = buLangTranslate.preDef.Open;
		btn_save.Text = buLangTranslate.preDef.Save;
		spn_angle.Caption.Caption = buLangTranslate.preDef.Angle;
		spn_itemlength.Caption.Caption = buLangTranslate.preDef.Length;
		spn_xoffset.Caption.Caption = buLangTranslate.preChar.X + " " + buLangTranslate.preDef.Offset;
		spn_yoffset.Caption.Caption = buLangTranslate.preChar.Y + " " + buLangTranslate.preDef.Offset;
		chk_cutend.Text = buLangTranslate.preDef.End + " " + buLangTranslate.preDef.Cutting;
		chk_cutstart.Text = buLangTranslate.preDef.Start + " " + buLangTranslate.preDef.Cutting;
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
			if (control.Name == btn_itemok.Name)
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
