// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.VisualElementBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class VisualElementBase : ICloneable, IVisualElement
{
  private AnchorArea mAnchorArea = (AnchorArea) null;

  protected VisualElementBase()
  {
  }

  public VisualElementBase(VisualElementBase other)
  {
    if (other.AnchorArea != (AnchorArea) null)
      this.AnchorArea = (AnchorArea) other.AnchorArea.Clone();
    else
      this.AnchorArea = (AnchorArea) null;
  }

  public virtual AnchorArea AnchorArea
  {
    get => this.mAnchorArea;
    set => this.mAnchorArea = value;
  }

  protected virtual bool ShouldSerializeAnchorArea()
  {
    return this.AnchorArea != (AnchorArea) null && !this.AnchorArea.IsEmpty;
  }

  public SizeF Measure(MeasureHelper measure, SizeF minSize, SizeF maxSize)
  {
    return Utilities.CheckMeasure(this.OnMeasureContent(measure, maxSize), minSize, maxSize);
  }

  protected abstract SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize);

  public void Draw(GraphicsCache graphics, RectangleF area, out RectangleF drawingArea)
  {
    using (MeasureHelper measure = new MeasureHelper(graphics))
    {
      drawingArea = this.GetDrawingArea(measure, area);
      this.OnDraw(graphics, drawingArea);
    }
  }

  public void Draw(GraphicsCache graphics, RectangleF area)
  {
    this.Draw(graphics, area, out RectangleF _);
  }

  public RectangleF GetDrawingArea(MeasureHelper measure, RectangleF area)
  {
    RectangleF drawingArea = area;
    if ((!(this.AnchorArea != (AnchorArea) null) ? 0 : (!this.AnchorArea.IsEmpty ? 1 : 0)) != 0)
    {
      SizeF content = this.Measure(measure, SizeF.Empty, SizeF.Empty);
      drawingArea = AnchorArea.CalculateArea(area, content, this.AnchorArea);
    }
    return drawingArea;
  }

  protected abstract void OnDraw(GraphicsCache graphics, RectangleF area);

  public virtual VisualElementList GetElementsAtPoint(
    MeasureHelper measure,
    RectangleF area,
    PointF point)
  {
    VisualElementList elementsAtPoint = new VisualElementList();
    if (this.GetDrawingArea(measure, area).Contains(point))
      elementsAtPoint.Add((IVisualElement) this);
    return elementsAtPoint;
  }

  public abstract object Clone();
}
