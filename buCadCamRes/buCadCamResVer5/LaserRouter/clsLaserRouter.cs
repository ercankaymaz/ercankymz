// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.LaserRouter.clsLaserRouter
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buClass.Apps;
using buComm.FTP;
using buControls.ClassViewer;
using buControls.DialogBox;
using buControls.Forms.WinControlForms.Errors;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.LaserRouter;

public class clsLaserRouter
{
  public static List<string> Captions = new List<string>();
  public static F_PerpendicularSelection FrmPerpendicularSelect = (F_PerpendicularSelection) null;
  public static F_RouterOperations FrmRouterWood = (F_RouterOperations) null;
  public static F_LaserMaterial FrmLaserMats = (F_LaserMaterial) null;
  public static F_LaserStartOrder FrmLaserStartOrder = (F_LaserStartOrder) null;
  public List<LaserMaterial> Materials = new List<LaserMaterial>();
  public static LaserProgramSettings varLaserSettings = new LaserProgramSettings();
  public static RouterProgramSettings varRouterSettings = new RouterProgramSettings();
  public static LaserRouterRuntimeSettings varLaserRuntimeSettings = new LaserRouterRuntimeSettings();
  public List<Entity> CamOtherEntities = (List<Entity>) null;

  public void Init()
  {
    clsLaserRouter.FrmLaserMats = new F_LaserMaterial();
    clsLaserRouter.FrmLaserStartOrder = new F_LaserStartOrder();
    clsLaserRouter.FrmPerpendicularSelect = new F_PerpendicularSelection();
    clsLaserRouter.FrmRouterWood = new F_RouterOperations();
    buMWLaserRouterVars.Init();
    clsInit.appCommand.SetInformationAtStatus(clsInit.appLaserRouter.GetStatusInfo());
  }

  public void cmdRouterCommonOperation(DiemakerType CutType)
  {
    switch (CutType)
    {
      case DiemakerType.WoodChamferTop:
        this.cmdRouterOperation(CutType, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedWoodChamferTopToolName, ref buMWLaserRouterVars.varCamWoodTop);
        break;
      case DiemakerType.WoodChamferBottom:
        this.cmdRouterOperation(CutType, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedWoodChamferBottomToolName, ref buMWLaserRouterVars.varCamWoodBottom);
        break;
      case DiemakerType.PertinaxIncut:
        this.cmdRouterOperation(CutType, true, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedPertinaxInCutToolName, ref buMWLaserRouterVars.varCamPertinaxInCut);
        break;
      case DiemakerType.PertinaxOutcut:
        this.cmdRouterOperation(CutType, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedPertinaxOutCutToolName, ref buMWLaserRouterVars.varCamPertinaxOutCut);
        break;
      case DiemakerType.PertinaxHole:
        this.cmdRouterOperation(CutType, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedPertinaxHoleToolName, ref buMWLaserRouterVars.varCamPertinaxHoleCut);
        break;
      case DiemakerType.PertinaxAllCut:
        this.cmdRouterOperation(DiemakerType.PertinaxIncut, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedPertinaxInCutToolName, ref buMWLaserRouterVars.varCamPertinaxInCut);
        this.cmdRouterOperation(DiemakerType.PertinaxHole, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedPertinaxHoleToolName, ref buMWLaserRouterVars.varCamPertinaxHoleCut);
        this.cmdRouterOperation(DiemakerType.PertinaxText, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedPertinaxTextToolName, ref buMWLaserRouterVars.varCamPertinaxTextCut);
        this.cmdRouterOperation(DiemakerType.PertinaxOutcut, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedPertinaxOutCutToolName, ref buMWLaserRouterVars.varCamPertinaxOutCut);
        break;
      case DiemakerType.PertinaxText:
        this.cmdRouterOperation(CutType, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedPertinaxTextToolName, ref buMWLaserRouterVars.varCamPertinaxTextCut);
        break;
      case DiemakerType.SteelPlateContour:
        this.cmdRouterOperation(CutType, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedSteelContourToolName, ref buMWLaserRouterVars.varCamSteelContour);
        break;
      case DiemakerType.SteelPlatePocket:
        this.cmdRouterOperation(CutType, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedSteelPocketToolName, ref buMWLaserRouterVars.varCamSteelPocket);
        break;
      case DiemakerType.SteelPlateText:
        this.cmdRouterOperation(CutType, false, ref clsLaserRouter.varLaserRuntimeSettings.LastSelectedSteelTextToolName, ref buMWLaserRouterVars.varCamSteelText);
        break;
    }
  }

