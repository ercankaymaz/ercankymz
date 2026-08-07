// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.BigInteger
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Math;

[Serializable]
public sealed class BigInteger : IComparable, IComparable<BigInteger>, IEquatable<BigInteger>
{
  internal static readonly int[][] primeLists = new int[64 /*0x40*/][]
  {
    new int[8]{ 3, 5, 7, 11, 13, 17, 19, 23 },
    new int[5]{ 29, 31 /*0x1F*/, 37, 41, 43 },
    new int[5]{ 47, 53, 59, 61, 67 },
    new int[4]{ 71, 73, 79, 83 },
    new int[4]{ 89, 97, 101, 103 },
    new int[4]{ 107, 109, 113, (int) sbyte.MaxValue },
    new int[4]{ 131, 137, 139, 149 },
    new int[4]{ 151, 157, 163, 167 },
    new int[4]{ 173, 179, 181, 191 },
    new int[4]{ 193, 197, 199, 211 },
    new int[3]{ 223, 227, 229 },
    new int[3]{ 233, 239, 241 },
    new int[3]{ 251, 257, 263 },
    new int[3]{ 269, 271, 277 },
    new int[3]{ 281, 283, 293 },
    new int[3]{ 307, 311, 313 },
    new int[3]{ 317, 331, 337 },
    new int[3]{ 347, 349, 353 },
    new int[3]{ 359, 367, 373 },
    new int[3]{ 379, 383, 389 },
    new int[3]{ 397, 401, 409 },
    new int[3]{ 419, 421, 431 },
    new int[3]{ 433, 439, 443 },
    new int[3]{ 449, 457, 461 },
    new int[3]{ 463, 467, 479 },
    new int[3]{ 487, 491, 499 },
    new int[3]{ 503, 509, 521 },
    new int[3]{ 523, 541, 547 },
    new int[3]{ 557, 563, 569 },
    new int[3]{ 571, 577, 587 },
    new int[3]{ 593, 599, 601 },
    new int[3]{ 607, 613, 617 },
    new int[3]{ 619, 631, 641 },
    new int[3]{ 643, 647, 653 },
    new int[3]{ 659, 661, 673 },
    new int[3]{ 677, 683, 691 },
    new int[3]{ 701, 709, 719 },
    new int[3]{ 727, 733, 739 },
    new int[3]{ 743, 751, 757 },
    new int[3]{ 761, 769, 773 },
    new int[3]{ 787, 797, 809 },
    new int[3]{ 811, 821, 823 },
    new int[3]{ 827, 829, 839 },
    new int[3]{ 853, 857, 859 },
    new int[3]{ 863, 877, 881 },
    new int[3]{ 883, 887, 907 },
    new int[3]{ 911, 919, 929 },
    new int[3]{ 937, 941, 947 },
    new int[3]{ 953, 967, 971 },
    new int[3]{ 977, 983, 991 },
    new int[3]{ 997, 1009, 1013 },
    new int[3]{ 1019, 1021, 1031 },
    new int[3]{ 1033, 1039, 1049 },
    new int[3]{ 1051, 1061, 1063 },
    new int[3]{ 1069, 1087, 1091 },
    new int[3]{ 1093, 1097, 1103 },
    new int[3]{ 1109, 1117, 1123 },
    new int[3]{ 1129, 1151, 1153 },
    new int[3]{ 1163, 1171, 1181 },
    new int[3]{ 1187, 1193, 1201 },
    new int[3]{ 1213, 1217, 1223 },
    new int[3]{ 1229, 1231, 1237 },
    new int[3]{ 1249, 1259, 1277 },
    new int[3]{ 1279 /*0x04FF*/, 1283, 1289 }
  };
  internal static readonly int[] primeProducts;
  private const long IMASK = 4294967295 /*0xFFFFFFFF*/;
  private const ulong UIMASK = 4294967295 /*0xFFFFFFFF*/;
  private static readonly uint[] ZeroMagnitude = new uint[0];
  private static readonly byte[] ZeroEncoding = new byte[0];
  private static readonly BigInteger[] SMALL_CONSTANTS = new BigInteger[17];
  public static readonly BigInteger Zero;
  public static readonly BigInteger One;
  public static readonly BigInteger Two;
  public static readonly BigInteger Three;
  public static readonly BigInteger Four;
  public static readonly BigInteger Ten;
  private static readonly byte[] BitLengthTable = new byte[256 /*0x0100*/]
  {
    (byte) 0,
    (byte) 1,
    (byte) 2,
    (byte) 2,
    (byte) 3,
    (byte) 3,
    (byte) 3,
    (byte) 3,
    (byte) 4,
    (byte) 4,
    (byte) 4,
    (byte) 4,
    (byte) 4,
    (byte) 4,
    (byte) 4,
    (byte) 4,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 5,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 6,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 7,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8,
    (byte) 8
  };
  private const int chunk2 = 1;
  private const int chunk8 = 1;
  private const int chunk10 = 19;
  private const int chunk16 = 16 /*0x10*/;
  private static readonly BigInteger radix2;
  private static readonly BigInteger radix2E;
  private static readonly BigInteger radix8;
  private static readonly BigInteger radix8E;
  private static readonly BigInteger radix10;
  private static readonly BigInteger radix10E;
  private static readonly BigInteger radix16;
  private static readonly BigInteger radix16E;
  private static readonly int[] ExpWindowThresholds = new int[8]
  {
    7,
    25,
    81,
    241,
    673,
    1793,
    4609,
    int.MaxValue
  };
  private const int BitsPerByte = 8;
  private const int BitsPerInt = 32 /*0x20*/;
  private const int BytesPerInt = 4;
  private readonly uint[] magnitude;
  private readonly int sign;
  [NonSerialized]
  private int nBits = -1;
  [NonSerialized]
  private int nBitLength = -1;

  static BigInteger()
  {
    BigInteger.Zero = new BigInteger(0, BigInteger.ZeroMagnitude, false);
    BigInteger.Zero.nBits = 0;
    BigInteger.Zero.nBitLength = 0;
    BigInteger.SMALL_CONSTANTS[0] = BigInteger.Zero;
    for (uint index = 1; (long) index < (long) BigInteger.SMALL_CONSTANTS.Length; ++index)
      BigInteger.SMALL_CONSTANTS[(int) index] = BigInteger.CreateUValueOf((ulong) index);
    BigInteger.One = BigInteger.SMALL_CONSTANTS[1];
    BigInteger.Two = BigInteger.SMALL_CONSTANTS[2];
    BigInteger.Three = BigInteger.SMALL_CONSTANTS[3];
    BigInteger.Four = BigInteger.SMALL_CONSTANTS[4];
    BigInteger.Ten = BigInteger.SMALL_CONSTANTS[10];
    BigInteger.radix2 = BigInteger.ValueOf(2L);
    BigInteger.radix2E = BigInteger.radix2.Pow(1);
    BigInteger.radix8 = BigInteger.ValueOf(8L);
    BigInteger.radix8E = BigInteger.radix8.Pow(1);
    BigInteger.radix10 = BigInteger.ValueOf(10L);
    BigInteger.radix10E = BigInteger.radix10.Pow(19);
    BigInteger.radix16 = BigInteger.ValueOf(16L /*0x10*/);
    BigInteger.radix16E = BigInteger.radix16.Pow(16 /*0x10*/);
    BigInteger.primeProducts = new int[BigInteger.primeLists.Length];
    for (int index1 = 0; index1 < BigInteger.primeLists.Length; ++index1)
    {
      int[] primeList = BigInteger.primeLists[index1];
      int num = primeList[0];
      for (int index2 = 1; index2 < primeList.Length; ++index2)
        num *= primeList[index2];
      BigInteger.primeProducts[index1] = num;
    }
  }

  [System.Runtime.Serialization.OnDeserialized]
  private void OnDeserialized(StreamingContext context)
  {
    this.nBits = -1;
    this.nBitLength = -1;
  }

  private static int GetBytesLength(int nBits) => (nBits + 8 - 1) / 8;

  public static BigInteger Arbitrary(int sizeInBits)
  {
    return new BigInteger(sizeInBits, (Random) SecureRandom.ArbitraryRandom);
  }

  private BigInteger(int signum, uint[] mag, bool checkMag)
  {
    if (!checkMag)
    {
      this.sign = signum;
      this.magnitude = mag;
    }
    else
    {
      int sourceIndex = 0;
      while (sourceIndex < mag.Length && mag[sourceIndex] == 0U)
        ++sourceIndex;
      if (sourceIndex == mag.Length)
      {
        this.sign = 0;
        this.magnitude = BigInteger.ZeroMagnitude;
      }
      else
      {
        this.sign = signum;
        if (sourceIndex == 0)
        {
          this.magnitude = mag;
        }
        else
        {
          this.magnitude = new uint[mag.Length - sourceIndex];
          Array.Copy((Array) mag, sourceIndex, (Array) this.magnitude, 0, this.magnitude.Length);
        }
      }
    }
  }

  public BigInteger(string value)
    : this(value, 10)
  {
  }

