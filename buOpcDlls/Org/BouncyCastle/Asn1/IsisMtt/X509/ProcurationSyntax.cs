// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.X509.ProcurationSyntax
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.X509;

public class ProcurationSyntax : Asn1Encodable
{
  private readonly string country;
  private readonly DirectoryString typeOfSubstitution;
  private readonly GeneralName thirdPerson;
  private readonly IssuerSerial certRef;

  public static ProcurationSyntax GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case ProcurationSyntax _:
        return (ProcurationSyntax) obj;
      case Asn1Sequence seq:
        return new ProcurationSyntax(seq);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private ProcurationSyntax(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.Count >= 1 && seq.Count <= 3 ? seq.GetEnumerator() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    while (enumerator.MoveNext())
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) enumerator.Current);
      switch (instance.TagNo)
      {
        case 1:
          this.country = DerPrintableString.GetInstance(instance, true).GetString();
          continue;
        case 2:
          this.typeOfSubstitution = DirectoryString.GetInstance(instance, true);
          continue;
        case 3:
          Asn1Object asn1Object = instance.GetObject();
          if (asn1Object is Asn1TaggedObject)
          {
            this.thirdPerson = GeneralName.GetInstance((object) asn1Object);
            continue;
          }
          this.certRef = IssuerSerial.GetInstance((object) asn1Object);
          continue;
        default:
          throw new ArgumentException("Bad tag number: " + instance.TagNo.ToString());
      }
    }
  }

  public ProcurationSyntax(
    string country,
    DirectoryString typeOfSubstitution,
    IssuerSerial certRef)
  {
    this.country = country;
    this.typeOfSubstitution = typeOfSubstitution;
    this.thirdPerson = (GeneralName) null;
    this.certRef = certRef;
  }

  public ProcurationSyntax(
    string country,
    DirectoryString typeOfSubstitution,
    GeneralName thirdPerson)
  {
    this.country = country;
    this.typeOfSubstitution = typeOfSubstitution;
    this.thirdPerson = thirdPerson;
    this.certRef = (IssuerSerial) null;
  }

  public virtual string Country => this.country;

  public virtual DirectoryString TypeOfSubstitution => this.typeOfSubstitution;

  public virtual GeneralName ThirdPerson => this.thirdPerson;

  public virtual IssuerSerial CertRef => this.certRef;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    if (this.country != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 1, (Asn1Encodable) new DerPrintableString(this.country, true)));
    elementVector.AddOptionalTagged(true, 2, (Asn1Encodable) this.typeOfSubstitution);
    if (this.thirdPerson != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 3, (Asn1Encodable) this.thirdPerson));
    else
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 3, (Asn1Encodable) this.certRef));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
