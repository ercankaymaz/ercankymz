// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buMultilineText
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buMultilineText : buEntity
{
  internal ListBox \u0001;
  internal ListBox \u0002;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  public static byte f00370E;
  public FormProperties Properties;
  public new static List<string> Captions;
  public camParameters5 CamPar;

  public static ArrayList ToDefEntity(List<List<buEntity>> refEntities, int Space)
  {
    ArrayList AL = new ArrayList();
    buText.ToDefEntity(refEntities, Space, ref AL);
    return AL;
  }

  public ArrayList ToDef(int Space, string Char = "")
  {
    ArrayList def = new ArrayList();
    def.Add((object) $"{buImage5.SpaceChar(Space)}<buEntity{Char}>");
    if (this is buPoint)
    {
      buPoint buPoint = this as buPoint;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buPoint"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}StartPoint: {buSerilization5.ToDef(((CustomData) buPoint).StartPoint)}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buLine)
    {
      buLine buLine = this as buLine;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buLine"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}StartPoint: {buSerilization5.ToDef(((CustomData) buLine).StartPoint)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}EndPoint: {buSerilization5.ToDef(((CustomData) buLine).EndPoint)}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buCircle)
    {
      buCircle buCircle = this as buCircle;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buCircle"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}CenterPoint: {buSerilization5.ToDef(((CustomDataSurrogate) buCircle).Center)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Radius: {((CustomDataSurrogate) buCircle).Radius.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane: {buSerilization5.ToDef(((CustomDataSurrogate) buCircle).Plane)}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buArc)
    {
      buArc buArc = this as buArc;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buArc"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}CenterPoint: {buSerilization5.ToDef(((CustomDataSurrogate) buArc).Center)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Radius: {((CustomDataSurrogate) buArc).Radius.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}StartPoint: {buSerilization5.ToDef(((CustomData) buArc).StartPoint)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}EndPoint: {buSerilization5.ToDef(((CustomData) buArc).EndPoint)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane: {buSerilization5.ToDef(((CustomDataSurrogate) buArc).Plane)}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buLinearPath)
    {
      buLinearPath buLinearPath = this as buLinearPath;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buLinearPath"));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<Vertices>"));
      for (int index = 0; index <= ((CustomDataSurrogate) buLinearPath).Vertices.Count - 1; ++index)
        def.Add((object) $"{buImage5.SpaceChar(Space + 4)}P: {buSerilization5.ToDef(((CustomDataSurrogate) buLinearPath).Vertices[index])}");
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</Vertices>"));
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buEllipse)
    {
      buEllipse buEllipse = this as buEllipse;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buEllipse"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}CenterPoint: {buSerilization5.ToDef(((CustomDataSurrogate) buEllipse).Center)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}RadiusX: {((CustomDataSurrogate) buEllipse).RadiusX.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}RadiusY: {((CustomDataSurrogate) buEllipse).RadiusY.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Angle: {((CustomDataSurrogate) buEllipse).Angle.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane: {buSerilization5.ToDef(((CustomDataSurrogate) buEllipse).Plane)}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buCurve)
    {
      buCurve buCurve = this as buCurve;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buCurve"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Degree: {((CustomDataSurrogate) buCurve).Degree.ToString()}");
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ControlPoints>"));
      for (int index = 0; index <= ((CustomDataSurrogate) buCurve).ControlPoints.Count - 1; ++index)
        def.Add((object) $"{buImage5.SpaceChar(Space + 4)}CP: {buSerilization5.ToDef(((CustomDataSurrogate) buCurve).ControlPoints[index])}");
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ControlPoints>"));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<KnotVector>"));
      for (int index = 0; index <= ((CustomDataSurrogate) buCurve).KnotVector.Count - 1; ++index)
        def.Add((object) $"{buImage5.SpaceChar(Space + 4)}KV: {((CustomDataSurrogate) buCurve).KnotVector[index].ToString()}");
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</KnotVector>"));
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buCompositeCurve)
    {
      buCompositeCurve buCompositeCurve = this as buCompositeCurve;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buCompositeCurve"));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<SubCurves>"));
      for (int index = 0; index <= ((CustomDataSurrogate) buCompositeCurve).CurveList.Count - 1; ++index)
        def.AddRange((ICollection) ((buMultilineText) ((CustomDataSurrogate) buCompositeCurve).CurveList[index]).ToDef(Space + 2, "Sub"));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</SubCurves>"));
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buRegion)
    {
      buRegion buRegion = this as buRegion;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buRegion"));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<SubCurves>"));
      for (int index = 0; index <= ((CustomDataSurrogate) buRegion).CurveList.Count - 1; ++index)
        def.AddRange((ICollection) ((buMultilineText) ((CustomDataSurrogate) buRegion).CurveList[index]).ToDef(Space + 2, "Sub"));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</SubCurves>"));
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buMesh)
    {
      buMesh buMesh = this as buMesh;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buMesh"));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<Vertices>"));
      for (int index = 0; index <= ((CustomDataSurrogate) buMesh).Vertices.Count - 1; ++index)
        def.Add((object) $"{buImage5.SpaceChar(Space + 4)}P: {buSerilization5.ToDef(((CustomDataSurrogate) buMesh).Vertices[index])}");
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</Vertices>"));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<Triangles>"));
      for (int index = 0; index <= ((MyFileSerializer) buMesh).Triangles.Count - 1; ++index)
        def.Add((object) $"{buImage5.SpaceChar(Space + 4)}P: {buSerilization5.ToDef(((MyFileSerializer) buMesh).Triangles[index])}");
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</Triangles>"));
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buLinearDim)
    {
      buLinearDim buLinearDim = this as buLinearDim;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buLinearDim"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}ExtLine1: {buSerilization5.ToDef(((PolyNode) buLinearDim).ExtLine1)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}ExtLine2: {buSerilization5.ToDef(((PolyNode) buLinearDim).ExtLine2)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DimLinePosition: {buSerilization5.ToDef(((PolyNode) buLinearDim).DimLinePosition)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((PolyNode) buLinearDim).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane: {buSerilization5.ToDef(((PolyNode) buLinearDim).Plane)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextOverride: {((PolyNode) buLinearDim).TextOverride.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buAngularDim)
    {
      buAngularDim buAngularDim = this as buAngularDim;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buAngularDim"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}ExtLine1: {buSerilization5.ToDef(((\u000E.\u0001) buAngularDim).ExtLine1)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}ExtLine2: {buSerilization5.ToDef(((IntPoint) buAngularDim).ExtLine2)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DimLinePosition: {buSerilization5.ToDef(((IntPoint) buAngularDim).DimLinePosition)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((IntRect) buAngularDim).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane: {buSerilization5.ToDef(((IntRect) buAngularDim).Plane)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextOverride: {((ClipType) buAngularDim).TextOverride.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buRadialDim)
    {
      buRadialDim buRadialDim = this as buRadialDim;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buRadialDim"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Origin: {buSerilization5.ToDef(((EndType) buRadialDim).Origin)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DimLinePosition: {buSerilization5.ToDef(((EndType) buRadialDim).DimLinePosition)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Radius: {((EndType) buRadialDim).Radius.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((EndType) buRadialDim).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane: {buSerilization5.ToDef(((\u0004.\u0001) buRadialDim).Plane)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextOverride: {((\u0004.\u0001) buRadialDim).TextOverride.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buDiametricDim)
    {
      buDiametricDim buDiametricDim = this as buDiametricDim;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buDiametricDim"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Origin: {buSerilization5.ToDef(((ClipType) buDiametricDim).Origin)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DimLinePosition: {buSerilization5.ToDef(((ClipType) buDiametricDim).DimLinePosition)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Radius: {((PolyType) buDiametricDim).Radius.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((PolyType) buDiametricDim).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane: {buSerilization5.ToDef(((PolyType) buDiametricDim).Plane)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextOverride: {((PolyFillType) buDiametricDim).TextOverride.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buOrdinateDim)
    {
      buOrdinateDim buOrdinateDim = this as buOrdinateDim;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buOrdinateDim"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DefiningPoint: {buSerilization5.ToDef(((PolyFillType) buOrdinateDim).DefiningPoint)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DimLinePosition: {buSerilization5.ToDef(((PolyFillType) buOrdinateDim).DimLinePosition)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}isVertical: {((JoinType) buOrdinateDim).isVertical.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((JoinType) buOrdinateDim).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane: {buSerilization5.ToDef(((JoinType) buOrdinateDim).Plane)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextOverride: {((JoinType) buOrdinateDim).TextOverride.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buText)
    {
      buText buText = this as buText;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buText"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}InsertionPoint: {buSerilization5.ToDef(((\u0084.\u0001) buText).InsertionPoint)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextString: {((\u0015.\u0001) buText).TextString.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((\u0015.\u0001) buText).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}StyleName: {((\u0084.\u0001) buText).StyleName.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Simplify: {((\u0084.\u0001) buText).Simplify.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Alignment: {((\u0084.\u0001) buText).Alignment.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane: {buSerilization5.ToDef(((\u0015.\u0001) buText).Plane)}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buMultilineText)
    {
      buMultilineText buMultilineText = this as buMultilineText;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + nameof (buMultilineText)));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}InsertionPoint: {buSerilization5.ToDef(((\u0084.\u0001) buMultilineText).InsertionPoint)}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextString: {((\u0084.\u0001) buMultilineText).TextString.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((\u0084.\u0001) buMultilineText).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}StyleName: {((\u0084.\u0001) buMultilineText).StyleName.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Simplify: {((\u0084.\u0001) buMultilineText).Simplify.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Alignment: {((\u0084.\u0001) buMultilineText).Alignment.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}RectWidth: {((\u0084.\u0001) buMultilineText).RectWidth.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}LineSpaceDistance: {((\u0084.\u0001) buMultilineText).LineSpaceDistance.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Wrap: {((\u0084.\u0001) buMultilineText).Wrap.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane: {buSerilization5.ToDef(((\u0084.\u0001) buMultilineText).Plane)}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    def.Add((object) $"{buImage5.SpaceChar(Space)}</buEntity{Char}>");
    return def;
  }

  public ArrayList ToDefCommon(int Space)
  {
    ArrayList defCommon = new ArrayList();
    defCommon.Add((object) (buImage5.SpaceChar(Space) + "<Common>"));
    defCommon.Add((object) $"{buImage5.SpaceChar(Space + 2)}sortDirection: {((CustomData) this).sortDirection.ToString()}");
    defCommon.Add((object) $"{buImage5.SpaceChar(Space + 2)}typeDefination: {((CustomDataSurrogate) this).typeDefination.ToString()}");
    defCommon.Add((object) $"{buImage5.SpaceChar(Space + 2)}Orientation: {buSerilization5.ToDef(((CustomDataSurrogate) this).Orientation)}");
    defCommon.Add((object) $"{buImage5.SpaceChar(Space + 2)}Info = {buSerilization5.ClassToString((object) ((CustomData) this).Info)}");
    if (((CustomDataSurrogate) this).ToolName != null)
      defCommon.Add((object) $"{buImage5.SpaceChar(Space + 2)}ToolName: {((CustomDataSurrogate) this).ToolName.ToString()}");
    else
      defCommon.Add((object) (buImage5.SpaceChar(Space + 2) + "ToolName: "));
    if (((CustomDataSurrogate) this).LayerName != null)
      defCommon.Add((object) $"{buImage5.SpaceChar(Space + 2)}LayerName: {((CustomDataSurrogate) this).LayerName.ToString()}");
    else
      defCommon.Add((object) (buImage5.SpaceChar(Space + 2) + "LayerName: "));
    defCommon.Add((object) $"{buImage5.SpaceChar(Space + 2)}Color: {buFile5.ColorToString(((CustomDataSurrogate) this).Color, ColorConvertType.String)}");
    if (((CustomData) this).Shape != null)
      defCommon.Add((object) $"{buImage5.SpaceChar(Space + 2)}Shape = {buSerilization5.ClassToString((object) ((CustomData) this).Shape)}");
    if (((CustomData) this).Cutter != null)
      defCommon.Add((object) $"{buImage5.SpaceChar(Space + 2)}Cutter = {buSerilization5.ClassToString((object) ((CustomData) this).Cutter)}");
    defCommon.Add((object) (buImage5.SpaceChar(Space) + "</Common>"));
    if (((CustomData) this).Sewing != null)
    {
      defCommon.Add((object) (buImage5.SpaceChar(Space) + "<Sewing>"));
      defCommon.AddRange((ICollection) ((CutterInfo) ((CustomData) this).Sewing).ToDef(Space + 2));
      defCommon.Add((object) (buImage5.SpaceChar(Space) + "</Sewing>"));
    }
    if (((CustomData) this).Dimension != null)
    {
      defCommon.Add((object) (buImage5.SpaceChar(Space) + "<Dimension>"));
      defCommon.AddRange((ICollection) ((CharLibrary5) ((CustomData) this).Dimension).ToDef(Space + 2));
      defCommon.Add((object) (buImage5.SpaceChar(Space) + "</Dimension>"));
    }
    if (((CustomData) this).Marble != null)
    {
      defCommon.Add((object) (buImage5.SpaceChar(Space) + "<Marble>"));
      defCommon.AddRange((ICollection) ((Line2D) ((CustomData) this).Marble).ToDef(Space + 2));
      defCommon.Add((object) (buImage5.SpaceChar(Space) + "</Marble>"));
    }
    return defCommon;
  }

  public buMultilineText()
  {
    ((CustomData) this).BoxMax = new Point3D();
    ((CustomData) this).BoxMin = new Point3D();
    ((CustomData) this).StartPoint = new Point3D();
    ((CustomData) this).MiddlePoint = new Point3D();
    ((CustomData) this).EndPoint = new Point3D();
    ((CustomData) this).Shape = (EntityShapeInfo) null;
    ((CustomData) this).Info = (EntityInfo) new CharLibrary5();
    ((CustomData) this).Cutter = (CutterInfo) null;
    ((CustomData) this).Sewing = (SewingInfo) null;
    ((CustomData) this).Marble = (MarbleInfo) null;
    ((CustomData) this).Dimension = (DimensionInfo) null;
    ((CustomData) this).sortDirection = entitySortDirection.Normal;
    ((CustomDataSurrogate) this).typeDefination = entityTypeDefination.None;
    ((CustomDataSurrogate) this).Orientation = new OrientationAngle();
    ((CustomDataSurrogate) this).ToolName = "";
    ((CustomDataSurrogate) this).LayerName = "";
    ((CustomDataSurrogate) this).LayerIndex = 0;
    ((CustomDataSurrogate) this).Color = Color.Black;
    ((CustomDataSurrogate) this).Thickness = 1.0;
    ((CustomDataSurrogate) this).Vertices = new List<Point3D>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public abstract void m0017AC();

  public buMultilineText()
    : this()
  {
  }

  public buMultilineText(Point2D p)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(p.X, p.Y);
    ((buUpperLine) this).Update((buEntityUpdateType) 1);
  }

  public buMultilineText(Point3D p)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(p.X, p.Y, p.Z);
    ((buUpperLine) this).Update((buEntityUpdateType) 1);
  }

  public buMultilineText(double x, double y)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(x, y);
    ((buUpperLine) this).Update((buEntityUpdateType) 1);
  }

  public buMultilineText(double x, double y, double z)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(x, y, z);
    ((buUpperLine) this).Update((buEntityUpdateType) 1);
  }

  public buMultilineText(buPoint another)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(((CustomData) another).StartPoint.X, ((CustomData) another).StartPoint.Y, ((CustomData) another).StartPoint.Z);
    if (((CustomData) another).Shape != null)
      ((CustomData) this).Shape = (EntityShapeInfo) new SewingPunteriz(((CustomData) another).Shape);
    if (((CustomData) another).Info != null)
      ((CustomData) this).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) another).Info);
    if (((CustomData) another).Cutter != null)
      ((CustomData) this).Cutter = (CutterInfo) new AnalyseEntitiesResult(((CustomData) another).Cutter);
    if (((CustomData) another).Sewing != null)
      ((CustomData) this).Sewing = (SewingInfo) new EntityInfo(((CustomData) another).Sewing);
    if (((CustomData) another).Marble != null)
      ((CustomData) this).Marble = (MarbleInfo) new Line2D(((CustomData) another).Marble);
    if (((CustomData) another).Dimension != null)
      ((CustomData) this).Dimension = (DimensionInfo) new CharLibrary5(((CustomData) another).Dimension);
    ((CustomData) this).StartPoint = new Point3D(((CustomData) another).StartPoint.X, ((CustomData) another).StartPoint.Y, ((CustomData) another).StartPoint.Z);
    ((CustomData) this).BoxMin = new Point3D(((CustomData) another).BoxMin.X, ((CustomData) another).BoxMin.Y, ((CustomData) another).BoxMin.Z);
    ((CustomData) this).BoxMax = new Point3D(((CustomData) another).BoxMax.X, ((CustomData) another).BoxMax.Y, ((CustomData) another).BoxMax.Z);
    ((CustomData) this).sortDirection = ((CustomData) another).sortDirection;
    ((CustomDataSurrogate) this).typeDefination = ((CustomDataSurrogate) another).typeDefination;
    ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CustomDataSurrogate) another).Orientation);
    ((CustomDataSurrogate) this).ToolName = ((CustomDataSurrogate) another).ToolName;
    ((CustomDataSurrogate) this).LayerName = ((CustomDataSurrogate) another).LayerName;
    ((CustomDataSurrogate) this).LayerIndex = ((CustomDataSurrogate) another).LayerIndex;
    ((CustomDataSurrogate) this).Color = ((CustomDataSurrogate) another).Color;
    ((CustomDataSurrogate) this).Thickness = ((CustomDataSurrogate) another).Thickness;
    for (int index = 0; index <= ((CustomDataSurrogate) another).Vertices.Count - 1; ++index)
      ((CustomDataSurrogate) this).Vertices.Add(new Point3D(((CustomDataSurrogate) another).Vertices[index].X, ((CustomDataSurrogate) another).Vertices[index].Y, ((CustomDataSurrogate) another).Vertices[index].Z));
  }

  public buMultilineText(devDept.Eyeshot.Entities.Point another)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(another.StartPoint.X, another.StartPoint.Y, another.StartPoint.Z);
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 1);
  }

  public override string ToString()
  {
    string str = "Point Pnt: " + buString5.Point3DToString(((CustomData) this).StartPoint);
    if (((CustomDataSurrogate) this).typeDefination != 0)
      str = $"{str} Type: {((CustomDataSurrogate) this).typeDefination.ToString()}";
    if (((AnalyseEntitiesResult) ((CustomData) this).Info).CamSelected)
      str = $"{str} CamSelected: {((AnalyseEntitiesResult) ((CustomData) this).Info).CamSelected.ToString()}";
    if (((DirectionArrowSetting) ((CustomData) this).Info).Calculated)
      str = $"{str} Calculated: {((DirectionArrowSetting) ((CustomData) this).Info).Calculated.ToString()}";
    if (((AnalyseEntitiesSetting) ((CustomData) this).Info).RefIndex >= 0)
      str = $"{str} Ref Index: {((AnalyseEntitiesSetting) ((CustomData) this).Info).RefIndex.ToString()}";
    return str;
  }

  public abstract void m0017B5();

  public buMultilineText()
    : this()
  {
  }

  public buMultilineText(Plane plane, Point3D start, Point3D end)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(start.X, start.Y, start.Z);
    ((CustomData) this).EndPoint = new Point3D(end.X, end.Y, end.Z);
    ((buUpperLine) this).Update((buEntityUpdateType) 31 /*0x1F*/, plane: plane);
  }

  public buMultilineText(Point3D start, Point3D end)
    : this()
  {
    if ((!(start != (Point3D) null) ? 0 : (end != (Point3D) null ? 1 : 0)) == 0)
      return;
    ((CustomData) this).StartPoint = new Point3D(start.X, start.Y, start.Z);
    ((CustomData) this).EndPoint = new Point3D(end.X, end.Y, end.Z);
    ((buUpperLine) this).Update((buEntityUpdateType) 2);
  }

  public buMultilineText(double x1, double y1, double x2, double y2)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(x1, y1, 0.0);
    ((CustomData) this).EndPoint = new Point3D(x1, y1, 0.0);
    ((buUpperLine) this).Update((buEntityUpdateType) 2);
  }

  public buMultilineText(double x1, double y1, double z1, double x2, double y2, double z2)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(x1, y1, z1);
    ((CustomData) this).EndPoint = new Point3D(x1, y1, z2);
    ((buUpperLine) this).Update((buEntityUpdateType) 2);
  }

  public buMultilineText(buLine another)
    : this()
  {
    if (((CustomData) another).Shape != null)
      ((CustomData) this).Shape = (EntityShapeInfo) new SewingPunteriz(((CustomData) another).Shape);
    if (((CustomData) another).Info != null)
      ((CustomData) this).Info = (EntityInfo) new AnalyseEntitiesSetting(((CustomData) another).Info);
    if (((CustomData) another).Cutter != null)
      ((CustomData) this).Cutter = (CutterInfo) new AnalyseEntitiesResult(((CustomData) another).Cutter);
    if (((CustomData) another).Sewing != null)
      ((CustomData) this).Sewing = (SewingInfo) new EntityInfo(((CustomData) another).Sewing);
    if (((CustomData) another).Marble != null)
      ((CustomData) this).Marble = (MarbleInfo) new Line2D(((CustomData) another).Marble);
    if (((CustomData) another).Dimension != null)
      ((CustomData) this).Dimension = (DimensionInfo) new CharLibrary5(((CustomData) another).Dimension);
    ((CustomData) this).StartPoint = new Point3D(((CustomData) another).StartPoint.X, ((CustomData) another).StartPoint.Y, ((CustomData) another).StartPoint.Z);
    ((CustomData) this).MiddlePoint = new Point3D(((CustomData) another).MiddlePoint.X, ((CustomData) another).MiddlePoint.Y, ((CustomData) another).MiddlePoint.Z);
    ((CustomData) this).EndPoint = new Point3D(((CustomData) another).EndPoint.X, ((CustomData) another).EndPoint.Y, ((CustomData) another).EndPoint.Z);
    ((CustomData) this).BoxMin = new Point3D(((CustomData) another).BoxMin.X, ((CustomData) another).BoxMin.Y, ((CustomData) another).BoxMin.Z);
    ((CustomData) this).BoxMax = new Point3D(((CustomData) another).BoxMax.X, ((CustomData) another).BoxMax.Y, ((CustomData) another).BoxMax.Z);
    ((CustomData) this).sortDirection = ((CustomData) another).sortDirection;
    ((CustomDataSurrogate) this).typeDefination = ((CustomDataSurrogate) another).typeDefination;
    ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CustomDataSurrogate) another).Orientation);
    ((CustomDataSurrogate) this).ToolName = ((CustomDataSurrogate) another).ToolName;
    ((CustomDataSurrogate) this).LayerName = ((CustomDataSurrogate) another).LayerName;
    ((CustomDataSurrogate) this).LayerIndex = ((CustomDataSurrogate) another).LayerIndex;
    ((CustomDataSurrogate) this).Color = ((CustomDataSurrogate) another).Color;
    ((CustomDataSurrogate) this).Thickness = ((CustomDataSurrogate) another).Thickness;
    for (int index = 0; index <= ((CustomDataSurrogate) another).Vertices.Count - 1; ++index)
      ((CustomDataSurrogate) this).Vertices.Add(new Point3D(((CustomDataSurrogate) another).Vertices[index].X, ((CustomDataSurrogate) another).Vertices[index].Y, ((CustomDataSurrogate) another).Vertices[index].Z));
  }

  public buMultilineText(Line another)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(another.StartPoint.X, another.StartPoint.Y, another.StartPoint.Z);
    ((CustomData) this).EndPoint = new Point3D(another.EndPoint.X, another.EndPoint.Y, another.EndPoint.Z);
    if (another.EntityData != null && another.EntityData is CustomData)
      ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CutterIsoEntities) another.EntityData).get_OrientationA(), ((CutterIsoError) another.EntityData).get_OrientationB(), ((CutterIsoFileSettings) another.EntityData).get_OrientationC());
    ((CustomDataSurrogate) this).LayerName = another.LayerName;
    if ((buEyeBaseForms.\u0001 == null ? 0 : (buEyeBaseForms.\u0001.Count > 0 ? 1 : 0)) != 0)
    {
      Color color = another.Color;
      if (buConversion5.GetLayerColorFromName(another.LayerName, ref color))
        ((CustomDataSurrogate) this).Color = color;
    }
    ((buUpperLine) this).Update((buEntityUpdateType) 2);
  }

  public override string ToString()
  {
    string str = $"Line SP: {buString5.Point3DToString(((CustomData) this).StartPoint)} - EP: {buString5.Point3DToString(((CustomData) this).EndPoint)} - Dir: {((CustomData) this).sortDirection.ToString()}";
    if (((CustomDataSurrogate) this).typeDefination != 0)
      str = $"{str} Type: {((CustomDataSurrogate) this).typeDefination.ToString()}";
    if (((AnalyseEntitiesResult) ((CustomData) this).Info).CamSelected)
      str = $"{str} CamSelected: {((AnalyseEntitiesResult) ((CustomData) this).Info).CamSelected.ToString()}";
    if (((DirectionArrowSetting) ((CustomData) this).Info).Calculated)
      str = $"{str} Calculated: {((DirectionArrowSetting) ((CustomData) this).Info).Calculated.ToString()}";
    if (((AnalyseEntitiesSetting) ((CustomData) this).Info).RefIndex >= 0)
      str = $"{str} Ref Index: {((AnalyseEntitiesSetting) ((CustomData) this).Info).RefIndex.ToString()}";
    return str;
  }

  public abstract void m0017BE();

  public buMultilineText()
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).StartAngle = 10.0;
    ((CustomDataSurrogate) this).EndAngle = 10.0;
    ((CustomDataSurrogate) this).Flip = false;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMultilineText(Point3D center, Point3D start, Point3D end)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).StartAngle = 10.0;
    ((CustomDataSurrogate) this).EndAngle = 10.0;
    ((CustomDataSurrogate) this).Flip = false;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    this.\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y, center.Z);
    ((CustomData) this).StartPoint = new Point3D(start.X, start.Y, start.Z);
    ((CustomData) this).EndPoint = new Point3D(end.X, end.Y, end.Z);
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    ((buUpperLine) this).Update((buEntityUpdateType) 3);
  }

  public buMultilineText(Point3D center, double radius, double startAngle, double endAngle)
  {
    ((CustomDataSurrogate) this).Center = new Point3D();
    ((CustomDataSurrogate) this).Radius = 10.0;
    ((CustomDataSurrogate) this).StartAngle = 10.0;
    ((CustomDataSurrogate) this).EndAngle = 10.0;
    ((CustomDataSurrogate) this).Flip = false;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    this.\u002Ector();
    ((CustomDataSurrogate) this).Center = new Point3D(center.X, center.Y, center.Z);
    ((CustomDataSurrogate) this).Radius = radius;
    ((CustomDataSurrogate) this).StartAngle = startAngle;
    ((CustomDataSurrogate) this).EndAngle = endAngle;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    ((buUpperLine) this).Update((buEntityUpdateType) 4);
  }
}
