// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AuthorityInformationAccess
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AuthorityInformationAccess : Asn1Encodable
{
  private readonly AccessDescription[] descriptions;

  private static AccessDescription[] Copy(AccessDescription[] descriptions)
  {
    return (AccessDescription[]) descriptions.Clone();
  }

  public static AuthorityInformationAccess GetInstance(object obj)
  {
    if (obj == null)
      return (AuthorityInformationAccess) null;
    return obj is AuthorityInformationAccess informationAccess ? informationAccess : new AuthorityInformationAccess(Asn1Sequence.GetInstance(obj));
  }

  public static AuthorityInformationAccess FromExtensions(X509Extensions extensions)
  {
    return AuthorityInformationAccess.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.AuthorityInfoAccess));
  }

  private AuthorityInformationAccess(Asn1Sequence seq)
  {
    this.descriptions = seq.Count >= 1 ? new AccessDescription[seq.Count] : throw new ArgumentException("sequence may not be empty");
    for (int index = 0; index < seq.Count; ++index)
      this.descriptions[index] = AccessDescription.GetInstance((object) seq[index]);
  }

  public AuthorityInformationAccess(AccessDescription description)
  {
    this.descriptions = new AccessDescription[1]
    {
      description
    };
  }

  public AuthorityInformationAccess(AccessDescription[] descriptions)
  {
    this.descriptions = AuthorityInformationAccess.Copy(descriptions);
  }

  public AuthorityInformationAccess(DerObjectIdentifier oid, GeneralName location)
    : this(new AccessDescription(oid, location))
  {
  }

  public AccessDescription[] GetAccessDescriptions()
  {
    return AuthorityInformationAccess.Copy(this.descriptions);
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable[]) this.descriptions);
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("AuthorityInformationAccess:");
    foreach (AccessDescription description in this.descriptions)
      stringBuilder.Append("    ").Append((object) description).AppendLine();
    return stringBuilder.ToString();
  }
}
