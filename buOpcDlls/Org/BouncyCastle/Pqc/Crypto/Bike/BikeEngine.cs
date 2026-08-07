// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Bike.BikeEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Bike;

internal sealed class BikeEngine
{
  private readonly int r;
  private readonly int w;
  private readonly int hw;
  private readonly int t;
  private readonly int nbIter;
  private readonly int tau;
  private readonly BikeRing bikeRing;
  private readonly int L_BYTE;
  private readonly int R_BYTE;
  private readonly int R2_UINT;
  private readonly int R_ULONG;
  private readonly int R2_ULONG;

  internal BikeEngine(int r, int w, int t, int l, int nbIter, int tau)
  {
    this.r = r;
    this.w = w;
    this.t = t;
    this.nbIter = nbIter;
    this.tau = tau;
    this.hw = this.w / 2;
    this.L_BYTE = l / 8;
    this.R_BYTE = r + 7 >> 3;
    this.R2_UINT = 2 * r + 31 /*0x1F*/ >> 5;
    this.R_ULONG = r + 63 /*0x3F*/ >> 6;
    this.R2_ULONG = 2 * r + 63 /*0x3F*/ >> 6;
    this.bikeRing = new BikeRing(r);
  }

  internal int SessionKeySize => this.L_BYTE;

  private ulong[] FunctionH(byte[] seed)
  {
    IXof digest = (IXof) new ShakeDigest(256 /*0x0100*/);
    digest.BlockUpdate(seed, 0, seed.Length);
    ulong[] res = new ulong[2 * this.R_ULONG];
    BikeUtilities.GenerateRandomUlongs(res, 2 * this.r, this.t, digest);
    return res;
  }

  private void FunctionL(ulong[] e01, byte[] c1, int c1Off)
  {
    byte[] numArray = new byte[48 /*0x30*/];
    Sha3Digest.CalculateDigest(e01, 0, 16 /*0x10*/ * this.R_BYTE, numArray, 0, 384);
    Array.Copy((Array) numArray, 0, (Array) c1, c1Off, this.L_BYTE);
  }

  private void FunctionK(byte[] m, byte[] c01, byte[] result)
  {
    byte[] numArray = new byte[48 /*0x30*/];
    Sha3Digest sha3Digest = new Sha3Digest(384);
    sha3Digest.BlockUpdate(m, 0, m.Length);
    sha3Digest.BlockUpdate(c01, 0, c01.Length);
    sha3Digest.DoFinal(numArray, 0);
    Array.Copy((Array) numArray, 0, (Array) result, 0, this.L_BYTE);
  }

  private void FunctionK(byte[] m, byte[] c0, byte[] c1, byte[] result)
  {
    byte[] numArray = new byte[48 /*0x30*/];
    Sha3Digest sha3Digest = new Sha3Digest(384);
    sha3Digest.BlockUpdate(m, 0, m.Length);
    sha3Digest.BlockUpdate(c0, 0, c0.Length);
    sha3Digest.BlockUpdate(c1, 0, c1.Length);
    sha3Digest.DoFinal(numArray, 0);
    Array.Copy((Array) numArray, 0, (Array) result, 0, this.L_BYTE);
  }

  internal void GenKeyPair(byte[] h0, byte[] h1, byte[] sigma, byte[] h, SecureRandom random)
  {
    byte[] numArray1 = new byte[64 /*0x40*/];
    random.NextBytes(numArray1);
    IXof digest = (IXof) new ShakeDigest(256 /*0x0100*/);
    digest.BlockUpdate(numArray1, 0, this.L_BYTE);
    ulong[] numArray2 = this.bikeRing.Create();
    ulong[] numArray3 = this.bikeRing.Create();
    BikeUtilities.GenerateRandomUlongs(numArray2, this.r, this.hw, digest);
    BikeUtilities.GenerateRandomUlongs(numArray3, this.r, this.hw, digest);
    this.bikeRing.EncodeBytes(numArray2, h0);
    this.bikeRing.EncodeBytes(numArray3, h1);
    this.bikeRing.Inv(numArray2, numArray2);
    this.bikeRing.Multiply(numArray2, numArray3, numArray2);
    this.bikeRing.EncodeBytes(numArray2, h);
    Array.Copy((Array) numArray1, this.L_BYTE, (Array) sigma, 0, sigma.Length);
  }

