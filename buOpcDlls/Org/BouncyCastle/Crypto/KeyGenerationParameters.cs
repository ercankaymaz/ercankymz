// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.KeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public class KeyGenerationParameters
{
  private SecureRandom random;
  private int strength;

  public KeyGenerationParameters(SecureRandom random, int strength)
  {
    if (random == null)
      throw new ArgumentNullException(nameof (random));
    if (strength < 1)
      throw new ArgumentException("strength must be a positive value", nameof (strength));
    this.random = random;
    this.strength = strength;
  }

  public SecureRandom Random => this.random;

  public int Strength => this.strength;
}
