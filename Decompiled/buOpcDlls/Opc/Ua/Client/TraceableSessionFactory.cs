using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class TraceableSessionFactory : DefaultSessionFactory
{
	public new static readonly TraceableSessionFactory Instance = new TraceableSessionFactory();

	protected TraceableSessionFactory()
	{
	}

	public override async Task<ISession> CreateAsync(ApplicationConfiguration configuration, ConfiguredEndpoint endpoint, bool updateBeforeConnect, string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		using (TraceableSession.ActivitySource.StartActivity("CreateAsync"))
		{
			return new TraceableSession(await base.CreateAsync(configuration, endpoint, updateBeforeConnect, checkDomain: false, sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false));
		}
	}

	public override async Task<ISession> CreateAsync(ApplicationConfiguration configuration, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		using (TraceableSession.ActivitySource.StartActivity("CreateAsync"))
		{
			return new TraceableSession(await Session.Create((ISessionInstantiator)this, configuration, (ITransportWaitingConnection)null, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false));
		}
	}

	public override async Task<ISession> CreateAsync(ApplicationConfiguration configuration, ITransportWaitingConnection connection, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		using (TraceableSession.ActivitySource.StartActivity("CreateAsync"))
		{
			return new TraceableSession(await Session.Create(this, configuration, connection, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false));
		}
	}

	public override ISession Create(ApplicationConfiguration configuration, ITransportChannel channel, ConfiguredEndpoint endpoint, X509Certificate2 clientCertificate, EndpointDescriptionCollection availableEndpoints = null, StringCollection discoveryProfileUris = null)
	{
		using (TraceableSession.ActivitySource.StartActivity("Create"))
		{
			return new TraceableSession(base.Create(configuration, channel, endpoint, clientCertificate, availableEndpoints, discoveryProfileUris));
		}
	}

	public override async Task<ITransportChannel> CreateChannelAsync(ApplicationConfiguration configuration, ITransportWaitingConnection connection, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, CancellationToken ct = default(CancellationToken))
	{
		using (TraceableSession.ActivitySource.StartActivity("CreateChannelAsync"))
		{
			return await base.CreateChannelAsync(configuration, connection, endpoint, updateBeforeConnect, checkDomain, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public override async Task<ISession> CreateAsync(ApplicationConfiguration configuration, ReverseConnectManager reverseConnectManager, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity userIdentity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		using (TraceableSession.ActivitySource.StartActivity("CreateAsync"))
		{
			return new TraceableSession(await base.CreateAsync(configuration, reverseConnectManager, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false));
		}
	}

	public override async Task<ISession> RecreateAsync(ISession sessionTemplate, CancellationToken ct = default(CancellationToken))
	{
		Session sessionTemplate2 = ValidateISession(sessionTemplate);
		using (TraceableSession.ActivitySource.StartActivity("RecreateAsync"))
		{
			return new TraceableSession(await Session.RecreateAsync(sessionTemplate2, ct).ConfigureAwait(continueOnCapturedContext: false));
		}
	}

	public override async Task<ISession> RecreateAsync(ISession sessionTemplate, ITransportWaitingConnection connection, CancellationToken ct = default(CancellationToken))
	{
		Session sessionTemplate2 = ValidateISession(sessionTemplate);
		using (TraceableSession.ActivitySource.StartActivity("RecreateAsync"))
		{
			return new TraceableSession(await Session.RecreateAsync(sessionTemplate2, connection, ct).ConfigureAwait(continueOnCapturedContext: false));
		}
	}

	public override async Task<ISession> RecreateAsync(ISession sessionTemplate, ITransportChannel channel, CancellationToken ct = default(CancellationToken))
	{
		Session sessionTemplate2 = ValidateISession(sessionTemplate);
		using (TraceableSession.ActivitySource.StartActivity("RecreateAsync"))
		{
			return new TraceableSession(await Session.RecreateAsync(sessionTemplate2, channel, ct).ConfigureAwait(continueOnCapturedContext: false));
		}
	}

	private Session ValidateISession(ISession sessionTemplate)
	{
		Session session = sessionTemplate as Session;
		if (session == null)
		{
			if (!(sessionTemplate is TraceableSession traceableSession))
			{
				throw new ArgumentOutOfRangeException("sessionTemplate", "The ISession provided is not of a supported type.");
			}
			session = (Session)traceableSession.Session;
		}
		return session;
	}
}
