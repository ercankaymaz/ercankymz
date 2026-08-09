using System.Xml;

namespace System.ServiceModel.Security;

public class Basic256Sha256SecurityAlgorithmSuite : Basic256SecurityAlgorithmSuite
{
	internal override XmlDictionaryString DefaultDigestAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.Sha256Digest;

	internal override XmlDictionaryString DefaultSymmetricSignatureAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.HmacSha256Signature;

	internal override XmlDictionaryString DefaultAsymmetricSignatureAlgorithmDictionaryString => XD.SecurityAlgorithmDictionary.RsaSha256Signature;

	public override string ToString()
	{
		return "Basic256Sha256";
	}
}
