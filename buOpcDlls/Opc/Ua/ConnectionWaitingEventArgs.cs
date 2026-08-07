// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConnectionWaitingEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ConnectionWaitingEventArgs : EventArgs, ITransportWaitingConnection
{
  protected ConnectionWaitingEventArgs(string serverUri, Uri endpointUrl)
  {
    this.ServerUri = serverUri;
    this.EndpointUrl = endpointUrl;
    this.Accepted = false;
  }

  public string ServerUri { get; private set; }

  public Uri EndpointUrl { get; private set; }

  public virtual object Handle => (object) null;

  public bool Accepted { get; set; }
}
