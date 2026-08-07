// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.DesEdeKeyGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class DesEdeKeyGenerator : DesKeyGenerator
{
  public DesEdeKeyGenerator()
  {
  }

  internal DesEdeKeyGenerator(int defaultStrength)
    : base(defaultStrength)
  {
  }

  protected override void EngineInit(KeyGenerationParameters parameters)
  {
    this.random = parameters.Random;
    this.strength = (parameters.Strength + 7) / 8;
    if (this.strength != 0 && this.strength != 21)
    {
      if (this.strength == 14)
        this.strength = 16 /*0x10*/;
      else if (this.strength != 24 && this.strength != 16 /*0x10*/)
        throw new ArgumentException($"DESede key must be {192 /*0xC0*/.ToString()} or {128 /*0x80*/.ToString()} bits long.");
    }
    else
      this.strength = 24;
  }

  protected override byte[] EngineGenerateKey()
  {
    byte[] key = new byte[this.strength];
    do
    {
      this.random.NextBytes(key);
      DesParameters.SetOddParity(key);
    }
    while (DesEdeParameters.IsWeakKey(key, 0, key.Length) || !DesEdeParameters.IsRealEdeKey(key, 0));
    return key;
  }
}
