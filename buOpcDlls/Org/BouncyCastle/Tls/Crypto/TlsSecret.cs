// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsSecret
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public interface TlsSecret
{
  byte[] CalculateHmac(int cryptoHashAlgorithm, byte[] buf, int off, int len);

  TlsSecret DeriveUsingPrf(int prfAlgorithm, string label, byte[] seed, int length);

  void Destroy();

  byte[] Encrypt(TlsEncryptor encryptor);

  byte[] Extract();

  TlsSecret HkdfExpand(int cryptoHashAlgorithm, byte[] info, int length);

  TlsSecret HkdfExtract(int cryptoHashAlgorithm, TlsSecret ikm);

  bool IsAlive();

  int Length { get; }
}
