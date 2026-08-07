// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpConnectionWaitingEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpConnectionWaitingEventArgs : ConnectionWaitingEventArgs
{
  internal TcpConnectionWaitingEventArgs(string serverUrl, Uri endpointUrl, IMessageSocket socket)
    : base(serverUrl, endpointUrl)
  {
    this.Socket = socket;
  }

  public override object Handle => (object) this.Socket;

  internal IMessageSocket Socket { get; }
}
