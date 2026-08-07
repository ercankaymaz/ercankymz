// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.IMessageSocket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface IMessageSocket : IDisposable
{
  int Handle { get; }

  EndPoint LocalEndpoint { get; }

  TransportChannelFeatures MessageSocketFeatures { get; }

  Task<bool> BeginConnect(
    Uri endpointUrl,
    EventHandler<IMessageSocketAsyncEventArgs> callback,
    object state,
    CancellationToken cts);

  void Close();

  void ReadNextMessage();

  void ChangeSink(IMessageSink sink);

  bool SendAsync(IMessageSocketAsyncEventArgs args);

  IMessageSocketAsyncEventArgs MessageSocketEventArgs();
}
