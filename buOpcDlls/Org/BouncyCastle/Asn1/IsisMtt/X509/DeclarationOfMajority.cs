// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.X509.DeclarationOfMajority
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.X509;

public class DeclarationOfMajority : Asn1Encodable, IAsn1Choice
{
  private readonly Asn1TaggedObject m_declaration;

  public DeclarationOfMajority(int notYoungerThan)
  {
    this.m_declaration = (Asn1TaggedObject) new DerTaggedObject(false, 0, (Asn1Encodable) new DerInteger(notYoungerThan));
  }

  public DeclarationOfMajority(bool fullAge, string country)
  {
    DerPrintableString derPrintableString = country.Length <= 2 ? new DerPrintableString(country, true) : throw new ArgumentException("country can only be 2 characters", nameof (country));
    this.m_declaration = (Asn1TaggedObject) new DerTaggedObject(false, 1, !fullAge ? (Asn1Encodable) new DerSequence((Asn1Encodable) DerBoolean.False, (Asn1Encodable) derPrintableString) : (Asn1Encodable) new DerSequence((Asn1Encodable) derPrintableString));
  }

  public DeclarationOfMajority(Asn1GeneralizedTime dateOfBirth)
  {
    this.m_declaration = (Asn1TaggedObject) new DerTaggedObject(false, 2, (Asn1Encodable) dateOfBirth);
  }

  public static DeclarationOfMajority GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DeclarationOfMajority) null;
      case DeclarationOfMajority instance:
        return instance;
      case Asn1TaggedObject o:
        return new DeclarationOfMajority(o);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private DeclarationOfMajority(Asn1TaggedObject o)
  {
    this.m_declaration = o.TagNo <= 2 ? o : throw new ArgumentException("Bad tag number: " + o.TagNo.ToString());
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_declaration;

  public DeclarationOfMajority.Choice Type
  {
    get => (DeclarationOfMajority.Choice) this.m_declaration.TagNo;
  }

  public virtual int NotYoungerThan
  {
    get
    {
      return this.Type == DeclarationOfMajority.Choice.NotYoungerThan ? DerInteger.GetInstance(this.m_declaration, false).IntValueExact : -1;
    }
  }

  public virtual Asn1Sequence FullAgeAtCountry
  {
    get
    {
      return this.Type == DeclarationOfMajority.Choice.FullAgeAtCountry ? Asn1Sequence.GetInstance(this.m_declaration, false) : (Asn1Sequence) null;
    }
  }

  public virtual Asn1GeneralizedTime DateOfBirth
  {
    get
    {
      return this.Type == DeclarationOfMajority.Choice.DateOfBirth ? Asn1GeneralizedTime.GetInstance(this.m_declaration, false) : (Asn1GeneralizedTime) null;
    }
  }

  public enum Choice
  {
    NotYoungerThan,
    FullAgeAtCountry,
    DateOfBirth,
  }
}
