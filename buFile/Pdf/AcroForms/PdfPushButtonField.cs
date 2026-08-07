// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfPushButtonField
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfPushButtonField : PdfButtonField
{
  internal PdfPushButtonField(PdfDocument document)
    : base(document)
  {
    this._document = document;
  }

  internal PdfPushButtonField(PdfDictionary dict)
    : base(dict)
  {
  }

  internal override DictionaryMeta Meta => PdfPushButtonField.Keys.Meta;

  public new class Keys : PdfAcroField.Keys
  {
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfPushButtonField.Keys._meta ?? (PdfPushButtonField.Keys._meta = KeysBase.CreateMeta(typeof (PdfPushButtonField.Keys)));
      }
    }
  }
}
