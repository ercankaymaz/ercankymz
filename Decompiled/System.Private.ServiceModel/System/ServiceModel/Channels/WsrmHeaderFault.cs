using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class WsrmHeaderFault : WsrmFault
{
	private bool faultsInput;

	private bool faultsOutput;

	private UniqueId sequenceID;

	private string subcode;

	public bool FaultsInput => faultsInput;

	public bool FaultsOutput => faultsOutput;

	public UniqueId SequenceID
	{
		get
		{
			return sequenceID;
		}
		protected set
		{
			sequenceID = value;
		}
	}

	protected WsrmHeaderFault(bool isSenderFault, string subcode, string faultReason, string exceptionMessage, UniqueId sequenceID, bool faultsInput, bool faultsOutput)
		: base(isSenderFault, subcode, faultReason, exceptionMessage)
	{
		this.subcode = subcode;
		this.sequenceID = sequenceID;
		this.faultsInput = faultsInput;
		this.faultsOutput = faultsOutput;
	}

	protected WsrmHeaderFault(FaultCode code, string subcode, FaultReason reason, XmlDictionaryReader detailReader, ReliableMessagingVersion reliableMessagingVersion, bool faultsInput, bool faultsOutput)
		: this(code, subcode, reason, faultsInput, faultsOutput)
	{
		sequenceID = ParseDetail(detailReader, reliableMessagingVersion);
	}

	protected WsrmHeaderFault(FaultCode code, string subcode, FaultReason reason, bool faultsInput, bool faultsOutput)
		: base(code, subcode, reason)
	{
		this.subcode = subcode;
		this.faultsInput = faultsInput;
		this.faultsOutput = faultsOutput;
	}

	private static WsrmHeaderFault CreateWsrmHeaderFault(ReliableMessagingVersion reliableMessagingVersion, FaultCode code, string subcode, FaultReason reason, XmlDictionaryReader detailReader)
	{
		if (code.IsSenderFault)
		{
			switch (subcode)
			{
			case "InvalidAcknowledgement":
				return new InvalidAcknowledgementFault(code, reason, detailReader, reliableMessagingVersion);
			case "MessageNumberRollover":
				return new MessageNumberRolloverFault(code, reason, detailReader, reliableMessagingVersion);
			case "UnknownSequence":
				return new UnknownSequenceFault(code, reason, detailReader, reliableMessagingVersion);
			}
			if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
			{
				if (subcode == "LastMessageNumberExceeded")
				{
					return new LastMessageNumberExceededFault(code, reason, detailReader, reliableMessagingVersion);
				}
			}
			else if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11 && subcode == "SequenceClosed")
			{
				return new SequenceClosedFault(code, reason, detailReader, reliableMessagingVersion);
			}
		}
		if (code.IsSenderFault || code.IsReceiverFault)
		{
			return new SequenceTerminatedFault(code, reason, detailReader, reliableMessagingVersion);
		}
		return null;
	}

	protected override FaultCode Get11Code(FaultCode code, string subcode)
	{
		return code;
	}

	protected override bool Get12HasDetail()
	{
		return true;
	}

	private static void LookupDetailInformation(ReliableMessagingVersion reliableMessagingVersion, string subcode, out string detailName, out string detailNamespace)
	{
		detailName = null;
		detailNamespace = null;
		string namespaceString = WsrmIndex.GetNamespaceString(reliableMessagingVersion);
		bool flag = reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005;
		bool flag2 = reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11;
		switch (subcode)
		{
		case "InvalidAcknowledgement":
			detailName = "SequenceAcknowledgement";
			detailNamespace = namespaceString;
			return;
		default:
			if ((!flag || !(subcode == "LastMessageNumberExceeded")) && (!flag2 || !(subcode == "SequenceClosed")))
			{
				break;
			}
			goto case "MessageNumberRollover";
		case "MessageNumberRollover":
		case "SequenceTerminated":
		case "UnknownSequence":
			detailName = "Identifier";
			detailNamespace = namespaceString;
			return;
		}
		detailName = null;
		detailNamespace = null;
	}

	protected override void OnFaultMessageCreated(MessageVersion version, Message message)
	{
		if (version.Envelope == EnvelopeVersion.Soap11)
		{
			WsrmSequenceFaultHeader header = new WsrmSequenceFaultHeader(GetReliableMessagingVersion(), this);
			message.Headers.Add(header);
		}
	}

	protected override void OnWriteDetailContents(XmlDictionaryWriter writer)
	{
		WsrmUtilities.WriteIdentifier(writer, GetReliableMessagingVersion(), sequenceID);
	}

	private static UniqueId ParseDetail(XmlDictionaryReader reader, ReliableMessagingVersion reliableMessagingVersion)
	{
		try
		{
			return WsrmUtilities.ReadIdentifier(reader, reliableMessagingVersion);
		}
		finally
		{
			reader.Close();
		}
	}

	public static bool TryCreateFault11(ReliableMessagingVersion reliableMessagingVersion, Message message, MessageFault fault, int index, out WsrmHeaderFault wsrmFault)
	{
		if (index == -1)
		{
			wsrmFault = null;
			return false;
		}
		if (!fault.Code.IsSenderFault && !fault.Code.IsReceiverFault)
		{
			wsrmFault = null;
			return false;
		}
		string text = WsrmSequenceFaultHeader.GetSubcode(message.Headers.GetReaderAtHeader(index), reliableMessagingVersion);
		if (text == null)
		{
			wsrmFault = null;
			return false;
		}
		LookupDetailInformation(reliableMessagingVersion, text, out var detailName, out var detailNamespace);
		XmlDictionaryReader readerAtDetailContents = WsrmSequenceFaultHeader.GetReaderAtDetailContents(detailName, detailNamespace, message.Headers.GetReaderAtHeader(index), reliableMessagingVersion);
		if (readerAtDetailContents == null)
		{
			wsrmFault = null;
			return false;
		}
		wsrmFault = CreateWsrmHeaderFault(reliableMessagingVersion, fault.Code, text, fault.Reason, readerAtDetailContents);
		if (wsrmFault != null)
		{
			message.Headers.UnderstoodHeaders.Add(message.Headers[index]);
			return true;
		}
		return false;
	}

	public static bool TryCreateFault12(ReliableMessagingVersion reliableMessagingVersion, Message message, MessageFault fault, out WsrmHeaderFault wsrmFault)
	{
		if (!fault.Code.IsSenderFault && !fault.Code.IsReceiverFault)
		{
			wsrmFault = null;
			return false;
		}
		if (fault.Code.SubCode == null || fault.Code.SubCode.Namespace != WsrmIndex.GetNamespaceString(reliableMessagingVersion) || !fault.HasDetail)
		{
			wsrmFault = null;
			return false;
		}
		string name = fault.Code.SubCode.Name;
		XmlDictionaryReader readerAtDetailContents = fault.GetReaderAtDetailContents();
		wsrmFault = CreateWsrmHeaderFault(reliableMessagingVersion, fault.Code, name, fault.Reason, readerAtDetailContents);
		return wsrmFault != null;
	}
}
