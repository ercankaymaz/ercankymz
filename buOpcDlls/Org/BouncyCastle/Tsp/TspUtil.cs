// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tsp.TspUtil
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.GM;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tsp;

public class TspUtil
{
  private static readonly Dictionary<string, int> DigestLengths = new Dictionary<string, int>();
  private static readonly Dictionary<string, string> DigestNames = new Dictionary<string, string>();

  static TspUtil()
  {
    TspUtil.DigestLengths.Add(PkcsObjectIdentifiers.MD5.Id, 16 /*0x10*/);
    TspUtil.DigestLengths.Add(OiwObjectIdentifiers.IdSha1.Id, 20);
    TspUtil.DigestLengths.Add(NistObjectIdentifiers.IdSha224.Id, 28);
    TspUtil.DigestLengths.Add(NistObjectIdentifiers.IdSha256.Id, 32 /*0x20*/);
    TspUtil.DigestLengths.Add(NistObjectIdentifiers.IdSha384.Id, 48 /*0x30*/);
    TspUtil.DigestLengths.Add(NistObjectIdentifiers.IdSha512.Id, 64 /*0x40*/);
    TspUtil.DigestLengths.Add(TeleTrusTObjectIdentifiers.RipeMD128.Id, 16 /*0x10*/);
    TspUtil.DigestLengths.Add(TeleTrusTObjectIdentifiers.RipeMD160.Id, 20);
    TspUtil.DigestLengths.Add(TeleTrusTObjectIdentifiers.RipeMD256.Id, 32 /*0x20*/);
    TspUtil.DigestLengths.Add(CryptoProObjectIdentifiers.GostR3411.Id, 32 /*0x20*/);
    TspUtil.DigestLengths.Add(RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256.Id, 32 /*0x20*/);
    TspUtil.DigestLengths.Add(RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512.Id, 64 /*0x40*/);
    TspUtil.DigestLengths.Add(GMObjectIdentifiers.sm3.Id, 32 /*0x20*/);
    TspUtil.DigestNames.Add(PkcsObjectIdentifiers.MD5.Id, "MD5");
    TspUtil.DigestNames.Add(OiwObjectIdentifiers.IdSha1.Id, "SHA1");
    TspUtil.DigestNames.Add(NistObjectIdentifiers.IdSha224.Id, "SHA224");
    TspUtil.DigestNames.Add(NistObjectIdentifiers.IdSha256.Id, "SHA256");
    TspUtil.DigestNames.Add(NistObjectIdentifiers.IdSha384.Id, "SHA384");
    TspUtil.DigestNames.Add(NistObjectIdentifiers.IdSha512.Id, "SHA512");
    TspUtil.DigestNames.Add(PkcsObjectIdentifiers.MD5WithRsaEncryption.Id, "MD5");
    TspUtil.DigestNames.Add(PkcsObjectIdentifiers.Sha1WithRsaEncryption.Id, "SHA1");
    TspUtil.DigestNames.Add(PkcsObjectIdentifiers.Sha224WithRsaEncryption.Id, "SHA224");
    TspUtil.DigestNames.Add(PkcsObjectIdentifiers.Sha256WithRsaEncryption.Id, "SHA256");
    TspUtil.DigestNames.Add(PkcsObjectIdentifiers.Sha384WithRsaEncryption.Id, "SHA384");
    TspUtil.DigestNames.Add(PkcsObjectIdentifiers.Sha512WithRsaEncryption.Id, "SHA512");
    TspUtil.DigestNames.Add(TeleTrusTObjectIdentifiers.RipeMD128.Id, "RIPEMD128");
    TspUtil.DigestNames.Add(TeleTrusTObjectIdentifiers.RipeMD160.Id, "RIPEMD160");
    TspUtil.DigestNames.Add(TeleTrusTObjectIdentifiers.RipeMD256.Id, "RIPEMD256");
    TspUtil.DigestNames.Add(CryptoProObjectIdentifiers.GostR3411.Id, "GOST3411");
    TspUtil.DigestNames.Add(OiwObjectIdentifiers.DsaWithSha1.Id, "SHA1");
    TspUtil.DigestNames.Add(OiwObjectIdentifiers.Sha1WithRsa.Id, "SHA1");
    TspUtil.DigestNames.Add(OiwObjectIdentifiers.MD5WithRsa.Id, "MD5");
    TspUtil.DigestNames.Add(RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256.Id, "GOST3411-2012-256");
    TspUtil.DigestNames.Add(RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512.Id, "GOST3411-2012-512");
    TspUtil.DigestNames.Add(GMObjectIdentifiers.sm3.Id, "SM3");
  }

