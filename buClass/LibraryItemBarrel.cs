// Decompiled with JetBrains decompiler
// Type: buClass.LibraryItemBarrel
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryItemBarrel : LibraryItem
{
  public Pnt3D HeadPoint = new Pnt3D();
  public double HeadRadius = 0.0;
  public double Width = 0.0;
  public double Height = 0.0;

  public LibraryItemBarrel()
  {
  }

  public LibraryItemBarrel(LibraryItemBarrel data)
  {
    this.HeadPoint = new Pnt3D(data.HeadPoint);
    this.HeadRadius = data.HeadRadius;
    this.Width = data.Width;
    this.Height = data.Height;
    this.Rotation = data.Rotation;
    this.Plane = new WorkPlane(data.Plane);
  }

  public LibraryItemBarrel(
    Pnt3D headpoint,
    double headradius,
    double width,
    double height,
    double rotation,
    WorkPlane plane)
  {
    this.HeadPoint = new Pnt3D(headpoint);
    this.HeadRadius = headradius;
    this.Width = width;
    this.Height = height;
    this.Rotation = rotation;
    this.Plane = new WorkPlane(plane);
  }

  public override string ToString()
  {
    return $"Barrel :  [X:{this.HeadPoint.X.ToString("f3")} Y:{this.HeadPoint.Y.ToString("f3")} Z:{this.HeadPoint.Z.ToString("f3")}] , Head R: {this.HeadRadius.ToString()} , W: {this.Width.ToString()} , H: {this.Height.ToString()}";
  }
}
