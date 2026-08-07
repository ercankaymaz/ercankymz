// Decompiled with JetBrains decompiler
// Type: buMW.buMWCalcs
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using buMW.CamForms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW;

public class buMWCalcs
{
  public static bool AdvancedTriMesh;
  public static bool GetProgressUpdating;
  public static MWParameters varCamMeshRoughPars;
  public static MWParameters varCamMeshParalelPars;
  public static MWParameters varCamMeshContantZPars;
  public static MWParameters varCamMeshPencilPars;
  public static MWParameters varCamMeshProjectionPars;
  public static MWParameters varCamMeshFlatlandPars;
  public static MWParameters varCamMeshContantCuspPars;
  public static MWParameters varCamWFPocketPars;
  public static MWParameters varCamWFContourPars;
  public static MWParameters varCamWFContour4XPars;
  public static MWParameters varCamDrillPars;
  public static MWParameters varCamContouringPars;
  public static MWParameters varCamSurfacePars;
  public static MWParameters varCam3AXTo5AXPars;
  public static MWParameters varCamGeodesicPars;
  public static List<Entity> OrientationLines;
  public static List<Entity> CamEntities;
  public static List<List<Entity>> entityProjection;
  public buMWUpdateHandler updateHandler = (buMWUpdateHandler) null;
  public List<Meshd> Stock = (List<Meshd>) null;
  public GeoLib mwCamDataParameter = (GeoLib) null;
  public camParameters5 buCamDataParameter = (camParameters5) null;
  public buCamCalcSettings Settings = new buCamCalcSettings();
  public buCamCalcRuntimeSettings SettingsRuntime = new buCamCalcRuntimeSettings();
  public List<List<eEntities>> ProjectionCurves = new List<List<eEntities>>();
  public List<ModuleWorksMeshData> MeshEntities = new List<ModuleWorksMeshData>();

  public abstract void m000001();

