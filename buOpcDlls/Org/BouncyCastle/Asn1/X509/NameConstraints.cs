// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.NameConstraints
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class NameConstraints : Asn1Encodable
{
  private Asn1Sequence m_permitted;
  private Asn1Sequence m_excluded;

  public static NameConstraints GetInstance(object obj)
  {
    if (obj == null)
      return (NameConstraints) null;
    return obj is NameConstraints nameConstraints ? nameConstraints : new NameConstraints(Asn1Sequence.GetInstance(obj));
  }

  public static NameConstraints GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return NameConstraints.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  [Obsolete("Use 'GetInstance' instead")]
  public NameConstraints(Asn1Sequence seq)
  {
    foreach (Asn1TaggedObject taggedObject in seq)
    {
      switch (taggedObject.TagNo)
      {
        case 0:
          this.m_permitted = Asn1Sequence.GetInstance(taggedObject, false);
          continue;
        case 1:
          this.m_excluded = Asn1Sequence.GetInstance(taggedObject, false);
          continue;
        default:
          continue;
      }
    }
  }

  public NameConstraints(IList<GeneralSubtree> permitted, IList<GeneralSubtree> excluded)
  {
    if (permitted != null)
      this.m_permitted = (Asn1Sequence) this.CreateSequence(permitted);
    if (excluded == null)
      return;
    this.m_excluded = (Asn1Sequence) this.CreateSequence(excluded);
  }

  private DerSequence CreateSequence(IList<GeneralSubtree> subtrees)
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(subtrees.Count);
    foreach (GeneralSubtree subtree in (IEnumerable<GeneralSubtree>) subtrees)
      elementVector.Add((Asn1Encodable) subtree);
    return new DerSequence(elementVector);
  }

  public Asn1Sequence PermittedSubtrees => this.m_permitted;

  public Asn1Sequence ExcludedSubtrees => this.m_excluded;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.m_permitted);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.m_excluded);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
