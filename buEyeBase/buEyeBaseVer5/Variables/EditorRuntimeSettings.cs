// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Variables.EditorRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using Poly2Tri.Triangulation.Polygon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Variables;

[Serializable]
public class EditorRuntimeSettings : buSerilization5
{
  private WriteFileAsync \u0001;
  private Exception \u0001;
  private string \u0002;
  private TaskAwaiter \u0001;
  public static byte f0009DD;
  public List<eEntities> GCodeEntities;
  public List<Pnt9D> PointListVersusGCodeLines;
  public Vec3D MoveDistance;
  public bool UsePointListForGCodeLines;
  private string \u0001;
  private double \u0001;
  private bool \u0001;
  private PostProcessor \u0001;
  public static byte f0009EB;
  [SpecialName]
  public int value__;
  public const SerilizationMode5 SingleLine = ; // Unable to render the field
  public const SerilizationMode5 MultiLine = ; // Unable to render the field
  public const SerilizationMode5 SingleLineWithParenthesis = ; // Unable to render the field
  public object ValueBaseClass;
  public object Value;
  public string ValueAsString;
  public object SubParameter;
  public string Name;
  public Type Types;
  public FieldInfo Field;
  public static byte f0009F7;
  public static string AskMeResult;
  public static double AskMeValue;
  public static SortAskMe AskMe;
  public static SortbuAskMe AskMeBu;
  public static SortPointClickData PointClickData;

