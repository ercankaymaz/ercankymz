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

public class F_MarbleMilling5AxisMenu : Form
{
	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public MarbleEngraveMenuType EngraveType = MarbleEngraveMenuType.Editor;

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

	public buButton btn_contourmenufilelist;

	public buButton btn_contourmenufromfile;

	public buButton btn_close;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	internal buSeparator buSeparator_0;

	internal buSeparator buSeparator_1;

	public buButton btn_strategy;

	public buButton btn_tool;

	public buButton btn_camsettings;

	public buButton btn_toolsettings;

	public buGround buGround1;

	public buLabel lbl_strategytype;

	public buLabel lbl_tooltype;

	public buLabel lbl_contourtype;

	public buButton btn_camsettings2;

	public buButton btn_strategy2;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

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

	public F_MarbleMilling5AxisMenu()
	{
		Class186.smethod_51(this);
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
		if (MenuType.AxesNumber != 3)
		{
			if (MenuType.AxesNumber != 4)
			{
				if (MenuType.AxesNumber == 5)
				{
					radioButton_0.Checked = true;
				}
			}
			else
			{
				radioButton_1.Checked = true;
			}
		}
		else
		{
			radioButton_2.Checked = true;
		}
		btn_contourmenufilelist.Display.BackColor = clrButtonDisplay;
		btn_contourmenufilelist.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_contourmenufilelist.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_contourmenufromfile.Display.BackColor = clrButtonDisplay;
		btn_contourmenufromfile.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_contourmenufromfile.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_strategy.Display.BackColor = clrButtonDisplay;
		btn_strategy.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_strategy.ButtonOverDisplay.BackColor = clrButtonOver;
		btn_strategy2.Display.BackColor = clrButtonDisplay;
		btn_strategy2.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_strategy2.ButtonOverDisplay.BackColor = clrButtonOver;
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
			lbl_contourtype.Text = buLangTranslate.preDef.Engrave + " " + buLangTranslate.preDef.Type;
			lbl_strategytype.Text = buLangTranslate.preDef.Strategy + " " + buLangTranslate.preDef.Type;
			lbl_tooltype.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Type;
			btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
			btn_contourmenufromfile.Text = buLangTranslate.preDef.FromFile;
			btn_strategy.Text = buLangTranslate.preDef.Strategy;
			btn_tool.Text = buLangTranslate.preDef.Tool;
			buGround1.Text = "5 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Menu;
		}
		catch (Exception)
		{
		}
	}

	public void StrategyMillingToImageIndex(int Index)
	{
		if (Index == 0)
		{
			if (MenuType.selectedMesh5AxisType == CamTriangularMeshType.Rough)
			{
				btn_strategy.Image = imageList_0.Images[0];
			}
			if (MenuType.selectedMesh5AxisType == CamTriangularMeshType.ParallelCuts)
			{
				btn_strategy.Image = imageList_0.Images[1];
			}
			if (MenuType.selectedMesh5AxisType == CamTriangularMeshType.ConstantZ)
			{
				btn_strategy.Image = imageList_0.Images[2];
			}
			if (MenuType.selectedMesh5AxisType == CamTriangularMeshType.None)
			{
				btn_strategy.Image = imageList_0.Images[3];
			}
			btn_strategy.Text = buLangTranslate.preDef.Cam + " : " + MenuType.selectedMesh5AxisType;
		}
		if (Index == 1)
		{
			if (MenuType.selectedMesh5AxisType2 == CamTriangularMeshType.Rough)
			{
				btn_strategy2.Image = imageList_0.Images[0];
			}
			if (MenuType.selectedMesh5AxisType2 == CamTriangularMeshType.ParallelCuts)
			{
				btn_strategy2.Image = imageList_0.Images[1];
			}
			if (MenuType.selectedMesh5AxisType2 == CamTriangularMeshType.ConstantZ)
			{
				btn_strategy2.Image = imageList_0.Images[2];
			}
			if (MenuType.selectedMesh5AxisType2 == CamTriangularMeshType.None)
			{
				btn_strategy2.Image = imageList_0.Images[3];
			}
			btn_strategy2.Text = buLangTranslate.preDef.Cam + " : " + MenuType.selectedMesh5AxisType2;
		}
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
				if (!(control.Name == btn_strategy2.Name))
				{
					if (!(control.Name == btn_toolsettings.Name))
					{
						if (!(control.Name == btn_camsettings.Name))
						{
							if (!(control.Name == btn_camsettings2.Name))
							{
								PropertiesForm.Result = DialogResult.OK;
								if (!radioButton_2.Checked)
								{
									if (!radioButton_1.Checked)
									{
										if (radioButton_0.Checked)
										{
											MenuType.AxesNumber = 5;
										}
									}
									else
									{
										MenuType.AxesNumber = 4;
									}
								}
								else
								{
									MenuType.AxesNumber = 3;
								}
								if (control.Name == btn_contourmenufilelist.Name)
								{
									EngraveType = MarbleEngraveMenuType.FromList;
								}
								if (control.Name == btn_contourmenufromfile.Name)
								{
									EngraveType = MarbleEngraveMenuType.FromFile;
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
								okCommandWithFiveDataEventHandler_0("CamSetting", ItemType, MenuType.selectedTool, MenuType.selectedMeshType2, null);
							}
						}
						else if (okCommandWithFiveDataEventHandler_0 != null)
						{
							okCommandWithFiveDataEventHandler_0("CamSetting", ItemType, MenuType.selectedTool, MenuType.selectedMeshType, null);
						}
					}
					else if (okCommandWithFiveDataEventHandler_0 != null)
					{
						okCommandWithFiveDataEventHandler_0("ToolSetting", MenuType.selectedTool, null, null, null);
					}
				}
				else if ((MenuType.selectedTool == MarbleToolType.Milling) | (MenuType.selectedTool == MarbleToolType.MillingHead))
				{
					F_Marble5DCamStrategyMenu f_Marble5DCamStrategyMenu = new F_Marble5DCamStrategyMenu();
					f_Marble5DCamStrategyMenu.MeshType = MenuType.selectedMesh5AxisType2;
					f_Marble5DCamStrategyMenu.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
					f_Marble5DCamStrategyMenu.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
					f_Marble5DCamStrategyMenu.Init();
					f_Marble5DCamStrategyMenu.ShowDialog();
					if (f_Marble5DCamStrategyMenu.PropertiesForm.Result == DialogResult.OK)
					{
						MenuType.selectedMesh5AxisType2 = f_Marble5DCamStrategyMenu.MeshType;
						StrategyFromToolType(1);
					}
				}
			}
			else if ((MenuType.selectedTool == MarbleToolType.Milling) | (MenuType.selectedTool == MarbleToolType.MillingHead))
			{
				F_Marble5DCamStrategyMenu f_Marble5DCamStrategyMenu2 = new F_Marble5DCamStrategyMenu();
				f_Marble5DCamStrategyMenu2.MeshType = MenuType.selectedMesh5AxisType;
				f_Marble5DCamStrategyMenu2.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_Marble5DCamStrategyMenu2.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
				f_Marble5DCamStrategyMenu2.Init();
				f_Marble5DCamStrategyMenu2.ShowDialog();
				if (f_Marble5DCamStrategyMenu2.PropertiesForm.Result == DialogResult.OK)
				{
					MenuType.selectedMesh5AxisType = f_Marble5DCamStrategyMenu2.MeshType;
					StrategyFromToolType(0);
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
