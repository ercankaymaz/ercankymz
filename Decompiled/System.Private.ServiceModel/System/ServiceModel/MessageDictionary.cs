using System.Xml;

namespace System.ServiceModel;

internal class MessageDictionary
{
	public XmlDictionaryString MustUnderstand;

	public XmlDictionaryString Envelope;

	public XmlDictionaryString Header;

	public XmlDictionaryString Body;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString Fault;

	public XmlDictionaryString MustUnderstandFault;

	public XmlDictionaryString Namespace;

	public MessageDictionary(ServiceModelDictionary dictionary)
	{
		MustUnderstand = dictionary.CreateString("mustUnderstand", 0);
		Envelope = dictionary.CreateString("Envelope", 1);
		Header = dictionary.CreateString("Header", 4);
		Body = dictionary.CreateString("Body", 7);
		Prefix = dictionary.CreateString("s", 66);
		Fault = dictionary.CreateString("Fault", 67);
		MustUnderstandFault = dictionary.CreateString("MustUnderstand", 68);
		Namespace = dictionary.CreateString("http://schemas.microsoft.com/ws/2005/05/envelope/none", 440);
	}
}
