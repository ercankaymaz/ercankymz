// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.Poly
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

internal class Poly
{
  private KyberEngine m_engine;
  public short[] m_coeffs = new short[256 /*0x0100*/];
  private Symmetric m_symmetric;

  public Poly(KyberEngine mEngine)
  {
    this.m_engine = mEngine;
    this.m_symmetric = mEngine.Symmetric;
  }

  internal short[] Coeffs => this.m_coeffs;

  internal void GetNoiseEta1(byte[] seed, byte nonce)
  {
    byte[] numArray = new byte[this.m_engine.Eta1 * 256 /*0x0100*/ / 4];
    this.m_symmetric.Prf(numArray, seed, nonce);
    Cbd.Eta(this, numArray, this.m_engine.Eta1);
  }

  internal void GetNoiseEta2(byte[] seed, byte nonce)
  {
    byte[] numArray = new byte[128 /*0x80*/];
    this.m_symmetric.Prf(numArray, seed, nonce);
    Cbd.Eta(this, numArray, 2);
  }

  internal void PolyNtt()
  {
    Ntt.NTT(this.Coeffs);
    this.PolyReduce();
  }

  internal void PolyInverseNttToMont() => Ntt.InvNTT(this.Coeffs);

  internal static void BaseMultMontgomery(Poly r, Poly a, Poly b)
  {
    for (int index = 0; index < 64 /*0x40*/; ++index)
    {
      Ntt.BaseMult(r.Coeffs, 4 * index, a.Coeffs[4 * index], a.Coeffs[4 * index + 1], b.Coeffs[4 * index], b.Coeffs[4 * index + 1], Ntt.Zetas[64 /*0x40*/ + index]);
      Ntt.BaseMult(r.Coeffs, 4 * index + 2, a.Coeffs[4 * index + 2], a.Coeffs[4 * index + 3], b.Coeffs[4 * index + 2], b.Coeffs[4 * index + 3], (short) (-1 * (int) Ntt.Zetas[64 /*0x40*/ + index]));
    }
  }

  internal void ToMont()
  {
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      this.Coeffs[index] = Reduce.MontgomeryReduce((int) this.Coeffs[index] * 1353);
  }

  internal void Add(Poly a)
  {
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      this.Coeffs[index] += a.Coeffs[index];
  }

  internal void Subtract(Poly a)
  {
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      this.Coeffs[index] = (short) ((int) a.Coeffs[index] - (int) this.Coeffs[index]);
  }

  internal void PolyReduce()
  {
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      this.Coeffs[index] = Reduce.BarrettReduce(this.Coeffs[index]);
  }

  internal void CompressPoly(byte[] r, int off)
  {
    byte[] numArray = new byte[8];
    int num = 0;
    this.CondSubQ();
    if (this.m_engine.PolyCompressedBytes == 128 /*0x80*/)
    {
      for (int index1 = 0; index1 < 32 /*0x20*/; ++index1)
      {
        for (int index2 = 0; index2 < 8; ++index2)
          numArray[index2] = (byte) ((((int) this.Coeffs[8 * index1 + index2] << 4) + 1664) / 3329 & 15);
        r[off + num] = (byte) ((uint) numArray[0] | (uint) numArray[1] << 4);
        r[off + num + 1] = (byte) ((uint) numArray[2] | (uint) numArray[3] << 4);
        r[off + num + 2] = (byte) ((uint) numArray[4] | (uint) numArray[5] << 4);
        r[off + num + 3] = (byte) ((uint) numArray[6] | (uint) numArray[7] << 4);
        num += 4;
      }
    }
    else
    {
      if (this.m_engine.PolyCompressedBytes != 160 /*0xA0*/)
        throw new ArgumentException("PolyCompressedBytes is neither 128 or 160!");
      for (int index3 = 0; index3 < 32 /*0x20*/; ++index3)
      {
        for (int index4 = 0; index4 < 8; ++index4)
          numArray[index4] = (byte) ((((int) this.Coeffs[8 * index3 + index4] << 5) + 1664) / 3329 & 31 /*0x1F*/);
        r[off + num] = (byte) ((uint) numArray[0] | (uint) numArray[1] << 5);
        r[off + num + 1] = (byte) ((int) numArray[1] >> 3 | (int) numArray[2] << 2 | (int) numArray[3] << 7);
        r[off + num + 2] = (byte) ((int) numArray[3] >> 1 | (int) numArray[4] << 4);
        r[off + num + 3] = (byte) ((int) numArray[4] >> 4 | (int) numArray[5] << 1 | (int) numArray[6] << 6);
        r[off + num + 4] = (byte) ((int) numArray[6] >> 2 | (int) numArray[7] << 3);
        num += 5;
      }
    }
  }

