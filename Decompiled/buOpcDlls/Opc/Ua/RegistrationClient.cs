using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegistrationClient : ClientBase, IRegistrationClientMethods
{
	public new IRegistrationChannel InnerChannel => (IRegistrationChannel)base.InnerChannel;

	public static RegistrationClient Create(ApplicationConfiguration configuration, EndpointDescription description, EndpointConfiguration endpointConfiguration, X509Certificate2 instanceCertificate)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		if (description == null)
		{
			throw new ArgumentNullException("description");
		}
		return new RegistrationClient(RegistrationChannel.Create(configuration, description, endpointConfiguration, instanceCertificate, new ServiceMessageContext()));
	}

	public RegistrationClient(ITransportChannel channel)
		: base(channel)
	{
	}

	public virtual ResponseHeader RegisterServer(RequestHeader requestHeader, RegisteredServer server)
	{
		RegisterServerRequest registerServerRequest = new RegisterServerRequest();
		RegisterServerResponse registerServerResponse = null;
		registerServerRequest.RequestHeader = requestHeader;
		registerServerRequest.Server = server;
		UpdateRequestHeader(registerServerRequest, requestHeader == null, "RegisterServer");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(registerServerRequest) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			registerServerResponse = (RegisterServerResponse)obj;
		}
		finally
		{
			RequestCompleted(registerServerRequest, registerServerResponse, "RegisterServer");
		}
		return registerServerResponse.ResponseHeader;
	}

	public virtual IAsyncResult BeginRegisterServer(RequestHeader requestHeader, RegisteredServer server, AsyncCallback callback, object asyncState)
	{
		RegisterServerRequest registerServerRequest = new RegisterServerRequest();
		registerServerRequest.RequestHeader = requestHeader;
		registerServerRequest.Server = server;
		UpdateRequestHeader(registerServerRequest, requestHeader == null, "RegisterServer");
		return base.TransportChannel.BeginSendRequest(registerServerRequest, callback, asyncState);
	}

	public virtual ResponseHeader EndRegisterServer(IAsyncResult result)
	{
		RegisterServerResponse registerServerResponse = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			registerServerResponse = (RegisterServerResponse)obj;
		}
		finally
		{
			RequestCompleted(null, registerServerResponse, "RegisterServer");
		}
		return registerServerResponse.ResponseHeader;
	}

	public virtual async Task<RegisterServerResponse> RegisterServerAsync(RequestHeader requestHeader, RegisteredServer server, CancellationToken ct)
	{
		RegisterServerRequest request = new RegisterServerRequest();
		RegisterServerResponse response = null;
		request.RequestHeader = requestHeader;
		request.Server = server;
		UpdateRequestHeader(request, requestHeader == null, "RegisterServer");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (RegisterServerResponse)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "RegisterServer");
		}
		return response;
	}

	public virtual ResponseHeader RegisterServer2(RequestHeader requestHeader, RegisteredServer server, ExtensionObjectCollection discoveryConfiguration, out StatusCodeCollection configurationResults, out DiagnosticInfoCollection diagnosticInfos)
	{
		RegisterServer2Request registerServer2Request = new RegisterServer2Request();
		RegisterServer2Response registerServer2Response = null;
		registerServer2Request.RequestHeader = requestHeader;
		registerServer2Request.Server = server;
		registerServer2Request.DiscoveryConfiguration = discoveryConfiguration;
		UpdateRequestHeader(registerServer2Request, requestHeader == null, "RegisterServer2");
		try
		{
			IServiceResponse obj = base.TransportChannel.SendRequest(registerServer2Request) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			registerServer2Response = (RegisterServer2Response)obj;
			configurationResults = registerServer2Response.ConfigurationResults;
			diagnosticInfos = registerServer2Response.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(registerServer2Request, registerServer2Response, "RegisterServer2");
		}
		return registerServer2Response.ResponseHeader;
	}

	public virtual IAsyncResult BeginRegisterServer2(RequestHeader requestHeader, RegisteredServer server, ExtensionObjectCollection discoveryConfiguration, AsyncCallback callback, object asyncState)
	{
		RegisterServer2Request registerServer2Request = new RegisterServer2Request();
		registerServer2Request.RequestHeader = requestHeader;
		registerServer2Request.Server = server;
		registerServer2Request.DiscoveryConfiguration = discoveryConfiguration;
		UpdateRequestHeader(registerServer2Request, requestHeader == null, "RegisterServer2");
		return base.TransportChannel.BeginSendRequest(registerServer2Request, callback, asyncState);
	}

	public virtual ResponseHeader EndRegisterServer2(IAsyncResult result, out StatusCodeCollection configurationResults, out DiagnosticInfoCollection diagnosticInfos)
	{
		RegisterServer2Response registerServer2Response = null;
		try
		{
			IServiceResponse obj = base.TransportChannel.EndSendRequest(result) ?? throw new ServiceResultException(2148073472u);
			ClientBase.ValidateResponse(obj.ResponseHeader);
			registerServer2Response = (RegisterServer2Response)obj;
			configurationResults = registerServer2Response.ConfigurationResults;
			diagnosticInfos = registerServer2Response.DiagnosticInfos;
		}
		finally
		{
			RequestCompleted(null, registerServer2Response, "RegisterServer2");
		}
		return registerServer2Response.ResponseHeader;
	}

	public virtual async Task<RegisterServer2Response> RegisterServer2Async(RequestHeader requestHeader, RegisteredServer server, ExtensionObjectCollection discoveryConfiguration, CancellationToken ct)
	{
		RegisterServer2Request request = new RegisterServer2Request();
		RegisterServer2Response response = null;
		request.RequestHeader = requestHeader;
		request.Server = server;
		request.DiscoveryConfiguration = discoveryConfiguration;
		UpdateRequestHeader(request, requestHeader == null, "RegisterServer2");
		try
		{
			IServiceResponse serviceResponse = await base.TransportChannel.SendRequestAsync(request, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (serviceResponse == null)
			{
				throw new ServiceResultException(2148073472u);
			}
			ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
			response = (RegisterServer2Response)serviceResponse;
		}
		finally
		{
			RequestCompleted(request, response, "RegisterServer2");
		}
		return response;
	}
}
