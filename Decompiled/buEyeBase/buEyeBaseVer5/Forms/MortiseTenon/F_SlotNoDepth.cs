using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.MortiseTenon;

public class F_SlotNoDepth : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public new double Width = 0.0;

	public double Diameter = 0.0;

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

	public buSpin spn_slotheight;

	public buSpin spn_slotwidth;

	public buSpin spn_ZPos;

	public buSpin spn_XPos;

	internal buGroup buGroup_0;

	public buSpin spn_cuttingfeed;

	public buSpin spn_rapiddis;

	public buSpin spn_plungefeed;

	public buSpin spn_safedis;

	public F_SlotNoDepth()
	{
		Class186.smethod_539(this);
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
		spn_slotheight.Value = Diameter;
		spn_slotwidth.Value = Width;
		spn_XPos.Value = XPos;
		spn_ZPos.Value = YPos;
		Class186.smethod_413(this);
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
				Class186.smethod_404(this);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
