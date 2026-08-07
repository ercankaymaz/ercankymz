// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpServerChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Logging;
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
public class TcpServerChannel : TcpListenerChannel
{
  private SortedDictionary<uint, IServiceResponse> m_queuedResponses;
  private readonly string m_ImplementationString = ".NET Standard ServerChannel UA-TCP " + Utils.GetAssemblyBuildNumber();
  private TcpServerChannel.ReverseConnectAsyncResult m_pendingReverseHello;

  public TcpServerChannel(
    string contextId,
    ITcpChannelListener listener,
    BufferManager bufferManager,
    ChannelQuotas quotas,
    X509Certificate2 serverCertificate,
    EndpointDescriptionCollection endpoints)
    : this(contextId, listener, bufferManager, quotas, serverCertificate, (X509Certificate2Collection) null, endpoints)
  {
    this.m_queuedResponses = new SortedDictionary<uint, IServiceResponse>();
  }

  public TcpServerChannel(
    string contextId,
    ITcpChannelListener listener,
    BufferManager bufferManager,
    ChannelQuotas quotas,
    X509Certificate2 serverCertificate,
    X509Certificate2Collection serverCertificateChain,
    EndpointDescriptionCollection endpoints)
    : base(contextId, listener, bufferManager, quotas, serverCertificate, serverCertificateChain, endpoints)
  {
    this.m_queuedResponses = new SortedDictionary<uint, IServiceResponse>();
  }

  protected override void Dispose(bool disposing) => base.Dispose(disposing);

  public override string ChannelName => "TCPSERVERCHANNEL";

  public Uri ReverseConnectionUrl { get; internal set; }

  public event TcpChannelStatusEventHandler StatusChanged;

  public IAsyncResult BeginReverseConnect(
    uint channelId,
    Uri endpointUrl,
    AsyncCallback callback,
    object callbackData,
    int timeout)
  {
    this.ChannelId = channelId;
    this.ReverseConnectionUrl = endpointUrl;
    this.SetEndpointUrl(this.Listener.EndpointUrl.ToString());
    TcpServerChannel.ReverseConnectAsyncResult ar = new TcpServerChannel.ReverseConnectAsyncResult(callback, callbackData, timeout);
    TcpMessageSocketFactory messageSocketFactory = new TcpMessageSocketFactory();
    ar.Socket = this.Socket = messageSocketFactory.Create((IMessageSink) this, this.BufferManager, this.ReceiveBufferSize);
    EventHandler<IMessageSocketAsyncEventArgs> connectComplete = new EventHandler<IMessageSocketAsyncEventArgs>(this.OnReverseConnectComplete);
    Task.Run<bool>((Func<Task<bool>>) (async () => await this.Socket.BeginConnect(endpointUrl, connectComplete, (object) ar, ar.CancellationToken).ConfigureAwait(false)));
    return (IAsyncResult) ar;
  }

  public void EndReverseConnect(IAsyncResult result)
  {
    if (!(result is TcpServerChannel.ReverseConnectAsyncResult connectAsyncResult))
      throw new ArgumentException("EndReverseConnect is called with invalid IAsyncResult.", nameof (result));
    if (!connectAsyncResult.WaitForComplete())
      throw new TimeoutException();
  }

  private void OnReverseConnectComplete(object sender, IMessageSocketAsyncEventArgs result)
  {
    TcpServerChannel.ReverseConnectAsyncResult userToken = (TcpServerChannel.ReverseConnectAsyncResult) result.UserToken;
    if (userToken == null || this.m_pendingReverseHello != null)
      return;
    if (result.IsSocketError)
    {
      userToken.Exception = (Exception) new ServiceResultException(2156527616U /*0x808A0000*/, result.SocketErrorString);
      userToken.OperationCompleted();
    }
    else
    {
      byte[] numArray = this.BufferManager.TakeBuffer(this.SendBufferSize, "OnReverseConnectConnectComplete");
      try
      {
        userToken.Socket.ReadNextMessage();
        using (BinaryEncoder binaryEncoder = new BinaryEncoder(numArray, 0, this.SendBufferSize, this.Quotas.MessageContext))
        {
          binaryEncoder.WriteUInt32((string) null, 1178945618U);
          binaryEncoder.WriteUInt32((string) null, 0U);
          binaryEncoder.WriteString((string) null, this.EndpointDescription.Server.ApplicationUri);
          binaryEncoder.WriteString((string) null, this.EndpointDescription.EndpointUrl);
          int num = binaryEncoder.Close();
          UaSCUaBinaryChannel.UpdateMessageSize(numArray, 0, num);
          this.State = TcpChannelState.Connecting;
          this.m_pendingReverseHello = userToken;
          this.BeginWriteMessage(new ArraySegment<byte>(numArray, 0, num), (object) null);
          numArray = (byte[]) null;
        }
      }
      catch (Exception ex)
      {
        userToken.Exception = ex;
        userToken.OperationCompleted();
      }
      finally
      {
        if (numArray != null)
          this.BufferManager.ReturnBuffer(numArray, nameof (OnReverseConnectComplete));
      }
    }
  }

