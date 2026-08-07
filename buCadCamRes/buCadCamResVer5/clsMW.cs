// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.clsMW
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.CamForms;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5;

public class clsMW
{
  public static GeoLib varMWCamMeshRoughPars = (GeoLib) null;
  public static camParameters5 varbuCamMeshRoughPars = (camParameters5) null;
  public static GeoLib varMWCamMeshParalelPars = (GeoLib) null;
  public static camParameters5 varbuCamMeshParallelPars = (camParameters5) null;
  public static GeoLib varMWCamMeshContantZPars = (GeoLib) null;
  public static camParameters5 varbuCamMeshConstantZPars = (camParameters5) null;
  public static GeoLib varMWCamMeshPencilPars = (GeoLib) null;
  public static camParameters5 varbuCamMeshPencilPars = (camParameters5) null;
  public static GeoLib varMWCamMeshProjectionPars = (GeoLib) null;
  public static camParameters5 varbuCamMeshProjectionPars = (camParameters5) null;
  public static GeoLib varMWCamMeshFlatlandPars = (GeoLib) null;
  public static camParameters5 varbuCamMeshFlatlandsPars = (camParameters5) null;
  public static GeoLib varMWCamMeshContantCuspPars = (GeoLib) null;
  public static camParameters5 varbuCamMeshConstantCuspPars = (camParameters5) null;
  public static GeoLib varMWCamMeshRough5AXPars = (GeoLib) null;
  public static camParameters5 varbuCamMeshRough5AXPars = (camParameters5) null;
  public static GeoLib varMWCamMeshParalel5AXPars = (GeoLib) null;
  public static camParameters5 varbuCamMeshParallel5AXPars = (camParameters5) null;
  public static GeoLib varMWCamMeshContantZ5AXPars = (GeoLib) null;
  public static camParameters5 varbuCamMeshConstantZ5AXPars = (camParameters5) null;
  public static GeoLib varMWCamWFPocketPars = (GeoLib) null;
  public static camParameters5 varbuCamWFPocketPars = (camParameters5) null;
  public static GeoLib varMWCamWFContourPars = (GeoLib) null;
  public static camParameters5 varbuCamWFContourPars = (camParameters5) null;
  public static GeoLib varMWCamWFProfile3AxisPars = (GeoLib) null;
  public static camParameters5 varbuCamWFProfile3AxisPars = (camParameters5) null;
  public static GeoLib varMWCamDrillPars = (GeoLib) null;
  public static camParameters5 varbuCamDrillPars = (camParameters5) null;
  public static GeoLib varMWCamWFFacePars = (GeoLib) null;
  public static camParameters5 varbuCamWFFacePars = (camParameters5) null;
  public static GeoLib varMWCamSurfaceParallelPars = (GeoLib) null;
  public static camParameters5 varbuCamSurfaceParallelPars = (camParameters5) null;
  public static GeoLib varMWCamGeodesicPars = (GeoLib) null;
  public static camParameters5 varbuCamGeodesicPars = (camParameters5) null;
  public static GeoLib varMWCamContourPars = (GeoLib) null;
  public static camParameters5 varbuCamContourPars = (camParameters5) null;
  public static List<Entity> CamEntities = new List<Entity>();
  public static List<Entity> Containment2DEntities = new List<Entity>();
  public static List<Entity> StockEntities = new List<Entity>();
  public static List<List<Entity>> CamEntitiesGroup = new List<List<Entity>>();
  public static List<buEntity> CamBuEntities = new List<buEntity>();

  public void Init()
  {
    clsMW.varMWCamMeshRoughPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamMeshRoughPars = new camParameters5();
    clsMW.varMWCamMeshParalelPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamMeshParallelPars = new camParameters5();
    clsMW.varMWCamMeshContantZPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamMeshConstantZPars = new camParameters5();
    clsMW.varMWCamMeshPencilPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamMeshPencilPars = new camParameters5();
    clsMW.varMWCamMeshProjectionPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamMeshProjectionPars = new camParameters5();
    clsMW.varMWCamMeshFlatlandPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamMeshFlatlandsPars = new camParameters5();
    clsMW.varMWCamMeshContantCuspPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamMeshConstantCuspPars = new camParameters5();
    clsMW.varMWCamMeshParalel5AXPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamMeshParallel5AXPars = new camParameters5();
    clsMW.varMWCamMeshContantZ5AXPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamMeshConstantZ5AXPars = new camParameters5();
    clsMW.varMWCamMeshRough5AXPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamMeshRough5AXPars = new camParameters5();
    clsMW.varMWCamWFPocketPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamWFPocketPars = new camParameters5();
    clsMW.varMWCamWFContourPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamWFContourPars = new camParameters5();
    clsMW.varMWCamWFProfile3AxisPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamWFProfile3AxisPars = new camParameters5();
    clsMW.varMWCamDrillPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamDrillPars = new camParameters5();
    clsMW.varMWCamGeodesicPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamGeodesicPars = new camParameters5();
    clsMW.varMWCamSurfaceParallelPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamSurfaceParallelPars = new camParameters5();
    clsMW.varMWCamContourPars = new GeoLib(Unit.Metric);
    clsMW.varbuCamContourPars = new camParameters5();
    clsVar.varCamMeshRoughPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamMeshParallelPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamMeshConstantZPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamMeshPencilPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamMeshProjectionPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamMeshFlatlandsPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamMeshConstantCuspPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamWFPocketPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamWFContourPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamWFContour4XPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamDrillPars = new MWParameters(Unit.Metric, 0);
    clsVar.varCamDrill4XPars = new MWParameters(Unit.Metric, 0);
    clsInit.cMwCalc.GetCalculations += new MWCalculationResultHandler(this.GetCalculationFromMWCore);
    clsInit.cMwCalc.CalculationInProgressMwCalc += new CalculationEventHandler(clsInit.appCommand.CalculationInProgressCmd);
  }

  public void GetCalculationFromMWCore(MWCalculationResult Result, MWCalculationResultEventArg e)
  {
    try
    {
      if (e.CalculationSuccess)
      {
        clsFiles.SaveParameter();
        if (!buSystem.Canceled)
          ;
        clsInit.appCommand.Reset(ReDraw: true);
      }
      else
        clsInit.appCommand.Reset(ReDraw: true);
    }
    catch (Exception ex)
    {
    }
  }

  public int doWireframeContour(
    MWCalculationOptions MWCalcOptions,
    ToolBase5 ToolSelected,
    ref camTp Cam,
    ref camResult Result)
  {
    ToolBase5 Tool = new ToolBase5(ToolSelected);
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    MWCalculationResult camResult = new MWCalculationResult();
    bool flag1 = false;
    WireframeBasedTpCalcParamsPattern CalcType = WireframeBasedTpCalcParamsPattern.Wfb2axisProfile;
    List<List<Entity>> entityListList = new List<List<Entity>>();
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> SortedEntities = new List<Entity>();
    List<buMWCurveEntities> CurveEntities = new List<buMWCurveEntities>();
    List<ModuleWorks.Curve> curveList = new List<ModuleWorks.Curve>();
    buMWCurveEntities buMwCurveEntities = new buMWCurveEntities();
    SortSettings Settings = new SortSettings(MWCalcOptions.SortingSettings);
    SortResult Result1 = new SortResult();
    Cam = new camTp();
    Result = new camResult();
    int num1;
    if (Tool.Purpose == ToolPurpose.Drilling)
    {
      int num2 = (int) MessageBox.Show(AppLanguage.CadCamMessages[57]);
      clsInit.appCommand.Reset();
      num1 = -1;
    }
    else if (MWCalcOptions.CamWireframeType != CamWireFrameType.Contour && Tool.Purpose == ToolPurpose.Saw)
    {
      int num3 = (int) MessageBox.Show(AppLanguage.CadCamMessages[57]);
      clsInit.appCommand.Reset();
      num1 = -1;
    }
    else
    {
      if (MWCalcOptions.UseSortedAndSplitedEntities & clsMW.CamEntitiesGroup.Count > 0)
      {
        flag1 = true;
        buVector5.CopyEntities(clsMW.CamEntitiesGroup, ref entityListList);
      }
      SelectionOption Option = new SelectionOption();
      Option.CircleToArc = true;
      Option.CircleTo4Arc = true;
      Option.SplitArcIfGreatThen180 = true;
      Option.Point = false;
      if (!flag1)
      {
        if (clsMW.CamEntities.Count == 0)
        {
          clsInit.appCommand.SelectionToEntities(ref entityList1, Option);
          clsInit.cVector5.EntitiesPlaneCheck(ref entityList1);
          if (ccVars.entityEdges != null && ccVars.entityEdges.Count > 0)
          {
            entityList1.Clear();
            buVector5.CopyEntities(ccVars.entityEdges[0], ref entityList1);
          }
        }
        else
        {
          for (int index = 0; index <= clsMW.CamEntities.Count - 1; ++index)
          {
            if (clsMW.CamEntities[index].GetType() == typeof (Circle))
            {
              Entity copiedEnt = (Entity) null;
              buVector5.CopyEntities(clsMW.CamEntities[index], ref copiedEnt);
              Entity Arc1 = (Entity) null;
              Entity Arc2 = (Entity) null;
              Entity Arc3 = (Entity) null;
              Entity Arc4 = (Entity) null;
              clsInit.cVector5.CircletoFourArc((Circle) copiedEnt, ref Arc1, ref Arc2, ref Arc3, ref Arc4);
              entityList1.Add(Arc1);
              entityList1.Add(Arc2);
              entityList1.Add(Arc3);
              entityList1.Add(Arc4);
            }
            else
            {
              Entity copiedEnt = (Entity) null;
              buVector5.CopyEntities(clsMW.CamEntities[index], ref copiedEnt);
              entityList1.Add(copiedEnt);
            }
          }
          clsInit.cVector5.EntitiesPlaneCheck(ref entityList1);
        }
        Result.UsedEntities.Clear();
        buEntity.Copy(entityList1, ref Result.UsedEntities);
        if (MWCalcOptions.DevideData.DevideEnable)
        {
          List<Entity> devideEntities = new List<Entity>();
          clsInit.cVector5.EntitiesDevideByLengthAsPolyline(entityList1, MWCalcOptions.DevideData, ref devideEntities);
          entityList1.Clear();
          buVector5.CopyEntities(devideEntities, ref entityList1);
        }
        if (ccVars.SelectionOP.ClickList.Count > 0)
        {
          Settings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
          clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref entityList1, Settings, ref SortedEntities, ref Result1);
        }
        else if (entityList1.Count > 0)
          clsInit.cVector5.SortEntitiesByRefPoint(((ICurve) entityList1[0]).StartPoint, ref entityList1, Settings, ref SortedEntities, ref Result1);
        clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref entityListList);
      }
      if (clsInit.cMwCalc.mwCamDataParameter != null)
        clsInit.cMwCalc.mwCamDataParameter.Dispose();
      clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
      if (MWCalcOptions.CamWireframeType == CamWireFrameType.Contour | MWCalcOptions.CamWireframeType == CamWireFrameType.CenterPath)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamWFContourPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamWFContourPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamWFContourPars);
        CalcType = WireframeBasedTpCalcParamsPattern.Wfb2axisProfile;
      }
      else if (MWCalcOptions.CamWireframeType == CamWireFrameType.Pocket)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamWFPocketPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamWFPocketPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamWFPocketPars);
        CalcType = WireframeBasedTpCalcParamsPattern.Wfb2axisRough;
      }
      else if (MWCalcOptions.CamWireframeType == CamWireFrameType.Profile3Axis)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamWFProfile3AxisPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamWFProfile3AxisPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamWFProfile3AxisPars);
        CalcType = WireframeBasedTpCalcParamsPattern.Wfb3axisProfile;
      }
      else if (MWCalcOptions.CamWireframeType == CamWireFrameType.Face)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamWFFacePars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamWFFacePars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamWFFacePars);
        CalcType = WireframeBasedTpCalcParamsPattern.WfbFace;
      }
      clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.AllowDriveCurvesSelfIntersectionsFlg = MWCalcOptions.AllowIntercetionCurve;
      if (MWCalcOptions.NumberofAxis == 4)
        clsInit.cMwCalc.buCamDataParameter.Strategy.ArcToPoints = true;
      if (MWCalcOptions.ToolDataToCamData)
        this.ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
      clsInit.cVector5.BoxSizeCalculate(entityListList, ref MinPoint, ref MidPoint, ref MaxPoint);
      if (MWCalcOptions.CheckBoxBounding)
      {
        if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
        {
          if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[1], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[0], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
          {
            if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[3], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[2], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[5], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[4], 0);
              Result.Errors.Add(calculationError);
            }
          }
        }
        if (Result.Errors.Count > 0)
        {
          num1 = -1;
          goto label_155;
        }
      }
      if (MWCalcOptions.HeightFromEntities && clsInit.cMwCalc.buCamDataParameter != null)
        clsInit.cMwCalc.buCamDataParameter.Operations.Height = MaxPoint.Z;
      if (MWCalcOptions.WireframeRoughtStepOverParaelelOverride > 0.0)
        clsInit.cMwCalc.mwCamDataParameter.MachParam.MaxStepoverDistance = MWCalcOptions.WireframeRoughtStepOverParaelelOverride;
      if (!MWCalcOptions.DontShowDialogBox)
      {
        if (MWCalcOptions.CamWireframeType == CamWireFrameType.Contour | MWCalcOptions.CamWireframeType == CamWireFrameType.CenterPath)
        {
          if (MWCalcOptions.NumberofAxis == 4)
          {
            if (!MWCalcOptions.isSpinCalculation)
            {
              F_WFContour4AX fWfContour4Ax = new F_WFContour4AX()
              {
                mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
              };
              fWfContour4Ax.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
              buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, fWfContour4Ax.mwCamParameter);
              fWfContour4Ax.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
              fWfContour4Ax.Configration = new MWCalculationOptions(MWCalcOptions);
              fWfContour4Ax.Tool = new ToolBase5(Tool);
              fWfContour4Ax.Init();
              int num4 = (int) fWfContour4Ax.ShowDialog();
              if (fWfContour4Ax.PropertiesForm.Result == DialogResult.OK)
              {
                Tool.CamData.SpindleSpeed = fWfContour4Ax.buCamParameter.Speeds.SpindleSpeed;
                clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(fWfContour4Ax.mwCamParameter.MachParam);
                buMWCalcs.CopyGeoLibProperties(fWfContour4Ax.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
                clsInit.cMwCalc.buCamDataParameter = new camParameters5(fWfContour4Ax.buCamParameter);
              }
              else
              {
                num1 = -1;
                goto label_155;
              }
            }
            else
            {
              F_WFSpin fWfSpin = new F_WFSpin()
              {
                mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
              };
              fWfSpin.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
              buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, fWfSpin.mwCamParameter);
              fWfSpin.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
              fWfSpin.Configration = new MWCalculationOptions(MWCalcOptions);
              fWfSpin.Tool = new ToolBase5(Tool);
              fWfSpin.Init();
              int num5 = (int) fWfSpin.ShowDialog();
              if (fWfSpin.PropertiesForm.Result == DialogResult.OK)
              {
                Tool.CamData.SpindleSpeed = fWfSpin.buCamParameter.Speeds.SpindleSpeed;
                clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(fWfSpin.mwCamParameter.MachParam);
                buMWCalcs.CopyGeoLibProperties(fWfSpin.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
                clsInit.cMwCalc.buCamDataParameter = new camParameters5(fWfSpin.buCamParameter);
                clsInit.cMwCalc.mwCamDataParameter.MachParam.StockRemain = 0.0;
                clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
                clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
                clsInit.cMwCalc.buCamDataParameter.Offsets.ClosedContour = CamClosedContourType.Center;
              }
              else
              {
                num1 = -1;
                goto label_155;
              }
            }
          }
          else
          {
            F_WFContour fWfContour = new F_WFContour()
            {
              mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
            };
            fWfContour.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
            buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, fWfContour.mwCamParameter);
            fWfContour.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
            fWfContour.Text = "Contour Cut";
            fWfContour.Configration = new MWCalculationOptions(MWCalcOptions);
            fWfContour.Tool = new ToolBase5(Tool);
            fWfContour.Init();
            int num6 = (int) fWfContour.ShowDialog();
            if (fWfContour.PropertiesForm.Result == DialogResult.OK)
            {
              Tool.CamData.SpindleSpeed = fWfContour.buCamParameter.Speeds.SpindleSpeed;
              clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
              buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
              clsInit.cMwCalc.buCamDataParameter = new camParameters5(fWfContour.buCamParameter);
              if (MWCalcOptions.isSpinCalculation)
              {
                clsInit.cMwCalc.mwCamDataParameter.MachParam.StockRemain = 0.0;
                clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
                clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
                clsInit.cMwCalc.buCamDataParameter.Offsets.ClosedContour = CamClosedContourType.Center;
              }
            }
            else
            {
              num1 = -1;
              goto label_155;
            }
          }
          if (clsInit.cMwCalc.buCamDataParameter.Operations.Direction == MWCalcOptions.Direction)
            ;
        }
        else if (MWCalcOptions.CamWireframeType == CamWireFrameType.Pocket)
        {
          F_WFRough fWfRough = new F_WFRough()
          {
            mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
          };
          fWfRough.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, fWfRough.mwCamParameter);
          fWfRough.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
          fWfRough.Configration = new MWCalculationOptions(MWCalcOptions);
          fWfRough.Tool = new ToolBase5(Tool);
          fWfRough.Init();
          int num7 = (int) fWfRough.ShowDialog();
          if (fWfRough.PropertiesForm.Result == DialogResult.OK)
          {
            Tool.CamData.SpindleSpeed = fWfRough.buCamParameter.Speeds.SpindleSpeed;
            clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(fWfRough.mwCamParameter.MachParam);
            buMWCalcs.CopyGeoLibProperties(fWfRough.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
            clsInit.cMwCalc.buCamDataParameter = new camParameters5(fWfRough.buCamParameter);
          }
          else
          {
            num1 = -1;
            goto label_155;
          }
        }
        else
        {
          num1 = -1;
          goto label_155;
        }
      }
      this.CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
      bool flag2 = true;
      if (MWCalcOptions.isBuWireframeCalculation)
      {
        if (clsInit.cMwCalc.buCamDataParameter.Operations.isClosed & clsInit.cMwCalc.buCamDataParameter.Offsets.ClosedContour == CamClosedContourType.Center)
          flag2 = false;
        if (!clsInit.cMwCalc.buCamDataParameter.Operations.isClosed & clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide == WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter)
          flag2 = false;
        if (clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtOff)
          flag2 = false;
      }
      else if (MWCalcOptions.isSpinCalculation)
        flag2 = false;
      else if (MWCalcOptions.isSpinConstantCalculation)
        flag2 = false;
      bool flag3 = false;
      bool flag4;
      if (flag2)
      {
        for (int index1 = 0; index1 <= entityListList.Count - 1; ++index1)
        {
          List<Entity> entityList2 = new List<Entity>();
          bool flag5 = clsInit.cVector5.isEntitiesClosed(entityListList[index1]);
          ClockDirectionType clockDirectionType = clsInit.cVector5.EntitiesClockDirection(entityListList[index1]);
          if (MWCalcOptions.CheckIsCLosedEntities)
            clsInit.cMwCalc.buCamDataParameter.Operations.isClosed = flag5;
          if (flag5)
          {
            if (clockDirectionType != clsInit.cMwCalc.buCamDataParameter.Operations.Direction)
              clsInit.cVector5.ChangeEntitiesDirection(entityListList[index1], ref entityList2);
            else
              buVector5.CopyEntities(entityListList[index1], ref entityList2);
          }
          else
            buVector5.CopyEntities(entityListList[index1], ref entityList2);
          for (int index2 = 0; index2 <= entityList2.Count - 1; ++index2)
          {
            entitySortDirection sortDirection = clsInit.cVector5.GetSortDirection(entityList2[index2]);
            if (index2 == 0)
            {
              if (sortDirection == entitySortDirection.Normal)
                buMwCurveEntities.pntStart = new Point3d<double>(((ICurve) entityList2[index2]).StartPoint.X, ((ICurve) entityList2[index2]).StartPoint.Y, ((ICurve) entityList2[index2]).StartPoint.Z);
              if (sortDirection == entitySortDirection.Reverse)
                buMwCurveEntities.pntStart = new Point3d<double>(((ICurve) entityList2[index2]).EndPoint.X, ((ICurve) entityList2[index2]).EndPoint.Y, ((ICurve) entityList2[index2]).EndPoint.Z);
              if (CurveEntities.Count < ccVars.SelectionOP.ClickList.Count - 1 & ccVars.SelectionOP.ClickList.Count > 0 & clsMW.varbuCamWFContourPars.Strategy.StartFromAnyPoint)
                buMwCurveEntities.pntStart = new Point3d<double>(ccVars.SelectionOP.ClickList[CurveEntities.Count].X, ccVars.SelectionOP.ClickList[CurveEntities.Count].Y, ccVars.SelectionOP.ClickList[CurveEntities.Count].Z);
            }
            ModuleWorks.Curve mwEntity = (ModuleWorks.Curve) null;
            buMWCalcs.ConvertWireEntity(entityList2[index2], ref mwEntity);
            buMwCurveEntities.CurveList.Add(mwEntity);
          }
          if (buMwCurveEntities.CurveList.Count > 0)
          {
            CurveEntities.Add(buMwCurveEntities);
            buMwCurveEntities = new buMWCurveEntities();
          }
        }
        if (CurveEntities.Count == 0)
        {
          buString.MessageBoxError(AppLanguage.CadCamMessages[80 /*0x50*/]);
          clsInit.appCommand.Reset();
          clsItem.FrmProgress.Visible = false;
          num1 = -1;
          goto label_155;
        }
        flag3 = false;
        if (CurveEntities.Count > 1)
          flag3 = true;
        flag4 = clsInit.cMwCalc.CalculateWireframe(Tool, CurveEntities, CalcType, MWCalcOptions, ref camResult);
      }
      else
      {
        camParameters5 BUPar = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
        clsInit.appCommand.CamAvailableIDGet(ref BUPar.Runtime.CamID);
        buMWCalcs.ConvertFromMwCamParToBuCamPar(clsInit.cMwCalc.mwCamDataParameter, ref BUPar);
        flag4 = !MWCalcOptions.isSpinCalculation ? (!MWCalcOptions.isSpinCalculation ? (entityListList.Count <= 0 ? (MWCalcOptions.NumberofAxis != 3 ? clsInit.cCam5.camContourCenter(SortedEntities, true, Tool, BUPar, ref Cam) : clsInit.cCam5.camContourCenter(SortedEntities, false, Tool, BUPar, ref Cam)) : (MWCalcOptions.NumberofAxis != 3 ? clsInit.cCam5.camContourCenter(entityListList, true, Tool, BUPar, ref Cam) : clsInit.cCam5.camContourCenter(entityListList, false, Tool, BUPar, ref Cam))) : clsInit.cCam5.camContourCenter(SortedEntities, false, Tool, BUPar, ref Cam)) : clsInit.cCam5.camSpin(entityListList, true, Tool, BUPar, ref Cam);
        camResult.buCamParamters = new camParameters5(BUPar);
        camResult.geoLib = new GeoLib(Unit.Metric);
        camResult.geoLib.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
        camResult.Tool = new ToolBase5(Tool);
      }
      if (flag4)
      {
        ccVars.UndoDont = true;
        clsInit.appCommand.undoBuffer();
        int AvailableCamID = 0;
        clsInit.appCommand.CamAvailableIDGet(ref AvailableCamID);
        if (flag2)
        {
          if (MWCalcOptions.is5AxisWireframe)
          {
            clsInit.appMW.IterateThroughEntireStructure5X(camResult.ToolPathCalc, AvailableCamID, camResult.buCamParamters, camResult.geoLib, ref Cam);
            clsMW.varMWCamWFContourPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
            buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamWFContourPars);
            clsMW.varbuCamWFContourPars = new camParameters5(camResult.buCamParamters);
          }
          else if (MWCalcOptions.CamWireframeType == CamWireFrameType.Contour | MWCalcOptions.CamWireframeType == CamWireFrameType.CenterPath)
          {
            if (MWCalcOptions.NumberofAxis == 3)
              this.IterateThroughEntireStructure3X(camResult.ToolPathCalc, AvailableCamID, camResult.buCamParamters, camResult.geoLib, ref Cam, MWCalcOptions.isAllG1);
            if (MWCalcOptions.NumberofAxis == 4)
              this.IterateThroughEntireStructure4X(camResult.ToolPathCalc, AvailableCamID, camResult.buCamParamters, camResult.geoLib, ref Cam);
            clsMW.varMWCamWFContourPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
            buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamWFContourPars);
            clsMW.varbuCamWFContourPars = new camParameters5(camResult.buCamParamters);
          }
          else if (MWCalcOptions.CamWireframeType == CamWireFrameType.Pocket)
          {
            this.IterateThroughEntireStructure3X(camResult.ToolPathCalc, AvailableCamID, camResult.buCamParamters, camResult.geoLib, ref Cam, MWCalcOptions.isAllG1);
            clsMW.varMWCamWFPocketPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
            buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamWFPocketPars);
            clsMW.varbuCamWFPocketPars = new camParameters5(camResult.buCamParamters);
          }
          else if (MWCalcOptions.CamWireframeType == CamWireFrameType.Profile3Axis)
          {
            this.IterateThroughEntireStructure3X(camResult.ToolPathCalc, AvailableCamID, camResult.buCamParamters, camResult.geoLib, ref Cam, MWCalcOptions.isAllG1);
            clsMW.varMWCamWFProfile3AxisPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
            buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamWFProfile3AxisPars);
            clsMW.varbuCamWFProfile3AxisPars = new camParameters5(camResult.buCamParamters);
          }
        }
        else if (MWCalcOptions.CamWireframeType == CamWireFrameType.Contour)
        {
          clsMW.varMWCamWFContourPars.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, clsMW.varMWCamWFContourPars);
          clsMW.varbuCamWFContourPars = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
        }
        Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
        Cam.Parameter = new camParameters5(camResult.buCamParamters);
        Cam.mwParameter = (object) new MachiningParams(camResult.geoLib.MachParam);
        if (MWCalcOptions.CamWireframeType == CamWireFrameType.Contour | MWCalcOptions.CamWireframeType == CamWireFrameType.CenterPath)
        {
          if (MWCalcOptions.NumberofAxis == 3)
          {
            Cam.TypeCam = !MWCalcOptions.isClosed ? (clsMW.varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft ? (clsMW.varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsRight ? CamType.ContourOpenCenter : CamType.ContourOpenRight) : CamType.ContourOpenLeft) : (clsMW.varbuCamWFContourPars.Operations.Direction != ClockDirectionType.CCW ? (clsMW.varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft ? (clsMW.varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsRight ? CamType.ContourClosedCenter : CamType.ContourClosedInside) : CamType.ContourClosedOutside) : (clsMW.varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft ? (clsMW.varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsRight ? CamType.ContourClosedCenter : CamType.ContourClosedOutside) : CamType.ContourClosedInside));
            if (flag3)
              Cam.TypeCam = CamType.ContourMulti;
          }
          else if (MWCalcOptions.NumberofAxis == 4)
            Cam.TypeCam = CamType.Contour4X;
        }
        else if (MWCalcOptions.CamWireframeType == CamWireFrameType.Pocket)
          Cam.TypeCam = CamType.PocketCircular;
        Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
        Cam.Tool = new ToolBase5(camResult.Tool);
        buVector5.CopyEntities(SortedEntities, ref Cam.sortedEntities);
        buVector5.CopyEntities(entityList1, ref Cam.RefEntities);
        if (Cam.Tool.Geometry.GeometryType == buClass.ToolType.Saw)
          Cam.SimilationToolOffset.Z = Cam.Tool.Geometry.Diameter / 2.0;
        Cam.CamID = AvailableCamID;
        this.SaveMWParameter();
        if (MWCalcOptions.AddToCamListInMWCalculation)
          clsInit.appCommand.CamAdd(Cam);
        if (!MWCalcOptions.DontApplyReset)
          clsInit.appCommand.Reset();
        if (MWCalcOptions.ShowProgressForm)
          clsItem.FrmProgress.Visible = false;
        num1 = 1;
      }
      else
        num1 = -1;
    }
