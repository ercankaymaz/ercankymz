// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.CryptoSignatureAlgorithm
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public abstract class CryptoSignatureAlgorithm
{
  public const int rsa = 1;
  public const int dsa = 2;
  public const int ecdsa = 3;
  public const int rsa_pss_rsae_sha256 = 4;
  public const int rsa_pss_rsae_sha384 = 5;
  public const int rsa_pss_rsae_sha512 = 6;
  public const int ed25519 = 7;
  public const int ed448 = 8;
  public const int rsa_pss_pss_sha256 = 9;
  public const int rsa_pss_pss_sha384 = 10;
  public const int rsa_pss_pss_sha512 = 11;
  public const int ecdsa_brainpoolP256r1tls13_sha256 = 26;
  public const int ecdsa_brainpoolP384r1tls13_sha384 = 27;
  public const int ecdsa_brainpoolP512r1tls13_sha512 = 28;
  public const int gostr34102012_256 = 64 /*0x40*/;
  public const int gostr34102012_512 = 65;
  public const int sm2 = 200;
}