  public void cmdRouterOperation(
    DiemakerType CutType,
    bool PerpendicularSelection,
    ref string LastSelectedToolName,
    ref MWParameters Pars)
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      if (PerpendicularSelection)
      {
        clsLaserRouter.FrmPerpendicularSelect.Horizontal = clsLaserRouter.varLaserRuntimeSettings.HorizontalSelection;
        clsLaserRouter.FrmPerpendicularSelect.Vertical = clsLaserRouter.varLaserRuntimeSettings.VerticalSelection;
        clsLaserRouter.FrmPerpendicularSelect.Angle = clsLaserRouter.varLaserRuntimeSettings.AngleSelection;
        clsLaserRouter.FrmPerpendicularSelect.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsLaserRouter.FrmPerpendicularSelect.Init();
        int num = (int) clsLaserRouter.FrmPerpendicularSelect.ShowDialog();
        if (clsLaserRouter.FrmPerpendicularSelect.PropertiesForm.Result != DialogResult.OK)
          return;
        clsLaserRouter.varLaserRuntimeSettings.HorizontalSelection = clsLaserRouter.FrmPerpendicularSelect.Horizontal;
        clsLaserRouter.varLaserRuntimeSettings.VerticalSelection = clsLaserRouter.FrmPerpendicularSelect.Vertical;
        clsLaserRouter.varLaserRuntimeSettings.AngleSelection = clsLaserRouter.FrmPerpendicularSelect.Angle;
      }
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        string str = "";
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
        {
          if (ccVars.Pages[ccVars.PageIndex].Layers[index].Diemaker != null && ccVars.Pages[ccVars.PageIndex].Layers[index].Diemaker.Type == CutType)
            str = ccVars.Pages[ccVars.PageIndex].Layers[index].Name;
        }
        List<int> Added = new List<int>();
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName == str)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
            Added.Add(index);
          }
        }
        if (Added.Count > 0)
          clsInit.appCommand.SelectedToSelectionAdd(Added);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      }
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        buString5.MessageBoxWarning(AppLanguage.CadCamMessages[7]);
      }
      else
      {
        if (clsLaserRouter.FrmRouterWood != null)
        {
          if (!clsLaserRouter.FrmRouterWood.Visible)
          {
            clsLaserRouter.FrmRouterWood.SelectedToolIndex = ccVars.ToolIndex;
            clsLaserRouter.FrmRouterWood.Tools.Clear();
            clsLaserRouter.FrmRouterWood.Tools = new List<ToolBase5>();
            for (int index = 0; index <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index)
            {
              ToolBase5 toolBase5 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[index]);
              clsLaserRouter.FrmRouterWood.Tools.Add(toolBase5);
              if (toolBase5.Data.Name == LastSelectedToolName)
                clsLaserRouter.FrmRouterWood.SelectedToolIndex = index;
            }
            clsLaserRouter.FrmRouterWood.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
            clsLaserRouter.FrmRouterWood.varCamPars = new camParameters5(Pars.buPar);
            clsLaserRouter.FrmRouterWood.Init();
            int num = (int) clsLaserRouter.FrmRouterWood.ShowDialog();
            if (clsLaserRouter.FrmRouterWood.PropertiesForm.Result == DialogResult.OK)
            {
              Pars.buPar = new camParameters5(clsLaserRouter.FrmRouterWood.varCamPars);
              for (int index = 0; index <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index)
              {
                if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index].Data.Name == clsLaserRouter.FrmRouterWood.ToolSelected.Data.Name)
                {
                  ccVars.Tools[ccVars.ToolGroupIndex].Tools[index].CamData = new ToolCamData5(clsLaserRouter.FrmRouterWood.ToolSelected.CamData);
                  ccVars.toolActive = new ToolBase5(clsLaserRouter.FrmRouterWood.ToolSelected);
                }
              }
            }
            else
            {
              clsInit.appCommand.Reset();
              return;
            }
          }
          else
          {
            clsInit.appCommand.Reset();
            clsLaserRouter.FrmRouterWood.Visible = false;
            return;
          }
        }
        List<Entity> selectedEntities = new List<Entity>();
        List<Entity> entityList = new List<Entity>();
        clsInit.appCommand.SelectionToEntities(ref selectedEntities, new SelectionOption()
        {
          CircleToArc = true,
          CircleTo4Arc = true,
          SplitArcIfGreatThen180 = true,
          Point = false,
          SplitArcIfGreatThenValue = 160.0
        });
        clsMW.CamEntities.Clear();
        List<Entity> VerticalEntities = new List<Entity>();
        List<Entity> HorizontalEntities = new List<Entity>();
        List<Entity> OtherEntities = new List<Entity>();
        if (PerpendicularSelection)
        {
          clsInit.cVector5.GetPerpendicularEntities(selectedEntities, ref HorizontalEntities, ref VerticalEntities, ref OtherEntities);
          if (clsLaserRouter.varLaserRuntimeSettings.VerticalSelection)
            buVector5.AddEntities(VerticalEntities, ref entityList);
          if (clsLaserRouter.varLaserRuntimeSettings.HorizontalSelection)
            buVector5.AddEntities(HorizontalEntities, ref entityList);
          if (clsLaserRouter.varLaserRuntimeSettings.AngleSelection)
            buVector5.AddEntities(OtherEntities, ref entityList);
          if (entityList.Count == 0)
          {
            buString5.MessageBoxWarning(AppLanguage.CadCamMessages[7]);
            clsInit.appCommand.Reset();
            return;
          }
        }
        selectedEntities.Clear();
        bool isPocket = false;
        if (Pars.buPar.Operations.Width > ccVars.toolActive.Geometry.Diameter)
        {
          SortSettings Settings = new SortSettings();
          SortResult Result = new SortResult();
          List<Entity> SortedEntities = new List<Entity>();
          clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(), ref entityList, Settings, ref SortedEntities, ref Result);
          List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
          clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
          List<List<Point3D>> Points = new List<List<Point3D>>();
          clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites, 0.01, ref Points);
          for (int index = 0; index <= Points.Count - 1; ++index)
          {
            List<Pnt3D> CopiedPnt = new List<Pnt3D>();
            List<List<Pnt3D>> OffsetedPoints = new List<List<Pnt3D>>();
            buConversion5.Point3DToPnt3D(Points[index], ref CopiedPnt);
            clsInit.cVector.OffsetContour(CopiedPnt, Pars.buPar.Operations.Width / 2.0, OffsetCornerType.Round, CamOpenContourType2.Closed, new WorkPlane(), 0.0, ref OffsetedPoints);
            if (OffsetedPoints.Count > 0)
            {
              List<Point3D> points = new List<Point3D>();
              buConversion5.Pnt3DToPoint3D(OffsetedPoints[0], ref points);
              clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref points);
              if (points.Count > 1)
              {
                LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
                linearPath.Regen(0.01);
                selectedEntities.Add((Entity) linearPath);
              }
            }
          }
          isPocket = true;
          buVector5.CopyEntities(selectedEntities, ref clsMW.CamEntities);
        }
        LastSelectedToolName = ccVars.toolActive.Data.Name;
        camTp Cam = new camTp();
        MWCalculationOptions MWCalcoptions = new MWCalculationOptions();
        MWCalcoptions.NumberofAxis = 3;
        MWCalcoptions.CamWireframeType = CamWireFrameType.Contour;
        MWCalcoptions.Mode = CamMode.WireFrame;
        MWCalcoptions.DontApplyReset = true;
        MWCalcoptions.isBuWireframeCalculation = clsLaserRouter.varRouterSettings.isBuCalculation;
        MWCalcoptions.AddToCamListInMWCalculation = false;
        MWCalcoptions.DontShowDialogBox = !clsLaserRouter.varRouterSettings.ShowBuDialog;
        MWCalcoptions.isBuSort = clsLaserRouter.varRouterSettings.isBuSorting;
        MWCalcoptions.UseStartPoint = clsLaserRouter.varRouterSettings.UseStartPoint;
        MWCalcoptions.UseConstantStartPoint = true;
        MWCalcoptions.StartPointX = clsLaserRouter.varRouterSettings.StartPointX;
        MWCalcoptions.StartPointY = clsLaserRouter.varRouterSettings.StartPointY;
        MWCalcoptions.HeightFromEntities = false;
        if (isPocket)
          MWCalcoptions.CamWireframeType = CamWireFrameType.Pocket;
        Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
        Pars.buPar.Offsets.OpenContour = CamOpenContourType.Center;
        Pars.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
        Pars.buPar.Operations.Height = Pars.buPar.Material.Thickness + Pars.buPar.Operations.BaseThickness - Pars.buPar.Operations.Depth;
        Pars.buPar.Distances.EntryAndExit = Pars.buPar.Distances.Rapid;
        Pars.buPar.Distances.Safe = clsLaserRouter.varRouterSettings.SafeDistance;
        Pars.buPar.Distances.RapidRetract = clsLaserRouter.varRouterSettings.RapidRetract;
        Pars.buPar.Distances.Air = Pars.buPar.Distances.Rapid;
        Pars.buPar.Distances.RapidRetract = true;
        Pars.buPar.Speeds.Leave = clsLaserRouter.varRouterSettings.LeaveSpeed;
        Pars.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(Pars.mwPar, Pars.buPar);
        Pars.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
        Pars.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
        Pars.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
        Pars.mwPar.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
        Pars.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
        Pars.mwPar.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
        Pars.buPar.Steps.StartValue = Pars.buPar.Material.Thickness + Pars.buPar.Operations.BaseThickness;
        Pars.buPar.Steps.EndValue = Pars.buPar.Operations.Height;
        Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices;
        Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep = Pars.buPar.Steps.Count;
        if (Pars.buPar.Steps.Count > 1)
        {
          Pars.buPar.Steps.Enable = true;
          Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Pars.buPar.Steps.StartValue;
          Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Pars.buPar.Steps.EndValue;
        }
        else
        {
          Pars.buPar.Steps.Enable = false;
          Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = Pars.buPar.Operations.Height;
          Pars.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = Pars.buPar.Operations.Height;
        }
        Pars.buPar.Operations.Direction = clsLaserRouter.varRouterSettings.InsideCutClosedPatternCutDirection;
        if (Pars.buPar.Operations.SpiralMode)
        {
          Pars.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeSpiral;
          Pars.mwPar.MachParam.MachiningAreaMode = MachiningParamsMachiningAreaMode.MachByRegions;
          Pars.mwPar.MachParam.CloseFirstSpiralMachContour = false;
        }
        else
          Pars.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeZigzag;
        switch (CutType)
        {
          case DiemakerType.WoodChamferBottom:
            this.doWireframeContourRouterWoodBottom(MWCalcoptions, Pars.mwPar, Pars.buPar, isPocket, ref Cam);
            break;
          case DiemakerType.PertinaxHole:
            Pars.buPar.Drill.StartHeight = Pars.buPar.Material.Thickness + Pars.buPar.Operations.BaseThickness;
            Pars.buPar.Drill.EndHeight = Pars.buPar.Material.Thickness + Pars.buPar.Operations.BaseThickness - Pars.buPar.Operations.Depth;
            MWCalcoptions.CamWireframeType = CamWireFrameType.Contour;
            MWCalcoptions.Mode = CamMode.Drill;
            this.doDrill(MWCalcoptions, Pars.mwPar, Pars.buPar, ccVars.toolActive, ref Cam);
            break;
          case DiemakerType.SteelPlatePocket:
            MWCalcoptions.CamWireframeType = CamWireFrameType.Pocket;
            this.doWireframeContourRouter(MWCalcoptions, ref Pars, true, ref Cam);
            break;
          default:
            this.doWireframeContourRouter(MWCalcoptions, ref Pars, isPocket, ref Cam);
            break;
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSettingsRouter()
  {
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.Text = "Router";
    classViewerDialog.Value = (object) clsLaserRouter.varRouterSettings;
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Width = 500;
    classViewerDialog.Height = 400;
    classViewerDialog.ValuePersentage = 35.0;
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog();
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    clsLaserRouter.varRouterSettings = new RouterProgramSettings((RouterProgramSettings) classViewerDialog.Value);
    clsFiles.SaveParameter();
  }

  public void cmdShowMaterialPage()
  {
    try
    {
      if (clsLaserRouter.FrmLaserMats == null)
        return;
      if (!clsLaserRouter.FrmLaserMats.Visible)
      {
        clsLaserRouter.FrmLaserMats.Materials.Clear();
        clsLaserRouter.FrmLaserMats.Materials = new List<LaserMaterial>();
        for (int index = 0; index <= this.Materials.Count - 1; ++index)
        {
          LaserMaterial laserMaterial = new LaserMaterial(this.Materials[index]);
          clsLaserRouter.FrmLaserMats.Materials.Add(laserMaterial);
        }
        clsLaserRouter.FrmLaserMats.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsLaserRouter.FrmLaserMats.pathMaterialFile = clsLaserRouter.varLaserRuntimeSettings.PathMaterialSave;
        clsLaserRouter.FrmLaserMats.SelectedMaterialIndex = clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial;
        clsLaserRouter.FrmLaserMats.Cf2Properties.Clear();
        clsLaserRouter.FrmLaserMats.Cf2Properties = new List<Cf2FileProperties>();
        for (int index = 0; index <= clsVar.Cf2Properties.Count - 1; ++index)
        {
          Cf2FileProperties cf2FileProperties = new Cf2FileProperties(clsVar.Cf2Properties[index]);
          clsLaserRouter.FrmLaserMats.Cf2Properties.Add(cf2FileProperties);
        }
        clsLaserRouter.FrmLaserMats.SelectedMaterialIndex = clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial;
        clsLaserRouter.FrmLaserMats.Init();
        int num = (int) clsLaserRouter.FrmLaserMats.ShowDialog();
        if (clsLaserRouter.FrmLaserMats.PropertiesForm.Result != DialogResult.OK)
          return;
        clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial = clsLaserRouter.FrmLaserMats.SelectedMaterialIndex;
        this.Materials.Clear();
        this.Materials = new List<LaserMaterial>();
        for (int index = 0; index <= clsLaserRouter.FrmLaserMats.Materials.Count - 1; ++index)
          this.Materials.Add(new LaserMaterial(clsLaserRouter.FrmLaserMats.Materials[index]));
        clsLaserRouter.varLaserRuntimeSettings.PathMaterialSave = clsLaserRouter.FrmLaserMats.pathMaterialFile;
        clsFiles.SaveParameter();
        clsInit.appCommand.SetInformationAtStatus(clsInit.appLaserRouter.GetStatusInfo());
      }
      else
        clsLaserRouter.FrmLaserMats.Visible = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void cmdCamContour(actionTypeBU Action)
  {
    try
    {
      bool flag1 = false;
      string str1 = "";
      double num1 = -1.0;
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      if (ccVars.SelectionOP.Selections.Count > 0)
        flag1 = true;
      ccVars.Action = Action;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      List<LaserMaterialData> laserMaterialDataList1 = new List<LaserMaterialData>();
      List<LaserMaterialData> laserMaterialDataList2 = new List<LaserMaterialData>();
      if (clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial >= 0 & clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial <= this.Materials.Count - 1)
      {
        for (int index1 = 0; index1 <= this.Materials[clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial].Orders.Count - 1; ++index1)
        {
          bool flag2 = false;
          DiemakerType codeType = this.Materials[clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial].Orders[index1].CodeType;
          double ptRealValue = this.Materials[clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial].Orders[index1].PtRealValue;
          if (!this.Materials[clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial].Orders[index1].ApplyAll)
          {
            for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index2)
            {
              if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData != null & (!flag1 | flag1 & ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected))
              {
                for (int index3 = 0; index3 <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index3)
                {
                  if (ccVars.Pages[ccVars.PageIndex].Layers[index3].Name == ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].LayerName && ccVars.Pages[ccVars.PageIndex].Layers[index3].Diemaker != null && ccVars.Pages[ccVars.PageIndex].Layers[index3].Diemaker.Type == codeType & ccVars.Pages[ccVars.PageIndex].Layers[index3].Diemaker.Pt == ptRealValue)
                    flag2 = true;
                }
              }
            }
          }
          else
          {
            for (int index4 = 0; index4 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index4)
            {
              if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].EntityData != null & (!flag1 | flag1 & ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected) && ((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].EntityData).CamSelectable)
              {
                for (int index5 = 0; index5 <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index5)
                {
                  if (ccVars.Pages[ccVars.PageIndex].Layers[index5].Name == ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].LayerName && ccVars.Pages[ccVars.PageIndex].Layers[index5].Diemaker != null && ccVars.Pages[ccVars.PageIndex].Layers[index5].Diemaker.Pt == ptRealValue)
                    flag2 = true;
                }
              }
            }
          }
          if (flag2)
            laserMaterialDataList1.Add(new LaserMaterialData(this.Materials[clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial].Orders[index1]));
        }
      }
      if (laserMaterialDataList1.Count > 0)
      {
        if (clsLaserRouter.FrmLaserStartOrder != null)
        {
          if (!clsLaserRouter.FrmLaserStartOrder.Visible)
          {
            clsLaserRouter.FrmLaserStartOrder.MaterialOrders.Clear();
            clsLaserRouter.FrmLaserStartOrder.MaterialOrders = new List<LaserMaterialData>();
            for (int index = 0; index <= laserMaterialDataList1.Count - 1; ++index)
            {
              LaserMaterialData laserMaterialData = new LaserMaterialData(laserMaterialDataList1[index]);
              clsLaserRouter.FrmLaserStartOrder.MaterialOrders.Add(laserMaterialData);
            }
            clsLaserRouter.FrmLaserStartOrder.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
            clsLaserRouter.FrmLaserStartOrder.Init();
            int num2 = (int) clsLaserRouter.FrmLaserStartOrder.ShowDialog();
            if (clsLaserRouter.FrmLaserStartOrder.PropertiesForm.Result == DialogResult.OK)
            {
              laserMaterialDataList1.Clear();
              laserMaterialDataList1 = new List<LaserMaterialData>();
              for (int index = 0; index <= clsLaserRouter.FrmLaserStartOrder.MaterialOrders.Count - 1; ++index)
              {
                LaserMaterialData laserMaterialData = new LaserMaterialData(clsLaserRouter.FrmLaserStartOrder.MaterialOrders[index]);
                laserMaterialDataList1.Add(laserMaterialData);
              }
            }
            else
            {
              clsInit.appCommand.Reset();
              return;
            }
          }
          else
            clsLaserRouter.FrmLaserStartOrder.Visible = false;
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
        if (clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial >= 0 & clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial <= this.Materials.Count - 1)
        {
          for (int index6 = 0; index6 <= laserMaterialDataList1.Count - 1; ++index6)
          {
            if (laserMaterialDataList1[index6].Enable)
            {
              int num3 = 0;
              if (laserMaterialDataList1[index6].PtRealValue == 3.0 & clsLaserRouter.varLaserSettings.Pt3DoubleCutEnable)
                num3 = 1;
              if (laserMaterialDataList1[index6].PtRealValue == 4.0 & clsLaserRouter.varLaserSettings.Pt4DoubleCutEnable)
                num3 = 1;
              if (laserMaterialDataList1[index6].PtRealValue == 6.0 & clsLaserRouter.varLaserSettings.Pt6DoubleCutEnable)
                num3 = 1;
              if (laserMaterialDataList1[index6].PtRealValue == 1.0)
                ccVars.toolActive.Geometry.Diameter = clsLaserRouter.varLaserSettings.Pt1ThicknessValue / 2.0;
              if (laserMaterialDataList1[index6].PtRealValue == 2.0)
                ccVars.toolActive.Geometry.Diameter = clsLaserRouter.varLaserSettings.Pt2ThicknessValue / 2.0;
              if (laserMaterialDataList1[index6].PtRealValue == 3.0)
                ccVars.toolActive.Geometry.Diameter = clsLaserRouter.varLaserSettings.Pt3ThicknessValue / 2.0;
              if (laserMaterialDataList1[index6].PtRealValue == 4.0)
                ccVars.toolActive.Geometry.Diameter = clsLaserRouter.varLaserSettings.Pt4ThicknessValue / 2.0;
              if (laserMaterialDataList1[index6].PtRealValue == 6.0)
                ccVars.toolActive.Geometry.Diameter = clsLaserRouter.varLaserSettings.Pt6ThicknessValue / 2.0;
              for (int index7 = 0; index7 <= num3; ++index7)
              {
                if (num3 == 0)
                {
                  buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
                  buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
                  buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
                }
                else
                {
                  if (index7 == 0)
                  {
                    buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft;
                    buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.OpenContour = CamOpenContourType.Left;
                    buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
                  }
                  if (index7 == 1)
                  {
                    buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsRight;
                    buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.OpenContour = CamOpenContourType.Right;
                    buMWLaserRouterVars.varCamLaserWFContour.buPar.Offsets.ClosedContour = CamClosedContourType.Outter;
                  }
                }
                bool flag3 = false;
                DiemakerType codeType = laserMaterialDataList1[index6].CodeType;
                double ptRealValue = laserMaterialDataList1[index6].PtRealValue;
                buMWLaserRouterVars.varCamLaserWFContour.mwPar.MachParam.FeedRate = laserMaterialDataList1[index6].FeedXPlus;
                buMWLaserRouterVars.varCamLaserWFContour.buPar.Speeds.Feed = laserMaterialDataList1[index6].FeedXPlus;
                if (!laserMaterialDataList1[index6].ApplyAll)
                {
                  for (int index8 = 0; index8 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index8)
                  {
                    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index8].EntityData != null & (!flag1 | flag1 & ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index8].Selected))
                    {
                      for (int index9 = 0; index9 <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index9)
                      {
                        if (ccVars.Pages[ccVars.PageIndex].Layers[index9].Name == ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index8].LayerName && ccVars.Pages[ccVars.PageIndex].Layers[index9].Diemaker != null && ccVars.Pages[ccVars.PageIndex].Layers[index9].Diemaker.Type == codeType & ccVars.Pages[ccVars.PageIndex].Layers[index9].Diemaker.Pt == ptRealValue)
                        {
                          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index8].Selected = true;
                          str1 = ccVars.Pages[ccVars.PageIndex].Layers[index9].Diemaker.Type.ToString();
                          num1 = ccVars.Pages[ccVars.PageIndex].Layers[index9].Diemaker.Pt;
                          flag3 = true;
                        }
                      }
                    }
                  }
                }
                else
                {
                  for (int index10 = 0; index10 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index10)
                  {
                    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index10].EntityData != null & (!flag1 | flag1 & ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index10].Selected) && ((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index10].EntityData).CamSelectable)
                    {
                      for (int index11 = 0; index11 <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index11)
                      {
                        if (ccVars.Pages[ccVars.PageIndex].Layers[index11].Name == ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index10].LayerName && ccVars.Pages[ccVars.PageIndex].Layers[index11].Diemaker != null && ccVars.Pages[ccVars.PageIndex].Layers[index11].Diemaker.Pt == ptRealValue)
                        {
                          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index10].Selected = true;
                          str1 = ccVars.Pages[ccVars.PageIndex].Layers[index11].Diemaker.Type.ToString();
                          num1 = ccVars.Pages[ccVars.PageIndex].Layers[index11].Diemaker.Pt;
                          flag3 = true;
                        }
                      }
                    }
                  }
                }
                if (flag3)
                {
                  for (int index12 = 0; index12 <= clsVar.Cf2Properties.Count - 1; ++index12)
                  {
                    if (clsVar.Cf2Properties[index12].CodeType.ToString() == str1 & clsVar.Cf2Properties[index12].PtIndex == num1 && clsVar.Cf2Properties[index12].ToolNo > 0)
                      ccVars.toolActive.Data.No = clsVar.Cf2Properties[index12].ToolNo;
                  }
                  laserMaterialDataList2.Add(new LaserMaterialData(laserMaterialDataList1[index6]));
                  ccVars.UndoDont = true;
                  camTp Cam = new camTp();
                  this.doWireframeContourLaser(new MWCalculationOptions()
                  {
                    NumberofAxis = 3,
                    CamWireframeType = CamWireFrameType.Contour,
                    Mode = CamMode.WireFrame,
                    DontApplyReset = true,
                    isBuWireframeCalculation = clsLaserRouter.varLaserSettings.isBuCalculation,
                    AddToCamListInMWCalculation = false,
                    DontShowDialogBox = true,
                    isBuSort = clsLaserRouter.varLaserSettings.isBuSorting,
                    UseStartPoint = clsLaserRouter.varLaserSettings.UseStartPoint,
                    UseConstantStartPoint = true,
                    StartPointX = 0.0,
                    StartPointY = 0.0
                  }, ref Cam);
                }
              }
            }
          }
          for (int index13 = 0; index13 <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index13)
          {
            for (int index14 = 0; index14 <= ccVars.Pages[ccVars.PageIndex].Cams[index13].CamPoints.Count - 1; ++index14)
            {
              ccVars.Pages[ccVars.PageIndex].Cams[index13].CamPoints[index14].Points[0].Type = 0;
              for (int index15 = ccVars.Pages[ccVars.PageIndex].Cams[index13].CamPoints[index14].Points.Count - 1; index15 >= 0; --index15)
              {
                if (ccVars.Pages[ccVars.PageIndex].Cams[index13].CamPoints[index14].Points[index15].PlungeAxisMovement)
                  ccVars.Pages[ccVars.PageIndex].Cams[index13].CamPoints[index14].Points.RemoveAt(index15);
              }
            }
          }
          int index16 = 0;
          for (int index17 = count; index17 <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index17)
          {
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            double num10 = 0.0;
            LaserMaterialData laserMaterialData = new LaserMaterialData(laserMaterialDataList2[index16]);
            ccVars.Pages[ccVars.PageIndex].Cams[index17].PreCodes.Add((object) ("M40 K" + laserMaterialData.Height.ToString()));
            double num11 = 9999999999.0;
            for (int index18 = 0; index18 <= ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints.Count - 1; ++index18)
            {
              if (laserMaterialData.Acceleration > 0.0)
                ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].PreCodes.Add((object) ("M15 K" + laserMaterialData.Acceleration.ToString()));
              if (laserMaterialData.Jerk > 0.0)
                ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].PreCodes.Add((object) ("M16 K" + laserMaterialData.Jerk.ToString()));
              num6 += laserMaterialData.PowerDelayTime / 1000.0;
              num7 += laserMaterialData.PowerStopTime / 1000.0;
              int num12;
              if (laserMaterialData.PtRealValue <= 3.0)
              {
                ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].PreCodes.Add((object) ("M10 K" + laserMaterialData.PtRealValue.ToString()));
              }
              else
              {
                ArrayList preCodes = ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].PreCodes;
                num12 = Convert.ToInt32(laserMaterialData.PtRealValue / 2.0);
                string str2 = "M10 K" + num12.ToString();
                preCodes.Add((object) str2);
              }
              ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].PreCodes.Add((object) ("M6 K" + laserMaterialData.PowerDelayTime.ToString()));
              ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].PreCodes.Add((object) ("M7 K" + laserMaterialData.PowerStopTime.ToString()));
              ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].PreCodes.Add((object) ("M20 K" + laserMaterialData.FocusXPlus.ToString()));
              ArrayList preCodes1 = ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].PreCodes;
              num12 = Convert.ToInt32((object) laserMaterialData.LaserSelect) + 1;
              string str3 = "M4 K" + num12.ToString();
              preCodes1.Add((object) str3);
              for (int index19 = 0; index19 <= ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points.Count - 1; ++index19)
              {
                if (ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Type == 0)
                {
                  ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].AfterCodes.Add((object) ("M3 K" + laserMaterialData.CuttingPower.ToString()));
                  num8 += clsLaserRouter.varLaserSettings.LaserStartTime / 1000.0;
                  if (index19 > 0)
                  {
                    Pnt3D StartPoint = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19 - 1].P9);
                    Pnt3D EndPoint = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].P9);
                    double Distance = clsInit.cVector.Length3D(StartPoint, EndPoint, new WorkPlane());
                    double num13 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(clsLaserRouter.varLaserSettings.G0FeedMmperSec, Distance, laserMaterialData.Acceleration, laserMaterialData.Acceleration);
                    num5 += num13;
                    num10 += Distance;
                  }
                }
                if (ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Type == 1 && index19 > 0)
                {
                  Pnt3D pnt3D1 = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19 - 1].P9);
                  Pnt3D pnt3D2 = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].P9);
                  double num14 = clsInit.cVector.Length3D(pnt3D1, pnt3D2, new WorkPlane());
                  double Angle = clsInit.cVector.PointAngle(pnt3D2, pnt3D1);
                  double calcValue1 = 0.0;
                  this.CalcValueFromAngleQuadrantAsValue(Angle, laserMaterialData.FeedXPlus, laserMaterialData.FeedXMinus, laserMaterialData.FeedYPlus, laserMaterialData.FeedYMinus, ref calcValue1);
                  if (calcValue1 > 0.0)
                    ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Feed = calcValue1;
                  double num15 = num14 / ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Feed;
                  num4 += num15;
                  num9 += num14;
                  double calcValue2 = 0.0;
                  this.CalcValueFromAngleQuadrantAsValue(Angle, laserMaterialData.FocusXPlus, laserMaterialData.FocusXMinus, laserMaterialData.FocusYPlus, laserMaterialData.FocusYMinus, ref calcValue2);
                  if (calcValue2 != 0.0 & calcValue2 != num11)
                  {
                    ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].PreCodes.Add((object) ("M21 K" + Math.Round(calcValue2, 2).ToString()));
                    num11 = calcValue2;
                  }
                }
                if (ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Type == 2)
                {
                  if (laserMaterialData.FeedXY > 0.0)
                    ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Feed = laserMaterialData.FeedXY;
                  if (index19 > 0)
                  {
                    Pnt3D ArcCenter = new Pnt3D();
                    double StartAngle = 0.0;
                    double EndAngle = 0.0;
                    double radius = ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Radius;
                    if (radius != 0.0)
                    {
                      Pnt3D ArcStartPoint = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19 - 1].P9);
                      Pnt3D ArcEndPoint = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].P9);
                      if (radius > 0.0)
                        clsInit.cVector.ArcWithTwoPointAndRadius(ArcStartPoint, ArcEndPoint, Math.Abs(radius), true, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                      if (radius < 0.0)
                      {
                        clsInit.cVector.ArcWithTwoPointAndRadius(ArcStartPoint, ArcEndPoint, Math.Abs(radius), true, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                        if (EndAngle - StartAngle < 180.0)
                          buGeneral.ExchangeDatas(ref StartAngle, ref EndAngle);
                        if (StartAngle > EndAngle)
                          EndAngle += 360.0;
                      }
                      double num16 = clsInit.cVector.ArcCircumference(Math.Abs(radius), StartAngle, EndAngle);
                      double num17 = num16 / ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Feed;
                      num4 += num17;
                      num9 += num16;
                    }
                    double focusXy = laserMaterialData.FocusXY;
                    if (focusXy != 0.0 & focusXy != num11)
                    {
                      ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].PreCodes.Add((object) ("M21 K" + Math.Round(focusXy, 2).ToString()));
                      num11 = focusXy;
                    }
                  }
                }
                if (ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Type == 3)
                {
                  if (laserMaterialData.FeedXY > 0.0)
                    ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Feed = laserMaterialData.FeedXY;
                  if (index19 > 0)
                  {
                    Pnt3D ArcCenter = new Pnt3D();
                    double StartAngle = 0.0;
                    double EndAngle = 0.0;
                    double radius = ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Radius;
                    if (radius != 0.0)
                    {
                      Pnt3D ArcStartPoint = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19 - 1].P9);
                      Pnt3D ArcEndPoint = new Pnt3D(ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].P9);
                      if (radius > 0.0)
                        clsInit.cVector.ArcWithTwoPointAndRadius(ArcStartPoint, ArcEndPoint, Math.Abs(radius), false, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                      if (radius < 0.0)
                      {
                        clsInit.cVector.ArcWithTwoPointAndRadius(ArcStartPoint, ArcEndPoint, Math.Abs(radius), false, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                        if (EndAngle - StartAngle < 180.0)
                          buGeneral.ExchangeDatas(ref StartAngle, ref EndAngle);
                        if (StartAngle > EndAngle)
                          EndAngle += 360.0;
                      }
                      double num18 = clsInit.cVector.ArcCircumference(Math.Abs(radius), StartAngle, EndAngle);
                      double num19 = num18 / ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Feed;
                      num4 += num19;
                      num9 += num18;
                    }
                    double focusXy = laserMaterialData.FocusXY;
                    if (focusXy != 0.0 & focusXy != num11)
                    {
                      ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].PreCodes.Add((object) ("M21 K" + Math.Round(focusXy, 2).ToString()));
                      num11 = focusXy;
                    }
                  }
                }
                if (index19 < ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points.Count - 1)
                {
                  if (ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Type == 1 | ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Type == 2 | ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Type == 3 && ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19 + 1].Type == 0)
                  {
                    num8 += clsLaserRouter.varLaserSettings.LaserStopTime / 1000.0;
                    ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].AfterCodes.Add((object) "M5");
                  }
                }
                else if (ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Type == 1 | ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Type == 2 | ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].Type == 3)
                {
                  num8 += clsLaserRouter.varLaserSettings.LaserStopTime / 1000.0;
                  ccVars.Pages[ccVars.PageIndex].Cams[index17].CamPoints[index18].Points[index19].AfterCodes.Add((object) "M5");
                }
              }
            }
            ccVars.Pages[ccVars.PageIndex].Cams[index17].Information.AirMoveSecond = num5;
            ccVars.Pages[ccVars.PageIndex].Cams[index17].Information.ProcessSecond = num4;
            ccVars.Pages[ccVars.PageIndex].Cams[index17].Information.TotalSecond = num5 + num4 + num8;
            ccVars.Pages[ccVars.PageIndex].Cams[index17].Information.StartSecond = num6;
            ccVars.Pages[ccVars.PageIndex].Cams[index17].Information.EndSecond = num7;
            ccVars.Pages[ccVars.PageIndex].Cams[index17].Information.TotalProcessLength = num9;
            ccVars.Pages[ccVars.PageIndex].Cams[index17].Information.AirMoveLength = num10;
            ccVars.Pages[ccVars.PageIndex].Cams[index17].Information.TotalLength = num9 + num10;
            ++index16;
          }
        }
        clsInit.appCommand.SetInformationAtStatus(clsInit.appLaserRouter.GetStatusInfo());
        ccVars.UndoDont = false;
      }
      else
        clsInit.appCommand.Reset();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSettingsLaser()
  {
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.Text = "Laser";
    classViewerDialog.Value = (object) clsLaserRouter.varLaserSettings;
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.Width = 500;
    classViewerDialog.Height = 400;
    classViewerDialog.ValuePersentage = 35.0;
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog();
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    clsLaserRouter.varLaserSettings = new LaserProgramSettings((LaserProgramSettings) classViewerDialog.Value);
    clsFiles.SaveParameter();
  }

  public void cmdCamCreatGCode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
        saveFileDialog.Filter = $"{ccVars.PostActive.FileExplanation} ({ccVars.PostActive.FileExtension})|{ccVars.PostActive.FileExtension}";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
          return;
        clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
        string Lines = "";
        PostProcessor Post = new PostProcessor(ccVars.PostActive);
        if (clsVar.appModes_0.LaserRouterDiamekerMode.Laser)
        {
          string str = "//" + this.Materials[clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial].Name;
          Post.StartLines.Insert(0, (object) str);
        }
        clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, Post, ref Lines);
        buFile5.SaveToFile(Lines, saveFileDialog.FileName);
        clsFiles.SaveParameter();
        if (clsItem.FrmProgress == null)
          return;
        clsItem.FrmProgress.Visible = false;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamCreatPlt()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
        saveFileDialog.Filter = "Plt File (*.plt)|*.plt";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
          return;
        for (int index1 = 0; index1 <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index1)
        {
          ccVars.Pages[ccVars.PageIndex].Cams[index1].AfterCodes.Clear();
          ccVars.Pages[ccVars.PageIndex].Cams[index1].PreCodes.Clear();
          for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Cams[index1].CamPoints.Count - 1; ++index2)
          {
            ccVars.Pages[ccVars.PageIndex].Cams[index1].CamPoints[index2].AfterCodes.Clear();
            ccVars.Pages[ccVars.PageIndex].Cams[index1].CamPoints[index2].PreCodes.Clear();
            for (int index3 = 0; index3 <= ccVars.Pages[ccVars.PageIndex].Cams[index1].CamPoints[index2].Points.Count - 1; ++index3)
            {
              ccVars.Pages[ccVars.PageIndex].Cams[index1].CamPoints[index2].Points[index3].PreCodes.Clear();
              ccVars.Pages[ccVars.PageIndex].Cams[index1].CamPoints[index2].Points[index3].AfterCodes.Clear();
            }
          }
        }
        ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Add((object) "IN");
        ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add((object) "PU 0,0IN");
        clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
        PostProcessor postProcessor = new PostProcessor(ccVars.PostActive);
        new buFile5.HPGLFile().WriteHPGL(saveFileDialog.FileName, clsVar.varFile.HPGLFileProperties, ccVars.Pages[ccVars.PageIndex].Cams);
        clsFiles.SaveParameter();
        if (clsItem.FrmProgress == null)
          return;
        clsItem.FrmProgress.Visible = false;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamShowGCode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        string Lines = "";
        PostProcessor Post = new PostProcessor(ccVars.PostActive);
        if (clsVar.appModes_0.LaserRouterDiamekerMode.Laser)
        {
          string str = "//" + this.Materials[clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial].Name;
          Post.StartLines.Insert(0, (object) str);
        }
        clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, Post, ref Lines);
        F_Notepad fNotepad = new F_Notepad();
        fNotepad.Init(Lines);
        fNotepad.Show();
        if (clsItem.FrmProgress == null)
          return;
        clsItem.FrmProgress.Visible = false;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamSendController()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num1 = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        string Lines = "";
        PostProcessor Post = new PostProcessor(ccVars.PostActive);
        if (clsVar.appModes_0.LaserRouterDiamekerMode.Laser)
        {
          string str = "//" + this.Materials[clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial].Name;
          Post.StartLines.Insert(0, (object) str);
        }
        clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, Post, ref Lines);
        if (!new DirectoryInfo(clsVar.varInterface.pathGCode).Exists)
        {
          FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
          int num2 = (int) folderBrowserDialog.ShowDialog();
          clsVar.varInterface.pathGCode = folderBrowserDialog.SelectedPath;
        }
        buFile5.SaveToFile(Lines, clsVar.varInterface.pathGCode + "\\AutoLaser.cnc");
        clsFiles.SaveParameter();
        if (clsItem.FrmProgress != null)
          clsItem.FrmProgress.Visible = false;
        clsInit.appCommand.cmdCamRemoveAll(true);
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void SentToController(string FileName)
  {
    FTPConnect ftpConnect = new FTPConnect();
    FTPConnect.ftpConnectionProperties.IP = clsVar.varCommunication.IPNumber;
    FTPConnect.ftpConnectionProperties.UserName = clsVar.varCommunication.FtpUser;
    FTPConnect.ftpConnectionProperties.Password = clsVar.varCommunication.FtpPassword;
    FTPConnect.ftpConnectionProperties.Port = clsVar.varCommunication.FtpPort;
    ftpConnect.FtpClientConnect();
    if (ftpConnect.FtpClientFileTransfer(FileName, clsVar.varCommunication.FtpPath + "\\AutoLaser.cnc"))
      return;
    buString5.MessageBoxError("FileTransfer Error");
  }

  public void cmdSelectRules()
  {
    F_LayerList fLayerList = new F_LayerList();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      fLayerList.Layers.Add(ccVars.Pages[ccVars.PageIndex].Layers[index]);
    if (fLayerList.Layers.Count <= 0)
      return;
    fLayerList.Text = "Select Rule";
    fLayerList.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
    fLayerList.Init();
    int num = (int) fLayerList.ShowDialog();
    if (fLayerList.PropertiesForm.Result != DialogResult.OK)
      return;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
    List<int> Added = new List<int>();
    if (fLayerList.SelectedLayerIndex >= 0)
    {
      string name = fLayerList.Layers[fLayerList.SelectedLayerIndex].Name;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName == name)
        {
          bool flag = true;
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() == typeof (buArcCam))
            flag = false;
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() == typeof (buLineCam))
            flag = false;
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() == typeof (buLinearPathCam))
            flag = false;
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() == typeof (buCompositeCurveCam))
            flag = false;
          if (flag)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
            Added.Add(index);
          }
        }
      }
    }
    if (Added.Count > 0)
      clsInit.appCommand.SelectedToSelectionAdd(Added);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdChangeRuleType()
  {
    try
    {
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        buString5.MessageBoxWarning(AppLanguage.CadCamMessages[7]);
      }
      else
      {
        F_LayerList fLayerList = new F_LayerList();
        for (int index = 0; index <= clsVar.Cf2Properties.Count - 1; ++index)
        {
          LayerBase5 layerBase5 = new LayerBase5()
          {
            LayerColor = clsVar.Cf2Properties[index].Color,
            Name = $"{clsVar.Cf2Properties[index].CodeType.ToString()}-{clsVar.Cf2Properties[index].PtRealValue.ToString()}Pt",
            Diemaker = new LayerDiemakerProps()
          };
          layerBase5.Diemaker.Pt = clsVar.Cf2Properties[index].PtRealValue;
          layerBase5.Diemaker.Type = clsVar.Cf2Properties[index].CodeType;
          layerBase5.Selectable = clsVar.Cf2Properties[index].Selectable;
          fLayerList.Layers.Add(layerBase5);
        }
        if (fLayerList.Layers.Count <= 0)
          return;
        fLayerList.Text = "Rule Change";
        fLayerList.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
        fLayerList.Init();
        int num = (int) fLayerList.ShowDialog();
        if (fLayerList.PropertiesForm.Result == DialogResult.OK)
        {
          if (fLayerList.SelectedLayerIndex >= 0)
          {
            LayerBase5 buLayer = new LayerBase5(fLayerList.Layers[fLayerList.SelectedLayerIndex]);
            bool flag = false;
            string LayerName = "";
            bool SetValue = true;
            for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
            {
              if (ccVars.Pages[ccVars.PageIndex].Layers[index].Diemaker.Pt == buLayer.Diemaker.Pt && ccVars.Pages[ccVars.PageIndex].Layers[index].Diemaker.Type == buLayer.Diemaker.Type)
              {
                flag = true;
                LayerName = ccVars.Pages[ccVars.PageIndex].Layers[index].Name;
                SetValue = ccVars.Pages[ccVars.PageIndex].Layers[index].Selectable;
              }
            }
            if (!flag)
            {
              ccVars.Pages[ccVars.PageIndex].Layers.Add(buLayer);
              Layer eyeLayer = (Layer) null;
              buConversion5.buLayerToeyeLayer(buLayer, ref eyeLayer);
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(eyeLayer);
              LayerName = buLayer.Name;
              SetValue = buLayer.Selectable;
            }
            string name = fLayerList.Layers[fLayerList.SelectedLayerIndex].Name;
            for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
            {
              if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected)
              {
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName = name;
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Color = fLayerList.Layers[fLayerList.SelectedLayerIndex].LayerColor;
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LineWeight = fLayerList.Layers[fLayerList.SelectedLayerIndex].LayerThickness;
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = false;
              }
            }
            clsInit.cVector5.SetSelectableByLayerName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, SetValue, LayerName);
          }
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved();
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
          clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, true, -1);
          clsInit.appCommand.Reset();
        }
        else
          clsInit.appCommand.Reset();
      }
    }
    catch (Exception ex)
    {
      string str = nameof (cmdChangeRuleType);
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void cmdShowInformation()
  {
    string statusFullInfo = this.GetStatusFullInfo(true);
    DialogBoxMultiText dialogBoxMultiText = new DialogBoxMultiText();
    dialogBoxMultiText.Value = statusFullInfo;
    dialogBoxMultiText.Text = "Information";
    dialogBoxMultiText.Init(statusFullInfo);
    int num = (int) dialogBoxMultiText.ShowDialog();
  }

  public void cmdRotate()
  {
    List<int> Added = new List<int>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
      Added.Add(index);
    }
    if (Added.Count <= 0)
      return;
    clsInit.appCommand.SelectedToSelectionAdd(Added);
    clsInit.appCommand.Rotate(new Point3D(), Utility.DegToRad(90.0), true, false);
  }

  public void cmdMirror()
  {
    List<int> Added1 = new List<int>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
      Added1.Add(index);
    }
    if (Added1.Count <= 0)
      return;
    clsInit.appCommand.SelectedToSelectionAdd(Added1);
    clsInit.appCommand.Mirror(new Point3D(), new Point3D(0.0, 100.0, 0.0), true, false, true);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved();
    List<int> Added2 = new List<int>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
      Added2.Add(index);
    }
    clsInit.appCommand.SelectedToSelectionAdd(Added2);
    clsInit.appCommand.Move(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.BoxMin, new Point3D());
  }

  public void cmdMoveZero()
  {
    List<int> Added = new List<int>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
      Added.Add(index);
    }
    if (Added.Count <= 0)
      return;
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    clsInit.cVector5.BoxSizeCalculate(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
    clsInit.appCommand.SelectedToSelectionAdd(Added);
    clsInit.appCommand.Move(MinPoint, new Point3D());
  }

  public void cmdMoveZeroPoint()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.eventMovePointToZero;
      dynamicInfo.Command = AppLanguage.CadCamStatus[123];
      ccVars.selectionProcess = false;
      ccVars.stpDrawing = 1;
      clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void LoadLanguage()
  {
    List<string> CalcList = new List<string>();
    FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buLaser.lng") : new FileInfo(AppPath.Language + "\\buLaser.lng");
    if (fileInfo.Exists)
    {
      List<string> StringList = new List<string>();
      buFile.OpenFromFile(fileInfo.FullName, ref StringList);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Main>", "</F_Main>", StringList), clsVar.varRuntime.Language, ref CalcList);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MaterialSettings>", "</MaterialSettings>", StringList), clsVar.varRuntime.Language, ref F_LaserMaterial.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_LaserStartOrder>", "</F_LaserStartOrder>", StringList), clsVar.varRuntime.Language, ref F_LaserStartOrder.Captions);
      StringList.Clear();
    }
    else
    {
      buLog.addLog("LaserLanguage", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Laser Language File Missing");
    }
    if (CalcList.Count > 0)
      ;
  }

  public void CalcValueFromAngleQuadrantAsRatio(
    double Angle,
    double Value,
    double XPlusRatio,
    double XMinusRatio,
    double YPlusRatio,
    double YMinusRatio,
    ref double calcValue)
  {
    double X3 = 1.0;
    if (Angle >= 0.0 & Angle <= 90.0)
      buNumeric.EquationLineer(XPlusRatio, YPlusRatio, 0.0, 90.0, Angle, ref X3);
    else if (Angle >= 90.0 & Angle <= 180.0)
      buNumeric.EquationLineer(XMinusRatio, YPlusRatio, 90.0, 180.0, Angle, ref X3);
    else if (Angle >= 180.0 & Angle <= 270.0)
      buNumeric.EquationLineer(XMinusRatio, YMinusRatio, 180.0, 270.0, Angle, ref X3);
    else if (Angle >= 270.0 & Angle <= 360.0)
      buNumeric.EquationLineer(XPlusRatio, YMinusRatio, 270.0, 360.0, Angle, ref X3);
    calcValue = X3 * Value;
  }

  public void CalcValueFromAngleQuadrantAsValue(
    double Angle,
    double XPlusValue,
    double XMinusValue,
    double YPlusValue,
    double YMinusValue,
    ref double calcValue)
  {
    double X3 = 1.0;
    if (Angle >= 0.0 & Angle <= 90.0)
      buNumeric.EquationLineer(XPlusValue, YPlusValue, 0.0, 90.0, Angle, ref X3);
    else if (Angle >= 90.0 & Angle <= 180.0)
      buNumeric.EquationLineer(YPlusValue, XMinusValue, 90.0, 180.0, Angle, ref X3);
    else if (Angle >= 180.0 & Angle <= 270.0)
      buNumeric.EquationLineer(XMinusValue, YMinusValue, 180.0, 270.0, Angle, ref X3);
    else if (Angle >= 270.0 & Angle <= 360.0)
      buNumeric.EquationLineer(YMinusValue, XPlusValue, 270.0, 360.0, Angle, ref X3);
    calcValue = X3;
  }

  public void SaveLaserFile()
  {
    string FileName1 = AppPath.Settings + "\\Laser\\Laser.prm";
    ArrayList StringList1 = new ArrayList();
    StringList1.Add((object) "<LaserMaterials>");
    for (int index1 = 0; index1 <= this.Materials.Count - 1; ++index1)
    {
      StringList1.Add((object) "  <LaserMaterial>");
      StringList1.Add((object) ("    " + this.Materials[index1].Name));
      for (int index2 = 0; index2 <= this.Materials[index1].Orders.Count - 1; ++index2)
        StringList1.AddRange((ICollection) this.Materials[index1].Orders[index2].ToDefAll("", 4, SerilizationMode.MultiLine));
      StringList1.Add((object) "  </LaserMaterial>");
    }
    StringList1.Add((object) "</LaserMaterials>");
    StringList1.Add((object) "<Cf2Props>");
    for (int index = 0; index <= clsVar.Cf2Properties.Count - 1; ++index)
      StringList1.AddRange((ICollection) clsVar.Cf2Properties[index].ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList1.Add((object) "</Cf2Props>");
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "   Router Settings");
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "<RouterSettings>");
    StringList1.AddRange((ICollection) clsLaserRouter.varRouterSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList1.Add((object) "</RouterSettings>");
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "   Laser Settings");
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "<LaserSettings>");
    StringList1.AddRange((ICollection) clsLaserRouter.varLaserSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList1.Add((object) "</LaserSettings>");
    StringList1.Add((object) "<LaserRuntimeSettings>");
    StringList1.AddRange((ICollection) clsLaserRouter.varLaserRuntimeSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList1.Add((object) "</LaserRuntimeSettings>");
    buFile.SaveToFile(StringList1, FileName1);
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
    string FileName2 = AppPath.Settings + "\\Laser\\RouterCam.bucamset";
    ArrayList StringList2 = new ArrayList();
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "   MW Cam Settings");
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "<MwCamSettings>");
    StringList2.AddRange((ICollection) buMWLaserRouterVars.varCamWoodTop.buPar.ToDefAll("_varbuRouterCamWoodTopPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWLaserRouterVars.varCamWoodBottom.buPar.ToDefAll("_varbuRouterCamWoodBottomPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWLaserRouterVars.varCamPertinaxInCut.buPar.ToDefAll("_varbuRouterCamPertinaxIncutPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWLaserRouterVars.varCamPertinaxOutCut.buPar.ToDefAll("_varbuRouterCamPertinaxOutcutPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWLaserRouterVars.varCamPertinaxHoleCut.buPar.ToDefAll("_varbuRouterCamPertinaxHolePars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWLaserRouterVars.varCamPertinaxTextCut.buPar.ToDefAll("_varbuRouterCamPertinaxTextPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWLaserRouterVars.varCamSteelContour.buPar.ToDefAll("_varbuRouterCamSteelContourPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWLaserRouterVars.varCamSteelPocket.buPar.ToDefAll("_varbuRouterCamSteelPocketPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWLaserRouterVars.varCamSteelText.buPar.ToDefAll("_varbuRouterCamSteelTextPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWLaserRouterVars.varCamLaserWFContour.buPar.ToDefAll("_varCamLaserWFContour", 2, SerilizationMode5.MultiLine));
    StringList2.Add((object) "</MwCamSettings>");
    buFile.SaveToFile(StringList2, FileName2);
  }

  public void OpenLaserFile()
  {
    try
    {
      ArrayList arrayList1 = new ArrayList();
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Laser\\Laser.prm");
      this.Materials = new List<LaserMaterial>();
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList1 = new ArrayList();
          buString.ListToSpecificList("<LaserSettings>", "</LaserSettings>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) clsLaserRouter.varLaserSettings);
            buLog.addLog("LaserSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList1 = new ArrayList();
          buString.ListToSpecificList("<RouterSettings>", "</RouterSettings>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) clsLaserRouter.varRouterSettings);
            buLog.addLog("RouterSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList1 = new ArrayList();
          buString.ListToSpecificList("<LaserRuntimeSettings>", "</LaserRuntimeSettings>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) clsLaserRouter.varLaserRuntimeSettings);
            buLog.addLog("LaserRuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          List<List<string>> CalcList2 = new List<List<string>>();
          buString.ListToSpecificList("<LaserMaterial>", "</LaserMaterial>", true, StringList, ref CalcList2);
          if (CalcList2.Count > 0)
          {
            for (int index1 = 0; index1 <= CalcList2.Count - 1; ++index1)
            {
              LaserMaterial laserMaterial = new LaserMaterial();
              laserMaterial.Name = CalcList2[index1][1];
              buSerilization.Decode(CalcList2[index1], "", SerilizationMode.MultiLine, (object) laserMaterial);
              List<List<string>> CalcList3 = new List<List<string>>();
              buString.ListToSpecificList("<LaserMaterialData>", "</LaserMaterialData>", true, CalcList2[index1], ref CalcList3);
              for (int index2 = 0; index2 <= CalcList3.Count - 1; ++index2)
              {
                LaserMaterialData laserMaterialData = new LaserMaterialData();
                buSerilization.Decode(CalcList3[index2], "", SerilizationMode.MultiLine, (object) laserMaterialData);
                laserMaterial.Orders.Add(laserMaterialData);
              }
              this.Materials.Add(laserMaterial);
            }
          }
          ArrayList CalcList4 = new ArrayList();
          CalcList2 = new List<List<string>>();
          clsVar.Cf2Properties = new List<Cf2FileProperties>();
          buString.ListToSpecificList("<Cf2Props>", "</Cf2Props>", true, StringList, ref CalcList4);
          buString.ListToSpecificList("<Cf2FileProperties>", "</Cf2FileProperties>", true, CalcList4, ref CalcList2);
          if (CalcList2.Count > 0)
          {
            for (int index = 0; index <= CalcList2.Count - 1; ++index)
            {
              Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
              buSerilization.Decode(CalcList2[index], "", SerilizationMode.MultiLine, (object) cf2FileProperties);
              clsVar.Cf2Properties.Add(cf2FileProperties);
            }
          }
          ArrayList arrayList2 = new ArrayList();
          CalcList2 = new List<List<string>>();
        }
        catch (Exception ex)
        {
          buLog.addLog("Laser Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Laser Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Laser Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Laser Settings File Missing");
      }
      buLog.addLog("Laser Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterWoodTop.bin");
      if (fileInfo2.Exists)
        buMWLaserRouterVars.varCamWoodTop.mwPar.Deserialize(fileInfo2.FullName);
      FileInfo fileInfo3 = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterWoodBottom.bin");
      if (fileInfo3.Exists)
        buMWLaserRouterVars.varCamWoodBottom.mwPar.Deserialize(fileInfo3.FullName);
      FileInfo fileInfo4 = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterPertinaxIncut.bin");
      if (fileInfo4.Exists)
        buMWLaserRouterVars.varCamPertinaxInCut.mwPar.Deserialize(fileInfo4.FullName);
      FileInfo fileInfo5 = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterPertinaxOutcut.bin");
      if (fileInfo5.Exists)
        buMWLaserRouterVars.varCamPertinaxOutCut.mwPar.Deserialize(fileInfo5.FullName);
      FileInfo fileInfo6 = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterPertinaxHole.bin");
      if (fileInfo6.Exists)
        buMWLaserRouterVars.varCamPertinaxHoleCut.mwPar.Deserialize(fileInfo6.FullName);
      FileInfo fileInfo7 = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterPertinaxText.bin");
      if (fileInfo7.Exists)
        buMWLaserRouterVars.varCamPertinaxTextCut.mwPar.Deserialize(fileInfo7.FullName);
      FileInfo fileInfo8 = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterSteelContour.bin");
      if (fileInfo8.Exists)
        buMWLaserRouterVars.varCamSteelContour.mwPar.Deserialize(fileInfo8.FullName);
      FileInfo fileInfo9 = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterSteelPocket.bin");
      if (fileInfo9.Exists)
        buMWLaserRouterVars.varCamSteelPocket.mwPar.Deserialize(fileInfo9.FullName);
      FileInfo fileInfo10 = new FileInfo(AppPath.Settings + "\\Laser\\mwRouterSteelText.bin");
      if (fileInfo10.Exists)
        buMWLaserRouterVars.varCamSteelText.mwPar.Deserialize(fileInfo10.FullName);
      FileInfo fileInfo11 = new FileInfo(AppPath.Settings + "\\Laser\\mwLaserContour.bin");
      if (fileInfo11.Exists)
        buMWLaserRouterVars.varCamLaserWFContour.mwPar.Deserialize(fileInfo11.FullName);
      string str = AppPath.Settings + "\\Laser\\RouterCam.bucamset";
      if (new FileInfo(str).Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(str, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", true, StringList, ref CalcList);
          if (CalcList.Count <= 0)
            return;
          buSerilization.Decode(StringList, "_varbuRouterCamWoodTopPars", SerilizationMode.MultiLine, (object) buMWLaserRouterVars.varCamWoodTop.buPar);
          buSerilization.Decode(StringList, "_varbuRouterCamWoodBottomPars", SerilizationMode.MultiLine, (object) buMWLaserRouterVars.varCamWoodBottom.buPar);
          buSerilization.Decode(StringList, "_varbuRouterCamPertinaxIncutPars", SerilizationMode.MultiLine, (object) buMWLaserRouterVars.varCamPertinaxInCut.buPar);
          buSerilization.Decode(StringList, "_varbuRouterCamPertinaxOutcutPars", SerilizationMode.MultiLine, (object) buMWLaserRouterVars.varCamPertinaxOutCut.buPar);
          buSerilization.Decode(StringList, "_varbuRouterCamPertinaxHolePars", SerilizationMode.MultiLine, (object) buMWLaserRouterVars.varCamPertinaxHoleCut.buPar);
          buSerilization.Decode(StringList, "_varbuRouterCamPertinaxTextPars", SerilizationMode.MultiLine, (object) buMWLaserRouterVars.varCamPertinaxTextCut.buPar);
          buSerilization.Decode(StringList, "_varbuRouterCamSteelContourPars", SerilizationMode.MultiLine, (object) buMWLaserRouterVars.varCamSteelContour.buPar);
          buSerilization.Decode(StringList, "_varbuRouterCamSteelPocketPars", SerilizationMode.MultiLine, (object) buMWLaserRouterVars.varCamSteelPocket.buPar);
          buSerilization.Decode(StringList, "_varbuRouterCamSteelTextPars", SerilizationMode.MultiLine, (object) buMWLaserRouterVars.varCamSteelText.buPar);
          buSerilization.Decode(StringList, "_varCamLaserWFContour", SerilizationMode.MultiLine, (object) buMWLaserRouterVars.varCamLaserWFContour.buPar);
        }
        catch (Exception ex)
        {
          buLog.addLog("MW Laser Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Laser Settings Decoder Error");
        }
      }
      else
      {
        buLog.addLog("Laser Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Laser Cam Settings File Missing");
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("Laser Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Laser Settings Decoder Error");
    }
  }

  public string GetStatusInfo()
  {
    string statusInfo = "";
    if (ccVars.Pages.Count > 0)
      statusInfo = $"{statusInfo}dX: {ccVars.Pages[ccVars.PageIndex].Info.EntitiesBoxSize.X.ToString("f3")} - dY: {ccVars.Pages[ccVars.PageIndex].Info.EntitiesBoxSize.Y.ToString("f3")}";
    if (clsInit.appLaserRouter.Materials.Count > 0 & clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial >= 0 & clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial <= clsInit.appLaserRouter.Materials.Count - 1)
      statusInfo = $"{statusInfo} - Parameter : {clsInit.appLaserRouter.Materials[clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial].Name}";
    if (ccVars.Pages.Count > 0 && ccVars.Pages[ccVars.PageIndex].Cams.Count > 0)
    {
      double num = 0.0;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index)
        num += ccVars.Pages[ccVars.PageIndex].Cams[index].Information.TotalSecond;
      string str = TimeSpan.FromSeconds(num).ToString("hh\\:mm\\:ss");
      statusInfo = $"{statusInfo} - Time : {str}";
    }
    return statusInfo;
  }

  public string GetStatusFullInfo(bool MultiLine)
  {
    string statusFullInfo = "";
    if (ccVars.Pages.Count > 0)
      statusFullInfo = $"{statusFullInfo}dX: {ccVars.Pages[ccVars.PageIndex].Info.EntitiesBoxSize.X.ToString("f3")} - dY: {ccVars.Pages[ccVars.PageIndex].Info.EntitiesBoxSize.Y.ToString("f3")}";
    if (MultiLine)
      statusFullInfo += Environment.NewLine;
    if (clsInit.appLaserRouter.Materials.Count > 0 & clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial >= 0 & clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial <= clsInit.appLaserRouter.Materials.Count - 1)
      statusFullInfo = $"{statusFullInfo}Parameter : {clsInit.appLaserRouter.Materials[clsLaserRouter.varLaserRuntimeSettings.SelectedMaterial].Name}";
    if (MultiLine)
      statusFullInfo += Environment.NewLine;
    if (ccVars.Pages.Count > 0 && ccVars.Pages[ccVars.PageIndex].Cams.Count > 0)
    {
      double num1 = 0.0;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index)
        num1 += ccVars.Pages[ccVars.PageIndex].Cams[index].Information.TotalSecond;
      string str1 = TimeSpan.FromSeconds(num1).ToString("hh\\:mm\\:ss");
      string str2 = $"{statusFullInfo}Total Time : {str1}";
      if (MultiLine)
        str2 += Environment.NewLine;
      double num2 = 0.0;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index)
        num2 += ccVars.Pages[ccVars.PageIndex].Cams[index].Information.ProcessSecond;
      string str3 = TimeSpan.FromSeconds(num2).ToString("hh\\:mm\\:ss");
      string str4 = $"{str2}Operation Time : {str3}";
      if (MultiLine)
        str4 += Environment.NewLine;
      double num3 = 0.0;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index)
        num3 += ccVars.Pages[ccVars.PageIndex].Cams[index].Information.AirMoveSecond;
      string str5 = TimeSpan.FromSeconds(num3).ToString("hh\\:mm\\:ss");
      string str6 = $"{str4}Air Move Time : {str5}";
      if (MultiLine)
        str6 += Environment.NewLine;
      double num4 = 0.0;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index)
        num4 += ccVars.Pages[ccVars.PageIndex].Cams[index].Information.TotalLength;
      string str7 = $"{str6}Total Length : {num4.ToString("f3")} mm";
      if (MultiLine)
        str7 += Environment.NewLine;
      double num5 = 0.0;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index)
        num5 += ccVars.Pages[ccVars.PageIndex].Cams[index].Information.TotalProcessLength;
      string str8 = $"{str7}Operation Length : {num5.ToString("f3")} mm";
      if (MultiLine)
        str8 += Environment.NewLine;
      double num6 = 0.0;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index)
        num6 += ccVars.Pages[ccVars.PageIndex].Cams[index].Information.AirMoveLength;
      statusFullInfo = $"{str8}Air Move Length : {num6.ToString("f3")} mm";
      if (MultiLine)
        statusFullInfo += Environment.NewLine;
    }
    return statusFullInfo;
  }

  public void doWireframeContourLaser(MWCalculationOptions MWCalcoptions, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWLaserRouterVars.varCamLaserWFContour.mwPar, buMWLaserRouterVars.varCamLaserWFContour.buPar, out clsMW.varbuCamWFContourPars);
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
    buMWLaserRouterVars.varCamLaserWFContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWLaserRouterVars.varCamLaserWFContour.buPar);
    if (num < 1)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      if (this.CamOtherEntities != null && this.CamOtherEntities.Count > 0)
      {
        for (int index = 0; index <= this.CamOtherEntities.Count - 1; ++index)
        {
          Entity copiedEnt = (Entity) null;
          buVector5.CopyEntities(this.CamOtherEntities[index], ref copiedEnt);
          Cam.EntitiesOther.Add(copiedEnt);
        }
      }
      Cam.Mode = MWCalcoptions.Mode;
      Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
      Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
      Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
      if (MWCalcoptions.Mode == CamMode.WireFrame && MWCalcoptions.CamWireframeType == CamWireFrameType.Contour)
      {
        for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
        {
          if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
            Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
        }
        for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
        {
          if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
            Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
        }
        clsInit.appCommand.CamAdd(Cam);
      }
      clsInit.appCommand.Reset();
    }
  }

  public void doWireframeContourRouter(
    MWCalculationOptions MWCalcoptions,
    ref MWParameters Pars,
    bool isPocket,
    ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    if (!isPocket)
      clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(Pars.mwPar, Pars.buPar, out clsMW.varbuCamWFContourPars);
    else
      clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(Pars.mwPar, Pars.buPar, out clsMW.varbuCamWFPocketPars);
    MWCalcoptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
    List<Entity> refEntities = new List<Entity>();
    List<Entity> SortedEntities1 = new List<Entity>();
    SelectionOption Option = new SelectionOption();
    SortResult Result1 = new SortResult();
    Option.CircleToArc = true;
    Option.CircleTo4Arc = true;
    Option.SplitArcIfGreatThen180 = true;
    Option.Point = false;
    Option.SplitArcIfGreatThenValue = 160.0;
    clsInit.appCommand.SelectionToEntities(ref refEntities, Option);
    clsInit.cVector5.EntitiesPlaneCheck(ref refEntities);
    clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MWCalcoptions.StartPointX, MWCalcoptions.StartPointY), ref refEntities, MWCalcoptions.SortingSettings, ref SortedEntities1, ref Result1);
    List<List<Entity>> refEnt = new List<List<Entity>>();
    List<List<Entity>> InsideEntities = new List<List<Entity>>();
    List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
    clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities1, ref SplitedEntitites);
    clsInit.cVector5.EnitiesFirstInsideThenOutside(SplitedEntitites, ref InsideEntities, ref refEnt);
    int num = 1;
    clsMW.CamEntitiesGroup.Clear();
    if (InsideEntities.Count > 0)
    {
      if (clsMW.CamEntities.Count == 0)
      {
        buVector5.CopyEntities(InsideEntities, ref clsMW.CamEntitiesGroup);
        MWCalcoptions.UseSortedAndSplitedEntities = true;
      }
      camResult Result2 = (camResult) null;
      num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result2);
    }
    clsMW.CamEntitiesGroup.Clear();
    if (refEnt.Count > 0)
    {
      Point3D MinPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      List<Entity> SortedEntities2 = new List<Entity>();
      refEntities = new List<Entity>();
      buVector5.CopyEntities(refEnt, ref refEntities);
      clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
      clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MaxPoint.X, MinPoint.Y), ref refEntities, MWCalcoptions.SortingSettings, ref SortedEntities2, ref Result1);
      clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities2, ref refEnt);
      camTp Cam1 = new camTp();
      if (clsMW.CamEntities.Count == 0)
      {
        buVector5.CopyEntities(refEnt, ref clsMW.CamEntitiesGroup);
        MWCalcoptions.UseSortedAndSplitedEntities = true;
      }
      MWCalcoptions.UseConstantStartPoint = false;
      MWCalcoptions.UseEachCurveStartPoint = true;
      if (InsideEntities.Count > 0)
      {
        camResult Result3 = (camResult) null;
        num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam1, ref Result3);
        clsInit.cVector5.CamAddtoOtherCam(Cam1, ref Cam);
      }
      else
      {
        camResult Result4 = (camResult) null;
        num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result4);
      }
    }
    Pars.mwPar = isPocket ? buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out Pars.buPar) : buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out Pars.buPar);
    if (num < 1)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      if (this.CamOtherEntities != null && this.CamOtherEntities.Count > 0)
      {
        for (int index = 0; index <= this.CamOtherEntities.Count - 1; ++index)
        {
          Entity copiedEnt = (Entity) null;
          buVector5.CopyEntities(this.CamOtherEntities[index], ref copiedEnt);
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
          if (MWCalcoptions.NumberofAxis == 4)
          {
            Cam.PreCodes.Add((object) "G90");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G53");
            Cam.PreCodes.Add((object) "G0 Z0");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M55");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            Cam.AfterCodes.Add((object) "M30");
            Cam.AfterCodes.Add((object) "M2");
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            clsInit.appCommand.CamAdd(Cam);
          }
          else if (MWCalcoptions.NumberofAxis == 3 & !MWCalcoptions.isSpinConstantCalculation)
          {
            Cam.PreCodes.Add((object) "G90");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G53");
            Cam.PreCodes.Add((object) "G0 Z0");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            Cam.AfterCodes.Add((object) "M30");
            Cam.AfterCodes.Add((object) "M2");
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            clsInit.appCommand.CamAdd(Cam);
          }
          else if (MWCalcoptions.NumberofAxis == 3 & MWCalcoptions.isSpinConstantCalculation)
          {
            Cam.PreCodes.Add((object) "G90");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G53");
            Cam.PreCodes.Add((object) "G0 Z0");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M55");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            Cam.AfterCodes.Add((object) "M30");
            Cam.AfterCodes.Add((object) "M2");
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            Cam.CamPoints[0].PreCodes.Add((object) ("M40 K" + clsMW.varbuCamWFContourPars.Strategy.SpinSpeed.ToString()));
            clsInit.appCommand.CamAdd(Cam);
          }
        }
        if (MWCalcoptions.CamWireframeType == CamWireFrameType.Pocket && MWCalcoptions.NumberofAxis == 3)
        {
          Cam.PreCodes.Add((object) "G90");
          Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "G53");
          Cam.PreCodes.Add((object) "G0 Z0");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "M154");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
          Cam.PreCodes.Add((object) "G75");
          for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
          {
            if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
              Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
          }
          Cam.AfterCodes.Add((object) "M30");
          Cam.AfterCodes.Add((object) "M2");
          for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
          {
            if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
              Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
          }
          clsInit.appCommand.CamAdd(Cam);
        }
      }
      clsInit.appCommand.Reset();
      this.SaveLaserFile();
    }
  }

  public void doWireframeContourRouterWoodBottom(
    MWCalculationOptions MWCalcoptions,
    GeoLib mwPars,
    camParameters5 buPars,
    bool isPocket,
    ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    if (!isPocket)
      clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(mwPars, buPars, out clsMW.varbuCamWFContourPars);
    else
      clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(mwPars, buPars, out clsMW.varbuCamWFPocketPars);
    MWCalcoptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
    List<Entity> refEntities1 = new List<Entity>();
    List<Entity> SortedEntities1 = new List<Entity>();
    SelectionOption Option = new SelectionOption();
    SortResult Result1 = new SortResult();
    Option.CircleToArc = true;
    Option.CircleTo4Arc = true;
    Option.SplitArcIfGreatThen180 = true;
    Option.Point = false;
    Option.SplitArcIfGreatThenValue = 160.0;
    clsInit.appCommand.SelectionToEntities(ref refEntities1, Option);
    clsInit.cVector5.EntitiesPlaneCheck(ref refEntities1);
    MWCalcoptions.SortingSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLengthWithSingleTouch;
    clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MWCalcoptions.StartPointX, MWCalcoptions.StartPointY), ref refEntities1, MWCalcoptions.SortingSettings, ref SortedEntities1, ref Result1);
    List<List<Entity>> refEntities2 = new List<List<Entity>>();
    List<List<Entity>> InsideEntities = new List<List<Entity>>();
    List<List<Entity>> calcEntities1 = new List<List<Entity>>();
    List<List<Entity>> calcEntities2 = new List<List<Entity>>();
    List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
    clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities1, ref SplitedEntitites);
    clsInit.cVector5.EnitiesFirstInsideThenOutside(SplitedEntitites, ref InsideEntities, ref refEntities2);
    BreakEntitiesByRefLineEventVar Settings = new BreakEntitiesByRefLineEventVar();
    Settings.PersentageOfBoxSize = clsLaserRouter.varRouterSettings.WoodBottomTrimPersentage;
    Settings.RefDirection = clsLaserRouter.varRouterSettings.WoodBottomRefSide;
    Settings.SortResolution = clsVar.varSelection.SelectionResolution;
    clsInit.cVector5.BreakEntitiesByRefLine(InsideEntities, Settings, ref calcEntities2);
    clsInit.cVector5.BreakEntitiesByRefLine(refEntities2, Settings, ref calcEntities1);
    int num = 1;
    clsMW.CamEntitiesGroup.Clear();
    if (calcEntities2.Count > 0)
    {
      buVector5.CopyEntities(calcEntities2, ref clsMW.CamEntitiesGroup);
      MWCalcoptions.UseSortedAndSplitedEntities = true;
      camResult Result2 = (camResult) null;
      num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result2);
    }
    clsMW.CamEntitiesGroup.Clear();
    if (calcEntities1.Count > 0)
    {
      Point3D MinPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      List<Entity> SortedEntities2 = new List<Entity>();
      List<List<Entity>> entityListList = new List<List<Entity>>();
      refEntities1 = new List<Entity>();
      buVector5.CopyEntities(calcEntities1, ref refEntities1);
      clsInit.cVector5.BoxSizeCalculate(refEntities1, ref MinPoint, ref MidPoint, ref MaxPoint);
      clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MaxPoint.X, MinPoint.Y), ref refEntities1, MWCalcoptions.SortingSettings, ref SortedEntities2, ref Result1);
      clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities2, ref refEntities2);
      camTp Cam1 = new camTp();
      buVector5.CopyEntities(calcEntities1, ref clsMW.CamEntitiesGroup);
      MWCalcoptions.UseSortedAndSplitedEntities = true;
      MWCalcoptions.UseConstantStartPoint = false;
      MWCalcoptions.UseEachCurveStartPoint = true;
      camResult Result3 = (camResult) null;
      num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam1, ref Result3);
      clsInit.cVector5.CamAddtoOtherCam(Cam1, ref Cam);
    }
    mwPars = isPocket ? buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buPars) : buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buPars);
    if (num < 1)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      if (this.CamOtherEntities != null && this.CamOtherEntities.Count > 0)
      {
        for (int index = 0; index <= this.CamOtherEntities.Count - 1; ++index)
        {
          Entity copiedEnt = (Entity) null;
          buVector5.CopyEntities(this.CamOtherEntities[index], ref copiedEnt);
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
          if (MWCalcoptions.NumberofAxis == 4)
          {
            Cam.PreCodes.Add((object) "G90");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G53");
            Cam.PreCodes.Add((object) "G0 Z0");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M55");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            Cam.AfterCodes.Add((object) "M30");
            Cam.AfterCodes.Add((object) "M2");
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            clsInit.appCommand.CamAdd(Cam);
          }
          else if (MWCalcoptions.NumberofAxis == 3 & !MWCalcoptions.isSpinConstantCalculation)
          {
            Cam.PreCodes.Add((object) "G90");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G53");
            Cam.PreCodes.Add((object) "G0 Z0");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            Cam.AfterCodes.Add((object) "M30");
            Cam.AfterCodes.Add((object) "M2");
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            clsInit.appCommand.CamAdd(Cam);
          }
          else if (MWCalcoptions.NumberofAxis == 3 & MWCalcoptions.isSpinConstantCalculation)
          {
            Cam.PreCodes.Add((object) "G90");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G53");
            Cam.PreCodes.Add((object) "G0 Z0");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M55");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            Cam.AfterCodes.Add((object) "M30");
            Cam.AfterCodes.Add((object) "M2");
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            Cam.CamPoints[0].PreCodes.Add((object) ("M40 K" + clsMW.varbuCamWFContourPars.Strategy.SpinSpeed.ToString()));
            clsInit.appCommand.CamAdd(Cam);
          }
        }
        if (MWCalcoptions.CamWireframeType == CamWireFrameType.Pocket && MWCalcoptions.NumberofAxis == 3)
        {
          Cam.PreCodes.Add((object) "G90");
          Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "G53");
          Cam.PreCodes.Add((object) "G0 Z0");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "M154");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
          Cam.PreCodes.Add((object) "G75");
          for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
          {
            if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
              Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
          }
          Cam.AfterCodes.Add((object) "M30");
          Cam.AfterCodes.Add((object) "M2");
          for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
          {
            if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
              Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
          }
          clsInit.appCommand.CamAdd(Cam);
        }
      }
      clsInit.appCommand.Reset();
    }
  }

  public int doDrill(
    MWCalculationOptions MWCalcoptions,
    GeoLib mwPars,
    camParameters5 buPars,
    ToolBase5 Tool,
    ref camTp Cam)
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
    camResult Result = (camResult) null;
    int num1 = clsInit.appMW.doDrill(MWCalcoptions, Tool, ref Cam, ref Result);
    int num2;
    if (Result.Errors.Count > 0)
    {
      F_ErrorList fErrorList = new F_ErrorList();
      fErrorList.Init(Result.Errors);
      int num3 = (int) fErrorList.ShowDialog();
      clsInit.appCommand.Reset();
      num2 = -2;
    }
    else
    {
      buMWCalcs.CopyCamParameter(clsMW.varMWCamDrillPars, clsMW.varbuCamDrillPars, ref clsVar.varCamDrillPars);
      if (num1 < 1)
      {
        clsInit.appCommand.Reset();
        num2 = num1;
      }
      else
      {
        Cam.Mode = MWCalcoptions.Mode;
        Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
        Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
        Cam.CamDrillType = MWCalcoptions.CamDrillType;
        Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
        if (MWCalcoptions.Mode == CamMode.Drill && MWCalcoptions.NumberofAxis == 3)
        {
          buString5.AddToArrayList(ccVars.PostActive.Drill3AXPreCodes, ref Cam.PreCodes);
          for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
          {
            if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
              Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
          }
          buString5.AddToArrayList(ccVars.PostActive.Drill3AXAfterCodes, ref Cam.AfterCodes);
          for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
          {
            if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
              Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
          }
          clsInit.appCommand.CamAdd(Cam);
        }
        clsInit.appCommand.Reset();
        clsFiles.SaveParameter();
        num2 = 1;
      }
    }
    return num2;
  }

  public void doMoveZeroPoint(Point3D refPoint)
  {
    List<int> Added = new List<int>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
      Added.Add(index);
    }
    if (Added.Count > 0)
    {
      clsInit.appCommand.SelectedToSelectionAdd(Added);
      clsInit.appCommand.Move(refPoint, new Point3D());
    }
    clsInit.appCommand.Reset(false);
  }
}
