// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IDiscoveryServer
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
public interface IDiscoveryServer : IServerBase, IAuditEventCallback
{
  ResponseHeader FindServers(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection serverUris,
    out ApplicationDescriptionCollection servers);

  ResponseHeader FindServersOnNetwork(
    RequestHeader requestHeader,
    uint startingRecordId,
    uint maxRecordsToReturn,
    StringCollection serverCapabilityFilter,
    out DateTime lastCounterResetTime,
    out ServerOnNetworkCollection servers);

  ResponseHeader GetEndpoints(
    RequestHeader requestHeader,
    string endpointUrl,
    StringCollection localeIds,
    StringCollection profileUris,
    out EndpointDescriptionCollection endpoints);

  ResponseHeader RegisterServer(RequestHeader requestHeader, RegisteredServer server);

  ResponseHeader RegisterServer2(
    RequestHeader requestHeader,
    RegisteredServer server,
    ExtensionObjectCollection discoveryConfiguration,
    out StatusCodeCollection configurationResults,
    out DiagnosticInfoCollection diagnosticInfos);
}
