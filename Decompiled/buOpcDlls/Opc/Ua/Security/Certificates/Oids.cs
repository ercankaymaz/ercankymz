using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

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
		{
			return "1.2.840.113549.1.1.5";
		}
		if (hashAlgorithm == HashAlgorithmName.SHA256)
		{
			return "1.2.840.113549.1.1.11";
		}
		if (hashAlgorithm == HashAlgorithmName.SHA384)
		{
			return "1.2.840.113549.1.1.12";
		}
		if (hashAlgorithm == HashAlgorithmName.SHA512)
		{
			return "1.2.840.113549.1.1.13";
		}
		throw new NotSupportedException("Signing RSA with hash " + hashAlgorithm.Name + " is not supported. ");
	}

	public static string GetECDsaOid(HashAlgorithmName hashAlgorithm)
	{
		if (hashAlgorithm == HashAlgorithmName.SHA1)
		{
			return "1.2.840.10045.4.1";
		}
		if (hashAlgorithm == HashAlgorithmName.SHA256)
		{
			return "1.2.840.10045.4.3.2";
		}
		if (hashAlgorithm == HashAlgorithmName.SHA384)
		{
			return "1.2.840.10045.4.3.3";
		}
		if (hashAlgorithm == HashAlgorithmName.SHA512)
		{
			return "1.2.840.10045.4.3.4";
		}
		throw new NotSupportedException("Signing ECDsa with hash " + hashAlgorithm.Name + " is not supported. ");
	}

	public static HashAlgorithmName GetHashAlgorithmName(string oid)
	{
		switch (oid)
		{
		case "1.2.840.10045.4.1":
		case "1.2.840.113549.1.1.5":
			return HashAlgorithmName.SHA1;
		case "1.2.840.10045.4.3.2":
		case "1.2.840.113549.1.1.11":
			return HashAlgorithmName.SHA256;
		case "1.2.840.10045.4.3.3":
		case "1.2.840.113549.1.1.12":
			return HashAlgorithmName.SHA384;
		case "1.2.840.10045.4.3.4":
		case "1.2.840.113549.1.1.13":
			return HashAlgorithmName.SHA512;
		default:
			throw new NotSupportedException("Hash algorithm " + oid + " is not supported. ");
		}
	}
}
