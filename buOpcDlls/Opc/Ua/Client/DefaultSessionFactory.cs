// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.DefaultSessionFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class DefaultSessionFactory : ISessionFactory, ISessionInstantiator
{
  public static readonly DefaultSessionFactory Instance = new DefaultSessionFactory();

  protected DefaultSessionFactory()
  {
  }

  public virtual Task<ISession> CreateAsync(
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    return this.CreateAsync(configuration, endpoint, updateBeforeConnect, false, sessionName, sessionTimeout, identity, preferredLocales, ct);
  }

  public virtual async Task<ISession> CreateAsync(
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    return (ISession) await Session.Create((ISessionInstantiator) this, configuration, (ITransportWaitingConnection) null, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(false);
  }

  public virtual async Task<ISession> CreateAsync(
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    return (ISession) await Session.Create((ISessionInstantiator) this, configuration, connection, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(false);
  }

  public virtual async Task<ISession> CreateAsync(
    ApplicationConfiguration configuration,
    ReverseConnectManager reverseConnectManager,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity userIdentity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    if (reverseConnectManager == null)
      return await this.CreateAsync(configuration, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct).ConfigureAwait(false);
    ConfiguredTaskAwaitable<ITransportWaitingConnection>.ConfiguredTaskAwaiter awaiter1;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter2;
    ITransportWaitingConnection connection;
    do
    {
      awaiter1 = reverseConnectManager.WaitForConnection(endpoint.EndpointUrl, endpoint.ReverseConnect?.ServerUri, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter1.IsCompleted)
      {
        connection = awaiter1.GetResult();
        if (updateBeforeConnect)
          goto label_5;
label_4:
        continue;
label_5:
        awaiter2 = endpoint.UpdateFromServerAsync(endpoint.EndpointUrl, connection, endpoint.Description.SecurityMode, endpoint.Description.SecurityPolicyUri, ct).ConfigureAwait(false).GetAwaiter();
        if (awaiter2.IsCompleted)
        {
          awaiter2.GetResult();
          updateBeforeConnect = false;
          connection = (ITransportWaitingConnection) null;
          goto label_4;
        }
        goto label_8;
      }
      goto label_7;
    }
    while (connection == null);
    goto label_9;
label_7:
    int num = 1;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003E1__state = 1;
    ConfiguredTaskAwaitable<ITransportWaitingConnection>.ConfiguredTaskAwaiter configuredTaskAwaiter1 = awaiter1;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<ITransportWaitingConnection>.ConfiguredTaskAwaiter, DefaultSessionFactory.\u003CCreateAsync\u003Ed__5>(ref awaiter1, this);
    return;
label_8:
    num = 2;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003E1__state = 2;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter2 = awaiter2;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, DefaultSessionFactory.\u003CCreateAsync\u003Ed__5>(ref awaiter2, this);
    return;
label_9:
    return await this.CreateAsync(configuration, connection, endpoint, false, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct).ConfigureAwait(false);
  }

  public virtual ISession Create(
    ApplicationConfiguration configuration,
    ITransportChannel channel,
    ConfiguredEndpoint endpoint,
    X509Certificate2 clientCertificate,
    EndpointDescriptionCollection availableEndpoints = null,
    StringCollection discoveryProfileUris = null)
  {
    return (ISession) Session.Create((ISessionInstantiator) this, configuration, channel, endpoint, clientCertificate, availableEndpoints, discoveryProfileUris);
  }

  public virtual Task<ITransportChannel> CreateChannelAsync(
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    CancellationToken ct = default (CancellationToken))
  {
    return Session.CreateChannelAsync(configuration, connection, endpoint, updateBeforeConnect, checkDomain, ct);
  }

  public virtual async Task<ISession> RecreateAsync(ISession sessionTemplate, CancellationToken ct = default (CancellationToken))
  {
    if (!(sessionTemplate is Session sessionTemplate1))
      throw new ArgumentOutOfRangeException(nameof (sessionTemplate), "The ISession provided is not of a supported type.");
    return (ISession) await Session.RecreateAsync(sessionTemplate1, ct).ConfigureAwait(false);
  }

  public virtual async Task<ISession> RecreateAsync(
    ISession sessionTemplate,
    ITransportWaitingConnection connection,
    CancellationToken ct = default (CancellationToken))
  {
    if (!(sessionTemplate is Session sessionTemplate1))
      throw new ArgumentOutOfRangeException(nameof (sessionTemplate), "The ISession provided is not of a supported type");
    return (ISession) await Session.RecreateAsync(sessionTemplate1, connection, ct).ConfigureAwait(false);
  }

  public virtual async Task<ISession> RecreateAsync(
    ISession sessionTemplate,
    ITransportChannel transportChannel,
    CancellationToken ct = default (CancellationToken))
  {
    if (!(sessionTemplate is Session sessionTemplate1))
      throw new ArgumentOutOfRangeException(nameof (sessionTemplate), "The ISession provided is not of a supported type");
    return (ISession) await Session.RecreateAsync(sessionTemplate1, transportChannel, ct).ConfigureAwait(false);
  }

  public virtual Session Create(
    ISessionChannel channel,
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint)
  {
    return new Session(channel, configuration, endpoint);
  }

  public virtual Session Create(
    ITransportChannel channel,
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    X509Certificate2 clientCertificate,
    EndpointDescriptionCollection availableEndpoints = null,
    StringCollection discoveryProfileUris = null)
  {
    return new Session(channel, configuration, endpoint, clientCertificate, availableEndpoints, discoveryProfileUris);
  }
}
