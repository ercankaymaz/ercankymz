// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IRegistrationEndpoint
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
public interface IRegistrationEndpoint : IEndpointBase
{
  IAsyncResult BeginRegisterServer(
    RegisterServerMessage request,
    AsyncCallback callback,
    object asyncState);

  RegisterServerResponseMessage EndRegisterServer(IAsyncResult result);

  IAsyncResult BeginRegisterServer2(
    RegisterServer2Message request,
    AsyncCallback callback,
    object asyncState);

  RegisterServer2ResponseMessage EndRegisterServer2(IAsyncResult result);
}
