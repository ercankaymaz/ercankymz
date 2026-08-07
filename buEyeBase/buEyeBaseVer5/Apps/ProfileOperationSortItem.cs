// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationSortItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using devDept.Geometry;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationSortItem : buSerilization5
{
  public Color SheetEntityColor;
  public Color PartInnerEntityColor;
  public Color SheetInnerColor;
  public double PartEntityThickness;
  public double PartInnerEntityThickness;

  public bool isOperationSafeForClamps(
    ProfileItem Item,
    ProfileItemCalc ItemCalc,
    GProfileOperation sortOP,
    ProfileSettings varProfileSet,
    ProfileClamperSettings varProfileClampSet)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    bool flag = false;
    if (((ProfileMirror) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlaneName == planeNames.Free)
    {
      num1 = buCall.\u0001.PointAngle(new Point3D(((ProfilePatternCopy) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlane.AxisZ.X, ((ProfilePatternCopy) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlane.AxisZ.Y, ((ProfilePatternCopy) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlane.AxisZ.Z), new Point3D(), Plane.YZ);
      num2 = num1 <= 90.0 ? 90.0 - num1 : num1 - 90.0;
    }
    if (((ProfileMirror) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlaneName == planeNames.Bottom | ((ProfileMirror) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlaneName == planeNames.Free & num2 <= ((buMarbleCalc) varProfileClampSet).FreePlaneToBackFrontAngleLimit)
    {
      if (((ProfileSettings) ItemCalc).Height + ((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockZHeight > ((buMarbleCalc) varProfileClampSet).ClamperMaxHeight)
        flag = true;
      if (((FlatViewSettings) ((ProfileRuntimeSettings) sortOP).SizePoint).MinPoint.Z + ((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockZHeight > ((buMarbleCalc) varProfileClampSet).ClamperMaxHeight)
        flag = true;
      if (((FlatViewSettings) ((ProfileRuntimeSettings) sortOP).SizePoint).MinPoint.Y - ((MarbleVacuumCut) varProfileSet).ToolPensDiameter / 2.0 - 5.0 > -((ProfileSettings) ItemCalc).Width & ((MachineSimulation) ((ProfileRuntimeSettings) sortOP).SizePoint).MaxPoint.Y + ((MarbleVacuumCut) varProfileSet).ToolPensDiameter / 2.0 + 5.0 < 0.0)
        flag = true;
      if (((FlatViewSettings) ((ProfileRuntimeSettings) sortOP).SizePoint).MinPoint.Z + ((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockZHeight + (((ToolGeometry5) ((ProfileRuntimeSettings) sortOP).Tool).Geometry.TotalLength - ((MarbleVacuumCut) varProfileSet).ToolHolderLength) > ((buMarbleCalc) varProfileClampSet).ClamperMaxHeight && ((FlatViewSettings) ((ProfileRuntimeSettings) sortOP).SizePoint).MinPoint.Y - ((ToolGeometry5) ((ProfileRuntimeSettings) sortOP).Tool).Geometry.Diameter / 2.0 - 5.0 > -((ProfileSettings) ItemCalc).Width & ((MachineSimulation) ((ProfileRuntimeSettings) sortOP).SizePoint).MaxPoint.Y + ((ToolGeometry5) ((ProfileRuntimeSettings) sortOP).Tool).Geometry.Diameter / 2.0 + 5.0 < 0.0)
        flag = true;
    }
    if (((ProfileMirror) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlaneName == planeNames.Back | ((ProfileMirror) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlaneName == planeNames.Free & num2 > ((buMarbleCalc) varProfileClampSet).FreePlaneToBackFrontAngleLimit & num1 < 90.0 && ((ProfileMirror) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlaneName == planeNames.Free && ((FlatViewSettings) ((ProfileRuntimeSettings) sortOP).SizePoint).MinPoint.Z + ((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockZHeight > ((buMarbleCalc) varProfileClampSet).ClamperMaxHeight)
      flag = true;
    if (((ProfileMirror) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlaneName == planeNames.Free & num2 > ((buMarbleCalc) varProfileClampSet).FreePlaneToBackFrontAngleLimit & num1 > 90.0 && ((ProfileMirror) ((ProfileRuntimeSettings) sortOP).OperationData).selectedPlaneName == planeNames.Free && ((FlatViewSettings) ((ProfileRuntimeSettings) sortOP).SizePoint).MinPoint.Z + ((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockZHeight > ((buMarbleCalc) varProfileClampSet).ClamperMaxHeight)
      flag = true;
    return flag;
  }

  public bool isNotchOperationSimilar(GProfileOperation FirstOP, GProfileOperation SecondOP)
  {
    return (FirstOP == null ? 0 : (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) FirstOP).OperationData).OperationType == ProfileOperationTypes.Notch ? 1 : 0)) != 0 && ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) FirstOP).OperationData).NotchData).NotchOPType == ProfileNotchOperationType.Side && (SecondOP == null ? 0 : (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) SecondOP).OperationData).OperationType == ProfileOperationTypes.Notch ? 1 : 0)) != 0 && ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) FirstOP).OperationData).NotchData).NotchOPType == ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) SecondOP).OperationData).NotchData).NotchOPType && ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) FirstOP).OperationData).NotchData).NotchLocation == ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) SecondOP).OperationData).NotchData).NotchLocation & ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) FirstOP).OperationData).NotchData).NotchFrontBack == ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) SecondOP).OperationData).NotchData).NotchFrontBack && ((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) FirstOP).OperationData).CamParNotch).Notch).NotchCutType == ((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) SecondOP).OperationData).CamParNotch).Notch).NotchCutType;
  }

  public void PositionConversionFromPlane(
    ProfileItem curItem,
    planeNames selectedPlaneName,
    Plane selectedPlane,
    ref ProfileOperationData OPData,
    ref double Ang)
  {
    Ang = buCall.\u0001.PlaneAngleYZ(selectedPlane);
  }

  public ShapeTypes ActionToShapeType(actionTypeBU action)
  {
    ShapeTypes shapeType = ShapeTypes.Rectangle;
    if (action == actionTypeBU.profileRectangle)
      shapeType = ShapeTypes.Rectangle;
    if (action == actionTypeBU.profileCircle)
      shapeType = ShapeTypes.Circle;
    if (action == actionTypeBU.profileEllipse)
      shapeType = ShapeTypes.Ellipse;
    if (action == actionTypeBU.profileBarrel)
      shapeType = ShapeTypes.KeyHole;
    if (action == actionTypeBU.profilePolygon)
      shapeType = ShapeTypes.Polygon;
    if (action == actionTypeBU.profileSlot)
      shapeType = ShapeTypes.Slot;
    if (action == actionTypeBU.profileHole)
      shapeType = ShapeTypes.Hole;
    if (action == actionTypeBU.profileTapping)
      shapeType = ShapeTypes.Hole;
    if (action == actionTypeBU.profileCut)
      shapeType = ShapeTypes.Cut;
    if (action == actionTypeBU.profileFreeDraw)
      shapeType = ShapeTypes.FreeDraw;
    if (action == actionTypeBU.profileText)
      shapeType = ShapeTypes.Text;
    if (action == actionTypeBU.profileWireText)
      shapeType = ShapeTypes.Text;
    return shapeType;
  }

  public void ManuelZValueFromPlaneChange(
    ProfileItem curItem,
    ProfileOperation OP,
    planeNames newPlane,
    double refManuelZVal,
    ref double calcManuelZVal)
  {
    if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front)
    {
      if (newPlane == planeNames.Back)
      {
        calcManuelZVal = ((ProfileSettings) curItem).Width + refManuelZVal;
        if (calcManuelZVal > 0.0)
          calcManuelZVal = 0.0;
      }
      if (newPlane != planeNames.Top)
        return;
      calcManuelZVal = ((ProfileSettings) curItem).Height + (-((ProfileSettings) curItem).Width - refManuelZVal);
    }
    else if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back)
    {
      if (newPlane == planeNames.Front)
      {
        calcManuelZVal = -((ProfileSettings) curItem).Width - refManuelZVal;
        if (calcManuelZVal < -((ProfileSettings) curItem).Width)
          calcManuelZVal = -((ProfileSettings) curItem).Width;
      }
      if (newPlane != planeNames.Top)
        return;
      calcManuelZVal = ((ProfileSettings) curItem).Height + refManuelZVal;
    }
    else if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top)
      ;
  }
}
