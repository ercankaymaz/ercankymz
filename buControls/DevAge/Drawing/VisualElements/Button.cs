// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.Button
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Button : ButtonBase
{
  public Button()
  {
  }

  public Button(Button other)
    : base((ButtonBase) other)
  {
  }

  public override object Clone() => (object) new Button(this);

  protected override void OnDraw(GraphicsCache graphics, RectangleF area)
  {
    base.OnDraw(graphics, area);
    ButtonState state = this.Style != ButtonStyle.Disabled ? (this.Style != ButtonStyle.Pressed ? (this.Style != ButtonStyle.Hot ? ButtonState.Normal : ButtonState.Normal) : ButtonState.Pushed) : ButtonState.Inactive;
    ControlPaint.DrawButton(graphics.Graphics, Rectangle.Round(area), state);
    if (this.Style == ButtonStyle.NormalDefault)
      graphics.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(area));
    if (this.Style != ButtonStyle.Focus)
      return;
    using (MeasureHelper measure = new MeasureHelper(graphics))
      ControlPaint.DrawFocusRectangle(graphics.Graphics, Rectangle.Round(this.GetBackgroundContentRectangle(measure, area)));
  }

  public override RectangleF GetBackgroundContentRectangle(
    MeasureHelper measure,
    RectangleF backGroundArea)
  {
    backGroundArea = base.GetBackgroundContentRectangle(measure, backGroundArea);
    if ((double) backGroundArea.Width > 4.0)
    {
      backGroundArea.X += 2f;
      backGroundArea.Width -= 4f;
    }
    if ((double) backGroundArea.Height > 4.0)
    {
      backGroundArea.Y += 2f;
      backGroundArea.Height -= 4f;
    }
    return backGroundArea;
  }

  public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
  {
    contentSize = new SizeF(contentSize.Width + 4f, contentSize.Height + 4f);
    return base.GetBackgroundExtent(measure, contentSize);
  }
}
