// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ITransportChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Bindings;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface ITransportChannel : IDisposable
{
  TransportChannelFeatures SupportedFeatures { get; }

  EndpointDescription EndpointDescription { get; }

  EndpointConfiguration EndpointConfiguration { get; }

  IServiceMessageContext MessageContext { get; }

  ChannelToken CurrentToken { get; }

  int OperationTimeout { get; set; }

  void Initialize(Uri url, TransportChannelSettings settings);

  void Initialize(ITransportWaitingConnection connection, TransportChannelSettings settings);

  void Open();

  IAsyncResult BeginOpen(AsyncCallback callback, object callbackData);

  void EndOpen(IAsyncResult result);

  void Reconnect();

  void Reconnect(ITransportWaitingConnection connection);

  IAsyncResult BeginReconnect(AsyncCallback callback, object callbackData);

  void EndReconnect(IAsyncResult result);

  void Close();

  Task CloseAsync(CancellationToken ct);

  IAsyncResult BeginClose(AsyncCallback callback, object callbackData);

  void EndClose(IAsyncResult result);

  IServiceResponse SendRequest(IServiceRequest request);

  Task<IServiceResponse> SendRequestAsync(IServiceRequest request, CancellationToken ct);

  IAsyncResult BeginSendRequest(
    IServiceRequest request,
    AsyncCallback callback,
    object callbackData);

  IServiceResponse EndSendRequest(IAsyncResult result);

  Task<IServiceResponse> EndSendRequestAsync(IAsyncResult result, CancellationToken ct);
}
