// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.BufferManager
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Buffers;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class BufferManager
{
  private readonly string m_name;
  private readonly int m_maxBufferSize;
  private readonly ArrayPool<byte> m_arrayPool;
  private const byte kCookieLocked = 165;
  private const byte kCookieUnlocked = 90;
  private const byte kCookieLength = 1;

  public BufferManager(string name, int maxBufferSize)
  {
    this.m_name = name;
    this.m_arrayPool = maxBufferSize <= 1048576 /*0x100000*/ ? ArrayPool<byte>.Shared : ArrayPool<byte>.Create(maxBufferSize + 1, 4);
    this.m_maxBufferSize = maxBufferSize;
  }

  public byte[] TakeBuffer(int size, string owner)
  {
    byte[] buffer = size <= this.m_maxBufferSize ? this.m_arrayPool.Rent(size + 1) : throw new ArgumentOutOfRangeException(nameof (size));
    buffer[buffer.Length - 1] = (byte) 90;
    return buffer;
  }

  public void TransferBuffer(byte[] buffer, string owner)
  {
  }

  public static void LockBuffer(byte[] buffer)
  {
    if (buffer[buffer.Length - 1] != (byte) 90)
      throw new InvalidOperationException("Buffer is already locked.");
    buffer[buffer.Length - 1] = (byte) 165;
  }

  public static void UnlockBuffer(byte[] buffer)
  {
    if (buffer[buffer.Length - 1] != (byte) 165)
      throw new InvalidOperationException("Buffer is not locked.");
    buffer[buffer.Length - 1] = (byte) 90;
  }

  public void ReturnBuffer(byte[] buffer, string owner)
  {
    if (buffer == null)
      return;
    if (buffer[buffer.Length - 1] != (byte) 90)
      throw new InvalidOperationException("Buffer has been locked.");
    buffer[buffer.Length - 1] = byte.MaxValue;
    this.m_arrayPool.Return(buffer);
  }
}
