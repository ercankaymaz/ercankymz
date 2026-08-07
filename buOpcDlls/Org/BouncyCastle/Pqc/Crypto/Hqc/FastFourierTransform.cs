// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.FastFourierTransform
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

internal class FastFourierTransform
{
  internal static void FFT(int[] output, int[] elements, int noCoefs, int fft)
  {
    int m = 8;
    int length = 1 << fft;
    int[] numArray1 = new int[length];
    int[] numArray2 = new int[length];
    int[] betaSet = new int[7];
    int[] output1 = new int[128 /*0x80*/];
    int[] numArray3 = new int[128 /*0x80*/];
    int[] numArray4 = new int[7];
    int[] subsetSum = new int[128 /*0x80*/];
    FastFourierTransform.ComputeFFTBetas(numArray4, 8);
    FastFourierTransform.ComputeSubsetSum(subsetSum, numArray4, 7);
    FastFourierTransform.ComputeRadix(numArray1, numArray2, elements, fft, fft);
    for (int index = 0; index < m - 1; ++index)
      betaSet[index] = GFCalculator.mult(numArray4[index], numArray4[index]) ^ numArray4[index];
    FastFourierTransform.ComputeFFTRec(output1, numArray1, (noCoefs + 1) / 2, m - 1, fft - 1, betaSet, fft, m);
    FastFourierTransform.ComputeFFTRec(numArray3, numArray2, noCoefs / 2, m - 1, fft - 1, betaSet, fft, m);
    int index1 = 1 << m - 1;
    Array.Copy((Array) numArray3, 0, (Array) output, index1, index1);
    output[0] = output1[0];
    output[index1] ^= output1[0];
    for (int index2 = 1; index2 < index1; ++index2)
    {
      output[index2] = output1[index2] ^ GFCalculator.mult(subsetSum[index2], numArray3[index2]);
      output[index1 + index2] ^= output[index2];
    }
  }

  internal static void ComputeFFTBetas(int[] betas, int m)
  {
    for (int index = 0; index < m - 1; ++index)
      betas[index] = 1 << m - 1 - index;
  }

  internal static void ComputeSubsetSum(int[] subsetSum, int[] set, int size)
  {
    subsetSum[0] = 0;
    for (int index1 = 0; index1 < size; ++index1)
    {
      for (int index2 = 0; index2 < 1 << index1; ++index2)
        subsetSum[(1 << index1) + index2] = set[index1] ^ subsetSum[index2];
    }
  }

  internal static void ComputeRadix(int[] f0, int[] f1, int[] f, int mf, int fft)
  {
    switch (mf)
    {
      case 1:
        f0[0] = f[0];
        f1[0] = f[1];
        break;
      case 2:
        f0[0] = f[0];
        f0[1] = f[2] ^ f[3];
        f1[0] = f[1] ^ f0[1];
        f1[1] = f[3];
        break;
      case 3:
        f0[0] = f[0];
        f0[2] = f[4] ^ f[6];
        f0[3] = f[6] ^ f[7];
        f1[1] = f[3] ^ f[5] ^ f[7];
        f1[2] = f[5] ^ f[6];
        f1[3] = f[7];
        f0[1] = f[2] ^ f0[2] ^ f1[1];
        f1[0] = f[1] ^ f0[1];
        break;
      case 4:
        f0[4] = f[8] ^ f[12];
        f0[6] = f[12] ^ f[14];
        f0[7] = f[14] ^ f[15];
        f1[5] = f[11] ^ f[13];
        f1[6] = f[13] ^ f[14];
        f1[7] = f[15];
        f0[5] = f[10] ^ f[12] ^ f1[5];
        f1[4] = f[9] ^ f[13] ^ f0[5];
        f0[0] = f[0];
        f1[3] = f[7] ^ f[11] ^ f[15];
        f0[3] = f[6] ^ f[10] ^ f[14] ^ f1[3];
        f0[2] = f[4] ^ f0[4] ^ f0[3] ^ f1[3];
        f1[1] = f[3] ^ f[5] ^ f[9] ^ f[13] ^ f1[3];
        f1[2] = f[3] ^ f1[1] ^ f0[3];
        f0[1] = f[2] ^ f0[2] ^ f1[1];
        f1[0] = f[1] ^ f0[1];
        break;
      default:
        FastFourierTransform.ComputeRadixBig(f0, f1, f, mf, fft);
        break;
    }
  }

  internal static void ComputeRadixBig(int[] f0, int[] f1, int[] f, int mf, int fft)
  {
    int offsetDst = 1 << mf - 2;
    int length = 1 << fft - 2;
    int[] numArray1 = new int[2 * length];
    int[] numArray2 = new int[2 * length];
    int[] numArray3 = new int[length];
    int[] numArray4 = new int[length];
    int[] numArray5 = new int[length];
    int[] numArray6 = new int[length];
    Utils.CopyBytes(f, 3 * offsetDst, numArray1, 0, 2 * offsetDst);
    Utils.CopyBytes(f, 3 * offsetDst, numArray1, offsetDst, 2 * offsetDst);
    Utils.CopyBytes(f, 0, numArray2, 0, 4 * offsetDst);
    for (int index = 0; index < offsetDst; ++index)
    {
      numArray1[index] ^= f[2 * offsetDst + index];
      numArray2[offsetDst + index] ^= numArray1[index];
    }
    FastFourierTransform.ComputeRadix(numArray3, numArray4, numArray1, mf - 1, fft);
    FastFourierTransform.ComputeRadix(numArray5, numArray6, numArray2, mf - 1, fft);
    Utils.CopyBytes(numArray5, 0, f0, 0, 2 * offsetDst);
    Utils.CopyBytes(numArray3, 0, f0, offsetDst, 2 * offsetDst);
    Utils.CopyBytes(numArray6, 0, f1, 0, 2 * offsetDst);
    Utils.CopyBytes(numArray4, 0, f1, offsetDst, 2 * offsetDst);
  }

