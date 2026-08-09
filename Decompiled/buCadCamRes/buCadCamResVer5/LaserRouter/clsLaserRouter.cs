using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buClass.Apps;
using buComm.FTP;
using buControls.ClassViewer;
using buControls.DialogBox;
using buControls.Forms.WinControlForms.Errors;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.LaserRouter;

public class clsLaserRouter
{
	public static List<string> Captions = new List<string>();

	public static F_PerpendicularSelection FrmPerpendicularSelect = null;

	public static F_RouterOperations FrmRouterWood = null;

	public static F_LaserMaterial FrmLaserMats = null;

	public static F_LaserStartOrder FrmLaserStartOrder = null;

	public List<LaserMaterial> Materials = new List<LaserMaterial>();

	public static LaserProgramSettings varLaserSettings = new LaserProgramSettings();

	public static RouterProgramSettings varRouterSettings = new RouterProgramSettings();

	public static LaserRouterRuntimeSettings varLaserRuntimeSettings = new LaserRouterRuntimeSettings();

	public List<Entity> CamOtherEntities = null;

	public void Init()
	{
		FrmLaserMats = new F_LaserMaterial();
		FrmLaserStartOrder = new F_LaserStartOrder();
		FrmPerpendicularSelect = new F_PerpendicularSelection();
		FrmRouterWood = new F_RouterOperations();
		buMWLaserRouterVars.Init();
		clsInit.appCommand.SetInformationAtStatus(clsInit.appLaserRouter.GetStatusInfo());
	}

	public void cmdRouterCommonOperation(DiemakerType CutType)
	{
		switch (CutType)
		{
		case DiemakerType.WoodChamferTop:
			cmdRouterOperation(CutType, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedWoodChamferTopToolName, ref buMWLaserRouterVars.varCamWoodTop);
			break;
		case DiemakerType.WoodChamferBottom:
			cmdRouterOperation(CutType, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedWoodChamferBottomToolName, ref buMWLaserRouterVars.varCamWoodBottom);
			break;
		case DiemakerType.PertinaxIncut:
			cmdRouterOperation(CutType, PerpendicularSelection: true, ref varLaserRuntimeSettings.LastSelectedPertinaxInCutToolName, ref buMWLaserRouterVars.varCamPertinaxInCut);
			break;
		case DiemakerType.PertinaxOutcut:
			cmdRouterOperation(CutType, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedPertinaxOutCutToolName, ref buMWLaserRouterVars.varCamPertinaxOutCut);
			break;
		case DiemakerType.PertinaxHole:
			cmdRouterOperation(CutType, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedPertinaxHoleToolName, ref buMWLaserRouterVars.varCamPertinaxHoleCut);
			break;
		case DiemakerType.PertinaxAllCut:
			cmdRouterOperation(DiemakerType.PertinaxIncut, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedPertinaxInCutToolName, ref buMWLaserRouterVars.varCamPertinaxInCut);
			cmdRouterOperation(DiemakerType.PertinaxHole, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedPertinaxHoleToolName, ref buMWLaserRouterVars.varCamPertinaxHoleCut);
			cmdRouterOperation(DiemakerType.PertinaxText, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedPertinaxTextToolName, ref buMWLaserRouterVars.varCamPertinaxTextCut);
			cmdRouterOperation(DiemakerType.PertinaxOutcut, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedPertinaxOutCutToolName, ref buMWLaserRouterVars.varCamPertinaxOutCut);
			break;
		case DiemakerType.PertinaxText:
			cmdRouterOperation(CutType, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedPertinaxTextToolName, ref buMWLaserRouterVars.varCamPertinaxTextCut);
			break;
		case DiemakerType.SteelPlateContour:
			cmdRouterOperation(CutType, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedSteelContourToolName, ref buMWLaserRouterVars.varCamSteelContour);
			break;
		case DiemakerType.SteelPlatePocket:
			cmdRouterOperation(CutType, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedSteelPocketToolName, ref buMWLaserRouterVars.varCamSteelPocket);
			break;
		case DiemakerType.SteelPlateText:
			cmdRouterOperation(CutType, PerpendicularSelection: false, ref varLaserRuntimeSettings.LastSelectedSteelTextToolName, ref buMWLaserRouterVars.varCamSteelText);
			break;
		}
	}