  public BigInteger(string str, int radix)
  {
    if (str.Length == 0)
      throw new FormatException("Zero length BigInteger");
    NumberStyles style;
    int length;
    BigInteger bigInteger1;
    BigInteger val;
    switch (radix)
    {
      case 2:
        style = NumberStyles.Integer;
        length = 1;
        bigInteger1 = BigInteger.radix2;
        val = BigInteger.radix2E;
        break;
      case 8:
        style = NumberStyles.Integer;
        length = 1;
        bigInteger1 = BigInteger.radix8;
        val = BigInteger.radix8E;
        break;
      case 10:
        style = NumberStyles.Integer;
        length = 19;
        bigInteger1 = BigInteger.radix10;
        val = BigInteger.radix10E;
        break;
      case 16 /*0x10*/:
        style = NumberStyles.AllowHexSpecifier;
        length = 16 /*0x10*/;
        bigInteger1 = BigInteger.radix16;
        val = BigInteger.radix16E;
        break;
      default:
        throw new FormatException("Only bases 2, 8, 10, or 16 allowed");
    }
    int num1 = 0;
    this.sign = 1;
    if (str[0] == '-')
    {
      if (str.Length == 1)
        throw new FormatException("Zero length BigInteger");
      this.sign = -1;
      num1 = 1;
    }
    while (num1 < str.Length && int.Parse(str[num1].ToString(), style) == 0)
      ++num1;
    if (num1 >= str.Length)
    {
      this.sign = 0;
      this.magnitude = BigInteger.ZeroMagnitude;
    }
    else
    {
      BigInteger bigInteger2 = BigInteger.Zero;
      int num2 = num1 + length;
      if (num2 <= str.Length)
      {
        string s;
        do
        {
          s = str.Substring(num1, length);
          ulong num3 = ulong.Parse(s, style);
          BigInteger uvalueOf = BigInteger.CreateUValueOf(num3);
          BigInteger bigInteger3;
          switch (radix)
          {
            case 2:
              if (num3 < 2UL)
              {
                bigInteger3 = bigInteger2.ShiftLeft(1);
                break;
              }
              goto label_26;
            case 8:
              if (num3 < 8UL)
              {
                bigInteger3 = bigInteger2.ShiftLeft(3);
                break;
              }
              goto label_25;
            case 16 /*0x10*/:
              bigInteger3 = bigInteger2.ShiftLeft(64 /*0x40*/);
              break;
            default:
              bigInteger3 = bigInteger2.Multiply(val);
              break;
          }
          bigInteger2 = bigInteger3.Add(uvalueOf);
          num1 = num2;
          num2 += length;
        }
        while (num2 <= str.Length);
        goto label_27;
label_25:
        throw new FormatException("Bad character in radix 8 string: " + s);
label_26:
        throw new FormatException("Bad character in radix 2 string: " + s);
      }
label_27:
      if (num1 < str.Length)
      {
        string s = str.Substring(num1);
        BigInteger uvalueOf = BigInteger.CreateUValueOf(ulong.Parse(s, style));
        if (bigInteger2.sign > 0)
        {
          switch (radix)
          {
            case 2:
            case 8:
              bigInteger2 = bigInteger2.Add(uvalueOf);
              break;
            case 16 /*0x10*/:
              bigInteger2 = bigInteger2.ShiftLeft(s.Length << 2);
              goto case 2;
            default:
              bigInteger2 = bigInteger2.Multiply(bigInteger1.Pow(s.Length));
              goto case 2;
          }
        }
        else
          bigInteger2 = uvalueOf;
      }
      this.magnitude = bigInteger2.magnitude;
    }
  }

  public BigInteger(byte[] bytes)
    : this(bytes, 0, bytes.Length)
  {
  }

  public BigInteger(byte[] bytes, int offset, int length)
  {
    if (length == 0)
      throw new FormatException("Zero length BigInteger");
    if ((sbyte) bytes[offset] >= (sbyte) 0)
    {
      this.magnitude = BigInteger.MakeMagnitude(bytes, offset, length);
      this.sign = this.magnitude.Length != 0 ? 1 : 0;
    }
    else
    {
      this.sign = -1;
      int num = offset + length;
      int index1 = offset;
      while (index1 < num && bytes[index1] == byte.MaxValue)
        ++index1;
      if (index1 >= num)
      {
        this.magnitude = BigInteger.One.magnitude;
      }
      else
      {
        int length1 = num - index1;
        byte[] bytes1 = new byte[length1];
        int index2 = 0;
        while (index2 < length1)
          bytes1[index2++] = ~bytes[index1++];
        while (bytes1[--index2] == byte.MaxValue)
          bytes1[index2] = (byte) 0;
        ++bytes1[index2];
        this.magnitude = BigInteger.MakeMagnitude(bytes1);
      }
    }
  }

  private static uint[] MakeMagnitude(byte[] bytes)
  {
    return BigInteger.MakeMagnitude(bytes, 0, bytes.Length);
  }

  private static uint[] MakeMagnitude(byte[] bytes, int offset, int length)
  {
    int num1 = offset + length;
    int index1 = offset;
    while (index1 < num1 && bytes[index1] == (byte) 0)
      ++index1;
    if (index1 >= num1)
      return BigInteger.ZeroMagnitude;
    int length1 = (num1 - index1 + 3) / 4;
    int num2 = (num1 - index1) % 4;
    if (num2 == 0)
      num2 = 4;
    if (length1 < 1)
      return BigInteger.ZeroMagnitude;
    uint[] numArray = new uint[length1];
    uint num3 = 0;
    int index2 = 0;
    for (int index3 = index1; index3 < num1; ++index3)
    {
      num3 = num3 << 8 | (uint) bytes[index3];
      --num2;
      if (num2 <= 0)
      {
        numArray[index2] = num3;
        ++index2;
        num2 = 4;
        num3 = 0U;
      }
    }
    if (index2 < numArray.Length)
      numArray[index2] = num3;
    return numArray;
  }

  public BigInteger(int sign, byte[] bytes)
    : this(sign, bytes, 0, bytes.Length)
  {
  }

  public BigInteger(int sign, byte[] bytes, int offset, int length)
  {
    if (sign < -1 || sign > 1)
      throw new FormatException("Invalid sign value");
    if (sign == 0)
    {
      this.sign = 0;
      this.magnitude = BigInteger.ZeroMagnitude;
    }
    else
    {
      this.magnitude = BigInteger.MakeMagnitude(bytes, offset, length);
      this.sign = this.magnitude.Length < 1 ? 0 : sign;
    }
  }

  public BigInteger(int sizeInBits, Random random)
  {
    if (sizeInBits < 0)
      throw new ArgumentException("sizeInBits must be non-negative");
    this.nBits = -1;
    this.nBitLength = -1;
    if (sizeInBits == 0)
    {
      this.sign = 0;
      this.magnitude = BigInteger.ZeroMagnitude;
    }
    else
    {
      int bytesLength = BigInteger.GetBytesLength(sizeInBits);
      byte[] numArray = new byte[bytesLength];
      random.NextBytes(numArray);
      int num = 8 * bytesLength - sizeInBits;
      numArray[0] &= (byte) ((uint) byte.MaxValue >> num);
      this.magnitude = BigInteger.MakeMagnitude(numArray);
      this.sign = this.magnitude.Length < 1 ? 0 : 1;
    }
  }

  public BigInteger(int bitLength, int certainty, Random random)
  {
    if (bitLength < 2)
      throw new ArithmeticException("bitLength < 2");
    this.sign = 1;
    this.nBitLength = bitLength;
    if (bitLength == 2)
    {
      this.magnitude = random.Next(2) == 0 ? BigInteger.Two.magnitude : BigInteger.Three.magnitude;
    }
    else
    {
      int bytesLength = BigInteger.GetBytesLength(bitLength);
      byte[] numArray = new byte[bytesLength];
      int num1 = 8 * bytesLength - bitLength;
      byte num2 = (byte) ((uint) byte.MaxValue >> num1);
      byte num3 = (byte) (1 << 7 - num1);
label_9:
      random.NextBytes(numArray);
      numArray[0] &= num2;
      numArray[0] |= num3;
      numArray[bytesLength - 1] |= (byte) 1;
      this.magnitude = BigInteger.MakeMagnitude(numArray);
      this.nBits = -1;
      if (certainty < 1 || this.CheckProbablePrime(certainty, random, true))
        return;
      for (int index = 1; index < this.magnitude.Length - 1; ++index)
      {
        this.magnitude[index] ^= (uint) random.Next();
        if (this.CheckProbablePrime(certainty, random, true))
          return;
      }
      goto label_9;
    }
  }

  public BigInteger Abs() => this.sign < 0 ? this.Negate() : this;

  private static uint[] AddMagnitudes(uint[] a, uint[] b)
  {
    int index = a.Length - 1;
    int num1 = b.Length - 1;
    ulong num2 = 0;
    while (num1 >= 0)
    {
      ulong num3 = num2 + ((ulong) a[index] + (ulong) b[num1--]);
      a[index--] = (uint) num3;
      num2 = num3 >> 32 /*0x20*/;
    }
    if (num2 != 0UL)
    {
      while (index >= 0 && ++a[index--] == 0U)
        ;
    }
    return a;
  }

  public BigInteger Add(BigInteger value)
  {
    if (this.sign == 0)
      return value;
    if (this.sign == value.sign)
      return this.AddToMagnitude(value.magnitude);
    if (value.sign == 0)
      return this;
    return value.sign < 0 ? this.Subtract(value.Negate()) : value.Subtract(this.Negate());
  }

  private BigInteger AddToMagnitude(uint[] magToAdd)
  {
    uint[] numArray;
    uint[] b;
    if (this.magnitude.Length < magToAdd.Length)
    {
      numArray = magToAdd;
      b = this.magnitude;
    }
    else
    {
      numArray = this.magnitude;
      b = magToAdd;
    }
    uint maxValue = uint.MaxValue;
    if (numArray.Length == b.Length)
      maxValue -= b[0];
    bool checkMag;
    uint[] a;
    if (checkMag = numArray[0] >= maxValue)
    {
      a = new uint[numArray.Length + 1];
      numArray.CopyTo((Array) a, 1);
    }
    else
      a = (uint[]) numArray.Clone();
    return new BigInteger(this.sign, BigInteger.AddMagnitudes(a, b), checkMag);
  }

  public BigInteger And(BigInteger value)
  {
    if (this.sign == 0 || value.sign == 0)
      return BigInteger.Zero;
    uint[] numArray1 = this.sign > 0 ? this.magnitude : this.Add(BigInteger.One).magnitude;
    uint[] numArray2 = value.sign > 0 ? value.magnitude : value.Add(BigInteger.One).magnitude;
    bool flag = this.sign < 0 && value.sign < 0;
    uint[] mag = new uint[System.Math.Max(numArray1.Length, numArray2.Length)];
    int num1 = mag.Length - numArray1.Length;
    int num2 = mag.Length - numArray2.Length;
    for (int index = 0; index < mag.Length; ++index)
    {
      uint num3 = index >= num1 ? numArray1[index - num1] : 0U;
      uint num4 = index >= num2 ? numArray2[index - num2] : 0U;
      if (this.sign < 0)
        num3 = ~num3;
      if (value.sign < 0)
        num4 = ~num4;
      mag[index] = num3 & num4;
      if (flag)
        mag[index] = ~mag[index];
    }
    BigInteger bigInteger = new BigInteger(1, mag, true);
    if (flag)
      bigInteger = bigInteger.Not();
    return bigInteger;
  }

