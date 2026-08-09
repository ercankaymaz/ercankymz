using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

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

	public XmlSignatureDictionary(IdentityModelDictionary dictionary)
	{
		Algorithm = dictionary.CreateString("Algorithm", 0);
		URI = dictionary.CreateString("URI", 1);
		Reference = dictionary.CreateString("Reference", 2);
		Transforms = dictionary.CreateString("Transforms", 4);
		Transform = dictionary.CreateString("Transform", 5);
		DigestMethod = dictionary.CreateString("DigestMethod", 6);
		DigestValue = dictionary.CreateString("DigestValue", 7);
		Namespace = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#", 8);
		EnvelopedSignature = dictionary.CreateString("http://www.w3.org/2000/09/xmldsig#enveloped-signature", 9);
		KeyInfo = dictionary.CreateString("KeyInfo", 10);
		Signature = dictionary.CreateString("Signature", 11);
		SignedInfo = dictionary.CreateString("SignedInfo", 12);
		CanonicalizationMethod = dictionary.CreateString("CanonicalizationMethod", 13);
		SignatureMethod = dictionary.CreateString("SignatureMethod", 14);
		SignatureValue = dictionary.CreateString("SignatureValue", 15);
		KeyName = dictionary.CreateString("KeyName", 82);
		Type = dictionary.CreateString("Type", 83);
		MgmtData = dictionary.CreateString("MgmtData", 84);
		Prefix = dictionary.CreateString("", 85);
		KeyValue = dictionary.CreateString("KeyValue", 86);
		RsaKeyValue = dictionary.CreateString("RSAKeyValue", 87);
		Modulus = dictionary.CreateString("Modulus", 88);
		Exponent = dictionary.CreateString("Exponent", 89);
		X509Data = dictionary.CreateString("X509Data", 90);
		X509IssuerSerial = dictionary.CreateString("X509IssuerSerial", 91);
		X509IssuerName = dictionary.CreateString("X509IssuerName", 92);
		X509SerialNumber = dictionary.CreateString("X509SerialNumber", 93);
		X509Certificate = dictionary.CreateString("X509Certificate", 94);
	}

	public XmlSignatureDictionary(IXmlDictionary dictionary)
	{
		Algorithm = LookupDictionaryString(dictionary, "Algorithm");
		URI = LookupDictionaryString(dictionary, "URI");
		Reference = LookupDictionaryString(dictionary, "Reference");
		Transforms = LookupDictionaryString(dictionary, "Transforms");
		Transform = LookupDictionaryString(dictionary, "Transform");
		DigestMethod = LookupDictionaryString(dictionary, "DigestMethod");
		DigestValue = LookupDictionaryString(dictionary, "DigestValue");
		Namespace = LookupDictionaryString(dictionary, "http://www.w3.org/2000/09/xmldsig#");
		EnvelopedSignature = LookupDictionaryString(dictionary, "http://www.w3.org/2000/09/xmldsig#enveloped-signature");
		KeyInfo = LookupDictionaryString(dictionary, "KeyInfo");
		Signature = LookupDictionaryString(dictionary, "Signature");
		SignedInfo = LookupDictionaryString(dictionary, "SignedInfo");
		CanonicalizationMethod = LookupDictionaryString(dictionary, "CanonicalizationMethod");
		SignatureMethod = LookupDictionaryString(dictionary, "SignatureMethod");
		SignatureValue = LookupDictionaryString(dictionary, "SignatureValue");
		KeyName = LookupDictionaryString(dictionary, "KeyName");
		Type = LookupDictionaryString(dictionary, "Type");
		MgmtData = LookupDictionaryString(dictionary, "MgmtData");
		Prefix = LookupDictionaryString(dictionary, "");
		KeyValue = LookupDictionaryString(dictionary, "KeyValue");
		RsaKeyValue = LookupDictionaryString(dictionary, "RSAKeyValue");
		Modulus = LookupDictionaryString(dictionary, "Modulus");
		Exponent = LookupDictionaryString(dictionary, "Exponent");
		X509Data = LookupDictionaryString(dictionary, "X509Data");
		X509IssuerSerial = LookupDictionaryString(dictionary, "X509IssuerSerial");
		X509IssuerName = LookupDictionaryString(dictionary, "X509IssuerName");
		X509SerialNumber = LookupDictionaryString(dictionary, "X509SerialNumber");
		X509Certificate = LookupDictionaryString(dictionary, "X509Certificate");
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
