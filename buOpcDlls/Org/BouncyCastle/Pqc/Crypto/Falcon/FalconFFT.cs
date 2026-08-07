// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconFFT
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

internal class FalconFFT
{
  private FprEngine fpre;

  internal FalconFFT() => this.fpre = new FprEngine();

  internal FalconFFT(FprEngine fprengine) => this.fpre = fprengine;

  internal FalconFPR[] FPC_ADD(FalconFPR a_re, FalconFPR a_im, FalconFPR b_re, FalconFPR b_im)
  {
    return new FalconFPR[2]
    {
      this.fpre.fpr_add(a_re, b_re),
      this.fpre.fpr_add(a_im, b_im)
    };
  }

  internal FalconFPR[] FPC_SUB(FalconFPR a_re, FalconFPR a_im, FalconFPR b_re, FalconFPR b_im)
  {
    return new FalconFPR[2]
    {
      this.fpre.fpr_sub(a_re, b_re),
      this.fpre.fpr_sub(a_im, b_im)
    };
  }

  internal FalconFPR[] FPC_MUL(FalconFPR a_re, FalconFPR a_im, FalconFPR b_re, FalconFPR b_im)
  {
    FalconFPR x1 = a_re;
    FalconFPR x2 = a_im;
    FalconFPR y1 = b_re;
    FalconFPR y2 = b_im;
    return new FalconFPR[2]
    {
      this.fpre.fpr_sub(this.fpre.fpr_mul(x1, y1), this.fpre.fpr_mul(x2, y2)),
      this.fpre.fpr_add(this.fpre.fpr_mul(x1, y2), this.fpre.fpr_mul(x2, y1))
    };
  }

  internal FalconFPR[] FPC_SQR(FalconFPR d_re, FalconFPR d_im, FalconFPR a_re, FalconFPR a_im)
  {
    FalconFPR x = a_re;
    FalconFPR falconFpr = a_im;
    return new FalconFPR[2]
    {
      this.fpre.fpr_sub(this.fpre.fpr_sqr(x), this.fpre.fpr_sqr(falconFpr)),
      this.fpre.fpr_double(this.fpre.fpr_mul(x, falconFpr))
    };
  }

  internal FalconFPR[] FPC_INV(FalconFPR a_re, FalconFPR a_im)
  {
    FalconFPR x1 = a_re;
    FalconFPR x2 = a_im;
    FalconFPR y = this.fpre.fpr_inv(this.fpre.fpr_add(this.fpre.fpr_sqr(x1), this.fpre.fpr_sqr(x2)));
    return new FalconFPR[2]
    {
      this.fpre.fpr_mul(x1, y),
      this.fpre.fpr_mul(this.fpre.fpr_neg(x2), y)
    };
  }

  internal FalconFPR[] FPC_DIV(FalconFPR a_re, FalconFPR a_im, FalconFPR b_re, FalconFPR b_im)
  {
    FalconFPR x1 = a_re;
    FalconFPR x2 = a_im;
    FalconFPR x3 = b_re;
    FalconFPR x4 = b_im;
    FalconFPR y1 = this.fpre.fpr_inv(this.fpre.fpr_add(this.fpre.fpr_sqr(x3), this.fpre.fpr_sqr(x4)));
    FalconFPR y2 = this.fpre.fpr_mul(x3, y1);
    FalconFPR y3 = this.fpre.fpr_mul(this.fpre.fpr_neg(x4), y1);
    return new FalconFPR[2]
    {
      this.fpre.fpr_sub(this.fpre.fpr_mul(x1, y2), this.fpre.fpr_mul(x2, y3)),
      this.fpre.fpr_add(this.fpre.fpr_mul(x1, y3), this.fpre.fpr_mul(x2, y2))
    };
  }

