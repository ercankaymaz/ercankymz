// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.SignatureAlgorithm
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public class SignatureAlgorithm
{
  public const short anonymous = 0;
  public const short rsa = 1;
  public const short dsa = 2;
  public const short ecdsa = 3;
  public const short ed25519 = 7;
  public const short ed448 = 8;
  public const short rsa_pss_rsae_sha256 = 4;
  public const short rsa_pss_rsae_sha384 = 5;
  public const short rsa_pss_rsae_sha512 = 6;
  public const short rsa_pss_pss_sha256 = 9;
  public const short rsa_pss_pss_sha384 = 10;
  public const short rsa_pss_pss_sha512 = 11;
  public const short ecdsa_brainpoolP256r1tls13_sha256 = 26;
  public const short ecdsa_brainpoolP384r1tls13_sha384 = 27;
  public const short ecdsa_brainpoolP512r1tls13_sha512 = 28;
  public const short gostr34102012_256 = 64 /*0x40*/;
  public const short gostr34102012_512 = 65;

  public static short GetClientCertificateType(short signatureAlgorithm)
  {
    switch (signatureAlgorithm)
    {
      case 1:
      case 4:
      case 5:
      case 6:
      case 9:
      case 10:
      case 11:
        return 1;
      case 2:
        return 2;
      case 3:
      case 7:
      case 8:
        return 64 /*0x40*/;
      case 64 /*0x40*/:
        return 67;
      case 65:
        return 68;
      default:
        return -1;
    }
  }

  public static string GetName(short signatureAlgorithm)
  {
    switch (signatureAlgorithm)
    {
      case 0:
        return "anonymous";
      case 1:
        return "rsa";
      case 2:
        return "dsa";
      case 3:
        return "ecdsa";
      case 4:
        return "rsa_pss_rsae_sha256";
      case 5:
        return "rsa_pss_rsae_sha384";
      case 6:
        return "rsa_pss_rsae_sha512";
      case 7:
        return "ed25519";
      case 8:
        return "ed448";
      case 9:
        return "rsa_pss_pss_sha256";
      case 10:
        return "rsa_pss_pss_sha384";
      case 11:
        return "rsa_pss_pss_sha512";
      case 26:
        return "ecdsa_brainpoolP256r1tls13_sha256";
      case 27:
        return "ecdsa_brainpoolP384r1tls13_sha384";
      case 28:
        return "ecdsa_brainpoolP512r1tls13_sha512";
      case 64 /*0x40*/:
        return "gostr34102012_256";
      case 65:
        return "gostr34102012_512";
      default:
        return "UNKNOWN";
    }
  }

  public static string GetText(short signatureAlgorithm)
  {
    return $"{SignatureAlgorithm.GetName(signatureAlgorithm)}({signatureAlgorithm.ToString()})";
  }

  public static bool IsRecognized(short signatureAlgorithm)
  {
    if ((uint) signatureAlgorithm > 11U)
    {
      switch (signatureAlgorithm)
      {
        case 26:
        case 27:
        case 28:
        case 64 /*0x40*/:
        case 65:
          break;
        default:
          return false;
      }
    }
    return true;
  }
}
