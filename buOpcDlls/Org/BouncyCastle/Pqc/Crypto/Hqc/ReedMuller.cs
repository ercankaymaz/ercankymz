// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.ReedMuller
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

internal class ReedMuller
{
  private static void EncodeSub(ReedMuller.Codeword codeword, int m)
  {
    int num1 = ReedMuller.Bit0Mask(m >> 7) ^ (int) ((long) ReedMuller.Bit0Mask(m) & 2863311530L /*0xAAAAAAAA*/) ^ (int) ((long) ReedMuller.Bit0Mask(m >> 1) & 3435973836L /*0xCCCCCCCC*/) ^ (int) ((long) ReedMuller.Bit0Mask(m >> 2) & 4042322160L /*0xF0F0F0F0*/) ^ (int) ((long) ReedMuller.Bit0Mask(m >> 3) & 4278255360L /*0xFF00FF00*/) ^ (int) ((long) ReedMuller.Bit0Mask(m >> 4) & 4294901760L);
    codeword.type32[0] = num1;
    int num2 = num1 ^ ReedMuller.Bit0Mask(m >> 5);
    codeword.type32[1] = num2;
    int num3 = num2 ^ ReedMuller.Bit0Mask(m >> 6);
    codeword.type32[3] = num3;
    int num4 = num3 ^ ReedMuller.Bit0Mask(m >> 5);
    codeword.type32[2] = num4;
  }

  private static void HadamardTransform(int[] srcCode, int[] desCode)
  {
    int[] sourceArray1 = Arrays.Clone(srcCode);
    int[] sourceArray2 = Arrays.Clone(desCode);
    for (int index1 = 0; index1 < 7; ++index1)
    {
      for (int index2 = 0; index2 < 64 /*0x40*/; ++index2)
      {
        sourceArray2[index2] = sourceArray1[2 * index2] + sourceArray1[2 * index2 + 1];
        sourceArray2[index2 + 64 /*0x40*/] = sourceArray1[2 * index2] - sourceArray1[2 * index2 + 1];
      }
      int[] numArray = sourceArray1;
      sourceArray1 = sourceArray2;
      sourceArray2 = numArray;
    }
    Array.Copy((Array) sourceArray2, 0, (Array) srcCode, 0, srcCode.Length);
    Array.Copy((Array) sourceArray1, 0, (Array) desCode, 0, desCode.Length);
  }

  private static void ExpandThenSum(
    int[] desCode,
    ReedMuller.Codeword[] srcCode,
    int off,
    int mulParam)
  {
    for (int index1 = 0; index1 < 4; ++index1)
    {
      for (int index2 = 0; index2 < 32 /*0x20*/; ++index2)
        desCode[index1 * 32 /*0x20*/ + index2] = srcCode[off].type32[index1] >> index2 & 1;
    }
    for (int index3 = 1; index3 < mulParam; ++index3)
    {
      for (int index4 = 0; index4 < 4; ++index4)
      {
        for (int index5 = 0; index5 < 32 /*0x20*/; ++index5)
          desCode[index4 * 32 /*0x20*/ + index5] += srcCode[index3 + off].type32[index4] >> index5 & 1;
      }
    }
  }

  private static int FindPeaks(int[] input)
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    for (int index = 0; index < 128 /*0x80*/; ++index)
    {
      int num4 = input[index];
      int num5 = num4 > 0 ? -1 : 0;
      int num6 = num5 & num4 | ~num5 & -num4;
      num2 = num6 > num1 ? num4 : num2;
      num3 = num6 > num1 ? index : num3;
      num1 = num6 > num1 ? num6 : num1;
    }
    int num7 = num2 > 0 ? 1 : 0;
    return num3 | 128 /*0x80*/ * num7;
  }

  private static int Bit0Mask(int b) => (int) ((long) -(b & 1) & (long) uint.MaxValue);

  public static void Encode(long[] codeword, byte[] m, int n1, int mulParam)
  {
    byte[] numArray1 = Arrays.Clone(m);
    ReedMuller.Codeword[] codewordArray = new ReedMuller.Codeword[n1 * mulParam];
    for (int index = 0; index < codewordArray.Length; ++index)
      codewordArray[index] = new ReedMuller.Codeword();
    for (int index1 = 0; index1 < n1; ++index1)
    {
      int index2 = index1 * mulParam;
      ReedMuller.EncodeSub(codewordArray[index2], (int) numArray1[index1]);
      for (int index3 = 1; index3 < mulParam; ++index3)
        codewordArray[index2 + index3] = codewordArray[index2];
    }
    int[] numArray2 = new int[codewordArray.Length * 4];
    int destinationIndex = 0;
    for (int index = 0; index < codewordArray.Length; ++index)
    {
      Array.Copy((Array) codewordArray[index].type32, 0, (Array) numArray2, destinationIndex, codewordArray[index].type32.Length);
      destinationIndex += 4;
    }
    Utils.FromByte32ArrayToLongArray(codeword, numArray2);
  }

  public static void Decode(byte[] m, long[] codeword, int n1, int mulParam)
  {
    byte[] sourceArray = Arrays.Clone(m);
    ReedMuller.Codeword[] srcCode = new ReedMuller.Codeword[codeword.Length / 2];
    int[] output = new int[codeword.Length * 2];
    Utils.FromLongArrayToByte32Array(output, codeword);
    for (int index1 = 0; index1 < srcCode.Length; ++index1)
    {
      srcCode[index1] = new ReedMuller.Codeword();
      for (int index2 = 0; index2 < 4; ++index2)
        srcCode[index1].type32[index2] = output[index1 * 4 + index2];
    }
    int[] numArray1 = new int[128 /*0x80*/];
    for (int index = 0; index < n1; ++index)
    {
      ReedMuller.ExpandThenSum(numArray1, srcCode, index * mulParam, mulParam);
      int[] numArray2 = new int[128 /*0x80*/];
      ReedMuller.HadamardTransform(numArray1, numArray2);
      numArray2[0] -= 64 /*0x40*/ * mulParam;
      sourceArray[index] = (byte) ReedMuller.FindPeaks(numArray2);
    }
    int[] numArray3 = new int[srcCode.Length * 4];
    int destinationIndex = 0;
    for (int index = 0; index < srcCode.Length; ++index)
    {
      Array.Copy((Array) srcCode[index].type32, 0, (Array) numArray3, destinationIndex, srcCode[index].type32.Length);
      destinationIndex += 4;
    }
    Utils.FromByte32ArrayToLongArray(codeword, numArray3);
    Array.Copy((Array) sourceArray, 0, (Array) m, 0, m.Length);
  }

  internal class Codeword
  {
    internal int[] type32;
    internal int[] type8;

    public Codeword()
    {
      this.type32 = new int[4];
      this.type8 = new int[16 /*0x10*/];
    }
  }
}
