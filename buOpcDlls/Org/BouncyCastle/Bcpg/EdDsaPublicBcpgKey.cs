// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.EdDsaPublicBcpgKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public sealed class EdDsaPublicBcpgKey : ECPublicBcpgKey
{
  internal EdDsaPublicBcpgKey(BcpgInputStream bcpgIn)
    : base(bcpgIn)
  {
  }

  public EdDsaPublicBcpgKey(DerObjectIdentifier oid, ECPoint point)
    : base(oid, point)
  {
  }

  public EdDsaPublicBcpgKey(DerObjectIdentifier oid, BigInteger encodedPoint)
    : base(oid, encodedPoint)
  {
  }
}
