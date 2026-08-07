// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsRecordLayer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Date;
using System;
using System.IO;
using System.Net.Sockets;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal class DtlsRecordLayer : DatagramTransport, DatagramReceiver, DatagramSender, TlsCloseable
{
  private const int RECORD_HEADER_LENGTH = 13;
  private const int MAX_FRAGMENT_LENGTH = 16384 /*0x4000*/;
  private const long TCP_MSL = 120000;
  private const long RETRANSMIT_TIMEOUT = 240000;
  private readonly TlsContext m_context;
  private readonly TlsPeer m_peer;
  private readonly DatagramTransport m_transport;
  private readonly ByteQueue m_recordQueue = new ByteQueue();
  private readonly object m_writeLock = new object();
  private volatile bool m_closed;
  private volatile bool m_failed;
  private volatile ProtocolVersion m_readVersion;
  private volatile ProtocolVersion m_writeVersion;
  private volatile bool m_inConnection;
  private volatile bool m_inHandshake;
  private volatile int m_plaintextLimit;
  private DtlsEpoch m_currentEpoch;
  private DtlsEpoch m_pendingEpoch;
  private DtlsEpoch m_readEpoch;
  private DtlsEpoch m_writeEpoch;
  private DtlsHandshakeRetransmit m_retransmit;
  private DtlsEpoch m_retransmitEpoch;
  private Timeout m_retransmitTimeout;
  private TlsHeartbeat m_heartbeat;
  private bool m_heartBeatResponder;
  private HeartbeatMessage m_heartbeatInFlight;
  private Timeout m_heartbeatTimeout;
  private int m_heartbeatResendMillis = -1;
  private Timeout m_heartbeatResendTimeout;

  internal static byte[] ReceiveClientHelloRecord(byte[] data, int dataOff, int dataLen)
  {
    if (dataLen < 13)
      return (byte[]) null;
    if ((short) 22 != TlsUtilities.ReadUint8(data, dataOff))
      return (byte[]) null;
    ProtocolVersion version = TlsUtilities.ReadVersion(data, dataOff + 1);
    if (!ProtocolVersion.DTLSv10.IsEqualOrEarlierVersionOf(version))
      return (byte[]) null;
    if (TlsUtilities.ReadUint16(data, dataOff + 3) != 0)
      return (byte[]) null;
    int num = TlsUtilities.ReadUint16(data, dataOff + 11);
    if (dataLen < 13 + num)
      return (byte[]) null;
    return num > 16384 /*0x4000*/ ? (byte[]) null : TlsUtilities.CopyOfRangeExact(data, dataOff + 13, dataOff + 13 + num);
  }

  internal static void SendHelloVerifyRequestRecord(
    DatagramSender sender,
    long recordSeq,
    byte[] message)
  {
    TlsUtilities.CheckUint16(message.Length);
    byte[] numArray = new byte[13 + message.Length];
    TlsUtilities.WriteUint8((short) 22, numArray, 0);
    TlsUtilities.WriteVersion(ProtocolVersion.DTLSv10, numArray, 1);
    TlsUtilities.WriteUint16(0, numArray, 3);
    TlsUtilities.WriteUint48(recordSeq, numArray, 5);
    TlsUtilities.WriteUint16(message.Length, numArray, 11);
    Array.Copy((Array) message, 0, (Array) numArray, 13, message.Length);
    DtlsRecordLayer.SendDatagram(sender, numArray, 0, numArray.Length);
  }

  private static void SendDatagram(DatagramSender sender, byte[] buf, int off, int len)
  {
    sender.Send(buf, off, len);
  }

  internal DtlsRecordLayer(TlsContext context, TlsPeer peer, DatagramTransport transport)
  {
    this.m_context = context;
    this.m_peer = peer;
    this.m_transport = transport;
    this.m_inHandshake = true;
    this.m_currentEpoch = new DtlsEpoch(0, (TlsCipher) TlsNullNullCipher.Instance, 13, 13);
    this.m_pendingEpoch = (DtlsEpoch) null;
    this.m_readEpoch = this.m_currentEpoch;
    this.m_writeEpoch = this.m_currentEpoch;
    this.SetPlaintextLimit(16384 /*0x4000*/);
  }

  internal virtual bool IsClosed => this.m_closed;

  internal virtual void ResetAfterHelloVerifyRequestServer(long recordSeq)
  {
    this.m_inConnection = true;
    this.m_currentEpoch.SequenceNumber = recordSeq;
    this.m_currentEpoch.ReplayWindow.Reset(recordSeq);
  }

  internal virtual void SetPlaintextLimit(int plaintextLimit)
  {
    this.m_plaintextLimit = plaintextLimit;
  }

  internal virtual int ReadEpoch => this.m_readEpoch.Epoch;

  internal virtual ProtocolVersion ReadVersion
  {
    get => this.m_readVersion;
    set => this.m_readVersion = value;
  }

  internal virtual void SetWriteVersion(ProtocolVersion writeVersion)
  {
    this.m_writeVersion = writeVersion;
  }

  internal virtual void InitPendingEpoch(TlsCipher pendingCipher)
  {
    if (this.m_pendingEpoch != null)
      throw new InvalidOperationException();
    SecurityParameters securityParameters = this.m_context.SecurityParameters;
    byte[] connectionIdPeer = securityParameters.ConnectionIDPeer;
    int recordHeaderLengthRead = 13 + (connectionIdPeer != null ? connectionIdPeer.Length : 0);
    byte[] connectionIdLocal = securityParameters.ConnectionIDLocal;
    int recordHeaderLengthWrite = 13 + (connectionIdLocal != null ? connectionIdLocal.Length : 0);
    this.m_pendingEpoch = new DtlsEpoch(this.m_writeEpoch.Epoch + 1, pendingCipher, recordHeaderLengthRead, recordHeaderLengthWrite);
  }

  internal virtual void HandshakeSuccessful(DtlsHandshakeRetransmit retransmit)
  {
    if (this.m_readEpoch == this.m_currentEpoch || this.m_writeEpoch == this.m_currentEpoch)
      throw new InvalidOperationException();
    if (retransmit != null)
    {
      this.m_retransmit = retransmit;
      this.m_retransmitEpoch = this.m_currentEpoch;
      this.m_retransmitTimeout = new Timeout(240000L);
    }
    this.m_inHandshake = false;
    this.m_currentEpoch = this.m_pendingEpoch;
    this.m_pendingEpoch = (DtlsEpoch) null;
  }

  internal virtual void InitHeartbeat(TlsHeartbeat heartbeat, bool heartbeatResponder)
  {
    if (this.m_inHandshake)
      throw new InvalidOperationException();
    this.m_heartbeat = heartbeat;
    this.m_heartBeatResponder = heartbeatResponder;
    if (heartbeat == null)
      return;
    this.ResetHeartbeat();
  }

  internal virtual void ResetWriteEpoch()
  {
    if (this.m_retransmitEpoch != null)
      this.m_writeEpoch = this.m_retransmitEpoch;
    else
      this.m_writeEpoch = this.m_currentEpoch;
  }

  public virtual int GetReceiveLimit()
  {
    int ciphertextLimit = this.m_transport.GetReceiveLimit() - this.m_readEpoch.RecordHeaderLengthRead;
    TlsCipher cipher = this.m_readEpoch.Cipher;
    return Math.Min(this.m_plaintextLimit, !(cipher is TlsCipherExt tlsCipherExt) ? cipher.GetPlaintextLimit(ciphertextLimit) : tlsCipherExt.GetPlaintextDecodeLimit(ciphertextLimit));
  }

  public virtual int GetSendLimit()
  {
    TlsCipher cipher = this.m_writeEpoch.Cipher;
    int ciphertextLimit = this.m_transport.GetSendLimit() - this.m_writeEpoch.RecordHeaderLengthWrite;
    return Math.Min(this.m_plaintextLimit, !(cipher is TlsCipherExt tlsCipherExt) ? cipher.GetPlaintextLimit(ciphertextLimit) : tlsCipherExt.GetPlaintextEncodeLimit(ciphertextLimit));
  }

  public virtual int Receive(byte[] buf, int off, int len, int waitMillis)
  {
    return this.Receive(buf, off, len, waitMillis, (DtlsRecordCallback) null);
  }

  internal int Receive(
    byte[] buf,
    int off,
    int len,
    int waitMillis,
    DtlsRecordCallback recordCallback)
  {
    long currentTimeMillis = DateTimeUtilities.CurrentUnixMs();
    Timeout timeout = Timeout.ForWaitMillis(waitMillis, currentTimeMillis);
    byte[] numArray = (byte[]) null;
    for (; waitMillis >= 0; waitMillis = Timeout.GetWaitMillis(timeout, currentTimeMillis))
    {
      if (this.m_retransmitTimeout != null && this.m_retransmitTimeout.RemainingMillis(currentTimeMillis) < 1L)
      {
        this.m_retransmit = (DtlsHandshakeRetransmit) null;
        this.m_retransmitEpoch = (DtlsEpoch) null;
        this.m_retransmitTimeout = (Timeout) null;
      }
      if (Timeout.HasExpired(this.m_heartbeatTimeout, currentTimeMillis))
      {
        this.m_heartbeatInFlight = this.m_heartbeatInFlight == null ? HeartbeatMessage.Create(this.m_context, (short) 1, this.m_heartbeat.GeneratePayload()) : throw new TlsTimeoutException("Heartbeat timed out");
        this.m_heartbeatTimeout = new Timeout((long) this.m_heartbeat.TimeoutMillis, currentTimeMillis);
        this.m_heartbeatResendMillis = TlsUtilities.GetHandshakeResendTimeMillis(this.m_peer);
        this.m_heartbeatResendTimeout = new Timeout((long) this.m_heartbeatResendMillis, currentTimeMillis);
        this.SendHeartbeatMessage(this.m_heartbeatInFlight);
      }
      else if (Timeout.HasExpired(this.m_heartbeatResendTimeout, currentTimeMillis))
      {
        this.m_heartbeatResendMillis = DtlsReliableHandshake.BackOff(this.m_heartbeatResendMillis);
        this.m_heartbeatResendTimeout = new Timeout((long) this.m_heartbeatResendMillis, currentTimeMillis);
        this.SendHeartbeatMessage(this.m_heartbeatInFlight);
      }
      waitMillis = Timeout.ConstrainWaitMillis(waitMillis, this.m_heartbeatTimeout, currentTimeMillis);
      waitMillis = Timeout.ConstrainWaitMillis(waitMillis, this.m_heartbeatResendTimeout, currentTimeMillis);
      if (waitMillis < 0)
        waitMillis = 1;
      int receiveLimit = this.m_transport.GetReceiveLimit();
      if (numArray == null || numArray.Length < receiveLimit)
        numArray = new byte[receiveLimit];
      int num = this.ProcessRecord(this.ReceiveRecord(numArray, 0, receiveLimit, waitMillis), numArray, buf, off, len, recordCallback);
      if (num >= 0)
        return num;
      currentTimeMillis = DateTimeUtilities.CurrentUnixMs();
    }
    return -1;
  }

  internal int ReceivePending(byte[] buf, int off, int len, DtlsRecordCallback recordCallback)
  {
    if (this.m_recordQueue.Available > 0)
    {
      int available = this.m_recordQueue.Available;
      byte[] numArray = new byte[available];
      int pending;
      do
      {
        pending = this.ProcessRecord(this.ReceivePendingRecord(numArray, 0, available), numArray, buf, off, len, recordCallback);
        if (pending >= 0)
          goto label_4;
      }
      while (this.m_recordQueue.Available > 0);
      goto label_5;
label_4:
      return pending;
    }
label_5:
    return -1;
  }

  public virtual void Send(byte[] buf, int off, int len)
  {
    short contentType = 23;
    if (this.m_inHandshake || this.m_writeEpoch == this.m_retransmitEpoch)
    {
      contentType = (short) 22;
      if (TlsUtilities.ReadUint8(buf, off) == (short) 20)
      {
        DtlsEpoch dtlsEpoch = (DtlsEpoch) null;
        if (this.m_inHandshake)
          dtlsEpoch = this.m_pendingEpoch;
        else if (this.m_writeEpoch == this.m_retransmitEpoch)
          dtlsEpoch = this.m_currentEpoch;
        if (dtlsEpoch == null)
          throw new InvalidOperationException();
        byte[] buf1 = new byte[1]{ (byte) 1 };
        this.SendRecord((short) 20, buf1, 0, buf1.Length);
        this.m_writeEpoch = dtlsEpoch;
      }
    }
    this.SendRecord(contentType, buf, off, len);
  }

  public virtual void Close()
  {
    if (this.m_closed)
      return;
    if (this.m_inHandshake && this.m_inConnection)
      this.Warn((short) 90, "User canceled handshake");
    this.CloseTransport();
  }

  internal virtual void Fail(short alertDescription)
  {
    if (this.m_closed)
      return;
    if (this.m_inConnection)
    {
      try
      {
        this.RaiseAlert((short) 2, alertDescription, (string) null, (Exception) null);
      }
      catch (Exception ex)
      {
      }
    }
    this.m_failed = true;
    this.CloseTransport();
  }

  internal virtual void Failed()
  {
    if (this.m_closed)
      return;
    this.m_failed = true;
    this.CloseTransport();
  }

  internal virtual void Warn(short alertDescription, string message)
  {
    this.RaiseAlert((short) 1, alertDescription, message, (Exception) null);
  }

  private void CloseTransport()
  {
    if (this.m_closed)
      return;
    try
    {
      if (!this.m_failed)
        this.Warn((short) 0, (string) null);
      this.m_transport.Close();
    }
    catch (Exception ex)
    {
    }
    this.m_closed = true;
  }

  private void RaiseAlert(
    short alertLevel,
    short alertDescription,
    string message,
    Exception cause)
  {
    this.m_peer.NotifyAlertRaised(alertLevel, alertDescription, message, cause);
    this.SendRecord((short) 21, new byte[2]
    {
      (byte) alertLevel,
      (byte) alertDescription
    }, 0, 2);
  }

  private int ReceiveDatagram(byte[] buf, int off, int len, int waitMillis)
  {
    try
    {
      return this.m_transport.Receive(buf, off, len, waitMillis);
    }
    catch (TlsTimeoutException ex)
    {
      return -1;
    }
    catch (SocketException ex)
    {
      if (TlsUtilities.IsTimeout(ex))
        return -1;
      throw;
    }
  }

  private int ProcessRecord(
    int received,
    byte[] record,
    byte[] buf,
    int off,
    int len,
    DtlsRecordCallback recordCallback)
  {
    if (received < 13)
      return -1;
    short recordType = TlsUtilities.ReadUint8(record, 0);
    switch (recordType)
    {
      case 20:
      case 21:
      case 22:
      case 23:
      case 24:
      case 25:
        ProtocolVersion protocolVersion = TlsUtilities.ReadVersion(record, 1);
        if (!protocolVersion.IsDtls)
          return -1;
        int epoch = TlsUtilities.ReadUint16(record, 3);
        DtlsEpoch dtlsEpoch = (DtlsEpoch) null;
        if (epoch == this.m_readEpoch.Epoch)
          dtlsEpoch = this.m_readEpoch;
        else if (recordType == (short) 22 && this.m_retransmitEpoch != null && epoch == this.m_retransmitEpoch.Epoch)
          dtlsEpoch = this.m_retransmitEpoch;
        if (dtlsEpoch == null)
          return -1;
        long num = TlsUtilities.ReadUint48(record, 5);
        if (dtlsEpoch.ReplayWindow.ShouldDiscard(num))
          return -1;
        int headerLengthRead = dtlsEpoch.RecordHeaderLengthRead;
        if (headerLengthRead > 13)
        {
          if ((short) 25 != recordType || received < headerLengthRead)
            return -1;
          byte[] connectionIdPeer = this.m_context.SecurityParameters.ConnectionIDPeer;
          if (!Arrays.FixedTimeEquals(connectionIdPeer.Length, connectionIdPeer, 0, record, 11))
            return -1;
        }
        else if ((short) 25 == recordType)
          return -1;
        int len1 = TlsUtilities.ReadUint16(record, headerLengthRead - 2);
        if (received != len1 + headerLengthRead || this.m_readVersion != null && !this.m_readVersion.Equals(protocolVersion) && (this.ReadEpoch != 0 || len1 <= 0 || (short) 22 != recordType ? 0 : ((short) 1 == TlsUtilities.ReadUint8(record, headerLengthRead) ? 1 : 0)) == 0)
          return -1;
        long macSequenceNumber = DtlsRecordLayer.GetMacSequenceNumber(dtlsEpoch.Epoch, num);
        TlsDecodeResult tlsDecodeResult;
        try
        {
          tlsDecodeResult = dtlsEpoch.Cipher.DecodeCiphertext(macSequenceNumber, recordType, protocolVersion, record, headerLengthRead, len1);
        }
        catch (TlsFatalAlert ex) when ((short) 20 == ex.AlertDescription)
        {
          return -1;
        }
        if (tlsDecodeResult.len > this.m_plaintextLimit || tlsDecodeResult.len < 1 && tlsDecodeResult.contentType != (short) 23)
          return -1;
        if (this.m_readVersion == null)
        {
          if ((this.ReadEpoch != 0 || len1 <= 0 || (short) 22 != recordType ? 0 : ((short) 3 == TlsUtilities.ReadUint8(record, headerLengthRead) ? 1 : 0)) != 0)
          {
            if (!ProtocolVersion.DTLSv12.IsEqualOrLaterVersionOf(protocolVersion))
              return -1;
          }
          else
            this.m_readVersion = protocolVersion;
        }
        bool isLatestConfirmed;
        dtlsEpoch.ReplayWindow.ReportAuthenticated(num, out isLatestConfirmed);
        if (recordCallback != null)
        {
          DtlsRecordFlags flags = DtlsRecordFlags.None;
          if (dtlsEpoch == this.m_readEpoch & isLatestConfirmed)
            flags |= DtlsRecordFlags.IsNewest;
          if ((short) 25 == recordType)
            flags |= DtlsRecordFlags.UsesConnectionID;
          recordCallback(flags);
        }
        switch (tlsDecodeResult.contentType)
        {
          case 20:
            for (int index = 0; index < tlsDecodeResult.len; ++index)
            {
              if (TlsUtilities.ReadUint8(tlsDecodeResult.buf, tlsDecodeResult.off + index) == (short) 1 && this.m_pendingEpoch != null)
                this.m_readEpoch = this.m_pendingEpoch;
            }
            return -1;
          case 21:
            if (tlsDecodeResult.len == 2)
            {
              short alertLevel = TlsUtilities.ReadUint8(tlsDecodeResult.buf, tlsDecodeResult.off);
              short alertDescription = TlsUtilities.ReadUint8(tlsDecodeResult.buf, tlsDecodeResult.off + 1);
              this.m_peer.NotifyAlertReceived(alertLevel, alertDescription);
              if (alertLevel == (short) 2)
              {
                this.Failed();
                throw new TlsFatalAlert(alertDescription);
              }
              if (alertDescription == (short) 0)
                this.CloseTransport();
            }
            return -1;
          case 22:
            if (!this.m_inHandshake)
            {
              if (this.m_retransmit != null)
                this.m_retransmit.ReceivedHandshakeRecord(epoch, tlsDecodeResult.buf, tlsDecodeResult.off, tlsDecodeResult.len);
              return -1;
            }
            break;
          case 23:
            if (this.m_inHandshake)
              return -1;
            break;
          case 24:
            if (this.m_heartbeatInFlight != null || this.m_heartBeatResponder)
            {
              try
              {
                HeartbeatMessage heartbeatMessage = HeartbeatMessage.Parse((Stream) new MemoryStream(tlsDecodeResult.buf, tlsDecodeResult.off, tlsDecodeResult.len, false));
                if (heartbeatMessage != null)
                {
                  switch (heartbeatMessage.Type)
                  {
                    case 1:
                      if (this.m_heartBeatResponder)
                      {
                        this.SendHeartbeatMessage(HeartbeatMessage.Create(this.m_context, (short) 2, heartbeatMessage.Payload));
                        break;
                      }
                      break;
                    case 2:
                      if (this.m_heartbeatInFlight != null)
                      {
                        if (Arrays.AreEqual(heartbeatMessage.Payload, this.m_heartbeatInFlight.Payload))
                        {
                          this.ResetHeartbeat();
                          break;
                        }
                        break;
                      }
                      break;
                  }
                }
              }
              catch (Exception ex)
              {
              }
            }
            return -1;
          default:
            return -1;
        }
        if (!this.m_inHandshake && this.m_retransmit != null)
        {
          this.m_retransmit = (DtlsHandshakeRetransmit) null;
          this.m_retransmitEpoch = (DtlsEpoch) null;
          this.m_retransmitTimeout = (Timeout) null;
        }
        if (tlsDecodeResult.len > len)
          throw new TlsFatalAlert((short) 80 /*0x50*/);
        Array.Copy((Array) tlsDecodeResult.buf, tlsDecodeResult.off, (Array) buf, off, tlsDecodeResult.len);
        return tlsDecodeResult.len;
      default:
        return -1;
    }
  }

  private int ReceivePendingRecord(byte[] buf, int off, int len)
  {
    int val2 = 13;
    if (this.m_recordQueue.Available >= 13)
    {
      short num1 = this.m_recordQueue.ReadUint8(0);
      int num2 = this.m_recordQueue.ReadUint16(3);
      DtlsEpoch dtlsEpoch = (DtlsEpoch) null;
      if (num2 == this.m_readEpoch.Epoch)
        dtlsEpoch = this.m_readEpoch;
      else if (num1 == (short) 22 && this.m_retransmitEpoch != null && num2 == this.m_retransmitEpoch.Epoch)
        dtlsEpoch = this.m_retransmitEpoch;
      if (dtlsEpoch == null)
      {
        this.m_recordQueue.RemoveData(this.m_recordQueue.Available);
        return -1;
      }
      val2 = dtlsEpoch.RecordHeaderLengthRead;
      if (this.m_recordQueue.Available >= val2)
      {
        int num3 = this.m_recordQueue.ReadUint16(val2 - 2);
        val2 += num3;
      }
    }
    int len1 = Math.Min(this.m_recordQueue.Available, val2);
    this.m_recordQueue.RemoveData(buf, off, len1, 0);
    return len1;
  }

  private int ReceiveRecord(byte[] buf, int off, int len, int waitMillis)
  {
    if (this.m_recordQueue.Available > 0)
      return this.ReceivePendingRecord(buf, off, len);
    int record = this.ReceiveDatagram(buf, off, len, waitMillis);
    if (record >= 13)
    {
      this.m_inConnection = true;
      short num1 = TlsUtilities.ReadUint8(buf, off);
      int num2 = TlsUtilities.ReadUint16(buf, off + 3);
      DtlsEpoch dtlsEpoch = (DtlsEpoch) null;
      if (num2 == this.m_readEpoch.Epoch)
        dtlsEpoch = this.m_readEpoch;
      else if (num1 == (short) 22 && this.m_retransmitEpoch != null && num2 == this.m_retransmitEpoch.Epoch)
        dtlsEpoch = this.m_retransmitEpoch;
      if (dtlsEpoch == null)
        return -1;
      int headerLengthRead = dtlsEpoch.RecordHeaderLengthRead;
      if (record >= headerLengthRead)
      {
        int num3 = TlsUtilities.ReadUint16(buf, off + headerLengthRead - 2);
        int num4 = headerLengthRead + num3;
        if (record > num4)
        {
          this.m_recordQueue.AddData(buf, off + num4, record - num4);
          record = num4;
        }
      }
    }
    return record;
  }

  private void ResetHeartbeat()
  {
    this.m_heartbeatInFlight = (HeartbeatMessage) null;
    this.m_heartbeatResendMillis = -1;
    this.m_heartbeatResendTimeout = (Timeout) null;
    this.m_heartbeatTimeout = new Timeout((long) this.m_heartbeat.IdleMillis);
  }

  private void SendHeartbeatMessage(HeartbeatMessage heartbeatMessage)
  {
    MemoryStream output = new MemoryStream();
    heartbeatMessage.Encode((Stream) output);
    byte[] array = output.ToArray();
    this.SendRecord((short) 24, array, 0, array.Length);
  }

  private void SendRecord(short contentType, byte[] buf, int off, int len)
  {
    if (this.m_writeVersion == null)
      return;
    if (len > this.m_plaintextLimit)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    if (len < 1 && contentType != (short) 23)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    lock (this.m_writeLock)
    {
      int epoch = this.m_writeEpoch.Epoch;
      long num = this.m_writeEpoch.AllocateSequenceNumber();
      long macSequenceNumber = DtlsRecordLayer.GetMacSequenceNumber(epoch, num);
      ProtocolVersion writeVersion = this.m_writeVersion;
      int headerLengthWrite = this.m_writeEpoch.RecordHeaderLengthWrite;
      TlsEncodeResult tlsEncodeResult = this.m_writeEpoch.Cipher.EncodePlaintext(macSequenceNumber, contentType, writeVersion, headerLengthWrite, buf, off, len);
      int i = tlsEncodeResult.len - headerLengthWrite;
      TlsUtilities.CheckUint16(i);
      TlsUtilities.WriteUint8(tlsEncodeResult.recordType, tlsEncodeResult.buf, tlsEncodeResult.off);
      TlsUtilities.WriteVersion(writeVersion, tlsEncodeResult.buf, tlsEncodeResult.off + 1);
      TlsUtilities.WriteUint16(epoch, tlsEncodeResult.buf, tlsEncodeResult.off + 3);
      TlsUtilities.WriteUint48(num, tlsEncodeResult.buf, tlsEncodeResult.off + 5);
      if (headerLengthWrite > 13)
      {
        byte[] connectionIdLocal = this.m_context.SecurityParameters.ConnectionIDLocal;
        Array.Copy((Array) connectionIdLocal, 0, (Array) tlsEncodeResult.buf, tlsEncodeResult.off + 11, connectionIdLocal.Length);
      }
      TlsUtilities.WriteUint16(i, tlsEncodeResult.buf, tlsEncodeResult.off + (headerLengthWrite - 2));
      DtlsRecordLayer.SendDatagram((DatagramSender) this.m_transport, tlsEncodeResult.buf, tlsEncodeResult.off, tlsEncodeResult.len);
    }
  }

  private static long GetMacSequenceNumber(int epoch, long sequence_number)
  {
    return ((long) epoch & (long) uint.MaxValue) << 48 /*0x30*/ | sequence_number;
  }
}
