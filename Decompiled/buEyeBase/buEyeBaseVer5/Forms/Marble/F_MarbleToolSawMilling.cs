using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolSawMilling : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public ToolBase5 ToolMilling = new ToolBase5();

	public ToolBase5 ToolSaw = new ToolBase5();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buButton btn_opentools;

	public buButton btn_savetools;

	public buTab buTab_command_settings;

	public TabPage tabPage_saw;

	public TabPage tabPage_mlling;

	internal Panel panel_0;

	public buButton btn_saw_activate;

	public buButton btn_saw_zeroposition;

	public buButton btn_sawgonyele;

	public buButton btn_sawlimitdisable;

	public buButton btn_saw_measure;

	public buSpin spn_sawspeed;

	public buSpin spn_sawthickness;

	public buSpin spn_sawdia;

	public buButton btn_milling_activate;

	public buButton btn_milling_zeroposition;

	public buButton btn_milling_limitdisable;

	public buButton btn_milling_measure;

	public buSpin spn_milling_speed;

	public buSpin spn_milling_length;

	public buSpin spn_milling_diameter;

	internal Panel panel_1;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	public buButton btn_stop;

	public F_MarbleToolSawMilling()
	{
		Class186.smethod_218(this);
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
		spn_milling_diameter.Value = ToolMilling.Geometry.Diameter;
		spn_milling_length.Value = ToolMilling.Geometry.Length;
		spn_milling_speed.Value = ToolMilling.CamData.SpindleSpeed;
		spn_sawdia.Value = ToolSaw.Geometry.Diameter;
		spn_sawthickness.Value = ToolSaw.Geometry.Thickness;
		spn_sawspeed.Value = ToolSaw.CamData.SpindleSpeed;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			buGround_0.Text = buLangTranslate.preDef.Tools;
			btn_ok.Text = buLangTranslate.preDef.Ok;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
			tabPage_saw.Text = buLangTranslate.preDef.Saw;
			tabPage_mlling.Text = buLangTranslate.preDef.Milling;
			btn_sawgonyele.Text = buLangTranslate.preDef.Perpendicular;
			btn_sawlimitdisable.Text = buLangTranslate.preDef.Limit + " " + buLangTranslate.preDef.Disable;
			btn_saw_activate.Text = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Activate;
			btn_saw_measure.Text = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Measure;
			btn_saw_zeroposition.Text = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Zero;
			btn_milling_limitdisable.Text = buLangTranslate.preDef.Limit + " " + buLangTranslate.preDef.Disable;
			btn_milling_activate.Text = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Activate;
			btn_milling_measure.Text = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Measure;
			btn_milling_zeroposition.Text = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Zero;
			btn_savetools.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Save;
			btn_opentools.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Open;
			spn_sawdia.Caption.Caption = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Diameter;
			spn_sawthickness.Caption.Caption = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Thickness;
			spn_sawspeed.Caption.Caption = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Speed;
			spn_milling_diameter.Caption.Caption = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Diameter;
			spn_milling_length.Caption.Caption = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Length;
			spn_milling_speed.Caption.Caption = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Speed;
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
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	public void Apply()
	{
		ToolMilling.Geometry.Diameter = spn_milling_diameter.Value;
		ToolMilling.Geometry.Length = spn_milling_length.Value;
		ToolMilling.CamData.SpindleSpeed = spn_milling_speed.Value;
		ToolSaw.Geometry.Diameter = spn_sawdia.Value;
		ToolSaw.Geometry.Thickness = spn_sawthickness.Value;
		ToolSaw.CamData.SpindleSpeed = spn_sawspeed.Value;
	}

	public void UpdateSawDiameter(double Diameter)
	{
		if (Diameter > 0.0)
		{
			spn_sawdia.Value = Diameter;
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
