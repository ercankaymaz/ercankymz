// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.TlsBlockCipherImpl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public interface TlsBlockCipherImpl
{
  void SetKey(byte[] key, int keyOff, int keyLen);

  void Init(byte[] iv, int ivOff, int ivLen);

  int DoFinal(byte[] input, int inputOffset, int inputLength, byte[] output, int outputOffset);

  int GetBlockSize();
}
