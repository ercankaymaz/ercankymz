// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public interface TlsCipher
{
  int GetCiphertextDecodeLimit(int plaintextLimit);

  int GetCiphertextEncodeLimit(int plaintextLength, int plaintextLimit);

  int GetPlaintextLimit(int ciphertextLimit);

  TlsEncodeResult EncodePlaintext(
    long seqNo,
    short contentType,
    ProtocolVersion recordVersion,
    int headerAllocation,
    byte[] plaintext,
    int offset,
    int len);

  TlsDecodeResult DecodeCiphertext(
    long seqNo,
    short recordType,
    ProtocolVersion recordVersion,
    byte[] ciphertext,
    int offset,
    int len);

  void RekeyDecoder();

  void RekeyEncoder();

  bool UsesOpaqueRecordType { get; }
}
