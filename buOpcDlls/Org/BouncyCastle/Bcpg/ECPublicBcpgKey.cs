// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.ECPublicBcpgKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public abstract class ECPublicBcpgKey : BcpgObject, IBcpgKey
{
  internal DerObjectIdentifier oid;
  internal BigInteger point;

  protected ECPublicBcpgKey(BcpgInputStream bcpgIn)
  {
    this.oid = DerObjectIdentifier.GetInstance((object) Asn1Object.FromByteArray(ECPublicBcpgKey.ReadBytesOfEncodedLength(bcpgIn)));
    this.point = new MPInteger(bcpgIn).Value;
  }

  protected ECPublicBcpgKey(DerObjectIdentifier oid, ECPoint point)
  {
    this.point = MPInteger.ToMpiBigInteger(point);
    this.oid = oid;
  }

  protected ECPublicBcpgKey(DerObjectIdentifier oid, BigInteger encodedPoint)
  {
    this.point = encodedPoint;
    this.oid = oid;
  }

  public string Format => "PGP";

  public override byte[] GetEncoded()
  {
    try
    {
      return base.GetEncoded();
    }
    catch (IOException ex)
    {
      return (byte[]) null;
    }
  }

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    byte[] encoded = this.oid.GetEncoded();
    bcpgOut.Write(encoded, 1, encoded.Length - 1);
    MPInteger mpInteger = new MPInteger(this.point);
    bcpgOut.WriteObject((BcpgObject) mpInteger);
  }

  public virtual BigInteger EncodedPoint => this.point;

  public virtual DerObjectIdentifier CurveOid => this.oid;

  protected static byte[] ReadBytesOfEncodedLength(BcpgInputStream bcpgIn)
  {
    int num = bcpgIn.ReadByte();
    if (num < 0)
      throw new EndOfStreamException();
    if (num == 0 || num == (int) byte.MaxValue)
      throw new IOException("future extensions not yet implemented");
    byte[] buffer = num <= (int) sbyte.MaxValue ? new byte[num + 2] : throw new IOException("unsupported OID");
    bcpgIn.ReadFully(buffer, 2, buffer.Length - 2);
    buffer[0] = (byte) 6;
    buffer[1] = (byte) num;
    return buffer;
  }
}
