// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.EditablePanel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class EditablePanel : EditablePanelBase
{
  private RectangleBorder mEquivalentPadding = new RectangleBorder(new BorderLine(Color.Empty, 2f));

  public EditablePanel()
  {
  }

  public EditablePanel(EditablePanel other)
    : base((EditablePanelBase) other)
  {
  }

  public override object Clone() => (object) new EditablePanel(this);

  public override void Draw(GraphicsCache graphics, RectangleF area)
  {
    if (this.BorderStyle != DevAge.Drawing.BorderStyle.System)
      return;
    ControlPaint.DrawBorder3D(graphics.Graphics, Rectangle.Round(area), Border3DStyle.Flat, Border3DSide.All);
  }

  public override RectangleF GetContentRectangle(RectangleF backGroundArea)
  {
    return this.BorderStyle != DevAge.Drawing.BorderStyle.System ? backGroundArea : this.mEquivalentPadding.GetContentRectangle(backGroundArea);
  }

  public override SizeF GetExtent(SizeF contentSize)
  {
    return this.BorderStyle != DevAge.Drawing.BorderStyle.System ? contentSize : this.mEquivalentPadding.GetExtent(contentSize);
  }

  public override RectanglePartType GetPointPartType(
    RectangleF area,
    PointF point,
    out float distanceFromBorder)
  {
    RectanglePartType pointPartType;
    if (this.BorderStyle == DevAge.Drawing.BorderStyle.System)
    {
      pointPartType = this.mEquivalentPadding.GetPointPartType(area, point, out distanceFromBorder);
    }
    else
    {
      distanceFromBorder = 0.0f;
      pointPartType = RectanglePartType.ContentArea;
    }
    return pointPartType;
  }
}
