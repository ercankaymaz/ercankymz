// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.TlsAeadCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public class TlsAeadCipher : TlsCipher, TlsCipherExt
{
  public const int AEAD_CCM = 1;
  public const int AEAD_CHACHA20_POLY1305 = 2;
  public const int AEAD_GCM = 3;
  private const int NONCE_RFC5288 = 1;
  private const int NONCE_RFC7905 = 2;
  private const long SequenceNumberPlaceholder = -1;
  protected readonly TlsCryptoParameters m_cryptoParams;
  protected readonly int m_keySize;
  protected readonly int m_macSize;
  protected readonly int m_fixed_iv_length;
  protected readonly int m_record_iv_length;
  protected readonly TlsAeadCipherImpl m_decryptCipher;
  protected readonly TlsAeadCipherImpl m_encryptCipher;
  protected readonly byte[] m_decryptNonce;
  protected readonly byte[] m_encryptNonce;
  protected readonly byte[] m_decryptConnectionID;
  protected readonly byte[] m_encryptConnectionID;
  protected readonly bool m_decryptUseInnerPlaintext;
  protected readonly bool m_encryptUseInnerPlaintext;
  protected readonly bool m_isTlsV13;
  protected readonly int m_nonceMode;

  public TlsAeadCipher(
    TlsCryptoParameters cryptoParams,
    TlsAeadCipherImpl encryptCipher,
    TlsAeadCipherImpl decryptCipher,
    int keySize,
    int macSize,
    int aeadType)
  {
    SecurityParameters securityParameters = cryptoParams.SecurityParameters;
    ProtocolVersion negotiatedVersion = securityParameters.NegotiatedVersion;
    this.m_isTlsV13 = TlsImplUtilities.IsTlsV12(negotiatedVersion) ? TlsImplUtilities.IsTlsV13(negotiatedVersion) : throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_nonceMode = TlsAeadCipher.GetNonceMode(this.m_isTlsV13, aeadType);
    this.m_decryptConnectionID = securityParameters.ConnectionIDPeer;
    this.m_encryptConnectionID = securityParameters.ConnectionIDLocal;
    this.m_decryptUseInnerPlaintext = this.m_isTlsV13 || !Arrays.IsNullOrEmpty(this.m_decryptConnectionID);
    this.m_encryptUseInnerPlaintext = this.m_isTlsV13 || !Arrays.IsNullOrEmpty(this.m_encryptConnectionID);
    switch (this.m_nonceMode)
    {
      case 1:
        this.m_fixed_iv_length = 4;
        this.m_record_iv_length = 8;
        break;
      case 2:
        this.m_fixed_iv_length = 12;
        this.m_record_iv_length = 0;
        break;
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
    this.m_cryptoParams = cryptoParams;
    this.m_keySize = keySize;
    this.m_macSize = macSize;
    this.m_decryptCipher = decryptCipher;
    this.m_encryptCipher = encryptCipher;
    this.m_decryptNonce = new byte[this.m_fixed_iv_length];
    this.m_encryptNonce = new byte[this.m_fixed_iv_length];
    bool isServer = cryptoParams.IsServer;
    if (this.m_isTlsV13)
    {
      this.RekeyCipher(securityParameters, decryptCipher, this.m_decryptNonce, !isServer);
      this.RekeyCipher(securityParameters, encryptCipher, this.m_encryptNonce, isServer);
    }
    else
    {
      int length = 2 * keySize + 2 * this.m_fixed_iv_length;
      byte[] keyBlock = TlsImplUtilities.CalculateKeyBlock(cryptoParams, length);
      int keyOff1 = 0;
      int num;
      if (isServer)
      {
        decryptCipher.SetKey(keyBlock, keyOff1, keySize);
        int keyOff2 = keyOff1 + keySize;
        encryptCipher.SetKey(keyBlock, keyOff2, keySize);
        int sourceIndex1 = keyOff2 + keySize;
        Array.Copy((Array) keyBlock, sourceIndex1, (Array) this.m_decryptNonce, 0, this.m_fixed_iv_length);
        int sourceIndex2 = sourceIndex1 + this.m_fixed_iv_length;
        Array.Copy((Array) keyBlock, sourceIndex2, (Array) this.m_encryptNonce, 0, this.m_fixed_iv_length);
        num = sourceIndex2 + this.m_fixed_iv_length;
      }
      else
      {
        encryptCipher.SetKey(keyBlock, keyOff1, keySize);
        int keyOff3 = keyOff1 + keySize;
        decryptCipher.SetKey(keyBlock, keyOff3, keySize);
        int sourceIndex3 = keyOff3 + keySize;
        Array.Copy((Array) keyBlock, sourceIndex3, (Array) this.m_encryptNonce, 0, this.m_fixed_iv_length);
        int sourceIndex4 = sourceIndex3 + this.m_fixed_iv_length;
        Array.Copy((Array) keyBlock, sourceIndex4, (Array) this.m_decryptNonce, 0, this.m_fixed_iv_length);
        num = sourceIndex4 + this.m_fixed_iv_length;
      }
      if (num != length)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      byte[] nonce = new byte[this.m_fixed_iv_length + this.m_record_iv_length];
      nonce[0] = ~this.m_encryptNonce[0];
      nonce[1] = ~this.m_decryptNonce[1];
      encryptCipher.Init(nonce, macSize, (byte[]) null);
      decryptCipher.Init(nonce, macSize, (byte[]) null);
    }
  }

  public virtual int GetCiphertextDecodeLimit(int plaintextLimit)
  {
    return plaintextLimit + (this.m_decryptUseInnerPlaintext ? 1 : 0) + this.m_macSize + this.m_record_iv_length;
  }

  public virtual int GetCiphertextEncodeLimit(int plaintextLength, int plaintextLimit)
  {
    plaintextLimit = Math.Min(plaintextLength, plaintextLimit);
    return plaintextLimit + (this.m_encryptUseInnerPlaintext ? 1 : 0) + this.m_macSize + this.m_record_iv_length;
  }

  public virtual int GetPlaintextLimit(int ciphertextLimit)
  {
    return this.GetPlaintextEncodeLimit(ciphertextLimit);
  }

  public virtual int GetPlaintextDecodeLimit(int ciphertextLimit)
  {
    return ciphertextLimit - this.m_macSize - this.m_record_iv_length - (this.m_decryptUseInnerPlaintext ? 1 : 0);
  }

  public virtual int GetPlaintextEncodeLimit(int ciphertextLimit)
  {
    return ciphertextLimit - this.m_macSize - this.m_record_iv_length - (this.m_encryptUseInnerPlaintext ? 1 : 0);
  }

  public virtual TlsEncodeResult EncodePlaintext(
    long seqNo,
    short contentType,
    ProtocolVersion recordVersion,
    int headerAllocation,
    byte[] plaintext,
    int plaintextOffset,
    int plaintextLength)
  {
    byte[] numArray1 = new byte[this.m_encryptNonce.Length + this.m_record_iv_length];
    switch (this.m_nonceMode)
    {
      case 1:
        Array.Copy((Array) this.m_encryptNonce, 0, (Array) numArray1, 0, this.m_encryptNonce.Length);
        TlsUtilities.WriteUint64(seqNo, numArray1, this.m_encryptNonce.Length);
        break;
      case 2:
        TlsUtilities.WriteUint64(seqNo, numArray1, numArray1.Length - 8);
        for (int index = 0; index < this.m_encryptNonce.Length; ++index)
          numArray1[index] ^= this.m_encryptNonce[index];
        break;
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
    int num1 = plaintextLength + (this.m_encryptUseInnerPlaintext ? 1 : 0);
    int ciphertextLength = this.m_record_iv_length + this.m_encryptCipher.GetOutputSize(num1);
    byte[] numArray2 = new byte[headerAllocation + ciphertextLength];
    int num2 = headerAllocation;
    if (this.m_record_iv_length != 0)
    {
      Array.Copy((Array) numArray1, numArray1.Length - this.m_record_iv_length, (Array) numArray2, num2, this.m_record_iv_length);
      num2 += this.m_record_iv_length;
    }
    short recordType = contentType;
    if (this.m_encryptUseInnerPlaintext)
      recordType = this.m_isTlsV13 ? (short) 23 : (short) 25;
    byte[] additionalData = this.GetAdditionalData(seqNo, recordType, recordVersion, ciphertextLength, num1, this.m_encryptConnectionID);
    int num3;
    try
    {
      Array.Copy((Array) plaintext, plaintextOffset, (Array) numArray2, num2, plaintextLength);
      if (this.m_encryptUseInnerPlaintext)
        numArray2[num2 + plaintextLength] = (byte) contentType;
      this.m_encryptCipher.Init(numArray1, this.m_macSize, additionalData);
      num3 = num2 + this.m_encryptCipher.DoFinal(numArray2, num2, num1, numArray2, num2);
    }
    catch (IOException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new TlsFatalAlert((short) 80 /*0x50*/, ex);
    }
    if (num3 != numArray2.Length)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    return new TlsEncodeResult(numArray2, 0, numArray2.Length, recordType);
  }

  public virtual TlsDecodeResult DecodeCiphertext(
    long seqNo,
    short recordType,
    ProtocolVersion recordVersion,
    byte[] ciphertext,
    int ciphertextOffset,
    int ciphertextLength)
  {
    if (this.GetPlaintextDecodeLimit(ciphertextLength) < 0)
      throw new TlsFatalAlert((short) 50);
    byte[] numArray = new byte[this.m_decryptNonce.Length + this.m_record_iv_length];
    switch (this.m_nonceMode)
    {
      case 1:
        Array.Copy((Array) this.m_decryptNonce, 0, (Array) numArray, 0, this.m_decryptNonce.Length);
        Array.Copy((Array) ciphertext, ciphertextOffset, (Array) numArray, numArray.Length - this.m_record_iv_length, this.m_record_iv_length);
        break;
      case 2:
        TlsUtilities.WriteUint64(seqNo, numArray, numArray.Length - 8);
        for (int index = 0; index < this.m_decryptNonce.Length; ++index)
          numArray[index] ^= this.m_decryptNonce[index];
        break;
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
    int num1 = ciphertextOffset + this.m_record_iv_length;
    int inputLength = ciphertextLength - this.m_record_iv_length;
    int outputSize = this.m_decryptCipher.GetOutputSize(inputLength);
    byte[] additionalData = this.GetAdditionalData(seqNo, recordType, recordVersion, ciphertextLength, outputSize, this.m_decryptConnectionID);
    int num2;
    try
    {
      this.m_decryptCipher.Init(numArray, this.m_macSize, additionalData);
      num2 = this.m_decryptCipher.DoFinal(ciphertext, num1, inputLength, ciphertext, num1);
    }
    catch (TlsFatalAlert ex)
    {
      if ((short) 20 == ex.AlertDescription)
        this.m_decryptCipher.Reset();
      throw;
    }
    catch (IOException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      this.m_decryptCipher.Reset();
      throw new TlsFatalAlert((short) 20, ex);
    }
    if (num2 != outputSize)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    short contentType = recordType;
    int len = outputSize;
    if (this.m_decryptUseInnerPlaintext)
    {
      while (--len >= 0)
      {
        byte num3 = ciphertext[num1 + len];
        if (num3 != (byte) 0)
        {
          contentType = (short) ((int) num3 & (int) byte.MaxValue);
          goto label_22;
        }
      }
      throw new TlsFatalAlert((short) 10);
    }
label_22:
    return new TlsDecodeResult(ciphertext, num1, len, contentType);
  }

  public virtual void RekeyDecoder()
  {
    this.RekeyCipher(this.m_cryptoParams.SecurityParameters, this.m_decryptCipher, this.m_decryptNonce, !this.m_cryptoParams.IsServer);
  }

  public virtual void RekeyEncoder()
  {
    this.RekeyCipher(this.m_cryptoParams.SecurityParameters, this.m_encryptCipher, this.m_encryptNonce, this.m_cryptoParams.IsServer);
  }

  public virtual bool UsesOpaqueRecordType => this.m_isTlsV13;

  protected virtual byte[] GetAdditionalData(
    long seqNo,
    short recordType,
    ProtocolVersion recordVersion,
    int ciphertextLength,
    int plaintextLength)
  {
    if (this.m_isTlsV13)
    {
      byte[] buf = new byte[5];
      TlsUtilities.WriteUint8(recordType, buf, 0);
      TlsUtilities.WriteVersion(recordVersion, buf, 1);
      TlsUtilities.WriteUint16(ciphertextLength, buf, 3);
      return buf;
    }
    byte[] buf1 = new byte[13];
    TlsUtilities.WriteUint64(seqNo, buf1, 0);
    TlsUtilities.WriteUint8(recordType, buf1, 8);
    TlsUtilities.WriteVersion(recordVersion, buf1, 9);
    TlsUtilities.WriteUint16(plaintextLength, buf1, 11);
    return buf1;
  }

  protected virtual byte[] GetAdditionalData(
    long seqNo,
    short recordType,
    ProtocolVersion recordVersion,
    int ciphertextLength,
    int plaintextLength,
    byte[] connectionID)
  {
    if (Arrays.IsNullOrEmpty(connectionID))
      return this.GetAdditionalData(seqNo, recordType, recordVersion, ciphertextLength, plaintextLength);
    int length = connectionID.Length;
    byte[] additionalData = new byte[23 + length];
    TlsUtilities.WriteUint64(-1L, additionalData, 0);
    TlsUtilities.WriteUint8((short) 25, additionalData, 8);
    TlsUtilities.WriteUint8(length, additionalData, 9);
    TlsUtilities.WriteUint8((short) 25, additionalData, 10);
    TlsUtilities.WriteVersion(recordVersion, additionalData, 11);
    TlsUtilities.WriteUint64(seqNo, additionalData, 13);
    Array.Copy((Array) connectionID, 0, (Array) additionalData, 21, length);
    TlsUtilities.WriteUint16(plaintextLength, additionalData, 21 + length);
    return additionalData;
  }

  protected virtual void RekeyCipher(
    SecurityParameters securityParameters,
    TlsAeadCipherImpl cipher,
    byte[] nonce,
    bool serverSecret)
  {
    if (!this.m_isTlsV13)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.Setup13Cipher(cipher, nonce, (serverSecret ? securityParameters.TrafficSecretServer : securityParameters.TrafficSecretClient) ?? throw new TlsFatalAlert((short) 80 /*0x50*/), securityParameters.PrfCryptoHashAlgorithm);
  }

  protected virtual void Setup13Cipher(
    TlsAeadCipherImpl cipher,
    byte[] nonce,
    TlsSecret secret,
    int cryptoHashAlgorithm)
  {
    byte[] key = TlsCryptoUtilities.HkdfExpandLabel(secret, cryptoHashAlgorithm, "key", TlsUtilities.EmptyBytes, this.m_keySize).Extract();
    byte[] numArray = TlsCryptoUtilities.HkdfExpandLabel(secret, cryptoHashAlgorithm, "iv", TlsUtilities.EmptyBytes, this.m_fixed_iv_length).Extract();
    cipher.SetKey(key, 0, this.m_keySize);
    Array.Copy((Array) numArray, 0, (Array) nonce, 0, this.m_fixed_iv_length);
    numArray[0] ^= (byte) 128 /*0x80*/;
    cipher.Init(numArray, this.m_macSize, (byte[]) null);
  }

  private static int GetNonceMode(bool isTLSv13, int aeadType)
  {
    switch (aeadType)
    {
      case 1:
      case 3:
        return !isTLSv13 ? 1 : 2;
      case 2:
        return 2;
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }
}
