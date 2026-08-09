using System.Runtime;
using System.Security.Claims;
using System.Security.Principal;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace System.ServiceModel;

public sealed class OperationContext : IExtensibleObject<OperationContext>
{
	internal class Holder
	{
		public OperationContext Context { get; set; }
	}

	[ThreadStatic]
	private static Holder s_currentContext;

	private static AsyncLocal<OperationContext> s_asyncContext;

	private Message _clientReply;

	private bool _closeClientReply;

	private ExtensionCollection<OperationContext> _extensions;

	private Message _request;

	private bool _isServiceReentrant;

	internal IPrincipal threadPrincipal;

	private MessageProperties _outgoingMessageProperties;

	private MessageHeaders _outgoingMessageHeaders;

	private EndpointDispatcher _endpointDispatcher;

	public IContextChannel Channel => GetCallbackChannel<IContextChannel>();

	public static OperationContext Current
	{
		get
		{
			if (DisableAsyncFlow)
			{
				return CurrentHolder.Context;
			}
			return s_asyncContext.Value;
		}
		set
		{
			if (DisableAsyncFlow)
			{
				CurrentHolder.Context = value;
			}
			else
			{
				s_asyncContext.Value = value;
			}
		}
	}

	internal static Holder CurrentHolder
	{
		get
		{
			Holder holder = s_currentContext;
			if (holder == null)
			{
				holder = (s_currentContext = new Holder());
			}
			return holder;
		}
	}

	internal static bool DisableAsyncFlow { get; }

	public EndpointDispatcher EndpointDispatcher
	{
		get
		{
			return _endpointDispatcher;
		}
		set
		{
			_endpointDispatcher = value;
		}
	}

	public bool IsUserContext => _request == null;

	public IExtensionCollection<OperationContext> Extensions
	{
		get
		{
			if (_extensions == null)
			{
				_extensions = new ExtensionCollection<OperationContext>(this);
			}
			return _extensions;
		}
	}

	internal bool IsServiceReentrant
	{
		get
		{
			return _isServiceReentrant;
		}
		set
		{
			_isServiceReentrant = value;
		}
	}

	internal Message IncomingMessage => _clientReply ?? _request;

	internal ServiceChannel InternalServiceChannel { get; set; }

	internal bool HasOutgoingMessageHeaders => _outgoingMessageHeaders != null;

	public MessageHeaders OutgoingMessageHeaders
	{
		get
		{
			if (_outgoingMessageHeaders == null)
			{
				_outgoingMessageHeaders = new MessageHeaders(OutgoingMessageVersion);
			}
			return _outgoingMessageHeaders;
		}
	}

	internal bool HasOutgoingMessageProperties => _outgoingMessageProperties != null;

	public MessageProperties OutgoingMessageProperties
	{
		get
		{
			if (_outgoingMessageProperties == null)
			{
				_outgoingMessageProperties = new MessageProperties();
			}
			return _outgoingMessageProperties;
		}
	}

	internal MessageVersion OutgoingMessageVersion { get; }

	public MessageHeaders IncomingMessageHeaders => (_clientReply ?? _request)?.Headers;

	public MessageProperties IncomingMessageProperties => (_clientReply ?? _request)?.Properties;

	public MessageVersion IncomingMessageVersion => (_clientReply ?? _request)?.Version;

	public InstanceContext InstanceContext { get; private set; }

	public RequestContext RequestContext { get; set; }

	public string SessionId
	{
		get
		{
			if (InternalServiceChannel != null)
			{
				IChannel innerChannel = InternalServiceChannel.InnerChannel;
				if (innerChannel != null)
				{
					if (innerChannel is ISessionChannel<IDuplexSession> { Session: not null } sessionChannel)
					{
						return sessionChannel.Session.Id;
					}
					if (innerChannel is ISessionChannel<IInputSession> { Session: not null } sessionChannel2)
					{
						return sessionChannel2.Session.Id;
					}
					if (innerChannel is ISessionChannel<IOutputSession> { Session: not null } sessionChannel3)
					{
						return sessionChannel3.Session.Id;
					}
				}
			}
			return null;
		}
	}

	internal IPrincipal ThreadPrincipal
	{
		get
		{
			return threadPrincipal;
		}
		set
		{
			threadPrincipal = value;
		}
	}

	public ClaimsPrincipal ClaimsPrincipal { get; internal set; }

	public event EventHandler OperationCompleted;

	static OperationContext()
	{
		DisableAsyncFlow = AppContext.TryGetSwitch("System.ServiceModel.OperationContext.DisableAsyncFlow", out var isEnabled) && isEnabled;
		if (!DisableAsyncFlow)
		{
			s_asyncContext = new AsyncLocal<OperationContext>();
		}
	}

	public OperationContext(IContextChannel channel)
	{
		if (channel == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("channel"));
		}
		ServiceChannel serviceChannel = channel as ServiceChannel;
		if (serviceChannel == null)
		{
			serviceChannel = ServiceChannelFactory.GetServiceChannel(channel);
		}
		if (serviceChannel != null)
		{
			OutgoingMessageVersion = serviceChannel.MessageVersion;
			InternalServiceChannel = serviceChannel;
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxInvalidChannelToOperationContext));
	}

	internal OperationContext()
		: this(MessageVersion.Soap12WSAddressing10)
	{
	}

	internal OperationContext(MessageVersion outgoingMessageVersion)
	{
		OutgoingMessageVersion = outgoingMessageVersion ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("outgoingMessageVersion"));
	}

	internal OperationContext(RequestContext requestContext, Message request, ServiceChannel channel)
	{
		InternalServiceChannel = channel;
		RequestContext = requestContext;
		_request = request;
		OutgoingMessageVersion = channel.MessageVersion;
	}

	internal void ClearClientReplyNoThrow()
	{
		_clientReply = null;
	}

	internal void FireOperationCompleted()
	{
		try
		{
			this.OperationCompleted?.Invoke(this, EventArgs.Empty);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	public T GetCallbackChannel<T>()
	{
		if (InternalServiceChannel == null || IsUserContext)
		{
			return default(T);
		}
		return (T)InternalServiceChannel.Proxy;
	}

	internal void ReInit(RequestContext requestContext, Message request, ServiceChannel channel)
	{
		RequestContext = requestContext;
		_request = request;
		InternalServiceChannel = channel;
	}

	internal void Recycle()
	{
		RequestContext = null;
		_request = null;
		_extensions = null;
		InstanceContext = null;
		threadPrincipal = null;
		SetClientReply(null, closeMessage: false);
	}

	internal void SetClientReply(Message message, bool closeMessage)
	{
		Message message2 = null;
		if (!object.Equals(message, _clientReply))
		{
			if (_closeClientReply && _clientReply != null)
			{
				message2 = _clientReply;
			}
			_clientReply = message;
		}
		_closeClientReply = closeMessage;
		message2?.Close();
	}

	internal void SetInstanceContext(InstanceContext instanceContext)
	{
		InstanceContext = instanceContext;
	}
}
