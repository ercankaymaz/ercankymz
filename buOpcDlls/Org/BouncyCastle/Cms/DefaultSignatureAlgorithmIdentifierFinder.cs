// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.DefaultSignatureAlgorithmIdentifierFinder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.BC;
using Org.BouncyCastle.Asn1.Bsi;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.Eac;
using Org.BouncyCastle.Asn1.GM;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class DefaultSignatureAlgorithmIdentifierFinder
{
  private static readonly IDictionary<string, DerObjectIdentifier> m_algorithms = (IDictionary<string, DerObjectIdentifier>) new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly HashSet<DerObjectIdentifier> noParams = new HashSet<DerObjectIdentifier>();
  private static readonly IDictionary<string, Asn1Encodable> m_params = (IDictionary<string, Asn1Encodable>) new Dictionary<string, Asn1Encodable>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly HashSet<DerObjectIdentifier> pkcs15RsaEncryption = new HashSet<DerObjectIdentifier>();
  private static readonly IDictionary<DerObjectIdentifier, DerObjectIdentifier> m_digestOids = (IDictionary<DerObjectIdentifier, DerObjectIdentifier>) new Dictionary<DerObjectIdentifier, DerObjectIdentifier>();

  static DefaultSignatureAlgorithmIdentifierFinder()
  {
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["MD2WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.MD2WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["MD2WITHRSA"] = PkcsObjectIdentifiers.MD2WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["MD5WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.MD5WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["MD5WITHRSA"] = PkcsObjectIdentifiers.MD5WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA1WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha1WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-1WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha1WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA1WITHRSA"] = PkcsObjectIdentifiers.Sha1WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-1WITHRSA"] = PkcsObjectIdentifiers.Sha1WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA224WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha224WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-224WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha224WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA224WITHRSA"] = PkcsObjectIdentifiers.Sha224WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-224WITHRSA"] = PkcsObjectIdentifiers.Sha224WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA256WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha256WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-256WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha256WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA256WITHRSA"] = PkcsObjectIdentifiers.Sha256WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-256WITHRSA"] = PkcsObjectIdentifiers.Sha256WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA384WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha384WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-384WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha384WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA384WITHRSA"] = PkcsObjectIdentifiers.Sha384WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-384WITHRSA"] = PkcsObjectIdentifiers.Sha384WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-512WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512WITHRSA"] = PkcsObjectIdentifiers.Sha512WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-512WITHRSA"] = PkcsObjectIdentifiers.Sha512WithRsaEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512(224)WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512_224WithRSAEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-512(224)WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512_224WithRSAEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512(224)WITHRSA"] = PkcsObjectIdentifiers.Sha512_224WithRSAEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-512(224)WITHRSA"] = PkcsObjectIdentifiers.Sha512_224WithRSAEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512(256)WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512_256WithRSAEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-512(256)WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512_256WithRSAEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512(256)WITHRSA"] = PkcsObjectIdentifiers.Sha512_256WithRSAEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-512(256)WITHRSA"] = PkcsObjectIdentifiers.Sha512_256WithRSAEncryption;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA1WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA224WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA256WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA384WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-224WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-256WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-384WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-512WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["RIPEMD160WITHRSAENCRYPTION"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["RIPEMD160WITHRSA"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["RIPEMD128WITHRSAENCRYPTION"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["RIPEMD128WITHRSA"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["RIPEMD256WITHRSAENCRYPTION"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["RIPEMD256WITHRSA"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA1WITHDSA"] = X9ObjectIdentifiers.IdDsaWithSha1;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA-1WITHDSA"] = X9ObjectIdentifiers.IdDsaWithSha1;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["DSAWITHSHA1"] = X9ObjectIdentifiers.IdDsaWithSha1;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA224WITHDSA"] = NistObjectIdentifiers.DsaWithSha224;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA256WITHDSA"] = NistObjectIdentifiers.DsaWithSha256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA384WITHDSA"] = NistObjectIdentifiers.DsaWithSha384;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512WITHDSA"] = NistObjectIdentifiers.DsaWithSha512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-224WITHDSA"] = NistObjectIdentifiers.IdDsaWithSha3_224;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-256WITHDSA"] = NistObjectIdentifiers.IdDsaWithSha3_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-384WITHDSA"] = NistObjectIdentifiers.IdDsaWithSha3_384;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-512WITHDSA"] = NistObjectIdentifiers.IdDsaWithSha3_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-224WITHECDSA"] = NistObjectIdentifiers.IdEcdsaWithSha3_224;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-256WITHECDSA"] = NistObjectIdentifiers.IdEcdsaWithSha3_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-384WITHECDSA"] = NistObjectIdentifiers.IdEcdsaWithSha3_384;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-512WITHECDSA"] = NistObjectIdentifiers.IdEcdsaWithSha3_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-224WITHRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-256WITHRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-384WITHRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-512WITHRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-224WITHRSAENCRYPTION"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-256WITHRSAENCRYPTION"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-384WITHRSAENCRYPTION"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-512WITHRSAENCRYPTION"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA1WITHECDSA"] = X9ObjectIdentifiers.ECDsaWithSha1;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["ECDSAWITHSHA1"] = X9ObjectIdentifiers.ECDsaWithSha1;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA224WITHECDSA"] = X9ObjectIdentifiers.ECDsaWithSha224;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA256WITHECDSA"] = X9ObjectIdentifiers.ECDsaWithSha256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA384WITHECDSA"] = X9ObjectIdentifiers.ECDsaWithSha384;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512WITHECDSA"] = X9ObjectIdentifiers.ECDsaWithSha512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411WITHGOST3410"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411WITHGOST3410-94"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411WITHECGOST3410"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411WITHECGOST3410-2001"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411WITHGOST3410-2001"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411WITHECGOST3410-2012-256"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411WITHECGOST3410-2012-512"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411-2012-256WITHECGOST3410"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411-2012-256WITHECGOST3410-2012-256"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411-2012-512WITHECGOST3410"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["GOST3411-2012-512WITHECGOST3410-2012-512"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA1WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA1;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA224WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA224;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA256WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA384WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA384;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["RIPEMD160WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_RIPEMD160;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA1WITHCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_1;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA224WITHCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_224;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA256WITHCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA384WITHCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_384;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512WITHCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA3-512WITHSPHINCS256"] = BCObjectIdentifiers.sphincs256_with_SHA3_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512WITHSPHINCS256"] = BCObjectIdentifiers.sphincs256_with_SHA512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA256WITHSM2"] = GMObjectIdentifiers.sm2sign_with_sha256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SM3WITHSM2"] = GMObjectIdentifiers.sm2sign_with_sm3;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA256WITHXMSS"] = BCObjectIdentifiers.xmss_with_SHA256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512WITHXMSS"] = BCObjectIdentifiers.xmss_with_SHA512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHAKE128WITHXMSS"] = BCObjectIdentifiers.xmss_with_SHAKE128;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHAKE256WITHXMSS"] = BCObjectIdentifiers.xmss_with_SHAKE256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA256WITHXMSSMT"] = BCObjectIdentifiers.xmss_mt_with_SHA256;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHA512WITHXMSSMT"] = BCObjectIdentifiers.xmss_mt_with_SHA512;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHAKE128WITHXMSSMT"] = BCObjectIdentifiers.xmss_mt_with_SHAKE128;
    DefaultSignatureAlgorithmIdentifierFinder.m_algorithms["SHAKE256WITHXMSSMT"] = BCObjectIdentifiers.xmss_mt_with_SHAKE256;
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(X9ObjectIdentifiers.ECDsaWithSha1);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(X9ObjectIdentifiers.ECDsaWithSha224);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(X9ObjectIdentifiers.ECDsaWithSha256);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(X9ObjectIdentifiers.ECDsaWithSha384);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(X9ObjectIdentifiers.ECDsaWithSha512);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(X9ObjectIdentifiers.IdDsaWithSha1);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.DsaWithSha224);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.DsaWithSha256);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.DsaWithSha384);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.DsaWithSha512);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.IdDsaWithSha3_224);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.IdDsaWithSha3_256);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.IdDsaWithSha3_384);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.IdDsaWithSha3_512);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.IdEcdsaWithSha3_224);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.IdEcdsaWithSha3_256);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.IdEcdsaWithSha3_384);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(NistObjectIdentifiers.IdEcdsaWithSha3_512);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(BCObjectIdentifiers.sphincs256_with_SHA512);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(BCObjectIdentifiers.sphincs256_with_SHA3_512);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(BCObjectIdentifiers.xmss_with_SHA256);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(BCObjectIdentifiers.xmss_with_SHA512);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(BCObjectIdentifiers.xmss_with_SHAKE128);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(BCObjectIdentifiers.xmss_with_SHAKE256);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(BCObjectIdentifiers.xmss_mt_with_SHA256);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(BCObjectIdentifiers.xmss_mt_with_SHA512);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(BCObjectIdentifiers.xmss_mt_with_SHAKE128);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(BCObjectIdentifiers.xmss_mt_with_SHAKE256);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(GMObjectIdentifiers.sm2sign_with_sha256);
    DefaultSignatureAlgorithmIdentifierFinder.noParams.Add(GMObjectIdentifiers.sm2sign_with_sm3);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384);
    DefaultSignatureAlgorithmIdentifierFinder.pkcs15RsaEncryption.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512);
    AlgorithmIdentifier hashAlgId1 = new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1, (Asn1Encodable) DerNull.Instance);
    DefaultSignatureAlgorithmIdentifierFinder.m_params["SHA1WITHRSAANDMGF1"] = (Asn1Encodable) DefaultSignatureAlgorithmIdentifierFinder.CreatePssParams(hashAlgId1, 20);
    AlgorithmIdentifier hashAlgId2 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha224, (Asn1Encodable) DerNull.Instance);
    DefaultSignatureAlgorithmIdentifierFinder.m_params["SHA224WITHRSAANDMGF1"] = (Asn1Encodable) DefaultSignatureAlgorithmIdentifierFinder.CreatePssParams(hashAlgId2, 28);
    AlgorithmIdentifier hashAlgId3 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha256, (Asn1Encodable) DerNull.Instance);
    DefaultSignatureAlgorithmIdentifierFinder.m_params["SHA256WITHRSAANDMGF1"] = (Asn1Encodable) DefaultSignatureAlgorithmIdentifierFinder.CreatePssParams(hashAlgId3, 32 /*0x20*/);
    AlgorithmIdentifier hashAlgId4 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha384, (Asn1Encodable) DerNull.Instance);
    DefaultSignatureAlgorithmIdentifierFinder.m_params["SHA384WITHRSAANDMGF1"] = (Asn1Encodable) DefaultSignatureAlgorithmIdentifierFinder.CreatePssParams(hashAlgId4, 48 /*0x30*/);
    AlgorithmIdentifier hashAlgId5 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha512, (Asn1Encodable) DerNull.Instance);
    DefaultSignatureAlgorithmIdentifierFinder.m_params["SHA512WITHRSAANDMGF1"] = (Asn1Encodable) DefaultSignatureAlgorithmIdentifierFinder.CreatePssParams(hashAlgId5, 64 /*0x40*/);
    AlgorithmIdentifier hashAlgId6 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha3_224, (Asn1Encodable) DerNull.Instance);
    DefaultSignatureAlgorithmIdentifierFinder.m_params["SHA3-224WITHRSAANDMGF1"] = (Asn1Encodable) DefaultSignatureAlgorithmIdentifierFinder.CreatePssParams(hashAlgId6, 28);
    AlgorithmIdentifier hashAlgId7 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha3_256, (Asn1Encodable) DerNull.Instance);
    DefaultSignatureAlgorithmIdentifierFinder.m_params["SHA3-256WITHRSAANDMGF1"] = (Asn1Encodable) DefaultSignatureAlgorithmIdentifierFinder.CreatePssParams(hashAlgId7, 32 /*0x20*/);
    AlgorithmIdentifier hashAlgId8 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha3_384, (Asn1Encodable) DerNull.Instance);
    DefaultSignatureAlgorithmIdentifierFinder.m_params["SHA3-384WITHRSAANDMGF1"] = (Asn1Encodable) DefaultSignatureAlgorithmIdentifierFinder.CreatePssParams(hashAlgId8, 48 /*0x30*/);
    AlgorithmIdentifier hashAlgId9 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha3_512, (Asn1Encodable) DerNull.Instance);
    DefaultSignatureAlgorithmIdentifierFinder.m_params["SHA3-512WITHRSAANDMGF1"] = (Asn1Encodable) DefaultSignatureAlgorithmIdentifierFinder.CreatePssParams(hashAlgId9, 64 /*0x40*/);
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[PkcsObjectIdentifiers.Sha224WithRsaEncryption] = NistObjectIdentifiers.IdSha224;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[PkcsObjectIdentifiers.Sha256WithRsaEncryption] = NistObjectIdentifiers.IdSha256;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[PkcsObjectIdentifiers.Sha384WithRsaEncryption] = NistObjectIdentifiers.IdSha384;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[PkcsObjectIdentifiers.Sha512WithRsaEncryption] = NistObjectIdentifiers.IdSha512;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[PkcsObjectIdentifiers.Sha512_224WithRSAEncryption] = NistObjectIdentifiers.IdSha512_224;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[PkcsObjectIdentifiers.Sha512_256WithRSAEncryption] = NistObjectIdentifiers.IdSha512_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.DsaWithSha224] = NistObjectIdentifiers.IdSha224;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.DsaWithSha256] = NistObjectIdentifiers.IdSha256;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.DsaWithSha384] = NistObjectIdentifiers.IdSha384;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.DsaWithSha512] = NistObjectIdentifiers.IdSha512;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdDsaWithSha3_224] = NistObjectIdentifiers.IdSha3_224;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdDsaWithSha3_256] = NistObjectIdentifiers.IdSha3_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdDsaWithSha3_384] = NistObjectIdentifiers.IdSha3_384;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdDsaWithSha3_512] = NistObjectIdentifiers.IdSha3_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdEcdsaWithSha3_224] = NistObjectIdentifiers.IdSha3_224;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdEcdsaWithSha3_256] = NistObjectIdentifiers.IdSha3_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdEcdsaWithSha3_384] = NistObjectIdentifiers.IdSha3_384;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdEcdsaWithSha3_512] = NistObjectIdentifiers.IdSha3_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224] = NistObjectIdentifiers.IdSha3_224;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256] = NistObjectIdentifiers.IdSha3_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384] = NistObjectIdentifiers.IdSha3_384;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512] = NistObjectIdentifiers.IdSha3_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[PkcsObjectIdentifiers.MD2WithRsaEncryption] = PkcsObjectIdentifiers.MD2;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[PkcsObjectIdentifiers.MD4WithRsaEncryption] = PkcsObjectIdentifiers.MD4;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[PkcsObjectIdentifiers.MD5WithRsaEncryption] = PkcsObjectIdentifiers.MD5;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[PkcsObjectIdentifiers.Sha1WithRsaEncryption] = OiwObjectIdentifiers.IdSha1;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128] = TeleTrusTObjectIdentifiers.RipeMD128;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160] = TeleTrusTObjectIdentifiers.RipeMD160;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256] = TeleTrusTObjectIdentifiers.RipeMD256;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94] = CryptoProObjectIdentifiers.GostR3411;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001] = CryptoProObjectIdentifiers.GostR3411;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256] = RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512] = RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[GMObjectIdentifiers.sm2sign_with_sha256] = NistObjectIdentifiers.IdSha256;
    DefaultSignatureAlgorithmIdentifierFinder.m_digestOids[GMObjectIdentifiers.sm2sign_with_sm3] = GMObjectIdentifiers.sm3;
  }

  private static AlgorithmIdentifier Generate(string signatureAlgorithm)
  {
    DerObjectIdentifier algorithm;
    if (!DefaultSignatureAlgorithmIdentifierFinder.m_algorithms.TryGetValue(signatureAlgorithm, out algorithm))
      throw new ArgumentException("Unknown signature type requested: " + signatureAlgorithm);
    Asn1Encodable parameters;
    return !DefaultSignatureAlgorithmIdentifierFinder.noParams.Contains(algorithm) ? (!DefaultSignatureAlgorithmIdentifierFinder.m_params.TryGetValue(signatureAlgorithm, out parameters) ? new AlgorithmIdentifier(algorithm, (Asn1Encodable) DerNull.Instance) : new AlgorithmIdentifier(algorithm, parameters)) : new AlgorithmIdentifier(algorithm);
  }

  private static RsassaPssParameters CreatePssParams(AlgorithmIdentifier hashAlgId, int saltSize)
  {
    return new RsassaPssParameters(hashAlgId, new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) hashAlgId), new DerInteger(saltSize), new DerInteger(1));
  }

  public AlgorithmIdentifier Find(string sigAlgName)
  {
    return DefaultSignatureAlgorithmIdentifierFinder.Generate(sigAlgName);
  }
}
