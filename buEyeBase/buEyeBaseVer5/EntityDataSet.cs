// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.EntityDataSet
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class EntityDataSet : buSerilization5
{
  public int CamID;
  public int ItemID;
  public int EdgeID;
  public int CamToolNo;
  public string EntityName;
  public string CamCode;
  public string ID;
  public string Tags;
  public string Data;
  public double AuxVal;
  public double Length;
  public double Radius;
  public Point3D Offset;
  public PointABC OffsetABC;
  public OrientationAngle OffsetAngle;
  public List<string> Commands;
  public List<string> Options;
  public entityOriginalType OrjType;
  public static byte f000530;
  public Point3D notchPoint;
  public static byte f000532;
  public Point3D StartPoint;
  public double Width;
  public double Height;
  public static byte f000536;
  public Point3D StartPoint;

  public static void Rectangle3DToVertices(
    Point3D CornerPoint,
    double dX,
    double dY,
    ref List<Point3D> Vertices)
  {
    Vertices = new List<Point3D>();
    Vertices.Add(new Point3D(CornerPoint.X, CornerPoint.Y));
    Vertices.Add(new Point3D(CornerPoint.X + dX, CornerPoint.Y));
    Vertices.Add(new Point3D(CornerPoint.X + dX, CornerPoint.Y + dY));
    Vertices.Add(new Point3D(CornerPoint.X, CornerPoint.Y + dY));
    Vertices.Add(new Point3D(CornerPoint.X, CornerPoint.Y));
  }

  public static void Rectangle2DCenter(Rectangle2D rect, ref Point3D Center)
  {
    Center = new Point3D(((EntityDataSet) rect).StartPoint.X + ((EntityDataSet) rect).Width / 2.0, ((EntityDataSet) rect).StartPoint.Y + ((EntityDataSet) rect).Height / 2.0);
  }

  public static Rectangle2D Copy(Rectangle2D P)
  {
    return (Rectangle2D) new DirectionArrowSetting(((EntityDataSet) P).StartPoint, ((EntityDataSet) P).Width, ((EntityDataSet) P).Height);
  }

  public static Rectangle2D[] Copy(Rectangle2D[] pts)
  {
    Rectangle2D[] rectangle2DArray = new Rectangle2D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      rectangle2DArray[index] = EntityDataSet.Copy(pts[index]);
    return rectangle2DArray;
  }

  public static List<Rectangle2D> Copy(List<Rectangle2D> pts)
  {
    List<Rectangle2D> rectangle2DList = new List<Rectangle2D>();
    for (int index = 0; index < pts.Count; ++index)
      rectangle2DList.Add(EntityDataSet.Copy(pts[index]));
    return rectangle2DList;
  }

  public static void Copy(List<Rectangle2D> pts, ref List<Rectangle2D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(EntityDataSet.Copy(pts[index]));
  }
}
