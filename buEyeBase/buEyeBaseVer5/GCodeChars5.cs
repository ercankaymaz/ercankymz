// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.GCodeChars5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class GCodeChars5 : buSerilization5
{
  public selectionFilterType Type;
  public Point3D PointOverEntity;
  public Point3D BoxMin;
  public Point3D BoxMax;
  public static byte f00087B;
  public List<Point3D> Points;
  public double Length;
  public string Text;
  public Point3D PntText;
  public Color Color;
  public float Size;
  public static byte f000882;
  public string Action;
  public double Radius;
  public double HeadRadius;
  public double MajorRadius;
  public double MinorRadius;
  public double Width;
  public double Height;

  public GCodeChars5()
  {
    ((ShapeRuntimeData) this).MinBox = new Point3D();
    ((ShapeRuntimeData) this).MaxBox = new Point3D();
    ((ShapeRuntimeData) this).CenterPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
