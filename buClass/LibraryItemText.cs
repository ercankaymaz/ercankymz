// Decompiled with JetBrains decompiler
// Type: buClass.LibraryItemText
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryItemText : LibraryItem
{
  public double Height = 0.0;
  public string Text = "";
  public Font TextFont = new Font("Arial", 16f);
  public Pnt3D PointCenter = new Pnt3D();
  public ContentAlignment Alignment = ContentAlignment.BottomLeft;

  public LibraryItemText()
  {
  }

  public LibraryItemText(LibraryItemText data)
  {
    this.PointCenter = new Pnt3D(data.PointCenter);
    this.Height = data.Height;
    this.Text = data.Text;
    this.Alignment = data.Alignment;
    this.TextFont = data.TextFont;
    this.Plane = new WorkPlane(data.Plane);
  }

  public LibraryItemText(
    Pnt3D centerpoint,
    double height,
    string text,
    Font font,
    ContentAlignment alignment,
    WorkPlane plane)
  {
    this.PointCenter = new Pnt3D(centerpoint);
    this.Height = height;
    this.Text = text;
    this.Alignment = alignment;
    this.TextFont = font;
    this.Plane = new WorkPlane(plane);
  }

  public override string ToString()
  {
    return $"Text :  [X:{this.PointCenter.X.ToString("f3")} Y:{this.PointCenter.Y.ToString("f3")} Z:{this.PointCenter.Z.ToString("f3")}] , Text: {this.Text.ToString()} , H: {this.Height.ToString()}";
  }
}
