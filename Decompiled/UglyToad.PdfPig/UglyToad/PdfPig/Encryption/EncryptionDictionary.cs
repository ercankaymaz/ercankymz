using System;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Exceptions;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Encryption;

internal class EncryptionDictionary
{
	public string Filter { get; }

	public EncryptionAlgorithmCode EncryptionAlgorithmCode { get; }

	public int? KeyLength { get; }

	public int Revision { get; }

	public byte[]? OwnerBytes { get; }

	public byte[]? UserBytes { get; }

	public byte[]? OwnerEncryptionBytes { get; }

	public byte[]? UserEncryptionBytes { get; }

	public UserAccessPermissions UserAccessPermissions { get; }

	public bool IsStandardFilter => string.Equals(Filter, "Standard", StringComparison.OrdinalIgnoreCase);

	public bool EncryptMetadata { get; }

	public DictionaryToken Dictionary { get; }

	public EncryptionDictionary(string filter, EncryptionAlgorithmCode encryptionAlgorithmCode, int? keyLength, int revision, byte[]? ownerBytes, byte[]? userBytes, byte[]? ownerEncryptionBytes, byte[]? userEncryptionBytes, UserAccessPermissions userAccessPermissions, DictionaryToken dictionary, bool encryptMetadata)
	{
		Filter = filter;
		EncryptionAlgorithmCode = encryptionAlgorithmCode;
		KeyLength = keyLength;
		Revision = revision;
		OwnerBytes = ownerBytes;
		UserBytes = userBytes;
		OwnerEncryptionBytes = ownerEncryptionBytes;
		UserEncryptionBytes = userEncryptionBytes;
		UserAccessPermissions = userAccessPermissions;
		Dictionary = dictionary;
		EncryptMetadata = encryptMetadata;
	}

	public bool TryGetCryptHandler([NotNullWhen(true)] out CryptHandler? cryptHandler)
	{
		cryptHandler = null;
		if (EncryptionAlgorithmCode != EncryptionAlgorithmCode.SecurityHandlerInDocument && EncryptionAlgorithmCode != EncryptionAlgorithmCode.SecurityHandlerInDocument256)
		{
			return false;
		}
		if (!Dictionary.TryGet(NameToken.Cf, out DictionaryToken token))
		{
			return false;
		}
		DictionaryToken dictionaryToken = token;
		NameToken token2;
		NameToken nameToken = (Dictionary.TryGet(NameToken.StmF, out token2) ? token2 : NameToken.Identity);
		NameToken token3;
		NameToken nameToken2 = (Dictionary.TryGet(NameToken.StrF, out token3) ? token3 : NameToken.Identity);
		if (nameToken != NameToken.Identity && !dictionaryToken.TryGet(nameToken, out var token4))
		{
			throw new PdfDocumentEncryptedException($"Stream filter {nameToken} not found in crypt dictionary: {token}.");
		}
		if (nameToken2 != NameToken.Identity && !dictionaryToken.TryGet(nameToken2, out token4))
		{
			throw new PdfDocumentEncryptedException($"String filter {nameToken2} not found in crypt dictionary: {token}.");
		}
		cryptHandler = new CryptHandler(dictionaryToken, nameToken, nameToken2);
		return true;
	}
}
