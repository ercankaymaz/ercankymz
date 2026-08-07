// Decompiled with JetBrains decompiler
// Type: buClass.LibraryItemPolygon
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryItemPolygon : LibraryItem
{
  public double Radius = 0.0;
  public int Sides = 5;
  public Pnt3D PointCenter = new Pnt3D();

  public LibraryItemPolygon()
  {
  }

  public LibraryItemPolygon(LibraryItemPolygon data)
  {
    this.PointCenter = new Pnt3D(data.PointCenter);
    this.Radius = data.Radius;
    this.Sides = data.Sides;
    this.Plane = new WorkPlane(data.Plane);
  }

  public LibraryItemPolygon(Pnt3D centerpoint, double rad, int sides, WorkPlane plane)
  {
    this.PointCenter = new Pnt3D(centerpoint);
    this.Radius = rad;
    this.Sides = sides;
    this.Plane = new WorkPlane(plane);
  }

  public override string ToString()
  {
    return $"Polygon Center :  [X:{this.PointCenter.X.ToString("f3")} Y:{this.PointCenter.Y.ToString("f3")} Z:{this.PointCenter.Z.ToString("f3")}] , R: {this.Radius.ToString()} , Sides: {this.Sides.ToString()}";
  }
}
