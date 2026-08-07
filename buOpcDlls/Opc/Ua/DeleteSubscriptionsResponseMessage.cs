// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DeleteSubscriptionsResponseMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeleteSubscriptionsResponseMessage
{
  public DeleteSubscriptionsResponse DeleteSubscriptionsResponse;

  public DeleteSubscriptionsResponseMessage()
  {
  }

  public DeleteSubscriptionsResponseMessage(
    DeleteSubscriptionsResponse DeleteSubscriptionsResponse)
  {
    this.DeleteSubscriptionsResponse = DeleteSubscriptionsResponse;
  }

  public DeleteSubscriptionsResponseMessage(ServiceFault ServiceFault)
  {
    this.DeleteSubscriptionsResponse = new DeleteSubscriptionsResponse();
    if (ServiceFault == null)
      return;
    this.DeleteSubscriptionsResponse.ResponseHeader = ServiceFault.ResponseHeader;
  }
}
