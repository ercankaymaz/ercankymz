using System.Runtime;
using System.ServiceModel.Security;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class WsrmFeb2005Index : WsrmIndex
{
	private static MessagePartSpecification s_signedReliabilityMessageParts;

	private ActionHeader _ackRequestedActionHeader;

	private AddressingVersion _addressingVersion;

	private ActionHeader _createSequenceActionHeader;

	private ActionHeader _sequenceAcknowledgementActionHeader;

	private ActionHeader _terminateSequenceActionHeader;

	internal static MessagePartSpecification SignedReliabilityMessageParts
	{
		get
		{
			if (s_signedReliabilityMessageParts == null)
			{
				XmlQualifiedName[] headerTypes = new XmlQualifiedName[3]
				{
					new XmlQualifiedName("Sequence", "http://schemas.xmlsoap.org/ws/2005/02/rm"),
					new XmlQualifiedName("SequenceAcknowledgement", "http://schemas.xmlsoap.org/ws/2005/02/rm"),
					new XmlQualifiedName("AckRequested", "http://schemas.xmlsoap.org/ws/2005/02/rm")
				};
				MessagePartSpecification messagePartSpecification = new MessagePartSpecification(headerTypes);
				messagePartSpecification.MakeReadOnly();
				s_signedReliabilityMessageParts = messagePartSpecification;
			}
			return s_signedReliabilityMessageParts;
		}
	}

	internal WsrmFeb2005Index(AddressingVersion addressingVersion)
	{
		_addressingVersion = addressingVersion;
	}

	protected override ActionHeader GetActionHeader(string element)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		switch (element)
		{
		case "AckRequested":
			if (_ackRequestedActionHeader == null)
			{
				_ackRequestedActionHeader = ActionHeader.Create(wsrmFeb2005Dictionary.AckRequestedAction, _addressingVersion);
			}
			return _ackRequestedActionHeader;
		case "CreateSequence":
			if (_createSequenceActionHeader == null)
			{
				_createSequenceActionHeader = ActionHeader.Create(wsrmFeb2005Dictionary.CreateSequenceAction, _addressingVersion);
			}
			return _createSequenceActionHeader;
		case "SequenceAcknowledgement":
			if (_sequenceAcknowledgementActionHeader == null)
			{
				_sequenceAcknowledgementActionHeader = ActionHeader.Create(wsrmFeb2005Dictionary.SequenceAcknowledgementAction, _addressingVersion);
			}
			return _sequenceAcknowledgementActionHeader;
		case "TerminateSequence":
			if (_terminateSequenceActionHeader == null)
			{
				_terminateSequenceActionHeader = ActionHeader.Create(wsrmFeb2005Dictionary.TerminateSequenceAction, _addressingVersion);
			}
			return _terminateSequenceActionHeader;
		default:
			throw Fx.AssertAndThrow("Element not supported.");
		}
	}
}
