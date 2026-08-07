// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace \u0084;

internal class \u0001
{
  public string StyleName;
  public bool Simplify;
  public Text.alignmentType Alignment;
  public Point3D InsertionPoint;
  public static byte f0038A7;
  public Plane Plane;
  public string TextString;
  public double RectWidth;
  public double Height;
  public double LineSpaceDistance;
  public string StyleName;
  public bool Simplify;
  public bool Wrap;
  public Text.alignmentType Alignment;
  public Point3D InsertionPoint;
  public static byte f0038B2;
  public List<buEntity> Entities;
  public List<Point3D> Points;

  public \u0001(double width, double height)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((LinearPath) this).\u002Ector(width, height);
  }
}
