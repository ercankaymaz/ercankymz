// Decompiled with JetBrains decompiler
// Type: buClass.geoText
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoText : geoEntity
{
  public string TextString = "";
  public Pnt3D StartPoint = new Pnt3D();
  public double Height = 10.0;
  public double Angle = 0.0;
  public Font TextFont = new Font("Times New Roman", 12f);

  public geoText()
  {
  }

  public geoText(geoText text)
  {
    this.StartPoint = new Pnt3D(text.StartPoint);
    this.TextString = text.TextString;
    this.Height = text.Height;
    this.Color = text.Color;
    this.TextFont = new Font(text.TextFont.FontFamily, text.TextFont.Size, text.TextFont.Style);
    this.Angle = text.Angle;
    this.TypeDefination = text.TypeDefination;
    this.isText = text.isText;
  }

  public geoText(
    Pnt3D startpnt,
    string text,
    Font fnt,
    Color color,
    double height,
    double angle)
  {
    this.StartPoint = new Pnt3D(startpnt);
    this.TextString = text;
    this.Height = height;
    this.TextFont = new Font(fnt.FontFamily, fnt.Size, fnt.Style);
    this.Color = color;
    this.Angle = angle;
  }

  public geoText(
    Pnt3D startpnt,
    string text,
    Font fnt,
    Color color,
    double height,
    double angle,
    int layer)
  {
    this.StartPoint = new Pnt3D(startpnt);
    this.TextString = text;
    this.Height = height;
    this.TextFont = new Font(fnt.FontFamily, fnt.Size, fnt.Style);
    this.Color = color;
    this.Angle = angle;
    this.Layer = layer;
  }

  public override string ToString()
  {
    return $"[X:{this.StartPoint.X.ToString("f3")} Y:{this.StartPoint.Y.ToString("f3")} Z:{this.StartPoint.Z.ToString("f3")}] ; {this.TextString}";
  }
}
