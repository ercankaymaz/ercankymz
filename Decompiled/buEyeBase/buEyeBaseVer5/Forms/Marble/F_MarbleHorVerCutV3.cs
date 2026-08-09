using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHorVerCutV3 : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties Properties = new FormProperties();

	public bool isDialog = false;

	internal IContainer icontainer_0 = null;

	public buSpin spn_itemhorlength;

	public buSpin spn_itemhorEA5;

	public buSpin spn_itemhorSA5;

	public buSpin spn_itemhorcount5;

	public buSpin spn_itemhorlen5;

	public buSpin spn_itemhorEA4;

	public buSpin spn_itemhorSA4;

	public buSpin spn_itemhorcount4;

	public buSpin spn_itemhorlen4;

	public buSpin spn_itemhorEA3;

	public buSpin spn_itemhorSA3;

	public buSpin spn_itemhorcount3;

	public buSpin spn_itemhorlen3;

	public buSpin spn_itemhorEA2;

	public buSpin spn_itemhorSA2;

	public buSpin spn_itemhorcount2;

	public buSpin spn_itemhorlen2;

	public buSpin spn_itemhorEA1;

	public buSpin spn_itemhorSA1;

	public buSpin spn_itemhorcount1;

	public buSpin spn_itemhorlen1;

	public buButton buButton1;

	public buButton btn_maximize;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_horveropen;

	public buButton btn_itemhordown;

	public buButton btn_itemhorup;

	public buButton btn_itemhorverok;

	public buButton btn_cancel;

	public buLabel lbl_lengthhor;

	public buLabel lbl_hor5;

	public buLabel lbl_hor4;

	public buLabel lbl_hor3;

	public buLabel lbl_hor2;

	public buLabel lbl_hor1;

	public buLabel lbl_eahor;

	public buLabel lbl_sahor;

	public buLabel lbl_counthor;

	public buLabel lbl_hor7;

	public buSpin spn_itemhorEA7;

	public buSpin spn_itemhorSA7;

	public buSpin spn_itemhorcount7;

	public buSpin spn_itemhorlen7;

	public buLabel lbl_hor6;

	public buSpin spn_itemhorEA6;

	public buSpin spn_itemhorSA6;

	public buSpin spn_itemhorcount6;

	public buSpin spn_itemhorlen6;

	public Panel pnl_base;

	public buButton btn_itemhorclearall;

	public buSpin spn_horverangle;

	public buButton btn_horversave;

	internal buLabel buLabel_0;

	public TextBox txt_info;

	public Panel pnl_data;

	public buSpin spn_horverxoffset;

	public buSpin spn_horveryoffset;

	public buButton btn_itemhorverstartpos;

	public buButton btn_itemhorverendpos;

	public buButton btn_addtolist;

	public buLabel lbl_lengthver;

	public buSpin spn_itemverlen4;

	public buSpin spn_itemverEA3;

	public buSpin spn_itemvercount4;

	public buButton btn_itemverclearall;

	public buSpin spn_itemverSA3;

	public buSpin spn_itemverSA4;

	public buSpin spn_itemvercount3;

	public buLabel lbl_ver7;

	public buSpin spn_itemverEA4;

	public buSpin spn_itemverEA7;

	public buSpin spn_itemverlen3;

	public buSpin spn_itemverSA7;

	public buSpin spn_itemverlen5;

	public buSpin spn_itemvercount7;

	public buSpin spn_itemverEA2;

	public buSpin spn_itemverlen7;

	public buSpin spn_itemvercount5;

	public buLabel lbl_ver6;

	public buSpin spn_itemverSA2;

	public buSpin spn_itemverEA6;

	public buSpin spn_itemverSA5;

	public buSpin spn_itemverSA6;

	public buSpin spn_itemvercount2;

	public buSpin spn_itemvercount6;

	public buSpin spn_itemverEA5;

	public buSpin spn_itemverlen6;

	public buSpin spn_itemverlen2;

	public buLabel lbl_ver5;

	public buLabel lbl_ver4;

	public buButton btn_itemverup;

	public buLabel lbl_ver3;

	public buButton btn_itemverdown;

	public buLabel lbl_ver2;

	public buLabel lbl_ver1;

	public buLabel lbl_eaver;

	public buSpin spn_itemverEA1;

	public buLabel lbl_saver;

	public buSpin spn_itemverlen1;

	public buSpin spn_itemverSA1;

	public buSpin spn_itemvercount1;

	public buLabel lbl_countver;

	public buSpin spn_itemverlength;

	public TabPage tabPage_Hor;

	public TabPage tabPage_Ver;

	public buCheckBox chk_horverleftbottom;

	public buCheckBox chk_horverlefttop;

	public buTab buTab1;

	public Panel pnl_viewport;

	public buLabel lbl_EAimgHor7;

	public ImageList IC32;

	public buLabel lbl_SAimgHor7;

	public buLabel lbl_EAimgHor6;

	public buLabel lbl_SAimgHor6;

	public buLabel lbl_EAimgHor5;

	public buLabel lbl_SAimgHor5;

	public buLabel lbl_EAimgHor4;

	public buLabel lbl_SAimgHor4;

	public buLabel lbl_EAimgHor3;

	public buLabel lbl_SAimgHor3;

	public buLabel lbl_EAimgHor2;

	public buLabel lbl_SAimgHor2;

	public buLabel lbl_EAimgHor1;

	public buLabel lbl_SAimgHor1;

	public buLabel lbl_EAimgVer7;

	public buLabel lbl_EAimgVer6;

	public buLabel lbl_SAimgVer7;

	public buLabel lbl_EAimgVer5;

	public buLabel lbl_EAimgVer4;

	public buLabel lbl_EAimgVer3;

	public buLabel lbl_SAimgVer6;

	public buLabel lbl_EAimgVer2;

	public buLabel lbl_EAimgVer1;

	public buLabel lbl_SAimgVer5;

	public buLabel lbl_SAimgVer4;

	public buLabel lbl_SAimgVer3;

	public buLabel lbl_SAimgVer2;

	public buLabel lbl_SAimgVer1;

	public buCheckBox chk_verticalfirst;

	public F_MarbleHorVerCutV3()
	{
		Class186.smethod_416(this);
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
		lbl_countver.Text = buLangTranslate.preDef.Count;
		lbl_eaver.Text = buLangTranslate.preDef.EndAngle;
		lbl_lengthver.Text = buLangTranslate.preDef.Width;
		lbl_saver.Text = buLangTranslate.preDef.StartAngle;
		lbl_counthor.Text = buLangTranslate.preDef.Count;
		lbl_eahor.Text = buLangTranslate.preDef.EndAngle;
		lbl_lengthhor.Text = buLangTranslate.preDef.Width;
		lbl_sahor.Text = buLangTranslate.preDef.StartAngle;
		buLabel_0.Text = buLangTranslate.preDef.Information;
		btn_addtolist.Text = buLangTranslate.preDef.AddToList;
		btn_cancel.Text = buLangTranslate.preDef.Cancel;
		btn_itemhorverendpos.Text = buLangTranslate.preDef.EndPoint;
		btn_itemhorverok.Text = buLangTranslate.preDef.Ok;
		btn_itemhorverstartpos.Text = buLangTranslate.preDef.StartPoint;
		btn_horveropen.Text = buLangTranslate.preDef.Open;
		btn_horversave.Text = buLangTranslate.preDef.Save;
		spn_itemhorlength.Caption.Caption = buLangTranslate.preDef.Length;
		spn_itemverlength.Caption.Caption = buLangTranslate.preDef.Length;
		spn_horverangle.Caption.Caption = buLangTranslate.preDef.Angle;
		spn_horverxoffset.Caption.Caption = buLangTranslate.preChar.X + " " + buLangTranslate.preDef.Offset;
		spn_horveryoffset.Caption.Caption = buLangTranslate.preChar.Y + " " + buLangTranslate.preDef.Offset;
		tabPage_Hor.Text = buLangTranslate.preDef.Horizontal;
		tabPage_Ver.Text = buLangTranslate.preDef.Vertical;
		Text = buLangTranslate.preDef.Horizontal + " - " + buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Cutting;
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
			if (control.Name == btn_itemhorverok.Name)
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
