using System;
using UglyToad.PdfPig.Exceptions;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Encryption;

internal class CryptHandler
{
	private readonly DictionaryToken cryptDictionary;

	public CryptDictionary StreamDictionary { get; }

	public CryptDictionary StringDictionary { get; }

	public CryptHandler(DictionaryToken cryptDictionary, NameToken streamName, NameToken stringName)
	{
		if ((object)streamName == null)
		{
			throw new ArgumentNullException("streamName");
		}
		if ((object)stringName == null)
		{
			throw new ArgumentNullException("stringName");
		}
		this.cryptDictionary = cryptDictionary ?? throw new ArgumentNullException("cryptDictionary");
		StreamDictionary = ParseCryptDictionary(cryptDictionary, streamName);
		StringDictionary = ParseCryptDictionary(cryptDictionary, stringName);
	}

	public CryptDictionary GetNamedCryptDictionary(NameToken name)
	{
		if ((object)name == null)
		{
			throw new ArgumentNullException("name");
		}
		return ParseCryptDictionary(cryptDictionary, name);
	}

	private static CryptDictionary ParseCryptDictionary(DictionaryToken cryptDictionary, NameToken name)
	{
		if (name == NameToken.Identity)
		{
			return CryptDictionary.Identity;
		}
		if (!cryptDictionary.TryGet(name, out DictionaryToken token))
		{
			throw new PdfDocumentEncryptedException($"Could not find named crypt filter {name} for decryption in crypt dictionary: {token}.");
		}
		if (token.TryGet(NameToken.Type, out NameToken token2) && token2 != NameToken.CryptFilter && token2 != NameToken.CryptAlgorithm)
		{
			throw new PdfDocumentEncryptedException($"Invalid crypt dictionary type {token2} for crypt filter {name}: {token}.");
		}
		NameToken token3;
		NameToken nameToken = (token.TryGet(NameToken.Cfm, out token3) ? token3 : NameToken.None);
		CryptDictionary.Method name2;
		if (nameToken == NameToken.None)
		{
			name2 = CryptDictionary.Method.None;
		}
		else if (nameToken == NameToken.V2)
		{
			name2 = CryptDictionary.Method.V2;
		}
		else if (nameToken == NameToken.Aesv2)
		{
			name2 = CryptDictionary.Method.AesV2;
		}
		else
		{
			if (!(nameToken == NameToken.Aesv3))
			{
				throw new PdfDocumentEncryptedException($"Unrecognized CFM option for crypt filter {token3}: {token}.");
			}
			name2 = CryptDictionary.Method.AesV3;
		}
		NameToken token4;
		NameToken nameToken2 = (token.TryGet(NameToken.AuthEvent, out token4) ? token4 : NameToken.DocOpen);
		CryptDictionary.TriggerEvent triggerEvent;
		if (nameToken2 == NameToken.DocOpen)
		{
			triggerEvent = CryptDictionary.TriggerEvent.DocumentOpen;
		}
		else
		{
			if (!(nameToken2 == NameToken.EfOpen))
			{
				throw new PdfDocumentEncryptedException($"Unrecognized AuthEvent option for crypt filter {nameToken2}: {token}.");
			}
			triggerEvent = CryptDictionary.TriggerEvent.EmbeddedFileOpen;
		}
		NumericToken token5;
		int length = (token.TryGet(NameToken.Length, out token5) ? token5.Int : 0);
		return new CryptDictionary(name2, triggerEvent, length);
	}
}
