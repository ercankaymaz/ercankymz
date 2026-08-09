using System.ComponentModel;
using System.ServiceModel.Channels;

namespace System.ServiceModel;

public class WSHttpBinding : WSHttpBindingBase
{
	private static readonly MessageSecurityVersion s_WSMessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;

	private WSHttpSecurity _security = new WSHttpSecurity();

	[DefaultValue(false)]
	public bool AllowCookies
	{
		get
		{
			return base.HttpTransport.AllowCookies;
		}
		set
		{
			base.HttpTransport.AllowCookies = value;
			base.HttpsTransport.AllowCookies = value;
		}
	}

	public WSHttpSecurity Security
	{
		get
		{
			return _security;
		}
		set
		{
			_security = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
	}

	public WSHttpBinding()
	{
	}

	public WSHttpBinding(SecurityMode securityMode)
		: this(securityMode, reliableSessionEnabled: false)
	{
	}

	public WSHttpBinding(SecurityMode securityMode, bool reliableSessionEnabled)
		: base(reliableSessionEnabled)
	{
		_security.Mode = securityMode;
	}

	internal WSHttpBinding(WSHttpSecurity security, bool reliableSessionEnabled)
		: base(reliableSessionEnabled)
	{
		_security = ((security == null) ? new WSHttpSecurity() : security);
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingParameterCollection parameters)
	{
		if (_security.Mode == SecurityMode.Transport && _security.Transport.ClientCredentialType == HttpClientCredentialType.InheritedFromHost)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.HttpClientCredentialTypeInvalid, _security.Transport.ClientCredentialType)));
		}
		return base.BuildChannelFactory<TChannel>(parameters);
	}

	public override BindingElementCollection CreateBindingElements()
	{
		return base.CreateBindingElements();
	}

	protected override TransportBindingElement GetTransport()
	{
		if (_security.Mode == SecurityMode.None || _security.Mode == SecurityMode.Message)
		{
			base.HttpTransport.ExtendedProtectionPolicy = _security.Transport.ExtendedProtectionPolicy;
			return base.HttpTransport;
		}
		_security.ApplyTransportSecurity(base.HttpsTransport);
		return base.HttpsTransport;
	}

	protected override SecurityBindingElement CreateMessageSecurity()
	{
		return _security.CreateMessageSecurity(base.ReliableSession.Enabled, s_WSMessageSecurityVersion);
	}
}
