// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleSlatPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSlatPars : buSerilization5
{
  public MarbleConcaveCuttingType ConcaveCuttingType;
  public MarbleConcaveCuttingType ConvexCuttingType;
  public MarbleConcaveDrillType ConcaveDrillType;
  public CamCuttingDirectionType CuttingDirection;
  public ClockDirectionType ContourDirection;
  public ClockDirectionType ContourInsideDirection;
  public ClockDirectionType ConcaveDirection;
  public ClockDirectionType ConvexDirection;
  public MarbleContourCutSequence CutSequence;
  public MarbleMillingToolType DefaultMillingTool;
  public MarbleMillingToolType DefaultDrillTool;
  public MarbleCornerCleanToolType DefaultCornerCleanTool;
  public MarbleMaterialHardness MaterialHardness;
  public MarbleStepType StepType;
  public bool isBuWireframeCalculation;
  public double MaterialMonsHardness;
  public double MaterialDensity;
  public double MaterialUnitVolumeWeight;
  public double MaterialPorosity;
  public string MaterialName;
  public bool Contour3DCreate;
  public bool UseG53;
  public List<marbleStepAnsFeedForCircular> StepCircularLimits;

  public void OffsetItem(
    ref MarbleItem refItem,
    int EntityIndex,
    int EntitySubIndex,
    double OffsetDistance)
  {
    try
    {
      if (EntityIndex >= 0 & EntitySubIndex == -1)
      {
        List<buEntity> OffsetedEntity = new List<buEntity>();
        CamClosedContourType ClosedType = CamClosedContourType.Outter;
        if (OffsetDistance < 0.0)
          ClosedType = CamClosedContourType.Inner;
        buCall.\u0001.OffsetEntities(((\u0084.\u0001) ((MarbleScreenCaptureSettings) refItem).EntGroup.Outside).Entities, OffsetDistance, CamOpenContourType.Center, ClosedType, ref OffsetedEntity);
        if (((MarbleScreenCaptureSettings) refItem).EntGroup.Inside == null)
          ((MarbleScreenCaptureSettings) refItem).EntGroup.Inside = new List<buEntityList>();
        if (OffsetedEntity.Count <= 0)
          return;
        buEntityList buEntityList = (buEntityList) new buArcCam();
        buRadialDim.Copy(OffsetedEntity, ref ((\u0084.\u0001) buEntityList).Entities);
        if (((MarbleScreenCaptureSettings) refItem).EntGroup.Inside.Count > 0)
        {
          ((\u0008.\u0001) ((MarbleScreenCaptureSettings) refItem).EntGroup.Inside[0]).InOutType = entityInOutDirectionType.InsideOfInside;
          ((\u0008.\u0001) buEntityList).InOutType = entityInOutDirectionType.InsideOfInside;
        }
        ((MarbleScreenCaptureSettings) refItem).EntGroup.Inside.Add(buEntityList);
      }
      else
      {
        List<buEntity> OffsetedEntity = new List<buEntity>();
        CamClosedContourType ClosedType = CamClosedContourType.Outter;
        if (OffsetDistance < 0.0)
          ClosedType = CamClosedContourType.Inner;
        buCall.\u0001.OffsetEntities(((\u0084.\u0001) ((MarbleScreenCaptureSettings) refItem).EntGroup.Inside[EntityIndex]).Entities, OffsetDistance, CamOpenContourType.Center, ClosedType, ref OffsetedEntity);
        if (((MarbleScreenCaptureSettings) refItem).EntGroup.Inside == null)
          ((MarbleScreenCaptureSettings) refItem).EntGroup.Inside = new List<buEntityList>();
        if (OffsetedEntity.Count <= 0)
          return;
        buEntityList buEntityList = (buEntityList) new buArcCam();
        buRadialDim.Copy(OffsetedEntity, ref ((\u0084.\u0001) buEntityList).Entities);
        if (((MarbleScreenCaptureSettings) refItem).EntGroup.Inside.Count > 0)
        {
          ((\u0008.\u0001) ((MarbleScreenCaptureSettings) refItem).EntGroup.Inside[0]).InOutType = entityInOutDirectionType.InsideOfInside;
          ((\u0008.\u0001) buEntityList).InOutType = entityInOutDirectionType.InsideOfInside;
        }
        ((MarbleScreenCaptureSettings) refItem).EntGroup.Inside.Add(buEntityList);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void OffsetCalculation(
    marbleOffsetCalculationParameters Pars,
    MarbleItemSettings Settings,
    ref double Offset)
  {
    double XLength = 0.0;
    double num = ((marbleCountertopPocketPars) Pars).ToolThickness;
    if (((marbleCountertopPocketPars) Pars).ToolSocket > ((marbleCountertopPocketPars) Pars).ToolThickness)
      num = ((marbleCountertopPocketPars) Pars).ToolSocket;
    Offset = (Math.Abs(num / 2.0) + ((marbleCountertopCornerPars) Pars).Offset) / Math.Cos(buString5.DegreeToRadian(((marbleCountertopCornerPars) Pars).OrientationA));
    if (((marbleCountertopCornerPars) Pars).OrientationA < 0.0)
      Math.Round(-((marbleCountertopCornerPars) Pars).TargetZ * Math.Tan(buString5.DegreeToRadian(Math.Abs(((marbleCountertopCornerPars) Pars).OrientationA))), 5);
    if (((marbleChamferBothSidePars) Pars).isToolSaw)
    {
      buCall.\u0001.LengthFromZLengthAndAngle(((marbleCountertopCornerPars) Pars).MaterialThickness - ((marbleCountertopCornerPars) Pars).TargetZ, ((marbleCountertopCornerPars) Pars).OrientationA, ref XLength);
      if (((marbleChamferBothSidePars) Pars).isReverseAngleA)
        XLength = -XLength;
    }
    if (Math.Abs(((marbleCountertopCornerPars) Pars).OrientationA) <= 0.0)
      return;
    Offset -= XLength;
  }

  public void OffsetCalculation(
    marbleOffsetCalculationParameters Pars,
    ref double Offset,
    ref CamOpenContourType OpenOffsetType)
  {
    double XLength = 0.0;
    if (((marbleChamferBothSidePars) Pars).isClosed)
    {
      if (((marbleCountertopCornerPars) Pars).ClosedOffsetType == CamClosedContourType.Inner)
        Offset = -Math.Abs(((marbleCountertopPocketPars) Pars).ToolDiameter / 2.0) + ((marbleCountertopCornerPars) Pars).Offset;
      if (((marbleCountertopCornerPars) Pars).ClosedOffsetType == CamClosedContourType.Outter)
        Offset = (Math.Abs(((marbleCountertopPocketPars) Pars).ToolDiameter / 2.0) + ((marbleCountertopCornerPars) Pars).Offset) / Math.Cos(buString5.DegreeToRadian(((marbleCountertopCornerPars) Pars).OrientationA));
      if (((marbleCountertopCornerPars) Pars).ClosedOffsetType == CamClosedContourType.Center)
        Offset = 0.0;
    }
    else
    {
      if (((marbleCountertopCornerPars) Pars).OpenOffsetType == CamOpenContourType.Left | ((marbleCountertopCornerPars) Pars).OpenOffsetType == CamOpenContourType.Right)
        Offset = (Math.Abs(((marbleCountertopPocketPars) Pars).ToolDiameter / 2.0) + ((marbleCountertopCornerPars) Pars).Offset) / Math.Cos(buString5.DegreeToRadian(((marbleCountertopCornerPars) Pars).OrientationA));
      if (((marbleCountertopCornerPars) Pars).OpenOffsetType == CamOpenContourType.Center)
        Offset = 0.0;
    }
    if (((marbleChamferBothSidePars) Pars).isToolSaw)
    {
      buCall.\u0001.LengthFromZLengthAndAngle(((marbleCountertopCornerPars) Pars).MaterialThickness - ((marbleCountertopCornerPars) Pars).TargetZ, ((marbleCountertopCornerPars) Pars).OrientationA, ref XLength);
      if (((marbleChamferBothSidePars) Pars).isReverseAngleA)
        XLength = -XLength;
    }
    if (((marbleChamferBothSidePars) Pars).isClosed)
      Offset -= XLength;
    else if (((marbleCountertopCornerPars) Pars).OpenOffsetType == CamOpenContourType.Right)
    {
      Offset -= XLength;
      if (Offset >= 0.0)
        return;
      OpenOffsetType = CamOpenContourType.Right;
    }
    else
    {
      if (((marbleCountertopCornerPars) Pars).OpenOffsetType != CamOpenContourType.Left)
        return;
      Offset += XLength;
      if (Offset >= 0.0)
        return;
      OpenOffsetType = CamOpenContourType.Left;
    }
  }

  public void EntityLengthModify(
    buEntity RefEntity,
    StartPointType ModifyDirType,
    double ModifyLength,
    ref buEntity ModifiedEntity)
  {
    ModifiedEntity = (buEntity) new buMultilineText();
    double CutLength = ModifyLength / Math.Cos(buString5.DegreeToRadian(((CustomDataSurrogate) RefEntity).Orientation.A));
    if (ModifyDirType == StartPointType.Start)
    {
      if (((CustomData) RefEntity).sortDirection == entitySortDirection.Normal)
        buCall.\u0001.EntityUpdateByLengthUsingCamDirection(buAngularDim.Copy(RefEntity), CutLength, StartPointType.Start, Plane.XY, ref ModifiedEntity);
      else
        buCall.\u0001.EntityUpdateByLengthUsingCamDirection(buAngularDim.Copy(RefEntity), CutLength, StartPointType.End, Plane.XY, ref ModifiedEntity);
    }
    if (ModifyDirType == StartPointType.End)
    {
      if (((CustomData) RefEntity).sortDirection == entitySortDirection.Normal)
        buCall.\u0001.EntityUpdateByLengthUsingCamDirection(buAngularDim.Copy(RefEntity), CutLength, StartPointType.End, Plane.XY, ref ModifiedEntity);
      else
        buCall.\u0001.EntityUpdateByLengthUsingCamDirection(buAngularDim.Copy(RefEntity), CutLength, StartPointType.Start, Plane.XY, ref ModifiedEntity);
    }
    if (ModifyDirType == StartPointType.StartAndEnd)
      buCall.\u0001.EntityUpdateByLengthUsingCamDirection(buAngularDim.Copy(RefEntity), CutLength, StartPointType.StartAndEnd, Plane.XY, ref ModifiedEntity);
    ((AnalyseEntitiesResult) ((CustomData) ModifiedEntity).Info).CamSelected = false;
  }
}
