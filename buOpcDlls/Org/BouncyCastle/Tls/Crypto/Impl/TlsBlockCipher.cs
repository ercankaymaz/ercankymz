// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.TlsBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public class TlsBlockCipher : TlsCipher, TlsCipherExt
{
  protected readonly TlsCryptoParameters m_cryptoParams;
  protected readonly byte[] m_randomData;
  protected readonly bool m_encryptThenMac;
  protected readonly bool m_useExplicitIV;
  protected readonly bool m_acceptExtraPadding;
  protected readonly bool m_useExtraPadding;
  protected readonly TlsBlockCipherImpl m_decryptCipher;
  protected readonly TlsBlockCipherImpl m_encryptCipher;
  protected readonly TlsSuiteHmac m_readMac;
  protected readonly TlsSuiteHmac m_writeMac;
  protected readonly byte[] m_decryptConnectionID;
  protected readonly byte[] m_encryptConnectionID;
  protected readonly bool m_decryptUseInnerPlaintext;
  protected readonly bool m_encryptUseInnerPlaintext;

  public TlsBlockCipher(
    TlsCryptoParameters cryptoParams,
    TlsBlockCipherImpl encryptCipher,
    TlsBlockCipherImpl decryptCipher,
    TlsHmac clientMac,
    TlsHmac serverMac,
    int cipherKeySize)
  {
    SecurityParameters securityParameters = cryptoParams.SecurityParameters;
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    if (TlsImplUtilities.IsTlsV13(negotiatedVersion))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_decryptConnectionID = securityParameters.ConnectionIDPeer;
    this.m_encryptConnectionID = securityParameters.ConnectionIDLocal;
    this.m_decryptUseInnerPlaintext = !Arrays.IsNullOrEmpty(this.m_decryptConnectionID);
    this.m_encryptUseInnerPlaintext = !Arrays.IsNullOrEmpty(this.m_encryptConnectionID);
    this.m_cryptoParams = cryptoParams;
    this.m_randomData = cryptoParams.NonceGenerator.GenerateNonce(256 /*0x0100*/);
    this.m_encryptThenMac = securityParameters.IsEncryptThenMac;
    this.m_useExplicitIV = TlsImplUtilities.IsTlsV11(negotiatedVersion);
    this.m_acceptExtraPadding = !negotiatedVersion.IsSsl;
    this.m_useExtraPadding = securityParameters.IsExtendedPadding && ProtocolVersion.TLSv10.IsEqualOrEarlierVersionOf(negotiatedVersion) && (this.m_encryptThenMac || !securityParameters.IsTruncatedHmac);
    this.m_encryptCipher = encryptCipher;
    this.m_decryptCipher = decryptCipher;
    TlsBlockCipherImpl tlsBlockCipherImpl1;
    TlsBlockCipherImpl tlsBlockCipherImpl2;
    if (cryptoParams.IsServer)
    {
      tlsBlockCipherImpl1 = decryptCipher;
      tlsBlockCipherImpl2 = encryptCipher;
    }
    else
    {
      tlsBlockCipherImpl1 = encryptCipher;
      tlsBlockCipherImpl2 = decryptCipher;
    }
    int length = 2 * cipherKeySize + clientMac.MacLength + serverMac.MacLength;
    if (!this.m_useExplicitIV)
      length += tlsBlockCipherImpl1.GetBlockSize() + tlsBlockCipherImpl2.GetBlockSize();
    byte[] keyBlock = TlsImplUtilities.CalculateKeyBlock(cryptoParams, length);
    clientMac.SetKey(keyBlock, 0, clientMac.MacLength);
    int keyOff1 = 0 + clientMac.MacLength;
    serverMac.SetKey(keyBlock, keyOff1, serverMac.MacLength);
    int keyOff2 = keyOff1 + serverMac.MacLength;
    tlsBlockCipherImpl1.SetKey(keyBlock, keyOff2, cipherKeySize);
    int keyOff3 = keyOff2 + cipherKeySize;
    tlsBlockCipherImpl2.SetKey(keyBlock, keyOff3, cipherKeySize);
    int ivOff1 = keyOff3 + cipherKeySize;
    int blockSize1 = tlsBlockCipherImpl1.GetBlockSize();
    int blockSize2 = tlsBlockCipherImpl2.GetBlockSize();
    if (this.m_useExplicitIV)
    {
      tlsBlockCipherImpl1.Init(new byte[blockSize1], 0, blockSize1);
      tlsBlockCipherImpl2.Init(new byte[blockSize2], 0, blockSize2);
    }
    else
    {
      tlsBlockCipherImpl1.Init(keyBlock, ivOff1, blockSize1);
      int ivOff2 = ivOff1 + blockSize1;
      tlsBlockCipherImpl2.Init(keyBlock, ivOff2, blockSize2);
      ivOff1 = ivOff2 + blockSize2;
    }
    if (ivOff1 != length)
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
    return this.GetCiphertextLength(this.m_decryptCipher.GetBlockSize(), this.m_readMac.Size, 256 /*0x0100*/, plaintextLimit + (this.m_decryptUseInnerPlaintext ? 1 : 0));
  }

  public virtual int GetCiphertextEncodeLimit(int plaintextLength, int plaintextLimit)
  {
    plaintextLimit = Math.Min(plaintextLength, plaintextLimit);
    int blockSize = this.m_encryptCipher.GetBlockSize();
    int size = this.m_writeMac.Size;
    int maxPadding = this.m_useExtraPadding ? 256 /*0x0100*/ : blockSize;
    int plaintextLength1 = plaintextLimit + (this.m_encryptUseInnerPlaintext ? 1 : 0);
    return this.GetCiphertextLength(blockSize, size, maxPadding, plaintextLength1);
  }

  public virtual int GetPlaintextLimit(int ciphertextLimit)
  {
    return this.GetPlaintextEncodeLimit(ciphertextLimit);
  }

  public virtual int GetPlaintextDecodeLimit(int ciphertextLimit)
  {
    return this.GetPlaintextLength(this.m_decryptCipher.GetBlockSize(), this.m_readMac.Size, ciphertextLimit) - (this.m_decryptUseInnerPlaintext ? 1 : 0);
  }

  public virtual int GetPlaintextEncodeLimit(int ciphertextLimit)
  {
    return this.GetPlaintextLength(this.m_encryptCipher.GetBlockSize(), this.m_writeMac.Size, ciphertextLimit) - (this.m_encryptUseInnerPlaintext ? 1 : 0);
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
    int blockSize = this.m_encryptCipher.GetBlockSize();
    int size = this.m_writeMac.Size;
    int msgLen = len + (this.m_encryptUseInnerPlaintext ? 1 : 0);
    int num1 = msgLen;
    if (!this.m_encryptThenMac)
      num1 += size;
    int num2 = blockSize - num1 % blockSize;
    if (this.m_useExtraPadding)
    {
      int num3 = this.ChooseExtraPadBlocks((256 /*0x0100*/ - num2) / blockSize);
      num2 += num3 * blockSize;
    }
    int num4 = msgLen + size + num2;
    if (this.m_useExplicitIV)
      num4 += blockSize;
    byte[] numArray = new byte[headerAllocation + num4];
    int destinationIndex1 = headerAllocation;
    if (this.m_useExplicitIV)
    {
      Array.Copy((Array) this.m_cryptoParams.NonceGenerator.GenerateNonce(blockSize), 0, (Array) numArray, destinationIndex1, blockSize);
      destinationIndex1 += blockSize;
    }
    int msgOff = destinationIndex1;
    Array.Copy((Array) plaintext, offset, (Array) numArray, destinationIndex1, len);
    int destinationIndex2 = destinationIndex1 + len;
    short num5 = contentType;
    if (this.m_encryptUseInnerPlaintext)
    {
      numArray[destinationIndex2++] = (byte) contentType;
      num5 = (short) 25;
    }
    if (!this.m_encryptThenMac)
    {
      byte[] mac = this.m_writeMac.CalculateMac(seqNo, num5, this.m_encryptConnectionID, numArray, msgOff, msgLen);
      Array.Copy((Array) mac, 0, (Array) numArray, destinationIndex2, mac.Length);
      destinationIndex2 += mac.Length;
    }
    byte num6 = (byte) (num2 - 1);
    for (int index = 0; index < num2; ++index)
      numArray[destinationIndex2++] = num6;
    this.m_encryptCipher.DoFinal(numArray, headerAllocation, destinationIndex2 - headerAllocation, numArray, headerAllocation);
    if (this.m_encryptThenMac)
    {
      byte[] mac = this.m_writeMac.CalculateMac(seqNo, num5, this.m_encryptConnectionID, numArray, headerAllocation, destinationIndex2 - headerAllocation);
      Array.Copy((Array) mac, 0, (Array) numArray, destinationIndex2, mac.Length);
      destinationIndex2 += mac.Length;
    }
    if (destinationIndex2 != numArray.Length)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    return new TlsEncodeResult(numArray, 0, numArray.Length, num5);
  }

  public virtual TlsDecodeResult DecodeCiphertext(
    long seqNo,
    short recordType,
    ProtocolVersion recordVersion,
    byte[] ciphertext,
    int offset,
    int len)
  {
    int blockSize = this.m_decryptCipher.GetBlockSize();
    int size = this.m_readMac.Size;
    int val1 = blockSize;
    int num1 = !this.m_encryptThenMac ? Math.Max(val1, size + 1) : val1 + size;
    if (this.m_useExplicitIV)
      num1 += blockSize;
    int num2 = len >= num1 ? len : throw new TlsFatalAlert((short) 50);
    if (this.m_encryptThenMac)
      num2 -= size;
    if (num2 % blockSize != 0)
      throw new TlsFatalAlert((short) 21);
    if (this.m_encryptThenMac)
    {
      byte[] mac = this.m_readMac.CalculateMac(seqNo, recordType, this.m_decryptConnectionID, ciphertext, offset, len - size);
      if (!TlsUtilities.ConstantTimeAreEqual(size, mac, 0, ciphertext, offset + len - size))
        throw new TlsFatalAlert((short) 20);
    }
    this.m_decryptCipher.DoFinal(ciphertext, offset, num2, ciphertext, offset);
    if (this.m_useExplicitIV)
    {
      offset += blockSize;
      num2 -= blockSize;
    }
    int num3 = this.CheckPaddingConstantTime(ciphertext, offset, num2, blockSize, this.m_encryptThenMac ? 0 : size);
    bool flag = num3 == 0;
    int msgLen = num2 - num3;
    if (!this.m_encryptThenMac)
    {
      msgLen -= size;
      byte[] macConstantTime = this.m_readMac.CalculateMacConstantTime(seqNo, recordType, this.m_decryptConnectionID, ciphertext, offset, msgLen, num2 - size, this.m_randomData);
      flag |= !TlsUtilities.ConstantTimeAreEqual(size, macConstantTime, 0, ciphertext, offset + msgLen);
    }
    if (flag)
      throw new TlsFatalAlert((short) 20);
    short contentType = recordType;
    int len1 = msgLen;
    if (this.m_decryptUseInnerPlaintext)
    {
      while (--len1 >= 0)
      {
        byte num4 = ciphertext[offset + len1];
        if (num4 != (byte) 0)
        {
          contentType = (short) ((int) num4 & (int) byte.MaxValue);
          goto label_22;
        }
      }
      throw new TlsFatalAlert((short) 10);
    }
label_22:
    return new TlsDecodeResult(ciphertext, offset, len1, contentType);
  }

  public virtual void RekeyDecoder() => throw new TlsFatalAlert((short) 80 /*0x50*/);

  public virtual void RekeyEncoder() => throw new TlsFatalAlert((short) 80 /*0x50*/);

  public virtual bool UsesOpaqueRecordType => false;

  protected virtual int CheckPaddingConstantTime(
    byte[] buf,
    int off,
    int len,
    int blockSize,
    int macSize)
  {
    int num1 = off + len;
    byte num2 = buf[num1 - 1];
    int num3 = ((int) num2 & (int) byte.MaxValue) + 1;
    int num4 = 0;
    byte num5 = 0;
    int num6 = Math.Min(this.m_acceptExtraPadding ? 256 /*0x0100*/ : blockSize, len - macSize);
    if (num3 > num6)
    {
      num3 = 0;
    }
    else
    {
      int num7 = num1 - num3;
      do
      {
        num5 |= (byte) ((uint) buf[num7++] ^ (uint) num2);
      }
      while (num7 < num1);
      num4 = num3;
      if (num5 != (byte) 0)
        num3 = 0;
    }
    byte[] randomData = this.m_randomData;
    while (num4 < 256 /*0x0100*/)
      num5 |= (byte) ((uint) randomData[num4++] ^ (uint) num2);
    randomData[0] ^= num5;
    return num3;
  }

  protected virtual int ChooseExtraPadBlocks(int max)
  {
    return Math.Min(Integers.NumberOfTrailingZeros((int) Pack.LE_To_UInt32(this.m_cryptoParams.NonceGenerator.GenerateNonce(4), 0)), max);
  }

  protected virtual int GetCiphertextLength(
    int blockSize,
    int macSize,
    int maxPadding,
    int plaintextLength)
  {
    int num1 = plaintextLength;
    if (this.m_useExplicitIV)
      num1 += blockSize;
    int num2 = num1 + maxPadding;
    int ciphertextLength;
    if (this.m_encryptThenMac)
    {
      ciphertextLength = num2 - num2 % blockSize + macSize;
    }
    else
    {
      int num3 = num2 + macSize;
      ciphertextLength = num3 - num3 % blockSize;
    }
    return ciphertextLength;
  }

  protected virtual int GetPlaintextLength(int blockSize, int macSize, int ciphertextLength)
  {
    int num1 = ciphertextLength;
    int num2;
    if (this.m_encryptThenMac)
    {
      int num3 = num1 - macSize;
      num2 = num3 - num3 % blockSize;
    }
    else
      num2 = num1 - num1 % blockSize - macSize;
    int plaintextLength = num2 - 1;
    if (this.m_useExplicitIV)
      plaintextLength -= blockSize;
    return plaintextLength;
  }
}
