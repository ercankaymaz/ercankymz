// Decompiled with JetBrains decompiler
// Type: buClass.LibraryItemSlot
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryItemSlot : LibraryItem
{
  public double Width = 0.0;
  public double Height = 0.0;
  public Pnt3D PointBase = new Pnt3D();

  public LibraryItemSlot()
  {
  }

  public LibraryItemSlot(LibraryItemSlot data)
  {
    this.PointBase = new Pnt3D(data.PointBase);
    this.Width = data.Width;
    this.Height = data.Height;
    this.Plane = new WorkPlane(data.Plane);
  }

  public LibraryItemSlot(
    Pnt3D basepoint,
    double width,
    double height,
    double rotation,
    WorkPlane plane)
  {
    this.PointBase = new Pnt3D(basepoint);
    this.Width = width;
    this.Height = height;
    this.Rotation = rotation;
    this.Plane = new WorkPlane(plane);
  }

  public override string ToString()
  {
    return $"Slot :  [X:{this.PointBase.X.ToString("f3")} Y:{this.PointBase.Y.ToString("f3")} Z:{this.PointBase.Z.ToString("f3")}] , W: {this.Width.ToString()} , H: {this.Height.ToString()}";
  }
}
