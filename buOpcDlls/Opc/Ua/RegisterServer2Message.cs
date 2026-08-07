// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegisterServer2Message
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RegisterServer2Message : IServiceMessage
{
  public RegisterServer2Request RegisterServer2Request;

  public RegisterServer2Message()
  {
  }

  public RegisterServer2Message(RegisterServer2Request RegisterServer2Request)
  {
    this.RegisterServer2Request = RegisterServer2Request;
  }

  public IServiceRequest GetRequest() => (IServiceRequest) this.RegisterServer2Request;

  public object CreateResponse(IServiceResponse response)
  {
    if (!(response is RegisterServer2Response RegisterServer2Response))
    {
      RegisterServer2Response = new RegisterServer2Response();
      RegisterServer2Response.ResponseHeader = ((ServiceFault) response).ResponseHeader;
    }
    return (object) new RegisterServer2ResponseMessage(RegisterServer2Response);
  }
}
