// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.NaccacheSternPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class NaccacheSternPrivateKeyParameters : NaccacheSternKeyParameters
{
  private readonly BigInteger phiN;
  private readonly IList<BigInteger> smallPrimes;

  public NaccacheSternPrivateKeyParameters(
    BigInteger g,
    BigInteger n,
    int lowerSigmaBound,
    IList<BigInteger> smallPrimes,
    BigInteger phiN)
    : base(true, g, n, lowerSigmaBound)
  {
    this.smallPrimes = smallPrimes;
    this.phiN = phiN;
  }

  public BigInteger PhiN => this.phiN;

  public IList<BigInteger> SmallPrimesList => this.smallPrimes;
}