  internal void Encaps(byte[] c01, byte[] k, byte[] h, SecureRandom random)
  {
    byte[] numArray1 = new byte[this.L_BYTE];
    random.NextBytes(numArray1);
    ulong[] numArray2 = this.FunctionH(numArray1);
    this.AlignE01From1To64(numArray2);
    ulong[] numArray3 = this.bikeRing.Create();
    this.bikeRing.DecodeBytes(h, numArray3);
    this.bikeRing.Multiply(numArray3, 0, numArray2, this.R_ULONG, numArray3);
    this.bikeRing.Add(numArray3, numArray2, numArray3);
    this.bikeRing.EncodeBytes(numArray3, c01);
    this.AlignE01From64To8(numArray2);
    this.FunctionL(numArray2, c01, this.R_BYTE);
    Bytes.XorTo(this.L_BYTE, numArray1, 0, c01, this.R_BYTE);
    this.FunctionK(numArray1, c01, k);
  }

  internal void Decaps(byte[] k, byte[] h0, byte[] h1, byte[] sigma, byte[] c0, byte[] c1)
  {
    int[] numArray1 = new int[this.hw];
    int[] numArray2 = new int[this.hw];
    this.ConvertToCompact(numArray1, h0);
    this.ConvertToCompact(numArray2, h1);
    byte[] input = this.BGFDecoder(this.ComputeSyndrome(c0, h0), numArray1, numArray2);
    ulong[] numArray3 = new ulong[2 * this.R_ULONG];
    BikeUtilities.FromBitsToUlongs(numArray3, input, 0, 2 * this.r);
    this.AlignE01From1To64(numArray3);
    this.AlignE01From64To8(numArray3);
    byte[] numArray4 = new byte[this.L_BYTE];
    this.FunctionL(numArray3, numArray4, 0);
    Bytes.XorTo(this.L_BYTE, c1, numArray4);
    this.AlignE01From8To1(numArray3);
    ulong[] b = this.FunctionH(numArray4);
    if (Arrays.AreEqual(numArray3, 0, this.R2_ULONG, b, 0, this.R2_ULONG))
      this.FunctionK(numArray4, c0, c1, k);
    else
      this.FunctionK(sigma, c0, c1, k);
  }

  private byte[] ComputeSyndrome(byte[] c0, byte[] h0)
  {
    ulong[] numArray1 = this.bikeRing.Create();
    ulong[] numArray2 = this.bikeRing.Create();
    this.bikeRing.DecodeBytes(c0, numArray1);
    this.bikeRing.DecodeBytes(h0, numArray2);
    this.bikeRing.Multiply(numArray1, numArray2, numArray1);
    return this.bikeRing.EncodeBitsTransposed(numArray1);
  }

  private byte[] BGFDecoder(byte[] s, int[] h0Compact, int[] h1Compact)
  {
    byte[] e = new byte[2 * this.r];
    int[] fromCompactVersion1 = this.GetColumnFromCompactVersion(h0Compact);
    int[] fromCompactVersion2 = this.GetColumnFromCompactVersion(h1Compact);
    uint[] numArray1 = new uint[this.R2_UINT];
    byte[] ctrs = new byte[this.r];
    uint[] numArray2 = new uint[this.R2_UINT];
    int T1 = BikeEngine.Threshold(BikeUtilities.GetHammingWeight(s), this.r);
    this.BFIter(s, e, T1, h0Compact, h1Compact, fromCompactVersion1, fromCompactVersion2, numArray1, numArray2, ctrs);
    this.BFMaskedIter(s, e, numArray1, (this.hw + 3) / 2, h0Compact, h1Compact, fromCompactVersion1, fromCompactVersion2);
    this.BFMaskedIter(s, e, numArray2, (this.hw + 3) / 2, h0Compact, h1Compact, fromCompactVersion1, fromCompactVersion2);
    for (int index = 1; index < this.nbIter; ++index)
    {
      Array.Clear((Array) numArray1, 0, numArray1.Length);
      int T2 = BikeEngine.Threshold(BikeUtilities.GetHammingWeight(s), this.r);
      this.BFIter2(s, e, T2, h0Compact, h1Compact, fromCompactVersion1, fromCompactVersion2, numArray1, ctrs);
    }
    return BikeUtilities.GetHammingWeight(s) == 0 ? e : (byte[]) null;
  }

