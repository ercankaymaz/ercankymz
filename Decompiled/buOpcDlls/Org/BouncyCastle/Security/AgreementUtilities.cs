using System;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Agreement.Kdf;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Utilities.Collections;

namespace Org.BouncyCastle.Security;

public static class AgreementUtilities
{
	private static readonly IDictionary<string, string> Algorithms;

	static AgreementUtilities()
	{
		Algorithms = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		Algorithms[X9ObjectIdentifiers.DHSinglePassCofactorDHSha1KdfScheme.Id] = "ECCDHWITHSHA1KDF";
		Algorithms[X9ObjectIdentifiers.DHSinglePassStdDHSha1KdfScheme.Id] = "ECDHWITHSHA1KDF";
		Algorithms[X9ObjectIdentifiers.MqvSinglePassSha1KdfScheme.Id] = "ECMQVWITHSHA1KDF";
		Algorithms[EdECObjectIdentifiers.id_X25519.Id] = "X25519";
		Algorithms[EdECObjectIdentifiers.id_X448.Id] = "X448";
	}

	public static IBasicAgreement GetBasicAgreement(DerObjectIdentifier oid)
	{
		return GetBasicAgreement(oid.Id);
	}

	public static IBasicAgreement GetBasicAgreement(string algorithm)
	{
		switch (GetMechanism(algorithm))
		{
		case "DH":
		case "DIFFIEHELLMAN":
			return new DHBasicAgreement();
		case "ECDH":
			return new ECDHBasicAgreement();
		case "ECDHC":
		case "ECCDH":
			return new ECDHCBasicAgreement();
		case "ECMQV":
			return new ECMqvBasicAgreement();
		default:
			throw new SecurityUtilityException("Basic Agreement " + algorithm + " not recognised.");
		}
	}

	public static IBasicAgreement GetBasicAgreementWithKdf(DerObjectIdentifier oid, string wrapAlgorithm)
	{
		return GetBasicAgreementWithKdf(oid.Id, wrapAlgorithm);
	}

	public static IBasicAgreement GetBasicAgreementWithKdf(string agreeAlgorithm, string wrapAlgorithm)
	{
		switch (GetMechanism(agreeAlgorithm))
		{
		case "DHWITHSHA1KDF":
		case "ECDHWITHSHA1KDF":
			return new ECDHWithKdfBasicAgreement(wrapAlgorithm, new ECDHKekGenerator(new Sha1Digest()));
		case "ECMQVWITHSHA1KDF":
			return new ECMqvWithKdfBasicAgreement(wrapAlgorithm, new ECDHKekGenerator(new Sha1Digest()));
		default:
			throw new SecurityUtilityException("Basic Agreement (with KDF) " + agreeAlgorithm + " not recognised.");
		}
	}

	public static IRawAgreement GetRawAgreement(DerObjectIdentifier oid)
	{
		return GetRawAgreement(oid.Id);
	}

	public static IRawAgreement GetRawAgreement(string algorithm)
	{
		string mechanism = GetMechanism(algorithm);
		if (mechanism == "X25519")
		{
			return new X25519Agreement();
		}
		if (mechanism == "X448")
		{
			return new X448Agreement();
		}
		throw new SecurityUtilityException("Raw Agreement " + algorithm + " not recognised.");
	}

	public static string GetAlgorithmName(DerObjectIdentifier oid)
	{
		return CollectionUtilities.GetValueOrNull(Algorithms, oid.Id);
	}

	private static string GetMechanism(string algorithm)
	{
		return CollectionUtilities.GetValueOrKey(Algorithms, algorithm).ToUpperInvariant();
	}
}
