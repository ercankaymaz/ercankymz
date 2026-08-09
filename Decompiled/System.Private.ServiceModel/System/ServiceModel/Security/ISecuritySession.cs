using System.ServiceModel.Channels;

namespace System.ServiceModel.Security;

public interface ISecuritySession : ISession
{
	EndpointIdentity RemoteIdentity { get; }
}
