// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.EditablePanelThemed
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
public class EditablePanelThemed : EditablePanelBase
{
  private EditablePanel mStandard = new EditablePanel();
  private RectangleBorder mEquivalentPadding = new RectangleBorder(new BorderLine(Color.Empty, 2f));

  public EditablePanelThemed()
  {
  }

  public EditablePanelThemed(EditablePanelThemed other)
    : base((EditablePanelBase) other)
  {
  }

  public override object Clone() => (object) new EditablePanelThemed(this);

  protected VisualStyleElement GetBackgroundElement() => VisualStyleElement.TextBox.TextEdit.Normal;

  protected VisualStyleRenderer GetRenderer(VisualStyleElement element)
  {
    return new VisualStyleRenderer(element);
  }

  public override DevAge.Drawing.BorderStyle BorderStyle
  {
    get => base.BorderStyle;
    set
    {
      base.BorderStyle = value;
      this.mStandard.BorderStyle = value;
    }
  }

  public override void Draw(GraphicsCache graphics, RectangleF area)
  {
    if ((!Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetBackgroundElement()) ? 1 : 0)) != 0)
    {
      if (this.BorderStyle != DevAge.Drawing.BorderStyle.System)
        return;
      this.GetRenderer(this.GetBackgroundElement()).DrawBackground((IDeviceContext) graphics.Graphics, Rectangle.Round(area));
    }
    else
      this.mStandard.Draw(graphics, area);
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
