// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.FontWriter
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.IO;

#nullable disable
namespace PdfSharp.Fonts;

internal class FontWriter
{
  private Stream _stream;

  public FontWriter(Stream stream) => this._stream = stream;

  public void Close(bool closeUnderlyingStream)
  {
    if (this._stream != null & closeUnderlyingStream)
    {
      this._stream.Close();
      this._stream.Dispose();
    }
    this._stream = (Stream) null;
  }

  public void Close() => this.Close(true);

  public int Position
  {
    get => (int) this._stream.Position;
    set => this._stream.Position = (long) value;
  }

  public void WriteByte(byte value) => this._stream.WriteByte(value);

  public void WriteByte(int value) => this._stream.WriteByte((byte) value);

  public void WriteShort(short value)
  {
    this._stream.WriteByte((byte) ((uint) value >> 8));
    this._stream.WriteByte((byte) value);
  }

  public void WriteShort(int value) => this.WriteShort((short) value);

  public void WriteUShort(ushort value)
  {
    this._stream.WriteByte((byte) ((uint) value >> 8));
    this._stream.WriteByte((byte) value);
  }

  public void WriteUShort(int value) => this.WriteUShort((ushort) value);

  public void WriteInt(int value)
  {
    this._stream.WriteByte((byte) (value >> 24));
    this._stream.WriteByte((byte) (value >> 16 /*0x10*/));
    this._stream.WriteByte((byte) (value >> 8));
    this._stream.WriteByte((byte) value);
  }

  public void WriteUInt(uint value)
  {
    this._stream.WriteByte((byte) (value >> 24));
    this._stream.WriteByte((byte) (value >> 16 /*0x10*/));
    this._stream.WriteByte((byte) (value >> 8));
    this._stream.WriteByte((byte) value);
  }

  public void Write(byte[] buffer) => this._stream.Write(buffer, 0, buffer.Length);

  public void Write(byte[] buffer, int offset, int count)
  {
    this._stream.Write(buffer, offset, count);
  }

  internal Stream Stream => this._stream;
}
