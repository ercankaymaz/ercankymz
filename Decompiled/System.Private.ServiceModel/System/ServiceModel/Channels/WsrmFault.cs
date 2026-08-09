using System.Globalization;
using System.Runtime;
using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class WsrmFault : MessageFault
{
	private FaultCode code;

	private string exceptionMessage;

	private bool hasDetail;

	private bool isRemote;

	private FaultReason reason;

	private ReliableMessagingVersion reliableMessagingVersion;

	private string subcode;

	public override FaultCode Code => code;

	public override bool HasDetail => hasDetail;

	public bool IsRemote => isRemote;

	public override FaultReason Reason => reason;

	public string Subcode => subcode;

	protected WsrmFault(bool isSenderFault, string subcode, string faultReason, string exceptionMessage)
	{
		if (isSenderFault)
		{
			code = new FaultCode("Sender", "");
		}
		else
		{
			code = new FaultCode("Receiver", "");
		}
		this.subcode = subcode;
		reason = new FaultReason(faultReason, CultureInfo.CurrentCulture);
		this.exceptionMessage = exceptionMessage;
		isRemote = false;
	}

	protected WsrmFault(FaultCode code, string subcode, FaultReason reason)
	{
		this.code = code;
		this.subcode = subcode;
		this.reason = reason;
		isRemote = true;
	}

	public virtual CommunicationException CreateException()
	{
		string safeReasonText;
		if (IsRemote)
		{
			safeReasonText = FaultException.GetSafeReasonText(reason);
			safeReasonText = System.SR.Format(System.SR.WsrmFaultReceived, safeReasonText);
		}
		else
		{
			if (exceptionMessage == null)
			{
				throw Fx.AssertAndThrow("Exception message must not be accessed unless set.");
			}
			safeReasonText = exceptionMessage;
		}
		if (code.IsSenderFault)
		{
			return new ProtocolException(safeReasonText);
		}
		return new CommunicationException(safeReasonText);
	}

	public static CommunicationException CreateException(WsrmFault fault)
	{
		return fault.CreateException();
	}

	public Message CreateMessage(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion)
	{
		SetReliableMessagingVersion(reliableMessagingVersion);
		string faultActionString = WsrmIndex.GetFaultActionString(messageVersion.Addressing, reliableMessagingVersion);
		if (messageVersion.Envelope == EnvelopeVersion.Soap11)
		{
			code = Get11Code(code, subcode);
		}
		else
		{
			if (messageVersion.Envelope != EnvelopeVersion.Soap12)
			{
				throw Fx.AssertAndThrow("Unsupported MessageVersion.");
			}
			if (code.SubCode == null)
			{
				FaultCode subCode = new FaultCode(subcode, WsrmIndex.GetNamespaceString(reliableMessagingVersion));
				code = new FaultCode(code.Name, code.Namespace, subCode);
			}
			hasDetail = Get12HasDetail();
		}
		Message message = Message.CreateMessage(messageVersion, this, faultActionString);
		OnFaultMessageCreated(messageVersion, message);
		return message;
	}

	protected abstract FaultCode Get11Code(FaultCode code, string subcode);

	protected abstract bool Get12HasDetail();

	protected string GetExceptionMessage()
	{
		if (exceptionMessage == null)
		{
			throw Fx.AssertAndThrow("Exception message must not be accessed unless set.");
		}
		return exceptionMessage;
	}

	protected ReliableMessagingVersion GetReliableMessagingVersion()
	{
		if (reliableMessagingVersion == null)
		{
			throw Fx.AssertAndThrow("Reliable messaging version must not be accessed unless set.");
		}
		return reliableMessagingVersion;
	}

	protected abstract void OnFaultMessageCreated(MessageVersion version, Message message);

	protected void SetReliableMessagingVersion(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == null)
		{
			throw Fx.AssertAndThrow("Reliable messaging version cannot be set to null.");
		}
		if (this.reliableMessagingVersion != null)
		{
			throw Fx.AssertAndThrow("Reliable messaging version must not be set twice.");
		}
		this.reliableMessagingVersion = reliableMessagingVersion;
	}

	internal void WriteDetail(XmlDictionaryWriter writer)
	{
		OnWriteDetailContents(writer);
	}
}
