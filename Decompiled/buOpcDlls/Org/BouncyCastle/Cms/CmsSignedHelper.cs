using System;
using System.Collections.Generic;
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

namespace Org.BouncyCastle.Cms;

internal class CmsSignedHelper
{
	internal static readonly CmsSignedHelper Instance;

	private static readonly string EncryptionECDsaWithSha1;

	private static readonly string EncryptionECDsaWithSha224;

	private static readonly string EncryptionECDsaWithSha256;

	private static readonly string EncryptionECDsaWithSha384;

	private static readonly string EncryptionECDsaWithSha512;

	private static readonly IDictionary<string, string> m_encryptionAlgs;

	private static readonly IDictionary<string, string> m_digestAlgs;

	private static readonly IDictionary<string, string[]> m_digestAliases;

	private static readonly HashSet<string> m_noParams;

	private static readonly IDictionary<string, string> m_ecAlgorithms;

	private static void AddEntries(DerObjectIdentifier oid, string digest, string encryption)
	{
		string id = oid.Id;
		m_digestAlgs.Add(id, digest);
		m_encryptionAlgs.Add(id, encryption);
	}

	static CmsSignedHelper()
	{
		Instance = new CmsSignedHelper();
		EncryptionECDsaWithSha1 = X9ObjectIdentifiers.ECDsaWithSha1.Id;
		EncryptionECDsaWithSha224 = X9ObjectIdentifiers.ECDsaWithSha224.Id;
		EncryptionECDsaWithSha256 = X9ObjectIdentifiers.ECDsaWithSha256.Id;
		EncryptionECDsaWithSha384 = X9ObjectIdentifiers.ECDsaWithSha384.Id;
		EncryptionECDsaWithSha512 = X9ObjectIdentifiers.ECDsaWithSha512.Id;
		m_encryptionAlgs = new Dictionary<string, string>();
		m_digestAlgs = new Dictionary<string, string>();
		m_digestAliases = new Dictionary<string, string[]>();
		m_noParams = new HashSet<string>();
		m_ecAlgorithms = new Dictionary<string, string>();
		AddEntries(NistObjectIdentifiers.DsaWithSha224, "SHA224", "DSA");
		AddEntries(NistObjectIdentifiers.DsaWithSha256, "SHA256", "DSA");
		AddEntries(NistObjectIdentifiers.DsaWithSha384, "SHA384", "DSA");
		AddEntries(NistObjectIdentifiers.DsaWithSha512, "SHA512", "DSA");
		AddEntries(OiwObjectIdentifiers.DsaWithSha1, "SHA1", "DSA");
		AddEntries(OiwObjectIdentifiers.MD4WithRsa, "MD4", "RSA");
		AddEntries(OiwObjectIdentifiers.MD4WithRsaEncryption, "MD4", "RSA");
		AddEntries(OiwObjectIdentifiers.MD5WithRsa, "MD5", "RSA");
		AddEntries(OiwObjectIdentifiers.Sha1WithRsa, "SHA1", "RSA");
		AddEntries(PkcsObjectIdentifiers.MD2WithRsaEncryption, "MD2", "RSA");
		AddEntries(PkcsObjectIdentifiers.MD4WithRsaEncryption, "MD4", "RSA");
		AddEntries(PkcsObjectIdentifiers.MD5WithRsaEncryption, "MD5", "RSA");
		AddEntries(PkcsObjectIdentifiers.Sha1WithRsaEncryption, "SHA1", "RSA");
		AddEntries(PkcsObjectIdentifiers.Sha224WithRsaEncryption, "SHA224", "RSA");
		AddEntries(PkcsObjectIdentifiers.Sha256WithRsaEncryption, "SHA256", "RSA");
		AddEntries(PkcsObjectIdentifiers.Sha384WithRsaEncryption, "SHA384", "RSA");
		AddEntries(PkcsObjectIdentifiers.Sha512WithRsaEncryption, "SHA512", "RSA");
		AddEntries(PkcsObjectIdentifiers.Sha512_224WithRSAEncryption, "SHA512(224)", "RSA");
		AddEntries(PkcsObjectIdentifiers.Sha512_256WithRSAEncryption, "SHA512(256)", "RSA");
		AddEntries(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224, "SHA3-224", "RSA");
		AddEntries(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256, "SHA3-256", "RSA");
		AddEntries(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384, "SHA3-384", "RSA");
		AddEntries(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512, "SHA3-512", "RSA");
		AddEntries(X9ObjectIdentifiers.ECDsaWithSha1, "SHA1", "ECDSA");
		AddEntries(X9ObjectIdentifiers.ECDsaWithSha224, "SHA224", "ECDSA");
		AddEntries(X9ObjectIdentifiers.ECDsaWithSha256, "SHA256", "ECDSA");
		AddEntries(X9ObjectIdentifiers.ECDsaWithSha384, "SHA384", "ECDSA");
		AddEntries(X9ObjectIdentifiers.ECDsaWithSha512, "SHA512", "ECDSA");
		AddEntries(X9ObjectIdentifiers.IdDsaWithSha1, "SHA1", "DSA");
		AddEntries(EacObjectIdentifiers.id_TA_ECDSA_SHA_1, "SHA1", "ECDSA");
		AddEntries(EacObjectIdentifiers.id_TA_ECDSA_SHA_224, "SHA224", "ECDSA");
		AddEntries(EacObjectIdentifiers.id_TA_ECDSA_SHA_256, "SHA256", "ECDSA");
		AddEntries(EacObjectIdentifiers.id_TA_ECDSA_SHA_384, "SHA384", "ECDSA");
		AddEntries(EacObjectIdentifiers.id_TA_ECDSA_SHA_512, "SHA512", "ECDSA");
		AddEntries(EacObjectIdentifiers.id_TA_RSA_v1_5_SHA_1, "SHA1", "RSA");
		AddEntries(EacObjectIdentifiers.id_TA_RSA_v1_5_SHA_256, "SHA256", "RSA");
		AddEntries(EacObjectIdentifiers.id_TA_RSA_PSS_SHA_1, "SHA1", "RSAandMGF1");
		AddEntries(EacObjectIdentifiers.id_TA_RSA_PSS_SHA_256, "SHA256", "RSAandMGF1");
		AddEntries(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94, "GOST3411", "GOST3410");
		AddEntries(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001, "GOST3411", "ECGOST3410");
		AddEntries(RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256, "GOST3411-2012-256", "ECGOST3410");
		AddEntries(RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512, "GOST3411-2012-512", "ECGOST3410");
		m_encryptionAlgs.Add(X9ObjectIdentifiers.IdDsa.Id, "DSA");
		m_encryptionAlgs.Add(PkcsObjectIdentifiers.RsaEncryption.Id, "RSA");
		m_encryptionAlgs.Add(TeleTrusTObjectIdentifiers.TeleTrusTRsaSignatureAlgorithm.Id, "RSA");
		m_encryptionAlgs.Add(X509ObjectIdentifiers.IdEARsa.Id, "RSA");
		m_encryptionAlgs.Add(CmsSignedGenerator.EncryptionRsaPss, "RSAandMGF1");
		m_encryptionAlgs.Add(CryptoProObjectIdentifiers.GostR3410x94.Id, "GOST3410");
		m_encryptionAlgs.Add(CryptoProObjectIdentifiers.GostR3410x2001.Id, "ECGOST3410");
		m_encryptionAlgs.Add(RosstandartObjectIdentifiers.id_tc26_gost_3410_12_256.Id, "ECGOST3410");
		m_encryptionAlgs.Add(RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512.Id, "ECGOST3410");
		m_encryptionAlgs.Add("1.3.6.1.4.1.5849.1.6.2", "ECGOST3410");
		m_encryptionAlgs.Add("1.3.6.1.4.1.5849.1.1.5", "GOST3410");
		m_digestAlgs.Add(PkcsObjectIdentifiers.MD2.Id, "MD2");
		m_digestAlgs.Add(PkcsObjectIdentifiers.MD4.Id, "MD4");
		m_digestAlgs.Add(PkcsObjectIdentifiers.MD5.Id, "MD5");
		m_digestAlgs.Add(OiwObjectIdentifiers.IdSha1.Id, "SHA1");
		m_digestAlgs.Add(NistObjectIdentifiers.IdSha224.Id, "SHA224");
		m_digestAlgs.Add(NistObjectIdentifiers.IdSha256.Id, "SHA256");
		m_digestAlgs.Add(NistObjectIdentifiers.IdSha384.Id, "SHA384");
		m_digestAlgs.Add(NistObjectIdentifiers.IdSha512.Id, "SHA512");
		m_digestAlgs.Add(NistObjectIdentifiers.IdSha512_224.Id, "SHA512(224)");
		m_digestAlgs.Add(NistObjectIdentifiers.IdSha512_256.Id, "SHA512(256)");
		m_digestAlgs.Add(NistObjectIdentifiers.IdSha3_224.Id, "SHA3-224");
		m_digestAlgs.Add(NistObjectIdentifiers.IdSha3_256.Id, "SHA3-256");
		m_digestAlgs.Add(NistObjectIdentifiers.IdSha3_384.Id, "SHA3-384");
		m_digestAlgs.Add(NistObjectIdentifiers.IdSha3_512.Id, "SHA3-512");
		m_digestAlgs.Add(TeleTrusTObjectIdentifiers.RipeMD128.Id, "RIPEMD128");
		m_digestAlgs.Add(TeleTrusTObjectIdentifiers.RipeMD160.Id, "RIPEMD160");
		m_digestAlgs.Add(TeleTrusTObjectIdentifiers.RipeMD256.Id, "RIPEMD256");
		m_digestAlgs.Add(CryptoProObjectIdentifiers.GostR3411.Id, "GOST3411");
		m_digestAlgs.Add("1.3.6.1.4.1.5849.1.2.1", "GOST3411");
		m_digestAlgs.Add(RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256.Id, "GOST3411-2012-256");
		m_digestAlgs.Add(RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512.Id, "GOST3411-2012-512");
		m_digestAliases.Add("SHA1", new string[1] { "SHA-1" });
		m_digestAliases.Add("SHA224", new string[1] { "SHA-224" });
		m_digestAliases.Add("SHA256", new string[1] { "SHA-256" });
		m_digestAliases.Add("SHA384", new string[1] { "SHA-384" });
		m_digestAliases.Add("SHA512", new string[1] { "SHA-512" });
		m_noParams.Add(CmsSignedGenerator.EncryptionDsa);
		m_noParams.Add(EncryptionECDsaWithSha1);
		m_noParams.Add(EncryptionECDsaWithSha224);
		m_noParams.Add(EncryptionECDsaWithSha256);
		m_noParams.Add(EncryptionECDsaWithSha384);
		m_noParams.Add(EncryptionECDsaWithSha512);
		m_ecAlgorithms.Add(CmsSignedGenerator.DigestSha1, EncryptionECDsaWithSha1);
		m_ecAlgorithms.Add(CmsSignedGenerator.DigestSha224, EncryptionECDsaWithSha224);
		m_ecAlgorithms.Add(CmsSignedGenerator.DigestSha256, EncryptionECDsaWithSha256);
		m_ecAlgorithms.Add(CmsSignedGenerator.DigestSha384, EncryptionECDsaWithSha384);
		m_ecAlgorithms.Add(CmsSignedGenerator.DigestSha512, EncryptionECDsaWithSha512);
	}

