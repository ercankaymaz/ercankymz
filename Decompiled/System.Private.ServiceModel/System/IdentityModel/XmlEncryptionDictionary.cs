using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class XmlEncryptionDictionary
{
	public XmlDictionaryString Namespace;

	public XmlDictionaryString DataReference;

	public XmlDictionaryString EncryptedData;

	public XmlDictionaryString EncryptionMethod;

	public XmlDictionaryString CipherData;

	public XmlDictionaryString CipherValue;

	public XmlDictionaryString ReferenceList;

	public XmlDictionaryString Encoding;

	public XmlDictionaryString MimeType;

	public XmlDictionaryString Type;

	public XmlDictionaryString Id;

	public XmlDictionaryString CarriedKeyName;

	public XmlDictionaryString Recipient;

	public XmlDictionaryString EncryptedKey;

	public XmlDictionaryString URI;

	public XmlDictionaryString KeyReference;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString ElementType;

	public XmlDictionaryString ContentType;

	public XmlDictionaryString AlgorithmAttribute;

	public XmlEncryptionDictionary(IdentityModelDictionary dictionary)
	{
		Namespace = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#", 156);
		DataReference = dictionary.CreateString("DataReference", 157);
		EncryptedData = dictionary.CreateString("EncryptedData", 158);
		EncryptionMethod = dictionary.CreateString("EncryptionMethod", 159);
		CipherData = dictionary.CreateString("CipherData", 160);
		CipherValue = dictionary.CreateString("CipherValue", 161);
		ReferenceList = dictionary.CreateString("ReferenceList", 162);
		Encoding = dictionary.CreateString("Encoding", 163);
		MimeType = dictionary.CreateString("MimeType", 164);
		Type = dictionary.CreateString("Type", 83);
		Id = dictionary.CreateString("Id", 3);
		CarriedKeyName = dictionary.CreateString("CarriedKeyName", 165);
		Recipient = dictionary.CreateString("Recipient", 166);
		EncryptedKey = dictionary.CreateString("EncryptedKey", 167);
		URI = dictionary.CreateString("URI", 1);
		KeyReference = dictionary.CreateString("KeyReference", 168);
		Prefix = dictionary.CreateString("e", 169);
		ElementType = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#Element", 170);
		ContentType = dictionary.CreateString("http://www.w3.org/2001/04/xmlenc#Content", 171);
		AlgorithmAttribute = dictionary.CreateString("Algorithm", 0);
	}

	public XmlEncryptionDictionary(IXmlDictionary dictionary)
	{
		Namespace = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#");
		DataReference = LookupDictionaryString(dictionary, "DataReference");
		EncryptedData = LookupDictionaryString(dictionary, "EncryptedData");
		EncryptionMethod = LookupDictionaryString(dictionary, "EncryptionMethod");
		CipherData = LookupDictionaryString(dictionary, "CipherData");
		CipherValue = LookupDictionaryString(dictionary, "CipherValue");
		ReferenceList = LookupDictionaryString(dictionary, "ReferenceList");
		Encoding = LookupDictionaryString(dictionary, "Encoding");
		MimeType = LookupDictionaryString(dictionary, "MimeType");
		Type = LookupDictionaryString(dictionary, "Type");
		Id = LookupDictionaryString(dictionary, "Id");
		CarriedKeyName = LookupDictionaryString(dictionary, "CarriedKeyName");
		Recipient = LookupDictionaryString(dictionary, "Recipient");
		EncryptedKey = LookupDictionaryString(dictionary, "EncryptedKey");
		URI = LookupDictionaryString(dictionary, "URI");
		KeyReference = LookupDictionaryString(dictionary, "KeyReference");
		Prefix = LookupDictionaryString(dictionary, "e");
		ElementType = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#Element");
		ContentType = LookupDictionaryString(dictionary, "http://www.w3.org/2001/04/xmlenc#Content");
		AlgorithmAttribute = LookupDictionaryString(dictionary, "Algorithm");
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
