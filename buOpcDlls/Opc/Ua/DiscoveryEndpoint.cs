// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiscoveryEndpoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DiscoveryEndpoint : 
  EndpointBase,
  IDiscoveryEndpoint,
  IEndpointBase,
  IRegistrationEndpoint
{
  public DiscoveryEndpoint() => this.CreateKnownTypes();

  public DiscoveryEndpoint(IServiceHostBase host)
    : base(host)
  {
    this.CreateKnownTypes();
  }

  public DiscoveryEndpoint(ServerBase server)
    : base(server)
  {
    this.CreateKnownTypes();
  }

  protected IDiscoveryServer ServerInstance
  {
    get
    {
      if (ServiceResult.IsBad(this.ServerError))
        throw new ServiceResultException(this.ServerError);
      return this.ServerForContext as IDiscoveryServer;
    }
  }

  public IServiceResponse FindServers(IServiceRequest incoming)
  {
    FindServersResponse response = (FindServersResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      FindServersRequest findServersRequest = (FindServersRequest) incoming;
      ApplicationDescriptionCollection servers = (ApplicationDescriptionCollection) null;
      response = new FindServersResponse();
      response.ResponseHeader = this.ServerInstance.FindServers(findServersRequest.RequestHeader, findServersRequest.EndpointUrl, findServersRequest.LocaleIds, findServersRequest.ServerUris, out servers);
      response.Servers = servers;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginFindServers(
    FindServersMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.FindServersRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.FindServersRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.FindServersRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual FindServersResponseMessage EndFindServers(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new FindServersResponseMessage((FindServersResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse FindServersOnNetwork(IServiceRequest incoming)
  {
    FindServersOnNetworkResponse response = (FindServersOnNetworkResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      FindServersOnNetworkRequest onNetworkRequest = (FindServersOnNetworkRequest) incoming;
      DateTime lastCounterResetTime = DateTime.MinValue;
      ServerOnNetworkCollection servers = (ServerOnNetworkCollection) null;
      response = new FindServersOnNetworkResponse();
      response.ResponseHeader = this.ServerInstance.FindServersOnNetwork(onNetworkRequest.RequestHeader, onNetworkRequest.StartingRecordId, onNetworkRequest.MaxRecordsToReturn, onNetworkRequest.ServerCapabilityFilter, out lastCounterResetTime, out servers);
      response.LastCounterResetTime = lastCounterResetTime;
      response.Servers = servers;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginFindServersOnNetwork(
    FindServersOnNetworkMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.FindServersOnNetworkRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.FindServersOnNetworkRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.FindServersOnNetworkRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual FindServersOnNetworkResponseMessage EndFindServersOnNetwork(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new FindServersOnNetworkResponseMessage((FindServersOnNetworkResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse GetEndpoints(IServiceRequest incoming)
  {
    GetEndpointsResponse response = (GetEndpointsResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      GetEndpointsRequest endpointsRequest = (GetEndpointsRequest) incoming;
      EndpointDescriptionCollection endpoints = (EndpointDescriptionCollection) null;
      response = new GetEndpointsResponse();
      response.ResponseHeader = this.ServerInstance.GetEndpoints(endpointsRequest.RequestHeader, endpointsRequest.EndpointUrl, endpointsRequest.LocaleIds, endpointsRequest.ProfileUris, out endpoints);
      response.Endpoints = endpoints;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginGetEndpoints(
    GetEndpointsMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.GetEndpointsRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.GetEndpointsRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.GetEndpointsRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual GetEndpointsResponseMessage EndGetEndpoints(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new GetEndpointsResponseMessage((GetEndpointsResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse RegisterServer(IServiceRequest incoming)
  {
    RegisterServerResponse response = (RegisterServerResponse) null;
    try
    {
      this.OnRequestReceived(incoming);
      RegisterServerRequest registerServerRequest = (RegisterServerRequest) incoming;
      response = new RegisterServerResponse();
      response.ResponseHeader = this.ServerInstance.RegisterServer(registerServerRequest.RequestHeader, registerServerRequest.Server);
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginRegisterServer(
    RegisterServerMessage message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.RegisterServerRequest);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.RegisterServerRequest);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.RegisterServerRequest, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual RegisterServerResponseMessage EndRegisterServer(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new RegisterServerResponseMessage((RegisterServerResponse) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public IServiceResponse RegisterServer2(IServiceRequest incoming)
  {
    RegisterServer2Response response = (RegisterServer2Response) null;
    try
    {
      this.OnRequestReceived(incoming);
      RegisterServer2Request registerServer2Request = (RegisterServer2Request) incoming;
      StatusCodeCollection configurationResults = (StatusCodeCollection) null;
      DiagnosticInfoCollection diagnosticInfos = (DiagnosticInfoCollection) null;
      response = new RegisterServer2Response();
      response.ResponseHeader = this.ServerInstance.RegisterServer2(registerServer2Request.RequestHeader, registerServer2Request.Server, registerServer2Request.DiscoveryConfiguration, out configurationResults, out diagnosticInfos);
      response.ConfigurationResults = configurationResults;
      response.DiagnosticInfos = diagnosticInfos;
    }
    finally
    {
      this.OnResponseSent((IServiceResponse) response);
    }
    return (IServiceResponse) response;
  }

  public virtual IAsyncResult BeginRegisterServer2(
    RegisterServer2Message message,
    AsyncCallback callback,
    object callbackData)
  {
    try
    {
      if (message == null)
        throw new ArgumentNullException(nameof (message));
      this.OnRequestReceived((IServiceRequest) message.RegisterServer2Request);
      this.SetRequestContext(RequestEncoding.Xml);
      return new EndpointBase.ProcessRequestAsyncResult((EndpointBase) this, callback, callbackData, 0).BeginProcessRequest(SecureChannelContext.Current, (IServiceRequest) message.RegisterServer2Request);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault((IServiceRequest) message.RegisterServer2Request, ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  public virtual RegisterServer2ResponseMessage EndRegisterServer2(IAsyncResult ar)
  {
    try
    {
      IServiceResponse response = EndpointBase.ProcessRequestAsyncResult.WaitForComplete(ar, true);
      this.OnResponseSent(response);
      return new RegisterServer2ResponseMessage((RegisterServer2Response) response);
    }
    catch (Exception ex)
    {
      Exception soapFault = EndpointBase.CreateSoapFault(EndpointBase.ProcessRequestAsyncResult.GetRequest(ar), ex);
      this.OnResponseFaultSent(soapFault);
      throw soapFault;
    }
  }

  protected virtual void CreateKnownTypes()
  {
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.FindServersRequest, new EndpointBase.ServiceDefinition(typeof (FindServersRequest), new EndpointBase.InvokeServiceEventHandler(this.FindServers)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.FindServersOnNetworkRequest, new EndpointBase.ServiceDefinition(typeof (FindServersOnNetworkRequest), new EndpointBase.InvokeServiceEventHandler(this.FindServersOnNetwork)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.GetEndpointsRequest, new EndpointBase.ServiceDefinition(typeof (GetEndpointsRequest), new EndpointBase.InvokeServiceEventHandler(this.GetEndpoints)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.RegisterServerRequest, new EndpointBase.ServiceDefinition(typeof (RegisterServerRequest), new EndpointBase.InvokeServiceEventHandler(this.RegisterServer)));
    this.SupportedServices.Add((ExpandedNodeId) DataTypeIds.RegisterServer2Request, new EndpointBase.ServiceDefinition(typeof (RegisterServer2Request), new EndpointBase.InvokeServiceEventHandler(this.RegisterServer2)));
  }
}