	internal string GetDigestAlgName(string digestAlgOid)
	{
		return CollectionUtilities.GetValueOrKey(m_digestAlgs, digestAlgOid);
	}

	internal AlgorithmIdentifier GetEncAlgorithmIdentifier(DerObjectIdentifier encOid, Asn1Encodable sigX509Parameters)
	{
		if (m_noParams.Contains(encOid.Id))
		{
			return new AlgorithmIdentifier(encOid);
		}
		return new AlgorithmIdentifier(encOid, sigX509Parameters);
	}

	internal string[] GetDigestAliases(string algName)
	{
		if (!m_digestAliases.TryGetValue(algName, out var value))
		{
			return new string[0];
		}
		return (string[])value.Clone();
	}

	internal string GetEncryptionAlgName(string encryptionAlgOid)
	{
		return CollectionUtilities.GetValueOrKey(m_encryptionAlgs, encryptionAlgOid);
	}

	internal IDigest GetDigestInstance(string algorithm)
	{
		try
		{
			return DigestUtilities.GetDigest(algorithm);
		}
		catch (SecurityUtilityException)
		{
			string[] digestAliases = GetDigestAliases(algorithm);
			foreach (string algorithm2 in digestAliases)
			{
				try
				{
					return DigestUtilities.GetDigest(algorithm2);
				}
				catch (SecurityUtilityException)
				{
				}
			}
			throw;
		}
	}

