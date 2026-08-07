// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buConversion5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buApplication3D.UserInterfaces;
using buClass;
using buEyeBaseVer5.Forms;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class buConversion5
{
  public static void DisposeAll()
  {
    if (buEyeItems.viewportCadCam != null)
      buEyeItems.viewportCadCam.Dispose();
    if (buEyeItems.viewportCNC != null)
      buEyeItems.viewportCNC.Dispose();
    if (buEyeItems.viewportDialogs == null)
      return;
    buEyeItems.viewportDialogs.Dispose();
  }

  public static void ExchangeTwoVaues(ref Point3D Val1, ref Point3D Val2)
  {
    Point3D point3D = new Point3D(Val1.X, Val1.Y, Val1.Z);
    Val1 = new Point3D(Val2.X, Val2.Y, Val2.Z);
    Val2 = point3D;
  }

  public static void CreateControlsTool(
    bool FirstCreate,
    EyeCreateProps Properties,
    ref Design viewport)
  {
    if (FirstCreate)
    {
      viewport = new Design();
      viewport.InitializeViewports();
      viewport.CreateControl();
      viewport.CreateGraphics();
      viewport.Dock = DockStyle.Fill;
    }
    BackgroundSettings backgroundSettings = new BackgroundSettings(backgroundStyleType.LinearGradient, ((MaterialBase5) Properties).BottomColor, ((MaterialBase5) Properties).IntermediateColor, ((MaterialBase5) Properties).TopColor, 0.75, (Image) null, colorThemeType.Auto, 0.3);
    viewport.Viewports[0].Background = backgroundSettings;
    viewport.ActiveViewport.DisplayMode = ((MaterialBase5) Properties).DisplayType;
    viewport.Viewports[0].Pan.MouseButton = new MouseButton(((MaterialBase5) Properties).PanMouseButton.Button, ((MaterialBase5) Properties).PanMouseButton.ModifierKey);
    viewport.Viewports[0].Rotate.MouseButton = new MouseButton(((MaterialBase5) Properties).RotateMouseButton.Button, ((MaterialBase5) Properties).RotateMouseButton.ModifierKey);
    viewport.Viewports[0].Zoom.MouseButton = new MouseButton(((MaterialBase5) Properties).ZoomMouseButton.Button, ((MaterialBase5) Properties).ZoomMouseButton.ModifierKey);
    viewport.Viewports[0].Camera.ProjectionMode = ((MaterialBase5) Properties).ProjectionType;
    viewport.Viewports[0].Grid.Visible = ((MaterialBase5) Properties).ShowGrid;
    viewport.Viewports[0].OriginSymbol.Visible = ((MaterialBase5) Properties).ShowOrigin;
    viewport.Viewports[0].Zoom.ReverseMouseWheel = ((DiameterDepthPoint) Properties).ReverseMouseWheel;
    viewport.Viewports[0].OriginSymbol.LabelOrigin = ((ShapeCreateParameters) Properties).OriginString;
    viewport.Viewports[0].OriginSymbol.StyleMode = ((MaterialBase5) Properties).OriginSymbol;
    viewport.Viewports[0].OriginSymbol.Size = ((ShapeCreateParameters) Properties).OrigineSize;
    viewport.Viewports[0].CoordinateSystemIcon.Visible = ((MaterialBase5) Properties).ShowCoordinateArrow;
    viewport.Viewports[0].ViewCubeIcon.Visible = ((DiameterDepthPoint) Properties).ShowViewCube;
    viewport.Viewports[0].ToolBar.Visible = ((DiameterDepthPoint) Properties).ShowToolBar;
    viewport.Viewports[0].OriginSymbol.Visible = ((MaterialBase5) Properties).ShowOrigin;
    viewport.ActiveViewport.ToolBar.Visible = ((DiameterDepthPoint) Properties).ShowToolBar;
    viewport.ActiveViewport.OriginSymbol.Visible = ((MaterialBase5) Properties).ShowOrigin;
    viewport.ActiveViewport.CoordinateSystemIcon.Visible = ((MaterialBase5) Properties).ShowCoordinateArrow;
    if (((ShapeCreateParameters) Properties).Width > 0)
      viewport.Width = ((ShapeCreateParameters) Properties).Width;
    if (((ShapeCreateParameters) Properties).Height <= 0)
      return;
    viewport.Height = ((ShapeCreateParameters) Properties).Height;
  }

  public static Design CreateControlsTool(bool FirstCreate, EyeCreateProps Properties)
  {
    Design viewport = (Design) null;
    buConversion5.CreateControlsTool(FirstCreate, Properties, ref viewport);
    return viewport;
  }

  public static bool isTextStyleAvailable(Design Viewport, string TextStyleName)
  {
    bool flag;
    if (Viewport != null && Viewport.TextStyles != null)
    {
      for (int index = 0; index <= Viewport.TextStyles.Count - 1; ++index)
      {
        if (Viewport.TextStyles[index].Name == TextStyleName)
        {
          flag = true;
          goto label_7;
        }
      }
    }
    flag = false;
label_7:
    return flag;
  }

  public static bool isBlockAvailable(Design Viewport, string BlockName)
  {
    bool flag;
    if (Viewport != null && Viewport.Blocks != null)
    {
      for (int index = 0; index <= Viewport.Blocks.Count - 1; ++index)
      {
        if (Viewport.Blocks[index].Name == BlockName)
        {
          flag = true;
          goto label_7;
        }
      }
    }
    flag = false;
label_7:
    return flag;
  }

  public static bool isHatchAvailable(Design Viewport, string HatchName)
  {
    bool flag;
    if (Viewport != null && Viewport.HatchPatterns != null)
    {
      for (int index = 0; index <= Viewport.HatchPatterns.Count - 1; ++index)
      {
        if (Viewport.HatchPatterns[index].Name == HatchName)
        {
          flag = true;
          goto label_7;
        }
      }
    }
    flag = false;
label_7:
    return flag;
  }

  public static bool isLineTypeAvailable(Design Viewport, string LineTypeName)
  {
    bool flag;
    if (Viewport != null && Viewport.LineTypes != null)
    {
      for (int index = 0; index <= Viewport.LineTypes.Count - 1; ++index)
      {
        if (Viewport.LineTypes[index].Name == LineTypeName)
        {
          flag = true;
          goto label_7;
        }
      }
    }
    flag = false;
label_7:
    return flag;
  }

  public static bool isLayerAvailable(Design Viewport, string LayerName)
  {
    bool flag;
    if (Viewport != null && Viewport.Layers != null)
    {
      for (int index = 0; index <= Viewport.Layers.Count - 1; ++index)
      {
        if (Viewport.Layers[index].Name == LayerName)
        {
          flag = true;
          goto label_7;
        }
      }
    }
    flag = false;
label_7:
    return flag;
  }

  public static void ShowViewportViewBox(ref Design Viewport, bool Show)
  {
    Viewport.ActiveViewport.ViewCubeIcon.Visible = Show;
  }

  public static void ShowViewportToolbar(ref Design Viewport, bool Show)
  {
    Viewport.ActiveViewport.ToolBar.Visible = Show;
  }

  public static void ZoomFit(ref Design Viewport)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void ViewTop(ref Design Viewport, bool isZoomFit)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.SetView(viewType.Top);
    if (isZoomFit)
      Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void Viewfront(ref Design Viewport, bool isZoomFit)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.SetView(viewType.Front);
    if (isZoomFit)
      Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void ViewBack(ref Design Viewport, bool isZoomFit)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.SetView(viewType.Rear);
    if (isZoomFit)
      Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void ViewBottom(ref Design Viewport, bool isZoomFit)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.SetView(viewType.Bottom);
    if (isZoomFit)
      Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void ViewRight(ref Design Viewport, bool isZoomFit)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.SetView(viewType.Right);
    if (isZoomFit)
      Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void ViewLeft(ref Design Viewport, bool isZoomFit)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.SetView(viewType.Left);
    if (isZoomFit)
      Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void ViewIso(ref Design Viewport, bool isZoomFit)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.SetView(viewType.Isometric);
    if (isZoomFit)
      Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void ViewTrimetric(ref Design Viewport, bool isZoomFit)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.SetView(viewType.Trimetric);
    if (isZoomFit)
      Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void ViewProfile(ref Design Viewport, bool isZoomFit)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.SetView(viewType.vcFrontFaceTopLeft);
    if (isZoomFit)
      Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void ViewPan(ref Design Viewport)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    if (Viewport.ActionMode != devDept.Eyeshot.actionType.Pan)
      Viewport.ActionMode = devDept.Eyeshot.actionType.Pan;
    else
      Viewport.ActionMode = devDept.Eyeshot.actionType.None;
  }

  public static void ViewRotate(ref Design Viewport)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    if (Viewport.ActionMode != devDept.Eyeshot.actionType.Rotate)
      Viewport.ActionMode = devDept.Eyeshot.actionType.Rotate;
    else
      Viewport.ActionMode = devDept.Eyeshot.actionType.None;
  }

  public static void ViewZoomIn(ref Design Viewport)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.ZoomCamera(10);
    Viewport.Invalidate();
  }

  public static void ViewZoomOut(ref Design Viewport)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.ZoomCamera(-10);
    Viewport.Invalidate();
  }

  public static void ViewZoomNormal(ref Design Viewport)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public static void ViewZoomWindow(ref Design Viewport)
  {
    if (Viewport.Entities.Count <= 0)
      return;
    if (Viewport.ActionMode != devDept.Eyeshot.actionType.ZoomWindow)
      Viewport.ActionMode = devDept.Eyeshot.actionType.ZoomWindow;
    else
      Viewport.ActionMode = devDept.Eyeshot.actionType.None;
  }

  public static void ShowProgressBar(ref Design Viewport, bool Show)
  {
    Viewport.ProgressBar.Visible = Show;
  }

  public static void EnableWaitCursor(ref Design Viewport, bool Enable)
  {
    if (!Enable)
      Viewport.WaitCursorMode = waitCursorType.Never;
    else
      Viewport.WaitCursorMode = waitCursorType.RegenAndBoundingBox;
  }

  public static void CopyView(Design refViewport, ref Design copiedViewport)
  {
    devDept.Eyeshot.Camera saved;
    refViewport.SaveView(out saved);
    copiedViewport.RestoreView(saved);
    copiedViewport.Invalidate();
  }

  public static void CreateBoxWithCenter(
    Point3D CenterPoint,
    double Width,
    double Height,
    double Depth,
    bool isZCenter,
    ref Mesh entMesh)
  {
    entMesh = new Mesh();
    entMesh = Mesh.CreateBox(Width, Height, Depth);
    double num = 0.0;
    if (isZCenter)
      num = Depth / 2.0;
    entMesh.Translate(CenterPoint.X - Width / 2.0, CenterPoint.Y - Height / 2.0, CenterPoint.Z - num);
  }

  public static void CreateCylinderWithCenter(
    Point3D CenterPoint,
    double Radius,
    double Length,
    double RotationAngle,
    ref Mesh entMesh)
  {
    entMesh = new Mesh();
    entMesh = Mesh.CreateCylinder(Radius, Length, 40);
    entMesh.Translate(CenterPoint.X, CenterPoint.Y, CenterPoint.Z);
    if (RotationAngle == 0.0)
      return;
    entMesh.Rotate(buString5.DegreeToRadian(RotationAngle), new Vector3D(1.0, 0.0, 0.0));
  }

  public static void CreateConeWithCenter(
    Point3D CenterPoint,
    double BottomRadius,
    double TopRadius,
    double Length,
    double RotationAngle,
    ref Mesh entMesh)
  {
    entMesh = new Mesh();
    entMesh = Mesh.CreateCone(BottomRadius, TopRadius, Length, 40);
    entMesh.Translate(CenterPoint.X, CenterPoint.Y, CenterPoint.Z);
    if (RotationAngle == 0.0)
      return;
    entMesh.Rotate(buString5.DegreeToRadian(RotationAngle), new Vector3D(1.0, 0.0, 0.0));
  }

  public static void CreateArrow(
    Point3D BasePoint,
    Point3D TipPoint,
    double BottomRadius,
    double ArrowHeadRadius,
    double TotalLength,
    double ArrowHeadLenght,
    Color color,
    ref Mesh entMesh)
  {
    entMesh = new Mesh();
    Vector3D direction = new Vector3D(TipPoint.X - BasePoint.X, TipPoint.Y - BasePoint.Y, TipPoint.Z - BasePoint.Z);
    entMesh = Mesh.CreateArrow(BasePoint, direction, BottomRadius, TotalLength, ArrowHeadRadius, ArrowHeadLenght, 40, Mesh.natureType.Smooth, Mesh.edgeStyleType.Sharp);
    entMesh.Color = color;
  }

  public static void CreateSphere(Point3D BasePoint, double Radius, Color color, ref Mesh entMesh)
  {
    entMesh = new Mesh();
    entMesh = Mesh.CreateSphere(Radius, 10, 10, Mesh.natureType.Smooth);
    entMesh.Color = color;
    entMesh.Translate(BasePoint.X, BasePoint.Y, BasePoint.Z);
  }

  public static void CreateQuad(Quad3D quad, Color color, ref Mesh entMesh)
  {
    List<Point3D> Vertices = new List<Point3D>();
    List<List<Pnt3D>> pnt3DListList = new List<List<Pnt3D>>();
    Plane pln = new Plane();
    Vertices.Add(F_NotchEdit.ToPoint3D(quad.FirstPoint));
    Vertices.Add(F_NotchEdit.ToPoint3D(quad.SecondPoint));
    Vertices.Add(F_NotchEdit.ToPoint3D(quad.ThirdPoint));
    Vertices.Add(F_NotchEdit.ToPoint3D(quad.FourthPoint));
    Vertices.Add(F_NotchEdit.ToPoint3D(quad.FirstPoint));
    if (buCall.\u0001.GetClockDirection(Vertices) != 0)
      Vertices.Reverse();
    List<Point3D> Q1 = new List<Point3D>();
    for (int index = 0; index <= Vertices.Count - 1; ++index)
      Q1.Add(new Point3D(Vertices[index].X, Vertices[index].Y, Vertices[index].Z));
    List<ICurve> contours = new List<ICurve>();
    contours.Add((ICurve) Curve.GlobalInterpolation((IList<Point3D>) Q1, 1));
    if (pnt3DListList.Count > 0)
    {
      for (int index1 = 0; index1 <= pnt3DListList.Count - 1; ++index1)
      {
        List<Point3D> Q2 = new List<Point3D>();
        for (int index2 = 0; index2 <= pnt3DListList[index1].Count - 1; ++index2)
          Q2.Add(new Point3D(pnt3DListList[index1][index2].X, pnt3DListList[index1][index2].Y, pnt3DListList[index1][index2].Z));
        ICurve curve = (ICurve) Curve.GlobalInterpolation((IList<Point3D>) Q2, 1);
        contours.Add(curve);
      }
    }
    devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((IList<ICurve>) contours, pln);
    entMesh = region.ExtrudeAsMesh(0.01, 0.01, Mesh.natureType.Plain);
    entMesh.Color = color;
  }

  public static void SurfaceRevolveFromCurve(
    List<Point3D> Points,
    double StartAngle,
    double EndAngle,
    Vector3D vecDir,
    Point3D pntCenter,
    Color color,
    ref Mesh entMesh)
  {
    List<Point3D> Q = new List<Point3D>();
    for (int index = 0; index <= Points.Count - 1; ++index)
      Q.Add(new Point3D(Points[index].X, Points[index].Y, Points[index].Z));
    ICurve curve = (ICurve) Curve.GlobalInterpolation((IList<Point3D>) Q, 1);
    entMesh = curve.RevolveAsMesh(StartAngle, EndAngle - StartAngle, vecDir, pntCenter, 20, 0.1, Mesh.natureType.Smooth);
    entMesh.Color = color;
  }

  public static bool GetLayerColorFromName(string LayerName, ref Color colorLayer)
  {
    bool layerColorFromName;
    if (buEyeBaseForms.\u0001 != null)
    {
      for (int index = 0; index <= buEyeBaseForms.\u0001.Count - 1; ++index)
      {
        if (((DevideEventFormVars) buEyeBaseForms.\u0001[index]).Name == LayerName)
        {
          colorLayer = ((DevideEventFormVars) buEyeBaseForms.\u0001[index]).LayerColor;
          layerColorFromName = true;
          goto label_7;
        }
      }
    }
    layerColorFromName = false;
label_7:
    return layerColorFromName;
  }

  public void SketchWorkCompleted(object sender, WorkCompletedEventArgs e)
  {
    if (!(e.WorkUnit is ReadFileAsync))
      return;
    ReadFileAsync workUnit1 = (ReadFileAsync) e.WorkUnit;
    RegenOptions ro = new RegenOptions();
    ReadFile workUnit2 = e.WorkUnit as ReadFile;
    workUnit1.OpenTo((IDesign) buUserControls.desingSketch, ro);
  }

  public buConversion5()
  {
  }

  public buConversion5()
  {
    if (!buVector5.\u0001("buKinematic5"))
      throw new RegisterException("buKinematic5");
  }

  public void ForwardKinematix4Ax(
    double ToolLength,
    KinematicBase5 Kinematic,
    VectorType AxisVector,
    OrientationAngle Orientation,
    Point3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    KinematicBase5 kinematicBase5 = (KinematicBase5) new OsnapPoint(Kinematic);
    ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + ToolLength;
    ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Z = 0.0;
    if (((MeshToSurfacePointsSettings) Kinematic).Type == KinemeticType.CartezianXYZ_WristAC_5Axis | ((MeshToSurfacePointsSettings) Kinematic).Type == KinemeticType.CartezianXYZ_TableC_4Axis)
    {
      double num1 = Math.Cos(buString5.DegreeToRadian(Orientation.A));
      double m32 = Math.Sin(buString5.DegreeToRadian(Orientation.A));
      double num2 = Math.Cos(buString5.DegreeToRadian(Orientation.B));
      double m13 = Math.Sin(buString5.DegreeToRadian(Orientation.B));
      double num3 = Math.Cos(buString5.DegreeToRadian(Orientation.C));
      double m21 = Math.Sin(buString5.DegreeToRadian(Orientation.C));
      buMatrix5 m1_1 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num1, -m32, 0.0, 0.0, m32, num1, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m1_2 = buConversion5.CreatMatrix4x4(num2, 0.0, m13, 0.0, 0.0, 1.0, 0.0, 0.0, -m13, 0.0, num2, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m1_3 = buConversion5.CreatMatrix4x4(num3, -m21, 0.0, 0.0, m21, num3, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 buMatrix5 = (buMatrix5) null;
      buMatrix5 m2_1 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m2_2 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m2_3 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
      if (AxisVector == VectorType.XVector)
        buMatrix5 = buConversion5.Multiply(buConversion5.Multiply(m1_1, m2_1), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      if (AxisVector == VectorType.YVector)
        buMatrix5 = buConversion5.Multiply(buConversion5.Multiply(m1_2, m2_2), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      if (AxisVector == VectorType.ZVector)
        buMatrix5 = buConversion5.Multiply(buConversion5.Multiply(m1_3, m2_3), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      CalcPoint.X = ((buConversion5) buMatrix5).get_Item(0, 0) + MovePoint.X;
      CalcPoint.Y = ((buConversion5) buMatrix5).get_Item(1, 0) + MovePoint.Y;
      CalcPoint.Z = ((buConversion5) buMatrix5).get_Item(2, 0) + MovePoint.Z;
      CalcPoint.A = Orientation.A;
      CalcPoint.B = Orientation.B;
      CalcPoint.C = Orientation.C;
    }
    if (((MeshToSurfacePointsSettings) Kinematic).Type != KinemeticType.CartezianXYZ_WristA_4Axis)
      return;
    double num4 = Math.Cos(buString5.DegreeToRadian(Orientation.A));
    double m32_1 = Math.Sin(buString5.DegreeToRadian(Orientation.A));
    double num5 = Math.Cos(buString5.DegreeToRadian(Orientation.B));
    double m13_1 = Math.Sin(buString5.DegreeToRadian(Orientation.B));
    double num6 = Math.Cos(buString5.DegreeToRadian(Orientation.C));
    double m21_1 = Math.Sin(buString5.DegreeToRadian(Orientation.C));
    buMatrix5 m1 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num4, -m32_1, 0.0, 0.0, m32_1, num4, 0.0, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(num5, 0.0, m13_1, 0.0, 0.0, 1.0, 0.0, 0.0, -m13_1, 0.0, num5, 0.0, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(num6, -m21_1, 0.0, 0.0, m21_1, num6, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
    buMatrix5 m2 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
    buMatrix5 buMatrix5_1 = buConversion5.Multiply(buConversion5.Multiply(m1, m2), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
    CalcPoint.X = ((buConversion5) buMatrix5_1).get_Item(0, 0) + MovePoint.X;
    CalcPoint.Y = ((buConversion5) buMatrix5_1).get_Item(1, 0) + MovePoint.Y;
    CalcPoint.Z = ((buConversion5) buMatrix5_1).get_Item(2, 0) + MovePoint.Z;
    CalcPoint.A = Orientation.A;
    CalcPoint.B = Orientation.B;
    CalcPoint.C = Orientation.C;
  }

  public void ReverseKinematix4Ax(
    double ToolLength,
    KinematicBase5 Kinematic,
    VectorType AxisVector,
    OrientationAngle Orientation,
    Point3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    KinematicBase5 kinematicBase5 = (KinematicBase5) new OsnapPoint(Kinematic);
    ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + ToolLength;
    ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Z = 0.0;
    if (((MeshToSurfacePointsSettings) Kinematic).Type == KinemeticType.CartezianXYZ_WristAC_5Axis | ((MeshToSurfacePointsSettings) Kinematic).Type == KinemeticType.CartezianXYZ_TableC_4Axis)
    {
      double num1 = Math.Cos(buString5.DegreeToRadian(Orientation.A));
      double m32 = Math.Sin(buString5.DegreeToRadian(Orientation.A));
      double num2 = Math.Cos(buString5.DegreeToRadian(Orientation.B));
      double m13 = Math.Sin(buString5.DegreeToRadian(Orientation.B));
      double num3 = Math.Cos(buString5.DegreeToRadian(Orientation.C));
      double m21 = Math.Sin(buString5.DegreeToRadian(Orientation.C));
      buMatrix5 m1_1 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num1, -m32, 0.0, 0.0, m32, num1, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m1_2 = buConversion5.CreatMatrix4x4(num2, 0.0, m13, 0.0, 0.0, 1.0, 0.0, 0.0, -m13, 0.0, num2, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m1_3 = buConversion5.CreatMatrix4x4(num3, -m21, 0.0, 0.0, m21, num3, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 buMatrix5 = (buMatrix5) null;
      buMatrix5 m2_1 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m2_2 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m2_3 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
      if (AxisVector == VectorType.XVector)
        buMatrix5 = buConversion5.Multiply(buConversion5.Multiply(m1_1, m2_1), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      if (AxisVector == VectorType.YVector)
        buMatrix5 = buConversion5.Multiply(buConversion5.Multiply(m1_2, m2_2), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      if (AxisVector == VectorType.ZVector)
        buMatrix5 = buConversion5.Multiply(buConversion5.Multiply(m1_3, m2_3), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      CalcPoint.X = MovePoint.X - ((buConversion5) buMatrix5).get_Item(0, 0);
      CalcPoint.Y = MovePoint.Y - ((buConversion5) buMatrix5).get_Item(1, 0);
      CalcPoint.Z = MovePoint.Z - ((buConversion5) buMatrix5).get_Item(2, 0);
      CalcPoint.A = Orientation.A;
      CalcPoint.B = Orientation.B;
      CalcPoint.C = Orientation.C;
    }
    if (((MeshToSurfacePointsSettings) Kinematic).Type != KinemeticType.CartezianXYZ_WristA_4Axis)
      return;
    double num4 = Math.Cos(buString5.DegreeToRadian(Orientation.A));
    double m32_1 = Math.Sin(buString5.DegreeToRadian(Orientation.A));
    double num5 = Math.Cos(buString5.DegreeToRadian(Orientation.B));
    double m13_1 = Math.Sin(buString5.DegreeToRadian(Orientation.B));
    double num6 = Math.Cos(buString5.DegreeToRadian(Orientation.C));
    double m21_1 = Math.Sin(buString5.DegreeToRadian(Orientation.C));
    buMatrix5 m1 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num4, -m32_1, 0.0, 0.0, m32_1, num4, 0.0, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(num5, 0.0, m13_1, 0.0, 0.0, 1.0, 0.0, 0.0, -m13_1, 0.0, num5, 0.0, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(num6, -m21_1, 0.0, 0.0, m21_1, num6, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
    buMatrix5 m2 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
    buMatrix5 buMatrix5_1 = buConversion5.Multiply(buConversion5.Multiply(m1, m2), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
    CalcPoint.X = MovePoint.X - ((buConversion5) buMatrix5_1).get_Item(0, 0);
    CalcPoint.Y = MovePoint.Y - ((buConversion5) buMatrix5_1).get_Item(1, 0);
    CalcPoint.Z = MovePoint.Z - ((buConversion5) buMatrix5_1).get_Item(2, 0);
    CalcPoint.A = Orientation.A;
    CalcPoint.B = Orientation.B;
    CalcPoint.C = Orientation.C;
  }

  public void ForwardKinematix5Ax(
    double ToolLength,
    KinematicBase5 Kinematic,
    OrientationAngle Orientation,
    Point3D MovePoint,
    bool ApplyOffset,
    ref Pnt6D CalcPoint)
  {
    if (((MeshToSurfacePointsSettings) Kinematic).Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
    {
      Point3D point3D = new Point3D();
      KinematicBase5 Kinematic1 = (KinematicBase5) new OsnapPoint(Kinematic);
      if (ApplyOffset)
        this.FindKinematicOffsets(ref Kinematic1, Orientation);
      KinematicBase5 Kinematic2 = (KinematicBase5) new OsnapPoint(Kinematic1);
      ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfA.Z + ToolLength;
      ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfC.Z = 0.0;
      this.ForwardKinematix4Ax(ToolLength, Kinematic1, VectorType.XVector, Orientation, new Point3D(point3D.X, point3D.Y, point3D.Z), ref CalcPoint);
      CalcPoint.Y -= ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfA.Y - ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfC.Y;
      ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfC.Y = CalcPoint.Y;
      this.ForwardKinematix4Ax(ToolLength, Kinematic2, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
      double num = 0.0;
      CalcPoint.X = CalcPoint.X + num + MovePoint.X;
      CalcPoint.Y += MovePoint.Y;
      CalcPoint.Z = CalcPoint.Z + MovePoint.Z + ((OsnapCoordinateCatch) Kinematic2).CalcOffsetXYZ.Z;
    }
    if (((MeshToSurfacePointsSettings) Kinematic).Type != KinemeticType.CartezianXYZ_TableC_4Axis)
      return;
    Point3D point3D1 = new Point3D();
    KinematicBase5 Kinematic3 = (KinematicBase5) new OsnapPoint(Kinematic);
    ((OsnapCoordinateCatch) Kinematic3).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + ToolLength;
    ((OsnapCoordinateCatch) Kinematic3).RotateCenterOffsetOfC.Z = 0.0;
    this.ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D1.X, point3D1.Y, point3D1.Z), ref CalcPoint);
    CalcPoint.Y -= ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y;
    ((OsnapCoordinateCatch) Kinematic3).RotateCenterOffsetOfC.Y = CalcPoint.Y;
    this.ForwardKinematix4Ax(ToolLength, Kinematic3, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
    Math.Round(0.5 * Math.Sin(buString5.DegreeToRadian(Orientation.C)), 5);
    double num1 = 0.0;
    CalcPoint.X = CalcPoint.X + num1 + MovePoint.X;
    CalcPoint.Y += MovePoint.Y;
    CalcPoint.Z += MovePoint.Z;
  }

  public void FindKinematicOffsets(ref KinematicBase5 Kinematic, OrientationAngle Orientation)
  {
    double c = Orientation.C;
    if (c < 0.0)
      c += 360.0;
    if (c > 360.0)
      c -= 360.0;
    if (c < -360.0)
      c += 360.0;
    if (c >= 0.0 & c <= 90.0)
    {
      double X3_1 = 0.0;
      buFile5.EquationLineer(((OsnapPoint) Kinematic).CDistanceAtC0, ((PointWithIndex) Kinematic).CDistanceAtC90, 0.0, 90.0, c, ref X3_1);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y + X3_1;
      if (Math.Abs(Orientation.A) <= 1.0)
      {
        double X3_2 = 0.0;
        buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA0AtC0, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA0AtC90, 0.0, 90.0, c, ref X3_2);
        ((OsnapCoordinateCatch) Kinematic).CalcOffsetXYZ.Z = X3_2;
      }
      else
      {
        double X3_3 = 0.0;
        buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC0, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC90, 0.0, 90.0, c, ref X3_3);
        ((OsnapCoordinateCatch) Kinematic).CalcOffsetXYZ.Z = X3_3;
      }
      if (Math.Abs(Orientation.A) <= 0.0)
        return;
      double X3_4 = 0.0;
      buFile5.EquationLineer(((OsnapPoint) Kinematic).ADistanceForA45AtC0, ((OsnapPoint) Kinematic).ADistanceForA45AtC90, 0.0, 90.0, c, ref X3_4);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y + X3_4;
      double X3_5 = 0.0;
      buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC0, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC90, 0.0, 90.0, c, ref X3_5);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + X3_5;
    }
    else if (c >= 90.0 & c <= 180.0)
    {
      double X3_6 = 0.0;
      buFile5.EquationLineer(((PointWithIndex) Kinematic).CDistanceAtC90, ((PointWithIndex) Kinematic).CDistanceAtC180, 90.0, 180.0, c, ref X3_6);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y + X3_6;
      if (Math.Abs(Orientation.A) <= 1.0)
      {
        double X3_7 = 0.0;
        buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA0AtC90, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA0AtC180, 90.0, 180.0, c, ref X3_7);
        ((OsnapCoordinateCatch) Kinematic).CalcOffsetXYZ.Z = X3_7;
      }
      else
      {
        double X3_8 = 0.0;
        buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC90, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC180, 90.0, 180.0, c, ref X3_8);
        ((OsnapCoordinateCatch) Kinematic).CalcOffsetXYZ.Z = X3_8;
      }
      if (Math.Abs(Orientation.A) <= 0.0)
        return;
      double X3_9 = 0.0;
      buFile5.EquationLineer(((OsnapPoint) Kinematic).ADistanceForA45AtC90, ((OsnapPoint) Kinematic).ADistanceForA45AtC180, 90.0, 180.0, c, ref X3_9);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y + X3_9;
      double X3_10 = 0.0;
      buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC90, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC180, 90.0, 180.0, c, ref X3_10);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + X3_10;
    }
    else if (c >= 180.0 & c <= 270.0)
    {
      double X3_11 = 0.0;
      buFile5.EquationLineer(((PointWithIndex) Kinematic).CDistanceAtC180, ((MeshToSurfacePointsSettings) Kinematic).CDistanceAtC270, 180.0, 270.0, c, ref X3_11);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y + X3_11;
      if (Math.Abs(Orientation.A) <= 1.0)
      {
        double X3_12 = 0.0;
        buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA0AtC180, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA0AtC270, 180.0, 270.0, c, ref X3_12);
        ((OsnapCoordinateCatch) Kinematic).CalcOffsetXYZ.Z = X3_12;
      }
      else
      {
        double X3_13 = 0.0;
        buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC180, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC270, 180.0, 270.0, c, ref X3_13);
        ((OsnapCoordinateCatch) Kinematic).CalcOffsetXYZ.Z = X3_13;
      }
      if (Math.Abs(Orientation.A) <= 0.0)
        return;
      double X3_14 = 0.0;
      buFile5.EquationLineer(((OsnapPoint) Kinematic).ADistanceForA45AtC180, ((OsnapPoint) Kinematic).ADistanceForA45AtC270, 180.0, 270.0, c, ref X3_14);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y + X3_14;
      double X3_15 = 0.0;
      buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC180, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC270, 180.0, 270.0, c, ref X3_15);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + X3_15;
    }
    else
    {
      if (!(c >= 270.0 & c <= 360.0))
        return;
      double X3_16 = 0.0;
      buFile5.EquationLineer(((MeshToSurfacePointsSettings) Kinematic).CDistanceAtC270, ((OsnapPoint) Kinematic).CDistanceAtC0, 270.0, 360.0, c, ref X3_16);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y + X3_16;
      if (Math.Abs(Orientation.A) <= 1.0)
      {
        double X3_17 = 0.0;
        buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA0AtC270, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA0AtC0, 270.0, 360.0, c, ref X3_17);
        ((OsnapCoordinateCatch) Kinematic).CalcOffsetXYZ.Z = X3_17;
      }
      else
      {
        double X3_18 = 0.0;
        buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC270, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC0, 270.0, 360.0, c, ref X3_18);
        ((OsnapCoordinateCatch) Kinematic).CalcOffsetXYZ.Z = X3_18;
      }
      if (Math.Abs(Orientation.A) <= 0.0)
        return;
      double X3_19 = 0.0;
      buFile5.EquationLineer(((OsnapPoint) Kinematic).ADistanceForA45AtC270, ((OsnapPoint) Kinematic).ADistanceForA45AtC0, 270.0, 360.0, c, ref X3_19);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y + X3_19;
      double X3_20 = 0.0;
      buFile5.EquationLineer(((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC270, ((OsnapCoordinateCatch) Kinematic).ZDistanceForA45AtC0, 270.0, 360.0, c, ref X3_20);
      ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + X3_20;
    }
  }

  public void ForwardKinematix5Ax(
    double ToolLength,
    KinematicBase5 Kinematic,
    OrientationAngle Orientation,
    Point3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    if (((MeshToSurfacePointsSettings) Kinematic).Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
    {
      Point3D point3D = new Point3D();
      KinematicBase5 Kinematic1 = (KinematicBase5) new OsnapPoint(Kinematic);
      ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + ToolLength;
      ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfC.Z = 0.0;
      this.ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D.X, point3D.Y, point3D.Z), ref CalcPoint);
      CalcPoint.Y -= ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y;
      ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfC.Y = CalcPoint.Y;
      this.ForwardKinematix4Ax(ToolLength, Kinematic1, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
      double num = 0.0;
      CalcPoint.X = CalcPoint.X + num + MovePoint.X;
      CalcPoint.Y += MovePoint.Y;
      CalcPoint.Z += MovePoint.Z;
    }
    if (((MeshToSurfacePointsSettings) Kinematic).Type != KinemeticType.CartezianXYZ_TableC_4Axis)
      return;
    Point3D point3D1 = new Point3D();
    KinematicBase5 Kinematic2 = (KinematicBase5) new OsnapPoint(Kinematic);
    ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + ToolLength;
    ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfC.Z = 0.0;
    this.ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D1.X, point3D1.Y, point3D1.Z), ref CalcPoint);
    CalcPoint.Y -= ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y;
    ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfC.Y = CalcPoint.Y;
    this.ForwardKinematix4Ax(ToolLength, Kinematic2, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
    Math.Round(0.5 * Math.Sin(buString5.DegreeToRadian(Orientation.C)), 5);
    double num1 = 0.0;
    CalcPoint.X = CalcPoint.X + num1 + MovePoint.X;
    CalcPoint.Y += MovePoint.Y;
    CalcPoint.Z += MovePoint.Z;
  }

  public void ForwardKinematix4AxMilling(
    double ToolLength,
    KinematicBase5 Kinematic,
    VectorType AxisVector,
    OrientationAngle Orientation,
    Point3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    KinematicBase5 kinematicBase5 = (KinematicBase5) new OsnapPoint(Kinematic);
    ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Z = 0.0;
    if (((MeshToSurfacePointsSettings) Kinematic).Type == KinemeticType.CartezianXYZ_WristAC_5Axis | ((MeshToSurfacePointsSettings) Kinematic).Type == KinemeticType.CartezianXYZ_TableC_4Axis)
    {
      double num1 = Math.Cos(buString5.DegreeToRadian(Orientation.A));
      double m32 = Math.Sin(buString5.DegreeToRadian(Orientation.A));
      double num2 = Math.Cos(buString5.DegreeToRadian(Orientation.B));
      double m13 = Math.Sin(buString5.DegreeToRadian(Orientation.B));
      double num3 = Math.Cos(buString5.DegreeToRadian(Orientation.C));
      double m21 = Math.Sin(buString5.DegreeToRadian(Orientation.C));
      buMatrix5 m1_1 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num1, -m32, 0.0, 0.0, m32, num1, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m1_2 = buConversion5.CreatMatrix4x4(num2, 0.0, m13, 0.0, 0.0, 1.0, 0.0, 0.0, -m13, 0.0, num2, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m1_3 = buConversion5.CreatMatrix4x4(num3, -m21, 0.0, 0.0, m21, num3, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 buMatrix5 = (buMatrix5) null;
      buMatrix5 m2_1 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m2_2 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
      buMatrix5 m2_3 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
      if (AxisVector == VectorType.XVector)
        buMatrix5 = buConversion5.Multiply(buConversion5.Multiply(m1_1, m2_1), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      if (AxisVector == VectorType.YVector)
        buMatrix5 = buConversion5.Multiply(buConversion5.Multiply(m1_2, m2_2), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      if (AxisVector == VectorType.ZVector)
        buMatrix5 = buConversion5.Multiply(buConversion5.Multiply(m1_3, m2_3), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
      CalcPoint.X = ((buConversion5) buMatrix5).get_Item(0, 0) + MovePoint.X;
      CalcPoint.Y = ((buConversion5) buMatrix5).get_Item(1, 0) + MovePoint.Y;
      CalcPoint.Z = ((buConversion5) buMatrix5).get_Item(2, 0) + MovePoint.Z;
      CalcPoint.A = Orientation.A;
      CalcPoint.B = Orientation.B;
      CalcPoint.C = Orientation.C;
    }
    if (((MeshToSurfacePointsSettings) Kinematic).Type != KinemeticType.CartezianXYZ_WristA_4Axis)
      return;
    double num4 = Math.Cos(buString5.DegreeToRadian(Orientation.A));
    double m32_1 = Math.Sin(buString5.DegreeToRadian(Orientation.A));
    double num5 = Math.Cos(buString5.DegreeToRadian(Orientation.B));
    double m13_1 = Math.Sin(buString5.DegreeToRadian(Orientation.B));
    double num6 = Math.Cos(buString5.DegreeToRadian(Orientation.C));
    double m21_1 = Math.Sin(buString5.DegreeToRadian(Orientation.C));
    buMatrix5 m1 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, 0.0, 0.0, num4, -m32_1, 0.0, 0.0, m32_1, num4, 0.0, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(num5, 0.0, m13_1, 0.0, 0.0, 1.0, 0.0, 0.0, -m13_1, 0.0, num5, 0.0, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(num6, -m21_1, 0.0, 0.0, m21_1, num6, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
    buMatrix5 m2 = buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfA.Z, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfB.Z, 0.0, 0.0, 0.0, 1.0);
    buConversion5.CreatMatrix4x4(1.0, 0.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.X, 0.0, 1.0, 0.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Y, 0.0, 0.0, 1.0, ((OsnapCoordinateCatch) kinematicBase5).RotateCenterOffsetOfC.Z, 0.0, 0.0, 0.0, 1.0);
    buMatrix5 buMatrix5_1 = buConversion5.Multiply(buConversion5.Multiply(m1, m2), buConversion5.CreatMatrix4x1(0.0, 0.0, 0.0, 1.0));
    CalcPoint.X = ((buConversion5) buMatrix5_1).get_Item(0, 0) + MovePoint.X;
    CalcPoint.Y = ((buConversion5) buMatrix5_1).get_Item(1, 0) + MovePoint.Y;
    CalcPoint.Z = ((buConversion5) buMatrix5_1).get_Item(2, 0) + MovePoint.Z;
    CalcPoint.A = Orientation.A;
    CalcPoint.B = Orientation.B;
    CalcPoint.C = Orientation.C;
  }

  public void ForwardKinematix5AxMilling(
    double ToolLength,
    double PivotOffseet,
    IJK ijk,
    OrientationAngle Orientation,
    Point3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    double num = ToolLength + PivotOffseet;
    double x = MovePoint.X + num * ijk.I;
    double y = MovePoint.Y + num * ijk.J;
    double z = MovePoint.Z + num * ijk.K - num;
    CalcPoint = new Pnt6D(x, y, z, Orientation.A, Orientation.B, Orientation.C);
  }

  public void ReverseKinematix5AxMilling(
    double ToolLength,
    double PivotOffseet,
    OrientationAngle Orientation,
    Point3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    double num1 = Orientation.A * Math.PI / 180.0;
    double num2 = Orientation.B * Math.PI / 180.0;
    double num3 = Orientation.C * Math.PI / 180.0;
    double num4 = Math.Cos(num3) * Math.Sin(num2) * Math.Cos(num1) + Math.Sin(num3) * Math.Sin(num1);
    double num5 = Math.Sin(num3) * Math.Sin(num2) * Math.Cos(num1) - Math.Cos(num3) * Math.Sin(num1);
    double num6 = Math.Cos(num2) * Math.Cos(num1);
  }

  public void ForwardKinematix5AxMilling(
    double ToolLength,
    KinematicBase5 Kinematic,
    OrientationAngle Orientation,
    Point3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    if (((MeshToSurfacePointsSettings) Kinematic).Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
    {
      Point3D point3D = new Point3D();
      KinematicBase5 Kinematic1 = (KinematicBase5) new OsnapPoint(Kinematic);
      ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfC.Z = 0.0;
      this.ForwardKinematix4AxMilling(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D.X, point3D.Y, point3D.Z), ref CalcPoint);
      CalcPoint.Y -= ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y;
      ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfC.Y = CalcPoint.Y;
      this.ForwardKinematix4AxMilling(ToolLength, Kinematic1, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
      double num = 0.0;
      CalcPoint.X = CalcPoint.X + num + MovePoint.X;
      CalcPoint.Y += MovePoint.Y;
      CalcPoint.Z += MovePoint.Z;
    }
    if (((MeshToSurfacePointsSettings) Kinematic).Type != KinemeticType.CartezianXYZ_TableC_4Axis)
      return;
    Point3D point3D1 = new Point3D();
    KinematicBase5 Kinematic2 = (KinematicBase5) new OsnapPoint(Kinematic);
    ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + ToolLength;
    ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfC.Z = 0.0;
    this.ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D1.X, point3D1.Y, point3D1.Z), ref CalcPoint);
    CalcPoint.Y -= ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y;
    ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfC.Y = CalcPoint.Y;
    this.ForwardKinematix4Ax(ToolLength, Kinematic2, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
    Math.Round(0.5 * Math.Sin(buString5.DegreeToRadian(Orientation.C)), 5);
    double num1 = 0.0;
    CalcPoint.X = CalcPoint.X + num1 + MovePoint.X;
    CalcPoint.Y += MovePoint.Y;
    CalcPoint.Z += MovePoint.Z;
  }

  public void ReverseKinematix5Ax(
    double ToolLength,
    KinematicBase5 Kinematic,
    OrientationAngle Orientation,
    Point3D MovePoint,
    ref Pnt6D CalcPoint)
  {
    if (((MeshToSurfacePointsSettings) Kinematic).Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
    {
      Point3D point3D = new Point3D();
      KinematicBase5 Kinematic1 = (KinematicBase5) new OsnapPoint(Kinematic);
      ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + ToolLength;
      ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfC.Z = 0.0;
      this.ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D.X, point3D.Y, point3D.Z), ref CalcPoint);
      CalcPoint.Y -= ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y;
      ((OsnapCoordinateCatch) Kinematic1).RotateCenterOffsetOfC.Y = CalcPoint.Y;
      this.ForwardKinematix4Ax(ToolLength, Kinematic1, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
      CalcPoint.X = MovePoint.X - CalcPoint.X;
      CalcPoint.Y = MovePoint.Y - CalcPoint.Y;
      CalcPoint.Z = MovePoint.Z - CalcPoint.Z;
    }
    if (((MeshToSurfacePointsSettings) Kinematic).Type != KinemeticType.CartezianXYZ_TableC_4Axis)
      return;
    Point3D point3D1 = new Point3D();
    KinematicBase5 Kinematic2 = (KinematicBase5) new OsnapPoint(Kinematic);
    ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfA.Z = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z + ToolLength;
    ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfC.Z = 0.0;
    this.ForwardKinematix4Ax(ToolLength, Kinematic, VectorType.XVector, Orientation, new Point3D(point3D1.X, point3D1.Y, point3D1.Z), ref CalcPoint);
    CalcPoint.Y -= ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y;
    ((OsnapCoordinateCatch) Kinematic2).RotateCenterOffsetOfC.Y = CalcPoint.Y;
    this.ForwardKinematix4Ax(ToolLength, Kinematic2, VectorType.ZVector, Orientation, new Point3D(CalcPoint.X, 0.0, CalcPoint.Z), ref CalcPoint);
    CalcPoint.X = MovePoint.X - CalcPoint.X;
    CalcPoint.Y = MovePoint.Y - CalcPoint.Y;
    CalcPoint.Z = MovePoint.Z - CalcPoint.Z;
  }

  public abstract void m00040F();

  public buConversion5()
  {
    if (!buVector5.\u0001("buMatrix"))
      throw new RegisterException("buMatrix");
  }

  public buConversion5(int dim1, int dim2) => ((buVector5) this).\u0001 = new double[dim1, dim2];

  [SpecialName]
  public int get_Height() => ((buVector5) this).\u0001.GetLength(0);

  [SpecialName]
  public int get_Width() => ((buVector5) this).\u0001.GetLength(1);

  [SpecialName]
  public double get_Item(int x, int y) => ((buVector5) this).\u0001[x, y];

  [SpecialName]
  public void set_Item(int x, int y, double value) => ((buVector5) this).\u0001[x, y] = value;

  public static buMatrix5 CreatMatrix4x4(
    double m11,
    double m12,
    double m13,
    double m14,
    double m21,
    double m22,
    double m23,
    double m24,
    double m31,
    double m32,
    double m33,
    double m34,
    double m41,
    double m42,
    double m43,
    double m44)
  {
    try
    {
      buMatrix5 buMatrix5 = (buMatrix5) new buConversion5(4, 4);
      ((buConversion5) buMatrix5).set_Item(0, 0, m11);
      ((buConversion5) buMatrix5).set_Item(0, 1, m12);
      ((buConversion5) buMatrix5).set_Item(0, 2, m13);
      ((buConversion5) buMatrix5).set_Item(0, 3, m14);
      ((buConversion5) buMatrix5).set_Item(1, 0, m21);
      ((buConversion5) buMatrix5).set_Item(1, 1, m22);
      ((buConversion5) buMatrix5).set_Item(1, 2, m23);
      ((buConversion5) buMatrix5).set_Item(1, 3, m24);
      ((buConversion5) buMatrix5).set_Item(2, 0, m31);
      ((buConversion5) buMatrix5).set_Item(2, 1, m32);
      ((buConversion5) buMatrix5).set_Item(2, 2, m33);
      ((buConversion5) buMatrix5).set_Item(2, 3, m34);
      ((buConversion5) buMatrix5).set_Item(3, 0, m41);
      ((buConversion5) buMatrix5).set_Item(3, 1, m42);
      ((buConversion5) buMatrix5).set_Item(3, 2, m43);
      ((buConversion5) buMatrix5).set_Item(3, 3, m44);
      return buMatrix5;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return (buMatrix5) new buConversion5();
    }
  }

  public static buMatrix5 CreatMatrix4x1(double m11, double m21, double m31, double m41)
  {
    try
    {
      buMatrix5 buMatrix5 = (buMatrix5) new buConversion5(4, 1);
      ((buConversion5) buMatrix5).set_Item(0, 0, m11);
      ((buConversion5) buMatrix5).set_Item(1, 0, m21);
      ((buConversion5) buMatrix5).set_Item(2, 0, m31);
      ((buConversion5) buMatrix5).set_Item(3, 0, m41);
      return buMatrix5;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return (buMatrix5) new buConversion5();
    }
  }

  public static void Copy(buMatrix5 refMatrix, ref buMatrix5 copiedMatrix)
  {
    try
    {
      copiedMatrix = (buMatrix5) new buConversion5(((buConversion5) refMatrix).get_Width(), ((buConversion5) refMatrix).get_Height());
      for (int x = 0; x <= ((buConversion5) refMatrix).get_Width() - 1; ++x)
      {
        for (int y = 0; y <= ((buConversion5) refMatrix).get_Width() - 1; ++y)
          ((buConversion5) copiedMatrix).set_Item(x, y, ((buConversion5) refMatrix).get_Item(x, y));
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static buMatrix5 Multiply(buMatrix5 m1, buMatrix5 m2)
  {
    try
    {
      buMatrix5 buMatrix5_1 = (buMatrix5) new buConversion5(((buConversion5) m1).get_Height(), ((buConversion5) m2).get_Width());
      for (int x1 = 0; x1 < ((buConversion5) buMatrix5_1).get_Height(); ++x1)
      {
        for (int y1 = 0; y1 < ((buConversion5) buMatrix5_1).get_Width(); ++y1)
        {
          ((buConversion5) buMatrix5_1).set_Item(x1, y1, 0.0);
          for (int index = 0; index < ((buConversion5) m1).get_Width(); ++index)
          {
            buMatrix5 buMatrix5_2 = buMatrix5_1;
            int x2 = x1;
            int y2 = y1;
            ((buConversion5) buMatrix5_2).set_Item(x2, y2, ((buConversion5) buMatrix5_2).get_Item(x2, y2) + ((buConversion5) m1).get_Item(x1, index) * ((buConversion5) m2).get_Item(index, y1));
          }
        }
      }
      return buMatrix5_1;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return (buMatrix5) new buConversion5();
    }
  }

  public static void SwapRowsColumns(ref buMatrix5 m1)
  {
    try
    {
      buMatrix5 refMatrix = (buMatrix5) new buConversion5(((buConversion5) m1).get_Height(), ((buConversion5) m1).get_Width());
      for (int index1 = 0; index1 < ((buConversion5) m1).get_Width(); ++index1)
      {
        for (int index2 = 0; index2 < ((buConversion5) m1).get_Height(); ++index2)
        {
          double num = ((buConversion5) m1).get_Item(index1, index2);
          ((buConversion5) refMatrix).set_Item(index2, index1, num);
        }
      }
      buConversion5.Copy(refMatrix, ref m1);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public override string ToString() => $"m11{Environment.NewLine}m22";

  public abstract void m00041C();

  public buConversion5()
  {
  }

  public static bool GT(double Value1, double Value2, double Resolution = 0.001)
  {
    return !buConversion5.EQ(Value1, Value2, Resolution) & Value1 > Value2;
  }

  public static bool GE(double Value1, double Value2, double Resolution = 0.001)
  {
    return buConversion5.EQ(Value1, Value2, Resolution) | Value1 > Value2;
  }

  public static bool LT(double Value1, double Value2, double Resolution = 0.001)
  {
    return !buConversion5.EQ(Value1, Value2, Resolution) & Value1 < Value2;
  }

  public static bool LE(double Value1, double Value2, double Resolution = 0.001)
  {
    return buConversion5.EQ(Value1, Value2, Resolution) | Value1 < Value2;
  }

  public static bool EQ(double Value1, double Value2)
  {
    return buConversion5.EQ(Value1, Value2, buVector5.resolutionCompare);
  }

  public static bool EQ(Pnt2D Value1, Pnt2D Value2)
  {
    return buConversion5.EQ(Value1, Value2, buVector5.resolutionCompare);
  }

  public static bool EQ(Point3D Value1, Point3D Value2)
  {
    // ISSUE: reference to a compiler-generated method
    return buConversion5.\u003C\u003Ec.EQ(Value1, Value2, buVector5.resolutionCompare);
  }

  public static bool EQ(Point3D Value1, Point3D Value2, Plane refPlane)
  {
    return buString5.EQ(Value1, Value2, buVector5.resolutionCompare, refPlane);
  }

  public static bool EQ(Pnt3D Value1, Pnt3D Value2)
  {
    return buConversion5.EQ(Value1, Value2, buVector5.resolutionCompare);
  }

  public static bool EQ(Pnt4D Value1, Pnt4D Value2)
  {
    return buString5.EQ(Value1, Value2, buVector5.resolutionCompare);
  }

  public static bool EQ(Pnt6D Value1, Pnt6D Value2)
  {
    return buString5.EQ(Value1, Value2, buVector5.resolutionCompare);
  }

  public static bool EQ(Pnt6DSimMove Value1, Pnt6DSimMove Value2)
  {
    return buString5.EQ(Value1, Value2, buVector5.resolutionCompare);
  }

  public static bool EQ(Pnt9D Value1, Pnt9D Value2)
  {
    return buString5.EQ(Value1, Value2, buVector5.resolutionCompare);
  }

  public static bool EQ(TpPnt9D Value1, TpPnt9D Value2)
  {
    return buString5.EQ(((TpArcData) Value1).P9, ((TpArcData) Value2).P9, buVector5.resolutionCompare);
  }

  public static bool EQ(Pnt6D Value1, TpPnt9D Value2)
  {
    return buString5.EQ(Value1, new Pnt6D(((TpArcData) Value2).P9), buVector5.resolutionCompare);
  }

  public static bool EQ(double Value1, double Value2, double Resolution)
  {
    return Math.Abs(Value1 - Value2) < Resolution;
  }

  public static bool EQ(Pnt2D Value1, Pnt2D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y)) < Resolution;
  }

  public static bool EQ(Pnt3D Value1, Pnt3D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) < Resolution;
  }

  public static bool EQ(OrientationAngle Value1, OrientationAngle Value2, double Resolution = 0.001)
  {
    return Math.Sqrt((Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C)) < Resolution;
  }

  public static bool EQ(Point2D Value1, Point2D Value2, double Resolution = 0.001)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y)) < Resolution;
  }

  public static bool EQ(List<Point3D> refList1, List<Point3D> refList2, double Resolution = 0.001)
  {
    bool flag;
    if (refList1.Count == 0 | refList2.Count == 0)
      flag = false;
    else if (refList1.Count != refList2.Count)
    {
      flag = false;
    }
    else
    {
      for (int index = 0; index <= refList1.Count - 1; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        if (!buConversion5.\u003C\u003Ec.EQ(refList1[index], refList2[index], Resolution))
        {
          flag = false;
          goto label_10;
        }
      }
      flag = true;
    }
label_10:
    return flag;
  }
}
