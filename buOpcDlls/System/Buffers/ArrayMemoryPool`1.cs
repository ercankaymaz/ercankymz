// Decompiled with JetBrains decompiler
// Type: System.Buffers.ArrayMemoryPool`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;

#nullable disable
namespace System.Buffers;

internal sealed class ArrayMemoryPool<T> : MemoryPool<T>
{
  private const int s_maxBufferSize = 2147483647 /*0x7FFFFFFF*/;

  public sealed override int MaxBufferSize => int.MaxValue;

  public sealed override IMemoryOwner<T> Rent(int minimumBufferSize = -1)
  {
    if (minimumBufferSize == -1)
      minimumBufferSize = 1 + 4095 /*0x0FFF*/ / Unsafe.SizeOf<T>();
    else if ((uint) minimumBufferSize > (uint) int.MaxValue)
      ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.minimumBufferSize);
    return (IMemoryOwner<T>) new ArrayMemoryPool<T>.ArrayMemoryPoolBuffer(minimumBufferSize);
  }

  protected sealed override void Dispose(bool disposing)
  {
  }

  private sealed class ArrayMemoryPoolBuffer : IMemoryOwner<T>, IDisposable
  {
    private T[] _array;

    public ArrayMemoryPoolBuffer(int size) => this._array = ArrayPool<T>.Shared.Rent(size);

    public Memory<T> Memory
    {
      get
      {
        T[] array = this._array;
        if (array == null)
          ThrowHelper.ThrowObjectDisposedException_ArrayMemoryPoolBuffer();
        return new Memory<T>(array);
      }
    }

    public void Dispose()
    {
      T[] array = this._array;
      if (array == null)
        return;
      this._array = (T[]) null;
      ArrayPool<T>.Shared.Return(array);
    }
  }
}
