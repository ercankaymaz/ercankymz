using System.Xml;

namespace System.ServiceModel;

internal class XmlSignatureDictionary
{
	public XmlDictionaryString Algorithm;

	public XmlDictionaryString URI;

	public XmlDictionaryString Reference;

	public XmlDictionaryString Transforms;

	public XmlDictionaryString Transform;

	public XmlDictionaryString DigestMethod;

	public XmlDictionaryString DigestValue;

	public XmlDictionaryString Namespace;

	public XmlDictionaryString EnvelopedSignature;

	public XmlDictionaryString KeyInfo;

	public XmlDictionaryString Signature;

	public XmlDictionaryString SignedInfo;

	public XmlDictionaryString CanonicalizationMethod;

	public XmlDictionaryString SignatureMethod;

	public XmlDictionaryString SignatureValue;

	public XmlDictionaryString KeyName;

	public XmlDictionaryString Type;

	public XmlDictionaryString MgmtData;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString KeyValue;

	public XmlDictionaryString RsaKeyValue;

	public XmlDictionaryString Modulus;

	public XmlDictionaryString Exponent;

	public XmlDictionaryString X509Data;

	public XmlDictionaryString X509IssuerSerial;

	public XmlDictionaryString X509IssuerName;

	public XmlDictionaryString X509SerialNumber;

	public XmlDictionaryString X509Certificate;

	public XmlSignatureDictionary(ServiceModelDictionary dictionary)
	{
		Algorithm = dictionary.CreateString("Algorithm", 8);
		URI = dictionary.CreateString("URI", 11);
		Reference = dictionary.CreateString("Reference", 12);
		Transforms = dictionary.CreateString("Transforms", 17);
		Transform = dictionary.CreateString("Transform", 18);
		DigestMethod = dictionary.CreateString("DigestMethod", 19);
		DigestValue = dictionary.CreateString("DigestValue", 20);
		Namespace = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#", 33);
		EnvelopedSignature = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#enveloped-signature", 34);
		KeyInfo = dictionary.CreateString("KeyInfo", 35);
		Signature = dictionary.CreateString("Signature", 41);
		SignedInfo = dictionary.CreateString("SignedInfo", 42);
		CanonicalizationMethod = dictionary.CreateString("CanonicalizationMethod", 43);
		SignatureMethod = dictionary.CreateString("SignatureMethod", 44);
		SignatureValue = dictionary.CreateString("SignatureValue", 45);
		KeyName = dictionary.CreateString("KeyName", 317);
		Type = dictionary.CreateString("Type", 59);
		MgmtData = dictionary.CreateString("MgmtData", 318);
		Prefix = dictionary.CreateString("", 81);
		KeyValue = dictionary.CreateString("KeyValue", 319);
		RsaKeyValue = dictionary.CreateString("RSAKeyValue", 320);
		Modulus = dictionary.CreateString("Modulus", 321);
		Exponent = dictionary.CreateString("Exponent", 322);
		X509Data = dictionary.CreateString("X509Data", 323);
		X509IssuerSerial = dictionary.CreateString("X509IssuerSerial", 324);
		X509IssuerName = dictionary.CreateString("X509IssuerName", 325);
		X509SerialNumber = dictionary.CreateString("X509SerialNumber", 326);
		X509Certificate = dictionary.CreateString("X509Certificate", 327);
	}
}