label_155:
    return num1;
  }

  public int doTriangularMesh3D(
    MWCalculationOptions MWCalcOptions,
    ToolBase5 ToolSelected,
    ref camTp Cam,
    ref camResult Result)
  {
    try
    {
      ToolBase5 Tool = new ToolBase5(ToolSelected);
      Point3D MinPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      MWCalculationResult camResult = new MWCalculationResult();
      TriangleMeshBasedTpCalcParamsPattern CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
      List<Entity> entityList1 = new List<Entity>();
      List<Entity> refEnt = new List<Entity>();
      List<Entity> entityList2 = new List<Entity>();
      List<buMWCurveEntities> Curve2dContainment = new List<buMWCurveEntities>();
      buMWCurveEntities buMwCurveEntities = new buMWCurveEntities();
      SelectionOption Option1 = new SelectionOption(false, true, false, false, false, false);
      bool flag1 = true;
      Result = new camResult();
      if (Tool.Purpose == ToolPurpose.Drilling | Tool.Purpose == ToolPurpose.DiamondCut)
        flag1 = false;
      if (!flag1)
      {
        int num = (int) MessageBox.Show(AppLanguage.CadCamMessages[57]);
        clsInit.appCommand.Reset();
        return -1;
      }
      if (clsMW.CamEntities.Count == 0)
      {
        clsInit.appCommand.SelectionToEntities(ref entityList1, Option1);
        SelectionOption Option2 = new SelectionOption(true, false, false, false, false, false);
        clsInit.appCommand.SelectionToEntities(ref refEnt, Option2);
      }
      else
      {
        buVector5.CopyEntities(clsMW.CamEntities, ref entityList1);
        clsInit.cVector5.EntitiesPlaneCheck(ref entityList1);
        buVector5.CopyEntities(clsMW.Containment2DEntities, ref refEnt);
      }
      if (clsMW.Containment2DEntities.Count > 0)
        buVector5.CopyEntities(clsMW.Containment2DEntities, ref refEnt);
      if (clsInit.cMwCalc.mwCamDataParameter != null)
        clsInit.cMwCalc.mwCamDataParameter.Dispose();
      clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
      if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.Rough | MWCalcOptions.CamTriMeshType == CamTriangularMeshType.Rough3Plus2)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamMeshRoughPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamMeshRoughPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamMeshRoughPars);
        CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
      }
      else if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamMeshParalelPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamMeshParalelPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamMeshParallelPars);
        CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts;
      }
      else if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamMeshContantZPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamMeshContantZPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamMeshConstantZPars);
        CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ;
      }
      else if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ConstantCusp)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamMeshContantCuspPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamMeshContantCuspPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamMeshConstantCuspPars);
        CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantCusp;
      }
      else if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.Flatlands)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamMeshFlatlandPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamMeshFlatlandPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamMeshFlatlandsPars);
        CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbFlatlands;
      }
      else if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.Pencil)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamMeshPencilPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamMeshPencilPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamMeshPencilPars);
        CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil;
      }
      else if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ProjectionAlong | MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ProjectionAround)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamMeshProjectionPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamMeshProjectionPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamMeshProjectionPars);
        CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbProjection;
      }
      this.ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
      clsInit.cVector5.BoxSizeCalculate(entityList1, ref MinPoint, ref MidPoint, ref MaxPoint);
      clsInit.cMwCalc.buCamDataParameter.Operations.Height = MaxPoint.Z;
      if (MWCalcOptions.CheckBoxBounding)
      {
        if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
        {
          if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[1], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[0], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
          {
            if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[3], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[2], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[5], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[4], 0);
              Result.Errors.Add(calculationError);
            }
          }
        }
        if (Result.Errors.Count > 0)
          return -1;
      }
      if (!MWCalcOptions.DontShowbuDialogBox)
      {
        if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.Rough)
        {
          F_TriMeshRough fTriMeshRough = new F_TriMeshRough()
          {
            Configration = new MWCalculationOptions(MWCalcOptions),
            mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
          };
          fTriMeshRough.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, fTriMeshRough.mwCamParameter);
          fTriMeshRough.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
          fTriMeshRough.Init();
          int num = (int) fTriMeshRough.ShowDialog();
          if (fTriMeshRough.PropertiesForm.Result != DialogResult.OK)
            return -1;
          clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(fTriMeshRough.mwCamParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(fTriMeshRough.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
          clsInit.cMwCalc.buCamDataParameter = new camParameters5(fTriMeshRough.buCamParameter);
        }
        else if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
        {
          F_TriMeshParallelCut triMeshParallelCut = new F_TriMeshParallelCut()
          {
            Configration = new MWCalculationOptions(MWCalcOptions),
            mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
          };
          triMeshParallelCut.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, triMeshParallelCut.mwCamParameter);
          triMeshParallelCut.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
          triMeshParallelCut.Init();
          int num = (int) triMeshParallelCut.ShowDialog();
          if (triMeshParallelCut.PropertiesForm.Result != DialogResult.OK)
            return -1;
          clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(triMeshParallelCut.mwCamParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(triMeshParallelCut.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
          clsInit.cMwCalc.buCamDataParameter = new camParameters5(triMeshParallelCut.buCamParameter);
        }
        else
        {
          if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.ConstantZ)
            return -1;
          F_TriMeshConstantZ triMeshConstantZ = new F_TriMeshConstantZ()
          {
            Configration = new MWCalculationOptions(MWCalcOptions),
            mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
          };
          triMeshConstantZ.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, triMeshConstantZ.mwCamParameter);
          triMeshConstantZ.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
          triMeshConstantZ.Init();
          int num = (int) triMeshConstantZ.ShowDialog();
          if (triMeshConstantZ.PropertiesForm.Result != DialogResult.OK)
            return -1;
          clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(triMeshConstantZ.mwCamParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(triMeshConstantZ.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
          clsInit.cMwCalc.buCamDataParameter = new camParameters5(triMeshConstantZ.buCamParameter);
        }
      }
      this.CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
      List<Meshd> MeshEntities = new List<Meshd>();
      clsInit.cMwCalc.Stock = (List<Meshd>) null;
      List<Point3D> pointList = new List<Point3D>();
      for (int index = 0; index <= entityList1.Count - 1; ++index)
      {
        if (entityList1[index] is Mesh)
        {
          if (clsInit.cMwCalc.buCamDataParameter.Options.StockHeight > 0.0)
          {
            if (entityList1[index].BoxMax == (Point3D) null)
            {
              entityList1[index].Regen(new RegenParams(0.01));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMax));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMin));
            }
            else
            {
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMax));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMin));
            }
          }
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh((Mesh) entityList1[index]);
          if (mwMesh != null)
            MeshEntities.Add(mwMesh);
        }
        else if (entityList1[index] is devDept.Eyeshot.Entities.Surface)
        {
          Mesh mesh = ((devDept.Eyeshot.Entities.Surface) entityList1[index]).ConvertToMesh();
          if (mesh.BoxMax == (Point3D) null)
            mesh.Regen(new RegenParams(0.01));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMax));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMin));
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh(mesh);
          if (mwMesh != null)
            MeshEntities.Add(mwMesh);
        }
        else if (entityList1[index] is Brep)
        {
          Mesh mesh = ((Brep) entityList1[index]).ConvertToMesh(0.01);
          mesh.Regen(0.01);
          if (mesh.BoxMax == (Point3D) null)
            mesh.Regen(new RegenParams(0.01));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMax));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMin));
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh(mesh);
          if (mwMesh != null)
            MeshEntities.Add(mwMesh);
        }
      }
      if (MeshEntities.Count == 0)
      {
        buString.MessageBoxError(AppLanguage.CadCamMessages[79]);
        clsInit.appCommand.Reset();
        clsItem.FrmProgress.Visible = false;
        return -1;
      }
      if (pointList.Count > 0)
      {
        Point3D min = new Point3D();
        Point3D max = new Point3D();
        Utility.BoundingBox((IList<Point3D>) pointList, out min, out max);
        Mesh box = Mesh.CreateBox(max.X - min.X, max.Y - min.Y, clsInit.cMwCalc.buCamDataParameter.Options.StockHeight);
        box.Translate(min.X, min.Y, min.Z);
        if (box != null)
        {
          if (clsInit.cMwCalc.Stock == null)
            clsInit.cMwCalc.Stock = new List<Meshd>();
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh(box);
          clsInit.cMwCalc.Stock.Add(mwMesh);
        }
      }
      if (clsMW.StockEntities.Count > 0)
      {
        if (clsInit.cMwCalc.Stock == null)
          clsInit.cMwCalc.Stock = new List<Meshd>();
        clsInit.cMwCalc.Stock.Clear();
        for (int index = 0; index <= clsMW.StockEntities.Count - 1; ++index)
        {
          if (clsMW.StockEntities[index] is Mesh)
          {
            Meshd mwMesh = buMWCalcs.ConvertToMWMesh((Mesh) clsMW.StockEntities[index]);
            clsInit.cMwCalc.Stock.Add(mwMesh);
          }
        }
      }
      SortSettings sortSettings = new SortSettings();
      SortResult Result1 = new SortResult();
      List<Entity> RefEntities = new List<Entity>();
      if (refEnt.Count > 0)
      {
        if (MWCalcOptions.isBuSort)
        {
          if (ccVars.SelectionOP.ClickList.Count > 0)
          {
            sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
            clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref refEnt, MWCalcOptions.SortingSettings, ref RefEntities, ref Result1);
          }
          else if (MWCalcOptions.UseConstantStartPoint)
            clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MWCalcOptions.StartPointX, MWCalcOptions.StartPointY), ref refEnt, MWCalcOptions.SortingSettings, ref RefEntities, ref Result1);
          else
            clsInit.cVector5.SortEntitiesByRefPoint(((ICurve) refEnt[0]).StartPoint, ref refEnt, MWCalcOptions.SortingSettings, ref RefEntities, ref Result1);
        }
        else
          buVector5.CopyEntities(refEnt, ref RefEntities);
      }
      List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
      List<List<Entity>> entityListList = new List<List<Entity>>();
      clsInit.cVector5.EntitiesSplitByUpperLine(RefEntities, ref SplitedEntitites);
      for (int index1 = 0; index1 <= SplitedEntitites.Count - 1; ++index1)
      {
        List<Entity> entityList3 = new List<Entity>();
        bool flag2 = clsInit.cVector5.isEntitiesClosed(SplitedEntitites[index1]);
        int num = (int) clsInit.cVector5.EntitiesClockDirection(SplitedEntitites[index1]);
        if (flag2)
        {
          List<Point3D> Points = new List<Point3D>();
          clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[index1], clsVar.varEntities.RegenDeviation, ref Points);
          if (Points.Count > 1)
          {
            LinearPath linearPath = new LinearPath((ICollection<Point3D>) Points);
            entityList3.Add((Entity) linearPath);
          }
          for (int index2 = 0; index2 <= entityList3.Count - 1; ++index2)
          {
            entitySortDirection sortDirection = clsInit.cVector5.GetSortDirection(entityList3[index2]);
            if (sortDirection == entitySortDirection.Normal)
              buMwCurveEntities.pntStart = new Point3d<double>(((ICurve) entityList3[index2]).StartPoint.X, ((ICurve) entityList3[index2]).StartPoint.Y, ((ICurve) entityList3[index2]).StartPoint.Z);
            if (sortDirection == entitySortDirection.Reverse)
              buMwCurveEntities.pntStart = new Point3d<double>(((ICurve) entityList3[index2]).EndPoint.X, ((ICurve) entityList3[index2]).EndPoint.Y, ((ICurve) entityList3[index2]).EndPoint.Z);
            if (Curve2dContainment.Count < ccVars.SelectionOP.ClickList.Count - 1 & ccVars.SelectionOP.ClickList.Count > 0)
              buMwCurveEntities.pntStart = new Point3d<double>(ccVars.SelectionOP.ClickList[Curve2dContainment.Count].X, ccVars.SelectionOP.ClickList[Curve2dContainment.Count].Y, ccVars.SelectionOP.ClickList[Curve2dContainment.Count].Z);
            ModuleWorks.Curve mwEntity = (ModuleWorks.Curve) null;
            buMWCalcs.ConvertWireEntity(entityList3[index2], ref mwEntity);
            buMwCurveEntities.CurveList.Add(mwEntity);
          }
        }
        if (buMwCurveEntities.CurveList.Count > 0)
        {
          Curve2dContainment.Add(buMwCurveEntities);
          buMwCurveEntities = new buMWCurveEntities();
        }
      }
      if (Curve2dContainment.Count == 0)
        clsInit.cMwCalc.mwCamDataParameter.MachParam.Containment2dParams.IsUsedFlg = false;
      if (!clsInit.cMwCalc.CalculateTriangleMesh(Tool, MeshEntities, Curve2dContainment, CalcType, MWCalcOptions, ref camResult))
        return -1;
      ccVars.UndoDont = true;
      Cam = new camTp();
      int AvailableCamID = 0;
      clsInit.appCommand.CamAvailableIDGet(ref AvailableCamID);
      CamType camType = CamType.None;
      if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.Rough)
      {
        clsMW.varMWCamMeshRoughPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
        buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamMeshRoughPars);
        buMWCalcs.ConvertFromMwCamParToBuCamParTriangleMesh(camResult.geoLib, ref clsMW.varbuCamMeshRoughPars);
        camType = CamType.Rough;
      }
      else if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
      {
        clsMW.varMWCamMeshParalelPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
        buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamMeshParalelPars);
        buMWCalcs.ConvertFromMwCamParToBuCamParTriangleMesh(camResult.geoLib, ref clsMW.varbuCamMeshParallelPars);
        camType = CamType.ParallelCut;
      }
      else if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
      {
        clsMW.varMWCamMeshContantZPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
        buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamMeshContantZPars);
        buMWCalcs.ConvertFromMwCamParToBuCamParTriangleMesh(camResult.geoLib, ref clsMW.varbuCamMeshConstantZPars);
        camType = CamType.ConstantZ;
      }
      if (MWCalcOptions.NumberofAxis == 3)
        this.IterateThroughEntireStructure3X(camResult.ToolPathCalc, AvailableCamID, camResult.buCamParamters, camResult.geoLib, ref Cam);
      else if (MWCalcOptions.NumberofAxis == 4)
        this.IterateThroughEntireStructure4XVectorX(camResult.ToolPathCalc, AvailableCamID, camResult.buCamParamters, camResult.geoLib, ref Cam);
      else
        this.IterateThroughEntireStructure5X(camResult.ToolPathCalc, AvailableCamID, camResult.buCamParamters, camResult.geoLib, ref Cam);
      Cam.TypeCam = camType;
      Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
      Cam.Tool = new ToolBase5(camResult.Tool);
      Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
      Cam.Parameter = new camParameters5(camResult.buCamParamters);
      Cam.mwParameter = (object) new MachiningParams(camResult.geoLib.MachParam);
      Cam.CamID = AvailableCamID;
      buVector5.CopyEntities(entityList1, ref Cam.RefEntities);
      if (MWCalcOptions.SaveDefaultMWParameter)
        this.SaveMWParameter();
      if (MWCalcOptions.AddToCamListInMWCalculation)
        clsInit.appCommand.CamAdd(Cam);
      if (!MWCalcOptions.DontApplyReset)
        clsInit.appCommand.Reset();
      clsItem.FrmProgress.Visible = false;
      return 1;
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public int doTriangularMesh3D5Axis(
    MWCalculationOptions MWCalcOptions,
    ToolBase5 ToolSelected,
    ref camTp Cam,
    ref camResult Result)
  {
    ToolBase5 Tool = new ToolBase5(ToolSelected);
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    MWCalculationResult camResult = new MWCalculationResult();
    TriangleMeshBasedTpCalcParamsPattern CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> refEnt = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    List<buMWCurveEntities> Curve2dContainment = new List<buMWCurveEntities>();
    buMWCurveEntities buMwCurveEntities = new buMWCurveEntities();
    SelectionOption Option1 = new SelectionOption(false, true, false, false, false, false);
    bool flag1 = true;
    Result = new camResult();
    if (Tool.Purpose == ToolPurpose.Drilling | Tool.Purpose == ToolPurpose.DiamondCut)
      flag1 = false;
    int num1;
    if (!flag1)
    {
      int num2 = (int) MessageBox.Show(AppLanguage.CadCamMessages[57]);
      clsInit.appCommand.Reset();
      num1 = -1;
    }
    else
    {
      if (clsMW.CamEntities.Count == 0)
      {
        clsInit.appCommand.SelectionToEntities(ref entityList1, Option1);
        SelectionOption Option2 = new SelectionOption(true, false, false, false, false, false);
        clsInit.appCommand.SelectionToEntities(ref refEnt, Option2);
      }
      else
      {
        buVector5.CopyEntities(clsMW.CamEntities, ref entityList1);
        clsInit.cVector5.EntitiesPlaneCheck(ref entityList1);
      }
      if (clsMW.Containment2DEntities.Count > 0)
        buVector5.CopyEntities(clsMW.Containment2DEntities, ref refEnt);
      if (clsInit.cMwCalc.mwCamDataParameter != null)
        clsInit.cMwCalc.mwCamDataParameter.Dispose();
      clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
      if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.Rough)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamMeshRough5AXPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamMeshRough5AXPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamMeshRough5AXPars);
        CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
      }
      else if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ParallelCuts)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamMeshParalel5AXPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamMeshParalel5AXPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamMeshParallel5AXPars);
        clsInit.cMwCalc.mwCamDataParameter.MachParam.ToolAxisControlParams.LimitsFlg = true;
        CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts;
      }
      else if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ConstantZ)
      {
        buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamMeshContantZPars, clsInit.cMwCalc.mwCamDataParameter);
        clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamMeshContantZ5AXPars.MachParam);
        clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamMeshConstantZ5AXPars);
        CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ;
      }
      this.ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
      clsInit.cVector5.BoxSizeCalculate(entityList1, ref MinPoint, ref MidPoint, ref MaxPoint);
      clsInit.cMwCalc.buCamDataParameter.Operations.Height = MaxPoint.Z;
      if (MWCalcOptions.CheckBoxBounding)
      {
        if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
        {
          if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[1], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[0], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
          {
            if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[3], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[2], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[5], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[4], 0);
              Result.Errors.Add(calculationError);
            }
          }
        }
        if (Result.Errors.Count > 0)
        {
          num1 = -1;
          goto label_117;
        }
      }
      if (!MWCalcOptions.DontShowbuDialogBox)
      {
        if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.Rough)
        {
          F_TriMeshRough fTriMeshRough = new F_TriMeshRough()
          {
            Configration = new MWCalculationOptions(MWCalcOptions),
            mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
          };
          fTriMeshRough.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, fTriMeshRough.mwCamParameter);
          fTriMeshRough.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
          fTriMeshRough.Init();
          int num3 = (int) fTriMeshRough.ShowDialog();
          if (fTriMeshRough.PropertiesForm.Result == DialogResult.OK)
          {
            clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(fTriMeshRough.mwCamParameter.MachParam);
            buMWCalcs.CopyGeoLibProperties(fTriMeshRough.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
            clsInit.cMwCalc.buCamDataParameter = new camParameters5(fTriMeshRough.buCamParameter);
          }
          else
          {
            num1 = -1;
            goto label_117;
          }
        }
        else if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ParallelCuts)
        {
          F_TriMeshParallelCut triMeshParallelCut = new F_TriMeshParallelCut()
          {
            Configration = new MWCalculationOptions(MWCalcOptions),
            mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
          };
          triMeshParallelCut.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, triMeshParallelCut.mwCamParameter);
          triMeshParallelCut.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
          triMeshParallelCut.Init();
          int num4 = (int) triMeshParallelCut.ShowDialog();
          if (triMeshParallelCut.PropertiesForm.Result == DialogResult.OK)
          {
            clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(triMeshParallelCut.mwCamParameter.MachParam);
            buMWCalcs.CopyGeoLibProperties(triMeshParallelCut.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
            clsInit.cMwCalc.buCamDataParameter = new camParameters5(triMeshParallelCut.buCamParameter);
          }
          else
          {
            num1 = -1;
            goto label_117;
          }
        }
        else if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ConstantZ)
        {
          F_TriMeshConstantZ triMeshConstantZ = new F_TriMeshConstantZ()
          {
            Configration = new MWCalculationOptions(MWCalcOptions),
            mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
          };
          triMeshConstantZ.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, triMeshConstantZ.mwCamParameter);
          triMeshConstantZ.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
          triMeshConstantZ.Init();
          int num5 = (int) triMeshConstantZ.ShowDialog();
          if (triMeshConstantZ.PropertiesForm.Result == DialogResult.OK)
          {
            clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(triMeshConstantZ.mwCamParameter.MachParam);
            buMWCalcs.CopyGeoLibProperties(triMeshConstantZ.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
            clsInit.cMwCalc.buCamDataParameter = new camParameters5(triMeshConstantZ.buCamParameter);
          }
          else
          {
            num1 = -1;
            goto label_117;
          }
        }
        else
        {
          num1 = -1;
          goto label_117;
        }
      }
      this.CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
      List<Meshd> MeshEntities = new List<Meshd>();
      clsInit.cMwCalc.Stock = (List<Meshd>) null;
      List<Point3D> pointList = new List<Point3D>();
      for (int index = 0; index <= entityList1.Count - 1; ++index)
      {
        if (entityList1[index] is Mesh)
        {
          if (clsInit.cMwCalc.buCamDataParameter.Options.StockHeight > 0.0)
          {
            if (entityList1[index].BoxMax == (Point3D) null)
            {
              entityList1[index].Regen(new RegenParams(0.01));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMax));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMin));
            }
            else
            {
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMax));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMin));
            }
          }
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh((Mesh) entityList1[index]);
          if (mwMesh != null)
            MeshEntities.Add(mwMesh);
        }
        else if (entityList1[index] is devDept.Eyeshot.Entities.Surface)
        {
          Mesh mesh = ((devDept.Eyeshot.Entities.Surface) entityList1[index]).ConvertToMesh();
          if (mesh.BoxMax == (Point3D) null)
            mesh.Regen(new RegenParams(0.01));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMax));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMin));
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh(mesh);
          if (mwMesh != null)
            MeshEntities.Add(mwMesh);
        }
        else if (entityList1[index] is Brep)
        {
          Mesh mesh = ((Brep) entityList1[index]).ConvertToMesh(0.01);
          mesh.Regen(0.01);
          if (mesh.BoxMax == (Point3D) null)
            mesh.Regen(new RegenParams(0.01));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMax));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMin));
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh(mesh);
          if (mwMesh != null)
            MeshEntities.Add(mwMesh);
        }
      }
      if (MeshEntities.Count == 0)
      {
        buString.MessageBoxError(AppLanguage.CadCamMessages[79]);
        clsInit.appCommand.Reset();
        clsItem.FrmProgress.Visible = false;
        num1 = -1;
      }
      else
      {
        if (pointList.Count > 0)
        {
          Point3D min = new Point3D();
          Point3D max = new Point3D();
          Utility.BoundingBox((IList<Point3D>) pointList, out min, out max);
          Mesh box = Mesh.CreateBox(max.X - min.X, max.Y - min.Y, clsInit.cMwCalc.buCamDataParameter.Options.StockHeight);
          box.Translate(min.X, min.Y, min.Z);
          if (box != null)
          {
            if (clsInit.cMwCalc.Stock == null)
              clsInit.cMwCalc.Stock = new List<Meshd>();
            Meshd mwMesh = buMWCalcs.ConvertToMWMesh(box);
            clsInit.cMwCalc.Stock.Add(mwMesh);
          }
        }
        SortSettings sortSettings = new SortSettings();
        SortResult Result1 = new SortResult();
        List<Entity> RefEntities = new List<Entity>();
        if (refEnt.Count > 0)
        {
          if (MWCalcOptions.isBuSort)
          {
            if (ccVars.SelectionOP.ClickList.Count > 0)
            {
              sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
              clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref refEnt, MWCalcOptions.SortingSettings, ref RefEntities, ref Result1);
            }
            else if (MWCalcOptions.UseConstantStartPoint)
              clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MWCalcOptions.StartPointX, MWCalcOptions.StartPointY), ref refEnt, MWCalcOptions.SortingSettings, ref RefEntities, ref Result1);
            else
              clsInit.cVector5.SortEntitiesByRefPoint(((ICurve) refEnt[0]).StartPoint, ref refEnt, MWCalcOptions.SortingSettings, ref RefEntities, ref Result1);
          }
          else
            buVector5.CopyEntities(refEnt, ref RefEntities);
        }
        List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
        List<List<Entity>> entityListList = new List<List<Entity>>();
        clsInit.cVector5.EntitiesSplitByUpperLine(RefEntities, ref SplitedEntitites);
        for (int index1 = 0; index1 <= SplitedEntitites.Count - 1; ++index1)
        {
          List<Entity> entityList3 = new List<Entity>();
          bool flag2 = clsInit.cVector5.isEntitiesClosed(SplitedEntitites[index1]);
          int num6 = (int) clsInit.cVector5.EntitiesClockDirection(SplitedEntitites[index1]);
          if (flag2)
          {
            List<Point3D> Points = new List<Point3D>();
            clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[index1], clsVar.varEntities.RegenDeviation, ref Points);
            if (Points.Count > 1)
            {
              LinearPath linearPath = new LinearPath((ICollection<Point3D>) Points);
              entityList3.Add((Entity) linearPath);
            }
            for (int index2 = 0; index2 <= entityList3.Count - 1; ++index2)
            {
              entitySortDirection sortDirection = clsInit.cVector5.GetSortDirection(entityList3[index2]);
              if (sortDirection == entitySortDirection.Normal)
                buMwCurveEntities.pntStart = new Point3d<double>(((ICurve) entityList3[index2]).StartPoint.X, ((ICurve) entityList3[index2]).StartPoint.Y, ((ICurve) entityList3[index2]).StartPoint.Z);
              if (sortDirection == entitySortDirection.Reverse)
                buMwCurveEntities.pntStart = new Point3d<double>(((ICurve) entityList3[index2]).EndPoint.X, ((ICurve) entityList3[index2]).EndPoint.Y, ((ICurve) entityList3[index2]).EndPoint.Z);
              if (Curve2dContainment.Count < ccVars.SelectionOP.ClickList.Count - 1 & ccVars.SelectionOP.ClickList.Count > 0)
                buMwCurveEntities.pntStart = new Point3d<double>(ccVars.SelectionOP.ClickList[Curve2dContainment.Count].X, ccVars.SelectionOP.ClickList[Curve2dContainment.Count].Y, ccVars.SelectionOP.ClickList[Curve2dContainment.Count].Z);
              ModuleWorks.Curve mwEntity = (ModuleWorks.Curve) null;
              buMWCalcs.ConvertWireEntity(entityList3[index2], ref mwEntity);
              buMwCurveEntities.CurveList.Add(mwEntity);
            }
          }
          if (buMwCurveEntities.CurveList.Count > 0)
          {
            Curve2dContainment.Add(buMwCurveEntities);
            buMwCurveEntities = new buMWCurveEntities();
          }
        }
        if (Curve2dContainment.Count == 0)
          clsInit.cMwCalc.mwCamDataParameter.MachParam.Containment2dParams.IsUsedFlg = false;
        if (clsInit.cMwCalc.CalculateTriangleMesh(Tool, MeshEntities, Curve2dContainment, CalcType, MWCalcOptions, ref camResult))
        {
          clsInit.appCommand.undoBuffer();
          ccVars.UndoDont = true;
          Cam = new camTp();
          int AvailableCamID = 0;
          clsInit.appCommand.CamAvailableIDGet(ref AvailableCamID);
          CamType camType = CamType.None;
          if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.Rough)
          {
            clsMW.varMWCamMeshRough5AXPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
            buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamMeshRough5AXPars);
            clsMW.varbuCamMeshRough5AXPars = new camParameters5(camResult.buCamParamters);
            camType = CamType.Rough;
          }
          else if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ParallelCuts)
          {
            clsMW.varMWCamMeshParalel5AXPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
            buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamMeshParalel5AXPars);
            clsMW.varbuCamMeshParallel5AXPars = new camParameters5(camResult.buCamParamters);
            camType = CamType.ParallelCut;
          }
          else if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ConstantZ)
          {
            clsMW.varMWCamMeshContantZ5AXPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
            buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamMeshContantZ5AXPars);
            clsMW.varbuCamMeshConstantZ5AXPars = new camParameters5(camResult.buCamParamters);
            camType = CamType.ConstantZ;
          }
          this.IterateThroughEntireStructure5X(camResult.ToolPathCalc, AvailableCamID, camResult.buCamParamters, camResult.geoLib, ref Cam);
          Cam.TypeCam = camType;
          Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
          Cam.Tool = new ToolBase5(camResult.Tool);
          Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
          Cam.Parameter = new camParameters5(camResult.buCamParamters);
          Cam.mwParameter = (object) new MachiningParams(camResult.geoLib.MachParam);
          Cam.CamID = AvailableCamID;
          buVector5.CopyEntities(entityList1, ref Cam.RefEntities);
          this.SaveMWParameter();
          if (MWCalcOptions.AddToCamListInMWCalculation)
            clsInit.appCommand.CamAdd(Cam);
          if (!MWCalcOptions.DontApplyReset)
            clsInit.appCommand.Reset();
          clsItem.FrmProgress.Visible = false;
          num1 = 1;
        }
        else
          num1 = -1;
      }
    }
