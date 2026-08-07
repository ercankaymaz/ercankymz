// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Internal.ImagePrivateDataDct
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Drawing.Internal;

internal class ImagePrivateDataDct : ImagePrivateData
{
  private readonly byte[] _data;
  private readonly int _length;

  public ImagePrivateDataDct(byte[] data, int length)
  {
    this._data = data;
    this._length = length;
  }

  public byte[] Data => this._data;

  public int Length => this._length;
}
