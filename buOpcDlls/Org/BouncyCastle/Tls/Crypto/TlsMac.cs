// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsMac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public interface TlsMac
{
  void SetKey(byte[] key, int keyOff, int keyLen);

  void Update(byte[] input, int inOff, int length);

  byte[] CalculateMac();

  void CalculateMac(byte[] output, int outOff);

  int MacLength { get; }

  void Reset();
}
