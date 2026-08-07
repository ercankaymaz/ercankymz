// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfilePatternCopy
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfilePatternCopy : buSerilization5
{
  public Plane selectedPlane;
  public Point3D movePlanePoint;
  public Point3D Position;

  public void CopyJustProfileProperties(ProfileItem refProfile, ref ProfileItem copyProfile)
  {
    ((ProfileSettings) copyProfile).Color = ((ProfileSettings) refProfile).Color;
    ((ProfileSettings) copyProfile).colorProfile = ((ProfileSettings) refProfile).colorProfile;
    ((ProfileSettings) copyProfile).colorSupportBlock = ((ProfileSettings) refProfile).colorSupportBlock;
    ((ProfileSettings) copyProfile).CreatedFromDrawing = ((ProfileSettings) refProfile).CreatedFromDrawing;
    ((ProfileSettings) copyProfile).Direction = new Vector3D(((ProfileSettings) refProfile).Direction.X, ((ProfileSettings) refProfile).Direction.Y, ((ProfileSettings) refProfile).Direction.Z);
    ((ProfileSettings) copyProfile).Enable = ((ProfileSettings) refProfile).Enable;
    ((ProfileSettings) copyProfile).FileName = ((ProfileSettings) refProfile).FileName;
    ((ProfileSettings) copyProfile).FileNameFull = ((ProfileSettings) refProfile).FileNameFull;
    ((ProfileSettings) copyProfile).Height = ((ProfileSettings) refProfile).Height;
    for (int index = 0; index <= ((ProfileSettings) refProfile).Drawings.Count - 1; ++index)
    {
      if (((MarbleJob) ((ProfileSettings) refProfile).Drawings[index]).InnerEntities != null)
      {
        ((MarbleJob) ((ProfileSettings) copyProfile).Drawings[index]).InnerEntities.Clear();
        buRadialDim.Copy(((MarbleJob) ((ProfileSettings) refProfile).Drawings[index]).InnerEntities, ref ((MarbleJob) ((ProfileSettings) copyProfile).Drawings[index]).InnerEntities);
      }
      if (((MarbleJob) ((ProfileSettings) refProfile).Drawings[index]).OutterEntitites != null)
      {
        ((MarbleJob) ((ProfileSettings) copyProfile).Drawings[index]).OutterEntitites.Clear();
        buRadialDim.Copy(((MarbleJob) ((ProfileSettings) refProfile).Drawings[index]).OutterEntitites, ref ((MarbleJob) ((ProfileSettings) copyProfile).Drawings[index]).OutterEntitites);
      }
      ((MarbleJob) ((ProfileSettings) copyProfile).Drawings[index]).InnerPoints.Clear();
      ((MarbleJob) ((ProfileSettings) copyProfile).Drawings[index]).OutterPoints.Clear();
      buVector5.Copy(((MarbleJob) ((ProfileSettings) refProfile).Drawings[index]).InnerPoints, ref ((MarbleJob) ((ProfileSettings) copyProfile).Drawings[index]).InnerPoints);
      buVector5.Copy(((MarbleJob) ((ProfileSettings) refProfile).Drawings[index]).OutterPoints, ref ((MarbleJob) ((ProfileSettings) copyProfile).Drawings[index]).OutterPoints);
      // ISSUE: reference to a compiler-generated field
      if (((buMarbleCalc.\u0001) ((ProfileSettings) refProfile).Drawings[index]).SolidEntity != null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        buRadialDim.Copy(((buMarbleCalc.\u0001) ((ProfileSettings) refProfile).Drawings[index]).SolidEntity, ref ((buMarbleCalc.\u0001) ((ProfileSettings) copyProfile).Drawings[index]).SolidEntity);
      }
    }
    ((ProfileSettings) copyProfile).ItemName = ((ProfileSettings) refProfile).ItemName;
    ((ProfileSettings) copyProfile).LeftAngle = ((ProfileSettings) refProfile).LeftAngle;
    if (((ProfileSettings) refProfile).LeftAngleEntity != null)
      buRadialDim.Copy(((ProfileSettings) refProfile).LeftAngleEntity, ref ((ProfileSettings) copyProfile).LeftAngleEntity);
    if (((ProfileSettings) refProfile).RightAngleEntity != null)
      buRadialDim.Copy(((ProfileSettings) refProfile).RightAngleEntity, ref ((ProfileSettings) copyProfile).RightAngleEntity);
    ((ProfileSettings) copyProfile).Length = ((ProfileSettings) refProfile).Length;
    ((ProfileSettings) copyProfile).MaxClamperNumber = ((ProfileSettings) refProfile).MaxClamperNumber;
    ((ProfileSettings) copyProfile).MaxOperationXPosition = ((ProfileSettings) refProfile).MaxOperationXPosition;
    ((ProfileSettings) copyProfile).ProfileCenterPoint = F_NotchEdit.ToPoint3D(((ProfileSettings) refProfile).ProfileCenterPoint);
    ((ProfileSettings) copyProfile).ProfileMaxPoint = F_NotchEdit.ToPoint3D(((ProfileSettings) refProfile).ProfileMaxPoint);
    ((ProfileSettings) copyProfile).ProfileMinPoint = F_NotchEdit.ToPoint3D(((ProfileSettings) refProfile).ProfileMinPoint);
    if (((ProfileSettings) refProfile).ProfileReferanceEntity != null)
      buRadialDim.Copy(((ProfileSettings) refProfile).ProfileReferanceEntity, ref ((ProfileSettings) copyProfile).ProfileReferanceEntity);
    if (((ProfileSettings) refProfile).SupportBlockEntities != null)
      buRadialDim.Copy(((ProfileSettings) refProfile).SupportBlockEntities, ref ((ProfileSettings) copyProfile).SupportBlockEntities);
    ((ProfileSettings) copyProfile).ProfileTraformations.Clear();
    for (int index = 0; index <= ((ProfileSettings) refProfile).ProfileTraformations.Count - 1; ++index)
      ((ProfileSettings) copyProfile).ProfileTraformations.Add(((ProfileSettings) refProfile).ProfileTraformations[index]);
    ((ProfileSettings) copyProfile).RightAngle = ((ProfileSettings) refProfile).RightAngle;
    ((ProfileSettings) copyProfile).selectedFreePlanes.Clear();
    for (int index = 0; index <= ((ProfileSettings) refProfile).selectedFreePlanes.Count - 1; ++index)
      ((ProfileSettings) copyProfile).selectedFreePlanes.Add((SelectedPlaneInfo) new hmiUISettings(((ProfileSettings) refProfile).selectedFreePlanes[index]));
    ((ProfileSettings) copyProfile).Skin = new MaterialSkin(((ProfileSettings) refProfile).Skin);
    ((ProfileSettings) copyProfile).StandartProfileIndex = ((ProfileSettings) refProfile).StandartProfileIndex;
    ((ProfileSettings) copyProfile).SupportBlock = (ProfileSupportBlock) new MarbleRuntimeSettings(((ProfileSettings) refProfile).SupportBlock);
    ((ProfileSettings) copyProfile).TextureName = ((ProfileSettings) refProfile).TextureName;
    ((ProfileSettings) copyProfile).Thickness = ((ProfileSettings) refProfile).Thickness;
    ((ProfileSettings) copyProfile).TotalOffset = ((ProfileSettings) refProfile).TotalOffset;
    ((ProfileSettings) copyProfile).Transparency = ((ProfileSettings) refProfile).Transparency;
    ((ProfileSettings) copyProfile).Width = ((ProfileSettings) refProfile).Width;
    ((ProfileSettings) copyProfile).XReferanceLocation = ((ProfileSettings) refProfile).XReferanceLocation;
    ((ProfileSettings) copyProfile).YDirection = ((ProfileSettings) refProfile).YDirection;
  }

  public void NotchCadCreate(
    ref ProfileOperation OP,
    ProfileItem curItem,
    double SupportBlockZHeight)
  {
    ((ShapeRuntimeData) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).Array).LineerEnable = false;
    Brep brep = (Brep) null;
    ((ProfileRuntimeSettings) OP).ProfileWidth = ((ProfileSettings) curItem).Width;
    ((ProfileRuntimeSettings) OP).ProfileHeight = ((ProfileSettings) curItem).Height;
    ((ProfileRuntimeSettings) OP).ProfileLength = ((ProfileSettings) curItem).Length;
    ((ProfileRuntimeSettings) OP).ProfileName = ((ProfileSettings) curItem).ItemName;
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Side)
    {
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      {
        brep = Brep.CreateBox(((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchDepth, ((ProfileSettings) curItem).Width, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight);
        brep.Regen(new RegenParams(buSystem.RegenDeviation));
        double dy = ((ProfileSettings) curItem).ProfileMaxPoint.Y - brep.BoxMax.Y;
        brep.Translate(0.0, dy);
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
      {
        brep = Brep.CreateBox(((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchDepth, ((ProfileSettings) curItem).Width, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight);
        brep.Regen(new RegenParams(buSystem.RegenDeviation));
        double dx = ((ProfileSettings) curItem).Length - brep.BoxMax.X;
        double dy = ((ProfileSettings) curItem).ProfileMaxPoint.Y - brep.BoxMax.Y;
        brep.Translate(dx, dy);
      }
    }
    else if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Length)
    {
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Back)
      {
        brep = Brep.CreateBox(((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchWidth, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchDepth, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight);
        brep.Regen(new RegenParams(buSystem.RegenDeviation));
        double dy = ((ProfileSettings) curItem).ProfileMaxPoint.Y - brep.BoxMax.Y;
        if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Left)
          brep.Translate(((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) OP).OperationData).basePosition.X, dy);
        if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Right)
          brep.Translate(((ProfileSettings) curItem).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) OP).OperationData).basePosition.X - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchWidth, dy);
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Front)
      {
        brep = Brep.CreateBox(((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchWidth, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchDepth, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight);
        brep.Regen(new RegenParams(buSystem.RegenDeviation));
        double num = ((ProfileSettings) curItem).ProfileMaxPoint.X - brep.BoxMax.X;
        double dy = ((ProfileSettings) curItem).ProfileMinPoint.Y + brep.BoxMax.Y - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchDepth;
        if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Left)
          brep.Translate(((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) OP).OperationData).basePosition.X, dy);
        if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Right)
          brep.Translate(((ProfileSettings) curItem).Length - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) OP).OperationData).basePosition.X - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchWidth, dy);
      }
    }
    else if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Vertical)
    {
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      {
        brep = Brep.CreateBox(((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchDepth, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight, ((ProfileSettings) curItem).Height);
        brep.Regen(new RegenParams(buSystem.RegenDeviation));
        double dy = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchFrontBack != FrontBackType.Back ? ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((ProfileSettings) curItem).ProfileMinPoint.Y : -((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - brep.BoxMax.Y;
        brep.Translate(0.0, dy);
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
      {
        brep = Brep.CreateBox(((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchDepth, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight, ((ProfileSettings) curItem).Height);
        brep.Regen(new RegenParams(buSystem.RegenDeviation));
        double dx = ((ProfileSettings) curItem).Length - brep.BoxMax.X;
        double dy = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchFrontBack != FrontBackType.Back ? ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((ProfileSettings) curItem).ProfileMinPoint.Y : -((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - brep.BoxMax.Y;
        brep.Translate(dx, dy);
      }
    }
    else if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Horizontal)
    {
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      {
        brep = Brep.CreateBox(((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchWidth, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchDepth);
        brep.Regen(new RegenParams(buSystem.RegenDeviation));
        double dy = -((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) OP).OperationData).basePosition.Y - (brep.BoxMax.Y + brep.BoxMin.Y) / 2.0;
        double x = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) OP).OperationData).basePosition.X;
        brep.Translate(x, dy);
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
      {
        brep = Brep.CreateBox(((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchWidth, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight, ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchDepth);
        brep.Regen(new RegenParams(buSystem.RegenDeviation));
        double dy = -((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) OP).OperationData).basePosition.Y - (brep.BoxMax.Y + brep.BoxMin.Y) / 2.0;
        double dx = ((ProfileSettings) curItem).Length - brep.BoxMax.X - ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) OP).OperationData).basePosition.X;
        brep.Translate(dx, dy);
      }
    }
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Side)
    {
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up && brep != null)
      {
        double dz = ((ProfileSettings) curItem).ProfileMaxPoint.Z - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - brep.BoxMax.Z;
        brep.Translate(0.0, 0.0, dz);
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down && brep != null)
      {
        double dz = brep.BoxMin.Z + ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
        brep.Translate(0.0, 0.0, dz);
      }
    }
    else if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Length)
    {
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up && brep != null)
      {
        double dz = ((ProfileSettings) curItem).ProfileMaxPoint.Z - brep.BoxMax.Z - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
        brep.Translate(0.0, 0.0, dz);
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down && brep != null)
      {
        double dz = brep.BoxMin.Z + ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
        brep.Translate(0.0, 0.0, dz);
      }
    }
    else if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Horizontal && brep != null)
    {
      double dz = ((ProfileSettings) curItem).ProfileMaxPoint.Z - brep.BoxMax.Z;
      brep.Translate(0.0, 0.0, dz);
    }
    if (brep == null)
      return;
    brep.Regen(new RegenParams(buSystem.RegenDeviation));
    CustomData customData = (CustomData) new ClipperOffset();
    ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Operation);
    brep.EntityData = (object) customData;
    ((ProfileRuntimeSettings) OP).EntityMultiSolidDepth.Add((Entity) brep);
  }

  public int NotchCalc(
    ref ProfileOperation P,
    ref camTp CamCalc,
    ProfileItem Profile,
    List<ToolBase5> ToolList,
    ProfileSettings Settings)
  {
    try
    {
      string Name = "";
      CamCalc = new camTp();
      camTpPoint CP = (camTpPoint) new TpPnt9D();
      CamCalc.Name = "Profile -" + Name;
      TpPnt9D tpPnt9D1 = new TpPnt9D();
      ToolBase5 toolBase5_1 = (ToolBase5) null;
      ToolBase5 toolBase5_2 = (ToolBase5) null;
      double num1 = 0.0;
      double YSing = -1.0;
      double XOffset = 0.0;
      double YOffset = 0.0;
      double XStart = 0.0;
      double XEnd = 0.0;
      double YSafe = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      for (int index = 0; index <= ToolList.Count - 1; ++index)
      {
        if (((ToolGeometry5) ToolList[index]).Purpose == ToolPurpose.Saw)
          toolBase5_1 = (ToolBase5) new ToolGeometry5(ToolList[index]);
        if (((ToolGeometry5) ToolList[index]).Purpose == ToolPurpose.Milling)
        {
          if (toolBase5_2 == null)
          {
            if (((ToolGeometry5) ToolList[index]).Geometry.Length > ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight && ((ToolGeometry5) ToolList[index]).Geometry.Diameter / 2.0 <= ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth)
              toolBase5_2 = (ToolBase5) new ToolGeometry5(ToolList[index]);
          }
          else if (((ToolGeometry5) ToolList[index]).Geometry.Length > ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight && ((ToolGeometry5) ToolList[index]).Geometry.Diameter / 2.0 <= ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth && ((ToolGeometry5) ToolList[index]).Geometry.Diameter < ((ToolGeometry5) toolBase5_2).Geometry.Diameter)
            toolBase5_2 = (ToolBase5) new ToolGeometry5(ToolList[index]);
        }
      }
      ToolBase5 toolBase5_3 = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) P).Tool);
      ToolBase5 toolBase5_4 = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) P).ToolNotch);
      if (toolBase5_4 == null || toolBase5_3 == null & ((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutType == ProfileNotchCutType.BySawAndMilling)
        return -1;
      List<double> refValues = new List<double>();
      List<double> doubleList = new List<double>();
      double XVal = 0.0;
      double XSafe = 0.0;
      double num4 = 0.0;
      double DistanceX = 0.0;
      ((ProfileOnlineOpOptions) this).NotchCalcParameter(Profile, toolBase5_4, toolBase5_3, ref P, ref XOffset, ref XSafe, ref XStart, ref XEnd, ref XVal, ref DistanceX, ref YSafe, ref YOffset, ref Name);
      ((ProfileRuntimeSettings) P).ToolNotch = (ToolBase5) new ToolGeometry5(toolBase5_4);
      ((ProfileRuntimeSettings) P).Tool = (ToolBase5) new ToolGeometry5(toolBase5_3);
      ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).ToolName = ((ToolCamData5) ((ToolGeometry5) toolBase5_3).Data).Name;
      ((ToolCheckOption) ((ProfileRuntimeSettings) P).OperationData).ToolNotchName = ((ToolCamData5) ((ToolGeometry5) toolBase5_4).Data).Name;
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Horizontal)
        refValues.Add(((ProfileSettings) Profile).Height - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth);
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Side | ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Length)
      {
        ((ProfileRuntimeSettings) P).Width = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth;
        ((ProfileRuntimeSettings) P).Height = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
        ((ProfileRuntimeSettings) P).Start = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart;
        ((ProfileRuntimeSettings) P).Depth = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth;
        ((ProfileRuntimeSettings) P).NotchLocation = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation;
        double num5 = Math.Round(((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness, 3) * ((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutPersentage / 100.0;
        double num6;
        double num7;
        double num8;
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
        {
          num6 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight - Math.Round(((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness, 3);
          num7 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart;
          num8 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart;
        }
        else if (((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight >= ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness)
        {
          num6 = ((ProfileSettings) Profile).ProfileMaxPoint.Z - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart - ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness;
          num7 = ((ProfileSettings) Profile).ProfileMaxPoint.Z - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
          num8 = ((ProfileSettings) Profile).ProfileMaxPoint.Z - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
        }
        else
        {
          num6 = ((ProfileSettings) Profile).ProfileMaxPoint.Z - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
          num7 = ((ProfileSettings) Profile).ProfileMaxPoint.Z - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
          num8 = ((ProfileSettings) Profile).ProfileMaxPoint.Z - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
        }
        double num9 = num6 - num7;
        int int32 = Convert.ToInt32(buNumeric.RoundToUpper(buNumeric.RoundToUpper(num9 / num5)));
        double num10 = Math.Round(num9 / (double) int32, 5);
        refValues.Add(num8);
        for (int index = 1; index <= int32; ++index)
        {
          double num11 = Math.Round(num8 + num10, 5);
          if (!buFile5.isValueAvailableInList(refValues, num11))
          {
            refValues.Add(num11);
            num8 = num11;
          }
        }
        if (!buFile5.isValueAvailableInList(refValues, num6))
          refValues.Add(num6);
        if (((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).CutDirection == UpDownDirectionType.UpToDown)
          refValues.Reverse();
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Vertical)
      {
        ((ProfileRuntimeSettings) P).Width = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth;
        ((ProfileRuntimeSettings) P).Height = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
        ((ProfileRuntimeSettings) P).Start = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart;
        ((ProfileRuntimeSettings) P).Depth = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth;
        ((ProfileRuntimeSettings) P).NotchLocation = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation;
        double num12 = ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness * ((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutPersentage / 100.0;
        double num13;
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchFrontBack == FrontBackType.Front)
        {
          num3 = -((ProfileSettings) Profile).Width + ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight - num12;
          num2 = -((ProfileSettings) Profile).Width + ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart + ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness;
          num13 = -((ProfileSettings) Profile).Width + ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
        }
        else
        {
          num3 = -((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart - num12 - ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness;
          num2 = -((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
          num13 = -((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart - ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness;
        }
        double num14 = num3 - num2;
        int int32 = Convert.ToInt32(buNumeric.RoundToUpper(buNumeric.RoundToUpper(num14 / num12)));
        double num15 = Math.Round(num14 / (double) int32, 5);
        doubleList.Clear();
        doubleList.Add(num13);
        for (int index = 1; index <= int32; ++index)
        {
          num4 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchFrontBack != FrontBackType.Front ? Math.Round(num13 - num15, 5) : Math.Round(num13 - num15, 5);
          doubleList.Add(num4);
          num13 = num4;
        }
        doubleList.Add(num2);
        if (((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).CutDirection == UpDownDirectionType.UpToDown)
          doubleList.Reverse();
      }
      bool flag = false;
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up & ((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutType == ProfileNotchCutType.BySawAndMilling)
        flag = true;
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchStart != 0.0)
        flag = false;
      if (flag)
      {
        if (toolBase5_3 == null)
          return -1;
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Side)
        {
          ((ProfileRuntimeSettings) P).Tool = (ToolBase5) new ToolGeometry5(toolBase5_3);
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_4);
          double z = ((ProfileSettings) Profile).Height - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight + ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness / 2.0 + num1;
          List<Point3D> points1 = new List<Point3D>();
          TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D2.PlungeAxis = "X";
          tpPnt9D2.PlungeAxisMovement = true;
          tpPnt9D2.MoveType = CamMoveType.Plunge;
          CP.Points.Add(tpPnt9D2);
          points1.Add(new Point3D(((TpArcData) tpPnt9D2).P9.X, ((TpArcData) tpPnt9D2).P9.Y, ((TpArcData) tpPnt9D2).P9.Z));
          TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, z), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D3.Type = 0;
          tpPnt9D3.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
          tpPnt9D3.MoveType = CamMoveType.G0;
          CP.Points.Add(tpPnt9D3);
          points1.Add(new Point3D(((TpArcData) tpPnt9D3).P9.X, ((TpArcData) tpPnt9D3).P9.Y, ((TpArcData) tpPnt9D3).P9.Z));
          TpPnt9D tpPnt9D4 = new TpPnt9D(new Pnt6D(XVal + XOffset, 0.0, z), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D4.Type = 1;
          tpPnt9D4.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
          tpPnt9D4.MoveType = CamMoveType.G1;
          CP.Points.Add(tpPnt9D4);
          points1.Add(new Point3D(((TpArcData) tpPnt9D4).P9.X, ((TpArcData) tpPnt9D4).P9.Y, ((TpArcData) tpPnt9D4).P9.Z));
          TpPnt9D tpPnt9D5 = new TpPnt9D(new Pnt6D(XVal + XOffset, ((ProfileSettings) Profile).Width * YSing, z), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D5.Type = 1;
          tpPnt9D5.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
          tpPnt9D5.MoveType = CamMoveType.G1;
          CP.Points.Add(tpPnt9D5);
          points1.Add(new Point3D(((TpArcData) tpPnt9D5).P9.X, ((TpArcData) tpPnt9D5).P9.Y, ((TpArcData) tpPnt9D5).P9.Z));
          TpPnt9D tpPnt9D6 = new TpPnt9D(new Pnt6D(XSafe + XOffset, ((ProfileSettings) Profile).Width * YSing, z), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D6.Type = 1;
          tpPnt9D6.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D6.MoveType = CamMoveType.G1;
          CP.Points.Add(tpPnt9D6);
          points1.Add(new Point3D(((TpArcData) tpPnt9D6).P9.X, ((TpArcData) tpPnt9D6).P9.Y, ((TpArcData) tpPnt9D6).P9.Z));
          TpPnt9D tpPnt9D7 = new TpPnt9D(new Pnt6D(XSafe + XOffset, ((ProfileSettings) Profile).Width * YSing, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D7.Type = 0;
          tpPnt9D7.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D7.MoveType = CamMoveType.G0;
          CP.Points.Add(tpPnt9D7);
          points1.Add(new Point3D(((TpArcData) tpPnt9D7).P9.X, ((TpArcData) tpPnt9D7).P9.Y, ((TpArcData) tpPnt9D7).P9.Z));
          LinearPath linearPath1 = new LinearPath((ICollection<Point3D>) points1);
          CamCalc.CamPoints.Add(CP);
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_4);
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
            ((LayerBase5) ((ToolGeometry5) CamCalc.Tool).CamData).SimMoveOffset.X = -((ToolGeometry5) toolBase5_4).Geometry.Diameter / 2.0;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
            ((LayerBase5) ((ToolGeometry5) CamCalc.Tool).CamData).SimMoveOffset.X = ((ToolGeometry5) toolBase5_4).Geometry.Diameter / 2.0;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
            CamCalc.MoveOffset.X = -((ToolGeometry5) CamCalc.Tool).Geometry.Diameter / 2.0;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
            CamCalc.MoveOffset.X = ((ToolGeometry5) CamCalc.Tool).Geometry.Diameter / 2.0;
          ((ProfileRuntimeSettings) P).CamCalculation.Add(CamCalc);
          CamCalc = new camTp();
          camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
          CamCalc.Name = "Profile -" + Name;
          tpPnt9D1 = new TpPnt9D();
          List<Point3D> points2 = new List<Point3D>();
          TpPnt9D tpPnt9D8 = new TpPnt9D(new Pnt6D(DistanceX, 0.0, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe + num1), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D8.PlungeAxis = "Z";
          tpPnt9D8.PlungeAxisMovement = true;
          tpPnt9D8.MoveType = CamMoveType.Plunge;
          camTpPoint.Points.Add(tpPnt9D8);
          points2.Add(new Point3D(((TpArcData) tpPnt9D8).P9.X, ((TpArcData) tpPnt9D8).P9.Y, ((TpArcData) tpPnt9D8).P9.Z));
          TpPnt9D tpPnt9D9 = new TpPnt9D(new Pnt6D(DistanceX, 0.0, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe + num1), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D9.Type = 0;
          tpPnt9D9.MoveType = CamMoveType.G0;
          tpPnt9D9.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
          camTpPoint.Points.Add(tpPnt9D9);
          points2.Add(new Point3D(((TpArcData) tpPnt9D9).P9.X, ((TpArcData) tpPnt9D9).P9.Y, ((TpArcData) tpPnt9D9).P9.Z));
          TpPnt9D tpPnt9D10 = new TpPnt9D(new Pnt6D(DistanceX, 0.0, z - ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness / 2.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D10.Type = 1;
          tpPnt9D10.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
          tpPnt9D10.MoveType = CamMoveType.G1;
          camTpPoint.Points.Add(tpPnt9D10);
          points2.Add(new Point3D(((TpArcData) tpPnt9D10).P9.X, ((TpArcData) tpPnt9D10).P9.Y, ((TpArcData) tpPnt9D10).P9.Z));
          TpPnt9D tpPnt9D11 = new TpPnt9D(new Pnt6D(DistanceX, ((ProfileSettings) Profile).Width * YSing, z - ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness / 2.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D11.Type = 1;
          tpPnt9D11.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
          tpPnt9D11.MoveType = CamMoveType.G1;
          camTpPoint.Points.Add(tpPnt9D11);
          points2.Add(new Point3D(((TpArcData) tpPnt9D11).P9.X, ((TpArcData) tpPnt9D11).P9.Y, ((TpArcData) tpPnt9D11).P9.Z));
          TpPnt9D tpPnt9D12 = new TpPnt9D(new Pnt6D(DistanceX, ((ProfileSettings) Profile).Width * YSing, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe + num1), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D12.Type = 1;
          tpPnt9D12.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D12.MoveType = CamMoveType.G1;
          camTpPoint.Points.Add(tpPnt9D12);
          points2.Add(new Point3D(((TpArcData) tpPnt9D12).P9.X, ((TpArcData) tpPnt9D12).P9.Y, ((TpArcData) tpPnt9D12).P9.Z));
          LinearPath linearPath2 = new LinearPath((ICollection<Point3D>) points2);
          CamCalc.CamPoints.Add(camTpPoint);
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_3);
          ((ProfileRuntimeSettings) P).CamCalculation.Add(CamCalc);
          refValues.Clear();
          return 1;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Length)
        {
          ((ProfileRuntimeSettings) P).Tool = (ToolBase5) new ToolGeometry5(toolBase5_3);
          ((ProfileRuntimeSettings) P).ToolNotch = (ToolBase5) new ToolGeometry5(toolBase5_4);
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_4);
          double DistanceZ = ((ProfileSettings) Profile).Height - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight + ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness / 2.0 + num1;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Front)
          {
            num4 = (((ProfileSettings) Profile).Width - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth) * YSing + YOffset;
            YSafe = (((ProfileSettings) Profile).Width + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe) * YSing + YOffset;
          }
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Back)
          {
            num4 = -((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth + YOffset;
            YSafe = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe + YOffset;
          }
          List<Point3D> PL = new List<Point3D>();
          TpPnt9D tpPnt9D13 = new TpPnt9D(new Pnt6D(XStart, YSafe, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D13.PlungeAxis = "Y";
          tpPnt9D13.PlungeAxisMovement = true;
          tpPnt9D13.MoveType = CamMoveType.Plunge;
          CP.Points.Add(tpPnt9D13);
          PL.Add(new Point3D(((TpArcData) tpPnt9D13).P9.X, ((TpArcData) tpPnt9D13).P9.Y, ((TpArcData) tpPnt9D13).P9.Z));
          ((ProfileOnlineOpOptions) this).NotchWidthTypeCamMoveCalc(ref P, ref CP, ref PL, XStart, XEnd, YSafe, num4, DistanceZ);
          LinearPath linearPath3 = new LinearPath((ICollection<Point3D>) PL);
          CamCalc.CamPoints.Add(CP);
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_4);
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Front)
            ;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Back)
            ;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Front)
            CamCalc.MoveOffset.Y = -((ToolGeometry5) CamCalc.Tool).Geometry.Diameter / 2.0;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Back)
            CamCalc.MoveOffset.Y = ((ToolGeometry5) CamCalc.Tool).Geometry.Diameter / 2.0;
          ((ProfileRuntimeSettings) P).CamCalculation.Add(CamCalc);
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Front)
            num4 = -((ProfileSettings) Profile).Width + ((ToolGeometry5) toolBase5_3).Geometry.Diameter / 2.0 + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Back)
            num4 = -((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth + ((ToolGeometry5) toolBase5_3).Geometry.Diameter / 2.0;
          CamCalc = new camTp();
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_3);
          XStart = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X + ((ToolGeometry5) toolBase5_3).Geometry.Diameter / 2.0;
          double x = ((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.X + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchWidth - ((ToolGeometry5) toolBase5_3).Geometry.Diameter / 2.0;
          camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
          CamCalc.Name = "Profile -" + Name;
          tpPnt9D1 = new TpPnt9D();
          List<Point3D> points = new List<Point3D>();
          TpPnt9D tpPnt9D14 = new TpPnt9D(new Pnt6D(XStart, num4, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe + num1), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D14.PlungeAxis = "Z";
          tpPnt9D14.PlungeAxisMovement = true;
          tpPnt9D14.MoveType = CamMoveType.Plunge;
          camTpPoint.Points.Add(tpPnt9D14);
          points.Add(new Point3D(((TpArcData) tpPnt9D14).P9.X, ((TpArcData) tpPnt9D14).P9.Y, ((TpArcData) tpPnt9D14).P9.Z));
          TpPnt9D tpPnt9D15 = new TpPnt9D(new Pnt6D(XStart, num4, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe + num1), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D15.Type = 0;
          tpPnt9D15.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
          tpPnt9D15.MoveType = CamMoveType.G0;
          camTpPoint.Points.Add(tpPnt9D15);
          points.Add(new Point3D(((TpArcData) tpPnt9D15).P9.X, ((TpArcData) tpPnt9D15).P9.Y, ((TpArcData) tpPnt9D15).P9.Z));
          TpPnt9D tpPnt9D16 = new TpPnt9D(new Pnt6D(XStart, num4, DistanceZ - ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness / 2.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D16.Type = 1;
          tpPnt9D16.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
          tpPnt9D16.MoveType = CamMoveType.G1;
          camTpPoint.Points.Add(tpPnt9D16);
          points.Add(new Point3D(((TpArcData) tpPnt9D16).P9.X, ((TpArcData) tpPnt9D16).P9.Y, ((TpArcData) tpPnt9D16).P9.Z));
          TpPnt9D tpPnt9D17 = new TpPnt9D(new Pnt6D(x, num4, DistanceZ - ((ToolDisplay5) ((ToolGeometry5) toolBase5_4).Geometry).Thickness / 2.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D17.Type = 1;
          tpPnt9D17.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
          tpPnt9D17.MoveType = CamMoveType.G1;
          camTpPoint.Points.Add(tpPnt9D17);
          points.Add(new Point3D(((TpArcData) tpPnt9D17).P9.X, ((TpArcData) tpPnt9D17).P9.Y, ((TpArcData) tpPnt9D17).P9.Z));
          TpPnt9D tpPnt9D18 = new TpPnt9D(new Pnt6D(x, num4, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe + num1), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D18.Type = 1;
          tpPnt9D18.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D18.MoveType = CamMoveType.G1;
          camTpPoint.Points.Add(tpPnt9D18);
          points.Add(new Point3D(((TpArcData) tpPnt9D18).P9.X, ((TpArcData) tpPnt9D18).P9.Y, ((TpArcData) tpPnt9D18).P9.Z));
          LinearPath linearPath4 = new LinearPath((ICollection<Point3D>) points);
          CamCalc.CamPoints.Add(camTpPoint);
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_3);
          ((ProfileRuntimeSettings) P).CamCalculation.Add(CamCalc);
          refValues.Clear();
          return 1;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Vertical)
        {
          double a = 90.0;
          ((ProfileRuntimeSettings) P).Tool = (ToolBase5) new ToolGeometry5(toolBase5_3);
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_4);
          double height = ((ProfileSettings) Profile).Height;
          double y1;
          if (((ProfileMirror) ((ProfileRuntimeSettings) P).OperationData).selectedPlaneName == planeNames.Front)
          {
            y1 = num3;
          }
          else
          {
            y1 = num2;
            a = -90.0;
          }
          List<Point3D> points3 = new List<Point3D>();
          CP.Points.Add(new TpPnt9D(new Pnt6D(XSafe + XOffset, y1, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
          {
            PlungeAxis = "X",
            PlungeAxisMovement = true,
            MoveType = CamMoveType.Plunge
          });
          CP.Points.Add(new TpPnt9D(new Pnt6D(XSafe + XOffset, y1, height, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
          {
            Type = 0,
            Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid,
            MoveType = CamMoveType.G0
          });
          TpPnt9D tpPnt9D19 = new TpPnt9D(new Pnt6D(XVal + XOffset, y1, height, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D19.Type = 1;
          tpPnt9D19.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
          tpPnt9D19.MoveType = CamMoveType.G1;
          CP.Points.Add(tpPnt9D19);
          points3.Add(new Point3D(((TpArcData) tpPnt9D19).P9.X, ((TpArcData) tpPnt9D19).P9.Y, ((TpArcData) tpPnt9D19).P9.Z));
          TpPnt9D tpPnt9D20 = new TpPnt9D(new Pnt6D(XVal + XOffset, y1, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D20.Type = 1;
          tpPnt9D20.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
          tpPnt9D20.MoveType = CamMoveType.G1;
          CP.Points.Add(tpPnt9D20);
          points3.Add(new Point3D(((TpArcData) tpPnt9D20).P9.X, ((TpArcData) tpPnt9D20).P9.Y, ((TpArcData) tpPnt9D20).P9.Z));
          TpPnt9D tpPnt9D21 = new TpPnt9D(new Pnt6D(XSafe + XOffset, y1, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D21.Type = 1;
          tpPnt9D21.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D21.MoveType = CamMoveType.G1;
          CP.Points.Add(tpPnt9D21);
          points3.Add(new Point3D(((TpArcData) tpPnt9D21).P9.X, ((TpArcData) tpPnt9D21).P9.Y, ((TpArcData) tpPnt9D21).P9.Z));
          TpPnt9D tpPnt9D22 = new TpPnt9D(new Pnt6D(XSafe + XOffset, y1, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D22.Type = 0;
          tpPnt9D22.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D22.MoveType = CamMoveType.G0;
          CP.Points.Add(tpPnt9D22);
          points3.Add(new Point3D(((TpArcData) tpPnt9D22).P9.X, ((TpArcData) tpPnt9D22).P9.Y, ((TpArcData) tpPnt9D22).P9.Z));
          TpPnt9D tpPnt9D23 = new TpPnt9D(new Pnt6D(XSafe + XOffset, y1, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D23.Type = 0;
          tpPnt9D23.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D23.MoveType = CamMoveType.G0;
          CP.Points.Add(tpPnt9D23);
          points3.Add(new Point3D(((TpArcData) tpPnt9D23).P9.X, ((TpArcData) tpPnt9D23).P9.Y, ((TpArcData) tpPnt9D23).P9.Z));
          CP.Points.Add(new TpPnt9D(new Pnt6D(XSafe + XOffset, y1, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe, 90.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
          {
            Type = 0,
            Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave,
            MoveType = CamMoveType.G0
          });
          LinearPath linearPath5 = new LinearPath((ICollection<Point3D>) points3);
          CamCalc.CamPoints.Add(CP);
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_4);
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
            ((LayerBase5) ((ToolGeometry5) CamCalc.Tool).CamData).SimMoveOffset.X = -((ToolGeometry5) toolBase5_4).Geometry.Diameter / 2.0;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
            ((LayerBase5) ((ToolGeometry5) CamCalc.Tool).CamData).SimMoveOffset.X = ((ToolGeometry5) toolBase5_4).Geometry.Diameter / 2.0;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
            CamCalc.MoveOffset.X = -((ToolGeometry5) CamCalc.Tool).Geometry.Diameter / 2.0;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
            CamCalc.MoveOffset.X = ((ToolGeometry5) CamCalc.Tool).Geometry.Diameter / 2.0;
          ((ProfileRuntimeSettings) P).CamCalculation.Add(CamCalc);
          CamCalc = new camTp();
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_3);
          double y2;
          if (((ProfileMirror) ((ProfileRuntimeSettings) P).OperationData).selectedPlaneName == planeNames.Front)
          {
            YSafe = -((ProfileSettings) Profile).Width - ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe;
            y2 = -((ProfileSettings) Profile).Width + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
          }
          else
          {
            YSafe = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe;
            y2 = -((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight;
          }
          double z = ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe + num1;
          camTpPoint camTpPoint = (camTpPoint) new TpPnt9D();
          CamCalc.Name = "Profile -" + Name;
          tpPnt9D1 = new TpPnt9D();
          List<Point3D> points4 = new List<Point3D>();
          camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(DistanceX, YSafe, z, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
          {
            PlungeAxis = "Z",
            PlungeAxisMovement = true,
            MoveType = CamMoveType.Plunge
          });
          camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(DistanceX, YSafe, z, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
          {
            Type = 0,
            Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid,
            MoveType = CamMoveType.G0
          });
          TpPnt9D tpPnt9D24 = new TpPnt9D(new Pnt6D(DistanceX, y2, z, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D24.Type = 1;
          tpPnt9D24.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
          camTpPoint.Points.Add(tpPnt9D24);
          tpPnt9D24.MoveType = CamMoveType.G1;
          points4.Add(new Point3D(((TpArcData) tpPnt9D24).P9.X, ((TpArcData) tpPnt9D24).P9.Y, ((TpArcData) tpPnt9D24).P9.Z));
          TpPnt9D tpPnt9D25 = new TpPnt9D(new Pnt6D(DistanceX, y2, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D25.Type = 1;
          tpPnt9D25.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
          tpPnt9D25.MoveType = CamMoveType.G1;
          camTpPoint.Points.Add(tpPnt9D25);
          points4.Add(new Point3D(((TpArcData) tpPnt9D25).P9.X, ((TpArcData) tpPnt9D25).P9.Y, ((TpArcData) tpPnt9D25).P9.Z));
          TpPnt9D tpPnt9D26 = new TpPnt9D(new Pnt6D(DistanceX, YSafe, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D26.Type = 0;
          tpPnt9D26.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D26.MoveType = CamMoveType.G0;
          camTpPoint.Points.Add(tpPnt9D26);
          points4.Add(new Point3D(((TpArcData) tpPnt9D26).P9.X, ((TpArcData) tpPnt9D26).P9.Y, ((TpArcData) tpPnt9D26).P9.Z));
          camTpPoint.Points.Add(new TpPnt9D(new Pnt6D(DistanceX, YSafe, z, 0.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1)
          {
            Type = 0,
            Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave,
            MoveType = CamMoveType.G0
          });
          LinearPath linearPath6 = new LinearPath((ICollection<Point3D>) points4);
          CamCalc.CamPoints.Add(camTpPoint);
          CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_3);
          ((ProfileRuntimeSettings) P).CamCalculation.Add(CamCalc);
          refValues.Clear();
          return 1;
        }
      }
      for (int index1 = 0; index1 <= refValues.Count - 1; ++index1)
      {
        CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolBase5_4);
        List<Point3D> PL1 = new List<Point3D>();
        CP = (camTpPoint) new TpPnt9D();
        double num16 = refValues[index1];
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Side)
          ((ProfileOnlineOpOptions) this).NotchSideCalc(ref CP, ref P, ref CamCalc, index1, toolBase5_4, Profile, XVal, XSafe, XOffset, YSing, num16, Settings);
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Length)
        {
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Front)
          {
            num4 = (((ProfileSettings) Profile).Width - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth) * YSing + YOffset;
            YSafe = (((ProfileSettings) Profile).Width + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe) * YSing + YOffset;
          }
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Back)
          {
            num4 = -((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchDepth + YOffset;
            YSafe = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe + YOffset;
          }
          if (((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
            ((ProfileOnlineOpOptions) this).NotchWidthTypeCamMoveCalc(ref P, ref CP, ref PL1, XStart, XEnd, YSafe, num4, num16);
          if (((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
          {
            if (index1 % 2 == 1)
              ((ProfileOnlineOpOptions) this).NotchWidthTypeCamMoveCalc(ref P, ref CP, ref PL1, XEnd, XStart, YSafe, num4, num16);
            else
              ((ProfileOnlineOpOptions) this).NotchWidthTypeCamMoveCalc(ref P, ref CP, ref PL1, XStart, XEnd, YSafe, num4, num16);
          }
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) PL1);
          CustomData customData = (CustomData) new ClipperOffset();
          ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.CamPlunge);
          linearPath.EntityData = (object) customData;
          CamCalc.EntitiesG1.Add((Entity) linearPath);
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
            ((LayerBase5) ((ToolGeometry5) CamCalc.Tool).CamData).SimMoveOffset.X = -((ToolGeometry5) toolBase5_4).Geometry.Diameter / 2.0;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
            ((LayerBase5) ((ToolGeometry5) CamCalc.Tool).CamData).SimMoveOffset.X = ((ToolGeometry5) toolBase5_4).Geometry.Diameter / 2.0;
          CamCalc.CamPoints.Add(CP);
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
            CamCalc.MoveOffset.X = -((ToolGeometry5) CamCalc.Tool).Geometry.Diameter / 2.0;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
            CamCalc.MoveOffset.X = ((ToolGeometry5) CamCalc.Tool).Geometry.Diameter / 2.0;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Horizontal)
        {
          double Start = Math.Round(-((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.Y + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight / 2.0, 5);
          double End = Math.Round(-((ProfileOnlineOpOptions) ((ProfileRuntimeSettings) P).OperationData).basePosition.Y - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchHeight / 2.0);
          List<double> calcSteps = new List<double>();
          buCall.\u0001.StepCalculation(Start, End, Math.Round(((ToolDisplay5) ((ToolGeometry5) ((ProfileRuntimeSettings) P).ToolNotch).Geometry).Thickness), ref calcSteps);
          for (int index2 = 0; index2 <= calcSteps.Count - 1; ++index2)
          {
            CP = (camTpPoint) new TpPnt9D();
            List<Point3D> PL2 = new List<Point3D>();
            ((ToolCheckOption) this).NotchHorizontalTypeCamMoveCalc(toolBase5_4, ref P, ref CP, ref PL2, XStart, XEnd, calcSteps[index2] + ((ToolDisplay5) ((ToolGeometry5) ((ProfileRuntimeSettings) P).ToolNotch).Geometry).Thickness / 2.0, ((ProfileSettings) Profile).Height + ((PanelCutSettings) ((ProfileRuntimeSettings) P).CamOPData).distanceSafe, num16);
            LinearPath linearPath = new LinearPath((ICollection<Point3D>) PL2);
            CustomData customData = (CustomData) new ClipperOffset();
            ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.CamPlunge);
            linearPath.EntityData = (object) customData;
            CamCalc.EntitiesG1.Add((Entity) linearPath);
            if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
              ((LayerBase5) ((ToolGeometry5) CamCalc.Tool).CamData).SimMoveOffset.X = -((ToolGeometry5) toolBase5_4).Geometry.Diameter / 2.0;
            if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
              ((LayerBase5) ((ToolGeometry5) CamCalc.Tool).CamData).SimMoveOffset.X = ((ToolGeometry5) toolBase5_4).Geometry.Diameter / 2.0;
            CamCalc.CamPoints.Add(CP);
          }
          ((ProfileRuntimeSettings) P).CamCalculation.Add(CamCalc);
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).UseMilling)
          {
            CamCalc = new camTp();
            CP = (camTpPoint) new TpPnt9D();
            List<Point3D> PL3 = new List<Point3D>();
            ((ToolCheckOption) this).NotchHorizontalTypeMillingCamMoveCalc(toolBase5_3, ref P, ref CP, ref PL3, XStart + ((ToolGeometry5) ((ProfileRuntimeSettings) P).Tool).Geometry.Diameter / 2.0, XEnd - ((ToolGeometry5) ((ProfileRuntimeSettings) P).Tool).Geometry.Diameter / 2.0, calcSteps[0] - ((ToolGeometry5) ((ProfileRuntimeSettings) P).Tool).Geometry.Diameter / 2.0, calcSteps[calcSteps.Count - 1] + ((ToolGeometry5) ((ProfileRuntimeSettings) P).Tool).Geometry.Diameter / 2.0, ((ProfileSettings) Profile).Height + ((PanelCutSettings) ((ProfileRuntimeSettings) P).CamOPData).distanceSafe, num16);
            LinearPath linearPath = new LinearPath((ICollection<Point3D>) PL3);
            CustomData customData = (CustomData) new ClipperOffset();
            ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.CamG1);
            linearPath.EntityData = (object) customData;
            CamCalc.EntitiesG1.Add((Entity) linearPath);
            if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
              ;
            if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
              ;
            CamCalc.CamPoints.Add(CP);
            ((ProfileRuntimeSettings) P).CamCalculation.Add(CamCalc);
          }
          return 1;
        }
      }
      for (int index = 0; index <= doubleList.Count - 1; ++index)
      {
        bool isLast = false;
        if (index == doubleList.Count - 1)
          isLast = true;
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) P).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Vertical)
          this.NotchVerticalCalc(ref CP, ref P, ref CamCalc, index, toolBase5_4, Profile, XVal, XSafe, XOffset, YSing, doubleList[index], Settings, isLast);
      }
      TpPnt9D Pnt = new TpPnt9D(CamCalc.CamPoints[0].Points[0]);
      Pnt.PlungeAxis = "Z";
      ((TpArcData) Pnt).P9.Z = ((ProfileSettings) Profile).Height + ((PanelCutSettings) ((ProfileRuntimeSettings) P).CamOPData).distanceSafe;
      if (((TpArcData) Pnt).P9.Z < ((buMarbleCalc) ((ProfileSettings) Profile).ClamperSettings).ClamperMaxHeight + 50.0)
      {
        ((TpArcData) Pnt).P9.Z = ((buMarbleCalc) ((ProfileSettings) Profile).ClamperSettings).ClamperMaxHeight + 50.0;
        if ((CamCalc.CamPoints[0].Points.Count <= 0 ? 0 : (((TpArcData) Pnt).P9.Z < ((TpArcData) CamCalc.CamPoints[0].Points[0]).P9.Z ? 1 : 0)) != 0)
          ((TpArcData) Pnt).P9.Z = ((TpArcData) CamCalc.CamPoints[0].Points[0]).P9.Z;
      }
      TpPnt9D tpPnt9D27 = new TpPnt9D(Pnt);
      tpPnt9D27.EnableAxes.Z = false;
      tpPnt9D27.PlungeAxis = "";
      tpPnt9D27.PlungeAxisMovement = false;
      TpPnt9D tpPnt9D28 = new TpPnt9D(Pnt);
      CamCalc.CamPoints[0].Points.Insert(0, tpPnt9D28);
      CamCalc.CamPoints[0].Points.Insert(0, tpPnt9D27);
      Line line1 = new Line(new Point3D(((TpArcData) CamCalc.CamPoints[0].Points[0]).P9.X, ((TpArcData) CamCalc.CamPoints[0].Points[0]).P9.Y, ((TpArcData) CamCalc.CamPoints[0].Points[0]).P9.Z), new Point3D(((TpArcData) CamCalc.CamPoints[0].Points[1]).P9.X, ((TpArcData) CamCalc.CamPoints[0].Points[1]).P9.Y, ((TpArcData) CamCalc.CamPoints[0].Points[1]).P9.Z));
      CustomData customData1 = (CustomData) new ClipperOffset();
      ((CutterRuntimeSettings) customData1).set_typeDefination(entityTypeDefination.CamG0);
      line1.EntityData = (object) customData1;
      CamCalc.EntitiesG0.Insert(0, (Entity) line1);
      TpPnt9D tpPnt9D29 = new TpPnt9D(CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1]);
      tpPnt9D29.PlungeAxis = "Z";
      ((TpArcData) tpPnt9D29).P9.Z = ((ProfileSettings) Profile).Height + ((PanelCutSettings) ((ProfileRuntimeSettings) P).CamOPData).distanceSafe;
      if (((TpArcData) tpPnt9D29).P9.Z < ((buMarbleCalc) ((ProfileSettings) Profile).ClamperSettings).ClamperMaxHeight + 50.0)
      {
        ((TpArcData) tpPnt9D29).P9.Z = ((buMarbleCalc) ((ProfileSettings) Profile).ClamperSettings).ClamperMaxHeight + 50.0;
        if ((CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count <= 0 ? 0 : (((TpArcData) tpPnt9D29).P9.Z < ((TpArcData) CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1]).P9.Z ? 1 : 0)) != 0)
          ((TpArcData) tpPnt9D29).P9.Z = ((TpArcData) CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1]).P9.Z;
      }
      tpPnt9D29.Type = 0;
      tpPnt9D29.MoveType = CamMoveType.G0;
      CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Add(tpPnt9D29);
      Line line2 = new Line(new Point3D(((TpArcData) CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 2]).P9.X, ((TpArcData) CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 2]).P9.Y, ((TpArcData) CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 2]).P9.Z), new Point3D(((TpArcData) CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1]).P9.X, ((TpArcData) CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1]).P9.Y, ((TpArcData) CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1]).P9.Z));
      CustomData customData2 = (CustomData) new ClipperOffset();
      ((CutterRuntimeSettings) customData2).set_typeDefination(entityTypeDefination.CamG0);
      line1.EntityData = (object) customData2;
      CamCalc.EntitiesG0.Add((Entity) line2);
      ((ProfileRuntimeSettings) P).CamCalculation.Add(new camTp(CamCalc));
      return 1;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return -1;
    }
  }

  public void NotchVerticalCalc(
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
    double calcY,
    ProfileSettings Settings,
    bool isLast)
  {
    CamCalc.Tool = (ToolBase5) new ToolGeometry5(toolSaw);
    List<Point3D> points = new List<Point3D>();
    CP = (camTpPoint) new TpPnt9D();
    double a = 90.0;
    if (((ProfileMirror) ((ProfileRuntimeSettings) P).OperationData).selectedPlaneName == planeNames.Back)
      a = -90.0;
    if (i == 0 && ((MarbleTempVars) Settings).NotchVerticalSafeAtXAxis)
      CP.Points.Add(new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, ((ProfileSettings) Profile).Height + ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Distances.Safe, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
      {
        MoveType = CamMoveType.G0
      });
    if (((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
    {
      CP.Points.Add(new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, ((ProfileSettings) Profile).Height, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
      {
        PlungeAxis = "X",
        PlungeAxisMovement = true,
        MoveType = CamMoveType.G0
      });
      TpPnt9D tpPnt9D1 = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, ((ProfileSettings) Profile).Height, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
      tpPnt9D1.Type = 0;
      tpPnt9D1.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
      tpPnt9D1.MoveType = CamMoveType.G0;
      CP.Points.Add(tpPnt9D1);
      points.Add(new Point3D(((TpArcData) tpPnt9D1).P9.X, ((TpArcData) tpPnt9D1).P9.Y, ((TpArcData) tpPnt9D1).P9.Z));
      TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, ((ProfileSettings) Profile).Height, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
      tpPnt9D2.Type = 1;
      tpPnt9D2.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
      tpPnt9D2.MoveType = CamMoveType.Plunge;
      CP.Points.Add(tpPnt9D2);
      points.Add(new Point3D(((TpArcData) tpPnt9D2).P9.X, ((TpArcData) tpPnt9D2).P9.Y, ((TpArcData) tpPnt9D2).P9.Z));
      TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
      tpPnt9D3.Type = 1;
      tpPnt9D3.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
      tpPnt9D3.MoveType = CamMoveType.G1;
      CP.Points.Add(tpPnt9D3);
      points.Add(new Point3D(((TpArcData) tpPnt9D3).P9.X, ((TpArcData) tpPnt9D3).P9.Y, ((TpArcData) tpPnt9D3).P9.Z));
      TpPnt9D tpPnt9D4 = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
      tpPnt9D4.Type = 1;
      tpPnt9D4.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
      tpPnt9D4.MoveType = CamMoveType.Leave;
      CP.Points.Add(tpPnt9D4);
      points.Add(new Point3D(((TpArcData) tpPnt9D4).P9.X, ((TpArcData) tpPnt9D4).P9.Y, ((TpArcData) tpPnt9D4).P9.Z));
    }
    if (((MarbleTempVars) Settings).NotchVerticalSafeAtXAxis)
    {
      if (((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
      {
        if (i % 2 == 1)
        {
          TpPnt9D tpPnt9D5 = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D5.PlungeAxis = "X";
          tpPnt9D5.PlungeAxisMovement = true;
          tpPnt9D5.MoveType = CamMoveType.G0;
          CP.Points.Add(tpPnt9D5);
          points.Add(new Point3D(((TpArcData) tpPnt9D5).P9.X, ((TpArcData) tpPnt9D5).P9.Y, ((TpArcData) tpPnt9D5).P9.Z));
          TpPnt9D tpPnt9D6 = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D6.Type = 0;
          tpPnt9D6.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
          tpPnt9D6.MoveType = CamMoveType.G0;
          CP.Points.Add(tpPnt9D6);
          points.Add(new Point3D(((TpArcData) tpPnt9D6).P9.X, ((TpArcData) tpPnt9D6).P9.Y, ((TpArcData) tpPnt9D6).P9.Z));
          TpPnt9D tpPnt9D7 = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D7.Type = 1;
          tpPnt9D7.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
          tpPnt9D7.PlungeAxis = "X";
          tpPnt9D7.MoveType = CamMoveType.Plunge;
          CP.Points.Add(tpPnt9D7);
          points.Add(new Point3D(((TpArcData) tpPnt9D7).P9.X, ((TpArcData) tpPnt9D7).P9.Y, ((TpArcData) tpPnt9D7).P9.Z));
          TpPnt9D tpPnt9D8 = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, ((ProfileSettings) Profile).Height, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D8.Type = 1;
          tpPnt9D8.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
          tpPnt9D8.MoveType = CamMoveType.G1;
          CP.Points.Add(tpPnt9D8);
          points.Add(new Point3D(((TpArcData) tpPnt9D8).P9.X, ((TpArcData) tpPnt9D8).P9.Y, ((TpArcData) tpPnt9D8).P9.Z));
          TpPnt9D tpPnt9D9 = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, ((ProfileSettings) Profile).Height, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D9.Type = 1;
          tpPnt9D9.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D9.MoveType = CamMoveType.Leave;
          CP.Points.Add(tpPnt9D9);
          points.Add(new Point3D(((TpArcData) tpPnt9D9).P9.X, ((TpArcData) tpPnt9D9).P9.Y, ((TpArcData) tpPnt9D9).P9.Z));
        }
        else
        {
          CP.Points.Add(new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, ((ProfileSettings) Profile).Height, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0)
          {
            PlungeAxis = "X",
            PlungeAxisMovement = true,
            MoveType = CamMoveType.G0
          });
          TpPnt9D tpPnt9D10 = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, ((ProfileSettings) Profile).Height, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
          tpPnt9D10.Type = 0;
          tpPnt9D10.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
          tpPnt9D10.MoveType = CamMoveType.G0;
          CP.Points.Add(tpPnt9D10);
          points.Add(new Point3D(((TpArcData) tpPnt9D10).P9.X, ((TpArcData) tpPnt9D10).P9.Y, ((TpArcData) tpPnt9D10).P9.Z));
          TpPnt9D tpPnt9D11 = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, ((ProfileSettings) Profile).Height, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D11.Type = 1;
          tpPnt9D11.MoveType = CamMoveType.Plunge;
          tpPnt9D11.PlungeAxis = "X";
          tpPnt9D11.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
          CP.Points.Add(tpPnt9D11);
          points.Add(new Point3D(((TpArcData) tpPnt9D11).P9.X, ((TpArcData) tpPnt9D11).P9.Y, ((TpArcData) tpPnt9D11).P9.Z));
          TpPnt9D tpPnt9D12 = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D12.Type = 1;
          tpPnt9D12.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
          tpPnt9D12.MoveType = CamMoveType.G1;
          CP.Points.Add(tpPnt9D12);
          points.Add(new Point3D(((TpArcData) tpPnt9D12).P9.X, ((TpArcData) tpPnt9D12).P9.Y, ((TpArcData) tpPnt9D12).P9.Z));
          TpPnt9D tpPnt9D13 = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, 0.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
          tpPnt9D13.Type = 1;
          tpPnt9D13.Feed = ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave;
          tpPnt9D13.MoveType = CamMoveType.Leave;
          CP.Points.Add(tpPnt9D13);
          points.Add(new Point3D(((TpArcData) tpPnt9D13).P9.X, ((TpArcData) tpPnt9D13).P9.Y, ((TpArcData) tpPnt9D13).P9.Z));
        }
      }
    }
    else if (((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch).Notch).NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
    {
      if (i % 2 == 1)
      {
        TpPnt9D tpPnt9D14 = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, 0.0 - ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
        tpPnt9D14.PlungeAxis = "Z";
        tpPnt9D14.PlungeAxisMovement = true;
        tpPnt9D14.MoveType = CamMoveType.G0;
        CP.Points.Add(tpPnt9D14);
        points.Add(new Point3D(((TpArcData) tpPnt9D14).P9.X, ((TpArcData) tpPnt9D14).P9.Y, ((TpArcData) tpPnt9D14).P9.Z));
        TpPnt9D tpPnt9D15 = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, ((ProfileSettings) Profile).Height + ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
        tpPnt9D15.Type = 1;
        tpPnt9D15.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
        tpPnt9D15.MoveType = CamMoveType.G1;
        CP.Points.Add(tpPnt9D15);
        points.Add(new Point3D(((TpArcData) tpPnt9D15).P9.X, ((TpArcData) tpPnt9D15).P9.Y, ((TpArcData) tpPnt9D15).P9.Z));
      }
      else
      {
        TpPnt9D tpPnt9D16 = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, ((ProfileSettings) Profile).Height + ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
        tpPnt9D16.PlungeAxis = "Z";
        tpPnt9D16.PlungeAxisMovement = true;
        tpPnt9D16.MoveType = CamMoveType.G0;
        CP.Points.Add(tpPnt9D16);
        points.Add(new Point3D(((TpArcData) tpPnt9D16).P9.X, ((TpArcData) tpPnt9D16).P9.Y, ((TpArcData) tpPnt9D16).P9.Z));
        TpPnt9D tpPnt9D17 = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, 0.0 - ((ToolGeometry5) toolSaw).Geometry.Diameter / 2.0, a, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
        tpPnt9D17.Type = 1;
        tpPnt9D17.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
        tpPnt9D17.MoveType = CamMoveType.G1;
        CP.Points.Add(tpPnt9D17);
        points.Add(new Point3D(((TpArcData) tpPnt9D17).P9.X, ((TpArcData) tpPnt9D17).P9.Y, ((TpArcData) tpPnt9D17).P9.Z));
      }
      if (isLast)
      {
        TpPnt9D tpPnt9D = new TpPnt9D(CP.Points[CP.Points.Count - 1]);
        ((TpArcData) tpPnt9D).P9.X = XSafe + XOffset;
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
}
