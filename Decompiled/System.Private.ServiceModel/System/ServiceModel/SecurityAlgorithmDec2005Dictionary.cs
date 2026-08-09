using System.Collections.Generic;
using System.Xml;

namespace System.ServiceModel;

internal class SecurityAlgorithmDec2005Dictionary
{
	public XmlDictionaryString Psha1KeyDerivationDec2005;

	public List<XmlDictionaryString> SecurityAlgorithmDictionaryStrings = new List<XmlDictionaryString>();

	public SecurityAlgorithmDec2005Dictionary(XmlDictionary dictionary)
	{
		Psha1KeyDerivationDec2005 = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk/p_sha1");
	}

	public void PopulateSecurityAlgorithmDictionaryString()
	{
		SecurityAlgorithmDictionaryStrings.Add(DXD.SecurityAlgorithmDec2005Dictionary.Psha1KeyDerivationDec2005);
	}
}
