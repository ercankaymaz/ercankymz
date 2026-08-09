using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Opc.Ua.Test;

namespace Opc.Ua;

internal static class RsaUtils
{
	public enum Padding
	{
		Pkcs1,
		OaepSHA1,
		OaepSHA256
	}

	internal static readonly Lazy<bool> IsSupportingRSAPssSign = new Lazy<bool>(() => !Utils.IsRunningOnMono());

	internal static RSAEncryptionPadding GetRSAEncryptionPadding(Padding padding)
	{
		return padding switch
		{
			Padding.Pkcs1 => RSAEncryptionPadding.Pkcs1, 
			Padding.OaepSHA1 => RSAEncryptionPadding.OaepSHA1, 
			Padding.OaepSHA256 => RSAEncryptionPadding.OaepSHA256, 
			_ => throw new ServiceResultException("Invalid Padding"), 
		};
	}

	internal static int GetPlainTextBlockSize(X509Certificate2 encryptingCertificate, Padding padding)
	{
		using RSA rsa = encryptingCertificate.GetRSAPublicKey();
		return GetPlainTextBlockSize(rsa, padding);
	}

	internal static int GetPlainTextBlockSize(RSA rsa, Padding padding)
	{
		if (rsa != null)
		{
			switch (padding)
			{
			case Padding.Pkcs1:
				return rsa.KeySize / 8 - 11;
			case Padding.OaepSHA1:
				return rsa.KeySize / 8 - 42;
			case Padding.OaepSHA256:
				return rsa.KeySize / 8 - 66;
			}
		}
		return -1;
	}

	internal static int GetCipherTextBlockSize(X509Certificate2 encryptingCertificate, Padding padding)
	{
		using RSA rsa = encryptingCertificate.GetRSAPublicKey();
		return GetCipherTextBlockSize(rsa, padding);
	}

	internal static int GetCipherTextBlockSize(RSA rsa, Padding padding)
	{
		if (rsa != null)
		{
			return rsa.KeySize / 8;
		}
		return -1;
	}

	internal static int GetSignatureLength(X509Certificate2 signingCertificate)
	{
		using RSA rSA = signingCertificate.GetRSAPublicKey();
		if (rSA == null)
		{
			throw ServiceResultException.Create(2148728832u, "No public key for certificate.");
		}
		return rSA.KeySize / 8;
	}

	internal static byte[] Rsa_Sign(ArraySegment<byte> dataToSign, X509Certificate2 signingCertificate, HashAlgorithmName hashAlgorithm, RSASignaturePadding rsaSignaturePadding)
	{
		using RSA rSA = signingCertificate.GetRSAPrivateKey();
		if (rSA == null)
		{
			throw ServiceResultException.Create(2148728832u, "No private key for certificate.");
		}
		return rSA.SignData(dataToSign.Array, dataToSign.Offset, dataToSign.Count, hashAlgorithm, rsaSignaturePadding);
	}

	internal static bool Rsa_Verify(ArraySegment<byte> dataToVerify, byte[] signature, X509Certificate2 signingCertificate, HashAlgorithmName hashAlgorithm, RSASignaturePadding rsaSignaturePadding)
	{
		using RSA rSA = signingCertificate.GetRSAPublicKey();
		if (rSA == null)
		{
			throw ServiceResultException.Create(2148728832u, "No public key for certificate.");
		}
		return rSA.VerifyData(dataToVerify.Array, dataToVerify.Offset, dataToVerify.Count, signature, hashAlgorithm, rsaSignaturePadding);
	}

	internal static byte[] Encrypt(byte[] dataToEncrypt, X509Certificate2 encryptingCertificate, Padding padding)
	{
		using RSA rSA = encryptingCertificate.GetRSAPublicKey();
		if (rSA == null)
		{
			throw ServiceResultException.Create(2148728832u, "No public key for certificate.");
		}
		int plainTextBlockSize = GetPlainTextBlockSize(rSA, padding);
		int num = (dataToEncrypt.Length + 4) / plainTextBlockSize + 1;
		int num2 = num * plainTextBlockSize;
		int num3 = num * GetCipherTextBlockSize(rSA, padding);
		byte[] array = new byte[num2];
		array[0] = (byte)(0xFF & dataToEncrypt.Length);
		array[1] = (byte)((0xFF00 & dataToEncrypt.Length) >> 8);
		array[2] = (byte)((0xFF0000 & dataToEncrypt.Length) >> 16);
		array[3] = (byte)((0xFF000000u & dataToEncrypt.Length) >> 24);
		Array.Copy(dataToEncrypt, 0, array, 4, dataToEncrypt.Length);
		byte[] array2 = new byte[num3];
		Encrypt(new ArraySegment<byte>(array), rSA, padding, new ArraySegment<byte>(array2));
		return array2;
	}

