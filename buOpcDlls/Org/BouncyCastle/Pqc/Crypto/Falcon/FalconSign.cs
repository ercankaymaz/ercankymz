// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconSign
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

internal class FalconSign
{
  private FalconFFT ffte;
  private FprEngine fpre;
  private FalconCommon common;

  internal FalconSign(FalconCommon common)
  {
    this.ffte = new FalconFFT();
    this.fpre = new FprEngine();
    this.common = common;
  }

  internal uint ffLDL_treesize(uint logn) => logn + 1U << (int) logn;

  internal void ffLDL_fft_inner(
    FalconFPR[] treesrc,
    int tree,
    FalconFPR[] g0src,
    int g0,
    FalconFPR[] g1src,
    int g1,
    uint logn,
    FalconFPR[] tmpsrc,
    int tmp)
  {
    int num1 = 1 << (int) logn;
    if (num1 == 1)
    {
      treesrc[tree] = g0src[g0];
    }
    else
    {
      int num2 = num1 >> 1;
      this.ffte.poly_LDLmv_fft(tmpsrc, tmp, treesrc, tree, g0src, g0, g1src, g1, g0src, g0, logn);
      this.ffte.poly_split_fft(g1src, g1, g1src, g1 + num2, g0src, g0, logn);
      this.ffte.poly_split_fft(g0src, g0, g0src, g0 + num2, tmpsrc, tmp, logn);
      this.ffLDL_fft_inner(treesrc, tree + num1, g1src, g1, g1src, g1 + num2, logn - 1U, tmpsrc, tmp);
      this.ffLDL_fft_inner(treesrc, tree + num1 + (int) this.ffLDL_treesize(logn - 1U), g0src, g0, g0src, g0 + num2, logn - 1U, tmpsrc, tmp);
    }
  }

  internal void ffLDL_fft(
    FalconFPR[] treesrc,
    int tree,
    FalconFPR[] g00src,
    int g00,
    FalconFPR[] g01src,
    int g01,
    FalconFPR[] g11src,
    int g11,
    uint logn,
    FalconFPR[] tmpsrc,
    int tmp)
  {
    int length = 1 << (int) logn;
    if (length == 1)
    {
      treesrc[tree] = g00src[g00];
    }
    else
    {
      int num1 = length >> 1;
      int num2 = tmp;
      int num3 = tmp + length;
      tmp += length << 1;
      Array.Copy((Array) g00src, g00, (Array) tmpsrc, num2, length);
      this.ffte.poly_LDLmv_fft(tmpsrc, num3, treesrc, tree, g00src, g00, g01src, g01, g11src, g11, logn);
      this.ffte.poly_split_fft(tmpsrc, tmp, tmpsrc, tmp + num1, tmpsrc, num2, logn);
      this.ffte.poly_split_fft(tmpsrc, num2, tmpsrc, num2 + num1, tmpsrc, num3, logn);
      Array.Copy((Array) tmpsrc, tmp, (Array) tmpsrc, num3, length);
      this.ffLDL_fft_inner(treesrc, tree + length, tmpsrc, num3, tmpsrc, num3 + num1, logn - 1U, tmpsrc, tmp);
      this.ffLDL_fft_inner(treesrc, tree + length + (int) this.ffLDL_treesize(logn - 1U), tmpsrc, num2, tmpsrc, num2 + num1, logn - 1U, tmpsrc, tmp);
    }
  }

  internal void ffLDL_binary_normalize(FalconFPR[] treesrc, int tree, uint orig_logn, uint logn)
  {
    int num = 1 << (int) logn;
    if (num == 1)
    {
      treesrc[tree] = this.fpre.fpr_mul(this.fpre.fpr_sqrt(treesrc[tree]), this.fpre.fpr_inv_sigma[(int) orig_logn]);
    }
    else
    {
      this.ffLDL_binary_normalize(treesrc, tree + num, orig_logn, logn - 1U);
      this.ffLDL_binary_normalize(treesrc, tree + num + (int) this.ffLDL_treesize(logn - 1U), orig_logn, logn - 1U);
    }
  }

