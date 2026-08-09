using System.Security.Authentication.ExtendedProtection;

namespace System.ServiceModel.Channels;

public class TcpTransportBindingElement : ConnectionOrientedTransportBindingElement
{
	private class BindingDeliveryCapabilitiesHelper : IBindingDeliveryCapabilities
	{
		bool IBindingDeliveryCapabilities.AssuresOrderedDelivery => true;

		bool IBindingDeliveryCapabilities.QueuedDelivery => false;

		internal BindingDeliveryCapabilitiesHelper()
		{
		}
	}

	private class TransportCompressionSupportHelper : ITransportCompressionSupport
	{
		public bool IsCompressionFormatSupported(CompressionFormat compressionFormat)
		{
			return true;
		}
	}

	private ExtendedProtectionPolicy _extendedProtectionPolicy;

	public TcpConnectionPoolSettings ConnectionPoolSettings { get; }

	public override string Scheme => "net.tcp";

	public ExtendedProtectionPolicy ExtendedProtectionPolicy
	{
		get
		{
			return _extendedProtectionPolicy;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value.PolicyEnforcement == PolicyEnforcement.Always && !ExtendedProtectionPolicy.OSSupportsExtendedProtection)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new PlatformNotSupportedException(System.SR.ExtendedProtectionNotSupported));
			}
			_extendedProtectionPolicy = value;
		}
	}

	public TcpTransportBindingElement()
	{
		ConnectionPoolSettings = new TcpConnectionPoolSettings();
		_extendedProtectionPolicy = ChannelBindingUtility.DefaultPolicy;
	}

	protected TcpTransportBindingElement(TcpTransportBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		ConnectionPoolSettings = elementToBeCloned.ConnectionPoolSettings.Clone();
		_extendedProtectionPolicy = elementToBeCloned._extendedProtectionPolicy;
	}

	public override BindingElement Clone()
	{
		return new TcpTransportBindingElement(this);
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (!CanBuildChannelFactory<TChannel>(context))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("TChannel", System.SR.Format(System.SR.ChannelTypeNotSupported, typeof(TChannel)));
		}
		return new TcpChannelFactory<TChannel>(this, context);
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(IBindingDeliveryCapabilities))
		{
			return (T)(object)new BindingDeliveryCapabilitiesHelper();
		}
		if (typeof(T) == typeof(ExtendedProtectionPolicy))
		{
			return (T)(object)ExtendedProtectionPolicy;
		}
		if (typeof(T) == typeof(ITransportCompressionSupport))
		{
			return (T)(object)new TransportCompressionSupportHelper();
		}
		return base.GetProperty<T>(context);
	}

	internal override bool IsMatch(BindingElement b)
	{
		if (!base.IsMatch(b))
		{
			return false;
		}
		if (!(b is TcpTransportBindingElement tcpTransportBindingElement))
		{
			return false;
		}
		if (!ConnectionPoolSettings.IsMatch(tcpTransportBindingElement.ConnectionPoolSettings))
		{
			return false;
		}
		return true;
	}
}
