// Decompiled with JetBrains decompiler
// Type: System.Buffers.MemoryPool`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace System.Buffers;

[ComVisible(true)]
public abstract class MemoryPool<T> : IDisposable
{
  private static readonly MemoryPool<T> s_shared = (MemoryPool<T>) new ArrayMemoryPool<T>();

  public static MemoryPool<T> Shared => MemoryPool<T>.s_shared;

  public abstract IMemoryOwner<T> Rent(int minBufferSize = -1);

  public abstract int MaxBufferSize { get; }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected abstract void Dispose(bool disposing);
}
