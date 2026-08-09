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

public class F_Marble3DShapeMenu : Form
{
	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public MarbleShapeTypes ShapeType = MarbleShapeTypes.Rectangle;

	public MarbleItemType ItemType = MarbleItemType.Shape;

	public marbleMenuType MenuType = new marbleMenuType();

	public Color clrLabel = Color.DarkSeaGreen;

	public Color clrFormCaption = Color.LightBlue;

	public Color clrFormBackUpper = Color.Black;

	public Color clrFormBackDown = Color.DarkGray;

	public Color clrButtonDisplay = Color.DarkGray;

	public Color clrButtonOver = Color.Gold;

	public Color clrButtonDown = Color.Goldenrod;

	internal IContainer icontainer_0 = null;

	public buButton btn_rectangle;

	public buButton btn_ellipse;

	public buButton btn_circle;

	public buButton btn_trapezoid;

	public buButton btn_triangle;

	public buButton btn_slot;

	public buButton btn_polygon;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	internal buSeparator buSeparator_0;

	public buButton btn_camsettings;

	public buButton btn_toolsettings;

	public buButton btn_strategy;

	public buButton btn_tool;

	public buGround buGround1;

	public buLabel lbl_strategytype;

	public buLabel lbl_tooltype;

	public buLabel lbl_contourtype;

	public buButton btn_settings;

	public buButton btn_close;

	public buButton btn_arc;

	public buButton btn_shipnose;

	public buButton btn_rectanglecross;

	public buButton btn_rectanglechamfer;

	public buButton btn_rectangleround;

	public buButton btn_ellipsepie;

	public buButton btn_arcpie;

	public buButton btn_library;

	public buButton btn_contour;

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