	internal ISigner GetSignatureInstance(string algorithm)
	{
		return SignerUtilities.GetSigner(algorithm);
	}

	internal AlgorithmIdentifier FixAlgID(AlgorithmIdentifier algId)
	{
		if (algId.Parameters == null)
		{
			return new AlgorithmIdentifier(algId.Algorithm, DerNull.Instance);
		}
		return algId;
	}

	internal string GetEncOid(AsymmetricKeyParameter key, string digestOID)
	{
		string value = null;
		if (key is RsaKeyParameters rsaKeyParameters)
		{
			if (!rsaKeyParameters.IsPrivate)
			{
				throw new ArgumentException("Expected RSA private key");
			}
			value = CmsSignedGenerator.EncryptionRsa;
		}
		else if (key is DsaPrivateKeyParameters)
		{
			if (digestOID.Equals(CmsSignedGenerator.DigestSha1))
			{
				value = CmsSignedGenerator.EncryptionDsa;
			}
			else if (digestOID.Equals(CmsSignedGenerator.DigestSha224))
			{
				value = NistObjectIdentifiers.DsaWithSha224.Id;
			}
			else if (digestOID.Equals(CmsSignedGenerator.DigestSha256))
			{
				value = NistObjectIdentifiers.DsaWithSha256.Id;
			}
			else if (digestOID.Equals(CmsSignedGenerator.DigestSha384))
			{
				value = NistObjectIdentifiers.DsaWithSha384.Id;
			}
			else
			{
				if (!digestOID.Equals(CmsSignedGenerator.DigestSha512))
				{
					throw new ArgumentException("can't mix DSA with anything but SHA1/SHA2");
				}
				value = NistObjectIdentifiers.DsaWithSha512.Id;
			}
		}
		else if (key is ECPrivateKeyParameters eCPrivateKeyParameters)
		{
			if (eCPrivateKeyParameters.AlgorithmName == "ECGOST3410")
			{
				value = CmsSignedGenerator.EncryptionECGost3410;
			}
			else if (eCPrivateKeyParameters.Parameters is ECGost3410Parameters { DigestParamSet: var digestParamSet })
			{
				if (digestParamSet.Equals(RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256))
				{
					value = CmsSignedGenerator.EncryptionECGost3410_2012_256;
				}
				else
				{
					if (!digestParamSet.Equals(RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512))
					{
						throw new ArgumentException("can't determine GOST3410 algorithm");
					}
					value = CmsSignedGenerator.EncryptionECGost3410_2012_512;
				}
			}
			else if (!m_ecAlgorithms.TryGetValue(digestOID, out value))
			{
				throw new ArgumentException("can't mix ECDSA with anything but SHA family digests");
			}
		}
		else
		{
			if (!(key is Gost3410PrivateKeyParameters))
			{
				throw new ArgumentException("Unknown algorithm in CmsSignedGenerator.GetEncOid");
			}
			value = CmsSignedGenerator.EncryptionGost3410;
		}
		return value;
	}

