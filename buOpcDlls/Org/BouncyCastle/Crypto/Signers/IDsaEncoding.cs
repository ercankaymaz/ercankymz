// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.IDsaEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public interface IDsaEncoding
{
  BigInteger[] Decode(BigInteger n, byte[] encoding);

  byte[] Encode(BigInteger n, BigInteger r, BigInteger s);

  int GetMaxEncodingSize(BigInteger n);
}
