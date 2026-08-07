// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.ECDsaPublicBcpgKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class ECDsaPublicBcpgKey : ECPublicBcpgKey
{
  protected internal ECDsaPublicBcpgKey(BcpgInputStream bcpgIn)
    : base(bcpgIn)
  {
  }

  public ECDsaPublicBcpgKey(DerObjectIdentifier oid, ECPoint point)
    : base(oid, point)
  {
  }

  public ECDsaPublicBcpgKey(DerObjectIdentifier oid, BigInteger encodedPoint)
    : base(oid, encodedPoint)
  {
  }
}
