// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ByteQueue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class ByteQueue
{
  private byte[] m_databuf;
  private int m_skipped;
  private int m_available;
  private bool m_readOnlyBuf;

  private static int GetAllocationSize(int i) => Integers.HighestOneBit((256 /*0x0100*/ | i) << 1);

  public ByteQueue()
    : this(0)
  {
  }

  public ByteQueue(int capacity)
  {
    this.m_databuf = capacity == 0 ? TlsUtilities.EmptyBytes : new byte[capacity];
  }

  public ByteQueue(byte[] buf, int off, int len)
  {
    this.m_databuf = buf;
    this.m_skipped = off;
    this.m_available = len;
    this.m_readOnlyBuf = true;
  }

  public void AddData(byte[] buf, int off, int len)
  {
    if (this.m_readOnlyBuf)
      throw new InvalidOperationException("Cannot add data to read-only buffer");
    if (this.m_available == 0)
    {
      if (len > this.m_databuf.Length)
        this.m_databuf = new byte[ByteQueue.GetAllocationSize(len)];
      this.m_skipped = 0;
    }
    else if (this.m_skipped + this.m_available + len > this.m_databuf.Length)
    {
      int allocationSize = ByteQueue.GetAllocationSize(this.m_available + len);
      if (allocationSize > this.m_databuf.Length)
      {
        byte[] destinationArray = new byte[allocationSize];
        Array.Copy((Array) this.m_databuf, this.m_skipped, (Array) destinationArray, 0, this.m_available);
        this.m_databuf = destinationArray;
      }
      else
        Array.Copy((Array) this.m_databuf, this.m_skipped, (Array) this.m_databuf, 0, this.m_available);
      this.m_skipped = 0;
    }
    Array.Copy((Array) buf, off, (Array) this.m_databuf, this.m_skipped + this.m_available, len);
    this.m_available += len;
  }

  public int Available => this.m_available;

  public void CopyTo(Stream output, int length)
  {
    if (length > this.m_available)
      throw new InvalidOperationException($"Cannot copy {length.ToString()} bytes, only got {this.m_available.ToString()}");
    output.Write(this.m_databuf, this.m_skipped, length);
  }

  public void Read(byte[] buf, int offset, int len, int skip)
  {
    if (buf.Length - offset < len)
      throw new ArgumentException($"Buffer size of {buf.Length.ToString()} is too small for a read of {len.ToString()} bytes");
    if (this.m_available - skip < len)
      throw new InvalidOperationException("Not enough data to read");
    Array.Copy((Array) this.m_databuf, this.m_skipped + skip, (Array) buf, offset, len);
  }

  internal HandshakeMessageInput ReadHandshakeMessage(int length)
  {
    if (length > this.m_available)
      throw new InvalidOperationException($"Cannot read {length.ToString()} bytes, only got {this.m_available.ToString()}");
    int skipped = this.m_skipped;
    this.m_available -= length;
    this.m_skipped += length;
    return new HandshakeMessageInput(this.m_databuf, skipped, length);
  }

  public int ReadInt32()
  {
    if (this.m_available < 4)
      throw new InvalidOperationException("Not enough data to read");
    return TlsUtilities.ReadInt32(this.m_databuf, this.m_skipped);
  }

  public short ReadUint8(int skip)
  {
    if (this.m_available < skip + 1)
      throw new InvalidOperationException("Not enough data to read");
    return TlsUtilities.ReadUint8(this.m_databuf, this.m_skipped + skip);
  }

  public int ReadUint16(int skip)
  {
    if (this.m_available < skip + 2)
      throw new InvalidOperationException("Not enough data to read");
    return TlsUtilities.ReadUint16(this.m_databuf, this.m_skipped + skip);
  }

  public void RemoveData(int i)
  {
    if (i > this.m_available)
      throw new InvalidOperationException($"Cannot remove {i.ToString()} bytes, only got {this.m_available.ToString()}");
    this.m_available -= i;
    this.m_skipped += i;
  }

  public void RemoveData(byte[] buf, int off, int len, int skip)
  {
    this.Read(buf, off, len, skip);
    this.RemoveData(skip + len);
  }

  public byte[] RemoveData(int len, int skip)
  {
    byte[] buf = new byte[len];
    this.RemoveData(buf, 0, len, skip);
    return buf;
  }

  public void Shrink()
  {
    if (this.m_available == 0)
    {
      this.m_databuf = TlsUtilities.EmptyBytes;
      this.m_skipped = 0;
    }
    else
    {
      int allocationSize = ByteQueue.GetAllocationSize(this.m_available);
      if (allocationSize >= this.m_databuf.Length)
        return;
      byte[] destinationArray = new byte[allocationSize];
      Array.Copy((Array) this.m_databuf, this.m_skipped, (Array) destinationArray, 0, this.m_available);
      this.m_databuf = destinationArray;
      this.m_skipped = 0;
    }
  }
}
