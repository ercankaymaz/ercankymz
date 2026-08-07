// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials.HrssPolynomial
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;

internal class HrssPolynomial : Polynomial
{
  internal HrssPolynomial(NtruParameterSet parameterSet)
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
      bytes[13 * num] = (byte) ((uint) numArray[0] & (uint) byte.MaxValue);
      bytes[13 * num + 1] = (byte) ((int) numArray[0] >> 8 | ((int) numArray[1] & 7) << 5);
      bytes[13 * num + 2] = (byte) ((int) numArray[1] >> 3 & (int) byte.MaxValue);
      bytes[13 * num + 3] = (byte) ((int) numArray[1] >> 11 | ((int) numArray[2] & 63 /*0x3F*/) << 2);
      bytes[13 * num + 4] = (byte) ((int) numArray[2] >> 6 | ((int) numArray[3] & 1) << 7);
      bytes[13 * num + 5] = (byte) ((int) numArray[3] >> 1 & (int) byte.MaxValue);
      bytes[13 * num + 6] = (byte) ((int) numArray[3] >> 9 | ((int) numArray[4] & 15) << 4);
      bytes[13 * num + 7] = (byte) ((int) numArray[4] >> 4 & (int) byte.MaxValue);
      bytes[13 * num + 8] = (byte) ((int) numArray[4] >> 12 | ((int) numArray[5] & (int) sbyte.MaxValue) << 1);
      bytes[13 * num + 9] = (byte) ((int) numArray[5] >> 7 | ((int) numArray[6] & 3) << 6);
      bytes[13 * num + 10] = (byte) ((int) numArray[6] >> 2 & (int) byte.MaxValue);
      bytes[13 * num + 11] = (byte) ((int) numArray[6] >> 10 | ((int) numArray[7] & 31 /*0x1F*/) << 3);
      bytes[13 * num + 12] = (byte) ((uint) numArray[7] >> 5);
    }
    int index1;
    for (index1 = 0; index1 < this.ParameterSet.PackDegree() - 8 * num; ++index1)
      numArray[index1] = (short) Polynomial.ModQ((uint) this.coeffs[8 * num + index1] & (uint) ushort.MaxValue, (uint) this.ParameterSet.Q());
    for (; index1 < 8; ++index1)
      numArray[index1] = (short) 0;
    switch (this.ParameterSet.PackDegree() - 8 * (this.ParameterSet.PackDegree() / 8))
    {
      case 2:
        bytes[13 * num] = (byte) ((uint) numArray[0] & (uint) byte.MaxValue);
        bytes[13 * num + 1] = (byte) ((int) numArray[0] >> 8 | ((int) numArray[1] & 7) << 5);
        bytes[13 * num + 2] = (byte) ((int) numArray[1] >> 3 & (int) byte.MaxValue);
        bytes[13 * num + 3] = (byte) ((int) numArray[1] >> 11 | ((int) numArray[2] & 63 /*0x3F*/) << 2);
        break;
      case 4:
        bytes[13 * num] = (byte) ((uint) numArray[0] & (uint) byte.MaxValue);
        bytes[13 * num + 1] = (byte) ((int) numArray[0] >> 8 | ((int) numArray[1] & 7) << 5);
        bytes[13 * num + 2] = (byte) ((int) numArray[1] >> 3 & (int) byte.MaxValue);
        bytes[13 * num + 3] = (byte) ((int) numArray[1] >> 11 | ((int) numArray[2] & 63 /*0x3F*/) << 2);
        bytes[13 * num + 4] = (byte) ((int) numArray[2] >> 6 | ((int) numArray[3] & 1) << 7);
        bytes[13 * num + 5] = (byte) ((int) numArray[3] >> 1 & (int) byte.MaxValue);
        bytes[13 * num + 6] = (byte) ((int) numArray[3] >> 9 | ((int) numArray[4] & 15) << 4);
        break;
    }
    return bytes;
  }

  public override void SqFromBytes(byte[] a)
  {
    int num;
    for (num = 0; num < this.ParameterSet.PackDegree() / 8; ++num)
    {
      this.coeffs[8 * num] = (ushort) ((int) a[13 * num] & (int) byte.MaxValue | ((int) (ushort) ((uint) a[13 * num + 1] & (uint) byte.MaxValue) & 31 /*0x1F*/) << 8);
      this.coeffs[8 * num + 1] = (ushort) (((int) a[13 * num + 1] & (int) byte.MaxValue) >> 5 | (int) (ushort) ((uint) a[13 * num + 2] & (uint) byte.MaxValue) << 3 | ((int) (short) ((int) a[13 * num + 3] & (int) byte.MaxValue) & 3) << 11);
      this.coeffs[8 * num + 2] = (ushort) (((int) a[13 * num + 3] & (int) byte.MaxValue) >> 2 | ((int) (ushort) ((uint) a[13 * num + 4] & (uint) byte.MaxValue) & (int) sbyte.MaxValue) << 6);
      this.coeffs[8 * num + 3] = (ushort) (((int) a[13 * num + 4] & (int) byte.MaxValue) >> 7 | (int) (ushort) ((uint) a[13 * num + 5] & (uint) byte.MaxValue) << 1 | ((int) (short) ((int) a[13 * num + 6] & (int) byte.MaxValue) & 15) << 9);
      this.coeffs[8 * num + 4] = (ushort) (((int) a[13 * num + 6] & (int) byte.MaxValue) >> 4 | (int) (ushort) ((uint) a[13 * num + 7] & (uint) byte.MaxValue) << 4 | ((int) (short) ((int) a[13 * num + 8] & (int) byte.MaxValue) & 1) << 12);
      this.coeffs[8 * num + 5] = (ushort) (((int) a[13 * num + 8] & (int) byte.MaxValue) >> 1 | ((int) (ushort) ((uint) a[13 * num + 9] & (uint) byte.MaxValue) & 63 /*0x3F*/) << 7);
      this.coeffs[8 * num + 6] = (ushort) (((int) a[13 * num + 9] & (int) byte.MaxValue) >> 6 | (int) (ushort) ((uint) a[13 * num + 10] & (uint) byte.MaxValue) << 2 | ((int) (short) ((int) a[13 * num + 11] & (int) byte.MaxValue) & 7) << 10);
      this.coeffs[8 * num + 7] = (ushort) (((int) a[13 * num + 11] & (int) byte.MaxValue) >> 3 | (int) (ushort) ((uint) a[13 * num + 12] & (uint) byte.MaxValue) << 5);
    }
    switch (this.ParameterSet.PackDegree() & 7)
    {
      case 2:
        this.coeffs[8 * num] = (ushort) ((int) a[13 * num] & (int) byte.MaxValue | ((int) (short) ((int) a[13 * num + 1] & (int) byte.MaxValue) & 31 /*0x1F*/) << 8);
        this.coeffs[8 * num + 1] = (ushort) (((int) a[13 * num + 1] & (int) byte.MaxValue) >> 5 | (int) (short) ((int) a[13 * num + 2] & (int) byte.MaxValue) << 3 | ((int) (short) ((int) a[13 * num + 3] & (int) byte.MaxValue) & 3) << 11);
        break;
      case 4:
        this.coeffs[8 * num] = (ushort) ((int) a[13 * num] & (int) byte.MaxValue | ((int) (short) ((int) a[13 * num + 1] & (int) byte.MaxValue) & 31 /*0x1F*/) << 8);
        this.coeffs[8 * num + 1] = (ushort) (((int) a[13 * num + 1] & (int) byte.MaxValue) >> 5 | (int) (short) ((int) a[13 * num + 2] & (int) byte.MaxValue) << 3 | ((int) (short) ((int) a[13 * num + 3] & (int) byte.MaxValue) & 3) << 11);
        this.coeffs[8 * num + 2] = (ushort) (((int) a[13 * num + 3] & (int) byte.MaxValue) >> 2 | ((int) (short) ((int) a[13 * num + 4] & (int) byte.MaxValue) & (int) sbyte.MaxValue) << 6);
        this.coeffs[8 * num + 3] = (ushort) (((int) a[13 * num + 4] & (int) byte.MaxValue) >> 7 | (int) (short) ((int) a[13 * num + 5] & (int) byte.MaxValue) << 1 | ((int) (short) ((int) a[13 * num + 6] & (int) byte.MaxValue) & 15) << 9);
        break;
    }
    this.coeffs[this.ParameterSet.N - 1] = (ushort) 0;
  }

  public override void Lift(Polynomial a)
  {
    int length = this.coeffs.Length;
    HrssPolynomial hrssPolynomial = new HrssPolynomial(this.ParameterSet);
    ushort num1 = (ushort) (3 - length % 3);
    hrssPolynomial.coeffs[0] = (ushort) ((int) a.coeffs[0] * (2 - (int) num1) + 0 + (int) a.coeffs[2] * (int) num1);
    hrssPolynomial.coeffs[1] = (ushort) ((int) a.coeffs[1] * (2 - (int) num1) + 0);
    hrssPolynomial.coeffs[2] = (ushort) ((uint) a.coeffs[2] * (2U - (uint) num1));
    ushort num2 = 0;
    for (int index = 3; index < length; ++index)
    {
      hrssPolynomial.coeffs[0] += (ushort) ((uint) a.coeffs[index] * ((uint) num2 + 2U * (uint) num1));
      hrssPolynomial.coeffs[1] += (ushort) ((uint) a.coeffs[index] * ((uint) num2 + (uint) num1));
      hrssPolynomial.coeffs[2] += (ushort) ((uint) a.coeffs[index] * (uint) num2);
      num2 = (ushort) (((int) num2 + (int) num1) % 3);
    }
    hrssPolynomial.coeffs[1] += (ushort) ((uint) a.coeffs[0] * ((uint) num2 + (uint) num1));
    hrssPolynomial.coeffs[2] += (ushort) ((uint) a.coeffs[0] * (uint) num2);
    hrssPolynomial.coeffs[2] += (ushort) ((uint) a.coeffs[1] * ((uint) num2 + (uint) num1));
    for (int index = 3; index < length; ++index)
      hrssPolynomial.coeffs[index] = (ushort) ((uint) hrssPolynomial.coeffs[index - 3] + (uint) (2 * ((int) a.coeffs[index] + (int) a.coeffs[index - 1] + (int) a.coeffs[index - 2])));
    hrssPolynomial.Mod3PhiN();
    hrssPolynomial.Z3ToZq();
    this.coeffs[0] = -hrssPolynomial.coeffs[0];
    for (int index = 0; index < length - 1; ++index)
      this.coeffs[index + 1] = (ushort) ((uint) hrssPolynomial.coeffs[index] - (uint) hrssPolynomial.coeffs[index + 1]);
  }

  public override void R2Inv(Polynomial a)
  {
    HrssPolynomial f = new HrssPolynomial(this.ParameterSet);
    HrssPolynomial g = new HrssPolynomial(this.ParameterSet);
    HrssPolynomial v = new HrssPolynomial(this.ParameterSet);
    HrssPolynomial w = new HrssPolynomial(this.ParameterSet);
    this.R2Inv(a, (Polynomial) f, (Polynomial) g, (Polynomial) v, (Polynomial) w);
  }

  public override void RqInv(Polynomial a)
  {
    HrssPolynomial ai2 = new HrssPolynomial(this.ParameterSet);
    HrssPolynomial b = new HrssPolynomial(this.ParameterSet);
    HrssPolynomial c = new HrssPolynomial(this.ParameterSet);
    HrssPolynomial s = new HrssPolynomial(this.ParameterSet);
    this.RqInv(a, (Polynomial) ai2, (Polynomial) b, (Polynomial) c, (Polynomial) s);
  }

  public override void S3Inv(Polynomial a)
  {
    HrssPolynomial f = new HrssPolynomial(this.ParameterSet);
    HrssPolynomial g = new HrssPolynomial(this.ParameterSet);
    HrssPolynomial v = new HrssPolynomial(this.ParameterSet);
    HrssPolynomial w = new HrssPolynomial(this.ParameterSet);
    this.S3Inv(a, (Polynomial) f, (Polynomial) g, (Polynomial) v, (Polynomial) w);
  }
}
