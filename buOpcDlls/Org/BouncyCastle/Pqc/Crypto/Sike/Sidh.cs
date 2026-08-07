// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.Sidh
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal sealed class Sidh
{
  private readonly SikeEngine engine;

  internal Sidh(SikeEngine engine) => this.engine = engine;

  internal void init_basis(ulong[] gen, ulong[][] XP, ulong[][] XQ, ulong[][] XR)
  {
    this.engine.fpx.fpcopy(gen, 0L, XP[0]);
    this.engine.fpx.fpcopy(gen, (long) this.engine.param.NWORDS_FIELD, XP[1]);
    this.engine.fpx.fpcopy(gen, (long) (2U * this.engine.param.NWORDS_FIELD), XQ[0]);
    this.engine.fpx.fpcopy(gen, (long) (3U * this.engine.param.NWORDS_FIELD), XQ[1]);
    this.engine.fpx.fpcopy(gen, (long) (4U * this.engine.param.NWORDS_FIELD), XR[0]);
    this.engine.fpx.fpcopy(gen, (long) (5U * this.engine.param.NWORDS_FIELD), XR[1]);
  }

  internal void EphemeralKeyGeneration_B(byte[] sk, byte[] pk)
  {
    PointProj pointProj = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj Q1 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj Q2 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj Q3 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj[] pointProjArray = new PointProj[(int) this.engine.param.MAX_INT_POINTS_BOB];
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] coeff = SikeUtilities.InitArray(3U, 2U, this.engine.param.NWORDS_FIELD);
    uint index1 = 0;
    uint num1 = 0;
    uint[] numArray7 = new uint[(int) this.engine.param.MAX_INT_POINTS_BOB];
    ulong[] numArray8 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    this.init_basis(this.engine.param.B_gen, numArray1, numArray2, numArray3);
    this.init_basis(this.engine.param.A_gen, Q1.X, Q2.X, Q3.X);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, Q1.Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, Q2.Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, Q3.Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray4[0]);
    this.engine.fpx.mp2_add(numArray4, numArray4, numArray4);
    this.engine.fpx.mp2_add(numArray4, numArray4, numArray5);
    this.engine.fpx.mp2_add(numArray4, numArray5, numArray6);
    this.engine.fpx.mp2_add(numArray5, numArray5, numArray4);
    this.engine.fpx.decode_to_digits(sk, this.engine.param.MSG_BYTES, numArray8, this.engine.param.SECRETKEY_B_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.isogeny.LADDER3PT(numArray1, numArray2, numArray3, numArray8, this.engine.param.BOB, pointProj, numArray6);
    uint num2 = 0;
    for (uint index2 = 1; index2 < this.engine.param.MAX_Bob; ++index2)
    {
      uint e;
      for (; num2 < this.engine.param.MAX_Bob - index2; num2 += e)
      {
        pointProjArray[(int) index1] = new PointProj(this.engine.param.NWORDS_FIELD);
        this.engine.fpx.fp2copy(pointProj.X, pointProjArray[(int) index1].X);
        this.engine.fpx.fp2copy(pointProj.Z, pointProjArray[(int) index1].Z);
        numArray7[(int) index1++] = num2;
        e = this.engine.param.strat_Bob[(int) num1++];
        this.engine.isogeny.XTplE(pointProj, pointProj, numArray5, numArray4, e);
      }
      this.engine.isogeny.Get3Isog(pointProj, numArray5, numArray4, coeff);
      for (uint index3 = 0; index3 < index1; ++index3)
        this.engine.isogeny.Eval3Isog(pointProjArray[(int) index3], coeff);
      this.engine.isogeny.Eval3Isog(Q1, coeff);
      this.engine.isogeny.Eval3Isog(Q2, coeff);
      this.engine.isogeny.Eval3Isog(Q3, coeff);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].X, pointProj.X);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].Z, pointProj.Z);
      num2 = numArray7[(int) index1 - 1];
      --index1;
    }
    this.engine.isogeny.Get3Isog(pointProj, numArray5, numArray4, coeff);
    this.engine.isogeny.Eval3Isog(Q1, coeff);
    this.engine.isogeny.Eval3Isog(Q2, coeff);
    this.engine.isogeny.Eval3Isog(Q3, coeff);
    this.engine.isogeny.Inv3Way(Q1.Z, Q2.Z, Q3.Z);
    this.engine.fpx.fp2mul_mont(Q1.X, Q1.Z, Q1.X);
    this.engine.fpx.fp2mul_mont(Q2.X, Q2.Z, Q2.X);
    this.engine.fpx.fp2mul_mont(Q3.X, Q3.Z, Q3.X);
    this.engine.fpx.fp2_encode(Q1.X, pk, 0U);
    this.engine.fpx.fp2_encode(Q2.X, pk, this.engine.param.FP2_ENCODED_BYTES);
    this.engine.fpx.fp2_encode(Q3.X, pk, 2U * this.engine.param.FP2_ENCODED_BYTES);
  }

  internal void EphemeralKeyGeneration_A(byte[] ephemeralsk, byte[] ct)
  {
    PointProj pointProj1 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj P1 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj P2 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj P3 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj[] pointProjArray = new PointProj[(int) this.engine.param.MAX_INT_POINTS_ALICE];
    ulong[][] numArray1 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray6 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] coeff = SikeUtilities.InitArray(3U, 2U, this.engine.param.NWORDS_FIELD);
    uint index1 = 0;
    uint num1 = 0;
    uint[] numArray7 = new uint[(int) this.engine.param.MAX_INT_POINTS_ALICE];
    ulong[] numArray8 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    this.init_basis(this.engine.param.A_gen, numArray1, numArray2, numArray3);
    this.init_basis(this.engine.param.B_gen, P1.X, P2.X, P3.X);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, P1.Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, P2.Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, P3.Z[0]);
    this.engine.fpx.fpcopy(this.engine.param.Montgomery_one, 0L, numArray4[0]);
    this.engine.fpx.mp2_add(numArray4, numArray4, numArray4);
    this.engine.fpx.mp2_add(numArray4, numArray4, numArray5);
    this.engine.fpx.mp2_add(numArray4, numArray5, numArray6);
    this.engine.fpx.mp2_add(numArray5, numArray5, numArray4);
    this.engine.fpx.decode_to_digits(ephemeralsk, 0U, numArray8, this.engine.param.SECRETKEY_A_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.isogeny.LADDER3PT(numArray1, numArray2, numArray3, numArray8, this.engine.param.ALICE, pointProj1, numArray6);
    if (this.engine.param.OALICE_BITS % 2U == 1U)
    {
      PointProj pointProj2 = new PointProj(this.engine.param.NWORDS_FIELD);
      this.engine.isogeny.XDblE(pointProj1, pointProj2, numArray4, numArray5, this.engine.param.OALICE_BITS - 1U);
      this.engine.isogeny.Get2Isog(pointProj2, numArray4, numArray5);
      this.engine.isogeny.Eval2Isog(P1, pointProj2);
      this.engine.isogeny.Eval2Isog(P2, pointProj2);
      this.engine.isogeny.Eval2Isog(P3, pointProj2);
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
        numArray7[(int) index1++] = num2;
        num3 = this.engine.param.strat_Alice[(int) num1++];
        this.engine.isogeny.XDblE(pointProj1, pointProj1, numArray4, numArray5, 2U * num3);
      }
      this.engine.isogeny.Get4Isog(pointProj1, numArray4, numArray5, coeff);
      for (uint index3 = 0; index3 < index1; ++index3)
        this.engine.isogeny.Eval4Isog(pointProjArray[(int) index3], coeff);
      this.engine.isogeny.Eval4Isog(P1, coeff);
      this.engine.isogeny.Eval4Isog(P2, coeff);
      this.engine.isogeny.Eval4Isog(P3, coeff);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].X, pointProj1.X);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].Z, pointProj1.Z);
      num2 = numArray7[(int) index1 - 1];
      --index1;
    }
    this.engine.isogeny.Get4Isog(pointProj1, numArray4, numArray5, coeff);
    this.engine.isogeny.Eval4Isog(P1, coeff);
    this.engine.isogeny.Eval4Isog(P2, coeff);
    this.engine.isogeny.Eval4Isog(P3, coeff);
    this.engine.isogeny.Inv3Way(P1.Z, P2.Z, P3.Z);
    this.engine.fpx.fp2mul_mont(P1.X, P1.Z, P1.X);
    this.engine.fpx.fp2mul_mont(P2.X, P2.Z, P2.X);
    this.engine.fpx.fp2mul_mont(P3.X, P3.Z, P3.X);
    this.engine.fpx.fp2_encode(P1.X, ct, 0U);
    this.engine.fpx.fp2_encode(P2.X, ct, this.engine.param.FP2_ENCODED_BYTES);
    this.engine.fpx.fp2_encode(P3.X, ct, 2U * this.engine.param.FP2_ENCODED_BYTES);
  }

  internal void EphemeralSecretAgreement_A(byte[] ephemeralsk, byte[] pk, byte[] jinvariant)
  {
    PointProj pointProj1 = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj[] pointProjArray = new PointProj[(int) this.engine.param.MAX_INT_POINTS_ALICE];
    ulong[][][] numArray1 = SikeUtilities.InitArray(3U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] coeff = SikeUtilities.InitArray(3U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    uint index1 = 0;
    uint num1 = 0;
    uint[] numArray6 = new uint[(int) this.engine.param.MAX_INT_POINTS_ALICE];
    ulong[] numArray7 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    this.engine.fpx.fp2_decode(pk, numArray1[0], 0U);
    this.engine.fpx.fp2_decode(pk, numArray1[1], this.engine.param.FP2_ENCODED_BYTES);
    this.engine.fpx.fp2_decode(pk, numArray1[2], 2U * this.engine.param.FP2_ENCODED_BYTES);
    this.engine.isogeny.GetA(numArray1[0], numArray1[1], numArray1[2], numArray5);
    long num2 = (long) this.engine.fpx.mp_add(this.engine.param.Montgomery_one, this.engine.param.Montgomery_one, numArray4[0], this.engine.param.NWORDS_FIELD);
    this.engine.fpx.mp2_add(numArray5, numArray4, numArray3);
    long num3 = (long) this.engine.fpx.mp_add(numArray4[0], numArray4[0], numArray4[0], this.engine.param.NWORDS_FIELD);
    this.engine.fpx.decode_to_digits(ephemeralsk, 0U, numArray7, this.engine.param.SECRETKEY_A_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.isogeny.LADDER3PT(numArray1[0], numArray1[1], numArray1[2], numArray7, this.engine.param.ALICE, pointProj1, numArray5);
    if (this.engine.param.OALICE_BITS % 2U == 1U)
    {
      PointProj pointProj2 = new PointProj(this.engine.param.NWORDS_FIELD);
      this.engine.isogeny.XDblE(pointProj1, pointProj2, numArray3, numArray4, this.engine.param.OALICE_BITS - 1U);
      this.engine.isogeny.Get2Isog(pointProj2, numArray3, numArray4);
      this.engine.isogeny.Eval2Isog(pointProj1, pointProj2);
    }
    uint num4 = 0;
    for (uint index2 = 1; index2 < this.engine.param.MAX_Alice; ++index2)
    {
      uint num5;
      for (; num4 < this.engine.param.MAX_Alice - index2; num4 += num5)
      {
        pointProjArray[(int) index1] = new PointProj(this.engine.param.NWORDS_FIELD);
        this.engine.fpx.fp2copy(pointProj1.X, pointProjArray[(int) index1].X);
        this.engine.fpx.fp2copy(pointProj1.Z, pointProjArray[(int) index1].Z);
        numArray6[(int) index1++] = num4;
        num5 = this.engine.param.strat_Alice[(int) num1++];
        this.engine.isogeny.XDblE(pointProj1, pointProj1, numArray3, numArray4, 2U * num5);
      }
      this.engine.isogeny.Get4Isog(pointProj1, numArray3, numArray4, coeff);
      for (uint index3 = 0; index3 < index1; ++index3)
        this.engine.isogeny.Eval4Isog(pointProjArray[(int) index3], coeff);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].X, pointProj1.X);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].Z, pointProj1.Z);
      num4 = numArray6[(int) index1 - 1];
      --index1;
    }
    this.engine.isogeny.Get4Isog(pointProj1, numArray3, numArray4, coeff);
    this.engine.fpx.mp2_add(numArray3, numArray3, numArray3);
    this.engine.fpx.fp2sub(numArray3, numArray4, numArray3);
    this.engine.fpx.fp2add(numArray3, numArray3, numArray3);
    this.engine.isogeny.JInv(numArray3, numArray4, numArray2);
    this.engine.fpx.fp2_encode(numArray2, jinvariant, 0U);
  }

  internal void EphemeralSecretAgreement_B(byte[] sk, byte[] ct, byte[] jinvariant_)
  {
    PointProj pointProj = new PointProj(this.engine.param.NWORDS_FIELD);
    PointProj[] pointProjArray = new PointProj[(int) this.engine.param.MAX_INT_POINTS_BOB];
    ulong[][][] coeff = SikeUtilities.InitArray(3U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][][] numArray1 = SikeUtilities.InitArray(3U, 2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray2 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray3 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray4 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    ulong[][] numArray5 = SikeUtilities.InitArray(2U, this.engine.param.NWORDS_FIELD);
    uint index1 = 0;
    uint num1 = 0;
    uint[] numArray6 = new uint[(int) this.engine.param.MAX_INT_POINTS_BOB];
    ulong[] numArray7 = new ulong[(int) this.engine.param.NWORDS_ORDER];
    this.engine.fpx.fp2_decode(ct, numArray1[0], 0U);
    this.engine.fpx.fp2_decode(ct, numArray1[1], this.engine.param.FP2_ENCODED_BYTES);
    this.engine.fpx.fp2_decode(ct, numArray1[2], 2U * this.engine.param.FP2_ENCODED_BYTES);
    this.engine.isogeny.GetA(numArray1[0], numArray1[1], numArray1[2], numArray5);
    long num2 = (long) this.engine.fpx.mp_add(this.engine.param.Montgomery_one, this.engine.param.Montgomery_one, numArray4[0], this.engine.param.NWORDS_FIELD);
    this.engine.fpx.mp2_add(numArray5, numArray4, numArray3);
    this.engine.fpx.mp2_sub_p2(numArray5, numArray4, numArray4);
    this.engine.fpx.decode_to_digits(sk, this.engine.param.MSG_BYTES, numArray7, this.engine.param.SECRETKEY_B_BYTES, this.engine.param.NWORDS_ORDER);
    this.engine.isogeny.LADDER3PT(numArray1[0], numArray1[1], numArray1[2], numArray7, this.engine.param.BOB, pointProj, numArray5);
    uint num3 = 0;
    for (uint index2 = 1; index2 < this.engine.param.MAX_Bob; ++index2)
    {
      uint e;
      for (; num3 < this.engine.param.MAX_Bob - index2; num3 += e)
      {
        pointProjArray[(int) index1] = new PointProj(this.engine.param.NWORDS_FIELD);
        this.engine.fpx.fp2copy(pointProj.X, pointProjArray[(int) index1].X);
        this.engine.fpx.fp2copy(pointProj.Z, pointProjArray[(int) index1].Z);
        numArray6[(int) index1++] = num3;
        e = this.engine.param.strat_Bob[(int) num1++];
        this.engine.isogeny.XTplE(pointProj, pointProj, numArray4, numArray3, e);
      }
      this.engine.isogeny.Get3Isog(pointProj, numArray4, numArray3, coeff);
      for (uint index3 = 0; index3 < index1; ++index3)
        this.engine.isogeny.Eval3Isog(pointProjArray[(int) index3], coeff);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].X, pointProj.X);
      this.engine.fpx.fp2copy(pointProjArray[(int) index1 - 1].Z, pointProj.Z);
      num3 = numArray6[(int) index1 - 1];
      --index1;
    }
    this.engine.isogeny.Get3Isog(pointProj, numArray4, numArray3, coeff);
    this.engine.fpx.fp2add(numArray3, numArray4, numArray5);
    this.engine.fpx.fp2add(numArray5, numArray5, numArray5);
    this.engine.fpx.fp2sub(numArray3, numArray4, numArray3);
    this.engine.isogeny.JInv(numArray5, numArray3, numArray2);
    this.engine.fpx.fp2_encode(numArray2, jinvariant_, 0U);
  }
}
