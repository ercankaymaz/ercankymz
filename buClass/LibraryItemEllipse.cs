// Decompiled with JetBrains decompiler
// Type: buClass.LibraryItemEllipse
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryItemEllipse : LibraryItem
{
  public double MajorRadius = 0.0;
  public double MinorRadius = 0.0;
  public Pnt3D PointCenter = new Pnt3D();

  public LibraryItemEllipse()
  {
  }

  public LibraryItemEllipse(LibraryItemEllipse data)
  {
    this.PointCenter = new Pnt3D(data.PointCenter);
    this.MajorRadius = data.MajorRadius;
    this.MinorRadius = data.MinorRadius;
    this.Plane = new WorkPlane(data.Plane);
  }

  public LibraryItemEllipse(
    Pnt3D centerpoint,
    double majorrad,
    double minorrad,
    double rotation,
    WorkPlane plane)
  {
    this.PointCenter = new Pnt3D(centerpoint);
    this.MajorRadius = majorrad;
    this.MinorRadius = minorrad;
    this.Rotation = rotation;
    this.Plane = new WorkPlane(plane);
  }

  public override string ToString()
  {
    return $"Ellipse Center :  [X:{this.PointCenter.X.ToString("f3")} Y:{this.PointCenter.Y.ToString("f3")} Z:{this.PointCenter.Z.ToString("f3")}] , Major R: {this.MajorRadius.ToString()} , Minor R: {this.MinorRadius.ToString()}";
  }
}
