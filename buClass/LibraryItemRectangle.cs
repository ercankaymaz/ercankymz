// Decompiled with JetBrains decompiler
// Type: buClass.LibraryItemRectangle
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryItemRectangle : LibraryItem
{
  public double Width = 0.0;
  public double Height = 0.0;
  public Pnt3D PointCenter = new Pnt3D();
  public RectangleDrawMode Mode = RectangleDrawMode.Normal;
  public RectangleType Type = RectangleType.Corner;
  public double Chamfer = 0.0;
  public double Radius = 0.0;

  public LibraryItemRectangle()
  {
  }

  public LibraryItemRectangle(LibraryItemRectangle data)
  {
    this.PointCenter = new Pnt3D(data.PointCenter);
    this.Width = data.Width;
    this.Height = data.Height;
    this.Rotation = data.Rotation;
    this.Plane = new WorkPlane(data.Plane);
  }

  public LibraryItemRectangle(
    Pnt3D centerpoint,
    double width,
    double height,
    double rotation,
    RectangleDrawMode drawmode,
    RectangleType type,
    double chamfer,
    double radius,
    WorkPlane plane)
  {
    this.PointCenter = new Pnt3D(centerpoint);
    this.Width = width;
    this.Height = height;
    this.Rotation = rotation;
    this.Mode = drawmode;
    this.Type = type;
    this.Chamfer = chamfer;
    this.Radius = radius;
    this.Plane = new WorkPlane(plane);
  }

  public override string ToString()
  {
    string str = "";
    if (this.Mode == RectangleDrawMode.Normal)
      str = $"Rect :  [X:{this.PointCenter.X.ToString("f3")} Y:{this.PointCenter.Y.ToString("f3")} Z:{this.PointCenter.Z.ToString("f3")}] , W: {this.Width.ToString()} , H: {this.Height.ToString()}";
    if (this.Mode == RectangleDrawMode.Round)
      str = $"Rect :  [X:{this.PointCenter.X.ToString("f3")} Y:{this.PointCenter.Y.ToString("f3")} Z:{this.PointCenter.Z.ToString("f3")}] , W: {this.Width.ToString()} , H: {this.Height.ToString()} , R: {this.Radius.ToString()}";
    if (this.Mode == RectangleDrawMode.Chamfer)
      str = $"Rect :  [X:{this.PointCenter.X.ToString("f3")} Y:{this.PointCenter.Y.ToString("f3")} Z:{this.PointCenter.Z.ToString("f3")}] , W: {this.Width.ToString()} , H: {this.Height.ToString()} , Dis: {this.Chamfer.ToString()}";
    return str;
  }
}
