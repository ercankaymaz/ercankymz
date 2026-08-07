// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IRegistrationChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface IRegistrationChannel : IChannelBase
{
  RegisterServerResponseMessage RegisterServer(RegisterServerMessage request);

  IAsyncResult BeginRegisterServer(
    RegisterServerMessage request,
    AsyncCallback callback,
    object asyncState);

  RegisterServerResponseMessage EndRegisterServer(IAsyncResult result);

  Task<RegisterServerResponseMessage> RegisterServerAsync(RegisterServerMessage request);

  RegisterServer2ResponseMessage RegisterServer2(RegisterServer2Message request);

  IAsyncResult BeginRegisterServer2(
    RegisterServer2Message request,
    AsyncCallback callback,
    object asyncState);

  RegisterServer2ResponseMessage EndRegisterServer2(IAsyncResult result);

  Task<RegisterServer2ResponseMessage> RegisterServer2Async(RegisterServer2Message request);
}
