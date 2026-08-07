// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsSignedHelper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.Eac;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

internal class CmsSignedHelper
{
  internal static readonly CmsSignedHelper Instance = new CmsSignedHelper();
  private static readonly string EncryptionECDsaWithSha1 = X9ObjectIdentifiers.ECDsaWithSha1.Id;
  private static readonly string EncryptionECDsaWithSha224 = X9ObjectIdentifiers.ECDsaWithSha224.Id;
  private static readonly string EncryptionECDsaWithSha256 = X9ObjectIdentifiers.ECDsaWithSha256.Id;
  private static readonly string EncryptionECDsaWithSha384 = X9ObjectIdentifiers.ECDsaWithSha384.Id;
  private static readonly string EncryptionECDsaWithSha512 = X9ObjectIdentifiers.ECDsaWithSha512.Id;
  private static readonly IDictionary<string, string> m_encryptionAlgs = (IDictionary<string, string>) new Dictionary<string, string>();
  private static readonly IDictionary<string, string> m_digestAlgs = (IDictionary<string, string>) new Dictionary<string, string>();
  private static readonly IDictionary<string, string[]> m_digestAliases = (IDictionary<string, string[]>) new Dictionary<string, string[]>();
  private static readonly HashSet<string> m_noParams = new HashSet<string>();
  private static readonly IDictionary<string, string> m_ecAlgorithms = (IDictionary<string, string>) new Dictionary<string, string>();

  private static void AddEntries(DerObjectIdentifier oid, string digest, string encryption)
  {
    string id = oid.Id;
    CmsSignedHelper.m_digestAlgs.Add(id, digest);
    CmsSignedHelper.m_encryptionAlgs.Add(id, encryption);
  }

