// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.SignatureAndHashAlgorithm
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class SignatureAndHashAlgorithm
{
  public static readonly SignatureAndHashAlgorithm ecdsa_brainpoolP256r1tls13_sha256 = SignatureAndHashAlgorithm.Create(2074);
  public static readonly SignatureAndHashAlgorithm ecdsa_brainpoolP384r1tls13_sha384 = SignatureAndHashAlgorithm.Create(2075);
  public static readonly SignatureAndHashAlgorithm ecdsa_brainpoolP512r1tls13_sha512 = SignatureAndHashAlgorithm.Create(2076);
  public static readonly SignatureAndHashAlgorithm ed25519 = SignatureAndHashAlgorithm.Create(2055);
  public static readonly SignatureAndHashAlgorithm ed448 = SignatureAndHashAlgorithm.Create(2056);
  public static readonly SignatureAndHashAlgorithm gostr34102012_256 = SignatureAndHashAlgorithm.Create((short) 8, (short) 64 /*0x40*/);
  public static readonly SignatureAndHashAlgorithm gostr34102012_512 = SignatureAndHashAlgorithm.Create((short) 8, (short) 65);
  public static readonly SignatureAndHashAlgorithm rsa_pss_rsae_sha256 = SignatureAndHashAlgorithm.Create(2052);
  public static readonly SignatureAndHashAlgorithm rsa_pss_rsae_sha384 = SignatureAndHashAlgorithm.Create(2053);
  public static readonly SignatureAndHashAlgorithm rsa_pss_rsae_sha512 = SignatureAndHashAlgorithm.Create(2054);
  public static readonly SignatureAndHashAlgorithm rsa_pss_pss_sha256 = SignatureAndHashAlgorithm.Create(2057);
  public static readonly SignatureAndHashAlgorithm rsa_pss_pss_sha384 = SignatureAndHashAlgorithm.Create(2058);
  public static readonly SignatureAndHashAlgorithm rsa_pss_pss_sha512 = SignatureAndHashAlgorithm.Create(2059);
  private readonly short m_hash;
  private readonly short m_signature;

  public static SignatureAndHashAlgorithm GetInstance(short hashAlgorithm, short signatureAlgorithm)
  {
    return hashAlgorithm == (short) 8 ? SignatureAndHashAlgorithm.GetInstanceIntrinsic(signatureAlgorithm) : SignatureAndHashAlgorithm.Create(hashAlgorithm, signatureAlgorithm);
  }

  private static SignatureAndHashAlgorithm GetInstanceIntrinsic(short signatureAlgorithm)
  {
    switch (signatureAlgorithm)
    {
      case 4:
        return SignatureAndHashAlgorithm.rsa_pss_rsae_sha256;
      case 5:
        return SignatureAndHashAlgorithm.rsa_pss_rsae_sha384;
      case 6:
        return SignatureAndHashAlgorithm.rsa_pss_rsae_sha512;
      case 7:
        return SignatureAndHashAlgorithm.ed25519;
      case 8:
        return SignatureAndHashAlgorithm.ed448;
      case 9:
        return SignatureAndHashAlgorithm.rsa_pss_pss_sha256;
      case 10:
        return SignatureAndHashAlgorithm.rsa_pss_pss_sha384;
      case 11:
        return SignatureAndHashAlgorithm.rsa_pss_pss_sha512;
      case 26:
        return SignatureAndHashAlgorithm.ecdsa_brainpoolP256r1tls13_sha256;
      case 27:
        return SignatureAndHashAlgorithm.ecdsa_brainpoolP384r1tls13_sha384;
      case 28:
        return SignatureAndHashAlgorithm.ecdsa_brainpoolP512r1tls13_sha512;
      case 64 /*0x40*/:
        return SignatureAndHashAlgorithm.gostr34102012_256;
      case 65:
        return SignatureAndHashAlgorithm.gostr34102012_512;
      default:
        return SignatureAndHashAlgorithm.Create((short) 8, signatureAlgorithm);
    }
  }

  private static SignatureAndHashAlgorithm Create(int signatureScheme)
  {
    return SignatureAndHashAlgorithm.Create(SignatureScheme.GetHashAlgorithm(signatureScheme), SignatureScheme.GetSignatureAlgorithm(signatureScheme));
  }

  private static SignatureAndHashAlgorithm Create(short hashAlgorithm, short signatureAlgorithm)
  {
    return new SignatureAndHashAlgorithm(hashAlgorithm, signatureAlgorithm);
  }

  public SignatureAndHashAlgorithm(short hash, short signature)
  {
    if (((int) hash & (int) byte.MaxValue) != (int) hash)
      throw new ArgumentException("should be a uint8", nameof (hash));
    if (((int) signature & (int) byte.MaxValue) != (int) signature)
      throw new ArgumentException("should be a uint8", nameof (signature));
    this.m_hash = hash;
    this.m_signature = signature;
  }

  public short Hash => this.m_hash;

  public short Signature => this.m_signature;

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint8(this.Hash, output);
    TlsUtilities.WriteUint8(this.Signature, output);
  }

  public static SignatureAndHashAlgorithm Parse(Stream input)
  {
    return SignatureAndHashAlgorithm.GetInstance(TlsUtilities.ReadUint8(input), TlsUtilities.ReadUint8(input));
  }

  public override bool Equals(object obj)
  {
    if (!(obj is SignatureAndHashAlgorithm))
      return false;
    SignatureAndHashAlgorithm andHashAlgorithm = (SignatureAndHashAlgorithm) obj;
    return (int) andHashAlgorithm.Hash == (int) this.Hash && (int) andHashAlgorithm.Signature == (int) this.Signature;
  }

  public override int GetHashCode() => (int) this.Hash << 16 /*0x10*/ | (int) this.Signature;

  public override string ToString()
  {
    return $"{{{HashAlgorithm.GetText(this.Hash)},{SignatureAlgorithm.GetText(this.Signature)}}}";
  }
}
