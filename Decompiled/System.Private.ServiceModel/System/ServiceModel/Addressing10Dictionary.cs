using System.Xml;

namespace System.ServiceModel;

internal class Addressing10Dictionary
{
	public XmlDictionaryString Namespace;

	public XmlDictionaryString Anonymous;

	public XmlDictionaryString FaultAction;

	public XmlDictionaryString ReplyRelationship;

	public XmlDictionaryString NoneAddress;

	public XmlDictionaryString Metadata;

	public Addressing10Dictionary(ServiceModelDictionary dictionary)
	{
		Namespace = dictionary.CreateString("http://www.w3.org/2005/08/addressing", 3);
		Anonymous = dictionary.CreateString("http://www.w3.org/2005/08/addressing/anonymous", 10);
		FaultAction = dictionary.CreateString("http://www.w3.org/2005/08/addressing/fault", 99);
		ReplyRelationship = dictionary.CreateString("http://www.w3.org/2005/08/addressing/reply", 102);
		NoneAddress = dictionary.CreateString("http://www.w3.org/2005/08/addressing/none", 103);
		Metadata = dictionary.CreateString("Metadata", 104);
	}
}
