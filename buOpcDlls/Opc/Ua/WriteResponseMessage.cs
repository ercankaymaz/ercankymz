// Decompiled with JetBrains decompiler
// Type: Opc.Ua.WriteResponseMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class WriteResponseMessage
{
  public WriteResponse WriteResponse;

  public WriteResponseMessage()
  {
  }

  public WriteResponseMessage(WriteResponse WriteResponse) => this.WriteResponse = WriteResponse;

  public WriteResponseMessage(ServiceFault ServiceFault)
  {
    this.WriteResponse = new WriteResponse();
    if (ServiceFault == null)
      return;
    this.WriteResponse.ResponseHeader = ServiceFault.ResponseHeader;
  }
}
