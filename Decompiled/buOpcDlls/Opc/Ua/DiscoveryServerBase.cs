using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DiscoveryServerBase : ServerBase, IDiscoveryServer, IServerBase, IAuditEventCallback
{
	public virtual ResponseHeader FindServers(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection serverUris, out ApplicationDescriptionCollection servers)
	{
		servers = null;
		ValidateRequest(requestHeader);
		return CreateResponse(requestHeader, 2148204544u);
	}

	public virtual ResponseHeader FindServersOnNetwork(RequestHeader requestHeader, uint startingRecordId, uint maxRecordsToReturn, StringCollection serverCapabilityFilter, out DateTime lastCounterResetTime, out ServerOnNetworkCollection servers)
	{
		lastCounterResetTime = DateTime.MinValue;
		servers = null;
		ValidateRequest(requestHeader);
		return CreateResponse(requestHeader, 2148204544u);
	}

	public virtual ResponseHeader GetEndpoints(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection profileUris, out EndpointDescriptionCollection endpoints)
	{
		endpoints = null;
		ValidateRequest(requestHeader);
		return CreateResponse(requestHeader, 2148204544u);
	}

	public virtual ResponseHeader RegisterServer(RequestHeader requestHeader, RegisteredServer server)
	{
		ValidateRequest(requestHeader);
		return CreateResponse(requestHeader, 2148204544u);
	}

	public virtual ResponseHeader RegisterServer2(RequestHeader requestHeader, RegisteredServer server, ExtensionObjectCollection discoveryConfiguration, out StatusCodeCollection configurationResults, out DiagnosticInfoCollection diagnosticInfos)
	{
		configurationResults = null;
		diagnosticInfos = null;
		ValidateRequest(requestHeader);
		return CreateResponse(requestHeader, 2148204544u);
	}
}
