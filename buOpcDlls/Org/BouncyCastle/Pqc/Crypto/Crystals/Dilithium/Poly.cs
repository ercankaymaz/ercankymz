// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.Poly
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

internal class Poly
{
  private int N;
  private DilithiumEngine Engine;
  private int PolyUniformNBlocks;
  private Symmetric Symmetric;

  public int[] Coeffs { get; set; }

  public Poly(DilithiumEngine engine)
  {
    this.N = 256 /*0x0100*/;
    this.Coeffs = new int[this.N];
    this.Engine = engine;
    this.Symmetric = engine.Symmetric;
    this.PolyUniformNBlocks = (768 /*0x0300*/ + this.Symmetric.Stream128BlockBytes - 1) / this.Symmetric.Stream128BlockBytes;
  }

  public void UniformBlocks(byte[] seed, ushort nonce)
  {
    int num = this.PolyUniformNBlocks * this.Symmetric.Stream128BlockBytes;
    byte[] numArray = new byte[num + 2];
    this.Symmetric.Stream128Init(seed, nonce);
    this.Symmetric.Stream128SqueezeBlocks(numArray, 0, num);
    for (int off = Poly.RejectUniform(this.Coeffs, 0, this.N, numArray, num); off < this.N; off += Poly.RejectUniform(this.Coeffs, off, this.N - off, numArray, num))
    {
      int offset = num % 3;
      for (int index = 0; index < offset; ++index)
        numArray[index] = numArray[num - offset + index];
      this.Symmetric.Stream128SqueezeBlocks(numArray, offset, this.Symmetric.Stream128BlockBytes);
      num = this.Symmetric.Stream128BlockBytes + offset;
    }
  }

  private static int RejectUniform(int[] coeffs, int off, int len, byte[] buf, int buflen)
  {
    int num1 = 0;
    int num2 = 0;
    while (num2 < len && num1 + 3 <= buflen)
    {
      byte[] numArray1 = buf;
      int index1 = num1;
      int num3 = index1 + 1;
      int num4 = (int) ((uint) numArray1[index1] & (uint) byte.MaxValue);
      byte[] numArray2 = buf;
      int index2 = num3;
      int num5 = index2 + 1;
      int num6 = ((int) numArray2[index2] & (int) byte.MaxValue) << 8;
      int num7 = num4 | num6;
      byte[] numArray3 = buf;
      int index3 = num5;
      num1 = index3 + 1;
      int num8 = ((int) numArray3[index3] & (int) byte.MaxValue) << 16 /*0x10*/;
      uint num9 = (uint) (num7 | num8) & 8388607U /*0x7FFFFF*/;
      if (num9 < 8380417U)
        coeffs[off + num2++] = (int) num9;
    }
    return num2;
  }

  public void UniformEta(byte[] seed, ushort nonce)
  {
    int eta = this.Engine.Eta;
    int num;
    if (this.Engine.Eta == 2)
    {
      num = (136 + this.Symmetric.Stream256BlockBytes - 1) / this.Symmetric.Stream256BlockBytes;
    }
    else
    {
      if (this.Engine.Eta != 4)
        throw new ArgumentException("Wrong Dilithium Eta!");
      num = (227 + this.Symmetric.Stream256BlockBytes - 1) / this.Symmetric.Stream256BlockBytes;
    }
    int length = num * this.Symmetric.Stream256BlockBytes;
    byte[] numArray = new byte[length];
    this.Symmetric.Stream256Init(seed, nonce);
    this.Symmetric.Stream256SqueezeBlocks(numArray, 0, length);
    for (int off = Poly.RejectEta(this.Coeffs, 0, this.N, numArray, length, eta); off < 256 /*0x0100*/; off += Poly.RejectEta(this.Coeffs, off, this.N - off, numArray, this.Symmetric.Stream256BlockBytes, eta))
      this.Symmetric.Stream256SqueezeBlocks(numArray, 0, this.Symmetric.Stream256BlockBytes);
  }

