// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.TlsSuiteHmac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public class TlsSuiteHmac : TlsSuiteMac
{
  private const long SequenceNumberPlaceholder = -1;
  protected readonly TlsCryptoParameters m_cryptoParams;
  protected readonly TlsHmac m_mac;
  protected readonly int m_digestBlockSize;
  protected readonly int m_digestOverhead;
  protected readonly int m_macSize;

  protected static int GetMacSize(TlsCryptoParameters cryptoParams, TlsMac mac)
  {
    int val1 = mac.MacLength;
    if (cryptoParams.SecurityParameters.IsTruncatedHmac)
      val1 = Math.Min(val1, 10);
    return val1;
  }

  public TlsSuiteHmac(TlsCryptoParameters cryptoParams, TlsHmac mac)
  {
    this.m_cryptoParams = cryptoParams;
    this.m_mac = mac;
    this.m_macSize = TlsSuiteHmac.GetMacSize(cryptoParams, (TlsMac) mac);
    this.m_digestBlockSize = mac.InternalBlockSize;
    if (TlsImplUtilities.IsSsl(cryptoParams) && mac.MacLength == 20)
      this.m_digestOverhead = 4;
    else
      this.m_digestOverhead = this.m_digestBlockSize / 8;
  }

  public virtual int Size => this.m_macSize;

  public virtual byte[] CalculateMac(long seqNo, short type, byte[] msg, int msgOff, int msgLen)
  {
    return this.CalculateMac(seqNo, type, (byte[]) null, msg, msgOff, msgLen);
  }

  public virtual byte[] CalculateMac(
    long seqNo,
    short type,
    byte[] connectionID,
    byte[] msg,
    int msgOff,
    int msgLen)
  {
    ProtocolVersion serverVersion = this.m_cryptoParams.ServerVersion;
    if (serverVersion.IsSsl)
    {
      byte[] numArray = new byte[11];
      TlsUtilities.WriteUint64(seqNo, numArray, 0);
      TlsUtilities.WriteUint8(type, numArray, 8);
      TlsUtilities.WriteUint16(msgLen, numArray, 9);
      this.m_mac.Update(numArray, 0, numArray.Length);
    }
    else if (!Arrays.IsNullOrEmpty(connectionID))
    {
      int length = connectionID.Length;
      byte[] numArray = new byte[23 + length];
      TlsUtilities.WriteUint64(-1L, numArray, 0);
      TlsUtilities.WriteUint8((short) 25, numArray, 8);
      TlsUtilities.WriteUint8(length, numArray, 9);
      TlsUtilities.WriteUint8((short) 25, numArray, 10);
      TlsUtilities.WriteVersion(serverVersion, numArray, 11);
      TlsUtilities.WriteUint64(seqNo, numArray, 13);
      Array.Copy((Array) connectionID, 0, (Array) numArray, 21, length);
      TlsUtilities.WriteUint16(msgLen, numArray, 21 + length);
      this.m_mac.Update(numArray, 0, numArray.Length);
    }
    else
    {
      byte[] numArray = new byte[13];
      TlsUtilities.WriteUint64(seqNo, numArray, 0);
      TlsUtilities.WriteUint8(type, numArray, 8);
      TlsUtilities.WriteVersion(serverVersion, numArray, 9);
      TlsUtilities.WriteUint16(msgLen, numArray, 11);
      this.m_mac.Update(numArray, 0, numArray.Length);
    }
    this.m_mac.Update(msg, msgOff, msgLen);
    return this.Truncate(this.m_mac.CalculateMac());
  }

  public virtual byte[] CalculateMacConstantTime(
    long seqNo,
    short type,
    byte[] msg,
    int msgOff,
    int msgLen,
    int fullLength,
    byte[] dummyData)
  {
    return this.CalculateMacConstantTime(seqNo, type, (byte[]) null, msg, msgOff, msgLen, fullLength, dummyData);
  }

  public virtual byte[] CalculateMacConstantTime(
    long seqNo,
    short type,
    byte[] connectionID,
    byte[] msg,
    int msgOff,
    int msgLen,
    int fullLength,
    byte[] dummyData)
  {
    byte[] mac = this.CalculateMac(seqNo, type, connectionID, msg, msgOff, msgLen);
    int headerLength = this.GetHeaderLength(connectionID);
    int num = this.GetDigestBlockCount(headerLength + fullLength) - this.GetDigestBlockCount(headerLength + msgLen);
    while (--num >= 0)
      this.m_mac.Update(dummyData, 0, this.m_digestBlockSize);
    this.m_mac.Update(dummyData, 0, 1);
    this.m_mac.Reset();
    return mac;
  }

  protected virtual int GetDigestBlockCount(int inputLength)
  {
    return (inputLength + this.m_digestOverhead) / this.m_digestBlockSize;
  }

  protected virtual int GetHeaderLength(byte[] connectionID)
  {
    if (this.m_cryptoParams.ServerVersion.IsSsl)
      return 11;
    return !Arrays.IsNullOrEmpty(connectionID) ? 23 + connectionID.Length : 13;
  }

  protected virtual byte[] Truncate(byte[] bs)
  {
    return bs.Length <= this.m_macSize ? bs : Arrays.CopyOf(bs, this.m_macSize);
  }
}
