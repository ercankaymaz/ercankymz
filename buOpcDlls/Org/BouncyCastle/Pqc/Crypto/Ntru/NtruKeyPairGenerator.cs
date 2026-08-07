// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.NtruKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto.Ntru.Owcpa;
using Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru;

public class NtruKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private NtruKeyGenerationParameters _keygenParameters;
  private SecureRandom _random;

  public void Init(KeyGenerationParameters parameters)
  {
    this._keygenParameters = (NtruKeyGenerationParameters) parameters;
    this._random = parameters.Random;
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    NtruParameterSet parameterSet = this._keygenParameters.NtruParameters.ParameterSet;
    byte[] numArray1 = new byte[parameterSet.SampleFgBytes()];
    this._random.NextBytes(numArray1);
    OwcpaKeyPair owcpaKeyPair = new NtruOwcpa(parameterSet).KeyPair(numArray1);
    byte[] publicKey = owcpaKeyPair.PublicKey;
    byte[] numArray2 = new byte[parameterSet.NtruSecretKeyBytes()];
    byte[] privateKey = owcpaKeyPair.PrivateKey;
    Array.Copy((Array) privateKey, 0, (Array) numArray2, 0, privateKey.Length);
    byte[] numArray3 = new byte[parameterSet.PrfKeyBytes];
    this._random.NextBytes(numArray3);
    Array.Copy((Array) numArray3, 0, (Array) numArray2, parameterSet.OwcpaSecretKeyBytes(), numArray3.Length);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new NtruPublicKeyParameters(this._keygenParameters.NtruParameters, publicKey), (AsymmetricKeyParameter) new NtruPrivateKeyParameters(this._keygenParameters.NtruParameters, numArray2));
  }
}
