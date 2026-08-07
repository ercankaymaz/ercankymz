// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.AnchorArea
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing;

[Serializable]
public class AnchorArea : ICloneable, IComparable
{
  [DefaultValue(float.NaN)]
  public float Right = float.NaN;
  [DefaultValue(float.NaN)]
  public float Left = float.NaN;
  [DefaultValue(false)]
  public bool Center;
  [DefaultValue(float.NaN)]
  public float Top = float.NaN;
  [DefaultValue(float.NaN)]
  public float Bottom = float.NaN;
  [DefaultValue(false)]
  public bool Middle;

  public AnchorArea()
  {
  }

  public AnchorArea(float left, float top, float right, float bottom, bool center, bool middle)
  {
    this.Left = left;
    this.Top = top;
    this.Right = right;
    this.Bottom = bottom;
    this.Center = center;
    this.Middle = middle;
  }

  public AnchorArea(AnchorArea other)
  {
    this.Right = other.Right;
    this.Left = other.Left;
    this.Bottom = other.Bottom;
    this.Top = other.Top;
    this.Center = other.Center;
    this.Middle = other.Middle;
  }

  public AnchorArea(ContentAlignment aligment, bool stretch)
  {
    if (Utilities.IsBottom(aligment) | stretch)
      this.Bottom = 0.0f;
    if (Utilities.IsLeft(aligment) | stretch)
      this.Left = 0.0f;
    if (Utilities.IsRight(aligment) | stretch)
      this.Right = 0.0f;
    if (Utilities.IsTop(aligment) | stretch)
      this.Top = 0.0f;
    if ((!Utilities.IsCenter(aligment) ? 0 : (!stretch ? 1 : 0)) != 0)
      this.Center = true;
    if ((!Utilities.IsMiddle(aligment) ? 0 : (!stretch ? 1 : 0)) == 0)
      return;
    this.Middle = true;
  }

  public static AnchorArea Empty => new AnchorArea();

  public bool IsEmpty
  {
    get
    {
      return !this.HasRight && !this.HasLeft && !this.HasTop && !this.HasBottom && !this.Middle && !this.Center;
    }
  }

  public bool HasRight => !float.IsNaN(this.Right);

  public bool HasLeft => !float.IsNaN(this.Left);

  public bool HasTop => !float.IsNaN(this.Top);

  public bool HasBottom => !float.IsNaN(this.Bottom);

  public override string ToString()
  {
    return $"Top {this.Top.ToString()}, Bottom {this.Bottom.ToString()}, Right {this.Right.ToString()}, Left {this.Left.ToString()}";
  }

  public override int GetHashCode()
  {
    return (int) ((double) this.Top + (double) this.Bottom + (double) this.Left + (double) this.Right);
  }

  public override bool Equals(object obj) => this.CompareTo(obj) == 0;

  public object Clone() => (object) new AnchorArea(this);

  public int CompareTo(object obj)
  {
    int num1;
    if (obj == null)
    {
      num1 = 1;
    }
    else
    {
      AnchorArea anchorArea = obj is AnchorArea ? (AnchorArea) obj : throw new ArgumentException("Invalid object, AnchorArea expected");
      int num2 = this.Top.CompareTo(anchorArea.Top);
      int num3 = this.Bottom.CompareTo(anchorArea.Bottom);
      int num4 = this.Left.CompareTo(anchorArea.Left);
      int num5 = this.Right.CompareTo(anchorArea.Right);
      int num6 = this.Center.CompareTo(anchorArea.Center);
      int num7 = this.Middle.CompareTo(anchorArea.Middle);
      num1 = num2 <= 1 ? (num2 >= 1 ? (num3 <= 1 ? (num3 >= 1 ? (num5 <= 1 ? (num5 >= 1 ? (num4 <= 1 ? (num4 >= 1 ? (num6 <= 1 ? (num6 >= 1 ? (num7 <= 1 ? (num7 >= 1 ? 0 : -1) : 1) : -1) : 1) : -1) : 1) : -1) : 1) : -1) : 1) : -1) : 1;
    }
    return num1;
  }

  public static bool operator ==(AnchorArea a, AnchorArea b)
  {
    return (object) a == (object) b || ((object) a == null ? 1 : ((object) b == null ? 1 : 0)) == 0 && a.Equals((object) b);
  }

  public static bool operator !=(AnchorArea a, AnchorArea b) => !(a == b);

  public static RectangleF CalculateArea(RectangleF area, SizeF content, AnchorArea anchor)
  {
    RectangleF area1;
    if (anchor.IsEmpty)
    {
      area1 = area;
    }
    else
    {
      RectangleF rectangleF = new RectangleF();
      if (anchor.Center)
      {
        rectangleF.X = (float) ((double) area.X + (double) area.Width / 2.0 - (double) content.Width / 2.0);
        rectangleF.Width = content.Width;
      }
      else if ((!anchor.HasLeft ? 0 : (anchor.HasRight ? 1 : 0)) != 0)
      {
        rectangleF.X = area.Left + anchor.Left;
        rectangleF.Width = area.Width - (anchor.Left + anchor.Right);
      }
      else if (anchor.HasLeft)
      {
        rectangleF.X = area.Left + anchor.Left;
        rectangleF.Width = content.Width;
      }
      else if (anchor.HasRight)
      {
        rectangleF.X = area.Right - content.Width - anchor.Right;
        rectangleF.Width = content.Width;
      }
      else
      {
        rectangleF.X = area.Left;
        rectangleF.Width = content.Width;
      }
      if (anchor.Middle)
      {
        rectangleF.Y = (float) ((double) area.Y + (double) area.Height / 2.0 - (double) content.Height / 2.0);
        rectangleF.Height = content.Height;
      }
      else if ((!anchor.HasTop ? 0 : (anchor.HasBottom ? 1 : 0)) != 0)
      {
        rectangleF.Y = area.Top + anchor.Top;
        rectangleF.Height = area.Height - (anchor.Top + anchor.Bottom);
      }
      else if (anchor.HasTop)
      {
        rectangleF.Y = area.Top + anchor.Top;
        rectangleF.Height = content.Height;
      }
      else if (anchor.HasBottom)
      {
        rectangleF.Y = area.Bottom - content.Height - anchor.Bottom;
        rectangleF.Height = content.Height;
      }
      else
      {
        rectangleF.Y = area.Top;
        rectangleF.Height = content.Height;
      }
      rectangleF.Intersect(area);
      area1 = rectangleF;
    }
    return area1;
  }
}
