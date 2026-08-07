// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileLengthClamperCount
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileLengthClamperCount : buSerilization5
{
  public double Layer0Speed;
  public double Layer1Speed;

  public void CreateDimensionEntity(
    ProfileOperation OP,
    ProfileItem curItem,
    ShapeDataValueType ValueType,
    MaterialBase5 Material,
    Point3D CornerPoint,
    ref Entity dimEntity,
    ref viewType ViewType,
    ref Plane viewPlane,
    double TextHeight = 20.0)
  {
    try
    {
      Point3D point3D1 = (Point3D) null;
      Point3D point3D2 = (Point3D) null;
      Point3D point3D3 = (Point3D) null;
      Point3D point3D4 = (Point3D) null;
      string str = "";
      Plane drawingPlane = (Plane) null;
      if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Bottom)
        point3D1 = new Point3D(((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z);
      else if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back)
        point3D1 = new Point3D(((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z);
      else if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Free)
      {
        point3D1 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X, ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).SelectedPlaneLength / 2.0 + ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y));
        point3D1.X = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileRectangle)
        ;
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileCircle)
        ;
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileHole)
        ;
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileTapping)
        ;
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileEllipse)
        ;
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileSlot)
        ;
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileBarrel)
        ;
      double x1 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
      if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Right)
        x1 = ((ProfileSettings) curItem).Length - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
      if (ValueType == ShapeDataValueType.XPosition)
      {
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileNotch)
        {
          x1 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
          CornerPoint.X = 0.0;
          if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Right)
          {
            x1 = ((ProfileSettings) curItem).Length - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
            CornerPoint.X = ((ProfileSettings) curItem).Length;
          }
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          point3D2 = new Point3D(x1, -((SortResult) Material).Size.Height, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z);
          point3D3 = new Point3D(CornerPoint.X, -((SortResult) Material).Size.Height, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z);
          point3D4 = new Point3D((point3D2.X + point3D3.X) / 2.0, 10.0, point3D2.Z);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
          viewPlane = Plane.XY;
          ViewType = viewType.Top;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back)
        {
          point3D2 = new Point3D(x1, -((SortResult) Material).Size.Height, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z);
          point3D3 = new Point3D(CornerPoint.X, -((SortResult) Material).Size.Height, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z);
          point3D4 = new Point3D((point3D2.X + point3D3.X) / 2.0, point3D2.Y, ((SortResult) Material).Size.Depth + 10.0);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XZ, ref drawingPlane);
          viewPlane = Plane.XY;
          ViewType = viewType.Front;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Free)
        {
          point3D2 = new Point3D(x1, -((SortResult) Material).Size.Height, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z);
          point3D3 = new Point3D(CornerPoint.X, -((SortResult) Material).Size.Height, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z);
          point3D4 = new Point3D((point3D2.X + point3D3.X) / 2.0, 10.0, point3D2.Z);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane, ref drawingPlane);
          viewPlane = (Plane) ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.Clone();
          ViewType = viewType.Top;
        }
        if (drawingPlane != (Plane) null)
        {
          dimEntity = (Entity) new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
          dimEntity.Selected = true;
        }
      }
      if (ValueType == ShapeDataValueType.YPosition)
      {
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          point3D2 = new Point3D(x1, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y, ((SortResult) Material).Size.Depth);
          point3D3 = new Point3D(x1, CornerPoint.Y, ((SortResult) Material).Size.Depth);
          point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, point3D2.Z);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
          viewPlane = Plane.XY;
          ViewType = viewType.Top;
          if (drawingPlane != (Plane) null)
            dimEntity = (Entity) new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Free)
        {
          double num = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y;
          if (num == 0.0)
            num = 1.0;
          point3D2 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X, ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).SelectedPlaneLength / 2.0));
          point3D2.X = x1;
          point3D3 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X, ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).SelectedPlaneLength / 2.0 - num));
          point3D3.X = x1;
          point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, (point3D2.Z + point3D3.Z) / 2.0);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane, ref drawingPlane);
          viewPlane = (Plane) ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.Clone();
          ViewType = viewType.Top;
          if (drawingPlane != (Plane) null)
          {
            dimEntity = (Entity) new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
            if (((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y == 0.0)
              ((Dimension) dimEntity).TextOverride = "0";
          }
        }
        if (dimEntity != null)
          dimEntity.Selected = true;
      }
      if (ValueType == ShapeDataValueType.ZPosition)
      {
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back)
        {
          point3D2 = new Point3D(x1, -((SortResult) Material).Size.Height, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z);
          point3D3 = new Point3D(x1, -((SortResult) Material).Size.Height, CornerPoint.Z);
          point3D4 = new Point3D(point3D2.X - 20.0, point3D2.Y, (point3D2.Z + point3D3.Z) / 2.0);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XZ, ref drawingPlane);
          viewPlane = Plane.XY;
          ViewType = viewType.Front;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top && ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileNotch)
        {
          double x2 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
          double z = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Length && ((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Right)
            x2 = ((ProfileSettings) curItem).Length - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
          if (z == 0.0)
          {
            z = 0.1;
            str = "0";
          }
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
            x2 = ((SortResult) Material).Size.Width;
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
          {
            point3D2 = new Point3D(x2, -((SortResult) Material).Size.Height, ((SortResult) Material).Size.Depth);
            point3D3 = new Point3D(x2, -((SortResult) Material).Size.Height, ((SortResult) Material).Size.Depth - z);
          }
          if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
          {
            point3D2 = new Point3D(x2, -((SortResult) Material).Size.Height, 0.0);
            point3D3 = new Point3D(x2, -((SortResult) Material).Size.Height, z);
          }
          point3D4 = new Point3D(point3D2.X - 20.0, point3D2.Y, (point3D2.Z + point3D3.Z) / 2.0);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XZ, ref drawingPlane);
          viewPlane = Plane.XZ;
          ViewType = viewType.Front;
        }
        if (drawingPlane != (Plane) null)
        {
          dimEntity = (Entity) new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
          dimEntity.Selected = true;
        }
      }
      if (ValueType == ShapeDataValueType.Width | ValueType == ShapeDataValueType.Height | ValueType == ShapeDataValueType.HeadDiameter | ValueType == ShapeDataValueType.Diameter | ValueType == ShapeDataValueType.Distance)
      {
        DimensionGroup dimensionGroup = (DimensionGroup) null;
        for (int index = 0; index <= ((ProfileRuntimeSettings) OP).EntityDimension.Count - 1; ++index)
        {
          if (((camTp) ((ProfileRuntimeSettings) OP).EntityDimension[index]).ShapeValueType == ValueType)
          {
            dimensionGroup = ((ProfileRuntimeSettings) OP).EntityDimension[index];
            buAngularDim.Copy(((camTp) ((ProfileRuntimeSettings) OP).EntityDimension[index]).dimEntity, ref dimEntity);
            dimEntity.Selected = true;
          }
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          viewPlane = Plane.XY;
          ViewType = viewType.Top;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back)
        {
          viewPlane = Plane.XY;
          ViewType = viewType.Front;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Free)
        {
          viewPlane = (Plane) ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.Clone();
          ViewType = viewType.Top;
        }
        if ((dimensionGroup == null ? 0 : (((camTp) dimensionGroup).UsePlaneType ? 1 : 0)) != 0)
        {
          if (((camTp) dimensionGroup).PlaneType == planeNames.Top | ((camTp) dimensionGroup).PlaneType == planeNames.Bottom)
          {
            viewPlane = Plane.XY;
            ViewType = viewType.Top;
          }
          if (((camTp) dimensionGroup).PlaneType == planeNames.Front | ((camTp) dimensionGroup).PlaneType == planeNames.Back)
          {
            viewPlane = Plane.XY;
            ViewType = viewType.Front;
          }
          if (((camTp) dimensionGroup).PlaneType == planeNames.Left)
          {
            viewPlane = Plane.YZ;
            ViewType = viewType.Left;
          }
          if (((camTp) dimensionGroup).PlaneType == planeNames.Right)
          {
            viewPlane = Plane.YZ;
            ViewType = viewType.Right;
          }
          if (((camTp) dimensionGroup).PlaneType == planeNames.Free)
          {
            viewPlane = (Plane) ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.Clone();
            ViewType = viewType.Top;
          }
        }
      }
      if (ValueType == ShapeDataValueType.Depth)
      {
        double x3 = ((ProfileRuntimeSettings) OP).MinPoint.X;
        if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Right)
          x3 = ((ProfileSettings) curItem).Length - ((ProfileRuntimeSettings) OP).MinPoint.X;
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          point3D2 = new Point3D(x3, -((SortResult) Material).Size.Height, ((ProfileRuntimeSettings) OP).MinPoint.Z + ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExtraDepth);
          point3D3 = new Point3D(x3, -((SortResult) Material).Size.Height, ((ProfileRuntimeSettings) OP).MaxPoint.Z);
          point3D4 = new Point3D(point3D2.X - 20.0, point3D3.Y, (point3D2.Z + point3D3.Z) / 2.0);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XZ, ref drawingPlane);
          viewPlane = Plane.XY;
          ViewType = viewType.Front;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front)
        {
          point3D2 = new Point3D(x3, ((ProfileRuntimeSettings) OP).MinPoint.Y, ((SortResult) Material).Size.Depth + 1.0);
          point3D3 = new Point3D(x3, ((ProfileRuntimeSettings) OP).MaxPoint.Y - ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExtraDepth, ((SortResult) Material).Size.Depth + 1.0);
          point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, point3D3.Z);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
          viewPlane = Plane.XY;
          ViewType = viewType.Top;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back)
        {
          point3D2 = new Point3D(x3, ((ProfileRuntimeSettings) OP).MinPoint.Y + ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExtraDepth, ((SortResult) Material).Size.Depth + 1.0);
          point3D3 = new Point3D(x3, ((ProfileRuntimeSettings) OP).MaxPoint.Y, ((SortResult) Material).Size.Depth + 1.0);
          point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, point3D3.Z);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
          viewPlane = Plane.XY;
          ViewType = viewType.Top;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Free)
        {
          point3D2 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X, ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).SelectedPlaneLength / 2.0 + ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y));
          point3D2.X = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
          point3D3 = new Point3D();
          point3D3.Y = point3D2.Y + -((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisZ.Y * ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExternalDepth;
          point3D3.Z = point3D2.Z + -((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisZ.Z * ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExternalDepth;
          point3D3.X = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
          point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, (point3D2.Z + point3D3.Z) / 2.0);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
          if (drawingPlane != (Plane) null)
            viewPlane = (Plane) drawingPlane.Clone();
          ViewType = viewType.Top;
        }
        if (drawingPlane != (Plane) null)
        {
          dimEntity = (Entity) new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
          dimEntity.Selected = true;
        }
      }
      if (ValueType == ShapeDataValueType.ExtraDepth)
      {
        double num = ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExtraDepth;
        if (num == 0.0)
          num = 0.1;
        double x4 = ((ProfileRuntimeSettings) OP).MinPoint.X;
        if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Right)
          x4 = ((ProfileSettings) curItem).Length - ((ProfileRuntimeSettings) OP).MinPoint.X;
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          point3D2 = new Point3D(x4, -((SortResult) Material).Size.Height, ((ProfileRuntimeSettings) OP).MinPoint.Z + num);
          point3D3 = new Point3D(x4, -((SortResult) Material).Size.Height, ((ProfileRuntimeSettings) OP).MinPoint.Z);
          point3D4 = new Point3D(point3D2.X - 20.0, point3D3.Y, (point3D2.Z + point3D3.Z) / 2.0);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XZ, ref drawingPlane);
          viewPlane = Plane.XY;
          ViewType = viewType.Front;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front)
        {
          point3D2 = new Point3D(x4, ((ProfileRuntimeSettings) OP).MaxPoint.Y - num, ((SortResult) Material).Size.Depth + 1.0);
          point3D3 = new Point3D(x4, ((ProfileRuntimeSettings) OP).MaxPoint.Y, ((SortResult) Material).Size.Depth + 1.0);
          point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, point3D3.Z);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
          viewPlane = Plane.XY;
          ViewType = viewType.Top;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back)
        {
          point3D2 = new Point3D(x4, ((ProfileRuntimeSettings) OP).MinPoint.Y + num, ((SortResult) Material).Size.Depth + 1.0);
          point3D3 = new Point3D(x4, ((ProfileRuntimeSettings) OP).MinPoint.Y, ((SortResult) Material).Size.Depth + 1.0);
          point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, point3D3.Z);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
          viewPlane = Plane.XY;
          ViewType = viewType.Top;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Free)
        {
          point3D2 = new Point3D();
          point3D2.Y = point3D1.Y + -((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisZ.Y * ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExternalDepth;
          point3D2.Z = point3D1.Z + -((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisZ.Z * ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExternalDepth;
          point3D2.X = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
          point3D3 = new Point3D();
          point3D3.Y = point3D1.Y + -((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisZ.Y * (((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExternalDepth + ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExtraDepth);
          point3D3.Z = point3D1.Z + -((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisZ.Z * (((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExternalDepth + ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExtraDepth);
          point3D3.X = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
          point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, (point3D2.Z + point3D3.Z) / 2.0);
          buCall.\u0001.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
          if (drawingPlane != (Plane) null)
            viewPlane = (Plane) drawingPlane.Clone();
          ViewType = viewType.Top;
        }
        if (drawingPlane != (Plane) null)
        {
          dimEntity = (Entity) new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
          ((Dimension) dimEntity).TextOverride = ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExtraDepth.ToString("f1");
          dimEntity.Selected = true;
        }
      }
      if (dimEntity != null)
      {
        dimEntity.Color = Color.Red;
        dimEntity.ColorMethod = colorMethodType.byEntity;
      }
      if (str.Length <= 0 || dimEntity == null)
        return;
      ((Dimension) dimEntity).TextOverride = str;
    }
    catch (Exception ex)
    {
    }
  }

  public bool isSameOperationAvailableInList(ProfileItem Item, ProfileOperation Operation)
  {
    bool flag;
    for (int index = 0; index <= ((ProfileSettings) Item).Operations.Count - 1; ++index)
    {
      ProfileOperationData operationData1 = ((ProfileRuntimeSettings) ((ProfileSettings) Item).Operations[index]).OperationData;
      ProfileOperationData operationData2 = ((ProfileRuntimeSettings) Operation).OperationData;
      if (((CreateProfileFromDataOptions) operationData1).OperationType == ((CreateProfileFromDataOptions) operationData2).OperationType & ((ProfileMirror) operationData1).selectedPlaneName == ((ProfileMirror) operationData2).selectedPlaneName)
      {
        if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.Rectangle || !(buConversion5.EQ(((CreateProfileFromDataOptions) ((DepthPositions) operationData2).RectangleData).RectangleWidth, ((CreateProfileFromDataOptions) ((DepthPositions) operationData1).RectangleData).RectangleWidth) & buConversion5.EQ(((OperationUpdateArg) ((DepthPositions) operationData2).RectangleData).RectangleHeight, ((OperationUpdateArg) ((DepthPositions) operationData1).RectangleData).RectangleHeight)) || !(buConversion5.EQ(((OperationUpdateArg) ((DepthPositions) operationData2).RectangleData).RectangleAngle, ((OperationUpdateArg) ((DepthPositions) operationData1).RectangleData).RectangleAngle) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName) || !buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position))
        {
          if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.RoundRectangle || !(buConversion5.EQ(((PanelCutMove) ((DepthPositions) operationData2).RectangleRoundData).RoundRectangleWidth, ((PanelCutMove) ((DepthPositions) operationData1).RectangleRoundData).RoundRectangleWidth) & buConversion5.EQ(((PanelCutMove) ((DepthPositions) operationData2).RectangleRoundData).RoundRectangleHeight, ((PanelCutMove) ((DepthPositions) operationData1).RectangleRoundData).RoundRectangleHeight)) || !(buConversion5.EQ(((PanelCutMove) ((DepthPositions) operationData2).RectangleRoundData).RoundRectangleAngle, ((PanelCutMove) ((DepthPositions) operationData1).RectangleRoundData).RoundRectangleAngle) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName) || !(buConversion5.EQ(((PanelCutMove) ((DepthPositions) operationData2).RectangleRoundData).RoundRectangleRadius, ((PanelCutMove) ((DepthPositions) operationData1).RectangleRoundData).RoundRectangleRadius) & buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position)))
          {
            if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.Circle || !(buConversion5.EQ(((CreateProfileFromDataOptions) ((OperationInsideClampers) operationData2).CircleData).CircleDiameter, ((CreateProfileFromDataOptions) ((OperationInsideClampers) operationData1).CircleData).CircleDiameter) & buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position)))
            {
              if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.Barrel || !(buConversion5.EQ(((PanelCutMove) ((DepthPositions) operationData2).BarelData).BarrelAngle, ((PanelCutMove) ((DepthPositions) operationData1).BarelData).BarrelAngle) & buConversion5.EQ(((PanelCutMove) ((DepthPositions) operationData2).BarelData).BarrelLength, ((PanelCutMove) ((DepthPositions) operationData1).BarelData).BarrelLength)) || !(buConversion5.EQ(((PanelCutMove) ((DepthPositions) operationData2).BarelData).BarrelDiameter, ((PanelCutMove) ((DepthPositions) operationData1).BarelData).BarrelDiameter) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName) || !(buConversion5.EQ(((PanelCutMove) ((DepthPositions) operationData2).BarelData).BarrelWidth, ((PanelCutMove) ((DepthPositions) operationData1).BarelData).BarrelWidth) & buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position)))
              {
                if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.Cut || !(buConversion5.EQ(((PanelWaitAssembly) ((DepthPositions) operationData2).CutData).CutAngle, ((PanelWaitAssembly) ((DepthPositions) operationData1).CutData).CutAngle) & buConversion5.EQ(((PanelDonePart) ((DepthPositions) operationData2).CutData).CutDepth, ((PanelDonePart) ((DepthPositions) operationData1).CutData).CutDepth)) || !(buConversion5.EQ(((PanelDonePart) ((DepthPositions) operationData2).CutData).CutHeigth, ((PanelDonePart) ((DepthPositions) operationData1).CutData).CutHeigth) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName) || !(buConversion5.EQ(((PanelDonePart) ((DepthPositions) operationData2).CutData).CutWidth, ((PanelDonePart) ((DepthPositions) operationData1).CutData).CutWidth) & buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position)))
                {
                  if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.Ellipse || !(buConversion5.EQ(((NestingPanelJob) ((DepthPositions) operationData2).EllipseData).EllipseAngle, ((NestingPanelJob) ((DepthPositions) operationData1).EllipseData).EllipseAngle) & buConversion5.EQ(((NestingPanelJob) ((DepthPositions) operationData2).EllipseData).EllipseHeight, ((NestingPanelJob) ((DepthPositions) operationData1).EllipseData).EllipseHeight)) || !(buConversion5.EQ(((NestingPanelJob) ((DepthPositions) operationData2).EllipseData).EllipseWidth, ((NestingPanelJob) ((DepthPositions) operationData1).EllipseData).EllipseWidth) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName) || !buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position))
                  {
                    if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.Hole || !(buConversion5.EQ(((NestingPanel) ((DepthPositions) operationData2).HoleData).HoleDepth, ((NestingPanel) ((DepthPositions) operationData1).HoleData).HoleDepth) & buConversion5.EQ(((NestingPanel) ((DepthPositions) operationData2).HoleData).HoleDiameter, ((NestingPanel) ((DepthPositions) operationData1).HoleData).HoleDiameter)) || !(buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName))
                    {
                      if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.Notch || !(buConversion5.EQ(((NestingPanelJob) ((DepthPositions) operationData2).NotchData).NotchDepth, ((NestingPanelJob) ((DepthPositions) operationData1).NotchData).NotchDepth) & buConversion5.EQ(((NestingPanelJob) ((DepthPositions) operationData2).NotchData).NotchHeight, ((NestingPanelJob) ((DepthPositions) operationData1).NotchData).NotchHeight)) || !(buConversion5.EQ(((NestingPanel) ((DepthPositions) operationData2).NotchData).NotchStart, ((NestingPanel) ((DepthPositions) operationData1).NotchData).NotchStart) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName) || !buConversion5.EQ(((NestingPanelJob) ((DepthPositions) operationData2).NotchData).NotchWidth, ((NestingPanelJob) ((DepthPositions) operationData1).NotchData).NotchWidth) || !(buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position) & ((NestingPanel) ((DepthPositions) operationData2).NotchData).NotchLocation == ((NestingPanel) ((DepthPositions) operationData1).NotchData).NotchLocation) || ((NestingPanel) ((DepthPositions) operationData2).NotchData).NotchOPType != ((NestingPanel) ((DepthPositions) operationData1).NotchData).NotchOPType)
                      {
                        if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.Polygon || !(buConversion5.EQ(((CreateProfileFromDataOptions) ((DepthPositionOptions) operationData2).PolygonData).PolygonAngle, ((CreateProfileFromDataOptions) ((DepthPositionOptions) operationData1).PolygonData).PolygonAngle) & buConversion5.EQ(((CreateProfileFromDataOptions) ((DepthPositionOptions) operationData2).PolygonData).PolygonDiameter, ((CreateProfileFromDataOptions) ((DepthPositionOptions) operationData1).PolygonData).PolygonDiameter)) || !(buConversion5.EQ((double) ((CreateProfileFromDataOptions) ((DepthPositionOptions) operationData2).PolygonData).PolygonSide, (double) ((CreateProfileFromDataOptions) ((DepthPositionOptions) operationData1).PolygonData).PolygonSide) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName) || !buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position))
                        {
                          if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.Slot || !(buConversion5.EQ(((PanelEntityData) ((DepthPositions) operationData2).SlotData).SlotAngle, ((PanelEntityData) ((DepthPositions) operationData1).SlotData).SlotAngle) & buConversion5.EQ(((PanelEntityData) ((DepthPositions) operationData2).SlotData).SlotWidth, ((PanelEntityData) ((DepthPositions) operationData1).SlotData).SlotWidth)) || !(buConversion5.EQ(((PanelEntityData) ((DepthPositions) operationData2).SlotData).SlotDiameter, ((PanelEntityData) ((DepthPositions) operationData1).SlotData).SlotDiameter) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName) || !buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position))
                          {
                            if (((CreateProfileFromDataOptions) operationData2).OperationType != ProfileOperationTypes.Text || !(buConversion5.EQ(((NestingPanelNode) ((DepthPositionOptions) operationData2).TextData).TextAngle, ((NestingPanelNode) ((DepthPositionOptions) operationData1).TextData).TextAngle) & ((NestingPanelNode) ((DepthPositionOptions) operationData2).TextData).TextString == ((NestingPanelNode) ((DepthPositionOptions) operationData1).TextData).TextString) || !(buConversion5.EQ(((NestingPanelNode) ((DepthPositionOptions) operationData2).TextData).TextWidth, ((NestingPanelNode) ((DepthPositionOptions) operationData1).TextData).TextWidth) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName) || !(buConversion5.EQ(((NestingPanelNode) ((DepthPositionOptions) operationData2).TextData).TextHeight, ((NestingPanelNode) ((DepthPositionOptions) operationData1).TextData).TextHeight) & buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position)))
                            {
                              if (((CreateProfileFromDataOptions) operationData2).OperationType == ProfileOperationTypes.FreeDraw && buConversion5.EQ(((NestingPanelNode) ((DepthPositionOptions) operationData2).FreeDrawData).FreeDrawAngle, ((NestingPanelNode) ((DepthPositionOptions) operationData1).FreeDrawData).FreeDrawAngle) & ((NestingPanelNode) ((DepthPositionOptions) operationData2).FreeDrawData).FreeDrawHeight == ((NestingPanelNode) ((DepthPositionOptions) operationData1).FreeDrawData).FreeDrawHeight && buConversion5.EQ(((NestingPanelNode) ((DepthPositionOptions) operationData2).FreeDrawData).FreeDrawWidth, ((NestingPanelNode) ((DepthPositionOptions) operationData1).FreeDrawData).FreeDrawWidth) & ((ProfileMirror) operationData2).selectedPlaneName == ((ProfileMirror) operationData1).selectedPlaneName && ((NestingPanelNode) ((DepthPositionOptions) operationData2).FreeDrawData).FreeDrawScaleCenter == ((NestingPanelNode) ((DepthPositionOptions) operationData1).FreeDrawData).FreeDrawScaleCenter & buConversion5.EQ(((ProfilePatternCopy) operationData2).Position, ((ProfilePatternCopy) operationData1).Position))
                              {
                                flag = true;
                                goto label_29;
                              }
                            }
                            else
                            {
                              flag = true;
                              goto label_29;
                            }
                          }
                          else
                          {
                            flag = true;
                            goto label_29;
                          }
                        }
                        else
                        {
                          flag = true;
                          goto label_29;
                        }
                      }
                      else
                      {
                        flag = true;
                        goto label_29;
                      }
                    }
                    else
                    {
                      flag = true;
                      goto label_29;
                    }
                  }
                  else
                  {
                    flag = true;
                    goto label_29;
                  }
                }
                else
                {
                  flag = true;
                  goto label_29;
                }
              }
              else
              {
                flag = true;
                goto label_29;
              }
            }
            else
            {
              flag = true;
              goto label_29;
            }
          }
          else
          {
            flag = true;
            goto label_29;
          }
        }
        else
        {
          flag = true;
          goto label_29;
        }
      }
    }
    flag = false;
