// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.X509.ProfessionInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.X509;

public class ProfessionInfo : Asn1Encodable
{
  public static readonly DerObjectIdentifier Rechtsanwltin = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".1");
  public static readonly DerObjectIdentifier Rechtsanwalt = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".2");
  public static readonly DerObjectIdentifier Rechtsbeistand = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".3");
  public static readonly DerObjectIdentifier Steuerberaterin = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".4");
  public static readonly DerObjectIdentifier Steuerberater = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".5");
  public static readonly DerObjectIdentifier Steuerbevollmchtigte = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".6");
  public static readonly DerObjectIdentifier Steuerbevollmchtigter = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".7");
  public static readonly DerObjectIdentifier Notarin = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".8");
  public static readonly DerObjectIdentifier Notar = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".9");
  public static readonly DerObjectIdentifier Notarvertreterin = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".10");
  public static readonly DerObjectIdentifier Notarvertreter = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".11");
  public static readonly DerObjectIdentifier Notariatsverwalterin = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".12");
  public static readonly DerObjectIdentifier Notariatsverwalter = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".13");
  public static readonly DerObjectIdentifier Wirtschaftsprferin = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".14");
  public static readonly DerObjectIdentifier Wirtschaftsprfer = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".15");
  public static readonly DerObjectIdentifier VereidigteBuchprferin = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".16");
  public static readonly DerObjectIdentifier VereidigterBuchprfer = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".17");
  public static readonly DerObjectIdentifier Patentanwltin = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".18");
  public static readonly DerObjectIdentifier Patentanwalt = new DerObjectIdentifier(NamingAuthority.IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern?.ToString() + ".19");
  private readonly NamingAuthority namingAuthority;
  private readonly Asn1Sequence professionItems;
  private readonly Asn1Sequence professionOids;
  private readonly string registrationNumber;
  private readonly Asn1OctetString addProfessionInfo;

  public static ProfessionInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case ProfessionInfo _:
        return (ProfessionInfo) obj;
      case Asn1Sequence seq:
        return new ProfessionInfo(seq);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private ProfessionInfo(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.Count <= 5 ? seq.GetEnumerator() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    enumerator.MoveNext();
    Asn1Encodable current1 = enumerator.Current;
    if (current1 is Asn1TaggedObject asn1TaggedObject)
    {
      this.namingAuthority = asn1TaggedObject.TagNo == 0 ? NamingAuthority.GetInstance(asn1TaggedObject, true) : throw new ArgumentException("Bad tag number: " + asn1TaggedObject.TagNo.ToString());
      enumerator.MoveNext();
      current1 = enumerator.Current;
    }
    this.professionItems = Asn1Sequence.GetInstance((object) current1);
    if (enumerator.MoveNext())
    {
      Asn1Encodable current2 = enumerator.Current;
      switch (current2)
      {
        case Asn1Sequence asn1Sequence:
          this.professionOids = asn1Sequence;
          break;
        case DerPrintableString derPrintableString:
          this.registrationNumber = derPrintableString.GetString();
          break;
        case Asn1OctetString asn1OctetString:
          this.addProfessionInfo = asn1OctetString;
          break;
        default:
          throw new ArgumentException("Bad object encountered: " + Platform.GetTypeName((object) current2));
      }
    }
    if (enumerator.MoveNext())
    {
      Asn1Encodable current3 = enumerator.Current;
      switch (current3)
      {
        case DerPrintableString derPrintableString:
          this.registrationNumber = derPrintableString.GetString();
          break;
        case Asn1OctetString asn1OctetString:
          this.addProfessionInfo = asn1OctetString;
          break;
        default:
          throw new ArgumentException("Bad object encountered: " + Platform.GetTypeName((object) current3));
      }
    }
    if (!enumerator.MoveNext())
      return;
    Asn1Encodable current4 = enumerator.Current;
    this.addProfessionInfo = current4 is Asn1OctetString asn1OctetString1 ? asn1OctetString1 : throw new ArgumentException("Bad object encountered: " + Platform.GetTypeName((object) current4));
  }

  public ProfessionInfo(
    NamingAuthority namingAuthority,
    DirectoryString[] professionItems,
    DerObjectIdentifier[] professionOids,
    string registrationNumber,
    Asn1OctetString addProfessionInfo)
  {
    this.namingAuthority = namingAuthority;
    this.professionItems = (Asn1Sequence) new DerSequence((Asn1Encodable[]) professionItems);
    if (professionOids != null)
      this.professionOids = (Asn1Sequence) new DerSequence((Asn1Encodable[]) professionOids);
    this.registrationNumber = registrationNumber;
    this.addProfessionInfo = addProfessionInfo;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(5);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.namingAuthority);
    elementVector.Add((Asn1Encodable) this.professionItems);
    elementVector.AddOptional((Asn1Encodable) this.professionOids);
    if (this.registrationNumber != null)
      elementVector.Add((Asn1Encodable) new DerPrintableString(this.registrationNumber, true));
    elementVector.AddOptional((Asn1Encodable) this.addProfessionInfo);
    return (Asn1Object) new DerSequence(elementVector);
  }

  public virtual Asn1OctetString AddProfessionInfo => this.addProfessionInfo;

  public virtual NamingAuthority NamingAuthority => this.namingAuthority;

  public virtual DirectoryString[] GetProfessionItems()
  {
    DirectoryString[] professionItems = new DirectoryString[this.professionItems.Count];
    for (int index = 0; index < this.professionItems.Count; ++index)
      professionItems[index] = DirectoryString.GetInstance((object) this.professionItems[index]);
    return professionItems;
  }

  public virtual DerObjectIdentifier[] GetProfessionOids()
  {
    if (this.professionOids == null)
      return new DerObjectIdentifier[0];
    DerObjectIdentifier[] professionOids = new DerObjectIdentifier[this.professionOids.Count];
    for (int index = 0; index < this.professionOids.Count; ++index)
      professionOids[index] = DerObjectIdentifier.GetInstance((object) this.professionOids[index]);
    return professionOids;
  }

  public virtual string RegistrationNumber => this.registrationNumber;
}
