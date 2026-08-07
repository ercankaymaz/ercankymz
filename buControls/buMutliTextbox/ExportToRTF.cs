// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.ExportToRTF
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

#nullable disable
namespace buMutliTextbox;

public class ExportToRTF
{
  internal buMultiTextBox buMultiTextBox_0;
  internal Dictionary<Color, int> dictionary_0 = new Dictionary<Color, int>();

  public bool IncludeLineNumbers { get; set; }

  public bool UseOriginalFont { get; set; }

  public ExportToRTF() => this.UseOriginalFont = true;

  public string GetRtf(buMultiTextBox tb)
  {
    this.buMultiTextBox_0 = tb;
    Range r = new Range(tb);
    r.SelectAll();
    return this.GetRtf(r);
  }

  public string GetRtf(Range r)
  {
    this.buMultiTextBox_0 = r.tb;
    Dictionary<StyleIndex, object> dictionary = new Dictionary<StyleIndex, object>();
    StringBuilder stringBuilder_0 = new StringBuilder();
    StringBuilder stringBuilder_1 = new StringBuilder();
    StyleIndex styleIndex = StyleIndex.None;
    r.Normalize();
    int iLine = r.Start.iLine;
    dictionary[StyleIndex.None] = (object) null;
    this.dictionary_0.Clear();
    int num = Class39.smethod_168(this, r.tb.LineNumberColor);
    if (this.IncludeLineNumbers)
      stringBuilder_1.AppendFormat("{{\\cf{1} {0}}}\\tab", (object) (iLine + 1), (object) num);
    foreach (Place place in (IEnumerable<Place>) r)
    {
      Char @char = r.tb[place.iLine][place.iChar];
      if (@char.style != styleIndex)
      {
        Class39.smethod_573(this, stringBuilder_0, stringBuilder_1, styleIndex);
        styleIndex = @char.style;
        dictionary[styleIndex] = (object) null;
      }
      if (place.iLine != iLine)
      {
        for (int index = iLine; index < place.iLine; ++index)
        {
          stringBuilder_1.AppendLine("\\line");
          if (this.IncludeLineNumbers)
            stringBuilder_1.AppendFormat("{{\\cf{1} {0}}}\\tab", (object) (index + 2), (object) num);
        }
        iLine = place.iLine;
      }
      switch (@char.c)
      {
        case '\\':
          stringBuilder_1.Append("\\\\");
          continue;
        case '{':
          stringBuilder_1.Append("\\{");
          continue;
        case '}':
          stringBuilder_1.Append("\\}");
          continue;
        default:
          int c = (int) @char.c;
          if (c < 128 /*0x80*/)
          {
            stringBuilder_1.Append(@char.c);
            continue;
          }
          stringBuilder_1.AppendFormat("{{\\u{0}}}", (object) c);
          continue;
      }
    }
    Class39.smethod_573(this, stringBuilder_0, stringBuilder_1, styleIndex);
    SortedList<int, Color> sortedList = new SortedList<int, Color>();
    foreach (KeyValuePair<Color, int> keyValuePair in this.dictionary_0)
      sortedList.Add(keyValuePair.Value, keyValuePair.Key);
    stringBuilder_1.Length = 0;
    stringBuilder_1.AppendFormat("{{\\colortbl;");
    foreach (KeyValuePair<int, Color> keyValuePair in sortedList)
      stringBuilder_1.Append(ExportToRTF.GetColorAsString(keyValuePair.Value) + ";");
    stringBuilder_1.AppendLine("}");
    if (this.UseOriginalFont)
    {
      stringBuilder_0.Insert(0, string.Format("{{\\fonttbl{{\\f0\\fmodern {0};}}}}{{\\fs{1} ", (object) this.buMultiTextBox_0.Font.Name, (object) (int) (2.0 * (double) this.buMultiTextBox_0.Font.SizeInPoints), (object) this.buMultiTextBox_0.CharHeight));
      stringBuilder_0.AppendLine("}");
    }
    stringBuilder_0.Insert(0, stringBuilder_1.ToString());
    stringBuilder_0.Insert(0, "{\\rtf1\\ud\\deff0");
    stringBuilder_0.AppendLine("}");
    return stringBuilder_0.ToString();
  }

  public static string GetColorAsString(Color color)
  {
    return !(color == Color.Transparent) ? $"\\red{color.R}\\green{color.G}\\blue{color.B}" : "";
  }
}
