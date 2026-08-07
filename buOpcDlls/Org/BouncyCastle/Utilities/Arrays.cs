// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Arrays
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Utilities;

public static class Arrays
{
  public static readonly byte[] EmptyBytes = new byte[0];
  public static readonly int[] EmptyInts = new int[0];

  public static bool AreAllZeroes(byte[] buf, int off, int len)
  {
    uint num = 0;
    for (int index = 0; index < len; ++index)
      num |= (uint) buf[off + index];
    return num == 0U;
  }

  public static bool AreEqual(bool[] a, bool[] b)
  {
    if (a == b)
      return true;
    return a != null && b != null && Arrays.HaveSameContents(a, b);
  }

  public static bool AreEqual(char[] a, char[] b)
  {
    if (a == b)
      return true;
    return a != null && b != null && Arrays.HaveSameContents(a, b);
  }

  public static bool AreEqual(byte[] a, byte[] b)
  {
    if (a == b)
      return true;
    return a != null && b != null && Arrays.HaveSameContents(a, b);
  }

  public static bool AreEqual(
    byte[] a,
    int aFromIndex,
    int aToIndex,
    byte[] b,
    int bFromIndex,
    int bToIndex)
  {
    int num1 = aToIndex - aFromIndex;
    int num2 = bToIndex - bFromIndex;
    if (num1 != num2)
      return false;
    for (int index = 0; index < num1; ++index)
    {
      if ((int) a[aFromIndex + index] != (int) b[bFromIndex + index])
        return false;
    }
    return true;
  }

  [CLSCompliant(false)]
  public static bool AreEqual(
    ulong[] a,
    int aFromIndex,
    int aToIndex,
    ulong[] b,
    int bFromIndex,
    int bToIndex)
  {
    int num1 = aToIndex - aFromIndex;
    int num2 = bToIndex - bFromIndex;
    if (num1 != num2)
      return false;
    for (int index = 0; index < num1; ++index)
    {
      if ((long) a[aFromIndex + index] != (long) b[bFromIndex + index])
        return false;
    }
    return true;
  }

  [Obsolete("Use 'FixedTimeEquals' instead")]
  public static bool ConstantTimeAreEqual(byte[] a, byte[] b) => Arrays.FixedTimeEquals(a, b);

  [Obsolete("Use 'FixedTimeEquals' instead")]
  public static bool ConstantTimeAreEqual(int len, byte[] a, int aOff, byte[] b, int bOff)
  {
    return Arrays.FixedTimeEquals(len, a, aOff, b, bOff);
  }

  [MethodImpl(MethodImplOptions.NoOptimization)]
  public static bool FixedTimeEquals(byte[] a, byte[] b)
  {
    if (a == null || b == null)
      return false;
    int length = a.Length;
    if (length != b.Length)
      return false;
    int num = 0;
    for (int index = 0; index < length; ++index)
      num |= (int) a[index] ^ (int) b[index];
    return num == 0;
  }

  [MethodImpl(MethodImplOptions.NoOptimization)]
  public static bool FixedTimeEquals(int len, byte[] a, int aOff, byte[] b, int bOff)
  {
    if (a == null)
      throw new ArgumentNullException(nameof (a));
    if (b == null)
      throw new ArgumentNullException(nameof (b));
    if (len < 0)
      throw new ArgumentException("cannot be negative", nameof (len));
    if (aOff > a.Length - len)
      throw new IndexOutOfRangeException("'aOff' value invalid for specified length");
    if (bOff > b.Length - len)
      throw new IndexOutOfRangeException("'bOff' value invalid for specified length");
    int num = 0;
    for (int index = 0; index < len; ++index)
      num |= (int) a[aOff + index] ^ (int) b[bOff + index];
    return num == 0;
  }

  public static bool AreEqual(int[] a, int[] b)
  {
    if (a == b)
      return true;
    return a != null && b != null && Arrays.HaveSameContents(a, b);
  }

  [CLSCompliant(false)]
  public static bool AreEqual(uint[] a, uint[] b)
  {
    if (a == b)
      return true;
    return a != null && b != null && Arrays.HaveSameContents(a, b);
  }

  public static bool AreEqual(long[] a, long[] b)
  {
    if (a == b)
      return true;
    return a != null && b != null && Arrays.HaveSameContents(a, b);
  }

