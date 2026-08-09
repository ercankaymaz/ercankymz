using System.ComponentModel;
using System.Net;
using System.Net.Security;

namespace System.ServiceModel.Channels;

public class HttpsTransportBindingElement : HttpTransportBindingElement
{
	private MessageSecurityVersion _messageSecurityVersion;

	[DefaultValue(false)]
	public bool RequireClientCertificate { get; set; }

	public override string Scheme => "https";

	internal MessageSecurityVersion MessageSecurityVersion
	{
		get
		{
			return _messageSecurityVersion;
		}
		set
		{
			_messageSecurityVersion = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
		}
	}

	public HttpsTransportBindingElement()
	{
		RequireClientCertificate = false;
	}

	protected HttpsTransportBindingElement(HttpsTransportBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		RequireClientCertificate = elementToBeCloned.RequireClientCertificate;
		_messageSecurityVersion = elementToBeCloned._messageSecurityVersion;
	}

	private HttpsTransportBindingElement(HttpTransportBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
	}

	public override BindingElement Clone()
	{
		return new HttpsTransportBindingElement(this);
	}

	internal override bool GetSupportsClientAuthenticationImpl(AuthenticationSchemes effectiveAuthenticationSchemes)
	{
		if (!RequireClientCertificate)
		{
			return base.GetSupportsClientAuthenticationImpl(effectiveAuthenticationSchemes);
		}
		return true;
	}

	internal override bool GetSupportsClientWindowsIdentityImpl(AuthenticationSchemes effectiveAuthenticationSchemes)
	{
		if (!RequireClientCertificate)
		{
			return base.GetSupportsClientWindowsIdentityImpl(effectiveAuthenticationSchemes);
		}
		return true;
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (base.MessageHandlerFactory != null)
		{
			throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.HttpPipelineNotSupportedOnClientSide, "MessageHandlerFactory")));
		}
		if (!CanBuildChannelFactory<TChannel>(context))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("TChannel", System.SR.Format(System.SR.ChannelTypeNotSupported, typeof(TChannel)));
		}
		return new HttpsChannelFactory<TChannel>(this, context);
	}

	internal static HttpsTransportBindingElement CreateFromHttpBindingElement(HttpTransportBindingElement elementToBeCloned)
	{
		return new HttpsTransportBindingElement(elementToBeCloned);
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(ISecurityCapabilities))
		{
			AuthenticationSchemes authenticationScheme = base.AuthenticationScheme;
			return (T)(object)new SecurityCapabilities(GetSupportsClientAuthenticationImpl(authenticationScheme), supportsServerAuth: true, GetSupportsClientWindowsIdentityImpl(authenticationScheme), ProtectionLevel.EncryptAndSign, ProtectionLevel.EncryptAndSign);
		}
		return base.GetProperty<T>(context);
	}
}
