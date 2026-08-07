// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleSawMillingPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSawMillingPars : buSerilization5
{
  public double SimDrawMillingToolOffsetX;
  public double SimDrawMillingToolOffsetY;
  public double SimDrawMillingToolOffsetZ;
  public double SimDrawSpindleOffsetX;
  public double SimDrawSpindleOffsetY;
  public double SimDrawSpindleOffsetZ;
  public double SimSpindleG54OffsetZ;
  public double SimDrawAirDryOffsetX;
  public double SimDrawAirDryOffsetY;
  public double SimDrawAirDryOffsetZ;
  public double SimDrawLaserPointerOffsetX;
  public double SimDrawLaserPointerOffsetY;
  public double SimDrawLaserPointerOffsetZ;
  public double SimDrawWaterjetOffsetX;
  public double SimDrawWaterjetOffsetY;
  public double SimDrawWaterjetOffsetZ;
  public double ExternalMillingSpindleStroke;
  public double SimDrawMillingHeadToolXOffset;
  public double SimDrawMillingHeadToolYOffset;
  public double SimDrawMillingHeadToolZOffset;
  public double SimCalcMillingToolXOffset;
  public double SimCalcMillingToolYOffset;
  public double SimCalcMillingToolZOffset;
  public double SimCalcMillingHeadToolXOffset;
  public double SimCalcMillingHeadToolYOffset;
  public double SimCalcMillingHeadToolZOffset;
  public double SimCalcLaserPointerToolXOffset;
  public double SimCalcLaserPointerToolYOffset;
  public double SimCalcLaserPointerToolZOffset;
  public double SimCalcAirDryToolXOffset;
  public double SimCalcAirDryToolYOffset;
  public double SimCalcAirDryToolZOffset;
  public double SimCalcWaterjetToolXOffset;
  public double SimCalcWaterjetToolYOffset;
  public double SimCalcWaterjetToolZOffset;
  public double SimulatioOnlineMoveXOffset;
  public double SimulatioOnlineMoveYOffset;
  public double SimulatioOnlineMoveZOffset;
  public double SimulatioOfflineMoveXOffset;
  public double SimulatioOfflineMoveYOffset;
  public double SimulatioOfflineMoveZOffset;
  public bool OnlineSimulation;
  public int SimInterval;
  public double SimulationG0DevideLength;
  public double SimulationG1DevideLength;
  public double LatheXOffset;
  public double LatheYOffset;
  public double LatheZOffset;
  public double LatheGCodeXOffset;
  public double LatheGCodeYOffset;
  public double LatheGCodeZOffset;
  public double LatheLeftRightSideDistance;
  public LeftRightType LathePosition;
  public MarbleDisplayViewportSettings ViewportSettings;
  public bool ShowCamG1Entities;
  public bool ShowCamG0Entities;
  public bool ShowCamPlungeEntities;
  public bool ShowCamLeaveEntities;
  public bool ShowCamLeadInOutEntities;
  public bool ShowCamConnectionEntities;
  public bool DrawItemSizeEntities;
  public bool buttonColorSolidEnable;
  public bool PartMaterialSkinEnable;
  public bool WoodMaterialSkinEnable;
  public int ViewPanAmount;
  public static List<string> Captions;
  public static byte f004B5B;
  public bool ZoomMouseWheelReverse;
  public Color CNCViewportBottomColor;
  public Color CNCViewportMiddleColor;
  public Color CNCViewportTopColor;
  public DisplayModeType CNCViewportDisplayType;
  public ProjectionModeType CNCViewportProjection;
  public bool CNCViewportShowCubeBox;
  public bool CNCViewportShowUcsArrow;
  public bool CNCViewportShowOrigineSembol;
  public bool CNCViewportShowMouseCoordinates;
  public Color CadCamViewportBottomColor;
  public Color CadCamViewportMiddleColor;
  public Color CadCamViewportTopColor;
  public DisplayModeType CadCamViewportDisplayType;
  public ProjectionModeType CadCamViewportProjection;
  public bool CadCamViewportShowCubeBox;
  public bool CadCamViewportShowUcsArrow;
  public bool CadCamViewportShowOrigineSembol;
  public bool CadCamViewportShowMouseCoordinates;
  public Color DialogViewportBottomColor;
  public Color DialogViewportMiddleColor;
  public Color DialogViewportTopColor;

  public void CalculatePointsWithKinematic(
    List<Pnt6D> refPoints,
    KinematicBase5 refKinematic,
    ToolBase5 Tool,
    ref List<Pnt6D> calcPoints)
  {
    try
    {
      KinematicBase5 Kinematic = (KinematicBase5) new OsnapPoint(refKinematic);
      ((marbleColoumsPars) this).KinematicCalc(refKinematic, Tool, ref Kinematic);
      double ToolLength = ((ToolGeometry5) Tool).Geometry.Diameter / 2.0;
      for (int index = 0; index <= refPoints.Count - 1; ++index)
      {
        Pnt6D refPoint = refPoints[index];
        OrientationAngle Orientation = new OrientationAngle(refPoints[index].A, refPoints[index].B, refPoints[index].C);
        Pnt6D CalcPoint = new Pnt6D();
        Point3D point3D = F_NotchEdit.ToPoint3D(refPoints[index]);
        ((buConversion5) buCall.\u0001).ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, point3D, ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z;
        CalcPoint.Z = CalcPoint.Z + ((OsnapCoordinateCatch) Kinematic).OffsetXYZ.Z - ((ToolGeometry5) Tool).Geometry.Diameter / 2.0;
        calcPoints.Add(CalcPoint);
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculatePointsWithKinematic(
    Pnt6D refPoint,
    KinematicBase5 refKinematic,
    ToolBase5 Tool,
    ref Pnt6D calcPoint)
  {
    try
    {
      KinematicBase5 Kinematic = (KinematicBase5) new OsnapPoint(refKinematic);
      ((marbleColoumsPars) this).KinematicCalc(refKinematic, Tool, ref Kinematic);
      double ToolLength = ((ToolGeometry5) Tool).Geometry.Diameter / 2.0;
      OrientationAngle Orientation = new OrientationAngle(refPoint.A, refPoint.B, refPoint.C);
      calcPoint = new Pnt6D();
      Point3D point3D = F_NotchEdit.ToPoint3D(refPoint);
      ((buConversion5) buCall.\u0001).ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, point3D, ref calcPoint);
      calcPoint.Z = calcPoint.Z + ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z;
      calcPoint.Z = calcPoint.Z + ((OsnapCoordinateCatch) refKinematic).OffsetXYZ.Z - ((ToolGeometry5) Tool).Geometry.Diameter / 2.0;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void SortCuttingFirstSameDirection(ref List<List<buEntity>> calcEntities)
  {
    List<List<buEntity>> collection1 = new List<List<buEntity>>();
    List<List<buEntity>> collection2 = new List<List<buEntity>>();
    List<List<buEntity>> collection3 = new List<List<buEntity>>();
    List<List<buEntity>> collection4 = new List<List<buEntity>>();
    List<List<buEntity>> collection5 = new List<List<buEntity>>();
    List<List<buEntity>> collection6 = new List<List<buEntity>>();
    for (int index = 0; index <= calcEntities.Count - 1; ++index)
    {
      if (calcEntities[index].Count > 0)
      {
        buEntity buEntity = calcEntities[index][0];
        if (buEntity is buLine)
        {
          double num = buCall.\u0001.PointAngle(((CustomData) buEntity).EndPoint, ((CustomData) buEntity).StartPoint);
          if (((CustomData) buEntity).sortDirection == entitySortDirection.Reverse)
            num += 180.0;
          if (!buConversion5.EQ(((EntityInfo) ((CustomData) buEntity).Marble).Angle, 0.0, 0.1) & ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).isA45First)
            collection6.Add(calcEntities[index]);
          else if (buConversion5.EQ(num, 0.0, 0.1) | buConversion5.EQ(num, 360.0, 0.1))
            collection1.Add(calcEntities[index]);
          else if (buConversion5.EQ(num, 90.0, 0.1) | buConversion5.EQ(num, 450.0, 0.1))
            collection2.Add(calcEntities[index]);
          else if (buConversion5.EQ(num, 180.0, 0.1) | buConversion5.EQ(num, -180.0, 0.1))
            collection3.Add(calcEntities[index]);
          else if (buConversion5.EQ(num, 270.0, 0.1) | buConversion5.EQ(num, -90.0, 0.1))
            collection4.Add(calcEntities[index]);
          else
            collection5.Add(calcEntities[index]);
        }
        else if (buConversion5.EQ(((EntityInfo) ((CustomData) buEntity).Marble).Angle, 0.0, 0.1))
          collection5.Add(calcEntities[index]);
        else if (((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).isA45First)
          collection6.Add(calcEntities[index]);
        else
          collection5.Add(calcEntities[index]);
      }
    }
    calcEntities.Clear();
    calcEntities.AddRange((IEnumerable<List<buEntity>>) collection6);
    if (((marbleCountertopTapPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).isCircularFirst)
      calcEntities.AddRange((IEnumerable<List<buEntity>>) collection5);
    calcEntities.AddRange((IEnumerable<List<buEntity>>) collection1);
    calcEntities.AddRange((IEnumerable<List<buEntity>>) collection3);
    calcEntities.AddRange((IEnumerable<List<buEntity>>) collection2);
    calcEntities.AddRange((IEnumerable<List<buEntity>>) collection4);
    if (((marbleCountertopTapPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).isCircularFirst)
      return;
    calcEntities.AddRange((IEnumerable<List<buEntity>>) collection5);
  }

  public void SortCuttingFirstSameDirection(ref List<buEntity> calcEntities)
  {
    List<buEntity> collection1 = new List<buEntity>();
    List<buEntity> collection2 = new List<buEntity>();
    List<buEntity> collection3 = new List<buEntity>();
    List<buEntity> collection4 = new List<buEntity>();
    List<buEntity> collection5 = new List<buEntity>();
    List<buEntity> collection6 = new List<buEntity>();
    for (int index = 0; index <= calcEntities.Count - 1; ++index)
    {
      buEntity buEntity = calcEntities[index];
      if (buEntity is buLine)
      {
        double num = buCall.\u0001.PointAngle(((CustomData) buEntity).EndPoint, ((CustomData) buEntity).StartPoint);
        if (((CustomData) buEntity).sortDirection == entitySortDirection.Reverse)
          num += 180.0;
        if (!buConversion5.EQ(((EntityInfo) ((CustomData) buEntity).Marble).Angle, 0.0, 0.1) & ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).isA45First)
          collection6.Add(calcEntities[index]);
        else if (buConversion5.EQ(num, 0.0, 0.1) | buConversion5.EQ(num, 360.0, 0.1))
          collection1.Add(calcEntities[index]);
        else if (buConversion5.EQ(num, 90.0, 0.1) | buConversion5.EQ(num, 450.0, 0.1))
          collection2.Add(calcEntities[index]);
        else if (buConversion5.EQ(num, 180.0, 0.1) | buConversion5.EQ(num, -180.0, 0.1))
          collection3.Add(calcEntities[index]);
        else if (buConversion5.EQ(num, 270.0, 0.1) | buConversion5.EQ(num, -90.0, 0.1))
          collection4.Add(calcEntities[index]);
        else
          collection5.Add(calcEntities[index]);
      }
      else if (buConversion5.EQ(((EntityInfo) ((CustomData) buEntity).Marble).Angle, 0.0, 0.1))
        collection5.Add(calcEntities[index]);
      else if (((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).isA45First)
        collection6.Add(calcEntities[index]);
      else
        collection5.Add(calcEntities[index]);
    }
    calcEntities.Clear();
    calcEntities.AddRange((IEnumerable<buEntity>) collection6);
    if (((marbleCountertopTapPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).isCircularFirst)
      calcEntities.AddRange((IEnumerable<buEntity>) collection5);
    calcEntities.AddRange((IEnumerable<buEntity>) collection1);
    calcEntities.AddRange((IEnumerable<buEntity>) collection3);
    calcEntities.AddRange((IEnumerable<buEntity>) collection2);
    calcEntities.AddRange((IEnumerable<buEntity>) collection4);
    if (((marbleCountertopTapPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).isCircularFirst)
      return;
    calcEntities.AddRange((IEnumerable<buEntity>) collection5);
  }

  public void ExtendFunctionCalculation(ref MarbleItem Item, ref MarbleItemCam marbleCam)
  {
    if (((MarbleScreenCaptureSettings) Item).Extends.Count <= 0)
      return;
    for (int index = 0; index <= ((MarbleScreenCaptureSettings) Item).Extends.Count - 1; ++index)
    {
      if (((MarbleMachineSettings) marbleCam).CamID == ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).CamID && ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).indexWire <= ((MarbleMachineOptionsSettings) marbleCam).WireEntities.Count - 1 && ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).indexWireSub <= ((MarbleMachineOptionsSettings) marbleCam).WireEntities[((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).indexWire].Count - 1)
      {
        buEntity copiedEntity = ((MarbleMachineOptionsSettings) marbleCam).WireEntities[((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).indexWire][((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).indexWireSub];
        if (!buCall.\u0001.isEntitySame(copiedEntity, ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).entityExtend))
        {
          ((CustomDataSurrogate) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).entityExtend).Orientation = new OrientationAngle(((CustomDataSurrogate) copiedEntity).Orientation);
          ((CustomData) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).entityExtend).Marble = (MarbleInfo) new Line2D(((CustomData) copiedEntity).Marble);
          buDiametricDim.Copy(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).entityExtend, ref copiedEntity);
          ((MarbleMachineOptionsSettings) marbleCam).WireEntities[((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).indexWire][((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index]).indexWireSub] = copiedEntity;
        }
      }
    }
  }
}
