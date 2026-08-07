// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.Evidence
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class Evidence : Asn1Encodable, IAsn1Choice
{
  private TimeStampTokenEvidence tstEvidence;
  private Asn1Sequence otherEvidence;

  public Evidence(TimeStampTokenEvidence tstEvidence) => this.tstEvidence = tstEvidence;

  private Evidence(Asn1TaggedObject tagged)
  {
    if (tagged.TagNo == 0)
      this.tstEvidence = TimeStampTokenEvidence.GetInstance(tagged, false);
    else
      this.otherEvidence = tagged.TagNo == 2 ? Asn1Sequence.GetInstance(tagged, false) : throw new ArgumentException("unknown tag in Evidence", nameof (tagged));
  }

  public static Evidence GetInstance(object obj)
  {
    switch (obj)
    {
      case Evidence _:
        return (Evidence) obj;
      case Asn1TaggedObject _:
        return new Evidence(Asn1TaggedObject.GetInstance(obj));
      default:
        throw new ArgumentException("Unknown object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static Evidence GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return Evidence.GetInstance((object) obj.GetObject());
  }

  public virtual TimeStampTokenEvidence TstEvidence => this.tstEvidence;

  public override Asn1Object ToAsn1Object()
  {
    return this.tstEvidence != null ? (Asn1Object) new DerTaggedObject(false, 0, (Asn1Encodable) this.tstEvidence) : (Asn1Object) new DerTaggedObject(false, 2, (Asn1Encodable) this.otherEvidence);
  }
}
