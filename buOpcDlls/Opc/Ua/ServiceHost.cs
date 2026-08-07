// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServiceHost
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ServiceHost : IServiceHostBase, IDisposable
{
  private ServerBase m_server;
  private Type m_endpointType;
  private Uri[] m_addresses;

  public ServiceHost(ServerBase server, Type endpointType, params Uri[] addresses)
  {
    this.m_server = server;
    this.m_endpointType = endpointType;
    this.m_addresses = addresses;
  }

  public void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing || this.State != ServiceHostState.Opened)
      return;
    this.Close();
  }

  public IServerBase Server => (IServerBase) this.m_server;

  public virtual void Open() => this.State = ServiceHostState.Opened;

  public virtual void Abort()
  {
  }

  public virtual void Close() => this.State = ServiceHostState.Closed;

  public ServiceHostState State { get; private set; }
}
