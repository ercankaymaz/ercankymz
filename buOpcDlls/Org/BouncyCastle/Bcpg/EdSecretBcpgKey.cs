// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.EdSecretBcpgKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public sealed class EdSecretBcpgKey : BcpgObject, IBcpgKey
{
  internal readonly MPInteger m_x;

  public EdSecretBcpgKey(BcpgInputStream bcpgIn) => this.m_x = new MPInteger(bcpgIn);

  public EdSecretBcpgKey(BigInteger x) => this.m_x = new MPInteger(x);

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
    bcpgOut.WriteObject((BcpgObject) this.m_x);
  }

  public BigInteger X => this.m_x.Value;
}
