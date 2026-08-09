using System;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Encryption;

internal static class EncryptionDictionaryFactory
{
	public static EncryptionDictionary Read(DictionaryToken encryptionDictionary, IPdfTokenScanner tokenScanner)
	{
		if (encryptionDictionary == null)
		{
			throw new ArgumentNullException("encryptionDictionary");
		}
		NameToken nameToken = encryptionDictionary.Get<NameToken>(NameToken.Filter, tokenScanner);
		EncryptionAlgorithmCode encryptionAlgorithmCode = EncryptionAlgorithmCode.Unrecognized;
		if (encryptionDictionary.TryGetOptionalTokenDirect<NumericToken>(NameToken.V, tokenScanner, out NumericToken result))
		{
			encryptionAlgorithmCode = (EncryptionAlgorithmCode)result.Int;
		}
		int? keyLength = null;
		if (encryptionDictionary.TryGetOptionalTokenDirect<NumericToken>(NameToken.Length, tokenScanner, out NumericToken result2))
		{
			keyLength = result2.Int;
		}
		int num = 0;
		if (encryptionDictionary.TryGetOptionalTokenDirect<NumericToken>(NameToken.R, tokenScanner, out NumericToken result3))
		{
			num = result3.Int;
		}
		byte[] ownerBytes = null;
		if (encryptionDictionary.TryGet(NameToken.O, out var token))
		{
			if (token is StringToken stringToken)
			{
				ownerBytes = stringToken.GetBytes();
			}
			else if (token is HexToken { Bytes: var bytes })
			{
				ownerBytes = bytes.ToArray();
			}
		}
		byte[] userBytes = null;
		if (encryptionDictionary.TryGet(NameToken.U, out var token2))
		{
			if (token2 is StringToken stringToken2)
			{
				userBytes = stringToken2.GetBytes();
			}
			else if (token2 is HexToken { Bytes: var bytes2 })
			{
				userBytes = bytes2.ToArray();
			}
		}
		UserAccessPermissions userAccessPermissions = (UserAccessPermissions)0L;
		if (encryptionDictionary.TryGetOptionalTokenDirect<NumericToken>(NameToken.P, tokenScanner, out NumericToken result4))
		{
			userAccessPermissions = (UserAccessPermissions)result4.Long;
		}
		byte[] userEncryptionBytes = null;
		byte[] ownerEncryptionBytes = null;
		if (num >= 5)
		{
			ownerEncryptionBytes = GetEncryptionBytesOrDefault(encryptionDictionary, tokenScanner, isUser: false);
			userEncryptionBytes = GetEncryptionBytesOrDefault(encryptionDictionary, tokenScanner, isUser: true);
		}
		encryptionDictionary.TryGetOptionalTokenDirect<BooleanToken>(NameToken.EncryptMetaData, tokenScanner, out BooleanToken result5);
		return new EncryptionDictionary(nameToken.Data, encryptionAlgorithmCode, keyLength, num, ownerBytes, userBytes, ownerEncryptionBytes, userEncryptionBytes, userAccessPermissions, encryptionDictionary, result5?.Data ?? true);
	}

	private static byte[]? GetEncryptionBytesOrDefault(DictionaryToken encryptionDictionary, IPdfTokenScanner tokenScanner, bool isUser)
	{
		NameToken name = (isUser ? NameToken.Ue : NameToken.Oe);
		if (encryptionDictionary.TryGet<StringToken>(name, tokenScanner, out StringToken token))
		{
			return token.GetBytes();
		}
		if (encryptionDictionary.TryGet<HexToken>(name, tokenScanner, out HexToken token2))
		{
			return token2.Bytes.ToArray();
		}
		return null;
	}
}
