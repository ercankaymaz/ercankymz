// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.ConstructedBitStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class ConstructedBitStream : BaseInputStream
{
  private readonly Asn1StreamParser m_parser;
  private readonly bool m_octetAligned;
  private bool m_first = true;
  private int m_padBits;
  private Asn1BitStringParser m_currentParser;
  private Stream m_currentStream;

  internal ConstructedBitStream(Asn1StreamParser parser, bool octetAligned)
  {
    this.m_parser = parser;
    this.m_octetAligned = octetAligned;
  }

  internal int PadBits => this.m_padBits;

  public override int Read(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (count < 1)
      return 0;
    if (this.m_currentStream == null)
    {
      if (!this.m_first)
        return 0;
      this.m_currentParser = this.GetNextParser();
      if (this.m_currentParser == null)
        return 0;
      this.m_first = false;
      this.m_currentStream = this.m_currentParser.GetBitStream();
    }
    int num1 = 0;
    while (true)
    {
      do
      {
        int num2 = this.m_currentStream.Read(buffer, offset + num1, count - num1);
        if (num2 > 0)
          num1 += num2;
        else
          goto label_9;
      }
      while (num1 != count);
      break;
label_9:
      this.m_padBits = this.m_currentParser.PadBits;
      this.m_currentParser = this.GetNextParser();
      if (this.m_currentParser != null)
        this.m_currentStream = this.m_currentParser.GetBitStream();
      else
        goto label_14;
    }
    return num1;
label_14:
    this.m_currentStream = (Stream) null;
    return num1;
  }

  public override int ReadByte()
  {
    if (this.m_currentStream == null)
    {
      if (!this.m_first)
        return -1;
      this.m_currentParser = this.GetNextParser();
      if (this.m_currentParser == null)
        return -1;
      this.m_first = false;
      this.m_currentStream = this.m_currentParser.GetBitStream();
    }
    int num;
    while (true)
    {
      num = this.m_currentStream.ReadByte();
      if (num < 0)
      {
        this.m_padBits = this.m_currentParser.PadBits;
        this.m_currentParser = this.GetNextParser();
        if (this.m_currentParser != null)
          this.m_currentStream = this.m_currentParser.GetBitStream();
        else
          goto label_10;
      }
      else
        break;
    }
    return num;
label_10:
    this.m_currentStream = (Stream) null;
    return -1;
  }

  private Asn1BitStringParser GetNextParser()
  {
    IAsn1Convertible nextParser = this.m_parser.ReadObject();
    if (nextParser == null)
    {
      if (this.m_octetAligned && this.m_padBits != 0)
        throw new IOException("expected octet-aligned bitstring, but found padBits: " + this.m_padBits.ToString());
      return (Asn1BitStringParser) null;
    }
    if (!(nextParser is Asn1BitStringParser))
      throw new IOException("unknown object encountered: " + Platform.GetTypeName((object) nextParser));
    if (this.m_padBits != 0)
      throw new IOException("only the last nested bitstring can have padding");
    return (Asn1BitStringParser) nextParser;
  }
}
