// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RepublishResponseMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RepublishResponseMessage
{
  public RepublishResponse RepublishResponse;

  public RepublishResponseMessage()
  {
  }

  public RepublishResponseMessage(RepublishResponse RepublishResponse)
  {
    this.RepublishResponse = RepublishResponse;
  }

  public RepublishResponseMessage(ServiceFault ServiceFault)
  {
    this.RepublishResponse = new RepublishResponse();
    if (ServiceFault == null)
      return;
    this.RepublishResponse.ResponseHeader = ServiceFault.ResponseHeader;
  }
}
