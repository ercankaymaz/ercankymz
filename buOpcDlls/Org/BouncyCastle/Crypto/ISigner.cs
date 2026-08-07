// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.ISigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto;

public interface ISigner
{
  string AlgorithmName { get; }

  void Init(bool forSigning, ICipherParameters parameters);

  void Update(byte input);

  void BlockUpdate(byte[] input, int inOff, int inLen);

  int GetMaxSignatureSize();

  byte[] GenerateSignature();

  bool VerifySignature(byte[] signature);

  void Reset();
}
