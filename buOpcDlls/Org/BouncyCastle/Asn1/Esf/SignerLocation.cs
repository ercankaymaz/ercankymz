// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.SignerLocation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X500;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class SignerLocation : Asn1Encodable
{
  private readonly DirectoryString countryName;
  private readonly DirectoryString localityName;
  private readonly Asn1Sequence postalAddress;

  public SignerLocation(Asn1Sequence seq)
  {
    foreach (Asn1TaggedObject taggedObject in seq)
    {
      switch (taggedObject.TagNo)
      {
        case 0:
          this.countryName = DirectoryString.GetInstance(taggedObject, true);
          continue;
        case 1:
          this.localityName = DirectoryString.GetInstance(taggedObject, true);
          continue;
        case 2:
          bool declaredExplicit = taggedObject.IsExplicit();
          this.postalAddress = Asn1Sequence.GetInstance(taggedObject, declaredExplicit);
          if (this.postalAddress != null && this.postalAddress.Count > 6)
            throw new ArgumentException("postal address must contain less than 6 strings");
          continue;
        default:
          throw new ArgumentException("illegal tag");
      }
    }
  }

  private SignerLocation(
    DirectoryString countryName,
    DirectoryString localityName,
    Asn1Sequence postalAddress)
  {
    if (postalAddress != null && postalAddress.Count > 6)
      throw new ArgumentException("postal address must contain less than 6 strings");
    this.countryName = countryName;
    this.localityName = localityName;
    this.postalAddress = postalAddress;
  }

  public SignerLocation(
    DirectoryString countryName,
    DirectoryString localityName,
    DirectoryString[] postalAddress)
    : this(countryName, localityName, (Asn1Sequence) new DerSequence((Asn1Encodable[]) postalAddress))
  {
  }

  public SignerLocation(
    DerUtf8String countryName,
    DerUtf8String localityName,
    Asn1Sequence postalAddress)
    : this(DirectoryString.GetInstance((object) countryName), DirectoryString.GetInstance((object) localityName), postalAddress)
  {
  }

  public static SignerLocation GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case SignerLocation _:
        return (SignerLocation) obj;
      default:
        return new SignerLocation(Asn1Sequence.GetInstance(obj));
    }
  }

  public DirectoryString Country => this.countryName;

  public DirectoryString Locality => this.localityName;

  public DirectoryString[] GetPostal()
  {
    return this.postalAddress == null ? (DirectoryString[]) null : this.postalAddress.MapElements<DirectoryString>((Func<Asn1Encodable, DirectoryString>) (element => DirectoryString.GetInstance((object) element.ToAsn1Object())));
  }

  public Asn1Sequence PostalAddress => this.postalAddress;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.countryName);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.localityName);
    elementVector.AddOptionalTagged(true, 2, (Asn1Encodable) this.postalAddress);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
