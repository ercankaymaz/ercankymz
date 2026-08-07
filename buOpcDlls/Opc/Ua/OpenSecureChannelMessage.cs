// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OpenSecureChannelMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class OpenSecureChannelMessage : IServiceMessage
{
  public OpenSecureChannelRequest OpenSecureChannelRequest;

  public OpenSecureChannelMessage()
  {
  }

  public OpenSecureChannelMessage(OpenSecureChannelRequest OpenSecureChannelRequest)
  {
    this.OpenSecureChannelRequest = OpenSecureChannelRequest;
  }

  public IServiceRequest GetRequest() => (IServiceRequest) this.OpenSecureChannelRequest;

  public object CreateResponse(IServiceResponse response)
  {
    if (!(response is OpenSecureChannelResponse OpenSecureChannelResponse))
    {
      OpenSecureChannelResponse = new OpenSecureChannelResponse();
      OpenSecureChannelResponse.ResponseHeader = ((ServiceFault) response).ResponseHeader;
    }
    return (object) new OpenSecureChannelResponseMessage(OpenSecureChannelResponse);
  }
}
