// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.IBasicAgreement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public interface IBasicAgreement
{
  void Init(ICipherParameters parameters);

  int GetFieldSize();

  BigInteger CalculateAgreement(ICipherParameters pubKey);
}
