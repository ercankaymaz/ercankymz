// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpServiceHost
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public abstract class TcpServiceHost : 
  ITransportListenerFactory,
  ITransportBindingFactory<ITransportListener>,
  ITransportBindingScheme
{
  public abstract string UriScheme { get; }

  public abstract ITransportListener Create();

  public List<EndpointDescription> CreateServiceHost(
    ServerBase serverBase,
    IDictionary<string, ServiceHost> hosts,
    ApplicationConfiguration configuration,
    IList<string> baseAddresses,
    ApplicationDescription serverDescription,
    List<ServerSecurityPolicy> securityPolicies,
    X509Certificate2 instanceCertificate,
    X509Certificate2Collection instanceCertificateChain)
  {
    string key = "/Tcp";
    if (hosts.ContainsKey(key))
      key += Utils.Format("/{0}", (object) hosts.Count);
    List<Uri> uriList = new List<Uri>();
    EndpointDescriptionCollection serviceHost = new EndpointDescriptionCollection();
    EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(configuration);
    string hostName = Utils.GetHostName();
    for (int index1 = 0; index1 < baseAddresses.Count; ++index1)
    {
      if (baseAddresses[index1].StartsWith("opc.tcp", StringComparison.Ordinal))
      {
        UriBuilder uriBuilder = new UriBuilder(baseAddresses[index1]);
        if (string.Equals(uriBuilder.Host, "localhost", StringComparison.OrdinalIgnoreCase))
          uriBuilder.Host = hostName;
        ITransportListener listener = this.Create();
        if (listener != null)
        {
          EndpointDescriptionCollection descriptionCollection = new EndpointDescriptionCollection();
          uriList.Add(uriBuilder.Uri);
          foreach (ServerSecurityPolicy securityPolicy in securityPolicies)
          {
            EndpointDescription description = new EndpointDescription()
            {
              EndpointUrl = uriBuilder.ToString(),
              Server = serverDescription,
              SecurityMode = securityPolicy.SecurityMode,
              SecurityPolicyUri = securityPolicy.SecurityPolicyUri,
              SecurityLevel = ServerSecurityPolicy.CalculateSecurityLevel(securityPolicy.SecurityMode, securityPolicy.SecurityPolicyUri)
            };
            description.UserIdentityTokens = serverBase.GetUserTokenPolicies(configuration, description);
            description.TransportProfileUri = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";
            if (ServerBase.RequireEncryption(description))
            {
              description.ServerCertificate = instanceCertificate.RawData;
              if (configuration.SecurityConfiguration.SendCertificateChain && instanceCertificateChain != null && instanceCertificateChain.Count > 1)
              {
                List<byte> byteList = new List<byte>();
                for (int index2 = 0; index2 < instanceCertificateChain.Count; ++index2)
                  byteList.AddRange((IEnumerable<byte>) instanceCertificateChain[index2].RawData);
                description.ServerCertificate = byteList.ToArray();
              }
            }
            descriptionCollection.Add(description);
          }
          serverBase.CreateServiceHostEndpoint(uriBuilder.Uri, descriptionCollection, endpointConfiguration, listener, configuration.CertificateValidator.GetChannelValidator());
          serviceHost.AddRange((IEnumerable<EndpointDescription>) descriptionCollection);
        }
        else
          Utils.LogError("Failed to create endpoint {0} because the transport profile is unsupported.", (object) uriBuilder);
      }
    }
    hosts[key] = serverBase.CreateServiceHost(serverBase, uriList.ToArray());
    return (List<EndpointDescription>) serviceHost;
  }
}
