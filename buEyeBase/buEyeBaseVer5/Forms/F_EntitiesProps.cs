// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_EntitiesProps
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_EntitiesProps : Form
{
  public bool isSketchMode;
  public bool isSewingMode;
  public bool isFoamMode;
  public bool GridEnable;
  public bool OsnapOverDisable;
  public bool OsnapEntityDisable;
  public bool OsnapGridDisable;
  public bool OsnapPointDisable;
  public bool FromFileKeepRatio;
  public bool TurnOverCenter;
  public bool ExplodeCompositeCurveToEntities;
  public bool ExplodeCircleToArc;

  public bool isPointOverEntity(ICurve refCurve, Point3D refPoint, double Resolution)
  {
    double t;
    refCurve.ClosestPointTo(refPoint, out t);
    Point3D point3D = refCurve.PointAt(t);
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    return t >= refCurve.Domain.t0 & t <= refCurve.Domain.t1 && !(buConversion5.EQ(t, refCurve.Domain.t0, Resolution) & !buConversion5.\u003C\u003Ec.EQ(refPoint, refCurve.StartPoint, Resolution)) && !(buConversion5.EQ(t, refCurve.Domain.t1, Resolution) & !buConversion5.\u003C\u003Ec.EQ(refPoint, refCurve.EndPoint, Resolution)) && buConversion5.\u003C\u003Ec.EQ(point3D, refPoint, Resolution);
  }

  public bool isPointOverEntity(
    Entity refCurve,
    Point3D refPoint,
    double Resolution,
    ref Point3D pntOver)
  {
    double t;
    ((ICurve) refCurve).ClosestPointTo(refPoint, out t);
    pntOver = ((ICurve) refCurve).PointAt(t);
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    return t >= ((ICurve) refCurve).Domain.t0 & t <= ((ICurve) refCurve).Domain.t1 && !(buConversion5.EQ(t, ((ICurve) refCurve).Domain.t0, Resolution) & !buConversion5.\u003C\u003Ec.EQ(refPoint, ((ICurve) refCurve).StartPoint, Resolution)) && !(buConversion5.EQ(t, ((ICurve) refCurve).Domain.t1, Resolution) & !buConversion5.\u003C\u003Ec.EQ(refPoint, ((ICurve) refCurve).EndPoint, Resolution)) && buConversion5.\u003C\u003Ec.EQ(pntOver, refPoint, Resolution);
  }

  public bool isPointOverEntity(buEntity refCurve, Point3D refPoint, double Resolution)
  {
    Entity copiedEntity = (Entity) null;
    buAngularDim.Copy(refCurve, ref copiedEntity);
    Point3D pntOver = new Point3D();
    return this.isPointOverEntity(copiedEntity, refPoint, Resolution, ref pntOver);
  }

  public bool isPointOverLine(
    Point3D pntStart,
    Point3D pntEnd,
    Point3D refPoint,
    double Resolution)
  {
    Line refCurve = new Line(pntStart, pntEnd);
    Point3D pntOver = new Point3D();
    return this.isPointOverEntity((Entity) refCurve, refPoint, Resolution, ref pntOver);
  }

  public bool isPointOverLine(
    Point3D pntStart,
    Point3D pntEnd,
    Point3D refPoint,
    double Resolution,
    ref Point3D pntOver)
  {
    return this.isPointOverEntity((Entity) new Line(pntStart, pntEnd), refPoint, Resolution, ref pntOver);
  }

  public bool isPointReflectionOverLine(
    Point3D pntStart,
    Point3D pntEnd,
    Point3D refPoint,
    double Resolution,
    ref Point3D pntOver)
  {
    Line line = new Line(pntStart, pntEnd);
    double t;
    line.ClosestPointTo(refPoint, out t);
    pntOver = line.PointAt(t);
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    return t >= line.Domain.t0 & t <= line.Domain.t1 && !(buConversion5.EQ(t, line.Domain.t0, Resolution) & !buConversion5.\u003C\u003Ec.EQ(refPoint, line.StartPoint, Resolution)) && !(buConversion5.EQ(t, line.Domain.t1, Resolution) & !buConversion5.\u003C\u003Ec.EQ(refPoint, line.EndPoint, Resolution));
  }

  public bool IsPointInsidePolygon(
    List<Point3D> Vertices,
    Point3D RefPoint,
    Plane refPlane,
    bool CheckOver)
  {
    try
    {
      double num1 = 0.0;
      if (buVector5.isPlaneXYorYX(refPlane))
      {
        for (int index = 0; index < Vertices.Count; ++index)
        {
          double num2 = Vertices[index].X - RefPoint.X;
          double num3 = Vertices[index].Y - RefPoint.Y;
          double num4 = Vertices[(index + 1) % Vertices.Count].X - RefPoint.X;
          double num5 = Vertices[(index + 1) % Vertices.Count].Y - RefPoint.Y;
          num1 += \u0007.\u0001.\u0001(num2, num5, num4, (buVector5) this, num3);
          if (CheckOver & index > 0 && ((F_DeleteType) this).IsPointInsideLine(Vertices[index - 1], Vertices[index], RefPoint, refPlane, 0.01))
            return true;
        }
      }
      if (buVector5.isPlaneXYorYX(refPlane))
      {
        for (int index = 0; index < Vertices.Count; ++index)
        {
          double num6 = Vertices[index].X - RefPoint.X;
          double num7 = Vertices[index].Z - RefPoint.Z;
          double num8 = Vertices[(index + 1) % Vertices.Count].X - RefPoint.X;
          double num9 = Vertices[(index + 1) % Vertices.Count].Z - RefPoint.Z;
          num1 += \u0007.\u0001.\u0001(num6, num9, num8, (buVector5) this, num7);
        }
      }
      if (buVector5.isPlaneXYorYX(refPlane))
      {
        for (int index = 0; index < Vertices.Count; ++index)
        {
          double num10 = Vertices[index].Y - RefPoint.Y;
          double num11 = Vertices[index].Z - RefPoint.Z;
          double num12 = Vertices[(index + 1) % Vertices.Count].Y - RefPoint.Y;
          double num13 = Vertices[(index + 1) % Vertices.Count].Z - RefPoint.Z;
          num1 += \u0007.\u0001.\u0001(num10, num13, num12, (buVector5) this, num11);
        }
      }
      return !(Math.Abs(num1) < Math.PI | buConversion5.EQ(Math.Abs(num1), Math.PI));
    }
    catch (Exception ex)
    {
      string str = $"Vertices: {Vertices.Count.ToString()} - RefPoint: {RefPoint.ToString()} - Plane: {refPlane.ToString()} - CheckOver: {CheckOver.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool IsPointInsidePolygon(
    List<Point3D> Vertices,
    Point3D RefPoint,
    WorkPlane Plane,
    bool CheckOver)
  {
    try
    {
      double num1 = 0.0;
      if (WorkPlane.isPlaneXY(Plane))
      {
        for (int index = 0; index < Vertices.Count; ++index)
        {
          double num2 = Vertices[index].X - RefPoint.X;
          double num3 = Vertices[index].Y - RefPoint.Y;
          double num4 = Vertices[(index + 1) % Vertices.Count].X - RefPoint.X;
          double num5 = Vertices[(index + 1) % Vertices.Count].Y - RefPoint.Y;
          num1 += \u0007.\u0001.\u0001(num2, num5, num4, (buVector5) this, num3);
          if (CheckOver & index > 0 && ((F_DeleteType) this).IsPointInsideLine(Vertices[index - 1], Vertices[index], RefPoint, Plane))
            return true;
        }
      }
      if (WorkPlane.isPlaneXZ(Plane))
      {
        for (int index = 0; index < Vertices.Count; ++index)
        {
          double num6 = Vertices[index].X - RefPoint.X;
          double num7 = Vertices[index].Z - RefPoint.Z;
          double num8 = Vertices[(index + 1) % Vertices.Count].X - RefPoint.X;
          double num9 = Vertices[(index + 1) % Vertices.Count].Z - RefPoint.Z;
          num1 += \u0007.\u0001.\u0001(num6, num9, num8, (buVector5) this, num7);
        }
      }
      if (WorkPlane.isPlaneYZ(Plane))
      {
        for (int index = 0; index < Vertices.Count; ++index)
        {
          double num10 = Vertices[index].Y - RefPoint.Y;
          double num11 = Vertices[index].Z - RefPoint.Z;
          double num12 = Vertices[(index + 1) % Vertices.Count].Y - RefPoint.Y;
          double num13 = Vertices[(index + 1) % Vertices.Count].Z - RefPoint.Z;
          num1 += \u0007.\u0001.\u0001(num10, num13, num12, (buVector5) this, num11);
        }
      }
      return !(Math.Abs(num1) < Math.PI | buConversion5.EQ(Math.Abs(num1), Math.PI));
    }
    catch (Exception ex)
    {
      string str = $"Vertices: {Vertices.Count.ToString()} - RefPoint: {RefPoint.ToString()} - Plane: {Plane.ToString()} - CheckOver: {CheckOver.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool IsPointInsidePolygon(List<Point3D> Vertices, Point3D RefPoint)
  {
    return this.IsPointInsidePolygon(Vertices, RefPoint, new WorkPlane(), false);
  }

  public bool IsPointInsidePolygon(
    Point3D[] Vertices,
    Point3D RefPoint,
    WorkPlane Plane,
    bool CheckOver)
  {
    try
    {
      double num1 = 0.0;
      if (WorkPlane.isPlaneXY(Plane))
      {
        for (int index = 0; index < Vertices.Length; ++index)
        {
          double num2 = Vertices[index].X - RefPoint.X;
          double num3 = Vertices[index].Y - RefPoint.Y;
          double num4 = Vertices[(index + 1) % Vertices.Length].X - RefPoint.X;
          double num5 = Vertices[(index + 1) % Vertices.Length].Y - RefPoint.Y;
          num1 += \u0007.\u0001.\u0001(num2, num5, num4, (buVector5) this, num3);
          if (CheckOver & index > 0 && ((F_DeleteType) this).IsPointInsideLine(Vertices[index - 1], Vertices[index], RefPoint, Plane))
            return true;
        }
      }
      if (WorkPlane.isPlaneXZ(Plane))
      {
        for (int index = 0; index < Vertices.Length; ++index)
        {
          double num6 = Vertices[index].X - RefPoint.X;
          double num7 = Vertices[index].Z - RefPoint.Z;
          double num8 = Vertices[(index + 1) % Vertices.Length].X - RefPoint.X;
          double num9 = Vertices[(index + 1) % Vertices.Length].Z - RefPoint.Z;
          num1 += \u0007.\u0001.\u0001(num6, num9, num8, (buVector5) this, num7);
        }
      }
      if (WorkPlane.isPlaneYZ(Plane))
      {
        for (int index = 0; index < Vertices.Length; ++index)
        {
          double num10 = Vertices[index].Y - RefPoint.Y;
          double num11 = Vertices[index].Z - RefPoint.Z;
          double num12 = Vertices[(index + 1) % Vertices.Length].Y - RefPoint.Y;
          double num13 = Vertices[(index + 1) % Vertices.Length].Z - RefPoint.Z;
          num1 += \u0007.\u0001.\u0001(num10, num13, num12, (buVector5) this, num11);
        }
      }
      return !(Math.Abs(num1) < Math.PI | buConversion5.EQ(Math.Abs(num1), Math.PI));
    }
    catch (Exception ex)
    {
      string str = $"Vertices: {Vertices.Length.ToString()} - RefPoint: {RefPoint.ToString()} - Plane: {Plane.ToString()} - CheckOver: {CheckOver.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }
}
