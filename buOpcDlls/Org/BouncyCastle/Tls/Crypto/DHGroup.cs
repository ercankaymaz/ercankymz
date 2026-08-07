// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.DHGroup
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public class DHGroup
{
  private readonly BigInteger g;
  private readonly BigInteger p;
  private readonly BigInteger q;
  private readonly int l;

  public DHGroup(BigInteger p, BigInteger q, BigInteger g, int l)
  {
    this.p = p;
    this.g = g;
    this.q = q;
    this.l = l;
  }

  public virtual BigInteger G => this.g;

  public virtual int L => this.l;

  public virtual BigInteger P => this.p;

  public virtual BigInteger Q => this.q;
}
