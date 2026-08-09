using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class X509PfxUtils
{
	public const int TestBlockSize = 32;

	private static X509KeyUsageFlags GetKeyUsage(X509Certificate2 cert)
	{
		X509KeyUsageFlags x509KeyUsageFlags = X509KeyUsageFlags.None;
		foreach (X509KeyUsageExtension item in cert.Extensions.OfType<X509KeyUsageExtension>())
		{
			x509KeyUsageFlags |= item.KeyUsages;
		}
		return x509KeyUsageFlags;
	}

	public static bool VerifyRSAKeyPair(X509Certificate2 certWithPublicKey, X509Certificate2 certWithPrivateKey, bool throwOnError = false)
	{
		bool flag = false;
		try
		{
			using RSA rSA = certWithPrivateKey.GetRSAPrivateKey();
			using RSA rSA2 = certWithPublicKey.GetRSAPublicKey();
			if (rSA == null || rSA2 == null)
			{
				throw new CryptographicException("The certificate does not contain a RSA public/private key pair.");
			}
			X509KeyUsageFlags keyUsage = GetKeyUsage(certWithPublicKey);
			if ((keyUsage & X509KeyUsageFlags.DataEncipherment) != X509KeyUsageFlags.None)
			{
				flag = VerifyRSAKeyPairCrypt(rSA2, rSA);
			}
			else
			{
				if ((keyUsage & X509KeyUsageFlags.DigitalSignature) == 0)
				{
					throw new CryptographicException("Don't know how to verify the public/private key pair.");
				}
				flag = VerifyRSAKeyPairSign(rSA2, rSA);
			}
		}
		catch (Exception)
		{
			if (throwOnError)
			{
				throwOnError = false;
				throw;
			}
		}
		if (!flag && throwOnError)
		{
			throw new CryptographicException("The public/private key pair in the certficates do not match.");
		}
		return flag;
	}

	public static X509Certificate2 CreateCertificateFromPKCS12(byte[] rawData, string password)
	{
		Exception innerException = null;
		X509Certificate2 x509Certificate = null;
		X509KeyStorageFlags[] array = new X509KeyStorageFlags[2]
		{
			X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet,
			X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet
		};
		foreach (X509KeyStorageFlags keyStorageFlags in array)
		{
			try
			{
				x509Certificate = new X509Certificate2(rawData, password ?? string.Empty, keyStorageFlags);
				if (VerifyRSAKeyPair(x509Certificate, x509Certificate, throwOnError: true))
				{
					return x509Certificate;
				}
			}
			catch (Exception ex)
			{
				innerException = ex;
				x509Certificate?.Dispose();
				x509Certificate = null;
			}
		}
		if (x509Certificate == null)
		{
			throw new NotSupportedException("Creating X509Certificate from PKCS #12 store failed", innerException);
		}
		return x509Certificate;
	}

	internal static bool VerifyRSAKeyPairCrypt(RSA rsaPublicKey, RSA rsaPrivateKey)
	{
		byte[] array = new byte[32];
		new Random().NextBytes(array);
		byte[] data = rsaPublicKey.Encrypt(array, RSAEncryptionPadding.OaepSHA1);
		byte[] array2 = rsaPrivateKey.Decrypt(data, RSAEncryptionPadding.OaepSHA1);
		if (array2 != null)
		{
			return Enumerable.SequenceEqual(array, array2);
		}
		return false;
	}

	internal static bool VerifyRSAKeyPairSign(RSA rsaPublicKey, RSA rsaPrivateKey)
	{
		byte[] array = new byte[32];
		new Random().NextBytes(array);
		byte[] signature = rsaPrivateKey.SignData(array, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
		return rsaPublicKey.VerifyData(array, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
	}

	public static bool VerifyECDsaKeyPair(X509Certificate2 certWithPublicKey, X509Certificate2 certWithPrivateKey, bool throwOnError = false)
	{
		bool flag = false;
		using (ECDsa ecdsaPublicKey = certWithPrivateKey.GetECDsaPublicKey())
		{
			using ECDsa ecdsaPrivateKey = certWithPublicKey.GetECDsaPrivateKey();
			try
			{
				if ((GetKeyUsage(certWithPublicKey) & X509KeyUsageFlags.DigitalSignature) != X509KeyUsageFlags.None)
				{
					flag = VerifyECDsaKeyPairSign(ecdsaPublicKey, ecdsaPrivateKey);
				}
				else if (throwOnError)
				{
					throw new CryptographicException("Don't know how to verify the public/private key pair.");
				}
			}
			catch (Exception)
			{
				if (throwOnError)
				{
					throwOnError = false;
					throw;
				}
			}
		}
		if (!flag && throwOnError)
		{
			throw new CryptographicException("The public/private key pair in the certficates do not match.");
		}
		return flag;
	}

	internal static bool VerifyECDsaKeyPairSign(ECDsa ecdsaPublicKey, ECDsa ecdsaPrivateKey)
	{
		byte[] array = new byte[32];
		new Random().NextBytes(array);
		byte[] signature = ecdsaPrivateKey.SignData(array, HashAlgorithmName.SHA256);
		return ecdsaPublicKey.VerifyData(array, signature, HashAlgorithmName.SHA256);
	}
}
