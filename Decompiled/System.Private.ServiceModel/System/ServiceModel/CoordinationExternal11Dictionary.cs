using System.Xml;

namespace System.ServiceModel;

internal class CoordinationExternal11Dictionary
{
	public XmlDictionaryString Namespace;

	public XmlDictionaryString CreateCoordinationContextAction;

	public XmlDictionaryString CreateCoordinationContextResponseAction;

	public XmlDictionaryString RegisterAction;

	public XmlDictionaryString RegisterResponseAction;

	public XmlDictionaryString FaultAction;

	public XmlDictionaryString CannotCreateContext;

	public XmlDictionaryString CannotRegisterParticipant;

	public CoordinationExternal11Dictionary(XmlDictionary dictionary)
	{
		Namespace = dictionary.Add("http://docs.oasis-open.org/ws-tx/wscoor/2006/06");
		CreateCoordinationContextAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wscoor/2006/06/CreateCoordinationContext");
		CreateCoordinationContextResponseAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wscoor/2006/06/CreateCoordinationContextResponse");
		RegisterAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wscoor/2006/06/Register");
		RegisterResponseAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wscoor/2006/06/RegisterResponse");
		FaultAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wscoor/2006/06/fault");
		CannotCreateContext = dictionary.Add("CannotCreateContext");
		CannotRegisterParticipant = dictionary.Add("CannotRegisterParticipant");
	}
}
