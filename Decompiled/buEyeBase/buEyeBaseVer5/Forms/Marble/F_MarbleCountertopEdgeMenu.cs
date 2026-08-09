using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCountertopEdgeMenu : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public MarbleCountertopEdgeCommandTypes Type = MarbleCountertopEdgeCommandTypes.Edge;

	public Color clrLabel = Color.DarkSeaGreen;

	public Color clrFormCaption = Color.LightBlue;

	public Color clrFormBackUpper = Color.Black;

	public Color clrFormBackDown = Color.DarkGray;

	public Color clrButtonDisplay = Color.DarkGray;

	public Color clrButtonOver = Color.Gold;

	public Color clrButtonDown = Color.Goldenrod;

	internal IContainer icontainer_0 = null;

	public buButton btn_chamfer;

	public buButton btn_slat;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buGround buGround1;

	public buButton btn_settings;

	public buButton btn_close;

	public buButton btn_pocket;

	public buButton btn_angle;

	public F_MarbleCountertopEdgeMenu()
	{
		Class186.smethod_379(this);
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
		buGround1.DisplayTop.BackColor = clrFormCaption;
		buGround1.Display.GradientType = GradientMode.Lineer;
		buGround1.Display.LineerGradient.FirstColor = clrFormBackUpper;
		buGround1.Display.LineerGradient.SecondColor = clrFormBackDown;
		btn_close.Display.BackColor = clrFormCaption;
		btn_close.ButtonDownDisplay.BackColor = buImage5.ColorToneChange(clrFormCaption, 0.9);
		btn_close.ButtonOverDisplay.BackColor = buImage5.ColorToneChange(clrFormCaption, 0.95);
		btn_slat.Display.BackColor = clrButtonDisplay;
		btn_slat.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_slat.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_chamfer.Display.BackColor = clrButtonDisplay;
		btn_chamfer.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_chamfer.ButtonOverDisplay.BackColor = clrButtonOver;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			btn_chamfer.Text = buLangTranslate.preDef.Chamfer;
			btn_angle.Text = buLangTranslate.preDef.Angle;
			btn_slat.Text = buLangTranslate.preDef.Slat;
			btn_pocket.Text = buLangTranslate.preDef.Pocket;
			buGround1.Text = buLangTranslate.preDef.Edge + " " + buLangTranslate.preDef.Menu;
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
		Control control = sender as Control;
		PropertiesForm.Result = DialogResult.OK;
		if (control.Name == btn_chamfer.Name)
		{
			Type = MarbleCountertopEdgeCommandTypes.Chamfer;
		}
		if (control.Name == btn_angle.Name)
		{
			Type = MarbleCountertopEdgeCommandTypes.Angle;
		}
		if (control.Name == btn_slat.Name)
		{
			Type = MarbleCountertopEdgeCommandTypes.Slat;
		}
		if (control.Name == btn_pocket.Name)
		{
			Type = MarbleCountertopEdgeCommandTypes.Pocket;
		}
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