	internal IStore<X509V2AttributeCertificate> GetAttributeCertificates(Asn1Set attrCertSet)
	{
		List<X509V2AttributeCertificate> list = new List<X509V2AttributeCertificate>();
		if (attrCertSet != null)
		{
			foreach (Asn1Encodable item in attrCertSet)
			{
				if (item != null && item.ToAsn1Object() is Asn1TaggedObject asn1TaggedObject && asn1TaggedObject.HasContextTag(2))
				{
					Asn1Sequence instance = Asn1Sequence.GetInstance(asn1TaggedObject, declaredExplicit: false);
					list.Add(new X509V2AttributeCertificate(AttributeCertificate.GetInstance(instance)));
				}
			}
		}
		return CollectionUtilities.CreateStore(list);
	}

	internal IStore<X509Certificate> GetCertificates(Asn1Set certSet)
	{
		List<X509Certificate> list = new List<X509Certificate>();
		if (certSet != null)
		{
			foreach (Asn1Encodable item in certSet)
			{
				if (item != null)
				{
					if (item is X509CertificateStructure c)
					{
						list.Add(new X509Certificate(c));
					}
					else if (item.ToAsn1Object() is Asn1Sequence obj)
					{
						list.Add(new X509Certificate(X509CertificateStructure.GetInstance(obj)));
					}
				}
			}
		}
		return CollectionUtilities.CreateStore(list);
	}

	internal IStore<X509Crl> GetCrls(Asn1Set crlSet)
	{
		List<X509Crl> list = new List<X509Crl>();
		if (crlSet != null)
		{
			foreach (Asn1Encodable item in crlSet)
			{
				if (item != null)
				{
					if (item is CertificateList c)
					{
						list.Add(new X509Crl(c));
					}
					else if (item.ToAsn1Object() is Asn1Sequence obj)
					{
						list.Add(new X509Crl(CertificateList.GetInstance(obj)));
					}
				}
			}
		}
		return CollectionUtilities.CreateStore(list);
	}

	internal IStore<Asn1Encodable> GetOtherRevInfos(Asn1Set crlSet, DerObjectIdentifier otherRevInfoFormat)
	{
		List<Asn1Encodable> list = new List<Asn1Encodable>();
		if (crlSet != null && otherRevInfoFormat != null)
		{
			foreach (Asn1Encodable item in crlSet)
			{
				if (item != null && item.ToAsn1Object() is Asn1TaggedObject asn1TaggedObject && asn1TaggedObject.HasContextTag(1))
				{
					OtherRevocationInfoFormat instance = OtherRevocationInfoFormat.GetInstance(asn1TaggedObject, isExplicit: false);
					if (otherRevInfoFormat.Equals(instance.InfoFormat))
					{
						list.Add(instance.Info);
					}
				}
			}
		}
		return CollectionUtilities.CreateStore(list);
	}
}
