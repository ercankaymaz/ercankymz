using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolSpindleAndMagazine : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public ToolBase5 ToolMilling = new ToolBase5();

	public ToolBase5[] Tools = null;

	public FormProperties PropertiesForm = new FormProperties();

	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buButton btn_opentools;

	public buButton btn_savetools;

	public buTab buTab_command_settings;

	public TabPage tabPage_mlling;

	internal Panel panel_0;

	public buButton btn_milling_activate;

	public buButton btn_milling_zeroposition;

	public buButton btn_milling_limitdisable;

	public buButton btn_milling_measure;

	public buSpin spn_milling_speed;

	public buSpin spn_milling_length;

	public buSpin spn_milling_diameter;

	internal PictureBox pictureBox_0;

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

	internal TabPage tabPage_0;

	public buSpin spn_toolZ6;

	public buSpin spn_toolY6;

	public buSpin spn_toolX6;

	public buSpin spn_toolZ5;

	public buSpin spn_toolY5;

	public buSpin spn_toolX5;

	public buSpin spn_toolZ4;

	public buSpin spn_toolY4;

	public buSpin spn_toolX4;

	public buSpin spn_toolZ3;

	public buSpin spn_toolY3;

	public buSpin spn_toolX3;

	public buSpin spn_toolZ2;

	public buSpin spn_toolY2;

	public buSpin spn_toolX2;

	public buLabel buLabel1;

	public buLabel buLabel2;

	public buLabel buLabel3;

	public buLabel buLabel4;

	public buLabel buLabel5;

	public buLabel buLabel6;

	public buLabel buLabel7;

	public buLabel buLabel8;

	public buSpin spn_toolZ1;

	public buSpin spn_toolY1;

	public buSpin spn_toolX1;

	public buLabel buLabel9;

	public buButton btn_tooltake6;

	public buButton btn_tooltake5;

	public buButton btn_tooltake4;

	public buButton btn_tooltake3;

	public buButton btn_tooltake2;

	public buButton btn_tooltake1;

	public buButton btn_magazineclose;

	public buButton btn_doorclose;

	public buButton btn_pensopen;

	public buButton btn_pensclose;

	public buButton btn_magazineopen;

	public buButton btn_dooropen;

	public buCheckBox chk_round6;

	public buCheckBox chk_round5;

	public buCheckBox chk_round4;

	public buCheckBox chk_round3;

	public buCheckBox chk_round2;

	public buLabel buLabel10;

	public buCheckBox chk_round1;

	public event OkCommandWithFiveDataEventHandler CommandTool
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler = okCommandWithFiveDataEventHandler_0;
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler2;
			do
			{
				okCommandWithFiveDataEventHandler2 = okCommandWithFiveDataEventHandler;
				OkCommandWithFiveDataEventHandler value2 = (OkCommandWithFiveDataEventHandler)Delegate.Combine(okCommandWithFiveDataEventHandler2, value);
				okCommandWithFiveDataEventHandler = Interlocked.CompareExchange(ref okCommandWithFiveDataEventHandler_0, value2, okCommandWithFiveDataEventHandler2);
			}
			while ((object)okCommandWithFiveDataEventHandler != okCommandWithFiveDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler = okCommandWithFiveDataEventHandler_0;
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler2;
			do
			{
				okCommandWithFiveDataEventHandler2 = okCommandWithFiveDataEventHandler;
				OkCommandWithFiveDataEventHandler value2 = (OkCommandWithFiveDataEventHandler)Delegate.Remove(okCommandWithFiveDataEventHandler2, value);
				okCommandWithFiveDataEventHandler = Interlocked.CompareExchange(ref okCommandWithFiveDataEventHandler_0, value2, okCommandWithFiveDataEventHandler2);
			}
			while ((object)okCommandWithFiveDataEventHandler != okCommandWithFiveDataEventHandler2);
		}
	}

	public F_MarbleToolSpindleAndMagazine()
	{
		Class186.smethod_81(this);
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
		spn_toolX1.Value = Tools[1].Positions.Position.X;
		spn_toolX2.Value = Tools[2].Positions.Position.X;
		spn_toolX3.Value = Tools[3].Positions.Position.X;
		spn_toolX4.Value = Tools[4].Positions.Position.X;
		spn_toolX5.Value = Tools[5].Positions.Position.X;
		spn_toolX6.Value = Tools[6].Positions.Position.X;
		spn_toolY1.Value = Tools[1].Positions.Position.Y;
		spn_toolY2.Value = Tools[2].Positions.Position.Y;
		spn_toolY3.Value = Tools[3].Positions.Position.Y;
		spn_toolY4.Value = Tools[4].Positions.Position.Y;
		spn_toolY5.Value = Tools[5].Positions.Position.Y;
		spn_toolY6.Value = Tools[6].Positions.Position.Y;
		spn_toolZ1.Value = Tools[1].Positions.Position.Z;
		spn_toolZ2.Value = Tools[2].Positions.Position.Z;
		spn_toolZ3.Value = Tools[3].Positions.Position.Z;
		spn_toolZ4.Value = Tools[4].Positions.Position.Z;
		spn_toolZ5.Value = Tools[5].Positions.Position.Z;
		spn_toolZ6.Value = Tools[6].Positions.Position.Z;
		if (Tools[1].Geometry.GeometryType != ToolType.Flat)
		{
			chk_round1.Check = true;
		}
		else
		{
			chk_round1.Check = false;
		}
		if (Tools[2].Geometry.GeometryType != ToolType.Flat)
		{
			chk_round2.Check = true;
		}
		else
		{
			chk_round2.Check = false;
		}
		if (Tools[3].Geometry.GeometryType != ToolType.Flat)
		{
			chk_round3.Check = true;
		}
		else
		{
			chk_round3.Check = false;
		}
		if (Tools[4].Geometry.GeometryType != ToolType.Flat)
		{
			chk_round4.Check = true;
		}
		else
		{
			chk_round4.Check = false;
		}
		if (Tools[5].Geometry.GeometryType != ToolType.Flat)
		{
			chk_round5.Check = true;
		}
		else
		{
			chk_round5.Check = false;
		}
		if (Tools[6].Geometry.GeometryType != ToolType.Flat)
		{
			chk_round6.Check = true;
		}
		else
		{
			chk_round6.Check = false;
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
			tabPage_mlling.Text = buLangTranslate.preDef.Milling;
			btn_milling_limitdisable.Text = buLangTranslate.preDef.Limit + " " + buLangTranslate.preDef.Disable;
			btn_milling_activate.Text = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Activate;
			btn_milling_measure.Text = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Measure;
			btn_milling_zeroposition.Text = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Zero;
			btn_savetools.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Save;
			btn_opentools.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Open;
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
		Tools[1].Geometry.Length = spn_toollen1.Value;
		Tools[2].Geometry.Length = spn_toollen2.Value;
		Tools[3].Geometry.Length = spn_toollen3.Value;
		Tools[4].Geometry.Length = spn_toollen4.Value;
		Tools[5].Geometry.Length = spn_toollen5.Value;
		if (Tools.Length >= 6)
		{
			Tools[6].Geometry.Length = spn_toollen6.Value;
		}
		Tools[1].Geometry.Diameter = spn_tooldia1.Value;
		Tools[2].Geometry.Diameter = spn_tooldia2.Value;
		Tools[3].Geometry.Diameter = spn_tooldia3.Value;
		Tools[4].Geometry.Diameter = spn_tooldia4.Value;
		Tools[5].Geometry.Diameter = spn_tooldia5.Value;
		if (Tools.Length >= 6)
		{
			Tools[6].Geometry.Diameter = spn_tooldia6.Value;
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
		Tools[1].Positions.Position.X = spn_toolX1.Value;
		Tools[2].Positions.Position.X = spn_toolX2.Value;
		Tools[3].Positions.Position.X = spn_toolX3.Value;
		Tools[4].Positions.Position.X = spn_toolX4.Value;
		Tools[5].Positions.Position.X = spn_toolX5.Value;
		Tools[6].Positions.Position.X = spn_toolX6.Value;
		Tools[1].Positions.Position.Y = spn_toolY1.Value;
		Tools[2].Positions.Position.Y = spn_toolY2.Value;
		Tools[3].Positions.Position.Y = spn_toolY3.Value;
		Tools[4].Positions.Position.Y = spn_toolY4.Value;
		Tools[5].Positions.Position.Y = spn_toolY5.Value;
		Tools[6].Positions.Position.Y = spn_toolY6.Value;
		Tools[1].Positions.Position.Z = spn_toolZ1.Value;
		Tools[2].Positions.Position.Z = spn_toolZ2.Value;
		Tools[3].Positions.Position.Z = spn_toolZ3.Value;
		Tools[4].Positions.Position.Z = spn_toolZ4.Value;
		Tools[5].Positions.Position.Z = spn_toolZ5.Value;
		Tools[6].Positions.Position.Z = spn_toolZ6.Value;
		if (chk_round1.Check)
		{
			Tools[1].Geometry.GeometryType = ToolType.Sphere;
		}
		else
		{
			Tools[1].Geometry.GeometryType = ToolType.Flat;
		}
		if (chk_round2.Check)
		{
			Tools[2].Geometry.GeometryType = ToolType.Sphere;
		}
		else
		{
			Tools[2].Geometry.GeometryType = ToolType.Flat;
		}
		if (chk_round3.Check)
		{
			Tools[3].Geometry.GeometryType = ToolType.Sphere;
		}
		else
		{
			Tools[3].Geometry.GeometryType = ToolType.Flat;
		}
		if (chk_round4.Check)
		{
			Tools[4].Geometry.GeometryType = ToolType.Sphere;
		}
		else
		{
			Tools[4].Geometry.GeometryType = ToolType.Flat;
		}
		if (chk_round5.Check)
		{
			Tools[5].Geometry.GeometryType = ToolType.Sphere;
		}
		else
		{
			Tools[5].Geometry.GeometryType = ToolType.Flat;
		}
		if (chk_round6.Check)
		{
			Tools[6].Geometry.GeometryType = ToolType.Sphere;
		}
		else
		{
			Tools[6].Geometry.GeometryType = ToolType.Flat;
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

	internal void method_3(object sender, EventArgs e)
	{
		buButton buButton2 = sender as buButton;
		if (okCommandWithFiveDataEventHandler_0 != null)
		{
			if ((buButton2.Name == btn_toolacitve1.Name) | (buButton2.Name == btn_toolacitve2.Name) | (buButton2.Name == btn_toolacitve3.Name) | (buButton2.Name == btn_toolacitve4.Name) | (buButton2.Name == btn_toolacitve5.Name) | (buButton2.Name == btn_toolacitve6.Name))
			{
				Apply();
				okCommandWithFiveDataEventHandler_0(MarbleHMICommands.ToolSetActive, buButton2.Aux.Index, null, null, null);
			}
			if ((buButton2.Name == btn_tooltake1.Name) | (buButton2.Name == btn_tooltake2.Name) | (buButton2.Name == btn_tooltake3.Name) | (buButton2.Name == btn_tooltake4.Name) | (buButton2.Name == btn_tooltake5.Name) | (buButton2.Name == btn_tooltake6.Name))
			{
				Apply();
				okCommandWithFiveDataEventHandler_0(MarbleHMICommands.ToolChange, buButton2.Aux.Index, null, null, null);
			}
			if (buButton2.Name == btn_doorclose.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleHMICommands.DoorClose, null, null, null, null);
			}
			if (buButton2.Name == btn_dooropen.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleHMICommands.DoorOpen, null, null, null, null);
			}
			if (buButton2.Name == btn_magazineclose.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleHMICommands.MagazineClose, null, null, null, null);
			}
			if (buButton2.Name == btn_magazineopen.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleHMICommands.MagazineOpen, null, null, null, null);
			}
			if (buButton2.Name == btn_pensclose.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleHMICommands.PensClose, null, null, null, null);
			}
			if (buButton2.Name == btn_pensopen.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleHMICommands.PensOpen, null, null, null, null);
			}
			if (buButton2.Name == btn_magazine_measure.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleHMICommands.MillingToolZero, null, null, null, null);
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
