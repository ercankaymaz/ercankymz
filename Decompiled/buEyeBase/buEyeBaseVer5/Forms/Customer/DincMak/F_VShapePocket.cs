using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Customer.DincMak;

public class F_VShapePocket : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public new double Width = 0.0;

	public double StartHeight = 0.0;

	public double EndHeight = 0.0;

	public double Depth = 0.0;

	public double XPos = 0.0;

	public double ZOffset = 0.0;

	public double XOffset = 0.0;

	public double SafeDis = 0.0;

	public double RapidDis = 0.0;

	public double PlungeFeed = 0.0;

	public double CuttingFeed = 0.0;

	public LeftMiddleRightLocationType OpLocation = LeftMiddleRightLocationType.Middle;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buCheckBox chk_vmiddle;

	public buCheckBox chk_vright;

	public buCheckBox chk_vleft;

	public buSpin spn_vcleaningendheight;

	public buSpin spn_vcleaningdepth;

	public buSpin spn_vcleaningstartheight;

	public buSpin spn_vcleaningwidth;

	public buSpin spn_xpos;

	public buSpin spn_ZOffset;

	internal buGroup buGroup_0;

	public buSpin spn_cuttingfeed;

	public buSpin spn_rapiddis;

	public buSpin spn_plungefeed;

	public buSpin spn_safedis;

	public buSpin spn_xoffset;

	public F_VShapePocket()
	{
		Class186.smethod_156(this);
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
			Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		spn_safedis.Value = SafeDis;
		spn_rapiddis.Value = RapidDis;
		spn_plungefeed.Value = PlungeFeed;
		spn_cuttingfeed.Value = CuttingFeed;
		spn_vcleaningdepth.Value = Depth;
		spn_vcleaningendheight.Value = EndHeight;
		spn_vcleaningstartheight.Value = StartHeight;
		spn_vcleaningwidth.Value = Width;
		spn_xpos.Value = XPos;
		spn_ZOffset.Value = ZOffset;
		spn_xoffset.Value = XOffset;
		chk_vleft.Check = false;
		chk_vmiddle.Check = false;
		chk_vright.Check = false;
		if (OpLocation == LeftMiddleRightLocationType.Left)
		{
			chk_vleft.Check = true;
		}
		if (OpLocation == LeftMiddleRightLocationType.Right)
		{
			chk_vright.Check = true;
		}
		if (OpLocation == LeftMiddleRightLocationType.Middle)
		{
			chk_vmiddle.Check = true;
		}
		Class186.smethod_229(this);
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
				Class186.smethod_519(this);
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
			chk_vleft.Check = false;
			chk_vmiddle.Check = false;
			chk_vright.Check = false;
			if (buCheckBox2.Name == chk_vleft.Name)
			{
				chk_vleft.Check = true;
			}
			if (buCheckBox2.Name == chk_vmiddle.Name)
			{
				chk_vmiddle.Check = true;
			}
			if (buCheckBox2.Name == chk_vright.Name)
			{
				chk_vright.Check = true;
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