  internal void FFT(FalconFPR[] fsrc, int f, uint logn)
  {
    int num1 = 1 << (int) logn >> 1;
    int num2 = num1;
    uint num3 = 1;
    int num4 = 2;
    while (num3 < logn)
    {
      int num5 = num2 >> 1;
      int num6 = num4 >> 1;
      int num7 = 0;
      int num8 = 0;
      while (num7 < num6)
      {
        int num9 = num8 + num5;
        FalconFPR b_re1 = this.fpre.fpr_gm_tab[num4 + num7 << 1];
        FalconFPR b_im1 = this.fpre.fpr_gm_tab[(num4 + num7 << 1) + 1];
        for (int index = num8; index < num9; ++index)
        {
          FalconFPR a_re = fsrc[f + index];
          FalconFPR a_im = fsrc[f + index + num1];
          FalconFPR[] falconFprArray1 = this.FPC_MUL(fsrc[f + index + num5], fsrc[f + index + num5 + num1], b_re1, b_im1);
          FalconFPR b_re2 = falconFprArray1[0];
          FalconFPR b_im2 = falconFprArray1[1];
          FalconFPR[] falconFprArray2 = this.FPC_ADD(a_re, a_im, b_re2, b_im2);
          fsrc[f + index] = falconFprArray2[0];
          fsrc[f + index + num1] = falconFprArray2[1];
          FalconFPR[] falconFprArray3 = this.FPC_SUB(a_re, a_im, b_re2, b_im2);
          fsrc[f + index + num5] = falconFprArray3[0];
          fsrc[f + index + num5 + num1] = falconFprArray3[1];
        }
        ++num7;
        num8 += num2;
      }
      num2 = num5;
      ++num3;
      num4 <<= 1;
    }
  }

  internal void iFFT(FalconFPR[] fsrc, int f, uint logn)
  {
    int num1 = 1 << (int) logn;
    int num2 = 1;
    int num3 = num1;
    int num4 = num1 >> 1;
    for (int index1 = (int) logn; index1 > 1; --index1)
    {
      int num5 = num3 >> 1;
      int num6 = num2 << 1;
      int num7 = 0;
      for (int index2 = 0; index2 < num4; index2 += num6)
      {
        int num8 = index2 + num2;
        FalconFPR b_re1 = this.fpre.fpr_gm_tab[num5 + num7 << 1];
        FalconFPR b_im1 = this.fpre.fpr_neg(this.fpre.fpr_gm_tab[(num5 + num7 << 1) + 1]);
        for (int index3 = index2; index3 < num8; ++index3)
        {
          FalconFPR a_re = fsrc[f + index3];
          FalconFPR a_im = fsrc[f + index3 + num4];
          FalconFPR b_re2 = fsrc[f + index3 + num2];
          FalconFPR b_im2 = fsrc[f + index3 + num2 + num4];
          FalconFPR[] falconFprArray1 = this.FPC_ADD(a_re, a_im, b_re2, b_im2);
          fsrc[f + index3] = falconFprArray1[0];
          fsrc[f + index3 + num4] = falconFprArray1[1];
          FalconFPR[] falconFprArray2 = this.FPC_SUB(a_re, a_im, b_re2, b_im2);
          FalconFPR[] falconFprArray3 = this.FPC_MUL(falconFprArray2[0], falconFprArray2[1], b_re1, b_im1);
          fsrc[f + index3 + num2] = falconFprArray3[0];
          fsrc[f + index3 + num2 + num4] = falconFprArray3[1];
        }
        ++num7;
      }
      num2 = num6;
      num3 = num5;
    }
    if (logn <= 0U)
      return;
    FalconFPR y = this.fpre.fpr_p2_tab[(int) logn];
    for (int index = 0; index < num1; ++index)
      fsrc[f + index] = this.fpre.fpr_mul(fsrc[f + index], y);
  }

  internal void poly_add(FalconFPR[] asrc, int a, FalconFPR[] bsrc, int b, uint logn)
  {
    int num = 1 << (int) logn;
    for (int index = 0; index < num; ++index)
      asrc[a + index] = this.fpre.fpr_add(asrc[a + index], bsrc[b + index]);
  }

  internal void poly_sub(FalconFPR[] asrc, int a, FalconFPR[] bsrc, int b, uint logn)
  {
    int num = 1 << (int) logn;
    for (int index = 0; index < num; ++index)
      asrc[a + index] = this.fpre.fpr_sub(asrc[a + index], bsrc[b + index]);
  }

  internal void poly_neg(FalconFPR[] asrc, int a, uint logn)
  {
    int num = 1 << (int) logn;
    for (int index = 0; index < num; ++index)
      asrc[a + index] = this.fpre.fpr_neg(asrc[a + index]);
  }

  internal void poly_adj_fft(FalconFPR[] asrc, int a, uint logn)
  {
    int num = 1 << (int) logn;
    for (int index = num >> 1; index < num; ++index)
      asrc[a + index] = this.fpre.fpr_neg(asrc[a + index]);
  }