  internal void smallints_to_fpr(FalconFPR[] rsrc, int r, sbyte[] tsrc, int t, uint logn)
  {
    int num = 1 << (int) logn;
    for (int index = 0; index < num; ++index)
      rsrc[r + index] = this.fpre.fpr_of((long) tsrc[t + index]);
  }

  private int skoff_b00(uint logn) => 0;

  private int skoff_b01(uint logn) => 1 << (int) logn;

  private int skoff_b10(uint logn) => 2 << (int) logn;

  private int skoff_b11(uint logn) => 3 << (int) logn;

  private int skoff_tree(uint logn) => 4 << (int) logn;

  internal void ffSampling_fft_dyntree(
    SamplerZ samp,
    FalconFPR[] t0src,
    int t0,
    FalconFPR[] t1src,
    int t1,
    FalconFPR[] g00src,
    int g00,
    FalconFPR[] g01src,
    int g01,
    FalconFPR[] g11src,
    int g11,
    uint orig_logn,
    uint logn,
    FalconFPR[] tmpsrc,
    int tmp)
  {
    if (logn == 0U)
    {
      FalconFPR isigma = this.fpre.fpr_mul(this.fpre.fpr_sqrt(g00src[g00]), this.fpre.fpr_inv_sigma[(int) orig_logn]);
      t0src[t0] = this.fpre.fpr_of((long) samp.Sample(t0src[t0], isigma));
      t1src[t1] = this.fpre.fpr_of((long) samp.Sample(t1src[t1], isigma));
    }
    else
    {
      int length1 = 1 << (int) logn;
      int length2 = length1 >> 1;
      this.ffte.poly_LDL_fft(g00src, g00, g01src, g01, g11src, g11, logn);
      this.ffte.poly_split_fft(tmpsrc, tmp, tmpsrc, tmp + length2, g00src, g00, logn);
      Array.Copy((Array) tmpsrc, tmp, (Array) g00src, g00, length1);
      this.ffte.poly_split_fft(tmpsrc, tmp, tmpsrc, tmp + length2, g11src, g11, logn);
      Array.Copy((Array) tmpsrc, tmp, (Array) g11src, g11, length1);
      Array.Copy((Array) g01src, g01, (Array) tmpsrc, tmp, length1);
      Array.Copy((Array) g00src, g00, (Array) g01src, g01, length2);
      Array.Copy((Array) g11src, g11, (Array) g01src, g01 + length2, length2);
      int num1 = tmp + length1;
      this.ffte.poly_split_fft(tmpsrc, num1, tmpsrc, num1 + length2, tmpsrc, t1, logn);
      this.ffSampling_fft_dyntree(samp, tmpsrc, num1, tmpsrc, num1 + length2, g11src, g11, g11src, g11 + length2, g01src, g01 + length2, orig_logn, logn - 1U, tmpsrc, num1 + length1);
      this.ffte.poly_merge_fft(tmpsrc, tmp + (length1 << 1), tmpsrc, num1, tmpsrc, num1 + length2, logn);
      Array.Copy((Array) tmpsrc, t1, (Array) tmpsrc, num1, length1);
      this.ffte.poly_sub(tmpsrc, num1, tmpsrc, tmp + (length1 << 1), logn);
      Array.Copy((Array) tmpsrc, tmp + (length1 << 1), (Array) tmpsrc, t1, length1);
      this.ffte.poly_mul_fft(tmpsrc, tmp, tmpsrc, num1, logn);
      this.ffte.poly_add(tmpsrc, t0, tmpsrc, tmp, logn);
      int num2 = tmp;
      this.ffte.poly_split_fft(tmpsrc, num2, tmpsrc, num2 + length2, tmpsrc, t0, logn);
      this.ffSampling_fft_dyntree(samp, tmpsrc, num2, tmpsrc, num2 + length2, g00src, g00, g00src, g00 + length2, g01src, g01, orig_logn, logn - 1U, tmpsrc, num2 + length1);
      this.ffte.poly_merge_fft(tmpsrc, t0, tmpsrc, num2, tmpsrc, num2 + length2, logn);
    }
  }

