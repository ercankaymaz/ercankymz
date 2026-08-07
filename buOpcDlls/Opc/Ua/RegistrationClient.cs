// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegistrationClient
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegistrationClient(ITransportChannel channel) : ClientBase(channel), IRegistrationClientMethods
{
  public static RegistrationClient Create(
    ApplicationConfiguration configuration,
    EndpointDescription description,
    EndpointConfiguration endpointConfiguration,
    X509Certificate2 instanceCertificate)
  {
    if (configuration == null)
      throw new ArgumentNullException(nameof (configuration));
    if (description == null)
      throw new ArgumentNullException(nameof (description));
    return new RegistrationClient(RegistrationChannel.Create(configuration, description, endpointConfiguration, instanceCertificate, (IServiceMessageContext) new ServiceMessageContext()));
  }

  public IRegistrationChannel InnerChannel => (IRegistrationChannel) base.InnerChannel;

  public virtual ResponseHeader RegisterServer(RequestHeader requestHeader, RegisteredServer server)
  {
    RegisterServerRequest request = new RegisterServerRequest();
    RegisterServerResponse response = (RegisterServerResponse) null;
    request.RequestHeader = requestHeader;
    request.Server = server;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (RegisterServer));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RegisterServerResponse) serviceResponse;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (RegisterServer));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginRegisterServer(
    RequestHeader requestHeader,
    RegisteredServer server,
    AsyncCallback callback,
    object asyncState)
  {
    RegisterServerRequest request = new RegisterServerRequest();
    request.RequestHeader = requestHeader;
    request.Server = server;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "RegisterServer");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndRegisterServer(IAsyncResult result)
  {
    RegisterServerResponse response = (RegisterServerResponse) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RegisterServerResponse) serviceResponse;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "RegisterServer");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<RegisterServerResponse> RegisterServerAsync(
    RequestHeader requestHeader,
    RegisteredServer server,
    CancellationToken ct)
  {
    RegistrationClient registrationClient = this;
    RegisterServerRequest request = new RegisterServerRequest();
    RegisterServerResponse response = (RegisterServerResponse) null;
    request.RequestHeader = requestHeader;
    request.Server = server;
    registrationClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "RegisterServer");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (registrationClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RegisterServerResponse) serviceResponse;
    }
    finally
    {
      registrationClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "RegisterServer");
    }
    RegisterServerResponse registerServerResponse = response;
    request = (RegisterServerRequest) null;
    response = (RegisterServerResponse) null;
    return registerServerResponse;
  }

  public virtual ResponseHeader RegisterServer2(
    RequestHeader requestHeader,
    RegisteredServer server,
    ExtensionObjectCollection discoveryConfiguration,
    out StatusCodeCollection configurationResults,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    RegisterServer2Request request = new RegisterServer2Request();
    RegisterServer2Response response = (RegisterServer2Response) null;
    request.RequestHeader = requestHeader;
    request.Server = server;
    request.DiscoveryConfiguration = discoveryConfiguration;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, nameof (RegisterServer2));
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.SendRequest((IServiceRequest) request);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RegisterServer2Response) serviceResponse;
      configurationResults = response.ConfigurationResults;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, nameof (RegisterServer2));
    }
    return response.ResponseHeader;
  }

  public virtual IAsyncResult BeginRegisterServer2(
    RequestHeader requestHeader,
    RegisteredServer server,
    ExtensionObjectCollection discoveryConfiguration,
    AsyncCallback callback,
    object asyncState)
  {
    RegisterServer2Request request = new RegisterServer2Request();
    request.RequestHeader = requestHeader;
    request.Server = server;
    request.DiscoveryConfiguration = discoveryConfiguration;
    this.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "RegisterServer2");
    return this.TransportChannel.BeginSendRequest((IServiceRequest) request, callback, asyncState);
  }

  public virtual ResponseHeader EndRegisterServer2(
    IAsyncResult result,
    out StatusCodeCollection configurationResults,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    RegisterServer2Response response = (RegisterServer2Response) null;
    try
    {
      IServiceResponse serviceResponse = this.TransportChannel.EndSendRequest(result);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RegisterServer2Response) serviceResponse;
      configurationResults = response.ConfigurationResults;
      diagnosticInfos = response.DiagnosticInfos;
    }
    finally
    {
      this.RequestCompleted((IServiceRequest) null, (IServiceResponse) response, "RegisterServer2");
    }
    return response.ResponseHeader;
  }

  public virtual async Task<RegisterServer2Response> RegisterServer2Async(
    RequestHeader requestHeader,
    RegisteredServer server,
    ExtensionObjectCollection discoveryConfiguration,
    CancellationToken ct)
  {
    RegistrationClient registrationClient = this;
    RegisterServer2Request request = new RegisterServer2Request();
    RegisterServer2Response response = (RegisterServer2Response) null;
    request.RequestHeader = requestHeader;
    request.Server = server;
    request.DiscoveryConfiguration = discoveryConfiguration;
    registrationClient.UpdateRequestHeader((IServiceRequest) request, requestHeader == null, "RegisterServer2");
    try
    {
      // ISSUE: explicit non-virtual call
      IServiceResponse serviceResponse = await __nonvirtual (registrationClient.TransportChannel).SendRequestAsync((IServiceRequest) request, ct).ConfigureAwait(false);
      if (serviceResponse == null)
        throw new ServiceResultException(2148073472U /*0x80090000*/);
      ClientBase.ValidateResponse(serviceResponse.ResponseHeader);
      response = (RegisterServer2Response) serviceResponse;
    }
    finally
    {
      registrationClient.RequestCompleted((IServiceRequest) request, (IServiceResponse) response, "RegisterServer2");
    }
    RegisterServer2Response registerServer2Response = response;
    request = (RegisterServer2Request) null;
    response = (RegisterServer2Response) null;
    return registerServer2Response;
  }
}
