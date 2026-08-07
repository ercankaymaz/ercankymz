// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.CustomData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class CustomData
{
  public const buEntityUpdateType LinearPath = ; // Unable to render the field
  public const buEntityUpdateType UpperLine = ; // Unable to render the field
  public const buEntityUpdateType EllipseCenterRadius = ; // Unable to render the field
  public const buEntityUpdateType EllipseCenterRadiusPlane = ; // Unable to render the field
  public const buEntityUpdateType EllipseCenter2DRadiusPlane = ; // Unable to render the field
  public const buEntityUpdateType EllipseDerivate = ; // Unable to render the field
  public const buEntityUpdateType CurveControlPoint = ; // Unable to render the field
  public const buEntityUpdateType CurveControlPoint4D = ; // Unable to render the field
  public const buEntityUpdateType CurveDerivate = ; // Unable to render the field
  public const buEntityUpdateType CompositeCurveCurveList = ; // Unable to render the field
  public const buEntityUpdateType CompositeCurveCurveListSort = ; // Unable to render the field
  public const buEntityUpdateType CompositeCurveCurveListClosure = ; // Unable to render the field
  public const buEntityUpdateType CompositeCurveCurveListSortClosure = ; // Unable to render the field
  public const buEntityUpdateType CompositeCurveDerivate = ; // Unable to render the field
  public const buEntityUpdateType LinePlane = ; // Unable to render the field
  public const buEntityUpdateType LinearPathPlane = ; // Unable to render the field
  public const buEntityUpdateType MeshVerticeTriangleIndices = ; // Unable to render the field
  public const buEntityUpdateType RegionCurveList = ; // Unable to render the field
  public const buEntityUpdateType RegionCurveListSort = ; // Unable to render the field
  public const buEntityUpdateType RegionCurveListClosure = ; // Unable to render the field
  public const buEntityUpdateType RegionCurveListSortClosure = ; // Unable to render the field
  public const buEntityUpdateType RegionDerivate = ; // Unable to render the field
  public const buEntityUpdateType LinearDim = ; // Unable to render the field
  public const buEntityUpdateType AngularDim = ; // Unable to render the field
  public const buEntityUpdateType DiametricDim = ; // Unable to render the field
  public const buEntityUpdateType OrdinateDim = ; // Unable to render the field
  public const buEntityUpdateType RadialDim = ; // Unable to render the field
  public const buEntityUpdateType Text = ; // Unable to render the field
  public const buEntityUpdateType TextStyle = ; // Unable to render the field
  public const buEntityUpdateType MultilineText = ; // Unable to render the field
  public const buEntityUpdateType MultilineTextStyle = ; // Unable to render the field
  public Point3D BoxMax;
  public Point3D BoxMin;
  public Point3D StartPoint;
  public Point3D MiddlePoint;
  public Point3D EndPoint;
  public EntityShapeInfo Shape;
  public EntityInfo Info;
  public CutterInfo Cutter;
  public SewingInfo Sewing;
  public MarbleInfo Marble;
  public DimensionInfo Dimension;
  public entitySortDirection sortDirection;

  public override string ToString()
  {
    string str = $"Text | {((buClipperBase) this).planeName.ToString()} Text: {((CutterProgramSettings) this).TextString.ToString()} , Width: {((CutterRuntimeSettings) this).Width.ToString("f2")} , Height: {((CutterProgramSettings) this).Height.ToString("f2")}";
    if (((CutterProgramSettings) this).Angle != 0.0)
      str = $"{str} , Ang: {((CutterProgramSettings) this).Angle.ToString("f2")}";
    if (((\u0012.\u0002) this).Depth != 0.0)
      str = $"{str} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}";
    return str;
  }

  public abstract void m0018E3();

  public CustomData()
  {
    ((CutterProgramSettings) this).NotchWidth = 10.0;
    ((CutterProgramSettings) this).NotchHeight = 10.0;
    ((CutterProgramSettings) this).NotchStartHeight = 0.0;
    ((CutterProgramSettings) this).NotchAngle = 0.0;
    ((CutterProgramSettings) this).NotchUpDown = UpDownLocationType.Up;
    ((CutterProgramSettings) this).NotchFrontBack = FrontBackType.Front;
    ((CutterProgramSettings) this).NotchLocation = ProfileNotchLocationType.Left;
    ((CutterProgramSettings) this).NotchOPType = ProfileNotchOperationType.Side;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Notch;
  }

  public CustomData(
    double width,
    double height,
    double startheight,
    double depth,
    UpDownLocationType updown,
    ProfileNotchLocationType location,
    ProfileNotchOperationType NotchOpType,
    FrontBackType frontback)
  {
    ((CutterProgramSettings) this).NotchWidth = 10.0;
    ((CutterProgramSettings) this).NotchHeight = 10.0;
    ((CutterProgramSettings) this).NotchStartHeight = 0.0;
    ((CutterProgramSettings) this).NotchAngle = 0.0;
    ((CutterProgramSettings) this).NotchUpDown = UpDownLocationType.Up;
    ((CutterProgramSettings) this).NotchFrontBack = FrontBackType.Front;
    ((CutterProgramSettings) this).NotchLocation = ProfileNotchLocationType.Left;
    ((CutterProgramSettings) this).NotchOPType = ProfileNotchOperationType.Side;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((CutterProgramSettings) this).NotchWidth = width;
    ((CutterProgramSettings) this).NotchHeight = height;
    ((CutterProgramSettings) this).NotchStartHeight = startheight;
    ((CutterProgramSettings) this).NotchUpDown = updown;
    ((CutterProgramSettings) this).NotchLocation = location;
    ((\u0012.\u0002) this).Depth = depth;
    ((CutterProgramSettings) this).NotchOPType = NotchOpType;
    ((CutterProgramSettings) this).NotchFrontBack = frontback;
  }

  public CustomData(buShape data)
  {
    ((CutterProgramSettings) this).NotchWidth = 10.0;
    ((CutterProgramSettings) this).NotchHeight = 10.0;
    ((CutterProgramSettings) this).NotchStartHeight = 0.0;
    ((CutterProgramSettings) this).NotchAngle = 0.0;
    ((CutterProgramSettings) this).NotchUpDown = UpDownLocationType.Up;
    ((CutterProgramSettings) this).NotchFrontBack = FrontBackType.Front;
    ((CutterProgramSettings) this).NotchLocation = ProfileNotchLocationType.Left;
    ((CutterProgramSettings) this).NotchOPType = ProfileNotchOperationType.Side;
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
    return $"{$"{$"{((CutterProgramSettings) this).NotchOPType.ToString()} - Width: {((CutterProgramSettings) this).NotchWidth.ToString("f2")} , Height: {((CutterProgramSettings) this).NotchHeight.ToString("f2")} , Depth: {((\u0012.\u0002) this).Depth.ToString("f2")}"} , Location: {((CutterProgramSettings) this).NotchLocation.ToString()}"} , UpDown: {((CutterProgramSettings) this).NotchUpDown.ToString()}";
  }

  public abstract void m0018E8();

  public CustomData()
  {
    ((CutterProgramSettings) this).colorHole = (ColorType) new CircularSpeedReduction(Color.Blue, 220);
    ((CutterProgramSettings) this).colorShape = (ColorType) new CircularSpeedReduction(Color.Orange, 220);
    ((CutterProgramSettings) this).colorCut = (ColorType) new CircularSpeedReduction(Color.Green, 220);
    ((CutterProgramSettings) this).colorProfiling = (ColorType) new CircularSpeedReduction(Color.Cyan, 220);
    ((CutterProgramSettings) this).colorJunktion = (ColorType) new CircularSpeedReduction(Color.Purple, 220);
    ((CutterProgramSettings) this).colorEngraving = (ColorType) new CircularSpeedReduction(Color.Silver, 220);
    ((CutterProgramSettings) this).colorText = (ColorType) new CircularSpeedReduction(Color.Magenta, 220);
    ((CutterProgramSettings) this).colorOnline = (ColorType) new CircularSpeedReduction(Color.Lime, 220);
    ((CutterProgramSettings) this).colorOperation = (ColorType) new CircularSpeedReduction(Color.Pink, 220);
    ((CutterProgramSettings) this).colorOperationSelected = (ColorType) new CircularSpeedReduction(Color.Gold, 220);
    ((CutterProgramSettings) this).colorOperationDisable = (ColorType) new CircularSpeedReduction(Color.MediumVioletRed, 220);
    ((CutterProgramSettings) this).colorOperationDisableSelected = (ColorType) new CircularSpeedReduction(Color.DarkGray, 220);
    ((CutterProgramSettings) this).colorCam = (ColorType) new CircularSpeedReduction(Color.Red, (int) byte.MaxValue);
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public CustomData(buShapeVisualition data)
  {
    ((CutterProgramSettings) this).colorHole = (ColorType) new CircularSpeedReduction(Color.Blue, 220);
    ((CutterProgramSettings) this).colorShape = (ColorType) new CircularSpeedReduction(Color.Orange, 220);
    ((CutterProgramSettings) this).colorCut = (ColorType) new CircularSpeedReduction(Color.Green, 220);
    ((CutterProgramSettings) this).colorProfiling = (ColorType) new CircularSpeedReduction(Color.Cyan, 220);
    ((CutterProgramSettings) this).colorJunktion = (ColorType) new CircularSpeedReduction(Color.Purple, 220);
    ((CutterProgramSettings) this).colorEngraving = (ColorType) new CircularSpeedReduction(Color.Silver, 220);
    ((CutterProgramSettings) this).colorText = (ColorType) new CircularSpeedReduction(Color.Magenta, 220);
    ((CutterProgramSettings) this).colorOnline = (ColorType) new CircularSpeedReduction(Color.Lime, 220);
    ((CutterProgramSettings) this).colorOperation = (ColorType) new CircularSpeedReduction(Color.Pink, 220);
    ((CutterProgramSettings) this).colorOperationSelected = (ColorType) new CircularSpeedReduction(Color.Gold, 220);
    ((CutterProgramSettings) this).colorOperationDisable = (ColorType) new CircularSpeedReduction(Color.MediumVioletRed, 220);
    ((CutterProgramSettings) this).colorOperationDisableSelected = (ColorType) new CircularSpeedReduction(Color.DarkGray, 220);
    ((CutterProgramSettings) this).colorCam = (ColorType) new CircularSpeedReduction(Color.Red, (int) byte.MaxValue);
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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

  public CustomData(CompositeCurve another)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((CompositeCurve) this).\u002Ector(another);
    if (!(another is buCompositeCurveCam))
      return;
    this.set_MoveType(((CustomData) another).get_MoveType());
    this.set_DirArrowDistances(((CustomData) another).get_DirArrowDistances());
    this.set_CamID(((CustomData) another).get_CamID());
  }

  public CustomData(IEnumerable<ICurve> curveList)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((CompositeCurve) this).\u002Ector(curveList);
  }

  public CustomData(params ICurve[] curveList)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((CompositeCurve) this).\u002Ector(curveList);
  }

  public CustomData(ICurve curve)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((CompositeCurve) this).\u002Ector(curve);
  }

  public CustomData(IEnumerable<ICurve> curveList, bool sortAndOrient)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((CompositeCurve) this).\u002Ector(curveList, sortAndOrient);
  }

  public CustomData(IEnumerable<ICurve> curveList, double closureTol)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((CompositeCurve) this).\u002Ector(curveList, closureTol);
  }

  public CustomData(IEnumerable<ICurve> curveList, double closureTol, bool sortAndOrient)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((CompositeCurve) this).\u002Ector(curveList, closureTol, sortAndOrient);
  }

  public override string ToString()
  {
    // ISSUE: explicit non-virtual call
    // ISSUE: explicit non-virtual call
    return $"CompositeCurveCam : {__nonvirtual (((CompositeCurve) this).StartPoint).ToString()} - {__nonvirtual (((CompositeCurve) this).EndPoint).ToString()} - {((CompositeCurve) this).CurveList.Count.ToString()}";
  }

  [CompilerGenerated]
  [SpecialName]
  public double get_DirArrowDistances() => ((CutterProgramSettings) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_DirArrowDistances(double value) => ((CutterProgramSettings) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public CamMoveType get_MoveType() => ((CutterProgramSettings) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_MoveType(CamMoveType value) => ((CutterProgramSettings) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_CamID() => ((CutterProgramSettings) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamID(int value) => ((CutterProgramSettings) this).\u0001 = value;

  public abstract void m0018F9();

  public CustomData(devDept.Eyeshot.Entities.LinearPath another)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamLinkType.NotALink;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((devDept.Eyeshot.Entities.LinearPath) this).\u002Ector(another);
    if (!(another is buLinearPathCam))
      return;
    this.set_MoveType(((CustomData) another).get_MoveType());
    this.set_DirArrowDistances(((CustomData) another).get_DirArrowDistances());
    this.set_CamID(((CustomData) another).get_CamID());
    this.set_isLink(((CustomData) another).get_isLink());
    this.set_LinkType(((CustomData) another).get_LinkType());
  }

  public CustomData(List<Point3D> points)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamLinkType.NotALink;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((devDept.Eyeshot.Entities.LinearPath) this).\u002Ector((ICollection<Point3D>) points);
  }

  public CustomData(params Point3D[] points)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamLinkType.NotALink;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((devDept.Eyeshot.Entities.LinearPath) this).\u002Ector(points);
  }

  public CustomData(Point2D min, Point2D max)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamLinkType.NotALink;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((devDept.Eyeshot.Entities.LinearPath) this).\u002Ector(min, max);
  }

  public CustomData(Plane sketchPlane, params Point2D[] points)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamLinkType.NotALink;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((devDept.Eyeshot.Entities.LinearPath) this).\u002Ector(sketchPlane, points);
  }

  public CustomData(double width, double height)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamLinkType.NotALink;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((devDept.Eyeshot.Entities.LinearPath) this).\u002Ector(width, height);
  }

  public CustomData(Plane plane, Point2D min, Point2D max)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamLinkType.NotALink;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((devDept.Eyeshot.Entities.LinearPath) this).\u002Ector(plane, min, max);
  }

  public CustomData(double x, double y, double width, double height)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamLinkType.NotALink;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((devDept.Eyeshot.Entities.LinearPath) this).\u002Ector(x, y, width, height);
  }

  public CustomData(Plane plane, double x, double y, double width, double height)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterProgramSettings) this).\u0001 = CamLinkType.NotALink;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((devDept.Eyeshot.Entities.LinearPath) this).\u002Ector(plane, x, y, width, height);
  }

  public override string ToString()
  {
    // ISSUE: explicit non-virtual call
    // ISSUE: explicit non-virtual call
    string str = $"LPCam : {__nonvirtual (((devDept.Eyeshot.Entities.LinearPath) this).StartPoint).ToString()} - {__nonvirtual (((devDept.Eyeshot.Entities.LinearPath) this).EndPoint).ToString()} - {this.get_MoveType().ToString()} - Cnt: {((Entity) this).Vertices.Length.ToString()}";
    if (this.get_isLink())
      str = $"{str} Link: {this.get_LinkType().ToString()}";
    return str;
  }

  [CompilerGenerated]
  [SpecialName]
  public double get_DirArrowDistances() => ((CutterProgramSettings) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_DirArrowDistances(double value) => ((CutterProgramSettings) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public CamMoveType get_MoveType() => ((CutterProgramSettings) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_MoveType(CamMoveType value) => ((CutterProgramSettings) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public CamLinkType get_LinkType() => ((CutterProgramSettings) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_LinkType(CamLinkType value) => ((CutterProgramSettings) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public bool get_isLink() => ((CutterNotch) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_isLink(bool value) => ((CutterNotch) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_CamID() => ((CutterNotch) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamID(int value) => ((CutterNotch) this).\u0001 = value;

  public abstract void m00190E();

  public CustomData(Arc another)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(another);
    if (!(another is buArcCam))
      return;
    this.set_MoveType(((CustomData) another).get_MoveType());
    this.set_DirArrowDistances(((CustomData) another).get_DirArrowDistances());
    this.set_CamID(((CustomData) another).get_CamID());
    this.set_isReverse(((CustomData) another).get_isReverse());
  }

  public CustomData(Point3D center, double radius, double angleInRadians)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(center, radius, angleInRadians);
  }

  public CustomData(Point3D center, Point3D start, Point3D end)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(center, start, end);
  }

  public CustomData(Plane arcPlane, Point3D center, double radius, double angleInRadians)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(arcPlane, center, radius, angleInRadians);
  }

  public CustomData(
    Point3D center,
    double radius,
    double startAngleInRadians,
    double endAngleInRadians)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(center, radius, startAngleInRadians, endAngleInRadians);
  }

  public CustomData(Plane arcPlane, Point2D center, Point2D start, Point2D end)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(arcPlane, center, start, end);
  }

  public CustomData(Point3D first, Point3D second, Point3D third, bool flip)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(first, second, third, flip);
  }

  public CustomData(
    Plane arcPlane,
    Point3D center,
    double radius,
    double startAngleInRadians,
    double endAngleInRadians)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(arcPlane, center, radius, startAngleInRadians, endAngleInRadians);
  }

  public CustomData(
    Plane arcPlane,
    Point2D center,
    double radius,
    double startAngleInRadians,
    double endAngleInRadians)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(arcPlane, center, radius, startAngleInRadians, endAngleInRadians);
  }

  public CustomData(Plane arcPlane, Point2D first, Point2D second, Point2D third, bool flip)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(arcPlane, first, second, third, flip);
  }

  public CustomData(
    double x,
    double y,
    double z,
    double radius,
    double startAngleInRadians,
    double endAngleInRadians)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(x, y, z, radius, startAngleInRadians, endAngleInRadians);
  }

  public CustomData(
    Plane arcPlane,
    Point3D center,
    double radius,
    Point3D start,
    Point3D end,
    bool flip)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = false;
    // ISSUE: explicit constructor call
    ((Arc) this).\u002Ector(arcPlane, center, radius, start, end, flip);
  }

  public override string ToString()
  {
    return $"ArcCam : {((Circle) this).StartPoint.ToString()} - {((Circle) this).EndPoint.ToString()} - {this.get_MoveType().ToString()}";
  }

  [CompilerGenerated]
  [SpecialName]
  public double get_DirArrowDistances() => ((CutterNotch) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_DirArrowDistances(double value) => ((CutterNotch) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public CamMoveType get_MoveType() => ((CutterNotch) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_MoveType(CamMoveType value) => ((CutterNotch) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_CamID() => ((CutterNotch) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamID(int value) => ((CutterNotch) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public bool get_isReverse() => ((CutterNotch) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_isReverse(bool value) => ((CutterNotch) this).\u0001 = value;

  public abstract void m001924();

  public CustomData(Line another)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(another);
    if (!(another is buLineCam))
      return;
    this.set_MoveType(((CustomData) another).get_MoveType());
    this.set_DirArrowDistances(((CustomData) another).get_DirArrowDistances());
    this.set_CamID(((CustomData) another).get_CamID());
  }

  public CustomData(Segment2D seg)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(seg);
  }

  public CustomData(Segment3D seg)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(seg);
  }

  public CustomData(Point3D start, Point3D end)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(start, end);
  }

  public CustomData(Plane sketchPlane, Point2D startPoint, Point2D endPoint)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(sketchPlane, startPoint, endPoint);
  }

  public CustomData(double x1, double y1, double x2, double y2)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(x1, y1, x2, y2);
  }

  public CustomData(Plane sketchPlane, double x1, double y1, double x2, double y2)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(sketchPlane, x1, y1, x2, y2);
  }

  public CustomData(double x1, double y1, double z1, double x2, double y2, double z2)
  {
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = 200.0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = CamMoveType.G0;
    // ISSUE: reference to a compiler-generated field
    ((CutterNotch) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(x1, y1, z1, x2, y2, z2);
  }

  public override string ToString()
  {
    // ISSUE: explicit non-virtual call
    // ISSUE: explicit non-virtual call
    return $"LineCam : {__nonvirtual (((Line) this).StartPoint).ToString()} - {__nonvirtual (((Line) this).EndPoint).ToString()} - {this.get_MoveType().ToString()}";
  }

  [CompilerGenerated]
  [SpecialName]
  public double get_DirArrowDistances() => ((CutterNotch) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_DirArrowDistances(double value) => ((CutterNotch) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public CamMoveType get_MoveType() => ((CutterNotch) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_MoveType(CamMoveType value) => ((CutterNotch) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_CamID() => ((CutterNotch) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamID(int value) => ((CutterNotch) this).\u0001 = value;

  public abstract void m001934();

  public CustomData(string blockName)
  {
    ((CutterNotch) this).xPos = 0.0;
    ((CutterNotchType) this).yPos = 0.0;
    ((CutterNotchType) this).zPos = 0.0;
    ((CutterNotchType) this).aPos = 0.0;
    ((buToolGrindingCalc) this).bPos = 0.0;
    ((buToolGrindingCalc) this).cPos = 0.0;
    ((ToolGrindingJob) this).xRot = 0.0;
    ((ToolGrindingJob) this).yRot = 0.0;
    ((ToolGrindingJob) this).zRot = 0.0;
    ((ToolGrindingRuntimeSettings) this).centerPointOfA = (Point3D) null;
    ((ToolGrindingRuntimeSettings) this).centerPointOfB = (Point3D) null;
    ((buRollerBendCalc) this).centerPointOfC = (Point3D) null;
    ((buRollerBendCalc) this).ARotation = false;
    ((RollerJob) this).BRotation = false;
    ((RollerJob) this).CRotation = false;
    ((RollerJob) this).AnglesInRadian = false;
    ((RollerJob) this).No = -1;
    ((RollerJob) this).HeadNumber = 1;
    // ISSUE: explicit constructor call
    ((BlockReference) this).\u002Ector(0.0, 0.0, 0.0, blockName, 1.0, 1.0, 1.0, 0.0);
  }

  protected virtual void Animate(int frameNumber)
  {
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Entity) this).Animate(frameNumber));
  }

  public virtual void Rotate(double angleInRadians, Vector3D axis, Point3D center)
  {
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Entity) this).Rotate(angleInRadians, axis, center));
  }

  public virtual void MoveTo(DrawParams data)
  {
    // ISSUE: explicit non-virtual call
    __nonvirtual (((BlockReference) this).MoveTo(data));
    double num1 = ((CutterNotch) this).xPos;
    double num2 = ((CutterNotchType) this).yPos;
    double num3 = ((CutterNotchType) this).zPos;
    if (((RollerJob) this).CRotation)
    {
      double angleInRadians = Utility.DegToRad(((buToolGrindingCalc) this).cPos);
      if (((RollerJob) this).AnglesInRadian)
        angleInRadians = ((buToolGrindingCalc) this).cPos;
      if (((buRollerBendCalc) this).centerPointOfC == (Point3D) null)
        ((RollerJob) this).\u0001 = Transformation.CreateRotation(angleInRadians, new Vector3D(0.0, 0.0, 1.0), new Point3D(((ToolGrindingJob) this).xRot, ((ToolGrindingJob) this).yRot, ((ToolGrindingJob) this).zRot));
      else
        ((RollerJob) this).\u0001 = Transformation.CreateRotation(angleInRadians, new Vector3D(0.0, 0.0, 1.0), ((buRollerBendCalc) this).centerPointOfC);
      data.RenderContext.MultMatrixModelView(((RollerJob) this).\u0001);
      Point3D point3D = new Point3D(num1, num2, num3);
      point3D.TransformBy(Transformation.CreateRotation(Utility.DegToRad(-((buToolGrindingCalc) this).cPos), new Vector3D(0.0, 0.0, 1.0), new Point3D(0.0, 0.0, 0.0)));
      num1 = point3D.X;
      num2 = point3D.Y;
      num3 = point3D.Z;
    }
    if (((RollerJob) this).BRotation)
    {
      double angleInRadians = Utility.DegToRad(((buToolGrindingCalc) this).bPos);
      if (((RollerJob) this).AnglesInRadian)
        angleInRadians = ((buToolGrindingCalc) this).bPos;
      if (((ToolGrindingRuntimeSettings) this).centerPointOfB == (Point3D) null)
        ((RollerJob) this).\u0001 = Transformation.CreateRotation(angleInRadians, new Vector3D(0.0, 1.0, 0.0), new Point3D(((ToolGrindingJob) this).xRot, ((ToolGrindingJob) this).yRot, ((ToolGrindingJob) this).zRot));
      else
        ((RollerJob) this).\u0001 = Transformation.CreateRotation(angleInRadians, new Vector3D(0.0, 1.0, 0.0), ((ToolGrindingRuntimeSettings) this).centerPointOfB);
      data.RenderContext.MultMatrixModelView(((RollerJob) this).\u0001);
      Point3D point3D = new Point3D(num1, num2, num3);
      point3D.TransformBy(Transformation.CreateRotation(Utility.DegToRad(-((buToolGrindingCalc) this).bPos), new Vector3D(0.0, 1.0, 0.0), new Point3D(0.0, 0.0, 0.0)));
      num1 = point3D.X;
      num2 = point3D.Y;
      num3 = point3D.Z;
    }
    if (((buRollerBendCalc) this).ARotation)
    {
      double angleInRadians = Utility.DegToRad(((CutterNotchType) this).aPos);
      if (((RollerJob) this).AnglesInRadian)
        angleInRadians = ((CutterNotchType) this).aPos;
      if (((ToolGrindingRuntimeSettings) this).centerPointOfA == (Point3D) null)
        ((RollerJob) this).\u0001 = Transformation.CreateRotation(angleInRadians, new Vector3D(1.0, 0.0, 0.0), new Point3D(((ToolGrindingJob) this).xRot, ((ToolGrindingJob) this).yRot, ((ToolGrindingJob) this).zRot));
      else
        ((RollerJob) this).\u0001 = Transformation.CreateRotation(angleInRadians, new Vector3D(1.0, 0.0, 0.0), ((ToolGrindingRuntimeSettings) this).centerPointOfA);
      data.RenderContext.MultMatrixModelView(((RollerJob) this).\u0001);
      Point3D point3D = new Point3D(num1, num2, num3);
      point3D.TransformBy(Transformation.CreateRotation(Utility.DegToRad(-((CutterNotchType) this).aPos), new Vector3D(1.0, 0.0, 0.0), new Point3D(0.0, 0.0, 0.0)));
      num1 = point3D.X;
      num2 = point3D.Y;
      num3 = point3D.Z;
    }
    ((RollerJob) this).\u0001 = Transformation.CreateTranslation(num1, num2, num3);
    data.RenderContext.MultMatrixModelView(((RollerJob) this).\u0001);
  }

  public virtual bool IsInFrustum(FrustumParams data, Point3D center, double radius) => true;

  public CustomData(string blockName)
  {
    ((RollerJob) this).xPos = 0.0;
    ((RollerJob) this).yPos = 0.0;
    ((RollerJob) this).zPos = 0.0;
    ((RollerJob) this).aPos = 0.0;
    ((RollerBendMove) this).bPos = 0.0;
    ((RollerBendMove) this).cPos = 0.0;
    ((RollerBendMove) this).xRot = 0.0;
    ((RollerBendMove) this).yRot = 0.0;
    ((RollerBendMove) this).zRot = 0.0;
    ((RollerBendMove) this).aPos2 = 0.0;
    ((RollerBendMove) this).bPos2 = 0.0;
    ((RollerBendMove) this).cPos2 = 0.0;
    ((RollerBendMove) this).centerPointOfA = (Point3D) null;
    ((RollerBendMove) this).centerPointOfB = (Point3D) null;
    ((RollerBendRuntimeSettings) this).centerPointOfC = (Point3D) null;
    ((RollerBendRuntimeSettings) this).centerPointOfA2 = (Point3D) null;
    ((RollerBendRuntimeSettings) this).centerPointOfB2 = (Point3D) null;
    ((RollerBendRuntimeSettings) this).centerPointOfC2 = (Point3D) null;
    ((RollerBendRuntimeSettings) this).vectorARotation = (Vector3D) null;
    ((RollerBendRuntimeSettings) this).vectorBRotation = (Vector3D) null;
    ((RollerBendRuntimeSettings) this).vectorCRotation = (Vector3D) null;
    ((RollerBendRuntimeSettings) this).vectorARotation2 = (Vector3D) null;
    ((RollerBendRuntimeSettings) this).vectorBRotation2 = (Vector3D) null;
    ((RollerBendRuntimeSettings) this).vectorCRotation2 = (Vector3D) null;
    ((RollerBendSettings) this).XMove = false;
    ((RollerBendSettings) this).YMove = false;
    ((RollerBendSettings) this).ZMove = false;
    ((RollerBendSettings) this).ARotation = false;
    ((RollerBendSettings) this).BRotation = false;
    ((RollerBendSettings) this).CRotation = false;
    ((RollerBendSettings) this).ARotation2 = false;
    ((RollerBendSettings) this).BRotation2 = false;
    ((RollerBendSettings) this).CRotation2 = false;
    ((RollerBendSettings) this).No = -1;
    ((RollerBendSettings) this).HeadNumber = 1;
    // ISSUE: explicit constructor call
    ((BlockReference) this).\u002Ector(0.0, 0.0, 0.0, blockName, 1.0, 1.0, 1.0, 0.0);
  }

  protected virtual void Animate(int frameNumber)
  {
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Entity) this).Animate(frameNumber));
  }

  public virtual void Rotate(double angleInRadians, Vector3D axis, Point3D center)
  {
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Entity) this).Rotate(angleInRadians, axis, center));
  }

  public virtual void MoveTo(DrawParams data)
  {
    // ISSUE: explicit non-virtual call
    __nonvirtual (((BlockReference) this).MoveTo(data));
    double num1 = ((RollerJob) this).xPos;
    double num2 = ((RollerJob) this).yPos;
    double num3 = ((RollerJob) this).zPos;
    string blockName = ((BlockReference) this).BlockName;
    if (((RollerBendSettings) this).CRotation)
    {
      Vector3D axis = new Vector3D(0.0, 0.0, 1.0);
      if (((RollerBendRuntimeSettings) this).vectorCRotation != (Vector3D) null)
      {
        axis.X = ((RollerBendRuntimeSettings) this).vectorCRotation.X;
        axis.Y = ((RollerBendRuntimeSettings) this).vectorCRotation.Y;
        axis.Z = ((RollerBendRuntimeSettings) this).vectorCRotation.Z;
      }
      if (((RollerBendRuntimeSettings) this).centerPointOfC == (Point3D) null)
        ((RollerBendMoveCommand) this).\u0001 = Transformation.CreateRotation(Utility.DegToRad(((RollerBendMove) this).cPos), axis, new Point3D(((RollerBendMove) this).xRot, ((RollerBendMove) this).yRot, ((RollerBendMove) this).zRot));
      else
        ((RollerBendMoveCommand) this).\u0001 = Transformation.CreateRotation(Utility.DegToRad(((RollerBendMove) this).cPos), axis, ((RollerBendRuntimeSettings) this).centerPointOfC);
      data.RenderContext.MultMatrixModelView(((RollerBendMoveCommand) this).\u0001);
      if (!((RollerBendSettings) this).XMove)
        num1 = 0.0;
      if (!((RollerBendSettings) this).YMove)
        num2 = 0.0;
      if (!((RollerBendSettings) this).ZMove)
        num3 = 0.0;
      Point3D point3D = new Point3D(num1, num2, num3);
      point3D.TransformBy(Transformation.CreateRotation(Utility.DegToRad(-((RollerBendMove) this).cPos), axis, new Point3D(0.0, 0.0, 0.0)));
      num1 = point3D.X;
      num2 = point3D.Y;
      num3 = point3D.Z;
    }
    if (((RollerBendSettings) this).CRotation2)
    {
      Vector3D axis = new Vector3D(0.0, 0.0, 1.0);
      if (((RollerBendRuntimeSettings) this).vectorCRotation2 != (Vector3D) null)
      {
        axis.X = ((RollerBendRuntimeSettings) this).vectorCRotation2.X;
        axis.Y = ((RollerBendRuntimeSettings) this).vectorCRotation2.Y;
        axis.Z = ((RollerBendRuntimeSettings) this).vectorCRotation2.Z;
      }
      Point3D point3D = new Point3D((((Entity) this).BoxMin.X + ((Entity) this).BoxMax.X) / 2.0, (((Entity) this).BoxMin.Y + ((Entity) this).BoxMax.Y) / 2.0);
      if (((RollerBendRuntimeSettings) this).centerPointOfC2 == (Point3D) null)
        ((RollerBendMoveCommand) this).\u0001 = Transformation.CreateRotation(Utility.DegToRad(((RollerBendMove) this).cPos2), axis, new Point3D(((RollerBendMove) this).xRot, ((RollerBendMove) this).yRot, ((RollerBendMove) this).zRot));
      else
        ((RollerBendMoveCommand) this).\u0001 = Transformation.CreateRotation(Utility.DegToRad(((RollerBendMove) this).cPos2), axis, ((RollerBendRuntimeSettings) this).centerPointOfC2);
      data.RenderContext.MultMatrixModelView(((RollerBendMoveCommand) this).\u0001);
      if (!((RollerBendSettings) this).XMove)
        num1 = 0.0;
      if (!((RollerBendSettings) this).YMove)
        num2 = 0.0;
      if (!((RollerBendSettings) this).ZMove)
        num3 = 0.0;
      new Point3D(num1, num2, num3).TransformBy(Transformation.CreateRotation(Utility.DegToRad(-((RollerBendMove) this).cPos2), axis, new Point3D(0.0, 0.0, 0.0)));
    }
    if (((RollerBendSettings) this).BRotation)
    {
      if (((RollerBendMove) this).centerPointOfB == (Point3D) null)
        ((RollerBendMoveCommand) this).\u0001 = Transformation.CreateRotation(Utility.DegToRad(((RollerBendMove) this).bPos), new Vector3D(0.0, 1.0, 0.0), new Point3D(((RollerBendMove) this).xRot, ((RollerBendMove) this).yRot, ((RollerBendMove) this).zRot));
      else
        ((RollerBendMoveCommand) this).\u0001 = Transformation.CreateRotation(Utility.DegToRad(((RollerBendMove) this).bPos), new Vector3D(0.0, 1.0, 0.0), ((RollerBendMove) this).centerPointOfB);
      data.RenderContext.MultMatrixModelView(((RollerBendMoveCommand) this).\u0001);
      if (!((RollerBendSettings) this).XMove)
        num1 = 0.0;
      if (!((RollerBendSettings) this).YMove)
        num2 = 0.0;
      if (!((RollerBendSettings) this).ZMove)
        num3 = 0.0;
      Point3D point3D = new Point3D(num1, num2, num3);
      point3D.TransformBy(Transformation.CreateRotation(Utility.DegToRad(-((RollerBendMove) this).bPos), new Vector3D(0.0, 1.0, 0.0), new Point3D(0.0, 0.0, 0.0)));
      num1 = point3D.X;
      num2 = point3D.Y;
      num3 = point3D.Z;
    }
    if (((RollerBendSettings) this).ARotation)
    {
      if (((RollerBendMove) this).centerPointOfA == (Point3D) null)
        ((RollerBendMoveCommand) this).\u0001 = Transformation.CreateRotation(Utility.DegToRad(((RollerJob) this).aPos), new Vector3D(1.0, 0.0, 0.0), new Point3D(((RollerBendMove) this).xRot, ((RollerBendMove) this).yRot, ((RollerBendMove) this).zRot));
      else
        ((RollerBendMoveCommand) this).\u0001 = Transformation.CreateRotation(Utility.DegToRad(((RollerJob) this).aPos), new Vector3D(1.0, 0.0, 0.0), ((RollerBendMove) this).centerPointOfA);
      data.RenderContext.MultMatrixModelView(((RollerBendMoveCommand) this).\u0001);
      if (!((RollerBendSettings) this).XMove)
        num1 = 0.0;
      if (!((RollerBendSettings) this).YMove)
        num2 = 0.0;
      if (!((RollerBendSettings) this).ZMove)
        num3 = 0.0;
      Point3D point3D = new Point3D(num1, num2, num3);
      point3D.TransformBy(Transformation.CreateRotation(Utility.DegToRad(-((RollerJob) this).aPos), new Vector3D(1.0, 0.0, 0.0), new Point3D(0.0, 0.0, 0.0)));
      num1 = point3D.X;
      num2 = point3D.Y;
      num3 = point3D.Z;
    }
    this.ToString();
    if (!((RollerBendSettings) this).XMove)
      num1 = 0.0;
    if (!((RollerBendSettings) this).YMove)
      num2 = 0.0;
    if (!((RollerBendSettings) this).ZMove)
      num3 = 0.0;
    ((RollerBendMoveCommand) this).\u0001 = Transformation.CreateTranslation(num1, num2, num3);
    data.RenderContext.MultMatrixModelView(((RollerBendMoveCommand) this).\u0001);
  }

  public string Tags
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCamPlane) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXCamPlane) this).\u0001 = value;
  }

  public string SceneName
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXCamPlane) this).\u0002;
    [CompilerGenerated, SpecialName] set => ((Router3AXCamPlane) this).\u0002 = value;
  }

  public string EntityName
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXSettings) this).\u0003;
    [CompilerGenerated, SpecialName] set => ((Router3AXSettings) this).\u0003 = value;
  }

  public string ActionName
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXSettings) this).\u0004;
    [CompilerGenerated, SpecialName] set => ((Router3AXSettings) this).\u0004 = value;
  }

  public int ItemID
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXSettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXSettings) this).\u0001 = value;
  }

  public int CamID
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXSettings) this).\u0002;
    [CompilerGenerated, SpecialName] set => ((Router3AXSettings) this).\u0002 = value;
  }

  public int GroupIdIndex
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXSettings) this).\u0003;
    [CompilerGenerated, SpecialName] set => ((Router3AXSettings) this).\u0003 = value;
  }

  public int OriginalEntityIndex
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXSettings) this).\u0004;
    [CompilerGenerated, SpecialName] set => ((Router3AXSettings) this).\u0004 = value;
  }

  public int RefIndex
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXSettings) this).\u0005;
    [CompilerGenerated, SpecialName] set => ((Router3AXSettings) this).\u0005 = value;
  }

  public bool CamSelected
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXSettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXSettings) this).\u0001 = value;
  }

  public bool CamSelectable
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXSettings) this).\u0002;
    [CompilerGenerated, SpecialName] set => ((Router3AXSettings) this).\u0002 = value;
  }

  public bool DontUseForCalculation
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXSettings) this).\u0003;
    [CompilerGenerated, SpecialName] set => ((Router3AXSettings) this).\u0003 = value;
  }

  public double CamFeedrate
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0001 = value;
  }

  public double OrientationA
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0002;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0002 = value;
  }

  public double OrientationB
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0003;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0003 = value;
  }

  public double OrientationC
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0004;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0004 = value;
  }

  public entitySortDirection sortDirection
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0001 = value;
  }

  public entityTypeDefination typeDefination
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0001 = value;
  }

  public string infoString
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0005;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0005 = value;
  }

  public string infoData
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0006;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0006 = value;
  }

  public double infoLength
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0005;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0005 = value;
  }

  public double infoAngle
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0006;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0006 = value;
  }

  public double infoDirection
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0007;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0007 = value;
  }

  public double infoHeight
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u0008;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u0008 = value;
  }

  public double infoRadius
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXDisplaySettings) this).\u000E;
    [CompilerGenerated, SpecialName] set => ((Router3AXDisplaySettings) this).\u000E = value;
  }

  public double infoWidth
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXRuntimeSettings) this).\u000F;
    [CompilerGenerated, SpecialName] set => ((Router3AXRuntimeSettings) this).\u000F = value;
  }

  public double infoDepth
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXRuntimeSettings) this).\u0010;
    [CompilerGenerated, SpecialName] set => ((Router3AXRuntimeSettings) this).\u0010 = value;
  }

  public double infoHeadRadius
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXRuntimeSettings) this).\u0011;
    [CompilerGenerated, SpecialName] set => ((Router3AXRuntimeSettings) this).\u0011 = value;
  }

  public int infoSide
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXRuntimeSettings) this).\u0006;
    [CompilerGenerated, SpecialName] set => ((Router3AXRuntimeSettings) this).\u0006 = value;
  }

  public int infoDegree
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXRuntimeSettings) this).\u0007;
    [CompilerGenerated, SpecialName] set => ((Router3AXRuntimeSettings) this).\u0007 = value;
  }

  public Point3D infoBasePoint
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXRuntimeSettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXRuntimeSettings) this).\u0001 = value;
  }

  public entitySplineType CurveType
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXRuntimeSettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXRuntimeSettings) this).\u0001 = value;
  }

  public int Sequence
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXRuntimeSettings) this).\u0008;
    [CompilerGenerated, SpecialName] set => ((Router3AXRuntimeSettings) this).\u0008 = value;
  }

  public tuftingStitchModeType tuftingMode
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXRuntimeSettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((Router3AXRuntimeSettings) this).\u0001 = value;
  }

  public double tuftingPileHeight
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXTempVars) this).\u0012;
    [CompilerGenerated, SpecialName] set => ((Router3AXTempVars) this).\u0012 = value;
  }

  public double tuftingStitchLength
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXTempVars) this).\u0013;
    [CompilerGenerated, SpecialName] set => ((Router3AXTempVars) this).\u0013 = value;
  }

  public string ID
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXTempVars) this).\u0007;
    [CompilerGenerated, SpecialName] set => ((Router3AXTempVars) this).\u0007 = value;
  }

  public string Command
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXTempVars) this).\u0008;
    [CompilerGenerated, SpecialName] set => ((Router3AXTempVars) this).\u0008 = value;
  }

  public int EntityIndex
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXTempVars) this).\u000E;
    [CompilerGenerated, SpecialName] set => ((Router3AXTempVars) this).\u000E = value;
  }

  public int EntitySubIndex
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXTempVars) this).\u000F;
    [CompilerGenerated, SpecialName] set => ((Router3AXTempVars) this).\u000F = value;
  }

  public int CamIndex
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXTempVars) this).\u0010;
    [CompilerGenerated, SpecialName] set => ((Router3AXTempVars) this).\u0010 = value;
  }

  public int EdgeID
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXTempVars) this).\u0011;
    [CompilerGenerated, SpecialName] set => ((Router3AXTempVars) this).\u0011 = value;
  }

  public int InsideIndex
  {
    [CompilerGenerated, SpecialName] get => ((Router3AXTempVars) this).\u0012;
    [CompilerGenerated, SpecialName] set => ((Router3AXTempVars) this).\u0012 = value;
  }
}
