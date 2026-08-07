// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.TextStyle
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

#nullable disable
namespace buMutliTextbox;

public class TextStyle : Style
{
  public StringFormat stringFormat;

  public Brush ForeBrush { get; set; }

  public Brush BackgroundBrush { get; set; }

  public FontStyle FontStyle { get; set; }

  public TextStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle)
  {
    this.ForeBrush = foreBrush;
    this.BackgroundBrush = backgroundBrush;
    this.FontStyle = fontStyle;
    this.stringFormat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
  }

  public override void Draw(Graphics gr, Point position, Range range)
  {
    if (this.BackgroundBrush != null)
      gr.FillRectangle(this.BackgroundBrush, position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
    using (Font font = new Font(range.tb.Font, this.FontStyle))
    {
      Line line = range.tb[range.Start.iLine];
      float charWidth = (float) range.tb.CharWidth;
      float y = (float) (position.Y + range.tb.LineInterval / 2);
      float num1 = (float) (position.X - range.tb.CharWidth / 3);
      if (this.ForeBrush == null)
        this.ForeBrush = (Brush) new SolidBrush(range.tb.ForeColor);
      if (range.tb.ImeAllowed)
      {
        for (int iChar = range.Start.iChar; iChar < range.End.iChar; ++iChar)
        {
          SizeF charSize = buMultiTextBox.GetCharSize(font, line[iChar].c);
          GraphicsState gstate = gr.Save();
          float num2 = (double) charSize.Width > (double) (range.tb.CharWidth + 1) ? (float) range.tb.CharWidth / charSize.Width : 1f;
          gr.TranslateTransform(num1, y + (float) ((1.0 - (double) num2) * (double) range.tb.CharHeight / 2.0));
          gr.ScaleTransform(num2, (float) Math.Sqrt((double) num2));
          gr.DrawString(line[iChar].c.ToString(), font, this.ForeBrush, 0.0f, 0.0f, this.stringFormat);
          gr.Restore(gstate);
          num1 += charWidth;
        }
      }
      else
      {
        for (int iChar = range.Start.iChar; iChar < range.End.iChar; ++iChar)
        {
          gr.DrawString(line[iChar].c.ToString(), font, this.ForeBrush, num1, y, this.stringFormat);
          num1 += charWidth;
        }
      }
    }
  }

  public override string GetCSS()
  {
    string css = "";
    if (this.BackgroundBrush is SolidBrush)
    {
      string colorAsString = ExportToHTML.GetColorAsString((this.BackgroundBrush as SolidBrush).Color);
      if (colorAsString != "")
        css = $"{css}background-color:{colorAsString};";
    }
    if (this.ForeBrush is SolidBrush)
    {
      string colorAsString = ExportToHTML.GetColorAsString((this.ForeBrush as SolidBrush).Color);
      if (colorAsString != "")
        css = $"{css}color:{colorAsString};";
    }
    if ((this.FontStyle & FontStyle.Bold) != 0)
      css += "font-weight:bold;";
    if ((this.FontStyle & FontStyle.Italic) != 0)
      css += "font-style:oblique;";
    if ((this.FontStyle & FontStyle.Strikeout) != 0)
      css += "text-decoration:line-through;";
    if ((this.FontStyle & FontStyle.Underline) != 0)
      css += "text-decoration:underline;";
    return css;
  }

  public override RTFStyleDescriptor GetRTF()
  {
    RTFStyleDescriptor rtf = new RTFStyleDescriptor();
    if (this.BackgroundBrush is SolidBrush)
      rtf.BackColor = (this.BackgroundBrush as SolidBrush).Color;
    if (this.ForeBrush is SolidBrush)
      rtf.ForeColor = (this.ForeBrush as SolidBrush).Color;
    if ((this.FontStyle & FontStyle.Bold) != 0)
      rtf.AdditionalTags += "\\b";
    if ((this.FontStyle & FontStyle.Italic) != 0)
      rtf.AdditionalTags += "\\i";
    if ((this.FontStyle & FontStyle.Strikeout) != 0)
      rtf.AdditionalTags += "\\strike";
    if ((this.FontStyle & FontStyle.Underline) != 0)
      rtf.AdditionalTags += "\\ul";
    return rtf;
  }
}
