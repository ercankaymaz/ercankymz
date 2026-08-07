// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfFontDescriptor
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Fonts.OpenType;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfFontDescriptor : PdfDictionary
{
  internal OpenTypeDescriptor _descriptor;
  private bool _isSymbolFont;

  internal PdfFontDescriptor(PdfDocument document, OpenTypeDescriptor descriptor)
    : base(document)
  {
    this._descriptor = descriptor;
    this.Elements.SetName("/Type", "/FontDescriptor");
    this.Elements.SetInteger("/Ascent", this._descriptor.DesignUnitsToPdf((double) this._descriptor.Ascender));
    this.Elements.SetInteger("/CapHeight", this._descriptor.DesignUnitsToPdf((double) this._descriptor.CapHeight));
    this.Elements.SetInteger("/Descent", this._descriptor.DesignUnitsToPdf((double) this._descriptor.Descender));
    this.Elements.SetInteger("/Flags", (int) this.FlagsFromDescriptor(this._descriptor));
    this.Elements.SetRectangle("/FontBBox", new PdfRectangle((double) this._descriptor.DesignUnitsToPdf((double) this._descriptor.XMin), (double) this._descriptor.DesignUnitsToPdf((double) this._descriptor.YMin), (double) this._descriptor.DesignUnitsToPdf((double) this._descriptor.XMax), (double) this._descriptor.DesignUnitsToPdf((double) this._descriptor.YMax)));
    this.Elements.SetReal("/ItalicAngle", (double) this._descriptor.ItalicAngle);
    this.Elements.SetInteger("/StemV", this._descriptor.StemV);
    this.Elements.SetInteger("/XHeight", this._descriptor.DesignUnitsToPdf((double) this._descriptor.XHeight));
  }

  public string FontName
  {
    get => this.Elements.GetName("/FontName");
    set => this.Elements.SetName("/FontName", value);
  }

  public bool IsSymbolFont => this._isSymbolFont;

  private PdfFontDescriptorFlags FlagsFromDescriptor(OpenTypeDescriptor descriptor)
  {
    this._isSymbolFont = descriptor.FontFace.cmap.symbol;
    return (PdfFontDescriptorFlags) (0 | (descriptor.FontFace.cmap.symbol ? 4 : 32 /*0x20*/));
  }

  internal override DictionaryMeta Meta => PdfFontDescriptor.Keys.Meta;

  public sealed class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "FontDescriptor")]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string FontName = "/FontName";
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string FontFamily = "/FontFamily";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string FontStretch = "/FontStretch";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string FontWeight = "/FontWeight";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string Flags = "/Flags";
    [KeyInfo(KeyType.Rectangle | KeyType.Required)]
    public const string FontBBox = "/FontBBox";
    [KeyInfo(KeyType.Real | KeyType.Required)]
    public const string ItalicAngle = "/ItalicAngle";
    [KeyInfo(KeyType.Real | KeyType.Required)]
    public const string Ascent = "/Ascent";
    [KeyInfo(KeyType.Real | KeyType.Required)]
    public const string Descent = "/Descent";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string Leading = "/Leading";
    [KeyInfo(KeyType.Real | KeyType.Required)]
    public const string CapHeight = "/CapHeight";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string XHeight = "/XHeight";
    [KeyInfo(KeyType.Real | KeyType.Required)]
    public const string StemV = "/StemV";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string StemH = "/StemH";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string AvgWidth = "/AvgWidth";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string MaxWidth = "/MaxWidth";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string MissingWidth = "/MissingWidth";
    [KeyInfo(KeyType.Stream | KeyType.Optional)]
    public const string FontFile = "/FontFile";
    [KeyInfo(KeyType.Stream | KeyType.Optional)]
    public const string FontFile2 = "/FontFile2";
    [KeyInfo(KeyType.Stream | KeyType.Optional)]
    public const string FontFile3 = "/FontFile3";
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string CharSet = "/CharSet";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        if (PdfFontDescriptor.Keys._meta == null)
          PdfFontDescriptor.Keys._meta = KeysBase.CreateMeta(typeof (PdfFontDescriptor.Keys));
        return PdfFontDescriptor.Keys._meta;
      }
    }
  }
}
