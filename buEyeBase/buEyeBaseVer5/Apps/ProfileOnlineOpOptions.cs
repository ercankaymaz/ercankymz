// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOnlineOpOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOnlineOpOptions : buSerilization5
{
  public Point3D basePosition;
  public Point3D cornerPosition;
  public string ToolName;

  public void NotchSideCalc(
    ref camTpPoint CP,
    ref ProfileOperation P,
    ref camTp CamCalc,
    int i,
    ToolBase5 toolSaw,
    ProfileItem Profile,
    double XVal,
    double XSafe,
    double XOffset,
    double YSing,
    double calcZ,
    ProfileSettings Settings)
  {
    List<Point3D> points = new List<Point3D>();
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType != ProfileNotchOperationType.Side)
      return;
    if (((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
    {
      CP.Points.Add(new TpPnt9D(new Pnt6D(XSafe + XOffset, ((ProfileSettings) Profile).Width * YSing, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
      {
        PlungeAxis = "X",
        PlungeAxisMovement = true,
        MoveType = CamMoveType.G0
      });
      TpPnt9D tpPnt9D1 = new TpPnt9D(new Pnt6D(XSafe + XOffset, ((ProfileSettings) Profile).Width * YSing, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
      tpPnt9D1.Type = 0;
      tpPnt9D1.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
      tpPnt9D1.MoveType = CamMoveType.G0;
      CP.Points.Add(tpPnt9D1);
      points.Add(new Point3D(((TpArcData) tpPnt9D1).P9.X, ((TpArcData) tpPnt9D1).P9.Y, ((TpArcData) tpPnt9D1).P9.Z));
      TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(XVal + XOffset, ((ProfileSettings) Profile).Width * YSing, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
      tpPnt9D2.Type = 1;
      tpPnt9D2.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
      tpPnt9D2.MoveType = CamMoveType.Plunge;
      CP.Points.Add(tpPnt9D2);
      points.Add(new Point3D(((TpArcData) tpPnt9D2).P9.X, ((TpArcData) tpPnt9D2).P9.Y, ((TpArcData) tpPnt9D2).P9.Z));
      TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(XVal + XOffset, 0.0, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
      tpPnt9D3.Type = 1;
      tpPnt9D3.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
      tpPnt9D3.MoveType = CamMoveType.G1;
      CP.Points.Add(tpPnt9D3);
      points.Add(new Point3D(((TpArcData) tpPnt9D3).P9.X, ((TpArcData) tpPnt9D3).P9.Y, ((TpArcData) tpPnt9D3).P9.Z));
      TpPnt9D tpPnt9D4 = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
      tpPnt9D4.Type = 1;
      tpPnt9D4.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
      tpPnt9D4.MoveType = CamMoveType.Leave;
      CP.Points.Add(tpPnt9D4);
      points.Add(new Point3D(((TpArcData) tpPnt9D4).P9.X, ((TpArcData) tpPnt9D4).P9.Y, ((TpArcData) tpPnt9D4).P9.Z));
    }
    if (((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
    {
      if (((MarbleTempVars) Settings).NotchSideSafeAtXAxis)
      {
        if (i % 2 == 1)
        {
          TpPnt9D tpPnt9D5 = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D5.PlungeAxis = "X";
          tpPnt9D5.PlungeAxisMovement = true;
          tpPnt9D5.MoveType = CamMoveType.G0;
          CP.Points.Add(tpPnt9D5);
          points.Add(new Point3D(((TpArcData) tpPnt9D5).P9.X, ((TpArcData) tpPnt9D5).P9.Y, ((TpArcData) tpPnt9D5).P9.Z));
          TpPnt9D tpPnt9D6 = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D6.Type = 0;
          tpPnt9D6.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
          tpPnt9D6.MoveType = CamMoveType.G0;
          CP.Points.Add(tpPnt9D6);
          points.Add(new Point3D(((TpArcData) tpPnt9D6).P9.X, ((TpArcData) tpPnt9D6).P9.Y, ((TpArcData) tpPnt9D6).P9.Z));
          TpPnt9D tpPnt9D7 = new TpPnt9D(new Pnt6D(XVal + XOffset, 0.0, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D7.Type = 1;
          tpPnt9D7.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
          tpPnt9D7.PlungeAxis = "X";
          tpPnt9D7.MoveType = CamMoveType.Plunge;
          CP.Points.Add(tpPnt9D7);
          points.Add(new Point3D(((TpArcData) tpPnt9D7).P9.X, ((TpArcData) tpPnt9D7).P9.Y, ((TpArcData) tpPnt9D7).P9.Z));
          TpPnt9D tpPnt9D8 = new TpPnt9D(new Pnt6D(XVal + XOffset, ((ProfileSettings) Profile).Width * YSing, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D8.Type = 1;
          tpPnt9D8.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
          tpPnt9D8.MoveType = CamMoveType.G1;
          CP.Points.Add(tpPnt9D8);
          points.Add(new Point3D(((TpArcData) tpPnt9D8).P9.X, ((TpArcData) tpPnt9D8).P9.Y, ((TpArcData) tpPnt9D8).P9.Z));
          TpPnt9D tpPnt9D9 = new TpPnt9D(new Pnt6D(XSafe + XOffset, ((ProfileSettings) Profile).Width * YSing, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D9.Type = 1;
          tpPnt9D9.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D9.MoveType = CamMoveType.Leave;
          CP.Points.Add(tpPnt9D9);
          points.Add(new Point3D(((TpArcData) tpPnt9D9).P9.X, ((TpArcData) tpPnt9D9).P9.Y, ((TpArcData) tpPnt9D9).P9.Z));
        }
        else
        {
          CP.Points.Add(new TpPnt9D(new Pnt6D(XSafe + XOffset, ((ProfileSettings) Profile).Width * YSing, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
          {
            PlungeAxis = "X",
            PlungeAxisMovement = true,
            MoveType = CamMoveType.G0
          });
          TpPnt9D tpPnt9D10 = new TpPnt9D(new Pnt6D(XSafe + XOffset, ((ProfileSettings) Profile).Width * YSing, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D10.Type = 0;
          tpPnt9D10.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
          tpPnt9D10.MoveType = CamMoveType.G0;
          CP.Points.Add(tpPnt9D10);
          points.Add(new Point3D(((TpArcData) tpPnt9D10).P9.X, ((TpArcData) tpPnt9D10).P9.Y, ((TpArcData) tpPnt9D10).P9.Z));
          TpPnt9D tpPnt9D11 = new TpPnt9D(new Pnt6D(XVal + XOffset, ((ProfileSettings) Profile).Width * YSing, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D11.Type = 1;
          tpPnt9D11.MoveType = CamMoveType.Plunge;
          tpPnt9D11.PlungeAxis = "X";
          tpPnt9D11.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
          CP.Points.Add(tpPnt9D11);
          points.Add(new Point3D(((TpArcData) tpPnt9D11).P9.X, ((TpArcData) tpPnt9D11).P9.Y, ((TpArcData) tpPnt9D11).P9.Z));
          TpPnt9D tpPnt9D12 = new TpPnt9D(new Pnt6D(XVal + XOffset, 0.0, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D12.Type = 1;
          tpPnt9D12.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
          tpPnt9D12.MoveType = CamMoveType.G1;
          CP.Points.Add(tpPnt9D12);
          points.Add(new Point3D(((TpArcData) tpPnt9D12).P9.X, ((TpArcData) tpPnt9D12).P9.Y, ((TpArcData) tpPnt9D12).P9.Z));
          TpPnt9D tpPnt9D13 = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D13.Type = 1;
          tpPnt9D13.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D13.MoveType = CamMoveType.Leave;
          CP.Points.Add(tpPnt9D13);
          points.Add(new Point3D(((TpArcData) tpPnt9D13).P9.X, ((TpArcData) tpPnt9D13).P9.Y, ((TpArcData) tpPnt9D13).P9.Z));
        }
      }
      else if (i % 2 == 1)
      {
        TpPnt9D tpPnt9D14 = new TpPnt9D(new Pnt6D(XVal + XOffset, -(YSing * ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0), calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
        tpPnt9D14.PlungeAxis = "Y";
        tpPnt9D14.PlungeAxisMovement = true;
        tpPnt9D14.MoveType = CamMoveType.G0;
        CP.Points.Add(tpPnt9D14);
        points.Add(new Point3D(((TpArcData) tpPnt9D14).P9.X, ((TpArcData) tpPnt9D14).P9.Y, ((TpArcData) tpPnt9D14).P9.Z));
        TpPnt9D tpPnt9D15 = new TpPnt9D(new Pnt6D(XVal + XOffset, (((ProfileSettings) Profile).Width + ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0) * YSing, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
        tpPnt9D15.Type = 1;
        tpPnt9D15.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
        tpPnt9D15.MoveType = CamMoveType.G1;
        CP.Points.Add(tpPnt9D15);
        points.Add(new Point3D(((TpArcData) tpPnt9D15).P9.X, ((TpArcData) tpPnt9D15).P9.Y, ((TpArcData) tpPnt9D15).P9.Z));
      }
      else
      {
        CP.Points.Add(new TpPnt9D(new Pnt6D(XVal + XOffset, (((ProfileSettings) Profile).Width + ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0) * YSing, calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
        {
          PlungeAxis = "Y",
          PlungeAxisMovement = true,
          MoveType = CamMoveType.G0
        });
        TpPnt9D tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, -(YSing * ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0), calcZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
        tpPnt9D.Type = 1;
        tpPnt9D.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
        tpPnt9D.MoveType = CamMoveType.G1;
        CP.Points.Add(tpPnt9D);
        points.Add(new Point3D(((TpArcData) tpPnt9D).P9.X, ((TpArcData) tpPnt9D).P9.Y, ((TpArcData) tpPnt9D).P9.Z));
      }
    }
    LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
    CustomData customData = (CustomData) new ClipperOffset();
    ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.CamPlunge);
    linearPath.EntityData = (object) customData;
    CamCalc.EntitiesG1.Add((Entity) linearPath);
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      ((LayerBase5) ((ToolGeometry5) CamCalc.Tool).CamData).SimMoveOffset.X = -((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
      ((LayerBase5) ((ToolGeometry5) CamCalc.Tool).CamData).SimMoveOffset.X = ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
    CamCalc.CamPoints.Add(CP);
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      CamCalc.MoveOffset.X = -((ToolGeometry5) CamCalc.Tool).Geometry.Diameter / 2.0;
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation != ProfileNotchLocationType.Right)
      return;
    CamCalc.MoveOffset.X = ((ToolGeometry5) CamCalc.Tool).Geometry.Diameter / 2.0;
  }

  public void NotchCalcParameter(
    ProfileItem Profile,
    ToolBase5 toolSaw,
    ToolBase5 toolMilling,
    ref ProfileOperation P,
    ref double XOffset,
    ref double XSafe,
    ref double XStart,
    ref double XEnd,
    ref double XVal,
    ref double DistanceX,
    ref double YSafe,
    ref double YOffset,
    ref string Name)
  {
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Side)
    {
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation != 0 & ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation != ProfileNotchLocationType.Right)
        ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation = ProfileNotchLocationType.Left;
      Name = $"{buLangTranslate.preDef.Notch} {buLangTranslate.preDef.Side}";
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      {
        XOffset = -((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
        XSafe = -((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe;
        DistanceX = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth - ((ToolGeometry5) toolMilling).Geometry.Diameter / 2.0;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
      {
        XOffset = ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
        XSafe = ((ProfileSettings) Profile).Length + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe;
        DistanceX = ((ProfileSettings) Profile).Length - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth + ((ToolGeometry5) toolMilling).Geometry.Diameter / 2.0;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
        XVal = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth;
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
        XVal = ((ProfileSettings) Profile).Length - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth;
      ((ProfileMirror) ((ProfileRuntimeSettings) P).OperationData).selectedPlaneName = planeNames.Top;
      ((ProfilePatternCopy) ((ProfileRuntimeSettings) P).OperationData).selectedPlane = Plane.XY;
    }
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Length)
    {
      Name = $"{buLangTranslate.preDef.Notch} {buLangTranslate.preDef.Length}";
      if (((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth < ((ToolGeometry5) toolSaw).Geometry.Diameter)
      {
        if (((ProfileSettings) Profile).XReferanceLocation == LeftRightType.Left)
        {
          XStart = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X;
          XEnd = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth;
        }
        if (((ProfileSettings) Profile).XReferanceLocation == LeftRightType.Right)
        {
          XStart = ((ProfileSettings) Profile).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth;
          XEnd = ((ProfileSettings) Profile).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth;
        }
      }
      else if (buConversion5.EQ(((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X, 0.0))
      {
        if (((ProfileSettings) Profile).XReferanceLocation == LeftRightType.Left)
        {
          XStart = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X + ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
          XEnd = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth - ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
        }
        if (((ProfileSettings) Profile).XReferanceLocation == LeftRightType.Right)
        {
          XStart = ((ProfileSettings) Profile).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth + ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
          XEnd = ((ProfileSettings) Profile).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth - ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
        }
        if (XStart > XEnd)
          XStart = XEnd - 50.0;
      }
      else
      {
        if (((ProfileSettings) Profile).XReferanceLocation == LeftRightType.Left)
        {
          XStart = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X + ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
          XEnd = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth - ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
        }
        if (((ProfileSettings) Profile).XReferanceLocation == LeftRightType.Right)
        {
          XStart = ((ProfileSettings) Profile).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth + ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
          XEnd = ((ProfileSettings) Profile).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth - ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
        }
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Back)
      {
        YSafe = -((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe;
        DistanceX = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth - ((ToolGeometry5) toolMilling).Geometry.Diameter / 2.0;
        YOffset = ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Front)
      {
        YSafe = ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe;
        DistanceX = ((ProfileSettings) Profile).Length - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth + ((ToolGeometry5) toolMilling).Geometry.Diameter / 2.0;
        YOffset = -((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
        XVal = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X;
      ((ProfileMirror) ((ProfileRuntimeSettings) P).OperationData).selectedPlaneName = planeNames.Top;
      ((ProfilePatternCopy) ((ProfileRuntimeSettings) P).OperationData).selectedPlane = Plane.XY;
    }
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Vertical)
    {
      Name = $"{buLangTranslate.preDef.Notch} {buLangTranslate.preDef.Vertical}";
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      {
        XOffset = -((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
        XSafe = -((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe;
        DistanceX = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth - ((ToolGeometry5) toolMilling).Geometry.Diameter / 2.0;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
      {
        XOffset = ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0;
        XSafe = ((ProfileSettings) Profile).Length + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe;
        DistanceX = ((ProfileSettings) Profile).Length - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth + ((ToolGeometry5) toolMilling).Geometry.Diameter / 2.0;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
        XVal = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth;
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
        XVal = ((ProfileSettings) Profile).Length - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth;
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchFrontBack == FrontBackType.Front)
      {
        ((ProfileMirror) ((ProfileRuntimeSettings) P).OperationData).selectedPlaneName = planeNames.Front;
        ((ProfilePatternCopy) ((ProfileRuntimeSettings) P).OperationData).selectedPlane = Plane.XZ;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchFrontBack == FrontBackType.Back)
      {
        ((ProfileMirror) ((ProfileRuntimeSettings) P).OperationData).selectedPlaneName = planeNames.Back;
        ((ProfilePatternCopy) ((ProfileRuntimeSettings) P).OperationData).selectedPlane = Plane.XZ;
      }
    }
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType != ProfileNotchOperationType.Horizontal)
      return;
    Name = $"{buLangTranslate.preDef.Notch} {buLangTranslate.preDef.Horizontal}";
    if (((ProfileSettings) Profile).XReferanceLocation == LeftRightType.Left)
    {
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      {
        XStart = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X;
        XEnd = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth;
      }
      else
      {
        XEnd = ((ProfileSettings) Profile).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X;
        XStart = ((ProfileSettings) Profile).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth;
      }
    }
    if (((ProfileSettings) Profile).XReferanceLocation == LeftRightType.Right)
    {
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      {
        XEnd = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth;
        XStart = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X;
      }
      else
      {
        XStart = ((ProfileSettings) Profile).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth;
        XEnd = ((ProfileSettings) Profile).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X;
      }
    }
    ((ProfileMirror) ((ProfileRuntimeSettings) P).OperationData).selectedPlaneName = planeNames.Top;
    ((ProfilePatternCopy) ((ProfileRuntimeSettings) P).OperationData).selectedPlane = Plane.XY;
  }

  public void NotchWidthTypeCamMoveCalc(
    ref ProfileOperation P,
    ref camTpPoint CP,
    ref List<Point3D> PL,
    double XStart,
    double XEnd,
    double YSafe,
    double YVal,
    double DistanceZ)
  {
    TpPnt9D tpPnt9D1 = new TpPnt9D(new Pnt6D(XStart, YSafe, DistanceZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
    tpPnt9D1.Type = 0;
    tpPnt9D1.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
    tpPnt9D1.MoveType = CamMoveType.G0;
    CP.Points.Add(tpPnt9D1);
    PL.Add(new Point3D(((TpArcData) tpPnt9D1).P9.X, ((TpArcData) tpPnt9D1).P9.Y, ((TpArcData) tpPnt9D1).P9.Z));
    TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(XStart, YVal, DistanceZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
    tpPnt9D2.Type = 1;
    tpPnt9D2.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
    tpPnt9D2.MoveType = CamMoveType.G1;
    tpPnt9D2.PlungeAxis = "Y";
    tpPnt9D2.LeaveAxis = "Y";
    CP.Points.Add(tpPnt9D2);
    PL.Add(new Point3D(((TpArcData) tpPnt9D2).P9.X, ((TpArcData) tpPnt9D2).P9.Y, ((TpArcData) tpPnt9D2).P9.Z));
    TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(XEnd, YVal, DistanceZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
    tpPnt9D3.Type = 1;
    tpPnt9D3.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
    CP.Points.Add(tpPnt9D3);
    PL.Add(new Point3D(((TpArcData) tpPnt9D3).P9.X, ((TpArcData) tpPnt9D3).P9.Y, ((TpArcData) tpPnt9D3).P9.Z));
    TpPnt9D tpPnt9D4 = new TpPnt9D(new Pnt6D(XEnd, YSafe, DistanceZ), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
    tpPnt9D4.Type = 1;
    tpPnt9D4.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
    tpPnt9D4.MoveType = CamMoveType.G1;
    tpPnt9D4.PlungeAxis = "Y";
    tpPnt9D4.LeaveAxis = "Y";
    CP.Points.Add(tpPnt9D4);
    PL.Add(new Point3D(((TpArcData) tpPnt9D4).P9.X, ((TpArcData) tpPnt9D4).P9.Y, ((TpArcData) tpPnt9D4).P9.Z));
  }
}
