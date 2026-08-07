// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BerTaggedObjectParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class BerTaggedObjectParser : Asn1TaggedObjectParser, IAsn1Convertible
{
  internal readonly int m_tagClass;
  internal readonly int m_tagNo;
  internal readonly Asn1StreamParser m_parser;

  internal BerTaggedObjectParser(int tagClass, int tagNo, Asn1StreamParser parser)
  {
    this.m_tagClass = tagClass;
    this.m_tagNo = tagNo;
    this.m_parser = parser;
  }

  public virtual bool IsConstructed => true;

  public int TagClass => this.m_tagClass;

  public int TagNo => this.m_tagNo;

  public bool HasContextTag() => this.m_tagClass == 128 /*0x80*/;

  public bool HasContextTag(int tagNo) => this.m_tagClass == 128 /*0x80*/ && this.m_tagNo == tagNo;

  public bool HasTag(int tagClass, int tagNo)
  {
    return this.m_tagClass == tagClass && this.m_tagNo == tagNo;
  }

  public bool HasTagClass(int tagClass) => this.m_tagClass == tagClass;

  public virtual IAsn1Convertible ParseBaseUniversal(bool declaredExplicit, int baseTagNo)
  {
    return declaredExplicit ? this.m_parser.ParseObject(baseTagNo) : this.m_parser.ParseImplicitConstructedIL(baseTagNo);
  }

  public virtual IAsn1Convertible ParseExplicitBaseObject() => this.m_parser.ReadObject();

  public virtual Asn1TaggedObjectParser ParseExplicitBaseTagged()
  {
    return this.m_parser.ParseTaggedObject();
  }

  public virtual Asn1TaggedObjectParser ParseImplicitBaseTagged(int baseTagClass, int baseTagNo)
  {
    return (Asn1TaggedObjectParser) new BerTaggedObjectParser(baseTagClass, baseTagNo, this.m_parser);
  }

  public virtual Asn1Object ToAsn1Object()
  {
    try
    {
      return this.m_parser.LoadTaggedIL(this.TagClass, this.TagNo);
    }
    catch (IOException ex)
    {
      throw new Asn1ParsingException(ex.Message);
    }
  }
}
