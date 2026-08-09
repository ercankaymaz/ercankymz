using System.Net.Security;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

namespace System.ServiceModel.Channels;

public sealed class TransportSecurityBindingElement : SecurityBindingElement
{
	internal override bool SessionMode
	{
		get
		{
			SecureConversationSecurityTokenParameters secureConversationSecurityTokenParameters = null;
			if (base.EndpointSupportingTokenParameters.Endorsing.Count > 0)
			{
				secureConversationSecurityTokenParameters = base.EndpointSupportingTokenParameters.Endorsing[0] as SecureConversationSecurityTokenParameters;
			}
			return secureConversationSecurityTokenParameters?.RequireCancellation ?? false;
		}
	}

	internal override bool SupportsDuplex => true;

	internal override bool SupportsRequestReply => true;

	public TransportSecurityBindingElement()
	{
	}

	private TransportSecurityBindingElement(TransportSecurityBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
	}

	internal override ISecurityCapabilities GetIndividualISecurityCapabilities()
	{
		GetSupportingTokensCapabilities(out var supportsClientAuth, out var supportsWindowsIdentity);
		return new SecurityCapabilities(supportsClientAuth, supportsServerAuth: false, supportsWindowsIdentity, ProtectionLevel.None, ProtectionLevel.None);
	}

	internal override SecurityProtocolFactory CreateSecurityProtocolFactory<TChannel>(BindingContext context, SecurityCredentialsManager credentialsManager, bool isForService, BindingContext issuerBindingContext)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (credentialsManager == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("credentialsManager");
		}
		TransportSecurityProtocolFactory transportSecurityProtocolFactory = new TransportSecurityProtocolFactory();
		ConfigureProtocolFactory(transportSecurityProtocolFactory, credentialsManager, isForService, issuerBindingContext, context.Binding);
		transportSecurityProtocolFactory.DetectReplays = false;
		return transportSecurityProtocolFactory;
	}

	protected override IChannelFactory<TChannel> BuildChannelFactoryCore<TChannel>(BindingContext context)
	{
		ISecurityCapabilities property = GetProperty<ISecurityCapabilities>(context);
		SecurityCredentialsManager securityCredentialsManager = context.BindingParameters.Find<SecurityCredentialsManager>();
		if (securityCredentialsManager == null)
		{
			securityCredentialsManager = ClientCredentials.CreateDefaultCredentials();
		}
		SecureConversationSecurityTokenParameters secureConversationSecurityTokenParameters = null;
		if (base.EndpointSupportingTokenParameters.Endorsing.Count > 0)
		{
			secureConversationSecurityTokenParameters = base.EndpointSupportingTokenParameters.Endorsing[0] as SecureConversationSecurityTokenParameters;
		}
		bool flag = RequiresChannelDemuxer();
		ChannelBuilder channelBuilder = new ChannelBuilder(context, flag);
		if (flag)
		{
			ApplyPropertiesOnDemuxer(channelBuilder, context);
		}
		BindingContext bindingContext = context.Clone();
		if (secureConversationSecurityTokenParameters != null)
		{
			if (secureConversationSecurityTokenParameters.BootstrapSecurityBindingElement == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SecureConversationSecurityTokenParametersRequireBootstrapBinding));
			}
			secureConversationSecurityTokenParameters.IssuerBindingContext = bindingContext;
			if (secureConversationSecurityTokenParameters.RequireCancellation)
			{
				SessionSymmetricTransportSecurityProtocolFactory sessionSymmetricTransportSecurityProtocolFactory = new SessionSymmetricTransportSecurityProtocolFactory();
				sessionSymmetricTransportSecurityProtocolFactory.SecurityTokenParameters = secureConversationSecurityTokenParameters.Clone();
				((SecureConversationSecurityTokenParameters)sessionSymmetricTransportSecurityProtocolFactory.SecurityTokenParameters).IssuerBindingContext = bindingContext;
				base.EndpointSupportingTokenParameters.Endorsing.RemoveAt(0);
				try
				{
					ConfigureProtocolFactory(sessionSymmetricTransportSecurityProtocolFactory, securityCredentialsManager, isForService: false, bindingContext, context.Binding);
				}
				finally
				{
					base.EndpointSupportingTokenParameters.Endorsing.Insert(0, secureConversationSecurityTokenParameters);
				}
				SecuritySessionClientSettings<TChannel> securitySessionClientSettings = new SecuritySessionClientSettings<TChannel>();
				securitySessionClientSettings.ChannelBuilder = channelBuilder;
				securitySessionClientSettings.KeyRenewalInterval = base.LocalClientSettings.SessionKeyRenewalInterval;
				securitySessionClientSettings.KeyRolloverInterval = base.LocalClientSettings.SessionKeyRolloverInterval;
				securitySessionClientSettings.TolerateTransportFailures = base.LocalClientSettings.ReconnectTransportOnFailure;
				securitySessionClientSettings.CanRenewSession = secureConversationSecurityTokenParameters.CanRenewSession;
				securitySessionClientSettings.IssuedSecurityTokenParameters = secureConversationSecurityTokenParameters.Clone();
				((SecureConversationSecurityTokenParameters)securitySessionClientSettings.IssuedSecurityTokenParameters).IssuerBindingContext = bindingContext;
				securitySessionClientSettings.SecurityStandardsManager = sessionSymmetricTransportSecurityProtocolFactory.StandardsManager;
				securitySessionClientSettings.SessionProtocolFactory = sessionSymmetricTransportSecurityProtocolFactory;
				return new SecurityChannelFactory<TChannel>(property, context, securitySessionClientSettings);
			}
			TransportSecurityProtocolFactory transportSecurityProtocolFactory = new TransportSecurityProtocolFactory();
			base.EndpointSupportingTokenParameters.Endorsing.RemoveAt(0);
			try
			{
				ConfigureProtocolFactory(transportSecurityProtocolFactory, securityCredentialsManager, isForService: false, bindingContext, context.Binding);
				SecureConversationSecurityTokenParameters secureConversationSecurityTokenParameters2 = (SecureConversationSecurityTokenParameters)secureConversationSecurityTokenParameters.Clone();
				secureConversationSecurityTokenParameters2.IssuerBindingContext = bindingContext;
				transportSecurityProtocolFactory.SecurityBindingElement.EndpointSupportingTokenParameters.Endorsing.Insert(0, secureConversationSecurityTokenParameters2);
			}
			finally
			{
				base.EndpointSupportingTokenParameters.Endorsing.Insert(0, secureConversationSecurityTokenParameters);
			}
			return new SecurityChannelFactory<TChannel>(property, context, channelBuilder, transportSecurityProtocolFactory);
		}
		SecurityProtocolFactory protocolFactory = CreateSecurityProtocolFactory<TChannel>(context, securityCredentialsManager, isForService: false, bindingContext);
		return new SecurityChannelFactory<TChannel>(property, context, channelBuilder, protocolFactory);
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(ChannelProtectionRequirements))
		{
			throw ExceptionHelper.PlatformNotSupported("TransportSecurityBindingElement doesn't support ChannelProtectionRequirements yet.");
		}
		return base.GetProperty<T>(context);
	}

	public override BindingElement Clone()
	{
		return new TransportSecurityBindingElement(this);
	}
}
