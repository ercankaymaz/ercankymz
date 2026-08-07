// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Field.PrimeField
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.Field;

internal class PrimeField : IFiniteField
{
  protected readonly BigInteger characteristic;

  internal PrimeField(BigInteger characteristic) => this.characteristic = characteristic;

  public virtual BigInteger Characteristic => this.characteristic;

  public virtual int Dimension => 1;

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    return obj is PrimeField primeField && this.characteristic.Equals(primeField.characteristic);
  }

  public override int GetHashCode() => this.characteristic.GetHashCode();
}
