// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfTrueTypeFont
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf.Filters;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal class PdfTrueTypeFont : PdfFont
{
  private readonly XPdfFontOptions _fontOptions;

  public PdfTrueTypeFont(PdfDocument document)
    : base(document)
  {
  }

  public PdfTrueTypeFont(PdfDocument document, XFont font)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Font");
    this.Elements.SetName("/Subtype", "/TrueType");
    OpenTypeDescriptor descriptorFor = (OpenTypeDescriptor) FontDescriptorCache.GetOrCreateDescriptorFor(font);
    this.FontDescriptor = new PdfFontDescriptor(document, descriptorFor);
    this._fontOptions = font.PdfOptions;
    Debug.Assert(this._fontOptions != null);
    this._cmapInfo = new CMapInfo(descriptorFor);
    this.BaseFont = font.GlyphTypeface.GetBaseName();
    if (this._fontOptions.FontEmbedding == PdfFontEmbedding.Always)
      this.BaseFont = PdfFont.CreateEmbeddedFontSubsetName(this.BaseFont);
    this.FontDescriptor.FontName = this.BaseFont;
    Debug.Assert(this._fontOptions.FontEncoding == PdfFontEncoding.WinAnsi);
    if (!this.IsSymbolFont)
      this.Encoding = "/WinAnsiEncoding";
    this.Owner._irefTable.Add((PdfObject) this.FontDescriptor);
    this.Elements["/FontDescriptor"] = (PdfItem) this.FontDescriptor.Reference;
    this.FontEncoding = font.PdfOptions.FontEncoding;
  }

  private XPdfFontOptions FontOptions => this._fontOptions;

  public string BaseFont
  {
    get => this.Elements.GetName("/BaseFont");
    set => this.Elements.SetName("/BaseFont", value);
  }

  public int FirstChar
  {
    get => this.Elements.GetInteger("/FirstChar");
    set => this.Elements.SetInteger("/FirstChar", value);
  }

  public int LastChar
  {
    get => this.Elements.GetInteger("/LastChar");
    set => this.Elements.SetInteger("/LastChar", value);
  }

  public PdfArray Widths => (PdfArray) this.Elements.GetValue("/Widths", VCF.Create);

  public string Encoding
  {
    get => this.Elements.GetName("/Encoding");
    set => this.Elements.SetName("/Encoding", value);
  }

  internal override void PrepareForSave()
  {
    base.PrepareForSave();
    byte[] data = this.FontDescriptor._descriptor.FontFace.CreateFontSubSet(this._cmapInfo.GlyphIndices, false).FontSource.Bytes;
    PdfDictionary pdfDictionary = new PdfDictionary(this.Owner);
    this.Owner.Internals.AddObject((PdfObject) pdfDictionary);
    this.FontDescriptor.Elements["/FontFile2"] = (PdfItem) pdfDictionary.Reference;
    pdfDictionary.Elements["/Length1"] = (PdfItem) new PdfInteger(data.Length);
    if (!this.Owner.Options.NoCompression)
    {
      data = Filtering.FlateDecode.Encode(data, this._document.Options.FlateEncodeMode);
      pdfDictionary.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
    }
    pdfDictionary.Elements["/Length"] = (PdfItem) new PdfInteger(data.Length);
    pdfDictionary.CreateStream(data);
    this.FirstChar = 0;
    this.LastChar = (int) byte.MaxValue;
    PdfArray widths = this.Widths;
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      widths.Elements.Add((PdfItem) new PdfInteger(this.FontDescriptor._descriptor.Widths[index]));
  }

  internal override DictionaryMeta Meta => PdfTrueTypeFont.Keys.Meta;

  public new sealed class Keys : PdfFont.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
    public new const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public new const string Subtype = "/Subtype";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Name = "/Name";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public new const string BaseFont = "/BaseFont";
    [KeyInfo(KeyType.Integer)]
    public const string FirstChar = "/FirstChar";
    [KeyInfo(KeyType.Integer)]
    public const string LastChar = "/LastChar";
    [KeyInfo(KeyType.Array, typeof (PdfArray))]
    public const string Widths = "/Widths";
    [KeyInfo(KeyType.Dictionary | KeyType.MustBeIndirect, typeof (PdfFontDescriptor))]
    public new const string FontDescriptor = "/FontDescriptor";
    [KeyInfo(KeyType.Dictionary)]
    public const string Encoding = "/Encoding";
    [KeyInfo(KeyType.Stream | KeyType.Optional)]
    public const string ToUnicode = "/ToUnicode";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfTrueTypeFont.Keys._meta ?? (PdfTrueTypeFont.Keys._meta = KeysBase.CreateMeta(typeof (PdfTrueTypeFont.Keys)));
      }
    }
  }
}
