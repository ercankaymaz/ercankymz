// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.Oids
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class Oids
{
  public const string Dsa = "1.2.840.10040.4.1";
  public const string Rsa = "1.2.840.113549.1.1.1";
  public const string RsaOaep = "1.2.840.113549.1.1.7";
  public const string RsaPss = "1.2.840.113549.1.1.10";
  public const string RsaPkcs1Sha1 = "1.2.840.113549.1.1.5";
  public const string RsaPkcs1Sha256 = "1.2.840.113549.1.1.11";
  public const string RsaPkcs1Sha384 = "1.2.840.113549.1.1.12";
  public const string RsaPkcs1Sha512 = "1.2.840.113549.1.1.13";
  public const string ECPublicKey = "1.2.840.10045.2.1";
  public const string ECDsaWithSha1 = "1.2.840.10045.4.1";
  public const string ECDsaWithSha256 = "1.2.840.10045.4.3.2";
  public const string ECDsaWithSha384 = "1.2.840.10045.4.3.3";
  public const string ECDsaWithSha512 = "1.2.840.10045.4.3.4";
  public const string CrlNumber = "2.5.29.20";
  public const string CrlReasonCode = "2.5.29.21";
  public const string ServerAuthentication = "1.3.6.1.5.5.7.3.1";
  public const string ClientAuthentication = "1.3.6.1.5.5.7.3.2";
  public const string AuthorityInfoAccess = "1.3.6.1.5.5.7.1.1";
  public const string OnlineCertificateStatusProtocol = "1.3.6.1.5.5.7.48.1";
  public const string CertificateAuthorityIssuers = "1.3.6.1.5.5.7.48.2";
  public const string CRLDistributionPoint = "2.5.29.31";

  public static string GetRSAOid(HashAlgorithmName hashAlgorithm)
  {
    if (hashAlgorithm == HashAlgorithmName.SHA1)
      return "1.2.840.113549.1.1.5";
    if (hashAlgorithm == HashAlgorithmName.SHA256)
      return "1.2.840.113549.1.1.11";
    if (hashAlgorithm == HashAlgorithmName.SHA384)
      return "1.2.840.113549.1.1.12";
    if (!(hashAlgorithm == HashAlgorithmName.SHA512))
      throw new NotSupportedException($"Signing RSA with hash {hashAlgorithm.Name} is not supported. ");
    return "1.2.840.113549.1.1.13";
  }

  public static string GetECDsaOid(HashAlgorithmName hashAlgorithm)
  {
    if (hashAlgorithm == HashAlgorithmName.SHA1)
      return "1.2.840.10045.4.1";
    if (hashAlgorithm == HashAlgorithmName.SHA256)
      return "1.2.840.10045.4.3.2";
    if (hashAlgorithm == HashAlgorithmName.SHA384)
      return "1.2.840.10045.4.3.3";
    if (!(hashAlgorithm == HashAlgorithmName.SHA512))
      throw new NotSupportedException($"Signing ECDsa with hash {hashAlgorithm.Name} is not supported. ");
    return "1.2.840.10045.4.3.4";
  }

  public static HashAlgorithmName GetHashAlgorithmName(string oid)
  {
    if (oid != null)
    {
      switch (oid.Length)
      {
        case 17:
          if (oid == "1.2.840.10045.4.1")
            break;
          goto label_15;
        case 19:
          switch (oid[18])
          {
            case '2':
              if (oid == "1.2.840.10045.4.3.2")
                goto label_11;
              goto label_15;
            case '3':
              if (oid == "1.2.840.10045.4.3.3")
                goto label_13;
              goto label_15;
            case '4':
              if (oid == "1.2.840.10045.4.3.4")
                goto label_16;
              goto label_15;
            default:
              goto label_15;
          }
        case 20:
          if (!(oid == "1.2.840.113549.1.1.5"))
            goto label_15;
          break;
        case 21:
          switch (oid[20])
          {
            case '1':
              if (!(oid == "1.2.840.113549.1.1.11"))
                goto label_15;
              goto label_11;
            case '2':
              if (!(oid == "1.2.840.113549.1.1.12"))
                goto label_15;
              goto label_13;
            case '3':
              if (oid == "1.2.840.113549.1.1.13")
                goto label_16;
              goto label_15;
            default:
              goto label_15;
          }
        default:
          goto label_15;
      }
      return HashAlgorithmName.SHA1;
label_11:
      return HashAlgorithmName.SHA256;
label_13:
      return HashAlgorithmName.SHA384;
label_16:
      return HashAlgorithmName.SHA512;
    }
label_15:
    throw new NotSupportedException($"Hash algorithm {oid} is not supported. ");
  }
}
