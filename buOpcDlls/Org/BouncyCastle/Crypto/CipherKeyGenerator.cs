// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.CipherKeyGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public class CipherKeyGenerator
{
  protected internal SecureRandom random;
  protected internal int strength;
  private bool uninitialised = true;
  private int defaultStrength;

  public CipherKeyGenerator()
  {
  }

  internal CipherKeyGenerator(int defaultStrength)
  {
    this.defaultStrength = defaultStrength >= 1 ? defaultStrength : throw new ArgumentException("strength must be a positive value", nameof (defaultStrength));
  }

  public int DefaultStrength => this.defaultStrength;

  public void Init(KeyGenerationParameters parameters)
  {
    if (parameters == null)
      throw new ArgumentNullException(nameof (parameters));
    this.uninitialised = false;
    this.EngineInit(parameters);
  }

  protected virtual void EngineInit(KeyGenerationParameters parameters)
  {
    this.random = parameters.Random;
    this.strength = (parameters.Strength + 7) / 8;
  }

  public byte[] GenerateKey()
  {
    this.EnsureInitialized();
    return this.EngineGenerateKey();
  }

  public KeyParameter GenerateKeyParameter()
  {
    this.EnsureInitialized();
    return this.EngineGenerateKeyParameter();
  }

  protected virtual byte[] EngineGenerateKey()
  {
    return SecureRandom.GetNextBytes(this.random, this.strength);
  }

  protected virtual KeyParameter EngineGenerateKeyParameter()
  {
    return new KeyParameter(this.EngineGenerateKey());
  }

  protected virtual void EnsureInitialized()
  {
    if (!this.uninitialised)
      return;
    if (this.defaultStrength < 1)
      throw new InvalidOperationException("Generator has not been initialised");
    this.uninitialised = false;
    this.EngineInit(new KeyGenerationParameters(CryptoServicesRegistrar.GetSecureRandom(), this.defaultStrength));
  }
}
