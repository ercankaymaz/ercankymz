using System.Xml;

namespace System.ServiceModel.Security;

public class TripleDesSecurityAlgorithmSuite : SecurityAlgorithmSuite
{
	public override string DefaultCanonicalizationAlgorithm => DefaultCanonicalizationAlgorithmDictionaryString.Value;

	public override string DefaultDigestAlgorithm => DefaultDigestAlgorithmDictionaryString.Value;

	public override string DefaultEncryptionAlgorithm => DefaultEncryptionAlgorithmDictionaryString.Value;

	public override int DefaultEncryptionKeyDerivationLength => 192;

	public override string DefaultSymmetricKeyWrapAlgorithm => DefaultSymmetricKeyWrapAlgorithmDictionaryString.Value;

	public override string DefaultAsymmetricKeyWrapAlgorithm => DefaultAsymmetricKeyWrapAlgorithmDictionaryString.Value;

	public override string DefaultSymmetricSignatureAlgorithm => DefaultSymmetricSignatureAlgorithmDictionaryString.Value;

	public override string DefaultAsymmetricSignatureAlgorithm => DefaultAsymmetricSignatureAlgorithmDictionaryString.Value;

	public override int DefaultSignatureKeyDerivationLength => 192;

	public override int DefaultSymmetricKeyLength => 192;

	internal override XmlDictionaryString DefaultCanonicalizationAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.ExclusiveC14n;

	internal override XmlDictionaryString DefaultDigestAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.Sha1Digest;

	internal override XmlDictionaryString DefaultEncryptionAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.TripleDesEncryption;

	internal override XmlDictionaryString DefaultSymmetricKeyWrapAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.TripleDesKeyWrap;

	internal override XmlDictionaryString DefaultAsymmetricKeyWrapAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.RsaOaepKeyWrap;

	internal override XmlDictionaryString DefaultSymmetricSignatureAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.HmacSha1Signature;

	internal override XmlDictionaryString DefaultAsymmetricSignatureAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.RsaSha1Signature;

	public override bool IsSymmetricKeyLengthSupported(int length)
	{
		if (length >= 192)
		{
			return length <= 256;
		}
		return false;
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
		return "TripleDes";
	}
}
