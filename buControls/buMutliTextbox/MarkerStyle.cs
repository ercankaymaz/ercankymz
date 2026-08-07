// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.MarkerStyle
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;

#nullable disable
namespace buMutliTextbox;

public class MarkerStyle : Style
{
  public Brush BackgroundBrush { get; set; }

  public MarkerStyle(Brush backgroundBrush)
  {
    this.BackgroundBrush = backgroundBrush;
    this.IsExportable = true;
  }

  public override void Draw(Graphics gr, Point position, Range range)
  {
    if (this.BackgroundBrush == null)
      return;
    Rectangle rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
    if (rect.Width == 0)
      return;
    gr.FillRectangle(this.BackgroundBrush, rect);
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
    return css;
  }
}
