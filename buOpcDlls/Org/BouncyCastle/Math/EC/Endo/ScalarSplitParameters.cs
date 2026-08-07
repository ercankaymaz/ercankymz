// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Endo.ScalarSplitParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Endo;

public class ScalarSplitParameters
{
  protected readonly BigInteger m_v1A;
  protected readonly BigInteger m_v1B;
  protected readonly BigInteger m_v2A;
  protected readonly BigInteger m_v2B;
  protected readonly BigInteger m_g1;
  protected readonly BigInteger m_g2;
  protected readonly int m_bits;

  private static void CheckVector(BigInteger[] v, string name)
  {
    if (v == null || v.Length != 2 || v[0] == null || v[1] == null)
      throw new ArgumentException("Must consist of exactly 2 (non-null) values", name);
  }

  public ScalarSplitParameters(
    BigInteger[] v1,
    BigInteger[] v2,
    BigInteger g1,
    BigInteger g2,
    int bits)
  {
    ScalarSplitParameters.CheckVector(v1, nameof (v1));
    ScalarSplitParameters.CheckVector(v2, nameof (v2));
    this.m_v1A = v1[0];
    this.m_v1B = v1[1];
    this.m_v2A = v2[0];
    this.m_v2B = v2[1];
    this.m_g1 = g1;
    this.m_g2 = g2;
    this.m_bits = bits;
  }

  public virtual BigInteger V1A => this.m_v1A;

  public virtual BigInteger V1B => this.m_v1B;

  public virtual BigInteger V2A => this.m_v2A;

  public virtual BigInteger V2B => this.m_v2B;

  public virtual BigInteger G1 => this.m_g1;

  public virtual BigInteger G2 => this.m_g2;

  public virtual int Bits => this.m_bits;
}
