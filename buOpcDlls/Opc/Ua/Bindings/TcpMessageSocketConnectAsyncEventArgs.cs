// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpMessageSocketConnectAsyncEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpMessageSocketConnectAsyncEventArgs : IMessageSocketAsyncEventArgs, IDisposable
{
  private SocketError m_socketError;

  public TcpMessageSocketConnectAsyncEventArgs(SocketError error) => this.m_socketError = error;

  public void Dispose()
  {
  }

  public object UserToken { get; set; }

  public void SetBuffer(byte[] buffer, int offset, int count)
  {
    throw new NotImplementedException();
  }

  public bool IsSocketError => this.m_socketError != 0;

  public string SocketErrorString => this.m_socketError.ToString();

  public event EventHandler<IMessageSocketAsyncEventArgs> Completed
  {
    add => throw new NotImplementedException();
    remove => throw new NotImplementedException();
  }

  public int BytesTransferred => 0;

  public byte[] Buffer => (byte[]) null;

  public BufferCollection BufferList
  {
    get => (BufferCollection) null;
    set => throw new NotImplementedException();
  }
}
