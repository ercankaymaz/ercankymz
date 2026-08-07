// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.ExpandFoldingMarker
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;

#nullable disable
namespace buMutliTextbox;

public class ExpandFoldingMarker : VisualMarker
{
  public readonly int iLine;

  public ExpandFoldingMarker(int iLine, Rectangle rectangle)
    : base(rectangle)
  {
    this.iLine = iLine;
  }

  public void Draw(Graphics gr, Pen pen, Brush backgroundBrush, Pen forePen)
  {
    gr.FillRectangle(backgroundBrush, this.rectangle);
    gr.DrawRectangle(pen, this.rectangle);
    Graphics graphics1 = gr;
    Pen pen1 = forePen;
    Rectangle rectangle1 = this.rectangle;
    int x1_1 = rectangle1.Left + 2;
    rectangle1 = this.rectangle;
    int top1 = rectangle1.Top;
    rectangle1 = this.rectangle;
    int num1 = rectangle1.Height / 2;
    int y1_1 = top1 + num1;
    rectangle1 = this.rectangle;
    int x2_1 = rectangle1.Right - 2;
    rectangle1 = this.rectangle;
    int top2 = rectangle1.Top;
    rectangle1 = this.rectangle;
    int num2 = rectangle1.Height / 2;
    int y2_1 = top2 + num2;
    graphics1.DrawLine(pen1, x1_1, y1_1, x2_1, y2_1);
    Graphics graphics2 = gr;
    Pen pen2 = forePen;
    Rectangle rectangle2 = this.rectangle;
    int left1 = rectangle2.Left;
    rectangle2 = this.rectangle;
    int num3 = rectangle2.Width / 2;
    int x1_2 = left1 + num3;
    rectangle2 = this.rectangle;
    int y1_2 = rectangle2.Top + 2;
    rectangle2 = this.rectangle;
    int left2 = rectangle2.Left;
    rectangle2 = this.rectangle;
    int num4 = rectangle2.Width / 2;
    int x2_2 = left2 + num4;
    rectangle2 = this.rectangle;
    int y2_2 = rectangle2.Bottom - 2;
    graphics2.DrawLine(pen2, x1_2, y1_2, x2_2, y2_2);
  }
}
