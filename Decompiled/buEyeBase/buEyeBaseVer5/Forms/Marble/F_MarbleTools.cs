using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleTools : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public ToolBase5 ToolMilling = new ToolBase5();

	public ToolBase5 ToolSaw = new ToolBase5();

	public ToolBase5[] Tools = null;

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

	public buButton btn_magazine_zero;

	public buButton btn_magazine_disablelimit;

	public buButton btn_magazine_measure;

	public buSpin spn_toolspeed6;

	public buSpin spn_tooldia6;

	public buSpin spn_toollen6;

	public buSpin spn_toolspeed5;

	public buSpin spn_tooldia5;

	public buSpin spn_toollen5;

	public buSpin spn_toolspeed4;

	public buSpin spn_tooldia4;

	public buSpin spn_toollen4;

	public buSpin spn_toolspeed3;

	public buSpin spn_tooldia3;

	public buSpin spn_toollen3;

	public buSpin spn_toolspeed2;

	public buSpin spn_tooldia2;

	public buSpin spn_toollen2;

	public buSpin spn_toolspeed1;

	public buSpin spn_tooldia1;

	public buSpin spn_toollen1;

	public buButton btn_toolacitve6;

	public buButton btn_toolacitve5;

	public buButton btn_toolacitve4;

	public buButton btn_toolacitve3;

	public buButton btn_toolacitve2;

	public buButton btn_toolacitve1;

	public TabPage tabPage_magazine;

	public buLabel lbl_tool1;

	public buLabel lbl_tool6;

	public buLabel lbl_tool5;

	public buLabel lbl_tool4;

	public buLabel lbl_tool3;

	public buLabel lbl_tool2;

	public buLabel lbl_toolspeed;

	public buLabel lbl_tooldia;

	public buLabel lbl_toollen;

	public F_MarbleTools()
	{
		Class186.smethod_163(this);
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
		spn_toollen1.Value = Tools[1].Geometry.Length;
		spn_toollen2.Value = Tools[2].Geometry.Length;
		spn_toollen3.Value = Tools[3].Geometry.Length;
		spn_toollen4.Value = Tools[4].Geometry.Length;
		spn_toollen5.Value = Tools[5].Geometry.Length;
		if (Tools.Length >= 6)
		{
			spn_toollen6.Value = Tools[6].Geometry.Length;
		}
		spn_tooldia1.Value = Tools[1].Geometry.Diameter;
		spn_tooldia2.Value = Tools[2].Geometry.Diameter;
		spn_tooldia3.Value = Tools[3].Geometry.Diameter;
		spn_tooldia4.Value = Tools[4].Geometry.Diameter;
		spn_tooldia5.Value = Tools[5].Geometry.Diameter;
		if (Tools.Length >= 6)
		{
			spn_tooldia1.Value = Tools[1].Geometry.Diameter;
		}
		spn_toolspeed1.Value = Tools[1].CamData.SpindleSpeed;
		spn_toolspeed2.Value = Tools[2].CamData.SpindleSpeed;
		spn_toolspeed3.Value = Tools[3].CamData.SpindleSpeed;
		spn_toolspeed4.Value = Tools[4].CamData.SpindleSpeed;
		spn_toolspeed5.Value = Tools[5].CamData.SpindleSpeed;
		if (Tools.Length >= 6)
		{
			spn_toolspeed6.Value = Tools[6].CamData.SpindleSpeed;
		}
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

	public void Apply()
	{
		ToolMilling.Geometry.Diameter = spn_milling_diameter.Value;
		ToolMilling.Geometry.Length = spn_milling_length.Value;
		ToolMilling.CamData.SpindleSpeed = spn_milling_speed.Value;
		ToolSaw.Geometry.Diameter = spn_sawdia.Value;
		ToolSaw.Geometry.Thickness = spn_sawthickness.Value;
		ToolSaw.CamData.SpindleSpeed = spn_sawspeed.Value;
		Tools[1].Geometry.Length = spn_toollen1.Value;
		Tools[2].Geometry.Length = spn_toollen2.Value;
		Tools[3].Geometry.Length = spn_toollen3.Value;
		Tools[4].Geometry.Length = spn_toollen4.Value;
		Tools[5].Geometry.Length = spn_toollen5.Value;
		if (Tools.Length >= 6)
		{
			Tools[6].Geometry.Length = spn_toollen6.Value;
		}
		Tools[1].CamData.SpindleSpeed = spn_toolspeed1.Value;
		Tools[2].CamData.SpindleSpeed = spn_toolspeed2.Value;
		Tools[3].CamData.SpindleSpeed = spn_toolspeed3.Value;
		Tools[4].CamData.SpindleSpeed = spn_toolspeed4.Value;
		Tools[5].CamData.SpindleSpeed = spn_toolspeed5.Value;
		if (Tools.Length >= 6)
		{
			Tools[1].CamData.SpindleSpeed = spn_toolspeed6.Value;
		}
	}

	public void UpdateSawDiameter(double Diameter)
	{
		if (Diameter > 0.0)
		{
			spn_sawdia.Value = Diameter;
		}
	}

	public void UpdateMagazineLength(int activetool, double Length)
	{
		if (activetool >= 1 && activetool <= 6 && Length > 0.0)
		{
			if (activetool == 1)
			{
				spn_toollen1.Value = Length;
			}
			if (activetool == 2)
			{
				spn_toollen2.Value = Length;
			}
			if (activetool == 3)
			{
				spn_toollen3.Value = Length;
			}
			if (activetool == 4)
			{
				spn_toollen4.Value = Length;
			}
			if (activetool == 5)
			{
				spn_toollen5.Value = Length;
			}
			if (activetool == 6)
			{
				spn_toollen6.Value = Length;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
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

	internal void method_2(object sender, EventArgs e)
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
