// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpTransportChannelFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpTransportChannelFactory : 
  ITransportChannelFactory,
  ITransportBindingFactory<ITransportChannel>,
  ITransportBindingScheme
{
  public string UriScheme => "opc.tcp";

  public ITransportChannel Create() => (ITransportChannel) new TcpTransportChannel();
}
