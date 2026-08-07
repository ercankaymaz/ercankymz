// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.RowHeaderThemed
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
public class RowHeaderThemed : RowHeaderBase
{
  private RowHeader mStandardRowHeader = new RowHeader();
  private ColumnHeaderThemed mColHeaderThemed = new ColumnHeaderThemed();
  private bool mRotateColHeaderIfNotDefined = true;

  public RowHeaderThemed()
  {
  }

  public RowHeaderThemed(RowHeaderThemed other)
    : base((RowHeaderBase) other)
  {
  }

  public override object Clone() => (object) new RowHeaderThemed(this);

  public override ControlDrawStyle Style
  {
    get => base.Style;
    set
    {
      base.Style = value;
      this.mStandardRowHeader.Style = value;
      this.mColHeaderThemed.Style = value;
    }
  }

  public virtual bool RotateColHeaderIfNotDefined
  {
    get => this.mRotateColHeaderIfNotDefined;
    set => this.mRotateColHeaderIfNotDefined = value;
  }

  protected VisualStyleElement GetBackgroundElement()
  {
    return this.Style != ControlDrawStyle.Hot ? (this.Style != ControlDrawStyle.Pressed ? VisualStyleElement.Header.ItemLeft.Normal : VisualStyleElement.Header.ItemLeft.Pressed) : VisualStyleElement.Header.ItemLeft.Hot;
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
    else if (this.RotateColHeaderIfNotDefined)
    {
      Bitmap bitmap = new Bitmap((int) area.Height, (int) area.Width);
      Graphics graphics1 = Graphics.FromImage((System.Drawing.Image) bitmap);
      try
      {
        Rectangle area1 = new Rectangle(0, 0, (int) area.Height, (int) area.Width);
        using (GraphicsCache graphics2 = new GraphicsCache(graphics1))
          this.mColHeaderThemed.Draw(graphics2, (RectangleF) area1);
        bitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
        graphics.Graphics.DrawImage((System.Drawing.Image) bitmap, area);
      }
      finally
      {
        graphics1.Dispose();
        bitmap.Dispose();
      }
    }
    else
      this.mStandardRowHeader.Draw(graphics, area);
  }

  public override RectangleF GetBackgroundContentRectangle(
    MeasureHelper measure,
    RectangleF backGroundArea)
  {
    backGroundArea = base.GetBackgroundContentRectangle(measure, backGroundArea);
    return (!Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetBackgroundElement()) ? 1 : 0)) == 0 ? this.mStandardRowHeader.GetBackgroundContentRectangle(measure, backGroundArea) : (RectangleF) this.GetRenderer(this.GetBackgroundElement()).GetBackgroundContentRectangle((IDeviceContext) measure.Graphics, Rectangle.Round(backGroundArea));
  }

  public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
  {
    if ((!Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetBackgroundElement()) ? 1 : 0)) != 0)
    {
      Rectangle contentBounds = new Rectangle(new Point(0, 0), Size.Ceiling(contentSize));
      contentSize = (SizeF) this.GetRenderer(this.GetBackgroundElement()).GetBackgroundExtent((IDeviceContext) measure.Graphics, contentBounds).Size;
    }
    else
      contentSize = this.mStandardRowHeader.GetBackgroundExtent(measure, contentSize);
    return base.GetBackgroundExtent(measure, contentSize);
  }
}
