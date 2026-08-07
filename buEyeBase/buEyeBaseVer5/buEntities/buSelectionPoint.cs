// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buSelectionPoint
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buSelectionPoint : devDept.Eyeshot.Entities.Point
{
  public const buEntityUpdateType ArcCenterStartEndRadiusPlaneFlip = ; // Unable to render the field
  public const buEntityUpdateType ArcDerivate = ; // Unable to render the field
  public const buEntityUpdateType CircleCenterRadius = ; // Unable to render the field
  public const buEntityUpdateType CircleCenterRadiusPlane = ; // Unable to render the field
  public const buEntityUpdateType CircleCenter2DRadiusPlane = ; // Unable to render the field
  public const buEntityUpdateType Circle3Point = ; // Unable to render the field
  public const buEntityUpdateType Circle3Point2D = ; // Unable to render the field
  public const buEntityUpdateType CircleDerivate = ; // Unable to render the field

  public buSelectionPoint()
  {
    ((DiemakerGrindingShapeSettings) this).DiameterOutside = 4.0;
    ((DiemakerGrindingShapeSettings) this).Hole3Angle = 0.0;
    ((DiemakerGrindingShapeSettings) this).DistanceX = 40.0;
    ((DiemakerGrindingShapeSettings) this).DistanceY = 40.0;
    // ISSUE: explicit constructor call
    ((buLinearPathArrow) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).DrillType = drillTypes.ThreeHole;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Drill;
  }

  public buSelectionPoint(
    double diameter,
    double depth,
    double diameteroutside,
    double distancex,
    double distancey,
    double angle = 0.0)
  {
    ((DiemakerGrindingShapeSettings) this).DiameterOutside = 4.0;
    ((DiemakerGrindingShapeSettings) this).Hole3Angle = 0.0;
    ((DiemakerGrindingShapeSettings) this).DistanceX = 40.0;
    ((DiemakerGrindingShapeSettings) this).DistanceY = 40.0;
    // ISSUE: explicit constructor call
    ((buLinearPathArrow) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Diameter = diameter;
    ((DiemakerGrindingShapeSettings) this).DiameterOutside = diameteroutside;
    ((\u0012.\u0002) this).Depth = depth;
    ((DiemakerGrindingShapeSettings) this).DistanceX = distancex;
    ((DiemakerGrindingShapeSettings) this).DistanceY = distancey;
    ((DiemakerGrindingShapeSettings) this).Hole3Angle = angle;
    ((DiemakerGrindingShapeSettings) this).DrillType = drillTypes.ThreeHole;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Drill;
  }

  public buSelectionPoint(buShape data)
  {
    ((DiemakerGrindingShapeSettings) this).DiameterOutside = 4.0;
    ((DiemakerGrindingShapeSettings) this).Hole3Angle = 0.0;
    ((DiemakerGrindingShapeSettings) this).DistanceX = 40.0;
    ((DiemakerGrindingShapeSettings) this).DistanceY = 40.0;
    // ISSUE: explicit constructor call
    ((buLinearPathArrow) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    string str = $"Hole 3 | {((buClipperBase) this).planeName.ToString()} Dia: {((DiemakerGrindingShapeSettings) this).Diameter.ToString("f2")} DiaOut: {((DiemakerGrindingShapeSettings) this).DiameterOutside.ToString("f2")} DisX: {((DiemakerGrindingShapeSettings) this).DistanceX.ToString("f2")} DisY: {((DiemakerGrindingShapeSettings) this).DistanceY.ToString("f2")}";
    if (((DiemakerGrindingShapeSettings) this).Hole3Angle != 0.0)
      str = $"{str} , Angle: {((DiemakerGrindingShapeSettings) this).Hole3Angle.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018C9();

  public buSelectionPoint()
  {
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Length = 200.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    ((DiemakerGrindingShapeSettings) this).StartDistance = 0.0;
    ((DiemakerGrindingShapeSettings) this).EndDistance = 0.0;
    ((DiemakerGrindingShapeSettings) this).CutType = CutTypes.CutHorizontal;
    ((DiemakerGrindingShapeSettings) this).isMilling = false;
    ((buCutter) this).pntEnd = new Point3D();
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Cut;
  }

  public buSelectionPoint(
    CutTypes slotType,
    double diameter,
    double depth,
    double length,
    double startdistance = 0.0,
    double enddistance = 0.0,
    double angle = 0.0)
  {
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Length = 200.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    ((DiemakerGrindingShapeSettings) this).StartDistance = 0.0;
    ((DiemakerGrindingShapeSettings) this).EndDistance = 0.0;
    ((DiemakerGrindingShapeSettings) this).CutType = CutTypes.CutHorizontal;
    ((DiemakerGrindingShapeSettings) this).isMilling = false;
    ((buCutter) this).pntEnd = new Point3D();
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Diameter = diameter;
    ((DiemakerGrindingShapeSettings) this).Length = length;
    ((DiemakerGrindingShapeSettings) this).Angle = angle;
    ((DiemakerGrindingShapeSettings) this).StartDistance = startdistance;
    ((DiemakerGrindingShapeSettings) this).EndDistance = enddistance;
    ((\u0012.\u0002) this).Depth = depth;
    ((DiemakerGrindingShapeSettings) this).CutType = slotType;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Cut;
  }

  public buSelectionPoint(buShape data)
  {
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Length = 200.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    ((DiemakerGrindingShapeSettings) this).StartDistance = 0.0;
    ((DiemakerGrindingShapeSettings) this).EndDistance = 0.0;
    ((DiemakerGrindingShapeSettings) this).CutType = CutTypes.CutHorizontal;
    ((DiemakerGrindingShapeSettings) this).isMilling = false;
    ((buCutter) this).pntEnd = new Point3D();
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    if (!(data is buShapeCut))
      return;
    ((buCutter) this).pntEnd = new Point3D(((buCutter) data).pntEnd.X, ((buCutter) data).pntEnd.Y, ((buCutter) data).pntEnd.Z);
  }

  public override string ToString()
  {
    string str = $"Slot | {((buClipperBase) this).planeName.ToString()} Dia: {((DiemakerGrindingShapeSettings) this).Diameter.ToString("f2")}Len: {((DiemakerGrindingShapeSettings) this).Length.ToString("f2")}";
    if (((DiemakerGrindingShapeSettings) this).Angle != 0.0)
      str = $"{str} , Angle: {((DiemakerGrindingShapeSettings) this).Angle.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018CE();

  public buSelectionPoint()
  {
    ((buCutter) this).Radius = 10.0;
    ((CutterIsoEntities) this).Length = 200.0;
    ((CutterIsoEntities) this).Width = 0.0;
    ((CutterIsoEntities) this).Height = 0.0;
    ((CutterIsoEntities) this).ProfilingType = ProfilingTypes.ProfilingRectangle;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Profiling;
  }

  public buSelectionPoint(
    ProfilingTypes profilingType,
    double radius,
    double depth,
    double length,
    double width,
    double height)
  {
    ((buCutter) this).Radius = 10.0;
    ((CutterIsoEntities) this).Length = 200.0;
    ((CutterIsoEntities) this).Width = 0.0;
    ((CutterIsoEntities) this).Height = 0.0;
    ((CutterIsoEntities) this).ProfilingType = ProfilingTypes.ProfilingRectangle;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buCutter) this).Radius = radius;
    ((CutterIsoEntities) this).Length = length;
    ((CutterIsoEntities) this).Width = width;
    ((CutterIsoEntities) this).Height = height;
    ((\u0012.\u0002) this).Depth = depth;
    ((CutterIsoEntities) this).ProfilingType = profilingType;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Profiling;
  }

  public buSelectionPoint(buShape data)
  {
    ((buCutter) this).Radius = 10.0;
    ((CutterIsoEntities) this).Length = 200.0;
    ((CutterIsoEntities) this).Width = 0.0;
    ((CutterIsoEntities) this).Height = 0.0;
    ((CutterIsoEntities) this).ProfilingType = ProfilingTypes.ProfilingRectangle;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    string str = $"Profiling | {((buClipperBase) this).planeName.ToString()} -";
    if (((CutterIsoEntities) this).ProfilingType == ProfilingTypes.ProfilingRectangle)
      str = $"{str} Width: {((CutterIsoEntities) this).Width.ToString("f2")} , Height: {((CutterIsoEntities) this).Height.ToString("f2")}";
    if (((CutterIsoEntities) this).ProfilingType == ProfilingTypes.ProfilingRound)
      str = $"{str} Radius: {((buCutter) this).Radius.ToString("f2")}";
    if (((CutterIsoEntities) this).ProfilingType == ProfilingTypes.ProfilingChamfer)
      str = $"{str} Len: {((CutterIsoEntities) this).Length.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018D3();

  public buSelectionPoint()
  {
    ((CutterIsoEntities) this).Width = 0.0;
    ((CutterIsoEntities) this).Height = 0.0;
    ((CutterIsoEntities) this).isFinish = false;
    ((CutterIsoEntities) this).entityMesh = (Entity) null;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Engraving;
  }

  public buSelectionPoint(double depth, double width, double height, Entity mesh)
  {
    ((CutterIsoEntities) this).Width = 0.0;
    ((CutterIsoEntities) this).Height = 0.0;
    ((CutterIsoEntities) this).isFinish = false;
    ((CutterIsoEntities) this).entityMesh = (Entity) null;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((CutterIsoEntities) this).Width = width;
    ((CutterIsoEntities) this).Height = height;
    ((\u0012.\u0002) this).Depth = depth;
    if (mesh != null)
      buRadialDim.Copy(mesh, ref ((CutterIsoEntities) this).entityMesh);
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Engraving;
  }

  public buSelectionPoint(buShape data)
  {
    ((CutterIsoEntities) this).Width = 0.0;
    ((CutterIsoEntities) this).Height = 0.0;
    ((CutterIsoEntities) this).isFinish = false;
    ((CutterIsoEntities) this).entityMesh = (Entity) null;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    if (!(data is buShapeEngrave) || ((CutterIsoEntities) data).entityMesh == null)
      return;
    buRadialDim.Copy(((CutterIsoEntities) data).entityMesh, ref ((CutterIsoEntities) this).entityMesh);
  }

  public override string ToString()
  {
    return $"{$"Engrave | {((buClipperBase) this).planeName.ToString()} -"} Width: {((CutterIsoEntities) this).Width.ToString("f2")} , Height: {((CutterIsoEntities) this).Height.ToString("f2")}";
  }

  public abstract void m0018D8();

  public buSelectionPoint()
  {
    ((CutterIsoFileSettings) this).Diameter = 10.0;
    ((CutterIsoFileSettings) this).DiameterOutside = 5.0;
    ((CutterIsoFileSettings) this).Distance = 40.0;
    ((CutterIsoFileItems) this).JunctionType = JunctionTypes.Junction3HoleIntersectHorizontal;
    ((CutterRuntimeSettings) this).isMilling = false;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Junction;
  }

  public buSelectionPoint(
    JunctionTypes junctionType,
    double diameter,
    double depth,
    double diameteroutside,
    double distance,
    bool ismilling)
  {
    ((CutterIsoFileSettings) this).Diameter = 10.0;
    ((CutterIsoFileSettings) this).DiameterOutside = 5.0;
    ((CutterIsoFileSettings) this).Distance = 40.0;
    ((CutterIsoFileItems) this).JunctionType = JunctionTypes.Junction3HoleIntersectHorizontal;
    ((CutterRuntimeSettings) this).isMilling = false;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((CutterIsoFileSettings) this).Diameter = diameter;
    ((CutterIsoFileSettings) this).DiameterOutside = diameteroutside;
    ((CutterIsoFileSettings) this).Distance = distance;
    ((CutterRuntimeSettings) this).isMilling = ismilling;
    ((\u0012.\u0002) this).Depth = depth;
    ((CutterIsoFileItems) this).JunctionType = junctionType;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Junction;
  }

  public buSelectionPoint(buShape data)
  {
    ((CutterIsoFileSettings) this).Diameter = 10.0;
    ((CutterIsoFileSettings) this).DiameterOutside = 5.0;
    ((CutterIsoFileSettings) this).Distance = 40.0;
    ((CutterIsoFileItems) this).JunctionType = JunctionTypes.Junction3HoleIntersectHorizontal;
    ((CutterRuntimeSettings) this).isMilling = false;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    string str = $"Junction | {((buClipperBase) this).planeName.ToString()} Dia: {((CutterIsoFileSettings) this).Diameter.ToString("f2")}Dis: {((CutterIsoFileSettings) this).Distance.ToString("f2")}";
    if (((CutterIsoFileItems) this).JunctionType == JunctionTypes.Junction2HoleNearByHorizontal | ((CutterIsoFileItems) this).JunctionType == JunctionTypes.Junction2HoleNearByVertical)
      str = $"{str} , Dia Outside: {((CutterIsoFileSettings) this).DiameterOutside.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018DD();

  public buSelectionPoint()
  {
    ((CutterRuntimeSettings) this).Width = 10.0;
    ((CutterProgramSettings) this).Height = 10.0;
    ((CutterProgramSettings) this).Angle = 0.0;
    ((CutterProgramSettings) this).TextString = "";
    ((CutterProgramSettings) this).isWire = false;
    ((CutterProgramSettings) this).TextFont = new Font("Arial", 10f);
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeType = ShapeTypes.Text;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Text;
  }

  public buSelectionPoint(double width, double height, string textString)
  {
    ((CutterRuntimeSettings) this).Width = 10.0;
    ((CutterProgramSettings) this).Height = 10.0;
    ((CutterProgramSettings) this).Angle = 0.0;
    ((CutterProgramSettings) this).TextString = "";
    ((CutterProgramSettings) this).isWire = false;
    ((CutterProgramSettings) this).TextFont = new Font("Arial", 10f);
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((CutterRuntimeSettings) this).Width = width;
    ((CutterProgramSettings) this).Height = height;
    ((CutterProgramSettings) this).TextString = textString;
    ((buClipperBase) this).ShapeType = ShapeTypes.Text;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Text;
  }

  public string Tags
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCAM) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXCAM) this).\u0001 = value;
  }

  public int CamID
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCAM) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXCAM) this).\u0001 = value;
  }

  public string SceneName
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCAM) this).\u0002;
    [CompilerGenerated, SpecialName] set => ((Router3AXCAM) this).\u0002 = value;
  }

  public string EntityName
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCAM) this).\u0003;
    [CompilerGenerated, SpecialName] set => ((Router3AXCAM) this).\u0003 = value;
  }

  public string ActionName
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCamPlane) this).\u0004;
    [CompilerGenerated, SpecialName] set => ((Router3AXCamPlane) this).\u0004 = value;
  }

  public int GroupIdIndex
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCamPlane) this).\u0002;
    [CompilerGenerated, SpecialName] set => ((Router3AXCamPlane) this).\u0002 = value;
  }

  public bool CamSelected
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCamPlane) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXCamPlane) this).\u0001 = value;
  }

  public double OrientationC
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCamPlane) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXCamPlane) this).\u0001 = value;
  }
}
