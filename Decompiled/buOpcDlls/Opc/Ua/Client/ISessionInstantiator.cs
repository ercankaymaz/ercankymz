using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Client;

[ComVisible(true)]
public interface ISessionInstantiator
{
	Session Create(ISessionChannel channel, ApplicationConfiguration configuration, ConfiguredEndpoint endpoint);

	Session Create(ITransportChannel channel, ApplicationConfiguration configuration, ConfiguredEndpoint endpoint, X509Certificate2 clientCertificate, EndpointDescriptionCollection availableEndpoints = null, StringCollection discoveryProfileUris = null);
}
