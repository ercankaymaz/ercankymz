using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Customer.DincMak;

public class F_RectangleShape : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public double OPWidth = 0.0;

	public double OPHeight = 0.0;

	public double Depth = 0.0;

	public double Radius = 0.0;

	public double XPos = 0.0;

	public double YPos = 0.0;

	public double SafeDis = 0.0;

	public double RapidDis = 0.0;

	public double PlungeFeed = 0.0;

	public double CuttingFeed = 0.0;

	public CamClosedContourType CamType = CamClosedContourType.Outter;

	public int ToolNo = 1;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	public buSpin spn_slotdepth;

	public buSpin spn_slotheight;

	public buSpin spn_slotwidth;

	public buSpin spn_ZPos;

	public buSpin spn_XPos;

	public buCheckBox chk_contourcenter;

	public buCheckBox chk_contourinside;

	public buCheckBox chk_tool3;

	public buCheckBox chk_contouroutside;

	public buCheckBox chk_tool2;

	public buCheckBox chk_tool1;

	public buSpin spn_slotradius;

	internal buGroup buGroup_0;

	public buSpin spn_cuttingfeed;

	public buSpin spn_rapiddis;

	public buSpin spn_plungefeed;

	public buSpin spn_safedis;

	public F_RectangleShape()
	{
		Class186.smethod_70(this);
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
		spn_slotdepth.Value = Depth;
		spn_slotheight.Value = OPHeight;
		spn_slotwidth.Value = OPWidth;
		spn_slotradius.Value = Radius;
		spn_XPos.Value = XPos;
		spn_ZPos.Value = YPos;
		chk_contourcenter.Check = false;
		chk_contourinside.Check = false;
		chk_contouroutside.Check = false;
		chk_tool1.Check = false;
		chk_tool2.Check = false;
		chk_tool3.Check = false;
		if (CamType == CamClosedContourType.Outter)
		{
			chk_contouroutside.Check = true;
		}
		if (CamType == CamClosedContourType.Inner)
		{
			chk_contourinside.Check = true;
		}
		if (CamType == CamClosedContourType.Center)
		{
			chk_contourcenter.Check = true;
		}
		if ((ToolNo == 0) | (ToolNo == 1))
		{
			chk_tool1.Check = true;
		}
		if (ToolNo == 2)
		{
			chk_tool2.Check = true;
		}
		if (ToolNo == 3)
		{
			chk_tool3.Check = true;
		}
		Class186.smethod_275(this);
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
				Class186.smethod_250(this);
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

	internal void method_2(object sender, EventArgs e)
	{
		if (!Properties.Inited)
		{
			return;
		}
		buCheckBox buCheckBox2 = sender as buCheckBox;
		if ((buCheckBox2.Name == chk_contourcenter.Name) | (buCheckBox2.Name == chk_contourinside.Name) | (buCheckBox2.Name == chk_contouroutside.Name))
		{
			chk_contourcenter.Check = false;
			chk_contourinside.Check = false;
			chk_contouroutside.Check = false;
			if (buCheckBox2.Name == chk_contourcenter.Name)
			{
				chk_contourcenter.Check = true;
			}
			if (buCheckBox2.Name == chk_contourinside.Name)
			{
				chk_contourinside.Check = true;
			}
			if (buCheckBox2.Name == chk_contouroutside.Name)
			{
				chk_contouroutside.Check = true;
			}
		}
		if ((buCheckBox2.Name == chk_tool1.Name) | (buCheckBox2.Name == chk_tool2.Name) | (buCheckBox2.Name == chk_tool3.Name))
		{
			chk_tool1.Check = false;
			chk_tool2.Check = false;
			chk_tool3.Check = false;
			if (buCheckBox2.Name == chk_tool1.Name)
			{
				chk_tool1.Check = true;
			}
			if (buCheckBox2.Name == chk_tool2.Name)
			{
				chk_tool2.Check = true;
			}
			if (buCheckBox2.Name == chk_tool3.Name)
			{
				chk_tool3.Check = true;
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
