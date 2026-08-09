using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel;

public class DuplexChannelFactory<TChannel> : ChannelFactory<TChannel>
{
	public DuplexChannelFactory(Type callbackInstanceType)
		: this((object)callbackInstanceType)
	{
	}

	public DuplexChannelFactory(Type callbackInstanceType, Binding binding, string remoteAddress)
		: this((object)callbackInstanceType, binding, new EndpointAddress(remoteAddress))
	{
	}

	public DuplexChannelFactory(Type callbackInstanceType, Binding binding, EndpointAddress remoteAddress)
		: this((object)callbackInstanceType, binding, remoteAddress)
	{
	}

	public DuplexChannelFactory(Type callbackInstanceType, Binding binding)
		: this((object)callbackInstanceType, binding)
	{
	}

	public DuplexChannelFactory(Type callbackInstanceType, string endpointConfigurationName, EndpointAddress remoteAddress)
		: this((object)callbackInstanceType, endpointConfigurationName, remoteAddress)
	{
	}

	public DuplexChannelFactory(Type callbackInstanceType, string endpointConfigurationName)
		: this((object)callbackInstanceType, endpointConfigurationName)
	{
	}

	public DuplexChannelFactory(Type callbackInstanceType, ServiceEndpoint endpoint)
		: this((object)callbackInstanceType, endpoint)
	{
	}

	public DuplexChannelFactory(InstanceContext callbackInstance)
		: this((object)callbackInstance)
	{
	}

	public DuplexChannelFactory(InstanceContext callbackInstance, Binding binding, string remoteAddress)
		: this((object)callbackInstance, binding, new EndpointAddress(remoteAddress))
	{
	}

	public DuplexChannelFactory(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress)
		: this((object)callbackInstance, binding, remoteAddress)
	{
	}

	public DuplexChannelFactory(InstanceContext callbackInstance, Binding binding)
		: this((object)callbackInstance, binding)
	{
	}

	public DuplexChannelFactory(InstanceContext callbackInstance, string endpointConfigurationName, EndpointAddress remoteAddress)
		: this((object)callbackInstance, endpointConfigurationName, remoteAddress)
	{
	}

	public DuplexChannelFactory(InstanceContext callbackInstance, string endpointConfigurationName)
		: this((object)callbackInstance, endpointConfigurationName)
	{
	}

	public DuplexChannelFactory(InstanceContext callbackInstance, ServiceEndpoint endpoint)
		: this((object)callbackInstance, endpoint)
	{
	}

