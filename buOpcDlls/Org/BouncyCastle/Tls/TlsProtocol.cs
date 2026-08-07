// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsProtocol
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class TlsProtocol : TlsCloseable
{
  protected const short CS_START = 0;
  protected const short CS_CLIENT_HELLO = 1;
  protected const short CS_SERVER_HELLO_RETRY_REQUEST = 2;
  protected const short CS_CLIENT_HELLO_RETRY = 3;
  protected const short CS_SERVER_HELLO = 4;
  protected const short CS_SERVER_ENCRYPTED_EXTENSIONS = 5;
  protected const short CS_SERVER_SUPPLEMENTAL_DATA = 6;
  protected const short CS_SERVER_CERTIFICATE = 7;
  protected const short CS_SERVER_CERTIFICATE_STATUS = 8;
  protected const short CS_SERVER_CERTIFICATE_VERIFY = 9;
  protected const short CS_SERVER_KEY_EXCHANGE = 10;
  protected const short CS_SERVER_CERTIFICATE_REQUEST = 11;
  protected const short CS_SERVER_HELLO_DONE = 12;
  protected const short CS_CLIENT_END_OF_EARLY_DATA = 13;
  protected const short CS_CLIENT_SUPPLEMENTAL_DATA = 14;
  protected const short CS_CLIENT_CERTIFICATE = 15;
  protected const short CS_CLIENT_KEY_EXCHANGE = 16 /*0x10*/;
  protected const short CS_CLIENT_CERTIFICATE_VERIFY = 17;
  protected const short CS_CLIENT_FINISHED = 18;
  protected const short CS_SERVER_SESSION_TICKET = 19;
  protected const short CS_SERVER_FINISHED = 20;
  protected const short CS_END = 21;
  protected const short ADS_MODE_1_Nsub1 = 0;
  protected const short ADS_MODE_0_N = 1;
  protected const short ADS_MODE_0_N_FIRSTONLY = 2;
  private readonly ByteQueue m_applicationDataQueue = new ByteQueue(0);
  private readonly ByteQueue m_alertQueue = new ByteQueue(2);
  private readonly ByteQueue m_handshakeQueue = new ByteQueue(0);
  internal readonly RecordStream m_recordStream;
  internal readonly object m_recordWriteLock = new object();
  private int m_maxHandshakeMessageSize = -1;
  internal TlsHandshakeHash m_handshakeHash;
  private TlsStream m_tlsStream;
  private volatile bool m_closed;
  private volatile bool m_failedWithError;
  private volatile bool m_appDataReady;
  private volatile bool m_appDataSplitEnabled = true;
  private volatile bool m_keyUpdateEnabled;
  private volatile bool m_keyUpdatePendingSend;
  private volatile bool m_resumableHandshake;
  private volatile int m_appDataSplitMode;
  protected TlsSession m_tlsSession;
  protected SessionParameters m_sessionParameters;
  protected TlsSecret m_sessionMasterSecret;
  protected byte[] m_retryCookie;
  protected int m_retryGroup = -1;
  protected IDictionary<int, byte[]> m_clientExtensions;
  protected IDictionary<int, byte[]> m_serverExtensions;
  protected short m_connectionState;
  protected bool m_selectedPsk13;
  protected bool m_receivedChangeCipherSpec;
  protected bool m_expectSessionTicket;
  protected readonly bool m_blocking;
  protected readonly ByteQueueInputStream m_inputBuffers;
  protected readonly ByteQueueOutputStream m_outputBuffer;

  protected bool IsLegacyConnectionState()
  {
    switch (this.m_connectionState)
    {
      case 0:
      case 1:
      case 4:
      case 6:
      case 7:
      case 8:
      case 10:
      case 11:
      case 12:
      case 14:
      case 15:
      case 16 /*0x10*/:
      case 17:
      case 18:
      case 19:
      case 20:
      case 21:
        return true;
      default:
        return false;
    }
  }

  protected bool IsTlsV13ConnectionState()
  {
    switch (this.m_connectionState)
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 7:
      case 9:
      case 11:
      case 13:
      case 15:
      case 17:
      case 18:
      case 20:
      case 21:
        return true;
      default:
        return false;
    }
  }

  protected TlsProtocol()
  {
    this.m_blocking = false;
    this.m_inputBuffers = new ByteQueueInputStream();
    this.m_outputBuffer = new ByteQueueOutputStream();
    this.m_recordStream = new RecordStream(this, (Stream) this.m_inputBuffers, (Stream) this.m_outputBuffer);
  }

  public TlsProtocol(Stream stream)
    : this(stream, stream)
  {
  }

  public TlsProtocol(Stream input, Stream output)
  {
    this.m_blocking = true;
    this.m_inputBuffers = (ByteQueueInputStream) null;
    this.m_outputBuffer = (ByteQueueOutputStream) null;
    this.m_recordStream = new RecordStream(this, input, output);
  }

  public virtual void ResumeHandshake()
  {
    if (!this.m_blocking)
      throw new InvalidOperationException("Cannot use ResumeHandshake() in non-blocking mode!");
    if (!this.IsHandshaking)
      throw new InvalidOperationException("No handshake in progress");
    this.BlockForHandshake();
  }

  protected virtual void CloseConnection() => this.m_recordStream.Close();

  protected abstract TlsContext Context { get; }

  internal abstract AbstractTlsContext ContextAdmin { get; }

  protected abstract TlsPeer Peer { get; }

  protected virtual void HandleAlertMessage(short alertLevel, short alertDescription)
  {
    this.Peer.NotifyAlertReceived(alertLevel, alertDescription);
    if (alertLevel != (short) 1)
    {
      this.HandleFailure();
      throw new TlsFatalAlertReceived(alertDescription);
    }
    this.HandleAlertWarningMessage(alertDescription);
  }

  protected virtual void HandleAlertWarningMessage(short alertDescription)
  {
    if (alertDescription != (short) 0)
    {
      if (alertDescription == (short) 41)
        throw new TlsFatalAlert((short) 10);
      if (alertDescription == (short) 100)
        throw new TlsFatalAlert((short) 40);
    }
    else
    {
      if (!this.m_appDataReady)
        throw new TlsFatalAlert((short) 40);
      this.HandleClose(false);
    }
  }

  protected virtual void HandleChangeCipherSpecMessage()
  {
  }

  protected virtual void HandleClose(bool user_canceled)
  {
    if (this.m_closed)
      return;
    this.m_closed = true;
    if (!this.m_appDataReady)
    {
      this.CleanupHandshake();
      if (user_canceled)
        this.RaiseAlertWarning((short) 90, "User canceled handshake");
    }
    this.RaiseAlertWarning((short) 0, "Connection closed");
    this.CloseConnection();
  }

  protected virtual void HandleException(short alertDescription, string message, Exception e)
  {
    if (this.m_closed)
      return;
    this.RaiseAlertFatal(alertDescription, message, e);
    this.HandleFailure();
  }

  protected virtual void HandleFailure()
  {
    this.m_closed = true;
    this.m_failedWithError = true;
    this.InvalidateSession();
    if (!this.m_appDataReady)
      this.CleanupHandshake();
    this.CloseConnection();
  }

  protected abstract void HandleHandshakeMessage(short type, HandshakeMessageInput buf);

  protected virtual void ApplyMaxFragmentLengthExtension(short maxFragmentLength)
  {
    if (maxFragmentLength < (short) 0)
      return;
    if (!MaxFragmentLength.IsValid(maxFragmentLength))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_recordStream.SetPlaintextLimit(1 << 8 + (int) maxFragmentLength);
  }

  protected virtual void CheckReceivedChangeCipherSpec(bool expected)
  {
    if (expected != this.m_receivedChangeCipherSpec)
      throw new TlsFatalAlert((short) 10);
  }

  protected virtual void BlockForHandshake()
  {
    while (this.m_connectionState != (short) 21)
    {
      if (this.IsClosed)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      this.SafeReadRecord();
    }
  }

  protected virtual void BeginHandshake()
  {
    AbstractTlsContext contextAdmin = this.ContextAdmin;
    TlsPeer peer = this.Peer;
    this.m_maxHandshakeMessageSize = Math.Max(1024 /*0x0400*/, peer.GetMaxHandshakeMessageSize());
    this.m_handshakeHash = (TlsHandshakeHash) new DeferredHash((TlsContext) contextAdmin);
    this.m_connectionState = (short) 0;
    this.m_selectedPsk13 = false;
    contextAdmin.HandshakeBeginning(peer);
    contextAdmin.SecurityParameters.m_extendedPadding = peer.ShouldUseExtendedPadding();
  }

  protected virtual void CleanupHandshake()
  {
    this.Context?.SecurityParameters?.Clear();
    this.m_tlsSession = (TlsSession) null;
    this.m_sessionParameters = (SessionParameters) null;
    this.m_sessionMasterSecret = (TlsSecret) null;
    this.m_retryCookie = (byte[]) null;
    this.m_retryGroup = -1;
    this.m_clientExtensions = (IDictionary<int, byte[]>) null;
    this.m_serverExtensions = (IDictionary<int, byte[]>) null;
    this.m_selectedPsk13 = false;
    this.m_receivedChangeCipherSpec = false;
    this.m_expectSessionTicket = false;
  }

  protected virtual void CompleteHandshake()
  {
    try
    {
      AbstractTlsContext contextAdmin = this.ContextAdmin;
      SecurityParameters securityParameters = contextAdmin.SecurityParameters;
      if (!contextAdmin.IsHandshaking || securityParameters.LocalVerifyData == null || securityParameters.PeerVerifyData == null)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      this.m_recordStream.FinaliseHandshake();
      this.m_connectionState = (short) 21;
      this.m_handshakeHash = (TlsHandshakeHash) new DeferredHash((TlsContext) contextAdmin);
      this.m_alertQueue.Shrink();
      this.m_handshakeQueue.Shrink();
      ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
      this.m_appDataSplitEnabled = !TlsUtilities.IsTlsV11(negotiatedVersion);
      this.m_appDataReady = true;
      this.m_keyUpdateEnabled = TlsUtilities.IsTlsV13(negotiatedVersion);
      if (this.m_blocking)
        this.m_tlsStream = new TlsStream(this);
      if (this.m_sessionParameters == null)
      {
        this.m_sessionMasterSecret = securityParameters.MasterSecret;
        this.m_sessionParameters = new SessionParameters.Builder().SetCipherSuite(securityParameters.CipherSuite).SetExtendedMasterSecret(securityParameters.IsExtendedMasterSecret).SetLocalCertificate(securityParameters.LocalCertificate).SetMasterSecret(contextAdmin.Crypto.AdoptSecret(this.m_sessionMasterSecret)).SetNegotiatedVersion(securityParameters.NegotiatedVersion).SetPeerCertificate(securityParameters.PeerCertificate).SetPskIdentity(securityParameters.PskIdentity).SetSrpIdentity(securityParameters.SrpIdentity).SetServerExtensions(this.m_serverExtensions).Build();
        this.m_tlsSession = TlsUtilities.ImportSession(securityParameters.SessionID, this.m_sessionParameters);
      }
      else
      {
        securityParameters.m_localCertificate = this.m_sessionParameters.LocalCertificate;
        securityParameters.m_peerCertificate = this.m_sessionParameters.PeerCertificate;
        securityParameters.m_pskIdentity = this.m_sessionParameters.PskIdentity;
        securityParameters.m_srpIdentity = this.m_sessionParameters.SrpIdentity;
      }
      contextAdmin.HandshakeComplete(this.Peer, this.m_tlsSession);
    }
    finally
    {
      this.CleanupHandshake();
    }
  }

  internal void ProcessRecord(short protocol, byte[] buf, int off, int len)
  {
    switch (protocol)
    {
      case 20:
        this.ProcessChangeCipherSpec(buf, off, len);
        break;
      case 21:
        this.m_alertQueue.AddData(buf, off, len);
        this.ProcessAlertQueue();
        break;
      case 22:
        if (this.m_handshakeQueue.Available > 0)
        {
          this.m_handshakeQueue.AddData(buf, off, len);
          this.ProcessHandshakeQueue(this.m_handshakeQueue);
          break;
        }
        ByteQueue queue = new ByteQueue(buf, off, len);
        this.ProcessHandshakeQueue(queue);
        int available = queue.Available;
        if (available <= 0)
          break;
        this.m_handshakeQueue.AddData(buf, off + len - available, available);
        break;
      case 23:
        if (!this.m_appDataReady)
          throw new TlsFatalAlert((short) 10);
        this.m_applicationDataQueue.AddData(buf, off, len);
        this.ProcessApplicationDataQueue();
        break;
      default:
        throw new TlsFatalAlert((short) 10);
    }
  }

  private void ProcessHandshakeQueue(ByteQueue queue)
  {
    while (queue.Available >= 4)
    {
      int num1 = queue.ReadInt32();
      short num2 = (short) (num1 >>> 24);
      if (!HandshakeType.IsRecognized(num2))
        throw new TlsFatalAlert((short) 10, "Handshake message of unrecognized type: " + num2.ToString());
      int num3 = num1 & 16777215 /*0xFFFFFF*/;
      if (num3 <= this.m_maxHandshakeMessageSize)
      {
        int length = 4 + num3;
        if (queue.Available < length)
          break;
        if (num2 != (short) 0)
        {
          ProtocolVersion serverVersion = this.Context.ServerVersion;
          if (serverVersion == null || !TlsUtilities.IsTlsV13(serverVersion))
            this.CheckReceivedChangeCipherSpec((short) 20 == num2);
        }
        HandshakeMessageInput buf = queue.ReadHandshakeMessage(length);
        if (num2 <= (short) 15)
        {
          switch (num2)
          {
            case 0:
            case 1:
            case 2:
              goto label_15;
            case 3:
              break;
            case 4:
              ProtocolVersion serverVersion1 = this.Context.ServerVersion;
              if (serverVersion1 != null && !TlsUtilities.IsTlsV13(serverVersion1))
              {
                buf.UpdateHash((TlsHash) this.m_handshakeHash);
                goto label_15;
              }
              goto label_15;
            default:
              if (num2 == (short) 15)
                goto label_15;
              break;
          }
        }
        else if (num2 == (short) 20 || num2 == (short) 24)
          goto label_15;
        buf.UpdateHash((TlsHash) this.m_handshakeHash);
label_15:
        buf.Seek(4L, SeekOrigin.Current);
        this.HandleHandshakeMessage(num2, buf);
      }
      else
        throw new TlsFatalAlert((short) 80 /*0x50*/, $"Handshake message length exceeds the maximum: {HandshakeType.GetText(num2)}, {num3.ToString()} > {this.m_maxHandshakeMessageSize.ToString()}");
    }
  }

  private void ProcessApplicationDataQueue()
  {
  }

  private void ProcessAlertQueue()
  {
    while (this.m_alertQueue.Available >= 2)
    {
      byte[] numArray = this.m_alertQueue.RemoveData(2, 0);
      this.HandleAlertMessage((short) numArray[0], (short) numArray[1]);
    }
  }

  private void ProcessChangeCipherSpec(byte[] buf, int off, int len)
  {
    ProtocolVersion serverVersion = this.Context.ServerVersion;
    if (serverVersion == null || TlsUtilities.IsTlsV13(serverVersion))
      throw new TlsFatalAlert((short) 10);
    for (int index = 0; index < len; ++index)
    {
      if (TlsUtilities.ReadUint8(buf, off + index) != (short) 1)
        throw new TlsFatalAlert((short) 50);
      if (this.m_receivedChangeCipherSpec || this.m_alertQueue.Available > 0 || this.m_handshakeQueue.Available > 0)
        throw new TlsFatalAlert((short) 10);
      this.m_recordStream.NotifyChangeCipherSpecReceived();
      this.m_receivedChangeCipherSpec = true;
      this.HandleChangeCipherSpecMessage();
    }
  }

  public virtual int ApplicationDataAvailable => this.m_applicationDataQueue.Available;

  public virtual int ReadApplicationData(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (!this.m_appDataReady)
      throw new InvalidOperationException("Cannot read application data until initial handshake completed.");
    while (this.m_applicationDataQueue.Available < 1)
    {
      if (!this.m_closed)
      {
        this.SafeReadRecord();
      }
      else
      {
        if (this.m_failedWithError)
          throw new IOException("Cannot read application data on failed TLS connection");
        return 0;
      }
    }
    if (count > 0)
    {
      count = Math.Min(count, this.m_applicationDataQueue.Available);
      this.m_applicationDataQueue.RemoveData(buffer, offset, count, 0);
    }
    return count;
  }

  protected virtual RecordPreview SafePreviewRecordHeader(byte[] recordHeader)
  {
    try
    {
      return this.m_recordStream.PreviewRecordHeader(recordHeader);
    }
    catch (TlsFatalAlert ex)
    {
      this.HandleException(ex.AlertDescription, "Failed to read record", (Exception) ex);
      throw;
    }
    catch (IOException ex)
    {
      this.HandleException((short) 80 /*0x50*/, "Failed to read record", (Exception) ex);
      throw;
    }
    catch (Exception ex)
    {
      this.HandleException((short) 80 /*0x50*/, "Failed to read record", ex);
      throw new TlsFatalAlert((short) 80 /*0x50*/, ex);
    }
  }

  protected virtual void SafeReadRecord()
  {
    try
    {
      if (this.m_recordStream.ReadRecord())
        return;
      if (!this.m_appDataReady)
        throw new TlsFatalAlert((short) 40);
      if (!this.Peer.RequiresCloseNotify())
      {
        this.HandleClose(false);
        return;
      }
    }
    catch (TlsFatalAlertReceived ex)
    {
      throw;
    }
    catch (TlsFatalAlert ex)
    {
      this.HandleException(ex.AlertDescription, "Failed to read record", (Exception) ex);
      throw;
    }
    catch (IOException ex)
    {
      this.HandleException((short) 80 /*0x50*/, "Failed to read record", (Exception) ex);
      throw;
    }
    catch (Exception ex)
    {
      this.HandleException((short) 80 /*0x50*/, "Failed to read record", ex);
      throw new TlsFatalAlert((short) 80 /*0x50*/, ex);
    }
    this.HandleFailure();
    throw new TlsNoCloseNotifyException();
  }

  protected virtual bool SafeReadFullRecord(byte[] input, int inputOff, int inputLen)
  {
    try
    {
      return this.m_recordStream.ReadFullRecord(input, inputOff, inputLen);
    }
    catch (TlsFatalAlert ex)
    {
      this.HandleException(ex.AlertDescription, "Failed to process record", (Exception) ex);
      throw;
    }
    catch (IOException ex)
    {
      this.HandleException((short) 80 /*0x50*/, "Failed to process record", (Exception) ex);
      throw;
    }
    catch (Exception ex)
    {
      this.HandleException((short) 80 /*0x50*/, "Failed to process record", ex);
      throw new TlsFatalAlert((short) 80 /*0x50*/, ex);
    }
  }

  protected virtual void SafeWriteRecord(short type, byte[] buf, int offset, int len)
  {
    try
    {
      this.m_recordStream.WriteRecord(type, buf, offset, len);
    }
    catch (TlsFatalAlert ex)
    {
      this.HandleException(ex.AlertDescription, "Failed to write record", (Exception) ex);
      throw;
    }
    catch (IOException ex)
    {
      this.HandleException((short) 80 /*0x50*/, "Failed to write record", (Exception) ex);
      throw;
    }
    catch (Exception ex)
    {
      this.HandleException((short) 80 /*0x50*/, "Failed to write record", ex);
      throw new TlsFatalAlert((short) 80 /*0x50*/, ex);
    }
  }

  public virtual void WriteApplicationData(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (!this.m_appDataReady)
      throw new InvalidOperationException("Cannot write application data until initial handshake completed.");
    int len;
    lock (this.m_recordWriteLock)
    {
      for (; count > 0; count -= len)
      {
        if (this.m_closed)
          throw new IOException("Cannot write application data on closed/failed TLS connection");
        if (this.m_appDataSplitEnabled)
        {
          switch (this.m_appDataSplitMode)
          {
            case 1:
              this.SafeWriteRecord((short) 23, TlsUtilities.EmptyBytes, 0, 0);
              break;
            case 2:
              this.m_appDataSplitEnabled = false;
              this.SafeWriteRecord((short) 23, TlsUtilities.EmptyBytes, 0, 0);
              break;
            default:
              if (count > 1)
              {
                this.SafeWriteRecord((short) 23, buffer, offset, 1);
                ++offset;
                --count;
                break;
              }
              break;
          }
        }
        else if (this.m_keyUpdateEnabled)
        {
          if (this.m_keyUpdatePendingSend)
            this.Send13KeyUpdate(false);
          else if (this.m_recordStream.NeedsKeyUpdate())
            this.Send13KeyUpdate(true);
        }
        len = Math.Min(count, this.m_recordStream.PlaintextLimit);
        this.SafeWriteRecord((short) 23, buffer, offset, len);
        offset += len;
      }
    }
  }

  public virtual int AppDataSplitMode
  {
    get => this.m_appDataSplitMode;
    set
    {
      this.m_appDataSplitMode = value >= 0 && value <= 2 ? value : throw new InvalidOperationException("Illegal appDataSplitMode mode: " + value.ToString());
    }
  }

  public virtual bool IsResumableHandshake
  {
    get => this.m_resumableHandshake;
    set => this.m_resumableHandshake = value;
  }

  internal void WriteHandshakeMessage(byte[] buf, int off, int len)
  {
    if (len < 4)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    switch (TlsUtilities.ReadUint8(buf, off))
    {
      case 0:
      case 1:
      case 24:
        int num = 0;
        do
        {
          int len1 = Math.Min(len - num, this.m_recordStream.PlaintextLimit);
          this.SafeWriteRecord((short) 22, buf, off + num, len1);
          num += len1;
        }
        while (num < len);
        break;
      case 4:
        ProtocolVersion serverVersion = this.Context.ServerVersion;
        if (serverVersion != null && !TlsUtilities.IsTlsV13(serverVersion))
        {
          this.m_handshakeHash.Update(buf, off, len);
          goto case 0;
        }
        goto case 0;
      default:
        this.m_handshakeHash.Update(buf, off, len);
        goto case 0;
    }
  }

  public virtual Stream Stream
  {
    get
    {
      if (!this.m_blocking)
        throw new InvalidOperationException("Cannot use Stream in non-blocking mode! Use OfferInput()/OfferOutput() instead.");
      return (Stream) this.m_tlsStream;
    }
  }

  public virtual void CloseInput()
  {
    if (this.m_blocking)
      throw new InvalidOperationException("Cannot use CloseInput() in blocking mode!");
    if (this.m_closed)
      return;
    if (this.m_inputBuffers.Available > 0)
      throw new EndOfStreamException();
    if (!this.m_appDataReady)
      throw new TlsFatalAlert((short) 40);
    if (this.Peer.RequiresCloseNotify())
    {
      this.HandleFailure();
      throw new TlsNoCloseNotifyException();
    }
    this.HandleClose(false);
  }

  public virtual RecordPreview PreviewInputRecord(byte[] recordHeader)
  {
    if (this.m_blocking)
      throw new InvalidOperationException("Cannot use PreviewInputRecord() in blocking mode!");
    if (this.m_inputBuffers.Available != 0)
      throw new InvalidOperationException("Can only use PreviewInputRecord() for record-aligned input.");
    if (this.m_closed)
      throw new IOException("Connection is closed, cannot accept any more input");
    return this.SafePreviewRecordHeader(recordHeader);
  }

  public virtual int PreviewOutputRecord()
  {
    if (this.m_blocking)
      throw new InvalidOperationException("Cannot use PreviewOutputRecord() in blocking mode!");
    ByteQueue buffer = this.m_outputBuffer.Buffer;
    int available = buffer.Available;
    if (available < 1)
      return 0;
    if (available >= 5)
    {
      int num = 5 + buffer.ReadUint16(3);
      if (available >= num)
        return num;
    }
    throw new InvalidOperationException("Can only use PreviewOutputRecord() for record-aligned output.");
  }

  public virtual RecordPreview PreviewOutputRecord(int applicationDataSize)
  {
    if (!this.m_appDataReady)
      throw new InvalidOperationException("Cannot use PreviewOutputRecord() until initial handshake completed.");
    if (this.m_blocking)
      throw new InvalidOperationException("Cannot use PreviewOutputRecord() in blocking mode!");
    if (this.m_outputBuffer.Buffer.Available != 0)
      throw new InvalidOperationException("Can only use PreviewOutputRecord() for record-aligned output.");
    if (this.m_closed)
      throw new IOException("Connection is closed, cannot produce any more output");
    if (applicationDataSize < 1)
      return new RecordPreview(0, 0);
    if (this.m_appDataSplitEnabled)
    {
      switch (this.m_appDataSplitMode)
      {
        case 1:
        case 2:
          return RecordPreview.CombineAppData(this.m_recordStream.PreviewOutputRecord(0), this.m_recordStream.PreviewOutputRecord(applicationDataSize));
        default:
          RecordPreview a1 = this.m_recordStream.PreviewOutputRecord(1);
          if (applicationDataSize > 1)
          {
            RecordPreview b = this.m_recordStream.PreviewOutputRecord(applicationDataSize - 1);
            a1 = RecordPreview.CombineAppData(a1, b);
          }
          return a1;
      }
    }
    else
    {
      RecordPreview a2 = this.m_recordStream.PreviewOutputRecord(applicationDataSize);
      if (this.m_keyUpdateEnabled && (this.m_keyUpdatePendingSend || this.m_recordStream.NeedsKeyUpdate()))
      {
        int recordSize = this.m_recordStream.PreviewOutputRecordSize(HandshakeMessageOutput.GetLength(1));
        a2 = RecordPreview.ExtendRecordSize(a2, recordSize);
      }
      return a2;
    }
  }

  public virtual void OfferInput(byte[] input) => this.OfferInput(input, 0, input.Length);

  public virtual void OfferInput(byte[] input, int inputOff, int inputLen)
  {
    if (this.m_blocking)
      throw new InvalidOperationException("Cannot use OfferInput() in blocking mode! Use Stream instead.");
    if (this.m_closed)
      throw new IOException("Connection is closed, cannot accept any more input");
    if (this.m_inputBuffers.Available == 0 && this.SafeReadFullRecord(input, inputOff, inputLen))
    {
      if (this.m_closed && !this.m_appDataReady)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
    else
    {
      this.m_inputBuffers.AddBytes(input, inputOff, inputLen);
      while (this.m_inputBuffers.Available >= 5)
      {
        byte[] numArray = new byte[5];
        if (5 != this.m_inputBuffers.Peek(numArray))
          throw new TlsFatalAlert((short) 80 /*0x50*/);
        if (this.m_inputBuffers.Available < this.SafePreviewRecordHeader(numArray).RecordSize)
          break;
        this.SafeReadRecord();
        if (this.m_closed)
        {
          if (this.m_appDataReady)
            break;
          throw new TlsFatalAlert((short) 80 /*0x50*/);
        }
      }
    }
  }

  public virtual int ApplicationDataLimit => this.m_recordStream.PlaintextLimit;

  public virtual int GetAvailableInputBytes()
  {
    if (this.m_blocking)
      throw new InvalidOperationException("Cannot use GetAvailableInputBytes() in blocking mode!");
    return this.ApplicationDataAvailable;
  }

  public virtual int ReadInput(byte[] buf, int off, int len)
  {
    if (this.m_blocking)
      throw new InvalidOperationException("Cannot use ReadInput() in blocking mode! Use Stream instead.");
    len = Math.Min(len, this.ApplicationDataAvailable);
    if (len < 1)
      return 0;
    this.m_applicationDataQueue.RemoveData(buf, off, len, 0);
    return len;
  }

  public virtual int GetAvailableOutputBytes()
  {
    if (this.m_blocking)
      throw new InvalidOperationException("Cannot use GetAvailableOutputBytes() in blocking mode! Use Stream instead.");
    return this.m_outputBuffer.Buffer.Available;
  }

  public virtual int ReadOutput(byte[] buffer, int offset, int length)
  {
    if (this.m_blocking)
      throw new InvalidOperationException("Cannot use ReadOutput() in blocking mode! Use 'Stream() instead.");
    int len = Math.Min(this.GetAvailableOutputBytes(), length);
    this.m_outputBuffer.Buffer.RemoveData(buffer, offset, len, 0);
    return len;
  }

  protected virtual bool EstablishSession(TlsSession sessionToResume)
  {
    this.m_tlsSession = (TlsSession) null;
    this.m_sessionParameters = (SessionParameters) null;
    this.m_sessionMasterSecret = (TlsSecret) null;
    if (sessionToResume == null || !sessionToResume.IsResumable)
      return false;
    SessionParameters sessionParameters = sessionToResume.ExportSessionParameters();
    if (sessionParameters == null)
      return false;
    if (!sessionParameters.IsExtendedMasterSecret)
    {
      TlsPeer peer = this.Peer;
      if (!peer.AllowLegacyResumption() || peer.RequiresExtendedMasterSecret())
        return false;
    }
    TlsSecret sessionMasterSecret = TlsUtilities.GetSessionMasterSecret(this.Context.Crypto, sessionParameters.MasterSecret);
    if (sessionMasterSecret == null)
      return false;
    this.m_tlsSession = sessionToResume;
    this.m_sessionParameters = sessionParameters;
    this.m_sessionMasterSecret = sessionMasterSecret;
    return true;
  }

  protected virtual void InvalidateSession()
  {
    if (this.m_sessionMasterSecret != null)
    {
      this.m_sessionMasterSecret.Destroy();
      this.m_sessionMasterSecret = (TlsSecret) null;
    }
    if (this.m_sessionParameters != null)
    {
      this.m_sessionParameters.Clear();
      this.m_sessionParameters = (SessionParameters) null;
    }
    if (this.m_tlsSession == null)
      return;
    this.m_tlsSession.Invalidate();
    this.m_tlsSession = (TlsSession) null;
  }

  protected virtual void ProcessFinishedMessage(MemoryStream buf)
  {
    TlsContext context = this.Context;
    SecurityParameters securityParameters = context.SecurityParameters;
    bool isServer = context.IsServer;
    byte[] b = TlsUtilities.ReadFully(securityParameters.VerifyDataLength, (Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    byte[] verifyData = TlsUtilities.CalculateVerifyData(context, this.m_handshakeHash, !isServer);
    securityParameters.m_peerVerifyData = Arrays.FixedTimeEquals(verifyData, b) ? verifyData : throw new TlsFatalAlert((short) 51);
    if (securityParameters.IsResumedSession && !securityParameters.IsExtendedMasterSecret || securityParameters.LocalVerifyData != null)
      return;
    securityParameters.m_tlsUnique = verifyData;
  }

  protected virtual void Process13FinishedMessage(MemoryStream buf)
  {
    TlsContext context = this.Context;
    SecurityParameters securityParameters = context.SecurityParameters;
    bool isServer = context.IsServer;
    byte[] b = TlsUtilities.ReadFully(securityParameters.VerifyDataLength, (Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    byte[] verifyData = TlsUtilities.CalculateVerifyData(context, this.m_handshakeHash, !isServer);
    securityParameters.m_peerVerifyData = Arrays.FixedTimeEquals(verifyData, b) ? verifyData : throw new TlsFatalAlert((short) 51);
    securityParameters.m_tlsUnique = (byte[]) null;
  }

  protected virtual void RaiseAlertFatal(short alertDescription, string message, Exception cause)
  {
    this.Peer.NotifyAlertRaised((short) 2, alertDescription, message, cause);
    byte[] plaintext = new byte[2]
    {
      (byte) 2,
      (byte) alertDescription
    };
    try
    {
      this.m_recordStream.WriteRecord((short) 21, plaintext, 0, 2);
    }
    catch (Exception ex)
    {
    }
  }

  protected virtual void RaiseAlertWarning(short alertDescription, string message)
  {
    this.Peer.NotifyAlertRaised((short) 1, alertDescription, message, (Exception) null);
    this.SafeWriteRecord((short) 21, new byte[2]
    {
      (byte) 1,
      (byte) alertDescription
    }, 0, 2);
  }

  protected virtual void Receive13KeyUpdate(MemoryStream buf)
  {
    if (!this.m_appDataReady || !this.m_keyUpdateEnabled)
      throw new TlsFatalAlert((short) 10);
    short keyUpdateRequest = TlsUtilities.ReadUint8((Stream) buf);
    TlsProtocol.AssertEmpty(buf);
    if (!KeyUpdateRequest.IsValid(keyUpdateRequest))
      throw new TlsFatalAlert((short) 47);
    bool flag = (short) 1 == keyUpdateRequest;
    TlsUtilities.Update13TrafficSecretPeer(this.Context);
    this.m_recordStream.NotifyKeyUpdateReceived();
    this.m_keyUpdatePendingSend |= flag;
  }

  protected virtual void SendCertificateMessage(Certificate certificate, Stream endPointHash)
  {
    TlsContext context = this.Context;
    SecurityParameters securityParameters = context.SecurityParameters;
    if (securityParameters.LocalCertificate != null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    if (certificate == null)
      certificate = Certificate.EmptyChain;
    if (certificate.IsEmpty && !context.IsServer && securityParameters.NegotiatedVersion.IsSsl)
    {
      this.RaiseAlertWarning((short) 41, "SSLv3 client didn't provide credentials");
    }
    else
    {
      HandshakeMessageOutput messageOutput = new HandshakeMessageOutput((short) 11);
      certificate.Encode(context, (Stream) messageOutput, endPointHash);
      messageOutput.Send(this);
    }
    securityParameters.m_localCertificate = certificate;
  }

  protected virtual void Send13CertificateMessage(Certificate certificate)
  {
    if (certificate == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsContext context = this.Context;
    SecurityParameters securityParameters = context.SecurityParameters;
    if (securityParameters.LocalCertificate != null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    HandshakeMessageOutput messageOutput = new HandshakeMessageOutput((short) 11);
    certificate.Encode(context, (Stream) messageOutput, (Stream) null);
    messageOutput.Send(this);
    securityParameters.m_localCertificate = certificate;
  }

  protected virtual void Send13CertificateVerifyMessage(DigitallySigned certificateVerify)
  {
    HandshakeMessageOutput output = new HandshakeMessageOutput((short) 15);
    certificateVerify.Encode((Stream) output);
    output.Send(this);
  }

  protected virtual void SendChangeCipherSpec()
  {
    this.SendChangeCipherSpecMessage();
    this.m_recordStream.EnablePendingCipherWrite();
  }

  protected virtual void SendChangeCipherSpecMessage()
  {
    byte[] buf = new byte[1]{ (byte) 1 };
    this.SafeWriteRecord((short) 20, buf, 0, buf.Length);
  }

  protected virtual void SendFinishedMessage()
  {
    TlsContext context = this.Context;
    SecurityParameters securityParameters = context.SecurityParameters;
    byte[] verifyData = TlsUtilities.CalculateVerifyData(context, this.m_handshakeHash, context.IsServer);
    securityParameters.m_localVerifyData = verifyData;
    if ((!securityParameters.IsResumedSession || securityParameters.IsExtendedMasterSecret) && securityParameters.PeerVerifyData == null)
      securityParameters.m_tlsUnique = verifyData;
    HandshakeMessageOutput.Send(this, (short) 20, verifyData);
  }

  protected virtual void Send13FinishedMessage()
  {
    TlsContext context = this.Context;
    SecurityParameters securityParameters = context.SecurityParameters;
    byte[] verifyData = TlsUtilities.CalculateVerifyData(context, this.m_handshakeHash, context.IsServer);
    securityParameters.m_localVerifyData = verifyData;
    securityParameters.m_tlsUnique = (byte[]) null;
    HandshakeMessageOutput.Send(this, (short) 20, verifyData);
  }

  protected virtual void Send13KeyUpdate(bool updateRequested)
  {
    if (!this.m_appDataReady || !this.m_keyUpdateEnabled)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    HandshakeMessageOutput.Send(this, (short) 24, TlsUtilities.EncodeUint8(updateRequested ? (short) 1 : (short) 0));
    TlsUtilities.Update13TrafficSecretLocal(this.Context);
    this.m_recordStream.NotifyKeyUpdateSent();
    this.m_keyUpdatePendingSend &= updateRequested;
  }

  protected virtual void SendSupplementalDataMessage(IList<SupplementalDataEntry> supplementalData)
  {
    HandshakeMessageOutput output = new HandshakeMessageOutput((short) 23);
    TlsProtocol.WriteSupplementalData((Stream) output, supplementalData);
    output.Send(this);
  }

  public virtual void Close() => this.HandleClose(true);

  public virtual void Flush()
  {
  }

  internal bool IsApplicationDataReady => this.m_appDataReady;

  public virtual bool IsClosed => this.m_closed;

  public virtual bool IsConnected
  {
    get
    {
      if (this.m_closed)
        return false;
      AbstractTlsContext contextAdmin = this.ContextAdmin;
      return contextAdmin != null && contextAdmin.IsConnected;
    }
  }

  public virtual bool IsHandshaking
  {
    get
    {
      if (this.m_closed)
        return false;
      AbstractTlsContext contextAdmin = this.ContextAdmin;
      return contextAdmin != null && contextAdmin.IsHandshaking;
    }
  }

  protected virtual short ProcessMaxFragmentLengthExtension(
    IDictionary<int, byte[]> clientExtensions,
    IDictionary<int, byte[]> serverExtensions,
    short alertDescription)
  {
    short fragmentLengthExtension = TlsExtensionsUtilities.GetMaxFragmentLengthExtension(serverExtensions);
    return fragmentLengthExtension < (short) 0 || MaxFragmentLength.IsValid(fragmentLengthExtension) && (clientExtensions == null || (int) fragmentLengthExtension == (int) TlsExtensionsUtilities.GetMaxFragmentLengthExtension(clientExtensions)) ? fragmentLengthExtension : throw new TlsFatalAlert(alertDescription);
  }

  protected virtual void RefuseRenegotiation()
  {
    if (TlsUtilities.IsSsl(this.Context))
      throw new TlsFatalAlert((short) 40);
    this.RaiseAlertWarning((short) 100, "Renegotiation not supported");
  }

  internal static void AssertEmpty(MemoryStream buf)
  {
    if (buf.Position < buf.Length)
      throw new TlsFatalAlert((short) 50);
  }

  internal static byte[] CreateRandomBlock(bool useGmtUnixTime, TlsContext context)
  {
    byte[] nonce = context.NonceGenerator.GenerateNonce(32 /*0x20*/);
    if (useGmtUnixTime)
      TlsUtilities.WriteGmtUnixTime(nonce, 0);
    return nonce;
  }

  internal static byte[] CreateRenegotiationInfo(byte[] renegotiated_connection)
  {
    return TlsUtilities.EncodeOpaque8(renegotiated_connection);
  }

  internal static void EstablishMasterSecret(TlsContext context, TlsKeyExchange keyExchange)
  {
    TlsSecret preMasterSecret = keyExchange.GeneratePreMasterSecret();
    if (preMasterSecret == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    try
    {
      context.SecurityParameters.m_masterSecret = TlsUtilities.CalculateMasterSecret(context, preMasterSecret);
    }
    finally
    {
      preMasterSecret.Destroy();
    }
  }

  internal static IDictionary<int, byte[]> ReadExtensions(MemoryStream input)
  {
    if (input.Position >= input.Length)
      return (IDictionary<int, byte[]>) null;
    byte[] extBytes = TlsUtilities.ReadOpaque16((Stream) input);
    TlsProtocol.AssertEmpty(input);
    return TlsProtocol.ReadExtensionsData(extBytes);
  }

  internal static IDictionary<int, byte[]> ReadExtensionsData(byte[] extBytes)
  {
    Dictionary<int, byte[]> dictionary = new Dictionary<int, byte[]>();
    if (extBytes.Length != 0)
    {
      MemoryStream input = new MemoryStream(extBytes, false);
      int num;
      do
      {
        num = TlsUtilities.ReadUint16((Stream) input);
        byte[] numArray = TlsUtilities.ReadOpaque16((Stream) input);
        if (!dictionary.ContainsKey(num))
          dictionary.Add(num, numArray);
        else
          goto label_4;
      }
      while (input.Position < input.Length);
      goto label_5;
label_4:
      throw new TlsFatalAlert((short) 47, "Repeated extension: " + ExtensionType.GetText(num));
    }
label_5:
    return (IDictionary<int, byte[]>) dictionary;
  }

  internal static IDictionary<int, byte[]> ReadExtensionsData13(int handshakeType, byte[] extBytes)
  {
    Dictionary<int, byte[]> dictionary = new Dictionary<int, byte[]>();
    if (extBytes.Length != 0)
    {
      MemoryStream input = new MemoryStream(extBytes, false);
      int num;
      do
      {
        num = TlsUtilities.ReadUint16((Stream) input);
        if (TlsUtilities.IsPermittedExtensionType13(handshakeType, num))
        {
          byte[] numArray = TlsUtilities.ReadOpaque16((Stream) input);
          if (!dictionary.ContainsKey(num))
            dictionary.Add(num, numArray);
          else
            goto label_6;
        }
        else
          goto label_5;
      }
      while (input.Position < input.Length);
      goto label_7;
label_5:
      throw new TlsFatalAlert((short) 47, "Invalid extension: " + ExtensionType.GetText(num));
label_6:
      throw new TlsFatalAlert((short) 47, "Repeated extension: " + ExtensionType.GetText(num));
    }
label_7:
    return (IDictionary<int, byte[]>) dictionary;
  }

  internal static IDictionary<int, byte[]> ReadExtensionsDataClientHello(byte[] extBytes)
  {
    Dictionary<int, byte[]> dictionary = new Dictionary<int, byte[]>();
    if (extBytes.Length != 0)
    {
      MemoryStream input = new MemoryStream(extBytes, false);
      bool flag = false;
      int num;
      do
      {
        num = TlsUtilities.ReadUint16((Stream) input);
        byte[] numArray = TlsUtilities.ReadOpaque16((Stream) input);
        if (!dictionary.ContainsKey(num))
        {
          dictionary.Add(num, numArray);
          flag |= 41 == num;
        }
        else
          goto label_4;
      }
      while (input.Position < input.Length);
      goto label_5;
label_4:
      throw new TlsFatalAlert((short) 47, "Repeated extension: " + ExtensionType.GetText(num));
label_5:
      if (flag && 41 != num)
        throw new TlsFatalAlert((short) 47, "'pre_shared_key' MUST be last in ClientHello");
    }
    return (IDictionary<int, byte[]>) dictionary;
  }

  internal static IList<SupplementalDataEntry> ReadSupplementalDataMessage(MemoryStream input)
  {
    byte[] buffer = TlsUtilities.ReadOpaque24((Stream) input, 1);
    TlsProtocol.AssertEmpty(input);
    MemoryStream input1 = new MemoryStream(buffer, false);
    List<SupplementalDataEntry> supplementalDataEntryList = new List<SupplementalDataEntry>();
    while (input1.Position < input1.Length)
    {
      int dataType = TlsUtilities.ReadUint16((Stream) input1);
      byte[] data = TlsUtilities.ReadOpaque16((Stream) input1);
      supplementalDataEntryList.Add(new SupplementalDataEntry(dataType, data));
    }
    return (IList<SupplementalDataEntry>) supplementalDataEntryList;
  }

  internal static void WriteExtensions(Stream output, IDictionary<int, byte[]> extensions)
  {
    TlsProtocol.WriteExtensions(output, extensions, 0);
  }

  internal static void WriteExtensions(
    Stream output,
    IDictionary<int, byte[]> extensions,
    int bindersSize)
  {
    if (extensions == null || extensions.Count < 1)
      return;
    byte[] buffer = TlsProtocol.WriteExtensionsData(extensions, bindersSize);
    int i = buffer.Length + bindersSize;
    TlsUtilities.CheckUint16(i);
    TlsUtilities.WriteUint16(i, output);
    output.Write(buffer, 0, buffer.Length);
  }

  internal static byte[] WriteExtensionsData(IDictionary<int, byte[]> extensions)
  {
    return TlsProtocol.WriteExtensionsData(extensions, 0);
  }

  internal static byte[] WriteExtensionsData(IDictionary<int, byte[]> extensions, int bindersSize)
  {
    MemoryStream buf = new MemoryStream();
    TlsProtocol.WriteExtensionsData(extensions, buf, bindersSize);
    return buf.ToArray();
  }

  internal static void WriteExtensionsData(IDictionary<int, byte[]> extensions, MemoryStream buf)
  {
    TlsProtocol.WriteExtensionsData(extensions, buf, 0);
  }

  internal static void WriteExtensionsData(
    IDictionary<int, byte[]> extensions,
    MemoryStream buf,
    int bindersSize)
  {
    TlsProtocol.WriteSelectedExtensions((Stream) buf, extensions, true);
    TlsProtocol.WriteSelectedExtensions((Stream) buf, extensions, false);
    TlsProtocol.WritePreSharedKeyExtension(buf, extensions, bindersSize);
  }

  internal static void WritePreSharedKeyExtension(
    MemoryStream buf,
    IDictionary<int, byte[]> extensions,
    int bindersSize)
  {
    byte[] buffer;
    if (!extensions.TryGetValue(41, out buffer))
      return;
    TlsUtilities.CheckUint16(41);
    TlsUtilities.WriteUint16(41, (Stream) buf);
    int i = buffer.Length + bindersSize;
    TlsUtilities.CheckUint16(i);
    TlsUtilities.WriteUint16(i, (Stream) buf);
    buf.Write(buffer, 0, buffer.Length);
  }

  internal static void WriteSelectedExtensions(
    Stream output,
    IDictionary<int, byte[]> extensions,
    bool selectEmpty)
  {
    foreach (KeyValuePair<int, byte[]> extension in (IEnumerable<KeyValuePair<int, byte[]>>) extensions)
    {
      int key = extension.Key;
      if (41 != key)
      {
        byte[] buf = extension.Value;
        if (selectEmpty == (buf.Length == 0))
        {
          TlsUtilities.CheckUint16(key);
          TlsUtilities.WriteUint16(key, output);
          TlsUtilities.WriteOpaque16(buf, output);
        }
      }
    }
  }

  internal static void WriteSupplementalData(
    Stream output,
    IList<SupplementalDataEntry> supplementalData)
  {
    MemoryStream output1 = new MemoryStream();
    foreach (SupplementalDataEntry supplementalDataEntry in (IEnumerable<SupplementalDataEntry>) supplementalData)
    {
      int dataType = supplementalDataEntry.DataType;
      TlsUtilities.CheckUint16(dataType);
      TlsUtilities.WriteUint16(dataType, (Stream) output1);
      TlsUtilities.WriteOpaque16(supplementalDataEntry.Data, (Stream) output1);
    }
    TlsUtilities.WriteOpaque24(output1.ToArray(), output);
  }
}
