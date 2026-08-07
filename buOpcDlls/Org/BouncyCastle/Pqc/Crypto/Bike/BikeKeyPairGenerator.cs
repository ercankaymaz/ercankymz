// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Bike.BikeKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Bike;

public sealed class BikeKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private SecureRandom random;
  private int r;
  private int l;
  private int L_BYTE;
  private int R_BYTE;
  private BikeKeyGenerationParameters bikeKeyGenerationParameters;

  public void Init(KeyGenerationParameters param)
  {
    this.bikeKeyGenerationParameters = (BikeKeyGenerationParameters) param;
    this.random = param.Random;
    this.r = this.bikeKeyGenerationParameters.Parameters.R;
    this.l = this.bikeKeyGenerationParameters.Parameters.L;
    this.L_BYTE = this.l / 8;
    this.R_BYTE = (this.r + 7) / 8;
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    BikeParameters parameters = this.bikeKeyGenerationParameters.Parameters;
    BikeEngine bikeEngine = parameters.BikeEngine;
    byte[] h0_1 = new byte[this.R_BYTE];
    byte[] h1_1 = new byte[this.R_BYTE];
    byte[] publicKey = new byte[this.R_BYTE];
    byte[] sigma1 = new byte[this.L_BYTE];
    byte[] h0_2 = h0_1;
    byte[] h1_2 = h1_1;
    byte[] sigma2 = sigma1;
    byte[] h = publicKey;
    SecureRandom random = this.random;
    bikeEngine.GenKeyPair(h0_2, h1_2, sigma2, h, random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new BikePublicKeyParameters(parameters, publicKey), (AsymmetricKeyParameter) new BikePrivateKeyParameters(parameters, h0_1, h1_1, sigma1));
  }
}
