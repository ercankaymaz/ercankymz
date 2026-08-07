// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.Poly
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

internal class Poly
{
  private const int KARATSUBA_N = 64 /*0x40*/;
  private readonly int N_SB;
  private readonly int N_SB_RES;
  private readonly int SABER_N;
  private readonly int SABER_L;
  private readonly SaberEngine engine;
  private readonly SaberUtilities utils;

  public Poly(SaberEngine engine)
  {
    this.engine = engine;
    this.SABER_L = engine.L;
    this.SABER_N = engine.N;
    this.N_SB = this.SABER_N >> 2;
    this.N_SB_RES = 2 * this.N_SB - 1;
    this.utils = engine.Utilities;
  }

  public void GenMatrix(short[][][] A, byte[] seed)
  {
    byte[] numArray = new byte[this.SABER_L * this.engine.PolyVecBytes];
    this.engine.Symmetric.Prf(numArray, seed, this.engine.SeedBytes, numArray.Length);
    for (int index = 0; index < this.SABER_L; ++index)
      this.utils.BS2POLVECq(numArray, index * this.engine.PolyVecBytes, A[index]);
  }

  public void GenSecret(short[][] s, byte[] seed)
  {
    byte[] numArray = new byte[this.SABER_L * this.engine.PolyCoinBytes];
    this.engine.Symmetric.Prf(numArray, seed, this.engine.NoiseSeedBytes, numArray.Length);
    for (int index1 = 0; index1 < this.SABER_L; ++index1)
    {
      if (!this.engine.UsingEffectiveMasking)
      {
        this.Cbd(s[index1], numArray, index1 * this.engine.PolyCoinBytes);
      }
      else
      {
        for (int index2 = 0; index2 < this.SABER_N / 4; ++index2)
        {
          s[index1][4 * index2] = (short) (((int) numArray[index2 + index1 * this.engine.PolyCoinBytes] & 3 ^ 2) - 2);
          s[index1][4 * index2 + 1] = (short) (((int) numArray[index2 + index1 * this.engine.PolyCoinBytes] >> 2 & 3 ^ 2) - 2);
          s[index1][4 * index2 + 2] = (short) (((int) numArray[index2 + index1 * this.engine.PolyCoinBytes] >> 4 & 3 ^ 2) - 2);
          s[index1][4 * index2 + 3] = (short) (((int) numArray[index2 + index1 * this.engine.PolyCoinBytes] >> 6 & 3 ^ 2) - 2);
        }
      }
    }
  }

  private long LoadLittleEndian(byte[] x, int offset, int bytes)
  {
    long num = (long) ((int) x[offset] & (int) byte.MaxValue);
    for (int index = 1; index < bytes; ++index)
      num |= (long) ((int) x[offset + index] & (int) byte.MaxValue) << 8 * index;
    return num;
  }

