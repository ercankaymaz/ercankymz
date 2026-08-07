// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Annotations.PdfGenericAnnotation
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Annotations;

internal sealed class PdfGenericAnnotation(PdfDictionary dict) : PdfAnnotation(dict)
{
  internal override DictionaryMeta Meta => PdfGenericAnnotation.Keys.Meta;

  internal new class Keys : PdfAnnotation.Keys
  {
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfGenericAnnotation.Keys._meta ?? (PdfGenericAnnotation.Keys._meta = KeysBase.CreateMeta(typeof (PdfGenericAnnotation.Keys)));
      }
    }
  }
}
