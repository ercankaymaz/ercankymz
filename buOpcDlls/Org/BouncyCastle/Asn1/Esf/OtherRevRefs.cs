// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.OtherRevRefs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class OtherRevRefs : Asn1Encodable
{
  private readonly DerObjectIdentifier otherRevRefType;
  private readonly Asn1Object otherRevRefs;

  public static OtherRevRefs GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OtherRevRefs _:
        return (OtherRevRefs) obj;
      case Asn1Sequence _:
        return new OtherRevRefs((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in 'OtherRevRefs' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private OtherRevRefs(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.otherRevRefType = seq.Count == 2 ? (DerObjectIdentifier) seq[0].ToAsn1Object() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.otherRevRefs = seq[1].ToAsn1Object();
  }

  public OtherRevRefs(DerObjectIdentifier otherRevRefType, Asn1Encodable otherRevRefs)
  {
    if (otherRevRefType == null)
      throw new ArgumentNullException(nameof (otherRevRefType));
    if (otherRevRefs == null)
      throw new ArgumentNullException(nameof (otherRevRefs));
    this.otherRevRefType = otherRevRefType;
    this.otherRevRefs = otherRevRefs.ToAsn1Object();
  }

  public DerObjectIdentifier OtherRevRefType => this.otherRevRefType;

  public Asn1Object OtherRevRefsObject => this.otherRevRefs;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.otherRevRefType, (Asn1Encodable) this.otherRevRefs);
  }
}
