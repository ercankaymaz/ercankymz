// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegisterNodesMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegisterNodesMessage : IServiceMessage
{
  public RegisterNodesRequest RegisterNodesRequest;

  public RegisterNodesMessage()
  {
  }

  public RegisterNodesMessage(RegisterNodesRequest RegisterNodesRequest)
  {
    this.RegisterNodesRequest = RegisterNodesRequest;
  }

  public IServiceRequest GetRequest() => (IServiceRequest) this.RegisterNodesRequest;

  public object CreateResponse(IServiceResponse response)
  {
    if (!(response is RegisterNodesResponse RegisterNodesResponse))
    {
      RegisterNodesResponse = new RegisterNodesResponse();
      RegisterNodesResponse.ResponseHeader = ((ServiceFault) response).ResponseHeader;
    }
    return (object) new RegisterNodesResponseMessage(RegisterNodesResponse);
  }
}
