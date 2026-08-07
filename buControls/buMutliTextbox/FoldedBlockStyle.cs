// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.FoldedBlockStyle
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;

#nullable disable
namespace buMutliTextbox;

public class FoldedBlockStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle) : 
  TextStyle(foreBrush, backgroundBrush, fontStyle)
{
  public override void Draw(Graphics gr, Point position, Range range)
  {
    if (range.End.iChar > range.Start.iChar)
    {
      base.Draw(gr, position, range);
      int x = position.X;
      for (int iChar = range.Start.iChar; iChar < range.End.iChar && range.tb[range.Start.iLine][iChar].c == ' '; ++iChar)
        x += range.tb.CharWidth;
      range.tb.AddVisualMarker((VisualMarker) new FoldedAreaMarker(range.Start.iLine, new Rectangle(x, position.Y, position.X + (range.End.iChar - range.Start.iChar) * range.tb.CharWidth - x, range.tb.CharHeight)));
    }
    else
    {
      using (Font font = new Font(range.tb.Font, this.FontStyle))
        gr.DrawString("...", font, this.ForeBrush, (float) range.tb.LeftIndent, (float) (position.Y - 2));
      range.tb.AddVisualMarker((VisualMarker) new FoldedAreaMarker(range.Start.iLine, new Rectangle(range.tb.LeftIndent + 2, position.Y, 2 * range.tb.CharHeight, range.tb.CharHeight)));
    }
  }
}
