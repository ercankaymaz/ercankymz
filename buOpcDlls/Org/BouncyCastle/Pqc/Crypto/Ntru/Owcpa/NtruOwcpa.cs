// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.Owcpa.NtruOwcpa
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;
using Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru.Owcpa;

internal class NtruOwcpa
{
  private readonly NtruParameterSet _parameterSet;
  private readonly NtruSampling _sampling;

  internal NtruOwcpa(NtruParameterSet parameterSet)
  {
    this._parameterSet = parameterSet;
    this._sampling = new NtruSampling(parameterSet);
  }

  internal OwcpaKeyPair KeyPair(byte[] seed)
  {
    byte[] numArray = new byte[this._parameterSet.OwcpaSecretKeyBytes()];
    int n = this._parameterSet.N;
    this._parameterSet.Q();
    this._parameterSet.CreatePolynomial();
    this._parameterSet.CreatePolynomial();
    Polynomial polynomial1 = this._parameterSet.CreatePolynomial();
    Polynomial polynomial2 = this._parameterSet.CreatePolynomial();
    Polynomial polynomial3 = this._parameterSet.CreatePolynomial();
    Polynomial polynomial4 = polynomial1;
    Polynomial a1 = polynomial1;
    Polynomial a2 = polynomial2;
    Polynomial a3 = polynomial3;
    Polynomial polynomial5 = polynomial1;
    Polynomial polynomial6 = polynomial1;
    PolynomialPair polynomialPair = this._sampling.SampleFg(seed);
    Polynomial polynomial7 = polynomialPair.F();
    Polynomial polynomial8 = polynomialPair.G();
    polynomial4.S3Inv(polynomial7);
    byte[] bytes1 = polynomial7.S3ToBytes(this._parameterSet.OwcpaMsgBytes());
    Array.Copy((Array) bytes1, 0, (Array) numArray, 0, bytes1.Length);
    byte[] bytes2 = polynomial4.S3ToBytes(numArray.Length - this._parameterSet.PackTrinaryBytes());
    Array.Copy((Array) bytes2, 0, (Array) numArray, this._parameterSet.PackTrinaryBytes(), bytes2.Length);
    polynomial7.Z3ToZq();
    polynomial8.Z3ToZq();
    if (this._parameterSet is NtruHrssParameterSet)
    {
      for (int index = n - 1; index > 0; --index)
        polynomial8.coeffs[index] = (ushort) (3 * ((int) polynomial8.coeffs[index - 1] - (int) polynomial8.coeffs[index]));
      polynomial8.coeffs[0] = (ushort) -(3 * (int) polynomial8.coeffs[0]);
    }
    else
    {
      for (int index = 0; index < n; ++index)
        polynomial8.coeffs[index] = (ushort) (3U * (uint) polynomial8.coeffs[index]);
    }
    a1.RqMul(polynomial8, polynomial7);
    a2.RqInv(a1);
    a3.RqMul(a2, polynomial7);
    polynomial5.SqMul(a3, polynomial7);
    byte[] bytes3 = polynomial5.SqToBytes(numArray.Length - 2 * this._parameterSet.PackTrinaryBytes());
    Array.Copy((Array) bytes3, 0, (Array) numArray, 2 * this._parameterSet.PackTrinaryBytes(), bytes3.Length);
    a3.RqMul(a2, polynomial8);
    polynomial6.RqMul(a3, polynomial8);
    return new OwcpaKeyPair(polynomial6.RqSumZeroToBytes(this._parameterSet.OwcpaPublicKeyBytes()), numArray);
  }

  internal byte[] Encrypt(Polynomial r, Polynomial m, byte[] publicKey)
  {
    Polynomial polynomial1 = this._parameterSet.CreatePolynomial();
    Polynomial polynomial2 = this._parameterSet.CreatePolynomial();
    Polynomial b = polynomial1;
    Polynomial polynomial3 = polynomial1;
    Polynomial polynomial4 = polynomial2;
    b.RqSumZeroFromBytes(publicKey);
    polynomial4.RqMul(r, b);
    polynomial3.Lift(m);
    for (int index = 0; index < this._parameterSet.N; ++index)
      polynomial4.coeffs[index] += polynomial3.coeffs[index];
    return polynomial4.RqSumZeroToBytes(this._parameterSet.NtruCiphertextBytes());
  }

