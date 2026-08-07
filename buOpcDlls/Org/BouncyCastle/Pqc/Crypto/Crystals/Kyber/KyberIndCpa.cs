// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.KyberIndCpa
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

internal class KyberIndCpa
{
  private readonly KyberEngine m_engine;
  private Symmetric m_symmetric;

  internal KyberIndCpa(KyberEngine mEngine)
  {
    this.m_engine = mEngine;
    this.m_symmetric = mEngine.Symmetric;
  }

  private int GenerateMatrixNBlocks
  {
    get => (472 + this.m_symmetric.XofBlockBytes) / this.m_symmetric.XofBlockBytes;
  }

  private void GenerateMatrix(PolyVec[] a, byte[] seed, bool transposed)
  {
    int k = this.m_engine.K;
    byte[] numArray = new byte[this.GenerateMatrixNBlocks * this.m_symmetric.XofBlockBytes + 2];
    for (int index1 = 0; index1 < k; ++index1)
    {
      for (int index2 = 0; index2 < k; ++index2)
      {
        if (transposed)
          this.m_symmetric.XofAbsorb(seed, (byte) index1, (byte) index2);
        else
          this.m_symmetric.XofAbsorb(seed, (byte) index2, (byte) index1);
        this.m_symmetric.XofSqueezeBlocks(numArray, 0, this.GenerateMatrixNBlocks * this.m_symmetric.XofBlockBytes);
        int buflen = this.GenerateMatrixNBlocks * this.m_symmetric.XofBlockBytes;
        for (int off = this.RejectionSampling(a[index1].m_vec[index2].m_coeffs, 0, 256 /*0x0100*/, numArray, buflen); off < 256 /*0x0100*/; off += this.RejectionSampling(a[index1].m_vec[index2].m_coeffs, off, 256 /*0x0100*/ - off, numArray, buflen))
        {
          int outOffset = buflen % 3;
          for (int index3 = 0; index3 < outOffset; ++index3)
            numArray[index3] = numArray[buflen - outOffset + index3];
          this.m_symmetric.XofSqueezeBlocks(numArray, outOffset, this.m_symmetric.XofBlockBytes * 2);
          buflen = outOffset + this.m_symmetric.XofBlockBytes;
        }
      }
    }
  }

  private int RejectionSampling(short[] r, int off, int len, byte[] buf, int buflen)
  {
    int num1 = 0;
    int index = 0;
    while (num1 < len && index + 3 <= buflen)
    {
      ushort num2 = (ushort) (((int) (ushort) ((uint) buf[index] & (uint) byte.MaxValue) | (int) (ushort) ((uint) buf[index + 1] & (uint) byte.MaxValue) << 8) & 4095 /*0x0FFF*/);
      ushort num3 = (ushort) (((int) (ushort) ((uint) buf[index + 1] & (uint) byte.MaxValue) >> 4 | (int) (ushort) ((uint) buf[index + 2] & (uint) byte.MaxValue) << 4) & 4095 /*0x0FFF*/);
      index += 3;
      if (num2 < (ushort) 3329)
        r[off + num1++] = (short) num2;
      if (num1 < len && num3 < (ushort) 3329)
        r[off + num1++] = (short) num3;
    }
    return num1;
  }

  internal void GenerateKeyPair(out byte[] pk, out byte[] sk)
  {
    int k = this.m_engine.K;
    byte[] numArray1 = new byte[2 * KyberEngine.SymBytes];
    byte num = 0;
    PolyVec[] a1 = new PolyVec[k];
    PolyVec a2 = new PolyVec(this.m_engine);
    PolyVec pkpv = new PolyVec(this.m_engine);
    PolyVec polyVec = new PolyVec(this.m_engine);
    byte[] numArray2 = new byte[32 /*0x20*/];
    this.m_engine.RandomBytes(numArray2, 32 /*0x20*/);
    this.m_symmetric.Hash_g(numArray1, numArray2);
    byte[] seed1 = Arrays.CopyOfRange(numArray1, 0, KyberEngine.SymBytes);
    byte[] seed2 = Arrays.CopyOfRange(numArray1, KyberEngine.SymBytes, 2 * KyberEngine.SymBytes);
    for (int index = 0; index < k; ++index)
      a1[index] = new PolyVec(this.m_engine);
    this.GenerateMatrix(a1, seed1, false);
    for (int index = 0; index < k; ++index)
      polyVec.m_vec[index].GetNoiseEta1(seed2, num++);
    for (int index = 0; index < k; ++index)
      a2.m_vec[index].GetNoiseEta1(seed2, num++);
    polyVec.Ntt();
    a2.Ntt();
    for (int index = 0; index < k; ++index)
    {
      PolyVec.PointwiseAccountMontgomery(pkpv.m_vec[index], a1[index], polyVec, this.m_engine);
      pkpv.m_vec[index].ToMont();
    }
    pkpv.Add(a2);
    pkpv.Reduce();
    this.PackSecretKey(out sk, polyVec);
    this.PackPublicKey(out pk, pkpv, seed1);
  }

