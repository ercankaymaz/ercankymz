// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.EditablePanelBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class EditablePanelBase : ICloneable, IBorder, IEditablePanel
{
  private BorderStyle mBorderStyle = BorderStyle.System;

  public EditablePanelBase()
  {
  }

  public EditablePanelBase(EditablePanelBase other) => this.BorderStyle = other.BorderStyle;

  public virtual BorderStyle BorderStyle
  {
    get => this.mBorderStyle;
    set => this.mBorderStyle = value;
  }

  protected virtual bool ShouldSerializeBorderStyle() => this.BorderStyle != BorderStyle.System;

  public abstract RectangleF GetContentRectangle(RectangleF backGroundArea);

  public abstract SizeF GetExtent(SizeF contentSize);

  public abstract void Draw(GraphicsCache graphics, RectangleF area);

  public abstract RectanglePartType GetPointPartType(
    RectangleF area,
    PointF point,
    out float distanceFromBorder);

  public abstract object Clone();
}
