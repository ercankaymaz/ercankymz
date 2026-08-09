using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_Marble2DCamStrategyMenu : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public CamWireFrameType WireframeType = CamWireFrameType.Contour;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	public buButton btn_close;

	public buCheckBox chk_center;

	public buCheckBox chk_Contour;

	public buCheckBox chk_engrave;

	public buCheckBox chk_chamfer;

	public buCheckBox chk_floorfinish;

	public buCheckBox chk_face;

	public buCheckBox chk_trochoidal;

	public buCheckBox chk_textengrave;

	public buCheckBox chk_rough;

	public buCheckBox chk_none;

	public F_Marble2DCamStrategyMenu()
	{
		Class186.smethod_318(this);
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
		chk_center.Check = false;
		chk_chamfer.Check = false;
		chk_Contour.Check = false;
		chk_engrave.Check = false;
		chk_face.Check = false;
		chk_floorfinish.Check = false;
		chk_rough.Check = false;
		chk_textengrave.Check = false;
		chk_trochoidal.Check = false;
		chk_none.Check = false;
		if (WireframeType == CamWireFrameType.CenterPath)
		{
			chk_center.Check = true;
		}
		if (WireframeType == CamWireFrameType.Chamfer2D)
		{
			chk_chamfer.Check = true;
		}
		if (WireframeType == CamWireFrameType.Contour)
		{
			chk_Contour.Check = true;
		}
		if (WireframeType == CamWireFrameType.Engrave)
		{
			chk_engrave.Check = true;
		}
		if (WireframeType == CamWireFrameType.Face)
		{
			chk_face.Check = true;
		}
		if (WireframeType == CamWireFrameType.FloorFinish)
		{
			chk_floorfinish.Check = true;
		}
		if (WireframeType == CamWireFrameType.Pocket)
		{
			chk_rough.Check = true;
		}
		if (WireframeType == CamWireFrameType.TextEngrave)
		{
			chk_textengrave.Check = true;
		}
		if (WireframeType == CamWireFrameType.Trochoidal)
		{
			chk_trochoidal.Check = true;
		}
		if (WireframeType == CamWireFrameType.None)
		{
			chk_none.Check = true;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			chk_center.Text = buLangTranslate.preDef.Center + " " + buLangTranslate.preDef.Strategy;
			chk_chamfer.Text = buLangTranslate.preDef.Chamfer + " " + buLangTranslate.preDef.Strategy;
			chk_Contour.Text = buLangTranslate.preDef.Contour + " " + buLangTranslate.preDef.Strategy;
			chk_engrave.Text = buLangTranslate.preDef.Engrave + " " + buLangTranslate.preDef.Strategy;
			chk_face.Text = buLangTranslate.preDef.Face + " " + buLangTranslate.preDef.Strategy;
			chk_floorfinish.Text = buLangTranslate.preDef.FloorFinish + " " + buLangTranslate.preDef.Strategy;
			chk_rough.Text = buLangTranslate.preDef.Rough + " " + buLangTranslate.preDef.Strategy;
			chk_textengrave.Text = buLangTranslate.preDef.TextEngrave + " " + buLangTranslate.preDef.Strategy;
			chk_trochoidal.Text = buLangTranslate.preDef.Trochoidal + " " + buLangTranslate.preDef.Strategy;
			chk_none.Text = buLangTranslate.preDef.None;
			buGround_0.Text = buLangTranslate.preDef.Millind2D + " " + buLangTranslate.preDef.Strategy;
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

	internal void method_2(object object_0, bool bool_0)
	{
		if (PropertiesForm.Inited)
		{
			Control control = object_0 as Control;
			if (control.Name == chk_center.Name)
			{
				chk_center.Check = true;
				WireframeType = CamWireFrameType.CenterPath;
			}
			if (control.Name == chk_chamfer.Name)
			{
				chk_chamfer.Check = true;
				WireframeType = CamWireFrameType.Chamfer2D;
			}
			if (control.Name == chk_Contour.Name)
			{
				chk_Contour.Check = false;
				WireframeType = CamWireFrameType.Contour;
			}
			if (control.Name == chk_engrave.Name)
			{
				chk_engrave.Check = false;
				WireframeType = CamWireFrameType.Engrave;
			}
			if (control.Name == chk_face.Name)
			{
				chk_face.Check = false;
				WireframeType = CamWireFrameType.Face;
			}
			if (control.Name == chk_floorfinish.Name)
			{
				chk_floorfinish.Check = false;
				WireframeType = CamWireFrameType.FloorFinish;
			}
			if (control.Name == chk_rough.Name)
			{
				chk_rough.Check = false;
				WireframeType = CamWireFrameType.Pocket;
			}
			if (control.Name == chk_textengrave.Name)
			{
				chk_textengrave.Check = false;
				WireframeType = CamWireFrameType.TextEngrave;
			}
			if (control.Name == chk_trochoidal.Name)
			{
				chk_trochoidal.Check = false;
				WireframeType = CamWireFrameType.Trochoidal;
			}
			if (control.Name == chk_none.Name)
			{
				chk_none.Check = false;
				WireframeType = CamWireFrameType.None;
			}
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
