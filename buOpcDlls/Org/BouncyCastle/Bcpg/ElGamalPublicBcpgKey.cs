// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.ElGamalPublicBcpgKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class ElGamalPublicBcpgKey : BcpgObject, IBcpgKey
{
  internal MPInteger p;
  internal MPInteger g;
  internal MPInteger y;

  public ElGamalPublicBcpgKey(BcpgInputStream bcpgIn)
  {
    this.p = new MPInteger(bcpgIn);
    this.g = new MPInteger(bcpgIn);
    this.y = new MPInteger(bcpgIn);
  }

  public ElGamalPublicBcpgKey(BigInteger p, BigInteger g, BigInteger y)
  {
    this.p = new MPInteger(p);
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

  public BigInteger P => this.p.Value;

  public BigInteger G => this.g.Value;

  public BigInteger Y => this.y.Value;

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WriteObjects((BcpgObject) this.p, (BcpgObject) this.g, (BcpgObject) this.y);
  }
}
