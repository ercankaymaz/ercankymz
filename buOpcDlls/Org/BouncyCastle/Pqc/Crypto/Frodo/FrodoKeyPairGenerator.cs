// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Frodo.FrodoKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public class FrodoKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private FrodoKeyGenerationParameters frodoParams;
  private int n;
  private int D;
  private int B;
  private SecureRandom random;

  private void Initialize(KeyGenerationParameters param)
  {
    this.frodoParams = (FrodoKeyGenerationParameters) param;
    this.random = param.Random;
    this.n = this.frodoParams.Parameters.N;
    this.D = this.frodoParams.Parameters.D;
    this.B = this.frodoParams.Parameters.B;
  }

  private AsymmetricCipherKeyPair GenKeyPair()
  {
    FrodoEngine engine = this.frodoParams.Parameters.Engine;
    byte[] numArray1 = new byte[engine.PrivateKeySize];
    byte[] numArray2 = new byte[engine.PublicKeySize];
    engine.kem_keypair(numArray2, numArray1, this.random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new FrodoPublicKeyParameters(this.frodoParams.Parameters, numArray2), (AsymmetricKeyParameter) new FrodoPrivateKeyParameters(this.frodoParams.Parameters, numArray1));
  }

  public void Init(KeyGenerationParameters param) => this.Initialize(param);

  public AsymmetricCipherKeyPair GenerateKeyPair() => this.GenKeyPair();
}
