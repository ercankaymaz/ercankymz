using System.ServiceModel.Channels;

namespace System.ServiceModel;

public abstract class DuplexClientBase<TChannel> : ClientBase<TChannel> where TChannel : class
{
	public IDuplexContextChannel InnerDuplexChannel => (IDuplexContextChannel)base.InnerChannel;

	protected DuplexClientBase(InstanceContext callbackInstance)
	{
		throw new PlatformNotSupportedException(System.SR.ConfigurationFilesNotSupported);
	}

	protected DuplexClientBase(InstanceContext callbackInstance, string endpointConfigurationName)
	{
		throw new PlatformNotSupportedException(System.SR.ConfigurationFilesNotSupported);
	}

	protected DuplexClientBase(InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress)
	{
		throw new PlatformNotSupportedException(System.SR.ConfigurationFilesNotSupported);
	}

	protected DuplexClientBase(InstanceContext callbackInstance, string endpointConfigurationName, EndpointAddress remoteAddress)
	{
		throw new PlatformNotSupportedException(System.SR.ConfigurationFilesNotSupported);
	}

	protected DuplexClientBase(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress)
		: base(callbackInstance, binding, remoteAddress)
	{
	}
}
