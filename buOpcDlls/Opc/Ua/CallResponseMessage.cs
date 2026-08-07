// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CallResponseMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CallResponseMessage
{
  public CallResponse CallResponse;

  public CallResponseMessage()
  {
  }

  public CallResponseMessage(CallResponse CallResponse) => this.CallResponse = CallResponse;

  public CallResponseMessage(ServiceFault ServiceFault)
  {
    this.CallResponse = new CallResponse();
    if (ServiceFault == null)
      return;
    this.CallResponse.ResponseHeader = ServiceFault.ResponseHeader;
  }
}