  public BigInteger AndNot(BigInteger val) => this.And(val.Not());

  public int BitCount
  {
    get
    {
      if (this.nBits == -1)
      {
        if (this.sign < 0)
        {
          this.nBits = this.Not().BitCount;
        }
        else
        {
          int num = 0;
          for (int index = 0; index < this.magnitude.Length; ++index)
            num += Integers.PopCount(this.magnitude[index]);
          this.nBits = num;
        }
      }
      return this.nBits;
    }
  }

  private static int CalcBitLength(int sign, int indx, uint[] mag)
  {
    for (; indx < mag.Length; ++indx)
    {
      if (mag[indx] != 0U)
      {
        int num1 = 32 /*0x20*/ * (mag.Length - indx - 1);
        uint v = mag[indx];
        int num2 = num1 + BigInteger.BitLen(v);
        if (sign < 0 && ((long) v & (long) -v) == (long) v)
        {
          while (++indx < mag.Length)
          {
            if (mag[indx] != 0U)
              goto label_8;
          }
          --num2;
        }
label_8:
        return num2;
      }
    }
    return 0;
  }

  public int BitLength
  {
    get
    {
      if (this.nBitLength == -1)
        this.nBitLength = this.sign == 0 ? 0 : BigInteger.CalcBitLength(this.sign, 0, this.magnitude);
      return this.nBitLength;
    }
  }

  private static int BitLen(byte b) => (int) BigInteger.BitLengthTable[(int) b];

  private static int BitLen(uint v)
  {
    uint index1 = v >> 24;
    if (index1 != 0U)
      return 24 + (int) BigInteger.BitLengthTable[(int) index1];
    uint index2 = v >> 16 /*0x10*/;
    if (index2 != 0U)
      return 16 /*0x10*/ + (int) BigInteger.BitLengthTable[(int) index2];
    uint index3 = v >> 8;
    return index3 != 0U ? 8 + (int) BigInteger.BitLengthTable[(int) index3] : (int) BigInteger.BitLengthTable[(int) v];
  }

  private bool QuickPow2Check() => this.sign > 0 && this.nBits == 1;

  public int CompareTo(object obj)
  {
    if (obj == null)
      return 1;
    return obj is BigInteger other ? this.CompareTo(other) : throw new ArgumentException("Object is not a BigInteger", nameof (obj));
  }

  public int CompareTo(BigInteger other)
  {
    if (other == null)
      return 1;
    if (this.sign < other.sign)
      return -1;
    if (this.sign > other.sign)
      return 1;
    return this.sign != 0 ? this.sign * BigInteger.CompareNoLeadingZeroes(0, this.magnitude, 0, other.magnitude) : 0;
  }

  private static int CompareTo(int xIndx, uint[] x, int yIndx, uint[] y)
  {
    while (xIndx != x.Length && x[xIndx] == 0U)
      ++xIndx;
    while (yIndx != y.Length && y[yIndx] == 0U)
      ++yIndx;
    return BigInteger.CompareNoLeadingZeroes(xIndx, x, yIndx, y);
  }

  private static int CompareNoLeadingZeroes(int xIndx, uint[] x, int yIndx, uint[] y)
  {
    int num1 = x.Length - y.Length - (xIndx - yIndx);
    if (num1 != 0)
      return num1 >= 0 ? 1 : -1;
    while (xIndx < x.Length)
    {
      uint num2 = x[xIndx++];
      uint num3 = y[yIndx++];
      if ((int) num2 != (int) num3)
        return num2 >= num3 ? 1 : -1;
    }
    return 0;
  }

  private uint[] Divide(uint[] x, uint[] y)
  {
    int index1 = 0;
    while (index1 < x.Length && x[index1] == 0U)
      ++index1;
    int index2 = 0;
    while (index2 < y.Length && y[index2] == 0U)
      ++index2;
    int num1 = BigInteger.CompareNoLeadingZeroes(index1, x, index2, y);
    uint[] a;
    if (num1 > 0)
    {
      int num2 = BigInteger.CalcBitLength(1, index2, y);
      int num3 = BigInteger.CalcBitLength(1, index1, x);
      int n1 = num3 - num2;
      int start = 0;
      int index3 = 0;
      int num4 = num2;
      uint[] numArray1;
      uint[] numArray2;
      if (n1 > 0)
      {
        numArray1 = new uint[(n1 >> 5) + 1];
        numArray1[0] = (uint) (1 << n1 % 32 /*0x20*/);
        numArray2 = BigInteger.ShiftLeft(y, n1);
        num4 += n1;
      }
      else
      {
        numArray1 = new uint[1]{ 1U };
        int length = y.Length - index2;
        numArray2 = new uint[length];
        Array.Copy((Array) y, index2, (Array) numArray2, 0, length);
      }
      a = new uint[numArray1.Length];
label_26:
      if (num4 < num3 || BigInteger.CompareNoLeadingZeroes(index1, x, index3, numArray2) >= 0)
      {
        BigInteger.Subtract(index1, x, index3, numArray2);
        BigInteger.AddMagnitudes(a, numArray1);
        while (x[index1] == 0U)
        {
          if (++index1 == x.Length)
            return a;
        }
        num3 = 32 /*0x20*/ * (x.Length - index1 - 1) + BigInteger.BitLen(x[index1]);
        if (num3 <= num2)
        {
          if (num3 < num2)
            return a;
          num1 = BigInteger.CompareNoLeadingZeroes(index1, x, index2, y);
          if (num1 <= 0)
            goto label_30;
        }
      }
      int n2 = num4 - num3;
      if (n2 == 1 && numArray2[index3] >> 1 > x[index1])
        ++n2;
      if (n2 < 2)
      {
        BigInteger.ShiftRightOneInPlace(index3, numArray2);
        --num4;
        BigInteger.ShiftRightOneInPlace(start, numArray1);
      }
      else
      {
        BigInteger.ShiftRightInPlace(index3, numArray2, n2);
        num4 -= n2;
        BigInteger.ShiftRightInPlace(start, numArray1, n2);
      }
      while (numArray2[index3] == 0U)
        ++index3;
      while (numArray1[start] == 0U)
        ++start;
      goto label_26;
    }
    a = new uint[1];
label_30:
    if (num1 == 0)
    {
      BigInteger.AddMagnitudes(a, BigInteger.One.magnitude);
      Array.Clear((Array) x, index1, x.Length - index1);
    }
    return a;
  }

  public BigInteger Divide(BigInteger val)
  {
    if (val.sign == 0)
      throw new ArithmeticException("Division by zero error");
    if (this.sign == 0)
      return BigInteger.Zero;
    if (val.QuickPow2Check())
    {
      BigInteger bigInteger = this.Abs().ShiftRight(val.Abs().BitLength - 1);
      return val.sign != this.sign ? bigInteger.Negate() : bigInteger;
    }
    uint[] x = (uint[]) this.magnitude.Clone();
    return new BigInteger(this.sign * val.sign, this.Divide(x, val.magnitude), true);
  }