  public buMWCalcs()
  {
    if (!buMWCalcs.\u0001(nameof (buMWCalcs)))
      throw new RegisterException(nameof (buMWCalcs));
    // ISSUE: reference to a compiler-generated field
    if (this.\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.\u0001(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.\u0002(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.\u0003 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.\u0003(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.\u0004 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.\u0004(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.\u0001(new CalculationErrorEventArg("", "", "", 0));
  }

  internal static bool \u0001([In] string obj0)
  {
    bool flag1;
    if (buVector5.AskMeResult != "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2" | buVector5.AskMeValue != -5861345679435.9121)
    {
      BinaryReader binaryReader = (BinaryReader) null;
      try
      {
        FileInfo fileInfo = new FileInfo(AppPath.Base + "\\mnbucfd.dll");
        if (!fileInfo.Exists)
          throw new RegisterException(obj0);
        if (fileInfo.Exists)
        {
          List<double> doubleList = new List<double>();
          List<string> stringList1 = new List<string>();
          List<string> stringList2 = new List<string>();
          bool flag2;
          bool flag3;
          try
          {
            buLogVer5.addToLog("DefK", "Mode 12100", "mnb", "1", 0.0, 0.0);
            binaryReader = new BinaryReader((Stream) new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.None));
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            string str10 = "";
            string str11 = "";
            string str12 = "";
            string str13 = "";
            string str14 = "";
            Decimal num1 = 0M;
            for (int index = 0; index < 755; ++index)
            {
              double num2 = (double) binaryReader.ReadSingle();
            }
            for (int index = 0; index < 1274; ++index)
              binaryReader.ReadDouble();
            for (int index = 0; index < 1498; ++index)
              num1 = binaryReader.ReadDecimal();
            for (int index = 0; index < 5614; ++index)
            {
              double num3 = (double) binaryReader.ReadInt32();
            }
            for (int index = 0; index < 4243; ++index)
            {
              double num4 = (double) binaryReader.ReadSingle();
            }
            for (int index = 0; index < 9867; ++index)
              binaryReader.ReadDouble();
            for (int index = 0; index < 3886; ++index)
              num1 = binaryReader.ReadDecimal();
            for (int index = 0; index < 5765; ++index)
            {
              double num5 = (double) binaryReader.ReadInt32();
            }
            int num6 = binaryReader.ReadInt32();
            doubleList.Clear();
            stringList1.Clear();
            stringList2.Clear();
            for (int index1 = 0; index1 <= num6 - 1; ++index1)
            {
              double num7 = binaryReader.ReadDouble() / 65.87;
              doubleList.Add(num7);
              int num8 = binaryReader.ReadInt32();
              string str15 = "";
              for (int index2 = 0; index2 < num8; ++index2)
              {
                byte num9 = Convert.ToByte(binaryReader.ReadDouble() / 46.8613);
                str15 += Convert.ToChar(num9).ToString();
              }
              stringList1.Add(str15);
              int num10 = binaryReader.ReadInt32();
              string str16 = "";
              for (int index3 = 0; index3 < num10; ++index3)
              {
                byte num11 = Convert.ToByte(binaryReader.ReadDouble() / 86.3456);
                str16 += Convert.ToChar(num11).ToString();
              }
              stringList2.Add(str16);
            }
            int num12 = binaryReader.ReadInt32();
            for (int index = 0; index < num12; ++index)
            {
              byte num13 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              str1 += Convert.ToChar(num13).ToString();
            }
            int num14 = binaryReader.ReadInt32();
            for (int index = 0; index < num14; ++index)
            {
              byte num15 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              str2 += Convert.ToChar(num15).ToString();
            }
            int num16 = binaryReader.ReadInt32();
            for (int index = 0; index < num16; ++index)
            {
              byte num17 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              str3 += Convert.ToChar(num17).ToString();
            }
            int num18 = binaryReader.ReadInt32();
            for (int index = 0; index < num18; ++index)
            {
              byte num19 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              str4 += Convert.ToChar(num19).ToString();
            }
            int num20 = binaryReader.ReadInt32();
            for (int index = 0; index < num20; ++index)
            {
              byte num21 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              str5 += Convert.ToChar(num21).ToString();
            }
            int num22 = binaryReader.ReadInt32();
            for (int index = 0; index < num22; ++index)
            {
              byte num23 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              str6 += Convert.ToChar(num23).ToString();
            }
            int num24 = binaryReader.ReadInt32();
            for (int index = 0; index < num24; ++index)
            {
              byte num25 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              str7 += Convert.ToChar(num25).ToString();
            }
            int num26 = binaryReader.ReadInt32();
            for (int index = 0; index < num26; ++index)
            {
              byte num27 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              str8 += Convert.ToChar(num27).ToString();
            }
            int num28 = binaryReader.ReadInt32();
            for (int index = 0; index < num28; ++index)
            {
              byte num29 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              str9 += Convert.ToChar(num29).ToString();
            }
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            int num30 = binaryReader.ReadInt32();
            for (int index = 0; index < num30; ++index)
            {
              byte num31 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
              str10 += Convert.ToChar(num31).ToString();
            }
            int num32 = binaryReader.ReadInt32();
            for (int index = 0; index < num32; ++index)
            {
              byte num33 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
              str11 += Convert.ToChar(num33).ToString();
            }
            int num34 = binaryReader.ReadInt32();
            for (int index = 0; index < num34; ++index)
            {
              byte num35 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
              str12 += Convert.ToChar(num35).ToString();
            }
            int num36 = binaryReader.ReadInt32();
            for (int index = 0; index < num36; ++index)
            {
              byte num37 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
              str13 += Convert.ToChar(num37).ToString();
            }
            int num38 = binaryReader.ReadInt32();
            for (int index = 0; index < num38; ++index)
            {
              byte num39 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
              str14 += Convert.ToChar(num39).ToString();
            }
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            flag2 = binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            flag3 = binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.Close();
            buLogVer5.addToLog("DefK", "Mode 12101", "mnb", "100", 0.0, 0.0);
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show(ex.Message);
            binaryReader.Close();
            throw new RegisterException(obj0);
          }
          List<string> MacAddress = new List<string>();
          List<string> CpuAddress = new List<string>();
          string MBAddress = "";
          buVector5.getMacAddress(ref MacAddress);
          buLogVer5.addToLog("DefK", "Mode 12102", "mnb", "100", 0.0, 0.0);
          buVector5.getCpuID(ref CpuAddress);
          buLogVer5.addToLog("DefK", "Mode 12103", "mnb", "100", 0.0, 0.0);
          buVector5.GetMotherBoardID(ref MBAddress);
          buLogVer5.addToLog("DefK", "Mode 12104", "mnb", "100", 0.0, 0.0);
          if (!flag2 & !flag3)
          {
            bool flag4 = \u0005.\u0002.\u0001(MacAddress, CpuAddress, obj0, MBAddress, doubleList);
            buLogVer5.addToLog("DefK", "Mode 12104", "mnb", "100", 0.0, 0.0);
            if (flag4)
            {
              flag1 = true;
              goto label_90;
            }
          }
          throw new RegisterException(obj0);
        }
        throw new RegisterException(obj0);
      }
      catch (Exception ex)
      {
        throw new RegisterException(obj0);
      }
    }
    else
      flag1 = true;
label_90:
    return flag1;
  }

  public event CalculationEventHandler CalculationInProgressMwCalc;

  public event CalculationEventHandler CalculationStarted;

  public event CalculationEventHandler CalculationEnded;

  public event CalculationEventHandler CalculationCanceled;

  public event CalculationErrorEventHandler CalculationError;

  public event MWCalculationResultHandler GetCalculations;

  public void Init()
  {
    this.updateHandler.CalculationUpdate += new MWCalculationUpdateHandler(this.GetProgress);
  }

  public bool CalculateWireframe(
    ToolBase5 Tool,
    List<buMWCurveEntities> CurveEntities,
    WireframeBasedTpCalcParamsPattern CalcType,
    MWCalculationOptions Option,
    ref MWCalculationResult camResult)
  {
    try
    {
      if (this.mwCamDataParameter == null)
        return false;
      if (this.updateHandler == null)
      {
        this.updateHandler = (buMWUpdateHandler) new MWCalculationResult();
        this.updateHandler.CalculationUpdate += new MWCalculationUpdateHandler(this.GetProgress);
      }
      ModuleWorks.Tool mwTool = (ModuleWorks.Tool) null;
      GeoLib geoLib = new GeoLib(Unit.Metric);
      buMWUpdateHandler.CancelOperation = false;
      if (this.CreateMWTool(Tool, ref mwTool) != 1)
        return false;
      geoLib.ToolInfo = mwTool;
      geoLib.MachParam = new MachiningParams(this.mwCamDataParameter.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.mwCamDataParameter, geoLib);
      geoLib.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmWireframeBased;
      geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.Pattern = CalcType;
      geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType3axis;
      geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.StartFromPosition = WireframeBasedTpCalcParamsStartFromPosition.SfpUserDefinedStartPoint;
      if (Option.is5AxisWireframe)
      {
        geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
        geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.Pattern = WireframeBasedTpCalcParamsPattern.Wfb5axisProfiling;
      }
      List<Point3d<double>> point3dList = new List<Point3d<double>>();
      if (Option.UseConstantStartPoint)
        point3dList.Add(new Point3d<double>(Option.StartPointX, Option.StartPointY, 0.0));
      List<ModuleWorks.Curve> curveList1 = new List<ModuleWorks.Curve>();
      for (int index1 = 0; index1 <= CurveEntities.Count - 1; ++index1)
      {
        if (Option.UseEachCurveStartPoint)
          point3dList.Add(new Point3d<double>(((buMWUpdateHandler) CurveEntities[index1]).pntStart));
        for (int index2 = 0; index2 <= CurveEntities[index1].CurveList.Count - 1; ++index2)
        {
          if (CurveEntities[index1].CurveList[index2] != null)
          {
            ModuleWorks.Curve curve = new ModuleWorks.Curve(CurveEntities[index1].CurveList[index2]);
            if (Option.Reverse)
              curve.Reverse();
            curveList1.Add(curve);
          }
        }
      }
      if (point3dList.Count == 0)
        point3dList.Add(new Point3d<double>(0.0, 0.0, 0.0));
      List<ModuleWorks.Curve> curveList2 = new List<ModuleWorks.Curve>();
      if (buMWCalcs.OrientationLines.Count > 0)
      {
        for (int index = 0; index <= buMWCalcs.OrientationLines.Count - 1; ++index)
        {
          ModuleWorks.Curve mwEntity = (ModuleWorks.Curve) null;
          buMWCalcs.ConvertWireEntity(buMWCalcs.OrientationLines[index], ref mwEntity);
          curveList2.Add(mwEntity);
        }
      }
      geoLib.StartPoints = (IEnumerable<Point3d<double>>) point3dList;
      geoLib.MachParam.StartPosFlag = Option.UseStartPoint;
      geoLib.DriveCurves = (IEnumerable<ModuleWorks.Curve>) curveList1;
      if (curveList2.Count > 0)
        geoLib.OrientationLines = (IEnumerable<ModuleWorks.Curve>) curveList2;
      geoLib.SetUpdateHandler((UpdateHandler) this.updateHandler);
      if (Option.CamWireframeType == CamWireFrameType.Contour)
      {
        if (!this.buCamDataParameter.Operations.isClosed)
        {
          geoLib.MachParam.MachDirForOneWay = MachiningParamsDirection.DirClimb;
          geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter ? CutterRadiusCompParamsCompensationType.CtInComputer : CutterRadiusCompParamsCompensationType.CtOff;
          if (geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide == WireframeBasedTpCalcParamsCuttingSide.WfbCsRight)
            geoLib.MachParam.MachDirForOneWay = MachiningParamsDirection.DirConventional;
        }
        else if (this.buCamDataParameter.Offsets.ClosedContour == CamClosedContourType.Center)
        {
          geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
          geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
        }
        else if (this.buCamDataParameter.Offsets.ClosedContour == CamClosedContourType.Inner)
        {
          geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInComputer;
          if (this.buCamDataParameter.Operations.Direction == ClockDirectionType.CW)
          {
            geoLib.MachParam.MachDirForOneWay = MachiningParamsDirection.DirConventional;
            geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsRight;
          }
          else
          {
            geoLib.MachParam.MachDirForOneWay = MachiningParamsDirection.DirClimb;
            geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft;
          }
        }
        else if (this.buCamDataParameter.Offsets.ClosedContour == CamClosedContourType.Outter)
        {
          geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInComputer;
          if (this.buCamDataParameter.Operations.Direction == ClockDirectionType.CW)
          {
            geoLib.MachParam.MachDirForOneWay = MachiningParamsDirection.DirClimb;
            geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft;
          }
          else
          {
            geoLib.MachParam.MachDirForOneWay = MachiningParamsDirection.DirConventional;
            geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsRight;
          }
        }
      }
      else if (Option.CamWireframeType == CamWireFrameType.CenterPath)
      {
        geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
        geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
      }
      geoLib.MachParam.LinkParams.FirstEntry.LeadController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LastExit.LeadController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      \u0002.\u0001 interactor = new \u0002.\u0001(Unit.Metric);
      MachiningParameterDialog machiningParameterDialog = new MachiningParameterDialog(geoLib, (ParamInteractor) interactor);
      bool flag = true;
      if (this.Settings.ShowMwDialogBox)
        flag = machiningParameterDialog.Show();
      if (!flag)
        return false;
      // ISSUE: reference to a compiler-generated field
      if (this.\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.\u0002(new CalculationEventArg()
        {
          ShowForm = Option.ShowProgressForm
        });
      }
      geoLib.Serialize(Application.StartupPath + "\\mwResult.bin");
      CollisionsReport collReport = new CollisionsReport();
      geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide.ToString();
      geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType.ToString();
      geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.Pattern.ToString();
      ToolPath copy = geoLib.CalcToolPath(collReport);
      camResult = (MWCalculationResult) new MWIterationOption();
      camResult.ToolPathCalc = new ToolPath(copy);
      camResult.Tool = new ToolBase5(Tool);
      camResult.geoLib = new GeoLib(geoLib.Units, 0);
      camResult.geoLib.MachParam = new MachiningParams(geoLib.MachParam);
      buMWCalcs.CopyGeoLibProperties(geoLib, camResult.geoLib);
      ((MWIterationOption) camResult).buCamParamters = new camParameters5(this.buCamDataParameter);
      camResult.Tool.CamData.SpindleSpeed = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleSpeed;
      camResult.Tool.CamData.SpindleDirection = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleDirection;
      geoLib.Dispose();
      return true;
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return false;
    }
  }

  public bool CalculateTriangleMesh(
    ToolBase5 Tool,
    List<Meshd> MeshEntities,
    List<buMWCurveEntities> Curve2dContainment,
    TriangleMeshBasedTpCalcParamsPattern CalcType,
    MWCalculationOptions Option,
    ref MWCalculationResult camResult)
  {
    try
    {
      if (this.mwCamDataParameter == null)
        return false;
      if (this.updateHandler == null)
      {
        this.updateHandler = (buMWUpdateHandler) new MWCalculationResult();
        this.updateHandler.CalculationUpdate += new MWCalculationUpdateHandler(this.GetProgress);
      }
      ModuleWorks.Tool mwTool = (ModuleWorks.Tool) null;
      GeoLib geoLib = new GeoLib(Unit.Metric);
      buMWUpdateHandler.CancelOperation = false;
      if (this.CreateMWTool(Tool, ref mwTool) != 1)
        return false;
      geoLib.ToolInfo = mwTool;
      geoLib.MachParam = new MachiningParams(this.mwCamDataParameter.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.mwCamDataParameter, geoLib);
      geoLib.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmTriangleMeshBased;
      geoLib.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern = CalcType;
      geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType3axis;
      if (Option.NumberofAxis == 4 & CalcType != 0)
        geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType4axis;
      if (Option.NumberofAxis == 5)
        geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
      List<Point3d<double>> point3dList = new List<Point3d<double>>();
      if (Option.UseConstantStartPoint)
        point3dList.Add(new Point3d<double>(Option.StartPointX, Option.StartPointY, 0.0));
      if (point3dList.Count > 0)
      {
        geoLib.StartPoints = (IEnumerable<Point3d<double>>) point3dList;
        geoLib.MachParam.StartPosFlag = true;
      }
      else
        geoLib.MachParam.StartPosFlag = false;
      geoLib.MachiningSurfaces = (IEnumerable<Meshd>) MeshEntities;
      if (this.Stock != null)
        geoLib.StockDefinition = (IEnumerable<Meshd>) this.Stock;
      List<ModuleWorks.Curve> curveList1 = new List<ModuleWorks.Curve>();
      for (int index1 = 0; index1 <= Curve2dContainment.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= Curve2dContainment[index1].CurveList.Count - 1; ++index2)
        {
          if (Curve2dContainment[index1].CurveList[index2] != null)
          {
            ModuleWorks.Curve curve = new ModuleWorks.Curve(Curve2dContainment[index1].CurveList[index2]);
            if (Option.Reverse)
              curve.Reverse();
            curveList1.Add(curve);
          }
        }
      }
      geoLib.ContainmentCurves2d = (IEnumerable<ModuleWorks.Curve>) curveList1;
      geoLib.UserDefinedContainment = (IEnumerable<ModuleWorks.Curve>) curveList1;
      List<ModuleWorks.Curve> curveList2 = new List<ModuleWorks.Curve>();
      for (int index3 = 0; index3 <= Curve2dContainment.Count - 1; ++index3)
      {
        if (Option.UseEachCurveStartPoint)
          point3dList.Add(new Point3d<double>(((buMWUpdateHandler) Curve2dContainment[index3]).pntStart));
        for (int index4 = 0; index4 <= Curve2dContainment[index3].CurveList.Count - 1; ++index4)
        {
          if (Curve2dContainment[index3].CurveList[index4] != null)
          {
            ModuleWorks.Curve curve = new ModuleWorks.Curve(Curve2dContainment[index3].CurveList[index4]);
            if (Option.Reverse)
              curve.Reverse();
            curveList2.Add(curve);
          }
        }
      }
      geoLib.DriveCurves = (IEnumerable<ModuleWorks.Curve>) curveList2;
      geoLib.SetUpdateHandler((UpdateHandler) this.updateHandler);
      geoLib.MachParam.LinkParams.FirstEntry.LeadController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LastExit.LeadController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      \u0002.\u0001 interactor = new \u0002.\u0001(Unit.Metric);
      MachiningParameterDialog machiningParameterDialog = new MachiningParameterDialog(geoLib, (ParamInteractor) interactor);
      bool flag = true;
      if (this.Settings.ShowMwDialogBox)
        flag = machiningParameterDialog.Show();
      if (!flag)
        return false;
      // ISSUE: reference to a compiler-generated field
      if (this.\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.\u0002(new CalculationEventArg());
      }
      this.Settings.ShowProgressForm = Option.ShowProgressForm;
      geoLib.Serialize(Application.StartupPath + "\\mwResult.bin");
      CollisionsReport collReport = new CollisionsReport();
      ToolPath copy = geoLib.CalcToolPath(collReport);
      geoLib.Serialize(Application.StartupPath + "\\mwResult2.bin");
      camResult = (MWCalculationResult) new MWIterationOption();
      camResult.ToolPathCalc = new ToolPath(copy);
      camResult.Tool = new ToolBase5(Tool);
      camResult.geoLib = new GeoLib(geoLib.Units);
      camResult.geoLib.MachParam = new MachiningParams(geoLib.MachParam);
      buMWCalcs.CopyGeoLibProperties(geoLib, camResult.geoLib);
      ((MWIterationOption) camResult).buCamParamters = new camParameters5(this.buCamDataParameter);
      camResult.Tool.CamData.SpindleSpeed = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleSpeed;
      camResult.Tool.CamData.SpindleDirection = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleDirection;
      geoLib.Dispose();
      return true;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
      return false;
    }
  }

  public bool CalculateGeodesic(
    ToolBase5 Tool,
    List<Meshd> MeshEntities,
    List<buMWCurveEntities> Curve2dContainment,
    TriangleMeshBasedTpCalcParamsPattern CalcType,
    MWCalculationOptions Option,
    ref MWCalculationResult camResult)
  {
    try
    {
      if (this.mwCamDataParameter == null)
        return false;
      if (this.updateHandler == null)
      {
        this.updateHandler = (buMWUpdateHandler) new MWCalculationResult();
        this.updateHandler.CalculationUpdate += new MWCalculationUpdateHandler(this.GetProgress);
      }
      ModuleWorks.Tool mwTool = (ModuleWorks.Tool) null;
      GeoLib geoLib = new GeoLib(Unit.Metric, 1);
      buMWUpdateHandler.CancelOperation = false;
      if (this.CreateMWTool(Tool, ref mwTool) != 1)
        return false;
      geoLib.ToolInfo = mwTool;
      geoLib.MachParam = new MachiningParams(this.mwCamDataParameter.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.mwCamDataParameter, geoLib);
      geoLib.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmGeodesicMachiningBased;
      geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType3axis;
      if (Option.NumberofAxis == 4)
        geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType4axis;
      if (Option.NumberofAxis == 5)
        geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
      List<Point3d<double>> point3dList = new List<Point3d<double>>();
      if (Option.UseConstantStartPoint)
        point3dList.Add(new Point3d<double>(Option.StartPointX, Option.StartPointY, 0.0));
      if (point3dList.Count > 0)
      {
        geoLib.StartPoints = (IEnumerable<Point3d<double>>) point3dList;
        geoLib.MachParam.StartPosFlag = true;
      }
      else
        geoLib.MachParam.StartPosFlag = false;
      geoLib.MachiningSurfaces = (IEnumerable<Meshd>) MeshEntities;
      if (this.Stock != null)
        geoLib.StockDefinition = (IEnumerable<Meshd>) this.Stock;
      List<ModuleWorks.Curve> curveList1 = new List<ModuleWorks.Curve>();
      for (int index1 = 0; index1 <= Curve2dContainment.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= Curve2dContainment[index1].CurveList.Count - 1; ++index2)
        {
          if (Curve2dContainment[index1].CurveList[index2] != null)
          {
            ModuleWorks.Curve curve = new ModuleWorks.Curve(Curve2dContainment[index1].CurveList[index2]);
            if (Option.Reverse)
              curve.Reverse();
            curveList1.Add(curve);
          }
        }
      }
      geoLib.ContainmentCurves2d = (IEnumerable<ModuleWorks.Curve>) curveList1;
      geoLib.UserDefinedContainment = (IEnumerable<ModuleWorks.Curve>) curveList1;
      List<ModuleWorks.Curve> curveList2 = new List<ModuleWorks.Curve>();
      for (int index3 = 0; index3 <= Curve2dContainment.Count - 1; ++index3)
      {
        if (Option.UseEachCurveStartPoint)
          point3dList.Add(new Point3d<double>(((buMWUpdateHandler) Curve2dContainment[index3]).pntStart));
        for (int index4 = 0; index4 <= Curve2dContainment[index3].CurveList.Count - 1; ++index4)
        {
          if (Curve2dContainment[index3].CurveList[index4] != null)
          {
            ModuleWorks.Curve curve = new ModuleWorks.Curve(Curve2dContainment[index3].CurveList[index4]);
            if (Option.Reverse)
              curve.Reverse();
            curveList2.Add(curve);
          }
        }
      }
      geoLib.DriveCurves = (IEnumerable<ModuleWorks.Curve>) curveList2;
      geoLib.SetUpdateHandler((UpdateHandler) this.updateHandler);
      geoLib.MachParam.LinkParams.FirstEntry.LeadController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LastExit.LeadController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      \u0002.\u0001 interactor = new \u0002.\u0001(Unit.Metric);
      MachiningParameterDialog machiningParameterDialog = new MachiningParameterDialog(geoLib, (ParamInteractor) interactor);
      bool flag = true;
      if (this.Settings.ShowMwDialogBox)
        flag = machiningParameterDialog.Show();
      if (!flag)
        return false;
      // ISSUE: reference to a compiler-generated field
      if (this.\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.\u0002(new CalculationEventArg());
      }
      this.Settings.ShowProgressForm = Option.ShowProgressForm;
      geoLib.Serialize(Application.StartupPath + "\\mwResult.bin");
      CollisionsReport collReport = new CollisionsReport();
      ToolPath copy = geoLib.CalcToolPath(collReport);
      camResult = (MWCalculationResult) new MWIterationOption();
      camResult.ToolPathCalc = new ToolPath(copy);
      camResult.Tool = new ToolBase5(Tool);
      camResult.geoLib = new GeoLib(geoLib.Units, 0);
      camResult.geoLib.MachParam = new MachiningParams(geoLib.MachParam);
      buMWCalcs.CopyGeoLibProperties(geoLib, camResult.geoLib);
      ((MWIterationOption) camResult).buCamParamters = new camParameters5(this.buCamDataParameter);
      camResult.Tool.CamData.SpindleSpeed = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleSpeed;
      camResult.Tool.CamData.SpindleDirection = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleDirection;
      geoLib.Dispose();
      return true;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
      return false;
    }
  }

  public bool CalculateDrill(
    ToolBase5 Tool,
    List<Pnt3D> Points,
    DrillingBasedTpCalcParamsPattern CalcType,
    MWCalculationOptions Option,
    ref MWCalculationResult camResult)
  {
    bool drill;
    if (this.mwCamDataParameter == null)
    {
      drill = false;
    }
    else
    {
      ModuleWorks.Tool mwTool = (ModuleWorks.Tool) null;
      GeoLib geoLib = new GeoLib(Unit.Metric, 1);
      buMWUpdateHandler.CancelOperation = false;
      if (this.CreateMWTool(Tool, ref mwTool) == 1)
      {
        geoLib.ToolInfo = mwTool;
        geoLib.MachParam = new MachiningParams(this.mwCamDataParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(this.mwCamDataParameter, geoLib);
        geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType3axis;
        geoLib.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.StartFromPosition = WireframeBasedTpCalcParamsStartFromPosition.SfpUserDefinedStartPoint;
        geoLib.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmDrillingBased;
        geoLib.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.Pattern = DrillingBasedTpCalcParamsPattern.TcDbPoints;
        geoLib.DrillPoints = (IEnumerable<Point3d<double>>) new List<Point3d<double>>()
        {
          new Point3d<double>(100.0, 120.0, 0.0)
        };
        F_DrillLine fDrillLine = new F_DrillLine()
        {
          mwCamParameter = new GeoLib(geoLib.Units, 0)
        };
        fDrillLine.mwCamParameter.MachParam = new MachiningParams(geoLib.MachParam);
        buMWCalcs.CopyGeoLibProperties(geoLib, fDrillLine.mwCamParameter);
        fDrillLine.mwCamParameter.TabsPoints = geoLib.TabsPoints;
        fDrillLine.buCamParameter = new camParameters5(this.buCamDataParameter);
        fDrillLine.Init();
        int num = (int) fDrillLine.ShowDialog();
        if (fDrillLine.PropertiesForm.Result == DialogResult.OK)
        {
          geoLib.MachParam = new MachiningParams(fDrillLine.mwCamParameter.MachParam);
          buMWCalcs.CopyGeoLibProperties(fDrillLine.mwCamParameter, geoLib);
          this.buCamDataParameter = new camParameters5(fDrillLine.buCamParameter);
          List<ModuleWorks.Curve> curveList = new List<ModuleWorks.Curve>();
          for (int index = 0; index <= Points.Count - 1; ++index)
            curveList.Add(ModuleWorks.Curve.FromLine(new Point3d<double>(Points[index].X, Points[index].Y, this.buCamDataParameter.Steps.StartValue), new Point3d<double>(Points[index].X, Points[index].Y, this.buCamDataParameter.Steps.EndValue)));
          geoLib.DrillHoleLines = (IEnumerable<ModuleWorks.Curve>) curveList;
          geoLib.SetUpdateHandler((UpdateHandler) this.updateHandler);
          \u0002.\u0001 interactor = new \u0002.\u0001(Unit.Metric);
          MachiningParameterDialog machiningParameterDialog = new MachiningParameterDialog(geoLib, (ParamInteractor) interactor);
          bool flag = true;
          if (this.Settings.ShowMwDialogBox)
            flag = machiningParameterDialog.Show();
          if (flag)
          {
            // ISSUE: reference to a compiler-generated field
            if (this.\u0002 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.\u0002(new CalculationEventArg());
            }
            geoLib.Serialize(Application.StartupPath + "\\mwResult.bin");
            CollisionsReport collReport = new CollisionsReport();
            ToolPath copy = geoLib.CalcToolPath(collReport);
            camResult = (MWCalculationResult) new MWIterationOption();
            camResult.ToolPathCalc = new ToolPath(copy);
            camResult.Tool = new ToolBase5(Tool);
            camResult.geoLib = new GeoLib(geoLib.Units, 0);
            camResult.geoLib.MachParam = new MachiningParams(geoLib.MachParam);
            buMWCalcs.CopyGeoLibProperties(geoLib, camResult.geoLib);
            ((MWIterationOption) camResult).buCamParamters = new camParameters5(this.buCamDataParameter);
            camResult.Tool.CamData.SpindleSpeed = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleSpeed;
            camResult.Tool.CamData.SpindleDirection = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleDirection;
            geoLib.Dispose();
            drill = true;
          }
          else
            drill = false;
        }
        else
          drill = false;
      }
      else
        drill = false;
    }
    return drill;
  }

  public bool CalculateContouring(
    ToolBase5 Tool,
    List<Meshd> SurfaceEntities,
    List<buMWCurveEntities> EdgeCurves,
    TriangleMeshBasedTpCalcParamsPattern CalcType,
    MWCalculationOptions Option,
    ref MWCalculationResult camResult)
  {
    try
    {
      if (this.mwCamDataParameter == null)
        return false;
      if (this.updateHandler == null)
      {
        this.updateHandler = (buMWUpdateHandler) new MWCalculationResult();
        this.updateHandler.CalculationUpdate += new MWCalculationUpdateHandler(this.GetProgress);
      }
      ModuleWorks.Tool mwTool = (ModuleWorks.Tool) null;
      GeoLib geoLib = new GeoLib(Unit.Metric, 1);
      buMWUpdateHandler.CancelOperation = false;
      if (this.CreateMWTool(Tool, ref mwTool) != 1)
        return false;
      geoLib.ToolInfo = mwTool;
      geoLib.MachParam = new MachiningParams(this.mwCamDataParameter.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.mwCamDataParameter, geoLib);
      geoLib.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmContouringBased;
      geoLib.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern = CalcType;
      geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType3axis;
      geoLib.MachiningSurfaces = (IEnumerable<Meshd>) SurfaceEntities;
      if (this.Stock != null)
        geoLib.StockDefinition = (IEnumerable<Meshd>) this.Stock;
      List<ModuleWorks.Curve> curveList = new List<ModuleWorks.Curve>();
      for (int index1 = 0; index1 <= EdgeCurves.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= EdgeCurves[index1].CurveList.Count - 1; ++index2)
        {
          if (EdgeCurves[index1].CurveList[index2] != null)
          {
            ModuleWorks.Curve curve = new ModuleWorks.Curve(EdgeCurves[index1].CurveList[index2]);
            if (Option.Reverse)
              curve.Reverse();
            curveList.Add(curve);
          }
        }
      }
      geoLib.EdgeCurves = (IEnumerable<ModuleWorks.Curve>) curveList;
      geoLib.SetUpdateHandler((UpdateHandler) this.updateHandler);
      geoLib.MachParam.LinkParams.FirstEntry.LeadController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LastExit.LeadController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
      geoLib.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
      \u0002.\u0001 interactor = new \u0002.\u0001(Unit.Metric);
      MachiningParameterDialog machiningParameterDialog = new MachiningParameterDialog(geoLib, (ParamInteractor) interactor);
      bool flag = true;
      if (this.Settings.ShowMwDialogBox)
        flag = machiningParameterDialog.Show();
      if (!flag)
        return false;
      // ISSUE: reference to a compiler-generated field
      if (this.\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.\u0002(new CalculationEventArg());
      }
      geoLib.Serialize(Application.StartupPath + "\\mwResult.bin");
      CollisionsReport collReport = new CollisionsReport();
      ToolPath copy = geoLib.CalcToolPath(collReport);
      camResult = (MWCalculationResult) new MWIterationOption();
      camResult.ToolPathCalc = new ToolPath(copy);
      camResult.Tool = new ToolBase5(Tool);
      camResult.geoLib = new GeoLib(geoLib.Units, 0);
      camResult.geoLib.MachParam = new MachiningParams(geoLib.MachParam);
      buMWCalcs.CopyGeoLibProperties(geoLib, camResult.geoLib);
      double axialShift1 = camResult.geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
      double axialShift2 = geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
      ((MWIterationOption) camResult).buCamParamters = new camParameters5(this.buCamDataParameter);
      camResult.Tool.CamData.SpindleSpeed = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleSpeed;
      camResult.Tool.CamData.SpindleDirection = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleDirection;
      geoLib.Dispose();
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public bool CalculateSurface(
    ToolBase5 Tool,
    List<ModuleWorks.Surface> SurfaceEntities,
    List<Meshd> Meshes,
    TriangleMeshBasedTpCalcParamsPattern CalcType,
    MWCalculationOptions Option,
    ref MWCalculationResult camResult)
  {
    try
    {
      if (this.mwCamDataParameter == null)
        return false;
      if (this.updateHandler == null)
      {
        this.updateHandler = (buMWUpdateHandler) new MWCalculationResult();
        this.updateHandler.CalculationUpdate += new MWCalculationUpdateHandler(this.GetProgress);
      }
      ModuleWorks.Tool mwTool = (ModuleWorks.Tool) null;
      GeoLib geoLib = new GeoLib(Unit.Metric, 1);
      buMWUpdateHandler.CancelOperation = false;
      if (this.CreateMWTool(Tool, ref mwTool) != 1)
        return false;
      geoLib.ToolInfo = mwTool;
      geoLib.MachParam = new MachiningParams(this.mwCamDataParameter.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.mwCamDataParameter, geoLib);
      geoLib.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmSurfaceBased;
      geoLib.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern = TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts;
      geoLib.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
      for (int index = 0; index <= SurfaceEntities.Count - 1; ++index)
      {
        if (index <= Meshes.Count - 1)
        {
          SurfaceEntities[index].SetMesh(Meshes[index]);
        }
        else
        {
          Meshd tessellationFromSurface = new Tesselator().GetTessellationFromSurface(SurfaceEntities[index], 0.01, Unit.Metric);
          SurfaceEntities[index].SetMesh(tessellationFromSurface);
        }
      }
      geoLib.DriveSurfArray = (IEnumerable<ModuleWorks.Surface>) SurfaceEntities;
      if (this.Stock != null)
        geoLib.StockDefinition = (IEnumerable<Meshd>) this.Stock;
      if ((buMWCalcs.entityProjection == null ? 0 : (buMWCalcs.entityProjection.Count > 0 ? 1 : 0)) != 0)
      {
        List<ModuleWorks.Curve> curveList = new List<ModuleWorks.Curve>();
        for (int index1 = 0; index1 <= buMWCalcs.entityProjection.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= buMWCalcs.entityProjection[index1].Count - 1; ++index2)
          {
            if (buMWCalcs.entityProjection[index1][index2] != null)
            {
              ModuleWorks.Curve mwEntity = (ModuleWorks.Curve) null;
              buMWCalcs.ConvertWireEntity(buMWCalcs.entityProjection[index1][index2], ref mwEntity);
              if (mwEntity != null)
                curveList.Add(mwEntity);
            }
          }
        }
        if ((curveList == null ? 0 : (curveList.Count > 0 ? 1 : 0)) != 0)
          geoLib.ProjectionCurves = (IEnumerable<ModuleWorks.Curve>) curveList;
      }
      geoLib.SetUpdateHandler((UpdateHandler) this.updateHandler);
      \u0002.\u0001 interactor = new \u0002.\u0001(Unit.Metric);
      MachiningParameterDialog machiningParameterDialog = new MachiningParameterDialog(geoLib, (ParamInteractor) interactor);
      bool flag = true;
      if (this.Settings.ShowMwDialogBox)
        flag = machiningParameterDialog.Show();
      if (!flag)
        return false;
      // ISSUE: reference to a compiler-generated field
      if (this.\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.\u0002(new CalculationEventArg());
      }
      geoLib.Serialize(Application.StartupPath + "\\mwResult.bin");
      CollisionsReport collReport = new CollisionsReport();
      ToolPath copy = geoLib.CalcToolPath(collReport);
      camResult = (MWCalculationResult) new MWIterationOption();
      camResult.ToolPathCalc = new ToolPath(copy);
      camResult.Tool = new ToolBase5(Tool);
      camResult.geoLib = new GeoLib(geoLib.Units, 0);
      camResult.geoLib.MachParam = new MachiningParams(geoLib.MachParam);
      buMWCalcs.CopyGeoLibProperties(geoLib, camResult.geoLib);
      double axialShift1 = camResult.geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
      double axialShift2 = geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
      ((MWIterationOption) camResult).buCamParamters = new camParameters5(this.buCamDataParameter);
      camResult.Tool.CamData.SpindleSpeed = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleSpeed;
      camResult.Tool.CamData.SpindleDirection = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleDirection;
      geoLib.Dispose();
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public bool CalculateExistingToolPath3To5Axis(
    ToolBase5 Tool,
    ToolPath OriginalToolPath,
    List<Meshd> CheckSurface,
    TriangleMeshBasedTpCalcParamsPattern CalcType,
    MWCalculationOptions Option,
    ref MWCalculationResult camResult)
  {
    bool toolPath3To5Axis;
    if (this.mwCamDataParameter == null)
    {
      toolPath3To5Axis = false;
    }
    else
    {
      if (this.updateHandler == null)
      {
        this.updateHandler = (buMWUpdateHandler) new MWCalculationResult();
        this.updateHandler.CalculationUpdate += new MWCalculationUpdateHandler(this.GetProgress);
      }
      ModuleWorks.Tool mwTool = (ModuleWorks.Tool) null;
      GeoLib geoLib = new GeoLib(Unit.Metric, 1);
      buMWUpdateHandler.CancelOperation = false;
      if (this.CreateMWTool(Tool, ref mwTool) == 1)
      {
        geoLib.ToolInfo = mwTool;
        geoLib.MachParam = new MachiningParams(this.mwCamDataParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(this.mwCamDataParameter, geoLib);
        geoLib.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern = CalcType;
        geoLib.CheckSurfArray1 = (IEnumerable<Meshd>) CheckSurface;
        geoLib.OriginalToolPath = OriginalToolPath;
        if (this.Stock != null)
          geoLib.StockDefinition = (IEnumerable<Meshd>) this.Stock;
        geoLib.SetUpdateHandler((UpdateHandler) this.updateHandler);
        \u0002.\u0001 interactor = new \u0002.\u0001(Unit.Metric);
        MachiningParameterDialog machiningParameterDialog = new MachiningParameterDialog(geoLib, (ParamInteractor) interactor);
        bool flag = true;
        if (this.Settings.ShowMwDialogBox)
          flag = machiningParameterDialog.Show();
        if (flag)
        {
          // ISSUE: reference to a compiler-generated field
          if (this.\u0002 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.\u0002(new CalculationEventArg());
          }
          geoLib.Serialize(Application.StartupPath + "\\mwResult.bin");
          CollisionsReport collReport = new CollisionsReport();
          ToolPath copy = geoLib.CalcToolPath(collReport);
          camResult = (MWCalculationResult) new MWIterationOption();
          camResult.ToolPathCalc = new ToolPath(copy);
          camResult.Tool = new ToolBase5(Tool);
          camResult.geoLib = new GeoLib(geoLib.Units, 0);
          camResult.geoLib.MachParam = new MachiningParams(geoLib.MachParam);
          buMWCalcs.CopyGeoLibProperties(geoLib, camResult.geoLib);
          double axialShift1 = camResult.geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
          double axialShift2 = geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
          ((MWIterationOption) camResult).buCamParamters = new camParameters5(this.buCamDataParameter);
          camResult.Tool.CamData.SpindleSpeed = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleSpeed;
          camResult.Tool.CamData.SpindleDirection = ((MWIterationOption) camResult).buCamParamters.Speeds.SpindleDirection;
          geoLib.Dispose();
          toolPath3To5Axis = true;
        }
        else
          toolPath3To5Axis = false;
      }
      else
        toolPath3To5Axis = false;
    }
    return toolPath3To5Axis;
  }

  public int CreateMWTool(ToolBase5 buTool, ref ModuleWorks.Tool mwTool)
  {
    int mwTool1;
    if (buTool == null)
    {
      mwTool1 = -1;
    }
    else
    {
      if (buTool.Geometry.GeometryType == buClass.ToolType.Flat)
        mwTool = buMWCalcs.CreateEndFlatMill(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.Sphere)
        mwTool = buMWCalcs.CreateSphereMill(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.Bullnose)
        mwTool = buMWCalcs.CreateBullMill(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.Barrel)
        mwTool = buMWCalcs.CreateBarrelMill(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.Taper)
        mwTool = buMWCalcs.CreateTaperMill(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.Dove)
        mwTool = buMWCalcs.CreateDoveMill(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.Chamfer)
        mwTool = buMWCalcs.CreateChamferMill(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.Lollipop)
        mwTool = buMWCalcs.CreateLollipop(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.Slot)
        mwTool = buMWCalcs.CreateSlotMill(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.ConvexTip)
        mwTool = buMWCalcs.CreateConvexTipMill(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.Saw)
        mwTool = buMWCalcs.CreateSaw(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.WateJet)
        mwTool = buMWCalcs.CreateEndFlatMill(buTool);
      else if (buTool.Geometry.GeometryType == buClass.ToolType.Laser)
        mwTool = buMWCalcs.CreateEndFlatMill(buTool);
      mwTool1 = 1;
    }
    return mwTool1;
  }

  public static ModuleWorks.Tool CreateEndFlatMill(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      if (Tool.Geometry.CutLength > Tool.Geometry.Length)
        Tool.Geometry.CutLength = Tool.Geometry.Length - 0.2;
      return (ModuleWorks.Tool) new EndMill(Tool.Geometry.Diameter, holder, Tool.Geometry.Length, Tool.Geometry.CutLength, arbor, Unit.Metric);
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public static ModuleWorks.Tool CreateSphereMill(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      return (ModuleWorks.Tool) new SphereMill(Tool.Geometry.Diameter, holder, Tool.Geometry.Length, Tool.Geometry.CutLength, arbor, Unit.Metric);
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public static ModuleWorks.Tool CreateBullMill(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      return (ModuleWorks.Tool) new BullMill(Tool.Geometry.Diameter, holder, Tool.Geometry.Length, Tool.Geometry.CutLength, arbor, Tool.Geometry.RoundRadius, Unit.Metric);
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public static ModuleWorks.Tool CreateTaperMill(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      CornerRadiusType radiusType = (CornerRadiusType) Enum.ToObject(typeof (CornerRadiusType), Convert.ToInt32((object) Tool.Geometry.CornerRadiusType));
      return (ModuleWorks.Tool) new TaperMill(Tool.Geometry.Diameter, holder, Tool.Geometry.Length, Tool.Geometry.CutLength, arbor, Tool.Geometry.LowerRadius, radiusType, Tool.Geometry.TaperAngle, Unit.Metric);
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public static ModuleWorks.Tool CreateLollipop(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      return (ModuleWorks.Tool) new LollipopMill(Tool.Geometry.Diameter, holder, Tool.Geometry.Length, Tool.Geometry.CutLength, arbor, Tool.Geometry.OutsideDiameter, Unit.Metric);
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public static ModuleWorks.Tool CreateSlotMill(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      CornerRadiusType radiusType = (CornerRadiusType) Enum.ToObject(typeof (CornerRadiusType), Convert.ToInt32((object) Tool.Geometry.CornerRadiusType));
      SlotMill slotMill;
      if (Tool.Geometry.ShoulderDiameter <= 0.0 | Tool.Geometry.ShoulderLength <= 0.0)
      {
        slotMill = new SlotMill(Tool.Geometry.Diameter, holder, Tool.Geometry.CutLength, arbor, Tool.Geometry.LowerRadius, Tool.Geometry.UpperRadius, radiusType, Unit.Metric);
      }
      else
      {
        ShoulderExtension shoulderExtension = new ShoulderExtension(Tool.Geometry.ShoulderDiameter, Tool.Geometry.Length, Unit.Metric);
        slotMill = new SlotMill(Tool.Geometry.Diameter, holder, Tool.Geometry.CutLength, arbor, Tool.Geometry.LowerRadius, Tool.Geometry.UpperRadius, radiusType, Tool.Geometry.Length, shoulderExtension, Unit.Metric);
      }
      return (ModuleWorks.Tool) slotMill;
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public static ModuleWorks.Tool CreateChamferMill(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      CornerRadiusType radiusType = (CornerRadiusType) Enum.ToObject(typeof (CornerRadiusType), Convert.ToInt32((object) Tool.Geometry.CornerRadiusType));
      return (ModuleWorks.Tool) new ChamferMill(Tool.Geometry.Diameter, holder, Tool.Geometry.Length, Tool.Geometry.CutLength, arbor, Tool.Geometry.LowerRadius, radiusType, Tool.Geometry.OutsideDiameter, Tool.Geometry.TaperAngle, Unit.Metric);
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public static ModuleWorks.Tool CreateDoveMill(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      CornerRadiusType radiusType = (CornerRadiusType) Enum.ToObject(typeof (CornerRadiusType), Convert.ToInt32((object) Tool.Geometry.CornerRadiusType));
      return (ModuleWorks.Tool) new DoveMill(Tool.Geometry.Diameter, holder, Tool.Geometry.Length, Tool.Geometry.CutLength, arbor, Tool.Geometry.LowerRadius, radiusType, Tool.Geometry.TaperAngle, Unit.Metric);
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public static ModuleWorks.Tool CreateBarrelMill(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      return (ModuleWorks.Tool) new BarrelMill(Tool.Geometry.UpperDiameter, Tool.Geometry.MaxDiameter, holder, Tool.Geometry.Length, Tool.Geometry.CutLength, arbor, Tool.Geometry.LowerRadius, Tool.Geometry.ProfileRadius, Unit.Metric);
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public static ModuleWorks.Tool CreateConvexTipMill(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      return (ModuleWorks.Tool) new ConvexTipMill(Tool.Geometry.Diameter, holder, Tool.Geometry.Length, Tool.Geometry.CutLength, arbor, Tool.Geometry.LowerRadius, Tool.Geometry.ConvexTipRadius, Tool.Geometry.FlatnessDiameter, Unit.Metric);
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public static ModuleWorks.Tool CreateSaw(ToolBase5 Tool)
  {
    try
    {
      ToolHolder holder;
      if (Tool.Geometry.HolderPoints.Count == 0)
      {
        holder = ToolHolder.CreateHolderAsCylinder(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.HolderPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.HolderPoints[index].X, Tool.Geometry.HolderPoints[index].Y + 0.0 + 0.0);
          points.Add(point2d);
        }
        holder = ToolHolder.CreateHolderFromPoints(points, Unit.Metric);
      }
      ToolArbor arbor;
      if (Tool.Geometry.ArborPoints.Count == 0)
      {
        arbor = ToolArbor.CreateArborAsCylinder(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
      }
      else
      {
        List<Point2d<double>> points = new List<Point2d<double>>();
        for (int index = 0; index <= Tool.Geometry.ArborPoints.Count - 1; ++index)
        {
          Point2d<double> point2d = new Point2d<double>(Tool.Geometry.ArborPoints[index].X, Tool.Geometry.ArborPoints[index].Y + Tool.Geometry.Length - Tool.Geometry.Thickness);
          points.Add(point2d);
        }
        arbor = ToolArbor.CreateArborFromPoints(points, Unit.Metric);
      }
      Tool.Geometry.LowerRadius = Tool.Geometry.Thickness / 8.0;
      Tool.Geometry.UpperRadius = Tool.Geometry.Thickness / 8.0;
      return (ModuleWorks.Tool) new SlotMill(Tool.Geometry.Diameter, holder, Tool.Geometry.Thickness, arbor, Tool.Geometry.LowerRadius, Tool.Geometry.UpperRadius, CornerRadiusType.None, Unit.Metric);
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(ex.Message);
      return (ModuleWorks.Tool) null;
    }
  }

  public void GetProgress(
    ProgressDescription rProgress,
    OverallProgressDescription rOverAllProgress)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.\u0001 == null)
      return;
    buMWCalcs.GetProgressUpdating = true;
    Application.DoEvents();
    CalculationEventArg e = new CalculationEventArg();
    e.OverallProgressPercentage = (double) rOverAllProgress.Percentage;
    e.ActiveProgressPercentage = (double) rProgress.Percentage;
    e.ShowForm = this.Settings.ShowProgressForm;
    if (rProgress.ObjectId != 0)
      e.Job = $"{rProgress.OperationId.ToString()}  -  {rProgress.ObjectId.ToString()} [ {rProgress.Current.ToString()} / {rProgress.Total.ToString()} ]";
    else
      e.Job = $"{rProgress.OperationId.ToString()} [ {rProgress.Current.ToString()} / {rProgress.Total.ToString()} ]";
    // ISSUE: reference to a compiler-generated field
    this.\u0001(e);
    buMWCalcs.GetProgressUpdating = false;
  }

  public static GeoLib CopyCamParameter(
    GeoLib mainMW,
    camParameters5 mainBU,
    out camParameters5 copyBU)
  {
    GeoLib copy = new GeoLib(mainMW.Units);
    copy.MachParam = new MachiningParams(mainMW.MachParam);
    buMWCalcs.CopyGeoLibProperties(mainMW, copy);
    copyBU = new camParameters5(mainBU);
    return copy;
  }

  public static void CopyCamParameter(
    GeoLib mainMW,
    camParameters5 mainBU,
    ref MWParameters CopyPar)
  {
    if (CopyPar == null)
      CopyPar = new MWParameters(Unit.Metric, 0);
    ((buCamCalcSettings) CopyPar).mwPar.MachParam = new MachiningParams(mainMW.MachParam);
    buMWCalcs.CopyGeoLibProperties(mainMW, ref ((buCamCalcSettings) CopyPar).mwPar);
    CopyPar.buPar = new camParameters5(mainBU);
  }

  public static void CopyCamParameter(MWParameters RefPar, ref MWParameters CopyPar)
  {
    if (CopyPar == null)
      CopyPar = new MWParameters(Unit.Metric, 0);
    ((buCamCalcSettings) CopyPar).mwPar.MachParam = new MachiningParams(((buCamCalcSettings) RefPar).mwPar.MachParam);
    buMWCalcs.CopyGeoLibProperties(((buCamCalcSettings) RefPar).mwPar, ref ((buCamCalcSettings) CopyPar).mwPar);
    CopyPar.buPar = new camParameters5(RefPar.buPar);
  }

  public static void CopyCamParameter(
    MWParameters RefPar,
    ref GeoLib copyMWPar,
    ref camParameters5 copyBUPar)
  {
    if (copyMWPar == null)
      copyMWPar = new GeoLib(Unit.Metric);
    copyMWPar.MachParam = new MachiningParams(((buCamCalcSettings) RefPar).mwPar.MachParam);
    buMWCalcs.CopyGeoLibProperties(((buCamCalcSettings) RefPar).mwPar, ref copyMWPar);
    copyBUPar = new camParameters5(RefPar.buPar);
  }

  public static void CopyGeoLibProperties(GeoLib main, GeoLib copy)
  {
    copy.DrillPoints = main.DrillPoints;
    copy.TabsPoints = main.TabsPoints;
    copy.DrillHoleLines = main.DrillHoleLines;
    copy.ContainmentCurves2d = main.ContainmentCurves2d;
  }

  public static void CopyGeoLibProperties(GeoLib main, ref GeoLib copy)
  {
    copy.DrillPoints = main.DrillPoints;
    copy.TabsPoints = main.TabsPoints;
    copy.DrillHoleLines = main.DrillHoleLines;
    copy.ContainmentCurves2d = main.ContainmentCurves2d;
  }

  public static void ConvertFromMwCamParToBuCamPar(GeoLib MWPar, ref camParameters5 BUPar)
  {
    BUPar.Speeds.Feed = MWPar.MachParam.FeedRate;
    BUPar.Speeds.Plunge = MWPar.MachParam.PlungeFeedRate;
    BUPar.Speeds.Leave = MWPar.MachParam.RetractFeedRate;
    BUPar.Speeds.RapidEnable = MWPar.MachParam.RapidFeedFlg;
    BUPar.Speeds.Rapid = MWPar.MachParam.RapidFeedrate;
    BUPar.Distances.Air = MWPar.MachParam.LinkParams.AirMoveSafetyDistance;
    BUPar.Distances.Safe = MWPar.MachParam.LinkParams.ClearancePlaneHeight;
    BUPar.Distances.Rapid = (bool) MWPar.MachParam.LinkParams.RetractPlaneIncremental;
    BUPar.Distances.EntryAndExit = MWPar.MachParam.LinkParams.ApproachFeedPlaneIncremental;
    BUPar.Distances.EntryAndExit = MWPar.MachParam.LinkParams.FeedPlaneIncremental;
    BUPar.Distances.RapidRetract = MWPar.MachParam.RapidRetractFlg;
    BUPar.Steps.DepthStep = MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep;
    BUPar.Steps.NumberOfSlice = MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep;
    BUPar.Steps.DepthStepMode = (CamStepDepthMode) Convert.ToInt32((object) MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode);
    BUPar.Drill.PeckMode = MWPar.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.PeckDrillFlg;
    BUPar.Drill.PeckFullRetract = MWPar.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.FullRetractFlg;
    BUPar.Drill.PeckDepth = MWPar.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.PeckDepth;
    BUPar.Drill.PeckMinRetractDistance = MWPar.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.MinRetractDistance;
    BUPar.Offsets.AdditionalOffset = MWPar.MachParam.StockRemain;
    BUPar.Strategy.MachiningAreaMode = (CamMachiningAreaMode) Convert.ToInt32((object) MWPar.MachParam.MachiningAreaMode);
    BUPar.Strategy.CuttingMethod = (CamCuttingMethod) Convert.ToInt32((object) MWPar.MachParam.CurMachType);
    if (MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide == WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft)
      BUPar.Offsets.OpenContour = CamOpenContourType.Left;
    else if (MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide == WireframeBasedTpCalcParamsCuttingSide.WfbCsRight)
    {
      BUPar.Offsets.OpenContour = CamOpenContourType.Right;
    }
    else
    {
      if (MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter)
        return;
      BUPar.Offsets.OpenContour = CamOpenContourType.Center;
    }
  }

  public static GeoLib ConvertFromBuCamParToMwCamPar(GeoLib MWPar, camParameters5 BUPar)
  {
    MWPar.MachParam.FeedRate = BUPar.Speeds.Feed;
    MWPar.MachParam.PlungeFeedRate = BUPar.Speeds.Plunge;
    MWPar.MachParam.RetractFeedRate = BUPar.Speeds.Leave;
    MWPar.MachParam.RapidFeedFlg = BUPar.Speeds.RapidEnable;
    MWPar.MachParam.RapidFeedrate = BUPar.Speeds.Rapid;
    MWPar.MachParam.LinkParams.AirMoveSafetyDistance = BUPar.Distances.Air;
    MWPar.MachParam.LinkParams.ClearancePlaneHeight = BUPar.Distances.Safe;
    MWPar.MachParam.LinkParams.RetractPlaneIncremental = (double) (BUPar.Distances.Rapid ? 1 : 0);
    MWPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = BUPar.Distances.EntryAndExit;
    MWPar.MachParam.LinkParams.FeedPlaneIncremental = BUPar.Distances.EntryAndExit;
    MWPar.MachParam.RapidRetractFlg = BUPar.Distances.RapidRetract;
    if (BUPar.Steps.DepthStep <= 0.0)
      BUPar.Steps.DepthStep = 1.0;
    MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep = Math.Abs(BUPar.Steps.DepthStep);
    MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep = BUPar.Steps.NumberOfSlice;
    MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = (MachiningAreaRoughingParamsDepthStepMode) Convert.ToInt32((object) BUPar.Steps.DepthStepMode);
    MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = BUPar.Steps.EndValue;
    MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = BUPar.Steps.StartValue;
    MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep = Math.Abs(BUPar.Steps.DepthStep);
    MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep = BUPar.Steps.NumberOfSlice;
    MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = (MachiningAreaRoughingParamsDepthStepMode) Convert.ToInt32((object) BUPar.Steps.DepthStepMode);
    MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = BUPar.Steps.EndValue;
    MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = BUPar.Steps.StartValue;
    MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = !(BUPar.Steps.EndValue != BUPar.Steps.StartValue & BUPar.Steps.StartValue > BUPar.Steps.EndValue) ? MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic : MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
    MWPar.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.PeckDrillFlg = BUPar.Drill.PeckMode;
    MWPar.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.FullRetractFlg = BUPar.Drill.PeckFullRetract;
    MWPar.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.PeckDepth = BUPar.Drill.PeckDepth;
    MWPar.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.MinRetractDistance = BUPar.Drill.PeckMinRetractDistance;
    MWPar.MachParam.StockRemain = BUPar.Offsets.AdditionalOffset;
    MWPar.MachParam.CurMachType = (MachiningParamsMachType) Convert.ToInt32((object) BUPar.Strategy.CuttingMethod);
    MWPar.MachParam.MachiningAreaMode = (MachiningParamsMachiningAreaMode) Convert.ToInt32((object) BUPar.Strategy.MachiningAreaMode);
    MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = BUPar.Offsets.OpenContour != CamOpenContourType.Left ? (BUPar.Offsets.OpenContour != CamOpenContourType.Right ? WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter : WireframeBasedTpCalcParamsCuttingSide.WfbCsRight) : WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft;
    return MWPar;
  }

  public static void ConvertFromMwCamParToBuCamParTriangleMesh(
    GeoLib MWPar,
    ref camParameters5 BUPar)
  {
    BUPar.Speeds.Feed = MWPar.MachParam.FeedRate;
    BUPar.Speeds.Plunge = MWPar.MachParam.PlungeFeedRate;
    BUPar.Speeds.Leave = MWPar.MachParam.RetractFeedRate;
    BUPar.Speeds.RapidEnable = MWPar.MachParam.RapidFeedFlg;
    BUPar.Speeds.Rapid = MWPar.MachParam.RapidFeedrate;
    BUPar.Distances.Air = MWPar.MachParam.LinkParams.AirMoveSafetyDistance;
    BUPar.Distances.Safe = MWPar.MachParam.LinkParams.ClearancePlaneHeight;
    BUPar.Distances.Rapid = (bool) MWPar.MachParam.LinkParams.RetractPlaneIncremental;
    BUPar.Distances.EntryAndExit = MWPar.MachParam.LinkParams.ApproachFeedPlaneIncremental;
    BUPar.Distances.EntryAndExit = MWPar.MachParam.LinkParams.FeedPlaneIncremental;
    BUPar.Distances.RapidRetract = MWPar.MachParam.RapidRetractFlg;
    BUPar.Strategy.UseRamp = MWPar.MachParam.LinkParams.FirstEntry.LeadController.IsUsed;
    BUPar.Strategy.UseRamp = MWPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed;
    BUPar.Strategy.CutTolerance = MWPar.MachParam.CutTolerance;
    BUPar.Steps.DepthStep = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep;
    BUPar.Steps.NumberOfSlice = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep;
    BUPar.Steps.DepthStepMode = (CamStepDepthMode) Convert.ToInt32((object) MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode);
    BUPar.Steps.EndValue = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight;
    BUPar.Steps.StartValue = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight;
    BUPar.Steps.HeightType = (CamHeightsType) Convert.ToInt32((object) MWPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType);
    BUPar.Operations.Stepover = MWPar.MachParam.MaxStepoverDistance;
    BUPar.Offsets.AdditionalOffset = MWPar.MachParam.StockRemain;
    BUPar.Strategy.MachiningAreaMode = (CamMachiningAreaMode) Convert.ToInt32((object) MWPar.MachParam.MachiningAreaMode);
    BUPar.Strategy.CuttingMethod = (CamCuttingMethod) Convert.ToInt32((object) MWPar.MachParam.CurMachType);
    BUPar.Pockets.SharpCorner = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharpCornersFlg;
    BUPar.Strategy.RoughLeadOut = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg;
    BUPar.Strategy.MinimizeLink = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinimizeLinksFlg;
    BUPar.Strategy.RemoveCornerPeg = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RemoveCornerPegsFlg;
    BUPar.Strategy.RoughLeadOut = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg;
    BUPar.Strategy.SilhouetteEnable = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg;
    BUPar.Strategy.SilhouetteTriangleMeshType = (CamSilhouetteContainmentTriangleMeshType) Convert.ToInt32((object) MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType);
    BUPar.Pockets.PocketType = (CamPocketType) Convert.ToInt32((object) MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType);
    BUPar.Strategy.RampTypeTriangleMesh = (CamRampTypeTriangleMeshType) Convert.ToInt32((object) MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType);
    BUPar.Strategy.RampModeTriangleMesh = (CamRampModeTriangleMeshType) Convert.ToInt32((object) MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampMode);
    BUPar.Strategy.RampPitch = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampPitch;
    BUPar.Strategy.RampAngle = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampAngle;
    BUPar.Strategy.RampMaxDiameterFromToolPerc = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampLengthPercent;
    BUPar.Strategy.RampMinDiameterFromToolPerc = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinRampDiameterPercent;
    BUPar.Strategy.RampMinDiameterToolDiameterEnable = MWPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseMinRampDiameterFlg;
    BUPar.Rotary.MaxAngleChange = MWPar.MachParam.MaxAngleChange;
    BUPar.Rotary.TiltStrategy = (CamTiltStrategy) Convert.ToInt32((object) MWPar.MachParam.ToolAxisControlParams.TiltStrategy);
    BUPar.Rotary.SideTiltDefTypes = (CamSideTiltDefTypes) Convert.ToInt32((object) MWPar.MachParam.ToolAxisControlParams.CurSideTiltDefType);
    BUPar.Rotary.LagAngle = MWPar.MachParam.ToolAxisControlParams.LagAngle;
    BUPar.Rotary.SideTiltAngle = MWPar.MachParam.ToolAxisControlParams.SideTiltAngle;
    BUPar.Rotary.SmoothingFlg = MWPar.MachParam.ToolAxisControlParams.SmoothingFlg;
    BUPar.Rotary.LimitsFlg = MWPar.MachParam.ToolAxisControlParams.LimitsFlg;
    BUPar.Rotary.MaxAngleFromInitialToolOrientation = MWPar.MachParam.ToolAxisControlParams.ToolAxisSmoothingParams.MaxAngleFromInitialToolOrientation;
    BUPar.Rotary.BAngleLimitInXZPlaneFlg = MWPar.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg;
    BUPar.Rotary.BAngleLimitStartInXZPlane = MWPar.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane;
    BUPar.Rotary.BAngleLimitEndInXZPlane = MWPar.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane;
    BUPar.Rotary.AAngleLimitInYZPlaneFlg = MWPar.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg;
    BUPar.Rotary.AAngleLimitStartInYZPlane = MWPar.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane;
    BUPar.Rotary.AAngleLimitEndInYZPlane = MWPar.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane;
    BUPar.Rotary.CAngleLimitInXYPlaneFlg = MWPar.MachParam.ToolAxisControlParams.CAngleLimitInXYPlaneFlg;
    BUPar.Rotary.CAngleLimitStartInXYPlane = MWPar.MachParam.ToolAxisControlParams.CAngleLimitStartInXYPlane;
    BUPar.Rotary.CAngleLimitEndInXYPlane = MWPar.MachParam.ToolAxisControlParams.CAngleLimitEndInXYPlane;
    BUPar.Rotary.WOrtAngleLimitFlg = MWPar.MachParam.ToolAxisControlParams.WOrtAngleLimitFlg;
    BUPar.Rotary.WOrtAngleLimitStart = MWPar.MachParam.ToolAxisControlParams.WOrtAngleLimitStart;
    BUPar.Rotary.WOrtAngleLimitEnd = MWPar.MachParam.ToolAxisControlParams.WOrtAngleLimitEnd;
  }

  public static GeoLib ConvertFromBuCamParToMwCamParTriangleMesh(GeoLib MWPar, camParameters5 BUPar)
  {
    // ISSUE: unable to decompile the method.
  }

  public static Point3d<double> Pnt3DToPnt3D(Point3D P)
  {
    try
    {
      return new Point3d<double>(P.X, P.Y, P.Z);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", "Pnt3DToPoint3D");
      buException.throwException(ex, "Pnt3DToPoint3D", true, str);
      return new Point3d<double>();
    }
  }

  public static Point3D Pnt3DToPnt3D(Point3d<double> P)
  {
    try
    {
      return new Point3D(P.X, P.Y, P.Z);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", "Point3DToPnt3D");
      buException.throwException(ex, "Point3DToPnt3D", true, str);
      return new Point3D();
    }
  }

  public static Vectord Vec3DToVec3D(Vector3D P)
  {
    try
    {
      return new Vectord(P.X, P.Y, P.Z);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", "Vec3DToVector3D");
      buException.throwException(ex, "Vec3DToVector3D", true, str);
      return new Vectord();
    }
  }

  public static Vector3D Vec3DToVec3D(Vectord P)
  {
    try
    {
      return new Vector3D(P.X, P.Y, P.Z);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", "Vector3DToVec3D");
      buException.throwException(ex, "Vector3DToVec3D", true, str);
      return new Vector3D();
    }
  }

  public static ModuleWorks.Surface ConvertToMWSurface(devDept.Eyeshot.Entities.Surface surf)
  {
    int length1 = surf.ControlPoints.GetLength(0);
    int length2 = surf.ControlPoints.GetLength(1);
    WeightedPoint3d<double>[,] controlPoints = new WeightedPoint3d<double>[length1, length2];
    UVKnotVector uvNodes = new UVKnotVector();
    uvNodes.UKnots.AddRange((IEnumerable<double>) surf.KnotVectorU);
    uvNodes.VKnots.AddRange((IEnumerable<double>) surf.KnotVectorV);
    for (int index1 = 0; index1 < length1; ++index1)
    {
      for (int index2 = 0; index2 < length2; ++index2)
      {
        Point4D controlPoint = surf.ControlPoints[index1, index2];
        controlPoints[index1, index2] = new WeightedPoint3d<double>(controlPoint.X, controlPoint.Y, controlPoint.Z, controlPoint.W);
      }
    }
    List<ModuleWorks.Curve> trimLoops = new List<ModuleWorks.Curve>();
    foreach (ICurve contour in surf.Trimming.ContourList)
    {
      devDept.Eyeshot.Entities.Curve nurbsForm = contour.GetNurbsForm();
      List<WeightedPoint2d<double>> weightedPoint2dList = new List<WeightedPoint2d<double>>(nurbsForm.ControlPoints.Length);
      foreach (Point4D controlPoint in nurbsForm.ControlPoints)
        weightedPoint2dList.Add(new WeightedPoint2d<double>(controlPoint.X, controlPoint.Y, controlPoint.W));
      ModuleWorks.Curve curve = new ModuleWorks.Curve(weightedPoint2dList.ToArray(), (short) nurbsForm.Degree, nurbsForm.KnotVector);
      trimLoops.Add(curve);
    }
    return new ModuleWorks.Surface(controlPoints, (short) surf.DegreeU, (short) surf.DegreeV, uvNodes, trimLoops, true);
  }

  public static ModuleWorks.Curve ConvertToMWCurve(ICurve curve, bool Reverse)
  {
    devDept.Eyeshot.Entities.Curve nurbsForm = curve.GetNurbsForm();
    List<WeightedPoint3d<double>> weightedPoint3dList = new List<WeightedPoint3d<double>>(nurbsForm.ControlPoints.Length);
    foreach (Point4D controlPoint in nurbsForm.ControlPoints)
      weightedPoint3dList.Add(new WeightedPoint3d<double>(controlPoint.X, controlPoint.Y, controlPoint.Z, controlPoint.W));
    if (Reverse)
      weightedPoint3dList.Reverse();
    return new ModuleWorks.Curve(weightedPoint3dList.ToArray(), (short) nurbsForm.Degree, nurbsForm.KnotVector);
  }

  public static ModuleWorks.Curve ConvertToMWLine(Line line, bool Reverse)
  {
    List<WeightedPoint3d<double>> weightedPoint3dList = new List<WeightedPoint3d<double>>(2);
    if (!Reverse)
    {
      weightedPoint3dList.Add(new WeightedPoint3d<double>(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z, 1.0));
      weightedPoint3dList.Add(new WeightedPoint3d<double>(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z, 1.0));
    }
    else
    {
      weightedPoint3dList.Add(new WeightedPoint3d<double>(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z, 1.0));
      weightedPoint3dList.Add(new WeightedPoint3d<double>(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z, 1.0));
    }
    double[] knots = new double[4]{ 0.0, 0.0, 1.0, 1.0 };
    return new ModuleWorks.Curve(weightedPoint3dList.ToArray(), (short) 1, knots);
  }

  public static ModuleWorks.Curve ConvertToMWArc(Arc arc, bool Reverse)
  {
    return Reverse ? ModuleWorks.Curve.FromArc(buMWCalcs.Pnt3DToPnt3D(arc.EndPoint), buMWCalcs.Pnt3DToPnt3D(arc.StartPoint), buMWCalcs.Pnt3DToPnt3D(arc.Center), new Point3d<double>(arc.Plane.AxisZ.X, arc.Plane.AxisZ.Y, arc.Plane.AxisZ.Z), arc.Radius) : (((CustomData) arc.EntityData).sortDirection != entitySortDirection.Normal ? ModuleWorks.Curve.FromArc(buMWCalcs.Pnt3DToPnt3D(arc.EndPoint), buMWCalcs.Pnt3DToPnt3D(arc.StartPoint), buMWCalcs.Pnt3DToPnt3D(arc.Center), new Point3d<double>(arc.Plane.AxisZ.X, arc.Plane.AxisZ.Y, arc.Plane.AxisZ.Z * -1.0), arc.Radius) : ModuleWorks.Curve.FromArc(buMWCalcs.Pnt3DToPnt3D(arc.StartPoint), buMWCalcs.Pnt3DToPnt3D(arc.EndPoint), buMWCalcs.Pnt3DToPnt3D(arc.Center), new Point3d<double>(arc.Plane.AxisZ.X, arc.Plane.AxisZ.Y, arc.Plane.AxisZ.Z), arc.Radius));
  }

  public static ModuleWorks.Curve ConvertToMWCircle(Circle circle, bool Reverse)
  {
    return ModuleWorks.Curve.FromArc(buMWCalcs.Pnt3DToPnt3D(circle.StartPoint), buMWCalcs.Pnt3DToPnt3D(circle.StartPoint), buMWCalcs.Pnt3DToPnt3D(circle.Center), new Point3d<double>(circle.Plane.AxisZ.X, circle.Plane.AxisZ.Y, circle.Plane.AxisZ.Z), circle.Radius);
  }

  public static Meshd ConvertToMWMesh(Mesh mesh)
  {
    List<Triangled> triangles = new List<Triangled>(mesh.Triangles.Length);
    List<Vectord> vertices = new List<Vectord>(mesh.Vertices.Length);
    for (int index = 0; index < mesh.Triangles.Length; ++index)
    {
      IndexTriangle triangle = mesh.Triangles[index];
      Triangled triangled = new Triangled(triangle.V1, triangle.V2, triangle.V3);
      triangles.Add(triangled);
    }
    if (mesh.Normals != null)
    {
      for (int index = 0; index < mesh.Normals.Length; ++index)
      {
        if (index <= triangles.Count - 1)
        {
          Vector3D normal = mesh.Normals[index];
          triangles[index].Normal = new Vectord(normal.X, normal.Y, normal.Z);
        }
      }
    }
    for (int index = 0; index < mesh.Vertices.Length; ++index)
    {
      Point3D vertex = mesh.Vertices[index];
      Vectord vectord = new Vectord(vertex.X, vertex.Y, vertex.Z);
      vertices.Add(vectord);
    }
    return new Meshd(triangles, vertices, Unit.Metric);
  }

  public static Mesh ConvertToDevDeptMesh(Meshd mesh)
  {
    List<Point3D> vertices = new List<Point3D>();
    List<IndexTriangle> triangles = new List<IndexTriangle>();
    List<Triangled> triangledList = new List<Triangled>(mesh.TriangleCount);
    List<Vectord> vectordList = new List<Vectord>(mesh.PointCount);
    for (int index = 0; index < mesh.PointCount; ++index)
    {
      Point3D point3D = new Point3D(mesh.GetPoint(index).X, mesh.GetPoint(index).Y, mesh.GetPoint(index).Z);
      vertices.Add(point3D);
    }
    for (int index = 0; index < mesh.TriangleCount; ++index)
    {
      IndexTriangle indexTriangle = new IndexTriangle(mesh.GetTriangle(index).Idx1, mesh.GetTriangle(index).Idx2, mesh.GetTriangle(index).Idx3);
      triangles.Add(indexTriangle);
    }
    return new Mesh((IList<Point3D>) vertices, (IList<IndexTriangle>) triangles);
  }

  public static void ConvertWireEntity(Entity buEntity, ref ModuleWorks.Curve mwEntity)
  {
    bool Reverse = false;
    switch (buEntity)
    {
      case Line _:
        if (buMWCalcs.GetSortDirection(buEntity) == entitySortDirection.Reverse)
          Reverse = true;
        mwEntity = buMWCalcs.ConvertToMWCurve((ICurve) buEntity, Reverse);
        break;
      case Arc _:
        if (buMWCalcs.GetSortDirection(buEntity) == entitySortDirection.Reverse)
          Reverse = false;
        mwEntity = buMWCalcs.ConvertToMWArc((Arc) buEntity, Reverse);
        break;
      case Circle _:
        if (buMWCalcs.GetSortDirection(buEntity) == entitySortDirection.Reverse)
          Reverse = false;
        mwEntity = buMWCalcs.ConvertToMWCircle((Circle) buEntity, Reverse);
        break;
      case devDept.Eyeshot.Entities.Curve _:
        if (buMWCalcs.GetSortDirection(buEntity) == entitySortDirection.Reverse)
          Reverse = true;
        mwEntity = buMWCalcs.ConvertToMWCurve((ICurve) buEntity, Reverse);
        break;
      case LinearPath _:
        if (buMWCalcs.GetSortDirection(buEntity) == entitySortDirection.Reverse)
          Reverse = true;
        mwEntity = buMWCalcs.ConvertToMWCurve((ICurve) buEntity, Reverse);
        break;
      case CompositeCurve _:
        if (buMWCalcs.GetSortDirection(buEntity) == entitySortDirection.Reverse)
          Reverse = true;
        mwEntity = buMWCalcs.ConvertToMWCurve((ICurve) buEntity, Reverse);
        break;
      case Ellipse _:
        if (buMWCalcs.GetSortDirection(buEntity) == entitySortDirection.Reverse)
          Reverse = true;
        mwEntity = buMWCalcs.ConvertToMWCurve((ICurve) buEntity, Reverse);
        break;
    }
  }

  public static entitySortDirection GetSortDirection(Entity refEntity)
  {
    entitySortDirection sortDirection = entitySortDirection.Normal;
    if (refEntity.EntityData != null)
      sortDirection = ((CustomData) refEntity.EntityData).sortDirection;
    return sortDirection;
  }
}
