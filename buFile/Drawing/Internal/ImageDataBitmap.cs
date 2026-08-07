// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Internal.ImageDataBitmap
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf;

#nullable disable
namespace PdfSharp.Drawing.Internal;

internal class ImageDataBitmap : ImageData
{
  private byte[] _data;
  private int _length;
  private byte[] _dataFax;
  private int _lengthFax;
  private byte[] _alphaMask;
  private int _alphaMaskLength;
  private byte[] _bitmapMask;
  private int _bitmapMaskLength;
  private byte[] _paletteData;
  private int _paletteDataLength;
  public bool SegmentedColorMask;
  public int IsBitonal;
  public int K;
  public bool IsGray;
  internal readonly PdfDocument _document;

  private ImageDataBitmap()
  {
  }

  internal ImageDataBitmap(PdfDocument document) => this._document = document;

  public byte[] Data
  {
    get => this._data;
    internal set => this._data = value;
  }

  public int Length
  {
    get => this._length;
    internal set => this._length = value;
  }

  public byte[] DataFax
  {
    get => this._dataFax;
    internal set => this._dataFax = value;
  }

  public int LengthFax
  {
    get => this._lengthFax;
    internal set => this._lengthFax = value;
  }

  public byte[] AlphaMask
  {
    get => this._alphaMask;
    internal set => this._alphaMask = value;
  }

  public int AlphaMaskLength
  {
    get => this._alphaMaskLength;
    internal set => this._alphaMaskLength = value;
  }

  public byte[] BitmapMask
  {
    get => this._bitmapMask;
    internal set => this._bitmapMask = value;
  }

  public int BitmapMaskLength
  {
    get => this._bitmapMaskLength;
    internal set => this._bitmapMaskLength = value;
  }

  public byte[] PaletteData
  {
    get => this._paletteData;
    set => this._paletteData = value;
  }

  public int PaletteDataLength
  {
    get => this._paletteDataLength;
    set => this._paletteDataLength = value;
  }
}
