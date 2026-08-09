using System.Xml;

namespace System.ServiceModel;

internal class Message12Dictionary
{
	public XmlDictionaryString Namespace;

	public XmlDictionaryString Role;

	public XmlDictionaryString Relay;

	public XmlDictionaryString FaultCode;

	public XmlDictionaryString FaultReason;

	public XmlDictionaryString FaultText;

	public XmlDictionaryString FaultNode;

	public XmlDictionaryString FaultRole;

	public XmlDictionaryString FaultDetail;

	public XmlDictionaryString FaultValue;

	public XmlDictionaryString FaultSubcode;

	public XmlDictionaryString NotUnderstood;

	public XmlDictionaryString QName;

	public Message12Dictionary(ServiceModelDictionary dictionary)
	{
		Namespace = dictionary.CreateString("http://www.w3.org/2003/05/soap-envelope", 2);
		Role = dictionary.CreateString("role", 69);
		Relay = dictionary.CreateString("relay", 70);
		FaultCode = dictionary.CreateString("Code", 71);
		FaultReason = dictionary.CreateString("Reason", 72);
		FaultText = dictionary.CreateString("Text", 73);
		FaultNode = dictionary.CreateString("Node", 74);
		FaultRole = dictionary.CreateString("Role", 75);
		FaultDetail = dictionary.CreateString("Detail", 76);
		FaultValue = dictionary.CreateString("Value", 77);
		FaultSubcode = dictionary.CreateString("Subcode", 78);
		NotUnderstood = dictionary.CreateString("NotUnderstood", 79);
		QName = dictionary.CreateString("qname", 80);
	}
}
