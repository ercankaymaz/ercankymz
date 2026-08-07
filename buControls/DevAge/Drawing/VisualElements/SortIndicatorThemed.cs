// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.SortIndicatorThemed
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
public class SortIndicatorThemed : SortIndicator
{
  public SortIndicatorThemed()
  {
  }

  public SortIndicatorThemed(SortIndicatorThemed other)
    : base((SortIndicator) other)
  {
  }

  public override object Clone() => (object) new SortIndicatorThemed(this);

  protected VisualStyleElement GetSortElement()
  {
    return this.SortStyle != HeaderSortStyle.Ascending ? (this.SortStyle != HeaderSortStyle.Descending ? (VisualStyleElement) null : VisualStyleElement.Header.SortArrow.SortedDown) : VisualStyleElement.Header.SortArrow.SortedUp;
  }

  public VisualStyleRenderer GetRenderer(VisualStyleElement element)
  {
    return new VisualStyleRenderer(element);
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    if ((this.SortStyle == HeaderSortStyle.None || !Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetSortElement()) ? 1 : 0)) != 0)
    {
      Rectangle bounds = Rectangle.Round(area);
      VisualStyleRenderer renderer = this.GetRenderer(this.GetSortElement());
      Size partSize = renderer.GetPartSize((IDeviceContext) graphics.Graphics, bounds, ThemeSizeType.Draw);
      bounds = new Rectangle(bounds.Right - partSize.Width, bounds.Top, partSize.Width, partSize.Height);
      renderer.DrawBackground((IDeviceContext) graphics.Graphics, bounds);
    }
    else
      base.OnDraw(graphics, area);
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    return (this.SortStyle == HeaderSortStyle.None || !Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetSortElement()) ? 1 : 0)) == 0 ? base.OnMeasureContent(measure, maxSize) : (SizeF) this.GetRenderer(this.GetSortElement()).GetPartSize((IDeviceContext) measure.Graphics, ThemeSizeType.Draw);
  }
}
