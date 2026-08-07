// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.DHKeyGeneratorHelper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

internal class DHKeyGeneratorHelper
{
  internal static readonly DHKeyGeneratorHelper Instance = new DHKeyGeneratorHelper();

  private DHKeyGeneratorHelper()
  {
  }

  internal BigInteger CalculatePrivate(DHParameters dhParams, SecureRandom random)
  {
    int l = dhParams.L;
    if (l != 0)
    {
      int num = l >> 2;
      BigInteger k;
      do
      {
        k = new BigInteger(l, (Random) random).SetBit(l - 1);
      }
      while (WNafUtilities.GetNafWeight(k) < num);
      return k;
    }
    BigInteger min = BigInteger.Two;
    int m = dhParams.M;
    if (m != 0)
      min = BigInteger.One.ShiftLeft(m - 1);
    BigInteger max = (dhParams.Q ?? dhParams.P).Subtract(BigInteger.Two);
    int num1 = max.BitLength >> 2;
    BigInteger randomInRange;
    do
    {
      randomInRange = BigIntegers.CreateRandomInRange(min, max, random);
    }
    while (WNafUtilities.GetNafWeight(randomInRange) < num1);
    return randomInRange;
  }

  internal BigInteger CalculatePublic(DHParameters dhParams, BigInteger x)
  {
    return dhParams.G.ModPow(x, dhParams.P);
  }
}
