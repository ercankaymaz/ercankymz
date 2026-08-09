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

public class F_MarbleCamProfile : Form
{
	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public MarbleCamType CommandType = MarbleCamType.None;

	public Color clrLabel = Color.DarkSeaGreen;

	public Color clrFormCaption = Color.LightBlue;

	public Color clrFormBackUpper = Color.Black;

	public Color clrFormBackDown = Color.DarkGray;

	public Color clrButtonDisplay = Color.DarkGray;

	public Color clrButtonOver = Color.Gold;

	public Color clrButtonDown = Color.Goldenrod;

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buGround buGround1;

	public buButton btn_constantZ3AX;

	public buButton btn_paralllelcut3AX;

	public buButton btn_profilefinish;

	public buButton btn_profilerough;

	public buButton btn_Rough3AX;

	public buButton btn_surfaceclear;

	public buButton btn_profileroughoutside;

	public buButton btn_profiloffset;

	public event OkCommandWithFiveDataEventHandler CommandExecute
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

	public F_MarbleCamProfile()
	{
		Class186.smethod_822(this);
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
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			btn_constantZ3AX.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.ConstantZ;
			btn_paralllelcut3AX.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.ParalelCuts;
			btn_Rough3AX.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Rough;
			btn_profilefinish.Text = buLangTranslate.preDef.Profile + " " + buLangTranslate.preDef.Finish;
			btn_profilerough.Text = buLangTranslate.preDef.Profile + " " + buLangTranslate.preDef.Rough;
			btn_surfaceclear.Text = buLangTranslate.preDef.Surface + " " + buLangTranslate.preDef.Cleaning;
			btn_profileroughoutside.Text = buLangTranslate.preDef.Rough + " " + buLangTranslate.preDef.Outside;
			btn_profiloffset.Text = buLangTranslate.preDef.Profile + " " + buLangTranslate.preDef.Offset;
			buGround1.Text = buLangTranslate.preDef.Cam + " " + buLangTranslate.preDef.Strategy;
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
		if (!(control.Name == btn_Rough3AX.Name))
		{
			if (!(control.Name == btn_constantZ3AX.Name))
			{
				if (!(control.Name == btn_paralllelcut3AX.Name))
				{
					if (!(control.Name == btn_profilefinish.Name))
					{
						if (!(control.Name == btn_profilerough.Name))
						{
							if (!(control.Name == btn_surfaceclear.Name))
							{
								if (!(control.Name == btn_profileroughoutside.Name))
								{
									if (control.Name == btn_profiloffset.Name)
									{
										CommandType = MarbleCamType.ProfileOffset;
									}
								}
								else
								{
									CommandType = MarbleCamType.RoughOutside;
								}
							}
							else
							{
								CommandType = MarbleCamType.Surface2D;
							}
						}
						else
						{
							CommandType = MarbleCamType.ProfileRough;
						}
					}
					else
					{
						CommandType = MarbleCamType.ProfileFinish;
					}
				}
				else
				{
					CommandType = MarbleCamType.MillingParallelCut3D;
				}
			}
			else
			{
				CommandType = MarbleCamType.MillingContantZ3D;
			}
		}
		else
		{
			CommandType = MarbleCamType.MillingRough3D;
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
		CommandType = MarbleCamType.None;
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