	private static ArraySegment<byte> Encrypt(ArraySegment<byte> dataToEncrypt, RSA rsa, Padding padding, ArraySegment<byte> outputBuffer)
	{
		int plainTextBlockSize = GetPlainTextBlockSize(rsa, padding);
		int cipherTextBlockSize = GetCipherTextBlockSize(rsa, padding);
		if (dataToEncrypt.Count % plainTextBlockSize != 0)
		{
			Utils.LogError("Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", dataToEncrypt.Count, plainTextBlockSize);
		}
		byte[] array = outputBuffer.Array;
		RSAEncryptionPadding rSAEncryptionPadding = GetRSAEncryptionPadding(padding);
		using (MemoryStream memoryStream = new MemoryStream(array, outputBuffer.Offset, outputBuffer.Count))
		{
			byte[] array2 = new byte[plainTextBlockSize];
			for (int i = dataToEncrypt.Offset; i < dataToEncrypt.Offset + dataToEncrypt.Count; i += plainTextBlockSize)
			{
				Array.Copy(dataToEncrypt.Array, i, array2, 0, array2.Length);
				byte[] array3 = rsa.Encrypt(array2, rSAEncryptionPadding);
				memoryStream.Write(array3, 0, array3.Length);
			}
		}
		return new ArraySegment<byte>(array, outputBuffer.Offset, dataToEncrypt.Count / plainTextBlockSize * cipherTextBlockSize);
	}

	internal static byte[] Decrypt(ArraySegment<byte> dataToDecrypt, X509Certificate2 encryptingCertificate, Padding padding)
	{
		using RSA rSA = encryptingCertificate.GetRSAPrivateKey();
		if (rSA == null)
		{
			throw ServiceResultException.Create(2148728832u, "No private key for certificate.");
		}
		byte[] array = new byte[dataToDecrypt.Count / GetCipherTextBlockSize(rSA, padding) * GetPlainTextBlockSize(encryptingCertificate, padding)];
		ArraySegment<byte> arraySegment = Decrypt(dataToDecrypt, rSA, padding, new ArraySegment<byte>(array));
		int num = 0;
		num += arraySegment.Array[arraySegment.Offset];
		num += arraySegment.Array[arraySegment.Offset + 1] << 8;
		num += arraySegment.Array[arraySegment.Offset + 2] << 16;
		num += arraySegment.Array[arraySegment.Offset + 3] << 24;
		if (num > arraySegment.Count - arraySegment.Offset - 4)
		{
			throw ServiceResultException.Create(2159017984u, "Could not decrypt data. Invalid total length.");
		}
		byte[] array2 = new byte[num];
		Array.Copy(arraySegment.Array, arraySegment.Offset + 4, array2, 0, num);
		return array2;
	}

	private static ArraySegment<byte> Decrypt(ArraySegment<byte> dataToDecrypt, RSA rsa, Padding padding, ArraySegment<byte> outputBuffer)
	{
		int cipherTextBlockSize = GetCipherTextBlockSize(rsa, padding);
		int plainTextBlockSize = GetPlainTextBlockSize(rsa, padding);
		if (dataToDecrypt.Count % cipherTextBlockSize != 0)
		{
			Utils.LogError("Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", dataToDecrypt.Count, cipherTextBlockSize);
		}
		byte[] array = outputBuffer.Array;
		RSAEncryptionPadding rSAEncryptionPadding = GetRSAEncryptionPadding(padding);
		using (MemoryStream memoryStream = new MemoryStream(array, outputBuffer.Offset, outputBuffer.Count))
		{
			byte[] array2 = new byte[cipherTextBlockSize];
			for (int i = dataToDecrypt.Offset; i < dataToDecrypt.Offset + dataToDecrypt.Count; i += cipherTextBlockSize)
			{
				Array.Copy(dataToDecrypt.Array, i, array2, 0, array2.Length);
				byte[] array3 = rsa.Decrypt(array2, rSAEncryptionPadding);
				memoryStream.Write(array3, 0, array3.Length);
			}
		}
		return new ArraySegment<byte>(array, outputBuffer.Offset, dataToDecrypt.Count / cipherTextBlockSize * plainTextBlockSize);
	}

	internal static bool TryVerifyRSAPssSign(RSA publicKey, RSA privateKey)
	{
		try
		{
			RandomSource randomSource = new RandomSource();
			int num = 16;
			byte[] array = new byte[num];
			randomSource.NextBytes(array, 0, num);
			byte[] signature = privateKey.SignData(array, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
			return publicKey.VerifyData(array, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
		}
		catch
		{
			return false;
		}
	}
}
