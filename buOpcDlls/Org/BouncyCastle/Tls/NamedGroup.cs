// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.NamedGroup
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class NamedGroup
{
  public const int sect163k1 = 1;
  public const int sect163r1 = 2;
  public const int sect163r2 = 3;
  public const int sect193r1 = 4;
  public const int sect193r2 = 5;
  public const int sect233k1 = 6;
  public const int sect233r1 = 7;
  public const int sect239k1 = 8;
  public const int sect283k1 = 9;
  public const int sect283r1 = 10;
  public const int sect409k1 = 11;
  public const int sect409r1 = 12;
  public const int sect571k1 = 13;
  public const int sect571r1 = 14;
  public const int secp160k1 = 15;
  public const int secp160r1 = 16 /*0x10*/;
  public const int secp160r2 = 17;
  public const int secp192k1 = 18;
  public const int secp192r1 = 19;
  public const int secp224k1 = 20;
  public const int secp224r1 = 21;
  public const int secp256k1 = 22;
  public const int secp256r1 = 23;
  public const int secp384r1 = 24;
  public const int secp521r1 = 25;
  public const int brainpoolP256r1 = 26;
  public const int brainpoolP384r1 = 27;
  public const int brainpoolP512r1 = 28;
  public const int x25519 = 29;
  public const int x448 = 30;
  public const int brainpoolP256r1tls13 = 31 /*0x1F*/;
  public const int brainpoolP384r1tls13 = 32 /*0x20*/;
  public const int brainpoolP512r1tls13 = 33;
  public const int GC256A = 34;
  public const int GC256B = 35;
  public const int GC256C = 36;
  public const int GC256D = 37;
  public const int GC512A = 38;
  public const int GC512B = 39;
  public const int GC512C = 40;
  public const int curveSM2 = 41;
  public const int ffdhe2048 = 256 /*0x0100*/;
  public const int ffdhe3072 = 257;
  public const int ffdhe4096 = 258;
  public const int ffdhe6144 = 259;
  public const int ffdhe8192 = 260;
  public const int arbitrary_explicit_prime_curves = 65281;
  public const int arbitrary_explicit_char2_curves = 65282;
  private static readonly string[] CurveNames = new string[41]
  {
    nameof (sect163k1),
    nameof (sect163r1),
    nameof (sect163r2),
    nameof (sect193r1),
    nameof (sect193r2),
    nameof (sect233k1),
    nameof (sect233r1),
    nameof (sect239k1),
    nameof (sect283k1),
    nameof (sect283r1),
    nameof (sect409k1),
    nameof (sect409r1),
    nameof (sect571k1),
    nameof (sect571r1),
    nameof (secp160k1),
    nameof (secp160r1),
    nameof (secp160r2),
    nameof (secp192k1),
    nameof (secp192r1),
    nameof (secp224k1),
    nameof (secp224r1),
    nameof (secp256k1),
    nameof (secp256r1),
    nameof (secp384r1),
    nameof (secp521r1),
    nameof (brainpoolP256r1),
    nameof (brainpoolP384r1),
    nameof (brainpoolP512r1),
    "X25519",
    "X448",
    nameof (brainpoolP256r1),
    nameof (brainpoolP384r1),
    nameof (brainpoolP512r1),
    "Tc26-Gost-3410-12-256-paramSetA",
    "GostR3410-2001-CryptoPro-A",
    "GostR3410-2001-CryptoPro-B",
    "GostR3410-2001-CryptoPro-C",
    "Tc26-Gost-3410-12-512-paramSetA",
    "Tc26-Gost-3410-12-512-paramSetB",
    "Tc26-Gost-3410-12-512-paramSetC",
    "sm2p256v1"
  };
  private static readonly string[] FiniteFieldNames = new string[5]
  {
    nameof (ffdhe2048),
    nameof (ffdhe3072),
    nameof (ffdhe4096),
    nameof (ffdhe6144),
    nameof (ffdhe8192)
  };

  public static bool CanBeNegotiated(int namedGroup, ProtocolVersion version)
  {
    if (TlsUtilities.IsTlsV13(version))
    {
      if (namedGroup >= 1 && namedGroup <= 22 || namedGroup >= 26 && namedGroup <= 28 || namedGroup >= 34 && namedGroup <= 40 || namedGroup >= 65281 && namedGroup <= 65282)
        return false;
    }
    else if (namedGroup >= 31 /*0x1F*/ && namedGroup <= 33 || namedGroup == 41)
      return false;
    return NamedGroup.IsValid(namedGroup);
  }

  public static int GetCurveBits(int namedGroup)
  {
    switch (namedGroup)
    {
      case 1:
      case 2:
      case 3:
        return 163;
      case 4:
      case 5:
        return 193;
      case 6:
      case 7:
        return 233;
      case 8:
        return 239;
      case 9:
      case 10:
        return 283;
      case 11:
      case 12:
        return 409;
      case 13:
      case 14:
        return 571;
      case 15:
      case 16 /*0x10*/:
      case 17:
        return 160 /*0xA0*/;
      case 18:
      case 19:
        return 192 /*0xC0*/;
      case 20:
      case 21:
        return 224 /*0xE0*/;
      case 22:
      case 23:
      case 26:
      case 31 /*0x1F*/:
      case 34:
      case 35:
      case 36:
      case 37:
      case 41:
        return 256 /*0x0100*/;
      case 24:
      case 27:
      case 32 /*0x20*/:
        return 384;
      case 25:
        return 521;
      case 28:
      case 33:
      case 38:
      case 39:
      case 40:
        return 512 /*0x0200*/;
      case 29:
        return 252;
      case 30:
        return 446;
      default:
        return 0;
    }
  }

  public static string GetCurveName(int namedGroup)
  {
    return NamedGroup.RefersToASpecificCurve(namedGroup) ? NamedGroup.CurveNames[namedGroup - 1] : (string) null;
  }

  public static int GetFiniteFieldBits(int namedGroup)
  {
    switch (namedGroup)
    {
      case 256 /*0x0100*/:
        return 2048 /*0x0800*/;
      case 257:
        return 3072 /*0x0C00*/;
      case 258:
        return 4096 /*0x1000*/;
      case 259:
        return 6144;
      case 260:
        return 8192 /*0x2000*/;
      default:
        return 0;
    }
  }

  public static string GetFiniteFieldName(int namedGroup)
  {
    return NamedGroup.RefersToASpecificFiniteField(namedGroup) ? NamedGroup.FiniteFieldNames[namedGroup - 256 /*0x0100*/] : (string) null;
  }

  public static int GetMaximumChar2CurveBits() => 571;

  public static int GetMaximumCurveBits() => 571;

  public static int GetMaximumFiniteFieldBits() => 8192 /*0x2000*/;

  public static int GetMaximumPrimeCurveBits() => 521;

  public static string GetName(int namedGroup)
  {
    if (NamedGroup.IsPrivate(namedGroup))
      return "PRIVATE";
    switch (namedGroup)
    {
      case 29:
        return "x25519";
      case 30:
        return "x448";
      case 31 /*0x1F*/:
        return "brainpoolP256r1tls13";
      case 32 /*0x20*/:
        return "brainpoolP384r1tls13";
      case 33:
        return "brainpoolP512r1tls13";
      case 34:
        return "GC256A";
      case 35:
        return "GC256B";
      case 36:
        return "GC256C";
      case 37:
        return "GC256D";
      case 38:
        return "GC512A";
      case 39:
        return "GC512B";
      case 40:
        return "GC512C";
      case 41:
        return "curveSM2";
      case 65281:
        return "arbitrary_explicit_prime_curves";
      case 65282:
        return "arbitrary_explicit_char2_curves";
      default:
        return NamedGroup.GetStandardName(namedGroup) ?? "UNKNOWN";
    }
  }

  public static string GetStandardName(int namedGroup)
  {
    return NamedGroup.GetCurveName(namedGroup) ?? NamedGroup.GetFiniteFieldName(namedGroup) ?? (string) null;
  }

  public static string GetText(int namedGroup)
  {
    return $"{NamedGroup.GetName(namedGroup)}({namedGroup.ToString()})";
  }

  public static bool IsChar2Curve(int namedGroup)
  {
    return namedGroup >= 1 && namedGroup <= 14 || namedGroup == 65282;
  }

  public static bool IsPrimeCurve(int namedGroup)
  {
    return namedGroup >= 15 && namedGroup <= 41 || namedGroup == 65281;
  }

  public static bool IsPrivate(int namedGroup)
  {
    return namedGroup >> 2 == (int) sbyte.MaxValue || namedGroup >> 8 == 254;
  }

  public static bool IsValid(int namedGroup)
  {
    if (NamedGroup.RefersToASpecificGroup(namedGroup) || NamedGroup.IsPrivate(namedGroup))
      return true;
    return namedGroup >= 65281 && namedGroup <= 65282;
  }

  public static bool RefersToAnECDHCurve(int namedGroup)
  {
    return NamedGroup.RefersToASpecificCurve(namedGroup);
  }

  public static bool RefersToAnECDSACurve(int namedGroup)
  {
    return NamedGroup.RefersToASpecificCurve(namedGroup) && !NamedGroup.RefersToAnXDHCurve(namedGroup);
  }

  public static bool RefersToAnXDHCurve(int namedGroup) => namedGroup >= 29 && namedGroup <= 30;

  public static bool RefersToASpecificCurve(int namedGroup) => namedGroup >= 1 && namedGroup <= 41;

  public static bool RefersToASpecificFiniteField(int namedGroup)
  {
    return namedGroup >= 256 /*0x0100*/ && namedGroup <= 260;
  }

  public static bool RefersToASpecificGroup(int namedGroup)
  {
    return NamedGroup.RefersToASpecificCurve(namedGroup) || NamedGroup.RefersToASpecificFiniteField(namedGroup);
  }
}
