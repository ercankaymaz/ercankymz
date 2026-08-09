using System.ComponentModel;
using System.Runtime;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Xml;

namespace System.ServiceModel.Channels;

public sealed class ReliableSessionBindingElement : BindingElement
{
	private class BindingDeliveryCapabilitiesHelper : IBindingDeliveryCapabilities
	{
		private ReliableSessionBindingElement element;

		private IBindingDeliveryCapabilities inner;

		bool IBindingDeliveryCapabilities.AssuresOrderedDelivery => element.Ordered;

		bool IBindingDeliveryCapabilities.QueuedDelivery
		{
			get
			{
				if (inner == null)
				{
					return false;
				}
				return inner.QueuedDelivery;
			}
		}

		internal BindingDeliveryCapabilitiesHelper(ReliableSessionBindingElement element, IBindingDeliveryCapabilities inner)
		{
			this.element = element;
			this.inner = inner;
		}
	}

	private TimeSpan _acknowledgementInterval = ReliableSessionDefaults.AcknowledgementInterval;

	private TimeSpan _inactivityTimeout = ReliableSessionDefaults.InactivityTimeout;

	private int _maxPendingChannels = 4;

	private int _maxRetryCount = 8;

	private int _maxTransferWindowSize = 8;

	private ReliableMessagingVersion _reliableMessagingVersion = ReliableMessagingVersion.Default;

	private static MessagePartSpecification s_bodyOnly;

