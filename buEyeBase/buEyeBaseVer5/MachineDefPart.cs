// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MachineDefPart
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

public class MachineDefPart : buSerilization5
{
  public bool Enable;
  public int IndexEntity;
  public List<int> IndexEntityList;
  public string Explanation;
  public Point3D pntError;
  public AnalyseEntitiesResultErrorType ErrorType;
  public AnalyseEntitiesActionType Action;
  public static byte f000554;
  public bool Enable;
  public int ArrowPointCount;
  public double MinLength;
  public double ArrowLength;
  public double ArrowAngle;
  public static byte f00055A;
  public string SceneName;
  public string EntityName;
  public string ActionName;

  public MachineDefPart(double dX, double dY)
  {
    ((EntityDataSet) this).StartPoint = new Point3D();
    ((EntitiesCopySettings) this).EndPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((EntityDataSet) this).StartPoint = new Point3D();
    ((EntitiesCopySettings) this).EndPoint = new Point3D(dX, dY);
  }

  public static void Line2DToVertices(Line2D line, ref List<Point3D> Vertices)
  {
    Vertices = new List<Point3D>();
    Vertices.Add(new Point3D(((EntityDataSet) line).StartPoint.X, ((EntityDataSet) line).StartPoint.Y));
    Vertices.Add(new Point3D(((EntitiesCopySettings) line).EndPoint.X, ((EntitiesCopySettings) line).EndPoint.Y));
  }

  public static Line2D Copy(Line2D P)
  {
    return (Line2D) new MachineDef(((EntityDataSet) P).StartPoint, ((EntitiesCopySettings) P).EndPoint);
  }
}
