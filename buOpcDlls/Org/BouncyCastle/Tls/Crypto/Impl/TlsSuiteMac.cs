// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.TlsSuiteMac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public interface TlsSuiteMac
{
  int Size { get; }

  byte[] CalculateMac(long seqNo, short type, byte[] message, int offset, int length);

  byte[] CalculateMacConstantTime(
    long seqNo,
    short type,
    byte[] message,
    int offset,
    int length,
    int expectedLength,
    byte[] randomData);
}
