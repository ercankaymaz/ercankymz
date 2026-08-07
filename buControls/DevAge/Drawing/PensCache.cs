// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.PensCache
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

#nullable disable
namespace DevAge.Drawing;

public class PensCache : IDisposable
{
  private Pen[] pen_0;
  private PensCache.Struct1[] struct1_0;
  private List<Pen> list_0 = new List<Pen>();

  public PensCache(int maxCapacity)
  {
    this.pen_0 = new Pen[maxCapacity];
    this.struct1_0 = new PensCache.Struct1[maxCapacity];
  }

  public Pen GetPen(Color color, float width, DashStyle style)
  {
    PensCache.Struct1 other;
    other.color_0 = color;
    other.float_0 = width;
    other.dashStyle_0 = style;
    Pen pen1;
    for (int index = 0; index < this.pen_0.Length; ++index)
    {
      if (this.pen_0[index] != null)
      {
        if (this.struct1_0[index].System\u002EIEquatable\u003CDevAge\u002EDrawing\u002EPensCache\u002EStruct1\u003E\u002EEquals(other))
        {
          pen1 = this.pen_0[index];
          goto label_12;
        }
      }
      else
      {
        Pen pen2 = new Pen(color, width);
        if (pen2.DashStyle != style)
          pen2.DashStyle = style;
        this.pen_0[index] = pen2;
        this.struct1_0[index] = other;
        pen1 = pen2;
        goto label_12;
      }
    }
    Pen pen3 = new Pen(color, width);
    if (pen3.DashStyle != style)
      pen3.DashStyle = style;
    this.list_0.Add(pen3);
    pen1 = pen3;
label_12:
    return pen1;
  }

  public void Dispose()
  {
    for (int index = 0; index < this.pen_0.Length; ++index)
    {
      if (this.pen_0[index] != null)
      {
        this.pen_0[index].Dispose();
        this.pen_0[index] = (Pen) null;
      }
    }
    foreach (Pen pen in this.list_0)
      pen.Dispose();
  }

  private struct Struct1 : IEquatable<PensCache.Struct1>
  {
    public Color color_0;
    public DashStyle dashStyle_0;
    public float float_0;

    public bool System\u002EIEquatable\u003CDevAge\u002EDrawing\u002EPensCache\u002EStruct1\u003E\u002EEquals(
      PensCache.Struct1 other)
    {
      return other.color_0 == this.color_0 && other.dashStyle_0 == this.dashStyle_0 && (double) other.float_0 == (double) this.float_0;
    }
  }
}
