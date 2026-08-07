// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LmsKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private LmsKeyGenerationParameters m_parameters;

  public void Init(KeyGenerationParameters parameters)
  {
    this.m_parameters = (LmsKeyGenerationParameters) parameters;
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    SecureRandom random = this.m_parameters.Random;
    byte[] numArray1 = new byte[16 /*0x10*/];
    random.NextBytes(numArray1);
    byte[] numArray2 = new byte[32 /*0x20*/];
    random.NextBytes(numArray2);
    LmsPrivateKeyParameters keys = Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateKeys(this.m_parameters.LmsParameters.LMSigParameters, this.m_parameters.LmsParameters.LMOtsParameters, 0, numArray1, numArray2);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) keys.GetPublicKey(), (AsymmetricKeyParameter) keys);
  }
}