  internal void ffSampling_fft(
    SamplerZ samp,
    FalconFPR[] z0src,
    int z0,
    FalconFPR[] z1src,
    int z1,
    FalconFPR[] treesrc,
    int tree,
    FalconFPR[] t0src,
    int t0,
    FalconFPR[] t1src,
    int t1,
    uint logn,
    FalconFPR[] tmpsrc,
    int tmp)
  {
    if (logn == 2U)
    {
      int index1 = tree + 4;
      int index2 = tree + 8;
      FalconFPR x1 = t1src[t1];
      FalconFPR x2 = t1src[t1 + 2];
      FalconFPR y1 = t1src[t1 + 1];
      FalconFPR y2 = t1src[t1 + 3];
      FalconFPR x3 = this.fpre.fpr_add(x1, y1);
      FalconFPR x4 = this.fpre.fpr_add(x2, y2);
      FalconFPR y3 = this.fpre.fpr_half(x3);
      FalconFPR y4 = this.fpre.fpr_half(x4);
      FalconFPR falconFpr1 = this.fpre.fpr_sub(x1, y1);
      FalconFPR falconFpr2 = this.fpre.fpr_sub(x2, y2);
      FalconFPR falconFpr3 = this.fpre.fpr_mul(this.fpre.fpr_add(falconFpr1, falconFpr2), this.fpre.fpr_invsqrt8);
      FalconFPR falconFpr4 = this.fpre.fpr_mul(this.fpre.fpr_sub(falconFpr2, falconFpr1), this.fpre.fpr_invsqrt8);
      FalconFPR falconFpr5 = falconFpr3;
      FalconFPR falconFpr6 = falconFpr4;
      FalconFPR isigma1 = treesrc[index2 + 3];
      FalconFPR y5 = this.fpre.fpr_of((long) samp.Sample(falconFpr5, isigma1));
      FalconFPR y6 = this.fpre.fpr_of((long) samp.Sample(falconFpr6, isigma1));
      FalconFPR x5 = this.fpre.fpr_sub(falconFpr5, y5);
      FalconFPR x6 = this.fpre.fpr_sub(falconFpr6, y6);
      FalconFPR y7 = treesrc[index2];
      FalconFPR y8 = treesrc[index2 + 1];
      FalconFPR x7 = this.fpre.fpr_sub(this.fpre.fpr_mul(x5, y7), this.fpre.fpr_mul(x6, y8));
      FalconFPR x8 = this.fpre.fpr_add(this.fpre.fpr_mul(x5, y8), this.fpre.fpr_mul(x6, y7));
      FalconFPR mu1 = this.fpre.fpr_add(x7, y3);
      FalconFPR mu2 = this.fpre.fpr_add(x8, y4);
      FalconFPR isigma2 = treesrc[index2 + 2];
      FalconFPR falconFpr7 = this.fpre.fpr_of((long) samp.Sample(mu1, isigma2));
      FalconFPR falconFpr8 = this.fpre.fpr_of((long) samp.Sample(mu2, isigma2));
      FalconFPR x9 = falconFpr7;
      FalconFPR x10 = falconFpr8;
      FalconFPR x11 = y5;
      FalconFPR y9 = y6;
      FalconFPR y10 = this.fpre.fpr_mul(this.fpre.fpr_sub(x11, y9), this.fpre.fpr_invsqrt2);
      FalconFPR y11 = this.fpre.fpr_mul(this.fpre.fpr_add(x11, y9), this.fpre.fpr_invsqrt2);
      FalconFPR y12;
      z1src[z1] = y12 = this.fpre.fpr_add(x9, y10);
      FalconFPR y13;
      z1src[z1 + 2] = y13 = this.fpre.fpr_add(x10, y11);
      FalconFPR y14;
      z1src[z1 + 1] = y14 = this.fpre.fpr_sub(x9, y10);
      FalconFPR y15;
      z1src[z1 + 3] = y15 = this.fpre.fpr_sub(x10, y11);
      FalconFPR falconFpr9 = this.fpre.fpr_sub(t1src[t1], y12);
      FalconFPR falconFpr10 = this.fpre.fpr_sub(t1src[t1 + 1], y14);
      FalconFPR falconFpr11 = this.fpre.fpr_sub(t1src[t1 + 2], y13);
      FalconFPR falconFpr12 = this.fpre.fpr_sub(t1src[t1 + 3], y15);
      FalconFPR x12 = falconFpr9;
      FalconFPR x13 = falconFpr11;
      FalconFPR y16 = treesrc[tree];
      FalconFPR y17 = treesrc[tree + 2];
      FalconFPR x14 = this.fpre.fpr_sub(this.fpre.fpr_mul(x12, y16), this.fpre.fpr_mul(x13, y17));
      FalconFPR x15 = this.fpre.fpr_add(this.fpre.fpr_mul(x12, y17), this.fpre.fpr_mul(x13, y16));
      FalconFPR x16 = falconFpr10;
      FalconFPR x17 = falconFpr12;
      FalconFPR y18 = treesrc[tree + 1];
      FalconFPR y19 = treesrc[tree + 3];
      FalconFPR x18 = this.fpre.fpr_sub(this.fpre.fpr_mul(x16, y18), this.fpre.fpr_mul(x17, y19));
      FalconFPR x19 = this.fpre.fpr_add(this.fpre.fpr_mul(x16, y19), this.fpre.fpr_mul(x17, y18));
      FalconFPR falconFpr13 = this.fpre.fpr_add(x14, t0src[t0]);
      FalconFPR falconFpr14 = this.fpre.fpr_add(x18, t0src[t0 + 1]);
      FalconFPR falconFpr15 = this.fpre.fpr_add(x15, t0src[t0 + 2]);
      FalconFPR falconFpr16 = this.fpre.fpr_add(x19, t0src[t0 + 3]);
      FalconFPR x20 = falconFpr13;
      FalconFPR x21 = falconFpr15;
      FalconFPR y20 = falconFpr14;
      FalconFPR y21 = falconFpr16;
      FalconFPR x22 = this.fpre.fpr_add(x20, y20);
      FalconFPR x23 = this.fpre.fpr_add(x21, y21);
      FalconFPR y22 = this.fpre.fpr_half(x22);
      FalconFPR y23 = this.fpre.fpr_half(x23);
      FalconFPR falconFpr17 = this.fpre.fpr_sub(x20, y20);
      FalconFPR falconFpr18 = this.fpre.fpr_sub(x21, y21);
      FalconFPR falconFpr19 = this.fpre.fpr_mul(this.fpre.fpr_add(falconFpr17, falconFpr18), this.fpre.fpr_invsqrt8);
      FalconFPR falconFpr20 = this.fpre.fpr_mul(this.fpre.fpr_sub(falconFpr18, falconFpr17), this.fpre.fpr_invsqrt8);
      FalconFPR falconFpr21 = falconFpr19;
      FalconFPR falconFpr22 = falconFpr20;
      FalconFPR isigma3 = treesrc[index1 + 3];
      FalconFPR y24;
      FalconFPR falconFpr23 = y24 = this.fpre.fpr_of((long) samp.Sample(falconFpr21, isigma3));
      FalconFPR y25;
      FalconFPR falconFpr24 = y25 = this.fpre.fpr_of((long) samp.Sample(falconFpr22, isigma3));
      FalconFPR x24 = this.fpre.fpr_sub(falconFpr21, y24);
      FalconFPR x25 = this.fpre.fpr_sub(falconFpr22, y25);
      FalconFPR y26 = treesrc[index1];
      FalconFPR y27 = treesrc[index1 + 1];
      FalconFPR x26 = this.fpre.fpr_sub(this.fpre.fpr_mul(x24, y26), this.fpre.fpr_mul(x25, y27));
      FalconFPR x27 = this.fpre.fpr_add(this.fpre.fpr_mul(x24, y27), this.fpre.fpr_mul(x25, y26));
      FalconFPR mu3 = this.fpre.fpr_add(x26, y22);
      FalconFPR mu4 = this.fpre.fpr_add(x27, y23);
      FalconFPR isigma4 = treesrc[index1 + 2];
      FalconFPR falconFpr25 = this.fpre.fpr_of((long) samp.Sample(mu3, isigma4));
      FalconFPR falconFpr26 = this.fpre.fpr_of((long) samp.Sample(mu4, isigma4));
      FalconFPR x28 = falconFpr25;
      FalconFPR x29 = falconFpr26;
      FalconFPR x30 = falconFpr23;
      FalconFPR y28 = falconFpr24;
      FalconFPR y29 = this.fpre.fpr_mul(this.fpre.fpr_sub(x30, y28), this.fpre.fpr_invsqrt2);
      FalconFPR y30 = this.fpre.fpr_mul(this.fpre.fpr_add(x30, y28), this.fpre.fpr_invsqrt2);
      z0src[z0] = this.fpre.fpr_add(x28, y29);
      z0src[z0 + 2] = this.fpre.fpr_add(x29, y30);
      z0src[z0 + 1] = this.fpre.fpr_sub(x28, y29);
      z0src[z0 + 3] = this.fpre.fpr_sub(x29, y30);
    }
    else if (logn == 1U)
    {
      FalconFPR falconFpr27 = t1src[t1];
      FalconFPR falconFpr28 = t1src[t1 + 1];
      FalconFPR isigma5 = treesrc[tree + 3];
      FalconFPR y31;
      z1src[z1] = y31 = this.fpre.fpr_of((long) samp.Sample(falconFpr27, isigma5));
      FalconFPR y32;
      z1src[z1 + 1] = y32 = this.fpre.fpr_of((long) samp.Sample(falconFpr28, isigma5));
      FalconFPR x31 = this.fpre.fpr_sub(falconFpr27, y31);
      FalconFPR x32 = this.fpre.fpr_sub(falconFpr28, y32);
      FalconFPR y33 = treesrc[tree];
      FalconFPR y34 = treesrc[tree + 1];
      FalconFPR x33 = this.fpre.fpr_sub(this.fpre.fpr_mul(x31, y33), this.fpre.fpr_mul(x32, y34));
      FalconFPR x34 = this.fpre.fpr_add(this.fpre.fpr_mul(x31, y34), this.fpre.fpr_mul(x32, y33));
      FalconFPR mu5 = this.fpre.fpr_add(x33, t0src[t0]);
      FalconFPR mu6 = this.fpre.fpr_add(x34, t0src[t0 + 1]);
      FalconFPR isigma6 = treesrc[tree + 2];
      z0src[z0] = this.fpre.fpr_of((long) samp.Sample(mu5, isigma6));
      z0src[z0 + 1] = this.fpre.fpr_of((long) samp.Sample(mu6, isigma6));
    }
    else
    {
      int length = 1 << (int) logn;
      int num = length >> 1;
      int tree1 = tree + length;
      int tree2 = tree + length + (int) this.ffLDL_treesize(logn - 1U);
      this.ffte.poly_split_fft(z1src, z1, z1src, z1 + num, t1src, t1, logn);
      this.ffSampling_fft(samp, tmpsrc, tmp, tmpsrc, tmp + num, treesrc, tree2, z1src, z1, z1src, z1 + num, logn - 1U, tmpsrc, tmp + length);
      this.ffte.poly_merge_fft(z1src, z1, tmpsrc, tmp, tmpsrc, tmp + num, logn);
      Array.Copy((Array) t1src, t1, (Array) tmpsrc, tmp, length);
      this.ffte.poly_sub(tmpsrc, tmp, z1src, z1, logn);
      this.ffte.poly_mul_fft(tmpsrc, tmp, treesrc, tree, logn);
      this.ffte.poly_add(tmpsrc, tmp, t0src, t0, logn);
      this.ffte.poly_split_fft(z0src, z0, z0src, z0 + num, tmpsrc, tmp, logn);
      this.ffSampling_fft(samp, tmpsrc, tmp, tmpsrc, tmp + num, treesrc, tree1, z0src, z0, z0src, z0 + num, logn - 1U, tmpsrc, tmp + length);
      this.ffte.poly_merge_fft(z0src, z0, tmpsrc, tmp, tmpsrc, tmp + num, logn);
    }
  }