  private void BFIter(
    byte[] s,
    byte[] e,
    int T,
    int[] h0Compact,
    int[] h1Compact,
    int[] h0CompactCol,
    int[] h1CompactCol,
    uint[] black,
    uint[] gray,
    byte[] ctrs)
  {
    this.CtrAll(h0CompactCol, s, ctrs);
    int num1 = ((int) ctrs[0] - T >> 31 /*0x1F*/) + 1;
    int num2 = ((int) ctrs[0] - (T - this.tau) >> 31 /*0x1F*/) + 1;
    e[0] ^= (byte) num1;
    black[0] |= (uint) num1;
    gray[0] |= (uint) num2;
    for (int index = 1; index < this.r; ++index)
    {
      int num3 = ((int) ctrs[index] - T >> 31 /*0x1F*/) + 1;
      int num4 = ((int) ctrs[index] - (T - this.tau) >> 31 /*0x1F*/) + 1;
      e[this.r - index] ^= (byte) num3;
      black[index >> 5] |= (uint) (num3 << index);
      gray[index >> 5] |= (uint) (num4 << index);
    }
    this.CtrAll(h1CompactCol, s, ctrs);
    int num5 = ((int) ctrs[0] - T >> 31 /*0x1F*/) + 1;
    int num6 = ((int) ctrs[0] - (T - this.tau) >> 31 /*0x1F*/) + 1;
    e[this.r] ^= (byte) num5;
    black[this.r >> 5] |= (uint) (num5 << this.r);
    gray[this.r >> 5] |= (uint) (num6 << this.r);
    for (int index = 1; index < this.r; ++index)
    {
      int num7 = ((int) ctrs[index] - T >> 31 /*0x1F*/) + 1;
      int num8 = ((int) ctrs[index] - (T - this.tau) >> 31 /*0x1F*/) + 1;
      e[this.r + this.r - index] ^= (byte) num7;
      black[this.r + index >> 5] |= (uint) (num7 << this.r + index);
      gray[this.r + index >> 5] |= (uint) (num8 << this.r + index);
    }
    int num9;
    for (int index = 0; index < black.Length; ++index)
    {
      for (uint i = black[index]; i != 0U; i ^= (uint) (1 << num9))
      {
        num9 = Integers.NumberOfTrailingZeros((int) i);
        this.RecomputeSyndrome(s, (index << 5) + num9, h0Compact, h1Compact);
      }
    }
  }

  private void BFIter2(
    byte[] s,
    byte[] e,
    int T,
    int[] h0Compact,
    int[] h1Compact,
    int[] h0CompactCol,
    int[] h1CompactCol,
    uint[] black,
    byte[] ctrs)
  {
    this.CtrAll(h0CompactCol, s, ctrs);
    int num1 = ((int) ctrs[0] - T >> 31 /*0x1F*/) + 1;
    e[0] ^= (byte) num1;
    black[0] |= (uint) num1;
    for (int index = 1; index < this.r; ++index)
    {
      int num2 = ((int) ctrs[index] - T >> 31 /*0x1F*/) + 1;
      e[this.r - index] ^= (byte) num2;
      black[index >> 5] |= (uint) (num2 << index);
    }
    this.CtrAll(h1CompactCol, s, ctrs);
    int num3 = ((int) ctrs[0] - T >> 31 /*0x1F*/) + 1;
    e[this.r] ^= (byte) num3;
    black[this.r >> 5] |= (uint) (num3 << this.r);
    for (int index = 1; index < this.r; ++index)
    {
      int num4 = ((int) ctrs[index] - T >> 31 /*0x1F*/) + 1;
      e[this.r + this.r - index] ^= (byte) num4;
      black[this.r + index >> 5] |= (uint) (num4 << this.r + index);
    }
    int num5;
    for (int index = 0; index < black.Length; ++index)
    {
      for (uint i = black[index]; i != 0U; i ^= (uint) (1 << num5))
      {
        num5 = Integers.NumberOfTrailingZeros((int) i);
        this.RecomputeSyndrome(s, (index << 5) + num5, h0Compact, h1Compact);
      }
    }
  }

