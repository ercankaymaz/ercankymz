// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.OptionalValidity
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class OptionalValidity : Asn1Encodable
{
  private readonly Time notBefore;
  private readonly Time notAfter;

  private OptionalValidity(Asn1Sequence seq)
  {
    foreach (Asn1TaggedObject taggedObject in seq)
    {
      if (taggedObject.TagNo == 0)
        this.notBefore = Time.GetInstance(taggedObject, true);
      else
        this.notAfter = Time.GetInstance(taggedObject, true);
    }
  }

  public static OptionalValidity GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OptionalValidity _:
        return (OptionalValidity) obj;
      default:
        return new OptionalValidity(Asn1Sequence.GetInstance(obj));
    }
  }

  public OptionalValidity(Time notBefore, Time notAfter)
  {
    this.notBefore = notBefore;
    this.notAfter = notAfter;
  }

  public virtual Time NotBefore => this.notBefore;

  public virtual Time NotAfter => this.notAfter;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.notBefore);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.notAfter);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