label_29:
    return flag;
  }

  public bool isAllOperationInsideXLimit(ProfileItem Item, double XLimit)
  {
    bool flag1 = false;
    bool flag2;
    for (int index = 0; index <= ((ProfileSettings) Item).Operations.Count - 1; ++index)
    {
      if (((ProfileRuntimeSettings) ((ProfileSettings) Item).Operations[index]).MaxPoint.X > XLimit)
      {
        flag2 = true;
        goto label_6;
      }
    }
    flag2 = flag1;
label_6:
    return flag2;
  }

  public bool isBottomOperationAvailable(ProfileItem Item)
  {
    bool flag1 = false;
    bool flag2;
    for (int index = 0; index <= ((ProfileSettings) Item).Operations.Count - 1; ++index)
    {
      if (((ProfileMirror) ((ProfileRuntimeSettings) ((ProfileSettings) Item).Operations[index]).OperationData).selectedPlaneName == planeNames.Bottom)
      {
        flag2 = true;
        goto label_6;
      }
    }
    flag2 = flag1;
label_6:
    return flag2;
  }

  public bool isNextOperationsInsideRange(
    List<GProfileOperation> Operations,
    GProfileOperation refOP,
    bool UseMaxPoint,
    int startIndex,
    double MaxDistance,
    ref double calcDistance,
    ref List<GProfileOperation> foundOP)
  {
    bool flag1 = false;
    foundOP.Clear();
    bool flag2;
    for (int index = startIndex; index <= Operations.Count - 1; ++index)
    {
      if (UseMaxPoint)
      {
        double num = ((MachineSimulation) ((ProfileRuntimeSettings) Operations[index]).SizePoint).MaxPoint.X - ((MachineSimulation) ((ProfileRuntimeSettings) refOP).SizePoint).MaxPoint.X;
        if (num < MaxDistance & num >= 0.0)
        {
          if (num > calcDistance)
            calcDistance = num;
          foundOP.Add((GProfileOperation) new buMarbleCalc(Operations[index]));
          flag1 = true;
        }
        else
        {
          flag2 = flag1;
          goto label_15;
        }
      }
      else
      {
        double num = ((FlatViewSettings) ((ProfileRuntimeSettings) Operations[index]).SizePoint).MinPoint.X - ((FlatViewSettings) ((ProfileRuntimeSettings) refOP).SizePoint).MinPoint.X;
        if (num < MaxDistance & num > 0.0)
        {
          if (num > calcDistance)
            calcDistance = num;
          foundOP.Add((GProfileOperation) new buMarbleCalc(Operations[index]));
          flag1 = true;
        }
        else
        {
          flag2 = flag1;
          goto label_15;
        }
      }
    }
    flag2 = flag1;
label_15:
    return flag2;
  }

  public bool GetOperationDepthValueFromProfile(
    ProfileItem Profile,
    DepthPositionOptions Options,
    double ExternalDepth,
    double ExtraDepth,
    double DepthUp,
    bool EachLayer,
    ToolBase5 Tool,
    ref ProfileOperation Operation)
  {
    bool valueFromProfile;
    if (Profile == null)
    {
      valueFromProfile = false;
    }
    else
    {
      Point3D MinPoint1 = new Point3D();
      Point3D MaxPoint1 = new Point3D();
      ((ProfileRuntimeSettings) Operation).ProfileWidth = ((ProfileSettings) Profile).Width;
      ((ProfileRuntimeSettings) Operation).ProfileHeight = ((ProfileSettings) Profile).Height;
      ((ProfileRuntimeSettings) Operation).ProfileLength = ((ProfileSettings) Profile).Length;
      ((ProfileRuntimeSettings) Operation).ProfileName = ((ProfileSettings) Profile).ItemName;
      List<DepthPositions> depthPositionsList1 = new List<DepthPositions>();
      DepthPositions depthPositions = (DepthPositions) new MarbleColorSettings();
      List<double> Values1 = new List<double>();
      List<Point3D> Points = new List<Point3D>();
      List<Point3D> collection1 = new List<Point3D>();
      double StartValue = 0.0;
      double EndValue = 0.0;
      double y1 = 0.0;
      double y2 = 0.0;
      double z1 = 0.0;
      double z2 = 0.0;
      Point3D point3D1 = new Point3D(0.0, 0.0, 0.0);
      Point3D point3D2 = new Point3D(0.0, 0.0, 0.0);
      List<Line> lineList = new List<Line>();
      List<double> Values2 = new List<double>();
      if (((MarbleRuntimeSettings) Options).AreaCalculation)
      {
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileRectangle)
        {
          StartValue = -((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).RectangleData).RectangleHeight / 2.0;
          EndValue = ((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).RectangleData).RectangleHeight / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).RectangleData).RectangleHeight;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).RectangleData).RectangleHeight;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileCircle)
        {
          StartValue = -((CreateProfileFromDataOptions) ((OperationInsideClampers) ((ProfileRuntimeSettings) Operation).OperationData).CircleData).CircleDiameter / 2.0;
          EndValue = ((CreateProfileFromDataOptions) ((OperationInsideClampers) ((ProfileRuntimeSettings) Operation).OperationData).CircleData).CircleDiameter / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((CreateProfileFromDataOptions) ((OperationInsideClampers) ((ProfileRuntimeSettings) Operation).OperationData).CircleData).CircleDiameter;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((CreateProfileFromDataOptions) ((OperationInsideClampers) ((ProfileRuntimeSettings) Operation).OperationData).CircleData).CircleDiameter;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileSlot)
        {
          StartValue = -((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).SlotData).SlotDiameter / 2.0;
          EndValue = ((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).SlotData).SlotDiameter / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).SlotData).SlotDiameter;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).SlotData).SlotDiameter;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileHole)
        {
          StartValue = -((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).HoleData).HoleDiameter / 2.0;
          EndValue = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).HoleData).HoleDiameter / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).HoleData).HoleDiameter;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).HoleData).HoleDiameter;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profilePolygon)
        {
          StartValue = -((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).PolygonData).PolygonDiameter / 2.0;
          EndValue = ((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).PolygonData).PolygonDiameter / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).PolygonData).PolygonDiameter;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).PolygonData).PolygonDiameter;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileTapping)
        {
          StartValue = -((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).HoleData).HoleDiameter / 2.0;
          EndValue = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).HoleData).HoleDiameter / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).HoleData).HoleDiameter;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).HoleData).HoleDiameter;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileText)
        {
          StartValue = -((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).TextData).TextHeight / 2.0;
          EndValue = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).TextData).TextHeight / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).TextData).TextHeight;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).TextData).TextHeight;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileFreeDraw)
        {
          StartValue = -((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).FreeDrawData).FreeDrawHeight / 2.0;
          EndValue = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).FreeDrawData).FreeDrawHeight / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).FreeDrawData).FreeDrawHeight;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Operation).OperationData).FreeDrawData).FreeDrawHeight;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileCut)
        {
          StartValue = -((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).CutData).CutHeigth / 2.0;
          EndValue = ((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).CutData).CutHeigth / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).CutData).CutHeigth;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).CutData).CutHeigth;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileEllipse)
        {
          StartValue = -((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).EllipseData).EllipseHeight / 2.0;
          EndValue = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).EllipseData).EllipseHeight / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).EllipseData).EllipseHeight;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).EllipseData).EllipseHeight;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileBarrel)
        {
          StartValue = -((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).BarelData).BarrelDiameter / 2.0;
          EndValue = ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).BarelData).BarrelDiameter / 2.0;
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.TopRight)
          {
            StartValue = 0.0;
            EndValue = -((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).BarelData).BarrelDiameter;
          }
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomLeft | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomCenter | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Alignment == ObjectAlignment.BottomRight)
          {
            StartValue = 0.0;
            EndValue = ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).BarelData).BarrelDiameter;
          }
          buFile5.DevideMinMaxValueByNumber(StartValue, EndValue, ((MarbleRuntimeSettings) Options).AreaStep, ref Values2);
        }
        for (int index = 0; index <= Values2.Count - 1; ++index)
          Values2[index] += ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y;
        List<double> doubleList = new List<double>();
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top)
        {
          y1 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y + StartValue;
          y2 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y + EndValue;
          z1 = ((ProfileSettings) Profile).ProfileMaxPoint.Z - ExternalDepth;
          z2 = ((ProfileSettings) Profile).ProfileMaxPoint.Z;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          y1 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y + StartValue;
          y2 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y + EndValue;
          z1 = ((ProfileSettings) Profile).ProfileMinPoint.Z;
          z2 = ((ProfileSettings) Profile).ProfileMinPoint.Z + ExternalDepth;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front)
        {
          z1 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Z + StartValue;
          z2 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Z + EndValue;
          y1 = ((ProfileSettings) Profile).ProfileMinPoint.Y;
          y2 = ((ProfileSettings) Profile).ProfileMinPoint.Y + ExternalDepth;
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
        {
          z1 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Z + StartValue;
          z2 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Z + EndValue;
          y1 = ((ProfileSettings) Profile).ProfileMaxPoint.Y - ExternalDepth;
          y2 = ((ProfileSettings) Profile).ProfileMaxPoint.Y;
        }
        Point3D MinPoint2 = new Point3D(0.0, y1, z1);
        Point3D MaxPoint2 = new Point3D(0.0, y2, z2);
        for (int index1 = 0; index1 <= ((ProfileSettings) Profile).Drawings.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterEntitites.Count - 1; ++index2)
          {
            if (((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterEntitites[index2] is buCompositeCurve)
            {
              buCompositeCurve outterEntitite = ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterEntitites[index2] as buCompositeCurve;
              for (int index3 = 0; index3 <= ((CustomDataSurrogate) outterEntitite).CurveList.Count - 1; ++index3)
              {
                Point3D Point1 = new Point3D(0.0, ((CustomData) ((CustomDataSurrogate) outterEntitite).CurveList[index3]).StartPoint.X + ((ProfileSettings) Profile).ProfileOffset.Y, ((CustomData) ((CustomDataSurrogate) outterEntitite).CurveList[index3]).StartPoint.Y + ((ProfileSettings) Profile).ProfileOffset.Z);
                if (buCall.\u0001.IsPointInsideBoxsize(Point1, MinPoint2, MaxPoint2, Plane.YZ))
                {
                  if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
                    Values2.Add(Point1.Y);
                  if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
                    Values2.Add(Point1.Z);
                }
                Point3D Point2 = new Point3D(0.0, ((CustomData) ((CustomDataSurrogate) outterEntitite).CurveList[index3]).EndPoint.X + ((ProfileSettings) Profile).ProfileOffset.Y, ((CustomData) ((CustomDataSurrogate) outterEntitite).CurveList[index3]).EndPoint.Y + ((ProfileSettings) Profile).ProfileOffset.Z);
                if (buCall.\u0001.IsPointInsideBoxsize(Point2, MinPoint2, MaxPoint2, Plane.YZ))
                {
                  if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
                    Values2.Add(Point2.Y);
                  if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
                    Values2.Add(Point2.Z);
                }
              }
            }
            else
            {
              buEntity outterEntitite = ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterEntitites[index2];
              Point3D Point3 = new Point3D(0.0, ((CustomData) outterEntitite).StartPoint.X + ((ProfileSettings) Profile).ProfileOffset.Y, ((CustomData) outterEntitite).StartPoint.Y + ((ProfileSettings) Profile).ProfileOffset.Z);
              if (buCall.\u0001.IsPointInsideBoxsize(Point3, MinPoint2, MaxPoint2, Plane.YZ))
              {
                if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
                  Values2.Add(Point3.Y);
                if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
                  Values2.Add(Point3.Z);
              }
              Point3D Point4 = new Point3D(0.0, ((CustomData) outterEntitite).EndPoint.X + ((ProfileSettings) Profile).ProfileOffset.Y, ((CustomData) outterEntitite).EndPoint.Y + ((ProfileSettings) Profile).ProfileOffset.Z);
              if (buCall.\u0001.IsPointInsideBoxsize(Point4, MinPoint2, MaxPoint2, Plane.YZ))
              {
                if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
                  Values2.Add(Point4.Y);
                if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
                  Values2.Add(Point4.Z);
              }
            }
          }
        }
        Values2.Sort();
        buFile5.CheckDuplicatedWithPrevious(ref Values2, 0.2);
      }
      if (Values2.Count == 0)
        Values2.Add(((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y);
      if (EachLayer)
      {
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          for (int index = 0; index <= Values2.Count - 1; ++index)
            lineList.Add(new Line(new Point3D(0.0, Values2[index], -10000.0), new Point3D(0.0, Values2[index], 10000.0)));
        }
        else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front)
        {
          for (int index = 0; index <= Values2.Count - 1; ++index)
            lineList.Add(new Line(new Point3D(0.0, -10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).movePlanePoint.Z + Values2[index]), new Point3D(0.0, 10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).movePlanePoint.Z + Values2[index])));
        }
        else
        {
          Line line = new Line(new Point3D(0.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Y * 10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Z * 10000.0), new Point3D(0.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Y * -10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Z * -10000.0));
          lineList.Add(line);
        }
      }
      else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
        lineList.Add(new Line(new Point3D(0.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y, -10000.0), new Point3D(0.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y, 10000.0)));
      else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front)
      {
        lineList.Add(new Line(new Point3D(0.0, -10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y + ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).movePlanePoint.Z), new Point3D(0.0, 10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y + ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).movePlanePoint.Z)));
      }
      else
      {
        Line line = new Line(new Point3D(0.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Y * 10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Z * 10000.0), new Point3D(0.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Y * -10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Z * -10000.0));
        lineList.Add(line);
      }
      for (int index4 = 0; index4 <= lineList.Count - 1; ++index4)
      {
        for (int index5 = 0; index5 <= ((ProfileSettings) Profile).Drawings.Count - 1; ++index5)
        {
          Point3D[] collection2 = new LinearPath((ICollection<Point3D>) ((MarbleJob) ((ProfileSettings) Profile).Drawings[index5]).OutterPoints).IntersectWith((ICurve) lineList[index4], 0.0, true);
          Points.AddRange((IEnumerable<Point3D>) collection2);
          for (int index6 = 0; index6 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index5]).InnerPoints.Count - 1; ++index6)
          {
            Point3D[] collection3 = new LinearPath((ICollection<Point3D>) ((MarbleJob) ((ProfileSettings) Profile).Drawings[index5]).InnerPoints[index6]).IntersectWith((ICurve) lineList[index4], 0.0, true);
            Points.AddRange((IEnumerable<Point3D>) collection3);
          }
        }
      }
      if (EachLayer)
      {
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          Line C2 = (Line) null;
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top)
            C2 = new Line(new Point3D(0.0, y1, z1), new Point3D(0.0, y2, z1));
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
            C2 = new Line(new Point3D(0.0, y1, z2), new Point3D(0.0, y2, z2));
          for (int index7 = 0; index7 <= ((ProfileSettings) Profile).Drawings.Count - 1; ++index7)
          {
            Point3D[] collection4 = new LinearPath((ICollection<Point3D>) ((MarbleJob) ((ProfileSettings) Profile).Drawings[index7]).OutterPoints).IntersectWith((ICurve) C2, 0.0, true);
            collection1.AddRange((IEnumerable<Point3D>) collection4);
            for (int index8 = 0; index8 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index7]).InnerPoints.Count - 1; ++index8)
            {
              Point3D[] collection5 = new LinearPath((ICollection<Point3D>) ((MarbleJob) ((ProfileSettings) Profile).Drawings[index7]).InnerPoints[index8]).IntersectWith((ICurve) C2, 0.0, true);
              collection1.AddRange((IEnumerable<Point3D>) collection5);
            }
          }
          buCall.\u0001.SortDeltaZ(new Point3D(0.0, 0.0, 10000.0), SortDirectionType.Bigger, ref collection1);
          ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref collection1);
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
        {
          Line C2 = (Line) null;
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
            C2 = new Line(new Point3D(0.0, y1, z1), new Point3D(0.0, y1, z2));
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front)
            C2 = new Line(new Point3D(0.0, y2, z1), new Point3D(0.0, y2, z2));
          for (int index9 = 0; index9 <= ((ProfileSettings) Profile).Drawings.Count - 1; ++index9)
          {
            Point3D[] collection6 = new LinearPath((ICollection<Point3D>) ((MarbleJob) ((ProfileSettings) Profile).Drawings[index9]).OutterPoints).IntersectWith((ICurve) C2, 0.0, true);
            collection1.AddRange((IEnumerable<Point3D>) collection6);
            for (int index10 = 0; index10 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index9]).InnerPoints.Count - 1; ++index10)
            {
              Point3D[] collection7 = new LinearPath((ICollection<Point3D>) ((MarbleJob) ((ProfileSettings) Profile).Drawings[index9]).InnerPoints[index10]).IntersectWith((ICurve) C2, 0.0, true);
              collection1.AddRange((IEnumerable<Point3D>) collection7);
            }
          }
          buCall.\u0001.SortDeltaY(new Point3D(0.0, 10000.0, 0.0), SortDirectionType.Bigger, ref collection1);
          ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref collection1);
        }
      }
      buCall.\u0001.BoxSizeCalculate(Points, ref MinPoint1, ref MaxPoint1);
      Points.Clear();
      for (int index11 = 0; index11 <= lineList.Count - 1; ++index11)
      {
        Values1.Clear();
        Points.Clear();
        Points.AddRange((IEnumerable<Point3D>) collection1);
        for (int index12 = 0; index12 <= ((ProfileSettings) Profile).Drawings.Count - 1; ++index12)
        {
          int num = 0;
          for (int index13 = 1; index13 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).OutterPoints.Count - 1; ++index13)
          {
            bool flag = false;
            if (!(((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back) || buConversion5.EQ(((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).OutterPoints[index13 - 1].Z, ((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).OutterPoints[index13].Z, 0.01))
              ;
            if (!(((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom) || buConversion5.EQ(((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).OutterPoints[index13 - 1].Y, ((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).OutterPoints[index13].Y, 0.01))
              ;
            if (!flag)
            {
              Point3D[] collection8 = new Line(((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).OutterPoints[index13 - 1], ((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).OutterPoints[index13]).IntersectWith((ICurve) lineList[index11], 0.0, true);
              if (collection8.Length != 0)
              {
                if (Points.Count == 0)
                {
                  Points.AddRange((IEnumerable<Point3D>) collection8);
                  num = index13;
                }
                else
                {
                  if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back && Math.Abs(Points[Points.Count - 1].Y - collection8[0].Y) > 0.1)
                  {
                    if (index13 - num > 0)
                    {
                      Points.AddRange((IEnumerable<Point3D>) collection8);
                      num = index13;
                    }
                    else
                    {
                      if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front && collection8[0].Y < Points[Points.Count - 1].Y)
                      {
                        Points[Points.Count - 1] = new Point3D(collection8[0].X, collection8[0].Y, collection8[0].Z);
                        num = index13;
                      }
                      if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back && collection8[0].Y > Points[Points.Count - 1].Y)
                      {
                        Points[Points.Count - 1] = new Point3D(collection8[0].X, collection8[0].Y, collection8[0].Z);
                        num = index13;
                      }
                    }
                  }
                  if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom && Math.Abs(Points[Points.Count - 1].Z - collection8[0].Z) > 0.1)
                  {
                    if (index13 - num > 0)
                    {
                      Points.AddRange((IEnumerable<Point3D>) collection8);
                      num = index13;
                    }
                    else
                    {
                      if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top && collection8[0].Z > Points[Points.Count - 1].Z)
                      {
                        Points[Points.Count - 1] = new Point3D(collection8[0].X, collection8[0].Y, collection8[0].Z);
                        num = index13;
                      }
                      if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom && collection8[0].Z < Points[Points.Count - 1].Z)
                      {
                        Points[Points.Count - 1] = new Point3D(collection8[0].X, collection8[0].Y, collection8[0].Z);
                        num = index13;
                      }
                    }
                  }
                }
              }
            }
          }
          for (int index14 = 0; index14 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).InnerPoints.Count - 1; ++index14)
          {
            for (int index15 = 1; index15 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).InnerPoints[index14].Count - 1; ++index15)
            {
              bool flag = false;
              if (!(((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back) || buConversion5.EQ(((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).InnerPoints[index14][index15 - 1].Z, ((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).InnerPoints[index14][index15].Z, 0.1))
                ;
              if (!(((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom) || buConversion5.EQ(((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).InnerPoints[index14][index15 - 1].Y, ((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).InnerPoints[index14][index15].Y, 0.1))
                ;
              if (!flag)
              {
                Point3D[] collection9 = new Line(((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).InnerPoints[index14][index15 - 1], ((MarbleJob) ((ProfileSettings) Profile).Drawings[index12]).InnerPoints[index14][index15]).IntersectWith((ICurve) lineList[index11], 0.0, true);
                Points.AddRange((IEnumerable<Point3D>) collection9);
              }
            }
          }
        }
        for (int index16 = 0; index16 <= Points.Count - 1; ++index16)
        {
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top)
          {
            if (buConversion5.GE(Points[index16].Z, MaxPoint1.Z - ExternalDepth, 0.1))
              Values1.Add(Math.Round(Points[index16].Z, 3));
          }
          else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
          {
            if (buConversion5.LE(Points[index16].Z, MinPoint1.Z + ExternalDepth, 0.1))
              Values1.Add(Math.Round(Points[index16].Z, 3));
          }
          else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front)
          {
            if (buConversion5.LE(Points[index16].Y, MinPoint1.Y + ExternalDepth, 0.1))
              Values1.Add(Math.Round(Points[index16].Y, 3));
          }
          else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back && buConversion5.GE(Points[index16].Y, MaxPoint1.Y - ExternalDepth, 0.1))
            Values1.Add(Math.Round(Points[index16].Y, 3));
        }
        if (Values1.Count >= 2)
        {
          Values1.Sort();
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
            Values1.Reverse();
        }
        if (Values1.Count == 1)
        {
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
            Values1.Add(Values1[0] - ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ExternalDepth);
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
            Values1.Add(Values1[0] + ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ExternalDepth);
        }
        buFile5.CheckDuplicatedWithPrevious(ref Values1);
        if (Values1.Count % 2 == 1)
          ;
        bool flag1 = false;
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
        {
          for (int index17 = 0; index17 <= Values1.Count - 1; index17 += 2)
          {
            if (index17 < Values1.Count - 1)
            {
              double num = Values1[index17] - Values1[index17 + 1];
              if (num >= ((MarbleRuntimeSettings) Options).MinThickness & num <= ((MarbleRuntimeSettings) Options).MaxThickness)
              {
                DepthPositions data = (DepthPositions) new MarbleColorSettings();
                ((MarbleRuntimeSettings) data).TopPosition = Values1[index17];
                ((MarbleRuntimeSettings) data).BottomPosition = Values1[index17 + 1] - ExtraDepth;
                ((MarbleRuntimeSettings) data).Depth = ((MarbleRuntimeSettings) data).BottomPosition - ((MarbleRuntimeSettings) data).TopPosition;
                if (EachLayer)
                {
                  if (depthPositionsList1.Count == 0)
                  {
                    depthPositionsList1.Add(data);
                  }
                  else
                  {
                    bool flag2 = false;
                    for (int index18 = 0; index18 <= depthPositionsList1.Count - 1; ++index18)
                    {
                      bool flag3 = buFile5.IsValueInsideMinMaxValues(((MarbleRuntimeSettings) data).TopPosition, ((MarbleRuntimeSettings) depthPositionsList1[index18]).BottomPosition, ((MarbleRuntimeSettings) depthPositionsList1[index18]).TopPosition);
                      bool flag4 = buFile5.IsValueInsideMinMaxValues(((MarbleRuntimeSettings) data).BottomPosition, ((MarbleRuntimeSettings) depthPositionsList1[index18]).BottomPosition, ((MarbleRuntimeSettings) depthPositionsList1[index18]).TopPosition);
                      if (flag3 | flag4)
                      {
                        flag2 = true;
                        if (flag3 & !flag4)
                        {
                          ((MarbleRuntimeSettings) depthPositionsList1[index18]).BottomPosition = ((MarbleRuntimeSettings) data).BottomPosition;
                          ((MarbleRuntimeSettings) depthPositionsList1[index18]).Depth = ((MarbleRuntimeSettings) depthPositionsList1[index18]).BottomPosition - ((MarbleRuntimeSettings) depthPositionsList1[index18]).TopPosition;
                        }
                        else if (!flag3 & flag4)
                        {
                          ((MarbleRuntimeSettings) depthPositionsList1[index18]).TopPosition = ((MarbleRuntimeSettings) data).TopPosition;
                          ((MarbleRuntimeSettings) depthPositionsList1[index18]).Depth = ((MarbleRuntimeSettings) depthPositionsList1[index18]).BottomPosition - ((MarbleRuntimeSettings) depthPositionsList1[index18]).TopPosition;
                        }
                      }
                    }
                    if (!flag2)
                      depthPositionsList1.Add(data);
                  }
                }
                else if (!flag1)
                {
                  depthPositions = (DepthPositions) new MarbleColorSettings(data);
                  flag1 = true;
                }
              }
            }
          }
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZEnable)
          {
            depthPositionsList1.Clear();
            DepthPositions data = (DepthPositions) new MarbleColorSettings();
            ((MarbleRuntimeSettings) data).TopPosition = ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZVal;
            ((MarbleRuntimeSettings) data).BottomPosition = ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZVal - ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ExternalDepth - ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ExtraDepth;
            ((MarbleRuntimeSettings) data).Depth = ((MarbleRuntimeSettings) data).BottomPosition - ((MarbleRuntimeSettings) data).TopPosition;
            ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Depth = (DepthPositions) new MarbleColorSettings(data);
          }
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front)
        {
          for (int index19 = 0; index19 <= Values1.Count - 1; index19 += 2)
          {
            if (index19 < Values1.Count - 1)
            {
              double num = Values1[index19 + 1] - Values1[index19];
              if (num >= ((MarbleRuntimeSettings) Options).MinThickness & num <= ((MarbleRuntimeSettings) Options).MaxThickness)
              {
                DepthPositions data = (DepthPositions) new MarbleColorSettings();
                ((MarbleRuntimeSettings) data).TopPosition = Values1[index19];
                ((MarbleRuntimeSettings) data).BottomPosition = Values1[index19 + 1] + ExtraDepth;
                ((MarbleRuntimeSettings) data).Depth = ((MarbleRuntimeSettings) data).BottomPosition - ((MarbleRuntimeSettings) data).TopPosition;
                if (EachLayer)
                {
                  if (depthPositionsList1.Count == 0)
                  {
                    depthPositionsList1.Add(data);
                  }
                  else
                  {
                    bool flag5 = false;
                    for (int index20 = 0; index20 <= depthPositionsList1.Count - 1; ++index20)
                    {
                      bool flag6 = buFile5.IsValueInsideMinMaxValues(((MarbleRuntimeSettings) data).TopPosition, ((MarbleRuntimeSettings) depthPositionsList1[index20]).BottomPosition, ((MarbleRuntimeSettings) depthPositionsList1[index20]).TopPosition);
                      bool flag7 = buFile5.IsValueInsideMinMaxValues(((MarbleRuntimeSettings) data).BottomPosition, ((MarbleRuntimeSettings) depthPositionsList1[index20]).BottomPosition, ((MarbleRuntimeSettings) depthPositionsList1[index20]).TopPosition);
                      if (flag6 | flag7)
                      {
                        flag5 = true;
                        if (flag6 & !flag7)
                        {
                          ((MarbleRuntimeSettings) depthPositionsList1[index20]).BottomPosition = ((MarbleRuntimeSettings) data).BottomPosition;
                          ((MarbleRuntimeSettings) depthPositionsList1[index20]).Depth = ((MarbleRuntimeSettings) depthPositionsList1[index20]).BottomPosition - ((MarbleRuntimeSettings) depthPositionsList1[index20]).TopPosition;
                        }
                        else if (!flag6 & flag7)
                        {
                          ((MarbleRuntimeSettings) depthPositionsList1[index20]).TopPosition = ((MarbleRuntimeSettings) data).TopPosition;
                          ((MarbleRuntimeSettings) depthPositionsList1[index20]).Depth = ((MarbleRuntimeSettings) depthPositionsList1[index20]).BottomPosition - ((MarbleRuntimeSettings) depthPositionsList1[index20]).TopPosition;
                        }
                      }
                    }
                    if (!flag5)
                      depthPositionsList1.Add(data);
                  }
                }
                else if (!flag1)
                {
                  depthPositions = (DepthPositions) new MarbleColorSettings(data);
                  flag1 = true;
                }
              }
            }
          }
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZEnable)
          {
            depthPositionsList1.Clear();
            DepthPositions data = (DepthPositions) new MarbleColorSettings();
            ((MarbleRuntimeSettings) data).TopPosition = ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZVal;
            ((MarbleRuntimeSettings) data).BottomPosition = ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZVal + ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ExternalDepth + ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ExtraDepth;
            ((MarbleRuntimeSettings) data).Depth = ((MarbleRuntimeSettings) data).BottomPosition - ((MarbleRuntimeSettings) data).TopPosition;
            depthPositions = (DepthPositions) new MarbleColorSettings(data);
          }
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Free)
        {
          DepthPositions data = (DepthPositions) new MarbleColorSettings();
          ((MarbleRuntimeSettings) data).TopPosition = 0.0;
          ((MarbleRuntimeSettings) data).BottomPosition = 0.0;
          ((MarbleRuntimeSettings) data).Depth = ExternalDepth;
          if (((MarbleRuntimeSettings) data).Depth == 0.0)
            ((MarbleRuntimeSettings) data).Depth = 2.0;
          ((MarbleRuntimeSettings) data).Depth = ((MarbleRuntimeSettings) data).Depth + ExtraDepth;
          depthPositions = (DepthPositions) new MarbleColorSettings(data);
        }
      }
      ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Depth = depthPositions;
      if (depthPositionsList1.Count > 1)
      {
        List<DepthPositions> depthPositionsList2 = new List<DepthPositions>();
        depthPositionsList2.Add((DepthPositions) new MarbleColorSettings(depthPositionsList1[0]));
        for (int index21 = 1; index21 <= depthPositionsList1.Count - 1; ++index21)
        {
          bool flag8 = false;
          for (int index22 = 0; index22 <= depthPositionsList2.Count - 1; ++index22)
          {
            bool flag9 = buFile5.IsValueInsideMinMaxValues(((MarbleRuntimeSettings) depthPositionsList1[index21]).TopPosition, ((MarbleRuntimeSettings) depthPositionsList2[index22]).BottomPosition, ((MarbleRuntimeSettings) depthPositionsList2[index22]).TopPosition, 0.5);
            bool flag10 = buFile5.IsValueInsideMinMaxValues(((MarbleRuntimeSettings) depthPositionsList1[index21]).BottomPosition, ((MarbleRuntimeSettings) depthPositionsList2[index22]).BottomPosition, ((MarbleRuntimeSettings) depthPositionsList2[index22]).TopPosition, 0.5);
            if (flag9 | flag10)
            {
              flag8 = true;
              if (flag9 & !flag10)
              {
                ((MarbleRuntimeSettings) depthPositionsList2[index22]).BottomPosition = ((MarbleRuntimeSettings) depthPositionsList1[index21]).BottomPosition;
                ((MarbleRuntimeSettings) depthPositionsList2[index22]).Depth = ((MarbleRuntimeSettings) depthPositionsList2[index22]).BottomPosition - ((MarbleRuntimeSettings) depthPositionsList2[index22]).TopPosition;
              }
              else if (!flag9 & flag10)
              {
                ((MarbleRuntimeSettings) depthPositionsList2[index22]).TopPosition = ((MarbleRuntimeSettings) depthPositionsList1[index21]).TopPosition;
                ((MarbleRuntimeSettings) depthPositionsList2[index22]).Depth = ((MarbleRuntimeSettings) depthPositionsList2[index22]).BottomPosition - ((MarbleRuntimeSettings) depthPositionsList2[index22]).TopPosition;
              }
            }
          }
          if (!flag8)
            depthPositionsList2.Add((DepthPositions) new MarbleColorSettings(depthPositionsList1[index21]));
        }
        ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues = depthPositionsList2;
      }
      else
        ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues = depthPositionsList1;
      if (DepthUp != 0.0)
      {
        for (int index = 0; index <= ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues.Count - 1; ++index)
        {
          if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
            ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[index]).TopPosition = ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[index]).TopPosition - DepthUp;
          else
            ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[index]).TopPosition = ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[index]).TopPosition + DepthUp;
          ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[index]).Depth = ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[index]).BottomPosition - ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[index]).TopPosition;
        }
      }
      valueFromProfile = true;
    }
    return valueFromProfile;
  }
}
