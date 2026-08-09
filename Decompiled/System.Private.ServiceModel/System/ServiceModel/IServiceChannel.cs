using System.ServiceModel.Channels;

namespace System.ServiceModel;

public interface IServiceChannel : IContextChannel, IChannel, ICommunicationObject, IExtensibleObject<IContextChannel>
{
	Uri ListenUri { get; }
}
