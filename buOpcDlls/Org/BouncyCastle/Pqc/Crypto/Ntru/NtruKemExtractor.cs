// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.NtruKemExtractor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Pqc.Crypto.Ntru.Owcpa;
using Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru;

public class NtruKemExtractor : IEncapsulatedSecretExtractor
{
  private readonly NtruParameters _parameters;
  private readonly NtruPrivateKeyParameters _ntruPrivateKey;

  public NtruKemExtractor(NtruPrivateKeyParameters ntruPrivateKey)
  {
    this._parameters = ntruPrivateKey.Parameters;
    this._ntruPrivateKey = ntruPrivateKey;
  }

  public byte[] ExtractSecret(byte[] encapsulation)
  {
    NtruParameterSet parameterSet = this._parameters.ParameterSet;
    byte[] privateKey = this._ntruPrivateKey.PrivateKey;
    byte[] input = new byte[parameterSet.PrfKeyBytes + parameterSet.NtruCiphertextBytes()];
    OwcpaDecryptResult owcpaDecryptResult = new NtruOwcpa(parameterSet).Decrypt(encapsulation, this._ntruPrivateKey.PrivateKey);
    byte[] rm = owcpaDecryptResult.Rm;
    int fail = owcpaDecryptResult.Fail;
    Sha3Digest sha3Digest = new Sha3Digest(256 /*0x0100*/);
    byte[] numArray = new byte[sha3Digest.GetDigestSize()];
    sha3Digest.BlockUpdate(rm, 0, rm.Length);
    sha3Digest.DoFinal(numArray, 0);
    for (int index = 0; index < parameterSet.PrfKeyBytes; ++index)
      input[index] = privateKey[index + parameterSet.OwcpaSecretKeyBytes()];
    for (int index = 0; index < parameterSet.NtruCiphertextBytes(); ++index)
      input[parameterSet.PrfKeyBytes + index] = encapsulation[index];
    sha3Digest.Reset();
    sha3Digest.BlockUpdate(input, 0, input.Length);
    sha3Digest.DoFinal(rm, 0);
    NtruKemExtractor.Cmov(numArray, rm, (byte) fail);
    byte[] destinationArray = new byte[parameterSet.SharedKeyBytes];
    Array.Copy((Array) numArray, 0, (Array) destinationArray, 0, parameterSet.SharedKeyBytes);
    Array.Clear((Array) numArray, 0, numArray.Length);
    return destinationArray;
  }

  private static void Cmov(byte[] r, byte[] x, byte b)
  {
    b = (byte) ((uint) ~b + 1U);
    for (int index = 0; index < r.Length; ++index)
      r[index] ^= (byte) ((uint) b & ((uint) x[index] ^ (uint) r[index]));
  }

  public int EncapsulationLength => this._parameters.ParameterSet.NtruCiphertextBytes();
}