  public override void Reconnect(
    IMessageSocket socket,
    uint requestId,
    uint sequenceNumber,
    X509Certificate2 clientCertificate,
    ChannelToken token,
    OpenSecureChannelRequest request)
  {
    if (socket == null)
      throw new ArgumentNullException(nameof (socket));
    lock (this.DataLock)
    {
      UaSCUaBinaryChannel.CompareCertificates(this.ClientCertificate, clientCertificate, false);
      if (!this.VerifySequenceNumber(sequenceNumber, nameof (Reconnect)))
        throw new ServiceResultException(2156396544U /*0x80880000*/);
      try
      {
        Utils.LogInfo("{0} SOCKET RECONNECTED: {1:X8}, ChannelId={2}", (object) this.ChannelName, (object) socket.Handle, (object) this.ChannelId);
        this.Socket = socket;
        this.Socket.ChangeSink((IMessageSink) this);
        token.TokenId = this.GetNewTokenId();
        this.ActivateToken(token);
        this.State = TcpChannelState.Open;
        this.CleanupTimer();
        this.SendOpenSecureChannelResponse(requestId, token, request);
        this.ResetQueuedResponses(new Action<object>(this.OnChannelReconnected));
      }
      catch (Exception ex)
      {
        this.SendServiceFault(token, requestId, ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "Unexpected error processing request."));
      }
    }
  }

  protected override bool HandleIncomingMessage(uint messageType, ArraySegment<byte> messageChunk)
  {
    lock (this.DataLock)
    {
      this.SetResponseRequired(true);
      try
      {
        if (TcpMessageType.IsType(messageType, 4674381U))
        {
          Utils.LogTrace((EventId) 16 /*0x10*/, "ChannelId {0}: ProcessRequestMessage", (object) this.ChannelId);
          return this.ProcessRequestMessage(messageType, messageChunk);
        }
        if (messageType == 1179403592U)
        {
          Utils.LogTrace((EventId) 16 /*0x10*/, "ChannelId {0}: ProcessHelloMessage", (object) this.ChannelId);
          return this.ProcessHelloMessage(messageChunk);
        }
        if (TcpMessageType.IsType(messageType, 5132367U))
        {
          Utils.LogTrace((EventId) 16 /*0x10*/, "ChannelId {0}: ProcessOpenSecureChannelRequest", (object) this.ChannelId);
          return this.ProcessOpenSecureChannelRequest(messageType, messageChunk);
        }
        if (TcpMessageType.IsType(messageType, 5196867U))
        {
          Utils.LogTrace((EventId) 16 /*0x10*/, "ChannelId {0}: ProcessCloseSecureChannelRequest", (object) this.ChannelId);
          return this.ProcessCloseSecureChannelRequest(messageType, messageChunk);
        }
        this.ForceChannelFault(2155741184U /*0x807E0000*/, "The server does not recognize the message type: {0:X8}.", (object) messageType);
        return false;
      }
      finally
      {
        this.SetResponseRequired(false);
      }
    }
  }

  private void OnChannelReconnected(object state)
  {
    if (!(state is SortedDictionary<uint, IServiceResponse> sortedDictionary))
      return;
    foreach (KeyValuePair<uint, IServiceResponse> keyValuePair in sortedDictionary)
    {
      try
      {
        this.SendResponse(keyValuePair.Key, keyValuePair.Value);
      }
      catch (Exception ex)
      {
        object[] objArray = new object[1]
        {
          (object) keyValuePair.Key
        };
        Utils.LogError(ex, "Unexpected error re-sending request (ID={0}).", objArray);
      }
    }
  }

  private bool ProcessHelloMessage(ArraySegment<byte> messageChunk)
  {
    if (this.State != TcpChannelState.Connecting)
    {
      this.ForceChannelFault(2155741184U /*0x807E0000*/, "Client sent an unexpected Hello message.");
      return false;
    }
    try
    {
      using (MemoryStream memoryStream = new MemoryStream(messageChunk.Array, messageChunk.Offset, messageChunk.Count, false))
      {
        BinaryDecoder binaryDecoder = new BinaryDecoder((Stream) memoryStream, this.Quotas.MessageContext);
        memoryStream.Seek(8L, SeekOrigin.Current);
        int num1 = (int) binaryDecoder.ReadUInt32((string) null);
        uint num2 = binaryDecoder.ReadUInt32((string) null);
        uint num3 = binaryDecoder.ReadUInt32((string) null);
        uint num4 = binaryDecoder.ReadUInt32((string) null);
        uint num5 = binaryDecoder.ReadUInt32((string) null);
        int length = binaryDecoder.ReadInt32((string) null);
        if (length > 0)
        {
          if (length > 4096 /*0x1000*/)
          {
            this.ForceChannelFault((ServiceResult) 2156068864U /*0x80830000*/);
            return false;
          }
          byte[] bytes = new byte[length];
          for (int index = 0; index < bytes.Length; ++index)
            bytes[index] = binaryDecoder.ReadByte((string) null);
          if (!this.SetEndpointUrl(new UTF8Encoding().GetString(bytes, 0, bytes.Length)))
          {
            this.ForceChannelFault((ServiceResult) 2156068864U /*0x80830000*/);
            return false;
          }
        }
        binaryDecoder.Close();
        if ((long) num2 < (long) this.ReceiveBufferSize)
          this.ReceiveBufferSize = (int) num2;
        if (this.ReceiveBufferSize < 8192 /*0x2000*/)
          this.ReceiveBufferSize = 8192 /*0x2000*/;
        if ((long) num3 < (long) this.SendBufferSize)
          this.SendBufferSize = (int) num3;
        if (this.SendBufferSize < 8192 /*0x2000*/)
          this.SendBufferSize = 8192 /*0x2000*/;
        if (num4 > 0U && (long) num4 < (long) this.MaxResponseMessageSize)
          this.MaxResponseMessageSize = (int) num4;
        if (this.MaxResponseMessageSize < this.SendBufferSize)
          this.MaxResponseMessageSize = this.SendBufferSize;
        this.MaxResponseChunkCount = UaSCUaBinaryChannel.CalculateChunkCount(this.MaxResponseMessageSize, this.SendBufferSize);
        if (num5 > 0U && (long) num5 < (long) this.MaxResponseChunkCount)
          this.MaxResponseChunkCount = (int) num5;
        this.MaxRequestChunkCount = UaSCUaBinaryChannel.CalculateChunkCount(this.MaxRequestMessageSize, this.ReceiveBufferSize);
      }
      byte[] numArray = this.BufferManager.TakeBuffer((int) sbyte.MaxValue, nameof (ProcessHelloMessage));
      try
      {
        using (MemoryStream memoryStream = new MemoryStream(numArray, 0, (int) sbyte.MaxValue))
        {
          using (BinaryEncoder binaryEncoder = new BinaryEncoder((Stream) memoryStream, this.Quotas.MessageContext, false))
          {
            binaryEncoder.WriteUInt32((string) null, 1179337537U);
            binaryEncoder.WriteUInt32((string) null, 0U);
            binaryEncoder.WriteUInt32((string) null, 0U);
            binaryEncoder.WriteUInt32((string) null, (uint) this.ReceiveBufferSize);
            binaryEncoder.WriteUInt32((string) null, (uint) this.SendBufferSize);
            binaryEncoder.WriteUInt32((string) null, (uint) this.MaxRequestMessageSize);
            binaryEncoder.WriteUInt32((string) null, (uint) this.MaxRequestChunkCount);
            int num = binaryEncoder.Close();
            UaSCUaBinaryChannel.UpdateMessageSize(numArray, 0, num);
            this.State = TcpChannelState.Opening;
            this.BeginWriteMessage(new ArraySegment<byte>(numArray, 0, num), (object) null);
          }
        }
        numArray = (byte[]) null;
      }
      finally
      {
        if (numArray != null)
          this.BufferManager.ReturnBuffer(numArray, nameof (ProcessHelloMessage));
      }
    }
    catch (Exception ex)
    {
      this.ForceChannelFault(ex, 2156003328U /*0x80820000*/, "Unexpected error while processing a Hello message.");
    }
    return false;
  }

  private bool ProcessOpenSecureChannelRequest(uint messageType, ArraySegment<byte> messageChunk)
  {
    if (this.State != TcpChannelState.Opening && this.State != TcpChannelState.Open)
    {
      this.ForceChannelFault(2155741184U /*0x807E0000*/, "Client sent an unexpected OpenSecureChannel message.");
      return false;
    }
    uint channelId = 0;
    X509Certificate2 senderCertificate = (X509Certificate2) null;
    uint requestId = 0;
    uint sequenceNumber = 0;
    ArraySegment<byte> chunk;
    try
    {
      chunk = this.ReadAsymmetricMessage(messageChunk, this.ServerCertificate, out channelId, out senderCertificate, out requestId, out sequenceNumber);
      if (!this.VerifySequenceNumber(sequenceNumber, nameof (ProcessOpenSecureChannelRequest)))
        throw new ServiceResultException(2156396544U /*0x80880000*/);
    }
    catch (Exception ex)
    {
      ReportAuditOpenSecureChannelEventHandler secureChannelEvent = this.ReportAuditOpenSecureChannelEvent;
      if (secureChannelEvent != null)
        secureChannelEvent(this, (OpenSecureChannelRequest) null, senderCertificate, ex);
      ReportAuditCertificateEventHandler certificateEvent = this.ReportAuditCertificateEvent;
      if (certificateEvent != null)
        certificateEvent(senderCertificate, ex);
      if (ex.InnerException is ServiceResultException innerException)
      {
        if (innerException.StatusCode != 2149187584U /*0x801A0000*/ && innerException.StatusCode != 2165112832U /*0x810D0000*/ && innerException.StatusCode != 2149384192U /*0x801D0000*/ && innerException.StatusCode != 2148663296U /*0x80120000*/ && innerException.StatusCode != 2165571584U && (innerException.InnerResult == null || !(innerException.InnerResult.StatusCode == 2149187584U /*0x801A0000*/)))
        {
          if (innerException.StatusCode == 2148794368U /*0x80140000*/ || innerException.StatusCode == 2148859904U /*0x80150000*/ || innerException.StatusCode == 2148925440U /*0x80160000*/ || innerException.StatusCode == 2148990976U /*0x80170000*/ || innerException.StatusCode == 2149056512U /*0x80180000*/ || innerException.StatusCode == 2149122048U /*0x80190000*/ || innerException.StatusCode == 2149253120U /*0x801B0000*/ || innerException.StatusCode == 2149318656U /*0x801C0000*/ || innerException.StatusCode == 2149449728U /*0x801E0000*/)
          {
            this.ForceChannelFault((Exception) innerException, innerException.StatusCode, ex.Message);
            return false;
          }
        }
        else
        {
          this.ForceChannelFault(2148728832U /*0x80130000*/, "Could not verify security on OpenSecureChannel request.");
          return false;
        }
      }
      this.ForceChannelFault(2148728832U /*0x80130000*/, "Could not verify security on OpenSecureChannel request.");
      return false;
    }
    BufferCollection buffers = (BufferCollection) null;
    OpenSecureChannelRequest request = (OpenSecureChannelRequest) null;
    try
    {
      bool firstCall = this.ClientCertificate == null;
      if (this.ClientCertificate != null)
        UaSCUaBinaryChannel.CompareCertificates(this.ClientCertificate, senderCertificate, false);
      else
        this.ClientCertificate = senderCertificate;
      if (!TcpMessageType.IsFinal(messageType))
      {
        this.SaveIntermediateChunk(requestId, chunk, true);
        return false;
      }
      buffers = this.GetSavedChunks(requestId, chunk, true);
      request = (OpenSecureChannelRequest) BinaryDecoder.DecodeMessage((Stream) new ArraySegmentStream(buffers), typeof (OpenSecureChannelRequest), this.Quotas.MessageContext);
      if (request == null)
        throw ServiceResultException.Create(2152071168U /*0x80460000*/, "Could not parse OpenSecureChannel request body.");
      if (request.SecurityMode != this.SecurityMode)
        this.ReviseSecurityMode(firstCall, request.SecurityMode);
      ChannelToken token = this.CreateToken();
      token.TokenId = this.GetNewTokenId();
      token.ServerNonce = this.CreateNonce();
      token.ClientNonce = request.ClientNonce;
      if (!this.ValidateNonce(token.ClientNonce))
        throw ServiceResultException.Create(2149842944U /*0x80240000*/, "Client nonce is not the correct length or not random enough.");
      int num = (int) request.RequestedLifetime;
      if (num < 60000)
        num = 60000;
      if (num > 0 && num < token.Lifetime)
        token.Lifetime = num;
      SecurityTokenRequestType requestType = request.RequestType;
      if (requestType == SecurityTokenRequestType.Issue && this.State != TcpChannelState.Opening)
        throw ServiceResultException.Create(2152923136U /*0x80530000*/, "Cannot request a new token for an open channel.");
      if (requestType == SecurityTokenRequestType.Renew && this.State != TcpChannelState.Open)
      {
        if (this.State != TcpChannelState.Opening)
          throw ServiceResultException.Create(2152923136U /*0x80530000*/, "Cannot request to renew a token for a channel that has not been opened.");
        this.Listener.ReconnectToExistingChannel(this.Socket, requestId, sequenceNumber, channelId, this.ClientCertificate, token, request);
        Utils.LogInfo("{0} ReconnectToExistingChannel Socket={1:X8}, ChannelId={2}, TokenId={3}", (object) this.ChannelName, (object) (this.Socket != null ? this.Socket.Handle : 0), (object) (uint) (this.CurrentToken != null ? (int) this.CurrentToken.ChannelId : 0), (object) (uint) (this.CurrentToken != null ? (int) this.CurrentToken.TokenId : 0));
        this.ChannelClosed();
        return false;
      }
      if (requestType == SecurityTokenRequestType.Renew && (int) channelId != (int) this.ChannelId)
        throw ServiceResultException.Create(2155806720U /*0x807F0000*/, "Do not recognize the secure channel id provided.");
      if (requestType == SecurityTokenRequestType.Issue)
        Audit.SecureChannelCreated(this.m_ImplementationString, this.Listener.EndpointUrl.ToString(), Utils.Format("{0}", (object) this.ChannelId), this.EndpointDescription, this.ClientCertificate, this.ServerCertificate, BinaryEncodingSupport.Required);
      else
        Audit.SecureChannelRenewed(this.m_ImplementationString, Utils.Format("{0}", (object) this.ChannelId));
      if (requestType == SecurityTokenRequestType.Renew)
        this.SetRenewedToken(token);
      else
        this.ActivateToken(token);
      this.State = TcpChannelState.Open;
      this.SendOpenSecureChannelResponse(requestId, token, request);
      this.CompleteReverseHello((Exception) null);
      this.NotifyMonitors(ServiceResult.Good, false);
      if (requestType == SecurityTokenRequestType.Issue)
      {
        ReportAuditOpenSecureChannelEventHandler secureChannelEvent = this.ReportAuditOpenSecureChannelEvent;
        if (secureChannelEvent != null)
          secureChannelEvent(this, request, this.ClientCertificate, (Exception) null);
      }
      return false;
    }
    catch (Exception ex)
    {
      ReportAuditOpenSecureChannelEventHandler secureChannelEvent = this.ReportAuditOpenSecureChannelEvent;
      if (secureChannelEvent != null)
        secureChannelEvent(this, request, this.ClientCertificate, ex);
      this.SendServiceFault(requestId, ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "Unexpected error processing OpenSecureChannel request."));
      this.CompleteReverseHello(ex);
      return false;
    }
    finally
    {
      buffers?.Release(this.BufferManager, nameof (ProcessOpenSecureChannelRequest));
    }
  }

  protected override void NotifyMonitors(ServiceResult status, bool closed)
  {
    try
    {
      TcpChannelStatusEventHandler statusChanged = this.StatusChanged;
      if (statusChanged == null)
        return;
      statusChanged(this, status, closed);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Error raising StatusChanged event.", objArray);
    }
  }

  protected override void CompleteReverseHello(Exception e)
  {
    TcpServerChannel.ReverseConnectAsyncResult pendingReverseHello = this.m_pendingReverseHello;
    if (pendingReverseHello == null || pendingReverseHello != Interlocked.CompareExchange<TcpServerChannel.ReverseConnectAsyncResult>(ref this.m_pendingReverseHello, (TcpServerChannel.ReverseConnectAsyncResult) null, pendingReverseHello))
      return;
    pendingReverseHello.Exception = e;
    pendingReverseHello.OperationCompleted();
  }

  private void SendOpenSecureChannelResponse(
    uint requestId,
    ChannelToken token,
    OpenSecureChannelRequest request)
  {
    Utils.LogTrace("ChannelId {0}: SendOpenSecureChannelResponse()", (object) this.ChannelId);
    byte[] array = BinaryEncoder.EncodeMessage((IEncodeable) new OpenSecureChannelResponse()
    {
      ResponseHeader = {
        RequestHandle = request.RequestHeader.RequestHandle,
        Timestamp = DateTime.UtcNow
      },
      SecurityToken = {
        ChannelId = token.ChannelId,
        TokenId = token.TokenId,
        CreatedAt = token.CreatedAt,
        RevisedLifetime = (uint) token.Lifetime
      },
      ServerNonce = token.ServerNonce
    }, this.Quotas.MessageContext);
    BufferCollection buffers = this.WriteAsymmetricMessage(5132367U, requestId, this.ServerCertificate, this.ServerCertificateChain, this.ClientCertificate, new ArraySegment<byte>(array, 0, array.Length));
    try
    {
      this.BeginWriteMessage(buffers, (object) null);
      buffers = (BufferCollection) null;
    }
    finally
    {
      buffers?.Release(this.BufferManager, nameof (SendOpenSecureChannelResponse));
    }
  }

  private bool ProcessCloseSecureChannelRequest(uint messageType, ArraySegment<byte> messageChunk)
  {
    ChannelToken token = (ChannelToken) null;
    uint requestId = 0;
    uint sequenceNumber = 0;
    ArraySegment<byte> chunk;
    try
    {
      chunk = this.ReadSymmetricMessage(messageChunk, true, out token, out requestId, out sequenceNumber);
      if (!this.VerifySequenceNumber(sequenceNumber, nameof (ProcessCloseSecureChannelRequest)))
        throw new ServiceResultException(2156396544U /*0x80880000*/, "Could not verify security on CloseSecureChannel request.");
    }
    catch (Exception ex)
    {
      ReportAuditCloseSecureChannelEventHandler secureChannelEvent = this.ReportAuditCloseSecureChannelEvent;
      if (secureChannelEvent != null)
        secureChannelEvent(this, ex);
      throw ServiceResultException.Create(2148728832U /*0x80130000*/, ex, "Could not verify security on CloseSecureChannel request.");
    }
    BufferCollection buffers = (BufferCollection) null;
    try
    {
      if (!TcpMessageType.IsFinal(messageType))
      {
        this.SaveIntermediateChunk(requestId, chunk, true);
        return false;
      }
      buffers = this.GetSavedChunks(requestId, chunk, true);
      if (!(BinaryDecoder.DecodeMessage((Stream) new ArraySegmentStream(buffers), typeof (CloseSecureChannelRequest), this.Quotas.MessageContext) is CloseSecureChannelRequest))
        throw ServiceResultException.Create(2152071168U /*0x80460000*/, "Could not parse CloseSecureChannel request body.");
      ReportAuditCloseSecureChannelEventHandler secureChannelEvent = this.ReportAuditCloseSecureChannelEvent;
      if (secureChannelEvent != null)
        secureChannelEvent(this, (Exception) null);
    }
    catch (Exception ex)
    {
      ReportAuditCloseSecureChannelEventHandler secureChannelEvent = this.ReportAuditCloseSecureChannelEvent;
      if (secureChannelEvent != null)
        secureChannelEvent(this, ex);
      Utils.LogError(ex, "Unexpected error processing CloseSecureChannel request.");
    }
    finally
    {
      buffers?.Release(this.BufferManager, nameof (ProcessCloseSecureChannelRequest));
      Utils.LogInfo("{0} ProcessCloseSecureChannelRequest success, ChannelId={1}, TokenId={2}, Socket={3:X8}", (object) this.ChannelName, (object) this.CurrentToken?.ChannelId, (object) this.CurrentToken?.TokenId, (object) this.Socket?.Handle);
      this.ChannelClosed();
    }
    return true;
  }

  private bool ProcessRequestMessage(uint messageType, ArraySegment<byte> messageChunk)
  {
    if (this.State != TcpChannelState.Open)
    {
      this.ForceChannelFault(2155741184U /*0x807E0000*/, "Client sent an unexpected request message.");
      return false;
    }
    ChannelToken token = (ChannelToken) null;
    uint requestId = 0;
    uint sequenceNumber = 0;
    ArraySegment<byte> arraySegment;
    try
    {
      arraySegment = this.ReadSymmetricMessage(messageChunk, true, out token, out requestId, out sequenceNumber);
      if (!this.VerifySequenceNumber(sequenceNumber, nameof (ProcessRequestMessage)))
        throw new ServiceResultException(2156396544U /*0x80880000*/);
      if (token == this.CurrentToken)
      {
        if (this.PreviousToken != null)
        {
          if (!this.PreviousToken.Expired)
          {
            Utils.LogInfo("ChannelId {0}: Server Current Token #{1}, Revoked Token #{2}.", (object) this.PreviousToken.ChannelId, (object) this.CurrentToken.TokenId, (object) this.PreviousToken.TokenId);
            this.PreviousToken.Lifetime = 0;
          }
        }
      }
    }
    catch (Exception ex)
    {
      this.ForceChannelFault(ex, 2148728832U /*0x80130000*/, "Could not verify security on incoming request.");
      return false;
    }
    int num = 5;
    while (this.ChannelFull && num > 0)
    {
      Utils.LogInfo("Channel {0}: full -- delay processing.", (object) this.Id);
      Thread.Sleep(1000);
      if (--num == 0 && this.ChannelFull)
      {
        Utils.LogWarning("Channel {0}: break socket connection.", (object) this.Id);
        this.ChannelClosed();
        return false;
      }
    }
    BufferCollection chunksToProcess = (BufferCollection) null;
    try
    {
      if (TcpMessageType.IsAbort(messageType))
      {
        Utils.LogWarning((EventId) 16 /*0x10*/, "ChannelId {0}: ProcessRequestMessage RequestId {1} was aborted.", (object) this.ChannelId, (object) requestId);
        chunksToProcess = this.GetSavedChunks(requestId, arraySegment, true);
        return true;
      }
      if (!TcpMessageType.IsFinal(messageType))
      {
        bool flag = this.SaveIntermediateChunk(requestId, arraySegment, true);
        if (this.DiscoveryOnly)
        {
          if (flag)
          {
            if (!this.ValidateDiscoveryServiceCall(token, requestId, arraySegment, out chunksToProcess))
              this.ChannelClosed();
          }
          else if (this.GetSavedChunksTotalSize() > (int) ushort.MaxValue)
          {
            chunksToProcess = this.GetSavedChunks(0U, arraySegment, true);
            this.SendServiceFault(token, requestId, ServiceResult.Create(2153054208U /*0x80550000*/, "Discovery Channel message size exceeded."));
            this.ChannelClosed();
          }
        }
        return true;
      }
      if (this.DiscoveryOnly && this.GetSavedChunksTotalSize() == 0 && !this.ValidateDiscoveryServiceCall(token, requestId, arraySegment, out chunksToProcess))
        return true;
      chunksToProcess = this.GetSavedChunks(requestId, arraySegment, true);
      if (!(BinaryDecoder.DecodeMessage((Stream) new ArraySegmentStream(chunksToProcess), (Type) null, this.Quotas.MessageContext) is IServiceRequest request))
      {
        this.SendServiceFault(token, requestId, ServiceResult.Create(2152071168U /*0x80460000*/, "Could not parse request body."));
        return true;
      }
      if (this.DiscoveryOnly)
      {
        switch (request)
        {
          case GetEndpointsRequest _:
          case FindServersRequest _:
          case FindServersOnNetworkRequest _:
            break;
          default:
            this.SendServiceFault(token, requestId, ServiceResult.Create(2153054208U /*0x80550000*/, "Channel can only be used for discovery."));
            return true;
        }
      }
      TcpChannelRequestEventHandler requestReceived = this.RequestReceived;
      if (requestReceived != null)
        requestReceived((TcpListenerChannel) this, requestId, request);
      return true;
    }
    catch (Exception ex)
    {
      Utils.LogError(ex, "Unexpected error processing request.");
      this.SendServiceFault(token, requestId, ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "Unexpected error processing request."));
      return true;
    }
    finally
    {
      chunksToProcess?.Release(this.BufferManager, nameof (ProcessRequestMessage));
    }
  }

  public void SendResponse(uint requestId, IServiceResponse response)
  {
    if (response == null)
      throw new ArgumentNullException(nameof (response));
    lock (this.DataLock)
    {
      if (this.State != TcpChannelState.Faulted)
      {
        Utils.EventLog.SendResponse((int) this.ChannelId, (int) requestId);
        BufferCollection bufferCollection = (BufferCollection) null;
        BufferCollection buffers;
        try
        {
          bool limitsExceeded = false;
          buffers = this.WriteSymmetricMessage(4674381U, requestId, this.CurrentToken, (object) response, false, out limitsExceeded);
        }
        catch (Exception ex)
        {
          this.SendServiceFault(this.CurrentToken, requestId, ServiceResult.Create(ex, 2147876864U /*0x80060000*/, "Could not encode outgoing message."));
          return;
        }
        try
        {
          this.BeginWriteMessage(buffers, (object) null);
          bufferCollection = (BufferCollection) null;
        }
        catch (Exception ex)
        {
          buffers?.Release(this.BufferManager, nameof (SendResponse));
          this.m_queuedResponses[requestId] = response;
        }
      }
      else
        this.m_queuedResponses[requestId] = response;
    }
  }

  private void ResetQueuedResponses(Action<object> action)
  {
    Task.Factory.StartNew(action, (object) this.m_queuedResponses);
    this.m_queuedResponses = new SortedDictionary<uint, IServiceResponse>();
  }

  protected override void DoMessageLimitsExceeded()
  {
    base.DoMessageLimitsExceeded();
    this.ChannelClosed();
  }

  private bool ValidateDiscoveryServiceCall(
    ChannelToken token,
    uint requestId,
    ArraySegment<byte> messageBody,
    out BufferCollection chunksToProcess)
  {
    chunksToProcess = (BufferCollection) null;
    using (BinaryDecoder binaryDecoder = new BinaryDecoder(messageBody.AsMemory<byte>().ToArray(), this.Quotas.MessageContext))
    {
      NodeId nodeId = binaryDecoder.ReadNodeId((string) null);
      if (!(nodeId != (object) ObjectIds.GetEndpointsRequest_Encoding_DefaultBinary) || !(nodeId != (object) ObjectIds.FindServersRequest_Encoding_DefaultBinary) || !(nodeId != (object) ObjectIds.FindServersOnNetworkRequest_Encoding_DefaultBinary))
        return true;
      chunksToProcess = this.GetSavedChunks(0U, messageBody, true);
      this.SendServiceFault(token, requestId, ServiceResult.Create(2153054208U /*0x80550000*/, "Channel can only be used for discovery."));
      return false;
    }
  }

  private class ReverseConnectAsyncResult(AsyncCallback callback, object callbackData, int timeout) : 
    AsyncResultBase(callback, callbackData, timeout)
  {
    public IMessageSocket Socket;
  }
}
