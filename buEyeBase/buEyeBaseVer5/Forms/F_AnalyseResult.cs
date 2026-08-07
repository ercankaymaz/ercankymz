// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_AnalyseResult
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_AnalyseResult : Form
{
  public MirrorEventFormVars mirrorEventFormVar;
  public DevideEventFormVars devideEventFormVar;
  public DeleteTypeEventFormVars deleteTypeEventFormVar;
  public FlatViewSettings FlatViewSettings;
  public double GridStep;
  public double GridMinValue;
  public double GridMaxValue;
  public int GridMajorLineCount;
  public int snapGridPixel;
  public int snapSymbolSize;
  public double DrawThickness;
  public Color colorDraw;
  public Color colorGridLine;
  public Color colorGridMajorLine;
  public Color colorGridAxisX;
  public Color colorGridAxisY;
  public Color colorEntity;
  public Color colorDrawingPoints;
  public Color colorSelected;
  public Color colorDynamic;
  public Color colorFirstPart;
  public Color colorSecondPart;
  public Color colorEvent;
  public double thicknessDrawingPoints;
  public double thicknessEntityPoint;
  public double thicknessEntity;
  public double BoxSizeOffset;
  public bool ExpandDrawingTree;
  public bool ExpandConstraintTree;
  public bool ShowConstraintTreeItem;
  public bool ShowPointsAtDrawingTreeItem;
  public bool DrawDirrectionArrow;
  public int EntityMagnetRange;
  public bool OffsetByMouse;
  public bool isRectangleAsLine;
  public bool OsnapOver;
  public bool OsnapEntity;
  public bool OsnapGrid;
  public bool Ortho;
  public bool ShowPoints;
  public bool ShowBoxSize;

  public static string Point3DToDef(Point3D Pnt)
  {
    return $"{Pnt.X.ToString()};{Pnt.Y.ToString()};{Pnt.Z.ToString()}";
  }

  public static string Vector3DToDef(Vector3D Pnt)
  {
    return $"{Pnt.X.ToString()};{Pnt.Y.ToString()};{Pnt.Z.ToString()}";
  }

  public static Point3D Point3DDecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      string decimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
      if (Value.IndexOf("|") >= 0)
      {
        string[] strArray = Value.Split('|');
        if (strArray != null && strArray.Length == 2)
          Value = strArray[0];
      }
      if (decimalSeparator == ",")
        ;
      Point3D point3D = new Point3D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray1 = Value.Split(';');
      if (strArray1.Length != 3)
        strArray1 = Value.Split(',');
      if (strArray1.Length == 2)
      {
        point3D.X = double.Parse(strArray1[0], (IFormatProvider) provider);
        point3D.Y = double.Parse(strArray1[1], (IFormatProvider) provider);
        point3D.Z = 0.0;
      }
      if (strArray1.Length > 2)
      {
        point3D.X = double.Parse(strArray1[0], (IFormatProvider) provider);
        point3D.Y = double.Parse(strArray1[1], (IFormatProvider) provider);
        point3D.Z = double.Parse(strArray1[2], (IFormatProvider) provider);
      }
      return point3D;
    }
    catch (Exception ex)
    {
      return new Point3D();
    }
  }

  public static Vector3D Vector3DDecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      string decimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
      if (Value.IndexOf("|") >= 0)
      {
        string[] strArray = Value.Split('|');
        if (strArray != null && strArray.Length == 2)
          Value = strArray[0];
      }
      if (decimalSeparator == ",")
        ;
      Vector3D vector3D = (Vector3D) null;
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray1 = Value.Split(';');
      if (strArray1.Length != 3)
        strArray1 = Value.Split(',');
      if (strArray1.Length == 2)
        vector3D = new Vector3D(double.Parse(strArray1[0], (IFormatProvider) provider), double.Parse(strArray1[1], (IFormatProvider) provider), 0.0);
      if (strArray1.Length > 2)
        vector3D = new Vector3D(double.Parse(strArray1[0], (IFormatProvider) provider), double.Parse(strArray1[1], (IFormatProvider) provider), double.Parse(strArray1[2], (IFormatProvider) provider));
      return vector3D;
    }
    catch (Exception ex)
    {
      return new Vector3D();
    }
  }

  public static List<Point3D> ToPoint3D(List<Point3D> Pnt)
  {
    List<Point3D> point3D = new List<Point3D>();
    for (int index = 0; index <= Pnt.Count - 1; ++index)
      point3D.Add(F_NotchEdit.ToPoint3D(Pnt[index]));
    return point3D;
  }

  public static void ToPoint3D(List<Point3D> BasePnt, ref List<Point3D> CopyPnt)
  {
    CopyPnt = F_AnalyseResult.ToPoint3D(BasePnt);
  }

  public static void ToPoint3D(List<List<Point3D>> BasePnt, ref List<List<Point3D>> CopyPnt)
  {
    for (int index = 0; index <= BasePnt.Count - 1; ++index)
    {
      List<Point3D> CopyPnt1 = new List<Point3D>();
      F_AnalyseResult.ToPoint3D(BasePnt[index], ref CopyPnt1);
      CopyPnt.Add(CopyPnt1);
    }
  }

  public static Plane ToPlane(Plane refPlane)
  {
    Plane plane = new Plane();
    return (Plane) refPlane.Clone();
  }

  public bool isEntity3D(Entity Ent)
  {
    return Ent != null && Ent is Brep | Ent is Mesh | Ent is Solid | Ent is Surface;
  }

  public bool IsIndexNumberAvailableAtList(List<int> RefList, int Index)
  {
    try
    {
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (RefList[index] == Index)
          return true;
      }
      return false;
    }
    catch (Exception ex)
    {
      string str = $"RefList: {RefList.Count.ToString()} - Index: {Index.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool isEntitiesClosed(List<Entity> refEntities)
  {
    bool flag;
    if (refEntities.Count > 0)
    {
      if (refEntities[0] is ICurve & refEntities[refEntities.Count - 1] is ICurve)
      {
        Point3D point3D1 = new Point3D();
        Point3D point3D2 = new Point3D();
        entitySortDirection sortDirection1 = ((buVector5) this).GetSortDirection(refEntities[0]);
        entitySortDirection sortDirection2 = ((buVector5) this).GetSortDirection(refEntities[refEntities.Count - 1]);
        // ISSUE: reference to a compiler-generated method
        flag = buConversion5.\u003C\u003Ec.EQ(sortDirection1 != entitySortDirection.Normal ? ((ICurve) refEntities[0]).EndPoint : ((ICurve) refEntities[0]).StartPoint, sortDirection2 != entitySortDirection.Normal ? ((ICurve) refEntities[refEntities.Count - 1]).StartPoint : ((ICurve) refEntities[refEntities.Count - 1]).EndPoint, buSystem.resolutionCompare);
      }
      else
        flag = false;
    }
    else
      flag = false;
    return flag;
  }

  public bool isEntitiesClosed(List<buEntity> refEntities)
  {
    bool flag;
    if (refEntities.Count > 0)
    {
      Point3D point3D1 = new Point3D();
      Point3D point3D2 = new Point3D();
      entitySortDirection sortDirection1 = ((buVector5) this).GetSortDirection(refEntities[0]);
      entitySortDirection sortDirection2 = ((buVector5) this).GetSortDirection(refEntities[refEntities.Count - 1]);
      // ISSUE: reference to a compiler-generated method
      flag = buConversion5.\u003C\u003Ec.EQ(sortDirection1 != entitySortDirection.Normal ? ((CustomData) refEntities[0]).EndPoint : ((CustomData) refEntities[0]).StartPoint, sortDirection2 != entitySortDirection.Normal ? ((CustomData) refEntities[refEntities.Count - 1]).StartPoint : ((CustomData) refEntities[refEntities.Count - 1]).EndPoint, buSystem.resolutionCompare);
    }
    else
      flag = false;
    return flag;
  }

  public bool IsClosed(List<Point3D> RefPoints)
  {
    try
    {
      return RefPoints.Count > 1 && buConversion5.EQ(RefPoints[0], RefPoints[RefPoints.Count - 1]);
    }
    catch (Exception ex)
    {
      string str = "RefPoints: " + RefPoints.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool IsClosed(Point3D[] RefPoints)
  {
    try
    {
      return RefPoints.Length > 1 && RefPoints[0] == RefPoints[RefPoints.Length - 1];
    }
    catch (Exception ex)
    {
      string str = "RefPoints: " + RefPoints.Length.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool IsPointInsideWindow(
    Point3D LeftBottom,
    Point3D RightTop,
    Point3D ControledPoint,
    WorkPlane Plane,
    bool UseEqualCondition)
  {
    bool flag;
    try
    {
      if (UseEqualCondition)
      {
        if (WorkPlane.isPlaneXY(Plane) && LeftBottom.X <= ControledPoint.X & ControledPoint.X <= RightTop.X && LeftBottom.Y <= ControledPoint.Y & ControledPoint.Y <= RightTop.Y)
        {
          flag = true;
          goto label_20;
        }
        if (WorkPlane.isPlaneXZ(Plane) && LeftBottom.X <= ControledPoint.X & ControledPoint.X <= RightTop.X && LeftBottom.Z <= ControledPoint.Z & ControledPoint.Z <= RightTop.Z)
        {
          flag = true;
          goto label_20;
        }
        if (WorkPlane.isPlaneYZ(Plane))
        {
          if (LeftBottom.Y <= ControledPoint.Y & ControledPoint.Y <= RightTop.Y)
          {
            if (LeftBottom.Z <= ControledPoint.Z & ControledPoint.Z <= RightTop.Z)
            {
              flag = true;
              goto label_20;
            }
          }
        }
      }
      else
      {
        if (WorkPlane.isPlaneXY(Plane) && LeftBottom.X < ControledPoint.X & ControledPoint.X < RightTop.X && LeftBottom.Y < ControledPoint.Y & ControledPoint.Y < RightTop.Y)
        {
          flag = true;
          goto label_20;
        }
        if (WorkPlane.isPlaneXZ(Plane) && LeftBottom.X < ControledPoint.X & ControledPoint.X < RightTop.X && LeftBottom.Z < ControledPoint.Z & ControledPoint.Z < RightTop.Z)
        {
          flag = true;
          goto label_20;
        }
        if (WorkPlane.isPlaneYZ(Plane))
        {
          if (LeftBottom.Y < ControledPoint.Y & ControledPoint.Y < RightTop.Y)
          {
            if (LeftBottom.Z < ControledPoint.Z & ControledPoint.Z < RightTop.Z)
            {
              flag = true;
              goto label_20;
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"LeftBottom: {LeftBottom.ToString()} - RightTop: {RightTop.ToString()} - ControledPoint: {ControledPoint.ToString()} - UseEqualCondition: {UseEqualCondition.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      flag = false;
      goto label_20;
    }
    flag = false;
label_20:
    return flag;
  }

  public bool IsPointInsideBoxsize(
    Point3D Point,
    Point3D MinPoint,
    Point3D MaxPoint,
    WorkPlane Plane)
  {
    try
    {
      return this.IsPointInsideWindow(MinPoint, MaxPoint, Point, Plane, false);
    }
    catch (Exception ex)
    {
      string str = $"Point: {Point.ToString()} - MinPoint: {MinPoint.ToString()} - MaxPoint: {MaxPoint.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool isEntityDrawing(Entity refEntity)
  {
    bool flag;
    switch (refEntity)
    {
      case Line _:
        flag = true;
        break;
      case LinearPath _:
        flag = true;
        break;
      case Circle _:
        flag = true;
        break;
      case Arc _:
        flag = true;
        break;
      case Ellipse _:
        flag = true;
        break;
      case EllipticalArc _:
        flag = true;
        break;
      case Curve _:
        flag = true;
        break;
      case CompositeCurve _:
        flag = true;
        break;
      default:
        flag = false;
        break;
    }
    return flag;
  }

  public event OkCommandWithTwoDataEventHandler Selected;

  public event OkCommandWithTwoDataEventHandler Fix;

  public event OkCommandWithTwoDataEventHandler Cancel;

  public event OkCommandWithTwoDataEventHandler Find;
}
