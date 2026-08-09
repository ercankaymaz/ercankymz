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

public class clsDrillGoAtc : clsDrill
{
	public double LastZ = 0.0;

	public drillPlaneNames LastPlane = drillPlaneNames.Top;

	private List<string> list_2 = new List<string>();

	private List<string> list_3 = new List<string>();

	public void cmdCreateCode(string strGCodes, string FileName = "")
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
		saveFileDialog.Filter = ccVars.PostActive.FileExplanation + " (" + ccVars.PostActive.FileExtension + ")|" + ccVars.PostActive.FileExtension;
		saveFileDialog.FilterIndex = 1;
		if (FileName.Length != 0)
		{
			buFile5.SaveToFile(strGCodes, FileName);
			if (clsItem.FrmProgress != null)
			{
				clsItem.FrmProgress.Visible = false;
			}
		}
		else if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
			buFile5.SaveToFile(strGCodes, saveFileDialog.FileName);
			if (clsItem.FrmProgress != null)
			{
				clsItem.FrmProgress.Visible = false;
			}
			strGCodes = "";
			clsFiles.SaveParameter();
		}
	}

	public bool cmdShowTools()
	{
		if (FrmTools == null)
		{
			FrmTools = new F_Tools();
		}
		FrmTools.fileNameLeftTools = AppPath.MachineSimConfig;
		FrmTools.fileNameRightTools = AppPath.MachineSimConfig + "\\Tools\\GoToolGroups.step";
		FrmTools.fileNameBottomTools = AppPath.MachineSimConfig;
		CreateModelProperties createModelProperties = new CreateModelProperties();
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
		FrmTools.StartPosition = FormStartPosition.CenterParent;
		FrmTools.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		FrmTools.settingRuntime = new DrillRuntimeSettings(clsDrill.varDrillRunSettings);
		FrmTools.UseCommponOffsetToolDrawing = true;
		FrmTools.isGo = true;
		if (FrmTools.tabControl1.TabPages.Count >= 3)
		{
			FrmTools.tabControl1.TabPages.RemoveAt(2);
		}
		if (FrmTools.tabControl1.TabPages.Count >= 2)
		{
			FrmTools.tabControl1.TabPages.RemoveAt(1);
		}
		FrmTools.ShowPlungeSpeed = true;
		FrmTools.ShowWaitTime = true;
		FrmTools.Init();
		FrmTools.ShowDialog();
		if (FrmTools.PropertiesForm.Result != DialogResult.OK)
		{
			return false;
		}
		for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
		{
			if (clsInit.appDrill.MachType == DrillMachineType.GoWithNoAtc && clsDrill.ToolList[i].Data.No == 31)
			{
				clsDrill.toolTop = new ToolBase5(clsDrill.ToolList[i]);
			}
			if (clsDrill.ToolList[i].Data.No == 95)
			{
				clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[i]);
				clsDrill.toolSlotY1.Geometry.Thickness = clsDrill.toolSlotY1.Geometry.CutLength;
				clsDrill.ToolList[i].Geometry.Thickness = clsDrill.toolSlotY1.Geometry.CutLength;
			}
		}
		clsDrill.varDrillRunSettings = new DrillRuntimeSettings(FrmTools.settingRuntime);
		return true;
	}

	public void cmdCreateCodes(ref List<string> SL, DrillJob Job)
	{
		SL.Clear();
		if (Job.Moves.Count == 0)
		{
			return;
		}
		double num = Job.Moves[0].X1Clamper;
		double num2 = Job.Moves[0].X2Clamper;
		int num3 = 0;
		bool flag = false;
		for (int i = 0; i <= Job.Moves.Count - 1; i++)
		{
			if (Job.Moves[i].Command == DrillMoveCommand.Wait)
			{
				num = Math.Abs(Job.Moves[i].X1Clamper);
				num2 = Math.Abs(Job.Moves[i].X2Clamper);
			}
			if (Job.Moves[i].CodeLines != null && Job.Moves[i].CodeLines.Count > 0 && num3 == 0)
			{
				num3 = i;
			}
			if (Job.Moves[i].Command == DrillMoveCommand.SetPiston)
			{
				if ((Job.Moves[i].Tool1 >= 61) & (Job.Moves[i].Tool1 <= 71))
				{
					flag = true;
				}
				if (Job.Moves[i].Tool1 == 95)
				{
					flag = true;
				}
			}
		}
		SL.Add(string.Format("(R1802 = {0}", Job.Material.Size.Depth.ToString("f1")) + ") { Thickness");
		SL.Add(string.Format("(R1801 = {0}", Job.Material.Size.Height.ToString("f1")) + ") { Panel_Y WIDTH");
		SL.Add(string.Format("(R1800 = {0}", Job.Material.Size.Width.ToString("f1")) + ") { Panel_X LENGTH");
		SL.Add(string.Format("(R4100 = {0}", num2.ToString("f1")) + ")");
		SL.Add(string.Format("(R4110 = {0}", num.ToString("f1")) + ")");
		SL.Add("{" + $"PNAME = {Job.Name}");
		SL.Add("M1090 { Below Up");
		SL.Add("L ONGIRIS");
		SL.Add("M85 { MultiHole Tools Up");
		if (flag)
		{
			SL.Add("M87");
		}
		SL.Add("$M40 { Spindle Up");
		new List<string>();
		for (int j = num3; j <= Job.Moves.Count - 1; j++)
		{
			DrillMove drillMove = Job.Moves[j];
			if (drillMove.Command != DrillMoveCommand.AxisMove)
			{
				if (drillMove.Command != DrillMoveCommand.GCode)
				{
					if (drillMove.Command != DrillMoveCommand.GCodeList)
					{
						if (drillMove.Mode == DrillCNCMode.ToolOffset)
						{
							SL.Add("M6T" + drillMove.Tool1);
							SL.Add("M16");
						}
						if (drillMove.Mode == DrillCNCMode.ToolReset && SL[SL.Count - 1].IndexOf("M85") == -1)
						{
							SL.Add("M85 { MultiHole Tools Up");
						}
						if (drillMove.Mode == DrillCNCMode.PressPistonReset && SL[SL.Count - 1].IndexOf("144") == -1)
						{
							SL.Add("M144 { Press Piston Reset");
						}
						if (drillMove.Mode != DrillCNCMode.ToolSet)
						{
						}
						if (drillMove.CodeLines != null)
						{
							for (int k = 0; k <= drillMove.CodeLines.Count - 1; k++)
							{
								SL.Add(drillMove.CodeLines[k]);
							}
						}
					}
					else if (drillMove.CodeLines != null)
					{
						for (int l = 0; l <= drillMove.CodeLines.Count - 1; l++)
						{
							SL.Add(drillMove.CodeLines[l]);
						}
					}
				}
				else if (drillMove.CodeLines != null)
				{
					for (int m = 0; m <= drillMove.CodeLines.Count - 1; m++)
					{
						SL.Add(drillMove.CodeLines[m]);
					}
				}
				continue;
			}
			if (drillMove.CodeLines != null)
			{
				for (int n = 0; n <= drillMove.CodeLines.Count - 1; n++)
				{
					SL.Add(drillMove.CodeLines[n]);
				}
			}
			if (!(drillMove.pntCenter != null))
			{
				continue;
			}
			string text = "";
			if (!drillMove.isG0)
			{
				text = "G1";
				_ = " F" + drillMove.Feed;
			}
			else
			{
				text = "G0";
			}
			if (drillMove.EnableAxes != null)
			{
				if (drillMove.EnableAxes.X)
				{
					text = text + " X" + drillMove.pntCenter.X.ToString("f3");
				}
				if (drillMove.EnableAxes.Y)
				{
					text = text + " Y" + drillMove.pntCenter.Y.ToString("f3");
				}
				if (drillMove.EnableAxes.Z)
				{
					text = text + " Z" + drillMove.pntCenter.Z.ToString("f3");
				}
			}
		}
		SL.Add("M85 { MultiHole Tools Up");
		SL.Add("M88 { MultiHole Stop");
		SL.Add("M1090 { Below Up");
		SL.Add("$M40 { Spindle Up");
		SL.Add("M5 { Spindle Stop");
		SL.Add("L GFINPRO.ISC");
		SL.Add("$M02 { Program End");
		if (SL.Count > 0)
		{
		}
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
				if (((buShapeCut2.CutType == CutTypes.CutHorizontal) | (buShapeCut2.CutType == CutTypes.CutHorizontalLine)) && buShapeCut2.BasePoint.X + buShapeCut2.Length > clsDrill.activeJob.Material.Size.Width + 100.0)
				{
					Messages.Add(buDrillCalc.LangDrillMessage[44]);
				}
				if (Shape.BasePoint.Y < -40.0)
				{
					Messages.Add(buDrillCalc.LangDrillMessage[45]);
				}
				if (Shape.BasePoint.Y > clsDrill.activeJob.Material.Size.Height + 50.0)
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
					if (buShapeCut2.isMilling & (buShapeCut2.Diameter != buShapeCut2.Tool.Geometry.Diameter))
					{
						Messages.Add(buDrillCalc.LangDrillMessage[54] + " " + buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Diameter + " : " + buShapeCut2.Tool.Geometry.Diameter.ToString("f1"));
					}
					if (!buShapeCut2.isMilling & (buShapeCut2.Diameter != clsDrill.toolSlotY1.Geometry.Thickness))
					{
						Messages.Add(buDrillCalc.LangDrillMessage[55]);
					}
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
		double num = 0.0;
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
		Job.isError = false;
		Job.isLesSafe = false;
		Job.isSorted = false;
		for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
		{
			if (clsDrill.ToolList[i].Data.No == 95)
			{
				clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[i]);
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
							DrillItem drillItem = new DrillItem((buShapeHole)Job.Items[j]);
							if (Job.Items[j].Tool != null)
							{
								drillItem.ToolMilling = new ToolBase5(Job.Items[j].Tool);
							}
							list6.Add(drillItem);
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
				if (!((buShapeCut2.CutType == CutTypes.CutHorizontal) | (buShapeCut2.CutType == CutTypes.CutHorizontalLine)))
				{
					if (Job.Items[j].Tool != null)
					{
						if (!((buShapeCut2.CutType == CutTypes.CutVertical) | (buShapeCut2.CutType == CutTypes.CutVerticalLine) | (buShapeCut2.CutType == CutTypes.CutFree)))
						{
							DrillItem drillItem2 = new DrillItem((buShapeCut)Job.Items[j]);
							if (!((0.0 - buShapeCut2.CalculatedPoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0) | (0.0 - buShapeCut2.ItemSize.MaxBox.Y <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0)))
							{
								if (!(((buShapeCut)Job.Items[j]).Length >= 2400.0))
								{
									if (!((((buShapeCut)Job.Items[j]).Length > 2000.0) & (((buShapeCut)Job.Items[j]).Length < 2400.0)))
									{
										DrillItem drillItem3 = new DrillItem((buShapeCut)Job.Items[j]);
										if (Job.Items[j].Tool != null)
										{
											drillItem3.ToolMilling = new ToolBase5(Job.Items[j].Tool);
										}
										if (num != 0.0)
										{
											drillItem3.X1First = false;
											drillItem3.X1Move = 0.0 - num;
											drillItem3.X2Move = 0.0 - num;
										}
										list7.Add(drillItem3);
									}
									else
									{
										buShapeCut buShapeCut3 = Job.Items[j] as buShapeCut;
										buShapeCut buShapeCut4 = new buShapeCut((buShapeCut)Job.Items[j]);
										buShapeCut4.Length = buShapeCut3.Length / 2.0;
										buShapeCut buShapeCut5 = new buShapeCut((buShapeCut)Job.Items[j]);
										buShapeCut5.Length = buShapeCut3.Length / 2.0;
										buShapeCut5.CalculatedPoint.X = buShapeCut5.CalculatedPoint.X - buShapeCut5.Length;
										DrillItem drillItem4 = new DrillItem(buShapeCut5);
										if (Job.Items[j].Tool != null)
										{
											drillItem4.ToolMilling = new ToolBase5(Job.Items[j].Tool);
										}
										drillItem4.X1First = true;
										drillItem4.X1Move = 0.0 - buShapeCut5.Length;
										drillItem4.X2Move = 0.0 - buShapeCut5.Length;
										list7.Add(drillItem4);
										drillItem4 = new DrillItem(buShapeCut4);
										if (Job.Items[j].Tool != null)
										{
											drillItem4.ToolMilling = new ToolBase5(Job.Items[j].Tool);
										}
										if (num != 0.0)
										{
											drillItem4.X1First = false;
											drillItem4.X1Move = 0.0 - num;
											drillItem4.X2Move = 0.0 - num;
										}
										list7.Add(drillItem4);
										num = 0.0 - buShapeCut5.Length;
									}
								}
								else
								{
									buShapeCut buShapeCut6 = Job.Items[j] as buShapeCut;
									buShapeCut buShapeCut7 = new buShapeCut((buShapeCut)Job.Items[j]);
									buShapeCut7.Length = buShapeCut6.Length / 2.0;
									buShapeCut buShapeCut8 = new buShapeCut((buShapeCut)Job.Items[j]);
									buShapeCut8.Length = buShapeCut6.Length / 2.0;
									buShapeCut8.CalculatedPoint.X = buShapeCut8.CalculatedPoint.X - buShapeCut8.Length;
									DrillItem drillItem5 = new DrillItem(buShapeCut8);
									if (Job.Items[j].Tool != null)
									{
										drillItem5.ToolMilling = new ToolBase5(Job.Items[j].Tool);
									}
									list7.Add(drillItem5);
									drillItem5 = new DrillItem(buShapeCut7);
									if (num == 0.0)
									{
									}
									if (Job.Items[j].Tool != null)
									{
										drillItem5.ToolMilling = new ToolBase5(Job.Items[j].Tool);
									}
									list7.Add(drillItem5);
									num = 0.0 - buShapeCut8.Length;
								}
							}
							else if (!(buShapeCut2.Length < Job.Material.Size.Width * 0.25))
							{
								List<Point3D> list10 = new List<Point3D>();
								List<Point3D> PointsDevided = new List<Point3D>();
								list10.Add(buVector5.ToPoint3D(drillItem2.camEntities[0][0].StartPoint));
								list10.Add(buVector5.ToPoint3D(drillItem2.camEntities[0][0].EndPoint));
								double num2 = 8.0;
								if (clsDrill.activeJob.Material.Size.Width > 1000.0)
								{
									num2 = 8.0;
								}
								if (clsDrill.activeJob.Material.Size.Width > 2000.0)
								{
									num2 = 12.0;
								}
								clsInit.cVector5.DevidePointsByLength(list10, buShapeCut2.Length / num2, ref PointsDevided);
								if (PointsDevided.Count > 0)
								{
									drillItem2.camEntities[0].Clear();
									for (int m = 1; m <= PointsDevided.Count - 1; m++)
									{
										DrillItem drillItem6 = new DrillItem(drillItem2);
										drillItem6.camEntities = new List<List<buEntity>>();
										List<buEntity> list11 = new List<buEntity>();
										buLine item = new buLine(PointsDevided[m - 1], PointsDevided[m]);
										list11.Add(item);
										clsInit.cVector5.BoxSizeCalculate(list11, ref drillItem6.BoxMinOfDrawing, ref drillItem6.BoxMaxOfDrawing);
										if ((buShapeCut2.CutType == CutTypes.CutHorizontal) | (buShapeCut2.CutType == CutTypes.CutHorizontalLine))
										{
											drillItem6.BoxMinOfDrawing.Y = buShapeCut2.ItemSize.MinBox.Y;
											drillItem6.BoxMaxOfDrawing.Y = buShapeCut2.ItemSize.MaxBox.Y;
										}
										if ((buShapeCut2.CutType == CutTypes.CutVertical) | (buShapeCut2.CutType == CutTypes.CutVerticalLine))
										{
											drillItem6.BoxMinOfDrawing.X = buShapeCut2.ItemSize.MinBox.X;
											drillItem6.BoxMaxOfDrawing.X = buShapeCut2.ItemSize.MaxBox.X;
										}
										drillItem6.BoxMinItem = new Point3D(0.0 - drillItem6.BoxMaxOfDrawing.X, 0.0 - drillItem6.BoxMaxOfDrawing.Y, drillItem6.BoxMinOfDrawing.Z);
										drillItem6.BoxMaxItem = new Point3D(0.0 - drillItem6.BoxMinOfDrawing.X, 0.0 - drillItem6.BoxMinOfDrawing.Y, drillItem6.BoxMaxOfDrawing.Z);
										drillItem6.camEntities.Add(list11);
										list7.Add(drillItem6);
									}
								}
							}
							else
							{
								list7.Add(new DrillItem((buShapeCut)Job.Items[j]));
							}
						}
						else if (!(((buShapeCut)Job.Items[j]).Length > 2500.0))
						{
							list7.Add(new DrillItem((buShapeCut)Job.Items[j]));
						}
						else
						{
							buShapeCut buShapeCut9 = Job.Items[j] as buShapeCut;
							buShapeCut buShapeCut10 = new buShapeCut((buShapeCut)Job.Items[j]);
							buShapeCut10.Length = buShapeCut9.Length / 2.0;
							new buShapeCut((buShapeCut)Job.Items[j]);
							list7.Add(new DrillItem(buShapeCut10));
						}
					}
				}
				else
				{
					DrillCalcItem drillCalcItem = new DrillCalcItem(buShapeCut2);
					if (!drillCalcItem.UseMilling)
					{
						drillCalcItem.Tool = 95;
					}
					Job.ItemCalc.Add(drillCalcItem);
				}
			}
			if ((Job.Items[j].ShapeGroup == ShapeGroup.Shape) & Job.Items[j].Enable)
			{
				DrillItem drillItem7 = new DrillItem(Job.Items[j]);
				if (Job.Items[j].Tool != null)
				{
					drillItem7.ToolMilling = new ToolBase5(Job.Items[j].Tool);
					list5.Add(drillItem7);
				}
			}
			if ((Job.Items[j].ShapeGroup == ShapeGroup.Profiling) & Job.Items[j].Enable)
			{
				DrillItem drillItem8 = new DrillItem((buShapeProfiling)Job.Items[j]);
				if (Job.Items[j].Tool != null)
				{
					drillItem8.ToolMilling = new ToolBase5(Job.Items[j].Tool);
				}
				list5.Add(drillItem8);
			}
			if ((Job.Items[j] is buShapeJunction) & Job.Items[j].Enable)
			{
				buShapeJunction buShapeJunction2 = Job.Items[j] as buShapeJunction;
				if (buShapeJunction2.Enable)
				{
					for (int n = 0; n <= buShapeJunction2.multiCenter.Count - 1; n++)
					{
						buShapeHole buShapeHole9 = new buShapeHole(buShapeJunction2.multiCenter[n].Diameter, buShapeJunction2.Depth);
						buShapeHole9.CalculatedPoint = new Point3D(buShapeJunction2.multiCenter[n].Center.X, buShapeJunction2.multiCenter[n].Center.Y, buShapeJunction2.multiCenter[n].Center.Z);
						buShapeHole9.planeName = buShapeJunction2.planeName;
						buShapeHole9.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole9));
						IDCounter++;
					}
				}
			}
			if ((Job.Items[j].ShapeGroup == ShapeGroup.Engraving) & Job.Items[j].Enable)
			{
				DrillItem drillItem9 = new DrillItem((buShapeEngrave)Job.Items[j]);
				if (Job.Items[j].Tool != null)
				{
					drillItem9.ToolMilling = new ToolBase5(Job.Items[j].Tool);
				}
				list5.Add(drillItem9);
			}
		}
		SortJobItems(ref Job);
		Job.isSorted = true;
		for (int num3 = 0; num3 <= Job.ItemCalc.Count - 1; num3++)
		{
			Job.ItemCalc[num3].Calculated = false;
		}
		for (int num4 = 0; num4 <= Job.ItemCalc.Count - 1; num4++)
		{
			if (Job.ItemCalc[num4].Enable & (Job.ItemCalc[num4].Type == DrillItemType.Drill))
			{
				if (Job.ItemCalc[num4].planeName == planeBoxNames.Left)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[num4]));
				}
				if (Job.ItemCalc[num4].planeName == planeBoxNames.Right)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[num4]));
				}
				if (Job.ItemCalc[num4].planeName == planeBoxNames.Back)
				{
					list.Add(new DrillCalcItem(Job.ItemCalc[num4]));
				}
				if (Job.ItemCalc[num4].planeName == planeBoxNames.Front)
				{
					list2.Add(new DrillCalcItem(Job.ItemCalc[num4]));
				}
				if (Job.ItemCalc[num4].planeName == planeBoxNames.Top)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[num4]));
				}
				if (Job.ItemCalc[num4].planeName == planeBoxNames.Bottom)
				{
					list3.Add(new DrillCalcItem(Job.ItemCalc[num4]));
				}
			}
			if (Job.ItemCalc[num4].Enable & (Job.ItemCalc[num4].Type == DrillItemType.Slot))
			{
				list4.Add(new DrillCalcItem(Job.ItemCalc[num4]));
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
		Job.isSingleClamper = false;
		calcErrorList.Clear();
		bool flag = false;
		if (Job.FirstClamperX < 0.0 - Job.Material.Size.Width && ((0.0 - Job.Material.Size.Width < Job.SecondClamperX) & (Job.SecondClamperX < 0.0)))
		{
			flag = true;
		}
		if (!Job.ClampesSetByManuelly)
		{
			FindFirstClamperPositionsFromFullJob(Job, ref MaterialZeroYPos, ref X, ref X2, ReSort: false);
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
			Job.isSingleClamper = isSingleClamperAvailable(Job, ref X1Pos, ref X2Pos);
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
			Job.isSingleClamper = SingleMustClamper(Job, ref X1Pos2, ref X2Pos2);
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
		ItemSplited = new List<List<DrillCalcItem>>();
		list8 = new List<DrillCalcItem>();
		List<DrillCalcItem> list12 = new List<DrillCalcItem>();
		List<DrillCalcItem> list13 = new List<DrillCalcItem>();
		List<DrillCalcItem> list14 = new List<DrillCalcItem>();
		List<DrillCalcItem> list15 = new List<DrillCalcItem>();
		List<DrillCalcItem> list16 = new List<DrillCalcItem>();
		for (int num5 = 0; num5 <= list3.Count - 1; num5++)
		{
			if (list8.Count != 0)
			{
				bool flag2 = false;
				if (buCompare5.EQ(list8[list8.Count - 1].Center.X, list3[num5].Center.X, 0.01))
				{
					flag2 = true;
				}
				if (!flag2)
				{
					List<DrillCalcItem> list17 = new List<DrillCalcItem>();
					for (int num6 = 0; num6 <= list13.Count - 1; num6++)
					{
						list17.Add(list13[num6]);
					}
					for (int num7 = 0; num7 <= list14.Count - 1; num7++)
					{
						list17.Add(list14[num7]);
					}
					for (int num8 = 0; num8 <= list12.Count - 1; num8++)
					{
						list17.Add(list12[num8]);
					}
					for (int num9 = 0; num9 <= list15.Count - 1; num9++)
					{
						list17.Add(list15[num9]);
					}
					for (int num10 = 0; num10 <= list16.Count - 1; num10++)
					{
						list17.Add(list16[num10]);
					}
					ItemSplited.Add(list17);
					list8 = new List<DrillCalcItem>();
					list8.Add(list3[num5]);
					list12 = new List<DrillCalcItem>();
					list13 = new List<DrillCalcItem>();
					list14 = new List<DrillCalcItem>();
					list15 = new List<DrillCalcItem>();
					list16 = new List<DrillCalcItem>();
				}
				else
				{
					list8.Add(list3[num5]);
				}
			}
			else
			{
				list8.Add(new DrillCalcItem(list3[num5]));
			}
			if (list3[num5].planeName == planeBoxNames.Back)
			{
				list16.Add(new DrillCalcItem(list3[num5]));
			}
			if (list3[num5].planeName == planeBoxNames.Front)
			{
				list15.Add(new DrillCalcItem(list3[num5]));
			}
			if (list3[num5].planeName == planeBoxNames.Top)
			{
				list13.Add(new DrillCalcItem(list3[num5]));
			}
			if (list3[num5].planeName == planeBoxNames.Bottom)
			{
				list14.Add(new DrillCalcItem(list3[num5]));
			}
			if ((list3[num5].planeName == planeBoxNames.Left) | (list3[num5].planeName == planeBoxNames.Right))
			{
				list12.Add(new DrillCalcItem(list3[num5]));
			}
		}
		if (list8.Count > 0)
		{
			List<DrillCalcItem> list18 = new List<DrillCalcItem>();
			for (int num11 = 0; num11 <= list13.Count - 1; num11++)
			{
				list18.Add(list13[num11]);
			}
			for (int num12 = 0; num12 <= list14.Count - 1; num12++)
			{
				list18.Add(list14[num12]);
			}
			for (int num13 = 0; num13 <= list12.Count - 1; num13++)
			{
				list18.Add(list12[num13]);
			}
			for (int num14 = 0; num14 <= list15.Count - 1; num14++)
			{
				list18.Add(list15[num14]);
			}
			for (int num15 = 0; num15 <= list16.Count - 1; num15++)
			{
				list18.Add(list16[num15]);
			}
			ItemSplited.Add(list18);
		}
		drillMove = new DrillMove(clsDrill.activeJob.FirstClamperX, clsDrill.activeJob.SecondClamperX, clsDrill.varDrillCNCSettings.ParkY1, clsDrill.varDrillCNCSettings.ParkY2, clsDrill.varDrillCNCSettings.ParkY3, clsDrill.varDrillCNCSettings.ParkZ1, clsDrill.varDrillCNCSettings.ParkZ2, clsDrill.varDrillCNCSettings.ParkZ3, DrillMoveCommand.AxisMove, 0.0);
		Job.Moves.Add(drillMove);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetAll, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(X, X2, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, NoMove, ref Job);
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Wait, drillPlaneNames.Top, NoMove, ref Job);
		SplitedItems = new DrillSplitedItems();
		if (list2.Count > 0)
		{
			list9 = new List<List<DrillCalcItem>>();
			list2 = SortByYDistance(list2, new DrillCalcItem(), SortDirection.LowerToBigger);
			SplitItemsByDepth(list2, ref list9);
			for (int num16 = 0; num16 <= list9.Count - 1; num16++)
			{
				if (list9[num16].Count > 0)
				{
					List<DrillCalcItem> CopiedItem = new List<DrillCalcItem>();
					DrillCalcItem.Copy(list9[num16], ref CopiedItem);
					SplitedItems.lstFront.Add(CopiedItem);
				}
			}
		}
		for (int num17 = 0; num17 <= ItemSplited.Count - 1; num17++)
		{
			List<DrillCalcItem> list19 = new List<DrillCalcItem>();
			List<DrillCalcItem> list20 = new List<DrillCalcItem>();
			List<DrillCalcItem> list21 = new List<DrillCalcItem>();
			List<DrillCalcItem> list22 = new List<DrillCalcItem>();
			ItemSplited[num17] = SortByYDistance(ItemSplited[num17], new DrillCalcItem(), SortDirection.LowerToBigger);
			for (int num18 = 0; num18 <= ItemSplited[num17].Count - 1; num18++)
			{
				if (ItemSplited[num17][num18].planeName == planeBoxNames.Top)
				{
					list19.Add(new DrillCalcItem(ItemSplited[num17][num18]));
				}
				if (ItemSplited[num17][num18].planeName == planeBoxNames.Bottom)
				{
					list20.Add(new DrillCalcItem(ItemSplited[num17][num18]));
				}
				if (ItemSplited[num17][num18].planeName == planeBoxNames.Left)
				{
					list21.Add(new DrillCalcItem(ItemSplited[num17][num18]));
				}
				if (ItemSplited[num17][num18].planeName == planeBoxNames.Right)
				{
					list22.Add(new DrillCalcItem(ItemSplited[num17][num18]));
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
				SplitedItems.lstLeft.Add(list21);
			}
			if (list22.Count > 0)
			{
				SplitedItems.lstRight.Add(list22);
			}
		}
		if (list.Count > 0)
		{
			list9 = new List<List<DrillCalcItem>>();
			list = SortByYDistance(list, new DrillCalcItem(), SortDirection.LowerToBigger);
			SplitItemsByDepth(list, ref list9);
			for (int num19 = 0; num19 <= list9.Count - 1; num19++)
			{
				if (list9[num19].Count > 0)
				{
					List<DrillCalcItem> CopiedItem2 = new List<DrillCalcItem>();
					DrillCalcItem.Copy(list9[num19], ref CopiedItem2);
					SplitedItems.lstBack.Add(CopiedItem2);
				}
			}
		}
		FoundDrills.Clear();
		ClearCalculatedThings();
		FindHolesForFrontSide();
		FindHolesForTopSide();
		FindHolesForBottomSide();
		FindHolesForLefttSide();
		FindHolesForRightSide();
		FindHolesForBackSide();
		AssingToolOffset();
		for (int num20 = 0; num20 <= FoundDrills.Count - 2; num20++)
		{
			if (buCompare5.EQ(FoundDrills[num20].Items[0].OffsetedPoint.X, FoundDrills[num20 + 1].Items[0].OffsetedPoint.X, 0.01))
			{
				FoundDrills[num20 + 1].Items[0].OffsetedPoint.X = FoundDrills[num20].Items[0].OffsetedPoint.X + 1E-05;
			}
		}
		FoundDrills = SortByXOffsetedDistanceDrillFound(FoundDrills, new DrillCalcItem(), SortDirection.LowerToBigger);
		for (int num21 = 0; num21 <= FoundDrills.Count - 1; num21++)
		{
			if (FoundDrills[num21].Items[0].planeName != planeBoxNames.Right)
			{
				continue;
			}
			double x = FoundDrills[num21].Items[0].OffsetedPoint.X;
			int num22 = 1;
			for (int num23 = num21 + 1; num23 <= FoundDrills.Count - 1; num23++)
			{
				if (FoundDrills[num23].Items[0].planeName == planeBoxNames.Right)
				{
					double x2 = FoundDrills[num23].Items[0].OffsetedPoint.X;
					if (!(x2 - x > 0.0 && x2 - x < 100.0))
					{
						num21 = num23 - 1;
						num23 = FoundDrills.Count;
						continue;
					}
					DrillFound item2 = new DrillFound(FoundDrills[num23]);
					FoundDrills.RemoveAt(num23);
					FoundDrills.Insert(num21 + num22, item2);
					num22++;
				}
			}
		}
		if (clsDrill.varDrillCNCSettings.BackOperationsAlwaysWillLastOperation)
		{
			MoveBackOperationToLast();
		}
		CreateCodes(ref Job);
		for (int num24 = 0; num24 <= FoundDrills.Count - 1; num24++)
		{
			for (int num25 = 0; num25 <= FoundDrills[num24].Items.Count - 1; num25++)
			{
				SetAsCalculatedDrillItemByID(FoundDrills[num24].Items[num25].ID, ref Job.ItemCalc);
			}
		}
		for (int num26 = Job.ItemCalc.Count - 1; num26 >= 0; num26--)
		{
			if (Job.ItemCalc[num26].Type == DrillItemType.Drill)
			{
				if (Job.ItemCalc[num26].Enable)
				{
					if (!Job.ItemCalc[num26].Calculated)
					{
						calcErrorList.Add("Not Calculated | " + Job.ItemCalc[num26].planeName.ToString() + " - Diameter: " + Job.ItemCalc[num26].Diameter.ToString("f2") + " - Center (" + Job.ItemCalc[num26].Center.ToString() + ")");
					}
				}
				else
				{
					calcErrorList.Add("Disabled | " + Job.ItemCalc[num26].planeName.ToString() + " - Diameter: " + Job.ItemCalc[num26].Diameter.ToString("f2") + " - Center (" + Job.ItemCalc[num26].Center.ToString() + ")");
				}
			}
		}
		if (list4.Count > 0)
		{
			list4 = SortByYDistance(list4, new DrillCalcItem(), SortDirection.LowerToBigger);
			new List<DrillCalcItem>();
			for (int num27 = 0; num27 <= list4.Count - 1; num27++)
			{
				List<DrillCalcItem> ItemSlot = new List<DrillCalcItem>();
				ItemSlot.Add(list4[num27]);
				CreateCodeForSlotTopSide(ref Job, ref ItemSlot);
			}
			double num28 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			double num29 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			double num30 = 0.0;
			if (Job.Moves[Job.Moves.Count - 1].XPosition == NoMove)
			{
				num28 = Job.Moves[Job.Moves.Count - 2].X1Clamper - Job.Moves[Job.Moves.Count - 2].XPosition;
				num29 = Job.Moves[Job.Moves.Count - 2].X2Clamper - Job.Moves[Job.Moves.Count - 2].XPosition;
			}
			if (num28 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
			{
				double num31 = clsDrill.varDrillMachineSettings.MachineMinXStroke - num28;
				num28 += num31;
				num29 += num31;
				num30 += num31;
			}
		}
		CreatCodeFromJobShapeContourAndSlotItem(ref Job);
		CreatCodeFromJobShapeItem(ref Job, list5, list6, list7);
		if (Job.Moves.Count > 0)
		{
			double num32 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			double num33 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			if ((list5.Count == 0) & (list6.Count == 0) & (list7.Count == 0))
			{
				if (!(num32 < clsDrill.varDrillMachineSettings.MachineMinXStroke))
				{
					AddDrillMove(num32, num33, clsDrill.varDrillCNCSettings.ParkY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, 0.0, new DrillMoveOptions(), ref Job);
				}
				else
				{
					double num34 = num33 - num32;
					double x3 = clsDrill.varDrillMachineSettings.MachineMinXStroke - num32;
					num32 = clsDrill.varDrillMachineSettings.MachineMinXStroke;
					num33 = clsDrill.varDrillMachineSettings.MachineMinXStroke + num34;
					AddDrillMove(num32, num33, clsDrill.varDrillCNCSettings.ParkY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, x3, new DrillMoveOptions(), ref Job);
				}
			}
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.Finished, drillPlaneNames.Top, NoMove, ref Job);
		}
		CreatCodeFromMove(Job.Moves, ref Job.Codes);
		Job.TotalSec = 0.0;
		doCalculateTime(ref Job.TotalSec);
		if (calcErrorList.Count > 0 && !IgnoreErrors)
		{
			DialogBoxList dialogBoxList = new DialogBoxList();
			dialogBoxList.Caption = "No Tool Available for These Holes";
			dialogBoxList.Width = 500;
			dialogBoxList.lst_items.ScrollAlwaysVisible = true;
			dialogBoxList.lst_items.HorizontalScrollbar = true;
			for (int num35 = 0; num35 <= calcErrorList.Count - 1; num35++)
			{
				dialogBoxList.Items.Add(calcErrorList[num35]);
			}
			dialogBoxList.Init();
			dialogBoxList.ShowDialog();
			Job.isError = true;
		}
		if (clsItem.FrmProgress != null)
		{
			clsItem.FrmProgress.Visible = false;
		}
	}

	public void CreatCodeFromJobShapeItem(ref DrillJob Job, List<DrillItem> ItemShape, List<DrillItem> ItemDrillShape, List<DrillItem> ItemSlotShape)
	{
		list_2.Clear();
		list_3.Clear();
		double num = 0.0;
		double num2 = 0.0;
		new Point3D();
		new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast);
		if (!((ItemShape.Count > 0) | (ItemDrillShape.Count > 0) | (ItemSlotShape.Count > 0) | Job.MakeContour))
		{
			if (Job.Cams.Count > 0)
			{
				TpPnt9D LastP = new TpPnt9D();
				clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP);
				string Lines = "";
				clsInit.cGcodeCreate.CreatGCode(Job.Cams, ccVars.PostActive, ref Lines);
				DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCode, Job.Moves[Job.Moves.Count - 1].XPosition);
				drillMove.pntCenter = new Point3D();
				drillMove.CodeLines = new List<string>();
				buString5.StringToListByNewLine(Lines, ref drillMove.CodeLines);
				drillMove.CodeLines.Insert(0, "M6 T" + clsDrill.toolTop.Data.No);
				drillMove.CodeLines.Insert(1, "$M39");
				drillMove.CodeLines.Insert(2, "S" + clsDrill.toolTop.CamData.SpindleSpeed + " M3");
				drillMove.CodeLines.Insert(3, "M149");
				drillMove.CodeLines.Insert(4, "M1091");
				if (drillMove.CodeLines[drillMove.CodeLines.Count - 1].Trim().Length == 0)
				{
					drillMove.CodeLines.RemoveAt(drillMove.CodeLines.Count - 1);
				}
				Job.Moves.Add(drillMove);
			}
			return;
		}
		if (Job.Moves[Job.Moves.Count - 1].XPosition != 0.0)
		{
			num = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			if (num < clsDrill.varDrillMachineSettings.MachineMinXStroke)
			{
				double num3 = clsDrill.varDrillMachineSettings.MachineMinXStroke - num;
				list_2.Clear();
				list_2.Add("G0 X" + num3.ToString("f2"));
				AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition + num3, Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition + num3, NoMove, NoMove, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(), list_2, list_3, ref Job);
				List<string> list = new List<string>();
				list_2.Clear();
				list_2.Add("R910=0");
				list_2.Add("R900=" + (0.0 - num3).ToString("f1"));
				list_2.Add("L CARPB.ISC");
				double newX = Job.Moves[Job.Moves.Count - 1].X2Clamper + num3;
				double newX2 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num3;
				MoveClampers(NoMove, newX, drillPlaneNames.Top, list_2, list_3, ref Job);
				list_2.Clear();
				list_2.Add("R910=0");
				list_2.Add("R901=" + (0.0 - num3).ToString("f1"));
				list_2.Add("L CARPA.ISC");
				MoveClampers(newX2, NoMove, drillPlaneNames.Top, list_2, list_3, ref Job);
				DrillMove drillMove2 = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
				drillMove2.Command = DrillMoveCommand.GCodeList;
				drillMove2.pntCenter = new Point3D();
				drillMove2.CodeLines = new List<string>();
				if (list.Count > 0)
				{
					drillMove2.CodeLines.AddRange(list);
					Job.Moves.Add(drillMove2);
				}
			}
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition, Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition, NoMove, NoMove, DrillMoveCommand.AxisMove, 0.0, new DrillMoveOptions(), ref Job);
		}
		if (clsInit.appDrill.MachType == DrillMachineType.GoWithNoAtc)
		{
			for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
			{
				if (clsDrill.ToolList[i].Data.No == 31)
				{
					clsDrill.toolTop = new ToolBase5(clsDrill.ToolList[i]);
				}
			}
		}
		if (clsInit.appDrill.MachType == DrillMachineType.GoWithAtc)
		{
			clsDrill.toolTop = new ToolBase5(ccVars.toolActive);
		}
		num = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
		num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
		List<DrillItem> list2 = new List<DrillItem>();
		List<DrillItem> list3 = new List<DrillItem>();
		List<DrillItem> ItemShape2 = new List<DrillItem>();
		for (int j = 0; j <= ItemShape.Count - 1; j++)
		{
			if (ItemShape[j].planeName == planeBoxNames.Top)
			{
				list3.Add(ItemShape[j]);
			}
			list2.Add(ItemShape[j]);
		}
		for (int k = 0; k <= ItemDrillShape.Count - 1; k++)
		{
			if (ItemDrillShape[k].planeName == planeBoxNames.Top)
			{
				list3.Add(ItemDrillShape[k]);
				list3[list3.Count - 1].isDrill = true;
			}
			list2.Add(ItemDrillShape[k]);
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
					if (!(ItemSlotShape[l].ShapeData.Length > 2000.0))
					{
					}
					list3.Add(ItemSlotShape[l]);
				}
			}
			if (!flag)
			{
				list2.Add(ItemSlotShape[l]);
			}
		}
		list2 = SortShapeByXDistance(list2, new DrillItem(), SortDirection.LowerToBigger);
		list3 = new List<DrillItem>();
		for (int m = 0; m <= list2.Count - 1; m++)
		{
			if (list2[m].planeName == planeBoxNames.Top)
			{
				list3.Add(list2[m]);
			}
		}
		List<DrillItem> list4 = new List<DrillItem>();
		for (int n = 0; n <= list2.Count - 1; n++)
		{
			if (list2[n].planeName == planeBoxNames.Top)
			{
				double num4 = clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				double num5 = clsDrill.toolTop.Geometry.Length - list2[n].ShapeData.Depth - clsDrill.varDrillCNCSettings.ClamperThickness;
				if (num5 > 0.0)
				{
					num4 = clsDrill.toolTop.Geometry.Diameter / 2.0 + 5.0;
				}
				if (Math.Abs(list2[n].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + num4)
				{
					list4.Add(new DrillItem(list2[n]));
				}
			}
		}
		num = Job.Moves[Job.Moves.Count - 1].X1Clamper;
		num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
		AdjustClamperForShape(ref Job, list4, num, num2);
		if (ItemShape2.Count > 0)
		{
			double parkY = clsDrill.varDrillCNCSettings.ParkY2;
			AddDrillMove(NoMove, NoMove, NoMove, parkY, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.None, NoMove, ref Job);
			CreateCodeForSlotTopSide(ref ItemShape2, isTop: true, clsDrill.toolTop, ref Job);
			TpPnt9D LastP2 = new TpPnt9D();
			if (Job.Cams.Count > 0)
			{
				clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP2);
				string Lines2 = "";
				for (int num6 = 0; num6 <= Job.Cams.Count - 1; num6++)
				{
					for (int num7 = 0; num7 <= Job.Cams[num6].CamPoints.Count - 1; num7++)
					{
						if (Job.Cams[num6].CamPoints[num7].ToolCam != null)
						{
							Job.Cams[num6].CamPoints[num7].PreCodes.Add("M6 T" + Job.Cams[num6].CamPoints[num7].ToolCam.Data.No);
							Job.Cams[num6].CamPoints[num7].PreCodes.Add("$M39");
							double spindleSpeed = Job.Cams[num6].CamPoints[num7].ToolCam.CamData.SpindleSpeed;
							if (ItemShape2[num6].SpindleSpeed > 0.0)
							{
								spindleSpeed = ItemShape2[num6].SpindleSpeed;
							}
							Job.Cams[num6].CamPoints[num7].PreCodes.Add("S" + spindleSpeed + " M3");
							Job.Cams[num6].CamPoints[num7].PreCodes.Add("M149");
						}
					}
				}
				Job.Cams[0].CamPoints[0].Points[0].AfterCodes.Add("M1091");
				clsInit.cGcodeCreate.CreatGCode(Job.Cams, ccVars.PostActive, ref Lines2);
				DrillMove drillMove3 = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCode, Job.Moves[Job.Moves.Count - 1].XPosition);
				drillMove3.pntCenter = new Point3D();
				drillMove3.CodeLines = new List<string>();
				buString5.StringToListByNewLine(Lines2, ref drillMove3.CodeLines);
				if (drillMove3.CodeLines[drillMove3.CodeLines.Count - 1].Trim().Length == 0)
				{
					drillMove3.CodeLines.RemoveAt(drillMove3.CodeLines.Count - 1);
				}
				Job.Moves.Add(drillMove3);
			}
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.GCode, drillPlaneNames.Top, NoMove, ref Job);
		}
		if (list3.Count > 0)
		{
			num = Job.Moves[Job.Moves.Count - 1].X1Clamper;
			num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
			double num8 = 0.0;
			double num9 = 0.0;
			double x = clsDrill.toolTop.Positions.CommonOffset.X;
			for (int num10 = 0; num10 <= list3.Count - 1; num10++)
			{
				if (list3[num10].ToolMilling != null && ((list3[num10].ToolMilling.Data.No >= 30) & (list3[num10].ToolMilling.Data.No <= 40)))
				{
					clsDrill.toolTop = new ToolBase5(list3[num10].ToolMilling);
				}
				double ClamperMinXToToolX = 0.0;
				double ClamperMaxXToToolX = 0.0;
				double num11 = clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				double num12 = clsDrill.toolTop.Geometry.Length - list3[num10].ShapeData.Depth - clsDrill.varDrillCNCSettings.ClamperThickness;
				if (num12 > 0.0)
				{
					num11 = clsDrill.toolTop.Geometry.Diameter / 2.0 + 5.0;
				}
				if (!(Math.Abs(list3[num10].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + num11))
				{
					continue;
				}
				if (isItemInsideClamper(list3[num10], num2 + clsDrill.toolTop.Positions.CommonOffset.X + num9, clsDrill.toolTop, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, num11) | ((Math.Abs(ClamperMaxXToToolX) < 5.0) & (Math.Abs(ClamperMaxXToToolX) > 0.0)) | ((Math.Abs(ClamperMinXToToolX) < 20.0) & (Math.Abs(ClamperMinXToToolX) > 0.0)))
				{
					if (!(num2 + ClamperMinXToToolX < clsDrill.varDrillCNCSettings.ClamperLength / 2.0))
					{
						list3[num10].X2Move = 0.0 - ClamperMaxXToToolX;
					}
					else
					{
						num9 += ClamperMinXToToolX;
						double num13 = num2 + x + num9 + list3[num10].BoxMinItem.X;
						double num14 = num13 - clsDrill.toolTop.Positions.CommonOffset.X;
						if (num14 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + num11)
						{
							double num15 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + num11 - num14;
							num9 += num15;
							ClamperMinXToToolX += num15;
						}
						list3[num10].X2Move = ClamperMinXToToolX;
					}
				}
				if (isItemInsideClamper(list3[num10], num + clsDrill.toolTop.Positions.CommonOffset.X + num8, clsDrill.toolTop, ref ClamperMinXToToolX, ref ClamperMaxXToToolX, num11) | ((Math.Abs(ClamperMaxXToToolX) < 20.0) & (Math.Abs(ClamperMaxXToToolX) > 0.0)) | ((Math.Abs(ClamperMinXToToolX) < 20.0) & (Math.Abs(ClamperMinXToToolX) > 0.0)))
				{
					num8 += ClamperMinXToToolX;
					double num16 = num + x + num8 + list3[num10].BoxMinItem.X;
					double num17 = num16 - clsDrill.toolTop.Positions.CommonOffset.X;
					if (num17 < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + num11)
					{
						double num18 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + num11 - num17;
						num8 += num18;
						ClamperMinXToToolX += num18;
					}
					double num19 = num2 + num9;
					if (num19 - (num + num8) < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
					{
						double num20 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - (num19 - (num + num8));
						num9 += num20;
						list3[num10].X2Move = num20;
						list3[num10].X1First = false;
					}
					list3[num10].X1Move = ClamperMinXToToolX;
				}
			}
			double parkY2 = clsDrill.varDrillCNCSettings.ParkY2;
			AddDrillMove(NoMove, NoMove, NoMove, parkY2, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.None, NoMove, ref Job);
			CreateCodeForShapeTopAndBottomSide(ref list3, preCalculation: false, isTop: true, clsDrill.toolTop, ref Job);
			double num21 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
			double num22 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
			double num23 = Job.Moves[Job.Moves.Count - 1].XPosition;
			double num24 = 0.0;
			TpPnt9D LastP3 = new TpPnt9D();
			if (Job.Cams.Count > 0)
			{
				clsInit.cCam5.GetLastPointOfCam(Job.Cams[Job.Cams.Count - 1], ref LastP3);
				string Lines3 = "";
				for (int num25 = 0; num25 <= Job.Cams.Count - 1; num25++)
				{
					for (int num26 = 0; num26 <= Job.Cams[num25].CamPoints.Count - 1; num26++)
					{
						if (Job.Cams[num25].CamPoints[num26].ToolCam != null)
						{
							Job.Cams[num25].CamPoints[num26].PreCodes.Add("M6 T" + Job.Cams[num25].CamPoints[num26].ToolCam.Data.No);
							Job.Cams[num25].CamPoints[num26].PreCodes.Add("$M39");
							double spindleSpeed2 = Job.Cams[num25].CamPoints[num26].ToolCam.CamData.SpindleSpeed;
							if (list3[num25].SpindleSpeed > 0.0)
							{
								spindleSpeed2 = list3[num25].SpindleSpeed;
							}
							Job.Cams[num25].CamPoints[num26].PreCodes.Add("S" + spindleSpeed2 + " M3");
							Job.Cams[num25].CamPoints[num26].PreCodes.Add("M149");
							Point3D MinPoint = new Point3D();
							Point3D MaxPoint = new Point3D();
							clsInit.cVector5.BoxSizeCalculate(Job.Cams[num25].CamPoints[num26].Points, ref MinPoint, ref MaxPoint);
							for (int num27 = 0; num27 <= Job.Cams[num25].CamPoints[num26].Points.Count - 1; num27++)
							{
								num21 += Job.Cams[num25].CamPoints[num26].Points[num27].P9.X - num24;
								num22 += Job.Cams[num25].CamPoints[num26].Points[num27].P9.X - num24;
								num23 += Job.Cams[num25].CamPoints[num26].Points[num27].P9.X - num24;
								num24 = Job.Cams[num25].CamPoints[num26].Points[num27].P9.X;
							}
							if (!(num21 < clsDrill.varDrillMachineSettings.MachineMinXStroke))
							{
							}
							if (num22 > clsDrill.varDrillMachineSettings.MachineMaxXStroke)
							{
								Job.Cams[num25].CamPoints[num26].PreCodes.Add("M85");
								Job.Cams[num25].CamPoints[num26].PreCodes.Add("R910=0");
								Job.Cams[num25].CamPoints[num26].PreCodes.Add("R900=850");
								Job.Cams[num25].CamPoints[num26].PreCodes.Add("L CARPB.ISC");
								num22 -= 850.0;
								Job.Cams[num25].CamPoints[num26].PreCodes.Add("M85");
								Job.Cams[num25].CamPoints[num26].PreCodes.Add("R910=0");
								Job.Cams[num25].CamPoints[num26].PreCodes.Add("R901=850");
								Job.Cams[num25].CamPoints[num26].PreCodes.Add("L CARPA.ISC");
								num21 -= 850.0;
							}
						}
					}
				}
				Job.Cams[0].CamPoints[0].Points[0].AfterCodes.Add("M1091");
				clsInit.cGcodeCreate.CreatGCode(Job.Cams, ccVars.PostActive, ref Lines3);
				DrillMove drillMove4 = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCode, Job.Moves[Job.Moves.Count - 1].XPosition);
				drillMove4.pntCenter = new Point3D();
				drillMove4.CodeLines = new List<string>();
				buString5.StringToListByNewLine(Lines3, ref drillMove4.CodeLines);
				if (drillMove4.CodeLines[drillMove4.CodeLines.Count - 1].Trim().Length == 0)
				{
					drillMove4.CodeLines.RemoveAt(drillMove4.CodeLines.Count - 1);
				}
				Job.Moves.Add(drillMove4);
			}
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.GCode, drillPlaneNames.Top, NoMove, ref Job);
		}
		list4 = new List<DrillItem>();
		for (int num28 = 0; num28 <= list2.Count - 1; num28++)
		{
			if (list2[num28].planeName == planeBoxNames.Bottom && Math.Abs(list2[num28].BoxMinItem.Y) <= clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.BottomKorukYMinusDistance)
			{
				list4.Add(new DrillItem(list2[num28]));
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
	}

	public void AdjustClamperForShape(ref DrillJob Job, List<DrillItem> entInClamperArea, double lastX1, double lastX2)
	{
		double aPos = 0.0;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = lastX1;
		double num5 = lastX2;
		if (entInClamperArea.Count == 0)
		{
			double num6 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].X1Clamper;
			if (num6 < Job.Material.Size.Width * 0.25)
			{
				DrillMove drillMove = Job.Moves[Job.Moves.Count - 1];
				if (drillMove.X2Clamper > drillMove.XPosition)
				{
					drillMove.X2Clamper = drillMove.XPosition - 150.0;
				}
				if (drillMove.X1Clamper > drillMove.XPosition - Job.Material.Size.Width * 0.5)
				{
					drillMove.X1Clamper = drillMove.XPosition - Job.Material.Size.Width + 50.0;
				}
				if (drillMove.X2Clamper - drillMove.X1Clamper < clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					drillMove.X1Clamper = drillMove.X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
				}
				aPos = Job.Moves[Job.Moves.Count - 1].X1Clamper - lastX1;
				num = Job.Moves[Job.Moves.Count - 1].X2Clamper - lastX2;
				MoveClampers(NoMove, lastX2, drillPlaneNames.Top, ref Job, AddListCmd: true);
				AddClamperMoveForCnc(ref Job, aPos, num, isAFirst: false);
				return;
			}
		}
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
				double num7 = clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				if (flag)
				{
					num7 = clsDrill.varDrillCNCSettings.BottomKorukXPlusDistance;
				}
				if (j == 0)
				{
					MinMidMaxRange minMidMaxRange2 = new MinMidMaxRange();
					minMidMaxRange2.Max = 0.0;
					minMidMaxRange2.Min = RefList[j] + num7;
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
					minMidMaxRange3.Max = RefList[j - 1] - num7;
					minMidMaxRange3.Min = RefList[j] + num7;
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
					minMidMaxRange4.Max = RefList[j] - num7;
					minMidMaxRange4.Min = 0.0 - clsDrill.activeJob.Material.Size.Width;
					minMidMaxRange4.Mid = (minMidMaxRange4.Min + minMidMaxRange4.Max) / 2.0;
					minMidMaxRange4.Range = minMidMaxRange4.Max - minMidMaxRange4.Min;
					if ((minMidMaxRange4.Max > minMidMaxRange4.Min) & (minMidMaxRange4.Range > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance))
					{
						list.Add(minMidMaxRange4);
					}
				}
			}
			num2 = Job.Moves[Job.Moves.Count - 1].X1Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			num3 = Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].XPosition;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = true;
			bool flag5 = true;
			for (int k = 0; k <= list2.Count - 1; k++)
			{
				double num8 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				double num9 = Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				double num10 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				double num11 = Job.Moves[Job.Moves.Count - 1].X2Clamper + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
				if ((num10 > list2[k].Min) & (num10 < list2[k].Max))
				{
					flag5 = false;
				}
				if ((num11 > list2[k].Min) & (num11 < list2[k].Max))
				{
					flag5 = false;
				}
				if ((list2[k].Min > num10) & (list2[k].Min < num11))
				{
					flag5 = false;
				}
				if ((list2[k].Max > num10) & (list2[k].Max < num11))
				{
					flag5 = false;
				}
				if ((num8 > list2[k].Min) & (num8 < list2[k].Max))
				{
					flag4 = false;
				}
				if ((num9 > list2[k].Min) & (num9 < list2[k].Max))
				{
					flag4 = false;
				}
				if ((list2[k].Min > num8) & (list2[k].Min < num9))
				{
					flag4 = false;
				}
				if ((list2[k].Max > num8) & (list2[k].Max < num9))
				{
					flag4 = false;
				}
			}
			if (list.Count > 0)
			{
				num3 = 0.0;
				num2 = 0.0;
				if (flag4)
				{
					num2 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
				}
				if (flag5)
				{
					num3 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
				}
				if (!flag5)
				{
					for (int l = 0; l <= list.Count - 1; l++)
					{
						if (l != 0)
						{
							if (!flag3 && list[l].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
							{
								num3 = list[l].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag3 = true;
							}
						}
						else if (!(list[l].Max > -0.1))
						{
							if (list[l].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
							{
								num3 = list[l].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								flag3 = true;
							}
						}
						else if (!(Math.Abs(list[l].Min) < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0))
						{
							num3 = list[l].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
							if ((num3 < 0.0) & (num3 < clsDrill.varDrillCNCSettings.ClamperLength / 4.0))
							{
								flag3 = true;
							}
						}
						else if (list.Count < 2)
						{
							if (Math.Abs(list[l].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num3 = list[l].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								if ((num3 < 0.0) & (num3 < clsDrill.varDrillCNCSettings.ClamperLength / 4.0))
								{
									flag3 = true;
								}
							}
						}
						else if (!(list[1].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance))
						{
							if (Math.Abs(list[l].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num3 = list[l].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								if ((num3 < 0.0) & (2.0 < clsDrill.varDrillCNCSettings.ClamperLength / 4.0))
								{
									flag3 = true;
								}
							}
						}
						else if (!(Math.Abs(list[1].Max) < Job.Material.Size.Width / 3.0))
						{
							if (Math.Abs(list[l].Min) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num3 = list[l].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								if (num3 < clsDrill.varDrillCNCSettings.ClamperLength / 4.0)
								{
									flag3 = true;
								}
							}
						}
						else
						{
							num3 = list[1].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
							if (num3 < clsDrill.varDrillCNCSettings.ClamperLength / 4.0)
							{
								flag3 = true;
							}
						}
					}
				}
				if (!flag4)
				{
					for (int num12 = list.Count - 1; num12 >= 0; num12--)
					{
						if (num12 != list.Count - 1)
						{
							if (!flag2 && list[num12].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
							{
								num2 = list[num12].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
								if (!(num2 > clsDrill.varDrillMachineSettings.MachineMinXStroke))
								{
									double num13 = list[num12].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
									double num14 = list[num12].Max - (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance);
									if ((clsDrill.varDrillMachineSettings.MachineMinXStroke > num13) & (clsDrill.varDrillMachineSettings.MachineMinXStroke < num14))
									{
										num2 = clsDrill.varDrillMachineSettings.MachineMinXStroke;
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
						else if (!(list[num12].Min <= 0.0 - clsDrill.activeJob.Material.Size.Width))
						{
							if (list[num12].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
							{
								num2 = list[num12].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
								if (num2 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
								{
									flag2 = true;
								}
							}
						}
						else if (!(list[num12].Range < clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0))
						{
							if (!(list[num12].Range < clsDrill.varDrillCNCSettings.ClamperLength * 2.0))
							{
								num2 = list[num12].Min + (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0);
								if (num2 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
								{
									flag2 = true;
								}
							}
							else
							{
								num2 = list[num12].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								if (num2 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
								{
									flag2 = true;
								}
							}
						}
						else if (list.Count < 2)
						{
							if (Math.Abs(list[num12].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num2 = list[num12].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								if (num2 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
								{
									flag2 = true;
								}
							}
						}
						else if (!(list[list.Count - 2].Range > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance))
						{
							if (Math.Abs(list[num12].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num2 = list[num12].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								if (num2 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
								{
									flag2 = true;
								}
							}
						}
						else if (!(list[list.Count - 2].Min < (0.0 - Job.Material.Size.Width) * 0.66))
						{
							if (Math.Abs(list[num12].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
							{
								num2 = list[num12].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								if (num2 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
								{
									flag2 = true;
								}
							}
						}
						else
						{
							double num15 = list[list.Count - 2].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
							double num16 = num3 - num15;
							if (!(num16 > clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance))
							{
								if (Math.Abs(list[num12].Range) > clsDrill.varDrillCNCSettings.ClamperMinCatchXDistance)
								{
									num2 = list[num12].Max - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
									if (num2 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
									{
										flag2 = true;
									}
								}
							}
							else
							{
								num2 = list[list.Count - 2].Min + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + clsDrill.varDrillCNCSettings.SpindlePensDiameter / 2.0;
								if (num2 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
								{
									flag2 = true;
								}
							}
						}
					}
				}
				double num17 = clsDrill.activeJob.Material.Size.Width - Math.Abs(num2);
				if ((num17 < 0.0) & (clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - Math.Abs(num17) < 50.0))
				{
					num2 = 0.0 - clsDrill.activeJob.Material.Size.Width;
				}
				List<string> list3 = new List<string>();
				if (!flag5)
				{
					if (!flag3)
					{
						list3.Add(buDrillCalc.LangDrillMessage[25] + " [X2]");
					}
					else if (!buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X2Clamper, num3))
					{
						if (num3 < (0.0 - Job.Material.Size.Width) / 2.0)
						{
							for (int m = 0; m <= list2.Count - 1; m++)
							{
								if ((0.0 - Job.Material.Size.Width) / 2.0 < list2[m].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
								{
									num3 = (0.0 - Job.Material.Size.Width) / 2.0;
								}
							}
						}
						aPos = 0.0;
						if (num3 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
						{
							num2 = num3 - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
							aPos = Job.Moves[Job.Moves.Count - 1].X1Clamper - num2;
							MoveClampers(num2, NoMove, drillPlaneNames.Top, ref Job, AddListCmd: true);
						}
						num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num3;
						MoveClampers(NoMove, num3, drillPlaneNames.Top, ref Job, AddListCmd: true);
						AddClamperMoveForCnc(ref Job, aPos, num, isAFirst: true);
					}
				}
				if (!flag4)
				{
					if (!flag2)
					{
						list3.Add(buDrillCalc.LangDrillMessage[25] + " [X1]");
					}
					else if (!buCompare5.EQ(Job.Moves[Job.Moves.Count - 1].X1Clamper, num2) && num2 < (0.0 - Job.Material.Size.Width) / 2.0 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperSafeXDistance - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
					{
						double num18 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num2;
						aPos = 0.0;
						if (num18 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
						{
							num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
							aPos = Job.Moves[Job.Moves.Count - 1].X1Clamper - num2;
						}
						num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num3;
						MoveClampers(num2, NoMove, drillPlaneNames.Top, ref Job, AddListCmd: true);
						AddClamperMoveForCnc(ref Job, aPos, num, isAFirst: true);
					}
				}
				if (Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					num = 0.0;
					aPos = Job.Moves[Job.Moves.Count - 1].X1Clamper - num2;
					MoveClampers(num2, NoMove, drillPlaneNames.Top, ref Job, AddListCmd: true);
					AddClamperMoveForCnc(ref Job, aPos, num, isAFirst: true);
				}
			}
			if (!((entInClamperArea.Count > 0) & (list2.Count > 0) & (list.Count == 0 || (!flag3 && !flag5))))
			{
				return;
			}
			_ = Job.Moves[Job.Moves.Count - 1].XPosition;
			if (!(Job.Material.Size.Width < 300.0))
			{
				if (!((Job.Material.Size.Width >= 300.0) & (Job.Material.Size.Width <= 500.0)))
				{
					num5 = list2[0].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - 150.0;
					if (num5 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
					{
						num4 = num5 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
						aPos = Job.Moves[Job.Moves.Count - 1].X1Clamper - num4;
						MoveClampers(num4, NoMove, drillPlaneNames.Top, ref Job, AddListCmd: true);
					}
					num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num5;
					MoveClampers(NoMove, num5, drillPlaneNames.Top, ref Job, AddListCmd: true);
					AddClamperMoveForCnc(ref Job, aPos, num, isAFirst: true);
				}
				else
				{
					num5 = (0.0 - Job.Material.Size.Width) / 2.0;
					if (num5 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
					{
						num4 = num5 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
						aPos = Job.Moves[Job.Moves.Count - 1].X1Clamper - num4;
						MoveClampers(num4, NoMove, drillPlaneNames.Top, ref Job, AddListCmd: true);
					}
					num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num5;
					MoveClampers(NoMove, num5, drillPlaneNames.Top, ref Job, AddListCmd: true);
					AddClamperMoveForCnc(ref Job, aPos, num, isAFirst: true);
				}
			}
			else
			{
				num5 = list2[0].Min - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - 20.0;
				if (num5 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					num4 = num5 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
					aPos = Job.Moves[Job.Moves.Count - 1].X1Clamper - num4;
					MoveClampers(num4, NoMove, drillPlaneNames.Top, ref Job, AddListCmd: true);
				}
				num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num5;
				MoveClampers(NoMove, num5, drillPlaneNames.Top, ref Job, AddListCmd: true);
				AddClamperMoveForCnc(ref Job, aPos, num, isAFirst: true);
			}
			return;
		}
		double num19 = Job.Material.Size.Width - clsDrill.varDrillMachineSettings.MachineMillingStandartXStroke;
		double num20 = lastX2 - num19;
		if (!(num20 - lastX1 > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance))
		{
			double num21 = num20 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
			if (num21 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
			{
				lastX2 = num20;
				lastX1 = num20 - (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
				aPos = Job.Moves[Job.Moves.Count - 1].X1Clamper - lastX1;
				num = Job.Moves[Job.Moves.Count - 1].X2Clamper - lastX2;
				MoveClampers(lastX1, NoMove, drillPlaneNames.Top, ref Job, AddListCmd: true);
				MoveClampers(NoMove, lastX2, drillPlaneNames.Top, ref Job, AddListCmd: true);
				AddClamperMoveForCnc(ref Job, aPos, num, isAFirst: true);
			}
		}
		else
		{
			lastX2 = num20;
			aPos = 0.0;
			num = Job.Moves[Job.Moves.Count - 1].X2Clamper - lastX2;
			MoveClampers(NoMove, lastX2, drillPlaneNames.Top, ref Job, AddListCmd: true);
			AddClamperMoveForCnc(ref Job, aPos, num, isAFirst: false);
		}
	}

	public void CreatCodeFromJobShapeContourAndSlotItem(ref DrillJob Job)
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
				if (Job.Items[i].Tool != null)
				{
					drillItem.ToolMilling = new ToolBase5(Job.Items[i].Tool);
				}
				list.Add(drillItem);
			}
		}
		if (!flag)
		{
			return;
		}
		if (clsInit.appDrill.MachType == DrillMachineType.GoWithNoAtc)
		{
			for (int j = 0; j <= clsDrill.ToolList.Count - 1; j++)
			{
				if (clsDrill.ToolList[j].Data.No == 31)
				{
					clsDrill.toolTop = new ToolBase5(clsDrill.ToolList[j]);
				}
			}
		}
		if (clsInit.appDrill.MachType == DrillMachineType.GoWithAtc)
		{
			clsDrill.toolTop = new ToolBase5(ccVars.toolActive);
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
			if (list[k].ToolMilling != null)
			{
				tool = new ToolBase5(list[k].ToolMilling);
			}
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
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.AxisMove, drillPlaneNames.Top, DrillCNCMode.None, NoMove, ref Job);
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
				double parkY = clsDrill.varDrillCNCSettings.ParkY2;
				DrillMoveOptions options = new DrillMoveOptions(drillPlaneNames.Bottom, DrillCNCMode.Z1_Z2NoOffset, DrillMoveAddType.OnlyMove);
				AddDrillMove(NoMove, NoMove, y, parkY, NoMove, clsDrill.varDrillCNCSettings.Z1SafeDistance, NoMove, NoMove, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
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

	public void MoveSimPart(DrillMove pntMove)
	{
		clsDrill.SimToCollsionCheck1.Clear();
		clsDrill.SimToCollsionCheck2.Clear();
		if (pntMove.Command == DrillMoveCommand.Wait)
		{
			double num = 0.0;
			if (clsDrill.activeJob != null)
			{
				num = clsDrill.activeJob.Material.Size.Depth;
			}
			X1ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX1ClampZDistance + num;
			X2ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX2ClampZDistance + num;
		}
		if (pntMove.Command == DrillMoveCommand.AllClamperDown)
		{
			double num2 = 0.0;
			if (clsDrill.activeJob != null)
			{
				num2 = clsDrill.activeJob.Material.Size.Depth;
			}
			X1ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX1ClampZDistance + num2;
			X2ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX2ClampZDistance + num2;
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
			double num3 = 0.0;
			if (clsDrill.activeJob != null)
			{
				num3 = clsDrill.activeJob.Material.Size.Depth;
			}
			X1ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX1ClampZDistance + num3;
		}
		if (pntMove.Command == DrillMoveCommand.Clamper2Up)
		{
			X2ClamperZOffset = 0.0;
		}
		if (pntMove.Command == DrillMoveCommand.Clamper2Down)
		{
			double num4 = 0.0;
			if (clsDrill.activeJob != null)
			{
				num4 = clsDrill.activeJob.Material.Size.Depth;
			}
			X2ClamperZOffset = clsDrill.varDrillSettings.ClamperSimX2ClampZDistance + num4;
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
			if (!((clsDrill.viewportAuto.Entities.Count > 0) & (clsDrill.SimMovePartIndex[j] <= clsDrill.viewportAuto.Entities.Count - 1)))
			{
				continue;
			}
			CustomData customData = clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]].EntityData as CustomData;
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
				double num5 = 0.0;
				if ((buTool2.No >= 0) & (buTool2.No <= 299))
				{
					num5 = clsDrill.ToolPistonDownPos[buTool2.No];
				}
				if (buTool2.Tag != null && buTool2.Tag == "Z1")
				{
					((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y1Position;
					if (buTool2.No == 31)
					{
						((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = pntMove.Z1Position + num5;
					}
					else
					{
						((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = pntMove.Z1Position + num5;
					}
					Entity entity = buVector5.CopyEntities((buTool)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
					entity.Translate(0.0, 0.0 - pntMove.Y1Position, pntMove.Z1Position + num5);
					entity.Regen(new RegenParams(0.01, clsDrill.viewportAuto));
					clsDrill.SimToCollsionCheck1.Add(entity);
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
			double num6 = 0.0;
			if ((buMachinePart2.No >= 0) & (buMachinePart2.No <= 299))
			{
				num6 = clsDrill.ToolPistonDownPos[buMachinePart2.No];
			}
			if ((blockName == "X1_Body") | (blockName == "X1_Clamper"))
			{
				if (!(blockName == "X1_Clamper"))
				{
				}
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).xPos = pntMove.X1Clamper;
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = X1ClamperZOffset;
				Entity entity2 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity2.Translate(pntMove.X1Clamper, 0.0, X1ClamperZOffset);
				entity2.Regen(new RegenParams(0.01, clsDrill.viewportAuto));
				if (blockName == "X1_Clamper")
				{
					clsDrill.SimToCollsionCheck2.Add(entity2);
				}
			}
			if ((blockName == "X2_Body") | (blockName == "X2_Clamper"))
			{
				if (!(blockName == "X2_Clamper"))
				{
				}
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).xPos = pntMove.X2Clamper;
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = X2ClamperZOffset;
				Entity entity3 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity3.Translate(pntMove.X2Clamper, 0.0, X2ClamperZOffset);
				entity3.Regen(new RegenParams(0.01, clsDrill.viewportAuto));
				if (blockName == "X2_Clamper")
				{
					clsDrill.SimToCollsionCheck2.Add(entity3);
				}
			}
			if (blockName == "Y1_Body")
			{
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y1Position;
				Entity entity4 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity4.Translate(0.0, 0.0 - pntMove.Y1Position);
			}
			if (buMachinePart2.Tag != null && buMachinePart2.Tag == "Z1")
			{
				((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).yPos = 0.0 - pntMove.Y1Position;
				if (!(blockName != "Z_Milling"))
				{
					((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = pntMove.Z1Position + num6;
				}
				else
				{
					((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]).zPos = pntMove.Z1Position + num6;
				}
				Entity entity5 = buVector5.CopyEntities((buMachinePart)clsDrill.viewportAuto.Entities[clsDrill.SimMovePartIndex[j]]);
				entity5.Translate(0.0, 0.0 - pntMove.Y1Position, pntMove.Z1Position + num6);
				clsDrill.SimToCollsionCheck1.Add(entity5);
			}
		}
		clsDrill.viewportAuto.Entities.Regen();
		if (!clsDrill.viewportAuto.IsAnimationRunning)
		{
		}
	}

	public void DrawTool(int ToolNo)
	{
		CustomData customData = null;
		for (int num = clsDrill.viewportAuto.Blocks.Count - 1; num >= 0; num--)
		{
			if (clsDrill.viewportAuto.Blocks[num].Name.IndexOf("ToolMilling") >= 0)
			{
				clsDrill.viewportAuto.Blocks.RemoveAt(num);
				if (clsDrill.SimMovePartIndex.Count > 0)
				{
					clsDrill.SimMovePartIndex.RemoveAt(clsDrill.SimMovePartIndex.Count - 1);
				}
			}
		}
		List<Mesh> refMeshes = new List<Mesh>();
		Block block = null;
		buTool buTool2 = null;
		for (int i = 0; i <= ccVars.Tools.Count - 1; i++)
		{
			for (int j = 0; j <= ccVars.Tools[i].Tools.Count - 1; j++)
			{
				if (ccVars.Tools[i].Tools[j].Data.No == ToolNo)
				{
					ToolBase5 toolBase = new ToolBase5(ccVars.Tools[i].Tools[j]);
					toolBase.Geometry.Length = 41.2;
					clsInit.appMW.CreateToolWithToolDirection(toolBase, ToolCut: true, ToolBody: true, Arbor: false, Holder: false, ZeroIsMachineSide: true, ref refMeshes);
					block = new Block("ToolMilling" + ccVars.Tools[i].Tools[j].Data.No);
					buTool2 = new buTool(block.Name);
				}
			}
		}
		for (int k = 0; k <= clsDrill.ToolList.Count - 1; k++)
		{
			clsDrill.ToolList[k].Geometry.LowerRadius = 0.0;
			clsDrill.ToolList[k].Geometry.UpperRadius = 0.0;
			clsDrill.ToolList[k].Geometry.CornerRadiusType = ToolCornerRadiusType.None;
			for (int l = 0; l <= refMeshes.Count - 1; l++)
			{
				refMeshes[l].Color = Color.FromArgb(255, refMeshes[l].Color);
				if (clsDrill.ToolList[k].Data.No == 31)
				{
					double x = clsDrill.ToolList[k].Positions.CommonOffset.X;
					double y = clsDrill.ToolList[k].Positions.CommonOffset.Y;
					double dz = clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
					refMeshes[l].Translate(x, y, dz);
					buTool2.Tag = "Z1";
					refMeshes[l].EntityData = clsDrill.ToolList[k].Data.No;
					block.Entities.Add(refMeshes[l]);
					buTool2.No = clsDrill.ToolList[k].Data.No;
					customData = new CustomData();
					customData.typeDefination = entityTypeDefination.Tool;
					customData.OriginalEntityIndex = clsDrill.viewportAuto.Entities.Count;
					buTool2.EntityData = customData;
				}
			}
		}
		if (block != null && block.Entities.Count > 0)
		{
			clsDrill.viewportAuto.Blocks.Add(block);
			clsDrill.viewportAuto.Entities.Add(buTool2);
			clsDrill.SimMovePartIndex.Add(clsDrill.viewportAuto.Entities.Count - 1);
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
				if (ccVars.SimMachine.MachineParts[i].Tag != null && ccVars.SimMachine.MachineParts[i].Tag == "Z1")
				{
					num = clsDrill.varDrillCNCSettings.Y1GroupZOffset;
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
						double x = clsDrill.ToolList[k].Positions.CommonOffset.X;
						double y = clsDrill.ToolList[k].Positions.CommonOffset.Y;
						double dz2 = clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
						refMeshes[l].Translate(x, y, dz2);
					}
					else
					{
						double x2 = clsDrill.ToolList[k].Positions.CommonOffset.X;
						double y2 = clsDrill.ToolList[k].Positions.CommonOffset.Y;
						double dz3 = clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
						refMeshes[l].Translate(x2, y2, dz3);
					}
					buTool2.Tag = "Z1";
				}
				if (clsDrill.ToolList[k].Data.No == 95)
				{
					double x3 = clsDrill.ToolList[k].Positions.CommonOffset.X;
					double y3 = clsDrill.ToolList[k].Positions.CommonOffset.Y;
					double dz4 = clsDrill.varDrillCNCSettings.Y1GroupToolSawZOffset + clsDrill.varDrillCNCSettings.Y1GroupZOffset;
					refMeshes[l].Translate(x3, y3 + clsDrill.ToolList[k].Geometry.Thickness / 2.0, dz4);
					buTool2.Tag = "Z1";
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
				buMaterialMoveable buMaterialMoveable3 = new buMaterialMoveable("SolidMat" + n.ToString("D3") + num3.ToString("D3"));
				buMaterialMoveable3.XMove = true;
				Block block3 = new Block("SolidMat" + n.ToString("D3") + num3.ToString("D3"));
				block3.Entities.Add(copiedEntity);
				for (int num4 = 0; num4 <= clsDrill.viewportAuto.Blocks.Count - 1; num4++)
				{
					if (!(clsDrill.viewportAuto.Blocks[num4].Name == "SolidMat" + n.ToString("D3") + num3.ToString("D3")))
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

	public void SetTools(int ToolNo)
	{
		if (ToolNo >= 61 && ToolNo <= 70)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonVerticalDistance;
		}
		if (ToolNo >= 31 && ToolNo <= 39)
		{
			DrawTool(ToolNo);
			clsDrill.ToolPistonDownPos[31] = 0.0 - clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
			clsDrill.ToolPistonDownPos[32] = 0.0 - clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
			clsDrill.ToolPistonDownPos[33] = 0.0 - clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
			clsDrill.ToolPistonDownPos[34] = 0.0 - clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
			clsDrill.ToolPistonDownPos[35] = 0.0 - clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
			clsDrill.ToolPistonDownPos[36] = 0.0 - clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
			clsDrill.ToolPistonDownPos[37] = 0.0 - clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
			clsDrill.ToolPistonDownPos[38] = 0.0 - clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
			clsDrill.ToolPistonDownPos[39] = 0.0 - clsDrill.varDrillCNCSettings.ToolTopSpindlePistonDistance;
		}
		if (ToolNo == 95)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonSawDistance;
		}
		if (ToolNo == 72 || ToolNo == 74 || ToolNo == 76)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
			clsDrill.ToolPistonDownPos[ToolNo - 1] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
		}
		if (ToolNo == 71 || ToolNo == 73 || ToolNo == 75)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
			clsDrill.ToolPistonDownPos[ToolNo + 1] = 0.0 - clsDrill.varDrillCNCSettings.ToolPistonHorizontalDistance;
		}
	}

	public void ResetTools(int ToolNo)
	{
		if (ToolNo >= 0 && ToolNo <= 299)
		{
			clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
			if (ToolNo == 72 || ToolNo == 74 || ToolNo == 76)
			{
				clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
				clsDrill.ToolPistonDownPos[ToolNo - 1] = 0.0;
			}
			if (ToolNo == 71 || ToolNo == 73 || ToolNo == 75)
			{
				clsDrill.ToolPistonDownPos[ToolNo] = 0.0;
				clsDrill.ToolPistonDownPos[ToolNo + 1] = 0.0;
			}
		}
	}

	public void FindHolesForFrontSide()
	{
		int num = 0;
		for (int i = 0; i <= base.SplitedItems.lstFront.Count - 1; i++)
		{
			List<DrillCalcItem> list = base.SplitedItems.lstFront[i];
			List<DrillCalcItem> list2 = new List<DrillCalcItem>();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				if (!list[j].Calculated)
				{
					list2.Add(new DrillCalcItem(list[j]));
				}
			}
			if (list2.Count > 0)
			{
				list2 = SortByYDistance(list2, new DrillCalcItem(), SortDirection.LowerToBigger);
			}
			num = list2.Count;
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
			for (int m = 0; m <= num - 1; m++)
			{
				DrillFound Found = new DrillFound();
				for (int n = 0; n <= clsDrill.ToolList.Count - 1; n++)
				{
					clsDrill.ToolList[n].Data.Used = false;
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
				int num2 = 0;
				FindToolSettings findToolSettings = new FindToolSettings();
				findToolSettings.Plane = planeBoxNames.Front;
				findToolSettings.SetAsUsed = true;
				ToolBase5 foundTool = null;
				if (((m <= list2.Count - 1) & (list2.Count > 0)) && !list2[m].Calculated)
				{
					num2 = 0;
					clsInit.cDrill.isHorizontalDrillAvailabe(list2, list2[m], clsDrill.varDrillCNCSettings.ToolRepeatDistance, m, ref num2);
					if (clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
					{
						FindToolFromBlock(list2[m], 0, findToolSettings, SortDirection.BiggerToLower, ref foundTool);
					}
					else
					{
						FindToolFromBlock(list2[m], 0, findToolSettings, ref foundTool);
					}
					if (foundTool != null)
					{
						int num3 = SetValueToAvailableTool(foundTool.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
						if (num3 <= 0)
						{
							calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + foundTool.Data.No + " - Position : " + list2[m].Center.ToString());
						}
						else
						{
							list2[m].Calculated = true;
							list2[m].OffsetedPoint.Y = list2[m].Center.Y + foundTool.Positions.CommonOffset.Y;
							list2[m].HeadNo = 1;
							DrillFound.Add(list2[m], foundTool.Data.No, ref Found);
							SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
							SetAsCalculatedDrillItemByID(list2[m].ID);
						}
					}
					if (foundTool != null)
					{
						for (int num4 = m + 1; num4 <= list2.Count - 1; num4++)
						{
							double num5 = list2[num4].Center.Y - list2[m].Center.Y;
							if (clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
							{
								num5 = list2[m].Center.Y - list2[num4].Center.Y;
							}
							double value = Math.Round(num5, 5) % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
							if (!((num5 > 0.0) & !list2[num4].Calculated & buCompare5.EQ(value, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(list2[m], list2[num4])))
							{
								continue;
							}
							for (int num6 = 0; num6 <= clsDrill.ToolList.Count - 1; num6++)
							{
								if (!((foundTool.Data.GroupIndex == clsDrill.ToolList[num6].Data.GroupIndex) & !clsDrill.ToolList[num6].Data.Used & (clsDrill.ToolList[num6].Geometry.Diameter == list2[num4].Diameter) & (clsDrill.ToolList[num6].Geometry.ToolDirection.X == -1.0)))
								{
									continue;
								}
								double value2 = foundTool.Positions.CommonOffset.Y - clsDrill.ToolList[num6].Positions.CommonOffset.Y;
								if (!clsDrill.varDrillCNCSettings.MirrorCalculationForFront)
								{
								}
								if (buCompare5.EQ(value2, num5, 0.05))
								{
									int num7 = SetValueToAvailableTool(clsDrill.ToolList[num6].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool, ref Y2GroupTool);
									if (num7 > 0)
									{
										list2[num4].Calculated = true;
										list2[num4].OffsetedPoint.Y = list2[num4].Center.Y + clsDrill.ToolList[num6].Positions.CommonOffset.Y;
										list2[num4].HeadNo = 1;
										clsDrill.ToolList[num6].Data.Used = true;
										DrillFound.Add(list2[num4], clsDrill.ToolList[num6].Data.No, ref Found);
										SetAsCalculatedDrillItemByID(list2[num4].ID);
									}
									if (num7 < 1)
									{
										calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num6].Data.No + " - Position : " + list2[num4].Center.ToString());
									}
									num6 = clsDrill.ToolList.Count;
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
		int num = 0;
		for (int i = 0; i <= base.SplitedItems.lstBack.Count - 1; i++)
		{
			List<DrillCalcItem> list = base.SplitedItems.lstBack[i];
			List<DrillCalcItem> list2 = new List<DrillCalcItem>();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				if (!list[j].Calculated)
				{
					list2.Add(new DrillCalcItem(list[j]));
				}
			}
			if (list2.Count > 0)
			{
				list2 = SortByYDistance(list2, new DrillCalcItem(), SortDirection.LowerToBigger);
			}
			num = list2.Count;
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
			for (int m = 0; m <= num - 1; m++)
			{
				DrillFound Found = new DrillFound();
				for (int n = 0; n <= clsDrill.ToolList.Count - 1; n++)
				{
					clsDrill.ToolList[n].Data.Used = false;
				}
				List<int> Y1GroupTool = new List<int>();
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
				int num2 = 0;
				FindToolSettings findToolSettings = new FindToolSettings();
				findToolSettings.Plane = planeBoxNames.Back;
				findToolSettings.SetAsUsed = true;
				ToolBase5 foundTool = null;
				if (((m <= list2.Count - 1) & (list2.Count > 0)) && !list2[m].Calculated)
				{
					num2 = 0;
					clsInit.cDrill.isHorizontalDrillAvailabe(list2, list2[m], clsDrill.varDrillCNCSettings.ToolRepeatDistance, m, ref num2);
					FindToolFromBlock(list2[m], 0, findToolSettings, ref foundTool);
					if (foundTool != null)
					{
						int num3 = SetValueToAvailableTool(foundTool.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
						if (num3 <= 0)
						{
							calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + foundTool.Data.No + " - Position : " + list2[m].Center.ToString());
						}
						else
						{
							list2[m].Calculated = true;
							list2[m].OffsetedPoint.Y = list2[m].Center.Y + foundTool.Positions.CommonOffset.Y;
							list2[m].HeadNo = 1;
							DrillFound.Add(list2[m], foundTool.Data.No, ref Found);
							SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
							SetAsCalculatedDrillItemByID(list2[m].ID);
						}
					}
					if (foundTool != null)
					{
						for (int num4 = m + 1; num4 <= list2.Count - 1; num4++)
						{
							double num5 = list2[num4].Center.Y - list2[m].Center.Y;
							double value = Math.Round(num5, 5) % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
							if (!((num5 > 0.0) & !list2[num4].Calculated & buCompare5.EQ(value, 0.0, 0.05) & clsInit.cDrill.isDrillSameForSameLine(list2[m], list2[num4])))
							{
								continue;
							}
							for (int num6 = 0; num6 <= clsDrill.ToolList.Count - 1; num6++)
							{
								if (!((foundTool.Data.GroupIndex == clsDrill.ToolList[num6].Data.GroupIndex) & !clsDrill.ToolList[num6].Data.Used & (clsDrill.ToolList[num6].Geometry.Diameter == list2[num4].Diameter) & (clsDrill.ToolList[num6].Geometry.ToolDirection.X == 1.0)))
								{
									continue;
								}
								double value2 = foundTool.Positions.CommonOffset.Y - clsDrill.ToolList[num6].Positions.CommonOffset.Y;
								if (buCompare5.EQ(value2, num5, 0.05))
								{
									int num7 = SetValueToAvailableTool(clsDrill.ToolList[num6].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool);
									if (num7 > 0)
									{
										list2[num4].Calculated = true;
										list2[num4].OffsetedPoint.Y = list2[num4].Center.Y - clsDrill.ToolList[num6].Positions.CommonOffset.Y;
										list2[num4].HeadNo = 1;
										clsDrill.ToolList[num6].Data.Used = true;
										DrillFound.Add(list2[num4], clsDrill.ToolList[num6].Data.No, ref Found);
										SetAsCalculatedDrillItemByID(list2[num4].ID);
									}
									if (num7 < 1)
									{
										calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num6].Data.No + " - Position : " + list2[num4].Center.ToString());
									}
									num6 = clsDrill.ToolList.Count;
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
		int num = 0;
		for (int i = 0; i <= SplitedItems.lstTop.Count - 1; i++)
		{
			bool flag = true;
			List<DrillCalcItem> list = SplitedItems.lstTop[i];
			List<DrillCalcItem> list2 = null;
			if (i < SplitedItems.lstTop.Count - 1)
			{
				list2 = SplitedItems.lstTop[i + 1];
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
				list3 = SortByYDistance(list3, new DrillCalcItem(), SortDirection.BiggerToLower);
			}
			flag = false;
			num = list3.Count;
			for (int l = 0; l <= num - 1; l++)
			{
				DrillFound Found = new DrillFound();
				for (int m = 0; m <= clsDrill.ToolList.Count - 1; m++)
				{
					clsDrill.ToolList[m].Data.Used = false;
				}
				List<int> Y1GroupTool = new List<int>();
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
				findToolSettings.Plane = planeBoxNames.Top;
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
						clsInit.cDrill.isVerticalDrillAvailable(list3[l], SplitedItems.lstTop, clsDrill.varDrillCNCSettings.ToolRepeatDistance, i, ref Count2);
						bool flag3 = false;
						if (Count == 0 && ((Count2 == 0 && i > 0) & (FoundDrills.Count > 0)) && ((FoundDrills[FoundDrills.Count - 1].Items[0].Diameter == list3[l].Diameter) & (FoundDrills[FoundDrills.Count - 1].Items[0].planeName == list3[l].planeName)) && ((FoundDrills[FoundDrills.Count - 1].Items[0].Center.Y == list3[l].Center.Y) & (FoundDrills[FoundDrills.Count - 1].Items[0].Tool == 70)))
						{
							flag3 = true;
						}
						if (Count <= 0)
						{
							if (Count2 <= 0)
							{
								if (!(Count2 == 0 && flag3))
								{
									findToolSettings.StartToolIndex = 65;
									FindToolFromBlock(list3[l], 0, findToolSettings, SortDirection.LowerToBigger, ref foundTool);
									if (foundTool == null)
									{
										FindToolFromBlock(list3[l], 0, findToolSettings, SortDirection.BiggerToLower, ref foundTool);
									}
								}
								else
								{
									findToolSettings.StartToolIndex = 70;
									FindToolFromBlock(list3[l], 0, findToolSettings, SortDirection.BiggerToLower, ref foundTool);
								}
							}
							else
							{
								findToolSettings.StartToolIndex = 70;
								FindToolFromBlock(list3[l], 0, findToolSettings, SortDirection.BiggerToLower, ref foundTool);
							}
						}
						else
						{
							Convert.ToInt32(MaxYDistance / clsDrill.varDrillCNCSettings.ToolRepeatDistance);
							if (!clsDrill.varDrillCNCSettings.MirrorCalculationForTop)
							{
								findToolSettings.StartToolIndex = 65;
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
							int num2 = SetValueToAvailableTool(foundTool.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
							if (num2 <= 0)
							{
								calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + foundTool.Data.No + " - Position : " + list3[l].Center.ToString());
							}
							else
							{
								list3[l].Calculated = true;
								list3[l].HeadNo = 1;
								list3[l].OffsetedPoint.Y = list3[l].Center.Y + foundTool.Positions.CommonOffset.Y;
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
								double value = Math.Round(num3, 5) % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
								if (!(buCompare5.EQ(value, 0.0, 0.05) & !list3[n].Calculated & clsInit.cDrill.isDrillSameForSameLine(list3[l], list3[n])))
								{
									continue;
								}
								for (int num4 = 0; num4 <= clsDrill.ToolList.Count - 1; num4++)
								{
									if (!((foundTool.Data.GroupIndex == clsDrill.ToolList[num4].Data.GroupIndex) & !clsDrill.ToolList[num4].Data.Used & (clsDrill.ToolList[num4].Geometry.Diameter == list3[n].Diameter) & (clsDrill.ToolList[num4].Geometry.ToolDirection.Z == -1.0)))
									{
										continue;
									}
									double value2 = clsDrill.ToolList[num4].Positions.CommonOffset.Y - foundTool.Positions.CommonOffset.Y;
									if (buCompare5.EQ(value2, num3, 0.05))
									{
										int num5 = SetValueToAvailableTool(clsDrill.ToolList[num4].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool);
										if (num5 > 0)
										{
											list3[n].Calculated = true;
											list3[n].HeadNo = 1;
											list3[n].OffsetedPoint.Y = list3[n].Center.Y + clsDrill.ToolList[num4].Positions.CommonOffset.Y;
											clsDrill.ToolList[num4].Data.Used = true;
											DrillFound.Add(list3[n], clsDrill.ToolList[num4].Data.No, ref Found);
											SetAsCalculatedDrillItemByID(list3[n].ID);
										}
										if (num5 < 1)
										{
											calcErrorList.Add("Top Surface Y1 Group Tool Set Limit Full - Tool No : " + clsDrill.ToolList[num4].Data.No + " - Position : " + list3[n].Center.ToString());
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
							int maxToolCount = -1;
							if (list3[l].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + list3[l].Diameter / 2.0)
							{
								int num6 = (int)buNumeric5.RoundToLower((clsDrill.activeJob.Material.Size.Width - clsDrill.varDrillCNCSettings.ClamperLength * 1.5) / clsDrill.varDrillCNCSettings.ToolRepeatDistance);
								if (num6 > 0)
								{
									if (num6 <= 4)
									{
										maxToolCount = num6;
									}
								}
								else
								{
									maxToolCount = 1;
								}
							}
							clsInit.cDrill.FindNextVerticalDrill(SplitedItems.lstTop, list3[l], i + 1, clsDrill.varDrillCNCSettings.ToolRepeatDistance, ref foundItems, maxToolCount);
							for (int num7 = 0; num7 <= foundItems.Count - 1; num7++)
							{
								double value3 = foundItems[num7].Center.X - list3[l].Center.X;
								for (int num8 = 0; num8 <= clsDrill.ToolList.Count - 1; num8++)
								{
									if (!(!foundItems[num7].Calculated & (foundTool.Data.GroupIndex == clsDrill.ToolList[num8].Data.GroupIndex) & !clsDrill.ToolList[num8].Data.Used & (clsDrill.ToolList[num8].Geometry.Diameter == foundItems[num7].Diameter) & (clsDrill.ToolList[num8].Geometry.ToolDirection.Z == -1.0)))
									{
										continue;
									}
									double value4 = foundTool.Positions.CommonOffset.X - clsDrill.ToolList[num8].Positions.CommonOffset.X;
									double value5 = foundTool.Positions.CommonOffset.Y - clsDrill.ToolList[num8].Positions.CommonOffset.Y;
									if (buCompare5.EQ(value3, value4, 0.05) & buCompare5.EQ(value5, 0.0, 0.05))
									{
										int num9 = SetValueToAvailableTool(clsDrill.ToolList[num8].Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12, ref Y1GroupTool);
										if (num9 > 0)
										{
											foundItems[num7].HeadNo = 1;
											foundItems[num7].OffsetedPoint.Y = foundItems[num7].Center.Y + clsDrill.ToolList[num8].Positions.CommonOffset.Y;
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
								double value = Math.Round(num3, 5) % clsDrill.varDrillCNCSettings.ToolRepeatDistance;
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

	public void FindHolesForLefttSide()
	{
		int num = 0;
		for (int i = 0; i <= SplitedItems.lstLeft.Count - 1; i++)
		{
			List<DrillCalcItem> list = SplitedItems.lstLeft[i];
			List<DrillCalcItem> list2 = null;
			if (i < SplitedItems.lstLeft.Count - 1)
			{
				list2 = SplitedItems.lstLeft[i + 1];
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
			num = list3.Count;
			for (int l = 0; l <= num - 1; l++)
			{
				DrillFound Found = new DrillFound();
				for (int m = 0; m <= clsDrill.ToolList.Count - 1; m++)
				{
					clsDrill.ToolList[m].Data.Used = false;
				}
				new List<int>();
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
				int num2 = 0;
				FindToolSettings findToolSettings = new FindToolSettings();
				findToolSettings.SetAsUsed = true;
				ToolBase5 foundTool = null;
				findToolSettings.Plane = planeBoxNames.Left;
				if (((l <= list3.Count - 1) & (list3.Count > 0)) && !list3[l].Calculated)
				{
					num2 = 0;
					clsInit.cDrill.isVerticalDrillAvailable(list3[l], SplitedItems.lstLeft, clsDrill.varDrillCNCSettings.ToolRepeatDistance, i, ref num2);
					FindToolFromBlock(list3[l], 0, findToolSettings, ref foundTool);
					if (foundTool != null)
					{
						int num3 = SetValueToAvailableTool(foundTool.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
						if (num3 <= 0)
						{
							calcErrorList.Add("Left Surface Y2 Group Tool Set Limit Full - Tool No : " + foundTool.Data.No + " - Position : " + list3[l].Center.ToString());
						}
						else
						{
							list3[l].Calculated = true;
							list3[l].OffsetedPoint.Y = list3[l].Center.Y + foundTool.Positions.CommonOffset.Y;
							list3[l].HeadNo = 1;
							DrillFound.Add(list3[l], foundTool.Data.No, ref Found);
							SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
							SetAsCalculatedDrillItemByID(list3[l].ID);
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

	public void FindHolesForRightSide()
	{
		int num = 0;
		for (int i = 0; i <= SplitedItems.lstRight.Count - 1; i++)
		{
			List<DrillCalcItem> list = SplitedItems.lstRight[i];
			List<DrillCalcItem> list2 = null;
			if (i < SplitedItems.lstRight.Count - 1)
			{
				list2 = SplitedItems.lstRight[i + 1];
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
			num = list3.Count;
			for (int l = 0; l <= num - 1; l++)
			{
				DrillFound Found = new DrillFound();
				for (int m = 0; m <= clsDrill.ToolList.Count - 1; m++)
				{
					clsDrill.ToolList[m].Data.Used = false;
				}
				new List<int>();
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
				int num2 = 0;
				FindToolSettings findToolSettings = new FindToolSettings();
				findToolSettings.SetAsUsed = true;
				ToolBase5 foundTool = null;
				findToolSettings.Plane = planeBoxNames.Right;
				if (((l <= list3.Count - 1) & (list3.Count > 0)) && !list3[l].Calculated)
				{
					num2 = 0;
					clsInit.cDrill.isVerticalDrillAvailable(list3[l], SplitedItems.lstRight, clsDrill.varDrillCNCSettings.ToolRepeatDistance, i, ref num2);
					FindToolFromBlock(list3[l], 0, findToolSettings, ref foundTool);
					if (foundTool != null)
					{
						int num3 = SetValueToAvailableTool(foundTool.Data.No, ref T, ref T2, ref T3, ref T4, ref T5, ref T6, ref T7, ref T8, ref T9, ref T10, ref T11, ref T12);
						if (num3 <= 0)
						{
							calcErrorList.Add("Rigth Surface Y2 Group Tool Set Limit Full - Tool No : " + foundTool.Data.No + " - Position : " + list3[l].Center.ToString());
						}
						else
						{
							list3[l].Calculated = true;
							list3[l].OffsetedPoint.Y = list3[l].Center.Y + foundTool.Positions.CommonOffset.Y;
							list3[l].HeadNo = 1;
							DrillFound.Add(list3[l], foundTool.Data.No, ref Found);
							SetAsUsedToolByNo(foundTool.Data.No, ref clsDrill.ToolList);
							SetAsCalculatedDrillItemByID(list3[l].ID);
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
				double x = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.0 + FoundDrills[i].Items[j].Center.X;
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
		LastPlane = drillPlaneNames.Top;
		if (FoundDrills.Count > 0)
		{
			if (FoundDrills[0].Items.Count <= 0)
			{
				buString5.AddStringsToList("M87", ref list_2);
				DrillMoveOptions drillMoveOptions = new DrillMoveOptions();
				drillMoveOptions.OnlyCode = true;
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, list_2, list_3, ref Job);
			}
			else
			{
				double num = FoundDrills[0].Items[0].OffsetedPoint.X + clsDrill.varDrillCNCSettings.X1SafeDistance;
				if (!(Job.Moves[Job.Moves.Count - 1].X2Clamper + num > clsDrill.varDrillMachineSettings.MachineMaxXStroke))
				{
					buString5.AddStringsToList("M87", ref list_2);
					DrillMoveOptions drillMoveOptions2 = new DrillMoveOptions();
					drillMoveOptions2.OnlyCode = true;
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions2, list_2, list_3, ref Job);
				}
				else
				{
					double num2 = 0.0;
					num2 = ((FoundDrills.Count >= 2) ? (FoundDrills[1].Items[0].OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition) : (FoundDrills[0].Items[0].OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition));
					double num3 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num2;
					double num4 = num3 - clsDrill.varDrillMachineSettings.MachineMaxXStroke + 100.0;
					num2 = 500.0;
					if (num4 > 0.0 && num4 < 500.0)
					{
						num2 = num4;
					}
					if (num4 >= 500.0 && num4 < 1000.0)
					{
						num2 = num4;
					}
					if (num4 > 1000.0)
					{
						num2 = 1000.0;
					}
					if (num2 > 1000.0)
					{
						num2 = 1000.0;
					}
					buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2, ClearList: true, "M87");
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(), list_2, list_3, ref Job);
					double num5 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num2;
					double num6 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num2;
					List<string> list = new List<string>();
					double num7 = 0.0;
					if (num5 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
					{
						if (num6 - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
						{
							num7 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num5;
							list_2.Clear();
							list_2.Add("R910=0");
							list_2.Add("R901=" + num7.ToString("f1"));
							list_2.Add("L CARPA.ISC");
							MoveClampers(num5, NoMoveX2, drillPlaneNames.Top, list_2, list_3, ref Job);
						}
						num7 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num6;
						list_2.Clear();
						list_2.Add("R910=0");
						list_2.Add("R900=" + num7.ToString("f1"));
						list_2.Add("L CARPB.ISC");
						MoveClampers(NoMoveX1, num6, drillPlaneNames.Top, list_2, list_3, ref Job);
					}
					DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
					drillMove.Command = DrillMoveCommand.GCodeList;
					drillMove.pntCenter = new Point3D();
					drillMove.CodeLines = new List<string>();
					if (list.Count > 0)
					{
						drillMove.CodeLines.AddRange(list);
					}
					Job.Moves.Add(drillMove);
				}
			}
		}
		for (int i = 0; i <= FoundDrills.Count - 1; i++)
		{
			if (FoundDrills[i].Items[0].planeName == planeBoxNames.Top)
			{
				CreateCodeForTop(ref Job, FoundDrills[i].Items, i);
			}
			if (FoundDrills[i].Items[0].planeName == planeBoxNames.Front)
			{
				CreateCodeForFront(ref Job, FoundDrills[i].Items, i);
			}
			if (FoundDrills[i].Items[0].planeName == planeBoxNames.Back)
			{
				CreateCodeForBack(ref Job, FoundDrills[i].Items, i);
			}
			if (FoundDrills[i].Items[0].planeName == planeBoxNames.Left)
			{
				CreateCodeForLeft(ref Job, FoundDrills[i].Items, i);
			}
			if (FoundDrills[i].Items[0].planeName == planeBoxNames.Right)
			{
				CreateCodeForRight(ref Job, FoundDrills[i].Items, i);
			}
			if (i >= FoundDrills.Count - 1 || FoundDrills[i + 1].Items.Count <= 0)
			{
				continue;
			}
			double num8 = FoundDrills[i + 1].Items[0].OffsetedPoint.X - FoundDrills[i].Items[0].OffsetedPoint.X;
			double num9 = FoundDrills[FoundDrills.Count - 1].Items[0].OffsetedPoint.X - FoundDrills[i].Items[0].OffsetedPoint.X;
			double num10 = num8 + 100.0;
			if (num9 > num8)
			{
				num10 = num9 + 100.0;
			}
			if (!(Job.Moves[Job.Moves.Count - 1].X2Clamper + num8 > clsDrill.varDrillMachineSettings.MachineMaxXStroke))
			{
				continue;
			}
			double num11 = Math.Round(Job.Moves[Job.Moves.Count - 1].X2Clamper + num10 - clsDrill.varDrillMachineSettings.MachineMaxXStroke, 5);
			double num12 = FoundDrills[FoundDrills.Count - 1].Items[0].OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			double num13 = FoundDrills[FoundDrills.Count - 1].Items[0].OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			double num14 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num11;
			double num15 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num11;
			double xPosition = Job.Moves[Job.Moves.Count - 1].XPosition;
			double num16 = xPosition - Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 50.0;
			double num17 = 0.0;
			List<string> list2 = new List<string>();
			if (num15 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
			{
				num15 = clsDrill.varDrillMachineSettings.MachineMinXStroke + 20.0;
			}
			if (num15 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
			{
				if (num15 < num16)
				{
					num12 -= num16 - num15;
				}
				buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(), list_2, list_3, ref Job);
				_ = Job.Moves[Job.Moves.Count - 1].X1Clamper - num12;
				_ = Job.Moves[Job.Moves.Count - 1].X2Clamper - num13;
				num17 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num15;
				list_2.Clear();
				list_2.Add("R910=0");
				list_2.Add("R901=" + num17.ToString("f1"));
				list_2.Add("L CARPA.ISC");
				MoveClampers(num15, NoMoveX2, drillPlaneNames.Top, list_2, list_3, ref Job);
				num17 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num14;
				list_2.Clear();
				list_2.Add("R910=0");
				list_2.Add("R900=" + num17.ToString("f1"));
				list_2.Add("L CARPB.ISC");
				MoveClampers(NoMoveX1, num14, drillPlaneNames.Top, list_2, list_3, ref Job);
				DrillMove drillMove2 = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
				drillMove2.Command = DrillMoveCommand.GCodeList;
				drillMove2.pntCenter = new Point3D();
				drillMove2.CodeLines = new List<string>();
				if (list2.Count > 0)
				{
					drillMove2.CodeLines.AddRange(list2);
				}
				Job.Moves.Add(drillMove2);
			}
		}
	}

	public void CreateCodeForTop(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
	{
		List<string> CodesSL = new List<string>();
		list_2.Clear();
		list_3.Clear();
		drillPlaneNames refPlane = drillPlaneNames.Top;
		Point3D point3D = new Point3D();
		DrillCalcItem drillCalcItem = null;
		DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
		double centerX = 0.0;
		double num = 0.0;
		double num2 = 0.0;
		double y = NoMoveY1;
		double noMoveZ = NoMoveZ1;
		double z = NoMoveZ1;
		double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		double z2 = NoMoveZ1;
		bool flag = false;
		List<ToolBase5> list = new List<ToolBase5>();
		double num3 = clsDrill.varDrillCNCSettings.DrillPlungeFeed;
		double num4 = 0.0;
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			if ((drillCalcItem == null) & (Items[i].HeadNo == 1))
			{
				drillCalcItem = Items[i];
				y = drillCalcItem.OffsetedPoint.Y;
				noMoveZ = drillCalcItem.Center.Z;
				z2 = noMoveZ - drillCalcItem.Depth;
				z = noMoveZ + clsDrill.varDrillCNCSettings.Z1SmallSafeDistance;
				centerX = drillCalcItem.Center.X;
				point3D.X = drillCalcItem.Center.X;
				point3D.Y = drillCalcItem.Center.Y;
				point3D.Z = drillCalcItem.Depth;
			}
			if (Items[i].HeadNo == 1)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option);
			}
			if (Items[i] != null && Items[i].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + Items[i].Diameter / 2.0)
			{
				flag = true;
			}
			if (Items[i].Tool <= 0)
			{
				calcErrorList.Add(buDrillCalc.LangDrillMessage[40] + " - " + clsInit.cDrill.DrillCalcItemToString(Items[i]));
				continue;
			}
			ToolBase5 foundTool = new ToolBase5();
			if (FindToolWithToolNo(Items[i].Tool, ref foundTool))
			{
				if (foundTool.CamData.PlungeSpeed > 0.0)
				{
					num3 = foundTool.CamData.PlungeSpeed;
					num4 = foundTool.CamData.WaitTime;
				}
				list.Add(foundTool);
			}
		}
		if (drillCalcItem != null)
		{
			num = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			num2 = drillCalcItem.OffsetedPoint.X;
		}
		if (Index != 0)
		{
			if (FoundDrills[Index - 1].Items[0].planeName != planeBoxNames.Top)
			{
				buString5.AddStringsToList("M6T" + Option.Tool1, ref list_2, ClearList: true, "M16");
			}
			else if (FoundDrills[Index - 1].Items[0].Tool != drillCalcItem.Tool)
			{
				buString5.AddStringsToList("M6T" + Option.Tool1, ref list_2, ClearList: true, "M16");
			}
			Option.OnlyCode = true;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveX2, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			Option.OnlyCode = false;
		}
		else
		{
			buString5.AddStringsToList("M85", ref list_2, ClearList: true, "M6T" + Option.Tool1, "M16", "G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"));
			Option.isG0 = true;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			LastZ = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		}
		if (flag & !Job.isSingleClamper)
		{
			CheckClampers(Index, num, centerX, Items[0], refPlane, list, ref Job, ref CodesSL);
		}
		if (!(Job.Moves[Job.Moves.Count - 1].X2Clamper + num > clsDrill.varDrillMachineSettings.MachineMaxXStroke))
		{
			buString5.AddStringsToList("G0 X" + point3D.X.ToString("f2") + " Y" + point3D.Y.ToString("f2"), ref list_2);
			Option.Mode = DrillCNCMode.Fast;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, y, NoMoveZ1, DrillMoveCommand.AxisMove, num2, Option, list_2, list_3, ref Job);
		}
		else
		{
			double num5 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num - clsDrill.varDrillMachineSettings.MachineMaxXStroke;
			buString5.AddStringsToList("G0 X" + (point3D.X - num5).ToString("f2") + " Y" + point3D.Y.ToString("f2"), ref list_2);
			Option.Mode = DrillCNCMode.Fast;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num - num5, Job.Moves[Job.Moves.Count - 1].X2Clamper + num - num5, y, NoMoveZ1, DrillMoveCommand.AxisMove, num2 - num5, Option, list_2, list_3, ref Job);
			list_2.Clear();
			list_2.Add("R910=0");
			list_2.Add("R901=" + num5.ToString("f1"));
			list_2.Add("L CARPA.ISC");
			MoveClampers(Job.Moves[Job.Moves.Count - 1].X1Clamper - num5, NoMoveX2, drillPlaneNames.Top, list_2, list_3, ref Job);
			list_2.Clear();
			list_2.Add("R910=0");
			list_2.Add("R900=" + num5.ToString("f1"));
			list_2.Add("L CARPB.ISC");
			MoveClampers(NoMoveX1, Job.Moves[Job.Moves.Count - 1].X2Clamper - num5, drillPlaneNames.Top, list_2, list_3, ref Job);
			buString5.AddStringsToList("G0 X" + point3D.X.ToString("f2") + " Y" + point3D.Y.ToString("f2"), ref list_2);
			Option.Mode = DrillCNCMode.Fast;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num5, Job.Moves[Job.Moves.Count - 1].X2Clamper + num5, y, NoMoveZ1, DrillMoveCommand.AxisMove, num2, Option, list_2, list_3, ref Job);
		}
		Option.Mode = DrillCNCMode.ToolSet;
		buString5.AddStringsToList("G0 Z" + z.ToString("f2"), ref list_2);
		ToolSetAddList(Option, ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.SetPiston, NoMove, Option, list_2, list_3, ref Job);
		Option.Mode = DrillCNCMode.Plunge;
		buString5.AddStringsToList("G1 Z" + z2.ToString("f2") + " F" + num3, ref list_2);
		if (num4 > 0.0)
		{
			buString5.AddStringsToList("G4 F" + num4.ToString("f1"), ref list_2, ClearList: false);
		}
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z2, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		if (Index >= FoundDrills.Count - 1)
		{
			buString5.AddStringsToList("G0 Z" + z1SafeDistance.ToString("f2"), ref list_2);
			Option.Mode = DrillCNCMode.Safe;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			list_2.Clear();
			Option.Mode = DrillCNCMode.ToolReset;
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
		}
		else
		{
			bool flag2 = false;
			if (FoundDrills[Index + 1].Items[0].planeName != planeBoxNames.Top)
			{
				buString5.AddStringsToList("G0 Z" + z1SafeDistance.ToString("f2"), ref list_2);
				Option.Mode = DrillCNCMode.Safe;
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
				Option.Mode = DrillCNCMode.ToolReset;
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
			}
			else
			{
				if (clsInit.cDrill.isToolsSameForNextOperation(Items, FoundDrills[Index + 1].Items))
				{
					flag2 = true;
				}
				if (flag)
				{
					flag2 = false;
				}
				if (!flag2)
				{
					buString5.AddStringsToList("G0 Z" + z.ToString("f2"), ref list_2);
					Option.Mode = DrillCNCMode.SafeRapid;
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
					buString5.AddStringsToList("M85", ref list_2);
					Option.Mode = DrillCNCMode.ToolReset;
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
				}
				else if (Job.isSingleClamper)
				{
					if (!flag)
					{
						buString5.AddStringsToList("G0 Z" + z.ToString("f2"), ref list_2, ClearList: true, "M144");
						Option.Mode = DrillCNCMode.SafeRapid;
						AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
					}
					else
					{
						buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2, ClearList: true, "M144");
						Option.Mode = DrillCNCMode.SafeRapid;
						AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
					}
				}
				else
				{
					buString5.AddStringsToList("G0 Z" + z.ToString("f2"), ref list_2, ClearList: true, "M144");
					Option.Mode = DrillCNCMode.SafeRapid;
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
				}
			}
		}
		LastPlane = drillPlaneNames.Top;
		DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
		drillMove.Command = DrillMoveCommand.GCodeList;
		drillMove.pntCenter = new Point3D();
		drillMove.CodeLines = new List<string>();
		drillMove.CodeLines.AddRange(CodesSL);
		if (CodesSL.Count > 0)
		{
			Job.Moves.Add(drillMove);
		}
	}

	public void CreateCodeForFront(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
	{
		list_2.Clear();
		list_3.Clear();
		List<string> list = new List<string>();
		DrillCalcItem drillCalcItem = null;
		drillPlaneNames plane = drillPlaneNames.Front;
		Point3D point3D = new Point3D();
		DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Front, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double y = NoMoveY1;
		double z = NoMoveZ1;
		double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		double num7 = double.MaxValue;
		double num8 = 0.0;
		List<ToolBase5> list2 = new List<ToolBase5>();
		double num9 = clsDrill.varDrillCNCSettings.DrillPlungeFeed;
		double num10 = 0.0;
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			if ((drillCalcItem == null) & (Items[i].HeadNo == 1))
			{
				drillCalcItem = Items[i];
				y = drillCalcItem.OffsetedPoint.Y;
				z = drillCalcItem.Center.Z;
				num8 = drillCalcItem.Center.X;
				point3D.X = drillCalcItem.Depth;
				point3D.Y = drillCalcItem.Center.Y;
				point3D.Z = drillCalcItem.Center.Z;
			}
			if (Items[i].HeadNo == 1)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option);
			}
			if (Items[i].Center.Y < num7)
			{
				num7 = Items[i].Center.Y;
			}
			if (Items[i].Tool <= 0)
			{
				calcErrorList.Add("No Defined Tool For This OP");
				continue;
			}
			ToolBase5 foundTool = new ToolBase5();
			if (FindToolWithToolNo(Items[i].Tool, ref foundTool))
			{
				if (foundTool.CamData.PlungeSpeed > 0.0)
				{
					num9 = foundTool.CamData.PlungeSpeed;
					num10 = foundTool.CamData.WaitTime;
				}
				list2.Add(foundTool);
			}
		}
		if (drillCalcItem != null)
		{
			ToolBase5 foundTool2 = new ToolBase5();
			FindToolWithToolNo(drillCalcItem.Tool, ref foundTool2);
			num2 = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			num3 = drillCalcItem.OffsetedPoint.X;
			num4 = num3 - foundTool2.Geometry.Length - clsDrill.varDrillCNCSettings.X1SafeDistance;
			num5 = num3 - foundTool2.Geometry.Length - clsDrill.varDrillCNCSettings.X1SmallSafeDistance;
			num6 = num3 - foundTool2.Geometry.Length + drillCalcItem.Depth;
		}
		if (!Job.isSingleClamper && ((num7 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0) & ((Job.Moves[Job.Moves.Count - 1].X2Clamper > 0.0) | (Math.Abs(Job.Moves[Job.Moves.Count - 1].X2Clamper) < clsDrill.varDrillCNCSettings.ClamperLength / 2.0))))
		{
			double num11 = 0.0;
			double num12 = 0.0;
			if (Index < FoundDrills.Count - 1)
			{
				for (int j = Index + 1; j <= FoundDrills.Count - 1; j++)
				{
					for (int k = 0; k <= FoundDrills[j].Items.Count - 1; k++)
					{
						if (FoundDrills[j].Items[k].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + FoundDrills[j].Items[k].Diameter / 2.0)
						{
							double num13 = FoundDrills[j].Items[k].Center.X - num8;
							if (num13 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && ((FoundDrills[j].Items[k].planeName == planeBoxNames.Top) | (FoundDrills[j].Items[k].planeName == planeBoxNames.Left)) && num13 > num11)
							{
								num11 = num13;
							}
						}
					}
				}
			}
			if (num11 > 0.0)
			{
				num11 += clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
			}
			num12 = list2[0].Positions.CommonOffset.X - list2[0].Geometry.Length - 40.0;
			double num14 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num2;
			if (num14 > num12)
			{
				double num15 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (num14 - num12) - num11;
				double num16 = num15 - Job.Moves[Job.Moves.Count - 1].X1Clamper;
				if (num16 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					double num17 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					num = Job.Moves[Job.Moves.Count - 1].X1Clamper - (num15 - num17);
					list_2.Clear();
					list_2.Add("R910=0");
					list_2.Add("R901=" + num.ToString("f1"));
					list_2.Add("L CARPA.ISC");
					MoveClampers(num15 - num17, NoMove, plane, list_2, list_3, ref Job);
				}
				num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num15;
				list_2.Clear();
				list_2.Add("R910=0");
				list_2.Add("R900=" + num.ToString("f1"));
				list_2.Add("L CARPB.ISC");
				MoveClampers(NoMove, num15, plane, list_2, list_3, ref Job);
			}
		}
		if (Index != 0)
		{
			if (FoundDrills[Index - 1].Items[0].planeName != planeBoxNames.Front)
			{
				buString5.AddStringsToList("M6T" + Option.Tool1, ref list_2, ClearList: true, "M16");
			}
			else if (FoundDrills[Index - 1].Items[0].Tool != drillCalcItem.Tool)
			{
				buString5.AddStringsToList("M6T" + Option.Tool1, ref list_2, ClearList: true, "M16");
			}
		}
		else
		{
			buString5.AddStringsToList("M85", ref list_2, ClearList: true, "M6T" + Option.Tool1, "M16", "G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"));
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			LastZ = clsDrill.varDrillCNCSettings.Z1SafeDistance;
			buString5.AddStringsToList("G0 X" + (0.0 - clsDrill.varDrillCNCSettings.XSafeDistance).ToString("f2") + " Y" + point3D.Y.ToString("f2"), ref list_2);
			num2 = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, y, NoMoveZ1, DrillMoveCommand.AxisMove, num4, Option, list_2, list_3, ref Job);
		}
		if (Index <= 0)
		{
			list_2.Add("G0 X" + (0.0 - clsDrill.varDrillCNCSettings.X1SafeDistance).ToString("f2") + " Y" + point3D.Y.ToString("f2"));
		}
		else if (FoundDrills[Index - 1].Items[0].planeName != planeBoxNames.Front)
		{
			list_2.Add("G0 X" + (0.0 - clsDrill.varDrillCNCSettings.X1SafeDistance).ToString("f2") + " Y" + point3D.Y.ToString("f2"));
		}
		else
		{
			list_2.Add("G0 X" + (0.0 - clsDrill.varDrillCNCSettings.X1SmallSafeDistance).ToString("f2") + " Y" + point3D.Y.ToString("f2"));
		}
		num2 = num5 - Job.Moves[Job.Moves.Count - 1].XPosition;
		AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, y, NoMoveZ1, DrillMoveCommand.AxisMove, num5, Option, list_2, list_3, ref Job);
		list_2.Clear();
		ToolSetAddList(Option, ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.SetPiston, NoMove, Option, list_2, list_3, ref Job);
		buString5.AddStringsToList("G0 Z" + point3D.Z.ToString("f2"), ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		num2 = num6 - Job.Moves[Job.Moves.Count - 1].XPosition;
		buString5.AddStringsToList("G1 X" + point3D.X.ToString("f2") + " F" + num9, ref list_2);
		AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, num6, Option, list_2, list_3, ref Job);
		if (num10 > 0.0)
		{
			buString5.AddStringsToList("G4 F" + num10.ToString("f1"), ref list_2, ClearList: false);
		}
		if (Index >= FoundDrills.Count - 1)
		{
			num2 = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			buString5.AddStringsToList("G0 X" + (0.0 - clsDrill.varDrillCNCSettings.XSafeDistance).ToString("f2"), ref list_2);
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, num4, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("M85", ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX1, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		}
		else
		{
			bool flag = false;
			if (FoundDrills[Index + 1].Items[0].planeName != planeBoxNames.Front)
			{
				num2 = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
				buString5.AddStringsToList("G0 X" + (0.0 - clsDrill.varDrillCNCSettings.XSafeDistance).ToString("f2"), ref list_2);
				AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, num4, Option, list_2, list_3, ref Job);
				buString5.AddStringsToList("M85", ref list_2);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
				buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2);
				AddDrillMove(NoMoveX1, NoMoveX1, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			}
			else
			{
				buString5.AddStringsToList("G0 X" + (0.0 - clsDrill.varDrillCNCSettings.X1SmallSafeDistance).ToString("f2"), ref list_2);
				num2 = num5 - Job.Moves[Job.Moves.Count - 1].XPosition;
				AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, num5, Option, list_2, list_3, ref Job);
				if (clsInit.cDrill.isToolsSameForNextOperation(Items, FoundDrills[Index + 1].Items))
				{
					flag = true;
				}
				if (flag)
				{
					buString5.AddStringsToList("M144", ref list_2);
					Option.OnlyCode = true;
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
					Option.OnlyCode = false;
				}
				else
				{
					buString5.AddStringsToList("M85", ref list_2);
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
				}
			}
		}
		DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
		drillMove.Command = DrillMoveCommand.GCodeList;
		drillMove.pntCenter = new Point3D();
		drillMove.CodeLines = new List<string>();
		drillMove.CodeLines.AddRange(list);
		if (list.Count > 0)
		{
			Job.Moves.Add(drillMove);
		}
		LastPlane = drillPlaneNames.Front;
	}

	public void CreateCodeForBack(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
	{
		list_2.Clear();
		list_3.Clear();
		List<string> list = new List<string>();
		DrillCalcItem drillCalcItem = null;
		Point3D point3D = new Point3D();
		DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Back, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double y = NoMoveY1;
		double z = NoMoveZ1;
		double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		double num7 = double.MaxValue;
		double num8 = 0.0;
		List<ToolBase5> list2 = new List<ToolBase5>();
		double num9 = clsDrill.varDrillCNCSettings.DrillPlungeFeed;
		double num10 = 0.0;
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			if ((drillCalcItem == null) & (Items[i].HeadNo == 1))
			{
				drillCalcItem = Items[i];
				y = drillCalcItem.OffsetedPoint.Y;
				z = drillCalcItem.Center.Z;
				num8 = drillCalcItem.Center.X;
				point3D.X = Job.Material.Size.Width - drillCalcItem.Depth;
				point3D.Y = drillCalcItem.Center.Y;
				point3D.Z = drillCalcItem.Center.Z;
			}
			if (Items[i].HeadNo == 1)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option);
			}
			if (Items[i].Center.Y < num7)
			{
				num7 = Items[i].Center.Y;
			}
			if (Items[i].Tool <= 0)
			{
				calcErrorList.Add("No Defined Tool For This OP");
				continue;
			}
			ToolBase5 foundTool = new ToolBase5();
			if (FindToolWithToolNo(Items[i].Tool, ref foundTool))
			{
				if (foundTool.CamData.PlungeSpeed > 0.0)
				{
					num9 = foundTool.CamData.PlungeSpeed;
					num10 = foundTool.CamData.WaitTime;
				}
				list2.Add(foundTool);
			}
		}
		if (drillCalcItem != null)
		{
			ToolBase5 foundTool2 = new ToolBase5();
			FindToolWithToolNo(drillCalcItem.Tool, ref foundTool2);
			num2 = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			num3 = drillCalcItem.OffsetedPoint.X;
			num4 = num3 + foundTool2.Geometry.Length + clsDrill.varDrillCNCSettings.X1SafeDistance;
			num5 = num3 + foundTool2.Geometry.Length + clsDrill.varDrillCNCSettings.X1SmallSafeDistance;
			num6 = num3 + foundTool2.Geometry.Length - drillCalcItem.Depth;
		}
		if (!Job.isSingleClamper)
		{
			double num11 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
			if ((num7 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0) & (Job.Moves[Job.Moves.Count - 1].X1Clamper < num11 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0))
			{
				double num12 = 0.0;
				if (Index < FoundDrills.Count - 1)
				{
					for (int j = Index + 1; j <= FoundDrills.Count - 1; j++)
					{
						for (int k = 0; k <= FoundDrills[j].Items.Count - 1; k++)
						{
							if (FoundDrills[j].Items[k].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + FoundDrills[j].Items[k].Diameter / 2.0)
							{
								double num13 = Math.Abs(FoundDrills[j].Items[k].Center.X - num8);
								if (num13 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && ((FoundDrills[j].Items[k].planeName == planeBoxNames.Top) | (FoundDrills[j].Items[k].planeName == planeBoxNames.Left)) && num13 > num12)
								{
									num12 = num13;
								}
							}
						}
					}
				}
				if (num12 > 0.0)
				{
					num12 += clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
				}
				num2 = num6 - Job.Moves[Job.Moves.Count - 1].XPosition;
				double num14 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num2;
				double num15 = list2[0].Positions.CommonOffset.X + list2[0].Geometry.Length + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
				if ((num7 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + clsDrill.varDrillCNCSettings.HorizontalToolHolderWidth / 2.0) & (num14 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 < num15))
				{
					double num16 = num15 - (num14 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0);
					if (num16 > 0.0)
					{
						num14 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num16 + clsDrill.varDrillCNCSettings.ClamperSafeXDistance + num12;
						double num17 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num14;
						if (num17 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
						{
							double num18 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
							double num19 = num14 + num18;
							num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num19;
							list_2.Clear();
							list_2.Add("R910=0");
							list_2.Add("R900=" + num.ToString("f1"));
							list_2.Add("L CARPB.ISC");
							MoveClampers(NoMove, num19, drillPlaneNames.Back, list_2, list_3, ref Job);
						}
						num = Job.Moves[Job.Moves.Count - 1].X1Clamper - num14;
						list_2.Clear();
						list_2.Add("R910=0");
						list_2.Add("R901=" + num.ToString("f1"));
						list_2.Add("L CARPA.ISC");
						MoveClampers(num14, NoMove, drillPlaneNames.Back, list_2, list_3, ref Job);
					}
				}
			}
		}
		if (Index != 0)
		{
			if (FoundDrills[Index - 1].Items[0].planeName != planeBoxNames.Back)
			{
				buString5.AddStringsToList("M6T" + Option.Tool1, ref list_2, ClearList: true, "M16");
			}
			else if (FoundDrills[Index - 1].Items[0].Tool != drillCalcItem.Tool)
			{
				buString5.AddStringsToList("M6T" + Option.Tool1, ref list_2, ClearList: true, "M16");
			}
		}
		else
		{
			buString5.AddStringsToList("M85", ref list_2, ClearList: true, "M6T" + Option.Tool1, "M16", "G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"));
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			LastZ = clsDrill.varDrillCNCSettings.Z1SafeDistance;
			buString5.AddStringsToList("G0 X" + (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.XSafeDistance).ToString("f2") + " Y" + point3D.Y.ToString("f2"), ref list_2);
			num2 = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, y, NoMoveZ1, DrillMoveCommand.AxisMove, num4, Option, list_2, list_3, ref Job);
		}
		if (Index <= 0)
		{
			list_2.Add("G0 X" + (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.X1SafeDistance).ToString("f2") + " Y" + point3D.Y.ToString("f2"));
		}
		else if (FoundDrills[Index - 1].Items[0].planeName != planeBoxNames.Back)
		{
			list_2.Add("G0 X" + (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.X1SafeDistance).ToString("f2") + " Y" + point3D.Y.ToString("f2"));
		}
		else
		{
			list_2.Add("G0 X" + (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.X1SmallSafeDistance).ToString("f2") + " Y" + point3D.Y.ToString("f2"));
		}
		num2 = num5 - Job.Moves[Job.Moves.Count - 1].XPosition;
		AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, y, NoMoveZ1, DrillMoveCommand.AxisMove, num5, Option, list_2, list_3, ref Job);
		list_2.Clear();
		ToolSetAddList(Option, ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.SetPiston, NoMove, Option, list_2, list_3, ref Job);
		buString5.AddStringsToList("G0 Z" + point3D.Z.ToString("f2"), ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		num2 = num6 - Job.Moves[Job.Moves.Count - 1].XPosition;
		buString5.AddStringsToList("G1 X" + point3D.X.ToString("f2") + " F" + num9, ref list_2);
		AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, num6, Option, list_2, list_3, ref Job);
		if (num10 > 0.0)
		{
			buString5.AddStringsToList("G4 F" + num10.ToString("f1"), ref list_2, ClearList: false);
		}
		if (Index >= FoundDrills.Count - 1)
		{
			num2 = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
			buString5.AddStringsToList("G0 X" + (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.XSafeDistance).ToString("f2"), ref list_2);
			AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, num4, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("M85", ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX1, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		}
		else
		{
			bool flag = false;
			if (FoundDrills[Index + 1].Items[0].planeName != planeBoxNames.Back)
			{
				num2 = num4 - Job.Moves[Job.Moves.Count - 1].XPosition;
				buString5.AddStringsToList("G0 X" + (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.XSafeDistance).ToString("f2"), ref list_2);
				AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, num4, Option, list_2, list_3, ref Job);
				buString5.AddStringsToList("M85", ref list_2);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetPiston, NoMove, Option, list_2, list_3, ref Job);
				buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2);
				AddDrillMove(NoMoveX1, NoMoveX1, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			}
			else
			{
				buString5.AddStringsToList("G0 X" + (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.X1SmallSafeDistance).ToString("f2"), ref list_2);
				num2 = num5 - Job.Moves[Job.Moves.Count - 1].XPosition;
				AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num2, Job.Moves[Job.Moves.Count - 1].X2Clamper + num2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, num5, Option, list_2, list_3, ref Job);
				if (clsInit.cDrill.isToolsSameForNextOperation(Items, FoundDrills[Index + 1].Items))
				{
					flag = true;
				}
				if (flag)
				{
					buString5.AddStringsToList("M144", ref list_2);
					Option.OnlyCode = true;
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
					Option.OnlyCode = false;
				}
				else
				{
					buString5.AddStringsToList("M85", ref list_2);
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
				}
			}
		}
		DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
		drillMove.Command = DrillMoveCommand.GCodeList;
		drillMove.pntCenter = new Point3D();
		drillMove.CodeLines = new List<string>();
		drillMove.CodeLines.AddRange(list);
		if (list.Count > 0)
		{
			Job.Moves.Add(drillMove);
		}
		LastPlane = drillPlaneNames.Back;
	}

	public void CreateCodeForLeft(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
	{
		list_2.Clear();
		list_3.Clear();
		List<string> CodesSL = new List<string>();
		drillPlaneNames refPlane = drillPlaneNames.Left;
		DrillCalcItem drillCalcItem = null;
		Point3D point3D = new Point3D();
		DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Left, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
		double num = 0.0;
		double x = 0.0;
		double z = NoMoveZ1;
		double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		double num2 = double.MaxValue;
		double centerX = 0.0;
		double y = NoMoveY1;
		double y2 = NoMoveY1;
		double y3 = NoMoveY1;
		List<ToolBase5> list = new List<ToolBase5>();
		double num3 = clsDrill.varDrillCNCSettings.DrillPlungeFeed;
		double num4 = 0.0;
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			if ((drillCalcItem == null) & (Items[i].HeadNo == 1))
			{
				drillCalcItem = Items[i];
				z = drillCalcItem.Center.Z;
				centerX = drillCalcItem.Center.X;
				ToolBase5 foundTool = new ToolBase5();
				FindToolWithToolNo(drillCalcItem.Tool, ref foundTool);
				y = drillCalcItem.OffsetedPoint.Y - foundTool.Geometry.Length - clsDrill.varDrillCNCSettings.Y1SafeDistance;
				y3 = drillCalcItem.OffsetedPoint.Y - foundTool.Geometry.Length + drillCalcItem.Depth;
				y2 = drillCalcItem.OffsetedPoint.Y - foundTool.Geometry.Length - clsDrill.varDrillCNCSettings.Y1SmallSafeDistance;
				point3D.X = drillCalcItem.Center.X;
				point3D.Y = drillCalcItem.Depth;
				point3D.Z = drillCalcItem.Center.Z;
			}
			if (Items[i].HeadNo == 1)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option);
			}
			if (Items[i].Center.Y < num2)
			{
				num2 = Items[i].Center.Y;
			}
			if (Items[i].Tool <= 0)
			{
				calcErrorList.Add("No Defined Tool For This OP");
				continue;
			}
			ToolBase5 foundTool2 = new ToolBase5();
			if (FindToolWithToolNo(Items[i].Tool, ref foundTool2))
			{
				if (foundTool2.CamData.PlungeSpeed > 0.0)
				{
					num3 = foundTool2.CamData.PlungeSpeed;
					num4 = foundTool2.CamData.WaitTime;
				}
				list.Add(foundTool2);
			}
		}
		if (drillCalcItem != null)
		{
			num = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			x = drillCalcItem.OffsetedPoint.X;
		}
		if ((num2 < clsDrill.varDrillCNCSettings.ClamperCatchWidth + Items[0].Diameter / 2.0) & !Job.isSingleClamper)
		{
			CheckClampers(Index, num, centerX, Items[0], refPlane, list, ref Job, ref CodesSL);
		}
		if (Index != 0)
		{
			if (FoundDrills[Index - 1].Items[0].planeName != planeBoxNames.Left)
			{
				buString5.AddStringsToList("M6T" + Option.Tool1, ref list_2, ClearList: true, "M16");
			}
			else if (FoundDrills[Index - 1].Items[0].Tool != drillCalcItem.Tool)
			{
				buString5.AddStringsToList("M6T" + Option.Tool1, ref list_2, ClearList: true, "M16");
			}
		}
		else
		{
			buString5.AddStringsToList("M85", ref list_2, ClearList: true, "M6T" + Option.Tool1, "M16", "G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"));
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			LastZ = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		}
		if (Index <= 0)
		{
			list_2.Add("G0 X" + point3D.X.ToString("f2") + " Y" + (0.0 - clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2"));
		}
		else if (FoundDrills[Index - 1].Items[0].planeName != planeBoxNames.Left)
		{
			list_2.Add("G0 X" + point3D.X.ToString("f2") + " Y" + (0.0 - clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2"));
		}
		else
		{
			list_2.Add("G0 X" + point3D.X.ToString("f2") + " Y" + (0.0 - clsDrill.varDrillCNCSettings.Y1SmallSafeDistance).ToString("f2"));
		}
		AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, y2, NoMoveZ1, DrillMoveCommand.AxisMove, x, Option, list_2, list_3, ref Job);
		list_2.Clear();
		ToolSetAddList(Option, ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.SetPiston, NoMove, Option, list_2, list_3, ref Job);
		buString5.AddStringsToList("G0 Z" + point3D.Z.ToString("f2"), ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		buString5.AddStringsToList("G1 Y" + point3D.Y.ToString("f2") + " F" + num3, ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, y3, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		if (num4 > 0.0)
		{
			buString5.AddStringsToList("G4 F" + num4.ToString("f1"), ref list_2, ClearList: false);
		}
		if (Index >= FoundDrills.Count - 1)
		{
			buString5.AddStringsToList("G0 Y" + (0.0 - clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2"), ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX2, y, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("M85", ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX1, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		}
		else if (FoundDrills[Index + 1].Items[0].planeName != planeBoxNames.Left)
		{
			buString5.AddStringsToList("G0 Y" + (0.0 - clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2"), ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX2, y, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("M85", ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX1, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		}
		else
		{
			buString5.AddStringsToList("G0 Y" + (0.0 - clsDrill.varDrillCNCSettings.Y1SmallSafeDistance).ToString("f2"), ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX2, y, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("M85", ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX1, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		}
		LastPlane = drillPlaneNames.Left;
		DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
		drillMove.Command = DrillMoveCommand.GCodeList;
		drillMove.pntCenter = new Point3D();
		drillMove.CodeLines = new List<string>();
		drillMove.CodeLines.AddRange(CodesSL);
		if (CodesSL.Count > 0)
		{
			Job.Moves.Add(drillMove);
		}
	}

	public void CreateCodeForRight(ref DrillJob Job, List<DrillCalcItem> Items, int Index)
	{
		list_2.Clear();
		list_3.Clear();
		List<string> list = new List<string>();
		DrillCalcItem drillCalcItem = null;
		Point3D point3D = new Point3D();
		DrillMoveOptions Option = new DrillMoveOptions(drillPlaneNames.Right, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
		double num = 0.0;
		double x = 0.0;
		double z = NoMoveZ1;
		double z1SafeDistance = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		double num2 = double.MaxValue;
		double y = NoMoveY1;
		double y2 = NoMoveY1;
		double y3 = NoMoveY1;
		List<ToolBase5> list2 = new List<ToolBase5>();
		double num3 = clsDrill.varDrillCNCSettings.DrillPlungeFeed;
		double num4 = 0.0;
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			if ((drillCalcItem == null) & (Items[i].HeadNo == 1))
			{
				drillCalcItem = Items[i];
				z = drillCalcItem.Center.Z;
				ToolBase5 foundTool = new ToolBase5();
				FindToolWithToolNo(drillCalcItem.Tool, ref foundTool);
				y = drillCalcItem.OffsetedPoint.Y + foundTool.Geometry.Length + clsDrill.varDrillCNCSettings.Y1SafeDistance;
				y2 = drillCalcItem.OffsetedPoint.Y + foundTool.Geometry.Length + clsDrill.varDrillCNCSettings.Y1SmallSafeDistance;
				y3 = drillCalcItem.OffsetedPoint.Y + foundTool.Geometry.Length - drillCalcItem.Depth;
				point3D.X = drillCalcItem.Center.X;
				point3D.Y = Job.Material.Size.Height - drillCalcItem.Depth;
				point3D.Z = drillCalcItem.Center.Z;
			}
			if (Items[i].HeadNo == 1)
			{
				SetValueToAvailableTool(Items[i].Tool, ref Option);
			}
			if (Items[i].Center.Y < num2)
			{
				num2 = Items[i].Center.Y;
			}
			if (Items[i].Tool <= 0)
			{
				calcErrorList.Add("No Defined Tool For This OP");
				continue;
			}
			ToolBase5 foundTool2 = new ToolBase5();
			if (FindToolWithToolNo(Items[i].Tool, ref foundTool2))
			{
				if (foundTool2.CamData.PlungeSpeed > 0.0)
				{
					num3 = foundTool2.CamData.PlungeSpeed;
					num4 = foundTool2.CamData.WaitTime;
				}
				list2.Add(foundTool2);
			}
		}
		if (drillCalcItem != null)
		{
			num = drillCalcItem.OffsetedPoint.X - Job.Moves[Job.Moves.Count - 1].XPosition;
			x = drillCalcItem.OffsetedPoint.X;
		}
		if (Index != 0)
		{
			if (FoundDrills[Index - 1].Items[0].planeName != planeBoxNames.Right)
			{
				buString5.AddStringsToList("M6T" + Option.Tool1, ref list_2, ClearList: true, "M16");
			}
			else if (FoundDrills[Index - 1].Items[0].Tool != drillCalcItem.Tool)
			{
				buString5.AddStringsToList("M6T" + Option.Tool1, ref list_2, ClearList: true, "M16");
			}
		}
		else
		{
			buString5.AddStringsToList("M85", ref list_2, ClearList: true, "M6T" + Option.Tool1, "M16", "G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"));
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			LastZ = clsDrill.varDrillCNCSettings.Z1SafeDistance;
		}
		if (Index <= 0)
		{
			list_2.Add("G0 X" + point3D.X.ToString("f2") + " Y" + (Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2"));
		}
		else if (FoundDrills[Index - 1].Items[0].planeName != planeBoxNames.Right)
		{
			list_2.Add("G0 X" + point3D.X.ToString("f2") + " Y" + (Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2"));
		}
		else
		{
			list_2.Add("G0 X" + point3D.X.ToString("f2") + " Y" + (Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SmallSafeDistance).ToString("f2"));
		}
		AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num, Job.Moves[Job.Moves.Count - 1].X2Clamper + num, y2, NoMoveZ1, DrillMoveCommand.AxisMove, x, Option, list_2, list_3, ref Job);
		list_2.Clear();
		ToolSetAddList(Option, ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.SetPiston, NoMove, Option, list_2, list_3, ref Job);
		buString5.AddStringsToList("G0 Z" + point3D.Z.ToString("f2"), ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, z, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		buString5.AddStringsToList("G1 Y" + point3D.Y.ToString("f2") + " F" + num3, ref list_2);
		AddDrillMove(NoMoveX1, NoMoveX2, y3, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		if (num4 > 0.0)
		{
			buString5.AddStringsToList("G4 F" + num4.ToString("f1"), ref list_2, ClearList: false);
		}
		if (Index >= FoundDrills.Count - 1)
		{
			buString5.AddStringsToList("G0 Y" + (Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2"), ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX2, y, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("M85", ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
			buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2);
			AddDrillMove(NoMoveX1, NoMoveX1, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
		}
		else
		{
			bool flag = false;
			if (FoundDrills[Index + 1].Items[0].planeName != planeBoxNames.Right)
			{
				buString5.AddStringsToList("G0 Y" + (Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SafeDistance).ToString("f2"), ref list_2);
				AddDrillMove(NoMoveX1, NoMoveX2, y, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
				buString5.AddStringsToList("M85", ref list_2);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
				buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.Z1SafeDistance.ToString("f2"), ref list_2);
				AddDrillMove(NoMoveX1, NoMoveX1, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
			}
			else
			{
				buString5.AddStringsToList("G0 Y" + (Job.Material.Size.Height + clsDrill.varDrillCNCSettings.Y1SmallSafeDistance).ToString("f2"), ref list_2);
				AddDrillMove(NoMoveX1, NoMoveX2, y2, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, Option, list_2, list_3, ref Job);
				if (clsInit.cDrill.isToolsSameForNextOperation(Items, FoundDrills[Index + 1].Items))
				{
					flag = true;
				}
				if (flag)
				{
					buString5.AddStringsToList("M144", ref list_2);
					Option.OnlyCode = true;
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
					Option.OnlyCode = false;
				}
				else
				{
					buString5.AddStringsToList("M85", ref list_2);
					AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, Option, list_2, list_3, ref Job);
				}
			}
		}
		DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
		drillMove.Command = DrillMoveCommand.GCodeList;
		drillMove.pntCenter = new Point3D();
		drillMove.CodeLines = new List<string>();
		drillMove.CodeLines.AddRange(list);
		if (list.Count > 0)
		{
			Job.Moves.Add(drillMove);
		}
		LastPlane = drillPlaneNames.Right;
	}

	public void CheckClampers(int Index, double dX, double CenterX, DrillCalcItem Item, drillPlaneNames refPlane, List<ToolBase5> FoundTools, ref DrillJob Job, ref List<string> CodesSL)
	{
		list_2.Clear();
		list_3.Clear();
		ClamperInsideCalc clamperInsideCalc = new ClamperInsideCalc();
		ClamperInsideCalc clamperInsideCalc2 = new ClamperInsideCalc();
		DrillMoveOptions options = new DrillMoveOptions(refPlane, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
		string text = Item.planeName.ToString() + " - " + Item.Diameter.ToString("f1") + " - " + Item.Center.ToString();
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		bool flag = false;
		bool flag2 = false;
		num3 = ((Job.Material.Size.Width <= clsDrill.varDrillCNCSettings.MaterialSmallLimit) ? Math.Round(clsDrill.varDrillCNCSettings.ClamperLength * clsDrill.varDrillCNCSettings.ClamperSmallMaterialCLampMinLengthPersc / 100.0, 3) : (((clsDrill.varDrillCNCSettings.MaterialSmallLimit < Job.Material.Size.Width) & (Job.Material.Size.Width <= clsDrill.varDrillCNCSettings.MaterialMediumLimit)) ? Math.Round(clsDrill.varDrillCNCSettings.ClamperLength * clsDrill.varDrillCNCSettings.ClamperMediumMaterialCLampMinLengthPersc / 100.0, 3) : Math.Round(clsDrill.varDrillCNCSettings.ClamperLength * clsDrill.varDrillCNCSettings.ClamperBigMaterialCLampMinLengthPersc / 100.0, 3)));
		if (Index < FoundDrills.Count - 1)
		{
			for (int i = Index + 1; i <= FoundDrills.Count - 1; i++)
			{
				for (int j = 0; j <= FoundDrills[i].Items.Count - 1; j++)
				{
					if (FoundDrills[i].Items[j].Center.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + FoundDrills[i].Items[j].Diameter / 2.0)
					{
						double num4 = FoundDrills[i].Items[j].Center.X - CenterX;
						if (num4 < clsDrill.varDrillCNCSettings.ClamperNextLookOperationDistance && ((FoundDrills[i].Items[j].planeName == planeBoxNames.Top) | (FoundDrills[i].Items[j].planeName == planeBoxNames.Left)) && num4 > num2)
						{
							num2 = num4 + 10.0;
						}
					}
				}
			}
		}
		clamperInsideCalc2.DrillInClamper = isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance, ref clamperInsideCalc2.minXClamper, ref clamperInsideCalc2.maxXClamper);
		clamperInsideCalc.DrillInClamper = isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance, ref clamperInsideCalc.minXClamper, ref clamperInsideCalc.maxXClamper);
		clamperInsideCalc.XMovePlus = Job.Moves[Job.Moves.Count - 1].X1Clamper + clamperInsideCalc.minXClamper + num2;
		clamperInsideCalc.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.maxXClamper - num2;
		clamperInsideCalc2.XMovePlus = Job.Moves[Job.Moves.Count - 1].X2Clamper + clamperInsideCalc2.minXClamper + num2;
		clamperInsideCalc2.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.maxXClamper - num2;
		clamperInsideCalc2.DrillInClamperLassSafe = isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance / 2.0, ref clamperInsideCalc2.minXClamperLessSafe, ref clamperInsideCalc2.maxXClamperLessSafe);
		clamperInsideCalc.DrillInClamperLassSafe = isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance / 2.0, ref clamperInsideCalc.minXClamperLessSafe, ref clamperInsideCalc.maxXClamperLessSafe);
		clamperInsideCalc.XMovePlusLessSafe = Job.Moves[Job.Moves.Count - 1].X1Clamper + clamperInsideCalc.minXClamperLessSafe;
		clamperInsideCalc.XMoveMinusLessSafe = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.maxXClamperLessSafe;
		clamperInsideCalc2.XMovePlusLessSafe = Job.Moves[Job.Moves.Count - 1].X2Clamper + clamperInsideCalc2.minXClamperLessSafe;
		clamperInsideCalc2.XMoveMinusLessSafe = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.maxXClamperLessSafe;
		double num5 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
		double num6 = clamperInsideCalc.XMoveMinus + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num5;
		if (num6 < num3)
		{
			flag = true;
		}
		if (num2 != 0.0 && flag)
		{
			flag = false;
			clamperInsideCalc.XMovePlus = Job.Moves[Job.Moves.Count - 1].X1Clamper + clamperInsideCalc.minXClamper;
			clamperInsideCalc.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.maxXClamper;
			num5 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
			num6 = clamperInsideCalc.XMoveMinus + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num5;
			if (num6 < num3)
			{
				flag = true;
			}
		}
		double num7 = Job.Moves[Job.Moves.Count - 1].XPosition - (clamperInsideCalc2.XMovePlus - clsDrill.varDrillCNCSettings.ClamperLength / 2.0);
		if (num7 < num3)
		{
			flag2 = true;
		}
		if (num2 != 0.0 && flag2)
		{
			flag2 = false;
			clamperInsideCalc2.XMovePlus = Job.Moves[Job.Moves.Count - 1].X2Clamper + clamperInsideCalc2.minXClamper;
			clamperInsideCalc2.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.maxXClamper;
			num7 = Job.Moves[Job.Moves.Count - 1].XPosition - (clamperInsideCalc2.XMovePlus - clsDrill.varDrillCNCSettings.ClamperLength / 2.0);
			if (num7 < num3)
			{
				flag2 = true;
			}
		}
		if (clamperInsideCalc2.DrillInClamper)
		{
			list_2.Clear();
			list_2.Add("M85");
			if (!isLastPositionLastZ(Job))
			{
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, options, list_2, list_3, ref Job);
				list_2.Clear();
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, options, list_2, list_3, ref Job);
			}
			double num8 = 0.0;
			if (!flag2)
			{
				bool flag3 = false;
				num8 = clamperInsideCalc2.XMovePlus - Job.Moves[Job.Moves.Count - 1].X1Clamper;
				if (!(num8 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance))
				{
					num = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMovePlus;
					list_2.Clear();
					list_2.Add("R910=0");
					list_2.Add("R900=" + num.ToString("f1"));
					list_2.Add("L CARPB.ISC");
					MoveClampers(NoMove, clamperInsideCalc2.XMovePlus, refPlane, list_2, list_3, ref Job);
					flag3 = true;
				}
				else
				{
					double num9 = clamperInsideCalc2.XMoveMinus - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					double num10 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
					double num11 = num9 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num10;
					if (!(num11 > num3))
					{
						num9 = clamperInsideCalc2.XMoveMinusLessSafe - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
						num10 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
						num11 = num9 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num10;
						if (num11 > num3)
						{
							num = Job.Moves[Job.Moves.Count - 1].X1Clamper - num9;
							list_2.Clear();
							list_2.Add("R910=0");
							list_2.Add("R901=" + num.ToString("f1"));
							list_2.Add("L CARPA.ISC");
							MoveClampers(num9, NoMove, refPlane, list_2, list_3, ref Job);
							num = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinusLessSafe;
							list_2.Clear();
							list_2.Add("R910=0");
							list_2.Add("R900=" + num.ToString("f1"));
							list_2.Add("L CARPB.ISC");
							MoveClampers(NoMove, clamperInsideCalc2.XMoveMinusLessSafe, refPlane, list_2, list_3, ref Job);
							flag3 = true;
							Job.isLesSafe = true;
						}
					}
					else
					{
						num = Job.Moves[Job.Moves.Count - 1].X1Clamper - num9;
						list_2.Clear();
						list_2.Add("R910=0");
						list_2.Add("R901=" + num.ToString("f1"));
						list_2.Add("L CARPA.ISC");
						MoveClampers(num9, NoMove, refPlane, ref Job);
						num = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinus;
						list_2.Clear();
						list_2.Add("R910=0");
						list_2.Add("R900=" + num.ToString("f1"));
						list_2.Add("L CARPB.ISC");
						MoveClampers(NoMove, clamperInsideCalc2.XMoveMinus, refPlane, list_2, list_3, ref Job);
						flag3 = true;
					}
				}
				if (!flag3)
				{
					num = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinus;
					list_2.Clear();
					list_2.Add("R910=0");
					list_2.Add("R900=" + num.ToString("f1"));
					list_2.Add("L CARPB.ISC");
					MoveClampers(NoMove, clamperInsideCalc2.XMoveMinus, refPlane, list_2, list_3, ref Job);
				}
			}
			else
			{
				num8 = clamperInsideCalc2.XMoveMinus - Job.Moves[Job.Moves.Count - 1].X1Clamper;
				if (!(num8 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance))
				{
					num = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinus;
					list_2.Clear();
					list_2.Add("R910=0");
					list_2.Add("R900=" + num.ToString("f1"));
					list_2.Add("L CARPB.ISC");
					MoveClampers(NoMove, clamperInsideCalc2.XMoveMinus, refPlane, list_2, list_3, ref Job);
				}
				else
				{
					double num12 = clamperInsideCalc2.XMoveMinus - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					double num13 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
					double num14 = num12 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num13;
					if (!(num14 > num3))
					{
						num12 = clamperInsideCalc2.XMoveMinusLessSafe - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
						num13 = Job.Moves[Job.Moves.Count - 1].XPosition - Job.Material.Size.Width;
						num14 = num12 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - num13;
						if (!(num14 > num3))
						{
							calcErrorList.Add(buDrillCalc.LangDrillMessage[25] + " - " + text);
						}
						else
						{
							num = Job.Moves[Job.Moves.Count - 1].X1Clamper - num12;
							list_2.Clear();
							list_2.Add("R910=0");
							list_2.Add("R901=" + num.ToString("f1"));
							list_2.Add("L CARPA.ISC");
							MoveClampers(num12, NoMove, refPlane, list_2, list_3, ref Job);
							num = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinusLessSafe;
							list_2.Clear();
							list_2.Add("R910=0");
							list_2.Add("R900=" + num.ToString("f1"));
							list_2.Add("L CARPB.ISC");
							MoveClampers(NoMove, clamperInsideCalc2.XMoveMinusLessSafe, refPlane, list_2, list_3, ref Job);
							Job.isLesSafe = true;
						}
					}
					else
					{
						num = Job.Moves[Job.Moves.Count - 1].X1Clamper - num12;
						list_2.Clear();
						list_2.Add("R910=0");
						list_2.Add("R901=" + num.ToString("f1"));
						list_2.Add("L CARPA.ISC");
						MoveClampers(num12, NoMove, refPlane, list_2, list_3, ref Job);
						num = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.XMoveMinus;
						list_2.Clear();
						list_2.Add("R910=0");
						list_2.Add("R900=" + num.ToString("f1"));
						list_2.Add("L CARPB.ISC");
						MoveClampers(NoMove, clamperInsideCalc2.XMoveMinus, refPlane, list_2, list_3, ref Job);
					}
				}
			}
		}
		if (clamperInsideCalc.DrillInClamper & clamperInsideCalc2.DrillInClamper)
		{
			clamperInsideCalc2.DrillInClamper = isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance, ref clamperInsideCalc2.minXClamper, ref clamperInsideCalc2.maxXClamper);
			clamperInsideCalc.DrillInClamper = isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance, ref clamperInsideCalc.minXClamper, ref clamperInsideCalc.maxXClamper);
			clamperInsideCalc.XMovePlus = Job.Moves[Job.Moves.Count - 1].X1Clamper + clamperInsideCalc.minXClamper + num2;
			clamperInsideCalc.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.maxXClamper - num2;
			clamperInsideCalc2.XMovePlus = Job.Moves[Job.Moves.Count - 1].X2Clamper + clamperInsideCalc2.minXClamper + num2;
			clamperInsideCalc2.XMoveMinus = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.maxXClamper - num2;
			clamperInsideCalc2.DrillInClamperLassSafe = isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X2Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance / 2.0, ref clamperInsideCalc2.minXClamperLessSafe, ref clamperInsideCalc2.maxXClamperLessSafe);
			clamperInsideCalc.DrillInClamperLassSafe = isDrillInsideClamper(Job.Moves[Job.Moves.Count - 1].X1Clamper + dX, FoundTools, clsDrill.varDrillCNCSettings.ClamperOperationMinDistance / 2.0, ref clamperInsideCalc.minXClamperLessSafe, ref clamperInsideCalc.maxXClamperLessSafe);
			clamperInsideCalc.XMovePlusLessSafe = Job.Moves[Job.Moves.Count - 1].X1Clamper + clamperInsideCalc.minXClamperLessSafe;
			clamperInsideCalc.XMoveMinusLessSafe = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.maxXClamperLessSafe;
			clamperInsideCalc2.XMovePlusLessSafe = Job.Moves[Job.Moves.Count - 1].X2Clamper + clamperInsideCalc2.minXClamperLessSafe;
			clamperInsideCalc2.XMoveMinusLessSafe = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc2.maxXClamperLessSafe;
		}
		if (clamperInsideCalc.DrillInClamper)
		{
			list_2.Clear();
			list_2.Add("M85");
			if (!isLastPositionLastZ(Job))
			{
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.Z1SafeDistance, DrillMoveCommand.AxisMove, NoMove, options, list_2, list_3, ref Job);
				list_2.Clear();
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, options, list_2, list_3, ref Job);
			}
			double num15 = 0.0;
			if (!flag)
			{
				bool flag4 = false;
				num15 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc.XMovePlus;
				if (!(num15 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance))
				{
					num = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.XMovePlus;
					list_2.Clear();
					list_2.Add("R910=0");
					list_2.Add("R901=" + num.ToString("f1"));
					list_2.Add("L CARPA.ISC");
					MoveClampers(clamperInsideCalc.XMovePlus, NoMoveX2, refPlane, list_2, list_3, ref Job);
					flag4 = true;
				}
				else
				{
					double num16 = 0.0;
					double num17 = clamperInsideCalc.XMovePlus + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					double num18 = Job.Moves[Job.Moves.Count - 1].XPosition - (num17 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0);
					if (!(num18 >= num3))
					{
						num16 = 0.0;
						num17 = clamperInsideCalc.XMovePlusLessSafe + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
						num18 = Job.Moves[Job.Moves.Count - 1].XPosition - (num17 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0);
						if (num18 >= num3)
						{
							num16 = clamperInsideCalc.XMovePlusLessSafe + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
							num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num16;
							list_2.Clear();
							list_2.Add("R910=0");
							list_2.Add("R900=" + num.ToString("f1"));
							list_2.Add("L CARPB.ISC");
							MoveClampers(NoMoveX1, num16, refPlane, list_2, list_3, ref Job);
							num = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.XMovePlusLessSafe;
							list_2.Clear();
							list_2.Add("R910=0");
							list_2.Add("R901=" + num.ToString("f1"));
							list_2.Add("L CARPA.ISC");
							MoveClampers(clamperInsideCalc.XMovePlusLessSafe, NoMoveX2, refPlane, list_2, list_3, ref Job);
							flag4 = true;
							Job.isLesSafe = true;
						}
					}
					else
					{
						num16 = clamperInsideCalc.XMovePlus + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
						num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num16;
						list_2.Clear();
						list_2.Add("R910=0");
						list_2.Add("R900=" + num.ToString("f1"));
						list_2.Add("L CARPB.ISC");
						MoveClampers(NoMoveX1, num16, refPlane, list_2, list_3, ref Job);
						num = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.XMovePlus;
						list_2.Clear();
						list_2.Add("R910=0");
						list_2.Add("R901=" + num.ToString("f1"));
						list_2.Add("L CARPA.ISC");
						MoveClampers(clamperInsideCalc.XMovePlus, NoMoveX2, refPlane, list_2, list_3, ref Job);
						flag4 = true;
					}
				}
				if (!flag4)
				{
					num = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.XMoveMinus;
					list_2.Clear();
					list_2.Add("R910=0");
					list_2.Add("R901=" + num.ToString("f1"));
					list_2.Add("L CARPA.ISC");
					MoveClampers(clamperInsideCalc.XMoveMinus, NoMoveX2, refPlane, list_2, list_3, ref Job);
				}
			}
			else
			{
				num15 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clamperInsideCalc.XMovePlus;
				if (!(num15 <= clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance))
				{
					num = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.XMovePlus;
					list_2.Clear();
					list_2.Add("R910=0");
					list_2.Add("R901=" + num.ToString("f1"));
					list_2.Add("L CARPA.ISC");
					MoveClampers(clamperInsideCalc.XMovePlus, NoMoveX2, refPlane, list_2, list_3, ref Job);
				}
				else
				{
					double num19 = 0.0;
					double num20 = clamperInsideCalc.XMovePlus + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
					double num21 = Job.Moves[Job.Moves.Count - 1].XPosition - (num20 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0);
					if (!(num21 >= num3))
					{
						num20 = clamperInsideCalc.XMovePlusLessSafe + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
						num21 = Job.Moves[Job.Moves.Count - 1].XPosition - (num20 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0);
						if (!(num21 >= num3 * 0.5))
						{
							calcErrorList.Add(buDrillCalc.LangDrillMessage[25] + " - " + text);
						}
						else
						{
							num19 = clamperInsideCalc.XMovePlusLessSafe + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0;
							num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num19;
							list_2.Clear();
							list_2.Add("R910=0");
							list_2.Add("R900=" + num.ToString("f1"));
							list_2.Add("L CARPB.ISC");
							MoveClampers(NoMoveX1, num19, refPlane, list_2, list_3, ref Job);
							num = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.XMovePlusLessSafe;
							list_2.Clear();
							list_2.Add("R910=0");
							list_2.Add("R901=" + num.ToString("f1"));
							list_2.Add("L CARPA.ISC");
							MoveClampers(clamperInsideCalc.XMovePlusLessSafe, NoMoveX2, refPlane, list_2, list_3, ref Job);
							Job.isLesSafe = true;
						}
					}
					else
					{
						num19 = clamperInsideCalc.XMovePlus + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
						num = Job.Moves[Job.Moves.Count - 1].X2Clamper - num19;
						list_2.Clear();
						list_2.Add("R910=0");
						list_2.Add("R900=" + num.ToString("f1"));
						list_2.Add("L CARPB.ISC");
						MoveClampers(NoMoveX1, num19, refPlane, list_2, list_3, ref Job);
						num = Job.Moves[Job.Moves.Count - 1].X1Clamper - clamperInsideCalc.XMovePlus;
						list_2.Clear();
						list_2.Add("R910=0");
						list_2.Add("R901=" + num.ToString("f1"));
						list_2.Add("L CARPA.ISC");
						MoveClampers(clamperInsideCalc.XMovePlus, NoMoveX2, refPlane, list_2, list_3, ref Job);
					}
				}
			}
		}
		if (Job.Moves[Job.Moves.Count - 1].X2Clamper - Job.Moves[Job.Moves.Count - 1].X1Clamper < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance / 2.0)
		{
			calcErrorList.Add(buDrillCalc.LangDrillMessage[63] + " - " + text);
		}
	}

	public bool isLastPositionLastZ(DrillJob Job)
	{
		if (Job.Moves.Count <= 0)
		{
			return false;
		}
		if (Job.Moves[Job.Moves.Count - 1].Z1Position != clsDrill.varDrillCNCSettings.Z1SafeDistance)
		{
			return false;
		}
		return true;
	}

	public void CreateCodeForSlotTopSide(ref DrillJob Job, ref List<DrillCalcItem> ItemSlot)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		list_2.Clear();
		list_3.Clear();
		Point3D point3D = new Point3D();
		DrillMoveOptions drillMoveOptions = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast);
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		for (int i = 0; i <= ItemSlot.Count - 1; i++)
		{
			if (!(ItemSlot[i].Center.X + ItemSlot[i].Length > Job.Material.Size.Width * 1.2))
			{
				if (!((ItemSlot[i].Corner == CornerLocation.RightBottom) | (ItemSlot[i].Corner == CornerLocation.RightCenter) | (ItemSlot[i].Corner == CornerLocation.RightTop)))
				{
					list.Add(new DrillCalcItem(ItemSlot[i]));
					continue;
				}
				DrillCalcItem item = new DrillCalcItem(ItemSlot[i]);
				list.Add(item);
			}
			else
			{
				DrillCalcItem drillCalcItem = new DrillCalcItem(ItemSlot[i]);
				drillCalcItem.Center.X = drillCalcItem.Center.X - drillCalcItem.Length;
				list.Add(drillCalcItem);
			}
		}
		for (int j = 0; j <= clsDrill.ToolList.Count - 1; j++)
		{
			clsDrill.ToolList[j].Data.Used = false;
		}
		if (list.Count == 0)
		{
			return;
		}
		if (!((list[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperCatchWidth) & (Job.Material.Size.Width < 400.0)))
		{
			List<string> list2 = new List<string>();
			if (!(list[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperSlotCatchWidth))
			{
				list = SortByYDistance(list, new DrillCalcItem(), SortDirection.LowerToBigger);
				List<DrillCalcItem> list3 = new List<DrillCalcItem>();
				for (int k = 0; k <= list.Count - 1; k++)
				{
					list3.Add(new DrillCalcItem(list[k]));
				}
				int count = list3.Count;
				int num4 = 0;
				while (true)
				{
					if (num4 <= count - 1)
					{
						bool flag = true;
						double num5 = 0.0;
						FindToolSettings findToolSettings = new FindToolSettings();
						findToolSettings.Plane = planeBoxNames.Top;
						findToolSettings.SetAsUsed = true;
						for (int l = 0; l <= clsDrill.ToolList.Count - 1; l++)
						{
							clsDrill.ToolList[l].Data.Used = false;
						}
						int t = 0;
						int t2 = 0;
						ToolBase5 foundTool = null;
						num = NoMove;
						num2 = NoMove;
						if (!((num4 <= list3.Count - 1) & (list3.Count > 0)))
						{
							flag = false;
						}
						else if (!(!list3[num4].Calculated & !list3[num4].UseMilling))
						{
							if (!list3[num4].UseMilling)
							{
								flag = false;
							}
							else
							{
								num = list3[num4].Center.Y;
								num2 = list3[num4].Center.Z;
								_ = list3[num4].Center.X;
								_ = list3[num4].Center.X;
								num5 = list3[num4].Depth;
								list3[num4].Calculated = true;
								for (int m = 0; m <= ccVars.Tools[0].Tools.Count - 1; m++)
								{
									if (ccVars.Tools[0].Tools[m].Data.No == list3[num4].Tool)
									{
										foundTool = new ToolBase5(ccVars.Tools[0].Tools[m]);
									}
								}
								t = list3[num4].Tool;
							}
						}
						else
						{
							FindToolFromBlock(list3[num4], 0, findToolSettings, ref foundTool);
							if (foundTool != null)
							{
								num = list3[num4].Center.Y + foundTool.Positions.CommonOffset.Y;
								num2 = list3[num4].Center.Z;
								_ = list3[num4].Center.X;
								_ = list3[num4].Center.X;
								num5 = list3[num4].Depth;
								list3[num4].Calculated = true;
								t = foundTool.Data.No;
							}
						}
						if (num2 == NoMove && num2 != num3)
						{
							num2 = clsDrill.varDrillCNCSettings.SlotSawSafeDistance;
						}
						if (num2 == num3)
						{
							num2 = NoMove;
						}
						if (foundTool == null)
						{
							break;
						}
						if (flag)
						{
							double XOffset = 0.0;
							double YOffset = 0.0;
							if (foundTool != null)
							{
								new ToolBase5(foundTool);
								if (list[0].UseMilling)
								{
									XOffset = foundTool.Positions.CommonOffset.X;
									YOffset = foundTool.Positions.CommonOffset.Y;
								}
								else
								{
									GetXYToolOffsetFromNo(foundTool.Data.No, ref XOffset, ref YOffset);
								}
							}
							point3D.X = list[0].Center.X;
							point3D.Y = list[0].Center.Y;
							point3D.Z = Job.Material.Size.Depth - list[0].Depth;
							drillMoveOptions.Tool1 = foundTool.Data.No;
							drillMoveOptions.Mode = DrillCNCMode.ToolOffset;
							if (list[0].UseMilling)
							{
								buString5.AddStringsToList("M85", ref list_2, ClearList: true, "M40", "M6 T" + foundTool.Data.No, "$M39", "M3 S" + foundTool.CamData.SpindleSpeed, "M149", "G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
							}
							else
							{
								buString5.AddStringsToList("M85", ref list_2, ClearList: true, "M40", "M6 T" + foundTool.Data.No, "M16", "G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
							}
							drillMoveOptions.Mode = DrillCNCMode.Safe;
							drillMoveOptions.EnableAxes = new AxesEnable(x: false, y: false, z: true);
							AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.SlotSawSafeDistance, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, list_2, list_3, ref Job);
							double num6 = 0.0;
							double num7 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X;
							if (clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
							{
								num7 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + list[0].Length;
							}
							double num8 = num7 - Job.Moves[Job.Moves.Count - 1].XPosition;
							double num9 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num8;
							double num10 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num8;
							if (!(num9 < clsDrill.varDrillMachineSettings.MachineMinXStroke))
							{
								list_2.Clear();
								if (clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
								{
									list_2.Add("G0 X" + (list[0].Center.X + list[0].Length).ToString("f2") + " Y" + list[0].Center.Y.ToString("f2"));
									if (list[0].UseMilling)
									{
										list_2.Add("M1091");
									}
								}
								else
								{
									list_2.Add("G0 X" + list[0].Center.X.ToString("f2") + " Y" + list[0].Center.Y.ToString("f2"));
									if (list[0].UseMilling)
									{
										list_2.Add("M1091");
									}
								}
								drillMoveOptions.Mode = DrillCNCMode.Safe;
								drillMoveOptions.EnableAxes = new AxesEnable(x: true, y: true, z: false);
								AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num8, Job.Moves[Job.Moves.Count - 1].X2Clamper + num8, num, NoMoveZ1, DrillMoveCommand.AxisMove, num7, drillMoveOptions, list_2, list_3, ref Job);
							}
							else
							{
								list_2.Clear();
								list_2.Add("G0 Y" + list[0].Center.Y.ToString("f2"));
								AddDrillMove(NoMove, NoMove, num, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, t, t2), list_2, list_3, ref Job);
								double num11 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillMachineSettings.MachineMinXStroke;
								double x = num7 + Math.Abs(num8) - num11;
								num8 += num11;
								list_2.Clear();
								list_2.Add("G0 X" + Math.Abs(num8).ToString("f2"));
								if (list[0].UseMilling)
								{
									list_2.Add("M1091");
								}
								AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - num11, Job.Moves[Job.Moves.Count - 1].X2Clamper - num11, NoMove, NoMove, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), list_2, list_3, ref Job);
								num9 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num8;
								num10 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num8;
								double num12 = num9 - clsDrill.varDrillMachineSettings.MachineMinXStroke;
								double num13 = num9 - num12;
								double num14 = num10 - num12;
								AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
								num6 = 0.0 - (num14 - num12 - Job.Moves[Job.Moves.Count - 1].X2Clamper);
								buString5.AddStringsToList("R910=0", ref list_2, ClearList: true, "R900=" + num6.ToString("f2"), "L CARPB.ISC");
								AddDrillMove(NoMove, num14 - num12, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), list_2, list_3, ref Job);
								AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
								AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
								num6 = 0.0 - (num13 - num12 - Job.Moves[Job.Moves.Count - 1].X1Clamper);
								buString5.AddStringsToList("R910=0", ref list_2, ClearList: true, "R901=" + num6.ToString("f2"), "L CARPA.ISC", "G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
								AddDrillMove(num13 - num12, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), list_2, list_3, ref Job);
								AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
								list_2.Clear();
								list_2.Add("G0 X" + list[0].Center.X.ToString("f2") + " Y" + list[0].Center.Y.ToString("f2"));
								AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num8, Job.Moves[Job.Moves.Count - 1].X2Clamper + num8, NoMove, NoMove, DrillMoveCommand.AxisMove, num7, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), list_2, list_3, ref Job);
							}
							double noMove = NoMove;
							if (flag & (num2 != NoMove))
							{
								noMove = num2 + clsDrill.varDrillCNCSettings.SlotSawRapidDistance;
							}
							drillMoveOptions.Mode = DrillCNCMode.ToolSet;
							if (!list[0].UseMilling)
							{
								buString5.AddStringsToList("M" + foundTool.Data.No, ref list_2);
								AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.SetPiston, NoMove, drillMoveOptions, list_2, list_3, ref Job);
							}
							buString5.AddStringsToList("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"), ref list_2);
							drillMoveOptions.Mode = DrillCNCMode.Safe;
							drillMoveOptions.EnableAxes = new AxesEnable(x: false, y: false, z: true);
							AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.SlotSawRapidDistance, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, list_2, list_3, ref Job);
							buString5.AddStringsToList("G1 Z" + (Job.Material.Size.Depth - list[0].Depth).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed, ref list_2);
							drillMoveOptions.Mode = DrillCNCMode.Safe;
							drillMoveOptions.EnableAxes = new AxesEnable(x: false, y: false, z: true);
							AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, point3D.Z, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, list_2, list_3, ref Job);
							if (flag)
							{
								int Index = -1;
								GetIndexFromItemID(list3[num4].ID, list, ref Index);
								if (Index >= 0)
								{
									list[Index].OffsetedPoint.X = num7;
								}
							}
							noMove = NoMove;
							if (flag & (num2 != NoMove))
							{
								noMove = num2 - num5;
							}
							num7 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + list[0].Length;
							if (clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
							{
								num7 = XOffset + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X;
							}
							num8 = num7 - Job.Moves[Job.Moves.Count - 1].XPosition;
							num9 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num8;
							num10 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num8;
							double num15 = clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + XOffset;
							if (!(num10 > clsDrill.varDrillMachineSettings.MachineMaxXStroke - clsDrill.varDrillMachineSettings.MillingHolderOffset))
							{
								drillMoveOptions.Mode = DrillCNCMode.Plunge;
								drillMoveOptions.EnableAxes = new AxesEnable(x: true, y: false, z: false);
								drillMoveOptions.isG0 = false;
								drillMoveOptions.Feed = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
								list_2.Clear();
								if (clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
								{
									list_2.Add("G1 X" + list[0].Center.X.ToString("f2") + " Y" + list[0].Center.Y.ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
								}
								else
								{
									list_2.Add("G1 X" + (list[0].Center.X + list[0].Length).ToString("f2") + " Y" + list[0].Center.Y.ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
								}
								AddDrillMove(num9, num10, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, num7, drillMoveOptions, list_2, list_3, ref Job);
							}
							else
							{
								double num16 = num10 - clsDrill.varDrillMachineSettings.MachineMaxXStroke + clsDrill.varDrillMachineSettings.MillingHolderOffset;
								double num17 = num9 - num16;
								double num18 = num10 - num16;
								double num19 = num7 - num16;
								buString5.AddStringsToList("G1 X" + (num19 - num15).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed, ref list_2);
								AddDrillMove(num17, num18, NoMove, NoMove, DrillMoveCommand.AxisMove, num19, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), list_2, list_3, ref Job);
								AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
								num6 = Job.Moves[Job.Moves.Count - 1].X1Clamper - (num17 - num16);
								buString5.AddStringsToList("R910=0", ref list_2, ClearList: true, "R901=" + num6.ToString("f2"), "L CARPA.ISC");
								AddDrillMove(num17 - num16, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), list_2, list_3, ref Job);
								AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
								AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
								num6 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (num18 - num16);
								buString5.AddStringsToList("R910=0", ref list_2, ClearList: true, "R900=" + num6.ToString("f2"), "L CARPB.ISC");
								AddDrillMove(NoMove, num18 - num16, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), list_2, list_3, ref Job);
								AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
								list_2.Clear();
								list_2.Add("G1 Z" + (Job.Material.Size.Depth - list[0].Depth).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed);
								list_2.Add("G1 X" + (num7 - num15).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
								AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num16, Job.Moves[Job.Moves.Count - 1].X2Clamper + num16, NoMove, NoMove, DrillMoveCommand.AxisMove, num7, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), list_2, list_3, ref Job);
							}
							noMove = NoMove;
							if (flag & (num2 != NoMove))
							{
								noMove = num2 + clsDrill.varDrillCNCSettings.SlotSawRapidDistance;
							}
							drillMoveOptions.Mode = DrillCNCMode.Safe;
							drillMoveOptions.isG0 = true;
							drillMoveOptions.EnableAxes = new AxesEnable(x: false, y: false, z: true);
							buString5.AddStringsToList("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"), ref list_2);
							AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.SlotSawSafeDistance, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, list_2, list_3, ref Job);
							num2 = noMove;
							buString5.AddStringsToList("M1090", ref list_2);
							drillMoveOptions.Mode = DrillCNCMode.ToolReset;
							AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, drillMoveOptions, list_2, list_3, ref Job);
						}
						num3 = num2;
						num4++;
						continue;
					}
					DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCodeList, Job.Moves[Job.Moves.Count - 1].XPosition);
					drillMove.pntCenter = new Point3D();
					drillMove.CodeLines = new List<string>();
					drillMove.CodeLines.AddRange(list2);
					if (list2.Count > 0)
					{
						Job.Moves.Add(drillMove);
					}
					break;
				}
				return;
			}
			list2.Add("M85");
			list2.Add("M40");
			list2.Add("M6 T" + list[0].Tool);
			if (!list[0].UseMilling)
			{
				list2.Add("M16");
			}
			list2.Add("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
			FindToolSettings findToolSettings2 = new FindToolSettings();
			findToolSettings2.SetAsUsed = true;
			if (findToolSettings2.Y1Y2ZoneSelectionLimit < clsDrill.varDrillCNCSettings.Y1MinLimit)
			{
				findToolSettings2.Y1Y2ZoneSelectionLimit = clsDrill.varDrillCNCSettings.Y1MinLimit;
			}
			ToolBase5 foundTool2 = new ToolBase5();
			FindToolFromBlock(list[0], 0, findToolSettings2, ref foundTool2);
			if (foundTool2 == null)
			{
				return;
			}
			double XOffset2 = 0.0;
			double YOffset2 = 0.0;
			GetXYToolOffsetFromNo(foundTool2.Data.No, ref XOffset2, ref YOffset2);
			num = list[0].Center.Y + foundTool2.Positions.CommonOffset.Y;
			num2 = list[0].Center.Z + clsDrill.varDrillCNCSettings.SlotSawSafeDistance;
			drillMoveOptions.Tool1 = foundTool2.Data.No;
			double num20 = 0.0;
			double num21 = 0.0;
			double num22 = 0.0;
			double num23 = 0.0;
			if (!(Job.Material.Size.Width <= 550.0))
			{
				if (!((Job.Material.Size.Width > 550.0) & (Job.Material.Size.Width <= 750.0)))
				{
					if (!((Job.Material.Size.Width > 750.0) & (Job.Material.Size.Width <= 1200.0)))
					{
						num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X - 50.0;
						num21 = num20 - Job.Moves[Job.Moves.Count - 1].XPosition;
						num22 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num21;
						num23 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num21;
					}
					else
					{
						num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X - 50.0;
						num21 = num20 - Job.Moves[Job.Moves.Count - 1].XPosition;
						num22 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num21;
						num23 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num21;
					}
				}
				else
				{
					num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X - 50.0;
					num21 = num20 - Job.Moves[Job.Moves.Count - 1].XPosition;
					num22 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num21;
					num23 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num21;
				}
			}
			else
			{
				num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X - 50.0;
				num21 = num20 - Job.Moves[Job.Moves.Count - 1].XPosition;
				num22 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num21;
				num23 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num21;
			}
			AddDrillMove(NoMove, NoMove, num, NoMove, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, ref Job);
			int Index2 = -1;
			GetIndexFromItemID(list[0].ID, list, ref Index2);
			if (Index2 >= 0)
			{
				list[Index2].OffsetedPoint.X = num20;
			}
			AddDrillMove(num22, num23, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num20, drillMoveOptions, ref Job);
			double num24 = 0.0;
			double num25 = 0.0;
			if (!(Job.Material.Size.Width <= 550.0))
			{
				if (!((Job.Material.Size.Width > 550.0) & (clsDrill.activeJob.Material.Size.Width <= 750.0)))
				{
					if (!((Job.Material.Size.Width > 750.0) & (clsDrill.activeJob.Material.Size.Width <= 1200.0)))
					{
						if (!((Job.Material.Size.Width > 1200.0) & (clsDrill.activeJob.Material.Size.Width <= 1500.0)))
						{
							if (!((Job.Material.Size.Width > 1500.0) & (clsDrill.activeJob.Material.Size.Width <= 2000.0)))
							{
								double num26 = 0.0 - (2000.0 - Job.Moves[Job.Moves.Count - 1].XPosition);
								double num27 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num26;
								list2.Add("R910=0");
								list2.Add("R901=" + num27.ToString("f2"));
								list2.Add("L CARPA.ISC");
								MoveClampers(num26, NoMove, drillPlaneNames.Top, ref Job);
								double num28 = num26 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 800.0;
								num27 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num28;
								list2.Add("R910=0");
								list2.Add("R900=" + num27.ToString("f2"));
								list2.Add("L CARPB.ISC");
								MoveClampers(NoMove, num28, drillPlaneNames.Top, ref Job);
								num24 = num20 - (num28 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
							}
							else
							{
								double num29 = 0.0 - (Job.Material.Size.Width - Job.Moves[Job.Moves.Count - 1].XPosition) + clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
								double num30 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num29;
								list2.Add("R910=0");
								list2.Add("R901=" + num30.ToString("f2"));
								list2.Add("L CARPA.ISC");
								MoveClampers(num29, NoMove, drillPlaneNames.Top, ref Job);
								double num31 = num29 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 600.0;
								num30 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num31;
								list2.Add("R910=0");
								list2.Add("R900=" + num30.ToString("f2"));
								list2.Add("L CARPB.ISC");
								MoveClampers(NoMove, num31, drillPlaneNames.Top, ref Job);
								num24 = num20 - (num31 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
							}
						}
						else
						{
							double num32 = 0.0 - (Job.Material.Size.Width - Job.Moves[Job.Moves.Count - 1].XPosition) + clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
							double num33 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num32;
							list2.Add("R910=0");
							list2.Add("R901=" + num33.ToString("f2"));
							list2.Add("L CARPA.ISC");
							MoveClampers(num32, NoMove, drillPlaneNames.Top, ref Job);
							double num34 = num32 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 400.0;
							num33 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num34;
							list2.Add("R910=0");
							list2.Add("R900=" + num33.ToString("f2"));
							list2.Add("L CARPB.ISC");
							MoveClampers(NoMove, num34, drillPlaneNames.Top, ref Job);
							num24 = num20 - (num34 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
						}
					}
					else
					{
						double num35 = 0.0 - (Job.Material.Size.Width - Job.Moves[Job.Moves.Count - 1].XPosition) + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperLength / 4.0;
						double num36 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num35;
						list2.Add("R910=0");
						list2.Add("R901=" + num36.ToString("f2"));
						list2.Add("L CARPA.ISC");
						MoveClampers(num35, NoMove, drillPlaneNames.Top, ref Job);
						double num37 = num35 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 150.0;
						num36 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num37;
						list2.Add("R910=0");
						list2.Add("R900=" + num36.ToString("f2"));
						list2.Add("L CARPB.ISC");
						MoveClampers(NoMove, num37, drillPlaneNames.Top, ref Job);
						num24 = num20 - (num37 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 100.0);
					}
				}
				else
				{
					double num38 = 0.0 - (Job.Material.Size.Width - Job.Moves[Job.Moves.Count - 1].XPosition) + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperLength / 4.0;
					double num39 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num38;
					list2.Add("R910=0");
					list2.Add("R901=" + num39.ToString("f2"));
					list2.Add("L CARPA.ISC");
					MoveClampers(num38, NoMove, drillPlaneNames.Top, ref Job);
					double num40 = num38 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + 60.0;
					num39 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num40;
					list2.Add("R910=0");
					list2.Add("R900=" + num39.ToString("f2"));
					list2.Add("L CARPB.ISC");
					MoveClampers(NoMove, num40, drillPlaneNames.Top, ref Job);
					num24 = num20 - (num40 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 70.0);
				}
			}
			else
			{
				double num41 = 0.0 - (Job.Material.Size.Width - Job.Moves[Job.Moves.Count - 1].XPosition) + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
				double num42 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num41;
				list2.Add("R910=0");
				list2.Add("R901=" + num42.ToString("f2"));
				list2.Add("L CARPA.ISC");
				MoveClampers(num41, NoMove, drillPlaneNames.Top, ref Job);
				double num43 = num41 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
				num42 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num43;
				list2.Add("R910=0");
				list2.Add("R900=" + num42.ToString("f2"));
				list2.Add("L CARPB.ISC");
				MoveClampers(NoMove, num43, drillPlaneNames.Top, ref Job);
				num24 = num20 - (num43 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + 70.0);
			}
			list2.Add("G0 X" + list[0].Center.X.ToString("f2") + " Y" + list[0].Center.Y.ToString("f2"));
			list2.Add("M" + list[0].Tool);
			list2.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
			list2.Add("G1 Z" + (Job.Material.Size.Depth - list[0].Depth).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed);
			if (list.Count < 2)
			{
				num2 = NoMove;
			}
			else
			{
				num2 = list[1].Center.Z + clsDrill.varDrillCNCSettings.SlotSawRapidDistance;
			}
			AddDrillMove(NoMove, NoMove, NoMove, clsDrill.activeJob.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance, DrillMoveCommand.AxisMove, num20, drillMoveOptions, ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.SetPiston, NoMove, drillMoveOptions, ref Job);
			if (list.Count < 2)
			{
				num2 = NoMove;
			}
			else
			{
				num2 = list[1].Center.Z - list[1].Depth;
			}
			AddDrillMove(NoMove, NoMove, NoMove, list[0].Center.Z - list[0].Depth, DrillMoveCommand.AxisMove, num20, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
			num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + num24;
			if (!(Job.Material.Size.Width <= 550.0))
			{
				if ((Job.Material.Size.Width > 550.0) & (clsDrill.activeJob.Material.Size.Width <= 750.0))
				{
					num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + num24 - 20.0;
				}
			}
			else
			{
				num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + num24 - 5.0;
			}
			num21 = num20 - Job.Moves[Job.Moves.Count - 1].XPosition;
			num22 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num21;
			num23 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num21;
			AddDrillMove(num22, num23, NoMove, NoMove, DrillMoveCommand.AxisMove, num20, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
			list2.Add("G1 X" + num20.ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed);
			list2.Add("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
			list2.Add("M85");
			double num44 = num24 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperLength * 0.3 + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
			num44 = XOffset2 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
			num44 = ((Job.Material.Size.Width <= 550.0) ? (num20 + clsDrill.varDrillCNCSettings.ClamperLength * 0.2) : (((Job.Material.Size.Width > 550.0) & (clsDrill.activeJob.Material.Size.Width <= 750.0)) ? (num20 + clsDrill.varDrillCNCSettings.ClamperLength * 0.15) : (((Job.Material.Size.Width > 750.0) & (clsDrill.activeJob.Material.Size.Width <= 1200.0)) ? (num20 - clsDrill.varDrillCNCSettings.ClamperLength / 4.0) : (num20 - clsDrill.varDrillCNCSettings.ClamperLength))));
			double num45 = Job.Moves[Job.Moves.Count - 1].X2Clamper - num44;
			list2.Add("R910=0");
			list2.Add("R900=" + num45.ToString("f2"));
			list2.Add("L CARPB.ISC");
			list2.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
			list2.Add("G1 Z" + (Job.Material.Size.Depth - list[0].Depth).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetAll, NoMove, drillMoveOptions, ref Job);
			MoveClampers(NoMove, num44, drillPlaneNames.Top, ref Job);
			num25 = num24 + (foundTool2.Positions.CommonOffset.X - (Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength / 2.0)) - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance * 2.0;
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.SetPiston, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool2.Data.No), ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, list[0].Center.Z - list[0].Depth, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
			num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + num25;
			if (!(Job.Material.Size.Width <= 550.0))
			{
				if ((Job.Material.Size.Width > 550.0) & (clsDrill.activeJob.Material.Size.Width <= 750.0))
				{
					num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + num25 + 5.0;
				}
			}
			else
			{
				num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + num25 + 30.0;
			}
			num21 = num20 - Job.Moves[Job.Moves.Count - 1].XPosition;
			num22 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num21;
			num23 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num21;
			list2.Add("G1 X" + num20.ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
			list2.Add("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
			list2.Add("M85");
			AddDrillMove(num22, num23, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num20, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.Z2SafeDistance, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetPiston, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool2.Data.No), ref Job);
			double num46 = Job.Moves[Job.Moves.Count - 1].X1Clamper + clsDrill.varDrillCNCSettings.ClamperLength * 2.0;
			num46 = XOffset2 + clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
			num46 = ((Job.Material.Size.Width <= 550.0) ? (Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength) : (((Job.Material.Size.Width > 550.0) & (Job.Material.Size.Width <= 750.0)) ? (Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 70.0) : (((Job.Material.Size.Width > 750.0) & (Job.Material.Size.Width <= 1200.0)) ? (Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 140.0) : (((Job.Material.Size.Width > 1200.0) & (Job.Material.Size.Width <= 1500.0)) ? (Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 500.0) : (((Job.Material.Size.Width > 1500.0) & (Job.Material.Size.Width <= 2000.0)) ? (Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 800.0) : (Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - clsDrill.varDrillCNCSettings.ClamperLength - 1000.0))))));
			if (Job.Moves[Job.Moves.Count - 1].X2Clamper - num46 < clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + clsDrill.varDrillCNCSettings.ClamperLength)
			{
				num46 = Job.Moves[Job.Moves.Count - 1].X2Clamper - clsDrill.varDrillCNCSettings.ClamperLength - clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance;
			}
			num45 = Job.Moves[Job.Moves.Count - 1].X1Clamper - num46;
			list2.Add("R910=0");
			list2.Add("R901=" + num45.ToString("f2"));
			list2.Add("L CARPA.ISC");
			list2.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
			list2.Add("G1 Z" + (Job.Material.Size.Depth - list[0].Depth).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetAll, NoMove, drillMoveOptions, ref Job);
			MoveClampers(num46, NoMove, drillPlaneNames.Top, ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.SetPiston, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool2.Data.No), ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, list[0].Center.Z - list[0].Depth, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
			num20 = XOffset2 + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + list[0].Length + foundTool2.Geometry.Diameter / 4.0;
			num21 = num20 - Job.Moves[Job.Moves.Count - 1].XPosition;
			num22 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num21;
			num23 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num21;
			if (!(num23 > clsDrill.varDrillMachineSettings.MachineMaxXStroke))
			{
				AddDrillMove(num22, num23, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num20, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
				list2.Add("G1 X" + num20.ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
			}
			else
			{
				double num47 = num23 - clsDrill.varDrillMachineSettings.MachineMaxXStroke;
				double num48 = num22 - num47;
				double num49 = num23 - num47;
				double x2 = num20 - num47;
				list2.Add("G1 X" + x2.ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
				AddDrillMove(num48, num49, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, x2, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
				AddDrillMove(num48 - num47, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
				AddDrillMove(NoMove, num49 - num47, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None, foundTool2.Data.No), ref Job);
				AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num47, Job.Moves[Job.Moves.Count - 1].X2Clamper + num47, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num20, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge, foundTool2.Data.No), ref Job);
				num45 = Job.Moves[Job.Moves.Count - 1].X1Clamper - (num48 - num47);
				list2.Add("R910=0");
				list2.Add("R901=" + num45.ToString("f2"));
				list2.Add("L CARPA.ISC");
				list2.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
				num45 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (num49 - num47);
				list2.Add("R910=0");
				list2.Add("R900=" + num45.ToString("f2"));
				list2.Add("L CARPB.ISC");
				list2.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
				list2.Add("G1 Z" + (Job.Material.Size.Depth - list[0].Depth).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed);
				list2.Add("G1 X" + num20.ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
			}
			AddDrillMove(NoMove, NoMove, NoMove, clsDrill.varDrillCNCSettings.SlotSawSafeDistance, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.ResetAll, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, foundTool2.Data.No), ref Job);
			list2.Add("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
			list2.Add("M85");
			DrillMove drillMove2 = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCodeList, Job.Moves[Job.Moves.Count - 1].XPosition);
			drillMove2.pntCenter = new Point3D();
			drillMove2.CodeLines = new List<string>();
			drillMove2.CodeLines.AddRange(list2);
			Job.Moves.Add(drillMove2);
		}
		else
		{
			buString5.MessageBoxError(buDrillCalc.LangDrillMessage[41]);
		}
	}

	public void CreateCodeForSlotTopSideByMilling(ref DrillJob Job, ref List<DrillItem> ItemSlot)
	{
		double y = 0.0;
		Point3D point3D = new Point3D();
		DrillMoveOptions drillMoveOptions = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast);
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		for (int i = 0; i <= ItemSlot.Count - 1; i++)
		{
			DrillCalcItem item = new DrillCalcItem(ItemSlot[i]);
			list.Add(item);
		}
		if (list.Count == 0)
		{
			return;
		}
		if (!((list[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperCatchWidth) & (Job.Material.Size.Width < 400.0)))
		{
			List<string> list2 = new List<string>();
			if (list[0].Center.Y <= clsDrill.varDrillCNCSettings.ClamperSlotCatchWidth)
			{
				return;
			}
			for (int j = 0; j <= ItemSlot.Count - 1; j++)
			{
				list2.Add("M85");
				list2.Add("M40");
				list2.Add("M6 T" + ItemSlot[j].ToolMilling.Data.No);
				list2.Add("$M39");
				list2.Add("S" + ItemSlot[j].ToolMilling.CamData.SpindleSpeed + " M3");
				list2.Add("M149");
				list2.Add("G0 X" + ItemSlot[j].Center.X.ToString("f2") + " Y" + ItemSlot[j].Center.Y.ToString("f2") + " Z" + clsDrill.varDrillCNCSettings.distanceSafe.ToString("f2"));
				list2.Add("M1091");
				if (clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
				{
					list2.Add("G0 X" + (list[0].Center.X + list[0].Length).ToString("f2") + " Y" + list[0].Center.Y.ToString("f2"));
				}
				else
				{
					list2.Add("G0 X" + list[0].Center.X.ToString("f2") + " Y" + list[0].Center.Y.ToString("f2"));
				}
				double num = 0.0;
				point3D.X = list[0].Center.X;
				point3D.Y = list[0].Center.Y;
				point3D.Z = Job.Material.Size.Depth - list[0].Depth;
				drillMoveOptions.Tool1 = ItemSlot[j].ToolMilling.Data.No;
				drillMoveOptions.Mode = DrillCNCMode.Safe;
				drillMoveOptions.EnableAxes = new AxesEnable(x: false, y: false, z: true);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.distanceSafe, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, ref Job);
				double num2 = 0.0;
				double num3 = num + list[0].Center.X;
				double num4 = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
				double num5 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num4;
				double num6 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num4;
				if (!(num5 < clsDrill.varDrillMachineSettings.MachineMinXStroke))
				{
					drillMoveOptions.Mode = DrillCNCMode.Safe;
					drillMoveOptions.EnableAxes = new AxesEnable(x: true, y: true, z: false);
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num4, Job.Moves[Job.Moves.Count - 1].X2Clamper + num4, y, NoMoveZ1, DrillMoveCommand.AxisMove, num3, drillMoveOptions, ref Job);
				}
				else
				{
					AddDrillMove(NoMove, NoMove, y, NoMove, DrillMoveCommand.AxisMove, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast, 0, 0), ref Job);
					double num7 = Job.Moves[Job.Moves.Count - 1].X1Clamper - clsDrill.varDrillMachineSettings.MachineMinXStroke;
					double x = num3 + Math.Abs(num4) - num7;
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper - num7, Job.Moves[Job.Moves.Count - 1].X2Clamper - num7, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, x, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
					num4 += num7;
					num5 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num4;
					num6 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num4;
					double num8 = num5 - clsDrill.varDrillMachineSettings.MachineMinXStroke;
					double num9 = num5 - num8;
					double num10 = num6 - num8;
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(NoMove, num10 - num8, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(num9 - num8, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num4, Job.Moves[Job.Moves.Count - 1].X2Clamper + num4, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast), ref Job);
				}
				list2.Add("M95");
				list2.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
				list2.Add("G1 Z" + (Job.Material.Size.Depth - list[0].Depth).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed);
				drillMoveOptions.Mode = DrillCNCMode.ToolSet;
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.SetPiston, NoMove, drillMoveOptions, ref Job);
				drillMoveOptions.Mode = DrillCNCMode.Safe;
				drillMoveOptions.EnableAxes = new AxesEnable(x: false, y: false, z: true);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.SlotSawRapidDistance, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, ref Job);
				drillMoveOptions.Mode = DrillCNCMode.Safe;
				drillMoveOptions.EnableAxes = new AxesEnable(x: false, y: false, z: true);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, point3D.Z, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, ref Job);
				num3 = num + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X + list[0].Length;
				if (clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
				{
					num3 = num + clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + list[0].Center.X;
				}
				num4 = num3 - Job.Moves[Job.Moves.Count - 1].XPosition;
				num5 = Job.Moves[Job.Moves.Count - 1].X1Clamper + num4;
				num6 = Job.Moves[Job.Moves.Count - 1].X2Clamper + num4;
				double num11 = clsDrill.varDrillCNCSettings.ReclineDiameter * 0.5 + num;
				if (!(num6 > clsDrill.varDrillMachineSettings.MachineMaxXStroke - clsDrill.varDrillMachineSettings.MillingHolderOffset))
				{
					drillMoveOptions.Mode = DrillCNCMode.Plunge;
					drillMoveOptions.EnableAxes = new AxesEnable(x: true, y: false, z: false);
					drillMoveOptions.isG0 = false;
					drillMoveOptions.Feed = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
					AddDrillMove(num5, num6, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, num3, drillMoveOptions, ref Job);
					if (clsDrill.varDrillCNCSettings.SlotSawReverseDirection)
					{
						list2.Add("G1 X" + list[0].Center.X.ToString("f2") + " Y" + list[0].Center.Y.ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
					}
					else
					{
						list2.Add("G1 X" + (list[0].Center.X + list[0].Length).ToString("f2") + " Y" + list[0].Center.Y.ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
					}
				}
				else
				{
					double num12 = num6 - clsDrill.varDrillMachineSettings.MachineMaxXStroke + clsDrill.varDrillMachineSettings.MillingHolderOffset;
					double num13 = num5 - num12;
					double num14 = num6 - num12;
					double num15 = num3 - num12;
					list2.Add("G1 X" + (num15 - num11).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
					AddDrillMove(num13, num14, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num15, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(num13 - num12, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(NoMove, num14 - num12, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, NoMove, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.None), ref Job);
					AddDrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper + num12, Job.Moves[Job.Moves.Count - 1].X2Clamper + num12, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.AxisMove, num3, new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Plunge), ref Job);
					num2 = Job.Moves[Job.Moves.Count - 1].X1Clamper - (num13 - num12);
					list2.Add("R910=0");
					list2.Add("R901=" + num2.ToString("f2"));
					list2.Add("L CARPA.ISC");
					list2.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
					num2 = Job.Moves[Job.Moves.Count - 1].X2Clamper - (num14 - num12);
					list2.Add("R910=0");
					list2.Add("R900=" + num2.ToString("f2"));
					list2.Add("L CARPB.ISC");
					list2.Add("G0 Z" + (Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.SlotSawRapidDistance).ToString("f2"));
					list2.Add("G1 Z" + (Job.Material.Size.Depth - list[0].Depth).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawPlungeSpeed);
					list2.Add("G1 X" + (num3 - num11).ToString("f2") + " F" + clsDrill.varDrillCNCSettings.SlotSawCuttingSpeed);
				}
				list2.Add("G0 Z" + clsDrill.varDrillCNCSettings.SlotSawSafeDistance.ToString("f2"));
				list2.Add("M1090");
				list2.Add("M85");
				drillMoveOptions.Mode = DrillCNCMode.Safe;
				drillMoveOptions.isG0 = true;
				drillMoveOptions.EnableAxes = new AxesEnable(x: false, y: false, z: true);
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, clsDrill.varDrillCNCSettings.SlotSawSafeDistance, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, ref Job);
				drillMoveOptions.Mode = DrillCNCMode.ToolReset;
				AddDrillMove(NoMoveX1, NoMoveX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.ResetAll, NoMove, drillMoveOptions, ref Job);
				DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1].X1Clamper, Job.Moves[Job.Moves.Count - 1].X2Clamper, Job.Moves[Job.Moves.Count - 1].Y1Position, Job.Moves[Job.Moves.Count - 1].Z1Position, DrillMoveCommand.GCodeList, Job.Moves[Job.Moves.Count - 1].XPosition);
				drillMove.pntCenter = new Point3D();
				drillMove.CodeLines = new List<string>();
				drillMove.CodeLines.AddRange(list2);
				Job.Moves.Add(drillMove);
			}
		}
		else
		{
			buString5.MessageBoxError(buDrillCalc.LangDrillMessage[41]);
		}
	}

	public void CreateCodeForSlotTopSide(ref List<DrillItem> ItemShape, bool isTop, ToolBase5 toolFound, ref DrillJob Job)
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
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<DrillCalcItem>();
		List<Entity> list = null;
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
		camTp camTp2 = new camTp();
		new camTp();
		new camTp();
		new camTp();
		new camTp();
		camTp camTp3 = new camTp();
		ShapeCamParameterSet(Job, toolFound);
		for (int i = 0; i <= ItemShape.Count - 1; i++)
		{
			num3 = ItemShape[i].ShapeData.Depth;
			buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
			buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
			buMWDrillVars.varCamContour.buPar.Distances.RapidRetract = true;
			List<List<buEntity>> copiedEntities = new List<List<buEntity>>();
			if (ItemShape[i].camEntities.Count <= 0)
			{
				buEntity.Copy(ItemShape[i].shapeEntitites, ref copiedEntities);
			}
			else
			{
				buEntity.Copy(ItemShape[i].camEntities, ref copiedEntities);
			}
			if (ItemShape[i].isDrill)
			{
				continue;
			}
			for (int j = 0; j <= copiedEntities.Count - 1; j++)
			{
				list = new List<Entity>();
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
					Entity copiedEntity = null;
					buEntity.Copy(buEntity2, ref copiedEntity);
					list.Add(copiedEntity);
				}
				buMWDrillVars.varCamContour.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
				buMWDrillVars.varCamContour.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
				ccVars.toolActive.CamData.SpindleSpeed = clsDrill.varDrillCNCSettings.TopSpindleSpeed;
				buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
				buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - num3;
				buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
				buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - num3;
				if (ItemShape[i].FeedCut > 0.0)
				{
					buMWDrillVars.varCamContour.buPar.Speeds.Feed = ItemShape[i].FeedCut;
				}
				if (ItemShape[i].FeedPlunge > 0.0)
				{
					buMWDrillVars.varCamContour.buPar.Speeds.Plunge = ItemShape[i].FeedPlunge;
				}
				if (ItemShape[i].SpindleSpeed > 0.0)
				{
					ccVars.toolActive.CamData.SpindleSpeed = ItemShape[i].SpindleSpeed;
				}
				if (!ItemShape[i].StepEnable)
				{
					buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
					buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[i].StepValue;
					buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
					buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[i].StepValue;
					buMWDrillVars.varCamRough.buPar.Steps.StartValue = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamRough.buPar.Steps.EndValue = Job.Material.Size.Depth - num3;
				}
				else
				{
					buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
					buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[i].StepValue;
					buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth;
					buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
					buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[i].StepValue;
					buMWDrillVars.varCamRough.buPar.Steps.StartValue = Job.Material.Size.Depth;
					buMWDrillVars.varCamRough.buPar.Steps.EndValue = Job.Material.Size.Depth - num3;
				}
				if (list.Count <= 0)
				{
					continue;
				}
				clsMW.CamEntities.Clear();
				for (int l = 0; l <= list.Count - 1; l++)
				{
					Entity copiedEnt = null;
					buVector5.CopyEntities(list[l], ref copiedEnt);
					clsMW.CamEntities.Add(copiedEnt);
				}
				mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
				camTp2 = new camTp();
				ToolBase5 tool = new ToolBase5(toolFound);
				if (ItemShape[i].ToolMilling != null)
				{
					tool = new ToolBase5(ItemShape[i].ToolMilling);
				}
				doWireframeContour(mWCalculationOptions, tool, ref camTp2);
				camTp3.EntitiesG1.AddRange(camTp2.EntitiesG1);
				camTp2.Tool = new ToolBase5(tool);
				bool flag = false;
				if (!ItemShape[i].X1First)
				{
					camTp2.Aux1First = ItemShape[i].X1First;
					if (ItemShape[i].X2Move != 0.0)
					{
						camTp2.Aux2 = ItemShape[i].X2Move;
						camTp2.CamPoints[0].PreCodes.Add("M85");
						camTp2.CamPoints[0].PreCodes.Add("R910=0");
						camTp2.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
						camTp2.CamPoints[0].PreCodes.Add("L CARPB.ISC");
						flag = true;
					}
					if (ItemShape[i].X1Move != 0.0)
					{
						camTp2.Aux1 = ItemShape[i].X1Move;
						camTp2.CamPoints[0].PreCodes.Add("M85");
						camTp2.CamPoints[0].PreCodes.Add("R910=0");
						camTp2.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
						camTp2.CamPoints[0].PreCodes.Add("L CARPA.ISC");
						flag = true;
					}
				}
				else
				{
					camTp2.Aux1First = ItemShape[i].X1First;
					if ((ItemShape[i].X1Move != 0.0) & (camTp2.CamPoints.Count > 0))
					{
						camTp2.Aux1 = ItemShape[i].X1Move;
						camTp2.CamPoints[0].PreCodes.Add("M85");
						camTp2.CamPoints[0].PreCodes.Add("R910=0");
						camTp2.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
						camTp2.CamPoints[0].PreCodes.Add("L CARPA.ISC");
						flag = true;
					}
					if ((ItemShape[i].X2Move != 0.0) & (camTp2.CamPoints.Count > 0))
					{
						camTp2.Aux2 = ItemShape[i].X2Move;
						camTp2.CamPoints[0].PreCodes.Add("M85");
						camTp2.CamPoints[0].PreCodes.Add("R910=0");
						camTp2.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
						camTp2.CamPoints[0].PreCodes.Add("L CARPB.ISC");
						flag = true;
					}
				}
				if (!flag || ItemShape[i].planeName == planeBoxNames.Top)
				{
				}
				if (camTp2.CamPoints.Count > 0)
				{
					camTp3.Tool = new ToolBase5(camTp2.Tool);
					for (int m = 0; m <= camTp2.CamPoints.Count - 1; m++)
					{
						camTpPoint camTpPoint2 = new camTpPoint(camTp2.CamPoints[m]);
						camTpPoint2.ToolCam = new ToolBase5(camTp2.Tool);
						camTp3.CamPoints.Add(camTpPoint2);
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
				if (camTp2.SimilationPoint.SimMove.Count <= 0)
				{
					continue;
				}
				if (camTp3.SimilationPoint.SimMove.Count > 0)
				{
					List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
					clsInit.cVector5.LineerInterpolation(camTp3.SimilationPoint.SimMove[camTp3.SimilationPoint.SimMove.Count - 1], camTp2.SimilationPoint.SimMove[0], 0.1, ref CalculatedPoints);
					if (CalculatedPoints.Count >= 3)
					{
						CalculatedPoints.RemoveAt(0);
						CalculatedPoints.RemoveAt(CalculatedPoints.Count - 1);
						for (int n = 0; n <= CalculatedPoints.Count - 1; n++)
						{
							CalculatedPoints[n].ToolNo = ItemShape[i].ToolMilling.Data.No;
							camTp3.SimilationPoint.SimMove.Add(CalculatedPoints[n]);
						}
					}
				}
				if (!((camTp2.Aux1 != 0.0) & (camTp2.Aux2 != 0.0)))
				{
					if (!((camTp2.Aux1 != 0.0) & (camTp2.Aux2 == 0.0)))
					{
						if ((camTp2.Aux1 == 0.0) & (camTp2.Aux2 != 0.0))
						{
							Pnt6DSimMove pnt6DSimMove = new Pnt6DSimMove(camTp2.SimilationPoint.SimMove[camTp2.SimilationPoint.SimMove.Count - 1]);
							pnt6DSimMove.Aux2 = camTp2.Aux2;
							camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove);
						}
					}
					else
					{
						Pnt6DSimMove pnt6DSimMove2 = new Pnt6DSimMove(camTp2.SimilationPoint.SimMove[camTp2.SimilationPoint.SimMove.Count - 1]);
						pnt6DSimMove2.Aux1 = camTp2.Aux1;
						camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove2);
					}
				}
				else if (!camTp2.Aux1First)
				{
					Pnt6DSimMove pnt = new Pnt6DSimMove(camTp2.SimilationPoint.SimMove[camTp2.SimilationPoint.SimMove.Count - 1]);
					Pnt6DSimMove pnt6DSimMove3 = new Pnt6DSimMove(pnt);
					pnt6DSimMove3.Aux2 = camTp2.Aux2;
					camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove3);
					pnt6DSimMove3 = new Pnt6DSimMove(pnt);
					pnt6DSimMove3.Aux1 = camTp2.Aux1;
					camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove3);
				}
				else
				{
					Pnt6DSimMove pnt2 = new Pnt6DSimMove(camTp2.SimilationPoint.SimMove[camTp2.SimilationPoint.SimMove.Count - 1]);
					Pnt6DSimMove pnt6DSimMove4 = new Pnt6DSimMove(pnt2);
					pnt6DSimMove4.Aux1 = camTp2.Aux1;
					camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove4);
					pnt6DSimMove4 = new Pnt6DSimMove(pnt2);
					pnt6DSimMove4.Aux2 = camTp2.Aux2;
					camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove4);
				}
				for (int num4 = 0; num4 <= camTp2.SimilationPoint.SimMove.Count - 1; num4++)
				{
					Pnt6DSimMove pnt6DSimMove5 = new Pnt6DSimMove(camTp2.SimilationPoint.SimMove[num4]);
					pnt6DSimMove5.ToolNo = ItemShape[i].ToolMilling.Data.No;
					camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove5);
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
			return;
		}
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		DrillMove drillMove = new DrillMove();
		if ((Job.SimulationMoves.Count > 0) & (camTp3.SimilationPoint.SimMove.Count > 0))
		{
			num5 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].XPosition;
			num6 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
			num7 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
			num = num6;
			num2 = num7;
			y = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y1Position;
			y2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y2Position;
			y3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y3Position;
			z = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z1Position;
			z2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z2Position;
			z3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z3Position;
			drillMove = new DrillMove(num6, num7, y, y2, y3, z, z2, z3, DrillMoveCommand.SetPiston, num5, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[0].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			Job.SimulationMoves.Add(drillMove);
		}
		double num8 = 0.0;
		double num9 = 0.0;
		for (int num10 = 0; num10 <= camTp3.SimilationPoint.SimMove.Count - 1; num10++)
		{
			if (Job.SimulationMoves[Job.SimulationMoves.Count - 1].Tool1 != (int)camTp3.SimilationPoint.SimMove[num10].ToolNo)
			{
				num6 = num6 + camTp3.SimilationPoint.SimMove[num10].X - num5;
				num7 = num7 + camTp3.SimilationPoint.SimMove[num10].X - num5;
				xPos = camTp3.SimilationPoint.SimMove[num10].X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
				num = num6 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num8;
				num2 = num7 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num9;
				y = camTp3.SimilationPoint.SimMove[num10].Y;
				z = camTp3.SimilationPoint.SimMove[num10].Z;
				drillMove = new DrillMove(num6, num7, y, y2, y3, z, z2, z3, DrillMoveCommand.SetPiston, num5, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num10].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
			}
			if (!((camTp3.SimilationPoint.SimMove[num10].Aux1 != 0.0) | (camTp3.SimilationPoint.SimMove[num10].Aux2 != 0.0)))
			{
				num6 = num6 + camTp3.SimilationPoint.SimMove[num10].X - num5;
				num7 = num7 + camTp3.SimilationPoint.SimMove[num10].X - num5;
				xPos = camTp3.SimilationPoint.SimMove[num10].X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
				num = num6 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num8;
				num2 = num7 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num9;
				y = camTp3.SimilationPoint.SimMove[num10].Y;
				z = camTp3.SimilationPoint.SimMove[num10].Z;
				if (num10 == camTp3.SimilationPoint.SimMove.Count - 1)
				{
					drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.ResetPiston, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num10].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					Job.SimulationMoves.Add(drillMove);
				}
				drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.AxisMove, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num10].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				if (num10 == 0 && Job.SimulationMoves.Count > 0)
				{
					List<DrillMove> calcSimMoves = new List<DrillMove>();
					clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove, 20.0, ref calcSimMoves);
					if (calcSimMoves.Count > 2)
					{
						calcSimMoves.RemoveAt(calcSimMoves.Count - 1);
						for (int num11 = 0; num11 <= calcSimMoves.Count - 1; num11++)
						{
							Job.SimulationMoves.Add(calcSimMoves[num11]);
						}
					}
				}
				Job.SimulationMoves.Add(drillMove);
				num5 = camTp3.SimilationPoint.SimMove[num10].X;
				continue;
			}
			if (camTp3.SimilationPoint.SimMove[num10].Aux1 != 0.0)
			{
				num8 += camTp3.SimilationPoint.SimMove[num10].Aux1;
				drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper1Up, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num10].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
				List<double> Values = new List<double>();
				buNumeric5.DevideMinMaxValueByNumber(0.0, camTp3.SimilationPoint.SimMove[num10].Aux1, 5, ref Values);
				_ = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
				for (int num12 = 1; num12 <= Values.Count - 1; num12++)
				{
					drillMove = new DrillMove(num + Values[num12], num2, y, y2, y3, z, z2, z3, DrillMoveCommand.AxisMove, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num10].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					Job.SimulationMoves.Add(drillMove);
				}
				num += camTp3.SimilationPoint.SimMove[num10].Aux1;
				drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper1Down, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num10].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
			}
			if (camTp3.SimilationPoint.SimMove[num10].Aux2 != 0.0)
			{
				num9 += camTp3.SimilationPoint.SimMove[num10].Aux2;
				drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper2Up, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num10].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
				List<double> Values2 = new List<double>();
				buNumeric5.DevideMinMaxValueByNumber(0.0, camTp3.SimilationPoint.SimMove[num10].Aux2, 5, ref Values2);
				_ = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
				for (int num13 = 1; num13 <= Values2.Count - 1; num13++)
				{
					drillMove = new DrillMove(num, num2 + Values2[num13], y, y2, y3, z, z2, z3, DrillMoveCommand.AxisMove, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num10].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					Job.SimulationMoves.Add(drillMove);
				}
				num2 += camTp3.SimilationPoint.SimMove[num10].Aux2;
				drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper2Down, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num10].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
			}
		}
		if (camTp3.CamPoints.Count > 0 && isTop)
		{
			Job.Cams.Add(camTp3);
		}
	}

	public void ShapeCamParameterSet(DrillJob Job, ToolBase5 toolFound)
	{
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
		camTp camTp2 = new camTp();
		camTp Cam = new camTp();
		camTp Cam2 = new camTp();
		new camTp();
		new camTp();
		camTp camTp3 = new camTp();
		ShapeCamParameterSet(Job, toolFound);
		for (int i = 0; i <= ItemShape.Count - 1; i++)
		{
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
							mWCalculationOptions.isBuWireframeCalculation = false;
							if (ItemShape[i].ShapeType == ShapeTypes.FreeLines)
							{
								mWCalculationOptions.isBuWireframeCalculation = true;
								buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
								buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
							}
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
			buMWDrillVars.varCamContour.buPar.Distances.RapidRetract = true;
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
					buMWDrillVars.varCamContour.buPar.Distances.Rapid = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
					buMWDrillVars.varCamContour.buPar.Distances.EntryAndExit = Job.Material.Size.Depth + clsDrill.varDrillCNCSettings.distanceSmallSafe;
					ccVars.toolActive.CamData.SpindleSpeed = clsDrill.varDrillCNCSettings.TopSpindleSpeed;
					buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
					buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth - num3;
					if (ItemShape[i].FeedCut > 0.0)
					{
						buMWDrillVars.varCamContour.buPar.Speeds.Feed = ItemShape[i].FeedCut;
					}
					if (ItemShape[i].FeedPlunge > 0.0)
					{
						buMWDrillVars.varCamContour.buPar.Speeds.Plunge = ItemShape[i].FeedPlunge;
					}
					if (ItemShape[i].SpindleSpeed > 0.0)
					{
						ccVars.toolActive.CamData.SpindleSpeed = ItemShape[i].SpindleSpeed;
					}
					if (!ItemShape[i].StepEnable)
					{
						buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
						buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[i].StepValue;
						buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
						buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[i].StepValue;
						buMWDrillVars.varCamRough.buPar.Steps.StartValue = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamRough.buPar.Steps.EndValue = Job.Material.Size.Depth - num3;
					}
					else
					{
						buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
						buMWDrillVars.varCamContour.buPar.Steps.DepthStep = ItemShape[i].StepValue;
						buMWDrillVars.varCamContour.buPar.Steps.StartValue = Job.Material.Size.Depth;
						buMWDrillVars.varCamContour.buPar.Steps.EndValue = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Job.Material.Size.Depth - num3;
						buMWDrillVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Job.Material.Size.Depth;
						buMWDrillVars.varCamRough.buPar.Steps.DepthStep = ItemShape[i].StepValue;
						buMWDrillVars.varCamRough.buPar.Steps.StartValue = Job.Material.Size.Depth;
						buMWDrillVars.varCamRough.buPar.Steps.EndValue = Job.Material.Size.Depth - num3;
					}
					if (list.Count > 0)
					{
						clsMW.CamEntities.Clear();
						for (int l = 0; l <= list.Count - 1; l++)
						{
							Entity copiedEnt = null;
							buVector5.CopyEntities(list[l], ref copiedEnt);
							clsMW.CamEntities.Add(copiedEnt);
						}
						mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
						camTp2 = new camTp();
						ToolBase5 tool = new ToolBase5(toolFound);
						if (ItemShape[i].ToolMilling != null)
						{
							tool = new ToolBase5(ItemShape[i].ToolMilling);
						}
						doWireframeContour(mWCalculationOptions, tool, ref camTp2);
						camTp3.EntitiesG1.AddRange(camTp2.EntitiesG1);
						camTp2.Tool = new ToolBase5(tool);
						if (!((ItemShape[i].Command == drillCommands.DrawingContour) | ItemShape[i].isMillingAtClamperSide))
						{
							bool flag = false;
							if (!ItemShape[i].X1First)
							{
								camTp2.Aux1First = ItemShape[i].X1First;
								if (ItemShape[i].X2Move != 0.0)
								{
									camTp2.Aux2 = ItemShape[i].X2Move;
									camTp2.CamPoints[0].PreCodes.Add("M85");
									camTp2.CamPoints[0].PreCodes.Add("R910=0");
									camTp2.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
									camTp2.CamPoints[0].PreCodes.Add("L CARPB.ISC");
									flag = true;
								}
								if (ItemShape[i].X1Move != 0.0)
								{
									camTp2.Aux1 = ItemShape[i].X1Move;
									camTp2.CamPoints[0].PreCodes.Add("M85");
									camTp2.CamPoints[0].PreCodes.Add("R910=0");
									camTp2.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
									camTp2.CamPoints[0].PreCodes.Add("L CARPA.ISC");
									flag = true;
								}
							}
							else
							{
								camTp2.Aux1First = ItemShape[i].X1First;
								if ((ItemShape[i].X1Move != 0.0) & (camTp2.CamPoints.Count > 0))
								{
									camTp2.Aux1 = ItemShape[i].X1Move;
									camTp2.CamPoints[0].PreCodes.Add("M85");
									camTp2.CamPoints[0].PreCodes.Add("R910=0");
									camTp2.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
									camTp2.CamPoints[0].PreCodes.Add("L CARPA.ISC");
									flag = true;
								}
								if ((ItemShape[i].X2Move != 0.0) & (camTp2.CamPoints.Count > 0))
								{
									camTp2.Aux2 = ItemShape[i].X2Move;
									camTp2.CamPoints[0].PreCodes.Add("M85");
									camTp2.CamPoints[0].PreCodes.Add("R910=0");
									camTp2.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
									camTp2.CamPoints[0].PreCodes.Add("L CARPB.ISC");
									flag = true;
								}
							}
							if (flag && ItemShape[i].planeName != planeBoxNames.Top)
							{
							}
						}
						else
						{
							if (copiedEntities.Count == 2 && j == 1)
							{
								bool flag2 = false;
								if (!ItemShape[i].X1First)
								{
									camTp2.Aux1First = ItemShape[i].X1First;
									if (ItemShape[i].X2Move != 0.0)
									{
										camTp2.Aux2 = ItemShape[i].X2Move;
										camTp2.CamPoints[0].PreCodes.Add("M85");
										camTp2.CamPoints[0].PreCodes.Add("R910=0");
										camTp2.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
										camTp2.CamPoints[0].PreCodes.Add("L CARPB.ISC");
										flag2 = true;
									}
									if (ItemShape[i].X1Move != 0.0)
									{
										camTp2.Aux1 = ItemShape[i].X1Move;
										camTp2.CamPoints[0].PreCodes.Add("M85");
										camTp2.CamPoints[0].PreCodes.Add("R910=0");
										camTp2.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
										camTp2.CamPoints[0].PreCodes.Add("L CARPA.ISC");
										flag2 = true;
									}
								}
								else
								{
									camTp2.Aux1First = ItemShape[i].X1First;
									if (ItemShape[i].X1Move != 0.0)
									{
										camTp2.Aux1 = ItemShape[i].X1Move;
										camTp2.CamPoints[0].PreCodes.Add("M85");
										camTp2.CamPoints[0].PreCodes.Add("R910=0");
										camTp2.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
										camTp2.CamPoints[0].PreCodes.Add("L CARPA.ISC");
										flag2 = true;
									}
									if (ItemShape[i].X2Move != 0.0)
									{
										camTp2.Aux2 = ItemShape[i].X2Move;
										camTp2.CamPoints[0].PreCodes.Add("M85");
										camTp2.CamPoints[0].PreCodes.Add("R910=0");
										camTp2.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
										camTp2.CamPoints[0].PreCodes.Add("L CARPB.ISC");
										flag2 = true;
									}
								}
								if (flag2 && ItemShape[i].planeName != planeBoxNames.Top)
								{
								}
							}
							if (copiedEntities.Count == 3)
							{
								if (ItemShape[i].Command != drillCommands.DrawingContour)
								{
									if (j == 1)
									{
										bool flag3 = false;
										if (ItemShape[i].X2Move != 0.0)
										{
											camTp2.Aux2 = ItemShape[i].X2Move;
											camTp2.CamPoints[0].PreCodes.Add("M85");
											camTp2.CamPoints[0].PreCodes.Add("R910=0");
											camTp2.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
											camTp2.CamPoints[0].PreCodes.Add("L CARPB.ISC");
											flag3 = true;
										}
										if (flag3 && ItemShape[i].planeName != planeBoxNames.Top)
										{
										}
									}
									if (j == 2)
									{
										bool flag4 = false;
										if (ItemShape[i].X1Move != 0.0)
										{
											camTp2.Aux1 = ItemShape[i].X1Move;
											camTp2.CamPoints[0].PreCodes.Add("M85");
											camTp2.CamPoints[0].PreCodes.Add("R910=0");
											camTp2.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
											camTp2.CamPoints[0].PreCodes.Add("L CARPA.ISC");
											flag4 = true;
										}
										if (flag4 && ItemShape[i].planeName != planeBoxNames.Top)
										{
										}
									}
								}
								else
								{
									if (j == 1)
									{
										bool flag5 = false;
										if (ItemShape[i].X2Move != 0.0 && ItemShape[i].ClockDir == ClockDirectionType.CW)
										{
											camTp2.Aux1First = false;
											camTp2.Aux2 = ItemShape[i].X2Move;
											camTp2.CamPoints[0].PreCodes.Add("M85");
											camTp2.CamPoints[0].PreCodes.Add("R910=0");
											camTp2.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
											camTp2.CamPoints[0].PreCodes.Add("L CARPB.ISC");
											camTp2.Aux1 = ItemShape[i].X2Move;
											camTp2.CamPoints[0].PreCodes.Add("M85");
											camTp2.CamPoints[0].PreCodes.Add("R910=0");
											camTp2.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
											camTp2.CamPoints[0].PreCodes.Add("L CARPA.ISC");
											flag5 = true;
										}
										if (ItemShape[i].X1Move != 0.0 && ItemShape[i].ClockDir == ClockDirectionType.CCW)
										{
											camTp2.Aux1First = true;
											camTp2.Aux1 = ItemShape[i].X1Move;
											camTp2.CamPoints[0].PreCodes.Add("M85");
											camTp2.CamPoints[0].PreCodes.Add("R910=0");
											camTp2.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
											camTp2.CamPoints[0].PreCodes.Add("L CARPA.ISC");
											camTp2.Aux2 = ItemShape[i].X1Move;
											camTp2.CamPoints[0].PreCodes.Add("M85");
											camTp2.CamPoints[0].PreCodes.Add("R910=0");
											camTp2.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
											camTp2.CamPoints[0].PreCodes.Add("L CARPB.ISC");
											flag5 = true;
										}
										if (flag5 && ItemShape[i].planeName != planeBoxNames.Top)
										{
										}
									}
									if (j == 2)
									{
										bool flag6 = false;
										if (ItemShape[i].X1Move != 0.0)
										{
											if (ItemShape[i].ClockDir == ClockDirectionType.CW)
											{
												camTp2.Aux1 = ItemShape[i].X1Move;
												camTp2.CamPoints[0].PreCodes.Add("M85");
												camTp2.CamPoints[0].PreCodes.Add("R910=0");
												camTp2.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
												camTp2.CamPoints[0].PreCodes.Add("L CARPA.ISC");
												ItemShape[i].X1Move = ItemShape[i].X1Move + ItemShape[i].X2Move;
											}
											flag6 = true;
										}
										if (ItemShape[i].X2Move != 0.0 && ItemShape[i].ClockDir == ClockDirectionType.CCW)
										{
											camTp2.Aux2 = ItemShape[i].X2Move;
											camTp2.CamPoints[0].PreCodes.Add("M85");
											camTp2.CamPoints[0].PreCodes.Add("R910=0");
											camTp2.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
											camTp2.CamPoints[0].PreCodes.Add("L CARPB.ISC");
											ItemShape[i].X2Move = ItemShape[i].X1Move + ItemShape[i].X2Move;
											flag6 = true;
										}
										if (flag6 && ItemShape[i].planeName != planeBoxNames.Top)
										{
										}
									}
								}
							}
						}
						if (camTp2.CamPoints.Count > 0)
						{
							camTp3.Tool = new ToolBase5(camTp2.Tool);
							for (int m = 0; m <= camTp2.CamPoints.Count - 1; m++)
							{
								camTpPoint camTpPoint2 = new camTpPoint(camTp2.CamPoints[m]);
								camTpPoint2.ToolCam = new ToolBase5(camTp2.Tool);
								camTp3.CamPoints.Add(camTpPoint2);
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
						if (camTp2.SimilationPoint.SimMove.Count > 0)
						{
							if (camTp3.SimilationPoint.SimMove.Count > 0)
							{
								List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
								clsInit.cVector5.LineerInterpolation(camTp3.SimilationPoint.SimMove[camTp3.SimilationPoint.SimMove.Count - 1], camTp2.SimilationPoint.SimMove[0], 0.1, ref CalculatedPoints);
								if (CalculatedPoints.Count >= 3)
								{
									CalculatedPoints.RemoveAt(0);
									CalculatedPoints.RemoveAt(CalculatedPoints.Count - 1);
									for (int n = 0; n <= CalculatedPoints.Count - 1; n++)
									{
										CalculatedPoints[n].ToolNo = ItemShape[i].ToolMilling.Data.No;
										camTp3.SimilationPoint.SimMove.Add(CalculatedPoints[n]);
									}
								}
							}
							if (!((camTp2.Aux1 != 0.0) & (camTp2.Aux2 != 0.0)))
							{
								if (!((camTp2.Aux1 != 0.0) & (camTp2.Aux2 == 0.0)))
								{
									if ((camTp2.Aux1 == 0.0) & (camTp2.Aux2 != 0.0))
									{
										Pnt6DSimMove pnt6DSimMove = new Pnt6DSimMove(camTp3.SimilationPoint.SimMove[camTp3.SimilationPoint.SimMove.Count - 1]);
										pnt6DSimMove.Aux2 = camTp2.Aux2;
										camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove);
									}
								}
								else
								{
									Pnt6DSimMove pnt6DSimMove2 = new Pnt6DSimMove(camTp3.SimilationPoint.SimMove[camTp3.SimilationPoint.SimMove.Count - 1]);
									pnt6DSimMove2.Aux1 = camTp2.Aux1;
									camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove2);
								}
							}
							else if (!camTp2.Aux1First)
							{
								Pnt6DSimMove pnt = new Pnt6DSimMove();
								if (camTp3.SimilationPoint.SimMove.Count > 0)
								{
									pnt = new Pnt6DSimMove(camTp3.SimilationPoint.SimMove[camTp3.SimilationPoint.SimMove.Count - 1]);
								}
								Pnt6DSimMove pnt6DSimMove3 = new Pnt6DSimMove(pnt);
								pnt6DSimMove3.Aux2 = camTp2.Aux2;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove3);
								pnt6DSimMove3 = new Pnt6DSimMove(pnt);
								pnt6DSimMove3.Aux1 = camTp2.Aux1;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove3);
							}
							else
							{
								Pnt6DSimMove pnt2 = new Pnt6DSimMove(camTp3.SimilationPoint.SimMove[camTp3.SimilationPoint.SimMove.Count - 1]);
								Pnt6DSimMove pnt6DSimMove4 = new Pnt6DSimMove(pnt2);
								pnt6DSimMove4.Aux1 = camTp2.Aux1;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove4);
								pnt6DSimMove4 = new Pnt6DSimMove(pnt2);
								pnt6DSimMove4.Aux2 = camTp2.Aux2;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove4);
							}
							for (int num4 = 0; num4 <= camTp2.SimilationPoint.SimMove.Count - 1; num4++)
							{
								Pnt6DSimMove pnt6DSimMove5 = new Pnt6DSimMove(camTp2.SimilationPoint.SimMove[num4]);
								pnt6DSimMove5.ToolNo = ItemShape[i].ToolMilling.Data.No;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove5);
							}
						}
					}
					if (list2.Count <= 0)
					{
						continue;
					}
					clsMW.CamEntities.Clear();
					for (int num5 = 0; num5 <= list2.Count - 1; num5++)
					{
						Entity copiedEnt2 = null;
						buVector5.CopyEntities(list2[num5], ref copiedEnt2);
						clsMW.CamEntities.Add(copiedEnt2);
					}
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
					ToolBase5 tool2 = new ToolBase5(toolFound);
					if (ItemShape[i].ToolMilling != null)
					{
						tool2 = new ToolBase5(ItemShape[i].ToolMilling);
					}
					buMWDrillVars.varCamRough.buPar.Pockets.StepOverPersentage = ItemShape[i].CamPars.Pockets.StepOverPersentage;
					doWireframePocket(mWCalculationOptions, tool2, ref Cam);
					camTp3.EntitiesG1.AddRange(Cam.EntitiesG1);
					Cam.Tool = new ToolBase5(tool2);
					if (!ItemShape[i].isMillingAtClamperSide)
					{
						bool flag7 = false;
						if (!ItemShape[i].X1First)
						{
							Cam.Aux1First = ItemShape[i].X1First;
							if (ItemShape[i].X2Move != 0.0)
							{
								Cam.Aux2 = ItemShape[i].X2Move;
								Cam.CamPoints[0].PreCodes.Add("M85");
								Cam.CamPoints[0].PreCodes.Add("R910=0");
								Cam.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
								Cam.CamPoints[0].PreCodes.Add("L CARPB.ISC");
								flag7 = true;
							}
							if (ItemShape[i].X1Move != 0.0)
							{
								Cam.Aux1 = ItemShape[i].X1Move;
								Cam.CamPoints[0].PreCodes.Add("M85");
								Cam.CamPoints[0].PreCodes.Add("R910=0");
								Cam.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
								Cam.CamPoints[0].PreCodes.Add("L CARPA.ISC");
								flag7 = true;
							}
						}
						else
						{
							Cam.Aux1First = ItemShape[i].X1First;
							if ((ItemShape[i].X1Move != 0.0) & (Cam.CamPoints.Count > 0))
							{
								Cam.Aux1 = ItemShape[i].X1Move;
								Cam.CamPoints[0].PreCodes.Add("M85");
								Cam.CamPoints[0].PreCodes.Add("R910=0");
								Cam.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
								Cam.CamPoints[0].PreCodes.Add("L CARPA.ISC");
								flag7 = true;
							}
							if ((ItemShape[i].X2Move != 0.0) & (Cam.CamPoints.Count > 0))
							{
								Cam.Aux2 = ItemShape[i].X2Move;
								Cam.CamPoints[0].PreCodes.Add("M85");
								Cam.CamPoints[0].PreCodes.Add("R910=0");
								Cam.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
								Cam.CamPoints[0].PreCodes.Add("L CARPB.ISC");
								flag7 = true;
							}
						}
						if (flag7 && ItemShape[i].planeName != planeBoxNames.Top)
						{
						}
					}
					else
					{
						if (copiedEntities.Count == 2 && j == 1)
						{
							bool flag8 = false;
							if (!ItemShape[i].X1First)
							{
								Cam.Aux1First = ItemShape[i].X1First;
								if (ItemShape[i].X2Move != 0.0)
								{
									Cam.Aux2 = ItemShape[i].X2Move;
									Cam.CamPoints[0].PreCodes.Add("M85");
									Cam.CamPoints[0].PreCodes.Add("R910=0");
									Cam.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
									Cam.CamPoints[0].PreCodes.Add("L CARPB.ISC");
									flag8 = true;
								}
								if (ItemShape[i].X1Move != 0.0)
								{
									Cam.Aux1 = ItemShape[i].X1Move;
									Cam.CamPoints[0].PreCodes.Add("M85");
									Cam.CamPoints[0].PreCodes.Add("R910=0");
									Cam.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
									Cam.CamPoints[0].PreCodes.Add("L CARPA.ISC");
									flag8 = true;
								}
							}
							else
							{
								Cam.Aux1First = ItemShape[i].X1First;
								if (ItemShape[i].X1Move != 0.0)
								{
									Cam.Aux1 = ItemShape[i].X1Move;
									Cam.CamPoints[0].PreCodes.Add("M85");
									Cam.CamPoints[0].PreCodes.Add("R910=0");
									Cam.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
									Cam.CamPoints[0].PreCodes.Add("L CARPA.ISC");
									flag8 = true;
								}
								if (ItemShape[i].X2Move != 0.0)
								{
									Cam.Aux2 = ItemShape[i].X2Move;
									Cam.CamPoints[0].PreCodes.Add("M85");
									Cam.CamPoints[0].PreCodes.Add("R910=0");
									Cam.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
									Cam.CamPoints[0].PreCodes.Add("L CARPB.ISC");
									flag8 = true;
								}
							}
							if (flag8 && ItemShape[i].planeName != planeBoxNames.Top)
							{
							}
						}
						if (copiedEntities.Count == 3)
						{
							if (j == 1)
							{
								bool flag9 = false;
								if (ItemShape[i].X2Move != 0.0)
								{
									Cam.Aux2 = ItemShape[i].X2Move;
									Cam.CamPoints[0].PreCodes.Add("M85");
									Cam.CamPoints[0].PreCodes.Add("R910=0");
									Cam.CamPoints[0].PreCodes.Add("R900=" + (0.0 - ItemShape[i].X2Move).ToString("f1"));
									Cam.CamPoints[0].PreCodes.Add("L CARPB.ISC");
									flag9 = true;
								}
								if (flag9 && ItemShape[i].planeName != planeBoxNames.Top)
								{
								}
							}
							if (j == 2)
							{
								bool flag10 = false;
								if (ItemShape[i].X1Move != 0.0)
								{
									Cam.Aux1 = ItemShape[i].X1Move;
									Cam.CamPoints[0].PreCodes.Add("M85");
									Cam.CamPoints[0].PreCodes.Add("R910=0");
									Cam.CamPoints[0].PreCodes.Add("R901=" + (0.0 - ItemShape[i].X1Move).ToString("f1"));
									Cam.CamPoints[0].PreCodes.Add("L CARPA.ISC");
									flag10 = true;
								}
								if (flag10 && ItemShape[i].planeName != planeBoxNames.Top)
								{
								}
							}
						}
					}
					if (Cam.CamPoints.Count > 0)
					{
						camTp3.Tool = new ToolBase5(Cam.Tool);
						for (int num6 = 0; num6 <= Cam.CamPoints.Count - 1; num6++)
						{
							camTpPoint camTpPoint3 = new camTpPoint(Cam.CamPoints[num6]);
							camTpPoint3.ToolCam = new ToolBase5(Cam.Tool);
							camTp3.CamPoints.Add(camTpPoint3);
							if (!isTop)
							{
								camTp3.PlaneName = planeNames.Bottom;
								continue;
							}
							if (num6 != 0)
							{
							}
							if (num6 != Cam.CamPoints.Count - 1)
							{
							}
							if (camTp3.CamPoints.Count <= 0 || clsDrill.activeJob.Material.Size.Depth - ItemShape[i].ShapeData.Depth <= 2.0)
							{
							}
							camTp3.PlaneName = planeNames.Top;
						}
					}
					if (Cam.SimilationPoint.SimMove.Count <= 0)
					{
						continue;
					}
					if (camTp3.SimilationPoint.SimMove.Count > 0)
					{
						List<Pnt6DSimMove> CalculatedPoints2 = new List<Pnt6DSimMove>();
						clsInit.cVector5.LineerInterpolation(camTp3.SimilationPoint.SimMove[camTp3.SimilationPoint.SimMove.Count - 1], Cam.SimilationPoint.SimMove[0], 0.1, ref CalculatedPoints2);
						if (CalculatedPoints2.Count >= 3)
						{
							CalculatedPoints2.RemoveAt(0);
							CalculatedPoints2.RemoveAt(CalculatedPoints2.Count - 1);
							for (int num7 = 0; num7 <= CalculatedPoints2.Count - 1; num7++)
							{
								CalculatedPoints2[num7].ToolNo = ItemShape[i].ToolMilling.Data.No;
								camTp3.SimilationPoint.SimMove.Add(CalculatedPoints2[num7]);
							}
						}
					}
					if (!((Cam.Aux1 != 0.0) & (Cam.Aux2 != 0.0)))
					{
						if (!((Cam.Aux1 != 0.0) & (Cam.Aux2 == 0.0)))
						{
							if ((Cam.Aux1 == 0.0) & (Cam.Aux2 != 0.0))
							{
								Pnt6DSimMove pnt6DSimMove6 = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
								pnt6DSimMove6.Aux2 = Cam.Aux2;
								camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove6);
							}
						}
						else
						{
							Pnt6DSimMove pnt6DSimMove7 = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
							pnt6DSimMove7.Aux1 = Cam.Aux1;
							camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove7);
						}
					}
					else if (!Cam.Aux1First)
					{
						Pnt6DSimMove pnt3 = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
						Pnt6DSimMove pnt6DSimMove8 = new Pnt6DSimMove(pnt3);
						pnt6DSimMove8.Aux2 = Cam.Aux2;
						camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove8);
						pnt6DSimMove8 = new Pnt6DSimMove(pnt3);
						pnt6DSimMove8.Aux1 = Cam.Aux1;
						camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove8);
					}
					else
					{
						Pnt6DSimMove pnt4 = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
						Pnt6DSimMove pnt6DSimMove9 = new Pnt6DSimMove(pnt4);
						pnt6DSimMove9.Aux1 = Cam.Aux1;
						camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove9);
						pnt6DSimMove9 = new Pnt6DSimMove(pnt4);
						pnt6DSimMove9.Aux2 = Cam.Aux2;
						camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove9);
					}
					for (int num8 = 0; num8 <= Cam.SimilationPoint.SimMove.Count - 1; num8++)
					{
						Pnt6DSimMove pnt6DSimMove10 = new Pnt6DSimMove(Cam.SimilationPoint.SimMove[num8]);
						pnt6DSimMove10.ToolNo = ItemShape[i].ToolMilling.Data.No;
						camTp3.SimilationPoint.SimMove.Add(pnt6DSimMove10);
					}
				}
			}
			if (ItemShape[i].Command == drillCommands.Engraving)
			{
				for (int num9 = 0; num9 <= ItemShape[i].solidEntities.Count - 1; num9++)
				{
					if (ItemShape[i].isRough)
					{
						Entity copiedEntity3 = null;
						buEntity.Copy(ItemShape[i].solidEntities[num9], ref copiedEntity3);
						list4.Add(copiedEntity3);
					}
					if (ItemShape[i].isFinish)
					{
						Entity copiedEntity4 = null;
						buEntity.Copy(ItemShape[i].solidEntities[num9], ref copiedEntity4);
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
		if (list3.Count > 0)
		{
			double depth = 0.0;
			clsMW.CamEntities.Clear();
			for (int num10 = 0; num10 <= list3.Count - 1; num10++)
			{
				Entity copiedEnt3 = null;
				depth = (isTop ? (clsDrill.activeJob.Material.Size.Depth - ((CustomData)list3[num10].EntityData).infoDepth) : (0.0 - ((CustomData)list3[num10].EntityData).infoDepth));
				buVector5.CopyEntities(list3[num10], ref copiedEnt3);
				clsMW.CamEntities.Add(copiedEnt3);
			}
			ToolBase5 tool3 = new ToolBase5();
			doDrill(mWCalculationOptions, depth, tool3, ref Cam2);
			if (Cam2.CamPoints.Count > 0)
			{
				for (int num11 = 0; num11 <= Cam2.CamPoints.Count - 1; num11++)
				{
					if (num11 <= list3.Count - 1)
					{
						for (int num12 = 0; num12 <= ccVars.Tools[0].Tools.Count - 1; num12++)
						{
							if (buCompare5.EQ(ccVars.Tools[0].Tools[num12].Geometry.Diameter, ((Circle)list3[num11]).Diameter, 0.1))
							{
								Cam2.CamPoints[num11].ToolCam = new ToolBase5(ccVars.Tools[0].Tools[num12]);
							}
						}
					}
					if (Cam2.CamPoints[num11].ToolCam == null)
					{
						calcErrorList.Add("Top Surface Milling Tool Not Available : " + buLangTranslate.preDef.Diameter + " =  " + ((Circle)list3[num11]).Diameter.ToString("f1"));
					}
					camTp3.CamPoints.Add(new camTpPoint(Cam2.CamPoints[num11]));
				}
			}
			if (Cam2.SimilationPoint.SimMove.Count > 0)
			{
				for (int num13 = 0; num13 <= Cam2.SimilationPoint.SimMove.Count - 1; num13++)
				{
					camTp3.SimilationPoint.SimMove.Add(new Pnt6DSimMove(Cam2.SimilationPoint.SimMove[num13]));
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
			return;
		}
		double num14 = 0.0;
		double num15 = 0.0;
		double num16 = 0.0;
		DrillMove drillMove = new DrillMove();
		if ((Job.SimulationMoves.Count > 0) & (camTp3.SimilationPoint.SimMove.Count > 0))
		{
			num14 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].XPosition;
			num15 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
			num16 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
			num = num15;
			num2 = num16;
			y = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y1Position;
			y2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y2Position;
			y3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Y3Position;
			z = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z1Position;
			z2 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z2Position;
			z3 = Job.SimulationMoves[Job.SimulationMoves.Count - 1].Z3Position;
			drillMove = new DrillMove(num15, num16, y, y2, y3, z, z2, z3, DrillMoveCommand.SetPiston, num14, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[0].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			Job.SimulationMoves.Add(drillMove);
		}
		double num17 = 0.0;
		double num18 = 0.0;
		for (int num19 = 0; num19 <= camTp3.SimilationPoint.SimMove.Count - 1; num19++)
		{
			if (Job.SimulationMoves[Job.SimulationMoves.Count - 1].Tool1 != (int)camTp3.SimilationPoint.SimMove[num19].ToolNo)
			{
				num15 = num15 + camTp3.SimilationPoint.SimMove[num19].X - num14;
				num16 = num16 + camTp3.SimilationPoint.SimMove[num19].X - num14;
				xPos = camTp3.SimilationPoint.SimMove[num19].X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
				num = num15 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num17;
				num2 = num16 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num18;
				y = camTp3.SimilationPoint.SimMove[num19].Y;
				z = camTp3.SimilationPoint.SimMove[num19].Z;
				drillMove = new DrillMove(num15, num16, y, y2, y3, z, z2, z3, DrillMoveCommand.SetPiston, num14, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num19].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
			}
			if (!((camTp3.SimilationPoint.SimMove[num19].Aux1 != 0.0) | (camTp3.SimilationPoint.SimMove[num19].Aux2 != 0.0)))
			{
				num15 = num15 + camTp3.SimilationPoint.SimMove[num19].X - num14;
				num16 = num16 + camTp3.SimilationPoint.SimMove[num19].X - num14;
				xPos = camTp3.SimilationPoint.SimMove[num19].X + clsDrill.varDrillCNCSettings.Tool80XZeroOffset;
				num = num15 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num17;
				num2 = num16 + clsDrill.varDrillCNCSettings.Tool80XZeroOffset + num18;
				y = camTp3.SimilationPoint.SimMove[num19].Y;
				z = camTp3.SimilationPoint.SimMove[num19].Z;
				if (num19 == camTp3.SimilationPoint.SimMove.Count - 1)
				{
					drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.ResetPiston, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num19].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					Job.SimulationMoves.Add(drillMove);
				}
				drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.AxisMove, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num19].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				if (num19 == 0 && Job.SimulationMoves.Count > 0)
				{
					List<DrillMove> calcSimMoves = new List<DrillMove>();
					clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove, 20.0, ref calcSimMoves);
					if (calcSimMoves.Count > 2)
					{
						calcSimMoves.RemoveAt(calcSimMoves.Count - 1);
						for (int num20 = 0; num20 <= calcSimMoves.Count - 1; num20++)
						{
							Job.SimulationMoves.Add(calcSimMoves[num20]);
						}
					}
				}
				Job.SimulationMoves.Add(drillMove);
				num14 = camTp3.SimilationPoint.SimMove[num19].X;
				continue;
			}
			if (camTp3.SimilationPoint.SimMove[num19].Aux1 != 0.0)
			{
				num17 += camTp3.SimilationPoint.SimMove[num19].Aux1;
				drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper1Up, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num19].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
				List<double> Values = new List<double>();
				buNumeric5.DevideMinMaxValueByNumber(0.0, camTp3.SimilationPoint.SimMove[num19].Aux1, 5, ref Values);
				_ = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X1Clamper;
				for (int num21 = 1; num21 <= Values.Count - 1; num21++)
				{
					drillMove = new DrillMove(num + Values[num21], num2, y, y2, y3, z, z2, z3, DrillMoveCommand.AxisMove, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num19].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					Job.SimulationMoves.Add(drillMove);
				}
				num += camTp3.SimilationPoint.SimMove[num19].Aux1;
				drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper1Down, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num19].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
			}
			if (camTp3.SimilationPoint.SimMove[num19].Aux2 != 0.0)
			{
				num18 += camTp3.SimilationPoint.SimMove[num19].Aux2;
				drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper2Up, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num19].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
				List<double> Values2 = new List<double>();
				buNumeric5.DevideMinMaxValueByNumber(0.0, camTp3.SimilationPoint.SimMove[num19].Aux2, 5, ref Values2);
				_ = Job.SimulationMoves[Job.SimulationMoves.Count - 1].X2Clamper;
				for (int num22 = 1; num22 <= Values2.Count - 1; num22++)
				{
					drillMove = new DrillMove(num, num2 + Values2[num22], y, y2, y3, z, z2, z3, DrillMoveCommand.AxisMove, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num19].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					Job.SimulationMoves.Add(drillMove);
				}
				num2 += camTp3.SimilationPoint.SimMove[num19].Aux2;
				drillMove = new DrillMove(num, num2, y, y2, y3, z, z2, z3, DrillMoveCommand.Clamper2Down, xPos, DrillCNCMode.None, drillPlaneNames.Top, (int)camTp3.SimilationPoint.SimMove[num19].ToolNo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				Job.SimulationMoves.Add(drillMove);
			}
		}
		if (camTp3.CamPoints.Count > 0 && isTop)
		{
			Job.Cams.Add(camTp3);
		}
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
		clsMW.varMWCamWFPocketPars.MachParam.MaxStepoverDistance = Tool.Geometry.Diameter * clsMW.varbuCamWFPocketPars.Pockets.StepOverPersentage / 100.0;
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

	public void ToolSetAddList(DrillMoveOptions Option, ref List<string> CodeSL)
	{
		if (Option.Tool1 != 0)
		{
			CodeSL.Add("M" + Option.Tool1);
		}
		if (Option.Tool2 != 0)
		{
			CodeSL.Add("M" + Option.Tool2);
		}
		if (Option.Tool3 != 0)
		{
			CodeSL.Add("M" + Option.Tool3);
		}
		if (Option.Tool4 != 0)
		{
			CodeSL.Add("M" + Option.Tool4);
		}
		if (Option.Tool5 != 0)
		{
			CodeSL.Add("M" + Option.Tool5);
		}
		if (Option.Tool6 != 0)
		{
			CodeSL.Add("M" + Option.Tool6);
		}
		if (Option.Tool7 != 0)
		{
			CodeSL.Add("M" + Option.Tool7);
		}
		if (Option.Tool8 != 0)
		{
			CodeSL.Add("M" + Option.Tool8);
		}
		if (Option.Tool9 != 0)
		{
			CodeSL.Add("M" + Option.Tool9);
		}
		if (Option.Tool10 != 0)
		{
			CodeSL.Add("M" + Option.Tool10);
		}
		if (Option.Tool11 != 0)
		{
			CodeSL.Add("M" + Option.Tool11);
		}
		if (Option.Tool12 != 0)
		{
			CodeSL.Add("M" + Option.Tool12);
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

	public int SetValueToAvailableTool(int ToolValue, ref int T1, ref int T2, ref int T3, ref int T4, ref int T5, ref int T6, ref int T7, ref int T8, ref int T9, ref int T10, ref int T11, ref int T12, ref List<int> Y1GroupTool)
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
				return 1;
			}
			if (T2 <= 0)
			{
				T2 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
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
				return 3;
			}
			if (T4 <= 0)
			{
				T4 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
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
				return 5;
			}
			if (T6 <= 0)
			{
				T6 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
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
				return 7;
			}
			if (T8 <= 0)
			{
				T8 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
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
				return 9;
			}
			if (T10 <= 0)
			{
				T10 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
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
				return 11;
			}
			if (T12 <= 0)
			{
				T12 = ToolValue;
				if (ToolValue >= 61 && ToolValue <= 79)
				{
					Y1GroupTool.Add(ToolValue);
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
			double num = 0.0;
			for (int j = 1; j <= list.Count - 1; j++)
			{
				num = list[j] - list[j - 1];
				if (num > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					X2Pos = 0.0 - Math.Abs(list[j - 1] + (list[j] - list[j - 1]) / 2.0);
					X1Pos = 0.0 - (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
					return true;
				}
			}
			num = Math.Abs(list[0]);
			if (num > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
			{
				X2Pos = (0.0 - num) / 2.0;
				X1Pos = 0.0 - (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
				return true;
			}
			double num2 = Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength * 0.3;
			num = num2 - Math.Abs(list[list.Count - 1]);
			if (num > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
			{
				X2Pos = 0.0 - Math.Abs(list[list.Count - 1] + (num2 - list[list.Count - 1]) / 2.0);
				X1Pos = 0.0 - (Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength + 3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
				return true;
			}
		}
		if (list.Count != 1 || !(Job.Material.Size.Width < clsDrill.varDrillCNCSettings.ClamperLength) || list[0] != 0.0)
		{
			if (!((list.Count == 0) & (list2.Count > 0)))
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

	public bool SingleMustClamper(DrillJob Job, ref double X1Pos, ref double X2Pos)
	{
		double num = (0.0 - Job.Material.Size.Width) / 2.0;
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			if (Job.Items[i].planeName == planeBoxNames.Right)
			{
				flag = true;
			}
			if (Job.Items[i].planeName == planeBoxNames.Left)
			{
				flag2 = true;
			}
		}
		if (flag2)
		{
			if (!flag)
			{
				num = 0.0 - Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
			}
		}
		else
		{
			num = (0.0 - clsDrill.varDrillCNCSettings.ClamperLength) / 2.0;
		}
		X2Pos = num;
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

	public bool isDrillInsideClamper(double XPosition, List<ToolBase5> activeTools, double ClamperOperationMinDistance, ref double ClamperMinXToToolX, ref double ClamperMaxXToToolX, double ExtraOffset = 0.0)
	{
		bool result = false;
		double num = XPosition - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - ClamperOperationMinDistance - ExtraOffset;
		double num2 = XPosition + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + ClamperOperationMinDistance + ExtraOffset;
		List<double> RefList = new List<double>();
		for (int i = 0; i <= activeTools.Count - 1; i++)
		{
			double x = activeTools[i].Positions.CommonOffset.X;
			if (((num <= activeTools[i].Positions.CommonOffset.X) & (activeTools[i].Positions.CommonOffset.X <= num2)) && ((x >= num && x <= num2) & (Math.Abs(x - num2) > 1.0) & (Math.Abs(x - num) > 1.0)))
			{
				result = true;
			}
			RefList.Add(x);
		}
		clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList);
		if (RefList.Count > 0)
		{
			ClamperMinXToToolX = Math.Round(RefList[RefList.Count - 1] - num, 3);
			ClamperMaxXToToolX = Math.Round(num2 - RefList[0], 3);
		}
		return result;
	}

	public bool isItemInsideClamper(double XPosition, ToolBase5 ToolMilling, double ClamperOperationMinDistance, ref double ClamperMinXToToolX, ref double ClamperMaxXToToolX, double ExtraOffset = 0.0)
	{
		bool result = false;
		double num = XPosition - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - ClamperOperationMinDistance - ExtraOffset;
		double num2 = XPosition + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + ClamperOperationMinDistance + ExtraOffset;
		List<double> RefList = new List<double>();
		double x = ToolMilling.Positions.CommonOffset.X;
		if (((num <= ToolMilling.Positions.CommonOffset.X) & (ToolMilling.Positions.CommonOffset.X <= num2)) && ((x >= num && x <= num2) & (Math.Abs(x - num2) > 1.0) & (Math.Abs(x - num) > 1.0)))
		{
			result = true;
		}
		RefList.Add(x);
		clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList);
		if (RefList.Count > 0)
		{
			ClamperMinXToToolX = Math.Round(RefList[RefList.Count - 1] - num, 3);
			ClamperMaxXToToolX = Math.Round(num2 - RefList[0], 3);
		}
		return result;
	}

	public bool isItemInsideClamper(DrillItem Item, double dX, ToolBase5 ToolMilling, ref double ClamperMinXToToolX, ref double ClamperMaxXToToolX, double ExtraOffset = 0.0)
	{
		bool flag = false;
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
				flag = true;
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
				flag = true;
			}
			RefList.Add(num6);
		}
		clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList);
		if (RefList.Count > 0)
		{
			ClamperMinXToToolX = RefList[RefList.Count - 1] - num3;
			ClamperMaxXToToolX = num4 - RefList[0];
		}
		if (!flag)
		{
			if (!flag)
			{
				List<double> Values = new List<double>();
				buNumeric5.DevideMinMaxValueByNumber(Item.BoxMinItem.X, Item.BoxMaxItem.X, 5, ref Values);
				double num7 = Values[0] + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
				double num8 = Values[Values.Count - 1] + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
				for (int i = 0; i <= Values.Count - 1; i++)
				{
					ClamperMaxXToToolX = 0.0;
					ClamperMinXToToolX = 0.0;
					num = Values[i] + dX - clsDrill.varDrillCNCSettings.ClamperLength / 2.0 - clsDrill.varDrillCNCSettings.ClamperOperationMinDistance - ExtraOffset;
					num2 = Values[i] + dX + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance + ExtraOffset;
					num3 = double.MaxValue;
					num4 = double.MinValue;
					RefList = new List<double>();
					if ((num <= ToolMilling.Positions.CommonOffset.X) & (ToolMilling.Positions.CommonOffset.X <= num2))
					{
						double num9 = ToolMilling.Positions.CommonOffset.X + clsDrill.varDrillCNCSettings.ReclineDiameter / 2.0;
						num3 = num7;
						num4 = num8;
						if (num9 >= num && num9 <= num2)
						{
							flag = true;
						}
						RefList.Add(num9);
					}
					clsInit.cVector5.SortList(SortDirectionType.Lower, ref RefList);
					if (RefList.Count > 0)
					{
						ClamperMinXToToolX = RefList[RefList.Count - 1] - num3;
						ClamperMaxXToToolX = num4 - RefList[0];
						if (flag)
						{
							return flag;
						}
					}
				}
			}
			return flag;
		}
		return flag;
	}

	public void MoveClampers(double newX1, double newX2, drillPlaneNames Plane, ref DrillJob Job, bool AddListCmd = false)
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
				DrillMoveOptions drillMoveOptions = new DrillMoveOptions(Plane, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
				if (AddListCmd)
				{
					drillMoveOptions.Mode = DrillCNCMode.X2ClamperMove;
					drillMoveOptions.ClamperMove = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
					drillMoveOptions.pntCenter = new Point3D();
				}
				AddDrillMove(NoMove, newX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions, ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, Plane, NoMove, ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.XAxesGantyOn, Plane, NoMove, ref Job);
			}
		}
		else
		{
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, Plane, NoMove, ref Job);
			DrillMoveOptions drillMoveOptions2 = new DrillMoveOptions(Plane, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation, 0, 0, 0, 0, 0, 0, DrillMoveCommand.None, DrillMoveCommand.None);
			if (AddListCmd)
			{
				drillMoveOptions2.Mode = DrillCNCMode.X1ClamperMove;
				drillMoveOptions2.ClamperMove = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
				drillMoveOptions2.pntCenter = new Point3D();
			}
			AddDrillMove(newX1, NoMove, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, drillMoveOptions2, ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, Plane, NoMove, ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.XAxesGantyOn, Plane, NoMove, ref Job);
		}
	}

	public void MoveClampers(double newX1, double newX2, drillPlaneNames Plane, List<string> PreCodes, List<string> AfterCodes, ref DrillJob Job, bool AddListCmd = false)
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
		DrillMoveOptions options = new DrillMoveOptions(drillPlaneNames.Top, DrillCNCMode.Fast);
		if (!((newX1 != NoMove) | (newX2 != NoMove)))
		{
			return;
		}
		AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.XAxesGantyOff, NoMove, options, PreCodes, AfterCodes, ref Job);
		if (newX1 == NoMove)
		{
			if (newX2 != NoMove)
			{
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Up, NoMove, ref Job);
				options = new DrillMoveOptions(Plane, DrillCNCMode.Fast);
				if (AddListCmd)
				{
					options.Mode = DrillCNCMode.X2ClamperMove;
					options.ClamperMove = Job.Moves[Job.Moves.Count - 1].X2Clamper - newX2;
					options.pntCenter = new Point3D();
				}
				AddDrillMove(NoMove, newX2, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper2Down, NoMove, ref Job);
				AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.XAxesGantyOn, NoMove, ref Job);
			}
		}
		else
		{
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Up, NoMove, ref Job);
			options = new DrillMoveOptions(Plane, DrillCNCMode.Fast);
			if (AddListCmd)
			{
				options.Mode = DrillCNCMode.X1ClamperMove;
				options.ClamperMove = Job.Moves[Job.Moves.Count - 1].X1Clamper - newX1;
				options.pntCenter = new Point3D();
			}
			AddDrillMove(newX1, NoMove, NoMoveY1, NoMoveZ1, DrillMoveCommand.AxisMove, NoMove, options, ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.Clamper1Down, NoMove, ref Job);
			AddDrillMove(NoMove, NoMove, NoMove, NoMove, DrillMoveCommand.XAxesGantyOn, NoMove, ref Job);
		}
	}

	public void AddDrillMove(double X1, double X2, double Y1, double Z1, DrillMoveCommand Cmd, double X, DrillMoveOptions Options, ref DrillJob Job)
	{
		AddDrillMove(X1, X2, Y1, Z1, Cmd, X, Options, new List<string>(), new List<string>(), ref Job);
	}

	public void AddDrillMove(double X1, double X2, double Y1, double Z1, DrillMoveCommand Cmd, double X, ref DrillJob Job)
	{
		DrillMoveOptions drillMoveOptions = new DrillMoveOptions();
		drillMoveOptions.Mode = DrillCNCMode.Fast;
		AddDrillMove(X1, X2, Y1, Z1, Cmd, X, drillMoveOptions, new List<string>(), new List<string>(), ref Job);
	}

	public void AddDrillMove(double X1, double X2, double Y1, double Z1, DrillMoveCommand Cmd, double X, DrillMoveOptions Options, List<string> PreCodes, List<string> AfterCodes, ref DrillJob Job)
	{
		double x = X1;
		double x2 = X2;
		double y = Y1;
		double z = Z1;
		double xPos = X;
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		DrillMove drillMove = null;
		if (Job.Moves.Count > 0)
		{
			if (Options.OnlyCode)
			{
				drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
				drillMove.CodeLines = new List<string>();
				if (PreCodes.Count > 0)
				{
					drillMove.CodeLines.AddRange(PreCodes);
				}
				if (AfterCodes.Count > 0)
				{
					drillMove.CodeLines.AddRange(AfterCodes);
				}
				if (drillMove.CodeLines.Count > 0)
				{
					Job.Moves.Add(drillMove);
				}
				return;
			}
			if (Cmd == DrillMoveCommand.AxisMove)
			{
				double x1Clamper = Job.Moves[Job.Moves.Count - 1].X1Clamper;
				double x2Clamper = Job.Moves[Job.Moves.Count - 1].X2Clamper;
				double xPosition = Job.Moves[Job.Moves.Count - 1].XPosition;
				double y1Position = Job.Moves[Job.Moves.Count - 1].Y1Position;
				_ = Job.Moves[Job.Moves.Count - 1].Y2Position;
				_ = Job.Moves[Job.Moves.Count - 1].Y3Position;
				double z1Position = Job.Moves[Job.Moves.Count - 1].Z1Position;
				_ = Job.Moves[Job.Moves.Count - 1].Z2Position;
				_ = Job.Moves[Job.Moves.Count - 1].Z3Position;
				if (((buCompare5.EQ(X1, x1Clamper, 0.01) | (X1 == NoMove)) & (buCompare5.EQ(X2, x2Clamper, 0.01) | (X2 == NoMove)) & (buCompare5.EQ(X, xPosition, 0.01) | (X == NoMove))) && (buCompare5.EQ(Y1, y1Position, 0.01) | (Y1 == NoMove)) && (buCompare5.EQ(Z1, z1Position, 0.01) | (Z1 == NoMove)))
				{
					if (((Options.Cmd1 == DrillMoveCommand.None) & (Options.Cmd2 == DrillMoveCommand.None) & (Options.Cmd3 == DrillMoveCommand.None)) && ((PreCodes.Count == 0) & (AfterCodes.Count == 0)))
					{
						return;
					}
					if (Options.Cmd1 == DrillMoveCommand.ResetAll)
					{
						Cmd = Options.Cmd1;
					}
					if (Options.Cmd2 == DrillMoveCommand.ResetAll)
					{
						Cmd = Options.Cmd2;
					}
					if (Options.Cmd3 == DrillMoveCommand.ResetAll)
					{
						Cmd = Options.Cmd3;
					}
					if (Options.Cmd1 == DrillMoveCommand.SetPiston)
					{
						Cmd = Options.Cmd1;
					}
					if (Options.Cmd2 == DrillMoveCommand.SetPiston)
					{
						Cmd = Options.Cmd2;
					}
					if (Options.Cmd3 == DrillMoveCommand.SetPiston)
					{
						Cmd = Options.Cmd3;
					}
				}
			}
		}
		if (Cmd == DrillMoveCommand.AxisMove && ((X1 == NoMove) & (X2 == NoMove) & (Y1 == NoMove) & (Z1 == NoMove) & (X == NoMove)) && ((Options.Cmd1 == DrillMoveCommand.None) & (Options.Cmd2 == DrillMoveCommand.None) & (Options.Cmd3 == DrillMoveCommand.None)))
		{
			return;
		}
		text = "X" + X.ToString("f2") + " ";
		text2 = "Y" + Y1.ToString("f2") + " ";
		text3 = "Z" + Z1.ToString("f2") + " ";
		if ((Job.Moves.Count > 0) & (X1 == NoMove))
		{
			x = Job.Moves[Job.Moves.Count - 1].X1Clamper;
		}
		if ((Job.Moves.Count > 0) & (X2 == NoMove))
		{
			x2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
		}
		if ((Job.Moves.Count > 0) & (Y1 == NoMove))
		{
			y = Job.Moves[Job.Moves.Count - 1].Y1Position;
			text2 = "";
		}
		if ((Job.Moves.Count > 0) & (Z1 == NoMove))
		{
			z = Job.Moves[Job.Moves.Count - 1].Z1Position;
			text3 = "";
		}
		if ((Job.Moves.Count > 0) & (X == NoMove))
		{
			xPos = Job.Moves[Job.Moves.Count - 1].XPosition;
			text = "";
		}
		drillMove = new DrillMove(x, x2, y, 0.0, 0.0, z, 0.0, 0.0, Cmd, xPos);
		drillMove.Tool1 = Options.Tool1;
		drillMove.Tool2 = Options.Tool2;
		drillMove.Tool3 = Options.Tool3;
		drillMove.Tool4 = Options.Tool4;
		drillMove.Tool5 = Options.Tool5;
		drillMove.Tool6 = Options.Tool6;
		drillMove.Tool7 = Options.Tool7;
		drillMove.Tool8 = Options.Tool8;
		drillMove.Tool9 = Options.Tool9;
		drillMove.Tool10 = Options.Tool10;
		drillMove.Tool11 = Options.Tool11;
		drillMove.Tool12 = Options.Tool12;
		drillMove.Mode = Options.Mode;
		drillMove.Plane = Options.Plane;
		drillMove.Command2 = Options.Cmd2;
		drillMove.Command3 = Options.Cmd3;
		drillMove.CodeLines = new List<string>();
		if (Options.pntCenter != null)
		{
			drillMove.pntCenter = new Point3D(Options.pntCenter.X, Options.pntCenter.Y, Options.pntCenter.Z);
		}
		drillMove.EnableAxes = new AxesEnable(Options.EnableAxes);
		drillMove.isG0 = Options.isG0;
		drillMove.Feed = Options.Feed;
		drillMove.ClamperMove = Options.ClamperMove;
		text4 = ((Options.Feed > 0.0) ? ("F" + Options.Feed.ToString("f1")) : ("F" + clsDrill.varDrillCNCSettings.DrillPlungeFeed.ToString("f1")));
		if (PreCodes.Count > 0)
		{
			drillMove.CodeLines.AddRange(PreCodes);
		}
		if (Options.AddAxesCode)
		{
			if (drillMove.isG0)
			{
				drillMove.CodeLines.Add("G0 " + text + text2 + text3);
			}
			else
			{
				drillMove.CodeLines.Add("G1 " + text + text2 + text3 + text4);
			}
		}
		if (AfterCodes.Count > 0)
		{
			drillMove.CodeLines.AddRange(AfterCodes);
		}
		if (Options.AddType != DrillMoveAddType.OnlyMove)
		{
			if (Options.AddType != DrillMoveAddType.OnlySimulation)
			{
				Job.Moves.Add(drillMove);
				if (!(Job.SimulationMoves.Count == 0 || Cmd != DrillMoveCommand.AxisMove))
				{
					double devideLen = clsDrill.varDrillCNCSettings.SimulationDevideG0Length;
					if ((drillMove.Mode == DrillCNCMode.Plunge) | (drillMove.Mode == DrillCNCMode.Cut))
					{
						devideLen = clsDrill.varDrillCNCSettings.SimulationDevideG1Length;
					}
					List<DrillMove> calcSimMoves = new List<DrillMove>();
					clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove, devideLen, ref calcSimMoves);
					if (calcSimMoves.Count > 0)
					{
						for (int i = 0; i <= calcSimMoves.Count - 1; i++)
						{
							calcSimMoves[i].LineIndex = Job.Moves.Count - 1;
							Job.SimulationMoves.Add(calcSimMoves[i]);
						}
					}
				}
				else
				{
					DrillMove drillMove2 = new DrillMove(drillMove);
					drillMove2.LineIndex = Job.Moves.Count - 1;
					Job.SimulationMoves.Add(drillMove2);
				}
			}
			else if (Job.SimulationMoves.Count != 0)
			{
				List<DrillMove> calcSimMoves2 = new List<DrillMove>();
				clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove, Options.DevideLen, ref calcSimMoves2);
				if (calcSimMoves2.Count > 0)
				{
					for (int j = 0; j <= calcSimMoves2.Count - 1; j++)
					{
						Job.SimulationMoves.Add(calcSimMoves2[j]);
					}
				}
			}
			else
			{
				Job.SimulationMoves.Add(drillMove);
			}
		}
		else
		{
			Job.Moves.Add(drillMove);
		}
	}

	public void AddClamperMoveForCnc(ref DrillJob Job, double APos, double BPos, bool isAFirst)
	{
		List<string> list = new List<string>();
		double num = 0.0;
		if (!isAFirst)
		{
			if (BPos != 0.0)
			{
				num = BPos;
				list.Add("R910=0");
				list.Add("R900=" + num.ToString("f1"));
				list.Add("L CARPB.ISC");
			}
			if (APos != 0.0)
			{
				num = APos;
				list.Add("R910=0");
				list.Add("R901=" + num.ToString("f1"));
				list.Add("L CARPA.ISC");
			}
		}
		else
		{
			if (APos != 0.0)
			{
				num = APos;
				list.Add("R910=0");
				list.Add("R901=" + num.ToString("f1"));
				list.Add("L CARPA.ISC");
			}
			if (BPos != 0.0)
			{
				num = BPos;
				list.Add("R910=0");
				list.Add("R900=" + num.ToString("f1"));
				list.Add("L CARPB.ISC");
			}
		}
		if (list.Count > 0)
		{
			DrillMove drillMove = new DrillMove(Job.Moves[Job.Moves.Count - 1]);
			drillMove.Command = DrillMoveCommand.GCodeList;
			drillMove.pntCenter = new Point3D();
			drillMove.CodeLines = new List<string>();
			drillMove.CodeLines.AddRange(list);
			Job.Moves.Add(drillMove);
		}
	}
}
