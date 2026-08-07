// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IRegistrationClientMethods
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface IRegistrationClientMethods
{
  ResponseHeader RegisterServer(RequestHeader requestHeader, RegisteredServer server);

  IAsyncResult BeginRegisterServer(
    RequestHeader requestHeader,
    RegisteredServer server,
    AsyncCallback callback,
    object asyncState);

  ResponseHeader EndRegisterServer(IAsyncResult result);

  Task<RegisterServerResponse> RegisterServerAsync(
    RequestHeader requestHeader,
    RegisteredServer server,
    CancellationToken ct);

  ResponseHeader RegisterServer2(
    RequestHeader requestHeader,
    RegisteredServer server,
    ExtensionObjectCollection discoveryConfiguration,
    out StatusCodeCollection configurationResults,
    out DiagnosticInfoCollection diagnosticInfos);

  IAsyncResult BeginRegisterServer2(
    RequestHeader requestHeader,
    RegisteredServer server,
    ExtensionObjectCollection discoveryConfiguration,
    AsyncCallback callback,
    object asyncState);

  ResponseHeader EndRegisterServer2(
    IAsyncResult result,
    out StatusCodeCollection configurationResults,
    out DiagnosticInfoCollection diagnosticInfos);

  Task<RegisterServer2Response> RegisterServer2Async(
    RequestHeader requestHeader,
    RegisteredServer server,
    ExtensionObjectCollection discoveryConfiguration,
    CancellationToken ct);
}
