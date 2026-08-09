using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Security;

internal abstract class NegotiationTokenProvider<T> : IssuanceTokenProviderBase<T> where T : IssuanceTokenProviderState
{
	private IChannelFactory<IAsyncRequestChannel> _rstChannelFactory;

	private bool _requiresManualReplyAddressing;

	private BindingContext _issuanceBindingContext;

	private MessageVersion _messageVersion;

	public BindingContext IssuerBindingContext
	{
		get
		{
			return _issuanceBindingContext;
		}
		set
		{
			base.CommunicationObject.ThrowIfDisposedOrImmutable();
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			_issuanceBindingContext = value.Clone();
		}
	}

	public override XmlDictionaryString RequestSecurityTokenAction => base.StandardsManager.TrustDriver.RequestSecurityTokenAction;

	public override XmlDictionaryString RequestSecurityTokenResponseAction => base.StandardsManager.TrustDriver.RequestSecurityTokenResponseAction;

	protected override MessageVersion MessageVersion => _messageVersion;

	protected override bool RequiresManualReplyAddressing
	{
		get
		{
			ThrowIfCreated();
			return _requiresManualReplyAddressing;
		}
	}

	public override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		if (_rstChannelFactory != null)
		{
			await _rstChannelFactory.CloseHelperAsync(timeout);
			_rstChannelFactory = null;
		}
		await base.OnCloseAsync(timeoutHelper.RemainingTime());
	}

	public override void OnAbort()
	{
		if (_rstChannelFactory != null)
		{
			_rstChannelFactory.Abort();
			_rstChannelFactory = null;
		}
		base.OnAbort();
	}

	public override async Task OnOpenAsync(TimeSpan timeout)
	{
		if (IssuerBindingContext == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.IssuerBuildContextNotSet, GetType())));
		}
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		SetupRstChannelFactory();
		await _rstChannelFactory.OpenHelperAsync(timeout);
		await base.OnOpenAsync(timeoutHelper.RemainingTime());
	}

	protected abstract IChannelFactory<IAsyncRequestChannel> GetNegotiationChannelFactory(IChannelFactory<IAsyncRequestChannel> transportChannelFactory, ChannelBuilder channelBuilder);

	private void SetupRstChannelFactory()
	{
		IChannelFactory<IAsyncRequestChannel> channelFactory = null;
		ChannelBuilder channelBuilder = new ChannelBuilder(IssuerBindingContext.Clone(), addChannelDemuxerIfRequired: true);
		if (channelBuilder.CanBuildChannelFactory<IAsyncRequestChannel>())
		{
			channelFactory = channelBuilder.BuildChannelFactory<IAsyncRequestChannel>();
			_requiresManualReplyAddressing = true;
		}
		else
		{
			ClientRuntime clientRuntime = new ClientRuntime("RequestSecurityTokenContract", "http://tempuri.org/");
			clientRuntime.ValidateMustUnderstand = false;
			ServiceChannelFactory serviceChannelFactory = ServiceChannelFactory.BuildChannelFactory(channelBuilder, clientRuntime);
			serviceChannelFactory.ClientRuntime.UseSynchronizationContext = false;
			serviceChannelFactory.ClientRuntime.AddTransactionFlowProperties = false;
			ClientOperation clientOperation = new ClientOperation(serviceChannelFactory.ClientRuntime, "RequestSecurityToken", RequestSecurityTokenAction.Value);
			clientOperation.Formatter = MessageOperationFormatter.Instance;
			serviceChannelFactory.ClientRuntime.Operations.Add(clientOperation);
			if (IsMultiLegNegotiation)
			{
				ClientOperation clientOperation2 = new ClientOperation(serviceChannelFactory.ClientRuntime, "RequestSecurityTokenResponse", RequestSecurityTokenResponseAction.Value);
				clientOperation2.Formatter = MessageOperationFormatter.Instance;
				serviceChannelFactory.ClientRuntime.Operations.Add(clientOperation2);
			}
			_requiresManualReplyAddressing = false;
			channelFactory = new SecuritySessionSecurityTokenProvider.RequestChannelFactory(serviceChannelFactory);
		}
		_rstChannelFactory = GetNegotiationChannelFactory(channelFactory, channelBuilder);
		_messageVersion = channelBuilder.Binding.MessageVersion;
	}

	protected override Task InitializeChannelFactoriesAsync(EndpointAddress target, TimeSpan timeout)
	{
		return Task.CompletedTask;
	}

	protected override IAsyncRequestChannel CreateClientChannel(EndpointAddress target, Uri via)
	{
		if (via != null)
		{
			return _rstChannelFactory.CreateChannel(target, via);
		}
		return _rstChannelFactory.CreateChannel(target);
	}
}
