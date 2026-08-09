using System;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.Kisa;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Nsri;
using Org.BouncyCastle.Asn1.Ntt;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;

namespace Org.BouncyCastle.Security;

public static class CipherUtilities
{
	private enum CipherAlgorithm
	{
		AES,
		ARC4,
		ARIA,
		BLOWFISH,
		CAMELLIA,
		CAST5,
		CAST6,
		CHACHA,
		CHACHA20_POLY1305,
		CHACHA7539,
		DES,
		DESEDE,
		ELGAMAL,
		GOST28147,
		HC128,
		HC256,
		IDEA,
		NOEKEON,
		PBEWITHSHAAND128BITRC4,
		PBEWITHSHAAND40BITRC4,
		RC2,
		RC5,
		RC5_64,
		RC6,
		RIJNDAEL,
		RSA,
		SALSA20,
		SEED,
		SERPENT,
		SKIPJACK,
		SM4,
		TEA,
		THREEFISH_256,
		THREEFISH_512,
		THREEFISH_1024,
		TNEPRES,
		TWOFISH,
		VMPC,
		VMPC_KSA3,
		XTEA
	}

	private enum CipherMode
	{
		ECB,
		NONE,
		CBC,
		CCM,
		CFB,
		CTR,
		CTS,
		EAX,
		GCM,
		GOFB,
		OCB,
		OFB,
		OPENPGPCFB,
		SIC
	}

	private enum CipherPadding
	{
		NOPADDING,
		RAW,
		ISO10126PADDING,
		ISO10126D2PADDING,
		ISO10126_2PADDING,
		ISO7816_4PADDING,
		ISO9797_1PADDING,
		ISO9796_1,
		ISO9796_1PADDING,
		OAEP,
		OAEPPADDING,
		OAEPWITHMD5ANDMGF1PADDING,
		OAEPWITHSHA1ANDMGF1PADDING,
		OAEPWITHSHA_1ANDMGF1PADDING,
		OAEPWITHSHA224ANDMGF1PADDING,
		OAEPWITHSHA_224ANDMGF1PADDING,
		OAEPWITHSHA256ANDMGF1PADDING,
		OAEPWITHSHA_256ANDMGF1PADDING,
		OAEPWITHSHA256ANDMGF1WITHSHA256PADDING,
		OAEPWITHSHA_256ANDMGF1WITHSHA_256PADDING,
		OAEPWITHSHA256ANDMGF1WITHSHA1PADDING,
		OAEPWITHSHA_256ANDMGF1WITHSHA_1PADDING,
		OAEPWITHSHA384ANDMGF1PADDING,
		OAEPWITHSHA_384ANDMGF1PADDING,
		OAEPWITHSHA512ANDMGF1PADDING,
		OAEPWITHSHA_512ANDMGF1PADDING,
		PKCS1,
		PKCS1PADDING,
		PKCS5,
		PKCS5PADDING,
		PKCS7,
		PKCS7PADDING,
		TBCPADDING,
		WITHCTS,
		X923PADDING,
		ZEROBYTEPADDING
	}

	private static readonly Dictionary<string, string> Algorithms;

