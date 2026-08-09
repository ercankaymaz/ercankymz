using System.Xml;

namespace System.ServiceModel;

internal class UtilityDictionary
{
	public XmlDictionaryString IdAttribute;

	public XmlDictionaryString Namespace;

	public XmlDictionaryString Timestamp;

	public XmlDictionaryString CreatedElement;

	public XmlDictionaryString ExpiresElement;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString UniqueEndpointHeaderName;

	public XmlDictionaryString UniqueEndpointHeaderNamespace;

	public UtilityDictionary(ServiceModelDictionary dictionary)
	{
		IdAttribute = dictionary.CreateString("Id", 14);
		Namespace = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", 51);
		Timestamp = dictionary.CreateString("Timestamp", 53);
		CreatedElement = dictionary.CreateString("Created", 54);
		ExpiresElement = dictionary.CreateString("Expires", 55);
		Prefix = dictionary.CreateString("u", 305);
		UniqueEndpointHeaderName = dictionary.CreateString("ChannelInstance", 306);
		UniqueEndpointHeaderNamespace = dictionary.CreateString("http://schemas.microsoft.com/ws/2005/02/duplex", 307);
	}
}