	public DuplexChannelFactory(object callbackObject)
		: base(typeof(TChannel))
	{
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityConstructChannelFactory, TraceUtility.CreateSourceString(this)), ActivityType.Construct);
		}
		if (callbackObject == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("callbackObject");
		}
		CheckAndAssignCallbackInstance(callbackObject);
		InitializeEndpoint((string)null, (EndpointAddress)null);
	}

	public DuplexChannelFactory(object callbackObject, string endpointConfigurationName)
		: this(callbackObject, endpointConfigurationName, (EndpointAddress)null)
	{
	}

	public DuplexChannelFactory(object callbackObject, string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(typeof(TChannel))
	{
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityConstructChannelFactory, TraceUtility.CreateSourceString(this)), ActivityType.Construct);
		}
		if (callbackObject == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("callbackObject");
		}
		if (endpointConfigurationName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("endpointConfigurationName");
		}
		CheckAndAssignCallbackInstance(callbackObject);
		InitializeEndpoint(endpointConfigurationName, remoteAddress);
	}

	public DuplexChannelFactory(object callbackObject, Binding binding)
		: this(callbackObject, binding, (EndpointAddress)null)
	{
	}

	public DuplexChannelFactory(object callbackObject, Binding binding, string remoteAddress)
		: this(callbackObject, binding, new EndpointAddress(remoteAddress))
	{
	}

	public DuplexChannelFactory(object callbackObject, Binding binding, EndpointAddress remoteAddress)
		: base(typeof(TChannel))
	{
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityConstructChannelFactory, TraceUtility.CreateSourceString(this)), ActivityType.Construct);
		}
		if (callbackObject == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("callbackObject");
		}
		if (binding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("binding");
		}
		CheckAndAssignCallbackInstance(callbackObject);
		InitializeEndpoint(binding, remoteAddress);
	}

	public DuplexChannelFactory(object callbackObject, ServiceEndpoint endpoint)
		: base(typeof(TChannel))
	{
		using ServiceModelActivity activity = (DiagnosticUtility.ShouldUseActivity ? ServiceModelActivity.CreateBoundedActivity() : null);
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity.Start(activity, System.SR.Format(System.SR.ActivityConstructChannelFactory, TraceUtility.CreateSourceString(this)), ActivityType.Construct);
		}
		if (callbackObject == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("callbackObject");
		}
		if (endpoint == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("endpoint");
		}
		CheckAndAssignCallbackInstance(callbackObject);
		InitializeEndpoint(endpoint);
	}

	internal void CheckAndAssignCallbackInstance(object callbackInstance)
	{
		if (callbackInstance is Type)
		{
			base.CallbackType = (Type)callbackInstance;
		}
		else if (callbackInstance is InstanceContext)
		{
			base.CallbackInstance = (InstanceContext)callbackInstance;
		}
		else
		{
			base.CallbackInstance = new InstanceContext(callbackInstance);
		}
	}

	public TChannel CreateChannel(InstanceContext callbackInstance)
	{
		return CreateChannel(callbackInstance, CreateEndpointAddress(base.Endpoint), null);
	}

	public TChannel CreateChannel(InstanceContext callbackInstance, EndpointAddress address)
	{
		if (address == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("address");
		}
		return CreateChannel(callbackInstance, address, address.Uri);
	}

	public override TChannel CreateChannel(EndpointAddress address, Uri via)
	{
		return CreateChannel(base.CallbackInstance, address, via);
	}

	public virtual TChannel CreateChannel(InstanceContext callbackInstance, EndpointAddress address, Uri via)
	{
		if (address == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("address");
		}
		if (base.CallbackType != null && callbackInstance == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxCreateDuplexChannelNoCallback1));
		}
		if (callbackInstance == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxCreateDuplexChannelNoCallback));
		}
		if (callbackInstance.UserObject == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxCreateDuplexChannelNoCallbackUserObject));
		}
		if (!HasDuplexOperations())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxCreateDuplexChannel1, base.Endpoint.Contract.Name)));
		}
		Type type = callbackInstance.UserObject.GetType();
		Type callbackContractType = base.Endpoint.Contract.CallbackContractType;
		if (callbackContractType != null && !callbackContractType.IsAssignableFrom(type))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxCreateDuplexChannelBadCallbackUserObject, callbackContractType)));
		}
		EnsureOpened();
		TChannel val = base.ServiceChannelFactory.CreateChannel<TChannel>(address, via);
		if (val is IDuplexContextChannel duplexContextChannel)
		{
			duplexContextChannel.CallbackInstance = callbackInstance;
		}
		return val;
	}

	private static InstanceContext GetInstanceContextForObject(object callbackObject)
	{
		if (callbackObject is InstanceContext)
		{
			return (InstanceContext)callbackObject;
		}
		return new InstanceContext(callbackObject);
	}

	public static TChannel CreateChannel(object callbackObject, string endpointConfigurationName)
	{
		return CreateChannel(GetInstanceContextForObject(callbackObject), endpointConfigurationName);
	}

	public static TChannel CreateChannel(object callbackObject, Binding binding, EndpointAddress endpointAddress)
	{
		return CreateChannel(GetInstanceContextForObject(callbackObject), binding, endpointAddress);
	}

	public static TChannel CreateChannel(object callbackObject, Binding binding, EndpointAddress endpointAddress, Uri via)
	{
		return CreateChannel(GetInstanceContextForObject(callbackObject), binding, endpointAddress, via);
	}

	public static TChannel CreateChannel(InstanceContext callbackInstance, string endpointConfigurationName)
	{
		DuplexChannelFactory<TChannel> duplexChannelFactory = new DuplexChannelFactory<TChannel>(callbackInstance, endpointConfigurationName);
		TChannel val = duplexChannelFactory.CreateChannel();
		ChannelFactory<TChannel>.SetFactoryToAutoClose(val);
		return val;
	}

	public static TChannel CreateChannel(InstanceContext callbackInstance, Binding binding, EndpointAddress endpointAddress)
	{
		DuplexChannelFactory<TChannel> duplexChannelFactory = new DuplexChannelFactory<TChannel>(callbackInstance, binding, endpointAddress);
		TChannel val = duplexChannelFactory.CreateChannel();
		ChannelFactory<TChannel>.SetFactoryToAutoClose(val);
		return val;
	}

	public static TChannel CreateChannel(InstanceContext callbackInstance, Binding binding, EndpointAddress endpointAddress, Uri via)
	{
		DuplexChannelFactory<TChannel> duplexChannelFactory = new DuplexChannelFactory<TChannel>(callbackInstance, binding);
		TChannel val = duplexChannelFactory.CreateChannel(endpointAddress, via);
		ChannelFactory<TChannel>.SetFactoryToAutoClose(val);
		return val;
	}
}
