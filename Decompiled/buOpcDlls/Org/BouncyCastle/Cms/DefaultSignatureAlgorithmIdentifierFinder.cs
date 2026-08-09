using System;
using System.Collections.Generic;
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

namespace Org.BouncyCastle.Cms;

public class DefaultSignatureAlgorithmIdentifierFinder
{
	private static readonly IDictionary<string, DerObjectIdentifier> m_algorithms;

	private static readonly HashSet<DerObjectIdentifier> noParams;

	private static readonly IDictionary<string, Asn1Encodable> m_params;

	private static readonly HashSet<DerObjectIdentifier> pkcs15RsaEncryption;

	private static readonly IDictionary<DerObjectIdentifier, DerObjectIdentifier> m_digestOids;

	static DefaultSignatureAlgorithmIdentifierFinder()
	{
		m_algorithms = new Dictionary<string, DerObjectIdentifier>(StringComparer.OrdinalIgnoreCase);
		noParams = new HashSet<DerObjectIdentifier>();
		m_params = new Dictionary<string, Asn1Encodable>(StringComparer.OrdinalIgnoreCase);
		pkcs15RsaEncryption = new HashSet<DerObjectIdentifier>();
		m_digestOids = new Dictionary<DerObjectIdentifier, DerObjectIdentifier>();
		m_algorithms["MD2WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.MD2WithRsaEncryption;
		m_algorithms["MD2WITHRSA"] = PkcsObjectIdentifiers.MD2WithRsaEncryption;
		m_algorithms["MD5WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.MD5WithRsaEncryption;
		m_algorithms["MD5WITHRSA"] = PkcsObjectIdentifiers.MD5WithRsaEncryption;
		m_algorithms["SHA1WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha1WithRsaEncryption;
		m_algorithms["SHA-1WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha1WithRsaEncryption;
		m_algorithms["SHA1WITHRSA"] = PkcsObjectIdentifiers.Sha1WithRsaEncryption;
		m_algorithms["SHA-1WITHRSA"] = PkcsObjectIdentifiers.Sha1WithRsaEncryption;
		m_algorithms["SHA224WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha224WithRsaEncryption;
		m_algorithms["SHA-224WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha224WithRsaEncryption;
		m_algorithms["SHA224WITHRSA"] = PkcsObjectIdentifiers.Sha224WithRsaEncryption;
		m_algorithms["SHA-224WITHRSA"] = PkcsObjectIdentifiers.Sha224WithRsaEncryption;
		m_algorithms["SHA256WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha256WithRsaEncryption;
		m_algorithms["SHA-256WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha256WithRsaEncryption;
		m_algorithms["SHA256WITHRSA"] = PkcsObjectIdentifiers.Sha256WithRsaEncryption;
		m_algorithms["SHA-256WITHRSA"] = PkcsObjectIdentifiers.Sha256WithRsaEncryption;
		m_algorithms["SHA384WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha384WithRsaEncryption;
		m_algorithms["SHA-384WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha384WithRsaEncryption;
		m_algorithms["SHA384WITHRSA"] = PkcsObjectIdentifiers.Sha384WithRsaEncryption;
		m_algorithms["SHA-384WITHRSA"] = PkcsObjectIdentifiers.Sha384WithRsaEncryption;
		m_algorithms["SHA512WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512WithRsaEncryption;
		m_algorithms["SHA-512WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512WithRsaEncryption;
		m_algorithms["SHA512WITHRSA"] = PkcsObjectIdentifiers.Sha512WithRsaEncryption;
		m_algorithms["SHA-512WITHRSA"] = PkcsObjectIdentifiers.Sha512WithRsaEncryption;
		m_algorithms["SHA512(224)WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512_224WithRSAEncryption;
		m_algorithms["SHA-512(224)WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512_224WithRSAEncryption;
		m_algorithms["SHA512(224)WITHRSA"] = PkcsObjectIdentifiers.Sha512_224WithRSAEncryption;
		m_algorithms["SHA-512(224)WITHRSA"] = PkcsObjectIdentifiers.Sha512_224WithRSAEncryption;
		m_algorithms["SHA512(256)WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512_256WithRSAEncryption;
		m_algorithms["SHA-512(256)WITHRSAENCRYPTION"] = PkcsObjectIdentifiers.Sha512_256WithRSAEncryption;
		m_algorithms["SHA512(256)WITHRSA"] = PkcsObjectIdentifiers.Sha512_256WithRSAEncryption;
		m_algorithms["SHA-512(256)WITHRSA"] = PkcsObjectIdentifiers.Sha512_256WithRSAEncryption;
		m_algorithms["SHA1WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
		m_algorithms["SHA224WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
		m_algorithms["SHA256WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
		m_algorithms["SHA384WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
		m_algorithms["SHA512WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
		m_algorithms["SHA3-224WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
		m_algorithms["SHA3-256WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
		m_algorithms["SHA3-384WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
		m_algorithms["SHA3-512WITHRSAANDMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
		m_algorithms["RIPEMD160WITHRSAENCRYPTION"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160;
		m_algorithms["RIPEMD160WITHRSA"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160;
		m_algorithms["RIPEMD128WITHRSAENCRYPTION"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128;
		m_algorithms["RIPEMD128WITHRSA"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128;
		m_algorithms["RIPEMD256WITHRSAENCRYPTION"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256;
		m_algorithms["RIPEMD256WITHRSA"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256;
		m_algorithms["SHA1WITHDSA"] = X9ObjectIdentifiers.IdDsaWithSha1;
		m_algorithms["SHA-1WITHDSA"] = X9ObjectIdentifiers.IdDsaWithSha1;
		m_algorithms["DSAWITHSHA1"] = X9ObjectIdentifiers.IdDsaWithSha1;
		m_algorithms["SHA224WITHDSA"] = NistObjectIdentifiers.DsaWithSha224;
		m_algorithms["SHA256WITHDSA"] = NistObjectIdentifiers.DsaWithSha256;
		m_algorithms["SHA384WITHDSA"] = NistObjectIdentifiers.DsaWithSha384;
		m_algorithms["SHA512WITHDSA"] = NistObjectIdentifiers.DsaWithSha512;
		m_algorithms["SHA3-224WITHDSA"] = NistObjectIdentifiers.IdDsaWithSha3_224;
		m_algorithms["SHA3-256WITHDSA"] = NistObjectIdentifiers.IdDsaWithSha3_256;
		m_algorithms["SHA3-384WITHDSA"] = NistObjectIdentifiers.IdDsaWithSha3_384;
		m_algorithms["SHA3-512WITHDSA"] = NistObjectIdentifiers.IdDsaWithSha3_512;
		m_algorithms["SHA3-224WITHECDSA"] = NistObjectIdentifiers.IdEcdsaWithSha3_224;
		m_algorithms["SHA3-256WITHECDSA"] = NistObjectIdentifiers.IdEcdsaWithSha3_256;
		m_algorithms["SHA3-384WITHECDSA"] = NistObjectIdentifiers.IdEcdsaWithSha3_384;
		m_algorithms["SHA3-512WITHECDSA"] = NistObjectIdentifiers.IdEcdsaWithSha3_512;
		m_algorithms["SHA3-224WITHRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224;
		m_algorithms["SHA3-256WITHRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256;
		m_algorithms["SHA3-384WITHRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384;
		m_algorithms["SHA3-512WITHRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512;
		m_algorithms["SHA3-224WITHRSAENCRYPTION"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224;
		m_algorithms["SHA3-256WITHRSAENCRYPTION"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256;
		m_algorithms["SHA3-384WITHRSAENCRYPTION"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384;
		m_algorithms["SHA3-512WITHRSAENCRYPTION"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512;
		m_algorithms["SHA1WITHECDSA"] = X9ObjectIdentifiers.ECDsaWithSha1;
		m_algorithms["ECDSAWITHSHA1"] = X9ObjectIdentifiers.ECDsaWithSha1;
		m_algorithms["SHA224WITHECDSA"] = X9ObjectIdentifiers.ECDsaWithSha224;
		m_algorithms["SHA256WITHECDSA"] = X9ObjectIdentifiers.ECDsaWithSha256;
		m_algorithms["SHA384WITHECDSA"] = X9ObjectIdentifiers.ECDsaWithSha384;
		m_algorithms["SHA512WITHECDSA"] = X9ObjectIdentifiers.ECDsaWithSha512;
		m_algorithms["GOST3411WITHGOST3410"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94;
		m_algorithms["GOST3411WITHGOST3410-94"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94;
		m_algorithms["GOST3411WITHECGOST3410"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001;
		m_algorithms["GOST3411WITHECGOST3410-2001"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001;
		m_algorithms["GOST3411WITHGOST3410-2001"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001;
		m_algorithms["GOST3411WITHECGOST3410-2012-256"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256;
		m_algorithms["GOST3411WITHECGOST3410-2012-512"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512;
		m_algorithms["GOST3411-2012-256WITHECGOST3410"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256;
		m_algorithms["GOST3411-2012-256WITHECGOST3410-2012-256"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256;
		m_algorithms["GOST3411-2012-512WITHECGOST3410"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512;
		m_algorithms["GOST3411-2012-512WITHECGOST3410-2012-512"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512;
		m_algorithms["SHA1WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA1;
		m_algorithms["SHA224WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA224;
		m_algorithms["SHA256WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA256;
		m_algorithms["SHA384WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA384;
		m_algorithms["SHA512WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA512;
		m_algorithms["RIPEMD160WITHPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_RIPEMD160;
		m_algorithms["SHA1WITHCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_1;
		m_algorithms["SHA224WITHCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_224;
		m_algorithms["SHA256WITHCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_256;
		m_algorithms["SHA384WITHCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_384;
		m_algorithms["SHA512WITHCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_512;
		m_algorithms["SHA3-512WITHSPHINCS256"] = BCObjectIdentifiers.sphincs256_with_SHA3_512;
		m_algorithms["SHA512WITHSPHINCS256"] = BCObjectIdentifiers.sphincs256_with_SHA512;
		m_algorithms["SHA256WITHSM2"] = GMObjectIdentifiers.sm2sign_with_sha256;
		m_algorithms["SM3WITHSM2"] = GMObjectIdentifiers.sm2sign_with_sm3;
		m_algorithms["SHA256WITHXMSS"] = BCObjectIdentifiers.xmss_with_SHA256;
		m_algorithms["SHA512WITHXMSS"] = BCObjectIdentifiers.xmss_with_SHA512;
		m_algorithms["SHAKE128WITHXMSS"] = BCObjectIdentifiers.xmss_with_SHAKE128;
		m_algorithms["SHAKE256WITHXMSS"] = BCObjectIdentifiers.xmss_with_SHAKE256;
		m_algorithms["SHA256WITHXMSSMT"] = BCObjectIdentifiers.xmss_mt_with_SHA256;
		m_algorithms["SHA512WITHXMSSMT"] = BCObjectIdentifiers.xmss_mt_with_SHA512;
		m_algorithms["SHAKE128WITHXMSSMT"] = BCObjectIdentifiers.xmss_mt_with_SHAKE128;
		m_algorithms["SHAKE256WITHXMSSMT"] = BCObjectIdentifiers.xmss_mt_with_SHAKE256;
		noParams.Add(X9ObjectIdentifiers.ECDsaWithSha1);
		noParams.Add(X9ObjectIdentifiers.ECDsaWithSha224);
		noParams.Add(X9ObjectIdentifiers.ECDsaWithSha256);
		noParams.Add(X9ObjectIdentifiers.ECDsaWithSha384);
		noParams.Add(X9ObjectIdentifiers.ECDsaWithSha512);
		noParams.Add(X9ObjectIdentifiers.IdDsaWithSha1);
		noParams.Add(NistObjectIdentifiers.DsaWithSha224);
		noParams.Add(NistObjectIdentifiers.DsaWithSha256);
		noParams.Add(NistObjectIdentifiers.DsaWithSha384);
		noParams.Add(NistObjectIdentifiers.DsaWithSha512);
		noParams.Add(NistObjectIdentifiers.IdDsaWithSha3_224);
		noParams.Add(NistObjectIdentifiers.IdDsaWithSha3_256);
		noParams.Add(NistObjectIdentifiers.IdDsaWithSha3_384);
		noParams.Add(NistObjectIdentifiers.IdDsaWithSha3_512);
		noParams.Add(NistObjectIdentifiers.IdEcdsaWithSha3_224);
		noParams.Add(NistObjectIdentifiers.IdEcdsaWithSha3_256);
		noParams.Add(NistObjectIdentifiers.IdEcdsaWithSha3_384);
		noParams.Add(NistObjectIdentifiers.IdEcdsaWithSha3_512);
		noParams.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
		noParams.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
		noParams.Add(RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256);
		noParams.Add(RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512);
		noParams.Add(BCObjectIdentifiers.sphincs256_with_SHA512);
		noParams.Add(BCObjectIdentifiers.sphincs256_with_SHA3_512);
		noParams.Add(BCObjectIdentifiers.xmss_with_SHA256);
		noParams.Add(BCObjectIdentifiers.xmss_with_SHA512);
		noParams.Add(BCObjectIdentifiers.xmss_with_SHAKE128);
		noParams.Add(BCObjectIdentifiers.xmss_with_SHAKE256);
		noParams.Add(BCObjectIdentifiers.xmss_mt_with_SHA256);
		noParams.Add(BCObjectIdentifiers.xmss_mt_with_SHA512);
		noParams.Add(BCObjectIdentifiers.xmss_mt_with_SHAKE128);
		noParams.Add(BCObjectIdentifiers.xmss_mt_with_SHAKE256);
		noParams.Add(GMObjectIdentifiers.sm2sign_with_sha256);
		noParams.Add(GMObjectIdentifiers.sm2sign_with_sm3);
		pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha1WithRsaEncryption);
		pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha224WithRsaEncryption);
		pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha256WithRsaEncryption);
		pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha384WithRsaEncryption);
		pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha512WithRsaEncryption);
		pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
		pkcs15RsaEncryption.Add(PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
		pkcs15RsaEncryption.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128);
		pkcs15RsaEncryption.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160);
		pkcs15RsaEncryption.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256);
		pkcs15RsaEncryption.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224);
		pkcs15RsaEncryption.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256);
		pkcs15RsaEncryption.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384);
		pkcs15RsaEncryption.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512);
		AlgorithmIdentifier hashAlgId = new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1, DerNull.Instance);
		m_params["SHA1WITHRSAANDMGF1"] = CreatePssParams(hashAlgId, 20);
		AlgorithmIdentifier hashAlgId2 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha224, DerNull.Instance);
		m_params["SHA224WITHRSAANDMGF1"] = CreatePssParams(hashAlgId2, 28);
		AlgorithmIdentifier hashAlgId3 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha256, DerNull.Instance);
		m_params["SHA256WITHRSAANDMGF1"] = CreatePssParams(hashAlgId3, 32);
		AlgorithmIdentifier hashAlgId4 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha384, DerNull.Instance);
		m_params["SHA384WITHRSAANDMGF1"] = CreatePssParams(hashAlgId4, 48);
		AlgorithmIdentifier hashAlgId5 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha512, DerNull.Instance);
		m_params["SHA512WITHRSAANDMGF1"] = CreatePssParams(hashAlgId5, 64);
		AlgorithmIdentifier hashAlgId6 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha3_224, DerNull.Instance);
		m_params["SHA3-224WITHRSAANDMGF1"] = CreatePssParams(hashAlgId6, 28);
		AlgorithmIdentifier hashAlgId7 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha3_256, DerNull.Instance);
		m_params["SHA3-256WITHRSAANDMGF1"] = CreatePssParams(hashAlgId7, 32);
		AlgorithmIdentifier hashAlgId8 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha3_384, DerNull.Instance);
		m_params["SHA3-384WITHRSAANDMGF1"] = CreatePssParams(hashAlgId8, 48);
		AlgorithmIdentifier hashAlgId9 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha3_512, DerNull.Instance);
		m_params["SHA3-512WITHRSAANDMGF1"] = CreatePssParams(hashAlgId9, 64);
		m_digestOids[PkcsObjectIdentifiers.Sha224WithRsaEncryption] = NistObjectIdentifiers.IdSha224;
		m_digestOids[PkcsObjectIdentifiers.Sha256WithRsaEncryption] = NistObjectIdentifiers.IdSha256;
		m_digestOids[PkcsObjectIdentifiers.Sha384WithRsaEncryption] = NistObjectIdentifiers.IdSha384;
		m_digestOids[PkcsObjectIdentifiers.Sha512WithRsaEncryption] = NistObjectIdentifiers.IdSha512;
		m_digestOids[PkcsObjectIdentifiers.Sha512_224WithRSAEncryption] = NistObjectIdentifiers.IdSha512_224;
		m_digestOids[PkcsObjectIdentifiers.Sha512_256WithRSAEncryption] = NistObjectIdentifiers.IdSha512_256;
		m_digestOids[NistObjectIdentifiers.DsaWithSha224] = NistObjectIdentifiers.IdSha224;
		m_digestOids[NistObjectIdentifiers.DsaWithSha256] = NistObjectIdentifiers.IdSha256;
		m_digestOids[NistObjectIdentifiers.DsaWithSha384] = NistObjectIdentifiers.IdSha384;
		m_digestOids[NistObjectIdentifiers.DsaWithSha512] = NistObjectIdentifiers.IdSha512;
		m_digestOids[NistObjectIdentifiers.IdDsaWithSha3_224] = NistObjectIdentifiers.IdSha3_224;
		m_digestOids[NistObjectIdentifiers.IdDsaWithSha3_256] = NistObjectIdentifiers.IdSha3_256;
		m_digestOids[NistObjectIdentifiers.IdDsaWithSha3_384] = NistObjectIdentifiers.IdSha3_384;
		m_digestOids[NistObjectIdentifiers.IdDsaWithSha3_512] = NistObjectIdentifiers.IdSha3_512;
		m_digestOids[NistObjectIdentifiers.IdEcdsaWithSha3_224] = NistObjectIdentifiers.IdSha3_224;
		m_digestOids[NistObjectIdentifiers.IdEcdsaWithSha3_256] = NistObjectIdentifiers.IdSha3_256;
		m_digestOids[NistObjectIdentifiers.IdEcdsaWithSha3_384] = NistObjectIdentifiers.IdSha3_384;
		m_digestOids[NistObjectIdentifiers.IdEcdsaWithSha3_512] = NistObjectIdentifiers.IdSha3_512;
		m_digestOids[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224] = NistObjectIdentifiers.IdSha3_224;
		m_digestOids[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256] = NistObjectIdentifiers.IdSha3_256;
		m_digestOids[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384] = NistObjectIdentifiers.IdSha3_384;
		m_digestOids[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512] = NistObjectIdentifiers.IdSha3_512;
		m_digestOids[PkcsObjectIdentifiers.MD2WithRsaEncryption] = PkcsObjectIdentifiers.MD2;
		m_digestOids[PkcsObjectIdentifiers.MD4WithRsaEncryption] = PkcsObjectIdentifiers.MD4;
		m_digestOids[PkcsObjectIdentifiers.MD5WithRsaEncryption] = PkcsObjectIdentifiers.MD5;
		m_digestOids[PkcsObjectIdentifiers.Sha1WithRsaEncryption] = OiwObjectIdentifiers.IdSha1;
		m_digestOids[TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128] = TeleTrusTObjectIdentifiers.RipeMD128;
		m_digestOids[TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160] = TeleTrusTObjectIdentifiers.RipeMD160;
		m_digestOids[TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256] = TeleTrusTObjectIdentifiers.RipeMD256;
		m_digestOids[CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94] = CryptoProObjectIdentifiers.GostR3411;
		m_digestOids[CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001] = CryptoProObjectIdentifiers.GostR3411;
		m_digestOids[RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256] = RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256;
		m_digestOids[RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512] = RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512;
		m_digestOids[GMObjectIdentifiers.sm2sign_with_sha256] = NistObjectIdentifiers.IdSha256;
		m_digestOids[GMObjectIdentifiers.sm2sign_with_sm3] = GMObjectIdentifiers.sm3;
	}

	private static AlgorithmIdentifier Generate(string signatureAlgorithm)
	{
		if (!m_algorithms.TryGetValue(signatureAlgorithm, out var value))
		{
			throw new ArgumentException("Unknown signature type requested: " + signatureAlgorithm);
		}
		if (noParams.Contains(value))
		{
			return new AlgorithmIdentifier(value);
		}
		if (m_params.TryGetValue(signatureAlgorithm, out var value2))
		{
			return new AlgorithmIdentifier(value, value2);
		}
		return new AlgorithmIdentifier(value, DerNull.Instance);
	}

	private static RsassaPssParameters CreatePssParams(AlgorithmIdentifier hashAlgId, int saltSize)
	{
		return new RsassaPssParameters(hashAlgId, new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, hashAlgId), new DerInteger(saltSize), new DerInteger(1));
	}

	public AlgorithmIdentifier Find(string sigAlgName)
	{
		return Generate(sigAlgName);
	}
}
