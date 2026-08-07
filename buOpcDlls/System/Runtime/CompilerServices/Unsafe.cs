// Decompiled with JetBrains decompiler
// Type: System.Runtime.CompilerServices.Unsafe
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Versioning;

#nullable disable
namespace System.Runtime.CompilerServices;

[ComVisible(true)]
public static class Unsafe
{
  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe T Read<T>(void* source) => *(T*) source;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe T ReadUnaligned<T>(void* source) => *(T*) source;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static T ReadUnaligned<T>(ref byte source) => ^(T&) ref source;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void Write<T>(void* destination, T value) => *(T*) destination = value;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void WriteUnaligned<T>(void* destination, T value)
  {
    *(T*) destination = value;
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void WriteUnaligned<T>(ref byte destination, T value)
  {
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ^(T&) ref destination = value;
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void Copy<T>(void* destination, ref T source) => *(T*) destination = source;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void Copy<T>(ref T destination, void* source) => destination = *(T*) source;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void* AsPointer<T>(ref T value) => (void*) ref value;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void SkipInit<T>(out T value)
  {
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int SizeOf<T>() => sizeof (T);

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void CopyBlock(void* destination, void* source, uint byteCount)
  {
    // ISSUE: cpblk instruction
    __memcpy((IntPtr) destination, (IntPtr) source, (int) byteCount);
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void CopyBlock(ref byte destination, ref byte source, uint byteCount)
  {
    // ISSUE: cpblk instruction
    __memcpy(ref destination, ref source, (int) byteCount);
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void CopyBlockUnaligned(void* destination, void* source, uint byteCount)
  {
    // ISSUE: cpblk instruction
    __memcpy((IntPtr) destination, (IntPtr) source, (int) byteCount);
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void CopyBlockUnaligned(ref byte destination, ref byte source, uint byteCount)
  {
    // ISSUE: cpblk instruction
    __memcpy(ref destination, ref source, (int) byteCount);
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void InitBlock(void* startAddress, byte value, uint byteCount)
  {
    // ISSUE: initblk instruction
    __memset((IntPtr) startAddress, (int) value, (int) byteCount);
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void InitBlock(ref byte startAddress, byte value, uint byteCount)
  {
    // ISSUE: initblk instruction
    __memset(ref startAddress, (int) value, (int) byteCount);
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void InitBlockUnaligned(void* startAddress, byte value, uint byteCount)
  {
    // ISSUE: initblk instruction
    __memset((IntPtr) startAddress, (int) value, (int) byteCount);
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void InitBlockUnaligned(ref byte startAddress, byte value, uint byteCount)
  {
    // ISSUE: initblk instruction
    __memset(ref startAddress, (int) value, (int) byteCount);
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static T As<T>(object o) where T : class => (T) o;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe ref T AsRef<T>(void* source) => (T&) ref (*(int*) source);

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref T AsRef<T>([System.Runtime.CompilerServices.System.Runtime.CompilerServices.Unsafe3632169.IsReadOnly] ref T source)
  {
    return ref source;
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref TTo As<TFrom, TTo>(ref TFrom source) => (TTo&) ref source;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref T Unbox<T>(object box) where T : struct => @(T) box;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref T Add<T>(ref T source, int elementOffset)
  {
    // ISSUE: cast to a reference type
    return (T&) ((IntPtr) ref source + elementOffset * (IntPtr) sizeof (T));
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void* Add<T>(void* source, int elementOffset)
  {
    return (void*) ((IntPtr) source + elementOffset * (IntPtr) sizeof (T));
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe ref T Add<T>(ref T source, IntPtr elementOffset)
  {
    // ISSUE: explicit reference operation
    return @((T*) ref source)[elementOffset.ToInt64()];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe ref T Add<T>(ref T source, [NativeInteger, NonVersionable] UIntPtr elementOffset)
  {
    // ISSUE: explicit reference operation
    return @((T*) ref source)[elementOffset];
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref T AddByteOffset<T>(ref T source, IntPtr byteOffset)
  {
    // ISSUE: cast to a reference type
    return (T&) ((IntPtr) ref source + byteOffset);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref T AddByteOffset<T>(ref T source, [NonVersionable, NativeInteger] UIntPtr byteOffset)
  {
    // ISSUE: cast to a reference type
    return (T&) ((IntPtr) ref source + (IntPtr) byteOffset);
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref T Subtract<T>(ref T source, int elementOffset)
  {
    // ISSUE: cast to a reference type
    return (T&) ((IntPtr) ref source - elementOffset * (IntPtr) sizeof (T));
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe void* Subtract<T>(void* source, int elementOffset)
  {
    return (void*) ((IntPtr) source - elementOffset * (IntPtr) sizeof (T));
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe ref T Subtract<T>(ref T source, IntPtr elementOffset)
  {
    return ref (*((T*) ref source - elementOffset.ToInt64()));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe ref T Subtract<T>(ref T source, [NonVersionable, NativeInteger] UIntPtr elementOffset)
  {
    return ref (*((T*) ref source - elementOffset));
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref T SubtractByteOffset<T>(ref T source, IntPtr byteOffset)
  {
    // ISSUE: cast to a reference type
    return (T&) ((IntPtr) ref source - byteOffset);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref T SubtractByteOffset<T>(ref T source, [NativeInteger, NonVersionable] UIntPtr byteOffset)
  {
    // ISSUE: cast to a reference type
    return (T&) ((IntPtr) ref source - (IntPtr) byteOffset);
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static IntPtr ByteOffset<T>(ref T origin, ref T target)
  {
    return (IntPtr) ref target - (IntPtr) ref origin;
  }

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool AreSame<T>(ref T left, ref T right) => ref left == ref right;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsAddressGreaterThan<T>(ref T left, ref T right) => ref left > ref right;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsAddressLessThan<T>(ref T left, ref T right) => ref left < ref right;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsNullRef<T>(ref T source) => ref source == IntPtr.Zero;

  [NonVersionable]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref T NullRef<T>() => (T&) IntPtr.Zero;
}
