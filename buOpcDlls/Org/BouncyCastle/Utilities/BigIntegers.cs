// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.BigIntegers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Utilities;

public static class BigIntegers
{
  public static readonly BigInteger Zero = BigInteger.Zero;
  public static readonly BigInteger One = BigInteger.One;
  private const int MaxIterations = 1000;

  public static byte[] AsUnsignedByteArray(BigInteger n) => n.ToByteArrayUnsigned();

  public static byte[] AsUnsignedByteArray(int length, BigInteger n)
  {
    byte[] byteArrayUnsigned = n.ToByteArrayUnsigned();
    int length1 = byteArrayUnsigned.Length;
    if (length1 == length)
      return byteArrayUnsigned;
    byte[] destinationArray = length1 <= length ? new byte[length] : throw new ArgumentException("standard length exceeded", nameof (n));
    Array.Copy((Array) byteArrayUnsigned, 0, (Array) destinationArray, length - length1, length1);
    return destinationArray;
  }

  public static void AsUnsignedByteArray(BigInteger n, byte[] buf, int off, int len)
  {
    byte[] byteArrayUnsigned = n.ToByteArrayUnsigned();
    int length = byteArrayUnsigned.Length;
    if (length > len)
      throw new ArgumentException("standard length exceeded", nameof (n));
    int num = len - length;
    Arrays.Fill(buf, off, off + num, (byte) 0);
    Array.Copy((Array) byteArrayUnsigned, 0, (Array) buf, off + num, length);
  }

  public static BigInteger CreateRandomBigInteger(int bitLength, SecureRandom secureRandom)
  {
    return new BigInteger(bitLength, (Random) secureRandom);
  }

  public static BigInteger CreateRandomInRange(BigInteger min, BigInteger max, SecureRandom random)
  {
    int num = min.CompareTo(max);
    if (num >= 0)
    {
      if (num > 0)
        throw new ArgumentException("'min' may not be greater than 'max'");
      return min;
    }
    if (min.BitLength > max.BitLength / 2)
      return BigIntegers.CreateRandomInRange(BigInteger.Zero, max.Subtract(min), random).Add(min);
    for (int index = 0; index < 1000; ++index)
    {
      BigInteger randomInRange = new BigInteger(max.BitLength, (Random) random);
      if (randomInRange.CompareTo(min) >= 0 && randomInRange.CompareTo(max) <= 0)
        return randomInRange;
    }
    return new BigInteger(max.Subtract(min).BitLength - 1, (Random) random).Add(min);
  }

  public static BigInteger FromUnsignedByteArray(byte[] buf) => new BigInteger(1, buf);

  public static BigInteger FromUnsignedByteArray(byte[] buf, int off, int length)
  {
    return new BigInteger(1, buf, off, length);
  }

  public static int GetByteLength(BigInteger n) => n.GetLengthofByteArray();

  public static int GetUnsignedByteLength(BigInteger n) => n.GetLengthofByteArrayUnsigned();

  public static BigInteger ModOddInverse(BigInteger M, BigInteger X)
  {
    if (!M.TestBit(0))
      throw new ArgumentException("must be odd", nameof (M));
    if (M.SignValue != 1)
      throw new ArithmeticException("BigInteger: modulus not positive");
    if (X.SignValue < 0 || X.CompareTo(M) >= 0)
      X = X.Mod(M);
    int bitLength = M.BitLength;
    uint[] m = Nat.FromBigInteger(bitLength, M);
    uint[] x = Nat.FromBigInteger(bitLength, X);
    int length = m.Length;
    uint[] numArray = Nat.Create(length);
    if (Mod.ModOddInverse(m, x, numArray) == 0U)
      throw new ArithmeticException("BigInteger not invertible");
    return Nat.ToBigInteger(length, numArray);
  }

  public static BigInteger ModOddInverseVar(BigInteger M, BigInteger X)
  {
    if (!M.TestBit(0))
      throw new ArgumentException("must be odd", nameof (M));
    if (M.SignValue != 1)
      throw new ArithmeticException("BigInteger: modulus not positive");
    if (M.Equals(BigIntegers.One))
      return BigIntegers.Zero;
    if (X.SignValue < 0 || X.CompareTo(M) >= 0)
      X = X.Mod(M);
    if (X.Equals(BigIntegers.One))
      return BigIntegers.One;
    int bitLength = M.BitLength;
    uint[] m = Nat.FromBigInteger(bitLength, M);
    uint[] x = Nat.FromBigInteger(bitLength, X);
    int length = m.Length;
    uint[] numArray = Nat.Create(length);
    if (!Mod.ModOddInverseVar(m, x, numArray))
      throw new ArithmeticException("BigInteger not invertible");
    return Nat.ToBigInteger(length, numArray);
  }
}
