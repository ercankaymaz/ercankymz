// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.RandomDsaKCalculator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class RandomDsaKCalculator : IDsaKCalculator
{
  private BigInteger q;
  private SecureRandom random;

  public virtual bool IsDeterministic => false;

  public virtual void Init(BigInteger n, SecureRandom random)
  {
    this.q = n;
    this.random = random;
  }

  public virtual void Init(BigInteger n, BigInteger d, byte[] message)
  {
    throw new InvalidOperationException("Operation not supported");
  }

  public virtual BigInteger NextK()
  {
    int bitLength = this.q.BitLength;
    BigInteger bigInteger;
    do
    {
      bigInteger = new BigInteger(bitLength, (Random) this.random);
    }
    while (bigInteger.SignValue < 1 || bigInteger.CompareTo(this.q) >= 0);
    return bigInteger;
  }
}
