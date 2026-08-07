// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FindServersOnNetworkMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FindServersOnNetworkMessage : IServiceMessage
{
  public FindServersOnNetworkRequest FindServersOnNetworkRequest;

  public FindServersOnNetworkMessage()
  {
  }

  public FindServersOnNetworkMessage(
    FindServersOnNetworkRequest FindServersOnNetworkRequest)
  {
    this.FindServersOnNetworkRequest = FindServersOnNetworkRequest;
  }

  public IServiceRequest GetRequest() => (IServiceRequest) this.FindServersOnNetworkRequest;

  public object CreateResponse(IServiceResponse response)
  {
    if (!(response is FindServersOnNetworkResponse FindServersOnNetworkResponse))
    {
      FindServersOnNetworkResponse = new FindServersOnNetworkResponse();
      FindServersOnNetworkResponse.ResponseHeader = ((ServiceFault) response).ResponseHeader;
    }
    return (object) new FindServersOnNetworkResponseMessage(FindServersOnNetworkResponse);
  }
}
