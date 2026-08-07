// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials.HpsPolynomial
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;

internal class HpsPolynomial : Polynomial
{
  internal HpsPolynomial(NtruParameterSet parameterSet)
    : base(parameterSet)
  {
  }

  public override byte[] SqToBytes(int len)
  {
    byte[] bytes = new byte[len];
    short[] numArray = new short[8];
    int num;
    for (num = 0; num < this.ParameterSet.PackDegree() / 8; ++num)
    {
      for (int index = 0; index < 8; ++index)
        numArray[index] = (short) Polynomial.ModQ((uint) this.coeffs[8 * num + index] & (uint) ushort.MaxValue, (uint) this.ParameterSet.Q());
      bytes[11 * num] = (byte) ((uint) numArray[0] & (uint) byte.MaxValue);
      bytes[11 * num + 1] = (byte) ((int) numArray[0] >> 8 | ((int) numArray[1] & 31 /*0x1F*/) << 3);
      bytes[11 * num + 2] = (byte) ((int) numArray[1] >> 5 | ((int) numArray[2] & 3) << 6);
      bytes[11 * num + 3] = (byte) ((int) numArray[2] >> 2 & (int) byte.MaxValue);
      bytes[11 * num + 4] = (byte) ((int) numArray[2] >> 10 | ((int) numArray[3] & (int) sbyte.MaxValue) << 1);
      bytes[11 * num + 5] = (byte) ((int) numArray[3] >> 7 | ((int) numArray[4] & 15) << 4);
      bytes[11 * num + 6] = (byte) ((int) numArray[4] >> 4 | ((int) numArray[5] & 1) << 7);
      bytes[11 * num + 7] = (byte) ((int) numArray[5] >> 1 & (int) byte.MaxValue);
      bytes[11 * num + 8] = (byte) ((int) numArray[5] >> 9 | ((int) numArray[6] & 63 /*0x3F*/) << 2);
      bytes[11 * num + 9] = (byte) ((int) numArray[6] >> 6 | ((int) numArray[7] & 7) << 5);
      bytes[11 * num + 10] = (byte) ((uint) numArray[7] >> 3);
    }
    int index1;
    for (index1 = 0; index1 < this.ParameterSet.PackDegree() - 8 * num; ++index1)
      numArray[index1] = (short) Polynomial.ModQ((uint) this.coeffs[8 * num + index1] & (uint) ushort.MaxValue, (uint) this.ParameterSet.Q());
    for (; index1 < 8; ++index1)
      numArray[index1] = (short) 0;
    switch (this.ParameterSet.PackDegree() & 7)
    {
      case 2:
        bytes[11 * num] = (byte) ((uint) numArray[0] & (uint) byte.MaxValue);
        bytes[11 * num + 1] = (byte) ((int) numArray[0] >> 8 | ((int) numArray[1] & 31 /*0x1F*/) << 3);
        bytes[11 * num + 2] = (byte) ((int) numArray[1] >> 5 | ((int) numArray[2] & 3) << 6);
        break;
      case 4:
        bytes[11 * num] = (byte) ((uint) numArray[0] & (uint) byte.MaxValue);
        bytes[11 * num + 1] = (byte) ((int) numArray[0] >> 8 | ((int) numArray[1] & 31 /*0x1F*/) << 3);
        bytes[11 * num + 2] = (byte) ((int) numArray[1] >> 5 | ((int) numArray[2] & 3) << 6);
        bytes[11 * num + 3] = (byte) ((int) numArray[2] >> 2 & (int) byte.MaxValue);
        bytes[11 * num + 4] = (byte) ((int) numArray[2] >> 10 | ((int) numArray[3] & (int) sbyte.MaxValue) << 1);
        bytes[11 * num + 5] = (byte) ((int) numArray[3] >> 7 | ((int) numArray[4] & 15) << 4);
        break;
    }
    return bytes;
  }

