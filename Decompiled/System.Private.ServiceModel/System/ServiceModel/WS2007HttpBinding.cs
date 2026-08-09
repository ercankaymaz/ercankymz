using System.ServiceModel.Channels;

namespace System.ServiceModel;

public class WS2007HttpBinding : WSHttpBinding
{
	private static readonly MessageSecurityVersion WS2007MessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;

	public WS2007HttpBinding()
	{
		base.HttpsTransport.MessageSecurityVersion = WS2007MessageSecurityVersion;
	}

	public WS2007HttpBinding(SecurityMode securityMode)
		: this(securityMode, reliableSessionEnabled: false)
	{
	}

	public WS2007HttpBinding(SecurityMode securityMode, bool reliableSessionEnabled)
		: base(securityMode, reliableSessionEnabled)
	{
		base.HttpsTransport.MessageSecurityVersion = WS2007MessageSecurityVersion;
	}

	internal WS2007HttpBinding(WSHttpSecurity security, bool reliableSessionEnabled)
		: base(security, reliableSessionEnabled)
	{
		base.HttpsTransport.MessageSecurityVersion = WS2007MessageSecurityVersion;
	}

	protected override SecurityBindingElement CreateMessageSecurity()
	{
		return base.Security.CreateMessageSecurity(base.ReliableSession.Enabled, WS2007MessageSecurityVersion);
	}
}
