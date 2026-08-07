// Decompiled with JetBrains decompiler
// Type: System.ReadOnlySpan`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace System;

[System.Runtime.CompilerServices.System.Memory.IsByRefLike]
[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
[System.Runtime.CompilerServices.System.Memory.IsReadOnly]
[DebuggerTypeProxy(typeof (SpanDebugView<>))]
[DebuggerDisplay("{ToString(),raw}")]
[DebuggerTypeProxy(typeof (SpanDebugView<>))]
[DebuggerDisplay("{ToString(),raw}")]
[ComVisible(true)]
public struct ReadOnlySpan<T>
{
  private readonly System.Pinnable<T> _pinnable;
  private readonly IntPtr _byteOffset;
  private readonly int _length;

  public int Length => this._length;

  public bool IsEmpty => this._length == 0;

  public static bool operator !=(ReadOnlySpan<T> left, ReadOnlySpan<T> right) => !(left == right);

  [Obsolete("Equals() on ReadOnlySpan will always throw an exception. Use == instead.")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public override bool Equals(object obj)
  {
    throw new NotSupportedException(System.System.Memory3568249.SR.NotSupported_CannotCallEqualsOnSpan);
  }

  [Obsolete("GetHashCode() on ReadOnlySpan will always throw an exception.")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public override int GetHashCode()
  {
    throw new NotSupportedException(System.System.Memory3568249.SR.NotSupported_CannotCallGetHashCodeOnSpan);
  }

  public static implicit operator ReadOnlySpan<T>(T[] array) => new ReadOnlySpan<T>(array);

  public static implicit operator ReadOnlySpan<T>(ArraySegment<T> segment)
  {
    return new ReadOnlySpan<T>(segment.Array, segment.Offset, segment.Count);
  }

  public static ReadOnlySpan<T> Empty => new ReadOnlySpan<T>();

  public ReadOnlySpan<T>.Enumerator GetEnumerator() => new ReadOnlySpan<T>.Enumerator(this);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe ReadOnlySpan(T[] array)
  {
    if (array == null)
    {
      *(ReadOnlySpan<T>*) ref this = new ReadOnlySpan<T>();
    }
    else
    {
      this._length = array.Length;
      this._pinnable = Unsafe.As<System.Pinnable<T>>((object) array);
      this._byteOffset = SpanHelpers.PerTypeValues<T>.ArrayAdjustment;
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe ReadOnlySpan(T[] array, int start, int length)
  {
    if (array == null)
    {
      if (start != 0 || length != 0)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);
      *(ReadOnlySpan<T>*) ref this = new ReadOnlySpan<T>();
    }
    else
    {
      if ((uint) start > (uint) array.Length || (uint) length > (uint) (array.Length - start))
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);
      this._length = length;
      this._pinnable = Unsafe.As<System.Pinnable<T>>((object) array);
      this._byteOffset = SpanHelpers.PerTypeValues<T>.ArrayAdjustment.Add<T>(start);
    }
  }

  [CLSCompliant(false)]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe ReadOnlySpan(void* pointer, int length)
  {
    if (SpanHelpers.IsReferenceOrContainsReferences<T>())
      ThrowHelper.ThrowArgumentException_InvalidTypeWithPointersNotSupported(typeof (T));
    if (length < 0)
      ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);
    this._length = length;
    this._pinnable = (System.Pinnable<T>) null;
    this._byteOffset = new IntPtr(pointer);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal ReadOnlySpan(System.Pinnable<T> pinnable, IntPtr byteOffset, int length)
  {
    this._length = length;
    this._pinnable = pinnable;
    this._byteOffset = byteOffset;
  }

  [System.Runtime.CompilerServices.System.Memory.IsReadOnly]
  public unsafe ref T this[int index]
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: System.Runtime.CompilerServices.System.Memory.IsReadOnly] get
    {
      if ((uint) index >= (uint) this._length)
        ThrowHelper.ThrowIndexOutOfRangeException();
      return ref (this._pinnable == null ? ref Unsafe.Add<T>(ref Unsafe.AsRef<T>(this._byteOffset.ToPointer()), index) : ref Unsafe.Add<T>(ref Unsafe.AddByteOffset<T>(ref this._pinnable.Data, this._byteOffset), index));
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [return: System.Runtime.CompilerServices.System.Memory.IsReadOnly]
  public unsafe ref T GetPinnableReference()
  {
    if (this._length == 0)
      return ref Unsafe.AsRef<T>((void*) null);
    return ref (this._pinnable == null ? ref Unsafe.AsRef<T>(this._byteOffset.ToPointer()) : ref Unsafe.AddByteOffset<T>(ref this._pinnable.Data, this._byteOffset));
  }

  public void CopyTo(Span<T> destination)
  {
    if (this.TryCopyTo(destination))
      return;
    ThrowHelper.ThrowArgumentException_DestinationTooShort();
  }

  public bool TryCopyTo(Span<T> destination)
  {
    int length1 = this._length;
    int length2 = destination.Length;
    if (length1 == 0)
      return true;
    if ((uint) length1 > (uint) length2)
      return false;
    ref T local = ref this.DangerousGetPinnableReference();
    SpanHelpers.CopyTo<T>(ref destination.DangerousGetPinnableReference(), length2, ref local, length1);
    return true;
  }

  public static bool operator ==(ReadOnlySpan<T> left, ReadOnlySpan<T> right)
  {
    return left._length == right._length && Unsafe.AreSame<T>(ref left.DangerousGetPinnableReference(), ref right.DangerousGetPinnableReference());
  }

  public override unsafe string ToString()
  {
    if (!(typeof (T) == typeof (char)))
      return $"System.ReadOnlySpan<{typeof (T).Name}>[{this._length}]";
    if (this._byteOffset == MemoryExtensions.StringAdjustment && Unsafe.As<object>((object) this._pinnable) is string str && this._length == str.Length)
      return str;
    fixed (char* chPtr = &Unsafe.As<T, char>(ref this.DangerousGetPinnableReference()))
      return new string(chPtr, 0, this._length);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ReadOnlySpan<T> Slice(int start)
  {
    if ((uint) start > (uint) this._length)
      ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);
    return new ReadOnlySpan<T>(this._pinnable, this._byteOffset.Add<T>(start), this._length - start);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ReadOnlySpan<T> Slice(int start, int length)
  {
    if ((uint) start > (uint) this._length || (uint) length > (uint) (this._length - start))
      ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);
    return new ReadOnlySpan<T>(this._pinnable, this._byteOffset.Add<T>(start), length);
  }

  public T[] ToArray()
  {
    if (this._length == 0)
      return SpanHelpers.PerTypeValues<T>.EmptyArray;
    T[] destination = new T[this._length];
    this.CopyTo((Span<T>) destination);
    return destination;
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal unsafe ref T DangerousGetPinnableReference()
  {
    return ref (this._pinnable == null ? ref Unsafe.AsRef<T>(this._byteOffset.ToPointer()) : ref Unsafe.AddByteOffset<T>(ref this._pinnable.Data, this._byteOffset));
  }

  internal System.Pinnable<T> Pinnable => this._pinnable;

  internal IntPtr ByteOffset => this._byteOffset;

  [System.Runtime.CompilerServices.System.Memory.IsByRefLike]
  [Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
  public struct Enumerator
  {
    private readonly ReadOnlySpan<T> _span;
    private int _index;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Enumerator(ReadOnlySpan<T> span)
    {
      this._span = span;
      this._index = -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
      int num = this._index + 1;
      if (num >= this._span.Length)
        return false;
      this._index = num;
      return true;
    }

    [System.Runtime.CompilerServices.System.Memory.IsReadOnly]
    public ref T Current
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: System.Runtime.CompilerServices.System.Memory.IsReadOnly] get
      {
        return ref this._span[this._index];
      }
    }
  }
}
