// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CancelMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CancelMessage : IServiceMessage
{
  public CancelRequest CancelRequest;

  public CancelMessage()
  {
  }

  public CancelMessage(CancelRequest CancelRequest) => this.CancelRequest = CancelRequest;

  public IServiceRequest GetRequest() => (IServiceRequest) this.CancelRequest;

  public object CreateResponse(IServiceResponse response)
  {
    if (!(response is CancelResponse CancelResponse))
    {
      CancelResponse = new CancelResponse();
      CancelResponse.ResponseHeader = ((ServiceFault) response).ResponseHeader;
    }
    return (object) new CancelResponseMessage(CancelResponse);
  }
}
