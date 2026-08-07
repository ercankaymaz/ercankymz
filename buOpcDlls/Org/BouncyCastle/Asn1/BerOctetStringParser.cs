// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BerOctetStringParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class BerOctetStringParser : Asn1OctetStringParser, IAsn1Convertible
{
  private readonly Asn1StreamParser _parser;

  internal BerOctetStringParser(Asn1StreamParser parser) => this._parser = parser;

  public Stream GetOctetStream() => (Stream) new ConstructedOctetStream(this._parser);

  public Asn1Object ToAsn1Object()
  {
    try
    {
      return (Asn1Object) BerOctetStringParser.Parse(this._parser);
    }
    catch (IOException ex)
    {
      throw new Asn1ParsingException("IOException converting stream to byte array: " + ex.Message, (Exception) ex);
    }
  }

  internal static BerOctetString Parse(Asn1StreamParser sp)
  {
    return new BerOctetString(Streams.ReadAll((Stream) new ConstructedOctetStream(sp)));
  }
}
