// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.ISessionFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public interface ISessionFactory
{
  Task<ISession> CreateAsync(
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken));

  Task<ISession> CreateAsync(
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken));

  ISession Create(
    ApplicationConfiguration configuration,
    ITransportChannel channel,
    ConfiguredEndpoint endpoint,
    X509Certificate2 clientCertificate,
    EndpointDescriptionCollection availableEndpoints = null,
    StringCollection discoveryProfileUris = null);

  Task<ITransportChannel> CreateChannelAsync(
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    CancellationToken ct = default (CancellationToken));

  Task<ISession> CreateAsync(
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken));

  Task<ISession> CreateAsync(
    ApplicationConfiguration configuration,
    ReverseConnectManager reverseConnectManager,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity userIdentity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken));

  Task<ISession> RecreateAsync(ISession sessionTemplate, CancellationToken ct = default (CancellationToken));

  Task<ISession> RecreateAsync(
    ISession sessionTemplate,
    ITransportWaitingConnection connection,
    CancellationToken ct = default (CancellationToken));

  Task<ISession> RecreateAsync(
    ISession sessionTemplate,
    ITransportChannel transportChannel,
    CancellationToken ct = default (CancellationToken));
}