  public override void SqFromBytes(byte[] a)
  {
    int length = this.coeffs.Length;
    int num;
    for (num = 0; num < this.ParameterSet.PackDegree() / 8; ++num)
    {
      this.coeffs[8 * num] = (ushort) ((int) a[11 * num] & (int) byte.MaxValue | ((int) (ushort) ((uint) a[11 * num + 1] & (uint) byte.MaxValue) & 7) << 8);
      this.coeffs[8 * num + 1] = (ushort) (((int) a[11 * num + 1] & (int) byte.MaxValue) >> 3 | ((int) (ushort) ((uint) a[11 * num + 2] & (uint) byte.MaxValue) & 63 /*0x3F*/) << 5);
      this.coeffs[8 * num + 2] = (ushort) (((int) a[11 * num + 2] & (int) byte.MaxValue) >> 6 | ((int) (ushort) ((uint) a[11 * num + 3] & (uint) byte.MaxValue) & (int) byte.MaxValue) << 2 | ((int) (ushort) ((uint) a[11 * num + 4] & (uint) byte.MaxValue) & 1) << 10);
      this.coeffs[8 * num + 3] = (ushort) (((int) a[11 * num + 4] & (int) byte.MaxValue) >> 1 | ((int) (ushort) ((uint) a[11 * num + 5] & (uint) byte.MaxValue) & 15) << 7);
      this.coeffs[8 * num + 4] = (ushort) (((int) a[11 * num + 5] & (int) byte.MaxValue) >> 4 | ((int) (ushort) ((uint) a[11 * num + 6] & (uint) byte.MaxValue) & (int) sbyte.MaxValue) << 4);
      this.coeffs[8 * num + 5] = (ushort) (((int) a[11 * num + 6] & (int) byte.MaxValue) >> 7 | ((int) (ushort) ((uint) a[11 * num + 7] & (uint) byte.MaxValue) & (int) byte.MaxValue) << 1 | ((int) (ushort) ((uint) a[11 * num + 8] & (uint) byte.MaxValue) & 3) << 9);
      this.coeffs[8 * num + 6] = (ushort) (((int) a[11 * num + 8] & (int) byte.MaxValue) >> 2 | ((int) (ushort) ((uint) a[11 * num + 9] & (uint) byte.MaxValue) & 31 /*0x1F*/) << 6);
      this.coeffs[8 * num + 7] = (ushort) (((int) a[11 * num + 9] & (int) byte.MaxValue) >> 5 | ((int) (ushort) ((uint) a[11 * num + 10] & (uint) byte.MaxValue) & (int) byte.MaxValue) << 3);
    }
    switch (this.ParameterSet.PackDegree() & 7)
    {
      case 2:
        this.coeffs[8 * num] = (ushort) ((int) a[11 * num] & (int) byte.MaxValue | ((int) (ushort) ((uint) a[11 * num + 1] & (uint) byte.MaxValue) & 7) << 8);
        this.coeffs[8 * num + 1] = (ushort) (((int) a[11 * num + 1] & (int) byte.MaxValue) >> 3 | ((int) (ushort) ((uint) a[11 * num + 2] & (uint) byte.MaxValue) & 63 /*0x3F*/) << 5);
        break;
      case 4:
        this.coeffs[8 * num] = (ushort) ((int) a[11 * num] & (int) byte.MaxValue | ((int) (ushort) ((uint) a[11 * num + 1] & (uint) byte.MaxValue) & 7) << 8);
        this.coeffs[8 * num + 1] = (ushort) (((int) a[11 * num + 1] & (int) byte.MaxValue) >> 3 | ((int) (ushort) ((uint) a[11 * num + 2] & (uint) byte.MaxValue) & 63 /*0x3F*/) << 5);
        this.coeffs[8 * num + 2] = (ushort) (((int) a[11 * num + 2] & (int) byte.MaxValue) >> 6 | ((int) (ushort) ((uint) a[11 * num + 3] & (uint) byte.MaxValue) & (int) byte.MaxValue) << 2 | ((int) (ushort) ((uint) a[11 * num + 4] & (uint) byte.MaxValue) & 1) << 10);
        this.coeffs[8 * num + 3] = (ushort) (((int) a[11 * num + 4] & (int) byte.MaxValue) >> 1 | ((int) (ushort) ((uint) a[11 * num + 5] & (uint) byte.MaxValue) & 15) << 7);
        break;
    }
    this.coeffs[length - 1] = (ushort) 0;
  }

  public override void Lift(Polynomial a)
  {
    int length = this.coeffs.Length;
    Array.Copy((Array) a.coeffs, 0, (Array) this.coeffs, 0, length);
    this.Z3ToZq();
  }

  public override void R2Inv(Polynomial a)
  {
    HpsPolynomial f = new HpsPolynomial(this.ParameterSet);
    HpsPolynomial g = new HpsPolynomial(this.ParameterSet);
    HpsPolynomial v = new HpsPolynomial(this.ParameterSet);
    HpsPolynomial w = new HpsPolynomial(this.ParameterSet);
    this.R2Inv(a, (Polynomial) f, (Polynomial) g, (Polynomial) v, (Polynomial) w);
  }

  public override void RqInv(Polynomial a)
  {
    HpsPolynomial ai2 = new HpsPolynomial(this.ParameterSet);
    HpsPolynomial b = new HpsPolynomial(this.ParameterSet);
    HpsPolynomial c = new HpsPolynomial(this.ParameterSet);
    HpsPolynomial s = new HpsPolynomial(this.ParameterSet);
    this.RqInv(a, (Polynomial) ai2, (Polynomial) b, (Polynomial) c, (Polynomial) s);
  }

  public override void S3Inv(Polynomial a)
  {
    HpsPolynomial f = new HpsPolynomial(this.ParameterSet);
    HpsPolynomial g = new HpsPolynomial(this.ParameterSet);
    HpsPolynomial v = new HpsPolynomial(this.ParameterSet);
    HpsPolynomial w = new HpsPolynomial(this.ParameterSet);
    this.S3Inv(a, (Polynomial) f, (Polynomial) g, (Polynomial) v, (Polynomial) w);
  }
}
