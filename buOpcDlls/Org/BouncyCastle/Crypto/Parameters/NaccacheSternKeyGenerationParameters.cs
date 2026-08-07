// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.NaccacheSternKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class NaccacheSternKeyGenerationParameters : KeyGenerationParameters
{
  private readonly int certainty;
  private readonly int countSmallPrimes;

  public NaccacheSternKeyGenerationParameters(
    SecureRandom random,
    int strength,
    int certainty,
    int countSmallPrimes)
    : base(random, strength)
  {
    if (countSmallPrimes % 2 == 1)
      throw new ArgumentException("countSmallPrimes must be a multiple of 2");
    if (countSmallPrimes < 30)
      throw new ArgumentException("countSmallPrimes must be >= 30 for security reasons");
    this.certainty = certainty;
    this.countSmallPrimes = countSmallPrimes;
  }

  public int Certainty => this.certainty;

  public int CountSmallPrimes => this.countSmallPrimes;
}
