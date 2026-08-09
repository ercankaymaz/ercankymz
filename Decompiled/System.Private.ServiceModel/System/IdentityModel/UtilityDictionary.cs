using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class UtilityDictionary
{
	public XmlDictionaryString IdAttribute;

	public XmlDictionaryString Namespace;

	public XmlDictionaryString Timestamp;

	public XmlDictionaryString CreatedElement;

	public XmlDictionaryString ExpiresElement;

	public XmlDictionaryString Prefix;

	public UtilityDictionary(IdentityModelDictionary dictionary)
	{
		IdAttribute = dictionary.CreateString("Id", 3);
		Namespace = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", 16);
		Timestamp = dictionary.CreateString("Timestamp", 17);
		CreatedElement = dictionary.CreateString("Created", 18);
		ExpiresElement = dictionary.CreateString("Expires", 19);
		Prefix = dictionary.CreateString("u", 81);
	}

	public UtilityDictionary(IXmlDictionary dictionary)
	{
		IdAttribute = LookupDictionaryString(dictionary, "Id");
		Namespace = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
		Timestamp = LookupDictionaryString(dictionary, "Timestamp");
		CreatedElement = LookupDictionaryString(dictionary, "Created");
		ExpiresElement = LookupDictionaryString(dictionary, "Expires");
		Prefix = LookupDictionaryString(dictionary, "u");
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
