// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DLTaggedObjectParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class DLTaggedObjectParser : BerTaggedObjectParser
{
  private readonly bool m_constructed;

  internal DLTaggedObjectParser(
    int tagClass,
    int tagNo,
    bool constructed,
    Asn1StreamParser parser)
    : base(tagClass, tagNo, parser)
  {
    this.m_constructed = constructed;
  }

  public override bool IsConstructed => this.m_constructed;

  public override IAsn1Convertible ParseBaseUniversal(bool declaredExplicit, int baseTagNo)
  {
    if (declaredExplicit)
    {
      if (!this.m_constructed)
        throw new IOException("Explicit tags must be constructed (see X.690 8.14.2)");
      return this.m_parser.ParseObject(baseTagNo);
    }
    return !this.m_constructed ? this.m_parser.ParseImplicitPrimitive(baseTagNo) : this.m_parser.ParseImplicitConstructedDL(baseTagNo);
  }

  public override IAsn1Convertible ParseExplicitBaseObject()
  {
    if (!this.m_constructed)
      throw new IOException("Explicit tags must be constructed (see X.690 8.14.2)");
    return this.m_parser.ReadObject();
  }

  public override Asn1TaggedObjectParser ParseExplicitBaseTagged()
  {
    if (!this.m_constructed)
      throw new IOException("Explicit tags must be constructed (see X.690 8.14.2)");
    return this.m_parser.ParseTaggedObject();
  }

  public override Asn1TaggedObjectParser ParseImplicitBaseTagged(int baseTagClass, int baseTagNo)
  {
    return (Asn1TaggedObjectParser) new DLTaggedObjectParser(baseTagClass, baseTagNo, this.m_constructed, this.m_parser);
  }

  public override Asn1Object ToAsn1Object()
  {
    try
    {
      return this.m_parser.LoadTaggedDL(this.TagClass, this.TagNo, this.m_constructed);
    }
    catch (IOException ex)
    {
      throw new Asn1ParsingException(ex.Message);
    }
  }
}
