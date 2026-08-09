using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHorVerCut : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties Properties = new FormProperties();

	public bool isHorizontal = false;

	private IContainer icontainer_0 = null;

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

	public buButton btn_minimize;

	public buButton btn_maximize;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_save;

	public buButton btn_open;

	public buButton btn_downVer;

	public buButton btn_upVer;

	public buButton btn_okVer;

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

	public Panel pnl_ver_viewport;

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

	public buButton btn_clearallVer;

	public buSpin spn_anglever;

	public buSpin spn_lengthVer;

	internal buLabel buLabel_0;

	public Panel pnl_data;

	public buSpin spn_y;

	public buSpin spn_x;

	public TextBox txt_info;

	public buCheckBox chk_showalldrawing;

	public F_MarbleHorVerCut()
	{
		Class186.smethod_193(this);
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
		Class186.smethod_167(this);
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
			if (control.Name == btn_okVer.Name)
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
			if (control.Name == btn_minimize.Name)
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
