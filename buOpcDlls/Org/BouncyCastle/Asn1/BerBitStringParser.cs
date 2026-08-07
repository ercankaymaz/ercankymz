// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BerBitStringParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class BerBitStringParser : Asn1BitStringParser, IAsn1Convertible
{
  private readonly Asn1StreamParser m_parser;
  private ConstructedBitStream m_bitStream;

  internal BerBitStringParser(Asn1StreamParser parser) => this.m_parser = parser;

  public Stream GetOctetStream()
  {
    return (Stream) (this.m_bitStream = new ConstructedBitStream(this.m_parser, true));
  }

  public Stream GetBitStream()
  {
    return (Stream) (this.m_bitStream = new ConstructedBitStream(this.m_parser, false));
  }

  public int PadBits => this.m_bitStream.PadBits;

  public Asn1Object ToAsn1Object()
  {
    try
    {
      return (Asn1Object) BerBitStringParser.Parse(this.m_parser);
    }
    catch (IOException ex)
    {
      throw new Asn1ParsingException("IOException converting stream to byte array: " + ex.Message, (Exception) ex);
    }
  }

  internal static BerBitString Parse(Asn1StreamParser sp)
  {
    ConstructedBitStream inStr = new ConstructedBitStream(sp, false);
    return new BerBitString(Streams.ReadAll((Stream) inStr), inStr.PadBits);
  }
}
