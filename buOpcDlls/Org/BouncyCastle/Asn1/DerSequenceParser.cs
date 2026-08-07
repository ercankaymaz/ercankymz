// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerSequenceParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerSequenceParser : Asn1SequenceParser, IAsn1Convertible
{
  private readonly Asn1StreamParser m_parser;

  internal DerSequenceParser(Asn1StreamParser parser) => this.m_parser = parser;

  public IAsn1Convertible ReadObject() => this.m_parser.ReadObject();

  public Asn1Object ToAsn1Object()
  {
    return (Asn1Object) DLSequence.FromVector(this.m_parser.ReadVector());
  }
}
