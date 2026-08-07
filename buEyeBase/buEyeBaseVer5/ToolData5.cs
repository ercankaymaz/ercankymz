// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ToolData5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ToolData5 : buSerilization5
{
  public double PositionAngle;
  public bool AddHalfOfToolThicknessToDistance;
  public Vec3D PlaneDirection;
  public Vec3D ToolDirection;
  public Vec3D DistanceForOrientation;
  public ToolType GeometryType;
  public ToolFlatGeometryType FlatGeometry;
  public ToolCornerRadiusType CornerRadiusType;
  public bool LengthReverseDirection;
  public bool DrawHolder;
  public bool DrawArbor;
  public bool DrawLength;
  public bool AgregateLeftEnable;
  public bool AgregateRightEnable;
  public double AgregateVerticalLength;
  public double AgregateToolCenterLength;
  public bool AgregateCircleBody;
  public bool FromFileEnable;
  public string FromFileFileName;

  public void MmToInch()
  {
    ((ToolGeometry5) this).Geometry.Diameter = Math.Round(((ToolGeometry5) this).Geometry.Diameter * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.DiameterLeft = Math.Round(((ToolGeometry5) this).Geometry.DiameterLeft * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.DiameterRight = Math.Round(((ToolGeometry5) this).Geometry.DiameterRight * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.DiameterBody = Math.Round(((ToolGeometry5) this).Geometry.DiameterBody * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.ShoulderDiameter = Math.Round(((ToolGeometry5) this).Geometry.ShoulderDiameter * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.ShoulderLength = Math.Round(((ToolGeometry5) this).Geometry.ShoulderLength * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.BottomDiameter = Math.Round(((ToolGeometry5) this).Geometry.BottomDiameter * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.TopDiameter = Math.Round(((ToolGeometry5) this).Geometry.TopDiameter * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.RoundRadius = Math.Round(((ToolGeometry5) this).Geometry.RoundRadius * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.Length = Math.Round(((ToolGeometry5) this).Geometry.Length * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.LengthLeft = Math.Round(((ToolGeometry5) this).Geometry.LengthLeft * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.LengthRigth = Math.Round(((ToolGeometry5) this).Geometry.LengthRigth * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.LengthDiameter = Math.Round(((ToolGeometry5) this).Geometry.LengthDiameter * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.CutLength = Math.Round(((ToolGeometry5) this).Geometry.CutLength * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.CutLengthLeft = Math.Round(((ToolGeometry5) this).Geometry.CutLengthLeft * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.CutLengthRight = Math.Round(((ToolGeometry5) this).Geometry.CutLengthRight * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.ArborLength = Math.Round(((ToolGeometry5) this).Geometry.ArborLength * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.ArborTopDiameter = Math.Round(((ToolGeometry5) this).Geometry.ArborTopDiameter * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.ArborBottomDiameter = Math.Round(((ToolGeometry5) this).Geometry.ArborBottomDiameter * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.HolderLength = Math.Round(((ToolGeometry5) this).Geometry.HolderLength * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.HolderDiameter = Math.Round(((ToolGeometry5) this).Geometry.HolderDiameter * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.HolderInDiameter = Math.Round(((ToolGeometry5) this).Geometry.HolderInDiameter * buSystem.MmToInchRatio, 5);
    ((ToolGeometry5) this).Geometry.LowerRadius = Math.Round(((ToolGeometry5) this).Geometry.LowerRadius * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).UpperRadius = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).UpperRadius * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).UpperDiameter = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).UpperDiameter * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).ProfileRadius = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).ProfileRadius * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).OutsideDiameter = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).OutsideDiameter * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).ProfileDiameter = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).ProfileDiameter * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).MaxDiameter = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).MaxDiameter * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).FlatnessDiameter = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).FlatnessDiameter * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).ConvexTipRadius = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).ConvexTipRadius * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).Thickness = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).Thickness * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).MinLength = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).MinLength * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeWidth = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeWidth * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeDepth = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeDepth * buSystem.MmToInchRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeHeight = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeHeight * buSystem.MmToInchRatio, 5);
    ((ToolData5) ((ToolGeometry5) this).Geometry).AgregateVerticalLength = Math.Round(((ToolData5) ((ToolGeometry5) this).Geometry).AgregateVerticalLength * buSystem.MmToInchRatio, 5);
    ((ToolData5) ((ToolGeometry5) this).Geometry).AgregateToolCenterLength = Math.Round(((ToolData5) ((ToolGeometry5) this).Geometry).AgregateToolCenterLength * buSystem.MmToInchRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).DepthConstant = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).DepthConstant * buSystem.MmToInchRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).Stepover = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).Stepover * buSystem.MmToInchRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).Cutover = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).Cutover * buSystem.MmToInchRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).OperationHeight = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).OperationHeight * buSystem.MmToInchRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).AreaClearanceSpeed = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).AreaClearanceSpeed * buSystem.MmToInchRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).FinishSpeed = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).FinishSpeed * buSystem.MmToInchRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).RetractSpeed = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).RetractSpeed * buSystem.MmToInchRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).FeedSpeed = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).FeedSpeed * buSystem.MmToInchRatio, 5);
    ((ToolPositions5) ((ToolGeometry5) this).CamData).PlungeSpeed = Math.Round(((ToolPositions5) ((ToolGeometry5) this).CamData).PlungeSpeed * buSystem.MmToInchRatio, 5);
    ((ToolPositions5) ((ToolGeometry5) this).CamData).LeaveSpeed = Math.Round(((ToolPositions5) ((ToolGeometry5) this).CamData).LeaveSpeed * buSystem.MmToInchRatio, 5);
    ((ToolPositions5) ((ToolGeometry5) this).CamData).SpindleSpeed = Math.Round(((ToolPositions5) ((ToolGeometry5) this).CamData).SpindleSpeed * buSystem.MmToInchRatio, 5);
    ((ToolPositions5) ((ToolGeometry5) this).CamData).OperationHeigthForSecond = Math.Round(((ToolPositions5) ((ToolGeometry5) this).CamData).OperationHeigthForSecond * buSystem.MmToInchRatio, 5);
    ((ToolPositions5) ((ToolGeometry5) this).CamData).ExtraOffset = Math.Round(((ToolPositions5) ((ToolGeometry5) this).CamData).ExtraOffset * buSystem.MmToInchRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).CamData).SafeDistance = Math.Round(((LayerBase5) ((ToolGeometry5) this).CamData).SafeDistance * buSystem.MmToInchRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).CamData).RapidDistance = Math.Round(((LayerBase5) ((ToolGeometry5) this).CamData).RapidDistance * buSystem.MmToInchRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.X = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.X * buSystem.MmToInchRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.Y = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.Y * buSystem.MmToInchRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.Z = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.Z * buSystem.MmToInchRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.X = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.X * buSystem.MmToInchRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.Y = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.Y * buSystem.MmToInchRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.Z = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.Z * buSystem.MmToInchRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.X = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.X * buSystem.MmToInchRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.Y = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.Y * buSystem.MmToInchRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.Z = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.Z * buSystem.MmToInchRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.X = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.X * buSystem.MmToInchRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.Y = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.Y * buSystem.MmToInchRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.Z = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.Z * buSystem.MmToInchRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.X = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.X * buSystem.MmToInchRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.Y = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.Y * buSystem.MmToInchRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.Z = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.Z * buSystem.MmToInchRatio, 5);
  }

  public void InchToMm()
  {
    ((ToolGeometry5) this).Geometry.Diameter = Math.Round(((ToolGeometry5) this).Geometry.Diameter * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.DiameterLeft = Math.Round(((ToolGeometry5) this).Geometry.DiameterLeft * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.DiameterRight = Math.Round(((ToolGeometry5) this).Geometry.DiameterRight * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.DiameterBody = Math.Round(((ToolGeometry5) this).Geometry.DiameterBody * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.ShoulderDiameter = Math.Round(((ToolGeometry5) this).Geometry.ShoulderDiameter * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.ShoulderLength = Math.Round(((ToolGeometry5) this).Geometry.ShoulderLength * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.BottomDiameter = Math.Round(((ToolGeometry5) this).Geometry.BottomDiameter * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.TopDiameter = Math.Round(((ToolGeometry5) this).Geometry.TopDiameter * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.RoundRadius = Math.Round(((ToolGeometry5) this).Geometry.RoundRadius * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.Length = Math.Round(((ToolGeometry5) this).Geometry.Length * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.LengthLeft = Math.Round(((ToolGeometry5) this).Geometry.LengthLeft * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.LengthRigth = Math.Round(((ToolGeometry5) this).Geometry.LengthRigth * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.LengthDiameter = Math.Round(((ToolGeometry5) this).Geometry.LengthDiameter * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.CutLength = Math.Round(((ToolGeometry5) this).Geometry.CutLength * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.CutLengthLeft = Math.Round(((ToolGeometry5) this).Geometry.CutLengthLeft * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.CutLengthRight = Math.Round(((ToolGeometry5) this).Geometry.CutLengthRight * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.ArborLength = Math.Round(((ToolGeometry5) this).Geometry.ArborLength * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.ArborTopDiameter = Math.Round(((ToolGeometry5) this).Geometry.ArborTopDiameter * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.ArborBottomDiameter = Math.Round(((ToolGeometry5) this).Geometry.ArborBottomDiameter * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.HolderLength = Math.Round(((ToolGeometry5) this).Geometry.HolderLength * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.HolderDiameter = Math.Round(((ToolGeometry5) this).Geometry.HolderDiameter * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.HolderInDiameter = Math.Round(((ToolGeometry5) this).Geometry.HolderInDiameter * buSystem.InchToMmRatio, 5);
    ((ToolGeometry5) this).Geometry.LowerRadius = Math.Round(((ToolGeometry5) this).Geometry.LowerRadius * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).UpperRadius = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).UpperRadius * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).UpperDiameter = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).UpperDiameter * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).ProfileRadius = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).ProfileRadius * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).OutsideDiameter = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).OutsideDiameter * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).ProfileDiameter = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).ProfileDiameter * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).MaxDiameter = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).MaxDiameter * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).FlatnessDiameter = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).FlatnessDiameter * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).ConvexTipRadius = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).ConvexTipRadius * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).Thickness = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).Thickness * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).MinLength = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).MinLength * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeWidth = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeWidth * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeDepth = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeDepth * buSystem.InchToMmRatio, 5);
    ((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeHeight = Math.Round(((ToolDisplay5) ((ToolGeometry5) this).Geometry).SizeHeight * buSystem.InchToMmRatio, 5);
    ((ToolData5) ((ToolGeometry5) this).Geometry).AgregateVerticalLength = Math.Round(((ToolData5) ((ToolGeometry5) this).Geometry).AgregateVerticalLength * buSystem.InchToMmRatio, 5);
    ((ToolData5) ((ToolGeometry5) this).Geometry).AgregateToolCenterLength = Math.Round(((ToolData5) ((ToolGeometry5) this).Geometry).AgregateToolCenterLength * buSystem.InchToMmRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).DepthConstant = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).DepthConstant * buSystem.InchToMmRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).Stepover = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).Stepover * buSystem.InchToMmRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).Cutover = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).Cutover * buSystem.InchToMmRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).OperationHeight = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).OperationHeight * buSystem.InchToMmRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).AreaClearanceSpeed = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).AreaClearanceSpeed * buSystem.InchToMmRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).FinishSpeed = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).FinishSpeed * buSystem.InchToMmRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).RetractSpeed = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).RetractSpeed * buSystem.InchToMmRatio, 5);
    ((ToolLimits5) ((ToolGeometry5) this).CamData).FeedSpeed = Math.Round(((ToolLimits5) ((ToolGeometry5) this).CamData).FeedSpeed * buSystem.InchToMmRatio, 5);
    ((ToolPositions5) ((ToolGeometry5) this).CamData).PlungeSpeed = Math.Round(((ToolPositions5) ((ToolGeometry5) this).CamData).PlungeSpeed * buSystem.InchToMmRatio, 5);
    ((ToolPositions5) ((ToolGeometry5) this).CamData).LeaveSpeed = Math.Round(((ToolPositions5) ((ToolGeometry5) this).CamData).LeaveSpeed * buSystem.InchToMmRatio, 5);
    ((ToolPositions5) ((ToolGeometry5) this).CamData).SpindleSpeed = Math.Round(((ToolPositions5) ((ToolGeometry5) this).CamData).SpindleSpeed * buSystem.InchToMmRatio, 5);
    ((ToolPositions5) ((ToolGeometry5) this).CamData).OperationHeigthForSecond = Math.Round(((ToolPositions5) ((ToolGeometry5) this).CamData).OperationHeigthForSecond * buSystem.InchToMmRatio, 5);
    ((ToolPositions5) ((ToolGeometry5) this).CamData).ExtraOffset = Math.Round(((ToolPositions5) ((ToolGeometry5) this).CamData).ExtraOffset * buSystem.InchToMmRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).CamData).SafeDistance = Math.Round(((LayerBase5) ((ToolGeometry5) this).CamData).SafeDistance * buSystem.InchToMmRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).CamData).RapidDistance = Math.Round(((LayerBase5) ((ToolGeometry5) this).CamData).RapidDistance * buSystem.InchToMmRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.X = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.X * buSystem.InchToMmRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.Y = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.Y * buSystem.InchToMmRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.Z = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).CommonOffset.Z * buSystem.InchToMmRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.X = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.X * buSystem.InchToMmRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.Y = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.Y * buSystem.InchToMmRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.Z = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Offset.Z * buSystem.InchToMmRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.X = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.X * buSystem.InchToMmRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.Y = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.Y * buSystem.InchToMmRatio, 5);
    ((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.Z = Math.Round(((MoveEventFormVars) ((ToolGeometry5) this).Positions).Position.Z * buSystem.InchToMmRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.X = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.X * buSystem.InchToMmRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.Y = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.Y * buSystem.InchToMmRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.Z = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMaxLimits.Z * buSystem.InchToMmRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.X = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.X * buSystem.InchToMmRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.Y = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.Y * buSystem.InchToMmRatio, 5);
    ((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.Z = Math.Round(((LayerBase5) ((ToolGeometry5) this).Limits).AxesMinLimits.Z * buSystem.InchToMmRatio, 5);
  }

  public static ArrayList ToDef(ToolBase5 Tool)
  {
    return new ArrayList()
    {
      (object) ((ToolGeometry5) Tool).Purpose.ToString(),
      (object) buSerilization5.ClassToString((object) ((ToolGeometry5) Tool).Data),
      (object) buSerilization5.ClassToString((object) ((ToolGeometry5) Tool).Geometry),
      (object) buSerilization5.ClassToString((object) ((ToolGeometry5) Tool).CamData)
    };
  }

  public static ArrayList ToDefShort(int Space, ToolBase5 Tool)
  {
    ArrayList defShort = new ArrayList();
    string str = new string(' ', Space);
    defShort.Add((object) (str + ((ToolGeometry5) Tool).Purpose.ToString()));
    defShort.Add((object) (str + buSerilization5.ClassToString((object) ((ToolGeometry5) Tool).Data)));
    defShort.Add((object) (str + buSerilization5.ClassToString((object) ((ToolGeometry5) Tool).Geometry)));
    defShort.Add((object) (str + buSerilization5.ClassToString((object) ((ToolGeometry5) Tool).CamData)));
    defShort.Add((object) (str + buSerilization5.ClassToString((object) ((ToolGeometry5) Tool).Limits)));
    defShort.Add((object) (str + buSerilization5.ClassToString((object) ((ToolGeometry5) Tool).Positions)));
    return defShort;
  }
}
