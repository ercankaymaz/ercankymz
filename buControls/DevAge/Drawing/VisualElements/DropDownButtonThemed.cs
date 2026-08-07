// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.DropDownButtonThemed
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
public class DropDownButtonThemed : DropDownButtonBase
{
  private DropDownButton mStandardButton = new DropDownButton();

  public DropDownButtonThemed()
  {
  }

  public DropDownButtonThemed(DropDownButtonThemed other)
    : base((DropDownButtonBase) other)
  {
  }

  public override object Clone() => (object) new DropDownButtonThemed(this);

  public override ButtonStyle Style
  {
    get => base.Style;
    set
    {
      base.Style = value;
      this.mStandardButton.Style = value;
    }
  }

  protected VisualStyleElement GetBackgroundElement()
  {
    return this.Style != ButtonStyle.Hot ? (this.Style != ButtonStyle.Pressed ? (this.Style != ButtonStyle.Disabled ? VisualStyleElement.ComboBox.DropDownButton.Normal : VisualStyleElement.ComboBox.DropDownButton.Disabled) : VisualStyleElement.ComboBox.DropDownButton.Pressed) : VisualStyleElement.ComboBox.DropDownButton.Hot;
  }

  protected VisualStyleRenderer GetRenderer(VisualStyleElement element)
  {
    return new VisualStyleRenderer(element);
  }

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    if ((!Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetBackgroundElement()) ? 1 : 0)) != 0)
    {
      this.GetRenderer(this.GetBackgroundElement()).DrawBackground((IDeviceContext) graphics.Graphics, Rectangle.Round(area));
      if (this.Style != ButtonStyle.Focus)
        return;
      using (new MeasureHelper(graphics))
        ControlPaint.DrawFocusRectangle(graphics.Graphics, Rectangle.Round(area));
    }
    else
      this.mStandardButton.Draw(graphics, area);
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    SizeF sizeF;
    if ((!Application.RenderWithVisualStyles ? 0 : (VisualStyleRenderer.IsElementDefined(this.GetBackgroundElement()) ? 1 : 0)) != 0)
    {
      Size partSize = this.GetRenderer(this.GetBackgroundElement()).GetPartSize((IDeviceContext) measure.Graphics, ThemeSizeType.True);
      if (partSize.Width < 16 /*0x10*/)
        partSize.Width = 16 /*0x10*/;
      sizeF = (SizeF) partSize;
    }
    else
      sizeF = this.mStandardButton.Measure(measure, (SizeF) Size.Empty, maxSize);
    return sizeF;
  }
}
