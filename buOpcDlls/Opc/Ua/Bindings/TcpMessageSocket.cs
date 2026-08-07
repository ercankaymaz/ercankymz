// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpMessageSocket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpMessageSocket : IMessageSocket, IDisposable
{
  private static readonly int s_defaultRetryNextAddressTimeout = 1000;
  private IMessageSink m_sink;
  private BufferManager m_bufferManager;
  private readonly int m_receiveBufferSize;
  private readonly EventHandler<SocketAsyncEventArgs> m_readComplete;
  private readonly object m_socketLock = new object();
  private Socket m_socket;
  private bool m_closed;
  private TaskCompletionSource<SocketError> m_tcs;
  private int m_socketResponses;
  private readonly object m_readLock = new object();
  private byte[] m_receiveBuffer;
  private int m_bytesReceived;
  private int m_bytesToReceive;
  private int m_incomingMessageSize;
  private TcpMessageSocket.ReadState m_readState;

  public TcpMessageSocket(IMessageSink sink, BufferManager bufferManager, int receiveBufferSize)
  {
    if (bufferManager == null)
      throw new ArgumentNullException(nameof (bufferManager));
    this.m_sink = sink;
    this.m_socket = (Socket) null;
    this.m_bufferManager = bufferManager;
    this.m_receiveBufferSize = receiveBufferSize;
    this.m_incomingMessageSize = -1;
    this.m_readComplete = new EventHandler<SocketAsyncEventArgs>(this.OnReadComplete);
    this.m_readState = TcpMessageSocket.ReadState.Ready;
  }

  public TcpMessageSocket(
    IMessageSink sink,
    Socket socket,
    BufferManager bufferManager,
    int receiveBufferSize)
  {
    if (socket == null)
      throw new ArgumentNullException(nameof (socket));
    if (bufferManager == null)
      throw new ArgumentNullException(nameof (bufferManager));
    this.m_sink = sink;
    this.m_socket = socket;
    this.m_bufferManager = bufferManager;
    this.m_receiveBufferSize = receiveBufferSize;
    this.m_incomingMessageSize = -1;
    this.m_readComplete = new EventHandler<SocketAsyncEventArgs>(this.OnReadComplete);
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    this.m_socket.Dispose();
  }

  public int Handle => this.m_socket == null ? -1 : this.m_socket.GetHashCode();

  public EndPoint LocalEndpoint => this.m_socket.LocalEndPoint;

  public TransportChannelFeatures MessageSocketFeatures
  {
    get => TransportChannelFeatures.Reconnect | TransportChannelFeatures.ReverseConnect;
  }

  public async Task<bool> BeginConnect(
    Uri endpointUrl,
    EventHandler<IMessageSocketAsyncEventArgs> callback,
    object state,
    CancellationToken cts)
  {
    if (endpointUrl == (Uri) null)
      throw new ArgumentNullException(nameof (endpointUrl));
    if (this.m_socket != null)
      throw new InvalidOperationException("The socket is already connected.");
    SocketError error = SocketError.NotInitialized;
    TcpMessageSocket.CallbackAction doCallback = (TcpMessageSocket.CallbackAction) (socketError => callback((object) this, (IMessageSocketAsyncEventArgs) new TcpMessageSocketConnectAsyncEventArgs(socketError)
    {
      UserToken = state
    }));
    IPAddress[] source;
    try
    {
      source = await Dns.GetHostAddressesAsync(endpointUrl.DnsSafeHost).ConfigureAwait(false);
    }
    catch (SocketException ex)
    {
      Utils.LogWarning("Name resolution failed for: {0} Error: {1}", (object) endpointUrl.DnsSafeHost, (object) ex.Message);
      error = ex.SocketErrorCode;
      goto label_34;
    }
    IPAddress[] addressesV4 = ((IEnumerable<IPAddress>) source).Where<IPAddress>((Func<IPAddress, bool>) (a => a.AddressFamily == AddressFamily.InterNetwork)).ToArray<IPAddress>();
    IPAddress[] addressesV6 = ((IEnumerable<IPAddress>) source).Where<IPAddress>((Func<IPAddress, bool>) (a => a.AddressFamily == AddressFamily.InterNetworkV6)).ToArray<IPAddress>();
    int port = endpointUrl.Port;
    if (port <= 0 || port > (int) ushort.MaxValue)
      port = 4840;
    int arrayV4Index = 0;
    int arrayV6Index = 0;
    this.m_socketResponses = 0;
    this.m_tcs = new TaskCompletionSource<SocketError>();
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter1;
    ConfiguredTaskAwaitable<SocketError>.ConfiguredTaskAwaiter awaiter2;
    bool moreAddresses;
    do
    {
      error = SocketError.NotInitialized;
      lock (this.m_socketLock)
      {
        if (addressesV6.Length > arrayV6Index)
          ++this.m_socketResponses;
        if (addressesV4.Length > arrayV4Index)
          ++this.m_socketResponses;
        if (this.m_tcs.Task.IsCompleted)
          this.m_tcs = new TaskCompletionSource<SocketError>();
      }
      if (addressesV6.Length > arrayV6Index && this.m_socket == null)
      {
        if (this.BeginConnect(addressesV6[arrayV6Index], AddressFamily.InterNetworkV6, port, doCallback) != SocketError.Success)
          ++arrayV6Index;
        else
          goto label_35;
      }
      if (addressesV4.Length > arrayV4Index && this.m_socket == null)
      {
        if (this.BeginConnect(addressesV4[arrayV4Index], AddressFamily.InterNetwork, port, doCallback) != SocketError.Success)
          ++arrayV4Index;
        else
          goto label_36;
      }
      moreAddresses = addressesV6.Length > arrayV6Index || addressesV4.Length > arrayV4Index;
      if (moreAddresses && !this.m_tcs.Task.IsCompleted)
      {
        awaiter1 = Task.Delay(TcpMessageSocket.s_defaultRetryNextAddressTimeout, cts).ContinueWith((Action<Task>) (tsk =>
        {
          if (!tsk.IsCanceled)
            return;
          moreAddresses = false;
        }), cts).ConfigureAwait(false).GetAwaiter();
        if (awaiter1.IsCompleted)
          awaiter1.GetResult();
        else
          goto label_37;
      }
      if (!moreAddresses || this.m_tcs.Task.IsCompleted)
        goto label_32;
label_31:
      continue;
label_32:
      awaiter2 = this.m_tcs.Task.ConfigureAwait(false).GetAwaiter();
      if (awaiter2.IsCompleted)
      {
        error = awaiter2.GetResult();
        switch (error)
        {
          case SocketError.Success:
            goto label_39;
          case SocketError.ConnectionRefused:
            goto label_31;
          default:
            goto label_34;
        }
      }
      else
        goto label_38;
    }
    while (moreAddresses);
    goto label_34;
label_35:
    return true;
label_36:
    return true;
label_37:
    int num = 1;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003E1__state = 1;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter1 = awaiter1;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, TcpMessageSocket.\u003CBeginConnect\u003Ed__11>(ref awaiter1, this);
    return;
label_38:
    num = 2;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003E1__state = 2;
    ConfiguredTaskAwaitable<SocketError>.ConfiguredTaskAwaiter configuredTaskAwaiter2 = awaiter2;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<SocketError>.ConfiguredTaskAwaiter, TcpMessageSocket.\u003CBeginConnect\u003Ed__11>(ref awaiter2, this);
    return;
label_39:
    return true;
label_34:
    doCallback(error);
    return false;
  }

  public void Close()
  {
    lock (this.m_socketLock)
    {
      this.m_closed = true;
      if (this.m_socket == null)
        return;
      try
      {
        if (!this.m_socket.Connected)
          return;
        this.m_socket.Shutdown(SocketShutdown.Both);
      }
      catch (Exception ex)
      {
        object[] objArray = Array.Empty<object>();
        Utils.LogError(ex, "Unexpected error closing socket.", objArray);
      }
      finally
      {
        this.m_socket.Dispose();
        this.m_socket = (Socket) null;
      }
    }
  }

  public void ReadNextMessage()
  {
    lock (this.m_readLock)
    {
      do
      {
        if (this.m_receiveBuffer == null)
          goto label_5;
label_2:
        this.m_bytesReceived = 0;
        this.m_bytesToReceive = 8;
        this.m_incomingMessageSize = -1;
        do
        {
          this.ReadNextBlock();
        }
        while (this.m_readState == TcpMessageSocket.ReadState.ReadNextBlock);
        continue;
label_5:
        this.m_receiveBuffer = this.m_bufferManager.TakeBuffer(this.m_receiveBufferSize, nameof (ReadNextMessage));
        goto label_2;
      }
      while (this.m_readState == TcpMessageSocket.ReadState.ReadNextMessage);
    }
  }

  public void ChangeSink(IMessageSink sink)
  {
    lock (this.m_readLock)
      this.m_sink = sink;
  }

  private void OnReadComplete(object sender, SocketAsyncEventArgs e)
  {
    lock (this.m_readLock)
    {
      ServiceResult serviceResult = (ServiceResult) null;
      try
      {
        int num = this.m_readState == TcpMessageSocket.ReadState.ReadComplete ? 1 : 0;
        serviceResult = this.DoReadComplete(e);
        if (num == 0)
        {
          if (!ServiceResult.IsBad(serviceResult))
          {
            while (this.ReadNext())
              ;
          }
        }
      }
      catch (Exception ex)
      {
        Utils.LogError(ex, "Unexpected error during OnReadComplete,");
        serviceResult = ServiceResult.Create(ex, 2156003328U /*0x80820000*/, ex.Message);
      }
      finally
      {
        e?.Dispose();
      }
      if (this.m_readState == TcpMessageSocket.ReadState.NotConnected && ServiceResult.IsGood(serviceResult))
        serviceResult = ServiceResult.Create(2158886912U /*0x80AE0000*/, "Remote side closed connection.");
      if (!ServiceResult.IsBad(serviceResult))
        return;
      if (this.m_receiveBuffer != null)
      {
        this.m_bufferManager.ReturnBuffer(this.m_receiveBuffer, nameof (OnReadComplete));
        this.m_receiveBuffer = (byte[]) null;
      }
      this.m_sink?.OnReceiveError((IMessageSocket) this, serviceResult);
    }
  }

  private ServiceResult DoReadComplete(SocketAsyncEventArgs e)
  {
    int bytesTransferred = e.BytesTransferred;
    this.m_readState = TcpMessageSocket.ReadState.Ready;
    lock (this.m_socketLock)
      BufferManager.UnlockBuffer(this.m_receiveBuffer);
    if (bytesTransferred == 0)
    {
      if (this.m_receiveBuffer != null)
      {
        this.m_bufferManager.ReturnBuffer(this.m_receiveBuffer, nameof (DoReadComplete));
        this.m_receiveBuffer = (byte[]) null;
      }
      this.m_readState = TcpMessageSocket.ReadState.Error;
      return ServiceResult.Create(2158886912U /*0x80AE0000*/, "Remote side closed connection");
    }
    this.m_bytesReceived += bytesTransferred;
    if (this.m_bytesReceived < this.m_bytesToReceive)
    {
      this.m_readState = TcpMessageSocket.ReadState.ReadNextBlock;
      return ServiceResult.Good;
    }
    if (this.m_incomingMessageSize < 0)
    {
      this.m_incomingMessageSize = BitConverter.ToInt32(this.m_receiveBuffer, 4);
      if (this.m_incomingMessageSize > 0 && this.m_incomingMessageSize <= this.m_receiveBufferSize)
      {
        this.m_bytesToReceive = this.m_incomingMessageSize;
        this.m_readState = TcpMessageSocket.ReadState.ReadNextBlock;
        return ServiceResult.Good;
      }
      Utils.LogError("BadTcpMessageTooLarge: BufferSize={0}; MessageSize={1}", (object) this.m_receiveBufferSize, (object) this.m_incomingMessageSize);
      this.m_readState = TcpMessageSocket.ReadState.Error;
      return ServiceResult.Create(2155872256U /*0x80800000*/, "Messages size {0} bytes is too large for buffer of size {1}.", (object) this.m_incomingMessageSize, (object) this.m_receiveBufferSize);
    }
    if (this.m_sink != null)
    {
      try
      {
        ArraySegment<byte> message = new ArraySegment<byte>(this.m_receiveBuffer, 0, this.m_incomingMessageSize);
        this.m_receiveBuffer = (byte[]) null;
        this.m_sink.OnMessageReceived((IMessageSocket) this, message);
      }
      catch (Exception ex)
      {
        object[] objArray = Array.Empty<object>();
        Utils.LogError(ex, "Unexpected error invoking OnMessageReceived callback.", objArray);
      }
    }
    if (this.m_receiveBuffer != null)
    {
      this.m_bufferManager.ReturnBuffer(this.m_receiveBuffer, nameof (DoReadComplete));
      this.m_receiveBuffer = (byte[]) null;
    }
    this.m_readState = TcpMessageSocket.ReadState.ReadNextMessage;
    return ServiceResult.Good;
  }

  private void ReadNextBlock()
  {
    Socket socket = (Socket) null;
    lock (this.m_socketLock)
    {
      socket = this.m_socket;
      if (socket != null)
      {
        if (socket.Connected)
          goto label_8;
      }
      this.m_readState = TcpMessageSocket.ReadState.NotConnected;
      return;
    }
label_8:
    BufferManager.LockBuffer(this.m_receiveBuffer);
    SocketAsyncEventArgs e = new SocketAsyncEventArgs();
    try
    {
      this.m_readState = TcpMessageSocket.ReadState.Receive;
      e.SetBuffer(this.m_receiveBuffer, this.m_bytesReceived, this.m_bytesToReceive - this.m_bytesReceived);
      e.Completed += this.m_readComplete;
      if (socket.ReceiveAsync(e))
        return;
      if (e.SocketError != SocketError.Success)
        throw ServiceResultException.Create(2156003328U /*0x80820000*/, e.SocketError.ToString());
      this.m_readState = TcpMessageSocket.ReadState.ReadComplete;
      this.m_readComplete((object) null, e);
    }
    catch (ServiceResultException ex)
    {
      e?.Dispose();
      BufferManager.UnlockBuffer(this.m_receiveBuffer);
      throw;
    }
    catch (Exception ex)
    {
      e?.Dispose();
      BufferManager.UnlockBuffer(this.m_receiveBuffer);
      throw ServiceResultException.Create(2156003328U /*0x80820000*/, ex, "BeginReceive failed.");
    }
  }

  private bool ReadNext()
  {
    bool flag = true;
    switch (this.m_readState)
    {
      case TcpMessageSocket.ReadState.ReadNextMessage:
        this.ReadNextMessage();
        break;
      case TcpMessageSocket.ReadState.ReadNextBlock:
        this.ReadNextBlock();
        break;
      default:
        flag = false;
        break;
    }
    return flag;
  }

  private SocketError BeginConnect(
    IPAddress address,
    AddressFamily addressFamily,
    int port,
    TcpMessageSocket.CallbackAction callback)
  {
    Socket sender = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
    SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs()
    {
      UserToken = (object) callback,
      RemoteEndPoint = (EndPoint) new IPEndPoint(address, port)
    };
    socketAsyncEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(this.OnSocketConnected);
    if (sender.ConnectAsync(socketAsyncEventArgs))
      return SocketError.InProgress;
    this.OnSocketConnected((object) sender, socketAsyncEventArgs);
    return socketAsyncEventArgs.SocketError;
  }

  private void OnSocketConnected(object sender, SocketAsyncEventArgs args)
  {
    Socket socket = sender as Socket;
    bool flag = false;
    lock (this.m_socketLock)
    {
      --this.m_socketResponses;
      if (!this.m_closed)
      {
        if (this.m_socket == null)
        {
          if (args.SocketError == SocketError.Success)
          {
            this.m_socket = socket;
            flag = true;
            this.m_tcs.SetResult(args.SocketError);
          }
          else if (this.m_socketResponses == 0)
            this.m_tcs.SetResult(args.SocketError);
        }
      }
    }
    if (flag)
    {
      ((TcpMessageSocket.CallbackAction) args.UserToken)(args.SocketError);
    }
    else
    {
      try
      {
        if (socket.Connected)
          socket.Shutdown(SocketShutdown.Both);
      }
      catch
      {
      }
      finally
      {
        socket.Dispose();
      }
    }
    args.Dispose();
  }

  public bool SendAsync(IMessageSocketAsyncEventArgs args)
  {
    if (!(args is TcpMessageSocketAsyncEventArgs socketAsyncEventArgs))
      throw new ArgumentNullException(nameof (args));
    if (this.m_socket == null)
      throw new InvalidOperationException("The socket is not connected.");
    socketAsyncEventArgs.Args.SocketError = SocketError.NotConnected;
    return this.m_socket.SendAsync(socketAsyncEventArgs.Args);
  }

  public IMessageSocketAsyncEventArgs MessageSocketEventArgs()
  {
    return (IMessageSocketAsyncEventArgs) new TcpMessageSocketAsyncEventArgs();
  }

  private delegate void CallbackAction(SocketError error);

  private enum ReadState
  {
    Ready = 0,
    ReadNextMessage = 1,
    ReadNextBlock = 2,
    Receive = 3,
    ReadComplete = 4,
    NotConnected = 5,
    Error = 255, // 0x000000FF
  }
}
