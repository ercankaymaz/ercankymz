// Decompiled with JetBrains decompiler
// Type: buClass.DxfText
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class DxfText : buSerilization
{
  public string Text = "";
  public double Height = 10.0;
  public Pnt3D StartPoint = new Pnt3D();
  public double Rotation = 0.0;
  public string Layer = "";
  public Color Color = Color.Black;

  public DxfText()
  {
  }

  public DxfText(DxfText data)
  {
    this.Color = data.Color;
    this.Height = data.Height;
    this.Layer = data.Layer;
    this.Rotation = data.Rotation;
    this.StartPoint = new Pnt3D(data.StartPoint);
    this.Text = data.Text;
  }
}
