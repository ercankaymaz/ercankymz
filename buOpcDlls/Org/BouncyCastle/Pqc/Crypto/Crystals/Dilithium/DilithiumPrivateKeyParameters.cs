// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.DilithiumPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

public sealed class DilithiumPrivateKeyParameters : DilithiumKeyParameters
{
  internal byte[] rho;
  internal byte[] k;
  internal byte[] tr;
  internal byte[] s1;
  internal byte[] s2;
  internal byte[] t0;
  private byte[] t1;

  public DilithiumPrivateKeyParameters(
    DilithiumParameters parameters,
    byte[] rho,
    byte[] K,
    byte[] tr,
    byte[] s1,
    byte[] s2,
    byte[] t0,
    byte[] t1)
    : base(true, parameters)
  {
    this.rho = Arrays.Clone(rho);
    this.k = Arrays.Clone(K);
    this.tr = Arrays.Clone(tr);
    this.s1 = Arrays.Clone(s1);
    this.s2 = Arrays.Clone(s2);
    this.t0 = Arrays.Clone(t0);
    this.t1 = Arrays.Clone(t1);
  }

  public byte[] Rho => Arrays.Clone(this.rho);

  public byte[] K => Arrays.Clone(this.k);

  public byte[] Tr => Arrays.Clone(this.tr);

  public byte[] S1 => Arrays.Clone(this.s1);

  public byte[] S2 => Arrays.Clone(this.s2);

  public byte[] T0 => Arrays.Clone(this.t0);

  public byte[] T1 => this.t1;

  public byte[] GetEncoded()
  {
    return Arrays.ConcatenateAll(this.rho, this.k, this.tr, this.s1, this.s2, this.t0);
  }
}
