using System.Xml;

namespace System.ServiceModel;

internal class AddressingDictionary
{
	public XmlDictionaryString Action;

	public XmlDictionaryString To;

	public XmlDictionaryString RelatesTo;

	public XmlDictionaryString MessageId;

	public XmlDictionaryString Address;

	public XmlDictionaryString ReplyTo;

	public XmlDictionaryString Empty;

	public XmlDictionaryString From;

	public XmlDictionaryString FaultTo;

	public XmlDictionaryString EndpointReference;

	public XmlDictionaryString PortType;

	public XmlDictionaryString ServiceName;

	public XmlDictionaryString PortName;

	public XmlDictionaryString ReferenceProperties;

	public XmlDictionaryString RelationshipType;

	public XmlDictionaryString Reply;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString IdentityExtensionNamespace;

	public XmlDictionaryString Identity;

	public XmlDictionaryString Spn;

	public XmlDictionaryString Upn;

	public XmlDictionaryString Rsa;

	public XmlDictionaryString Dns;

	public XmlDictionaryString X509v3Certificate;

	public XmlDictionaryString ReferenceParameters;

	public XmlDictionaryString IsReferenceParameter;

	public AddressingDictionary(ServiceModelDictionary dictionary)
	{
		Action = dictionary.CreateString("Action", 5);
		To = dictionary.CreateString("To", 6);
		RelatesTo = dictionary.CreateString("RelatesTo", 9);
		MessageId = dictionary.CreateString("MessageID", 13);
		Address = dictionary.CreateString("Address", 21);
		ReplyTo = dictionary.CreateString("ReplyTo", 22);
		Empty = dictionary.CreateString("", 81);
		From = dictionary.CreateString("From", 82);
		FaultTo = dictionary.CreateString("FaultTo", 83);
		EndpointReference = dictionary.CreateString("EndpointReference", 84);
		PortType = dictionary.CreateString("PortType", 85);
		ServiceName = dictionary.CreateString("ServiceName", 86);
		PortName = dictionary.CreateString("PortName", 87);
		ReferenceProperties = dictionary.CreateString("ReferenceProperties", 88);
		RelationshipType = dictionary.CreateString("RelationshipType", 89);
		Reply = dictionary.CreateString("Reply", 90);
		Prefix = dictionary.CreateString("a", 91);
		IdentityExtensionNamespace = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2006/02/addressingidentity", 92);
		Identity = dictionary.CreateString("Identity", 93);
		Spn = dictionary.CreateString("Spn", 94);
		Upn = dictionary.CreateString("Upn", 95);
		Rsa = dictionary.CreateString("Rsa", 96);
		Dns = dictionary.CreateString("Dns", 97);
		X509v3Certificate = dictionary.CreateString("X509v3Certificate", 98);
		ReferenceParameters = dictionary.CreateString("ReferenceParameters", 100);
		IsReferenceParameter = dictionary.CreateString("IsReferenceParameter", 101);
	}
}
