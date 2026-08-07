// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.IsoTrailers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class IsoTrailers
{
  public const int TRAILER_IMPLICIT = 188;
  public const int TRAILER_RIPEMD160 = 12748;
  public const int TRAILER_RIPEMD128 = 13004;
  public const int TRAILER_SHA1 = 13260;
  public const int TRAILER_SHA256 = 13516;
  public const int TRAILER_SHA512 = 13772;
  public const int TRAILER_SHA384 = 14028;
  public const int TRAILER_WHIRLPOOL = 14284;
  public const int TRAILER_SHA224 = 14540;
  public const int TRAILER_SHA512_224 = 14796;
  public const int TRAILER_SHA512_256 = 16588;
  private static readonly IDictionary<string, int> TrailerMap = IsoTrailers.CreateTrailerMap();

  private static IDictionary<string, int> CreateTrailerMap()
  {
    return (IDictionary<string, int>) new Dictionary<string, int>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        "RIPEMD128",
        13004
      },
      {
        "RIPEMD160",
        12748
      },
      {
        "SHA-1",
        13260
      },
      {
        "SHA-224",
        14540
      },
      {
        "SHA-256",
        13516
      },
      {
        "SHA-384",
        14028
      },
      {
        "SHA-512",
        13772
      },
      {
        "SHA-512/224",
        14796
      },
      {
        "SHA-512/256",
        16588
      },
      {
        "Whirlpool",
        14284
      }
    };
  }

  public static int GetTrailer(IDigest digest)
  {
    int trailer;
    if (!IsoTrailers.TrailerMap.TryGetValue(digest.AlgorithmName, out trailer))
      throw new InvalidOperationException("No trailer for digest");
    return trailer;
  }

  public static bool NoTrailerAvailable(IDigest digest)
  {
    return !IsoTrailers.TrailerMap.ContainsKey(digest.AlgorithmName);
  }
}
