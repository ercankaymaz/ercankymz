// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.SaberKemGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

public sealed class SaberKemGenerator : IEncapsulatedSecretGenerator
{
  private SecureRandom sr;

  public SaberKemGenerator(SecureRandom random)
  {
    this.sr = CryptoServicesRegistrar.GetSecureRandom(random);
  }

  public ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey)
  {
    SaberPublicKeyParameters publicKeyParameters = (SaberPublicKeyParameters) recipientKey;
    SaberEngine engine = publicKeyParameters.Parameters.Engine;
    byte[] numArray1 = new byte[engine.GetCipherTextSize()];
    byte[] numArray2 = new byte[engine.GetSessionKeySize()];
    engine.crypto_kem_enc(numArray1, numArray2, publicKeyParameters.GetPublicKey(), this.sr);
    return (ISecretWithEncapsulation) new SecretWithEncapsulationImpl(numArray2, numArray1);
  }
}
