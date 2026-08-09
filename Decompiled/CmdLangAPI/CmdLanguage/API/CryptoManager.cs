using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CmdLanguage.API;

internal static class CryptoManager
{
	private static readonly byte[] Key = Encoding.UTF8.GetBytes("CmdLangSecureKey_2026!@#$$%^&*()");

	private static readonly byte[] IV = Encoding.UTF8.GetBytes("CmdLang_IV_16byt");

	public static string Decrypt(string cipherText)
	{
		try
		{
			using Aes aes = Aes.Create();
			aes.Key = Key;
			aes.IV = IV;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
			byte[] buffer = Convert.FromBase64String(cipherText);
			using MemoryStream stream = new MemoryStream(buffer);
			using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			using StreamReader streamReader = new StreamReader(stream2);
			return streamReader.ReadToEnd();
		}
		catch
		{
			return null;
		}
	}
}
