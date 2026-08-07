// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XPdfFontOptions
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf;
using System;

#nullable disable
namespace PdfSharp.Drawing;

public class XPdfFontOptions
{
  private readonly PdfFontEncoding _fontEncoding;

  internal XPdfFontOptions()
  {
  }

  [Obsolete("Must not specify an embedding option anymore.")]
  public XPdfFontOptions(PdfFontEncoding encoding, PdfFontEmbedding embedding)
  {
    this._fontEncoding = encoding;
  }

  public XPdfFontOptions(PdfFontEncoding encoding) => this._fontEncoding = encoding;

  [Obsolete("Must not specify an embedding option anymore.")]
  public XPdfFontOptions(PdfFontEmbedding embedding)
  {
    this._fontEncoding = PdfFontEncoding.WinAnsi;
  }

  public PdfFontEmbedding FontEmbedding => PdfFontEmbedding.Always;

  public PdfFontEncoding FontEncoding => this._fontEncoding;

  public static XPdfFontOptions WinAnsiDefault => new XPdfFontOptions(PdfFontEncoding.WinAnsi);

  public static XPdfFontOptions UnicodeDefault => new XPdfFontOptions(PdfFontEncoding.Unicode);
}
