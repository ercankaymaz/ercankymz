// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.PolyVec
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

internal class PolyVec
{
  private KyberEngine m_engine;
  internal Poly[] m_vec;

  internal PolyVec(KyberEngine engine)
  {
    this.m_engine = engine;
    this.m_vec = new Poly[engine.K];
    for (int index = 0; index < engine.K; ++index)
      this.m_vec[index] = new Poly(engine);
  }

  internal void Ntt()
  {
    for (int index = 0; index < this.m_engine.K; ++index)
      this.m_vec[index].PolyNtt();
  }

  internal void InverseNttToMont()
  {
    for (int index = 0; index < this.m_engine.K; ++index)
      this.m_vec[index].PolyInverseNttToMont();
  }

  internal static void PointwiseAccountMontgomery(
    Poly r,
    PolyVec a,
    PolyVec b,
    KyberEngine engine)
  {
    Poly poly = new Poly(engine);
    Poly.BaseMultMontgomery(r, a.m_vec[0], b.m_vec[0]);
    for (int index = 1; index < engine.K; ++index)
    {
      Poly.BaseMultMontgomery(poly, a.m_vec[index], b.m_vec[index]);
      r.Add(poly);
    }
    r.PolyReduce();
  }

  internal void Add(PolyVec a)
  {
    for (int index = 0; index < this.m_engine.K; ++index)
      this.m_vec[index].Add(a.m_vec[index]);
  }

  internal void Reduce()
  {
    for (int index = 0; index < this.m_engine.K; ++index)
      this.m_vec[index].PolyReduce();
  }

  internal void CompressPolyVec(byte[] r)
  {
    this.ConditionalSubQ();
    int index1 = 0;
    if (this.m_engine.PolyVecCompressedBytes == this.m_engine.K * 320)
    {
      short[] numArray = new short[4];
      for (int index2 = 0; index2 < this.m_engine.K; ++index2)
      {
        for (int index3 = 0; index3 < 64 /*0x40*/; ++index3)
        {
          for (int index4 = 0; index4 < 4; ++index4)
            numArray[index4] = (short) ((int) ((uint) (((int) this.m_vec[index2].m_coeffs[4 * index3 + index4] << 10) + 1664) / 3329U) & 1023 /*0x03FF*/);
          r[index1] = (byte) numArray[0];
          r[index1 + 1] = (byte) ((int) numArray[0] >> 8 | (int) numArray[1] << 2);
          r[index1 + 2] = (byte) ((int) numArray[1] >> 6 | (int) numArray[2] << 4);
          r[index1 + 3] = (byte) ((int) numArray[2] >> 4 | (int) numArray[3] << 6);
          r[index1 + 4] = (byte) ((uint) numArray[3] >> 2);
          index1 += 5;
        }
      }
    }
    else
    {
      if (this.m_engine.PolyVecCompressedBytes != this.m_engine.K * 352)
        throw new ArgumentException("Kyber PolyVecCompressedBytes neither 320 * KyberK or 352 * KyberK!");
      short[] numArray = new short[8];
      for (int index5 = 0; index5 < this.m_engine.K; ++index5)
      {
        for (int index6 = 0; index6 < 32 /*0x20*/; ++index6)
        {
          for (int index7 = 0; index7 < 8; ++index7)
            numArray[index7] = (short) ((int) ((uint) (((int) this.m_vec[index5].m_coeffs[8 * index6 + index7] << 11) + 1664) / 3329U) & 2047 /*0x07FF*/);
          r[index1] = (byte) numArray[0];
          r[index1 + 1] = (byte) ((int) numArray[0] >> 8 | (int) numArray[1] << 3);
          r[index1 + 2] = (byte) ((int) numArray[1] >> 5 | (int) numArray[2] << 6);
          r[index1 + 3] = (byte) ((uint) numArray[2] >> 2);
          r[index1 + 4] = (byte) ((int) numArray[2] >> 10 | (int) numArray[3] << 1);
          r[index1 + 5] = (byte) ((int) numArray[3] >> 7 | (int) numArray[4] << 4);
          r[index1 + 6] = (byte) ((int) numArray[4] >> 4 | (int) numArray[5] << 7);
          r[index1 + 7] = (byte) ((uint) numArray[5] >> 1);
          r[index1 + 8] = (byte) ((int) numArray[5] >> 9 | (int) numArray[6] << 2);
          r[index1 + 9] = (byte) ((int) numArray[6] >> 6 | (int) numArray[7] << 5);
          r[index1 + 10] = (byte) ((uint) numArray[7] >> 3);
          index1 += 11;
        }
      }
    }
  }

