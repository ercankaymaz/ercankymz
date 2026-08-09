using System.Runtime;
using System.ServiceModel.Description;

namespace System.ServiceModel.Channels;

public abstract class Binding : IDefaultCommunicationTimeouts
{
	private TimeSpan _closeTimeout = ServiceDefaults.CloseTimeout;

	private string _name;

	private string _namespaceIdentifier;

	private TimeSpan _openTimeout = ServiceDefaults.OpenTimeout;

	private TimeSpan _receiveTimeout = ServiceDefaults.ReceiveTimeout;

	private TimeSpan _sendTimeout = ServiceDefaults.SendTimeout;

	internal const string DefaultNamespace = "http://tempuri.org/";

	public TimeSpan CloseTimeout
	{
		get
		{
			return _closeTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRange0));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_closeTimeout = value;
		}
	}

	public string Name
	{
		get
		{
			if (_name == null)
			{
				_name = GetType().Name;
			}
			return _name;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("value", System.SR.SFXBindingNameCannotBeNullOrEmpty);
			}
			_name = value;
		}
	}

	public string Namespace
	{
		get
		{
			return _namespaceIdentifier;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value.Length > 0)
			{
				NamingHelper.CheckUriProperty(value, "Namespace");
			}
			_namespaceIdentifier = value;
		}
	}

	public TimeSpan OpenTimeout
	{
		get
		{
			return _openTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRange0));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_openTimeout = value;
		}
	}

	public TimeSpan ReceiveTimeout
	{
		get
		{
			return _receiveTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRange0));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_receiveTimeout = value;
		}
	}

	public abstract string Scheme { get; }

	public MessageVersion MessageVersion => GetProperty<MessageVersion>(new BindingParameterCollection());

	public TimeSpan SendTimeout
	{
		get
		{
			return _sendTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRange0));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_sendTimeout = value;
		}
	}

	protected Binding()
	{
		_name = null;
		_namespaceIdentifier = "http://tempuri.org/";
	}

	protected Binding(string name, string ns)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("name", System.SR.SFXBindingNameCannotBeNullOrEmpty);
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("ns");
		}
		if (ns.Length > 0)
		{
			NamingHelper.CheckUriParameter(ns, "ns");
		}
		_name = name;
		_namespaceIdentifier = ns;
	}

	public IChannelFactory<TChannel> BuildChannelFactory<TChannel>(params object[] parameters)
	{
		return BuildChannelFactory<TChannel>(new BindingParameterCollection(parameters));
	}

	public virtual IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingParameterCollection parameters)
	{
		EnsureInvariants();
		BindingContext bindingContext = new BindingContext(new CustomBinding(this), parameters);
		IChannelFactory<TChannel> channelFactory = bindingContext.BuildInnerChannelFactory<TChannel>();
		bindingContext.ValidateBindingElementsConsumed();
		ValidateSecurityCapabilities(channelFactory.GetProperty<ISecurityCapabilities>(), parameters);
		return channelFactory;
	}

	private void ValidateSecurityCapabilities(ISecurityCapabilities runtimeSecurityCapabilities, BindingParameterCollection parameters)
	{
		ISecurityCapabilities property = GetProperty<ISecurityCapabilities>(parameters);
		if (!SecurityCapabilities.IsEqual(property, runtimeSecurityCapabilities))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SecurityCapabilitiesMismatched, this)));
		}
	}

	public bool CanBuildChannelFactory<TChannel>(params object[] parameters)
	{
		return CanBuildChannelFactory<TChannel>(new BindingParameterCollection(parameters));
	}

	public virtual bool CanBuildChannelFactory<TChannel>(BindingParameterCollection parameters)
	{
		BindingContext bindingContext = new BindingContext(new CustomBinding(this), parameters);
		return bindingContext.CanBuildInnerChannelFactory<TChannel>();
	}

	public abstract BindingElementCollection CreateBindingElements();

	public T GetProperty<T>(BindingParameterCollection parameters) where T : class
	{
		BindingContext bindingContext = new BindingContext(new CustomBinding(this), parameters);
		return bindingContext.GetInnerProperty<T>();
	}

	private void EnsureInvariants()
	{
		EnsureInvariants(null);
	}

	internal void EnsureInvariants(string contractName)
	{
		BindingElementCollection bindingElementCollection = CreateBindingElements();
		TransportBindingElement transportBindingElement = null;
		int i;
		for (i = 0; i < bindingElementCollection.Count; i++)
		{
			transportBindingElement = bindingElementCollection[i] as TransportBindingElement;
			if (transportBindingElement != null)
			{
				break;
			}
		}
		if (transportBindingElement == null)
		{
			if (contractName == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.CustomBindingRequiresTransport, Name)));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxCustomBindingNeedsTransport1, contractName)));
		}
		if (i != bindingElementCollection.Count - 1)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TransportBindingElementMustBeLast, Name, transportBindingElement.GetType().Name)));
		}
		if (string.IsNullOrEmpty(transportBindingElement.Scheme))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.InvalidBindingScheme, transportBindingElement.GetType().Name)));
		}
		if (MessageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.MessageVersionMissingFromBinding, Name)));
		}
	}

	internal void CopyTimeouts(IDefaultCommunicationTimeouts source)
	{
		CloseTimeout = source.CloseTimeout;
		OpenTimeout = source.OpenTimeout;
		ReceiveTimeout = source.ReceiveTimeout;
		SendTimeout = source.SendTimeout;
	}
}
