// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.CollapseFoldingMarker
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;

#nullable disable
namespace buMutliTextbox;

public class CollapseFoldingMarker : VisualMarker
{
  public readonly int iLine;

  public CollapseFoldingMarker(int iLine, Rectangle rectangle)
    : base(rectangle)
  {
    this.iLine = iLine;
  }

  public void Draw(Graphics gr, Pen pen, Brush backgroundBrush, Pen forePen)
  {
    gr.FillRectangle(backgroundBrush, this.rectangle);
    gr.DrawRectangle(pen, this.rectangle);
    Graphics graphics = gr;
    Pen pen1 = forePen;
    Rectangle rectangle = this.rectangle;
    int x1 = rectangle.Left + 2;
    rectangle = this.rectangle;
    int top1 = rectangle.Top;
    rectangle = this.rectangle;
    int num1 = rectangle.Height / 2;
    int y1 = top1 + num1;
    rectangle = this.rectangle;
    int x2 = rectangle.Right - 2;
    rectangle = this.rectangle;
    int top2 = rectangle.Top;
    rectangle = this.rectangle;
    int num2 = rectangle.Height / 2;
    int y2 = top2 + num2;
    graphics.DrawLine(pen1, x1, y1, x2, y2);
  }
}
