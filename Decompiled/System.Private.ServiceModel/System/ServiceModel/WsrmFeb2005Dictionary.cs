using System.Xml;

namespace System.ServiceModel;

internal class WsrmFeb2005Dictionary
{
	public XmlDictionaryString Identifier;

	public XmlDictionaryString Namespace;

	public XmlDictionaryString SequenceAcknowledgement;

	public XmlDictionaryString AcknowledgementRange;

	public XmlDictionaryString Upper;

	public XmlDictionaryString Lower;

	public XmlDictionaryString BufferRemaining;

	public XmlDictionaryString NETNamespace;

	public XmlDictionaryString SequenceAcknowledgementAction;

	public XmlDictionaryString Sequence;

	public XmlDictionaryString MessageNumber;

	public XmlDictionaryString AckRequested;

	public XmlDictionaryString AckRequestedAction;

	public XmlDictionaryString AcksTo;

	public XmlDictionaryString Accept;

	public XmlDictionaryString CreateSequence;

	public XmlDictionaryString CreateSequenceAction;

	public XmlDictionaryString CreateSequenceRefused;

	public XmlDictionaryString CreateSequenceResponse;

	public XmlDictionaryString CreateSequenceResponseAction;

	public XmlDictionaryString Expires;

	public XmlDictionaryString FaultCode;

	public XmlDictionaryString InvalidAcknowledgement;

	public XmlDictionaryString LastMessage;

	public XmlDictionaryString LastMessageAction;

	public XmlDictionaryString LastMessageNumberExceeded;

	public XmlDictionaryString MessageNumberRollover;

	public XmlDictionaryString Nack;

	public XmlDictionaryString NETPrefix;

	public XmlDictionaryString Offer;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString SequenceFault;

	public XmlDictionaryString SequenceTerminated;

	public XmlDictionaryString TerminateSequence;

	public XmlDictionaryString TerminateSequenceAction;

	public XmlDictionaryString UnknownSequence;

	public XmlDictionaryString ConnectionLimitReached;

	public WsrmFeb2005Dictionary(ServiceModelDictionary dictionary)
	{
		Identifier = dictionary.CreateString("Identifier", 15);
		Namespace = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/rm", 16);
		SequenceAcknowledgement = dictionary.CreateString("SequenceAcknowledgement", 23);
		AcknowledgementRange = dictionary.CreateString("AcknowledgementRange", 24);
		Upper = dictionary.CreateString("Upper", 25);
		Lower = dictionary.CreateString("Lower", 26);
		BufferRemaining = dictionary.CreateString("BufferRemaining", 27);
		NETNamespace = dictionary.CreateString("http://schemas.microsoft.com/ws/2006/05/rm", 28);
		SequenceAcknowledgementAction = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/rm/SequenceAcknowledgement", 29);
		Sequence = dictionary.CreateString("Sequence", 31);
		MessageNumber = dictionary.CreateString("MessageNumber", 32);
		AckRequested = dictionary.CreateString("AckRequested", 328);
		AckRequestedAction = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/rm/AckRequested", 329);
		AcksTo = dictionary.CreateString("AcksTo", 330);
		Accept = dictionary.CreateString("Accept", 331);
		CreateSequence = dictionary.CreateString("CreateSequence", 332);
		CreateSequenceAction = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/rm/CreateSequence", 333);
		CreateSequenceRefused = dictionary.CreateString("CreateSequenceRefused", 334);
		CreateSequenceResponse = dictionary.CreateString("CreateSequenceResponse", 335);
		CreateSequenceResponseAction = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/rm/CreateSequenceResponse", 336);
		Expires = dictionary.CreateString("Expires", 55);
		FaultCode = dictionary.CreateString("FaultCode", 337);
		InvalidAcknowledgement = dictionary.CreateString("InvalidAcknowledgement", 338);
		LastMessage = dictionary.CreateString("LastMessage", 339);
		LastMessageAction = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/rm/LastMessage", 340);
		LastMessageNumberExceeded = dictionary.CreateString("LastMessageNumberExceeded", 341);
		MessageNumberRollover = dictionary.CreateString("MessageNumberRollover", 342);
		Nack = dictionary.CreateString("Nack", 343);
		NETPrefix = dictionary.CreateString("netrm", 344);
		Offer = dictionary.CreateString("Offer", 345);
		Prefix = dictionary.CreateString("r", 346);
		SequenceFault = dictionary.CreateString("SequenceFault", 347);
		SequenceTerminated = dictionary.CreateString("SequenceTerminated", 348);
		TerminateSequence = dictionary.CreateString("TerminateSequence", 349);
		TerminateSequenceAction = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/rm/TerminateSequence", 350);
		UnknownSequence = dictionary.CreateString("UnknownSequence", 351);
		ConnectionLimitReached = dictionary.CreateString("ConnectionLimitReached", 480);
	}
}
