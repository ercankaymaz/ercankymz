// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.CheckBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class CheckBox : CheckBoxBase
{
  public CheckBox()
  {
  }

  public CheckBox(CheckBox other)
    : base((CheckBoxBase) other)
  {
  }

  public override object Clone() => (object) new CheckBox(this);

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    ButtonState state = this.Style != ControlDrawStyle.Disabled ? (this.Style != ControlDrawStyle.Pressed ? (this.Style != ControlDrawStyle.Hot ? ButtonState.Normal : ButtonState.Normal) : ButtonState.Pushed) : ButtonState.Inactive;
    if (this.CheckBoxState == CheckBoxState.Checked)
      state |= ButtonState.Checked;
    ControlPaint.DrawCheckBox(graphics.Graphics, Rectangle.Round(area), state);
  }

  protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
  {
    return new SizeF(16f, 16f);
  }
}
