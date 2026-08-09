using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DiscoveryChannel : UaChannelBase<IDiscoveryChannel>, IDiscoveryChannel, IChannelBase
{
	public static ITransportChannel Create(Uri discoveryUrl, EndpointConfiguration endpointConfiguration, IServiceMessageContext messageContext, X509Certificate2 clientCertificate = null)
	{
		EndpointDescription endpointDescription = new EndpointDescription
		{
			EndpointUrl = discoveryUrl.OriginalString,
			SecurityMode = MessageSecurityMode.None,
			SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None"
		};
		endpointDescription.Server.ApplicationUri = endpointDescription.EndpointUrl;
		endpointDescription.Server.ApplicationType = ApplicationType.DiscoveryServer;
		return UaChannelBase.CreateUaBinaryChannel(null, endpointDescription, endpointConfiguration, clientCertificate, messageContext);
	}

	public static ITransportChannel Create(ApplicationConfiguration configuration, ITransportWaitingConnection connection, EndpointConfiguration endpointConfiguration, IServiceMessageContext messageContext, X509Certificate2 clientCertificate = null)
	{
		EndpointDescription endpointDescription = new EndpointDescription
		{
			EndpointUrl = connection.EndpointUrl.OriginalString,
			SecurityMode = MessageSecurityMode.None,
			SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None"
		};
		endpointDescription.Server.ApplicationUri = endpointDescription.EndpointUrl;
		endpointDescription.Server.ApplicationType = ApplicationType.DiscoveryServer;
		return UaChannelBase.CreateUaBinaryChannel(configuration, connection, endpointDescription, endpointConfiguration, clientCertificate, null, messageContext);
	}

	public static ITransportChannel Create(ApplicationConfiguration configuration, Uri discoveryUrl, EndpointConfiguration endpointConfiguration, IServiceMessageContext messageContext, X509Certificate2 clientCertificate = null)
	{
		EndpointDescription endpointDescription = new EndpointDescription
		{
			EndpointUrl = discoveryUrl.OriginalString,
			SecurityMode = MessageSecurityMode.None,
			SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None"
		};
		endpointDescription.Server.ApplicationUri = endpointDescription.EndpointUrl;
		endpointDescription.Server.ApplicationType = ApplicationType.DiscoveryServer;
		return UaChannelBase.CreateUaBinaryChannel(configuration, endpointDescription, endpointConfiguration, clientCertificate, null, messageContext);
	}

	internal DiscoveryChannel()
	{
	}

	public FindServersResponseMessage FindServers(FindServersMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginFindServers(request, null, null);
		}
		return base.Channel.EndFindServers(result);
	}

	public IAsyncResult BeginFindServers(FindServersMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginFindServers(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public FindServersResponseMessage EndFindServers(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndFindServers(uaChannelAsyncResult.InnerResult);
	}

	public Task<FindServersResponseMessage> FindServersAsync(FindServersMessage request)
	{
		return base.Channel.FindServersAsync(request);
	}

	public FindServersOnNetworkResponseMessage FindServersOnNetwork(FindServersOnNetworkMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginFindServersOnNetwork(request, null, null);
		}
		return base.Channel.EndFindServersOnNetwork(result);
	}

	public IAsyncResult BeginFindServersOnNetwork(FindServersOnNetworkMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginFindServersOnNetwork(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public FindServersOnNetworkResponseMessage EndFindServersOnNetwork(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndFindServersOnNetwork(uaChannelAsyncResult.InnerResult);
	}

	public Task<FindServersOnNetworkResponseMessage> FindServersOnNetworkAsync(FindServersOnNetworkMessage request)
	{
		return base.Channel.FindServersOnNetworkAsync(request);
	}

	public GetEndpointsResponseMessage GetEndpoints(GetEndpointsMessage request)
	{
		IAsyncResult result = null;
		lock (base.Channel)
		{
			result = base.Channel.BeginGetEndpoints(request, null, null);
		}
		return base.Channel.EndGetEndpoints(result);
	}

	public IAsyncResult BeginGetEndpoints(GetEndpointsMessage request, AsyncCallback callback, object asyncState)
	{
		UaChannelAsyncResult uaChannelAsyncResult = new UaChannelAsyncResult(base.Channel, callback, asyncState);
		lock (uaChannelAsyncResult.Lock)
		{
			uaChannelAsyncResult.InnerResult = uaChannelAsyncResult.Channel.BeginGetEndpoints(request, uaChannelAsyncResult.OnOperationCompleted, null);
			return uaChannelAsyncResult;
		}
	}

	public GetEndpointsResponseMessage EndGetEndpoints(IAsyncResult result)
	{
		UaChannelAsyncResult uaChannelAsyncResult = UaChannelAsyncResult.WaitForComplete(result);
		return uaChannelAsyncResult.Channel.EndGetEndpoints(uaChannelAsyncResult.InnerResult);
	}

	public Task<GetEndpointsResponseMessage> GetEndpointsAsync(GetEndpointsMessage request)
	{
		return base.Channel.GetEndpointsAsync(request);
	}
}