  internal void poly_mul_fft(FalconFPR[] asrc, int a, FalconFPR[] bsrc, int b, uint logn)
  {
    int num = 1 << (int) logn >> 1;
    for (int index = 0; index < num; ++index)
    {
      FalconFPR[] falconFprArray = this.FPC_MUL(asrc[a + index], asrc[a + index + num], bsrc[b + index], bsrc[b + index + num]);
      asrc[a + index] = falconFprArray[0];
      asrc[a + index + num] = falconFprArray[1];
    }
  }

  internal void poly_muladj_fft(FalconFPR[] asrc, int a, FalconFPR[] bsrc, int b, uint logn)
  {
    int num = 1 << (int) logn >> 1;
    for (int index = 0; index < num; ++index)
    {
      FalconFPR[] falconFprArray = this.FPC_MUL(asrc[a + index], asrc[a + index + num], bsrc[b + index], this.fpre.fpr_neg(bsrc[b + index + num]));
      asrc[a + index] = falconFprArray[0];
      asrc[a + index + num] = falconFprArray[1];
    }
  }

  internal void poly_mulselfadj_fft(FalconFPR[] asrc, int a, uint logn)
  {
    int num = 1 << (int) logn >> 1;
    for (int index = 0; index < num; ++index)
    {
      FalconFPR x1 = asrc[a + index];
      FalconFPR x2 = asrc[a + index + num];
      asrc[a + index] = this.fpre.fpr_add(this.fpre.fpr_sqr(x1), this.fpre.fpr_sqr(x2));
      asrc[a + index + num] = this.fpre.fpr_zero;
    }
  }

  internal void poly_mulconst(FalconFPR[] asrc, int a, FalconFPR x, uint logn)
  {
    int num = 1 << (int) logn;
    for (int index = 0; index < num; ++index)
      asrc[a + index] = this.fpre.fpr_mul(asrc[a + index], x);
  }

  internal void poly_div_fft(FalconFPR[] asrc, int a, FalconFPR[] bsrc, int b, uint logn)
  {
    int num = 1 << (int) logn >> 1;
    for (int index = 0; index < num; ++index)
    {
      FalconFPR[] falconFprArray = this.FPC_DIV(asrc[a + index], asrc[a + index + num], bsrc[b + index], bsrc[b + index + num]);
      asrc[a + index] = falconFprArray[0];
      asrc[a + index + num] = falconFprArray[1];
    }
  }

  internal void poly_invnorm2_fft(
    FalconFPR[] dsrc,
    int d,
    FalconFPR[] asrc,
    int a,
    FalconFPR[] bsrc,
    int b,
    uint logn)
  {
    int num = 1 << (int) logn >> 1;
    for (int index = 0; index < num; ++index)
    {
      FalconFPR x1 = asrc[a + index];
      FalconFPR x2 = asrc[a + index + num];
      FalconFPR x3 = bsrc[b + index];
      FalconFPR x4 = bsrc[b + index + num];
      dsrc[d + index] = this.fpre.fpr_inv(this.fpre.fpr_add(this.fpre.fpr_add(this.fpre.fpr_sqr(x1), this.fpre.fpr_sqr(x2)), this.fpre.fpr_add(this.fpre.fpr_sqr(x3), this.fpre.fpr_sqr(x4))));
    }
  }

  internal void poly_add_muladj_fft(
    FalconFPR[] dsrc,
    int d,
    FalconFPR[] Fsrc,
    int F,
    FalconFPR[] Gsrc,
    int G,
    FalconFPR[] fsrc,
    int f,
    FalconFPR[] gsrc,
    int g,
    uint logn)
  {
    int num = 1 << (int) logn >> 1;
    for (int index = 0; index < num; ++index)
    {
      FalconFPR a_re1 = Fsrc[F + index];
      FalconFPR a_im1 = Fsrc[F + index + num];
      FalconFPR a_re2 = Gsrc[G + index];
      FalconFPR a_im2 = Gsrc[G + index + num];
      FalconFPR b_re1 = fsrc[f + index];
      FalconFPR x1 = fsrc[f + index + num];
      FalconFPR b_re2 = gsrc[g + index];
      FalconFPR x2 = gsrc[g + index + num];
      FalconFPR[] falconFprArray1 = this.FPC_MUL(a_re1, a_im1, b_re1, this.fpre.fpr_neg(x1));
      FalconFPR x3 = falconFprArray1[0];
      FalconFPR x4 = falconFprArray1[1];
      FalconFPR[] falconFprArray2 = this.FPC_MUL(a_re2, a_im2, b_re2, this.fpre.fpr_neg(x2));
      FalconFPR y1 = falconFprArray2[0];
      FalconFPR y2 = falconFprArray2[1];
      dsrc[d + index] = this.fpre.fpr_add(x3, y1);
      dsrc[d + index + num] = this.fpre.fpr_add(x4, y2);
    }
  }

