// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.Isogeny
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal sealed class Isogeny
{
  private readonly SikeEngine engine;

  internal Isogeny(SikeEngine engine) => this.engine = engine;

  internal void Double(PointProj P, PointProj Q, ulong[][] A24, uint k)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2copy(P.X, Q.X);
    this.engine.fpx.fp2copy(P.Z, Q.Z);
    for (int index = 0; (long) index < (long) k; ++index)
    {
      this.engine.fpx.fp2add(Q.X, Q.Z, numArray2);
      this.engine.fpx.fp2sub(Q.X, Q.Z, numArray3);
      this.engine.fpx.fp2sqr_mont(numArray2, numArray5);
      this.engine.fpx.fp2sqr_mont(numArray3, numArray6);
      this.engine.fpx.fp2sub(numArray5, numArray6, numArray4);
      this.engine.fpx.fp2mul_mont(numArray5, numArray6, Q.X);
      this.engine.fpx.fp2mul_mont(A24, numArray4, numArray1);
      this.engine.fpx.fp2add(numArray1, numArray6, numArray1);
      this.engine.fpx.fp2mul_mont(numArray4, numArray1, Q.Z);
    }
  }

  internal void CompleteMPoint(ulong[][] A, PointProj P, PointProjFull R)
  {
    ulong[][] a1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] a2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray7 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, a2[0]);
    if (Fpx.subarrayEquals(P.Z[0], a1[0], this.engine.param.NWORDS_FIELD) && Fpx.subarrayEquals(P.Z[1], a1[1], this.engine.param.NWORDS_FIELD))
    {
      this.engine.fpx.fp2copy(a1, R.X);
      this.engine.fpx.fp2copy(a2, R.Y);
      this.engine.fpx.fp2copy(a1, R.Z);
    }
    else
    {
      this.engine.fpx.fp2mul_mont(P.X, P.Z, numArray1);
      this.engine.fpx.fpsubPRIME(P.X[0], P.Z[1], numArray6[0]);
      this.engine.fpx.fpaddPRIME(P.X[1], P.Z[0], numArray6[1]);
      this.engine.fpx.fpaddPRIME(P.X[0], P.Z[1], numArray7[0]);
      this.engine.fpx.fpsubPRIME(P.X[1], P.Z[0], numArray7[1]);
      this.engine.fpx.fp2mul_mont(numArray6, numArray7, numArray3);
      this.engine.fpx.fp2mul_mont(A, numArray1, numArray6);
      this.engine.fpx.fp2add(numArray6, numArray3, numArray7);
      this.engine.fpx.fp2mul_mont(numArray1, numArray7, numArray4);
      this.engine.fpx.sqrt_Fp2(numArray4, numArray2);
      this.engine.fpx.fp2copy(P.Z, numArray5);
      this.engine.fpx.fp2inv_mont_bingcd(numArray5);
      this.engine.fpx.fp2mul_mont(P.X, numArray5, R.X);
      this.engine.fpx.fp2sqr_mont(numArray5, numArray6);
      this.engine.fpx.fp2mul_mont(numArray2, numArray6, R.Y);
      this.engine.fpx.fp2copy(a2, R.Z);
    }
  }

  internal void Ladder(PointProj P, ulong[] m, ulong[][] A, uint order_bits, PointProj R)
  {
    PointProj P1 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj Q = new PointProj(this.engine.param.NWORDS_FIELD);
    ulong[][] numArray = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    int num1 = 0;
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray[0]);
    this.engine.fpx.fpaddPRIME(numArray[0], numArray[0], numArray[0]);
    this.engine.fpx.fp2add(A, numArray, numArray);
    this.engine.fpx.fp2div2(numArray, numArray);
    this.engine.fpx.fp2div2(numArray, numArray);
    int num2 = (int) order_bits - 1;
    for (uint index = (uint) (m[num2 >> (int) Internal.LOG2RADIX] >> (int) ((long) num2 & (long) (Internal.RADIX - 1U)) & 1UL); index == 0U; index = (uint) (m[num2 >> (int) Internal.LOG2RADIX] >> (int) ((long) num2 & (long) (Internal.RADIX - 1U)) & 1UL))
      --num2;
    this.engine.fpx.fp2copy(P.X, P1.X);
    this.engine.fpx.fp2copy(P.Z, P1.Z);
    this.XDblE(P, Q, numArray, 1);
    for (int index = num2 - 1; index >= 0; --index)
    {
      uint num3 = (uint) (m[index >> (int) Internal.LOG2RADIX] >> (int) ((long) index & (long) (Internal.RADIX - 1U)) & 1UL);
      int num4 = (int) ((long) num3 ^ (long) num1);
      num1 = (int) num3;
      ulong option = (ulong) -num4;
      this.SwapPoints(P1, Q, option);
      this.XDblAddProj(P1, Q, P.X, P.Z, numArray);
    }
    ulong option1 = (ulong) -(0 ^ num1);
    this.SwapPoints(P1, Q, option1);
    this.engine.fpx.fp2copy(P1.X, R.X);
    this.engine.fpx.fp2copy(P1.Z, R.Z);
  }

  private void XDblAddProj(PointProj P, PointProj Q, ulong[][] XPQ, ulong[][] ZPQ, ulong[][] A24)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2add(P.X, P.Z, numArray1);
    this.engine.fpx.fp2sub(P.X, P.Z, numArray2);
    this.engine.fpx.fp2sqr_mont(numArray1, P.X);
    this.engine.fpx.fp2sub(Q.X, Q.Z, numArray3);
    this.engine.fpx.fp2correction(numArray3);
    this.engine.fpx.fp2add(Q.X, Q.Z, Q.X);
    this.engine.fpx.fp2mul_mont(numArray1, numArray3, numArray1);
    this.engine.fpx.fp2sqr_mont(numArray2, P.Z);
    this.engine.fpx.fp2mul_mont(numArray2, Q.X, numArray2);
    this.engine.fpx.fp2sub(P.X, P.Z, numArray3);
    this.engine.fpx.fp2mul_mont(P.X, P.Z, P.X);
    this.engine.fpx.fp2mul_mont(numArray3, A24, Q.X);
    this.engine.fpx.fp2sub(numArray1, numArray2, Q.Z);
    this.engine.fpx.fp2add(Q.X, P.Z, P.Z);
    this.engine.fpx.fp2add(numArray1, numArray2, Q.X);
    this.engine.fpx.fp2mul_mont(P.Z, numArray3, P.Z);
    this.engine.fpx.fp2sqr_mont(Q.Z, Q.Z);
    this.engine.fpx.fp2sqr_mont(Q.X, Q.X);
    this.engine.fpx.fp2mul_mont(Q.X, ZPQ, Q.X);
    this.engine.fpx.fp2mul_mont(Q.Z, XPQ, Q.Z);
  }

  private void XDblE(PointProj P, PointProj Q, ulong[][] A24, int e)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2copy(P.X, Q.X);
    this.engine.fpx.fp2copy(P.Z, Q.Z);
    for (int index = 0; index < e; ++index)
    {
      this.engine.fpx.fp2add(Q.X, Q.Z, numArray2);
      this.engine.fpx.fp2sub(Q.X, Q.Z, numArray3);
      this.engine.fpx.fp2sqr_mont(numArray2, numArray5);
      this.engine.fpx.fp2sqr_mont(numArray3, numArray6);
      this.engine.fpx.fp2sub(numArray5, numArray6, numArray4);
      this.engine.fpx.fp2mul_mont(numArray5, numArray6, Q.X);
      this.engine.fpx.fp2mul_mont(A24, numArray4, numArray1);
      this.engine.fpx.fp2add(numArray1, numArray6, numArray1);
      this.engine.fpx.fp2mul_mont(numArray4, numArray1, Q.Z);
    }
  }

  internal void XTplEFast(PointProj P, PointProj Q, ulong[][] A2, uint e)
  {
    PointProj pointProj = new PointProj(this.engine.param.NWORDS_FIELD);
    this.engine.fpx.copy_words(P, pointProj);
    for (int index = 0; (long) index < (long) e; ++index)
      this.XTplFast(pointProj, pointProj, A2);
    this.engine.fpx.copy_words(pointProj, Q);
  }

  private void XTplFast(PointProj P, PointProj Q, ulong[][] A2)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2sqr_mont(P.X, numArray1);
    this.engine.fpx.fp2sqr_mont(P.Z, numArray2);
    this.engine.fpx.fp2add(numArray1, numArray2, numArray3);
    this.engine.fpx.fp2add(P.X, P.Z, numArray4);
    this.engine.fpx.fp2sqr_mont(numArray4, numArray4);
    this.engine.fpx.fp2sub(numArray4, numArray3, numArray4);
    this.engine.fpx.fp2mul_mont(A2, numArray4, numArray4);
    this.engine.fpx.fp2add(numArray3, numArray4, numArray4);
    this.engine.fpx.fp2sub(numArray1, numArray2, numArray3);
    this.engine.fpx.fp2sqr_mont(numArray3, numArray3);
    this.engine.fpx.fp2mul_mont(numArray1, numArray4, numArray1);
    this.engine.fpx.fp2shl(numArray1, 2U, numArray1);
    this.engine.fpx.fp2sub(numArray1, numArray3, numArray1);
    this.engine.fpx.fp2sqr_mont(numArray1, numArray1);
    this.engine.fpx.fp2mul_mont(numArray2, numArray4, numArray2);
    this.engine.fpx.fp2shl(numArray2, 2U, numArray2);
    this.engine.fpx.fp2sub(numArray2, numArray3, numArray2);
    this.engine.fpx.fp2sqr_mont(numArray2, numArray2);
    this.engine.fpx.fp2mul_mont(P.X, numArray2, Q.X);
    this.engine.fpx.fp2mul_mont(P.Z, numArray1, Q.Z);
  }

  internal void LADDER3PT(
    ulong[][] xP,
    ulong[][] xQ,
    ulong[][] xPQ,
    ulong[] m,
    uint AliceOrBob,
    PointProj R,
    ulong[][] A)
  {
    PointProj P = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj Q = new PointProj(this.engine.param.NWORDS_FIELD);
    ulong[][] numArray = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    uint num1 = 0;
    uint num2 = (int) AliceOrBob != (int) this.engine.param.ALICE ? this.engine.param.OBOB_BITS - 1U : this.engine.param.OALICE_BITS;
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray[0]);
    this.engine.fpx.mp2_add(numArray, numArray, numArray);
    this.engine.fpx.mp2_add(A, numArray, numArray);
    this.engine.fpx.fp2div2(numArray, numArray);
    this.engine.fpx.fp2div2(numArray, numArray);
    this.engine.fpx.fp2copy(xQ, P.X);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, P.Z[0]);
    this.engine.fpx.fp2copy(xPQ, Q.X);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, Q.Z[0]);
    this.engine.fpx.fp2copy(xP, R.X);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, R.Z[0]);
    this.engine.fpx.fpzero(R.Z[1]);
    for (uint index = 0; index < num2; ++index)
    {
      int num3 = (int) (uint) (m[(int) (index >> (int) Internal.LOG2RADIX)] >> ((int) index & (int) Internal.RADIX - 1) & 1UL);
      uint num4 = (uint) num3 ^ num1;
      num1 = (uint) num3;
      ulong option = (ulong) -num4;
      this.SwapPoints(R, Q, option);
      this.XDblAdd(P, Q, R.X, numArray);
      this.engine.fpx.fp2mul_mont(Q.X, R.Z, Q.X);
    }
    ulong option1 = (ulong) -(0U ^ num1);
    this.SwapPoints(R, Q, option1);
  }

  internal void CompletePoint(PointProj P, PointProjFull R)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] b = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] a = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, a[0]);
    this.engine.fpx.fp2mul_mont(P.X, P.Z, numArray1);
    this.engine.fpx.fpsubPRIME(P.X[0], P.Z[1], numArray6[0]);
    this.engine.fpx.fpaddPRIME(P.X[1], P.Z[0], numArray6[1]);
    this.engine.fpx.fpaddPRIME(P.X[0], P.Z[1], b[0]);
    this.engine.fpx.fpsubPRIME(P.X[1], P.Z[0], b[1]);
    this.engine.fpx.fp2mul_mont(numArray6, b, numArray2);
    this.engine.fpx.fp2mul_mont(numArray1, numArray2, numArray3);
    this.engine.fpx.sqrt_Fp2(numArray3, numArray4);
    this.engine.fpx.fp2copy(P.Z, numArray5);
    this.engine.fpx.fp2inv_mont_bingcd(numArray5);
    this.engine.fpx.fp2mul_mont(P.X, numArray5, R.X);
    this.engine.fpx.fp2sqr_mont(numArray5, numArray6);
    this.engine.fpx.fp2mul_mont(numArray4, numArray6, R.Y);
    this.engine.fpx.fp2copy(a, R.Z);
  }

  internal void SwapPoints(PointProj P, PointProj Q, ulong option)
  {
    for (int index = 0; (long) index < (long) this.engine.param.NWORDS_FIELD; ++index)
    {
      ulong num1 = option & (P.X[0][index] ^ Q.X[0][index]);
      P.X[0][index] = num1 ^ P.X[0][index];
      Q.X[0][index] = num1 ^ Q.X[0][index];
      ulong num2 = option & (P.X[1][index] ^ Q.X[1][index]);
      P.X[1][index] = num2 ^ P.X[1][index];
      Q.X[1][index] = num2 ^ Q.X[1][index];
      ulong num3 = option & (P.Z[0][index] ^ Q.Z[0][index]);
      P.Z[0][index] = num3 ^ P.Z[0][index];
      Q.Z[0][index] = num3 ^ Q.Z[0][index];
      ulong num4 = option & (P.Z[1][index] ^ Q.Z[1][index]);
      P.Z[1][index] = num4 ^ P.Z[1][index];
      Q.Z[1][index] = num4 ^ Q.Z[1][index];
    }
  }

  internal void XDblAdd(PointProj P, PointProj Q, ulong[][] xPQ, ulong[][] A24)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.mp2_add(P.X, P.Z, numArray1);
    this.engine.fpx.mp2_sub_p2(P.X, P.Z, numArray2);
    this.engine.fpx.fp2sqr_mont(numArray1, P.X);
    this.engine.fpx.mp2_sub_p2(Q.X, Q.Z, numArray3);
    this.engine.fpx.mp2_add(Q.X, Q.Z, Q.X);
    this.engine.fpx.fp2mul_mont(numArray1, numArray3, numArray1);
    this.engine.fpx.fp2sqr_mont(numArray2, P.Z);
    this.engine.fpx.fp2mul_mont(numArray2, Q.X, numArray2);
    this.engine.fpx.mp2_sub_p2(P.X, P.Z, numArray3);
    this.engine.fpx.fp2mul_mont(P.X, P.Z, P.X);
    this.engine.fpx.fp2mul_mont(A24, numArray3, Q.X);
    this.engine.fpx.mp2_sub_p2(numArray1, numArray2, Q.Z);
    this.engine.fpx.mp2_add(Q.X, P.Z, P.Z);
    this.engine.fpx.mp2_add(numArray1, numArray2, Q.X);
    this.engine.fpx.fp2mul_mont(P.Z, numArray3, P.Z);
    this.engine.fpx.fp2sqr_mont(Q.Z, Q.Z);
    this.engine.fpx.fp2sqr_mont(Q.X, Q.X);
    this.engine.fpx.fp2mul_mont(Q.Z, xPQ, Q.Z);
  }

  internal void XDblE(PointProj P, PointProj Q, ulong[][] A24plus, ulong[][] C24, uint e)
  {
    this.engine.fpx.copy_words(P, Q);
    for (int index = 0; (long) index < (long) e; ++index)
      this.XDbl(Q, Q, A24plus, C24);
  }

  internal void XDbl(PointProj P, PointProj Q, ulong[][] A24plus, ulong[][] C24)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.mp2_sub_p2(P.X, P.Z, numArray1);
    this.engine.fpx.mp2_add(P.X, P.Z, numArray2);
    this.engine.fpx.fp2sqr_mont(numArray1, numArray1);
    this.engine.fpx.fp2sqr_mont(numArray2, numArray2);
    this.engine.fpx.fp2mul_mont(C24, numArray1, Q.Z);
    this.engine.fpx.fp2mul_mont(numArray2, Q.Z, Q.X);
    this.engine.fpx.mp2_sub_p2(numArray2, numArray1, numArray2);
    this.engine.fpx.fp2mul_mont(A24plus, numArray2, numArray1);
    this.engine.fpx.mp2_add(Q.Z, numArray1, Q.Z);
    this.engine.fpx.fp2mul_mont(Q.Z, numArray2, Q.Z);
  }

  private void XTpl(PointProj P, PointProj Q, ulong[][] A24minus, ulong[][] A24plus)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray7 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.mp2_sub_p2(P.X, P.Z, numArray1);
    this.engine.fpx.fp2sqr_mont(numArray1, numArray3);
    this.engine.fpx.mp2_add(P.X, P.Z, numArray2);
    this.engine.fpx.fp2sqr_mont(numArray2, numArray4);
    this.engine.fpx.mp2_add(P.X, P.X, numArray5);
    this.engine.fpx.mp2_add(P.Z, P.Z, numArray1);
    this.engine.fpx.fp2sqr_mont(numArray5, numArray2);
    this.engine.fpx.mp2_sub_p2(numArray2, numArray4, numArray2);
    this.engine.fpx.mp2_sub_p2(numArray2, numArray3, numArray2);
    this.engine.fpx.fp2mul_mont(A24plus, numArray4, numArray6);
    this.engine.fpx.fp2mul_mont(numArray4, numArray6, numArray4);
    this.engine.fpx.fp2mul_mont(A24minus, numArray3, numArray7);
    this.engine.fpx.fp2mul_mont(numArray3, numArray7, numArray3);
    this.engine.fpx.mp2_sub_p2(numArray3, numArray4, numArray4);
    this.engine.fpx.mp2_sub_p2(numArray6, numArray7, numArray3);
    this.engine.fpx.fp2mul_mont(numArray2, numArray3, numArray2);
    this.engine.fpx.fp2add(numArray4, numArray2, numArray3);
    this.engine.fpx.fp2sqr_mont(numArray3, numArray3);
    this.engine.fpx.fp2mul_mont(numArray5, numArray3, Q.X);
    this.engine.fpx.fp2sub(numArray4, numArray2, numArray2);
    this.engine.fpx.fp2sqr_mont(numArray2, numArray2);
    this.engine.fpx.fp2mul_mont(numArray1, numArray2, Q.Z);
  }

  internal void XTplE(PointProj P, PointProj Q, ulong[][] A24minus, ulong[][] A24plus, uint e)
  {
    this.engine.fpx.copy_words(P, Q);
    for (int index = 0; (long) index < (long) e; ++index)
      this.XTpl(Q, Q, A24minus, A24plus);
  }

  internal void GetA(ulong[][] xP, ulong[][] xQ, ulong[][] xR, ulong[][] A)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] b = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, b[0]);
    this.engine.fpx.fp2add(xP, xQ, numArray2);
    this.engine.fpx.fp2mul_mont(xP, xQ, numArray1);
    this.engine.fpx.fp2mul_mont(xR, numArray2, A);
    this.engine.fpx.fp2add(numArray1, A, A);
    this.engine.fpx.fp2mul_mont(numArray1, xR, numArray1);
    this.engine.fpx.fp2sub(A, b, A);
    this.engine.fpx.fp2add(numArray1, numArray1, numArray1);
    this.engine.fpx.fp2add(numArray2, xR, numArray2);
    this.engine.fpx.fp2add(numArray1, numArray1, numArray1);
    this.engine.fpx.fp2sqr_mont(A, A);
    this.engine.fpx.fp2inv_mont(numArray1);
    this.engine.fpx.fp2mul_mont(A, numArray1, A);
    this.engine.fpx.fp2sub(A, numArray2, A);
  }

  internal void JInv(ulong[][] A, ulong[][] C, ulong[][] jinv)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2sqr_mont(A, jinv);
    this.engine.fpx.fp2sqr_mont(C, numArray2);
    this.engine.fpx.fp2add(numArray2, numArray2, numArray1);
    this.engine.fpx.fp2sub(jinv, numArray1, numArray1);
    this.engine.fpx.fp2sub(numArray1, numArray2, numArray1);
    this.engine.fpx.fp2sub(numArray1, numArray2, jinv);
    this.engine.fpx.fp2sqr_mont(numArray2, numArray2);
    this.engine.fpx.fp2mul_mont(jinv, numArray2, jinv);
    this.engine.fpx.fp2add(numArray1, numArray1, numArray1);
    this.engine.fpx.fp2add(numArray1, numArray1, numArray1);
    this.engine.fpx.fp2sqr_mont(numArray1, numArray2);
    this.engine.fpx.fp2mul_mont(numArray1, numArray2, numArray1);
    this.engine.fpx.fp2add(numArray1, numArray1, numArray1);
    this.engine.fpx.fp2add(numArray1, numArray1, numArray1);
    this.engine.fpx.fp2inv_mont(jinv);
    this.engine.fpx.fp2mul_mont(jinv, numArray1, jinv);
  }

  internal void Get3Isog(PointProj P, ulong[][] A24minus, ulong[][] A24plus, ulong[][][] coeff)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.mp2_sub_p2(P.X, P.Z, coeff[0]);
    this.engine.fpx.fp2sqr_mont(coeff[0], numArray1);
    this.engine.fpx.mp2_add(P.X, P.Z, coeff[1]);
    this.engine.fpx.fp2sqr_mont(coeff[1], numArray2);
    this.engine.fpx.mp2_add(P.X, P.X, numArray4);
    this.engine.fpx.fp2sqr_mont(numArray4, numArray4);
    this.engine.fpx.fp2sub(numArray4, numArray1, numArray3);
    this.engine.fpx.fp2sub(numArray4, numArray2, numArray4);
    this.engine.fpx.mp2_add(numArray1, numArray4, numArray5);
    this.engine.fpx.mp2_add(numArray5, numArray5, numArray5);
    this.engine.fpx.mp2_add(numArray2, numArray5, numArray5);
    this.engine.fpx.fp2mul_mont(numArray3, numArray5, A24minus);
    this.engine.fpx.mp2_add(numArray2, numArray3, numArray5);
    this.engine.fpx.mp2_add(numArray5, numArray5, numArray5);
    this.engine.fpx.mp2_add(numArray1, numArray5, numArray5);
    this.engine.fpx.fp2mul_mont(numArray4, numArray5, A24plus);
  }

  internal void Eval3Isog(PointProj Q, ulong[][][] coeff)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.mp2_add(Q.X, Q.Z, numArray1);
    this.engine.fpx.mp2_sub_p2(Q.X, Q.Z, numArray2);
    this.engine.fpx.fp2mul_mont(coeff[0], numArray1, numArray1);
    this.engine.fpx.fp2mul_mont(coeff[1], numArray2, numArray2);
    this.engine.fpx.mp2_add(numArray1, numArray2, numArray3);
    this.engine.fpx.mp2_sub_p2(numArray2, numArray1, numArray1);
    this.engine.fpx.fp2sqr_mont(numArray3, numArray3);
    this.engine.fpx.fp2sqr_mont(numArray1, numArray1);
    this.engine.fpx.fp2mul_mont(Q.X, numArray3, Q.X);
    this.engine.fpx.fp2mul_mont(Q.Z, numArray1, Q.Z);
  }

  internal void Inv3Way(ulong[][] z1, ulong[][] z2, ulong[][] z3)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.fp2mul_mont(z1, z2, numArray1);
    this.engine.fpx.fp2mul_mont(z3, numArray1, numArray2);
    this.engine.fpx.fp2inv_mont(numArray2);
    this.engine.fpx.fp2mul_mont(z3, numArray2, numArray3);
    this.engine.fpx.fp2mul_mont(numArray3, z2, numArray4);
    this.engine.fpx.fp2mul_mont(numArray3, z1, z2);
    this.engine.fpx.fp2mul_mont(numArray1, numArray2, z3);
    this.engine.fpx.fp2copy(numArray4, z1);
  }

  internal void Get2Isog(PointProj P, ulong[][] A, ulong[][] C)
  {
    this.engine.fpx.fp2sqr_mont(P.X, A);
    this.engine.fpx.fp2sqr_mont(P.Z, C);
    this.engine.fpx.mp2_sub_p2(C, A, A);
  }

  internal void Eval2Isog(PointProj P, PointProj Q)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.mp2_add(Q.X, Q.Z, numArray1);
    this.engine.fpx.mp2_sub_p2(Q.X, Q.Z, numArray2);
    this.engine.fpx.mp2_add(P.X, P.Z, numArray3);
    this.engine.fpx.mp2_sub_p2(P.X, P.Z, numArray4);
    this.engine.fpx.fp2mul_mont(numArray1, numArray4, numArray1);
    this.engine.fpx.fp2mul_mont(numArray2, numArray3, numArray2);
    this.engine.fpx.mp2_add(numArray1, numArray2, numArray3);
    this.engine.fpx.mp2_sub_p2(numArray1, numArray2, numArray4);
    this.engine.fpx.fp2mul_mont(P.X, numArray3, P.X);
    this.engine.fpx.fp2mul_mont(P.Z, numArray4, P.Z);
  }

  internal void Get4Isog(PointProj P, ulong[][] A24plus, ulong[][] C24, ulong[][][] coeff)
  {
    this.engine.fpx.mp2_sub_p2(P.X, P.Z, coeff[1]);
    this.engine.fpx.mp2_add(P.X, P.Z, coeff[2]);
    this.engine.fpx.fp2sqr_mont(P.Z, coeff[0]);
    this.engine.fpx.mp2_add(coeff[0], coeff[0], coeff[0]);
    this.engine.fpx.fp2sqr_mont(coeff[0], C24);
    this.engine.fpx.mp2_add(coeff[0], coeff[0], coeff[0]);
    this.engine.fpx.fp2sqr_mont(P.X, A24plus);
    this.engine.fpx.mp2_add(A24plus, A24plus, A24plus);
    this.engine.fpx.fp2sqr_mont(A24plus, A24plus);
  }

  internal void Eval4Isog(PointProj P, ulong[][][] coeff)
  {
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    this.engine.fpx.mp2_add(P.X, P.Z, numArray1);
    this.engine.fpx.mp2_sub_p2(P.X, P.Z, numArray2);
    this.engine.fpx.fp2mul_mont(numArray1, coeff[1], P.X);
    this.engine.fpx.fp2mul_mont(numArray2, coeff[2], P.Z);
    this.engine.fpx.fp2mul_mont(numArray1, numArray2, numArray1);
    this.engine.fpx.fp2mul_mont(coeff[0], numArray1, numArray1);
    this.engine.fpx.mp2_add(P.X, P.Z, numArray2);
    this.engine.fpx.mp2_sub_p2(P.X, P.Z, P.Z);
    this.engine.fpx.fp2sqr_mont(numArray2, numArray2);
    this.engine.fpx.fp2sqr_mont(P.Z, P.Z);
    this.engine.fpx.mp2_add(numArray2, numArray1, P.X);
    this.engine.fpx.mp2_sub_p2(P.Z, numArray1, numArray1);
    this.engine.fpx.fp2mul_mont(P.X, numArray2, P.X);
    this.engine.fpx.fp2mul_mont(P.Z, numArray1, P.Z);
  }
}
