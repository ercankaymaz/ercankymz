using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Drill;

public class clsDrillGoUltra2Up1Down : clsDrill
{
	public void cmdShowTools()
	{
		if (FrmTools == null)
		{
			FrmTools = new F_Tools();
		}
		FrmTools.fileNameLeftTools = AppPath.MachineSimConfig + "\\Tools\\GoUltraLeftToolGroups.step";
		FrmTools.fileNameRightTools = AppPath.MachineSimConfig + "\\Tools\\GoUltraRightToolGroups.step";
		FrmTools.fileNameBottomTools = AppPath.MachineSimConfig + "\\Tools\\GoUltraBottomToolGroups.step";
		CreateModelProperties createModelProperties = new CreateModelProperties();
		if (FrmTools.viewportLeft == null)
		{
			createModelProperties = new CreateModelProperties();
			createModelProperties.CoordinateSystemIconVisible = false;
			createModelProperties.OriginSymbolVisible = false;
			createModelProperties.ViewCubeIconVisible = false;
			createModelProperties.OrigineCaptionVisible = false;
			createModelProperties.ToolBorVisible = false;
			createModelProperties.BottomColor = Color.LightGray;
			createModelProperties.MiddleColor = Color.WhiteSmoke;
			createModelProperties.TopColor = Color.LightGray;
			createModelProperties.PanMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
			createModelProperties.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
			createModelProperties.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
			FrmTools.viewportLeft = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, createModelProperties);
			FrmTools.viewportLeft.Name = "viewportLeft";
			FrmTools.pnl_viewportleft.Controls.Add(FrmTools.viewportLeft);
		}
		if (FrmTools.viewportRight == null)
		{
			createModelProperties = new CreateModelProperties();
			createModelProperties.CoordinateSystemIconVisible = false;
			createModelProperties.OriginSymbolVisible = false;
			createModelProperties.ViewCubeIconVisible = false;
			createModelProperties.OrigineCaptionVisible = false;
			createModelProperties.ToolBorVisible = false;
			createModelProperties.BottomColor = Color.LightGray;
			createModelProperties.MiddleColor = Color.WhiteSmoke;
			createModelProperties.TopColor = Color.LightGray;
			createModelProperties.PanMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
			createModelProperties.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
			createModelProperties.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
			FrmTools.viewportRight = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, createModelProperties);
			FrmTools.viewportRight.Name = "viewportRight";
			FrmTools.pnl_viewportright.Controls.Add(FrmTools.viewportRight);
		}
		if (FrmTools.viewportBottom == null)
		{
			createModelProperties = new CreateModelProperties();
			createModelProperties.CoordinateSystemIconVisible = false;
			createModelProperties.OriginSymbolVisible = false;
			createModelProperties.ViewCubeIconVisible = false;
			createModelProperties.OrigineCaptionVisible = false;
			createModelProperties.ToolBorVisible = false;
			createModelProperties.BottomColor = Color.LightGray;
			createModelProperties.MiddleColor = Color.WhiteSmoke;
			createModelProperties.TopColor = Color.LightGray;
			createModelProperties.PanMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
			createModelProperties.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
			createModelProperties.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
			FrmTools.viewportBottom = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, createModelProperties);
			FrmTools.viewportBottom.Name = "viewportBottom";
			FrmTools.pnl_viewportbottom.Controls.Add(FrmTools.viewportBottom);
		}
		FrmTools.StartPosition = FormStartPosition.CenterParent;
		FrmTools.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		FrmTools.settingRuntime = new DrillRuntimeSettings(clsDrill.varDrillRunSettings);
		FrmTools.Init();
		FrmTools.ShowDialog();
		if (FrmTools.PropertiesForm.Result != DialogResult.OK)
		{
			return;
		}
		for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
		{
			if (clsDrill.ToolList[i].Data.No == 41)
			{
				clsDrill.toolBottom = new ToolBase5(clsDrill.ToolList[i]);
			}
		}
		clsDrill.varDrillRunSettings = new DrillRuntimeSettings(FrmTools.settingRuntime);
		SaveDrillFile();
		SaveToolConfigFile(clsDrill.fileNameToolSetting);
	}

	public bool CheckOperationsGoUltra2Top1BottomNoAtc(buShape Shape, ref List<string> Messages)
	{
		Messages.Clear();
		if (!clsInit.appDrill.EditOperation)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			for (int i = 0; i <= clsDrill.activeJob.Items.Count - 1; i++)
			{
				if (!buShape.isSame(clsDrill.activeJob.Items[i], Shape))
				{
					if ((clsDrill.activeJob.Items[i].ShapeGroup == ShapeGroup.Contour) & (Shape.ShapeGroup == ShapeGroup.Contour))
					{
						Messages.Add(buDrillCalc.LangDrillMessage[62]);
						i = clsDrill.activeJob.Items.Count;
					}
				}
				else
				{
					Messages.Add(buDrillCalc.LangDrillMessage[61]);
					i = clsDrill.activeJob.Items.Count;
				}
			}
			if (Shape is buShapeHole)
			{
				buShapeHole buShapeHole4 = Shape as buShapeHole;
				if (((Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back)) && buShapeHole4.isMilling)
				{
					Messages.Add(buDrillCalc.LangDrillMessage[59]);
				}
				if ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back))
				{
					if (buShapeHole4.BasePoint.X < 0.0)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[49]);
						flag = true;
					}
					if (buShapeHole4.BasePoint.X > clsDrill.activeJob.Material.Size.Width)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[50]);
						flag = true;
					}
				}
				if ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom) | (Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right))
				{
					if (Shape.BasePoint.Y < 0.0)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[45]);
						flag2 = true;
					}
					if (Shape.BasePoint.Y > clsDrill.activeJob.Material.Size.Height)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[46]);
						flag2 = true;
					}
				}
				if ((Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back))
				{
					if (buShapeHole4.BasePoint.Z < 0.0)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[56]);
						flag3 = true;
					}
					if (buShapeHole4.BasePoint.Z > clsDrill.activeJob.Material.Size.Depth)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[57]);
						flag3 = true;
					}
				}
				if (buShapeHole4.planeName == planeBoxNames.Top && (buShapeHole4.isMilling & (buShapeHole4.Diameter != clsDrill.toolTop.Geometry.Diameter)))
				{
					Messages.Add(buDrillCalc.LangDrillMessage[53]);
				}
				if (buShapeHole4.planeName == planeBoxNames.Bottom && (buShapeHole4.isMilling & (buShapeHole4.Diameter != clsDrill.toolBottom.Geometry.Diameter)))
				{
					Messages.Add(buDrillCalc.LangDrillMessage[53]);
				}
				if (buShapeHole4.multiCenter != null && buShapeHole4.multiCenter.Count > 0)
				{
					for (int j = 0; j <= buShapeHole4.multiCenter.Count - 1; j++)
					{
						if (!flag && ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back)))
						{
							if (0.0 - buShapeHole4.multiCenter[j].Center.X < 0.0)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[49]);
								flag = true;
							}
							if (0.0 - buShapeHole4.multiCenter[j].Center.X > clsDrill.activeJob.Material.Size.Width)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[50]);
								flag = true;
							}
						}
						if (!flag2 && ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom) | (Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right)))
						{
							if (0.0 - buShapeHole4.multiCenter[j].Center.Y < 0.0)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[45]);
								flag2 = true;
							}
							if (0.0 - buShapeHole4.multiCenter[j].Center.Y > clsDrill.activeJob.Material.Size.Height)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[46]);
								flag2 = true;
							}
						}
						if (!flag3 && ((Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back)))
						{
							if (buShapeHole4.multiCenter[j].Center.Z < 0.0)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[56]);
								flag3 = true;
							}
							if (buShapeHole4.multiCenter[j].Center.Z > clsDrill.activeJob.Material.Size.Depth)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[57]);
								flag3 = true;
							}
						}
					}
				}
				if (Shape is buShapeHole3)
				{
					for (int k = 0; k <= buShapeHole4.entitiesShape.Count - 1; k++)
					{
						if (!(buShapeHole4.entitiesShape[k] is buCircle))
						{
							continue;
						}
						buCircle buCircle2 = buShapeHole4.entitiesShape[k] as buCircle;
						if (!flag && ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back)))
						{
							if (0.0 - buCircle2.Center.X < 0.0)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[49]);
								flag = true;
							}
							if (0.0 - buCircle2.Center.X > clsDrill.activeJob.Material.Size.Width)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[50]);
								flag = true;
							}
						}
						if (!flag2 && ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom) | (Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right)))
						{
							if (0.0 - buCircle2.Center.Y < 0.0)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[45]);
								flag2 = true;
							}
							if (0.0 - buCircle2.Center.Y > clsDrill.activeJob.Material.Size.Height)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[46]);
								flag2 = true;
							}
						}
						if (!flag3 && ((Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back)))
						{
							if (buCircle2.Center.Z < 0.0)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[56]);
								flag3 = true;
							}
							if (buCircle2.Center.Z > clsDrill.activeJob.Material.Size.Depth)
							{
								Messages.Add(buDrillCalc.LangDrillMessage[57]);
								flag3 = true;
							}
						}
					}
				}
			}
			if (Shape is buShapeCut)
			{
				buShapeCut buShapeCut2 = Shape as buShapeCut;
				if (buShapeCut2.BasePoint.X < -100.0)
				{
					Messages.Add(buDrillCalc.LangDrillMessage[43]);
				}
				if (buShapeCut2.BasePoint.X + buShapeCut2.Length > clsDrill.activeJob.Material.Size.Width + 100.0)
				{
					Messages.Add(buDrillCalc.LangDrillMessage[44]);
				}
				if (Shape.BasePoint.Y < 0.0)
				{
					Messages.Add(buDrillCalc.LangDrillMessage[45]);
				}
				if (Shape.BasePoint.Y > clsDrill.activeJob.Material.Size.Height)
				{
					Messages.Add(buDrillCalc.LangDrillMessage[46]);
				}
				if ((buShapeCut2.planeName == planeBoxNames.Back) | (buShapeCut2.planeName == planeBoxNames.Front) | (buShapeCut2.planeName == planeBoxNames.Left) | (buShapeCut2.planeName == planeBoxNames.Right))
				{
					Messages.Add(buDrillCalc.LangDrillMessage[51]);
				}
				if (buShapeCut2.planeName == planeBoxNames.Bottom && !buShapeCut2.isMilling)
				{
					Messages.Add(buDrillCalc.LangDrillMessage[52]);
				}
				if (buShapeCut2.planeName == planeBoxNames.Top)
				{
					if (buShapeCut2.isMilling & (buShapeCut2.Diameter != clsDrill.toolTop.Geometry.Diameter))
					{
						Messages.Add(buDrillCalc.LangDrillMessage[54]);
					}
					if (!buShapeCut2.isMilling & (buShapeCut2.Diameter != clsDrill.toolSlotY1.Geometry.CutLength) & (buShapeCut2.Diameter != clsDrill.toolSlotY2.Geometry.CutLength))
					{
						Messages.Add(buDrillCalc.LangDrillMessage[55]);
					}
				}
				if (buShapeCut2.planeName == planeBoxNames.Bottom && (buShapeCut2.isMilling & (buShapeCut2.Diameter != clsDrill.toolBottom.Geometry.Diameter)))
				{
					Messages.Add(buDrillCalc.LangDrillMessage[54]);
				}
			}
			if (Shape != null && Shape.ShapeGroup == ShapeGroup.Shape)
			{
				if (clsDrill.activeJob.Material.Size.Width > clsDrill.varDrillMachineSettings.MachineMillingStandartXMaxLimit)
				{
					Messages.Add(buDrillCalc.LangDrillMessage[60]);
				}
				if ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back))
				{
					if (Shape.BasePoint.X < 0.0)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[49]);
						flag = true;
					}
					if (Shape.BasePoint.X > clsDrill.activeJob.Material.Size.Width)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[50]);
						flag = true;
					}
				}
				if ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom) | (Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right))
				{
					if (Shape.BasePoint.Y < 0.0)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[45]);
						flag2 = true;
					}
					if (Shape.BasePoint.Y > clsDrill.activeJob.Material.Size.Height)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[46]);
						flag2 = true;
					}
				}
				if ((Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back))
				{
					if (Shape.BasePoint.Z < 0.0)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[56]);
						flag3 = true;
					}
					if (Shape.BasePoint.Z > clsDrill.activeJob.Material.Size.Depth)
					{
						Messages.Add(buDrillCalc.LangDrillMessage[57]);
						flag3 = true;
					}
				}
				if ((Shape.planeName == planeBoxNames.Back) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right))
				{
					Messages.Add(buDrillCalc.LangDrillMessage[51]);
				}
			}
			if (Messages.Count <= 0)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public void CreatCodeFromMove(List<DrillMove> Moves, ref List<string> SL)
	{
		SL.Clear();
		bool flag = false;
		for (int i = 0; i <= Moves.Count - 1; i++)
		{
			string text = "";
			text = clsInit.cDrill.MoveCommandToString(Moves[i].Command);
			if ((Moves[i].Command == DrillMoveCommand.ResetPiston) | (Moves[i].Command == DrillMoveCommand.SetPiston))
			{
				string text2 = clsInit.cDrill.DrillMoveToolsToString(Moves[i]);
				text = text + " [ " + text2 + " ] ";
			}
			if (Moves[i].Command == DrillMoveCommand.AxisMove)
			{
				_ = Moves[i].Command.ToString() + " - ";
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				string text7 = "";
				string text8 = "";
				string text9 = "";
				string text10 = "";
				string text11 = "";
				string text12 = "";
				if (Moves[i].XPosition != NoMove)
				{
					text3 = " X: " + Moves[i].XPosition.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal);
					if (flag && buCompare5.EQ(Moves[i].XPosition, Moves[i - 1].XPosition))
					{
						text3 = "";
					}
				}
				if (Moves[i].X1Clamper != NoMove)
				{
					text4 = " X1: " + Moves[i].X1Clamper.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal);
					if (flag && buCompare5.EQ(Moves[i].X1Clamper, Moves[i - 1].X1Clamper))
					{
						text4 = "";
					}
				}
				if (Moves[i].X2Clamper != NoMove)
				{
					text5 = " X2: " + Moves[i].X2Clamper.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal);
					if (flag && buCompare5.EQ(Moves[i].X2Clamper, Moves[i - 1].X2Clamper))
					{
						text5 = "";
					}
				}
				if (Moves[i].Y1Position != NoMove)
				{
					text6 = " Y1: " + Moves[i].Y1Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal);
					if (flag && buCompare5.EQ(Moves[i].Y1Position, Moves[i - 1].Y1Position))
					{
						text6 = "";
					}
				}
				if (Moves[i].Y2Position != NoMove)
				{
					text7 = " Y2: " + Moves[i].Y2Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal);
					if (flag && buCompare5.EQ(Moves[i].Y2Position, Moves[i - 1].Y2Position))
					{
						text7 = "";
					}
				}
				if (Moves[i].Y3Position != NoMove)
				{
					text8 = " Y3: " + Moves[i].Y3Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal);
					if (flag && buCompare5.EQ(Moves[i].Y3Position, Moves[i - 1].Y3Position))
					{
						text8 = "";
					}
				}
				if (Moves[i].Z1Position != NoMove)
				{
					text9 = " Z1: " + Moves[i].Z1Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal);
					if (flag && buCompare5.EQ(Moves[i].Z1Position, Moves[i - 1].Z1Position))
					{
						text9 = "";
					}
				}
				if (Moves[i].Z2Position != NoMove)
				{
					text10 = " Z2: " + Moves[i].Z2Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal);
					if (flag && buCompare5.EQ(Moves[i].Z2Position, Moves[i - 1].Z2Position))
					{
						text10 = "";
					}
				}
				if (Moves[i].Z3Position != NoMove)
				{
					text11 = " Z3: " + Moves[i].Z3Position.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal);
					if (flag && buCompare5.EQ(Moves[i].Z3Position, Moves[i - 1].Z3Position))
					{
						text11 = "";
					}
				}
				if (Moves[i].SPosition != NoMove)
				{
					text12 = " S: " + Moves[i].SPosition.ToString("f" + clsDrill.varDrillSettings.CodeLineDecimal);
					if (flag && buCompare5.EQ(Moves[i].SPosition, Moves[i - 1].SPosition))
					{
						text12 = "";
					}
				}
				text = text + " -" + text3 + text4 + text5 + text6 + text7 + text8 + text9 + text10 + text11 + text12;
				string text13 = "";
				if (Moves[i].Command2 != DrillMoveCommand.None)
				{
					text13 = clsInit.cDrill.MoveCommandToString(Moves[i].Command2);
					text = text + " - " + text13;
					if ((Moves[i].Command2 == DrillMoveCommand.SetPiston) | (Moves[i].Command2 == DrillMoveCommand.ResetPiston))
					{
						string text14 = clsInit.cDrill.DrillMoveToolsToString(Moves[i]);
						text = text + " [ " + text14 + " ]";
					}
				}
				flag = true;
			}
			SL.Add(text);
		}
	}

	public void CreatCodeFromJobItem(ref DrillJob Job, bool IgnoreErrors = false)
	{
		DrillMove drillMove = null;
		double X = 0.0;
		double X2 = 0.0;
		double MaterialZeroYPos = 0.0;
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		List<DrillCalcItem> list2 = new List<DrillCalcItem>();
		List<DrillCalcItem> list3 = new List<DrillCalcItem>();
		List<DrillCalcItem> list4 = new List<DrillCalcItem>();
		List<DrillItem> list5 = new List<DrillItem>();
		List<DrillItem> itemDrillShape = new List<DrillItem>();
		List<DrillItem> itemSlotShape = new List<DrillItem>();
		ItemSplited = new List<List<DrillCalcItem>>();
		List<DrillCalcItem> list6 = new List<DrillCalcItem>();
		List<List<DrillCalcItem>> list7 = new List<List<DrillCalcItem>>();
		clsInit.appDrill.GetItemsFromDrillTypes(ref Job);
		for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
		{
			if (clsDrill.ToolList[i].Data.No == 85)
			{
				clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[i]);
			}
			if (clsDrill.ToolList[i].Data.No == 185)
			{
				clsDrill.toolSlotY2 = new ToolBase5(clsDrill.ToolList[i]);
			}
		}
		FindFirstClamperPositions(Job, ref MaterialZeroYPos, ref X, ref X2);
		bool flag = false;
		if (Job.FirstClamperX < 0.0 - Job.Material.Size.Width && ((0.0 - Job.Material.Size.Width < Job.SecondClamperX) & (Job.SecondClamperX < 0.0)))
		{
			flag = true;
		}
		if (flag)
		{
			X = Job.FirstClamperX;
			X2 = Job.SecondClamperX;
			Job.isSingleClamper = true;
		}
		else if ((Job.isClamperSideDrillOpAvailable & (Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperSingleLimit)) || flag)
		{
			double X1Pos = 0.0;
			double X2Pos = 0.0;
			Job.isSingleClamper = clsInit.cDrill.isSingleClamperAvailable(Job, clsDrill.varDrillCNCSettings, ref X1Pos, ref X2Pos);
			if (Job.isSingleClamper)
			{
				X = X1Pos;
				X2 = X2Pos;
			}
		}
		if ((Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperSingleMustLimit) & !Job.isSingleClamper)
		{
			double X1Pos2 = 0.0;
			double X2Pos2 = 0.0;
			Job.isSingleClamper = clsInit.cDrill.SingleMustClamper(Job, clsDrill.varDrillCNCSettings, ref X1Pos2, ref X2Pos2);
			if (Job.isSingleClamper)
			{
				X = X1Pos2;
				X2 = X2Pos2;
			}
			if (Job.isClamperSideDrillOpAvailable)
			{
				calcErrorList.Add(buDrillCalc.LangDrillMessage[66]);
			}
		}
		for (int j = 0; j <= Job.ItemShape.Count - 1; j++)
		{
			list5.Add(new DrillItem(Job.ItemShape[j]));
		}
		for (int k = 0; k <= Job.ItemCalc.Count - 1; k++)
		{
			if (Job.ItemCalc[k].Enable & (Job.ItemCalc[k].Type == DrillItemType.Drill))
			{
				if (Job.ItemCalc[k].planeName == planeBoxNames.Left)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[k]));
				}
				if (Job.ItemCalc[k].planeName == planeBoxNames.Right)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[k]));
				}
				if (Job.ItemCalc[k].planeName == planeBoxNames.Back)
				{
					list.Add(new DrillCalcItem(Job.ItemCalc[k]));
				}
				if (Job.ItemCalc[k].planeName == planeBoxNames.Front)
				{
					list2.Add(new DrillCalcItem(Job.ItemCalc[k]));
				}
				if (Job.ItemCalc[k].planeName == planeBoxNames.Top)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[k]));
				}
				if (Job.ItemCalc[k].planeName == planeBoxNames.Bottom)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[k]));
				}
			}
			if (Job.ItemCalc[k].Enable & (Job.ItemCalc[k].Type == DrillItemType.Slot))
			{
				list4.Add(new DrillCalcItem(Job.ItemCalc[k]));
			}
		}
		list3 = SortByXDistance(list3, new DrillCalcItem(), SortDirection.LowerToBigger);
		ItemSplited = new List<List<DrillCalcItem>>();
		list6 = new List<DrillCalcItem>();
		List<DrillCalcItem> list8 = new List<DrillCalcItem>();
		List<DrillCalcItem> list9 = new List<DrillCalcItem>();
		List<DrillCalcItem> list10 = new List<DrillCalcItem>();
		List<DrillCalcItem> list11 = new List<DrillCalcItem>();
		List<DrillCalcItem> list12 = new List<DrillCalcItem>();
		for (int l = 0; l <= list3.Count - 1; l++)
		{
			if (list6.Count != 0)
			{
				bool flag2 = false;
				if (buCompare5.EQ(list6[list6.Count - 1].Center.X, list3[l].Center.X, 0.01))
				{
					flag2 = true;
				}
				if (!flag2)
				{
					List<DrillCalcItem> list13 = new List<DrillCalcItem>();
					for (int m = 0; m <= list9.Count - 1; m++)
					{
						list13.Add(list9[m]);
					}
					for (int n = 0; n <= list10.Count - 1; n++)
					{
						list13.Add(list10[n]);
					}
					for (int num = 0; num <= list8.Count - 1; num++)
					{
						list13.Add(list8[num]);
					}
					for (int num2 = 0; num2 <= list11.Count - 1; num2++)
					{
						list13.Add(list11[num2]);
					}
					for (int num3 = 0; num3 <= list12.Count - 1; num3++)
					{
						list13.Add(list12[num3]);
					}
					ItemSplited.Add(list13);
					list6 = new List<DrillCalcItem>();
					list6.Add(list3[l]);
					list8 = new List<DrillCalcItem>();
					list9 = new List<DrillCalcItem>();
					list10 = new List<DrillCalcItem>();
					list11 = new List<DrillCalcItem>();
					list12 = new List<DrillCalcItem>();
				}
				else
				{
					list6.Add(list3[l]);
				}
			}
			else
			{
				list6.Add(new DrillCalcItem(list3[l]));
			}
			if (list3[l].planeName == planeBoxNames.Back)
			{
				list12.Add(new DrillCalcItem(list3[l]));
			}
			if (list3[l].planeName == planeBoxNames.Front)
			{
				list11.Add(new DrillCalcItem(list3[l]));
			}
			if (list3[l].planeName == planeBoxNames.Top)
			{
				list9.Add(new DrillCalcItem(list3[l]));
			}
			if (list3[l].planeName == planeBoxNames.Bottom)
			{
				list10.Add(new DrillCalcItem(list3[l]));
			}
			if ((list3[l].planeName == planeBoxNames.Left) | (list3[l].planeName == planeBoxNames.Right))
			{
				list8.Add(new DrillCalcItem(list3[l]));
			}
		}
		if (list6.Count > 0)
		{
			List<DrillCalcItem> list14 = new List<DrillCalcItem>();
			for (int num4 = 0; num4 <= list9.Count - 1; num4++)
			{
				list14.Add(list9[num4]);
			}
			for (int num5 = 0; num5 <= list10.Count - 1; num5++)
			{
				list14.Add(list10[num5]);
			}
			for (int num6 = 0; num6 <= list8.Count - 1; num6++)
			{
				list14.Add(list8[num6]);
			}
			for (int num7 = 0; num7 <= list11.Count - 1; num7++)
			{
				list14.Add(list11[num7]);
			}
			for (int num8 = 0; num8 <= list12.Count - 1; num8++)
			{
				list14.Add(list12[num8]);
			}
			ItemSplited.Add(list14);
		}
		drillMove = new DrillMove(clsDrill.varDrillCNCSettings.ParkX1, clsDrill.varDrillCNCSettings.ParkX2, clsDrill.varDrillCNCSettings.ParkY1, clsDrill.varDrillCNCSettings.ParkY2, clsDrill.varDrillCNCSettings.ParkY3, clsDrill.varDrillCNCSettings.ParkZ1, clsDrill.varDrillCNCSettings.ParkZ2, clsDrill.varDrillCNCSettings.ParkZ3, DrillMoveCommand.AxisMove, 0.0);
		Job.Moves.Add(drillMove);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AllClamperUp, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, clsDrill.varDrillCNCSettings.Z2SafeDistance, clsDrill.varDrillCNCSettings.Z3SafeDistance, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetAll, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(X, X2, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, MaterialZeroYPos, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z2SupportDistance, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Wait, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AllClamperDown, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.XAxesGantyOn, drillPlaneNames.Top, NoMove, ref Job);
		SplitedItems = new DrillSplitedItems();
		if (list2.Count > 0)
		{
			list7 = new List<List<DrillCalcItem>>();
			list2 = SortByYDistance(list2, new DrillCalcItem(), SortDirection.LowerToBigger);
			SplitItemsByDepth(list2, ref list7);
			for (int num9 = 0; num9 <= list7.Count - 1; num9++)
			{
				if (list7[num9].Count > 0)
				{
					List<DrillCalcItem> CopiedItem = new List<DrillCalcItem>();
					DrillCalcItem.Copy(list7[num9], ref CopiedItem);
					SplitedItems.lstFront.Add(CopiedItem);
				}
			}
		}
		for (int num10 = 0; num10 <= ItemSplited.Count - 1; num10++)
		{
			List<DrillCalcItem> list15 = new List<DrillCalcItem>();
			List<DrillCalcItem> list16 = new List<DrillCalcItem>();
			List<DrillCalcItem> list17 = new List<DrillCalcItem>();
			ItemSplited[num10] = SortByYDistance(ItemSplited[num10], new DrillCalcItem(), SortDirection.LowerToBigger);
			for (int num11 = 0; num11 <= ItemSplited[num10].Count - 1; num11++)
			{
				if (ItemSplited[num10][num11].planeName == planeBoxNames.Top)
				{
					list15.Add(new DrillCalcItem(ItemSplited[num10][num11]));
				}
				if (ItemSplited[num10][num11].planeName == planeBoxNames.Bottom)
				{
					list16.Add(new DrillCalcItem(ItemSplited[num10][num11]));
				}
				if ((ItemSplited[num10][num11].planeName == planeBoxNames.Right) | (ItemSplited[num10][num11].planeName == planeBoxNames.Left))
				{
					list17.Add(new DrillCalcItem(ItemSplited[num10][num11]));
				}
			}
			if (list15.Count > 0)
			{
				SplitedItems.lstTop.Add(list15);
			}
			if (list16.Count > 0)
			{
				SplitedItems.lstBottom.Add(list16);
			}
			if (list17.Count > 0)
			{
				SplitedItems.lstLeftRight.Add(list17);
			}
		}
		if (list.Count > 0)
		{
			list7 = new List<List<DrillCalcItem>>();
			list = SortByYDistance(list, new DrillCalcItem(), SortDirection.LowerToBigger);
			SplitItemsByDepth(list, ref list7);
			for (int num12 = 0; num12 <= list7.Count - 1; num12++)
			{
				if (list7[num12].Count > 0)
				{
					List<DrillCalcItem> CopiedItem2 = new List<DrillCalcItem>();
					DrillCalcItem.Copy(list7[num12], ref CopiedItem2);
					SplitedItems.lstBack.Add(CopiedItem2);
				}
			}
		}
		calcErrorList.Clear();
		FoundDrills.Clear();
		ClearCalculatedThings();
		FindHolesForFrontSide();
		FindHolesForTopSide();
		FindHolesForBottomSide();
		FindHolesForLeftRightSide();
		FindHolesForBackSide();
		AssingToolOffset();
		for (int num13 = 0; num13 <= FoundDrills.Count - 2; num13++)
		{
			if (buCompare5.EQ(FoundDrills[num13].Items[0].OffsetedPoint.X, FoundDrills[num13 + 1].Items[0].OffsetedPoint.X, 0.01))
			{
				FoundDrills[num13 + 1].Items[0].OffsetedPoint.X = FoundDrills[num13].Items[0].OffsetedPoint.X + 1E-05;
			}
		}
		FoundDrills = SortByXOffsetedDistanceDrillFound(FoundDrills, new DrillCalcItem(), SortDirection.LowerToBigger);
		if (clsDrill.varDrillCNCSettings.BackOperationsAlwaysWillLastOperation)
		{
			MoveBackOperationToLast();
		}
		CreateCodes(ref Job);
		for (int num14 = 0; num14 <= FoundDrills.Count - 1; num14++)
		{
			for (int num15 = 0; num15 <= FoundDrills[num14].Items.Count - 1; num15++)
			{
				SetAsCalculatedDrillItemByID(FoundDrills[num14].Items[num15].ID, ref Job.ItemCalc);
			}
		}
		for (int num16 = Job.ItemCalc.Count - 1; num16 >= 0; num16--)
		{
			if (Job.ItemCalc[num16].Type == DrillItemType.Drill)
			{
				if (Job.ItemCalc[num16].Enable)
				{
					if (!Job.ItemCalc[num16].Calculated)
					{
						calcErrorList.Add("Not Calculated | " + Job.ItemCalc[num16].planeName.ToString() + " - Diameter: " + Job.ItemCalc[num16].Diameter.ToString("f2") + " - Center (" + Job.ItemCalc[num16].Center.ToString() + ")");
					}
				}
				else
				{
					calcErrorList.Add("Disabled | " + Job.ItemCalc[num16].planeName.ToString() + " - Diameter: " + Job.ItemCalc[num16].Diameter.ToString("f2") + " - Center (" + Job.ItemCalc[num16].Center.ToString() + ")");
				}
			}
		}
		if (list4.Count > 0)
		{
			list4 = SortByYDistance(list4, new DrillCalcItem(), SortDirection.LowerToBigger);
			List<DrillCalcItem> ItemSlot = new List<DrillCalcItem>();
			if (list4.Count != 1)
			{
				for (int num17 = 0; num17 <= list4.Count - 1; num17++)
				{
					if (!list4[num17].Calculated)
					{
						DrillCalcItem drillCalcItem = list4[num17];
						ItemSlot.Add(drillCalcItem);
						for (int num18 = num17 + 1; num18 <= list4.Count - 1; num18++)
						{
							if (!list4[num18].Calculated)
							{
								DrillCalcItem drillCalcItem2 = list4[num18];
								double num19 = drillCalcItem.Center.Y - clsDrill.toolSlotY2.Positions.CommonOffset.Y;
								double num20 = drillCalcItem2.Center.Y - clsDrill.toolSlotY1.Positions.CommonOffset.Y;
								double num21 = num20 - num19;
								if (num21 > clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
								{
									ItemSlot.Add(drillCalcItem2);
								}
							}
							if (ItemSlot.Count >= 2)
							{
								num18 = list4.Count;
							}
						}
					}
					if (ItemSlot.Count > 0)
					{
						CreateCodeForSlotTopSide(ref Job, ref ItemSlot);
						for (int num22 = 0; num22 <= ItemSlot.Count - 1; num22++)
						{
							ItemSlot[num22].Calculated = true;
						}
					}
					ItemSlot.Clear();
				}
			}
			else
			{
				CreateCodeForSlotTopSide(ref Job, ref list4);
			}
			double num23 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			double num24 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			double num25 = 0.0;
			if (num23 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
			{
				double num26 = clsDrill.varDrillMachineSettings.MachineMinXStroke - num23;
				num23 += num26;
				num24 += num26;
				num25 += num26;
			}
			AddDrillMove(num23, num24, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, num25, ref Job);
		}
		CreatCodeFromJobShapeContour(ref Job);
		CreatCodeFromJobShapeItem(ref Job, Job.ItemShape, itemDrillShape, itemSlotShape);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.Finished, drillPlaneNames.Top, NoMove, ref Job);
		CreatCodeFromMove(Job.Moves, ref Job.Codes);
		Job.TotalSec = 0.0;
		doCalculateTime(ref Job.TotalSec);
		if (calcErrorList.Count > 0 && !IgnoreErrors)
		{
			DialogBoxList dialogBoxList = new DialogBoxList();
			dialogBoxList.Caption = "No Tool Available for These Holes";
			dialogBoxList.Width = 500;
			for (int num27 = 0; num27 <= calcErrorList.Count - 1; num27++)
			{
				dialogBoxList.Items.Add(calcErrorList[num27]);
			}
			dialogBoxList.Init();
			dialogBoxList.ShowDialog();
		}
	}

	public void CreatCodeFromJobItem1(ref DrillJob Job, bool IgnoreErrors = false)
	{
		DrillMove drillMove = null;
		double X = 0.0;
		double X2 = 0.0;
		double MaterialZeroYPos = 0.0;
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		List<DrillCalcItem> list2 = new List<DrillCalcItem>();
		List<DrillCalcItem> list3 = new List<DrillCalcItem>();
		List<DrillCalcItem> list4 = new List<DrillCalcItem>();
		List<DrillItem> list5 = new List<DrillItem>();
		List<DrillItem> list6 = new List<DrillItem>();
		List<DrillItem> list7 = new List<DrillItem>();
		ItemSplited = new List<List<DrillCalcItem>>();
		List<DrillCalcItem> list8 = new List<DrillCalcItem>();
		List<List<DrillCalcItem>> list9 = new List<List<DrillCalcItem>>();
		Job.ErrorCodes = new List<string>();
		for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
		{
			if (clsDrill.ToolList[i].Data.No == 85)
			{
				clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[i]);
			}
			if (clsDrill.ToolList[i].Data.No == 185)
			{
				clsDrill.toolSlotY2 = new ToolBase5(clsDrill.ToolList[i]);
			}
		}
		Job.isClamperSideDrillOpAvailable = false;
		Job.isClamperSideSlotOpAvailable = false;
		Job.isClamperSideMillingOpAvailable = false;
		Job.ItemCalc.Clear();
		for (int j = 0; j <= Job.Items.Count - 1; j++)
		{
			if (Job.Items[j] is buShapeHole)
			{
				buShapeHole buShapeHole4 = Job.Items[j] as buShapeHole;
				if (buShapeHole4.Enable)
				{
					if (buShapeHole4.planeName == planeBoxNames.Back)
					{
						Job.isClamperSideDrillOpAvailable = true;
					}
					if (buShapeHole4.DrillType == drillTypes.SingleHole)
					{
						if (buShapeHole4.isMilling)
						{
							list6.Add(new DrillItem((buShapeHole)Job.Items[j]));
						}
						else
						{
							Job.ItemCalc.Add(new DrillCalcItem(buShapeHole4));
							Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
							if (Job.Items[j].BasePoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
							{
								Job.isClamperSideDrillOpAvailable = true;
							}
							IDCounter++;
						}
					}
					if ((buShapeHole4.DrillType == drillTypes.HorizontalHoles) | (buShapeHole4.DrillType == drillTypes.HorizontalLineHoles) | (buShapeHole4.DrillType == drillTypes.VerticalHoles) | (buShapeHole4.DrillType == drillTypes.VerticalLineHoles) | (buShapeHole4.DrillType == drillTypes.InclineHoles))
					{
						if (buShapeHole4.isMilling)
						{
							for (int k = 0; k <= buShapeHole4.multiCenter.Count - 1; k++)
							{
								buShapeHole buShapeHole5 = new buShapeHole(buShapeHole4.Diameter, buShapeHole4.Depth);
								buShapeHole5.CalculatedPoint = new Point3D(buShapeHole4.multiCenter[k].Center.X, buShapeHole4.multiCenter[k].Center.Y, buShapeHole4.multiCenter[k].Center.Z);
								buShapeHole5.ItemSize.MinBox = new Point3D(buShapeHole4.multiCenter[k].Center.X - buShapeHole4.Diameter / 2.0, buShapeHole4.multiCenter[k].Center.Y - buShapeHole4.Diameter / 2.0);
								buShapeHole5.ItemSize.MaxBox = new Point3D(buShapeHole4.multiCenter[k].Center.X + buShapeHole4.Diameter / 2.0, buShapeHole4.multiCenter[k].Center.Y + buShapeHole4.Diameter / 2.0);
								buShapeHole5.planeName = buShapeHole4.planeName;
								list6.Add(new DrillItem(buShapeHole5));
							}
						}
						else
						{
							for (int l = 0; l <= buShapeHole4.multiCenter.Count - 1; l++)
							{
								buShapeHole buShapeHole6 = new buShapeHole(buShapeHole4.Diameter, buShapeHole4.Depth);
								buShapeHole6.CalculatedPoint = new Point3D(buShapeHole4.multiCenter[l].Center.X, buShapeHole4.multiCenter[l].Center.Y, buShapeHole4.multiCenter[l].Center.Z);
								buShapeHole6.planeName = buShapeHole4.planeName;
								buShapeHole6.ID = IDCounter;
								Job.ItemCalc.Add(new DrillCalcItem(buShapeHole6));
								Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
								if (Math.Abs(buShapeHole4.multiCenter[l].Center.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
								{
									Job.isClamperSideDrillOpAvailable = true;
								}
								IDCounter++;
							}
						}
					}
					if (buShapeHole4.DrillType == drillTypes.ThreeHole)
					{
						buShapeHole3 buShapeHole7 = Job.Items[j] as buShapeHole3;
						Point3D calcCenter = new Point3D();
						Point3D calcCenter2 = new Point3D();
						clsInit.cVector5.calcBuShapeHole3Point(buShapeHole7.CalculatedPoint, buShapeHole7.planeName, buShapeHole7.DistanceX, buShapeHole7.DistanceY, buShapeHole7.DiameterOutside, buShapeHole7.Hole3Angle, ref calcCenter, ref calcCenter2);
						buShapeHole buShapeHole8 = new buShapeHole(buShapeHole7.Diameter, buShapeHole7.Depth);
						buShapeHole8.CalculatedPoint = new Point3D(buShapeHole4.CalculatedPoint.X, buShapeHole4.CalculatedPoint.Y, buShapeHole4.CalculatedPoint.Z);
						buShapeHole8.planeName = buShapeHole4.planeName;
						buShapeHole8.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole8));
						Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
						IDCounter++;
						if (Math.Abs(buShapeHole8.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
						{
							Job.isClamperSideDrillOpAvailable = true;
						}
						buShapeHole8 = new buShapeHole(buShapeHole7.DiameterOutside, buShapeHole7.Depth);
						buShapeHole8.CalculatedPoint = new Point3D(calcCenter.X, calcCenter.Y, calcCenter.Z);
						buShapeHole8.planeName = buShapeHole4.planeName;
						buShapeHole8.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole8));
						Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
						IDCounter++;
						if (Math.Abs(buShapeHole8.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
						{
							Job.isClamperSideDrillOpAvailable = true;
						}
						buShapeHole8 = new buShapeHole(buShapeHole7.DiameterOutside, buShapeHole7.Depth);
						buShapeHole8.CalculatedPoint = new Point3D(calcCenter2.X, calcCenter2.Y, calcCenter.Z);
						buShapeHole8.planeName = buShapeHole4.planeName;
						buShapeHole8.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole8));
						Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
						IDCounter++;
						if (Math.Abs(buShapeHole8.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
						{
							Job.isClamperSideDrillOpAvailable = true;
						}
					}
				}
			}
			if ((Job.Items[j] is buShapeCut) & Job.Items[j].Enable)
			{
				buShapeCut buShapeCut2 = Job.Items[j] as buShapeCut;
				if (!(((buShapeCut2.CutType == CutTypes.CutHorizontal) | (buShapeCut2.CutType == CutTypes.CutHorizontalLine)) & !buShapeCut2.isMilling))
				{
					if (!((buShapeCut2.CutType == CutTypes.CutVertical) | (buShapeCut2.CutType == CutTypes.CutVerticalLine) | (buShapeCut2.CutType == CutTypes.CutFree)))
					{
						DrillItem drillItem = new DrillItem((buShapeCut)Job.Items[j]);
						if (!(0.0 - buShapeCut2.CalculatedPoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + buShapeCut2.Diameter / 2.0))
						{
							list7.Add(new DrillItem((buShapeCut)Job.Items[j]));
						}
						else if (!(buShapeCut2.Length < Job.Material.Size.Width * 0.25))
						{
							List<Point3D> list10 = new List<Point3D>();
							List<Point3D> PointsDevided = new List<Point3D>();
							list10.Add(buVector5.ToPoint3D(drillItem.camEntities[0][0].StartPoint));
							list10.Add(buVector5.ToPoint3D(drillItem.camEntities[0][0].EndPoint));
							double num = 6.0;
							if (clsDrill.activeJob.Material.Size.Width > 1000.0)
							{
								num = 8.0;
							}
							if (clsDrill.activeJob.Material.Size.Width > 2000.0)
							{
								num = 12.0;
							}
							clsInit.cVector5.DevidePointsByLength(list10, buShapeCut2.Length / num, ref PointsDevided);
							if (PointsDevided.Count > 0)
							{
								drillItem.camEntities[0].Clear();
								DrillItem drillItem2 = new DrillItem(drillItem);
								drillItem2.camEntities = new List<List<buEntity>>();
								List<buEntity> list11 = new List<buEntity>();
								buLine item = new buLine(PointsDevided[0], PointsDevided[1]);
								list11.Add(item);
								clsInit.cVector5.BoxSizeCalculate(list11, ref drillItem2.BoxMinOfDrawing, ref drillItem2.BoxMaxOfDrawing);
								drillItem2.BoxMinItem = new Point3D(0.0 - drillItem2.BoxMaxOfDrawing.X, 0.0 - drillItem2.BoxMaxOfDrawing.Y, drillItem2.BoxMinOfDrawing.Z);
								drillItem2.BoxMaxItem = new Point3D(0.0 - drillItem2.BoxMinOfDrawing.X, 0.0 - drillItem2.BoxMinOfDrawing.Y, drillItem2.BoxMaxOfDrawing.Z);
								drillItem2.camEntities.Add(list11);
								list7.Add(drillItem2);
								drillItem2 = new DrillItem(drillItem);
								drillItem2.camEntities = new List<List<buEntity>>();
								list11 = new List<buEntity>();
								item = new buLine(PointsDevided[1], PointsDevided[2]);
								list11.Add(item);
								clsInit.cVector5.BoxSizeCalculate(list11, ref drillItem2.BoxMinOfDrawing, ref drillItem2.BoxMaxOfDrawing);
								drillItem2.BoxMinItem = new Point3D(0.0 - drillItem2.BoxMaxOfDrawing.X, 0.0 - drillItem2.BoxMaxOfDrawing.Y, drillItem2.BoxMinOfDrawing.Z);
								drillItem2.BoxMaxItem = new Point3D(0.0 - drillItem2.BoxMinOfDrawing.X, 0.0 - drillItem2.BoxMinOfDrawing.Y, drillItem2.BoxMaxOfDrawing.Z);
								drillItem2.camEntities.Add(list11);
								list7.Add(drillItem2);
								drillItem2 = new DrillItem(drillItem);
								drillItem2.camEntities = new List<List<buEntity>>();
								list11 = new List<buEntity>();
								item = new buLine(PointsDevided[2], PointsDevided[PointsDevided.Count - 3]);
								list11.Add(item);
								clsInit.cVector5.BoxSizeCalculate(list11, ref drillItem2.BoxMinOfDrawing, ref drillItem2.BoxMaxOfDrawing);
								drillItem2.BoxMinItem = new Point3D(0.0 - drillItem2.BoxMaxOfDrawing.X, 0.0 - drillItem2.BoxMaxOfDrawing.Y, drillItem2.BoxMinOfDrawing.Z);
								drillItem2.BoxMaxItem = new Point3D(0.0 - drillItem2.BoxMinOfDrawing.X, 0.0 - drillItem2.BoxMinOfDrawing.Y, drillItem2.BoxMaxOfDrawing.Z);
								drillItem2.camEntities.Add(list11);
								list7.Add(drillItem2);
								drillItem2 = new DrillItem(drillItem);
								drillItem2.camEntities = new List<List<buEntity>>();
								list11 = new List<buEntity>();
								item = new buLine(PointsDevided[PointsDevided.Count - 3], PointsDevided[PointsDevided.Count - 2]);
								list11.Add(item);
								clsInit.cVector5.BoxSizeCalculate(list11, ref drillItem2.BoxMinOfDrawing, ref drillItem2.BoxMaxOfDrawing);
								drillItem2.BoxMinItem = new Point3D(0.0 - drillItem2.BoxMaxOfDrawing.X, 0.0 - drillItem2.BoxMaxOfDrawing.Y, drillItem2.BoxMinOfDrawing.Z);
								drillItem2.BoxMaxItem = new Point3D(0.0 - drillItem2.BoxMinOfDrawing.X, 0.0 - drillItem2.BoxMinOfDrawing.Y, drillItem2.BoxMaxOfDrawing.Z);
								drillItem2.camEntities.Add(list11);
								list7.Add(drillItem2);
								drillItem2 = new DrillItem(drillItem);
								drillItem2.camEntities = new List<List<buEntity>>();
								list11 = new List<buEntity>();
								item = new buLine(PointsDevided[PointsDevided.Count - 2], PointsDevided[PointsDevided.Count - 1]);
								list11.Add(item);
								clsInit.cVector5.BoxSizeCalculate(list11, ref drillItem2.BoxMinOfDrawing, ref drillItem2.BoxMaxOfDrawing);
								drillItem2.BoxMinItem = new Point3D(0.0 - drillItem2.BoxMaxOfDrawing.X, 0.0 - drillItem2.BoxMaxOfDrawing.Y, drillItem2.BoxMinOfDrawing.Z);
								drillItem2.BoxMaxItem = new Point3D(0.0 - drillItem2.BoxMinOfDrawing.X, 0.0 - drillItem2.BoxMinOfDrawing.Y, drillItem2.BoxMaxOfDrawing.Z);
								drillItem2.camEntities.Add(list11);
								list7.Add(drillItem2);
							}
						}
						else
						{
							list7.Add(new DrillItem((buShapeCut)Job.Items[j]));
						}
					}
					else
					{
						list7.Add(new DrillItem((buShapeCut)Job.Items[j]));
					}
				}
				else
				{
					Job.ItemCalc.Add(new DrillCalcItem(buShapeCut2));
				}
			}
			if ((Job.Items[j].ShapeGroup == ShapeGroup.Shape) & Job.Items[j].Enable)
			{
				list5.Add(new DrillItem(Job.Items[j]));
			}
			if ((Job.Items[j].ShapeGroup == ShapeGroup.Profiling) & Job.Items[j].Enable)
			{
				list5.Add(new DrillItem((buShapeProfiling)Job.Items[j]));
			}
			if ((Job.Items[j] is buShapeJunction) & Job.Items[j].Enable)
			{
				buShapeJunction buShapeJunction2 = Job.Items[j] as buShapeJunction;
				if (buShapeJunction2.Enable)
				{
					for (int m = 0; m <= buShapeJunction2.multiCenter.Count - 1; m++)
					{
						buShapeHole buShapeHole9 = new buShapeHole(buShapeJunction2.multiCenter[m].Diameter, buShapeJunction2.Depth);
						buShapeHole9.CalculatedPoint = new Point3D(buShapeJunction2.multiCenter[m].Center.X, buShapeJunction2.multiCenter[m].Center.Y, buShapeJunction2.multiCenter[m].Center.Z);
						buShapeHole9.planeName = buShapeJunction2.planeName;
						buShapeHole9.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole9));
						IDCounter++;
					}
				}
			}
			if ((Job.Items[j].ShapeGroup == ShapeGroup.Engraving) & Job.Items[j].Enable)
			{
				list5.Add(new DrillItem((buShapeEngrave)Job.Items[j]));
			}
		}
		SortJobItems(ref Job);
		Job.isSorted = true;
		for (int n = 0; n <= Job.ItemCalc.Count - 1; n++)
		{
			Job.ItemCalc[n].Calculated = false;
		}
		for (int num2 = 0; num2 <= Job.ItemCalc.Count - 1; num2++)
		{
			if (Job.ItemCalc[num2].Enable & (Job.ItemCalc[num2].Type == DrillItemType.Drill))
			{
				if (Job.ItemCalc[num2].planeName == planeBoxNames.Left)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[num2]));
				}
				if (Job.ItemCalc[num2].planeName == planeBoxNames.Right)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[num2]));
				}
				if (Job.ItemCalc[num2].planeName == planeBoxNames.Back)
				{
					list.Add(new DrillCalcItem(Job.ItemCalc[num2]));
				}
				if (Job.ItemCalc[num2].planeName == planeBoxNames.Front)
				{
					list2.Add(new DrillCalcItem(Job.ItemCalc[num2]));
				}
				if (Job.ItemCalc[num2].planeName == planeBoxNames.Top)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[num2]));
				}
				if (Job.ItemCalc[num2].planeName == planeBoxNames.Bottom)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[num2]));
				}
			}
			if (Job.ItemCalc[num2].Enable & (Job.ItemCalc[num2].Type == DrillItemType.Slot))
			{
				list4.Add(new DrillCalcItem(Job.ItemCalc[num2]));
			}
		}
		FindFirstClamperPositions(Job, ref MaterialZeroYPos, ref X, ref X2);
		list3 = SortByXDistance(list3, new DrillCalcItem(), SortDirection.LowerToBigger);
		Job.Codes.Clear();
		Job.Cams.Clear();
		Job.Moves.Clear();
		Job.SimulationMoves.Clear();
		Job.Moves = new List<DrillMove>();
		Job.SimulationMoves = new List<DrillMove>();
		if (Job.isClamperSideDrillOpAvailable & (Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperSingleLimit))
		{
			double X1Pos = 0.0;
			double X2Pos = 0.0;
			Job.isSingleClamper = isSingleClamperAvailable(Job, ref X1Pos, ref X2Pos);
			if (Job.isSingleClamper)
			{
				X = X1Pos;
				X2 = X2Pos;
			}
		}
		ItemSplited = new List<List<DrillCalcItem>>();
		list8 = new List<DrillCalcItem>();
		List<DrillCalcItem> list12 = new List<DrillCalcItem>();
		List<DrillCalcItem> list13 = new List<DrillCalcItem>();
		List<DrillCalcItem> list14 = new List<DrillCalcItem>();
		List<DrillCalcItem> list15 = new List<DrillCalcItem>();
		List<DrillCalcItem> list16 = new List<DrillCalcItem>();
		for (int num3 = 0; num3 <= list3.Count - 1; num3++)
		{
			if (list8.Count != 0)
			{
				bool flag = false;
				if (buCompare5.EQ(list8[list8.Count - 1].Center.X, list3[num3].Center.X, 0.01))
				{
					flag = true;
				}
				if (!flag)
				{
					List<DrillCalcItem> list17 = new List<DrillCalcItem>();
					for (int num4 = 0; num4 <= list13.Count - 1; num4++)
					{
						list17.Add(list13[num4]);
					}
					for (int num5 = 0; num5 <= list14.Count - 1; num5++)
					{
						list17.Add(list14[num5]);
					}
					for (int num6 = 0; num6 <= list12.Count - 1; num6++)
					{
						list17.Add(list12[num6]);
					}
					for (int num7 = 0; num7 <= list15.Count - 1; num7++)
					{
						list17.Add(list15[num7]);
					}
					for (int num8 = 0; num8 <= list16.Count - 1; num8++)
					{
						list17.Add(list16[num8]);
					}
					ItemSplited.Add(list17);
					list8 = new List<DrillCalcItem>();
					list8.Add(list3[num3]);
					list12 = new List<DrillCalcItem>();
					list13 = new List<DrillCalcItem>();
					list14 = new List<DrillCalcItem>();
					list15 = new List<DrillCalcItem>();
					list16 = new List<DrillCalcItem>();
				}
				else
				{
					list8.Add(list3[num3]);
				}
			}
			else
			{
				list8.Add(new DrillCalcItem(list3[num3]));
			}
			if (list3[num3].planeName == planeBoxNames.Back)
			{
				list16.Add(new DrillCalcItem(list3[num3]));
			}
			if (list3[num3].planeName == planeBoxNames.Front)
			{
				list15.Add(new DrillCalcItem(list3[num3]));
			}
			if (list3[num3].planeName == planeBoxNames.Top)
			{
				list13.Add(new DrillCalcItem(list3[num3]));
			}
			if (list3[num3].planeName == planeBoxNames.Bottom)
			{
				list14.Add(new DrillCalcItem(list3[num3]));
			}
			if ((list3[num3].planeName == planeBoxNames.Left) | (list3[num3].planeName == planeBoxNames.Right))
			{
				list12.Add(new DrillCalcItem(list3[num3]));
			}
		}
		if (list8.Count > 0)
		{
			List<DrillCalcItem> list18 = new List<DrillCalcItem>();
			for (int num9 = 0; num9 <= list13.Count - 1; num9++)
			{
				list18.Add(list13[num9]);
			}
			for (int num10 = 0; num10 <= list14.Count - 1; num10++)
			{
				list18.Add(list14[num10]);
			}
			for (int num11 = 0; num11 <= list12.Count - 1; num11++)
			{
				list18.Add(list12[num11]);
			}
			for (int num12 = 0; num12 <= list15.Count - 1; num12++)
			{
				list18.Add(list15[num12]);
			}
			for (int num13 = 0; num13 <= list16.Count - 1; num13++)
			{
				list18.Add(list16[num13]);
			}
			ItemSplited.Add(list18);
		}
		drillMove = new DrillMove(clsDrill.varDrillCNCSettings.ParkX1, clsDrill.varDrillCNCSettings.ParkX2, clsDrill.varDrillCNCSettings.ParkY1, clsDrill.varDrillCNCSettings.ParkY2, clsDrill.varDrillCNCSettings.ParkY3, clsDrill.varDrillCNCSettings.ParkZ1, clsDrill.varDrillCNCSettings.ParkZ2, clsDrill.varDrillCNCSettings.ParkZ3, DrillMoveCommand.AxisMove, 0.0);
		Job.Moves.Add(drillMove);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AllClamperUp, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, clsDrill.varDrillCNCSettings.Z2SafeDistance, clsDrill.varDrillCNCSettings.Z3SafeDistance, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetAll, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(X, X2, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, MaterialZeroYPos, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z2SupportDistance, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Wait, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AllClamperDown, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.XAxesGantyOn, drillPlaneNames.Top, NoMove, ref Job);
		SplitedItems = new DrillSplitedItems();
		if (list2.Count > 0)
		{
			list9 = new List<List<DrillCalcItem>>();
			list2 = SortByYDistance(list2, new DrillCalcItem(), SortDirection.LowerToBigger);
			SplitItemsByDepth(list2, ref list9);
			for (int num14 = 0; num14 <= list9.Count - 1; num14++)
			{
				if (list9[num14].Count > 0)
				{
					List<DrillCalcItem> CopiedItem = new List<DrillCalcItem>();
					DrillCalcItem.Copy(list9[num14], ref CopiedItem);
					SplitedItems.lstFront.Add(CopiedItem);
				}
			}
		}
		for (int num15 = 0; num15 <= ItemSplited.Count - 1; num15++)
		{
			List<DrillCalcItem> list19 = new List<DrillCalcItem>();
			List<DrillCalcItem> list20 = new List<DrillCalcItem>();
			List<DrillCalcItem> list21 = new List<DrillCalcItem>();
			ItemSplited[num15] = SortByYDistance(ItemSplited[num15], new DrillCalcItem(), SortDirection.LowerToBigger);
			for (int num16 = 0; num16 <= ItemSplited[num15].Count - 1; num16++)
			{
				if (ItemSplited[num15][num16].planeName == planeBoxNames.Top)
				{
					list19.Add(new DrillCalcItem(ItemSplited[num15][num16]));
				}
				if (ItemSplited[num15][num16].planeName == planeBoxNames.Bottom)
				{
					list20.Add(new DrillCalcItem(ItemSplited[num15][num16]));
				}
				if ((ItemSplited[num15][num16].planeName == planeBoxNames.Right) | (ItemSplited[num15][num16].planeName == planeBoxNames.Left))
				{
					list21.Add(new DrillCalcItem(ItemSplited[num15][num16]));
				}
			}
			if (list19.Count > 0)
			{
				SplitedItems.lstTop.Add(list19);
			}
			if (list20.Count > 0)
			{
				SplitedItems.lstBottom.Add(list20);
			}
			if (list21.Count > 0)
			{
				SplitedItems.lstLeftRight.Add(list21);
			}
		}
		if (list.Count > 0)
		{
			list9 = new List<List<DrillCalcItem>>();
			list = SortByYDistance(list, new DrillCalcItem(), SortDirection.LowerToBigger);
			SplitItemsByDepth(list, ref list9);
			for (int num17 = 0; num17 <= list9.Count - 1; num17++)
			{
				if (list9[num17].Count > 0)
				{
					List<DrillCalcItem> CopiedItem2 = new List<DrillCalcItem>();
					DrillCalcItem.Copy(list9[num17], ref CopiedItem2);
					SplitedItems.lstBack.Add(CopiedItem2);
				}
			}
		}
		calcErrorList.Clear();
		FoundDrills.Clear();
		ClearCalculatedThings();
		FindHolesForFrontSide();
		FindHolesForTopSide();
		FindHolesForBottomSide();
		FindHolesForLeftRightSide();
		FindHolesForBackSide();
		AssingToolOffset();
		for (int num18 = 0; num18 <= FoundDrills.Count - 2; num18++)
		{
			if (buCompare5.EQ(FoundDrills[num18].Items[0].OffsetedPoint.X, FoundDrills[num18 + 1].Items[0].OffsetedPoint.X, 0.01))
			{
				FoundDrills[num18 + 1].Items[0].OffsetedPoint.X = FoundDrills[num18].Items[0].OffsetedPoint.X + 1E-05;
			}
		}
		FoundDrills = SortByXOffsetedDistanceDrillFound(FoundDrills, new DrillCalcItem(), SortDirection.LowerToBigger);
		if (clsDrill.varDrillCNCSettings.BackOperationsAlwaysWillLastOperation)
		{
			MoveBackOperationToLast();
		}
		CreateCodes(ref Job);
		for (int num19 = 0; num19 <= FoundDrills.Count - 1; num19++)
		{
			for (int num20 = 0; num20 <= FoundDrills[num19].Items.Count - 1; num20++)
			{
				SetAsCalculatedDrillItemByID(FoundDrills[num19].Items[num20].ID, ref Job.ItemCalc);
			}
		}
		for (int num21 = Job.ItemCalc.Count - 1; num21 >= 0; num21--)
		{
			if (Job.ItemCalc[num21].Type == DrillItemType.Drill)
			{
				if (Job.ItemCalc[num21].Enable)
				{
					if (!Job.ItemCalc[num21].Calculated)
					{
						calcErrorList.Add("Not Calculated | " + Job.ItemCalc[num21].planeName.ToString() + " - Diameter: " + Job.ItemCalc[num21].Diameter.ToString("f2") + " - Center (" + Job.ItemCalc[num21].Center.ToString() + ")");
					}
				}
				else
				{
					calcErrorList.Add("Disabled | " + Job.ItemCalc[num21].planeName.ToString() + " - Diameter: " + Job.ItemCalc[num21].Diameter.ToString("f2") + " - Center (" + Job.ItemCalc[num21].Center.ToString() + ")");
				}
			}
		}
		if (list4.Count > 0)
		{
			list4 = SortByYDistance(list4, new DrillCalcItem(), SortDirection.LowerToBigger);
			List<DrillCalcItem> ItemSlot = new List<DrillCalcItem>();
			if (list4.Count != 1)
			{
				for (int num22 = 0; num22 <= list4.Count - 1; num22++)
				{
					if (!list4[num22].Calculated)
					{
						DrillCalcItem drillCalcItem = list4[num22];
						ItemSlot.Add(drillCalcItem);
						for (int num23 = num22 + 1; num23 <= list4.Count - 1; num23++)
						{
							if (!list4[num23].Calculated)
							{
								DrillCalcItem drillCalcItem2 = list4[num23];
								double num24 = drillCalcItem.Center.Y - clsDrill.toolSlotY2.Positions.CommonOffset.Y;
								double num25 = drillCalcItem2.Center.Y - clsDrill.toolSlotY1.Positions.CommonOffset.Y;
								double num26 = num25 - num24;
								if (num26 > clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
								{
									ItemSlot.Add(drillCalcItem2);
								}
							}
							if (ItemSlot.Count >= 2)
							{
								num23 = list4.Count;
							}
						}
					}
					if (ItemSlot.Count > 0)
					{
						CreateCodeForSlotTopSide(ref Job, ref ItemSlot);
						for (int num27 = 0; num27 <= ItemSlot.Count - 1; num27++)
						{
							ItemSlot[num27].Calculated = true;
						}
					}
					ItemSlot.Clear();
				}
			}
			else
			{
				CreateCodeForSlotTopSide(ref Job, ref list4);
			}
			double num28 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			double num29 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			double num30 = 0.0;
			if (num28 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
			{
				double num31 = clsDrill.varDrillMachineSettings.MachineMinXStroke - num28;
				num28 += num31;
				num29 += num31;
				num30 += num31;
			}
			AddDrillMove(num28, num29, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, num30, ref Job);
		}
		CreatCodeFromJobShapeContour(ref Job);
		CreatCodeFromJobShapeItem(ref Job, list5, list6, list7);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.Finished, drillPlaneNames.Top, NoMove, ref Job);
		CreatCodeFromMove(Job.Moves, ref Job.Codes);
		Job.TotalSec = 0.0;
		doCalculateTime(ref Job.TotalSec);
		if (calcErrorList.Count > 0 && !IgnoreErrors)
		{
			DialogBoxList dialogBoxList = new DialogBoxList();
			dialogBoxList.Caption = "No Tool Available for These Holes";
			dialogBoxList.Width = 500;
			for (int num32 = 0; num32 <= calcErrorList.Count - 1; num32++)
			{
				dialogBoxList.Items.Add(calcErrorList[num32]);
			}
			dialogBoxList.Init();
			dialogBoxList.ShowDialog();
		}
	}

	public void CreatCodeFromJobShapeItem(ref DrillJob Job, List<DrillItem> ItemShape, List<DrillItem> ItemDrillShape, List<DrillItem> ItemSlotShape)
	{
		double num = 0.0;
		double num2 = 0.0;
		if (!((ItemShape.Count > 0) | (ItemDrillShape.Count > 0) | (ItemSlotShape.Count > 0) | Job.MakeContour))
		{
			return;
		}
		if (Job.Moves[Job.Moves.Count - 1].XPosition != 0.0)
		{
			num = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition, Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.Fast, 0.0, 0, 0, 0, 0, 0, 0, ref Job);
		}
		for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
		{
			if (clsDrill.ToolList[i].Data.No == 41)
			{
				clsDrill.toolBottom = new ToolBase5(clsDrill.ToolList[i]);
			}
		}
		num = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
		num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
		List<DrillItem> list = new List<DrillItem>();
		List<DrillItem> list2 = new List<DrillItem>();
		List<DrillItem> list3 = new List<DrillItem>();
		for (int j = 0; j <= ItemShape.Count - 1; j++)
		{
			if (ItemShape[j].planeName == planeBoxNames.Top)
			{
				list2.Add(ItemShape[j]);
			}
			if (ItemShape[j].planeName == planeBoxNames.Bottom)
			{
				list3.Add(ItemShape[j]);
			}
			list.Add(ItemShape[j]);
		}
		for (int k = 0; k <= ItemDrillShape.Count - 1; k++)
		{
			if (ItemDrillShape[k].planeName == planeBoxNames.Top)
			{
				list2.Add(ItemDrillShape[k]);
				list2[list2.Count - 1].isDrill = true;
			}
			if (ItemDrillShape[k].planeName == planeBoxNames.Bottom)
			{
				list3.Add(ItemDrillShape[k]);
				list3[list3.Count - 1].isDrill = true;
			}
			list.Add(ItemDrillShape[k]);
		}
		for (int l = 0; l <= ItemSlotShape.Count - 1; l++)
		{
			bool flag = false;
			if (ItemSlotShape[l].planeName == planeBoxNames.Top)
			{
				if (!((ItemSlotShape[l].Type == DrillItemType.SlotByMilling) & (ItemSlotShape[l].Command == drillCommands.CutHorizontal)) || ItemSlotShape[l].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
				{
				}
				if (!flag)
				{
					list2.Add(ItemSlotShape[l]);
				}
			}
			if (ItemSlotShape[l].planeName == planeBoxNames.Bottom)
			{
				list3.Add(ItemSlotShape[l]);
			}
			if (!flag)
			{
				list.Add(ItemSlotShape[l]);
			}
		}
		list = SortShapeByXDistance(list, new DrillItem(), SortDirection.LowerToBigger);
		list2 = new List<DrillItem>();
		list3 = new List<DrillItem>();
		for (int m = 0; m <= list.Count - 1; m++)
		{
			if (list[m].planeName == planeBoxNames.Top)
			{
				list2.Add(list[m]);
			}
			if (list[m].planeName == planeBoxNames.Bottom)
			{
				list3.Add(list[m]);
			}
		}
		List<DrillItem> list4 = new List<DrillItem>();
		for (int n = 0; n <= list.Count - 1; n++)
		{
			if (list[n].planeName == planeBoxNames.Top && Math.Abs(list[n].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
			{
				list4.Add(new DrillItem(list[n]));
			}
		}
		AdjustClamperForShape(ref Job, list4, num, num2);
		if (list2.Count > 0)
		{
			num = Job.Moves[Job.Moves.Count - 1].X1Clamper;
			num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
			double num3 = 0.0;
			double num4 = 0.0;
			double x = clsDrill.toolTop.Positions.CommonOffset.X;
			for (int num5 = 0; num5 <= list2.Count - 1; num5++)
			{
				if (list2[num5].ToolMilling != null)
				{
					clsDrill.toolTop = new ToolBase5(list2[num5].ToolMilling);
				}
				double ClamperMinXToToolX = 0.0;
				double ClamperMaxXToToolX = 0.0;
				if (!(Math.Abs(list2[num5].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0))
				{
					continue;
				}
				if (isItemInsideClamper(list2[num5], num2 + clsDrill.toolTop.Positions.CommonOffset.X + num4, clsDrill.toolTop, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0) | ((Math.Abs(ClamperMaxXToToolX) < 5.0) & (Math.Abs(ClamperMaxXToToolX) > 0.0)) | ((Math.Abs(ClamperMinXToToolX) < 20.0) & (Math.Abs(ClamperMinXToToolX) > 0.0)))
				{
					num4 += ClamperMinXToToolX;
					double num6 = num2 + x + num4 + list2[num5].BoxMinItem.X;
					double num7 = num6 - clsDrill.toolTop.Positions.CommonOffset.X;
					if (num7 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
					{
						double num8 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0 - num7;
						num4 += num8;
						ClamperMinXToToolX += num8;
					}
					list2[num5].X2Move = ClamperMinXToToolX;
				}
				if (isItemInsideClamper(list2[num5], num + clsDrill.toolTop.Positions.CommonOffset.X + num3, clsDrill.toolTop, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0) | ((Math.Abs(ClamperMaxXToToolX) < 20.0) & (Math.Abs(ClamperMaxXToToolX) > 0.0)) | ((Math.Abs(ClamperMinXToToolX) < 20.0) & (Math.Abs(ClamperMinXToToolX) > 0.0)))
				{
					num3 += ClamperMinXToToolX;
					double num9 = num + x + num3 + list2[num5].BoxMinItem.X;
					double num10 = num9 - clsDrill.toolTop.Positions.CommonOffset.X;
					if (num10 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
					{
						double num11 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0 - num10;
						num3 += num11;
						ClamperMinXToToolX += num11;
					}
					double num12 = num2 + num4;
					if (num12 - (num + num3) < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
					{
						double num13 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - (num12 - (num + num3));
						num4 += num13;
						list2[num5].X2Move = num13;
						list2[num5].X1First = false;
					}
					list2[num5].X1Move = ClamperMinXToToolX;
				}
			}
			double parkY = clsDrill.varDrillCNCSettings.ParkY2;
			AddDrillMove(NoMove, NoMove, NoMove, parkY, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.None, NoMove, ref Job);
			CreateCodeForShapeTopAndBottomSide(ref list2, preCalculation: false, isTop: true, clsDrill.toolTop, ref Job);
			TpPnt9D LastP = new TpPnt9D();
			if (Job.Cams.Count > 0)
			{
				clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP);
			}
			double num14 = LastP.P9.X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
			AddDrillMove(num + num3 + num14, num2 + num4 + num14, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.GCode, drillPlaneNames.Top, num14, ref Job);
			if (list3.Count > 0)
			{
				AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - num14, Job.Moves[Job.Moves.Count - 1].X2Clamper - num14, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.Fast, 0.0, 0, 0, 0, 0, 0, 0, ref Job);
			}
		}
		list4 = new List<DrillItem>();
		for (int num15 = 0; num15 <= list.Count - 1; num15++)
		{
			if (list[num15].planeName == planeBoxNames.Bottom && Math.Abs(list[num15].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.BottomKorukYMinusDistance)
			{
				list4.Add(new DrillItem(list[num15]));
			}
		}
		if (Job.Moves[Job.Moves.Count - 1].XPosition != 0.0)
		{
			num = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
		}
		else
		{
			num = Job.Moves[Job.Moves.Count - 1].X1Clamper;
			num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
		}
		AdjustClamperForShape(ref Job, list4, Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper);
		if (list3.Count <= 0)
		{
			return;
		}
		double num16 = 0.0;
		double num17 = 0.0;
		num = Job.Moves[Job.Moves.Count - 1].X1Clamper;
		num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
		num16 = 0.0;
		num17 = 0.0;
		for (int num18 = 0; num18 <= list3.Count - 1; num18++)
		{
			if (list3[num18].ToolMilling != null)
			{
				clsDrill.toolBottom = new ToolBase5(list3[num18].ToolMilling);
			}
			double ClamperMinXToToolX2 = 0.0;
			double ClamperMaxXToToolX2 = 0.0;
			if (!(Math.Abs(list3[num18].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0))
			{
				continue;
			}
			if (isItemInsideClamper(list3[num18], num2 + clsDrill.toolBottom.Positions.CommonOffset.X + num17, clsDrill.toolBottom, ref ClamperMinXToToolX2, ref ClamperMaxXToToolX2, clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance) | ((Math.Abs(ClamperMaxXToToolX2) < 20.0) & (Math.Abs(ClamperMaxXToToolX2) > 0.0)) | ((Math.Abs(ClamperMinXToToolX2) < 20.0) & (Math.Abs(ClamperMinXToToolX2) > 0.0)))
			{
				num17 += ClamperMinXToToolX2;
				double num19 = num2 + clsDrill.toolBottom.Positions.CommonOffset.X + num17 + list3[num18].BoxMinItem.X;
				double num20 = num19 - clsDrill.toolTop.Positions.CommonOffset.X;
				if (num20 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance)
				{
					double num21 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance - num20;
					num17 += num21;
					ClamperMinXToToolX2 += num21;
				}
				list3[num18].X2Move = ClamperMinXToToolX2;
			}
			if (isItemInsideClamper(list3[num18], num + clsDrill.toolBottom.Positions.CommonOffset.X + num16, clsDrill.toolBottom, ref ClamperMinXToToolX2, ref ClamperMaxXToToolX2, clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance) | ((Math.Abs(ClamperMaxXToToolX2) < 20.0) & (Math.Abs(ClamperMaxXToToolX2) > 0.0)) | ((Math.Abs(ClamperMinXToToolX2) < 20.0) & (Math.Abs(ClamperMinXToToolX2) > 0.0)))
			{
				num16 += ClamperMinXToToolX2;
				double num22 = num + clsDrill.toolBottom.Positions.CommonOffset.X + num16 + list3[num18].BoxMinItem.X;
				double num23 = num22 - clsDrill.toolTop.Positions.CommonOffset.X;
				if (num23 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance)
				{
					double num24 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance - num23;
					num16 += num24;
					ClamperMinXToToolX2 += num24;
				}
				double num25 = num2 + num17;
				if (num25 - (num + num16) < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					double num26 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - (num25 - (num + num16));
					num17 += num26;
					list3[num18].X2Move = num26;
					list3[num18].X1First = false;
				}
				list3[num18].X1Move = ClamperMinXToToolX2;
			}
		}
		CreateCodeForShapeTopAndBottomSide(ref list3, preCalculation: false, isTop: false, clsDrill.toolBottom, ref Job);
		if (Job.Cams.Count > 0 && Job.Cams[0].CamPoints.Count > 0)
		{
			double y = Job.Cams[Job.Cams.Count - 1].CamPoints[0].Points[0].P9.Y + clsDrill.varDrillCNCSettings.TopSpindleYOffsetForBottomOperation;
			double parkY2 = clsDrill.varDrillCNCSettings.ParkY2;
			TpPnt9D LastP2 = new TpPnt9D();
			clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP2);
			double num27 = LastP2.P9.X + clsDrill.varDrillCNCSettings.Tool270XZeroOffset;
			AddDrillMove(NoMove, NoMove, y, parkY2, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Bottom, DrillCNCMode.Z1_Z2NoOffset, NoMove, ref Job);
			AddDrillMove(num + num16 + num27, num2 + num17 + num27, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.GCode, drillPlaneNames.Bottom, DrillCNCMode.Z1_Z2NoOffset, num27, ref Job);
		}
	}

	public void AdjustClamperForShape(ref DrillJob Job, List<DrillItem> entInClamperArea, double lastX1, double lastX2)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = lastX1;
		double num4 = lastX2;
		if (!(Job.Material.Size.Width > clsDrill.varDrillMachineSettings.MachineMillingStandartXStroke))
		{
			List<MinMidMaxRange> list = new List<MinMidMaxRange>();
			List<MinMidMaxRange> list2 = new List<MinMidMaxRange>();
			List<double> RefList = new List<double>();
			for (int i = 0; i <= entInClamperArea.Count - 1; i++)
			{
				RefList.Add(entInClamperArea[i].BoxMinOfDrawing.X);
				RefList.Add(entInClamperArea[i].BoxMaxOfDrawing.X);
				if (entInClamperArea[i].planeName != planeBoxNames.Bottom)
				{
				}
				MinMidMaxRange minMidMaxRange = new MinMidMaxRange();
				minMidMaxRange.Min = entInClamperArea[i].BoxMinOfDrawing.X;
				minMidMaxRange.Max = entInClamperArea[i].BoxMaxOfDrawing.X;
				minMidMaxRange.Mid = (minMidMaxRange.Min + minMidMaxRange.Max) / 2.0;
				minMidMaxRange.Range = minMidMaxRange.Max - minMidMaxRange.Min;
				list2.Add(minMidMaxRange);
			}
			clsInit.cVector5.SortList(SortDirectionType.Bigger, ref RefList);
			bool flag = false;
			if (entInClamperArea.Count > 0 && entInClamperArea[0].planeName == planeBoxNames.Bottom)
			{
				flag = true;
			}
			for (int j = 0; j <= RefList.Count - 1; j++)
			{
				double num5 = clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				if (flag)
				{
					num5 = clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance;
				}
				if (j == 0)
				{
					MinMidMaxRange minMidMaxRange2 = new MinMidMaxRange();
					minMidMaxRange2.Max = 0.0;
					minMidMaxRange2.Min = RefList[j] + num5;
					minMidMaxRange2.Mid = (minMidMaxRange2.Min + minMidMaxRange2.Max) / 2.0;
					minMidMaxRange2.Range = minMidMaxRange2.Max - minMidMaxRange2.Min;
					if ((minMidMaxRange2.Max > minMidMaxRange2.Min) & (minMidMaxRange2.Range > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance))
					{
						list.Add(minMidMaxRange2);
					}
				}
				if (j > 0)
				{
					MinMidMaxRange minMidMaxRange3 = new MinMidMaxRange();
					minMidMaxRange3.Max = RefList[j - 1] - num5;
					minMidMaxRange3.Min = RefList[j] + num5;
					minMidMaxRange3.Mid = (minMidMaxRange3.Min + minMidMaxRange3.Max) / 2.0;
					minMidMaxRange3.Range = minMidMaxRange3.Max - minMidMaxRange3.Min;
					if ((minMidMaxRange3.Max > minMidMaxRange3.Min) & (minMidMaxRange3.Range > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance))
					{
						list.Add(minMidMaxRange3);
					}
				}
				if (j == RefList.Count - 1)
				{
					MinMidMaxRange minMidMaxRange4 = new MinMidMaxRange();
					minMidMaxRange4.Max = RefList[j] - num5;
					minMidMaxRange4.Min = 0.0 - clsDrill.activeJob.Material.Size.Width;
					minMidMaxRange4.Mid = (minMidMaxRange4.Min + minMidMaxRange4.Max) / 2.0;
					minMidMaxRange4.Range = minMidMaxRange4.Max - minMidMaxRange4.Min;
					if ((minMidMaxRange4.Max > minMidMaxRange4.Min) & (minMidMaxRange4.Range > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance))
					{
						list.Add(minMidMaxRange4);
					}
				}
			}
			num = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = true;
			bool flag5 = true;
			for (int k = 0; k <= list2.Count - 1; k++)
			{
				double num6 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				double num7 = Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				double num8 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				double num9 = Job.Moves[Job.Moves.Count - 1].X2Clamper + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				if ((num8 > list2[k].Min) & (num8 < list2[k].Max))
				{
					flag5 = false;
				}
				if ((num9 > list2[k].Min) & (num9 < list2[k].Max))
				{
					flag5 = false;
				}
				if ((list2[k].Min > num8) & (list2[k].Min < num9))
				{
					flag5 = false;
				}
				if ((list2[k].Max > num8) & (list2[k].Max < num9))
				{
					flag5 = false;
				}
				if ((num6 > list2[k].Min) & (num6 < list2[k].Max))
				{
					flag4 = false;
				}
				if ((num7 > list2[k].Min) & (num7 < list2[k].Max))
				{
					flag4 = false;
				}
				if ((list2[k].Min > num6) & (list2[k].Min < num7))
				{
					flag4 = false;
				}
				if ((list2[k].Max > num6) & (list2[k].Max < num7))
				{
					flag4 = false;
				}
			}
			if (list.Count > 0)
			{
				num2 = 0.0;
				num = 0.0;
				if (flag4)
				{
					num = Job.Moves[Job.Moves.Count - 1].X1Clamper;
				}
				if (flag5)
				{
					num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
				}
				if (!flag5)
				{
					for (int l = 0; l <= list.Count - 1; l++)
					{
						if (l != 0)
						{
							if (!flag3 && list[l].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance)
							{
								num2 = list[l].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag3 = true;
							}
						}
						else if (!(list[l].Max > -0.1))
						{
							if (list[l].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
							{
								num2 = list[l].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag3 = true;
							}
						}
						else if (!(Math.Abs(list[l].Min) < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0))
						{
							num2 = list[l].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
							flag3 = true;
						}
						else if (list.Count < 2)
						{
							if (Math.Abs(list[l].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num2 = list[l].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag3 = true;
							}
						}
						else if (!(list[1].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance))
						{
							if (Math.Abs(list[l].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num2 = list[l].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag3 = true;
							}
						}
						else if (!(Math.Abs(list[1].Max) < Job.Material.Size.Width / 3.0))
						{
							if (Math.Abs(list[l].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num2 = list[l].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag3 = true;
							}
						}
						else
						{
							num2 = list[1].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
							flag3 = true;
						}
					}
				}
				if (!flag4)
				{
					for (int num10 = list.Count - 1; num10 >= 0; num10--)
					{
						if (num10 != list.Count - 1)
						{
							if (!flag2 && list[num10].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
							{
								num = list[num10].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
								if (!(num > clsDrill.varDrillMachineSettings.MachineMinXStroke))
								{
									double num11 = list[num10].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
									double num12 = list[num10].Max - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
									if ((clsDrill.varDrillMachineSettings.MachineMinXStroke > num11) & (clsDrill.varDrillMachineSettings.MachineMinXStroke < num12))
									{
										num = clsDrill.varDrillMachineSettings.MachineMinXStroke;
										flag2 = true;
									}
								}
								else
								{
									flag2 = true;
								}
								if (flag2)
								{
								}
							}
						}
						else if (!(list[num10].Min <= 0.0 - clsDrill.activeJob.Material.Size.Width))
						{
							if (list[num10].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
							{
								num = list[num10].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
								flag2 = true;
							}
						}
						else if (!(list[num10].Range < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0))
						{
							if (!(list[num10].Range < clsDrill.varDrillCNCSettings.ClamperLength * 2.0))
							{
								num = list[num10].Min + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0);
								if (num > clsDrill.varDrillMachineSettings.MachineMinXStroke)
								{
									flag2 = true;
								}
							}
							else
							{
								num = list[num10].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								if (num > clsDrill.varDrillMachineSettings.MachineMinXStroke)
								{
									flag2 = true;
								}
							}
						}
						else if (list.Count < 2)
						{
							if (Math.Abs(list[num10].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num = list[num10].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag2 = true;
							}
						}
						else if (!(list[list.Count - 2].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance))
						{
							if (Math.Abs(list[num10].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num = list[num10].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag2 = true;
							}
						}
						else if (!(list[list.Count - 2].Min < (0.0 - Job.Material.Size.Width) * 0.66))
						{
							if (Math.Abs(list[num10].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num = list[num10].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag2 = true;
							}
						}
						else
						{
							double num13 = list[list.Count - 2].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
							double num14 = num2 - num13;
							if (!(num14 > clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance))
							{
								if (Math.Abs(list[num10].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
								{
									num = list[num10].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
									flag2 = true;
								}
							}
							else
							{
								num = list[list.Count - 2].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag2 = true;
							}
						}
					}
				}
				double num15 = clsDrill.activeJob.Material.Size.Width - Math.Abs(num);
				if ((num15 < 0.0) & (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - Math.Abs(num15) < 50.0))
				{
					num = 0.0 - clsDrill.activeJob.Material.Size.Width;
				}
				List<string> list3 = new List<string>();
				if (!flag5)
				{
					if (!flag3)
					{
						list3.Add(buDrillCalc.LangDrillMessage[25] + " [X2]");
					}
					else if (!buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X2Clamper, num2))
					{
						if (num2 < (0.0 - Job.Material.Size.Width) / 2.0)
						{
							for (int m = 0; m <= list2.Count - 1; m++)
							{
								if ((0.0 - Job.Material.Size.Width) / 2.0 < list2[m].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
								{
									num2 = (0.0 - Job.Material.Size.Width) / 2.0;
								}
							}
						}
						if (num2 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
						{
							num = num2 - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
							MoveClampers(num, NoMove, drillPlaneNames.Top, ref Job);
						}
						MoveClampers(NoMove, num2, drillPlaneNames.Top, ref Job);
					}
				}
				if (!flag4)
				{
					if (!flag2)
					{
						list3.Add(buDrillCalc.LangDrillMessage[25] + " [X1]");
					}
					else if (!buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X1Clamper, num) && num < (0.0 - Job.Material.Size.Width) / 2.0 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
					{
						double num16 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num;
						if (num16 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
						{
							num = Job.Moves[Job.Moves.Count - 1].X2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
						}
						MoveClampers(num, NoMove, drillPlaneNames.Top, ref Job);
					}
				}
				if (Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					num = Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					MoveClampers(num, NoMove, drillPlaneNames.Top, ref Job);
				}
			}
			if (!((entInClamperArea.Count > 0) & (list2.Count > 0) & (list.Count == 0 || (!flag3 && !flag5))))
			{
				return;
			}
			_ = Job.Moves[Job.Moves.Count - 1].XPosition;
			if (!(Job.Material.Size.Width <= 500.0))
			{
				num4 = list2[0].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - 150.0;
				if (num4 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					num3 = num4 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
					MoveClampers(num3, NoMove, drillPlaneNames.Top, ref Job);
				}
				MoveClampers(NoMove, num4, drillPlaneNames.Top, ref Job);
			}
			else
			{
				num4 = list2[0].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - 20.0;
				if (num4 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					num3 = num4 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
					MoveClampers(num3, NoMove, drillPlaneNames.Top, ref Job);
				}
				MoveClampers(NoMove, num4, drillPlaneNames.Top, ref Job);
			}
			return;
		}
		double num17 = Job.Material.Size.Width - clsDrill.varDrillMachineSettings.MachineMillingStandartXStroke;
		double num18 = lastX2 - num17;
		if (!(num18 - lastX1 > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance))
		{
			if (num18 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance) > clsDrill.varDrillMachineSettings.MachineMinXStroke)
			{
				lastX2 = num18;
				lastX1 = num18 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
				MoveClampers(lastX1, NoMove, drillPlaneNames.Top, ref Job);
				MoveClampers(NoMove, lastX2, drillPlaneNames.Top, ref Job);
			}
		}
		else
		{
			lastX2 = num18;
			MoveClampers(NoMove, lastX2, drillPlaneNames.Top, ref Job);
		}
	}

	public void CreatCodeFromJobShapeContour(ref DrillJob Job)
	{
		bool flag = false;
		List<DrillItem> list = new List<DrillItem>();
		DrillItem drillItem = new DrillItem();
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			if (Job.Items[i].ShapeGroup == ShapeGroup.Contour)
			{
				flag = true;
				drillItem = new DrillItem(Job.Items[i], Contour: true);
				drillItem.shapeEntitites.Clear();
				list.Add(drillItem);
			}
		}
		if (!flag)
		{
			return;
		}
		for (int j = 0; j <= clsDrill.ToolList.Count - 1; j++)
		{
			if (clsDrill.ToolList[j].Data.No == 41)
			{
				clsDrill.toolBottom = new ToolBase5(clsDrill.ToolList[j]);
			}
		}
		double num = Job.Moves[Job.Moves.Count - 1].XPosition;
		double X = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
		double X2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
		AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - num, Job.Moves[Job.Moves.Count - 1].X2Clamper - num, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.Fast, 0.0, 0, 0, 0, 0, 0, 0, ref Job);
		List<DrillItem> list2 = new List<DrillItem>();
		List<DrillItem> list3 = new List<DrillItem>();
		List<DrillItem> list4 = new List<DrillItem>();
		if (!flag)
		{
			return;
		}
		for (int k = 0; k <= list.Count - 1; k++)
		{
			bool isTop = true;
			ToolBase5 tool = new ToolBase5(clsDrill.toolTop);
			double num2 = clsDrill.varDrillCNCSettings.ContourLimitLenForTopSpindleOneMove;
			if (list[k].planeName == planeBoxNames.Bottom)
			{
				num2 = clsDrill.varDrillCNCSettings.ContourLimitLenForBottomSpindleOneMove;
				tool = new ToolBase5(clsDrill.toolBottom);
				isTop = false;
			}
			list3 = new List<DrillItem>();
			list4 = new List<DrillItem>();
			drillItem = new DrillItem(list[k]);
			MillingContourClamperPositions(Job, isTop, ref X, ref X2);
			if (!(Job.Material.Size.Width >= num2))
			{
				if (!(Job.Moves[Job.Moves.Count - 1].X2Clamper - X > clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength))
				{
					double num3 = Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper - X2);
					if (num3 > 0.2)
					{
						MoveClampers(NoMove, X2, drillPlaneNames.Top, ref Job);
					}
					double num4 = Math.Abs(Job.Moves[Job.Moves.Count - 1].X1Clamper - X);
					if (num4 > 0.2)
					{
						MoveClampers(X, NoMove, drillPlaneNames.Top, ref Job);
					}
				}
				else
				{
					double num5 = Math.Abs(Job.Moves[Job.Moves.Count - 1].X1Clamper - X);
					if (num5 > 0.2)
					{
						MoveClampers(X, NoMove, drillPlaneNames.Top, ref Job);
					}
					double num6 = Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper - X2);
					if (num6 > 0.2)
					{
						MoveClampers(NoMove, X2, drillPlaneNames.Top, ref Job);
					}
				}
			}
			else if (!(X2 - Job.Moves[Job.Moves.Count - 1].X1Clamper > clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength))
			{
				double num7 = Math.Abs(Job.Moves[Job.Moves.Count - 1].X1Clamper - X);
				if (num7 > 0.2)
				{
					MoveClampers(X, NoMove, drillPlaneNames.Top, ref Job);
				}
				double num8 = Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper - X2);
				if (num8 > 0.2)
				{
					MoveClampers(NoMove, X2, drillPlaneNames.Top, ref Job);
				}
			}
			else
			{
				double num9 = Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper - X2);
				if (num9 > 0.2)
				{
					MoveClampers(NoMove, X2, drillPlaneNames.Top, ref Job);
				}
				double num10 = Math.Abs(Job.Moves[Job.Moves.Count - 1].X1Clamper - X);
				if (num10 > 0.2)
				{
					MoveClampers(X, NoMove, drillPlaneNames.Top, ref Job);
				}
			}
			drillItem.Command = drillCommands.DrawingContour;
			if (drillItem.planeName == planeBoxNames.Top)
			{
				CreateContourEntities(Job, drillItem, tool, isTop, ref drillItem.X1Move, ref drillItem.X2Move, ref drillItem.X1First, ref drillItem.ClockDir, ref drillItem.shapeEntitites);
				drillItem.isMillingAtClamperSide = true;
				list3.Add(drillItem);
				list2.Add(new DrillItem(drillItem));
			}
			if (drillItem.planeName == planeBoxNames.Bottom)
			{
				CreateContourEntities(Job, drillItem, tool, isTop, ref drillItem.X1Move, ref drillItem.X2Move, ref drillItem.X1First, ref drillItem.ClockDir, ref drillItem.shapeEntitites);
				drillItem.isMillingAtClamperSide = true;
				list4.Add(drillItem);
				list2.Add(new DrillItem(drillItem));
			}
			if (list3.Count > 0)
			{
				double parkY = clsDrill.varDrillCNCSettings.ParkY2;
				AddDrillMove(NoMove, NoMove, NoMove, parkY, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.None, NoMove, ref Job);
				CreateCodeForShapeTopAndBottomSide(ref list3, preCalculation: false, isTop: true, clsDrill.toolTop, ref Job);
				X = Job.Moves[Job.Moves.Count - 1].X1Clamper;
				X2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
				for (int l = 0; l <= list3.Count - 1; l++)
				{
					X += list3[l].X1Move;
					X2 += list3[l].X2Move;
				}
				TpPnt9D LastP = new TpPnt9D();
				clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP);
				num = LastP.P9.X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
				X += num;
				X2 += num;
				AddDrillMove(X, X2, LastP.P9.Y, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.GCode, drillPlaneNames.Top, num, ref Job);
				camTpPoint camTpPoint2 = Job.Cams[Job.Cams.Count - 1].CamPoints[Job.Cams[Job.Cams.Count - 1].CamPoints.Count - 1];
				_ = camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y + 100.0;
				camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M26");
			}
			if (list4.Count > 0)
			{
				CreateCodeForShapeTopAndBottomSide(ref list4, preCalculation: false, isTop: false, clsDrill.toolBottom, ref Job);
				X = Job.Moves[Job.Moves.Count - 1].X1Clamper;
				X2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
				for (int m = 0; m <= list4.Count - 1; m++)
				{
					X += list4[m].X1Move;
					X2 += list4[m].X2Move;
				}
				TpPnt9D LastP2 = new TpPnt9D();
				clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP2);
				num = LastP2.P9.X + clsDrill.varDrillCNCSettings.Tool270XZeroOffset;
				X += num;
				X2 += num;
				double y = Job.Cams[Job.Cams.Count - 1].CamPoints[0].Points[0].P9.Y + 0.0;
				_ = Job.Cams[Job.Cams.Count - 1].CamPoints[0].Points[0].P9.Y;
				double parkY2 = clsDrill.varDrillCNCSettings.ParkY2;
				DrillMoveOptions options = new DrillMoveOptions(drillPlaneNames.Bottom, DrillCNCMode.Z1_Z2NoOffset, DrillMoveAddType.OnlyMove);
				AddDrillMove(NoMove, NoMove, y, parkY2, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
				AddDrillMove(X, X2, NoMove, NoMove, LastP2.P9.Y, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z3SafeDistance, DrillMoveCommand.GCode, drillPlaneNames.Bottom, num, ref Job);
				camTpPoint camTpPoint3 = Job.Cams[Job.Cams.Count - 1].CamPoints[Job.Cams[Job.Cams.Count - 1].CamPoints.Count - 1];
				camTpPoint3.Points[camTpPoint3.Points.Count - 1].AfterCodes.Add("M28");
			}
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - num, Job.Moves[Job.Moves.Count - 1].X2Clamper - num, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.Fast, 0.0, 0, 0, 0, 0, 0, 0, ref Job);
		}
	}

	public void CreateContourEntities(DrillJob Job, DrillItem ContourOP, ToolBase5 Tool, bool isTop, ref double X1Move, ref double X2Move, ref bool isX1First, ref ClockDirectionType ClockDir, ref List<List<buEntity>> ELL)
	{
		double x1Clamper = Job.Moves[Job.Moves.Count - 1].X1Clamper;
		double x2Clamper = Job.Moves[Job.Moves.Count - 1].X2Clamper;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = Tool.Geometry.Diameter / 2.0 + ContourOP.Offset;
		num2 = clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + 10.0;
		num = clsDrill.varDrillCNCSettings.ContourLimitLenForTopSpindleOneMove;
		if (!isTop)
		{
			num2 = Math.Abs(clsDrill.varDrillCNCSettings.BottomKorukXMinusDistance) + clsDrill.varDrillCNCSettings.ClamperSafeXDistance;
			num = clsDrill.varDrillCNCSettings.ContourLimitLenForBottomSpindleOneMove;
		}
		if ((isTop & (clsDrill.varDrillCNCSettings.ContourTopDirection == ClockDirectionType.CW)) | (!isTop & (clsDrill.varDrillCNCSettings.ContourBottomDirection == ClockDirectionType.CW)))
		{
			isX1First = false;
			ClockDir = ClockDirectionType.CW;
			if (!(Job.Material.Size.Width >= num))
			{
				double num4 = 0.0;
				double num5 = 0.0;
				if (!isTop)
				{
					if (!((Job.Material.Size.Width >= 700.0) & (Job.Material.Size.Width < num)))
					{
						num4 = x1Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.8);
						num5 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.8);
					}
					else
					{
						num4 = x1Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
						num5 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
					}
				}
				else if (!((Job.Material.Size.Width >= 500.0) & (Job.Material.Size.Width < num)))
				{
					if (!((Job.Material.Size.Width >= 400.0) & (Job.Material.Size.Width < 500.0)))
					{
						num4 = x1Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.5);
						num5 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.5);
					}
					else
					{
						num4 = x1Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.8);
						num5 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.8);
					}
				}
				else
				{
					num4 = x1Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
					num5 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
				}
				Point3D start = new Point3D(num5, num3);
				Point3D point3D = new Point3D(num3, num3);
				Point3D point3D2 = new Point3D(num3, 0.0 - Job.Material.Size.Height - num3);
				Point3D point3D3 = new Point3D(0.0 - Job.Material.Size.Width - num3, 0.0 - Job.Material.Size.Height - num3);
				Point3D point3D4 = new Point3D(0.0 - Job.Material.Size.Width - num3, num3);
				Point3D point3D5 = new Point3D(num4, num3);
				Point3D end = new Point3D(num5, num3);
				List<buEntity> list = new List<buEntity>();
				buLine item = new buLine(start, point3D);
				list.Add(item);
				item = new buLine(point3D, point3D2);
				list.Add(item);
				item = new buLine(point3D2, point3D3);
				list.Add(item);
				ELL.Add(list);
				list = new List<buEntity>();
				item = new buLine(point3D3, point3D4);
				list.Add(item);
				item = new buLine(point3D4, point3D5);
				list.Add(item);
				ELL.Add(list);
				list = new List<buEntity>();
				item = new buLine(point3D5, end);
				list.Add(item);
				ELL.Add(list);
				if (!isTop)
				{
					if (!((Job.Material.Size.Width >= 700.0) & (Job.Material.Size.Width < num)))
					{
						X1Move = x2Clamper - 75.0;
						X2Move = 0.0 - x2Clamper + 65.0;
					}
					else
					{
						X1Move = x2Clamper;
						X2Move = 0.0 - x2Clamper;
					}
				}
				else if (!((Job.Material.Size.Width >= 500.0) & (Job.Material.Size.Width < num)))
				{
					if (!((Job.Material.Size.Width >= 400.0) & (Job.Material.Size.Width < 500.0)))
					{
						X1Move = x2Clamper - 75.0;
						X2Move = 0.0 - x2Clamper + 65.0;
					}
					else
					{
						X1Move = x2Clamper - 20.0;
						X2Move = 0.0 - x2Clamper + 20.0;
					}
				}
				else
				{
					X1Move = x2Clamper;
					X2Move = 0.0 - x2Clamper;
				}
			}
			else
			{
				double x = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
				double x2 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
				Point3D start2 = new Point3D(x2, num3);
				Point3D point3D6 = new Point3D(num3, num3);
				Point3D point3D7 = new Point3D(num3, 0.0 - Job.Material.Size.Height - num3);
				Point3D point3D8 = new Point3D(0.0 - Job.Material.Size.Width - num3, 0.0 - Job.Material.Size.Height - num3);
				Point3D point3D9 = new Point3D(0.0 - Job.Material.Size.Width - num3, num3);
				Point3D point3D10 = new Point3D(x, num3);
				Point3D end2 = new Point3D(x2, num3);
				List<buEntity> list2 = new List<buEntity>();
				buLine item2 = new buLine(start2, point3D6);
				list2.Add(item2);
				item2 = new buLine(point3D6, point3D7);
				list2.Add(item2);
				item2 = new buLine(point3D7, point3D8);
				list2.Add(item2);
				item2 = new buLine(point3D8, point3D9);
				list2.Add(item2);
				item2 = new buLine(point3D9, point3D10);
				list2.Add(item2);
				ELL.Add(list2);
				list2 = new List<buEntity>();
				item2 = new buLine(point3D10, end2);
				list2.Add(item2);
				ELL.Add(list2);
				X1Move = 0.0 - (clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2);
				X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2;
			}
		}
		if (!((isTop & (clsDrill.varDrillCNCSettings.ContourTopDirection == ClockDirectionType.CCW)) | (!isTop & (clsDrill.varDrillCNCSettings.ContourBottomDirection == ClockDirectionType.CCW))))
		{
			return;
		}
		isX1First = true;
		ClockDir = ClockDirectionType.CCW;
		if (!(Job.Material.Size.Width >= num))
		{
			if (!((500.0 <= Job.Material.Size.Width) & (Job.Material.Size.Width < num)))
			{
				double num6 = 0.0;
				double num7 = 0.0;
				if (!(Job.Material.Size.Width >= 500.0))
				{
					num6 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
					num7 = x2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
				}
				else
				{
					num6 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
					num7 = x2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
				}
				Point3D start3 = new Point3D(num6, num3);
				Point3D point3D11 = new Point3D(0.0 - Job.Material.Size.Width - num3, num3);
				Point3D point3D12 = new Point3D(0.0 - Job.Material.Size.Width - num3, 0.0 - Job.Material.Size.Height - num3);
				Point3D point3D13 = new Point3D(num3, 0.0 - Job.Material.Size.Height - num3);
				Point3D point3D14 = new Point3D(num3, num3);
				Point3D point3D15 = new Point3D(num7, num3);
				Point3D end3 = new Point3D(num6, num3);
				List<buEntity> list3 = new List<buEntity>();
				buLine item3 = new buLine(start3, point3D11);
				list3.Add(item3);
				item3 = new buLine(point3D11, point3D12);
				list3.Add(item3);
				item3 = new buLine(point3D12, point3D13);
				list3.Add(item3);
				ELL.Add(list3);
				list3 = new List<buEntity>();
				item3 = new buLine(point3D13, point3D14);
				list3.Add(item3);
				item3 = new buLine(point3D14, point3D15);
				list3.Add(item3);
				ELL.Add(list3);
				list3 = new List<buEntity>();
				item3 = new buLine(point3D15, end3);
				list3.Add(item3);
				ELL.Add(list3);
				if (!(Job.Material.Size.Width >= 500.0))
				{
					X1Move = 0.0 - (clsDrill.varDrillCNCSettings.ClamperLength + 1.8 * num2);
					X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 1.6 * num2;
				}
				else
				{
					X1Move = 0.0 - (clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2);
					X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2;
				}
			}
			else
			{
				double num8 = 0.0;
				double num9 = 0.0;
				if (!(Job.Material.Size.Width >= 500.0))
				{
					num8 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.9);
					num9 = x2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2 * 0.8);
				}
				else
				{
					num8 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
					num9 = x2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
				}
				Point3D start4 = new Point3D(num8, num3);
				Point3D point3D16 = new Point3D(0.0 - Job.Material.Size.Width - num3, num3);
				Point3D point3D17 = new Point3D(0.0 - Job.Material.Size.Width - num3, 0.0 - Job.Material.Size.Height - num3);
				Point3D point3D18 = new Point3D(num3, 0.0 - Job.Material.Size.Height - num3);
				Point3D point3D19 = new Point3D(num3, num3);
				Point3D point3D20 = new Point3D(num9, num3);
				Point3D end4 = new Point3D(num8, num3);
				List<buEntity> list4 = new List<buEntity>();
				buLine item4 = new buLine(start4, point3D16);
				list4.Add(item4);
				item4 = new buLine(point3D16, point3D17);
				list4.Add(item4);
				item4 = new buLine(point3D17, point3D18);
				list4.Add(item4);
				ELL.Add(list4);
				list4 = new List<buEntity>();
				item4 = new buLine(point3D18, point3D19);
				list4.Add(item4);
				item4 = new buLine(point3D19, point3D20);
				list4.Add(item4);
				ELL.Add(list4);
				list4 = new List<buEntity>();
				item4 = new buLine(point3D20, end4);
				list4.Add(item4);
				ELL.Add(list4);
				if (!(Job.Material.Size.Width >= 500.0))
				{
					X1Move = 0.0 - (clsDrill.varDrillCNCSettings.ClamperLength + 1.2 * num2);
					X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 1.0 * num2;
				}
				else
				{
					X1Move = 0.0 - (clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2);
					X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2;
				}
			}
		}
		else
		{
			double x3 = x1Clamper - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
			double x4 = x2Clamper + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num2);
			Point3D start5 = new Point3D(x3, num3);
			Point3D point3D21 = new Point3D(0.0 - Job.Material.Size.Width - num3, num3);
			Point3D point3D22 = new Point3D(0.0 - Job.Material.Size.Width - num3, 0.0 - Job.Material.Size.Height - num3);
			Point3D point3D23 = new Point3D(num3, 0.0 - Job.Material.Size.Height - num3);
			Point3D point3D24 = new Point3D(num3, num3);
			Point3D point3D25 = new Point3D(x4, num3);
			Point3D end5 = new Point3D(x3, num3);
			List<buEntity> list5 = new List<buEntity>();
			buLine item5 = new buLine(start5, point3D21);
			list5.Add(item5);
			item5 = new buLine(point3D21, point3D22);
			list5.Add(item5);
			item5 = new buLine(point3D22, point3D23);
			list5.Add(item5);
			item5 = new buLine(point3D23, point3D24);
			list5.Add(item5);
			item5 = new buLine(point3D24, point3D25);
			list5.Add(item5);
			ELL.Add(list5);
			list5 = new List<buEntity>();
			item5 = new buLine(point3D25, end5);
			list5.Add(item5);
			ELL.Add(list5);
			X1Move = 0.0 - (clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2);
			X2Move = clsDrill.varDrillCNCSettings.ClamperLength + 2.0 * num2;
		}
	}

	public void DrawEntities(bool ZoomFit)
	{
		clsDrill.viewportAuto.Entities.Clear();
		CustomData customData = null;
		clsDrill.SimMovePartIndex.Clear();
		for (int i = 0; i <= ccVars.SimMachine.MachineParts.Count - 1; i++)
		{
			for (int j = 0; j <= ccVars.SimMachine.MachineParts[i].Entities.Count - 1; j++)
			{
				buMachinePart buMachinePart2 = new buMachinePart(ccVars.SimMachine.MachineParts[i].PartName);
				buMachinePart2.ARotation = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.A;
				buMachinePart2.BRotation = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.B;
				buMachinePart2.CRotation = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.C;
				buMachinePart2.XMove = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.X;
				buMachinePart2.YMove = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.Y;
				buMachinePart2.ZMove = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.Z;
				buMachinePart2.xRot = ccVars.SimMachine.MachineParts[i].RotationCenter.X;
				buMachinePart2.yRot = ccVars.SimMachine.MachineParts[i].RotationCenter.Y;
				buMachinePart2.zRot = ccVars.SimMachine.MachineParts[i].RotationCenter.Z;
				buMachinePart2.Color = ccVars.SimMachine.MachineParts[i].Color;
				buMachinePart2.ColorMethod = colorMethodType.byEntity;
				double num = 0.0;
				if (ccVars.SimMachine.MachineParts[i].Tag != null)
				{
					if (ccVars.SimMachine.MachineParts[i].Tag == "Z1")
					{
						num = clsDrill.varDrillCNCSettings.Y1GroupZOffset;
					}
					if (ccVars.SimMachine.MachineParts[i].Tag == "Z2")
					{
						num = clsDrill.varDrillCNCSettings.Y2GroupZOffset;
					}
					if (ccVars.SimMachine.MachineParts[i].Tag == "Z3")
					{
						num = clsDrill.varDrillCNCSettings.Y3GroupZOffset;
					}
				}
				double dx = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.X;
				double dy = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.Y;
				double dz = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.Z + num;
				buMachinePart2.Translate(dx, dy, dz);
				buMachinePart2.Tag = ccVars.SimMachine.MachineParts[i].Tag;
				buMachinePart2.No = ccVars.SimMachine.MachineParts[i].No;
				customData = new CustomData();
				customData.typeDefination = entityTypeDefination.MachineBody;
				customData.OriginalEntityIndex = clsDrill.viewportAuto.Entities.Count;
				buMachinePart2.EntityData = customData;
				clsDrill.viewportAuto.Entities.Add(buMachinePart2);
				clsDrill.SimMovePartIndex.Add(clsDrill.viewportAuto.Entities.Count - 1);
			}
		}
		for (int num2 = clsDrill.viewportAuto.Blocks.Count - 1; num2 >= 0; num2--)
		{
			bool flag = false;
			if (clsDrill.viewportAuto.Blocks[num2].Name.IndexOf("Tool") >= 0)
			{
				clsDrill.viewportAuto.Blocks.RemoveAt(num2);
				flag = true;
			}
			if (!flag && clsDrill.viewportAuto.Blocks[num2].Name.IndexOf("SolidMat") >= 0)
			{
				clsDrill.viewportAuto.Blocks.RemoveAt(num2);
				flag = true;
			}
			if (!flag && clsDrill.viewportAuto.Blocks[num2].Name.IndexOf("MaterialWood") >= 0)
			{
				clsDrill.viewportAuto.Blocks.RemoveAt(num2);
				flag = true;
			}
		}
		for (int k = 0; k <= clsDrill.ToolList.Count - 1; k++)
		{
			List<Mesh> refMeshes = new List<Mesh>();
			clsDrill.ToolList[k].Geometry.LowerRadius = 0.0;
			clsDrill.ToolList[k].Geometry.UpperRadius = 0.0;
			clsDrill.ToolList[k].Geometry.CornerRadiusType = ToolCornerRadiusType.None;
			clsInit.appMW.CreateToolWithToolDirection(clsDrill.ToolList[k], ToolCut: true, ToolBody: true, Arbor: false, Holder: false, ZeroIsMachineSide: true, ref refMeshes);
			Block block = new Block("Tool" + clsDrill.ToolList[k].Data.No);
			buTool buTool2 = new buTool(block.Name);
			for (int l = 0; l <= refMeshes.Count - 1; l++)
			{
				refMeshes[l].Color = Color.FromArgb(255, refMeshes[l].Color);
				if ((clsDrill.ToolList[k].Data.No >= 61) & (clsDrill.ToolList[k].Data.No <= 79))
				{
					if (Math.Abs(clsDrill.ToolList[k].Geometry.ToolDirection.Z) == 0.0)
					{
						double dx2 = clsDrill.ToolList[k].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalXOffset;
						double dy2 = 0.0 - clsDrill.ToolList[k].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalYOffset;
						double dz2 = clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
						refMeshes[l].Translate(dx2, dy2, dz2);
					}
					else
					{
						double dx3 = clsDrill.ToolList[k].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalXOffset;
						double dy3 = 0.0 - clsDrill.ToolList[k].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalYOffset;
						double dz3 = clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
						refMeshes[l].Translate(dx3, dy3, dz3);
					}
					buTool2.Tag = "Z1";
				}
				if (clsDrill.ToolList[k].Data.No == 80)
				{
					double dx4 = clsDrill.ToolList[k].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalXOffset;
					double dy4 = 0.0 - clsDrill.ToolList[k].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalYOffset;
					double dz4 = clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
					refMeshes[l].Translate(dx4, dy4, dz4);
					buTool2.Tag = "Z1";
				}
				if (clsDrill.ToolList[k].Data.No == 85)
				{
					double dx5 = clsDrill.ToolList[k].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalXOffset;
					double dy5 = 0.0 - clsDrill.ToolList[k].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y1GroupToolVerticalYOffset;
					double dz5 = clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
					refMeshes[l].Translate(dx5, dy5, dz5);
					buTool2.Tag = "Z1";
				}
				if ((clsDrill.ToolList[k].Data.No >= 161) & (clsDrill.ToolList[k].Data.No <= 179))
				{
					if (Math.Abs(clsDrill.ToolList[k].Geometry.ToolDirection.Z) == 0.0)
					{
						double dx6 = clsDrill.ToolList[k].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y2GroupToolHorizontalXOffset;
						double dy6 = 0.0 - clsDrill.ToolList[k].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y2GroupToolHorizontalYOffset;
						double dz6 = clsDrill.varDrillCNCSettings.Y2GroupToolHorizontalZOffset + clsDrill.varDrillCNCSettings.Y2GroupZOffset;
						refMeshes[l].Translate(dx6, dy6, dz6);
					}
					else
					{
						double dx7 = clsDrill.ToolList[k].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y2GroupToolVerticalXOffset;
						double dy7 = 0.0 - clsDrill.ToolList[k].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y2GroupToolVerticalYOffset;
						double dz7 = clsDrill.varDrillCNCSettings.Y2GroupToolVerticalZOffset + clsDrill.varDrillCNCSettings.Y2GroupZOffset;
						refMeshes[l].Translate(dx7, dy7, dz7);
					}
					buTool2.Tag = "Z2";
				}
				if (clsDrill.ToolList[k].Data.No == 185)
				{
					double dx8 = clsDrill.ToolList[k].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y2GroupToolVerticalXOffset;
					double dy8 = 0.0 - clsDrill.ToolList[k].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y2GroupToolVerticalYOffset;
					double dz8 = clsDrill.varDrillCNCSettings.Y2GroupToolVerticalZOffset + clsDrill.varDrillCNCSettings.Y2GroupZOffset;
					refMeshes[l].Translate(dx8, dy8, dz8);
					buTool2.Tag = "Z2";
				}
				if ((clsDrill.ToolList[k].Data.No >= 261) & (clsDrill.ToolList[k].Data.No <= 269))
				{
					double dx9 = clsDrill.ToolList[k].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y3GroupToolVerticalXOffset;
					double dy9 = 0.0 - clsDrill.ToolList[k].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y3GroupToolVerticalYOffset;
					double dz9 = clsDrill.varDrillCNCSettings.Y3GroupToolVerticalZOffset + clsDrill.varDrillCNCSettings.Y3GroupZOffset;
					refMeshes[l].Translate(dx9, dy9, dz9);
					buTool2.Tag = "Z3";
				}
				if (clsDrill.ToolList[k].Data.No == 270)
				{
					double dx10 = clsDrill.ToolList[k].Positions.Offset.X + clsDrill.varDrillCNCSettings.Y3GroupToolVerticalXOffset;
					double dy10 = 0.0 - clsDrill.ToolList[k].Positions.Offset.Y + clsDrill.varDrillCNCSettings.Y3GroupToolVerticalYOffset;
					double dz10 = clsDrill.varDrillCNCSettings.Y3GroupToolMillingZOffset + clsDrill.varDrillCNCSettings.Y3GroupZOffset;
					refMeshes[l].Translate(dx10, dy10, dz10);
					buTool2.Tag = "Z3";
				}
				refMeshes[l].EntityData = clsDrill.ToolList[k].Data.No;
				block.Entities.Add(refMeshes[l]);
			}
			if (block.Entities.Count > 0)
			{
				clsDrill.viewportAuto.Blocks.Add(block);
			}
			buTool2.No = clsDrill.ToolList[k].Data.No;
			customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Tool;
			customData.OriginalEntityIndex = clsDrill.viewportAuto.Entities.Count;
			buTool2.EntityData = customData;
			clsDrill.viewportAuto.Entities.Add(buTool2);
			clsDrill.SimMovePartIndex.Add(clsDrill.viewportAuto.Entities.Count - 1);
		}
		if (clsDrill.activeJob == null)
		{
			return;
		}
		if (clsDrill.activeJob.Material.Entities != null)
		{
			Entity copiedEnt = null;
			clsDrill.activeJob.panelEntity.Color = Color.FromArgb(150, clsDrill.varDrillSettings.colorPanel);
			buVector5.CopyEntities(clsDrill.activeJob.Material.Entities[0], ref copiedEnt);
			copiedEnt.Color = Color.FromArgb(150, clsDrill.varDrillSettings.colorPanel);
			copiedEnt.Regen(0.005);
			buMaterialMoveable buMaterialMoveable2 = new buMaterialMoveable("MaterialWood");
			buMaterialMoveable2.XMove = true;
			Block block2 = new Block("MaterialWood");
			block2.Entities.Add(copiedEnt);
			for (int m = 0; m <= clsDrill.viewportAuto.Blocks.Count - 1; m++)
			{
				if (!(clsDrill.viewportAuto.Blocks[m].Name == "MaterialWood"))
				{
				}
			}
			clsDrill.viewportAuto.Blocks.Add(block2);
			customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Material;
			customData.OriginalEntityIndex = clsDrill.viewportAuto.Entities.Count;
			buMaterialMoveable2.EntityData = customData;
			clsDrill.viewportAuto.Entities.Add(buMaterialMoveable2);
			clsDrill.SimMovePartIndex.Add(clsDrill.viewportAuto.Entities.Count - 1);
		}
		for (int n = 0; n <= clsDrill.activeJob.Items.Count - 1; n++)
		{
			for (int num3 = 0; num3 <= clsDrill.activeJob.Items[n].entitySolid.Count - 1; num3++)
			{
				Entity copiedEntity = null;
				buEntity.Copy(clsDrill.activeJob.Items[n].entitySolid[num3], ref copiedEntity);
				if (clsDrill.activeJob.Items[n].Enable)
				{
					copiedEntity.Color = Color.Lime;
				}
				else
				{
					copiedEntity.Color = Color.Gray;
				}
				buMaterialMoveable buMaterialMoveable3 = new buMaterialMoveable("SolidMat" + n + num3);
				buMaterialMoveable3.XMove = true;
				Block block3 = new Block("SolidMat" + n + num3);
				block3.Entities.Add(copiedEntity);
				for (int num4 = 0; num4 <= clsDrill.viewportAuto.Blocks.Count - 1; num4++)
				{
					if (!(clsDrill.viewportAuto.Blocks[num4].Name == "SolidMat" + n + num3))
					{
					}
				}
				clsDrill.viewportAuto.Blocks.Add(block3);
				customData = new CustomData();
				customData.typeDefination = entityTypeDefination.Material;
				customData.OriginalEntityIndex = clsDrill.viewportAuto.Entities.Count;
				buMaterialMoveable3.EntityData = customData;
				clsDrill.viewportAuto.Entities.Add(buMaterialMoveable3);
				clsDrill.SimMovePartIndex.Add(clsDrill.viewportAuto.Entities.Count - 1);
			}
		}
	}

	public void MoveSimPart(DrillMove pntMove)
	{
		clsDrill.SimToCollsionCheck1.Clear();
		clsDrill.SimToCollsionCheck2.Clear();
		if (pntMove.Command == DrillMoveCommand.AllClamperDown)
		{
			double num = 0.0;
			if (clsDrill.activeJob != null)
			{
				num = clsDrill.activeJob.Material.Size.Depth;
			}
			X1ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX1ClampZDistance + num;
			X2ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX2ClampZDistance + num;
		}
		if (pntMove.Command == DrillMoveCommand.AllClamperUp)
		{
			X1ClamperZOffset = 0.0;
			X2ClamperZOffset = 0.0;
		}
		if (pntMove.Command == DrillMoveCommand.Clamper1Up)
		{
			X1ClamperZOffset = 0.0;
		}
		if (pntMove.Command == DrillMoveCommand.Clamper1Down)
		{
			double num2 = 0.0;
			if (clsDrill.activeJob != null)
			{
				num2 = clsDrill.activeJob.Material.Size.Depth;
			}
			X1ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX1ClampZDistance + num2;
		}
		if (pntMove.Command == DrillMoveCommand.Clamper2Up)
		{
			X2ClamperZOffset = 0.0;
		}
		if (pntMove.Command == DrillMoveCommand.Clamper2Down)
		{
			double num3 = 0.0;
			if (clsDrill.activeJob != null)
			{
				num3 = clsDrill.activeJob.Material.Size.Depth;
			}
			X2ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX2ClampZDistance + num3;
		}
		if ((pntMove.Command == DrillMoveCommand.ResetAll) | (pntMove.Command2 == DrillMoveCommand.ResetAll) | (pntMove.Command3 == DrillMoveCommand.ResetAll))
		{
			for (int i = 0; i < 300; i++)
			{
				clsDrill.ToolPistonDownPos[i] = 0.0;
			}
		}
		if ((pntMove.Command == DrillMoveCommand.ResetPiston) | (pntMove.Command2 == DrillMoveCommand.ResetPiston) | (pntMove.Command3 == DrillMoveCommand.ResetPiston))
		{
			ResetTools(pntMove.Tool1);
			ResetTools(pntMove.Tool2);
			ResetTools(pntMove.Tool3);
			ResetTools(pntMove.Tool4);
			ResetTools(pntMove.Tool5);
			ResetTools(pntMove.Tool6);
			ResetTools(pntMove.Tool7);
			ResetTools(pntMove.Tool8);
			ResetTools(pntMove.Tool9);
			ResetTools(pntMove.Tool10);
			ResetTools(pntMove.Tool11);
			ResetTools(pntMove.Tool12);
		}
		if ((pntMove.Command == DrillMoveCommand.SetPiston) | (pntMove.Command2 == DrillMoveCommand.SetPiston) | (pntMove.Command3 == DrillMoveCommand.SetPiston))
		{
			SetTools(pntMove.Tool1);
			SetTools(pntMove.Tool2);
			SetTools(pntMove.Tool3);
			SetTools(pntMove.Tool4);
			SetTools(pntMove.Tool5);
			SetTools(pntMove.Tool6);
			SetTools(pntMove.Tool7);
			SetTools(pntMove.Tool8);
			SetTools(pntMove.Tool9);
			SetTools(pntMove.Tool10);
			SetTools(pntMove.Tool11);
			SetTools(pntMove.Tool12);
		}
		for (int j = 0; j <= clsDrill.SimMovePartIndex.Count - 1; j++)
		{
			CustomData customData = clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]].EntityData as CustomData;
			KinematicBase5 kinematicBase = new KinematicBase5();
			kinematicBase.RotateCenterOffsetOfA.Z = 171.0;
			kinematicBase.Type = KinemeticType.CartezianXYZ_WristA_4Axis;
			new Pnt6D();
			new Point3D();
			_ = clsDrill.SimMovePartIndex[j];
			if (!((clsDrill.SimMovePartIndex[j] >= 0) & (clsDrill.SimMovePartIndex[j] <= clsDrill.viewportAuto.Entities.Count - 1)))
			{
				continue;
			}
			if (clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]].GetType() == typeof(buTool))
			{
				buTool buTool2 = clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]] as buTool;
				_ = ((BlockReference)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).BlockName;
				double num4 = 0.0;
				if ((buTool2.No >= 0) & (buTool2.No <= 299))
				{
					num4 = clsDrill.ToolPistonDownPos[buTool2.No];
				}
				if (buTool2.Tag != null)
				{
					if (buTool2.Tag == "Z1")
					{
						((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y1Position;
						if (buTool2.No == 80)
						{
							((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = pntMove.Z1Position + num4;
						}
						else
						{
							((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = pntMove.Z1Position + num4;
						}
						Entity entity = buVector5.CopyEntities((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
						entity.Translate(0.0, 0.0 - pntMove.Y1Position, pntMove.Z1Position + num4);
						entity.Regen(new RegenParams(0.01, clsDrill.viewportAuto));
						clsDrill.SimToCollsionCheck1.Add(entity);
					}
					if (buTool2.Tag == "Z2")
					{
						((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y2Position;
						((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = pntMove.Z2Position + num4;
						Entity entity2 = buVector5.CopyEntities((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
						entity2.Translate(0.0, 0.0 - pntMove.Y2Position, pntMove.Z2Position + num4);
						entity2.Regen(new RegenParams(0.01, clsDrill.viewportAuto));
						clsDrill.SimToCollsionCheck1.Add(entity2);
					}
					if (buTool2.Tag == "Z3")
					{
						((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y3Position;
						if (buTool2.No == 270)
						{
							((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = 0.0 - (pntMove.Z3Position + num4 + clsDrill.varDrillSettings.SimBottomMillinOffset);
						}
						else
						{
							((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = 0.0 - (pntMove.Z3Position + num4);
						}
						Entity entity3 = buVector5.CopyEntities((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
						entity3.Translate(0.0, 0.0 - pntMove.Y3Position, 0.0 - (pntMove.Z3Position + num4));
						entity3.Regen(new RegenParams(0.01, clsDrill.viewportAuto));
						clsDrill.SimToCollsionCheck1.Add(entity3);
					}
				}
			}
			if (clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]].GetType() == typeof(buMaterialMoveable))
			{
				((buMaterialMoveable)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).xPos = pntMove.XPosition;
			}
			if (!(clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]].GetType() == typeof(buMachinePart)))
			{
				continue;
			}
			buMachinePart buMachinePart2 = clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]] as buMachinePart;
			if (!((customData.typeDefination == entityTypeDefination.MachineBody) | (customData.typeDefination == entityTypeDefination.MachineParts)))
			{
				continue;
			}
			string blockName = ((BlockReference)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).BlockName;
			double num5 = 0.0;
			if ((buMachinePart2.No >= 0) & (buMachinePart2.No <= 299))
			{
				num5 = clsDrill.ToolPistonDownPos[buMachinePart2.No];
			}
			if ((blockName == "X1_Body") | (blockName == "X1_Clamper"))
			{
				if (!(blockName == "X1_Clamper"))
				{
				}
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).xPos = pntMove.X1Clamper;
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = X1ClamperZOffset;
				Entity entity4 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity4.Translate(pntMove.X1Clamper, 0.0, X1ClamperZOffset);
				entity4.Regen(new RegenParams(0.01, clsDrill.viewportAuto));
				if (blockName == "X1_Clamper")
				{
					clsDrill.SimToCollsionCheck2.Add(entity4);
				}
			}
			if ((blockName == "X2_Body") | (blockName == "X2_Clamper"))
			{
				if (!(blockName == "X2_Clamper"))
				{
				}
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).xPos = pntMove.X2Clamper;
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = X2ClamperZOffset;
				Entity entity5 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity5.Translate(pntMove.X2Clamper, 0.0, X2ClamperZOffset);
				entity5.Regen(new RegenParams(0.01, clsDrill.viewportAuto));
				if (blockName == "X2_Clamper")
				{
					clsDrill.SimToCollsionCheck2.Add(entity5);
				}
			}
			if (blockName == "Y1_Body")
			{
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y1Position;
				Entity entity6 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity6.Translate(0.0, 0.0 - pntMove.Y1Position);
			}
			if (blockName == "Y2_Body")
			{
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y2Position;
				Entity entity7 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity7.Translate(0.0, 0.0 - pntMove.Y2Position);
			}
			if (blockName == "Y3_Body")
			{
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y3Position;
				Entity entity8 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity8.Translate(0.0, 0.0 - pntMove.Y3Position);
			}
			if (buMachinePart2.Tag == null)
			{
				continue;
			}
			if (buMachinePart2.Tag == "Z1")
			{
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y1Position;
				if (!(blockName != "Z1_Milling"))
				{
					((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = pntMove.Z1Position + clsDrill.ToolPistonDownPos[80] + clsDrill.varDrillSettings.SimTopMillingOffset;
				}
				else
				{
					((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = pntMove.Z1Position + num5;
				}
				Entity entity9 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity9.Translate(0.0, 0.0 - pntMove.Y1Position, pntMove.Z1Position + num5);
			}
			if (buMachinePart2.Tag == "Z2")
			{
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y2Position;
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = pntMove.Z2Position + num5;
				Entity entity10 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity10.Translate(0.0, 0.0 - pntMove.Y2Position, pntMove.Z2Position + num5);
			}
			if (buMachinePart2.Tag == "Z3")
			{
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y3Position;
				if (!(blockName != "Z3_Milling"))
				{
					((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = 0.0 - (pntMove.Z3Position + num5 + clsDrill.ToolPistonDownPos[270] + clsDrill.varDrillSettings.SimBottomMillinOffset);
				}
				else
				{
					((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = 0.0 - (pntMove.Z3Position + num5);
				}
				Entity entity11 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity11.Translate(0.0, 0.0 - pntMove.Y3Position, 0.0 - (pntMove.Z3Position + num5));
			}
		}
		clsDrill.viewportAuto.Entities.Regen();
		if (!clsDrill.viewportAuto.IsAnimationRunning)
		{
		}
	}

	public void SetTools(int ToolNo)
	{
		if (ToolNo >= 61 && ToolNo <= 71)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonVerticalDistance;
		}
		if (ToolNo >= 31 && ToolNo <= 36)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
		}
		if (ToolNo == 85)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonSawDistance;
		}
		if (ToolNo >= 161 && ToolNo <= 171)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonVerticalDistance;
		}
		if (ToolNo == 185)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonSawDistance;
		}
		if (ToolNo == 41)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolBottomSpindlePistonDistance;
		}
		if (ToolNo >= 261 && ToolNo <= 269)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonVerticalDistance;
		}
		if (ToolNo == 72 || ToolNo == 74 || ToolNo == 76 || ToolNo == 78 || ToolNo == 172 || ToolNo == 174 || ToolNo == 176 || ToolNo == 178)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
			clsDrill.ToolPistonDownPos[ToolNo + 1] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
		}
		if (ToolNo == 73 || ToolNo == 75 || ToolNo == 77 || ToolNo == 79 || ToolNo == 173 || ToolNo == 175 || ToolNo == 177 || ToolNo == 179)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
			clsDrill.ToolPistonDownPos[ToolNo - 1] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
		}
	}

	public void ResetTools(int ToolNo)
	{
		if (ToolNo >= 0 && ToolNo <= 299)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
			if (ToolNo == 72 || ToolNo == 74 || ToolNo == 76 || ToolNo == 78 || ToolNo == 172 || ToolNo == 174 || ToolNo == 176 || ToolNo == 178)
			{
				clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
				clsDrill.ToolPistonDownPos[ToolNo + 1] = 0.0;
			}
			if (ToolNo == 73 || ToolNo == 75 || ToolNo == 77 || ToolNo == 79 || ToolNo == 173 || ToolNo == 175 || ToolNo == 177 || ToolNo == 179)
			{
				clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
				clsDrill.ToolPistonDownPos[ToolNo - 1] = 0.0;
			}
		}
	}

	public void FindHolesForFrontSide()
	{
		double num = clsDrill.varDrillCNCSettings.Y1MinLimit;
		int num2 = 0;
		if (clsDrill.activeJob.Material.Size.Height > clsDrill.varDrillCNCSettings.DoubleHeadWorkTogetherLimit)
		{
			num = clsDrill.activeJob.Material.Size.Height / 2.0;
		}
		for (int i = 0; i <= base.SplitedItems.lstFront.Count - 1; i++)
		{
			List<DrillCalcItem> list = base.SplitedItems.lstFront[i];
			List<DrillCalcItem> list2 = new List<DrillCalcItem>();
			List<DrillCalcItem> list3 = new List<DrillCalcItem>();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				if (!list[j].Calculated)
				{
					if (!(list[j].Center.Y < clsDrill.activeJob.Material.Size.Height))
					{
						list3.Add(new DrillCalcItem(list[j]));
					}
					else if (!(list[j].Center.Y >= num))
					{
						list3.Add(new DrillCalcItem(list[j]));
					}
					else
					{
						list2.Add(new DrillCalcItem(list[j]));
					}
				}
			}
			if (list2.Count > 0)
			{
				list2 = ((!clsDrill.varDrillCNCSettings.MirrorCalculationForFront) ? SortByYDistance(list2, new DrillCalcItem(), SortDirection.LowerToBigger) : SortByYDistance(list2, new DrillCalcItem(), SortDirection.BiggerToLower));
			}
			if (list3.Count > 0)
			{
				list3 = SortByYDistance(list3, new DrillCalcItem(), SortDirection.LowerToBigger);
			}
			num2 = list2.Count;
			if (list3.Count > num2)
			{
				num2 = list3.Count;
			}
			if (list2.Count >= 2 && clsInit.cDrill.isMultiZAvailable(list2))
			{
				List<List<DrillCalcItem>> SplitedItems = new List<List<DrillCalcItem>>();
				clsInit.cDrill.SplitDrillsByYDistanceThenSortZDir(list2, SortDirection.LowerToBigger, ref SplitedItems);
				if (SplitedItems.Count > 0)
				{
					list2 = new List<DrillCalcItem>();
					for (int k = 0; k <= SplitedItems.Count - 1; k++)
					{
						for (int l = 0; l <= SplitedItems[k].Count - 1; l++)
						{
							list2.Add(new DrillCalcItem(SplitedItems[k][l]));
						}
					}
				}
			}
			if (list3.Count >= 2 && clsInit.cDrill.isMultiZAvailable(list3))
			{
				List<List<DrillCalcItem>> SplitedItems2 = new List<List<DrillCalcItem>>();
				clsInit.cDrill.SplitDrillsByYDistanceThenSortZDir(list3, SortDirection.LowerToBigger, ref SplitedItems2);
				if (SplitedItems2.Count > 0)
				{
					list3 = new List<DrillCalcItem>();
					for (int m = 0; m <= SplitedItems2.Count - 1; m++)
					{
						for (int n = 0; n <= SplitedItems2[m].Count - 1; n++)
						{
							list3.Add(new DrillCalcItem(SplitedItems2[m][n]));
						}
					}
				}
			}
			for (int num3 = 0; num3 <= num2 - 1; num3++)
			{
				DrillFound Found = new DrillFound();
				for (int num4 = 0; num4 <= clsDrill.ToolList.Count - 1; num4++)
				{
					clsDrill.ToolList[num4].Data.Used = false;
				}
				List<int> Y1GroupTool = new List<int>();
				List<int> Y1GroupTool2 = new List<int>();
				int T = 0;
				int T2 = 0;
				int T3 = 0;
				int T4 = 0;
				int T5 = 0;
				int T6 = 0;
				int T7 = 0;
				int T8 = 0;
				int T9 = 0;
				int T10 = 0;
				int T11 = 0;
				int T12 = 0;
				int num5 = 0;
				FindToolSettings findToolSettings = new FindToolSettings();
				findToolSettings.Plane = planeBoxNames.Front;
				findToolSettings.SetAsUsed = true;
				ToolBase5 foundTool = null;
				ToolBase5 foundTool2 = null;
				if (((num3 <= list3.Count - 1) & (list3.Count > 0)) && !list3[num3].Calculated)
				{
					if (list3[num3].NumberNextVerticalItem > 0)
					{
						findToolSettings.SelectVerticalTools = true;
					}
					num5 = 0;
					clsInit.cDrill.isHorizontalDrillAvailabe(list3, list3[num3], clsDrill.varDrillCNCSettings.ToolRepeatDistance, num3, ref num5);
					FindToolFromBlock(list3[num3], 1, findToolSettings, SortDirection.BiggerToLower, ref foundTool2);
					if (foundTool2 != null)
					{
						int num6 = SetValueToAvailableTool(foundTool2.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
						if (num6 <= 0)
						{
							calcErrorList.Add("Top Surface Y2 Group Tool Set Limit Full - Tool No : " + foundTool2.Data.No + " - Position : " + list3[num3].Center.ToString());
						}
						else
						{
							list3[num3].Calculated = true;
							list3[num3].OffsetedPoint.Y = list3[num3].Center.Y - foundTool2.Positions.Offset.Y;
							list3[num3].HeadNo = 2;
							DrillFound.Add(list3[num3], foundTool2.Data.No, ref Found);
							SetAsUsedToolByNo(foundTool2.Data.No, ref clsDrill.ToolList);
							SetAsCalculatedDrillItemByID(list3[num3].ID);
						}
					}
					if (foundTool2 != null)
					{
						for (int num7 = num3 + 1; num7 <= list3.Count - 1; num7++)
						{
							double num8 = list3[num7].Center.Y - list3[num3].Center.Y;
							double value = num8 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
							if (!((num8 > 0.0) & !list3[num7].Calculated & buCompare5.EQ(value, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(list3[num3], list3[num7])))
							{
								continue;
							}
							for (int num9 = 0; num9 <= clsDrill.ToolList.Count - 1; num9++)
							{
								if (!((foundTool2.Data.GroupIndex == clsDrill.ToolList[num9].Data.GroupIndex) & !clsDrill.ToolList[num9].Data.Used & (clsDrill.ToolList[num9].Geometry.Diameter == list3[num7].Diameter) & (clsDrill.ToolList[num9].Geometry.ToolDirection.X == -1.0)))
								{
									continue;
								}
								double value2 = clsDrill.ToolList[num9].Positions.Offset.Y - foundTool2.Positions.Offset.Y;
								if (buCompare5.EQ(value2, num8, 0.05))
								{
									int num10 = SetValueToAvailableTool(clsDrill.ToolList[num9].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool2, ref Y1GroupTool2);
									if (num10 > 0)
									{
										list3[num7].HeadNo = 2;
										list3[num7].OffsetedPoint.Y = list3[num7].Center.Y - clsDrill.ToolList[num9].Positions.Offset.Y;
										list3[num7].Calculated = true;
										clsDrill.ToolList[num9].Data.Used = true;
										DrillFound.Add(list3[num7], clsDrill.ToolList[num9].Data.No, ref Found);
										SetAsCalculatedDrillItemByID(list3[num7].ID);
									}
									if (num10 < 1)
									{
										calcErrorList.Add("Top Surface Y2 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num9].Data.No + " - Position : " + list3[num7].Center.ToString());
									}
									num9 = clsDrill.ToolList.Count;
								}
							}
						}
					}
				}
				if (((num3 <= list2.Count - 1) & (list2.Count > 0)) && !list2[num3].Calculated)
				{
					num5 = 0;
					clsInit.cDrill.isHorizontalDrillAvailabe(list2, list2[num3], clsDrill.varDrillCNCSettings.ToolRepeatDistance, num3, ref num5);
					if (clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
					{
						FindToolFromBlock(list2[num3], 0, findToolSettings, SortDirection.BiggerToLower, ref foundTool);
					}
					else
					{
						FindToolFromBlock(list2[num3], 0, findToolSettings, ref foundTool);
					}
					if (foundTool != null)
					{
						int num11 = SetValueToAvailableTool(foundTool.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
						if (num11 <= 0)
						{
							calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + foundTool.Data.No + " - Position : " + list2[num3].Center.ToString());
						}
						else
						{
							list2[num3].Calculated = true;
							list2[num3].OffsetedPoint.Y = list2[num3].Center.Y - foundTool.Positions.Offset.Y;
							list2[num3].HeadNo = 1;
							DrillFound.Add(list2[num3], foundTool.Data.No, ref Found);
							SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
							SetAsCalculatedDrillItemByID(list2[num3].ID);
						}
					}
					if (foundTool != null)
					{
						for (int num12 = num3 + 1; num12 <= list2.Count - 1; num12++)
						{
							double num13 = list2[num12].Center.Y - list2[num3].Center.Y;
							if (clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
							{
								num13 = list2[num3].Center.Y - list2[num12].Center.Y;
							}
							double value3 = num13 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
							if (!((num13 > 0.0) & !list2[num12].Calculated & buCompare5.EQ(value3, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(list2[num3], list2[num12])))
							{
								continue;
							}
							for (int num14 = 0; num14 <= clsDrill.ToolList.Count - 1; num14++)
							{
								if (!((foundTool.Data.GroupIndex == clsDrill.ToolList[num14].Data.GroupIndex) & !clsDrill.ToolList[num14].Data.Used & (clsDrill.ToolList[num14].Geometry.Diameter == list2[num12].Diameter) & (clsDrill.ToolList[num14].Geometry.ToolDirection.X == -1.0)))
								{
									continue;
								}
								double value4 = clsDrill.ToolList[num14].Positions.Offset.Y - foundTool.Positions.Offset.Y;
								if (clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
								{
									value4 = foundTool.Positions.Offset.Y - clsDrill.ToolList[num14].Positions.Offset.Y;
								}
								if (buCompare5.EQ(value4, num13, 0.05))
								{
									int num15 = SetValueToAvailableTool(clsDrill.ToolList[num14].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y1GroupTool2);
									if (num15 > 0)
									{
										list2[num12].Calculated = true;
										list2[num12].OffsetedPoint.Y = list2[num12].Center.Y - clsDrill.ToolList[num14].Positions.Offset.Y;
										list2[num12].HeadNo = 1;
										clsDrill.ToolList[num14].Data.Used = true;
										DrillFound.Add(list2[num12], clsDrill.ToolList[num14].Data.No, ref Found);
										SetAsCalculatedDrillItemByID(list2[num12].ID);
									}
									if (num15 < 1)
									{
										calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num14].Data.No + " - Position : " + list2[num12].Center.ToString());
									}
									num14 = clsDrill.ToolList.Count;
								}
							}
						}
					}
				}
				if (Found.Items.Count > 0)
				{
					FoundDrills.Add(Found);
				}
			}
		}
	}

	public void FindHolesForBackSide()
	{
		double num = clsDrill.varDrillCNCSettings.Y1MinLimit;
		int num2 = 0;
		if (clsDrill.activeJob.Material.Size.Height > clsDrill.varDrillCNCSettings.DoubleHeadWorkTogetherLimit)
		{
			num = clsDrill.activeJob.Material.Size.Height / 2.0;
		}
		for (int i = 0; i <= base.SplitedItems.lstBack.Count - 1; i++)
		{
			List<DrillCalcItem> list = base.SplitedItems.lstBack[i];
			List<DrillCalcItem> list2 = new List<DrillCalcItem>();
			List<DrillCalcItem> list3 = new List<DrillCalcItem>();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				if (!list[j].Calculated)
				{
					if (!(list[j].Center.Y < clsDrill.activeJob.Material.Size.Height))
					{
						list3.Add(new DrillCalcItem(list[j]));
					}
					else if (!(list[j].Center.Y >= num))
					{
						list3.Add(new DrillCalcItem(list[j]));
					}
					else
					{
						list2.Add(new DrillCalcItem(list[j]));
					}
				}
			}
			if (list2.Count > 0)
			{
				list2 = ((!clsDrill.varDrillCNCSettings.MirrorCalculationForBack) ? SortByYDistance(list2, new DrillCalcItem(), SortDirection.LowerToBigger) : SortByYDistance(list2, new DrillCalcItem(), SortDirection.BiggerToLower));
			}
			if (list3.Count > 0)
			{
				list3 = SortByYDistance(list3, new DrillCalcItem(), SortDirection.LowerToBigger);
			}
			num2 = list2.Count;
			if (list3.Count > num2)
			{
				num2 = list3.Count;
			}
			if (list2.Count >= 2 && clsInit.cDrill.isMultiZAvailable(list2))
			{
				List<List<DrillCalcItem>> SplitedItems = new List<List<DrillCalcItem>>();
				clsInit.cDrill.SplitDrillsByYDistanceThenSortZDir(list2, SortDirection.LowerToBigger, ref SplitedItems);
				if (SplitedItems.Count > 0)
				{
					list2 = new List<DrillCalcItem>();
					for (int k = 0; k <= SplitedItems.Count - 1; k++)
					{
						for (int l = 0; l <= SplitedItems[k].Count - 1; l++)
						{
							list2.Add(new DrillCalcItem(SplitedItems[k][l]));
						}
					}
				}
			}
			if (list3.Count >= 2 && clsInit.cDrill.isMultiZAvailable(list3))
			{
				List<List<DrillCalcItem>> SplitedItems2 = new List<List<DrillCalcItem>>();
				clsInit.cDrill.SplitDrillsByYDistanceThenSortZDir(list3, SortDirection.LowerToBigger, ref SplitedItems2);
				if (SplitedItems2.Count > 0)
				{
					list3 = new List<DrillCalcItem>();
					for (int m = 0; m <= SplitedItems2.Count - 1; m++)
					{
						for (int n = 0; n <= SplitedItems2[m].Count - 1; n++)
						{
							list3.Add(new DrillCalcItem(SplitedItems2[m][n]));
						}
					}
				}
			}
			for (int num3 = 0; num3 <= num2 - 1; num3++)
			{
				DrillFound Found = new DrillFound();
				for (int num4 = 0; num4 <= clsDrill.ToolList.Count - 1; num4++)
				{
					clsDrill.ToolList[num4].Data.Used = false;
				}
				List<int> Y1GroupTool = new List<int>();
				List<int> Y1GroupTool2 = new List<int>();
				int T = 0;
				int T2 = 0;
				int T3 = 0;
				int T4 = 0;
				int T5 = 0;
				int T6 = 0;
				int T7 = 0;
				int T8 = 0;
				int T9 = 0;
				int T10 = 0;
				int T11 = 0;
				int T12 = 0;
				int num5 = 0;
				FindToolSettings findToolSettings = new FindToolSettings();
				findToolSettings.Plane = planeBoxNames.Back;
				findToolSettings.SetAsUsed = true;
				ToolBase5 foundTool = null;
				ToolBase5 foundTool2 = null;
				if (((num3 <= list3.Count - 1) & (list3.Count > 0)) && !list3[num3].Calculated)
				{
					num5 = 0;
					clsInit.cDrill.isHorizontalDrillAvailabe(list3, list3[num3], clsDrill.varDrillCNCSettings.ToolRepeatDistance, num3, ref num5);
					FindToolFromBlock(list3[num3], 1, findToolSettings, SortDirection.BiggerToLower, ref foundTool2);
					if (foundTool2 != null)
					{
						int num6 = SetValueToAvailableTool(foundTool2.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
						if (num6 <= 0)
						{
							calcErrorList.Add("Top Surface Y2 Group Tool Set Limit Full - Tool No : " + foundTool2.Data.No + " - Position : " + list3[num3].Center.ToString());
						}
						else
						{
							list3[num3].Calculated = true;
							list3[num3].OffsetedPoint.Y = list3[num3].Center.Y - foundTool2.Positions.Offset.Y;
							list3[num3].HeadNo = 2;
							DrillFound.Add(list3[num3], foundTool2.Data.No, ref Found);
							SetAsUsedToolByNo(foundTool2.Data.No, ref clsDrill.ToolList);
							SetAsCalculatedDrillItemByID(list3[num3].ID);
						}
					}
					if (foundTool2 != null)
					{
						for (int num7 = num3 + 1; num7 <= list3.Count - 1; num7++)
						{
							double num8 = list3[num7].Center.Y - list3[num3].Center.Y;
							double value = num8 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
							if (!((num8 > 0.0) & !list3[num7].Calculated & buCompare5.EQ(value, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(list3[num3], list3[num7])))
							{
								continue;
							}
							for (int num9 = 0; num9 <= clsDrill.ToolList.Count - 1; num9++)
							{
								if (!((foundTool2.Data.GroupIndex == clsDrill.ToolList[num9].Data.GroupIndex) & !clsDrill.ToolList[num9].Data.Used & (clsDrill.ToolList[num9].Geometry.Diameter == list3[num7].Diameter) & (clsDrill.ToolList[num9].Geometry.ToolDirection.X == 1.0)))
								{
									continue;
								}
								double value2 = clsDrill.ToolList[num9].Positions.Offset.Y - foundTool2.Positions.Offset.Y;
								if (buCompare5.EQ(value2, num8, 0.05))
								{
									int num10 = SetValueToAvailableTool(clsDrill.ToolList[num9].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool2, ref Y1GroupTool2);
									if (num10 > 0)
									{
										list3[num7].OffsetedPoint.Y = list3[num7].Center.Y - clsDrill.ToolList[num9].Positions.Offset.Y;
										list3[num7].HeadNo = 2;
										list3[num7].Calculated = true;
										clsDrill.ToolList[num9].Data.Used = true;
										DrillFound.Add(list3[num7], clsDrill.ToolList[num9].Data.No, ref Found);
										SetAsCalculatedDrillItemByID(list3[num7].ID);
									}
									if (num10 < 1)
									{
										calcErrorList.Add("Top Surface Y2 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num9].Data.No + " - Position : " + list3[num7].Center.ToString());
									}
									num9 = clsDrill.ToolList.Count;
								}
							}
						}
					}
				}
				if (((num3 <= list2.Count - 1) & (list2.Count > 0)) && !list2[num3].Calculated)
				{
					num5 = 0;
					clsInit.cDrill.isHorizontalDrillAvailabe(list2, list2[num3], clsDrill.varDrillCNCSettings.ToolRepeatDistance, num3, ref num5);
					if (clsDrill.varDrillCNCSettings.MirrorCalculationForBack)
					{
						FindToolFromBlock(list2[num3], 0, findToolSettings, SortDirection.BiggerToLower, ref foundTool);
					}
					else
					{
						FindToolFromBlock(list2[num3], 0, findToolSettings, ref foundTool);
					}
					if (foundTool != null)
					{
						int num11 = SetValueToAvailableTool(foundTool.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
						if (num11 <= 0)
						{
							calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + foundTool.Data.No + " - Position : " + list2[num3].Center.ToString());
						}
						else
						{
							list2[num3].Calculated = true;
							list2[num3].OffsetedPoint.Y = list2[num3].Center.Y - foundTool.Positions.Offset.Y;
							list2[num3].HeadNo = 1;
							DrillFound.Add(list2[num3], foundTool.Data.No, ref Found);
							SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
							SetAsCalculatedDrillItemByID(list2[num3].ID);
						}
					}
					if (foundTool != null)
					{
						for (int num12 = num3 + 1; num12 <= list2.Count - 1; num12++)
						{
							double num13 = list2[num12].Center.Y - list2[num3].Center.Y;
							if (clsDrill.varDrillCNCSettings.MirrorCalculationForBack)
							{
								num13 = list2[num3].Center.Y - list2[num12].Center.Y;
							}
							double value3 = num13 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
							if (!((num13 > 0.0) & !list2[num12].Calculated & buCompare5.EQ(value3, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(list2[num3], list2[num12])))
							{
								continue;
							}
							for (int num14 = 0; num14 <= clsDrill.ToolList.Count - 1; num14++)
							{
								if (!((foundTool.Data.GroupIndex == clsDrill.ToolList[num14].Data.GroupIndex) & !clsDrill.ToolList[num14].Data.Used & (clsDrill.ToolList[num14].Geometry.Diameter == list2[num12].Diameter) & (clsDrill.ToolList[num14].Geometry.ToolDirection.X == 1.0)))
								{
									continue;
								}
								double value4 = clsDrill.ToolList[num14].Positions.Offset.Y - foundTool.Positions.Offset.Y;
								if (clsDrill.varDrillCNCSettings.MirrorCalculationForBack)
								{
									value4 = foundTool.Positions.Offset.Y - clsDrill.ToolList[num14].Positions.Offset.Y;
								}
								if (buCompare5.EQ(value4, num13, 0.05))
								{
									int num15 = SetValueToAvailableTool(clsDrill.ToolList[num14].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y1GroupTool2);
									if (num15 > 0)
									{
										list2[num12].Calculated = true;
										list2[num12].OffsetedPoint.Y = list2[num12].Center.Y - clsDrill.ToolList[num14].Positions.Offset.Y;
										list2[num12].HeadNo = 1;
										clsDrill.ToolList[num14].Data.Used = true;
										DrillFound.Add(list2[num12], clsDrill.ToolList[num14].Data.No, ref Found);
										SetAsCalculatedDrillItemByID(list2[num12].ID);
									}
									if (num15 < 1)
									{
										calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num14].Data.No + " - Position : " + list2[num12].Center.ToString());
									}
									num14 = clsDrill.ToolList.Count;
								}
							}
						}
					}
				}
				if (Found.Items.Count > 0)
				{
					FoundDrills.Add(Found);
				}
			}
		}
	}

	public void FindHolesForTopSide()
	{
		double num = clsDrill.varDrillCNCSettings.Y1MinLimit;
		int num2 = 0;
		if (clsDrill.activeJob.Material.Size.Height > clsDrill.varDrillCNCSettings.DoubleHeadWorkTogetherLimit)
		{
			num = clsDrill.activeJob.Material.Size.Height / 2.0;
		}
		for (int i = 0; i <= SplitedItems.lstTop.Count - 1; i++)
		{
			bool flag = true;
			bool flag2 = true;
			List<DrillCalcItem> list = SplitedItems.lstTop[i];
			List<DrillCalcItem> list2 = null;
			if (i < SplitedItems.lstTop.Count - 1)
			{
				list2 = SplitedItems.lstTop[i + 1];
			}
			List<DrillCalcItem> list3 = new List<DrillCalcItem>();
			List<DrillCalcItem> list4 = new List<DrillCalcItem>();
			List<DrillCalcItem> list5 = new List<DrillCalcItem>();
			List<DrillCalcItem> list6 = new List<DrillCalcItem>();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				if (!list[j].Calculated)
				{
					if (!(list[j].Center.Y < clsDrill.activeJob.Material.Size.Height))
					{
						list4.Add(new DrillCalcItem(list[j]));
					}
					else if (!(list[j].Center.Y >= num))
					{
						list4.Add(new DrillCalcItem(list[j]));
					}
					else
					{
						list3.Add(new DrillCalcItem(list[j]));
					}
				}
			}
			if (list2 != null)
			{
				for (int k = 0; k <= list2.Count - 1; k++)
				{
					if (!list2[k].Calculated)
					{
						if (!(list2[k].Center.Y < clsDrill.activeJob.Material.Size.Height))
						{
							list6.Add(new DrillCalcItem(list2[k]));
						}
						else if (!(list2[k].Center.Y >= num))
						{
							list6.Add(new DrillCalcItem(list2[k]));
						}
						else
						{
							list5.Add(new DrillCalcItem(list2[k]));
						}
					}
				}
			}
			if (list3.Count > 0)
			{
				list3 = ((!clsDrill.varDrillCNCSettings.MirrorCalculationForTop) ? SortByYDistance(list3, new DrillCalcItem(), SortDirection.LowerToBigger) : SortByYDistance(list3, new DrillCalcItem(), SortDirection.BiggerToLower));
			}
			if (list4.Count > 0)
			{
				list4 = SortByYDistance(list4, new DrillCalcItem(), SortDirection.LowerToBigger);
			}
			num2 = list3.Count;
			if (list4.Count > num2)
			{
				num2 = list4.Count;
			}
			for (int l = 0; l <= num2 - 1; l++)
			{
				DrillFound Found = new DrillFound();
				for (int m = 0; m <= clsDrill.ToolList.Count - 1; m++)
				{
					clsDrill.ToolList[m].Data.Used = false;
				}
				List<int> Y1GroupTool = new List<int>();
				List<int> Y2GroupTool = new List<int>();
				int T = 0;
				int T2 = 0;
				int T3 = 0;
				int T4 = 0;
				int T5 = 0;
				int T6 = 0;
				int T7 = 0;
				int T8 = 0;
				int T9 = 0;
				int T10 = 0;
				int T11 = 0;
				int T12 = 0;
				int Count = 0;
				int Count2 = 0;
				bool flag3 = true;
				FindToolSettings findToolSettings = new FindToolSettings();
				findToolSettings.Plane = planeBoxNames.Top;
				findToolSettings.SetAsUsed = true;
				ToolBase5 foundTool = null;
				ToolBase5 foundTool2 = null;
				if ((l <= list3.Count - 1) & (list3.Count > 0))
				{
					flag3 = true;
					if (!list3[l].Calculated)
					{
						if (list3[l].NumberNextVerticalItem > 0)
						{
							findToolSettings.SelectVerticalTools = true;
						}
						double MaxYDistance = 0.0;
						clsInit.cDrill.isHorizontalDrillAvailabe(list3, list3[l], clsDrill.varDrillCNCSettings.ToolRepeatDistance, l, ref Count, ref MaxYDistance);
						clsInit.cDrill.isVerticalDrillAvailable(list3[l], SplitedItems.lstTop, clsDrill.varDrillCNCSettings.ToolRepeatDistance, i, ref Count2);
						if (Count <= 0)
						{
							if (Count2 <= 0)
							{
								findToolSettings.StartToolIndex = 66;
								FindToolFromBlock(list3[l], 0, findToolSettings, SortDirection.LowerToBigger, ref foundTool);
								if (foundTool == null)
								{
									FindToolFromBlock(list3[l], 0, findToolSettings, SortDirection.BiggerToLower, ref foundTool);
								}
							}
							else
							{
								findToolSettings.StartToolIndex = 66;
								FindToolFromBlock(list3[l], 0, findToolSettings, SortDirection.LowerToBigger, ref foundTool);
							}
						}
						else
						{
							Convert.ToInt32(MaxYDistance / clsDrill.varDrillCNCSettings.ToolRepeatDistance);
							if (!clsDrill.varDrillCNCSettings.MirrorCalculationForTop)
							{
								findToolSettings.StartToolIndex = 66;
							}
							else
							{
								findToolSettings.StartToolIndex = 61;
							}
							if (!clsDrill.varDrillCNCSettings.MirrorCalculationForTop)
							{
								FindToolFromBlock(list3[l], 0, findToolSettings, SortDirection.BiggerToLower, ref foundTool);
							}
							else
							{
								FindToolFromBlock(list3[l], 0, findToolSettings, SortDirection.LowerToBigger, ref foundTool);
							}
						}
						if (foundTool == null)
						{
							findToolSettings.StartToolIndex = 60;
							FindToolFromBlock(list3[l], 0, findToolSettings, ref foundTool);
						}
						if (foundTool != null)
						{
							int num3 = SetValueToAvailableTool(foundTool.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
							if (num3 <= 0)
							{
								calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + foundTool.Data.No + " - Position : " + list3[l].Center.ToString());
							}
							else
							{
								list3[l].Calculated = true;
								list3[l].HeadNo = 1;
								list3[l].OffsetedPoint.Y = list3[l].Center.Y - foundTool.Positions.Offset.Y;
								DrillFound.Add(list3[l], foundTool.Data.No, ref Found);
								SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
								SetAsCalculatedDrillItemByID(list3[l].ID);
							}
						}
						if (foundTool != null)
						{
							for (int n = l + 1; n <= list3.Count - 1; n++)
							{
								double num4 = list3[n].Center.Y - list3[l].Center.Y;
								if (!flag)
								{
									num4 = list3[l].Center.Y - list3[n].Center.Y;
								}
								double value = num4 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
								if (!(buCompare5.EQ(value, 0.0, 0.05) & !list3[n].Calculated & clsInit.cDrill.isDrillSameForSameLine(list3[l], list3[n])))
								{
									continue;
								}
								for (int num5 = 0; num5 <= clsDrill.ToolList.Count - 1; num5++)
								{
									if (!((foundTool.Data.GroupIndex == clsDrill.ToolList[num5].Data.GroupIndex) & !clsDrill.ToolList[num5].Data.Used & (clsDrill.ToolList[num5].Geometry.Diameter == list3[n].Diameter) & (clsDrill.ToolList[num5].Geometry.ToolDirection.Z == -1.0)))
									{
										continue;
									}
									double value2 = clsDrill.ToolList[num5].Positions.Offset.Y - foundTool.Positions.Offset.Y;
									if (clsDrill.varDrillCNCSettings.MirrorCalculationForTop)
									{
										value2 = clsDrill.ToolList[num5].Positions.Offset.Y - foundTool.Positions.Offset.Y;
									}
									if (buCompare5.EQ(value2, num4, 0.05))
									{
										int num6 = SetValueToAvailableTool(clsDrill.ToolList[num5].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y2GroupTool);
										if (num6 > 0)
										{
											list3[n].Calculated = true;
											list3[n].HeadNo = 1;
											list3[n].OffsetedPoint.Y = list3[n].Center.Y - clsDrill.ToolList[num5].Positions.Offset.Y;
											clsDrill.ToolList[num5].Data.Used = true;
											DrillFound.Add(list3[n], clsDrill.ToolList[num5].Data.No, ref Found);
											SetAsCalculatedDrillItemByID(list3[n].ID);
										}
										if (num6 < 1)
										{
											calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num5].Data.No + " - Position : " + list3[n].Center.ToString());
										}
										num5 = clsDrill.ToolList.Count;
									}
								}
							}
						}
						if ((Count > 0) & !clsDrill.varDrillCNCSettings.SearchVerToolEvenMultiHorDrillAvailableForTop)
						{
							flag3 = false;
						}
						if (foundTool != null && Count2 > 0 && flag3 && list3.Count > 0)
						{
							List<DrillCalcItem> foundItems = new List<DrillCalcItem>();
							clsInit.cDrill.FindNextVerticalDrill(SplitedItems.lstTop, list3[l], i + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems);
							for (int num7 = 0; num7 <= foundItems.Count - 1; num7++)
							{
								double value3 = foundItems[num7].Center.X - list3[l].Center.X;
								for (int num8 = 0; num8 <= clsDrill.ToolList.Count - 1; num8++)
								{
									if (!(!foundItems[num7].Calculated & (foundTool.Data.GroupIndex == clsDrill.ToolList[num8].Data.GroupIndex) & !clsDrill.ToolList[num8].Data.Used & (clsDrill.ToolList[num8].Geometry.Diameter == foundItems[num7].Diameter) & (clsDrill.ToolList[num8].Geometry.ToolDirection.Z == -1.0)))
									{
										continue;
									}
									double value4 = foundTool.Positions.Offset.X - clsDrill.ToolList[num8].Positions.Offset.X;
									double value5 = foundTool.Positions.Offset.Y - clsDrill.ToolList[num8].Positions.Offset.Y;
									if (buCompare5.EQ(value3, value4, 0.05) & buCompare5.EQ(value5, 0.0, 0.05))
									{
										int num9 = SetValueToAvailableTool(clsDrill.ToolList[num8].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y2GroupTool);
										if (num9 > 0)
										{
											foundItems[num7].HeadNo = 1;
											foundItems[num7].OffsetedPoint.Y = foundItems[num7].Center.Y - clsDrill.ToolList[num8].Positions.Offset.Y;
											DrillFound.Add(foundItems[num7], clsDrill.ToolList[num8].Data.No, ref Found);
											SetAsCalculatedDrillItemByID(foundItems[num7].ID);
											clsDrill.ToolList[num8].Data.Used = true;
										}
										if (num9 < 1)
										{
											calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num8].Data.No + " - Position : " + foundItems[num7].Center.ToString());
										}
										num8 = clsDrill.ToolList.Count;
									}
								}
							}
						}
					}
				}
				if ((l <= list4.Count - 1) & (list4.Count > 0))
				{
					flag3 = true;
					if (!list4[l].Calculated)
					{
						if (list4[l].NumberNextVerticalItem > 0)
						{
							findToolSettings.SelectVerticalTools = true;
						}
						Count = 0;
						Count2 = 0;
						double MaxYDistance2 = 0.0;
						clsInit.cDrill.isHorizontalDrillAvailabe(list4, list4[l], clsDrill.varDrillCNCSettings.ToolRepeatDistance, l, ref Count, ref MaxYDistance2);
						clsInit.cDrill.isVerticalDrillAvailable(list4[l], SplitedItems.lstTop, clsDrill.varDrillCNCSettings.ToolRepeatDistance, i, ref Count2);
						if (Count2 > 0 && Count == 0)
						{
							findToolSettings.StartToolIndex = 166;
						}
						if (Count > 0)
						{
							Convert.ToInt32(MaxYDistance2 / clsDrill.varDrillCNCSettings.ToolRepeatDistance);
							findToolSettings.StartToolIndex = 161;
						}
						FindToolFromBlock(list4[l], 1, findToolSettings, ref foundTool2);
						if (foundTool2 == null)
						{
							findToolSettings.StartToolIndex = 160;
							FindToolFromBlock(list4[l], 1, findToolSettings, ref foundTool2);
						}
						if (foundTool2 != null)
						{
							int num10 = SetValueToAvailableTool(foundTool2.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
							if (num10 <= 0)
							{
								calcErrorList.Add("Top Surface Y2 Group Tool Set Limit Full - Tool No : " + foundTool2.Data.No + " - Position : " + list4[l].Center.ToString());
							}
							else
							{
								list4[l].Calculated = true;
								list4[l].HeadNo = 2;
								list4[l].OffsetedPoint.Y = list4[l].Center.Y - foundTool2.Positions.Offset.Y;
								DrillFound.Add(list4[l], foundTool2.Data.No, ref Found);
								SetAsUsedToolByNo(foundTool2.Data.No, ref clsDrill.ToolList);
								SetAsCalculatedDrillItemByID(list4[l].ID);
							}
						}
						if (foundTool2 != null)
						{
							for (int num11 = l + 1; num11 <= list4.Count - 1; num11++)
							{
								double num12 = list4[num11].Center.Y - list4[l].Center.Y;
								if (!flag2)
								{
									num12 = list4[l].Center.Y - list4[num11].Center.Y;
								}
								double value6 = num12 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
								if (!(buCompare5.EQ(value6, 0.0, 0.05) & !list4[num11].Calculated & clsInit.cDrill.isDrillSameForSameLine(list4[l], list4[num11])))
								{
									continue;
								}
								for (int num13 = 0; num13 <= clsDrill.ToolList.Count - 1; num13++)
								{
									if (!((foundTool2.Data.GroupIndex == clsDrill.ToolList[num13].Data.GroupIndex) & !clsDrill.ToolList[num13].Data.Used & (clsDrill.ToolList[num13].Geometry.Diameter == list4[num11].Diameter) & (clsDrill.ToolList[num13].Geometry.ToolDirection.Z == -1.0)))
									{
										continue;
									}
									double value7 = clsDrill.ToolList[num13].Positions.Offset.Y - foundTool2.Positions.Offset.Y;
									if (foundTool2.Data.No >= clsDrill.ToolList[num13].Data.No)
									{
									}
									if (buCompare5.EQ(value7, num12, 0.05))
									{
										int num14 = SetValueToAvailableTool(clsDrill.ToolList[num13].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y2GroupTool, ref Y2GroupTool);
										if (num14 > 0)
										{
											list4[num11].Calculated = true;
											list4[num11].HeadNo = 2;
											list4[num11].OffsetedPoint.Y = list4[num11].Center.Y - clsDrill.ToolList[num13].Positions.Offset.Y;
											clsDrill.ToolList[num13].Data.Used = true;
											DrillFound.Add(list4[num11], clsDrill.ToolList[num13].Data.No, ref Found);
											SetAsCalculatedDrillItemByID(list4[num11].ID);
										}
										if (num14 < 1)
										{
											calcErrorList.Add("Top Surface Y2 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num13].Data.No + " - Position : " + list4[num11].Center.ToString());
										}
										num13 = clsDrill.ToolList.Count;
									}
								}
							}
						}
						if ((Count > 0) & !clsDrill.varDrillCNCSettings.SearchVerToolEvenMultiHorDrillAvailableForTop)
						{
							flag3 = false;
						}
						if (foundTool2 != null && Count2 > 0 && Count == 0 && list4.Count > 0)
						{
							List<DrillCalcItem> foundItems2 = new List<DrillCalcItem>();
							clsInit.cDrill.FindNextVerticalDrill(SplitedItems.lstTop, list4[l], i + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems2);
							for (int num15 = 0; num15 <= foundItems2.Count - 1; num15++)
							{
								double value8 = foundItems2[num15].Center.X - list4[l].Center.X;
								double value9 = foundItems2[num15].Center.Y - list4[l].Center.Y;
								for (int num16 = 0; num16 <= clsDrill.ToolList.Count - 1; num16++)
								{
									if (!(!foundItems2[num15].Calculated & (foundTool2.Data.GroupIndex == clsDrill.ToolList[num16].Data.GroupIndex) & !clsDrill.ToolList[num16].Data.Used & (clsDrill.ToolList[num16].Geometry.Diameter == foundItems2[num15].Diameter) & (clsDrill.ToolList[num16].Geometry.ToolDirection.Z == -1.0)))
									{
										continue;
									}
									double value10 = foundTool2.Positions.Offset.X - clsDrill.ToolList[num16].Positions.Offset.X;
									double value11 = foundTool2.Positions.Offset.Y - clsDrill.ToolList[num16].Positions.Offset.Y;
									if (buCompare5.EQ(value8, value10, 0.05) & buCompare5.EQ(value9, value11, 0.05))
									{
										int num17 = SetValueToAvailableTool(clsDrill.ToolList[num16].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y2GroupTool, ref Y2GroupTool);
										if (num17 > 0)
										{
											foundItems2[num15].HeadNo = 2;
											foundItems2[num15].OffsetedPoint.Y = foundItems2[num15].Center.Y - clsDrill.ToolList[num16].Positions.Offset.Y;
											DrillFound.Add(foundItems2[num15], clsDrill.ToolList[num16].Data.No, ref Found);
											SetAsCalculatedDrillItemByID(foundItems2[num15].ID);
											clsDrill.ToolList[num16].Data.Used = true;
										}
										if (num17 < 1)
										{
											calcErrorList.Add("Top Surface Y2 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num16].Data.No + " - Position : " + foundItems2[num15].Center.ToString());
										}
										num16 = clsDrill.ToolList.Count;
									}
								}
							}
						}
					}
				}
				if (Found.Items.Count > 0)
				{
					FoundDrills.Add(Found);
				}
			}
		}
	}

	public void FindHolesForBottomSide()
	{
		for (int i = 0; i <= SplitedItems.lstBottom.Count - 1; i++)
		{
			bool flag = true;
			List<DrillCalcItem> list = SplitedItems.lstBottom[i];
			List<DrillCalcItem> list2 = null;
			if (i < SplitedItems.lstBottom.Count - 1)
			{
				list2 = SplitedItems.lstBottom[i + 1];
			}
			List<DrillCalcItem> list3 = new List<DrillCalcItem>();
			List<DrillCalcItem> list4 = new List<DrillCalcItem>();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				if (!list[j].Calculated)
				{
					list3.Add(new DrillCalcItem(list[j]));
				}
			}
			if (list2 != null)
			{
				for (int k = 0; k <= list2.Count - 1; k++)
				{
					if (!list2[k].Calculated)
					{
						list4.Add(new DrillCalcItem(list2[k]));
					}
				}
			}
			if (list3.Count > 0)
			{
				list3 = SortByYDistance(list3, new DrillCalcItem(), SortDirection.LowerToBigger);
				if (list4.Count > 0)
				{
					list4 = SortByYDistance(list4, new DrillCalcItem(), SortDirection.LowerToBigger);
				}
				list3 = (flag ? SortByYDistance(list3, new DrillCalcItem(), SortDirection.LowerToBigger) : SortByYDistance(list3, new DrillCalcItem(), SortDirection.BiggerToLower));
			}
			double num = list3.Count;
			for (int l = 0; (double)l <= num - 1.0; l++)
			{
				DrillFound Found = new DrillFound();
				for (int m = 0; m <= clsDrill.ToolList.Count - 1; m++)
				{
					clsDrill.ToolList[m].Data.Used = false;
				}
				List<int> Y1GroupTool = new List<int>();
				List<int> Y2GroupTool = new List<int>();
				int T = 0;
				int T2 = 0;
				int T3 = 0;
				int T4 = 0;
				int T5 = 0;
				int T6 = 0;
				int T7 = 0;
				int T8 = 0;
				int T9 = 0;
				int T10 = 0;
				int T11 = 0;
				int T12 = 0;
				int Count = 0;
				int Count2 = 0;
				bool flag2 = true;
				FindToolSettings findToolSettings = new FindToolSettings();
				findToolSettings.Plane = planeBoxNames.Bottom;
				findToolSettings.SetAsUsed = true;
				ToolBase5 foundTool = null;
				if ((l <= list3.Count - 1) & (list3.Count > 0))
				{
					flag2 = true;
					if (!list3[l].Calculated)
					{
						if (list3[l].NumberNextVerticalItem > 0)
						{
							findToolSettings.SelectVerticalTools = true;
						}
						double MaxYDistance = 0.0;
						clsInit.cDrill.isHorizontalDrillAvailabe(list3, list3[l], clsDrill.varDrillCNCSettings.ToolRepeatDistance, l, ref Count, ref MaxYDistance);
						clsInit.cDrill.isVerticalDrillAvailable(list3[l], SplitedItems.lstBottom, clsDrill.varDrillCNCSettings.ToolRepeatDistance, i, ref Count2);
						if (Count2 > 0)
						{
							clsInit.cDrill.FindVerticalSameDiameterTools(clsDrill.ToolList, list3[l].Diameter, planeBoxNames.Bottom, ref findToolSettings.StartToolIndex);
						}
						FindToolFromBlock(list3[l], 2, findToolSettings, ref foundTool);
						if (foundTool == null)
						{
							findToolSettings.StartToolIndex = 0;
							FindToolFromBlock(list3[l], 2, findToolSettings, ref foundTool);
						}
						if (foundTool != null)
						{
							int num2 = SetValueToAvailableTool(foundTool.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
							if (num2 <= 0)
							{
								calcErrorList.Add("Bottom Surface Y1 Group Tool Set Limit Full - Tool No : " + foundTool.Data.No + " - Position : " + list3[l].Center.ToString());
							}
							else
							{
								list3[l].Calculated = true;
								list3[l].HeadNo = 3;
								list3[l].OffsetedPoint.Y = list3[l].Center.Y - foundTool.Positions.Offset.Y;
								DrillFound.Add(list3[l], foundTool.Data.No, ref Found);
								SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
								SetAsCalculatedDrillItemByID(list3[l].ID);
							}
						}
						if (foundTool != null)
						{
							for (int n = l + 1; n <= list3.Count - 1; n++)
							{
								double num3 = list3[n].Center.Y - list3[l].Center.Y;
								if (!flag)
								{
									num3 = list3[l].Center.Y - list3[n].Center.Y;
								}
								double value = num3 % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
								if (!(buCompare5.EQ(value, 0.0, 0.05) & !list3[n].Calculated & clsInit.cDrill.isDrillSameForSameLine(list3[l], list3[n])))
								{
									continue;
								}
								for (int num4 = 0; num4 <= clsDrill.ToolList.Count - 1; num4++)
								{
									if (!((foundTool.Data.GroupIndex == clsDrill.ToolList[num4].Data.GroupIndex) & !clsDrill.ToolList[num4].Data.Used & (clsDrill.ToolList[num4].Geometry.Diameter == list3[n].Diameter) & (clsDrill.ToolList[num4].Geometry.ToolDirection.Z == 1.0)))
									{
										continue;
									}
									double value2 = clsDrill.ToolList[num4].Positions.Offset.Y - foundTool.Positions.Offset.Y;
									if (buCompare5.EQ(value2, num3, 0.05))
									{
										int num5 = SetValueToAvailableTool(clsDrill.ToolList[num4].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y2GroupTool);
										if (num5 > 0)
										{
											list3[n].Calculated = true;
											list3[n].HeadNo = 3;
											list3[n].OffsetedPoint.Y = list3[n].Center.Y - clsDrill.ToolList[num4].Positions.Offset.Y;
											clsDrill.ToolList[num4].Data.Used = true;
											DrillFound.Add(list3[n], clsDrill.ToolList[num4].Data.No, ref Found);
											SetAsCalculatedDrillItemByID(list3[n].ID);
										}
										if (num5 < 1)
										{
											calcErrorList.Add("Bottom Surface Y3 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num4].Data.No + " - Position : " + list3[n].Center.ToString());
										}
										num4 = clsDrill.ToolList.Count;
									}
								}
							}
						}
						if ((Count > 0) & !clsDrill.varDrillCNCSettings.SearchVerToolEvenMultiHorDrillAvailableForTop)
						{
							flag2 = false;
						}
						if (foundTool != null && Count2 > 0 && flag2 && list3.Count > 0)
						{
							List<DrillCalcItem> foundItems = new List<DrillCalcItem>();
							clsInit.cDrill.FindNextVerticalDrill(SplitedItems.lstBottom, list3[l], i + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems);
							for (int num6 = 0; num6 <= foundItems.Count - 1; num6++)
							{
								double value3 = foundItems[num6].Center.X - list3[l].Center.X;
								for (int num7 = 0; num7 <= clsDrill.ToolList.Count - 1; num7++)
								{
									if (!(!foundItems[num6].Calculated & (foundTool.Data.GroupIndex == clsDrill.ToolList[num7].Data.GroupIndex) & !clsDrill.ToolList[num7].Data.Used & (clsDrill.ToolList[num7].Geometry.Diameter == foundItems[num6].Diameter) & (clsDrill.ToolList[num7].Geometry.ToolDirection.Z == 1.0)))
									{
										continue;
									}
									double value4 = foundTool.Positions.Offset.X - clsDrill.ToolList[num7].Positions.Offset.X;
									double value5 = foundTool.Positions.Offset.Y - clsDrill.ToolList[num7].Positions.Offset.Y;
									if (buCompare5.EQ(value3, value4, 0.05) & buCompare5.EQ(value5, 0.0, 0.05))
									{
										int num8 = SetValueToAvailableTool(clsDrill.ToolList[num7].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y2GroupTool);
										if (num8 > 0)
										{
											foundItems[num6].HeadNo = 3;
											foundItems[num6].OffsetedPoint.Y = foundItems[num6].Center.Y - clsDrill.ToolList[num7].Positions.Offset.Y;
											DrillFound.Add(foundItems[num6], clsDrill.ToolList[num7].Data.No, ref Found);
											SetAsCalculatedDrillItemByID(foundItems[num6].ID);
											clsDrill.ToolList[num7].Data.Used = true;
										}
										if (num8 < 1)
										{
											calcErrorList.Add("Bottom Surface Y3 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num7].Data.No + " - Position : " + foundItems[num6].Center.ToString());
										}
										num7 = clsDrill.ToolList.Count;
									}
								}
							}
						}
					}
				}
				if (Found.Items.Count > 0)
				{
					FoundDrills.Add(Found);
				}
			}
		}
	}

	public void FindHolesForLeftRightSide()
	{
		int num = 0;
		for (int i = 0; i <= SplitedItems.lstLeftRight.Count - 1; i++)
		{
			List<DrillCalcItem> list = SplitedItems.lstLeftRight[i];
			List<DrillCalcItem> list2 = null;
			if (i < SplitedItems.lstLeftRight.Count - 1)
			{
				list2 = SplitedItems.lstLeftRight[i + 1];
			}
			List<DrillCalcItem> list3 = new List<DrillCalcItem>();
			List<DrillCalcItem> list4 = new List<DrillCalcItem>();
			List<DrillCalcItem> list5 = new List<DrillCalcItem>();
			List<DrillCalcItem> list6 = new List<DrillCalcItem>();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				if (!list[j].Calculated)
				{
					if (list[j].planeName != planeBoxNames.Left)
					{
						list3.Add(new DrillCalcItem(list[j]));
					}
					else
					{
						list4.Add(new DrillCalcItem(list[j]));
					}
				}
			}
			if (list2 != null)
			{
				for (int k = 0; k <= list2.Count - 1; k++)
				{
					if (!list2[k].Calculated)
					{
						if (list2[k].planeName != planeBoxNames.Left)
						{
							list5.Add(new DrillCalcItem(list2[k]));
						}
						else
						{
							list6.Add(new DrillCalcItem(list2[k]));
						}
					}
				}
			}
			num = list3.Count;
			if (list4.Count > num)
			{
				num = list4.Count;
			}
			for (int l = 0; l <= num - 1; l++)
			{
				DrillFound Found = new DrillFound();
				for (int m = 0; m <= clsDrill.ToolList.Count - 1; m++)
				{
					clsDrill.ToolList[m].Data.Used = false;
				}
				List<int> Y1GroupTool = new List<int>();
				List<int> Y2GroupTool = new List<int>();
				int T = 0;
				int T2 = 0;
				int T3 = 0;
				int T4 = 0;
				int T5 = 0;
				int T6 = 0;
				int T7 = 0;
				int T8 = 0;
				int T9 = 0;
				int T10 = 0;
				int T11 = 0;
				int T12 = 0;
				int Count = 0;
				FindToolSettings findToolSettings = new FindToolSettings();
				findToolSettings.SetAsUsed = true;
				ToolBase5 foundTool = null;
				ToolBase5 foundTool2 = null;
				findToolSettings.Plane = planeBoxNames.Right;
				if (((l <= list3.Count - 1) & (list3.Count > 0)) && !list3[l].Calculated)
				{
					if (list3[l].NumberNextVerticalItem > 0)
					{
						findToolSettings.SelectVerticalTools = true;
					}
					clsInit.cDrill.isVerticalDrillAvailable(list3[l], SplitedItems.lstLeftRight, clsDrill.varDrillCNCSettings.ToolRepeatDistance, i, ref Count);
					FindToolFromBlock(list3[l], 0, findToolSettings, ref foundTool);
					if (foundTool != null)
					{
						int num2 = SetValueToAvailableTool(foundTool.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
						if (num2 <= 0)
						{
							calcErrorList.Add("Right Surface Y1 Group Tool Set Limit Full - Tool No : " + foundTool.Data.No + " - Position : " + list3[l].Center.ToString());
						}
						else
						{
							list3[l].Calculated = true;
							list3[l].OffsetedPoint.Y = list3[l].Center.Y - foundTool.Positions.Offset.Y;
							list3[l].HeadNo = 1;
							DrillFound.Add(list3[l], foundTool.Data.No, ref Found);
							SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
							SetAsCalculatedDrillItemByID(list3[l].ID);
						}
					}
					if (foundTool != null && Count > 0 && list3.Count > 0)
					{
						List<DrillCalcItem> foundItems = new List<DrillCalcItem>();
						clsInit.cDrill.FindNextVerticalDrill(SplitedItems.lstLeftRight, list3[l], i + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems);
						for (int n = 0; n <= foundItems.Count - 1; n++)
						{
							double value = foundItems[n].Center.X - list3[l].Center.X;
							for (int num3 = 0; num3 <= clsDrill.ToolList.Count - 1; num3++)
							{
								if (!((foundTool.Data.GroupIndex == clsDrill.ToolList[num3].Data.GroupIndex) & !clsDrill.ToolList[num3].Data.Used & (clsDrill.ToolList[num3].Geometry.Diameter == foundItems[n].Diameter) & (clsDrill.ToolList[num3].Geometry.ToolDirection.Y == -1.0)))
								{
									continue;
								}
								double value2 = foundTool.Positions.Offset.X - clsDrill.ToolList[num3].Positions.Offset.X;
								if (buCompare5.EQ(value, value2, 0.05))
								{
									int num4 = SetValueToAvailableTool(clsDrill.ToolList[num3].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y2GroupTool);
									if (num4 > 0)
									{
										foundItems[n].OffsetedPoint.Y = foundItems[n].Center.Y - clsDrill.ToolList[num3].Positions.Offset.Y;
										foundItems[n].HeadNo = 1;
										DrillFound.Add(foundItems[n], clsDrill.ToolList[num3].Data.No, ref Found);
										SetAsCalculatedDrillItemByID(foundItems[n].ID);
										clsDrill.ToolList[num3].Data.Used = true;
									}
									if (num4 < 1)
									{
										calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num3].Data.No + " - Position : " + foundItems[n].Center.ToString());
									}
									num3 = clsDrill.ToolList.Count;
								}
							}
						}
					}
				}
				findToolSettings.Plane = planeBoxNames.Left;
				if (((l <= list4.Count - 1) & (list4.Count > 0)) && !list4[l].Calculated)
				{
					Count = 0;
					clsInit.cDrill.isVerticalDrillAvailable(list4[l], SplitedItems.lstLeftRight, clsDrill.varDrillCNCSettings.ToolRepeatDistance, i, ref Count);
					FindToolFromBlock(list4[l], 1, findToolSettings, ref foundTool2);
					if (foundTool2 != null)
					{
						int num5 = SetValueToAvailableTool(foundTool2.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
						if (num5 <= 0)
						{
							calcErrorList.Add("Left Surface Y2 Group Tool Set Limit Full - Tool No : " + foundTool2.Data.No + " - Position : " + list4[l].Center.ToString());
						}
						else
						{
							list4[l].Calculated = true;
							list4[l].OffsetedPoint.Y = list4[l].Center.Y - foundTool2.Positions.Offset.Y;
							list4[l].HeadNo = 2;
							DrillFound.Add(list4[l], foundTool2.Data.No, ref Found);
							SetAsUsedToolByNo(foundTool2.Data.No, ref clsDrill.ToolList);
							SetAsCalculatedDrillItemByID(list4[l].ID);
						}
					}
					if (foundTool2 != null && Count > 0 && list4.Count > 0)
					{
						List<DrillCalcItem> foundItems2 = new List<DrillCalcItem>();
						clsInit.cDrill.FindNextVerticalDrill(SplitedItems.lstLeftRight, list4[l], i + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems2);
						for (int num6 = 0; num6 <= foundItems2.Count - 1; num6++)
						{
							double value3 = foundItems2[num6].Center.X - list4[l].Center.X;
							for (int num7 = 0; num7 <= clsDrill.ToolList.Count - 1; num7++)
							{
								if (!((foundTool2.Data.GroupIndex == clsDrill.ToolList[num7].Data.GroupIndex) & !clsDrill.ToolList[num7].Data.Used & (clsDrill.ToolList[num7].Geometry.Diameter == foundItems2[num6].Diameter) & (clsDrill.ToolList[num7].Geometry.ToolDirection.Y == 1.0)))
								{
									continue;
								}
								double value4 = foundTool2.Positions.Offset.X - clsDrill.ToolList[num7].Positions.Offset.X;
								if (buCompare5.EQ(value3, value4, 0.05))
								{
									int num8 = SetValueToAvailableTool(clsDrill.ToolList[num7].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y2GroupTool, ref Y2GroupTool);
									if (num8 > 0)
									{
										foundItems2[num6].HeadNo = 2;
										foundItems2[num6].OffsetedPoint.Y = foundItems2[num6].Center.Y - clsDrill.ToolList[num7].Positions.Offset.Y;
										DrillFound.Add(foundItems2[num6], clsDrill.ToolList[num7].Data.No, ref Found);
										SetAsCalculatedDrillItemByID(foundItems2[num6].ID);
										clsDrill.ToolList[num7].Data.Used = true;
									}
									if (num8 < 1)
									{
										calcErrorList.Add("Top Surface Y2 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num7].Data.No + " - Position : " + foundItems2[num6].Center.ToString());
									}
									num7 = clsDrill.ToolList.Count;
								}
							}
						}
					}
				}
				if (Found.Items.Count > 0)
				{
					FoundDrills.Add(Found);
				}
			}
		}
	}

	public void AssingToolOffset()
	{
		for (int i = 0; i <= FoundDrills.Count - 1; i++)
		{
			for (int j = 0; j <= FoundDrills[i].Items.Count - 1; j++)
			{
				double XOffset = 0.0;
				GetXToolOffsetFromNo(FoundDrills[i].Items[j].Tool, ref XOffset);
				double x = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + FoundDrills[i].Items[j].Center.X;
				FoundDrills[i].Items[j].OffsetedPoint.X = x;
			}
		}
	}

	public void MoveBackOperationToLast()
	{
		List<DrillFound> list = new List<DrillFound>();
		for (int num = FoundDrills.Count - 1; num >= 0; num--)
		{
			if (FoundDrills[num].Items[0].planeName == planeBoxNames.Back)
			{
				DrillFound item = new DrillFound(FoundDrills[num]);
				list.Add(item);
				FoundDrills.RemoveAt(num);
			}
		}
		if (list.Count > 0)
		{
			list.Reverse();
			for (int i = 0; i <= list.Count - 1; i++)
			{
				FoundDrills.Add(list[i]);
			}
		}
	}

	public void CreateCodes(ref DrillJob Job)
	{
		AddDrillMove(NoMoveX1, NoMoveX1, NoMoveY1, NoMoveY2, NoMoveY3, clsDrill.varDrillCNCSettings.Z1SafeDistance, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
		for (int i = 0; i <= FoundDrills.Count - 1; i++)
		{
			if (FoundDrills[i].Items[0].planeName == planeBoxNames.Top)
			{
				CreateCodeForTop(ref Job, FoundDrills[i].Items, i);
			}
			if (FoundDrills[i].Items[0].planeName == planeBoxNames.Bottom)
			{
				CreateCodeForBottom(ref Job, FoundDrills[i].Items, i);
			}
			if (FoundDrills[i].Items[0].planeName == planeBoxNames.Front)
			{
				CreateCodeForFront(ref Job, FoundDrills[i].Items, i);
			}
			if (FoundDrills[i].Items[0].planeName == planeBoxNames.Back)
			{
				CreateCodeForBack(ref Job, FoundDrills[i].Items, i);
			}
			if ((FoundDrills[i].Items[0].planeName == planeBoxNames.Left) | (FoundDrills[i].Items[0].planeName == planeBoxNames.Right))
			{
				CreateCodeForLeftRight(ref Job, FoundDrills[i].Items, i);
			}
			if (i >= FoundDrills.Count - 1 || FoundDrills[i + 1].Items.Count <= 0)
			{
				continue;
			}
			double num = FoundDrills[i + 1].Items[0].Center.X - FoundDrills[i].Items[0].Center.X;
			if (Job.Moves[Job.Moves.Count - 1].X2Clamper + num > clsDrill.varDrillMachineSettings.MachineMaxXStroke - 100.0)
			{
				double num2 = FoundDrills[FoundDrills.Count - 1].Items[0].Center.X - Job.Moves[Job.Moves.Count - 1].XPosition + 500.0;
				if (num2 > 1000.0)
				{
					num2 = 1000.0;
				}
				double num3 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num2;
				double newX = Job.Moves[Job.Moves.Count - 1].X2Clamper - num2;
				if (num3 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
				{
					double num4 = num * 0.4;
					double x = Job.Moves[Job.Moves.Count - 1].XPosition + num4;
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num4, Job.Moves[Job.Moves.Count - 1].X2Clamper + num4, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
					double num5 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillMachineSettings.MachineMinXStroke;
					num3 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num5;
					newX = Job.Moves[Job.Moves.Count - 1].X2Clamper - num5;
				}
				MoveClampers(num3, NoMoveX2, drillPlaneNames.Top, ref Job);
				MoveClampers(NoMoveX1, newX, drillPlaneNames.Top, ref Job);
			}
		}
	}

	public void CreateCodeForTop(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
	{
		drillPlaneNames plane = drillPlaneNames.Top;
		DrillCalcItem drillCalcItem = null;
		DrillCalcItem drillCalcItem2 = null;
		DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
		new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
		DrillMoveOptions options = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.ResetAll, DrillMoveCommand.None);
		DrillMoveOptions Option2 = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
		DrillMoveOptions Option3 = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
		double num = 0.0;
		double x = 0.0;
		double num2 = NoMoveY1;
		double num3 = NoMoveY2;
		double noMoveZ = NoMoveZ1;
		double noMoveZ2 = NoMoveZ2;
		double z = NoMoveZ1;
		double z2 = NoMoveZ2;
		double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		double z2SafeDistance = clsDrill.varDrillCNCSettings.Z2SafeDistance;
		double z3 = NoMoveZ1;
		double z4 = NoMoveZ2;
		double ClamperMinXToToolX = 0.0;
		double ClamperMaxXToToolX = 0.0;
		double num4 = 0.0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		List<ToolBase5> list = new List<ToolBase5>();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			if ((drillCalcItem == null) & (Items[i].HeadNo == 1))
			{
				drillCalcItem = Items[i];
				num2 = drillCalcItem.OffsetedPoint.Y;
				noMoveZ = drillCalcItem.Center.Z;
				z3 = noMoveZ - drillCalcItem.Depth;
				z = noMoveZ + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
				num4 = drillCalcItem.Center.X;
			}
			if ((drillCalcItem2 == null) & (Items[i].HeadNo == 2))
			{
				drillCalcItem2 = Items[i];
				num3 = drillCalcItem2.OffsetedPoint.Y;
				noMoveZ2 = drillCalcItem2.Center.Z;
				z4 = noMoveZ2 - drillCalcItem2.Depth;
				z2 = noMoveZ2 + clsDrill.varDrillCNCSettings.Z2SmallSafeDistance;
				num4 = drillCalcItem2.Center.X;
			}
			if (Items[i].HeadNo == 1)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option2);
			}
			if (Items[i].HeadNo == 2)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option3);
			}
			if (drillCalcItem != null && drillCalcItem.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem.Diameter / 2.0)
			{
				flag2 = true;
			}
			if (drillCalcItem2 != null && drillCalcItem2.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem2.Diameter / 2.0)
			{
				flag3 = true;
			}
			if (Items[i].Tool <= 0)
			{
				calcErrorList.Add(buDrillCalc.LangDrillMessage[40] + " - " + clsInit.cDrill.DrillCalcItemToString(Items[i]));
			}
			else
			{
				ToolBase5 foundTool = new ToolBase5();
				if (FindToolWithToolNo(Items[i].Tool, ref foundTool))
				{
					list.Add(foundTool);
				}
			}
			SetValueToAvailableTool(Items[i].Tool, ref Option);
		}
		if (drillCalcItem == null)
		{
			if (drillCalcItem2 != null)
			{
				num = drillCalcItem2.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
				x = drillCalcItem2.OffsetedPoint.X;
			}
		}
		else
		{
			num = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			x = drillCalcItem.OffsetedPoint.X;
		}
		if ((flag2 || flag3) && clsDrill.varDrillCNCSettings.MoveSafeDistanceAtClamperSideForTop)
		{
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
			flag = true;
		}
		if ((flag2 || flag3) & !Job.isSingleClamper)
		{
			double num5 = 0.0;
			if (Index < FoundDrills.Count - 1)
			{
				for (int j = Index + 1; j <= FoundDrills.Count - 1; j++)
				{
					for (int k = 0; k <= FoundDrills[j].Items.Count - 1; k++)
					{
						if (FoundDrills[j].Items[k].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + FoundDrills[j].Items[k].Diameter / 2.0)
						{
							double num6 = FoundDrills[j].Items[k].Center.X - num4;
							if (num6 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && ((FoundDrills[j].Items[k].planeName == planeBoxNames.Top) | (FoundDrills[j].Items[k].planeName == planeBoxNames.Left)) && num6 > num5)
							{
								num5 = num6;
							}
						}
					}
				}
			}
			if (isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + num, list, ref ClamperMinXToToolX, ref ClamperMaxXToToolX))
			{
				if (!flag)
				{
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
					flag = true;
				}
				double num7 = Job.Moves[Job.Moves.Count - 1].X2Clamper + ClamperMinXToToolX;
				if (num7 > Job.Moves[Job.Moves.Count - 1].XPosition && clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - (num7 - Job.Moves[Job.Moves.Count - 1].XPosition) < 40.0)
				{
					num7 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num5;
				}
				if (num7 > Job.Moves[Job.Moves.Count - 1].XPosition)
				{
					double num8 = num7 - Job.Moves[Job.Moves.Count - 1].XPosition;
					if (num8 > clsDrill.varDrillCNCSettings.ClamperLength / 2.0 * 0.75)
					{
						num7 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num5;
					}
				}
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
				double num9 = num7 - Job.Moves[Job.Moves.Count - 1].X1Clamper;
				if (num9 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					double num10 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					MoveClampers(num7 - num10, NoMove, plane, ref Job);
				}
				MoveClampers(NoMove, num7, plane, ref Job);
			}
			if (isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, list, ref ClamperMinXToToolX, ref ClamperMaxXToToolX))
			{
				if (!flag)
				{
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
					flag = true;
				}
				double num11 = Job.Moves[Job.Moves.Count - 1].X1Clamper + ClamperMinXToToolX;
				double num12 = Job.Moves[Job.Moves.Count - 1].X1Clamper - ClamperMaxXToToolX;
				bool flag5 = false;
				if (num12 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 < Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width)
				{
					flag5 = true;
				}
				double num13 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num11;
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
				if (!(num13 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance))
				{
					MoveClampers(num11, NoMoveX2, plane, ref Job);
				}
				else
				{
					double num14 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					double num15 = num11 + num14;
					bool flag6 = false;
					if (num15 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 > Job.Moves[Job.Moves.Count - 1].XPosition)
					{
						flag6 = true;
					}
					if (!flag5)
					{
						MoveClampers(num12, NoMoveX2, plane, ref Job);
					}
					else if (!(num15 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperCatchDistanceInsideFromMaterial < Job.Moves[Job.Moves.Count - 1].XPosition))
					{
						if (flag6)
						{
							calcErrorList.Add(buDrillCalc.LangDrillMessage[40] + " - ");
						}
						else if (!(num15 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperCatchDistanceInsideFromMaterial / 2.0 < Job.Moves[Job.Moves.Count - 1].XPosition))
						{
							if (!(num15 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperCatchDistanceInsideFromMaterial / 4.0 < Job.Moves[Job.Moves.Count - 1].XPosition))
							{
								calcErrorList.Add(buDrillCalc.LangDrillMessage[40] + " - ");
							}
							else
							{
								MoveClampers(NoMoveX1, num15, plane, ref Job);
								MoveClampers(num11, NoMoveX2, plane, ref Job);
							}
						}
						else
						{
							MoveClampers(NoMoveX1, num15, plane, ref Job);
							MoveClampers(num11, NoMoveX2, plane, ref Job);
						}
					}
					else
					{
						MoveClampers(NoMoveX1, num15, plane, ref Job);
						MoveClampers(num11, NoMoveX2, plane, ref Job);
					}
				}
			}
		}
		if (!(drillCalcItem != null && drillCalcItem2 != null))
		{
			if (!(drillCalcItem != null && drillCalcItem2 == null))
			{
				if (drillCalcItem == null && drillCalcItem2 != null && Job.Moves[Job.Moves.Count - 1].Y1Position - num3 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
				{
					num2 = num3 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
				}
			}
			else if (num2 - Job.Moves[Job.Moves.Count - 1].Y2Position < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
			{
				num3 = num2 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			}
		}
		else if (num2 - num3 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
		{
			flag4 = true;
		}
		if (flag4)
		{
			double num16 = num3;
			num3 = num2 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, num2, num3, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option2, ref Job);
			DrillMoveOptions drillMoveOptions = new DrillMoveOptions(Option);
			drillMoveOptions.Mode = DrillCNCMode.Plunge;
			drillMoveOptions.Cmd2 = DrillMoveCommand.None;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z3, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, ref Job);
			Option2.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option2, ref Job);
			num3 = num16;
			num2 = num3 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			AddDrillMove(NoMoveX1, NoMoveX2, num2, num3, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option3, ref Job);
			drillMoveOptions = new DrillMoveOptions(Option);
			drillMoveOptions.Mode = DrillCNCMode.Plunge;
			drillMoveOptions.Cmd2 = DrillMoveCommand.None;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, z4, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, ref Job);
			Option3.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option3, ref Job);
		}
		else
		{
			Option.Cmd2 = DrillMoveCommand.None;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, num2, num3, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, x, Option, ref Job);
			Option.Cmd2 = DrillMoveCommand.SetPiston;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
			DrillMoveOptions drillMoveOptions2 = new DrillMoveOptions(Option);
			drillMoveOptions2.Mode = DrillCNCMode.Plunge;
			drillMoveOptions2.Cmd2 = DrillMoveCommand.None;
			Option.Mode = DrillCNCMode.Plunge;
			Option.Cmd2 = DrillMoveCommand.None;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z3, z4, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
		}
		Option.Mode = DrillCNCMode.Fast;
		if (Index >= FoundDrills.Count - 1)
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			if (!clsDrill.varDrillCNCSettings.ResetDrillPistonWhileMoveSafeAfterDrill)
			{
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			}
			else
			{
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
			}
			return;
		}
		if (FoundDrills[Index + 1].Items[0].planeName != planeBoxNames.Top)
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			if (!clsDrill.varDrillCNCSettings.ResetDrillPistonWhileMoveSafeAfterDrill)
			{
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			}
			else
			{
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
			}
			return;
		}
		if (!clsInit.cDrill.isToolsSameForNextOperation(Items, FoundDrills[Index + 1].Items))
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
		}
		else
		{
			Option.Cmd2 = DrillMoveCommand.None;
			for (int l = 0; l <= Items.Count - 1; l++)
			{
				if (Items[l].Center.Y < clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
				{
					Option.Cmd2 = DrillMoveCommand.ResetAll;
				}
			}
		}
		if (clsDrill.varDrillCNCSettings.ResetDrillPistonWhileMoveSafeAfterDrill)
		{
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			return;
		}
		if (Option.Cmd2 != DrillMoveCommand.ResetAll)
		{
			Option.Cmd2 = DrillMoveCommand.ResetPress;
		}
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
	}

	public void CreateCodeForBottom(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
	{
		DrillCalcItem drillCalcItem = null;
		drillPlaneNames plane = drillPlaneNames.Bottom;
		DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Bottom, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		DrillMoveOptions options = new DrillMoveOptions(drillPlaneNames.Bottom, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.ResetAll, DrillMoveCommand.None);
		double num = 0.0;
		double x = 0.0;
		double num2 = NoMoveY3;
		double noMoveZ = NoMoveZ3;
		double z = NoMoveZ3;
		double z3SafeDistance = clsDrill.varDrillCNCSettings.Z3SafeDistance;
		double z2 = NoMoveZ3;
		double num3 = double.MaxValue;
		double ClamperMinXToToolX = 0.0;
		double ClamperMaxXToToolX = 0.0;
		double num4 = 0.0;
		double noMoveZ2 = NoMoveZ1;
		double noMoveZ3 = NoMoveZ2;
		double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		double z2SafeDistance = clsDrill.varDrillCNCSettings.Z2SafeDistance;
		bool flag = false;
		bool flag2 = false;
		List<ToolBase5> list = new List<ToolBase5>();
		List<DrillCalcItem> CopiedItem = new List<DrillCalcItem>();
		DrillCalcItem.Copy(Items, ref CopiedItem);
		for (int i = 0; i <= CopiedItem.Count - 1; i++)
		{
			if ((drillCalcItem == null) & (CopiedItem[i].HeadNo == 3))
			{
				drillCalcItem = CopiedItem[i];
				num2 = drillCalcItem.OffsetedPoint.Y;
				noMoveZ = drillCalcItem.Center.Z;
				z2 = noMoveZ - drillCalcItem.Depth;
				z = noMoveZ + clsDrill.varDrillCNCSettings.Z3SmallSafeDistance;
				num4 = drillCalcItem.Center.X;
			}
			if (CopiedItem[i].HeadNo == 3)
			{
				SetValueToAvailableTool(CopiedItem[i].Tool, ref Option);
			}
			if (drillCalcItem != null)
			{
				if (drillCalcItem.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem.Diameter / 2.0)
				{
					flag = true;
				}
				if (i == CopiedItem.Count - 1)
				{
					DrillCalcItem.Copy(CopiedItem[i], ref LastCalcItem);
				}
			}
			if (CopiedItem[i].Center.Y < num3)
			{
				num3 = CopiedItem[i].Center.Y;
			}
			if (CopiedItem[i].Tool <= 0)
			{
				calcErrorList.Add("No Defined Tool For This OP");
				continue;
			}
			ToolBase5 foundTool = new ToolBase5();
			if (FindToolWithToolNo(CopiedItem[i].Tool, ref foundTool))
			{
				list.Add(foundTool);
			}
		}
		if (drillCalcItem != null)
		{
			num = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			x = drillCalcItem.OffsetedPoint.X;
		}
		if (flag && Index == 0)
		{
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY3, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, z3SafeDistance, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
		}
		if ((num3 < clsDrill.varDrillCNCSettings.ClamperCatchWidthForBottom + Items[0].Diameter / 2.0) & !Job.isSingleClamper)
		{
			double num5 = 0.0;
			if (Index < FoundDrills.Count - 1)
			{
				for (int j = Index + 1; j <= FoundDrills.Count - 1; j++)
				{
					for (int k = 0; k <= FoundDrills[j].Items.Count - 1; k++)
					{
						if (FoundDrills[j].Items[k].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + FoundDrills[j].Items[k].Diameter / 2.0)
						{
							double num6 = FoundDrills[j].Items[k].Center.X - num4;
							if (num6 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && ((FoundDrills[j].Items[k].planeName == planeBoxNames.Top) | (FoundDrills[j].Items[k].planeName == planeBoxNames.Bottom) | (FoundDrills[j].Items[k].planeName == planeBoxNames.Left)) && num6 > num5)
							{
								num5 = num6;
							}
						}
					}
				}
			}
			if (isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + num, list, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, 50.0))
			{
				double num7 = Job.Moves[Job.Moves.Count - 1].X2Clamper + ClamperMinXToToolX;
				if (num7 > Job.Moves[Job.Moves.Count - 1].XPosition && clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - (num7 - Job.Moves[Job.Moves.Count - 1].XPosition) < 40.0)
				{
					num7 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num5;
				}
				if (num7 > Job.Moves[Job.Moves.Count - 1].XPosition)
				{
					double num8 = num7 - Job.Moves[Job.Moves.Count - 1].XPosition;
					if (num8 > clsDrill.varDrillCNCSettings.ClamperLength / 2.0 * 0.75)
					{
						num7 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num5;
					}
				}
				double value = num7 - Job.Moves[Job.Moves.Count - 1].X2Clamper;
				if (Math.Abs(value) > 0.1)
				{
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY3, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, z3SafeDistance, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
					if (!flag2 & clsDrill.varDrillCNCSettings.LeaveClamperSideWhileClamperChangeForBottom)
					{
						AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, num2 + clsDrill.varDrillCNCSettings.LeaveYDistanceWhileClamperChangeForBottom, NoMoveZ3, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
						flag2 = true;
					}
					double num9 = num7 - Job.Moves[Job.Moves.Count - 1].X1Clamper;
					if (num9 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
					{
						double num10 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
						MoveClampers(num7 - num10, NoMove, plane, ref Job);
					}
					MoveClampers(NoMove, num7, plane, ref Job);
				}
			}
			if (isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, list, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, 50.0))
			{
				double num11 = Job.Moves[Job.Moves.Count - 1].X1Clamper + ClamperMinXToToolX;
				double num12 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num11;
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY3, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, z3SafeDistance, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
				if (!flag2 & clsDrill.varDrillCNCSettings.LeaveClamperSideWhileClamperChangeForBottom)
				{
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, num2 + clsDrill.varDrillCNCSettings.LeaveYDistanceWhileClamperChangeForBottom, NoMoveZ3, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
					flag2 = true;
				}
				if (num12 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					double num13 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					double num14 = num11 + num13 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
					if (!(num14 + clsDrill.varDrillCNCSettings.ClamperCatchDistanceInsideFromMaterial < Job.Moves[Job.Moves.Count - 1].XPosition))
					{
						num11 = Job.Moves[Job.Moves.Count - 1].X1Clamper - ClamperMaxXToToolX;
					}
					else
					{
						MoveClampers(NoMoveX1, num11 + num13, plane, ref Job);
					}
				}
				MoveClampers(num11, NoMoveX2, plane, ref Job);
			}
		}
		double z1Position = Job.Moves[Job.Moves.Count - 1].Z1Position;
		double z2Position = Job.Moves[Job.Moves.Count - 1].Z2Position;
		double y1Position = Job.Moves[Job.Moves.Count - 1].Y1Position;
		double y2Position = Job.Moves[Job.Moves.Count - 1].Y2Position;
		noMoveZ2 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
		noMoveZ3 = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.Z2SmallSafeDistance;
		if (!(Job.Material.Size.Height <= clsDrill.varDrillCNCSettings.BottomDrillBothY1AndY2PressLimit))
		{
			z2Position = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
			z1Position = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
			if (!(drillCalcItem.Center.Y < Job.Material.Size.Height / 2.0))
			{
				y1Position = drillCalcItem.Center.Y + 215.0;
				if (drillCalcItem.Depth > Job.Material.Size.Depth - 1.0)
				{
					y1Position = drillCalcItem.Center.Y + 215.0 + 100.0;
				}
				y2Position = y1Position - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			}
			else
			{
				y2Position = drillCalcItem.Center.Y - 165.0;
				if (drillCalcItem.Depth > Job.Material.Size.Depth - 1.0)
				{
					y2Position = drillCalcItem.Center.Y - 165.0 + 100.0;
				}
				y1Position = y2Position + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			}
		}
		else if (!(drillCalcItem.Center.Y < clsDrill.varDrillCNCSettings.BottomDrillPressMinLimit))
		{
			y2Position = drillCalcItem.Center.Y - 165.0;
			z2Position = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
			y1Position = y2Position + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			z1Position = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
		}
		else
		{
			y2Position = clsDrill.varDrillCNCSettings.BottomDrillPressMinLimit - 100.0;
			z2Position = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
			y1Position = y2Position + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			z1Position = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.BottomDrillPressDisForY1AndY2FromMatTop;
		}
		if (!flag2)
		{
			if (!flag)
			{
				if (!clsDrill.varDrillCNCSettings.MoveXYSameTimeForBottom)
				{
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ3, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
					AddDrillMove(NoMoveX1, NoMoveX2, y1Position, y2Position, num2, NoMoveZ3, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
				}
				else
				{
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, y1Position, y2Position, num2, NoMoveZ3, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
				}
			}
			else
			{
				AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ3, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
				AddDrillMove(NoMoveX1, NoMoveX2, y1Position, y2Position, num2, NoMoveZ3, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			}
		}
		else
		{
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ3, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, y1Position, y2Position, num2, NoMoveZ3, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
		}
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1Position, z2Position, z, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, z2, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Plunge), ref Job);
		if (Index >= FoundDrills.Count - 1)
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, z3SafeDistance, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, clsDrill.varDrillCNCSettings.ParkY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
		}
		else if (FoundDrills[Index + 1].Items[0].planeName != planeBoxNames.Bottom)
		{
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, z3SafeDistance, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, clsDrill.varDrillCNCSettings.ParkY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
		}
		else if (!clsInit.cDrill.isToolsSameForNextOperation(Items, FoundDrills[Index + 1].Items))
		{
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, z3SafeDistance, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
		}
		else
		{
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, noMoveZ2, noMoveZ3, z, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
		}
	}

	public void CreateCodeForFront(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
	{
		DrillCalcItem drillCalcItem = null;
		DrillCalcItem drillCalcItem2 = null;
		drillPlaneNames plane = drillPlaneNames.Front;
		DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		DrillMoveOptions Option2 = new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		DrillMoveOptions Option3 = new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = NoMoveY1;
		double num6 = NoMoveY2;
		double z = NoMoveZ1;
		double z2 = NoMoveZ2;
		double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		double z2SafeDistance = clsDrill.varDrillCNCSettings.Z2SafeDistance;
		double num7 = double.MaxValue;
		double num8 = 0.0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		List<ToolBase5> list = new List<ToolBase5>();
		if (((Index > 0) & (Index <= FoundDrills.Count - 1)) && FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Front)
		{
			flag4 = true;
		}
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			if ((drillCalcItem == null) & (Items[i].HeadNo == 1))
			{
				drillCalcItem = Items[i];
				num5 = drillCalcItem.OffsetedPoint.Y;
				z = drillCalcItem.Center.Z;
				num8 = drillCalcItem.Center.X;
			}
			if ((drillCalcItem2 == null) & (Items[i].HeadNo == 2))
			{
				drillCalcItem2 = Items[i];
				num6 = drillCalcItem2.OffsetedPoint.Y;
				z2 = drillCalcItem2.Center.Z;
				num8 = drillCalcItem2.Center.X;
			}
			if (Items[i].HeadNo == 1)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option2);
			}
			if (Items[i].HeadNo == 2)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option3);
			}
			if (drillCalcItem != null && drillCalcItem.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem.Diameter / 2.0)
			{
				flag = true;
			}
			if (drillCalcItem2 != null && drillCalcItem2.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem2.Diameter / 2.0)
			{
				flag2 = true;
			}
			if (Items[i].Center.Y < num7)
			{
				num7 = Items[i].Center.Y;
			}
			if (Items[i].Tool <= 0)
			{
				calcErrorList.Add("No Defined Tool For This OP");
			}
			else
			{
				ToolBase5 foundTool = new ToolBase5();
				if (FindToolWithToolNo(Items[i].Tool, ref foundTool))
				{
					list.Add(foundTool);
				}
			}
			SetValueToAvailableTool(Items[i].Tool, ref Option);
		}
		if (drillCalcItem == null)
		{
			if (drillCalcItem2 != null)
			{
				ToolBase5 foundTool2 = new ToolBase5();
				FindToolWithToolNo(drillCalcItem2.Tool, ref foundTool2);
				num = drillCalcItem2.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
				num2 = drillCalcItem2.OffsetedPoint.X;
				num3 = num2 - foundTool2.Geometry.Length - clsDrill.varDrillCNCSettings.X1SafeDistance;
				num4 = num2 - foundTool2.Geometry.Length + drillCalcItem2.Depth;
			}
		}
		else
		{
			ToolBase5 foundTool3 = new ToolBase5();
			FindToolWithToolNo(drillCalcItem.Tool, ref foundTool3);
			num = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			num2 = drillCalcItem.OffsetedPoint.X;
			num3 = num2 - foundTool3.Geometry.Length - clsDrill.varDrillCNCSettings.X1SafeDistance;
			num4 = num2 - foundTool3.Geometry.Length + drillCalcItem.Depth;
		}
		if (!Job.isSingleClamper && ((num7 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0) & ((Job.Moves[Job.Moves.Count - 1].X2Clamper > 0.0) | (Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper) < clsDrill.varDrillCNCSettings.ClamperLength / 2.0))))
		{
			double num9 = 0.0;
			if (Index < FoundDrills.Count - 1)
			{
				for (int j = Index + 1; j <= FoundDrills.Count - 1; j++)
				{
					for (int k = 0; k <= FoundDrills[j].Items.Count - 1; k++)
					{
						if (FoundDrills[j].Items[k].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + FoundDrills[j].Items[k].Diameter / 2.0)
						{
							double num10 = FoundDrills[j].Items[k].Center.X - num8;
							if (num10 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && ((FoundDrills[j].Items[k].planeName == planeBoxNames.Top) | (FoundDrills[j].Items[k].planeName == planeBoxNames.Left)) && num10 > num9)
							{
								num9 = num10;
							}
						}
					}
				}
			}
			if (num9 > 0.0)
			{
				num9 += clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
			}
			double num11 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num;
			if (num11 > 0.0)
			{
				double num12 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num11 - num9;
				double num13 = num12 - Job.Moves[Job.Moves.Count - 1].X1Clamper;
				if (num13 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					double num14 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					MoveClampers(num12 - num14, NoMove, plane, ref Job);
				}
				MoveClampers(NoMove, num12, plane, ref Job);
			}
		}
		if (Index != 0)
		{
			if ((flag || flag2) & clsDrill.varDrillCNCSettings.MoveSafeDistanceAtClamperSideForFront)
			{
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
			}
		}
		else
		{
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
		}
		if (!(drillCalcItem != null && drillCalcItem2 != null))
		{
			if (!(drillCalcItem != null && drillCalcItem2 == null))
			{
				if (drillCalcItem == null && drillCalcItem2 != null && Job.Moves[Job.Moves.Count - 1].Y1Position - num6 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
				{
					num5 = num6 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
				}
			}
			else if (num5 - Job.Moves[Job.Moves.Count - 1].Y2Position < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
			{
				num6 = num5 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			}
		}
		else if (num5 - num6 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
		{
			flag3 = true;
		}
		if (flag3)
		{
			double num15 = num6;
			if (!buCompare5.EQ(num3, Job.Moves[Job.Moves.Count - 1].XPosition) | !buCompare5.EQ(num5, Job.Moves[Job.Moves.Count - 1].Y1Position) | !buCompare5.EQ(num6, Job.Moves[Job.Moves.Count - 1].Y2Position))
			{
				num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
				AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
			}
			num6 = num5 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			if (!(Job.Moves[Job.Moves.Count - 1].Y1Position < Job.Material.Size.Height))
			{
				Option2.Cmd2 = DrillMoveCommand.None;
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option2, ref Job);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.SetPiston, NoMove, Option2, ref Job);
			}
			else
			{
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option2, ref Job);
			}
			num = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num4, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Plunge), ref Job);
			num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
			num6 = num15;
			num5 = num6 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			if (!(num6 > 50.0))
			{
				Option3.Cmd2 = DrillMoveCommand.None;
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option3, ref Job);
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.SetPiston, NoMove, Option3, ref Job);
			}
			else
			{
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option3, ref Job);
			}
			num = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num4, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Plunge), ref Job);
			num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
		}
		else
		{
			if (flag4)
			{
				if (!(!buCompare5.EQ(num3, Job.Moves[Job.Moves.Count - 1].XPosition) | !buCompare5.EQ(num5, Job.Moves[Job.Moves.Count - 1].Y1Position) | !buCompare5.EQ(num6, Job.Moves[Job.Moves.Count - 1].Y2Position)))
				{
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
				}
				else
				{
					num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, Option, ref Job);
				}
			}
			else
			{
				if (!buCompare5.EQ(num3, Job.Moves[Job.Moves.Count - 1].XPosition) | !buCompare5.EQ(num5, Job.Moves[Job.Moves.Count - 1].Y1Position) | !buCompare5.EQ(num6, Job.Moves[Job.Moves.Count - 1].Y2Position))
				{
					num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, num5, num6, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
				}
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
			}
			num = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num4, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Plunge), ref Job);
			num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast), ref Job);
		}
		if (Index >= FoundDrills.Count - 1)
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
		}
		else if (FoundDrills[Index + 1].Items[0].planeName != planeBoxNames.Front)
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
		}
		else if (!clsInit.cDrill.isToolsSameForNextOperation(Items, FoundDrills[Index + 1].Items))
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
		}
		else
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.ResetAllPress, NoMove, Option, ref Job);
		}
	}

	public void CreateCodeForBack(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
	{
		DrillCalcItem drillCalcItem = null;
		DrillCalcItem drillCalcItem2 = null;
		drillPlaneNames plane = drillPlaneNames.Back;
		DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		DrillMoveOptions Option2 = new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		DrillMoveOptions Option3 = new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = NoMoveY1;
		double num6 = NoMoveY2;
		double z = NoMoveZ1;
		double z2 = NoMoveZ2;
		double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		double z2SafeDistance = clsDrill.varDrillCNCSettings.Z2SafeDistance;
		double num7 = double.MaxValue;
		double num8 = 0.0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		List<ToolBase5> list = new List<ToolBase5>();
		if (((Index > 0) & (Index <= FoundDrills.Count - 1)) && FoundDrills[Index - 1].Items[0].planeName == planeBoxNames.Back)
		{
			flag4 = true;
		}
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			if ((drillCalcItem == null) & (Items[i].HeadNo == 1))
			{
				drillCalcItem = Items[i];
				num5 = drillCalcItem.OffsetedPoint.Y;
				z = drillCalcItem.Center.Z;
				num8 = drillCalcItem.Center.X;
			}
			if ((drillCalcItem2 == null) & (Items[i].HeadNo == 2))
			{
				drillCalcItem2 = Items[i];
				num6 = drillCalcItem2.OffsetedPoint.Y;
				z2 = drillCalcItem2.Center.Z;
				num8 = drillCalcItem2.Center.X;
			}
			if (Items[i].HeadNo == 1)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option2);
			}
			if (Items[i].HeadNo == 2)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option3);
			}
			if (drillCalcItem != null && drillCalcItem.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem.Diameter / 2.0)
			{
				flag = true;
			}
			if (drillCalcItem2 != null && drillCalcItem2.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem2.Diameter / 2.0)
			{
				flag2 = true;
			}
			if (Items[i].Center.Y < num7)
			{
				num7 = Items[i].Center.Y;
			}
			if (Items[i].Tool <= 0)
			{
				calcErrorList.Add("No Defined Tool For This OP");
			}
			else
			{
				ToolBase5 foundTool = new ToolBase5();
				if (FindToolWithToolNo(Items[i].Tool, ref foundTool))
				{
					list.Add(foundTool);
				}
			}
			SetValueToAvailableTool(Items[i].Tool, ref Option);
		}
		if (drillCalcItem == null)
		{
			if (drillCalcItem2 != null)
			{
				ToolBase5 foundTool2 = new ToolBase5();
				FindToolWithToolNo(drillCalcItem2.Tool, ref foundTool2);
				num = drillCalcItem2.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
				num2 = drillCalcItem2.OffsetedPoint.X;
				num3 = num2 + foundTool2.Geometry.Length + clsDrill.varDrillCNCSettings.X1SafeDistance;
				num4 = num2 + foundTool2.Geometry.Length - drillCalcItem2.Depth;
			}
		}
		else
		{
			ToolBase5 foundTool3 = new ToolBase5();
			FindToolWithToolNo(drillCalcItem.Tool, ref foundTool3);
			num = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			num2 = drillCalcItem.OffsetedPoint.X;
			num3 = num2 + foundTool3.Geometry.Length + clsDrill.varDrillCNCSettings.X1SafeDistance;
			num4 = num2 + foundTool3.Geometry.Length - drillCalcItem.Depth;
		}
		if (!Job.isSingleClamper)
		{
			double num9 = 0.0;
			if (Index < FoundDrills.Count - 1)
			{
				for (int j = Index + 1; j <= FoundDrills.Count - 1; j++)
				{
					for (int k = 0; k <= FoundDrills[j].Items.Count - 1; k++)
					{
						if (FoundDrills[j].Items[k].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + FoundDrills[j].Items[k].Diameter / 2.0)
						{
							double num10 = Math.Abs(FoundDrills[j].Items[k].Center.X - num8);
							if (num10 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && ((FoundDrills[j].Items[k].planeName == planeBoxNames.Top) | (FoundDrills[j].Items[k].planeName == planeBoxNames.Left)) && num10 > num9)
							{
								num9 = num10;
							}
						}
					}
				}
			}
			if (num9 > 0.0)
			{
				num9 += clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
			}
			num = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			double num11 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num;
			double num12 = list[0].Positions.CommonOffset.X + list[0].Geometry.Length + 40.0;
			if ((num7 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0) & (num11 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 < num12))
			{
				double num13 = num12 - (num11 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0);
				if (num13 > 0.0)
				{
					num11 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num13 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + num9;
					double num14 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num11;
					if (num14 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
					{
						double num15 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
						double newX = num11 + num15;
						MoveClampers(NoMove, newX, drillPlaneNames.Back, ref Job);
					}
					MoveClampers(num11, NoMove, drillPlaneNames.Back, ref Job);
				}
			}
		}
		if (Index != 0)
		{
			if ((flag || flag2) & clsDrill.varDrillCNCSettings.MoveSafeDistanceAtClamperSideForBack)
			{
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
			}
		}
		else
		{
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
		}
		if (!(drillCalcItem != null && drillCalcItem2 != null))
		{
			if (!(drillCalcItem != null && drillCalcItem2 == null))
			{
				if (drillCalcItem == null && drillCalcItem2 != null && Job.Moves[Job.Moves.Count - 1].Y1Position - num6 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
				{
					num5 = num6 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
				}
			}
			else if (num5 - Job.Moves[Job.Moves.Count - 1].Y2Position < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
			{
				num6 = num5 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			}
		}
		else if (num5 - num6 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
		{
			flag3 = true;
		}
		if (flag3)
		{
			double num16 = num6;
			if (!buCompare5.EQ(num3, Job.Moves[Job.Moves.Count - 1].XPosition))
			{
				num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
				AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
			}
			num6 = num5 - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			if (!(Job.Moves[Job.Moves.Count - 1].Y1Position < Job.Material.Size.Height))
			{
				Option2.Cmd2 = DrillMoveCommand.None;
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option2, ref Job);
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.SetPiston, NoMove, Option2, ref Job);
			}
			else
			{
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option2, ref Job);
			}
			num = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num4, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Plunge), ref Job);
			num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
			num6 = num16;
			num5 = num6 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
			if (!(num6 > 50.0))
			{
				Option3.Cmd2 = DrillMoveCommand.None;
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option3, ref Job);
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.SetPiston, NoMove, Option3, ref Job);
			}
			else
			{
				AddDrillMove(NoMoveX1, NoMoveX2, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option3, ref Job);
			}
			num = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num4, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Plunge), ref Job);
			num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
		}
		else
		{
			if (flag4)
			{
				if (!(!buCompare5.EQ(num3, Job.Moves[Job.Moves.Count - 1].XPosition) | !buCompare5.EQ(num5, Job.Moves[Job.Moves.Count - 1].Y1Position) | !buCompare5.EQ(num6, Job.Moves[Job.Moves.Count - 1].Y2Position)))
				{
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
				}
				else
				{
					num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
					Option.Cmd2 = DrillMoveCommand.None;
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, num5, num6, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, Option, ref Job);
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.SetPiston, NoMove, Option, ref Job);
				}
			}
			else
			{
				if (!buCompare5.EQ(num3, Job.Moves[Job.Moves.Count - 1].XPosition) | !buCompare5.EQ(num5, Job.Moves[Job.Moves.Count - 1].Y1Position) | !buCompare5.EQ(num6, Job.Moves[Job.Moves.Count - 1].Y2Position))
				{
					num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, num5, num6, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
				}
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
			}
			num = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num4, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Plunge), ref Job);
			num = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast), ref Job);
		}
		if (Index >= FoundDrills.Count - 1)
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
		}
		else if (FoundDrills[Index + 1].Items[0].planeName != planeBoxNames.Back)
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
		}
		else if (!clsInit.cDrill.isToolsSameForNextOperation(Items, FoundDrills[Index + 1].Items))
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
		}
		else
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.ResetAllPress, NoMove, Option, ref Job);
		}
	}

	public void CreateCodeForLeftRight(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
	{
		drillPlaneNames plane = drillPlaneNames.LeftRight;
		DrillCalcItem drillCalcItem = null;
		DrillCalcItem drillCalcItem2 = null;
		DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.LeftRight, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		DrillMoveOptions options = new DrillMoveOptions(drillPlaneNames.LeftRight, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.ResetAll, DrillMoveCommand.None);
		DrillMoveOptions Option2 = new DrillMoveOptions(drillPlaneNames.LeftRight, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		DrillMoveOptions Option3 = new DrillMoveOptions(drillPlaneNames.LeftRight, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.SetPiston, DrillMoveCommand.None);
		double num = 0.0;
		double x = 0.0;
		double num2 = NoMoveY1;
		double num3 = NoMoveY2;
		double z = NoMoveZ1;
		double z2 = NoMoveZ2;
		double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		double z2SafeDistance = clsDrill.varDrillCNCSettings.Z2SafeDistance;
		double num4 = double.MaxValue;
		double ClamperMinXToToolX = 0.0;
		double ClamperMaxXToToolX = 0.0;
		double num5 = 0.0;
		double num6 = NoMoveY1;
		double num7 = NoMoveY2;
		double y = NoMoveY1;
		double y2 = NoMoveY2;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		List<ToolBase5> list = new List<ToolBase5>();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			if ((drillCalcItem == null) & (Items[i].HeadNo == 1))
			{
				drillCalcItem = Items[i];
				num2 = drillCalcItem.OffsetedPoint.Y;
				z = drillCalcItem.Center.Z;
				num5 = drillCalcItem.Center.X;
				ToolBase5 foundTool = new ToolBase5();
				FindToolWithToolNo(drillCalcItem.Tool, ref foundTool);
				num6 = drillCalcItem.OffsetedPoint.Y + foundTool.Geometry.Length + clsDrill.varDrillCNCSettings.Y1SafeDistance;
				y = drillCalcItem.OffsetedPoint.Y + foundTool.Geometry.Length - drillCalcItem.Depth;
			}
			if ((drillCalcItem2 == null) & (Items[i].HeadNo == 2))
			{
				drillCalcItem2 = Items[i];
				num3 = drillCalcItem2.OffsetedPoint.Y;
				z2 = drillCalcItem2.Center.Z;
				num5 = drillCalcItem2.Center.X;
				ToolBase5 foundTool2 = new ToolBase5();
				FindToolWithToolNo(drillCalcItem2.Tool, ref foundTool2);
				num7 = drillCalcItem2.OffsetedPoint.Y - foundTool2.Geometry.Length - clsDrill.varDrillCNCSettings.Y2SafeDistance;
				y2 = drillCalcItem2.OffsetedPoint.Y - foundTool2.Geometry.Length + drillCalcItem2.Depth;
			}
			if (Items[i].HeadNo == 1)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option2);
			}
			if (Items[i].HeadNo == 2)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option3);
			}
			if (drillCalcItem != null && drillCalcItem.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem.Diameter / 2.0)
			{
				flag2 = true;
			}
			if (drillCalcItem2 != null && drillCalcItem2.Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + drillCalcItem2.Diameter / 2.0)
			{
				flag3 = true;
			}
			if (Items[i].Center.Y < num4)
			{
				num4 = Items[i].Center.Y;
			}
			if (Items[i].Tool <= 0)
			{
				calcErrorList.Add("No Defined Tool For This OP");
			}
			else
			{
				ToolBase5 foundTool3 = new ToolBase5();
				if (FindToolWithToolNo(Items[i].Tool, ref foundTool3))
				{
					list.Add(foundTool3);
				}
			}
			SetValueToAvailableTool(Items[i].Tool, ref Option);
		}
		if (drillCalcItem == null)
		{
			if (drillCalcItem2 != null)
			{
				num = drillCalcItem2.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
				x = drillCalcItem2.OffsetedPoint.X;
			}
		}
		else
		{
			num = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			x = drillCalcItem.OffsetedPoint.X;
		}
		if (Index != 0)
		{
			if ((flag2 || flag3) & clsDrill.varDrillCNCSettings.MoveSafeDistanceAtClamperSideForLeftRight)
			{
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			}
		}
		else
		{
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
		}
		if ((num4 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + Items[0].Diameter / 2.0) & !Job.isSingleClamper)
		{
			double num8 = 0.0;
			if (Index < FoundDrills.Count - 1)
			{
				for (int j = Index + 1; j <= FoundDrills.Count - 1; j++)
				{
					for (int k = 0; k <= FoundDrills[j].Items.Count - 1; k++)
					{
						if (FoundDrills[j].Items[k].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + FoundDrills[j].Items[k].Diameter / 2.0)
						{
							double num9 = FoundDrills[j].Items[k].Center.X - num5;
							if (num9 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && ((FoundDrills[j].Items[k].planeName == planeBoxNames.Top) | (FoundDrills[j].Items[k].planeName == planeBoxNames.Left)) && num9 > num8)
							{
								num8 = num9 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance;
							}
						}
					}
				}
			}
			if (isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + num, list, ref ClamperMinXToToolX, ref ClamperMaxXToToolX))
			{
				double num10 = Job.Moves[Job.Moves.Count - 1].X2Clamper + ClamperMinXToToolX;
				if (num10 > Job.Moves[Job.Moves.Count - 1].XPosition && clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - (num10 - Job.Moves[Job.Moves.Count - 1].XPosition) < 40.0)
				{
					num10 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num8;
				}
				if (num10 > Job.Moves[Job.Moves.Count - 1].XPosition)
				{
					double num11 = num10 - Job.Moves[Job.Moves.Count - 1].XPosition;
					if (num11 > clsDrill.varDrillCNCSettings.ClamperLength / 2.0 * 0.75)
					{
						num10 = Job.Moves[Job.Moves.Count - 1].X2Clamper - ClamperMaxXToToolX - num8;
					}
				}
				if (!flag)
				{
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
					flag = true;
				}
				double num12 = num10 - Job.Moves[Job.Moves.Count - 1].X1Clamper;
				if (num12 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					double num13 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					MoveClampers(num10 - num13, NoMove, plane, ref Job);
				}
				MoveClampers(NoMove, num10, plane, ref Job);
			}
			if (isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, list, ref ClamperMinXToToolX, ref ClamperMaxXToToolX))
			{
				double num14 = Job.Moves[Job.Moves.Count - 1].X1Clamper + ClamperMinXToToolX;
				double num15 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num14;
				if (!flag)
				{
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
					flag = true;
				}
				if (num15 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					double num16 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					double num17 = num14 + num16 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
					if (!(num17 + clsDrill.varDrillCNCSettings.ClamperCatchDistanceInsideFromMaterial < Job.Moves[Job.Moves.Count - 1].XPosition))
					{
						num14 = Job.Moves[Job.Moves.Count - 1].X1Clamper - ClamperMaxXToToolX;
					}
					else
					{
						MoveClampers(NoMoveX1, num14 + num16, plane, ref Job);
					}
				}
				MoveClampers(num14, NoMoveX2, plane, ref Job);
			}
		}
		double y1AndY2MinDistance = clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
		if (!(drillCalcItem != null && drillCalcItem2 != null))
		{
			if (!(drillCalcItem != null && drillCalcItem2 == null))
			{
				if (drillCalcItem == null && drillCalcItem2 != null)
				{
					plane = drillPlaneNames.Right;
					if (Job.Moves[Job.Moves.Count - 1].Y1Position - num3 < y1AndY2MinDistance - 80.0)
					{
						num2 = num3 + y1AndY2MinDistance + 0.0;
						if (num6 == NoMove)
						{
							num6 = num2;
						}
					}
				}
			}
			else
			{
				plane = drillPlaneNames.Left;
				if (num2 - Job.Moves[Job.Moves.Count - 1].Y2Position < y1AndY2MinDistance - 80.0)
				{
					num3 = num2 - y1AndY2MinDistance - 0.0;
					if (num7 == NoMove)
					{
						num7 = num3;
					}
				}
			}
		}
		else if (num2 - num3 < y1AndY2MinDistance - 80.0)
		{
			flag4 = true;
		}
		if (flag4)
		{
			MessageBox.Show("Not Ready");
		}
		else
		{
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, num6, num7, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z, z2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, y, y2, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Plunge), ref Job);
			AddDrillMove(NoMoveX1, NoMoveX2, num6, num7, NoMoveY3, NoMoveZ1, NoMoveZ2, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
		}
		if (Index >= FoundDrills.Count - 1)
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
			return;
		}
		double z3 = NoMoveZ1;
		double z4 = NoMoveZ2;
		if (Job.Material.Size.Depth > 20.0)
		{
			z3 = z1SafeDistance;
			z4 = z2SafeDistance;
		}
		if (!((FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Left) | (FoundDrills[Index + 1].Items[0].planeName == planeBoxNames.Right)))
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z1SafeDistance, z2SafeDistance, NoMoveZ3, DrillMoveCommand.AxisMove, NoMove, Option, ref Job);
		}
		else if (clsInit.cDrill.isToolsSameForNextOperation(Items, FoundDrills[Index + 1].Items))
		{
			double num18 = 0.0;
			double num19 = 0.0;
			double num20 = 0.0;
			double num21 = 0.0;
			for (int l = 0; l <= Items.Count - 1; l++)
			{
				double XOffset = 0.0;
				double x2 = FoundDrills[Index].Items[l].Center.X;
				GetXToolOffsetFromNo(Items[l].Tool, ref XOffset);
				for (int m = 0; m <= FoundDrills[Index + 1].Items.Count - 1; m++)
				{
					double XOffset2 = 0.0;
					double x3 = FoundDrills[Index + 1].Items[m].Center.X;
					double num22 = x3 - x2;
					GetXToolOffsetFromNo(FoundDrills[Index + 1].Items[m].Tool, ref XOffset2);
					num18 = ((Job.Moves[Job.Moves.Count - 1].X2Clamper < XOffset) ? (-1.0) : 1.0);
					num19 = ((Job.Moves[Job.Moves.Count - 1].X2Clamper + num22 < XOffset2) ? (-1.0) : 1.0);
					num20 = ((Job.Moves[Job.Moves.Count - 1].X1Clamper < XOffset) ? (-1.0) : 1.0);
					num21 = ((Job.Moves[Job.Moves.Count - 1].X1Clamper + num22 < XOffset2) ? (-1.0) : 1.0);
				}
			}
			if (num18 == num19)
			{
				if (num20 == num21)
				{
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z3, z4, NoMoveZ3, DrillMoveCommand.ResetAllPress, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
					return;
				}
				Option.Cmd2 = DrillMoveCommand.ResetAll;
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z3, z4, NoMoveZ3, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			}
			else
			{
				Option.Cmd2 = DrillMoveCommand.ResetAll;
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, z3, z4, NoMoveZ3, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
			}
		}
		else
		{
			Option.Cmd2 = DrillMoveCommand.ResetAll;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveY2, NoMoveY3, NoMoveZ1, z4, NoMoveZ3, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(plane, DrillCNCMode.Fast), ref Job);
		}
	}

	public void CreateCodeForSlotTopSide(ref DrillJob Job, ref List<DrillCalcItem> ItemSlot)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		DrillMoveOptions drillMoveOptions = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast);
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		for (int i = 0; i <= ItemSlot.Count - 1; i++)
		{
			if (!(ItemSlot[i].Center.X + ItemSlot[i].Length > Job.Material.Size.Width * 1.2))
			{
				list.Add(new DrillCalcItem(ItemSlot[i]));
				continue;
			}
			DrillCalcItem drillCalcItem = new DrillCalcItem(ItemSlot[i]);
			drillCalcItem.Center.X = drillCalcItem.Center.X - drillCalcItem.Length;
			list.Add(drillCalcItem);
		}
		if (list.Count == 0)
		{
			return;
		}
		if (!((list[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperCatchWidth) & (Job.Material.Size.Width < 400.0)))
		{
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
			if (!(list[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperCatchWidth))
			{
				list = SortByYDistance(list, new DrillCalcItem(), SortDirection.LowerToBigger);
				List<DrillCalcItem> list2 = new List<DrillCalcItem>();
				List<DrillCalcItem> list3 = new List<DrillCalcItem>();
				for (int j = 0; j <= list.Count - 1; j++)
				{
					if (!(list[j].Center.Y < Job.Material.Size.Height))
					{
						list3.Add(new DrillCalcItem(list[j]));
					}
					else if (!(list[j].Center.Y >= Job.Material.Size.Height / 2.0))
					{
						list3.Add(new DrillCalcItem(list[j]));
					}
					else
					{
						list2.Add(new DrillCalcItem(list[j]));
					}
				}
				int count = list2.Count;
				if (list3.Count > count)
				{
					count = list3.Count;
				}
				for (int k = 0; k <= count - 1; k++)
				{
					bool flag = true;
					bool flag2 = true;
					double num7 = 0.0;
					FindToolSettings findToolSettings = new FindToolSettings();
					findToolSettings.Plane = planeBoxNames.Top;
					findToolSettings.SetAsUsed = true;
					for (int l = 0; l <= clsDrill.ToolList.Count - 1; l++)
					{
						clsDrill.ToolList[l].Data.Used = false;
					}
					int num8 = 0;
					int num9 = 0;
					ToolBase5 foundTool = null;
					ToolBase5 foundTool2 = null;
					num = NoMove;
					num2 = NoMove;
					num3 = NoMove;
					num4 = NoMove;
					if (!((k <= list2.Count - 1) & (list2.Count > 0)))
					{
						flag = false;
					}
					else if (list2[k].Calculated)
					{
						flag = false;
					}
					else
					{
						FindToolFromBlock(list2[k], 0, findToolSettings, ref foundTool);
						if (foundTool != null)
						{
							num = list2[k].Center.Y - foundTool.Positions.Offset.Y;
							num3 = list2[k].Center.Z;
							_ = list2[k].Center.X;
							_ = list2[k].Center.X;
							num7 = list2[k].Depth;
							list2[k].Calculated = true;
							num8 = foundTool.Data.No;
						}
					}
					if (!((k <= list3.Count - 1) & (list3.Count > 0)))
					{
						flag2 = false;
					}
					else if (list3[k].Calculated)
					{
						flag2 = false;
					}
					else
					{
						FindToolFromBlock(list3[k], 1, findToolSettings, ref foundTool2);
						if (foundTool2 != null)
						{
							num2 = list3[k].Center.Y - foundTool2.Positions.Offset.Y;
							num4 = list3[k].Center.Z;
							_ = list3[k].Center.X;
							_ = list3[k].Center.X;
							num7 = list3[k].Depth;
							list3[k].Calculated = true;
							num9 = foundTool2.Data.No;
						}
					}
					if (num3 == NoMove && num3 != num5)
					{
						num3 = clsDrill.varDrillCNCSettings.Z1SafeDistance;
					}
					if (num4 == NoMove && num4 != num6)
					{
						num4 = clsDrill.varDrillCNCSettings.Z2SafeDistance;
					}
					if (num3 == num5)
					{
						num3 = NoMove;
					}
					if (num4 == num6)
					{
						num4 = NoMove;
					}
					if (flag && !flag2 && num - Job.Moves[Job.Moves.Count - 1].Y2Position < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
					{
						num2 = num - clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
					}
					if (!flag && flag2 && Job.Moves[Job.Moves.Count - 1].Y1Position - num2 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
					{
						num = num2 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance;
					}
					if (flag || flag2)
					{
						double XOffset = 0.0;
						double YOffset = 0.0;
						if (foundTool == null)
						{
							new ToolBase5(foundTool2);
							GetXYToolOffsetFromNo(foundTool2.Data.No, ref XOffset, ref YOffset);
						}
						else
						{
							new ToolBase5(foundTool);
							GetXYToolOffsetFromNo(foundTool.Data.No, ref XOffset, ref YOffset);
						}
						AddDrillMove(NoMove, NoMove, num, num2, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, num8, num9), ref Job);
						double num10 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X;
						double num11 = num10 - Job.Moves[Job.Moves.Count - 1].XPosition;
						double num12 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num11;
						double num13 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num11;
						if (!(num12 < clsDrill.varDrillMachineSettings.MachineMinXStroke))
						{
							AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num11, Job.Moves[Job.Moves.Count - 1].X2Clamper + num11, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num10, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
						}
						else
						{
							double num14 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillMachineSettings.MachineMinXStroke;
							double x = num10 + Math.Abs(num11) - num14;
							AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - num14, Job.Moves[Job.Moves.Count - 1].X2Clamper - num14, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
							num11 += num14;
							num12 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num11;
							num13 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num11;
							double num15 = num12 - clsDrill.varDrillMachineSettings.MachineMinXStroke;
							double num16 = num12 - num15;
							double num17 = num13 - num15;
							AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(NoMove, num17 - num15, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(num16 - num15, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num11, Job.Moves[Job.Moves.Count - 1].X2Clamper + num11, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num10, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
						}
						double z = NoMove;
						double z2 = NoMove;
						if (flag & (num3 != NoMove))
						{
							z = num3 + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
						}
						if (flag2 & (num4 != NoMove))
						{
							z2 = num4 + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
						}
						AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, z, z2, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
						AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.SetPiston, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, num8, num9), ref Job);
						if (flag)
						{
							int Index = -1;
							GetIndexFromItemID(list2[k].ID, list, ref Index);
							if (Index >= 0)
							{
								list[Index].OffsetedPoint.X = num10;
							}
						}
						if (flag2)
						{
							int Index2 = -1;
							GetIndexFromItemID(list3[k].ID, list, ref Index2);
							if (Index2 >= 0)
							{
								list[Index2].OffsetedPoint.X = num10;
							}
						}
						z = NoMove;
						z2 = NoMove;
						if (flag & (num3 != NoMove))
						{
							z = num3 - num7;
						}
						if (flag2 & (num4 != NoMove))
						{
							z2 = num4 - num7;
						}
						AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, z, z2, NoMove, DrillMoveCommand.AxisMove, num10, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
						num10 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + list[0].Length;
						num11 = num10 - Job.Moves[Job.Moves.Count - 1].XPosition;
						num12 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num11;
						num13 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num11;
						if (!(num13 > clsDrill.varDrillMachineSettings.MachineMaxXStroke))
						{
							AddDrillMove(num12, num13, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num10, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
						}
						else
						{
							double num18 = num13 - clsDrill.varDrillMachineSettings.MachineMaxXStroke;
							double num19 = num12 - num18;
							double num20 = num13 - num18;
							double x2 = num10 - num18;
							AddDrillMove(num19, num20, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, x2, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
							AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(num19 - num18, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(NoMove, num20 - num18, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
							AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num18, Job.Moves[Job.Moves.Count - 1].X2Clamper + num18, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num10, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
						}
						z = NoMove;
						z2 = NoMove;
						if (flag & (num3 != NoMove))
						{
							z = num3 + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
						}
						if (flag2 & (num4 != NoMove))
						{
							z2 = num4 + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
						}
						AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, z, z2, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
						num3 = z;
						num4 = z2;
						if (num8 != 0 || num9 != 0)
						{
							AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetPiston, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, num8, num9), ref Job);
						}
					}
					num5 = num3;
					num6 = num4;
				}
			}
			else
			{
				FindToolSettings findToolSettings2 = new FindToolSettings();
				findToolSettings2.Y1Y2ZoneSelectionLimit = Job.Material.Size.Height / 2.0;
				if (findToolSettings2.Y1Y2ZoneSelectionLimit < clsDrill.varDrillCNCSettings.Y1MinLimit)
				{
					findToolSettings2.Y1Y2ZoneSelectionLimit = clsDrill.varDrillCNCSettings.Y1MinLimit;
				}
				ToolBase5 foundTool3 = new ToolBase5();
				ToolBase5 foundTool4 = new ToolBase5();
				FindTool(list[0], findToolSettings2, ref foundTool4);
				double XOffset2 = 0.0;
				double YOffset2 = 0.0;
				GetXYToolOffsetFromNo(foundTool4.Data.No, ref XOffset2, ref YOffset2);
				num2 = list[0].Center.Y - foundTool4.Positions.Offset.Y;
				num4 = list[0].Center.Z + clsDrill.varDrillCNCSettings.Z2SafeDistance;
				if (list.Count < 2)
				{
					num = Job.Moves[Job.Moves.Count - 1].Y1Position;
					double num21 = Job.Moves[Job.Moves.Count - 1].Y1Position - num2;
					if (num21 < clsDrill.varDrillCNCSettings.Y1AndY2MinDistance)
					{
						num = num2 + clsDrill.varDrillCNCSettings.Y1AndY2MinDistance + 20.0;
					}
				}
				else
				{
					FindTool(list[1], findToolSettings2, ref foundTool3);
					GetXYToolOffsetFromNo(foundTool3.Data.No, ref XOffset2, ref YOffset2);
					num = list[1].Center.Y - foundTool3.Positions.Offset.Y;
					num3 = list[1].Center.Z + clsDrill.varDrillCNCSettings.Z1SafeDistance;
				}
				if (!((foundTool3.Data.No > 0) & (foundTool4.Data.No > 0)))
				{
					if (!((foundTool3.Data.No > 0) & (foundTool4.Data.No == 0)))
					{
						if ((foundTool3.Data.No == 0) & (foundTool4.Data.No > 0))
						{
							drillMoveOptions.Tool1 = foundTool4.Data.No;
						}
					}
					else
					{
						drillMoveOptions.Tool1 = foundTool3.Data.No;
					}
				}
				else
				{
					drillMoveOptions.Tool1 = foundTool4.Data.No;
					drillMoveOptions.Tool2 = foundTool3.Data.No;
				}
				double num22 = 0.0;
				double num23 = 0.0;
				double num24 = 0.0;
				double num25 = 0.0;
				if (!(Job.Material.Size.Width <= 500.0))
				{
					if (!((Job.Material.Size.Width > 500.0) & (Job.Material.Size.Width <= 750.0)))
					{
						if (!((Job.Material.Size.Width > 750.0) & (Job.Material.Size.Width <= 1200.0)))
						{
							num22 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X - 50.0;
							num23 = num22 - Job.Moves[Job.Moves.Count - 1].XPosition;
							num24 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num23;
							num25 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num23;
						}
						else
						{
							num22 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X - 50.0;
							num23 = num22 - Job.Moves[Job.Moves.Count - 1].XPosition;
							num24 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num23;
							num25 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num23;
						}
					}
					else
					{
						num22 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X - 50.0;
						num23 = num22 - Job.Moves[Job.Moves.Count - 1].XPosition;
						num24 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num23;
						num25 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num23;
					}
				}
				else
				{
					num22 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X - 50.0;
					num23 = num22 - Job.Moves[Job.Moves.Count - 1].XPosition;
					num24 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num23;
					num25 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num23;
				}
				AddDrillMove(NoMove, NoMove, num, num2, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, ref Job);
				int Index3 = -1;
				GetIndexFromItemID(list[0].ID, list, ref Index3);
				if (Index3 >= 0)
				{
					list[Index3].OffsetedPoint.X = num22;
				}
				AddDrillMove(num24, num25, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num22, drillMoveOptions, ref Job);
				double num26 = 0.0;
				double num27 = 0.0;
				if (!(Job.Material.Size.Width <= 550.0))
				{
					if (!((Job.Material.Size.Width > 550.0) & (clsDrill.activeJob.Material.Size.Width <= 750.0)))
					{
						if (!((Job.Material.Size.Width > 750.0) & (clsDrill.activeJob.Material.Size.Width <= 1200.0)))
						{
							if (!((Job.Material.Size.Width > 1200.0) & (clsDrill.activeJob.Material.Size.Width <= 1500.0)))
							{
								double num28 = -1200.0;
								MoveClampers(num28, NoMove, drillPlaneNames.Top, ref Job);
								double num29 = num28 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 400.0;
								MoveClampers(NoMove, num29, drillPlaneNames.Top, ref Job);
								num26 = num22 - (num29 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 60.0);
							}
							else
							{
								double num30 = 0.0 - Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num23;
								MoveClampers(num30, NoMove, drillPlaneNames.Top, ref Job);
								double num31 = num30 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 200.0;
								MoveClampers(NoMove, num31, drillPlaneNames.Top, ref Job);
								num26 = num22 - (num31 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
							}
						}
						else
						{
							double num32 = 0.0 - Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num23;
							MoveClampers(num32, NoMove, drillPlaneNames.Top, ref Job);
							double num33 = num32 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 200.0;
							MoveClampers(NoMove, num33, drillPlaneNames.Top, ref Job);
							num26 = num22 - (num33 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
						}
					}
					else
					{
						double num34 = 0.0 - Job.Material.Size.Width + num23;
						MoveClampers(num34, NoMove, drillPlaneNames.Top, ref Job);
						double num35 = num34 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 100.0;
						MoveClampers(NoMove, num35, drillPlaneNames.Top, ref Job);
						num26 = num22 - (num35 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 70.0);
					}
				}
				else
				{
					double num36 = 0.0 - Job.Material.Size.Width + num23;
					MoveClampers(num36, NoMove, drillPlaneNames.Top, ref Job);
					double num37 = num36 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					MoveClampers(NoMove, num37, drillPlaneNames.Top, ref Job);
					num26 = num22 - (num37 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 70.0);
				}
				AddDrillMove(Z1: (list.Count >= 2) ? (list[1].Center.Z + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance) : NoMove, X1: NoMove, X2: NoMove, Y1: NoMove, Y2: NoMove, Y3: NoMove, Z2: list[0].Center.Z + clsDrill.varDrillCNCSettings.Z2SmallSafeDistance, Z3: NoMove, Cmd: DrillMoveCommand.AxisMove, X: num22, Options: drillMoveOptions, Job: ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.SetPiston, NoMove, drillMoveOptions, ref Job);
				AddDrillMove(Z1: (list.Count >= 2) ? (list[1].Center.Z - list[1].Depth) : NoMove, X1: NoMove, X2: NoMove, Y1: NoMove, Y2: NoMove, Y3: NoMove, Z2: list[0].Center.Z - list[0].Depth, Z3: NoMove, Cmd: DrillMoveCommand.AxisMove, X: num22, Options: new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), Job: ref Job);
				num22 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + num26;
				num23 = num22 - Job.Moves[Job.Moves.Count - 1].XPosition;
				num24 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num23;
				num25 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num23;
				AddDrillMove(num24, num25, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num22, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetPiston, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool4.Data.No), ref Job);
				double num38 = num26 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.3 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
				num38 = XOffset2 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
				MoveClampers(newX2: (Job.Material.Size.Width <= 550.0) ? (num22 + clsDrill.varDrillCNCSettings.ClamperLength / 4.0) : (((Job.Material.Size.Width > 550.0) & (clsDrill.activeJob.Material.Size.Width <= 750.0)) ? (num22 + clsDrill.varDrillCNCSettings.ClamperLength / 8.0) : (((Job.Material.Size.Width > 750.0) & (clsDrill.activeJob.Material.Size.Width <= 1200.0)) ? (num22 - clsDrill.varDrillCNCSettings.ClamperLength / 4.0) : (num22 - clsDrill.varDrillCNCSettings.ClamperLength))), newX1: NoMove, Plane: drillPlaneNames.Top, Job: ref Job);
				num27 = num26 + (foundTool4.Positions.Offset.X - (Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength / 2.0)) - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance * 2.0;
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.SetPiston, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool4.Data.No), ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, list[0].Center.Z - list[0].Depth, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool4.Data.No), ref Job);
				num22 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + num27;
				num23 = num22 - Job.Moves[Job.Moves.Count - 1].XPosition;
				num24 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num23;
				num25 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num23;
				AddDrillMove(num24, num25, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num22, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool4.Data.No), ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetPiston, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool4.Data.No), ref Job);
				double num39 = Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength * 2.0;
				num39 = XOffset2 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
				num39 = ((Job.Material.Size.Width <= 550.0) ? (Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength) : (((Job.Material.Size.Width > 550.0) & (Job.Material.Size.Width <= 750.0)) ? (Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 100.0) : (((Job.Material.Size.Width > 750.0) & (Job.Material.Size.Width <= 1200.0)) ? (Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 200.0) : (Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 500.0))));
				if (Job.Moves[Job.Moves.Count - 1].X2Clamper - num39 < clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength)
				{
					num39 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
				}
				MoveClampers(num39, NoMove, drillPlaneNames.Top, ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.SetPiston, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool4.Data.No), ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, list[0].Center.Z - list[0].Depth, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool4.Data.No), ref Job);
				num22 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + list[0].Length + foundTool4.Geometry.Diameter / 4.0;
				num23 = num22 - Job.Moves[Job.Moves.Count - 1].XPosition;
				num24 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num23;
				num25 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num23;
				if (!(num25 > clsDrill.varDrillMachineSettings.MachineMaxXStroke))
				{
					AddDrillMove(num24, num25, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num22, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool4.Data.No), ref Job);
				}
				else
				{
					double num40 = num25 - clsDrill.varDrillMachineSettings.MachineMaxXStroke;
					double num41 = num24 - num40;
					double num42 = num25 - num40;
					double x3 = num22 - num40;
					AddDrillMove(num41, num42, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, x3, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool4.Data.No), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool4.Data.No), ref Job);
					AddDrillMove(num41 - num40, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool4.Data.No), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool4.Data.No), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool4.Data.No), ref Job);
					AddDrillMove(NoMove, num42 - num40, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool4.Data.No), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool4.Data.No), ref Job);
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num40, Job.Moves[Job.Moves.Count - 1].X2Clamper + num40, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num22, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool4.Data.No), ref Job);
				}
				AddDrillMove(Z1: (list.Count >= 2) ? (list[1].Center.Z + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance) : NoMove, X1: NoMove, X2: NoMove, Y1: NoMove, Y2: NoMove, Y3: NoMove, Z2: list[0].Center.Z + clsDrill.varDrillCNCSettings.Z2SmallSafeDistance, Z3: NoMove, Cmd: DrillMoveCommand.AxisMove, X: NoMove, Options: new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), Job: ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetPiston, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool3.Data.No, foundTool4.Data.No), ref Job);
			}
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetAllPress, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
		}
		else
		{
			buString5.MessageBoxError(buDrillCalc.LangDrillMessage[41]);
		}
	}

	public void CreateCodeForShapeTopAndBottomSide(ref List<DrillItem> ItemShape, bool preCalculation, bool isTop, ToolBase5 toolFound, ref DrillJob Job)
	{
		double y = 0.0;
		double y2 = 0.0;
		double y3 = 0.0;
		double z = 0.0;
		double z2 = 0.0;
		double z3 = 0.0;
		double num = 0.0;
		double num2 = 0.0;
		double xPos = 0.0;
		new ToolBase5();
		List<Entity> list = new List<Entity>();
		List<Entity> list2 = new List<Entity>();
		List<Entity> list3 = new List<Entity>();
		List<Entity> list4 = new List<Entity>();
		List<Entity> list5 = new List<Entity>();
		new List<DrillCalcItem>();
		double num3 = 1000.0;
		clsMW.CamEntities.Clear();
		MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
		mWCalculationOptions.NumberofAxis = 3;
		mWCalculationOptions.Mode = CamMode.WireFrame;
		mWCalculationOptions.DontApplyReset = true;
		mWCalculationOptions.isBuWireframeCalculation = false;
		mWCalculationOptions.AddToCamListInMWCalculation = false;
		mWCalculationOptions.DontShowDialogBox = true;
		mWCalculationOptions.isBuSort = false;
		mWCalculationOptions.UseStartPoint = false;
		mWCalculationOptions.UseConstantStartPoint = false;
		mWCalculationOptions.StartPointX = 0.0;
		mWCalculationOptions.StartPointY = 0.0;
		mWCalculationOptions.ShowProgressForm = false;
		camTp Cam = new camTp();
		camTp Cam2 = new camTp();
		camTp camTp2 = new camTp();
		camTp Cam3 = new camTp();
		camTp Cam4 = new camTp();
		camTp camTp3 = new camTp();
		buMWDrillVars.varCamContour.buPar.Speeds.Feed = clsDrill.varDrillCNCSettings.MillingFeed;
		buMWDrillVars.varCamContour.buPar.Speeds.Plunge = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
		buMWDrillVars.varCamContour.buPar.Distances.SafeSmall = clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamContour.buPar.Distances.Safe = clsDrill.varDrillCNCSettings.distanceSafe;
		buMWDrillVars.varCamContour.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamContour.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamContour.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamContour.mwPar.MachParam.LinkParams.FeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamContour.mwPar.MachParam.LinkParams.RetractPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamContour.mwPar.MachParam.LinkParams.ClearancePlaneHeight = clsDrill.varDrillCNCSettings.distanceSafe;
		buMWDrillVars.varCamContour.mwPar.MachParam.RapidRetractFlg = true;
		buMWDrillVars.varCamContour.mwPar.MachParam.RapidFeedFlg = true;
		buMWDrillVars.varCamRough.buPar.Speeds.Feed = clsDrill.varDrillCNCSettings.MillingFeed;
		buMWDrillVars.varCamRough.buPar.Speeds.Plunge = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
		buMWDrillVars.varCamRough.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
		buMWDrillVars.varCamRough.buPar.Distances.SafeSmall = clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamRough.buPar.Distances.Safe = clsDrill.varDrillCNCSettings.distanceSafe;
		buMWDrillVars.varCamRough.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamRough.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamRough.mwPar.MachParam.MaxStepoverDistance = toolFound.Geometry.Diameter * 0.9;
		buMWDrillVars.varCamRough.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamRough.mwPar.MachParam.LinkParams.FeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamRough.mwPar.MachParam.LinkParams.RetractPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamRough.mwPar.MachParam.LinkParams.ClearancePlaneHeight = clsDrill.varDrillCNCSettings.distanceSafe;
		buMWDrillVars.varCamRough.mwPar.MachParam.RapidRetractFlg = true;
		buMWDrillVars.varCamRough.mwPar.MachParam.RapidFeedFlg = true;
		buMWDrillVars.varCamMeshRough.mwPar.MachParam.MaxStepoverDistance = toolFound.Geometry.Diameter * 0.9;
		buMWDrillVars.varCamMeshRough.buPar.Speeds.Feed = clsDrill.varDrillCNCSettings.MillingFeed;
		buMWDrillVars.varCamMeshRough.buPar.Speeds.Plunge = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
		buMWDrillVars.varCamMeshRough.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
		buMWDrillVars.varCamMeshRough.buPar.Distances.SafeSmall = clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshRough.buPar.Distances.Safe = clsDrill.varDrillCNCSettings.distanceSafe;
		buMWDrillVars.varCamMeshRough.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshRough.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshRough.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshRough.mwPar.MachParam.LinkParams.FeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshRough.mwPar.MachParam.LinkParams.RetractPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshRough.mwPar.MachParam.LinkParams.ClearancePlaneHeight = clsDrill.varDrillCNCSettings.distanceSafe;
		buMWDrillVars.varCamMeshParalelCut.buPar.Speeds.Feed = clsDrill.varDrillCNCSettings.MillingFeed;
		buMWDrillVars.varCamMeshParalelCut.buPar.Speeds.Plunge = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
		buMWDrillVars.varCamMeshParalelCut.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
		buMWDrillVars.varCamMeshParalelCut.buPar.Distances.SafeSmall = clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshParalelCut.buPar.Distances.Safe = clsDrill.varDrillCNCSettings.distanceSafe;
		buMWDrillVars.varCamMeshParalelCut.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshParalelCut.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshParalelCut.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshParalelCut.mwPar.MachParam.LinkParams.FeedPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshParalelCut.mwPar.MachParam.LinkParams.RetractPlaneIncremental = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		buMWDrillVars.varCamMeshParalelCut.mwPar.MachParam.LinkParams.ClearancePlaneHeight = clsDrill.varDrillCNCSettings.distanceSafe;
		for (int i = 0; i <= ItemShape.Count - 1; i++)
		{
			if (ItemShape[i].ToolMilling != null)
			{
				toolFound = new ToolBase5(ItemShape[i].ToolMilling);
			}
			num3 = ItemShape[i].ShapeData.Depth;
			buMWDrillVars.varCamContour.buPar.Operations.Direction = ClockDirectionType.CW;
			if (ItemShape[i].Type != DrillItemType.Contouring)
			{
				if (ItemShape[i].Type != DrillItemType.Contour)
				{
					if (ItemShape[i].Type != DrillItemType.SlotByMilling)
					{
						if (ItemShape[i].Type != DrillItemType.Profiling)
						{
							buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = ItemShape[i].CamPars.Offsets.ClosedContour;
						}
						else
						{
							buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Right;
							buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
						}
					}
					else
					{
						buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
						buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
					}
				}
				else
				{
					buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
					buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
				}
			}
			else
			{
				buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Outter;
			}
			List<List<buEntity>> copiedEntities = new List<List<buEntity>>();
			if (ItemShape[i].camEntities.Count <= 0)
			{
				buEntity.Copy(ItemShape[i].shapeEntitites, ref copiedEntities);
			}
			else
			{
				buEntity.Copy(ItemShape[i].camEntities, ref copiedEntities);
			}
			if (!ItemShape[i].isDrill)
			{
				for (int j = 0; j <= copiedEntities.Count - 1; j++)
				{
					list = new List<Entity>();
					list2 = new List<Entity>();
					for (int k = 0; k <= copiedEntities[j].Count - 1; k++)
					{
						buEntity buEntity2 = null;
						buEntity2 = buEntity.Copy(copiedEntities[j][k]);
						Plane plane = new Plane(new Point3D(), Vector3D.AxisX, Vector3D.AxisZ);
						Mirror t = new Mirror(plane);
						buEntity2.TransformBy(t);
						plane = new Plane(new Point3D(), Vector3D.AxisY, Vector3D.AxisZ);
						t = new Mirror(plane);
						buEntity2.TransformBy(t);
						if (!(ItemShape[i].isPocket & !ItemShape[i].isDrill))
						{
							Entity copiedEntity = null;
							buEntity.Copy(buEntity2, ref copiedEntity);
							list.Add(copiedEntity);
						}
						else
						{
							Entity copiedEntity2 = null;
							buEntity.Copy(buEntity2, ref copiedEntity2);
							list2.Add(copiedEntity2);
						}
					}
					if (!isTop)
					{
						buMWDrillVars.varCamContour.buPar.Distances.Rapid = num3 + clsDrill.varDrillCNCSettings.distanceSmallSafe;
						buMWDrillVars.varCamContour.buPar.Distances.EntryAndExit = num3 + clsDrill.varDrillCNCSettings.distanceSmallSafe;
						buMWDrillVars.varCamContour.buPar.Steps.Enable = ItemShape[i].StepEnable;
						buMWDrillVars.varCamContour.buPar.Steps.StartValue = 0.0 - num3;
						buMWDrillVars.varCamContour.buPar.Steps.EndValue = 0.0 - num3;
						ccVars.toolActive.CamData.SpindleSpeed = clsDrill.varDrillCNCSettings.BottomSpindleSpeed;
						buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = 0.0 - num3;
						buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = 0.0 - num3;
						buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = 0.0 - num3;
						buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = 0.0 - num3;
						if (ItemShape[i].StepEnable)
						{
							buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = 0.0 - num3;
							buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = 0.0;
							buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[i].StepValue;
							buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = 0.0 - num3;
							buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = 0.0;
							buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[i].StepValue;
							buMWDrillVars.varCamContour.buPar.Steps.StartValue = 0.0;
							buMWDrillVars.varCamContour.buPar.Steps.EndValue = 0.0 - num3;
						}
					}
					else
					{
						buMWDrillVars.varCamContour.buPar.Distances.Rapid = num3 + clsDrill.varDrillCNCSettings.distanceSmallSafe;
						buMWDrillVars.varCamContour.buPar.Distances.EntryAndExit = num3 + clsDrill.varDrillCNCSettings.distanceSmallSafe;
						ccVars.toolActive.CamData.SpindleSpeed = clsDrill.varDrillCNCSettings.TopSpindleSpeed;
						buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth - num3;
						if (ItemShape[i].StepEnable)
						{
							buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
							buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
							buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[i].StepValue;
							buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
							buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
							buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[i].StepValue;
							buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth - num3;
							buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth;
						}
					}
					if (list.Count > 0)
					{
						bool flag = false;
						clsMW.CamEntities.Clear();
						for (int l = 0; l <= list.Count - 1; l++)
						{
							Entity copiedEnt = null;
							buVector5.CopyEntities(list[l], ref copiedEnt);
							clsMW.CamEntities.Add(copiedEnt);
						}
						mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
						Cam = new camTp();
						doWireframeContour(mWCalculationOptions, toolFound, ref Cam);
						for (int m = 0; m <= Cam.CamPoints.Count - 1; m++)
						{
							Cam.CamPoints[m].ToolCam = new ToolBase5(toolFound);
						}
						Cam.Tool = new ToolBase5(toolFound);
						if (!((ItemShape[i].Command == drillCommands.DrawingContour) | ItemShape[i].isMillingAtClamperSide))
						{
							bool flag2 = false;
							if (!ItemShape[i].X1First)
							{
								Cam.Aux1First = ItemShape[i].X1First;
								if (ItemShape[i].X2Move != 0.0)
								{
									Cam.Aux2 = ItemShape[i].X2Move;
									Cam.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
									flag2 = true;
								}
								if (ItemShape[i].X1Move != 0.0)
								{
									Cam.Aux1 = ItemShape[i].X1Move;
									Cam.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
									flag2 = true;
								}
							}
							else
							{
								Cam.Aux1First = ItemShape[i].X1First;
								if ((ItemShape[i].X1Move != 0.0) & (Cam.CamPoints.Count > 0))
								{
									Cam.Aux1 = ItemShape[i].X1Move;
									Cam.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
									flag2 = true;
								}
								if ((ItemShape[i].X2Move != 0.0) & (Cam.CamPoints.Count > 0))
								{
									Cam.Aux2 = ItemShape[i].X2Move;
									Cam.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
									flag2 = true;
								}
							}
							if (flag2)
							{
								flag = true;
								if (ItemShape[i].planeName == planeBoxNames.Top)
								{
									Cam.CamPoints[0].PreCodes.Add("G75");
									Cam.CamPoints[0].PreCodes.Add("M27");
								}
								if (ItemShape[i].planeName == planeBoxNames.Bottom)
								{
									Cam.CamPoints[0].PreCodes.Add("G75");
									Cam.CamPoints[0].PreCodes.Add("M29");
								}
								Cam.CamPoints[0].PreCodes.Add("M46");
							}
						}
						else
						{
							if (copiedEntities.Count == 2 && j == 1)
							{
								bool flag3 = false;
								if (!ItemShape[i].X1First)
								{
									Cam.Aux1First = ItemShape[i].X1First;
									if (ItemShape[i].X2Move != 0.0)
									{
										Cam.Aux2 = ItemShape[i].X2Move;
										Cam.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
										flag3 = true;
									}
									if (ItemShape[i].X1Move != 0.0)
									{
										Cam.Aux1 = ItemShape[i].X1Move;
										Cam.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
										flag3 = true;
									}
								}
								else
								{
									Cam.Aux1First = ItemShape[i].X1First;
									if (ItemShape[i].X1Move != 0.0)
									{
										Cam.Aux1 = ItemShape[i].X1Move;
										Cam.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
										flag3 = true;
									}
									if (ItemShape[i].X2Move != 0.0)
									{
										Cam.Aux2 = ItemShape[i].X2Move;
										Cam.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
										flag3 = true;
									}
								}
								if (flag3)
								{
									if (ItemShape[i].planeName == planeBoxNames.Top)
									{
										Cam.CamPoints[0].PreCodes.Add("G75");
										Cam.CamPoints[0].PreCodes.Add("M27");
									}
									if (ItemShape[i].planeName == planeBoxNames.Bottom)
									{
										Cam.CamPoints[0].PreCodes.Add("G75");
										Cam.CamPoints[0].PreCodes.Add("M29");
									}
									Cam.CamPoints[0].PreCodes.Add("M46");
								}
							}
							if (copiedEntities.Count == 3)
							{
								if (ItemShape[i].Command != drillCommands.DrawingContour)
								{
									if (j == 1)
									{
										bool flag4 = false;
										if (ItemShape[i].X2Move != 0.0)
										{
											Cam.Aux2 = ItemShape[i].X2Move;
											Cam.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
											flag4 = true;
										}
										if (flag4)
										{
											if (ItemShape[i].planeName == planeBoxNames.Top)
											{
												Cam.CamPoints[0].PreCodes.Add("G75");
												Cam.CamPoints[0].PreCodes.Add("M27");
											}
											if (ItemShape[i].planeName == planeBoxNames.Bottom)
											{
												Cam.CamPoints[0].PreCodes.Add("G75");
												Cam.CamPoints[0].PreCodes.Add("M29");
											}
											Cam.CamPoints[0].PreCodes.Add("M46");
										}
									}
									if (j == 2)
									{
										bool flag5 = false;
										if (ItemShape[i].X1Move != 0.0)
										{
											Cam.Aux1 = ItemShape[i].X1Move;
											Cam.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
											flag5 = true;
										}
										if (flag5)
										{
											if (ItemShape[i].planeName == planeBoxNames.Top)
											{
												Cam.CamPoints[0].PreCodes.Add("M27");
											}
											if (ItemShape[i].planeName == planeBoxNames.Bottom)
											{
												Cam.CamPoints[0].PreCodes.Add("M29");
											}
											Cam.CamPoints[0].PreCodes.Add("M46");
										}
									}
								}
								else
								{
									if (j == 1)
									{
										bool flag6 = false;
										if (ItemShape[i].X2Move != 0.0 && ItemShape[i].ClockDir == ClockDirectionType.CW)
										{
											Cam.Aux1First = false;
											Cam.Aux2 = ItemShape[i].X2Move;
											Cam.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
											Cam.Aux1 = ItemShape[i].X2Move;
											Cam.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X2Move.ToString("f1"));
											flag6 = true;
										}
										if (ItemShape[i].X1Move != 0.0 && ItemShape[i].ClockDir == ClockDirectionType.CCW)
										{
											Cam.Aux1First = true;
											Cam.Aux1 = ItemShape[i].X1Move;
											Cam.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
											Cam.Aux2 = ItemShape[i].X1Move;
											Cam.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X1Move.ToString("f1"));
											flag6 = true;
										}
										if (flag6)
										{
											if (ItemShape[i].planeName == planeBoxNames.Top)
											{
												Cam.CamPoints[0].PreCodes.Add("G75");
												Cam.CamPoints[0].PreCodes.Add("M27");
											}
											if (ItemShape[i].planeName == planeBoxNames.Bottom)
											{
												Cam.CamPoints[0].PreCodes.Add("G75");
												Cam.CamPoints[0].PreCodes.Add("M29");
											}
											Cam.CamPoints[0].PreCodes.Add("M46");
										}
									}
									if (j == 2)
									{
										bool flag7 = false;
										if (ItemShape[i].X1Move != 0.0)
										{
											if (ItemShape[i].ClockDir == ClockDirectionType.CW)
											{
												Cam.Aux1 = ItemShape[i].X1Move;
												Cam.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
												ItemShape[i].X1Move = ItemShape[i].X1Move + ItemShape[i].X2Move;
											}
											flag7 = true;
										}
										if (ItemShape[i].X2Move != 0.0 && ItemShape[i].ClockDir == ClockDirectionType.CCW)
										{
											Cam.Aux2 = ItemShape[i].X2Move;
											Cam.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
											ItemShape[i].X2Move = ItemShape[i].X1Move + ItemShape[i].X2Move;
											flag7 = true;
										}
										if (flag7)
										{
											if (ItemShape[i].planeName == planeBoxNames.Top)
											{
												Cam.CamPoints[0].PreCodes.Add("G75");
												Cam.CamPoints[0].PreCodes.Add("M27");
											}
											if (ItemShape[i].planeName == planeBoxNames.Bottom)
											{
												Cam.CamPoints[0].PreCodes.Add("G75");
												Cam.CamPoints[0].PreCodes.Add("M29");
											}
											Cam.CamPoints[0].PreCodes.Add("M46");
										}
									}
								}
							}
						}
						if ((ItemShape[i].BoxMinItem.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth && !isTop) & (clsDrill.varDrillCNCSettings.MoveY3AxisToSafeIfOperationAtClamperSideFroBottom || flag))
						{
							if (Cam.CamPoints.Count > 0 && Cam.CamPoints[0].Points.Count > 0)
							{
								TpPnt9D tpPnt9D = new TpPnt9D(Cam.CamPoints[0].Points[0]);
								tpPnt9D.EnableAxes = new AxesEnableWithUVW(x: true, y: false, z: false, a: false, b: false, c: false);
								Cam.CamPoints[0].Points.Insert(0, tpPnt9D);
								tpPnt9D = new TpPnt9D(Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 1]);
								tpPnt9D.P9.Y = 300.0;
								tpPnt9D.EnableAxes = new AxesEnableWithUVW(x: false, y: true, z: false, a: false, b: false, c: false);
								Cam.CamPoints[0].Points.Add(tpPnt9D);
							}
							Cam.SimilationPoint.SimMove.Clear();
							List<Pnt6DSimMove> simPoints = new List<Pnt6DSimMove>();
							if (i == 0 && Cam.CamPoints.Count > 0)
							{
								TpPnt9D pntFirst = new TpPnt9D(0.0, Job.Moves[Job.Moves.Count - 1].Y3Position, Job.Moves[Job.Moves.Count - 1].Z3Position);
								clsInit.cCam5.SimilationPointBetweenTwoPoints(pntFirst, Cam.CamPoints[0].Points[0], ref simPoints, 20.0);
								if (simPoints.Count >= 2)
								{
									simPoints.RemoveAt(simPoints.Count - 1);
								}
							}
							if (Cam.CamPoints.Count > 0)
							{
								clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam, Cam.CamPoints[0], 20.0, 5.0);
							}
							if (simPoints.Count > 0)
							{
								Cam.SimilationPoint.SimMove.InsertRange(0, simPoints);
							}
						}
						if (isTop && Cam.CamPoints.Count > 0)
						{
							if (!(clsDrill.activeJob.Material.Size.Depth - ItemShape[i].ShapeData.Depth <= 2.0))
							{
								Cam.CamPoints[0].Points[0].PreCodes.Add("M33");
							}
							else
							{
								Cam.CamPoints[0].Points[0].PreCodes.Add("M32");
							}
						}
						if (Cam.CamPoints.Count > 0)
						{
							for (int n = 0; n <= Cam.CamPoints.Count - 1; n++)
							{
								camTp3.CamPoints.Add(new camTpPoint(Cam.CamPoints[n]));
							}
							if (!isTop)
							{
								camTp3.PlaneName = planeNames.Bottom;
							}
							else
							{
								camTp3.PlaneName = planeNames.Top;
							}
						}
						if (Cam.SimilationPoint.SimMove.Count > 0)
						{
							if (camTp3.SimilationPoint.SimMove.Count > 0)
							{
								List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
								clsInit.cVector5.LineerInterpolation(camTp3.SimilationPoint.SimMove[camTp3.SimilationPoint.SimMove.Count - 1], Cam.SimilationPoint.SimMove[0], 0.1, ref CalculatedPoints);
								if (CalculatedPoints.Count >= 3)
								{
									CalculatedPoints.RemoveAt(0);
									CalculatedPoints.RemoveAt(CalculatedPoints.Count - 1);
									for (int num4 = 0; num4 <= CalculatedPoints.Count - 1; num4++)
									{
										camTp3.SimilationPoint.SimMove.Add(CalculatedPoints[num4]);
									}
								}
							}
							if (!((Cam.Aux1 != 0.0) & (Cam.Aux2 != 0.0)))
							{
								if (!((Cam.Aux1 != 0.0) & (Cam.Aux2 == 0.0)))
								{
									if ((Cam.Aux1 == 0.0) & (Cam.Aux2 != 0.0))
									{
										Pnt6DSimMove pnt6DSimMove = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
										pnt6DSimMove.Aux2 = Cam.Aux2;
										camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove);
									}
								}
								else
								{
									Pnt6DSimMove pnt6DSimMove2 = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
									pnt6DSimMove2.Aux1 = Cam.Aux1;
									camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove2);
								}
							}
							else if (!Cam.Aux1First)
							{
								Pnt6DSimMove pnt = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
								Pnt6DSimMove pnt6DSimMove3 = new Pnt6DSimMove(pnt);
								pnt6DSimMove3.Aux2 = Cam.Aux2;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove3);
								pnt6DSimMove3 = new Pnt6DSimMove(pnt);
								pnt6DSimMove3.Aux1 = Cam.Aux1;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove3);
							}
							else
							{
								Pnt6DSimMove pnt2 = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
								Pnt6DSimMove pnt6DSimMove4 = new Pnt6DSimMove(pnt2);
								pnt6DSimMove4.Aux1 = Cam.Aux1;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove4);
								pnt6DSimMove4 = new Pnt6DSimMove(pnt2);
								pnt6DSimMove4.Aux2 = Cam.Aux2;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove4);
							}
							for (int num5 = 0; num5 <= Cam.SimilationPoint.SimMove.Count - 1; num5++)
							{
								camTp3.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam.SimilationPoint.SimMove[num5]));
							}
						}
					}
					if (list2.Count <= 0)
					{
						continue;
					}
					clsMW.CamEntities.Clear();
					for (int num6 = 0; num6 <= list2.Count - 1; num6++)
					{
						Entity copiedEnt2 = null;
						buVector5.CopyEntities(list2[num6], ref copiedEnt2);
						clsMW.CamEntities.Add(copiedEnt2);
					}
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
					doWireframePocket(mWCalculationOptions, toolFound, ref Cam2);
					if (!ItemShape[i].isMillingAtClamperSide)
					{
						bool flag8 = false;
						if (!ItemShape[i].X1First)
						{
							Cam2.Aux1First = ItemShape[i].X1First;
							if (ItemShape[i].X2Move != 0.0)
							{
								Cam2.Aux2 = ItemShape[i].X2Move;
								Cam2.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
								flag8 = true;
							}
							if (ItemShape[i].X1Move != 0.0)
							{
								Cam2.Aux1 = ItemShape[i].X1Move;
								Cam2.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
								flag8 = true;
							}
						}
						else
						{
							Cam2.Aux1First = ItemShape[i].X1First;
							if ((ItemShape[i].X1Move != 0.0) & (Cam2.CamPoints.Count > 0))
							{
								Cam2.Aux1 = ItemShape[i].X1Move;
								Cam2.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
								flag8 = true;
							}
							if ((ItemShape[i].X2Move != 0.0) & (Cam2.CamPoints.Count > 0))
							{
								Cam2.Aux2 = ItemShape[i].X2Move;
								Cam2.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
								flag8 = true;
							}
						}
						if (flag8)
						{
							if (ItemShape[i].planeName == planeBoxNames.Top)
							{
								Cam2.CamPoints[0].PreCodes.Add("G75");
								Cam2.CamPoints[0].PreCodes.Add("M27");
							}
							if (ItemShape[i].planeName == planeBoxNames.Bottom)
							{
								Cam2.CamPoints[0].PreCodes.Add("G75");
								Cam2.CamPoints[0].PreCodes.Add("M29");
							}
							Cam2.CamPoints[0].PreCodes.Add("M46");
						}
					}
					else
					{
						if (copiedEntities.Count == 2 && j == 1)
						{
							bool flag9 = false;
							if (!ItemShape[i].X1First)
							{
								Cam2.Aux1First = ItemShape[i].X1First;
								if (ItemShape[i].X2Move != 0.0)
								{
									Cam2.Aux2 = ItemShape[i].X2Move;
									Cam2.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
									flag9 = true;
								}
								if (ItemShape[i].X1Move != 0.0)
								{
									Cam2.Aux1 = ItemShape[i].X1Move;
									Cam2.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
									flag9 = true;
								}
							}
							else
							{
								Cam2.Aux1First = ItemShape[i].X1First;
								if (ItemShape[i].X1Move != 0.0)
								{
									Cam2.Aux1 = ItemShape[i].X1Move;
									Cam2.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
									flag9 = true;
								}
								if (ItemShape[i].X2Move != 0.0)
								{
									Cam2.Aux2 = ItemShape[i].X2Move;
									Cam2.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
									flag9 = true;
								}
							}
							if (flag9)
							{
								if (ItemShape[i].planeName == planeBoxNames.Top)
								{
									Cam2.CamPoints[0].PreCodes.Add("G75");
									Cam2.CamPoints[0].PreCodes.Add("M27");
								}
								if (ItemShape[i].planeName == planeBoxNames.Bottom)
								{
									Cam2.CamPoints[0].PreCodes.Add("G75");
									Cam2.CamPoints[0].PreCodes.Add("M29");
								}
								Cam2.CamPoints[0].PreCodes.Add("M46");
							}
						}
						if (copiedEntities.Count == 3)
						{
							if (j == 1)
							{
								bool flag10 = false;
								if (ItemShape[i].X2Move != 0.0)
								{
									Cam2.Aux2 = ItemShape[i].X2Move;
									Cam2.CamPoints[0].PreCodes.Add("M45 K" + ItemShape[i].X2Move.ToString("f1"));
									flag10 = true;
								}
								if (flag10)
								{
									if (ItemShape[i].planeName == planeBoxNames.Top)
									{
										Cam2.CamPoints[0].PreCodes.Add("G75");
										Cam2.CamPoints[0].PreCodes.Add("M27");
									}
									if (ItemShape[i].planeName == planeBoxNames.Bottom)
									{
										Cam2.CamPoints[0].PreCodes.Add("G75");
										Cam2.CamPoints[0].PreCodes.Add("M29");
									}
									Cam2.CamPoints[0].PreCodes.Add("M46");
								}
							}
							if (j == 2)
							{
								bool flag11 = false;
								if (ItemShape[i].X1Move != 0.0)
								{
									Cam2.Aux1 = ItemShape[i].X1Move;
									Cam2.CamPoints[0].PreCodes.Add("M44 K" + ItemShape[i].X1Move.ToString("f1"));
									flag11 = true;
								}
								if (flag11)
								{
									if (ItemShape[i].planeName == planeBoxNames.Top)
									{
										Cam2.CamPoints[0].PreCodes.Add("M27");
									}
									if (ItemShape[i].planeName == planeBoxNames.Bottom)
									{
										Cam2.CamPoints[0].PreCodes.Add("M29");
									}
									Cam2.CamPoints[0].PreCodes.Add("M46");
								}
							}
						}
					}
					if (ItemShape[i].BoxMinItem.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth && !isTop)
					{
						if (Cam.CamPoints.Count > 0 && Cam.CamPoints[0].Points.Count > 0)
						{
							TpPnt9D tpPnt9D2 = new TpPnt9D(Cam.CamPoints[0].Points[0]);
							tpPnt9D2.EnableAxes = new AxesEnableWithUVW(x: true, y: false, z: false, a: false, b: false, c: false);
							Cam.CamPoints[0].Points.Insert(0, tpPnt9D2);
							tpPnt9D2 = new TpPnt9D(Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 1]);
							tpPnt9D2.P9.Y = 300.0;
							tpPnt9D2.EnableAxes = new AxesEnableWithUVW(x: false, y: true, z: false, a: false, b: false, c: false);
							Cam.CamPoints[0].Points.Add(tpPnt9D2);
						}
						Cam.SimilationPoint.SimMove.Clear();
						List<Pnt6DSimMove> simPoints2 = new List<Pnt6DSimMove>();
						if (i == 0)
						{
							TpPnt9D pntFirst2 = new TpPnt9D(0.0, Job.Moves[Job.Moves.Count - 1].Y3Position, Job.Moves[Job.Moves.Count - 1].Z3Position);
							clsInit.cCam5.SimilationPointBetweenTwoPoints(pntFirst2, Cam.CamPoints[0].Points[0], ref simPoints2, 20.0);
							if (simPoints2.Count >= 2)
							{
								simPoints2.RemoveAt(simPoints2.Count - 1);
							}
						}
						clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam, Cam.CamPoints[0]);
						if (simPoints2.Count > 0)
						{
							Cam.SimilationPoint.SimMove.InsertRange(0, simPoints2);
						}
					}
					if (Cam2.CamPoints.Count > 0)
					{
						for (int num7 = 0; num7 <= Cam2.CamPoints.Count - 1; num7++)
						{
							camTp3.CamPoints.Add(new camTpPoint(Cam2.CamPoints[num7]));
							if (!isTop)
							{
								camTp3.PlaneName = planeNames.Bottom;
								continue;
							}
							if (num7 == 0)
							{
								camTp3.CamPoints[num7].PreCodes.Add("M34");
							}
							if (num7 == Cam2.CamPoints.Count - 1)
							{
								camTp3.CamPoints[num7].AfterCodes.Add("M35");
							}
							if (camTp3.CamPoints.Count > 0)
							{
								if (!(clsDrill.activeJob.Material.Size.Depth - ItemShape[i].ShapeData.Depth <= 2.0))
								{
									camTp3.CamPoints[0].Points[0].PreCodes.Add("M33");
								}
								else
								{
									camTp3.CamPoints[0].Points[0].PreCodes.Add("M32");
								}
							}
							camTp3.PlaneName = planeNames.Top;
						}
					}
					if (Cam2.SimilationPoint.SimMove.Count <= 0)
					{
						continue;
					}
					if (camTp3.SimilationPoint.SimMove.Count > 0)
					{
						List<Pnt6DSimMove> CalculatedPoints2 = new List<Pnt6DSimMove>();
						clsInit.cVector5.LineerInterpolation(camTp3.SimilationPoint.SimMove[camTp3.SimilationPoint.SimMove.Count - 1], Cam2.SimilationPoint.SimMove[0], 0.1, ref CalculatedPoints2);
						if (CalculatedPoints2.Count >= 3)
						{
							CalculatedPoints2.RemoveAt(0);
							CalculatedPoints2.RemoveAt(CalculatedPoints2.Count - 1);
							for (int num8 = 0; num8 <= CalculatedPoints2.Count - 1; num8++)
							{
								camTp3.SimilationPoint.SimMove.Add(CalculatedPoints2[num8]);
							}
						}
					}
					if (!((Cam2.Aux1 != 0.0) & (Cam2.Aux2 != 0.0)))
					{
						if (!((Cam2.Aux1 != 0.0) & (Cam2.Aux2 == 0.0)))
						{
							if ((Cam2.Aux1 == 0.0) & (Cam2.Aux2 != 0.0))
							{
								Pnt6DSimMove pnt6DSimMove5 = new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[Cam2.SimilationPoint.SimMove.Count - 1]);
								pnt6DSimMove5.Aux2 = Cam2.Aux2;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove5);
							}
						}
						else
						{
							Pnt6DSimMove pnt6DSimMove6 = new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[Cam2.SimilationPoint.SimMove.Count - 1]);
							pnt6DSimMove6.Aux1 = Cam2.Aux1;
							camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove6);
						}
					}
					else if (!Cam2.Aux1First)
					{
						Pnt6DSimMove pnt3 = new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[Cam2.SimilationPoint.SimMove.Count - 1]);
						Pnt6DSimMove pnt6DSimMove7 = new Pnt6DSimMove(pnt3);
						pnt6DSimMove7.Aux2 = Cam2.Aux2;
						camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove7);
						pnt6DSimMove7 = new Pnt6DSimMove(pnt3);
						pnt6DSimMove7.Aux1 = Cam2.Aux1;
						camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove7);
					}
					else
					{
						Pnt6DSimMove pnt4 = new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[Cam2.SimilationPoint.SimMove.Count - 1]);
						Pnt6DSimMove pnt6DSimMove8 = new Pnt6DSimMove(pnt4);
						pnt6DSimMove8.Aux1 = Cam2.Aux1;
						camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove8);
						pnt6DSimMove8 = new Pnt6DSimMove(pnt4);
						pnt6DSimMove8.Aux2 = Cam2.Aux2;
						camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove8);
					}
					for (int num9 = 0; num9 <= Cam2.SimilationPoint.SimMove.Count - 1; num9++)
					{
						camTp3.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[num9]));
					}
				}
			}
			if (ItemShape[i].Command == drillCommands.Engraving)
			{
				for (int num10 = 0; num10 <= ItemShape[i].solidEntities.Count - 1; num10++)
				{
					if (ItemShape[i].isRough)
					{
						Entity copiedEntity3 = null;
						buEntity.Copy(ItemShape[i].solidEntities[num10], ref copiedEntity3);
						list4.Add(copiedEntity3);
					}
					if (ItemShape[i].isFinish)
					{
						Entity copiedEntity4 = null;
						buEntity.Copy(ItemShape[i].solidEntities[num10], ref copiedEntity4);
						list5.Add(copiedEntity4);
					}
				}
			}
			if (ItemShape[i].isDrill)
			{
				Entity entity = new Circle(Plane.XY, ItemShape[i].Center, ItemShape[i].ShapeData.Diameter / 2.0);
				CustomData customData = new CustomData();
				customData.infoDepth = ItemShape[i].ShapeData.Depth;
				entity.EntityData = customData;
				list3.Add(entity);
			}
		}
		if (list4.Count > 0)
		{
			clsMW.CamEntities.Clear();
			for (int num11 = 0; num11 <= list4.Count - 1; num11++)
			{
				Entity copiedEnt3 = null;
				buVector5.CopyEntities(list4[num11], ref copiedEnt3);
				Plane plane2 = new Plane(new Point3D(), Vector3D.AxisX, Vector3D.AxisZ);
				Mirror xform = new Mirror(plane2);
				copiedEnt3.TransformBy(xform);
				plane2 = new Plane(new Point3D(), Vector3D.AxisY, Vector3D.AxisZ);
				xform = new Mirror(plane2);
				copiedEnt3.TransformBy(xform);
				clsMW.CamEntities.Add(copiedEnt3);
			}
			if (clsMW.CamEntities.Count > 0)
			{
				mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.Mode = CamMode.TriangularMesh;
				mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.Rough;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.isBuWireframeCalculation = false;
				mWCalculationOptions.AddToCamListInMWCalculation = false;
				mWCalculationOptions.DontShowDialogBox = true;
				mWCalculationOptions.isBuSort = false;
				mWCalculationOptions.UseStartPoint = false;
				mWCalculationOptions.UseConstantStartPoint = false;
				mWCalculationOptions.StartPointX = 0.0;
				mWCalculationOptions.StartPointY = 0.0;
				mWCalculationOptions.ShowProgressForm = false;
				doTriangleMeshRough(mWCalculationOptions, toolFound, ref Cam3);
				if (Cam3.CamPoints.Count > 0)
				{
					Cam3.CamPoints[0].PreCodes.Add("M34");
					for (int num12 = 0; num12 <= Cam3.CamPoints.Count - 1; num12++)
					{
						camTp3.CamPoints.Add(new camTpPoint(Cam3.CamPoints[num12]));
					}
					for (int num13 = 0; num13 <= Cam3.SimilationPoint.SimMove.Count - 1; num13++)
					{
						camTp3.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam3.SimilationPoint.SimMove[num13]));
					}
				}
			}
		}
		if (list5.Count > 0)
		{
			clsMW.CamEntities.Clear();
			for (int num14 = 0; num14 <= list5.Count - 1; num14++)
			{
				Entity copiedEnt4 = null;
				buVector5.CopyEntities(list5[num14], ref copiedEnt4);
				Plane plane3 = new Plane(new Point3D(), Vector3D.AxisX, Vector3D.AxisZ);
				Mirror xform2 = new Mirror(plane3);
				copiedEnt4.TransformBy(xform2);
				plane3 = new Plane(new Point3D(), Vector3D.AxisY, Vector3D.AxisZ);
				xform2 = new Mirror(plane3);
				copiedEnt4.TransformBy(xform2);
				clsMW.CamEntities.Add(copiedEnt4);
			}
			if (clsMW.CamEntities.Count > 0)
			{
				mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.Mode = CamMode.TriangularMesh;
				mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.isBuWireframeCalculation = false;
				mWCalculationOptions.AddToCamListInMWCalculation = false;
				mWCalculationOptions.DontShowDialogBox = true;
				mWCalculationOptions.isBuSort = false;
				mWCalculationOptions.UseStartPoint = false;
				mWCalculationOptions.UseConstantStartPoint = false;
				mWCalculationOptions.StartPointX = 0.0;
				mWCalculationOptions.StartPointY = 0.0;
				mWCalculationOptions.ShowProgressForm = false;
				doTriangleMeshParalelCut(mWCalculationOptions, toolFound, ref Cam4);
				if (Cam4.CamPoints.Count > 0)
				{
					Cam4.CamPoints[0].PreCodes.Add("M34");
					for (int num15 = 0; num15 <= Cam4.CamPoints.Count - 1; num15++)
					{
						camTp3.CamPoints.Add(new camTpPoint(Cam4.CamPoints[num15]));
					}
					for (int num16 = 0; num16 <= Cam4.SimilationPoint.SimMove.Count - 1; num16++)
					{
						camTp3.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam4.SimilationPoint.SimMove[num16]));
					}
				}
			}
		}
		if (list3.Count > 0)
		{
			double num17 = 0.0;
			clsMW.CamEntities.Clear();
			for (int num18 = 0; num18 <= list3.Count - 1; num18++)
			{
				camTp2 = new camTp();
				clsMW.CamEntities.Clear();
				Entity copiedEnt5 = null;
				num17 = (isTop ? (clsDrill.activeJob.Material.Size.Depth - ((CustomData)list3[num18].EntityData).infoDepth) : (0.0 - ((CustomData)list3[num18].EntityData).infoDepth));
				buVector5.CopyEntities(list3[num18], ref copiedEnt5);
				clsMW.CamEntities.Add(copiedEnt5);
				ToolBase5 tool = new ToolBase5();
				for (int num19 = 0; num19 <= ccVars.Tools[0].Tools.Count - 1; num19++)
				{
					Circle circle = list3[num18] as Circle;
					if (!isTop)
					{
						if (ccVars.Tools[0].Tools[num19].Data.No == 41 && ccVars.Tools[0].Tools[num19].Geometry.Diameter == circle.Diameter)
						{
							tool = new ToolBase5(ccVars.Tools[0].Tools[num19]);
						}
					}
					else if (((ccVars.Tools[0].Tools[num19].Data.No >= 31) & (ccVars.Tools[0].Tools[num19].Data.No <= 35)) && ccVars.Tools[0].Tools[num19].Geometry.Diameter == circle.Diameter)
					{
						tool = new ToolBase5(ccVars.Tools[0].Tools[num19]);
					}
				}
				doDrill(mWCalculationOptions, num17, tool, ref camTp2);
				if (isTop && camTp2.CamPoints.Count > 0)
				{
					if (!(num17 <= 2.0))
					{
						camTp2.CamPoints[0].Points[0].PreCodes.Add("M33");
					}
					else
					{
						camTp2.CamPoints[0].Points[0].PreCodes.Add("M32");
					}
				}
				if (camTp2.CamPoints.Count > 0)
				{
					for (int num20 = 0; num20 <= camTp2.CamPoints.Count - 1; num20++)
					{
						camTpPoint camTpPoint2 = new camTpPoint(camTp2.CamPoints[num20]);
						camTpPoint2.ToolCam = new ToolBase5(tool);
						camTp3.CamPoints.Add(camTpPoint2);
					}
				}
				if (camTp2.SimilationPoint.SimMove.Count > 0)
				{
					for (int num21 = 0; num21 <= camTp2.SimilationPoint.SimMove.Count - 1; num21++)
					{
						camTp3.SimilationPoint.SimMove.Add(new Pnt6DSimMove(camTp2.SimilationPoint.SimMove[num21]));
					}
				}
			}
		}
		if (clsItem.FrmProgress != null)
		{
			clsItem.FrmProgress.Visible = false;
		}
		new List<DrillMove>();
		if (!isTop)
		{
			double num22 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].XPosition;
			double num23 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
			double num24 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
			y = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y1Position;
			y2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y2Position;
			y3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y3Position;
			z = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z1Position;
			z2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z2Position;
			z3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z3Position;
			DrillMove item = new DrillMove(num23, num24, y, y2, y3, z, z2, z3, DrillMoveCommand.SetPiston, num22, DrillCNCMode.None, drillPlaneNames.Bottom, 41, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			Job.SimulationMoves.Add(item);
			double num25 = 0.0;
			double num26 = 0.0;
			for (int num27 = 0; num27 <= camTp3.SimilationPoint.SimMove.Count - 1; num27++)
			{
				if (!((camTp3.SimilationPoint.SimMove[num27].Aux1 != 0.0) | (camTp3.SimilationPoint.SimMove[num27].Aux2 != 0.0)))
				{
					num23 = num23 + camTp3.SimilationPoint.SimMove[num27].X - num22;
					num24 = num24 + camTp3.SimilationPoint.SimMove[num27].X - num22;
					xPos = camTp3.SimilationPoint.SimMove[num27].X + clsDrill.varDrillCNCSettings.Tool270XZeroOffset;
					num = num23 + clsDrill.varDrillCNCSettings.Tool270XZeroOffset + num25;
					num2 = num24 + clsDrill.varDrillCNCSettings.Tool270XZeroOffset + num26;
					y = y3;
					y2 = clsDrill.varDrillCNCSettings.ParkY2;
					y3 = camTp3.SimilationPoint.SimMove[num27].Y;
					z3 = camTp3.SimilationPoint.SimMove[num27].Z;
					if (num27 == camTp3.SimilationPoint.SimMove.Count - 1)
					{
						item = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.ResetPiston, xPos, DrillCNCMode.None, drillPlaneNames.Bottom, 41, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
						Job.SimulationMoves.Add(item);
					}
					item = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.AxisMove, xPos);
					if (num27 == 0)
					{
						List<DrillMove> calcSimMoves = new List<DrillMove>();
						clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], item, 20.0, ref calcSimMoves);
						if (calcSimMoves.Count > 2)
						{
							calcSimMoves.RemoveAt(calcSimMoves.Count - 1);
							for (int num28 = 0; num28 <= calcSimMoves.Count - 1; num28++)
							{
								Job.SimulationMoves.Add(calcSimMoves[num28]);
							}
						}
					}
					Job.SimulationMoves.Add(item);
					num22 = camTp3.SimilationPoint.SimMove[num27].X;
				}
				else
				{
					if (camTp3.SimilationPoint.SimMove[num27].Aux1 != 0.0)
					{
						num25 += camTp3.SimilationPoint.SimMove[num27].Aux1;
					}
					if (camTp3.SimilationPoint.SimMove[num27].Aux2 != 0.0)
					{
						num26 += camTp3.SimilationPoint.SimMove[num27].Aux2;
					}
				}
			}
		}
		else
		{
			double num29 = 0.0;
			double num30 = 0.0;
			double num31 = 0.0;
			DrillMove drillMove = new DrillMove();
			if (Job.SimulationMoves.Count > 0)
			{
				num29 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].XPosition;
				num30 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
				num31 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
				num = num30;
				num2 = num31;
				y = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y1Position;
				y2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y2Position;
				y3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y3Position;
				z = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z1Position;
				z2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z2Position;
				z3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z3Position;
				drillMove = new DrillMove(num30, num31, y, y2, y3, z, z2, z3, DrillMoveCommand.SetPiston, num29, DrillCNCMode.None, drillPlaneNames.Top, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
			}
			double num32 = 0.0;
			double num33 = 0.0;
			for (int num34 = 0; num34 <= camTp3.SimilationPoint.SimMove.Count - 1; num34++)
			{
				if (!((camTp3.SimilationPoint.SimMove[num34].Aux1 != 0.0) | (camTp3.SimilationPoint.SimMove[num34].Aux2 != 0.0)))
				{
					num30 = num30 + camTp3.SimilationPoint.SimMove[num34].X - num29;
					num31 = num31 + camTp3.SimilationPoint.SimMove[num34].X - num29;
					xPos = camTp3.SimilationPoint.SimMove[num34].X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
					num = num30 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num32;
					num2 = num31 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num33;
					y = camTp3.SimilationPoint.SimMove[num34].Y;
					z = camTp3.SimilationPoint.SimMove[num34].Z;
					if (num34 == camTp3.SimilationPoint.SimMove.Count - 1)
					{
						drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.ResetPiston, xPos, DrillCNCMode.None, drillPlaneNames.Top, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
						Job.SimulationMoves.Add(drillMove);
					}
					drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.AxisMove, xPos);
					if (num34 == 0)
					{
						List<DrillMove> calcSimMoves2 = new List<DrillMove>();
						clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove, 20.0, ref calcSimMoves2);
						if (calcSimMoves2.Count > 2)
						{
							calcSimMoves2.RemoveAt(calcSimMoves2.Count - 1);
							for (int num35 = 0; num35 <= calcSimMoves2.Count - 1; num35++)
							{
								Job.SimulationMoves.Add(calcSimMoves2[num35]);
							}
						}
					}
					Job.SimulationMoves.Add(drillMove);
					num29 = camTp3.SimilationPoint.SimMove[num34].X;
					continue;
				}
				if (camTp3.SimilationPoint.SimMove[num34].Aux1 != 0.0)
				{
					num32 += camTp3.SimilationPoint.SimMove[num34].Aux1;
					drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper1Up, xPos, DrillCNCMode.None, drillPlaneNames.Top, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					Job.SimulationMoves.Add(drillMove);
					List<double> Values = new List<double>();
					buNumeric5.DevideMinMaxValueByNumber(0.0, camTp3.SimilationPoint.SimMove[num34].Aux1, 5, ref Values);
					_ = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
					for (int num36 = 1; num36 <= Values.Count - 1; num36++)
					{
						drillMove = new DrillMove(num + Values[num36], num2, y, y2, y3, z, z2, z3, DrillMoveCommand.AxisMove, xPos, DrillCNCMode.None, drillPlaneNames.Top, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
						Job.SimulationMoves.Add(drillMove);
					}
					num += camTp3.SimilationPoint.SimMove[num34].Aux1;
					drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper1Down, xPos, DrillCNCMode.None, drillPlaneNames.Top, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					Job.SimulationMoves.Add(drillMove);
				}
				if (camTp3.SimilationPoint.SimMove[num34].Aux2 != 0.0)
				{
					num33 += camTp3.SimilationPoint.SimMove[num34].Aux2;
					drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper2Up, xPos, DrillCNCMode.None, drillPlaneNames.Top, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					Job.SimulationMoves.Add(drillMove);
					List<double> Values2 = new List<double>();
					buNumeric5.DevideMinMaxValueByNumber(0.0, camTp3.SimilationPoint.SimMove[num34].Aux2, 5, ref Values2);
					_ = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
					for (int num37 = 1; num37 <= Values2.Count - 1; num37++)
					{
						drillMove = new DrillMove(num, num2 + Values2[num37], y, y2, y3, z, z2, z3, DrillMoveCommand.AxisMove, xPos, DrillCNCMode.None, drillPlaneNames.Top, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
						Job.SimulationMoves.Add(drillMove);
					}
					num2 += camTp3.SimilationPoint.SimMove[num34].Aux2;
					drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper2Down, xPos, DrillCNCMode.None, drillPlaneNames.Top, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					Job.SimulationMoves.Add(drillMove);
				}
			}
		}
		if (camTp3.CamPoints.Count > 0 && isTop)
		{
			camTp3.PreCodes.Add("G75");
			camTp3.PreCodes.Add("M154");
			camTp3.PreCodes.Add("G75");
			camTp3.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			camTp3.PreCodes.Add("G75");
			camTp3.PreCodes.Add("M154");
			camTp3.AfterCodes.Add("G53");
			camTp3.AfterCodes.Add("G0 X0");
			camTp3.AfterCodes.Add("G75");
			camTp3.AfterCodes.Add("M154");
			camTp3.AfterCodes.Add("G75");
			camTp3.AfterCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			camTp3.AfterCodes.Add("G75");
			for (int num38 = 0; num38 <= camTp3.CamPoints.Count - 1; num38++)
			{
				camTp3.CamPoints[num38].PreCodes.Add("M6 K" + camTp3.CamPoints[num38].ToolCam.Data.No);
				camTp3.CamPoints[num38].PreCodes.Add("M3 K" + camTp3.CamPoints[num38].ToolCam.CamData.SpindleSpeed);
				for (int num39 = 0; num39 <= camTp3.CamPoints[num38].Points.Count - 1; num39++)
				{
					if (!camTp3.CamPoints[num38].Points[num39].PlungeAxisMovement)
					{
						camTp3.CamPoints[num38].Points[num39].AfterCodes.Add("M27");
						num39 = camTp3.CamPoints[num38].Points.Count;
					}
				}
				bool flag12 = false;
				bool flag13 = false;
				if (num3 < clsDrill.varDrillCNCSettings.HorizontalTableTopSurfaceZLimit)
				{
					camTp3.CamPoints[num38].Points[0].AfterCodes.Add("M22");
				}
				for (int num40 = 0; num40 <= camTp3.CamPoints[num38].Points.Count - 1; num40++)
				{
					if (num40 > 0)
					{
						if (camTp3.CamPoints[num38].Points[num40].PlungeAxisMovement && camTp3.CamPoints[num38].Points[num40].P9.Z < camTp3.CamPoints[num38].Points[num40 - 1].P9.Z && !flag12)
						{
							camTp3.CamPoints[num38].Points[num40].PreCodes.Add("M20");
							flag12 = true;
							flag13 = false;
						}
						if (camTp3.CamPoints[num38].Points[num40].P9.Z > camTp3.CamPoints[num38].Points[num40 - 1].P9.Z && !flag13)
						{
							camTp3.CamPoints[num38].Points[num40].PreCodes.Add("M21");
							flag12 = false;
							flag13 = true;
						}
					}
				}
				if (camTp3.CamPoints[num38].Points.Count <= 0)
				{
					continue;
				}
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(camTp3.CamPoints[num38].Points, ref MinPoint, ref MaxPoint);
				if (!(MinPoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0))
				{
					if (num38 < camTp3.CamPoints.Count - 1)
					{
						MinPoint = new Point3D();
						MaxPoint = new Point3D();
						clsInit.cVector5.BoxSizeCalculate(camTp3.CamPoints[num38 + 1].Points, ref MinPoint, ref MaxPoint);
						if (MinPoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)
						{
							camTp3.CamPoints[num38].Points[camTp3.CamPoints[num38].Points.Count - 1].AfterCodes.Add("M26");
						}
					}
				}
				else
				{
					camTp3.CamPoints[num38].Points[camTp3.CamPoints[num38].Points.Count - 1].AfterCodes.Add("M26");
				}
			}
			Job.Cams.Add(camTp3);
		}
		if (!(camTp3.CamPoints.Count > 0 && !isTop))
		{
			return;
		}
		camTp3.PreCodes.Add("G75");
		camTp3.PreCodes.Add("M154");
		camTp3.PreCodes.Add("G75");
		camTp3.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
		camTp3.PreCodes.Add("G75");
		camTp3.PreCodes.Add("M154");
		camTp3.PreCodes.Add("M6 K41");
		camTp3.PreCodes.Add("M32");
		camTp3.AfterCodes.Add("G53");
		camTp3.AfterCodes.Add("G0 X0");
		camTp3.AfterCodes.Add("G75");
		camTp3.AfterCodes.Add("M154");
		camTp3.AfterCodes.Add("G75");
		camTp3.AfterCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
		camTp3.AfterCodes.Add("G75");
		for (int num41 = 0; num41 <= camTp3.CamPoints.Count - 1; num41++)
		{
			bool flag14 = false;
			bool flag15 = false;
			for (int num42 = 0; num42 <= camTp3.CamPoints[num41].Points.Count - 1; num42++)
			{
				if (num42 > 0 && camTp3.CamPoints[num41].Points[num42].PlungeAxisMovement)
				{
					if (camTp3.CamPoints[num41].Points[num42].P9.Z < camTp3.CamPoints[num41].Points[num42 - 1].P9.Z && !flag14)
					{
						camTp3.CamPoints[num41].Points[num42].PreCodes.Add("M50");
						camTp3.CamPoints[num41].Points[num42].PreCodes.Add("M20");
						camTp3.CamPoints[num41].Points[num42].PreCodes.Add("G75");
						flag14 = true;
						flag15 = false;
					}
					if (camTp3.CamPoints[num41].Points[num42].P9.Z > camTp3.CamPoints[num41].Points[num42 - 1].P9.Z && !flag15)
					{
						camTp3.CamPoints[num41].Points[num42].PreCodes.Add("M21");
						flag15 = true;
						flag14 = false;
					}
				}
			}
		}
		Job.Cams.Add(camTp3);
	}

	public void doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		buMWDrillVars.varCamContour.buPar.Runtime.SimG0DevideLength = 100.0;
		buMWDrillVars.varCamContour.buPar.Runtime.SimG1DevideLength = 40.0;
		buMWDrillVars.varCamContour.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDrillVars.varCamContour.mwPar, buMWDrillVars.varCamContour.buPar);
		clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWDrillVars.varCamContour.mwPar, buMWDrillVars.varCamContour.buPar, out clsMW.varbuCamWFContourPars);
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
		buMWDrillVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWDrillVars.varCamContour.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}

	public void doWireframePocket(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		MWCalcoptions.CamWireframeType = CamWireFrameType.Pocket;
		buMWDrillVars.varCamRough.buPar.Runtime.SimG0DevideLength = 100.0;
		buMWDrillVars.varCamRough.buPar.Runtime.SimG1DevideLength = 40.0;
		buMWDrillVars.varCamRough.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDrillVars.varCamRough.mwPar, buMWDrillVars.varCamRough.buPar);
		clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWDrillVars.varCamRough.mwPar, buMWDrillVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
		buMWDrillVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buMWDrillVars.varCamRough.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}

	public void doTriangleMeshRough(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		buMWDrillVars.varCamContour.buPar.Runtime.SimG0DevideLength = 100.0;
		buMWDrillVars.varCamContour.buPar.Runtime.SimG1DevideLength = 40.0;
		MWCalcoptions.CamTriMeshType = CamTriangularMeshType.Rough;
		buMWDrillVars.varCamMeshRough.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDrillVars.varCamMeshRough.mwPar, buMWDrillVars.varCamMeshRough.buPar);
		clsMW.varMWCamMeshRoughPars = buMWCalcs.CopyCamParameter(buMWDrillVars.varCamMeshRough.mwPar, buMWDrillVars.varCamMeshRough.buPar, out clsMW.varbuCamMeshRoughPars);
		camResult Result = null;
		int num = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, Tool, ref Cam, ref Result);
		buMWDrillVars.varCamMeshRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRoughPars, clsMW.varbuCamMeshRoughPars, out buMWDrillVars.varCamMeshRough.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}

	public void doTriangleMeshParalelCut(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		buMWDrillVars.varCamContour.buPar.Runtime.SimG0DevideLength = 100.0;
		buMWDrillVars.varCamContour.buPar.Runtime.SimG1DevideLength = 40.0;
		MWCalcoptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
		buMWDrillVars.varCamMeshParalelCut.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDrillVars.varCamMeshParalelCut.mwPar, buMWDrillVars.varCamMeshParalelCut.buPar);
		clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWDrillVars.varCamMeshParalelCut.mwPar, buMWDrillVars.varCamMeshParalelCut.buPar, out clsMW.varbuCamMeshParallelPars);
		camResult Result = null;
		int num = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, Tool, ref Cam, ref Result);
		buMWDrillVars.varCamMeshParalelCut.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWDrillVars.varCamMeshParalelCut.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}

	public void doDrill(MWCalculationOptions MWCalcoptions, double Depth, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		buMWDrillVars.varCamContour.buPar.Runtime.SimG0DevideLength = 20.0;
		buMWDrillVars.varCamContour.buPar.Runtime.SimG1DevideLength = 10.0;
		clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(buMWDrillVars.varCamContour.mwPar, buMWDrillVars.varCamContour.buPar, out clsMW.varbuCamDrillPars);
		camResult Result = null;
		clsMW.varbuCamDrillPars.Drill.EndHeight = Depth;
		clsMW.varbuCamDrillPars.Distances.Rapid = clsDrill.activeJob.Material.Size.Depth - Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		clsMW.varbuCamDrillPars.Distances.Safe = clsDrill.varDrillCNCSettings.distanceSafe;
		clsMW.varMWCamDrillPars.MachParam.LinkParams.ClearancePlaneHeight = clsDrill.varDrillCNCSettings.distanceSafe;
		clsMW.varMWCamDrillPars.MachParam.LinkParams.RetractPlaneIncremental = clsDrill.activeJob.Material.Size.Depth - Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
		ToolBase5 toolBase = new ToolBase5(Tool);
		toolBase.Purpose = ToolPurpose.Drilling;
		int num = clsInit.appMW.doDrill(MWCalcoptions, toolBase, ref Cam, ref Result);
		buMWDrillVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWDrillVars.varCamContour.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}

	public void RecommentedTools()
	{
		List<DrillCalcItem> Items = new List<DrillCalcItem>();
		DrillJob drillJob = new DrillJob(clsDrill.activeJob);
		FindDrillsAtPlane(drillJob, planeBoxNames.Top, ref Items);
		drillJob.ItemCalc.Clear();
		drillJob.ItemCalc.AddRange(Items);
	}

	public bool FindToolWithToolNo(int ToolNo, ref ToolBase5 foundTool)
	{
		for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
		{
			if (clsDrill.ToolList[i].Data.No == ToolNo)
			{
				foundTool = new ToolBase5(clsDrill.ToolList[i]);
				return true;
			}
		}
		return false;
	}

	public bool FindTool(DrillCalcItem Item, FindToolSettings Settings, ref ToolBase5 foundTool)
	{
		if (Item.Type == DrillItemType.Drill)
		{
			if (Item.planeName != planeBoxNames.Front)
			{
				if (Item.planeName != planeBoxNames.Left)
				{
					if (Item.planeName != planeBoxNames.Right)
					{
						if (Item.planeName != planeBoxNames.Top)
						{
							if (Item.planeName == planeBoxNames.Back)
							{
								for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
								{
									if ((clsDrill.ToolList[i].Geometry.ToolDirection.X == 1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter))
									{
										int num = -1;
										num = ((Item.Center.Y < Settings.Y1Y2ZoneSelectionLimit) ? 1 : 0);
										if (clsDrill.ToolList[i].Data.GroupIndex == num)
										{
											foundTool = new ToolBase5(clsDrill.ToolList[i]);
											return true;
										}
									}
								}
							}
						}
						else
						{
							for (int j = 0; j <= clsDrill.ToolList.Count - 1; j++)
							{
								if ((clsDrill.ToolList[j].Geometry.ToolDirection.Z == -1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter))
								{
									int num2 = -1;
									num2 = ((Item.Center.Y < Settings.Y1Y2ZoneSelectionLimit) ? 1 : 0);
									if (clsDrill.ToolList[j].Data.GroupIndex == num2)
									{
										foundTool = new ToolBase5(clsDrill.ToolList[j]);
										return true;
									}
								}
							}
						}
					}
					else
					{
						for (int k = 0; k <= clsDrill.ToolList.Count - 1; k++)
						{
							if (((clsDrill.ToolList[k].Geometry.ToolDirection.Y == -1.0) & (clsDrill.ToolList[k].Geometry.Diameter == Item.Diameter)) && clsDrill.ToolList[k].Data.GroupIndex == 0)
							{
								foundTool = new ToolBase5(clsDrill.ToolList[k]);
								return true;
							}
						}
					}
				}
				else
				{
					for (int l = 0; l <= clsDrill.ToolList.Count - 1; l++)
					{
						if (((clsDrill.ToolList[l].Geometry.ToolDirection.Y == 1.0) & (clsDrill.ToolList[l].Geometry.Diameter == Item.Diameter)) && clsDrill.ToolList[l].Data.GroupIndex == 1)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[l]);
							return true;
						}
					}
				}
			}
			else
			{
				for (int m = 0; m <= clsDrill.ToolList.Count - 1; m++)
				{
					if ((clsDrill.ToolList[m].Geometry.ToolDirection.X == -1.0) & (clsDrill.ToolList[m].Geometry.Diameter == Item.Diameter))
					{
						int num3 = -1;
						num3 = ((Item.Center.Y < Settings.Y1Y2ZoneSelectionLimit) ? 1 : 0);
						if (clsDrill.ToolList[m].Data.GroupIndex == num3)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[m]);
							return true;
						}
					}
				}
			}
		}
		if (Item.Type == DrillItemType.Slot && Item.planeName == planeBoxNames.Top)
		{
			for (int n = 0; n <= clsDrill.ToolList.Count - 1; n++)
			{
				if (clsDrill.ToolList[n].Geometry.GeometryType == ToolType.Slot)
				{
					int num4 = -1;
					num4 = ((Item.Center.Y < Settings.Y1Y2ZoneSelectionLimit) ? 1 : 0);
					if (clsDrill.ToolList[n].Data.GroupIndex == num4)
					{
						foundTool = new ToolBase5(clsDrill.ToolList[n]);
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool FindToolFromBlock(DrillCalcItem Item, int BlockIndex, FindToolSettings Settings, ref ToolBase5 foundTool)
	{
		foundTool = null;
		if (Item.Type == DrillItemType.Slot)
		{
			for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
			{
				if (!clsDrill.ToolList[i].Data.Used | Settings.IgnoreUsedInfo)
				{
					if (Settings.Plane == planeBoxNames.Top && ((clsDrill.ToolList[i].Geometry.GeometryType == ToolType.Slot) & (clsDrill.ToolList[i].Geometry.Thickness == Item.Width)) && ((BlockIndex == clsDrill.ToolList[i].Data.GroupIndex) & (clsDrill.ToolList[i].Data.No > Settings.StartToolIndex)))
					{
						foundTool = new ToolBase5(clsDrill.ToolList[i]);
						clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
						i = clsDrill.ToolList.Count;
					}
					if (Settings.Plane == planeBoxNames.Bottom && ((clsDrill.ToolList[i].Geometry.ToolDirection.Z == 1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[i].Data.GroupIndex) & (clsDrill.ToolList[i].Data.No > Settings.StartToolIndex)))
					{
						foundTool = new ToolBase5(clsDrill.ToolList[i]);
						clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
						i = clsDrill.ToolList.Count;
					}
					if (Settings.Plane == planeBoxNames.Front && ((clsDrill.ToolList[i].Geometry.ToolDirection.X == -1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[i].Data.GroupIndex) & (clsDrill.ToolList[i].Data.No > Settings.StartToolIndex)))
					{
						foundTool = new ToolBase5(clsDrill.ToolList[i]);
						clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
						i = clsDrill.ToolList.Count;
					}
					if (Settings.Plane == planeBoxNames.Back && ((clsDrill.ToolList[i].Geometry.ToolDirection.X == 1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[i].Data.GroupIndex) & (clsDrill.ToolList[i].Data.No > Settings.StartToolIndex)))
					{
						foundTool = new ToolBase5(clsDrill.ToolList[i]);
						clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
						i = clsDrill.ToolList.Count;
					}
					if (Settings.Plane == planeBoxNames.Left && ((clsDrill.ToolList[i].Geometry.ToolDirection.Y == 1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[i].Data.GroupIndex) & (clsDrill.ToolList[i].Data.No > Settings.StartToolIndex)))
					{
						foundTool = new ToolBase5(clsDrill.ToolList[i]);
						clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
						i = clsDrill.ToolList.Count;
					}
					if (Settings.Plane == planeBoxNames.Right && ((clsDrill.ToolList[i].Geometry.ToolDirection.Y == -1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[i].Data.GroupIndex) & (clsDrill.ToolList[i].Data.No > Settings.StartToolIndex)))
					{
						foundTool = new ToolBase5(clsDrill.ToolList[i]);
						clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
						i = clsDrill.ToolList.Count;
					}
				}
			}
			if (foundTool == null)
			{
				return false;
			}
		}
		if (foundTool == null)
		{
			for (int j = 0; j <= clsDrill.ToolList.Count - 1; j++)
			{
				if (!(!clsDrill.ToolList[j].Data.Used | Settings.IgnoreUsedInfo))
				{
					continue;
				}
				if (Settings.Plane == planeBoxNames.Top && ((clsDrill.ToolList[j].Geometry.ToolDirection.Z == -1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[j].Data.GroupIndex) & (clsDrill.ToolList[j].Data.No >= Settings.StartToolIndex)))
				{
					bool flag = true;
					if (Settings.SelectVerticalTools)
					{
						flag = false;
						if ((clsDrill.ToolList[j].Positions.Location == ToolLocationType.Vertical) | (clsDrill.ToolList[j].Positions.Location == ToolLocationType.HorizontalAndVertical))
						{
							flag = true;
						}
					}
					double num = Item.Center.Y - clsDrill.ToolList[j].Positions.CommonOffset.Y;
					if (BlockIndex == 0)
					{
						num = Item.Center.Y + clsDrill.ToolList[j].Positions.CommonOffset.Y;
					}
					if (BlockIndex == 1)
					{
						num = Item.Center.Y - clsDrill.ToolList[j].Positions.CommonOffset.Y;
					}
					if (num > clsDrill.ToolList[j].Limits.AxesMinLimits.Y && flag)
					{
						foundTool = new ToolBase5(clsDrill.ToolList[j]);
						clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
						j = clsDrill.ToolList.Count;
					}
				}
				if (Settings.Plane == planeBoxNames.Bottom && ((clsDrill.ToolList[j].Geometry.ToolDirection.Z == 1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[j].Data.GroupIndex) & (clsDrill.ToolList[j].Data.No >= Settings.StartToolIndex)))
				{
					double num2 = Item.Center.Y - clsDrill.ToolList[j].Positions.CommonOffset.Y;
					if (num2 > clsDrill.ToolList[j].Limits.AxesMinLimits.Y)
					{
						foundTool = new ToolBase5(clsDrill.ToolList[j]);
						clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
						j = clsDrill.ToolList.Count;
					}
				}
				if (Settings.Plane == planeBoxNames.Front && ((clsDrill.ToolList[j].Geometry.ToolDirection.X == -1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[j].Data.GroupIndex) & (clsDrill.ToolList[j].Data.No >= Settings.StartToolIndex)))
				{
					foundTool = new ToolBase5(clsDrill.ToolList[j]);
					clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
					j = clsDrill.ToolList.Count;
				}
				if (Settings.Plane == planeBoxNames.Back && ((clsDrill.ToolList[j].Geometry.ToolDirection.X == 1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[j].Data.GroupIndex) & (clsDrill.ToolList[j].Data.No >= Settings.StartToolIndex)))
				{
					foundTool = new ToolBase5(clsDrill.ToolList[j]);
					clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
					j = clsDrill.ToolList.Count;
				}
				if (Settings.Plane == planeBoxNames.Left && ((clsDrill.ToolList[j].Geometry.ToolDirection.Y == 1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[j].Data.GroupIndex) & (clsDrill.ToolList[j].Data.No >= Settings.StartToolIndex)))
				{
					foundTool = new ToolBase5(clsDrill.ToolList[j]);
					clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
					j = clsDrill.ToolList.Count;
				}
				if (Settings.Plane == planeBoxNames.Right && ((clsDrill.ToolList[j].Geometry.ToolDirection.Y == -1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && ((BlockIndex == clsDrill.ToolList[j].Data.GroupIndex) & (clsDrill.ToolList[j].Data.No >= Settings.StartToolIndex)))
				{
					foundTool = new ToolBase5(clsDrill.ToolList[j]);
					clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
					j = clsDrill.ToolList.Count;
				}
			}
			if (foundTool == null)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	public bool FindToolFromBlock(DrillCalcItem Item, int BlockIndex, FindToolSettings Settings, SortDirection SortDir, ref ToolBase5 foundTool)
	{
		foundTool = null;
		if (SortDir != SortDirection.LowerToBigger)
		{
			if (Item.Type == DrillItemType.Slot)
			{
				for (int num = clsDrill.ToolList.Count - 1; num >= 0; num--)
				{
					if (!clsDrill.ToolList[num].Data.Used | Settings.IgnoreUsedInfo)
					{
						if (Settings.Plane == planeBoxNames.Top && ((clsDrill.ToolList[num].Geometry.GeometryType == ToolType.Slot) & (clsDrill.ToolList[num].Geometry.Thickness == Item.Width)) && BlockIndex == clsDrill.ToolList[num].Data.GroupIndex)
						{
							double num2 = Item.Center.Y - clsDrill.ToolList[num].Positions.CommonOffset.Y;
							if (BlockIndex == 0)
							{
								num2 = Item.Center.Y + clsDrill.ToolList[num].Positions.CommonOffset.Y;
							}
							if (BlockIndex == 1)
							{
								num2 = Item.Center.Y - clsDrill.ToolList[num].Positions.CommonOffset.Y;
							}
							if (num2 > clsDrill.ToolList[num].Limits.AxesMinLimits.Y)
							{
								foundTool = new ToolBase5(clsDrill.ToolList[num]);
								clsDrill.ToolList[num].Data.Used = Settings.SetAsUsed;
								num = clsDrill.ToolList.Count;
							}
						}
						if (Settings.Plane == planeBoxNames.Bottom && ((clsDrill.ToolList[num].Geometry.ToolDirection.Z == 1.0) & (clsDrill.ToolList[num].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num].Data.GroupIndex)
						{
							double num3 = Item.Center.Y - clsDrill.ToolList[num].Positions.CommonOffset.Y;
							if (num3 > clsDrill.ToolList[num].Limits.AxesMinLimits.Y)
							{
								foundTool = new ToolBase5(clsDrill.ToolList[num]);
								clsDrill.ToolList[num].Data.Used = Settings.SetAsUsed;
								num = clsDrill.ToolList.Count;
							}
						}
						if (Settings.Plane == planeBoxNames.Front && ((clsDrill.ToolList[num].Geometry.ToolDirection.X == -1.0) & (clsDrill.ToolList[num].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num].Data.GroupIndex)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[num]);
							clsDrill.ToolList[num].Data.Used = Settings.SetAsUsed;
							num = clsDrill.ToolList.Count;
						}
						if (Settings.Plane == planeBoxNames.Back && ((clsDrill.ToolList[num].Geometry.ToolDirection.X == 1.0) & (clsDrill.ToolList[num].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num].Data.GroupIndex)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[num]);
							clsDrill.ToolList[num].Data.Used = Settings.SetAsUsed;
							num = clsDrill.ToolList.Count;
						}
						if (Settings.Plane == planeBoxNames.Left && ((clsDrill.ToolList[num].Geometry.ToolDirection.Y == 1.0) & (clsDrill.ToolList[num].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num].Data.GroupIndex)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[num]);
							clsDrill.ToolList[num].Data.Used = Settings.SetAsUsed;
							num = clsDrill.ToolList.Count;
						}
						if (Settings.Plane == planeBoxNames.Right && ((clsDrill.ToolList[num].Geometry.ToolDirection.Y == -1.0) & (clsDrill.ToolList[num].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num].Data.GroupIndex)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[num]);
							clsDrill.ToolList[num].Data.Used = Settings.SetAsUsed;
							num = clsDrill.ToolList.Count;
						}
					}
				}
			}
		}
		else if (Item.Type == DrillItemType.Slot)
		{
			for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
			{
				if (!(!clsDrill.ToolList[i].Data.Used | Settings.IgnoreUsedInfo))
				{
					continue;
				}
				if (Settings.Plane == planeBoxNames.Top && ((clsDrill.ToolList[i].Geometry.GeometryType == ToolType.Slot) & (clsDrill.ToolList[i].Geometry.Thickness == Item.Width)) && BlockIndex == clsDrill.ToolList[i].Data.GroupIndex)
				{
					double num4 = Item.Center.Y - clsDrill.ToolList[i].Positions.CommonOffset.Y;
					if (BlockIndex == 0)
					{
						num4 = Item.Center.Y + clsDrill.ToolList[i].Positions.CommonOffset.Y;
					}
					if (BlockIndex == 1)
					{
						num4 = Item.Center.Y - clsDrill.ToolList[i].Positions.CommonOffset.Y;
					}
					if (num4 > clsDrill.ToolList[i].Limits.AxesMinLimits.Y)
					{
						foundTool = new ToolBase5(clsDrill.ToolList[i]);
						clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
						i = clsDrill.ToolList.Count;
					}
				}
				if (Settings.Plane == planeBoxNames.Bottom && ((clsDrill.ToolList[i].Geometry.ToolDirection.Z == 1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[i].Data.GroupIndex)
				{
					double num5 = Item.Center.Y - clsDrill.ToolList[i].Positions.CommonOffset.Y;
					if (num5 > clsDrill.ToolList[i].Limits.AxesMinLimits.Y)
					{
						foundTool = new ToolBase5(clsDrill.ToolList[i]);
						clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
						i = clsDrill.ToolList.Count;
					}
				}
				if (Settings.Plane == planeBoxNames.Front && ((clsDrill.ToolList[i].Geometry.ToolDirection.X == -1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[i].Data.GroupIndex)
				{
					foundTool = new ToolBase5(clsDrill.ToolList[i]);
					clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
					i = clsDrill.ToolList.Count;
				}
				if (Settings.Plane == planeBoxNames.Back && ((clsDrill.ToolList[i].Geometry.ToolDirection.X == 1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[i].Data.GroupIndex)
				{
					foundTool = new ToolBase5(clsDrill.ToolList[i]);
					clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
					i = clsDrill.ToolList.Count;
				}
				if (Settings.Plane == planeBoxNames.Left && ((clsDrill.ToolList[i].Geometry.ToolDirection.Y == 1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[i].Data.GroupIndex)
				{
					foundTool = new ToolBase5(clsDrill.ToolList[i]);
					clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
					i = clsDrill.ToolList.Count;
				}
				if (Settings.Plane == planeBoxNames.Right && ((clsDrill.ToolList[i].Geometry.ToolDirection.Y == -1.0) & (clsDrill.ToolList[i].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[i].Data.GroupIndex)
				{
					foundTool = new ToolBase5(clsDrill.ToolList[i]);
					clsDrill.ToolList[i].Data.Used = Settings.SetAsUsed;
					i = clsDrill.ToolList.Count;
				}
			}
		}
		if (foundTool == null)
		{
			if (SortDir != SortDirection.LowerToBigger)
			{
				for (int num6 = clsDrill.ToolList.Count - 1; num6 >= 0; num6--)
				{
					if (!clsDrill.ToolList[num6].Data.Used | Settings.IgnoreUsedInfo)
					{
						if (Settings.Plane == planeBoxNames.Top && ((clsDrill.ToolList[num6].Geometry.ToolDirection.Z == -1.0) & (clsDrill.ToolList[num6].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num6].Data.GroupIndex)
						{
							double num7 = Item.Center.Y - clsDrill.ToolList[num6].Positions.CommonOffset.Y;
							if (BlockIndex == 0)
							{
								num7 = Item.Center.Y + clsDrill.ToolList[num6].Positions.CommonOffset.Y;
							}
							if (BlockIndex == 1)
							{
								num7 = Item.Center.Y - clsDrill.ToolList[num6].Positions.CommonOffset.Y;
							}
							if (num7 > clsDrill.ToolList[num6].Limits.AxesMinLimits.Y)
							{
								foundTool = new ToolBase5(clsDrill.ToolList[num6]);
								clsDrill.ToolList[num6].Data.Used = Settings.SetAsUsed;
								num6 = 0;
							}
						}
						if (Settings.Plane == planeBoxNames.Bottom && ((clsDrill.ToolList[num6].Geometry.ToolDirection.Z == 1.0) & (clsDrill.ToolList[num6].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num6].Data.GroupIndex)
						{
							double num8 = Item.Center.Y - clsDrill.ToolList[num6].Positions.CommonOffset.Y;
							if (num8 > clsDrill.ToolList[num6].Limits.AxesMinLimits.Y)
							{
								foundTool = new ToolBase5(clsDrill.ToolList[num6]);
								clsDrill.ToolList[num6].Data.Used = Settings.SetAsUsed;
								num6 = 0;
							}
						}
						if (Settings.Plane == planeBoxNames.Front && ((clsDrill.ToolList[num6].Geometry.ToolDirection.X == -1.0) & (clsDrill.ToolList[num6].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num6].Data.GroupIndex)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[num6]);
							clsDrill.ToolList[num6].Data.Used = Settings.SetAsUsed;
							num6 = 0;
						}
						if (Settings.Plane == planeBoxNames.Back && ((clsDrill.ToolList[num6].Geometry.ToolDirection.X == 1.0) & (clsDrill.ToolList[num6].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num6].Data.GroupIndex)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[num6]);
							clsDrill.ToolList[num6].Data.Used = Settings.SetAsUsed;
							num6 = 0;
						}
						if (Settings.Plane == planeBoxNames.Left && ((clsDrill.ToolList[num6].Geometry.ToolDirection.Y == 1.0) & (clsDrill.ToolList[num6].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num6].Data.GroupIndex)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[num6]);
							clsDrill.ToolList[num6].Data.Used = Settings.SetAsUsed;
							num6 = 0;
						}
						if (Settings.Plane == planeBoxNames.Right && ((clsDrill.ToolList[num6].Geometry.ToolDirection.Y == -1.0) & (clsDrill.ToolList[num6].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[num6].Data.GroupIndex)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[num6]);
							clsDrill.ToolList[num6].Data.Used = Settings.SetAsUsed;
							num6 = 0;
						}
					}
				}
			}
			else
			{
				for (int j = 0; j <= clsDrill.ToolList.Count - 1; j++)
				{
					if (!(!clsDrill.ToolList[j].Data.Used | Settings.IgnoreUsedInfo))
					{
						continue;
					}
					if (Settings.Plane == planeBoxNames.Top && ((clsDrill.ToolList[j].Geometry.ToolDirection.Z == -1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[j].Data.GroupIndex)
					{
						double num9 = Item.Center.Y - clsDrill.ToolList[j].Positions.CommonOffset.Y;
						if (BlockIndex == 0)
						{
							num9 = Item.Center.Y + clsDrill.ToolList[j].Positions.CommonOffset.Y;
						}
						if (BlockIndex == 1)
						{
							num9 = Item.Center.Y - clsDrill.ToolList[j].Positions.CommonOffset.Y;
						}
						if (num9 > clsDrill.ToolList[j].Limits.AxesMinLimits.Y)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[j]);
							clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
							j = clsDrill.ToolList.Count;
						}
					}
					if (Settings.Plane == planeBoxNames.Bottom && ((clsDrill.ToolList[j].Geometry.ToolDirection.Z == 1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[j].Data.GroupIndex)
					{
						double num10 = Item.Center.Y - clsDrill.ToolList[j].Positions.CommonOffset.Y;
						if (num10 > clsDrill.ToolList[j].Limits.AxesMinLimits.Y)
						{
							foundTool = new ToolBase5(clsDrill.ToolList[j]);
							clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
							j = clsDrill.ToolList.Count;
						}
					}
					if (Settings.Plane == planeBoxNames.Front && ((clsDrill.ToolList[j].Geometry.ToolDirection.X == -1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[j].Data.GroupIndex)
					{
						foundTool = new ToolBase5(clsDrill.ToolList[j]);
						clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
						j = clsDrill.ToolList.Count;
					}
					if (Settings.Plane == planeBoxNames.Back && ((clsDrill.ToolList[j].Geometry.ToolDirection.X == 1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[j].Data.GroupIndex)
					{
						foundTool = new ToolBase5(clsDrill.ToolList[j]);
						clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
						j = clsDrill.ToolList.Count;
					}
					if (Settings.Plane == planeBoxNames.Left && ((clsDrill.ToolList[j].Geometry.ToolDirection.Y == 1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[j].Data.GroupIndex)
					{
						foundTool = new ToolBase5(clsDrill.ToolList[j]);
						clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
						j = clsDrill.ToolList.Count;
					}
					if (Settings.Plane == planeBoxNames.Right && ((clsDrill.ToolList[j].Geometry.ToolDirection.Y == -1.0) & (clsDrill.ToolList[j].Geometry.Diameter == Item.Diameter)) && BlockIndex == clsDrill.ToolList[j].Data.GroupIndex)
					{
						foundTool = new ToolBase5(clsDrill.ToolList[j]);
						clsDrill.ToolList[j].Data.Used = Settings.SetAsUsed;
						j = clsDrill.ToolList.Count;
					}
				}
			}
			if (foundTool == null)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	public bool GetXYToolOffsetFromNo(int ToolNo, ref double XOffset, ref double YOffset)
	{
		XOffset = 0.0;
		YOffset = 0.0;
		bool result = false;
		for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
		{
			if (clsDrill.ToolList[i].Data.No == ToolNo)
			{
				XOffset = clsDrill.ToolList[i].Positions.CommonOffset.X;
				YOffset = clsDrill.ToolList[i].Positions.CommonOffset.Y;
				result = true;
			}
		}
		return result;
	}

	public bool GetXToolOffsetFromNo(int ToolNo, ref double XOffset)
	{
		double YOffset = 0.0;
		XOffset = 0.0;
		return GetXYToolOffsetFromNo(ToolNo, ref XOffset, ref YOffset);
	}

	public int SetValueToAvailableTool(int ToolValue, ref int T1, ref int T2, ref int T3, ref int T4, ref int T5, ref int T6, ref int T7, ref int T8, ref int T9, ref int T10, ref int T11, ref int T12)
	{
		if (ToolValue > 0)
		{
			if (T1 <= 0)
			{
				T1 = ToolValue;
				return 1;
			}
			if (T2 <= 0)
			{
				T2 = ToolValue;
				return 2;
			}
			if (T3 <= 0)
			{
				T3 = ToolValue;
				return 3;
			}
			if (T4 <= 0)
			{
				T4 = ToolValue;
				return 4;
			}
			if (T5 <= 0)
			{
				T5 = ToolValue;
				return 5;
			}
			if (T6 <= 0)
			{
				T6 = ToolValue;
				return 6;
			}
			if (T7 <= 0)
			{
				T7 = ToolValue;
				return 7;
			}
			if (T8 <= 0)
			{
				T8 = ToolValue;
				return 8;
			}
			if (T9 <= 0)
			{
				T9 = ToolValue;
				return 9;
			}
			if (T10 <= 0)
			{
				T10 = ToolValue;
				return 10;
			}
			if (T11 <= 0)
			{
				T11 = ToolValue;
				return 11;
			}
			if (T12 <= 0)
			{
				T12 = ToolValue;
				return 12;
			}
		}
		return 0;
	}

	public int SetValueToAvailableTool(int ToolValue, ref int T1, ref int T2, ref int T3, ref int T4, ref int T5, ref int T6, ref int T7, ref int T8, ref int T9, ref int T10, ref int T11, ref int T12, ref List<int> Y1GroupTool, ref List<int> Y2GroupTool)
	{
		if (ToolValue > 0)
		{
			if (T1 <= 0)
			{
				T1 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 1;
			}
			if (T2 <= 0)
			{
				T2 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 2;
			}
			if (T3 <= 0)
			{
				T3 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 3;
			}
			if (T4 <= 0)
			{
				T4 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 4;
			}
			if (T5 <= 0)
			{
				T5 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 5;
			}
			if (T6 <= 0)
			{
				T6 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 6;
			}
			if (T7 <= 0)
			{
				T7 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 7;
			}
			if (T8 <= 0)
			{
				T8 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 8;
			}
			if (T9 <= 0)
			{
				T9 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 9;
			}
			if (T10 <= 0)
			{
				T10 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 10;
			}
			if (T11 <= 0)
			{
				T11 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 11;
			}
			if (T12 <= 0)
			{
				T12 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
				}
				if (ToolValue >= 161 && ToolValue <= 179)
				{
					Y2GroupTool.Add(ToolValue);
				}
				return 12;
			}
		}
		return 0;
	}

	public int SetValueToAvailableTool(int ToolValue, ref DrillMoveOptions Option)
	{
		if (ToolValue > 0)
		{
			if (Option.Tool1 <= 0)
			{
				Option.Tool1 = ToolValue;
				return 1;
			}
			if (Option.Tool2 <= 0)
			{
				Option.Tool2 = ToolValue;
				return 2;
			}
			if (Option.Tool3 <= 0)
			{
				Option.Tool3 = ToolValue;
				return 3;
			}
			if (Option.Tool4 <= 0)
			{
				Option.Tool4 = ToolValue;
				return 4;
			}
			if (Option.Tool5 <= 0)
			{
				Option.Tool5 = ToolValue;
				return 5;
			}
			if (Option.Tool6 <= 0)
			{
				Option.Tool6 = ToolValue;
				return 6;
			}
			if (Option.Tool7 <= 0)
			{
				Option.Tool7 = ToolValue;
				return 7;
			}
			if (Option.Tool8 <= 0)
			{
				Option.Tool8 = ToolValue;
				return 8;
			}
			if (Option.Tool9 <= 0)
			{
				Option.Tool9 = ToolValue;
				return 9;
			}
			if (Option.Tool10 <= 0)
			{
				Option.Tool10 = ToolValue;
				return 10;
			}
			if (Option.Tool11 <= 0)
			{
				Option.Tool11 = ToolValue;
				return 11;
			}
			if (Option.Tool12 <= 0)
			{
				Option.Tool12 = ToolValue;
				return 12;
			}
		}
		return 0;
	}

	public bool FindFirstClamperPositions(DrillJob Job, ref double MaterialZeroYPos, ref double X1, ref double X2)
	{
		MaterialZeroYPos = Job.Material.Size.Height / 2.0;
		if (MaterialZeroYPos < clsDrill.varDrillCNCSettings.MaterialZeroYMinPosition)
		{
			MaterialZeroYPos = clsDrill.varDrillCNCSettings.MaterialZeroYMinPosition;
		}
		if (MaterialZeroYPos > clsDrill.varDrillCNCSettings.MaterialZeroYMaxPosition)
		{
			MaterialZeroYPos = clsDrill.varDrillCNCSettings.MaterialZeroYMaxPosition;
		}
		X2 = 0.0 - clsDrill.varDrillCNCSettings.ClamperFirstPositionOffset - clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
		X1 = 0.0 - Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperFirstPositionOffset + clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
		if (clsDrill.activeJob.FirstClamperX != clsDrill.activeJob.SecondClamperX)
		{
			X2 = clsDrill.activeJob.SecondClamperX;
			X1 = clsDrill.activeJob.FirstClamperX;
		}
		if (X2 - X1 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
		{
			double num = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - (X2 - X1);
			if (num > 0.0)
			{
				X2 += num / 2.0;
				X1 -= num / 2.0;
			}
		}
		if (!(Job.Material.Size.Width > clsDrill.varDrillCNCSettings.MaterialFeedMaxDistance))
		{
		}
		if (X1 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
		{
			X1 = clsDrill.varDrillMachineSettings.MachineMinXStroke;
		}
		return true;
	}

	public bool isSingleClamperAvailable(DrillJob Job, ref double X1Pos, ref double X2Pos)
	{
		List<double> list = new List<double>();
		List<double> list2 = new List<double>();
		for (int i = 0; i <= Job.ItemCalc.Count - 1; i++)
		{
			if (!((Job.ItemCalc[i].planeName == planeBoxNames.Front) | (Job.ItemCalc[i].planeName == planeBoxNames.Back)))
			{
				if (!(Math.Abs(Job.ItemCalc[i].Center.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth))
				{
					list2.Add(Job.ItemCalc[i].Center.X);
				}
				else
				{
					list.Add(Job.ItemCalc[i].Center.X);
				}
			}
			else if (!(Math.Abs(Job.ItemCalc[i].Center.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0))
			{
				list2.Add(Job.ItemCalc[i].Center.X);
			}
			else
			{
				list.Add(Job.ItemCalc[i].Center.X);
			}
		}
		if (list.Count >= 2)
		{
			for (int j = 1; j <= list.Count - 1; j++)
			{
				double num = list[j] - list[j - 1];
				if (num > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					X2Pos = 0.0 - Math.Abs(list[j - 1] + (list[j] - list[j - 1]) / 2.0);
					X1Pos = 0.0 - (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
					return true;
				}
			}
		}
		if (list.Count != 1 || !(Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperLength) || list[0] != 0.0)
		{
			if (list2.Count <= 0)
			{
				return false;
			}
			X2Pos = (0.0 - Job.Material.Size.Width) / 2.0;
			X1Pos = 0.0 - (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
			return true;
		}
		X2Pos = (0.0 - clsDrill.varDrillCNCSettings.ClamperLength) / 2.0;
		X1Pos = 0.0 - (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
		return true;
	}

	public bool MillingContourClamperPositions(DrillJob Job, bool isTop, ref double X1, ref double X2)
	{
		double num = clsDrill.varDrillCNCSettings.ContourLimitLenForTopSpindleOneMove;
		if (!isTop)
		{
			num = clsDrill.varDrillCNCSettings.ContourLimitLenForBottomSpindleOneMove;
		}
		if (!((isTop & (clsDrill.varDrillCNCSettings.ContourTopDirection == ClockDirectionType.CW)) | (!isTop & (clsDrill.varDrillCNCSettings.ContourBottomDirection == ClockDirectionType.CW))))
		{
			if (!((isTop & (clsDrill.varDrillCNCSettings.ContourTopDirection == ClockDirectionType.CCW)) | (!isTop & (clsDrill.varDrillCNCSettings.ContourBottomDirection == ClockDirectionType.CCW))))
			{
				return false;
			}
			if (!(Job.Material.Size.Width >= num))
			{
				if (!((Job.Material.Size.Width >= 700.0) & (Job.Material.Size.Width < num)))
				{
					if (!((Job.Material.Size.Width >= 500.0) & (Job.Material.Size.Width < 700.0)))
					{
						if (isTop)
						{
							X2 = clsDrill.varDrillCNCSettings.ClamperLength * 0.2;
							X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength);
						}
						return true;
					}
					if (isTop)
					{
						X2 = clsDrill.varDrillCNCSettings.ClamperLength * 0.1;
						X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength + 100.0);
					}
					else
					{
						X2 = 70.0;
						X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
					}
					return true;
				}
				if (isTop)
				{
					X2 = 0.0;
					X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 200.0);
				}
				else
				{
					X2 = 0.0;
					X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
				}
				return true;
			}
			if (isTop)
			{
				X2 = 0.0 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.5);
				X1 = 0.0 - Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.7;
			}
			else
			{
				X2 = 0.0 - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperLength * 1.2;
				X1 = 0.0 - Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 1.2;
			}
			if (X2 - X1 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
			{
				X1 = X2 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
			}
			if (X1 < clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength)
			{
				X1 = clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength;
				if (X2 - X1 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					X2 = X1 + (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
				}
			}
			return true;
		}
		if (!(Job.Material.Size.Width >= num))
		{
			if (!((Job.Material.Size.Width >= 700.0) & (Job.Material.Size.Width < num)))
			{
				if (!((Job.Material.Size.Width >= 500.0) & (Job.Material.Size.Width < 700.0)))
				{
					X2 = 0.0 - Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.3 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength;
					X1 = 0.0 - Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.3;
					return true;
				}
				X2 = 0.0 - Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.1 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength;
				X1 = 0.0 - Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.1;
				return true;
			}
			X2 = 0.0 - Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.0 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength;
			X1 = 0.0 - Job.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 0.0;
			if (X1 < clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength)
			{
				X1 = clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength;
			}
			return true;
		}
		if (isTop)
		{
			X2 = 0.0 - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperLength * 0.7;
			X1 = 0.0 - Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.7;
		}
		else
		{
			X2 = 0.0 - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperLength * 0.7;
			X1 = 0.0 - Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.7;
		}
		if (X1 < clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength)
		{
			X1 = clsDrill.varDrillMachineSettings.MachineMinXStroke + 2.0 * clsDrill.varDrillCNCSettings.ClamperLength;
		}
		return true;
	}

	public bool isDrillInsideClamper(double XPosition, List<ToolBase5> activeTools, ref double ClamperMinXToToolX, ref double ClamperMaxXToToolX, double ExtraOffset = 0.0)
	{
		bool result = false;
		double num = XPosition - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
		double num2 = XPosition + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset;
		List<double> RefList = new List<double>();
		for (int i = 0; i <= activeTools.Count - 1; i++)
		{
			double num3 = activeTools[i].Positions.CommonOffset.X + clsDrill.varDrillCNCSettings.ReclineDiameter / 2.0;
			if (((num <= activeTools[i].Positions.CommonOffset.X) & (activeTools[i].Positions.CommonOffset.X <= num2)) && num3 >= num && num3 <= num2)
			{
				result = true;
			}
			RefList.Add(num3);
		}
		clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList);
		if (RefList.Count > 0)
		{
			ClamperMinXToToolX = RefList[RefList.Count - 1] - num;
			ClamperMaxXToToolX = num2 - RefList[0];
		}
		return result;
	}

	public bool isItemInsideClamper(DrillItem Item, double dX, ToolBase5 ToolMilling, ref double ClamperMinXToToolX, ref double ClamperMaxXToToolX, double ExtraOffset = 0.0)
	{
		bool result = false;
		ClamperMaxXToToolX = 0.0;
		ClamperMinXToToolX = 0.0;
		double num = Item.BoxMinItem.X + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
		double num2 = Item.BoxMinItem.X + dX + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		List<double> RefList = new List<double>();
		if ((num <= ToolMilling.Positions.CommonOffset.X) & (ToolMilling.Positions.CommonOffset.X <= num2))
		{
			double num5 = ToolMilling.Positions.CommonOffset.X + clsDrill.varDrillCNCSettings.ReclineDiameter / 2.0;
			num3 = num;
			num4 = num2;
			if (num5 >= num && num5 <= num2)
			{
				result = true;
			}
			RefList.Add(num5);
		}
		num = Item.BoxMaxItem.X + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
		num2 = Item.BoxMaxItem.X + dX + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset;
		if ((num <= ToolMilling.Positions.CommonOffset.X) & (ToolMilling.Positions.CommonOffset.X <= num2))
		{
			double num6 = ToolMilling.Positions.CommonOffset.X + clsDrill.varDrillCNCSettings.ReclineDiameter / 2.0;
			if (num < num3)
			{
				num3 = num;
			}
			if (num2 > num4)
			{
				num4 = num2;
			}
			if (num6 >= num && num6 <= num2)
			{
				result = true;
			}
			RefList.Add(num6);
		}
		clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList);
		if (RefList.Count > 0)
		{
			ClamperMinXToToolX = RefList[RefList.Count - 1] - num3;
			ClamperMaxXToToolX = num4 - RefList[0];
		}
		return result;
	}

	public void MoveClampers(double newX1, double newX2, drillPlaneNames Plane, ref DrillJob Job)
	{
		if (Job.Moves.Count > 0)
		{
			if (buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X2Clamper, newX2, 0.1))
			{
				newX2 = NoMove;
			}
			if (buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X1Clamper, newX1, 0.1))
			{
				newX1 = NoMove;
			}
		}
		if (!((newX1 != NoMove) | (newX2 != NoMove)))
		{
			return;
		}
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.XAxesGantyOff, Plane, NoMove, ref Job);
		if (newX1 == NoMove)
		{
			if (newX2 != NoMove)
			{
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, Plane, NoMove, ref Job);
				AddDrillMove(NoMove, newX2, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, Plane, NoMove, ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, Plane, NoMove, ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.XAxesGantyOn, Plane, NoMove, ref Job);
			}
		}
		else
		{
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, Plane, NoMove, ref Job);
			AddDrillMove(newX1, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, Plane, NoMove, ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, Plane, NoMove, ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.XAxesGantyOn, Plane, NoMove, ref Job);
		}
	}
}
