// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfGroupAttributes
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public abstract class PdfGroupAttributes : PdfDictionary
{
  internal PdfGroupAttributes(PdfDocument thisDocument)
    : base(thisDocument)
  {
    this.Elements.SetName("/Type", "/Group");
  }

  internal override DictionaryMeta Meta => PdfGroupAttributes.Keys.Meta;

  public class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string S = "/S";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfGroupAttributes.Keys._meta ?? (PdfGroupAttributes.Keys._meta = KeysBase.CreateMeta(typeof (PdfGroupAttributes.Keys)));
      }
    }
  }
}