  internal void poly_mul_autoadj_fft(FalconFPR[] asrc, int a, FalconFPR[] bsrc, int b, uint logn)
  {
    int num = 1 << (int) logn >> 1;
    for (int index = 0; index < num; ++index)
    {
      asrc[a + index] = this.fpre.fpr_mul(asrc[a + index], bsrc[b + index]);
      asrc[a + index + num] = this.fpre.fpr_mul(asrc[a + index + num], bsrc[b + index]);
    }
  }

  internal void poly_div_autoadj_fft(FalconFPR[] asrc, int a, FalconFPR[] bsrc, int b, uint logn)
  {
    int num = 1 << (int) logn >> 1;
    for (int index = 0; index < num; ++index)
    {
      FalconFPR y = this.fpre.fpr_inv(bsrc[b + index]);
      asrc[a + index] = this.fpre.fpr_mul(asrc[a + index], y);
      asrc[a + index + num] = this.fpre.fpr_mul(asrc[a + index + num], y);
    }
  }

  internal void poly_LDL_fft(
    FalconFPR[] g00src,
    int g00,
    FalconFPR[] g01src,
    int g01,
    FalconFPR[] g11src,
    int g11,
    uint logn)
  {
    int num = 1 << (int) logn >> 1;
    for (int index = 0; index < num; ++index)
    {
      FalconFPR b_re1 = g00src[g00 + index];
      FalconFPR b_im1 = g00src[g00 + index + num];
      FalconFPR falconFpr1 = g01src[g01 + index];
      FalconFPR falconFpr2 = g01src[g01 + index + num];
      FalconFPR a_re1 = g11src[g11 + index];
      FalconFPR a_im = g11src[g11 + index + num];
      FalconFPR[] falconFprArray1 = this.FPC_DIV(falconFpr1, falconFpr2, b_re1, b_im1);
      FalconFPR a_re2 = falconFprArray1[0];
      FalconFPR falconFpr3 = falconFprArray1[1];
      FalconFPR[] falconFprArray2 = this.FPC_MUL(a_re2, falconFpr3, falconFpr1, this.fpre.fpr_neg(falconFpr2));
      FalconFPR b_re2 = falconFprArray2[0];
      FalconFPR b_im2 = falconFprArray2[1];
      FalconFPR[] falconFprArray3 = this.FPC_SUB(a_re1, a_im, b_re2, b_im2);
      g11src[g11 + index] = falconFprArray3[0];
      g11src[g11 + index + num] = falconFprArray3[1];
      g01src[g01 + index] = a_re2;
      g01src[g01 + index + num] = this.fpre.fpr_neg(falconFpr3);
    }
  }

  internal void poly_LDLmv_fft(
    FalconFPR[] d11src,
    int d11,
    FalconFPR[] l10src,
    int l10,
    FalconFPR[] g00src,
    int g00,
    FalconFPR[] g01src,
    int g01,
    FalconFPR[] g11src,
    int g11,
    uint logn)
  {
    int num = 1 << (int) logn >> 1;
    for (int index = 0; index < num; ++index)
    {
      FalconFPR b_re1 = g00src[g00 + index];
      FalconFPR b_im1 = g00src[g00 + index + num];
      FalconFPR falconFpr1 = g01src[g01 + index];
      FalconFPR falconFpr2 = g01src[g01 + index + num];
      FalconFPR a_re1 = g11src[g11 + index];
      FalconFPR a_im = g11src[g11 + index + num];
      FalconFPR[] falconFprArray1 = this.FPC_DIV(falconFpr1, falconFpr2, b_re1, b_im1);
      FalconFPR a_re2 = falconFprArray1[0];
      FalconFPR falconFpr3 = falconFprArray1[1];
      FalconFPR[] falconFprArray2 = this.FPC_MUL(a_re2, falconFpr3, falconFpr1, this.fpre.fpr_neg(falconFpr2));
      FalconFPR b_re2 = falconFprArray2[0];
      FalconFPR b_im2 = falconFprArray2[1];
      FalconFPR[] falconFprArray3 = this.FPC_SUB(a_re1, a_im, b_re2, b_im2);
      d11src[d11 + index] = falconFprArray3[0];
      d11src[d11 + index + num] = falconFprArray3[1];
      l10src[l10 + index] = a_re2;
      l10src[l10 + index + num] = this.fpre.fpr_neg(falconFpr3);
    }
  }

