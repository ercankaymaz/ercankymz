using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace Opc.Ua.Security.Certificates.BouncyCastle;

internal static class X509Utils
{
	internal static byte[] CreatePfxWithPrivateKey(Org.BouncyCastle.X509.X509Certificate certificate, string friendlyName, AsymmetricKeyParameter privateKey, string passcode, SecureRandom random)
	{
		using MemoryStream memoryStream = new MemoryStream();
		Pkcs12StoreBuilder pkcs12StoreBuilder = new Pkcs12StoreBuilder();
		pkcs12StoreBuilder.SetUseDerEncoding(useDerEncoding: true);
		Pkcs12Store pkcs12Store = pkcs12StoreBuilder.Build();
		X509CertificateEntry[] chain = new X509CertificateEntry[1]
		{
			new X509CertificateEntry(certificate)
		};
		if (string.IsNullOrEmpty(friendlyName))
		{
			friendlyName = GetCertificateCommonName(certificate);
		}
		pkcs12Store.SetKeyEntry(friendlyName, new AsymmetricKeyEntry(privateKey), chain);
		pkcs12Store.Save(memoryStream, passcode.ToCharArray(), random);
		return memoryStream.ToArray();
	}

	internal static string GetRSAHashAlgorithm(HashAlgorithmName hashAlgorithmName)
	{
		if (hashAlgorithmName == HashAlgorithmName.SHA1)
		{
			return "SHA1WITHRSA";
		}
		if (hashAlgorithmName == HashAlgorithmName.SHA256)
		{
			return "SHA256WITHRSA";
		}
		if (hashAlgorithmName == HashAlgorithmName.SHA384)
		{
			return "SHA384WITHRSA";
		}
		if (hashAlgorithmName == HashAlgorithmName.SHA512)
		{
			return "SHA512WITHRSA";
		}
		throw new CryptographicException($"The hash algorithm {hashAlgorithmName} is not supported");
	}

	internal static RsaKeyParameters GetPublicKeyParameter(X509Certificate2 certificate)
	{
		using RSA rsa = certificate.GetRSAPublicKey();
		return GetPublicKeyParameter(rsa);
	}

	internal static RsaKeyParameters GetPublicKeyParameter(RSA rsa)
	{
		RSAParameters rSAParameters = rsa.ExportParameters(includePrivateParameters: false);
		return new RsaKeyParameters(isPrivate: false, new BigInteger(1, rSAParameters.Modulus), new BigInteger(1, rSAParameters.Exponent));
	}

	internal static RsaPrivateCrtKeyParameters GetPrivateKeyParameter(X509Certificate2 certificate)
	{
		using RSA rsa = certificate.GetRSAPrivateKey();
		return GetPrivateKeyParameter(rsa);
	}

	internal static RsaPrivateCrtKeyParameters GetPrivateKeyParameter(RSA rsa)
	{
		RSAParameters rSAParameters = rsa.ExportParameters(includePrivateParameters: true);
		return new RsaPrivateCrtKeyParameters(new BigInteger(1, rSAParameters.Modulus), new BigInteger(1, rSAParameters.Exponent), new BigInteger(1, rSAParameters.D), new BigInteger(1, rSAParameters.P), new BigInteger(1, rSAParameters.Q), new BigInteger(1, rSAParameters.DP), new BigInteger(1, rSAParameters.DQ), new BigInteger(1, rSAParameters.InverseQ));
	}

	internal static BigInteger GetSerialNumber(X509Certificate2 certificate)
	{
		byte[] serialNumber = certificate.GetSerialNumber();
		return new BigInteger(1, Enumerable.Reverse(serialNumber).ToArray());
	}

	internal static string GetCertificateCommonName(Org.BouncyCastle.X509.X509Certificate certificate)
	{
		IList<string> valueList = certificate.SubjectDN.GetValueList(X509Name.CN);
		if (valueList.Count > 0)
		{
			return valueList[0].ToString();
		}
		return string.Empty;
	}

	internal static string GeneratePasscode()
	{
		using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
		byte[] array = new byte[18];
		randomNumberGenerator.GetBytes(array);
		return Convert.ToBase64String(array);
	}

	internal static RSA SetRSAPublicKey(byte[] publicKey)
	{
		RsaKeyParameters rsaKeyParameters = PublicKeyFactory.CreateKey(publicKey) as RsaKeyParameters;
		RSAParameters parameters = new RSAParameters
		{
			Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned(),
			Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned()
		};
		RSA rSA = RSA.Create();
		rSA.ImportParameters(parameters);
		return rSA;
	}
}
