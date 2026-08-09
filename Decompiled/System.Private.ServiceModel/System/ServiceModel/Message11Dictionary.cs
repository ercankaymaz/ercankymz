using System.Xml;

namespace System.ServiceModel;

internal class Message11Dictionary
{
	public XmlDictionaryString Namespace;

	public XmlDictionaryString Actor;

	public XmlDictionaryString FaultCode;

	public XmlDictionaryString FaultString;

	public XmlDictionaryString FaultActor;

	public XmlDictionaryString FaultDetail;

	public XmlDictionaryString FaultNamespace;

	public Message11Dictionary(ServiceModelDictionary dictionary)
	{
		Namespace = dictionary.CreateString("http://schemas.xmlsoap.org/soap/envelope/", 481);
		Actor = dictionary.CreateString("actor", 482);
		FaultCode = dictionary.CreateString("faultcode", 483);
		FaultString = dictionary.CreateString("faultstring", 484);
		FaultActor = dictionary.CreateString("faultactor", 485);
		FaultDetail = dictionary.CreateString("detail", 486);
		FaultNamespace = dictionary.CreateString("", 81);
	}
}
