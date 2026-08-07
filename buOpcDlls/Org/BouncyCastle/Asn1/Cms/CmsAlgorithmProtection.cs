// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.CmsAlgorithmProtection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class CmsAlgorithmProtection : Asn1Encodable
{
  public static readonly int Signature = 1;
  public static readonly int Mac = 2;
  private readonly AlgorithmIdentifier digestAlgorithm;
  private readonly AlgorithmIdentifier signatureAlgorithm;
  private readonly AlgorithmIdentifier macAlgorithm;

  public CmsAlgorithmProtection(
    AlgorithmIdentifier digestAlgorithm,
    int type,
    AlgorithmIdentifier algorithmIdentifier)
  {
    this.digestAlgorithm = digestAlgorithm != null && algorithmIdentifier != null ? digestAlgorithm : throw new ArgumentException("AlgorithmIdentifiers cannot be null");
    if (type == 1)
    {
      this.signatureAlgorithm = algorithmIdentifier;
      this.macAlgorithm = (AlgorithmIdentifier) null;
    }
    else
    {
      if (type != 2)
        throw new ArgumentException("Unknown type: " + type.ToString());
      this.signatureAlgorithm = (AlgorithmIdentifier) null;
      this.macAlgorithm = algorithmIdentifier;
    }
  }

  private CmsAlgorithmProtection(Asn1Sequence sequence)
  {
    this.digestAlgorithm = sequence.Count == 2 ? AlgorithmIdentifier.GetInstance((object) sequence[0]) : throw new ArgumentException("Sequence wrong size: One of signatureAlgorithm or macAlgorithm must be present");
    Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) sequence[1]);
    if (instance.TagNo == 1)
    {
      this.signatureAlgorithm = AlgorithmIdentifier.GetInstance(instance, false);
      this.macAlgorithm = (AlgorithmIdentifier) null;
    }
    else
    {
      if (instance.TagNo != 2)
        throw new ArgumentException("Unknown tag found: " + instance.TagNo.ToString());
      this.signatureAlgorithm = (AlgorithmIdentifier) null;
      this.macAlgorithm = AlgorithmIdentifier.GetInstance(instance, false);
    }
  }

  public static CmsAlgorithmProtection GetInstance(object obj)
  {
    if (obj == null)
      return (CmsAlgorithmProtection) null;
    return obj is CmsAlgorithmProtection algorithmProtection ? algorithmProtection : new CmsAlgorithmProtection(Asn1Sequence.GetInstance(obj));
  }

  public AlgorithmIdentifier DigestAlgorithm => this.digestAlgorithm;

  public AlgorithmIdentifier MacAlgorithm => this.macAlgorithm;

  public AlgorithmIdentifier SignatureAlgorithm => this.signatureAlgorithm;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.Add((Asn1Encodable) this.digestAlgorithm);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.signatureAlgorithm);
    elementVector.AddOptionalTagged(false, 2, (Asn1Encodable) this.macAlgorithm);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
