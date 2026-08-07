// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransferSubscriptionsMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TransferSubscriptionsMessage : IServiceMessage
{
  public TransferSubscriptionsRequest TransferSubscriptionsRequest;

  public TransferSubscriptionsMessage()
  {
  }

  public TransferSubscriptionsMessage(
    TransferSubscriptionsRequest TransferSubscriptionsRequest)
  {
    this.TransferSubscriptionsRequest = TransferSubscriptionsRequest;
  }

  public IServiceRequest GetRequest() => (IServiceRequest) this.TransferSubscriptionsRequest;

  public object CreateResponse(IServiceResponse response)
  {
    if (!(response is TransferSubscriptionsResponse TransferSubscriptionsResponse))
    {
      TransferSubscriptionsResponse = new TransferSubscriptionsResponse();
      TransferSubscriptionsResponse.ResponseHeader = ((ServiceFault) response).ResponseHeader;
    }
    return (object) new TransferSubscriptionsResponseMessage(TransferSubscriptionsResponse);
  }
}
