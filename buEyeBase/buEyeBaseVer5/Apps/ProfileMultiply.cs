// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileMultiply
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileMultiply : buSerilization5
{
  public buNestingResultSettings ResultSettings;
  public buNestingRuntime Runtime;
  public buNestingDraw Draw;
  public AnalyseEntitiesSetting AnalyseSettings;

  public double GetOperationRotationAngle(ProfileOperation OP)
  {
    return ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType != ProfileOperationTypes.Barrel ? (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType != ProfileOperationTypes.Cut ? (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType != ProfileOperationTypes.Ellipse ? (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType != ProfileOperationTypes.FreeDraw ? (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType != ProfileOperationTypes.Polygon ? (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType != ProfileOperationTypes.Rectangle ? (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType != ProfileOperationTypes.RoundRectangle ? (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType != ProfileOperationTypes.Slot ? (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType != ProfileOperationTypes.Text ? 0.0 : ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextAngle) : ((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).SlotData).SlotAngle) : ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleRoundData).RoundRectangleAngle) : ((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData).RectangleAngle) : ((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).PolygonData).PolygonAngle) : ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).FreeDrawData).FreeDrawAngle) : ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).EllipseData).EllipseAngle) : ((PanelWaitAssembly) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).CutData).CutAngle) : ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelAngle;
  }

  public void SetOperationRotationAngle(ref ProfileOperation OP, double Angle)
  {
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Barrel)
      ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelAngle = Angle;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Cut)
      ((PanelWaitAssembly) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).CutData).CutAngle = Angle;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Ellipse)
      ((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).EllipseData).EllipseAngle = Angle;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.FreeDraw)
      ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).FreeDrawData).FreeDrawAngle = Angle;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Polygon)
      ((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).PolygonData).PolygonAngle = Angle;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Rectangle)
      ((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData).RectangleAngle = Angle;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.RoundRectangle)
      ((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleRoundData).RoundRectangleAngle = Angle;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Slot)
      ((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).SlotData).SlotAngle = Angle;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType != ProfileOperationTypes.Text)
      return;
    ((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextAngle = Angle;
  }

  public void BoxSizeOfGOperationGroup(ref GProfileOperationGroup Grp)
  {
    List<Point3D> Points = new List<Point3D>();
    for (int index = 0; index <= ((ProfileSettings) Grp).OpList.Count - 1; ++index)
    {
      Points.Add(F_NotchEdit.ToPoint3D(((MachineSimulation) ((ProfileRuntimeSettings) ((ProfileSettings) Grp).OpList[index]).SizePoint).MaxPoint));
      Points.Add(F_NotchEdit.ToPoint3D(((FlatViewSettings) ((ProfileRuntimeSettings) ((ProfileSettings) Grp).OpList[index]).SizePoint).MinPoint));
    }
    Point3D MinPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    buCall.\u0001.BoxSizeCalculate(Points, ref MinPoint, ref MaxPoint);
    ((ProfileSettings) Grp).Size = (BoxSize5) new SortbuCamData(MinPoint, MaxPoint);
  }
}
