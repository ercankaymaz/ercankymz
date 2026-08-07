// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.DilithiumEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

internal class DilithiumEngine
{
  private SecureRandom _random;
  public const int N = 256 /*0x0100*/;
  public const int Q = 8380417;
  public const int QInv = 58728449;
  public const int D = 13;
  public const int RootOfUnity = 1753;
  public const int SeedBytes = 32 /*0x20*/;
  public const int CrhBytes = 64 /*0x40*/;
  public const int PolyT1PackedBytes = 320;
  public const int PolyT0PackedBytes = 416;

  public int Mode { get; private set; }

  public int K { get; private set; }

  public int L { get; private set; }

  public int Eta { get; private set; }

  public int Tau { get; private set; }

  public int Beta { get; private set; }

  public int Gamma1 { get; private set; }

  public int Gamma2 { get; private set; }

  public int Omega { get; private set; }

  public int PolyVecHPackedBytes { get; private set; }

  public int PolyZPackedBytes { get; private set; }

  public int PolyW1PackedBytes { get; private set; }

  public int PolyEtaPackedBytes { get; private set; }

  public int CryptoPublicKeyBytes { get; private set; }

  public int CryptoSecretKeyBytes { get; private set; }

  public int CryptoBytes { get; private set; }

  public int PolyUniformGamma1NBytes { get; private set; }

  public Symmetric Symmetric { get; private set; }

  public DilithiumEngine(int mode, SecureRandom random, bool usingAes)
  {
    this.Mode = mode;
    switch (this.Mode)
    {
      case 2:
        this.K = 4;
        this.L = 4;
        this.Eta = 2;
        this.Tau = 39;
        this.Beta = 78;
        this.Gamma1 = 131072 /*0x020000*/;
        this.Gamma2 = 95232;
        this.Omega = 80 /*0x50*/;
        this.PolyZPackedBytes = 576;
        this.PolyW1PackedBytes = 192 /*0xC0*/;
        this.PolyEtaPackedBytes = 96 /*0x60*/;
        break;
      case 3:
        this.K = 6;
        this.L = 5;
        this.Eta = 4;
        this.Tau = 49;
        this.Beta = 196;
        this.Gamma1 = 524288 /*0x080000*/;
        this.Gamma2 = 261888;
        this.Omega = 55;
        this.PolyZPackedBytes = 640;
        this.PolyW1PackedBytes = 128 /*0x80*/;
        this.PolyEtaPackedBytes = 128 /*0x80*/;
        break;
      case 5:
        this.K = 8;
        this.L = 7;
        this.Eta = 2;
        this.Tau = 60;
        this.Beta = 120;
        this.Gamma1 = 524288 /*0x080000*/;
        this.Gamma2 = 261888;
        this.Omega = 75;
        this.PolyZPackedBytes = 640;
        this.PolyW1PackedBytes = 128 /*0x80*/;
        this.PolyEtaPackedBytes = 96 /*0x60*/;
        break;
      default:
        throw new ArgumentException($"The mode {mode.ToString()}is not supported by Crystals Dilithium!");
    }
    this.Symmetric = !usingAes ? (Symmetric) new Symmetric.ShakeSymmetric() : (Symmetric) new Symmetric.AesSymmetric();
    this._random = random;
    this.PolyVecHPackedBytes = this.Omega + this.K;
    this.CryptoPublicKeyBytes = 32 /*0x20*/ + this.K * 320;
    this.CryptoSecretKeyBytes = 96 /*0x60*/ + this.L * this.PolyEtaPackedBytes + this.K * this.PolyEtaPackedBytes + this.K * 416;
    this.CryptoBytes = 32 /*0x20*/ + this.L * this.PolyZPackedBytes + this.PolyVecHPackedBytes;
    if (this.Gamma1 == 131072 /*0x020000*/)
    {
      this.PolyUniformGamma1NBytes = (576 + this.Symmetric.Stream256BlockBytes - 1) / this.Symmetric.Stream256BlockBytes;
    }
    else
    {
      if (this.Gamma1 != 524288 /*0x080000*/)
        throw new ArgumentException("Wrong Dilithium Gamma1!");
      this.PolyUniformGamma1NBytes = (640 + this.Symmetric.Stream256BlockBytes - 1) / this.Symmetric.Stream256BlockBytes;
    }
  }

