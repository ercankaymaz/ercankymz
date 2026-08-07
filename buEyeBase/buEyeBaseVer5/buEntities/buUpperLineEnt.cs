// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buUpperLineEnt
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.ClassViewer;
using buEyeBaseVer5.Flexo;
using devDept.Eyeshot.Entities;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buUpperLineEnt : Line
{
  public int DecimalPlace;
  public object Value;
  private object \u0001;
  private IContainer \u0001;
  internal buClassViewer5 \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public static byte f003807;
  public static double EntityRegenDeviation;
  public static byte f003809;
  [SpecialName]
  public int value__;

  public buUpperLineEnt(
    double width,
    double height,
    double radius,
    double chamfer,
    double depth,
    double angle)
  {
    ((ClipperOffset) this).Width = 10.0;
    ((ClipperOffset) this).Height = 10.0;
    ((ClipperOffset) this).Angle = 0.0;
    ((ClipperOffset) this).Radius = 0.0;
    ((ClipperOffset) this).Chamfer = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((ClipperOffset) this).Width = width;
    ((ClipperOffset) this).Height = height;
    ((ClipperOffset) this).Radius = radius;
    ((ClipperOffset) this).Chamfer = chamfer;
    ((\u0012.\u0002) this).Depth = depth;
    ((ClipperOffset) this).Angle = angle;
    ((buClipperBase) this).ShapeType = ShapeTypes.Rectangle;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(buShape data)
  {
    ((ClipperOffset) this).Width = 10.0;
    ((ClipperOffset) this).Height = 10.0;
    ((ClipperOffset) this).Angle = 0.0;
    ((ClipperOffset) this).Radius = 0.0;
    ((ClipperOffset) this).Chamfer = 0.0;
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
    string str = $"Rectangle | {((buClipperBase) this).planeName.ToString()} Width: {((ClipperOffset) this).Width.ToString("f2")} , Height: {((ClipperOffset) this).Height.ToString("f2")}";
    if (((ClipperOffset) this).Radius > 0.0)
      str = $"{str} , Rad: {((ClipperOffset) this).Radius.ToString("f2")}";
    if (((ClipperOffset) this).Chamfer > 0.0)
      str = $"{str} , Chamfer: {((ClipperOffset) this).Chamfer.ToString("f2")}";
    if (((ClipperOffset) this).Angle != 0.0)
      str = $"{str} , Ang: {((ClipperOffset) this).Angle.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public string ToStr()
  {
    string str = $"Rectangle | {((buClipperBase) this).planeName.ToString()} Width: {((ClipperOffset) this).Width.ToString("f2")} , Height: {((ClipperOffset) this).Height.ToString("f2")}";
    if (((ClipperOffset) this).Radius > 0.0)
      str = $"{str} , Rad: {((ClipperOffset) this).Radius.ToString("f2")}";
    if (((ClipperOffset) this).Chamfer > 0.0)
      str = $"{str} , Chamfer: {((ClipperOffset) this).Chamfer.ToString("f2")}";
    if (((ClipperOffset) this).Angle != 0.0)
      str = $"{str} , Ang: {((ClipperOffset) this).Angle.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m00188E();

  public buUpperLineEnt()
  {
    ((ClipperOffset) this).Radius = 10.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeType = ShapeTypes.Circle;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(double radius)
  {
    ((ClipperOffset) this).Radius = 10.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((ClipperOffset) this).Radius = radius;
    ((buClipperBase) this).ShapeType = ShapeTypes.Circle;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(double radius, double depth)
  {
    ((ClipperOffset) this).Radius = 10.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((ClipperOffset) this).Radius = radius;
    ((\u0012.\u0002) this).Depth = depth;
    ((buClipperBase) this).ShapeType = ShapeTypes.Circle;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(buShape data)
  {
    ((ClipperOffset) this).Radius = 10.0;
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
    string str = $"Circle | {((buClipperBase) this).planeName.ToString()} Rad: {((ClipperOffset) this).Radius.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m001894();

  public buUpperLineEnt()
  {
    ((ClipperOffset) this).RadiusX = 10.0;
    ((ClipperOffset) this).RadiusY = 10.0;
    ((ClipperOffset) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeType = ShapeTypes.Ellipse;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(double radiusx, double radiusy)
  {
    ((ClipperOffset) this).RadiusX = 10.0;
    ((ClipperOffset) this).RadiusY = 10.0;
    ((ClipperOffset) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((ClipperOffset) this).RadiusX = radiusx;
    ((ClipperOffset) this).RadiusY = radiusy;
    ((buClipperBase) this).ShapeType = ShapeTypes.Ellipse;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(double radiusx, double radiusy, double depth, double angle)
  {
    ((ClipperOffset) this).RadiusX = 10.0;
    ((ClipperOffset) this).RadiusY = 10.0;
    ((ClipperOffset) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((ClipperOffset) this).RadiusX = radiusx;
    ((ClipperOffset) this).RadiusY = radiusy;
    ((\u0012.\u0002) this).Depth = depth;
    ((ClipperOffset) this).Angle = angle;
    ((buClipperBase) this).ShapeType = ShapeTypes.Ellipse;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(buShape data)
  {
    ((ClipperOffset) this).RadiusX = 10.0;
    ((ClipperOffset) this).RadiusY = 10.0;
    ((ClipperOffset) this).Angle = 0.0;
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
    string str = $"Ellipse | {((buClipperBase) this).planeName.ToString()} XRad: {((ClipperOffset) this).RadiusX.ToString("f2")} , YRad: {((ClipperOffset) this).RadiusY.ToString("f2")}";
    if (((ClipperOffset) this).Angle != 0.0)
      str = $"{str} , Ang: {((ClipperOffset) this).Angle.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m00189A();

  public buUpperLineEnt()
  {
    ((ClipperOffset) this).Radius = 10.0;
    ((buFlexoCalc) this).Side = 6;
    ((buDiamakerCalc) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeType = ShapeTypes.Polygon;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(double radius, int side)
  {
    ((ClipperOffset) this).Radius = 10.0;
    ((buFlexoCalc) this).Side = 6;
    ((buDiamakerCalc) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((ClipperOffset) this).Radius = radius;
    ((buFlexoCalc) this).Side = side;
    ((buClipperBase) this).ShapeType = ShapeTypes.Polygon;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(double radius, int side, double depth, double angle)
  {
    ((ClipperOffset) this).Radius = 10.0;
    ((buFlexoCalc) this).Side = 6;
    ((buDiamakerCalc) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((ClipperOffset) this).Radius = radius;
    ((buFlexoCalc) this).Side = side;
    ((\u0012.\u0002) this).Depth = depth;
    ((buDiamakerCalc) this).Angle = angle;
    ((buClipperBase) this).ShapeType = ShapeTypes.Polygon;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(buShape data)
  {
    ((ClipperOffset) this).Radius = 10.0;
    ((buFlexoCalc) this).Side = 6;
    ((buDiamakerCalc) this).Angle = 0.0;
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
    string str = $"Polygon | {((buClipperBase) this).planeName.ToString()} Side: {((buFlexoCalc) this).Side.ToString()} , Rad: {((ClipperOffset) this).Radius.ToString("f2")}";
    if (((buDiamakerCalc) this).Angle != 0.0)
      str = $"{str} , Ang: {((buDiamakerCalc) this).Angle.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018A0();

  public buUpperLineEnt()
  {
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Length = 6.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeType = ShapeTypes.Slot;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(double diameter, double length)
  {
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Length = 6.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Diameter = diameter;
    ((DiemakerGrindingShapeSettings) this).Length = length;
    ((buClipperBase) this).ShapeType = ShapeTypes.Slot;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(double diameter, double length, double depth, double angle)
  {
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Length = 6.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((DiemakerGrindingShapeSettings) this).Diameter = diameter;
    ((DiemakerGrindingShapeSettings) this).Length = length;
    ((DiemakerGrindingShapeSettings) this).Angle = angle;
    ((\u0012.\u0002) this).Depth = depth;
    ((buClipperBase) this).ShapeType = ShapeTypes.Slot;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(buShape data)
  {
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
    string str = $"Slot | {((buClipperBase) this).planeName.ToString()} Len: {((DiemakerGrindingShapeSettings) this).Length.ToString()} , Dia: {((DiemakerGrindingShapeSettings) this).Diameter.ToString("f2")}";
    if (((DiemakerGrindingShapeSettings) this).Angle != 0.0)
      str = $"{str} , Ang: {((DiemakerGrindingShapeSettings) this).Angle.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018A6();

  public buUpperLineEnt()
  {
    ((DiemakerGrindingShapeSettings) this).HeadDiameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Diameter = 10.0;
    ((DiemakerGrindingShapeSettings) this).Length = 6.0;
    ((DiemakerGrindingShapeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeType = ShapeTypes.KeyHole;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buUpperLineEnt(double headdiameter, double diameter, double length)
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
    ((buClipperBase) this).ShapeType = ShapeTypes.KeyHole;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public double DirArrowDistances
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXItem) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXItem) this).\u0001 = value;
  }

  public double infoLength
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXItem) this).\u0002;
    [CompilerGenerated, SpecialName] set => ((Router3AXItem) this).\u0002 = value;
  }

  public double infoAngle
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXItem) this).\u0003;
    [CompilerGenerated, SpecialName] set => ((Router3AXItem) this).\u0003 = value;
  }

  public entitySortDirection sortDirection
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXItem) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXItem) this).\u0001 = value;
  }

  public string Tags
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXItem) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXItem) this).\u0001 = value;
  }

  public int CamID
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXItem) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXItem) this).\u0001 = value;
  }

  public string SceneName
  {
    [CompilerGenerated, SpecialName] get => (^(Router3AXItem&) ref this).\u0002;
    [CompilerGenerated, SpecialName] set => (^(Router3AXItem&) ref this).\u0002 = value;
  }

  public string EntityName
  {
    [CompilerGenerated, SpecialName] get => (^(Router3AXItem&) ref this).\u0003;
    [CompilerGenerated, SpecialName] set => (^(Router3AXItem&) ref this).\u0003 = value;
  }

  public string ActionName
  {
    [CompilerGenerated, SpecialName] get => (^(Router3AXCAM&) ref this).\u0004;
    [CompilerGenerated, SpecialName] set => (^(Router3AXCAM&) ref this).\u0004 = value;
  }

  public int GroupIdIndex
  {
    [CompilerGenerated, SpecialName] get => (^(Router3AXCAM&) ref this).\u0002;
    [CompilerGenerated, SpecialName] set => (^(Router3AXCAM&) ref this).\u0002 = value;
  }

  public bool CamSelected
  {
    [CompilerGenerated, SpecialName] get => (^(Router3AXCAM&) ref this).\u0001;
    [CompilerGenerated, SpecialName] set => (^(Router3AXCAM&) ref this).\u0001 = value;
  }
}
