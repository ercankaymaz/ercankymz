// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.EntropyUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng;

public abstract class EntropyUtilities
{
  public static byte[] GenerateSeed(IEntropySource entropySource, int numBytes)
  {
    byte[] seed = new byte[numBytes];
    int num;
    for (int index = 0; index < numBytes; index += num)
    {
      byte[] entropy = entropySource.GetEntropy();
      num = Math.Min(seed.Length, numBytes - index);
      byte[] destinationArray = seed;
      int destinationIndex = index;
      int length = num;
      Array.Copy((Array) entropy, 0, (Array) destinationArray, destinationIndex, length);
    }
    return seed;
  }
}
