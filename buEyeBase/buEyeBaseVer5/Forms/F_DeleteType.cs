// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_DeleteType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_DeleteType : Form
{
  public bool ExplodeCircleToPolyline;
  public bool ExplodeArcToPolyline;
  public bool ExplodeEllipseToPolyline;
  public bool ExplodeCurveToPolyline;
  public bool ExplodePolylineToLine;
  public string pathFromFile;
  public static byte f000A90;
  public int DrawingIndex;
  public Entity FinshedEntity;
  internal static ResourceManager \u0001;
  internal static CultureInfo \u0001;
  public static List<string> Captions;
  public CutterProgramSettings Settings;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal Label \u0003;
  internal Panel \u0001;
  internal NumericUpDown \u0002;
  internal Panel \u0002;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Label \u0004;
  public static byte f000AA4;
  public static List<string> Captions;

  public bool IsPointInsideLine(
    Point3D LineStart,
    Point3D LineEnd,
    Point3D RefPoint,
    WorkPlane Plane)
  {
    int ClosestPoint = 0;
    return this.IsPointInsideLine(LineStart, LineEnd, RefPoint, Plane, buSystem.resolutionCompare, ref ClosestPoint);
  }

  public bool IsPointInsideLine(
    Point3D LineStart,
    Point3D LineEnd,
    Point3D RefPoint,
    WorkPlane Plane,
    double Resolution)
  {
    int ClosestPoint = 0;
    return this.IsPointInsideLine(LineStart, LineEnd, RefPoint, Plane, Resolution, ref ClosestPoint);
  }

  public bool IsPointInsideLine(
    Point3D LineStart,
    Point3D LineEnd,
    Point3D RefPoint,
    WorkPlane Plane,
    double Resolution,
    ref int ClosestPoint)
  {
    double InsideDistance = 0.0;
    return this.IsPointInsideLine(LineStart, LineEnd, RefPoint, Plane, Resolution, ref ClosestPoint, ref InsideDistance);
  }

  public bool IsPointInsideLine(
    Point3D LineStart,
    Point3D LineEnd,
    Point3D RefPoint,
    WorkPlane Plane,
    double Resolution,
    ref int ClosestPoint,
    ref double InsideDistance)
  {
    try
    {
      double num1 = ((buVector5) this).Length3D(LineStart, LineEnd, Plane);
      double num2 = ((buVector5) this).Length3D(LineEnd, RefPoint, Plane);
      double num3 = ((buVector5) this).Length3D(LineStart, RefPoint, Plane);
      double num4 = num2 + num3;
      ClosestPoint = -1;
      if (num3 < num2)
      {
        ClosestPoint = 0;
        InsideDistance = num3;
      }
      else
      {
        ClosestPoint = 1;
        InsideDistance = num2;
      }
      if (buConversion5.EQ(num4, num1, Resolution))
        return true;
      InsideDistance *= -1.0;
      return false;
    }
    catch (Exception ex)
    {
      string str = $"LineStart: {LineStart.ToString()} - LineEnd: {LineEnd.ToString()} - RefPoint: {RefPoint.ToString()} - Plane: {Plane.ToString()} - Resolution: {Resolution.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool IsPointInsideLine(
    Point3D LineStart,
    Point3D LineEnd,
    Point3D RefPoint,
    Plane refPlane,
    double Resolution)
  {
    try
    {
      double num = ((buVector5) this).Length3D(LineStart, LineEnd, refPlane);
      return buConversion5.EQ(((buVector5) this).Length3D(LineEnd, RefPoint, refPlane) + ((buVector5) this).Length3D(LineStart, RefPoint, refPlane), num, Resolution);
    }
    catch (Exception ex)
    {
      string str = $"LineStart: {LineStart.ToString()} - LineEnd: {LineEnd.ToString()} - RefPoint: {RefPoint.ToString()} - Plane: {refPlane.ToString()} - Resolution: {Resolution.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool IsEntitiesClosedPath(List<Entity> RefEntities)
  {
    try
    {
      Point3D point3D1 = new Point3D();
      Point3D point3D2 = new Point3D(10.0, 10.0, 10.0);
      if (RefEntities.Count > 1)
      {
        point3D1 = ((CutterIsoFileItems) RefEntities[0].EntityData).get_sortDirection() != entitySortDirection.Normal ? F_NotchEdit.ToPoint3D(RefEntities[0].Vertices[RefEntities[0].Vertices.Length - 1]) : F_NotchEdit.ToPoint3D(RefEntities[0].Vertices[0]);
        point3D2 = ((CutterIsoFileItems) RefEntities[RefEntities.Count - 1].EntityData).get_sortDirection() != entitySortDirection.Normal ? F_NotchEdit.ToPoint3D(RefEntities[RefEntities.Count - 1].Vertices[0]) : F_NotchEdit.ToPoint3D(RefEntities[RefEntities.Count - 1].Vertices[RefEntities[RefEntities.Count - 1].Vertices.Length - 1]);
      }
      if (RefEntities.Count == 1 && RefEntities[0].Vertices.Length > 2)
      {
        point3D1 = F_NotchEdit.ToPoint3D(RefEntities[0].Vertices[0]);
        point3D2 = F_NotchEdit.ToPoint3D(RefEntities[0].Vertices[RefEntities[0].Vertices.Length - 1]);
      }
      return buConversion5.EQ(point3D1, point3D2);
    }
    catch (Exception ex)
    {
      string str = "RefEntities: " + RefEntities.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool IsEntitiesClosedPath(List<buEntity> RefEntities)
  {
    try
    {
      Point3D point3D1 = new Point3D();
      Point3D point3D2 = new Point3D(10.0, 10.0, 10.0);
      if (RefEntities.Count > 1)
      {
        point3D1 = ((CustomData) RefEntities[0]).sortDirection != entitySortDirection.Normal ? F_NotchEdit.ToPoint3D(((CustomData) RefEntities[0]).EndPoint) : F_NotchEdit.ToPoint3D(((CustomData) RefEntities[0]).StartPoint);
        point3D2 = ((CustomData) RefEntities[RefEntities.Count - 1]).sortDirection != entitySortDirection.Normal ? F_NotchEdit.ToPoint3D(((CustomData) RefEntities[RefEntities.Count - 1]).StartPoint) : F_NotchEdit.ToPoint3D(((CustomData) RefEntities[RefEntities.Count - 1]).EndPoint);
      }
      if (RefEntities.Count == 1)
      {
        point3D1 = F_NotchEdit.ToPoint3D(((CustomData) RefEntities[0]).StartPoint);
        point3D2 = F_NotchEdit.ToPoint3D(((CustomData) RefEntities[0]).EndPoint);
      }
      return buConversion5.EQ(point3D1, point3D2);
    }
    catch (Exception ex)
    {
      string str = "RefEntities: " + RefEntities.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public double GetTimeFromDistanceAndAcc(double Distance, double Acc)
  {
    return Math.Sqrt(2.0 * Distance / Acc);
  }

  public void SaveDxfFile(string FileName, Design refModel)
  {
    WriteFileAsync writeFileAsync = (WriteFileAsync) new WriteAutodesk(new WriteAutodeskParams(refModel.Document)
    {
      Version = autodeskVersionType.Acad2010
    }, FileName);
    refModel.DoWork((WorkUnit) writeFileAsync);
  }

  public void ReadDxfFile(string FileName, Design refModel, ref List<Entity> Entities)
  {
    ReadFileAsync readFileAsync = (ReadFileAsync) new ReadAutodesk(FileName);
    ((ReadAutodesk) readFileAsync).ExtrudeByThickness = false;
    readFileAsync.DoWork();
    if (readFileAsync.Entities == null)
      return;
    Entities.AddRange((IEnumerable<Entity>) readFileAsync.Entities);
  }

  public void ReadStlFile(string FileName, ref List<Entity> Entities)
  {
    ReadSTL readStl = new ReadSTL(FileName);
    readStl.DoWork();
    if (readStl.Entities == null)
      return;
    Entities.AddRange((IEnumerable<Entity>) readStl.Entities);
  }

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public event ApplyCommandWithDataEventHandler CommandApply;
}
