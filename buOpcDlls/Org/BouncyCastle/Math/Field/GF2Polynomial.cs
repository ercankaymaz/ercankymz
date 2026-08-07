// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Field.GF2Polynomial
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Math.Field;

internal class GF2Polynomial : IPolynomial
{
  protected readonly int[] exponents;

  internal GF2Polynomial(int[] exponents) => this.exponents = Arrays.Clone(exponents);

  public virtual int Degree => this.exponents[this.exponents.Length - 1];

  public virtual int[] GetExponentsPresent() => Arrays.Clone(this.exponents);

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    return obj is GF2Polynomial gf2Polynomial && Arrays.AreEqual(this.exponents, gf2Polynomial.exponents);
  }

  public override int GetHashCode() => Arrays.GetHashCode(this.exponents);
}
