// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfShadingPattern
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Drawing.Pdf;
using System;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfShadingPattern : PdfDictionaryWithContentStream
{
  public PdfShadingPattern(PdfDocument document)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Pattern");
    this.Elements["/PatternType"] = (PdfItem) new PdfInteger(2);
  }

  internal void SetupFromBrush(
    XLinearGradientBrush brush,
    XMatrix matrix,
    XGraphicsPdfRenderer renderer)
  {
    if (brush == null)
      throw new ArgumentNullException(nameof (brush));
    PdfShading pdfShading = new PdfShading(this._document);
    pdfShading.SetupFromBrush(brush, renderer);
    this.Elements["/Shading"] = (PdfItem) pdfShading;
    this.Elements.SetMatrix("/Matrix", matrix);
  }

  internal override DictionaryMeta Meta => PdfShadingPattern.Keys.Meta;

  internal new sealed class Keys : PdfDictionaryWithContentStream.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string PatternType = "/PatternType";
    [KeyInfo(KeyType.Dictionary | KeyType.Required)]
    public const string Shading = "/Shading";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Matrix = "/Matrix";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string ExtGState = "/ExtGState";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfShadingPattern.Keys._meta ?? (PdfShadingPattern.Keys._meta = KeysBase.CreateMeta(typeof (PdfShadingPattern.Keys)));
      }
    }
  }
}
