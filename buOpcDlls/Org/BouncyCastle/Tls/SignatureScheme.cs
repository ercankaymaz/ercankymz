// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.SignatureScheme
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class SignatureScheme
{
  public const int rsa_pkcs1_sha1 = 513;
  public const int ecdsa_sha1 = 515;
  public const int rsa_pkcs1_sha256 = 1025;
  public const int rsa_pkcs1_sha384 = 1281;
  public const int rsa_pkcs1_sha512 = 1537;
  public const int ecdsa_secp256r1_sha256 = 1027;
  public const int ecdsa_secp384r1_sha384 = 1283;
  public const int ecdsa_secp521r1_sha512 = 1539;
  public const int rsa_pss_rsae_sha256 = 2052;
  public const int rsa_pss_rsae_sha384 = 2053;
  public const int rsa_pss_rsae_sha512 = 2054;
  public const int ed25519 = 2055;
  public const int ed448 = 2056;
  public const int rsa_pss_pss_sha256 = 2057;
  public const int rsa_pss_pss_sha384 = 2058;
  public const int rsa_pss_pss_sha512 = 2059;
  public const int ecdsa_brainpoolP256r1tls13_sha256 = 2074;
  public const int ecdsa_brainpoolP384r1tls13_sha384 = 2075;
  public const int ecdsa_brainpoolP512r1tls13_sha512 = 2076;
  public const int sm2sig_sm3 = 1800;

  public static int From(SignatureAndHashAlgorithm sigAndHashAlg)
  {
    if (sigAndHashAlg == null)
      throw new ArgumentNullException();
    return SignatureScheme.From(sigAndHashAlg.Hash, sigAndHashAlg.Signature);
  }

  public static int From(short hashAlgorithm, short signatureAlgorithm)
  {
    return ((int) hashAlgorithm & (int) byte.MaxValue) << 8 | (int) signatureAlgorithm & (int) byte.MaxValue;
  }

  public static int GetCryptoHashAlgorithm(int signatureScheme)
  {
    switch (signatureScheme)
    {
      case 1800:
        return 7;
      case 2052:
      case 2057:
      case 2074:
        return 4;
      case 2053:
      case 2058:
      case 2075:
        return 5;
      case 2054:
      case 2059:
      case 2076:
        return 6;
      case 2055:
      case 2056:
        return -1;
      default:
        short hashAlgorithm = SignatureScheme.GetHashAlgorithm(signatureScheme);
        return (short) 8 != hashAlgorithm && HashAlgorithm.IsRecognized(hashAlgorithm) ? TlsCryptoUtilities.GetHash(hashAlgorithm) : -1;
    }
  }

  public static int GetCryptoHashAlgorithm(
    SignatureAndHashAlgorithm signatureAndHashAlgorithm)
  {
    return SignatureScheme.GetCryptoHashAlgorithm(SignatureScheme.From(signatureAndHashAlgorithm));
  }

  public static string GetName(int signatureScheme)
  {
    switch (signatureScheme)
    {
      case 513:
        return "rsa_pkcs1_sha1";
      case 515:
        return "ecdsa_sha1";
      case 1025:
        return "rsa_pkcs1_sha256";
      case 1027:
        return "ecdsa_secp256r1_sha256";
      case 1281:
        return "rsa_pkcs1_sha384";
      case 1283:
        return "ecdsa_secp384r1_sha384";
      case 1537:
        return "rsa_pkcs1_sha512";
      case 1539:
        return "ecdsa_secp521r1_sha512";
      case 1800:
        return "sm2sig_sm3";
      case 2052:
        return "rsa_pss_rsae_sha256";
      case 2053:
        return "rsa_pss_rsae_sha384";
      case 2054:
        return "rsa_pss_rsae_sha512";
      case 2055:
        return "ed25519";
      case 2056:
        return "ed448";
      case 2057:
        return "rsa_pss_pss_sha256";
      case 2058:
        return "rsa_pss_pss_sha384";
      case 2059:
        return "rsa_pss_pss_sha512";
      case 2074:
        return "ecdsa_brainpoolP256r1tls13_sha256";
      case 2075:
        return "ecdsa_brainpoolP384r1tls13_sha384";
      case 2076:
        return "ecdsa_brainpoolP512r1tls13_sha512";
      default:
        return "UNKNOWN";
    }
  }

  public static int GetNamedGroup(int signatureScheme)
  {
    switch (signatureScheme)
    {
      case 1027:
        return 23;
      case 1283:
        return 24;
      case 1539:
        return 25;
      case 1800:
        return 41;
      case 2074:
        return 31 /*0x1F*/;
      case 2075:
        return 32 /*0x20*/;
      case 2076:
        return 33;
      default:
        return -1;
    }
  }

  public static short GetHashAlgorithm(int signatureScheme)
  {
    return (short) (signatureScheme >> 8 & (int) byte.MaxValue);
  }

  public static short GetSignatureAlgorithm(int signatureScheme)
  {
    return (short) (signatureScheme & (int) byte.MaxValue);
  }

  public static SignatureAndHashAlgorithm GetSignatureAndHashAlgorithm(int signatureScheme)
  {
    return SignatureAndHashAlgorithm.GetInstance(SignatureScheme.GetHashAlgorithm(signatureScheme), SignatureScheme.GetSignatureAlgorithm(signatureScheme));
  }

  public static string GetText(int signatureScheme)
  {
    string upperInvariant = Convert.ToString(signatureScheme, 16 /*0x10*/).ToUpperInvariant();
    return $"{SignatureScheme.GetName(signatureScheme)}(0x{upperInvariant})";
  }

  public static bool IsPrivate(int signatureScheme) => signatureScheme >> 9 == 254;

  public static bool IsECDsa(int signatureScheme)
  {
    switch (signatureScheme)
    {
      case 2074:
      case 2075:
      case 2076:
        return true;
      default:
        return (short) 3 == SignatureScheme.GetSignatureAlgorithm(signatureScheme);
    }
  }

  public static bool IsRsaPss(int signatureScheme)
  {
    switch (signatureScheme)
    {
      case 2052:
      case 2053:
      case 2054:
      case 2057:
      case 2058:
      case 2059:
        return true;
      default:
        return false;
    }
  }
}
