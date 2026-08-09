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

public class F_MarbleTextMenu : Form
{
	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public MarbleTextMenuType TextType = MarbleTextMenuType.Font;

	public MarbleItemType ItemType = MarbleItemType.Profiling;

	public marbleMenuType MenuType = new marbleMenuType();

	public Color clrLabel = Color.DarkSeaGreen;

	public Color clrFormCaption = Color.LightBlue;

	public Color clrFormBackUpper = Color.Black;

	public Color clrFormBackDown = Color.DarkGray;

	public Color clrButtonDisplay = Color.DarkGray;

	public Color clrButtonOver = Color.Gold;

	public Color clrButtonDown = Color.Goldenrod;

	internal IContainer icontainer_0 = null;

	public buButton btn_textfont;

	public buButton btn_textfromfile;

	public buButton btn_textwireframe;

	public buButton btn_close;

	public buCheckBox chk_3D;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buButton btn_camsettings;

	public buButton btn_toolsettings;

	public buButton btn_strategy;

	public buButton btn_tool;

	internal buSeparator buSeparator_0;

	internal buSeparator buSeparator_1;

	public buGround buGround1;

	public buLabel lbl_strategytype;

	public buLabel lbl_tooltype;

	public buLabel lbl_contourtype;

	public buCheckBox chk_addtonesting;

	public buButton btn_camsettings2;

	public buButton btn_strategy2;

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

