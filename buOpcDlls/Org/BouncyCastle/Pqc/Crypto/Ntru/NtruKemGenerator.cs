// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.NtruKemGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Pqc.Crypto.Ntru.Owcpa;
using Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;
using Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru;

public class NtruKemGenerator : IEncapsulatedSecretGenerator
{
  private readonly SecureRandom _random;

  public NtruKemGenerator(SecureRandom random) => this._random = random;

  public ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey)
  {
    NtruParameterSet parameterSet = ((NtruKeyParameters) recipientKey).Parameters.ParameterSet;
    NtruSampling ntruSampling = new NtruSampling(parameterSet);
    NtruOwcpa ntruOwcpa = new NtruOwcpa(parameterSet);
    byte[] numArray1 = new byte[parameterSet.OwcpaMsgBytes()];
    byte[] buffer = new byte[parameterSet.SampleRmBytes()];
    this._random.NextBytes(buffer);
    byte[] uniformBytes = buffer;
    PolynomialPair polynomialPair = ntruSampling.SampleRm(uniformBytes);
    Polynomial r = polynomialPair.R();
    Polynomial m = polynomialPair.M();
    byte[] bytes1 = r.S3ToBytes(parameterSet.OwcpaMsgBytes());
    Array.Copy((Array) bytes1, 0, (Array) numArray1, 0, bytes1.Length);
    byte[] bytes2 = m.S3ToBytes(numArray1.Length - parameterSet.PackTrinaryBytes());
    Array.Copy((Array) bytes2, 0, (Array) numArray1, parameterSet.PackTrinaryBytes(), bytes2.Length);
    Sha3Digest sha3Digest = new Sha3Digest(256 /*0x0100*/);
    sha3Digest.BlockUpdate(numArray1, 0, numArray1.Length);
    byte[] numArray2 = new byte[sha3Digest.GetDigestSize()];
    sha3Digest.DoFinal(numArray2, 0);
    r.Z3ToZq();
    byte[] ciphertext = ntruOwcpa.Encrypt(r, m, ((NtruPublicKeyParameters) recipientKey).PublicKey);
    byte[] numArray3 = new byte[parameterSet.SharedKeyBytes];
    Array.Copy((Array) numArray2, 0, (Array) numArray3, 0, numArray3.Length);
    Array.Clear((Array) numArray2, 0, numArray2.Length);
    return (ISecretWithEncapsulation) new NtruEncapsulation(numArray3, ciphertext);
  }
}
