// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.IMessageSocketAsyncEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface IMessageSocketAsyncEventArgs : IDisposable
{
  byte[] Buffer { get; }

  BufferCollection BufferList { get; set; }

  int BytesTransferred { get; }

  bool IsSocketError { get; }

  string SocketErrorString { get; }

  object UserToken { get; set; }

  event EventHandler<IMessageSocketAsyncEventArgs> Completed;

  void SetBuffer(byte[] buffer, int offset, int count);
}
