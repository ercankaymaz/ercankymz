using System.Xml;

namespace System.ServiceModel;

internal class SecurityAlgorithmDictionary
{
	public XmlDictionaryString Aes128Encryption;

	public XmlDictionaryString Aes128KeyWrap;

	public XmlDictionaryString Aes192Encryption;

	public XmlDictionaryString Aes192KeyWrap;

	public XmlDictionaryString Aes256Encryption;

	public XmlDictionaryString Aes256KeyWrap;

	public XmlDictionaryString DesEncryption;

	public XmlDictionaryString DsaSha1Signature;

	public XmlDictionaryString ExclusiveC14n;

	public XmlDictionaryString ExclusiveC14nWithComments;

	public XmlDictionaryString HmacSha1Signature;

	public XmlDictionaryString HmacSha256Signature;

	public XmlDictionaryString Psha1KeyDerivation;

	public XmlDictionaryString Ripemd160Digest;

	public XmlDictionaryString RsaOaepKeyWrap;

	public XmlDictionaryString RsaSha1Signature;

	public XmlDictionaryString RsaSha256Signature;

	public XmlDictionaryString RsaV15KeyWrap;

	public XmlDictionaryString Sha1Digest;

	public XmlDictionaryString Sha256Digest;

	public XmlDictionaryString Sha512Digest;

	public XmlDictionaryString TripleDesEncryption;

	public XmlDictionaryString TripleDesKeyWrap;

	public XmlDictionaryString TlsSspiKeyWrap;

	public XmlDictionaryString WindowsSspiKeyWrap;

	public SecurityAlgorithmDictionary(ServiceModelDictionary dictionary)
	{
		Aes128Encryption = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#aes128-cbc", 138);
		Aes128KeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#kw-aes128", 139);
		Aes192Encryption = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#aes192-cbc", 140);
		Aes192KeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#kw-aes192", 141);
		Aes256Encryption = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#aes256-cbc", 142);
		Aes256KeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#kw-aes256", 143);
		DesEncryption = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#des-cbc", 144);
		DsaSha1Signature = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#dsa-sha1", 145);
		ExclusiveC14n = dictionary.CreateString("http://www.w3.org/2001/10/xml-exc-c14n#", 111);
		ExclusiveC14nWithComments = dictionary.CreateString("http://www.w3.org/2001/10/xml-exc-c14n#WithComments", 146);
		HmacSha1Signature = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#hmac-sha1", 147);
		HmacSha256Signature = dictionary.CreateString("http://www.w3.org/2001/04/xmldsig-more#hmac-sha256", 148);
		Psha1KeyDerivation = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/sc/dk/p_sha1", 149);
		Ripemd160Digest = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#ripemd160", 150);
		RsaOaepKeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p", 151);
		RsaSha1Signature = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#rsa-sha1", 152);
		RsaSha256Signature = dictionary.CreateString("http://www.w3.org/2001/04/xmldsig-more#rsa-sha256", 153);
		RsaV15KeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#rsa-1_5", 154);
		Sha1Digest = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#sha1", 155);
		Sha256Digest = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#sha256", 156);
		Sha512Digest = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#sha512", 157);
		TripleDesEncryption = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#tripledes-cbc", 158);
		TripleDesKeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#kw-tripledes", 159);
		TlsSspiKeyWrap = dictionary.CreateString("http://schemas.xmlsoap.org/2005/02/trust/tlsnego#TLS_Wrap", 160);
		WindowsSspiKeyWrap = dictionary.CreateString("http://schemas.xmlsoap.org/2005/02/trust/spnego#GSS_Wrap", 161);
	}
}
