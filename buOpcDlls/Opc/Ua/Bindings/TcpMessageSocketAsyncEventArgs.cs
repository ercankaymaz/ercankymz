// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpMessageSocketAsyncEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpMessageSocketAsyncEventArgs : IMessageSocketAsyncEventArgs, IDisposable
{
  private SocketAsyncEventArgs m_args;

  public TcpMessageSocketAsyncEventArgs()
  {
    this.m_args = new SocketAsyncEventArgs()
    {
      UserToken = (object) this
    };
  }

  public void Dispose() => this.m_args.Dispose();

  public object UserToken { get; set; }

  public void SetBuffer(byte[] buffer, int offset, int count)
  {
    this.m_args.SetBuffer(buffer, offset, count);
  }

  public bool IsSocketError => this.m_args.SocketError != 0;

  public string SocketErrorString => this.m_args.SocketError.ToString();

  public event EventHandler<IMessageSocketAsyncEventArgs> Completed
  {
    add
    {
      this.m_InternalComplete += value;
      this.m_args.Completed += new EventHandler<SocketAsyncEventArgs>(this.OnComplete);
    }
    remove
    {
      this.m_InternalComplete -= value;
      this.m_args.Completed -= new EventHandler<SocketAsyncEventArgs>(this.OnComplete);
    }
  }

  protected void OnComplete(object sender, SocketAsyncEventArgs e)
  {
    if (e.UserToken == null)
      return;
    this.m_InternalComplete((object) this, e.UserToken as IMessageSocketAsyncEventArgs);
  }

  public int BytesTransferred => this.m_args.BytesTransferred;

  public byte[] Buffer => this.m_args.Buffer;

  public BufferCollection BufferList
  {
    get => this.m_args.BufferList as BufferCollection;
    set => this.m_args.BufferList = (IList<ArraySegment<byte>>) value;
  }

  public SocketAsyncEventArgs Args => this.m_args;

  private event EventHandler<IMessageSocketAsyncEventArgs> m_InternalComplete;
}
