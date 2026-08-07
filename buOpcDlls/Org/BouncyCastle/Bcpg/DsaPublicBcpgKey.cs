// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.DsaPublicBcpgKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class DsaPublicBcpgKey : BcpgObject, IBcpgKey
{
  private readonly MPInteger p;
  private readonly MPInteger q;
  private readonly MPInteger g;
  private readonly MPInteger y;

  public DsaPublicBcpgKey(BcpgInputStream bcpgIn)
  {
    this.p = new MPInteger(bcpgIn);
    this.q = new MPInteger(bcpgIn);
    this.g = new MPInteger(bcpgIn);
    this.y = new MPInteger(bcpgIn);
  }

  public DsaPublicBcpgKey(BigInteger p, BigInteger q, BigInteger g, BigInteger y)
  {
    this.p = new MPInteger(p);
    this.q = new MPInteger(q);
    this.g = new MPInteger(g);
    this.y = new MPInteger(y);
  }

  public string Format => "PGP";

  public override byte[] GetEncoded()
  {
    try
    {
      return base.GetEncoded();
    }
    catch (Exception ex)
    {
      return (byte[]) null;
    }
  }

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WriteObjects((BcpgObject) this.p, (BcpgObject) this.q, (BcpgObject) this.g, (BcpgObject) this.y);
  }

  public BigInteger G => this.g.Value;

  public BigInteger P => this.p.Value;

  public BigInteger Q => this.q.Value;

  public BigInteger Y => this.y.Value;
}
