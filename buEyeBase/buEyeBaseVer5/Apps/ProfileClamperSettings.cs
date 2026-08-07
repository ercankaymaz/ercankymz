// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileClamperSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileClamperSettings : buSerilization5
{
  public bool ShowPartOtherColumb;
  public bool ShowPartAuxColumb;
  public bool ShowPartThicknessColumb;
  public static List<string> Captions;
  public int NestingThreadCalculationCount;
  public bool NestExecutionByThread;
  public int GarbageCollectionDisableSize;
  public bool ShowResultPreviewAfterFinish;
  public bool ShowBetterResult;
  public bool DeleteNestedPartAfterNesting;
  public bool UseCallBacks;
  public bool UseCompactMethod;
  public double CompactTime;
  public static List<string> Captions;
  public LengthUnit UnitLength;
  public LengthUnit UnitArea;
  public SpeedUnit UnitSpeed;
  public nestCalculationShowFormat CalculationShowFormat;
  public bool isCutter;
  public bool View3D;
  public bool DoubleSheetAtPdf;
  public double PenUpTime;
  public double PenDownTime;
  public double CuttingSpeed;
  public double NoneCuttingSpeed;
  public bool UseNoneCutting;
  public double TextTime;

  public void OperationDimensionEntities(
    ref ProfileOperation OP,
    ProfileItem curItem,
    double selectedFreePlaneLength)
  {
    Point3D point3D1 = (Point3D) null;
    Point3D point3D2 = (Point3D) null;
    Point3D point3D3 = (Point3D) null;
    Point3D point3D4 = (Point3D) null;
    Point3D point3D5 = (Point3D) null;
    Point3D point3D6 = (Point3D) null;
    Plane drawingPlane = (Plane) null;
    double num1 = 0.0;
    double num2 = 0.0;
    double Angle = 0.0;
    ((ProfileRuntimeSettings) OP).EntityDimension.Clear();
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileRectangle)
    {
      num1 = ((CreateProfileFromDataOptions) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData).RectangleWidth;
      num2 = ((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData).RectangleHeight;
      Angle = ((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData).RectangleAngle;
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileCircle)
      num1 = ((CreateProfileFromDataOptions) ((OperationInsideClampers) ((ProfileRuntimeSettings) OP).OperationData).CircleData).CircleDiameter;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileHole)
      num1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).HoleData).HoleDiameter;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileTapping)
      num1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).HoleData).HoleDiameter;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileEllipse)
    {
      num1 = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).EllipseData).EllipseWidth;
      num2 = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).EllipseData).EllipseHeight;
      Angle = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).EllipseData).EllipseAngle;
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileSlot)
    {
      num1 = ((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).SlotData).SlotWidth;
      num2 = ((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).SlotData).SlotDiameter;
      Angle = ((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).SlotData).SlotAngle;
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileBarrel)
    {
      num1 = ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelLength;
      num2 = ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelWidth;
      Angle = ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelAngle;
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profilePolygon)
      num1 = ((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).PolygonData).PolygonDiameter;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileCut)
    {
      num1 = ((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).CutData).CutWidth;
      num2 = ((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).CutData).CutHeigth;
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileText)
    {
      num1 = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextWidth;
      num2 = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextHeight;
      Angle = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextAngle;
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileWireText)
    {
      num1 = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextWidth;
      num2 = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextHeight;
      Angle = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextAngle;
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileFreeDraw)
    {
      num1 = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).FreeDrawData).FreeDrawWidth;
      num2 = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).FreeDrawData).FreeDrawHeight;
      Angle = ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).FreeDrawData).FreeDrawAngle;
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileNotch)
    {
      num1 = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchWidth;
      num2 = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
    }
    double num3 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
    if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Right)
      num3 = ((ProfileSettings) curItem).Length - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileNotch)
      this.OperationNotchDimensionEntities(ref OP, curItem, selectedFreePlaneLength);
    else if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Free)
    {
      if (num1 > 0.0)
      {
        Point3D point3D7 = new Point3D(-num1 / 2.0, 0.0, 0.0);
        Point3D point3D8 = new Point3D(num1 / 2.0, 0.0, 0.0);
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileBarrel)
        {
          point3D7 = new Point3D(-num1 / 2.0 + ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter / 1.0, 0.0, 0.0);
          point3D8 = new Point3D(num1 / 2.0 + ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter / 1.0, 0.0, 0.0);
        }
        Point3D point3D9 = new Point3D((point3D7.X + point3D8.X) / 2.0, 0.0, 0.0);
        Point3D point3D10 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(point3D7.X, point3D7.Y));
        Point3D point3D11 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(point3D8.X, point3D8.Y));
        point3D3 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(point3D9.X, point3D9.Y - num2 / 2.0 - 10.0));
        buCall.\u0001.AlignedDimCalculate(point3D10, point3D11, point3D3, 10.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane, ref drawingPlane);
        buLinearDim dimEnt = (buLinearDim) new buShapeHole(drawingPlane, point3D10, point3D11, point3D3, 10.0);
        if (Angle != 0.0)
          dimEnt.Rotate(Angle, (Vector3D) ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.Equation);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) dimEnt, ShapeDataValueType.Width);
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
      Point3D point3D12;
      if (num2 > 0.0)
      {
        Point3D point3D13 = new Point3D(0.0, -num2 / 2.0, 0.0);
        Point3D point3D14 = new Point3D(0.0, num2 / 2.0, 0.0);
        Point3D point3D15 = new Point3D(0.0, 0.0, 0.0);
        Point3D point3D16 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(point3D13.X, point3D13.Y));
        Point3D point3D17 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(point3D14.X, point3D14.Y));
        point3D12 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(point3D15.X - 20.0, point3D15.Y));
        Point3D point3D18 = point3D16 - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisY * (((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y - selectedFreePlaneLength / 2.0);
        Point3D point3D19 = point3D17 - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisY * (((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y - selectedFreePlaneLength / 2.0);
        Point3D point3D20 = point3D3 - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisY * (((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y - selectedFreePlaneLength / 2.0);
        point3D20.X = -num1 / 2.0 - 10.0;
        buCall.\u0001.AlignedDimCalculate(point3D18, point3D19, point3D20, 10.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane, ref drawingPlane);
        buLinearDim dimEnt = (buLinearDim) new buShapeHole(drawingPlane, point3D18, point3D19, point3D20, 10.0);
        if (Angle != 0.0)
          dimEnt.Rotate(Angle, (Vector3D) ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.Equation);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) dimEnt, ShapeDataValueType.Height);
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action != actionTypeBU.profileBarrel || ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter <= 0.0)
        return;
      Point3D point3D21 = new Point3D(0.0, -((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter / 2.0, 0.0);
      Point3D point3D22 = new Point3D(0.0, ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter / 2.0, 0.0);
      Point3D point3D23 = new Point3D(0.0, 0.0, 0.0);
      Point3D point3D24 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(point3D21.X, point3D21.Y));
      Point3D point3D25 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(point3D22.X, point3D22.Y));
      point3D12 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.PointAt(new Point2D(point3D23.X, point3D23.Y));
      Point3D point3D26 = point3D24 - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisY * (((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y - selectedFreePlaneLength / 2.0);
      Point3D point3D27 = point3D25 - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisY * (((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y - selectedFreePlaneLength / 2.0);
      Point3D point3D28 = point3D3 - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.AxisY * (((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y - selectedFreePlaneLength / 2.0);
      point3D28.X = -num1 / 2.0 - 10.0;
      buCall.\u0001.AlignedDimCalculate(point3D26, point3D27, point3D28, 10.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane, ref drawingPlane);
      buLinearDim dimEnt1 = (buLinearDim) new buShapeHole(drawingPlane, point3D26, point3D27, point3D28, 10.0);
      if (Angle != 0.0)
        dimEnt1.Rotate(Angle, (Vector3D) ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.Equation);
      DimensionGroup dimensionGroup1 = (DimensionGroup) new camTp((buEntity) dimEnt1, ShapeDataValueType.HeadDiameter);
      ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup1);
    }
    else
    {
      if (num1 > 0.0)
      {
        point3D1 = new Point3D(num3 - num1 / 2.0, 0.0, 0.0);
        point3D2 = new Point3D(num3 + num1 / 2.0, 0.0, 0.0);
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          point3D1.Y = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y;
          point3D2.Y = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y;
          point3D1.Z = ((ProfileRuntimeSettings) OP).ProfileHeight + 1.0;
          point3D2.Z = ((ProfileRuntimeSettings) OP).ProfileHeight + 1.0;
          point3D3 = new Point3D((point3D1.X + point3D2.X) / 2.0, ((ProfileRuntimeSettings) OP).MaxPoint.Y + 10.0, point3D2.Z);
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back)
        {
          point3D1.Y = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
          point3D2.Y = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
          point3D1.Z = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z;
          point3D2.Z = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z;
          point3D3 = new Point3D((point3D1.X + point3D2.X) / 2.0, 0.0, ((ProfileRuntimeSettings) OP).MaxPoint.Z + 10.0);
        }
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileBarrel)
        {
          point3D1.X += ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter;
          point3D2.X += ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter;
          point3D3.X += ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter;
        }
      }
      if (num2 > 0.0)
      {
        point3D4 = new Point3D(((ProfileRuntimeSettings) OP).MinPoint.X, 0.0, 0.0);
        point3D5 = new Point3D(((ProfileRuntimeSettings) OP).MinPoint.X, 0.0, 0.0);
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          point3D4.Y = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y - num2 / 2.0;
          point3D5.Y = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y + num2 / 2.0;
          point3D4.Z = ((ProfileRuntimeSettings) OP).ProfileHeight + 1.0;
          point3D5.Z = ((ProfileRuntimeSettings) OP).ProfileHeight + 1.0;
          point3D6 = new Point3D(point3D4.X - 20.0, (point3D4.Y + point3D5.Y) / 2.0, point3D4.Z);
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back)
        {
          point3D4.Y = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
          point3D5.Y = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
          point3D4.Z = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z - num2 / 2.0;
          point3D5.Z = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z + num2 / 2.0;
          point3D6 = new Point3D(point3D4.X - 20.0, -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0, (point3D4.Z + point3D5.Z) / 2.0);
        }
      }
      if (num1 > 0.0)
      {
        buCall.\u0001.AlignedDimCalculate(point3D1, point3D2, point3D3, 10.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane, ref drawingPlane);
        buLinearDim dimEnt = (buLinearDim) new buShapeHole(drawingPlane, point3D1, point3D2, point3D3, 10.0);
        if (Angle != 0.0)
          dimEnt.Rotate(Angle, (Vector3D) ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.Equation);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) dimEnt, ShapeDataValueType.Width);
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileNotch && ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Side)
        {
          ((camTp) dimensionGroup).PlaneType = planeNames.Front;
          ((camTp) dimensionGroup).UsePlaneType = true;
        }
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
      if (num2 > 0.0)
      {
        buCall.\u0001.AlignedDimCalculate(point3D4, point3D5, point3D6, 10.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane, ref drawingPlane);
        buLinearDim dimEnt = (buLinearDim) new buShapeHole(drawingPlane, point3D4, point3D5, point3D6, 10.0);
        if (Angle != 0.0)
          dimEnt.Rotate(Angle, (Vector3D) ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.Equation);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) dimEnt, ShapeDataValueType.Height);
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileNotch && ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Side)
        {
          ((camTp) dimensionGroup).PlaneType = planeNames.Front;
          ((camTp) dimensionGroup).UsePlaneType = true;
        }
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action != actionTypeBU.profileBarrel || ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter <= 0.0)
        return;
      Point3D point3D29 = new Point3D(((ProfileRuntimeSettings) OP).MinPoint.X, 0.0, 0.0);
      Point3D point3D30 = new Point3D(((ProfileRuntimeSettings) OP).MinPoint.X, 0.0, 0.0);
      if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Bottom)
      {
        point3D29.Y = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y - ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter / 2.0;
        point3D30.Y = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Y + ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter / 2.0;
        point3D29.Z = ((ProfileRuntimeSettings) OP).ProfileHeight + 1.0;
        point3D30.Z = ((ProfileRuntimeSettings) OP).ProfileHeight + 1.0;
        point3D6 = new Point3D(point3D29.X - 20.0, (point3D29.Y + point3D30.Y) / 2.0, point3D29.Z);
      }
      if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back)
      {
        point3D29.Y = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
        point3D30.Y = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
        point3D29.Z = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z - ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter / 2.0;
        point3D30.Z = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.Z + ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter / 2.0;
        point3D6 = new Point3D(point3D29.X - 20.0, -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0, (point3D29.Z + point3D30.Z) / 2.0);
      }
      buCall.\u0001.AlignedDimCalculate(point3D29, point3D30, point3D6, 10.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane, ref drawingPlane);
      buLinearDim dimEnt2 = (buLinearDim) new buShapeHole(drawingPlane, point3D29, point3D30, point3D6, 10.0);
      dimEnt2.Rotate(((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData).RectangleAngle, (Vector3D) ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).selectedPlane.Equation);
      DimensionGroup dimensionGroup2 = (DimensionGroup) new camTp((buEntity) dimEnt2, ShapeDataValueType.HeadDiameter);
      ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup2);
    }
  }

  public void OperationNotchDimensionEntities(
    ref ProfileOperation OP,
    ProfileItem curItem,
    double selectedFreePlaneLength)
  {
    Plane drawingPlane = (Plane) null;
    double x1 = 0.0;
    double x2 = 0.0;
    double x3 = 0.0;
    double y1 = 0.0;
    double z1 = 0.0;
    double z2 = 0.0;
    double notchWidth = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchWidth;
    double notchHeight = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
    double notchDepth = ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchDepth;
    double num = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Side)
    {
      double y2 = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      {
        x1 = 0.0;
        x3 = -20.0;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
      {
        x1 = ((ProfileRuntimeSettings) OP).ProfileLength;
        x3 = ((ProfileRuntimeSettings) OP).ProfileLength + 20.0;
      }
      if (notchHeight > 0.0)
      {
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
        {
          z1 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
          z2 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
        {
          z1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
          z2 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
        }
        Point3D point3D1 = new Point3D(x1, y2, z1);
        Point3D point3D2 = new Point3D(x1, y2, z2);
        Point3D point3D3 = new Point3D(x3, y2, (z1 + z2) / 2.0);
        buCall.\u0001.AlignedDimCalculate(point3D1, point3D2, point3D3, 10.0, Plane.XZ, ref drawingPlane);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) new buShapeHole(drawingPlane, point3D1, point3D2, point3D3, 10.0), ShapeDataValueType.Distance);
        ((camTp) dimensionGroup).PlaneType = planeNames.Front;
        ((camTp) dimensionGroup).UsePlaneType = true;
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
      if (num >= 0.0)
      {
        string str = "";
        if (num == 0.0)
        {
          num = 0.1;
          str = "0";
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
        {
          z1 = ((ProfileRuntimeSettings) OP).ProfileHeight;
          z2 = ((ProfileRuntimeSettings) OP).ProfileHeight - num;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
        {
          z1 = 0.0;
          z2 = num;
        }
        Point3D point3D4 = new Point3D(x1, y2, z1);
        Point3D point3D5 = new Point3D(x1, y2, z2);
        Point3D point3D6 = new Point3D(x3, y2, (z1 + z2) / 2.0);
        buCall.\u0001.AlignedDimCalculate(point3D4, point3D5, point3D6, 10.0, Plane.XZ, ref drawingPlane);
        buLinearDim dimEnt = (buLinearDim) new buShapeHole(drawingPlane, point3D4, point3D5, point3D6, 10.0);
        ((PolyNode) dimEnt).TextOverride = str;
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) dimEnt, ShapeDataValueType.Height);
        ((camTp) dimensionGroup).PlaneType = planeNames.Front;
        ((camTp) dimensionGroup).UsePlaneType = true;
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
      if (notchDepth > 0.0)
      {
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
        {
          x1 = 0.0;
          x2 = notchDepth;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
        {
          x1 = ((ProfileRuntimeSettings) OP).ProfileLength;
          x2 = ((ProfileRuntimeSettings) OP).ProfileLength - notchDepth;
        }
        x3 = (x1 + x2) / 2.0;
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
        {
          z1 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
          z2 = z1 - 10.0;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
        {
          z1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
          z2 = z1 + 10.0;
        }
        Point3D point3D7 = new Point3D(x1, y2, z1);
        Point3D point3D8 = new Point3D(x2, y2, z1);
        Point3D point3D9 = new Point3D(x3, y2, z2);
        buCall.\u0001.AlignedDimCalculate(point3D7, point3D8, point3D9, 10.0, Plane.XZ, ref drawingPlane);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) new buShapeHole(drawingPlane, point3D7, point3D8, point3D9, 10.0), ShapeDataValueType.Width);
        ((camTp) dimensionGroup).PlaneType = planeNames.Front;
        ((camTp) dimensionGroup).UsePlaneType = true;
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
    }
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Vertical)
    {
      double y3 = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
      {
        x1 = 0.0;
        x3 = -20.0;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
      {
        x1 = ((ProfileRuntimeSettings) OP).ProfileLength;
        x3 = ((ProfileRuntimeSettings) OP).ProfileLength + 20.0;
      }
      if (notchHeight > 0.0)
      {
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchFrontBack == FrontBackType.Front)
        {
          y3 = -((ProfileRuntimeSettings) OP).ProfileHeight + num;
          y1 = -((ProfileRuntimeSettings) OP).ProfileHeight + num + notchHeight;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchFrontBack == FrontBackType.Back)
        {
          y3 = -num;
          y1 = -num - notchHeight;
        }
        z1 = ((ProfileRuntimeSettings) OP).ProfileHeight;
        Point3D point3D10 = new Point3D(x1, y1, z1);
        Point3D point3D11 = new Point3D(x1, y3, z1);
        Point3D point3D12 = new Point3D(x1, (y3 + y1) / 2.0, z1 + 10.0);
        buCall.\u0001.AlignedDimCalculate(point3D10, point3D11, point3D12, 10.0, Plane.YZ, ref drawingPlane);
        drawingPlane.Rotate(buString5.DegreeToRadian(180.0), Vector3D.AxisZ);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) new buShapeHole(drawingPlane, point3D10, point3D11, point3D12, 10.0), ShapeDataValueType.Distance);
        ((camTp) dimensionGroup).PlaneType = planeNames.Left;
        ((camTp) dimensionGroup).UsePlaneType = true;
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
      if (num >= 0.0)
      {
        string str = "";
        if (num == 0.0)
        {
          num = 0.1;
          str = "0";
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchFrontBack == FrontBackType.Front)
        {
          y3 = -((ProfileRuntimeSettings) OP).ProfileHeight;
          y1 = -((ProfileRuntimeSettings) OP).ProfileHeight + num;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchFrontBack == FrontBackType.Back)
        {
          y3 = 0.0;
          y1 = -num;
        }
        z1 = ((ProfileRuntimeSettings) OP).ProfileHeight;
        Point3D point3D13 = new Point3D(x1, y1, z1);
        Point3D point3D14 = new Point3D(x1, y3, z1);
        Point3D point3D15 = new Point3D(x1, (y3 + y1) / 2.0, z1 + 10.0);
        buCall.\u0001.AlignedDimCalculate(point3D13, point3D14, point3D15, 10.0, Plane.YZ, ref drawingPlane);
        drawingPlane.Rotate(buString5.DegreeToRadian(180.0), Vector3D.AxisZ);
        buLinearDim dimEnt = (buLinearDim) new buShapeHole(drawingPlane, point3D13, point3D14, point3D15, 10.0);
        ((PolyNode) dimEnt).TextOverride = str;
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) dimEnt, ShapeDataValueType.Height);
        ((camTp) dimensionGroup).PlaneType = planeNames.Left;
        ((camTp) dimensionGroup).UsePlaneType = true;
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
      if (notchDepth > 0.0)
      {
        double y4 = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Left)
        {
          x1 = 0.0;
          x2 = notchDepth;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Right)
        {
          x1 = ((ProfileRuntimeSettings) OP).ProfileLength;
          x2 = ((ProfileRuntimeSettings) OP).ProfileLength - notchDepth;
        }
        x3 = (x1 + x2) / 2.0;
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
        {
          z1 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
          z2 = z1 - 10.0;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
        {
          z1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
          z2 = z1 + 10.0;
        }
        Point3D point3D16 = new Point3D(x1, y4, z1);
        Point3D point3D17 = new Point3D(x2, y4, z1);
        Point3D point3D18 = new Point3D(x3, y4, z2);
        buCall.\u0001.AlignedDimCalculate(point3D16, point3D17, point3D18, 10.0, Plane.XZ, ref drawingPlane);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) new buShapeHole(drawingPlane, point3D16, point3D17, point3D18, 10.0), ShapeDataValueType.Width);
        ((camTp) dimensionGroup).PlaneType = planeNames.Front;
        ((camTp) dimensionGroup).UsePlaneType = true;
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
    }
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Length)
    {
      double y5 = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
      if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Left)
      {
        x1 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
        x2 = x1 + notchWidth;
      }
      if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Right)
      {
        x1 = ((ProfileSettings) curItem).Length - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X - notchWidth;
        x2 = x1 + notchWidth;
      }
      if (notchHeight > 0.0)
      {
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
        {
          z1 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
          z2 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
        {
          z1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
          z2 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
        }
        Point3D point3D19 = new Point3D(x1, y5, z1);
        Point3D point3D20 = new Point3D(x1, y5, z2);
        Point3D point3D21 = new Point3D(x1 - 10.0, y5, (z1 + z2) / 2.0);
        buCall.\u0001.AlignedDimCalculate(point3D19, point3D20, point3D21, 10.0, Plane.XZ, ref drawingPlane);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) new buShapeHole(drawingPlane, point3D19, point3D20, point3D21, 10.0), ShapeDataValueType.Height);
        ((camTp) dimensionGroup).PlaneType = planeNames.Front;
        ((camTp) dimensionGroup).UsePlaneType = true;
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
      if (notchWidth > 0.0)
      {
        x3 = (x1 + x2) / 2.0;
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
        {
          z1 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
          z2 = z1 - 10.0;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
        {
          z1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
          z2 = z1 + 10.0;
        }
        Point3D point3D22 = new Point3D(x1, y5, z1);
        Point3D point3D23 = new Point3D(x2, y5, z1);
        Point3D point3D24 = new Point3D(x3, y5, z2);
        buCall.\u0001.AlignedDimCalculate(point3D22, point3D23, point3D24, 10.0, Plane.XZ, ref drawingPlane);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) new buShapeHole(drawingPlane, point3D22, point3D23, point3D24, 10.0), ShapeDataValueType.Width);
        ((camTp) dimensionGroup).PlaneType = planeNames.Front;
        ((camTp) dimensionGroup).UsePlaneType = true;
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
      if (notchDepth > 0.0)
      {
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Front)
        {
          y5 = -((ProfileRuntimeSettings) OP).ProfileWidth;
          y1 = -((ProfileRuntimeSettings) OP).ProfileWidth + notchDepth;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Back)
        {
          y5 = 0.0;
          y1 = -notchDepth;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
        {
          z1 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
          z2 = z1 - 10.0;
        }
        if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
        {
          z1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
          z2 = z1 + 10.0;
        }
        Point3D point3D25 = new Point3D(0.0, y5, z1);
        Point3D point3D26 = new Point3D(0.0, y1, z1);
        Point3D point3D27 = new Point3D(x3, y5, z2);
        buCall.\u0001.AlignedDimCalculate(point3D25, point3D26, point3D27, 10.0, Plane.YZ, ref drawingPlane);
        drawingPlane.Rotate(buString5.DegreeToRadian(180.0), Vector3D.AxisZ);
        DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) new buShapeHole(drawingPlane, point3D25, point3D26, point3D27, 10.0), ShapeDataValueType.Distance);
        ((camTp) dimensionGroup).PlaneType = planeNames.Left;
        ((camTp) dimensionGroup).UsePlaneType = true;
        ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
      }
    }
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType != ProfileNotchOperationType.Horizontal)
      return;
    double y6 = -((ProfileRuntimeSettings) OP).ProfileWidth - 1.0;
    if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Left)
    {
      x1 = ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X;
      x2 = x1 + notchWidth;
    }
    if (((ProfileSettings) curItem).XReferanceLocation == LeftRightType.Right)
    {
      x1 = ((ProfileSettings) curItem).Length - ((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position.X - notchWidth;
      x2 = x1 + notchWidth;
    }
    if (notchHeight > 0.0)
    {
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
      {
        z1 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
        z2 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
      {
        z1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart;
        z2 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
      }
      Point3D point3D28 = new Point3D(x1, y6, z1);
      Point3D point3D29 = new Point3D(x1, y6, z2);
      Point3D point3D30 = new Point3D(x1 - 10.0, y6, (z1 + z2) / 2.0);
      buCall.\u0001.AlignedDimCalculate(point3D28, point3D29, point3D30, 10.0, Plane.XZ, ref drawingPlane);
      DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) new buShapeHole(drawingPlane, point3D28, point3D29, point3D30, 10.0), ShapeDataValueType.Height);
      ((camTp) dimensionGroup).PlaneType = planeNames.Front;
      ((camTp) dimensionGroup).UsePlaneType = true;
      ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
    }
    if (notchWidth > 0.0)
    {
      x3 = (x1 + x2) / 2.0;
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
      {
        z1 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
        z2 = z1 - 10.0;
      }
      if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
      {
        z1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
        z2 = z1 + 10.0;
      }
      Point3D point3D31 = new Point3D(x1, y6, z1);
      Point3D point3D32 = new Point3D(x2, y6, z1);
      Point3D point3D33 = new Point3D(x3, y6, z2);
      buCall.\u0001.AlignedDimCalculate(point3D31, point3D32, point3D33, 10.0, Plane.XZ, ref drawingPlane);
      DimensionGroup dimensionGroup = (DimensionGroup) new camTp((buEntity) new buShapeHole(drawingPlane, point3D31, point3D32, point3D33, 10.0), ShapeDataValueType.Width);
      ((camTp) dimensionGroup).PlaneType = planeNames.Front;
      ((camTp) dimensionGroup).UsePlaneType = true;
      ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup);
    }
    if (notchDepth <= 0.0)
      return;
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Front)
    {
      y6 = -((ProfileRuntimeSettings) OP).ProfileWidth;
      y1 = -((ProfileRuntimeSettings) OP).ProfileWidth + notchDepth;
    }
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchLocation == ProfileNotchLocationType.Back)
    {
      y6 = 0.0;
      y1 = -notchDepth;
    }
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Up)
    {
      z1 = ((ProfileRuntimeSettings) OP).ProfileHeight - ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart - ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
      z2 = z1 - 10.0;
    }
    if (((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchUpDown == UpDownLocationType.Down)
    {
      z1 = ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchStart + ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchHeight;
      z2 = z1 + 10.0;
    }
    Point3D point3D34 = new Point3D(0.0, y6, z1);
    Point3D point3D35 = new Point3D(0.0, y1, z1);
    Point3D point3D36 = new Point3D(x3, y6, z2);
    buCall.\u0001.AlignedDimCalculate(point3D34, point3D35, point3D36, 10.0, Plane.YZ, ref drawingPlane);
    drawingPlane.Rotate(buString5.DegreeToRadian(180.0), Vector3D.AxisZ);
    DimensionGroup dimensionGroup1 = (DimensionGroup) new camTp((buEntity) new buShapeHole(drawingPlane, point3D34, point3D35, point3D36, 10.0), ShapeDataValueType.Distance);
    ((camTp) dimensionGroup1).PlaneType = planeNames.Left;
    ((camTp) dimensionGroup1).UsePlaneType = true;
    ((ProfileRuntimeSettings) OP).EntityDimension.Add(dimensionGroup1);
  }
}