	public F_MarbleTextMenu()
	{
		Class186.smethod_209(this);
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
		StrategyFromToolType(0);
		StrategyFromToolType(1);
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
		btn_textfont.Display.BackColor = clrButtonDisplay;
		btn_textfont.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_textfont.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_textfromfile.Display.BackColor = clrButtonDisplay;
		btn_textfromfile.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_textfromfile.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_textwireframe.Display.BackColor = clrButtonDisplay;
		btn_textwireframe.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_textwireframe.ButtonOverDisplay.BackColor = clrButtonOver;
		chk_3D.Display.BackColor = clrButtonDisplay;
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
			lbl_contourtype.Text = buLangTranslate.preDef.Text + " " + buLangTranslate.preDef.Type;
			lbl_strategytype.Text = buLangTranslate.preDef.Strategy + " " + buLangTranslate.preDef.Type;
			lbl_tooltype.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Type;
			btn_textfont.Text = buLangTranslate.preDef.Font;
			btn_textfromfile.Text = buLangTranslate.preDef.FromFile;
			btn_textwireframe.Text = buLangTranslate.preDef.Wireframe;
			btn_strategy.Text = buLangTranslate.preDef.Strategy;
			btn_strategy2.Text = buLangTranslate.preDef.Strategy;
			btn_tool.Text = buLangTranslate.preDef.Tool;
			buGround1.Text = buLangTranslate.preDef.Text + " " + buLangTranslate.preDef.Menu;
			chk_addtonesting.Text = buLangTranslate.preDef.Nesting + " " + buLangTranslate.preDef.Add;
		}
		catch (Exception)
		{
		}
	}

	public void StrategyMillingToImageIndex(int Index)
	{
		if (chk_3D.Check)
		{
			if (Index == 0)
			{
				if (MenuType.selectedMeshType == CamTriangularMeshType.Rough)
				{
					btn_strategy.Image = imageList_0.Images[19];
				}
				if (MenuType.selectedMeshType == CamTriangularMeshType.ParallelCuts)
				{
					btn_strategy.Image = imageList_0.Images[17];
				}
				if (MenuType.selectedMeshType == CamTriangularMeshType.ConstantZ)
				{
					btn_strategy.Image = imageList_0.Images[15];
				}
				if (MenuType.selectedMeshType == CamTriangularMeshType.Flatlands)
				{
					btn_strategy.Image = imageList_0.Images[16];
				}
				if (MenuType.selectedMeshType == CamTriangularMeshType.Pencil)
				{
					btn_strategy.Image = imageList_0.Images[18];
				}
				if (MenuType.selectedMeshType == CamTriangularMeshType.None)
				{
					btn_strategy.Image = imageList_0.Images[14];
				}
			}
			if (Index == 1)
			{
				if (MenuType.selectedMeshType2 == CamTriangularMeshType.Rough)
				{
					btn_strategy2.Image = imageList_0.Images[19];
				}
				if (MenuType.selectedMeshType2 == CamTriangularMeshType.ParallelCuts)
				{
					btn_strategy2.Image = imageList_0.Images[17];
				}
				if (MenuType.selectedMeshType2 == CamTriangularMeshType.ConstantZ)
				{
					btn_strategy2.Image = imageList_0.Images[15];
				}
				if (MenuType.selectedMeshType2 == CamTriangularMeshType.Flatlands)
				{
					btn_strategy2.Image = imageList_0.Images[16];
				}
				if (MenuType.selectedMeshType2 == CamTriangularMeshType.Pencil)
				{
					btn_strategy2.Image = imageList_0.Images[18];
				}
				if (MenuType.selectedMeshType2 == CamTriangularMeshType.None)
				{
					btn_strategy2.Image = imageList_0.Images[14];
				}
			}
			btn_strategy.Text = buLangTranslate.preDef.Cam + " : " + MenuType.selectedMeshType;
			btn_strategy2.Text = buLangTranslate.preDef.Cam + " : " + MenuType.selectedMeshType2;
			return;
		}
		if (Index == 0)
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
			if (MenuType.selectedWireframeType == CamWireFrameType.None)
			{
				btn_strategy.Image = imageList_0.Images[12];
			}
		}
		if (Index == 1)
		{
			if (MenuType.selectedWireframeType2 == CamWireFrameType.CenterPath)
			{
				btn_strategy2.Image = imageList_0.Images[0];
			}
			if (MenuType.selectedWireframeType2 == CamWireFrameType.Chamfer2D)
			{
				btn_strategy2.Image = imageList_0.Images[1];
			}
			if (MenuType.selectedWireframeType2 == CamWireFrameType.Contour)
			{
				btn_strategy2.Image = imageList_0.Images[6];
			}
			if (MenuType.selectedWireframeType2 == CamWireFrameType.Engrave)
			{
				btn_strategy2.Image = imageList_0.Images[3];
			}
			if (MenuType.selectedWireframeType2 == CamWireFrameType.Face)
			{
				btn_strategy2.Image = imageList_0.Images[4];
			}
			if (MenuType.selectedWireframeType2 == CamWireFrameType.FloorFinish)
			{
				btn_strategy2.Image = imageList_0.Images[5];
			}
			if (MenuType.selectedWireframeType2 == CamWireFrameType.Pocket)
			{
				btn_strategy2.Image = imageList_0.Images[7];
			}
			if (MenuType.selectedWireframeType2 == CamWireFrameType.TextEngrave)
			{
				btn_strategy2.Image = imageList_0.Images[8];
			}
			if (MenuType.selectedWireframeType2 == CamWireFrameType.Trochoidal)
			{
				btn_strategy2.Image = imageList_0.Images[9];
			}
			if (MenuType.selectedWireframeType2 == CamWireFrameType.None)
			{
				btn_strategy2.Image = imageList_0.Images[12];
			}
		}
		btn_strategy.Text = buLangTranslate.preDef.Cam + " : " + MenuType.selectedWireframeType;
		btn_strategy2.Text = buLangTranslate.preDef.Cam + " : " + MenuType.selectedWireframeType2;
	}

	public void StrategySawToImageIndex()
	{
		if (MenuType.selectedSawCamType == MarbleSawCamType.Contour)
		{
			btn_strategy.Image = imageList_0.Images[10];
			btn_strategy2.Image = imageList_0.Images[13];
		}
		btn_strategy.Text = buLangTranslate.preDef.Cam + " : " + MenuType.selectedSawCamType;
		btn_strategy2.Text = buLangTranslate.preDef.Cam + " : " + buLangTranslate.preDef.None;
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

	public void StrategyFromToolType(int Index)
	{
		if ((MenuType.selectedTool == MarbleToolType.Milling) | (MenuType.selectedTool == MarbleToolType.MillingHead))
		{
			StrategyMillingToImageIndex(Index);
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
		if (!(control.Name == chk_3D.Name))
		{
			if (!(control.Name == btn_tool.Name))
			{
				if (!(control.Name == btn_strategy.Name))
				{
					if (!(control.Name == btn_strategy2.Name))
					{
						if (!(control.Name == btn_toolsettings.Name))
						{
							if (!(control.Name == btn_camsettings.Name))
							{
								if (!(control.Name == btn_camsettings2.Name))
								{
									PropertiesForm.Result = DialogResult.OK;
									if (control.Name == btn_textfont.Name)
									{
										TextType = MarbleTextMenuType.Font;
									}
									if (control.Name == btn_textfromfile.Name)
									{
										TextType = MarbleTextMenuType.FromFile;
									}
									if (control.Name == btn_textwireframe.Name)
									{
										TextType = MarbleTextMenuType.Wireframe;
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
									if (!chk_3D.Check)
									{
										okCommandWithFiveDataEventHandler_0("CamSetting", ItemType, MenuType.selectedTool, MenuType.selectedWireframeType2, null);
									}
									else
									{
										okCommandWithFiveDataEventHandler_0("CamSetting", ItemType, MenuType.selectedTool, MenuType.selectedMeshType2, null);
									}
								}
							}
							else if (okCommandWithFiveDataEventHandler_0 != null)
							{
								if (!chk_3D.Check)
								{
									okCommandWithFiveDataEventHandler_0("CamSetting", ItemType, MenuType.selectedTool, MenuType.selectedWireframeType, null);
								}
								else
								{
									okCommandWithFiveDataEventHandler_0("CamSetting", ItemType, MenuType.selectedTool, MenuType.selectedMeshType, null);
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
						if (chk_3D.Check)
						{
							F_Marble3DCamStrategyMenu f_Marble3DCamStrategyMenu = new F_Marble3DCamStrategyMenu();
							f_Marble3DCamStrategyMenu.MeshType = MenuType.selectedMeshType2;
							f_Marble3DCamStrategyMenu.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
							f_Marble3DCamStrategyMenu.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
							f_Marble3DCamStrategyMenu.Init();
							f_Marble3DCamStrategyMenu.ShowDialog();
							if (f_Marble3DCamStrategyMenu.PropertiesForm.Result == DialogResult.OK)
							{
								MenuType.selectedMeshType2 = f_Marble3DCamStrategyMenu.MeshType;
								StrategyFromToolType(0);
								StrategyFromToolType(1);
							}
						}
						else
						{
							F_Marble2DCamStrategyMenu f_Marble2DCamStrategyMenu = new F_Marble2DCamStrategyMenu();
							f_Marble2DCamStrategyMenu.WireframeType = MenuType.selectedWireframeType;
							f_Marble2DCamStrategyMenu.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
							f_Marble2DCamStrategyMenu.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
							f_Marble2DCamStrategyMenu.Init();
							f_Marble2DCamStrategyMenu.ShowDialog();
							if (f_Marble2DCamStrategyMenu.PropertiesForm.Result == DialogResult.OK)
							{
								MenuType.selectedWireframeType2 = f_Marble2DCamStrategyMenu.WireframeType;
								StrategyFromToolType(0);
								StrategyFromToolType(1);
							}
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
							StrategyFromToolType(0);
							StrategyFromToolType(1);
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
							StrategyFromToolType(0);
							StrategyFromToolType(1);
						}
					}
					return;
				}
				if ((MenuType.selectedTool == MarbleToolType.Milling) | (MenuType.selectedTool == MarbleToolType.MillingHead))
				{
					if (chk_3D.Check)
					{
						F_Marble3DCamStrategyMenu f_Marble3DCamStrategyMenu2 = new F_Marble3DCamStrategyMenu();
						f_Marble3DCamStrategyMenu2.MeshType = MenuType.selectedMeshType;
						f_Marble3DCamStrategyMenu2.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
						f_Marble3DCamStrategyMenu2.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
						f_Marble3DCamStrategyMenu2.Init();
						f_Marble3DCamStrategyMenu2.ShowDialog();
						if (f_Marble3DCamStrategyMenu2.PropertiesForm.Result == DialogResult.OK)
						{
							MenuType.selectedMeshType = f_Marble3DCamStrategyMenu2.MeshType;
							StrategyFromToolType(0);
							StrategyFromToolType(1);
						}
					}
					else
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
							StrategyFromToolType(0);
							StrategyFromToolType(1);
						}
					}
				}
				if (MenuType.selectedTool == MarbleToolType.Saw)
				{
					F_MarbleSawCamStrategyMenu f_MarbleSawCamStrategyMenu2 = new F_MarbleSawCamStrategyMenu();
					f_MarbleSawCamStrategyMenu2.SawCamType = MenuType.selectedSawCamType;
					f_MarbleSawCamStrategyMenu2.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
					f_MarbleSawCamStrategyMenu2.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
					f_MarbleSawCamStrategyMenu2.Init();
					f_MarbleSawCamStrategyMenu2.ShowDialog();
					if (f_MarbleSawCamStrategyMenu2.PropertiesForm.Result == DialogResult.OK)
					{
						MenuType.selectedSawCamType = f_MarbleSawCamStrategyMenu2.SawCamType;
						StrategyFromToolType(0);
						StrategyFromToolType(1);
					}
				}
				if (MenuType.selectedTool == MarbleToolType.WaterJet)
				{
					F_MarbleWaterJetCamStrategyMenu f_MarbleWaterJetCamStrategyMenu2 = new F_MarbleWaterJetCamStrategyMenu();
					f_MarbleWaterJetCamStrategyMenu2.WaterJetCamType = MenuType.selectedWaterJetCamType;
					f_MarbleWaterJetCamStrategyMenu2.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
					f_MarbleWaterJetCamStrategyMenu2.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
					f_MarbleWaterJetCamStrategyMenu2.Init();
					f_MarbleWaterJetCamStrategyMenu2.ShowDialog();
					if (f_MarbleWaterJetCamStrategyMenu2.PropertiesForm.Result == DialogResult.OK)
					{
						MenuType.selectedWaterJetCamType = f_MarbleWaterJetCamStrategyMenu2.WaterJetCamType;
						StrategyFromToolType(0);
						StrategyFromToolType(1);
					}
				}
			}
			else
			{
				F_MarbleToolMillingMillingHeadMenu f_MarbleToolMillingMillingHeadMenu = new F_MarbleToolMillingMillingHeadMenu();
				f_MarbleToolMillingMillingHeadMenu.ToolType = MenuType.selectedTool;
				f_MarbleToolMillingMillingHeadMenu.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_MarbleToolMillingMillingHeadMenu.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
				f_MarbleToolMillingMillingHeadMenu.Init();
				f_MarbleToolMillingMillingHeadMenu.ShowDialog();
				if (f_MarbleToolMillingMillingHeadMenu.PropertiesForm.Result == DialogResult.OK)
				{
					MenuType.selectedTool = f_MarbleToolMillingMillingHeadMenu.ToolType;
					ToolToImageIndex();
					StrategyFromToolType(0);
					StrategyFromToolType(1);
				}
			}
		}
		else
		{
			ToolToImageIndex();
			StrategyFromToolType(0);
			StrategyFromToolType(1);
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
