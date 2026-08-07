// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.ITransportListenerFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface ITransportListenerFactory : 
  ITransportBindingFactory<ITransportListener>,
  ITransportBindingScheme
{
  List<EndpointDescription> CreateServiceHost(
    ServerBase serverBase,
    IDictionary<string, ServiceHost> hosts,
    ApplicationConfiguration configuration,
    IList<string> baseAddresses,
    ApplicationDescription serverDescription,
    List<ServerSecurityPolicy> securityPolicies,
    X509Certificate2 instanceCertificate,
    X509Certificate2Collection instanceCertificateChain);
}
