using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.Tufting;

public class F_TuftMachineSettings : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	public buGround buGround1;

	public buButton btn_closecross;

	public buButton btn_close;

	public buButton buButton10;

	public buButton btn_ok;

	public buButton btn_xabsoluteset;

	public buButton btn_yabsoluteset;

	public buSpin spn_HService;

	public buSpin spn_HUp;

	public buSpin spn_HDown;

	public buSpin spn_homeROffset;

	public buSpin spn_homeTOffset;

	public buLabel lbl_hHome;

	public buLabel lbl_rhome;

	public buLabel lbl_thome;

	public buGroup grp_xhome;

	public buGroup grp_hhome;

	public buGroup grp_rhome;

	public buGroup grp_thome;

	public buGroup grp_yhome;

	public F_TuftMachineSettings()
	{
		Class76.smethod_176(this);
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
		Class76.smethod_413(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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

	internal void method_1(object sender, EventArgs e)
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

	internal void method_2(object sender, EventArgs e)
	{
		PropertiesForm.Result = DialogResult.OK;
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
		f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
		f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
		f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
		if (buNumeric.IsNumeric(f_KeyPadNumV.Value))
		{
			buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
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
