// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.ContainerBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class ContainerBase : VisualElementBase, ICloneable, IVisualElement, IContainer
{
  private ElementsDrawMode mDrawMode = ElementsDrawMode.Covering;
  private IVisualElement mBackground = (IVisualElement) null;
  private Padding mPadding = Padding.Empty;
  private IBorder mBorder = (IBorder) null;

  public ContainerBase()
  {
  }

  public ContainerBase(ContainerBase other)
    : base((VisualElementBase) other)
  {
    this.Background = other.Background == null ? (IVisualElement) null : (IVisualElement) other.Background.Clone();
    this.ElementsDrawMode = other.ElementsDrawMode;
    this.Padding = other.Padding;
    if (other.Border != null)
      this.Border = (IBorder) other.Border.Clone();
    else
      this.Border = (IBorder) null;
  }

  protected abstract IEnumerable<IVisualElement> GetElements();

  protected ElementsDrawMode ElementsDrawMode
  {
    get => this.mDrawMode;
    set => this.mDrawMode = value;
  }

  protected virtual bool ShouldSerializeElementsDrawMode()
  {
    return this.ElementsDrawMode != ElementsDrawMode.Covering;
  }

  protected IVisualElement Background
  {
    get => this.mBackground;
    set => this.mBackground = value;
  }

  protected virtual bool ShouldSerializeBackground() => this.Background != null;

  protected Padding Padding
  {
    get => this.mPadding;
    set => this.mPadding = value;
  }

  protected virtual bool ShouldSerializePadding() => this.Padding != Padding.Empty;

  protected IBorder Border
  {
    get => this.mBorder;
    set => this.mBorder = value;
  }

  protected virtual bool ShouldSerializeBorder() => this.Border != null;

  public RectangleF GetContentRectangle(MeasureHelper measure, RectangleF backGroundArea)
  {
    if (this.Border != null)
      backGroundArea = this.Border.GetContentRectangle(backGroundArea);
    if (!this.Padding.IsEmpty)
      backGroundArea = this.Padding.GetContentRectangle(backGroundArea);
    if (this.Background is IBackground)
      backGroundArea = ((IBackground) this.Background).GetBackgroundContentRectangle(measure, backGroundArea);
    return backGroundArea;
  }

  public SizeF GetExtent(MeasureHelper measure, SizeF contentSize)
  {
    if (this.Background is IBackground)
      contentSize = ((IBackground) this.Background).GetBackgroundExtent(measure, contentSize);
    if (!this.Padding.IsEmpty)
      contentSize = this.Padding.GetExtent(contentSize);
    if (this.Border != null)
      contentSize = this.Border.GetExtent(contentSize);
    return contentSize;
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    this.OnDrawBackground(graphics, area);
    using (MeasureHelper measure = new MeasureHelper(graphics))
    {
      RectangleF contentRectangle = this.GetContentRectangle(measure, area);
      this.OnDrawContent(graphics, contentRectangle);
    }
  }

  protected virtual void OnDrawBackground(GraphicsCache graphics, RectangleF area)
  {
    if (this.Border != null)
    {
      this.Border.Draw(graphics, area);
      area = this.Border.GetContentRectangle(area);
    }
    if (this.Background == null)
      return;
    this.Background.Draw(graphics, area);
  }

  protected virtual void OnDrawContent(GraphicsCache graphics, RectangleF area)
  {
    if (this.ElementsDrawMode == ElementsDrawMode.Covering)
    {
      foreach (IVisualElement element in this.GetElements())
        element.Draw(graphics, area);
    }
    else
    {
      if (this.ElementsDrawMode != ElementsDrawMode.Align)
        throw new ApplicationException("DrawMode not supported");
      using (new MeasureHelper(graphics))
      {
        foreach (IVisualElement element in this.GetElements())
        {
          RectangleF drawingArea;
          element.Draw(graphics, area, out drawingArea);
          area = ContainerBase.CalculateRemainingArea(area, element.AnchorArea, drawingArea);
        }
      }
    }
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    SizeF sizeF = new SizeF(0.0f, 0.0f);
    if (this.ElementsDrawMode == ElementsDrawMode.Covering)
    {
      foreach (IVisualElement element in this.GetElements())
      {
        SizeF sizeWithAnchor = ContainerBase.CalculateSizeWithAnchor(element.Measure(measure, (SizeF) Size.Empty, maxSize), element.AnchorArea, maxSize);
        if ((double) sizeWithAnchor.Width > (double) sizeF.Width)
          sizeF.Width = sizeWithAnchor.Width;
        if ((double) sizeWithAnchor.Height > (double) sizeF.Height)
          sizeF.Height = sizeWithAnchor.Height;
      }
    }
    else
    {
      if (this.ElementsDrawMode != ElementsDrawMode.Align)
        throw new ApplicationException("DrawMode not supported");
      AnchorArea contentAnchor = (AnchorArea) null;
      foreach (IVisualElement element in this.GetElements())
      {
        SizeF sizeWithAnchor = ContainerBase.CalculateSizeWithAnchor(element.Measure(measure, (SizeF) Size.Empty, maxSize), element.AnchorArea, maxSize);
        sizeF = ContainerBase.CalculateSizeWithContent(sizeF, contentAnchor, sizeWithAnchor);
        contentAnchor = element.AnchorArea;
      }
    }
    return this.GetExtent(measure, sizeF);
  }

  public override VisualElementList GetElementsAtPoint(
    MeasureHelper measure,
    RectangleF area,
    PointF point)
  {
    VisualElementList elementsAtPoint = base.GetElementsAtPoint(measure, area, point);
    area = this.GetContentRectangle(measure, area);
    if (this.ElementsDrawMode == ElementsDrawMode.Covering)
    {
      foreach (IVisualElement element in this.GetElements())
        elementsAtPoint.AddRange((IEnumerable<IVisualElement>) element.GetElementsAtPoint(measure, area, point));
    }
    else
    {
      if (this.ElementsDrawMode != ElementsDrawMode.Align)
        throw new ApplicationException("DrawMode not supported");
      foreach (IVisualElement element in this.GetElements())
      {
        elementsAtPoint.AddRange((IEnumerable<IVisualElement>) element.GetElementsAtPoint(measure, area, point));
        RectangleF drawingArea = element.GetDrawingArea(measure, area);
        area = ContainerBase.CalculateRemainingArea(area, element.AnchorArea, drawingArea);
      }
    }
    return elementsAtPoint;
  }

  public static RectangleF CalculateRemainingArea(
    RectangleF parentArea,
    AnchorArea contentAnchor,
    RectangleF contentArea)
  {
    RectangleF remainingArea;
    if (contentAnchor != (AnchorArea) null)
    {
      float y;
      float height;
      if ((!contentAnchor.HasTop ? 0 : (!contentAnchor.HasBottom ? 1 : 0)) != 0)
      {
        y = contentArea.Bottom;
        height = parentArea.Height - contentArea.Height;
      }
      else if ((!contentAnchor.HasBottom ? 0 : (!contentAnchor.HasTop ? 1 : 0)) != 0)
      {
        y = parentArea.Top;
        height = parentArea.Height - contentArea.Height;
      }
      else
      {
        y = parentArea.Top;
        height = parentArea.Height;
      }
      float x;
      float width;
      if ((!contentAnchor.HasLeft ? 0 : (!contentAnchor.HasRight ? 1 : 0)) != 0)
      {
        x = contentArea.Right;
        width = parentArea.Width - contentArea.Width;
      }
      else if ((!contentAnchor.HasRight ? 0 : (!contentAnchor.HasLeft ? 1 : 0)) != 0)
      {
        x = parentArea.Left;
        width = parentArea.Width - contentArea.Width;
      }
      else
      {
        x = parentArea.Left;
        width = parentArea.Width;
      }
      RectangleF rectangleF = new RectangleF(x, y, width, height);
      rectangleF.Intersect(parentArea);
      remainingArea = rectangleF;
    }
    else
      remainingArea = parentArea;
    return remainingArea;
  }

  public static SizeF CalculateSizeWithContent(
    SizeF currentSize,
    AnchorArea contentAnchor,
    SizeF contentSize)
  {
    if ((!(contentAnchor != (AnchorArea) null) ? 0 : (contentAnchor.HasLeft ? 1 : (contentAnchor.HasRight ? 1 : 0))) != 0)
      currentSize.Width += contentSize.Width;
    else if ((double) contentSize.Width > (double) currentSize.Width)
      currentSize.Width = contentSize.Width;
    if ((!(contentAnchor != (AnchorArea) null) ? 0 : (contentAnchor.HasTop ? 1 : (contentAnchor.HasBottom ? 1 : 0))) != 0)
      currentSize.Height += contentSize.Height;
    else if ((double) contentSize.Height > (double) currentSize.Height)
      currentSize.Height = contentSize.Height;
    return currentSize;
  }

  public static SizeF CalculateSizeWithAnchor(
    SizeF contentSize,
    AnchorArea contentAnchor,
    SizeF clientSize)
  {
    SizeF sizeWithAnchor;
    if (contentAnchor == (AnchorArea) null)
    {
      sizeWithAnchor = contentSize;
    }
    else
    {
      if ((!contentAnchor.HasLeft ? 0 : (contentAnchor.HasRight ? 1 : 0)) != 0)
      {
        if (!clientSize.IsEmpty)
          contentSize.Width = clientSize.Width - (contentAnchor.Left + contentAnchor.Right);
      }
      else if (contentAnchor.HasLeft)
        contentSize.Width += contentAnchor.Left;
      else if (contentAnchor.HasRight)
        contentSize.Width += contentAnchor.Right;
      if ((double) contentSize.Width < 0.0)
        contentSize.Width = 0.0f;
      if ((!contentAnchor.HasTop ? 0 : (contentAnchor.HasBottom ? 1 : 0)) != 0)
      {
        if (!clientSize.IsEmpty)
          contentSize.Height = clientSize.Height - (contentAnchor.Top + contentAnchor.Bottom);
      }
      else if (contentAnchor.HasTop)
        contentSize.Height += contentAnchor.Top;
      else if (contentAnchor.HasBottom)
        contentSize.Height += contentAnchor.Bottom;
      if ((double) contentSize.Height < 0.0)
        contentSize.Height = 0.0f;
      sizeWithAnchor = contentSize;
    }
    return sizeWithAnchor;
  }
}
