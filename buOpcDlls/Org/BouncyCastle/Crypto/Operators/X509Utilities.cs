// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.X509Utilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.GM;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

internal class X509Utilities
{
  private static readonly IDictionary<string, DerObjectIdentifier> m_algorithms = (IDictionary<string, DerObjectIdentifier>) new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly IDictionary<string, Asn1Encodable> m_exParams = (IDictionary<string, Asn1Encodable>) new Dictionary<string, Asn1Encodable>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly HashSet<DerObjectIdentifier> noParams = new HashSet<DerObjectIdentifier>();

  static X509Utilities()
  {
    X509Utilities.m_algorithms.Add("MD2WITHRSAENCRYPTION", PkcsObjectIdentifiers.MD2WithRsaEncryption);
    X509Utilities.m_algorithms.Add("MD2WITHRSA", PkcsObjectIdentifiers.MD2WithRsaEncryption);
    X509Utilities.m_algorithms.Add("MD5WITHRSAENCRYPTION", PkcsObjectIdentifiers.MD5WithRsaEncryption);
    X509Utilities.m_algorithms.Add("MD5WITHRSA", PkcsObjectIdentifiers.MD5WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA1WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-1WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA1WITHRSA", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-1WITHRSA", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA224WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-224WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA224WITHRSA", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-224WITHRSA", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA256WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-256WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA256WITHRSA", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-256WITHRSA", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA384WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-384WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA384WITHRSA", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-384WITHRSA", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA512WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-512WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA512WITHRSA", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-512WITHRSA", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA512(224)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA-512(224)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA512(224)WITHRSA", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA-512(224)WITHRSA", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA512(256)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA-512(256)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA512(256)WITHRSA", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA-512(256)WITHRSA", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA3-224WITHRSAENCRYPTION", NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224);
    X509Utilities.m_algorithms.Add("SHA3-256WITHRSAENCRYPTION", NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256);
    X509Utilities.m_algorithms.Add("SHA3-384WITHRSAENCRYPTION", NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384);
    X509Utilities.m_algorithms.Add("SHA3-512WITHRSAENCRYPTION", NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512);
    X509Utilities.m_algorithms.Add("SHA3-224WITHRSA", NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224);
    X509Utilities.m_algorithms.Add("SHA3-256WITHRSA", NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256);
    X509Utilities.m_algorithms.Add("SHA3-384WITHRSA", NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384);
    X509Utilities.m_algorithms.Add("SHA3-512WITHRSA", NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512);
    X509Utilities.m_algorithms.Add("SHA1WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    X509Utilities.m_algorithms.Add("SHA224WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    X509Utilities.m_algorithms.Add("SHA256WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    X509Utilities.m_algorithms.Add("SHA384WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    X509Utilities.m_algorithms.Add("SHA512WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    X509Utilities.m_algorithms.Add("RIPEMD160WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160);
    X509Utilities.m_algorithms.Add("RIPEMD160WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160);
    X509Utilities.m_algorithms.Add("RIPEMD128WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128);
    X509Utilities.m_algorithms.Add("RIPEMD128WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128);
    X509Utilities.m_algorithms.Add("RIPEMD256WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256);
    X509Utilities.m_algorithms.Add("RIPEMD256WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256);
    X509Utilities.m_algorithms.Add("SHA1WITHDSA", X9ObjectIdentifiers.IdDsaWithSha1);
    X509Utilities.m_algorithms.Add("DSAWITHSHA1", X9ObjectIdentifiers.IdDsaWithSha1);
    X509Utilities.m_algorithms.Add("SHA224WITHDSA", NistObjectIdentifiers.DsaWithSha224);
    X509Utilities.m_algorithms.Add("SHA256WITHDSA", NistObjectIdentifiers.DsaWithSha256);
    X509Utilities.m_algorithms.Add("SHA384WITHDSA", NistObjectIdentifiers.DsaWithSha384);
    X509Utilities.m_algorithms.Add("SHA512WITHDSA", NistObjectIdentifiers.DsaWithSha512);
    X509Utilities.m_algorithms.Add("SHA1WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha1);
    X509Utilities.m_algorithms.Add("ECDSAWITHSHA1", X9ObjectIdentifiers.ECDsaWithSha1);
    X509Utilities.m_algorithms.Add("SHA224WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha224);
    X509Utilities.m_algorithms.Add("SHA256WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha256);
    X509Utilities.m_algorithms.Add("SHA384WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha384);
    X509Utilities.m_algorithms.Add("SHA512WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha512);
    X509Utilities.m_algorithms.Add("GOST3411WITHGOST3410", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    X509Utilities.m_algorithms.Add("GOST3411WITHGOST3410-94", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    X509Utilities.m_algorithms.Add("GOST3411WITHECGOST3410", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    X509Utilities.m_algorithms.Add("GOST3411WITHECGOST3410-2001", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    X509Utilities.m_algorithms.Add("GOST3411WITHGOST3410-2001", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    X509Utilities.m_algorithms.Add("GOST3411-2012-256WITHECGOST3410", RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256);
    X509Utilities.m_algorithms.Add("GOST3411-2012-256WITHECGOST3410-2012-256", RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256);
    X509Utilities.m_algorithms.Add("GOST3411-2012-512WITHECGOST3410", RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512);
    X509Utilities.m_algorithms.Add("GOST3411-2012-512WITHECGOST3410-2012-512", RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512);
    X509Utilities.m_algorithms.Add("Ed25519", EdECObjectIdentifiers.id_Ed25519);
    X509Utilities.m_algorithms.Add("Ed448", EdECObjectIdentifiers.id_Ed448);
    X509Utilities.m_algorithms.Add("SHA256WITHSM2", GMObjectIdentifiers.sm2sign_with_sha256);
    X509Utilities.m_algorithms.Add("SM3WITHSM2", GMObjectIdentifiers.sm2sign_with_sm3);
    X509Utilities.noParams.Add(X9ObjectIdentifiers.ECDsaWithSha1);
    X509Utilities.noParams.Add(X9ObjectIdentifiers.ECDsaWithSha224);
    X509Utilities.noParams.Add(X9ObjectIdentifiers.ECDsaWithSha256);
    X509Utilities.noParams.Add(X9ObjectIdentifiers.ECDsaWithSha384);
    X509Utilities.noParams.Add(X9ObjectIdentifiers.ECDsaWithSha512);
    X509Utilities.noParams.Add(X9ObjectIdentifiers.IdDsaWithSha1);
    X509Utilities.noParams.Add(OiwObjectIdentifiers.DsaWithSha1);
    X509Utilities.noParams.Add(NistObjectIdentifiers.DsaWithSha224);
    X509Utilities.noParams.Add(NistObjectIdentifiers.DsaWithSha256);
    X509Utilities.noParams.Add(NistObjectIdentifiers.DsaWithSha384);
    X509Utilities.noParams.Add(NistObjectIdentifiers.DsaWithSha512);
    X509Utilities.noParams.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    X509Utilities.noParams.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    AlgorithmIdentifier hashAlgId1 = new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1, (Asn1Encodable) DerNull.Instance);
    X509Utilities.m_exParams.Add("SHA1WITHRSAANDMGF1", (Asn1Encodable) X509Utilities.CreatePssParams(hashAlgId1, 20));
    AlgorithmIdentifier hashAlgId2 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha224, (Asn1Encodable) DerNull.Instance);
    X509Utilities.m_exParams.Add("SHA224WITHRSAANDMGF1", (Asn1Encodable) X509Utilities.CreatePssParams(hashAlgId2, 28));
    AlgorithmIdentifier hashAlgId3 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha256, (Asn1Encodable) DerNull.Instance);
    X509Utilities.m_exParams.Add("SHA256WITHRSAANDMGF1", (Asn1Encodable) X509Utilities.CreatePssParams(hashAlgId3, 32 /*0x20*/));
    AlgorithmIdentifier hashAlgId4 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha384, (Asn1Encodable) DerNull.Instance);
    X509Utilities.m_exParams.Add("SHA384WITHRSAANDMGF1", (Asn1Encodable) X509Utilities.CreatePssParams(hashAlgId4, 48 /*0x30*/));
    AlgorithmIdentifier hashAlgId5 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha512, (Asn1Encodable) DerNull.Instance);
    X509Utilities.m_exParams.Add("SHA512WITHRSAANDMGF1", (Asn1Encodable) X509Utilities.CreatePssParams(hashAlgId5, 64 /*0x40*/));
  }

  private static string GetDigestAlgName(DerObjectIdentifier digestAlgOID)
  {
    if (PkcsObjectIdentifiers.MD5.Equals((Asn1Object) digestAlgOID))
      return "MD5";
    if (OiwObjectIdentifiers.IdSha1.Equals((Asn1Object) digestAlgOID))
      return "SHA1";
    if (NistObjectIdentifiers.IdSha224.Equals((Asn1Object) digestAlgOID))
      return "SHA224";
    if (NistObjectIdentifiers.IdSha256.Equals((Asn1Object) digestAlgOID))
      return "SHA256";
    if (NistObjectIdentifiers.IdSha384.Equals((Asn1Object) digestAlgOID))
      return "SHA384";
    if (NistObjectIdentifiers.IdSha512.Equals((Asn1Object) digestAlgOID))
      return "SHA512";
    if (NistObjectIdentifiers.IdSha512_224.Equals((Asn1Object) digestAlgOID))
      return "SHA512(224)";
    if (NistObjectIdentifiers.IdSha512_256.Equals((Asn1Object) digestAlgOID))
      return "SHA512(256)";
    if (TeleTrusTObjectIdentifiers.RipeMD128.Equals((Asn1Object) digestAlgOID))
      return "RIPEMD128";
    if (TeleTrusTObjectIdentifiers.RipeMD160.Equals((Asn1Object) digestAlgOID))
      return "RIPEMD160";
    if (TeleTrusTObjectIdentifiers.RipeMD256.Equals((Asn1Object) digestAlgOID))
      return "RIPEMD256";
    if (CryptoProObjectIdentifiers.GostR3411.Equals((Asn1Object) digestAlgOID))
      return "GOST3411";
    if (RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256.Equals((Asn1Object) digestAlgOID))
      return "GOST3411-2012-256";
    return RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512.Equals((Asn1Object) digestAlgOID) ? "GOST3411-2012-512" : digestAlgOID.Id;
  }

  internal static string GetSignatureName(AlgorithmIdentifier sigAlgId)
  {
    Asn1Encodable parameters = sigAlgId.Parameters;
    if (parameters != null && !DerNull.Instance.Equals((object) parameters))
    {
      if (sigAlgId.Algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsassaPss))
        return X509Utilities.GetDigestAlgName(RsassaPssParameters.GetInstance((object) parameters).HashAlgorithm.Algorithm) + "withRSAandMGF1";
      if (sigAlgId.Algorithm.Equals((Asn1Object) X9ObjectIdentifiers.ECDsaWithSha2))
        return X509Utilities.GetDigestAlgName((DerObjectIdentifier) Asn1Sequence.GetInstance((object) parameters)[0]) + "withECDSA";
    }
    return sigAlgId.Algorithm.Id;
  }

  private static RsassaPssParameters CreatePssParams(AlgorithmIdentifier hashAlgId, int saltSize)
  {
    return new RsassaPssParameters(hashAlgId, new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) hashAlgId), new DerInteger(saltSize), new DerInteger(1));
  }

  internal static DerObjectIdentifier GetAlgorithmOid(string algorithmName)
  {
    DerObjectIdentifier objectIdentifier;
    return X509Utilities.m_algorithms.TryGetValue(algorithmName, out objectIdentifier) ? objectIdentifier : new DerObjectIdentifier(algorithmName);
  }

  internal static AlgorithmIdentifier GetSigAlgID(DerObjectIdentifier sigOid, string algorithmName)
  {
    if (X509Utilities.noParams.Contains(sigOid))
      return new AlgorithmIdentifier(sigOid);
    Asn1Encodable parameters;
    return X509Utilities.m_exParams.TryGetValue(algorithmName, out parameters) ? new AlgorithmIdentifier(sigOid, parameters) : new AlgorithmIdentifier(sigOid, (Asn1Encodable) DerNull.Instance);
  }

  internal static IEnumerable<string> GetAlgNames()
  {
    return CollectionUtilities.Proxy<string>((IEnumerable<string>) X509Utilities.m_algorithms.Keys);
  }
}