label_117:
    return num1;
  }

  public int doGeodesic(
    MWCalculationOptions MWCalcOptions,
    ToolBase5 ToolSelected,
    ref camTp Cam,
    ref camResult Result)
  {
    ToolBase5 Tool = new ToolBase5(ToolSelected);
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    MWCalculationResult camResult = new MWCalculationResult();
    TriangleMeshBasedTpCalcParamsPattern CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> refEnt = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    List<buMWCurveEntities> Curve2dContainment = new List<buMWCurveEntities>();
    buMWCurveEntities buMwCurveEntities = new buMWCurveEntities();
    SelectionOption Option1 = new SelectionOption(false, true, false, false, false, false);
    bool flag1 = true;
    Result = new camResult();
    if (Tool.Purpose == ToolPurpose.Drilling | Tool.Purpose == ToolPurpose.DiamondCut)
      flag1 = false;
    int num1;
    if (!flag1)
    {
      int num2 = (int) MessageBox.Show(AppLanguage.CadCamMessages[57]);
      clsInit.appCommand.Reset();
      num1 = -1;
    }
    else
    {
      if (clsMW.CamEntities.Count == 0)
      {
        clsInit.appCommand.SelectionToEntities(ref entityList1, Option1);
        SelectionOption Option2 = new SelectionOption(true, false, false, false, false, false);
        clsInit.appCommand.SelectionToEntities(ref refEnt, Option2);
      }
      else
      {
        buVector5.CopyEntities(clsMW.CamEntities, ref entityList1);
        clsInit.cVector5.EntitiesPlaneCheck(ref entityList1);
      }
      if (clsMW.Containment2DEntities.Count > 0)
        buVector5.CopyEntities(clsMW.Containment2DEntities, ref refEnt);
      if (clsInit.cMwCalc.mwCamDataParameter != null)
        clsInit.cMwCalc.mwCamDataParameter.Dispose();
      clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
      buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamGeodesicPars, clsInit.cMwCalc.mwCamDataParameter);
      clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamGeodesicPars.MachParam);
      clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamGeodesicPars);
      this.ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
      clsInit.cVector5.BoxSizeCalculate(entityList1, ref MinPoint, ref MidPoint, ref MaxPoint);
      clsInit.cMwCalc.buCamDataParameter.Operations.Height = MaxPoint.Z;
      if (MWCalcOptions.CheckBoxBounding)
      {
        if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
        {
          if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[1], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[0], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
          {
            if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[3], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[2], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[5], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[4], 0);
              Result.Errors.Add(calculationError);
            }
          }
        }
        if (Result.Errors.Count > 0)
        {
          num1 = -1;
          goto label_95;
        }
      }
      if (!MWCalcOptions.DontShowbuDialogBox)
      {
        F_TriMeshRough fTriMeshRough = new F_TriMeshRough()
        {
          Configration = new MWCalculationOptions(MWCalcOptions),
          mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
        };
        fTriMeshRough.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, fTriMeshRough.mwCamParameter);
        fTriMeshRough.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
        fTriMeshRough.Init();
        int num3 = (int) fTriMeshRough.ShowDialog();
        if (fTriMeshRough.PropertiesForm.Result == DialogResult.OK)
        {
          clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(fTriMeshRough.mwCamParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(fTriMeshRough.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
          clsInit.cMwCalc.buCamDataParameter = new camParameters5(fTriMeshRough.buCamParameter);
        }
        else
        {
          num1 = -1;
          goto label_95;
        }
      }
      this.CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
      List<Meshd> MeshEntities = new List<Meshd>();
      clsInit.cMwCalc.Stock = (List<Meshd>) null;
      List<Point3D> pointList = new List<Point3D>();
      for (int index = 0; index <= entityList1.Count - 1; ++index)
      {
        if (entityList1[index] is Mesh)
        {
          if (clsInit.cMwCalc.buCamDataParameter.Options.StockHeight > 0.0)
          {
            if (entityList1[index].BoxMax == (Point3D) null)
            {
              entityList1[index].Regen(new RegenParams(0.01));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMax));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMin));
            }
            else
            {
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMax));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMin));
            }
          }
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh((Mesh) entityList1[index]);
          if (mwMesh != null)
            MeshEntities.Add(mwMesh);
        }
        else if (entityList1[index] is devDept.Eyeshot.Entities.Surface)
        {
          Mesh mesh = ((devDept.Eyeshot.Entities.Surface) entityList1[index]).ConvertToMesh();
          if (mesh.BoxMax == (Point3D) null)
            mesh.Regen(new RegenParams(0.01));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMax));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMin));
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh(mesh);
          if (mwMesh != null)
            MeshEntities.Add(mwMesh);
        }
        else if (entityList1[index] is Brep)
        {
          Mesh mesh = ((Brep) entityList1[index]).ConvertToMesh(0.01);
          mesh.Regen(0.01);
          if (mesh.BoxMax == (Point3D) null)
            mesh.Regen(new RegenParams(0.01));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMax));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMin));
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh(mesh);
          if (mwMesh != null)
            MeshEntities.Add(mwMesh);
        }
      }
      if (MeshEntities.Count == 0)
      {
        buString.MessageBoxError(AppLanguage.CadCamMessages[79]);
        clsInit.appCommand.Reset();
        clsItem.FrmProgress.Visible = false;
        num1 = -1;
      }
      else
      {
        if (pointList.Count > 0)
        {
          Point3D min = new Point3D();
          Point3D max = new Point3D();
          Utility.BoundingBox((IList<Point3D>) pointList, out min, out max);
          Mesh box = Mesh.CreateBox(max.X - min.X, max.Y - min.Y, clsInit.cMwCalc.buCamDataParameter.Options.StockHeight);
          box.Translate(min.X, min.Y, min.Z);
          if (box != null)
          {
            if (clsInit.cMwCalc.Stock == null)
              clsInit.cMwCalc.Stock = new List<Meshd>();
            Meshd mwMesh = buMWCalcs.ConvertToMWMesh(box);
            clsInit.cMwCalc.Stock.Add(mwMesh);
          }
        }
        SortSettings sortSettings = new SortSettings();
        SortResult Result1 = new SortResult();
        List<Entity> RefEntities = new List<Entity>();
        if (refEnt.Count > 0)
        {
          if (MWCalcOptions.isBuSort)
          {
            if (ccVars.SelectionOP.ClickList.Count > 0)
            {
              sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
              clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref refEnt, MWCalcOptions.SortingSettings, ref RefEntities, ref Result1);
            }
            else if (MWCalcOptions.UseConstantStartPoint)
              clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MWCalcOptions.StartPointX, MWCalcOptions.StartPointY), ref refEnt, MWCalcOptions.SortingSettings, ref RefEntities, ref Result1);
            else
              clsInit.cVector5.SortEntitiesByRefPoint(((ICurve) refEnt[0]).StartPoint, ref refEnt, MWCalcOptions.SortingSettings, ref RefEntities, ref Result1);
          }
          else
            buVector5.CopyEntities(refEnt, ref RefEntities);
        }
        List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
        List<List<Entity>> entityListList = new List<List<Entity>>();
        clsInit.cVector5.EntitiesSplitByUpperLine(RefEntities, ref SplitedEntitites);
        for (int index1 = 0; index1 <= SplitedEntitites.Count - 1; ++index1)
        {
          List<Entity> entityList3 = new List<Entity>();
          bool flag2 = clsInit.cVector5.isEntitiesClosed(SplitedEntitites[index1]);
          int num4 = (int) clsInit.cVector5.EntitiesClockDirection(SplitedEntitites[index1]);
          if (flag2)
          {
            List<Point3D> Points = new List<Point3D>();
            clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[index1], clsVar.varEntities.RegenDeviation, ref Points);
            if (Points.Count > 1)
            {
              LinearPath linearPath = new LinearPath((ICollection<Point3D>) Points);
              entityList3.Add((Entity) linearPath);
            }
            for (int index2 = 0; index2 <= entityList3.Count - 1; ++index2)
            {
              entitySortDirection sortDirection = clsInit.cVector5.GetSortDirection(entityList3[index2]);
              if (sortDirection == entitySortDirection.Normal)
                buMwCurveEntities.pntStart = new Point3d<double>(((ICurve) entityList3[index2]).StartPoint.X, ((ICurve) entityList3[index2]).StartPoint.Y, ((ICurve) entityList3[index2]).StartPoint.Z);
              if (sortDirection == entitySortDirection.Reverse)
                buMwCurveEntities.pntStart = new Point3d<double>(((ICurve) entityList3[index2]).EndPoint.X, ((ICurve) entityList3[index2]).EndPoint.Y, ((ICurve) entityList3[index2]).EndPoint.Z);
              if (Curve2dContainment.Count < ccVars.SelectionOP.ClickList.Count - 1 & ccVars.SelectionOP.ClickList.Count > 0)
                buMwCurveEntities.pntStart = new Point3d<double>(ccVars.SelectionOP.ClickList[Curve2dContainment.Count].X, ccVars.SelectionOP.ClickList[Curve2dContainment.Count].Y, ccVars.SelectionOP.ClickList[Curve2dContainment.Count].Z);
              ModuleWorks.Curve mwEntity = (ModuleWorks.Curve) null;
              buMWCalcs.ConvertWireEntity(entityList3[index2], ref mwEntity);
              buMwCurveEntities.CurveList.Add(mwEntity);
            }
          }
          if (buMwCurveEntities.CurveList.Count > 0)
          {
            Curve2dContainment.Add(buMwCurveEntities);
            buMwCurveEntities = new buMWCurveEntities();
          }
        }
        if (Curve2dContainment.Count == 0)
          clsInit.cMwCalc.mwCamDataParameter.MachParam.Containment2dParams.IsUsedFlg = false;
        if (clsInit.cMwCalc.CalculateGeodesic(Tool, MeshEntities, Curve2dContainment, CalcType, MWCalcOptions, ref camResult))
        {
          clsInit.appCommand.undoBuffer();
          ccVars.UndoDont = true;
          Cam = new camTp();
          int AvailableCamID = 0;
          clsInit.appCommand.CamAvailableIDGet(ref AvailableCamID);
          clsMW.varMWCamGeodesicPars.MachParam = new MachiningParams(camResult.geoLib.MachParam);
          buMWCalcs.CopyGeoLibProperties(camResult.geoLib, clsMW.varMWCamGeodesicPars);
          clsMW.varbuCamGeodesicPars = new camParameters5(camResult.buCamParamters);
          this.IterateThroughEntireStructure5X(camResult.ToolPathCalc, AvailableCamID, camResult.buCamParamters, camResult.geoLib, ref Cam);
          Cam.TypeCam = CamType.Finish;
          Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
          Cam.Tool = new ToolBase5(camResult.Tool);
          Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
          Cam.Parameter = new camParameters5(camResult.buCamParamters);
          Cam.mwParameter = (object) new MachiningParams(camResult.geoLib.MachParam);
          Cam.CamID = AvailableCamID;
          buVector5.CopyEntities(entityList1, ref Cam.RefEntities);
          this.SaveMWParameter();
          if (MWCalcOptions.AddToCamListInMWCalculation)
            clsInit.appCommand.CamAdd(Cam);
          if (!MWCalcOptions.DontApplyReset)
            clsInit.appCommand.Reset();
          clsItem.FrmProgress.Visible = false;
          num1 = 1;
        }
        else
          num1 = -1;
      }
    }
label_95:
    return num1;
  }

  public int doDrill(
    MWCalculationOptions MWCalcOptions,
    ToolBase5 ToolSelected,
    ref camTp Cam,
    ref camResult Result)
  {
    ToolBase5 Tool = new ToolBase5(ToolSelected);
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    MWCalculationResult calculationResult = new MWCalculationResult();
    List<Entity> refEnt = new List<Entity>();
    List<Entity> BaseRefEntities = new List<Entity>();
    List<Entity> SortedEntities = new List<Entity>();
    List<buMWCurveEntities> buMwCurveEntitiesList = new List<buMWCurveEntities>();
    List<ModuleWorks.Curve> curveList = new List<ModuleWorks.Curve>();
    buMWCurveEntities buMwCurveEntities = new buMWCurveEntities();
    SortSettings Settings = new SortSettings();
    SortResult Result1 = new SortResult();
    bool flag = false;
    Result = new camResult();
    if (Tool.Purpose == ToolPurpose.Drilling | Tool.Purpose == ToolPurpose.DiamondCut)
      flag = true;
    int num1;
    if (!flag)
    {
      int num2 = (int) MessageBox.Show(AppLanguage.CadCamMessages[57]);
      clsInit.appCommand.Reset();
      num1 = -1;
    }
    else
    {
      if (clsMW.CamEntities.Count == 0)
      {
        SelectionOption Option = new SelectionOption();
        clsInit.appCommand.SelectionToEntities(ref refEnt, Option);
      }
      else
      {
        buVector5.CopyEntities(clsMW.CamEntities, ref refEnt);
        clsInit.cVector5.EntitiesPlaneCheck(ref refEnt);
      }
      for (int index = 0; index <= refEnt.Count - 1; ++index)
      {
        Point3D p = (Point3D) null;
        OrientationAngle orientationAngle = (OrientationAngle) null;
        if (refEnt[index] is Circle)
        {
          p = new Point3D(((Circle) refEnt[index]).Center.X, ((Circle) refEnt[index]).Center.Y, ((Circle) refEnt[index]).Center.Z);
          orientationAngle = new OrientationAngle();
        }
        else if (refEnt[index] is devDept.Eyeshot.Entities.Point)
        {
          p = new Point3D(((devDept.Eyeshot.Entities.Point) refEnt[index]).StartPoint.X, ((devDept.Eyeshot.Entities.Point) refEnt[index]).StartPoint.Y, ((devDept.Eyeshot.Entities.Point) refEnt[index]).StartPoint.Z);
          orientationAngle = new OrientationAngle();
        }
        else if (refEnt[index] is Arc)
        {
          p = new Point3D(((Circle) refEnt[index]).Center.X, ((Circle) refEnt[index]).Center.Y, ((Circle) refEnt[index]).Center.Z);
          orientationAngle = new OrientationAngle();
        }
        else if (refEnt[index] is Ellipse)
        {
          p = new Point3D(((Ellipse) refEnt[index]).Center.X, ((Ellipse) refEnt[index]).Center.Y, ((Ellipse) refEnt[index]).Center.Z);
          orientationAngle = new OrientationAngle();
        }
        else if (refEnt[index] is EllipticalArc)
        {
          p = new Point3D(((Ellipse) refEnt[index]).Center.X, ((Ellipse) refEnt[index]).Center.Y, ((Ellipse) refEnt[index]).Center.Z);
          orientationAngle = new OrientationAngle();
        }
        else if (refEnt[index] is Line)
        {
          p = new Point3D(((Line) refEnt[index]).MidPoint.X, ((Line) refEnt[index]).MidPoint.Y, ((Line) refEnt[index]).MidPoint.Z);
          orientationAngle = new OrientationAngle(0.0, 0.0, clsInit.cVector5.PointAngle(((Line) refEnt[index]).EndPoint, ((Line) refEnt[index]).StartPoint, Plane.XY));
        }
        if (p != (Point3D) null)
        {
          devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(p);
          point.EntityData = (object) new CustomData();
          ((CustomData) point.EntityData).OrientationC = orientationAngle.C;
          BaseRefEntities.Add((Entity) point);
        }
      }
      Settings.Filter.UsePointEntities = true;
      if (ccVars.SelectionOP.ClickList.Count > 0)
      {
        Settings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
        clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref BaseRefEntities, Settings, ref SortedEntities, ref Result1);
      }
      else
        clsInit.cVector5.SortEntitiesByRefPoint(((ICurve) refEnt[0]).StartPoint, ref BaseRefEntities, Settings, ref SortedEntities, ref Result1);
      if (clsInit.cMwCalc.mwCamDataParameter != null)
        clsInit.cMwCalc.mwCamDataParameter.Dispose();
      clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
      buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamDrillPars, clsInit.cMwCalc.mwCamDataParameter);
      clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamDrillPars.MachParam);
      clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamDrillPars);
      this.ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
      clsInit.cVector5.BoxSizeCalculate(SortedEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
      MWCalcOptions.isClosed = clsInit.cVector5.isEntitiesClosed(SortedEntities);
      MWCalcOptions.Direction = clsInit.cVector5.GetClockDirection(SortedEntities);
      if (MWCalcOptions.CheckBoxBounding)
      {
        if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
        {
          if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[1], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[0], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
          {
            if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[3], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[2], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[5], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[4], 0);
              Result.Errors.Add(calculationError);
            }
          }
        }
        if (Result.Errors.Count > 0)
        {
          num1 = -1;
          goto label_78;
        }
      }
      List<Pnt6D> Points = new List<Pnt6D>();
      for (int index = 0; index <= SortedEntities.Count - 1; ++index)
      {
        if (SortedEntities[index] is devDept.Eyeshot.Entities.Point)
        {
          devDept.Eyeshot.Entities.Point point = (devDept.Eyeshot.Entities.Point) SortedEntities[index];
          double c = 0.0;
          if (point.EntityData != null)
            c = ((CustomData) point.EntityData).OrientationC;
          Points.Add(new Pnt6D(point.Vertices[0].X, point.Vertices[0].Y, point.Vertices[0].Z, 0.0, 0.0, c));
        }
      }
      if (Points.Count == 0)
      {
        buString.MessageBoxError(AppLanguage.CadCamMessages[80 /*0x50*/]);
        clsInit.appCommand.Reset();
        clsItem.FrmProgress.Visible = false;
        num1 = -1;
      }
      else
      {
        if (!MWCalcOptions.DontShowDialogBox)
        {
          F_DrillLine fDrillLine = new F_DrillLine()
          {
            mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0)
          };
          fDrillLine.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, fDrillLine.mwCamParameter);
          fDrillLine.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
          fDrillLine.Configration = new MWCalculationOptions(MWCalcOptions);
          fDrillLine.Init();
          int num3 = (int) fDrillLine.ShowDialog();
          if (fDrillLine.PropertiesForm.Result == DialogResult.OK)
          {
            clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(fDrillLine.mwCamParameter.MachParam);
            buMWCalcs.CopyGeoLibProperties(fDrillLine.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
            clsInit.cMwCalc.buCamDataParameter = new camParameters5(fDrillLine.buCamParameter);
          }
          else
          {
            num1 = -1;
            goto label_78;
          }
        }
        this.CamDataToolData(clsInit.cMwCalc.buCamDataParameter, ref Tool);
        Tool.CamData.SpindleSpeed = clsInit.cMwCalc.buCamDataParameter.Speeds.SpindleSpeed;
        Tool.CamData.SpindleDirection = clsInit.cMwCalc.buCamDataParameter.Speeds.SpindleDirection;
        clsInit.cVector.CheckDuplicatedPointsWithPrevious(ref Points);
        Cam = new camTp();
        camParameters5 BUPar = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
        clsInit.appCommand.CamAvailableIDGet(ref BUPar.Runtime.CamID);
        buMWCalcs.ConvertFromMwCamParToBuCamPar(clsInit.cMwCalc.mwCamDataParameter, ref BUPar);
        if (MWCalcOptions.CamDrillMode == CamDrillMode.Point | MWCalcOptions.CamDrillMode == CamDrillMode.Tangent)
        {
          clsInit.cCam5.camDrill(Points, Tool, new WorkPlane(), BUPar, ref Cam);
          clsMW.varbuCamDrillPars = new camParameters5(BUPar);
          clsMW.varMWCamDrillPars.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, clsMW.varMWCamDrillPars);
        }
        else if (MWCalcOptions.CamDrillMode == CamDrillMode.Rotation)
        {
          clsInit.cCam5.camDrillThenRotation(Points, Tool, new WorkPlane(), BUPar, ref Cam);
          clsMW.varbuCamDrillPars = new camParameters5(BUPar);
          clsMW.varMWCamDrillPars.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, clsMW.varMWCamDrillPars);
        }
        clsInit.appCommand.undoBuffer();
        ccVars.UndoDont = true;
        if (MWCalcOptions.NumberofAxis == 3)
          Cam.TypeCam = CamType.Drill;
        if (MWCalcOptions.NumberofAxis == 4)
          Cam.TypeCam = CamType.Drill4X;
        Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
        if (calculationResult.geoLib != null)
        {
          clsMW.varMWCamDrillPars.MachParam = new MachiningParams(calculationResult.geoLib.MachParam);
          buMWCalcs.CopyGeoLibProperties(calculationResult.geoLib, clsMW.varMWCamDrillPars);
        }
        if (calculationResult.buCamParamters != null)
          clsMW.varbuCamDrillPars = new camParameters5(calculationResult.buCamParamters);
        Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
        Cam.Parameter = new camParameters5(BUPar);
        Cam.mwParameter = (object) new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
        Cam.CamID = BUPar.Runtime.CamID;
        Cam.Tool = Tool;
        buVector5.CopyEntities(refEnt, ref Cam.RefEntities);
        this.SaveMWParameter();
        if (MWCalcOptions.AddToCamListInMWCalculation)
          clsInit.appCommand.CamAdd(Cam);
        if (!MWCalcOptions.DontApplyReset)
          clsInit.appCommand.Reset();
        clsItem.FrmProgress.Visible = false;
        num1 = 1;
      }
    }
label_78:
    return num1;
  }

  public int doContouring(
    MWCalculationOptions MWCalcOptions,
    ToolBase5 ToolSelected,
    ref camTp Cam,
    ref camResult Result)
  {
    ToolBase5 Tool = new ToolBase5(ToolSelected);
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    MWCalculationResult camResult = new MWCalculationResult();
    TriangleMeshBasedTpCalcParamsPattern CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    List<Entity> entityList3 = new List<Entity>();
    List<buMWCurveEntities> EdgeCurves = new List<buMWCurveEntities>();
    buMWCurveEntities buMwCurveEntities = new buMWCurveEntities();
    SelectionOption selectionOption = new SelectionOption(false, true, false, false, false, false);
    bool flag = true;
    Result = new camResult();
    if (Tool.Purpose == ToolPurpose.Drilling | Tool.Purpose == ToolPurpose.DiamondCut)
      flag = false;
    int num1;
    if (!flag)
    {
      int num2 = (int) MessageBox.Show(AppLanguage.CadCamMessages[57]);
      num1 = -1;
    }
    else
    {
      buVector5.CopyEntities(clsMW.CamEntities, ref entityList1);
      clsInit.cVector5.EntitiesPlaneCheck(ref entityList1);
      if (buMWCalcs.CamEntities.Count > 0)
      {
        buVector5.CopyEntities(buMWCalcs.CamEntities, ref entityList1);
        clsInit.cVector5.EntitiesPlaneCheck(ref entityList1);
      }
      if (clsInit.cMwCalc.mwCamDataParameter != null)
        clsInit.cMwCalc.mwCamDataParameter.Dispose();
      clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
      buMWCalcs.CopyCamParameter(buMWCalcs.varCamContouringPars, ref clsInit.cMwCalc.mwCamDataParameter, ref clsInit.cMwCalc.buCamDataParameter);
      this.ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
      clsInit.cVector5.BoxSizeCalculate(entityList1, ref MinPoint, ref MidPoint, ref MaxPoint);
      if (MWCalcOptions.CheckBoxBounding)
      {
        if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
        {
          if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[1], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[0], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
          {
            if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[3], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[2], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[5], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[4], 0);
              Result.Errors.Add(calculationError);
            }
          }
        }
        if (Result.Errors.Count > 0)
        {
          num1 = -1;
          goto label_57;
        }
      }
      this.CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
      List<Meshd> SurfaceEntities = new List<Meshd>();
      clsInit.cMwCalc.Stock = (List<Meshd>) null;
      List<Point3D> pointList = new List<Point3D>();
      for (int index = 0; index <= entityList1.Count - 1; ++index)
      {
        if (entityList1[index] is Mesh)
        {
          if (clsInit.cMwCalc.buCamDataParameter.Options.StockHeight > 0.0)
          {
            if (entityList1[index].BoxMax == (Point3D) null)
            {
              entityList1[index].Regen(new RegenParams(0.01));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMax));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMin));
            }
            else
            {
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMax));
              pointList.Add(buVector5.ToPoint3D(entityList1[index].BoxMin));
            }
          }
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh((Mesh) entityList1[index]);
          if (mwMesh != null)
            SurfaceEntities.Add(mwMesh);
        }
        else if (entityList1[index] is devDept.Eyeshot.Entities.Surface)
        {
          Mesh mesh = ((devDept.Eyeshot.Entities.Surface) entityList1[index]).ConvertToMesh();
          if (mesh.BoxMax == (Point3D) null)
            mesh.Regen(new RegenParams(0.01));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMax));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMin));
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh(mesh);
          if (mwMesh != null)
            SurfaceEntities.Add(mwMesh);
        }
        else if (entityList1[index] is Brep)
        {
          entityList1[index].Regen(new RegenParams(0.01));
          Mesh mesh = ((Brep) entityList1[index]).ConvertToMesh();
          if (mesh.BoxMax == (Point3D) null)
            mesh.Regen(new RegenParams(0.01));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMax));
          pointList.Add(buVector5.ToPoint3D(mesh.BoxMin));
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh(mesh);
          if (mwMesh != null)
            SurfaceEntities.Add(mwMesh);
        }
      }
      if (SurfaceEntities.Count == 0)
      {
        buString.MessageBoxError(AppLanguage.CadCamMessages[79]);
        num1 = -1;
      }
      else
      {
        if (pointList.Count > 0)
        {
          Point3D min = new Point3D();
          Point3D max = new Point3D();
          Utility.BoundingBox((IList<Point3D>) pointList, out min, out max);
          Mesh box = Mesh.CreateBox(max.X - min.X, max.Y - min.Y, clsInit.cMwCalc.buCamDataParameter.Options.StockHeight);
          box.Translate(min.X, min.Y, min.Z);
          if (box != null)
          {
            if (clsInit.cMwCalc.Stock == null)
              clsInit.cMwCalc.Stock = new List<Meshd>();
            Meshd mwMesh = buMWCalcs.ConvertToMWMesh(box);
            clsInit.cMwCalc.Stock.Add(mwMesh);
          }
        }
        if (clsInit.cMwCalc.CalculateContouring(Tool, SurfaceEntities, EdgeCurves, CalcType, MWCalcOptions, ref camResult))
        {
          Cam = new camTp();
          buMWCalcs.CopyCamParameter(camResult.geoLib, camResult.buCamParamters, ref buMWCalcs.varCamContouringPars);
          double axialShift1 = camResult.geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
          double axialShift2 = buMWCalcs.varCamContouringPars.mwPar.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
          this.IterateThroughEntireStructure5X(camResult.ToolPathCalc, 0, camResult.buCamParamters, camResult.geoLib, ref Cam);
          Cam.TypeCam = CamType.None;
          Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
          Cam.Tool = new ToolBase5(camResult.Tool);
          Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
          Cam.Parameter = new camParameters5(camResult.buCamParamters);
          Cam.mwParameter = (object) new MachiningParams(camResult.geoLib.MachParam);
          Cam.CamID = 0;
          buVector5.CopyEntities(entityList1, ref Cam.RefEntities);
          num1 = 1;
        }
        else
          num1 = -1;
      }
    }