  public void GenerateKeyPair(
    out byte[] rho,
    out byte[] key,
    out byte[] tr,
    out byte[] s1_,
    out byte[] s2_,
    out byte[] t0_,
    out byte[] encT1)
  {
    byte[] numArray1 = new byte[32 /*0x20*/];
    byte[] numArray2 = new byte[128 /*0x80*/];
    byte[] numArray3 = new byte[64 /*0x40*/];
    tr = new byte[32 /*0x20*/];
    rho = new byte[32 /*0x20*/];
    key = new byte[32 /*0x20*/];
    s1_ = new byte[this.L * this.PolyEtaPackedBytes];
    s2_ = new byte[this.K * this.PolyEtaPackedBytes];
    t0_ = new byte[this.K * 416];
    PolyVecMatrix polyVecMatrix = new PolyVecMatrix(this);
    PolyVecL s1 = new PolyVecL(this);
    PolyVecK polyVecK1 = new PolyVecK(this);
    PolyVecK polyVecK2 = new PolyVecK(this);
    PolyVecK polyVecK3 = new PolyVecK(this);
    this._random.NextBytes(numArray1);
    ShakeDigest shakeDigest = new ShakeDigest(256 /*0x0100*/);
    shakeDigest.BlockUpdate(numArray1, 0, 32 /*0x20*/);
    shakeDigest.OutputFinal(numArray2, 0, 128 /*0x80*/);
    rho = Arrays.CopyOfRange(numArray2, 0, 32 /*0x20*/);
    byte[] seed = Arrays.CopyOfRange(numArray2, 32 /*0x20*/, 96 /*0x60*/);
    key = Arrays.CopyOfRange(numArray2, 96 /*0x60*/, 128 /*0x80*/);
    polyVecMatrix.ExpandMatrix(rho);
    s1.UniformEta(seed, (ushort) 0);
    polyVecK1.UniformEta(seed, (ushort) this.L);
    PolyVecL polyVecL = new PolyVecL(this);
    s1.CopyPolyVecL(polyVecL);
    polyVecL.Ntt();
    polyVecMatrix.PointwiseMontgomery(polyVecK2, polyVecL);
    polyVecK2.Reduce();
    polyVecK2.InverseNttToMont();
    polyVecK2.AddPolyVecK(polyVecK1);
    polyVecK2.ConditionalAddQ();
    polyVecK2.Power2Round(polyVecK3);
    encT1 = Packing.PackPublicKey(polyVecK2, this);
    shakeDigest.BlockUpdate(rho, 0, rho.Length);
    shakeDigest.BlockUpdate(encT1, 0, encT1.Length);
    shakeDigest.OutputFinal(tr, 0, 32 /*0x20*/);
    Packing.PackSecretKey(t0_, s1_, s2_, polyVecK3, s1, polyVecK1, this);
  }

  public void SignSignature(
    byte[] sig,
    int siglen,
    byte[] msg,
    int msglen,
    byte[] rho,
    byte[] key,
    byte[] tr,
    byte[] t0Enc,
    byte[] s1Enc,
    byte[] s2Enc)
  {
    byte[] numArray1 = new byte[64 /*0x40*/];
    byte[] numArray2 = new byte[64 /*0x40*/];
    ushort num = 0;
    PolyVecMatrix polyVecMatrix = new PolyVecMatrix(this);
    PolyVecL polyVecL1 = new PolyVecL(this);
    PolyVecL b = new PolyVecL(this);
    PolyVecL polyVecL2 = new PolyVecL(this);
    PolyVecK polyVecK1 = new PolyVecK(this);
    PolyVecK polyVecK2 = new PolyVecK(this);
    PolyVecK polyVecK3 = new PolyVecK(this);
    PolyVecK polyVecK4 = new PolyVecK(this);
    PolyVecK polyVecK5 = new PolyVecK(this);
    Poly a = new Poly(this);
    Packing.UnpackSecretKey(polyVecK1, polyVecL1, polyVecK2, t0Enc, s1Enc, s2Enc, this);
    ShakeDigest shakeDigest = new ShakeDigest(256 /*0x0100*/);
    shakeDigest.BlockUpdate(tr, 0, 32 /*0x20*/);
    shakeDigest.BlockUpdate(msg, 0, msglen);
    shakeDigest.OutputFinal(numArray1, 0, 64 /*0x40*/);
    if (this._random != null)
    {
      this._random.NextBytes(numArray2);
    }
    else
    {
      byte[] numArray3 = Arrays.CopyOf(key, 96 /*0x60*/);
      Array.Copy((Array) numArray1, 0, (Array) numArray3, 32 /*0x20*/, 64 /*0x40*/);
      shakeDigest.BlockUpdate(numArray3, 0, 96 /*0x60*/);
      shakeDigest.OutputFinal(numArray2, 0, 64 /*0x40*/);
    }
    polyVecMatrix.ExpandMatrix(rho);
    polyVecL1.Ntt();
    polyVecK2.Ntt();
    polyVecK1.Ntt();
    do
    {
      do
      {
        do
        {
          do
          {
            b.UniformGamma1(numArray2, num++);
            b.CopyPolyVecL(polyVecL2);
            polyVecL2.Ntt();
            polyVecMatrix.PointwiseMontgomery(polyVecK3, polyVecL2);
            polyVecK3.Reduce();
            polyVecK3.InverseNttToMont();
            polyVecK3.ConditionalAddQ();
            polyVecK3.Decompose(polyVecK4);
            polyVecK3.PackW1(sig);
            shakeDigest.BlockUpdate(numArray1, 0, 64 /*0x40*/);
            shakeDigest.BlockUpdate(sig, 0, this.K * this.PolyW1PackedBytes);
            shakeDigest.OutputFinal(sig, 0, 32 /*0x20*/);
            a.Challenge(sig);
            a.PolyNtt();
            polyVecL2.PointwisePolyMontgomery(a, polyVecL1);
            polyVecL2.InverseNttToMont();
            polyVecL2.AddPolyVecL(b);
            polyVecL2.Reduce();
          }
          while (polyVecL2.CheckNorm(this.Gamma1 - this.Beta));
          polyVecK5.PointwisePolyMontgomery(a, polyVecK2);
          polyVecK5.InverseNttToMont();
          polyVecK4.Subtract(polyVecK5);
          polyVecK4.Reduce();
        }
        while (polyVecK4.CheckNorm(this.Gamma2 - this.Beta));
        polyVecK5.PointwisePolyMontgomery(a, polyVecK1);
        polyVecK5.InverseNttToMont();
        polyVecK5.Reduce();
      }
      while (polyVecK5.CheckNorm(this.Gamma2));
      polyVecK4.AddPolyVecK(polyVecK5);
      polyVecK4.ConditionalAddQ();
    }
    while (polyVecK5.MakeHint(polyVecK4, polyVecK3) > this.Omega);
    Packing.PackSignature(sig, sig, polyVecL2, polyVecK5, this);
  }

