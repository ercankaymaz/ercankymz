// Decompiled with JetBrains decompiler
// Type: System.Numerics.Vector
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Numerics;

[Intrinsic]
[ComVisible(true)]
public static class Vector
{
  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe void Widen(
    Vector<byte> source,
    out Vector<ushort> low,
    out Vector<ushort> high)
  {
    int count = Vector<byte>.Count;
    ushort* dataPointer1 = stackalloc ushort[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer1[index] = (ushort) (short) source[index];
    ushort* dataPointer2 = stackalloc ushort[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer2[index] = (ushort) (short) source[index + count / 2];
    low = new Vector<ushort>((void*) dataPointer1);
    high = new Vector<ushort>((void*) dataPointer2);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe void Widen(
    Vector<ushort> source,
    out Vector<uint> low,
    out Vector<uint> high)
  {
    int count = Vector<ushort>.Count;
    uint* dataPointer1 = stackalloc uint[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer1[index] = (uint) source[index];
    uint* dataPointer2 = stackalloc uint[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer2[index] = (uint) source[index + count / 2];
    low = new Vector<uint>((void*) dataPointer1);
    high = new Vector<uint>((void*) dataPointer2);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe void Widen(
    Vector<uint> source,
    out Vector<ulong> low,
    out Vector<ulong> high)
  {
    int count = Vector<uint>.Count;
    ulong* dataPointer1 = stackalloc ulong[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer1[index] = (ulong) source[index];
    ulong* dataPointer2 = stackalloc ulong[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer2[index] = (ulong) source[index + count / 2];
    low = new Vector<ulong>((void*) dataPointer1);
    high = new Vector<ulong>((void*) dataPointer2);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe void Widen(
    Vector<sbyte> source,
    out Vector<short> low,
    out Vector<short> high)
  {
    int count = Vector<sbyte>.Count;
    short* dataPointer1 = stackalloc short[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer1[index] = (short) source[index];
    short* dataPointer2 = stackalloc short[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer2[index] = (short) source[index + count / 2];
    low = new Vector<short>((void*) dataPointer1);
    high = new Vector<short>((void*) dataPointer2);
  }

  [Intrinsic]
  public static unsafe void Widen(Vector<short> source, out Vector<int> low, out Vector<int> high)
  {
    int count = Vector<short>.Count;
    int* dataPointer1 = stackalloc int[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer1[index] = (int) source[index];
    int* dataPointer2 = stackalloc int[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer2[index] = (int) source[index + count / 2];
    low = new Vector<int>((void*) dataPointer1);
    high = new Vector<int>((void*) dataPointer2);
  }

  [Intrinsic]
  public static unsafe void Widen(Vector<int> source, out Vector<long> low, out Vector<long> high)
  {
    int count = Vector<int>.Count;
    long* dataPointer1 = stackalloc long[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer1[index] = (long) source[index];
    long* dataPointer2 = stackalloc long[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer2[index] = (long) source[index + count / 2];
    low = new Vector<long>((void*) dataPointer1);
    high = new Vector<long>((void*) dataPointer2);
  }

  [Intrinsic]
  public static unsafe void Widen(
    Vector<float> source,
    out Vector<double> low,
    out Vector<double> high)
  {
    int count = Vector<float>.Count;
    double* dataPointer1 = stackalloc double[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer1[index] = (double) source[index];
    double* dataPointer2 = stackalloc double[count / 2];
    for (int index = 0; index < count / 2; ++index)
      dataPointer2[index] = (double) source[index + count / 2];
    low = new Vector<double>((void*) dataPointer1);
    high = new Vector<double>((void*) dataPointer2);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe Vector<byte> Narrow(Vector<ushort> low, Vector<ushort> high)
  {
    int count = Vector<byte>.Count;
    byte* dataPointer = stackalloc byte[count];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index] = (byte) low[index];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index + count / 2] = (byte) high[index];
    return new Vector<byte>((void*) dataPointer);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe Vector<ushort> Narrow(Vector<uint> low, Vector<uint> high)
  {
    int count = Vector<ushort>.Count;
    ushort* dataPointer = stackalloc ushort[count];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index] = (ushort) low[index];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index + count / 2] = (ushort) high[index];
    return new Vector<ushort>((void*) dataPointer);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe Vector<uint> Narrow(Vector<ulong> low, Vector<ulong> high)
  {
    int count = Vector<uint>.Count;
    uint* dataPointer = stackalloc uint[count];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index] = (uint) low[index];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index + count / 2] = (uint) high[index];
    return new Vector<uint>((void*) dataPointer);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe Vector<sbyte> Narrow(Vector<short> low, Vector<short> high)
  {
    int count = Vector<sbyte>.Count;
    sbyte* dataPointer = stackalloc sbyte[count];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index] = (sbyte) low[index];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index + count / 2] = (sbyte) high[index];
    return new Vector<sbyte>((void*) dataPointer);
  }

  [Intrinsic]
  public static unsafe Vector<short> Narrow(Vector<int> low, Vector<int> high)
  {
    int count = Vector<short>.Count;
    short* dataPointer = stackalloc short[count];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index] = (short) low[index];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index + count / 2] = (short) high[index];
    return new Vector<short>((void*) dataPointer);
  }

  [Intrinsic]
  public static unsafe Vector<int> Narrow(Vector<long> low, Vector<long> high)
  {
    int count = Vector<int>.Count;
    int* dataPointer = stackalloc int[count];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index] = (int) low[index];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index + count / 2] = (int) high[index];
    return new Vector<int>((void*) dataPointer);
  }

  [Intrinsic]
  public static unsafe Vector<float> Narrow(Vector<double> low, Vector<double> high)
  {
    int count = Vector<float>.Count;
    float* dataPointer = stackalloc float[count];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index] = (float) low[index];
    for (int index = 0; index < count / 2; ++index)
      dataPointer[index + count / 2] = (float) high[index];
    return new Vector<float>((void*) dataPointer);
  }

  [Intrinsic]
  public static unsafe Vector<float> ConvertToSingle(Vector<int> value)
  {
    int count = Vector<float>.Count;
    float* dataPointer = stackalloc float[count];
    for (int index = 0; index < count; ++index)
      dataPointer[index] = (float) value[index];
    return new Vector<float>((void*) dataPointer);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe Vector<float> ConvertToSingle(Vector<uint> value)
  {
    int count = Vector<float>.Count;
    float* dataPointer = stackalloc float[count];
    for (int index = 0; index < count; ++index)
      dataPointer[index] = (float) value[index];
    return new Vector<float>((void*) dataPointer);
  }

  [Intrinsic]
  public static unsafe Vector<double> ConvertToDouble(Vector<long> value)
  {
    int count = Vector<double>.Count;
    double* dataPointer = stackalloc double[count];
    for (int index = 0; index < count; ++index)
      dataPointer[index] = (double) value[index];
    return new Vector<double>((void*) dataPointer);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe Vector<double> ConvertToDouble(Vector<ulong> value)
  {
    int count = Vector<double>.Count;
    double* dataPointer = stackalloc double[count];
    for (int index = 0; index < count; ++index)
      dataPointer[index] = (double) value[index];
    return new Vector<double>((void*) dataPointer);
  }

  [Intrinsic]
  public static unsafe Vector<int> ConvertToInt32(Vector<float> value)
  {
    int count = Vector<int>.Count;
    int* dataPointer = stackalloc int[count];
    for (int index = 0; index < count; ++index)
      dataPointer[index] = (int) value[index];
    return new Vector<int>((void*) dataPointer);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe Vector<uint> ConvertToUInt32(Vector<float> value)
  {
    int count = Vector<uint>.Count;
    uint* dataPointer = stackalloc uint[count];
    for (int index = 0; index < count; ++index)
      dataPointer[index] = (uint) value[index];
    return new Vector<uint>((void*) dataPointer);
  }

  [Intrinsic]
  public static unsafe Vector<long> ConvertToInt64(Vector<double> value)
  {
    int count = Vector<long>.Count;
    long* dataPointer = stackalloc long[count];
    for (int index = 0; index < count; ++index)
      dataPointer[index] = (long) value[index];
    return new Vector<long>((void*) dataPointer);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static unsafe Vector<ulong> ConvertToUInt64(Vector<double> value)
  {
    int count = Vector<ulong>.Count;
    ulong* dataPointer = stackalloc ulong[count];
    for (int index = 0; index < count; ++index)
      dataPointer[index] = (ulong) value[index];
    return new Vector<ulong>((void*) dataPointer);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<float> ConditionalSelect(
    Vector<int> condition,
    Vector<float> left,
    Vector<float> right)
  {
    return Vector<float>.ConditionalSelect((Vector<float>) condition, left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<double> ConditionalSelect(
    Vector<long> condition,
    Vector<double> left,
    Vector<double> right)
  {
    return Vector<double>.ConditionalSelect((Vector<double>) condition, left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> ConditionalSelect<T>(
    Vector<T> condition,
    Vector<T> left,
    Vector<T> right)
    where T : struct
  {
    return Vector<T>.ConditionalSelect(condition, left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Equals<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return Vector<T>.Equals(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> Equals(Vector<float> left, Vector<float> right)
  {
    return (Vector<int>) Vector<float>.Equals(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> Equals(Vector<int> left, Vector<int> right)
  {
    return Vector<int>.Equals(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> Equals(Vector<double> left, Vector<double> right)
  {
    return (Vector<long>) Vector<double>.Equals(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> Equals(Vector<long> left, Vector<long> right)
  {
    return Vector<long>.Equals(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool EqualsAll<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return left == right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool EqualsAny<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return !Vector<T>.Equals(left, right).Equals(Vector<T>.Zero);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> LessThan<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return Vector<T>.LessThan(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> LessThan(Vector<float> left, Vector<float> right)
  {
    return (Vector<int>) Vector<float>.LessThan(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> LessThan(Vector<int> left, Vector<int> right)
  {
    return Vector<int>.LessThan(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> LessThan(Vector<double> left, Vector<double> right)
  {
    return (Vector<long>) Vector<double>.LessThan(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> LessThan(Vector<long> left, Vector<long> right)
  {
    return Vector<long>.LessThan(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool LessThanAll<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return ((Vector<int>) Vector<T>.LessThan(left, right)).Equals(Vector<int>.AllOnes);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool LessThanAny<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return !((Vector<int>) Vector<T>.LessThan(left, right)).Equals(Vector<int>.Zero);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> LessThanOrEqual<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return Vector<T>.LessThanOrEqual(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> LessThanOrEqual(Vector<float> left, Vector<float> right)
  {
    return (Vector<int>) Vector<float>.LessThanOrEqual(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> LessThanOrEqual(Vector<int> left, Vector<int> right)
  {
    return Vector<int>.LessThanOrEqual(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> LessThanOrEqual(Vector<long> left, Vector<long> right)
  {
    return Vector<long>.LessThanOrEqual(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> LessThanOrEqual(Vector<double> left, Vector<double> right)
  {
    return (Vector<long>) Vector<double>.LessThanOrEqual(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool LessThanOrEqualAll<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return ((Vector<int>) Vector<T>.LessThanOrEqual(left, right)).Equals(Vector<int>.AllOnes);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool LessThanOrEqualAny<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return !((Vector<int>) Vector<T>.LessThanOrEqual(left, right)).Equals(Vector<int>.Zero);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> GreaterThan<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return Vector<T>.GreaterThan(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> GreaterThan(Vector<float> left, Vector<float> right)
  {
    return (Vector<int>) Vector<float>.GreaterThan(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> GreaterThan(Vector<int> left, Vector<int> right)
  {
    return Vector<int>.GreaterThan(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> GreaterThan(Vector<double> left, Vector<double> right)
  {
    return (Vector<long>) Vector<double>.GreaterThan(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> GreaterThan(Vector<long> left, Vector<long> right)
  {
    return Vector<long>.GreaterThan(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool GreaterThanAll<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return ((Vector<int>) Vector<T>.GreaterThan(left, right)).Equals(Vector<int>.AllOnes);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool GreaterThanAny<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return !((Vector<int>) Vector<T>.GreaterThan(left, right)).Equals(Vector<int>.Zero);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> GreaterThanOrEqual<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return Vector<T>.GreaterThanOrEqual(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> GreaterThanOrEqual(Vector<float> left, Vector<float> right)
  {
    return (Vector<int>) Vector<float>.GreaterThanOrEqual(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> GreaterThanOrEqual(Vector<int> left, Vector<int> right)
  {
    return Vector<int>.GreaterThanOrEqual(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> GreaterThanOrEqual(Vector<long> left, Vector<long> right)
  {
    return Vector<long>.GreaterThanOrEqual(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> GreaterThanOrEqual(Vector<double> left, Vector<double> right)
  {
    return (Vector<long>) Vector<double>.GreaterThanOrEqual(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool GreaterThanOrEqualAll<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return ((Vector<int>) Vector<T>.GreaterThanOrEqual(left, right)).Equals(Vector<int>.AllOnes);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool GreaterThanOrEqualAny<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return !((Vector<int>) Vector<T>.GreaterThanOrEqual(left, right)).Equals(Vector<int>.Zero);
  }

  public static bool IsHardwareAccelerated
  {
    [Intrinsic] get => false;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Abs<T>(Vector<T> value) where T : struct => Vector<T>.Abs(value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Min<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return Vector<T>.Min(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Max<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return Vector<T>.Max(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static T Dot<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return Vector<T>.DotProduct(left, right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> SquareRoot<T>(Vector<T> value) where T : struct
  {
    return Vector<T>.SquareRoot(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Add<T>(Vector<T> left, Vector<T> right) where T : struct => left + right;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Subtract<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return left - right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Multiply<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return left * right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Multiply<T>(Vector<T> left, T right) where T : struct => left * right;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Multiply<T>(T left, Vector<T> right) where T : struct => left * right;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Divide<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return left / right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Negate<T>(Vector<T> value) where T : struct => -value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> BitwiseAnd<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return left & right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> BitwiseOr<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return left | right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> OnesComplement<T>(Vector<T> value) where T : struct => ~value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> Xor<T>(Vector<T> left, Vector<T> right) where T : struct => left ^ right;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> AndNot<T>(Vector<T> left, Vector<T> right) where T : struct
  {
    return left & ~right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<byte> AsVectorByte<T>(Vector<T> value) where T : struct
  {
    return (Vector<byte>) value;
  }

  [CLSCompliant(false)]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<sbyte> AsVectorSByte<T>(Vector<T> value) where T : struct
  {
    return (Vector<sbyte>) value;
  }

  [CLSCompliant(false)]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<ushort> AsVectorUInt16<T>(Vector<T> value) where T : struct
  {
    return (Vector<ushort>) value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<short> AsVectorInt16<T>(Vector<T> value) where T : struct
  {
    return (Vector<short>) value;
  }

  [CLSCompliant(false)]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<uint> AsVectorUInt32<T>(Vector<T> value) where T : struct
  {
    return (Vector<uint>) value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<int> AsVectorInt32<T>(Vector<T> value) where T : struct
  {
    return (Vector<int>) value;
  }

  [CLSCompliant(false)]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<ulong> AsVectorUInt64<T>(Vector<T> value) where T : struct
  {
    return (Vector<ulong>) value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<long> AsVectorInt64<T>(Vector<T> value) where T : struct
  {
    return (Vector<long>) value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<float> AsVectorSingle<T>(Vector<T> value) where T : struct
  {
    return (Vector<float>) value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<double> AsVectorDouble<T>(Vector<T> value) where T : struct
  {
    return (Vector<double>) value;
  }
}
