// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.ElGamalParametersGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class ElGamalParametersGenerator
{
  private int size;
  private int certainty;
  private SecureRandom random;

  public void Init(int size, int certainty, SecureRandom random)
  {
    this.size = size;
    this.certainty = certainty;
    this.random = random;
  }

  public ElGamalParameters GenerateParameters()
  {
    BigInteger[] safePrimes = DHParametersHelper.GenerateSafePrimes(this.size, this.certainty, this.random);
    BigInteger p = safePrimes[0];
    BigInteger q = safePrimes[1];
    BigInteger g = DHParametersHelper.SelectGenerator(p, q, this.random);
    return new ElGamalParameters(p, g);
  }
}
