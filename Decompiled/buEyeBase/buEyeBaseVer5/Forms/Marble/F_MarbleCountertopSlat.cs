using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCountertopSlat : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public marbleSlatPars Slat = new marbleSlatPars();

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public Panel pnl_base;

	public buSpin spn_slatstartangle;

	public buButton btn_okVer;

	public buSpin spn_topchamferstartheight;

	public buSpin spn_topchamferstartangle;

	public buSpin spn_slatwidth;

	public buButton btn_cancel;

	public buCheckBox chk_topchamferstartenable;

	public buCheckBox chk_slatenable;

	public buSpin spn_slatendangle;

	public buCheckBox chk_topchamferendenable;

	public buSpin spn_topchamferendheight;

	public buSpin spn_topchamferendangle;

	public buCheckBox chk_Socket1;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	public buSpin spn_socketxdistance1;

	public buSpin spn_socketydistance1;

	public buSpin spn_socketwidth1;

	public buSpin spn_socketheight1;

	public buCheckBox chk_socket2;

	public buSpin spn_socketxdistance2;

	public buSpin spn_socketydistance2;

	public buSpin spn_socketwidth2;

	public buSpin spn_socketheight2;

	internal PictureBox pictureBox_2;

	internal PictureBox pictureBox_3;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal Panel panel_1;

	public F_MarbleCountertopSlat()
	{
		Class186.smethod_589(this);
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
		chk_slatenable.Check = Slat.DataSlat.Enable;
		chk_topchamferendenable.Check = Slat.EndChamfer.DataChamfer.TopEnable;
		chk_topchamferstartenable.Check = Slat.StartChamfer.DataChamfer.TopEnable;
		spn_slatstartangle.Value = Slat.DataSlat.StartAngle;
		spn_slatendangle.Value = Slat.DataSlat.EndAngle;
		spn_slatwidth.Value = Slat.DataSlat.Width;
		spn_topchamferstartheight.Value = Slat.StartChamfer.DataChamfer.TopHeight;
		spn_topchamferstartangle.Value = Slat.StartChamfer.DataChamfer.TopAngle;
		spn_topchamferendheight.Value = Slat.EndChamfer.DataChamfer.TopHeight;
		spn_topchamferendangle.Value = Slat.EndChamfer.DataChamfer.TopAngle;
		spn_socketxdistance1.Value = Slat.Socket1.DataInside.PositionX;
		spn_socketydistance1.Value = Slat.Socket1.DataInside.PositionY;
		spn_socketwidth1.Value = Slat.Socket1.DataInside.InsideWidth;
		spn_socketheight1.Value = Slat.Socket1.DataInside.InsideHeight;
		chk_Socket1.Check = Slat.Socket1.DataInside.Enable;
		if (Slat.Socket1.DataInside.InsideType != MarbleCountertopInsideTypes.Rectangle)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
		}
		else
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
		}
		spn_socketxdistance2.Value = Slat.Socket2.DataInside.PositionX;
		spn_socketydistance2.Value = Slat.Socket2.DataInside.PositionY;
		spn_socketwidth2.Value = Slat.Socket2.DataInside.InsideWidth;
		spn_socketheight2.Value = Slat.Socket2.DataInside.InsideHeight;
		chk_socket2.Check = Slat.Socket2.DataInside.Enable;
		if (Slat.Socket2.DataInside.InsideType != MarbleCountertopInsideTypes.Rectangle)
		{
			radioButton_3.Checked = false;
			radioButton_2.Checked = true;
		}
		else
		{
			radioButton_3.Checked = true;
			radioButton_2.Checked = false;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_279(this);
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
		Slat.DataSlat.Enable = chk_slatenable.Check;
		Slat.EndChamfer.DataChamfer.TopEnable = chk_topchamferendenable.Check;
		Slat.StartChamfer.DataChamfer.TopEnable = chk_topchamferstartenable.Check;
		Slat.DataSlat.StartAngle = spn_slatstartangle.Value;
		Slat.DataSlat.EndAngle = spn_slatendangle.Value;
		Slat.DataSlat.Width = spn_slatwidth.Value;
		Slat.StartChamfer.DataChamfer.TopHeight = spn_topchamferstartheight.Value;
		Slat.StartChamfer.DataChamfer.TopAngle = spn_topchamferstartangle.Value;
		Slat.EndChamfer.DataChamfer.TopHeight = spn_topchamferendheight.Value;
		Slat.EndChamfer.DataChamfer.TopAngle = spn_topchamferendangle.Value;
		Slat.Socket1.DataInside.PositionX = spn_socketxdistance1.Value;
		Slat.Socket1.DataInside.PositionY = spn_socketydistance1.Value;
		Slat.Socket1.DataInside.InsideWidth = spn_socketwidth1.Value;
		Slat.Socket1.DataInside.InsideHeight = spn_socketheight1.Value;
		Slat.Socket1.DataInside.Enable = chk_Socket1.Check;
		Slat.Socket2.DataInside.PositionX = spn_socketxdistance2.Value;
		Slat.Socket2.DataInside.PositionY = spn_socketydistance2.Value;
		Slat.Socket2.DataInside.InsideWidth = spn_socketwidth2.Value;
		Slat.Socket2.DataInside.InsideHeight = spn_socketheight2.Value;
		Slat.Socket2.DataInside.Enable = chk_socket2.Check;
		if (!radioButton_0.Checked)
		{
			Slat.Socket1.DataInside.InsideType = MarbleCountertopInsideTypes.Circular;
		}
		else
		{
			Slat.Socket1.DataInside.InsideType = MarbleCountertopInsideTypes.Rectangle;
		}
		if (!radioButton_3.Checked)
		{
			Slat.Socket2.DataInside.InsideType = MarbleCountertopInsideTypes.Circular;
		}
		else
		{
			Slat.Socket2.DataInside.InsideType = MarbleCountertopInsideTypes.Rectangle;
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
				Apply();
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

	internal void method_2(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			buSpin buSpin2 = sender as buSpin;
			buSpin2.Display.BackColor = buEyeVars.parVisual.colorDataFocus;
			buSpin2.SelectAll();
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
			f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
			if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
			{
				buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
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
