// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpListenerChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpListenerChannel : UaSCUaBinaryChannel
{
  private ITcpChannelListener m_listener;
  private bool m_responseRequired;
  private TcpChannelRequestEventHandler m_requestReceived;
  private ReportAuditOpenSecureChannelEventHandler m_reportAuditOpenSecureChannelEvent;
  private ReportAuditCloseSecureChannelEventHandler m_reportAuditCloseSecureChannelEvent;
  private ReportAuditCertificateEventHandler m_reportAuditCertificateEvent;
  private long m_lastTokenId;
  private Timer m_cleanupTimer;

  public TcpListenerChannel(
    string contextId,
    ITcpChannelListener listener,
    BufferManager bufferManager,
    ChannelQuotas quotas,
    X509Certificate2 serverCertificate,
    EndpointDescriptionCollection endpoints)
    : this(contextId, listener, bufferManager, quotas, serverCertificate, (X509Certificate2Collection) null, endpoints)
  {
  }

  public TcpListenerChannel(
    string contextId,
    ITcpChannelListener listener,
    BufferManager bufferManager,
    ChannelQuotas quotas,
    X509Certificate2 serverCertificate,
    X509Certificate2Collection serverCertificateChain,
    EndpointDescriptionCollection endpoints)
    : base(contextId, bufferManager, quotas, serverCertificate, serverCertificateChain, endpoints, MessageSecurityMode.None, "http://opcfoundation.org/UA/SecurityPolicy#None")
  {
    this.m_listener = listener;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
    {
      Utils.SilentDispose((IDisposable) this.m_cleanupTimer);
      this.m_cleanupTimer = (Timer) null;
    }
    base.Dispose(disposing);
  }

  public virtual string ChannelName => "TCPLISTENERCHANNEL";

  protected ITcpChannelListener Listener => this.m_listener;

  public void SetRequestReceivedCallback(TcpChannelRequestEventHandler callback)
  {
    lock (this.DataLock)
      this.m_requestReceived = callback;
  }

  public void SetReportOpenSecureChannellAuditCalback(
    ReportAuditOpenSecureChannelEventHandler callback)
  {
    lock (this.DataLock)
      this.m_reportAuditOpenSecureChannelEvent = callback;
  }

  public void SetReportCloseSecureChannellAuditCalback(
    ReportAuditCloseSecureChannelEventHandler callback)
  {
    lock (this.DataLock)
      this.m_reportAuditCloseSecureChannelEvent = callback;
  }

  public void SetReportCertificateAuditCalback(ReportAuditCertificateEventHandler callback)
  {
    lock (this.DataLock)
      this.m_reportAuditCertificateEvent = callback;
  }

  public void Attach(uint channelId, System.Net.Sockets.Socket socket)
  {
    if (socket == null)
      throw new ArgumentNullException(nameof (socket));
    lock (this.DataLock)
    {
      if (this.Socket != null)
        throw new InvalidOperationException("Channel is already attached to a socket.");
      this.ChannelId = channelId;
      this.State = TcpChannelState.Connecting;
      this.Socket = (IMessageSocket) new TcpMessageSocket((IMessageSink) this, socket, this.BufferManager, this.Quotas.MaxBufferSize);
      Utils.LogInfo("{0} SOCKET ATTACHED: {1:X8}, ChannelId={2}", (object) this.ChannelName, (object) this.Socket.Handle, (object) this.ChannelId);
      this.Socket.ReadNextMessage();
      this.StartCleanupTimer((ServiceResult) 2148139008U /*0x800A0000*/);
    }
  }

  protected override void HandleSocketError(ServiceResult result)
  {
    lock (this.DataLock)
    {
      if (ServiceResult.IsBad(result))
        this.ForceChannelFault(result);
      else
        this.ChannelClosed();
    }
  }

  protected void ForceChannelFault(uint statusCode, string format, params object[] args)
  {
    this.ForceChannelFault(ServiceResult.Create(statusCode, format, args));
  }

  protected void ForceChannelFault(
    Exception exception,
    uint defaultCode,
    string format,
    params object[] args)
  {
    this.ForceChannelFault(ServiceResult.Create(exception, defaultCode, format, args));
  }

  protected void ForceChannelFault(ServiceResult reason)
  {
    lock (this.DataLock)
    {
      Utils.LogError("{0} ForceChannelFault Socket={1:X8}, ChannelId={2}, TokenId={3}, Reason={4}", (object) this.ChannelName, (object) (this.Socket != null ? this.Socket.Handle : 0), (object) (uint) (this.CurrentToken != null ? (int) this.CurrentToken.ChannelId : 0), (object) (uint) (this.CurrentToken != null ? (int) this.CurrentToken.TokenId : 0), (object) reason);
      this.CompleteReverseHello((Exception) new ServiceResultException(reason));
      if (this.State == TcpChannelState.Faulted)
        return;
      if (this.Socket != null && this.m_responseRequired)
        this.SendErrorMessage(reason);
      this.State = TcpChannelState.Faulted;
      this.m_responseRequired = false;
      this.NotifyMonitors(reason, false);
      this.StartCleanupTimer(reason);
    }
  }

  protected void StartCleanupTimer(ServiceResult reason)
  {
    this.CleanupTimer();
    this.m_cleanupTimer = new Timer(new TimerCallback(this.OnCleanup), (object) reason, this.Quotas.ChannelLifetime, -1);
  }

  protected void CleanupTimer()
  {
    if (this.m_cleanupTimer == null)
      return;
    this.m_cleanupTimer.Dispose();
    this.m_cleanupTimer = (Timer) null;
  }

  private void OnCleanup(object state)
  {
    lock (this.DataLock)
    {
      this.CleanupTimer();
      if (this.State == TcpChannelState.Closed || this.State == TcpChannelState.Open)
        return;
      if (!(state is ServiceResult serviceResult))
        serviceResult = new ServiceResult(2148139008U /*0x800A0000*/);
      Utils.LogInfo("{0} Cleanup Socket={1:X8}, ChannelId={2}, TokenId={3}, Reason={4}", (object) this.ChannelName, (object) (this.Socket != null ? this.Socket.Handle : 0), (object) (uint) (this.CurrentToken != null ? (int) this.CurrentToken.ChannelId : 0), (object) (uint) (this.CurrentToken != null ? (int) this.CurrentToken.TokenId : 0), (object) serviceResult.ToString());
      this.ChannelClosed();
    }
  }

  protected void ChannelClosed()
  {
    try
    {
      if (this.Socket == null)
        return;
      this.Socket.Close();
    }
    finally
    {
      this.State = TcpChannelState.Closed;
      this.m_listener.ChannelClosed(this.ChannelId);
      this.NotifyMonitors(new ServiceResult(2158886912U /*0x80AE0000*/), true);
      this.CleanupTimer();
    }
  }

  protected void SendErrorMessage(ServiceResult error)
  {
    Utils.LogTrace("ChannelId {0}: SendErrorMessage={1}", (object) this.ChannelId, (object) error.StatusCode);
    byte[] numArray = this.BufferManager.TakeBuffer(this.SendBufferSize, nameof (SendErrorMessage));
    try
    {
      using (BinaryEncoder encoder = new BinaryEncoder(numArray, 0, this.SendBufferSize, this.Quotas.MessageContext))
      {
        encoder.WriteUInt32((string) null, 1179800133U);
        encoder.WriteUInt32((string) null, 0U);
        UaSCUaBinaryChannel.WriteErrorMessageBody(encoder, error);
        int num = encoder.Close();
        UaSCUaBinaryChannel.UpdateMessageSize(numArray, 0, num);
        this.BeginWriteMessage(new ArraySegment<byte>(numArray, 0, num), (object) null);
        numArray = (byte[]) null;
      }
    }
    finally
    {
      if (numArray != null)
        this.BufferManager.ReturnBuffer(numArray, nameof (SendErrorMessage));
    }
  }

  protected void SendServiceFault(ChannelToken token, uint requestId, ServiceResult fault)
  {
    Utils.LogTrace("ChannelId {0}: Request {1}: SendServiceFault={2}", (object) this.ChannelId, (object) requestId, (object) fault.StatusCode);
    BufferCollection buffers = (BufferCollection) null;
    try
    {
      ServiceFault messageBody = new ServiceFault();
      messageBody.ResponseHeader.ServiceResult = (StatusCode) fault.Code;
      StringTable stringTable = new StringTable();
      messageBody.ResponseHeader.ServiceDiagnostics = new DiagnosticInfo(fault, DiagnosticsMasks.NoInnerStatus, true, stringTable);
      messageBody.ResponseHeader.StringTable = (StringCollection) stringTable.ToArray();
      bool limitsExceeded = false;
      buffers = this.WriteSymmetricMessage(4674381U, requestId, token, (object) messageBody, false, out limitsExceeded);
      this.BeginWriteMessage(buffers, (object) null);
    }
    catch (Exception ex)
    {
      buffers?.Release(this.BufferManager, nameof (SendServiceFault));
      this.ForceChannelFault(ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "Unexpected error sending a service fault."));
    }
  }

  protected virtual void NotifyMonitors(ServiceResult status, bool closed)
  {
  }

  protected virtual void CompleteReverseHello(Exception e)
  {
  }

  protected void SendServiceFault(uint requestId, ServiceResult fault)
  {
    Utils.LogTrace("ChannelId {0}: Request {1}: SendServiceFault={2}", (object) this.ChannelId, (object) requestId, (object) fault.StatusCode);
    BufferCollection buffers = (BufferCollection) null;
    try
    {
      ServiceFault message = new ServiceFault();
      message.ResponseHeader.ServiceResult = (StatusCode) fault.Code;
      StringTable stringTable = new StringTable();
      message.ResponseHeader.ServiceDiagnostics = new DiagnosticInfo(fault, DiagnosticsMasks.NoInnerStatus, true, stringTable);
      message.ResponseHeader.StringTable = (StringCollection) stringTable.ToArray();
      byte[] array = BinaryEncoder.EncodeMessage((IEncodeable) message, this.Quotas.MessageContext);
      buffers = this.WriteAsymmetricMessage(5132367U, requestId, this.ServerCertificate, this.ClientCertificate, new ArraySegment<byte>(array, 0, array.Length));
      this.BeginWriteMessage(buffers, (object) null);
    }
    catch (Exception ex)
    {
      buffers?.Release(this.BufferManager, nameof (SendServiceFault));
      this.ForceChannelFault(ServiceResult.Create(ex, 2156003328U /*0x80820000*/, "Unexpected error sending a service fault."));
    }
  }

  public virtual void Reconnect(
    IMessageSocket socket,
    uint requestId,
    uint sequenceNumber,
    X509Certificate2 clientCertificate,
    ChannelToken token,
    OpenSecureChannelRequest request)
  {
    throw new NotImplementedException();
  }

  protected void SetResponseRequired(bool responseRequired)
  {
    this.m_responseRequired = responseRequired;
  }

  protected uint GetNewTokenId() => Utils.IncrementIdentifier(ref this.m_lastTokenId);

  protected TcpChannelRequestEventHandler RequestReceived => this.m_requestReceived;

  protected ReportAuditOpenSecureChannelEventHandler ReportAuditOpenSecureChannelEvent
  {
    get => this.m_reportAuditOpenSecureChannelEvent;
  }

  protected ReportAuditCloseSecureChannelEventHandler ReportAuditCloseSecureChannelEvent
  {
    get => this.m_reportAuditCloseSecureChannelEvent;
  }

  protected ReportAuditCertificateEventHandler ReportAuditCertificateEvent
  {
    get => this.m_reportAuditCertificateEvent;
  }
}
