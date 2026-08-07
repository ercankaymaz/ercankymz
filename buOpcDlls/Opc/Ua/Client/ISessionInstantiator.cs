// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.ISessionInstantiator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public interface ISessionInstantiator
{
  Session Create(
    ISessionChannel channel,
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint);

  Session Create(
    ITransportChannel channel,
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    X509Certificate2 clientCertificate,
    EndpointDescriptionCollection availableEndpoints = null,
    StringCollection discoveryProfileUris = null);
}
