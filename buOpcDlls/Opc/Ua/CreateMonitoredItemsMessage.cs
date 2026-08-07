// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CreateMonitoredItemsMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateMonitoredItemsMessage : IServiceMessage
{
  public CreateMonitoredItemsRequest CreateMonitoredItemsRequest;

  public CreateMonitoredItemsMessage()
  {
  }

  public CreateMonitoredItemsMessage(
    CreateMonitoredItemsRequest CreateMonitoredItemsRequest)
  {
    this.CreateMonitoredItemsRequest = CreateMonitoredItemsRequest;
  }

  public IServiceRequest GetRequest() => (IServiceRequest) this.CreateMonitoredItemsRequest;

  public object CreateResponse(IServiceResponse response)
  {
    if (!(response is CreateMonitoredItemsResponse CreateMonitoredItemsResponse))
    {
      CreateMonitoredItemsResponse = new CreateMonitoredItemsResponse();
      CreateMonitoredItemsResponse.ResponseHeader = ((ServiceFault) response).ResponseHeader;
    }
    return (object) new CreateMonitoredItemsResponseMessage(CreateMonitoredItemsResponse);
  }
}