  public int FontToVectorConvert(
    Point3D Location,
    Font fFont,
    string ConvertString,
    Plane refPlane,
    Point3D PlaneOffset,
    ref List<PointsList> CalculatedPoints)
  {
    Graphics fx = (Graphics) null;
    List<PointsList> pointsListList = new List<PointsList>();
    int vectorConvert = this.FontToVectorConvert(fx, fFont, ConvertString, ref CalculatedPoints);
    for (int index1 = 0; index1 <= CalculatedPoints.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((ViewportSettings) CalculatedPoints[index1]).Points.Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= ((ViewportSettings) CalculatedPoints[index1]).Points[index2].Count - 1; ++index3)
        {
          Point3D point3D = F_NotchEdit.ToPoint3D(((ViewportSettings) CalculatedPoints[index1]).Points[index2][index3]);
          if (buVector5.isPlaneXYorYX(refPlane))
            point3D.Z = PlaneOffset.Z;
          if (buVector5.isPlaneXZorZX(refPlane))
          {
            point3D.Z = point3D.Y;
            point3D.Y = PlaneOffset.Y;
          }
          if (buVector5.isPlaneYZorZY(refPlane))
          {
            double y = point3D.Y;
            point3D.Y = point3D.X;
            point3D.Z = y;
            point3D.X = PlaneOffset.X;
          }
          ((ViewportSettings) CalculatedPoints[index1]).Points[index2][index3] = point3D;
        }
      }
    }
    return vectorConvert;
  }

  public int FontToVectorConvert(
    Graphics fx,
    Font fFont,
    string ConvertString,
    ref List<PointsList> CalculatedPoints)
  {
    try
    {
      PointF[] pointFArray = (PointF[]) null;
      byte[] numArray = (byte[]) null;
      bool flag = true;
      if (fx == null)
        flag = false;
      using (GraphicsPath graphicsPath = new GraphicsPath())
      {
        graphicsPath.AddString(ConvertString, fFont.FontFamily, (int) fFont.Style, fFont.Size, new PointF(0.0f, 0.0f), StringFormat.GenericDefault);
        graphicsPath.Flatten();
        if (graphicsPath.PointCount == 0)
          return -1;
        pointFArray = graphicsPath.PathPoints;
        numArray = graphicsPath.PathTypes;
      }
      List<Poly2Tri.Triangulation.Polygon.Polygon> polygonList = new List<Poly2Tri.Triangulation.Polygon.Polygon>();
      List<PolygonPoint> points = (List<PolygonPoint>) null;
      Pen yellow = Pens.Yellow;
      int num = 0;
      int index1 = -1;
      for (int index2 = 0; index2 < pointFArray.Length; ++index2)
      {
        switch ((int) numArray[index2] & 7)
        {
          case 0:
            points = new List<PolygonPoint>()
            {
              new PolygonPoint((double) pointFArray[index2].X, (double) pointFArray[index2].Y)
            };
            index1 = index2;
            yellow = ((F_CutterMachineSettings) this).\u0001[num % ((F_CutterMachineSettings) this).\u0001.Length];
            ++num;
            if (flag)
            {
              fx.FillRectangle(Brushes.DarkOrange, pointFArray[index2].X - 1.5f, pointFArray[index2].Y - 1.5f, 3f, 3f);
              break;
            }
            break;
          case 1:
            if (flag)
              fx.DrawLine(yellow, pointFArray[index2 - 1], pointFArray[index2]);
            if (((uint) numArray[index2] & 128U /*0x80*/) > 0U)
            {
              if (pointFArray[index2] != pointFArray[index1])
                points.Add(new PolygonPoint((double) pointFArray[index2].X, (double) pointFArray[index2].Y));
              polygonList.Add(new Poly2Tri.Triangulation.Polygon.Polygon((IEnumerable<PolygonPoint>) points));
              if (flag)
              {
                fx.FillRectangle(Brushes.DarkBlue, pointFArray[index2].X - 1.5f, pointFArray[index2].Y - 1.5f, 3f, 3f);
                fx.DrawLine(yellow, pointFArray[index2], pointFArray[index1]);
              }
              points = (List<PolygonPoint>) null;
              break;
            }
            points.Add(new PolygonPoint((double) pointFArray[index2].X, (double) pointFArray[index2].Y));
            break;
          default:
            throw new Exception("Unsupported point type");
        }
      }
      CalculatedPoints.Clear();
      List<Point3D> point3DList = new List<Point3D>();
      List<List<Point3D>> Points = new List<List<Point3D>>();
      foreach (Poly2Tri.Triangulation.Polygon.Polygon polygon in polygonList)
      {
        PointsList pointsList1 = (PointsList) new SortOptions();
        List<Point3D> mirrorPoint = new List<Point3D>();
        List<List<Point3D>> point3DListList = new List<List<Point3D>>();
        Point3D MinPoint1 = new Point3D();
        Point3D MaxPoint1 = new Point3D();
        Point3D MinPoint2 = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint2 = new Point3D();
        for (int index3 = 0; index3 <= polygon.Points.Count - 1; ++index3)
          mirrorPoint.Add(new Point3D(polygon.Points[index3].X, polygon.Points[index3].Y, 0.0));
        // ISSUE: reference to a compiler-generated method
        if (mirrorPoint.Count > 2 && !buConversion5.\u003C\u003Ec.EQ(mirrorPoint[0], mirrorPoint[mirrorPoint.Count - 1], buSystem.resolutionCompare))
          mirrorPoint.Add(F_NotchEdit.ToPoint3D(mirrorPoint[0]));
        ((buVector5) this).Mirror(new Point3D(), new Point3D(1.0, 0.0, 0.0), Plane.XY, ref mirrorPoint);
        ((buVector5) this).BoxSizeCalculate(mirrorPoint, ref MinPoint1, ref MaxPoint1);
        if (Points.Count == 0)
        {
          Points.Add(mirrorPoint);
        }
        else
        {
          ((buVector5) this).BoxSizeCalculate(Points, ref MinPoint2, ref MidPoint, ref MaxPoint2);
          if (((buVector5) this).isBoxSizeInsideBoxSize(MinPoint2, MaxPoint2, MinPoint1, MaxPoint1, Plane.XY))
          {
            Points.Add(mirrorPoint);
          }
          else
          {
            PointsList pointsList2 = (PointsList) new SortOptions();
            ((ViewportSettings) pointsList2).Points = Points;
            CalculatedPoints.Add(pointsList2);
            Points = new List<List<Point3D>>();
            Points.Add(mirrorPoint);
          }
        }
        if (mirrorPoint.Count > 0)
          ;
        if (((ViewportSettings) pointsList1).Points.Count > 2)
          ;
      }
      if (Points.Count > 0)
      {
        PointsList pointsList = (PointsList) new SortOptions();
        ((ViewportSettings) pointsList).Points = Points;
        CalculatedPoints.Add(pointsList);
      }
      Point3D MinPoint = new Point3D();
      Point3D MidPoint1 = new Point3D();
      Point3D MaxPoint = new Point3D();
      ((buVector5) this).BoxSizeCalculate(CalculatedPoints, ref MinPoint, ref MidPoint1, ref MaxPoint);
      for (int index4 = 0; index4 <= CalculatedPoints.Count - 1; ++index4)
        ((buVector5) this).Move(MinPoint, new Point3D(), ref ((ViewportSettings) CalculatedPoints[index4]).Points);
      return 1;
    }
    catch (Exception ex)
    {
      string str = "ConvertString: " + ConvertString.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return -1;
    }
  }
}