label_57:
    return num1;
  }

  public int doSurface(
    MWCalculationOptions MWCalcOptions,
    ToolBase5 ToolSelected,
    ref camTp Cam,
    ref camResult Result)
  {
    ToolBase5 Tool = new ToolBase5(ToolSelected);
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    MWCalculationResult camResult = new MWCalculationResult();
    TriangleMeshBasedTpCalcParamsPattern CalcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> selectedEntities = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    List<buMWCurveEntities> buMwCurveEntitiesList = new List<buMWCurveEntities>();
    buMWCurveEntities buMwCurveEntities = new buMWCurveEntities();
    SelectionOption Option1 = new SelectionOption(false, true, false, false, false, false);
    bool flag = true;
    Result = new camResult();
    if (Tool.Purpose == ToolPurpose.Drilling | Tool.Purpose == ToolPurpose.DiamondCut)
      flag = false;
    int num1;
    if (!flag)
    {
      int num2 = (int) MessageBox.Show(AppLanguage.CadCamMessages[57]);
      num1 = -1;
    }
    else
    {
      if (clsMW.CamEntities.Count == 0)
      {
        clsInit.appCommand.SelectionToEntities(ref entityList1, Option1);
        SelectionOption Option2 = new SelectionOption(true, false, false, false, false, false);
        clsInit.appCommand.SelectionToEntities(ref selectedEntities, Option2);
      }
      else
      {
        buVector5.CopyEntities(clsMW.CamEntities, ref entityList1);
        clsInit.cVector5.EntitiesPlaneCheck(ref entityList1);
      }
      if (clsInit.cMwCalc.mwCamDataParameter != null)
        clsInit.cMwCalc.mwCamDataParameter.Dispose();
      clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
      buMWCalcs.CopyGeoLibProperties(clsMW.varMWCamSurfaceParallelPars, clsInit.cMwCalc.mwCamDataParameter);
      clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(clsMW.varMWCamSurfaceParallelPars.MachParam);
      clsInit.cMwCalc.buCamDataParameter = new camParameters5(clsMW.varbuCamSurfaceParallelPars);
      this.ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
      clsInit.cVector5.BoxSizeCalculate(entityList1, ref MinPoint, ref MidPoint, ref MaxPoint);
      if (MWCalcOptions.CheckBoxBounding)
      {
        if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
        {
          if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[1], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[0], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
          {
            if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[3], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[2], 0);
              Result.Errors.Add(calculationError);
            }
          }
          if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
          {
            if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[5], 0);
              Result.Errors.Add(calculationError);
            }
            if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
            {
              CalculationError calculationError = new CalculationError(AppLanguage.CadCamError[4], 0);
              Result.Errors.Add(calculationError);
            }
          }
        }
        if (Result.Errors.Count > 0)
        {
          num1 = -1;
          goto label_60;
        }
      }
      this.CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
      List<ModuleWorks.Surface> SurfaceEntities = new List<ModuleWorks.Surface>();
      List<Meshd> Meshes = new List<Meshd>();
      clsInit.cMwCalc.Stock = (List<Meshd>) null;
      List<Point3D> pointList = new List<Point3D>();
      for (int index1 = 0; index1 <= entityList1.Count - 1; ++index1)
      {
        if (entityList1[index1] is Mesh)
        {
          Meshd mwMesh = buMWCalcs.ConvertToMWMesh((Mesh) entityList1[index1]);
          if (mwMesh != null)
          {
            Meshes.Add(mwMesh);
            if (entityList1[index1].BoxMax == (Point3D) null)
              entityList1[index1].Regen(new RegenParams(0.01));
            pointList.Add(buVector5.ToPoint3D(entityList1[index1].BoxMax));
            pointList.Add(buVector5.ToPoint3D(entityList1[index1].BoxMin));
          }
        }
        else if (entityList1[index1] is devDept.Eyeshot.Entities.Surface)
        {
          devDept.Eyeshot.Entities.Surface surf = (devDept.Eyeshot.Entities.Surface) entityList1[index1];
          if (surf.BoxMax == (Point3D) null)
            surf.Regen(new RegenParams(0.01));
          pointList.Add(buVector5.ToPoint3D(surf.BoxMax));
          pointList.Add(buVector5.ToPoint3D(surf.BoxMin));
          ModuleWorks.Surface mwSurface = buMWCalcs.ConvertToMWSurface(surf);
          if (mwSurface != null)
          {
            SurfaceEntities.Add(mwSurface);
            Mesh mesh = surf.ConvertToMesh();
            Meshes.Add(buMWCalcs.ConvertToMWMesh(mesh));
          }
        }
        else if (entityList1[index1] is Brep)
        {
          entityList1[index1].Regen(new RegenParams(0.01));
          devDept.Eyeshot.Entities.Surface[] surfaces = ((Brep) entityList1[index1]).ConvertToSurfaces();
          if (surfaces != null)
          {
            for (int index2 = 0; index2 <= surfaces.Length - 1; ++index2)
            {
              if (surfaces[index2].BoxMax == (Point3D) null)
                surfaces[index2].Regen(new RegenParams(0.01));
              pointList.Add(buVector5.ToPoint3D(surfaces[index2].BoxMax));
              pointList.Add(buVector5.ToPoint3D(surfaces[index2].BoxMin));
              ModuleWorks.Surface mwSurface = buMWCalcs.ConvertToMWSurface(surfaces[index2]);
              if (mwSurface != null)
                SurfaceEntities.Add(mwSurface);
            }
          }
        }
      }
      if (SurfaceEntities.Count == 0 & Meshes.Count == 0)
      {
        buString.MessageBoxError(AppLanguage.CadCamMessages[79]);
        num1 = -1;
      }
      else
      {
        if (pointList.Count > 0)
        {
          Point3D min = new Point3D();
          Point3D max = new Point3D();
          Utility.BoundingBox((IList<Point3D>) pointList, out min, out max);
          Mesh box = Mesh.CreateBox(max.X - min.X, max.Y - min.Y, clsInit.cMwCalc.buCamDataParameter.Options.StockHeight);
          box.Translate(min.X, min.Y, min.Z);
          if (box != null)
          {
            if (clsInit.cMwCalc.Stock == null)
              clsInit.cMwCalc.Stock = new List<Meshd>();
            Meshd mwMesh = buMWCalcs.ConvertToMWMesh(box);
            clsInit.cMwCalc.Stock.Add(mwMesh);
          }
        }
        if (clsInit.cMwCalc.CalculateSurface(Tool, SurfaceEntities, Meshes, CalcType, MWCalcOptions, ref camResult))
        {
          Cam = new camTp();
          buMWCalcs.CopyCamParameter(camResult.geoLib, camResult.buCamParamters, ref buMWCalcs.varCamSurfacePars);
          this.IterateThroughEntireStructure5X(camResult.ToolPathCalc, 0, camResult.buCamParamters, camResult.geoLib, ref Cam);
          Cam.TypeCam = CamType.None;
          Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
          Cam.Tool = new ToolBase5(camResult.Tool);
          Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
          Cam.Parameter = new camParameters5(camResult.buCamParamters);
          Cam.mwParameter = (object) new MachiningParams(camResult.geoLib.MachParam);
          Cam.CamID = 0;
          buVector5.CopyEntities(entityList1, ref Cam.RefEntities);
          num1 = 1;
        }
        else
          num1 = -1;
      }
    }
