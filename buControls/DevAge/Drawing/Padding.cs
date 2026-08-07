// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.Padding
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing;

[Serializable]
public struct Padding
{
  public static Padding Empty = new Padding();
  public float Left;
  public float Right;
  public float Top;
  public float Bottom;

  public Padding(float all)
  {
    this.Left = all;
    this.Right = all;
    this.Top = all;
    this.Bottom = all;
  }

  public Padding(float left, float right, float top, float bottom)
  {
    this.Left = left;
    this.Right = right;
    this.Top = top;
    this.Bottom = bottom;
  }

  public bool IsEmpty
  {
    get
    {
      return (double) this.Left == 0.0 && (double) this.Right == 0.0 && (double) this.Top == 0.0 && (double) this.Bottom == 0.0;
    }
  }

  public RectangleF GetContentRectangle(RectangleF backGroundArea)
  {
    return !this.IsEmpty ? new RectangleF(backGroundArea.X + this.Left, backGroundArea.Y + this.Top, backGroundArea.Width - (this.Left + this.Right), backGroundArea.Height - (this.Top + this.Bottom)) : backGroundArea;
  }

  public SizeF GetExtent(SizeF contentSize)
  {
    return !this.IsEmpty ? new SizeF(contentSize.Width + (this.Left + this.Right), contentSize.Height + (this.Top + this.Bottom)) : contentSize;
  }

  public override string ToString()
  {
    return $"Left:{this.Left.ToString()},Right:{this.Right.ToString()},Top:{this.Top.ToString()},Bottom:{this.Bottom.ToString()}";
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
      Padding padding = (Padding) obj;
      flag = ((double) padding.Top != (double) this.Top || (double) padding.Bottom != (double) this.Bottom || (double) padding.Right != (double) this.Right ? 0 : ((double) padding.Left == (double) this.Left ? 1 : 0)) != 0;
    }
    return flag;
  }

  public override int GetHashCode() => this.Top.GetHashCode();

  public static bool operator ==(Padding a, Padding b) => a.Equals((object) b);

  public static bool operator !=(Padding a, Padding b) => !a.Equals((object) b);
}
