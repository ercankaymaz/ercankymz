// Decompiled with JetBrains decompiler
// Type: System.Numerics.Vector`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Globalization;
using System.Numerics.Hashing.System.Numerics.Vectors3620677;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace System.Numerics;

[Intrinsic]
[ComVisible(true)]
public struct Vector<T> : IEquatable<Vector<T>>, IFormattable where T : struct
{
  private Register register;
  private static readonly int s_count = Vector<T>.InitializeCount();
  private static readonly Vector<T> s_zero = new Vector<T>();
  private static readonly Vector<T> s_one = new Vector<T>(Vector<T>.GetOneValue());
  private static readonly Vector<T> s_allOnes = new Vector<T>(Vector<T>.GetAllBitsSetValue());

  public static int Count
  {
    [Intrinsic] get => Vector<T>.s_count;
  }

  public static Vector<T> Zero
  {
    [Intrinsic] get => Vector<T>.s_zero;
  }

  public static Vector<T> One
  {
    [Intrinsic] get => Vector<T>.s_one;
  }

  internal static Vector<T> AllOnes => Vector<T>.s_allOnes;

  private static unsafe int InitializeCount()
  {
    Vector<T>.VectorSizeHelper vectorSizeHelper;
    byte* numPtr = &vectorSizeHelper._placeholder.register.byte_0;
    int num1 = (int) (&vectorSizeHelper._byte - numPtr);
    int num2;
    if (typeof (T) == typeof (byte))
      num2 = 1;
    else if (typeof (T) == typeof (sbyte))
      num2 = 1;
    else if (typeof (T) == typeof (ushort))
      num2 = 2;
    else if (typeof (T) == typeof (short))
      num2 = 2;
    else if (typeof (T) == typeof (uint))
      num2 = 4;
    else if (typeof (T) == typeof (int))
      num2 = 4;
    else if (typeof (T) == typeof (ulong))
      num2 = 8;
    else if (typeof (T) == typeof (long))
      num2 = 8;
    else if (typeof (T) == typeof (float))
    {
      num2 = 4;
    }
    else
    {
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      num2 = 8;
    }
    return num1 / num2;
  }

