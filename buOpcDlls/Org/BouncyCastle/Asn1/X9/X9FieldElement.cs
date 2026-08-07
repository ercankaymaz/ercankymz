// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.X9FieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class X9FieldElement : Asn1Encodable
{
  private ECFieldElement f;

  public X9FieldElement(ECFieldElement f) => this.f = f;

  public ECFieldElement Value => this.f;

  public override Asn1Object ToAsn1Object()
  {
    int byteLength = X9IntegerConverter.GetByteLength(this.f);
    return (Asn1Object) new DerOctetString(X9IntegerConverter.IntegerToBytes(this.f.ToBigInteger(), byteLength));
  }
}
