// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.SCrypt
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class SCrypt
{
  public static byte[] Generate(byte[] P, byte[] S, int N, int r, int p, int dkLen)
  {
    if (P == null)
      throw new ArgumentNullException("Passphrase P must be provided.");
    if (S == null)
      throw new ArgumentNullException("Salt S must be provided.");
    if (N <= 1 || !SCrypt.IsPowerOf2(N))
      throw new ArgumentException("Cost parameter N must be > 1 and a power of 2.");
    if (r == 1 && N >= 65536 /*0x010000*/)
      throw new ArgumentException("Cost parameter N must be > 1 and < 65536.");
    if (r < 1)
      throw new ArgumentException("Block size r must be >= 1.");
    int num = int.MaxValue / (128 /*0x80*/ * r * 8);
    if (p >= 1 && p <= num)
    {
      if (dkLen < 1)
        throw new ArgumentException("Generated key length dkLen must be >= 1.");
      return SCrypt.MFcrypt(P, S, N, r, p, dkLen);
    }
    throw new ArgumentException($"Parallelisation parameter p must be >= 1 and <= {num.ToString()} (based on block size r of {r.ToString()})");
  }

  private static byte[] MFcrypt(byte[] P, byte[] S, int N, int r, int p, int dkLen)
  {
    int num1 = r * 128 /*0x80*/;
    byte[] numArray1 = SCrypt.SingleIterationPBKDF2(P, S, p * num1);
    uint[] numArray2 = (uint[]) null;
    try
    {
      int length = numArray1.Length >> 2;
      numArray2 = new uint[length];
      Pack.LE_To_UInt32(numArray1, 0, numArray2);
      int d = 0;
      for (int index = N * r; N - d > 2 && index > 1024 /*0x0400*/; index >>= 1)
        ++d;
      int num2 = num1 >> 2;
      for (int BOff = 0; BOff < length; BOff += num2)
        SCrypt.SMix(numArray2, BOff, N, d, r);
      Pack.UInt32_To_LE(numArray2, numArray1, 0);
      return SCrypt.SingleIterationPBKDF2(P, numArray1, dkLen);
    }
    finally
    {
      SCrypt.ClearAll((Array) numArray1, (Array) numArray2);
    }
  }

  private static byte[] SingleIterationPBKDF2(byte[] P, byte[] S, int dkLen)
  {
    Pkcs5S2ParametersGenerator parametersGenerator = new Pkcs5S2ParametersGenerator((IDigest) new Sha256Digest());
    parametersGenerator.Init(P, S, 1);
    return ((KeyParameter) parametersGenerator.GenerateDerivedMacParameters(dkLen * 8)).GetKey();
  }

  private static void SMix(uint[] B, int BOff, int N, int d, int r)
  {
    int num1 = Integers.NumberOfTrailingZeros(N);
    int num2 = N >> d;
    int length1 = 1 << d;
    int num3 = num2 - 1;
    int num4 = d;
    int num5 = num1 - num4;
    int length2 = r * 32 /*0x20*/;
    uint[] X1 = new uint[16 /*0x10*/];
    uint[] numArray1 = new uint[length2];
    uint[] numArray2 = new uint[length2];
    uint[][] numArray3 = new uint[length1][];
    try
    {
      Array.Copy((Array) B, BOff, (Array) numArray2, 0, length2);
      for (int index1 = 0; index1 < length1; ++index1)
      {
        uint[] destinationArray = new uint[num2 * length2];
        numArray3[index1] = destinationArray;
        int destinationIndex1 = 0;
        for (int index2 = 0; index2 < num2; index2 += 2)
        {
          Array.Copy((Array) numArray2, 0, (Array) destinationArray, destinationIndex1, length2);
          int destinationIndex2 = destinationIndex1 + length2;
          SCrypt.BlockMix(numArray2, X1, numArray1, r);
          Array.Copy((Array) numArray1, 0, (Array) destinationArray, destinationIndex2, length2);
          destinationIndex1 = destinationIndex2 + length2;
          SCrypt.BlockMix(numArray1, X1, numArray2, r);
        }
      }
      uint num6 = (uint) (N - 1);
      for (int index = 0; index < N; ++index)
      {
        int num7 = (int) numArray2[length2 - 16 /*0x10*/] & (int) num6;
        uint[] x = numArray3[num7 >> num5];
        int xOff = (num7 & num3) * length2;
        Nat.Xor(length2, x, xOff, numArray2, 0, numArray1, 0);
        SCrypt.BlockMix(numArray1, X1, numArray2, r);
      }
      Array.Copy((Array) numArray2, 0, (Array) B, BOff, length2);
    }
    finally
    {
      SCrypt.ClearAll((Array[]) numArray3);
      SCrypt.ClearAll((Array) numArray2, (Array) X1, (Array) numArray1);
    }
  }

  private static void BlockMix(uint[] B, uint[] X1, uint[] Y, int r)
  {
    Array.Copy((Array) B, B.Length - 16 /*0x10*/, (Array) X1, 0, 16 /*0x10*/);
    int xOff = 0;
    int destinationIndex = 0;
    int num = B.Length >> 1;
    for (int index = 2 * r; index > 0; --index)
    {
      Nat512.XorTo(B, xOff, X1, 0);
      Salsa20Engine.SalsaCore(8, X1, X1);
      Array.Copy((Array) X1, 0, (Array) Y, destinationIndex, 16 /*0x10*/);
      destinationIndex = num + xOff - destinationIndex;
      xOff += 16 /*0x10*/;
    }
  }

  private static void Clear(Array array)
  {
    if (array == null)
      return;
    Array.Clear(array, 0, array.Length);
  }

  private static void ClearAll(params Array[] arrays)
  {
    foreach (Array array in arrays)
      SCrypt.Clear(array);
  }

  private static bool IsPowerOf2(int x) => (x & x - 1) == 0;
}