  [Intrinsic]
  public unsafe Vector(T value)
    : this()
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        fixed (byte* numPtr = &this.register.byte_0)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[index] = (byte) (ValueType) value;
        }
      }
      else if (typeof (T) == typeof (sbyte))
      {
        fixed (sbyte* numPtr = &this.register.sbyte_0)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[index] = (sbyte) (ValueType) value;
        }
      }
      else if (typeof (T) == typeof (ushort))
      {
        fixed (ushort* numPtr = &this.register.uint16_0)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[index] = (ushort) (ValueType) value;
        }
      }
      else if (typeof (T) == typeof (short))
      {
        fixed (short* numPtr = &this.register.int16_0)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[index] = (short) (ValueType) value;
        }
      }
      else if (typeof (T) == typeof (uint))
      {
        fixed (uint* numPtr = &this.register.uint32_0)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[index] = (uint) (ValueType) value;
        }
      }
      else if (typeof (T) == typeof (int))
      {
        fixed (int* numPtr = &this.register.int32_0)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[index] = (int) (ValueType) value;
        }
      }
      else if (typeof (T) == typeof (ulong))
      {
        fixed (ulong* numPtr = &this.register.uint64_0)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[index] = (ulong) (ValueType) value;
        }
      }
      else if (typeof (T) == typeof (long))
      {
        fixed (long* numPtr = &this.register.int64_0)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[index] = (long) (ValueType) value;
        }
      }
      else if (typeof (T) == typeof (float))
      {
        fixed (float* numPtr = &this.register.single_0)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[index] = (float) (ValueType) value;
        }
      }
      else
      {
        if (!(typeof (T) == typeof (double)))
          return;
        fixed (double* numPtr = &this.register.double_0)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[index] = (double) (ValueType) value;
        }
      }
    }
    else if (typeof (T) == typeof (byte))
    {
      this.register.byte_0 = (byte) (ValueType) value;
      this.register.byte_1 = (byte) (ValueType) value;
      this.register.byte_2 = (byte) (ValueType) value;
      this.register.byte_3 = (byte) (ValueType) value;
      this.register.byte_4 = (byte) (ValueType) value;
      this.register.byte_5 = (byte) (ValueType) value;
      this.register.byte_6 = (byte) (ValueType) value;
      this.register.byte_7 = (byte) (ValueType) value;
      this.register.byte_8 = (byte) (ValueType) value;
      this.register.byte_9 = (byte) (ValueType) value;
      this.register.byte_10 = (byte) (ValueType) value;
      this.register.byte_11 = (byte) (ValueType) value;
      this.register.byte_12 = (byte) (ValueType) value;
      this.register.byte_13 = (byte) (ValueType) value;
      this.register.byte_14 = (byte) (ValueType) value;
      this.register.byte_15 = (byte) (ValueType) value;
    }
    else if (typeof (T) == typeof (sbyte))
    {
      this.register.sbyte_0 = (sbyte) (ValueType) value;
      this.register.sbyte_1 = (sbyte) (ValueType) value;
      this.register.sbyte_2 = (sbyte) (ValueType) value;
      this.register.sbyte_3 = (sbyte) (ValueType) value;
      this.register.sbyte_4 = (sbyte) (ValueType) value;
      this.register.sbyte_5 = (sbyte) (ValueType) value;
      this.register.sbyte_6 = (sbyte) (ValueType) value;
      this.register.sbyte_7 = (sbyte) (ValueType) value;
      this.register.sbyte_8 = (sbyte) (ValueType) value;
      this.register.sbyte_9 = (sbyte) (ValueType) value;
      this.register.sbyte_10 = (sbyte) (ValueType) value;
      this.register.sbyte_11 = (sbyte) (ValueType) value;
      this.register.sbyte_12 = (sbyte) (ValueType) value;
      this.register.sbyte_13 = (sbyte) (ValueType) value;
      this.register.sbyte_14 = (sbyte) (ValueType) value;
      this.register.sbyte_15 = (sbyte) (ValueType) value;
    }
    else if (typeof (T) == typeof (ushort))
    {
      this.register.uint16_0 = (ushort) (ValueType) value;
      this.register.uint16_1 = (ushort) (ValueType) value;
      this.register.uint16_2 = (ushort) (ValueType) value;
      this.register.uint16_3 = (ushort) (ValueType) value;
      this.register.uint16_4 = (ushort) (ValueType) value;
      this.register.uint16_5 = (ushort) (ValueType) value;
      this.register.uint16_6 = (ushort) (ValueType) value;
      this.register.uint16_7 = (ushort) (ValueType) value;
    }
    else if (typeof (T) == typeof (short))
    {
      this.register.int16_0 = (short) (ValueType) value;
      this.register.int16_1 = (short) (ValueType) value;
      this.register.int16_2 = (short) (ValueType) value;
      this.register.int16_3 = (short) (ValueType) value;
      this.register.int16_4 = (short) (ValueType) value;
      this.register.int16_5 = (short) (ValueType) value;
      this.register.int16_6 = (short) (ValueType) value;
      this.register.int16_7 = (short) (ValueType) value;
    }
    else if (typeof (T) == typeof (uint))
    {
      this.register.uint32_0 = (uint) (ValueType) value;
      this.register.uint32_1 = (uint) (ValueType) value;
      this.register.uint32_2 = (uint) (ValueType) value;
      this.register.uint32_3 = (uint) (ValueType) value;
    }
    else if (typeof (T) == typeof (int))
    {
      this.register.int32_0 = (int) (ValueType) value;
      this.register.int32_1 = (int) (ValueType) value;
      this.register.int32_2 = (int) (ValueType) value;
      this.register.int32_3 = (int) (ValueType) value;
    }
    else if (typeof (T) == typeof (ulong))
    {
      this.register.uint64_0 = (ulong) (ValueType) value;
      this.register.uint64_1 = (ulong) (ValueType) value;
    }
    else if (typeof (T) == typeof (long))
    {
      this.register.int64_0 = (long) (ValueType) value;
      this.register.int64_1 = (long) (ValueType) value;
    }
    else if (typeof (T) == typeof (float))
    {
      this.register.single_0 = (float) (ValueType) value;
      this.register.single_1 = (float) (ValueType) value;
      this.register.single_2 = (float) (ValueType) value;
      this.register.single_3 = (float) (ValueType) value;
    }
    else
    {
      if (!(typeof (T) == typeof (double)))
        return;
      this.register.double_0 = (double) (ValueType) value;
      this.register.double_1 = (double) (ValueType) value;
    }
  }

  [Intrinsic]
  public Vector(T[] values)
    : this(values, 0)
  {
  }

  public unsafe Vector(T[] values, int index)
    : this()
  {
    if (values == null)
      throw new NullReferenceException(System.System.Numerics.Vectors3620677.SR.Arg_NullArgumentNullRef);
    if (index < 0 || values.Length - index < Vector<T>.Count)
      throw new IndexOutOfRangeException(System.System.Numerics.Vectors3620677.SR.Format(System.System.Numerics.Vectors3620677.SR.Arg_InsufficientNumberOfElements, (object) Vector<T>.Count, (object) nameof (values)));
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        fixed (byte* numPtr = &this.register.byte_0)
        {
          for (int index1 = 0; index1 < Vector<T>.Count; ++index1)
            numPtr[index1] = (byte) (ValueType) values[index1 + index];
        }
      }
      else if (typeof (T) == typeof (sbyte))
      {
        fixed (sbyte* numPtr = &this.register.sbyte_0)
        {
          for (int index2 = 0; index2 < Vector<T>.Count; ++index2)
            numPtr[index2] = (sbyte) (ValueType) values[index2 + index];
        }
      }
      else if (typeof (T) == typeof (ushort))
      {
        fixed (ushort* numPtr = &this.register.uint16_0)
        {
          for (int index3 = 0; index3 < Vector<T>.Count; ++index3)
            numPtr[index3] = (ushort) (ValueType) values[index3 + index];
        }
      }
      else if (typeof (T) == typeof (short))
      {
        fixed (short* numPtr = &this.register.int16_0)
        {
          for (int index4 = 0; index4 < Vector<T>.Count; ++index4)
            numPtr[index4] = (short) (ValueType) values[index4 + index];
        }
      }
      else if (typeof (T) == typeof (uint))
      {
        fixed (uint* numPtr = &this.register.uint32_0)
        {
          for (int index5 = 0; index5 < Vector<T>.Count; ++index5)
            numPtr[index5] = (uint) (ValueType) values[index5 + index];
        }
      }
      else if (typeof (T) == typeof (int))
      {
        fixed (int* numPtr = &this.register.int32_0)
        {
          for (int index6 = 0; index6 < Vector<T>.Count; ++index6)
            numPtr[index6] = (int) (ValueType) values[index6 + index];
        }
      }
      else if (typeof (T) == typeof (ulong))
      {
        fixed (ulong* numPtr = &this.register.uint64_0)
        {
          for (int index7 = 0; index7 < Vector<T>.Count; ++index7)
            numPtr[index7] = (ulong) (ValueType) values[index7 + index];
        }
      }
      else if (typeof (T) == typeof (long))
      {
        fixed (long* numPtr = &this.register.int64_0)
        {
          for (int index8 = 0; index8 < Vector<T>.Count; ++index8)
            numPtr[index8] = (long) (ValueType) values[index8 + index];
        }
      }
      else if (typeof (T) == typeof (float))
      {
        fixed (float* numPtr = &this.register.single_0)
        {
          for (int index9 = 0; index9 < Vector<T>.Count; ++index9)
            numPtr[index9] = (float) (ValueType) values[index9 + index];
        }
      }
      else
      {
        if (!(typeof (T) == typeof (double)))
          return;
        fixed (double* numPtr = &this.register.double_0)
        {
          for (int index10 = 0; index10 < Vector<T>.Count; ++index10)
            numPtr[index10] = (double) (ValueType) values[index10 + index];
        }
      }
    }
    else if (typeof (T) == typeof (byte))
    {
      fixed (byte* numPtr = &this.register.byte_0)
      {
        *numPtr = (byte) (ValueType) values[index];
        numPtr[1] = (byte) (ValueType) values[1 + index];
        numPtr[2] = (byte) (ValueType) values[2 + index];
        numPtr[3] = (byte) (ValueType) values[3 + index];
        numPtr[4] = (byte) (ValueType) values[4 + index];
        numPtr[5] = (byte) (ValueType) values[5 + index];
        numPtr[6] = (byte) (ValueType) values[6 + index];
        numPtr[7] = (byte) (ValueType) values[7 + index];
        numPtr[8] = (byte) (ValueType) values[8 + index];
        numPtr[9] = (byte) (ValueType) values[9 + index];
        numPtr[10] = (byte) (ValueType) values[10 + index];
        numPtr[11] = (byte) (ValueType) values[11 + index];
        numPtr[12] = (byte) (ValueType) values[12 + index];
        numPtr[13] = (byte) (ValueType) values[13 + index];
        numPtr[14] = (byte) (ValueType) values[14 + index];
        numPtr[15] = (byte) (ValueType) values[15 + index];
      }
    }
    else if (typeof (T) == typeof (sbyte))
    {
      fixed (sbyte* numPtr = &this.register.sbyte_0)
      {
        *numPtr = (sbyte) (ValueType) values[index];
        numPtr[1] = (sbyte) (ValueType) values[1 + index];
        numPtr[2] = (sbyte) (ValueType) values[2 + index];
        numPtr[3] = (sbyte) (ValueType) values[3 + index];
        numPtr[4] = (sbyte) (ValueType) values[4 + index];
        numPtr[5] = (sbyte) (ValueType) values[5 + index];
        numPtr[6] = (sbyte) (ValueType) values[6 + index];
        numPtr[7] = (sbyte) (ValueType) values[7 + index];
        numPtr[8] = (sbyte) (ValueType) values[8 + index];
        numPtr[9] = (sbyte) (ValueType) values[9 + index];
        numPtr[10] = (sbyte) (ValueType) values[10 + index];
        numPtr[11] = (sbyte) (ValueType) values[11 + index];
        numPtr[12] = (sbyte) (ValueType) values[12 + index];
        numPtr[13] = (sbyte) (ValueType) values[13 + index];
        numPtr[14] = (sbyte) (ValueType) values[14 + index];
        numPtr[15] = (sbyte) (ValueType) values[15 + index];
      }
    }
    else if (typeof (T) == typeof (ushort))
    {
      fixed (ushort* numPtr = &this.register.uint16_0)
      {
        *numPtr = (ushort) (ValueType) values[index];
        numPtr[1] = (ushort) (ValueType) values[1 + index];
        numPtr[2] = (ushort) (ValueType) values[2 + index];
        numPtr[3] = (ushort) (ValueType) values[3 + index];
        numPtr[4] = (ushort) (ValueType) values[4 + index];
        numPtr[5] = (ushort) (ValueType) values[5 + index];
        numPtr[6] = (ushort) (ValueType) values[6 + index];
        numPtr[7] = (ushort) (ValueType) values[7 + index];
      }
    }
    else if (typeof (T) == typeof (short))
    {
      fixed (short* numPtr = &this.register.int16_0)
      {
        *numPtr = (short) (ValueType) values[index];
        numPtr[1] = (short) (ValueType) values[1 + index];
        numPtr[2] = (short) (ValueType) values[2 + index];
        numPtr[3] = (short) (ValueType) values[3 + index];
        numPtr[4] = (short) (ValueType) values[4 + index];
        numPtr[5] = (short) (ValueType) values[5 + index];
        numPtr[6] = (short) (ValueType) values[6 + index];
        numPtr[7] = (short) (ValueType) values[7 + index];
      }
    }
    else if (typeof (T) == typeof (uint))
    {
      fixed (uint* numPtr = &this.register.uint32_0)
      {
        *numPtr = (uint) (ValueType) values[index];
        numPtr[1] = (uint) (ValueType) values[1 + index];
        numPtr[2] = (uint) (ValueType) values[2 + index];
        numPtr[3] = (uint) (ValueType) values[3 + index];
      }
    }
    else if (typeof (T) == typeof (int))
    {
      fixed (int* numPtr = &this.register.int32_0)
      {
        *numPtr = (int) (ValueType) values[index];
        numPtr[1] = (int) (ValueType) values[1 + index];
        numPtr[2] = (int) (ValueType) values[2 + index];
        numPtr[3] = (int) (ValueType) values[3 + index];
      }
    }
    else if (typeof (T) == typeof (ulong))
    {
      fixed (ulong* numPtr = &this.register.uint64_0)
      {
        *numPtr = (ulong) (ValueType) values[index];
        numPtr[1] = (ulong) (ValueType) values[1 + index];
      }
    }
    else if (typeof (T) == typeof (long))
    {
      fixed (long* numPtr = &this.register.int64_0)
      {
        *numPtr = (long) (ValueType) values[index];
        numPtr[1] = (long) (ValueType) values[1 + index];
      }
    }
    else if (typeof (T) == typeof (float))
    {
      fixed (float* numPtr = &this.register.single_0)
      {
        *numPtr = (float) (ValueType) values[index];
        numPtr[1] = (float) (ValueType) values[1 + index];
        numPtr[2] = (float) (ValueType) values[2 + index];
        numPtr[3] = (float) (ValueType) values[3 + index];
      }
    }
    else
    {
      if (!(typeof (T) == typeof (double)))
        return;
      fixed (double* numPtr = &this.register.double_0)
      {
        *numPtr = (double) (ValueType) values[index];
        numPtr[1] = (double) (ValueType) values[1 + index];
      }
    }
  }

  internal unsafe Vector(void* dataPointer)
    : this(dataPointer, 0)
  {
  }

  internal unsafe Vector(void* dataPointer, int offset)
    : this()
  {
    if (typeof (T) == typeof (byte))
    {
      byte* numPtr1 = (byte*) ((IntPtr) dataPointer + offset);
      fixed (byte* numPtr2 = &this.register.byte_0)
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          numPtr2[index] = numPtr1[index];
      }
    }
    else if (typeof (T) == typeof (sbyte))
    {
      sbyte* numPtr3 = (sbyte*) ((IntPtr) dataPointer + offset);
      fixed (sbyte* numPtr4 = &this.register.sbyte_0)
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          numPtr4[index] = numPtr3[index];
      }
    }
    else if (typeof (T) == typeof (ushort))
    {
      ushort* numPtr5 = (ushort*) ((IntPtr) dataPointer + (IntPtr) offset * 2);
      fixed (ushort* numPtr6 = &this.register.uint16_0)
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          numPtr6[index] = numPtr5[index];
      }
    }
    else if (typeof (T) == typeof (short))
    {
      short* numPtr7 = (short*) ((IntPtr) dataPointer + (IntPtr) offset * 2);
      fixed (short* numPtr8 = &this.register.int16_0)
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          numPtr8[index] = numPtr7[index];
      }
    }
    else if (typeof (T) == typeof (uint))
    {
      uint* numPtr9 = (uint*) ((IntPtr) dataPointer + (IntPtr) offset * 4);
      fixed (uint* numPtr10 = &this.register.uint32_0)
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          numPtr10[index] = numPtr9[index];
      }
    }
    else if (typeof (T) == typeof (int))
    {
      int* numPtr11 = (int*) ((IntPtr) dataPointer + (IntPtr) offset * 4);
      fixed (int* numPtr12 = &this.register.int32_0)
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          numPtr12[index] = numPtr11[index];
      }
    }
    else if (typeof (T) == typeof (ulong))
    {
      ulong* numPtr13 = (ulong*) ((IntPtr) dataPointer + (IntPtr) offset * 8);
      fixed (ulong* numPtr14 = &this.register.uint64_0)
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          numPtr14[index] = numPtr13[index];
      }
    }
    else if (typeof (T) == typeof (long))
    {
      long* numPtr15 = (long*) ((IntPtr) dataPointer + (IntPtr) offset * 8);
      fixed (long* numPtr16 = &this.register.int64_0)
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          numPtr16[index] = numPtr15[index];
      }
    }
    else if (typeof (T) == typeof (float))
    {
      float* numPtr17 = (float*) ((IntPtr) dataPointer + (IntPtr) offset * 4);
      fixed (float* numPtr18 = &this.register.single_0)
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          numPtr18[index] = numPtr17[index];
      }
    }
    else
    {
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* numPtr19 = (double*) ((IntPtr) dataPointer + (IntPtr) offset * 8);
      fixed (double* numPtr20 = &this.register.double_0)
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          numPtr20[index] = numPtr19[index];
      }
    }
  }

  private Vector(ref Register existingRegister) => this.register = existingRegister;

  [Intrinsic]
  public void CopyTo(T[] destination) => this.CopyTo(destination, 0);

  [Intrinsic]
  public unsafe void CopyTo(T[] destination, int startIndex)
  {
    if (destination == null)
      throw new NullReferenceException(System.System.Numerics.Vectors3620677.SR.Arg_NullArgumentNullRef);
    if (startIndex < 0 || startIndex >= destination.Length)
      throw new ArgumentOutOfRangeException(nameof (startIndex), System.System.Numerics.Vectors3620677.SR.Format(System.System.Numerics.Vectors3620677.SR.Arg_ArgumentOutOfRangeException, (object) startIndex));
    if (destination.Length - startIndex < Vector<T>.Count)
      throw new ArgumentException(System.System.Numerics.Vectors3620677.SR.Format(System.System.Numerics.Vectors3620677.SR.Arg_ElementsInSourceIsGreaterThanDestination, (object) startIndex));
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        fixed (byte* numPtr = (byte[]) destination)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[startIndex + index] = (byte) (ValueType) this[index];
        }
      }
      else if (typeof (T) == typeof (sbyte))
      {
        fixed (sbyte* numPtr = (sbyte[]) destination)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[startIndex + index] = (sbyte) (ValueType) this[index];
        }
      }
      else if (typeof (T) == typeof (ushort))
      {
        fixed (ushort* numPtr = (ushort[]) destination)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[startIndex + index] = (ushort) (ValueType) this[index];
        }
      }
      else if (typeof (T) == typeof (short))
      {
        fixed (short* numPtr = (short[]) destination)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[startIndex + index] = (short) (ValueType) this[index];
        }
      }
      else if (typeof (T) == typeof (uint))
      {
        fixed (uint* numPtr = (uint[]) destination)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[startIndex + index] = (uint) (ValueType) this[index];
        }
      }
      else if (typeof (T) == typeof (int))
      {
        fixed (int* numPtr = (int[]) destination)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[startIndex + index] = (int) (ValueType) this[index];
        }
      }
      else if (typeof (T) == typeof (ulong))
      {
        fixed (ulong* numPtr = (ulong[]) destination)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[startIndex + index] = (ulong) (ValueType) this[index];
        }
      }
      else if (typeof (T) == typeof (long))
      {
        fixed (long* numPtr = (long[]) destination)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[startIndex + index] = (long) (ValueType) this[index];
        }
      }
      else if (typeof (T) == typeof (float))
      {
        fixed (float* numPtr = (float[]) destination)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[startIndex + index] = (float) (ValueType) this[index];
        }
      }
      else
      {
        if (!(typeof (T) == typeof (double)))
          return;
        fixed (double* numPtr = (double[]) destination)
        {
          for (int index = 0; index < Vector<T>.Count; ++index)
            numPtr[startIndex + index] = (double) (ValueType) this[index];
        }
      }
    }
    else if (typeof (T) == typeof (byte))
    {
      fixed (byte* numPtr = (byte[]) destination)
      {
        numPtr[startIndex] = this.register.byte_0;
        numPtr[startIndex + 1] = this.register.byte_1;
        numPtr[startIndex + 2] = this.register.byte_2;
        numPtr[startIndex + 3] = this.register.byte_3;
        numPtr[startIndex + 4] = this.register.byte_4;
        numPtr[startIndex + 5] = this.register.byte_5;
        numPtr[startIndex + 6] = this.register.byte_6;
        numPtr[startIndex + 7] = this.register.byte_7;
        numPtr[startIndex + 8] = this.register.byte_8;
        numPtr[startIndex + 9] = this.register.byte_9;
        numPtr[startIndex + 10] = this.register.byte_10;
        numPtr[startIndex + 11] = this.register.byte_11;
        numPtr[startIndex + 12] = this.register.byte_12;
        numPtr[startIndex + 13] = this.register.byte_13;
        numPtr[startIndex + 14] = this.register.byte_14;
        numPtr[startIndex + 15] = this.register.byte_15;
      }
    }
    else if (typeof (T) == typeof (sbyte))
    {
      fixed (sbyte* numPtr = (sbyte[]) destination)
      {
        numPtr[startIndex] = this.register.sbyte_0;
        numPtr[startIndex + 1] = this.register.sbyte_1;
        numPtr[startIndex + 2] = this.register.sbyte_2;
        numPtr[startIndex + 3] = this.register.sbyte_3;
        numPtr[startIndex + 4] = this.register.sbyte_4;
        numPtr[startIndex + 5] = this.register.sbyte_5;
        numPtr[startIndex + 6] = this.register.sbyte_6;
        numPtr[startIndex + 7] = this.register.sbyte_7;
        numPtr[startIndex + 8] = this.register.sbyte_8;
        numPtr[startIndex + 9] = this.register.sbyte_9;
        numPtr[startIndex + 10] = this.register.sbyte_10;
        numPtr[startIndex + 11] = this.register.sbyte_11;
        numPtr[startIndex + 12] = this.register.sbyte_12;
        numPtr[startIndex + 13] = this.register.sbyte_13;
        numPtr[startIndex + 14] = this.register.sbyte_14;
        numPtr[startIndex + 15] = this.register.sbyte_15;
      }
    }
    else if (typeof (T) == typeof (ushort))
    {
      fixed (ushort* numPtr = (ushort[]) destination)
      {
        numPtr[startIndex] = this.register.uint16_0;
        numPtr[startIndex + 1] = this.register.uint16_1;
        numPtr[startIndex + 2] = this.register.uint16_2;
        numPtr[startIndex + 3] = this.register.uint16_3;
        numPtr[startIndex + 4] = this.register.uint16_4;
        numPtr[startIndex + 5] = this.register.uint16_5;
        numPtr[startIndex + 6] = this.register.uint16_6;
        numPtr[startIndex + 7] = this.register.uint16_7;
      }
    }
    else if (typeof (T) == typeof (short))
    {
      fixed (short* numPtr = (short[]) destination)
      {
        numPtr[startIndex] = this.register.int16_0;
        numPtr[startIndex + 1] = this.register.int16_1;
        numPtr[startIndex + 2] = this.register.int16_2;
        numPtr[startIndex + 3] = this.register.int16_3;
        numPtr[startIndex + 4] = this.register.int16_4;
        numPtr[startIndex + 5] = this.register.int16_5;
        numPtr[startIndex + 6] = this.register.int16_6;
        numPtr[startIndex + 7] = this.register.int16_7;
      }
    }
    else if (typeof (T) == typeof (uint))
    {
      fixed (uint* numPtr = (uint[]) destination)
      {
        numPtr[startIndex] = this.register.uint32_0;
        numPtr[startIndex + 1] = this.register.uint32_1;
        numPtr[startIndex + 2] = this.register.uint32_2;
        numPtr[startIndex + 3] = this.register.uint32_3;
      }
    }
    else if (typeof (T) == typeof (int))
    {
      fixed (int* numPtr = (int[]) destination)
      {
        numPtr[startIndex] = this.register.int32_0;
        numPtr[startIndex + 1] = this.register.int32_1;
        numPtr[startIndex + 2] = this.register.int32_2;
        numPtr[startIndex + 3] = this.register.int32_3;
      }
    }
    else if (typeof (T) == typeof (ulong))
    {
      fixed (ulong* numPtr = (ulong[]) destination)
      {
        numPtr[startIndex] = this.register.uint64_0;
        numPtr[startIndex + 1] = this.register.uint64_1;
      }
    }
    else if (typeof (T) == typeof (long))
    {
      fixed (long* numPtr = (long[]) destination)
      {
        numPtr[startIndex] = this.register.int64_0;
        numPtr[startIndex + 1] = this.register.int64_1;
      }
    }
    else if (typeof (T) == typeof (float))
    {
      fixed (float* numPtr = (float[]) destination)
      {
        numPtr[startIndex] = this.register.single_0;
        numPtr[startIndex + 1] = this.register.single_1;
        numPtr[startIndex + 2] = this.register.single_2;
        numPtr[startIndex + 3] = this.register.single_3;
      }
    }
    else
    {
      if (!(typeof (T) == typeof (double)))
        return;
      fixed (double* numPtr = (double[]) destination)
      {
        numPtr[startIndex] = this.register.double_0;
        numPtr[startIndex + 1] = this.register.double_1;
      }
    }
  }

  public unsafe T this[int index]
  {
    [Intrinsic] get
    {
      if (index >= Vector<T>.Count || index < 0)
        throw new IndexOutOfRangeException(System.System.Numerics.Vectors3620677.SR.Format(System.System.Numerics.Vectors3620677.SR.Arg_ArgumentOutOfRangeException, (object) index));
      if (typeof (T) == typeof (byte))
      {
        fixed (byte* numPtr = &this.register.byte_0)
          return (T) (ValueType) numPtr[index];
      }
      if (typeof (T) == typeof (sbyte))
      {
        fixed (sbyte* numPtr = &this.register.sbyte_0)
          return (T) (ValueType) numPtr[index];
      }
      if (typeof (T) == typeof (ushort))
      {
        fixed (ushort* numPtr = &this.register.uint16_0)
          return (T) (ValueType) numPtr[index];
      }
      if (typeof (T) == typeof (short))
      {
        fixed (short* numPtr = &this.register.int16_0)
          return (T) (ValueType) numPtr[index];
      }
      if (typeof (T) == typeof (uint))
      {
        fixed (uint* numPtr = &this.register.uint32_0)
          return (T) (ValueType) numPtr[index];
      }
      if (typeof (T) == typeof (int))
      {
        fixed (int* numPtr = &this.register.int32_0)
          return (T) (ValueType) numPtr[index];
      }
      if (typeof (T) == typeof (ulong))
      {
        fixed (ulong* numPtr = &this.register.uint64_0)
          return (T) (ValueType) numPtr[index];
      }
      if (typeof (T) == typeof (long))
      {
        fixed (long* numPtr = &this.register.int64_0)
          return (T) (ValueType) numPtr[index];
      }
      if (typeof (T) == typeof (float))
      {
        fixed (float* numPtr = &this.register.single_0)
          return (T) (ValueType) numPtr[index];
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      fixed (double* numPtr = &this.register.double_0)
        return (T) (ValueType) numPtr[index];
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals(object obj) => obj is Vector<T> other && this.Equals(other);

  [Intrinsic]
  public bool Equals(Vector<T> other)
  {
    if (Vector.IsHardwareAccelerated)
    {
      for (int index = 0; index < Vector<T>.Count; ++index)
      {
        if (!Vector<T>.ScalarEquals(this[index], other[index]))
          return false;
      }
      return true;
    }
    if (typeof (T) == typeof (byte))
      return (int) this.register.byte_0 == (int) other.register.byte_0 && (int) this.register.byte_1 == (int) other.register.byte_1 && (int) this.register.byte_2 == (int) other.register.byte_2 && (int) this.register.byte_3 == (int) other.register.byte_3 && (int) this.register.byte_4 == (int) other.register.byte_4 && (int) this.register.byte_5 == (int) other.register.byte_5 && (int) this.register.byte_6 == (int) other.register.byte_6 && (int) this.register.byte_7 == (int) other.register.byte_7 && (int) this.register.byte_8 == (int) other.register.byte_8 && (int) this.register.byte_9 == (int) other.register.byte_9 && (int) this.register.byte_10 == (int) other.register.byte_10 && (int) this.register.byte_11 == (int) other.register.byte_11 && (int) this.register.byte_12 == (int) other.register.byte_12 && (int) this.register.byte_13 == (int) other.register.byte_13 && (int) this.register.byte_14 == (int) other.register.byte_14 && (int) this.register.byte_15 == (int) other.register.byte_15;
    if (typeof (T) == typeof (sbyte))
      return (int) this.register.sbyte_0 == (int) other.register.sbyte_0 && (int) this.register.sbyte_1 == (int) other.register.sbyte_1 && (int) this.register.sbyte_2 == (int) other.register.sbyte_2 && (int) this.register.sbyte_3 == (int) other.register.sbyte_3 && (int) this.register.sbyte_4 == (int) other.register.sbyte_4 && (int) this.register.sbyte_5 == (int) other.register.sbyte_5 && (int) this.register.sbyte_6 == (int) other.register.sbyte_6 && (int) this.register.sbyte_7 == (int) other.register.sbyte_7 && (int) this.register.sbyte_8 == (int) other.register.sbyte_8 && (int) this.register.sbyte_9 == (int) other.register.sbyte_9 && (int) this.register.sbyte_10 == (int) other.register.sbyte_10 && (int) this.register.sbyte_11 == (int) other.register.sbyte_11 && (int) this.register.sbyte_12 == (int) other.register.sbyte_12 && (int) this.register.sbyte_13 == (int) other.register.sbyte_13 && (int) this.register.sbyte_14 == (int) other.register.sbyte_14 && (int) this.register.sbyte_15 == (int) other.register.sbyte_15;
    if (typeof (T) == typeof (ushort))
      return (int) this.register.uint16_0 == (int) other.register.uint16_0 && (int) this.register.uint16_1 == (int) other.register.uint16_1 && (int) this.register.uint16_2 == (int) other.register.uint16_2 && (int) this.register.uint16_3 == (int) other.register.uint16_3 && (int) this.register.uint16_4 == (int) other.register.uint16_4 && (int) this.register.uint16_5 == (int) other.register.uint16_5 && (int) this.register.uint16_6 == (int) other.register.uint16_6 && (int) this.register.uint16_7 == (int) other.register.uint16_7;
    if (typeof (T) == typeof (short))
      return (int) this.register.int16_0 == (int) other.register.int16_0 && (int) this.register.int16_1 == (int) other.register.int16_1 && (int) this.register.int16_2 == (int) other.register.int16_2 && (int) this.register.int16_3 == (int) other.register.int16_3 && (int) this.register.int16_4 == (int) other.register.int16_4 && (int) this.register.int16_5 == (int) other.register.int16_5 && (int) this.register.int16_6 == (int) other.register.int16_6 && (int) this.register.int16_7 == (int) other.register.int16_7;
    if (typeof (T) == typeof (uint))
      return (int) this.register.uint32_0 == (int) other.register.uint32_0 && (int) this.register.uint32_1 == (int) other.register.uint32_1 && (int) this.register.uint32_2 == (int) other.register.uint32_2 && (int) this.register.uint32_3 == (int) other.register.uint32_3;
    if (typeof (T) == typeof (int))
      return this.register.int32_0 == other.register.int32_0 && this.register.int32_1 == other.register.int32_1 && this.register.int32_2 == other.register.int32_2 && this.register.int32_3 == other.register.int32_3;
    if (typeof (T) == typeof (ulong))
      return (long) this.register.uint64_0 == (long) other.register.uint64_0 && (long) this.register.uint64_1 == (long) other.register.uint64_1;
    if (typeof (T) == typeof (long))
      return this.register.int64_0 == other.register.int64_0 && this.register.int64_1 == other.register.int64_1;
    if (typeof (T) == typeof (float))
      return (double) this.register.single_0 == (double) other.register.single_0 && (double) this.register.single_1 == (double) other.register.single_1 && (double) this.register.single_2 == (double) other.register.single_2 && (double) this.register.single_3 == (double) other.register.single_3;
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return this.register.double_0 == other.register.double_0 && this.register.double_1 == other.register.double_1;
  }

  public override int GetHashCode()
  {
    int h1 = 0;
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          h1 = HashHelpers.Combine(h1, ((byte) (ValueType) this[index]).GetHashCode());
        return h1;
      }
      if (typeof (T) == typeof (sbyte))
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          h1 = HashHelpers.Combine(h1, ((sbyte) (ValueType) this[index]).GetHashCode());
        return h1;
      }
      if (typeof (T) == typeof (ushort))
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          h1 = HashHelpers.Combine(h1, ((ushort) (ValueType) this[index]).GetHashCode());
        return h1;
      }
      if (typeof (T) == typeof (short))
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          h1 = HashHelpers.Combine(h1, ((short) (ValueType) this[index]).GetHashCode());
        return h1;
      }
      if (typeof (T) == typeof (uint))
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          h1 = HashHelpers.Combine(h1, ((uint) (ValueType) this[index]).GetHashCode());
        return h1;
      }
      if (typeof (T) == typeof (int))
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          h1 = HashHelpers.Combine(h1, ((int) (ValueType) this[index]).GetHashCode());
        return h1;
      }
      if (typeof (T) == typeof (ulong))
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          h1 = HashHelpers.Combine(h1, ((ulong) (ValueType) this[index]).GetHashCode());
        return h1;
      }
      if (typeof (T) == typeof (long))
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          h1 = HashHelpers.Combine(h1, ((long) (ValueType) this[index]).GetHashCode());
        return h1;
      }
      if (typeof (T) == typeof (float))
      {
        for (int index = 0; index < Vector<T>.Count; ++index)
          h1 = HashHelpers.Combine(h1, ((float) (ValueType) this[index]).GetHashCode());
        return h1;
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      for (int index = 0; index < Vector<T>.Count; ++index)
        h1 = HashHelpers.Combine(h1, ((double) (ValueType) this[index]).GetHashCode());
      return h1;
    }
    if (typeof (T) == typeof (byte))
      return HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(h1, this.register.byte_0.GetHashCode()), this.register.byte_1.GetHashCode()), this.register.byte_2.GetHashCode()), this.register.byte_3.GetHashCode()), this.register.byte_4.GetHashCode()), this.register.byte_5.GetHashCode()), this.register.byte_6.GetHashCode()), this.register.byte_7.GetHashCode()), this.register.byte_8.GetHashCode()), this.register.byte_9.GetHashCode()), this.register.byte_10.GetHashCode()), this.register.byte_11.GetHashCode()), this.register.byte_12.GetHashCode()), this.register.byte_13.GetHashCode()), this.register.byte_14.GetHashCode()), this.register.byte_15.GetHashCode());
    if (typeof (T) == typeof (sbyte))
      return HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(h1, this.register.sbyte_0.GetHashCode()), this.register.sbyte_1.GetHashCode()), this.register.sbyte_2.GetHashCode()), this.register.sbyte_3.GetHashCode()), this.register.sbyte_4.GetHashCode()), this.register.sbyte_5.GetHashCode()), this.register.sbyte_6.GetHashCode()), this.register.sbyte_7.GetHashCode()), this.register.sbyte_8.GetHashCode()), this.register.sbyte_9.GetHashCode()), this.register.sbyte_10.GetHashCode()), this.register.sbyte_11.GetHashCode()), this.register.sbyte_12.GetHashCode()), this.register.sbyte_13.GetHashCode()), this.register.sbyte_14.GetHashCode()), this.register.sbyte_15.GetHashCode());
    if (typeof (T) == typeof (ushort))
      return HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(h1, this.register.uint16_0.GetHashCode()), this.register.uint16_1.GetHashCode()), this.register.uint16_2.GetHashCode()), this.register.uint16_3.GetHashCode()), this.register.uint16_4.GetHashCode()), this.register.uint16_5.GetHashCode()), this.register.uint16_6.GetHashCode()), this.register.uint16_7.GetHashCode());
    if (typeof (T) == typeof (short))
      return HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(h1, this.register.int16_0.GetHashCode()), this.register.int16_1.GetHashCode()), this.register.int16_2.GetHashCode()), this.register.int16_3.GetHashCode()), this.register.int16_4.GetHashCode()), this.register.int16_5.GetHashCode()), this.register.int16_6.GetHashCode()), this.register.int16_7.GetHashCode());
    if (typeof (T) == typeof (uint))
      return HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(h1, this.register.uint32_0.GetHashCode()), this.register.uint32_1.GetHashCode()), this.register.uint32_2.GetHashCode()), this.register.uint32_3.GetHashCode());
    if (typeof (T) == typeof (int))
      return HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(h1, this.register.int32_0.GetHashCode()), this.register.int32_1.GetHashCode()), this.register.int32_2.GetHashCode()), this.register.int32_3.GetHashCode());
    if (typeof (T) == typeof (ulong))
      return HashHelpers.Combine(HashHelpers.Combine(h1, this.register.uint64_0.GetHashCode()), this.register.uint64_1.GetHashCode());
    if (typeof (T) == typeof (long))
      return HashHelpers.Combine(HashHelpers.Combine(h1, this.register.int64_0.GetHashCode()), this.register.int64_1.GetHashCode());
    if (typeof (T) == typeof (float))
      return HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(h1, this.register.single_0.GetHashCode()), this.register.single_1.GetHashCode()), this.register.single_2.GetHashCode()), this.register.single_3.GetHashCode());
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return HashHelpers.Combine(HashHelpers.Combine(h1, this.register.double_0.GetHashCode()), this.register.double_1.GetHashCode());
  }

  public override string ToString()
  {
    return this.ToString("G", (IFormatProvider) CultureInfo.CurrentCulture);
  }

  public string ToString(string format)
  {
    return this.ToString(format, (IFormatProvider) CultureInfo.CurrentCulture);
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    StringBuilder stringBuilder = new StringBuilder();
    string numberGroupSeparator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
    stringBuilder.Append('<');
    for (int index = 0; index < Vector<T>.Count - 1; ++index)
    {
      stringBuilder.Append(((IFormattable) this[index]).ToString(format, formatProvider));
      stringBuilder.Append(numberGroupSeparator);
      stringBuilder.Append(' ');
    }
    stringBuilder.Append(((IFormattable) this[Vector<T>.Count - 1]).ToString(format, formatProvider));
    stringBuilder.Append('>');
    return stringBuilder.ToString();
  }

  public static unsafe Vector<T> operator +(Vector<T> left, Vector<T> right)
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        byte* dataPointer = stackalloc byte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (byte) (ValueType) Vector<T>.ScalarAdd(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (sbyte) (ValueType) Vector<T>.ScalarAdd(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ushort))
      {
        ushort* dataPointer = stackalloc ushort[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (ushort) (ValueType) Vector<T>.ScalarAdd(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (short) (ValueType) Vector<T>.ScalarAdd(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (uint))
      {
        uint* dataPointer = stackalloc uint[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (uint) (ValueType) Vector<T>.ScalarAdd(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (int) (ValueType) Vector<T>.ScalarAdd(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ulong))
      {
        ulong* dataPointer = stackalloc ulong[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (ulong) (ValueType) Vector<T>.ScalarAdd(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (long) (ValueType) Vector<T>.ScalarAdd(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (float) (ValueType) Vector<T>.ScalarAdd(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = (double) (ValueType) Vector<T>.ScalarAdd(left[index], right[index]);
      return new Vector<T>((void*) dataPointer1);
    }
    Vector<T> vector = new Vector<T>();
    if (typeof (T) == typeof (byte))
    {
      vector.register.byte_0 = (byte) ((uint) left.register.byte_0 + (uint) right.register.byte_0);
      vector.register.byte_1 = (byte) ((uint) left.register.byte_1 + (uint) right.register.byte_1);
      vector.register.byte_2 = (byte) ((uint) left.register.byte_2 + (uint) right.register.byte_2);
      vector.register.byte_3 = (byte) ((uint) left.register.byte_3 + (uint) right.register.byte_3);
      vector.register.byte_4 = (byte) ((uint) left.register.byte_4 + (uint) right.register.byte_4);
      vector.register.byte_5 = (byte) ((uint) left.register.byte_5 + (uint) right.register.byte_5);
      vector.register.byte_6 = (byte) ((uint) left.register.byte_6 + (uint) right.register.byte_6);
      vector.register.byte_7 = (byte) ((uint) left.register.byte_7 + (uint) right.register.byte_7);
      vector.register.byte_8 = (byte) ((uint) left.register.byte_8 + (uint) right.register.byte_8);
      vector.register.byte_9 = (byte) ((uint) left.register.byte_9 + (uint) right.register.byte_9);
      vector.register.byte_10 = (byte) ((uint) left.register.byte_10 + (uint) right.register.byte_10);
      vector.register.byte_11 = (byte) ((uint) left.register.byte_11 + (uint) right.register.byte_11);
      vector.register.byte_12 = (byte) ((uint) left.register.byte_12 + (uint) right.register.byte_12);
      vector.register.byte_13 = (byte) ((uint) left.register.byte_13 + (uint) right.register.byte_13);
      vector.register.byte_14 = (byte) ((uint) left.register.byte_14 + (uint) right.register.byte_14);
      vector.register.byte_15 = (byte) ((uint) left.register.byte_15 + (uint) right.register.byte_15);
    }
    else if (typeof (T) == typeof (sbyte))
    {
      vector.register.sbyte_0 = (sbyte) ((int) left.register.sbyte_0 + (int) right.register.sbyte_0);
      vector.register.sbyte_1 = (sbyte) ((int) left.register.sbyte_1 + (int) right.register.sbyte_1);
      vector.register.sbyte_2 = (sbyte) ((int) left.register.sbyte_2 + (int) right.register.sbyte_2);
      vector.register.sbyte_3 = (sbyte) ((int) left.register.sbyte_3 + (int) right.register.sbyte_3);
      vector.register.sbyte_4 = (sbyte) ((int) left.register.sbyte_4 + (int) right.register.sbyte_4);
      vector.register.sbyte_5 = (sbyte) ((int) left.register.sbyte_5 + (int) right.register.sbyte_5);
      vector.register.sbyte_6 = (sbyte) ((int) left.register.sbyte_6 + (int) right.register.sbyte_6);
      vector.register.sbyte_7 = (sbyte) ((int) left.register.sbyte_7 + (int) right.register.sbyte_7);
      vector.register.sbyte_8 = (sbyte) ((int) left.register.sbyte_8 + (int) right.register.sbyte_8);
      vector.register.sbyte_9 = (sbyte) ((int) left.register.sbyte_9 + (int) right.register.sbyte_9);
      vector.register.sbyte_10 = (sbyte) ((int) left.register.sbyte_10 + (int) right.register.sbyte_10);
      vector.register.sbyte_11 = (sbyte) ((int) left.register.sbyte_11 + (int) right.register.sbyte_11);
      vector.register.sbyte_12 = (sbyte) ((int) left.register.sbyte_12 + (int) right.register.sbyte_12);
      vector.register.sbyte_13 = (sbyte) ((int) left.register.sbyte_13 + (int) right.register.sbyte_13);
      vector.register.sbyte_14 = (sbyte) ((int) left.register.sbyte_14 + (int) right.register.sbyte_14);
      vector.register.sbyte_15 = (sbyte) ((int) left.register.sbyte_15 + (int) right.register.sbyte_15);
    }
    else if (typeof (T) == typeof (ushort))
    {
      vector.register.uint16_0 = (ushort) ((uint) left.register.uint16_0 + (uint) right.register.uint16_0);
      vector.register.uint16_1 = (ushort) ((uint) left.register.uint16_1 + (uint) right.register.uint16_1);
      vector.register.uint16_2 = (ushort) ((uint) left.register.uint16_2 + (uint) right.register.uint16_2);
      vector.register.uint16_3 = (ushort) ((uint) left.register.uint16_3 + (uint) right.register.uint16_3);
      vector.register.uint16_4 = (ushort) ((uint) left.register.uint16_4 + (uint) right.register.uint16_4);
      vector.register.uint16_5 = (ushort) ((uint) left.register.uint16_5 + (uint) right.register.uint16_5);
      vector.register.uint16_6 = (ushort) ((uint) left.register.uint16_6 + (uint) right.register.uint16_6);
      vector.register.uint16_7 = (ushort) ((uint) left.register.uint16_7 + (uint) right.register.uint16_7);
    }
    else if (typeof (T) == typeof (short))
    {
      vector.register.int16_0 = (short) ((int) left.register.int16_0 + (int) right.register.int16_0);
      vector.register.int16_1 = (short) ((int) left.register.int16_1 + (int) right.register.int16_1);
      vector.register.int16_2 = (short) ((int) left.register.int16_2 + (int) right.register.int16_2);
      vector.register.int16_3 = (short) ((int) left.register.int16_3 + (int) right.register.int16_3);
      vector.register.int16_4 = (short) ((int) left.register.int16_4 + (int) right.register.int16_4);
      vector.register.int16_5 = (short) ((int) left.register.int16_5 + (int) right.register.int16_5);
      vector.register.int16_6 = (short) ((int) left.register.int16_6 + (int) right.register.int16_6);
      vector.register.int16_7 = (short) ((int) left.register.int16_7 + (int) right.register.int16_7);
    }
    else if (typeof (T) == typeof (uint))
    {
      vector.register.uint32_0 = left.register.uint32_0 + right.register.uint32_0;
      vector.register.uint32_1 = left.register.uint32_1 + right.register.uint32_1;
      vector.register.uint32_2 = left.register.uint32_2 + right.register.uint32_2;
      vector.register.uint32_3 = left.register.uint32_3 + right.register.uint32_3;
    }
    else if (typeof (T) == typeof (int))
    {
      vector.register.int32_0 = left.register.int32_0 + right.register.int32_0;
      vector.register.int32_1 = left.register.int32_1 + right.register.int32_1;
      vector.register.int32_2 = left.register.int32_2 + right.register.int32_2;
      vector.register.int32_3 = left.register.int32_3 + right.register.int32_3;
    }
    else if (typeof (T) == typeof (ulong))
    {
      vector.register.uint64_0 = left.register.uint64_0 + right.register.uint64_0;
      vector.register.uint64_1 = left.register.uint64_1 + right.register.uint64_1;
    }
    else if (typeof (T) == typeof (long))
    {
      vector.register.int64_0 = left.register.int64_0 + right.register.int64_0;
      vector.register.int64_1 = left.register.int64_1 + right.register.int64_1;
    }
    else if (typeof (T) == typeof (float))
    {
      vector.register.single_0 = left.register.single_0 + right.register.single_0;
      vector.register.single_1 = left.register.single_1 + right.register.single_1;
      vector.register.single_2 = left.register.single_2 + right.register.single_2;
      vector.register.single_3 = left.register.single_3 + right.register.single_3;
    }
    else if (typeof (T) == typeof (double))
    {
      vector.register.double_0 = left.register.double_0 + right.register.double_0;
      vector.register.double_1 = left.register.double_1 + right.register.double_1;
    }
    return vector;
  }

  public static unsafe Vector<T> operator -(Vector<T> left, Vector<T> right)
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        byte* dataPointer = stackalloc byte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (byte) (ValueType) Vector<T>.ScalarSubtract(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (sbyte) (ValueType) Vector<T>.ScalarSubtract(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ushort))
      {
        ushort* dataPointer = stackalloc ushort[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (ushort) (ValueType) Vector<T>.ScalarSubtract(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (short) (ValueType) Vector<T>.ScalarSubtract(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (uint))
      {
        uint* dataPointer = stackalloc uint[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (uint) (ValueType) Vector<T>.ScalarSubtract(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (int) (ValueType) Vector<T>.ScalarSubtract(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ulong))
      {
        ulong* dataPointer = stackalloc ulong[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (ulong) (ValueType) Vector<T>.ScalarSubtract(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (long) (ValueType) Vector<T>.ScalarSubtract(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (float) (ValueType) Vector<T>.ScalarSubtract(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = (double) (ValueType) Vector<T>.ScalarSubtract(left[index], right[index]);
      return new Vector<T>((void*) dataPointer1);
    }
    Vector<T> vector = new Vector<T>();
    if (typeof (T) == typeof (byte))
    {
      vector.register.byte_0 = (byte) ((uint) left.register.byte_0 - (uint) right.register.byte_0);
      vector.register.byte_1 = (byte) ((uint) left.register.byte_1 - (uint) right.register.byte_1);
      vector.register.byte_2 = (byte) ((uint) left.register.byte_2 - (uint) right.register.byte_2);
      vector.register.byte_3 = (byte) ((uint) left.register.byte_3 - (uint) right.register.byte_3);
      vector.register.byte_4 = (byte) ((uint) left.register.byte_4 - (uint) right.register.byte_4);
      vector.register.byte_5 = (byte) ((uint) left.register.byte_5 - (uint) right.register.byte_5);
      vector.register.byte_6 = (byte) ((uint) left.register.byte_6 - (uint) right.register.byte_6);
      vector.register.byte_7 = (byte) ((uint) left.register.byte_7 - (uint) right.register.byte_7);
      vector.register.byte_8 = (byte) ((uint) left.register.byte_8 - (uint) right.register.byte_8);
      vector.register.byte_9 = (byte) ((uint) left.register.byte_9 - (uint) right.register.byte_9);
      vector.register.byte_10 = (byte) ((uint) left.register.byte_10 - (uint) right.register.byte_10);
      vector.register.byte_11 = (byte) ((uint) left.register.byte_11 - (uint) right.register.byte_11);
      vector.register.byte_12 = (byte) ((uint) left.register.byte_12 - (uint) right.register.byte_12);
      vector.register.byte_13 = (byte) ((uint) left.register.byte_13 - (uint) right.register.byte_13);
      vector.register.byte_14 = (byte) ((uint) left.register.byte_14 - (uint) right.register.byte_14);
      vector.register.byte_15 = (byte) ((uint) left.register.byte_15 - (uint) right.register.byte_15);
    }
    else if (typeof (T) == typeof (sbyte))
    {
      vector.register.sbyte_0 = (sbyte) ((int) left.register.sbyte_0 - (int) right.register.sbyte_0);
      vector.register.sbyte_1 = (sbyte) ((int) left.register.sbyte_1 - (int) right.register.sbyte_1);
      vector.register.sbyte_2 = (sbyte) ((int) left.register.sbyte_2 - (int) right.register.sbyte_2);
      vector.register.sbyte_3 = (sbyte) ((int) left.register.sbyte_3 - (int) right.register.sbyte_3);
      vector.register.sbyte_4 = (sbyte) ((int) left.register.sbyte_4 - (int) right.register.sbyte_4);
      vector.register.sbyte_5 = (sbyte) ((int) left.register.sbyte_5 - (int) right.register.sbyte_5);
      vector.register.sbyte_6 = (sbyte) ((int) left.register.sbyte_6 - (int) right.register.sbyte_6);
      vector.register.sbyte_7 = (sbyte) ((int) left.register.sbyte_7 - (int) right.register.sbyte_7);
      vector.register.sbyte_8 = (sbyte) ((int) left.register.sbyte_8 - (int) right.register.sbyte_8);
      vector.register.sbyte_9 = (sbyte) ((int) left.register.sbyte_9 - (int) right.register.sbyte_9);
      vector.register.sbyte_10 = (sbyte) ((int) left.register.sbyte_10 - (int) right.register.sbyte_10);
      vector.register.sbyte_11 = (sbyte) ((int) left.register.sbyte_11 - (int) right.register.sbyte_11);
      vector.register.sbyte_12 = (sbyte) ((int) left.register.sbyte_12 - (int) right.register.sbyte_12);
      vector.register.sbyte_13 = (sbyte) ((int) left.register.sbyte_13 - (int) right.register.sbyte_13);
      vector.register.sbyte_14 = (sbyte) ((int) left.register.sbyte_14 - (int) right.register.sbyte_14);
      vector.register.sbyte_15 = (sbyte) ((int) left.register.sbyte_15 - (int) right.register.sbyte_15);
    }
    else if (typeof (T) == typeof (ushort))
    {
      vector.register.uint16_0 = (ushort) ((uint) left.register.uint16_0 - (uint) right.register.uint16_0);
      vector.register.uint16_1 = (ushort) ((uint) left.register.uint16_1 - (uint) right.register.uint16_1);
      vector.register.uint16_2 = (ushort) ((uint) left.register.uint16_2 - (uint) right.register.uint16_2);
      vector.register.uint16_3 = (ushort) ((uint) left.register.uint16_3 - (uint) right.register.uint16_3);
      vector.register.uint16_4 = (ushort) ((uint) left.register.uint16_4 - (uint) right.register.uint16_4);
      vector.register.uint16_5 = (ushort) ((uint) left.register.uint16_5 - (uint) right.register.uint16_5);
      vector.register.uint16_6 = (ushort) ((uint) left.register.uint16_6 - (uint) right.register.uint16_6);
      vector.register.uint16_7 = (ushort) ((uint) left.register.uint16_7 - (uint) right.register.uint16_7);
    }
    else if (typeof (T) == typeof (short))
    {
      vector.register.int16_0 = (short) ((int) left.register.int16_0 - (int) right.register.int16_0);
      vector.register.int16_1 = (short) ((int) left.register.int16_1 - (int) right.register.int16_1);
      vector.register.int16_2 = (short) ((int) left.register.int16_2 - (int) right.register.int16_2);
      vector.register.int16_3 = (short) ((int) left.register.int16_3 - (int) right.register.int16_3);
      vector.register.int16_4 = (short) ((int) left.register.int16_4 - (int) right.register.int16_4);
      vector.register.int16_5 = (short) ((int) left.register.int16_5 - (int) right.register.int16_5);
      vector.register.int16_6 = (short) ((int) left.register.int16_6 - (int) right.register.int16_6);
      vector.register.int16_7 = (short) ((int) left.register.int16_7 - (int) right.register.int16_7);
    }
    else if (typeof (T) == typeof (uint))
    {
      vector.register.uint32_0 = left.register.uint32_0 - right.register.uint32_0;
      vector.register.uint32_1 = left.register.uint32_1 - right.register.uint32_1;
      vector.register.uint32_2 = left.register.uint32_2 - right.register.uint32_2;
      vector.register.uint32_3 = left.register.uint32_3 - right.register.uint32_3;
    }
    else if (typeof (T) == typeof (int))
    {
      vector.register.int32_0 = left.register.int32_0 - right.register.int32_0;
      vector.register.int32_1 = left.register.int32_1 - right.register.int32_1;
      vector.register.int32_2 = left.register.int32_2 - right.register.int32_2;
      vector.register.int32_3 = left.register.int32_3 - right.register.int32_3;
    }
    else if (typeof (T) == typeof (ulong))
    {
      vector.register.uint64_0 = left.register.uint64_0 - right.register.uint64_0;
      vector.register.uint64_1 = left.register.uint64_1 - right.register.uint64_1;
    }
    else if (typeof (T) == typeof (long))
    {
      vector.register.int64_0 = left.register.int64_0 - right.register.int64_0;
      vector.register.int64_1 = left.register.int64_1 - right.register.int64_1;
    }
    else if (typeof (T) == typeof (float))
    {
      vector.register.single_0 = left.register.single_0 - right.register.single_0;
      vector.register.single_1 = left.register.single_1 - right.register.single_1;
      vector.register.single_2 = left.register.single_2 - right.register.single_2;
      vector.register.single_3 = left.register.single_3 - right.register.single_3;
    }
    else if (typeof (T) == typeof (double))
    {
      vector.register.double_0 = left.register.double_0 - right.register.double_0;
      vector.register.double_1 = left.register.double_1 - right.register.double_1;
    }
    return vector;
  }

  public static unsafe Vector<T> operator *(Vector<T> left, Vector<T> right)
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        byte* dataPointer = stackalloc byte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (byte) (ValueType) Vector<T>.ScalarMultiply(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (sbyte) (ValueType) Vector<T>.ScalarMultiply(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ushort))
      {
        ushort* dataPointer = stackalloc ushort[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (ushort) (ValueType) Vector<T>.ScalarMultiply(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (short) (ValueType) Vector<T>.ScalarMultiply(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (uint))
      {
        uint* dataPointer = stackalloc uint[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (uint) (ValueType) Vector<T>.ScalarMultiply(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (int) (ValueType) Vector<T>.ScalarMultiply(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ulong))
      {
        ulong* dataPointer = stackalloc ulong[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (ulong) (ValueType) Vector<T>.ScalarMultiply(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (long) (ValueType) Vector<T>.ScalarMultiply(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (float) (ValueType) Vector<T>.ScalarMultiply(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = (double) (ValueType) Vector<T>.ScalarMultiply(left[index], right[index]);
      return new Vector<T>((void*) dataPointer1);
    }
    Vector<T> vector = new Vector<T>();
    if (typeof (T) == typeof (byte))
    {
      vector.register.byte_0 = (byte) ((uint) left.register.byte_0 * (uint) right.register.byte_0);
      vector.register.byte_1 = (byte) ((uint) left.register.byte_1 * (uint) right.register.byte_1);
      vector.register.byte_2 = (byte) ((uint) left.register.byte_2 * (uint) right.register.byte_2);
      vector.register.byte_3 = (byte) ((uint) left.register.byte_3 * (uint) right.register.byte_3);
      vector.register.byte_4 = (byte) ((uint) left.register.byte_4 * (uint) right.register.byte_4);
      vector.register.byte_5 = (byte) ((uint) left.register.byte_5 * (uint) right.register.byte_5);
      vector.register.byte_6 = (byte) ((uint) left.register.byte_6 * (uint) right.register.byte_6);
      vector.register.byte_7 = (byte) ((uint) left.register.byte_7 * (uint) right.register.byte_7);
      vector.register.byte_8 = (byte) ((uint) left.register.byte_8 * (uint) right.register.byte_8);
      vector.register.byte_9 = (byte) ((uint) left.register.byte_9 * (uint) right.register.byte_9);
      vector.register.byte_10 = (byte) ((uint) left.register.byte_10 * (uint) right.register.byte_10);
      vector.register.byte_11 = (byte) ((uint) left.register.byte_11 * (uint) right.register.byte_11);
      vector.register.byte_12 = (byte) ((uint) left.register.byte_12 * (uint) right.register.byte_12);
      vector.register.byte_13 = (byte) ((uint) left.register.byte_13 * (uint) right.register.byte_13);
      vector.register.byte_14 = (byte) ((uint) left.register.byte_14 * (uint) right.register.byte_14);
      vector.register.byte_15 = (byte) ((uint) left.register.byte_15 * (uint) right.register.byte_15);
    }
    else if (typeof (T) == typeof (sbyte))
    {
      vector.register.sbyte_0 = (sbyte) ((int) left.register.sbyte_0 * (int) right.register.sbyte_0);
      vector.register.sbyte_1 = (sbyte) ((int) left.register.sbyte_1 * (int) right.register.sbyte_1);
      vector.register.sbyte_2 = (sbyte) ((int) left.register.sbyte_2 * (int) right.register.sbyte_2);
      vector.register.sbyte_3 = (sbyte) ((int) left.register.sbyte_3 * (int) right.register.sbyte_3);
      vector.register.sbyte_4 = (sbyte) ((int) left.register.sbyte_4 * (int) right.register.sbyte_4);
      vector.register.sbyte_5 = (sbyte) ((int) left.register.sbyte_5 * (int) right.register.sbyte_5);
      vector.register.sbyte_6 = (sbyte) ((int) left.register.sbyte_6 * (int) right.register.sbyte_6);
      vector.register.sbyte_7 = (sbyte) ((int) left.register.sbyte_7 * (int) right.register.sbyte_7);
      vector.register.sbyte_8 = (sbyte) ((int) left.register.sbyte_8 * (int) right.register.sbyte_8);
      vector.register.sbyte_9 = (sbyte) ((int) left.register.sbyte_9 * (int) right.register.sbyte_9);
      vector.register.sbyte_10 = (sbyte) ((int) left.register.sbyte_10 * (int) right.register.sbyte_10);
      vector.register.sbyte_11 = (sbyte) ((int) left.register.sbyte_11 * (int) right.register.sbyte_11);
      vector.register.sbyte_12 = (sbyte) ((int) left.register.sbyte_12 * (int) right.register.sbyte_12);
      vector.register.sbyte_13 = (sbyte) ((int) left.register.sbyte_13 * (int) right.register.sbyte_13);
      vector.register.sbyte_14 = (sbyte) ((int) left.register.sbyte_14 * (int) right.register.sbyte_14);
      vector.register.sbyte_15 = (sbyte) ((int) left.register.sbyte_15 * (int) right.register.sbyte_15);
    }
    else if (typeof (T) == typeof (ushort))
    {
      vector.register.uint16_0 = (ushort) ((uint) left.register.uint16_0 * (uint) right.register.uint16_0);
      vector.register.uint16_1 = (ushort) ((uint) left.register.uint16_1 * (uint) right.register.uint16_1);
      vector.register.uint16_2 = (ushort) ((uint) left.register.uint16_2 * (uint) right.register.uint16_2);
      vector.register.uint16_3 = (ushort) ((uint) left.register.uint16_3 * (uint) right.register.uint16_3);
      vector.register.uint16_4 = (ushort) ((uint) left.register.uint16_4 * (uint) right.register.uint16_4);
      vector.register.uint16_5 = (ushort) ((uint) left.register.uint16_5 * (uint) right.register.uint16_5);
      vector.register.uint16_6 = (ushort) ((uint) left.register.uint16_6 * (uint) right.register.uint16_6);
      vector.register.uint16_7 = (ushort) ((uint) left.register.uint16_7 * (uint) right.register.uint16_7);
    }
    else if (typeof (T) == typeof (short))
    {
      vector.register.int16_0 = (short) ((int) left.register.int16_0 * (int) right.register.int16_0);
      vector.register.int16_1 = (short) ((int) left.register.int16_1 * (int) right.register.int16_1);
      vector.register.int16_2 = (short) ((int) left.register.int16_2 * (int) right.register.int16_2);
      vector.register.int16_3 = (short) ((int) left.register.int16_3 * (int) right.register.int16_3);
      vector.register.int16_4 = (short) ((int) left.register.int16_4 * (int) right.register.int16_4);
      vector.register.int16_5 = (short) ((int) left.register.int16_5 * (int) right.register.int16_5);
      vector.register.int16_6 = (short) ((int) left.register.int16_6 * (int) right.register.int16_6);
      vector.register.int16_7 = (short) ((int) left.register.int16_7 * (int) right.register.int16_7);
    }
    else if (typeof (T) == typeof (uint))
    {
      vector.register.uint32_0 = left.register.uint32_0 * right.register.uint32_0;
      vector.register.uint32_1 = left.register.uint32_1 * right.register.uint32_1;
      vector.register.uint32_2 = left.register.uint32_2 * right.register.uint32_2;
      vector.register.uint32_3 = left.register.uint32_3 * right.register.uint32_3;
    }
    else if (typeof (T) == typeof (int))
    {
      vector.register.int32_0 = left.register.int32_0 * right.register.int32_0;
      vector.register.int32_1 = left.register.int32_1 * right.register.int32_1;
      vector.register.int32_2 = left.register.int32_2 * right.register.int32_2;
      vector.register.int32_3 = left.register.int32_3 * right.register.int32_3;
    }
    else if (typeof (T) == typeof (ulong))
    {
      vector.register.uint64_0 = left.register.uint64_0 * right.register.uint64_0;
      vector.register.uint64_1 = left.register.uint64_1 * right.register.uint64_1;
    }
    else if (typeof (T) == typeof (long))
    {
      vector.register.int64_0 = left.register.int64_0 * right.register.int64_0;
      vector.register.int64_1 = left.register.int64_1 * right.register.int64_1;
    }
    else if (typeof (T) == typeof (float))
    {
      vector.register.single_0 = left.register.single_0 * right.register.single_0;
      vector.register.single_1 = left.register.single_1 * right.register.single_1;
      vector.register.single_2 = left.register.single_2 * right.register.single_2;
      vector.register.single_3 = left.register.single_3 * right.register.single_3;
    }
    else if (typeof (T) == typeof (double))
    {
      vector.register.double_0 = left.register.double_0 * right.register.double_0;
      vector.register.double_1 = left.register.double_1 * right.register.double_1;
    }
    return vector;
  }

  public static Vector<T> operator *(Vector<T> value, T factor)
  {
    if (Vector.IsHardwareAccelerated)
      return new Vector<T>(factor) * value;
    Vector<T> vector = new Vector<T>();
    if (typeof (T) == typeof (byte))
    {
      vector.register.byte_0 = (byte) ((uint) value.register.byte_0 * (uint) (byte) (ValueType) factor);
      vector.register.byte_1 = (byte) ((uint) value.register.byte_1 * (uint) (byte) (ValueType) factor);
      vector.register.byte_2 = (byte) ((uint) value.register.byte_2 * (uint) (byte) (ValueType) factor);
      vector.register.byte_3 = (byte) ((uint) value.register.byte_3 * (uint) (byte) (ValueType) factor);
      vector.register.byte_4 = (byte) ((uint) value.register.byte_4 * (uint) (byte) (ValueType) factor);
      vector.register.byte_5 = (byte) ((uint) value.register.byte_5 * (uint) (byte) (ValueType) factor);
      vector.register.byte_6 = (byte) ((uint) value.register.byte_6 * (uint) (byte) (ValueType) factor);
      vector.register.byte_7 = (byte) ((uint) value.register.byte_7 * (uint) (byte) (ValueType) factor);
      vector.register.byte_8 = (byte) ((uint) value.register.byte_8 * (uint) (byte) (ValueType) factor);
      vector.register.byte_9 = (byte) ((uint) value.register.byte_9 * (uint) (byte) (ValueType) factor);
      vector.register.byte_10 = (byte) ((uint) value.register.byte_10 * (uint) (byte) (ValueType) factor);
      vector.register.byte_11 = (byte) ((uint) value.register.byte_11 * (uint) (byte) (ValueType) factor);
      vector.register.byte_12 = (byte) ((uint) value.register.byte_12 * (uint) (byte) (ValueType) factor);
      vector.register.byte_13 = (byte) ((uint) value.register.byte_13 * (uint) (byte) (ValueType) factor);
      vector.register.byte_14 = (byte) ((uint) value.register.byte_14 * (uint) (byte) (ValueType) factor);
      vector.register.byte_15 = (byte) ((uint) value.register.byte_15 * (uint) (byte) (ValueType) factor);
    }
    else if (typeof (T) == typeof (sbyte))
    {
      vector.register.sbyte_0 = (sbyte) ((int) value.register.sbyte_0 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_1 = (sbyte) ((int) value.register.sbyte_1 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_2 = (sbyte) ((int) value.register.sbyte_2 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_3 = (sbyte) ((int) value.register.sbyte_3 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_4 = (sbyte) ((int) value.register.sbyte_4 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_5 = (sbyte) ((int) value.register.sbyte_5 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_6 = (sbyte) ((int) value.register.sbyte_6 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_7 = (sbyte) ((int) value.register.sbyte_7 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_8 = (sbyte) ((int) value.register.sbyte_8 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_9 = (sbyte) ((int) value.register.sbyte_9 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_10 = (sbyte) ((int) value.register.sbyte_10 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_11 = (sbyte) ((int) value.register.sbyte_11 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_12 = (sbyte) ((int) value.register.sbyte_12 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_13 = (sbyte) ((int) value.register.sbyte_13 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_14 = (sbyte) ((int) value.register.sbyte_14 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_15 = (sbyte) ((int) value.register.sbyte_15 * (int) (sbyte) (ValueType) factor);
    }
    else if (typeof (T) == typeof (ushort))
    {
      vector.register.uint16_0 = (ushort) ((uint) value.register.uint16_0 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_1 = (ushort) ((uint) value.register.uint16_1 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_2 = (ushort) ((uint) value.register.uint16_2 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_3 = (ushort) ((uint) value.register.uint16_3 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_4 = (ushort) ((uint) value.register.uint16_4 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_5 = (ushort) ((uint) value.register.uint16_5 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_6 = (ushort) ((uint) value.register.uint16_6 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_7 = (ushort) ((uint) value.register.uint16_7 * (uint) (ushort) (ValueType) factor);
    }
    else if (typeof (T) == typeof (short))
    {
      vector.register.int16_0 = (short) ((int) value.register.int16_0 * (int) (short) (ValueType) factor);
      vector.register.int16_1 = (short) ((int) value.register.int16_1 * (int) (short) (ValueType) factor);
      vector.register.int16_2 = (short) ((int) value.register.int16_2 * (int) (short) (ValueType) factor);
      vector.register.int16_3 = (short) ((int) value.register.int16_3 * (int) (short) (ValueType) factor);
      vector.register.int16_4 = (short) ((int) value.register.int16_4 * (int) (short) (ValueType) factor);
      vector.register.int16_5 = (short) ((int) value.register.int16_5 * (int) (short) (ValueType) factor);
      vector.register.int16_6 = (short) ((int) value.register.int16_6 * (int) (short) (ValueType) factor);
      vector.register.int16_7 = (short) ((int) value.register.int16_7 * (int) (short) (ValueType) factor);
    }
    else if (typeof (T) == typeof (uint))
    {
      vector.register.uint32_0 = value.register.uint32_0 * (uint) (ValueType) factor;
      vector.register.uint32_1 = value.register.uint32_1 * (uint) (ValueType) factor;
      vector.register.uint32_2 = value.register.uint32_2 * (uint) (ValueType) factor;
      vector.register.uint32_3 = value.register.uint32_3 * (uint) (ValueType) factor;
    }
    else if (typeof (T) == typeof (int))
    {
      vector.register.int32_0 = value.register.int32_0 * (int) (ValueType) factor;
      vector.register.int32_1 = value.register.int32_1 * (int) (ValueType) factor;
      vector.register.int32_2 = value.register.int32_2 * (int) (ValueType) factor;
      vector.register.int32_3 = value.register.int32_3 * (int) (ValueType) factor;
    }
    else if (typeof (T) == typeof (ulong))
    {
      vector.register.uint64_0 = value.register.uint64_0 * (ulong) (ValueType) factor;
      vector.register.uint64_1 = value.register.uint64_1 * (ulong) (ValueType) factor;
    }
    else if (typeof (T) == typeof (long))
    {
      vector.register.int64_0 = value.register.int64_0 * (long) (ValueType) factor;
      vector.register.int64_1 = value.register.int64_1 * (long) (ValueType) factor;
    }
    else if (typeof (T) == typeof (float))
    {
      vector.register.single_0 = value.register.single_0 * (float) (ValueType) factor;
      vector.register.single_1 = value.register.single_1 * (float) (ValueType) factor;
      vector.register.single_2 = value.register.single_2 * (float) (ValueType) factor;
      vector.register.single_3 = value.register.single_3 * (float) (ValueType) factor;
    }
    else if (typeof (T) == typeof (double))
    {
      vector.register.double_0 = value.register.double_0 * (double) (ValueType) factor;
      vector.register.double_1 = value.register.double_1 * (double) (ValueType) factor;
    }
    return vector;
  }

  public static Vector<T> operator *(T factor, Vector<T> value)
  {
    if (Vector.IsHardwareAccelerated)
      return new Vector<T>(factor) * value;
    Vector<T> vector = new Vector<T>();
    if (typeof (T) == typeof (byte))
    {
      vector.register.byte_0 = (byte) ((uint) value.register.byte_0 * (uint) (byte) (ValueType) factor);
      vector.register.byte_1 = (byte) ((uint) value.register.byte_1 * (uint) (byte) (ValueType) factor);
      vector.register.byte_2 = (byte) ((uint) value.register.byte_2 * (uint) (byte) (ValueType) factor);
      vector.register.byte_3 = (byte) ((uint) value.register.byte_3 * (uint) (byte) (ValueType) factor);
      vector.register.byte_4 = (byte) ((uint) value.register.byte_4 * (uint) (byte) (ValueType) factor);
      vector.register.byte_5 = (byte) ((uint) value.register.byte_5 * (uint) (byte) (ValueType) factor);
      vector.register.byte_6 = (byte) ((uint) value.register.byte_6 * (uint) (byte) (ValueType) factor);
      vector.register.byte_7 = (byte) ((uint) value.register.byte_7 * (uint) (byte) (ValueType) factor);
      vector.register.byte_8 = (byte) ((uint) value.register.byte_8 * (uint) (byte) (ValueType) factor);
      vector.register.byte_9 = (byte) ((uint) value.register.byte_9 * (uint) (byte) (ValueType) factor);
      vector.register.byte_10 = (byte) ((uint) value.register.byte_10 * (uint) (byte) (ValueType) factor);
      vector.register.byte_11 = (byte) ((uint) value.register.byte_11 * (uint) (byte) (ValueType) factor);
      vector.register.byte_12 = (byte) ((uint) value.register.byte_12 * (uint) (byte) (ValueType) factor);
      vector.register.byte_13 = (byte) ((uint) value.register.byte_13 * (uint) (byte) (ValueType) factor);
      vector.register.byte_14 = (byte) ((uint) value.register.byte_14 * (uint) (byte) (ValueType) factor);
      vector.register.byte_15 = (byte) ((uint) value.register.byte_15 * (uint) (byte) (ValueType) factor);
    }
    else if (typeof (T) == typeof (sbyte))
    {
      vector.register.sbyte_0 = (sbyte) ((int) value.register.sbyte_0 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_1 = (sbyte) ((int) value.register.sbyte_1 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_2 = (sbyte) ((int) value.register.sbyte_2 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_3 = (sbyte) ((int) value.register.sbyte_3 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_4 = (sbyte) ((int) value.register.sbyte_4 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_5 = (sbyte) ((int) value.register.sbyte_5 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_6 = (sbyte) ((int) value.register.sbyte_6 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_7 = (sbyte) ((int) value.register.sbyte_7 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_8 = (sbyte) ((int) value.register.sbyte_8 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_9 = (sbyte) ((int) value.register.sbyte_9 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_10 = (sbyte) ((int) value.register.sbyte_10 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_11 = (sbyte) ((int) value.register.sbyte_11 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_12 = (sbyte) ((int) value.register.sbyte_12 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_13 = (sbyte) ((int) value.register.sbyte_13 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_14 = (sbyte) ((int) value.register.sbyte_14 * (int) (sbyte) (ValueType) factor);
      vector.register.sbyte_15 = (sbyte) ((int) value.register.sbyte_15 * (int) (sbyte) (ValueType) factor);
    }
    else if (typeof (T) == typeof (ushort))
    {
      vector.register.uint16_0 = (ushort) ((uint) value.register.uint16_0 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_1 = (ushort) ((uint) value.register.uint16_1 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_2 = (ushort) ((uint) value.register.uint16_2 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_3 = (ushort) ((uint) value.register.uint16_3 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_4 = (ushort) ((uint) value.register.uint16_4 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_5 = (ushort) ((uint) value.register.uint16_5 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_6 = (ushort) ((uint) value.register.uint16_6 * (uint) (ushort) (ValueType) factor);
      vector.register.uint16_7 = (ushort) ((uint) value.register.uint16_7 * (uint) (ushort) (ValueType) factor);
    }
    else if (typeof (T) == typeof (short))
    {
      vector.register.int16_0 = (short) ((int) value.register.int16_0 * (int) (short) (ValueType) factor);
      vector.register.int16_1 = (short) ((int) value.register.int16_1 * (int) (short) (ValueType) factor);
      vector.register.int16_2 = (short) ((int) value.register.int16_2 * (int) (short) (ValueType) factor);
      vector.register.int16_3 = (short) ((int) value.register.int16_3 * (int) (short) (ValueType) factor);
      vector.register.int16_4 = (short) ((int) value.register.int16_4 * (int) (short) (ValueType) factor);
      vector.register.int16_5 = (short) ((int) value.register.int16_5 * (int) (short) (ValueType) factor);
      vector.register.int16_6 = (short) ((int) value.register.int16_6 * (int) (short) (ValueType) factor);
      vector.register.int16_7 = (short) ((int) value.register.int16_7 * (int) (short) (ValueType) factor);
    }
    else if (typeof (T) == typeof (uint))
    {
      vector.register.uint32_0 = value.register.uint32_0 * (uint) (ValueType) factor;
      vector.register.uint32_1 = value.register.uint32_1 * (uint) (ValueType) factor;
      vector.register.uint32_2 = value.register.uint32_2 * (uint) (ValueType) factor;
      vector.register.uint32_3 = value.register.uint32_3 * (uint) (ValueType) factor;
    }
    else if (typeof (T) == typeof (int))
    {
      vector.register.int32_0 = value.register.int32_0 * (int) (ValueType) factor;
      vector.register.int32_1 = value.register.int32_1 * (int) (ValueType) factor;
      vector.register.int32_2 = value.register.int32_2 * (int) (ValueType) factor;
      vector.register.int32_3 = value.register.int32_3 * (int) (ValueType) factor;
    }
    else if (typeof (T) == typeof (ulong))
    {
      vector.register.uint64_0 = value.register.uint64_0 * (ulong) (ValueType) factor;
      vector.register.uint64_1 = value.register.uint64_1 * (ulong) (ValueType) factor;
    }
    else if (typeof (T) == typeof (long))
    {
      vector.register.int64_0 = value.register.int64_0 * (long) (ValueType) factor;
      vector.register.int64_1 = value.register.int64_1 * (long) (ValueType) factor;
    }
    else if (typeof (T) == typeof (float))
    {
      vector.register.single_0 = value.register.single_0 * (float) (ValueType) factor;
      vector.register.single_1 = value.register.single_1 * (float) (ValueType) factor;
      vector.register.single_2 = value.register.single_2 * (float) (ValueType) factor;
      vector.register.single_3 = value.register.single_3 * (float) (ValueType) factor;
    }
    else if (typeof (T) == typeof (double))
    {
      vector.register.double_0 = value.register.double_0 * (double) (ValueType) factor;
      vector.register.double_1 = value.register.double_1 * (double) (ValueType) factor;
    }
    return vector;
  }

  public static unsafe Vector<T> operator /(Vector<T> left, Vector<T> right)
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        byte* dataPointer = stackalloc byte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (byte) (ValueType) Vector<T>.ScalarDivide(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (sbyte) (ValueType) Vector<T>.ScalarDivide(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ushort))
      {
        ushort* dataPointer = stackalloc ushort[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (ushort) (ValueType) Vector<T>.ScalarDivide(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (short) (ValueType) Vector<T>.ScalarDivide(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (uint))
      {
        uint* dataPointer = stackalloc uint[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (uint) (ValueType) Vector<T>.ScalarDivide(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (int) (ValueType) Vector<T>.ScalarDivide(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ulong))
      {
        ulong* dataPointer = stackalloc ulong[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (ulong) (ValueType) Vector<T>.ScalarDivide(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (long) (ValueType) Vector<T>.ScalarDivide(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (float) (ValueType) Vector<T>.ScalarDivide(left[index], right[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = (double) (ValueType) Vector<T>.ScalarDivide(left[index], right[index]);
      return new Vector<T>((void*) dataPointer1);
    }
    Vector<T> vector = new Vector<T>();
    if (typeof (T) == typeof (byte))
    {
      vector.register.byte_0 = (byte) ((uint) left.register.byte_0 / (uint) right.register.byte_0);
      vector.register.byte_1 = (byte) ((uint) left.register.byte_1 / (uint) right.register.byte_1);
      vector.register.byte_2 = (byte) ((uint) left.register.byte_2 / (uint) right.register.byte_2);
      vector.register.byte_3 = (byte) ((uint) left.register.byte_3 / (uint) right.register.byte_3);
      vector.register.byte_4 = (byte) ((uint) left.register.byte_4 / (uint) right.register.byte_4);
      vector.register.byte_5 = (byte) ((uint) left.register.byte_5 / (uint) right.register.byte_5);
      vector.register.byte_6 = (byte) ((uint) left.register.byte_6 / (uint) right.register.byte_6);
      vector.register.byte_7 = (byte) ((uint) left.register.byte_7 / (uint) right.register.byte_7);
      vector.register.byte_8 = (byte) ((uint) left.register.byte_8 / (uint) right.register.byte_8);
      vector.register.byte_9 = (byte) ((uint) left.register.byte_9 / (uint) right.register.byte_9);
      vector.register.byte_10 = (byte) ((uint) left.register.byte_10 / (uint) right.register.byte_10);
      vector.register.byte_11 = (byte) ((uint) left.register.byte_11 / (uint) right.register.byte_11);
      vector.register.byte_12 = (byte) ((uint) left.register.byte_12 / (uint) right.register.byte_12);
      vector.register.byte_13 = (byte) ((uint) left.register.byte_13 / (uint) right.register.byte_13);
      vector.register.byte_14 = (byte) ((uint) left.register.byte_14 / (uint) right.register.byte_14);
      vector.register.byte_15 = (byte) ((uint) left.register.byte_15 / (uint) right.register.byte_15);
    }
    else if (typeof (T) == typeof (sbyte))
    {
      vector.register.sbyte_0 = (sbyte) ((int) left.register.sbyte_0 / (int) right.register.sbyte_0);
      vector.register.sbyte_1 = (sbyte) ((int) left.register.sbyte_1 / (int) right.register.sbyte_1);
      vector.register.sbyte_2 = (sbyte) ((int) left.register.sbyte_2 / (int) right.register.sbyte_2);
      vector.register.sbyte_3 = (sbyte) ((int) left.register.sbyte_3 / (int) right.register.sbyte_3);
      vector.register.sbyte_4 = (sbyte) ((int) left.register.sbyte_4 / (int) right.register.sbyte_4);
      vector.register.sbyte_5 = (sbyte) ((int) left.register.sbyte_5 / (int) right.register.sbyte_5);
      vector.register.sbyte_6 = (sbyte) ((int) left.register.sbyte_6 / (int) right.register.sbyte_6);
      vector.register.sbyte_7 = (sbyte) ((int) left.register.sbyte_7 / (int) right.register.sbyte_7);
      vector.register.sbyte_8 = (sbyte) ((int) left.register.sbyte_8 / (int) right.register.sbyte_8);
      vector.register.sbyte_9 = (sbyte) ((int) left.register.sbyte_9 / (int) right.register.sbyte_9);
      vector.register.sbyte_10 = (sbyte) ((int) left.register.sbyte_10 / (int) right.register.sbyte_10);
      vector.register.sbyte_11 = (sbyte) ((int) left.register.sbyte_11 / (int) right.register.sbyte_11);
      vector.register.sbyte_12 = (sbyte) ((int) left.register.sbyte_12 / (int) right.register.sbyte_12);
      vector.register.sbyte_13 = (sbyte) ((int) left.register.sbyte_13 / (int) right.register.sbyte_13);
      vector.register.sbyte_14 = (sbyte) ((int) left.register.sbyte_14 / (int) right.register.sbyte_14);
      vector.register.sbyte_15 = (sbyte) ((int) left.register.sbyte_15 / (int) right.register.sbyte_15);
    }
    else if (typeof (T) == typeof (ushort))
    {
      vector.register.uint16_0 = (ushort) ((uint) left.register.uint16_0 / (uint) right.register.uint16_0);
      vector.register.uint16_1 = (ushort) ((uint) left.register.uint16_1 / (uint) right.register.uint16_1);
      vector.register.uint16_2 = (ushort) ((uint) left.register.uint16_2 / (uint) right.register.uint16_2);
      vector.register.uint16_3 = (ushort) ((uint) left.register.uint16_3 / (uint) right.register.uint16_3);
      vector.register.uint16_4 = (ushort) ((uint) left.register.uint16_4 / (uint) right.register.uint16_4);
      vector.register.uint16_5 = (ushort) ((uint) left.register.uint16_5 / (uint) right.register.uint16_5);
      vector.register.uint16_6 = (ushort) ((uint) left.register.uint16_6 / (uint) right.register.uint16_6);
      vector.register.uint16_7 = (ushort) ((uint) left.register.uint16_7 / (uint) right.register.uint16_7);
    }
    else if (typeof (T) == typeof (short))
    {
      vector.register.int16_0 = (short) ((int) left.register.int16_0 / (int) right.register.int16_0);
      vector.register.int16_1 = (short) ((int) left.register.int16_1 / (int) right.register.int16_1);
      vector.register.int16_2 = (short) ((int) left.register.int16_2 / (int) right.register.int16_2);
      vector.register.int16_3 = (short) ((int) left.register.int16_3 / (int) right.register.int16_3);
      vector.register.int16_4 = (short) ((int) left.register.int16_4 / (int) right.register.int16_4);
      vector.register.int16_5 = (short) ((int) left.register.int16_5 / (int) right.register.int16_5);
      vector.register.int16_6 = (short) ((int) left.register.int16_6 / (int) right.register.int16_6);
      vector.register.int16_7 = (short) ((int) left.register.int16_7 / (int) right.register.int16_7);
    }
    else if (typeof (T) == typeof (uint))
    {
      vector.register.uint32_0 = left.register.uint32_0 / right.register.uint32_0;
      vector.register.uint32_1 = left.register.uint32_1 / right.register.uint32_1;
      vector.register.uint32_2 = left.register.uint32_2 / right.register.uint32_2;
      vector.register.uint32_3 = left.register.uint32_3 / right.register.uint32_3;
    }
    else if (typeof (T) == typeof (int))
    {
      vector.register.int32_0 = left.register.int32_0 / right.register.int32_0;
      vector.register.int32_1 = left.register.int32_1 / right.register.int32_1;
      vector.register.int32_2 = left.register.int32_2 / right.register.int32_2;
      vector.register.int32_3 = left.register.int32_3 / right.register.int32_3;
    }
    else if (typeof (T) == typeof (ulong))
    {
      vector.register.uint64_0 = left.register.uint64_0 / right.register.uint64_0;
      vector.register.uint64_1 = left.register.uint64_1 / right.register.uint64_1;
    }
    else if (typeof (T) == typeof (long))
    {
      vector.register.int64_0 = left.register.int64_0 / right.register.int64_0;
      vector.register.int64_1 = left.register.int64_1 / right.register.int64_1;
    }
    else if (typeof (T) == typeof (float))
    {
      vector.register.single_0 = left.register.single_0 / right.register.single_0;
      vector.register.single_1 = left.register.single_1 / right.register.single_1;
      vector.register.single_2 = left.register.single_2 / right.register.single_2;
      vector.register.single_3 = left.register.single_3 / right.register.single_3;
    }
    else if (typeof (T) == typeof (double))
    {
      vector.register.double_0 = left.register.double_0 / right.register.double_0;
      vector.register.double_1 = left.register.double_1 / right.register.double_1;
    }
    return vector;
  }

  public static Vector<T> operator -(Vector<T> value) => Vector<T>.Zero - value;

  [Intrinsic]
  public static unsafe Vector<T> operator &(Vector<T> left, Vector<T> right)
  {
    Vector<T> vector = new Vector<T>();
    if (Vector.IsHardwareAccelerated)
    {
      long* numPtr1 = &vector.register.int64_0;
      long* numPtr2 = &left.register.int64_0;
      long* numPtr3 = &right.register.int64_0;
      for (int index = 0; index < Vector<long>.Count; ++index)
        numPtr1[index] = numPtr2[index] & numPtr3[index];
    }
    else
    {
      vector.register.int64_0 = left.register.int64_0 & right.register.int64_0;
      vector.register.int64_1 = left.register.int64_1 & right.register.int64_1;
    }
    return vector;
  }

  [Intrinsic]
  public static unsafe Vector<T> operator |(Vector<T> left, Vector<T> right)
  {
    Vector<T> vector = new Vector<T>();
    if (Vector.IsHardwareAccelerated)
    {
      long* numPtr1 = &vector.register.int64_0;
      long* numPtr2 = &left.register.int64_0;
      long* numPtr3 = &right.register.int64_0;
      for (int index = 0; index < Vector<long>.Count; ++index)
        numPtr1[index] = numPtr2[index] | numPtr3[index];
    }
    else
    {
      vector.register.int64_0 = left.register.int64_0 | right.register.int64_0;
      vector.register.int64_1 = left.register.int64_1 | right.register.int64_1;
    }
    return vector;
  }

  [Intrinsic]
  public static unsafe Vector<T> operator ^(Vector<T> left, Vector<T> right)
  {
    Vector<T> vector = new Vector<T>();
    if (Vector.IsHardwareAccelerated)
    {
      long* numPtr1 = &vector.register.int64_0;
      long* numPtr2 = &left.register.int64_0;
      long* numPtr3 = &right.register.int64_0;
      for (int index = 0; index < Vector<long>.Count; ++index)
        numPtr1[index] = numPtr2[index] ^ numPtr3[index];
    }
    else
    {
      vector.register.int64_0 = left.register.int64_0 ^ right.register.int64_0;
      vector.register.int64_1 = left.register.int64_1 ^ right.register.int64_1;
    }
    return vector;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Vector<T> operator ~(Vector<T> value) => Vector<T>.s_allOnes ^ value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(Vector<T> left, Vector<T> right) => left.Equals(right);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(Vector<T> left, Vector<T> right) => !(left == right);

  [Intrinsic]
  public static explicit operator Vector<byte>(Vector<T> value)
  {
    return new Vector<byte>(ref value.register);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static explicit operator Vector<sbyte>(Vector<T> value)
  {
    return new Vector<sbyte>(ref value.register);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static explicit operator Vector<ushort>(Vector<T> value)
  {
    return new Vector<ushort>(ref value.register);
  }

  [Intrinsic]
  public static explicit operator Vector<short>(Vector<T> value)
  {
    return new Vector<short>(ref value.register);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static explicit operator Vector<uint>(Vector<T> value)
  {
    return new Vector<uint>(ref value.register);
  }

  [Intrinsic]
  public static explicit operator Vector<int>(Vector<T> value)
  {
    return new Vector<int>(ref value.register);
  }

  [CLSCompliant(false)]
  [Intrinsic]
  public static explicit operator Vector<ulong>(Vector<T> value)
  {
    return new Vector<ulong>(ref value.register);
  }

  [Intrinsic]
  public static explicit operator Vector<long>(Vector<T> value)
  {
    return new Vector<long>(ref value.register);
  }

  [Intrinsic]
  public static explicit operator Vector<float>(Vector<T> value)
  {
    return new Vector<float>(ref value.register);
  }

  [Intrinsic]
  public static explicit operator Vector<double>(Vector<T> value)
  {
    return new Vector<double>(ref value.register);
  }

  [Intrinsic]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static unsafe Vector<T> Equals(Vector<T> left, Vector<T> right)
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        byte* dataPointer = stackalloc byte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarEquals(left[index], right[index]) ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarEquals(left[index], right[index]) ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ushort))
      {
        ushort* dataPointer = stackalloc ushort[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarEquals(left[index], right[index]) ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarEquals(left[index], right[index]) ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (uint))
      {
        uint* dataPointer = stackalloc uint[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarEquals(left[index], right[index]) ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarEquals(left[index], right[index]) ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ulong))
      {
        ulong* dataPointer = stackalloc ulong[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarEquals(left[index], right[index]) ? ConstantHelper.GetUInt64WithAllBitsSet() : 0UL;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarEquals(left[index], right[index]) ? ConstantHelper.GetInt64WithAllBitsSet() : 0L;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarEquals(left[index], right[index]) ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = Vector<T>.ScalarEquals(left[index], right[index]) ? ConstantHelper.GetDoubleWithAllBitsSet() : 0.0;
      return new Vector<T>((void*) dataPointer1);
    }
    Register existingRegister = new Register();
    if (typeof (T) == typeof (byte))
    {
      existingRegister.byte_0 = (int) left.register.byte_0 == (int) right.register.byte_0 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_1 = (int) left.register.byte_1 == (int) right.register.byte_1 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_2 = (int) left.register.byte_2 == (int) right.register.byte_2 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_3 = (int) left.register.byte_3 == (int) right.register.byte_3 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_4 = (int) left.register.byte_4 == (int) right.register.byte_4 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_5 = (int) left.register.byte_5 == (int) right.register.byte_5 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_6 = (int) left.register.byte_6 == (int) right.register.byte_6 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_7 = (int) left.register.byte_7 == (int) right.register.byte_7 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_8 = (int) left.register.byte_8 == (int) right.register.byte_8 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_9 = (int) left.register.byte_9 == (int) right.register.byte_9 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_10 = (int) left.register.byte_10 == (int) right.register.byte_10 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_11 = (int) left.register.byte_11 == (int) right.register.byte_11 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_12 = (int) left.register.byte_12 == (int) right.register.byte_12 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_13 = (int) left.register.byte_13 == (int) right.register.byte_13 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_14 = (int) left.register.byte_14 == (int) right.register.byte_14 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_15 = (int) left.register.byte_15 == (int) right.register.byte_15 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (sbyte))
    {
      existingRegister.sbyte_0 = (int) left.register.sbyte_0 == (int) right.register.sbyte_0 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_1 = (int) left.register.sbyte_1 == (int) right.register.sbyte_1 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_2 = (int) left.register.sbyte_2 == (int) right.register.sbyte_2 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_3 = (int) left.register.sbyte_3 == (int) right.register.sbyte_3 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_4 = (int) left.register.sbyte_4 == (int) right.register.sbyte_4 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_5 = (int) left.register.sbyte_5 == (int) right.register.sbyte_5 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_6 = (int) left.register.sbyte_6 == (int) right.register.sbyte_6 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_7 = (int) left.register.sbyte_7 == (int) right.register.sbyte_7 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_8 = (int) left.register.sbyte_8 == (int) right.register.sbyte_8 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_9 = (int) left.register.sbyte_9 == (int) right.register.sbyte_9 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_10 = (int) left.register.sbyte_10 == (int) right.register.sbyte_10 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_11 = (int) left.register.sbyte_11 == (int) right.register.sbyte_11 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_12 = (int) left.register.sbyte_12 == (int) right.register.sbyte_12 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_13 = (int) left.register.sbyte_13 == (int) right.register.sbyte_13 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_14 = (int) left.register.sbyte_14 == (int) right.register.sbyte_14 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_15 = (int) left.register.sbyte_15 == (int) right.register.sbyte_15 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (ushort))
    {
      existingRegister.uint16_0 = (int) left.register.uint16_0 == (int) right.register.uint16_0 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_1 = (int) left.register.uint16_1 == (int) right.register.uint16_1 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_2 = (int) left.register.uint16_2 == (int) right.register.uint16_2 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_3 = (int) left.register.uint16_3 == (int) right.register.uint16_3 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_4 = (int) left.register.uint16_4 == (int) right.register.uint16_4 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_5 = (int) left.register.uint16_5 == (int) right.register.uint16_5 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_6 = (int) left.register.uint16_6 == (int) right.register.uint16_6 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_7 = (int) left.register.uint16_7 == (int) right.register.uint16_7 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (short))
    {
      existingRegister.int16_0 = (int) left.register.int16_0 == (int) right.register.int16_0 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_1 = (int) left.register.int16_1 == (int) right.register.int16_1 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_2 = (int) left.register.int16_2 == (int) right.register.int16_2 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_3 = (int) left.register.int16_3 == (int) right.register.int16_3 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_4 = (int) left.register.int16_4 == (int) right.register.int16_4 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_5 = (int) left.register.int16_5 == (int) right.register.int16_5 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_6 = (int) left.register.int16_6 == (int) right.register.int16_6 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_7 = (int) left.register.int16_7 == (int) right.register.int16_7 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (uint))
    {
      existingRegister.uint32_0 = (int) left.register.uint32_0 == (int) right.register.uint32_0 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      existingRegister.uint32_1 = (int) left.register.uint32_1 == (int) right.register.uint32_1 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      existingRegister.uint32_2 = (int) left.register.uint32_2 == (int) right.register.uint32_2 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      existingRegister.uint32_3 = (int) left.register.uint32_3 == (int) right.register.uint32_3 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (int))
    {
      existingRegister.int32_0 = left.register.int32_0 == right.register.int32_0 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      existingRegister.int32_1 = left.register.int32_1 == right.register.int32_1 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      existingRegister.int32_2 = left.register.int32_2 == right.register.int32_2 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      existingRegister.int32_3 = left.register.int32_3 == right.register.int32_3 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (ulong))
    {
      existingRegister.uint64_0 = (long) left.register.uint64_0 == (long) right.register.uint64_0 ? ConstantHelper.GetUInt64WithAllBitsSet() : 0UL;
      existingRegister.uint64_1 = (long) left.register.uint64_1 == (long) right.register.uint64_1 ? ConstantHelper.GetUInt64WithAllBitsSet() : 0UL;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (long))
    {
      existingRegister.int64_0 = left.register.int64_0 == right.register.int64_0 ? ConstantHelper.GetInt64WithAllBitsSet() : 0L;
      existingRegister.int64_1 = left.register.int64_1 == right.register.int64_1 ? ConstantHelper.GetInt64WithAllBitsSet() : 0L;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (float))
    {
      existingRegister.single_0 = (double) left.register.single_0 == (double) right.register.single_0 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      existingRegister.single_1 = (double) left.register.single_1 == (double) right.register.single_1 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      existingRegister.single_2 = (double) left.register.single_2 == (double) right.register.single_2 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      existingRegister.single_3 = (double) left.register.single_3 == (double) right.register.single_3 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      return new Vector<T>(ref existingRegister);
    }
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    existingRegister.double_0 = left.register.double_0 == right.register.double_0 ? ConstantHelper.GetDoubleWithAllBitsSet() : 0.0;
    existingRegister.double_1 = left.register.double_1 == right.register.double_1 ? ConstantHelper.GetDoubleWithAllBitsSet() : 0.0;
    return new Vector<T>(ref existingRegister);
  }

  [Intrinsic]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static unsafe Vector<T> LessThan(Vector<T> left, Vector<T> right)
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        byte* dataPointer = stackalloc byte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ushort))
      {
        ushort* dataPointer = stackalloc ushort[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (uint))
      {
        uint* dataPointer = stackalloc uint[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ulong))
      {
        ulong* dataPointer = stackalloc ulong[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? ConstantHelper.GetUInt64WithAllBitsSet() : 0UL;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? ConstantHelper.GetInt64WithAllBitsSet() : 0L;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? ConstantHelper.GetDoubleWithAllBitsSet() : 0.0;
      return new Vector<T>((void*) dataPointer1);
    }
    Register existingRegister = new Register();
    if (typeof (T) == typeof (byte))
    {
      existingRegister.byte_0 = (int) left.register.byte_0 < (int) right.register.byte_0 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_1 = (int) left.register.byte_1 < (int) right.register.byte_1 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_2 = (int) left.register.byte_2 < (int) right.register.byte_2 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_3 = (int) left.register.byte_3 < (int) right.register.byte_3 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_4 = (int) left.register.byte_4 < (int) right.register.byte_4 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_5 = (int) left.register.byte_5 < (int) right.register.byte_5 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_6 = (int) left.register.byte_6 < (int) right.register.byte_6 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_7 = (int) left.register.byte_7 < (int) right.register.byte_7 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_8 = (int) left.register.byte_8 < (int) right.register.byte_8 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_9 = (int) left.register.byte_9 < (int) right.register.byte_9 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_10 = (int) left.register.byte_10 < (int) right.register.byte_10 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_11 = (int) left.register.byte_11 < (int) right.register.byte_11 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_12 = (int) left.register.byte_12 < (int) right.register.byte_12 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_13 = (int) left.register.byte_13 < (int) right.register.byte_13 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_14 = (int) left.register.byte_14 < (int) right.register.byte_14 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_15 = (int) left.register.byte_15 < (int) right.register.byte_15 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (sbyte))
    {
      existingRegister.sbyte_0 = (int) left.register.sbyte_0 < (int) right.register.sbyte_0 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_1 = (int) left.register.sbyte_1 < (int) right.register.sbyte_1 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_2 = (int) left.register.sbyte_2 < (int) right.register.sbyte_2 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_3 = (int) left.register.sbyte_3 < (int) right.register.sbyte_3 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_4 = (int) left.register.sbyte_4 < (int) right.register.sbyte_4 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_5 = (int) left.register.sbyte_5 < (int) right.register.sbyte_5 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_6 = (int) left.register.sbyte_6 < (int) right.register.sbyte_6 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_7 = (int) left.register.sbyte_7 < (int) right.register.sbyte_7 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_8 = (int) left.register.sbyte_8 < (int) right.register.sbyte_8 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_9 = (int) left.register.sbyte_9 < (int) right.register.sbyte_9 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_10 = (int) left.register.sbyte_10 < (int) right.register.sbyte_10 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_11 = (int) left.register.sbyte_11 < (int) right.register.sbyte_11 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_12 = (int) left.register.sbyte_12 < (int) right.register.sbyte_12 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_13 = (int) left.register.sbyte_13 < (int) right.register.sbyte_13 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_14 = (int) left.register.sbyte_14 < (int) right.register.sbyte_14 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_15 = (int) left.register.sbyte_15 < (int) right.register.sbyte_15 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (ushort))
    {
      existingRegister.uint16_0 = (int) left.register.uint16_0 < (int) right.register.uint16_0 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_1 = (int) left.register.uint16_1 < (int) right.register.uint16_1 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_2 = (int) left.register.uint16_2 < (int) right.register.uint16_2 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_3 = (int) left.register.uint16_3 < (int) right.register.uint16_3 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_4 = (int) left.register.uint16_4 < (int) right.register.uint16_4 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_5 = (int) left.register.uint16_5 < (int) right.register.uint16_5 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_6 = (int) left.register.uint16_6 < (int) right.register.uint16_6 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_7 = (int) left.register.uint16_7 < (int) right.register.uint16_7 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (short))
    {
      existingRegister.int16_0 = (int) left.register.int16_0 < (int) right.register.int16_0 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_1 = (int) left.register.int16_1 < (int) right.register.int16_1 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_2 = (int) left.register.int16_2 < (int) right.register.int16_2 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_3 = (int) left.register.int16_3 < (int) right.register.int16_3 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_4 = (int) left.register.int16_4 < (int) right.register.int16_4 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_5 = (int) left.register.int16_5 < (int) right.register.int16_5 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_6 = (int) left.register.int16_6 < (int) right.register.int16_6 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_7 = (int) left.register.int16_7 < (int) right.register.int16_7 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (uint))
    {
      existingRegister.uint32_0 = left.register.uint32_0 < right.register.uint32_0 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      existingRegister.uint32_1 = left.register.uint32_1 < right.register.uint32_1 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      existingRegister.uint32_2 = left.register.uint32_2 < right.register.uint32_2 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      existingRegister.uint32_3 = left.register.uint32_3 < right.register.uint32_3 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (int))
    {
      existingRegister.int32_0 = left.register.int32_0 < right.register.int32_0 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      existingRegister.int32_1 = left.register.int32_1 < right.register.int32_1 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      existingRegister.int32_2 = left.register.int32_2 < right.register.int32_2 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      existingRegister.int32_3 = left.register.int32_3 < right.register.int32_3 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (ulong))
    {
      existingRegister.uint64_0 = left.register.uint64_0 < right.register.uint64_0 ? ConstantHelper.GetUInt64WithAllBitsSet() : 0UL;
      existingRegister.uint64_1 = left.register.uint64_1 < right.register.uint64_1 ? ConstantHelper.GetUInt64WithAllBitsSet() : 0UL;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (long))
    {
      existingRegister.int64_0 = left.register.int64_0 < right.register.int64_0 ? ConstantHelper.GetInt64WithAllBitsSet() : 0L;
      existingRegister.int64_1 = left.register.int64_1 < right.register.int64_1 ? ConstantHelper.GetInt64WithAllBitsSet() : 0L;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (float))
    {
      existingRegister.single_0 = (double) left.register.single_0 < (double) right.register.single_0 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      existingRegister.single_1 = (double) left.register.single_1 < (double) right.register.single_1 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      existingRegister.single_2 = (double) left.register.single_2 < (double) right.register.single_2 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      existingRegister.single_3 = (double) left.register.single_3 < (double) right.register.single_3 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      return new Vector<T>(ref existingRegister);
    }
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    existingRegister.double_0 = left.register.double_0 < right.register.double_0 ? ConstantHelper.GetDoubleWithAllBitsSet() : 0.0;
    existingRegister.double_1 = left.register.double_1 < right.register.double_1 ? ConstantHelper.GetDoubleWithAllBitsSet() : 0.0;
    return new Vector<T>(ref existingRegister);
  }

  [Intrinsic]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static unsafe Vector<T> GreaterThan(Vector<T> left, Vector<T> right)
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        byte* dataPointer = stackalloc byte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ushort))
      {
        ushort* dataPointer = stackalloc ushort[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (uint))
      {
        uint* dataPointer = stackalloc uint[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ulong))
      {
        ulong* dataPointer = stackalloc ulong[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? ConstantHelper.GetUInt64WithAllBitsSet() : 0UL;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? ConstantHelper.GetInt64WithAllBitsSet() : 0L;
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? ConstantHelper.GetDoubleWithAllBitsSet() : 0.0;
      return new Vector<T>((void*) dataPointer1);
    }
    Register existingRegister = new Register();
    if (typeof (T) == typeof (byte))
    {
      existingRegister.byte_0 = (int) left.register.byte_0 > (int) right.register.byte_0 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_1 = (int) left.register.byte_1 > (int) right.register.byte_1 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_2 = (int) left.register.byte_2 > (int) right.register.byte_2 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_3 = (int) left.register.byte_3 > (int) right.register.byte_3 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_4 = (int) left.register.byte_4 > (int) right.register.byte_4 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_5 = (int) left.register.byte_5 > (int) right.register.byte_5 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_6 = (int) left.register.byte_6 > (int) right.register.byte_6 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_7 = (int) left.register.byte_7 > (int) right.register.byte_7 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_8 = (int) left.register.byte_8 > (int) right.register.byte_8 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_9 = (int) left.register.byte_9 > (int) right.register.byte_9 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_10 = (int) left.register.byte_10 > (int) right.register.byte_10 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_11 = (int) left.register.byte_11 > (int) right.register.byte_11 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_12 = (int) left.register.byte_12 > (int) right.register.byte_12 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_13 = (int) left.register.byte_13 > (int) right.register.byte_13 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_14 = (int) left.register.byte_14 > (int) right.register.byte_14 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      existingRegister.byte_15 = (int) left.register.byte_15 > (int) right.register.byte_15 ? ConstantHelper.GetByteWithAllBitsSet() : (byte) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (sbyte))
    {
      existingRegister.sbyte_0 = (int) left.register.sbyte_0 > (int) right.register.sbyte_0 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_1 = (int) left.register.sbyte_1 > (int) right.register.sbyte_1 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_2 = (int) left.register.sbyte_2 > (int) right.register.sbyte_2 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_3 = (int) left.register.sbyte_3 > (int) right.register.sbyte_3 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_4 = (int) left.register.sbyte_4 > (int) right.register.sbyte_4 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_5 = (int) left.register.sbyte_5 > (int) right.register.sbyte_5 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_6 = (int) left.register.sbyte_6 > (int) right.register.sbyte_6 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_7 = (int) left.register.sbyte_7 > (int) right.register.sbyte_7 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_8 = (int) left.register.sbyte_8 > (int) right.register.sbyte_8 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_9 = (int) left.register.sbyte_9 > (int) right.register.sbyte_9 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_10 = (int) left.register.sbyte_10 > (int) right.register.sbyte_10 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_11 = (int) left.register.sbyte_11 > (int) right.register.sbyte_11 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_12 = (int) left.register.sbyte_12 > (int) right.register.sbyte_12 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_13 = (int) left.register.sbyte_13 > (int) right.register.sbyte_13 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_14 = (int) left.register.sbyte_14 > (int) right.register.sbyte_14 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      existingRegister.sbyte_15 = (int) left.register.sbyte_15 > (int) right.register.sbyte_15 ? ConstantHelper.GetSByteWithAllBitsSet() : (sbyte) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (ushort))
    {
      existingRegister.uint16_0 = (int) left.register.uint16_0 > (int) right.register.uint16_0 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_1 = (int) left.register.uint16_1 > (int) right.register.uint16_1 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_2 = (int) left.register.uint16_2 > (int) right.register.uint16_2 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_3 = (int) left.register.uint16_3 > (int) right.register.uint16_3 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_4 = (int) left.register.uint16_4 > (int) right.register.uint16_4 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_5 = (int) left.register.uint16_5 > (int) right.register.uint16_5 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_6 = (int) left.register.uint16_6 > (int) right.register.uint16_6 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      existingRegister.uint16_7 = (int) left.register.uint16_7 > (int) right.register.uint16_7 ? ConstantHelper.GetUInt16WithAllBitsSet() : (ushort) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (short))
    {
      existingRegister.int16_0 = (int) left.register.int16_0 > (int) right.register.int16_0 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_1 = (int) left.register.int16_1 > (int) right.register.int16_1 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_2 = (int) left.register.int16_2 > (int) right.register.int16_2 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_3 = (int) left.register.int16_3 > (int) right.register.int16_3 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_4 = (int) left.register.int16_4 > (int) right.register.int16_4 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_5 = (int) left.register.int16_5 > (int) right.register.int16_5 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_6 = (int) left.register.int16_6 > (int) right.register.int16_6 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      existingRegister.int16_7 = (int) left.register.int16_7 > (int) right.register.int16_7 ? ConstantHelper.GetInt16WithAllBitsSet() : (short) 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (uint))
    {
      existingRegister.uint32_0 = left.register.uint32_0 > right.register.uint32_0 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      existingRegister.uint32_1 = left.register.uint32_1 > right.register.uint32_1 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      existingRegister.uint32_2 = left.register.uint32_2 > right.register.uint32_2 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      existingRegister.uint32_3 = left.register.uint32_3 > right.register.uint32_3 ? ConstantHelper.GetUInt32WithAllBitsSet() : 0U;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (int))
    {
      existingRegister.int32_0 = left.register.int32_0 > right.register.int32_0 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      existingRegister.int32_1 = left.register.int32_1 > right.register.int32_1 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      existingRegister.int32_2 = left.register.int32_2 > right.register.int32_2 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      existingRegister.int32_3 = left.register.int32_3 > right.register.int32_3 ? ConstantHelper.GetInt32WithAllBitsSet() : 0;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (ulong))
    {
      existingRegister.uint64_0 = left.register.uint64_0 > right.register.uint64_0 ? ConstantHelper.GetUInt64WithAllBitsSet() : 0UL;
      existingRegister.uint64_1 = left.register.uint64_1 > right.register.uint64_1 ? ConstantHelper.GetUInt64WithAllBitsSet() : 0UL;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (long))
    {
      existingRegister.int64_0 = left.register.int64_0 > right.register.int64_0 ? ConstantHelper.GetInt64WithAllBitsSet() : 0L;
      existingRegister.int64_1 = left.register.int64_1 > right.register.int64_1 ? ConstantHelper.GetInt64WithAllBitsSet() : 0L;
      return new Vector<T>(ref existingRegister);
    }
    if (typeof (T) == typeof (float))
    {
      existingRegister.single_0 = (double) left.register.single_0 > (double) right.register.single_0 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      existingRegister.single_1 = (double) left.register.single_1 > (double) right.register.single_1 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      existingRegister.single_2 = (double) left.register.single_2 > (double) right.register.single_2 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      existingRegister.single_3 = (double) left.register.single_3 > (double) right.register.single_3 ? ConstantHelper.GetSingleWithAllBitsSet() : 0.0f;
      return new Vector<T>(ref existingRegister);
    }
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    existingRegister.double_0 = left.register.double_0 > right.register.double_0 ? ConstantHelper.GetDoubleWithAllBitsSet() : 0.0;
    existingRegister.double_1 = left.register.double_1 > right.register.double_1 ? ConstantHelper.GetDoubleWithAllBitsSet() : 0.0;
    return new Vector<T>(ref existingRegister);
  }

  [Intrinsic]
  internal static Vector<T> GreaterThanOrEqual(Vector<T> left, Vector<T> right)
  {
    return Vector<T>.Equals(left, right) | Vector<T>.GreaterThan(left, right);
  }

  [Intrinsic]
  internal static Vector<T> LessThanOrEqual(Vector<T> left, Vector<T> right)
  {
    return Vector<T>.Equals(left, right) | Vector<T>.LessThan(left, right);
  }

  [Intrinsic]
  internal static Vector<T> ConditionalSelect(Vector<T> condition, Vector<T> left, Vector<T> right)
  {
    return left & condition | Vector.AndNot<T>(right, condition);
  }

  [Intrinsic]
  internal static unsafe Vector<T> Abs(Vector<T> value)
  {
    if (typeof (T) == typeof (byte) || typeof (T) == typeof (ushort) || typeof (T) == typeof (uint) || typeof (T) == typeof (ulong))
      return value;
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Math.Abs((sbyte) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Math.Abs((short) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Math.Abs((int) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Math.Abs((long) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Math.Abs((float) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = Math.Abs((double) (ValueType) value[index]);
      return new Vector<T>((void*) dataPointer1);
    }
    if (typeof (T) == typeof (sbyte))
    {
      value.register.sbyte_0 = Math.Abs(value.register.sbyte_0);
      value.register.sbyte_1 = Math.Abs(value.register.sbyte_1);
      value.register.sbyte_2 = Math.Abs(value.register.sbyte_2);
      value.register.sbyte_3 = Math.Abs(value.register.sbyte_3);
      value.register.sbyte_4 = Math.Abs(value.register.sbyte_4);
      value.register.sbyte_5 = Math.Abs(value.register.sbyte_5);
      value.register.sbyte_6 = Math.Abs(value.register.sbyte_6);
      value.register.sbyte_7 = Math.Abs(value.register.sbyte_7);
      value.register.sbyte_8 = Math.Abs(value.register.sbyte_8);
      value.register.sbyte_9 = Math.Abs(value.register.sbyte_9);
      value.register.sbyte_10 = Math.Abs(value.register.sbyte_10);
      value.register.sbyte_11 = Math.Abs(value.register.sbyte_11);
      value.register.sbyte_12 = Math.Abs(value.register.sbyte_12);
      value.register.sbyte_13 = Math.Abs(value.register.sbyte_13);
      value.register.sbyte_14 = Math.Abs(value.register.sbyte_14);
      value.register.sbyte_15 = Math.Abs(value.register.sbyte_15);
      return value;
    }
    if (typeof (T) == typeof (short))
    {
      value.register.int16_0 = Math.Abs(value.register.int16_0);
      value.register.int16_1 = Math.Abs(value.register.int16_1);
      value.register.int16_2 = Math.Abs(value.register.int16_2);
      value.register.int16_3 = Math.Abs(value.register.int16_3);
      value.register.int16_4 = Math.Abs(value.register.int16_4);
      value.register.int16_5 = Math.Abs(value.register.int16_5);
      value.register.int16_6 = Math.Abs(value.register.int16_6);
      value.register.int16_7 = Math.Abs(value.register.int16_7);
      return value;
    }
    if (typeof (T) == typeof (int))
    {
      value.register.int32_0 = Math.Abs(value.register.int32_0);
      value.register.int32_1 = Math.Abs(value.register.int32_1);
      value.register.int32_2 = Math.Abs(value.register.int32_2);
      value.register.int32_3 = Math.Abs(value.register.int32_3);
      return value;
    }
    if (typeof (T) == typeof (long))
    {
      value.register.int64_0 = Math.Abs(value.register.int64_0);
      value.register.int64_1 = Math.Abs(value.register.int64_1);
      return value;
    }
    if (typeof (T) == typeof (float))
    {
      value.register.single_0 = Math.Abs(value.register.single_0);
      value.register.single_1 = Math.Abs(value.register.single_1);
      value.register.single_2 = Math.Abs(value.register.single_2);
      value.register.single_3 = Math.Abs(value.register.single_3);
      return value;
    }
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    value.register.double_0 = Math.Abs(value.register.double_0);
    value.register.double_1 = Math.Abs(value.register.double_1);
    return value;
  }

  [Intrinsic]
  internal static unsafe Vector<T> Min(Vector<T> left, Vector<T> right)
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        byte* dataPointer = stackalloc byte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? (byte) (ValueType) left[index] : (byte) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? (sbyte) (ValueType) left[index] : (sbyte) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ushort))
      {
        ushort* dataPointer = stackalloc ushort[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? (ushort) (ValueType) left[index] : (ushort) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? (short) (ValueType) left[index] : (short) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (uint))
      {
        uint* dataPointer = stackalloc uint[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? (uint) (ValueType) left[index] : (uint) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? (int) (ValueType) left[index] : (int) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ulong))
      {
        ulong* dataPointer = stackalloc ulong[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? (ulong) (ValueType) left[index] : (ulong) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? (long) (ValueType) left[index] : (long) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? (float) (ValueType) left[index] : (float) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = Vector<T>.ScalarLessThan(left[index], right[index]) ? (double) (ValueType) left[index] : (double) (ValueType) right[index];
      return new Vector<T>((void*) dataPointer1);
    }
    Vector<T> vector = new Vector<T>();
    if (typeof (T) == typeof (byte))
    {
      vector.register.byte_0 = (int) left.register.byte_0 < (int) right.register.byte_0 ? left.register.byte_0 : right.register.byte_0;
      vector.register.byte_1 = (int) left.register.byte_1 < (int) right.register.byte_1 ? left.register.byte_1 : right.register.byte_1;
      vector.register.byte_2 = (int) left.register.byte_2 < (int) right.register.byte_2 ? left.register.byte_2 : right.register.byte_2;
      vector.register.byte_3 = (int) left.register.byte_3 < (int) right.register.byte_3 ? left.register.byte_3 : right.register.byte_3;
      vector.register.byte_4 = (int) left.register.byte_4 < (int) right.register.byte_4 ? left.register.byte_4 : right.register.byte_4;
      vector.register.byte_5 = (int) left.register.byte_5 < (int) right.register.byte_5 ? left.register.byte_5 : right.register.byte_5;
      vector.register.byte_6 = (int) left.register.byte_6 < (int) right.register.byte_6 ? left.register.byte_6 : right.register.byte_6;
      vector.register.byte_7 = (int) left.register.byte_7 < (int) right.register.byte_7 ? left.register.byte_7 : right.register.byte_7;
      vector.register.byte_8 = (int) left.register.byte_8 < (int) right.register.byte_8 ? left.register.byte_8 : right.register.byte_8;
      vector.register.byte_9 = (int) left.register.byte_9 < (int) right.register.byte_9 ? left.register.byte_9 : right.register.byte_9;
      vector.register.byte_10 = (int) left.register.byte_10 < (int) right.register.byte_10 ? left.register.byte_10 : right.register.byte_10;
      vector.register.byte_11 = (int) left.register.byte_11 < (int) right.register.byte_11 ? left.register.byte_11 : right.register.byte_11;
      vector.register.byte_12 = (int) left.register.byte_12 < (int) right.register.byte_12 ? left.register.byte_12 : right.register.byte_12;
      vector.register.byte_13 = (int) left.register.byte_13 < (int) right.register.byte_13 ? left.register.byte_13 : right.register.byte_13;
      vector.register.byte_14 = (int) left.register.byte_14 < (int) right.register.byte_14 ? left.register.byte_14 : right.register.byte_14;
      vector.register.byte_15 = (int) left.register.byte_15 < (int) right.register.byte_15 ? left.register.byte_15 : right.register.byte_15;
      return vector;
    }
    if (typeof (T) == typeof (sbyte))
    {
      vector.register.sbyte_0 = (int) left.register.sbyte_0 < (int) right.register.sbyte_0 ? left.register.sbyte_0 : right.register.sbyte_0;
      vector.register.sbyte_1 = (int) left.register.sbyte_1 < (int) right.register.sbyte_1 ? left.register.sbyte_1 : right.register.sbyte_1;
      vector.register.sbyte_2 = (int) left.register.sbyte_2 < (int) right.register.sbyte_2 ? left.register.sbyte_2 : right.register.sbyte_2;
      vector.register.sbyte_3 = (int) left.register.sbyte_3 < (int) right.register.sbyte_3 ? left.register.sbyte_3 : right.register.sbyte_3;
      vector.register.sbyte_4 = (int) left.register.sbyte_4 < (int) right.register.sbyte_4 ? left.register.sbyte_4 : right.register.sbyte_4;
      vector.register.sbyte_5 = (int) left.register.sbyte_5 < (int) right.register.sbyte_5 ? left.register.sbyte_5 : right.register.sbyte_5;
      vector.register.sbyte_6 = (int) left.register.sbyte_6 < (int) right.register.sbyte_6 ? left.register.sbyte_6 : right.register.sbyte_6;
      vector.register.sbyte_7 = (int) left.register.sbyte_7 < (int) right.register.sbyte_7 ? left.register.sbyte_7 : right.register.sbyte_7;
      vector.register.sbyte_8 = (int) left.register.sbyte_8 < (int) right.register.sbyte_8 ? left.register.sbyte_8 : right.register.sbyte_8;
      vector.register.sbyte_9 = (int) left.register.sbyte_9 < (int) right.register.sbyte_9 ? left.register.sbyte_9 : right.register.sbyte_9;
      vector.register.sbyte_10 = (int) left.register.sbyte_10 < (int) right.register.sbyte_10 ? left.register.sbyte_10 : right.register.sbyte_10;
      vector.register.sbyte_11 = (int) left.register.sbyte_11 < (int) right.register.sbyte_11 ? left.register.sbyte_11 : right.register.sbyte_11;
      vector.register.sbyte_12 = (int) left.register.sbyte_12 < (int) right.register.sbyte_12 ? left.register.sbyte_12 : right.register.sbyte_12;
      vector.register.sbyte_13 = (int) left.register.sbyte_13 < (int) right.register.sbyte_13 ? left.register.sbyte_13 : right.register.sbyte_13;
      vector.register.sbyte_14 = (int) left.register.sbyte_14 < (int) right.register.sbyte_14 ? left.register.sbyte_14 : right.register.sbyte_14;
      vector.register.sbyte_15 = (int) left.register.sbyte_15 < (int) right.register.sbyte_15 ? left.register.sbyte_15 : right.register.sbyte_15;
      return vector;
    }
    if (typeof (T) == typeof (ushort))
    {
      vector.register.uint16_0 = (int) left.register.uint16_0 < (int) right.register.uint16_0 ? left.register.uint16_0 : right.register.uint16_0;
      vector.register.uint16_1 = (int) left.register.uint16_1 < (int) right.register.uint16_1 ? left.register.uint16_1 : right.register.uint16_1;
      vector.register.uint16_2 = (int) left.register.uint16_2 < (int) right.register.uint16_2 ? left.register.uint16_2 : right.register.uint16_2;
      vector.register.uint16_3 = (int) left.register.uint16_3 < (int) right.register.uint16_3 ? left.register.uint16_3 : right.register.uint16_3;
      vector.register.uint16_4 = (int) left.register.uint16_4 < (int) right.register.uint16_4 ? left.register.uint16_4 : right.register.uint16_4;
      vector.register.uint16_5 = (int) left.register.uint16_5 < (int) right.register.uint16_5 ? left.register.uint16_5 : right.register.uint16_5;
      vector.register.uint16_6 = (int) left.register.uint16_6 < (int) right.register.uint16_6 ? left.register.uint16_6 : right.register.uint16_6;
      vector.register.uint16_7 = (int) left.register.uint16_7 < (int) right.register.uint16_7 ? left.register.uint16_7 : right.register.uint16_7;
      return vector;
    }
    if (typeof (T) == typeof (short))
    {
      vector.register.int16_0 = (int) left.register.int16_0 < (int) right.register.int16_0 ? left.register.int16_0 : right.register.int16_0;
      vector.register.int16_1 = (int) left.register.int16_1 < (int) right.register.int16_1 ? left.register.int16_1 : right.register.int16_1;
      vector.register.int16_2 = (int) left.register.int16_2 < (int) right.register.int16_2 ? left.register.int16_2 : right.register.int16_2;
      vector.register.int16_3 = (int) left.register.int16_3 < (int) right.register.int16_3 ? left.register.int16_3 : right.register.int16_3;
      vector.register.int16_4 = (int) left.register.int16_4 < (int) right.register.int16_4 ? left.register.int16_4 : right.register.int16_4;
      vector.register.int16_5 = (int) left.register.int16_5 < (int) right.register.int16_5 ? left.register.int16_5 : right.register.int16_5;
      vector.register.int16_6 = (int) left.register.int16_6 < (int) right.register.int16_6 ? left.register.int16_6 : right.register.int16_6;
      vector.register.int16_7 = (int) left.register.int16_7 < (int) right.register.int16_7 ? left.register.int16_7 : right.register.int16_7;
      return vector;
    }
    if (typeof (T) == typeof (uint))
    {
      vector.register.uint32_0 = left.register.uint32_0 < right.register.uint32_0 ? left.register.uint32_0 : right.register.uint32_0;
      vector.register.uint32_1 = left.register.uint32_1 < right.register.uint32_1 ? left.register.uint32_1 : right.register.uint32_1;
      vector.register.uint32_2 = left.register.uint32_2 < right.register.uint32_2 ? left.register.uint32_2 : right.register.uint32_2;
      vector.register.uint32_3 = left.register.uint32_3 < right.register.uint32_3 ? left.register.uint32_3 : right.register.uint32_3;
      return vector;
    }
    if (typeof (T) == typeof (int))
    {
      vector.register.int32_0 = left.register.int32_0 < right.register.int32_0 ? left.register.int32_0 : right.register.int32_0;
      vector.register.int32_1 = left.register.int32_1 < right.register.int32_1 ? left.register.int32_1 : right.register.int32_1;
      vector.register.int32_2 = left.register.int32_2 < right.register.int32_2 ? left.register.int32_2 : right.register.int32_2;
      vector.register.int32_3 = left.register.int32_3 < right.register.int32_3 ? left.register.int32_3 : right.register.int32_3;
      return vector;
    }
    if (typeof (T) == typeof (ulong))
    {
      vector.register.uint64_0 = left.register.uint64_0 < right.register.uint64_0 ? left.register.uint64_0 : right.register.uint64_0;
      vector.register.uint64_1 = left.register.uint64_1 < right.register.uint64_1 ? left.register.uint64_1 : right.register.uint64_1;
      return vector;
    }
    if (typeof (T) == typeof (long))
    {
      vector.register.int64_0 = left.register.int64_0 < right.register.int64_0 ? left.register.int64_0 : right.register.int64_0;
      vector.register.int64_1 = left.register.int64_1 < right.register.int64_1 ? left.register.int64_1 : right.register.int64_1;
      return vector;
    }
    if (typeof (T) == typeof (float))
    {
      vector.register.single_0 = (double) left.register.single_0 < (double) right.register.single_0 ? left.register.single_0 : right.register.single_0;
      vector.register.single_1 = (double) left.register.single_1 < (double) right.register.single_1 ? left.register.single_1 : right.register.single_1;
      vector.register.single_2 = (double) left.register.single_2 < (double) right.register.single_2 ? left.register.single_2 : right.register.single_2;
      vector.register.single_3 = (double) left.register.single_3 < (double) right.register.single_3 ? left.register.single_3 : right.register.single_3;
      return vector;
    }
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    vector.register.double_0 = left.register.double_0 < right.register.double_0 ? left.register.double_0 : right.register.double_0;
    vector.register.double_1 = left.register.double_1 < right.register.double_1 ? left.register.double_1 : right.register.double_1;
    return vector;
  }

  [Intrinsic]
  internal static unsafe Vector<T> Max(Vector<T> left, Vector<T> right)
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        byte* dataPointer = stackalloc byte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? (byte) (ValueType) left[index] : (byte) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? (sbyte) (ValueType) left[index] : (sbyte) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ushort))
      {
        ushort* dataPointer = stackalloc ushort[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? (ushort) (ValueType) left[index] : (ushort) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? (short) (ValueType) left[index] : (short) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (uint))
      {
        uint* dataPointer = stackalloc uint[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? (uint) (ValueType) left[index] : (uint) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? (int) (ValueType) left[index] : (int) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ulong))
      {
        ulong* dataPointer = stackalloc ulong[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? (ulong) (ValueType) left[index] : (ulong) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? (long) (ValueType) left[index] : (long) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? (float) (ValueType) left[index] : (float) (ValueType) right[index];
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = Vector<T>.ScalarGreaterThan(left[index], right[index]) ? (double) (ValueType) left[index] : (double) (ValueType) right[index];
      return new Vector<T>((void*) dataPointer1);
    }
    Vector<T> vector = new Vector<T>();
    if (typeof (T) == typeof (byte))
    {
      vector.register.byte_0 = (int) left.register.byte_0 > (int) right.register.byte_0 ? left.register.byte_0 : right.register.byte_0;
      vector.register.byte_1 = (int) left.register.byte_1 > (int) right.register.byte_1 ? left.register.byte_1 : right.register.byte_1;
      vector.register.byte_2 = (int) left.register.byte_2 > (int) right.register.byte_2 ? left.register.byte_2 : right.register.byte_2;
      vector.register.byte_3 = (int) left.register.byte_3 > (int) right.register.byte_3 ? left.register.byte_3 : right.register.byte_3;
      vector.register.byte_4 = (int) left.register.byte_4 > (int) right.register.byte_4 ? left.register.byte_4 : right.register.byte_4;
      vector.register.byte_5 = (int) left.register.byte_5 > (int) right.register.byte_5 ? left.register.byte_5 : right.register.byte_5;
      vector.register.byte_6 = (int) left.register.byte_6 > (int) right.register.byte_6 ? left.register.byte_6 : right.register.byte_6;
      vector.register.byte_7 = (int) left.register.byte_7 > (int) right.register.byte_7 ? left.register.byte_7 : right.register.byte_7;
      vector.register.byte_8 = (int) left.register.byte_8 > (int) right.register.byte_8 ? left.register.byte_8 : right.register.byte_8;
      vector.register.byte_9 = (int) left.register.byte_9 > (int) right.register.byte_9 ? left.register.byte_9 : right.register.byte_9;
      vector.register.byte_10 = (int) left.register.byte_10 > (int) right.register.byte_10 ? left.register.byte_10 : right.register.byte_10;
      vector.register.byte_11 = (int) left.register.byte_11 > (int) right.register.byte_11 ? left.register.byte_11 : right.register.byte_11;
      vector.register.byte_12 = (int) left.register.byte_12 > (int) right.register.byte_12 ? left.register.byte_12 : right.register.byte_12;
      vector.register.byte_13 = (int) left.register.byte_13 > (int) right.register.byte_13 ? left.register.byte_13 : right.register.byte_13;
      vector.register.byte_14 = (int) left.register.byte_14 > (int) right.register.byte_14 ? left.register.byte_14 : right.register.byte_14;
      vector.register.byte_15 = (int) left.register.byte_15 > (int) right.register.byte_15 ? left.register.byte_15 : right.register.byte_15;
      return vector;
    }
    if (typeof (T) == typeof (sbyte))
    {
      vector.register.sbyte_0 = (int) left.register.sbyte_0 > (int) right.register.sbyte_0 ? left.register.sbyte_0 : right.register.sbyte_0;
      vector.register.sbyte_1 = (int) left.register.sbyte_1 > (int) right.register.sbyte_1 ? left.register.sbyte_1 : right.register.sbyte_1;
      vector.register.sbyte_2 = (int) left.register.sbyte_2 > (int) right.register.sbyte_2 ? left.register.sbyte_2 : right.register.sbyte_2;
      vector.register.sbyte_3 = (int) left.register.sbyte_3 > (int) right.register.sbyte_3 ? left.register.sbyte_3 : right.register.sbyte_3;
      vector.register.sbyte_4 = (int) left.register.sbyte_4 > (int) right.register.sbyte_4 ? left.register.sbyte_4 : right.register.sbyte_4;
      vector.register.sbyte_5 = (int) left.register.sbyte_5 > (int) right.register.sbyte_5 ? left.register.sbyte_5 : right.register.sbyte_5;
      vector.register.sbyte_6 = (int) left.register.sbyte_6 > (int) right.register.sbyte_6 ? left.register.sbyte_6 : right.register.sbyte_6;
      vector.register.sbyte_7 = (int) left.register.sbyte_7 > (int) right.register.sbyte_7 ? left.register.sbyte_7 : right.register.sbyte_7;
      vector.register.sbyte_8 = (int) left.register.sbyte_8 > (int) right.register.sbyte_8 ? left.register.sbyte_8 : right.register.sbyte_8;
      vector.register.sbyte_9 = (int) left.register.sbyte_9 > (int) right.register.sbyte_9 ? left.register.sbyte_9 : right.register.sbyte_9;
      vector.register.sbyte_10 = (int) left.register.sbyte_10 > (int) right.register.sbyte_10 ? left.register.sbyte_10 : right.register.sbyte_10;
      vector.register.sbyte_11 = (int) left.register.sbyte_11 > (int) right.register.sbyte_11 ? left.register.sbyte_11 : right.register.sbyte_11;
      vector.register.sbyte_12 = (int) left.register.sbyte_12 > (int) right.register.sbyte_12 ? left.register.sbyte_12 : right.register.sbyte_12;
      vector.register.sbyte_13 = (int) left.register.sbyte_13 > (int) right.register.sbyte_13 ? left.register.sbyte_13 : right.register.sbyte_13;
      vector.register.sbyte_14 = (int) left.register.sbyte_14 > (int) right.register.sbyte_14 ? left.register.sbyte_14 : right.register.sbyte_14;
      vector.register.sbyte_15 = (int) left.register.sbyte_15 > (int) right.register.sbyte_15 ? left.register.sbyte_15 : right.register.sbyte_15;
      return vector;
    }
    if (typeof (T) == typeof (ushort))
    {
      vector.register.uint16_0 = (int) left.register.uint16_0 > (int) right.register.uint16_0 ? left.register.uint16_0 : right.register.uint16_0;
      vector.register.uint16_1 = (int) left.register.uint16_1 > (int) right.register.uint16_1 ? left.register.uint16_1 : right.register.uint16_1;
      vector.register.uint16_2 = (int) left.register.uint16_2 > (int) right.register.uint16_2 ? left.register.uint16_2 : right.register.uint16_2;
      vector.register.uint16_3 = (int) left.register.uint16_3 > (int) right.register.uint16_3 ? left.register.uint16_3 : right.register.uint16_3;
      vector.register.uint16_4 = (int) left.register.uint16_4 > (int) right.register.uint16_4 ? left.register.uint16_4 : right.register.uint16_4;
      vector.register.uint16_5 = (int) left.register.uint16_5 > (int) right.register.uint16_5 ? left.register.uint16_5 : right.register.uint16_5;
      vector.register.uint16_6 = (int) left.register.uint16_6 > (int) right.register.uint16_6 ? left.register.uint16_6 : right.register.uint16_6;
      vector.register.uint16_7 = (int) left.register.uint16_7 > (int) right.register.uint16_7 ? left.register.uint16_7 : right.register.uint16_7;
      return vector;
    }
    if (typeof (T) == typeof (short))
    {
      vector.register.int16_0 = (int) left.register.int16_0 > (int) right.register.int16_0 ? left.register.int16_0 : right.register.int16_0;
      vector.register.int16_1 = (int) left.register.int16_1 > (int) right.register.int16_1 ? left.register.int16_1 : right.register.int16_1;
      vector.register.int16_2 = (int) left.register.int16_2 > (int) right.register.int16_2 ? left.register.int16_2 : right.register.int16_2;
      vector.register.int16_3 = (int) left.register.int16_3 > (int) right.register.int16_3 ? left.register.int16_3 : right.register.int16_3;
      vector.register.int16_4 = (int) left.register.int16_4 > (int) right.register.int16_4 ? left.register.int16_4 : right.register.int16_4;
      vector.register.int16_5 = (int) left.register.int16_5 > (int) right.register.int16_5 ? left.register.int16_5 : right.register.int16_5;
      vector.register.int16_6 = (int) left.register.int16_6 > (int) right.register.int16_6 ? left.register.int16_6 : right.register.int16_6;
      vector.register.int16_7 = (int) left.register.int16_7 > (int) right.register.int16_7 ? left.register.int16_7 : right.register.int16_7;
      return vector;
    }
    if (typeof (T) == typeof (uint))
    {
      vector.register.uint32_0 = left.register.uint32_0 > right.register.uint32_0 ? left.register.uint32_0 : right.register.uint32_0;
      vector.register.uint32_1 = left.register.uint32_1 > right.register.uint32_1 ? left.register.uint32_1 : right.register.uint32_1;
      vector.register.uint32_2 = left.register.uint32_2 > right.register.uint32_2 ? left.register.uint32_2 : right.register.uint32_2;
      vector.register.uint32_3 = left.register.uint32_3 > right.register.uint32_3 ? left.register.uint32_3 : right.register.uint32_3;
      return vector;
    }
    if (typeof (T) == typeof (int))
    {
      vector.register.int32_0 = left.register.int32_0 > right.register.int32_0 ? left.register.int32_0 : right.register.int32_0;
      vector.register.int32_1 = left.register.int32_1 > right.register.int32_1 ? left.register.int32_1 : right.register.int32_1;
      vector.register.int32_2 = left.register.int32_2 > right.register.int32_2 ? left.register.int32_2 : right.register.int32_2;
      vector.register.int32_3 = left.register.int32_3 > right.register.int32_3 ? left.register.int32_3 : right.register.int32_3;
      return vector;
    }
    if (typeof (T) == typeof (ulong))
    {
      vector.register.uint64_0 = left.register.uint64_0 > right.register.uint64_0 ? left.register.uint64_0 : right.register.uint64_0;
      vector.register.uint64_1 = left.register.uint64_1 > right.register.uint64_1 ? left.register.uint64_1 : right.register.uint64_1;
      return vector;
    }
    if (typeof (T) == typeof (long))
    {
      vector.register.int64_0 = left.register.int64_0 > right.register.int64_0 ? left.register.int64_0 : right.register.int64_0;
      vector.register.int64_1 = left.register.int64_1 > right.register.int64_1 ? left.register.int64_1 : right.register.int64_1;
      return vector;
    }
    if (typeof (T) == typeof (float))
    {
      vector.register.single_0 = (double) left.register.single_0 > (double) right.register.single_0 ? left.register.single_0 : right.register.single_0;
      vector.register.single_1 = (double) left.register.single_1 > (double) right.register.single_1 ? left.register.single_1 : right.register.single_1;
      vector.register.single_2 = (double) left.register.single_2 > (double) right.register.single_2 ? left.register.single_2 : right.register.single_2;
      vector.register.single_3 = (double) left.register.single_3 > (double) right.register.single_3 ? left.register.single_3 : right.register.single_3;
      return vector;
    }
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    vector.register.double_0 = left.register.double_0 > right.register.double_0 ? left.register.double_0 : right.register.double_0;
    vector.register.double_1 = left.register.double_1 > right.register.double_1 ? left.register.double_1 : right.register.double_1;
    return vector;
  }

  [Intrinsic]
  internal static T DotProduct(Vector<T> left, Vector<T> right)
  {
    if (Vector.IsHardwareAccelerated)
    {
      T left1 = default (T);
      for (int index = 0; index < Vector<T>.Count; ++index)
        left1 = Vector<T>.ScalarAdd(left1, Vector<T>.ScalarMultiply(left[index], right[index]));
      return left1;
    }
    if (typeof (T) == typeof (byte))
      return (T) (ValueType) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) (0U + (uint) (byte) ((uint) left.register.byte_0 * (uint) right.register.byte_0)) + (uint) (byte) ((uint) left.register.byte_1 * (uint) right.register.byte_1)) + (uint) (byte) ((uint) left.register.byte_2 * (uint) right.register.byte_2)) + (uint) (byte) ((uint) left.register.byte_3 * (uint) right.register.byte_3)) + (uint) (byte) ((uint) left.register.byte_4 * (uint) right.register.byte_4)) + (uint) (byte) ((uint) left.register.byte_5 * (uint) right.register.byte_5)) + (uint) (byte) ((uint) left.register.byte_6 * (uint) right.register.byte_6)) + (uint) (byte) ((uint) left.register.byte_7 * (uint) right.register.byte_7)) + (uint) (byte) ((uint) left.register.byte_8 * (uint) right.register.byte_8)) + (uint) (byte) ((uint) left.register.byte_9 * (uint) right.register.byte_9)) + (uint) (byte) ((uint) left.register.byte_10 * (uint) right.register.byte_10)) + (uint) (byte) ((uint) left.register.byte_11 * (uint) right.register.byte_11)) + (uint) (byte) ((uint) left.register.byte_12 * (uint) right.register.byte_12)) + (uint) (byte) ((uint) left.register.byte_13 * (uint) right.register.byte_13)) + (uint) (byte) ((uint) left.register.byte_14 * (uint) right.register.byte_14)) + (uint) (byte) ((uint) left.register.byte_15 * (uint) right.register.byte_15));
    if (typeof (T) == typeof (sbyte))
      return (T) (ValueType) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) ((int) (sbyte) (0 + (int) (sbyte) ((int) left.register.sbyte_0 * (int) right.register.sbyte_0)) + (int) (sbyte) ((int) left.register.sbyte_1 * (int) right.register.sbyte_1)) + (int) (sbyte) ((int) left.register.sbyte_2 * (int) right.register.sbyte_2)) + (int) (sbyte) ((int) left.register.sbyte_3 * (int) right.register.sbyte_3)) + (int) (sbyte) ((int) left.register.sbyte_4 * (int) right.register.sbyte_4)) + (int) (sbyte) ((int) left.register.sbyte_5 * (int) right.register.sbyte_5)) + (int) (sbyte) ((int) left.register.sbyte_6 * (int) right.register.sbyte_6)) + (int) (sbyte) ((int) left.register.sbyte_7 * (int) right.register.sbyte_7)) + (int) (sbyte) ((int) left.register.sbyte_8 * (int) right.register.sbyte_8)) + (int) (sbyte) ((int) left.register.sbyte_9 * (int) right.register.sbyte_9)) + (int) (sbyte) ((int) left.register.sbyte_10 * (int) right.register.sbyte_10)) + (int) (sbyte) ((int) left.register.sbyte_11 * (int) right.register.sbyte_11)) + (int) (sbyte) ((int) left.register.sbyte_12 * (int) right.register.sbyte_12)) + (int) (sbyte) ((int) left.register.sbyte_13 * (int) right.register.sbyte_13)) + (int) (sbyte) ((int) left.register.sbyte_14 * (int) right.register.sbyte_14)) + (int) (sbyte) ((int) left.register.sbyte_15 * (int) right.register.sbyte_15));
    if (typeof (T) == typeof (ushort))
      return (T) (ValueType) (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) (0U + (uint) (ushort) ((uint) left.register.uint16_0 * (uint) right.register.uint16_0)) + (uint) (ushort) ((uint) left.register.uint16_1 * (uint) right.register.uint16_1)) + (uint) (ushort) ((uint) left.register.uint16_2 * (uint) right.register.uint16_2)) + (uint) (ushort) ((uint) left.register.uint16_3 * (uint) right.register.uint16_3)) + (uint) (ushort) ((uint) left.register.uint16_4 * (uint) right.register.uint16_4)) + (uint) (ushort) ((uint) left.register.uint16_5 * (uint) right.register.uint16_5)) + (uint) (ushort) ((uint) left.register.uint16_6 * (uint) right.register.uint16_6)) + (uint) (ushort) ((uint) left.register.uint16_7 * (uint) right.register.uint16_7));
    if (typeof (T) == typeof (short))
      return (T) (ValueType) (short) ((int) (short) ((int) (short) ((int) (short) ((int) (short) ((int) (short) ((int) (short) ((int) (short) (0 + (int) (short) ((int) left.register.int16_0 * (int) right.register.int16_0)) + (int) (short) ((int) left.register.int16_1 * (int) right.register.int16_1)) + (int) (short) ((int) left.register.int16_2 * (int) right.register.int16_2)) + (int) (short) ((int) left.register.int16_3 * (int) right.register.int16_3)) + (int) (short) ((int) left.register.int16_4 * (int) right.register.int16_4)) + (int) (short) ((int) left.register.int16_5 * (int) right.register.int16_5)) + (int) (short) ((int) left.register.int16_6 * (int) right.register.int16_6)) + (int) (short) ((int) left.register.int16_7 * (int) right.register.int16_7));
    if (typeof (T) == typeof (uint))
      return (T) (ValueType) ((uint) (0 + (int) left.register.uint32_0 * (int) right.register.uint32_0) + left.register.uint32_1 * right.register.uint32_1 + left.register.uint32_2 * right.register.uint32_2 + left.register.uint32_3 * right.register.uint32_3);
    if (typeof (T) == typeof (int))
      return (T) (ValueType) (0 + left.register.int32_0 * right.register.int32_0 + left.register.int32_1 * right.register.int32_1 + left.register.int32_2 * right.register.int32_2 + left.register.int32_3 * right.register.int32_3);
    if (typeof (T) == typeof (ulong))
      return (T) (ValueType) ((ulong) (0L + (long) left.register.uint64_0 * (long) right.register.uint64_0) + left.register.uint64_1 * right.register.uint64_1);
    if (typeof (T) == typeof (long))
      return (T) (ValueType) (0L + left.register.int64_0 * right.register.int64_0 + left.register.int64_1 * right.register.int64_1);
    if (typeof (T) == typeof (float))
      return (T) (ValueType) (0.0f + left.register.single_0 * right.register.single_0 + left.register.single_1 * right.register.single_1 + left.register.single_2 * right.register.single_2 + left.register.single_3 * right.register.single_3);
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return (T) (ValueType) (0.0 + left.register.double_0 * right.register.double_0 + left.register.double_1 * right.register.double_1);
  }

  [Intrinsic]
  internal static unsafe Vector<T> SquareRoot(Vector<T> value)
  {
    if (Vector.IsHardwareAccelerated)
    {
      if (typeof (T) == typeof (byte))
      {
        byte* dataPointer = stackalloc byte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (byte) Math.Sqrt((double) (byte) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (sbyte))
      {
        sbyte* dataPointer = stackalloc sbyte[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (sbyte) Math.Sqrt((double) (sbyte) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ushort))
      {
        ushort* dataPointer = stackalloc ushort[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (ushort) Math.Sqrt((double) (ushort) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (short))
      {
        short* dataPointer = stackalloc short[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (short) Math.Sqrt((double) (short) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (uint))
      {
        uint* dataPointer = stackalloc uint[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (uint) Math.Sqrt((double) (uint) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (int))
      {
        int* dataPointer = stackalloc int[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (int) Math.Sqrt((double) (int) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (ulong))
      {
        ulong* dataPointer = stackalloc ulong[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (ulong) Math.Sqrt((double) (ulong) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (long))
      {
        long* dataPointer = stackalloc long[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (long) Math.Sqrt((double) (long) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (typeof (T) == typeof (float))
      {
        float* dataPointer = stackalloc float[Vector<T>.Count];
        for (int index = 0; index < Vector<T>.Count; ++index)
          dataPointer[index] = (float) Math.Sqrt((double) (float) (ValueType) value[index]);
        return new Vector<T>((void*) dataPointer);
      }
      if (!(typeof (T) == typeof (double)))
        throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
      double* dataPointer1 = stackalloc double[Vector<T>.Count];
      for (int index = 0; index < Vector<T>.Count; ++index)
        dataPointer1[index] = Math.Sqrt((double) (ValueType) value[index]);
      return new Vector<T>((void*) dataPointer1);
    }
    if (typeof (T) == typeof (byte))
    {
      value.register.byte_0 = (byte) Math.Sqrt((double) value.register.byte_0);
      value.register.byte_1 = (byte) Math.Sqrt((double) value.register.byte_1);
      value.register.byte_2 = (byte) Math.Sqrt((double) value.register.byte_2);
      value.register.byte_3 = (byte) Math.Sqrt((double) value.register.byte_3);
      value.register.byte_4 = (byte) Math.Sqrt((double) value.register.byte_4);
      value.register.byte_5 = (byte) Math.Sqrt((double) value.register.byte_5);
      value.register.byte_6 = (byte) Math.Sqrt((double) value.register.byte_6);
      value.register.byte_7 = (byte) Math.Sqrt((double) value.register.byte_7);
      value.register.byte_8 = (byte) Math.Sqrt((double) value.register.byte_8);
      value.register.byte_9 = (byte) Math.Sqrt((double) value.register.byte_9);
      value.register.byte_10 = (byte) Math.Sqrt((double) value.register.byte_10);
      value.register.byte_11 = (byte) Math.Sqrt((double) value.register.byte_11);
      value.register.byte_12 = (byte) Math.Sqrt((double) value.register.byte_12);
      value.register.byte_13 = (byte) Math.Sqrt((double) value.register.byte_13);
      value.register.byte_14 = (byte) Math.Sqrt((double) value.register.byte_14);
      value.register.byte_15 = (byte) Math.Sqrt((double) value.register.byte_15);
      return value;
    }
    if (typeof (T) == typeof (sbyte))
    {
      value.register.sbyte_0 = (sbyte) Math.Sqrt((double) value.register.sbyte_0);
      value.register.sbyte_1 = (sbyte) Math.Sqrt((double) value.register.sbyte_1);
      value.register.sbyte_2 = (sbyte) Math.Sqrt((double) value.register.sbyte_2);
      value.register.sbyte_3 = (sbyte) Math.Sqrt((double) value.register.sbyte_3);
      value.register.sbyte_4 = (sbyte) Math.Sqrt((double) value.register.sbyte_4);
      value.register.sbyte_5 = (sbyte) Math.Sqrt((double) value.register.sbyte_5);
      value.register.sbyte_6 = (sbyte) Math.Sqrt((double) value.register.sbyte_6);
      value.register.sbyte_7 = (sbyte) Math.Sqrt((double) value.register.sbyte_7);
      value.register.sbyte_8 = (sbyte) Math.Sqrt((double) value.register.sbyte_8);
      value.register.sbyte_9 = (sbyte) Math.Sqrt((double) value.register.sbyte_9);
      value.register.sbyte_10 = (sbyte) Math.Sqrt((double) value.register.sbyte_10);
      value.register.sbyte_11 = (sbyte) Math.Sqrt((double) value.register.sbyte_11);
      value.register.sbyte_12 = (sbyte) Math.Sqrt((double) value.register.sbyte_12);
      value.register.sbyte_13 = (sbyte) Math.Sqrt((double) value.register.sbyte_13);
      value.register.sbyte_14 = (sbyte) Math.Sqrt((double) value.register.sbyte_14);
      value.register.sbyte_15 = (sbyte) Math.Sqrt((double) value.register.sbyte_15);
      return value;
    }
    if (typeof (T) == typeof (ushort))
    {
      value.register.uint16_0 = (ushort) Math.Sqrt((double) value.register.uint16_0);
      value.register.uint16_1 = (ushort) Math.Sqrt((double) value.register.uint16_1);
      value.register.uint16_2 = (ushort) Math.Sqrt((double) value.register.uint16_2);
      value.register.uint16_3 = (ushort) Math.Sqrt((double) value.register.uint16_3);
      value.register.uint16_4 = (ushort) Math.Sqrt((double) value.register.uint16_4);
      value.register.uint16_5 = (ushort) Math.Sqrt((double) value.register.uint16_5);
      value.register.uint16_6 = (ushort) Math.Sqrt((double) value.register.uint16_6);
      value.register.uint16_7 = (ushort) Math.Sqrt((double) value.register.uint16_7);
      return value;
    }
    if (typeof (T) == typeof (short))
    {
      value.register.int16_0 = (short) Math.Sqrt((double) value.register.int16_0);
      value.register.int16_1 = (short) Math.Sqrt((double) value.register.int16_1);
      value.register.int16_2 = (short) Math.Sqrt((double) value.register.int16_2);
      value.register.int16_3 = (short) Math.Sqrt((double) value.register.int16_3);
      value.register.int16_4 = (short) Math.Sqrt((double) value.register.int16_4);
      value.register.int16_5 = (short) Math.Sqrt((double) value.register.int16_5);
      value.register.int16_6 = (short) Math.Sqrt((double) value.register.int16_6);
      value.register.int16_7 = (short) Math.Sqrt((double) value.register.int16_7);
      return value;
    }
    if (typeof (T) == typeof (uint))
    {
      value.register.uint32_0 = (uint) Math.Sqrt((double) value.register.uint32_0);
      value.register.uint32_1 = (uint) Math.Sqrt((double) value.register.uint32_1);
      value.register.uint32_2 = (uint) Math.Sqrt((double) value.register.uint32_2);
      value.register.uint32_3 = (uint) Math.Sqrt((double) value.register.uint32_3);
      return value;
    }
    if (typeof (T) == typeof (int))
    {
      value.register.int32_0 = (int) Math.Sqrt((double) value.register.int32_0);
      value.register.int32_1 = (int) Math.Sqrt((double) value.register.int32_1);
      value.register.int32_2 = (int) Math.Sqrt((double) value.register.int32_2);
      value.register.int32_3 = (int) Math.Sqrt((double) value.register.int32_3);
      return value;
    }
    if (typeof (T) == typeof (ulong))
    {
      value.register.uint64_0 = (ulong) Math.Sqrt((double) value.register.uint64_0);
      value.register.uint64_1 = (ulong) Math.Sqrt((double) value.register.uint64_1);
      return value;
    }
    if (typeof (T) == typeof (long))
    {
      value.register.int64_0 = (long) Math.Sqrt((double) value.register.int64_0);
      value.register.int64_1 = (long) Math.Sqrt((double) value.register.int64_1);
      return value;
    }
    if (typeof (T) == typeof (float))
    {
      value.register.single_0 = (float) Math.Sqrt((double) value.register.single_0);
      value.register.single_1 = (float) Math.Sqrt((double) value.register.single_1);
      value.register.single_2 = (float) Math.Sqrt((double) value.register.single_2);
      value.register.single_3 = (float) Math.Sqrt((double) value.register.single_3);
      return value;
    }
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    value.register.double_0 = Math.Sqrt(value.register.double_0);
    value.register.double_1 = Math.Sqrt(value.register.double_1);
    return value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool ScalarEquals(T left, T right)
  {
    if (typeof (T) == typeof (byte))
      return (int) (byte) (ValueType) left == (int) (byte) (ValueType) right;
    if (typeof (T) == typeof (sbyte))
      return (int) (sbyte) (ValueType) left == (int) (sbyte) (ValueType) right;
    if (typeof (T) == typeof (ushort))
      return (int) (ushort) (ValueType) left == (int) (ushort) (ValueType) right;
    if (typeof (T) == typeof (short))
      return (int) (short) (ValueType) left == (int) (short) (ValueType) right;
    if (typeof (T) == typeof (uint))
      return (int) (uint) (ValueType) left == (int) (uint) (ValueType) right;
    if (typeof (T) == typeof (int))
      return (int) (ValueType) left == (int) (ValueType) right;
    if (typeof (T) == typeof (ulong))
      return (long) (ulong) (ValueType) left == (long) (ulong) (ValueType) right;
    if (typeof (T) == typeof (long))
      return (long) (ValueType) left == (long) (ValueType) right;
    if (typeof (T) == typeof (float))
      return (double) (float) (ValueType) left == (double) (float) (ValueType) right;
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return (double) (ValueType) left == (double) (ValueType) right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool ScalarLessThan(T left, T right)
  {
    if (typeof (T) == typeof (byte))
      return (int) (byte) (ValueType) left < (int) (byte) (ValueType) right;
    if (typeof (T) == typeof (sbyte))
      return (int) (sbyte) (ValueType) left < (int) (sbyte) (ValueType) right;
    if (typeof (T) == typeof (ushort))
      return (int) (ushort) (ValueType) left < (int) (ushort) (ValueType) right;
    if (typeof (T) == typeof (short))
      return (int) (short) (ValueType) left < (int) (short) (ValueType) right;
    if (typeof (T) == typeof (uint))
      return (uint) (ValueType) left < (uint) (ValueType) right;
    if (typeof (T) == typeof (int))
      return (int) (ValueType) left < (int) (ValueType) right;
    if (typeof (T) == typeof (ulong))
      return (ulong) (ValueType) left < (ulong) (ValueType) right;
    if (typeof (T) == typeof (long))
      return (long) (ValueType) left < (long) (ValueType) right;
    if (typeof (T) == typeof (float))
      return (double) (float) (ValueType) left < (double) (float) (ValueType) right;
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return (double) (ValueType) left < (double) (ValueType) right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool ScalarGreaterThan(T left, T right)
  {
    if (typeof (T) == typeof (byte))
      return (int) (byte) (ValueType) left > (int) (byte) (ValueType) right;
    if (typeof (T) == typeof (sbyte))
      return (int) (sbyte) (ValueType) left > (int) (sbyte) (ValueType) right;
    if (typeof (T) == typeof (ushort))
      return (int) (ushort) (ValueType) left > (int) (ushort) (ValueType) right;
    if (typeof (T) == typeof (short))
      return (int) (short) (ValueType) left > (int) (short) (ValueType) right;
    if (typeof (T) == typeof (uint))
      return (uint) (ValueType) left > (uint) (ValueType) right;
    if (typeof (T) == typeof (int))
      return (int) (ValueType) left > (int) (ValueType) right;
    if (typeof (T) == typeof (ulong))
      return (ulong) (ValueType) left > (ulong) (ValueType) right;
    if (typeof (T) == typeof (long))
      return (long) (ValueType) left > (long) (ValueType) right;
    if (typeof (T) == typeof (float))
      return (double) (float) (ValueType) left > (double) (float) (ValueType) right;
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return (double) (ValueType) left > (double) (ValueType) right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static T ScalarAdd(T left, T right)
  {
    if (typeof (T) == typeof (byte))
      return (T) (ValueType) (byte) ((uint) (byte) (ValueType) left + (uint) (byte) (ValueType) right);
    if (typeof (T) == typeof (sbyte))
      return (T) (ValueType) (sbyte) ((int) (sbyte) (ValueType) left + (int) (sbyte) (ValueType) right);
    if (typeof (T) == typeof (ushort))
      return (T) (ValueType) (ushort) ((uint) (ushort) (ValueType) left + (uint) (ushort) (ValueType) right);
    if (typeof (T) == typeof (short))
      return (T) (ValueType) (short) ((int) (short) (ValueType) left + (int) (short) (ValueType) right);
    if (typeof (T) == typeof (uint))
      return (T) (ValueType) (uint) ((int) (uint) (ValueType) left + (int) (uint) (ValueType) right);
    if (typeof (T) == typeof (int))
      return (T) (ValueType) ((int) (ValueType) left + (int) (ValueType) right);
    if (typeof (T) == typeof (ulong))
      return (T) (ValueType) (ulong) ((long) (ulong) (ValueType) left + (long) (ulong) (ValueType) right);
    if (typeof (T) == typeof (long))
      return (T) (ValueType) ((long) (ValueType) left + (long) (ValueType) right);
    if (typeof (T) == typeof (float))
      return (T) (ValueType) ((float) (ValueType) left + (float) (ValueType) right);
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return (T) (ValueType) ((double) (ValueType) left + (double) (ValueType) right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static T ScalarSubtract(T left, T right)
  {
    if (typeof (T) == typeof (byte))
      return (T) (ValueType) (byte) ((uint) (byte) (ValueType) left - (uint) (byte) (ValueType) right);
    if (typeof (T) == typeof (sbyte))
      return (T) (ValueType) (sbyte) ((int) (sbyte) (ValueType) left - (int) (sbyte) (ValueType) right);
    if (typeof (T) == typeof (ushort))
      return (T) (ValueType) (ushort) ((uint) (ushort) (ValueType) left - (uint) (ushort) (ValueType) right);
    if (typeof (T) == typeof (short))
      return (T) (ValueType) (short) ((int) (short) (ValueType) left - (int) (short) (ValueType) right);
    if (typeof (T) == typeof (uint))
      return (T) (ValueType) (uint) ((int) (uint) (ValueType) left - (int) (uint) (ValueType) right);
    if (typeof (T) == typeof (int))
      return (T) (ValueType) ((int) (ValueType) left - (int) (ValueType) right);
    if (typeof (T) == typeof (ulong))
      return (T) (ValueType) (ulong) ((long) (ulong) (ValueType) left - (long) (ulong) (ValueType) right);
    if (typeof (T) == typeof (long))
      return (T) (ValueType) ((long) (ValueType) left - (long) (ValueType) right);
    if (typeof (T) == typeof (float))
      return (T) (ValueType) ((float) (ValueType) left - (float) (ValueType) right);
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return (T) (ValueType) ((double) (ValueType) left - (double) (ValueType) right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static T ScalarMultiply(T left, T right)
  {
    if (typeof (T) == typeof (byte))
      return (T) (ValueType) (byte) ((uint) (byte) (ValueType) left * (uint) (byte) (ValueType) right);
    if (typeof (T) == typeof (sbyte))
      return (T) (ValueType) (sbyte) ((int) (sbyte) (ValueType) left * (int) (sbyte) (ValueType) right);
    if (typeof (T) == typeof (ushort))
      return (T) (ValueType) (ushort) ((uint) (ushort) (ValueType) left * (uint) (ushort) (ValueType) right);
    if (typeof (T) == typeof (short))
      return (T) (ValueType) (short) ((int) (short) (ValueType) left * (int) (short) (ValueType) right);
    if (typeof (T) == typeof (uint))
      return (T) (ValueType) (uint) ((int) (uint) (ValueType) left * (int) (uint) (ValueType) right);
    if (typeof (T) == typeof (int))
      return (T) (ValueType) ((int) (ValueType) left * (int) (ValueType) right);
    if (typeof (T) == typeof (ulong))
      return (T) (ValueType) (ulong) ((long) (ulong) (ValueType) left * (long) (ulong) (ValueType) right);
    if (typeof (T) == typeof (long))
      return (T) (ValueType) ((long) (ValueType) left * (long) (ValueType) right);
    if (typeof (T) == typeof (float))
      return (T) (ValueType) ((float) (ValueType) left * (float) (ValueType) right);
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return (T) (ValueType) ((double) (ValueType) left * (double) (ValueType) right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static T ScalarDivide(T left, T right)
  {
    if (typeof (T) == typeof (byte))
      return (T) (ValueType) (byte) ((uint) (byte) (ValueType) left / (uint) (byte) (ValueType) right);
    if (typeof (T) == typeof (sbyte))
      return (T) (ValueType) (sbyte) ((int) (sbyte) (ValueType) left / (int) (sbyte) (ValueType) right);
    if (typeof (T) == typeof (ushort))
      return (T) (ValueType) (ushort) ((uint) (ushort) (ValueType) left / (uint) (ushort) (ValueType) right);
    if (typeof (T) == typeof (short))
      return (T) (ValueType) (short) ((int) (short) (ValueType) left / (int) (short) (ValueType) right);
    if (typeof (T) == typeof (uint))
      return (T) (ValueType) ((uint) (ValueType) left / (uint) (ValueType) right);
    if (typeof (T) == typeof (int))
      return (T) (ValueType) ((int) (ValueType) left / (int) (ValueType) right);
    if (typeof (T) == typeof (ulong))
      return (T) (ValueType) ((ulong) (ValueType) left / (ulong) (ValueType) right);
    if (typeof (T) == typeof (long))
      return (T) (ValueType) ((long) (ValueType) left / (long) (ValueType) right);
    if (typeof (T) == typeof (float))
      return (T) (ValueType) ((float) (ValueType) left / (float) (ValueType) right);
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return (T) (ValueType) ((double) (ValueType) left / (double) (ValueType) right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static T GetOneValue()
  {
    if (typeof (T) == typeof (byte))
      return (T) (ValueType) (byte) 1;
    if (typeof (T) == typeof (sbyte))
      return (T) (ValueType) (sbyte) 1;
    if (typeof (T) == typeof (ushort))
      return (T) (ValueType) (ushort) 1;
    if (typeof (T) == typeof (short))
      return (T) (ValueType) (short) 1;
    if (typeof (T) == typeof (uint))
      return (T) (ValueType) 1U;
    if (typeof (T) == typeof (int))
      return (T) (ValueType) 1;
    if (typeof (T) == typeof (ulong))
      return (T) (ValueType) 1UL;
    if (typeof (T) == typeof (long))
      return (T) (ValueType) 1L;
    if (typeof (T) == typeof (float))
      return (T) (ValueType) 1f;
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return (T) (ValueType) 1.0;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static T GetAllBitsSetValue()
  {
    if (typeof (T) == typeof (byte))
      return (T) (ValueType) ConstantHelper.GetByteWithAllBitsSet();
    if (typeof (T) == typeof (sbyte))
      return (T) (ValueType) ConstantHelper.GetSByteWithAllBitsSet();
    if (typeof (T) == typeof (ushort))
      return (T) (ValueType) ConstantHelper.GetUInt16WithAllBitsSet();
    if (typeof (T) == typeof (short))
      return (T) (ValueType) ConstantHelper.GetInt16WithAllBitsSet();
    if (typeof (T) == typeof (uint))
      return (T) (ValueType) ConstantHelper.GetUInt32WithAllBitsSet();
    if (typeof (T) == typeof (int))
      return (T) (ValueType) ConstantHelper.GetInt32WithAllBitsSet();
    if (typeof (T) == typeof (ulong))
      return (T) (ValueType) ConstantHelper.GetUInt64WithAllBitsSet();
    if (typeof (T) == typeof (long))
      return (T) (ValueType) ConstantHelper.GetInt64WithAllBitsSet();
    if (typeof (T) == typeof (float))
      return (T) (ValueType) ConstantHelper.GetSingleWithAllBitsSet();
    if (!(typeof (T) == typeof (double)))
      throw new NotSupportedException(System.System.Numerics.Vectors3620677.SR.Arg_TypeNotSupported);
    return (T) (ValueType) ConstantHelper.GetDoubleWithAllBitsSet();
  }

  private struct VectorSizeHelper
  {
    internal Vector<T> _placeholder;
    internal byte _byte;
  }
}
