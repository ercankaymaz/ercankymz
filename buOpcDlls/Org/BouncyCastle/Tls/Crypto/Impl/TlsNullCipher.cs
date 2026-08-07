// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.TlsNullCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public class TlsNullCipher : TlsCipher, TlsCipherExt
{
  protected readonly TlsCryptoParameters m_cryptoParams;
  protected readonly TlsSuiteHmac m_readMac;
  protected readonly TlsSuiteHmac m_writeMac;
  protected readonly byte[] m_decryptConnectionID;
  protected readonly byte[] m_encryptConnectionID;
  protected readonly bool m_decryptUseInnerPlaintext;
  protected readonly bool m_encryptUseInnerPlaintext;

  public TlsNullCipher(TlsCryptoParameters cryptoParams, TlsHmac clientMac, TlsHmac serverMac)
  {
    SecurityParameters securityParameters = cryptoParams.SecurityParameters;
    this.m_decryptConnectionID = !TlsImplUtilities.IsTlsV13(securityParameters.NegotiatedVersion) ? securityParameters.ConnectionIDPeer : throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_encryptConnectionID = securityParameters.ConnectionIDLocal;
    this.m_decryptUseInnerPlaintext = !Arrays.IsNullOrEmpty(this.m_decryptConnectionID);
    this.m_encryptUseInnerPlaintext = !Arrays.IsNullOrEmpty(this.m_encryptConnectionID);
    this.m_cryptoParams = cryptoParams;
    int length = clientMac.MacLength + serverMac.MacLength;
    byte[] keyBlock = TlsImplUtilities.CalculateKeyBlock(cryptoParams, length);
    clientMac.SetKey(keyBlock, 0, clientMac.MacLength);
    int keyOff = 0 + clientMac.MacLength;
    serverMac.SetKey(keyBlock, keyOff, serverMac.MacLength);
    if (keyOff + serverMac.MacLength != length)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    if (cryptoParams.IsServer)
    {
      this.m_writeMac = new TlsSuiteHmac(cryptoParams, serverMac);
      this.m_readMac = new TlsSuiteHmac(cryptoParams, clientMac);
    }
    else
    {
      this.m_writeMac = new TlsSuiteHmac(cryptoParams, clientMac);
      this.m_readMac = new TlsSuiteHmac(cryptoParams, serverMac);
    }
  }

  public virtual int GetCiphertextDecodeLimit(int plaintextLimit)
  {
    return plaintextLimit + (this.m_decryptUseInnerPlaintext ? 1 : 0) + this.m_readMac.Size;
  }

  public virtual int GetCiphertextEncodeLimit(int plaintextLength, int plaintextLimit)
  {
    plaintextLimit = Math.Min(plaintextLength, plaintextLimit);
    return plaintextLimit + (this.m_encryptUseInnerPlaintext ? 1 : 0) + this.m_writeMac.Size;
  }

  public virtual int GetPlaintextLimit(int ciphertextLimit)
  {
    return this.GetPlaintextEncodeLimit(ciphertextLimit);
  }

  public virtual int GetPlaintextDecodeLimit(int ciphertextLimit)
  {
    return ciphertextLimit - this.m_readMac.Size - (this.m_decryptUseInnerPlaintext ? 1 : 0);
  }

  public virtual int GetPlaintextEncodeLimit(int ciphertextLimit)
  {
    return ciphertextLimit - this.m_writeMac.Size - (this.m_encryptUseInnerPlaintext ? 1 : 0);
  }

  public virtual TlsEncodeResult EncodePlaintext(
    long seqNo,
    short contentType,
    ProtocolVersion recordVersion,
    int headerAllocation,
    byte[] plaintext,
    int offset,
    int len)
  {
    int size = this.m_writeMac.Size;
    int msgLen = len + (this.m_encryptUseInnerPlaintext ? 1 : 0);
    byte[] numArray = new byte[headerAllocation + msgLen + size];
    Array.Copy((Array) plaintext, offset, (Array) numArray, headerAllocation, len);
    short num = contentType;
    if (this.m_encryptUseInnerPlaintext)
    {
      numArray[headerAllocation + len] = (byte) contentType;
      num = (short) 25;
    }
    byte[] mac = this.m_writeMac.CalculateMac(seqNo, num, this.m_encryptConnectionID, numArray, headerAllocation, msgLen);
    Array.Copy((Array) mac, 0, (Array) numArray, headerAllocation + msgLen, mac.Length);
    return new TlsEncodeResult(numArray, 0, numArray.Length, num);
  }

  public virtual TlsDecodeResult DecodeCiphertext(
    long seqNo,
    short recordType,
    ProtocolVersion recordVersion,
    byte[] ciphertext,
    int offset,
    int len)
  {
    int size = this.m_readMac.Size;
    int msgLen = len - size;
    if (msgLen < (this.m_decryptUseInnerPlaintext ? 1 : 0))
      throw new TlsFatalAlert((short) 50);
    byte[] mac = this.m_readMac.CalculateMac(seqNo, recordType, this.m_decryptConnectionID, ciphertext, offset, msgLen);
    if (!TlsUtilities.ConstantTimeAreEqual(size, mac, 0, ciphertext, offset + msgLen))
      throw new TlsFatalAlert((short) 20);
    short contentType = recordType;
    int len1 = msgLen;
    if (this.m_decryptUseInnerPlaintext)
    {
      while (--len1 >= 0)
      {
        byte num = ciphertext[offset + len1];
        if (num != (byte) 0)
        {
          contentType = (short) ((int) num & (int) byte.MaxValue);
          goto label_9;
        }
      }
      throw new TlsFatalAlert((short) 10);
    }
label_9:
    return new TlsDecodeResult(ciphertext, offset, len1, contentType);
  }

  public virtual void RekeyDecoder() => throw new TlsFatalAlert((short) 80 /*0x50*/);

  public virtual void RekeyEncoder() => throw new TlsFatalAlert((short) 80 /*0x50*/);

  public virtual bool UsesOpaqueRecordType => false;
}
