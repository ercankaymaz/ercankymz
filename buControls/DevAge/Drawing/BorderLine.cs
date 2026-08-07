// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.BorderLine
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

#nullable disable
namespace DevAge.Drawing;

[Serializable]
public struct BorderLine
{
  public static readonly BorderLine NoBorder = new BorderLine(Color.White, 0.0f);
  public static readonly BorderLine Black1Width = new BorderLine(Color.Black, 1f);
  [DefaultValue(0)]
  public float Width;
  public Color Color;
  [DefaultValue(DashStyle.Solid)]
  public DashStyle DashStyle;
  [DefaultValue(0)]
  public float Padding;

  public BorderLine(Color p_Color)
  {
    this.Color = p_Color;
    this.Width = 1f;
    this.DashStyle = DashStyle.Solid;
    this.Padding = 0.0f;
  }

  public BorderLine(Color p_Color, float p_Width)
  {
    this.Width = p_Width;
    this.Color = p_Color;
    this.DashStyle = DashStyle.Solid;
    this.Padding = 0.0f;
  }

  public BorderLine(Color p_Color, float p_Width, DashStyle dashStyle)
  {
    this.Width = p_Width;
    this.Color = p_Color;
    this.DashStyle = dashStyle;
    this.Padding = 0.0f;
  }

  public BorderLine(Color p_Color, float p_Width, DashStyle dashStyle, float padding)
  {
    this.Width = p_Width;
    this.Color = p_Color;
    this.DashStyle = dashStyle;
    this.Padding = padding;
  }

  public override string ToString()
  {
    return $"{this.Color.ToString()}, Width= {this.Width.ToString()}, DashStyle= {this.DashStyle.ToString()}";
  }

  public override bool Equals(object obj)
  {
    bool flag;
    if (obj == null)
      flag = false;
    else if (obj.GetType() != this.GetType())
    {
      flag = false;
    }
    else
    {
      BorderLine borderLine = (BorderLine) obj;
      flag = ((double) borderLine.Width != (double) this.Width || !(borderLine.Color == this.Color) || borderLine.DashStyle != this.DashStyle ? 0 : ((double) borderLine.Padding == (double) this.Padding ? 1 : 0)) != 0;
    }
    return flag;
  }

  public override int GetHashCode() => this.Color.GetHashCode();

  public static bool operator ==(BorderLine a, BorderLine b) => a.Equals((object) b);

  public static bool operator !=(BorderLine a, BorderLine b) => !a.Equals((object) b);
}
