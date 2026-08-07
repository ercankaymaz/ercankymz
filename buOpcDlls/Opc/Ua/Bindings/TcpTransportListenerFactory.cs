// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpTransportListenerFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpTransportListenerFactory : TcpServiceHost
{
  public override string UriScheme => "opc.tcp";

  public override ITransportListener Create() => (ITransportListener) new TcpTransportListener();
}
