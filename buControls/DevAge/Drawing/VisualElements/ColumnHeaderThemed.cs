// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.ColumnHeaderThemed
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class ColumnHeaderThemed : ColumnHeaderBase
{
  private ColumnHeader mStandardHeader = new ColumnHeader();

  public ColumnHeaderThemed()
  {
  }

  public ColumnHeaderThemed(ColumnHeaderThemed other)
    : base((ColumnHeaderBase) other)
  {
  }

  public override object Clone() => (object) new ColumnHeaderThemed(this);

  public override ControlDrawStyle Style
  {
    get => base.Style;
    set
    {
      base.Style = value;
      this.mStandardHeader.Style = value;
    }
  }

  protected VisualStyleElement GetBackgroundElement()
  {
    return this.Style != ControlDrawStyle.Hot ? (this.Style != ControlDrawStyle.Pressed ? VisualStyleElement.Header.Item.Normal : VisualStyleElement.Header.Item.Pressed) : VisualStyleElement.Header.Item.Hot;
  }

  protected VisualStyleRenderer GetRenderer(VisualStyleElement element)
  {
    return new VisualStyleRenderer(element);
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    base.OnDraw(graphics, area);
    if ((!Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetBackgroundElement()) ? 1 : 0)) != 0)
      this.GetRenderer(this.GetBackgroundElement()).DrawBackground((IDeviceContext) graphics.Graphics, Rectangle.Round(area));
    else
      this.mStandardHeader.Draw(graphics, area);
  }

  public override RectangleF GetBackgroundContentRectangle(
    MeasureHelper measure,
    RectangleF backGroundArea)
  {
    backGroundArea = base.GetBackgroundContentRectangle(measure, backGroundArea);
    return (!Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetBackgroundElement()) ? 1 : 0)) == 0 ? this.mStandardHeader.GetBackgroundContentRectangle(measure, backGroundArea) : (RectangleF) this.GetRenderer(this.GetBackgroundElement()).GetBackgroundContentRectangle((IDeviceContext) measure.Graphics, Rectangle.Round(backGroundArea));
  }

  public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
  {
    if ((!Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetBackgroundElement()) ? 1 : 0)) != 0)
    {
      Rectangle contentBounds = new Rectangle(new Point(0, 0), Size.Ceiling(contentSize));
      contentSize = (SizeF) this.GetRenderer(this.GetBackgroundElement()).GetBackgroundExtent((IDeviceContext) measure.Graphics, contentBounds).Size;
    }
    else
      contentSize = this.mStandardHeader.GetBackgroundExtent(measure, contentSize);
    return base.GetBackgroundExtent(measure, contentSize);
  }
}
