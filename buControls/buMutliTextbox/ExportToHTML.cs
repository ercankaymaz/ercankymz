// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.ExportToHTML
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

#nullable disable
namespace buMutliTextbox;

public class ExportToHTML
{
  public string LineNumbersCSS = "<style type=\"text/css\"> .lineNumber{font-family : monospace; font-size : small; font-style : normal; font-weight : normal; color : Teal; background-color : ThreedFace;} </style>";
  private buMultiTextBox buMultiTextBox_0;

  public bool UseNbsp { get; set; }

  public bool UseForwardNbsp { get; set; }

  public bool UseOriginalFont { get; set; }

  public bool UseStyleTag { get; set; }

  public bool UseBr { get; set; }

  public bool IncludeLineNumbers { get; set; }

  public ExportToHTML()
  {
    this.UseNbsp = true;
    this.UseOriginalFont = true;
    this.UseStyleTag = true;
    this.UseBr = true;
  }

  public string GetHtml(buMultiTextBox tb)
  {
    this.buMultiTextBox_0 = tb;
    Range r = new Range(tb);
    r.SelectAll();
    return this.GetHtml(r);
  }

  public string GetHtml(Range r)
  {
    this.buMultiTextBox_0 = r.tb;
    Dictionary<StyleIndex, object> dictionary = new Dictionary<StyleIndex, object>();
    StringBuilder stringBuilder_0 = new StringBuilder();
    StringBuilder stringBuilder_1 = new StringBuilder();
    StyleIndex styleIndex = StyleIndex.None;
    r.Normalize();
    int iLine = r.Start.iLine;
    dictionary[StyleIndex.None] = (object) null;
    if (this.UseOriginalFont)
      stringBuilder_0.AppendFormat("<font style=\"font-family: {0}, monospace; font-size: {1}pt; line-height: {2}px;\">", (object) r.tb.Font.Name, (object) r.tb.Font.SizeInPoints, (object) r.tb.CharHeight);
    if (this.IncludeLineNumbers)
      stringBuilder_1.AppendFormat("<span class=lineNumber>{0}</span>  ", (object) (iLine + 1));
    bool flag = false;
    foreach (Place place in (IEnumerable<Place>) r)
    {
      Char @char = r.tb[place.iLine][place.iChar];
      if (@char.style != styleIndex)
      {
        Class39.smethod_491(this, stringBuilder_0, stringBuilder_1, styleIndex);
        styleIndex = @char.style;
        dictionary[styleIndex] = (object) null;
      }
      if (place.iLine != iLine)
      {
        for (int index = iLine; index < place.iLine; ++index)
        {
          stringBuilder_1.Append(this.UseBr ? "<br>" : "\r\n");
          if (this.IncludeLineNumbers)
            stringBuilder_1.AppendFormat("<span class=lineNumber>{0}</span>  ", (object) (index + 2));
        }
        iLine = place.iLine;
        flag = false;
      }
      switch (@char.c)
      {
        case ' ':
          if ((flag || !this.UseForwardNbsp ? (!this.UseNbsp ? 1 : 0) : 0) == 0)
          {
            stringBuilder_1.Append("&nbsp;");
            continue;
          }
          break;
        case '&':
          stringBuilder_1.Append("&amp;");
          continue;
        case '<':
          stringBuilder_1.Append("&lt;");
          continue;
        case '>':
          stringBuilder_1.Append("&gt;");
          continue;
      }
      flag = true;
      stringBuilder_1.Append(@char.c);
    }
    Class39.smethod_491(this, stringBuilder_0, stringBuilder_1, styleIndex);
    if (this.UseOriginalFont)
      stringBuilder_0.Append("</font>");
    if (this.UseStyleTag)
    {
      stringBuilder_1.Length = 0;
      stringBuilder_1.Append("<style type=\"text/css\">");
      foreach (StyleIndex key in dictionary.Keys)
        stringBuilder_1.AppendFormat(".fctb{0}{{ {1} }}\r\n", (object) Class39.smethod_587(key, this), (object) this.method_0(key));
      stringBuilder_1.Append("</style>");
      stringBuilder_0.Insert(0, stringBuilder_1.ToString());
    }
    if (this.IncludeLineNumbers)
      stringBuilder_0.Insert(0, this.LineNumbersCSS);
    return stringBuilder_0.ToString();
  }

  internal string method_0(StyleIndex styleIndex_0)
  {
    List<Style> styleList = new List<Style>();
    TextStyle textStyle = (TextStyle) null;
    int num = 1;
    bool flag = false;
    for (int index = 0; index < this.buMultiTextBox_0.Styles.Length; ++index)
    {
      if ((this.buMultiTextBox_0.Styles[index] == null ? 0 : ((styleIndex_0 & (StyleIndex) num) != 0 ? 1 : 0)) != 0 && this.buMultiTextBox_0.Styles[index].IsExportable)
      {
        Style style = this.buMultiTextBox_0.Styles[index];
        styleList.Add(style);
        if (style is TextStyle && (!flag ? 1 : (this.buMultiTextBox_0.AllowSeveralTextStyleDrawing ? 1 : 0)) != 0)
        {
          flag = true;
          textStyle = style as TextStyle;
        }
      }
      num <<= 1;
    }
    string str = flag ? textStyle.GetCSS() : this.buMultiTextBox_0.DefaultStyle.GetCSS();
    foreach (Style style in styleList)
    {
      if (!(style is TextStyle))
        str += style.GetCSS();
    }
    return str;
  }

  public static string GetColorAsString(Color color)
  {
    return !(color == Color.Transparent) ? $"#{color.R:x2}{color.G:x2}{color.B:x2}" : "";
  }
}
