using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class DefaultSessionFactory : ISessionFactory, ISessionInstantiator
{
	public static readonly DefaultSessionFactory Instance = new DefaultSessionFactory();

	protected DefaultSessionFactory()
	{
	}

	public virtual Task<ISession> CreateAsync(ApplicationConfiguration configuration, ConfiguredEndpoint endpoint, bool updateBeforeConnect, string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		return CreateAsync(configuration, endpoint, updateBeforeConnect, checkDomain: false, sessionName, sessionTimeout, identity, preferredLocales, ct);
	}

	public virtual async Task<ISession> CreateAsync(ApplicationConfiguration configuration, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		return await Session.Create((ISessionInstantiator)this, configuration, (ITransportWaitingConnection)null, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	public virtual async Task<ISession> CreateAsync(ApplicationConfiguration configuration, ITransportWaitingConnection connection, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity identity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		return await Session.Create(this, configuration, connection, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, identity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	public virtual async Task<ISession> CreateAsync(ApplicationConfiguration configuration, ReverseConnectManager reverseConnectManager, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, string sessionName, uint sessionTimeout, IUserIdentity userIdentity, IList<string> preferredLocales, CancellationToken ct = default(CancellationToken))
	{
		if (reverseConnectManager == null)
		{
			return await CreateAsync(configuration, endpoint, updateBeforeConnect, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		ITransportWaitingConnection transportWaitingConnection;
		do
		{
			transportWaitingConnection = await reverseConnectManager.WaitForConnection(endpoint.EndpointUrl, endpoint.ReverseConnect?.ServerUri, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (updateBeforeConnect)
			{
				await endpoint.UpdateFromServerAsync(endpoint.EndpointUrl, transportWaitingConnection, endpoint.Description.SecurityMode, endpoint.Description.SecurityPolicyUri, ct).ConfigureAwait(continueOnCapturedContext: false);
				updateBeforeConnect = false;
				transportWaitingConnection = null;
			}
		}
		while (transportWaitingConnection == null);
		return await CreateAsync(configuration, transportWaitingConnection, endpoint, updateBeforeConnect: false, checkDomain, sessionName, sessionTimeout, userIdentity, preferredLocales, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	public virtual ISession Create(ApplicationConfiguration configuration, ITransportChannel channel, ConfiguredEndpoint endpoint, X509Certificate2 clientCertificate, EndpointDescriptionCollection availableEndpoints = null, StringCollection discoveryProfileUris = null)
	{
		return Session.Create(this, configuration, channel, endpoint, clientCertificate, availableEndpoints, discoveryProfileUris);
	}

	public virtual Task<ITransportChannel> CreateChannelAsync(ApplicationConfiguration configuration, ITransportWaitingConnection connection, ConfiguredEndpoint endpoint, bool updateBeforeConnect, bool checkDomain, CancellationToken ct = default(CancellationToken))
	{
		return Session.CreateChannelAsync(configuration, connection, endpoint, updateBeforeConnect, checkDomain, ct);
	}

	public virtual async Task<ISession> RecreateAsync(ISession sessionTemplate, CancellationToken ct = default(CancellationToken))
	{
		return await Session.RecreateAsync((sessionTemplate as Session) ?? throw new ArgumentOutOfRangeException("sessionTemplate", "The ISession provided is not of a supported type."), ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	public virtual async Task<ISession> RecreateAsync(ISession sessionTemplate, ITransportWaitingConnection connection, CancellationToken ct = default(CancellationToken))
	{
		return await Session.RecreateAsync((sessionTemplate as Session) ?? throw new ArgumentOutOfRangeException("sessionTemplate", "The ISession provided is not of a supported type"), connection, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	public virtual async Task<ISession> RecreateAsync(ISession sessionTemplate, ITransportChannel transportChannel, CancellationToken ct = default(CancellationToken))
	{
		return await Session.RecreateAsync((sessionTemplate as Session) ?? throw new ArgumentOutOfRangeException("sessionTemplate", "The ISession provided is not of a supported type"), transportChannel, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	public virtual Session Create(ISessionChannel channel, ApplicationConfiguration configuration, ConfiguredEndpoint endpoint)
	{
		return new Session(channel, configuration, endpoint);
	}

	public virtual Session Create(ITransportChannel channel, ApplicationConfiguration configuration, ConfiguredEndpoint endpoint, X509Certificate2 clientCertificate, EndpointDescriptionCollection availableEndpoints = null, StringCollection discoveryProfileUris = null)
	{
		return new Session(channel, configuration, endpoint, clientCertificate, availableEndpoints, discoveryProfileUris);
	}
}
