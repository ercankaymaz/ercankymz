// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.BackgroundBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class BackgroundBase : VisualElementBase, ICloneable, IVisualElement, IBackground
{
  public BackgroundBase()
  {
  }

  public BackgroundBase(BackgroundBase other)
    : base((VisualElementBase) other)
  {
  }

  public virtual RectangleF GetBackgroundContentRectangle(
    MeasureHelper measure,
    RectangleF backGroundArea)
  {
    return backGroundArea;
  }

  public virtual SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize) => contentSize;

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    SizeF empty = SizeF.Empty;
    return this.GetBackgroundExtent(measure, empty);
  }
}
