// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.PolicyMappings
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class PolicyMappings : Asn1Encodable
{
  private readonly Asn1Sequence seq;

  public PolicyMappings(Asn1Sequence seq) => this.seq = seq;

  public PolicyMappings(IDictionary<string, string> mappings)
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(mappings.Count);
    foreach (KeyValuePair<string, string> mapping in (IEnumerable<KeyValuePair<string, string>>) mappings)
    {
      string key = mapping.Key;
      string identifier = mapping.Value;
      elementVector.Add((Asn1Encodable) new DerSequence((Asn1Encodable) new DerObjectIdentifier(key), (Asn1Encodable) new DerObjectIdentifier(identifier)));
    }
    this.seq = (Asn1Sequence) new DerSequence(elementVector);
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.seq;
}
