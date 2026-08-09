using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Events;

public class F_EventAll : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public ShapeAllData Data = new ShapeAllData();

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buTab buTab_shape;

	public TabPage tabPage_move;

	public TabPage tabPage_scale;

	internal PictureBox pictureBox_0;

	public buSpin spn_movey;

	public buSpin spn_movex;

	public TabPage tabPage_lineararray;

	public TabPage tabPage_mirror;

	public TabPage tabPage_copy;

	public TabPage tabPage_rotate;

	public TabPage tabPage_circulararray;

	public buSpin spn_scalex;

	public buSpin spn_scaley;

	internal PictureBox pictureBox_1;

	public buSpin spn_lineararraydisx;

	public buSpin spn_lineararraydisy;

	public buSpin spn_lineararraycountx;

	public buSpin spn_lineararraycounty;

	internal PictureBox pictureBox_2;

	internal buCheckBox buCheckBox_0;

	internal buCheckBox buCheckBox_1;

	public buSpin spn_mirrordis;

	internal PictureBox pictureBox_3;

	public buSpin spn_copyy;

	public buSpin spn_copyx;

	internal PictureBox pictureBox_4;

	public buSpin spn_rotate;

	internal PictureBox pictureBox_5;

	public buSpin spn_circulararraycount;

	public buSpin spn_circulararrayangle;

	internal PictureBox pictureBox_6;

	public F_EventAll()
	{
		Class186.smethod_623(this);
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
		LoadLanguage();
		spn_movex.Value = Data.MoveX;
		spn_movey.Value = Data.MoveY;
		spn_copyx.Value = Data.CopyX;
		spn_copyy.Value = Data.CopyY;
		spn_scalex.Value = Data.ScaleX;
		spn_scaley.Value = Data.ScaleY;
		spn_rotate.Value = Data.RotateAngle;
		spn_mirrordis.Value = Data.MirrorDistance;
		spn_lineararraycountx.Value = Data.LinearArrayXCount;
		spn_lineararraycounty.Value = Data.LinearArrayYCount;
		spn_lineararraydisx.Value = Data.LinearArrayXDistance;
		spn_lineararraydisy.Value = Data.LinearArrayYDistance;
		spn_circulararrayangle.Value = Data.CircularArrarAngle;
		spn_circulararraycount.Value = Data.CircularArrayCount;
		if (Data.MirrorAxis != MirrorAxisXYType.X)
		{
			buCheckBox_0.Check = false;
			buCheckBox_1.Check = true;
		}
		else
		{
			buCheckBox_0.Check = true;
			buCheckBox_1.Check = false;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 14)
			{
				buGround_0.Text = Captions[0];
				btn_ok.Text = Captions[13];
				btn_cancel.Text = Captions[14];
			}
		}
		catch (Exception)
		{
		}
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
		try
		{
			if (AppBool.TouchPad)
			{
				buSpin buSpin2 = new buSpin();
				buSpin2 = (buSpin)sender;
				buControlCommands.ShowKeyPad(this, buSpin2);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	public void Apply()
	{
		Data.MoveX = spn_movex.Value;
		Data.MoveY = spn_movey.Value;
		Data.CopyX = spn_copyx.Value;
		Data.CopyY = spn_copyy.Value;
		Data.ScaleX = spn_scalex.Value;
		Data.ScaleY = spn_scaley.Value;
		Data.RotateAngle = spn_rotate.Value;
		Data.MirrorDistance = spn_mirrordis.Value;
		Data.LinearArrayXCount = spn_lineararraycountx.Value;
		Data.LinearArrayYCount = spn_lineararraycounty.Value;
		Data.LinearArrayXDistance = spn_lineararraydisx.Value;
		Data.LinearArrayYDistance = spn_lineararraydisy.Value;
		Data.CircularArrarAngle = spn_circulararrayangle.Value;
		Data.CircularArrayCount = spn_circulararraycount.Value;
		if (!buCheckBox_0.Check)
		{
			Data.MirrorAxis = MirrorAxisXYType.Y;
		}
		else
		{
			Data.MirrorAxis = MirrorAxisXYType.X;
		}
	}

	internal void method_2(object sender, EventArgs e)
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

	internal void method_3(object sender, EventArgs e)
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

	internal void method_4(object sender, EventArgs e)
	{
		buSpin buSpin2 = (buSpin)sender;
		buSpin2.Display.BackColor = SpinFocusColor;
	}

	internal void method_5(object sender, EventArgs e)
	{
		buSpin buSpin2 = (buSpin)sender;
		buSpin2.Display.BackColor = SpinBaseColor;
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
