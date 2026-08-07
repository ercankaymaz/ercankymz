// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.SelectionStyle
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

#nullable disable
namespace buMutliTextbox;

public class SelectionStyle : Style
{
  public Brush BackgroundBrush { get; set; }

  public Brush ForegroundBrush { get; private set; }

  public override bool IsExportable
  {
    get => false;
    set
    {
    }
  }

  public SelectionStyle(Brush backgroundBrush, Brush foregroundBrush = null)
  {
    this.BackgroundBrush = backgroundBrush;
    this.ForegroundBrush = foregroundBrush;
  }

  public override void Draw(Graphics gr, Point position, Range range)
  {
    if (this.BackgroundBrush == null)
      return;
    gr.SmoothingMode = SmoothingMode.None;
    Rectangle rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
    if (rect.Width == 0)
      return;
    gr.FillRectangle(this.BackgroundBrush, rect);
    if (this.ForegroundBrush == null)
      return;
    gr.SmoothingMode = SmoothingMode.AntiAlias;
    Range range1 = new Range(range.tb, range.Start.iChar, range.Start.iLine, Math.Min(range.tb[range.End.iLine].Count, range.End.iChar), range.End.iLine);
    using (TextStyle textStyle = new TextStyle(this.ForegroundBrush, (Brush) null, FontStyle.Regular))
      textStyle.Draw(gr, new Point(position.X, position.Y - 1), range1);
  }
}
