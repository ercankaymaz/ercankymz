// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfTransparencyGroupAttributes
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfTransparencyGroupAttributes : PdfGroupAttributes
{
  internal PdfTransparencyGroupAttributes(PdfDocument thisDocument)
    : base(thisDocument)
  {
    this.Elements.SetName("/S", "/Transparency");
  }

  internal override DictionaryMeta Meta => PdfTransparencyGroupAttributes.Keys.Meta;

  public new sealed class Keys : PdfGroupAttributes.Keys
  {
    [KeyInfo(KeyType.NameOrArray | KeyType.Optional)]
    public const string CS = "/CS";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string I = "/I";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string K = "/K";
    private static DictionaryMeta _meta;

    internal new static DictionaryMeta Meta
    {
      get
      {
        return PdfTransparencyGroupAttributes.Keys._meta ?? (PdfTransparencyGroupAttributes.Keys._meta = KeysBase.CreateMeta(typeof (PdfTransparencyGroupAttributes.Keys)));
      }
    }
  }
}
