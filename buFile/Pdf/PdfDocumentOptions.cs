// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfDocumentOptions
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf;

public sealed class PdfDocumentOptions
{
  private PdfColorMode _colorMode = PdfColorMode.Rgb;
  private bool _compressContentStreams = false;
  private bool _noCompression;
  private PdfFlateEncodeMode _flateEncodeMode = PdfFlateEncodeMode.Default;
  private bool _enableCcittCompressionForBilevelImages = false;
  private PdfUseFlateDecoderForJpegImages _useFlateDecoderForJpegImages = PdfUseFlateDecoderForJpegImages.Never;

  internal PdfDocumentOptions(PdfDocument document)
  {
  }

  public PdfColorMode ColorMode
  {
    get => this._colorMode;
    set => this._colorMode = value;
  }

  public bool CompressContentStreams
  {
    get => this._compressContentStreams;
    set => this._compressContentStreams = value;
  }

  public bool NoCompression
  {
    get => this._noCompression;
    set => this._noCompression = value;
  }

  public PdfFlateEncodeMode FlateEncodeMode
  {
    get => this._flateEncodeMode;
    set => this._flateEncodeMode = value;
  }

  public bool EnableCcittCompressionForBilevelImages
  {
    get => this._enableCcittCompressionForBilevelImages;
    set => this._enableCcittCompressionForBilevelImages = value;
  }

  public PdfUseFlateDecoderForJpegImages UseFlateDecoderForJpegImages
  {
    get => this._useFlateDecoderForJpegImages;
    set => this._useFlateDecoderForJpegImages = value;
  }
}
