// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfFont
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Fonts;
using System;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public class PdfFont(PdfDocument document) : PdfDictionary(document)
{
  private PdfFontDescriptor _fontDescriptor;
  internal PdfFontEncoding FontEncoding;
  internal CMapInfo _cmapInfo;
  internal PdfToUnicodeMap _toUnicode;

  internal PdfFontDescriptor FontDescriptor
  {
    get
    {
      Debug.Assert(this._fontDescriptor != null);
      return this._fontDescriptor;
    }
    set => this._fontDescriptor = value;
  }

  public bool IsSymbolFont => this._fontDescriptor.IsSymbolFont;

  internal void AddChars(string text)
  {
    if (this._cmapInfo == null)
      return;
    this._cmapInfo.AddChars(text);
  }

  internal void AddGlyphIndices(string glyphIndices)
  {
    if (this._cmapInfo == null)
      return;
    this._cmapInfo.AddGlyphIndices(glyphIndices);
  }

  internal CMapInfo CMapInfo
  {
    get => this._cmapInfo;
    set => this._cmapInfo = value;
  }

  internal PdfToUnicodeMap ToUnicodeMap
  {
    get => this._toUnicode;
    set => this._toUnicode = value;
  }

  internal static string CreateEmbeddedFontSubsetName(string name)
  {
    StringBuilder stringBuilder = new StringBuilder(64 /*0x40*/);
    byte[] byteArray = Guid.NewGuid().ToByteArray();
    for (int index = 0; index < 6; ++index)
      stringBuilder.Append((char) (65 + (int) byteArray[index] % 26));
    stringBuilder.Append('+');
    if (name.StartsWith("/"))
      stringBuilder.Append(name.Substring(1));
    else
      stringBuilder.Append(name);
    return stringBuilder.ToString();
  }

  public class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string Subtype = "/Subtype";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string BaseFont = "/BaseFont";
    [KeyInfo(KeyType.Dictionary | KeyType.MustBeIndirect, typeof (PdfFontDescriptor))]
    public const string FontDescriptor = "/FontDescriptor";
  }
}