  [CLSCompliant(false)]
  public static bool AreEqual(ulong[] a, ulong[] b)
  {
    if (a == b)
      return true;
    return a != null && b != null && Arrays.HaveSameContents(a, b);
  }

  private static bool HaveSameContents(bool[] a, bool[] b)
  {
    int length = a.Length;
    if (length != b.Length)
      return false;
    while (length != 0)
    {
      --length;
      if (a[length] != b[length])
        return false;
    }
    return true;
  }

  private static bool HaveSameContents(char[] a, char[] b)
  {
    int length = a.Length;
    if (length != b.Length)
      return false;
    while (length != 0)
    {
      --length;
      if ((int) a[length] != (int) b[length])
        return false;
    }
    return true;
  }

  private static bool HaveSameContents(byte[] a, byte[] b)
  {
    int length = a.Length;
    if (length != b.Length)
      return false;
    while (length != 0)
    {
      --length;
      if ((int) a[length] != (int) b[length])
        return false;
    }
    return true;
  }

  private static bool HaveSameContents(int[] a, int[] b)
  {
    int length = a.Length;
    if (length != b.Length)
      return false;
    while (length != 0)
    {
      --length;
      if (a[length] != b[length])
        return false;
    }
    return true;
  }

  private static bool HaveSameContents(uint[] a, uint[] b)
  {
    int length = a.Length;
    if (length != b.Length)
      return false;
    while (length != 0)
    {
      --length;
      if ((int) a[length] != (int) b[length])
        return false;
    }
    return true;
  }

  private static bool HaveSameContents(long[] a, long[] b)
  {
    int length = a.Length;
    if (length != b.Length)
      return false;
    while (length != 0)
    {
      --length;
      if (a[length] != b[length])
        return false;
    }
    return true;
  }

  private static bool HaveSameContents(ulong[] a, ulong[] b)
  {
    int length = a.Length;
    if (length != b.Length)
      return false;
    while (length != 0)
    {
      --length;
      if ((long) a[length] != (long) b[length])
        return false;
    }
    return true;
  }

  public static string ToString(object[] a)
  {
    StringBuilder stringBuilder = new StringBuilder("[");
    if (a.Length != 0)
    {
      stringBuilder.Append(a[0]);
      for (int index = 1; index < a.Length; ++index)
        stringBuilder.Append(", ").Append(a[index]);
    }
    stringBuilder.Append(']');
    return stringBuilder.ToString();
  }

  public static int GetHashCode(byte[] data)
  {
    if (data == null)
      return 0;
    int length = data.Length;
    int hashCode = length + 1;
    while (--length >= 0)
      hashCode = hashCode * 257 ^ (int) data[length];
    return hashCode;
  }

  public static int GetHashCode(byte[] data, int off, int len)
  {
    if (data == null)
      return 0;
    int num = len;
    int hashCode = num + 1;
    while (--num >= 0)
      hashCode = hashCode * 257 ^ (int) data[off + num];
    return hashCode;
  }

  public static int GetHashCode(int[] data)
  {
    if (data == null)
      return 0;
    int length = data.Length;
    int hashCode = length + 1;
    while (--length >= 0)
      hashCode = hashCode * 257 ^ data[length];
    return hashCode;
  }

  [CLSCompliant(false)]
  public static int GetHashCode(ushort[] data)
  {
    if (data == null)
      return 0;
    int length = data.Length;
    int hashCode = length + 1;
    while (--length >= 0)
      hashCode = hashCode * 257 ^ (int) data[length];
    return hashCode;
  }

  public static int GetHashCode(int[] data, int off, int len)
  {
    if (data == null)
      return 0;
    int num = len;
    int hashCode = num + 1;
    while (--num >= 0)
      hashCode = hashCode * 257 ^ data[off + num];
    return hashCode;
  }

  [CLSCompliant(false)]
  public static int GetHashCode(uint[] data)
  {
    if (data == null)
      return 0;
    int length = data.Length;
    int hashCode = length + 1;
    while (--length >= 0)
      hashCode = hashCode * 257 ^ (int) data[length];
    return hashCode;
  }

  [CLSCompliant(false)]
  public static int GetHashCode(uint[] data, int off, int len)
  {
    if (data == null)
      return 0;
    int num = len;
    int hashCode = num + 1;
    while (--num >= 0)
      hashCode = hashCode * 257 ^ (int) data[off + num];
    return hashCode;
  }

