using System.Xml;

namespace System.ServiceModel;

internal class Wsrm11Dictionary
{
	public XmlDictionaryString AckRequestedAction;

	public XmlDictionaryString CloseSequence;

	public XmlDictionaryString CloseSequenceAction;

	public XmlDictionaryString CloseSequenceResponse;

	public XmlDictionaryString CloseSequenceResponseAction;

	public XmlDictionaryString CreateSequenceAction;

	public XmlDictionaryString CreateSequenceResponseAction;

	public XmlDictionaryString DiscardFollowingFirstGap;

	public XmlDictionaryString Endpoint;

	public XmlDictionaryString FaultAction;

	public XmlDictionaryString Final;

	public XmlDictionaryString IncompleteSequenceBehavior;

	public XmlDictionaryString LastMsgNumber;

	public XmlDictionaryString MaxMessageNumber;

	public XmlDictionaryString Namespace;

	public XmlDictionaryString NoDiscard;

	public XmlDictionaryString None;

	public XmlDictionaryString SequenceAcknowledgementAction;

	public XmlDictionaryString SequenceClosed;

	public XmlDictionaryString TerminateSequenceAction;

	public XmlDictionaryString TerminateSequenceResponse;

	public XmlDictionaryString TerminateSequenceResponseAction;

	public XmlDictionaryString UsesSequenceSSL;

	public XmlDictionaryString UsesSequenceSTR;

	public XmlDictionaryString WsrmRequired;

	public Wsrm11Dictionary(XmlDictionary dictionary)
	{
		AckRequestedAction = dictionary.Add("http://docs.oasis-open.org/ws-rx/wsrm/200702/AckRequested");
		CloseSequence = dictionary.Add("CloseSequence");
		CloseSequenceAction = dictionary.Add("http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequence");
		CloseSequenceResponse = dictionary.Add("CloseSequenceResponse");
		CloseSequenceResponseAction = dictionary.Add("http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequenceResponse");
		CreateSequenceAction = dictionary.Add("http://docs.oasis-open.org/ws-rx/wsrm/200702/CreateSequence");
		CreateSequenceResponseAction = dictionary.Add("http://docs.oasis-open.org/ws-rx/wsrm/200702/CreateSequenceResponse");
		DiscardFollowingFirstGap = dictionary.Add("DiscardFollowingFirstGap");
		Endpoint = dictionary.Add("Endpoint");
		FaultAction = dictionary.Add("http://docs.oasis-open.org/ws-rx/wsrm/200702/fault");
		Final = dictionary.Add("Final");
		IncompleteSequenceBehavior = dictionary.Add("IncompleteSequenceBehavior");
		LastMsgNumber = dictionary.Add("LastMsgNumber");
		MaxMessageNumber = dictionary.Add("MaxMessageNumber");
		Namespace = dictionary.Add("http://docs.oasis-open.org/ws-rx/wsrm/200702");
		NoDiscard = dictionary.Add("NoDiscard");
		None = dictionary.Add("None");
		SequenceAcknowledgementAction = dictionary.Add("http://docs.oasis-open.org/ws-rx/wsrm/200702/SequenceAcknowledgement");
		SequenceClosed = dictionary.Add("SequenceClosed");
		TerminateSequenceAction = dictionary.Add("http://docs.oasis-open.org/ws-rx/wsrm/200702/TerminateSequence");
		TerminateSequenceResponse = dictionary.Add("TerminateSequenceResponse");
		TerminateSequenceResponseAction = dictionary.Add("http://docs.oasis-open.org/ws-rx/wsrm/200702/TerminateSequenceResponse");
		UsesSequenceSSL = dictionary.Add("UsesSequenceSSL");
		UsesSequenceSTR = dictionary.Add("UsesSequenceSTR");
		WsrmRequired = dictionary.Add("WsrmRequired");
	}
}
