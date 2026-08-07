// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials.Hps4096Polynomial
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;

internal class Hps4096Polynomial : HpsPolynomial
{
  internal Hps4096Polynomial(NtruParameterSet parameterSet)
    : base(parameterSet)
  {
  }

  public override byte[] SqToBytes(int len)
  {
    byte[] bytes = new byte[len];
    uint q = (uint) this.ParameterSet.Q();
    for (int index = 0; index < this.ParameterSet.PackDegree() / 2; ++index)
    {
      bytes[3 * index] = (byte) (Polynomial.ModQ((uint) this.coeffs[2 * index] & (uint) ushort.MaxValue, q) & (uint) byte.MaxValue);
      bytes[3 * index + 1] = (byte) (Polynomial.ModQ((uint) this.coeffs[2 * index] & (uint) ushort.MaxValue, q) >> 8 | (uint) (((int) Polynomial.ModQ((uint) this.coeffs[2 * index + 1] & (uint) ushort.MaxValue, q) & 15) << 4));
      bytes[3 * index + 2] = (byte) (Polynomial.ModQ((uint) this.coeffs[2 * index + 1] & (uint) ushort.MaxValue, q) >> 4);
    }
    return bytes;
  }

  public override void SqFromBytes(byte[] a)
  {
    for (int index = 0; index < this.ParameterSet.PackDegree() / 2; ++index)
    {
      this.coeffs[2 * index] = (ushort) ((int) a[3 * index] & (int) byte.MaxValue | ((int) (ushort) ((uint) a[3 * index + 1] & (uint) byte.MaxValue) & 15) << 8);
      this.coeffs[2 * index + 1] = (ushort) (((int) a[3 * index + 1] & (int) byte.MaxValue) >> 4 | ((int) (ushort) ((uint) a[3 * index + 2] & (uint) byte.MaxValue) & (int) byte.MaxValue) << 4);
    }
    this.coeffs[this.ParameterSet.N - 1] = (ushort) 0;
  }
}