  internal void DecompressPoly(byte[] CompressedCipherText, int off)
  {
    int index1 = off;
    if (this.m_engine.PolyCompressedBytes == 128 /*0x80*/)
    {
      for (int index2 = 0; index2 < 128 /*0x80*/; ++index2)
      {
        this.Coeffs[2 * index2] = (short) ((int) (short) ((int) CompressedCipherText[index1] & (int) byte.MaxValue & 15) * 3329 + 8 >> 4);
        this.Coeffs[2 * index2 + 1] = (short) ((int) (short) (((int) CompressedCipherText[index1] & (int) byte.MaxValue) >> 4) * 3329 + 8 >> 4);
        ++index1;
      }
    }
    else
    {
      if (this.m_engine.PolyCompressedBytes != 160 /*0xA0*/)
        throw new ArgumentException("PolyCompressedBytes is neither 128 or 160!");
      byte[] numArray = new byte[8];
      for (int index3 = 0; index3 < 32 /*0x20*/; ++index3)
      {
        numArray[0] = (byte) ((uint) CompressedCipherText[index1] & (uint) byte.MaxValue);
        numArray[1] = (byte) (((int) CompressedCipherText[index1] & (int) byte.MaxValue) >> 5 | ((int) CompressedCipherText[index1 + 1] & (int) byte.MaxValue) << 3);
        numArray[2] = (byte) (((int) CompressedCipherText[index1 + 1] & (int) byte.MaxValue) >> 2);
        numArray[3] = (byte) (((int) CompressedCipherText[index1 + 1] & (int) byte.MaxValue) >> 7 | ((int) CompressedCipherText[index1 + 2] & (int) byte.MaxValue) << 1);
        numArray[4] = (byte) (((int) CompressedCipherText[index1 + 2] & (int) byte.MaxValue) >> 4 | ((int) CompressedCipherText[index1 + 3] & (int) byte.MaxValue) << 4);
        numArray[5] = (byte) (((int) CompressedCipherText[index1 + 3] & (int) byte.MaxValue) >> 1);
        numArray[6] = (byte) (((int) CompressedCipherText[index1 + 3] & (int) byte.MaxValue) >> 6 | ((int) CompressedCipherText[index1 + 4] & (int) byte.MaxValue) << 2);
        numArray[7] = (byte) (((int) CompressedCipherText[index1 + 4] & (int) byte.MaxValue) >> 3);
        index1 += 5;
        for (int index4 = 0; index4 < 8; ++index4)
          this.Coeffs[8 * index3 + index4] = (short) (((int) numArray[index4] & 31 /*0x1F*/) * 3329 + 16 /*0x10*/ >> 5);
      }
    }
  }

  internal void ToBytes(byte[] r, int off)
  {
    this.CondSubQ();
    for (int index = 0; index < 128 /*0x80*/; ++index)
    {
      ushort coeff1 = (ushort) this.Coeffs[2 * index];
      ushort coeff2 = (ushort) this.Coeffs[2 * index + 1];
      r[off + 3 * index] = (byte) coeff1;
      r[off + 3 * index + 1] = (byte) ((uint) coeff1 >> 8 | (uint) (ushort) ((uint) coeff2 << 4));
      r[off + 3 * index + 2] = (byte) (ushort) ((uint) coeff2 >> 4);
    }
  }

  internal void FromBytes(byte[] a, int off)
  {
    for (int index = 0; index < 128 /*0x80*/; ++index)
    {
      this.Coeffs[2 * index] = (short) (((int) a[off + 3 * index] & (int) byte.MaxValue | (int) (ushort) (((int) a[off + 3 * index + 1] & (int) byte.MaxValue) << 8)) & 4095 /*0x0FFF*/);
      this.Coeffs[2 * index + 1] = (short) ((((int) a[off + 3 * index + 1] & (int) byte.MaxValue) >> 4 | (int) (ushort) (((int) a[off + 3 * index + 2] & (int) byte.MaxValue) << 4)) & 4095 /*0x0FFF*/);
    }
  }

  internal void ToMsg(byte[] msg)
  {
    this.CondSubQ();
    for (int index1 = 0; index1 < 32 /*0x20*/; ++index1)
    {
      msg[index1] = (byte) 0;
      for (int index2 = 0; index2 < 8; ++index2)
      {
        short num = (short) (((int) (short) ((int) this.Coeffs[8 * index1 + index2] << 1) + 1664) / 3329 & 1);
        msg[index1] |= (byte) ((uint) num << index2);
      }
    }
  }

  internal void FromMsg(byte[] m)
  {
    if (m.Length != 32 /*0x20*/)
      throw new ArgumentException("KYBER_INDCPA_MSGBYTES must be equal to KYBER_N/8 bytes!");
    for (int index1 = 0; index1 < 32 /*0x20*/; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        short num = (short) (-1 * (int) (short) (((int) m[index1] & (int) byte.MaxValue) >> index2 & 1));
        this.Coeffs[8 * index1 + index2] = (short) ((int) num & 1665);
      }
    }
  }

  internal void CondSubQ()
  {
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      this.Coeffs[index] = Reduce.CondSubQ(this.Coeffs[index]);
  }
}
