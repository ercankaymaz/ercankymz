// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.RsaPublicBcpgKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class RsaPublicBcpgKey : BcpgObject, IBcpgKey
{
  private readonly MPInteger n;
  private readonly MPInteger e;

  public RsaPublicBcpgKey(BcpgInputStream bcpgIn)
  {
    this.n = new MPInteger(bcpgIn);
    this.e = new MPInteger(bcpgIn);
  }

  public RsaPublicBcpgKey(BigInteger n, BigInteger e)
  {
    this.n = new MPInteger(n);
    this.e = new MPInteger(e);
  }

  public BigInteger PublicExponent => this.e.Value;

  public BigInteger Modulus => this.n.Value;

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
    bcpgOut.WriteObjects((BcpgObject) this.n, (BcpgObject) this.e);
  }
}