	[DefaultValue(typeof(TimeSpan), "00:00:00.2")]
	public TimeSpan AcknowledgementInterval
	{
		get
		{
			return _acknowledgementInterval;
		}
		set
		{
			if (value <= TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.TimeSpanMustbeGreaterThanTimeSpanZero));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_acknowledgementInterval = value;
		}
	}

	[DefaultValue(true)]
	public bool FlowControlEnabled { get; set; } = true;

	[DefaultValue(typeof(TimeSpan), "00:10:00")]
	public TimeSpan InactivityTimeout
	{
		get
		{
			return _inactivityTimeout;
		}
		set
		{
			if (value <= TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.TimeSpanMustbeGreaterThanTimeSpanZero));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_inactivityTimeout = value;
		}
	}

	[DefaultValue(4)]
	public int MaxPendingChannels
	{
		get
		{
			return _maxPendingChannels;
		}
		set
		{
			if (value <= 0 || value > 16384)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.Format(System.SR.ValueMustBeInRange, 0, 16384)));
			}
			_maxPendingChannels = value;
		}
	}

	[DefaultValue(8)]
	public int MaxRetryCount
	{
		get
		{
			return _maxRetryCount;
		}
		set
		{
			if (value <= 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBePositive));
			}
			_maxRetryCount = value;
		}
	}

	[DefaultValue(8)]
	public int MaxTransferWindowSize
	{
		get
		{
			return _maxTransferWindowSize;
		}
		set
		{
			if (value <= 0 || value > 4096)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.Format(System.SR.ValueMustBeInRange, 0, 4096)));
			}
			_maxTransferWindowSize = value;
		}
	}

	[DefaultValue(true)]
	public bool Ordered { get; set; } = true;

	[DefaultValue(typeof(ReliableMessagingVersion), "WSReliableMessagingFebruary2005")]
	public ReliableMessagingVersion ReliableMessagingVersion
	{
		get
		{
			return _reliableMessagingVersion;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (!ReliableMessagingVersion.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_reliableMessagingVersion = value;
		}
	}

	private static MessagePartSpecification BodyOnly
	{
		get
		{
			if (s_bodyOnly == null)
			{
				MessagePartSpecification messagePartSpecification = new MessagePartSpecification(isBodyIncluded: true);
				messagePartSpecification.MakeReadOnly();
				s_bodyOnly = messagePartSpecification;
			}
			return s_bodyOnly;
		}
	}

	public ReliableSessionBindingElement()
	{
	}

	internal ReliableSessionBindingElement(ReliableSessionBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		AcknowledgementInterval = elementToBeCloned.AcknowledgementInterval;
		FlowControlEnabled = elementToBeCloned.FlowControlEnabled;
		InactivityTimeout = elementToBeCloned.InactivityTimeout;
		MaxPendingChannels = elementToBeCloned.MaxPendingChannels;
		MaxRetryCount = elementToBeCloned.MaxRetryCount;
		MaxTransferWindowSize = elementToBeCloned.MaxTransferWindowSize;
		Ordered = elementToBeCloned.Ordered;
		ReliableMessagingVersion = elementToBeCloned.ReliableMessagingVersion;
	}

	public ReliableSessionBindingElement(bool ordered)
	{
		Ordered = ordered;
	}

	public override BindingElement Clone()
	{
		return new ReliableSessionBindingElement(this);
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(ChannelProtectionRequirements))
		{
			ChannelProtectionRequirements protectionRequirements = GetProtectionRequirements();
			protectionRequirements.Add(context.GetInnerProperty<ChannelProtectionRequirements>() ?? new ChannelProtectionRequirements());
			return (T)(object)protectionRequirements;
		}
		if (typeof(T) == typeof(IBindingDeliveryCapabilities))
		{
			return (T)(object)new BindingDeliveryCapabilitiesHelper(this, context.GetInnerProperty<IBindingDeliveryCapabilities>());
		}
		return context.GetInnerProperty<T>();
	}

	private ChannelProtectionRequirements GetProtectionRequirements()
	{
		ChannelProtectionRequirements channelProtectionRequirements = new ChannelProtectionRequirements();
		MessagePartSpecification signedReliabilityMessageParts = WsrmIndex.GetSignedReliabilityMessageParts(_reliableMessagingVersion);
		channelProtectionRequirements.IncomingSignatureParts.AddParts(signedReliabilityMessageParts);
		channelProtectionRequirements.OutgoingSignatureParts.AddParts(signedReliabilityMessageParts);
		if (_reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			ScopedMessagePartSpecification incomingSignatureParts = channelProtectionRequirements.IncomingSignatureParts;
			ScopedMessagePartSpecification incomingEncryptionParts = channelProtectionRequirements.IncomingEncryptionParts;
			ProtectProtocolMessage(incomingSignatureParts, incomingEncryptionParts, "http://schemas.xmlsoap.org/ws/2005/02/rm/AckRequested");
			ProtectProtocolMessage(incomingSignatureParts, incomingEncryptionParts, "http://schemas.xmlsoap.org/ws/2005/02/rm/CreateSequence");
			ProtectProtocolMessage(incomingSignatureParts, incomingEncryptionParts, "http://schemas.xmlsoap.org/ws/2005/02/rm/SequenceAcknowledgement");
			ProtectProtocolMessage(incomingSignatureParts, incomingEncryptionParts, "http://schemas.xmlsoap.org/ws/2005/02/rm/LastMessage");
			ProtectProtocolMessage(incomingSignatureParts, incomingEncryptionParts, "http://schemas.xmlsoap.org/ws/2005/02/rm/TerminateSequence");
			incomingSignatureParts = channelProtectionRequirements.OutgoingSignatureParts;
			incomingEncryptionParts = channelProtectionRequirements.OutgoingEncryptionParts;
			ProtectProtocolMessage(incomingSignatureParts, incomingEncryptionParts, "http://schemas.xmlsoap.org/ws/2005/02/rm/CreateSequenceResponse");
			ProtectProtocolMessage(incomingSignatureParts, incomingEncryptionParts, "http://schemas.xmlsoap.org/ws/2005/02/rm/SequenceAcknowledgement");
			ProtectProtocolMessage(incomingSignatureParts, incomingEncryptionParts, "http://schemas.xmlsoap.org/ws/2005/02/rm/LastMessage");
			ProtectProtocolMessage(incomingSignatureParts, incomingEncryptionParts, "http://schemas.xmlsoap.org/ws/2005/02/rm/TerminateSequence");
		}
		else
		{
			if (_reliableMessagingVersion != ReliableMessagingVersion.WSReliableMessaging11)
			{
				throw Fx.AssertAndThrow("Reliable messaging version not supported.");
			}
			ScopedMessagePartSpecification incomingSignatureParts2 = channelProtectionRequirements.IncomingSignatureParts;
			ScopedMessagePartSpecification incomingEncryptionParts2 = channelProtectionRequirements.IncomingEncryptionParts;
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/AckRequested");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequence");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequenceResponse");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/CreateSequence");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/fault");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/SequenceAcknowledgement");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/TerminateSequence");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/TerminateSequenceResponse");
			incomingSignatureParts2 = channelProtectionRequirements.OutgoingSignatureParts;
			incomingEncryptionParts2 = channelProtectionRequirements.OutgoingEncryptionParts;
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/AckRequested");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequence");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequenceResponse");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/CreateSequenceResponse");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/fault");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/SequenceAcknowledgement");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/TerminateSequence");
			ProtectProtocolMessage(incomingSignatureParts2, incomingEncryptionParts2, "http://docs.oasis-open.org/ws-rx/wsrm/200702/TerminateSequenceResponse");
		}
		return channelProtectionRequirements;
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		VerifyTransportMode(context);
		if (typeof(TChannel) == typeof(IOutputSessionChannel))
		{
			if (context.CanBuildInnerChannelFactory<IRequestSessionChannel>())
			{
				return new ReliableChannelFactory<TChannel, IRequestSessionChannel>(this, context.BuildInnerChannelFactory<IRequestSessionChannel>(), context.Binding);
			}
			if (context.CanBuildInnerChannelFactory<IRequestChannel>())
			{
				return new ReliableChannelFactory<TChannel, IRequestChannel>(this, context.BuildInnerChannelFactory<IRequestChannel>(), context.Binding);
			}
			if (context.CanBuildInnerChannelFactory<IDuplexSessionChannel>())
			{
				return new ReliableChannelFactory<TChannel, IDuplexSessionChannel>(this, context.BuildInnerChannelFactory<IDuplexSessionChannel>(), context.Binding);
			}
			if (context.CanBuildInnerChannelFactory<IDuplexChannel>())
			{
				return new ReliableChannelFactory<TChannel, IDuplexChannel>(this, context.BuildInnerChannelFactory<IDuplexChannel>(), context.Binding);
			}
		}
		else if (typeof(TChannel) == typeof(IDuplexSessionChannel))
		{
			if (context.CanBuildInnerChannelFactory<IDuplexSessionChannel>())
			{
				return new ReliableChannelFactory<TChannel, IDuplexSessionChannel>(this, context.BuildInnerChannelFactory<IDuplexSessionChannel>(), context.Binding);
			}
			if (context.CanBuildInnerChannelFactory<IDuplexChannel>())
			{
				return new ReliableChannelFactory<TChannel, IDuplexChannel>(this, context.BuildInnerChannelFactory<IDuplexChannel>(), context.Binding);
			}
		}
		else if (typeof(TChannel) == typeof(IRequestSessionChannel))
		{
			if (context.CanBuildInnerChannelFactory<IRequestSessionChannel>())
			{
				return new ReliableChannelFactory<TChannel, IRequestSessionChannel>(this, context.BuildInnerChannelFactory<IRequestSessionChannel>(), context.Binding);
			}
			if (context.CanBuildInnerChannelFactory<IRequestChannel>())
			{
				return new ReliableChannelFactory<TChannel, IRequestChannel>(this, context.BuildInnerChannelFactory<IRequestChannel>(), context.Binding);
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("TChannel", System.SR.Format(System.SR.ChannelTypeNotSupported, typeof(TChannel)));
	}

	public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(TChannel) == typeof(IOutputSessionChannel))
		{
			if (!context.CanBuildInnerChannelFactory<IRequestSessionChannel>() && !context.CanBuildInnerChannelFactory<IRequestChannel>() && !context.CanBuildInnerChannelFactory<IDuplexSessionChannel>())
			{
				return context.CanBuildInnerChannelFactory<IDuplexChannel>();
			}
			return true;
		}
		if (typeof(TChannel) == typeof(IDuplexSessionChannel))
		{
			if (!context.CanBuildInnerChannelFactory<IDuplexSessionChannel>())
			{
				return context.CanBuildInnerChannelFactory<IDuplexChannel>();
			}
			return true;
		}
		if (typeof(TChannel) == typeof(IRequestSessionChannel))
		{
			if (!context.CanBuildInnerChannelFactory<IRequestSessionChannel>())
			{
				return context.CanBuildInnerChannelFactory<IRequestChannel>();
			}
			return true;
		}
		return false;
	}

	private static void ProtectProtocolMessage(ScopedMessagePartSpecification signaturePart, ScopedMessagePartSpecification encryptionPart, string action)
	{
		signaturePart.AddParts(BodyOnly, action);
		encryptionPart.AddParts(MessagePartSpecification.NoParts, action);
	}

	private void VerifyTransportMode(BindingContext context)
	{
		TransportBindingElement transportBindingElement = context.RemainingBindingElements.Find<TransportBindingElement>();
		if (transportBindingElement != null && transportBindingElement.ManualAddressing)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ManualAddressingNotSupported));
		}
		ConnectionOrientedTransportBindingElement connectionOrientedTransportBindingElement = transportBindingElement as ConnectionOrientedTransportBindingElement;
		HttpTransportBindingElement httpTransportBindingElement = transportBindingElement as HttpTransportBindingElement;
		TransferMode transferMode = connectionOrientedTransportBindingElement?.TransferMode ?? httpTransportBindingElement?.TransferMode ?? TransferMode.Buffered;
		if (transferMode != TransferMode.Buffered)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TransferModeNotSupported, transferMode, GetType().Name)));
		}
	}

	private static XmlElement CreatePolicyElement(PolicyVersion policyVersion, XmlDocument doc)
	{
		string localName = "Policy";
		string namespaceURI = policyVersion.Namespace;
		string prefix = "wsp";
		return doc.CreateElement(prefix, localName, namespaceURI);
	}
}
