// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.NtruSampling
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;
using Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru;

internal class NtruSampling
{
  private readonly NtruParameterSet _parameterSet;

  internal NtruSampling(NtruParameterSet parameterSet) => this._parameterSet = parameterSet;

  internal PolynomialPair SampleFg(byte[] uniformBytes)
  {
    switch (this._parameterSet)
    {
      case NtruHrssParameterSet _:
        return new PolynomialPair((Polynomial) this.SampleIidPlus(Arrays.CopyOfRange(uniformBytes, 0, this._parameterSet.SampleIidBytes())), (Polynomial) this.SampleIidPlus(Arrays.CopyOfRange(uniformBytes, this._parameterSet.SampleIidBytes(), uniformBytes.Length)));
      case NtruHpsParameterSet _:
        return new PolynomialPair(this.SampleIid(Arrays.CopyOfRange(uniformBytes, 0, this._parameterSet.SampleIidBytes())), (Polynomial) this.SampleFixedType(Arrays.CopyOfRange(uniformBytes, this._parameterSet.SampleIidBytes(), uniformBytes.Length)));
      default:
        throw new ArgumentException("Invalid polynomial type");
    }
  }

  internal PolynomialPair SampleRm(byte[] uniformBytes)
  {
    switch (this._parameterSet)
    {
      case NtruHrssParameterSet _:
        return new PolynomialPair(this.SampleIid(Arrays.CopyOfRange(uniformBytes, 0, this._parameterSet.SampleIidBytes())), this.SampleIid(Arrays.CopyOfRange(uniformBytes, this._parameterSet.SampleIidBytes(), uniformBytes.Length)));
      case NtruHpsParameterSet _:
        return new PolynomialPair(this.SampleIid(Arrays.CopyOfRange(uniformBytes, 0, this._parameterSet.SampleIidBytes())), (Polynomial) this.SampleFixedType(Arrays.CopyOfRange(uniformBytes, this._parameterSet.SampleIidBytes(), uniformBytes.Length)));
      default:
        throw new ArgumentException("Invalid polynomial type");
    }
  }

  internal Polynomial SampleIid(byte[] uniformBytes)
  {
    Polynomial polynomial = this._parameterSet.CreatePolynomial();
    for (int index = 0; index < this._parameterSet.N - 1; ++index)
      polynomial.coeffs[index] = (ushort) NtruSampling.Mod3((int) uniformBytes[index]);
    polynomial.coeffs[this._parameterSet.N - 1] = (ushort) 0;
    return polynomial;
  }

  internal HpsPolynomial SampleFixedType(byte[] uniformBytes)
  {
    int n = this._parameterSet.N;
    int num1 = ((NtruHpsParameterSet) this._parameterSet).Weight();
    HpsPolynomial polynomial = (HpsPolynomial) this._parameterSet.CreatePolynomial();
    int[] array = new int[n - 1];
    for (int index = 0; index < (n - 1) / 4; ++index)
    {
      array[4 * index] = ((int) uniformBytes[15 * index] << 2) + ((int) uniformBytes[15 * index + 1] << 10) + ((int) uniformBytes[15 * index + 2] << 18) + ((int) uniformBytes[15 * index + 3] << 26);
      array[4 * index + 1] = (((int) uniformBytes[15 * index + 3] & 192 /*0xC0*/) >> 4) + ((int) uniformBytes[15 * index + 4] << 4) + ((int) uniformBytes[15 * index + 5] << 12) + ((int) uniformBytes[15 * index + 6] << 20) + ((int) uniformBytes[15 * index + 7] << 28);
      array[4 * index + 2] = (((int) uniformBytes[15 * index + 7] & 240 /*0xF0*/) >> 2) + ((int) uniformBytes[15 * index + 8] << 6) + ((int) uniformBytes[15 * index + 9] << 14) + ((int) uniformBytes[15 * index + 10] << 22) + ((int) uniformBytes[15 * index + 11] << 30);
      array[4 * index + 3] = ((int) uniformBytes[15 * index + 11] & 252) + ((int) uniformBytes[15 * index + 12] << 8) + ((int) uniformBytes[15 * index + 13] << 16 /*0x10*/) + ((int) uniformBytes[15 * index + 14] << 24);
    }
    if (n - 1 > (n - 1) / 4 * 4)
    {
      int num2 = (n - 1) / 4;
      array[4 * num2] = ((int) uniformBytes[15 * num2] << 2) + ((int) uniformBytes[15 * num2 + 1] << 10) + ((int) uniformBytes[15 * num2 + 2] << 18) + ((int) uniformBytes[15 * num2 + 3] << 26);
      array[4 * num2 + 1] = (((int) uniformBytes[15 * num2 + 3] & 192 /*0xC0*/) >> 4) + ((int) uniformBytes[15 * num2 + 4] << 4) + ((int) uniformBytes[15 * num2 + 5] << 12) + ((int) uniformBytes[15 * num2 + 6] << 20) + ((int) uniformBytes[15 * num2 + 7] << 28);
    }
    for (int index = 0; index < num1 / 2; ++index)
      array[index] |= 1;
    for (int index = num1 / 2; index < num1; ++index)
      array[index] |= 2;
    Array.Sort<int>(array);
    for (int index = 0; index < n - 1; ++index)
      polynomial.coeffs[index] = (ushort) (array[index] & 3);
    polynomial.coeffs[n - 1] = (ushort) 0;
    return polynomial;
  }

  internal HrssPolynomial SampleIidPlus(byte[] uniformBytes)
  {
    int n = this._parameterSet.N;
    ushort num1 = 0;
    HrssPolynomial hrssPolynomial = (HrssPolynomial) this.SampleIid(uniformBytes);
    for (int index = 0; index < n - 1; ++index)
      hrssPolynomial.coeffs[index] = (ushort) ((uint) hrssPolynomial.coeffs[index] | (uint) -((int) hrssPolynomial.coeffs[index] >> 1));
    for (int index = 0; index < n - 1; ++index)
      num1 += (ushort) ((uint) hrssPolynomial.coeffs[index + 1] * (uint) hrssPolynomial.coeffs[index]);
    ushort num2 = (ushort) (1 | -((int) num1 >> 15));
    for (int index = 0; index < n - 1; index += 2)
      hrssPolynomial.coeffs[index] = (ushort) ((uint) num2 * (uint) hrssPolynomial.coeffs[index]);
    for (int index = 0; index < n - 1; ++index)
      hrssPolynomial.coeffs[index] = (ushort) (3 & ((int) hrssPolynomial.coeffs[index] ^ (int) hrssPolynomial.coeffs[index] >> 15));
    return hrssPolynomial;
  }

  private static int Mod3(int a) => a % 3;
}
