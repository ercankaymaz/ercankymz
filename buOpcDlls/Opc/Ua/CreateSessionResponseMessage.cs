// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CreateSessionResponseMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CreateSessionResponseMessage
{
  public CreateSessionResponse CreateSessionResponse;

  public CreateSessionResponseMessage()
  {
  }

  public CreateSessionResponseMessage(CreateSessionResponse CreateSessionResponse)
  {
    this.CreateSessionResponse = CreateSessionResponse;
  }

  public CreateSessionResponseMessage(ServiceFault ServiceFault)
  {
    this.CreateSessionResponse = new CreateSessionResponse();
    if (ServiceFault == null)
      return;
    this.CreateSessionResponse.ResponseHeader = ServiceFault.ResponseHeader;
  }
}
