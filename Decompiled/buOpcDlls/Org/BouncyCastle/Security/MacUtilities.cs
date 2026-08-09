using System;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Iana;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;

namespace Org.BouncyCastle.Security;

public static class MacUtilities
{
	private static readonly IDictionary<string, string> Algorithms;

	static MacUtilities()
	{
		Algorithms = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		Algorithms[IanaObjectIdentifiers.HmacMD5.Id] = "HMAC-MD5";
		Algorithms[IanaObjectIdentifiers.HmacRipeMD160.Id] = "HMAC-RIPEMD160";
		Algorithms[IanaObjectIdentifiers.HmacSha1.Id] = "HMAC-SHA1";
		Algorithms[IanaObjectIdentifiers.HmacTiger.Id] = "HMAC-TIGER";
		Algorithms[PkcsObjectIdentifiers.IdHmacWithSha1.Id] = "HMAC-SHA1";
		Algorithms[MiscObjectIdentifiers.HMAC_SHA1.Id] = "HMAC-SHA1";
		Algorithms[PkcsObjectIdentifiers.IdHmacWithSha224.Id] = "HMAC-SHA224";
		Algorithms[PkcsObjectIdentifiers.IdHmacWithSha256.Id] = "HMAC-SHA256";
		Algorithms[PkcsObjectIdentifiers.IdHmacWithSha384.Id] = "HMAC-SHA384";
		Algorithms[PkcsObjectIdentifiers.IdHmacWithSha512.Id] = "HMAC-SHA512";
		Algorithms[NistObjectIdentifiers.IdHMacWithSha3_224.Id] = "HMAC-SHA3-224";
		Algorithms[NistObjectIdentifiers.IdHMacWithSha3_256.Id] = "HMAC-SHA3-256";
		Algorithms[NistObjectIdentifiers.IdHMacWithSha3_384.Id] = "HMAC-SHA3-384";
		Algorithms[NistObjectIdentifiers.IdHMacWithSha3_512.Id] = "HMAC-SHA3-512";
		Algorithms[RosstandartObjectIdentifiers.id_tc26_hmac_gost_3411_12_256.Id] = "HMAC-GOST3411-2012-256";
		Algorithms[RosstandartObjectIdentifiers.id_tc26_hmac_gost_3411_12_512.Id] = "HMAC-GOST3411-2012-512";
		Algorithms["DES"] = "DESMAC";
		Algorithms["DES/CFB8"] = "DESMAC/CFB8";
		Algorithms["DES64"] = "DESMAC64";
		Algorithms["DESEDE"] = "DESEDEMAC";
		Algorithms[PkcsObjectIdentifiers.DesEde3Cbc.Id] = "DESEDEMAC";
		Algorithms["DESEDE/CFB8"] = "DESEDEMAC/CFB8";
		Algorithms["DESISO9797MAC"] = "DESWITHISO9797";
		Algorithms["DESEDE64"] = "DESEDEMAC64";
		Algorithms["DESEDE64WITHISO7816-4PADDING"] = "DESEDEMAC64WITHISO7816-4PADDING";
		Algorithms["DESEDEISO9797ALG1MACWITHISO7816-4PADDING"] = "DESEDEMAC64WITHISO7816-4PADDING";
		Algorithms["DESEDEISO9797ALG1WITHISO7816-4PADDING"] = "DESEDEMAC64WITHISO7816-4PADDING";
		Algorithms["ISO9797ALG3"] = "ISO9797ALG3MAC";
		Algorithms["ISO9797ALG3MACWITHISO7816-4PADDING"] = "ISO9797ALG3WITHISO7816-4PADDING";
		Algorithms["SKIPJACK"] = "SKIPJACKMAC";
		Algorithms["SKIPJACK/CFB8"] = "SKIPJACKMAC/CFB8";
		Algorithms["IDEA"] = "IDEAMAC";
		Algorithms["IDEA/CFB8"] = "IDEAMAC/CFB8";
		Algorithms["RC2"] = "RC2MAC";
		Algorithms["RC2/CFB8"] = "RC2MAC/CFB8";
		Algorithms["RC5"] = "RC5MAC";
		Algorithms["RC5/CFB8"] = "RC5MAC/CFB8";
		Algorithms["GOST28147"] = "GOST28147MAC";
		Algorithms["VMPC"] = "VMPCMAC";
		Algorithms["VMPC-MAC"] = "VMPCMAC";
		Algorithms["SIPHASH"] = "SIPHASH-2-4";
		Algorithms["PBEWITHHMACSHA"] = "PBEWITHHMACSHA1";
		Algorithms["1.3.14.3.2.26"] = "PBEWITHHMACSHA1";
	}

