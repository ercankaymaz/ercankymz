// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.SigI.PersonalData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509.SigI;

public class PersonalData : Asn1Encodable
{
  private readonly NameOrPseudonym nameOrPseudonym;
  private readonly BigInteger nameDistinguisher;
  private readonly Asn1GeneralizedTime dateOfBirth;
  private readonly DirectoryString placeOfBirth;
  private readonly string gender;
  private readonly DirectoryString postalAddress;

  public static PersonalData GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case PersonalData _:
        return (PersonalData) obj;
      case Asn1Sequence _:
        return new PersonalData((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private PersonalData(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.Count >= 1 ? seq.GetEnumerator() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    enumerator.MoveNext();
    this.nameOrPseudonym = NameOrPseudonym.GetInstance((object) enumerator.Current);
    while (enumerator.MoveNext())
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) enumerator.Current);
      switch (instance.TagNo)
      {
        case 0:
          this.nameDistinguisher = DerInteger.GetInstance(instance, false).Value;
          continue;
        case 1:
          this.dateOfBirth = Asn1GeneralizedTime.GetInstance(instance, false);
          continue;
        case 2:
          this.placeOfBirth = DirectoryString.GetInstance(instance, true);
          continue;
        case 3:
          this.gender = DerPrintableString.GetInstance(instance, false).GetString();
          continue;
        case 4:
          this.postalAddress = DirectoryString.GetInstance(instance, true);
          continue;
        default:
          throw new ArgumentException("Bad tag number: " + instance.TagNo.ToString());
      }
    }
  }

  public PersonalData(
    NameOrPseudonym nameOrPseudonym,
    BigInteger nameDistinguisher,
    Asn1GeneralizedTime dateOfBirth,
    DirectoryString placeOfBirth,
    string gender,
    DirectoryString postalAddress)
  {
    this.nameOrPseudonym = nameOrPseudonym;
    this.dateOfBirth = dateOfBirth;
    this.gender = gender;
    this.nameDistinguisher = nameDistinguisher;
    this.postalAddress = postalAddress;
    this.placeOfBirth = placeOfBirth;
  }

  public NameOrPseudonym NameOrPseudonym => this.nameOrPseudonym;

  public BigInteger NameDistinguisher => this.nameDistinguisher;

  public Asn1GeneralizedTime DateOfBirth => this.dateOfBirth;

  public DirectoryString PlaceOfBirth => this.placeOfBirth;

  public string Gender => this.gender;

  public DirectoryString PostalAddress => this.postalAddress;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.nameOrPseudonym);
    if (this.nameDistinguisher != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 0, (Asn1Encodable) new DerInteger(this.nameDistinguisher)));
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.dateOfBirth);
    elementVector.AddOptionalTagged(true, 2, (Asn1Encodable) this.placeOfBirth);
    if (this.gender != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 3, (Asn1Encodable) new DerPrintableString(this.gender, true)));
    elementVector.AddOptionalTagged(true, 4, (Asn1Encodable) this.postalAddress);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
