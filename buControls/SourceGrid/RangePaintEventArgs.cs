// Decompiled with JetBrains decompiler
// Type: SourceGrid.RangePaintEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using System;

#nullable disable
namespace SourceGrid;

public class RangePaintEventArgs : EventArgs
{
  private GridVirtual grid;
  private GraphicsCache graphicsCache;
  private Range drawingRange;

  public RangePaintEventArgs(GridVirtual grid, GraphicsCache graphicsCache, Range drawingRange)
  {
    this.grid = grid;
    this.graphicsCache = graphicsCache;
    this.drawingRange = drawingRange;
  }

  public GridVirtual Grid => this.grid;

  public GraphicsCache GraphicsCache
  {
    get => this.graphicsCache;
    set => this.graphicsCache = value;
  }

  public Range DrawingRange
  {
    get => this.drawingRange;
    set => this.drawingRange = value;
  }
}