  public static IList<TimeStampToken> GetSignatureTimestamps(SignerInformation signerInfo)
  {
    List<TimeStampToken> signatureTimestamps = new List<TimeStampToken>();
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes = signerInfo.UnsignedAttributes;
    if (unsignedAttributes != null)
    {
      foreach (Org.BouncyCastle.Asn1.Cms.Attribute attribute in unsignedAttributes.GetAll(PkcsObjectIdentifiers.IdAASignatureTimeStampToken))
      {
        foreach (Asn1Encodable attrValue in attribute.AttrValues)
        {
          try
          {
            TimeStampToken timeStampToken = new TimeStampToken(Org.BouncyCastle.Asn1.Cms.ContentInfo.GetInstance((object) attrValue.ToAsn1Object()));
            TimeStampTokenInfo timeStampInfo = timeStampToken.TimeStampInfo;
            if (!Arrays.FixedTimeEquals(DigestUtilities.CalculateDigest(TspUtil.GetDigestAlgName(timeStampInfo.MessageImprintAlgOid), signerInfo.GetSignature()), timeStampInfo.GetMessageImprintDigest()))
              throw new TspValidationException("Incorrect digest in message imprint");
            signatureTimestamps.Add(timeStampToken);
          }
          catch (SecurityUtilityException ex)
          {
            throw new TspValidationException("Unknown hash algorithm specified in timestamp");
          }
          catch (Exception ex)
          {
            throw new TspValidationException("Timestamp could not be parsed");
          }
        }
      }
    }
    return (IList<TimeStampToken>) signatureTimestamps;
  }

  public static void ValidateCertificate(X509Certificate cert)
  {
    Asn1OctetString asn1OctetString = cert.Version == 3 ? cert.GetExtensionValue(X509Extensions.ExtendedKeyUsage) : throw new ArgumentException("Certificate must have an ExtendedKeyUsage extension.");
    if (asn1OctetString == null)
      throw new TspValidationException("Certificate must have an ExtendedKeyUsage extension.");
    if (!cert.GetCriticalExtensionOids().Contains(X509Extensions.ExtendedKeyUsage.Id))
      throw new TspValidationException("Certificate must have an ExtendedKeyUsage extension marked as critical.");
    try
    {
      ExtendedKeyUsage instance = ExtendedKeyUsage.GetInstance((object) Asn1Object.FromByteArray(asn1OctetString.GetOctets()));
      if (!instance.HasKeyPurposeId(KeyPurposeID.id_kp_timeStamping) || instance.Count != 1)
        throw new TspValidationException("ExtendedKeyUsage not solely time stamping.");
    }
    catch (IOException ex)
    {
      throw new TspValidationException("cannot process ExtendedKeyUsage extension");
    }
  }

  internal static string GetDigestAlgName(string digestAlgOid)
  {
    return CollectionUtilities.GetValueOrKey<string>((IDictionary<string, string>) TspUtil.DigestNames, digestAlgOid);
  }

  internal static int GetDigestLength(string digestAlgOid)
  {
    int digestLength;
    if (!TspUtil.DigestLengths.TryGetValue(digestAlgOid, out digestLength))
      throw new TspException("digest algorithm cannot be found.");
    return digestLength;
  }

  internal static IDigest CreateDigestInstance(string digestAlgOID)
  {
    return DigestUtilities.GetDigest(TspUtil.GetDigestAlgName(digestAlgOID));
  }

  internal static HashSet<DerObjectIdentifier> GetCriticalExtensionOids(X509Extensions extensions)
  {
    return extensions != null ? new HashSet<DerObjectIdentifier>((IEnumerable<DerObjectIdentifier>) extensions.GetCriticalExtensionOids()) : new HashSet<DerObjectIdentifier>();
  }

  internal static HashSet<DerObjectIdentifier> GetNonCriticalExtensionOids(X509Extensions extensions)
  {
    return extensions != null ? new HashSet<DerObjectIdentifier>((IEnumerable<DerObjectIdentifier>) extensions.GetNonCriticalExtensionOids()) : new HashSet<DerObjectIdentifier>();
  }

  internal static IList<DerObjectIdentifier> GetExtensionOids(X509Extensions extensions)
  {
    return extensions != null ? (IList<DerObjectIdentifier>) new List<DerObjectIdentifier>((IEnumerable<DerObjectIdentifier>) extensions.GetExtensionOids()) : (IList<DerObjectIdentifier>) new List<DerObjectIdentifier>();
  }
}
