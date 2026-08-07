// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddNodesMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddNodesMessage : IServiceMessage
{
  public AddNodesRequest AddNodesRequest;

  public AddNodesMessage()
  {
  }

  public AddNodesMessage(AddNodesRequest AddNodesRequest) => this.AddNodesRequest = AddNodesRequest;

  public IServiceRequest GetRequest() => (IServiceRequest) this.AddNodesRequest;

  public object CreateResponse(IServiceResponse response)
  {
    if (!(response is AddNodesResponse AddNodesResponse))
    {
      AddNodesResponse = new AddNodesResponse();
      AddNodesResponse.ResponseHeader = ((ServiceFault) response).ResponseHeader;
    }
    return (object) new AddNodesResponseMessage(AddNodesResponse);
  }
}