	public static IMac GetMac(DerObjectIdentifier id)
	{
		return GetMac(id.Id);
	}

	public static IMac GetMac(string algorithm)
	{
		if (algorithm == null)
		{
			throw new ArgumentNullException("algorithm");
		}
		string text = CollectionUtilities.GetValueOrKey(Algorithms, algorithm).ToUpperInvariant();
		if (Platform.StartsWith(text, "PBEWITH"))
		{
			text = text.Substring("PBEWITH".Length);
		}
		if (Platform.StartsWith(text, "HMAC"))
		{
			string algorithm2 = ((!Platform.StartsWith(text, "HMAC-") && !Platform.StartsWith(text, "HMAC/")) ? text.Substring(4) : text.Substring(5));
			return new HMac(DigestUtilities.GetDigest(algorithm2));
		}
		switch (text)
		{
		case "AESCMAC":
			return new CMac(AesUtilities.CreateEngine());
		case "DESMAC":
			return new CbcBlockCipherMac(new DesEngine());
		case "DESMAC/CFB8":
			return new CfbBlockCipherMac(new DesEngine());
		case "DESMAC64":
			return new CbcBlockCipherMac(new DesEngine(), 64);
		case "DESEDECMAC":
			return new CMac(new DesEdeEngine());
		case "DESEDEMAC":
			return new CbcBlockCipherMac(new DesEdeEngine());
		case "DESEDEMAC/CFB8":
			return new CfbBlockCipherMac(new DesEdeEngine());
		case "DESEDEMAC64":
			return new CbcBlockCipherMac(new DesEdeEngine(), 64);
		case "DESEDEMAC64WITHISO7816-4PADDING":
			return new CbcBlockCipherMac(new DesEdeEngine(), 64, new ISO7816d4Padding());
		case "DESWITHISO9797":
		case "ISO9797ALG3MAC":
			return new ISO9797Alg3Mac(new DesEngine());
		case "ISO9797ALG3WITHISO7816-4PADDING":
			return new ISO9797Alg3Mac(new DesEngine(), new ISO7816d4Padding());
		case "SKIPJACKMAC":
			return new CbcBlockCipherMac(new SkipjackEngine());
		case "SKIPJACKMAC/CFB8":
			return new CfbBlockCipherMac(new SkipjackEngine());
		case "IDEAMAC":
			return new CbcBlockCipherMac(new IdeaEngine());
		case "IDEAMAC/CFB8":
			return new CfbBlockCipherMac(new IdeaEngine());
		case "RC2MAC":
			return new CbcBlockCipherMac(new RC2Engine());
		case "RC2MAC/CFB8":
			return new CfbBlockCipherMac(new RC2Engine());
		case "RC5MAC":
			return new CbcBlockCipherMac(new RC532Engine());
		case "RC5MAC/CFB8":
			return new CfbBlockCipherMac(new RC532Engine());
		case "GOST28147MAC":
			return new Gost28147Mac();
		case "VMPCMAC":
			return new VmpcMac();
		case "SIPHASH-2-4":
			return new SipHash();
		default:
			throw new SecurityUtilityException("Mac " + text + " not recognised.");
		}
	}

	public static string GetAlgorithmName(DerObjectIdentifier oid)
	{
		return CollectionUtilities.GetValueOrNull(Algorithms, oid.Id);
	}

	public static byte[] CalculateMac(string algorithm, ICipherParameters cp, byte[] input)
	{
		IMac mac = GetMac(algorithm);
		mac.Init(cp);
		mac.BlockUpdate(input, 0, input.Length);
		return DoFinal(mac);
	}

	public static byte[] DoFinal(IMac mac)
	{
		byte[] array = new byte[mac.GetMacSize()];
		mac.DoFinal(array, 0);
		return array;
	}

	public static byte[] DoFinal(IMac mac, byte[] input)
	{
		mac.BlockUpdate(input, 0, input.Length);
		return DoFinal(mac);
	}
}
