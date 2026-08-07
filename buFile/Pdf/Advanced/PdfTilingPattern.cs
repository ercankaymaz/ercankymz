// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfTilingPattern
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfTilingPattern : PdfDictionaryWithContentStream
{
  public PdfTilingPattern(PdfDocument document)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Pattern");
    this.Elements["/PatternType"] = (PdfItem) new PdfInteger(1);
  }

  internal override DictionaryMeta Meta => PdfTilingPattern.Keys.Meta;

  internal new sealed class Keys : PdfDictionaryWithContentStream.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string PatternType = "/PatternType";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string PaintType = "/PaintType";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string TilingType = "/TilingType";
    [KeyInfo(KeyType.Rectangle | KeyType.Optional)]
    public const string BBox = "/BBox";
    [KeyInfo(KeyType.Real | KeyType.Required)]
    public const string XStep = "/XStep";
    [KeyInfo(KeyType.Real | KeyType.Required)]
    public const string YStep = "/YStep";
    [KeyInfo(KeyType.Dictionary | KeyType.Required)]
    public new const string Resources = "/Resources";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Matrix = "/Matrix";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfTilingPattern.Keys._meta ?? (PdfTilingPattern.Keys._meta = KeysBase.CreateMeta(typeof (PdfTilingPattern.Keys)));
      }
    }
  }
}
