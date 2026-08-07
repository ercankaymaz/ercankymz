// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SidhCompressed
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal sealed class SidhCompressed
{
  private readonly SikeEngine engine;
  private static uint t_points = 2;

  internal SidhCompressed(SikeEngine engine) => this.engine = engine;

  internal void init_basis(ulong[] gen, ulong[][] XP, ulong[][] XQ, ulong[][] XR)
  {
    this.engine.fpx.fpcopy(gen, 0L, XP[0]);
    this.engine.fpx.fpcopy(gen, (long) this.engine.param.NWORDS_FIELD, XP[1]);
    this.engine.fpx.fpcopy(gen, (long) (2U * this.engine.param.NWORDS_FIELD), XQ[0]);
    this.engine.fpx.fpcopy(gen, (long) (3U * this.engine.param.NWORDS_FIELD), XQ[1]);
    this.engine.fpx.fpcopy(gen, (long) (4U * this.engine.param.NWORDS_FIELD), XR[0]);
    this.engine.fpx.fpcopy(gen, (long) (5U * this.engine.param.NWORDS_FIELD), XR[1]);
  }

  internal void FormatPrivKey_B(byte[] skB)
  {
    skB[(int) this.engine.param.SECRETKEY_B_BYTES - 2] &= (byte) this.engine.param.MASK3_BOB;
    skB[(int) this.engine.param.SECRETKEY_B_BYTES - 1] &= (byte) this.engine.param.MASK2_BOB;
    this.engine.fpx.mul3(skB);
  }

  internal void random_mod_order_A(byte[] random_digits, SecureRandom random)
  {
    byte[] numArray = new byte[(int) this.engine.param.SECRETKEY_A_BYTES];
    random.NextBytes(numArray);
    Array.Copy((Array) numArray, 0L, (Array) random_digits, 0L, (long) this.engine.param.SECRETKEY_A_BYTES);
    random_digits[0] &= (byte) 254;
    random_digits[(int) this.engine.param.SECRETKEY_A_BYTES - 1] &= (byte) this.engine.param.MASK_ALICE;
  }

  internal void random_mod_order_B(byte[] random_digits, SecureRandom random)
  {
    byte[] numArray = new byte[(int) this.engine.param.SECRETKEY_B_BYTES];
    random.NextBytes(numArray);
    Array.Copy((Array) numArray, 0L, (Array) random_digits, 0L, (long) this.engine.param.SECRETKEY_A_BYTES);
    this.FormatPrivKey_B(random_digits);
  }

  internal void Ladder3pt_dual(
    PointProj[] Rs,
    ulong[] m,
    uint AliceOrBob,
    PointProj R,
    ulong[][] A24)
  {
    PointProj P = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj Q = new PointProj(this.engine.param.NWORDS_FIELD);
    uint num1 = 0;
    uint num2 = (int) AliceOrBob != (int) this.engine.param.ALICE ? this.engine.param.OBOB_BITS : this.engine.param.OALICE_BITS;
    this.engine.fpx.fp2copy(Rs[1].X, P.X);
    this.engine.fpx.fp2copy(Rs[1].Z, P.Z);
    this.engine.fpx.fp2copy(Rs[2].X, Q.X);
    this.engine.fpx.fp2copy(Rs[2].Z, Q.Z);
    this.engine.fpx.fp2copy(Rs[0].X, R.X);
    this.engine.fpx.fp2copy(Rs[0].Z, R.Z);
    for (uint index = 0; index < num2; ++index)
    {
      int num3 = (int) (uint) (m[(int) (index >> (int) Internal.LOG2RADIX)] >> ((int) index & (int) Internal.RADIX - 1) & 1UL);
      uint num4 = (uint) num3 ^ num1;
      num1 = (uint) num3;
      ulong option = (ulong) -num4;
      this.engine.isogeny.SwapPoints(R, Q, option);
      this.engine.isogeny.XDblAdd(P, Q, R.X, A24);
      this.engine.fpx.fp2mul_mont(Q.X, R.Z, Q.X);
    }
    ulong option1 = (ulong) -(0U ^ num1);
    this.engine.isogeny.SwapPoints(R, Q, option1);
  }

  internal void Elligator2(
    ulong[][] a24,
    uint[] r,
    uint rIndex,
    ulong[][] x,
    byte[] bit,
    uint bitOffset,
    uint COMPorDEC)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray3 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray4 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray5 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray6 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[][] numArray7 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray8 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray1);
    this.engine.fpx.fp2add(a24, a24, numArray7);
    this.engine.fpx.fpsubPRIME(numArray7[0], numArray1, numArray7[0]);
    this.engine.fpx.fp2add(numArray7, numArray7, numArray7);
    uint index1 = r[(int) rIndex];
    this.engine.fpx.fp2mul_mont(numArray7, this.engine.param.v_3_torsion[(int) index1], x);
    this.engine.fpx.fp2neg(x);
    if (COMPorDEC == 0U)
    {
      this.engine.fpx.fp2add(numArray7, x, numArray8);
      this.engine.fpx.fp2mul_mont(numArray8, x, numArray8);
      this.engine.fpx.fpaddPRIME(numArray8[0], numArray1, numArray8[0]);
      this.engine.fpx.fp2mul_mont(x, numArray8, numArray8);
      this.engine.fpx.fpsqr_mont(numArray8[0], numArray2);
      this.engine.fpx.fpsqr_mont(numArray8[1], numArray3);
      this.engine.fpx.fpaddPRIME(numArray2, numArray3, numArray4);
      this.engine.fpx.fpcopy(numArray4, 0L, numArray5);
      for (uint index2 = 0; index2 < this.engine.param.OALICE_BITS - 2U; ++index2)
        this.engine.fpx.fpsqr_mont(numArray5, numArray5);
      for (uint index3 = 0; index3 < this.engine.param.OBOB_EXPON; ++index3)
      {
        this.engine.fpx.fpsqr_mont(numArray5, numArray6);
        this.engine.fpx.fpmul_mont(numArray5, numArray6, numArray5);
      }
      this.engine.fpx.fpsqr_mont(numArray5, numArray6);
      this.engine.fpx.fpcorrectionPRIME(numArray6);
      this.engine.fpx.fpcorrectionPRIME(numArray4);
      if (Fpx.subarrayEquals(numArray6, numArray4, this.engine.param.NWORDS_FIELD))
        return;
      this.engine.fpx.fp2neg(x);
      this.engine.fpx.fp2sub(x, numArray7, x);
      if (COMPorDEC != 0U)
        return;
      bit[(int) bitOffset] = (byte) 1;
    }
    else
    {
      if (bit[(int) bitOffset] != (byte) 1)
        return;
      this.engine.fpx.fp2neg(x);
      this.engine.fpx.fp2sub(x, numArray7, x);
    }
  }

  internal void make_positive(ulong[][] x)
  {
    uint nwordsField = this.engine.param.NWORDS_FIELD;
    ulong[] b = new ulong[(int) this.engine.param.NWORDS_FIELD];
    this.engine.fpx.from_fp2mont(x, x);
    if (!Fpx.subarrayEquals(x[0], b, nwordsField))
    {
      if (((long) x[0][0] & 1L) == 1L)
        this.engine.fpx.fp2neg(x);
    }
    else if (((long) x[1][0] & 1L) == 1L)
      this.engine.fpx.fp2neg(x);
    this.engine.fpx.to_fp2mont(x, x);
  }

  internal void BiQuad_affine(ulong[][] a24, ulong[][] x0, ulong[][] x1, PointProj R)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2add(a24, a24, numArray1);
    this.engine.fpx.fp2add(numArray1, numArray1, numArray1);
    this.engine.fpx.fp2sub(x0, x1, numArray2);
    this.engine.fpx.fp2sqr_mont(numArray2, numArray2);
    this.engine.fpx.fp2mul_mont(x0, x1, numArray4);
    this.engine.fpx.fpsubPRIME(numArray4[0], this.engine.param.Montgomery_one, numArray4[0]);
    this.engine.fpx.fp2sqr_mont(numArray4, numArray4);
    this.engine.fpx.fpsubPRIME(x0[0], this.engine.param.Montgomery_one, numArray3[0]);
    this.engine.fpx.fpcopy(x0[1], 0L, numArray3[1]);
    this.engine.fpx.fp2sqr_mont(numArray3, numArray3);
    this.engine.fpx.fp2mul_mont(numArray1, x0, numArray5);
    this.engine.fpx.fp2add(numArray3, numArray5, numArray3);
    this.engine.fpx.fp2mul_mont(x1, numArray3, numArray3);
    this.engine.fpx.fpsubPRIME(x1[0], this.engine.param.Montgomery_one, numArray5[0]);
    this.engine.fpx.fpcopy(x1[1], 0L, numArray5[1]);
    this.engine.fpx.fp2sqr_mont(numArray5, numArray5);
    this.engine.fpx.fp2mul_mont(numArray1, x1, numArray6);
    this.engine.fpx.fp2add(numArray5, numArray6, numArray5);
    this.engine.fpx.fp2mul_mont(x0, numArray5, numArray5);
    this.engine.fpx.fp2add(numArray3, numArray5, numArray3);
    this.engine.fpx.fp2add(numArray3, numArray3, numArray3);
    this.engine.fpx.fp2sqr_mont(numArray3, numArray5);
    this.engine.fpx.fp2mul_mont(numArray2, numArray4, numArray6);
    this.engine.fpx.fp2add(numArray6, numArray6, numArray6);
    this.engine.fpx.fp2add(numArray6, numArray6, numArray6);
    this.engine.fpx.fp2sub(numArray5, numArray6, numArray5);
    this.engine.fpx.sqrt_Fp2(numArray5, numArray5);
    this.make_positive(numArray5);
    this.engine.fpx.fp2add(numArray3, numArray5, R.X);
    this.engine.fpx.fp2add(numArray2, numArray2, R.Z);
  }

  internal void get_4_isog_dual(PointProj P, ulong[][] A24, ulong[][] C24, ulong[][][] coeff)
  {
    this.engine.fpx.fp2sub(P.X, P.Z, coeff[1]);
    this.engine.fpx.fp2add(P.X, P.Z, coeff[2]);
    this.engine.fpx.fp2sqr_mont(P.Z, coeff[4]);
    this.engine.fpx.fp2add(coeff[4], coeff[4], coeff[0]);
    this.engine.fpx.fp2sqr_mont(coeff[0], C24);
    this.engine.fpx.fp2add(coeff[0], coeff[0], coeff[0]);
    this.engine.fpx.fp2sqr_mont(P.X, coeff[3]);
    this.engine.fpx.fp2add(coeff[3], coeff[3], A24);
    this.engine.fpx.fp2sqr_mont(A24, A24);
  }

  internal void eval_dual_2_isog(ulong[][] X2, ulong[][] Z2, PointProj P)
  {
    ulong[][] numArray = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2add(P.X, P.Z, numArray);
    this.engine.fpx.fp2sub(P.X, P.Z, P.Z);
    this.engine.fpx.fp2sqr_mont(numArray, numArray);
    this.engine.fpx.fp2sqr_mont(P.Z, P.Z);
    this.engine.fpx.fp2sub(numArray, P.Z, P.Z);
    this.engine.fpx.fp2mul_mont(X2, P.Z, P.Z);
    this.engine.fpx.fp2mul_mont(Z2, numArray, P.X);
  }

  internal void eval_final_dual_2_isog(PointProj P)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[] numArray3 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    this.engine.fpx.fp2add(P.X, P.Z, numArray1);
    this.engine.fpx.fp2mul_mont(P.X, P.Z, numArray2);
    this.engine.fpx.fp2sqr_mont(numArray1, P.X);
    this.engine.fpx.fpcopy(P.X[0], 0L, numArray3);
    this.engine.fpx.fpcopy(P.X[1], 0L, P.X[0]);
    this.engine.fpx.fpcopy(numArray3, 0L, P.X[1]);
    this.engine.fpx.fpnegPRIME(P.X[1]);
    this.engine.fpx.fp2add(numArray2, numArray2, P.Z);
    this.engine.fpx.fp2add(P.Z, P.Z, P.Z);
  }

  internal void eval_dual_4_isog_shared(
    ulong[][] X4pZ4,
    ulong[][] X42,
    ulong[][] Z42,
    ulong[][][] coeff,
    uint coeffOffset)
  {
    this.engine.fpx.fp2sub(X42, Z42, coeff[(int) coeffOffset]);
    this.engine.fpx.fp2add(X42, Z42, coeff[1 + (int) coeffOffset]);
    this.engine.fpx.fp2sqr_mont(X4pZ4, coeff[2 + (int) coeffOffset]);
    this.engine.fpx.fp2sub(coeff[2 + (int) coeffOffset], coeff[1 + (int) coeffOffset], coeff[2 + (int) coeffOffset]);
  }

  internal void eval_dual_4_isog(
    ulong[][] A24,
    ulong[][] C24,
    ulong[][][] coeff,
    uint coeffOffset,
    PointProj P)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2add(P.X, P.Z, numArray1);
    this.engine.fpx.fp2sub(P.X, P.Z, numArray2);
    this.engine.fpx.fp2sqr_mont(numArray1, numArray1);
    this.engine.fpx.fp2sqr_mont(numArray2, numArray2);
    this.engine.fpx.fp2sub(numArray1, numArray2, numArray3);
    this.engine.fpx.fp2sub(C24, A24, numArray4);
    this.engine.fpx.fp2mul_mont(numArray3, numArray4, numArray4);
    this.engine.fpx.fp2mul_mont(C24, numArray1, numArray3);
    this.engine.fpx.fp2sub(numArray3, numArray4, numArray3);
    this.engine.fpx.fp2mul_mont(numArray3, numArray1, P.X);
    this.engine.fpx.fp2mul_mont(numArray4, numArray2, P.Z);
    this.engine.fpx.fp2mul_mont(coeff[(int) coeffOffset], P.X, P.X);
    this.engine.fpx.fp2mul_mont(coeff[1 + (int) coeffOffset], P.Z, numArray1);
    this.engine.fpx.fp2add(P.X, numArray1, P.X);
    this.engine.fpx.fp2mul_mont(coeff[2 + (int) coeffOffset], P.Z, P.Z);
  }

  internal void eval_full_dual_4_isog(ulong[][][][] As, PointProj P)
  {
    for (uint index = 0; index < this.engine.param.MAX_Alice; ++index)
      this.eval_dual_4_isog(As[(int) this.engine.param.MAX_Alice - (int) index][0], As[(int) this.engine.param.MAX_Alice - (int) index][1], As[(int) this.engine.param.MAX_Alice - (int) index - 1], 2U, P);
    if (this.engine.param.OALICE_BITS % 2U == 1U)
      this.eval_dual_2_isog(As[(int) this.engine.param.MAX_Alice][2], As[(int) this.engine.param.MAX_Alice][3], P);
    this.eval_final_dual_2_isog(P);
  }

  internal void TripleAndParabola_proj(PointProjFull R, ulong[][] l1x, ulong[][] l1z)
  {
    this.engine.fpx.fp2sqr_mont(R.X, l1z);
    this.engine.fpx.fp2add(l1z, l1z, l1x);
    this.engine.fpx.fp2add(l1x, l1z, l1x);
    this.engine.fpx.fpaddPRIME(l1x[0], this.engine.param.Montgomery_one, l1x[0]);
    this.engine.fpx.fp2add(R.Y, R.Y, l1z);
  }

  internal void Tate3_proj(PointProjFull P, PointProjFull Q, ulong[][] gX, ulong[][] gZ)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.TripleAndParabola_proj(P, numArray2, gZ);
    this.engine.fpx.fp2sub(Q.X, P.X, gX);
    this.engine.fpx.fp2mul_mont(numArray2, gX, gX);
    this.engine.fpx.fp2sub(P.Y, Q.Y, numArray1);
    this.engine.fpx.fp2mul_mont(gZ, numArray1, numArray1);
    this.engine.fpx.fp2add(gX, numArray1, gX);
  }

  internal void FinalExpo3(ulong[][] gX, ulong[][] gZ)
  {
    ulong[][] numArray = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2copy(gZ, numArray);
    this.engine.fpx.fpnegPRIME(numArray[1]);
    this.engine.fpx.fp2mul_mont(gX, numArray, numArray);
    this.engine.fpx.fp2inv_mont_bingcd(numArray);
    this.engine.fpx.fpnegPRIME(gX[1]);
    this.engine.fpx.fp2mul_mont(gX, gZ, gX);
    this.engine.fpx.fp2mul_mont(gX, numArray, gX);
    for (uint index = 0; index < this.engine.param.OALICE_BITS; ++index)
      this.engine.fpx.fp2sqr_mont(gX, gX);
    for (uint index = 0; index < this.engine.param.OBOB_EXPON - 1U; ++index)
      this.engine.fpx.cube_Fp2_cycl(gX, this.engine.param.Montgomery_one);
  }

  internal void FinalExpo3_2way(ulong[][][] gX, ulong[][][] gZ)
  {
    ulong[][][] vec = SikeUtilities.InitArray(2U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] output = SikeUtilities.InitArray(2U, 2U, this.engine.param.NWORDS_FIELD);
    for (uint index = 0; index < 2U; ++index)
    {
      this.engine.fpx.fp2copy(gZ[(int) index], vec[(int) index]);
      this.engine.fpx.fpnegPRIME(vec[(int) index][1]);
      this.engine.fpx.fp2mul_mont(gX[(int) index], vec[(int) index], vec[(int) index]);
    }
    this.engine.fpx.mont_n_way_inv(vec, 2U, output);
    for (uint index1 = 0; index1 < 2U; ++index1)
    {
      this.engine.fpx.fpnegPRIME(gX[(int) index1][1]);
      this.engine.fpx.fp2mul_mont(gX[(int) index1], gZ[(int) index1], gX[(int) index1]);
      this.engine.fpx.fp2mul_mont(gX[(int) index1], output[(int) index1], gX[(int) index1]);
      for (uint index2 = 0; index2 < this.engine.param.OALICE_BITS; ++index2)
        this.engine.fpx.fp2sqr_mont(gX[(int) index1], gX[(int) index1]);
      for (uint index3 = 0; index3 < this.engine.param.OBOB_EXPON - 1U; ++index3)
        this.engine.fpx.cube_Fp2_cycl(gX[(int) index1], this.engine.param.Montgomery_one);
    }
  }

  private bool FirstPoint_dual(PointProj P, PointProjFull R, byte[] ind)
  {
    PointProjFull P1 = new PointProjFull(this.engine.param.NWORDS_FIELD);
    PointProjFull P2 = new PointProjFull(this.engine.param.NWORDS_FIELD);
    ulong[][][] gX = SikeUtilities.InitArray(2U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] gZ = SikeUtilities.InitArray(2U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[] b = new ulong[(int) this.engine.param.NWORDS_FIELD];
    uint nwordsField = this.engine.param.NWORDS_FIELD;
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, 0L, P1.X[0]);
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) this.engine.param.NWORDS_FIELD, P1.X[1]);
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) (2U * this.engine.param.NWORDS_FIELD), P1.Y[0]);
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) (3U * this.engine.param.NWORDS_FIELD), P1.Y[1]);
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) (4U * this.engine.param.NWORDS_FIELD), P2.X[0]);
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) (5U * this.engine.param.NWORDS_FIELD), P2.X[1]);
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) (6U * this.engine.param.NWORDS_FIELD), P2.Y[0]);
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) (7U * this.engine.param.NWORDS_FIELD), P2.Y[1]);
    this.engine.isogeny.CompletePoint(P, R);
    this.Tate3_proj(P1, R, gX[0], gZ[0]);
    this.Tate3_proj(P2, R, gX[1], gZ[1]);
    this.FinalExpo3_2way(gX, gZ);
    this.engine.fpx.fp2correction(gX[0]);
    this.engine.fpx.fp2correction(gX[1]);
    uint num1 = !Fpx.subarrayEquals(gX[0][1], b, nwordsField) ? (!Fpx.subarrayEquals(gX[0][1], this.engine.param.g_R_S_im, nwordsField) ? 2U : 1U) : 0U;
    uint num2 = !Fpx.subarrayEquals(gX[1][1], b, nwordsField) ? (!Fpx.subarrayEquals(gX[1][1], this.engine.param.g_R_S_im, nwordsField) ? 2U : 1U) : 0U;
    if (num1 == 0U && num2 == 0U)
      return false;
    ind[0] = num1 != 0U ? (num2 != 0U ? ((int) num1 + (int) num2 != 3 ? (byte) 2 : (byte) 3) : (byte) 1) : (byte) 0;
    return true;
  }

  private bool SecondPoint_dual(PointProj P, PointProjFull R, byte[] ind)
  {
    PointProjFull P1 = new PointProjFull(this.engine.param.NWORDS_FIELD);
    ulong[][] numArray = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] gZ = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[] b = new ulong[(int) this.engine.param.NWORDS_FIELD];
    uint nwordsField = this.engine.param.NWORDS_FIELD;
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) (4 * (int) ind[0]) * (long) this.engine.param.NWORDS_FIELD, P1.X[0]);
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) (4 * (int) ind[0] + 1) * (long) this.engine.param.NWORDS_FIELD, P1.X[1]);
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) (4 * (int) ind[0] + 2) * (long) this.engine.param.NWORDS_FIELD, P1.Y[0]);
    this.engine.fpx.fpcopy(this.engine.param.B_gen_3_tors, (long) (4 * (int) ind[0] + 3) * (long) this.engine.param.NWORDS_FIELD, P1.Y[1]);
    this.engine.isogeny.CompletePoint(P, R);
    this.Tate3_proj(P1, R, numArray, gZ);
    this.FinalExpo3(numArray, gZ);
    this.engine.fpx.fp2correction(numArray);
    return !Fpx.subarrayEquals(numArray[1], b, nwordsField);
  }

  internal void FirstPoint3n(
    ulong[][] a24,
    ulong[][][][] As,
    ulong[][] x,
    PointProjFull R,
    uint[] r,
    byte[] ind,
    byte[] bitEll)
  {
    bool flag = false;
    PointProj P = new PointProj(this.engine.param.NWORDS_FIELD);
    ulong[] a = new ulong[(int) this.engine.param.NWORDS_FIELD];
    r[0] = 0U;
    while (!flag)
    {
      bitEll[0] = (byte) 0;
      this.Elligator2(a24, r, 0U, x, bitEll, 0U, 0U);
      this.engine.fpx.fp2copy(x, P.X);
      this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, P.Z[0]);
      this.engine.fpx.fpcopy(a, 0L, P.Z[1]);
      this.eval_full_dual_4_isog(As, P);
      flag = this.FirstPoint_dual(P, R, ind);
      r[0] = r[0] + 1U;
    }
  }

  internal void SecondPoint3n(
    ulong[][] a24,
    ulong[][][][] As,
    ulong[][] x,
    PointProjFull R,
    uint[] r,
    byte[] ind,
    byte[] bitEll)
  {
    bool flag = false;
    PointProj P = new PointProj(this.engine.param.NWORDS_FIELD);
    ulong[] a = new ulong[(int) this.engine.param.NWORDS_FIELD];
    while (!flag)
    {
      bitEll[0] = (byte) 0;
      this.Elligator2(a24, r, 1U, x, bitEll, 0U, 0U);
      this.engine.fpx.fp2copy(x, P.X);
      this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, P.Z[0]);
      this.engine.fpx.fpcopy(a, 0L, P.Z[1]);
      this.eval_full_dual_4_isog(As, P);
      flag = this.SecondPoint_dual(P, R, ind);
      r[1] = r[1] + 1U;
    }
  }

  internal void makeDiff(PointProjFull R, PointProjFull S, PointProj D)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    uint nwordsField = this.engine.param.NWORDS_FIELD;
    this.engine.fpx.fp2sub(R.X, S.X, numArray1);
    this.engine.fpx.fp2sub(R.Y, S.Y, numArray2);
    this.engine.fpx.fp2sqr_mont(numArray1, numArray1);
    this.engine.fpx.fp2sqr_mont(numArray2, numArray2);
    this.engine.fpx.fp2add(R.X, S.X, numArray3);
    this.engine.fpx.fp2mul_mont(numArray1, numArray3, numArray3);
    this.engine.fpx.fp2sub(numArray2, numArray3, numArray2);
    this.engine.fpx.fp2mul_mont(D.Z, numArray2, numArray2);
    this.engine.fpx.fp2mul_mont(D.X, numArray1, numArray1);
    this.engine.fpx.fp2correction(numArray1);
    this.engine.fpx.fp2correction(numArray2);
    if (!(Fpx.subarrayEquals(numArray1[0], numArray2[0], nwordsField) & Fpx.subarrayEquals(numArray1[1], numArray2[1], nwordsField)))
      return;
    this.engine.fpx.fp2neg(S.Y);
  }

  internal void BuildOrdinary3nBasis_dual(
    ulong[][] a24,
    ulong[][][][] As,
    PointProjFull[] R,
    uint[] r,
    uint[] bitsEll,
    uint bitsEllOffset)
  {
    PointProj pointProj = new PointProj(this.engine.param.NWORDS_FIELD);
    ulong[][][] numArray = SikeUtilities.InitArray(2U, 2U, this.engine.param.NWORDS_FIELD);
    byte[] ind = new byte[1];
    byte[] bitEll = new byte[1];
    this.FirstPoint3n(a24, As, numArray[0], R[0], r, ind, bitEll);
    bitsEll[(int) bitsEllOffset] = (uint) bitEll[0];
    r[1] = r[0];
    this.SecondPoint3n(a24, As, numArray[1], R[1], r, ind, bitEll);
    bitsEll[(int) bitsEllOffset] |= (uint) bitEll[0] << 1;
    this.BiQuad_affine(a24, numArray[0], numArray[1], pointProj);
    this.eval_full_dual_4_isog(As, pointProj);
    this.makeDiff(R[0], R[1], pointProj);
  }

  internal void FullIsogeny_A_dual(byte[] PrivateKeyA, ulong[][][][] As, ulong[][] a24, uint sike)
  {
    PointProj pointProj1 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj[] pointProjArray = new PointProj[(int) this.engine.param.MAX_INT_POINTS_ALICE];
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] coeff = SikeUtilities.InitArray(5U, 2U, this.engine.param.NWORDS_FIELD);
    uint index1 = 0;
    uint num1 = 0;
    uint[] numArray7 = new uint[(int) this.engine.param.MAX_INT_POINTS_ALICE];
    ulong[] numArray8 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    this.init_basis(this.engine.param.A_gen, numArray1, numArray2, numArray3);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray4[0]);
    this.engine.fpx.fp2add(numArray4, numArray4, numArray4);
    this.engine.fpx.fp2add(numArray4, numArray4, numArray5);
    this.engine.fpx.fp2add(numArray4, numArray5, numArray6);
    this.engine.fpx.fp2add(numArray5, numArray5, numArray4);
    this.engine.fpx.decode_to_digits(PrivateKeyA, this.engine.param.MSG_BYTES, numArray8, this.engine.param.SECRETKEY_A_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.isogeny.LADDER3PT(numArray1, numArray2, numArray3, numArray8, this.engine.param.ALICE, pointProj1, numArray6);
    this.engine.fpx.fp2inv_mont(pointProj1.Z);
    this.engine.fpx.fp2mul_mont(pointProj1.X, pointProj1.Z, pointProj1.X);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, pointProj1.Z[0]);
    this.engine.fpx.fpzero(pointProj1.Z[1]);
    if (sike == 1U)
      this.engine.fpx.fp2_encode(pointProj1.X, PrivateKeyA, this.engine.param.MSG_BYTES + this.engine.param.SECRETKEY_A_BYTES + this.engine.param.CRYPTO_PUBLICKEYBYTES);
    if (this.engine.param.OALICE_BITS % 2U == 1U)
    {
      PointProj pointProj2 = new PointProj(this.engine.param.NWORDS_FIELD);
      this.engine.isogeny.XDblE(pointProj1, pointProj2, numArray4, numArray5, this.engine.param.OALICE_BITS - 1U);
      this.engine.isogeny.Get2Isog(pointProj2, numArray4, numArray5);
      this.engine.isogeny.Eval2Isog(pointProj1, pointProj2);
      this.engine.fpx.fp2copy(pointProj2.X, As[(int) this.engine.param.MAX_Alice][2]);
      this.engine.fpx.fp2copy(pointProj2.Z, As[(int) this.engine.param.MAX_Alice][3]);
    }
    uint num2 = 0;
    for (uint index2 = 1; index2 < this.engine.param.MAX_Alice; ++index2)
    {
      uint num3;
      for (; num2 < this.engine.param.MAX_Alice - index2; num2 += num3)
      {
        pointProjArray[(int) index1] = new PointProj(this.engine.param.NWORDS_FIELD);
        this.engine.fpx.fp2copy(pointProj1.X, pointProjArray[(int) index1].X);
        this.engine.fpx.fp2copy(pointProj1.Z, pointProjArray[(int) index1].Z);
        numArray7[(int) index1++] = num2;
        num3 = this.engine.param.strat_Alice[(int) num1++];
        this.engine.isogeny.XDblE(pointProj1, pointProj1, numArray4, numArray5, 2U * num3);
      }
      this.engine.fpx.fp2copy(numArray4, As[(int) index2 - 1][0]);
      this.engine.fpx.fp2copy(numArray5, As[(int) index2 - 1][1]);
      this.get_4_isog_dual(pointProj1, numArray4, numArray5, coeff);
      for (uint index3 = 0; index3 < index1; ++index3)
        this.engine.isogeny.Eval4Isog(pointProjArray[(int) index3], coeff);
      this.eval_dual_4_isog_shared(coeff[2], coeff[3], coeff[4], As[(int) index2 - 1], 2U);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].X, pointProj1.X);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].Z, pointProj1.Z);
      num2 = numArray7[(int) index1 - 1];
      --index1;
    }
    this.engine.fpx.fp2copy(numArray4, As[(int) this.engine.param.MAX_Alice - 1][0]);
    this.engine.fpx.fp2copy(numArray5, As[(int) this.engine.param.MAX_Alice - 1][1]);
    this.get_4_isog_dual(pointProj1, numArray4, numArray5, coeff);
    this.eval_dual_4_isog_shared(coeff[2], coeff[3], coeff[4], As[(int) this.engine.param.MAX_Alice - 1], 2U);
    this.engine.fpx.fp2copy(numArray4, As[(int) this.engine.param.MAX_Alice][0]);
    this.engine.fpx.fp2copy(numArray5, As[(int) this.engine.param.MAX_Alice][1]);
    this.engine.fpx.fp2inv_mont_bingcd(numArray5);
    this.engine.fpx.fp2mul_mont(numArray4, numArray5, a24);
  }

  internal void Dlogs3_dual(
    ulong[][][] f,
    int[] D,
    ulong[] d0,
    ulong[] c0,
    ulong[] d1,
    ulong[] c1)
  {
    this.solve_dlog(f[0], D, d0, 3U);
    this.solve_dlog(f[2], D, c0, 3U);
    this.solve_dlog(f[1], D, d1, 3U);
    this.solve_dlog(f[3], D, c1, 3U);
    long num1 = (long) this.engine.fpx.mp_sub(this.engine.param.Bob_order, c0, c0, this.engine.param.NWORDS_ORDER);
    long num2 = (long) this.engine.fpx.mp_sub(this.engine.param.Bob_order, c1, c1, this.engine.param.NWORDS_ORDER);
  }

  internal void BuildOrdinary3nBasis_Decomp_dual(
    ulong[][] A24,
    PointProj[] Rs,
    uint[] r,
    uint[] bitsEll,
    uint bitsEllIndex)
  {
    byte[] bit = new byte[2]
    {
      (byte) (bitsEll[(int) bitsEllIndex] & 1U),
      (byte) (bitsEll[(int) bitsEllIndex] >> 1 & 1U)
    };
    --r[0];
    this.Elligator2(A24, r, 0U, Rs[0].X, bit, 0U, 1U);
    --r[1];
    this.Elligator2(A24, r, 1U, Rs[1].X, bit, 1U, 1U);
    this.BiQuad_affine(A24, Rs[0].X, Rs[1].X, Rs[2]);
  }

  internal void PKADecompression_dual(
    byte[] SecretKeyB,
    byte[] CompressedPKA,
    PointProj R,
    ulong[][] A)
  {
    uint[] numArray1 = new uint[3];
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    PointProj[] Rs = new PointProj[3]
    {
      new PointProj(this.engine.param.NWORDS_FIELD),
      new PointProj(this.engine.param.NWORDS_FIELD),
      new PointProj(this.engine.param.NWORDS_FIELD)
    };
    ulong[] numArray3 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray4 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray5 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray6 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray7 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray8 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray9 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    this.engine.fpx.fp2_decode(CompressedPKA, A, 3U * this.engine.param.ORDER_B_ENCODED_BYTES);
    numArray7[0] = 1UL;
    this.engine.fpx.to_Montgomery_mod_order(numArray7, numArray7, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
    byte num1 = (byte) (((int) CompressedPKA[3 * (int) this.engine.param.ORDER_B_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] & (int) byte.MaxValue) >> 7);
    byte[] destinationArray = new byte[3];
    Array.Copy((Array) CompressedPKA, (long) (3U * this.engine.param.ORDER_B_ENCODED_BYTES + this.engine.param.FP2_ENCODED_BYTES), (Array) destinationArray, 0L, 3L);
    numArray1[0] = (uint) destinationArray[0] & (uint) ushort.MaxValue;
    numArray1[1] = (uint) destinationArray[1] & (uint) ushort.MaxValue;
    numArray1[2] = (uint) destinationArray[2] & (uint) ushort.MaxValue;
    numArray1[0] &= (uint) sbyte.MaxValue;
    this.engine.fpx.fpaddPRIME(A[0], this.engine.param.Montgomery_one, numArray2[0]);
    this.engine.fpx.fpcopy(A[1], 0L, numArray2[1]);
    this.engine.fpx.fpaddPRIME(numArray2[0], this.engine.param.Montgomery_one, numArray2[0]);
    this.engine.fpx.fp2div2(numArray2, numArray2);
    this.engine.fpx.fp2div2(numArray2, numArray2);
    this.BuildOrdinary3nBasis_Decomp_dual(numArray2, Rs, numArray1, numArray1, 2U);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, Rs[0].Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, Rs[1].Z[0]);
    this.engine.isogeny.SwapPoints(Rs[0], Rs[1], (ulong) -num1);
    this.engine.fpx.decode_to_digits(SecretKeyB, 0U, numArray9, this.engine.param.SECRETKEY_B_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.fpx.to_Montgomery_mod_order(numArray9, numArray3, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
    this.engine.fpx.decode_to_digits(CompressedPKA, 0U, numArray8, this.engine.param.ORDER_B_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.fpx.to_Montgomery_mod_order(numArray8, numArray4, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
    this.engine.fpx.decode_to_digits(CompressedPKA, this.engine.param.ORDER_B_ENCODED_BYTES, numArray8, this.engine.param.ORDER_B_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.fpx.to_Montgomery_mod_order(numArray8, numArray5, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
    this.engine.fpx.decode_to_digits(CompressedPKA, 2U * this.engine.param.ORDER_B_ENCODED_BYTES, numArray8, this.engine.param.ORDER_B_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.fpx.to_Montgomery_mod_order(numArray8, numArray6, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
    if (num1 == (byte) 0)
    {
      this.engine.fpx.Montgomery_multiply_mod_order(numArray3, numArray5, numArray5, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      long num2 = (long) this.engine.fpx.mp_add(numArray5, numArray7, numArray5, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.Montgomery_inversion_mod_order_bingcd(numArray5, numArray5, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
      this.engine.fpx.Montgomery_multiply_mod_order(numArray3, numArray6, numArray6, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      long num3 = (long) this.engine.fpx.mp_add(numArray4, numArray6, numArray6, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.Montgomery_multiply_mod_order(numArray5, numArray6, numArray5, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.from_Montgomery_mod_order(numArray5, numArray5, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.Ladder3pt_dual(Rs, numArray5, this.engine.param.BOB, R, numArray2);
    }
    else
    {
      this.engine.fpx.Montgomery_multiply_mod_order(numArray3, numArray6, numArray6, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      long num4 = (long) this.engine.fpx.mp_add(numArray6, numArray7, numArray6, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.Montgomery_inversion_mod_order_bingcd(numArray6, numArray6, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
      this.engine.fpx.Montgomery_multiply_mod_order(numArray3, numArray5, numArray5, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      long num5 = (long) this.engine.fpx.mp_add(numArray4, numArray5, numArray5, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.Montgomery_multiply_mod_order(numArray5, numArray6, numArray5, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.from_Montgomery_mod_order(numArray5, numArray5, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.Ladder3pt_dual(Rs, numArray5, this.engine.param.BOB, R, numArray2);
    }
    this.engine.isogeny.Double(R, R, numArray2, this.engine.param.OALICE_BITS);
  }

  internal void Compress_PKA_dual(
    ulong[] d0,
    ulong[] c0,
    ulong[] d1,
    ulong[] c1,
    ulong[][] a24,
    uint[] rs,
    byte[] CompressedPKA)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2add(a24, a24, numArray3);
    this.engine.fpx.fp2add(numArray3, numArray3, numArray3);
    this.engine.fpx.fpsubPRIME(numArray3[0], this.engine.param.Montgomery_one, numArray3[0]);
    this.engine.fpx.fpsubPRIME(numArray3[0], this.engine.param.Montgomery_one, numArray3[0]);
    int num = (int) this.engine.fpx.mod3(d1);
    this.engine.fpx.to_Montgomery_mod_order(c0, c0, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
    this.engine.fpx.to_Montgomery_mod_order(c1, c1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
    this.engine.fpx.to_Montgomery_mod_order(d0, d0, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
    this.engine.fpx.to_Montgomery_mod_order(d1, d1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
    if (num != 0)
    {
      this.engine.fpx.Montgomery_inversion_mod_order_bingcd(d1, numArray2, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
      this.engine.fpx.Montgomery_neg(d0, this.engine.param.Bob_order);
      this.engine.fpx.Montgomery_multiply_mod_order(d0, numArray2, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.from_Montgomery_mod_order(numArray1, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKA, 0U, this.engine.param.ORDER_B_ENCODED_BYTES);
      this.engine.fpx.Montgomery_neg(c1, this.engine.param.Bob_order);
      this.engine.fpx.Montgomery_multiply_mod_order(c1, numArray2, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.from_Montgomery_mod_order(numArray1, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKA, this.engine.param.ORDER_B_ENCODED_BYTES, this.engine.param.ORDER_B_ENCODED_BYTES);
      this.engine.fpx.Montgomery_multiply_mod_order(c0, numArray2, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.from_Montgomery_mod_order(numArray1, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKA, 2U * this.engine.param.ORDER_B_ENCODED_BYTES, this.engine.param.ORDER_B_ENCODED_BYTES);
      CompressedPKA[3 * (int) this.engine.param.ORDER_B_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] = (byte) 0;
    }
    else
    {
      this.engine.fpx.Montgomery_inversion_mod_order_bingcd(d0, numArray2, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2, this.engine.param.Montgomery_RB1);
      this.engine.fpx.Montgomery_neg(d1, this.engine.param.Bob_order);
      this.engine.fpx.Montgomery_multiply_mod_order(d1, numArray2, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.from_Montgomery_mod_order(numArray1, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKA, 0U, this.engine.param.ORDER_B_ENCODED_BYTES);
      this.engine.fpx.Montgomery_multiply_mod_order(c1, numArray2, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.from_Montgomery_mod_order(numArray1, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKA, this.engine.param.ORDER_B_ENCODED_BYTES, this.engine.param.ORDER_B_ENCODED_BYTES);
      this.engine.fpx.Montgomery_neg(c0, this.engine.param.Bob_order);
      this.engine.fpx.Montgomery_multiply_mod_order(c0, numArray2, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.from_Montgomery_mod_order(numArray1, numArray1, this.engine.param.Bob_order, this.engine.param.Montgomery_RB2);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKA, 2U * this.engine.param.ORDER_B_ENCODED_BYTES, this.engine.param.ORDER_B_ENCODED_BYTES);
      CompressedPKA[3 * (int) this.engine.param.ORDER_B_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] = (byte) 128 /*0x80*/;
    }
    this.engine.fpx.fp2_encode(numArray3, CompressedPKA, 3U * this.engine.param.ORDER_B_ENCODED_BYTES);
    CompressedPKA[3 * (int) this.engine.param.ORDER_B_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] |= (byte) rs[0];
    CompressedPKA[3 * (int) this.engine.param.ORDER_B_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES + 1] = (byte) rs[1];
    CompressedPKA[3 * (int) this.engine.param.ORDER_B_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES + 2] = (byte) rs[2];
  }

  internal uint EphemeralKeyGeneration_A_extended(byte[] PrivateKeyA, byte[] CompressedPKA)
  {
    uint[] numArray = new uint[3];
    int[] D = new int[(int) this.engine.param.DLEN_3];
    ulong[][] a24 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][][][] As = SikeUtilities.InitArray(this.engine.param.MAX_Alice + 1U, 5U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] f = SikeUtilities.InitArray(4U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[] c0 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] d0 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] c1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] d1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    PointProjFull[] pointProjFullArray = new PointProjFull[2]
    {
      new PointProjFull(this.engine.param.NWORDS_FIELD),
      new PointProjFull(this.engine.param.NWORDS_FIELD)
    };
    this.FullIsogeny_A_dual(PrivateKeyA, As, a24, 1U);
    this.BuildOrdinary3nBasis_dual(a24, As, pointProjFullArray, numArray, numArray, 2U);
    this.Tate3_pairings(pointProjFullArray, f);
    this.Dlogs3_dual(f, D, d0, c0, d1, c1);
    this.Compress_PKA_dual(d0, c0, d1, c1, a24, numArray, CompressedPKA);
    return 0;
  }

  private uint EphemeralKeyGeneration_A(byte[] PrivateKeyA, byte[] CompressedPKA)
  {
    uint[] numArray = new uint[3];
    int[] D = new int[(int) this.engine.param.DLEN_3];
    ulong[] c0 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] d0 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] c1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] d1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[][] a24 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] f = SikeUtilities.InitArray(4U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][][][] As = SikeUtilities.InitArray(this.engine.param.MAX_Alice + 1U, 5U, 2U, this.engine.param.NWORDS_FIELD);
    PointProjFull[] pointProjFullArray = new PointProjFull[2];
    this.FullIsogeny_A_dual(PrivateKeyA, As, a24, 0U);
    this.BuildOrdinary3nBasis_dual(a24, As, pointProjFullArray, numArray, numArray, 2U);
    this.Tate3_pairings(pointProjFullArray, f);
    this.Dlogs3_dual(f, D, d0, c0, d1, c1);
    this.Compress_PKA_dual(d0, c0, d1, c1, a24, numArray, CompressedPKA);
    return 0;
  }

  internal uint EphemeralSecretAgreement_B(byte[] PrivateKeyB, byte[] PKA, byte[] SharedSecretB)
  {
    uint num1 = 0;
    uint index1 = 0;
    uint[] numArray1 = new uint[(int) this.engine.param.MAX_INT_POINTS_BOB];
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    PointProj pointProj = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj[] pointProjArray = new PointProj[(int) this.engine.param.MAX_INT_POINTS_BOB];
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] coeff = SikeUtilities.InitArray(3U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.PKADecompression_dual(PrivateKeyB, PKA, pointProj, numArray6);
    this.engine.fpx.fp2copy(numArray6, numArray5);
    this.engine.fpx.fpaddPRIME(this.engine.param.Montgomery_one, this.engine.param.Montgomery_one, numArray3[0]);
    this.engine.fpx.fp2add(numArray5, numArray3, numArray2);
    this.engine.fpx.fp2sub(numArray5, numArray3, numArray3);
    uint num2 = 0;
    for (uint index2 = 1; index2 < this.engine.param.MAX_Bob; ++index2)
    {
      uint e;
      for (; num2 < this.engine.param.MAX_Bob - index2; num2 += e)
      {
        pointProjArray[(int) index1] = new PointProj(this.engine.param.NWORDS_FIELD);
        this.engine.fpx.fp2copy(pointProj.X, pointProjArray[(int) index1].X);
        this.engine.fpx.fp2copy(pointProj.Z, pointProjArray[(int) index1].Z);
        numArray1[(int) index1++] = num2;
        e = this.engine.param.strat_Bob[(int) num1++];
        this.engine.isogeny.XTplE(pointProj, pointProj, numArray3, numArray2, e);
      }
      this.engine.isogeny.Get3Isog(pointProj, numArray3, numArray2, coeff);
      for (uint index3 = 0; index3 < index1; ++index3)
        this.engine.isogeny.Eval3Isog(pointProjArray[(int) index3], coeff);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].X, pointProj.X);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].Z, pointProj.Z);
      num2 = numArray1[(int) index1 - 1];
      --index1;
    }
    this.engine.isogeny.Get3Isog(pointProj, numArray3, numArray2, coeff);
    this.engine.fpx.fp2add(numArray2, numArray3, numArray5);
    this.engine.fpx.fp2add(numArray5, numArray5, numArray5);
    this.engine.fpx.fp2sub(numArray2, numArray3, numArray2);
    this.engine.isogeny.JInv(numArray5, numArray2, numArray4);
    this.engine.fpx.fp2_encode(numArray4, SharedSecretB, 0U);
    return 0;
  }

  internal void BuildEntangledXonly(ulong[][] A, PointProj[] R, byte[] qnr, byte[] ind)
  {
    ulong[] s = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    uint bOffset = 0;
    ulong[][] b;
    if (this.engine.fpx.is_sqr_fp2(A, s))
    {
      b = this.engine.param.table_v_qnr;
      qnr[0] = (byte) 1;
    }
    else
    {
      b = this.engine.param.table_v_qr;
      qnr[0] = (byte) 0;
    }
    ind[0] = (byte) 0;
    do
    {
      this.engine.fpx.fp2mul_mont(A, b, bOffset, R[0].X);
      bOffset += 2U;
      this.engine.fpx.fp2neg(R[0].X);
      this.engine.fpx.fp2add(R[0].X, A, numArray2);
      this.engine.fpx.fp2mul_mont(R[0].X, numArray2, numArray2);
      this.engine.fpx.fpaddPRIME(numArray2[0], this.engine.param.Montgomery_one, numArray2[0]);
      this.engine.fpx.fp2mul_mont(R[0].X, numArray2, numArray2);
      ++ind[0];
    }
    while (!this.engine.fpx.is_sqr_fp2(numArray2, s));
    --ind[0];
    if (qnr[0] == (byte) 1)
      this.engine.fpx.fpcopy(this.engine.param.table_r_qnr[(int) ind[0]], 0L, numArray1[0]);
    else
      this.engine.fpx.fpcopy(this.engine.param.table_r_qr[(int) ind[0]], 0L, numArray1[0]);
    this.engine.fpx.fp2add(R[0].X, A, R[1].X);
    this.engine.fpx.fp2neg(R[1].X);
    this.engine.fpx.fp2sub(R[0].X, R[1].X, R[2].Z);
    this.engine.fpx.fp2sqr_mont(R[2].Z, R[2].Z);
    this.engine.fpx.fpcopy(numArray1[0], 0L, numArray1[1]);
    this.engine.fpx.fpaddPRIME(this.engine.param.Montgomery_one, numArray1[0], numArray1[0]);
    this.engine.fpx.fp2sqr_mont(numArray1, numArray1);
    this.engine.fpx.fp2mul_mont(numArray2, numArray1, R[2].X);
  }

  internal void RecoverY(ulong[][] A, PointProj[] xs, PointProjFull[] Rs)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2mul_mont(xs[2].X, xs[1].Z, numArray1);
    this.engine.fpx.fp2mul_mont(xs[1].X, xs[2].Z, numArray2);
    this.engine.fpx.fp2mul_mont(xs[1].X, xs[2].X, numArray3);
    this.engine.fpx.fp2mul_mont(xs[1].Z, xs[2].Z, numArray4);
    this.engine.fpx.fp2sqr_mont(xs[1].X, numArray5);
    this.engine.fpx.fp2sqr_mont(xs[1].Z, Rs[1].X);
    this.engine.fpx.fp2sub(numArray3, numArray4, Rs[1].Y);
    this.engine.fpx.fp2mul_mont(xs[1].X, Rs[1].Y, Rs[1].Y);
    this.engine.fpx.fp2add(numArray5, Rs[1].X, numArray5);
    this.engine.fpx.fp2mul_mont(xs[2].Z, numArray5, numArray5);
    this.engine.fpx.fp2mul_mont(A, numArray2, Rs[1].X);
    this.engine.fpx.fp2sub(numArray1, numArray2, Rs[1].Z);
    this.engine.fpx.fp2mul_mont(Rs[0].X, Rs[1].Z, numArray1);
    this.engine.fpx.fp2add(numArray3, Rs[1].X, numArray2);
    this.engine.fpx.fp2add(numArray2, numArray2, numArray2);
    this.engine.fpx.fp2sub(numArray1, numArray2, numArray1);
    this.engine.fpx.fp2mul_mont(xs[1].Z, numArray1, numArray1);
    this.engine.fpx.fp2sub(numArray1, numArray5, numArray1);
    this.engine.fpx.fp2mul_mont(Rs[0].X, numArray1, numArray1);
    this.engine.fpx.fp2add(numArray1, Rs[1].Y, Rs[1].Y);
    this.engine.fpx.fp2mul_mont(Rs[0].Y, numArray4, numArray1);
    this.engine.fpx.fp2mul_mont(xs[1].X, numArray1, Rs[1].X);
    this.engine.fpx.fp2add(Rs[1].X, Rs[1].X, Rs[1].X);
    this.engine.fpx.fp2mul_mont(xs[1].Z, numArray1, Rs[1].Z);
    this.engine.fpx.fp2add(Rs[1].Z, Rs[1].Z, Rs[1].Z);
    this.engine.fpx.fp2inv_mont_bingcd(Rs[1].Z);
    this.engine.fpx.fp2mul_mont(Rs[1].X, Rs[1].Z, Rs[1].X);
    this.engine.fpx.fp2mul_mont(Rs[1].Y, Rs[1].Z, Rs[1].Y);
  }

  internal void BuildOrdinary2nBasis_dual(
    ulong[][] A,
    ulong[][][][] Ds,
    PointProjFull[] Rs,
    byte[] qnr,
    byte[] ind)
  {
    ulong[] numArray = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[][] A1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    PointProj[] pointProjArray = new PointProj[3]
    {
      new PointProj(this.engine.param.NWORDS_FIELD),
      new PointProj(this.engine.param.NWORDS_FIELD),
      new PointProj(this.engine.param.NWORDS_FIELD)
    };
    this.BuildEntangledXonly(A, pointProjArray, qnr, ind);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, pointProjArray[0].Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, pointProjArray[1].Z[0]);
    for (uint index = 0; index < this.engine.param.MAX_Bob; ++index)
    {
      this.engine.isogeny.Eval3Isog(pointProjArray[0], Ds[(int) this.engine.param.MAX_Bob - 1 - (int) index]);
      this.engine.isogeny.Eval3Isog(pointProjArray[1], Ds[(int) this.engine.param.MAX_Bob - 1 - (int) index]);
      this.engine.isogeny.Eval3Isog(pointProjArray[2], Ds[(int) this.engine.param.MAX_Bob - 1 - (int) index]);
    }
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, A1[0]);
    this.engine.fpx.fpaddPRIME(A1[0], A1[0], numArray);
    this.engine.fpx.fpaddPRIME(numArray, numArray, A1[0]);
    this.engine.fpx.fpaddPRIME(A1[0], numArray, A1[0]);
    this.engine.isogeny.CompleteMPoint(A1, pointProjArray[0], Rs[0]);
    this.RecoverY(A1, pointProjArray, Rs);
  }

  internal void FullIsogeny_B_dual(byte[] PrivateKeyB, ulong[][][][] Ds, ulong[][] A)
  {
    PointProj pointProj = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj Q = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj[] pointProjArray = new PointProj[(int) this.engine.param.MAX_INT_POINTS_BOB];
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] coeff = SikeUtilities.InitArray(3U, 2U, this.engine.param.NWORDS_FIELD);
    uint index1 = 0;
    uint num1 = 0;
    uint[] numArray6 = new uint[(int) this.engine.param.MAX_INT_POINTS_BOB];
    ulong[] numArray7 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    this.init_basis(this.engine.param.B_gen, numArray1, numArray2, numArray3);
    this.engine.fpx.fpcopy(this.engine.param.XQB3, 0L, Q.X[0]);
    this.engine.fpx.fpcopy(this.engine.param.XQB3, (long) this.engine.param.NWORDS_FIELD, Q.X[1]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, Q.Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray4[0]);
    this.engine.fpx.fp2add(numArray4, numArray4, numArray4);
    this.engine.fpx.fp2add(numArray4, numArray4, numArray5);
    this.engine.fpx.fp2add(numArray4, numArray5, A);
    this.engine.fpx.fp2add(numArray5, numArray5, numArray4);
    this.engine.fpx.decode_to_digits(PrivateKeyB, 0U, numArray7, this.engine.param.SECRETKEY_B_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.isogeny.LADDER3PT(numArray1, numArray2, numArray3, numArray7, this.engine.param.BOB, pointProj, A);
    uint num2 = 0;
    for (uint index2 = 1; index2 < this.engine.param.MAX_Bob; ++index2)
    {
      uint e;
      for (; num2 < this.engine.param.MAX_Bob - index2; num2 += e)
      {
        pointProjArray[(int) index1] = new PointProj(this.engine.param.NWORDS_FIELD);
        this.engine.fpx.fp2copy(pointProj.X, pointProjArray[(int) index1].X);
        this.engine.fpx.fp2copy(pointProj.Z, pointProjArray[(int) index1].Z);
        numArray6[(int) index1++] = num2;
        e = this.engine.param.strat_Bob[(int) num1++];
        this.engine.isogeny.XTplE(pointProj, pointProj, numArray5, numArray4, e);
      }
      this.engine.isogeny.Get3Isog(pointProj, numArray5, numArray4, coeff);
      for (uint index3 = 0; index3 < index1; ++index3)
        this.engine.isogeny.Eval3Isog(pointProjArray[(int) index3], coeff);
      this.engine.isogeny.Eval3Isog(Q, coeff);
      this.engine.fpx.fp2sub(Q.X, Q.Z, Ds[(int) index2 - 1][0]);
      this.engine.fpx.fp2add(Q.X, Q.Z, Ds[(int) index2 - 1][1]);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].X, pointProj.X);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].Z, pointProj.Z);
      num2 = numArray6[(int) index1 - 1];
      --index1;
    }
    this.engine.isogeny.Get3Isog(pointProj, numArray5, numArray4, coeff);
    this.engine.isogeny.Eval3Isog(Q, coeff);
    this.engine.fpx.fp2sub(Q.X, Q.Z, Ds[(int) this.engine.param.MAX_Bob - 1][0]);
    this.engine.fpx.fp2add(Q.X, Q.Z, Ds[(int) this.engine.param.MAX_Bob - 1][1]);
    this.engine.fpx.fp2add(numArray4, numArray5, A);
    this.engine.fpx.fp2sub(numArray4, numArray5, numArray4);
    this.engine.fpx.fp2inv_mont_bingcd(numArray4);
    this.engine.fpx.fp2mul_mont(numArray4, A, A);
    this.engine.fpx.fp2add(A, A, A);
  }

  internal void Dlogs2_dual(
    ulong[][][] f,
    int[] D,
    ulong[] d0,
    ulong[] c0,
    ulong[] d1,
    ulong[] c1)
  {
    this.solve_dlog(f[0], D, d0, 2U);
    this.solve_dlog(f[2], D, c0, 2U);
    this.solve_dlog(f[1], D, d1, 2U);
    this.solve_dlog(f[3], D, c1, 2U);
    long num1 = (long) this.engine.fpx.mp_sub(this.engine.param.Alice_order, c0, c0, this.engine.param.NWORDS_ORDER);
    long num2 = (long) this.engine.fpx.mp_sub(this.engine.param.Alice_order, c1, c1, this.engine.param.NWORDS_ORDER);
  }

  internal void BuildEntangledXonly_Decomp(ulong[][] A, PointProj[] R, uint qnr, uint ind)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] b = qnr != 1U ? this.engine.param.table_v_qr : this.engine.param.table_v_qnr;
    if (ind >= this.engine.param.TABLE_V_LEN / 2U)
      ind = 0U;
    this.engine.fpx.fp2mul_mont(A, b, ind * 2U, R[0].X);
    this.engine.fpx.fp2neg(R[0].X);
    this.engine.fpx.fp2add(R[0].X, A, numArray2);
    this.engine.fpx.fp2mul_mont(R[0].X, numArray2, numArray2);
    this.engine.fpx.fpaddPRIME(numArray2[0], this.engine.param.Montgomery_one, numArray2[0]);
    this.engine.fpx.fp2mul_mont(R[0].X, numArray2, numArray2);
    if (qnr == 1U)
      this.engine.fpx.fpcopy(this.engine.param.table_r_qnr[(int) ind], 0L, numArray1[0]);
    else
      this.engine.fpx.fpcopy(this.engine.param.table_r_qr[(int) ind], 0L, numArray1[0]);
    this.engine.fpx.fp2add(R[0].X, A, R[1].X);
    this.engine.fpx.fp2neg(R[1].X);
    this.engine.fpx.fp2sub(R[0].X, R[1].X, R[2].Z);
    this.engine.fpx.fp2sqr_mont(R[2].Z, R[2].Z);
    this.engine.fpx.fpcopy(numArray1[0], 0L, numArray1[1]);
    this.engine.fpx.fpaddPRIME(this.engine.param.Montgomery_one, numArray1[0], numArray1[0]);
    this.engine.fpx.fp2sqr_mont(numArray1, numArray1);
    this.engine.fpx.fp2mul_mont(numArray2, numArray1, R[2].X);
  }

  internal void PKBDecompression_extended(
    byte[] SecretKeyA,
    uint SecretKeyAOffset,
    byte[] CompressedPKB,
    PointProj R,
    ulong[][] A,
    byte[] tphiBKA_t,
    uint tphiBKA_tOffset)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[] numArray3 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray4 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray5 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray6 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray7 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray8 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray9 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray10 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray11 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    PointProj[] pointProjArray = new PointProj[3]
    {
      new PointProj(this.engine.param.NWORDS_FIELD),
      new PointProj(this.engine.param.NWORDS_FIELD),
      new PointProj(this.engine.param.NWORDS_FIELD)
    };
    ulong num1 = ulong.MaxValue >> (int) this.engine.param.MAXBITS_ORDER - (int) this.engine.param.OALICE_BITS;
    this.engine.fpx.fp2_decode(CompressedPKB, A, 4U * this.engine.param.ORDER_A_ENCODED_BYTES);
    uint qnr = (uint) CompressedPKB[4 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] & 1U;
    uint ind = (uint) CompressedPKB[4 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES + 1];
    this.BuildEntangledXonly_Decomp(A, pointProjArray, qnr, ind);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, pointProjArray[0].Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, pointProjArray[1].Z[0]);
    this.engine.fpx.fpaddPRIME(A[0], this.engine.param.Montgomery_one, numArray1[0]);
    this.engine.fpx.fpcopy(A[1], 0L, numArray1[1]);
    this.engine.fpx.fpaddPRIME(numArray1[0], this.engine.param.Montgomery_one, numArray1[0]);
    this.engine.fpx.fp2div2(numArray1, numArray1);
    this.engine.fpx.fp2div2(numArray1, numArray1);
    this.engine.fpx.decode_to_digits(SecretKeyA, SecretKeyAOffset, numArray7, this.engine.param.SECRETKEY_A_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.fpx.decode_to_digits(CompressedPKB, 0U, numArray8, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.fpx.decode_to_digits(CompressedPKB, this.engine.param.ORDER_A_ENCODED_BYTES, numArray10, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.fpx.decode_to_digits(CompressedPKB, 2U * this.engine.param.ORDER_A_ENCODED_BYTES, numArray9, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.fpx.decode_to_digits(CompressedPKB, 3U * this.engine.param.ORDER_A_ENCODED_BYTES, numArray11, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
    if (((long) numArray8[0] & 1L) == 1L)
    {
      this.engine.fpx.multiply(numArray7, numArray11, numArray3, this.engine.param.NWORDS_ORDER);
      long num2 = (long) this.engine.fpx.mp_add(numArray3, numArray10, numArray3, this.engine.param.NWORDS_ORDER);
      numArray3[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
      this.engine.fpx.multiply(numArray7, numArray9, numArray4, this.engine.param.NWORDS_ORDER);
      long num3 = (long) this.engine.fpx.mp_add(numArray4, numArray8, numArray4, this.engine.param.NWORDS_ORDER);
      numArray4[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
      this.engine.fpx.inv_mod_orderA(numArray4, numArray5);
      this.engine.fpx.multiply(numArray3, numArray5, numArray6, this.engine.param.NWORDS_ORDER);
      numArray6[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
      this.Ladder3pt_dual(pointProjArray, numArray6, this.engine.param.ALICE, R, numArray1);
    }
    else
    {
      this.engine.fpx.multiply(numArray7, numArray9, numArray3, this.engine.param.NWORDS_ORDER);
      long num4 = (long) this.engine.fpx.mp_add(numArray3, numArray8, numArray3, this.engine.param.NWORDS_ORDER);
      numArray3[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
      this.engine.fpx.multiply(numArray7, numArray11, numArray4, this.engine.param.NWORDS_ORDER);
      long num5 = (long) this.engine.fpx.mp_add(numArray4, numArray10, numArray4, this.engine.param.NWORDS_ORDER);
      numArray4[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
      this.engine.fpx.inv_mod_orderA(numArray4, numArray5);
      this.engine.fpx.multiply(numArray5, numArray3, numArray6, this.engine.param.NWORDS_ORDER);
      numArray6[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
      this.engine.isogeny.SwapPoints(pointProjArray[0], pointProjArray[1], ulong.MaxValue);
      this.Ladder3pt_dual(pointProjArray, numArray6, this.engine.param.ALICE, R, numArray1);
    }
    this.engine.fpx.fp2div2(A, numArray2);
    this.engine.isogeny.XTplEFast(R, R, numArray2, this.engine.param.OBOB_EXPON);
    this.engine.fpx.fp2_encode(R.X, tphiBKA_t, tphiBKA_tOffset);
    this.engine.fpx.fp2_encode(R.Z, tphiBKA_t, tphiBKA_tOffset + this.engine.param.FP2_ENCODED_BYTES);
    this.engine.fpx.encode_to_bytes(numArray5, tphiBKA_t, tphiBKA_tOffset + 2U * this.engine.param.FP2_ENCODED_BYTES, this.engine.param.ORDER_A_ENCODED_BYTES);
  }

  internal void Compress_PKB_dual_extended(
    ulong[] d0,
    ulong[] c0,
    ulong[] d1,
    ulong[] c1,
    ulong[][] A,
    byte[] qnr,
    byte[] ind,
    byte[] CompressedPKB)
  {
    ulong[] numArray1 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray2 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray3 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong num1 = ulong.MaxValue >> (int) this.engine.param.MAXBITS_ORDER - (int) this.engine.param.OALICE_BITS;
    this.engine.fpx.multiply(c0, d1, numArray1, this.engine.param.NWORDS_ORDER);
    this.engine.fpx.multiply(c1, d0, numArray2, this.engine.param.NWORDS_ORDER);
    this.engine.fpx.Montgomery_neg(numArray2, this.engine.param.Alice_order);
    long num2 = (long) this.engine.fpx.mp_add(numArray1, numArray2, numArray2, this.engine.param.NWORDS_ORDER);
    numArray2[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
    this.engine.fpx.inv_mod_orderA(numArray2, numArray3);
    this.engine.fpx.multiply(d1, numArray3, numArray1, this.engine.param.NWORDS_ORDER);
    numArray1[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
    this.engine.fpx.encode_to_bytes(numArray1, CompressedPKB, 0U, this.engine.param.ORDER_A_ENCODED_BYTES);
    this.engine.fpx.Montgomery_neg(d0, this.engine.param.Alice_order);
    this.engine.fpx.multiply(d0, numArray3, numArray1, this.engine.param.NWORDS_ORDER);
    numArray1[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
    this.engine.fpx.encode_to_bytes(numArray1, CompressedPKB, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.ORDER_A_ENCODED_BYTES);
    this.engine.fpx.Montgomery_neg(c1, this.engine.param.Alice_order);
    this.engine.fpx.multiply(c1, numArray3, numArray1, this.engine.param.NWORDS_ORDER);
    numArray1[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
    this.engine.fpx.encode_to_bytes(numArray1, CompressedPKB, 2U * this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.ORDER_A_ENCODED_BYTES);
    this.engine.fpx.multiply(c0, numArray3, numArray1, this.engine.param.NWORDS_ORDER);
    numArray1[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
    this.engine.fpx.encode_to_bytes(numArray1, CompressedPKB, 3U * this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.ORDER_A_ENCODED_BYTES);
    this.engine.fpx.fp2_encode(A, CompressedPKB, 4U * this.engine.param.ORDER_A_ENCODED_BYTES);
    CompressedPKB[4 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] = qnr[0];
    CompressedPKB[4 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES + 1] = ind[0];
  }

  internal void PKBDecompression(
    byte[] SecretKeyA,
    uint SecretKeyAOffset,
    byte[] CompressedPKB,
    PointProj R,
    ulong[][] A)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[] numArray2 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray3 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray4 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray5 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray6 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    PointProj[] pointProjArray = new PointProj[3];
    ulong num1 = ulong.MaxValue >> (int) this.engine.param.MAXBITS_ORDER - (int) this.engine.param.OALICE_BITS;
    numArray4[0] = 1UL;
    this.engine.fpx.fp2_decode(CompressedPKB, A, 3U * this.engine.param.ORDER_A_ENCODED_BYTES);
    uint num2 = (uint) CompressedPKB[3 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] >> 7;
    uint qnr = (uint) CompressedPKB[3 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] & 1U;
    uint ind = (uint) CompressedPKB[3 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES + 1];
    this.BuildEntangledXonly_Decomp(A, pointProjArray, qnr, ind);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, pointProjArray[0].Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, pointProjArray[1].Z[0]);
    this.engine.fpx.fpaddPRIME(A[0], this.engine.param.Montgomery_one, numArray1[0]);
    this.engine.fpx.fpcopy(A[1], 0L, numArray1[1]);
    this.engine.fpx.fpaddPRIME(numArray1[0], this.engine.param.Montgomery_one, numArray1[0]);
    this.engine.fpx.fp2div2(numArray1, numArray1);
    this.engine.fpx.fp2div2(numArray1, numArray1);
    this.engine.fpx.decode_to_digits(SecretKeyA, SecretKeyAOffset, numArray5, this.engine.param.SECRETKEY_A_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.isogeny.SwapPoints(pointProjArray[0], pointProjArray[1], (ulong) -num2);
    if (num2 == 0U)
    {
      this.engine.fpx.decode_to_digits(CompressedPKB, this.engine.param.ORDER_A_ENCODED_BYTES, numArray6, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.multiply(numArray5, numArray6, numArray2, this.engine.param.NWORDS_ORDER);
      long num3 = (long) this.engine.fpx.mp_add(numArray2, numArray4, numArray2, this.engine.param.NWORDS_ORDER);
      numArray2[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
      this.engine.fpx.inv_mod_orderA(numArray2, numArray3);
      this.engine.fpx.decode_to_digits(CompressedPKB, 2U * this.engine.param.ORDER_A_ENCODED_BYTES, numArray6, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.multiply(numArray5, numArray6, numArray2, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.decode_to_digits(CompressedPKB, 0U, numArray6, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
      long num4 = (long) this.engine.fpx.mp_add(numArray6, numArray2, numArray2, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.multiply(numArray2, numArray3, numArray4, this.engine.param.NWORDS_ORDER);
      numArray4[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
      this.Ladder3pt_dual(pointProjArray, numArray4, this.engine.param.ALICE, R, numArray1);
    }
    else
    {
      this.engine.fpx.decode_to_digits(CompressedPKB, 2U * this.engine.param.ORDER_A_ENCODED_BYTES, numArray6, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.multiply(numArray5, numArray6, numArray2, this.engine.param.NWORDS_ORDER);
      long num5 = (long) this.engine.fpx.mp_add(numArray2, numArray4, numArray2, this.engine.param.NWORDS_ORDER);
      numArray2[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
      this.engine.fpx.inv_mod_orderA(numArray2, numArray3);
      this.engine.fpx.decode_to_digits(CompressedPKB, this.engine.param.ORDER_A_ENCODED_BYTES, numArray6, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.multiply(numArray5, numArray6, numArray2, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.decode_to_digits(CompressedPKB, 0U, numArray6, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
      long num6 = (long) this.engine.fpx.mp_add(numArray6, numArray2, numArray2, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.multiply(numArray2, numArray3, numArray4, this.engine.param.NWORDS_ORDER);
      numArray4[(int) this.engine.param.NWORDS_ORDER - 1] &= num1;
      this.Ladder3pt_dual(pointProjArray, numArray4, this.engine.param.ALICE, R, numArray1);
    }
    this.engine.fpx.fp2div2(A, numArray1);
    this.engine.isogeny.XTplEFast(R, R, numArray1, this.engine.param.OBOB_EXPON);
  }

  internal void Compress_PKB_dual(
    ulong[] d0,
    ulong[] c0,
    ulong[] d1,
    ulong[] c1,
    ulong[][] A,
    byte[] qnr,
    byte[] ind,
    byte[] CompressedPKB)
  {
    ulong[] numArray1 = new ulong[2 * (int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    if (((long) d1[0] & 1L) == 1L)
    {
      this.engine.fpx.inv_mod_orderA(d1, numArray2);
      this.engine.fpx.Montgomery_neg(d0, this.engine.param.Alice_order);
      this.engine.fpx.multiply(d0, numArray2, numArray1, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKB, 0U, this.engine.param.ORDER_A_ENCODED_BYTES);
      CompressedPKB[(int) this.engine.param.ORDER_A_ENCODED_BYTES - 1] &= (byte) this.engine.param.MASK_ALICE;
      this.engine.fpx.Montgomery_neg(c1, this.engine.param.Alice_order);
      this.engine.fpx.multiply(c1, numArray2, numArray1, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKB, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.ORDER_A_ENCODED_BYTES);
      CompressedPKB[2 * (int) this.engine.param.ORDER_A_ENCODED_BYTES - 1] &= (byte) this.engine.param.MASK_ALICE;
      this.engine.fpx.multiply(c0, numArray2, numArray1, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKB, 2U * this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.ORDER_A_ENCODED_BYTES);
      CompressedPKB[3 * (int) this.engine.param.ORDER_A_ENCODED_BYTES - 1] &= (byte) this.engine.param.MASK_ALICE;
      CompressedPKB[3 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] = (byte) 0;
    }
    else
    {
      this.engine.fpx.inv_mod_orderA(d0, numArray2);
      this.engine.fpx.Montgomery_neg(d1, this.engine.param.Alice_order);
      this.engine.fpx.multiply(d1, numArray2, numArray1, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKB, 0U, this.engine.param.ORDER_A_ENCODED_BYTES);
      CompressedPKB[(int) this.engine.param.ORDER_A_ENCODED_BYTES - 1] &= (byte) this.engine.param.MASK_ALICE;
      this.engine.fpx.multiply(c1, numArray2, numArray1, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKB, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.ORDER_A_ENCODED_BYTES);
      CompressedPKB[2 * (int) this.engine.param.ORDER_A_ENCODED_BYTES - 1] &= (byte) this.engine.param.MASK_ALICE;
      this.engine.fpx.Montgomery_neg(c0, this.engine.param.Alice_order);
      this.engine.fpx.multiply(c0, numArray2, numArray1, this.engine.param.NWORDS_ORDER);
      this.engine.fpx.encode_to_bytes(numArray1, CompressedPKB, 2U * this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.ORDER_A_ENCODED_BYTES);
      CompressedPKB[3 * (int) this.engine.param.ORDER_A_ENCODED_BYTES - 1] &= (byte) this.engine.param.MASK_ALICE;
      CompressedPKB[3 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] = (byte) 128 /*0x80*/;
    }
    this.engine.fpx.fp2_encode(A, CompressedPKB, 3U * this.engine.param.ORDER_A_ENCODED_BYTES);
    CompressedPKB[3 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES] |= qnr[0];
    CompressedPKB[3 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES + 1] = ind[0];
    CompressedPKB[3 * (int) this.engine.param.ORDER_A_ENCODED_BYTES + (int) this.engine.param.FP2_ENCODED_BYTES + 2] = (byte) 0;
  }

  internal uint EphemeralKeyGeneration_B_extended(
    byte[] PrivateKeyB,
    byte[] CompressedPKB,
    uint sike)
  {
    byte[] qnr = new byte[1];
    byte[] ind = new byte[1];
    int[] D = new int[(int) this.engine.param.DLEN_2];
    ulong[] c0 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] d0 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] c1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] d1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[][][][] Ds = SikeUtilities.InitArray(this.engine.param.MAX_Bob, 2U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] f = SikeUtilities.InitArray(4U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][] A = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    PointProjFull[] pointProjFullArray = new PointProjFull[2]
    {
      new PointProjFull(this.engine.param.NWORDS_FIELD),
      new PointProjFull(this.engine.param.NWORDS_FIELD)
    };
    PointProj P = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj Q = new PointProj(this.engine.param.NWORDS_FIELD);
    this.FullIsogeny_B_dual(PrivateKeyB, Ds, A);
    this.BuildOrdinary2nBasis_dual(A, Ds, pointProjFullArray, qnr, ind);
    this.engine.fpx.fpaddPRIME(this.engine.param.Montgomery_one, pointProjFullArray[0].X[0], pointProjFullArray[0].X[0]);
    this.engine.fpx.fpaddPRIME(this.engine.param.Montgomery_one, pointProjFullArray[0].X[0], pointProjFullArray[0].X[0]);
    this.engine.fpx.fpaddPRIME(this.engine.param.Montgomery_one, pointProjFullArray[1].X[0], pointProjFullArray[1].X[0]);
    this.engine.fpx.fpaddPRIME(this.engine.param.Montgomery_one, pointProjFullArray[1].X[0], pointProjFullArray[1].X[0]);
    this.engine.fpx.fpcopy(this.engine.param.A_basis_zero, 0L, P.X[0]);
    this.engine.fpx.fpcopy(this.engine.param.A_basis_zero, (long) this.engine.param.NWORDS_FIELD, P.X[1]);
    this.engine.fpx.fpcopy(this.engine.param.A_basis_zero, (long) (2U * this.engine.param.NWORDS_FIELD), P.Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.A_basis_zero, (long) (3U * this.engine.param.NWORDS_FIELD), P.Z[1]);
    this.engine.fpx.fpcopy(this.engine.param.A_basis_zero, (long) (4U * this.engine.param.NWORDS_FIELD), Q.X[0]);
    this.engine.fpx.fpcopy(this.engine.param.A_basis_zero, (long) (5U * this.engine.param.NWORDS_FIELD), Q.X[1]);
    this.engine.fpx.fpcopy(this.engine.param.A_basis_zero, (long) (6U * this.engine.param.NWORDS_FIELD), Q.Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.A_basis_zero, (long) (7U * this.engine.param.NWORDS_FIELD), Q.Z[1]);
    this.Tate2_pairings(P, Q, pointProjFullArray, f);
    this.engine.fpx.fp2correction(f[0]);
    this.engine.fpx.fp2correction(f[1]);
    this.engine.fpx.fp2correction(f[2]);
    this.engine.fpx.fp2correction(f[3]);
    this.Dlogs2_dual(f, D, d0, c0, d1, c1);
    if (sike == 1U)
      this.Compress_PKB_dual_extended(d0, c0, d1, c1, A, qnr, ind, CompressedPKB);
    else
      this.Compress_PKB_dual(d0, c0, d1, c1, A, qnr, ind, CompressedPKB);
    return 0;
  }

  internal uint EphemeralKeyGeneration_B(byte[] PrivateKeyB, byte[] CompressedPKB)
  {
    return this.EphemeralKeyGeneration_B_extended(PrivateKeyB, CompressedPKB, 0U);
  }

  internal uint EphemeralSecretAgreement_A_extended(
    byte[] PrivateKeyA,
    uint PrivateKeyAOffset,
    byte[] PKB,
    byte[] SharedSecretA,
    uint sike)
  {
    uint num1 = 0;
    uint index1 = 0;
    uint[] numArray1 = new uint[(int) this.engine.param.MAX_INT_POINTS_ALICE];
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    PointProj pointProj1 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj[] pointProjArray = new PointProj[(int) this.engine.param.MAX_INT_POINTS_ALICE];
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] coeff = SikeUtilities.InitArray(5U, 2U, this.engine.param.NWORDS_FIELD);
    if (sike == 1U)
      this.PKBDecompression_extended(PrivateKeyA, PrivateKeyAOffset, PKB, pointProj1, numArray6, SharedSecretA, this.engine.param.FP2_ENCODED_BYTES);
    else
      this.PKBDecompression(PrivateKeyA, PrivateKeyAOffset, PKB, pointProj1, numArray6);
    this.engine.fpx.fp2copy(numArray6, numArray5);
    this.engine.fpx.fpaddPRIME(this.engine.param.Montgomery_one, this.engine.param.Montgomery_one, numArray3[0]);
    this.engine.fpx.fp2add(numArray5, numArray3, numArray2);
    this.engine.fpx.fpaddPRIME(numArray3[0], numArray3[0], numArray3[0]);
    if (this.engine.param.OALICE_BITS % 2U == 1U)
    {
      PointProj pointProj2 = new PointProj(this.engine.param.NWORDS_FIELD);
      this.engine.isogeny.XDblE(pointProj1, pointProj2, numArray2, numArray3, this.engine.param.OALICE_BITS - 1U);
      this.engine.isogeny.Get2Isog(pointProj2, numArray2, numArray3);
      this.engine.isogeny.Eval2Isog(pointProj1, pointProj2);
    }
    uint num2 = 0;
    for (uint index2 = 1; index2 < this.engine.param.MAX_Alice; ++index2)
    {
      uint num3;
      for (; num2 < this.engine.param.MAX_Alice - index2; num2 += num3)
      {
        pointProjArray[(int) index1] = new PointProj(this.engine.param.NWORDS_FIELD);
        this.engine.fpx.fp2copy(pointProj1.X, pointProjArray[(int) index1].X);
        this.engine.fpx.fp2copy(pointProj1.Z, pointProjArray[(int) index1].Z);
        numArray1[(int) index1++] = num2;
        num3 = this.engine.param.strat_Alice[(int) num1++];
        this.engine.isogeny.XDblE(pointProj1, pointProj1, numArray2, numArray3, 2U * num3);
      }
      this.engine.isogeny.Get4Isog(pointProj1, numArray2, numArray3, coeff);
      for (uint index3 = 0; index3 < index1; ++index3)
        this.engine.isogeny.Eval4Isog(pointProjArray[(int) index3], coeff);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].X, pointProj1.X);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].Z, pointProj1.Z);
      num2 = numArray1[(int) index1 - 1];
      --index1;
    }
    this.engine.isogeny.Get4Isog(pointProj1, numArray2, numArray3, coeff);
    this.engine.fpx.fp2add(numArray2, numArray2, numArray2);
    this.engine.fpx.fp2sub(numArray2, numArray3, numArray2);
    this.engine.fpx.fp2add(numArray2, numArray2, numArray2);
    this.engine.isogeny.JInv(numArray2, numArray3, numArray4);
    this.engine.fpx.fp2_encode(numArray4, SharedSecretA, 0U);
    return 0;
  }

  private uint EphemeralSecretAgreement_A(
    byte[] PrivateKeyA,
    uint PrivateKeyAOffset,
    byte[] PKB,
    byte[] SharedSecretA)
  {
    return this.EphemeralSecretAgreement_A_extended(PrivateKeyA, PrivateKeyAOffset, PKB, SharedSecretA, 0U);
  }

  internal byte validate_ciphertext(
    byte[] ephemeralsk_,
    byte[] CompressedPKB,
    byte[] xKA,
    uint xKAOffset,
    byte[] tphiBKA_t,
    uint tphiBKA_tOffset)
  {
    PointProj[] pointProjArray1 = new PointProj[3];
    PointProj[] pointProjArray2 = new PointProj[(int) this.engine.param.MAX_INT_POINTS_BOB];
    pointProjArray1[0] = new PointProj(this.engine.param.NWORDS_FIELD);
    pointProjArray1[1] = new PointProj(this.engine.param.NWORDS_FIELD);
    pointProjArray1[2] = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj pointProj1 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj pointProj2 = new PointProj(this.engine.param.NWORDS_FIELD);
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray7 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray8 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray9 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] coeff = SikeUtilities.InitArray(3U, 2U, this.engine.param.NWORDS_FIELD);
    uint index1 = 0;
    uint num1 = 0;
    uint[] numArray10 = new uint[(int) this.engine.param.MAX_INT_POINTS_BOB];
    ulong[] numArray11 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray12 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray9[0]);
    this.init_basis(this.engine.param.B_gen, numArray1, numArray2, numArray3);
    this.engine.fpx.fp2_decode(xKA, pointProjArray1[0].X, xKAOffset);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, pointProjArray1[0].Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray4[0]);
    this.engine.fpx.fp2add(numArray4, numArray4, numArray4);
    this.engine.fpx.fp2add(numArray4, numArray4, numArray5);
    this.engine.fpx.fp2add(numArray4, numArray5, numArray6);
    this.engine.fpx.fp2add(numArray5, numArray5, numArray4);
    this.engine.fpx.decode_to_digits(ephemeralsk_, 0U, numArray12, this.engine.param.SECRETKEY_B_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.isogeny.LADDER3PT(numArray1, numArray2, numArray3, numArray12, this.engine.param.BOB, pointProj1, numArray6);
    uint num2 = 0;
    for (uint index2 = 1; index2 < this.engine.param.MAX_Bob; ++index2)
    {
      uint e;
      for (; num2 < this.engine.param.MAX_Bob - index2; num2 += e)
      {
        pointProjArray2[(int) index1] = new PointProj(this.engine.param.NWORDS_FIELD);
        this.engine.fpx.fp2copy(pointProj1.X, pointProjArray2[(int) index1].X);
        this.engine.fpx.fp2copy(pointProj1.Z, pointProjArray2[(int) index1].Z);
        numArray10[(int) index1++] = num2;
        e = this.engine.param.strat_Bob[(int) num1++];
        this.engine.isogeny.XTplE(pointProj1, pointProj1, numArray5, numArray4, e);
      }
      this.engine.isogeny.Get3Isog(pointProj1, numArray5, numArray4, coeff);
      for (uint index3 = 0; index3 < index1; ++index3)
        this.engine.isogeny.Eval3Isog(pointProjArray2[(int) index3], coeff);
      this.engine.isogeny.Eval3Isog(pointProjArray1[0], coeff);
      this.engine.fpx.fp2copy(pointProjArray2[(int) index1 - 1].X, pointProj1.X);
      this.engine.fpx.fp2copy(pointProjArray2[(int) index1 - 1].Z, pointProj1.Z);
      num2 = numArray10[(int) index1 - 1];
      --index1;
    }
    this.engine.isogeny.Get3Isog(pointProj1, numArray5, numArray4, coeff);
    this.engine.isogeny.Eval3Isog(pointProjArray1[0], coeff);
    this.engine.fpx.fp2_decode(CompressedPKB, numArray6, 4U * this.engine.param.ORDER_A_ENCODED_BYTES);
    this.engine.fpx.fp2_decode(tphiBKA_t, pointProj2.X, tphiBKA_tOffset);
    this.engine.fpx.fp2_decode(tphiBKA_t, pointProj2.Z, tphiBKA_tOffset + this.engine.param.FP2_ENCODED_BYTES);
    this.engine.fpx.decode_to_digits(tphiBKA_t, tphiBKA_tOffset + 2U * this.engine.param.FP2_ENCODED_BYTES, numArray11, this.engine.param.ORDER_A_ENCODED_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.isogeny.Ladder(pointProjArray1[0], numArray11, numArray6, this.engine.param.OALICE_BITS, pointProj1);
    this.engine.fpx.fp2mul_mont(pointProj1.X, pointProj2.Z, numArray7);
    this.engine.fpx.fp2mul_mont(pointProj1.Z, pointProj2.X, numArray8);
    return this.engine.fpx.cmp_f2elm(numArray7, numArray8);
  }

  internal void solve_dlog(ulong[][] r, int[] D, ulong[] d, uint ell)
  {
    switch (ell)
    {
      case 2:
        if ((long) this.engine.param.OALICE_BITS % (long) (int) this.engine.param.W_2 == 0L)
          this.Traverse_w_div_e_fullsigned(r, 0U, 0U, this.engine.param.PLEN_2 - 1U, this.engine.param.ph2_path, this.engine.param.ph2_T, D, this.engine.param.DLEN_2, this.engine.param.ELL2_W, this.engine.param.W_2);
        else
          this.Traverse_w_notdiv_e_fullsigned(r, 0U, 0U, this.engine.param.PLEN_2 - 1U, this.engine.param.ph2_path, this.engine.param.ph2_T1, this.engine.param.ph2_T2, D, this.engine.param.DLEN_2, ell, this.engine.param.ELL2_W, this.engine.param.ELL2_EMODW, this.engine.param.W_2, this.engine.param.OALICE_BITS);
        this.from_base(D, d, this.engine.param.DLEN_2, this.engine.param.ELL2_W);
        break;
      case 3:
        if ((long) this.engine.param.OBOB_EXPON % (long) (int) this.engine.param.W_3 == 0L)
          this.Traverse_w_div_e_fullsigned(r, 0U, 0U, this.engine.param.PLEN_3 - 1U, this.engine.param.ph3_path, this.engine.param.ph3_T, D, this.engine.param.DLEN_3, this.engine.param.ELL3_W, this.engine.param.W_3);
        else
          this.Traverse_w_notdiv_e_fullsigned(r, 0U, 0U, this.engine.param.PLEN_3 - 1U, this.engine.param.ph3_path, this.engine.param.ph3_T1, this.engine.param.ph3_T2, D, this.engine.param.DLEN_3, ell, this.engine.param.ELL3_W, this.engine.param.ELL3_EMODW, this.engine.param.W_3, this.engine.param.OBOB_EXPON);
        this.from_base(D, d, this.engine.param.DLEN_3, this.engine.param.ELL3_W);
        break;
    }
  }

  private void from_base(int[] D, ulong[] r, uint Dlen, uint baseNum)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    ulong[] numArray3 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    numArray1[0] = (ulong) baseNum;
    if (D[(int) Dlen - 1] < 0)
    {
      numArray2[0] = (ulong) (-D[(int) Dlen - 1] * (int) numArray1[0]);
      if (((int) baseNum & 1) == 0)
      {
        this.engine.fpx.Montgomery_neg(numArray2, this.engine.param.Alice_order);
        this.engine.fpx.copy_words(numArray2, r, this.engine.param.NWORDS_ORDER);
      }
      else
      {
        long num = (long) this.engine.fpx.mp_sub(this.engine.param.Bob_order, numArray2, r, this.engine.param.NWORDS_ORDER);
      }
    }
    else
      r[0] = (ulong) (uint) D[(int) Dlen - 1] * numArray1[0];
    for (uint index = Dlen - 2U; index >= 1U; --index)
    {
      uint num1 = baseNum;
      Arrays.Fill(numArray2, 0UL);
      if (D[(int) index] < 0)
      {
        numArray2[0] = (ulong) -D[(int) index];
        if (((int) baseNum & 1) == 0)
        {
          this.engine.fpx.Montgomery_neg(numArray2, this.engine.param.Alice_order);
        }
        else
        {
          long num2 = (long) this.engine.fpx.mp_sub(this.engine.param.Bob_order, numArray2, numArray2, this.engine.param.NWORDS_ORDER);
        }
      }
      else
        numArray2[0] = (ulong) (uint) D[(int) index];
      long num3 = (long) this.engine.fpx.mp_add(r, numArray2, r, this.engine.param.NWORDS_ORDER);
      if (((int) baseNum & 1) != 0 && !this.engine.fpx.is_orderelm_lt(r, this.engine.param.Bob_order))
      {
        long num4 = (long) this.engine.fpx.mp_sub(r, this.engine.param.Bob_order, r, this.engine.param.NWORDS_ORDER);
      }
      if (((int) baseNum & 1) == 0)
      {
        for (; num1 > 1U; num1 /= 2U)
        {
          long num5 = (long) this.engine.fpx.mp_add(r, r, r, this.engine.param.NWORDS_ORDER);
        }
      }
      else
      {
        for (; num1 > 1U; num1 /= 3U)
        {
          Arrays.Fill(numArray3, 0UL);
          long num6 = (long) this.engine.fpx.mp_add(r, r, numArray3, this.engine.param.NWORDS_ORDER);
          if (!this.engine.fpx.is_orderelm_lt(numArray3, this.engine.param.Bob_order))
          {
            long num7 = (long) this.engine.fpx.mp_sub(numArray3, this.engine.param.Bob_order, numArray3, this.engine.param.NWORDS_ORDER);
          }
          long num8 = (long) this.engine.fpx.mp_add(r, numArray3, r, this.engine.param.NWORDS_ORDER);
          if (!this.engine.fpx.is_orderelm_lt(r, this.engine.param.Bob_order))
          {
            long num9 = (long) this.engine.fpx.mp_sub(r, this.engine.param.Bob_order, r, this.engine.param.NWORDS_ORDER);
          }
        }
      }
    }
    Arrays.Fill(numArray2, 0UL);
    if (D[0] < 0)
    {
      numArray2[0] = (ulong) -D[0];
      if (((int) baseNum & 1) == 0)
      {
        this.engine.fpx.Montgomery_neg(numArray2, this.engine.param.Alice_order);
      }
      else
      {
        long num = (long) this.engine.fpx.mp_sub(this.engine.param.Bob_order, numArray2, numArray2, this.engine.param.NWORDS_ORDER);
      }
    }
    else
      numArray2[0] = (ulong) (uint) D[0];
    long num10 = (long) this.engine.fpx.mp_add(r, numArray2, r, this.engine.param.NWORDS_ORDER);
    if (((int) baseNum & 1) == 0 || this.engine.fpx.is_orderelm_lt(r, this.engine.param.Bob_order))
      return;
    long num11 = (long) this.engine.fpx.mp_sub(r, this.engine.param.Bob_order, r, this.engine.param.NWORDS_ORDER);
  }

  internal void Traverse_w_notdiv_e_fullsigned(
    ulong[][] r,
    uint j,
    uint k,
    uint z,
    uint[] P,
    ulong[] CT1,
    ulong[] CT2,
    int[] D,
    uint Dlen,
    uint ell,
    uint ellw,
    uint ell_emodw,
    uint w,
    uint e)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    if (z > 1U)
    {
      uint z1 = P[(int) z];
      this.engine.fpx.fp2copy(r, numArray1);
      uint num = j > 0U ? w * (z - z1) : e % w + w * (uint) ((int) z - (int) z1 - 1);
      for (uint index = 0; index < num; ++index)
      {
        if (((int) ell & 1) == 0)
          this.engine.fpx.sqr_Fp2_cycl(numArray1, this.engine.param.Montgomery_one);
        else
          this.engine.fpx.cube_Fp2_cycl(numArray1, this.engine.param.Montgomery_one);
      }
      this.Traverse_w_notdiv_e_fullsigned(numArray1, j + (z - z1), k, z1, P, CT1, CT2, D, Dlen, ell, ellw, ell_emodw, w, e);
      this.engine.fpx.fp2copy(r, numArray1);
      for (uint index = k; index < k + z1; ++index)
      {
        if (D[(int) index] != 0)
        {
          if (j > 0U)
          {
            if (D[(int) index] < 0)
            {
              this.engine.fpx.fp2copy(CT2, (uint) ((ulong) this.engine.param.NWORDS_FIELD * ((ulong) ((uint) (2 * ((int) j + (int) index)) * (ellw / 2U)) + (ulong) (2 * (-D[(int) index] - 1)))), numArray2);
              this.engine.fpx.fpnegPRIME(numArray2[1]);
              this.engine.fpx.fp2mul_mont(numArray1, numArray2, numArray1);
            }
            else
              this.engine.fpx.fp2mul_mont(numArray1, CT2, (uint) ((ulong) this.engine.param.NWORDS_FIELD * (ulong) (2L * ((long) ((j + index) * (ellw / 2U)) + (long) (D[(int) index] - 1)))), numArray1);
          }
          else if (D[(int) index] < 0)
          {
            this.engine.fpx.fp2copy(CT1, (uint) ((ulong) this.engine.param.NWORDS_FIELD * (ulong) (2L * ((long) ((j + index) * (ellw / 2U)) + (long) (-D[(int) index] - 1)))), numArray2);
            this.engine.fpx.fpnegPRIME(numArray2[1]);
            this.engine.fpx.fp2mul_mont(numArray1, numArray2, numArray1);
          }
          else
            this.engine.fpx.fp2mul_mont(numArray1, CT1, (uint) ((ulong) this.engine.param.NWORDS_FIELD * (ulong) (2L * ((long) ((j + index) * (ellw / 2U)) + (long) (D[(int) index] - 1)))), numArray1);
        }
      }
      this.Traverse_w_notdiv_e_fullsigned(numArray1, j, k + z1, z - z1, P, CT1, CT2, D, Dlen, ell, ellw, ell_emodw, w, e);
    }
    else
    {
      this.engine.fpx.fp2copy(r, numArray1);
      this.engine.fpx.fp2correction(numArray1);
      if (this.engine.fpx.is_felm_zero(numArray1[1]) && Fpx.subarrayEquals(numArray1[0], this.engine.param.Montgomery_one, this.engine.param.NWORDS_FIELD))
        D[(int) k] = 0;
      else if (j == 0U && (int) k == (int) Dlen - 1)
      {
        for (uint index = 1; index <= ell_emodw / 2U; ++index)
        {
          if (!Fpx.subarrayEquals(numArray1, CT1, this.engine.param.NWORDS_FIELD * (uint) (2 * (int) (ellw / 2U) * ((int) Dlen - 1) + 2 * ((int) index - 1)), 2U * this.engine.param.NWORDS_FIELD))
          {
            this.engine.fpx.fp2copy(CT1, this.engine.param.NWORDS_FIELD * (uint) (2 * ((int) (ellw / 2U) * ((int) Dlen - 1) + ((int) index - 1))), numArray2);
            this.engine.fpx.fpnegPRIME(numArray2[1]);
            this.engine.fpx.fpcorrectionPRIME(numArray2[1]);
            if (Fpx.subarrayEquals(numArray1, numArray2, 2U * this.engine.param.NWORDS_FIELD))
            {
              D[(int) k] = (int) index;
              break;
            }
          }
          else
          {
            D[(int) k] = -(int) index;
            break;
          }
        }
      }
      else
      {
        for (uint index = 1; index <= ellw / 2U; ++index)
        {
          if (!Fpx.subarrayEquals(numArray1, CT2, this.engine.param.NWORDS_FIELD * (uint) (2 * (int) (ellw / 2U) * ((int) Dlen - 1) + 2 * ((int) index - 1)), 2U * this.engine.param.NWORDS_FIELD))
          {
            this.engine.fpx.fp2copy(CT2, this.engine.param.NWORDS_FIELD * (uint) (2 * ((int) (ellw / 2U) * ((int) Dlen - 1) + ((int) index - 1))), numArray2);
            this.engine.fpx.fpnegPRIME(numArray2[1]);
            this.engine.fpx.fpcorrectionPRIME(numArray2[1]);
            if (Fpx.subarrayEquals(numArray1, numArray2, 2U * this.engine.param.NWORDS_FIELD))
            {
              D[(int) k] = (int) index;
              break;
            }
          }
          else
          {
            D[(int) k] = -(int) index;
            break;
          }
        }
      }
    }
  }

  internal void Traverse_w_div_e_fullsigned(
    ulong[][] r,
    uint j,
    uint k,
    uint z,
    uint[] P,
    ulong[] CT,
    int[] D,
    uint Dlen,
    uint ellw,
    uint w)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    if (z > 1U)
    {
      uint z1 = P[(int) z];
      this.engine.fpx.fp2copy(r, numArray1);
      for (uint index1 = 0; index1 < z - z1; ++index1)
      {
        if (((int) ellw & 1) == 0)
        {
          for (uint index2 = 0; index2 < w; ++index2)
            this.engine.fpx.sqr_Fp2_cycl(numArray1, this.engine.param.Montgomery_one);
        }
        else
        {
          for (uint index3 = 0; index3 < w; ++index3)
            this.engine.fpx.cube_Fp2_cycl(numArray1, this.engine.param.Montgomery_one);
        }
      }
      this.Traverse_w_div_e_fullsigned(numArray1, j + (z - z1), k, z1, P, CT, D, Dlen, ellw, w);
      this.engine.fpx.fp2copy(r, numArray1);
      for (uint index = k; index < k + z1; ++index)
      {
        if (D[(int) index] != 0)
        {
          if (D[(int) index] < 0)
          {
            this.engine.fpx.fp2copy(CT, (uint) ((ulong) this.engine.param.NWORDS_FIELD * (ulong) (2L * ((long) ((j + index) * (ellw / 2U)) + (long) (-D[(int) index] - 1)))), numArray2);
            this.engine.fpx.fpnegPRIME(numArray2[1]);
            this.engine.fpx.fp2mul_mont(numArray1, numArray2, numArray1);
          }
          else
            this.engine.fpx.fp2mul_mont(numArray1, CT, (uint) ((ulong) this.engine.param.NWORDS_FIELD * (ulong) (2L * ((long) ((j + index) * (ellw / 2U)) + (long) (D[(int) index] - 1)))), numArray1);
        }
      }
      this.Traverse_w_div_e_fullsigned(numArray1, j, k + z1, z - z1, P, CT, D, Dlen, ellw, w);
    }
    else
    {
      this.engine.fpx.fp2copy(r, numArray1);
      this.engine.fpx.fp2correction(numArray1);
      if (this.engine.fpx.is_felm_zero(numArray1[1]) && Fpx.subarrayEquals(numArray1[0], this.engine.param.Montgomery_one, this.engine.param.NWORDS_FIELD))
      {
        D[(int) k] = 0;
      }
      else
      {
        for (uint index = 1; index <= ellw / 2U; ++index)
        {
          if (!Fpx.subarrayEquals(numArray1, CT, this.engine.param.NWORDS_FIELD * (uint) (2 * (((int) Dlen - 1) * (int) (ellw / 2U) + ((int) index - 1))), 2U * this.engine.param.NWORDS_FIELD))
          {
            this.engine.fpx.fp2copy(CT, this.engine.param.NWORDS_FIELD * (uint) (2 * (((int) Dlen - 1) * (int) (ellw / 2U) + ((int) index - 1))), numArray2);
            this.engine.fpx.fpnegPRIME(numArray2[1]);
            this.engine.fpx.fpcorrectionPRIME(numArray2[1]);
            if (Fpx.subarrayEquals(numArray1, numArray2, 2U * this.engine.param.NWORDS_FIELD))
            {
              D[(int) k] = (int) index;
              break;
            }
          }
          else
          {
            D[(int) k] = -(int) index;
            break;
          }
        }
      }
    }
  }

  private void Tate3_pairings(PointProjFull[] Qj, ulong[][][] f)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray2 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray3 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray4 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray5 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray6 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray7 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray8 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[] numArray9 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[][][] numArray10 = SikeUtilities.InitArray(SidhCompressed.t_points, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] output = SikeUtilities.InitArray(2U * SidhCompressed.t_points, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][] a1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] a2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray11 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray12 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray13 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] a3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] b = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray14 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray15 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray16 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, a1[0]);
    for (uint index = 0; index < SidhCompressed.t_points; ++index)
    {
      this.engine.fpx.fp2copy(a1, f[(int) index]);
      this.engine.fpx.fp2copy(a1, f[(int) index + (int) SidhCompressed.t_points]);
      this.engine.fpx.fp2sqr_mont(Qj[(int) index].X, numArray10[(int) index]);
    }
    for (uint index1 = 0; index1 < this.engine.param.OBOB_EXPON - 1U; ++index1)
    {
      Array.Copy((Array) this.engine.param.T_tate3, (long) (this.engine.param.NWORDS_FIELD * (6U * index1)), (Array) numArray3, 0L, (long) this.engine.param.NWORDS_FIELD);
      Array.Copy((Array) this.engine.param.T_tate3, (long) (this.engine.param.NWORDS_FIELD * (uint) (6 * (int) index1 + 1)), (Array) numArray4, 0L, (long) this.engine.param.NWORDS_FIELD);
      Array.Copy((Array) this.engine.param.T_tate3, (long) (this.engine.param.NWORDS_FIELD * (uint) (6 * (int) index1 + 2)), (Array) numArray5, 0L, (long) this.engine.param.NWORDS_FIELD);
      Array.Copy((Array) this.engine.param.T_tate3, (long) (this.engine.param.NWORDS_FIELD * (uint) (6 * (int) index1 + 3)), (Array) numArray6, 0L, (long) this.engine.param.NWORDS_FIELD);
      Array.Copy((Array) this.engine.param.T_tate3, (long) (this.engine.param.NWORDS_FIELD * (uint) (6 * (int) index1 + 4)), (Array) numArray8, 0L, (long) this.engine.param.NWORDS_FIELD);
      Array.Copy((Array) this.engine.param.T_tate3, (long) (this.engine.param.NWORDS_FIELD * (uint) (6 * (int) index1 + 5)), (Array) numArray9, 0L, (long) this.engine.param.NWORDS_FIELD);
      for (uint index2 = 0; index2 < SidhCompressed.t_points; ++index2)
      {
        this.engine.fpx.fpmul_mont(Qj[(int) index2].X[0], numArray3, a2[0]);
        this.engine.fpx.fpmul_mont(Qj[(int) index2].X[1], numArray3, a2[1]);
        this.engine.fpx.fpmul_mont(Qj[(int) index2].X[0], numArray4, numArray12[0]);
        this.engine.fpx.fpmul_mont(Qj[(int) index2].X[1], numArray4, numArray12[1]);
        this.engine.fpx.fpaddPRIME(numArray10[(int) index2][0], numArray8, a3[0]);
        this.engine.fpx.fpcopy(numArray10[(int) index2][1], 0L, a3[1]);
        this.engine.fpx.fpmul_mont(Qj[(int) index2].X[0], numArray9, b[0]);
        this.engine.fpx.fpmul_mont(Qj[(int) index2].X[1], numArray9, b[1]);
        this.engine.fpx.fp2sub(a2, Qj[(int) index2].Y, numArray11);
        this.engine.fpx.fpaddPRIME(numArray11[0], numArray5, numArray11[0]);
        this.engine.fpx.fp2sub(numArray12, Qj[(int) index2].Y, numArray13);
        this.engine.fpx.fpaddPRIME(numArray13[0], numArray6, numArray13[0]);
        this.engine.fpx.fp2mul_mont(numArray11, numArray13, numArray14);
        this.engine.fpx.fp2sub(a3, b, numArray15);
        this.engine.fpx.fp2_conj(numArray15, numArray15);
        this.engine.fpx.fp2mul_mont(numArray14, numArray15, numArray14);
        this.engine.fpx.fp2sqr_mont(f[(int) index2], numArray16);
        this.engine.fpx.fp2mul_mont(f[(int) index2], numArray16, f[(int) index2]);
        this.engine.fpx.fp2mul_mont(f[(int) index2], numArray14, f[(int) index2]);
        this.engine.fpx.fpsubPRIME(a2[1], Qj[(int) index2].Y[0], numArray11[0]);
        this.engine.fpx.fpaddPRIME(a2[0], Qj[(int) index2].Y[1], numArray11[1]);
        this.engine.fpx.fpnegPRIME(numArray11[1]);
        this.engine.fpx.fpaddPRIME(numArray11[1], numArray5, numArray11[1]);
        this.engine.fpx.fpsubPRIME(numArray12[1], Qj[(int) index2].Y[0], numArray13[0]);
        this.engine.fpx.fpaddPRIME(numArray12[0], Qj[(int) index2].Y[1], numArray13[1]);
        this.engine.fpx.fpnegPRIME(numArray13[1]);
        this.engine.fpx.fpaddPRIME(numArray13[1], numArray6, numArray13[1]);
        this.engine.fpx.fp2mul_mont(numArray11, numArray13, numArray14);
        this.engine.fpx.fp2add(a3, b, numArray15);
        this.engine.fpx.fp2_conj(numArray15, numArray15);
        this.engine.fpx.fp2mul_mont(numArray14, numArray15, numArray14);
        this.engine.fpx.fp2sqr_mont(f[(int) index2 + (int) SidhCompressed.t_points], numArray16);
        this.engine.fpx.fp2mul_mont(f[(int) index2 + (int) SidhCompressed.t_points], numArray16, f[(int) index2 + (int) SidhCompressed.t_points]);
        this.engine.fpx.fp2mul_mont(f[(int) index2 + (int) SidhCompressed.t_points], numArray14, f[(int) index2 + (int) SidhCompressed.t_points]);
      }
    }
    for (uint index = 0; index < SidhCompressed.t_points; ++index)
    {
      Array.Copy((Array) this.engine.param.T_tate3, (long) (this.engine.param.NWORDS_FIELD * (uint) (6 * ((int) this.engine.param.OBOB_EXPON - 1))), (Array) numArray1, 0L, (long) this.engine.param.NWORDS_FIELD);
      Array.Copy((Array) this.engine.param.T_tate3, (long) (this.engine.param.NWORDS_FIELD * (uint) (6 * ((int) this.engine.param.OBOB_EXPON - 1) + 1)), (Array) numArray2, 0L, (long) this.engine.param.NWORDS_FIELD);
      Array.Copy((Array) this.engine.param.T_tate3, (long) (this.engine.param.NWORDS_FIELD * (uint) (6 * ((int) this.engine.param.OBOB_EXPON - 1) + 2)), (Array) numArray3, 0L, (long) this.engine.param.NWORDS_FIELD);
      Array.Copy((Array) this.engine.param.T_tate3, (long) (this.engine.param.NWORDS_FIELD * (uint) (6 * ((int) this.engine.param.OBOB_EXPON - 1) + 3)), (Array) numArray7, 0L, (long) this.engine.param.NWORDS_FIELD);
      this.engine.fpx.fpsubPRIME(Qj[(int) index].X[0], numArray1, a2[0]);
      this.engine.fpx.fpcopy(Qj[(int) index].X[1], 0L, a2[1]);
      this.engine.fpx.fpmul_mont(numArray3, a2[0], numArray11[0]);
      this.engine.fpx.fpmul_mont(numArray3, a2[1], numArray11[1]);
      this.engine.fpx.fp2sub(numArray11, Qj[(int) index].Y, numArray12);
      this.engine.fpx.fpaddPRIME(numArray12[0], numArray2, numArray12[0]);
      this.engine.fpx.fp2mul_mont(a2, numArray12, numArray14);
      this.engine.fpx.fpsubPRIME(Qj[(int) index].X[0], numArray7, numArray15[0]);
      this.engine.fpx.fpcopy(Qj[(int) index].X[1], 0L, numArray15[1]);
      this.engine.fpx.fpnegPRIME(numArray15[1]);
      this.engine.fpx.fp2mul_mont(numArray14, numArray15, numArray14);
      this.engine.fpx.fp2sqr_mont(f[(int) index], numArray16);
      this.engine.fpx.fp2mul_mont(f[(int) index], numArray16, f[(int) index]);
      this.engine.fpx.fp2mul_mont(f[(int) index], numArray14, f[(int) index]);
      this.engine.fpx.fpaddPRIME(Qj[(int) index].X[0], numArray1, a2[0]);
      this.engine.fpx.fpmul_mont(numArray3, a2[0], numArray11[0]);
      this.engine.fpx.fpsubPRIME(Qj[(int) index].Y[0], numArray11[1], numArray12[0]);
      this.engine.fpx.fpaddPRIME(Qj[(int) index].Y[1], numArray11[0], numArray12[1]);
      this.engine.fpx.fpsubPRIME(numArray12[1], numArray2, numArray12[1]);
      this.engine.fpx.fp2mul_mont(a2, numArray12, numArray14);
      this.engine.fpx.fpaddPRIME(Qj[(int) index].X[0], numArray7, numArray15[0]);
      this.engine.fpx.fp2mul_mont(numArray14, numArray15, numArray14);
      this.engine.fpx.fp2sqr_mont(f[(int) index + (int) SidhCompressed.t_points], numArray16);
      this.engine.fpx.fp2mul_mont(f[(int) index + (int) SidhCompressed.t_points], numArray16, f[(int) index + (int) SidhCompressed.t_points]);
      this.engine.fpx.fp2mul_mont(f[(int) index + (int) SidhCompressed.t_points], numArray14, f[(int) index + (int) SidhCompressed.t_points]);
    }
    this.engine.fpx.mont_n_way_inv(f, 2U * SidhCompressed.t_points, output);
    for (uint index = 0; index < 2U * SidhCompressed.t_points; ++index)
      this.final_exponentiation_3_torsion(f[(int) index], output[(int) index], f[(int) index]);
  }

  private void final_exponentiation_3_torsion(ulong[][] f, ulong[][] finv, ulong[][] fout)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray1);
    this.engine.fpx.fp2_conj(f, numArray2);
    this.engine.fpx.fp2mul_mont(numArray2, finv, numArray2);
    for (uint index = 0; index < this.engine.param.OALICE_BITS; ++index)
      this.engine.fpx.sqr_Fp2_cycl(numArray2, numArray1);
    this.engine.fpx.fp2copy(numArray2, fout);
  }

  private void Tate2_pairings(PointProj P, PointProj Q, PointProjFull[] Qj, ulong[][][] f)
  {
    ulong[][][] output = SikeUtilities.InitArray(2U * SidhCompressed.t_points, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][] a1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] a2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] b1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, a1[0]);
    for (uint index = 0; index < SidhCompressed.t_points; ++index)
    {
      this.engine.fpx.fp2copy(a1, f[(int) index]);
      this.engine.fpx.fp2copy(a1, f[(int) index + (int) SidhCompressed.t_points]);
    }
    ulong[][] x1 = P.X;
    ulong[][] z1 = P.Z;
    uint bOffset1 = 0;
    ulong[] tTate2FirststepP1 = this.engine.param.T_tate2_firststep_P;
    ulong[] tTate2FirststepP2 = this.engine.param.T_tate2_firststep_P;
    this.engine.fpx.fpcopy(this.engine.param.T_tate2_firststep_P, (long) (2U * this.engine.param.NWORDS_FIELD), a2[0]);
    this.engine.fpx.fpcopy(this.engine.param.T_tate2_firststep_P, (long) (3U * this.engine.param.NWORDS_FIELD), a2[1]);
    for (uint index = 0; index < SidhCompressed.t_points; ++index)
    {
      this.engine.fpx.fp2sub(Qj[(int) index].X, x1, numArray1);
      this.engine.fpx.fp2sub(Qj[(int) index].Y, z1, numArray2);
      this.engine.fpx.fp2mul_mont(a2, numArray1, numArray1);
      this.engine.fpx.fp2sub(numArray1, numArray2, numArray3);
      this.engine.fpx.fpsubPRIME(Qj[(int) index].X[0], this.engine.param.T_tate2_firststep_P, bOffset1, b1[0]);
      this.engine.fpx.fpcopy(Qj[(int) index].X[1], 0L, b1[1]);
      this.engine.fpx.fpnegPRIME(b1[1]);
      this.engine.fpx.fp2mul_mont(numArray3, b1, numArray3);
      this.engine.fpx.fp2sqr_mont(f[(int) index], f[(int) index]);
      this.engine.fpx.fp2mul_mont(f[(int) index], numArray3, f[(int) index]);
    }
    uint num1 = 0;
    uint bOffset2 = this.engine.param.NWORDS_FIELD;
    ulong[] numArray4 = tTate2FirststepP1;
    ulong[] b2 = tTate2FirststepP2;
    for (uint index1 = 0; index1 < this.engine.param.OALICE_BITS - 2U; ++index1)
    {
      ulong[] tTate2P1 = this.engine.param.T_tate2_P;
      ulong[] tTate2P2 = this.engine.param.T_tate2_P;
      ulong[] tTate2P3 = this.engine.param.T_tate2_P;
      uint bOffset3 = this.engine.param.NWORDS_FIELD * (3U * index1);
      uint num2 = this.engine.param.NWORDS_FIELD * (uint) (3 * (int) index1 + 1);
      uint maOffset = this.engine.param.NWORDS_FIELD * (uint) (3 * (int) index1 + 2);
      for (uint index2 = 0; index2 < SidhCompressed.t_points; ++index2)
      {
        this.engine.fpx.fpsubPRIME(numArray4, num1, Qj[(int) index2].X[0], numArray1[1]);
        this.engine.fpx.fpmul_mont(tTate2P3, maOffset, numArray1[1], numArray1[1]);
        this.engine.fpx.fpmul_mont(tTate2P3, maOffset, Qj[(int) index2].X[1], numArray1[0]);
        this.engine.fpx.fpsubPRIME(Qj[(int) index2].Y[1], b2, bOffset2, numArray2[1]);
        this.engine.fpx.fpsubPRIME(numArray1[1], numArray2[1], numArray3[1]);
        this.engine.fpx.fpsubPRIME(numArray1[0], Qj[(int) index2].Y[0], numArray3[0]);
        this.engine.fpx.fpsubPRIME(Qj[(int) index2].X[0], tTate2P1, bOffset3, b1[0]);
        this.engine.fpx.fpcopy(Qj[(int) index2].X[1], 0L, b1[1]);
        this.engine.fpx.fpnegPRIME(b1[1]);
        this.engine.fpx.fp2mul_mont(numArray3, b1, numArray3);
        this.engine.fpx.fp2sqr_mont(f[(int) index2], f[(int) index2]);
        this.engine.fpx.fp2mul_mont(f[(int) index2], numArray3, f[(int) index2]);
      }
      numArray4 = tTate2P1;
      b2 = tTate2P2;
      bOffset2 = num2;
      num1 = bOffset3;
    }
    for (uint index = 0; index < SidhCompressed.t_points; ++index)
    {
      this.engine.fpx.fpsubPRIME(Qj[(int) index].X[0], numArray4, num1, numArray3[0]);
      this.engine.fpx.fpcopy(Qj[(int) index].X[1], 0L, numArray3[1]);
      this.engine.fpx.fp2sqr_mont(f[(int) index], f[(int) index]);
      this.engine.fpx.fp2mul_mont(f[(int) index], numArray3, f[(int) index]);
    }
    ulong[][] x2 = Q.X;
    ulong[][] z2 = Q.Z;
    ulong[] tTate2FirststepQ1 = this.engine.param.T_tate2_firststep_Q;
    ulong[] tTate2FirststepQ2 = this.engine.param.T_tate2_firststep_Q;
    uint bOffset4 = 0;
    uint nwordsField = this.engine.param.NWORDS_FIELD;
    this.engine.fpx.fpcopy(this.engine.param.T_tate2_firststep_Q, (long) (2U * this.engine.param.NWORDS_FIELD), a2[0]);
    this.engine.fpx.fpcopy(this.engine.param.T_tate2_firststep_Q, (long) (3U * this.engine.param.NWORDS_FIELD), a2[1]);
    for (uint index = 0; index < SidhCompressed.t_points; ++index)
    {
      this.engine.fpx.fp2sub(Qj[(int) index].X, x2, numArray1);
      this.engine.fpx.fp2sub(Qj[(int) index].Y, z2, numArray2);
      this.engine.fpx.fp2mul_mont(a2, numArray1, numArray1);
      this.engine.fpx.fp2sub(numArray1, numArray2, numArray3);
      this.engine.fpx.fpsubPRIME(Qj[(int) index].X[0], tTate2FirststepQ1, bOffset4, b1[0]);
      this.engine.fpx.fpcopy(Qj[(int) index].X[1], 0L, b1[1]);
      this.engine.fpx.fpnegPRIME(b1[1]);
      this.engine.fpx.fp2mul_mont(numArray3, b1, numArray3);
      this.engine.fpx.fp2sqr_mont(f[(int) index + (int) SidhCompressed.t_points], f[(int) index + (int) SidhCompressed.t_points]);
      this.engine.fpx.fp2mul_mont(f[(int) index + (int) SidhCompressed.t_points], numArray3, f[(int) index + (int) SidhCompressed.t_points]);
    }
    ulong[] b3 = tTate2FirststepQ1;
    ulong[] b4 = tTate2FirststepQ2;
    uint bOffset5 = nwordsField;
    uint bOffset6 = bOffset4;
    for (uint index3 = 0; index3 < this.engine.param.OALICE_BITS - 2U; ++index3)
    {
      ulong[] tTate2Q1 = this.engine.param.T_tate2_Q;
      ulong[] tTate2Q2 = this.engine.param.T_tate2_Q;
      ulong[] tTate2Q3 = this.engine.param.T_tate2_Q;
      uint bOffset7 = this.engine.param.NWORDS_FIELD * (3U * index3);
      uint num3 = this.engine.param.NWORDS_FIELD * (uint) (3 * (int) index3 + 1);
      uint maOffset = this.engine.param.NWORDS_FIELD * (uint) (3 * (int) index3 + 2);
      for (uint index4 = 0; index4 < SidhCompressed.t_points; ++index4)
      {
        this.engine.fpx.fpsubPRIME(Qj[(int) index4].X[0], b3, bOffset6, numArray1[0]);
        this.engine.fpx.fpmul_mont(tTate2Q3, maOffset, numArray1[0], numArray1[0]);
        this.engine.fpx.fpmul_mont(tTate2Q3, maOffset, Qj[(int) index4].X[1], numArray1[1]);
        this.engine.fpx.fpsubPRIME(Qj[(int) index4].Y[0], b4, bOffset5, numArray2[0]);
        this.engine.fpx.fpsubPRIME(numArray1[0], numArray2[0], numArray3[0]);
        this.engine.fpx.fpsubPRIME(numArray1[1], Qj[(int) index4].Y[1], numArray3[1]);
        this.engine.fpx.fpsubPRIME(Qj[(int) index4].X[0], tTate2Q1, bOffset7, b1[0]);
        this.engine.fpx.fpcopy(Qj[(int) index4].X[1], 0L, b1[1]);
        this.engine.fpx.fpnegPRIME(b1[1]);
        this.engine.fpx.fp2mul_mont(numArray3, b1, numArray3);
        this.engine.fpx.fp2sqr_mont(f[(int) index4 + (int) SidhCompressed.t_points], f[(int) index4 + (int) SidhCompressed.t_points]);
        this.engine.fpx.fp2mul_mont(f[(int) index4 + (int) SidhCompressed.t_points], numArray3, f[(int) index4 + (int) SidhCompressed.t_points]);
      }
      b3 = tTate2Q1;
      b4 = tTate2Q2;
      bOffset5 = num3;
      bOffset6 = bOffset7;
    }
    for (uint index = 0; index < SidhCompressed.t_points; ++index)
    {
      this.engine.fpx.fpsubPRIME(Qj[(int) index].X[0], b3, bOffset6, numArray3[0]);
      this.engine.fpx.fpcopy(Qj[(int) index].X[1], 0L, numArray3[1]);
      this.engine.fpx.fp2sqr_mont(f[(int) index + (int) SidhCompressed.t_points], f[(int) index + (int) SidhCompressed.t_points]);
      this.engine.fpx.fp2mul_mont(f[(int) index + (int) SidhCompressed.t_points], numArray3, f[(int) index + (int) SidhCompressed.t_points]);
    }
    this.engine.fpx.mont_n_way_inv(f, 2U * SidhCompressed.t_points, output);
    for (uint index = 0; index < 2U * SidhCompressed.t_points; ++index)
      this.final_exponentiation_2_torsion(f[(int) index], output[(int) index], f[(int) index]);
  }

  private void final_exponentiation_2_torsion(ulong[][] f, ulong[][] finv, ulong[][] fout)
  {
    ulong[] numArray1 = new ulong[(int) this.engine.param.NWORDS_FIELD];
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray1);
    this.engine.fpx.fp2_conj(f, numArray2);
    this.engine.fpx.fp2mul_mont(numArray2, finv, numArray2);
    for (uint index = 0; index < this.engine.param.OBOB_EXPON; ++index)
      this.engine.fpx.cube_Fp2_cycl(numArray2, numArray1);
    this.engine.fpx.fp2copy(numArray2, fout);
  }
}
