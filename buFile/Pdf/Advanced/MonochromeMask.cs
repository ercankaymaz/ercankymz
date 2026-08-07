// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.MonochromeMask
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal class MonochromeMask
{
  private readonly byte[] _maskData;
  private readonly int _sizeX;
  private readonly int _sizeY;
  private int _writeOffset;
  private int _byteBuffer;
  private int _bitsWritten;

  public byte[] MaskData => this._maskData;

  public MonochromeMask(int sizeX, int sizeY)
  {
    this._sizeX = sizeX;
    this._sizeY = sizeY;
    this._maskData = new byte[(sizeX + 7) / 8 * sizeY];
    this.StartLine(0);
  }

  public void StartLine(int newCurrentLine)
  {
    this._bitsWritten = 0;
    this._byteBuffer = 0;
    this._writeOffset = (this._sizeX + 7) / 8 * (this._sizeY - 1 - newCurrentLine);
  }

  public void AddPel(bool isTransparent)
  {
    if (this._bitsWritten >= this._sizeX)
      return;
    if (isTransparent)
      this._byteBuffer = (this._byteBuffer << 1) + 1;
    else
      this._byteBuffer <<= 1;
    ++this._bitsWritten;
    if ((this._bitsWritten & 7) == 0)
    {
      this._maskData[this._writeOffset] = (byte) this._byteBuffer;
      ++this._writeOffset;
      this._byteBuffer = 0;
    }
    else
    {
      if (this._bitsWritten != this._sizeX)
        return;
      this._byteBuffer <<= 8 - (this._bitsWritten & 7);
      this._maskData[this._writeOffset] = (byte) this._byteBuffer;
    }
  }

  public void AddPel(int shade) => this.AddPel(shade < 128 /*0x80*/);
}
