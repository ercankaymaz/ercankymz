// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SikeKemGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

[Obsolete("Will be removed")]
public sealed class SikeKemGenerator : IEncapsulatedSecretGenerator
{
  private readonly SecureRandom sr;

  public SikeKemGenerator(SecureRandom random)
  {
    this.sr = CryptoServicesRegistrar.GetSecureRandom(random);
  }

  public ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey)
  {
    SikeEngine engine = ((SikeKeyParameters) recipientKey).Parameters.GetEngine();
    return this.GenerateEncapsulated(recipientKey, (int) engine.GetDefaultSessionKeySize());
  }

  public ISecretWithEncapsulation GenerateEncapsulated(
    AsymmetricKeyParameter recipientKey,
    int sessionKeySizeInBits)
  {
    Console.Error.WriteLine("WARNING: the SIKE algorithm is only for research purposes, insecure");
    SikePublicKeyParameters publicKeyParameters = (SikePublicKeyParameters) recipientKey;
    SikeEngine engine = publicKeyParameters.Parameters.GetEngine();
    byte[] numArray1 = new byte[engine.GetCipherTextSize()];
    byte[] numArray2 = new byte[sessionKeySizeInBits / 8];
    engine.crypto_kem_enc(numArray1, numArray2, publicKeyParameters.GetPublicKey(), this.sr);
    return (ISecretWithEncapsulation) new SecretWithEncapsulationImpl(numArray2, numArray1);
  }
}
