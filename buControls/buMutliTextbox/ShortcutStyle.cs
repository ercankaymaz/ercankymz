// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.ShortcutStyle
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;

#nullable disable
namespace buMutliTextbox;

public class ShortcutStyle : Style
{
  public Pen borderPen;

  public ShortcutStyle(Pen borderPen) => this.borderPen = borderPen;

  public override void Draw(Graphics gr, Point position, Range range)
  {
    Point point = range.tb.PlaceToPoint(range.End);
    Rectangle rect = new Rectangle(point.X - 5, point.Y + range.tb.CharHeight - 2, 4, 3);
    gr.FillPath(Brushes.White, Style.GetRoundedRectangle(rect, 1));
    gr.DrawPath(this.borderPen, Style.GetRoundedRectangle(rect, 1));
    this.AddVisualMarker(range.tb, new StyleVisualMarker(new Rectangle(point.X - range.tb.CharWidth, point.Y, range.tb.CharWidth, range.tb.CharHeight), (Style) this));
  }
}
