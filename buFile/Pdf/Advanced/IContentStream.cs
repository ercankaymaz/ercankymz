// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.IContentStream
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal interface IContentStream
{
  PdfResources Resources { get; }

  string GetFontName(XFont font, out PdfFont pdfFont);

  string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont);

  string GetImageName(XImage image);

  string GetFormName(XForm form);
}
