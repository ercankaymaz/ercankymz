// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.ImportedImage
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf;
using System;

#nullable disable
namespace PdfSharp.Drawing;

internal abstract class ImportedImage
{
  private ImageInformation _information = new ImageInformation();
  private ImageData _imageData;
  private IImageImporter _importer;
  internal ImagePrivateData Data;
  internal readonly PdfDocument _document;

  protected ImportedImage(IImageImporter importer, ImagePrivateData data, PdfDocument document)
  {
    this.Data = data;
    this._document = document;
    data.Image = this;
    this._importer = importer;
  }

  public ImageInformation Information
  {
    get => this._information;
    private set => this._information = value;
  }

  public bool HasImageData => this._imageData != null;

  public ImageData ImageData
  {
    get
    {
      if (!this.HasImageData)
        this._imageData = this.PrepareImageData();
      return this._imageData;
    }
    private set => this._imageData = value;
  }

  internal virtual ImageData PrepareImageData() => throw new NotImplementedException();
}