  internal OwcpaDecryptResult Decrypt(byte[] ciphertext, byte[] privateKey)
  {
    byte[] numArray1 = privateKey;
    byte[] numArray2 = new byte[this._parameterSet.OwcpaMsgBytes()];
    Polynomial polynomial1 = this._parameterSet.CreatePolynomial();
    Polynomial polynomial2 = this._parameterSet.CreatePolynomial();
    Polynomial polynomial3 = this._parameterSet.CreatePolynomial();
    Polynomial polynomial4 = this._parameterSet.CreatePolynomial();
    Polynomial a1 = polynomial1;
    Polynomial b1 = polynomial2;
    Polynomial a2 = polynomial3;
    Polynomial a3 = polynomial2;
    Polynomial b2 = polynomial3;
    Polynomial polynomial5 = polynomial4;
    Polynomial polynomial6 = polynomial2;
    Polynomial b3 = polynomial3;
    Polynomial r = polynomial4;
    Polynomial a4 = polynomial1;
    a1.RqSumZeroFromBytes(ciphertext);
    b1.S3FromBytes(numArray1);
    b1.Z3ToZq();
    a2.RqMul(a1, b1);
    a3.RqToS3(a2);
    b2.S3FromBytes(Arrays.CopyOfRange(numArray1, this._parameterSet.PackTrinaryBytes(), numArray1.Length));
    polynomial5.S3Mul(a3, b2);
    byte[] bytes1 = polynomial5.S3ToBytes(numArray2.Length - this._parameterSet.PackTrinaryBytes());
    int num = 0 | this.CheckCiphertext(ciphertext);
    if (this._parameterSet is NtruHpsParameterSet)
      num |= this.CheckM((HpsPolynomial) polynomial5);
    polynomial6.Lift(polynomial5);
    for (int index = 0; index < this._parameterSet.N; ++index)
      a4.coeffs[index] = (ushort) ((uint) a1.coeffs[index] - (uint) polynomial6.coeffs[index]);
    b3.SqFromBytes(Arrays.CopyOfRange(numArray1, 2 * this._parameterSet.PackTrinaryBytes(), numArray1.Length));
    r.SqMul(a4, b3);
    int fail = num | this.CheckR(r);
    r.TrinaryZqToZ3();
    byte[] bytes2 = r.S3ToBytes(this._parameterSet.OwcpaMsgBytes());
    Array.Copy((Array) bytes2, 0, (Array) numArray2, 0, bytes2.Length);
    Array.Copy((Array) bytes1, 0, (Array) numArray2, this._parameterSet.PackTrinaryBytes(), bytes1.Length);
    return new OwcpaDecryptResult(numArray2, fail);
  }

  private int CheckCiphertext(byte[] ciphertext)
  {
    return 1 & (int) ~(ushort) ((uint) (ushort) ciphertext[this._parameterSet.NtruCiphertextBytes() - 1] & (uint) (ushort) ((int) byte.MaxValue << 8 - (7 & this._parameterSet.LogQ * this._parameterSet.PackDegree()))) + 1 >> 15;
  }

  private int CheckR(Polynomial r)
  {
    int num = 0;
    for (int index = 0; index < this._parameterSet.N - 1; ++index)
    {
      ushort coeff = r.coeffs[index];
      num = num | (int) coeff + 1 & this._parameterSet.Q() - 4 | (int) coeff + 2 & 4;
    }
    return 1 & ~(num | (int) r.coeffs[this._parameterSet.N - 1]) + 1 >> 31 /*0x1F*/;
  }

  private int CheckM(HpsPolynomial m)
  {
    int num1 = 0;
    ushort num2 = 0;
    ushort num3 = 0;
    for (int index = 0; index < this._parameterSet.N - 1; ++index)
    {
      num2 += (ushort) ((uint) m.coeffs[index] & 1U);
      num3 += (ushort) ((uint) m.coeffs[index] & 2U);
    }
    return 1 & ~(num1 | (int) num2 ^ (int) num3 >> 1 | (int) num3 ^ ((NtruHpsParameterSet) this._parameterSet).Weight()) + 1 >> 31 /*0x1F*/;
  }
}
