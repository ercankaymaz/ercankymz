// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.CmceKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

public sealed class CmceKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private CmceKeyGenerationParameters m_cmceParams;
  private SecureRandom random;

  private void Initialize(KeyGenerationParameters param)
  {
    this.m_cmceParams = (CmceKeyGenerationParameters) param;
    this.random = param.Random;
  }

  private AsymmetricCipherKeyPair GenKeyPair()
  {
    ICmceEngine engine = this.m_cmceParams.Parameters.Engine;
    byte[] numArray1 = new byte[engine.PrivateKeySize];
    byte[] numArray2 = new byte[engine.PublicKeySize];
    engine.KemKeypair(numArray2, numArray1, this.random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new CmcePublicKeyParameters(this.m_cmceParams.Parameters, numArray2), (AsymmetricKeyParameter) new CmcePrivateKeyParameters(this.m_cmceParams.Parameters, numArray1));
  }

  public void Init(KeyGenerationParameters param) => this.Initialize(param);

  public AsymmetricCipherKeyPair GenerateKeyPair() => this.GenKeyPair();
}
