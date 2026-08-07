// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.Fpx
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal sealed class Fpx
{
  private readonly SikeEngine engine;

  internal Fpx(SikeEngine engine) => this.engine = engine;

  private void mp_shiftl1(ulong[] x, uint nwords)
  {
    for (int index = (int) nwords - 1; index > 0; --index)
      x[index] = x[index] << 1 ^ x[index - 1] >> (int) Internal.RADIX - 1;
    x[0] <<= 1;
  }

  internal void sqr_Fp2_cycl(ulong[][] a, ulong[] one)
  {
    ulong[] numArray = new ulong[(int) this.engine.param.NWORDS_FIELD];
    this.fpaddPRIME(a[0], a[1], numArray);
    this.fpsqr_mont(numArray, numArray);
    this.fpsubPRIME(numArray, one, a[1]);
    this.fpsqr_mont(a[0], numArray);
    this.fpaddPRIME(numArray, numArray, numArray);
    this.fpsubPRIME(numArray, one, a[0]);
  }

  internal void mont_n_way_inv(ulong[][][] vec, uint n, ulong[][][] output)
  {
    ulong[][] numArray = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.fp2copy(vec[0], output[0]);
    for (int index = 1; (long) index < (long) n; ++index)
      this.fp2mul_mont(output[index - 1], vec[index], output[index]);
    this.fp2copy(output[(int) n - 1], numArray);
    this.fp2inv_mont_bingcd(numArray);
    for (int index = (int) n - 1; index >= 1; --index)
    {
      this.fp2mul_mont(output[index - 1], numArray, output[index]);
      this.fp2mul_mont(numArray, vec[index], numArray);
    }
    this.fp2copy(numArray, output[0]);
  }

  internal void fpcopy(ulong[] a, long aOffset, ulong[] c)
  {
    for (uint index = 0; index < this.engine.param.NWORDS_FIELD; ++index)
      c[(int) index] = a[(long) index + aOffset];
  }

  internal void mp2_add(ulong[][] a, ulong[][] b, ulong[][] c)
  {
    long num1 = (long) this.mp_add(a[0], b[0], c[0], this.engine.param.NWORDS_FIELD);
    long num2 = (long) this.mp_add(a[1], b[1], c[1], this.engine.param.NWORDS_FIELD);
  }

  internal void fp2correction(ulong[][] a)
  {
    this.fpcorrectionPRIME(a[0]);
    this.fpcorrectionPRIME(a[1]);
  }

  internal ulong mp_add(ulong[] a, ulong[] b, ulong[] c, uint nwords)
  {
    ulong y = 0;
    for (uint index = 0; index < nwords; ++index)
    {
      ulong num = a[(int) index] + y;
      c[(int) index] = b[(int) index] + num;
      y = this.is_digit_lessthan_ct(num, y) | this.is_digit_lessthan_ct(c[(int) index], num);
    }
    return y;
  }

  private ulong mp_add(ulong[] a, uint aOffset, ulong[] b, ulong[] c, uint cOffset, uint nwords)
  {
    ulong y = 0;
    for (ulong index = 0; index < (ulong) nwords; ++index)
    {
      ulong num = a[checked ((ulong) unchecked ((long) index + (long) aOffset))] + y;
      c[checked ((ulong) unchecked ((long) index + (long) cOffset))] = b[index] + num;
      y = this.is_digit_lessthan_ct(num, y) | this.is_digit_lessthan_ct(c[checked ((ulong) unchecked ((long) index + (long) cOffset))], num);
    }
    return y;
  }

  private ulong mp_add(
    ulong[] a,
    uint aOffset,
    ulong[] b,
    uint bOffset,
    ulong[] c,
    uint cOffset,
    uint nwords)
  {
    ulong y = 0;
    for (ulong index = 0; index < (ulong) nwords; ++index)
    {
      ulong num = a[checked ((ulong) unchecked ((long) index + (long) aOffset))] + y;
      c[checked ((ulong) unchecked ((long) index + (long) cOffset))] = b[checked ((ulong) unchecked ((long) index + (long) bOffset))] + num;
      y = this.is_digit_lessthan_ct(num, y) | this.is_digit_lessthan_ct(c[checked ((ulong) unchecked ((long) index + (long) cOffset))], num);
    }
    return y;
  }

  private ulong is_digit_lessthan_ct(ulong x, ulong y)
  {
    return (x ^ (ulong) ((long) x ^ (long) y | (long) x - (long) y ^ (long) y)) >> (int) Internal.RADIX - 1;
  }

  private ulong is_digit_nonzero_ct(ulong x) => (x | (ulong) -(long) x) >> (int) Internal.RADIX - 1;

  private ulong is_digit_zero_ct(ulong x) => 1UL ^ this.is_digit_nonzero_ct(x);

  internal void fp2neg(ulong[][] a)
  {
    this.fpnegPRIME(a[0]);
    this.fpnegPRIME(a[1]);
  }

  internal bool is_felm_zero(ulong[] x)
  {
    for (uint index = 0; index < this.engine.param.NWORDS_FIELD; ++index)
    {
      if (x[(int) index] != 0UL)
        return false;
    }
    return true;
  }

  private bool is_felm_lt(ulong[] x, ulong[] y)
  {
    for (int index = (int) this.engine.param.NWORDS_FIELD - 1; index >= 0; --index)
    {
      if (x[index] < y[index])
        return true;
      if (x[index] > y[index])
        return false;
    }
    return false;
  }

  private static bool is_felm_even(ulong[] x) => ((long) x[0] & 1L) == 0L;

  internal bool is_sqr_fp2(ulong[][] a, ulong[] s)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray3 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray4 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    this.fpsqr_mont(a[0], numArray1);
    this.fpsqr_mont(a[1], numArray2);
    this.fpaddPRIME(numArray1, numArray2, numArray3);
    this.fpcopy(numArray3, 0L, s);
    for (uint index = 0; index < this.engine.param.OALICE_BITS - 2U; ++index)
      this.fpsqr_mont(s, s);
    for (uint index = 0; index < this.engine.param.OBOB_EXPON; ++index)
    {
      this.fpsqr_mont(s, numArray4);
      this.fpmul_mont(s, numArray4, s);
    }
    this.fpsqr_mont(s, numArray4);
    this.fpcorrectionPRIME(numArray4);
    this.fpcorrectionPRIME(numArray3);
    return Fpx.subarrayEquals(numArray4, numArray3, this.engine.param.NWORDS_FIELD);
  }

  private uint fpinv_mont_bingcd_partial(ulong[] a, ulong[] x1)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray3 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    this.fpcopy(a, 0L, numArray1);
    this.fpcopy(this.engine.param.PRIME, 0L, numArray2);
    this.fpzero(x1);
    x1[0] = 1UL;
    this.fpzero(numArray3);
    uint num1 = 0;
    while (!this.is_felm_zero(numArray2))
    {
      uint nwords = ++num1 / Internal.RADIX + 1U;
      if (nwords < this.engine.param.NWORDS_FIELD)
      {
        if (Fpx.is_felm_even(numArray2))
        {
          this.mp_shiftr1(numArray2);
          this.mp_shiftl1(x1, nwords);
        }
        else if (Fpx.is_felm_even(numArray1))
        {
          this.mp_shiftr1(numArray1);
          this.mp_shiftl1(numArray3, nwords);
        }
        else if (!this.is_felm_lt(numArray2, numArray1))
        {
          long num2 = (long) this.mp_sub(numArray2, numArray1, numArray2, this.engine.param.NWORDS_FIELD);
          this.mp_shiftr1(numArray2);
          long num3 = (long) this.mp_add(x1, numArray3, numArray3, nwords);
          this.mp_shiftl1(x1, nwords);
        }
        else
        {
          long num4 = (long) this.mp_sub(numArray1, numArray2, numArray1, this.engine.param.NWORDS_FIELD);
          this.mp_shiftr1(numArray1);
          long num5 = (long) this.mp_add(x1, numArray3, x1, nwords);
          this.mp_shiftl1(numArray3, nwords);
        }
      }
      else if (Fpx.is_felm_even(numArray2))
      {
        this.mp_shiftr1(numArray2);
        this.mp_shiftl1(x1, this.engine.param.NWORDS_FIELD);
      }
      else if (Fpx.is_felm_even(numArray1))
      {
        this.mp_shiftr1(numArray1);
        this.mp_shiftl1(numArray3, this.engine.param.NWORDS_FIELD);
      }
      else if (!this.is_felm_lt(numArray2, numArray1))
      {
        long num6 = (long) this.mp_sub(numArray2, numArray1, numArray2, this.engine.param.NWORDS_FIELD);
        this.mp_shiftr1(numArray2);
        long num7 = (long) this.mp_add(x1, numArray3, numArray3, this.engine.param.NWORDS_FIELD);
        this.mp_shiftl1(x1, this.engine.param.NWORDS_FIELD);
      }
      else
      {
        long num8 = (long) this.mp_sub(numArray1, numArray2, numArray1, this.engine.param.NWORDS_FIELD);
        this.mp_shiftr1(numArray1);
        long num9 = (long) this.mp_add(x1, numArray3, x1, this.engine.param.NWORDS_FIELD);
        this.mp_shiftl1(numArray3, this.engine.param.NWORDS_FIELD);
      }
    }
    if (this.is_felm_lt(this.engine.param.PRIME, x1))
    {
      long num10 = (long) this.mp_sub(x1, this.engine.param.PRIME, x1, this.engine.param.NWORDS_FIELD);
    }
    return num1;
  }

  private void power2_setup(ulong[] x, int mark, uint nwords)
  {
    for (uint index = 0; index < nwords; ++index)
      x[(int) index] = 0UL;
    uint index1 = 0;
    while (mark >= 0)
    {
      if ((long) mark < (long) Internal.RADIX)
        x[(int) index1] = (ulong) (1L << mark);
      mark -= (int) Internal.RADIX;
      ++index1;
    }
  }

  private void fpinv_mont_bingcd(ulong[] a)
  {
    if (this.is_felm_zero(a))
      return;
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    uint num = this.fpinv_mont_bingcd_partial(a, numArray1);
    if (num <= this.engine.param.MAXBITS_FIELD)
    {
      this.fpmul_mont(numArray1, this.engine.param.Montgomery_R2, numArray1);
      num += this.engine.param.MAXBITS_FIELD;
    }
    this.fpmul_mont(numArray1, this.engine.param.Montgomery_R2, numArray1);
    this.power2_setup(numArray2, 2 * (int) this.engine.param.MAXBITS_FIELD - (int) num, this.engine.param.NWORDS_FIELD);
    this.fpmul_mont(numArray1, numArray2, a);
  }

  internal void fp2inv_mont_bingcd(ulong[][] a)
  {
    ulong[][] numArray = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.fpsqr_mont(a[0], numArray[0]);
    this.fpsqr_mont(a[1], numArray[1]);
    this.fpaddPRIME(numArray[0], numArray[1], numArray[0]);
    this.fpinv_mont_bingcd(numArray[0]);
    this.fpnegPRIME(a[1]);
    this.fpmul_mont(a[0], numArray[0], a[0]);
    this.fpmul_mont(a[1], numArray[0], a[1]);
  }

  internal void fp2div2(ulong[][] a, ulong[][] c)
  {
    this.fpdiv2_PRIME(a[0], c[0]);
    this.fpdiv2_PRIME(a[1], c[1]);
  }

  private void fpdiv2_PRIME(ulong[] a, ulong[] c)
  {
    ulong y = 0;
    ulong num1 = (ulong) -((long) a[0] & 1L);
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong num2 = a[index] + y;
      c[index] = (this.engine.param.PRIME[index] & num1) + num2;
      y = this.is_digit_lessthan_ct(num2, y) | this.is_digit_lessthan_ct(c[index], num2);
    }
    this.mp_shiftr1(c);
  }

  private void mp_subPRIME_p2(ulong[] a, ulong[] b, ulong[] c)
  {
    ulong num1 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong x = a[index] - b[index];
      long num2 = (long) this.is_digit_lessthan_ct(a[index], b[index]) | (long) num1 & (long) this.is_digit_zero_ct(x);
      c[index] = x - num1;
      num1 = (ulong) num2;
    }
    ulong y = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong num3 = c[index] + y;
      c[index] = this.engine.param.PRIMEx2[index] + num3;
      y = this.is_digit_lessthan_ct(num3, y) | this.is_digit_lessthan_ct(c[index], num3);
    }
  }

  private void mp_subPRIME_p4(ulong[] a, ulong[] b, ulong[] c)
  {
    ulong num1 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong x = a[index] - b[index];
      long num2 = (long) this.is_digit_lessthan_ct(a[index], b[index]) | (long) num1 & (long) this.is_digit_zero_ct(x);
      c[index] = x - num1;
      num1 = (ulong) num2;
    }
    ulong y = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong num3 = c[index] + y;
      c[index] = this.engine.param.PRIMEx4[index] + num3;
      y = this.is_digit_lessthan_ct(num3, y) | this.is_digit_lessthan_ct(c[index], num3);
    }
  }

  private ulong digit_x_digit(ulong a, ulong b, out ulong low)
  {
    long num1 = (long) a & (long) uint.MaxValue;
    ulong num2 = a >> 32 /*0x20*/;
    ulong num3 = b & (ulong) uint.MaxValue;
    ulong num4 = b >> 32 /*0x20*/;
    ulong num5 = (ulong) num1 * num3;
    ulong num6 = (ulong) num1 * num4;
    ulong num7 = num2 * num3;
    ulong num8 = num2 * num4;
    low = num5 & (ulong) uint.MaxValue;
    long num9 = (long) (num5 >> 32 /*0x20*/);
    ulong num10 = num7 & (ulong) uint.MaxValue;
    ulong num11 = num6 & (ulong) uint.MaxValue;
    long num12 = (long) num10;
    ulong num13 = (ulong) (num9 + num12) + num11;
    ulong num14 = num13 >> 32 /*0x20*/;
    low ^= num13 << 32 /*0x20*/;
    long num15 = (long) (num7 >> 32 /*0x20*/);
    ulong num16 = num6 >> 32 /*0x20*/;
    ulong num17 = num8 & (ulong) uint.MaxValue;
    long num18 = (long) num16;
    ulong num19 = (ulong) (num15 + num18) + num17 + num14;
    long num20 = (long) num19 & (long) uint.MaxValue;
    ulong num21 = num19 & 18446744069414584320UL;
    long num22 = ((long) num8 & -4294967296L) + (long) num21;
    return (ulong) (num20 ^ num22);
  }

  private void rdc_mont(ulong[] ma, ulong[] mc)
  {
    ulong primeZeroWords = (ulong) this.engine.param.PRIME_ZERO_WORDS;
    ulong num1 = 0;
    ulong x1 = 0;
    ulong x2 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
      mc[index] = 0UL;
    ulong low;
    for (ulong index1 = 0; index1 < (ulong) this.engine.param.NWORDS_FIELD; ++index1)
    {
      for (ulong index2 = 0; index2 < index1; ++index2)
      {
        if (index2 < (ulong) ((long) index1 - (long) this.engine.param.PRIME_ZERO_WORDS + 1L))
        {
          ulong num2 = this.digit_x_digit(mc[index2], this.engine.param.PRIMEp1[checked ((ulong) unchecked ((long) index1 - (long) index2))], out low);
          x2 += low;
          ulong y = num2 + this.is_digit_lessthan_ct(x2, low);
          x1 += y;
          num1 += this.is_digit_lessthan_ct(x1, y);
        }
      }
      ulong y1 = ma[index1];
      ulong x3 = x2 + y1;
      ulong num3 = this.is_digit_lessthan_ct(x3, y1);
      ulong x4 = x1 + num3;
      ulong num4 = num3 & this.is_digit_zero_ct(x4);
      ulong num5 = num1 + num4;
      mc[index1] = x3;
      x2 = x4;
      x1 = num5;
      num1 = 0UL;
    }
    for (ulong nwordsField = (ulong) this.engine.param.NWORDS_FIELD; nwordsField < (ulong) (uint) (2 * (int) this.engine.param.NWORDS_FIELD - 1); ++nwordsField)
    {
      if (primeZeroWords > 0UL)
        --primeZeroWords;
      for (ulong index = (ulong) ((long) nwordsField - (long) this.engine.param.NWORDS_FIELD + 1L); index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
      {
        if (index < (ulong) this.engine.param.NWORDS_FIELD - primeZeroWords)
        {
          ulong num6 = this.digit_x_digit(mc[index], this.engine.param.PRIMEp1[checked ((ulong) unchecked ((long) nwordsField - (long) index))], out low);
          x2 += low;
          ulong y = num6 + this.is_digit_lessthan_ct(x2, low);
          x1 += y;
          num1 += this.is_digit_lessthan_ct(x1, y);
        }
      }
      ulong y2 = ma[nwordsField];
      ulong x5 = x2 + y2;
      ulong num7 = this.is_digit_lessthan_ct(x5, y2);
      ulong x6 = x1 + num7;
      ulong num8 = num7 & this.is_digit_zero_ct(x6);
      ulong num9 = num1 + num8;
      mc[checked ((ulong) unchecked ((long) nwordsField - (long) this.engine.param.NWORDS_FIELD))] = x5;
      x2 = x6;
      x1 = num9;
      num1 = 0UL;
    }
    ulong y3 = ma[2 * (int) this.engine.param.NWORDS_FIELD - 1];
    ulong x7 = x2 + y3;
    this.is_digit_lessthan_ct(x7, y3);
    mc[(int) this.engine.param.NWORDS_FIELD - 1] = x7;
  }

  internal static bool subarrayEquals(ulong[] a, ulong[] b, uint length)
  {
    for (uint index = 0; index < length; ++index)
    {
      if ((long) a[(int) index] != (long) b[(int) index])
        return false;
    }
    return true;
  }

  internal static bool subarrayEquals(ulong[][] a, ulong[][] b, uint length)
  {
    int length1 = b[0].Length;
    for (uint index = 0; index < length; ++index)
    {
      if ((long) a[(long) index / (long) length1][(long) index % (long) length1] != (long) b[(long) index / (long) length1][(long) index % (long) length1])
        return false;
    }
    return true;
  }

  internal static bool subarrayEquals(ulong[][] a, ulong[][] b, uint bOffset, uint length)
  {
    int length1 = b[0].Length;
    for (uint index = 0; index < length; ++index)
    {
      if ((long) a[(long) index / (long) length1][(long) index % (long) length1] != (long) b[(long) (index + bOffset) / (long) length1][(long) (index + bOffset) % (long) length1])
        return false;
    }
    return true;
  }

  internal static bool subarrayEquals(ulong[][] a, ulong[] b, uint bOffset, uint length)
  {
    int length1 = a[0].Length;
    for (uint index = 0; index < length; ++index)
    {
      if ((long) a[(long) index / (long) length1][(long) index % (long) length1] != (long) b[(int) index + (int) bOffset])
        return false;
    }
    return true;
  }

  internal void sqrt_Fp2(ulong[][] u, ulong[][] y)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray3 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray4 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    this.fpsqr_mont(u[0], numArray1);
    this.fpsqr_mont(u[1], numArray2);
    this.fpaddPRIME(numArray1, numArray2, numArray1);
    this.fpcopy(numArray1, 0L, numArray2);
    for (uint index = 0; index < this.engine.param.OALICE_BITS - 2U; ++index)
      this.fpsqr_mont(numArray2, numArray2);
    for (uint index = 0; index < this.engine.param.OBOB_EXPON; ++index)
    {
      this.fpsqr_mont(numArray2, numArray1);
      this.fpmul_mont(numArray2, numArray1, numArray2);
    }
    this.fpaddPRIME(u[0], numArray2, numArray1);
    this.fpdiv2_PRIME(numArray1, numArray1);
    this.fpcopy(numArray1, 0L, numArray3);
    this.fpinv_chain_mont(numArray3);
    this.fpmul_mont(numArray1, numArray3, numArray2);
    this.fpmul_mont(numArray3, u[1], numArray3);
    this.fpdiv2_PRIME(numArray3, numArray3);
    this.fpsqr_mont(numArray2, numArray4);
    this.fpcorrectionPRIME(numArray1);
    this.fpcorrectionPRIME(numArray4);
    if (Fpx.subarrayEquals(numArray1, numArray4, this.engine.param.NWORDS_FIELD))
    {
      this.fpcopy(numArray2, 0L, y[0]);
      this.fpcopy(numArray3, 0L, y[1]);
    }
    else
    {
      this.fpnegPRIME(numArray2);
      this.fpcopy(numArray3, 0L, y[0]);
      this.fpcopy(numArray2, 0L, y[1]);
    }
  }

  internal void fp2sqr_mont(ulong[][] a, ulong[][] c)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray3 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    long num1 = (long) this.mp_add(a[0], a[1], numArray1, this.engine.param.NWORDS_FIELD);
    this.mp_subPRIME_p4(a[0], a[1], numArray2);
    long num2 = (long) this.mp_add(a[0], a[0], numArray3, this.engine.param.NWORDS_FIELD);
    this.fpmul_mont(numArray1, numArray2, c[0]);
    this.fpmul_mont(numArray3, a[1], c[1]);
  }

  internal void fpaddPRIME(ulong[] a, ulong[] b, ulong[] c)
  {
    ulong y1 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong num = a[index] + y1;
      c[index] = b[index] + num;
      y1 = this.is_digit_lessthan_ct(num, y1) | this.is_digit_lessthan_ct(c[index], num);
    }
    ulong num1 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong x = c[index] - this.engine.param.PRIMEx2[index];
      long num2 = (long) this.is_digit_lessthan_ct(c[index], this.engine.param.PRIMEx2[index]) | (long) num1 & (long) this.is_digit_zero_ct(x);
      c[index] = x - num1;
      num1 = (ulong) num2;
    }
    ulong num3 = (ulong) -(long) num1;
    ulong y2 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong num4 = c[index] + y2;
      c[index] = (this.engine.param.PRIMEx2[index] & num3) + num4;
      y2 = this.is_digit_lessthan_ct(num4, y2) | this.is_digit_lessthan_ct(c[index], num4);
    }
  }

  internal void cube_Fp2_cycl(ulong[][] a, ulong[] one)
  {
    ulong[] numArray = new ulong[(int) this.engine.param.NWORDS_FIELD];
    this.fpaddPRIME(a[0], a[0], numArray);
    this.fpsqr_mont(numArray, numArray);
    this.fpsubPRIME(numArray, one, numArray);
    this.fpmul_mont(a[1], numArray, a[1]);
    this.fpsubPRIME(numArray, one, numArray);
    this.fpsubPRIME(numArray, one, numArray);
    this.fpmul_mont(a[0], numArray, a[0]);
  }

  internal void fpsubPRIME(ulong[] a, ulong[] b, uint bOffset, ulong[] c)
  {
    ulong num1 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong x = a[index] - b[checked ((ulong) unchecked ((long) index + (long) bOffset))];
      long num2 = (long) this.is_digit_lessthan_ct(a[index], b[checked ((ulong) unchecked ((long) index + (long) bOffset))]) | (long) num1 & (long) this.is_digit_zero_ct(x);
      c[index] = x - num1;
      num1 = (ulong) num2;
    }
    ulong num3 = (ulong) -(long) num1;
    ulong y = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong num4 = c[index] + y;
      c[index] = (this.engine.param.PRIMEx2[index] & num3) + num4;
      y = this.is_digit_lessthan_ct(num4, y) | this.is_digit_lessthan_ct(c[index], num4);
    }
  }

  internal void fpsubPRIME(ulong[] a, uint aOffset, ulong[] b, ulong[] c)
  {
    ulong num1 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong x = a[checked ((ulong) unchecked ((long) index + (long) aOffset))] - b[index];
      long num2 = (long) this.is_digit_lessthan_ct(a[checked ((ulong) unchecked ((long) index + (long) aOffset))], b[index]) | (long) num1 & (long) this.is_digit_zero_ct(x);
      c[index] = x - num1;
      num1 = (ulong) num2;
    }
    ulong num3 = (ulong) -(long) num1;
    ulong y = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong num4 = c[index] + y;
      c[index] = (this.engine.param.PRIMEx2[index] & num3) + num4;
      y = this.is_digit_lessthan_ct(num4, y) | this.is_digit_lessthan_ct(c[index], num4);
    }
  }

  internal void fpsubPRIME(ulong[] a, ulong[] b, ulong[] c)
  {
    ulong num1 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong x = a[index] - b[index];
      long num2 = (long) this.is_digit_lessthan_ct(a[index], b[index]) | (long) num1 & (long) this.is_digit_zero_ct(x);
      c[index] = x - num1;
      num1 = (ulong) num2;
    }
    ulong num3 = (ulong) -(long) num1;
    ulong y = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong num4 = c[index] + y;
      c[index] = (this.engine.param.PRIMEx2[index] & num3) + num4;
      y = this.is_digit_lessthan_ct(num4, y) | this.is_digit_lessthan_ct(c[index], num4);
    }
  }

  internal void fpnegPRIME(ulong[] a)
  {
    ulong num1 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong x = this.engine.param.PRIMEx2[index] - a[index];
      long num2 = (long) this.is_digit_lessthan_ct(this.engine.param.PRIMEx2[index], a[index]) | (long) num1 & (long) this.is_digit_zero_ct(x);
      a[index] = x - num1;
      num1 = (ulong) num2;
    }
  }

  internal void from_fp2mont(ulong[][] ma, ulong[][] c)
  {
    this.from_mont(ma[0], c[0]);
    this.from_mont(ma[1], c[1]);
  }

  internal void fp2_encode(ulong[][] x, byte[] enc, uint encOffset)
  {
    ulong[][] c = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.from_fp2mont(x, c);
    this.encode_to_bytes(c[0], enc, encOffset, this.engine.param.FP2_ENCODED_BYTES / 2U);
    this.encode_to_bytes(c[1], enc, encOffset + this.engine.param.FP2_ENCODED_BYTES / 2U, this.engine.param.FP2_ENCODED_BYTES / 2U);
  }

  internal void fp2_decode(byte[] x, ulong[][] dec, uint xOffset)
  {
    this.decode_to_digits(x, xOffset, dec[0], this.engine.param.FP2_ENCODED_BYTES / 2U, this.engine.param.NWORDS_FIELD);
    this.decode_to_digits(x, xOffset + this.engine.param.FP2_ENCODED_BYTES / 2U, dec[1], this.engine.param.FP2_ENCODED_BYTES / 2U, this.engine.param.NWORDS_FIELD);
    this.to_fp2mont(dec, dec);
  }

  internal void to_Montgomery_mod_order(
    ulong[] a,
    ulong[] mc,
    ulong[] order,
    ulong[] Montgomery_rprime,
    ulong[] Montgomery_Rprime)
  {
    this.Montgomery_multiply_mod_order(a, Montgomery_Rprime, mc, order, Montgomery_rprime);
  }

  internal void Montgomery_multiply_mod_order(
    ulong[] ma,
    ulong[] mb,
    ulong[] mc,
    ulong[] order,
    ulong[] Montgomery_rprime)
  {
    ulong[] numArray1 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray2 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray3 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    this.multiply(ma, mb, numArray1, this.engine.param.NWORDS_ORDER);
    this.multiply(numArray1, Montgomery_rprime, numArray2, this.engine.param.NWORDS_ORDER);
    this.multiply(numArray2, order, numArray3, this.engine.param.NWORDS_ORDER);
    ulong num1 = this.mp_add(numArray1, numArray3, numArray3, 2U * this.engine.param.NWORDS_ORDER);
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_ORDER; ++index)
      mc[index] = numArray3[checked ((ulong) unchecked ((long) this.engine.param.NWORDS_ORDER + (long) index))];
    ulong num2 = this.mp_sub(mc, order, mc, this.engine.param.NWORDS_ORDER);
    ulong num3 = num1 - num2;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_ORDER; ++index)
      numArray3[index] = order[index] & num3;
    long num4 = (long) this.mp_add(mc, numArray3, mc, this.engine.param.NWORDS_ORDER);
  }

  internal void inv_mod_orderA(ulong[] a, ulong[] c)
  {
    uint num1 = 0;
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray3 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] b = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] a1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong num2 = ulong.MaxValue >> (int) this.engine.param.NBITS_ORDER - (int) this.engine.param.OALICE_BITS;
    a1[(int) this.engine.param.NWORDS_ORDER - 1] = (ulong) (1L << 64 /*0x40*/ - ((int) this.engine.param.NBITS_ORDER - (int) this.engine.param.OALICE_BITS));
    b[0] = 1UL;
    long num3 = (long) this.mp_sub(a, b, numArray1, this.engine.param.NWORDS_ORDER);
    if (((long) a[0] & 1L) != 0L && !this.is_zero(numArray1, this.engine.param.NWORDS_ORDER))
    {
      long num4 = (long) this.mp_sub(a1, numArray1, c, this.engine.param.NWORDS_ORDER);
      long num5 = (long) this.mp_add(c, b, c, this.engine.param.NWORDS_ORDER);
      this.copy_words(numArray1, numArray2, this.engine.param.NWORDS_ORDER);
      while (((long) numArray2[0] & 1L) == 0L)
      {
        ++num1;
        this.mp_shiftr1(numArray2, this.engine.param.NWORDS_ORDER);
      }
      uint num6 = this.engine.param.OALICE_BITS / num1;
      for (uint index = 1; index < num6; index <<= 1)
      {
        this.multiply(numArray1, numArray1, numArray3, this.engine.param.NWORDS_ORDER);
        this.copy_words(numArray3, numArray1, this.engine.param.NWORDS_ORDER);
        numArray1[(int) this.engine.param.NWORDS_ORDER - 1] &= num2;
        long num7 = (long) this.mp_add(numArray1, b, numArray2, this.engine.param.NWORDS_ORDER);
        numArray2[(int) this.engine.param.NWORDS_ORDER - 1] &= num2;
        this.multiply(c, numArray2, numArray3, this.engine.param.NWORDS_ORDER);
        this.copy_words(numArray3, c, this.engine.param.NWORDS_ORDER);
        c[(int) this.engine.param.NWORDS_ORDER - 1] &= num2;
      }
    }
    else
    {
      this.copy_words(a, c, this.engine.param.NWORDS_ORDER);
      c[(int) this.engine.param.NWORDS_ORDER - 1] &= num2;
    }
  }

  internal void multiply(ulong[] a, ulong[] b, ulong[] c, uint nwords)
  {
    ulong num1 = 0;
    ulong x1 = 0;
    ulong x2 = 0;
    ulong low;
    for (ulong index1 = 0; index1 < (ulong) nwords; ++index1)
    {
      for (ulong index2 = 0; index2 <= index1; ++index2)
      {
        ulong num2 = this.digit_x_digit(a[index2], b[checked ((ulong) unchecked ((long) index1 - (long) index2))], out low);
        x2 += low;
        ulong y = num2 + this.is_digit_lessthan_ct(x2, low);
        x1 += y;
        num1 += this.is_digit_lessthan_ct(x1, y);
      }
      c[index1] = x2;
      x2 = x1;
      x1 = num1;
      num1 = 0UL;
    }
    for (ulong index3 = (ulong) nwords; index3 < (ulong) (uint) (2 * (int) nwords - 1); ++index3)
    {
      for (ulong index4 = (ulong) ((long) index3 - (long) nwords + 1L); index4 < (ulong) nwords; ++index4)
      {
        ulong num3 = this.digit_x_digit(a[index4], b[checked ((ulong) unchecked ((long) index3 - (long) index4))], out low);
        x2 += low;
        ulong y = num3 + this.is_digit_lessthan_ct(x2, low);
        x1 += y;
        num1 += this.is_digit_lessthan_ct(x1, y);
      }
      c[index3] = x2;
      x2 = x1;
      x1 = num1;
      num1 = 0UL;
    }
    c[2 * (int) nwords - 1] = x2;
  }

  private bool is_zero_mod_order(ulong[] x)
  {
    for (uint index = 0; index < this.engine.param.NWORDS_ORDER; ++index)
    {
      if (x[(int) index] != 0UL)
        return false;
    }
    return true;
  }

  private bool is_even_mod_order(ulong[] x) => ((long) x[0] & 1L) == 0L;

  private bool is_lt_mod_order(ulong[] x, ulong[] y)
  {
    for (int index = (int) this.engine.param.NWORDS_ORDER - 1; index >= 0; --index)
    {
      if (x[index] < y[index])
        return true;
      if (x[index] > y[index])
        return false;
    }
    return false;
  }

  private bool is_zero(ulong[] a, uint nwords)
  {
    for (uint index = 0; index < nwords; ++index)
    {
      if (a[(int) index] != 0UL)
        return false;
    }
    return true;
  }

  private uint Montgomery_inversion_mod_order_bingcd_partial(ulong[] a, ulong[] x1, ulong[] order)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray3 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    this.copy_words(a, numArray1, this.engine.param.NWORDS_ORDER);
    this.copy_words(order, numArray2, this.engine.param.NWORDS_ORDER);
    this.copy_words(numArray3, x1, this.engine.param.NWORDS_ORDER);
    x1[0] = 1UL;
    uint num1 = 0;
    while (!this.is_zero_mod_order(numArray2))
    {
      uint nwords = ++num1 / Internal.RADIX + 1U;
      if (nwords < this.engine.param.NWORDS_ORDER)
      {
        if (this.is_even_mod_order(numArray2))
        {
          this.mp_shiftr1(numArray2, this.engine.param.NWORDS_ORDER);
          this.mp_shiftl1(x1, nwords);
        }
        else if (this.is_even_mod_order(numArray1))
        {
          this.mp_shiftr1(numArray1, this.engine.param.NWORDS_ORDER);
          this.mp_shiftl1(numArray3, nwords);
        }
        else if (!this.is_lt_mod_order(numArray2, numArray1))
        {
          long num2 = (long) this.mp_sub(numArray2, numArray1, numArray2, this.engine.param.NWORDS_ORDER);
          this.mp_shiftr1(numArray2, this.engine.param.NWORDS_ORDER);
          long num3 = (long) this.mp_add(x1, numArray3, numArray3, nwords);
          this.mp_shiftl1(x1, nwords);
        }
        else
        {
          long num4 = (long) this.mp_sub(numArray1, numArray2, numArray1, this.engine.param.NWORDS_ORDER);
          this.mp_shiftr1(numArray1, this.engine.param.NWORDS_ORDER);
          long num5 = (long) this.mp_add(x1, numArray3, x1, nwords);
          this.mp_shiftl1(numArray3, nwords);
        }
      }
      else if (this.is_even_mod_order(numArray2))
      {
        this.mp_shiftr1(numArray2, this.engine.param.NWORDS_ORDER);
        this.mp_shiftl1(x1, this.engine.param.NWORDS_ORDER);
      }
      else if (this.is_even_mod_order(numArray1))
      {
        this.mp_shiftr1(numArray1, this.engine.param.NWORDS_ORDER);
        this.mp_shiftl1(numArray3, this.engine.param.NWORDS_ORDER);
      }
      else if (!this.is_lt_mod_order(numArray2, numArray1))
      {
        long num6 = (long) this.mp_sub(numArray2, numArray1, numArray2, this.engine.param.NWORDS_ORDER);
        this.mp_shiftr1(numArray2, this.engine.param.NWORDS_ORDER);
        long num7 = (long) this.mp_add(x1, numArray3, numArray3, this.engine.param.NWORDS_ORDER);
        this.mp_shiftl1(x1, this.engine.param.NWORDS_ORDER);
      }
      else
      {
        long num8 = (long) this.mp_sub(numArray1, numArray2, numArray1, this.engine.param.NWORDS_ORDER);
        this.mp_shiftr1(numArray1, this.engine.param.NWORDS_ORDER);
        long num9 = (long) this.mp_add(x1, numArray3, x1, this.engine.param.NWORDS_ORDER);
        this.mp_shiftl1(numArray3, this.engine.param.NWORDS_ORDER);
      }
    }
    if (this.is_lt_mod_order(order, x1))
    {
      long num10 = (long) this.mp_sub(x1, order, x1, this.engine.param.NWORDS_ORDER);
    }
    return num1;
  }

  internal void Montgomery_inversion_mod_order_bingcd(
    ulong[] a,
    ulong[] c,
    ulong[] order,
    ulong[] Montgomery_rprime,
    ulong[] Montgomery_Rprime)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    if (this.is_zero(a, this.engine.param.NWORDS_ORDER))
    {
      this.copy_words(numArray2, c, this.engine.param.NWORDS_ORDER);
    }
    else
    {
      uint num = this.Montgomery_inversion_mod_order_bingcd_partial(a, numArray1, order);
      if (num <= this.engine.param.NBITS_ORDER)
      {
        this.Montgomery_multiply_mod_order(numArray1, Montgomery_Rprime, numArray1, order, Montgomery_rprime);
        num += this.engine.param.NBITS_ORDER;
      }
      this.Montgomery_multiply_mod_order(numArray1, Montgomery_Rprime, numArray1, order, Montgomery_rprime);
      this.power2_setup(numArray2, 2 * (int) this.engine.param.NBITS_ORDER - (int) num, this.engine.param.NWORDS_ORDER);
      this.Montgomery_multiply_mod_order(numArray1, numArray2, c, order, Montgomery_rprime);
    }
  }

  internal void from_Montgomery_mod_order(
    ulong[] ma,
    ulong[] c,
    ulong[] order,
    ulong[] Montgomery_rprime)
  {
    ulong[] mb = new ulong[(int) this.engine.param.NWORDS_ORDER];
    mb[0] = 1UL;
    this.Montgomery_multiply_mod_order(ma, mb, c, order, Montgomery_rprime);
  }

  internal uint mod3(ulong[] a)
  {
    ulong num = 0;
    for (int index = 0; (long) index < (long) this.engine.param.NWORDS_ORDER; ++index)
      num = num + (a[index] >> 32 /*0x20*/) + (a[index] & (ulong) uint.MaxValue);
    return (uint) (num % 3UL);
  }

  internal void to_fp2mont(ulong[][] a, ulong[][] mc)
  {
    this.to_mont(a[0], mc[0]);
    this.to_mont(a[1], mc[1]);
  }

  private void to_mont(ulong[] a, ulong[] mc)
  {
    this.fpmul_mont(a, this.engine.param.Montgomery_R2, mc);
  }

  internal void fpcorrectionPRIME(ulong[] a)
  {
    ulong num1 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong x = a[index] - this.engine.param.PRIME[index];
      long num2 = (long) this.is_digit_lessthan_ct(a[index], this.engine.param.PRIME[index]) | (long) num1 & (long) this.is_digit_zero_ct(x);
      a[index] = x - num1;
      num1 = (ulong) num2;
    }
    ulong num3 = (ulong) -(long) num1;
    ulong y = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong num4 = a[index] + y;
      a[index] = (this.engine.param.PRIME[index] & num3) + num4;
      y = this.is_digit_lessthan_ct(num4, y) | this.is_digit_lessthan_ct(a[index], num4);
    }
  }

  internal byte cmp_f2elm(ulong[][] x, ulong[][] y)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    byte num = 0;
    this.fp2copy(x, numArray1);
    this.fp2copy(y, numArray2);
    this.fp2correction(numArray1);
    this.fp2correction(numArray2);
    for (int index = (int) this.engine.param.NWORDS_FIELD - 1; index >= 0; --index)
      num |= (byte) ((long) numArray1[0][index] ^ (long) numArray2[0][index] | (long) numArray1[1][index] ^ (long) numArray2[1][index]);
    return (byte) ((uint) -num >> 7);
  }

  internal void encode_to_bytes(ulong[] x, byte[] enc, uint encOffset, uint nbytes)
  {
    byte[] numArray = new byte[(long) (uint) ((int) nbytes * 4 + 7) & -8L];
    Pack.UInt64_To_LE(x, numArray, 0);
    Array.Copy((Array) numArray, 0L, (Array) enc, (long) encOffset, (long) nbytes);
  }

  internal void decode_to_digits(byte[] x, uint xOffset, ulong[] dec, uint nbytes, uint ndigits)
  {
    dec[(int) ndigits - 1] = 0UL;
    byte[] numArray = new byte[(long) (nbytes + 7U) & -8L];
    Array.Copy((Array) x, (long) xOffset, (Array) numArray, 0L, (long) nbytes);
    Pack.LE_To_UInt64(numArray, 0, dec);
  }

  internal void fp2_conj(ulong[][] v, ulong[][] r)
  {
    this.fpcopy(v[0], 0L, r[0]);
    this.fpcopy(v[1], 0L, r[1]);
    if (this.is_felm_zero(r[1]))
      return;
    this.fpnegPRIME(r[1]);
  }

  private void from_mont(ulong[] ma, ulong[] c)
  {
    ulong[] mb = new ulong[(int) this.engine.param.NWORDS_FIELD];
    mb[0] = 1UL;
    this.fpmul_mont(ma, mb, c);
    this.fpcorrectionPRIME(c);
  }

  private void mp_shiftr1(ulong[] x)
  {
    for (uint index = 0; index < this.engine.param.NWORDS_FIELD - 1U; ++index)
      x[(int) index] = x[(int) index] >> 1 ^ x[(int) index + 1] << (int) Internal.RADIX - 1;
    x[(int) this.engine.param.NWORDS_FIELD - 1] >>= 1;
  }

  private void mp_shiftr1(ulong[] x, uint nwords)
  {
    for (uint index = 0; index < nwords - 1U; ++index)
      x[(int) index] = x[(int) index] >> 1 ^ x[(int) index + 1] << (int) Internal.RADIX - 1;
    x[(int) nwords - 1] >>= 1;
  }

  internal void fp2copy(ulong[][] a, ulong[][] c)
  {
    this.fpcopy(a[0], 0L, c[0]);
    this.fpcopy(a[1], 0L, c[1]);
  }

  internal void fp2copy(ulong[][] a, uint aOffset, ulong[][] c)
  {
    this.fpcopy(a[(int) aOffset], 0L, c[0]);
    this.fpcopy(a[1 + (int) aOffset], 0L, c[1]);
  }

  internal void fp2copy(ulong[] a, uint aOffset, ulong[][] c)
  {
    this.fpcopy(a, (long) aOffset, c[0]);
    this.fpcopy(a, (long) (aOffset + this.engine.param.NWORDS_FIELD), c[1]);
  }

  internal void fpzero(ulong[] a)
  {
    for (uint index = 0; index < this.engine.param.NWORDS_FIELD; ++index)
      a[(int) index] = 0UL;
  }

  internal void mp2_sub_p2(ulong[][] a, ulong[][] b, ulong[][] c)
  {
    this.mp_subPRIME_p2(a[0], b[0], c[0]);
    this.mp_subPRIME_p2(a[1], b[1], c[1]);
  }

  internal void mp_mul(ulong[] a, ulong[] b, ulong[] c, uint nwords)
  {
    ulong num1 = 0;
    ulong x1 = 0;
    ulong x2 = 0;
    ulong low;
    for (ulong index1 = 0; index1 < (ulong) nwords; ++index1)
    {
      for (ulong index2 = 0; index2 <= index1; ++index2)
      {
        ulong num2 = this.digit_x_digit(a[index2], b[checked ((ulong) unchecked ((long) index1 - (long) index2))], out low);
        x2 += low;
        ulong y = num2 + this.is_digit_lessthan_ct(x2, low);
        x1 += y;
        num1 += this.is_digit_lessthan_ct(x1, y);
      }
      c[index1] = x2;
      x2 = x1;
      x1 = num1;
      num1 = 0UL;
    }
    for (ulong index3 = (ulong) nwords; index3 < (ulong) (uint) (2 * (int) nwords - 1); ++index3)
    {
      for (ulong index4 = (ulong) ((long) index3 - (long) nwords + 1L); index4 < (ulong) nwords; ++index4)
      {
        ulong num3 = this.digit_x_digit(a[index4], b[checked ((ulong) unchecked ((long) index3 - (long) index4))], out low);
        x2 += low;
        ulong y = num3 + this.is_digit_lessthan_ct(x2, low);
        x1 += y;
        num1 += this.is_digit_lessthan_ct(x1, y);
      }
      c[index3] = x2;
      x2 = x1;
      x1 = num1;
      num1 = 0UL;
    }
    c[2 * (int) nwords - 1] = x2;
  }

  internal void mp_mul(ulong[] a, uint aOffset, ulong[] b, ulong[] c, uint nwords)
  {
    ulong num1 = 0;
    ulong x1 = 0;
    ulong x2 = 0;
    ulong low;
    for (ulong index1 = 0; index1 < (ulong) nwords; ++index1)
    {
      for (ulong index2 = 0; index2 <= index1; ++index2)
      {
        ulong num2 = this.digit_x_digit(a[checked ((ulong) unchecked ((long) index2 + (long) aOffset))], b[checked ((ulong) unchecked ((long) index1 - (long) index2))], out low);
        x2 += low;
        ulong y = num2 + this.is_digit_lessthan_ct(x2, low);
        x1 += y;
        num1 += this.is_digit_lessthan_ct(x1, y);
      }
      c[index1] = x2;
      x2 = x1;
      x1 = num1;
      num1 = 0UL;
    }
    for (ulong index3 = (ulong) nwords; index3 < (ulong) (uint) (2 * (int) nwords - 1); ++index3)
    {
      for (ulong index4 = (ulong) ((long) index3 - (long) nwords + 1L); index4 < (ulong) nwords; ++index4)
      {
        ulong num3 = this.digit_x_digit(a[checked ((ulong) unchecked ((long) index4 + (long) aOffset))], b[checked ((ulong) unchecked ((long) index3 - (long) index4))], out low);
        x2 += low;
        ulong y = num3 + this.is_digit_lessthan_ct(x2, low);
        x1 += y;
        num1 += this.is_digit_lessthan_ct(x1, y);
      }
      c[index3] = x2;
      x2 = x1;
      x1 = num1;
      num1 = 0UL;
    }
    c[2 * (int) nwords - 1] = x2;
  }

  internal void fp2mul_mont(ulong[][] a, ulong[][] b, ulong[][] c)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray3 = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray4 = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray5 = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    long num1 = (long) this.mp_add(a[0], a[1], numArray1, this.engine.param.NWORDS_FIELD);
    long num2 = (long) this.mp_add(b[0], b[1], numArray2, this.engine.param.NWORDS_FIELD);
    this.mp_mul(a[0], b[0], numArray3, this.engine.param.NWORDS_FIELD);
    this.mp_mul(a[1], b[1], numArray4, this.engine.param.NWORDS_FIELD);
    this.mp_mul(numArray1, numArray2, numArray5, this.engine.param.NWORDS_FIELD);
    this.mp_dblsubfast(numArray3, numArray4, numArray5);
    this.mp_subaddfast(numArray3, numArray4, numArray3);
    this.rdc_mont(numArray5, c[1]);
    this.rdc_mont(numArray3, c[0]);
  }

  internal void fp2mul_mont(ulong[][] a, ulong[][] b, uint bOffset, ulong[][] c)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray3 = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray4 = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray5 = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    long num1 = (long) this.mp_add(a[0], a[1], numArray1, this.engine.param.NWORDS_FIELD);
    long num2 = (long) this.mp_add(b[(int) bOffset], b[(int) bOffset + 1], numArray2, this.engine.param.NWORDS_FIELD);
    this.mp_mul(a[0], b[(int) bOffset], numArray3, this.engine.param.NWORDS_FIELD);
    this.mp_mul(a[1], b[(int) bOffset + 1], numArray4, this.engine.param.NWORDS_FIELD);
    this.mp_mul(numArray1, numArray2, numArray5, this.engine.param.NWORDS_FIELD);
    this.mp_dblsubfast(numArray3, numArray4, numArray5);
    this.mp_subaddfast(numArray3, numArray4, numArray3);
    this.rdc_mont(numArray5, c[1]);
    this.rdc_mont(numArray3, c[0]);
  }

  internal void fp2mul_mont(ulong[][] a, ulong[] b, uint bOffset, ulong[][] c)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray3 = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray4 = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray5 = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    long num1 = (long) this.mp_add(a[0], a[1], numArray1, this.engine.param.NWORDS_FIELD);
    long num2 = (long) this.mp_add(b, bOffset, b, bOffset + this.engine.param.NWORDS_FIELD, numArray2, 0U, this.engine.param.NWORDS_FIELD);
    this.mp_mul(b, bOffset, a[0], numArray3, this.engine.param.NWORDS_FIELD);
    this.mp_mul(b, bOffset + this.engine.param.NWORDS_FIELD, a[1], numArray4, this.engine.param.NWORDS_FIELD);
    this.mp_mul(numArray1, numArray2, numArray5, this.engine.param.NWORDS_FIELD);
    this.mp_dblsubfast(numArray3, numArray4, numArray5);
    this.mp_subaddfast(numArray3, numArray4, numArray3);
    this.rdc_mont(numArray5, c[1]);
    this.rdc_mont(numArray3, c[0]);
  }

  private void mp_dblsubfast(ulong[] a, ulong[] b, ulong[] c)
  {
    long num1 = (long) this.mp_sub(c, a, c, 2U * this.engine.param.NWORDS_FIELD);
    long num2 = (long) this.mp_sub(c, b, c, 2U * this.engine.param.NWORDS_FIELD);
  }

  internal ulong mp_sub(ulong[] a, ulong[] b, ulong[] c, uint nwords)
  {
    ulong num1 = 0;
    for (ulong index = 0; index < (ulong) nwords; ++index)
    {
      ulong x = a[index] - b[index];
      long num2 = (long) this.is_digit_lessthan_ct(a[index], b[index]) | (long) num1 & (long) this.is_digit_zero_ct(x);
      c[index] = x - num1;
      num1 = (ulong) num2;
    }
    return num1;
  }

  internal bool is_orderelm_lt(ulong[] x, ulong[] y)
  {
    for (int index = (int) this.engine.param.NWORDS_ORDER - 1; index >= 0; --index)
    {
      if (x[index] < y[index])
        return true;
      if (x[index] > y[index])
        return false;
    }
    return false;
  }

  private void mp_subaddfast(ulong[] a, ulong[] b, ulong[] c)
  {
    ulong[] b1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong num1 = (ulong) -(long) this.mp_sub(a, b, c, 2U * this.engine.param.NWORDS_FIELD);
    for (uint index = 0; index < this.engine.param.NWORDS_FIELD; ++index)
      b1[(int) index] = this.engine.param.PRIME[(int) index] & num1;
    long num2 = (long) this.mp_add(c, this.engine.param.NWORDS_FIELD, b1, c, this.engine.param.NWORDS_FIELD, this.engine.param.NWORDS_FIELD);
  }

  internal void fpsqr_mont(ulong[] ma, ulong[] mc)
  {
    ulong[] numArray = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    this.mp_mul(ma, ma, numArray, this.engine.param.NWORDS_FIELD);
    this.rdc_mont(numArray, mc);
  }

  private void fpinv_mont(ulong[] a)
  {
    ulong[] numArray = new ulong[(int) this.engine.param.NWORDS_FIELD];
    this.fpcopy(a, 0L, numArray);
    this.fpinv_chain_mont(numArray);
    this.fpsqr_mont(numArray, numArray);
    this.fpsqr_mont(numArray, numArray);
    this.fpmul_mont(a, numArray, a);
  }

  internal void fp2inv_mont(ulong[][] a)
  {
    ulong[][] numArray = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.fpsqr_mont(a[0], numArray[0]);
    this.fpsqr_mont(a[1], numArray[1]);
    this.fpaddPRIME(numArray[0], numArray[1], numArray[0]);
    this.fpinv_mont(numArray[0]);
    this.fpnegPRIME(a[1]);
    this.fpmul_mont(a[0], numArray[0], a[0]);
    this.fpmul_mont(a[1], numArray[0], a[1]);
  }

  internal void mul3(byte[] a)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    this.decode_to_digits(a, 0U, numArray1, this.engine.param.SECRETKEY_B_BYTES, this.engine.param.NWORDS_ORDER);
    long num1 = (long) this.mp_add(numArray1, numArray1, numArray2, this.engine.param.NWORDS_ORDER);
    long num2 = (long) this.mp_add(numArray1, numArray2, numArray1, this.engine.param.NWORDS_ORDER);
    this.encode_to_bytes(numArray1, a, 0U, this.engine.param.SECRETKEY_B_BYTES);
  }

  internal byte ct_compare(byte[] a, byte[] b, uint len)
  {
    byte num = 0;
    for (uint index = 0; index < len; ++index)
      num |= (byte) ((uint) a[(int) index] ^ (uint) b[(int) index]);
    return (byte) ((uint) -num >> 7);
  }

  internal void ct_cmov(byte[] r, byte[] a, uint len, byte selector)
  {
    for (uint index = 0; index < len; ++index)
      r[(int) index] ^= (byte) ((uint) selector & ((uint) a[(int) index] ^ (uint) r[(int) index]));
  }

  internal void copy_words(ulong[] a, ulong[] c, uint nwords)
  {
    for (uint index = 0; index < nwords; ++index)
      c[(int) index] = a[(int) index];
  }

  internal void fp2shl(ulong[][] a, uint k, ulong[][] c)
  {
    this.fp2copy(a, c);
    for (uint index = 0; index < k; ++index)
      this.fp2add(c, c, c);
  }

  internal void copy_words(PointProj a, PointProj c)
  {
    for (uint index = 0; index < this.engine.param.NWORDS_FIELD; ++index)
    {
      c.X[0][(int) index] = a.X[0][(int) index];
      c.X[1][(int) index] = a.X[1][(int) index];
      c.Z[0][(int) index] = a.Z[0][(int) index];
      c.Z[1][(int) index] = a.Z[1][(int) index];
    }
  }

  internal void Montgomery_neg(ulong[] a, ulong[] order)
  {
    ulong num1 = 0;
    for (ulong index = 0; index < (ulong) this.engine.param.NWORDS_ORDER; ++index)
    {
      ulong x = order[index] - a[index];
      long num2 = (long) this.is_digit_lessthan_ct(order[index], a[index]) | (long) num1 & (long) this.is_digit_zero_ct(x);
      a[index] = x - num1;
      num1 = (ulong) num2;
    }
  }

  internal void fp2add(ulong[][] a, ulong[][] b, ulong[][] c)
  {
    this.fpaddPRIME(a[0], b[0], c[0]);
    this.fpaddPRIME(a[1], b[1], c[1]);
  }

  internal void fp2sub(ulong[][] a, ulong[][] b, ulong[][] c)
  {
    this.fpsubPRIME(a[0], b[0], c[0]);
    this.fpsubPRIME(a[1], b[1], c[1]);
  }

  private void mp2_sub_p4(ulong[][] a, ulong[][] b, ulong[][] c)
  {
    this.mp_subPRIME_p4(a[0], b[0], c[0]);
    this.mp_subPRIME_p4(a[1], b[1], c[1]);
  }

  internal void fpmul_mont(ulong[] ma, ulong[] mb, ulong[] mc)
  {
    ulong[] numArray = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    this.mp_mul(ma, mb, numArray, this.engine.param.NWORDS_FIELD);
    this.rdc_mont(numArray, mc);
  }

  internal void fpmul_mont(ulong[] ma, uint maOffset, ulong[] mb, ulong[] mc)
  {
    ulong[] numArray = new ulong[2 * (int) this.engine.param.NWORDS_FIELD];
    this.mp_mul(ma, maOffset, mb, numArray, this.engine.param.NWORDS_FIELD);
    this.rdc_mont(numArray, mc);
  }

  private void fpinv_chain_mont(ulong[] a)
  {
    if (this.engine.param.NBITS_FIELD == 434U)
    {
      ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
      ulong[][] numArray2 = SikeUtilities.InitArray(31U /*0x1F*/, this.engine.param.NWORDS_FIELD);
      this.fpsqr_mont(a, numArray1);
      this.fpmul_mont(a, numArray1, numArray2[0]);
      for (uint index = 0; index <= 29U; ++index)
        this.fpmul_mont(numArray2[(int) index], numArray1, numArray2[(int) index + 1]);
      this.fpcopy(a, 0L, numArray1);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[5], numArray1, numArray1);
      for (uint index = 0; index < 10U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[14], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[3], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[23], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[13], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[24], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[7], numArray1, numArray1);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[12], numArray1, numArray1);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[30], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[1], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[30], numArray1, numArray1);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[21], numArray1, numArray1);
      for (uint index = 0; index < 9U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[2], numArray1, numArray1);
      for (uint index = 0; index < 9U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[19], numArray1, numArray1);
      for (uint index = 0; index < 9U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[1], numArray1, numArray1);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[24], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[26], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[16 /*0x10*/], numArray1, numArray1);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[10], numArray1, numArray1);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[6], numArray1, numArray1);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[0], numArray1, numArray1);
      for (uint index = 0; index < 9U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[20], numArray1, numArray1);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[9], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[25], numArray1, numArray1);
      for (uint index = 0; index < 9U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[30], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[26], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(a, numArray1, numArray1);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[28], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[6], numArray1, numArray1);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[10], numArray1, numArray1);
      for (uint index = 0; index < 9U; ++index)
        this.fpsqr_mont(numArray1, numArray1);
      this.fpmul_mont(numArray2[22], numArray1, numArray1);
      for (uint index1 = 0; index1 < 35U; ++index1)
      {
        for (uint index2 = 0; index2 < 6U; ++index2)
          this.fpsqr_mont(numArray1, numArray1);
        this.fpmul_mont(numArray2[30], numArray1, numArray1);
      }
      this.fpcopy(numArray1, 0L, a);
    }
    if (this.engine.param.NBITS_FIELD == 503U)
    {
      ulong[][] numArray3 = SikeUtilities.InitArray(15U, this.engine.param.NWORDS_FIELD);
      ulong[] numArray4 = new ulong[(int) this.engine.param.NWORDS_FIELD];
      this.fpsqr_mont(a, numArray4);
      this.fpmul_mont(a, numArray4, numArray3[0]);
      for (uint index = 0; index <= 13U; ++index)
        this.fpmul_mont(numArray3[(int) index], numArray4, numArray3[(int) index + 1]);
      this.fpcopy(a, 0L, numArray4);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(a, numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[8], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[6], numArray4, numArray4);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[9], numArray4, numArray4);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[0], numArray4, numArray4);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(a, numArray4, numArray4);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[6], numArray4, numArray4);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[2], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[8], numArray4, numArray4);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(a, numArray4, numArray4);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[10], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[0], numArray4, numArray4);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[10], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[10], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[5], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[2], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[6], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[3], numArray4, numArray4);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[5], numArray4, numArray4);
      for (uint index = 0; index < 12U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[12], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[8], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[6], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[12], numArray4, numArray4);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[11], numArray4, numArray4);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[6], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[5], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[14], numArray4, numArray4);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[14], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[5], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[6], numArray4, numArray4);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[8], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(a, numArray4, numArray4);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[4], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[6], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[5], numArray4, numArray4);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[7], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(a, numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[0], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[11], numArray4, numArray4);
      for (uint index = 0; index < 5U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[13], numArray4, numArray4);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[1], numArray4, numArray4);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray4, numArray4);
      this.fpmul_mont(numArray3[10], numArray4, numArray4);
      for (uint index3 = 0; index3 < 49U; ++index3)
      {
        for (uint index4 = 0; index4 < 5U; ++index4)
          this.fpsqr_mont(numArray4, numArray4);
        this.fpmul_mont(numArray3[14], numArray4, numArray4);
      }
      this.fpcopy(numArray4, 0L, a);
    }
    if (this.engine.param.NBITS_FIELD == 610U)
    {
      ulong[][] numArray5 = SikeUtilities.InitArray(31U /*0x1F*/, this.engine.param.NWORDS_FIELD);
      ulong[] numArray6 = new ulong[(int) this.engine.param.NWORDS_FIELD];
      this.fpsqr_mont(a, numArray6);
      this.fpmul_mont(a, numArray6, numArray5[0]);
      for (uint index = 0; index <= 29U; ++index)
        this.fpmul_mont(numArray5[(int) index], numArray6, numArray5[(int) index + 1]);
      this.fpcopy(a, 0L, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[6], numArray6, numArray6);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[30], numArray6, numArray6);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[25], numArray6, numArray6);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[28], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[7], numArray6, numArray6);
      for (uint index = 0; index < 11U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[11], numArray6, numArray6);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(a, numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[0], numArray6, numArray6);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[3], numArray6, numArray6);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[16 /*0x10*/], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[24], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[28], numArray6, numArray6);
      for (uint index = 0; index < 9U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[16 /*0x10*/], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[4], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[3], numArray6, numArray6);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[20], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[11], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[14], numArray6, numArray6);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[15], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[0], numArray6, numArray6);
      for (uint index = 0; index < 9U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[15], numArray6, numArray6);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[19], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[9], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[5], numArray6, numArray6);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[27], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[28], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[29], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[1], numArray6, numArray6);
      for (uint index = 0; index < 9U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[3], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[2], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[30], numArray6, numArray6);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[25], numArray6, numArray6);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[28], numArray6, numArray6);
      for (uint index = 0; index < 9U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[22], numArray6, numArray6);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[3], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[22], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[7], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[9], numArray6, numArray6);
      for (uint index = 0; index < 6U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[4], numArray6, numArray6);
      for (uint index = 0; index < 7U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[20], numArray6, numArray6);
      for (uint index = 0; index < 11U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[10], numArray6, numArray6);
      for (uint index = 0; index < 8U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[26], numArray6, numArray6);
      for (uint index = 0; index < 11U; ++index)
        this.fpsqr_mont(numArray6, numArray6);
      this.fpmul_mont(numArray5[2], numArray6, numArray6);
      for (uint index5 = 0; index5 < 50U; ++index5)
      {
        for (uint index6 = 0; index6 < 6U; ++index6)
          this.fpsqr_mont(numArray6, numArray6);
        this.fpmul_mont(numArray5[30], numArray6, numArray6);
      }
      this.fpcopy(numArray6, 0L, a);
    }
    if (this.engine.param.NBITS_FIELD != 751U)
      return;
    ulong[][] numArray7 = SikeUtilities.InitArray(27U, this.engine.param.NWORDS_FIELD);
    ulong[] numArray8 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    this.fpsqr_mont(a, numArray8);
    this.fpmul_mont(a, numArray8, numArray7[0]);
    this.fpmul_mont(numArray7[0], numArray8, numArray7[1]);
    this.fpmul_mont(numArray7[1], numArray8, numArray7[2]);
    this.fpmul_mont(numArray7[2], numArray8, numArray7[3]);
    this.fpmul_mont(numArray7[3], numArray8, numArray7[3]);
    for (uint index = 3; index <= 8U; ++index)
      this.fpmul_mont(numArray7[(int) index], numArray8, numArray7[(int) index + 1]);
    this.fpmul_mont(numArray7[9], numArray8, numArray7[9]);
    for (uint index = 9; index <= 20U; ++index)
      this.fpmul_mont(numArray7[(int) index], numArray8, numArray7[(int) index + 1]);
    this.fpmul_mont(numArray7[21], numArray8, numArray7[21]);
    for (uint index = 21; index <= 24U; ++index)
      this.fpmul_mont(numArray7[(int) index], numArray8, numArray7[(int) index + 1]);
    this.fpmul_mont(numArray7[25], numArray8, numArray7[25]);
    this.fpmul_mont(numArray7[25], numArray8, numArray7[26]);
    this.fpcopy(a, 0L, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[20], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[24], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[11], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[8], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[2], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[23], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[2], numArray8, numArray8);
    for (uint index = 0; index < 9U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[2], numArray8, numArray8);
    for (uint index = 0; index < 10U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[15], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[13], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[26], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[20], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[11], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[10], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[14], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[4], numArray8, numArray8);
    for (uint index = 0; index < 10U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[18], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[1], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[22], numArray8, numArray8);
    for (uint index = 0; index < 10U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[6], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[24], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[9], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[18], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[17], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(a, numArray8, numArray8);
    for (uint index = 0; index < 10U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[16 /*0x10*/], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[7], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[0], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[12], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[19], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[22], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[25], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[2], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[10], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[22], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[18], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[4], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[14], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[13], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[5], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[23], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[21], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[2], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[23], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[12], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[9], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[3], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[13], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[17], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[26], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[5], numArray8, numArray8);
    for (uint index = 0; index < 8U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[8], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[2], numArray8, numArray8);
    for (uint index = 0; index < 6U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[11], numArray8, numArray8);
    for (uint index = 0; index < 7U; ++index)
      this.fpsqr_mont(numArray8, numArray8);
    this.fpmul_mont(numArray7[20], numArray8, numArray8);
    for (uint index7 = 0; index7 < 61U; ++index7)
    {
      for (uint index8 = 0; index8 < 6U; ++index8)
        this.fpsqr_mont(numArray8, numArray8);
      this.fpmul_mont(numArray7[26], numArray8, numArray8);
    }
    this.fpcopy(numArray8, 0L, a);
  }
}