  internal int do_sign_tree(
    SamplerZ samp,
    short[] s2src,
    int s2,
    FalconFPR[] ex_keysrc,
    int expanded_key,
    ushort[] hmsrc,
    int hm,
    uint logn,
    FalconFPR[] tmpsrc,
    int tmp)
  {
    int length = 1 << (int) logn;
    int num1 = tmp;
    int num2 = num1 + length;
    int b1 = expanded_key + this.skoff_b00(logn);
    int b2 = expanded_key + this.skoff_b01(logn);
    int b3 = expanded_key + this.skoff_b10(logn);
    int b4 = expanded_key + this.skoff_b11(logn);
    int tree = expanded_key + this.skoff_tree(logn);
    for (int index = 0; index < length; ++index)
      tmpsrc[num1 + index] = this.fpre.fpr_of((long) hmsrc[hm + index]);
    this.ffte.FFT(tmpsrc, num1, logn);
    FalconFPR fprInverseOfQ = this.fpre.fpr_inverse_of_q;
    Array.Copy((Array) tmpsrc, num1, (Array) tmpsrc, num2, length);
    this.ffte.poly_mul_fft(tmpsrc, num2, ex_keysrc, b2, logn);
    this.ffte.poly_mulconst(tmpsrc, num2, this.fpre.fpr_neg(fprInverseOfQ), logn);
    this.ffte.poly_mul_fft(tmpsrc, num1, ex_keysrc, b4, logn);
    this.ffte.poly_mulconst(tmpsrc, num1, fprInverseOfQ, logn);
    int num3 = num2 + length;
    int num4 = num3 + length;
    this.ffSampling_fft(samp, tmpsrc, num3, tmpsrc, num4, ex_keysrc, tree, tmpsrc, num1, tmpsrc, num2, logn, tmpsrc, num4 + length);
    Array.Copy((Array) tmpsrc, num3, (Array) tmpsrc, num1, length);
    Array.Copy((Array) tmpsrc, num4, (Array) tmpsrc, num2, length);
    this.ffte.poly_mul_fft(tmpsrc, num3, ex_keysrc, b1, logn);
    this.ffte.poly_mul_fft(tmpsrc, num4, ex_keysrc, b3, logn);
    this.ffte.poly_add(tmpsrc, num3, tmpsrc, num4, logn);
    Array.Copy((Array) tmpsrc, num1, (Array) tmpsrc, num4, length);
    this.ffte.poly_mul_fft(tmpsrc, num4, ex_keysrc, b2, logn);
    Array.Copy((Array) tmpsrc, num3, (Array) tmpsrc, num1, length);
    this.ffte.poly_mul_fft(tmpsrc, num2, ex_keysrc, b4, logn);
    this.ffte.poly_add(tmpsrc, num2, tmpsrc, num4, logn);
    this.ffte.iFFT(tmpsrc, num1, logn);
    this.ffte.iFFT(tmpsrc, num2, logn);
    short[] sourceArray = new short[length];
    short[] numArray = new short[length];
    uint num5 = 0;
    uint num6 = 0;
    for (int index = 0; index < length; ++index)
    {
      int num7 = (int) hmsrc[hm + index] - (int) this.fpre.fpr_rint(tmpsrc[num1 + index]);
      num5 += (uint) (num7 * num7);
      num6 |= num5;
      sourceArray[index] = (short) num7;
    }
    uint sqn = num5 | -(num6 >> 31 /*0x1F*/);
    for (int index = 0; index < length; ++index)
      numArray[index] = (short) -this.fpre.fpr_rint(tmpsrc[num2 + index]);
    if (!this.common.is_short_half(sqn, numArray, 0, logn))
      return 0;
    Array.Copy((Array) numArray, 0, (Array) s2src, s2, length);
    Array.Copy((Array) sourceArray, 0, (Array) tmpsrc, tmp, length);
    return 1;
  }

