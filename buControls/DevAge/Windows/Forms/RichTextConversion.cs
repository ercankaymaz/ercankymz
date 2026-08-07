// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.RichTextConversion
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

public static class RichTextConversion
{
  public static RichText StringToRichText(string txt)
  {
    return RichTextConversion.StringToRichText(txt, FontStyle.Regular);
  }

  public static RichText StringToRichText(string txt, FontStyle fontStyle)
  {
    string empty = string.Empty;
    RichTextBox richTextBox = new RichTextBox();
    string rtf;
    try
    {
      richTextBox.Text = txt;
      if (fontStyle != 0)
        richTextBox.Font = new Font(richTextBox.Font, fontStyle);
      rtf = richTextBox.Rtf;
    }
    catch (Exception ex)
    {
      richTextBox.Text = string.Empty;
      rtf = richTextBox.Rtf;
    }
    richTextBox.Dispose();
    return new RichText(rtf);
  }

  public static string RichTextToString(RichText rtf)
  {
    string str = string.Empty;
    RichTextBox richTextBox = new RichTextBox();
    try
    {
      richTextBox.Rtf = rtf.Rtf;
      str = richTextBox.Text;
    }
    catch (Exception ex)
    {
    }
    richTextBox.Dispose();
    return str;
  }

  public static string RichTextToStringStripWhitespaces(RichText rtf)
  {
    return Regex.Replace(RichTextConversion.RichTextToString(rtf), "[\\t\\n\\r\\f\\v]", string.Empty);
  }
}
