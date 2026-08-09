using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Location;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleLibraryMenu : Form
{
	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public MarbleLibraryMenuType LibraryType = MarbleLibraryMenuType.Editor;

	public MarbleItemType ItemType = MarbleItemType.Contour;

	public marbleMenuType MenuType = new marbleMenuType();

	public Color clrLabel = Color.DarkSeaGreen;

	public Color clrFormCaption = Color.LightBlue;

	public Color clrFormBackUpper = Color.Black;

	public Color clrFormBackDown = Color.DarkGray;

	public Color clrButtonDisplay = Color.DarkGray;

	public Color clrButtonOver = Color.Gold;

	public Color clrButtonDown = Color.Goldenrod;

	internal IContainer icontainer_0 = null;

	public buButton btn_contourmenueditor;

	public buButton btn_contourmenufilelist;

	public buButton btn_close;

	internal buSeparator buSeparator_0;

	internal buSeparator buSeparator_1;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buButton btn_camsettings;

	public buButton btn_toolsettings;

	public buButton btn_strategy;

	public buButton btn_tool;

	public buGround buGround1;

	public buLabel lbl_strategytype;

	public buLabel lbl_tooltype;

	public buLabel lbl_contourtype;

	public buCheckBox chk_addtonesting;

	public buCheckBox chk_insidemilling;

	internal buSeparator buSeparator_2;

	public buLabel lbl_events;

	public buCheckBox chk_rotate90plus;

	public buCheckBox chk_rotate180plus;

	public buCheckBox chk_rotate90minus;

	public buCheckBox chk_rotate180minus;

	public buCheckBox chk_mirroY;

	public buCheckBox chk_mirrorX;

	public buButton btn_objectlocation;

	internal ImageList imageList_2;

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

	public F_MarbleLibraryMenu()
	{
		Class186.smethod_692(this);
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
		ToolToImageIndex();
		StrategyFromToolType();
		if (!PropertiesForm.VisualUpdated)
		{
			InitVisual();
		}
		btn_objectlocation.Image = imageList_2.Images[Convert.ToInt32(MenuType.objectAlignment)];
		chk_insidemilling.Check = MenuType.InsideMilling;
		buGround1.DisplayTop.BackColor = clrFormCaption;
		buGround1.Display.GradientType = GradientMode.Lineer;
		buGround1.Display.LineerGradient.FirstColor = clrFormBackUpper;
		buGround1.Display.LineerGradient.SecondColor = clrFormBackDown;
		btn_close.Display.BackColor = clrFormCaption;
		btn_close.ButtonDownDisplay.BackColor = buImage5.ColorToneChange(clrFormCaption, 0.9);
		btn_close.ButtonOverDisplay.BackColor = buImage5.ColorToneChange(clrFormCaption, 0.95);
		lbl_contourtype.Display.BackColor = clrLabel;
		lbl_strategytype.Display.BackColor = clrLabel;
		lbl_tooltype.Display.BackColor = clrLabel;
		chk_mirrorX.Check = false;
		chk_mirroY.Check = false;
		chk_rotate180plus.Check = false;
		chk_rotate90plus.Check = false;
		chk_rotate180minus.Check = false;
		chk_rotate90minus.Check = false;
		btn_contourmenueditor.Display.BackColor = clrButtonDisplay;
		btn_contourmenueditor.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_contourmenueditor.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_contourmenufilelist.Display.BackColor = clrButtonDisplay;
		btn_contourmenufilelist.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_contourmenufilelist.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_strategy.Display.BackColor = clrButtonDisplay;
		btn_strategy.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_strategy.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_tool.Display.BackColor = clrButtonDisplay;
		btn_tool.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_tool.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_toolsettings.Display.BackColor = clrButtonDisplay;
		btn_toolsettings.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_toolsettings.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_camsettings.Display.BackColor = clrButtonDisplay;
		btn_camsettings.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_camsettings.ButtonOverDisplay.BackColor = clrButtonOver;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void InitVisual()
	{
		FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
		if (fileInfo.Exists)
		{
			Control.ControlCollection controlCollection = null;
			controlCollection = buGround1.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
		}
		PropertiesForm.VisualUpdated = true;
	}

	public void LoadLanguage()
	{
		try
		{
			lbl_contourtype.Text = buLangTranslate.preDef.Library + " " + buLangTranslate.preDef.Type;
			lbl_strategytype.Text = buLangTranslate.preDef.Strategy + " " + buLangTranslate.preDef.Type;
			lbl_tooltype.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Type;
			btn_contourmenueditor.Text = buLangTranslate.preDef.Editor;
			btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
			btn_strategy.Text = buLangTranslate.preDef.Strategy;
			btn_tool.Text = buLangTranslate.preDef.Tool;
			chk_addtonesting.Text = buLangTranslate.preDef.Nesting + " " + buLangTranslate.preDef.Add;
			buGround1.Text = buLangTranslate.preDef.Library + " " + buLangTranslate.preDef.Menu;
			chk_mirrorX.Text = buLangTranslate.preDef.Mirror + " X";
			chk_mirroY.Text = buLangTranslate.preDef.Mirror + " Y";
			lbl_events.Text = buLangTranslate.preDef.Events;
		}
		catch (Exception)
		{
		}
	}

	public void StrategyMillingToImageIndex()
	{
		if (MenuType.selectedWireframeType == CamWireFrameType.CenterPath)
		{
			btn_strategy.Image = imageList_0.Images[0];
		}
		if (MenuType.selectedWireframeType == CamWireFrameType.Chamfer2D)
		{
			btn_strategy.Image = imageList_0.Images[1];
		}
		if (MenuType.selectedWireframeType == CamWireFrameType.Contour)
		{
			btn_strategy.Image = imageList_0.Images[6];
		}
		if (MenuType.selectedWireframeType == CamWireFrameType.Engrave)
		{
			btn_strategy.Image = imageList_0.Images[3];
		}
		if (MenuType.selectedWireframeType == CamWireFrameType.Face)
		{
			btn_strategy.Image = imageList_0.Images[4];
		}
		if (MenuType.selectedWireframeType == CamWireFrameType.FloorFinish)
		{
			btn_strategy.Image = imageList_0.Images[5];
		}
		if (MenuType.selectedWireframeType == CamWireFrameType.Pocket)
		{
			btn_strategy.Image = imageList_0.Images[7];
		}
		if (MenuType.selectedWireframeType == CamWireFrameType.TextEngrave)
		{
			btn_strategy.Image = imageList_0.Images[8];
		}
		if (MenuType.selectedWireframeType == CamWireFrameType.Trochoidal)
		{
			btn_strategy.Image = imageList_0.Images[9];
		}
		btn_strategy.Text = buLangTranslate.preDef.Cam + " : " + MenuType.selectedWireframeType;
	}

	public void StrategySawToImageIndex()
	{
		if (MenuType.selectedSawCamType == MarbleSawCamType.Contour)
		{
			btn_strategy.Image = imageList_0.Images[10];
		}
		btn_strategy.Text = buLangTranslate.preDef.Cam + " : " + MenuType.selectedSawCamType;
	}

	public void StrategyWaterToImageIndex()
	{
		if (MenuType.selectedWaterJetCamType == MarbleWaterJetCamType.Contour)
		{
			btn_strategy.Image = imageList_0.Images[11];
		}
		btn_strategy.Text = buLangTranslate.preDef.Cam + " : " + MenuType.selectedWaterJetCamType;
	}

	public void ToolToImageIndex()
	{
		if (MenuType.selectedTool == MarbleToolType.Saw)
		{
			btn_tool.Image = imageList_1.Images[0];
		}
		if (MenuType.selectedTool == MarbleToolType.Milling)
		{
			btn_tool.Image = imageList_1.Images[1];
		}
		if (MenuType.selectedTool == MarbleToolType.MillingHead)
		{
			btn_tool.Image = imageList_1.Images[2];
		}
		btn_tool.Text = buLangTranslate.preDef.Tool + " : " + MenuType.selectedTool;
	}

	public void StrategyFromToolType()
	{
		if ((MenuType.selectedTool == MarbleToolType.Milling) | (MenuType.selectedTool == MarbleToolType.MillingHead))
		{
			StrategyMillingToImageIndex();
		}
		if (MenuType.selectedTool == MarbleToolType.Saw)
		{
			StrategySawToImageIndex();
		}
		if (MenuType.selectedTool == MarbleToolType.WaterJet)
		{
			StrategyWaterToImageIndex();
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
		if (!(control.Name == btn_tool.Name))
		{
			if (!(control.Name == btn_strategy.Name))
			{
				if (!(control.Name == btn_toolsettings.Name))
				{
					if (!(control.Name == btn_camsettings.Name))
					{
						if (!(control.Name == btn_objectlocation.Name))
						{
							MenuType.MirrorX = chk_mirrorX.Check;
							MenuType.MirrorY = chk_mirroY.Check;
							MenuType.Rotate180Plus = chk_rotate180plus.Check;
							MenuType.Rotate90Plus = chk_rotate90plus.Check;
							MenuType.Rotate180Minus = chk_rotate180minus.Check;
							MenuType.Rotate90Minus = chk_rotate90minus.Check;
							MenuType.InsideMilling = chk_insidemilling.Check;
							PropertiesForm.Result = DialogResult.OK;
							if (control.Name == btn_contourmenueditor.Name)
							{
								LibraryType = MarbleLibraryMenuType.Editor;
							}
							if (control.Name == btn_contourmenufilelist.Name)
							{
								LibraryType = MarbleLibraryMenuType.FromList;
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
						else
						{
							F_ObjectLocation f_ObjectLocation = new F_ObjectLocation();
							f_ObjectLocation.Alingnment = MenuType.objectAlignment;
							f_ObjectLocation.Properties.FormCloseMode = FormCloseModeType.Dispose;
							f_ObjectLocation.Properties.FormPosition = FormStartPosition.Manual;
							f_ObjectLocation.Top = 100;
							f_ObjectLocation.Left = Screen.PrimaryScreen.Bounds.Width - f_ObjectLocation.Width;
							f_ObjectLocation.Init();
							f_ObjectLocation.ShowDialog(this);
							if (f_ObjectLocation.Properties.Result == DialogResult.OK)
							{
								MenuType.objectAlignment = f_ObjectLocation.Alingnment;
								btn_objectlocation.Image = imageList_2.Images[Convert.ToInt32(MenuType.objectAlignment)];
							}
						}
					}
					else if (okCommandWithFiveDataEventHandler_0 != null)
					{
						if ((MenuType.selectedTool == MarbleToolType.Milling) | (MenuType.selectedTool == MarbleToolType.MillingHead))
						{
							okCommandWithFiveDataEventHandler_0("CamSetting", ItemType, MenuType.selectedTool, MenuType.selectedWireframeType, null);
						}
						if (MenuType.selectedTool == MarbleToolType.Saw)
						{
							okCommandWithFiveDataEventHandler_0("CamSetting", ItemType, MenuType.selectedTool, MenuType.selectedSawCamType, null);
						}
						if (MenuType.selectedTool == MarbleToolType.WaterJet)
						{
							okCommandWithFiveDataEventHandler_0("CamSetting", ItemType, MenuType.selectedTool, MenuType.selectedWaterJetCamType, null);
						}
					}
				}
				else if (okCommandWithFiveDataEventHandler_0 != null)
				{
					okCommandWithFiveDataEventHandler_0("ToolSetting", MenuType.selectedTool, null, null, null);
				}
				return;
			}
			if ((MenuType.selectedTool == MarbleToolType.Milling) | (MenuType.selectedTool == MarbleToolType.MillingHead))
			{
				F_Marble2DCamStrategyMenu f_Marble2DCamStrategyMenu = new F_Marble2DCamStrategyMenu();
				f_Marble2DCamStrategyMenu.WireframeType = MenuType.selectedWireframeType;
				f_Marble2DCamStrategyMenu.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_Marble2DCamStrategyMenu.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
				f_Marble2DCamStrategyMenu.Init();
				f_Marble2DCamStrategyMenu.ShowDialog();
				if (f_Marble2DCamStrategyMenu.PropertiesForm.Result == DialogResult.OK)
				{
					MenuType.selectedWireframeType = f_Marble2DCamStrategyMenu.WireframeType;
					StrategyFromToolType();
				}
			}
			if (MenuType.selectedTool == MarbleToolType.Saw)
			{
				F_MarbleSawCamStrategyMenu f_MarbleSawCamStrategyMenu = new F_MarbleSawCamStrategyMenu();
				f_MarbleSawCamStrategyMenu.SawCamType = MenuType.selectedSawCamType;
				f_MarbleSawCamStrategyMenu.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_MarbleSawCamStrategyMenu.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
				f_MarbleSawCamStrategyMenu.Init();
				f_MarbleSawCamStrategyMenu.ShowDialog();
				if (f_MarbleSawCamStrategyMenu.PropertiesForm.Result == DialogResult.OK)
				{
					MenuType.selectedSawCamType = f_MarbleSawCamStrategyMenu.SawCamType;
					StrategyFromToolType();
				}
			}
			if (MenuType.selectedTool == MarbleToolType.WaterJet)
			{
				F_MarbleWaterJetCamStrategyMenu f_MarbleWaterJetCamStrategyMenu = new F_MarbleWaterJetCamStrategyMenu();
				f_MarbleWaterJetCamStrategyMenu.WaterJetCamType = MenuType.selectedWaterJetCamType;
				f_MarbleWaterJetCamStrategyMenu.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_MarbleWaterJetCamStrategyMenu.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
				f_MarbleWaterJetCamStrategyMenu.Init();
				f_MarbleWaterJetCamStrategyMenu.ShowDialog();
				if (f_MarbleWaterJetCamStrategyMenu.PropertiesForm.Result == DialogResult.OK)
				{
					MenuType.selectedWaterJetCamType = f_MarbleWaterJetCamStrategyMenu.WaterJetCamType;
					StrategyFromToolType();
				}
			}
		}
		else
		{
			F_MarbleToolMenu f_MarbleToolMenu = new F_MarbleToolMenu();
			f_MarbleToolMenu.ToolType = MenuType.selectedTool;
			f_MarbleToolMenu.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
			f_MarbleToolMenu.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
			f_MarbleToolMenu.Init();
			f_MarbleToolMenu.ShowDialog();
			if (f_MarbleToolMenu.PropertiesForm.Result == DialogResult.OK)
			{
				MenuType.selectedTool = f_MarbleToolMenu.ToolType;
				ToolToImageIndex();
				StrategyFromToolType();
			}
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
		Control control = sender as Control;
		if (control.Name == chk_rotate180minus.Name)
		{
			chk_rotate180plus.Check = false;
			chk_rotate90minus.Check = false;
			chk_rotate90plus.Check = false;
		}
		if (control.Name == chk_rotate180plus.Name)
		{
			chk_rotate180minus.Check = false;
			chk_rotate90minus.Check = false;
			chk_rotate90plus.Check = false;
		}
		if (control.Name == chk_rotate90minus.Name)
		{
			chk_rotate180minus.Check = false;
			chk_rotate180plus.Check = false;
			chk_rotate90plus.Check = false;
		}
		if (control.Name == chk_rotate90plus.Name)
		{
			chk_rotate180minus.Check = false;
			chk_rotate180plus.Check = false;
			chk_rotate90minus.Check = false;
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
