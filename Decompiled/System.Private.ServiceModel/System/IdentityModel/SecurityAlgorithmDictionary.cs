using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

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

	public SecurityAlgorithmDictionary(IdentityModelDictionary dictionary)
	{
		Aes128Encryption = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#aes128-cbc", 95);
		Aes128KeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#kw-aes128", 96);
		Aes192Encryption = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#aes192-cbc", 97);
		Aes192KeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#kw-aes192", 98);
		Aes256Encryption = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#aes256-cbc", 99);
		Aes256KeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#kw-aes256", 100);
		DesEncryption = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#des-cbc", 101);
		DsaSha1Signature = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#dsa-sha1", 102);
		ExclusiveC14n = dictionary.CreateString("http://www.w3.org/2001/10/xml-exc-c14n#", 20);
		ExclusiveC14nWithComments = dictionary.CreateString("http://www.w3.org/2001/10/xml-exc-c14n#WithComments", 103);
		HmacSha1Signature = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#hmac-sha1", 104);
		HmacSha256Signature = dictionary.CreateString("http://www.w3.org/2001/04/xmldsig-more#hmac-sha256", 105);
		Psha1KeyDerivation = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/sc/dk/p_sha1", 106);
		Ripemd160Digest = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#ripemd160", 107);
		RsaOaepKeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p", 108);
		RsaSha1Signature = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#rsa-sha1", 109);
		RsaSha256Signature = dictionary.CreateString("http://www.w3.org/2001/04/xmldsig-more#rsa-sha256", 110);
		RsaV15KeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#rsa-1_5", 111);
		Sha1Digest = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#sha1", 112);
		Sha256Digest = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#sha256", 113);
		Sha512Digest = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#sha512", 114);
		TripleDesEncryption = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#tripledes-cbc", 115);
		TripleDesKeyWrap = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#kw-tripledes", 116);
		TlsSspiKeyWrap = dictionary.CreateString("http://schemas.xmlsoap.org/2005/02/trust/tlsnego#TLS_Wrap", 117);
		WindowsSspiKeyWrap = dictionary.CreateString("http://schemas.xmlsoap.org/2005/02/trust/spnego#GSS_Wrap", 118);
	}

	public SecurityAlgorithmDictionary(IXmlDictionary dictionary)
	{
		Aes128Encryption = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#aes128-cbc");
		Aes128KeyWrap = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#kw-aes128");
		Aes192Encryption = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#aes192-cbc");
		Aes192KeyWrap = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#kw-aes192");
		Aes256Encryption = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#aes256-cbc");
		Aes256KeyWrap = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#kw-aes256");
		DesEncryption = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#des-cbc");
		DsaSha1Signature = LookupDictionaryString(dictionary, "http://www.w3.org/2000/09/xmldsig#dsa-sha1");
		ExclusiveC14n = LookupDictionaryString(dictionary, "http://www.w3.org/2001/10/xml-exc-c14n#");
		ExclusiveC14nWithComments = LookupDictionaryString(dictionary, "http://www.w3.org/2001/10/xml-exc-c14n#WithComments");
		HmacSha1Signature = LookupDictionaryString(dictionary, "http://www.w3.org/2000/09/xmldsig#hmac-sha1");
		HmacSha256Signature = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256");
		Psha1KeyDerivation = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/sc/dk/p_sha1");
		Ripemd160Digest = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#ripemd160");
		RsaOaepKeyWrap = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p");
		RsaSha1Signature = LookupDictionaryString(dictionary, "http://www.w3.org/2000/09/xmldsig#rsa-sha1");
		RsaSha256Signature = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
		RsaV15KeyWrap = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#rsa-1_5");
		Sha1Digest = LookupDictionaryString(dictionary, "http://www.w3.org/2000/09/xmldsig#sha1");
		Sha256Digest = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#sha256");
		Sha512Digest = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#sha512");
		TripleDesEncryption = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#tripledes-cbc");
		TripleDesKeyWrap = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#kw-tripledes");
		TlsSspiKeyWrap = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/2005/02/trust/tlsnego#TLS_Wrap");
		WindowsSspiKeyWrap = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/2005/02/trust/spnego#GSS_Wrap");
	}

	private XmlDictionaryString LookupDictionaryString(IXmlDictionary dictionary, string value)
	{
		if (!dictionary.TryLookup(value, out XmlDictionaryString result))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.XDCannotFindValueInDictionaryString, value));
		}
		return result;
	}
}
