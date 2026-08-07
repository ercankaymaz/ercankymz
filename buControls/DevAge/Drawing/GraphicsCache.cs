// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.GraphicsCache
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing;

public class GraphicsCache : IDisposable
{
  private Rectangle clipRectangle;
  private Graphics graphics;
  private PensCache pensCache_0;
  private BrushsCache brushsCache_0;

  public GraphicsCache(Graphics graphics)
  {
    this.graphics = graphics;
    this.clipRectangle = Rectangle.Empty;
    this.pensCache_0 = new PensCache(20);
    this.brushsCache_0 = new BrushsCache(20);
  }

  public GraphicsCache(Graphics graphics, Rectangle clipRectangle)
  {
    this.graphics = graphics;
    this.clipRectangle = clipRectangle;
    this.pensCache_0 = new PensCache(20);
    this.brushsCache_0 = new BrushsCache(20);
  }

  public GraphicsCache(
    Graphics graphics,
    Rectangle clipRectangle,
    int pensCapacity,
    int brushsCapacity)
  {
    this.graphics = graphics;
    this.clipRectangle = clipRectangle;
    this.pensCache_0 = new PensCache(pensCapacity);
    this.brushsCache_0 = new BrushsCache(brushsCapacity);
  }

  public Rectangle ClipRectangle => this.clipRectangle;

  public Graphics Graphics => this.graphics;

  public PensCache PensCache => this.pensCache_0;

  public BrushsCache BrushsCache => this.brushsCache_0;

  public void Dispose()
  {
    this.pensCache_0.Dispose();
    this.pensCache_0 = (PensCache) null;
    this.brushsCache_0.Dispose();
    this.brushsCache_0 = (BrushsCache) null;
    this.graphics = (Graphics) null;
  }
}