  private void Cbd(short[] s, byte[] buf, int offset)
  {
    int[] numArray1 = new int[4];
    int[] numArray2 = new int[4];
    if (this.engine.MU == 6)
    {
      for (int index1 = 0; index1 < this.SABER_N / 4; ++index1)
      {
        int num1 = (int) this.LoadLittleEndian(buf, offset + 3 * index1, 3);
        int num2 = 0;
        for (int index2 = 0; index2 < 3; ++index2)
          num2 += num1 >> index2 & 2396745 /*0x249249*/;
        numArray1[0] = num2 & 7;
        numArray2[0] = num2 >> 3 & 7;
        numArray1[1] = num2 >> 6 & 7;
        numArray2[1] = num2 >> 9 & 7;
        numArray1[2] = num2 >> 12 & 7;
        numArray2[2] = num2 >> 15 & 7;
        numArray1[3] = num2 >> 18 & 7;
        numArray2[3] = num2 >> 21;
        s[4 * index1] = (short) (numArray1[0] - numArray2[0]);
        s[4 * index1 + 1] = (short) (numArray1[1] - numArray2[1]);
        s[4 * index1 + 2] = (short) (numArray1[2] - numArray2[2]);
        s[4 * index1 + 3] = (short) (numArray1[3] - numArray2[3]);
      }
    }
    else if (this.engine.MU == 8)
    {
      for (int index3 = 0; index3 < this.SABER_N / 4; ++index3)
      {
        int num3 = (int) this.LoadLittleEndian(buf, offset + 4 * index3, 4);
        int num4 = 0;
        for (int index4 = 0; index4 < 4; ++index4)
          num4 += num3 >> index4 & 286331153 /*0x11111111*/;
        numArray1[0] = num4 & 15;
        numArray2[0] = num4 >> 4 & 15;
        numArray1[1] = num4 >> 8 & 15;
        numArray2[1] = num4 >> 12 & 15;
        numArray1[2] = num4 >> 16 /*0x10*/ & 15;
        numArray2[2] = num4 >> 20 & 15;
        numArray1[3] = num4 >> 24 & 15;
        numArray2[3] = num4 >> 28;
        s[4 * index3] = (short) (numArray1[0] - numArray2[0]);
        s[4 * index3 + 1] = (short) (numArray1[1] - numArray2[1]);
        s[4 * index3 + 2] = (short) (numArray1[2] - numArray2[2]);
        s[4 * index3 + 3] = (short) (numArray1[3] - numArray2[3]);
      }
    }
    else
    {
      if (this.engine.MU != 10)
        return;
      for (int index5 = 0; index5 < this.SABER_N / 4; ++index5)
      {
        long num5 = this.LoadLittleEndian(buf, offset + 5 * index5, 5);
        long num6 = 0;
        for (int index6 = 0; index6 < 5; ++index6)
          num6 += num5 >> index6 & 35468117025L;
        numArray1[0] = (int) (num6 & 31L /*0x1F*/);
        numArray2[0] = (int) (num6 >> 5 & 31L /*0x1F*/);
        numArray1[1] = (int) (num6 >> 10 & 31L /*0x1F*/);
        numArray2[1] = (int) (num6 >> 15 & 31L /*0x1F*/);
        numArray1[2] = (int) (num6 >> 20 & 31L /*0x1F*/);
        numArray2[2] = (int) (num6 >> 25 & 31L /*0x1F*/);
        numArray1[3] = (int) (num6 >> 30 & 31L /*0x1F*/);
        numArray2[3] = (int) (num6 >> 35);
        s[4 * index5] = (short) (numArray1[0] - numArray2[0]);
        s[4 * index5 + 1] = (short) (numArray1[1] - numArray2[1]);
        s[4 * index5 + 2] = (short) (numArray1[2] - numArray2[2]);
        s[4 * index5 + 3] = (short) (numArray1[3] - numArray2[3]);
      }
    }
  }

  private short OVERFLOWING_MUL(int x, int y) => (short) (x * y);

  private void karatsuba_simple(int[] a_1, int[] b_1, int[] result_final)
  {
    int[] numArray1 = new int[31 /*0x1F*/];
    int[] numArray2 = new int[31 /*0x1F*/];
    int[] numArray3 = new int[31 /*0x1F*/];
    int[] numArray4 = new int[63 /*0x3F*/];
    for (int index1 = 0; index1 < 16 /*0x10*/; ++index1)
    {
      int x1 = a_1[index1];
      int x2 = a_1[index1 + 16 /*0x10*/];
      int y1 = a_1[index1 + 32 /*0x20*/];
      int y2 = a_1[index1 + 48 /*0x30*/];
      for (int index2 = 0; index2 < 16 /*0x10*/; ++index2)
      {
        int y3 = b_1[index2];
        int y4 = b_1[index2 + 16 /*0x10*/];
        result_final[index1 + index2] = result_final[index1 + index2] + (int) this.OVERFLOWING_MUL(x1, y3);
        result_final[index1 + index2 + 32 /*0x20*/] = result_final[index1 + index2 + 32 /*0x20*/] + (int) this.OVERFLOWING_MUL(x2, y4);
        int num1 = y3 + y4;
        int num2 = x1 + x2;
        numArray1[index1 + index2] = (int) ((long) numArray1[index1 + index2] + (long) num1 * (long) num2);
        int x3 = b_1[index2 + 32 /*0x20*/];
        int x4 = b_1[index2 + 48 /*0x30*/];
        result_final[index1 + index2 + 64 /*0x40*/] = result_final[index1 + index2 + 64 /*0x40*/] + (int) this.OVERFLOWING_MUL(x3, y1);
        result_final[index1 + index2 + 96 /*0x60*/] = result_final[index1 + index2 + 96 /*0x60*/] + (int) this.OVERFLOWING_MUL(x4, y2);
        int x5 = y1 + y2;
        int y5 = x3 + x4;
        numArray3[index1 + index2] = numArray3[index1 + index2] + (int) this.OVERFLOWING_MUL(x5, y5);
        int x6 = y3 + x3;
        int y6 = x1 + y1;
        numArray4[index1 + index2] = numArray4[index1 + index2] + (int) this.OVERFLOWING_MUL(x6, y6);
        int x7 = y4 + x4;
        int y7 = x2 + y2;
        numArray4[index1 + index2 + 32 /*0x20*/] = numArray4[index1 + index2 + 32 /*0x20*/] + (int) this.OVERFLOWING_MUL(x7, y7);
        int x8 = x6 + x7;
        int y8 = y6 + y7;
        numArray2[index1 + index2] = numArray2[index1 + index2] + (int) this.OVERFLOWING_MUL(x8, y8);
      }
    }
    for (int index = 0; index < 31 /*0x1F*/; ++index)
    {
      numArray2[index] = numArray2[index] - numArray4[index] - numArray4[index + 32 /*0x20*/];
      numArray1[index] = numArray1[index] - result_final[index] - result_final[index + 32 /*0x20*/];
      numArray3[index] = numArray3[index] - result_final[index + 64 /*0x40*/] - result_final[index + 96 /*0x60*/];
    }
    for (int index = 0; index < 31 /*0x1F*/; ++index)
    {
      numArray4[index + 16 /*0x10*/] = numArray4[index + 16 /*0x10*/] + numArray2[index];
      result_final[index + 16 /*0x10*/] = result_final[index + 16 /*0x10*/] + numArray1[index];
      result_final[index + 80 /*0x50*/] = result_final[index + 80 /*0x50*/] + numArray3[index];
    }
    for (int index = 0; index < 63 /*0x3F*/; ++index)
      numArray4[index] = numArray4[index] - result_final[index] - result_final[index + 64 /*0x40*/];
    for (int index = 0; index < 63 /*0x3F*/; ++index)
      result_final[index + 32 /*0x20*/] = result_final[index + 32 /*0x20*/] + numArray4[index];
  }

