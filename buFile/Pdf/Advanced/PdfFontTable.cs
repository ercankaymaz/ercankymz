// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfFontTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfFontTable(PdfDocument document) : PdfResourceTable(document)
{
  private readonly Dictionary<string, PdfFont> _fonts = new Dictionary<string, PdfFont>();

  public PdfFont GetFont(XFont font)
  {
    string key = font.Selector;
    if (key == null)
    {
      key = PdfFontTable.ComputeKey(font);
      font.Selector = key;
    }
    PdfFont font1;
    if (!this._fonts.TryGetValue(key, out font1))
    {
      font1 = !font.Unicode ? (PdfFont) new PdfTrueTypeFont(this.Owner, font) : (PdfFont) new PdfType0Font(this.Owner, font, font.IsVertical);
      Debug.Assert(font1.Owner == this.Owner);
      this._fonts[key] = font1;
    }
    return font1;
  }

  public PdfFont GetFont(string idName, byte[] fontData)
  {
    Debug.Assert(false);
    string key = (string) null;
    PdfFont font;
    if (!this._fonts.TryGetValue(key, out font))
    {
      font = (PdfFont) new PdfType0Font(this.Owner, idName, fontData, false);
      Debug.Assert(font.Owner == this.Owner);
      this._fonts[key] = font;
    }
    return font;
  }

  public PdfFont TryGetFont(string idName)
  {
    Debug.Assert(false);
    PdfFont font;
    this._fonts.TryGetValue((string) null, out font);
    return font;
  }

  internal static string ComputeKey(XFont font)
  {
    XGlyphTypeface glyphTypeface = font.GlyphTypeface;
    return glyphTypeface.Fontface.FullFaceName.ToLowerInvariant() + (glyphTypeface.IsBold ? "/b" : "") + (glyphTypeface.IsItalic ? "/i" : "") + font.Unicode.ToString();
  }

  public void PrepareForSave()
  {
    foreach (PdfObject pdfObject in this._fonts.Values)
      pdfObject.PrepareForSave();
  }
}
