// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.ArraySegmentStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class ArraySegmentStream : MemoryStream
{
  private int m_bufferIndex;
  private ArraySegment<byte> m_currentBuffer;
  private int m_currentPosition;
  private BufferCollection m_buffers;
  private BufferManager m_bufferManager;
  private int m_start;
  private int m_count;
  private int m_bufferSize;
  private int m_endOfLastBuffer;

  public ArraySegmentStream(BufferCollection buffers)
  {
    this.m_buffers = buffers;
    this.m_endOfLastBuffer = 0;
    if (this.m_buffers.Count > 0)
      this.m_endOfLastBuffer = this.m_buffers[this.m_buffers.Count - 1].Count;
    this.SetCurrentBuffer(0);
  }

  public ArraySegmentStream(BufferManager bufferManager, int bufferSize, int start, int count)
  {
    this.m_buffers = new BufferCollection();
    this.m_bufferManager = bufferManager;
    this.m_bufferSize = bufferSize;
    this.m_start = start;
    this.m_count = count;
    this.m_endOfLastBuffer = 0;
    this.SetCurrentBuffer(0);
  }

  public BufferCollection GetBuffers(string owner)
  {
    BufferCollection buffers = new BufferCollection(this.m_buffers.Count);
    for (int index = 0; index < this.m_buffers.Count; ++index)
    {
      BufferManager bufferManager = this.m_bufferManager;
      ArraySegment<byte> buffer = this.m_buffers[index];
      byte[] array1 = buffer.Array;
      string owner1 = owner;
      bufferManager.TransferBuffer(array1, owner1);
      BufferCollection bufferCollection = buffers;
      buffer = this.m_buffers[index];
      byte[] array2 = buffer.Array;
      buffer = this.m_buffers[index];
      int offset = buffer.Offset;
      int bufferCount = this.GetBufferCount(index);
      ArraySegment<byte> arraySegment = new ArraySegment<byte>(array2, offset, bufferCount);
      bufferCollection.Add(arraySegment);
    }
    this.m_buffers.Clear();
    return buffers;
  }

  public override bool CanRead => true;

  public override bool CanSeek => true;

  public override bool CanWrite => true;

  public override void Flush()
  {
  }

  public override long Length => (long) this.GetAbsoluteLength();

  public override long Position
  {
    get => (long) this.GetAbsolutePosition();
    set => this.Seek(value, SeekOrigin.Begin);
  }

  public override int ReadByte()
  {
    while (this.m_currentBuffer.Array != null)
    {
      if (this.GetBufferCount(this.m_bufferIndex) - this.m_currentPosition > 0)
        return (int) this.m_currentBuffer.Array[this.m_currentBuffer.Offset + this.m_currentPosition++];
      this.SetCurrentBuffer(this.m_bufferIndex + 1);
    }
    return -1;
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    int num1 = 0;
    while (count > 0 && this.m_currentBuffer.Array != null)
    {
      int length = this.GetBufferCount(this.m_bufferIndex) - this.m_currentPosition;
      if (length <= count)
      {
        Array.Copy((Array) this.m_currentBuffer.Array, this.m_currentPosition + this.m_currentBuffer.Offset, (Array) buffer, offset, length);
        num1 += length;
        offset += length;
        count -= length;
        this.SetCurrentBuffer(this.m_bufferIndex + 1);
      }
      else
      {
        Array.Copy((Array) this.m_currentBuffer.Array, this.m_currentPosition + this.m_currentBuffer.Offset, (Array) buffer, offset, count);
        int num2 = num1 + count;
        this.m_currentPosition += count;
        return num2;
      }
    }
    return num1;
  }

  public override long Seek(long offset, SeekOrigin origin)
  {
    switch (origin)
    {
      case SeekOrigin.Current:
        offset += (long) this.GetAbsolutePosition();
        break;
      case SeekOrigin.End:
        offset += (long) this.GetAbsoluteLength();
        break;
    }
    int num = offset >= 0L ? (int) offset : throw new IOException("Cannot seek beyond the beginning of the stream.");
    if (num >= this.GetAbsolutePosition())
      this.CheckEndOfStream();
    for (int index = 0; index < this.m_buffers.Count; ++index)
    {
      int bufferCount = this.GetBufferCount(index);
      if (offset > (long) bufferCount)
      {
        offset -= (long) bufferCount;
      }
      else
      {
        this.SetCurrentBuffer(index);
        this.m_currentPosition = (int) offset;
        return (long) num;
      }
    }
    throw new IOException("Cannot seek beyond the end of the stream.");
  }

  public override void SetLength(long value) => throw new NotSupportedException();

  public override void WriteByte(byte value)
  {
    while (true)
    {
      this.CheckEndOfStream();
      if (this.m_currentBuffer.Count - this.m_currentPosition < 1)
        this.SetCurrentBuffer(this.m_bufferIndex + 1);
      else
        break;
    }
    this.m_currentBuffer.Array[this.m_currentBuffer.Offset + this.m_currentPosition] = value;
    ++this.m_currentPosition;
    if (this.m_bufferIndex != this.m_buffers.Count - 1 || this.m_endOfLastBuffer >= this.m_currentPosition)
      return;
    this.m_endOfLastBuffer = this.m_currentPosition;
  }

  public override void Write(byte[] buffer, int offset, int count)
  {
    while (count > 0)
    {
      this.CheckEndOfStream();
      int length = this.m_currentBuffer.Count - this.m_currentPosition;
      if (length < count)
      {
        Array.Copy((Array) buffer, offset, (Array) this.m_currentBuffer.Array, this.m_currentPosition + this.m_currentBuffer.Offset, length);
        offset += length;
        count -= length;
        this.SetCurrentBuffer(this.m_bufferIndex + 1);
      }
      else
      {
        Array.Copy((Array) buffer, offset, (Array) this.m_currentBuffer.Array, this.m_currentPosition + this.m_currentBuffer.Offset, count);
        this.m_currentPosition += count;
        if (this.m_bufferIndex != this.m_buffers.Count - 1 || this.m_endOfLastBuffer >= this.m_currentPosition)
          break;
        this.m_endOfLastBuffer = this.m_currentPosition;
        break;
      }
    }
  }

  public override byte[] ToArray()
  {
    int absoluteLength = this.GetAbsoluteLength();
    if (absoluteLength == 0)
      return Array.Empty<byte>();
    byte[] array1 = new byte[absoluteLength];
    int num = 0;
    for (int index = 0; index < this.m_buffers.Count; ++index)
    {
      int bufferCount = this.GetBufferCount(index);
      ArraySegment<byte> buffer = this.m_buffers[index];
      byte[] array2 = buffer.Array;
      buffer = this.m_buffers[index];
      int offset = buffer.Offset;
      byte[] destinationArray = array1;
      int destinationIndex = num;
      int length = bufferCount;
      Array.Copy((Array) array2, offset, (Array) destinationArray, destinationIndex, length);
      num += bufferCount;
    }
    return array1;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private void SetCurrentBuffer(int index)
  {
    if (index >= 0 && index < this.m_buffers.Count)
    {
      this.m_bufferIndex = index;
      this.m_currentBuffer = this.m_buffers[index];
      this.m_currentPosition = 0;
    }
    else
    {
      this.m_currentBuffer = new ArraySegment<byte>();
      this.m_currentPosition = 0;
    }
  }

  private int GetAbsoluteLength()
  {
    int absoluteLength = 0;
    for (int index = 0; index < this.m_buffers.Count; ++index)
      absoluteLength += this.GetBufferCount(index);
    return absoluteLength;
  }

  private int GetAbsolutePosition()
  {
    if (this.m_currentBuffer.Array == null)
      return this.GetAbsoluteLength();
    int num = 0;
    for (int index = 0; index < this.m_bufferIndex; ++index)
      num += this.GetBufferCount(index);
    return num + this.m_currentPosition;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private int GetBufferCount(int index)
  {
    return index == this.m_buffers.Count - 1 ? this.m_endOfLastBuffer : this.m_buffers[index].Count;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private void CheckEndOfStream()
  {
    if (this.m_currentBuffer.Array != null)
      return;
    if (this.m_bufferManager == null)
      throw new IOException("Attempt to write past end of stream.");
    this.m_buffers.Add(new ArraySegment<byte>(this.m_bufferManager.TakeBuffer(this.m_bufferSize, "ArraySegmentStream.Write"), this.m_start, this.m_count));
    this.m_endOfLastBuffer = 0;
    this.SetCurrentBuffer(this.m_buffers.Count - 1);
  }
}
