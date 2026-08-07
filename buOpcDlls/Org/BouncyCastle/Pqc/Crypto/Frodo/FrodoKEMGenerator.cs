// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Frodo.FrodoKEMGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public class FrodoKEMGenerator : IEncapsulatedSecretGenerator
{
  private readonly SecureRandom sr;

  public FrodoKEMGenerator(SecureRandom random) => this.sr = random;

  public ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey)
  {
    FrodoPublicKeyParameters publicKeyParameters = (FrodoPublicKeyParameters) recipientKey;
    FrodoEngine engine = publicKeyParameters.Parameters.Engine;
    byte[] numArray1 = new byte[engine.CipherTextSize];
    byte[] numArray2 = new byte[engine.SessionKeySize];
    engine.kem_enc(numArray1, numArray2, publicKeyParameters.m_publicKey, this.sr);
    return (ISecretWithEncapsulation) new SecretWithEncapsulationImpl(numArray2, numArray1);
  }
}
