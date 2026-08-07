// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Internal.ImportedImageBitmap
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf;

#nullable disable
namespace PdfSharp.Drawing.Internal;

internal class ImportedImageBitmap(
  IImageImporter importer,
  ImagePrivateDataBitmap data,
  PdfDocument document) : ImportedImage(importer, (ImagePrivateData) data, document)
{
  internal override ImageData PrepareImageData()
  {
    ImagePrivateDataBitmap data = (ImagePrivateDataBitmap) this.Data;
    ImageDataBitmap dest = new ImageDataBitmap(this._document);
    data.CopyBitmap(dest);
    return (ImageData) dest;
  }
}
