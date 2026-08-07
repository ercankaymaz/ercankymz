// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.BrushsCache
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing;

public class BrushsCache : IDisposable
{
  private SolidBrush[] solidBrush_0;
  private Color[] color_0;
  private List<SolidBrush> list_0 = new List<SolidBrush>();

  public BrushsCache(int maxCapacity)
  {
    this.solidBrush_0 = new SolidBrush[maxCapacity];
    this.color_0 = new Color[maxCapacity];
  }

  public SolidBrush GetBrush(Color color)
  {
    SolidBrush brush;
    for (int index = 0; index < this.solidBrush_0.Length; ++index)
    {
      if (this.solidBrush_0[index] != null)
      {
        if (this.color_0[index].Equals((object) color))
        {
          brush = this.solidBrush_0[index];
          goto label_8;
        }
      }
      else
      {
        SolidBrush solidBrush = new SolidBrush(color);
        this.solidBrush_0[index] = solidBrush;
        this.color_0[index] = color;
        brush = solidBrush;
        goto label_8;
      }
    }
    SolidBrush solidBrush1 = new SolidBrush(color);
    this.list_0.Add(solidBrush1);
    brush = solidBrush1;
label_8:
    return brush;
  }

  public void Dispose()
  {
    for (int index = 0; index < this.solidBrush_0.Length; ++index)
    {
      if (this.solidBrush_0[index] != null)
      {
        this.solidBrush_0[index].Dispose();
        this.solidBrush_0[index] = (SolidBrush) null;
      }
    }
    foreach (Brush brush in this.list_0)
      brush.Dispose();
  }
}