  [CLSCompliant(false)]
  public static int GetHashCode(ulong[] data)
  {
    if (data == null)
      return 0;
    int length = data.Length;
    int hashCode = length + 1;
    while (--length >= 0)
    {
      ulong num = data[length];
      hashCode = (hashCode * 257 ^ (int) num) * 257 ^ (int) (num >> 32 /*0x20*/);
    }
    return hashCode;
  }

  [CLSCompliant(false)]
  public static int GetHashCode(ulong[] data, int off, int len)
  {
    if (data == null)
      return 0;
    int num1 = len;
    int hashCode = num1 + 1;
    while (--num1 >= 0)
    {
      ulong num2 = data[off + num1];
      hashCode = (hashCode * 257 ^ (int) num2) * 257 ^ (int) (num2 >> 32 /*0x20*/);
    }
    return hashCode;
  }

  public static bool[] Clone(bool[] data) => data != null ? (bool[]) data.Clone() : (bool[]) null;

  public static byte[] Clone(byte[] data) => data != null ? (byte[]) data.Clone() : (byte[]) null;

  public static short[] Clone(short[] data)
  {
    return data != null ? (short[]) data.Clone() : (short[]) null;
  }

  [CLSCompliant(false)]
  public static ushort[] Clone(ushort[] data)
  {
    return data != null ? (ushort[]) data.Clone() : (ushort[]) null;
  }

  public static int[] Clone(int[] data) => data != null ? (int[]) data.Clone() : (int[]) null;

  [CLSCompliant(false)]
  public static uint[] Clone(uint[] data) => data != null ? (uint[]) data.Clone() : (uint[]) null;

  public static long[] Clone(long[] data) => data != null ? (long[]) data.Clone() : (long[]) null;

  [CLSCompliant(false)]
  public static ulong[] Clone(ulong[] data)
  {
    return data != null ? (ulong[]) data.Clone() : (ulong[]) null;
  }

  public static byte[] Clone(byte[] data, byte[] existing)
  {
    if (data == null)
      return (byte[]) null;
    if (existing == null || existing.Length != data.Length)
      return Arrays.Clone(data);
    Array.Copy((Array) data, 0, (Array) existing, 0, existing.Length);
    return existing;
  }

  [CLSCompliant(false)]
  public static ulong[] Clone(ulong[] data, ulong[] existing)
  {
    if (data == null)
      return (ulong[]) null;
    if (existing == null || existing.Length != data.Length)
      return Arrays.Clone(data);
    Array.Copy((Array) data, 0, (Array) existing, 0, existing.Length);
    return existing;
  }

  public static bool Contains(byte[] a, byte n)
  {
    for (int index = 0; index < a.Length; ++index)
    {
      if ((int) a[index] == (int) n)
        return true;
    }
    return false;
  }

  public static bool Contains(short[] a, short n)
  {
    for (int index = 0; index < a.Length; ++index)
    {
      if ((int) a[index] == (int) n)
        return true;
    }
    return false;
  }

  public static bool Contains(int[] a, int n)
  {
    for (int index = 0; index < a.Length; ++index)
    {
      if (a[index] == n)
        return true;
    }
    return false;
  }

  public static void Fill(byte[] buf, byte b)
  {
    int length = buf.Length;
    while (length > 0)
      buf[--length] = b;
  }

  [CLSCompliant(false)]
  public static void Fill(ulong[] buf, ulong b)
  {
    int length = buf.Length;
    while (length > 0)
      buf[--length] = b;
  }

  public static void Fill(byte[] buf, int from, int to, byte b)
  {
    for (int index = from; index < to; ++index)
      buf[index] = b;
  }

  public static void Fill<T>(T[] ts, T t)
  {
    for (int index = 0; index < ts.Length; ++index)
      ts[index] = t;
  }

  public static byte[] CopyOf(byte[] data, int newLength)
  {
    byte[] destinationArray = new byte[newLength];
    Array.Copy((Array) data, 0, (Array) destinationArray, 0, System.Math.Min(newLength, data.Length));
    return destinationArray;
  }

