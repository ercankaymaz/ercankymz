using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface IDiscoveryServer : IServerBase, IAuditEventCallback
{
	ResponseHeader FindServers(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection serverUris, out ApplicationDescriptionCollection servers);

	ResponseHeader FindServersOnNetwork(RequestHeader requestHeader, uint startingRecordId, uint maxRecordsToReturn, StringCollection serverCapabilityFilter, out DateTime lastCounterResetTime, out ServerOnNetworkCollection servers);

	ResponseHeader GetEndpoints(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection profileUris, out EndpointDescriptionCollection endpoints);

	ResponseHeader RegisterServer(RequestHeader requestHeader, RegisteredServer server);

	ResponseHeader RegisterServer2(RequestHeader requestHeader, RegisteredServer server, ExtensionObjectCollection discoveryConfiguration, out StatusCodeCollection configurationResults, out DiagnosticInfoCollection diagnosticInfos);
}