  private void PackSecretKey(out byte[] sk, PolyVec skpv)
  {
    sk = new byte[this.m_engine.PolyVecBytes];
    skpv.ToBytes(sk);
  }

  private void UnpackSecretKey(PolyVec skpv, byte[] sk) => skpv.FromBytes(sk);

  private void PackPublicKey(out byte[] pk, PolyVec pkpv, byte[] seed)
  {
    pk = new byte[this.m_engine.IndCpaPublicKeyBytes];
    pkpv.ToBytes(pk);
    Array.Copy((Array) seed, 0, (Array) pk, this.m_engine.PolyVecBytes, KyberEngine.SymBytes);
  }

  private void UnpackPublicKey(PolyVec pkpv, byte[] seed, byte[] pk)
  {
    pkpv.FromBytes(pk);
    Array.Copy((Array) pk, this.m_engine.PolyVecBytes, (Array) seed, 0, KyberEngine.SymBytes);
  }

  public void Encrypt(byte[] c, byte[] m, byte[] pk, byte[] coins)
  {
    int k = this.m_engine.K;
    byte[] seed1 = new byte[KyberEngine.SymBytes];
    byte num1 = 0;
    PolyVec b1 = new PolyVec(this.m_engine);
    PolyVec polyVec = new PolyVec(this.m_engine);
    PolyVec a1 = new PolyVec(this.m_engine);
    PolyVec b2 = new PolyVec(this.m_engine);
    PolyVec[] a2 = new PolyVec[k];
    Poly poly1 = new Poly(this.m_engine);
    Poly a3 = new Poly(this.m_engine);
    Poly a4 = new Poly(this.m_engine);
    this.UnpackPublicKey(polyVec, seed1, pk);
    a3.FromMsg(m);
    for (int index = 0; index < k; ++index)
      a2[index] = new PolyVec(this.m_engine);
    this.GenerateMatrix(a2, seed1, true);
    for (int index = 0; index < k; ++index)
      b1.m_vec[index].GetNoiseEta1(coins, num1++);
    for (int index = 0; index < k; ++index)
      a1.m_vec[index].GetNoiseEta2(coins, num1++);
    Poly poly2 = a4;
    byte[] seed2 = coins;
    int nonce = (int) num1;
    byte num2 = (byte) (nonce + 1);
    poly2.GetNoiseEta2(seed2, (byte) nonce);
    b1.Ntt();
    for (int index = 0; index < k; ++index)
      PolyVec.PointwiseAccountMontgomery(b2.m_vec[index], a2[index], b1, this.m_engine);
    PolyVec.PointwiseAccountMontgomery(poly1, polyVec, b1, this.m_engine);
    b2.InverseNttToMont();
    poly1.PolyInverseNttToMont();
    b2.Add(a1);
    poly1.Add(a4);
    poly1.Add(a3);
    b2.Reduce();
    poly1.PolyReduce();
    this.PackCipherText(c, b2, poly1);
  }

  private void PackCipherText(byte[] r, PolyVec b, Poly v)
  {
    b.CompressPolyVec(r);
    v.CompressPoly(r, this.m_engine.PolyVecCompressedBytes);
  }

  private void UnpackCipherText(PolyVec b, Poly v, byte[] c)
  {
    b.DecompressPolyVec(c);
    v.DecompressPoly(c, this.m_engine.PolyVecCompressedBytes);
  }

  internal void Decrypt(byte[] m, byte[] c, byte[] sk)
  {
    PolyVec b = new PolyVec(this.m_engine);
    PolyVec polyVec = new PolyVec(this.m_engine);
    Poly poly = new Poly(this.m_engine);
    Poly r = new Poly(this.m_engine);
    this.UnpackCipherText(b, poly, c);
    this.UnpackSecretKey(polyVec, sk);
    b.Ntt();
    PolyVec.PointwiseAccountMontgomery(r, polyVec, b, this.m_engine);
    r.PolyInverseNttToMont();
    r.Subtract(poly);
    r.PolyReduce();
    r.ToMsg(m);
  }
}
