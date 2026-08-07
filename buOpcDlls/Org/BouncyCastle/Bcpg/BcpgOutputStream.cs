// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.BcpgOutputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class BcpgOutputStream : BaseOutputStream
{
  private Stream outStr;
  private bool useOldFormat;
  private byte[] partialBuffer;
  private int partialBufferLength;
  private int partialPower;
  private int partialOffset;
  private const int BufferSizePower = 16 /*0x10*/;

  internal static BcpgOutputStream Wrap(Stream outStr)
  {
    return outStr is BcpgOutputStream bcpgOutputStream ? bcpgOutputStream : new BcpgOutputStream(outStr);
  }

  public BcpgOutputStream(Stream outStr)
    : this(outStr, false)
  {
  }

  public BcpgOutputStream(Stream outStr, bool newFormatOnly)
  {
    this.outStr = outStr ?? throw new ArgumentNullException(nameof (outStr));
    this.useOldFormat = !newFormatOnly;
  }

  public BcpgOutputStream(Stream outStr, PacketTag tag)
  {
    this.outStr = outStr ?? throw new ArgumentNullException(nameof (outStr));
    this.WriteHeader(tag, true, true, 0L);
  }

  public BcpgOutputStream(Stream outStr, PacketTag tag, long length, bool oldFormat)
  {
    this.outStr = outStr ?? throw new ArgumentNullException(nameof (outStr));
    if (length > (long) uint.MaxValue)
    {
      this.WriteHeader(tag, false, true, 0L);
      this.partialBufferLength = 65536 /*0x010000*/;
      this.partialBuffer = new byte[this.partialBufferLength];
      this.partialPower = 16 /*0x10*/;
      this.partialOffset = 0;
    }
    else
      this.WriteHeader(tag, oldFormat, false, length);
  }

  public BcpgOutputStream(Stream outStr, PacketTag tag, long length)
  {
    this.outStr = outStr ?? throw new ArgumentNullException(nameof (outStr));
    this.WriteHeader(tag, false, false, length);
  }

  public BcpgOutputStream(Stream outStr, PacketTag tag, byte[] buffer)
  {
    this.outStr = outStr ?? throw new ArgumentNullException(nameof (outStr));
    this.WriteHeader(tag, false, true, 0L);
    this.partialBuffer = buffer;
    uint length = (uint) this.partialBuffer.Length;
    this.partialPower = 0;
    while (length != 1U)
    {
      length >>= 1;
      ++this.partialPower;
    }
    if (this.partialPower > 30)
      throw new IOException("Buffer cannot be greater than 2^30 in length.");
    this.partialBufferLength = 1 << this.partialPower;
    this.partialOffset = 0;
  }

  private void WriteNewPacketLength(long bodyLen)
  {
    if (bodyLen < 192L /*0xC0*/)
      this.outStr.WriteByte((byte) bodyLen);
    else if (bodyLen <= 8383L)
    {
      bodyLen -= 192L /*0xC0*/;
      this.outStr.WriteByte((byte) ((bodyLen >> 8 & (long) byte.MaxValue) + 192L /*0xC0*/));
      this.outStr.WriteByte((byte) bodyLen);
    }
    else
    {
      this.outStr.WriteByte(byte.MaxValue);
      this.outStr.WriteByte((byte) (bodyLen >> 24));
      this.outStr.WriteByte((byte) (bodyLen >> 16 /*0x10*/));
      this.outStr.WriteByte((byte) (bodyLen >> 8));
      this.outStr.WriteByte((byte) bodyLen);
    }
  }

  private void WriteHeader(PacketTag packetTag, bool oldPackets, bool partial, long bodyLen)
  {
    int num1 = 128 /*0x80*/;
    if (this.partialBuffer != null)
    {
      this.PartialFlushLast();
      this.partialBuffer = (byte[]) null;
    }
    int num2 = (int) packetTag;
    if (num2 <= 15 & oldPackets)
    {
      int num3 = num1 | num2 << 2;
      if (partial)
        this.WriteByte((byte) (num3 | 3));
      else if (bodyLen <= (long) byte.MaxValue)
      {
        this.WriteByte((byte) num3);
        this.WriteByte((byte) bodyLen);
      }
      else if (bodyLen <= (long) ushort.MaxValue)
      {
        this.WriteByte((byte) (num3 | 1));
        this.WriteByte((byte) (bodyLen >> 8));
        this.WriteByte((byte) bodyLen);
      }
      else
      {
        this.WriteByte((byte) (num3 | 2));
        this.WriteByte((byte) (bodyLen >> 24));
        this.WriteByte((byte) (bodyLen >> 16 /*0x10*/));
        this.WriteByte((byte) (bodyLen >> 8));
        this.WriteByte((byte) bodyLen);
      }
    }
    else
    {
      this.WriteByte((byte) (num1 | 64 /*0x40*/ | num2));
      if (partial)
        this.partialOffset = 0;
      else
        this.WriteNewPacketLength(bodyLen);
    }
  }

  private void PartialFlush()
  {
    this.outStr.WriteByte((byte) (224 /*0xE0*/ | this.partialPower));
    this.outStr.Write(this.partialBuffer, 0, this.partialBufferLength);
    this.partialOffset = 0;
  }

  private void PartialFlushLast()
  {
    this.WriteNewPacketLength((long) this.partialOffset);
    this.outStr.Write(this.partialBuffer, 0, this.partialOffset);
    this.partialOffset = 0;
  }

  private void PartialWrite(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (this.partialOffset == this.partialBufferLength)
      this.PartialFlush();
    if (count <= this.partialBufferLength - this.partialOffset)
    {
      Array.Copy((Array) buffer, offset, (Array) this.partialBuffer, this.partialOffset, count);
      this.partialOffset += count;
    }
    else
    {
      int length = this.partialBufferLength - this.partialOffset;
      Array.Copy((Array) buffer, offset, (Array) this.partialBuffer, this.partialOffset, length);
      offset += length;
      count -= length;
      this.PartialFlush();
      while (count > this.partialBufferLength)
      {
        Array.Copy((Array) buffer, offset, (Array) this.partialBuffer, 0, this.partialBufferLength);
        offset += this.partialBufferLength;
        count -= this.partialBufferLength;
        this.PartialFlush();
      }
      Array.Copy((Array) buffer, offset, (Array) this.partialBuffer, 0, count);
      this.partialOffset = count;
    }
  }

  private void PartialWriteByte(byte value)
  {
    if (this.partialOffset == this.partialBufferLength)
      this.PartialFlush();
    this.partialBuffer[this.partialOffset++] = value;
  }

  public override void Write(byte[] buffer, int offset, int count)
  {
    if (this.partialBuffer != null)
      this.PartialWrite(buffer, offset, count);
    else
      this.outStr.Write(buffer, offset, count);
  }

  public override void WriteByte(byte value)
  {
    if (this.partialBuffer != null)
      this.PartialWriteByte(value);
    else
      this.outStr.WriteByte(value);
  }

  internal virtual void WriteShort(short n) => this.Write((byte) ((uint) n >> 8), (byte) n);

  internal virtual void WriteInt(int n)
  {
    this.Write((byte) (n >> 24), (byte) (n >> 16 /*0x10*/), (byte) (n >> 8), (byte) n);
  }

  internal virtual void WriteLong(long n)
  {
    this.Write((byte) (n >> 56), (byte) (n >> 48 /*0x30*/), (byte) (n >> 40), (byte) (n >> 32 /*0x20*/), (byte) (n >> 24), (byte) (n >> 16 /*0x10*/), (byte) (n >> 8), (byte) n);
  }

  public void WritePacket(ContainedPacket p) => p.Encode(this);

  internal void WritePacket(PacketTag tag, byte[] body)
  {
    this.WritePacket(tag, body, this.useOldFormat);
  }

  internal void WritePacket(PacketTag tag, byte[] body, bool oldFormat)
  {
    this.WriteHeader(tag, oldFormat, false, (long) body.Length);
    this.Write(body);
  }

  public void WriteObject(BcpgObject bcpgObject) => bcpgObject.Encode(this);

  public void WriteObjects(params BcpgObject[] v)
  {
    foreach (BcpgObject bcpgObject in v)
      bcpgObject.Encode(this);
  }

  public override void Flush() => this.outStr.Flush();

  public void Finish()
  {
    if (this.partialBuffer == null)
      return;
    this.PartialFlushLast();
    Array.Clear((Array) this.partialBuffer, 0, this.partialBuffer.Length);
    this.partialBuffer = (byte[]) null;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
    {
      this.Finish();
      this.outStr.Flush();
      this.outStr.Dispose();
    }
    base.Dispose(disposing);
  }
}
