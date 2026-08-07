// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.Qualified.SemanticsInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509.Qualified;

public class SemanticsInformation : Asn1Encodable
{
  private readonly DerObjectIdentifier semanticsIdentifier;
  private readonly GeneralName[] nameRegistrationAuthorities;

  public static SemanticsInformation GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case SemanticsInformation _:
        return (SemanticsInformation) obj;
      case Asn1Sequence _:
        return new SemanticsInformation(Asn1Sequence.GetInstance(obj));
      default:
        throw new ArgumentException("unknown object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public SemanticsInformation(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.Count >= 1 ? seq.GetEnumerator() : throw new ArgumentException("no objects in SemanticsInformation");
    enumerator.MoveNext();
    Asn1Encodable current = enumerator.Current;
    if (current is DerObjectIdentifier objectIdentifier)
    {
      this.semanticsIdentifier = objectIdentifier;
      current = !enumerator.MoveNext() ? (Asn1Encodable) null : enumerator.Current;
    }
    if (current == null)
      return;
    Asn1Sequence instance = Asn1Sequence.GetInstance((object) current);
    this.nameRegistrationAuthorities = new GeneralName[instance.Count];
    for (int index = 0; index < instance.Count; ++index)
      this.nameRegistrationAuthorities[index] = GeneralName.GetInstance((object) instance[index]);
  }

  public SemanticsInformation(DerObjectIdentifier semanticsIdentifier, GeneralName[] generalNames)
  {
    this.semanticsIdentifier = semanticsIdentifier;
    this.nameRegistrationAuthorities = generalNames;
  }

  public SemanticsInformation(DerObjectIdentifier semanticsIdentifier)
  {
    this.semanticsIdentifier = semanticsIdentifier;
  }

  public SemanticsInformation(GeneralName[] generalNames)
  {
    this.nameRegistrationAuthorities = generalNames;
  }

  public DerObjectIdentifier SemanticsIdentifier => this.semanticsIdentifier;

  public GeneralName[] GetNameRegistrationAuthorities() => this.nameRegistrationAuthorities;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptional((Asn1Encodable) this.semanticsIdentifier);
    if (this.nameRegistrationAuthorities != null)
      elementVector.Add((Asn1Encodable) new DerSequence((Asn1Encodable[]) this.nameRegistrationAuthorities));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