	public void cmdRouterOperation(DiemakerType CutType, bool PerpendicularSelection, ref string LastSelectedToolName, ref MWParameters Pars)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			if (PerpendicularSelection)
			{
				FrmPerpendicularSelect.Horizontal = varLaserRuntimeSettings.HorizontalSelection;
				FrmPerpendicularSelect.Vertical = varLaserRuntimeSettings.VerticalSelection;
				FrmPerpendicularSelect.Angle = varLaserRuntimeSettings.AngleSelection;
				FrmPerpendicularSelect.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				FrmPerpendicularSelect.Init();
				FrmPerpendicularSelect.ShowDialog();
				if (FrmPerpendicularSelect.PropertiesForm.Result != DialogResult.OK)
				{
					return;
				}
				varLaserRuntimeSettings.HorizontalSelection = FrmPerpendicularSelect.Horizontal;
				varLaserRuntimeSettings.VerticalSelection = FrmPerpendicularSelect.Vertical;
				varLaserRuntimeSettings.AngleSelection = FrmPerpendicularSelect.Angle;
			}
			if (ccVars.SelectionOP.Selections.Count == 0)
			{
				string text = "";
				for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
				{
					if (ccVars.Pages[ccVars.PageIndex].Layers[i].Diemaker != null && ccVars.Pages[ccVars.PageIndex].Layers[i].Diemaker.Type == CutType)
					{
						text = ccVars.Pages[ccVars.PageIndex].Layers[i].Name;
					}
				}
				List<int> list = new List<int>();
				for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
				{
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].LayerName == text)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].Selected = true;
						list.Add(j);
					}
				}
				if (list.Count > 0)
				{
					clsInit.appCommand.SelectedToSelectionAdd(list);
				}
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			}
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				if (FrmRouterWood != null)
				{
					if (FrmRouterWood.Visible)
					{
						clsInit.appCommand.Reset();
						FrmRouterWood.Visible = false;
						return;
					}
					FrmRouterWood.SelectedToolIndex = ccVars.ToolIndex;
					FrmRouterWood.Tools.Clear();
					FrmRouterWood.Tools = new List<ToolBase5>();
					for (int k = 0; k <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; k++)
					{
						ToolBase5 toolBase = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[k]);
						FrmRouterWood.Tools.Add(toolBase);
						if (toolBase.Data.Name == LastSelectedToolName)
						{
							FrmRouterWood.SelectedToolIndex = k;
						}
					}
					FrmRouterWood.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					FrmRouterWood.varCamPars = new camParameters5(Pars.buPar);
					FrmRouterWood.Init();
					FrmRouterWood.ShowDialog();
					if (FrmRouterWood.PropertiesForm.Result != DialogResult.OK)
					{
						clsInit.appCommand.Reset();
						return;
					}
					Pars.buPar = new camParameters5(FrmRouterWood.varCamPars);
					for (int l = 0; l <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; l++)
					{
						if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[l].Data.Name == FrmRouterWood.ToolSelected.Data.Name)
						{
							ccVars.Tools[ccVars.ToolGroupIndex].Tools[l].CamData = new ToolCamData5(FrmRouterWood.ToolSelected.CamData);
							ccVars.toolActive = new ToolBase5(FrmRouterWood.ToolSelected);
						}
					}
				}
				List<Entity> selectedEntities = new List<Entity>();
				List<Entity> copiedEnt = new List<Entity>();
				SelectionOption selectionOption = new SelectionOption();
				selectionOption.CircleToArc = true;
				selectionOption.CircleTo4Arc = true;
				selectionOption.SplitArcIfGreatThen180 = true;
				selectionOption.Point = false;
				selectionOption.SplitArcIfGreatThenValue = 160.0;
				clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
				clsMW.CamEntities.Clear();
				List<Entity> VerticalEntities = new List<Entity>();
				List<Entity> HorizontalEntities = new List<Entity>();
				List<Entity> OtherEntities = new List<Entity>();
				if (PerpendicularSelection)
				{
					clsInit.cVector5.GetPerpendicularEntities(selectedEntities, ref HorizontalEntities, ref VerticalEntities, ref OtherEntities);
					if (varLaserRuntimeSettings.VerticalSelection)
					{
						buVector5.AddEntities(VerticalEntities, ref copiedEnt);
					}
					if (varLaserRuntimeSettings.HorizontalSelection)
					{
						buVector5.AddEntities(HorizontalEntities, ref copiedEnt);
					}
					if (varLaserRuntimeSettings.AngleSelection)
					{
						buVector5.AddEntities(OtherEntities, ref copiedEnt);
					}
					if (copiedEnt.Count == 0)
					{
						buString5.MessageBoxWarning(AppLanguage.CadCamMessages[7]);
						clsInit.appCommand.Reset();
						return;
					}
				}
				selectedEntities.Clear();
				bool flag = false;
				if (Pars.buPar.Operations.Width > ccVars.toolActive.Geometry.Diameter)
				{
					SortSettings settings = new SortSettings();
					SortResult Result = new SortResult();
					List<Entity> SortedEntities = new List<Entity>();
					clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(), ref copiedEnt, settings, ref SortedEntities, ref Result);
					List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
					clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
					List<List<Point3D>> Points = new List<List<Point3D>>();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites, 0.01, ref Points);
					for (int m = 0; m <= Points.Count - 1; m++)
					{
						List<Pnt3D> CopiedPnt = new List<Pnt3D>();
						List<List<Pnt3D>> OffsetedPoints = new List<List<Pnt3D>>();
						buConversion5.Point3DToPnt3D(Points[m], ref CopiedPnt);
						clsInit.cVector.OffsetContour(CopiedPnt, Pars.buPar.Operations.Width / 2.0, OffsetCornerType.Round, CamOpenContourType2.Closed, new WorkPlane(), 0.0, ref OffsetedPoints);
						if (OffsetedPoints.Count > 0)
						{
							List<Point3D> CopiedPnt2 = new List<Point3D>();
							buConversion5.Pnt3DToPoint3D(OffsetedPoints[0], ref CopiedPnt2);
							clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref CopiedPnt2);
							if (CopiedPnt2.Count > 1)
							{
								LinearPath linearPath = new LinearPath(CopiedPnt2);
								linearPath.Regen(0.01);
								selectedEntities.Add(linearPath);
							}
						}
					}
					flag = true;
					buVector5.CopyEntities(selectedEntities, ref clsMW.CamEntities);
				}
				LastSelectedToolName = ccVars.toolActive.Data.Name;
				camTp Cam = new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
				mWCalculationOptions.Mode = CamMode.WireFrame;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.isBuWireframeCalculation = varRouterSettings.isBuCalculation;
				mWCalculationOptions.AddToCamListInMWCalculation = false;
				mWCalculationOptions.DontShowDialogBox = !varRouterSettings.ShowBuDialog;
				mWCalculationOptions.isBuSort = varRouterSettings.isBuSorting;
				mWCalculationOptions.UseStartPoint = varRouterSettings.UseStartPoint;
				mWCalculationOptions.UseConstantStartPoint = true;
				mWCalculationOptions.StartPointX = varRouterSettings.StartPointX;
				mWCalculationOptions.StartPointY = varRouterSettings.StartPointY;
				mWCalculationOptions.HeightFromEntities = false;
				if (flag)
				{
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
				}
				Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
				Pars.buPar.Offsets.OpenContour = CamOpenContourType.Center;
				Pars.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
				Pars.buPar.Operations.Height = Pars.buPar.Material.Thickness + Pars.buPar.Operations.BaseThickness - Pars.buPar.Operations.Depth;
				Pars.buPar.Distances.EntryAndExit = Pars.buPar.Distances.Rapid;
				Pars.buPar.Distances.Safe = varRouterSettings.SafeDistance;
				Pars.buPar.Distances.RapidRetract = varRouterSettings.RapidRetract;
				Pars.buPar.Distances.Air = Pars.buPar.Distances.Rapid;
				Pars.buPar.Distances.RapidRetract = true;
				Pars.buPar.Speeds.Leave = varRouterSettings.LeaveSpeed;
				Pars.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(Pars.mwPar, Pars.buPar);
				((InterlinkHandeler)Pars.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
				((InterlinkHandeler)Pars.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
				((InterlinkHandeler)Pars.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
				((InterlinkHandeler)Pars.mwPar.MachParam.LinkParams.LinkBetweenSlices).SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
				((InterlinkHandeler)Pars.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
				((InterlinkHandeler)Pars.mwPar.MachParam.LinkParams.LinkBetweenPasses).SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
				Pars.buPar.Steps.StartValue = Pars.buPar.Material.Thickness + Pars.buPar.Operations.BaseThickness;
				Pars.buPar.Steps.EndValue = Pars.buPar.Operations.Height;
				Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices;
				Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep = Pars.buPar.Steps.Count;
				if (Pars.buPar.Steps.Count <= 1)
				{
					Pars.buPar.Steps.Enable = false;
					Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Pars.buPar.Operations.Height;
					Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Pars.buPar.Operations.Height;
				}
				else
				{
					Pars.buPar.Steps.Enable = true;
					Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Pars.buPar.Steps.StartValue;
					Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Pars.buPar.Steps.EndValue;
				}
				Pars.buPar.Operations.Direction = varRouterSettings.InsideCutClosedPatternCutDirection;
				if (!Pars.buPar.Operations.SpiralMode)
				{
					Pars.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeZigzag;
				}
				else
				{
					Pars.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeSpiral;
					Pars.mwPar.MachParam.MachiningAreaMode = MachiningParamsMachiningAreaMode.MachByRegions;
					Pars.mwPar.MachParam.CloseFirstSpiralMachContour = false;
				}
				switch (CutType)
				{
				default:
					doWireframeContourRouter(mWCalculationOptions, ref Pars, flag, ref Cam);
					break;
				case DiemakerType.WoodChamferBottom:
					doWireframeContourRouterWoodBottom(mWCalculationOptions, Pars.mwPar, Pars.buPar, flag, ref Cam);
					break;
				case DiemakerType.PertinaxHole:
					Pars.buPar.Drill.StartHeight = Pars.buPar.Material.Thickness + Pars.buPar.Operations.BaseThickness;
					Pars.buPar.Drill.EndHeight = Pars.buPar.Material.Thickness + Pars.buPar.Operations.BaseThickness - Pars.buPar.Operations.Depth;
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
					mWCalculationOptions.Mode = CamMode.Drill;
					doDrill(mWCalculationOptions, Pars.mwPar, Pars.buPar, ccVars.toolActive, ref Cam);
					break;
				case DiemakerType.SteelPlatePocket:
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
					doWireframeContourRouter(mWCalculationOptions, ref Pars, isPocket: true, ref Cam);
					break;
				}
			}
			else
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[7]);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSettingsRouter()
	{
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.Text = "Router";
		f_ClassViewerDialog.Value = varRouterSettings;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Width = 500;
		f_ClassViewerDialog.Height = 400;
		f_ClassViewerDialog.ValuePersentage = 35.0;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog();
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			varRouterSettings = new RouterProgramSettings((RouterProgramSettings)f_ClassViewerDialog.Value);
			clsFiles.SaveParameter();
		}
	}

	public void cmdShowMaterialPage()
	{
		try
		{
			if (FrmLaserMats == null)
			{
				return;
			}
			if (FrmLaserMats.Visible)
			{
				FrmLaserMats.Visible = false;
				return;
			}
			FrmLaserMats.Materials.Clear();
			FrmLaserMats.Materials = new List<LaserMaterial>();
			for (int i = 0; i <= Materials.Count - 1; i++)
			{
				LaserMaterial item = new LaserMaterial(Materials[i]);
				FrmLaserMats.Materials.Add(item);
			}
			FrmLaserMats.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			FrmLaserMats.pathMaterialFile = varLaserRuntimeSettings.PathMaterialSave;
			FrmLaserMats.SelectedMaterialIndex = varLaserRuntimeSettings.SelectedMaterial;
			FrmLaserMats.Cf2Properties.Clear();
			FrmLaserMats.Cf2Properties = new List<Cf2FileProperties>();
			for (int j = 0; j <= clsVar.Cf2Properties.Count - 1; j++)
			{
				Cf2FileProperties item2 = new Cf2FileProperties(clsVar.Cf2Properties[j]);
				FrmLaserMats.Cf2Properties.Add(item2);
			}
			FrmLaserMats.SelectedMaterialIndex = varLaserRuntimeSettings.SelectedMaterial;
			FrmLaserMats.Init();
			FrmLaserMats.ShowDialog();
			if (FrmLaserMats.PropertiesForm.Result == DialogResult.OK)
			{
				varLaserRuntimeSettings.SelectedMaterial = FrmLaserMats.SelectedMaterialIndex;
				Materials.Clear();
				Materials = new List<LaserMaterial>();
				for (int k = 0; k <= FrmLaserMats.Materials.Count - 1; k++)
				{
					LaserMaterial item3 = new LaserMaterial(FrmLaserMats.Materials[k]);
					Materials.Add(item3);
				}
				varLaserRuntimeSettings.PathMaterialSave = FrmLaserMats.pathMaterialFile;
				clsFiles.SaveParameter();
				clsInit.appCommand.SetInformationAtStatus(clsInit.appLaserRouter.GetStatusInfo());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void cmdCamContour(actionTypeBU Action)
	{
		try
		{
			bool flag = false;
			string text = "";
			double num = -1.0;
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			if (ccVars.SelectionOP.Selections.Count > 0)
			{
				flag = true;
			}
			ccVars.Action = Action;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			List<LaserMaterialData> list = new List<LaserMaterialData>();
			List<LaserMaterialData> list2 = new List<LaserMaterialData>();
			if ((varLaserRuntimeSettings.SelectedMaterial >= 0) & (varLaserRuntimeSettings.SelectedMaterial <= Materials.Count - 1))
			{
				for (int i = 0; i <= Materials[varLaserRuntimeSettings.SelectedMaterial].Orders.Count - 1; i++)
				{
					bool flag2 = false;
					DiemakerType codeType = Materials[varLaserRuntimeSettings.SelectedMaterial].Orders[i].CodeType;
					double ptRealValue = Materials[varLaserRuntimeSettings.SelectedMaterial].Orders[i].PtRealValue;
					if (Materials[varLaserRuntimeSettings.SelectedMaterial].Orders[i].ApplyAll)
					{
						for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
						{
							if (!((ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].EntityData != null) & (!flag | (flag & ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].Selected))) || !((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].EntityData).CamSelectable)
							{
								continue;
							}
							for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; k++)
							{
								if (ccVars.Pages[ccVars.PageIndex].Layers[k].Name == ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].LayerName && ccVars.Pages[ccVars.PageIndex].Layers[k].Diemaker != null && ccVars.Pages[ccVars.PageIndex].Layers[k].Diemaker.Pt == ptRealValue)
								{
									flag2 = true;
								}
							}
						}
					}
					else
					{
						for (int l = 0; l <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; l++)
						{
							if (!((ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l].EntityData != null) & (!flag | (flag & ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l].Selected))))
							{
								continue;
							}
							for (int m = 0; m <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; m++)
							{
								if (ccVars.Pages[ccVars.PageIndex].Layers[m].Name == ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l].LayerName && ccVars.Pages[ccVars.PageIndex].Layers[m].Diemaker != null && ((ccVars.Pages[ccVars.PageIndex].Layers[m].Diemaker.Type == codeType) & (ccVars.Pages[ccVars.PageIndex].Layers[m].Diemaker.Pt == ptRealValue)))
								{
									flag2 = true;
								}
							}
						}
					}
					if (flag2)
					{
						list.Add(new LaserMaterialData(Materials[varLaserRuntimeSettings.SelectedMaterial].Orders[i]));
					}
				}
			}
			if (list.Count <= 0)
			{
				clsInit.appCommand.Reset();
				return;
			}
			if (FrmLaserStartOrder != null)
			{
				if (FrmLaserStartOrder.Visible)
				{
					FrmLaserStartOrder.Visible = false;
				}
				else
				{
					FrmLaserStartOrder.MaterialOrders.Clear();
					FrmLaserStartOrder.MaterialOrders = new List<LaserMaterialData>();
					for (int n = 0; n <= list.Count - 1; n++)
					{
						LaserMaterialData item = new LaserMaterialData(list[n]);
						FrmLaserStartOrder.MaterialOrders.Add(item);
					}
					FrmLaserStartOrder.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					FrmLaserStartOrder.Init();
					FrmLaserStartOrder.ShowDialog();
					if (FrmLaserStartOrder.PropertiesForm.Result != DialogResult.OK)
					{
						clsInit.appCommand.Reset();
						return;
					}
					list.Clear();
					list = new List<LaserMaterialData>();
					for (int num2 = 0; num2 <= FrmLaserStartOrder.MaterialOrders.Count - 1; num2++)
					{
						LaserMaterialData item2 = new LaserMaterialData(FrmLaserStartOrder.MaterialOrders[num2]);
						list.Add(item2);
					}
				}
			}
			buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.LinkParams.ClearancePlaneHeight = 1.0;
			buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.LinkParams.AirMoveSafetyDistance = 1.0;
			buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = 1.0;
			buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.LinkParams.FeedPlaneIncremental = 1.0;
			buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.LinkParams.RetractPlaneIncremental = 1.0;
			buMWLaserRouterVars.varCamLaserWFContour.buPar.Distances.Safe = 1.0;
			buMWLaserRouterVars.varCamLaserWFContour.buPar.Distances.Rapid = 1.0;
			buMWLaserRouterVars.varCamLaserWFContour.buPar.Distances.SafeSmall = 1.0;
			clsInit.appCommand.undoBuffer();
			int count = ccVars.Pages[ccVars.PageIndex].Cams.Count;
			if ((varLaserRuntimeSettings.SelectedMaterial >= 0) & (varLaserRuntimeSettings.SelectedMaterial <= Materials.Count - 1))
			{
				for (int num3 = 0; num3 <= list.Count - 1; num3++)
				{
					if (!list[num3].Enable)
					{
						continue;
					}
					int num4 = 0;
					if ((list[num3].PtRealValue == 3.0) & varLaserSettings.Pt3DoubleCutEnable)
					{
						num4 = 1;
					}
					if ((list[num3].PtRealValue == 4.0) & varLaserSettings.Pt4DoubleCutEnable)
					{
						num4 = 1;
					}
					if ((list[num3].PtRealValue == 6.0) & varLaserSettings.Pt6DoubleCutEnable)
					{
						num4 = 1;
					}
					if (list[num3].PtRealValue == 1.0)
					{
						ccVars.toolActive.Geometry.Diameter = varLaserSettings.Pt1ThicknessValue / 2.0;
					}
					if (list[num3].PtRealValue == 2.0)
					{
						ccVars.toolActive.Geometry.Diameter = varLaserSettings.Pt2ThicknessValue / 2.0;
					}
					if (list[num3].PtRealValue == 3.0)
					{
						ccVars.toolActive.Geometry.Diameter = varLaserSettings.Pt3ThicknessValue / 2.0;
					}
					if (list[num3].PtRealValue == 4.0)
					{
						ccVars.toolActive.Geometry.Diameter = varLaserSettings.Pt4ThicknessValue / 2.0;
					}
					if (list[num3].PtRealValue == 6.0)
					{
						ccVars.toolActive.Geometry.Diameter = varLaserSettings.Pt6ThicknessValue / 2.0;
					}
					for (int num5 = 0; num5 <= num4; num5++)
					{
						if (num4 != 0)
						{
							if (num5 == 0)
							{
								buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft;
								buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.OpenContour = CamOpenContourType.Left;
								buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
							}
							if (num5 == 1)
							{
								buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsRight;
								buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.OpenContour = CamOpenContourType.Right;
								buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.ClosedContour = CamClosedContourType.Outter;
							}
						}
						else
						{
							buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
							buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
							buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
						}
						bool flag3 = false;
						DiemakerType codeType2 = list[num3].CodeType;
						double ptRealValue2 = list[num3].PtRealValue;
						buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.FeedRate = list[num3].FeedXPlus;
						buMWLaserRouterVars.varCamLaserWFContour.buPar.Speeds.Feed = list[num3].FeedXPlus;
						if (list[num3].ApplyAll)
						{
							for (int num6 = 0; num6 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; num6++)
							{
								if (!((ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num6].EntityData != null) & (!flag | (flag & ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num6].Selected))) || !((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num6].EntityData).CamSelectable)
								{
									continue;
								}
								for (int num7 = 0; num7 <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; num7++)
								{
									if (ccVars.Pages[ccVars.PageIndex].Layers[num7].Name == ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num6].LayerName && ccVars.Pages[ccVars.PageIndex].Layers[num7].Diemaker != null && ccVars.Pages[ccVars.PageIndex].Layers[num7].Diemaker.Pt == ptRealValue2)
									{
										ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num6].Selected = true;
										text = ccVars.Pages[ccVars.PageIndex].Layers[num7].Diemaker.Type.ToString();
										num = ccVars.Pages[ccVars.PageIndex].Layers[num7].Diemaker.Pt;
										flag3 = true;
									}
								}
							}
						}
						else
						{
							for (int num8 = 0; num8 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; num8++)
							{
								if (!((ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num8].EntityData != null) & (!flag | (flag & ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num8].Selected))))
								{
									continue;
								}
								for (int num9 = 0; num9 <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; num9++)
								{
									if (ccVars.Pages[ccVars.PageIndex].Layers[num9].Name == ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num8].LayerName && ccVars.Pages[ccVars.PageIndex].Layers[num9].Diemaker != null && ((ccVars.Pages[ccVars.PageIndex].Layers[num9].Diemaker.Type == codeType2) & (ccVars.Pages[ccVars.PageIndex].Layers[num9].Diemaker.Pt == ptRealValue2)))
									{
										ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num8].Selected = true;
										text = ccVars.Pages[ccVars.PageIndex].Layers[num9].Diemaker.Type.ToString();
										num = ccVars.Pages[ccVars.PageIndex].Layers[num9].Diemaker.Pt;
										flag3 = true;
									}
								}
							}
						}
						if (!flag3)
						{
							continue;
						}
						for (int num10 = 0; num10 <= clsVar.Cf2Properties.Count - 1; num10++)
						{
							if (((clsVar.Cf2Properties[num10].CodeType.ToString() == text) & (clsVar.Cf2Properties[num10].PtIndex == num)) && clsVar.Cf2Properties[num10].ToolNo > 0)
							{
								ccVars.toolActive.Data.No = clsVar.Cf2Properties[num10].ToolNo;
							}
						}
						list2.Add(new LaserMaterialData(list[num3]));
						ccVars.UndoDont = true;
						camTp Cam = new camTp();
						MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
						mWCalculationOptions.NumberofAxis = 3;
						mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
						mWCalculationOptions.Mode = CamMode.WireFrame;
						mWCalculationOptions.DontApplyReset = true;
						mWCalculationOptions.isBuWireframeCalculation = varLaserSettings.isBuCalculation;
						mWCalculationOptions.AddToCamListInMWCalculation = false;
						mWCalculationOptions.DontShowDialogBox = true;
						mWCalculationOptions.isBuSort = varLaserSettings.isBuSorting;
						mWCalculationOptions.UseStartPoint = varLaserSettings.UseStartPoint;
						mWCalculationOptions.UseConstantStartPoint = true;
						mWCalculationOptions.StartPointX = 0.0;
						mWCalculationOptions.StartPointY = 0.0;
						doWireframeContourLaser(mWCalculationOptions, ref Cam);
					}
				}
				for (int num11 = 0; num11 <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; num11++)
				{
					for (int num12 = 0; num12 <= ccVars.Pages[ccVars.PageIndex].Cams[num11].CamPoints.Count - 1; num12++)
					{
						ccVars.Pages[ccVars.PageIndex].Cams[num11].CamPoints[num12].Points[0].Type = 0;
						for (int num13 = ccVars.Pages[ccVars.PageIndex].Cams[num11].CamPoints[num12].Points.Count - 1; num13 >= 0; num13--)
						{
							if (ccVars.Pages[ccVars.PageIndex].Cams[num11].CamPoints[num12].Points[num13].PlungeAxisMovement)
							{
								ccVars.Pages[ccVars.PageIndex].Cams[num11].CamPoints[num12].Points.RemoveAt(num13);
							}
						}
					}
				}
				int num14 = 0;
				for (int num15 = count; num15 <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; num15++)
				{
					double num16 = 0.0;
					double num17 = 0.0;
					double num18 = 0.0;
					double num19 = 0.0;
					double num20 = 0.0;
					double num21 = 0.0;
					double num22 = 0.0;
					LaserMaterialData laserMaterialData = new LaserMaterialData(list2[num14]);
					ccVars.Pages[ccVars.PageIndex].Cams[num15].PreCodes.Add("M40 K" + laserMaterialData.Height);
					double num23 = 9999999999.0;
					for (int num24 = 0; num24 <= ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints.Count - 1; num24++)
					{
						if (laserMaterialData.Acceleration > 0.0)
						{
							ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].PreCodes.Add("M15 K" + laserMaterialData.Acceleration);
						}
						if (laserMaterialData.Jerk > 0.0)
						{
							ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].PreCodes.Add("M16 K" + laserMaterialData.Jerk);
						}
						num18 += laserMaterialData.PowerDelayTime / 1000.0;
						num19 += laserMaterialData.PowerStopTime / 1000.0;
						if (!(laserMaterialData.PtRealValue <= 3.0))
						{
							ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].PreCodes.Add("M10 K" + Convert.ToInt32(laserMaterialData.PtRealValue / 2.0));
						}
						else
						{
							ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].PreCodes.Add("M10 K" + laserMaterialData.PtRealValue);
						}
						ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].PreCodes.Add("M6 K" + laserMaterialData.PowerDelayTime);
						ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].PreCodes.Add("M7 K" + laserMaterialData.PowerStopTime);
						ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].PreCodes.Add("M20 K" + laserMaterialData.FocusXPlus);
						ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].PreCodes.Add("M4 K" + (Convert.ToInt32(laserMaterialData.LaserSelect) + 1));
						for (int num25 = 0; num25 <= ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points.Count - 1; num25++)
						{
							if (ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Type == 0)
							{
								ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].AfterCodes.Add("M3 K" + laserMaterialData.CuttingPower);
								num20 += varLaserSettings.LaserStartTime / 1000.0;
								if (num25 > 0)
								{
									Pnt3D startPoint = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25 - 1].P9);
									Pnt3D endPoint = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].P9);
									double num26 = clsInit.cVector.Length3D(startPoint, endPoint, new WorkPlane());
									double num27 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(varLaserSettings.G0FeedMmperSec, num26, laserMaterialData.Acceleration, laserMaterialData.Acceleration);
									num17 += num27;
									num22 += num26;
								}
							}
							if (ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Type == 1 && num25 > 0)
							{
								Pnt3D pnt3D = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25 - 1].P9);
								Pnt3D pnt3D2 = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].P9);
								double num28 = clsInit.cVector.Length3D(pnt3D, pnt3D2, new WorkPlane());
								double angle = clsInit.cVector.PointAngle(pnt3D2, pnt3D);
								double calcValue = 0.0;
								CalcValueFromAngleQuadrantAsValue(angle, laserMaterialData.FeedXPlus, laserMaterialData.FeedXMinus, laserMaterialData.FeedYPlus, laserMaterialData.FeedYMinus, ref calcValue);
								if (calcValue > 0.0)
								{
									ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Feed = calcValue;
								}
								double num29 = num28 / ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Feed;
								num16 += num29;
								num21 += num28;
								calcValue = 0.0;
								CalcValueFromAngleQuadrantAsValue(angle, laserMaterialData.FocusXPlus, laserMaterialData.FocusXMinus, laserMaterialData.FocusYPlus, laserMaterialData.FocusYMinus, ref calcValue);
								if (calcValue != 0.0 && calcValue != num23)
								{
									ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].PreCodes.Add("M21 K" + Math.Round(calcValue, 2));
									num23 = calcValue;
								}
							}
							if (ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Type == 2)
							{
								if (laserMaterialData.FeedXY > 0.0)
								{
									ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Feed = laserMaterialData.FeedXY;
								}
								if (num25 > 0)
								{
									Pnt3D ArcCenter = new Pnt3D();
									double ArcSA = 0.0;
									double ArcEA = 0.0;
									double radius = ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Radius;
									if (radius != 0.0)
									{
										Pnt3D arcStartPoint = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25 - 1].P9);
										Pnt3D arcEndPoint = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].P9);
										if (radius > 0.0)
										{
											clsInit.cVector.ArcWithTwoPointAndRadius(arcStartPoint, arcEndPoint, Math.Abs(radius), CW: true, new WorkPlane(), ref ArcCenter, ref ArcSA, ref ArcEA);
										}
										if (radius < 0.0)
										{
											clsInit.cVector.ArcWithTwoPointAndRadius(arcStartPoint, arcEndPoint, Math.Abs(radius), CW: true, new WorkPlane(), ref ArcCenter, ref ArcSA, ref ArcEA);
											if (ArcEA - ArcSA < 180.0)
											{
												buGeneral.ExchangeDatas(ref ArcSA, ref ArcEA);
											}
											if (ArcSA > ArcEA)
											{
												ArcEA += 360.0;
											}
										}
										double num30 = clsInit.cVector.ArcCircumference(Math.Abs(radius), ArcSA, ArcEA);
										double num31 = num30 / ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Feed;
										num16 += num31;
										num21 += num30;
									}
									double focusXY = laserMaterialData.FocusXY;
									if (focusXY != 0.0 && focusXY != num23)
									{
										ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].PreCodes.Add("M21 K" + Math.Round(focusXY, 2));
										num23 = focusXY;
									}
								}
							}
							if (ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Type == 3)
							{
								if (laserMaterialData.FeedXY > 0.0)
								{
									ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Feed = laserMaterialData.FeedXY;
								}
								if (num25 > 0)
								{
									Pnt3D ArcCenter2 = new Pnt3D();
									double ArcSA2 = 0.0;
									double ArcEA2 = 0.0;
									double radius2 = ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Radius;
									if (radius2 != 0.0)
									{
										Pnt3D arcStartPoint2 = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25 - 1].P9);
										Pnt3D arcEndPoint2 = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].P9);
										if (radius2 > 0.0)
										{
											clsInit.cVector.ArcWithTwoPointAndRadius(arcStartPoint2, arcEndPoint2, Math.Abs(radius2), CW: false, new WorkPlane(), ref ArcCenter2, ref ArcSA2, ref ArcEA2);
										}
										if (radius2 < 0.0)
										{
											clsInit.cVector.ArcWithTwoPointAndRadius(arcStartPoint2, arcEndPoint2, Math.Abs(radius2), CW: false, new WorkPlane(), ref ArcCenter2, ref ArcSA2, ref ArcEA2);
											if (ArcEA2 - ArcSA2 < 180.0)
											{
												buGeneral.ExchangeDatas(ref ArcSA2, ref ArcEA2);
											}
											if (ArcSA2 > ArcEA2)
											{
												ArcEA2 += 360.0;
											}
										}
										double num32 = clsInit.cVector.ArcCircumference(Math.Abs(radius2), ArcSA2, ArcEA2);
										double num33 = num32 / ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Feed;
										num16 += num33;
										num21 += num32;
									}
									double focusXY2 = laserMaterialData.FocusXY;
									if (focusXY2 != 0.0 && focusXY2 != num23)
									{
										ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].PreCodes.Add("M21 K" + Math.Round(focusXY2, 2));
										num23 = focusXY2;
									}
								}
							}
							if (num25 >= ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points.Count - 1)
							{
								if ((ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Type == 1) | (ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Type == 2) | (ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Type == 3))
								{
									num20 += varLaserSettings.LaserStopTime / 1000.0;
									ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].AfterCodes.Add("M5");
								}
							}
							else if (((ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Type == 1) | (ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Type == 2) | (ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].Type == 3)) && ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25 + 1].Type == 0)
							{
								num20 += varLaserSettings.LaserStopTime / 1000.0;
								ccVars.Pages[ccVars.PageIndex].Cams[num15].CamPoints[num24].Points[num25].AfterCodes.Add("M5");
							}
						}
					}
					ccVars.Pages[ccVars.PageIndex].Cams[num15].Information.AirMoveSecond = num17;
					ccVars.Pages[ccVars.PageIndex].Cams[num15].Information.ProcessSecond = num16;
					ccVars.Pages[ccVars.PageIndex].Cams[num15].Information.TotalSecond = num17 + num16 + num20;
					ccVars.Pages[ccVars.PageIndex].Cams[num15].Information.StartSecond = num18;
					ccVars.Pages[ccVars.PageIndex].Cams[num15].Information.EndSecond = num19;
					ccVars.Pages[ccVars.PageIndex].Cams[num15].Information.TotalProcessLength = num21;
					ccVars.Pages[ccVars.PageIndex].Cams[num15].Information.AirMoveLength = num22;
					ccVars.Pages[ccVars.PageIndex].Cams[num15].Information.TotalLength = num21 + num22;
					num14++;
				}
			}
			clsInit.appCommand.SetInformationAtStatus(clsInit.appLaserRouter.GetStatusInfo());
			ccVars.UndoDont = false;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSettingsLaser()
	{
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.Text = "Laser";
		f_ClassViewerDialog.Value = varLaserSettings;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Width = 500;
		f_ClassViewerDialog.Height = 400;
		f_ClassViewerDialog.ValuePersentage = 35.0;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog();
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			varLaserSettings = new LaserProgramSettings((LaserProgramSettings)f_ClassViewerDialog.Value);
			clsFiles.SaveParameter();
		}
	}

	public void cmdCamCreatGCode()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
					saveFileDialog.Filter = ccVars.PostActive.FileExplanation + " (" + ccVars.PostActive.FileExtension + ")|" + ccVars.PostActive.FileExtension;
					saveFileDialog.FilterIndex = 1;
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
						string Lines = "";
						PostProcessor postProcessor = new PostProcessor(ccVars.PostActive);
						if (clsVar.appModes_0.LaserRouterDiamekerMode.Laser)
						{
							string value = "//" + Materials[varLaserRuntimeSettings.SelectedMaterial].Name;
							postProcessor.StartLines.Insert(0, value);
						}
						clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, postProcessor, ref Lines);
						buFile5.SaveToFile(Lines, saveFileDialog.FileName);
						clsFiles.SaveParameter();
						if (clsItem.FrmProgress != null)
						{
							clsItem.FrmProgress.Visible = false;
						}
					}
				}
				else
				{
					buString.MessageBoxWarning(AppLanguage.Messages[9]);
				}
			}
			else
			{
				MessageBox.Show("Not Available in Demo Mode");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamCreatPlt()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
					saveFileDialog.Filter = "Plt File (*.plt)|*.plt";
					saveFileDialog.FilterIndex = 1;
					if (saveFileDialog.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; i++)
					{
						ccVars.Pages[ccVars.PageIndex].Cams[i].AfterCodes.Clear();
						ccVars.Pages[ccVars.PageIndex].Cams[i].PreCodes.Clear();
						for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Cams[i].CamPoints.Count - 1; j++)
						{
							ccVars.Pages[ccVars.PageIndex].Cams[i].CamPoints[j].AfterCodes.Clear();
							ccVars.Pages[ccVars.PageIndex].Cams[i].CamPoints[j].PreCodes.Clear();
							for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Cams[i].CamPoints[j].Points.Count - 1; k++)
							{
								ccVars.Pages[ccVars.PageIndex].Cams[i].CamPoints[j].Points[k].PreCodes.Clear();
								ccVars.Pages[ccVars.PageIndex].Cams[i].CamPoints[j].Points[k].AfterCodes.Clear();
							}
						}
					}
					ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Add("IN");
					ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add("PU 0,0IN");
					clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
					new PostProcessor(ccVars.PostActive);
					buFile5.HPGLFile hPGLFile = new buFile5.HPGLFile();
					hPGLFile.WriteHPGL(saveFileDialog.FileName, clsVar.varFile.HPGLFileProperties, ccVars.Pages[ccVars.PageIndex].Cams);
					clsFiles.SaveParameter();
					if (clsItem.FrmProgress != null)
					{
						clsItem.FrmProgress.Visible = false;
					}
				}
				else
				{
					buString.MessageBoxWarning(AppLanguage.Messages[9]);
				}
			}
			else
			{
				MessageBox.Show("Not Available in Demo Mode");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamShowGCode()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					string Lines = "";
					PostProcessor postProcessor = new PostProcessor(ccVars.PostActive);
					if (clsVar.appModes_0.LaserRouterDiamekerMode.Laser)
					{
						string value = "//" + Materials[varLaserRuntimeSettings.SelectedMaterial].Name;
						postProcessor.StartLines.Insert(0, value);
					}
					clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, postProcessor, ref Lines);
					F_Notepad f_Notepad = new F_Notepad();
					f_Notepad.Init(Lines);
					f_Notepad.Show();
					if (clsItem.FrmProgress != null)
					{
						clsItem.FrmProgress.Visible = false;
					}
				}
				else
				{
					buString.MessageBoxWarning(AppLanguage.Messages[9]);
				}
			}
			else
			{
				MessageBox.Show("Not Available in Demo Mode");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamSendController()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					string Lines = "";
					PostProcessor postProcessor = new PostProcessor(ccVars.PostActive);
					if (clsVar.appModes_0.LaserRouterDiamekerMode.Laser)
					{
						string value = "//" + Materials[varLaserRuntimeSettings.SelectedMaterial].Name;
						postProcessor.StartLines.Insert(0, value);
					}
					clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, postProcessor, ref Lines);
					DirectoryInfo directoryInfo = new DirectoryInfo(clsVar.varInterface.pathGCode);
					if (!directoryInfo.Exists)
					{
						FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
						folderBrowserDialog.ShowDialog();
						clsVar.varInterface.pathGCode = folderBrowserDialog.SelectedPath;
					}
					buFile5.SaveToFile(Lines, clsVar.varInterface.pathGCode + "\\AutoLaser.cnc");
					clsFiles.SaveParameter();
					if (clsItem.FrmProgress != null)
					{
						clsItem.FrmProgress.Visible = false;
					}
					clsInit.appCommand.cmdCamRemoveAll(DontAskQuestion: true);
				}
				else
				{
					buString.MessageBoxWarning(AppLanguage.Messages[9]);
				}
			}
			else
			{
				MessageBox.Show("Not Available in Demo Mode");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void SentToController(string FileName)
	{
		FTPConnect fTPConnect = new FTPConnect();
		FTPConnect.ftpConnectionProperties.IP = clsVar.varCommunication.IPNumber;
		FTPConnect.ftpConnectionProperties.UserName = clsVar.varCommunication.FtpUser;
		FTPConnect.ftpConnectionProperties.Password = clsVar.varCommunication.FtpPassword;
		FTPConnect.ftpConnectionProperties.Port = clsVar.varCommunication.FtpPort;
		fTPConnect.FtpClientConnect();
		if (!fTPConnect.FtpClientFileTransfer(FileName, clsVar.varCommunication.FtpPath + "\\AutoLaser.cnc"))
		{
			buString5.MessageBoxError("FileTransfer Error");
		}
	}

	public void cmdSelectRules()
	{
		F_LayerList f_LayerList = new F_LayerList();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
		{
			f_LayerList.Layers.Add(ccVars.Pages[ccVars.PageIndex].Layers[i]);
		}
		if (f_LayerList.Layers.Count <= 0)
		{
			return;
		}
		f_LayerList.Text = "Select Rule";
		f_LayerList.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
		f_LayerList.Init();
		f_LayerList.ShowDialog();
		if (f_LayerList.PropertiesForm.Result != DialogResult.OK)
		{
			return;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
		List<int> list = new List<int>();
		if (f_LayerList.SelectedLayerIndex >= 0)
		{
			string name = f_LayerList.Layers[f_LayerList.SelectedLayerIndex].Name;
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].LayerName == name)
				{
					bool flag = true;
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].GetType() == typeof(buArcCam))
					{
						flag = false;
					}
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].GetType() == typeof(buLineCam))
					{
						flag = false;
					}
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].GetType() == typeof(buLinearPathCam))
					{
						flag = false;
					}
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].GetType() == typeof(buCompositeCurveCam))
					{
						flag = false;
					}
					if (flag)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].Selected = true;
						list.Add(j);
					}
				}
			}
		}
		if (list.Count > 0)
		{
			clsInit.appCommand.SelectedToSelectionAdd(list);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdChangeRuleType()
	{
		try
		{
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				F_LayerList f_LayerList = new F_LayerList();
				for (int i = 0; i <= clsVar.Cf2Properties.Count - 1; i++)
				{
					LayerBase5 layerBase = new LayerBase5();
					layerBase.LayerColor = clsVar.Cf2Properties[i].Color;
					layerBase.Name = clsVar.Cf2Properties[i].CodeType.ToString() + "-" + clsVar.Cf2Properties[i].PtRealValue + "Pt";
					layerBase.Diemaker = new LayerDiemakerProps();
					layerBase.Diemaker.Pt = clsVar.Cf2Properties[i].PtRealValue;
					layerBase.Diemaker.Type = clsVar.Cf2Properties[i].CodeType;
					layerBase.Selectable = clsVar.Cf2Properties[i].Selectable;
					f_LayerList.Layers.Add(layerBase);
				}
				if (f_LayerList.Layers.Count <= 0)
				{
					return;
				}
				f_LayerList.Text = "Rule Change";
				f_LayerList.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_LayerList.Init();
				f_LayerList.ShowDialog();
				if (f_LayerList.PropertiesForm.Result == DialogResult.OK)
				{
					if (f_LayerList.SelectedLayerIndex >= 0)
					{
						LayerBase5 layerBase2 = new LayerBase5(f_LayerList.Layers[f_LayerList.SelectedLayerIndex]);
						bool flag = false;
						string layerName = "";
						bool setValue = true;
						for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
						{
							if (ccVars.Pages[ccVars.PageIndex].Layers[j].Diemaker.Pt == layerBase2.Diemaker.Pt && ccVars.Pages[ccVars.PageIndex].Layers[j].Diemaker.Type == layerBase2.Diemaker.Type)
							{
								flag = true;
								layerName = ccVars.Pages[ccVars.PageIndex].Layers[j].Name;
								setValue = ccVars.Pages[ccVars.PageIndex].Layers[j].Selectable;
							}
						}
						if (!flag)
						{
							ccVars.Pages[ccVars.PageIndex].Layers.Add(layerBase2);
							Layer eyeLayer = null;
							buConversion5.buLayerToeyeLayer(layerBase2, ref eyeLayer);
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(eyeLayer);
							layerName = layerBase2.Name;
							setValue = layerBase2.Selectable;
						}
						string name = f_LayerList.Layers[f_LayerList.SelectedLayerIndex].Name;
						for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; k++)
						{
							if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected)
							{
								ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].LayerName = name;
								ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Color = f_LayerList.Layers[f_LayerList.SelectedLayerIndex].LayerColor;
								ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].LineWeight = f_LayerList.Layers[f_LayerList.SelectedLayerIndex].LayerThickness;
								ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = false;
							}
						}
						clsInit.cVector5.SetSelectableByLayerName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, setValue, layerName);
					}
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved();
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
					clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, FillLayer: true, -1);
					clsInit.appCommand.Reset();
				}
				else
				{
					clsInit.appCommand.Reset();
				}
			}
			else
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[7]);
			}
		}
		catch (Exception mSException)
		{
			string text = "cmdChangeRuleType";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void cmdShowInformation()
	{
		string text = "";
		text = GetStatusFullInfo(MultiLine: true);
		DialogBoxMultiText dialogBoxMultiText = new DialogBoxMultiText();
		dialogBoxMultiText.Value = text;
		dialogBoxMultiText.Text = "Information";
		dialogBoxMultiText.Init(text);
		dialogBoxMultiText.ShowDialog();
	}

	public void cmdRotate()
	{
		List<int> list = new List<int>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
			list.Add(i);
		}
		if (list.Count > 0)
		{
			clsInit.appCommand.SelectedToSelectionAdd(list);
			clsInit.appCommand.Rotate(new Point3D(), Utility.DegToRad(90.0), DeleteOriginal: true, CommandRepat: false);
		}
	}

	public void cmdMirror()
	{
		List<int> list = new List<int>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
			list.Add(i);
		}
		if (list.Count > 0)
		{
			clsInit.appCommand.SelectedToSelectionAdd(list);
			clsInit.appCommand.Mirror(new Point3D(), new Point3D(0.0, 100.0, 0.0), DeleteOriginal: true, CommandRepat: false, ApplyReset: true);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved();
			list = new List<int>();
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].Selected = true;
				list.Add(j);
			}
			clsInit.appCommand.SelectedToSelectionAdd(list);
			clsInit.appCommand.Move(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.BoxMin, new Point3D());
		}
	}

	public void cmdMoveZero()
	{
		List<int> list = new List<int>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
			list.Add(i);
		}
		if (list.Count > 0)
		{
			Point3D MinPoint = new Point3D();
			Point3D MidPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
			clsInit.appCommand.SelectedToSelectionAdd(list);
			clsInit.appCommand.Move(MinPoint, new Point3D());
		}
	}

	public void cmdMoveZeroPoint()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.eventMovePointToZero;
			dynamicInfo.Command = AppLanguage.CadCamStatus[123];
			ccVars.selectionProcess = false;
			ccVars.stpDrawing = 1;
			clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void LoadLanguage()
	{
		List<string> CalcList = new List<string>();
		FileInfo fileInfo = null;
		fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buLaser.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buLaser.lng"));
		if (!fileInfo.Exists)
		{
			buLog.addLog("LaserLanguage", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buString.MessageBoxError("Laser Language File Missing");
		}
		else
		{
			List<string> StringList = new List<string>();
			buFile.OpenFromFile(fileInfo.FullName, ref StringList);
			buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Main>", "</F_Main>", StringList), clsVar.varRuntime.Language, ref CalcList);
			buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MaterialSettings>", "</MaterialSettings>", StringList), clsVar.varRuntime.Language, ref F_LaserMaterial.Captions);
			buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_LaserStartOrder>", "</F_LaserStartOrder>", StringList), clsVar.varRuntime.Language, ref F_LaserStartOrder.Captions);
			StringList.Clear();
		}
		if (CalcList.Count <= 0)
		{
		}
	}

	public void CalcValueFromAngleQuadrantAsRatio(double Angle, double Value, double XPlusRatio, double XMinusRatio, double YPlusRatio, double YMinusRatio, ref double calcValue)
	{
		double X = 1.0;
		if (!(Angle >= 0.0 && Angle <= 90.0))
		{
			if (!(Angle >= 90.0 && Angle <= 180.0))
			{
				if (!(Angle >= 180.0 && Angle <= 270.0))
				{
					if (Angle >= 270.0 && Angle <= 360.0)
					{
						buNumeric.EquationLineer(XPlusRatio, YMinusRatio, 270.0, 360.0, Angle, ref X);
					}
				}
				else
				{
					buNumeric.EquationLineer(XMinusRatio, YMinusRatio, 180.0, 270.0, Angle, ref X);
				}
			}
			else
			{
				buNumeric.EquationLineer(XMinusRatio, YPlusRatio, 90.0, 180.0, Angle, ref X);
			}
		}
		else
		{
			buNumeric.EquationLineer(XPlusRatio, YPlusRatio, 0.0, 90.0, Angle, ref X);
		}
		calcValue = X * Value;
	}

	public void CalcValueFromAngleQuadrantAsValue(double Angle, double XPlusValue, double XMinusValue, double YPlusValue, double YMinusValue, ref double calcValue)
	{
		double X = 1.0;
		if (!(Angle >= 0.0 && Angle <= 90.0))
		{
			if (!(Angle >= 90.0 && Angle <= 180.0))
			{
				if (!(Angle >= 180.0 && Angle <= 270.0))
				{
					if (Angle >= 270.0 && Angle <= 360.0)
					{
						buNumeric.EquationLineer(YMinusValue, XPlusValue, 270.0, 360.0, Angle, ref X);
					}
				}
				else
				{
					buNumeric.EquationLineer(XMinusValue, YMinusValue, 180.0, 270.0, Angle, ref X);
				}
			}
			else
			{
				buNumeric.EquationLineer(YPlusValue, XMinusValue, 90.0, 180.0, Angle, ref X);
			}
		}
		else
		{
			buNumeric.EquationLineer(XPlusValue, YPlusValue, 0.0, 90.0, Angle, ref X);
		}
		calcValue = X;
	}

	public void SaveLaserFile()
	{
		string fileName = AppPath.Settings + "\\Laser\\Laser.prm";
		ArrayList arrayList = new ArrayList();
		arrayList.Add("<LaserMaterials>");
		for (int i = 0; i <= Materials.Count - 1; i++)
		{
			arrayList.Add("  <LaserMaterial>");
			arrayList.Add("    " + Materials[i].Name);
			for (int j = 0; j <= Materials[i].Orders.Count - 1; j++)
			{
				arrayList.AddRange(Materials[i].Orders[j].ToDefAll("", 4, SerilizationMode.MultiLine));
			}
			arrayList.Add("  </LaserMaterial>");
		}
		arrayList.Add("</LaserMaterials>");
		arrayList.Add("<Cf2Props>");
		for (int k = 0; k <= clsVar.Cf2Properties.Count - 1; k++)
		{
			arrayList.AddRange(clsVar.Cf2Properties[k].ToDefAll("", 2, SerilizationMode.MultiLine));
		}
		arrayList.Add("</Cf2Props>");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Router Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<RouterSettings>");
		arrayList.AddRange(varRouterSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
		arrayList.Add("</RouterSettings>");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Laser Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<LaserSettings>");
		arrayList.AddRange(varLaserSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
		arrayList.Add("</LaserSettings>");
		arrayList.Add("<LaserRuntimeSettings>");
		arrayList.AddRange(varLaserRuntimeSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
		arrayList.Add("</LaserRuntimeSettings>");
		buFile.SaveToFile(arrayList, fileName);
		buLog.addLog("Laser Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		buMWLaserRouterVars.varCamWoodTop.mwPar.Serialize(AppPath.Settings + "\\Laser\\mwRouterWoodTop.bin");
		buMWLaserRouterVars.varCamWoodBottom.mwPar.Serialize(AppPath.Settings + "\\Laser\\mwRouterWoodBottom.bin");
		buMWLaserRouterVars.varCamPertinaxInCut.mwPar.Serialize(AppPath.Settings + "\\Laser\\mwRouterPertinaxIncut.bin");
		buMWLaserRouterVars.varCamPertinaxOutCut.mwPar.Serialize(AppPath.Settings + "\\Laser\\mwRouterPertinaxOutcut.bin");
		buMWLaserRouterVars.varCamPertinaxHoleCut.mwPar.Serialize(AppPath.Settings + "\\Laser\\mwRouterPertinaxHole.bin");
		buMWLaserRouterVars.varCamPertinaxTextCut.mwPar.Serialize(AppPath.Settings + "\\Laser\\mwRouterPertinaxText.bin");
		buMWLaserRouterVars.varCamSteelContour.mwPar.Serialize(AppPath.Settings + "\\Laser\\mwRouterSteelContour.bin");
		buMWLaserRouterVars.varCamSteelPocket.mwPar.Serialize(AppPath.Settings + "\\Laser\\mwRouterSteelPocket.bin");
		buMWLaserRouterVars.varCamSteelText.mwPar.Serialize(AppPath.Settings + "\\Laser\\mwRouterSteelText.bin");
		buMWLaserRouterVars.varCamLaserWFContour.mwPar.Serialize(AppPath.Settings + "\\Laser\\mwLaserContour.bin");
		string fileName2 = AppPath.Settings + "\\Laser\\RouterCam.bucamset";
		arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   MW Cam Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<MwCamSettings>");
		arrayList.AddRange(buMWLaserRouterVars.varCamWoodTop.buPar.ToDefAll("_varbuRouterCamWoodTopPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWLaserRouterVars.varCamWoodBottom.buPar.ToDefAll("_varbuRouterCamWoodBottomPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWLaserRouterVars.varCamPertinaxInCut.buPar.ToDefAll("_varbuRouterCamPertinaxIncutPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWLaserRouterVars.varCamPertinaxOutCut.buPar.ToDefAll("_varbuRouterCamPertinaxOutcutPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWLaserRouterVars.varCamPertinaxHoleCut.buPar.ToDefAll("_varbuRouterCamPertinaxHolePars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWLaserRouterVars.varCamPertinaxTextCut.buPar.ToDefAll("_varbuRouterCamPertinaxTextPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWLaserRouterVars.varCamSteelContour.buPar.ToDefAll("_varbuRouterCamSteelContourPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWLaserRouterVars.varCamSteelPocket.buPar.ToDefAll("_varbuRouterCamSteelPocketPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWLaserRouterVars.varCamSteelText.buPar.ToDefAll("_varbuRouterCamSteelTextPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWLaserRouterVars.varCamLaserWFContour.buPar.ToDefAll("_varCamLaserWFContour", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</MwCamSettings>");
		buFile.SaveToFile(arrayList, fileName2);
	}

	public void OpenLaserFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Laser\\Laser.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			Materials = new List<LaserMaterial>();
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Laser Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Laser Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<LaserSettings>", "</LaserSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, varLaserSettings);
						buLog.addLog("LaserSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<RouterSettings>", "</RouterSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, varRouterSettings);
						buLog.addLog("RouterSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<LaserRuntimeSettings>", "</LaserRuntimeSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, varLaserRuntimeSettings);
						buLog.addLog("LaserRuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					List<List<string>> CalcList2 = new List<List<string>>();
					buString.ListToSpecificList("<LaserMaterial>", "</LaserMaterial>", AddStartEndKey: true, arrayList, ref CalcList2);
					if (CalcList2.Count > 0)
					{
						for (int i = 0; i <= CalcList2.Count - 1; i++)
						{
							LaserMaterial laserMaterial = new LaserMaterial();
							laserMaterial.Name = CalcList2[i][1];
							buSerilization.Decode(CalcList2[i], "", SerilizationMode.MultiLine, laserMaterial);
							List<List<string>> CalcList3 = new List<List<string>>();
							buString.ListToSpecificList("<LaserMaterialData>", "</LaserMaterialData>", AddStartEndKey: true, CalcList2[i], ref CalcList3);
							for (int j = 0; j <= CalcList3.Count - 1; j++)
							{
								LaserMaterialData laserMaterialData = new LaserMaterialData();
								buSerilization.Decode(CalcList3[j], "", SerilizationMode.MultiLine, laserMaterialData);
								laserMaterial.Orders.Add(laserMaterialData);
							}
							Materials.Add(laserMaterial);
						}
					}
					ArrayList CalcList4 = new ArrayList();
					CalcList2 = new List<List<string>>();
					clsVar.Cf2Properties = new List<Cf2FileProperties>();
					buString.ListToSpecificList("<Cf2Props>", "</Cf2Props>", AddStartEndKey: true, arrayList, ref CalcList4);
					buString.ListToSpecificList("<Cf2FileProperties>", "</Cf2FileProperties>", AddStartEndKey: true, CalcList4, ref CalcList2);
					if (CalcList2.Count > 0)
					{
						for (int k = 0; k <= CalcList2.Count - 1; k++)
						{
							Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
							buSerilization.Decode(CalcList2[k], "", SerilizationMode.MultiLine, cf2FileProperties);
							clsVar.Cf2Properties.Add(cf2FileProperties);
						}
					}
					CalcList4 = new ArrayList();
					CalcList2 = new List<List<string>>();
				}
				catch (Exception mSException)
				{
					buLog.addLog("Laser Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Laser Settings Decoder Error");
				}
			}
			buLog.addLog("Laser Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			fileInfo = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterWoodTop.bin");
			if (fileInfo.Exists)
			{
				buMWLaserRouterVars.varCamWoodTop.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterWoodBottom.bin");
			if (fileInfo.Exists)
			{
				buMWLaserRouterVars.varCamWoodBottom.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterPertinaxIncut.bin");
			if (fileInfo.Exists)
			{
				buMWLaserRouterVars.varCamPertinaxInCut.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterPertinaxOutcut.bin");
			if (fileInfo.Exists)
			{
				buMWLaserRouterVars.varCamPertinaxOutCut.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterPertinaxHole.bin");
			if (fileInfo.Exists)
			{
				buMWLaserRouterVars.varCamPertinaxHoleCut.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterPertinaxText.bin");
			if (fileInfo.Exists)
			{
				buMWLaserRouterVars.varCamPertinaxTextCut.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterSteelContour.bin");
			if (fileInfo.Exists)
			{
				buMWLaserRouterVars.varCamSteelContour.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterSteelPocket.bin");
			if (fileInfo.Exists)
			{
				buMWLaserRouterVars.varCamSteelPocket.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterSteelText.bin");
			if (fileInfo.Exists)
			{
				buMWLaserRouterVars.varCamSteelText.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Laser\\mwLaserContour.bin");
			if (fileInfo.Exists)
			{
				buMWLaserRouterVars.varCamLaserWFContour.mwPar.Deserialize(fileInfo.FullName);
			}
			string fileName2 = AppPath.Settings + "\\Laser\\RouterCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (!fileInfo.Exists)
			{
				buLog.addLog("Laser Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Laser Cam Settings File Missing");
				return;
			}
			arrayList = new ArrayList();
			buFile.OpenFromFile(fileName2, ref arrayList);
			try
			{
				ArrayList CalcList5 = new ArrayList();
				buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", AddStartEndKey: true, arrayList, ref CalcList5);
				if (CalcList5.Count > 0)
				{
					buSerilization.Decode(arrayList, "_varbuRouterCamWoodTopPars", SerilizationMode.MultiLine, buMWLaserRouterVars.varCamWoodTop.buPar);
					buSerilization.Decode(arrayList, "_varbuRouterCamWoodBottomPars", SerilizationMode.MultiLine, buMWLaserRouterVars.varCamWoodBottom.buPar);
					buSerilization.Decode(arrayList, "_varbuRouterCamPertinaxIncutPars", SerilizationMode.MultiLine, buMWLaserRouterVars.varCamPertinaxInCut.buPar);
					buSerilization.Decode(arrayList, "_varbuRouterCamPertinaxOutcutPars", SerilizationMode.MultiLine, buMWLaserRouterVars.varCamPertinaxOutCut.buPar);
					buSerilization.Decode(arrayList, "_varbuRouterCamPertinaxHolePars", SerilizationMode.MultiLine, buMWLaserRouterVars.varCamPertinaxHoleCut.buPar);
					buSerilization.Decode(arrayList, "_varbuRouterCamPertinaxTextPars", SerilizationMode.MultiLine, buMWLaserRouterVars.varCamPertinaxTextCut.buPar);
					buSerilization.Decode(arrayList, "_varbuRouterCamSteelContourPars", SerilizationMode.MultiLine, buMWLaserRouterVars.varCamSteelContour.buPar);
					buSerilization.Decode(arrayList, "_varbuRouterCamSteelPocketPars", SerilizationMode.MultiLine, buMWLaserRouterVars.varCamSteelPocket.buPar);
					buSerilization.Decode(arrayList, "_varbuRouterCamSteelTextPars", SerilizationMode.MultiLine, buMWLaserRouterVars.varCamSteelText.buPar);
					buSerilization.Decode(arrayList, "_varCamLaserWFContour", SerilizationMode.MultiLine, buMWLaserRouterVars.varCamLaserWFContour.buPar);
				}
			}
			catch (Exception mSException2)
			{
				buLog.addLog("MW Laser Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Laser Settings Decoder Error");
			}
		}
		catch (Exception mSException3)
		{
			buLog.addLog("Laser Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Laser Settings Decoder Error");
		}
	}

	public string GetStatusInfo()
	{
		string text = "";
		if (ccVars.Pages.Count > 0)
		{
			text = text + "dX: " + ccVars.Pages[ccVars.PageIndex].Info.EntitiesBoxSize.X.ToString("f3") + " - dY: " + ccVars.Pages[ccVars.PageIndex].Info.EntitiesBoxSize.Y.ToString("f3");
		}
		if ((clsInit.appLaserRouter.Materials.Count > 0) & (varLaserRuntimeSettings.SelectedMaterial >= 0) & (varLaserRuntimeSettings.SelectedMaterial <= clsInit.appLaserRouter.Materials.Count - 1))
		{
			text = text + " - Parameter : " + clsInit.appLaserRouter.Materials[varLaserRuntimeSettings.SelectedMaterial].Name;
		}
		if (ccVars.Pages.Count > 0 && ccVars.Pages[ccVars.PageIndex].Cams.Count > 0)
		{
			double num = 0.0;
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; i++)
			{
				num += ccVars.Pages[ccVars.PageIndex].Cams[i].Information.TotalSecond;
			}
			string text2 = TimeSpan.FromSeconds(num).ToString("hh\\:mm\\:ss");
			text = text + " - Time : " + text2;
		}
		return text;
	}

	public string GetStatusFullInfo(bool MultiLine)
	{
		string text = "";
		if (ccVars.Pages.Count > 0)
		{
			text = text + "dX: " + ccVars.Pages[ccVars.PageIndex].Info.EntitiesBoxSize.X.ToString("f3") + " - dY: " + ccVars.Pages[ccVars.PageIndex].Info.EntitiesBoxSize.Y.ToString("f3");
		}
		if (MultiLine)
		{
			text += Environment.NewLine;
		}
		if ((clsInit.appLaserRouter.Materials.Count > 0) & (varLaserRuntimeSettings.SelectedMaterial >= 0) & (varLaserRuntimeSettings.SelectedMaterial <= clsInit.appLaserRouter.Materials.Count - 1))
		{
			text = text + "Parameter : " + clsInit.appLaserRouter.Materials[varLaserRuntimeSettings.SelectedMaterial].Name;
		}
		if (MultiLine)
		{
			text += Environment.NewLine;
		}
		if (ccVars.Pages.Count > 0 && ccVars.Pages[ccVars.PageIndex].Cams.Count > 0)
		{
			double num = 0.0;
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; i++)
			{
				num += ccVars.Pages[ccVars.PageIndex].Cams[i].Information.TotalSecond;
			}
			string text2 = TimeSpan.FromSeconds(num).ToString("hh\\:mm\\:ss");
			text = text + "Total Time : " + text2;
			if (MultiLine)
			{
				text += Environment.NewLine;
			}
			num = 0.0;
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; j++)
			{
				num += ccVars.Pages[ccVars.PageIndex].Cams[j].Information.ProcessSecond;
			}
			text2 = TimeSpan.FromSeconds(num).ToString("hh\\:mm\\:ss");
			text = text + "Operation Time : " + text2;
			if (MultiLine)
			{
				text += Environment.NewLine;
			}
			num = 0.0;
			for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; k++)
			{
				num += ccVars.Pages[ccVars.PageIndex].Cams[k].Information.AirMoveSecond;
			}
			text2 = TimeSpan.FromSeconds(num).ToString("hh\\:mm\\:ss");
			text = text + "Air Move Time : " + text2;
			if (MultiLine)
			{
				text += Environment.NewLine;
			}
			double num2 = 0.0;
			for (int l = 0; l <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; l++)
			{
				num2 += ccVars.Pages[ccVars.PageIndex].Cams[l].Information.TotalLength;
			}
			text = text + "Total Length : " + num2.ToString("f3") + " mm";
			if (MultiLine)
			{
				text += Environment.NewLine;
			}
			num2 = 0.0;
			for (int m = 0; m <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; m++)
			{
				num2 += ccVars.Pages[ccVars.PageIndex].Cams[m].Information.TotalProcessLength;
			}
			text = text + "Operation Length : " + num2.ToString("f3") + " mm";
			if (MultiLine)
			{
				text += Environment.NewLine;
			}
			num2 = 0.0;
			for (int n = 0; n <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; n++)
			{
				num2 += ccVars.Pages[ccVars.PageIndex].Cams[n].Information.AirMoveLength;
			}
			text = text + "Air Move Length : " + num2.ToString("f3") + " mm";
			if (MultiLine)
			{
				text += Environment.NewLine;
			}
		}
		return text;
	}

	public void doWireframeContourLaser(MWCalculationOptions MWCalcoptions, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWLaserRouterVars.varCamLaserWFContour.mwPar, buMWLaserRouterVars.varCamLaserWFContour.buPar, out clsMW.varbuCamWFContourPars);
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
		buMWLaserRouterVars.varCamLaserWFContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWLaserRouterVars.varCamLaserWFContour.buPar);
		if (num >= 1)
		{
			if (CamOtherEntities != null && CamOtherEntities.Count > 0)
			{
				for (int i = 0; i <= CamOtherEntities.Count - 1; i++)
				{
					Entity copiedEnt = null;
					buVector5.CopyEntities(CamOtherEntities[i], ref copiedEnt);
					Cam.EntitiesOther.Add(copiedEnt);
				}
			}
			Cam.Mode = MWCalcoptions.Mode;
			Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
			Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
			Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
			if (MWCalcoptions.Mode == CamMode.WireFrame && MWCalcoptions.CamWireframeType == CamWireFrameType.Contour)
			{
				for (int j = 0; j <= Cam.Tool.ToolNext.Count - 1; j++)
				{
					if (Cam.Tool.ToolNext[j].ToString().Trim().Length > 0)
					{
						Cam.AfterCodes.Add(Cam.Tool.ToolNext[j].ToString().Trim());
					}
				}
				for (int k = 0; k <= Cam.Tool.ToolPre.Count - 1; k++)
				{
					if (Cam.Tool.ToolPre[k].ToString().Trim().Length > 0)
					{
						Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[k].ToString().Trim());
					}
				}
				clsInit.appCommand.CamAdd(Cam);
			}
			clsInit.appCommand.Reset();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void doWireframeContourRouter(MWCalculationOptions MWCalcoptions, ref MWParameters Pars, bool isPocket, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		if (isPocket)
		{
			clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(Pars.mwPar, Pars.buPar, out clsMW.varbuCamWFPocketPars);
		}
		else
		{
			clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(Pars.mwPar, Pars.buPar, out clsMW.varbuCamWFContourPars);
		}
		MWCalcoptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
		List<Entity> selectedEntities = new List<Entity>();
		List<Entity> SortedEntities = new List<Entity>();
		SelectionOption selectionOption = new SelectionOption();
		SortResult Result = new SortResult();
		selectionOption.CircleToArc = true;
		selectionOption.CircleTo4Arc = true;
		selectionOption.SplitArcIfGreatThen180 = true;
		selectionOption.Point = false;
		selectionOption.SplitArcIfGreatThenValue = 160.0;
		clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
		clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
		clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MWCalcoptions.StartPointX, MWCalcoptions.StartPointY), ref selectedEntities, MWCalcoptions.SortingSettings, ref SortedEntities, ref Result);
		List<List<Entity>> OutsideEntities = new List<List<Entity>>();
		List<List<Entity>> InsideEntities = new List<List<Entity>>();
		List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
		clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
		clsInit.cVector5.EnitiesFirstInsideThenOutside(SplitedEntitites, ref InsideEntities, ref OutsideEntities);
		int num = 1;
		clsMW.CamEntitiesGroup.Clear();
		if (InsideEntities.Count > 0)
		{
			if (clsMW.CamEntities.Count == 0)
			{
				buVector5.CopyEntities(InsideEntities, ref clsMW.CamEntitiesGroup);
				MWCalcoptions.UseSortedAndSplitedEntities = true;
			}
			camResult Result2 = null;
			num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result2);
		}
		clsMW.CamEntitiesGroup.Clear();
		if (OutsideEntities.Count > 0)
		{
			Point3D MinPoint = new Point3D();
			Point3D MidPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			SortedEntities = new List<Entity>();
			selectedEntities = new List<Entity>();
			buVector5.CopyEntities(OutsideEntities, ref selectedEntities);
			clsInit.cVector5.BoxSizeCalculate(selectedEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
			clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MaxPoint.X, MinPoint.Y), ref selectedEntities, MWCalcoptions.SortingSettings, ref SortedEntities, ref Result);
			clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref OutsideEntities);
			camTp Cam2 = new camTp();
			if (clsMW.CamEntities.Count == 0)
			{
				buVector5.CopyEntities(OutsideEntities, ref clsMW.CamEntitiesGroup);
				MWCalcoptions.UseSortedAndSplitedEntities = true;
			}
			MWCalcoptions.UseConstantStartPoint = false;
			MWCalcoptions.UseEachCurveStartPoint = true;
			if (InsideEntities.Count <= 0)
			{
				camResult Result3 = null;
				num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result3);
			}
			else
			{
				camResult Result4 = null;
				num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam2, ref Result4);
				clsInit.cVector5.CamAddtoOtherCam(Cam2, ref Cam);
			}
		}
		if (isPocket)
		{
			Pars.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out Pars.buPar);
		}
		else
		{
			Pars.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out Pars.buPar);
		}
		if (num >= 1)
		{
			if (CamOtherEntities != null && CamOtherEntities.Count > 0)
			{
				for (int i = 0; i <= CamOtherEntities.Count - 1; i++)
				{
					Entity copiedEnt = null;
					buVector5.CopyEntities(CamOtherEntities[i], ref copiedEnt);
					Cam.EntitiesOther.Add(copiedEnt);
				}
			}
			Cam.Mode = MWCalcoptions.Mode;
			Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
			Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
			Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
			if (MWCalcoptions.Mode == CamMode.WireFrame)
			{
				if (MWCalcoptions.CamWireframeType == CamWireFrameType.Contour)
				{
					if (MWCalcoptions.NumberofAxis != 4)
					{
						if (!((MWCalcoptions.NumberofAxis == 3) & !MWCalcoptions.isSpinConstantCalculation))
						{
							if ((MWCalcoptions.NumberofAxis == 3) & MWCalcoptions.isSpinConstantCalculation)
							{
								Cam.PreCodes.Add("G90");
								Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("G53");
								Cam.PreCodes.Add("G0 Z0");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("M55");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("M154");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
								Cam.PreCodes.Add("G75");
								for (int j = 0; j <= Cam.Tool.ToolNext.Count - 1; j++)
								{
									if (Cam.Tool.ToolNext[j].ToString().Trim().Length > 0)
									{
										Cam.AfterCodes.Add(Cam.Tool.ToolNext[j].ToString().Trim());
									}
								}
								Cam.AfterCodes.Add("M30");
								Cam.AfterCodes.Add("M2");
								for (int k = 0; k <= Cam.Tool.ToolPre.Count - 1; k++)
								{
									if (Cam.Tool.ToolPre[k].ToString().Trim().Length > 0)
									{
										Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[k].ToString().Trim());
									}
								}
								Cam.CamPoints[0].PreCodes.Add("M40 K" + clsMW.varbuCamWFContourPars.Strategy.SpinSpeed);
								clsInit.appCommand.CamAdd(Cam);
							}
						}
						else
						{
							Cam.PreCodes.Add("G90");
							Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
							Cam.PreCodes.Add("G75");
							Cam.PreCodes.Add("G53");
							Cam.PreCodes.Add("G0 Z0");
							Cam.PreCodes.Add("G75");
							Cam.PreCodes.Add("M154");
							Cam.PreCodes.Add("G75");
							Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
							Cam.PreCodes.Add("G75");
							for (int l = 0; l <= Cam.Tool.ToolNext.Count - 1; l++)
							{
								if (Cam.Tool.ToolNext[l].ToString().Trim().Length > 0)
								{
									Cam.AfterCodes.Add(Cam.Tool.ToolNext[l].ToString().Trim());
								}
							}
							Cam.AfterCodes.Add("M30");
							Cam.AfterCodes.Add("M2");
							for (int m = 0; m <= Cam.Tool.ToolPre.Count - 1; m++)
							{
								if (Cam.Tool.ToolPre[m].ToString().Trim().Length > 0)
								{
									Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[m].ToString().Trim());
								}
							}
							clsInit.appCommand.CamAdd(Cam);
						}
					}
					else
					{
						Cam.PreCodes.Add("G90");
						Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("G53");
						Cam.PreCodes.Add("G0 Z0");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("M55");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("M154");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
						Cam.PreCodes.Add("G75");
						for (int n = 0; n <= Cam.Tool.ToolNext.Count - 1; n++)
						{
							if (Cam.Tool.ToolNext[n].ToString().Trim().Length > 0)
							{
								Cam.AfterCodes.Add(Cam.Tool.ToolNext[n].ToString().Trim());
							}
						}
						Cam.AfterCodes.Add("M30");
						Cam.AfterCodes.Add("M2");
						for (int num2 = 0; num2 <= Cam.Tool.ToolPre.Count - 1; num2++)
						{
							if (Cam.Tool.ToolPre[num2].ToString().Trim().Length > 0)
							{
								Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[num2].ToString().Trim());
							}
						}
						clsInit.appCommand.CamAdd(Cam);
					}
				}
				if (MWCalcoptions.CamWireframeType == CamWireFrameType.Pocket && MWCalcoptions.NumberofAxis == 3)
				{
					Cam.PreCodes.Add("G90");
					Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("G53");
					Cam.PreCodes.Add("G0 Z0");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("M154");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
					Cam.PreCodes.Add("G75");
					for (int num3 = 0; num3 <= Cam.Tool.ToolNext.Count - 1; num3++)
					{
						if (Cam.Tool.ToolNext[num3].ToString().Trim().Length > 0)
						{
							Cam.AfterCodes.Add(Cam.Tool.ToolNext[num3].ToString().Trim());
						}
					}
					Cam.AfterCodes.Add("M30");
					Cam.AfterCodes.Add("M2");
					for (int num4 = 0; num4 <= Cam.Tool.ToolPre.Count - 1; num4++)
					{
						if (Cam.Tool.ToolPre[num4].ToString().Trim().Length > 0)
						{
							Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[num4].ToString().Trim());
						}
					}
					clsInit.appCommand.CamAdd(Cam);
				}
			}
			clsInit.appCommand.Reset();
			SaveLaserFile();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void doWireframeContourRouterWoodBottom(MWCalculationOptions MWCalcoptions, GeoLib mwPars, camParameters5 buPars, bool isPocket, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		if (isPocket)
		{
			clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(mwPars, buPars, out clsMW.varbuCamWFPocketPars);
		}
		else
		{
			clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(mwPars, buPars, out clsMW.varbuCamWFContourPars);
		}
		MWCalcoptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
		List<Entity> selectedEntities = new List<Entity>();
		List<Entity> SortedEntities = new List<Entity>();
		SelectionOption selectionOption = new SelectionOption();
		SortResult Result = new SortResult();
		selectionOption.CircleToArc = true;
		selectionOption.CircleTo4Arc = true;
		selectionOption.SplitArcIfGreatThen180 = true;
		selectionOption.Point = false;
		selectionOption.SplitArcIfGreatThenValue = 160.0;
		clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
		clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
		MWCalcoptions.SortingSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLengthWithSingleTouch;
		clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MWCalcoptions.StartPointX, MWCalcoptions.StartPointY), ref selectedEntities, MWCalcoptions.SortingSettings, ref SortedEntities, ref Result);
		List<List<Entity>> OutsideEntities = new List<List<Entity>>();
		List<List<Entity>> InsideEntities = new List<List<Entity>>();
		List<List<Entity>> calcEntities = new List<List<Entity>>();
		List<List<Entity>> calcEntities2 = new List<List<Entity>>();
		List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
		clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
		clsInit.cVector5.EnitiesFirstInsideThenOutside(SplitedEntitites, ref InsideEntities, ref OutsideEntities);
		BreakEntitiesByRefLineEventVar breakEntitiesByRefLineEventVar = new BreakEntitiesByRefLineEventVar();
		breakEntitiesByRefLineEventVar.PersentageOfBoxSize = varRouterSettings.WoodBottomTrimPersentage;
		breakEntitiesByRefLineEventVar.RefDirection = varRouterSettings.WoodBottomRefSide;
		breakEntitiesByRefLineEventVar.SortResolution = clsVar.varSelection.SelectionResolution;
		clsInit.cVector5.BreakEntitiesByRefLine(InsideEntities, breakEntitiesByRefLineEventVar, ref calcEntities2);
		clsInit.cVector5.BreakEntitiesByRefLine(OutsideEntities, breakEntitiesByRefLineEventVar, ref calcEntities);
		int num = 1;
		clsMW.CamEntitiesGroup.Clear();
		if (calcEntities2.Count > 0)
		{
			buVector5.CopyEntities(calcEntities2, ref clsMW.CamEntitiesGroup);
			MWCalcoptions.UseSortedAndSplitedEntities = true;
			camResult Result2 = null;
			num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result2);
		}
		clsMW.CamEntitiesGroup.Clear();
		if (calcEntities.Count > 0)
		{
			Point3D MinPoint = new Point3D();
			Point3D MidPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			SortedEntities = new List<Entity>();
			SplitedEntitites = new List<List<Entity>>();
			selectedEntities = new List<Entity>();
			buVector5.CopyEntities(calcEntities, ref selectedEntities);
			clsInit.cVector5.BoxSizeCalculate(selectedEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
			clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MaxPoint.X, MinPoint.Y), ref selectedEntities, MWCalcoptions.SortingSettings, ref SortedEntities, ref Result);
			clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref OutsideEntities);
			camTp Cam2 = new camTp();
			buVector5.CopyEntities(calcEntities, ref clsMW.CamEntitiesGroup);
			MWCalcoptions.UseSortedAndSplitedEntities = true;
			MWCalcoptions.UseConstantStartPoint = false;
			MWCalcoptions.UseEachCurveStartPoint = true;
			camResult Result3 = null;
			num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam2, ref Result3);
			clsInit.cVector5.CamAddtoOtherCam(Cam2, ref Cam);
		}
		mwPars = ((!isPocket) ? buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buPars) : buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buPars));
		if (num >= 1)
		{
			if (CamOtherEntities != null && CamOtherEntities.Count > 0)
			{
				for (int i = 0; i <= CamOtherEntities.Count - 1; i++)
				{
					Entity copiedEnt = null;
					buVector5.CopyEntities(CamOtherEntities[i], ref copiedEnt);
					Cam.EntitiesOther.Add(copiedEnt);
				}
			}
			Cam.Mode = MWCalcoptions.Mode;
			Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
			Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
			Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
			if (MWCalcoptions.Mode == CamMode.WireFrame)
			{
				if (MWCalcoptions.CamWireframeType == CamWireFrameType.Contour)
				{
					if (MWCalcoptions.NumberofAxis != 4)
					{
						if (!((MWCalcoptions.NumberofAxis == 3) & !MWCalcoptions.isSpinConstantCalculation))
						{
							if ((MWCalcoptions.NumberofAxis == 3) & MWCalcoptions.isSpinConstantCalculation)
							{
								Cam.PreCodes.Add("G90");
								Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("G53");
								Cam.PreCodes.Add("G0 Z0");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("M55");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("M154");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
								Cam.PreCodes.Add("G75");
								for (int j = 0; j <= Cam.Tool.ToolNext.Count - 1; j++)
								{
									if (Cam.Tool.ToolNext[j].ToString().Trim().Length > 0)
									{
										Cam.AfterCodes.Add(Cam.Tool.ToolNext[j].ToString().Trim());
									}
								}
								Cam.AfterCodes.Add("M30");
								Cam.AfterCodes.Add("M2");
								for (int k = 0; k <= Cam.Tool.ToolPre.Count - 1; k++)
								{
									if (Cam.Tool.ToolPre[k].ToString().Trim().Length > 0)
									{
										Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[k].ToString().Trim());
									}
								}
								Cam.CamPoints[0].PreCodes.Add("M40 K" + clsMW.varbuCamWFContourPars.Strategy.SpinSpeed);
								clsInit.appCommand.CamAdd(Cam);
							}
						}
						else
						{
							Cam.PreCodes.Add("G90");
							Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
							Cam.PreCodes.Add("G75");
							Cam.PreCodes.Add("G53");
							Cam.PreCodes.Add("G0 Z0");
							Cam.PreCodes.Add("G75");
							Cam.PreCodes.Add("M154");
							Cam.PreCodes.Add("G75");
							Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
							Cam.PreCodes.Add("G75");
							for (int l = 0; l <= Cam.Tool.ToolNext.Count - 1; l++)
							{
								if (Cam.Tool.ToolNext[l].ToString().Trim().Length > 0)
								{
									Cam.AfterCodes.Add(Cam.Tool.ToolNext[l].ToString().Trim());
								}
							}
							Cam.AfterCodes.Add("M30");
							Cam.AfterCodes.Add("M2");
							for (int m = 0; m <= Cam.Tool.ToolPre.Count - 1; m++)
							{
								if (Cam.Tool.ToolPre[m].ToString().Trim().Length > 0)
								{
									Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[m].ToString().Trim());
								}
							}
							clsInit.appCommand.CamAdd(Cam);
						}
					}
					else
					{
						Cam.PreCodes.Add("G90");
						Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("G53");
						Cam.PreCodes.Add("G0 Z0");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("M55");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("M154");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
						Cam.PreCodes.Add("G75");
						for (int n = 0; n <= Cam.Tool.ToolNext.Count - 1; n++)
						{
							if (Cam.Tool.ToolNext[n].ToString().Trim().Length > 0)
							{
								Cam.AfterCodes.Add(Cam.Tool.ToolNext[n].ToString().Trim());
							}
						}
						Cam.AfterCodes.Add("M30");
						Cam.AfterCodes.Add("M2");
						for (int num2 = 0; num2 <= Cam.Tool.ToolPre.Count - 1; num2++)
						{
							if (Cam.Tool.ToolPre[num2].ToString().Trim().Length > 0)
							{
								Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[num2].ToString().Trim());
							}
						}
						clsInit.appCommand.CamAdd(Cam);
					}
				}
				if (MWCalcoptions.CamWireframeType == CamWireFrameType.Pocket && MWCalcoptions.NumberofAxis == 3)
				{
					Cam.PreCodes.Add("G90");
					Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("G53");
					Cam.PreCodes.Add("G0 Z0");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("M154");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
					Cam.PreCodes.Add("G75");
					for (int num3 = 0; num3 <= Cam.Tool.ToolNext.Count - 1; num3++)
					{
						if (Cam.Tool.ToolNext[num3].ToString().Trim().Length > 0)
						{
							Cam.AfterCodes.Add(Cam.Tool.ToolNext[num3].ToString().Trim());
						}
					}
					Cam.AfterCodes.Add("M30");
					Cam.AfterCodes.Add("M2");
					for (int num4 = 0; num4 <= Cam.Tool.ToolPre.Count - 1; num4++)
					{
						if (Cam.Tool.ToolPre[num4].ToString().Trim().Length > 0)
						{
							Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[num4].ToString().Trim());
						}
					}
					clsInit.appCommand.CamAdd(Cam);
				}
			}
			clsInit.appCommand.Reset();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public int doDrill(MWCalculationOptions MWCalcoptions, GeoLib mwPars, camParameters5 buPars, ToolBase5 Tool, ref camTp Cam)
	{
		Cam = new camTp();
		clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(mwPars, buPars, out clsMW.varbuCamDrillPars);
		if (ccVars.MaterialList.Count > 0 && ccVars.MaterialList[clsVar.varInterface.MaterialIndex].Enable)
		{
			MWCalcoptions.CheckBoxBounding = true;
			MWCalcoptions.BoxBoundingMin.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.X;
			MWCalcoptions.BoxBoundingMin.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.Y;
			MWCalcoptions.BoxBoundingMin.Z = 0.0;
			MWCalcoptions.BoxBoundingMax.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.X;
			MWCalcoptions.BoxBoundingMax.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.Y;
			MWCalcoptions.BoxBoundingMax.Z = 0.0;
		}
		camResult Result = null;
		int num = clsInit.appMW.doDrill(MWCalcoptions, Tool, ref Cam, ref Result);
		if (Result.Errors.Count <= 0)
		{
			buMWCalcs.CopyCamParameter(clsMW.varMWCamDrillPars, clsMW.varbuCamDrillPars, ref clsVar.varCamDrillPars);
			if (num >= 1)
			{
				Cam.Mode = MWCalcoptions.Mode;
				Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
				Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
				Cam.CamDrillType = MWCalcoptions.CamDrillType;
				Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
				if (MWCalcoptions.Mode == CamMode.Drill && MWCalcoptions.NumberofAxis == 3)
				{
					buString5.AddToArrayList(ccVars.PostActive.Drill3AXPreCodes, ref Cam.PreCodes);
					for (int i = 0; i <= Cam.Tool.ToolNext.Count - 1; i++)
					{
						if (Cam.Tool.ToolNext[i].ToString().Trim().Length > 0)
						{
							Cam.AfterCodes.Add(Cam.Tool.ToolNext[i].ToString().Trim());
						}
					}
					buString5.AddToArrayList(ccVars.PostActive.Drill3AXAfterCodes, ref Cam.AfterCodes);
					for (int j = 0; j <= Cam.Tool.ToolPre.Count - 1; j++)
					{
						if (Cam.Tool.ToolPre[j].ToString().Trim().Length > 0)
						{
							Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[j].ToString().Trim());
						}
					}
					clsInit.appCommand.CamAdd(Cam);
				}
				clsInit.appCommand.Reset();
				clsFiles.SaveParameter();
				return 1;
			}
			clsInit.appCommand.Reset();
			return num;
		}
		F_ErrorList f_ErrorList = new F_ErrorList();
		f_ErrorList.Init(Result.Errors);
		f_ErrorList.ShowDialog();
		clsInit.appCommand.Reset();
		return -2;
	}

	public void doMoveZeroPoint(Point3D refPoint)
	{
		List<int> list = new List<int>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
			list.Add(i);
		}
		if (list.Count > 0)
		{
			clsInit.appCommand.SelectedToSelectionAdd(list);
			clsInit.appCommand.Move(refPoint, new Point3D());
		}
		clsInit.appCommand.Reset(ClearSelection: false);
	}
}
