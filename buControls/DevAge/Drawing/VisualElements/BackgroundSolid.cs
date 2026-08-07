// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.BackgroundSolid
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class BackgroundSolid : VisualElementBase
{
  private Color mBackColor = Color.Empty;

  public BackgroundSolid()
  {
  }

  public BackgroundSolid(Color backcolor) => this.BackColor = backcolor;

  public BackgroundSolid(BackgroundSolid other)
    : base((VisualElementBase) other)
  {
    this.BackColor = other.BackColor;
  }

  public virtual Color BackColor
  {
    get => this.mBackColor;
    set => this.mBackColor = value;
  }

  protected virtual bool ShouldSerializeBackColor() => this.BackColor != Color.Empty;

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    if (!(this.BackColor != Color.Empty))
      return;
    SolidBrush brush = graphics.BrushsCache.GetBrush(this.BackColor);
    graphics.Graphics.FillRectangle((Brush) brush, area);
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize) => SizeF.Empty;

  public override object Clone() => (object) new BackgroundSolid(this);
}
