// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.CmceKemGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

public sealed class CmceKemGenerator : IEncapsulatedSecretGenerator
{
  private readonly SecureRandom sr;

  public CmceKemGenerator(SecureRandom random) => this.sr = random;

  public ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey)
  {
    ICmceEngine engine = ((CmceKeyParameters) recipientKey).Parameters.Engine;
    return this.GenerateEncapsulated(recipientKey, engine.DefaultSessionKeySize);
  }

  private ISecretWithEncapsulation GenerateEncapsulated(
    AsymmetricKeyParameter recipientKey,
    int sessionKeySizeInBits)
  {
    CmcePublicKeyParameters publicKeyParameters = (CmcePublicKeyParameters) recipientKey;
    ICmceEngine engine = publicKeyParameters.Parameters.Engine;
    byte[] cipher_text = new byte[engine.CipherTextSize];
    byte[] numArray = new byte[sessionKeySizeInBits / 8];
    engine.KemEnc(cipher_text, numArray, publicKeyParameters.publicKey, this.sr);
    return (ISecretWithEncapsulation) new SecretWithEncapsulationImpl(numArray, cipher_text);
  }
}
