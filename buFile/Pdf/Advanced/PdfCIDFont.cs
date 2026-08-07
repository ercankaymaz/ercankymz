// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfCIDFont
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Pdf.Filters;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal class PdfCIDFont : PdfFont
{
  public PdfCIDFont(PdfDocument document)
    : base(document)
  {
  }

  public PdfCIDFont(PdfDocument document, PdfFontDescriptor fontDescriptor, XFont font)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Font");
    this.Elements.SetName("/Subtype", "/CIDFontType2");
    PdfDictionary pdfDictionary = new PdfDictionary();
    pdfDictionary.Elements.SetString("/Ordering", "Identity");
    pdfDictionary.Elements.SetString("/Registry", "Adobe");
    pdfDictionary.Elements.SetInteger("/Supplement", 0);
    this.Elements.SetValue("/CIDSystemInfo", (PdfItem) pdfDictionary);
    this.FontDescriptor = fontDescriptor;
    this.Owner._irefTable.Add((PdfObject) fontDescriptor);
    this.Elements["/FontDescriptor"] = (PdfItem) fontDescriptor.Reference;
    this.FontEncoding = font.PdfOptions.FontEncoding;
  }

  public PdfCIDFont(PdfDocument document, PdfFontDescriptor fontDescriptor, byte[] fontData)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Font");
    this.Elements.SetName("/Subtype", "/CIDFontType2");
    PdfDictionary pdfDictionary = new PdfDictionary();
    pdfDictionary.Elements.SetString("/Ordering", "Identity");
    pdfDictionary.Elements.SetString("/Registry", "Adobe");
    pdfDictionary.Elements.SetInteger("/Supplement", 0);
    this.Elements.SetValue("/CIDSystemInfo", (PdfItem) pdfDictionary);
    this.FontDescriptor = fontDescriptor;
    this.Owner._irefTable.Add((PdfObject) fontDescriptor);
    this.Elements["/FontDescriptor"] = (PdfItem) fontDescriptor.Reference;
    this.FontEncoding = PdfFontEncoding.Unicode;
  }

  public string BaseFont
  {
    get => this.Elements.GetName("/BaseFont");
    set => this.Elements.SetName("/BaseFont", value);
  }

  internal override void PrepareForSave()
  {
    base.PrepareForSave();
    byte[] data = (this.FontDescriptor._descriptor.FontFace.loca != null ? this.FontDescriptor._descriptor.FontFace.CreateFontSubSet(this._cmapInfo.GlyphIndices, true) : this.FontDescriptor._descriptor.FontFace).FontSource.Bytes;
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
  }

  internal override DictionaryMeta Meta => PdfCIDFont.Keys.Meta;

  public new sealed class Keys : PdfFont.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
    public new const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public new const string Subtype = "/Subtype";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public new const string BaseFont = "/BaseFont";
    [KeyInfo(KeyType.Dictionary | KeyType.Required)]
    public const string CIDSystemInfo = "/CIDSystemInfo";
    [KeyInfo(KeyType.Dictionary | KeyType.MustBeIndirect, typeof (PdfFontDescriptor))]
    public new const string FontDescriptor = "/FontDescriptor";
    [KeyInfo(KeyType.Integer)]
    public const string DW = "/DW";
    [KeyInfo(KeyType.Array, typeof (PdfArray))]
    public const string W = "/W";
    [KeyInfo(KeyType.Array)]
    public const string DW2 = "/DW2";
    [KeyInfo(KeyType.Array, typeof (PdfArray))]
    public const string W2 = "/W2";
    [KeyInfo(KeyType.Dictionary | KeyType.StreamOrName)]
    public const string CIDToGIDMap = "/CIDToGIDMap";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfCIDFont.Keys._meta ?? (PdfCIDFont.Keys._meta = KeysBase.CreateMeta(typeof (PdfCIDFont.Keys)));
      }
    }
  }
}
