using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public abstract class TcpServiceHost : ITransportListenerFactory, ITransportBindingFactory<ITransportListener>, ITransportBindingScheme
{
	public abstract string UriScheme { get; }

	public abstract ITransportListener Create();

	public List<EndpointDescription> CreateServiceHost(ServerBase serverBase, IDictionary<string, ServiceHost> hosts, ApplicationConfiguration configuration, IList<string> baseAddresses, ApplicationDescription serverDescription, List<ServerSecurityPolicy> securityPolicies, X509Certificate2 instanceCertificate, X509Certificate2Collection instanceCertificateChain)
	{
		string text = "/Tcp";
		if (hosts.ContainsKey(text))
		{
			text += Utils.Format("/{0}", hosts.Count);
		}
		List<Uri> list = new List<Uri>();
		EndpointDescriptionCollection endpointDescriptionCollection = new EndpointDescriptionCollection();
		EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(configuration);
		string hostName = Utils.GetHostName();
		for (int i = 0; i < baseAddresses.Count; i++)
		{
			if (!baseAddresses[i].StartsWith("opc.tcp", StringComparison.Ordinal))
			{
				continue;
			}
			UriBuilder uriBuilder = new UriBuilder(baseAddresses[i]);
			if (string.Equals(uriBuilder.Host, "localhost", StringComparison.OrdinalIgnoreCase))
			{
				uriBuilder.Host = hostName;
			}
			ITransportListener transportListener = Create();
			if (transportListener != null)
			{
				EndpointDescriptionCollection endpointDescriptionCollection2 = new EndpointDescriptionCollection();
				list.Add(uriBuilder.Uri);
				foreach (ServerSecurityPolicy securityPolicy in securityPolicies)
				{
					EndpointDescription endpointDescription = new EndpointDescription();
					endpointDescription.EndpointUrl = uriBuilder.ToString();
					endpointDescription.Server = serverDescription;
					endpointDescription.SecurityMode = securityPolicy.SecurityMode;
					endpointDescription.SecurityPolicyUri = securityPolicy.SecurityPolicyUri;
					endpointDescription.SecurityLevel = ServerSecurityPolicy.CalculateSecurityLevel(securityPolicy.SecurityMode, securityPolicy.SecurityPolicyUri);
					endpointDescription.UserIdentityTokens = serverBase.GetUserTokenPolicies(configuration, endpointDescription);
					endpointDescription.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";
					if (ServerBase.RequireEncryption(endpointDescription))
					{
						endpointDescription.ServerCertificate = instanceCertificate.RawData;
						if (configuration.SecurityConfiguration.SendCertificateChain && instanceCertificateChain != null && instanceCertificateChain.Count > 1)
						{
							List<byte> list2 = new List<byte>();
							for (int j = 0; j < instanceCertificateChain.Count; j++)
							{
								list2.AddRange(instanceCertificateChain[j].RawData);
							}
							endpointDescription.ServerCertificate = list2.ToArray();
						}
					}
					endpointDescriptionCollection2.Add(endpointDescription);
				}
				serverBase.CreateServiceHostEndpoint(uriBuilder.Uri, endpointDescriptionCollection2, endpointConfiguration, transportListener, configuration.CertificateValidator.GetChannelValidator());
				endpointDescriptionCollection.AddRange(endpointDescriptionCollection2);
			}
			else
			{
				Utils.LogError("Failed to create endpoint {0} because the transport profile is unsupported.", uriBuilder);
			}
		}
		hosts[text] = serverBase.CreateServiceHost(serverBase, list.ToArray());
		return endpointDescriptionCollection;
	}
}