  private static int RejectEta(int[] coeffs, int off, int len, byte[] buf, int buflen, int eta)
  {
    int index = 0;
    int num1 = 0;
    while (num1 < len && index < buflen)
    {
      uint num2 = (uint) ((int) buf[index] & (int) byte.MaxValue & 15);
      uint num3 = ((uint) buf[index++] & (uint) byte.MaxValue) >> 4;
      switch (eta)
      {
        case 2:
          if (num2 < 15U)
          {
            uint num4 = num2 - (205U * num2 >> 10) * 5U;
            coeffs[off + num1++] = 2 - (int) num4;
          }
          if (num3 < 15U && num1 < len)
          {
            uint num5 = num3 - (205U * num3 >> 10) * 5U;
            coeffs[off + num1++] = 2 - (int) num5;
            continue;
          }
          continue;
        case 4:
          if (num2 < 9U)
            coeffs[off + num1++] = 4 - (int) num2;
          if (num3 < 9U && num1 < len)
          {
            coeffs[off + num1++] = 4 - (int) num3;
            continue;
          }
          continue;
        default:
          continue;
      }
    }
    return num1;
  }

  public void PointwiseMontgomery(Poly v, Poly w)
  {
    for (int index = 0; index < this.N; ++index)
      this.Coeffs[index] = Reduce.MontgomeryReduce((long) v.Coeffs[index] * (long) w.Coeffs[index]);
  }

  public void PointwiseAccountMontgomery(PolyVecL u, PolyVecL v)
  {
    Poly a = new Poly(this.Engine);
    this.PointwiseMontgomery(u.Vec[0], v.Vec[0]);
    for (int index = 1; index < this.Engine.L; ++index)
    {
      a.PointwiseMontgomery(u.Vec[index], v.Vec[index]);
      this.AddPoly(a);
    }
  }

  public void AddPoly(Poly a)
  {
    for (int index = 0; index < this.N; ++index)
      this.Coeffs[index] += a.Coeffs[index];
  }

  public void Subtract(Poly b)
  {
    for (int index = 0; index < this.N; ++index)
      this.Coeffs[index] -= b.Coeffs[index];
  }

  public void ReducePoly()
  {
    for (int index = 0; index < this.N; ++index)
      this.Coeffs[index] = Reduce.Reduce32(this.Coeffs[index]);
  }

  public void PolyNtt() => Ntt.NTT(this.Coeffs);

  public void InverseNttToMont() => Ntt.InverseNttToMont(this.Coeffs);

  public void ConditionalAddQ()
  {
    for (int index = 0; index < this.N; ++index)
      this.Coeffs[index] = Reduce.ConditionalAddQ(this.Coeffs[index]);
  }

  public void Power2Round(Poly a)
  {
    for (int index = 0; index < this.N; ++index)
    {
      int[] numArray = Rounding.Power2Round(this.Coeffs[index]);
      this.Coeffs[index] = numArray[0];
      a.Coeffs[index] = numArray[1];
    }
  }

