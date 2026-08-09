using System.Xml;

namespace System.ServiceModel.Security;

public class Basic256SecurityAlgorithmSuite : SecurityAlgorithmSuite
{
	public override string DefaultCanonicalizationAlgorithm => DefaultCanonicalizationAlgorithmDictionaryString.Value;

	public override string DefaultDigestAlgorithm => DefaultDigestAlgorithmDictionaryString.Value;

	public override string DefaultEncryptionAlgorithm => DefaultEncryptionAlgorithmDictionaryString.Value;

	public override int DefaultEncryptionKeyDerivationLength => 256;

	public override string DefaultSymmetricKeyWrapAlgorithm => DefaultSymmetricKeyWrapAlgorithmDictionaryString.Value;

	public override string DefaultAsymmetricKeyWrapAlgorithm => DefaultAsymmetricKeyWrapAlgorithmDictionaryString.Value;

	public override string DefaultSymmetricSignatureAlgorithm => DefaultSymmetricSignatureAlgorithmDictionaryString.Value;

	public override string DefaultAsymmetricSignatureAlgorithm => DefaultAsymmetricSignatureAlgorithmDictionaryString.Value;

	public override int DefaultSignatureKeyDerivationLength => 192;

	public override int DefaultSymmetricKeyLength => 256;

	internal override XmlDictionaryString DefaultCanonicalizationAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.ExclusiveC14n;

	internal override XmlDictionaryString DefaultDigestAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.Sha1Digest;

	internal override XmlDictionaryString DefaultEncryptionAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.Aes256Encryption;

	internal override XmlDictionaryString DefaultSymmetricKeyWrapAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.Aes256KeyWrap;

	internal override XmlDictionaryString DefaultAsymmetricKeyWrapAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.RsaOaepKeyWrap;

	internal override XmlDictionaryString DefaultSymmetricSignatureAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.HmacSha1Signature;

	internal override XmlDictionaryString DefaultAsymmetricSignatureAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.RsaSha1Signature;

	public override bool IsSymmetricKeyLengthSupported(int length)
	{
		return length == 256;
	}

	public override bool IsAsymmetricKeyLengthSupported(int length)
	{
		if (length >= 1024)
		{
			return length <= 4096;
		}
		return false;
	}

	public override string ToString()
	{
		return "Basic256";
	}
}