  internal int do_sign_dyn(
    SamplerZ samp,
    short[] s2src,
    int s2,
    sbyte[] fsrc,
    int f,
    sbyte[] gsrc,
    int g,
    sbyte[] Fsrc,
    int F,
    sbyte[] Gsrc,
    int G,
    ushort[] hmsrc,
    int hm,
    uint logn,
    FalconFPR[] tmpsrc,
    int tmp)
  {
    int length = 1 << (int) logn;
    int num1 = tmp;
    int num2 = num1 + length;
    int num3 = num2 + length;
    int num4 = num3 + length;
    this.smallints_to_fpr(tmpsrc, num2, fsrc, f, logn);
    this.smallints_to_fpr(tmpsrc, num1, gsrc, g, logn);
    this.smallints_to_fpr(tmpsrc, num4, Fsrc, F, logn);
    this.smallints_to_fpr(tmpsrc, num3, Gsrc, G, logn);
    this.ffte.FFT(tmpsrc, num2, logn);
    this.ffte.FFT(tmpsrc, num1, logn);
    this.ffte.FFT(tmpsrc, num4, logn);
    this.ffte.FFT(tmpsrc, num3, logn);
    this.ffte.poly_neg(tmpsrc, num2, logn);
    this.ffte.poly_neg(tmpsrc, num4, logn);
    int num5 = num4 + length;
    int num6 = num5 + length;
    Array.Copy((Array) tmpsrc, num2, (Array) tmpsrc, num5, length);
    this.ffte.poly_mulselfadj_fft(tmpsrc, num5, logn);
    Array.Copy((Array) tmpsrc, num1, (Array) tmpsrc, num6, length);
    this.ffte.poly_muladj_fft(tmpsrc, num6, tmpsrc, num3, logn);
    this.ffte.poly_mulselfadj_fft(tmpsrc, num1, logn);
    this.ffte.poly_add(tmpsrc, num1, tmpsrc, num5, logn);
    Array.Copy((Array) tmpsrc, num2, (Array) tmpsrc, num5, length);
    this.ffte.poly_muladj_fft(tmpsrc, num2, tmpsrc, num4, logn);
    this.ffte.poly_add(tmpsrc, num2, tmpsrc, num6, logn);
    this.ffte.poly_mulselfadj_fft(tmpsrc, num3, logn);
    Array.Copy((Array) tmpsrc, num4, (Array) tmpsrc, num6, length);
    this.ffte.poly_mulselfadj_fft(tmpsrc, num6, logn);
    this.ffte.poly_add(tmpsrc, num3, tmpsrc, num6, logn);
    int g00 = num1;
    int g01 = num2;
    int g11 = num3;
    int b = num5;
    int num7 = b + length;
    int num8 = num7 + length;
    for (int index = 0; index < length; ++index)
      tmpsrc[num7 + index] = this.fpre.fpr_of((long) (short) hmsrc[hm + index]);
    this.ffte.FFT(tmpsrc, num7, logn);
    FalconFPR fprInverseOfQ = this.fpre.fpr_inverse_of_q;
    Array.Copy((Array) tmpsrc, num7, (Array) tmpsrc, num8, length);
    this.ffte.poly_mul_fft(tmpsrc, num8, tmpsrc, b, logn);
    this.ffte.poly_mulconst(tmpsrc, num8, this.fpre.fpr_neg(fprInverseOfQ), logn);
    this.ffte.poly_mul_fft(tmpsrc, num7, tmpsrc, num4, logn);
    this.ffte.poly_mulconst(tmpsrc, num7, fprInverseOfQ, logn);
    Array.Copy((Array) tmpsrc, num7, (Array) tmpsrc, num4, length * 2);
    int num9 = g11 + length;
    int t1 = num9 + length;
    this.ffSampling_fft_dyntree(samp, tmpsrc, num9, tmpsrc, t1, tmpsrc, g00, tmpsrc, g01, tmpsrc, g11, logn, logn, tmpsrc, t1 + length);
    int num10 = tmp;
    int num11 = num10 + length;
    int num12 = num11 + length;
    int num13 = num12 + length;
    Array.Copy((Array) tmpsrc, num9, (Array) tmpsrc, num13 + length, length * 2);
    int num14 = num13 + length;
    int num15 = num14 + length;
    this.smallints_to_fpr(tmpsrc, num11, fsrc, f, logn);
    this.smallints_to_fpr(tmpsrc, num10, gsrc, g, logn);
    this.smallints_to_fpr(tmpsrc, num13, Fsrc, F, logn);
    this.smallints_to_fpr(tmpsrc, num12, Gsrc, G, logn);
    this.ffte.FFT(tmpsrc, num11, logn);
    this.ffte.FFT(tmpsrc, num10, logn);
    this.ffte.FFT(tmpsrc, num13, logn);
    this.ffte.FFT(tmpsrc, num12, logn);
    this.ffte.poly_neg(tmpsrc, num11, logn);
    this.ffte.poly_neg(tmpsrc, num13, logn);
    int num16 = num15 + length;
    int num17 = num16 + length;
    Array.Copy((Array) tmpsrc, num14, (Array) tmpsrc, num16, length);
    Array.Copy((Array) tmpsrc, num15, (Array) tmpsrc, num17, length);
    this.ffte.poly_mul_fft(tmpsrc, num16, tmpsrc, num10, logn);
    this.ffte.poly_mul_fft(tmpsrc, num17, tmpsrc, num12, logn);
    this.ffte.poly_add(tmpsrc, num16, tmpsrc, num17, logn);
    Array.Copy((Array) tmpsrc, num14, (Array) tmpsrc, num17, length);
    this.ffte.poly_mul_fft(tmpsrc, num17, tmpsrc, num11, logn);
    Array.Copy((Array) tmpsrc, num16, (Array) tmpsrc, num14, length);
    this.ffte.poly_mul_fft(tmpsrc, num15, tmpsrc, num13, logn);
    this.ffte.poly_add(tmpsrc, num15, tmpsrc, num17, logn);
    this.ffte.iFFT(tmpsrc, num14, logn);
    this.ffte.iFFT(tmpsrc, num15, logn);
    short[] numArray1 = new short[length];
    uint num18 = 0;
    uint num19 = 0;
    for (int index = 0; index < length; ++index)
    {
      int num20 = (int) hmsrc[hm + index] - (int) this.fpre.fpr_rint(tmpsrc[num14 + index]);
      num18 += (uint) (num20 * num20);
      num19 |= num18;
      numArray1[index] = (short) num20;
    }
    uint sqn = num18 | -(num19 >> 31 /*0x1F*/);
    short[] numArray2 = new short[length];
    for (int index = 0; index < length; ++index)
      numArray2[index] = (short) -this.fpre.fpr_rint(tmpsrc[num15 + index]);
    if (!this.common.is_short_half(sqn, numArray2, 0, logn))
      return 0;
    Array.Copy((Array) numArray2, 0, (Array) s2src, s2, length);
    return 1;
  }

