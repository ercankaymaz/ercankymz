// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.CrlNumber
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class CrlNumber(BigInteger number) : DerInteger(number)
{
  public BigInteger Number => this.PositiveValue;

  public override string ToString() => "CRLNumber: " + this.Number?.ToString();
}
