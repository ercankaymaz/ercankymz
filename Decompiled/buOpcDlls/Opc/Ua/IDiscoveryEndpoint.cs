using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface IDiscoveryEndpoint : IEndpointBase
{
	IAsyncResult BeginFindServers(FindServersMessage request, AsyncCallback callback, object asyncState);

	FindServersResponseMessage EndFindServers(IAsyncResult result);

	IAsyncResult BeginFindServersOnNetwork(FindServersOnNetworkMessage request, AsyncCallback callback, object asyncState);

	FindServersOnNetworkResponseMessage EndFindServersOnNetwork(IAsyncResult result);

	IAsyncResult BeginGetEndpoints(GetEndpointsMessage request, AsyncCallback callback, object asyncState);

	GetEndpointsResponseMessage EndGetEndpoints(IAsyncResult result);
}
