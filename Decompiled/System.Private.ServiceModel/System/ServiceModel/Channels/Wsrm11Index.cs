using System.Runtime;
using System.ServiceModel.Security;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class Wsrm11Index : WsrmIndex
{
	private static MessagePartSpecification s_signedReliabilityMessageParts;

	private ActionHeader _ackRequestedActionHeader;

	private AddressingVersion _addressingVersion;

	private ActionHeader _closeSequenceActionHeader;

	private ActionHeader _closeSequenceResponseActionHeader;

	private ActionHeader _createSequenceActionHeader;

	private ActionHeader _sequenceAcknowledgementActionHeader;

	private ActionHeader _terminateSequenceActionHeader;

	private ActionHeader _terminateSequenceResponseActionHeader;

	internal static MessagePartSpecification SignedReliabilityMessageParts
	{
		get
		{
			if (s_signedReliabilityMessageParts == null)
			{
				XmlQualifiedName[] headerTypes = new XmlQualifiedName[4]
				{
					new XmlQualifiedName("Sequence", "http://docs.oasis-open.org/ws-rx/wsrm/200702"),
					new XmlQualifiedName("SequenceAcknowledgement", "http://docs.oasis-open.org/ws-rx/wsrm/200702"),
					new XmlQualifiedName("AckRequested", "http://docs.oasis-open.org/ws-rx/wsrm/200702"),
					new XmlQualifiedName("UsesSequenceSTR", "http://docs.oasis-open.org/ws-rx/wsrm/200702")
				};
				MessagePartSpecification messagePartSpecification = new MessagePartSpecification(headerTypes);
				messagePartSpecification.MakeReadOnly();
				s_signedReliabilityMessageParts = messagePartSpecification;
			}
			return s_signedReliabilityMessageParts;
		}
	}

	internal Wsrm11Index(AddressingVersion addressingVersion)
	{
		_addressingVersion = addressingVersion;
	}

	protected override ActionHeader GetActionHeader(string element)
	{
		Wsrm11Dictionary wsrm11Dictionary = DXD.Wsrm11Dictionary;
		switch (element)
		{
		case "AckRequested":
			if (_ackRequestedActionHeader == null)
			{
				_ackRequestedActionHeader = ActionHeader.Create(wsrm11Dictionary.AckRequestedAction, _addressingVersion);
			}
			return _ackRequestedActionHeader;
		case "CreateSequence":
			if (_createSequenceActionHeader == null)
			{
				_createSequenceActionHeader = ActionHeader.Create(wsrm11Dictionary.CreateSequenceAction, _addressingVersion);
			}
			return _createSequenceActionHeader;
		case "SequenceAcknowledgement":
			if (_sequenceAcknowledgementActionHeader == null)
			{
				_sequenceAcknowledgementActionHeader = ActionHeader.Create(wsrm11Dictionary.SequenceAcknowledgementAction, _addressingVersion);
			}
			return _sequenceAcknowledgementActionHeader;
		case "TerminateSequence":
			if (_terminateSequenceActionHeader == null)
			{
				_terminateSequenceActionHeader = ActionHeader.Create(wsrm11Dictionary.TerminateSequenceAction, _addressingVersion);
			}
			return _terminateSequenceActionHeader;
		case "TerminateSequenceResponse":
			if (_terminateSequenceResponseActionHeader == null)
			{
				_terminateSequenceResponseActionHeader = ActionHeader.Create(wsrm11Dictionary.TerminateSequenceResponseAction, _addressingVersion);
			}
			return _terminateSequenceResponseActionHeader;
		case "CloseSequence":
			if (_closeSequenceActionHeader == null)
			{
				_closeSequenceActionHeader = ActionHeader.Create(wsrm11Dictionary.CloseSequenceAction, _addressingVersion);
			}
			return _closeSequenceActionHeader;
		case "CloseSequenceResponse":
			if (_closeSequenceResponseActionHeader == null)
			{
				_closeSequenceResponseActionHeader = ActionHeader.Create(wsrm11Dictionary.CloseSequenceResponseAction, _addressingVersion);
			}
			return _closeSequenceResponseActionHeader;
		default:
			throw Fx.AssertAndThrow("Element not supported.");
		}
	}
}
