// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.IVisualElement
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

public interface IVisualElement : ICloneable
{
  AnchorArea AnchorArea { get; set; }

  RectangleF GetDrawingArea(MeasureHelper measure, RectangleF area);

  SizeF Measure(MeasureHelper measure, SizeF minSize, SizeF maxSize);

  void Draw(GraphicsCache graphics, RectangleF area);

  void Draw(GraphicsCache graphics, RectangleF area, out RectangleF drawingArea);

  VisualElementList GetElementsAtPoint(MeasureHelper measure, RectangleF area, PointF point);
}
