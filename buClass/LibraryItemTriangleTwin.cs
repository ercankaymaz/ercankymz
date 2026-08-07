// Decompiled with JetBrains decompiler
// Type: buClass.LibraryItemTriangleTwin
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryItemTriangleTwin : LibraryItem
{
  public double Width = 0.0;
  public double Height = 5.0;
  public Pnt3D PointCenter = new Pnt3D();

  public LibraryItemTriangleTwin()
  {
  }

  public LibraryItemTriangleTwin(LibraryItemTriangleTwin data)
  {
    this.PointCenter = new Pnt3D(data.PointCenter);
    this.Width = data.Width;
    this.Height = data.Height;
    this.Plane = new WorkPlane(data.Plane);
  }

  public LibraryItemTriangleTwin(Pnt3D centerpoint, double width, double height, WorkPlane plane)
  {
    this.PointCenter = new Pnt3D(centerpoint);
    this.Width = width;
    this.Height = height;
    this.Plane = new WorkPlane(plane);
  }

  public override string ToString()
  {
    return $"Triangle Twin :  [X:{this.PointCenter.X.ToString("f3")} Y:{this.PointCenter.Y.ToString("f3")} Z:{this.PointCenter.Z.ToString("f3")}] , W: {this.Width.ToString()} , H: {this.Height.ToString()}";
  }
}