  internal static void ComputeFFTRec(
    int[] output,
    int[] func,
    int noCoeffs,
    int noOfBetas,
    int noCoeffsPlus,
    int[] betaSet,
    int fft,
    int m)
  {
    int length1 = 1 << fft - 2;
    int length2 = 1 << m - 2;
    int[] numArray1 = new int[length1];
    int[] numArray2 = new int[length1];
    int[] set = new int[m - 2];
    int[] betaSet1 = new int[m - 2];
    int num1 = 1;
    int[] subsetSum = new int[length2];
    int[] output1 = new int[length2];
    int[] numArray3 = new int[length2];
    int[] numArray4 = new int[m - fft + 1];
    int num2 = 0;
    if (noCoeffsPlus == 1)
    {
      for (int index = 0; index < noOfBetas; ++index)
        numArray4[index] = GFCalculator.mult(betaSet[index], func[1]);
      output[0] = func[0];
      int num3 = 1;
      for (int index1 = 0; index1 < noOfBetas; ++index1)
      {
        for (int index2 = 0; index2 < num3; ++index2)
          output[num3 + index2] = output[index2] ^ numArray4[index1];
        num3 <<= 1;
      }
    }
    else
    {
      if (betaSet[noOfBetas - 1] != 1)
      {
        int a = 1;
        num2 = 1;
        int num4 = 1 << noCoeffsPlus;
        for (int index = 1; index < num4; ++index)
        {
          a = GFCalculator.mult(a, betaSet[noOfBetas - 1]);
          func[index] = GFCalculator.mult(a, func[index]);
        }
      }
      FastFourierTransform.ComputeRadix(numArray1, numArray2, func, noCoeffsPlus, fft);
      for (int index = 0; index < noOfBetas - 1; ++index)
      {
        set[index] = GFCalculator.mult(betaSet[index], GFCalculator.inverse(betaSet[noOfBetas - 1]));
        betaSet1[index] = GFCalculator.mult(set[index], set[index]) ^ set[index];
      }
      FastFourierTransform.ComputeSubsetSum(subsetSum, set, noOfBetas - 1);
      FastFourierTransform.ComputeFFTRec(output1, numArray1, (noCoeffs + 1) / 2, noOfBetas - 1, noCoeffsPlus - 1, betaSet1, fft, m);
      num1 = 1;
      int index3 = 1 << (noOfBetas - 1 & 15);
      if (noCoeffs <= 3)
      {
        output[0] = output1[0];
        output[index3] = output1[0] ^ numArray2[0];
        for (int index4 = 1; index4 < index3; ++index4)
        {
          output[index4] = output1[index4] ^ GFCalculator.mult(subsetSum[index4], numArray2[0]);
          output[index3 + index4] = output[index4] ^ numArray2[0];
        }
      }
      else
      {
        FastFourierTransform.ComputeFFTRec(numArray3, numArray2, noCoeffs / 2, noOfBetas - 1, noCoeffsPlus - 1, betaSet1, fft, m);
        Array.Copy((Array) numArray3, 0, (Array) output, index3, index3);
        output[0] = output1[0];
        output[index3] ^= output1[0];
        for (int index5 = 1; index5 < index3; ++index5)
        {
          output[index5] = output1[index5] ^ GFCalculator.mult(subsetSum[index5], numArray3[index5]);
          output[index3 + index5] ^= output[index5];
        }
      }
    }
  }

  internal static void FastFourierTransformGetError(
    byte[] errorSet,
    int[] input,
    int mSize,
    int[] logArrays)
  {
    int maxValue = (int) byte.MaxValue;
    int[] numArray = new int[7];
    int[] subsetSum = new int[mSize];
    int index1 = mSize;
    FastFourierTransform.ComputeFFTBetas(numArray, 8);
    FastFourierTransform.ComputeSubsetSum(subsetSum, numArray, 7);
    errorSet[0] ^= (byte) (1 ^ Utils.ToUnsigned16Bits(-input[0] >> 15));
    errorSet[0] ^= (byte) (1 ^ Utils.ToUnsigned16Bits(-input[index1] >> 15));
    for (int index2 = 1; index2 < index1; ++index2)
    {
      int index3 = maxValue - logArrays[subsetSum[index2]];
      errorSet[index3] ^= (byte) (1 ^ Math.Abs(-input[index2] >> 15));
      int index4 = maxValue - logArrays[subsetSum[index2] ^ 1];
      errorSet[index4] ^= (byte) (1 ^ Math.Abs(-input[index1 + index2] >> 15));
    }
  }
}
