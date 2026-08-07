// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegisterNodesResponseMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegisterNodesResponseMessage
{
  public RegisterNodesResponse RegisterNodesResponse;

  public RegisterNodesResponseMessage()
  {
  }

  public RegisterNodesResponseMessage(RegisterNodesResponse RegisterNodesResponse)
  {
    this.RegisterNodesResponse = RegisterNodesResponse;
  }

  public RegisterNodesResponseMessage(ServiceFault ServiceFault)
  {
    this.RegisterNodesResponse = new RegisterNodesResponse();
    if (ServiceFault == null)
      return;
    this.RegisterNodesResponse.ResponseHeader = ServiceFault.ResponseHeader;
  }
}
