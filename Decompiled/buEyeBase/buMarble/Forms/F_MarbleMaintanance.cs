using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buMarble.Forms;

public class F_MarbleMaintanance : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_cancel;

	public buButton btn_clearX;

	internal ImageList imageList_0;

	internal buLabel buLabel_0;

	public buSpin spn_limitMAchineClean;

	public buSpin spn_actualMAchineClean;

	internal buLabel buLabel_1;

	public buButton btn_clearMachineClean;

	public buSpin spn_limitCabinet;

	public buSpin spn_actualCabinet;

	internal buLabel buLabel_2;

	public buButton btn_clearCabinet;

	public buSpin spn_limitLubricate;

	public buSpin spn_actualLuricate;

	internal buLabel buLabel_3;

	public buButton btn_clearLubricate;

	public buSpin spn_limitAir;

	public buSpin spn_actualAir;

	internal buLabel buLabel_4;

	public buButton btn_clearAir;

	public buSpin spn_limitHidro;

	public buSpin spn_actualHidro;

	internal buLabel buLabel_5;

	public buButton btn_clearHidro;

	public buSpin spn_limitC;

	public buSpin spn_actualC;

	internal buLabel buLabel_6;

	public buButton btn_clearC;

	public buSpin spn_limitA;

	public buSpin spn_actualA;

	internal buLabel buLabel_7;

	public buButton btn_clearA;

	public buSpin spn_limitZ;

	public buSpin spn_actualZ;

	internal buLabel buLabel_8;

	public buButton btn_clearZ;

	public buSpin spn_limitY;

	public buSpin spn_actualY;

	internal buLabel buLabel_9;

	public buButton btn_clearY;

	internal buLabel buLabel_10;

	internal buLabel buLabel_11;

	public buSpin spn_limitX;

	public buSpin spn_actualX;

	public F_MarbleMaintanance()
	{
		Class186.smethod_88(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_374(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void Apply()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if ((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name))
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
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
