using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_Marble5DCamStrategyMenu : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public CamTriangularMeshType MeshType = CamTriangularMeshType.Rough;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	public buButton btn_close;

	public buCheckBox chk_constantZ;

	public buCheckBox chk_parallelcut;

	public buCheckBox chk_rough;

	public buCheckBox chk_none;

	public F_Marble5DCamStrategyMenu()
	{
		Class186.smethod_793(this);
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
		chk_constantZ.Check = false;
		chk_parallelcut.Check = false;
		chk_rough.Check = false;
		chk_none.Check = false;
		if (MeshType != CamTriangularMeshType.ConstantZ)
		{
			if (MeshType != CamTriangularMeshType.Rough)
			{
				if (MeshType != CamTriangularMeshType.ParallelCuts)
				{
					chk_none.Check = true;
				}
				else
				{
					chk_parallelcut.Check = true;
				}
			}
			else
			{
				chk_rough.Check = true;
			}
		}
		else
		{
			chk_constantZ.Check = true;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			chk_constantZ.Text = buLangTranslate.preDef.ConstantZ + " " + buLangTranslate.preDef.Strategy;
			chk_parallelcut.Text = buLangTranslate.preDef.ParalelCuts + " " + buLangTranslate.preDef.Strategy;
			chk_rough.Text = buLangTranslate.preDef.Rough + " " + buLangTranslate.preDef.Strategy;
			chk_none.Text = buLangTranslate.preDef.None;
			buGround_0.Text = "5 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Strategy;
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
			if (control.Name == chk_constantZ.Name)
			{
				chk_constantZ.Check = true;
				MeshType = CamTriangularMeshType.ConstantZ;
			}
			if (control.Name == chk_rough.Name)
			{
				chk_rough.Check = true;
				MeshType = CamTriangularMeshType.Rough;
			}
			if (control.Name == chk_parallelcut.Name)
			{
				chk_parallelcut.Check = false;
				MeshType = CamTriangularMeshType.ParallelCuts;
			}
			if (control.Name == chk_none.Name)
			{
				chk_none.Check = false;
				MeshType = CamTriangularMeshType.None;
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
