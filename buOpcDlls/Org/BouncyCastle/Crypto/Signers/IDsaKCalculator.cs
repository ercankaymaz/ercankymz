// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.IDsaKCalculator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public interface IDsaKCalculator
{
  bool IsDeterministic { get; }

  void Init(BigInteger n, SecureRandom random);

  void Init(BigInteger n, BigInteger d, byte[] message);

  BigInteger NextK();
}
