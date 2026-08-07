// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.TraceableSessionFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class TraceableSessionFactory : DefaultSessionFactory
{
  public static readonly TraceableSessionFactory Instance = new TraceableSessionFactory();

  protected TraceableSessionFactory()
  {
  }

  public override async Task<ISession> CreateAsync(
    ApplicationConfiguration configuration,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    string sessionName,
    uint sessionTimeout,
    IUserIdentity identity,
    IList<string> preferredLocales,
    CancellationToken ct = default (CancellationToken))
  {
    ISession async;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateAsync)))
      async = (ISession) new TraceableSession(await base.CreateAsync(configuration, endpoint, updateBeforeConnect, false, sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(false));
    return async;
  }

  public override async Task<ISession> CreateAsync(
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
    TraceableSessionFactory traceableSessionFactory = this;
    ISession async;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateAsync)))
      async = (ISession) new TraceableSession((ISession) await Session.Create((ISessionInstantiator) traceableSessionFactory, configuration, (ITransportWaitingConnection) null, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(false));
    return async;
  }

  public override async Task<ISession> CreateAsync(
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
    TraceableSessionFactory traceableSessionFactory = this;
    ISession async;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateAsync)))
      async = (ISession) new TraceableSession((ISession) await Session.Create((ISessionInstantiator) traceableSessionFactory, configuration, connection, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(false));
    return async;
  }

  public override ISession Create(
    ApplicationConfiguration configuration,
    ITransportChannel channel,
    ConfiguredEndpoint endpoint,
    X509Certificate2 clientCertificate,
    EndpointDescriptionCollection availableEndpoints = null,
    StringCollection discoveryProfileUris = null)
  {
    using (TraceableSession.ActivitySource.StartActivity(nameof (Create)))
      return (ISession) new TraceableSession(base.Create(configuration, channel, endpoint, clientCertificate, availableEndpoints, discoveryProfileUris));
  }

  public override async Task<ITransportChannel> CreateChannelAsync(
    ApplicationConfiguration configuration,
    ITransportWaitingConnection connection,
    ConfiguredEndpoint endpoint,
    bool updateBeforeConnect,
    bool checkDomain,
    CancellationToken ct = default (CancellationToken))
  {
    ITransportChannel channelAsync;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateChannelAsync)))
      channelAsync = await base.CreateChannelAsync(configuration, connection, endpoint, updateBeforeConnect, checkDomain, ct).ConfigureAwait(false);
    return channelAsync;
  }

  public override async Task<ISession> CreateAsync(
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
    ISession async;
    using (TraceableSession.ActivitySource.StartActivity(nameof (CreateAsync)))
      async = (ISession) new TraceableSession(await base.CreateAsync(configuration, reverseConnectManager, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct).ConfigureAwait(false));
    return async;
  }

  public override async Task<ISession> RecreateAsync(ISession sessionTemplate, CancellationToken ct = default (CancellationToken))
  {
    Session sessionTemplate1 = this.ValidateISession(sessionTemplate);
    ISession session;
    using (TraceableSession.ActivitySource.StartActivity(nameof (RecreateAsync)))
      session = (ISession) new TraceableSession((ISession) await Session.RecreateAsync(sessionTemplate1, ct).ConfigureAwait(false));
    return session;
  }

  public override async Task<ISession> RecreateAsync(
    ISession sessionTemplate,
    ITransportWaitingConnection connection,
    CancellationToken ct = default (CancellationToken))
  {
    Session sessionTemplate1 = this.ValidateISession(sessionTemplate);
    ISession session;
    using (TraceableSession.ActivitySource.StartActivity(nameof (RecreateAsync)))
      session = (ISession) new TraceableSession((ISession) await Session.RecreateAsync(sessionTemplate1, connection, ct).ConfigureAwait(false));
    return session;
  }

  public override async Task<ISession> RecreateAsync(
    ISession sessionTemplate,
    ITransportChannel channel,
    CancellationToken ct = default (CancellationToken))
  {
    Session sessionTemplate1 = this.ValidateISession(sessionTemplate);
    ISession session;
    using (TraceableSession.ActivitySource.StartActivity(nameof (RecreateAsync)))
      session = (ISession) new TraceableSession((ISession) await Session.RecreateAsync(sessionTemplate1, channel, ct).ConfigureAwait(false));
    return session;
  }

  private Session ValidateISession(ISession sessionTemplate)
  {
    switch (sessionTemplate)
    {
      case Session session:
label_3:
        return session;
      case TraceableSession traceableSession:
        session = (Session) traceableSession.Session;
        goto label_3;
      default:
        throw new ArgumentOutOfRangeException(nameof (sessionTemplate), "The ISession provided is not of a supported type.");
    }
  }
}