	public F_Marble3DShapeMenu()
	{
		Class186.smethod_537(this);
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
		btn_circle.Display.BackColor = clrButtonDisplay;
		btn_circle.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_circle.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_ellipse.Display.BackColor = clrButtonDisplay;
		btn_ellipse.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_ellipse.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_polygon.Display.BackColor = clrButtonDisplay;
		btn_polygon.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_polygon.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_rectangle.Display.BackColor = clrButtonDisplay;
		btn_rectangle.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_rectangle.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_slot.Display.BackColor = clrButtonDisplay;
		btn_slot.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_slot.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_trapezoid.Display.BackColor = clrButtonDisplay;
		btn_trapezoid.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_trapezoid.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_triangle.Display.BackColor = clrButtonDisplay;
		btn_triangle.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_triangle.ButtonOverDisplay.BackColor = clrButtonOver;
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

	public void LoadLanguage()
	{
		try
		{
			lbl_contourtype.Text = buLangTranslate.preDef.Shape + " " + buLangTranslate.preDef.Type;
			lbl_strategytype.Text = buLangTranslate.preDef.Strategy + " " + buLangTranslate.preDef.Type;
			lbl_tooltype.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Type;
			btn_rectangle.Text = buLangTranslate.preDef.Rectangle;
			btn_circle.Text = buLangTranslate.preDef.Cirlce;
			btn_ellipse.Text = buLangTranslate.preDef.Ellipse;
			btn_polygon.Text = buLangTranslate.preDef.Polygon;
			btn_slot.Text = buLangTranslate.preDef.Slot;
			btn_trapezoid.Text = buLangTranslate.preDef.Trapezoid;
			btn_triangle.Text = buLangTranslate.preDef.Triangle;
			btn_arc.Text = buLangTranslate.preDef.Arc;
			btn_strategy.Text = buLangTranslate.preDef.Strategy;
			btn_tool.Text = buLangTranslate.preDef.Tool;
			buGround1.Text = buLangTranslate.preDef.Shape + " " + buLangTranslate.preDef.Menu;
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

	public void StrategyMillingHeadToImageIndex()
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
		if (MenuType.selectedTool == MarbleToolType.Milling)
		{
			StrategyMillingToImageIndex();
		}
		if (MenuType.selectedTool == MarbleToolType.MillingHead)
		{
			StrategyMillingHeadToImageIndex();
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
				if (!(control.Name == btn_settings.Name))
				{
					if (!(control.Name == btn_toolsettings.Name))
					{
						if (!(control.Name == btn_camsettings.Name))
						{
							PropertiesForm.Result = DialogResult.OK;
							if (control.Name == btn_rectangle.Name)
							{
								ShapeType = MarbleShapeTypes.Rectangle;
							}
							if (control.Name == btn_rectangleround.Name)
							{
								ShapeType = MarbleShapeTypes.RoundRectangle;
							}
							if (control.Name == btn_rectanglechamfer.Name)
							{
								ShapeType = MarbleShapeTypes.ChamferRectangle;
							}
							if (control.Name == btn_rectanglecross.Name)
							{
								ShapeType = MarbleShapeTypes.CrossRectangle;
							}
							if (control.Name == btn_ellipse.Name)
							{
								ShapeType = MarbleShapeTypes.Ellipse;
							}
							if (control.Name == btn_circle.Name)
							{
								ShapeType = MarbleShapeTypes.Circle;
							}
							if (control.Name == btn_ellipsepie.Name)
							{
								ShapeType = MarbleShapeTypes.EllipsePie;
							}
							if (control.Name == btn_arcpie.Name)
							{
								ShapeType = MarbleShapeTypes.ArcPie;
							}
							if (control.Name == btn_polygon.Name)
							{
								ShapeType = MarbleShapeTypes.Polygon;
							}
							if (control.Name == btn_slot.Name)
							{
								ShapeType = MarbleShapeTypes.Slot;
							}
							if (control.Name == btn_trapezoid.Name)
							{
								ShapeType = MarbleShapeTypes.Trepezoid;
							}
							if (control.Name == btn_triangle.Name)
							{
								ShapeType = MarbleShapeTypes.Triangle;
							}
							if (control.Name == btn_arc.Name)
							{
								ShapeType = MarbleShapeTypes.Arc;
							}
							if (control.Name == btn_shipnose.Name)
							{
								ShapeType = MarbleShapeTypes.ShipNose;
							}
							if (control.Name == btn_contour.Name)
							{
								ShapeType = MarbleShapeTypes.Contour;
							}
							if (control.Name == btn_library.Name)
							{
								ShapeType = MarbleShapeTypes.Library;
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
						else if (okCommandWithFiveDataEventHandler_0 != null)
						{
							if (MenuType.selectedTool == MarbleToolType.Milling)
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
							if (MenuType.selectedTool == MarbleToolType.MillingHead)
							{
								okCommandWithFiveDataEventHandler_0("CamSetting", ItemType, MenuType.selectedTool, MenuType.selectedWireframeType, null);
							}
						}
					}
					else if (okCommandWithFiveDataEventHandler_0 != null)
					{
						okCommandWithFiveDataEventHandler_0("ToolSetting", MenuType.selectedTool, null, null, null);
					}
				}
				else if (okCommandWithFiveDataEventHandler_0 != null)
				{
					okCommandWithFiveDataEventHandler_0("ContourSetting", MenuType.selectedTool, null, null, null);
				}
				return;
			}
			if (MenuType.selectedTool == MarbleToolType.Milling)
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
			if (MenuType.selectedTool == MarbleToolType.MillingHead)
			{
				F_Marble2DCamStrategyMenu f_Marble2DCamStrategyMenu2 = new F_Marble2DCamStrategyMenu();
				f_Marble2DCamStrategyMenu2.WireframeType = MenuType.selectedWireframeType;
				f_Marble2DCamStrategyMenu2.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_Marble2DCamStrategyMenu2.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
				f_Marble2DCamStrategyMenu2.Init();
				f_Marble2DCamStrategyMenu2.ShowDialog();
				if (f_Marble2DCamStrategyMenu2.PropertiesForm.Result == DialogResult.OK)
				{
					MenuType.selectedWireframeType = f_Marble2DCamStrategyMenu2.WireframeType;
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
