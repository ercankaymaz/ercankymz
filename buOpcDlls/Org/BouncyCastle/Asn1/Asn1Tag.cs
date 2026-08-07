// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1Tag
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal sealed class Asn1Tag
{
  private readonly int m_tagClass;
  private readonly int m_tagNo;

  internal static Asn1Tag Create(int tagClass, int tagNo) => new Asn1Tag(tagClass, tagNo);

  private Asn1Tag(int tagClass, int tagNo)
  {
    this.m_tagClass = tagClass;
    this.m_tagNo = tagNo;
  }

  internal int TagClass => this.m_tagClass;

  internal int TagNo => this.m_tagNo;
}
