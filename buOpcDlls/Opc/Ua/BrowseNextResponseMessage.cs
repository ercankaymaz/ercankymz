// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowseNextResponseMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BrowseNextResponseMessage
{
  public BrowseNextResponse BrowseNextResponse;

  public BrowseNextResponseMessage()
  {
  }

  public BrowseNextResponseMessage(BrowseNextResponse BrowseNextResponse)
  {
    this.BrowseNextResponse = BrowseNextResponse;
  }

  public BrowseNextResponseMessage(ServiceFault ServiceFault)
  {
    this.BrowseNextResponse = new BrowseNextResponse();
    if (ServiceFault == null)
      return;
    this.BrowseNextResponse.ResponseHeader = ServiceFault.ResponseHeader;
  }
}
