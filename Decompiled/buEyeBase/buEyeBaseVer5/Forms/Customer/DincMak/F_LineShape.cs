using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Customer.DincMak;

public class F_LineShape : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public double ZPos = 0.0;

	public double Depth = 0.0;

	public double X1Pos = 0.0;

	public double X2Pos = 0.0;

	public double SafeDis = 0.0;

	public double RapidDis = 0.0;

	public double PlungeFeed = 0.0;

	public double CuttingFeed = 0.0;

	public HorizontalDirectionType Dir = HorizontalDirectionType.LeftToRight;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buCheckBox chk_linerighttoleft;

	public buCheckBox chk_linelefttorigth;

	public buSpin spn_linedepth;

	public buSpin spn_zpos;

	public buSpin spn_x2Pos;

	public buSpin spn_x1pos;

	internal buGroup buGroup_0;

	public buSpin spn_cuttingfeed;

	public buSpin spn_rapiddis;

	public buSpin spn_plungefeed;

	public buSpin spn_safedis;

	public F_LineShape()
	{
		Class186.smethod_729(this);
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
		spn_safedis.Value = SafeDis;
		spn_rapiddis.Value = RapidDis;
		spn_plungefeed.Value = PlungeFeed;
		spn_cuttingfeed.Value = CuttingFeed;
		spn_linedepth.Value = Depth;
		spn_zpos.Value = ZPos;
		spn_x2Pos.Value = X2Pos;
		spn_x1pos.Value = X1Pos;
		chk_linelefttorigth.Check = false;
		chk_linerighttoleft.Check = false;
		if (Dir == HorizontalDirectionType.LeftToRight)
		{
			chk_linelefttorigth.Check = true;
		}
		if (Dir == HorizontalDirectionType.RigthToLeft)
		{
			chk_linerighttoleft.Check = true;
		}
		Class186.smethod_716(this);
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
			if (control.Name == btn_ok.Name)
			{
				Class186.smethod_344(this);
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
			if ((control.Name == btn_cancel.Name) | (control.Name == buButton_0.Name))
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

	internal void method_2(object object_0, bool bool_0)
	{
		if (!Properties.Inited)
		{
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (Properties.Inited)
		{
			buCheckBox buCheckBox2 = sender as buCheckBox;
			chk_linelefttorigth.Check = false;
			chk_linerighttoleft.Check = false;
			if (buCheckBox2.Name == chk_linelefttorigth.Name)
			{
				chk_linelefttorigth.Check = true;
			}
			if (buCheckBox2.Name == chk_linerighttoleft.Name)
			{
				chk_linerighttoleft.Check = true;
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
