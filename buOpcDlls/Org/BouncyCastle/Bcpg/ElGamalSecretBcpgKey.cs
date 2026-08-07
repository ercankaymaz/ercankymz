// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.ElGamalSecretBcpgKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class ElGamalSecretBcpgKey : BcpgObject, IBcpgKey
{
  internal MPInteger x;

  public ElGamalSecretBcpgKey(BcpgInputStream bcpgIn) => this.x = new MPInteger(bcpgIn);

  public ElGamalSecretBcpgKey(BigInteger x) => this.x = new MPInteger(x);

  public string Format => "PGP";

  public BigInteger X => this.x.Value;

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

  public override void Encode(BcpgOutputStream bcpgOut) => bcpgOut.WriteObject((BcpgObject) this.x);
}
