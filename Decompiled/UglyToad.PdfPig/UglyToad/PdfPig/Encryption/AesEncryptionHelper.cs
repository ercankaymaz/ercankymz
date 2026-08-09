using System;
using System.Security.Cryptography;

namespace UglyToad.PdfPig.Encryption;

internal static class AesEncryptionHelper
{
	public static byte[] Encrypt256()
	{
		throw new NotImplementedException();
	}

	public static byte[] Decrypt(byte[] data, byte[] finalKey)
	{
		if (data.Length == 0)
		{
			return data;
		}
		byte[] array = new byte[16];
		Array.Copy(data, array, array.Length);
		using Aes aes = Aes.Create();
		aes.Key = finalKey;
		aes.IV = array;
		if (data.Length <= array.Length)
		{
			aes.Clear();
			return Array.Empty<byte>();
		}
		using ICryptoTransform cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV);
		byte[] result = cryptoTransform.TransformFinalBlock(data, array.Length, data.Length - array.Length);
		aes.Clear();
		return result;
	}
}
