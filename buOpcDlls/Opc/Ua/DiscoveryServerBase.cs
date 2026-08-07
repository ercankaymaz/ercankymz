// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiscoveryServerBase
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
public class DiscoveryServerBase : ServerBase, IDiscoveryServer, IServerBase, IAuditEventCallback
{
  public virtual ResponseHeader FindServers(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection serverUris,
    out ApplicationDescriptionCollection servers)
  {
    servers = (ApplicationDescriptionCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader FindServersOnNetwork(
    RequestHeader requestHeader,
    uint startingRecordId,
    uint maxRecordsToReturn,
    StringCollection serverCapabilityFilter,
    out DateTime lastCounterResetTime,
    out ServerOnNetworkCollection servers)
  {
    lastCounterResetTime = DateTime.MinValue;
    servers = (ServerOnNetworkCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader GetEndpoints(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection profileUris,
    out EndpointDescriptionCollection endpoints)
  {
    endpoints = (EndpointDescriptionCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader RegisterServer(RequestHeader requestHeader, RegisteredServer server)
  {
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }

  public virtual ResponseHeader RegisterServer2(
    RequestHeader requestHeader,
    RegisteredServer server,
    ExtensionObjectCollection discoveryConfiguration,
    out StatusCodeCollection configurationResults,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    configurationResults = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    this.ValidateRequest(requestHeader);
    return this.CreateResponse(requestHeader, 2148204544U /*0x800B0000*/);
  }
}
