// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.UnfocusablePanel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

[ToolboxItem(false)]
public class UnfocusablePanel : UserControl
{
  public Color BackColor2 { get; set; }

  public Color BorderColor { get; set; }

  public new string Text { get; set; }

  public StringAlignment TextAlignment { get; set; }

  public UnfocusablePanel()
  {
    this.SetStyle(ControlStyles.Selectable, false);
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    using (LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(this.ClientRectangle, this.BackColor2, this.BackColor, 90f))
    {
      Graphics graphics = e.Graphics;
      LinearGradientBrush linearGradientBrush2 = linearGradientBrush1;
      Size clientSize = this.ClientSize;
      int width = clientSize.Width - 1;
      clientSize = this.ClientSize;
      int height = clientSize.Height - 1;
      graphics.FillRectangle((Brush) linearGradientBrush2, 0, 0, width, height);
    }
    using (Pen pen1 = new Pen(this.BorderColor))
    {
      Graphics graphics = e.Graphics;
      Pen pen2 = pen1;
      Size clientSize = this.ClientSize;
      int width = clientSize.Width - 1;
      clientSize = this.ClientSize;
      int height = clientSize.Height - 1;
      graphics.DrawRectangle(pen2, 0, 0, width, height);
    }
    if (string.IsNullOrEmpty(this.Text))
      return;
    StringFormat stringFormat = new StringFormat();
    stringFormat.Alignment = this.TextAlignment;
    stringFormat.LineAlignment = StringAlignment.Center;
    using (SolidBrush solidBrush1 = new SolidBrush(this.ForeColor))
    {
      Graphics graphics = e.Graphics;
      string text = this.Text;
      Font font = this.Font;
      SolidBrush solidBrush2 = solidBrush1;
      Size clientSize = this.ClientSize;
      double width = (double) (clientSize.Width - 2);
      clientSize = this.ClientSize;
      double height = (double) (clientSize.Height - 2);
      RectangleF layoutRectangle = new RectangleF(1f, 1f, (float) width, (float) height);
      StringFormat format = stringFormat;
      graphics.DrawString(text, font, (Brush) solidBrush2, layoutRectangle, format);
    }
  }
}