  private void toom_cook_4way(short[] a1, short[] b1, short[] result)
  {
    int num1 = 43691;
    int num2 = 36409;
    int num3 = 61167;
    int[] a_1_1 = new int[this.N_SB];
    int[] a_1_2 = new int[this.N_SB];
    int[] a_1_3 = new int[this.N_SB];
    int[] a_1_4 = new int[this.N_SB];
    int[] a_1_5 = new int[this.N_SB];
    int[] a_1_6 = new int[this.N_SB];
    int[] a_1_7 = new int[this.N_SB];
    int[] b_1_1 = new int[this.N_SB];
    int[] b_1_2 = new int[this.N_SB];
    int[] b_1_3 = new int[this.N_SB];
    int[] b_1_4 = new int[this.N_SB];
    int[] b_1_5 = new int[this.N_SB];
    int[] b_1_6 = new int[this.N_SB];
    int[] b_1_7 = new int[this.N_SB];
    int[] result_final1 = new int[this.N_SB_RES];
    int[] result_final2 = new int[this.N_SB_RES];
    int[] result_final3 = new int[this.N_SB_RES];
    int[] result_final4 = new int[this.N_SB_RES];
    int[] result_final5 = new int[this.N_SB_RES];
    int[] result_final6 = new int[this.N_SB_RES];
    int[] result_final7 = new int[this.N_SB_RES];
    short[] numArray = result;
    for (int index = 0; index < this.N_SB; ++index)
    {
      int num4 = (int) a1[index];
      int num5 = (int) a1[index + this.N_SB];
      int num6 = (int) a1[index + this.N_SB * 2];
      int num7 = (int) a1[index + this.N_SB * 3];
      int num8 = (int) (short) (num4 + num6);
      int num9 = (int) (short) (num5 + num7);
      int num10 = (int) (short) (num8 + num9);
      int num11 = (int) (short) (num8 - num9);
      a_1_3[index] = num10;
      a_1_4[index] = num11;
      int num12 = (int) (short) ((num4 << 2) + num6 << 1);
      int num13 = (int) (short) ((num5 << 2) + num7);
      int num14 = (int) (short) (num12 + num13);
      int num15 = (int) (short) (num12 - num13);
      a_1_5[index] = num14;
      a_1_6[index] = num15;
      int num16 = (int) (short) ((num7 << 3) + (num6 << 2) + (num5 << 1) + num4);
      a_1_2[index] = num16;
      a_1_7[index] = num4;
      a_1_1[index] = num7;
    }
    for (int index = 0; index < this.N_SB; ++index)
    {
      int num17 = (int) b1[index];
      int num18 = (int) b1[index + this.N_SB];
      int num19 = (int) b1[index + this.N_SB * 2];
      int num20 = (int) b1[index + this.N_SB * 3];
      int num21 = num17 + num19;
      int num22 = num18 + num20;
      int num23 = num21 + num22;
      int num24 = num21 - num22;
      b_1_3[index] = num23;
      b_1_4[index] = num24;
      int num25 = (num17 << 2) + num19 << 1;
      int num26 = (num18 << 2) + num20;
      int num27 = num25 + num26;
      int num28 = num25 - num26;
      b_1_5[index] = num27;
      b_1_6[index] = num28;
      int num29 = (num20 << 3) + (num19 << 2) + (num18 << 1) + num17;
      b_1_2[index] = num29;
      b_1_7[index] = num17;
      b_1_1[index] = num20;
    }
    this.karatsuba_simple(a_1_1, b_1_1, result_final1);
    this.karatsuba_simple(a_1_2, b_1_2, result_final2);
    this.karatsuba_simple(a_1_3, b_1_3, result_final3);
    this.karatsuba_simple(a_1_4, b_1_4, result_final4);
    this.karatsuba_simple(a_1_5, b_1_5, result_final5);
    this.karatsuba_simple(a_1_6, b_1_6, result_final6);
    this.karatsuba_simple(a_1_7, b_1_7, result_final7);
    for (int index = 0; index < this.N_SB_RES; ++index)
    {
      int num30 = result_final1[index];
      int num31 = result_final2[index];
      int num32 = result_final3[index];
      int num33 = result_final4[index];
      int num34 = result_final5[index];
      int num35 = result_final6[index];
      int num36 = result_final7[index];
      int num37 = num31 + num34;
      int num38 = num35 - num34;
      int num39 = (num33 & (int) ushort.MaxValue) - (num32 & (int) ushort.MaxValue) >> 1;
      int num40 = (num34 - num30 - (num36 << 6) << 1) + num38;
      int num41 = num32 + num39;
      int num42 = num37 - (num41 << 6) - num41;
      int num43 = num41 - num36 - num30;
      int num44 = num42 + 45 * num43;
      int num45 = ((num40 & (int) ushort.MaxValue) - (num43 << 3)) * num1 >> 3;
      int num46 = num38 + num44;
      int num47 = ((num44 & (int) ushort.MaxValue) + ((num39 & (int) ushort.MaxValue) << 4)) * num2 >> 1;
      int num48 = -(num39 + num47);
      int num49 = (30 * (num47 & (int) ushort.MaxValue) - (num46 & (int) ushort.MaxValue)) * num3 >> 2;
      int num50 = num43 - num45;
      int num51 = num47 - num49;
      numArray[index] += (short) (num36 & (int) ushort.MaxValue);
      numArray[index + 64 /*0x40*/] += (short) (num49 & (int) ushort.MaxValue);
      numArray[index + 128 /*0x80*/] += (short) (num45 & (int) ushort.MaxValue);
      numArray[index + 192 /*0xC0*/] += (short) (num48 & (int) ushort.MaxValue);
      numArray[index + 256 /*0x0100*/] += (short) (num50 & (int) ushort.MaxValue);
      numArray[index + 320] += (short) (num51 & (int) ushort.MaxValue);
      numArray[index + 384] += (short) (num30 & (int) ushort.MaxValue);
    }
  }

  private void poly_mul_acc(short[] a, short[] b, short[] res)
  {
    short[] result = new short[2 * this.SABER_N];
    this.toom_cook_4way(a, b, result);
    for (int saberN = this.SABER_N; saberN < 2 * this.SABER_N; ++saberN)
      res[saberN - this.SABER_N] += (short) ((int) result[saberN - this.SABER_N] - (int) result[saberN]);
  }

  public void MatrixVectorMul(short[][][] A, short[][] s, short[][] res, int transpose)
  {
    for (int index1 = 0; index1 < this.SABER_L; ++index1)
    {
      for (int index2 = 0; index2 < this.SABER_L; ++index2)
      {
        if (transpose == 1)
          this.poly_mul_acc(A[index2][index1], s[index2], res[index1]);
        else
          this.poly_mul_acc(A[index1][index2], s[index2], res[index1]);
      }
    }
  }

  public void InnerProd(short[][] b, short[][] s, short[] res)
  {
    for (int index = 0; index < this.SABER_L; ++index)
      this.poly_mul_acc(b[index], s[index], res);
  }
}
