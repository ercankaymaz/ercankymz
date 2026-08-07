// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.DropDownButton
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class DropDownButton : DropDownButtonBase
{
  public DropDownButton()
  {
  }

  public DropDownButton(DropDownButton other)
    : base((DropDownButtonBase) other)
  {
  }

  public override object Clone() => (object) new DropDownButton(this);

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    ButtonState state = this.Style != ButtonStyle.Disabled ? (this.Style != ButtonStyle.Pressed ? (this.Style != ButtonStyle.Hot ? ButtonState.Normal : ButtonState.Normal) : ButtonState.Pushed) : ButtonState.Inactive;
    ControlPaint.DrawComboButton(graphics.Graphics, Rectangle.Round(area), state);
    if (this.Style == ButtonStyle.NormalDefault)
      graphics.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(area));
    if (this.Style != ButtonStyle.Focus)
      return;
    using (new MeasureHelper(graphics))
      ControlPaint.DrawFocusRectangle(graphics.Graphics, Rectangle.Round(area));
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    return new SizeF(16f, 16f);
  }
}
