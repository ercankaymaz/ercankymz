// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleMillingAnalyzePars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleMillingAnalyzePars : buSerilization5
{
  public double CountertopRotation;
  public double CountertopRadius;
  public double CountertopChamfer;

  public void AddItemCommands(ref MarbleItem Item, MarbleItemCommands Cmd)
  {
    // ISSUE: unable to decompile the method.
  }

  public void AnalyzeCamItemsCuts(MarbleItem Items, ref List<MarbleItemCam> Cams)
  {
    // ISSUE: unable to decompile the method.
  }

  public bool ModifyAnalyzeCamItem(
    ref buEntity ModifiedBaseCamItem,
    buEntity CheckedCamItem,
    double CheckDistance)
  {
    bool flag1 = false;
    Point3D pntStart1 = (Point3D) null;
    Point3D pntEnd1 = (Point3D) null;
    Point3D pntStart2 = (Point3D) null;
    Point3D pntEnd2 = (Point3D) null;
    buCall.\u0001.GetEntityStartEndPointByCamDirection(ModifiedBaseCamItem, ref pntStart1, ref pntEnd1);
    buCall.\u0001.GetEntityStartEndPointByCamDirection(CheckedCamItem, ref pntStart2, ref pntEnd2);
    double num1 = buCall.\u0001.Length3D(pntStart1, pntStart2);
    double num2 = buCall.\u0001.Length3D(pntStart1, pntEnd2);
    bool flag2;
    if (this.isEntitySame(ModifiedBaseCamItem, CheckedCamItem))
    {
      flag2 = true;
    }
    else
    {
      if (num1 < CheckDistance)
      {
        if (((CustomData) ModifiedBaseCamItem).sortDirection == entitySortDirection.Normal)
          ((CustomData) ModifiedBaseCamItem).StartPoint = F_NotchEdit.ToPoint3D(pntEnd2);
        else
          ((CustomData) ModifiedBaseCamItem).EndPoint = F_NotchEdit.ToPoint3D(pntEnd2);
        flag1 = true;
      }
      else if (num2 < CheckDistance)
      {
        if (((CustomData) ModifiedBaseCamItem).sortDirection == entitySortDirection.Normal)
          ((CustomData) ModifiedBaseCamItem).StartPoint = F_NotchEdit.ToPoint3D(pntStart2);
        else
          ((CustomData) ModifiedBaseCamItem).EndPoint = F_NotchEdit.ToPoint3D(pntStart2);
        flag1 = true;
      }
      double num3 = buCall.\u0001.Length3D(pntEnd1, pntStart2);
      double num4 = buCall.\u0001.Length3D(pntEnd1, pntEnd2);
      if (num3 < CheckDistance)
      {
        if (((CustomData) ModifiedBaseCamItem).sortDirection == entitySortDirection.Normal)
          ((CustomData) ModifiedBaseCamItem).EndPoint = F_NotchEdit.ToPoint3D(pntEnd2);
        else
          ((CustomData) ModifiedBaseCamItem).StartPoint = F_NotchEdit.ToPoint3D(pntEnd2);
        flag1 = true;
      }
      else if (num4 < CheckDistance)
      {
        if (((CustomData) ModifiedBaseCamItem).sortDirection == entitySortDirection.Normal)
          ((CustomData) ModifiedBaseCamItem).EndPoint = F_NotchEdit.ToPoint3D(pntStart2);
        else
          ((CustomData) ModifiedBaseCamItem).StartPoint = F_NotchEdit.ToPoint3D(pntStart2);
        flag1 = true;
      }
      if (flag1)
        ((buUpperLine) ModifiedBaseCamItem).Update((buEntityUpdateType) 2);
      flag2 = flag1;
    }
    return flag2;
  }

  public bool isEntitySame(buEntity entFirst, buEntity entSecond)
  {
    bool flag1 = false;
    bool flag2;
    if (entFirst.GetType() == entSecond.GetType())
    {
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      if (buConversion5.\u003C\u003Ec.EQ(((CustomData) entFirst).StartPoint, ((CustomData) entSecond).StartPoint, 0.1) & buConversion5.\u003C\u003Ec.EQ(((CustomData) entFirst).EndPoint, ((CustomData) entSecond).EndPoint, 0.1))
      {
        flag2 = true;
        goto label_6;
      }
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      if (buConversion5.\u003C\u003Ec.EQ(((CustomData) entFirst).StartPoint, ((CustomData) entSecond).EndPoint, 0.1) & buConversion5.\u003C\u003Ec.EQ(((CustomData) entFirst).EndPoint, ((CustomData) entSecond).StartPoint, 0.1))
      {
        flag2 = true;
        goto label_6;
      }
    }
    flag2 = flag1;
label_6:
    return flag2;
  }

  public void ShapeTypeAngleSet(ref MarbleItem Item)
  {
    if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Rectangle)
    {
      for (int index = 0; index <= ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities.Count - 1; ++index)
      {
        if (((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble == null)
          ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble = (MarbleInfo) new Line2D();
        if (index == 0)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleBottomAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleBottomAngle;
        }
        if (index == 1)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRightAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRightAngle;
        }
        if (index == 2)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleTopAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleTopAngle;
        }
        if (index == 3)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleLeftAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleLeftAngle;
        }
      }
    }
    if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.CrossRectangle)
    {
      for (int index = 0; index <= ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities.Count - 1; ++index)
      {
        if (((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble == null)
          ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble = (MarbleInfo) new Line2D();
        if (index == 0)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossRightAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossRightAngle;
        }
        if (index == 1)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossTopAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossTopAngle;
        }
        if (index == 2)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossLeftAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossLeftAngle;
        }
        if (index == 3)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossBottomAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossBottomAngle;
        }
      }
    }
    if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Trepezoid)
    {
      for (int index = 0; index <= ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities.Count - 1; ++index)
      {
        if (((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble == null)
          ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble = (MarbleInfo) new Line2D();
        if (index == 0)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezBottomAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezBottomAngle;
        }
        if (index == 1)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezRightAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezRightAngle;
        }
        if (index == 2)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezTopAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezTopAngle;
        }
        if (index == 3)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezLeftAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezLeftAngle;
        }
      }
    }
    if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.ShipNose)
    {
      for (int index = 0; index <= ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities.Count - 1; ++index)
      {
        if (((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble == null)
          ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble = (MarbleInfo) new Line2D();
        if (index == 0)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseBottomAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseBottomAngle;
        }
        if (index == 1)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRightAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRightAngle;
        }
        if (index == 2)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseTopAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseTopAngle;
        }
        if (index == 3)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseLeftAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseLeftAngle;
        }
      }
    }
    if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Triangle)
    {
      for (int index = 0; index <= ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities.Count - 1; ++index)
      {
        if (((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble == null)
          ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble = (MarbleInfo) new Line2D();
        if (index == 0)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleBottomAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleBottomAngle;
        }
        if (index == 1)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleCrossAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleCrossAngle;
        }
        if (index == 2)
        {
          ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleLeftAngle;
          ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleLeftAngle;
        }
      }
    }
    if (!(((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Circle | ((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Ellipse | ((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Polygon | ((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Slot | ((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.RoundRectangle | ((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.ChamferRectangle | ((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.ArcPie | ((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.EllipsePie))
      return;
    for (int index = 0; index <= ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities.Count - 1; ++index)
    {
      if (((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble == null)
        ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble = (MarbleInfo) new Line2D();
      if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Circle)
      {
        ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeCircleAngle;
        ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeCircleAngle;
      }
      if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Ellipse)
      {
        ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipseAngle;
        ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipseAngle;
      }
      if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Polygon)
      {
        ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapePolygonAngle;
        ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapePolygonAngle;
      }
      if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.Slot)
      {
        ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotAngle;
        ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotAngle;
      }
      if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.RoundRectangle)
      {
        ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundAngle;
        ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundAngle;
      }
      if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.ChamferRectangle)
      {
        ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferAngle;
        ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferAngle;
      }
      if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.ArcPie)
      {
        ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcPieAngle;
        ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcPieAngle;
      }
      if (((MarbleScreenCaptureSettings) Item).ShapeType == MarbleShapeTypes.EllipsePie)
      {
        ((CustomDataSurrogate) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Orientation.A = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieAngle;
        ((EntityInfo) ((CustomData) ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities[index]).Marble).Angle = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieAngle;
      }
    }
  }
}