label_60:
    return num1;
  }

  public void IterateThroughEntireStructure3X(
    ToolPath calculatedToolPath,
    int CamID,
    camParameters5 camPars,
    GeoLib mwPars,
    ref camTp CamResult,
    bool AllG1 = false)
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    int num5 = 0;
    int num6 = 0;
    int num7 = 0;
    int num8 = 0;
    Point3D point3D1 = new Point3D();
    CamResult = new camTp();
    CalculationEventArg e = new CalculationEventArg();
    List<Point3D> point3DList = new List<Point3D>();
    foreach (TPPass pass in calculatedToolPath.Passes)
    {
      ++num1;
      double num9 = (double) num1 / (double) calculatedToolPath.Passes.Count<TPPass>();
      if (num9 > 1.0)
        num9 = 1.0;
      Application.DoEvents();
      e.OverallProgressPercentage = num9 * 100.0;
      int num10 = 0;
      foreach (TPSlice slice in pass.Slices)
      {
        ++num10;
        double num11 = Convert.ToDouble(num10) / (double) pass.Slices.Count<TPSlice>();
        if (num11 > 1.0)
          num11 = 1.0;
        e.ActiveProgressPercentage = num11 * 100.0;
        e.Job = "Iteration";
        e.ShowForm = clsInit.cMwCalc.Settings.ShowProgressForm;
        clsInit.appCommand.CalculationInProgressCmd(e);
        int num12 = 0;
        if (num10 >= 1)
        {
          camTpPoint camTpPoint = new camTpPoint();
          foreach (TPSection section in slice.Sections)
          {
            ++num12;
            ToolPathLinkType toolPathLinkType = ToolPathLinkType.NotALink;
            bool flag1;
            bool flag2;
            if (section is TPContour)
            {
              ++num2;
              flag1 = true;
              flag2 = false;
            }
            else
            {
              ++num3;
              flag1 = false;
              flag2 = true;
              toolPathLinkType = (section as TPLink).LinkType;
            }
            List<ICurve> curveList = new List<ICurve>();
            int num13 = 0;
            foreach (TPSectionFit sectionFit in section.SectionFits)
            {
              ++num13;
              TPHelixFit tpHelixFit = sectionFit as TPHelixFit;
              bool flag3 = false;
              if (tpHelixFit != null && !buCompare.EQ(tpHelixFit.Helix.StartPoint.Z, tpHelixFit.Helix.EndPoint.Z))
                flag3 = true;
              if (AllG1)
                flag3 = true;
              if (tpHelixFit != null & !flag3)
              {
                ++num5;
                if (tpHelixFit.Helix.ArcSweep <= 2.8015926535897933)
                {
                  TpPnt9D tpPnt9D = new TpPnt9D();
                  tpPnt9D.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D.IsArc = true;
                  this.HelixToArcData(tpHelixFit.Helix, ref tpPnt9D.ArcData);
                  tpPnt9D.P9 = new Pnt9D(tpHelixFit.Helix.EndPoint.X, tpHelixFit.Helix.EndPoint.Y, tpHelixFit.Helix.EndPoint.Z);
                  buArcCam another = new buArcCam(Plane.XY, tpPnt9D.ArcData.CenterPoint, tpPnt9D.ArcData.Radius, tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.EndPoint, false);
                  another.MoveType = CamMoveType.G1;
                  another.CamID = CamID;
                  another.Color = clsVar.varCam.CamG1Draw.Color;
                  another.ColorMethod = colorMethodType.byEntity;
                  another.Regen(new RegenParams(0.001));
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    tpPnt9D.ArcData.isCW = false;
                    tpPnt9D.Type = 3;
                  }
                  else
                  {
                    tpPnt9D.ArcData.isCW = true;
                    tpPnt9D.Type = 2;
                  }
                  if (!buCompare5.EQ(new Point3D(camTpPoint.Points[camTpPoint.Points.Count - 1].P9.X, camTpPoint.Points[camTpPoint.Points.Count - 1].P9.Y, camTpPoint.Points[camTpPoint.Points.Count - 1].P9.Z), another.StartPoint))
                    another.isReverse = true;
                  camTpPoint.Points.Add(tpPnt9D);
                  if (flag1)
                  {
                    if (CamResult.EntitiesG1Orj.Count > 0)
                    {
                      Point3D point3D2 = new Point3D();
                      if (!buCompare5.EQ(!(CamResult.EntitiesG1Orj[CamResult.EntitiesG1Orj.Count - 1] is buArcCam) ? buVector5.ToPoint3D(((ICurve) CamResult.EntitiesG1Orj[CamResult.EntitiesG1Orj.Count - 1]).EndPoint) : (((buArcCam) CamResult.EntitiesG1Orj[CamResult.EntitiesG1Orj.Count - 1]).isReverse ? buVector5.ToPoint3D(((ICurve) CamResult.EntitiesG1Orj[CamResult.EntitiesG1Orj.Count - 1]).StartPoint) : buVector5.ToPoint3D(((ICurve) CamResult.EntitiesG1Orj[CamResult.EntitiesG1Orj.Count - 1]).EndPoint)), another.StartPoint))
                        another.isReverse = true;
                    }
                    CamResult.EntitiesG1Orj.Add((Entity) new buArcCam((Arc) another));
                    List<Point3D> points = new List<Point3D>();
                    for (int index = 0; index <= another.Vertices.Length - 1; ++index)
                      points.Add(new Point3D(another.Vertices[index].X, another.Vertices[index].Y, another.Vertices[index].Z));
                    if (tpPnt9D.Type == 2)
                      points.Reverse();
                    if (points.Count > 1)
                    {
                      buLinearPathCam buLinearPathCam = new buLinearPathCam(points);
                      buLinearPathCam.MoveType = CamMoveType.G1;
                      buLinearPathCam.Color = clsVar.varCam.CamG1Draw.Color;
                      buLinearPathCam.CamID = CamID;
                      buLinearPathCam.isLink = flag2;
                      buLinearPathCam.LinkType = (CamLinkType) Convert.ToInt32((object) toolPathLinkType);
                      curveList.Add((ICurve) buLinearPathCam);
                    }
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) another);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) another);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) another);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) another);
                  }
                  point3D1 = new Point3D(tpHelixFit.Helix.EndPoint.X, tpHelixFit.Helix.EndPoint.Y, tpHelixFit.Helix.EndPoint.Z);
                  point3DList.Clear();
                  point3DList.Add(point3D1);
                }
                else
                {
                  Arc Arc1 = (Arc) null;
                  Arc Arc2 = (Arc) null;
                  this.HelixToSplitedArcs(tpHelixFit.Helix, ref Arc1, ref Arc2);
                  TpPnt9D tpPnt9D1 = new TpPnt9D();
                  tpPnt9D1.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D1.IsArc = true;
                  this.ArcToArcData(Arc1, ref tpPnt9D1.ArcData);
                  bool flag4;
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    flag4 = false;
                    tpPnt9D1.P9 = new Pnt9D(Arc1.EndPoint.X, Arc1.EndPoint.Y, Arc1.EndPoint.Z);
                    tpPnt9D1.ArcData.isCW = false;
                    tpPnt9D1.Type = 3;
                    tpPnt9D1.ArcData.isReverse = false;
                  }
                  else
                  {
                    flag4 = true;
                    tpPnt9D1.P9 = new Pnt9D(Arc1.StartPoint.X, Arc1.StartPoint.Y, Arc1.StartPoint.Z);
                    tpPnt9D1.ArcData.isReverse = true;
                    tpPnt9D1.ArcData.isCW = true;
                    tpPnt9D1.Type = 2;
                  }
                  buArcCam another1 = new buArcCam(Plane.XY, tpPnt9D1.ArcData.CenterPoint, tpPnt9D1.ArcData.Radius, tpPnt9D1.ArcData.StartPoint, tpPnt9D1.ArcData.EndPoint, false);
                  another1.isReverse = tpPnt9D1.ArcData.isReverse;
                  another1.MoveType = CamMoveType.G1;
                  another1.CamID = CamID;
                  another1.Color = clsVar.varCam.CamG1Draw.Color;
                  another1.ColorMethod = colorMethodType.byEntity;
                  another1.Regen(new RegenParams(0.01));
                  if (flag4)
                  {
                    tpPnt9D1.ArcData.isCW = true;
                    tpPnt9D1.Type = 2;
                  }
                  else
                  {
                    tpPnt9D1.ArcData.isCW = false;
                    tpPnt9D1.Type = 3;
                  }
                  camTpPoint.Points.Add(tpPnt9D1);
                  if (flag1)
                  {
                    CamResult.EntitiesG1Orj.Add((Entity) new buArcCam((Arc) another1));
                    curveList.Add((ICurve) another1);
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) another1);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) another1);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) another1);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) another1);
                  }
                  TpPnt9D tpPnt9D2 = new TpPnt9D();
                  tpPnt9D2.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D2.IsArc = true;
                  this.ArcToArcData(Arc2, ref tpPnt9D2.ArcData);
                  bool flag5;
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    flag5 = false;
                    tpPnt9D2.P9 = new Pnt9D(Arc2.EndPoint.X, Arc2.EndPoint.Y, Arc2.EndPoint.Z);
                    tpPnt9D2.ArcData.isCW = false;
                    tpPnt9D2.Type = 3;
                    tpPnt9D2.ArcData.isReverse = false;
                  }
                  else
                  {
                    flag5 = true;
                    tpPnt9D2.P9 = new Pnt9D(Arc2.StartPoint.X, Arc2.StartPoint.Y, Arc2.StartPoint.Z);
                    tpPnt9D2.ArcData.isReverse = true;
                    tpPnt9D2.ArcData.isCW = true;
                    tpPnt9D2.Type = 2;
                  }
                  buArcCam another2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, false);
                  another2.isReverse = tpPnt9D2.ArcData.isReverse;
                  another2.MoveType = CamMoveType.G1;
                  another2.CamID = CamID;
                  another2.Color = clsVar.varCam.CamG1Draw.Color;
                  another2.ColorMethod = colorMethodType.byEntity;
                  another2.Regen(new RegenParams(0.01));
                  if (flag5)
                  {
                    tpPnt9D2.ArcData.isCW = true;
                    tpPnt9D2.Type = 2;
                  }
                  else
                  {
                    tpPnt9D2.ArcData.isCW = false;
                    tpPnt9D2.Type = 3;
                  }
                  camTpPoint.Points.Add(tpPnt9D2);
                  if (flag1)
                  {
                    CamResult.EntitiesG1Orj.Add((Entity) new buArcCam((Arc) another2));
                    curveList.Add((ICurve) another2);
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) another2);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) another2);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) another2);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) another2);
                  }
                  point3D1 = tpHelixFit.Helix.CenterOrientation.Z <= 0.0 ? buVector5.ToPoint3D(tpPnt9D2.ArcData.StartPoint) : buVector5.ToPoint3D(tpPnt9D2.ArcData.EndPoint);
                  point3DList.Clear();
                  point3DList.Add(point3D1);
                }
              }
              else
              {
                ++num4;
                foreach (CNCMove move in sectionFit.Moves)
                {
                  ++num6;
                  if (move is CNC5AxMove mwCNC5AxMove)
                  {
                    TpPnt9D tpPnt9D = new TpPnt9D();
                    tpPnt9D.P9 = new Pnt9D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z);
                    tpPnt9D.Type = !mwCNC5AxMove.IsRapid ? 1 : 0;
                    tpPnt9D.Feed = mwCNC5AxMove.FeedRate;
                    point3DList.Add(new Point3D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z));
                    if (!flag1 & point3DList.Count > 1)
                    {
                      CamMoveType MoveType = CamMoveType.G0;
                      this.GetCamMoveType(point3DList, CamResult.OperationVector, mwCNC5AxMove, ref MoveType);
                      buLinearPathCam another = new buLinearPathCam(point3DList);
                      another.CamID = CamID;
                      another.MoveType = MoveType;
                      another.ColorMethod = colorMethodType.byEntity;
                      another.isLink = flag2;
                      another.LinkType = (CamLinkType) Convert.ToInt32((object) toolPathLinkType);
                      switch (MoveType)
                      {
                        case CamMoveType.G0:
                          another.Color = clsVar.varCam.CamG0Draw.Color;
                          CamResult.EntitiesG0.Add((Entity) another);
                          break;
                        case CamMoveType.G1:
                          if (flag2)
                          {
                            if (clsInit.cMwCalc.SettingsRuntime.CamLinkEntitiesAsG1)
                            {
                              another.Color = clsVar.varCam.CamG1Draw.Color;
                              CamResult.EntitiesG1.Add((Entity) another);
                              CamResult.EntitiesG1Orj.Add((Entity) new buLinearPathCam((LinearPath) another));
                              break;
                            }
                            break;
                          }
                          another.Color = clsVar.varCam.CamG1Draw.Color;
                          CamResult.EntitiesG1.Add((Entity) another);
                          CamResult.EntitiesG1Orj.Add((Entity) new buLinearPathCam((LinearPath) another));
                          break;
                        case CamMoveType.Plunge:
                          tpPnt9D.PlungeAxisMovement = true;
                          another.Color = clsVar.varCam.CamPlungeDraw.Color;
                          CamResult.EntitiesPlunge.Add((Entity) another);
                          break;
                        case CamMoveType.Leave:
                          tpPnt9D.LeaveAxisMovement = true;
                          another.Color = clsVar.varCam.CamLeaveDraw.Color;
                          CamResult.EntitiesLeave.Add((Entity) another);
                          break;
                        default:
                          another.Color = clsVar.varCam.CamOtherDraw.Color;
                          CamResult.EntitiesOther.Add((Entity) another);
                          break;
                      }
                      point3D1 = buVector5.ToPoint3D(point3DList[point3DList.Count - 1]);
                      point3DList.Clear();
                      point3DList.Add(point3D1);
                    }
                    if (flag1 & tpPnt9D.Type == 1 && camTpPoint.Points.Count > 0)
                    {
                      buLinearPathCam buLinearPathCam = new buLinearPathCam(new List<Point3D>()
                      {
                        new Point3D(camTpPoint.Points[camTpPoint.Points.Count - 1].P9.X, camTpPoint.Points[camTpPoint.Points.Count - 1].P9.Y, camTpPoint.Points[camTpPoint.Points.Count - 1].P9.Z),
                        new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z)
                      });
                      buLinearPathCam.CamID = CamID;
                      buLinearPathCam.MoveType = CamMoveType.G1;
                      buLinearPathCam.ColorMethod = colorMethodType.byEntity;
                      buLinearPathCam.isLink = flag2;
                      buLinearPathCam.LinkType = (CamLinkType) Convert.ToInt32((object) toolPathLinkType);
                      buLinearPathCam.Color = clsVar.varCam.CamG1Draw.Color;
                      CamResult.EntitiesG1Orj.Add((Entity) buLinearPathCam);
                    }
                    camTpPoint.Points.Add(tpPnt9D);
                    ++num7;
                  }
                }
                if (point3DList.Count > 0)
                  point3D1 = buVector5.ToPoint3D(point3DList[point3DList.Count - 1]);
              }
              if (point3DList.Count > 1)
              {
                if (flag1)
                {
                  if (point3DList.Count > 1)
                  {
                    buLinearPathCam buLinearPathCam = new buLinearPathCam(point3DList);
                    buLinearPathCam.MoveType = CamMoveType.G1;
                    buLinearPathCam.Color = clsVar.varCam.CamG1Draw.Color;
                    buLinearPathCam.CamID = CamID;
                    buLinearPathCam.isLink = flag2;
                    buLinearPathCam.LinkType = (CamLinkType) Convert.ToInt32((object) toolPathLinkType);
                    curveList.Add((ICurve) buLinearPathCam);
                  }
                }
                else if (point3DList.Count > 1)
                  CamResult.EntitiesG0.Add((Entity) new buLinearPathCam(point3DList)
                  {
                    CamID = CamID,
                    isLink = flag2,
                    LinkType = (CamLinkType) Convert.ToInt32((object) toolPathLinkType)
                  });
                point3DList.Clear();
                point3DList.Add(point3D1);
              }
            }
            if (curveList.Count > 0)
            {
              List<Point3D> points = new List<Point3D>();
              for (int index1 = 0; index1 <= curveList.Count - 1; ++index1)
              {
                Entity entity = (Entity) curveList[index1];
                List<Point3D> PointList = new List<Point3D>();
                buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
                if (entity.GetType() == typeof (buArcCam) && ((buArcCam) entity).isReverse)
                  PointList.Reverse();
                int num14 = 0;
                if (index1 > 0)
                  num14 = 1;
                for (int index2 = num14; index2 <= PointList.Count - 1; ++index2)
                  points.Add(new Point3D(PointList[index2].X, PointList[index2].Y, PointList[index2].Z));
              }
              if (points.Count > 1)
              {
                buLinearPathCam buLinearPathCam = new buLinearPathCam(points);
                buLinearPathCam.CamID = CamID;
                buLinearPathCam.MoveType = CamMoveType.G1;
                buLinearPathCam.Color = clsVar.varCam.CamG1Draw.Color;
                buLinearPathCam.isLink = flag2;
                buLinearPathCam.LinkType = (CamLinkType) Convert.ToInt32((object) toolPathLinkType);
                CamResult.EntitiesG1.Add((Entity) buLinearPathCam);
              }
              curveList.Clear();
            }
            ++num8;
          }
          if (camTpPoint.Points.Count > 0)
            CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint.Points[0]));
          for (int index3 = 1; index3 <= camTpPoint.Points.Count - 1; ++index3)
          {
            List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
            double num15 = clsInit.cVector.Length3D(new Pnt3D(camTpPoint.Points[index3 - 1].P9.X, camTpPoint.Points[index3 - 1].P9.Y, camTpPoint.Points[index3 - 1].P9.Z), new Pnt3D(camTpPoint.Points[index3].P9.X, camTpPoint.Points[index3].P9.Y, camTpPoint.Points[index3].P9.Z));
            if (camTpPoint.Points[index3].Type == 0)
            {
              int int32 = Convert.ToInt32(num15 / camPars.Runtime.SimG0DevideLength);
              clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3 - 1]), TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]), int32, ref CalculatedPoints);
            }
            else if (camTpPoint.Points[index3].Type == 1)
            {
              int int32 = Convert.ToInt32(num15 / camPars.Runtime.SimG1DevideLength);
              clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3 - 1]), TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]), int32, ref CalculatedPoints);
            }
            else if (camTpPoint.Points[index3].Type == 2 | camTpPoint.Points[index3].Type == 3)
            {
              double length = camTpPoint.Points[index3].ArcData.Length;
              new Arc(Plane.XY, camTpPoint.Points[index3].ArcData.CenterPoint, camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartPoint, camTpPoint.Points[index3].ArcData.EndPoint, false).Regen(0.01);
              List<Pnt3D> Vertices = new List<Pnt3D>();
              if (!camTpPoint.Points[index3].ArcData.isReverse)
              {
                clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint.Points[index3].ArcData.CenterPoint), camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartAngle, camTpPoint.Points[index3].ArcData.EndAngle, camPars.Runtime.SimG1DevideLength, new WorkPlane(), ref Vertices);
              }
              else
              {
                clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint.Points[index3].ArcData.CenterPoint), camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartAngle, camTpPoint.Points[index3].ArcData.EndAngle, camPars.Runtime.SimG1DevideLength, new WorkPlane(), ref Vertices);
                Vertices.Reverse();
              }
              if (Vertices.Count > 0)
              {
                for (int index4 = 0; index4 <= Vertices.Count - 1; ++index4)
                {
                  Pnt6DSimMove pnt6DsimMove = new Pnt6DSimMove(Vertices[index4].X, Vertices[index4].Y, Vertices[index4].Z);
                  CalculatedPoints.Add(pnt6DsimMove);
                }
              }
            }
            if (CalculatedPoints.Count >= 2)
            {
              CalculatedPoints.RemoveAt(0);
              CamResult.SimilationPoint.SimMove.AddRange((IEnumerable<Pnt6DSimMove>) CalculatedPoints);
            }
            else
              CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]));
          }
          CamResult.CamID = CamID;
          CamResult.CamPoints.Add(camTpPoint);
        }
      }
    }
  }

  public void IterateThroughEntireStructure4X(
    ToolPath calculatedToolPath,
    int CamID,
    camParameters5 camPars,
    GeoLib mwPars,
    ref camTp CamResult)
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    int num5 = 0;
    int num6 = 0;
    double c1 = 0.0;
    Point3D point3D = new Point3D();
    Point3D BasePoint = new Point3D();
    CamResult = new camTp();
    CalculationEventArg e = new CalculationEventArg();
    List<Point3D> point3DList = new List<Point3D>();
    foreach (TPPass pass in calculatedToolPath.Passes)
    {
      ++num1;
      double num7 = (double) num1 / (double) calculatedToolPath.Passes.Count<TPPass>();
      if (num7 > 1.0)
        num7 = 1.0;
      Application.DoEvents();
      e.OverallProgressPercentage = num7 * 100.0;
      int num8 = 0;
      foreach (TPSlice slice in pass.Slices)
      {
        ++num8;
        double num9 = Convert.ToDouble(num8) / (double) pass.Slices.Count<TPSlice>();
        if (num9 > 1.0)
          num9 = 1.0;
        e.ActiveProgressPercentage = num9 * 100.0;
        e.Job = "Iteration";
        e.ShowForm = clsInit.cMwCalc.Settings.ShowProgressForm;
        clsInit.appCommand.CalculationInProgressCmd(e);
        double num10 = 0.0;
        ToolPathLinkType toolPathLinkType = ToolPathLinkType.NotALink;
        int Index = 0;
        if (num8 >= 0)
        {
          camTpPoint camTpPoint = new camTpPoint();
          MWIterationOption Option = new MWIterationOption();
          List<Pnt6D> P6 = new List<Pnt6D>();
          foreach (TPSection section in slice.Sections)
          {
            bool flag1;
            if (section is TPContour)
            {
              ++num2;
              flag1 = true;
            }
            else
            {
              if (this.GetNextSectionOfTP(slice.Sections, Index, ref Option, ref P6) == 1)
                num10 = Option.StartPoint.C;
              ++num3;
              flag1 = false;
              toolPathLinkType = (section as TPLink).LinkType;
            }
            List<ICurve> curveList = new List<ICurve>();
            foreach (TPSectionFit sectionFit in section.SectionFits)
            {
              TPHelixFit tpHelixFit = sectionFit as TPHelixFit;
              bool flag2 = false;
              if (tpHelixFit != null && !buCompare.EQ(tpHelixFit.Helix.StartPoint.Z, tpHelixFit.Helix.EndPoint.Z))
                flag2 = true;
              if (tpHelixFit != null & !flag2 & !camPars.Strategy.ArcToPoints)
              {
                ++num5;
                TpPnt9D tpPnt9D = new TpPnt9D();
                List<Pnt3D> pnt3DList = new List<Pnt3D>();
                tpPnt9D.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                tpPnt9D.IsArc = true;
                tpPnt9D.ArcData.StartPoint = new Point3D(tpHelixFit.Helix.StartPoint.X, tpHelixFit.Helix.StartPoint.Y, tpHelixFit.Helix.StartPoint.Z);
                tpPnt9D.ArcData.EndPoint = new Point3D(tpHelixFit.Helix.EndPoint.X, tpHelixFit.Helix.EndPoint.Y, tpHelixFit.Helix.EndPoint.Z);
                tpPnt9D.ArcData.CenterPoint = new Point3D(tpHelixFit.Helix.CenterPoint.X, tpHelixFit.Helix.CenterPoint.Y, tpHelixFit.Helix.CenterPoint.Z);
                tpPnt9D.ArcData.SweepAngle = tpHelixFit.Helix.ArcSweep;
                tpPnt9D.ArcData.Radius = Point3D.Distance(tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.CenterPoint);
                tpPnt9D.ArcData.Length = tpHelixFit.Helix.ArcSweep * tpPnt9D.ArcData.Radius;
                tpPnt9D.ArcData.StartAngle = clsInit.cVector5.PointAngle(tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.CenterPoint, Plane.XY);
                tpPnt9D.ArcData.EndAngle = clsInit.cVector5.PointAngle(tpPnt9D.ArcData.EndPoint, tpPnt9D.ArcData.CenterPoint, Plane.XY);
                tpPnt9D.P9 = new Pnt9D(tpHelixFit.Helix.EndPoint.X, tpHelixFit.Helix.EndPoint.Y, tpHelixFit.Helix.EndPoint.Z);
                buArcCam buArcCam = new buArcCam(new Plane(new Vector3D(tpHelixFit.Helix.CenterOrientation.X, tpHelixFit.Helix.CenterOrientation.Y, tpHelixFit.Helix.CenterOrientation.Z)), tpPnt9D.ArcData.CenterPoint, tpPnt9D.ArcData.Radius, tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.EndPoint, false);
                buArcCam.MoveType = CamMoveType.G1;
                buArcCam.CamID = CamID;
                buArcCam.Color = clsVar.varCam.CamG1Draw.Color;
                buArcCam.ColorMethod = colorMethodType.byEntity;
                buArcCam.Regen(new RegenParams(0.01));
                if (Utility.IsOrientedClockwise<Point3D>((IList<Point3D>) buArcCam.Vertices))
                {
                  if (tpPnt9D.ArcData.EndAngle > tpPnt9D.ArcData.StartAngle)
                    tpPnt9D.ArcData.EndAngle -= 360.0;
                  tpPnt9D.ArcData.isCW = true;
                  tpPnt9D.Type = 2;
                }
                else
                {
                  if (tpPnt9D.ArcData.StartAngle > tpPnt9D.ArcData.EndAngle)
                    tpPnt9D.ArcData.StartAngle -= 360.0;
                  tpPnt9D.ArcData.isCW = false;
                  tpPnt9D.Type = 3;
                }
                camTpPoint.Points.Add(tpPnt9D);
                if (flag1)
                {
                  curveList.Add((ICurve) buArcCam);
                }
                else
                {
                  if (toolPathLinkType == ToolPathLinkType.LeadIn)
                    CamResult.EntitiesLeadIn.Add((Entity) buArcCam);
                  if (toolPathLinkType == ToolPathLinkType.LeadOut)
                    CamResult.EntitiesLeadOut.Add((Entity) buArcCam);
                  if (toolPathLinkType == ToolPathLinkType.Approach)
                    CamResult.EntitiesPlunge.Add((Entity) buArcCam);
                  if (toolPathLinkType == ToolPathLinkType.Retract)
                    CamResult.EntitiesLeave.Add((Entity) buArcCam);
                }
                point3D = buVector5.ToPoint3D(tpPnt9D.ArcData.EndPoint);
                point3DList.Clear();
                point3DList.Add(point3D);
              }
              else
              {
                ++num4;
                int num11 = 0;
                int num12 = 0;
                foreach (CNCMove move in sectionFit.Moves)
                {
                  CNC5AxMove mwCNC5AxMove = move as CNC5AxMove;
                  double num13 = 0.0;
                  if (mwCNC5AxMove != null)
                  {
                    TpPnt9D tpPnt9D1 = new TpPnt9D();
                    if (camTpPoint.Points.Count == 0 & !flag1)
                    {
                      tpPnt9D1.P9 = new Pnt9D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z);
                      tpPnt9D1.Type = 0;
                      tpPnt9D1.PlungeAxisMovement = true;
                      tpPnt9D1.PlungeAction = CamPlungeActionType.GoUp;
                      camTpPoint.Points.Add(tpPnt9D1);
                    }
                    if (!flag1)
                    {
                      if (toolPathLinkType == ToolPathLinkType.Approach | toolPathLinkType == ToolPathLinkType.ConnectionNotClearanceArea | toolPathLinkType == ToolPathLinkType.ConnectionClearanceArea)
                        num13 = num10;
                      if (toolPathLinkType == ToolPathLinkType.Retract)
                        num13 = c1;
                    }
                    else
                      num13 = clsInit.cVector5.PointAngle(new Point3D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z), BasePoint, Plane.XY);
                    double c2 = camPars.Strategy.UseContantTangent ? camPars.Strategy.ContantTangent : num13 + camPars.Strategy.TangentOffset;
                    if (flag1)
                    {
                      double num14 = c2 - c1;
                      double num15 = Math.Ceiling(Math.Abs(num14) / 360.0);
                      if (Math.Abs(num14) > 180.0)
                      {
                        if (num14 > 0.0)
                          c2 -= 360.0 * num15;
                        else
                          c2 += 360.0 * num15;
                      }
                      if (c2 > camPars.Strategy.MaxTangentValue)
                      {
                        if (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue >= 360.0)
                          c2 -= 360.0;
                        else
                          c2 -= camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
                      }
                      if (c2 < camPars.Strategy.MinTangentValue)
                      {
                        if (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue >= 360.0)
                          c2 += 360.0;
                        else
                          c2 += camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
                      }
                      if (Math.Abs(c2 - c1) > camPars.Strategy.AngleLimit & camPars.Strategy.UseTangentLimit)
                      {
                        camTpPoint.Points.Add(new TpPnt9D()
                        {
                          P9 = new Pnt9D(BasePoint.X, BasePoint.Y, BasePoint.Z + mwPars.MachParam.LinkParams.RetractPlaneIncremental, 0.0, 0.0, c1),
                          Type = 1,
                          Feed = mwPars.MachParam.RetractFeedRate,
                          PlungeAxisMovement = true,
                          PlungeAction = CamPlungeActionType.GoUp
                        });
                        camTpPoint.Points.Add(new TpPnt9D()
                        {
                          P9 = new Pnt9D(BasePoint.X, BasePoint.Y, BasePoint.Z + mwPars.MachParam.LinkParams.RetractPlaneIncremental, 0.0, 0.0, c2),
                          Type = 0,
                          Feed = mwPars.MachParam.RapidFeedrate,
                          PlungeAxisMovement = false
                        });
                        camTpPoint.Points.Add(new TpPnt9D()
                        {
                          P9 = new Pnt9D(BasePoint.X, BasePoint.Y, BasePoint.Z, 0.0, 0.0, c2),
                          Type = 1,
                          Feed = mwPars.MachParam.PlungeFeedRate,
                          PlungeAxisMovement = true,
                          PlungeAction = CamPlungeActionType.GoDownAproach
                        });
                      }
                    }
                    if (c2 > camPars.Strategy.MaxTangentValue & Math.Abs(camPars.Strategy.MinTangentValue - camPars.Strategy.MaxTangentValue) > 0.001)
                    {
                      if (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue > 360.0)
                        c2 -= 360.0;
                      else
                        c2 -= 180.0;
                    }
                    if (c2 < camPars.Strategy.MinTangentValue & Math.Abs(camPars.Strategy.MinTangentValue - camPars.Strategy.MaxTangentValue) > 0.001)
                    {
                      if (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue > 360.0)
                        c2 += 360.0;
                      else
                        c2 += 180.0;
                    }
                    TpPnt9D tpPnt9D2 = new TpPnt9D();
                    tpPnt9D2.P9 = new Pnt9D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z, 0.0, 0.0, Math.Round(c2, 5));
                    tpPnt9D2.Type = !mwCNC5AxMove.IsRapid ? 1 : 0;
                    tpPnt9D2.Feed = mwCNC5AxMove.FeedRate;
                    point3DList.Add(new Point3D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z));
                    if (!flag1 & point3DList.Count > 1)
                    {
                      CamMoveType MoveType = CamMoveType.G0;
                      this.GetCamMoveType(point3DList, CamResult.OperationVector, mwCNC5AxMove, ref MoveType);
                      buLinearPathCam buLinearPathCam = new buLinearPathCam(point3DList);
                      buLinearPathCam.CamID = CamID;
                      buLinearPathCam.MoveType = MoveType;
                      buLinearPathCam.ColorMethod = colorMethodType.byEntity;
                      switch (MoveType)
                      {
                        case CamMoveType.G0:
                          buLinearPathCam.Color = clsVar.varCam.CamG0Draw.Color;
                          CamResult.EntitiesG0.Add((Entity) buLinearPathCam);
                          break;
                        case CamMoveType.Plunge:
                          buLinearPathCam.Color = clsVar.varCam.CamPlungeDraw.Color;
                          CamResult.EntitiesPlunge.Add((Entity) buLinearPathCam);
                          break;
                        case CamMoveType.Leave:
                          buLinearPathCam.Color = clsVar.varCam.CamLeaveDraw.Color;
                          CamResult.EntitiesLeave.Add((Entity) buLinearPathCam);
                          break;
                        default:
                          buLinearPathCam.Color = clsVar.varCam.CamOtherDraw.Color;
                          CamResult.EntitiesOther.Add((Entity) buLinearPathCam);
                          break;
                      }
                      point3D = buVector5.ToPoint3D(point3DList[point3DList.Count - 1]);
                      point3DList.Clear();
                      point3DList.Add(point3D);
                    }
                    camTpPoint.Points.Add(tpPnt9D2);
                    BasePoint = new Point3D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z);
                    c1 = c2;
                    ++num12;
                  }
                  ++num11;
                }
                if (point3DList.Count > 0)
                  point3D = buVector5.ToPoint3D(point3DList[point3DList.Count - 1]);
              }
              if (point3DList.Count > 1)
              {
                if (flag1)
                {
                  if (point3DList.Count > 1)
                  {
                    buLinearPathCam buLinearPathCam = new buLinearPathCam(point3DList);
                    buLinearPathCam.MoveType = CamMoveType.G1;
                    buLinearPathCam.Color = clsVar.varCam.CamG1Draw.Color;
                    buLinearPathCam.CamID = CamID;
                    curveList.Add((ICurve) buLinearPathCam);
                  }
                }
                else if (point3DList.Count > 1)
                  CamResult.EntitiesG0.Add((Entity) new buLinearPathCam(point3DList)
                  {
                    CamID = CamID
                  });
                point3DList.Clear();
                point3DList.Add(point3D);
              }
            }
            if (curveList.Count > 0)
            {
              buCompositeCurveCam compositeCurveCam = new buCompositeCurveCam((IEnumerable<ICurve>) curveList);
              compositeCurveCam.CamID = CamID;
              compositeCurveCam.MoveType = CamMoveType.G1;
              compositeCurveCam.Color = clsVar.varCam.CamG1Draw.Color;
              CamResult.EntitiesG1.Add((Entity) compositeCurveCam);
              curveList.Clear();
            }
            ++num6;
            ++Index;
          }
          if (camTpPoint.Points.Count > 0)
            CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint.Points[0]));
          for (int index1 = 1; index1 <= camTpPoint.Points.Count - 1; ++index1)
          {
            List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
            double num16 = clsInit.cVector.Length3D(new Pnt3D(camTpPoint.Points[index1 - 1].P9.X, camTpPoint.Points[index1 - 1].P9.Y, camTpPoint.Points[index1 - 1].P9.Z), new Pnt3D(camTpPoint.Points[index1].P9.X, camTpPoint.Points[index1].P9.Y, camTpPoint.Points[index1].P9.Z));
            if (camTpPoint.Points[index1].Type == 0)
            {
              int int32 = Convert.ToInt32(num16 / 5.0);
              clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index1 - 1]), TpPnt9D.ToPnt6DSim(camTpPoint.Points[index1]), int32, ref CalculatedPoints);
            }
            else if (camTpPoint.Points[index1].Type == 1)
            {
              int int32 = Convert.ToInt32(num16 / 1.0);
              clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index1 - 1]), TpPnt9D.ToPnt6DSim(camTpPoint.Points[index1]), int32, ref CalculatedPoints);
            }
            else if (camTpPoint.Points[index1].Type == 2 | camTpPoint.Points[index1].Type == 3)
            {
              double length = camTpPoint.Points[index1].ArcData.Length;
              new Arc(Plane.XY, camTpPoint.Points[index1].ArcData.CenterPoint, camTpPoint.Points[index1].ArcData.Radius, camTpPoint.Points[index1].ArcData.StartPoint, camTpPoint.Points[index1].ArcData.EndPoint, false).Regen(0.01);
              List<Pnt3D> Vertices = new List<Pnt3D>();
              if (!camTpPoint.Points[index1].ArcData.isCW)
              {
                clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint.Points[index1].ArcData.CenterPoint), camTpPoint.Points[index1].ArcData.Radius, camTpPoint.Points[index1].ArcData.StartAngle, camTpPoint.Points[index1].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
              }
              else
              {
                clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint.Points[index1].ArcData.CenterPoint), camTpPoint.Points[index1].ArcData.Radius, camTpPoint.Points[index1].ArcData.EndAngle, camTpPoint.Points[index1].ArcData.StartAngle, 1.0, new WorkPlane(), ref Vertices);
                Vertices.Reverse();
              }
              if (Vertices.Count > 0)
              {
                for (int index2 = 0; index2 <= Vertices.Count - 1; ++index2)
                {
                  Pnt6DSimMove pnt6DsimMove = new Pnt6DSimMove(Vertices[index2].X, Vertices[index2].Y, Vertices[index2].Z);
                  CalculatedPoints.Add(pnt6DsimMove);
                }
              }
            }
            if (CalculatedPoints.Count >= 2)
            {
              CalculatedPoints.RemoveAt(0);
              CamResult.SimilationPoint.SimMove.AddRange((IEnumerable<Pnt6DSimMove>) CalculatedPoints);
            }
            else
              CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index1]));
          }
          CamResult.CamID = CamID;
          CamResult.CamPoints.Add(camTpPoint);
        }
      }
    }
  }

  public void IterateThroughEntireStructure4XVectorX(
    ToolPath calculatedToolPath,
    int CamID,
    camParameters5 camPars,
    GeoLib mwPars,
    ref camTp CamResult)
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    int num5 = 0;
    int num6 = 0;
    int num7 = 0;
    int num8 = 0;
    Point3D point3D1 = new Point3D();
    CamResult = new camTp();
    CalculationEventArg e = new CalculationEventArg();
    List<Point3D> point3DList = new List<Point3D>();
    foreach (TPPass pass in calculatedToolPath.Passes)
    {
      ++num1;
      double num9 = (double) num1 / (double) calculatedToolPath.Passes.Count<TPPass>();
      if (num9 > 1.0)
        num9 = 1.0;
      Application.DoEvents();
      e.OverallProgressPercentage = num9 * 100.0;
      int num10 = 0;
      foreach (TPSlice slice in pass.Slices)
      {
        ++num10;
        double num11 = Convert.ToDouble(num10) / (double) pass.Slices.Count<TPSlice>();
        if (num11 > 1.0)
          num11 = 1.0;
        e.ActiveProgressPercentage = num11 * 100.0;
        e.Job = "Iteration";
        e.ShowForm = clsInit.cMwCalc.Settings.ShowProgressForm;
        clsInit.appCommand.CalculationInProgressCmd(e);
        int num12 = 0;
        if (num10 >= 1)
        {
          camTpPoint camTpPoint = new camTpPoint();
          foreach (TPSection section in slice.Sections)
          {
            ++num12;
            bool flag1;
            if (section is TPContour)
            {
              ++num2;
              flag1 = true;
            }
            else
            {
              ++num3;
              flag1 = false;
              int linkType = (int) (section as TPLink).LinkType;
            }
            List<ICurve> curveList = new List<ICurve>();
            int num13 = 0;
            foreach (TPSectionFit sectionFit in section.SectionFits)
            {
              ++num13;
              TPHelixFit tpHelixFit = sectionFit as TPHelixFit;
              bool flag2 = false;
              if (tpHelixFit != null && !buCompare.EQ(tpHelixFit.Helix.StartPoint.Z, tpHelixFit.Helix.EndPoint.Z))
                flag2 = true;
              if (tpHelixFit != null & !flag2)
              {
                ++num5;
                if (tpHelixFit.Helix.ArcSweep <= 3.1315926535897933)
                {
                  TpPnt9D tpPnt9D = new TpPnt9D();
                  tpPnt9D.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D.IsArc = true;
                  this.HelixToArcData(tpHelixFit.Helix, ref tpPnt9D.ArcData);
                  tpPnt9D.P9 = new Pnt9D(tpHelixFit.Helix.EndPoint.X, tpHelixFit.Helix.EndPoint.Y, tpHelixFit.Helix.EndPoint.Z);
                  buArcCam buArcCam = new buArcCam(Plane.XY, tpPnt9D.ArcData.CenterPoint, tpPnt9D.ArcData.Radius, tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.EndPoint, false);
                  buArcCam.MoveType = CamMoveType.G1;
                  buArcCam.CamID = CamID;
                  buArcCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                  buArcCam.ColorMethod = colorMethodType.byEntity;
                  buArcCam.Regen(new RegenParams(0.001));
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    tpPnt9D.ArcData.isCW = false;
                    tpPnt9D.Type = 3;
                  }
                  else
                  {
                    tpPnt9D.ArcData.isCW = true;
                    tpPnt9D.Type = 2;
                  }
                  camTpPoint.Points.Add(tpPnt9D);
                  if (flag1)
                  {
                    List<Point3D> points = new List<Point3D>();
                    for (int index = 0; index <= buArcCam.Vertices.Length - 1; ++index)
                      points.Add(new Point3D(buArcCam.Vertices[index].X, buArcCam.Vertices[index].Y, buArcCam.Vertices[index].Z));
                    if (tpPnt9D.Type == 2)
                      points.Reverse();
                    if (points.Count > 1)
                    {
                      buLinearPathCam buLinearPathCam = new buLinearPathCam(points);
                      buLinearPathCam.MoveType = CamMoveType.G1;
                      buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                      buLinearPathCam.CamID = CamID;
                      curveList.Add((ICurve) buLinearPathCam);
                    }
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) buArcCam);
                  }
                  point3D1 = new Point3D(tpHelixFit.Helix.EndPoint.X, tpHelixFit.Helix.EndPoint.Y, tpHelixFit.Helix.EndPoint.Z);
                  point3DList.Clear();
                  point3DList.Add(point3D1);
                }
                else
                {
                  Arc Arc1 = (Arc) null;
                  Arc Arc2 = (Arc) null;
                  this.HelixToSplitedArcs(tpHelixFit.Helix, ref Arc1, ref Arc2);
                  TpPnt9D tpPnt9D1 = new TpPnt9D();
                  tpPnt9D1.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D1.IsArc = true;
                  this.ArcToArcData(Arc1, ref tpPnt9D1.ArcData);
                  bool flag3;
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    flag3 = false;
                    tpPnt9D1.P9 = new Pnt9D(Arc1.EndPoint.X, Arc1.EndPoint.Y, Arc1.EndPoint.Z);
                    tpPnt9D1.ArcData.isReverse = false;
                  }
                  else
                  {
                    tpPnt9D1.ArcData.isReverse = true;
                    flag3 = true;
                    tpPnt9D1.P9 = new Pnt9D(Arc1.StartPoint.X, Arc1.StartPoint.Y, Arc1.StartPoint.Z);
                    tpPnt9D1.ArcData.isReverse = true;
                  }
                  buArcCam buArcCam1 = new buArcCam(Plane.XY, tpPnt9D1.ArcData.CenterPoint, tpPnt9D1.ArcData.Radius, tpPnt9D1.ArcData.StartPoint, tpPnt9D1.ArcData.EndPoint, false);
                  buArcCam1.isReverse = tpPnt9D1.ArcData.isReverse;
                  buArcCam1.MoveType = CamMoveType.G1;
                  buArcCam1.CamID = CamID;
                  buArcCam1.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                  buArcCam1.ColorMethod = colorMethodType.byEntity;
                  buArcCam1.Regen(new RegenParams(0.01));
                  if (flag3)
                  {
                    tpPnt9D1.ArcData.isCW = true;
                    tpPnt9D1.Type = 2;
                  }
                  else
                  {
                    tpPnt9D1.ArcData.isCW = false;
                    tpPnt9D1.Type = 3;
                  }
                  camTpPoint.Points.Add(tpPnt9D1);
                  if (flag1)
                  {
                    curveList.Add((ICurve) buArcCam1);
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) buArcCam1);
                  }
                  TpPnt9D tpPnt9D2 = new TpPnt9D();
                  tpPnt9D2.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D2.IsArc = true;
                  this.ArcToArcData(Arc2, ref tpPnt9D2.ArcData);
                  bool flag4;
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    flag4 = false;
                    tpPnt9D2.P9 = new Pnt9D(Arc2.EndPoint.X, Arc2.EndPoint.Y, Arc2.EndPoint.Z);
                    tpPnt9D2.ArcData.isReverse = false;
                  }
                  else
                  {
                    flag4 = true;
                    tpPnt9D2.P9 = new Pnt9D(Arc2.StartPoint.X, Arc2.StartPoint.Y, Arc2.StartPoint.Z);
                    tpPnt9D2.ArcData.isReverse = true;
                  }
                  buArcCam buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, false);
                  buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
                  buArcCam2.MoveType = CamMoveType.G1;
                  buArcCam2.CamID = CamID;
                  buArcCam2.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                  buArcCam2.ColorMethod = colorMethodType.byEntity;
                  buArcCam2.Regen(new RegenParams(0.01));
                  if (flag4)
                  {
                    tpPnt9D2.ArcData.isCW = true;
                    tpPnt9D2.Type = 2;
                  }
                  else
                  {
                    tpPnt9D2.ArcData.isCW = false;
                    tpPnt9D2.Type = 3;
                  }
                  camTpPoint.Points.Add(tpPnt9D2);
                  if (flag1)
                  {
                    curveList.Add((ICurve) buArcCam2);
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) buArcCam2);
                  }
                  point3D1 = tpHelixFit.Helix.CenterOrientation.Z <= 0.0 ? buVector5.ToPoint3D(tpPnt9D2.ArcData.StartPoint) : buVector5.ToPoint3D(tpPnt9D2.ArcData.EndPoint);
                  point3DList.Clear();
                  point3DList.Add(point3D1);
                }
              }
              else
              {
                ++num4;
                foreach (CNCMove move in sectionFit.Moves)
                {
                  ++num6;
                  if (move is CNC5AxMove mwCNC5AxMove)
                  {
                    TpPnt9D tpPnt9D = new TpPnt9D();
                    tpPnt9D.P9 = new Pnt9D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z, mwCNC5AxMove.Orientation.X, mwCNC5AxMove.Orientation.Y, mwCNC5AxMove.Orientation.Z);
                    tpPnt9D.Type = !mwCNC5AxMove.IsRapid ? 1 : 0;
                    tpPnt9D.Feed = mwCNC5AxMove.FeedRate;
                    point3DList.Add(new Point3D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z));
                    if (!flag1 & point3DList.Count > 1)
                    {
                      CamMoveType MoveType = CamMoveType.G0;
                      this.GetCamMoveType(point3DList, CamResult.OperationVector, mwCNC5AxMove, ref MoveType);
                      buLinearPathCam buLinearPathCam = new buLinearPathCam(point3DList);
                      buLinearPathCam.CamID = CamID;
                      buLinearPathCam.MoveType = MoveType;
                      buLinearPathCam.ColorMethod = colorMethodType.byEntity;
                      switch (MoveType)
                      {
                        case CamMoveType.G0:
                          buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG0Draw.Color;
                          CamResult.EntitiesG0.Add((Entity) buLinearPathCam);
                          break;
                        case CamMoveType.Plunge:
                          if (buLinearPathCam.Vertices.Length == 2)
                          {
                            Vector3D vector3D = new Vector3D(mwCNC5AxMove.Orientation.X, mwCNC5AxMove.Orientation.Y, mwCNC5AxMove.Orientation.Z);
                            double num14 = buLinearPathCam.Length();
                            buLinearPathCam = new buLinearPathCam(new List<Point3D>()
                            {
                              new Point3D(buLinearPathCam.Vertices[1].X + vector3D.X * num14, buLinearPathCam.Vertices[1].Y + vector3D.Y * num14, buLinearPathCam.Vertices[1].Z + vector3D.Z * num14),
                              buVector5.ToPoint3D(buLinearPathCam.Vertices[1])
                            });
                          }
                          tpPnt9D.PlungeAxisMovement = true;
                          buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamPlungeDraw.Color;
                          CamResult.EntitiesPlunge.Add((Entity) buLinearPathCam);
                          break;
                        case CamMoveType.Leave:
                          if (buLinearPathCam.Vertices.Length == 2)
                          {
                            Vector3D vector3D = new Vector3D(mwCNC5AxMove.Orientation.X, mwCNC5AxMove.Orientation.Y, mwCNC5AxMove.Orientation.Z);
                            double num15 = buLinearPathCam.Length();
                            Point3D point3D2 = buVector5.ToPoint3D(buLinearPathCam.Vertices[0]);
                            Point3D point3D3 = new Point3D(point3D2.X + vector3D.X * num15, point3D2.Y + vector3D.Y * num15, point3D2.Z + vector3D.Z * num15);
                            buLinearPathCam = new buLinearPathCam(new List<Point3D>()
                            {
                              point3D2,
                              point3D3
                            });
                          }
                          tpPnt9D.PlungeAxisMovement = true;
                          buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamLeaveDraw.Color;
                          CamResult.EntitiesLeave.Add((Entity) buLinearPathCam);
                          break;
                        default:
                          buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamOtherDraw.Color;
                          CamResult.EntitiesOther.Add((Entity) buLinearPathCam);
                          break;
                      }
                      point3D1 = buVector5.ToPoint3D(point3DList[point3DList.Count - 1]);
                      point3DList.Clear();
                      point3DList.Add(point3D1);
                    }
                    camTpPoint.Points.Add(tpPnt9D);
                    ++num7;
                  }
                }
                if (point3DList.Count > 0)
                  point3D1 = buVector5.ToPoint3D(point3DList[point3DList.Count - 1]);
              }
              if (point3DList.Count > 1)
              {
                if (flag1)
                {
                  if (point3DList.Count > 1)
                  {
                    buLinearPathCam buLinearPathCam = new buLinearPathCam(point3DList);
                    buLinearPathCam.MoveType = CamMoveType.G1;
                    buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                    buLinearPathCam.CamID = CamID;
                    curveList.Add((ICurve) buLinearPathCam);
                  }
                }
                else if (point3DList.Count > 1)
                  CamResult.EntitiesG0.Add((Entity) new buLinearPathCam(point3DList)
                  {
                    CamID = CamID
                  });
                point3DList.Clear();
                point3DList.Add(point3D1);
              }
            }
            if (curveList.Count > 0)
            {
              List<Point3D> points = new List<Point3D>();
              for (int index1 = 0; index1 <= curveList.Count - 1; ++index1)
              {
                Entity entity = (Entity) curveList[index1];
                List<Point3D> PointList = new List<Point3D>();
                buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
                if (entity.GetType() == typeof (buArcCam) && ((buArcCam) entity).isReverse)
                  PointList.Reverse();
                int num16 = 0;
                if (index1 > 0)
                  num16 = 1;
                for (int index2 = num16; index2 <= PointList.Count - 1; ++index2)
                  points.Add(new Point3D(PointList[index2].X, PointList[index2].Y, PointList[index2].Z));
              }
              if (points.Count > 1)
              {
                buLinearPathCam buLinearPathCam = new buLinearPathCam(points);
                buLinearPathCam.CamID = CamID;
                buLinearPathCam.MoveType = CamMoveType.G1;
                buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                CamResult.EntitiesG1.Add((Entity) buLinearPathCam);
              }
              curveList.Clear();
            }
            ++num8;
          }
          if (camTpPoint.Points.Count > 0)
            CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint.Points[0]));
          for (int index3 = 1; index3 <= camTpPoint.Points.Count - 1; ++index3)
          {
            List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
            double num17 = clsInit.cVector5.Length3D(new Pnt3D(camTpPoint.Points[index3 - 1].P9.X, camTpPoint.Points[index3 - 1].P9.Y, camTpPoint.Points[index3 - 1].P9.Z), new Pnt3D(camTpPoint.Points[index3].P9.X, camTpPoint.Points[index3].P9.Y, camTpPoint.Points[index3].P9.Z));
            if (camTpPoint.Points[index3].Type == 0)
            {
              int int32 = Convert.ToInt32(num17 / 5.0);
              clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3 - 1]), TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]), int32, ref CalculatedPoints);
            }
            else if (camTpPoint.Points[index3].Type == 1)
            {
              int int32 = Convert.ToInt32(num17 / 1.0);
              clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3 - 1]), TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]), int32, ref CalculatedPoints);
            }
            else if (camTpPoint.Points[index3].Type == 2 | camTpPoint.Points[index3].Type == 3)
            {
              double length = camTpPoint.Points[index3].ArcData.Length;
              new Arc(Plane.XY, camTpPoint.Points[index3].ArcData.CenterPoint, camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartPoint, camTpPoint.Points[index3].ArcData.EndPoint, false).Regen(0.01);
              List<Pnt3D> Vertices = new List<Pnt3D>();
              if (!camTpPoint.Points[index3].ArcData.isReverse)
              {
                clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint.Points[index3].ArcData.CenterPoint), camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartAngle, camTpPoint.Points[index3].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
              }
              else
              {
                clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint.Points[index3].ArcData.CenterPoint), camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartAngle, camTpPoint.Points[index3].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
                Vertices.Reverse();
              }
              if (Vertices.Count > 0)
              {
                for (int index4 = 0; index4 <= Vertices.Count - 1; ++index4)
                {
                  Pnt6DSimMove pnt6DsimMove = new Pnt6DSimMove(Vertices[index4].X, Vertices[index4].Y, Vertices[index4].Z);
                  CalculatedPoints.Add(pnt6DsimMove);
                }
              }
            }
            if (CalculatedPoints.Count >= 2)
            {
              CalculatedPoints.RemoveAt(0);
              CamResult.SimilationPoint.SimMove.AddRange((IEnumerable<Pnt6DSimMove>) CalculatedPoints);
            }
            else
              CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]));
          }
          CamResult.CamID = CamID;
          CamResult.CamPoints.Add(camTpPoint);
        }
      }
    }
  }

  public void IterateThroughEntireStructure5X(
    ToolPath calculatedToolPath,
    int CamID,
    camParameters5 camPars,
    GeoLib mwPars,
    ref camTp CamResult)
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    int num5 = 0;
    int num6 = 0;
    int num7 = 0;
    int num8 = 0;
    Point3D point3D = new Point3D();
    CamResult = new camTp();
    CalculationEventArg e = new CalculationEventArg();
    List<Point3D> point3DList = new List<Point3D>();
    foreach (TPPass pass in calculatedToolPath.Passes)
    {
      ++num1;
      double num9 = (double) num1 / (double) calculatedToolPath.Passes.Count<TPPass>();
      if (num9 > 1.0)
        num9 = 1.0;
      Application.DoEvents();
      e.OverallProgressPercentage = num9 * 100.0;
      int num10 = 0;
      foreach (TPSlice slice in pass.Slices)
      {
        ++num10;
        double num11 = Convert.ToDouble(num10) / (double) pass.Slices.Count<TPSlice>();
        if (num11 > 1.0)
          num11 = 1.0;
        e.ActiveProgressPercentage = num11 * 100.0;
        e.Job = "Iteration";
        e.ShowForm = clsInit.cMwCalc.Settings.ShowProgressForm;
        clsInit.appCommand.CalculationInProgressCmd(e);
        int num12 = 0;
        if (num10 >= 1)
        {
          camTpPoint camTpPoint = new camTpPoint();
          foreach (TPSection section in slice.Sections)
          {
            ToolPathLinkType toolPathLinkType = ToolPathLinkType.NotALink;
            ++num12;
            bool flag1;
            if (section is TPContour)
            {
              ++num2;
              flag1 = true;
            }
            else
            {
              ++num3;
              flag1 = false;
              toolPathLinkType = (section as TPLink).LinkType;
            }
            List<ICurve> curveList = new List<ICurve>();
            int num13 = 0;
            foreach (TPSectionFit sectionFit in section.SectionFits)
            {
              ++num13;
              TPHelixFit tpHelixFit = sectionFit as TPHelixFit;
              bool flag2 = false;
              if (tpHelixFit != null && !buCompare.EQ(tpHelixFit.Helix.StartPoint.Z, tpHelixFit.Helix.EndPoint.Z))
                flag2 = true;
              if (tpHelixFit != null & !flag2)
              {
                ++num5;
                if (tpHelixFit.Helix.ArcSweep <= 3.1315926535897933)
                {
                  TpPnt9D tpPnt9D = new TpPnt9D();
                  tpPnt9D.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D.IsArc = true;
                  this.HelixToArcData(tpHelixFit.Helix, ref tpPnt9D.ArcData);
                  tpPnt9D.P9 = new Pnt9D(tpHelixFit.Helix.EndPoint.X, tpHelixFit.Helix.EndPoint.Y, tpHelixFit.Helix.EndPoint.Z);
                  buArcCam buArcCam = new buArcCam(Plane.XY, tpPnt9D.ArcData.CenterPoint, tpPnt9D.ArcData.Radius, tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.EndPoint, false);
                  buArcCam.MoveType = CamMoveType.G1;
                  buArcCam.CamID = CamID;
                  buArcCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                  buArcCam.ColorMethod = colorMethodType.byEntity;
                  buArcCam.Regen(new RegenParams(0.001));
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    tpPnt9D.ArcData.isCW = false;
                    tpPnt9D.Type = 3;
                  }
                  else
                  {
                    tpPnt9D.ArcData.isCW = true;
                    tpPnt9D.Type = 2;
                  }
                  camTpPoint.Points.Add(tpPnt9D);
                  if (flag1)
                  {
                    List<Point3D> points = new List<Point3D>();
                    for (int index = 0; index <= buArcCam.Vertices.Length - 1; ++index)
                      points.Add(new Point3D(buArcCam.Vertices[index].X, buArcCam.Vertices[index].Y, buArcCam.Vertices[index].Z));
                    if (tpPnt9D.Type == 2)
                      points.Reverse();
                    if (points.Count > 1)
                    {
                      buLinearPathCam buLinearPathCam = new buLinearPathCam(points);
                      buLinearPathCam.MoveType = CamMoveType.G1;
                      buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                      buLinearPathCam.CamID = CamID;
                      curveList.Add((ICurve) buLinearPathCam);
                    }
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.ConnectionClearanceArea)
                      CamResult.EntitiesConnection.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.ConnectionNotClearanceArea)
                      CamResult.EntitiesConnection.Add((Entity) buArcCam);
                  }
                  point3D = new Point3D(tpHelixFit.Helix.EndPoint.X, tpHelixFit.Helix.EndPoint.Y, tpHelixFit.Helix.EndPoint.Z);
                  point3DList.Clear();
                  point3DList.Add(point3D);
                }
                else
                {
                  Arc Arc1 = (Arc) null;
                  Arc Arc2 = (Arc) null;
                  this.HelixToSplitedArcs(tpHelixFit.Helix, ref Arc1, ref Arc2);
                  TpPnt9D tpPnt9D1 = new TpPnt9D();
                  tpPnt9D1.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D1.IsArc = true;
                  this.ArcToArcData(Arc1, ref tpPnt9D1.ArcData);
                  bool flag3;
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    flag3 = false;
                    tpPnt9D1.P9 = new Pnt9D(Arc1.EndPoint.X, Arc1.EndPoint.Y, Arc1.EndPoint.Z);
                    tpPnt9D1.ArcData.isReverse = false;
                  }
                  else
                  {
                    tpPnt9D1.ArcData.isReverse = true;
                    flag3 = true;
                    tpPnt9D1.P9 = new Pnt9D(Arc1.StartPoint.X, Arc1.StartPoint.Y, Arc1.StartPoint.Z);
                    tpPnt9D1.ArcData.isReverse = true;
                  }
                  buArcCam buArcCam1 = new buArcCam(Plane.XY, tpPnt9D1.ArcData.CenterPoint, tpPnt9D1.ArcData.Radius, tpPnt9D1.ArcData.StartPoint, tpPnt9D1.ArcData.EndPoint, false);
                  buArcCam1.isReverse = tpPnt9D1.ArcData.isReverse;
                  buArcCam1.MoveType = CamMoveType.G1;
                  buArcCam1.CamID = CamID;
                  buArcCam1.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                  buArcCam1.ColorMethod = colorMethodType.byEntity;
                  buArcCam1.Regen(new RegenParams(0.01));
                  if (flag3)
                  {
                    tpPnt9D1.ArcData.isCW = true;
                    tpPnt9D1.Type = 2;
                  }
                  else
                  {
                    tpPnt9D1.ArcData.isCW = false;
                    tpPnt9D1.Type = 3;
                  }
                  camTpPoint.Points.Add(tpPnt9D1);
                  if (flag1)
                  {
                    curveList.Add((ICurve) buArcCam1);
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.ConnectionClearanceArea)
                      CamResult.EntitiesConnection.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.ConnectionNotClearanceArea)
                      CamResult.EntitiesConnection.Add((Entity) buArcCam1);
                  }
                  TpPnt9D tpPnt9D2 = new TpPnt9D();
                  tpPnt9D2.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D2.IsArc = true;
                  this.ArcToArcData(Arc2, ref tpPnt9D2.ArcData);
                  bool flag4;
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    flag4 = false;
                    tpPnt9D2.P9 = new Pnt9D(Arc2.EndPoint.X, Arc2.EndPoint.Y, Arc2.EndPoint.Z);
                    tpPnt9D2.ArcData.isReverse = false;
                  }
                  else
                  {
                    flag4 = true;
                    tpPnt9D2.P9 = new Pnt9D(Arc2.StartPoint.X, Arc2.StartPoint.Y, Arc2.StartPoint.Z);
                    tpPnt9D2.ArcData.isReverse = true;
                  }
                  buArcCam buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, false);
                  buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
                  buArcCam2.MoveType = CamMoveType.G1;
                  buArcCam2.CamID = CamID;
                  buArcCam2.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                  buArcCam2.ColorMethod = colorMethodType.byEntity;
                  buArcCam2.Regen(new RegenParams(0.01));
                  if (flag4)
                  {
                    tpPnt9D2.ArcData.isCW = true;
                    tpPnt9D2.Type = 2;
                  }
                  else
                  {
                    tpPnt9D2.ArcData.isCW = false;
                    tpPnt9D2.Type = 3;
                  }
                  camTpPoint.Points.Add(tpPnt9D2);
                  if (flag1)
                  {
                    curveList.Add((ICurve) buArcCam2);
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.ConnectionClearanceArea)
                      CamResult.EntitiesConnection.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.ConnectionNotClearanceArea)
                      CamResult.EntitiesConnection.Add((Entity) buArcCam2);
                  }
                  point3D = tpHelixFit.Helix.CenterOrientation.Z <= 0.0 ? buVector5.ToPoint3D(tpPnt9D2.ArcData.StartPoint) : buVector5.ToPoint3D(tpPnt9D2.ArcData.EndPoint);
                  point3DList.Clear();
                  point3DList.Add(point3D);
                }
              }
              else
              {
                ++num4;
                foreach (CNCMove move in sectionFit.Moves)
                {
                  ++num6;
                  if (move is CNC5AxMove mwCNC5AxMove)
                  {
                    TpPnt9D tpPnt9D = new TpPnt9D();
                    tpPnt9D.P9 = new Pnt9D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z, mwCNC5AxMove.Orientation.X, mwCNC5AxMove.Orientation.Y, mwCNC5AxMove.Orientation.Z);
                    tpPnt9D.Type = !mwCNC5AxMove.IsRapid ? 1 : 0;
                    tpPnt9D.Feed = mwCNC5AxMove.FeedRate;
                    if (toolPathLinkType == ToolPathLinkType.Approach)
                      tpPnt9D.PlungeAxisMovement = true;
                    if (toolPathLinkType == ToolPathLinkType.Retract)
                      tpPnt9D.LeaveAxisMovement = true;
                    point3DList.Add(new Point3D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z));
                    if (!flag1 & point3DList.Count > 1)
                    {
                      CamMoveType MoveType = CamMoveType.G0;
                      this.GetCamMoveType(point3DList, CamResult.OperationVector, mwCNC5AxMove, ref MoveType);
                      if (MoveType == CamMoveType.G0 || toolPathLinkType == ToolPathLinkType.Retract || toolPathLinkType == ToolPathLinkType.Approach)
                        ;
                    }
                    camTpPoint.Points.Add(tpPnt9D);
                    ++num7;
                  }
                }
                if (point3DList.Count > 0)
                {
                  List<Point3D> copiedPoint = new List<Point3D>();
                  buVector5.Copy(point3DList, ref copiedPoint);
                  buLinearPathCam buLinearPathCam = new buLinearPathCam(copiedPoint);
                  buLinearPathCam.CamID = CamID;
                  buLinearPathCam.ColorMethod = colorMethodType.byEntity;
                  switch (toolPathLinkType)
                  {
                    case ToolPathLinkType.Approach:
                      buLinearPathCam.MoveType = CamMoveType.Plunge;
                      buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamPlungeDraw.Color;
                      CamResult.EntitiesPlunge.Add((Entity) buLinearPathCam);
                      break;
                    case ToolPathLinkType.LeadIn:
                      buLinearPathCam.MoveType = CamMoveType.LeadIn;
                      buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamLeadinDraw.Color;
                      CamResult.EntitiesLeadIn.Add((Entity) buLinearPathCam);
                      break;
                    case ToolPathLinkType.ConnectionNotClearanceArea:
                      buLinearPathCam.MoveType = CamMoveType.Connection;
                      buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamConnectionDraw.Color;
                      CamResult.EntitiesConnection.Add((Entity) buLinearPathCam);
                      break;
                    case ToolPathLinkType.ConnectionClearanceArea:
                      buLinearPathCam.MoveType = CamMoveType.Connection;
                      buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamConnectionDraw.Color;
                      CamResult.EntitiesConnection.Add((Entity) buLinearPathCam);
                      break;
                    case ToolPathLinkType.LeadOut:
                      buLinearPathCam.MoveType = CamMoveType.LeadOut;
                      buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamLeadOutDraw.Color;
                      CamResult.EntitiesLeadOut.Add((Entity) buLinearPathCam);
                      break;
                    case ToolPathLinkType.Retract:
                      buLinearPathCam.MoveType = CamMoveType.Leave;
                      buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamLeaveDraw.Color;
                      CamResult.EntitiesLeave.Add((Entity) buLinearPathCam);
                      break;
                  }
                  point3D = buVector5.ToPoint3D(point3DList[point3DList.Count - 1]);
                }
              }
              if (point3DList.Count > 1)
              {
                if (flag1)
                {
                  if (point3DList.Count > 1)
                  {
                    buLinearPathCam buLinearPathCam = new buLinearPathCam(point3DList);
                    buLinearPathCam.MoveType = CamMoveType.G1;
                    buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                    buLinearPathCam.CamID = CamID;
                    curveList.Add((ICurve) buLinearPathCam);
                  }
                }
                else if (point3DList.Count > 1)
                {
                  buLinearPathCam buLinearPathCam = new buLinearPathCam(point3DList);
                  buLinearPathCam.MoveType = CamMoveType.G0;
                  buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG0Draw.Color;
                  buLinearPathCam.CamID = CamID;
                  CamResult.EntitiesG0.Add((Entity) buLinearPathCam);
                }
                point3DList.Clear();
                point3DList.Add(point3D);
              }
            }
            if (curveList.Count > 0)
            {
              List<Point3D> points = new List<Point3D>();
              for (int index1 = 0; index1 <= curveList.Count - 1; ++index1)
              {
                Entity entity = (Entity) curveList[index1];
                List<Point3D> PointList = new List<Point3D>();
                buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
                if (entity.GetType() == typeof (buArcCam) && ((buArcCam) entity).isReverse)
                  PointList.Reverse();
                int num14 = 0;
                if (index1 > 0)
                  num14 = 1;
                for (int index2 = num14; index2 <= PointList.Count - 1; ++index2)
                  points.Add(new Point3D(PointList[index2].X, PointList[index2].Y, PointList[index2].Z));
              }
              if (points.Count > 1)
              {
                buLinearPathCam buLinearPathCam = new buLinearPathCam(points);
                buLinearPathCam.CamID = CamID;
                buLinearPathCam.MoveType = CamMoveType.G1;
                buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                CamResult.EntitiesG1.Add((Entity) buLinearPathCam);
              }
              curveList.Clear();
            }
            ++num8;
          }
          if (camTpPoint.Points.Count > 0)
            CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint.Points[0]));
          for (int index3 = 1; index3 <= camTpPoint.Points.Count - 1; ++index3)
          {
            List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
            double num15 = clsInit.cVector5.Length3D(new Pnt3D(camTpPoint.Points[index3 - 1].P9.X, camTpPoint.Points[index3 - 1].P9.Y, camTpPoint.Points[index3 - 1].P9.Z), new Pnt3D(camTpPoint.Points[index3].P9.X, camTpPoint.Points[index3].P9.Y, camTpPoint.Points[index3].P9.Z));
            if (camTpPoint.Points[index3].Type == 0)
            {
              int int32 = Convert.ToInt32(num15 / 5.0);
              clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3 - 1]), TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]), int32, ref CalculatedPoints);
            }
            else if (camTpPoint.Points[index3].Type == 1)
            {
              int int32 = Convert.ToInt32(num15 / 1.0);
              clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3 - 1]), TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]), int32, ref CalculatedPoints);
            }
            else if (camTpPoint.Points[index3].Type == 2 | camTpPoint.Points[index3].Type == 3)
            {
              double length = camTpPoint.Points[index3].ArcData.Length;
              new Arc(Plane.XY, camTpPoint.Points[index3].ArcData.CenterPoint, camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartPoint, camTpPoint.Points[index3].ArcData.EndPoint, false).Regen(0.01);
              List<Pnt3D> Vertices = new List<Pnt3D>();
              if (!camTpPoint.Points[index3].ArcData.isReverse)
              {
                clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint.Points[index3].ArcData.CenterPoint), camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartAngle, camTpPoint.Points[index3].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
              }
              else
              {
                clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint.Points[index3].ArcData.CenterPoint), camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartAngle, camTpPoint.Points[index3].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
                Vertices.Reverse();
              }
              if (Vertices.Count > 0)
              {
                for (int index4 = 0; index4 <= Vertices.Count - 1; ++index4)
                {
                  Pnt6DSimMove pnt6DsimMove = new Pnt6DSimMove(Vertices[index4].X, Vertices[index4].Y, Vertices[index4].Z);
                  CalculatedPoints.Add(pnt6DsimMove);
                }
              }
            }
            if (CalculatedPoints.Count >= 2)
            {
              CalculatedPoints.RemoveAt(0);
              CamResult.SimilationPoint.SimMove.AddRange((IEnumerable<Pnt6DSimMove>) CalculatedPoints);
            }
            else
              CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]));
          }
          CamResult.CamID = CamID;
          CamResult.CamPoints.Add(camTpPoint);
        }
      }
    }
  }

  public void IterateThroughEntireStructure5X_1(
    ToolPath calculatedToolPath,
    int CamID,
    camParameters5 camPars,
    GeoLib mwPars,
    ref camTp CamResult)
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    int num5 = 0;
    int num6 = 0;
    int num7 = 0;
    int num8 = 0;
    Point3D point3D1 = new Point3D();
    CamResult = new camTp();
    CalculationEventArg e = new CalculationEventArg();
    List<Point3D> point3DList = new List<Point3D>();
    foreach (TPPass pass in calculatedToolPath.Passes)
    {
      ++num1;
      double num9 = (double) num1 / (double) calculatedToolPath.Passes.Count<TPPass>();
      if (num9 > 1.0)
        num9 = 1.0;
      Application.DoEvents();
      e.OverallProgressPercentage = num9 * 100.0;
      int num10 = 0;
      foreach (TPSlice slice in pass.Slices)
      {
        ++num10;
        double num11 = Convert.ToDouble(num10) / (double) pass.Slices.Count<TPSlice>();
        if (num11 > 1.0)
          num11 = 1.0;
        e.ActiveProgressPercentage = num11 * 100.0;
        e.Job = "Iteration";
        e.ShowForm = clsInit.cMwCalc.Settings.ShowProgressForm;
        clsInit.appCommand.CalculationInProgressCmd(e);
        int num12 = 0;
        if (num10 >= 1)
        {
          camTpPoint camTpPoint = new camTpPoint();
          foreach (TPSection section in slice.Sections)
          {
            ++num12;
            bool flag1;
            if (section is TPContour)
            {
              ++num2;
              flag1 = true;
            }
            else
            {
              ++num3;
              flag1 = false;
              int linkType = (int) (section as TPLink).LinkType;
            }
            List<ICurve> curveList = new List<ICurve>();
            int num13 = 0;
            foreach (TPSectionFit sectionFit in section.SectionFits)
            {
              ++num13;
              TPHelixFit tpHelixFit = sectionFit as TPHelixFit;
              bool flag2 = false;
              if (tpHelixFit != null && !buCompare.EQ(tpHelixFit.Helix.StartPoint.Z, tpHelixFit.Helix.EndPoint.Z))
                flag2 = true;
              if (tpHelixFit != null & !flag2)
              {
                ++num5;
                if (tpHelixFit.Helix.ArcSweep <= 3.1315926535897933)
                {
                  TpPnt9D tpPnt9D = new TpPnt9D();
                  tpPnt9D.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D.IsArc = true;
                  this.HelixToArcData(tpHelixFit.Helix, ref tpPnt9D.ArcData);
                  tpPnt9D.P9 = new Pnt9D(tpHelixFit.Helix.EndPoint.X, tpHelixFit.Helix.EndPoint.Y, tpHelixFit.Helix.EndPoint.Z);
                  buArcCam buArcCam = new buArcCam(Plane.XY, tpPnt9D.ArcData.CenterPoint, tpPnt9D.ArcData.Radius, tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.EndPoint, false);
                  buArcCam.MoveType = CamMoveType.G1;
                  buArcCam.CamID = CamID;
                  buArcCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                  buArcCam.ColorMethod = colorMethodType.byEntity;
                  buArcCam.Regen(new RegenParams(0.001));
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    tpPnt9D.ArcData.isCW = false;
                    tpPnt9D.Type = 3;
                  }
                  else
                  {
                    tpPnt9D.ArcData.isCW = true;
                    tpPnt9D.Type = 2;
                  }
                  camTpPoint.Points.Add(tpPnt9D);
                  if (flag1)
                  {
                    List<Point3D> points = new List<Point3D>();
                    for (int index = 0; index <= buArcCam.Vertices.Length - 1; ++index)
                      points.Add(new Point3D(buArcCam.Vertices[index].X, buArcCam.Vertices[index].Y, buArcCam.Vertices[index].Z));
                    if (tpPnt9D.Type == 2)
                      points.Reverse();
                    if (points.Count > 1)
                    {
                      buLinearPathCam buLinearPathCam = new buLinearPathCam(points);
                      buLinearPathCam.MoveType = CamMoveType.G1;
                      buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                      buLinearPathCam.CamID = CamID;
                      curveList.Add((ICurve) buLinearPathCam);
                    }
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) buArcCam);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) buArcCam);
                  }
                  point3D1 = new Point3D(tpHelixFit.Helix.EndPoint.X, tpHelixFit.Helix.EndPoint.Y, tpHelixFit.Helix.EndPoint.Z);
                  point3DList.Clear();
                  point3DList.Add(point3D1);
                }
                else
                {
                  Arc Arc1 = (Arc) null;
                  Arc Arc2 = (Arc) null;
                  this.HelixToSplitedArcs(tpHelixFit.Helix, ref Arc1, ref Arc2);
                  TpPnt9D tpPnt9D1 = new TpPnt9D();
                  tpPnt9D1.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D1.IsArc = true;
                  this.ArcToArcData(Arc1, ref tpPnt9D1.ArcData);
                  bool flag3;
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    flag3 = false;
                    tpPnt9D1.P9 = new Pnt9D(Arc1.EndPoint.X, Arc1.EndPoint.Y, Arc1.EndPoint.Z);
                    tpPnt9D1.ArcData.isReverse = false;
                  }
                  else
                  {
                    tpPnt9D1.ArcData.isReverse = true;
                    flag3 = true;
                    tpPnt9D1.P9 = new Pnt9D(Arc1.StartPoint.X, Arc1.StartPoint.Y, Arc1.StartPoint.Z);
                    tpPnt9D1.ArcData.isReverse = true;
                  }
                  buArcCam buArcCam1 = new buArcCam(Plane.XY, tpPnt9D1.ArcData.CenterPoint, tpPnt9D1.ArcData.Radius, tpPnt9D1.ArcData.StartPoint, tpPnt9D1.ArcData.EndPoint, false);
                  buArcCam1.isReverse = tpPnt9D1.ArcData.isReverse;
                  buArcCam1.MoveType = CamMoveType.G1;
                  buArcCam1.CamID = CamID;
                  buArcCam1.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                  buArcCam1.ColorMethod = colorMethodType.byEntity;
                  buArcCam1.Regen(new RegenParams(0.01));
                  if (flag3)
                  {
                    tpPnt9D1.ArcData.isCW = true;
                    tpPnt9D1.Type = 2;
                  }
                  else
                  {
                    tpPnt9D1.ArcData.isCW = false;
                    tpPnt9D1.Type = 3;
                  }
                  camTpPoint.Points.Add(tpPnt9D1);
                  if (flag1)
                  {
                    curveList.Add((ICurve) buArcCam1);
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) buArcCam1);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) buArcCam1);
                  }
                  TpPnt9D tpPnt9D2 = new TpPnt9D();
                  tpPnt9D2.Feed = sectionFit.Moves.ElementAt<CNCMove>(0).FeedRate;
                  tpPnt9D2.IsArc = true;
                  this.ArcToArcData(Arc2, ref tpPnt9D2.ArcData);
                  bool flag4;
                  if (tpHelixFit.Helix.CenterOrientation.Z > 0.0)
                  {
                    flag4 = false;
                    tpPnt9D2.P9 = new Pnt9D(Arc2.EndPoint.X, Arc2.EndPoint.Y, Arc2.EndPoint.Z);
                    tpPnt9D2.ArcData.isReverse = false;
                  }
                  else
                  {
                    flag4 = true;
                    tpPnt9D2.P9 = new Pnt9D(Arc2.StartPoint.X, Arc2.StartPoint.Y, Arc2.StartPoint.Z);
                    tpPnt9D2.ArcData.isReverse = true;
                  }
                  buArcCam buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, false);
                  buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
                  buArcCam2.MoveType = CamMoveType.G1;
                  buArcCam2.CamID = CamID;
                  buArcCam2.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                  buArcCam2.ColorMethod = colorMethodType.byEntity;
                  buArcCam2.Regen(new RegenParams(0.01));
                  if (flag4)
                  {
                    tpPnt9D2.ArcData.isCW = true;
                    tpPnt9D2.Type = 2;
                  }
                  else
                  {
                    tpPnt9D2.ArcData.isCW = false;
                    tpPnt9D2.Type = 3;
                  }
                  camTpPoint.Points.Add(tpPnt9D2);
                  if (flag1)
                  {
                    curveList.Add((ICurve) buArcCam2);
                  }
                  else
                  {
                    TPLink tpLink = section as TPLink;
                    if (tpLink.LinkType == ToolPathLinkType.LeadIn)
                      CamResult.EntitiesLeadIn.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.LeadOut)
                      CamResult.EntitiesLeadOut.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.Approach)
                      CamResult.EntitiesPlunge.Add((Entity) buArcCam2);
                    if (tpLink.LinkType == ToolPathLinkType.Retract)
                      CamResult.EntitiesLeave.Add((Entity) buArcCam2);
                  }
                  point3D1 = tpHelixFit.Helix.CenterOrientation.Z <= 0.0 ? buVector5.ToPoint3D(tpPnt9D2.ArcData.StartPoint) : buVector5.ToPoint3D(tpPnt9D2.ArcData.EndPoint);
                  point3DList.Clear();
                  point3DList.Add(point3D1);
                }
              }
              else
              {
                ++num4;
                foreach (CNCMove move in sectionFit.Moves)
                {
                  ++num6;
                  if (move is CNC5AxMove mwCNC5AxMove)
                  {
                    TpPnt9D tpPnt9D = new TpPnt9D();
                    tpPnt9D.P9 = new Pnt9D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z, mwCNC5AxMove.Orientation.X, mwCNC5AxMove.Orientation.Y, mwCNC5AxMove.Orientation.Z);
                    tpPnt9D.Type = !mwCNC5AxMove.IsRapid ? 1 : 0;
                    tpPnt9D.Feed = mwCNC5AxMove.FeedRate;
                    point3DList.Add(new Point3D(mwCNC5AxMove.Position.X, mwCNC5AxMove.Position.Y, mwCNC5AxMove.Position.Z));
                    if (!flag1 & point3DList.Count > 1)
                    {
                      CamMoveType MoveType = CamMoveType.G0;
                      this.GetCamMoveType(point3DList, CamResult.OperationVector, mwCNC5AxMove, ref MoveType);
                      buLinearPathCam buLinearPathCam = new buLinearPathCam(point3DList);
                      buLinearPathCam.CamID = CamID;
                      buLinearPathCam.MoveType = MoveType;
                      buLinearPathCam.ColorMethod = colorMethodType.byEntity;
                      switch (MoveType)
                      {
                        case CamMoveType.G0:
                          buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG0Draw.Color;
                          CamResult.EntitiesG0.Add((Entity) buLinearPathCam);
                          break;
                        case CamMoveType.Plunge:
                          if (buLinearPathCam.Vertices.Length == 2)
                          {
                            Vector3D vector3D = new Vector3D(mwCNC5AxMove.Orientation.X, mwCNC5AxMove.Orientation.Y, mwCNC5AxMove.Orientation.Z);
                            double num14 = buLinearPathCam.Length();
                            buLinearPathCam = new buLinearPathCam(new List<Point3D>()
                            {
                              new Point3D(buLinearPathCam.Vertices[1].X + vector3D.X * num14, buLinearPathCam.Vertices[1].Y + vector3D.Y * num14, buLinearPathCam.Vertices[1].Z + vector3D.Z * num14),
                              buVector5.ToPoint3D(buLinearPathCam.Vertices[1])
                            });
                          }
                          tpPnt9D.PlungeAxisMovement = true;
                          buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamPlungeDraw.Color;
                          CamResult.EntitiesPlunge.Add((Entity) buLinearPathCam);
                          break;
                        case CamMoveType.Leave:
                          if (buLinearPathCam.Vertices.Length == 2)
                          {
                            Vector3D vector3D = new Vector3D(mwCNC5AxMove.Orientation.X, mwCNC5AxMove.Orientation.Y, mwCNC5AxMove.Orientation.Z);
                            double num15 = buLinearPathCam.Length();
                            Point3D point3D2 = buVector5.ToPoint3D(buLinearPathCam.Vertices[0]);
                            Point3D point3D3 = new Point3D(point3D2.X + vector3D.X * num15, point3D2.Y + vector3D.Y * num15, point3D2.Z + vector3D.Z * num15);
                            buLinearPathCam = new buLinearPathCam(new List<Point3D>()
                            {
                              point3D2,
                              point3D3
                            });
                          }
                          tpPnt9D.PlungeAxisMovement = true;
                          buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamLeaveDraw.Color;
                          CamResult.EntitiesLeave.Add((Entity) buLinearPathCam);
                          break;
                        default:
                          buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamOtherDraw.Color;
                          CamResult.EntitiesOther.Add((Entity) buLinearPathCam);
                          break;
                      }
                      point3D1 = buVector5.ToPoint3D(point3DList[point3DList.Count - 1]);
                      point3DList.Clear();
                      point3DList.Add(point3D1);
                    }
                    camTpPoint.Points.Add(tpPnt9D);
                    ++num7;
                  }
                }
                if (point3DList.Count > 0)
                  point3D1 = buVector5.ToPoint3D(point3DList[point3DList.Count - 1]);
              }
              if (point3DList.Count > 1)
              {
                if (flag1)
                {
                  if (point3DList.Count > 1)
                  {
                    buLinearPathCam buLinearPathCam = new buLinearPathCam(point3DList);
                    buLinearPathCam.MoveType = CamMoveType.G1;
                    buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                    buLinearPathCam.CamID = CamID;
                    curveList.Add((ICurve) buLinearPathCam);
                  }
                }
                else if (point3DList.Count > 1)
                  CamResult.EntitiesG0.Add((Entity) new buLinearPathCam(point3DList)
                  {
                    CamID = CamID
                  });
                point3DList.Clear();
                point3DList.Add(point3D1);
              }
            }
            if (curveList.Count > 0)
            {
              List<Point3D> points = new List<Point3D>();
              for (int index1 = 0; index1 <= curveList.Count - 1; ++index1)
              {
                Entity entity = (Entity) curveList[index1];
                List<Point3D> PointList = new List<Point3D>();
                buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
                if (entity.GetType() == typeof (buArcCam) && ((buArcCam) entity).isReverse)
                  PointList.Reverse();
                int num16 = 0;
                if (index1 > 0)
                  num16 = 1;
                for (int index2 = num16; index2 <= PointList.Count - 1; ++index2)
                  points.Add(new Point3D(PointList[index2].X, PointList[index2].Y, PointList[index2].Z));
              }
              if (points.Count > 1)
              {
                buLinearPathCam buLinearPathCam = new buLinearPathCam(points);
                buLinearPathCam.CamID = CamID;
                buLinearPathCam.MoveType = CamMoveType.G1;
                buLinearPathCam.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
                CamResult.EntitiesG1.Add((Entity) buLinearPathCam);
              }
              curveList.Clear();
            }
            ++num8;
          }
          if (camTpPoint.Points.Count > 0)
            CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint.Points[0]));
          for (int index3 = 1; index3 <= camTpPoint.Points.Count - 1; ++index3)
          {
            List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
            double num17 = clsInit.cVector5.Length3D(new Pnt3D(camTpPoint.Points[index3 - 1].P9.X, camTpPoint.Points[index3 - 1].P9.Y, camTpPoint.Points[index3 - 1].P9.Z), new Pnt3D(camTpPoint.Points[index3].P9.X, camTpPoint.Points[index3].P9.Y, camTpPoint.Points[index3].P9.Z));
            if (camTpPoint.Points[index3].Type == 0)
            {
              int int32 = Convert.ToInt32(num17 / 5.0);
              clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3 - 1]), TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]), int32, ref CalculatedPoints);
            }
            else if (camTpPoint.Points[index3].Type == 1)
            {
              int int32 = Convert.ToInt32(num17 / 1.0);
              clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3 - 1]), TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]), int32, ref CalculatedPoints);
            }
            else if (camTpPoint.Points[index3].Type == 2 | camTpPoint.Points[index3].Type == 3)
            {
              double length = camTpPoint.Points[index3].ArcData.Length;
              new Arc(Plane.XY, camTpPoint.Points[index3].ArcData.CenterPoint, camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartPoint, camTpPoint.Points[index3].ArcData.EndPoint, false).Regen(0.01);
              List<Pnt3D> Vertices = new List<Pnt3D>();
              if (!camTpPoint.Points[index3].ArcData.isReverse)
              {
                clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint.Points[index3].ArcData.CenterPoint), camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartAngle, camTpPoint.Points[index3].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
              }
              else
              {
                clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint.Points[index3].ArcData.CenterPoint), camTpPoint.Points[index3].ArcData.Radius, camTpPoint.Points[index3].ArcData.StartAngle, camTpPoint.Points[index3].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
                Vertices.Reverse();
              }
              if (Vertices.Count > 0)
              {
                for (int index4 = 0; index4 <= Vertices.Count - 1; ++index4)
                {
                  Pnt6DSimMove pnt6DsimMove = new Pnt6DSimMove(Vertices[index4].X, Vertices[index4].Y, Vertices[index4].Z);
                  CalculatedPoints.Add(pnt6DsimMove);
                }
              }
            }
            if (CalculatedPoints.Count >= 2)
            {
              CalculatedPoints.RemoveAt(0);
              CamResult.SimilationPoint.SimMove.AddRange((IEnumerable<Pnt6DSimMove>) CalculatedPoints);
            }
            else
              CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint.Points[index3]));
          }
          CamResult.CamID = CamID;
          CamResult.CamPoints.Add(camTpPoint);
        }
      }
    }
  }

  public int GetNextSectionOfTP(
    IEnumerable<TPSection> Sections,
    int Index,
    ref MWIterationOption Option,
    ref List<Pnt6D> P6)
  {
    try
    {
      Pnt3D Pnt = (Pnt3D) null;
      P6 = new List<Pnt6D>();
      int num = Index;
      if (num < 0)
        num = 0;
      for (int index1 = num; index1 <= Sections.Count<TPSection>() - 1; ++index1)
      {
        TPSection tpSection = Sections.ElementAt<TPSection>(index1);
        bool flag = tpSection is TPContour;
        foreach (TPSectionFit sectionFit in tpSection.SectionFits)
        {
          for (int index2 = 0; index2 <= sectionFit.Moves.Count<CNCMove>() - 1; ++index2)
          {
            CNC5AxMove cnC5AxMove = sectionFit.Moves.ElementAt<CNCMove>(index2) as CNC5AxMove;
            if (cnC5AxMove != null & flag)
            {
              if (index2 == 0)
                P6.Add(new Pnt6D(Pnt));
              P6.Add(new Pnt6D(cnC5AxMove.Position.X, cnC5AxMove.Position.Y, cnC5AxMove.Position.Z));
            }
            Pnt = new Pnt3D(cnC5AxMove.Position.X, cnC5AxMove.Position.Y, cnC5AxMove.Position.Z);
          }
        }
        if (P6.Count > 0)
        {
          double c1 = clsInit.cVector.PointAngle(new Pnt3D(P6[1]), new Pnt3D(P6[0]), new WorkPlane());
          double c2 = clsInit.cVector.PointAngle(new Pnt3D(P6[P6.Count - 1]), new Pnt3D(P6[P6.Count - 2]), new WorkPlane());
          Option.StartPoint = new Pnt6D(P6[0].X, P6[0].Y, P6[0].Z, 0.0, 0.0, c1);
          Option.EndPoint = new Pnt6D(P6[P6.Count - 1].X, P6[P6.Count - 1].Y, P6[P6.Count - 1].Z, 0.0, 0.0, c2);
          return 1;
        }
      }
      return 1;
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public void GetCamMoveType(
    List<Point3D> pointList,
    Vector3D OperationVector,
    CNC5AxMove mwCNC5AxMove,
    ref CamMoveType MoveType)
  {
    MoveType = CamMoveType.Other;
    if (pointList.Count < 2 || !(OperationVector == Vector3D.AxisZ))
      return;
    if (buCompare.EQ(pointList[pointList.Count - 1].X, pointList[pointList.Count - 2].X, buSystem.resolutionCompare))
    {
      if (buCompare.EQ(pointList[pointList.Count - 1].Y, pointList[pointList.Count - 2].Y, buSystem.resolutionCompare))
      {
        if (pointList[pointList.Count - 1].Z > pointList[pointList.Count - 2].Z)
          MoveType = CamMoveType.Leave;
        else
          MoveType = CamMoveType.Plunge;
      }
      else if (mwCNC5AxMove.IsRapid)
        MoveType = CamMoveType.G0;
      else
        MoveType = CamMoveType.G1;
    }
    else if (mwCNC5AxMove.IsRapid)
      MoveType = CamMoveType.G0;
    else
      MoveType = CamMoveType.G1;
  }

  public void HelixToArcData(HelixInformation Helix, ref TpArcData ArcData)
  {
    ArcData.CenterPoint = new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z);
    ArcData.SweepAngle = Helix.ArcSweep;
    ArcData.StartPoint = new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z);
    ArcData.EndPoint = new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z);
    ArcData.StartAngle = clsInit.cVector5.PointAngle(ArcData.StartPoint, ArcData.CenterPoint, Plane.XY);
    ArcData.EndAngle = clsInit.cVector5.PointAngle(ArcData.EndPoint, ArcData.CenterPoint, Plane.XY);
    if (!buCompare5.EQ(new Arc(Plane.XY, (Point2D) ArcData.CenterPoint, (Point2D) new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z), (Point2D) new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z)).AngleInRadians, Helix.ArcSweep))
    {
      Arc arc = new Arc(Plane.XY, (Point2D) ArcData.CenterPoint, (Point2D) new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z), (Point2D) new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z));
      ArcData.isReverse = true;
      ArcData.StartPoint = new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z);
      ArcData.EndPoint = new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z);
      ArcData.StartAngle = clsInit.cVector5.PointAngle(ArcData.StartPoint, ArcData.CenterPoint, Plane.XY);
      ArcData.EndAngle = clsInit.cVector5.PointAngle(ArcData.EndPoint, ArcData.CenterPoint, Plane.XY);
    }
    ArcData.Radius = Point3D.Distance(ArcData.StartPoint, ArcData.CenterPoint);
    ArcData.Length = Helix.ArcSweep * ArcData.Radius;
    if (ArcData.StartAngle <= ArcData.EndAngle)
      return;
    ArcData.EndAngle += 360.0;
  }

  public void ArcToArcData(Arc Arc, ref TpArcData ArcData)
  {
    if (Arc == null)
      return;
    ArcData.StartPoint = new Point3D(Arc.StartPoint.X, Arc.StartPoint.Y, Arc.StartPoint.Z);
    ArcData.EndPoint = new Point3D(Arc.EndPoint.X, Arc.EndPoint.Y, Arc.EndPoint.Z);
    ArcData.CenterPoint = new Point3D(Arc.Center.X, Arc.Center.Y, Arc.Center.Z);
    ArcData.SweepAngle = Arc.AngleInRadians;
    ArcData.Radius = Arc.Radius;
    ArcData.Length = Arc.Length();
    ArcData.StartAngle = clsInit.cVector5.PointAngle(ArcData.StartPoint, ArcData.CenterPoint, Plane.XY);
    ArcData.EndAngle = clsInit.cVector5.PointAngle(ArcData.EndPoint, ArcData.CenterPoint, Plane.XY);
    if (ArcData.StartAngle <= ArcData.EndAngle)
      return;
    ArcData.EndAngle += 360.0;
  }

  public void HelixToSplitedArcs(HelixInformation Helix, ref Arc Arc1, ref Arc Arc2)
  {
    if (buCompare5.EQ(Helix.ArcSweep, 2.0 * Math.PI, 0.01))
    {
      double radius = Point3D.Distance(new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z), new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z));
      Arc1 = new Arc(Plane.XY, new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z), radius, 0.0, Math.PI);
      Arc2 = new Arc(Plane.XY, new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z), radius, Math.PI, 2.0 * Math.PI);
    }
    else
    {
      Arc arc = Helix.CenterOrientation.Z <= 0.0 ? new Arc(Plane.XY, (Point2D) new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z), (Point2D) new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z), (Point2D) new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z)) : new Arc(Plane.XY, (Point2D) new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z), (Point2D) new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z), (Point2D) new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z));
      arc.Translate(0.0, 0.0, Helix.CenterPoint.Z);
      arc.Regen(new RegenParams(0.001));
      ICurve lower;
      ICurve upper;
      arc.SplitBy(arc.MidPoint, out lower, out upper);
      if (lower != null)
      {
        ((Entity) lower).Regen(new RegenParams(0.001));
        if (Helix.CenterOrientation.Z > 0.0)
          Arc1 = (Arc) lower;
        else
          Arc2 = (Arc) lower;
      }
      if (upper == null)
        return;
      ((Entity) upper).Regen(new RegenParams(0.001));
      if (Helix.CenterOrientation.Z > 0.0)
        Arc2 = (Arc) upper;
      else
        Arc1 = (Arc) upper;
    }
  }

  public void GetOffsetOfMesh(
    List<Entity> Meshes,
    double Offset,
    double StartZValue,
    double EndZValue,
    double ZStep,
    double Resolution,
    ref List<buEntity> OffsetEntities)
  {
    MWCalculationOptions MWCalcOptions = new MWCalculationOptions();
    MWCalcOptions.NumberofAxis = 3;
    MWCalcOptions.CamWireframeType = CamWireFrameType.Contour;
    MWCalcOptions.CamTriMeshType = CamTriangularMeshType.ConstantZ;
    MWCalcOptions.Mode = CamMode.TriangularMesh;
    MWCalcOptions.DontApplyReset = true;
    MWCalcOptions.isBuWireframeCalculation = false;
    MWCalcOptions.AddToCamListInLocalCalculation = false;
    MWCalcOptions.ShowLeadInOutPage = false;
    MWCalcOptions.DontShowDialogBox = true;
    MWCalcOptions.DontShowbuDialogBox = true;
    clsMW.varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep = ZStep;
    clsMW.varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep = 1;
    clsMW.varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep;
    clsMW.varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = EndZValue;
    clsMW.varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = StartZValue;
    clsMW.varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
    clsMW.varMWCamMeshContantZPars.MachParam.CutTolerance = Resolution;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.Direct;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.LastExit.Type = LastExitType.Direct;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.ClearancePlaneHeight = 2000.0;
    ToolBase5 ToolSelected = new ToolBase5();
    ToolSelected.Geometry.GeometryType = buClass.ToolType.Slot;
    ToolSelected.Geometry.Diameter = Offset * 2.0;
    ToolSelected.Geometry.Length = 500.0;
    clsMW.CamEntities.Clear();
    clsMW.CamEntities.AddRange((IEnumerable<Entity>) Meshes);
    camTp Cam = new camTp();
    camResult Result = new camResult();
    if (this.doTriangularMesh3D(MWCalcOptions, ToolSelected, ref Cam, ref Result) < 0 || Cam.CamPoints.Count <= 0)
      return;
    if (OffsetEntities == null)
      OffsetEntities = new List<buEntity>();
    OffsetEntities.Clear();
    for (int index = 0; index <= Cam.EntitiesG1.Count - 1; ++index)
    {
      if (Cam.EntitiesG1[index] is buLinearPathCam)
      {
        buLinearPathCam buLinearPathCam = Cam.EntitiesG1[index] as buLinearPathCam;
        if (!buLinearPathCam.isLink & buLinearPathCam.MoveType == CamMoveType.G1)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesG1[index], ref copiedEntity);
          OffsetEntities.Add(copiedEntity);
        }
      }
    }
  }

  public void GetPocketOfParalelEntities(
    List<Entity> refEntities,
    double Offset,
    double ZValue,
    double Resolution,
    ref List<buEntity> OffsetEntities)
  {
    MWCalculationOptions MWCalcOptions = new MWCalculationOptions();
    MWCalcOptions.NumberofAxis = 3;
    MWCalcOptions.CamWireframeType = CamWireFrameType.Pocket;
    MWCalcOptions.CamTriMeshType = CamTriangularMeshType.ConstantZ;
    MWCalcOptions.Mode = CamMode.WireFrame;
    MWCalcOptions.DontApplyReset = true;
    MWCalcOptions.isBuWireframeCalculation = false;
    MWCalcOptions.AddToCamListInLocalCalculation = false;
    MWCalcOptions.ShowLeadInOutPage = false;
    MWCalcOptions.DontShowDialogBox = true;
    MWCalcOptions.DontShowbuDialogBox = true;
    clsMW.varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep = 1.0;
    clsMW.varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep = 1;
    clsMW.varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep;
    clsMW.varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = ZValue;
    clsMW.varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = ZValue;
    clsMW.varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
    clsMW.varMWCamWFPocketPars.MachParam.CutTolerance = Resolution;
    clsMW.varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType = WireframeBasedTpCalcParamsRoughType.WfbRghtParallel;
    clsMW.varMWCamWFPocketPars.MachParam.CurMachType = MachiningParamsMachType.MachtypeOneway;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.Direct;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.LastExit.Type = LastExitType.Direct;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapIncrementalRapidPlane;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapIncrementalRapidPlane;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapIncrementalRapidPlane;
    clsMW.varMWCamMeshContantZPars.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapIncrementalRapidPlane;
    ToolBase5 ToolSelected = new ToolBase5();
    ToolSelected.Geometry.GeometryType = buClass.ToolType.Flat;
    ToolSelected.Geometry.Diameter = Offset * 2.0;
    ToolSelected.Geometry.Length = 500.0;
    clsMW.CamEntities.Clear();
    clsMW.CamEntities.AddRange((IEnumerable<Entity>) refEntities);
    camTp Cam = new camTp();
    camResult Result = new camResult();
    if (this.doWireframeContour(MWCalcOptions, ToolSelected, ref Cam, ref Result) < 0 || Cam.CamPoints.Count <= 0)
      return;
    if (OffsetEntities == null)
      OffsetEntities = new List<buEntity>();
    OffsetEntities.Clear();
    for (int index = 0; index <= Cam.EntitiesG1.Count - 1; ++index)
    {
      if (Cam.EntitiesG1[index] is buLinearPathCam && !(Cam.EntitiesG1[index] as buLinearPathCam).isLink)
      {
        buEntity copiedEntity = (buEntity) null;
        buEntity.Copy(Cam.EntitiesG1[index], ref copiedEntity);
        OffsetEntities.Add(copiedEntity);
      }
    }
  }

  public void SaveMWParameter()
  {
    if (clsInit.cMwCalc == null)
      return;
    clsVar.varCamWFContourPars.mwPar.Serialize(AppPath.Settings + "\\mwWfContour.bin");
    clsVar.varCamWFContour4XPars.mwPar.Serialize(AppPath.Settings + "\\mwWfContour4X.bin");
    clsVar.varCamWFPocketPars.mwPar.Serialize(AppPath.Settings + "\\mwWfPocket.bin");
    clsVar.varCamDrillPars.mwPar.Serialize(AppPath.Settings + "\\mwDrill.bin");
    clsVar.varCamMeshRoughPars.mwPar.Serialize(AppPath.Settings + "\\mwTmRough.bin");
    clsVar.varCamMeshParallelPars.mwPar.Serialize(AppPath.Settings + "\\mwTmParallel.bin");
    clsVar.varCamMeshConstantZPars.mwPar.Serialize(AppPath.Settings + "\\mwTmConstantZ.bin");
    clsVar.varCamMeshPencilPars.mwPar.Serialize(AppPath.Settings + "\\mwTmPencil.bin");
    clsVar.varCamMeshProjectionPars.mwPar.Serialize(AppPath.Settings + "\\mwTmProjection.bin");
    clsVar.varCamMeshConstantCuspPars.mwPar.Serialize(AppPath.Settings + "\\mwTmConstantCusp.bin");
    clsVar.varCamMeshFlatlandsPars.mwPar.Serialize(AppPath.Settings + "\\mwTmFlatlands.bin");
    string FileName = AppPath.Settings + "\\mwCam.bucamset";
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "   MW Cam Settings");
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "<MwCamSettings>");
    StringList.AddRange((ICollection) clsVar.varCamWFContourPars.buPar.ToDefAll("_varbuCamWFContourPars", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsVar.varCamWFContour4XPars.buPar.ToDefAll("_varbuCamWFContour4XPars", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsVar.varCamWFPocketPars.buPar.ToDefAll("_varbuCamWFPocketPars", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsVar.varCamDrillPars.buPar.ToDefAll("_varbuCamDrillPars", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsVar.varCamMeshRoughPars.buPar.ToDefAll("_varbuCamMeshRoughPars", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsVar.varCamMeshParallelPars.buPar.ToDefAll("_varbuCamMeshParallelPars", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsVar.varCamMeshConstantZPars.buPar.ToDefAll("_varbuCamMeshContantZPars", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsVar.varCamMeshPencilPars.buPar.ToDefAll("_varbuCamMeshPencilPars", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsVar.varCamMeshProjectionPars.buPar.ToDefAll("_varbuCamMeshProjectionPars", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsVar.varCamMeshFlatlandsPars.buPar.ToDefAll("_varbuCamMeshFlatlandsPars", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsVar.varCamMeshConstantCuspPars.buPar.ToDefAll("_varbuCamMeshContantCuspPars", 2, SerilizationMode5.MultiLine));
    StringList.Add((object) "</MwCamSettings>");
    buFile.SaveToFile(StringList, FileName);
  }

  public void OpenMWParameter()
  {
    if (clsInit.cMwCalc == null)
      return;
    FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\mwWfContour.bin");
    if (fileInfo1.Exists)
      clsVar.varCamWFContourPars.mwPar.Deserialize(fileInfo1.FullName);
    FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\mwWfPocket.bin");
    if (fileInfo2.Exists)
      clsVar.varCamWFPocketPars.mwPar.Deserialize(fileInfo2.FullName);
    FileInfo fileInfo3 = new FileInfo(AppPath.Settings + "\\mwWfContour4X.bin");
    if (fileInfo3.Exists)
      clsVar.varCamWFContour4XPars.mwPar.Deserialize(fileInfo3.FullName);
    FileInfo fileInfo4 = new FileInfo(AppPath.Settings + "\\mwDrill.bin");
    if (fileInfo4.Exists)
      clsVar.varCamDrillPars.mwPar.Deserialize(fileInfo4.FullName);
    FileInfo fileInfo5 = new FileInfo(AppPath.Settings + "\\mwTmRough.bin");
    if (fileInfo5.Exists)
      clsVar.varCamMeshRoughPars.mwPar.Deserialize(fileInfo5.FullName);
    FileInfo fileInfo6 = new FileInfo(AppPath.Settings + "\\mwTmParallel.bin");
    if (fileInfo6.Exists)
      clsVar.varCamMeshParallelPars.mwPar.Deserialize(fileInfo6.FullName);
    FileInfo fileInfo7 = new FileInfo(AppPath.Settings + "\\mwTmConstantZ.bin");
    if (fileInfo7.Exists)
      clsVar.varCamMeshConstantCuspPars.mwPar.Deserialize(fileInfo7.FullName);
    FileInfo fileInfo8 = new FileInfo(AppPath.Settings + "\\mwTmPencil.bin");
    if (fileInfo8.Exists)
      clsVar.varCamMeshPencilPars.mwPar.Deserialize(fileInfo8.FullName);
    FileInfo fileInfo9 = new FileInfo(AppPath.Settings + "\\mwTmProjection.bin");
    if (fileInfo9.Exists)
      clsVar.varCamMeshProjectionPars.mwPar.Deserialize(fileInfo9.FullName);
    FileInfo fileInfo10 = new FileInfo(AppPath.Settings + "\\mwTmConstantCusp.bin");
    if (fileInfo10.Exists)
      clsVar.varCamMeshConstantCuspPars.mwPar.Deserialize(fileInfo10.FullName);
    FileInfo fileInfo11 = new FileInfo(AppPath.Settings + "\\mwTmFlatlands.bin");
    if (fileInfo11.Exists)
      clsVar.varCamMeshFlatlandsPars.mwPar.Deserialize(fileInfo11.FullName);
    string str = AppPath.Settings + "\\mwCam.bucamset";
    if (!new FileInfo(str).Exists)
      return;
    ArrayList StringList = new ArrayList();
    buFile.OpenFromFile(str, ref StringList);
    try
    {
      ArrayList CalcList = new ArrayList();
      buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", true, StringList, ref CalcList);
      if (CalcList.Count <= 0)
        return;
      buSerilization.Decode(StringList, "_varbuCamWFContourPars", SerilizationMode.MultiLine, (object) clsVar.varCamWFContourPars.buPar);
      buSerilization.Decode(StringList, "_varbuCamWFPocketPars", SerilizationMode.MultiLine, (object) clsVar.varCamWFPocketPars.buPar);
      buSerilization.Decode(StringList, "_varbuCamWFContour4XPars", SerilizationMode.MultiLine, (object) clsVar.varCamWFContour4XPars.buPar);
      buSerilization.Decode(StringList, "_varbuCamDrillPars", SerilizationMode.MultiLine, (object) clsVar.varCamDrillPars.buPar);
      buSerilization.Decode(StringList, "_varbuCamMeshRoughPars", SerilizationMode.MultiLine, (object) clsVar.varCamMeshRoughPars.buPar);
      buSerilization.Decode(StringList, "_varbuCamMeshParallelPars", SerilizationMode.MultiLine, (object) clsVar.varCamMeshParallelPars.buPar);
      buSerilization.Decode(StringList, "_varbuCamMeshContantZPars", SerilizationMode.MultiLine, (object) clsVar.varCamMeshConstantZPars.buPar);
      buSerilization.Decode(StringList, "_varbuCamMeshPencilPars", SerilizationMode.MultiLine, (object) clsVar.varCamMeshPencilPars.buPar);
      buSerilization.Decode(StringList, "_varbuCamMeshProjectionPars", SerilizationMode.MultiLine, (object) clsVar.varCamMeshProjectionPars.buPar);
      buSerilization.Decode(StringList, "_varbuCamMeshFlatlandsPars", SerilizationMode.MultiLine, (object) clsVar.varCamMeshFlatlandsPars.buPar);
      buSerilization.Decode(StringList, "_varbuCamMeshContantCuspPars", SerilizationMode.MultiLine, (object) clsVar.varCamMeshConstantCuspPars.buPar);
    }
    catch (Exception ex)
    {
      buLog.addLog("MW Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Marble Settings Decoder Error");
    }
  }

  public void ToolDataToCamData(ToolBase5 Tool, ref camParameters5 varBU, ref GeoLib varMW)
  {
    if (!clsVar.varCam.CopyToolDataToCamData)
      return;
    varBU.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
    varBU.Speeds.SpindleDirection = Tool.CamData.SpindleDirection;
    if (Tool.CamData.FeedFromTool)
    {
      varMW.MachParam.FeedRate = Tool.CamData.FeedSpeed;
      varMW.MachParam.PlungeFeedRate = Tool.CamData.PlungeSpeed;
      varMW.MachParam.RetractFeedRate = Tool.CamData.RetractSpeed;
      varBU.Speeds.Feed = Tool.CamData.FeedSpeed;
      varBU.Speeds.Plunge = Tool.CamData.PlungeSpeed;
      varBU.Speeds.Leave = Tool.CamData.RetractSpeed;
      varBU.Speeds.Finish = Tool.CamData.FinishSpeed;
    }
    if (!Tool.CamData.DistanceFromTool)
      return;
    varMW.MachParam.FeedRate = Tool.CamData.RapidDistance;
    varMW.MachParam.PlungeFeedRate = Tool.CamData.SafeDistance;
    varMW.MachParam.RetractFeedRate = Tool.CamData.RetractSpeed;
    varBU.Distances.Safe = Tool.CamData.SafeDistance;
    varBU.Speeds.Rapid = Tool.CamData.RapidDistance;
    varBU.Speeds.Leave = Tool.CamData.RetractSpeed;
    varBU.Speeds.Finish = Tool.CamData.FinishSpeed;
  }

  public void CamDataToolData(camParameters5 varBU, ref ToolBase5 Tool)
  {
    if (!clsVar.varCam.CopyCamDataToToolData)
      return;
    if (varBU.Speeds.SpindleSpeed > 0.0)
      Tool.CamData.SpindleSpeed = varBU.Speeds.SpindleSpeed;
    Tool.CamData.SpindleDirection = varBU.Speeds.SpindleDirection;
    if (clsVar.varCam.CopyCamFeedToToolFeed && varBU.Speeds.Feed > 0.0)
      Tool.CamData.FeedSpeed = varBU.Speeds.Feed;
    if (clsVar.varCam.CopyCamPlungeFeedToToolPlungeFeed && varBU.Speeds.Plunge > 0.0)
      Tool.CamData.PlungeSpeed = varBU.Speeds.Plunge;
    if (!clsVar.varCam.CopyCamRetractFeedToToolRetractFeed || varBU.Speeds.Leave <= 0.0)
      return;
    Tool.CamData.LeaveSpeed = varBU.Speeds.Leave;
  }

  public void CamDataToolData(camParameters5 varBU, GeoLib varMW, ref ToolBase5 Tool)
  {
    if (!clsVar.varCam.CopyCamDataToToolData)
      return;
    if (varBU.Speeds.SpindleSpeed > 0.0)
      Tool.CamData.SpindleSpeed = varBU.Speeds.SpindleSpeed;
    Tool.CamData.SpindleDirection = varBU.Speeds.SpindleDirection;
    if (clsVar.varCam.CopyCamFeedToToolFeed && varMW.MachParam.FeedRate > 0.0)
      Tool.CamData.FeedSpeed = varMW.MachParam.FeedRate;
    if (clsVar.varCam.CopyCamPlungeFeedToToolPlungeFeed && varMW.MachParam.PlungeFeedRate > 0.0)
      Tool.CamData.PlungeSpeed = varMW.MachParam.PlungeFeedRate;
    if (!clsVar.varCam.CopyCamRetractFeedToToolRetractFeed || varMW.MachParam.RetractFeedRate <= 0.0)
      return;
    Tool.CamData.RetractSpeed = varMW.MachParam.RetractFeedRate;
  }

  public void CamEntitesToEntities(
    camTp Cam,
    CamEntitiesToEntitiesOption Option,
    ref CamEntitiesToEntities calcEntities)
  {
    if (!Option.AllAsSingle)
    {
      if (Option.G0EntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesG0.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesG0[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamG0;
          calcEntities.G0Entities.Add(entity);
        }
      }
      if (Option.G1EntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesG1.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesG1[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamG1;
          calcEntities.G1Entities.Add(entity);
        }
      }
      if (Option.LeaveEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesLeave.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesLeave[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamLeave;
          calcEntities.LeaveEntities.Add(entity);
        }
      }
      if (Option.PlungeEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesPlunge.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesPlunge[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamPlunge;
          calcEntities.PlungeEntities.Add(entity);
        }
      }
      if (Option.LeadInEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesLeadIn.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesLeadIn[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamLeadin;
          calcEntities.LeadInEntities.Add(entity);
        }
      }
      if (Option.LeadOutEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesLeadOut.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesLeadOut[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamLeadOut;
          calcEntities.LeadOutEntities.Add(entity);
        }
      }
      if (Option.MarkEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesMark.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesMark[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamMark;
          calcEntities.MarkEntities.Add(entity);
        }
      }
      if (!Option.OtherEntitiesEnable)
        return;
      for (int index = 0; index <= Cam.EntitiesOther.Count - 1; ++index)
      {
        Entity entity = buVector5.CopyEntities(Cam.EntitiesOther[index]);
        if (entity.EntityData != null)
          ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamOther;
        calcEntities.OtherEntities.Add(entity);
      }
    }
    else
    {
      if (Option.G0EntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesG0.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesG0[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamG0;
          calcEntities.AllEntities.Add(entity);
        }
      }
      if (Option.G1EntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesG1.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesG1[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamG1;
          calcEntities.AllEntities.Add(entity);
        }
      }
      if (Option.LeaveEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesLeave.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesLeave[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamLeave;
          calcEntities.AllEntities.Add(entity);
        }
      }
      if (Option.PlungeEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesPlunge.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesPlunge[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamPlunge;
          calcEntities.AllEntities.Add(entity);
        }
      }
      if (Option.LeadInEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesLeadIn.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesLeadIn[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamLeadin;
          calcEntities.AllEntities.Add(entity);
        }
      }
      if (Option.LeadOutEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesLeadOut.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesLeadOut[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamLeadOut;
          calcEntities.AllEntities.Add(entity);
        }
      }
      if (Option.MarkEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesMark.Count - 1; ++index)
        {
          Entity entity = buVector5.CopyEntities(Cam.EntitiesMark[index]);
          if (entity.EntityData != null)
            ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamMark;
          calcEntities.AllEntities.Add(entity);
        }
      }
      if (!Option.OtherEntitiesEnable)
        return;
      for (int index = 0; index <= Cam.EntitiesOther.Count - 1; ++index)
      {
        Entity entity = buVector5.CopyEntities(Cam.EntitiesOther[index]);
        if (entity.EntityData != null)
          ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.CamOther;
        calcEntities.AllEntities.Add(entity);
      }
    }
  }

  public void CamEntitesTobuEntities(
    camTp Cam,
    CamEntitiesToEntitiesOption Option,
    ref CamEntitiesTobuEntities calcEntities)
  {
    if (!Option.AllAsSingle)
    {
      if (Option.G0EntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesG0.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesG0[index], ref copiedEntity);
          if (copiedEntity != null)
            copiedEntity.typeDefination = entityTypeDefination.CamG0;
          if (Cam.EntitiesG0[index] is buArcCam && ((buArcCam) Cam.EntitiesG0[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.G0Entities.Add(copiedEntity);
        }
      }
      if (Option.G1EntitiesEnable)
      {
        if (Option.G1EntitiesFromOriginal & Cam.EntitiesG1Orj.Count > 0)
        {
          for (int index = 0; index <= Cam.EntitiesG1Orj.Count - 1; ++index)
          {
            buEntity copiedEntity = (buEntity) null;
            buEntity.Copy(Cam.EntitiesG1Orj[index], ref copiedEntity);
            if (copiedEntity != null)
              copiedEntity.typeDefination = entityTypeDefination.CamG1;
            if (Cam.EntitiesG1Orj[index] is buArcCam && ((buArcCam) Cam.EntitiesG1Orj[index]).isReverse)
              copiedEntity.sortDirection = entitySortDirection.Reverse;
            copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
            if (calcEntities.G1Entities.Count > 0)
            {
              Point3D pntStart = new Point3D();
              Point3D pntEnd1 = new Point3D();
              Point3D pntEnd2 = new Point3D();
              clsInit.cVector5.GetEntityEndPointByCamDirection(calcEntities.G1Entities[calcEntities.G1Entities.Count - 1], ref pntEnd2);
              clsInit.cVector5.GetEntityEndPointByCamDirection(copiedEntity, ref pntEnd1);
              clsInit.cVector5.GetEntityStartPointByCamDirection(copiedEntity, ref pntStart);
              if (!buCompare5.EQ(pntEnd2, pntStart) && buCompare5.EQ(pntEnd2, pntEnd1))
                copiedEntity.sortDirection = entitySortDirection.Reverse;
            }
            calcEntities.G1Entities.Add(copiedEntity);
          }
        }
        else
        {
          for (int index = 0; index <= Cam.EntitiesG1.Count - 1; ++index)
          {
            buEntity copiedEntity = (buEntity) null;
            buEntity.Copy(Cam.EntitiesG1[index], ref copiedEntity);
            if (copiedEntity != null)
            {
              copiedEntity.typeDefination = entityTypeDefination.CamG1;
              copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
            }
            if (Cam.EntitiesG1[index] is buArcCam && ((buArcCam) Cam.EntitiesG1[index]).isReverse)
              copiedEntity.sortDirection = entitySortDirection.Reverse;
            calcEntities.G1Entities.Add(copiedEntity);
          }
        }
      }
      if (Option.LeaveEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesLeave.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesLeave[index], ref copiedEntity);
          if (copiedEntity != null)
          {
            copiedEntity.typeDefination = entityTypeDefination.CamLeave;
            copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Leave;
          }
          if (Cam.EntitiesLeave[index] is buArcCam && ((buArcCam) Cam.EntitiesLeave[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.LeaveEntities.Add(copiedEntity);
        }
      }
      if (Option.PlungeEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesPlunge.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesPlunge[index], ref copiedEntity);
          if (copiedEntity != null)
            copiedEntity.typeDefination = entityTypeDefination.CamPlunge;
          copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Plunge;
          if (Cam.EntitiesPlunge[index] is buArcCam && ((buArcCam) Cam.EntitiesPlunge[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.PlungeEntities.Add(copiedEntity);
        }
      }
      if (Option.LeadInEntitiesEnable)
      {
        if (Option.G1EntitiesFromOriginal)
        {
          for (int index = 0; index <= Cam.EntitiesLeadIn.Count - 1; ++index)
          {
            buEntity copiedEntity = (buEntity) null;
            buEntity.Copy(Cam.EntitiesLeadIn[index], ref copiedEntity);
            if (copiedEntity != null)
              copiedEntity.typeDefination = entityTypeDefination.CamLeadin;
            copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
            if (Cam.EntitiesLeadIn[index] is buArcCam && ((buArcCam) Cam.EntitiesLeadIn[index]).isReverse)
              copiedEntity.sortDirection = entitySortDirection.Reverse;
            calcEntities.LeadInEntities.Add(copiedEntity);
          }
        }
        else
        {
          for (int index = 0; index <= Cam.EntitiesLeadIn.Count - 1; ++index)
          {
            List<Point3D> points = new List<Point3D>();
            points.AddRange((IEnumerable<Point3D>) ((IEnumerable<Point3D>) Cam.EntitiesLeadIn[index].Vertices).ToList<Point3D>());
            if (Cam.EntitiesLeadIn[index] is buArcCam && ((buArcCam) Cam.EntitiesLeadIn[index]).isReverse)
              points.Reverse();
            buLinearPath buLinearPath = new buLinearPath(points);
            if (buLinearPath != null)
              buLinearPath.typeDefination = entityTypeDefination.CamLeadin;
            buLinearPath.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
            calcEntities.LeadInEntities.Add((buEntity) buLinearPath);
          }
        }
      }
      if (Option.LeadOutEntitiesEnable)
      {
        if (Option.G1EntitiesFromOriginal)
        {
          for (int index = 0; index <= Cam.EntitiesLeadOut.Count - 1; ++index)
          {
            buEntity copiedEntity = (buEntity) null;
            buEntity.Copy(Cam.EntitiesLeadOut[index], ref copiedEntity);
            if (copiedEntity != null)
              copiedEntity.typeDefination = entityTypeDefination.CamLeadOut;
            copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
            if (Cam.EntitiesLeadOut[index] is buArcCam && ((buArcCam) Cam.EntitiesLeadOut[index]).isReverse)
              copiedEntity.sortDirection = entitySortDirection.Reverse;
            calcEntities.LeadOutEntities.Add(copiedEntity);
          }
        }
        else
        {
          for (int index = 0; index <= Cam.EntitiesLeadOut.Count - 1; ++index)
          {
            List<Point3D> points = new List<Point3D>();
            points.AddRange((IEnumerable<Point3D>) ((IEnumerable<Point3D>) Cam.EntitiesLeadOut[index].Vertices).ToList<Point3D>());
            if (Cam.EntitiesLeadOut[index] is buArcCam && ((buArcCam) Cam.EntitiesLeadOut[index]).isReverse)
              points.Reverse();
            buLinearPath buLinearPath = new buLinearPath(points);
            if (buLinearPath != null)
              buLinearPath.typeDefination = entityTypeDefination.CamLeadOut;
            buLinearPath.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
            calcEntities.LeadOutEntities.Add((buEntity) buLinearPath);
          }
        }
      }
      if (Option.MarkEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesMark.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesMark[index], ref copiedEntity);
          if (copiedEntity != null)
            copiedEntity.typeDefination = entityTypeDefination.CamMark;
          if (Cam.EntitiesMark[index] is buArcCam && ((buArcCam) Cam.EntitiesMark[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.MarkEntities.Add(copiedEntity);
        }
      }
      if (!Option.OtherEntitiesEnable)
        return;
      for (int index = 0; index <= Cam.EntitiesOther.Count - 1; ++index)
      {
        buEntity copiedEntity = (buEntity) null;
        buEntity.Copy(Cam.EntitiesOther[index], ref copiedEntity);
        if (copiedEntity != null)
          copiedEntity.typeDefination = entityTypeDefination.CamOther;
        if (Cam.EntitiesOther[index] is buArcCam && ((buArcCam) Cam.EntitiesOther[index]).isReverse)
          copiedEntity.sortDirection = entitySortDirection.Reverse;
        calcEntities.OtherEntities.Add(copiedEntity);
      }
    }
    else
    {
      if (Option.G0EntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesG0.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesG0[index], ref copiedEntity);
          if (copiedEntity != null)
            copiedEntity.typeDefination = entityTypeDefination.CamG0;
          if (Cam.EntitiesG0[index] is buArcCam && ((buArcCam) Cam.EntitiesG0[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.AllEntities.Add(copiedEntity);
        }
      }
      if (Option.G1EntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesG1.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesG1[index], ref copiedEntity);
          if (copiedEntity != null)
            copiedEntity.typeDefination = entityTypeDefination.CamG1;
          copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
          if (Cam.EntitiesG1[index] is buArcCam && ((buArcCam) Cam.EntitiesG1[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.AllEntities.Add(copiedEntity);
        }
      }
      if (Option.LeaveEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesLeave.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesLeave[index], ref copiedEntity);
          if (copiedEntity != null)
            copiedEntity.typeDefination = entityTypeDefination.CamLeave;
          copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Leave;
          if (Cam.EntitiesLeave[index] is buArcCam && ((buArcCam) Cam.EntitiesLeave[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.AllEntities.Add(copiedEntity);
        }
      }
      if (Option.PlungeEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesPlunge.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesPlunge[index], ref copiedEntity);
          if (copiedEntity != null)
            copiedEntity.typeDefination = entityTypeDefination.CamPlunge;
          copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Plunge;
          if (Cam.EntitiesPlunge[index] is buArcCam && ((buArcCam) Cam.EntitiesPlunge[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.AllEntities.Add(copiedEntity);
        }
      }
      if (Option.LeadInEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesLeadIn.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesLeadIn[index], ref copiedEntity);
          if (copiedEntity != null)
            copiedEntity.typeDefination = entityTypeDefination.CamLeadin;
          copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
          if (Cam.EntitiesLeadIn[index] is buArcCam && ((buArcCam) Cam.EntitiesLeadIn[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.AllEntities.Add(copiedEntity);
        }
      }
      if (Option.LeadOutEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesLeadOut.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesLeadOut[index], ref copiedEntity);
          if (copiedEntity != null)
            copiedEntity.typeDefination = entityTypeDefination.CamLeadOut;
          copiedEntity.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
          if (Cam.EntitiesLeadOut[index] is buArcCam && ((buArcCam) Cam.EntitiesLeadOut[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.AllEntities.Add(copiedEntity);
        }
      }
      if (Option.MarkEntitiesEnable)
      {
        for (int index = 0; index <= Cam.EntitiesMark.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(Cam.EntitiesMark[index], ref copiedEntity);
          if (copiedEntity != null)
            copiedEntity.typeDefination = entityTypeDefination.CamMark;
          if (Cam.EntitiesMark[index] is buArcCam && ((buArcCam) Cam.EntitiesMark[index]).isReverse)
            copiedEntity.sortDirection = entitySortDirection.Reverse;
          calcEntities.AllEntities.Add(copiedEntity);
        }
      }
      if (!Option.OtherEntitiesEnable)
        return;
      for (int index = 0; index <= Cam.EntitiesOther.Count - 1; ++index)
      {
        buEntity copiedEntity = (buEntity) null;
        buEntity.Copy(Cam.EntitiesOther[index], ref copiedEntity);
        if (copiedEntity != null)
          copiedEntity.typeDefination = entityTypeDefination.CamOther;
        if (Cam.EntitiesOther[index] is buArcCam && ((buArcCam) Cam.EntitiesOther[index]).isReverse)
          copiedEntity.sortDirection = entitySortDirection.Reverse;
        calcEntities.AllEntities.Add(copiedEntity);
      }
    }
  }

  public void OffsetEntities(
    List<buEntity> refEntities,
    double Offset,
    ref List<buEntity> OffsetedEntities,
    CamOpenContourType OpenOffsetType = CamOpenContourType.Center,
    CamClosedContourType ClosedOffsetType = CamClosedContourType.Outter)
  {
    List<Entity> copiedEntities = new List<Entity>();
    List<Entity> OffsetedEntities1 = new List<Entity>();
    buEntity.Copy(refEntities, ref copiedEntities);
    this.OffsetEntities(copiedEntities, Offset, ref OffsetedEntities1, OpenOffsetType, ClosedOffsetType);
    if (OffsetedEntities == null)
      OffsetedEntities = new List<buEntity>();
    OffsetedEntities.Clear();
    buEntity.Copy(OffsetedEntities1, ref OffsetedEntities);
  }

  public void OffsetEntities(
    List<Entity> refEntities,
    double Offset,
    ref List<Entity> OffsetedEntities,
    CamOpenContourType OpenOffsetType = CamOpenContourType.Center,
    CamClosedContourType ClosedOffsetType = CamClosedContourType.Outter)
  {
    MWCalculationOptions MWCalcOptions = new MWCalculationOptions();
    MWCalcOptions.NumberofAxis = 3;
    MWCalcOptions.CamWireframeType = CamWireFrameType.Contour;
    MWCalcOptions.Mode = CamMode.WireFrame;
    MWCalcOptions.DontApplyReset = true;
    MWCalcOptions.isBuWireframeCalculation = false;
    MWCalcOptions.AddToCamListInLocalCalculation = false;
    MWCalcOptions.AddToCamListInMWCalculation = false;
    MWCalcOptions.ShowLeadInOutPage = false;
    MWCalcOptions.DontShowDialogBox = true;
    ToolBase5 ToolSelected = new ToolBase5();
    ToolSelected.Purpose = ToolPurpose.Milling;
    ToolSelected.Geometry.GeometryType = buClass.ToolType.Flat;
    ToolSelected.Geometry.Diameter = Offset * 2.0;
    ToolSelected.Geometry.Length = 100.0;
    clsMW.CamEntities.Clear();
    buEntity.Copy(refEntities, ref clsMW.CamEntities);
    camParameters5 camParameters5 = new camParameters5();
    GeoLib MWPar = new GeoLib(Unit.Metric);
    camParameters5.Offsets.OpenContour = OpenOffsetType;
    camParameters5.Offsets.ClosedContour = ClosedOffsetType;
    camParameters5.Distances.Air = 0.0;
    camParameters5.Distances.Safe = 0.0;
    camParameters5.Distances.Rapid = 0.0;
    camParameters5.Distances.EntryAndExit = 0.0;
    camParameters5.Distances.EntryAndExit = 0.0;
    clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWCalcs.ConvertFromBuCamParToMwCamPar(MWPar, camParameters5), camParameters5, out clsMW.varbuCamWFContourPars);
    clsMW.varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = true;
    camResult Result = (camResult) null;
    camTp Cam = (camTp) null;
    clsInit.appMW.doWireframeContour(MWCalcOptions, ToolSelected, ref Cam, ref Result);
    OffsetedEntities = new List<Entity>();
    if (Cam == null)
      return;
    for (int index = 0; index <= Cam.EntitiesG1Orj.Count - 1; ++index)
    {
      Entity copiedEnt = (Entity) null;
      buVector5.CopyEntities(Cam.EntitiesG1Orj[index], ref copiedEnt);
      copiedEnt.EntityData = (object) new CustomData();
      OffsetedEntities.Add(copiedEnt);
    }
  }

  public void CreateToolWithToolDirection(
    ToolBase5 Tool,
    bool ToolCut,
    bool ToolBody,
    bool Arbor,
    bool Holder,
    bool ZeroIsMachineSide,
    ref List<Mesh> refMeshes)
  {
    this.CreateTool(Tool, ToolCut, ToolBody, Arbor, Holder, ref refMeshes);
    if (Tool.Geometry.ToolDirection.Z == 1.0)
    {
      for (int index = 0; index <= refMeshes.Count - 1; ++index)
        refMeshes[index].Rotate(buConversion5.DegreeToRadian(180.0), new Vector3D(1.0, 0.0, 0.0));
    }
    if (Tool.Geometry.ToolDirection.X == 1.0)
    {
      for (int index = 0; index <= refMeshes.Count - 1; ++index)
        refMeshes[index].Rotate(buConversion5.DegreeToRadian(-90.0), new Vector3D(0.0, 1.0, 0.0));
    }
    if (Tool.Geometry.ToolDirection.X == -1.0)
    {
      for (int index = 0; index <= refMeshes.Count - 1; ++index)
        refMeshes[index].Rotate(buConversion5.DegreeToRadian(90.0), new Vector3D(0.0, 1.0, 0.0));
    }
    if (Tool.Geometry.ToolDirection.Y == 1.0)
    {
      for (int index = 0; index <= refMeshes.Count - 1; ++index)
        refMeshes[index].Rotate(buConversion5.DegreeToRadian(-90.0), new Vector3D(1.0, 0.0, 0.0));
    }
    if (Tool.Geometry.ToolDirection.Y == -1.0)
    {
      for (int index = 0; index <= refMeshes.Count - 1; ++index)
        refMeshes[index].Rotate(buConversion5.DegreeToRadian(90.0), new Vector3D(1.0, 0.0, 0.0));
    }
    if (!ZeroIsMachineSide)
      return;
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    clsInit.cVector5.BoxSizeCalculate(refMeshes, ref MinPoint, ref MidPoint, ref MaxPoint);
    if (Tool.Geometry.ToolDirection.Z == 1.0)
    {
      for (int index = 0; index <= refMeshes.Count - 1; ++index)
        refMeshes[index].Translate(0.0, 0.0, -MinPoint.Z);
    }
    if (Tool.Geometry.ToolDirection.Z == -1.0)
    {
      for (int index = 0; index <= refMeshes.Count - 1; ++index)
        refMeshes[index].Translate(0.0, 0.0, -MaxPoint.Z);
    }
    if (Tool.Geometry.ToolDirection.X == 1.0)
    {
      for (int index = 0; index <= refMeshes.Count - 1; ++index)
        refMeshes[index].Translate(-MinPoint.X, 0.0);
    }
    if (Tool.Geometry.ToolDirection.X == -1.0)
    {
      for (int index = 0; index <= refMeshes.Count - 1; ++index)
        refMeshes[index].Translate(-MaxPoint.X, 0.0);
    }
    if (Tool.Geometry.ToolDirection.Y == 1.0)
    {
      for (int index = 0; index <= refMeshes.Count - 1; ++index)
        refMeshes[index].Translate(0.0, -MaxPoint.Y);
    }
    if (Tool.Geometry.ToolDirection.Y != -1.0)
      return;
    for (int index = 0; index <= refMeshes.Count - 1; ++index)
      refMeshes[index].Translate(0.0, -MinPoint.Y);
  }

  public void CreateTool(
    ToolBase5 Tool,
    bool ToolCut,
    bool ToolBody,
    bool Arbor,
    bool Holder,
    ref List<Mesh> refMeshes)
  {
    ModuleWorks.Tool mwTool = (ModuleWorks.Tool) null;
    clsInit.cMwCalc.CreateMWTool(Tool, ref mwTool);
    if (ToolCut && mwTool != (ModuleWorks.Tool) null)
    {
      Mesh devDeptMesh = buMWCalcs.ConvertToDevDeptMesh(MeshHelper.CreateToolMeshD(mwTool, 0.01, ToolMeshType.CuttingPart));
      devDeptMesh.Color = Color.FromArgb(Tool.Display.ToolCutSolid.SkinTransperancy, Tool.Display.ToolCutSolid.SkinColor);
      devDeptMesh.ColorMethod = colorMethodType.byEntity;
      if (devDeptMesh.Vertices.Length > 1)
        refMeshes.Add(devDeptMesh);
    }
    if (ToolBody)
    {
      if (Tool.Geometry.GeometryType != buClass.ToolType.Slot & Tool.Geometry.GeometryType != buClass.ToolType.Saw)
      {
        if (mwTool != (ModuleWorks.Tool) null)
        {
          Mesh devDeptMesh = buMWCalcs.ConvertToDevDeptMesh(MeshHelper.CreateToolMeshD(mwTool, 0.01, ToolMeshType.NonCuttingPart));
          devDeptMesh.Color = Color.FromArgb(Tool.Display.ToolBodySolid.SkinTransperancy, Tool.Display.ToolBodySolid.SkinColor);
          devDeptMesh.ColorMethod = colorMethodType.byEntity;
          if (devDeptMesh.Vertices.Length > 1)
            refMeshes.Add(devDeptMesh);
        }
      }
      else if (Tool.Geometry.GeometryType == buClass.ToolType.Saw)
      {
        Mesh cylinder = Mesh.CreateCylinder(Tool.Geometry.DiameterBody, Tool.Geometry.Length, 20);
        cylinder.Color = Color.FromArgb(Tool.Display.ToolBodySolid.SkinTransperancy, Tool.Display.ToolBodySolid.SkinColor);
        cylinder.ColorMethod = colorMethodType.byEntity;
        if (cylinder.Vertices.Length > 1)
          refMeshes.Add(cylinder);
      }
      else if (Tool.Geometry.ShoulderLength > 0.0 & Tool.Geometry.ShoulderDiameter > 0.0 && mwTool != (ModuleWorks.Tool) null)
      {
        Mesh devDeptMesh = buMWCalcs.ConvertToDevDeptMesh(MeshHelper.CreateToolMeshD(mwTool, 0.01, ToolMeshType.NonCuttingPart));
        devDeptMesh.Color = Color.FromArgb(Tool.Display.ToolBodySolid.SkinTransperancy, Tool.Display.ToolBodySolid.SkinColor);
        devDeptMesh.ColorMethod = colorMethodType.byEntity;
        if (devDeptMesh.Vertices.Length > 1)
          refMeshes.Add(devDeptMesh);
      }
    }
    if (Arbor && mwTool != (ModuleWorks.Tool) null)
    {
      Mesh devDeptMesh = buMWCalcs.ConvertToDevDeptMesh(MeshHelper.CreateToolMeshD(mwTool, 0.01, ToolMeshType.Arbor));
      devDeptMesh.Color = Color.FromArgb(Tool.Display.ArborSolid.SkinTransperancy, Tool.Display.ArborSolid.SkinColor);
      devDeptMesh.ColorMethod = colorMethodType.byEntity;
      if (devDeptMesh.Vertices.Length > 1)
        refMeshes.Add(devDeptMesh);
    }
    if (!Holder || !(mwTool != (ModuleWorks.Tool) null))
      return;
    Mesh devDeptMesh1 = buMWCalcs.ConvertToDevDeptMesh(MeshHelper.CreateToolMeshD(mwTool, 0.01, ToolMeshType.Holder));
    devDeptMesh1.Color = Color.FromArgb(Tool.Display.HolderSolid.SkinTransperancy, Tool.Display.HolderSolid.SkinColor);
    devDeptMesh1.ColorMethod = colorMethodType.byEntity;
    if (devDeptMesh1.Vertices.Length <= 1)
      return;
    refMeshes.Add(devDeptMesh1);
  }
}
