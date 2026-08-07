// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buLinearPathArrow
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buLinearPathArrow : LinearPath
{
  public const buEntityUpdateType None = ; // Unable to render the field
  public const buEntityUpdateType Point = ; // Unable to render the field
  public const buEntityUpdateType Line = ; // Unable to render the field
  public const buEntityUpdateType ArcCenterStartEnd = ; // Unable to render the field
  public const buEntityUpdateType ArcCenterRadiusSAEA = ; // Unable to render the field
  public const buEntityUpdateType ArcCenterStartEndPlane = ; // Unable to render the field
  public const buEntityUpdateType Arc3Point3D = ; // Unable to render the field
  public const buEntityUpdateType ArcCenterRadiusSAEAPlane = ; // Unable to render the field
  public const buEntityUpdateType Arc3Point2DPlane = ; // Unable to render the field

  public buLinearPathArrow(
    double headdiameter,
    double diameter,
    double length,
    double depth,
    double angle)
  {
    ((DiemakerGrindingShapeSettings) this).HeadDiameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Length = 6.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).HeadDiameter = headdiameter;
    ((DiemakerGrindingShapeSettings) this).Diameter = diameter;
    ((DiemakerGrindingShapeSettings) this).Length = length;
    ((\u0012.\u0002) this).Depth = depth;
    ((DiemakerGrindingShapeSettings) this).Angle = angle;
    ((buClipperBase) this).ShapeType = ShapeTypes.KeyHole;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buLinearPathArrow(buShape data)
  {
    ((DiemakerGrindingShapeSettings) this).HeadDiameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Length = 6.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
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
    string str = $"KeyHole | {((buClipperBase) this).planeName.ToString()} Len: {((DiemakerGrindingShapeSettings) this).Length.ToString()} , HeadDia: {((DiemakerGrindingShapeSettings) this).HeadDiameter.ToString("f2")} , Dia: {((DiemakerGrindingShapeSettings) this).Diameter.ToString("f2")}";
    if (((DiemakerGrindingShapeSettings) this).Angle != 0.0)
      str = $"{str} , Ang: {((DiemakerGrindingShapeSettings) this).Angle.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018AC();

  public buLinearPathArrow()
  {
    ((DiemakerGrindingShapeSettings) this).Width = 10.0;
    ((DiemakerGrindingShapeSettings) this).Height = 10.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeType = ShapeTypes.FreeDraw;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buLinearPathArrow(double width, double height)
  {
    ((DiemakerGrindingShapeSettings) this).Width = 10.0;
    ((DiemakerGrindingShapeSettings) this).Height = 10.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Width = width;
    ((DiemakerGrindingShapeSettings) this).Height = height;
    ((buClipperBase) this).ShapeType = ShapeTypes.FreeDraw;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buLinearPathArrow(double width, double height, double depth, double angle)
  {
    ((DiemakerGrindingShapeSettings) this).Width = 10.0;
    ((DiemakerGrindingShapeSettings) this).Height = 10.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Width = width;
    ((DiemakerGrindingShapeSettings) this).Height = height;
    ((\u0012.\u0002) this).Depth = depth;
    ((DiemakerGrindingShapeSettings) this).Angle = angle;
    ((buClipperBase) this).ShapeType = ShapeTypes.FreeDraw;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buLinearPathArrow(buShape data)
  {
    ((DiemakerGrindingShapeSettings) this).Width = 10.0;
    ((DiemakerGrindingShapeSettings) this).Height = 10.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
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
    buRadialDim.Copy(((buClipper) data).entitiesShape, ref ((buClipper) this).entitiesShape);
  }

  public override string ToString()
  {
    string str = $"Free Draw | {((buClipperBase) this).planeName.ToString()} Width: {((DiemakerGrindingShapeSettings) this).Width.ToString("f2")} , Height: {((DiemakerGrindingShapeSettings) this).Height.ToString("f2")}";
    if (((DiemakerGrindingShapeSettings) this).Angle != 0.0)
      str = $"{str} , Ang: {((DiemakerGrindingShapeSettings) this).Angle.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018B2();

  public buLinearPathArrow()
  {
    ((DiemakerGrindingShapeSettings) this).Width = 10.0;
    ((DiemakerGrindingShapeSettings) this).Height = 10.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeType = ShapeTypes.FreeDraw;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buLinearPathArrow(double width, double height)
  {
    ((DiemakerGrindingShapeSettings) this).Width = 10.0;
    ((DiemakerGrindingShapeSettings) this).Height = 10.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Width = width;
    ((DiemakerGrindingShapeSettings) this).Height = height;
    ((buClipperBase) this).ShapeType = ShapeTypes.FreeDraw;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buLinearPathArrow(double width, double height, double depth)
  {
    ((DiemakerGrindingShapeSettings) this).Width = 10.0;
    ((DiemakerGrindingShapeSettings) this).Height = 10.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Width = width;
    ((DiemakerGrindingShapeSettings) this).Height = height;
    ((\u0012.\u0002) this).Depth = depth;
    ((buClipperBase) this).ShapeType = ShapeTypes.FreeDraw;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buLinearPathArrow(buShape data)
  {
    ((DiemakerGrindingShapeSettings) this).Width = 10.0;
    ((DiemakerGrindingShapeSettings) this).Height = 10.0;
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
    buRadialDim.Copy(((buClipper) data).entitiesShape, ref ((buClipper) this).entitiesShape);
  }

  public override string ToString()
  {
    string str = $"Free Lines | {((buClipperBase) this).planeName.ToString()} Width: {((DiemakerGrindingShapeSettings) this).Width.ToString("f2")} , Height: {((DiemakerGrindingShapeSettings) this).Height.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018B8();

  public buLinearPathArrow()
  {
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).DrillType = drillTypes.SingleHole;
    ((DiemakerGrindingShapeSettings) this).isMilling = false;
    ((DiemakerGrindingShapeSettings) this).isTapping = false;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).DrillType = drillTypes.SingleHole;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Drill;
  }

  public buLinearPathArrow(double diameter)
  {
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).DrillType = drillTypes.SingleHole;
    ((DiemakerGrindingShapeSettings) this).isMilling = false;
    ((DiemakerGrindingShapeSettings) this).isTapping = false;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Diameter = diameter;
    ((DiemakerGrindingShapeSettings) this).DrillType = drillTypes.SingleHole;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Drill;
  }

  public buLinearPathArrow(double diameter, double depth)
  {
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).DrillType = drillTypes.SingleHole;
    ((DiemakerGrindingShapeSettings) this).isMilling = false;
    ((DiemakerGrindingShapeSettings) this).isTapping = false;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Diameter = diameter;
    ((\u0012.\u0002) this).Depth = depth;
    ((DiemakerGrindingShapeSettings) this).DrillType = drillTypes.SingleHole;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Drill;
  }

  public buLinearPathArrow(buShape data)
  {
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).DrillType = drillTypes.SingleHole;
    ((DiemakerGrindingShapeSettings) this).isMilling = false;
    ((DiemakerGrindingShapeSettings) this).isTapping = false;
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
    string str = $"Hole | {((buClipperBase) this).planeName.ToString()} Dia: {((DiemakerGrindingShapeSettings) this).Diameter.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    if (((DiemakerGrindingShapeSettings) this).isTapping)
      str += " , Tapping";
    return str;
  }

  public abstract void m0018BE();

  public buLinearPathArrow()
  {
    ((DiemakerGrindingShapeSettings) this).Count = 2;
    ((DiemakerGrindingShapeSettings) this).Distance = 32.0;
    ((DiemakerGrindingShapeSettings) this).StartDistance = 10.0;
    ((DiemakerGrindingShapeSettings) this).EndDistance = 10.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Drill;
  }

  public buLinearPathArrow(
    drillTypes type,
    double diameter,
    int count,
    double distance,
    double startdistance,
    double enddistance,
    double Angle = 0.0)
  {
    ((DiemakerGrindingShapeSettings) this).Count = 2;
    ((DiemakerGrindingShapeSettings) this).Distance = 32.0;
    ((DiemakerGrindingShapeSettings) this).StartDistance = 10.0;
    ((DiemakerGrindingShapeSettings) this).EndDistance = 10.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Diameter = diameter;
    ((DiemakerGrindingShapeSettings) this).Count = count;
    ((DiemakerGrindingShapeSettings) this).Distance = distance;
    ((DiemakerGrindingShapeSettings) this).StartDistance = startdistance;
    ((DiemakerGrindingShapeSettings) this).EndDistance = enddistance;
    ((DiemakerGrindingShapeSettings) this).DrillType = type;
    ((DiemakerGrindingShapeSettings) this).Angle = Angle;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Drill;
  }

  public buLinearPathArrow(
    drillTypes type,
    double diameter,
    int count,
    double distance,
    double startdistance,
    double enddistance,
    double depth,
    double Angle = 0.0)
  {
    ((DiemakerGrindingShapeSettings) this).Count = 2;
    ((DiemakerGrindingShapeSettings) this).Distance = 32.0;
    ((DiemakerGrindingShapeSettings) this).StartDistance = 10.0;
    ((DiemakerGrindingShapeSettings) this).EndDistance = 10.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Diameter = diameter;
    ((DiemakerGrindingShapeSettings) this).Count = count;
    ((\u0012.\u0002) this).Depth = depth;
    ((DiemakerGrindingShapeSettings) this).Distance = distance;
    ((DiemakerGrindingShapeSettings) this).StartDistance = startdistance;
    ((DiemakerGrindingShapeSettings) this).EndDistance = enddistance;
    ((DiemakerGrindingShapeSettings) this).DrillType = type;
    ((DiemakerGrindingShapeSettings) this).Angle = Angle;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Drill;
  }

  public buLinearPathArrow(buShape data)
  {
    ((DiemakerGrindingShapeSettings) this).Count = 2;
    ((DiemakerGrindingShapeSettings) this).Distance = 32.0;
    ((DiemakerGrindingShapeSettings) this).StartDistance = 10.0;
    ((DiemakerGrindingShapeSettings) this).EndDistance = 10.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    string str = $"Hole Multi | {((buClipperBase) this).planeName.ToString()} Dia: {((DiemakerGrindingShapeSettings) this).Diameter.ToString("f2")} Count: {((DiemakerGrindingShapeSettings) this).Count.ToString()} Dis: {((DiemakerGrindingShapeSettings) this).Distance.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018C4();

  public double DirArrowDistances
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCAM) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXCAM) this).\u0001 = value;
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
    [CompilerGenerated, SpecialName] get => ((Router3AXCAM) this).\u0004;
    [CompilerGenerated, SpecialName] set => ((Router3AXCAM) this).\u0004 = value;
  }

  public int GroupIdIndex
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCAM) this).\u0002;
    [CompilerGenerated, SpecialName] set => ((Router3AXCAM) this).\u0002 = value;
  }

  public int RefEntity
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCAM) this).\u0003;
    [CompilerGenerated, SpecialName] set => ((Router3AXCAM) this).\u0003 = value;
  }

  public Point3D infoBasePoint
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCAM) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXCAM) this).\u0001 = value;
  }
}