  public static char[] CopyOf(char[] data, int newLength)
  {
    char[] destinationArray = new char[newLength];
    Array.Copy((Array) data, 0, (Array) destinationArray, 0, System.Math.Min(newLength, data.Length));
    return destinationArray;
  }

  public static int[] CopyOf(int[] data, int newLength)
  {
    int[] destinationArray = new int[newLength];
    Array.Copy((Array) data, 0, (Array) destinationArray, 0, System.Math.Min(newLength, data.Length));
    return destinationArray;
  }

  [CLSCompliant(false)]
  public static uint[] CopyOf(uint[] data, int newLength)
  {
    uint[] destinationArray = new uint[newLength];
    Array.Copy((Array) data, 0, (Array) destinationArray, 0, System.Math.Min(newLength, data.Length));
    return destinationArray;
  }

  public static long[] CopyOf(long[] data, int newLength)
  {
    long[] destinationArray = new long[newLength];
    Array.Copy((Array) data, 0, (Array) destinationArray, 0, System.Math.Min(newLength, data.Length));
    return destinationArray;
  }

  public static BigInteger[] CopyOf(BigInteger[] data, int newLength)
  {
    BigInteger[] destinationArray = new BigInteger[newLength];
    Array.Copy((Array) data, 0, (Array) destinationArray, 0, System.Math.Min(newLength, data.Length));
    return destinationArray;
  }

  public static byte[] CopyOfRange(byte[] data, int from, int to)
  {
    int length = Arrays.GetLength(from, to);
    byte[] destinationArray = new byte[length];
    Array.Copy((Array) data, from, (Array) destinationArray, 0, System.Math.Min(length, data.Length - from));
    return destinationArray;
  }

  public static int[] CopyOfRange(int[] data, int from, int to)
  {
    int length = Arrays.GetLength(from, to);
    int[] destinationArray = new int[length];
    Array.Copy((Array) data, from, (Array) destinationArray, 0, System.Math.Min(length, data.Length - from));
    return destinationArray;
  }

  public static long[] CopyOfRange(long[] data, int from, int to)
  {
    int length = Arrays.GetLength(from, to);
    long[] destinationArray = new long[length];
    Array.Copy((Array) data, from, (Array) destinationArray, 0, System.Math.Min(length, data.Length - from));
    return destinationArray;
  }

  public static BigInteger[] CopyOfRange(BigInteger[] data, int from, int to)
  {
    int length = Arrays.GetLength(from, to);
    BigInteger[] destinationArray = new BigInteger[length];
    Array.Copy((Array) data, from, (Array) destinationArray, 0, System.Math.Min(length, data.Length - from));
    return destinationArray;
  }

  private static int GetLength(int from, int to)
  {
    int num = to - from;
    return num >= 0 ? num : throw new ArgumentException($"{from.ToString()} > {to.ToString()}");
  }

