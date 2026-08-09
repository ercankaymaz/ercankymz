using System.ComponentModel;
using System.ServiceModel.Channels;

namespace System.ServiceModel;

public sealed class NetTcpSecurity
{
	internal const SecurityMode DefaultMode = SecurityMode.Transport;

	private SecurityMode _mode;

	[DefaultValue(SecurityMode.Transport)]
	public SecurityMode Mode
	{
		get
		{
			return _mode;
		}
		set
		{
			if (!SecurityModeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_mode = value;
		}
	}

	public TcpTransportSecurity Transport { get; set; }

	public MessageSecurityOverTcp Message { get; set; }

	public NetTcpSecurity()
		: this(SecurityMode.Transport, new TcpTransportSecurity(), new MessageSecurityOverTcp())
	{
	}

	private NetTcpSecurity(SecurityMode mode, TcpTransportSecurity transportSecurity, MessageSecurityOverTcp messageSecurity)
	{
		_mode = mode;
		Transport = transportSecurity ?? new TcpTransportSecurity();
		Message = messageSecurity ?? new MessageSecurityOverTcp();
	}

	internal BindingElement CreateTransportSecurity()
	{
		if (_mode == SecurityMode.TransportWithMessageCredential)
		{
			return Transport.CreateTransportProtectionOnly();
		}
		if (_mode == SecurityMode.Transport)
		{
			return Transport.CreateTransportProtectionAndAuthentication();
		}
		return null;
	}

	internal SecurityBindingElement CreateMessageSecurity(bool isReliableSessionEnabled)
	{
		if (_mode == SecurityMode.Message)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		if (_mode == SecurityMode.TransportWithMessageCredential)
		{
			return Message.CreateSecurityBindingElement(isSecureTransportMode: true, isReliableSessionEnabled, CreateTransportSecurity());
		}
		return null;
	}
}
