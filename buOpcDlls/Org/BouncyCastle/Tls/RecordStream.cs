// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.RecordStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;
using System.IO;
using System.Runtime.ExceptionServices;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal sealed class RecordStream
{
  private const int DefaultPlaintextLimit = 16384 /*0x4000*/;
  private readonly RecordStream.Record m_inputRecord = new RecordStream.Record();
  private readonly RecordStream.SequenceNumber m_readSeqNo = new RecordStream.SequenceNumber();
  private readonly RecordStream.SequenceNumber m_writeSeqNo = new RecordStream.SequenceNumber();
  private readonly TlsProtocol m_handler;
  private readonly Stream m_input;
  private readonly Stream m_output;
  private TlsCipher m_pendingCipher;
  private TlsCipher m_readCipher = (TlsCipher) TlsNullNullCipher.Instance;
  private TlsCipher m_readCipherDeferred;
  private TlsCipher m_writeCipher = (TlsCipher) TlsNullNullCipher.Instance;
  private ProtocolVersion m_writeVersion;
  private int m_plaintextLimit = 16384 /*0x4000*/;
  private int m_ciphertextLimit = 16384 /*0x4000*/;
  private bool m_ignoreChangeCipherSpec;

  internal RecordStream(TlsProtocol handler, Stream input, Stream output)
  {
    this.m_handler = handler;
    this.m_input = input;
    this.m_output = output;
  }

  internal int PlaintextLimit => this.m_plaintextLimit;

  internal void SetPlaintextLimit(int plaintextLimit)
  {
    this.m_plaintextLimit = plaintextLimit;
    this.m_ciphertextLimit = this.m_readCipher.GetCiphertextDecodeLimit(plaintextLimit);
  }

  internal void SetWriteVersion(ProtocolVersion writeVersion) => this.m_writeVersion = writeVersion;

  internal void SetIgnoreChangeCipherSpec(bool ignoreChangeCipherSpec)
  {
    this.m_ignoreChangeCipherSpec = ignoreChangeCipherSpec;
  }

  internal void SetPendingCipher(TlsCipher tlsCipher) => this.m_pendingCipher = tlsCipher;

  internal void NotifyChangeCipherSpecReceived()
  {
    if (this.m_pendingCipher == null)
      throw new TlsFatalAlert((short) 10, "No pending cipher");
    this.EnablePendingCipherRead(false);
  }

  internal void EnablePendingCipherRead(bool deferred)
  {
    if (this.m_pendingCipher == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    if (this.m_readCipherDeferred != null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    if (deferred)
    {
      this.m_readCipherDeferred = this.m_pendingCipher;
    }
    else
    {
      this.m_readCipher = this.m_pendingCipher;
      this.m_ciphertextLimit = this.m_readCipher.GetCiphertextDecodeLimit(this.m_plaintextLimit);
      this.m_readSeqNo.Reset();
    }
  }

  internal void EnablePendingCipherWrite()
  {
    this.m_writeCipher = this.m_pendingCipher != null ? this.m_pendingCipher : throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_writeSeqNo.Reset();
  }

  internal void FinaliseHandshake()
  {
    if (this.m_readCipher != this.m_pendingCipher || this.m_writeCipher != this.m_pendingCipher)
      throw new TlsFatalAlert((short) 40);
    this.m_pendingCipher = (TlsCipher) null;
  }

  internal bool NeedsKeyUpdate() => this.m_writeSeqNo.CurrentValue >= 1048576L /*0x100000*/;

  internal void NotifyKeyUpdateReceived()
  {
    this.m_readCipher.RekeyDecoder();
    this.m_readSeqNo.Reset();
  }

  internal void NotifyKeyUpdateSent()
  {
    this.m_writeCipher.RekeyEncoder();
    this.m_writeSeqNo.Reset();
  }

  internal RecordPreview PreviewRecordHeader(byte[] recordHeader)
  {
    short num1 = this.CheckRecordType(recordHeader, 0);
    int num2 = TlsUtilities.ReadUint16(recordHeader, 3);
    RecordStream.CheckLength(num2, this.m_ciphertextLimit, (short) 22);
    int recordSize = 5 + num2;
    int num3 = 0;
    if ((short) 23 == num1 && this.m_handler.IsApplicationDataReady)
    {
      TlsCipher readCipher = this.m_readCipher;
      num3 = Math.Max(0, Math.Min(this.m_plaintextLimit, !(readCipher is TlsCipherExt tlsCipherExt) ? readCipher.GetPlaintextLimit(num2) : tlsCipherExt.GetPlaintextDecodeLimit(num2)));
    }
    int contentLimit = num3;
    return new RecordPreview(recordSize, contentLimit);
  }

  internal RecordPreview PreviewOutputRecord(int contentLength)
  {
    int num = Math.Max(0, Math.Min(this.m_plaintextLimit, contentLength));
    return new RecordPreview(this.PreviewOutputRecordSize(num), num);
  }

  internal int PreviewOutputRecordSize(int contentLength)
  {
    return 5 + this.m_writeCipher.GetCiphertextEncodeLimit(contentLength, this.m_plaintextLimit);
  }

  internal bool ReadFullRecord(byte[] input, int inputOff, int inputLen)
  {
    if (inputLen < 5)
      return false;
    int num = TlsUtilities.ReadUint16(input, inputOff + 3);
    if (inputLen != 5 + num)
      return false;
    short recordType = this.CheckRecordType(input, inputOff);
    ProtocolVersion recordVersion = TlsUtilities.ReadVersion(input, inputOff + 1);
    RecordStream.CheckLength(num, this.m_ciphertextLimit, (short) 22);
    if (this.m_ignoreChangeCipherSpec && (short) 20 == recordType)
    {
      this.CheckChangeCipherSpec(input, inputOff + 5, num);
      return true;
    }
    TlsDecodeResult tlsDecodeResult = this.DecodeAndVerify(recordType, recordVersion, input, inputOff + 5, num);
    this.m_handler.ProcessRecord(tlsDecodeResult.contentType, tlsDecodeResult.buf, tlsDecodeResult.off, tlsDecodeResult.len);
    return true;
  }

  internal bool ReadRecord()
  {
    if (!this.m_inputRecord.ReadHeader(this.m_input))
      return false;
    short recordType = this.CheckRecordType(this.m_inputRecord.m_buf, 0);
    ProtocolVersion recordVersion = TlsUtilities.ReadVersion(this.m_inputRecord.m_buf, 1);
    int num = TlsUtilities.ReadUint16(this.m_inputRecord.m_buf, 3);
    RecordStream.CheckLength(num, this.m_ciphertextLimit, (short) 22);
    this.m_inputRecord.ReadFragment(this.m_input, num);
    TlsDecodeResult tlsDecodeResult;
    try
    {
      if (this.m_ignoreChangeCipherSpec && (short) 20 == recordType)
      {
        this.CheckChangeCipherSpec(this.m_inputRecord.m_buf, 5, num);
        return true;
      }
      tlsDecodeResult = this.DecodeAndVerify(recordType, recordVersion, this.m_inputRecord.m_buf, 5, num);
    }
    finally
    {
      this.m_inputRecord.Reset();
    }
    this.m_handler.ProcessRecord(tlsDecodeResult.contentType, tlsDecodeResult.buf, tlsDecodeResult.off, tlsDecodeResult.len);
    return true;
  }

  internal TlsDecodeResult DecodeAndVerify(
    short recordType,
    ProtocolVersion recordVersion,
    byte[] ciphertext,
    int off,
    int len)
  {
    TlsDecodeResult tlsDecodeResult = this.m_readCipher.DecodeCiphertext(this.m_readSeqNo.NextValue((short) 10), recordType, recordVersion, ciphertext, off, len);
    RecordStream.CheckLength(tlsDecodeResult.len, this.m_plaintextLimit, (short) 22);
    if (tlsDecodeResult.len < 1 && tlsDecodeResult.contentType != (short) 23)
      throw new TlsFatalAlert((short) 47);
    return tlsDecodeResult;
  }

  internal void WriteRecord(
    short contentType,
    byte[] plaintext,
    int plaintextOffset,
    int plaintextLength)
  {
    if (this.m_writeVersion == null)
      return;
    RecordStream.CheckLength(plaintextLength, this.m_plaintextLimit, (short) 80 /*0x50*/);
    if (plaintextLength < 1 && contentType != (short) 23)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    long seqNo = this.m_writeSeqNo.NextValue((short) 80 /*0x50*/);
    ProtocolVersion writeVersion = this.m_writeVersion;
    TlsEncodeResult tlsEncodeResult = this.m_writeCipher.EncodePlaintext(seqNo, contentType, writeVersion, 5, plaintext, plaintextOffset, plaintextLength);
    int i = tlsEncodeResult.len - 5;
    TlsUtilities.CheckUint16(i);
    TlsUtilities.WriteUint8(tlsEncodeResult.recordType, tlsEncodeResult.buf, tlsEncodeResult.off);
    TlsUtilities.WriteVersion(writeVersion, tlsEncodeResult.buf, tlsEncodeResult.off + 1);
    TlsUtilities.WriteUint16(i, tlsEncodeResult.buf, tlsEncodeResult.off + 3);
    this.m_output.Write(tlsEncodeResult.buf, tlsEncodeResult.off, tlsEncodeResult.len);
    this.m_output.Flush();
  }

  internal void Close()
  {
    this.m_inputRecord.Reset();
    ExceptionDispatchInfo exceptionDispatchInfo = (ExceptionDispatchInfo) null;
    try
    {
      this.m_input.Dispose();
    }
    catch (IOException ex)
    {
      exceptionDispatchInfo = ExceptionDispatchInfo.Capture((Exception) ex);
    }
    try
    {
      this.m_output.Dispose();
    }
    catch (IOException ex)
    {
      if (exceptionDispatchInfo == null)
        exceptionDispatchInfo = ExceptionDispatchInfo.Capture((Exception) ex);
    }
    exceptionDispatchInfo?.Throw();
  }

  private void CheckChangeCipherSpec(byte[] buf, int off, int len)
  {
    if (1 != len || (byte) 1 != buf[off])
      throw new TlsFatalAlert((short) 10, "Malformed " + ContentType.GetText((short) 20));
  }

  private short CheckRecordType(byte[] buf, int off)
  {
    short contentType = TlsUtilities.ReadUint8(buf, off);
    if (this.m_readCipherDeferred != null && contentType == (short) 23)
    {
      this.m_readCipher = this.m_readCipherDeferred;
      this.m_readCipherDeferred = (TlsCipher) null;
      this.m_ciphertextLimit = this.m_readCipher.GetCiphertextDecodeLimit(this.m_plaintextLimit);
      this.m_readSeqNo.Reset();
    }
    else if (this.m_readCipher.UsesOpaqueRecordType)
    {
      if ((short) 23 != contentType && (!this.m_ignoreChangeCipherSpec || (short) 20 != contentType))
        throw new TlsFatalAlert((short) 10, "Opaque " + ContentType.GetText(contentType));
    }
    else
    {
      switch (contentType)
      {
        case 20:
        case 21:
        case 22:
          break;
        case 23:
          if (!this.m_handler.IsApplicationDataReady)
            throw new TlsFatalAlert((short) 10, "Not ready for " + ContentType.GetText((short) 23));
          break;
        default:
          throw new TlsFatalAlert((short) 10, "Unsupported " + ContentType.GetText(contentType));
      }
    }
    return contentType;
  }

  private static void CheckLength(int length, int limit, short alertDescription)
  {
    if (length > limit)
      throw new TlsFatalAlert(alertDescription);
  }

  private sealed class Record
  {
    private readonly byte[] m_header = new byte[5];
    internal volatile byte[] m_buf;
    internal volatile int m_pos;

    internal Record()
    {
      this.m_buf = this.m_header;
      this.m_pos = 0;
    }

    internal void FillTo(Stream input, int length)
    {
      int num;
      for (; this.m_pos < length; this.m_pos += num)
      {
        num = input.Read(this.m_buf, this.m_pos, length - this.m_pos);
        if (num < 1)
          break;
      }
    }

    internal void ReadFragment(Stream input, int fragmentLength)
    {
      int length = 5 + fragmentLength;
      this.Resize(length);
      this.FillTo(input, length);
      if (this.m_pos < length)
        throw new EndOfStreamException();
    }

    internal bool ReadHeader(Stream input)
    {
      this.FillTo(input, 5);
      if (this.m_pos == 0)
        return false;
      if (this.m_pos < 5)
        throw new EndOfStreamException();
      return true;
    }

    internal void Reset()
    {
      this.m_buf = this.m_header;
      this.m_pos = 0;
    }

    private void Resize(int length)
    {
      if (this.m_buf.Length >= length)
        return;
      byte[] destinationArray = new byte[length];
      Array.Copy((Array) this.m_buf, 0, (Array) destinationArray, 0, this.m_pos);
      this.m_buf = destinationArray;
    }
  }

  private sealed class SequenceNumber
  {
    private long m_value;
    private bool m_exhausted;

    internal long CurrentValue
    {
      get
      {
        lock (this)
          return this.m_value;
      }
    }

    internal long NextValue(short alertDescription)
    {
      lock (this)
      {
        if (this.m_exhausted)
          throw new TlsFatalAlert(alertDescription, "Sequence numbers exhausted");
        long num = this.m_value;
        if (++this.m_value == 0L)
          this.m_exhausted = true;
        return num;
      }
    }

    internal void Reset()
    {
      lock (this)
      {
        this.m_value = 0L;
        this.m_exhausted = false;
      }
    }
  }
}
