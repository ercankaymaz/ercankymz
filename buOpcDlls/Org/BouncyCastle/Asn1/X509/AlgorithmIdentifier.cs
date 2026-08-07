// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AlgorithmIdentifier : Asn1Encodable
{
  private readonly DerObjectIdentifier algorithm;
  private readonly Asn1Encodable parameters;

  public static AlgorithmIdentifier GetInstance(object obj)
  {
    if (obj == null)
      return (AlgorithmIdentifier) null;
    return obj is AlgorithmIdentifier algorithmIdentifier ? algorithmIdentifier : new AlgorithmIdentifier(Asn1Sequence.GetInstance(obj));
  }

  public static AlgorithmIdentifier GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return AlgorithmIdentifier.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public AlgorithmIdentifier(DerObjectIdentifier algorithm) => this.algorithm = algorithm;

  public AlgorithmIdentifier(DerObjectIdentifier algorithm, Asn1Encodable parameters)
  {
    this.algorithm = algorithm;
    this.parameters = parameters;
  }

  internal AlgorithmIdentifier(Asn1Sequence seq)
  {
    this.algorithm = seq.Count >= 1 && seq.Count <= 2 ? DerObjectIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    this.parameters = seq.Count < 2 ? (Asn1Encodable) null : seq[1];
  }

  public virtual DerObjectIdentifier Algorithm => this.algorithm;

  public virtual Asn1Encodable Parameters => this.parameters;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.algorithm);
    elementVector.AddOptional(this.parameters);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