  public static byte[] Append(byte[] a, byte b)
  {
    if (a == null)
      return new byte[1]{ b };
    int length = a.Length;
    byte[] destinationArray = new byte[length + 1];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, length);
    destinationArray[length] = b;
    return destinationArray;
  }

  public static short[] Append(short[] a, short b)
  {
    if (a == null)
      return new short[1]{ b };
    int length = a.Length;
    short[] destinationArray = new short[length + 1];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, length);
    destinationArray[length] = b;
    return destinationArray;
  }

  public static int[] Append(int[] a, int b)
  {
    if (a == null)
      return new int[1]{ b };
    int length = a.Length;
    int[] destinationArray = new int[length + 1];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, length);
    destinationArray[length] = b;
    return destinationArray;
  }

  public static byte[] Concatenate(byte[] a, byte[] b)
  {
    if (a == null)
      return Arrays.Clone(b);
    if (b == null)
      return Arrays.Clone(a);
    byte[] destinationArray = new byte[a.Length + b.Length];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, a.Length);
    Array.Copy((Array) b, 0, (Array) destinationArray, a.Length, b.Length);
    return destinationArray;
  }

  [CLSCompliant(false)]
  public static ushort[] Concatenate(ushort[] a, ushort[] b)
  {
    if (a == null)
      return Arrays.Clone(b);
    if (b == null)
      return Arrays.Clone(a);
    ushort[] destinationArray = new ushort[a.Length + b.Length];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, a.Length);
    Array.Copy((Array) b, 0, (Array) destinationArray, a.Length, b.Length);
    return destinationArray;
  }

  public static byte[] ConcatenateAll(params byte[][] vs)
  {
    byte[][] numArray = new byte[vs.Length][];
    int num = 0;
    int length = 0;
    for (int index = 0; index < vs.Length; ++index)
    {
      byte[] v = vs[index];
      if (v != null)
      {
        numArray[num++] = v;
        length += v.Length;
      }
    }
    byte[] destinationArray = new byte[length];
    int destinationIndex = 0;
    for (int index = 0; index < num; ++index)
    {
      byte[] sourceArray = numArray[index];
      Array.Copy((Array) sourceArray, 0, (Array) destinationArray, destinationIndex, sourceArray.Length);
      destinationIndex += sourceArray.Length;
    }
    return destinationArray;
  }

  public static int[] Concatenate(int[] a, int[] b)
  {
    if (a == null)
      return Arrays.Clone(b);
    if (b == null)
      return Arrays.Clone(a);
    int[] destinationArray = new int[a.Length + b.Length];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, a.Length);
    Array.Copy((Array) b, 0, (Array) destinationArray, a.Length, b.Length);
    return destinationArray;
  }

  [CLSCompliant(false)]
  public static uint[] Concatenate(uint[] a, uint[] b)
  {
    if (a == null)
      return Arrays.Clone(b);
    if (b == null)
      return Arrays.Clone(a);
    uint[] destinationArray = new uint[a.Length + b.Length];
    Array.Copy((Array) a, 0, (Array) destinationArray, 0, a.Length);
    Array.Copy((Array) b, 0, (Array) destinationArray, a.Length, b.Length);
    return destinationArray;
  }

  public static byte[] Prepend(byte[] a, byte b)
  {
    if (a == null)
      return new byte[1]{ b };
    int length = a.Length;
    byte[] destinationArray = new byte[length + 1];
    Array.Copy((Array) a, 0, (Array) destinationArray, 1, length);
    destinationArray[0] = b;
    return destinationArray;
  }

  public static short[] Prepend(short[] a, short b)
  {
    if (a == null)
      return new short[1]{ b };
    int length = a.Length;
    short[] destinationArray = new short[length + 1];
    Array.Copy((Array) a, 0, (Array) destinationArray, 1, length);
    destinationArray[0] = b;
    return destinationArray;
  }

  public static int[] Prepend(int[] a, int b)
  {
    if (a == null)
      return new int[1]{ b };
    int length = a.Length;
    int[] destinationArray = new int[length + 1];
    Array.Copy((Array) a, 0, (Array) destinationArray, 1, length);
    destinationArray[0] = b;
    return destinationArray;
  }

  public static T[] Prepend<T>(T[] a, T b)
  {
    if (a == null)
      return new T[1]{ b };
    T[] objArray = new T[1 + a.Length];
    objArray[0] = b;
    a.CopyTo((Array) objArray, 1);
    return objArray;
  }

  public static byte[] Reverse(byte[] a)
  {
    if (a == null)
      return (byte[]) null;
    int num = 0;
    int length = a.Length;
    byte[] numArray = new byte[length];
    while (--length >= 0)
      numArray[length] = a[num++];
    return numArray;
  }

  public static int[] Reverse(int[] a)
  {
    if (a == null)
      return (int[]) null;
    int num = 0;
    int length = a.Length;
    int[] numArray = new int[length];
    while (--length >= 0)
      numArray[length] = a[num++];
    return numArray;
  }

  public static T[] ReverseInPlace<T>(T[] array)
  {
    if (array == null)
      return (T[]) null;
    Array.Reverse((Array) array);
    return array;
  }

  public static void Clear(byte[] data)
  {
    if (data == null)
      return;
    Array.Clear((Array) data, 0, data.Length);
  }

  public static void Clear(int[] data)
  {
    if (data == null)
      return;
    Array.Clear((Array) data, 0, data.Length);
  }

  public static bool IsNullOrContainsNull(object[] array)
  {
    if (array == null)
      return true;
    int length = array.Length;
    for (int index = 0; index < length; ++index)
    {
      if (array[index] == null)
        return true;
    }
    return false;
  }

  public static bool IsNullOrEmpty(byte[] array) => array == null || array.Length < 1;

  public static bool IsNullOrEmpty(object[] array) => array == null || array.Length < 1;
}
