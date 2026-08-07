// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.X509.NamingAuthority
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.X509;

public class NamingAuthority : Asn1Encodable
{
  public static readonly DerObjectIdentifier IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern = new DerObjectIdentifier(IsisMttObjectIdentifiers.IdIsisMttATNamingAuthorities?.ToString() + ".1");
  private readonly DerObjectIdentifier namingAuthorityID;
  private readonly string namingAuthorityUrl;
  private readonly DirectoryString namingAuthorityText;

  public static NamingAuthority GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case NamingAuthority _:
        return (NamingAuthority) obj;
      case Asn1Sequence seq:
        return new NamingAuthority(seq);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static NamingAuthority GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return NamingAuthority.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  private NamingAuthority(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.Count <= 3 ? seq.GetEnumerator() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    if (enumerator.MoveNext())
    {
      Asn1Encodable current = enumerator.Current;
      switch (current)
      {
        case DerObjectIdentifier objectIdentifier:
          this.namingAuthorityID = objectIdentifier;
          break;
        case DerIA5String derIa5String:
          this.namingAuthorityUrl = derIa5String.GetString();
          break;
        case IAsn1String _:
          this.namingAuthorityText = DirectoryString.GetInstance((object) current);
          break;
        default:
          throw new ArgumentException("Bad object encountered: " + Platform.GetTypeName((object) current));
      }
    }
    if (enumerator.MoveNext())
    {
      Asn1Encodable current = enumerator.Current;
      switch (current)
      {
        case DerIA5String derIa5String:
          this.namingAuthorityUrl = derIa5String.GetString();
          break;
        case IAsn1String _:
          this.namingAuthorityText = DirectoryString.GetInstance((object) current);
          break;
        default:
          throw new ArgumentException("Bad object encountered: " + Platform.GetTypeName((object) current));
      }
    }
    if (!enumerator.MoveNext())
      return;
    Asn1Encodable current1 = enumerator.Current;
    this.namingAuthorityText = current1 is IAsn1String ? DirectoryString.GetInstance((object) current1) : throw new ArgumentException("Bad object encountered: " + Platform.GetTypeName((object) current1));
  }

  public virtual DerObjectIdentifier NamingAuthorityID => this.namingAuthorityID;

  public virtual DirectoryString NamingAuthorityText => this.namingAuthorityText;

  public virtual string NamingAuthorityUrl => this.namingAuthorityUrl;

  public NamingAuthority(
    DerObjectIdentifier namingAuthorityID,
    string namingAuthorityUrl,
    DirectoryString namingAuthorityText)
  {
    this.namingAuthorityID = namingAuthorityID;
    this.namingAuthorityUrl = namingAuthorityUrl;
    this.namingAuthorityText = namingAuthorityText;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptional((Asn1Encodable) this.namingAuthorityID);
    if (this.namingAuthorityUrl != null)
      elementVector.Add((Asn1Encodable) new DerIA5String(this.namingAuthorityUrl, true));
    elementVector.AddOptional((Asn1Encodable) this.namingAuthorityText);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
