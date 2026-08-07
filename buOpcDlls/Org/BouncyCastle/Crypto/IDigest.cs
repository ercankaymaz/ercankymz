// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.IDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto;

public interface IDigest
{
  string AlgorithmName { get; }

  int GetDigestSize();

  int GetByteLength();

  void Update(byte input);

  void BlockUpdate(byte[] input, int inOff, int inLen);

  int DoFinal(byte[] output, int outOff);

  void Reset();
}
