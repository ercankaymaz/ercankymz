// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.DesKeyGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class DesKeyGenerator : CipherKeyGenerator
{
  public DesKeyGenerator()
  {
  }

  internal DesKeyGenerator(int defaultStrength)
    : base(defaultStrength)
  {
  }

  protected override void EngineInit(KeyGenerationParameters parameters)
  {
    base.EngineInit(parameters);
    if (this.strength != 0 && this.strength != 7)
    {
      if (this.strength != 8)
        throw new ArgumentException($"DES key must be {64 /*0x40*/.ToString()} bits long.");
    }
    else
      this.strength = 8;
  }

  protected override byte[] EngineGenerateKey()
  {
    byte[] key = new byte[8];
    do
    {
      this.random.NextBytes(key);
      DesParameters.SetOddParity(key);
    }
    while (DesParameters.IsWeakKey(key, 0));
    return key;
  }
}
