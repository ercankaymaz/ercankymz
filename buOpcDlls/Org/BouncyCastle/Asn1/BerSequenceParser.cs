// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BerSequenceParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class BerSequenceParser : Asn1SequenceParser, IAsn1Convertible
{
  private readonly Asn1StreamParser _parser;

  internal BerSequenceParser(Asn1StreamParser parser) => this._parser = parser;

  public IAsn1Convertible ReadObject() => this._parser.ReadObject();

  public Asn1Object ToAsn1Object() => (Asn1Object) BerSequenceParser.Parse(this._parser);

  internal static BerSequence Parse(Asn1StreamParser sp) => new BerSequence(sp.ReadVector());
}