  internal void DecompressPolyVec(byte[] compressedCipherText)
  {
    int index1 = 0;
    if (this.m_engine.PolyVecCompressedBytes == this.m_engine.K * 320)
    {
      short[] numArray = new short[4];
      for (int index2 = 0; index2 < this.m_engine.K; ++index2)
      {
        for (int index3 = 0; index3 < 64 /*0x40*/; ++index3)
        {
          numArray[0] = (short) ((int) compressedCipherText[index1] & (int) byte.MaxValue | (int) (ushort) ((uint) compressedCipherText[index1 + 1] & (uint) byte.MaxValue) << 8);
          numArray[1] = (short) (((int) compressedCipherText[index1 + 1] & (int) byte.MaxValue) >> 2 | (int) (ushort) ((uint) compressedCipherText[index1 + 2] & (uint) byte.MaxValue) << 6);
          numArray[2] = (short) (((int) compressedCipherText[index1 + 2] & (int) byte.MaxValue) >> 4 | (int) (ushort) ((uint) compressedCipherText[index1 + 3] & (uint) byte.MaxValue) << 4);
          numArray[3] = (short) (((int) compressedCipherText[index1 + 3] & (int) byte.MaxValue) >> 6 | (int) (ushort) ((uint) compressedCipherText[index1 + 4] & (uint) byte.MaxValue) << 2);
          index1 += 5;
          for (int index4 = 0; index4 < 4; ++index4)
            this.m_vec[index2].m_coeffs[4 * index3 + index4] = (short) (((int) numArray[index4] & 1023 /*0x03FF*/) * 3329 + 512 /*0x0200*/ >> 10);
        }
      }
    }
    else
    {
      if (this.m_engine.PolyVecCompressedBytes != this.m_engine.K * 352)
        throw new ArgumentException("Kyber PolyVecCompressedBytes neither 320 * KyberK or 352 * KyberK!");
      short[] numArray = new short[8];
      for (int index5 = 0; index5 < this.m_engine.K; ++index5)
      {
        for (int index6 = 0; index6 < 32 /*0x20*/; ++index6)
        {
          numArray[0] = (short) ((int) compressedCipherText[index1] & (int) byte.MaxValue | (int) (ushort) ((uint) compressedCipherText[index1 + 1] & (uint) byte.MaxValue) << 8);
          numArray[1] = (short) (((int) compressedCipherText[index1 + 1] & (int) byte.MaxValue) >> 3 | (int) (ushort) ((uint) compressedCipherText[index1 + 2] & (uint) byte.MaxValue) << 5);
          numArray[2] = (short) (((int) compressedCipherText[index1 + 2] & (int) byte.MaxValue) >> 6 | (int) (ushort) ((uint) compressedCipherText[index1 + 3] & (uint) byte.MaxValue) << 2 | (int) (ushort) (((int) compressedCipherText[index1 + 4] & (int) byte.MaxValue) << 10));
          numArray[3] = (short) (((int) compressedCipherText[index1 + 4] & (int) byte.MaxValue) >> 1 | (int) (ushort) ((uint) compressedCipherText[index1 + 5] & (uint) byte.MaxValue) << 7);
          numArray[4] = (short) (((int) compressedCipherText[index1 + 5] & (int) byte.MaxValue) >> 4 | (int) (ushort) ((uint) compressedCipherText[index1 + 6] & (uint) byte.MaxValue) << 4);
          numArray[5] = (short) (((int) compressedCipherText[index1 + 6] & (int) byte.MaxValue) >> 7 | (int) (ushort) ((uint) compressedCipherText[index1 + 7] & (uint) byte.MaxValue) << 1 | (int) (ushort) (((int) compressedCipherText[index1 + 8] & (int) byte.MaxValue) << 9));
          numArray[6] = (short) (((int) compressedCipherText[index1 + 8] & (int) byte.MaxValue) >> 2 | (int) (ushort) ((uint) compressedCipherText[index1 + 9] & (uint) byte.MaxValue) << 6);
          numArray[7] = (short) (((int) compressedCipherText[index1 + 9] & (int) byte.MaxValue) >> 5 | (int) (ushort) ((uint) compressedCipherText[index1 + 10] & (uint) byte.MaxValue) << 3);
          index1 += 11;
          for (int index7 = 0; index7 < 8; ++index7)
            this.m_vec[index5].m_coeffs[8 * index6 + index7] = (short) (((int) numArray[index7] & 2047 /*0x07FF*/) * 3329 + 1024 /*0x0400*/ >> 11);
        }
      }
    }
  }

  internal void ToBytes(byte[] r)
  {
    for (int index = 0; index < this.m_engine.K; ++index)
      this.m_vec[index].ToBytes(r, index * KyberEngine.PolyBytes);
  }

  internal void FromBytes(byte[] pk)
  {
    for (int index = 0; index < this.m_engine.K; ++index)
      this.m_vec[index].FromBytes(pk, index * KyberEngine.PolyBytes);
  }

  private void ConditionalSubQ()
  {
    for (int index = 0; index < this.m_engine.K; ++index)
      this.m_vec[index].CondSubQ();
  }
}
