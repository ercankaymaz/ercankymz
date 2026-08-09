using System.Xml;

namespace System.ServiceModel;

internal class Addressing200408Dictionary
{
	public XmlDictionaryString Namespace;

	public XmlDictionaryString Anonymous;

	public XmlDictionaryString FaultAction;

	public Addressing200408Dictionary(ServiceModelDictionary dictionary)
	{
		Namespace = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2004/08/addressing", 105);
		Anonymous = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2004/08/addressing/role/anonymous", 106);
		FaultAction = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2004/08/addressing/fault", 107);
	}
}
