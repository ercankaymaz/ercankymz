// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DefiniteLengthInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class DefiniteLengthInputStream : LimitedInputStream
{
  private static readonly byte[] EmptyBytes = new byte[0];
  private readonly int _originalLength;
  private int _remaining;

  internal DefiniteLengthInputStream(Stream inStream, int length, int limit)
    : base(inStream, limit)
  {
    if (length <= 0)
    {
      if (length < 0)
        throw new ArgumentException("negative lengths not allowed", nameof (length));
      this.SetParentEofDetect();
    }
    this._originalLength = length;
    this._remaining = length;
  }

  internal int Remaining => this._remaining;

  public override int ReadByte()
  {
    if (this._remaining < 2)
    {
      if (this._remaining == 0)
        return -1;
      int num = this._in.ReadByte();
      if (num < 0)
        throw new EndOfStreamException($"DEF length {this._originalLength.ToString()} object truncated by {this._remaining.ToString()}");
      this._remaining = 0;
      this.SetParentEofDetect();
      return num;
    }
    int num1 = this._in.ReadByte();
    if (num1 < 0)
      throw new EndOfStreamException($"DEF length {this._originalLength.ToString()} object truncated by {this._remaining.ToString()}");
    --this._remaining;
    return num1;
  }

  public override int Read(byte[] buf, int off, int len)
  {
    if (this._remaining == 0)
      return 0;
    int count = Math.Min(len, this._remaining);
    int num = this._in.Read(buf, off, count);
    if (num < 1)
      throw new EndOfStreamException($"DEF length {this._originalLength.ToString()} object truncated by {this._remaining.ToString()}");
    if ((this._remaining -= num) == 0)
      this.SetParentEofDetect();
    return num;
  }

  internal void ReadAllIntoByteArray(byte[] buf)
  {
    if (this._remaining != buf.Length)
      throw new ArgumentException("buffer length not right for data");
    if (this._remaining == 0)
      return;
    int limit = this.Limit;
    if (this._remaining >= limit)
      throw new IOException($"corrupted stream - out of bounds length found: {this._remaining.ToString()} >= {limit.ToString()}");
    if ((this._remaining -= Streams.ReadFully(this._in, buf, 0, buf.Length)) != 0)
      throw new EndOfStreamException($"DEF length {this._originalLength.ToString()} object truncated by {this._remaining.ToString()}");
    this.SetParentEofDetect();
  }

  internal byte[] ToArray()
  {
    if (this._remaining == 0)
      return DefiniteLengthInputStream.EmptyBytes;
    int limit = this.Limit;
    byte[] buf = this._remaining < limit ? new byte[this._remaining] : throw new IOException($"corrupted stream - out of bounds length found: {this._remaining.ToString()} >= {limit.ToString()}");
    if ((this._remaining -= Streams.ReadFully(this._in, buf, 0, buf.Length)) != 0)
      throw new EndOfStreamException($"DEF length {this._originalLength.ToString()} object truncated by {this._remaining.ToString()}");
    this.SetParentEofDetect();
    return buf;
  }
}
