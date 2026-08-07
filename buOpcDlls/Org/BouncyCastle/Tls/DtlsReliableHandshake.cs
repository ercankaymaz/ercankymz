// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsReliableHandshake
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Date;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal class DtlsReliableHandshake
{
  private const int MAX_RECEIVE_AHEAD = 16 /*0x10*/;
  private const int MESSAGE_HEADER_LENGTH = 12;
  private const int MAX_RESEND_MILLIS = 60000;
  private DtlsRecordLayer m_recordLayer;
  private Timeout m_handshakeTimeout;
  private TlsHandshakeHash m_handshakeHash;
  private IDictionary<int, DtlsReassembler> m_currentInboundFlight = (IDictionary<int, DtlsReassembler>) new Dictionary<int, DtlsReassembler>();
  private IDictionary<int, DtlsReassembler> m_previousInboundFlight;
  private IList<DtlsReliableHandshake.Message> m_outboundFlight = (IList<DtlsReliableHandshake.Message>) new List<DtlsReliableHandshake.Message>();
  private readonly int m_initialResendMillis;
  private int m_resendMillis = -1;
  private Timeout m_resendTimeout;
  private int m_next_send_seq;
  private int m_next_receive_seq;

  internal static DtlsRequest ReadClientRequest(
    byte[] data,
    int dataOff,
    int dataLen,
    Stream dtlsOutput)
  {
    byte[] clientHelloRecord = DtlsRecordLayer.ReceiveClientHelloRecord(data, dataOff, dataLen);
    if (clientHelloRecord == null || clientHelloRecord.Length < 12)
      return (DtlsRequest) null;
    long recordSeq = TlsUtilities.ReadUint48(data, dataOff + 5);
    if ((short) 1 != TlsUtilities.ReadUint8(clientHelloRecord, 0))
      return (DtlsRequest) null;
    int count = TlsUtilities.ReadUint24(clientHelloRecord, 1);
    if (clientHelloRecord.Length != 12 + count)
      return (DtlsRequest) null;
    if (TlsUtilities.ReadUint24(clientHelloRecord, 6) != 0)
      return (DtlsRequest) null;
    int num = TlsUtilities.ReadUint24(clientHelloRecord, 9);
    if (count != num)
      return (DtlsRequest) null;
    ClientHello clientHello = ClientHello.Parse(new MemoryStream(clientHelloRecord, 12, count, false), dtlsOutput);
    return new DtlsRequest(recordSeq, clientHelloRecord, clientHello);
  }

  internal static void SendHelloVerifyRequest(DatagramSender sender, long recordSeq, byte[] cookie)
  {
    TlsUtilities.CheckUint8(cookie.Length);
    int i = 3 + cookie.Length;
    byte[] numArray = new byte[12 + i];
    TlsUtilities.WriteUint8((short) 3, numArray, 0);
    TlsUtilities.WriteUint24(i, numArray, 1);
    TlsUtilities.WriteUint24(i, numArray, 9);
    TlsUtilities.WriteVersion(ProtocolVersion.DTLSv10, numArray, 12);
    TlsUtilities.WriteOpaque8(cookie, numArray, 14);
    DtlsRecordLayer.SendHelloVerifyRequestRecord(sender, recordSeq, numArray);
  }

  internal DtlsReliableHandshake(
    TlsContext context,
    DtlsRecordLayer transport,
    int timeoutMillis,
    int initialResendMillis,
    DtlsRequest request)
  {
    this.m_recordLayer = transport;
    this.m_handshakeHash = (TlsHandshakeHash) new DeferredHash(context);
    this.m_handshakeTimeout = Timeout.ForWaitMillis(timeoutMillis);
    this.m_initialResendMillis = initialResendMillis;
    if (request == null)
      return;
    this.m_resendMillis = this.m_initialResendMillis;
    this.m_resendTimeout = new Timeout((long) this.m_resendMillis);
    long recordSeq = request.RecordSeq;
    int messageSeq = request.MessageSeq;
    byte[] message = request.Message;
    this.m_recordLayer.ResetAfterHelloVerifyRequestServer(recordSeq);
    DtlsReassembler dtlsReassembler = new DtlsReassembler((short) 1, message.Length - 12);
    this.m_currentInboundFlight[messageSeq] = dtlsReassembler;
    this.m_next_send_seq = 1;
    this.m_next_receive_seq = messageSeq + 1;
    this.m_handshakeHash.Update(message, 0, message.Length);
  }

  internal void ResetAfterHelloVerifyRequestClient()
  {
    this.m_currentInboundFlight = (IDictionary<int, DtlsReassembler>) new Dictionary<int, DtlsReassembler>();
    this.m_previousInboundFlight = (IDictionary<int, DtlsReassembler>) null;
    this.m_outboundFlight = (IList<DtlsReliableHandshake.Message>) new List<DtlsReliableHandshake.Message>();
    this.m_resendMillis = -1;
    this.m_resendTimeout = (Timeout) null;
    this.m_next_receive_seq = 1;
    this.m_handshakeHash.Reset();
  }

  internal TlsHandshakeHash HandshakeHash => this.m_handshakeHash;

  internal void PrepareToFinish() => this.m_handshakeHash.StopTracking();

  internal void SendMessage(short msg_type, byte[] body)
  {
    TlsUtilities.CheckUint24(body.Length);
    if (this.m_resendTimeout != null)
    {
      this.CheckInboundFlight();
      this.m_resendMillis = -1;
      this.m_resendTimeout = (Timeout) null;
      this.m_outboundFlight.Clear();
    }
    DtlsReliableHandshake.Message message = new DtlsReliableHandshake.Message(this.m_next_send_seq++, msg_type, body);
    this.m_outboundFlight.Add(message);
    this.WriteMessage(message);
    this.UpdateHandshakeMessagesDigest(message);
  }

  internal DtlsReliableHandshake.Message ReceiveMessage()
  {
    DtlsReliableHandshake.Message message = this.ImplReceiveMessage();
    this.UpdateHandshakeMessagesDigest(message);
    return message;
  }

  internal byte[] ReceiveMessageBody(short msg_type)
  {
    DtlsReliableHandshake.Message message = this.ImplReceiveMessage();
    if ((int) message.Type != (int) msg_type)
      throw new TlsFatalAlert((short) 10);
    this.UpdateHandshakeMessagesDigest(message);
    return message.Body;
  }

  internal DtlsReliableHandshake.Message ReceiveMessageDelayedDigest(short msg_type)
  {
    DtlsReliableHandshake.Message message = this.ImplReceiveMessage();
    if ((int) message.Type == (int) msg_type)
      return message;
    throw new TlsFatalAlert((short) 10);
  }

  internal void UpdateHandshakeMessagesDigest(DtlsReliableHandshake.Message message)
  {
    short type = message.Type;
    switch (type)
    {
      case 0:
        break;
      case 3:
        break;
      case 24:
        break;
      default:
        byte[] body = message.Body;
        byte[] numArray = new byte[12];
        TlsUtilities.WriteUint8(type, numArray, 0);
        TlsUtilities.WriteUint24(body.Length, numArray, 1);
        TlsUtilities.WriteUint16(message.Seq, numArray, 4);
        TlsUtilities.WriteUint24(0, numArray, 6);
        TlsUtilities.WriteUint24(body.Length, numArray, 9);
        this.m_handshakeHash.Update(numArray, 0, numArray.Length);
        this.m_handshakeHash.Update(body, 0, body.Length);
        break;
    }
  }

  internal void Finish()
  {
    DtlsHandshakeRetransmit retransmit = (DtlsHandshakeRetransmit) null;
    if (this.m_resendTimeout != null)
    {
      this.CheckInboundFlight();
    }
    else
    {
      this.PrepareInboundFlight((IDictionary<int, DtlsReassembler>) null);
      if (this.m_previousInboundFlight != null)
        retransmit = (DtlsHandshakeRetransmit) new DtlsReliableHandshake.Retransmit(this);
    }
    this.m_recordLayer.HandshakeSuccessful(retransmit);
  }

  internal static int BackOff(int timeoutMillis) => Math.Min(timeoutMillis * 2, 60000);

  private void CheckInboundFlight()
  {
    foreach (int key in (IEnumerable<int>) this.m_currentInboundFlight.Keys)
      ;
  }

  private DtlsReliableHandshake.Message GetPendingMessage()
  {
    DtlsReassembler dtlsReassembler;
    if (this.m_currentInboundFlight.TryGetValue(this.m_next_receive_seq, out dtlsReassembler))
    {
      byte[] bodyIfComplete = dtlsReassembler.GetBodyIfComplete();
      if (bodyIfComplete != null)
      {
        this.m_previousInboundFlight = (IDictionary<int, DtlsReassembler>) null;
        return new DtlsReliableHandshake.Message(this.m_next_receive_seq++, dtlsReassembler.MsgType, bodyIfComplete);
      }
    }
    return (DtlsReliableHandshake.Message) null;
  }

  private DtlsReliableHandshake.Message ImplReceiveMessage()
  {
    long currentTimeMillis = DateTimeUtilities.CurrentUnixMs();
    if (this.m_resendTimeout == null)
    {
      this.m_resendMillis = this.m_initialResendMillis;
      this.m_resendTimeout = new Timeout((long) this.m_resendMillis, currentTimeMillis);
      this.PrepareInboundFlight((IDictionary<int, DtlsReassembler>) new Dictionary<int, DtlsReassembler>());
    }
    byte[] buf = (byte[]) null;
    while (!this.m_recordLayer.IsClosed)
    {
      DtlsReliableHandshake.Message pendingMessage = this.GetPendingMessage();
      if (pendingMessage != null)
        return pendingMessage;
      if (Timeout.HasExpired(this.m_handshakeTimeout, currentTimeMillis))
        throw new TlsTimeoutException("Handshake timed out");
      int waitMillis = Timeout.ConstrainWaitMillis(Timeout.GetWaitMillis(this.m_handshakeTimeout, currentTimeMillis), this.m_resendTimeout, currentTimeMillis);
      if (waitMillis < 1)
        waitMillis = 1;
      int receiveLimit = this.m_recordLayer.GetReceiveLimit();
      if (buf == null || buf.Length < receiveLimit)
        buf = new byte[receiveLimit];
      int len = this.m_recordLayer.Receive(buf, 0, receiveLimit, waitMillis);
      if (len < 0)
        this.ResendOutboundFlight();
      else
        this.ProcessRecord(16 /*0x10*/, this.m_recordLayer.ReadEpoch, buf, 0, len);
      currentTimeMillis = DateTimeUtilities.CurrentUnixMs();
    }
    throw new TlsFatalAlert((short) 90);
  }

  private void PrepareInboundFlight(IDictionary<int, DtlsReassembler> nextFlight)
  {
    DtlsReliableHandshake.ResetAll(this.m_currentInboundFlight);
    this.m_previousInboundFlight = this.m_currentInboundFlight;
    this.m_currentInboundFlight = nextFlight;
  }

  private void ProcessRecord(int windowSize, int epoch, byte[] buf, int off, int len)
  {
    bool flag = false;
    int num1;
    for (; len >= 12; len -= num1)
    {
      int fragment_length = TlsUtilities.ReadUint24(buf, off + 9);
      num1 = fragment_length + 12;
      if (len >= num1)
      {
        int length = TlsUtilities.ReadUint24(buf, off + 1);
        int fragment_offset = TlsUtilities.ReadUint24(buf, off + 6);
        if (fragment_offset + fragment_length <= length)
        {
          short msg_type = TlsUtilities.ReadUint8(buf, off);
          int num2 = msg_type == (short) 20 ? 1 : 0;
          if (epoch == num2)
          {
            int key = TlsUtilities.ReadUint16(buf, off + 4);
            if (key < this.m_next_receive_seq + windowSize)
            {
              if (key >= this.m_next_receive_seq)
              {
                DtlsReassembler dtlsReassembler;
                if (!this.m_currentInboundFlight.TryGetValue(key, out dtlsReassembler))
                {
                  dtlsReassembler = new DtlsReassembler(msg_type, length);
                  this.m_currentInboundFlight[key] = dtlsReassembler;
                }
                dtlsReassembler.ContributeFragment(msg_type, length, buf, off + 12, fragment_offset, fragment_length);
              }
              else
              {
                DtlsReassembler dtlsReassembler;
                if (this.m_previousInboundFlight != null && this.m_previousInboundFlight.TryGetValue(key, out dtlsReassembler))
                {
                  dtlsReassembler.ContributeFragment(msg_type, length, buf, off + 12, fragment_offset, fragment_length);
                  flag = true;
                }
              }
            }
            off += num1;
          }
          else
            break;
        }
        else
          break;
      }
      else
        break;
    }
    if (!flag || !DtlsReliableHandshake.CheckAll(this.m_previousInboundFlight))
      return;
    this.ResendOutboundFlight();
    DtlsReliableHandshake.ResetAll(this.m_previousInboundFlight);
  }

  private void ResendOutboundFlight()
  {
    this.m_recordLayer.ResetWriteEpoch();
    foreach (DtlsReliableHandshake.Message message in (IEnumerable<DtlsReliableHandshake.Message>) this.m_outboundFlight)
      this.WriteMessage(message);
    this.m_resendMillis = DtlsReliableHandshake.BackOff(this.m_resendMillis);
    this.m_resendTimeout = new Timeout((long) this.m_resendMillis);
  }

  private void WriteMessage(DtlsReliableHandshake.Message message)
  {
    int val2 = this.m_recordLayer.GetSendLimit() - 12;
    if (val2 < 1)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    int length = message.Body.Length;
    int fragment_offset = 0;
    do
    {
      int fragment_length = Math.Min(length - fragment_offset, val2);
      this.WriteHandshakeFragment(message, fragment_offset, fragment_length);
      fragment_offset += fragment_length;
    }
    while (fragment_offset < length);
  }

  private void WriteHandshakeFragment(
    DtlsReliableHandshake.Message message,
    int fragment_offset,
    int fragment_length)
  {
    DtlsReliableHandshake.RecordLayerBuffer output = new DtlsReliableHandshake.RecordLayerBuffer(12 + fragment_length);
    TlsUtilities.WriteUint8(message.Type, (Stream) output);
    TlsUtilities.WriteUint24(message.Body.Length, (Stream) output);
    TlsUtilities.WriteUint16(message.Seq, (Stream) output);
    TlsUtilities.WriteUint24(fragment_offset, (Stream) output);
    TlsUtilities.WriteUint24(fragment_length, (Stream) output);
    output.Write(message.Body, fragment_offset, fragment_length);
    output.SendToRecordLayer(this.m_recordLayer);
  }

  private static bool CheckAll(IDictionary<int, DtlsReassembler> inboundFlight)
  {
    foreach (DtlsReassembler dtlsReassembler in (IEnumerable<DtlsReassembler>) inboundFlight.Values)
    {
      if (dtlsReassembler.GetBodyIfComplete() == null)
        return false;
    }
    return true;
  }

  private static void ResetAll(IDictionary<int, DtlsReassembler> inboundFlight)
  {
    foreach (DtlsReassembler dtlsReassembler in (IEnumerable<DtlsReassembler>) inboundFlight.Values)
      dtlsReassembler.Reset();
  }

  internal class Message
  {
    private readonly int m_message_seq;
    private readonly short m_msg_type;
    private readonly byte[] m_body;

    internal Message(int message_seq, short msg_type, byte[] body)
    {
      this.m_message_seq = message_seq;
      this.m_msg_type = msg_type;
      this.m_body = body;
    }

    public int Seq => this.m_message_seq;

    public short Type => this.m_msg_type;

    public byte[] Body => this.m_body;
  }

  internal class RecordLayerBuffer : MemoryStream
  {
    internal RecordLayerBuffer(int size)
      : base(size)
    {
    }

    internal void SendToRecordLayer(DtlsRecordLayer recordLayer)
    {
      byte[] buffer = this.GetBuffer();
      int int32 = Convert.ToInt32(this.Length);
      recordLayer.Send(buffer, 0, int32);
      this.Dispose();
    }
  }

  internal class Retransmit : DtlsHandshakeRetransmit
  {
    private readonly DtlsReliableHandshake m_outer;

    internal Retransmit(DtlsReliableHandshake outer) => this.m_outer = outer;

    public void ReceivedHandshakeRecord(int epoch, byte[] buf, int off, int len)
    {
      this.m_outer.ProcessRecord(0, epoch, buf, off, len);
    }
  }
}
