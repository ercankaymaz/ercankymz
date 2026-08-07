// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.DirectionArrowSetting
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class DirectionArrowSetting : buSerilization5
{
  public bool Enable;
  public bool Calculated;
  public bool Selectable;
  public bool DontUseForCalculation;
  public bool isUpperEntity;

  public DirectionArrowSetting(Point3D startPoint, double width, double height)
  {
    ((EntityDataSet) this).StartPoint = new Point3D();
    ((EntityDataSet) this).Width = 0.0;
    ((EntityDataSet) this).Height = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((EntityDataSet) this).StartPoint = F_NotchEdit.ToPoint3D(startPoint);
    ((EntityDataSet) this).Width = width;
    ((EntityDataSet) this).Height = height;
  }

  public DirectionArrowSetting(double width, double height)
  {
    ((EntityDataSet) this).StartPoint = new Point3D();
    ((EntityDataSet) this).Width = 0.0;
    ((EntityDataSet) this).Height = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((EntityDataSet) this).StartPoint = new Point3D();
    ((EntityDataSet) this).Width = width;
    ((EntityDataSet) this).Height = height;
  }

  public static void Rectangle3DToVertices(Rectangle2D rect, ref List<Point3D> Vertices)
  {
    Vertices = new List<Point3D>();
    Vertices.Add(new Point3D(((EntityDataSet) rect).StartPoint.X, ((EntityDataSet) rect).StartPoint.Y));
    Vertices.Add(new Point3D(((EntityDataSet) rect).StartPoint.X + ((EntityDataSet) rect).Width, ((EntityDataSet) rect).StartPoint.Y));
    Vertices.Add(new Point3D(((EntityDataSet) rect).StartPoint.X + ((EntityDataSet) rect).Width, ((EntityDataSet) rect).StartPoint.Y + ((EntityDataSet) rect).Height));
    Vertices.Add(new Point3D(((EntityDataSet) rect).StartPoint.X, ((EntityDataSet) rect).StartPoint.Y + ((EntityDataSet) rect).Height));
    Vertices.Add(new Point3D(((EntityDataSet) rect).StartPoint.X, ((EntityDataSet) rect).StartPoint.Y));
  }
}
