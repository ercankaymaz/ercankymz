using System.Runtime;
using System.ServiceModel.Security;
using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class WsrmIndex
{
	private static WsrmFeb2005Index s_wsAddressingAug2004WSReliableMessagingFeb2005;

	private static WsrmFeb2005Index s_wsAddressing10WSReliableMessagingFeb2005;

	private static Wsrm11Index s_wsAddressingAug2004WSReliableMessaging11;

	private static Wsrm11Index s_wsAddressing10WSReliableMessaging11;

	internal static ActionHeader GetAckRequestedActionHeader(AddressingVersion addressingVersion, ReliableMessagingVersion reliableMessagingVersion)
	{
		return GetActionHeader(addressingVersion, reliableMessagingVersion, "AckRequested");
	}

	protected abstract ActionHeader GetActionHeader(string element);

	private static ActionHeader GetActionHeader(AddressingVersion addressingVersion, ReliableMessagingVersion reliableMessagingVersion, string element)
	{
		WsrmIndex wsrmIndex = null;
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			if (addressingVersion == AddressingVersion.WSAddressingAugust2004)
			{
				if (s_wsAddressingAug2004WSReliableMessagingFeb2005 == null)
				{
					s_wsAddressingAug2004WSReliableMessagingFeb2005 = new WsrmFeb2005Index(addressingVersion);
				}
				wsrmIndex = s_wsAddressingAug2004WSReliableMessagingFeb2005;
			}
			else if (addressingVersion == AddressingVersion.WSAddressing10)
			{
				if (s_wsAddressing10WSReliableMessagingFeb2005 == null)
				{
					s_wsAddressing10WSReliableMessagingFeb2005 = new WsrmFeb2005Index(addressingVersion);
				}
				wsrmIndex = s_wsAddressing10WSReliableMessagingFeb2005;
			}
		}
		else
		{
			if (reliableMessagingVersion != ReliableMessagingVersion.WSReliableMessaging11)
			{
				throw Fx.AssertAndThrow("Reliable messaging version not supported.");
			}
			if (addressingVersion == AddressingVersion.WSAddressingAugust2004)
			{
				if (s_wsAddressingAug2004WSReliableMessaging11 == null)
				{
					s_wsAddressingAug2004WSReliableMessaging11 = new Wsrm11Index(addressingVersion);
				}
				wsrmIndex = s_wsAddressingAug2004WSReliableMessaging11;
			}
			else if (addressingVersion == AddressingVersion.WSAddressing10)
			{
				if (s_wsAddressing10WSReliableMessaging11 == null)
				{
					s_wsAddressing10WSReliableMessaging11 = new Wsrm11Index(addressingVersion);
				}
				wsrmIndex = s_wsAddressing10WSReliableMessaging11;
			}
		}
		if (wsrmIndex == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.AddressingVersionNotSupported, addressingVersion)));
		}
		return wsrmIndex.GetActionHeader(element);
	}

	internal static ActionHeader GetCloseSequenceActionHeader(AddressingVersion addressingVersion)
	{
		return GetActionHeader(addressingVersion, ReliableMessagingVersion.WSReliableMessaging11, "CloseSequence");
	}

	internal static ActionHeader GetCloseSequenceResponseActionHeader(AddressingVersion addressingVersion)
	{
		return GetActionHeader(addressingVersion, ReliableMessagingVersion.WSReliableMessaging11, "CloseSequenceResponse");
	}

	internal static ActionHeader GetCreateSequenceActionHeader(AddressingVersion addressingVersion, ReliableMessagingVersion reliableMessagingVersion)
	{
		return GetActionHeader(addressingVersion, reliableMessagingVersion, "CreateSequence");
	}

	internal static string GetCreateSequenceActionString(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return "http://schemas.xmlsoap.org/ws/2005/02/rm/CreateSequence";
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			return "http://docs.oasis-open.org/ws-rx/wsrm/200702/CreateSequence";
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	internal static XmlDictionaryString GetCreateSequenceResponseAction(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return XD.WsrmFeb2005Dictionary.CreateSequenceResponseAction;
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			return DXD.Wsrm11Dictionary.CreateSequenceResponseAction;
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	internal static string GetCreateSequenceResponseActionString(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return "http://schemas.xmlsoap.org/ws/2005/02/rm/CreateSequenceResponse";
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			return "http://docs.oasis-open.org/ws-rx/wsrm/200702/CreateSequenceResponse";
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	internal static string GetFaultActionString(AddressingVersion addressingVersion, ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return addressingVersion.DefaultFaultAction;
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			return "http://docs.oasis-open.org/ws-rx/wsrm/200702/fault";
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	internal static XmlDictionaryString GetNamespace(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return XD.WsrmFeb2005Dictionary.Namespace;
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			return DXD.Wsrm11Dictionary.Namespace;
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	internal static string GetNamespaceString(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return "http://schemas.xmlsoap.org/ws/2005/02/rm";
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			return "http://docs.oasis-open.org/ws-rx/wsrm/200702";
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	internal static ActionHeader GetSequenceAcknowledgementActionHeader(AddressingVersion addressingVersion, ReliableMessagingVersion reliableMessagingVersion)
	{
		return GetActionHeader(addressingVersion, reliableMessagingVersion, "SequenceAcknowledgement");
	}

	internal static string GetSequenceAcknowledgementActionString(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return "http://schemas.xmlsoap.org/ws/2005/02/rm/SequenceAcknowledgement";
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			return "http://docs.oasis-open.org/ws-rx/wsrm/200702/SequenceAcknowledgement";
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	internal static MessagePartSpecification GetSignedReliabilityMessageParts(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return WsrmFeb2005Index.SignedReliabilityMessageParts;
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			return Wsrm11Index.SignedReliabilityMessageParts;
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	internal static ActionHeader GetTerminateSequenceActionHeader(AddressingVersion addressingVersion, ReliableMessagingVersion reliableMessagingVersion)
	{
		return GetActionHeader(addressingVersion, reliableMessagingVersion, "TerminateSequence");
	}

	internal static string GetTerminateSequenceActionString(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return "http://schemas.xmlsoap.org/ws/2005/02/rm/TerminateSequence";
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			return "http://docs.oasis-open.org/ws-rx/wsrm/200702/TerminateSequence";
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	internal static string GetTerminateSequenceResponseActionString(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			return "http://docs.oasis-open.org/ws-rx/wsrm/200702/TerminateSequenceResponse";
		}
		throw Fx.AssertAndThrow("Reliable messaging version not supported.");
	}

	internal static ActionHeader GetTerminateSequenceResponseActionHeader(AddressingVersion addressingVersion)
	{
		return GetActionHeader(addressingVersion, ReliableMessagingVersion.WSReliableMessaging11, "TerminateSequenceResponse");
	}
}
