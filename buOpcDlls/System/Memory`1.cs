// Decompiled with JetBrains decompiler
// Type: System.Memory`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Buffers;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace System;

[System.Runtime.CompilerServices.System.Memory.IsReadOnly]
[DebuggerTypeProxy(typeof (MemoryDebugView<>))]
[DebuggerDisplay("{ToString(),raw}")]
[ComVisible(true)]
public struct Memory<T>
{
  private readonly object _object;
  private readonly int _index;
  private readonly int _length;
  private const int RemoveFlagsBitMask = 2147483647 /*0x7FFFFFFF*/;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe Memory(T[] array)
  {
    if (array == null)
    {
      *(System.Memory<T>*) ref this = new System.Memory<T>();
    }
    else
    {
      if ((object) default (T) == null && array.GetType() != typeof (T[]))
        ThrowHelper.ThrowArrayTypeMismatchException();
      this._object = (object) array;
      this._index = 0;
      this._length = array.Length;
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal unsafe Memory(T[] array, int start)
  {
    if (array == null)
    {
      if (start != 0)
        ThrowHelper.ThrowArgumentOutOfRangeException();
      *(System.Memory<T>*) ref this = new System.Memory<T>();
    }
    else
    {
      if ((object) default (T) == null && array.GetType() != typeof (T[]))
        ThrowHelper.ThrowArrayTypeMismatchException();
      if ((uint) start > (uint) array.Length)
        ThrowHelper.ThrowArgumentOutOfRangeException();
      this._object = (object) array;
      this._index = start;
      this._length = array.Length - start;
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe Memory(T[] array, int start, int length)
  {
    if (array == null)
    {
      if (start != 0 || length != 0)
        ThrowHelper.ThrowArgumentOutOfRangeException();
      *(System.Memory<T>*) ref this = new System.Memory<T>();
    }
    else
    {
      if ((object) default (T) == null && array.GetType() != typeof (T[]))
        ThrowHelper.ThrowArrayTypeMismatchException();
      if ((uint) start > (uint) array.Length || (uint) length > (uint) (array.Length - start))
        ThrowHelper.ThrowArgumentOutOfRangeException();
      this._object = (object) array;
      this._index = start;
      this._length = length;
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal Memory(MemoryManager<T> manager, int length)
  {
    if (length < 0)
      ThrowHelper.ThrowArgumentOutOfRangeException();
    this._object = (object) manager;
    this._index = int.MinValue;
    this._length = length;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal Memory(MemoryManager<T> manager, int start, int length)
  {
    if (length < 0 || start < 0)
      ThrowHelper.ThrowArgumentOutOfRangeException();
    this._object = (object) manager;
    this._index = start | int.MinValue;
    this._length = length;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal Memory(object obj, int start, int length)
  {
    this._object = obj;
    this._index = start;
    this._length = length;
  }

  public static implicit operator System.Memory<T>(T[] array) => new System.Memory<T>(array);

  public static implicit operator System.Memory<T>(ArraySegment<T> segment)
  {
    return new System.Memory<T>(segment.Array, segment.Offset, segment.Count);
  }

  public static implicit operator ReadOnlyMemory<T>(System.Memory<T> memory)
  {
    return Unsafe.As<System.Memory<T>, ReadOnlyMemory<T>>(ref memory);
  }

  public static System.Memory<T> Empty => new System.Memory<T>();

  public int Length => this._length & int.MaxValue;

  public bool IsEmpty => (this._length & int.MaxValue) == 0;

  public override string ToString()
  {
    if (!(typeof (T) == typeof (char)))
      return $"System.Memory<{typeof (T).Name}>[{this._length & int.MaxValue}]";
    return !(this._object is string str) ? this.Span.ToString() : str.Substring(this._index, this._length & int.MaxValue);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public System.Memory<T> Slice(int start)
  {
    int length = this._length;
    int num = length & int.MaxValue;
    if ((uint) start > (uint) num)
      ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);
    return new System.Memory<T>(this._object, this._index + start, length - start);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public System.Memory<T> Slice(int start, int length)
  {
    int length1 = this._length;
    int num = length1 & int.MaxValue;
    if ((uint) start > (uint) num || (uint) length > (uint) (num - start))
      ThrowHelper.ThrowArgumentOutOfRangeException();
    return new System.Memory<T>(this._object, this._index + start, length | length1 & int.MinValue);
  }

  public System.Span<T> Span
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)] get
    {
      if (this._index < 0)
        return ((MemoryManager<T>) this._object).GetSpan().Slice(this._index & int.MaxValue, this._length);
      if (typeof (T) == typeof (char) && this._object is string o)
        return new System.Span<T>(Unsafe.As<Pinnable<T>>((object) o), MemoryExtensions.StringAdjustment, o.Length).Slice(this._index, this._length);
      return this._object != null ? new System.Span<T>((T[]) this._object, this._index, this._length & int.MaxValue) : new System.Span<T>();
    }
  }

  public void CopyTo(System.Memory<T> destination) => this.Span.CopyTo(destination.Span);

  public bool TryCopyTo(System.Memory<T> destination) => this.Span.TryCopyTo(destination.Span);

  public unsafe MemoryHandle Pin()
  {
    if (this._index < 0)
      return ((MemoryManager<T>) this._object).Pin(this._index & int.MaxValue);
    if (typeof (T) == typeof (char) && this._object is string str)
    {
      GCHandle handle = GCHandle.Alloc((object) str, GCHandleType.Pinned);
      return new MemoryHandle(Unsafe.Add<T>((void*) handle.AddrOfPinnedObject(), this._index), handle);
    }
    if (!(this._object is T[] objArray))
      return new MemoryHandle();
    if (this._length < 0)
      return new MemoryHandle(Unsafe.Add<T>(Unsafe.AsPointer<T>(ref MemoryMarshal.GetReference<T>((System.Span<T>) objArray)), this._index));
    GCHandle handle1 = GCHandle.Alloc((object) objArray, GCHandleType.Pinned);
    return new MemoryHandle(Unsafe.Add<T>((void*) handle1.AddrOfPinnedObject(), this._index), handle1);
  }

  public T[] ToArray() => this.Span.ToArray();

  [EditorBrowsable(EditorBrowsableState.Never)]
  public override bool Equals(object obj)
  {
    switch (obj)
    {
      case ReadOnlyMemory<T> readOnlyMemory:
        return readOnlyMemory.Equals((ReadOnlyMemory<T>) this);
      case System.Memory<T> other:
        return this.Equals(other);
      default:
        return false;
    }
  }

  public bool Equals(System.Memory<T> other)
  {
    return this._object == other._object && this._index == other._index && this._length == other._length;
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  public override int GetHashCode()
  {
    if (this._object == null)
      return 0;
    int hashCode1 = this._object.GetHashCode();
    int num = this._index;
    int hashCode2 = num.GetHashCode();
    num = this._length;
    int hashCode3 = num.GetHashCode();
    return System.Memory<T>.CombineHashCodes(hashCode1, hashCode2, hashCode3);
  }

  private static int CombineHashCodes(int left, int right) => (left << 5) + left ^ right;

  private static int CombineHashCodes(int h1, int h2, int h3)
  {
    return System.Memory<T>.CombineHashCodes(System.Memory<T>.CombineHashCodes(h1, h2), h3);
  }
}
