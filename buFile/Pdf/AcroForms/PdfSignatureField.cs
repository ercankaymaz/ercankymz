// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfSignatureField
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfSignatureField : PdfAcroField
{
  internal PdfSignatureField(PdfDocument document)
    : base(document)
  {
  }

  internal PdfSignatureField(PdfDictionary dict)
    : base(dict)
  {
  }

  internal override DictionaryMeta Meta => PdfSignatureField.Keys.Meta;

  public new class Keys : PdfAcroField.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string Filter = "/Filter";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string SubFilter = "/SubFilter";
    [KeyInfo(KeyType.Array | KeyType.Required)]
    public const string ByteRange = "/ByteRange";
    [KeyInfo(KeyType.String | KeyType.Required)]
    public const string Contents = "/Contents";
    [KeyInfo(KeyType.TextString | KeyType.Optional)]
    public const string Name = "/Name";
    [KeyInfo(KeyType.Date | KeyType.Optional)]
    public const string M = "/M";
    [KeyInfo(KeyType.TextString | KeyType.Optional)]
    public const string Location = "/Location";
    [KeyInfo(KeyType.TextString | KeyType.Optional)]
    public const string Reason = "/Reason";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfSignatureField.Keys._meta ?? (PdfSignatureField.Keys._meta = KeysBase.CreateMeta(typeof (PdfSignatureField.Keys)));
      }
    }
  }
}