  internal void sign_tree(
    short[] sigsrc,
    int sig,
    SHAKE256 rng,
    FalconFPR[] ex_keysrc,
    int expanded_key,
    ushort[] hmsrc,
    int hm,
    uint logn,
    FalconFPR[] tmpsrc,
    int tmp)
  {
    int tmp1 = tmp;
    FalconRNG p;
    do
    {
      p = new FalconRNG();
      p.prng_init(rng);
    }
    while (this.do_sign_tree(new SamplerZ(p, this.fpre.fpr_sigma_min[(int) logn], this.fpre), sigsrc, sig, ex_keysrc, expanded_key, hmsrc, hm, logn, tmpsrc, tmp1) == 0);
  }

  internal void sign_dyn(
    short[] sigsrc,
    int sig,
    SHAKE256 rng,
    sbyte[] fsrc,
    int f,
    sbyte[] gsrc,
    int g,
    sbyte[] Fsrc,
    int F,
    sbyte[] Gsrc,
    int G,
    ushort[] hmsrc,
    int hm,
    uint logn,
    FalconFPR[] tmpsrc,
    int tmp)
  {
    FalconRNG p;
    do
    {
      p = new FalconRNG();
      p.prng_init(rng);
    }
    while (this.do_sign_dyn(new SamplerZ(p, this.fpre.fpr_sigma_min[(int) logn], this.fpre), sigsrc, sig, fsrc, f, gsrc, g, Fsrc, F, Gsrc, G, hmsrc, hm, logn, tmpsrc, tmp) == 0);
  }
}