  public void Sign(
    byte[] sig,
    int siglen,
    byte[] msg,
    int mlen,
    byte[] rho,
    byte[] key,
    byte[] tr,
    byte[] t0,
    byte[] s1,
    byte[] s2)
  {
    this.SignSignature(sig, siglen, msg, mlen, rho, key, tr, t0, s1, s2);
  }

  public bool SignVerify(
    byte[] sig,
    int siglen,
    byte[] msg,
    int msglen,
    byte[] rho,
    byte[] encT1)
  {
    byte[] numArray1 = new byte[this.K * this.PolyW1PackedBytes];
    byte[] numArray2 = new byte[64 /*0x40*/];
    byte[] numArray3 = new byte[32 /*0x20*/];
    byte[] output = new byte[32 /*0x20*/];
    Poly a = new Poly(this);
    PolyVecMatrix polyVecMatrix = new PolyVecMatrix(this);
    PolyVecL polyVecL = new PolyVecL(this);
    PolyVecK t1 = new PolyVecK(this);
    PolyVecK polyVecK = new PolyVecK(this);
    PolyVecK h = new PolyVecK(this);
    if (siglen != this.CryptoBytes)
      return false;
    PolyVecK v = Packing.UnpackPublicKey(t1, encT1, this);
    if (!Packing.UnpackSignature(polyVecL, h, sig, this))
      return false;
    byte[] seed = Arrays.CopyOfRange(sig, 0, 32 /*0x20*/);
    if (polyVecL.CheckNorm(this.Gamma1 - this.Beta))
      return false;
    ShakeDigest shakeDigest = new ShakeDigest(256 /*0x0100*/);
    shakeDigest.BlockUpdate(rho, 0, rho.Length);
    shakeDigest.BlockUpdate(encT1, 0, encT1.Length);
    shakeDigest.OutputFinal(numArray2, 0, 32 /*0x20*/);
    shakeDigest.BlockUpdate(numArray2, 0, 32 /*0x20*/);
    shakeDigest.BlockUpdate(msg, 0, msglen);
    shakeDigest.DoFinal(numArray2, 0);
    a.Challenge(seed);
    polyVecMatrix.ExpandMatrix(rho);
    polyVecL.Ntt();
    polyVecMatrix.PointwiseMontgomery(polyVecK, polyVecL);
    a.PolyNtt();
    v.ShiftLeft();
    v.Ntt();
    v.PointwisePolyMontgomery(a, v);
    polyVecK.Subtract(v);
    polyVecK.Reduce();
    polyVecK.InverseNttToMont();
    polyVecK.ConditionalAddQ();
    polyVecK.UseHint(polyVecK, h);
    polyVecK.PackW1(numArray1);
    shakeDigest.BlockUpdate(numArray2, 0, 64 /*0x40*/);
    shakeDigest.BlockUpdate(numArray1, 0, this.K * this.PolyW1PackedBytes);
    shakeDigest.OutputFinal(output, 0, 32 /*0x20*/);
    for (int index = 0; index < 32 /*0x20*/; ++index)
    {
      if ((int) seed[index] != (int) output[index])
        return false;
    }
    return true;
  }

  public bool SignOpen(byte[] msg, byte[] sig, int siglen, byte[] rho, byte[] t1)
  {
    return this.SignVerify(sig, siglen, msg, msg.Length, rho, t1);
  }
}
