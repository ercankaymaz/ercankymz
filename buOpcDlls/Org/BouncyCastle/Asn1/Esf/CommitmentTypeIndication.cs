// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.CommitmentTypeIndication
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class CommitmentTypeIndication : Asn1Encodable
{
  private readonly DerObjectIdentifier commitmentTypeId;
  private readonly Asn1Sequence commitmentTypeQualifier;

  public static CommitmentTypeIndication GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case CommitmentTypeIndication _:
        return (CommitmentTypeIndication) obj;
      case Asn1Sequence _:
        return new CommitmentTypeIndication((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in 'CommitmentTypeIndication' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public CommitmentTypeIndication(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.commitmentTypeId = seq.Count >= 1 && seq.Count <= 2 ? (DerObjectIdentifier) seq[0].ToAsn1Object() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    if (seq.Count <= 1)
      return;
    this.commitmentTypeQualifier = (Asn1Sequence) seq[1].ToAsn1Object();
  }

  public CommitmentTypeIndication(DerObjectIdentifier commitmentTypeId)
    : this(commitmentTypeId, (Asn1Sequence) null)
  {
  }

  public CommitmentTypeIndication(
    DerObjectIdentifier commitmentTypeId,
    Asn1Sequence commitmentTypeQualifier)
  {
    this.commitmentTypeId = commitmentTypeId != null ? commitmentTypeId : throw new ArgumentNullException(nameof (commitmentTypeId));
    if (commitmentTypeQualifier == null)
      return;
    this.commitmentTypeQualifier = commitmentTypeQualifier;
  }

  public DerObjectIdentifier CommitmentTypeID => this.commitmentTypeId;

  public Asn1Sequence CommitmentTypeQualifier => this.commitmentTypeQualifier;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.commitmentTypeId);
    elementVector.AddOptional((Asn1Encodable) this.commitmentTypeQualifier);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
