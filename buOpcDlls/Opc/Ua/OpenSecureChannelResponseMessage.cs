// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OpenSecureChannelResponseMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class OpenSecureChannelResponseMessage
{
  public OpenSecureChannelResponse OpenSecureChannelResponse;

  public OpenSecureChannelResponseMessage()
  {
  }

  public OpenSecureChannelResponseMessage(
    OpenSecureChannelResponse OpenSecureChannelResponse)
  {
    this.OpenSecureChannelResponse = OpenSecureChannelResponse;
  }

  public OpenSecureChannelResponseMessage(ServiceFault ServiceFault)
  {
    this.OpenSecureChannelResponse = new OpenSecureChannelResponse();
    if (ServiceFault == null)
      return;
    this.OpenSecureChannelResponse.ResponseHeader = ServiceFault.ResponseHeader;
  }
}