  private void BFMaskedIter(
    byte[] s,
    byte[] e,
    uint[] mask,
    int T,
    int[] h0Compact,
    int[] h1Compact,
    int[] h0CompactCol,
    int[] h1CompactCol)
  {
    uint[] numArray = new uint[this.R2_UINT];
    for (int j = 0; j < this.r; ++j)
    {
      if (((int) mask[j >> 5] & 1 << j) != 0)
      {
        int num1 = (this.Ctr(h0CompactCol, s, j) - T >> 31 /*0x1F*/) + 1;
        int num2 = -j;
        int index = num2 + (num2 >> 31 /*0x1F*/ & this.r);
        e[index] ^= (byte) num1;
        numArray[j >> 5] |= (uint) (num1 << j);
      }
    }
    for (int j = 0; j < this.r; ++j)
    {
      if (((int) mask[this.r + j >> 5] & 1 << this.r + j) != 0)
      {
        int num3 = (this.Ctr(h1CompactCol, s, j) - T >> 31 /*0x1F*/) + 1;
        int num4 = -j;
        int num5 = num4 + (num4 >> 31 /*0x1F*/ & this.r);
        e[this.r + num5] ^= (byte) num3;
        numArray[this.r + j >> 5] |= (uint) (num3 << this.r + j);
      }
    }
    int num;
    for (int index = 0; index < numArray.Length; ++index)
    {
      for (uint i = numArray[index]; i != 0U; i ^= (uint) (1 << num))
      {
        num = Integers.NumberOfTrailingZeros((int) i);
        this.RecomputeSyndrome(s, (index << 5) + num, h0Compact, h1Compact);
      }
    }
  }

  private static int Threshold(int hammingWeight, int r)
  {
    if (r == 12323)
      return BikeEngine.ThresholdFromParameters(hammingWeight, 0.0069722, 13.53, 36);
    if (r == 24659)
      return BikeEngine.ThresholdFromParameters(hammingWeight, 0.005265, 15.2588, 52);
    if (r != 40973)
      throw new ArgumentException();
    return BikeEngine.ThresholdFromParameters(hammingWeight, 0.00402312, 17.8785, 69);
  }

  private static int ThresholdFromParameters(int hammingWeight, double dm, double da, int min)
  {
    return System.Math.Max(min, Convert.ToInt32(System.Math.Floor(dm * (double) hammingWeight + da)));
  }

  private int Ctr(int[] hCompactCol, byte[] s, int j)
  {
    int num1 = 0;
    int index1 = 0;
    for (int index2 = this.hw - 4; index1 <= index2; index1 += 4)
    {
      int num2 = hCompactCol[index1] + j - this.r;
      int num3 = hCompactCol[index1 + 1] + j - this.r;
      int num4 = hCompactCol[index1 + 2] + j - this.r;
      int num5 = hCompactCol[index1 + 3] + j - this.r;
      int index3 = num2 + (num2 >> 31 /*0x1F*/ & this.r);
      int index4 = num3 + (num3 >> 31 /*0x1F*/ & this.r);
      int index5 = num4 + (num4 >> 31 /*0x1F*/ & this.r);
      int index6 = num5 + (num5 >> 31 /*0x1F*/ & this.r);
      num1 = num1 + (int) s[index3] + (int) s[index4] + (int) s[index5] + (int) s[index6];
    }
    for (; index1 < this.hw; ++index1)
    {
      int num6 = hCompactCol[index1] + j - this.r;
      int index7 = num6 + (num6 >> 31 /*0x1F*/ & this.r);
      num1 += (int) s[index7];
    }
    return num1;
  }