  static CmsSignedHelper()
  {
    CmsSignedHelper.AddEntries(NistObjectIdentifiers.DsaWithSha224, "SHA224", "DSA");
    CmsSignedHelper.AddEntries(NistObjectIdentifiers.DsaWithSha256, "SHA256", "DSA");
    CmsSignedHelper.AddEntries(NistObjectIdentifiers.DsaWithSha384, "SHA384", "DSA");
    CmsSignedHelper.AddEntries(NistObjectIdentifiers.DsaWithSha512, "SHA512", "DSA");
    CmsSignedHelper.AddEntries(OiwObjectIdentifiers.DsaWithSha1, "SHA1", "DSA");
    CmsSignedHelper.AddEntries(OiwObjectIdentifiers.MD4WithRsa, "MD4", "RSA");
    CmsSignedHelper.AddEntries(OiwObjectIdentifiers.MD4WithRsaEncryption, "MD4", "RSA");
    CmsSignedHelper.AddEntries(OiwObjectIdentifiers.MD5WithRsa, "MD5", "RSA");
    CmsSignedHelper.AddEntries(OiwObjectIdentifiers.Sha1WithRsa, "SHA1", "RSA");
    CmsSignedHelper.AddEntries(PkcsObjectIdentifiers.MD2WithRsaEncryption, "MD2", "RSA");
    CmsSignedHelper.AddEntries(PkcsObjectIdentifiers.MD4WithRsaEncryption, "MD4", "RSA");
    CmsSignedHelper.AddEntries(PkcsObjectIdentifiers.MD5WithRsaEncryption, "MD5", "RSA");
    CmsSignedHelper.AddEntries(PkcsObjectIdentifiers.Sha1WithRsaEncryption, "SHA1", "RSA");
    CmsSignedHelper.AddEntries(PkcsObjectIdentifiers.Sha224WithRsaEncryption, "SHA224", "RSA");
    CmsSignedHelper.AddEntries(PkcsObjectIdentifiers.Sha256WithRsaEncryption, "SHA256", "RSA");
    CmsSignedHelper.AddEntries(PkcsObjectIdentifiers.Sha384WithRsaEncryption, "SHA384", "RSA");
    CmsSignedHelper.AddEntries(PkcsObjectIdentifiers.Sha512WithRsaEncryption, "SHA512", "RSA");
    CmsSignedHelper.AddEntries(PkcsObjectIdentifiers.Sha512_224WithRSAEncryption, "SHA512(224)", "RSA");
    CmsSignedHelper.AddEntries(PkcsObjectIdentifiers.Sha512_256WithRSAEncryption, "SHA512(256)", "RSA");
    CmsSignedHelper.AddEntries(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224, "SHA3-224", "RSA");
    CmsSignedHelper.AddEntries(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256, "SHA3-256", "RSA");
    CmsSignedHelper.AddEntries(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384, "SHA3-384", "RSA");
    CmsSignedHelper.AddEntries(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512, "SHA3-512", "RSA");
    CmsSignedHelper.AddEntries(X9ObjectIdentifiers.ECDsaWithSha1, "SHA1", "ECDSA");
    CmsSignedHelper.AddEntries(X9ObjectIdentifiers.ECDsaWithSha224, "SHA224", "ECDSA");
    CmsSignedHelper.AddEntries(X9ObjectIdentifiers.ECDsaWithSha256, "SHA256", "ECDSA");
    CmsSignedHelper.AddEntries(X9ObjectIdentifiers.ECDsaWithSha384, "SHA384", "ECDSA");
    CmsSignedHelper.AddEntries(X9ObjectIdentifiers.ECDsaWithSha512, "SHA512", "ECDSA");
    CmsSignedHelper.AddEntries(X9ObjectIdentifiers.IdDsaWithSha1, "SHA1", "DSA");
    CmsSignedHelper.AddEntries(EacObjectIdentifiers.id_TA_ECDSA_SHA_1, "SHA1", "ECDSA");
    CmsSignedHelper.AddEntries(EacObjectIdentifiers.id_TA_ECDSA_SHA_224, "SHA224", "ECDSA");
    CmsSignedHelper.AddEntries(EacObjectIdentifiers.id_TA_ECDSA_SHA_256, "SHA256", "ECDSA");
    CmsSignedHelper.AddEntries(EacObjectIdentifiers.id_TA_ECDSA_SHA_384, "SHA384", "ECDSA");
    CmsSignedHelper.AddEntries(EacObjectIdentifiers.id_TA_ECDSA_SHA_512, "SHA512", "ECDSA");
    CmsSignedHelper.AddEntries(EacObjectIdentifiers.id_TA_RSA_v1_5_SHA_1, "SHA1", "RSA");
    CmsSignedHelper.AddEntries(EacObjectIdentifiers.id_TA_RSA_v1_5_SHA_256, "SHA256", "RSA");
    CmsSignedHelper.AddEntries(EacObjectIdentifiers.id_TA_RSA_PSS_SHA_1, "SHA1", "RSAandMGF1");
    CmsSignedHelper.AddEntries(EacObjectIdentifiers.id_TA_RSA_PSS_SHA_256, "SHA256", "RSAandMGF1");
    CmsSignedHelper.AddEntries(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94, "GOST3411", "GOST3410");
    CmsSignedHelper.AddEntries(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001, "GOST3411", "ECGOST3410");
    CmsSignedHelper.AddEntries(RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256, "GOST3411-2012-256", "ECGOST3410");
    CmsSignedHelper.AddEntries(RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512, "GOST3411-2012-512", "ECGOST3410");
    CmsSignedHelper.m_encryptionAlgs.Add(X9ObjectIdentifiers.IdDsa.Id, "DSA");
    CmsSignedHelper.m_encryptionAlgs.Add(PkcsObjectIdentifiers.RsaEncryption.Id, "RSA");
    CmsSignedHelper.m_encryptionAlgs.Add(TeleTrusTObjectIdentifiers.TeleTrusTRsaSignatureAlgorithm.Id, "RSA");
    CmsSignedHelper.m_encryptionAlgs.Add(X509ObjectIdentifiers.IdEARsa.Id, "RSA");
    CmsSignedHelper.m_encryptionAlgs.Add(CmsSignedGenerator.EncryptionRsaPss, "RSAandMGF1");
    CmsSignedHelper.m_encryptionAlgs.Add(CryptoProObjectIdentifiers.GostR3410x94.Id, "GOST3410");
    CmsSignedHelper.m_encryptionAlgs.Add(CryptoProObjectIdentifiers.GostR3410x2001.Id, "ECGOST3410");
    CmsSignedHelper.m_encryptionAlgs.Add(RosstandartObjectIdentifiers.id_tc26_gost_3410_12_256.Id, "ECGOST3410");
    CmsSignedHelper.m_encryptionAlgs.Add(RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512.Id, "ECGOST3410");
    CmsSignedHelper.m_encryptionAlgs.Add("1.3.6.1.4.1.5849.1.6.2", "ECGOST3410");
    CmsSignedHelper.m_encryptionAlgs.Add("1.3.6.1.4.1.5849.1.1.5", "GOST3410");
    CmsSignedHelper.m_digestAlgs.Add(PkcsObjectIdentifiers.MD2.Id, "MD2");
    CmsSignedHelper.m_digestAlgs.Add(PkcsObjectIdentifiers.MD4.Id, "MD4");
    CmsSignedHelper.m_digestAlgs.Add(PkcsObjectIdentifiers.MD5.Id, "MD5");
    CmsSignedHelper.m_digestAlgs.Add(OiwObjectIdentifiers.IdSha1.Id, "SHA1");
    CmsSignedHelper.m_digestAlgs.Add(NistObjectIdentifiers.IdSha224.Id, "SHA224");
    CmsSignedHelper.m_digestAlgs.Add(NistObjectIdentifiers.IdSha256.Id, "SHA256");
    CmsSignedHelper.m_digestAlgs.Add(NistObjectIdentifiers.IdSha384.Id, "SHA384");
    CmsSignedHelper.m_digestAlgs.Add(NistObjectIdentifiers.IdSha512.Id, "SHA512");
    CmsSignedHelper.m_digestAlgs.Add(NistObjectIdentifiers.IdSha512_224.Id, "SHA512(224)");
    CmsSignedHelper.m_digestAlgs.Add(NistObjectIdentifiers.IdSha512_256.Id, "SHA512(256)");
    CmsSignedHelper.m_digestAlgs.Add(NistObjectIdentifiers.IdSha3_224.Id, "SHA3-224");
    CmsSignedHelper.m_digestAlgs.Add(NistObjectIdentifiers.IdSha3_256.Id, "SHA3-256");
    CmsSignedHelper.m_digestAlgs.Add(NistObjectIdentifiers.IdSha3_384.Id, "SHA3-384");
    CmsSignedHelper.m_digestAlgs.Add(NistObjectIdentifiers.IdSha3_512.Id, "SHA3-512");
    CmsSignedHelper.m_digestAlgs.Add(TeleTrusTObjectIdentifiers.RipeMD128.Id, "RIPEMD128");
    CmsSignedHelper.m_digestAlgs.Add(TeleTrusTObjectIdentifiers.RipeMD160.Id, "RIPEMD160");
    CmsSignedHelper.m_digestAlgs.Add(TeleTrusTObjectIdentifiers.RipeMD256.Id, "RIPEMD256");
    CmsSignedHelper.m_digestAlgs.Add(CryptoProObjectIdentifiers.GostR3411.Id, "GOST3411");
    CmsSignedHelper.m_digestAlgs.Add("1.3.6.1.4.1.5849.1.2.1", "GOST3411");
    CmsSignedHelper.m_digestAlgs.Add(RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256.Id, "GOST3411-2012-256");
    CmsSignedHelper.m_digestAlgs.Add(RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512.Id, "GOST3411-2012-512");
    CmsSignedHelper.m_digestAliases.Add("SHA1", new string[1]
    {
      "SHA-1"
    });
    CmsSignedHelper.m_digestAliases.Add("SHA224", new string[1]
    {
      "SHA-224"
    });
    CmsSignedHelper.m_digestAliases.Add("SHA256", new string[1]
    {
      "SHA-256"
    });
    CmsSignedHelper.m_digestAliases.Add("SHA384", new string[1]
    {
      "SHA-384"
    });
    CmsSignedHelper.m_digestAliases.Add("SHA512", new string[1]
    {
      "SHA-512"
    });
    CmsSignedHelper.m_noParams.Add(CmsSignedGenerator.EncryptionDsa);
    CmsSignedHelper.m_noParams.Add(CmsSignedHelper.EncryptionECDsaWithSha1);
    CmsSignedHelper.m_noParams.Add(CmsSignedHelper.EncryptionECDsaWithSha224);
    CmsSignedHelper.m_noParams.Add(CmsSignedHelper.EncryptionECDsaWithSha256);
    CmsSignedHelper.m_noParams.Add(CmsSignedHelper.EncryptionECDsaWithSha384);
    CmsSignedHelper.m_noParams.Add(CmsSignedHelper.EncryptionECDsaWithSha512);
    CmsSignedHelper.m_ecAlgorithms.Add(CmsSignedGenerator.DigestSha1, CmsSignedHelper.EncryptionECDsaWithSha1);
    CmsSignedHelper.m_ecAlgorithms.Add(CmsSignedGenerator.DigestSha224, CmsSignedHelper.EncryptionECDsaWithSha224);
    CmsSignedHelper.m_ecAlgorithms.Add(CmsSignedGenerator.DigestSha256, CmsSignedHelper.EncryptionECDsaWithSha256);
    CmsSignedHelper.m_ecAlgorithms.Add(CmsSignedGenerator.DigestSha384, CmsSignedHelper.EncryptionECDsaWithSha384);
    CmsSignedHelper.m_ecAlgorithms.Add(CmsSignedGenerator.DigestSha512, CmsSignedHelper.EncryptionECDsaWithSha512);
  }