  internal void poly_split_fft(
    FalconFPR[] f0src,
    int f0,
    FalconFPR[] f1src,
    int f1,
    FalconFPR[] fsrc,
    int f,
    uint logn)
  {
    int num1 = 1 << (int) logn >> 1;
    int num2 = num1 >> 1;
    f0src[f0] = fsrc[f];
    f1src[f1] = fsrc[f + num1];
    for (int index = 0; index < num2; ++index)
    {
      FalconFPR a_re = fsrc[f + (index << 1)];
      FalconFPR a_im = fsrc[f + (index << 1) + num1];
      FalconFPR b_re = fsrc[f + (index << 1) + 1];
      FalconFPR b_im = fsrc[f + (index << 1) + 1 + num1];
      FalconFPR[] falconFprArray1 = this.FPC_ADD(a_re, a_im, b_re, b_im);
      FalconFPR x1 = falconFprArray1[0];
      FalconFPR x2 = falconFprArray1[1];
      f0src[f0 + index] = this.fpre.fpr_half(x1);
      f0src[f0 + index + num2] = this.fpre.fpr_half(x2);
      FalconFPR[] falconFprArray2 = this.FPC_SUB(a_re, a_im, b_re, b_im);
      FalconFPR[] falconFprArray3 = this.FPC_MUL(falconFprArray2[0], falconFprArray2[1], this.fpre.fpr_gm_tab[index + num1 << 1], this.fpre.fpr_neg(this.fpre.fpr_gm_tab[(index + num1 << 1) + 1]));
      FalconFPR x3 = falconFprArray3[0];
      FalconFPR x4 = falconFprArray3[1];
      f1src[f1 + index] = this.fpre.fpr_half(x3);
      f1src[f1 + index + num2] = this.fpre.fpr_half(x4);
    }
  }

  internal void poly_merge_fft(
    FalconFPR[] fsrc,
    int f,
    FalconFPR[] f0src,
    int f0,
    FalconFPR[] f1src,
    int f1,
    uint logn)
  {
    int num1 = 1 << (int) logn >> 1;
    int num2 = num1 >> 1;
    fsrc[f] = f0src[f0];
    fsrc[f + num1] = f1src[f1];
    for (int index = 0; index < num2; ++index)
    {
      FalconFPR a_re = f0src[f0 + index];
      FalconFPR a_im = f0src[f0 + index + num2];
      FalconFPR[] falconFprArray1 = this.FPC_MUL(f1src[f1 + index], f1src[f1 + index + num2], this.fpre.fpr_gm_tab[index + num1 << 1], this.fpre.fpr_gm_tab[(index + num1 << 1) + 1]);
      FalconFPR b_re = falconFprArray1[0];
      FalconFPR b_im = falconFprArray1[1];
      FalconFPR[] falconFprArray2 = this.FPC_ADD(a_re, a_im, b_re, b_im);
      FalconFPR falconFpr1 = falconFprArray2[0];
      FalconFPR falconFpr2 = falconFprArray2[1];
      fsrc[f + (index << 1)] = falconFpr1;
      fsrc[f + (index << 1) + num1] = falconFpr2;
      FalconFPR[] falconFprArray3 = this.FPC_SUB(a_re, a_im, b_re, b_im);
      FalconFPR falconFpr3 = falconFprArray3[0];
      FalconFPR falconFpr4 = falconFprArray3[1];
      fsrc[f + (index << 1) + 1] = falconFpr3;
      fsrc[f + (index << 1) + 1 + num1] = falconFpr4;
    }
  }
}
