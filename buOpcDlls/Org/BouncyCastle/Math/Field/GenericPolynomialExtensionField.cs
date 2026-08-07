// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Field.GenericPolynomialExtensionField
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Math.Field;

internal class GenericPolynomialExtensionField : 
  IPolynomialExtensionField,
  IExtensionField,
  IFiniteField
{
  protected readonly IFiniteField subfield;
  protected readonly IPolynomial minimalPolynomial;

  internal GenericPolynomialExtensionField(IFiniteField subfield, IPolynomial polynomial)
  {
    this.subfield = subfield;
    this.minimalPolynomial = polynomial;
  }

  public virtual BigInteger Characteristic => this.subfield.Characteristic;

  public virtual int Dimension => this.subfield.Dimension * this.minimalPolynomial.Degree;

  public virtual IFiniteField Subfield => this.subfield;

  public virtual int Degree => this.minimalPolynomial.Degree;

  public virtual IPolynomial MinimalPolynomial => this.minimalPolynomial;

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    return obj is GenericPolynomialExtensionField polynomialExtensionField && this.subfield.Equals((object) polynomialExtensionField.subfield) && this.minimalPolynomial.Equals((object) polynomialExtensionField.minimalPolynomial);
  }

  public override int GetHashCode()
  {
    return this.subfield.GetHashCode() ^ Integers.RotateLeft(this.minimalPolynomial.GetHashCode(), 16 /*0x10*/);
  }
}