  public void PolyT0Pack(byte[] r, int off)
  {
    int[] numArray = new int[8];
    for (int index = 0; index < this.N / 8; ++index)
    {
      numArray[0] = 4096 /*0x1000*/ - this.Coeffs[8 * index];
      numArray[1] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 1];
      numArray[2] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 2];
      numArray[3] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 3];
      numArray[4] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 4];
      numArray[5] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 5];
      numArray[6] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 6];
      numArray[7] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 7];
      r[off + 13 * index] = (byte) numArray[0];
      r[off + 13 * index + 1] = (byte) (numArray[0] >> 8);
      r[off + 13 * index + 1] = (byte) ((uint) r[off + 13 * index + 1] | (uint) (byte) (numArray[1] << 5));
      r[off + 13 * index + 2] = (byte) (numArray[1] >> 3);
      r[off + 13 * index + 3] = (byte) (numArray[1] >> 11);
      r[off + 13 * index + 3] = (byte) ((uint) r[off + 13 * index + 3] | (uint) (byte) (numArray[2] << 2));
      r[off + 13 * index + 4] = (byte) (numArray[2] >> 6);
      r[off + 13 * index + 4] = (byte) ((uint) r[off + 13 * index + 4] | (uint) (byte) (numArray[3] << 7));
      r[off + 13 * index + 5] = (byte) (numArray[3] >> 1);
      r[off + 13 * index + 6] = (byte) (numArray[3] >> 9);
      r[off + 13 * index + 6] = (byte) ((uint) r[off + 13 * index + 6] | (uint) (byte) (numArray[4] << 4));
      r[off + 13 * index + 7] = (byte) (numArray[4] >> 4);
      r[off + 13 * index + 8] = (byte) (numArray[4] >> 12);
      r[off + 13 * index + 8] = (byte) ((uint) r[off + 13 * index + 8] | (uint) (byte) (numArray[5] << 1));
      r[off + 13 * index + 9] = (byte) (numArray[5] >> 7);
      r[off + 13 * index + 9] = (byte) ((uint) r[off + 13 * index + 9] | (uint) (byte) (numArray[6] << 6));
      r[off + 13 * index + 10] = (byte) (numArray[6] >> 2);
      r[off + 13 * index + 11] = (byte) (numArray[6] >> 10);
      r[off + 13 * index + 11] = (byte) ((uint) r[off + 13 * index + 11] | (uint) (byte) (numArray[7] << 3));
      r[off + 13 * index + 12] = (byte) (numArray[7] >> 5);
    }
  }

  public void PolyT0Unpack(byte[] a, int off)
  {
    for (int index = 0; index < this.N / 8; ++index)
    {
      this.Coeffs[8 * index] = ((int) a[off + 13 * index] & (int) byte.MaxValue | ((int) a[off + 13 * index + 1] & (int) byte.MaxValue) << 8) & 8191 /*0x1FFF*/;
      this.Coeffs[8 * index + 1] = (((int) a[off + 13 * index + 1] & (int) byte.MaxValue) >> 5 | ((int) a[off + 13 * index + 2] & (int) byte.MaxValue) << 3 | ((int) a[off + 13 * index + 3] & (int) byte.MaxValue) << 11) & 8191 /*0x1FFF*/;
      this.Coeffs[8 * index + 2] = (((int) a[off + 13 * index + 3] & (int) byte.MaxValue) >> 2 | ((int) a[off + 13 * index + 4] & (int) byte.MaxValue) << 6) & 8191 /*0x1FFF*/;
      this.Coeffs[8 * index + 3] = (((int) a[off + 13 * index + 4] & (int) byte.MaxValue) >> 7 | ((int) a[off + 13 * index + 5] & (int) byte.MaxValue) << 1 | ((int) a[off + 13 * index + 6] & (int) byte.MaxValue) << 9) & 8191 /*0x1FFF*/;
      this.Coeffs[8 * index + 4] = (((int) a[off + 13 * index + 6] & (int) byte.MaxValue) >> 4 | ((int) a[off + 13 * index + 7] & (int) byte.MaxValue) << 4 | ((int) a[off + 13 * index + 8] & (int) byte.MaxValue) << 12) & 8191 /*0x1FFF*/;
      this.Coeffs[8 * index + 5] = (((int) a[off + 13 * index + 8] & (int) byte.MaxValue) >> 1 | ((int) a[off + 13 * index + 9] & (int) byte.MaxValue) << 7) & 8191 /*0x1FFF*/;
      this.Coeffs[8 * index + 6] = (((int) a[off + 13 * index + 9] & (int) byte.MaxValue) >> 6 | ((int) a[off + 13 * index + 10] & (int) byte.MaxValue) << 2 | ((int) a[off + 13 * index + 11] & (int) byte.MaxValue) << 10) & 8191 /*0x1FFF*/;
      this.Coeffs[8 * index + 7] = (((int) a[off + 13 * index + 11] & (int) byte.MaxValue) >> 3 | ((int) a[off + 13 * index + 12] & (int) byte.MaxValue) << 5) & 8191 /*0x1FFF*/;
      this.Coeffs[8 * index] = 4096 /*0x1000*/ - this.Coeffs[8 * index];
      this.Coeffs[8 * index + 1] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 1];
      this.Coeffs[8 * index + 2] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 2];
      this.Coeffs[8 * index + 3] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 3];
      this.Coeffs[8 * index + 4] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 4];
      this.Coeffs[8 * index + 5] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 5];
      this.Coeffs[8 * index + 6] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 6];
      this.Coeffs[8 * index + 7] = 4096 /*0x1000*/ - this.Coeffs[8 * index + 7];
    }
  }

  public byte[] PolyT1Pack()
  {
    byte[] numArray = new byte[320];
    for (int index = 0; index < this.N / 4; ++index)
    {
      numArray[5 * index] = (byte) this.Coeffs[4 * index];
      numArray[5 * index + 1] = (byte) (this.Coeffs[4 * index] >> 8 | this.Coeffs[4 * index + 1] << 2);
      numArray[5 * index + 2] = (byte) (this.Coeffs[4 * index + 1] >> 6 | this.Coeffs[4 * index + 2] << 4);
      numArray[5 * index + 3] = (byte) (this.Coeffs[4 * index + 2] >> 4 | this.Coeffs[4 * index + 3] << 6);
      numArray[5 * index + 4] = (byte) (this.Coeffs[4 * index + 3] >> 2);
    }
    return numArray;
  }

  public void PolyT1Unpack(byte[] a)
  {
    for (int index = 0; index < this.N / 4; ++index)
    {
      this.Coeffs[4 * index] = ((int) a[5 * index] & (int) byte.MaxValue | ((int) a[5 * index + 1] & (int) byte.MaxValue) << 8) & 1023 /*0x03FF*/;
      this.Coeffs[4 * index + 1] = (((int) a[5 * index + 1] & (int) byte.MaxValue) >> 2 | ((int) a[5 * index + 2] & (int) byte.MaxValue) << 6) & 1023 /*0x03FF*/;
      this.Coeffs[4 * index + 2] = (((int) a[5 * index + 2] & (int) byte.MaxValue) >> 4 | ((int) a[5 * index + 3] & (int) byte.MaxValue) << 4) & 1023 /*0x03FF*/;
      this.Coeffs[4 * index + 3] = (((int) a[5 * index + 3] & (int) byte.MaxValue) >> 6 | ((int) a[5 * index + 4] & (int) byte.MaxValue) << 2) & 1023 /*0x03FF*/;
    }
  }

  public void PolyEtaPack(byte[] r, int off)
  {
    byte[] numArray = new byte[8];
    if (this.Engine.Eta == 2)
    {
      for (int index = 0; index < this.N / 8; ++index)
      {
        numArray[0] = (byte) (this.Engine.Eta - this.Coeffs[8 * index]);
        numArray[1] = (byte) (this.Engine.Eta - this.Coeffs[8 * index + 1]);
        numArray[2] = (byte) (this.Engine.Eta - this.Coeffs[8 * index + 2]);
        numArray[3] = (byte) (this.Engine.Eta - this.Coeffs[8 * index + 3]);
        numArray[4] = (byte) (this.Engine.Eta - this.Coeffs[8 * index + 4]);
        numArray[5] = (byte) (this.Engine.Eta - this.Coeffs[8 * index + 5]);
        numArray[6] = (byte) (this.Engine.Eta - this.Coeffs[8 * index + 6]);
        numArray[7] = (byte) (this.Engine.Eta - this.Coeffs[8 * index + 7]);
        r[off + 3 * index] = (byte) ((int) numArray[0] | (int) numArray[1] << 3 | (int) numArray[2] << 6);
        r[off + 3 * index + 1] = (byte) ((int) numArray[2] >> 2 | (int) numArray[3] << 1 | (int) numArray[4] << 4 | (int) numArray[5] << 7);
        r[off + 3 * index + 2] = (byte) ((int) numArray[5] >> 1 | (int) numArray[6] << 2 | (int) numArray[7] << 5);
      }
    }
    else
    {
      if (this.Engine.Eta != 4)
        throw new ArgumentException("Eta needs to be 2 or 4!");
      for (int index = 0; index < this.N / 2; ++index)
      {
        numArray[0] = (byte) (this.Engine.Eta - this.Coeffs[2 * index]);
        numArray[1] = (byte) (this.Engine.Eta - this.Coeffs[2 * index + 1]);
        r[off + index] = (byte) ((uint) numArray[0] | (uint) numArray[1] << 4);
      }
    }
  }

  public void PolyEtaUnpack(byte[] a, int off)
  {
    int eta = this.Engine.Eta;
    switch (eta)
    {
      case 2:
        for (int index = 0; index < this.N / 8; ++index)
        {
          this.Coeffs[8 * index] = (int) a[off + 3 * index] & (int) byte.MaxValue & 7;
          this.Coeffs[8 * index + 1] = ((int) a[off + 3 * index] & (int) byte.MaxValue) >> 3 & 7;
          this.Coeffs[8 * index + 2] = ((int) a[off + 3 * index] & (int) byte.MaxValue) >> 6 | ((int) a[off + 3 * index + 1] & (int) byte.MaxValue) << 2 & 7;
          this.Coeffs[8 * index + 3] = ((int) a[off + 3 * index + 1] & (int) byte.MaxValue) >> 1 & 7;
          this.Coeffs[8 * index + 4] = ((int) a[off + 3 * index + 1] & (int) byte.MaxValue) >> 4 & 7;
          this.Coeffs[8 * index + 5] = ((int) a[off + 3 * index + 1] & (int) byte.MaxValue) >> 7 | ((int) a[off + 3 * index + 2] & (int) byte.MaxValue) << 1 & 7;
          this.Coeffs[8 * index + 6] = ((int) a[off + 3 * index + 2] & (int) byte.MaxValue) >> 2 & 7;
          this.Coeffs[8 * index + 7] = ((int) a[off + 3 * index + 2] & (int) byte.MaxValue) >> 5 & 7;
          this.Coeffs[8 * index] = eta - this.Coeffs[8 * index];
          this.Coeffs[8 * index + 1] = eta - this.Coeffs[8 * index + 1];
          this.Coeffs[8 * index + 2] = eta - this.Coeffs[8 * index + 2];
          this.Coeffs[8 * index + 3] = eta - this.Coeffs[8 * index + 3];
          this.Coeffs[8 * index + 4] = eta - this.Coeffs[8 * index + 4];
          this.Coeffs[8 * index + 5] = eta - this.Coeffs[8 * index + 5];
          this.Coeffs[8 * index + 6] = eta - this.Coeffs[8 * index + 6];
          this.Coeffs[8 * index + 7] = eta - this.Coeffs[8 * index + 7];
        }
        break;
      case 4:
        for (int index = 0; index < this.N / 2; ++index)
        {
          this.Coeffs[2 * index] = (int) a[off + index] & (int) byte.MaxValue & 15;
          this.Coeffs[2 * index + 1] = ((int) a[off + index] & (int) byte.MaxValue) >> 4;
          this.Coeffs[2 * index] = eta - this.Coeffs[2 * index];
          this.Coeffs[2 * index + 1] = eta - this.Coeffs[2 * index + 1];
        }
        break;
    }
  }

  public void UniformGamma1(byte[] seed, ushort nonce)
  {
    byte[] numArray = new byte[this.Engine.PolyUniformGamma1NBytes * this.Symmetric.Stream256BlockBytes];
    this.Symmetric.Stream256Init(seed, nonce);
    this.Symmetric.Stream256SqueezeBlocks(numArray, 0, numArray.Length);
    this.UnpackZ(numArray);
  }

  public void PackZ(byte[] r, int offset)
  {
    uint[] numArray = new uint[4];
    if (this.Engine.Gamma1 == 131072 /*0x020000*/)
    {
      for (int index = 0; index < this.N / 4; ++index)
      {
        numArray[0] = (uint) (this.Engine.Gamma1 - this.Coeffs[4 * index]);
        numArray[1] = (uint) (this.Engine.Gamma1 - this.Coeffs[4 * index + 1]);
        numArray[2] = (uint) (this.Engine.Gamma1 - this.Coeffs[4 * index + 2]);
        numArray[3] = (uint) (this.Engine.Gamma1 - this.Coeffs[4 * index + 3]);
        r[offset + 9 * index] = (byte) numArray[0];
        r[offset + 9 * index + 1] = (byte) (numArray[0] >> 8);
        r[offset + 9 * index + 2] = (byte) ((uint) (byte) (numArray[0] >> 16 /*0x10*/) | numArray[1] << 2);
        r[offset + 9 * index + 3] = (byte) (numArray[1] >> 6);
        r[offset + 9 * index + 4] = (byte) ((uint) (byte) (numArray[1] >> 14) | numArray[2] << 4);
        r[offset + 9 * index + 5] = (byte) (numArray[2] >> 4);
        r[offset + 9 * index + 6] = (byte) ((uint) (byte) (numArray[2] >> 12) | numArray[3] << 6);
        r[offset + 9 * index + 7] = (byte) (numArray[3] >> 2);
        r[offset + 9 * index + 8] = (byte) (numArray[3] >> 10);
      }
    }
    else
    {
      if (this.Engine.Gamma1 != 524288 /*0x080000*/)
        throw new ArgumentException("Wrong Dilithium Gamma1!");
      for (int index = 0; index < this.N / 2; ++index)
      {
        numArray[0] = (uint) (this.Engine.Gamma1 - this.Coeffs[2 * index]);
        numArray[1] = (uint) (this.Engine.Gamma1 - this.Coeffs[2 * index + 1]);
        r[offset + 5 * index] = (byte) numArray[0];
        r[offset + 5 * index + 1] = (byte) (numArray[0] >> 8);
        r[offset + 5 * index + 2] = (byte) ((uint) (byte) (numArray[0] >> 16 /*0x10*/) | numArray[1] << 4);
        r[offset + 5 * index + 3] = (byte) (numArray[1] >> 4);
        r[offset + 5 * index + 4] = (byte) (numArray[1] >> 12);
      }
    }
  }

  public void UnpackZ(byte[] a)
  {
    if (this.Engine.Gamma1 == 131072 /*0x020000*/)
    {
      for (int index = 0; index < this.N / 4; ++index)
      {
        this.Coeffs[4 * index] = ((int) a[9 * index] & (int) byte.MaxValue | ((int) a[9 * index + 1] & (int) byte.MaxValue) << 8 | ((int) a[9 * index + 2] & (int) byte.MaxValue) << 16 /*0x10*/) & 262143 /*0x03FFFF*/;
        this.Coeffs[4 * index + 1] = (((int) a[9 * index + 2] & (int) byte.MaxValue) >> 2 | ((int) a[9 * index + 3] & (int) byte.MaxValue) << 6 | ((int) a[9 * index + 4] & (int) byte.MaxValue) << 14) & 262143 /*0x03FFFF*/;
        this.Coeffs[4 * index + 2] = (((int) a[9 * index + 4] & (int) byte.MaxValue) >> 4 | ((int) a[9 * index + 5] & (int) byte.MaxValue) << 4 | ((int) a[9 * index + 6] & (int) byte.MaxValue) << 12) & 262143 /*0x03FFFF*/;
        this.Coeffs[4 * index + 3] = (((int) a[9 * index + 6] & (int) byte.MaxValue) >> 6 | ((int) a[9 * index + 7] & (int) byte.MaxValue) << 2 | ((int) a[9 * index + 8] & (int) byte.MaxValue) << 10) & 262143 /*0x03FFFF*/;
        this.Coeffs[4 * index] = this.Engine.Gamma1 - this.Coeffs[4 * index];
        this.Coeffs[4 * index + 1] = this.Engine.Gamma1 - this.Coeffs[4 * index + 1];
        this.Coeffs[4 * index + 2] = this.Engine.Gamma1 - this.Coeffs[4 * index + 2];
        this.Coeffs[4 * index + 3] = this.Engine.Gamma1 - this.Coeffs[4 * index + 3];
      }
    }
    else
    {
      if (this.Engine.Gamma1 != 524288 /*0x080000*/)
        throw new ArgumentException("Wrong Dilithiumn Gamma1!");
      for (int index = 0; index < this.N / 2; ++index)
      {
        this.Coeffs[2 * index] = ((int) a[5 * index] & (int) byte.MaxValue | ((int) a[5 * index + 1] & (int) byte.MaxValue) << 8 | ((int) a[5 * index + 2] & (int) byte.MaxValue) << 16 /*0x10*/) & 1048575 /*0x0FFFFF*/;
        this.Coeffs[2 * index + 1] = (((int) a[5 * index + 2] & (int) byte.MaxValue) >> 4 | ((int) a[5 * index + 3] & (int) byte.MaxValue) << 4 | ((int) a[5 * index + 4] & (int) byte.MaxValue) << 12) & 1048575 /*0x0FFFFF*/;
        this.Coeffs[2 * index] = this.Engine.Gamma1 - this.Coeffs[2 * index];
        this.Coeffs[2 * index + 1] = this.Engine.Gamma1 - this.Coeffs[2 * index + 1];
      }
    }
  }

  public void Decompose(Poly a)
  {
    for (int index = 0; index < this.N; ++index)
    {
      int[] numArray = Rounding.Decompose(this.Coeffs[index], this.Engine.Gamma2);
      a.Coeffs[index] = numArray[0];
      this.Coeffs[index] = numArray[1];
    }
  }

  public void PackW1(byte[] r, int off)
  {
    if (this.Engine.Gamma2 == 95232)
    {
      for (int index = 0; index < this.N / 4; ++index)
      {
        r[off + 3 * index] = (byte) ((uint) (byte) this.Coeffs[4 * index] | (uint) (this.Coeffs[4 * index + 1] << 6));
        r[off + 3 * index + 1] = (byte) ((uint) (byte) (this.Coeffs[4 * index + 1] >> 2) | (uint) (this.Coeffs[4 * index + 2] << 4));
        r[off + 3 * index + 2] = (byte) ((uint) (byte) (this.Coeffs[4 * index + 2] >> 4) | (uint) (this.Coeffs[4 * index + 3] << 2));
      }
    }
    else
    {
      if (this.Engine.Gamma2 != 261888)
        return;
      for (int index = 0; index < this.N / 2; ++index)
        r[off + index] = (byte) (this.Coeffs[2 * index] | this.Coeffs[2 * index + 1] << 4);
    }
  }

  public void Challenge(byte[] seed)
  {
    byte[] output = new byte[this.Symmetric.Stream256BlockBytes];
    ShakeDigest shakeDigest = new ShakeDigest(256 /*0x0100*/);
    shakeDigest.BlockUpdate(seed, 0, 32 /*0x20*/);
    shakeDigest.Output(output, 0, this.Symmetric.Stream256BlockBytes);
    ulong num1 = 0;
    for (int index = 0; index < 8; ++index)
      num1 |= (ulong) ((int) output[index] & (int) byte.MaxValue) << 8 * index;
    int num2 = 8;
    for (int index = 0; index < this.N; ++index)
      this.Coeffs[index] = 0;
    for (int index1 = this.N - this.Engine.Tau; index1 < this.N; ++index1)
    {
      int index2;
      do
      {
        if (num2 >= this.Symmetric.Stream256BlockBytes)
          goto label_8;
label_7:
        index2 = (int) output[num2++] & (int) byte.MaxValue;
        continue;
label_8:
        shakeDigest.Output(output, 0, this.Symmetric.Stream256BlockBytes);
        num2 = 0;
        goto label_7;
      }
      while (index2 > index1);
      this.Coeffs[index1] = this.Coeffs[index2];
      this.Coeffs[index2] = (int) (1L - 2L * ((long) num1 & 1L));
      num1 >>= 1;
    }
  }

  public bool CheckNorm(int B)
  {
    if (B > 1047552)
      return true;
    for (int index = 0; index < this.N; ++index)
    {
      int num = this.Coeffs[index] >> 31 /*0x1F*/;
      if (this.Coeffs[index] - (num & 2 * this.Coeffs[index]) >= B)
        return true;
    }
    return false;
  }

  public int PolyMakeHint(Poly a0, Poly a1)
  {
    int num = 0;
    for (int index = 0; index < this.N; ++index)
    {
      this.Coeffs[index] = Rounding.MakeHint(a0.Coeffs[index], a1.Coeffs[index], this.Engine);
      num += this.Coeffs[index];
    }
    return num;
  }

  public void PolyUseHint(Poly a, Poly h)
  {
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      this.Coeffs[index] = Rounding.UseHint(a.Coeffs[index], h.Coeffs[index], this.Engine.Gamma2);
  }

  public void ShiftLeft()
  {
    for (int index = 0; index < this.N; ++index)
      this.Coeffs[index] <<= 13;
  }
}
