using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface IDiscoveryClientMethods
{
	ResponseHeader FindServers(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection serverUris, out ApplicationDescriptionCollection servers);

	IAsyncResult BeginFindServers(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection serverUris, AsyncCallback callback, object asyncState);

	ResponseHeader EndFindServers(IAsyncResult result, out ApplicationDescriptionCollection servers);

	Task<FindServersResponse> FindServersAsync(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection serverUris, CancellationToken ct);

	ResponseHeader FindServersOnNetwork(RequestHeader requestHeader, uint startingRecordId, uint maxRecordsToReturn, StringCollection serverCapabilityFilter, out DateTime lastCounterResetTime, out ServerOnNetworkCollection servers);

	IAsyncResult BeginFindServersOnNetwork(RequestHeader requestHeader, uint startingRecordId, uint maxRecordsToReturn, StringCollection serverCapabilityFilter, AsyncCallback callback, object asyncState);

	ResponseHeader EndFindServersOnNetwork(IAsyncResult result, out DateTime lastCounterResetTime, out ServerOnNetworkCollection servers);

	Task<FindServersOnNetworkResponse> FindServersOnNetworkAsync(RequestHeader requestHeader, uint startingRecordId, uint maxRecordsToReturn, StringCollection serverCapabilityFilter, CancellationToken ct);

	ResponseHeader GetEndpoints(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection profileUris, out EndpointDescriptionCollection endpoints);

	IAsyncResult BeginGetEndpoints(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection profileUris, AsyncCallback callback, object asyncState);

	ResponseHeader EndGetEndpoints(IAsyncResult result, out EndpointDescriptionCollection endpoints);

	Task<GetEndpointsResponse> GetEndpointsAsync(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection profileUris, CancellationToken ct);
}
