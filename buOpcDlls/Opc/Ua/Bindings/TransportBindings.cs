// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TransportBindings
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public static class TransportBindings
{
  static TransportBindings()
  {
    TransportBindings.Channels = new TransportChannelBindings(new Type[1]
    {
      typeof (TcpTransportChannelFactory)
    });
    TransportBindings.Listeners = new TransportListenerBindings(new Type[1]
    {
      typeof (TcpTransportListenerFactory)
    });
  }

  public static TransportChannelBindings Channels { get; private set; }

  public static TransportListenerBindings Listeners { get; private set; }
}