  private void CtrAll(int[] hCompactCol, byte[] s, byte[] ctrs)
  {
    int num1 = hCompactCol[0];
    int num2 = this.r - num1;
    Array.Copy((Array) s, num1, (Array) ctrs, 0, num2);
    Array.Copy((Array) s, 0, (Array) ctrs, num2, num1);
    for (int index1 = 1; index1 < this.hw; ++index1)
    {
      int num3 = hCompactCol[index1];
      int num4 = this.r - num3;
      int index2 = 0;
      for (int index3 = num4 - 4; index2 <= index3; index2 += 4)
      {
        ctrs[index2] += s[num3 + index2];
        ctrs[index2 + 1] += s[num3 + index2 + 1];
        ctrs[index2 + 2] += s[num3 + index2 + 2];
        ctrs[index2 + 3] += s[num3 + index2 + 3];
      }
      for (; index2 < num4; ++index2)
        ctrs[index2] += s[num3 + index2];
      int index4 = num4;
      for (int index5 = this.r - 4; index4 <= index5; index4 += 4)
      {
        ctrs[index4] += s[index4 - num4];
        ctrs[index4 + 1] += s[index4 + 1 - num4];
        ctrs[index4 + 2] += s[index4 + 2 - num4];
        ctrs[index4 + 3] += s[index4 + 3 - num4];
      }
      for (; index4 < this.r; ++index4)
        ctrs[index4] += s[index4 - num4];
    }
  }

  private void ConvertToCompact(int[] compactVersion, byte[] h)
  {
    int index1 = 0;
    for (int index2 = 0; index2 < this.R_BYTE; ++index2)
    {
      for (int index3 = 0; index3 < 8 && index2 * 8 + index3 != this.r; ++index3)
      {
        int num1 = (int) h[index2] >> index3 & 1;
        compactVersion[index1] = index2 * 8 + index3 & -num1 | compactVersion[index1] & ~-num1;
        int num2 = index1 + (num1 - this.hw);
        index1 = num2 + (num2 >> 31 /*0x1F*/ & this.hw);
      }
    }
  }

  private int[] GetColumnFromCompactVersion(int[] hCompact)
  {
    int[] fromCompactVersion = new int[this.hw];
    if (hCompact[0] == 0)
    {
      fromCompactVersion[0] = 0;
      for (int index = 1; index < this.hw; ++index)
        fromCompactVersion[index] = this.r - hCompact[this.hw - index];
    }
    else
    {
      for (int index = 0; index < this.hw; ++index)
        fromCompactVersion[index] = this.r - hCompact[this.hw - 1 - index];
    }
    return fromCompactVersion;
  }

  private void RecomputeSyndrome(byte[] syndrome, int index, int[] h0Compact, int[] h1Compact)
  {
    if (index < this.r)
    {
      for (int index1 = 0; index1 < this.hw; ++index1)
      {
        if (h0Compact[index1] <= index)
          syndrome[index - h0Compact[index1]] ^= (byte) 1;
        else
          syndrome[this.r + index - h0Compact[index1]] ^= (byte) 1;
      }
    }
    else
    {
      for (int index2 = 0; index2 < this.hw; ++index2)
      {
        if (h1Compact[index2] <= index - this.r)
          syndrome[index - this.r - h1Compact[index2]] ^= (byte) 1;
        else
          syndrome[this.r - h1Compact[index2] + (index - this.r)] ^= (byte) 1;
      }
    }
  }

  private void AlignE01From1To64(ulong[] e01)
  {
    int num1 = this.r & 63 /*0x3F*/;
    int bits = 64 /*0x40*/ - num1;
    ulong num2 = (ulong) (-1L << num1);
    ulong num3 = e01[this.R_ULONG - 1];
    ulong c = num3 & num2;
    long num4 = (long) Nat.ShiftUpBits64(this.R_ULONG, e01, this.R_ULONG, bits, c);
    e01[this.R_ULONG - 1] = num3 & ~num2;
  }

  private void AlignE01From64To8(ulong[] e01)
  {
    int bits = 64 /*0x40*/ - (8 * this.R_BYTE & 63 /*0x3F*/);
    ulong num = Nat.ShiftDownBits64(this.R_ULONG, e01, this.R_ULONG, bits, 0UL);
    e01[this.R_ULONG - 1] |= num;
  }

  private void AlignE01From8To1(ulong[] e01)
  {
    int num1 = this.r & 63 /*0x3F*/;
    int bits = 8 * this.R_BYTE - this.r;
    ulong num2 = (ulong) (-1L << num1);
    ulong num3 = e01[this.R_ULONG - 1];
    ulong num4 = Nat.ShiftDownBits64(this.R_ULONG, e01, this.R_ULONG, bits, 0UL);
    e01[this.R_ULONG - 1] = (ulong) ((long) num3 & ~(long) num2 | (long) (num3 >> bits) & (long) num2) | num4;
  }
}