	static CipherUtilities()
	{
		Algorithms = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		Enums.GetArbitraryValue<CipherAlgorithm>().ToString();
		Enums.GetArbitraryValue<CipherMode>().ToString();
		Enums.GetArbitraryValue<CipherPadding>().ToString();
		Algorithms[NistObjectIdentifiers.IdAes128Cbc.Id] = "AES/CBC/PKCS7PADDING";
		Algorithms[NistObjectIdentifiers.IdAes192Cbc.Id] = "AES/CBC/PKCS7PADDING";
		Algorithms[NistObjectIdentifiers.IdAes256Cbc.Id] = "AES/CBC/PKCS7PADDING";
		Algorithms[NistObjectIdentifiers.IdAes128Ccm.Id] = "AES/CCM/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes192Ccm.Id] = "AES/CCM/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes256Ccm.Id] = "AES/CCM/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes128Cfb.Id] = "AES/CFB/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes192Cfb.Id] = "AES/CFB/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes256Cfb.Id] = "AES/CFB/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes128Ecb.Id] = "AES/ECB/PKCS7PADDING";
		Algorithms[NistObjectIdentifiers.IdAes192Ecb.Id] = "AES/ECB/PKCS7PADDING";
		Algorithms[NistObjectIdentifiers.IdAes256Ecb.Id] = "AES/ECB/PKCS7PADDING";
		Algorithms["AES//PKCS7"] = "AES/ECB/PKCS7PADDING";
		Algorithms["AES//PKCS7PADDING"] = "AES/ECB/PKCS7PADDING";
		Algorithms["AES//PKCS5"] = "AES/ECB/PKCS7PADDING";
		Algorithms["AES//PKCS5PADDING"] = "AES/ECB/PKCS7PADDING";
		Algorithms[NistObjectIdentifiers.IdAes128Gcm.Id] = "AES/GCM/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes192Gcm.Id] = "AES/GCM/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes256Gcm.Id] = "AES/GCM/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes128Ofb.Id] = "AES/OFB/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes192Ofb.Id] = "AES/OFB/NOPADDING";
		Algorithms[NistObjectIdentifiers.IdAes256Ofb.Id] = "AES/OFB/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria128_cbc.Id] = "ARIA/CBC/PKCS7PADDING";
		Algorithms[NsriObjectIdentifiers.id_aria192_cbc.Id] = "ARIA/CBC/PKCS7PADDING";
		Algorithms[NsriObjectIdentifiers.id_aria256_cbc.Id] = "ARIA/CBC/PKCS7PADDING";
		Algorithms[NsriObjectIdentifiers.id_aria128_ccm.Id] = "ARIA/CCM/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria192_ccm.Id] = "ARIA/CCM/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria256_ccm.Id] = "ARIA/CCM/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria128_cfb.Id] = "ARIA/CFB/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria192_cfb.Id] = "ARIA/CFB/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria256_cfb.Id] = "ARIA/CFB/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria128_ctr.Id] = "ARIA/CTR/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria192_ctr.Id] = "ARIA/CTR/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria256_ctr.Id] = "ARIA/CTR/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria128_ecb.Id] = "ARIA/ECB/PKCS7PADDING";
		Algorithms[NsriObjectIdentifiers.id_aria192_ecb.Id] = "ARIA/ECB/PKCS7PADDING";
		Algorithms[NsriObjectIdentifiers.id_aria256_ecb.Id] = "ARIA/ECB/PKCS7PADDING";
		Algorithms["ARIA//PKCS7"] = "ARIA/ECB/PKCS7PADDING";
		Algorithms["ARIA//PKCS7PADDING"] = "ARIA/ECB/PKCS7PADDING";
		Algorithms["ARIA//PKCS5"] = "ARIA/ECB/PKCS7PADDING";
		Algorithms["ARIA//PKCS5PADDING"] = "ARIA/ECB/PKCS7PADDING";
		Algorithms[NsriObjectIdentifiers.id_aria128_gcm.Id] = "ARIA/GCM/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria192_gcm.Id] = "ARIA/GCM/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria256_gcm.Id] = "ARIA/GCM/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria128_ofb.Id] = "ARIA/OFB/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria192_ofb.Id] = "ARIA/OFB/NOPADDING";
		Algorithms[NsriObjectIdentifiers.id_aria256_ofb.Id] = "ARIA/OFB/NOPADDING";
		Algorithms["RSA/ECB/PKCS1"] = "RSA//PKCS1PADDING";
		Algorithms["RSA/ECB/PKCS1PADDING"] = "RSA//PKCS1PADDING";
		Algorithms[PkcsObjectIdentifiers.RsaEncryption.Id] = "RSA//PKCS1PADDING";
		Algorithms[PkcsObjectIdentifiers.IdRsaesOaep.Id] = "RSA//OAEPPADDING";
		Algorithms[OiwObjectIdentifiers.DesCbc.Id] = "DES/CBC";
		Algorithms[OiwObjectIdentifiers.DesCfb.Id] = "DES/CFB";
		Algorithms[OiwObjectIdentifiers.DesEcb.Id] = "DES/ECB";
		Algorithms[OiwObjectIdentifiers.DesOfb.Id] = "DES/OFB";
		Algorithms[OiwObjectIdentifiers.DesEde.Id] = "DESEDE";
		Algorithms["TDEA"] = "DESEDE";
		Algorithms[PkcsObjectIdentifiers.DesEde3Cbc.Id] = "DESEDE/CBC";
		Algorithms[PkcsObjectIdentifiers.RC2Cbc.Id] = "RC2/CBC";
		Algorithms["1.3.6.1.4.1.188.7.1.1.2"] = "IDEA/CBC";
		Algorithms["1.2.840.113533.7.66.10"] = "CAST5/CBC";
		Algorithms["RC4"] = "ARC4";
		Algorithms["ARCFOUR"] = "ARC4";
		Algorithms["1.2.840.113549.3.4"] = "ARC4";
		Algorithms["PBEWITHSHA1AND128BITRC4"] = "PBEWITHSHAAND128BITRC4";
		Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd128BitRC4.Id] = "PBEWITHSHAAND128BITRC4";
		Algorithms["PBEWITHSHA1AND40BITRC4"] = "PBEWITHSHAAND40BITRC4";
		Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd40BitRC4.Id] = "PBEWITHSHAAND40BITRC4";
		Algorithms["PBEWITHSHA1ANDDES"] = "PBEWITHSHA1ANDDES-CBC";
		Algorithms[PkcsObjectIdentifiers.PbeWithSha1AndDesCbc.Id] = "PBEWITHSHA1ANDDES-CBC";
		Algorithms["PBEWITHSHA1ANDRC2"] = "PBEWITHSHA1ANDRC2-CBC";
		Algorithms[PkcsObjectIdentifiers.PbeWithSha1AndRC2Cbc.Id] = "PBEWITHSHA1ANDRC2-CBC";
		Algorithms["PBEWITHSHA1AND3-KEYTRIPLEDES-CBC"] = "PBEWITHSHAAND3-KEYTRIPLEDES-CBC";
		Algorithms["PBEWITHSHAAND3KEYTRIPLEDES"] = "PBEWITHSHAAND3-KEYTRIPLEDES-CBC";
		Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd3KeyTripleDesCbc.Id] = "PBEWITHSHAAND3-KEYTRIPLEDES-CBC";
		Algorithms["PBEWITHSHA1ANDDESEDE"] = "PBEWITHSHAAND3-KEYTRIPLEDES-CBC";
		Algorithms["PBEWITHSHA1AND2-KEYTRIPLEDES-CBC"] = "PBEWITHSHAAND2-KEYTRIPLEDES-CBC";
		Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd2KeyTripleDesCbc.Id] = "PBEWITHSHAAND2-KEYTRIPLEDES-CBC";
		Algorithms["PBEWITHSHA1AND128BITRC2-CBC"] = "PBEWITHSHAAND128BITRC2-CBC";
		Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd128BitRC2Cbc.Id] = "PBEWITHSHAAND128BITRC2-CBC";
		Algorithms["PBEWITHSHA1AND40BITRC2-CBC"] = "PBEWITHSHAAND40BITRC2-CBC";
		Algorithms[PkcsObjectIdentifiers.PbewithShaAnd40BitRC2Cbc.Id] = "PBEWITHSHAAND40BITRC2-CBC";
		Algorithms["PBEWITHSHA1AND128BITAES-CBC-BC"] = "PBEWITHSHAAND128BITAES-CBC-BC";
		Algorithms["PBEWITHSHA-1AND128BITAES-CBC-BC"] = "PBEWITHSHAAND128BITAES-CBC-BC";
		Algorithms["PBEWITHSHA1AND192BITAES-CBC-BC"] = "PBEWITHSHAAND192BITAES-CBC-BC";
		Algorithms["PBEWITHSHA-1AND192BITAES-CBC-BC"] = "PBEWITHSHAAND192BITAES-CBC-BC";
		Algorithms["PBEWITHSHA1AND256BITAES-CBC-BC"] = "PBEWITHSHAAND256BITAES-CBC-BC";
		Algorithms["PBEWITHSHA-1AND256BITAES-CBC-BC"] = "PBEWITHSHAAND256BITAES-CBC-BC";
		Algorithms["PBEWITHSHA-256AND128BITAES-CBC-BC"] = "PBEWITHSHA256AND128BITAES-CBC-BC";
		Algorithms["PBEWITHSHA-256AND192BITAES-CBC-BC"] = "PBEWITHSHA256AND192BITAES-CBC-BC";
		Algorithms["PBEWITHSHA-256AND256BITAES-CBC-BC"] = "PBEWITHSHA256AND256BITAES-CBC-BC";
		Algorithms["GOST"] = "GOST28147";
		Algorithms["GOST-28147"] = "GOST28147";
		Algorithms[CryptoProObjectIdentifiers.GostR28147Gcfb.Id] = "GOST28147/CBC/PKCS7PADDING";
		Algorithms["RC5-32"] = "RC5";
		Algorithms[NttObjectIdentifiers.IdCamellia128Cbc.Id] = "CAMELLIA/CBC/PKCS7PADDING";
		Algorithms[NttObjectIdentifiers.IdCamellia192Cbc.Id] = "CAMELLIA/CBC/PKCS7PADDING";
		Algorithms[NttObjectIdentifiers.IdCamellia256Cbc.Id] = "CAMELLIA/CBC/PKCS7PADDING";
		Algorithms[KisaObjectIdentifiers.IdSeedCbc.Id] = "SEED/CBC/PKCS7PADDING";
		Algorithms["1.3.6.1.4.1.3029.1.2"] = "BLOWFISH/CBC";
		Algorithms["CHACHA20"] = "CHACHA7539";
		Algorithms[PkcsObjectIdentifiers.IdAlgAeadChaCha20Poly1305.Id] = "CHACHA20-POLY1305";
	}

	public static IBufferedCipher GetCipher(DerObjectIdentifier oid)
	{
		return GetCipher(oid.Id);
	}

	public static IBufferedCipher GetCipher(string algorithm)
	{
		if (algorithm == null)
		{
			throw new ArgumentNullException("algorithm");
		}
		algorithm = CollectionUtilities.GetValueOrKey(Algorithms, algorithm).ToUpperInvariant();
		IBasicAgreement basicAgreement = null;
		if (algorithm == "IES")
		{
			basicAgreement = new DHBasicAgreement();
		}
		else if (algorithm == "ECIES")
		{
			basicAgreement = new ECDHBasicAgreement();
		}
		if (basicAgreement != null)
		{
			return new BufferedIesCipher(new IesEngine(basicAgreement, new Kdf2BytesGenerator(new Sha1Digest()), new HMac(new Sha1Digest())));
		}
		if (Platform.StartsWith(algorithm, "PBE"))
		{
			if (Platform.EndsWith(algorithm, "-CBC"))
			{
				if (algorithm == "PBEWITHSHA1ANDDES-CBC")
				{
					return new PaddedBufferedBlockCipher(new CbcBlockCipher(new DesEngine()));
				}
				if (algorithm == "PBEWITHSHA1ANDRC2-CBC")
				{
					return new PaddedBufferedBlockCipher(new CbcBlockCipher(new RC2Engine()));
				}
				if (Strings.IsOneOf(algorithm, "PBEWITHSHAAND2-KEYTRIPLEDES-CBC", "PBEWITHSHAAND3-KEYTRIPLEDES-CBC"))
				{
					return new PaddedBufferedBlockCipher(new CbcBlockCipher(new DesEdeEngine()));
				}
				if (Strings.IsOneOf(algorithm, "PBEWITHSHAAND128BITRC2-CBC", "PBEWITHSHAAND40BITRC2-CBC"))
				{
					return new PaddedBufferedBlockCipher(new CbcBlockCipher(new RC2Engine()));
				}
			}
			else if ((Platform.EndsWith(algorithm, "-BC") || Platform.EndsWith(algorithm, "-OPENSSL")) && Strings.IsOneOf(algorithm, "PBEWITHSHAAND128BITAES-CBC-BC", "PBEWITHSHAAND192BITAES-CBC-BC", "PBEWITHSHAAND256BITAES-CBC-BC", "PBEWITHSHA256AND128BITAES-CBC-BC", "PBEWITHSHA256AND192BITAES-CBC-BC", "PBEWITHSHA256AND256BITAES-CBC-BC", "PBEWITHMD5AND128BITAES-CBC-OPENSSL", "PBEWITHMD5AND192BITAES-CBC-OPENSSL", "PBEWITHMD5AND256BITAES-CBC-OPENSSL"))
			{
				return new PaddedBufferedBlockCipher(new CbcBlockCipher(AesUtilities.CreateEngine()));
			}
		}
		string[] array = algorithm.Split('/');
		IAeadCipher aeadCipher = null;
		IBlockCipher blockCipher = null;
		IAsymmetricBlockCipher asymmetricBlockCipher = null;
		IStreamCipher streamCipher = null;
		string s = CollectionUtilities.GetValueOrKey(Algorithms, array[0]).ToUpperInvariant();
		CipherAlgorithm enumValue;
		try
		{
			enumValue = Enums.GetEnumValue<CipherAlgorithm>(s);
		}
		catch (ArgumentException)
		{
			throw new SecurityUtilityException("Cipher " + algorithm + " not recognised.");
		}
		switch (enumValue)
		{
		case CipherAlgorithm.AES:
			blockCipher = AesUtilities.CreateEngine();
			break;
		case CipherAlgorithm.ARC4:
			streamCipher = new RC4Engine();
			break;
		case CipherAlgorithm.ARIA:
			blockCipher = new AriaEngine();
			break;
		case CipherAlgorithm.BLOWFISH:
			blockCipher = new BlowfishEngine();
			break;
		case CipherAlgorithm.CAMELLIA:
			blockCipher = new CamelliaEngine();
			break;
		case CipherAlgorithm.CAST5:
			blockCipher = new Cast5Engine();
			break;
		case CipherAlgorithm.CAST6:
			blockCipher = new Cast6Engine();
			break;
		case CipherAlgorithm.CHACHA:
			streamCipher = new ChaChaEngine();
			break;
		case CipherAlgorithm.CHACHA20_POLY1305:
			aeadCipher = new ChaCha20Poly1305();
			break;
		case CipherAlgorithm.CHACHA7539:
			streamCipher = new ChaCha7539Engine();
			break;
		case CipherAlgorithm.DES:
			blockCipher = new DesEngine();
			break;
		case CipherAlgorithm.DESEDE:
			blockCipher = new DesEdeEngine();
			break;
		case CipherAlgorithm.ELGAMAL:
			asymmetricBlockCipher = new ElGamalEngine();
			break;
		case CipherAlgorithm.GOST28147:
			blockCipher = new Gost28147Engine();
			break;
		case CipherAlgorithm.HC128:
			streamCipher = new HC128Engine();
			break;
		case CipherAlgorithm.HC256:
			streamCipher = new HC256Engine();
			break;
		case CipherAlgorithm.IDEA:
			blockCipher = new IdeaEngine();
			break;
		case CipherAlgorithm.NOEKEON:
			blockCipher = new NoekeonEngine();
			break;
		case CipherAlgorithm.PBEWITHSHAAND128BITRC4:
		case CipherAlgorithm.PBEWITHSHAAND40BITRC4:
			streamCipher = new RC4Engine();
			break;
		case CipherAlgorithm.RC2:
			blockCipher = new RC2Engine();
			break;
		case CipherAlgorithm.RC5:
			blockCipher = new RC532Engine();
			break;
		case CipherAlgorithm.RC5_64:
			blockCipher = new RC564Engine();
			break;
		case CipherAlgorithm.RC6:
			blockCipher = new RC6Engine();
			break;
		case CipherAlgorithm.RIJNDAEL:
			blockCipher = new RijndaelEngine();
			break;
		case CipherAlgorithm.RSA:
			asymmetricBlockCipher = new RsaBlindedEngine();
			break;
		case CipherAlgorithm.SALSA20:
			streamCipher = new Salsa20Engine();
			break;
		case CipherAlgorithm.SEED:
			blockCipher = new SeedEngine();
			break;
		case CipherAlgorithm.SERPENT:
			blockCipher = new SerpentEngine();
			break;
		case CipherAlgorithm.SKIPJACK:
			blockCipher = new SkipjackEngine();
			break;
		case CipherAlgorithm.SM4:
			blockCipher = new SM4Engine();
			break;
		case CipherAlgorithm.TEA:
			blockCipher = new TeaEngine();
			break;
		case CipherAlgorithm.THREEFISH_256:
			blockCipher = new ThreefishEngine(256);
			break;
		case CipherAlgorithm.THREEFISH_512:
			blockCipher = new ThreefishEngine(512);
			break;
		case CipherAlgorithm.THREEFISH_1024:
			blockCipher = new ThreefishEngine(1024);
			break;
		case CipherAlgorithm.TNEPRES:
			blockCipher = new TnepresEngine();
			break;
		case CipherAlgorithm.TWOFISH:
			blockCipher = new TwofishEngine();
			break;
		case CipherAlgorithm.VMPC:
			streamCipher = new VmpcEngine();
			break;
		case CipherAlgorithm.VMPC_KSA3:
			streamCipher = new VmpcKsa3Engine();
			break;
		case CipherAlgorithm.XTEA:
			blockCipher = new XteaEngine();
			break;
		default:
			throw new SecurityUtilityException("Cipher " + algorithm + " not recognised.");
		}
		if (aeadCipher != null)
		{
			if (array.Length > 1)
			{
				throw new ArgumentException("Modes and paddings cannot be applied to AEAD ciphers");
			}
			return new BufferedAeadCipher(aeadCipher);
		}
		if (streamCipher != null)
		{
			if (array.Length > 1)
			{
				throw new ArgumentException("Modes and paddings not used for stream ciphers");
			}
			return new BufferedStreamCipher(streamCipher);
		}
		bool flag = false;
		bool flag2 = true;
		IBlockCipherPadding blockCipherPadding = null;
		IAeadBlockCipher aeadBlockCipher = null;
		if (array.Length > 2)
		{
			if (streamCipher != null)
			{
				throw new ArgumentException("Paddings not used for stream ciphers");
			}
			string text = array[2];
			CipherPadding cipherPadding;
			if (text == "")
			{
				cipherPadding = CipherPadding.RAW;
			}
			else if (text == "X9.23PADDING")
			{
				cipherPadding = CipherPadding.X923PADDING;
			}
			else
			{
				try
				{
					cipherPadding = Enums.GetEnumValue<CipherPadding>(text);
				}
				catch (ArgumentException)
				{
					throw new SecurityUtilityException("Cipher " + algorithm + " not recognised.");
				}
			}
			switch (cipherPadding)
			{
			case CipherPadding.NOPADDING:
				flag2 = false;
				break;
			case CipherPadding.ISO10126PADDING:
			case CipherPadding.ISO10126D2PADDING:
			case CipherPadding.ISO10126_2PADDING:
				blockCipherPadding = new ISO10126d2Padding();
				break;
			case CipherPadding.ISO7816_4PADDING:
			case CipherPadding.ISO9797_1PADDING:
				blockCipherPadding = new ISO7816d4Padding();
				break;
			case CipherPadding.ISO9796_1:
			case CipherPadding.ISO9796_1PADDING:
				asymmetricBlockCipher = new ISO9796d1Encoding(asymmetricBlockCipher);
				break;
			case CipherPadding.OAEP:
			case CipherPadding.OAEPPADDING:
				asymmetricBlockCipher = new OaepEncoding(asymmetricBlockCipher);
				break;
			case CipherPadding.OAEPWITHMD5ANDMGF1PADDING:
				asymmetricBlockCipher = new OaepEncoding(asymmetricBlockCipher, new MD5Digest());
				break;
			case CipherPadding.OAEPWITHSHA1ANDMGF1PADDING:
			case CipherPadding.OAEPWITHSHA_1ANDMGF1PADDING:
				asymmetricBlockCipher = new OaepEncoding(asymmetricBlockCipher, new Sha1Digest());
				break;
			case CipherPadding.OAEPWITHSHA224ANDMGF1PADDING:
			case CipherPadding.OAEPWITHSHA_224ANDMGF1PADDING:
				asymmetricBlockCipher = new OaepEncoding(asymmetricBlockCipher, new Sha224Digest());
				break;
			case CipherPadding.OAEPWITHSHA256ANDMGF1PADDING:
			case CipherPadding.OAEPWITHSHA_256ANDMGF1PADDING:
			case CipherPadding.OAEPWITHSHA256ANDMGF1WITHSHA256PADDING:
			case CipherPadding.OAEPWITHSHA_256ANDMGF1WITHSHA_256PADDING:
				asymmetricBlockCipher = new OaepEncoding(asymmetricBlockCipher, new Sha256Digest());
				break;
			case CipherPadding.OAEPWITHSHA256ANDMGF1WITHSHA1PADDING:
			case CipherPadding.OAEPWITHSHA_256ANDMGF1WITHSHA_1PADDING:
				asymmetricBlockCipher = new OaepEncoding(asymmetricBlockCipher, new Sha256Digest(), new Sha1Digest(), null);
				break;
			case CipherPadding.OAEPWITHSHA384ANDMGF1PADDING:
			case CipherPadding.OAEPWITHSHA_384ANDMGF1PADDING:
				asymmetricBlockCipher = new OaepEncoding(asymmetricBlockCipher, new Sha384Digest());
				break;
			case CipherPadding.OAEPWITHSHA512ANDMGF1PADDING:
			case CipherPadding.OAEPWITHSHA_512ANDMGF1PADDING:
				asymmetricBlockCipher = new OaepEncoding(asymmetricBlockCipher, new Sha512Digest());
				break;
			case CipherPadding.PKCS1:
			case CipherPadding.PKCS1PADDING:
				asymmetricBlockCipher = new Pkcs1Encoding(asymmetricBlockCipher);
				break;
			case CipherPadding.PKCS5:
			case CipherPadding.PKCS5PADDING:
			case CipherPadding.PKCS7:
			case CipherPadding.PKCS7PADDING:
				blockCipherPadding = new Pkcs7Padding();
				break;
			case CipherPadding.TBCPADDING:
				blockCipherPadding = new TbcPadding();
				break;
			case CipherPadding.WITHCTS:
				flag = true;
				break;
			case CipherPadding.X923PADDING:
				blockCipherPadding = new X923Padding();
				break;
			case CipherPadding.ZEROBYTEPADDING:
				blockCipherPadding = new ZeroBytePadding();
				break;
			default:
				throw new SecurityUtilityException("Cipher " + algorithm + " not recognised.");
			case CipherPadding.RAW:
				break;
			}
		}
		string text2 = "";
		IBlockCipherMode blockCipherMode = null;
		if (array.Length > 1)
		{
			text2 = array[1];
			int digitIndex = GetDigitIndex(text2);
			string text3 = ((digitIndex >= 0) ? text2.Substring(0, digitIndex) : text2);
			try
			{
				switch ((text3 == "") ? CipherMode.NONE : Enums.GetEnumValue<CipherMode>(text3))
				{
				case CipherMode.CBC:
					blockCipherMode = new CbcBlockCipher(blockCipher);
					break;
				case CipherMode.CCM:
					aeadBlockCipher = new CcmBlockCipher(blockCipher);
					break;
				case CipherMode.CFB:
				{
					int bitBlockSize = ((digitIndex < 0) ? (8 * blockCipher.GetBlockSize()) : int.Parse(text2.Substring(digitIndex)));
					blockCipherMode = new CfbBlockCipher(blockCipher, bitBlockSize);
					break;
				}
				case CipherMode.CTR:
					blockCipherMode = new SicBlockCipher(blockCipher);
					break;
				case CipherMode.CTS:
					flag = true;
					blockCipherMode = new CbcBlockCipher(blockCipher);
					break;
				case CipherMode.EAX:
					aeadBlockCipher = new EaxBlockCipher(blockCipher);
					break;
				case CipherMode.GCM:
					aeadBlockCipher = new GcmBlockCipher(blockCipher);
					break;
				case CipherMode.GOFB:
					blockCipherMode = new GOfbBlockCipher(blockCipher);
					break;
				case CipherMode.OCB:
					aeadBlockCipher = new OcbBlockCipher(blockCipher, CreateBlockCipher(enumValue));
					break;
				case CipherMode.OFB:
				{
					int blockSize = ((digitIndex < 0) ? (8 * blockCipher.GetBlockSize()) : int.Parse(text2.Substring(digitIndex)));
					blockCipherMode = new OfbBlockCipher(blockCipher, blockSize);
					break;
				}
				case CipherMode.OPENPGPCFB:
					blockCipherMode = new OpenPgpCfbBlockCipher(blockCipher);
					break;
				case CipherMode.SIC:
					if (blockCipher.GetBlockSize() < 16)
					{
						throw new ArgumentException("Warning: SIC-Mode can become a twotime-pad if the blocksize of the cipher is too small. Use a cipher with a block size of at least 128 bits (e.g. AES)");
					}
					blockCipherMode = new SicBlockCipher(blockCipher);
					break;
				default:
					throw new SecurityUtilityException("Cipher " + algorithm + " not recognised.");
				case CipherMode.ECB:
				case CipherMode.NONE:
					break;
				}
			}
			catch (ArgumentException)
			{
				throw new SecurityUtilityException("Cipher " + algorithm + " not recognised.");
			}
		}
		if (aeadBlockCipher != null)
		{
			if (flag)
			{
				throw new SecurityUtilityException("CTS mode not valid for AEAD ciphers.");
			}
			if (flag2 && array.Length > 2 && array[2] != "")
			{
				throw new SecurityUtilityException("Bad padding specified for AEAD cipher.");
			}
			return new BufferedAeadBlockCipher(aeadBlockCipher);
		}
		if (blockCipher != null)
		{
			if (blockCipherMode == null)
			{
				blockCipherMode = EcbBlockCipher.GetBlockCipherMode(blockCipher);
			}
			if (flag)
			{
				return new CtsBlockCipher(blockCipherMode);
			}
			if (blockCipherPadding != null)
			{
				return new PaddedBufferedBlockCipher(blockCipherMode, blockCipherPadding);
			}
			if (!flag2 || blockCipherMode.IsPartialBlockOkay)
			{
				return new BufferedBlockCipher(blockCipherMode);
			}
			return new PaddedBufferedBlockCipher(blockCipherMode);
		}
		if (asymmetricBlockCipher != null)
		{
			return new BufferedAsymmetricBlockCipher(asymmetricBlockCipher);
		}
		throw new SecurityUtilityException("Cipher " + algorithm + " not recognised.");
	}

	public static string GetAlgorithmName(DerObjectIdentifier oid)
	{
		return CollectionUtilities.GetValueOrNull(Algorithms, oid.Id);
	}

	private static int GetDigitIndex(string s)
	{
		for (int i = 0; i < s.Length; i++)
		{
			if (char.IsDigit(s[i]))
			{
				return i;
			}
		}
		return -1;
	}

	private static IBlockCipher CreateBlockCipher(CipherAlgorithm cipherAlgorithm)
	{
		return cipherAlgorithm switch
		{
			CipherAlgorithm.AES => AesUtilities.CreateEngine(), 
			CipherAlgorithm.ARIA => new AriaEngine(), 
			CipherAlgorithm.BLOWFISH => new BlowfishEngine(), 
			CipherAlgorithm.CAMELLIA => new CamelliaEngine(), 
			CipherAlgorithm.CAST5 => new Cast5Engine(), 
			CipherAlgorithm.CAST6 => new Cast6Engine(), 
			CipherAlgorithm.DES => new DesEngine(), 
			CipherAlgorithm.DESEDE => new DesEdeEngine(), 
			CipherAlgorithm.GOST28147 => new Gost28147Engine(), 
			CipherAlgorithm.IDEA => new IdeaEngine(), 
			CipherAlgorithm.NOEKEON => new NoekeonEngine(), 
			CipherAlgorithm.RC2 => new RC2Engine(), 
			CipherAlgorithm.RC5 => new RC532Engine(), 
			CipherAlgorithm.RC5_64 => new RC564Engine(), 
			CipherAlgorithm.RC6 => new RC6Engine(), 
			CipherAlgorithm.RIJNDAEL => new RijndaelEngine(), 
			CipherAlgorithm.SEED => new SeedEngine(), 
			CipherAlgorithm.SERPENT => new SerpentEngine(), 
			CipherAlgorithm.SKIPJACK => new SkipjackEngine(), 
			CipherAlgorithm.SM4 => new SM4Engine(), 
			CipherAlgorithm.TEA => new TeaEngine(), 
			CipherAlgorithm.THREEFISH_256 => new ThreefishEngine(256), 
			CipherAlgorithm.THREEFISH_512 => new ThreefishEngine(512), 
			CipherAlgorithm.THREEFISH_1024 => new ThreefishEngine(1024), 
			CipherAlgorithm.TNEPRES => new TnepresEngine(), 
			CipherAlgorithm.TWOFISH => new TwofishEngine(), 
			CipherAlgorithm.XTEA => new XteaEngine(), 
			_ => throw new SecurityUtilityException("Cipher " + cipherAlgorithm.ToString() + " not recognised or not a block cipher"), 
		};
	}
}
