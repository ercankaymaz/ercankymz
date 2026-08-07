// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfType0Font
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfType0Font : PdfFont
{
  private XPdfFontOptions _fontOptions;
  private readonly PdfCIDFont _descendantFont;

  public PdfType0Font(PdfDocument document)
    : base(document)
  {
  }

  public PdfType0Font(PdfDocument document, XFont font, bool vertical)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Font");
    this.Elements.SetName("/Subtype", "/Type0");
    this.Elements.SetName("/Encoding", vertical ? "/Identity-V" : "/Identity-H");
    OpenTypeDescriptor descriptorFor = (OpenTypeDescriptor) FontDescriptorCache.GetOrCreateDescriptorFor(font);
    this.FontDescriptor = new PdfFontDescriptor(document, descriptorFor);
    this._fontOptions = font.PdfOptions;
    Debug.Assert(this._fontOptions != null);
    this._cmapInfo = new CMapInfo(descriptorFor);
    this._descendantFont = new PdfCIDFont(document, this.FontDescriptor, font);
    this._descendantFont.CMapInfo = this._cmapInfo;
    this._toUnicode = new PdfToUnicodeMap(document, this._cmapInfo);
    document.Internals.AddObject((PdfObject) this._toUnicode);
    this.Elements.Add("/ToUnicode", (PdfItem) this._toUnicode);
    this.BaseFont = font.GlyphTypeface.GetBaseName();
    this.BaseFont = PdfFont.CreateEmbeddedFontSubsetName(this.BaseFont);
    this.FontDescriptor.FontName = this.BaseFont;
    this._descendantFont.BaseFont = this.BaseFont;
    PdfArray pdfArray = new PdfArray(document);
    this.Owner._irefTable.Add((PdfObject) this._descendantFont);
    pdfArray.Elements.Add((PdfItem) this._descendantFont.Reference);
    this.Elements["/DescendantFonts"] = (PdfItem) pdfArray;
  }

  public PdfType0Font(PdfDocument document, string idName, byte[] fontData, bool vertical)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Font");
    this.Elements.SetName("/Subtype", "/Type0");
    this.Elements.SetName("/Encoding", vertical ? "/Identity-V" : "/Identity-H");
    OpenTypeDescriptor descriptor = (OpenTypeDescriptor) FontDescriptorCache.GetOrCreateDescriptor(idName, fontData);
    this.FontDescriptor = new PdfFontDescriptor(document, descriptor);
    this._fontOptions = new XPdfFontOptions(PdfFontEncoding.Unicode);
    Debug.Assert(this._fontOptions != null);
    this._cmapInfo = new CMapInfo(descriptor);
    this._descendantFont = new PdfCIDFont(document, this.FontDescriptor, fontData);
    this._descendantFont.CMapInfo = this._cmapInfo;
    this._toUnicode = new PdfToUnicodeMap(document, this._cmapInfo);
    document.Internals.AddObject((PdfObject) this._toUnicode);
    this.Elements.Add("/ToUnicode", (PdfItem) this._toUnicode);
    this.BaseFont = descriptor.FontName;
    if (!this.BaseFont.Contains("+"))
      this.BaseFont = PdfFont.CreateEmbeddedFontSubsetName(this.BaseFont);
    this.FontDescriptor.FontName = this.BaseFont;
    this._descendantFont.BaseFont = this.BaseFont;
    PdfArray pdfArray = new PdfArray(document);
    this.Owner._irefTable.Add((PdfObject) this._descendantFont);
    pdfArray.Elements.Add((PdfItem) this._descendantFont.Reference);
    this.Elements["/DescendantFonts"] = (PdfItem) pdfArray;
  }

  private XPdfFontOptions FontOptions => this._fontOptions;

  public string BaseFont
  {
    get => this.Elements.GetName("/BaseFont");
    set => this.Elements.SetName("/BaseFont", value);
  }

  internal PdfCIDFont DescendantFont => this._descendantFont;

  internal override void PrepareForSave()
  {
    base.PrepareForSave();
    OpenTypeDescriptor descriptor = this.FontDescriptor._descriptor;
    StringBuilder stringBuilder = new StringBuilder("[");
    if (this._cmapInfo != null)
    {
      int[] glyphIndices = this._cmapInfo.GetGlyphIndices();
      int length = glyphIndices.Length;
      int[] numArray = new int[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = descriptor.GlyphIndexToPdfWidth(glyphIndices[index]);
      for (int index = 0; index < length; ++index)
        stringBuilder.AppendFormat("{0}[{1}]", (object) glyphIndices[index], (object) numArray[index]);
      stringBuilder.Append("]");
      this._descendantFont.Elements.SetValue("/W", (PdfItem) new PdfLiteral(stringBuilder.ToString()));
    }
    this._descendantFont.PrepareForSave();
    this._toUnicode.PrepareForSave();
  }

  internal override DictionaryMeta Meta => PdfType0Font.Keys.Meta;

  public new sealed class Keys : PdfFont.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
    public new const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public new const string Subtype = "/Subtype";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public new const string BaseFont = "/BaseFont";
    [KeyInfo(KeyType.StreamOrName | KeyType.Required)]
    public const string Encoding = "/Encoding";
    [KeyInfo(KeyType.Array | KeyType.Required)]
    public const string DescendantFonts = "/DescendantFonts";
    [KeyInfo(KeyType.Stream | KeyType.Optional)]
    public const string ToUnicode = "/ToUnicode";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        if (PdfType0Font.Keys._meta == null)
          PdfType0Font.Keys._meta = KeysBase.CreateMeta(typeof (PdfType0Font.Keys));
        return PdfType0Font.Keys._meta;
      }
    }
  }
}
