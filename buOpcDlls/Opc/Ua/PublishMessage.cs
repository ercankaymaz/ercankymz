// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PublishMessage : IServiceMessage
{
  public PublishRequest PublishRequest;

  public PublishMessage()
  {
  }

  public PublishMessage(PublishRequest PublishRequest) => this.PublishRequest = PublishRequest;

  public IServiceRequest GetRequest() => (IServiceRequest) this.PublishRequest;

  public object CreateResponse(IServiceResponse response)
  {
    if (!(response is PublishResponse PublishResponse))
    {
      PublishResponse = new PublishResponse();
      PublishResponse.ResponseHeader = ((ServiceFault) response).ResponseHeader;
    }
    return (object) new PublishResponseMessage(PublishResponse);
  }
}