  internal string GetDigestAlgName(string digestAlgOid)
  {
    return CollectionUtilities.GetValueOrKey<string>(CmsSignedHelper.m_digestAlgs, digestAlgOid);
  }

  internal AlgorithmIdentifier GetEncAlgorithmIdentifier(
    DerObjectIdentifier encOid,
    Asn1Encodable sigX509Parameters)
  {
    return CmsSignedHelper.m_noParams.Contains(encOid.Id) ? new AlgorithmIdentifier(encOid) : new AlgorithmIdentifier(encOid, sigX509Parameters);
  }

  internal string[] GetDigestAliases(string algName)
  {
    string[] strArray;
    return !CmsSignedHelper.m_digestAliases.TryGetValue(algName, out strArray) ? new string[0] : (string[]) strArray.Clone();
  }

  internal string GetEncryptionAlgName(string encryptionAlgOid)
  {
    return CollectionUtilities.GetValueOrKey<string>(CmsSignedHelper.m_encryptionAlgs, encryptionAlgOid);
  }

  internal IDigest GetDigestInstance(string algorithm)
  {
    try
    {
      return DigestUtilities.GetDigest(algorithm);
    }
    catch (SecurityUtilityException ex1)
    {
      foreach (string digestAlias in this.GetDigestAliases(algorithm))
      {
        try
        {
          return DigestUtilities.GetDigest(digestAlias);
        }
        catch (SecurityUtilityException ex2)
        {
        }
      }
      throw;
    }
  }

