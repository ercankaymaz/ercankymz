// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IEndpointIncomingRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface IEndpointIncomingRequest
{
  IServiceRequest Request { get; }

  SecureChannelContext SecureChannelContext { get; }

  object Calldata { get; set; }

  void CallSynchronously();

  void OperationCompleted(IServiceResponse response, ServiceResult error);
}
