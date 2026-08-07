// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.PolicyInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class PolicyInformation : Asn1Encodable
{
  private readonly DerObjectIdentifier policyIdentifier;
  private readonly Asn1Sequence policyQualifiers;

  private PolicyInformation(Asn1Sequence seq)
  {
    this.policyIdentifier = seq.Count >= 1 && seq.Count <= 2 ? DerObjectIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    if (seq.Count <= 1)
      return;
    this.policyQualifiers = Asn1Sequence.GetInstance((object) seq[1]);
  }

  public PolicyInformation(DerObjectIdentifier policyIdentifier)
  {
    this.policyIdentifier = policyIdentifier;
  }

  public PolicyInformation(DerObjectIdentifier policyIdentifier, Asn1Sequence policyQualifiers)
  {
    this.policyIdentifier = policyIdentifier;
    this.policyQualifiers = policyQualifiers;
  }

  public static PolicyInformation GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case PolicyInformation _:
        return (PolicyInformation) obj;
      default:
        return new PolicyInformation(Asn1Sequence.GetInstance(obj));
    }
  }

  public DerObjectIdentifier PolicyIdentifier => this.policyIdentifier;

  public Asn1Sequence PolicyQualifiers => this.policyQualifiers;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.policyIdentifier);
    elementVector.AddOptional((Asn1Encodable) this.policyQualifiers);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
