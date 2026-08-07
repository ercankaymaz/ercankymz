// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Annotations.PdfWidgetAnnotation
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Annotations;

internal sealed class PdfWidgetAnnotation : PdfAnnotation
{
  public PdfWidgetAnnotation() => this.Initialize();

  public PdfWidgetAnnotation(PdfDocument document)
    : base(document)
  {
    this.Initialize();
  }

  private void Initialize() => this.Elements.SetName("/Subtype", "/Widget");

  internal override DictionaryMeta Meta => PdfWidgetAnnotation.Keys.Meta;

  internal new class Keys : PdfAnnotation.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string H = "/H";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string MK = "/MK";
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfWidgetAnnotation.Keys._meta ?? (PdfWidgetAnnotation.Keys._meta = KeysBase.CreateMeta(typeof (PdfWidgetAnnotation.Keys)));
      }
    }
  }
}
