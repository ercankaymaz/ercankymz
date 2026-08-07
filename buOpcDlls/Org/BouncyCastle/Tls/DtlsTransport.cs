// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsTransport
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Net.Sockets;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class DtlsTransport : DatagramTransport, DatagramReceiver, DatagramSender, TlsCloseable
{
  private readonly DtlsRecordLayer m_recordLayer;
  private readonly bool m_ignoreCorruptRecords;

  internal DtlsTransport(DtlsRecordLayer recordLayer, bool ignoreCorruptRecords)
  {
    this.m_recordLayer = recordLayer;
    this.m_ignoreCorruptRecords = ignoreCorruptRecords;
  }

  public virtual int GetReceiveLimit() => this.m_recordLayer.GetReceiveLimit();

  public virtual int GetSendLimit() => this.m_recordLayer.GetSendLimit();

  public virtual int Receive(byte[] buf, int off, int len, int waitMillis)
  {
    return this.Receive(buf, off, len, waitMillis, (DtlsRecordCallback) null);
  }

  public virtual int Receive(
    byte[] buf,
    int off,
    int len,
    int waitMillis,
    DtlsRecordCallback recordCallback)
  {
    if (buf == null)
      throw new ArgumentNullException(nameof (buf));
    if (off < 0 || off >= buf.Length)
      throw new ArgumentException("invalid offset: " + off.ToString(), nameof (off));
    if (len < 0 || len > buf.Length - off)
      throw new ArgumentException("invalid length: " + len.ToString(), nameof (len));
    if (waitMillis < 0)
      throw new ArgumentException("cannot be negative", nameof (waitMillis));
    try
    {
      return this.m_recordLayer.Receive(buf, off, len, waitMillis, recordCallback);
    }
    catch (TlsFatalAlert ex)
    {
      if (this.m_ignoreCorruptRecords && (short) 20 == ex.AlertDescription)
        return -1;
      this.m_recordLayer.Fail(ex.AlertDescription);
      throw;
    }
    catch (TlsTimeoutException ex)
    {
      throw;
    }
    catch (SocketException ex)
    {
      if (TlsUtilities.IsTimeout(ex))
        throw;
      this.m_recordLayer.Fail((short) 80 /*0x50*/);
      throw new TlsFatalAlert((short) 80 /*0x50*/, (Exception) ex);
    }
    catch (IOException ex)
    {
      this.m_recordLayer.Fail((short) 80 /*0x50*/);
      throw;
    }
    catch (Exception ex)
    {
      this.m_recordLayer.Fail((short) 80 /*0x50*/);
      throw new TlsFatalAlert((short) 80 /*0x50*/, ex);
    }
  }

  public virtual int ReceivePending(
    byte[] buf,
    int off,
    int len,
    DtlsRecordCallback recordCallback = null)
  {
    if (buf == null)
      throw new ArgumentNullException(nameof (buf));
    if (off >= 0 && off < buf.Length)
    {
      if (len >= 0)
      {
        if (len <= buf.Length - off)
        {
          try
          {
            return this.m_recordLayer.ReceivePending(buf, off, len, recordCallback);
          }
          catch (TlsFatalAlert ex)
          {
            if (this.m_ignoreCorruptRecords && (short) 20 == ex.AlertDescription)
              return -1;
            this.m_recordLayer.Fail(ex.AlertDescription);
            throw;
          }
          catch (TlsTimeoutException ex)
          {
            throw;
          }
          catch (SocketException ex)
          {
            if (TlsUtilities.IsTimeout(ex))
              throw;
            this.m_recordLayer.Fail((short) 80 /*0x50*/);
            throw new TlsFatalAlert((short) 80 /*0x50*/, (Exception) ex);
          }
          catch (IOException ex)
          {
            this.m_recordLayer.Fail((short) 80 /*0x50*/);
            throw;
          }
          catch (Exception ex)
          {
            this.m_recordLayer.Fail((short) 80 /*0x50*/);
            throw new TlsFatalAlert((short) 80 /*0x50*/, ex);
          }
        }
      }
      throw new ArgumentException("invalid length: " + len.ToString(), nameof (len));
    }
    throw new ArgumentException("invalid offset: " + off.ToString(), nameof (off));
  }

  public virtual void Send(byte[] buf, int off, int len)
  {
    if (buf == null)
      throw new ArgumentNullException(nameof (buf));
    if (off >= 0 && off < buf.Length)
    {
      if (len >= 0)
      {
        if (len <= buf.Length - off)
        {
          try
          {
            this.m_recordLayer.Send(buf, off, len);
            return;
          }
          catch (TlsFatalAlert ex)
          {
            this.m_recordLayer.Fail(ex.AlertDescription);
            throw;
          }
          catch (TlsTimeoutException ex)
          {
            throw;
          }
          catch (SocketException ex)
          {
            if (TlsUtilities.IsTimeout(ex))
              throw;
            this.m_recordLayer.Fail((short) 80 /*0x50*/);
            throw new TlsFatalAlert((short) 80 /*0x50*/, (Exception) ex);
          }
          catch (IOException ex)
          {
            this.m_recordLayer.Fail((short) 80 /*0x50*/);
            throw;
          }
          catch (Exception ex)
          {
            this.m_recordLayer.Fail((short) 80 /*0x50*/);
            throw new TlsFatalAlert((short) 80 /*0x50*/, ex);
          }
        }
      }
      throw new ArgumentException("invalid length: " + len.ToString(), nameof (len));
    }
    throw new ArgumentException("invalid offset: " + off.ToString(), nameof (off));
  }

  public virtual void Close() => this.m_recordLayer.Close();
}
