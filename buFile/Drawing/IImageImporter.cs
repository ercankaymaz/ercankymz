// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.IImageImporter
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf;

#nullable disable
namespace PdfSharp.Drawing;

internal interface IImageImporter
{
  ImportedImage ImportImage(StreamReaderHelper stream, PdfDocument document);

  ImageData PrepareImage(ImagePrivateData data);
}
