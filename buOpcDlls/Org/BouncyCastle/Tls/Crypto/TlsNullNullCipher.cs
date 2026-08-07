// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsNullNullCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public sealed class TlsNullNullCipher : TlsCipher
{
  public static readonly TlsNullNullCipher Instance = new TlsNullNullCipher();

  public int GetCiphertextDecodeLimit(int plaintextLimit) => plaintextLimit;

  public int GetCiphertextEncodeLimit(int plaintextLength, int plaintextLimit) => plaintextLength;

  public int GetPlaintextLimit(int ciphertextLimit) => ciphertextLimit;

  public TlsEncodeResult EncodePlaintext(
    long seqNo,
    short contentType,
    ProtocolVersion recordVersion,
    int headerAllocation,
    byte[] plaintext,
    int offset,
    int len)
  {
    byte[] numArray = new byte[headerAllocation + len];
    Array.Copy((Array) plaintext, offset, (Array) numArray, headerAllocation, len);
    return new TlsEncodeResult(numArray, 0, numArray.Length, contentType);
  }

  public TlsDecodeResult DecodeCiphertext(
    long seqNo,
    short recordType,
    ProtocolVersion recordVersion,
    byte[] ciphertext,
    int offset,
    int len)
  {
    return new TlsDecodeResult(ciphertext, offset, len, recordType);
  }

  public void RekeyDecoder() => throw new TlsFatalAlert((short) 80 /*0x50*/);

  public void RekeyEncoder() => throw new TlsFatalAlert((short) 80 /*0x50*/);

  public bool UsesOpaqueRecordType => false;
}
