using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class SecurityAlgorithmDec2005Dictionary
{
	public XmlDictionaryString Psha1KeyDerivationDec2005;

	public SecurityAlgorithmDec2005Dictionary(IdentityModelDictionary dictionary)
	{
		Psha1KeyDerivationDec2005 = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk/p_sha1", 267);
	}

	public SecurityAlgorithmDec2005Dictionary(IXmlDictionary dictionary)
	{
		Psha1KeyDerivationDec2005 = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk/p_sha1");
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