  internal ISigner GetSignatureInstance(string algorithm) => SignerUtilities.GetSigner(algorithm);

  internal AlgorithmIdentifier FixAlgID(AlgorithmIdentifier algId)
  {
    return algId.Parameters == null ? new AlgorithmIdentifier(algId.Algorithm, (Asn1Encodable) DerNull.Instance) : algId;
  }

  internal string GetEncOid(AsymmetricKeyParameter key, string digestOID)
  {
    string encOid = (string) null;
    switch (key)
    {
      case RsaKeyParameters rsaKeyParameters:
        if (!rsaKeyParameters.IsPrivate)
          throw new ArgumentException("Expected RSA private key");
        encOid = CmsSignedGenerator.EncryptionRsa;
        break;
      case DsaPrivateKeyParameters _:
        if (digestOID.Equals(CmsSignedGenerator.DigestSha1))
        {
          encOid = CmsSignedGenerator.EncryptionDsa;
          break;
        }
        if (digestOID.Equals(CmsSignedGenerator.DigestSha224))
        {
          encOid = NistObjectIdentifiers.DsaWithSha224.Id;
          break;
        }
        if (digestOID.Equals(CmsSignedGenerator.DigestSha256))
        {
          encOid = NistObjectIdentifiers.DsaWithSha256.Id;
          break;
        }
        if (digestOID.Equals(CmsSignedGenerator.DigestSha384))
        {
          encOid = NistObjectIdentifiers.DsaWithSha384.Id;
          break;
        }
        if (!digestOID.Equals(CmsSignedGenerator.DigestSha512))
          throw new ArgumentException("can't mix DSA with anything but SHA1/SHA2");
        encOid = NistObjectIdentifiers.DsaWithSha512.Id;
        break;
      case ECPrivateKeyParameters privateKeyParameters:
        if (privateKeyParameters.AlgorithmName == "ECGOST3410")
        {
          encOid = CmsSignedGenerator.EncryptionECGost3410;
          break;
        }
        if (privateKeyParameters.Parameters is ECGost3410Parameters parameters)
        {
          DerObjectIdentifier digestParamSet = parameters.DigestParamSet;
          if (digestParamSet.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256))
          {
            encOid = CmsSignedGenerator.EncryptionECGost3410_2012_256;
            break;
          }
          if (!digestParamSet.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512))
            throw new ArgumentException("can't determine GOST3410 algorithm");
          encOid = CmsSignedGenerator.EncryptionECGost3410_2012_512;
          break;
        }
        if (!CmsSignedHelper.m_ecAlgorithms.TryGetValue(digestOID, out encOid))
          throw new ArgumentException("can't mix ECDSA with anything but SHA family digests");
        break;
      case Gost3410PrivateKeyParameters _:
        encOid = CmsSignedGenerator.EncryptionGost3410;
        break;
      default:
        throw new ArgumentException("Unknown algorithm in CmsSignedGenerator.GetEncOid");
    }
    return encOid;
  }

  internal IStore<X509V2AttributeCertificate> GetAttributeCertificates(Asn1Set attrCertSet)
  {
    List<X509V2AttributeCertificate> contents = new List<X509V2AttributeCertificate>();
    if (attrCertSet != null)
    {
      foreach (Asn1Encodable attrCert in attrCertSet)
      {
        if (attrCert != null && attrCert.ToAsn1Object() is Asn1TaggedObject asn1Object && asn1Object.HasContextTag(2))
        {
          Asn1Sequence instance = Asn1Sequence.GetInstance(asn1Object, false);
          contents.Add(new X509V2AttributeCertificate(AttributeCertificate.GetInstance((object) instance)));
        }
      }
    }
    return CollectionUtilities.CreateStore<X509V2AttributeCertificate>((IEnumerable<X509V2AttributeCertificate>) contents);
  }

  internal IStore<X509Certificate> GetCertificates(Asn1Set certSet)
  {
    List<X509Certificate> contents = new List<X509Certificate>();
    if (certSet != null)
    {
      foreach (Asn1Encodable cert in certSet)
      {
        if (cert != null)
        {
          if (cert is X509CertificateStructure c)
            contents.Add(new X509Certificate(c));
          else if (cert.ToAsn1Object() is Asn1Sequence asn1Object)
            contents.Add(new X509Certificate(X509CertificateStructure.GetInstance((object) asn1Object)));
        }
      }
    }
    return CollectionUtilities.CreateStore<X509Certificate>((IEnumerable<X509Certificate>) contents);
  }

  internal IStore<X509Crl> GetCrls(Asn1Set crlSet)
  {
    List<X509Crl> contents = new List<X509Crl>();
    if (crlSet != null)
    {
      foreach (Asn1Encodable crl in crlSet)
      {
        if (crl != null)
        {
          if (crl is CertificateList c)
            contents.Add(new X509Crl(c));
          else if (crl.ToAsn1Object() is Asn1Sequence asn1Object)
            contents.Add(new X509Crl(CertificateList.GetInstance((object) asn1Object)));
        }
      }
    }
    return CollectionUtilities.CreateStore<X509Crl>((IEnumerable<X509Crl>) contents);
  }

  internal IStore<Asn1Encodable> GetOtherRevInfos(
    Asn1Set crlSet,
    DerObjectIdentifier otherRevInfoFormat)
  {
    List<Asn1Encodable> contents = new List<Asn1Encodable>();
    if (crlSet != null && otherRevInfoFormat != null)
    {
      foreach (Asn1Encodable crl in crlSet)
      {
        if (crl != null && crl.ToAsn1Object() is Asn1TaggedObject asn1Object && asn1Object.HasContextTag(1))
        {
          OtherRevocationInfoFormat instance = OtherRevocationInfoFormat.GetInstance(asn1Object, false);
          if (otherRevInfoFormat.Equals((Asn1Object) instance.InfoFormat))
            contents.Add(instance.Info);
        }
      }
    }
    return CollectionUtilities.CreateStore<Asn1Encodable>((IEnumerable<Asn1Encodable>) contents);
  }
}
