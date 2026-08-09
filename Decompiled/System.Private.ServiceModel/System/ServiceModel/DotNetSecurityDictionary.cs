using System.Xml;

namespace System.ServiceModel;

internal class DotNetSecurityDictionary
{
	public XmlDictionaryString Namespace;

	public XmlDictionaryString Prefix;

	public DotNetSecurityDictionary(ServiceModelDictionary dictionary)
	{
		Namespace = dictionary.CreateString("http://schemas.microsoft.com/ws/2006/05/security", 162);
		Prefix = dictionary.CreateString("dnse", 163);
	}
}
