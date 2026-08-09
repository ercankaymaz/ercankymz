using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ServiceModel.Security;
using System.Xml;

namespace System.ServiceModel.Channels;

public abstract class TransportBindingElement : BindingElement
{
	private bool _manualAddressing;

	private long _maxBufferPoolSize;

	private long _maxReceivedMessageSize;

	[DefaultValue(false)]
	public virtual bool ManualAddressing
	{
		get
		{
			return _manualAddressing;
		}
		set
		{
			_manualAddressing = value;
		}
	}

	[DefaultValue(524288L)]
	public virtual long MaxBufferPoolSize
	{
		get
		{
			return _maxBufferPoolSize;
		}
		set
		{
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBeNonNegative));
			}
			_maxBufferPoolSize = value;
		}
	}

	[DefaultValue(65536L)]
	public virtual long MaxReceivedMessageSize
	{
		get
		{
			return _maxReceivedMessageSize;
		}
		set
		{
			if (value <= 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBePositive));
			}
			_maxReceivedMessageSize = value;
		}
	}

	public abstract string Scheme { get; }

	protected TransportBindingElement()
	{
		_manualAddressing = false;
		_maxBufferPoolSize = 524288L;
		_maxReceivedMessageSize = 65536L;
	}

	protected TransportBindingElement(TransportBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		_manualAddressing = elementToBeCloned._manualAddressing;
		_maxBufferPoolSize = elementToBeCloned._maxBufferPoolSize;
		_maxReceivedMessageSize = elementToBeCloned._maxReceivedMessageSize;
	}

	internal static IChannelFactory<TChannel> CreateChannelFactory<TChannel>(TransportBindingElement transport)
	{
		Binding binding = new CustomBinding(transport);
		return binding.BuildChannelFactory<TChannel>(Array.Empty<object>());
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(ChannelProtectionRequirements))
		{
			ChannelProtectionRequirements protectionRequirements = GetProtectionRequirements(context);
			protectionRequirements.Add(context.GetInnerProperty<ChannelProtectionRequirements>() ?? new ChannelProtectionRequirements());
			return (T)(object)protectionRequirements;
		}
		Collection<BindingElement> collection = context.BindingParameters.FindAll<BindingElement>();
		T val = null;
		for (int i = 0; i < collection.Count; i++)
		{
			val = collection[i].GetIndividualProperty<T>();
			if (val != null)
			{
				return val;
			}
		}
		if (typeof(T) == typeof(MessageVersion))
		{
			return (T)(object)TransportDefaults.GetDefaultMessageEncoderFactory().MessageVersion;
		}
		if (typeof(T) == typeof(XmlDictionaryReaderQuotas))
		{
			return (T)(object)new XmlDictionaryReaderQuotas();
		}
		return null;
	}

	private ChannelProtectionRequirements GetProtectionRequirements(AddressingVersion addressingVersion)
	{
		ChannelProtectionRequirements channelProtectionRequirements = new ChannelProtectionRequirements();
		channelProtectionRequirements.IncomingSignatureParts.AddParts(addressingVersion.SignedMessageParts);
		channelProtectionRequirements.OutgoingSignatureParts.AddParts(addressingVersion.SignedMessageParts);
		return channelProtectionRequirements;
	}

	internal ChannelProtectionRequirements GetProtectionRequirements(BindingContext context)
	{
		AddressingVersion addressingVersion = AddressingVersion.WSAddressing10;
		MessageEncodingBindingElement messageEncodingBindingElement = context.Binding.Elements.Find<MessageEncodingBindingElement>();
		if (messageEncodingBindingElement != null)
		{
			addressingVersion = messageEncodingBindingElement.MessageVersion.Addressing;
		}
		return GetProtectionRequirements(addressingVersion);
	}

	internal override bool IsMatch(BindingElement b)
	{
		if (b == null)
		{
			return false;
		}
		if (!(b is TransportBindingElement transportBindingElement))
		{
			return false;
		}
		if (_maxBufferPoolSize != transportBindingElement.MaxBufferPoolSize)
		{
			return false;
		}
		if (_maxReceivedMessageSize != transportBindingElement.MaxReceivedMessageSize)
		{
			return false;
		}
		return true;
	}
}
