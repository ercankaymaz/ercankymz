using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface ITransportListenerFactory : ITransportBindingFactory<ITransportListener>, ITransportBindingScheme
{
	List<EndpointDescription> CreateServiceHost(ServerBase serverBase, IDictionary<string, ServiceHost> hosts, ApplicationConfiguration configuration, IList<string> baseAddresses, ApplicationDescription serverDescription, List<ServerSecurityPolicy> securityPolicies, X509Certificate2 instanceCertificate, X509Certificate2Collection instanceCertificateChain);
}