  public BigInteger[] DivideAndRemainder(BigInteger val)
  {
    if (val.sign == 0)
      throw new ArithmeticException("Division by zero error");
    BigInteger[] bigIntegerArray = new BigInteger[2];
    if (this.sign == 0)
    {
      bigIntegerArray[0] = BigInteger.Zero;
      bigIntegerArray[1] = BigInteger.Zero;
    }
    else if (val.QuickPow2Check())
    {
      int n = val.Abs().BitLength - 1;
      BigInteger bigInteger = this.Abs().ShiftRight(n);
      uint[] mag = this.LastNBits(n);
      bigIntegerArray[0] = val.sign == this.sign ? bigInteger : bigInteger.Negate();
      bigIntegerArray[1] = new BigInteger(this.sign, mag, true);
    }
    else
    {
      uint[] numArray = (uint[]) this.magnitude.Clone();
      uint[] mag = this.Divide(numArray, val.magnitude);
      bigIntegerArray[0] = new BigInteger(this.sign * val.sign, mag, true);
      bigIntegerArray[1] = new BigInteger(this.sign, numArray, true);
    }
    return bigIntegerArray;
  }

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is BigInteger x && this.sign == x.sign && this.IsEqualMagnitude(x);
  }

  public bool Equals(BigInteger other)
  {
    if (other == this)
      return true;
    return other != null && this.sign == other.sign && this.IsEqualMagnitude(other);
  }

  private bool IsEqualMagnitude(BigInteger x)
  {
    if (this.magnitude.Length != x.magnitude.Length)
      return false;
    for (int index = 0; index < this.magnitude.Length; ++index)
    {
      if ((int) this.magnitude[index] != (int) x.magnitude[index])
        return false;
    }
    return true;
  }

  public BigInteger Gcd(BigInteger value)
  {
    if (value.sign == 0)
      return this.Abs();
    if (this.sign == 0)
      return value.Abs();
    BigInteger bigInteger1 = this;
    BigInteger bigInteger2;
    for (BigInteger m = value; m.sign != 0; m = bigInteger2)
    {
      bigInteger2 = bigInteger1.Mod(m);
      bigInteger1 = m;
    }
    return bigInteger1;
  }

  public override int GetHashCode()
  {
    int length = this.magnitude.Length;
    if (this.magnitude.Length != 0)
    {
      length ^= (int) this.magnitude[0];
      if (this.magnitude.Length > 1)
        length ^= (int) this.magnitude[this.magnitude.Length - 1];
    }
    return this.sign >= 0 ? length : ~length;
  }

  private BigInteger Inc()
  {
    if (this.sign == 0)
      return BigInteger.One;
    return this.sign < 0 ? new BigInteger(-1, BigInteger.DoSubBigLil(this.magnitude, BigInteger.One.magnitude), true) : this.AddToMagnitude(BigInteger.One.magnitude);
  }

  public int IntValue
  {
    get
    {
      if (this.sign == 0)
        return 0;
      int num = (int) this.magnitude[this.magnitude.Length - 1];
      return this.sign >= 0 ? num : -num;
    }
  }

  public int IntValueExact
  {
    get
    {
      if (this.BitLength > 31 /*0x1F*/)
        throw new ArithmeticException("BigInteger out of int range");
      return this.IntValue;
    }
  }

  public bool IsProbablePrime(int certainty) => this.IsProbablePrime(certainty, false);

  internal bool IsProbablePrime(int certainty, bool randomlySelected)
  {
    if (certainty <= 0)
      return true;
    BigInteger bigInteger = this.Abs();
    if (!bigInteger.TestBit(0))
      return bigInteger.Equals(BigInteger.Two);
    return !bigInteger.Equals(BigInteger.One) && bigInteger.CheckProbablePrime(certainty, (Random) SecureRandom.ArbitraryRandom, randomlySelected);
  }

  private bool CheckProbablePrime(int certainty, Random random, bool randomlySelected)
  {
    int num1 = System.Math.Min(this.BitLength - 1, BigInteger.primeLists.Length);
    for (int index = 0; index < num1; ++index)
    {
      int num2 = this.Remainder(BigInteger.primeProducts[index]);
      foreach (int num3 in BigInteger.primeLists[index])
      {
        if (num2 % num3 == 0)
          return this.BitLength < 16 /*0x10*/ && this.IntValue == num3;
      }
    }
    return this.RabinMillerTest(certainty, random, randomlySelected);
  }

  public bool RabinMillerTest(int certainty, Random random)
  {
    return this.RabinMillerTest(certainty, random, false);
  }

  internal bool RabinMillerTest(int certainty, Random random, bool randomlySelected)
  {
    int bitLength = this.BitLength;
    int val2 = (certainty - 1) / 2 + 1;
    if (randomlySelected)
    {
      int val1 = bitLength >= 1024 /*0x0400*/ ? 4 : (bitLength >= 512 /*0x0200*/ ? 8 : (bitLength >= 256 /*0x0100*/ ? 16 /*0x10*/ : 50));
      val2 = certainty >= 100 ? val2 - 50 + val1 : System.Math.Min(val1, val2);
    }
    BigInteger bigInteger1 = this;
    int lowestSetBitMaskFirst = bigInteger1.GetLowestSetBitMaskFirst(4294967294U);
    BigInteger e = bigInteger1.ShiftRight(lowestSetBitMaskFirst);
    BigInteger bigInteger2 = BigInteger.One.ShiftLeft(32 /*0x20*/ * bigInteger1.magnitude.Length).Remainder(bigInteger1);
    BigInteger bigInteger3 = bigInteger1.Subtract(bigInteger2);
    do
    {
      BigInteger b1;
      do
      {
        b1 = new BigInteger(bigInteger1.BitLength, random);
      }
      while (b1.sign == 0 || b1.CompareTo(bigInteger1) >= 0 || b1.IsEqualMagnitude(bigInteger2) || b1.IsEqualMagnitude(bigInteger3));
      BigInteger b2 = BigInteger.ModPowMonty(b1, e, bigInteger1, false);
      if (!b2.Equals(bigInteger2))
      {
        int num = 0;
        do
        {
          if (!b2.Equals(bigInteger3))
          {
            if (++num != lowestSetBitMaskFirst)
              b2 = BigInteger.ModPowMonty(b2, BigInteger.Two, bigInteger1, false);
            else
              goto label_10;
          }
          else
            goto label_8;
        }
        while (!b2.Equals(bigInteger2));
        goto label_11;
      }
label_8:;
    }
    while (--val2 > 0);
    goto label_12;
label_10:
    return false;
label_11:
    return false;
label_12:
    return true;
  }

  public long LongValue
  {
    get
    {
      if (this.sign == 0)
        return 0;
      int length = this.magnitude.Length;
      long num = (long) this.magnitude[length - 1] & (long) uint.MaxValue;
      if (length > 1)
        num |= ((long) this.magnitude[length - 2] & (long) uint.MaxValue) << 32 /*0x20*/;
      return this.sign >= 0 ? num : -num;
    }
  }

  public long LongValueExact
  {
    get
    {
      if (this.BitLength > 63 /*0x3F*/)
        throw new ArithmeticException("BigInteger out of long range");
      return this.LongValue;
    }
  }

  public BigInteger Max(BigInteger value) => this.CompareTo(value) <= 0 ? value : this;

  public BigInteger Min(BigInteger value) => this.CompareTo(value) >= 0 ? value : this;

  public BigInteger Mod(BigInteger m)
  {
    BigInteger bigInteger = m.sign >= 1 ? this.Remainder(m) : throw new ArithmeticException("Modulus must be positive");
    return bigInteger.sign < 0 ? bigInteger.Add(m) : bigInteger;
  }

  public BigInteger ModInverse(BigInteger m)
  {
    if (m.sign < 1)
      throw new ArithmeticException("Modulus must be positive");
    if (m.QuickPow2Check())
      return this.ModInversePow2(m);
    BigInteger u1Out;
    if (!BigInteger.ExtEuclid(this.Remainder(m), m, out u1Out).Equals(BigInteger.One))
      throw new ArithmeticException("Numbers not relatively prime.");
    if (u1Out.sign < 0)
      u1Out = u1Out.Add(m);
    return u1Out;
  }

  private BigInteger ModInversePow2(BigInteger m)
  {
    if (!this.TestBit(0))
      throw new ArithmeticException("Numbers not relatively prime.");
    int num1 = m.BitLength - 1;
    long num2 = (long) Org.BouncyCastle.Math.Raw.Mod.Inverse64((ulong) this.LongValue);
    if (num1 < 64 /*0x40*/)
      num2 &= (1L << num1) - 1L;
    BigInteger bigInteger = BigInteger.ValueOf(num2);
    if (num1 > 64 /*0x40*/)
    {
      BigInteger val = this.Remainder(m);
      int num3 = 64 /*0x40*/;
      do
      {
        BigInteger n = bigInteger.Multiply(val).Remainder(m);
        bigInteger = bigInteger.Multiply(BigInteger.Two.Subtract(n)).Remainder(m);
        num3 <<= 1;
      }
      while (num3 < num1);
    }
    if (bigInteger.sign < 0)
      bigInteger = bigInteger.Add(m);
    return bigInteger;
  }

  private static BigInteger ExtEuclid(BigInteger a, BigInteger b, out BigInteger u1Out)
  {
    BigInteger bigInteger1 = BigInteger.One;
    BigInteger bigInteger2 = BigInteger.Zero;
    BigInteger bigInteger3 = a;
    BigInteger val = b;
    if (val.sign > 0)
    {
      while (true)
      {
        BigInteger[] bigIntegerArray = bigInteger3.DivideAndRemainder(val);
        bigInteger3 = val;
        val = bigIntegerArray[1];
        BigInteger bigInteger4 = bigInteger1;
        bigInteger1 = bigInteger2;
        if (val.sign > 0)
          bigInteger2 = bigInteger4.Subtract(bigInteger2.Multiply(bigIntegerArray[0]));
        else
          break;
      }
    }
    u1Out = bigInteger1;
    return bigInteger3;
  }

  private static void ZeroOut(int[] x) => Array.Clear((Array) x, 0, x.Length);

  public BigInteger ModPow(BigInteger e, BigInteger m)
  {
    if (m.sign < 1)
      throw new ArithmeticException("Modulus must be positive");
    if (m.Equals(BigInteger.One))
      return BigInteger.Zero;
    if (e.sign == 0)
      return BigInteger.One;
    if (this.sign == 0)
      return BigInteger.Zero;
    int num = e.sign < 0 ? 1 : 0;
    if (num != 0)
      e = e.Negate();
    BigInteger b = this.Mod(m);
    if (!e.Equals(BigInteger.One))
      b = ((int) m.magnitude[m.magnitude.Length - 1] & 1) != 0 ? BigInteger.ModPowMonty(b, e, m, true) : BigInteger.ModPowBarrett(b, e, m);
    if (num != 0)
      b = b.ModInverse(m);
    return b;
  }

  private static BigInteger ModPowBarrett(BigInteger b, BigInteger e, BigInteger m)
  {
    int length1 = m.magnitude.Length;
    BigInteger mr = BigInteger.One.ShiftLeft(length1 + 1 << 5);
    BigInteger yu = BigInteger.One.ShiftLeft(length1 << 6).Divide(m);
    int extraBits = 0;
    int bitLength = e.BitLength;
    while (bitLength > BigInteger.ExpWindowThresholds[extraBits])
      ++extraBits;
    int length2 = 1 << extraBits;
    BigInteger[] bigIntegerArray = new BigInteger[length2];
    bigIntegerArray[0] = b;
    BigInteger val = BigInteger.ReduceBarrett(b.Square(), m, mr, yu);
    for (int index = 1; index < length2; ++index)
      bigIntegerArray[index] = BigInteger.ReduceBarrett(bigIntegerArray[index - 1].Multiply(val), m, mr, yu);
    int[] windowList = BigInteger.GetWindowList(e.magnitude, extraBits);
    int num1 = windowList[0];
    int num2 = num1 & (int) byte.MaxValue;
    int num3 = num1 >> 8;
    BigInteger bigInteger;
    if (num2 == 1)
    {
      bigInteger = val;
      --num3;
    }
    else
      bigInteger = bigIntegerArray[num2 >> 1];
    int num4 = 1;
    while (true)
    {
      int[] numArray = windowList;
      int index1 = num4++;
      int num5;
      if ((num5 = numArray[index1]) != -1)
      {
        int b1 = num5 & (int) byte.MaxValue;
        int num6 = num3 + BigInteger.BitLen((byte) b1);
        for (int index2 = 0; index2 < num6; ++index2)
          bigInteger = BigInteger.ReduceBarrett(bigInteger.Square(), m, mr, yu);
        bigInteger = BigInteger.ReduceBarrett(bigInteger.Multiply(bigIntegerArray[b1 >> 1]), m, mr, yu);
        num3 = num5 >> 8;
      }
      else
        break;
    }
    for (int index = 0; index < num3; ++index)
      bigInteger = BigInteger.ReduceBarrett(bigInteger.Square(), m, mr, yu);
    return bigInteger;
  }

  private static BigInteger ReduceBarrett(
    BigInteger x,
    BigInteger m,
    BigInteger mr,
    BigInteger yu)
  {
    int bitLength1 = x.BitLength;
    int bitLength2 = m.BitLength;
    if (bitLength1 < bitLength2)
      return x;
    if (bitLength1 - bitLength2 > 1)
    {
      int length = m.magnitude.Length;
      BigInteger bigInteger1 = x.DivideWords(length - 1).Multiply(yu).DivideWords(length + 1);
      BigInteger bigInteger2 = x.RemainderWords(length + 1);
      BigInteger val = m;
      BigInteger n = bigInteger1.Multiply(val).RemainderWords(length + 1);
      x = bigInteger2.Subtract(n);
      if (x.sign < 0)
        x = x.Add(mr);
    }
    while (x.CompareTo(m) >= 0)
      x = x.Subtract(m);
    return x;
  }

  private static BigInteger ModPowMonty(BigInteger b, BigInteger e, BigInteger m, bool convert)
  {
    int length1 = m.magnitude.Length;
    int n = 32 /*0x20*/ * length1;
    bool smallMontyModulus = m.BitLength + 2 <= n;
    uint mquote = m.GetMQuote();
    if (convert)
      b = b.ShiftLeft(n).Remainder(m);
    uint[] a = new uint[length1 + 1];
    uint[] data = b.magnitude;
    if (data.Length < length1)
    {
      uint[] numArray = new uint[length1];
      data.CopyTo((Array) numArray, length1 - data.Length);
      data = numArray;
    }
    int extraBits = 0;
    if (e.magnitude.Length > 1 || e.BitCount > 2)
    {
      int bitLength = e.BitLength;
      while (bitLength > BigInteger.ExpWindowThresholds[extraBits])
        ++extraBits;
    }
    int length2 = 1 << extraBits;
    uint[][] numArray1 = new uint[length2][];
    numArray1[0] = data;
    uint[] numArray2 = Arrays.Clone(data);
    BigInteger.SquareMonty(a, numArray2, m.magnitude, mquote, smallMontyModulus);
    for (int index = 1; index < length2; ++index)
    {
      numArray1[index] = Arrays.Clone(numArray1[index - 1]);
      BigInteger.MultiplyMonty(a, numArray1[index], numArray2, m.magnitude, mquote, smallMontyModulus);
    }
    int[] windowList = BigInteger.GetWindowList(e.magnitude, extraBits);
    int num1 = windowList[0];
    int num2 = num1 & (int) byte.MaxValue;
    int num3 = num1 >> 8;
    uint[] numArray3;
    if (num2 == 1)
    {
      numArray3 = numArray2;
      --num3;
    }
    else
      numArray3 = Arrays.Clone(numArray1[num2 >> 1]);
    int num4 = 1;
    while (true)
    {
      int[] numArray4 = windowList;
      int index1 = num4++;
      int num5;
      if ((num5 = numArray4[index1]) != -1)
      {
        int b1 = num5 & (int) byte.MaxValue;
        int num6 = num3 + BigInteger.BitLen((byte) b1);
        for (int index2 = 0; index2 < num6; ++index2)
          BigInteger.SquareMonty(a, numArray3, m.magnitude, mquote, smallMontyModulus);
        BigInteger.MultiplyMonty(a, numArray3, numArray1[b1 >> 1], m.magnitude, mquote, smallMontyModulus);
        num3 = num5 >> 8;
      }
      else
        break;
    }
    for (int index = 0; index < num3; ++index)
      BigInteger.SquareMonty(a, numArray3, m.magnitude, mquote, smallMontyModulus);
    if (convert)
      BigInteger.MontgomeryReduce(numArray3, m.magnitude, mquote);
    else if (smallMontyModulus && BigInteger.CompareTo(0, numArray3, 0, m.magnitude) >= 0)
      BigInteger.Subtract(0, numArray3, 0, m.magnitude);
    return new BigInteger(1, numArray3, true);
  }

  private static int[] GetWindowList(uint[] mag, int extraBits)
  {
    int v = (int) mag[0];
    int num1 = BigInteger.BitLen((uint) v);
    int[] windowList = new int[((mag.Length - 1 << 5) + num1) / (1 + extraBits) + 2];
    int num2 = 0;
    int num3 = 33 - num1;
    int num4 = v << num3;
    int mult = 1;
    int num5 = 1 << extraBits;
    int zeroes = 0;
    int index1 = 0;
    while (true)
    {
      for (; num3 < 32 /*0x20*/; ++num3)
      {
        if (mult < num5)
          mult = mult << 1 | num4 >>> 31 /*0x1F*/;
        else if (num4 < 0)
        {
          windowList[num2++] = BigInteger.CreateWindowEntry(mult, zeroes);
          mult = 1;
          zeroes = 0;
        }
        else
          ++zeroes;
        num4 <<= 1;
      }
      if (++index1 != mag.Length)
      {
        num4 = (int) mag[index1];
        num3 = 0;
      }
      else
        break;
    }
    int[] numArray = windowList;
    int index2 = num2;
    int index3 = index2 + 1;
    int windowEntry = BigInteger.CreateWindowEntry(mult, zeroes);
    numArray[index2] = windowEntry;
    windowList[index3] = -1;
    return windowList;
  }

  private static int CreateWindowEntry(int mult, int zeroes)
  {
    while ((mult & 1) == 0)
    {
      mult >>= 1;
      ++zeroes;
    }
    return mult | zeroes << 8;
  }

  private static uint[] Square(uint[] w, uint[] x)
  {
    int index1 = w.Length - 1;
    for (int index2 = x.Length - 1; index2 > 0; --index2)
    {
      ulong num1 = (ulong) x[index2];
      ulong num2 = num1 * num1 + (ulong) w[index1];
      w[index1] = (uint) num2;
      ulong num3 = num2 >> 32 /*0x20*/;
      for (int index3 = index2 - 1; index3 >= 0; --index3)
      {
        ulong num4 = num1 * (ulong) x[index3];
        ulong num5 = num3 + (((ulong) w[--index1] & (ulong) uint.MaxValue) + (ulong) ((uint) num4 << 1));
        w[index1] = (uint) num5;
        num3 = (num5 >> 32 /*0x20*/) + (num4 >> 31 /*0x1F*/);
      }
      int index4;
      ulong num6 = num3 + (ulong) w[index4 = index1 - 1];
      w[index4] = (uint) num6;
      int index5;
      if ((index5 = index4 - 1) >= 0)
        w[index5] = (uint) (num6 >> 32 /*0x20*/);
      index1 = index5 + index2;
    }
    ulong num7 = (ulong) x[0];
    ulong num8 = num7 * num7 + (ulong) w[index1];
    w[index1] = (uint) num8;
    int index6;
    if ((index6 = index1 - 1) >= 0)
      w[index6] += (uint) (num8 >> 32 /*0x20*/);
    return w;
  }

  private static uint[] Multiply(uint[] x, uint[] y, uint[] z)
  {
    int length = z.Length;
    if (length < 1)
      return x;
    int index1 = x.Length - y.Length;
    do
    {
      long num1 = (long) z[--length] & (long) uint.MaxValue;
      long num2 = 0;
      if (num1 != 0L)
        goto label_6;
label_3:
      --index1;
      if (index1 >= 0)
        x[index1] = (uint) num2;
      continue;
label_6:
      for (int index2 = y.Length - 1; index2 >= 0; --index2)
      {
        long num3 = num2 + (num1 * ((long) y[index2] & (long) uint.MaxValue) + ((long) x[index1 + index2] & (long) uint.MaxValue));
        x[index1 + index2] = (uint) num3;
        num2 = num3 >>> 32 /*0x20*/;
      }
      goto label_3;
    }
    while (length > 0);
    return x;
  }

  private uint GetMQuote()
  {
    return Org.BouncyCastle.Math.Raw.Mod.Inverse32((uint) -(int) this.magnitude[this.magnitude.Length - 1]);
  }

  private static void MontgomeryReduce(uint[] x, uint[] m, uint mDash)
  {
    int length = m.Length;
    for (int index1 = length - 1; index1 >= 0; --index1)
    {
      uint num1 = x[length - 1];
      ulong num2 = (ulong) (num1 * mDash);
      ulong num3 = num2 * (ulong) m[length - 1] + (ulong) num1 >> 32 /*0x20*/;
      for (int index2 = length - 2; index2 >= 0; --index2)
      {
        ulong num4 = num3 + (num2 * (ulong) m[index2] + (ulong) x[index2]);
        x[index2 + 1] = (uint) num4;
        num3 = num4 >> 32 /*0x20*/;
      }
      x[0] = (uint) num3;
    }
    if (BigInteger.CompareTo(0, x, 0, m) < 0)
      return;
    BigInteger.Subtract(0, x, 0, m);
  }

  private static void MultiplyMonty(
    uint[] a,
    uint[] x,
    uint[] y,
    uint[] m,
    uint mDash,
    bool smallMontyModulus)
  {
    int length = m.Length;
    if (length == 1)
    {
      x[0] = BigInteger.MultiplyMontyNIsOne(x[0], y[0], m[0], mDash);
    }
    else
    {
      uint num1 = y[length - 1];
      ulong num2 = (ulong) x[length - 1];
      ulong num3 = num2 * (ulong) num1;
      ulong num4 = (ulong) ((uint) num3 * mDash);
      ulong num5 = num4 * (ulong) m[length - 1];
      ulong num6 = (num3 + (ulong) (uint) num5 >> 32 /*0x20*/) + (num5 >> 32 /*0x20*/);
      for (int index = length - 2; index >= 0; --index)
      {
        ulong num7 = num2 * (ulong) y[index];
        ulong num8 = num4 * (ulong) m[index];
        ulong num9 = num6 + ((num7 & (ulong) uint.MaxValue) + (ulong) (uint) num8);
        a[index + 2] = (uint) num9;
        num6 = (num9 >> 32 /*0x20*/) + (num7 >> 32 /*0x20*/) + (num8 >> 32 /*0x20*/);
      }
      a[1] = (uint) num6;
      uint num10 = (uint) (num6 >> 32 /*0x20*/);
      for (int index1 = length - 2; index1 >= 0; --index1)
      {
        uint num11 = a[length];
        ulong num12 = (ulong) x[index1];
        ulong num13 = num12 * (ulong) num1;
        ulong num14 = (num13 & (ulong) uint.MaxValue) + (ulong) num11;
        ulong num15 = (ulong) ((uint) num14 * mDash);
        ulong num16 = num15 * (ulong) m[length - 1];
        ulong num17 = (num14 + (ulong) (uint) num16 >> 32 /*0x20*/) + (num13 >> 32 /*0x20*/) + (num16 >> 32 /*0x20*/);
        for (int index2 = length - 2; index2 >= 0; --index2)
        {
          ulong num18 = num12 * (ulong) y[index2];
          ulong num19 = num15 * (ulong) m[index2];
          ulong num20 = num17 + ((num18 & (ulong) uint.MaxValue) + (ulong) (uint) num19 + (ulong) a[index2 + 1]);
          a[index2 + 2] = (uint) num20;
          num17 = (num20 >> 32 /*0x20*/) + (num18 >> 32 /*0x20*/) + (num19 >> 32 /*0x20*/);
        }
        ulong num21 = num17 + (ulong) num10;
        a[1] = (uint) num21;
        num10 = (uint) (num21 >> 32 /*0x20*/);
      }
      a[0] = num10;
      if (!smallMontyModulus && BigInteger.CompareTo(0, a, 0, m) >= 0)
        BigInteger.Subtract(0, a, 0, m);
      Array.Copy((Array) a, 1, (Array) x, 0, length);
    }
  }

  private static void SquareMonty(
    uint[] a,
    uint[] x,
    uint[] m,
    uint mDash,
    bool smallMontyModulus)
  {
    int length = m.Length;
    if (length == 1)
    {
      uint num = x[0];
      x[0] = BigInteger.MultiplyMontyNIsOne(num, num, m[0], mDash);
    }
    else
    {
      ulong num1 = (ulong) x[length - 1];
      ulong num2 = num1 * num1;
      ulong num3 = (ulong) ((uint) num2 * mDash);
      ulong num4 = num3 * (ulong) m[length - 1];
      ulong num5 = (num2 + (ulong) (uint) num4 >> 32 /*0x20*/) + (num4 >> 32 /*0x20*/);
      for (int index = length - 2; index >= 0; --index)
      {
        ulong num6 = num1 * (ulong) x[index];
        ulong num7 = num3 * (ulong) m[index];
        ulong num8 = num5 + ((num7 & (ulong) uint.MaxValue) + (ulong) ((uint) num6 << 1));
        a[index + 2] = (uint) num8;
        num5 = (num8 >> 32 /*0x20*/) + (num6 >> 31 /*0x1F*/) + (num7 >> 32 /*0x20*/);
      }
      a[1] = (uint) num5;
      uint num9 = (uint) (num5 >> 32 /*0x20*/);
      for (int index1 = length - 2; index1 >= 0; --index1)
      {
        uint num10 = a[length];
        ulong num11 = (ulong) (num10 * mDash);
        ulong num12 = num11 * (ulong) m[length - 1] + (ulong) num10 >> 32 /*0x20*/;
        for (int index2 = length - 2; index2 > index1; --index2)
        {
          ulong num13 = num12 + (num11 * (ulong) m[index2] + (ulong) a[index2 + 1]);
          a[index2 + 2] = (uint) num13;
          num12 = num13 >> 32 /*0x20*/;
        }
        ulong num14 = (ulong) x[index1];
        ulong num15 = num14 * num14;
        ulong num16 = num11 * (ulong) m[index1];
        ulong num17 = num12 + ((num15 & (ulong) uint.MaxValue) + (ulong) (uint) num16 + (ulong) a[index1 + 1]);
        a[index1 + 2] = (uint) num17;
        ulong num18 = (num17 >> 32 /*0x20*/) + (num15 >> 32 /*0x20*/) + (num16 >> 32 /*0x20*/);
        for (int index3 = index1 - 1; index3 >= 0; --index3)
        {
          ulong num19 = num14 * (ulong) x[index3];
          ulong num20 = num11 * (ulong) m[index3];
          ulong num21 = num18 + ((num20 & (ulong) uint.MaxValue) + (ulong) ((uint) num19 << 1) + (ulong) a[index3 + 1]);
          a[index3 + 2] = (uint) num21;
          num18 = (num21 >> 32 /*0x20*/) + (num19 >> 31 /*0x1F*/) + (num20 >> 32 /*0x20*/);
        }
        ulong num22 = num18 + (ulong) num9;
        a[1] = (uint) num22;
        num9 = (uint) (num22 >> 32 /*0x20*/);
      }
      a[0] = num9;
      if (!smallMontyModulus && BigInteger.CompareTo(0, a, 0, m) >= 0)
        BigInteger.Subtract(0, a, 0, m);
      Array.Copy((Array) a, 1, (Array) x, 0, length);
    }
  }

  private static uint MultiplyMontyNIsOne(uint x, uint y, uint m, uint mDash)
  {
    ulong num1 = (ulong) x * (ulong) y;
    uint num2 = (uint) num1 * mDash;
    ulong num3 = (ulong) m;
    ulong num4 = num3 * (ulong) num2;
    ulong num5 = (num1 + (ulong) (uint) num4 >> 32 /*0x20*/) + (num4 >> 32 /*0x20*/);
    if (num5 > num3)
      num5 -= num3;
    return (uint) num5;
  }

  public BigInteger Multiply(BigInteger val)
  {
    if (val == this)
      return this.Square();
    if ((this.sign & val.sign) == 0)
      return BigInteger.Zero;
    if (val.QuickPow2Check())
    {
      BigInteger bigInteger = this.ShiftLeft(val.Abs().BitLength - 1);
      return val.sign <= 0 ? bigInteger.Negate() : bigInteger;
    }
    if (this.QuickPow2Check())
    {
      BigInteger bigInteger = val.ShiftLeft(this.Abs().BitLength - 1);
      return this.sign <= 0 ? bigInteger.Negate() : bigInteger;
    }
    uint[] numArray = new uint[this.magnitude.Length + val.magnitude.Length];
    BigInteger.Multiply(numArray, this.magnitude, val.magnitude);
    return new BigInteger(this.sign ^ val.sign ^ 1, numArray, true);
  }

  public BigInteger Square()
  {
    if (this.sign == 0)
      return BigInteger.Zero;
    if (this.QuickPow2Check())
      return this.ShiftLeft(this.Abs().BitLength - 1);
    int length = this.magnitude.Length << 1;
    if (this.magnitude[0] >> 16 /*0x10*/ == 0U)
      --length;
    uint[] numArray = new uint[length];
    BigInteger.Square(numArray, this.magnitude);
    return new BigInteger(1, numArray, false);
  }

  public BigInteger Negate()
  {
    return this.sign == 0 ? this : new BigInteger(-this.sign, this.magnitude, false);
  }

  public BigInteger NextProbablePrime()
  {
    if (this.sign < 0)
      throw new ArithmeticException("Cannot be called on value < 0");
    if (this.CompareTo(BigInteger.Two) < 0)
      return BigInteger.Two;
    BigInteger bigInteger = this.Inc().SetBit(0);
    while (!bigInteger.CheckProbablePrime(100, (Random) SecureRandom.ArbitraryRandom, false))
      bigInteger = bigInteger.Add(BigInteger.Two);
    return bigInteger;
  }

  public BigInteger Not() => this.Inc().Negate();

  public BigInteger Pow(int exp)
  {
    if (exp <= 0)
    {
      if (exp < 0)
        throw new ArithmeticException("Negative exponent");
      return BigInteger.One;
    }
    if (this.sign == 0)
      return this;
    if (this.QuickPow2Check())
    {
      long n = (long) exp * (long) (this.BitLength - 1);
      return n <= (long) int.MaxValue ? BigInteger.One.ShiftLeft((int) n) : throw new ArithmeticException("Result too large");
    }
    BigInteger bigInteger = BigInteger.One;
    BigInteger val = this;
    while (true)
    {
      if ((exp & 1) == 1)
        goto label_13;
label_11:
      exp >>= 1;
      if (exp != 0)
      {
        val = val.Multiply(val);
        continue;
      }
      break;
label_13:
      bigInteger = bigInteger.Multiply(val);
      goto label_11;
    }
    return bigInteger;
  }

  public static BigInteger ProbablePrime(int bitLength, Random random)
  {
    return new BigInteger(bitLength, 100, random);
  }

  private int Remainder(int m)
  {
    long num1 = 0;
    for (int index = 0; index < this.magnitude.Length; ++index)
    {
      long num2 = (long) this.magnitude[index];
      num1 = (num1 << 32 /*0x20*/ | num2) % (long) m;
    }
    return (int) num1;
  }

  private static uint[] Remainder(uint[] x, uint[] y)
  {
    int index1 = 0;
    while (index1 < x.Length && x[index1] == 0U)
      ++index1;
    int index2 = 0;
    while (index2 < y.Length && y[index2] == 0U)
      ++index2;
    int num1 = BigInteger.CompareNoLeadingZeroes(index1, x, index2, y);
    if (num1 > 0)
    {
      int num2 = BigInteger.CalcBitLength(1, index2, y);
      int num3 = BigInteger.CalcBitLength(1, index1, x);
      int n1 = num3 - num2;
      int index3 = 0;
      int num4 = num2;
      uint[] numArray;
      if (n1 > 0)
      {
        numArray = BigInteger.ShiftLeft(y, n1);
        num4 += n1;
      }
      else
      {
        int length = y.Length - index2;
        numArray = new uint[length];
        Array.Copy((Array) y, index2, (Array) numArray, 0, length);
      }
label_23:
      if (num4 < num3 || BigInteger.CompareNoLeadingZeroes(index1, x, index3, numArray) >= 0)
      {
        BigInteger.Subtract(index1, x, index3, numArray);
        while (x[index1] == 0U)
        {
          if (++index1 == x.Length)
            return x;
        }
        num3 = 32 /*0x20*/ * (x.Length - index1 - 1) + BigInteger.BitLen(x[index1]);
        if (num3 <= num2)
        {
          if (num3 < num2)
            return x;
          num1 = BigInteger.CompareNoLeadingZeroes(index1, x, index2, y);
          if (num1 <= 0)
            goto label_26;
        }
      }
      int n2 = num4 - num3;
      if (n2 == 1 && numArray[index3] >> 1 > x[index1])
        ++n2;
      if (n2 < 2)
      {
        BigInteger.ShiftRightOneInPlace(index3, numArray);
        --num4;
      }
      else
      {
        BigInteger.ShiftRightInPlace(index3, numArray, n2);
        num4 -= n2;
      }
      while (numArray[index3] == 0U)
        ++index3;
      goto label_23;
    }
label_26:
    if (num1 == 0)
      Array.Clear((Array) x, index1, x.Length - index1);
    return x;
  }

  public BigInteger Remainder(BigInteger n)
  {
    if (n.sign == 0)
      throw new ArithmeticException("Division by zero error");
    if (this.sign == 0)
      return BigInteger.Zero;
    if (n.magnitude.Length == 1)
    {
      int m = (int) n.magnitude[0];
      if (m > 0)
      {
        if (m == 1)
          return BigInteger.Zero;
        int num = this.Remainder(m);
        if (num == 0)
          return BigInteger.Zero;
        return new BigInteger(this.sign, new uint[1]
        {
          (uint) num
        }, false);
      }
    }
    return BigInteger.CompareNoLeadingZeroes(0, this.magnitude, 0, n.magnitude) < 0 ? this : new BigInteger(this.sign, !n.QuickPow2Check() ? BigInteger.Remainder((uint[]) this.magnitude.Clone(), n.magnitude) : this.LastNBits(n.Abs().BitLength - 1), true);
  }

  private uint[] LastNBits(int n)
  {
    if (n < 1)
      return BigInteger.ZeroMagnitude;
    int length = System.Math.Min((n + 32 /*0x20*/ - 1) / 32 /*0x20*/, this.magnitude.Length);
    uint[] destinationArray = new uint[length];
    Array.Copy((Array) this.magnitude, this.magnitude.Length - length, (Array) destinationArray, 0, length);
    int num = (length << 5) - n;
    if (num > 0)
      destinationArray[0] &= uint.MaxValue >> num;
    return destinationArray;
  }

  private BigInteger DivideWords(int w)
  {
    int length = this.magnitude.Length;
    if (w >= length)
      return BigInteger.Zero;
    uint[] numArray = new uint[length - w];
    Array.Copy((Array) this.magnitude, 0, (Array) numArray, 0, length - w);
    return new BigInteger(this.sign, numArray, false);
  }

  private BigInteger RemainderWords(int w)
  {
    int length = this.magnitude.Length;
    if (w >= length)
      return this;
    uint[] numArray = new uint[w];
    Array.Copy((Array) this.magnitude, length - w, (Array) numArray, 0, w);
    return new BigInteger(this.sign, numArray, false);
  }

  private static uint[] ShiftLeft(uint[] mag, int n)
  {
    int num1 = n >>> 5;
    int num2 = n & 31 /*0x1F*/;
    int length = mag.Length;
    uint[] numArray;
    if (num2 == 0)
    {
      numArray = new uint[length + num1];
      mag.CopyTo((Array) numArray, 0);
    }
    else
    {
      int index1 = 0;
      int num3 = 32 /*0x20*/ - num2;
      uint num4 = mag[0] >> num3;
      if (num4 != 0U)
      {
        numArray = new uint[length + num1 + 1];
        numArray[index1++] = num4;
      }
      else
        numArray = new uint[length + num1];
      uint num5 = mag[0];
      for (int index2 = 0; index2 < length - 1; ++index2)
      {
        uint num6 = mag[index2 + 1];
        numArray[index1++] = num5 << num2 | num6 >> num3;
        num5 = num6;
      }
      numArray[index1] = mag[length - 1] << num2;
    }
    return numArray;
  }

  private static int ShiftLeftOneInPlace(int[] x, int carry)
  {
    int length = x.Length;
    while (--length >= 0)
    {
      uint num = (uint) x[length];
      x[length] = (int) num << 1 | carry;
      carry = (int) (num >> 31 /*0x1F*/);
    }
    return carry;
  }

  public BigInteger ShiftLeft(int n)
  {
    if (this.sign == 0 || this.magnitude.Length == 0)
      return BigInteger.Zero;
    if (n == 0)
      return this;
    if (n < 0)
      return this.ShiftRight(-n);
    BigInteger bigInteger = new BigInteger(this.sign, BigInteger.ShiftLeft(this.magnitude, n), true);
    if (this.nBits != -1)
      bigInteger.nBits = this.sign > 0 ? this.nBits : this.nBits + n;
    if (this.nBitLength != -1)
      bigInteger.nBitLength = this.nBitLength + n;
    return bigInteger;
  }

  private static void ShiftRightInPlace(int start, uint[] mag, int n)
  {
    int index1 = (n >>> 5) + start;
    int num1 = n & 31 /*0x1F*/;
    int index2 = mag.Length - 1;
    if (index1 != start)
    {
      int num2 = index1 - start;
      for (int index3 = index2; index3 >= index1; --index3)
        mag[index3] = mag[index3 - num2];
      for (int index4 = index1 - 1; index4 >= start; --index4)
        mag[index4] = 0U;
    }
    if (num1 == 0)
      return;
    int num3 = 32 /*0x20*/ - num1;
    uint num4 = mag[index2];
    for (int index5 = index2; index5 > index1; --index5)
    {
      uint num5 = mag[index5 - 1];
      mag[index5] = num4 >> num1 | num5 << num3;
      num4 = num5;
    }
    mag[index1] = mag[index1] >> num1;
  }

  private static void ShiftRightOneInPlace(int start, uint[] mag)
  {
    int length = mag.Length;
    uint num1 = mag[length - 1];
    while (--length > start)
    {
      uint num2 = mag[length - 1];
      mag[length] = num1 >> 1 | num2 << 31 /*0x1F*/;
      num1 = num2;
    }
    mag[start] = mag[start] >> 1;
  }

  public BigInteger ShiftRight(int n)
  {
    if (n == 0)
      return this;
    if (n < 0)
      return this.ShiftLeft(-n);
    if (n >= this.BitLength)
      return this.sign >= 0 ? BigInteger.Zero : BigInteger.One.Negate();
    int length = this.BitLength - n + 31 /*0x1F*/ >> 5;
    uint[] numArray = new uint[length];
    int num1 = n >> 5;
    int num2 = n & 31 /*0x1F*/;
    if (num2 == 0)
    {
      Array.Copy((Array) this.magnitude, 0, (Array) numArray, 0, numArray.Length);
    }
    else
    {
      int num3 = 32 /*0x20*/ - num2;
      int index1 = this.magnitude.Length - 1 - num1;
      for (int index2 = length - 1; index2 >= 0; --index2)
      {
        numArray[index2] = this.magnitude[index1--] >> num2;
        if (index1 >= 0)
          numArray[index2] |= this.magnitude[index1] << num3;
      }
    }
    return new BigInteger(this.sign, numArray, false);
  }

  public int SignValue => this.sign;

  private static uint[] Subtract(int xStart, uint[] x, int yStart, uint[] y)
  {
    int length1 = x.Length;
    int length2 = y.Length;
    int num1 = 0;
    do
    {
      long num2 = ((long) x[--length1] & (long) uint.MaxValue) - ((long) y[--length2] & (long) uint.MaxValue) + (long) num1;
      x[length1] = (uint) num2;
      num1 = (int) (num2 >> 63 /*0x3F*/);
    }
    while (length2 > yStart);
    if (num1 != 0)
    {
      while (--x[--length1] == uint.MaxValue)
        ;
    }
    return x;
  }

  public BigInteger Subtract(BigInteger n)
  {
    if (n.sign == 0)
      return this;
    if (this.sign == 0)
      return n.Negate();
    if (this.sign != n.sign)
      return this.Add(n.Negate());
    int num = BigInteger.CompareNoLeadingZeroes(0, this.magnitude, 0, n.magnitude);
    if (num == 0)
      return BigInteger.Zero;
    BigInteger bigInteger1;
    BigInteger bigInteger2;
    if (num < 0)
    {
      bigInteger1 = n;
      bigInteger2 = this;
    }
    else
    {
      bigInteger1 = this;
      bigInteger2 = n;
    }
    return new BigInteger(this.sign * num, BigInteger.DoSubBigLil(bigInteger1.magnitude, bigInteger2.magnitude), true);
  }

  private static uint[] DoSubBigLil(uint[] bigMag, uint[] lilMag)
  {
    return BigInteger.Subtract(0, (uint[]) bigMag.Clone(), 0, lilMag);
  }

  public int GetLengthofByteArray() => BigInteger.GetBytesLength(this.BitLength + 1);

  public int GetLengthofByteArrayUnsigned()
  {
    return BigInteger.GetBytesLength(this.sign < 0 ? this.BitLength + 1 : this.BitLength);
  }

  public byte[] ToByteArray() => this.ToByteArray(false);

  public byte[] ToByteArrayUnsigned() => this.ToByteArray(true);

  private byte[] ToByteArray(bool unsigned)
  {
    if (this.sign == 0)
      return !unsigned ? new byte[1] : BigInteger.ZeroEncoding;
    byte[] bs1 = new byte[BigInteger.GetBytesLength(!unsigned || this.sign <= 0 ? this.BitLength + 1 : this.BitLength)];
    int length1 = this.magnitude.Length;
    int length2 = bs1.Length;
    int num1;
    if (this.sign > 0)
    {
      while (length1 > 1)
      {
        int n = (int) this.magnitude[--length1];
        length2 -= 4;
        byte[] bs2 = bs1;
        int off = length2;
        Pack.UInt32_To_BE((uint) n, bs2, off);
      }
      uint num2;
      for (num2 = this.magnitude[0]; num2 > (uint) byte.MaxValue; num2 >>= 8)
        bs1[--length2] = (byte) num2;
      bs1[num1 = length2 - 1] = (byte) num2;
    }
    else
    {
      bool flag = true;
      while (length1 > 1)
      {
        uint n = ~this.magnitude[--length1];
        if (flag)
          flag = ++n == 0U;
        length2 -= 4;
        Pack.UInt32_To_BE(n, bs1, length2);
      }
      uint num3 = this.magnitude[0];
      if (flag)
        --num3;
      for (; num3 > (uint) byte.MaxValue; num3 >>= 8)
        bs1[--length2] = (byte) ~num3;
      int num4;
      bs1[num4 = length2 - 1] = (byte) ~num3;
      if (num4 != 0)
        bs1[num1 = num4 - 1] = byte.MaxValue;
    }
    return bs1;
  }

  public override string ToString() => this.ToString(10);

  public string ToString(int radix)
  {
    if (radix <= 8)
    {
      if (radix == 2 || radix == 8)
        goto label_4;
    }
    else if (radix == 10 || radix == 16 /*0x10*/)
      goto label_4;
    throw new FormatException("Only bases 2, 8, 10, 16 are allowed");
label_4:
    if (this.magnitude == null)
      return "null";
    if (this.sign == 0)
      return "0";
    int index1 = 0;
    while (index1 < this.magnitude.Length && this.magnitude[index1] == 0U)
      ++index1;
    if (index1 == this.magnitude.Length)
      return "0";
    StringBuilder sb = new StringBuilder();
    if (this.sign == -1)
      sb.Append('-');
    switch (radix)
    {
      case 2:
        int index2 = index1;
        sb.Append(Convert.ToString((long) this.magnitude[index2], 2));
        while (++index2 < this.magnitude.Length)
          BigInteger.AppendZeroExtendedString(sb, Convert.ToString((long) this.magnitude[index2], 2), 32 /*0x20*/);
        break;
      case 8:
        int num = 1073741823 /*0x3FFFFFFF*/;
        BigInteger bigInteger1 = this.Abs();
        int bitLength = bigInteger1.BitLength;
        List<string> stringList = new List<string>();
        for (; bitLength > 30; bitLength -= 30)
        {
          stringList.Add(Convert.ToString(bigInteger1.IntValue & num, 8));
          bigInteger1 = bigInteger1.ShiftRight(30);
        }
        sb.Append(Convert.ToString(bigInteger1.IntValue, 8));
        for (int index3 = stringList.Count - 1; index3 >= 0; --index3)
          BigInteger.AppendZeroExtendedString(sb, stringList[index3], 10);
        break;
      case 10:
        BigInteger bigInteger2 = this.Abs();
        if (bigInteger2.BitLength < 64 /*0x40*/)
        {
          sb.Append(Convert.ToString(bigInteger2.LongValue, radix));
          break;
        }
        List<BigInteger> moduli = new List<BigInteger>();
        for (BigInteger bigInteger3 = BigInteger.ValueOf((long) radix); bigInteger3.CompareTo(bigInteger2) <= 0; bigInteger3 = bigInteger3.Square())
          moduli.Add(bigInteger3);
        int count = moduli.Count;
        sb.EnsureCapacity(sb.Length + (1 << count));
        BigInteger.ToString(sb, radix, (IList<BigInteger>) moduli, count, bigInteger2);
        break;
      case 16 /*0x10*/:
        int index4 = index1;
        sb.Append(Convert.ToString((long) this.magnitude[index4], 16 /*0x10*/));
        while (++index4 < this.magnitude.Length)
          BigInteger.AppendZeroExtendedString(sb, Convert.ToString((long) this.magnitude[index4], 16 /*0x10*/), 8);
        break;
    }
    return sb.ToString();
  }

  private static void ToString(
    StringBuilder sb,
    int radix,
    IList<BigInteger> moduli,
    int scale,
    BigInteger pos)
  {
    if (pos.BitLength < 64 /*0x40*/)
    {
      string s = Convert.ToString(pos.LongValue, radix);
      if (sb.Length <= 1 && (sb.Length != 1 || sb[0] == '-'))
      {
        if (pos.SignValue == 0)
          return;
        sb.Append(s);
      }
      else
        BigInteger.AppendZeroExtendedString(sb, s, 1 << scale);
    }
    else
    {
      BigInteger[] bigIntegerArray = pos.DivideAndRemainder(moduli[--scale]);
      BigInteger.ToString(sb, radix, moduli, scale, bigIntegerArray[0]);
      BigInteger.ToString(sb, radix, moduli, scale, bigIntegerArray[1]);
    }
  }

  private static void AppendZeroExtendedString(StringBuilder sb, string s, int minLength)
  {
    for (int length = s.Length; length < minLength; ++length)
      sb.Append('0');
    sb.Append(s);
  }

  private static BigInteger CreateUValueOf(ulong value)
  {
    uint num1 = (uint) (value >> 32 /*0x20*/);
    uint num2 = (uint) value;
    if (num1 != 0U)
      return new BigInteger(1, new uint[2]{ num1, num2 }, false);
    if (num2 == 0U)
      return BigInteger.Zero;
    BigInteger uvalueOf = new BigInteger(1, new uint[1]
    {
      num2
    }, false);
    if (((long) num2 & (long) -num2) == (long) num2)
      uvalueOf.nBits = 1;
    return uvalueOf;
  }

  private static BigInteger CreateValueOf(long value)
  {
    if (value >= 0L)
      return BigInteger.CreateUValueOf((ulong) value);
    return value == long.MinValue ? BigInteger.CreateValueOf(~value).Not() : BigInteger.CreateValueOf(-value).Negate();
  }

  public static BigInteger ValueOf(long value)
  {
    return value >= 0L && value < (long) BigInteger.SMALL_CONSTANTS.Length ? BigInteger.SMALL_CONSTANTS[value] : BigInteger.CreateValueOf(value);
  }

  public int GetLowestSetBit()
  {
    return this.sign == 0 ? -1 : this.GetLowestSetBitMaskFirst(uint.MaxValue);
  }

  private int GetLowestSetBitMaskFirst(uint firstWordMaskX)
  {
    int length = this.magnitude.Length;
    int lowestSetBitMaskFirst = 0;
    int num1;
    uint num2 = this.magnitude[num1 = length - 1] & firstWordMaskX;
    while (num2 == 0U)
    {
      num2 = this.magnitude[--num1];
      lowestSetBitMaskFirst += 32 /*0x20*/;
    }
    while (((int) num2 & (int) byte.MaxValue) == 0)
    {
      num2 >>= 8;
      lowestSetBitMaskFirst += 8;
    }
    while (((int) num2 & 1) == 0)
    {
      num2 >>= 1;
      ++lowestSetBitMaskFirst;
    }
    return lowestSetBitMaskFirst;
  }

  public bool TestBit(int n)
  {
    if (n < 0)
      throw new ArithmeticException("Bit position must not be negative");
    if (this.sign < 0)
      return !this.Not().TestBit(n);
    int num = n / 32 /*0x20*/;
    return num < this.magnitude.Length && (this.magnitude[this.magnitude.Length - 1 - num] >> n % 32 /*0x20*/ & 1U) > 0U;
  }

  public BigInteger Or(BigInteger value)
  {
    if (this.sign == 0)
      return value;
    if (value.sign == 0)
      return this;
    uint[] numArray1 = this.sign > 0 ? this.magnitude : this.Add(BigInteger.One).magnitude;
    uint[] numArray2 = value.sign > 0 ? value.magnitude : value.Add(BigInteger.One).magnitude;
    bool flag = this.sign < 0 || value.sign < 0;
    uint[] mag = new uint[System.Math.Max(numArray1.Length, numArray2.Length)];
    int num1 = mag.Length - numArray1.Length;
    int num2 = mag.Length - numArray2.Length;
    for (int index = 0; index < mag.Length; ++index)
    {
      uint num3 = index >= num1 ? numArray1[index - num1] : 0U;
      uint num4 = index >= num2 ? numArray2[index - num2] : 0U;
      if (this.sign < 0)
        num3 = ~num3;
      if (value.sign < 0)
        num4 = ~num4;
      mag[index] = num3 | num4;
      if (flag)
        mag[index] = ~mag[index];
    }
    BigInteger bigInteger = new BigInteger(1, mag, true);
    if (flag)
      bigInteger = bigInteger.Not();
    return bigInteger;
  }

  public BigInteger Xor(BigInteger value)
  {
    if (this.sign == 0)
      return value;
    if (value.sign == 0)
      return this;
    uint[] numArray1 = this.sign > 0 ? this.magnitude : this.Add(BigInteger.One).magnitude;
    uint[] numArray2 = value.sign > 0 ? value.magnitude : value.Add(BigInteger.One).magnitude;
    bool flag = this.sign < 0 && value.sign >= 0 || this.sign >= 0 && value.sign < 0;
    uint[] mag = new uint[System.Math.Max(numArray1.Length, numArray2.Length)];
    int num1 = mag.Length - numArray1.Length;
    int num2 = mag.Length - numArray2.Length;
    for (int index = 0; index < mag.Length; ++index)
    {
      uint num3 = index >= num1 ? numArray1[index - num1] : 0U;
      uint num4 = index >= num2 ? numArray2[index - num2] : 0U;
      if (this.sign < 0)
        num3 = ~num3;
      if (value.sign < 0)
        num4 = ~num4;
      mag[index] = num3 ^ num4;
      if (flag)
        mag[index] = ~mag[index];
    }
    BigInteger bigInteger = new BigInteger(1, mag, true);
    if (flag)
      bigInteger = bigInteger.Not();
    return bigInteger;
  }

  public BigInteger SetBit(int n)
  {
    if (n < 0)
      throw new ArithmeticException("Bit address less than zero");
    if (this.TestBit(n))
      return this;
    return this.sign > 0 && n < this.BitLength - 1 ? this.FlipExistingBit(n) : this.Or(BigInteger.One.ShiftLeft(n));
  }

  public BigInteger ClearBit(int n)
  {
    if (n < 0)
      throw new ArithmeticException("Bit address less than zero");
    if (!this.TestBit(n))
      return this;
    return this.sign > 0 && n < this.BitLength - 1 ? this.FlipExistingBit(n) : this.AndNot(BigInteger.One.ShiftLeft(n));
  }

  public BigInteger FlipBit(int n)
  {
    if (n < 0)
      throw new ArithmeticException("Bit address less than zero");
    return this.sign > 0 && n < this.BitLength - 1 ? this.FlipExistingBit(n) : this.Xor(BigInteger.One.ShiftLeft(n));
  }

  private BigInteger FlipExistingBit(int n)
  {
    uint[] mag = (uint[]) this.magnitude.Clone();
    mag[mag.Length - 1 - (n >> 5)] ^= (uint) (1 << n);
    return new BigInteger(this.sign, mag, false);
  }
}
