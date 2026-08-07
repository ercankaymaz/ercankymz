// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.IDsa
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public interface IDsa
{
  string AlgorithmName { get; }

  void Init(bool forSigning, ICipherParameters parameters);

  BigInteger[] GenerateSignature(byte[] message);

  BigInteger Order { get; }

  bool VerifySignature(byte[] message, BigInteger r, BigInteger s);
}
