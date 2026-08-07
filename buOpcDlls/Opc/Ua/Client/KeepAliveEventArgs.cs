// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.KeepAliveEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class KeepAliveEventArgs : EventArgs
{
  private readonly ServiceResult m_status;
  private readonly ServerState m_currentState;
  private readonly DateTime m_currentTime;
  private bool m_cancelKeepAlive;

  internal KeepAliveEventArgs(ServiceResult status, ServerState currentState, DateTime currentTime)
  {
    this.m_status = status;
    this.m_currentState = currentState;
    this.m_currentTime = currentTime;
  }

  public ServiceResult Status => this.m_status;

  public ServerState CurrentState => this.m_currentState;

  public DateTime CurrentTime => this.m_currentTime;

  public bool CancelKeepAlive
  {
    get => this.m_cancelKeepAlive;
    set => this.m_cancelKeepAlive = value;
  }
}
