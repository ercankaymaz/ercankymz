using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class ExclusiveC14NDictionary
{
	public XmlDictionaryString Namespace;

	public XmlDictionaryString PrefixList;

	public XmlDictionaryString InclusiveNamespaces;

	public XmlDictionaryString Prefix;

	public ExclusiveC14NDictionary(IdentityModelDictionary dictionary)
	{
		Namespace = dictionary.CreateString("http://www.w3.org/2001/10/xml-exc-c14n#", 20);
		PrefixList = dictionary.CreateString("PrefixList", 21);
		InclusiveNamespaces = dictionary.CreateString("InclusiveNamespaces", 22);
		Prefix = dictionary.CreateString("ec", 23);
	}

	public ExclusiveC14NDictionary(IXmlDictionary dictionary)
	{
		Namespace = LookupDictionaryString(dictionary, "http://www.w3.org/2001/10/xml-exc-c14n#");
		PrefixList = LookupDictionaryString(dictionary, "PrefixList");
		InclusiveNamespaces = LookupDictionaryString(dictionary, "InclusiveNamespaces");
		Prefix = LookupDictionaryString(dictionary, "ec");
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
