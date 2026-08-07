// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddNodesResponseMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AddNodesResponseMessage
{
  public AddNodesResponse AddNodesResponse;

  public AddNodesResponseMessage()
  {
  }

  public AddNodesResponseMessage(AddNodesResponse AddNodesResponse)
  {
    this.AddNodesResponse = AddNodesResponse;
  }

  public AddNodesResponseMessage(ServiceFault ServiceFault)
  {
    this.AddNodesResponse = new AddNodesResponse();
    if (ServiceFault == null)
      return;
    this.AddNodesResponse.ResponseHeader = ServiceFault.ResponseHeader;
  }
}
