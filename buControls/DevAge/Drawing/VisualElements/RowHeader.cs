// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.RowHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class RowHeader : RowHeaderBase
{
  private Header mBackground = new Header(0.0f);

  public RowHeader()
  {
  }

  public RowHeader(RowHeader other)
    : base((RowHeaderBase) other)
  {
    this.mBackground = (Header) other.mBackground.Clone();
  }

  public override object Clone() => (object) new RowHeader(this);

  public override ControlDrawStyle Style
  {
    get => base.Style;
    set
    {
      base.Style = value;
      this.mBackground.Style = value;
    }
  }

  public Color BackColor
  {
    get => this.mBackground.BackColor;
    set => this.mBackground.BackColor = value;
  }

  public BackgroundColorStyle BackgroundColorStyle
  {
    get => this.mBackground.BackgroundColorStyle;
    set => this.mBackground.BackgroundColorStyle = value;
  }

  public RectangleBorder Border
  {
    get => this.mBackground.Border;
    set => this.mBackground.Border = value;
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    base.OnDraw(graphics, area);
    this.mBackground.Draw(graphics, area);
  }

  public override RectangleF GetBackgroundContentRectangle(
    MeasureHelper measure,
    RectangleF backGroundArea)
  {
    backGroundArea = base.GetBackgroundContentRectangle(measure, backGroundArea);
    return this.mBackground.GetBackgroundContentRectangle(measure, backGroundArea);
  }

  public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
  {
    contentSize = this.mBackground.GetBackgroundExtent(measure, contentSize);
    return base.GetBackgroundExtent(measure, contentSize);
  }
}
