// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.Drbg.DrbgUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng.Drbg;

internal class DrbgUtilities
{
  private static readonly IDictionary<string, int> MaxSecurityStrengths = (IDictionary<string, int>) new Dictionary<string, int>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static DrbgUtilities()
  {
    DrbgUtilities.MaxSecurityStrengths.Add("SHA-1", 128 /*0x80*/);
    DrbgUtilities.MaxSecurityStrengths.Add("SHA-224", 192 /*0xC0*/);
    DrbgUtilities.MaxSecurityStrengths.Add("SHA-256", 256 /*0x0100*/);
    DrbgUtilities.MaxSecurityStrengths.Add("SHA-384", 256 /*0x0100*/);
    DrbgUtilities.MaxSecurityStrengths.Add("SHA-512", 256 /*0x0100*/);
    DrbgUtilities.MaxSecurityStrengths.Add("SHA-512/224", 192 /*0xC0*/);
    DrbgUtilities.MaxSecurityStrengths.Add("SHA-512/256", 256 /*0x0100*/);
  }

  internal static int GetMaxSecurityStrength(IDigest d)
  {
    return DrbgUtilities.MaxSecurityStrengths[d.AlgorithmName];
  }

  internal static int GetMaxSecurityStrength(IMac m)
  {
    string algorithmName = m.AlgorithmName;
    return DrbgUtilities.MaxSecurityStrengths[algorithmName.Substring(0, algorithmName.IndexOf("/"))];
  }

  internal static void HashDF(IDigest digest, byte[] seedMaterial, int seedLength, byte[] output)
  {
    int num1 = (seedLength + 7) / 8;
    int digestSize = digest.GetDigestSize();
    int num2 = num1 / digestSize;
    int num3 = 1;
    byte[] numArray1 = new byte[digestSize];
    byte[] numArray2 = new byte[5];
    Pack.UInt32_To_BE((uint) seedLength, numArray2, 1);
    int num4 = 0;
    while (num4 <= num2)
    {
      numArray2[0] = (byte) num3;
      digest.BlockUpdate(numArray2, 0, numArray2.Length);
      digest.BlockUpdate(seedMaterial, 0, seedMaterial.Length);
      digest.DoFinal(numArray1, 0);
      int length = Math.Min(digestSize, num1 - num4 * digestSize);
      Array.Copy((Array) numArray1, 0, (Array) output, num4 * digestSize, length);
      ++num4;
      ++num3;
    }
    if (seedLength % 8 == 0)
      return;
    int num5 = 8 - seedLength % 8;
    uint num6 = 0;
    for (int index = 0; index != num1; ++index)
    {
      uint num7 = (uint) output[index];
      output[index] = (byte) (num7 >> num5 | num6 << 8 - num5);
      num6 = num7;
    }
  }
}
