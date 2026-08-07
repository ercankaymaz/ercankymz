// Decompiled with JetBrains decompiler
// Type: System.Buffers.MemoryManager`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Buffers;

[ComVisible(true)]
public abstract class MemoryManager<T> : IMemoryOwner<T>, IDisposable, IPinnable
{
  public virtual System.Memory<T> Memory => new System.Memory<T>(this, this.GetSpan().Length);

  public abstract Span<T> GetSpan();

  public abstract MemoryHandle Pin(int elementIndex = 0);

  public abstract void Unpin();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected System.Memory<T> CreateMemory(int length) => new System.Memory<T>(this, length);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  protected System.Memory<T> CreateMemory(int start, int length)
  {
    return new System.Memory<T>(this, start, length);
  }

  protected internal virtual bool TryGetArray(out ArraySegment<T> segment)
  {
    segment = new ArraySegment<T>();
    return false;
  }

  void IDisposable.Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected abstract void Dispose(bool disposing);
}
