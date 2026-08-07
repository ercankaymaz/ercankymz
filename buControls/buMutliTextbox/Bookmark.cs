// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.Bookmark
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;
using System.Drawing.Drawing2D;

#nullable disable
namespace buMutliTextbox;

public class Bookmark
{
  public buMultiTextBox TB { get; private set; }

  public string Name { get; set; }

  public int LineIndex { get; set; }

  public Color Color { get; set; }

  public virtual void DoVisible()
  {
    this.TB.Selection.Start = new Place(0, this.LineIndex);
    this.TB.DoRangeVisible(this.TB.Selection, true);
    this.TB.Invalidate();
  }

  public Bookmark(buMultiTextBox tb, string name, int lineIndex)
  {
    this.TB = tb;
    this.Name = name;
    this.LineIndex = lineIndex;
    this.Color = tb.BookmarkColor;
  }

  public virtual void Paint(Graphics gr, Rectangle lineRect)
  {
    int num = this.TB.CharHeight - 1;
    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(0, lineRect.Top, num, num), Color.White, this.Color, 45f))
      gr.FillEllipse((Brush) linearGradientBrush, 0, lineRect.Top, num, num);
    using (Pen pen = new Pen(this.Color))
      gr.DrawEllipse(pen, 0, lineRect.Top, num, num);
  }
}
