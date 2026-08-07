// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.UaSCUaBinaryClientChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class UaSCUaBinaryClientChannel : UaSCUaBinaryChannel
{
  private Uri m_url;
  private Uri m_via;
  private long m_lastRequestId;
  private Dictionary<uint, UaSCUaBinaryChannel.WriteOperation> m_requests;
  private UaSCUaBinaryChannel.WriteOperation m_handshakeOperation;
  private ChannelToken m_requestedToken;
  private Timer m_handshakeTimer;
  private bool m_reconnecting;
  private int m_waitBetweenReconnects;
  private EventHandler<IMessageSocketAsyncEventArgs> m_ConnectCallback;
  private IMessageSocketFactory m_socketFactory;
  private TimerCallback m_startHandshake;
  private AsyncCallback m_handshakeComplete;
  private List<UaSCUaBinaryClientChannel.QueuedOperation> m_queuedOperations;
  private readonly string g_ImplementationString;

  public UaSCUaBinaryClientChannel(
    string contextId,
    BufferManager bufferManager,
    IMessageSocketFactory socketFactory,
    ChannelQuotas quotas,
    X509Certificate2 clientCertificate,
    X509Certificate2 serverCertificate,
    EndpointDescription endpoint)
    : this(contextId, bufferManager, socketFactory, quotas, clientCertificate, (X509Certificate2Collection) null, serverCertificate, endpoint)
  {
  }

  public UaSCUaBinaryClientChannel(
    string contextId,
    BufferManager bufferManager,
    IMessageSocketFactory socketFactory,
    ChannelQuotas quotas,
    X509Certificate2 clientCertificate,
    X509Certificate2Collection clientCertificateChain,
    X509Certificate2 serverCertificate,
    EndpointDescription endpoint)
  {
    string contextId1 = contextId;
    BufferManager bufferManager1 = bufferManager;
    ChannelQuotas quotas1 = quotas;
    X509Certificate2 serverCertificate1 = serverCertificate;
    EndpointDescriptionCollection endpoints;
    if (endpoint == null)
      endpoints = (EndpointDescriptionCollection) null;
    else
      endpoints = new EndpointDescriptionCollection((IEnumerable<EndpointDescription>) new EndpointDescription[1]
      {
        endpoint
      });
    int securityMode = endpoint != null ? (int) endpoint.SecurityMode : 1;
    string securityPolicyUri = endpoint != null ? endpoint.SecurityPolicyUri : "http://opcfoundation.org/UA/SecurityPolicy#None";
    // ISSUE: explicit constructor call
    base.\u002Ector(contextId1, bufferManager1, quotas1, serverCertificate1, endpoints, (MessageSecurityMode) securityMode, securityPolicyUri);
    if (endpoint != null && endpoint.SecurityMode != MessageSecurityMode.None)
    {
      if (clientCertificate == null)
        throw new ArgumentNullException(nameof (clientCertificate));
      if (clientCertificate.RawData.Length > 7500)
        throw new ArgumentException(Utils.Format("The DER encoded certificate may not be more than {0} bytes.", (object) 7500), nameof (clientCertificate));
      this.ClientCertificate = clientCertificate;
      this.ClientCertificateChain = clientCertificateChain;
    }
    this.m_requests = new Dictionary<uint, UaSCUaBinaryChannel.WriteOperation>();
    this.m_lastRequestId = 0L;
    this.m_ConnectCallback = new EventHandler<IMessageSocketAsyncEventArgs>(this.OnConnectComplete);
    this.m_startHandshake = new TimerCallback(this.OnScheduledHandshake);
    this.m_handshakeComplete = new AsyncCallback(this.OnHandshakeComplete);
    this.m_socketFactory = socketFactory;
    this.EndpointDescription = endpoint;
    this.m_url = new Uri(endpoint.EndpointUrl);
  }

  protected override void Dispose(bool disposing)
  {
    this.m_waitBetweenReconnects = -1;
    if (disposing)
    {
      Utils.SilentDispose((IDisposable) this.m_handshakeTimer);
      this.m_handshakeTimer = (Timer) null;
    }
    base.Dispose(disposing);
  }

  public IAsyncResult BeginConnect(Uri url, int timeout, AsyncCallback callback, object state)
  {
    if (url == (Uri) null)
      throw new ArgumentNullException(nameof (url));
    if (timeout <= 0)
      throw new ArgumentException("Timeout must be greater than zero.", nameof (timeout));
    lock (this.DataLock)
    {
      if (this.State != TcpChannelState.Closed)
        throw new InvalidOperationException("Channel is already connected.");
      this.m_url = url;
      this.m_via = url;
      if (this.EndpointDescription != null && this.EndpointDescription.ProxyUrl != (Uri) null)
        this.m_via = this.EndpointDescription.ProxyUrl;
      this.m_waitBetweenReconnects = -1;
      UaSCUaBinaryChannel.WriteOperation operation = this.BeginOperation(timeout, callback, state);
      this.m_handshakeOperation = operation;
      this.State = TcpChannelState.Connecting;
      if (this.ReverseSocket)
      {
        if (this.Socket != null)
          this.SendHelloMessage(operation);
      }
      else
      {
        this.Socket = this.m_socketFactory.Create((IMessageSink) this, this.BufferManager, this.Quotas.MaxBufferSize);
        Task.Run((Func<Task>) (async () =>
        {
          using (CancellationTokenSource cts = new CancellationTokenSource(timeout))
          {
            IMessageSocket socket = this.Socket;
            Task<bool> task;
            if (socket == null)
            {
              task = (Task<bool>) null;
            }
            else
            {
              task = socket.BeginConnect(this.m_via, this.m_ConnectCallback, (object) operation, cts.Token);
              if (task != null)
                goto label_5;
            }
            task = Task.FromResult<bool>(false);
label_5:
            int num = await task.ConfigureAwait(false) ? 1 : 0;
          }
        }));
      }
    }
    return (IAsyncResult) this.m_handshakeOperation;
  }

  public void EndConnect(IAsyncResult result)
  {
    if (!(result is UaSCUaBinaryChannel.WriteOperation operation))
      throw new ArgumentNullException(nameof (result));
    try
    {
      operation.End(int.MaxValue);
      Utils.LogInfo("CLIENTCHANNEL SOCKET CONNECTED: {0:X8}, ChannelId={1}", (object) this.Socket.Handle, (object) this.ChannelId);
    }
    catch (Exception ex)
    {
      this.Shutdown(ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "Fatal error during connect."));
      throw;
    }
    finally
    {
      this.OperationCompleted(operation);
    }
  }

  public async Task EndConnectAsync(IAsyncResult result, CancellationToken ct = default (CancellationToken))
  {
    UaSCUaBinaryClientChannel binaryClientChannel = this;
    if (!(result is UaSCUaBinaryChannel.WriteOperation operation))
      throw new ArgumentNullException(nameof (result));
    try
    {
      int num = await operation.EndAsync(int.MaxValue, ct: ct).ConfigureAwait(false);
      Utils.LogInfo("CLIENTCHANNEL SOCKET CONNECTED: {0:X8}, ChannelId={1}", (object) binaryClientChannel.Socket.Handle, (object) binaryClientChannel.ChannelId);
    }
    catch (Exception ex)
    {
      binaryClientChannel.Shutdown(ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "Fatal error during connect."));
      throw;
    }
    finally
    {
      binaryClientChannel.OperationCompleted(operation);
    }
    operation = (UaSCUaBinaryChannel.WriteOperation) null;
  }

  public async Task CloseAsync(int timeout, CancellationToken ct = default (CancellationToken))
  {
    UaSCUaBinaryClientChannel binaryClientChannel = this;
    UaSCUaBinaryChannel.WriteOperation writeOperation = binaryClientChannel.InternalClose(timeout);
    if (writeOperation != null)
    {
      try
      {
        int num = await writeOperation.EndAsync(timeout, ct: ct).ConfigureAwait(false);
      }
      catch (ServiceResultException ex)
      {
        switch (ex.StatusCode)
        {
          case 2156134400 /*0x80840000*/:
          case 2156265472 /*0x80860000*/:
            break;
          default:
            Utils.LogWarning((Exception) ex, "ChannelId {0}: Could not gracefully close the channel. Reason={1}", (object) binaryClientChannel.ChannelId, (object) ex.Result.StatusCode);
            break;
        }
      }
      catch (Exception ex)
      {
        object[] objArray = new object[1]
        {
          (object) binaryClientChannel.ChannelId
        };
        Utils.LogError(ex, "ChannelId {0}: Could not gracefully close the channel.", objArray);
      }
    }
    binaryClientChannel.Shutdown((ServiceResult) 2158886912U /*0x80AE0000*/);
  }

  public void Close(int timeout)
  {
    UaSCUaBinaryChannel.WriteOperation writeOperation = this.InternalClose(timeout);
    if (writeOperation != null)
    {
      try
      {
        writeOperation.End(timeout, false);
      }
      catch (ServiceResultException ex)
      {
        switch (ex.StatusCode)
        {
          case 2156134400 /*0x80840000*/:
          case 2156265472 /*0x80860000*/:
            break;
          default:
            Utils.LogWarning((Exception) ex, "ChannelId {0}: Could not gracefully close the channel. Reason={1}", (object) this.ChannelId, (object) ex.Result.StatusCode);
            break;
        }
      }
      catch (Exception ex)
      {
        object[] objArray = new object[1]
        {
          (object) this.ChannelId
        };
        Utils.LogError(ex, "ChannelId {0}: Could not gracefully close the channel.", objArray);
      }
    }
    this.Shutdown((ServiceResult) 2158886912U /*0x80AE0000*/);
  }

  public IAsyncResult BeginSendRequest(
    IServiceRequest request,
    int timeout,
    AsyncCallback callback,
    object state)
  {
    if (request == null)
      throw new ArgumentNullException(nameof (request));
    if (timeout <= 0)
      throw new ArgumentException("Timeout must be greater than zero.", nameof (timeout));
    lock (this.DataLock)
    {
      bool flag = false;
      if (this.State == TcpChannelState.Closed && this.m_queuedOperations == null)
      {
        flag = true;
        this.m_queuedOperations = new List<UaSCUaBinaryClientChannel.QueuedOperation>();
      }
      if (this.m_queuedOperations != null)
      {
        UaSCUaBinaryChannel.WriteOperation operation = this.BeginOperation(timeout, callback, state);
        this.m_queuedOperations.Add(new UaSCUaBinaryClientChannel.QueuedOperation(operation, timeout, request));
        if (flag)
          this.BeginConnect(this.m_url, timeout, new AsyncCallback(this.OnConnectOnDemandComplete), (object) null);
        return (IAsyncResult) operation;
      }
      if (this.State != TcpChannelState.Open)
        throw new ServiceResultException(2158886912U /*0x80AE0000*/);
      Utils.LogTrace("ChannelId {0}: BeginSendRequest()", (object) this.ChannelId);
      if (this.m_reconnecting)
        throw ServiceResultException.Create(2156134400U /*0x80840000*/, "Attempting to reconnect to the server.");
      UaSCUaBinaryChannel.WriteOperation operation1 = this.BeginOperation(timeout, callback, state);
      this.SendRequest(operation1, timeout, request);
      return (IAsyncResult) operation1;
    }
  }

  public IServiceResponse EndSendRequest(IAsyncResult result)
  {
    if (!(result is UaSCUaBinaryChannel.WriteOperation operation))
      throw new ArgumentNullException(nameof (result));
    try
    {
      operation.End(int.MaxValue);
    }
    finally
    {
      this.OperationCompleted(operation);
    }
    return operation.MessageBody as IServiceResponse;
  }

  public async Task<IServiceResponse> EndSendRequestAsync(IAsyncResult result, CancellationToken ct)
  {
    if (!(result is UaSCUaBinaryChannel.WriteOperation operation))
      throw new ArgumentNullException(nameof (result));
    try
    {
      int num = await operation.EndAsync(int.MaxValue, ct: ct).ConfigureAwait(false);
    }
    finally
    {
      this.OperationCompleted(operation);
    }
    IServiceResponse messageBody = operation.MessageBody as IServiceResponse;
    operation = (UaSCUaBinaryChannel.WriteOperation) null;
    return messageBody;
  }

  private void SendHelloMessage(UaSCUaBinaryChannel.WriteOperation operation)
  {
    Utils.LogTrace("ChannelId {0}: SendHelloMessage()", (object) this.ChannelId);
    byte[] numArray = this.BufferManager.TakeBuffer(this.SendBufferSize, nameof (SendHelloMessage));
    try
    {
      using (BinaryEncoder binaryEncoder = new BinaryEncoder((Stream) new MemoryStream(numArray, 0, this.SendBufferSize), this.Quotas.MessageContext, false))
      {
        binaryEncoder.WriteUInt32((string) null, 1179403592U);
        binaryEncoder.WriteUInt32((string) null, 0U);
        binaryEncoder.WriteUInt32((string) null, 0U);
        binaryEncoder.WriteUInt32((string) null, (uint) this.ReceiveBufferSize);
        binaryEncoder.WriteUInt32((string) null, (uint) this.SendBufferSize);
        binaryEncoder.WriteUInt32((string) null, (uint) this.MaxResponseMessageSize);
        binaryEncoder.WriteUInt32((string) null, (uint) this.MaxResponseChunkCount);
        byte[] sourceArray = Encoding.UTF8.GetBytes(this.m_url.ToString());
        if (sourceArray.Length > 4096 /*0x1000*/)
        {
          byte[] destinationArray = new byte[4096 /*0x1000*/];
          Array.Copy((Array) sourceArray, (Array) destinationArray, 4096 /*0x1000*/);
          sourceArray = destinationArray;
        }
        binaryEncoder.WriteByteString((string) null, sourceArray);
        int num = binaryEncoder.Close();
        UaSCUaBinaryChannel.UpdateMessageSize(numArray, 0, num);
        this.BeginWriteMessage(new ArraySegment<byte>(numArray, 0, num), (object) operation);
        numArray = (byte[]) null;
      }
    }
    finally
    {
      if (numArray != null)
        this.BufferManager.ReturnBuffer(numArray, nameof (SendHelloMessage));
    }
  }

  private bool ProcessAcknowledgeMessage(ArraySegment<byte> messageChunk)
  {
    Utils.LogTrace("ChannelId {0}: ProcessAcknowledgeMessage()", (object) this.ChannelId);
    if (this.State != TcpChannelState.Connecting)
    {
      this.ForceReconnect(ServiceResult.Create(2155741184U /*0x807E0000*/, "Server sent an unexpected acknowledge message."));
      return false;
    }
    if (this.m_handshakeOperation == null)
      return false;
    MemoryStream memoryStream = new MemoryStream(messageChunk.Array, messageChunk.Offset, messageChunk.Count);
    BinaryDecoder binaryDecoder = new BinaryDecoder((Stream) memoryStream, this.Quotas.MessageContext);
    memoryStream.Seek(8L, SeekOrigin.Current);
    try
    {
      int num1 = (int) binaryDecoder.ReadUInt32((string) null);
      this.SendBufferSize = (int) binaryDecoder.ReadUInt32((string) null);
      this.ReceiveBufferSize = (int) binaryDecoder.ReadUInt32((string) null);
      int num2 = (int) binaryDecoder.ReadUInt32((string) null);
      int num3 = (int) binaryDecoder.ReadUInt32((string) null);
      if (num2 > 0 && num2 < this.MaxRequestMessageSize)
        this.MaxRequestMessageSize = num2;
      if (this.MaxRequestMessageSize < this.SendBufferSize)
        this.MaxRequestMessageSize = this.SendBufferSize;
      this.MaxRequestChunkCount = UaSCUaBinaryChannel.CalculateChunkCount(this.MaxRequestMessageSize, this.SendBufferSize);
      if (num3 > 0)
      {
        if (num3 < this.MaxRequestChunkCount)
          this.MaxRequestChunkCount = num3;
      }
    }
    finally
    {
      binaryDecoder.Close();
    }
    if (this.ReceiveBufferSize < 8192 /*0x2000*/)
    {
      this.m_handshakeOperation.Fault(2155937792U /*0x80810000*/, "Server receive buffer size is too small ({0} bytes).", (object) this.ReceiveBufferSize);
      return false;
    }
    if (this.SendBufferSize < 8192 /*0x2000*/)
    {
      this.m_handshakeOperation.Fault(2155937792U /*0x80810000*/, "Server send buffer size is too small ({0} bytes).", (object) this.SendBufferSize);
      return false;
    }
    this.State = TcpChannelState.Opening;
    try
    {
      if (this.CurrentToken != null)
      {
        this.SendOpenSecureChannelRequest(true);
        return false;
      }
      this.SendOpenSecureChannelRequest(false);
    }
    catch (Exception ex)
    {
      this.m_handshakeOperation.Fault(ex, 2156003328U /*0x80820000*/, "Could not send an Open Secure Channel request.");
    }
    return false;
  }

  private void SendOpenSecureChannelRequest(bool renew)
  {
    ChannelToken token = this.CreateToken();
    token.ClientNonce = this.CreateNonce();
    byte[] array = BinaryEncoder.EncodeMessage((IEncodeable) new OpenSecureChannelRequest()
    {
      RequestHeader = {
        Timestamp = DateTime.UtcNow
      },
      RequestType = (renew ? SecurityTokenRequestType.Renew : SecurityTokenRequestType.Issue),
      SecurityMode = this.SecurityMode,
      ClientNonce = token.ClientNonce,
      RequestedLifetime = (uint) this.Quotas.SecurityTokenLifetime
    }, this.Quotas.MessageContext);
    BufferCollection buffers = this.WriteAsymmetricMessage(5132367U, this.m_handshakeOperation.RequestId, this.ClientCertificate, this.ClientCertificateChain, this.ServerCertificate, new ArraySegment<byte>(array, 0, array.Length));
    this.m_requestedToken = token;
    try
    {
      this.BeginWriteMessage(buffers, (object) this.m_handshakeOperation);
      buffers = (BufferCollection) null;
    }
    finally
    {
      buffers?.Release(this.BufferManager, nameof (SendOpenSecureChannelRequest));
    }
  }

  private bool ProcessOpenSecureChannelResponse(uint messageType, ArraySegment<byte> messageChunk)
  {
    Utils.LogTrace("ChannelId {0}: ProcessOpenSecureChannelResponse()", (object) this.ChannelId);
    if (this.State != TcpChannelState.Opening && this.State != TcpChannelState.Open)
    {
      this.ForceReconnect(ServiceResult.Create(2155741184U /*0x807E0000*/, "Server sent an unexpected OpenSecureChannel response."));
      return false;
    }
    if (this.m_handshakeOperation == null)
      return false;
    uint channelId = 0;
    X509Certificate2 senderCertificate = (X509Certificate2) null;
    uint requestId = 0;
    uint sequenceNumber = 0;
    ArraySegment<byte> chunk;
    try
    {
      chunk = this.ReadAsymmetricMessage(messageChunk, this.ClientCertificate, out channelId, out senderCertificate, out requestId, out sequenceNumber);
    }
    catch (Exception ex)
    {
      this.ForceReconnect(ServiceResult.Create(ex, 2148728832U /*0x80130000*/, "Could not verify security on OpenSecureChannel response."));
      return false;
    }
    BufferCollection chunksToProcess = (BufferCollection) null;
    try
    {
      UaSCUaBinaryChannel.CompareCertificates(this.ServerCertificate, senderCertificate, true);
      this.ResetSequenceNumber(sequenceNumber);
      if (!TcpMessageType.IsFinal(messageType))
      {
        this.SaveIntermediateChunk(requestId, chunk, false);
        return false;
      }
      chunksToProcess = this.GetSavedChunks(requestId, chunk, false);
      if (!(this.ParseResponse(chunksToProcess) is OpenSecureChannelResponse response))
        throw ServiceResultException.Create(2155085824U /*0x80740000*/, "Server did not return a valid OpenSecureChannelResponse.");
      this.m_requestedToken.TokenId = response.SecurityToken.TokenId;
      this.m_requestedToken.Lifetime = (int) response.SecurityToken.RevisedLifetime;
      this.m_requestedToken.ServerNonce = response.ServerNonce;
      string implementationInfo = string.Format(this.g_ImplementationString, (object) this.m_socketFactory.Implementation);
      if (this.State == TcpChannelState.Opening)
        Audit.SecureChannelCreated(implementationInfo, this.m_url.ToString(), Utils.Format("{0}", (object) channelId), this.EndpointDescription, this.ClientCertificate, senderCertificate, BinaryEncodingSupport.Required);
      else
        Audit.SecureChannelRenewed(implementationInfo, Utils.Format("{0}", (object) channelId));
      this.ChannelId = this.m_requestedToken.ChannelId = channelId;
      this.ActivateToken(this.m_requestedToken);
      this.m_requestedToken = (ChannelToken) null;
      this.State = TcpChannelState.Open;
      this.m_reconnecting = false;
      this.m_waitBetweenReconnects = -1;
      this.ScheduleTokenRenewal(this.CurrentToken);
      this.m_handshakeOperation.Complete(0);
    }
    catch (Exception ex)
    {
      this.m_handshakeOperation.Fault(ex, 2156003328U /*0x80820000*/, "Could not process OpenSecureChannelResponse.");
    }
    finally
    {
      chunksToProcess?.Release(this.BufferManager, nameof (ProcessOpenSecureChannelResponse));
    }
    return false;
  }

  protected override void DoMessageLimitsExceeded()
  {
    base.DoMessageLimitsExceeded();
    this.Shutdown(new ServiceResult(2159607808U /*0x80B90000*/));
  }

  protected override void HandleSocketError(ServiceResult result) => this.ForceReconnect(result);

  protected override void HandleWriteComplete(
    BufferCollection buffers,
    object state,
    int bytesWritten,
    ServiceResult result)
  {
    lock (this.DataLock)
    {
      if (state is UaSCUaBinaryChannel.WriteOperation writeOperation)
      {
        if (ServiceResult.IsBad(result))
          writeOperation.Fault(new ServiceResult((StatusCode) 2148728832U /*0x80130000*/, result));
      }
    }
    base.HandleWriteComplete(buffers, state, bytesWritten, result);
  }

  protected override bool HandleIncomingMessage(uint messageType, ArraySegment<byte> messageChunk)
  {
    lock (this.DataLock)
    {
      if (TcpMessageType.IsType(messageType, 4674381U))
        return this.ProcessResponseMessage(messageType, messageChunk);
      if (messageType == 1179337537U)
        return this.ProcessAcknowledgeMessage(messageChunk);
      if (messageType == 1179800133U)
        return this.ProcessErrorMessage(messageType, messageChunk);
      if (TcpMessageType.IsType(messageType, 5132367U))
        return this.ProcessOpenSecureChannelResponse(messageType, messageChunk);
      if (TcpMessageType.IsType(messageType, 5196867U))
        return this.ProcessResponseMessage(messageType, messageChunk);
      this.ForceReconnect(ServiceResult.Create(2155741184U /*0x807E0000*/, "The client does not recognize the message type: {0:X8}.", (object) messageType));
      return false;
    }
  }

  private void OnConnectComplete(object sender, IMessageSocketAsyncEventArgs e)
  {
    UaSCUaBinaryChannel.WriteOperation userToken = (UaSCUaBinaryChannel.WriteOperation) e.UserToken;
    if (userToken == null)
      return;
    if (e.IsSocketError)
    {
      userToken.Fault((ServiceResult) 2156527616U /*0x808A0000*/);
    }
    else
    {
      lock (this.DataLock)
      {
        try
        {
          if (this.Socket == null)
          {
            userToken.Fault((ServiceResult) 2156265472U /*0x80860000*/);
          }
          else
          {
            this.Socket.ReadNextMessage();
            this.SendHelloMessage(userToken);
          }
        }
        catch (Exception ex)
        {
          object[] objArray = Array.Empty<object>();
          ServiceResult error = ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "An unexpected error occurred while connecting to the server.", objArray);
          userToken.Fault(error);
        }
      }
    }
  }

  private void OnScheduledHandshake(object state)
  {
    try
    {
      Utils.LogInfo("ChannelId {0}: Scheduled Handshake Starting: TokenId={1}", (object) this.ChannelId, (object) this.CurrentToken?.TokenId);
      lock (this.DataLock)
      {
        ChannelToken state1 = state as ChannelToken;
        if (state1 == this.CurrentToken)
        {
          Utils.LogInfo("ChannelId {0}: Attempting Renew Token Now: TokenId={1}", (object) this.ChannelId, (object) state1?.TokenId);
          if (this.State != TcpChannelState.Open)
            return;
          this.m_handshakeOperation = this.BeginOperation(int.MaxValue, this.m_handshakeComplete, (object) state1);
          this.SendOpenSecureChannelRequest(true);
        }
        else
        {
          if (!this.m_reconnecting)
            return;
          Utils.LogInfo("ChannelId {0}: Attempting Reconnect Now.", (object) this.ChannelId);
          if (this.m_handshakeOperation != null)
          {
            this.m_handshakeOperation.Fault((ServiceResult) 2148139008U /*0x800A0000*/);
            this.m_handshakeOperation = (UaSCUaBinaryChannel.WriteOperation) null;
          }
          this.State = TcpChannelState.Closed;
          if (this.Socket != null)
          {
            Utils.LogInfo("ChannelId {0}: CLIENTCHANNEL SOCKET CLOSED: {1:X8}", (object) this.ChannelId, (object) this.Socket.Handle);
            this.Socket.Close();
            this.Socket = (IMessageSocket) null;
          }
          if (this.ReverseSocket)
            return;
          this.m_handshakeOperation = this.BeginOperation(int.MaxValue, this.m_handshakeComplete, (object) null);
          this.State = TcpChannelState.Connecting;
          this.Socket = this.m_socketFactory.Create((IMessageSink) this, this.BufferManager, this.Quotas.MaxBufferSize);
          Task.Run<bool>((Func<Task<bool>>) (async () =>
          {
            UaSCUaBinaryClientChannel binaryClientChannel = this;
            IMessageSocket socket = binaryClientChannel.Socket;
            Task<bool> task;
            if (socket == null)
            {
              task = (Task<bool>) null;
            }
            else
            {
              task = socket.BeginConnect(binaryClientChannel.m_via, binaryClientChannel.m_ConnectCallback, (object) binaryClientChannel.m_handshakeOperation, CancellationToken.None);
              if (task != null)
                goto label_4;
            }
            task = Task.FromResult<bool>(false);
label_4:
            return await task.ConfigureAwait(false);
          }));
        }
      }
    }
    catch (Exception ex)
    {
      Utils.LogError("ChannelId {0}: Reconnect Failed {1}.", (object) this.ChannelId, (object) ex.Message);
      this.ForceReconnect(ServiceResult.Create(ex, 2147549184U /*0x80010000*/, "Unexpected error reconnecting or renewing a token."));
    }
  }

  private void OnHandshakeComplete(IAsyncResult result)
  {
    lock (this.DataLock)
    {
      try
      {
        if (this.m_handshakeOperation == null)
          return;
        Utils.LogTrace("ChannelId {0}: OnHandshakeComplete", (object) this.ChannelId);
        this.m_handshakeOperation.End(int.MaxValue);
        this.m_handshakeOperation = (UaSCUaBinaryChannel.WriteOperation) null;
        this.m_reconnecting = false;
      }
      catch (Exception ex)
      {
        Utils.LogError(ex, "ChannelId {0}: Handshake Failed {1}", (object) this.ChannelId, (object) ex.Message);
        this.m_handshakeOperation = (UaSCUaBinaryChannel.WriteOperation) null;
        this.m_reconnecting = false;
        ServiceResult reason = ServiceResult.Create(ex, 2147549184U /*0x80010000*/, "Unexpected error reconnecting or renewing a token.");
        if (reason.Code != 2155806720U /*0x807F0000*/ && reason.Code != 2148728832U /*0x80130000*/)
        {
          this.ForceReconnect(ServiceResult.Create(ex, 2147549184U /*0x80010000*/, "Unexpected error reconnecting or renewing a token."));
        }
        else
        {
          Utils.LogError("ChannelId {0}: Cannot Recover Channel", (object) this.ChannelId);
          this.Shutdown(reason);
        }
      }
    }
  }

  private void SendRequest(
    UaSCUaBinaryChannel.WriteOperation operation,
    int timeout,
    IServiceRequest request)
  {
    bool flag = false;
    BufferCollection buffers = (BufferCollection) null;
    try
    {
      ChannelToken currentToken = this.CurrentToken;
      if (currentToken == null)
        throw new ServiceResultException(2156265472U /*0x80860000*/);
      bool limitsExceeded = false;
      buffers = this.WriteSymmetricMessage(4674381U, operation.RequestId, currentToken, (object) request, true, out limitsExceeded);
      this.BeginWriteMessage(buffers, (object) operation);
      buffers = (BufferCollection) null;
      flag = true;
      if (limitsExceeded)
        throw new ServiceResultException(2159542272U /*0x80B80000*/);
    }
    catch (Exception ex)
    {
      operation.Fault(ex, 2156134400U /*0x80840000*/, "Could not send request to server.");
    }
    finally
    {
      buffers?.Release(this.BufferManager, nameof (SendRequest));
      if (!flag)
        this.OperationCompleted(operation);
    }
  }

  private IServiceResponse ParseResponse(BufferCollection chunksToProcess)
  {
    if (BinaryDecoder.DecodeMessage((Stream) new ArraySegmentStream(chunksToProcess), (Type) null, this.Quotas.MessageContext) is IServiceResponse response)
      return response;
    throw ServiceResultException.Create(2152071168U /*0x80460000*/, "Could not parse response body.");
  }

  private void Shutdown(ServiceResult reason)
  {
    lock (this.DataLock)
    {
      if (this.State == TcpChannelState.Closed)
        return;
      this.SaveIntermediateChunk(0U, new ArraySegment<byte>(), false);
      if (this.m_handshakeTimer != null)
      {
        this.m_handshakeTimer.Dispose();
        this.m_handshakeTimer = (Timer) null;
      }
      if (this.m_handshakeOperation != null && !this.m_handshakeOperation.IsCompleted)
        this.m_handshakeOperation.Fault(reason);
      foreach (ChannelAsyncOperation<int> channelAsyncOperation in new List<UaSCUaBinaryChannel.WriteOperation>((IEnumerable<UaSCUaBinaryChannel.WriteOperation>) this.m_requests.Values))
        channelAsyncOperation.Fault(new ServiceResult((StatusCode) 2156265472U /*0x80860000*/, reason));
      this.m_requests.Clear();
      uint channelId = this.ChannelId;
      this.State = TcpChannelState.Closed;
      this.ChannelId = 0U;
      this.DiscardTokens();
      this.m_handshakeOperation = (UaSCUaBinaryChannel.WriteOperation) null;
      this.m_requestedToken = (ChannelToken) null;
      this.m_reconnecting = false;
      if (this.Socket != null)
      {
        Utils.LogInfo("ChannelId {0}: CLIENTCHANNEL SOCKET CLOSED: {1:X8}", (object) channelId, (object) this.Socket.Handle);
        this.Socket.Close();
        this.Socket = (IMessageSocket) null;
      }
      this.ChannelStateChanged(TcpChannelState.Closed, reason);
    }
  }

  private void ForceReconnect(ServiceResult reason)
  {
    lock (this.DataLock)
    {
      if (this.m_reconnecting)
        return;
      if (this.State != TcpChannelState.Closing && this.m_waitBetweenReconnects != -1)
      {
        Utils.LogWarning("ChannelId {0}: Force reconnect reason={1}", (object) this.Id, (object) reason);
        foreach (ChannelAsyncOperation<int> channelAsyncOperation in new List<UaSCUaBinaryChannel.WriteOperation>((IEnumerable<UaSCUaBinaryChannel.WriteOperation>) this.m_requests.Values))
          channelAsyncOperation.Fault(new ServiceResult((StatusCode) 2156265472U /*0x80860000*/, reason));
        this.m_requests.Clear();
        if (this.m_handshakeOperation != null && !this.m_handshakeOperation.IsCompleted)
        {
          this.m_handshakeOperation.Fault(reason);
        }
        else
        {
          this.SaveIntermediateChunk(0U, new ArraySegment<byte>(), false);
          if (this.m_handshakeTimer != null)
          {
            this.m_handshakeTimer.Dispose();
            this.m_handshakeTimer = (Timer) null;
          }
          this.m_handshakeOperation = (UaSCUaBinaryChannel.WriteOperation) null;
          this.m_requestedToken = (ChannelToken) null;
          this.m_reconnecting = true;
          this.State = TcpChannelState.Faulted;
          Utils.LogInfo("ChannelId {0}: Attempting Reconnect in {1} ms. Reason: {2}", (object) this.ChannelId, (object) this.m_waitBetweenReconnects, (object) reason.ToLongString());
          this.m_handshakeTimer = new Timer(this.m_startHandshake, (object) null, this.m_waitBetweenReconnects, -1);
          this.m_waitBetweenReconnects *= 2;
          if (this.m_waitBetweenReconnects <= 0)
            this.m_waitBetweenReconnects = 1000;
          if (this.m_waitBetweenReconnects > 120000)
            this.m_waitBetweenReconnects = 120000;
          this.ChannelStateChanged(TcpChannelState.Faulted, reason);
        }
      }
      else
        this.Shutdown(reason);
    }
  }

  private void ScheduleTokenRenewal(ChannelToken token)
  {
    if (this.State != TcpChannelState.Open)
      return;
    if (this.m_handshakeTimer != null)
    {
      this.m_handshakeTimer.Dispose();
      this.m_handshakeTimer = (Timer) null;
    }
    DateTime dateTime1 = token.CreatedAt;
    DateTime dateTime2 = dateTime1.AddMilliseconds((double) token.Lifetime);
    long ticks1 = dateTime2.Ticks;
    dateTime1 = DateTime.UtcNow;
    long ticks2 = dateTime1.Ticks;
    double dueTime = (double) ((ticks1 - ticks2) / 10000L) * 0.75;
    if (dueTime < 0.0)
      dueTime = 0.0;
    Utils.LogInfo("ChannelId {0}: Token Expiry {1}, renewal scheduled in {2} ms.", (object) this.ChannelId, (object) dateTime2, (object) (int) dueTime);
    this.m_handshakeTimer = new Timer(this.m_startHandshake, (object) token, (int) dueTime, -1);
  }

  private UaSCUaBinaryChannel.WriteOperation BeginOperation(
    int timeout,
    AsyncCallback callback,
    object state)
  {
    UaSCUaBinaryChannel.WriteOperation writeOperation = new UaSCUaBinaryChannel.WriteOperation(timeout, callback, state);
    writeOperation.RequestId = Utils.IncrementIdentifier(ref this.m_lastRequestId);
    this.m_requests.Add(writeOperation.RequestId, writeOperation);
    return writeOperation;
  }

  private void OperationCompleted(UaSCUaBinaryChannel.WriteOperation operation)
  {
    if (operation == null)
      return;
    lock (this.DataLock)
    {
      if (this.m_handshakeOperation == operation)
        this.m_handshakeOperation = (UaSCUaBinaryChannel.WriteOperation) null;
      this.m_requests.Remove(operation.RequestId);
    }
  }

  private void OnConnectOnDemandComplete(object state)
  {
    lock (this.DataLock)
    {
      UaSCUaBinaryChannel.WriteOperation writeOperation = (UaSCUaBinaryChannel.WriteOperation) state;
      for (int index = 0; index < this.m_queuedOperations.Count; ++index)
      {
        UaSCUaBinaryClientChannel.QueuedOperation queuedOperation = this.m_queuedOperations[index];
        if (index == 0)
        {
          try
          {
            writeOperation.End(queuedOperation.Timeout);
          }
          catch (Exception ex)
          {
            queuedOperation.Operation.Fault(ex, 2150694912U /*0x80310000*/, "Error establishing a connection: " + ex.Message);
            break;
          }
        }
        if (this.CurrentToken == null)
          queuedOperation.Operation.Fault(2158886912U /*0x80AE0000*/, "Could not send request because connection is closed.");
        try
        {
          this.SendRequest(queuedOperation.Operation, queuedOperation.Timeout, queuedOperation.Request);
        }
        catch (Exception ex)
        {
          queuedOperation.Operation.Fault(ex, 2147811328U /*0x80050000*/, "Could not send request.");
        }
      }
      this.m_queuedOperations = (List<UaSCUaBinaryClientChannel.QueuedOperation>) null;
    }
  }

  private UaSCUaBinaryChannel.WriteOperation InternalClose(int timeout)
  {
    UaSCUaBinaryChannel.WriteOperation operation = (UaSCUaBinaryChannel.WriteOperation) null;
    lock (this.DataLock)
    {
      if (this.State == TcpChannelState.Closed)
        return (UaSCUaBinaryChannel.WriteOperation) null;
      if (this.m_handshakeOperation != null && !this.m_handshakeOperation.IsCompleted)
        this.m_handshakeOperation.Fault(ServiceResult.Create(2158886912U /*0x80AE0000*/, "Channel was closed by the user."));
      Utils.LogTrace("ChannelId {0}: Close", (object) this.ChannelId);
      if (this.State == TcpChannelState.Open)
      {
        this.State = TcpChannelState.Closing;
        operation = this.BeginOperation(timeout, (AsyncCallback) null, (object) null);
        this.SendCloseSecureChannelRequest(operation);
      }
    }
    return operation;
  }

  protected bool ProcessErrorMessage(uint messageType, ArraySegment<byte> messageChunk)
  {
    MemoryStream memoryStream = new MemoryStream(messageChunk.Array, messageChunk.Offset, messageChunk.Count, false);
    BinaryDecoder decoder = new BinaryDecoder((Stream) memoryStream, this.Quotas.MessageContext);
    memoryStream.Seek(8L, SeekOrigin.Current);
    try
    {
      ServiceResult serviceResult = UaSCUaBinaryChannel.ReadErrorMessageBody(decoder);
      Utils.LogTrace("ChannelId {0}: ProcessErrorMessage({1})", (object) this.ChannelId, (object) serviceResult);
      if (this.m_handshakeOperation != null)
      {
        this.m_handshakeOperation.Fault(serviceResult);
        return false;
      }
      this.ForceReconnect(serviceResult);
      return false;
    }
    finally
    {
      decoder.Close();
    }
  }

  private void SendCloseSecureChannelRequest(UaSCUaBinaryChannel.WriteOperation operation)
  {
    Utils.LogTrace("ChannelId {0}: SendCloseSecureChannelRequest()", (object) this.ChannelId);
    this.m_waitBetweenReconnects = -1;
    ChannelToken currentToken = this.CurrentToken;
    if (currentToken == null)
      throw new ServiceResultException(2156265472U /*0x80860000*/);
    CloseSecureChannelRequest messageBody = new CloseSecureChannelRequest();
    messageBody.RequestHeader.Timestamp = DateTime.UtcNow;
    bool limitsExceeded = false;
    BufferCollection buffers = this.WriteSymmetricMessage(5196867U, operation.RequestId, currentToken, (object) messageBody, true, out limitsExceeded);
    try
    {
      this.BeginWriteMessage(buffers, (object) operation);
      buffers = (BufferCollection) null;
    }
    finally
    {
      buffers?.Release(this.BufferManager, nameof (SendCloseSecureChannelRequest));
    }
  }

  private bool ProcessResponseMessage(uint messageType, ArraySegment<byte> messageChunk)
  {
    Utils.LogTrace("ChannelId {0}: ProcessResponseMessage()", (object) this.ChannelId);
    ChannelToken token = (ChannelToken) null;
    uint requestId = 0;
    uint sequenceNumber = 0;
    ArraySegment<byte> chunk;
    try
    {
      chunk = this.ReadSymmetricMessage(messageChunk, false, out token, out requestId, out sequenceNumber);
    }
    catch (Exception ex)
    {
      this.ForceReconnect(ServiceResult.Create(ex, 2148728832U /*0x80130000*/, "Could not verify security on response."));
      return false;
    }
    UaSCUaBinaryChannel.WriteOperation writeOperation = (UaSCUaBinaryChannel.WriteOperation) null;
    if (!this.m_requests.TryGetValue(requestId, out writeOperation))
      return false;
    BufferCollection chunksToProcess = (BufferCollection) null;
    if (!this.VerifySequenceNumber(sequenceNumber, nameof (ProcessResponseMessage)))
      throw new ServiceResultException(2156396544U /*0x80880000*/);
    try
    {
      if (TcpMessageType.IsAbort(messageType))
      {
        chunksToProcess = this.GetSavedChunks(requestId, chunk, false);
        BinaryDecoder decoder = new BinaryDecoder((Stream) new MemoryStream(chunk.Array, chunk.Offset, chunk.Count, false), this.Quotas.MessageContext);
        ServiceResult error = UaSCUaBinaryChannel.ReadErrorMessageBody(decoder);
        decoder.Close();
        writeOperation.Fault(true, error);
        return true;
      }
      if (!TcpMessageType.IsFinal(messageType))
      {
        this.SaveIntermediateChunk(requestId, chunk, false);
        return true;
      }
      chunksToProcess = this.GetSavedChunks(requestId, chunk, false);
      writeOperation.MessageBody = (IEncodeable) this.ParseResponse(chunksToProcess);
      if (writeOperation.MessageBody == null)
      {
        writeOperation.Fault(true, 2152071168U /*0x80460000*/, "Could not parse response body.");
        return true;
      }
      writeOperation.Complete(true, 0);
      return true;
    }
    catch (Exception ex)
    {
      Utils.LogError(ex, "Unexpected error processing response.");
      writeOperation.Fault(true, ex, 2148073472U /*0x80090000*/, "Unexpected error processing response.");
      return true;
    }
    finally
    {
      chunksToProcess?.Release(this.BufferManager, nameof (ProcessResponseMessage));
    }
  }

  private struct QueuedOperation(
    UaSCUaBinaryChannel.WriteOperation operation,
    int timeout,
    IServiceRequest request)
  {
    public UaSCUaBinaryChannel.WriteOperation Operation = operation;
    public int Timeout = timeout;
    public IServiceRequest Request = request;
  }
}
