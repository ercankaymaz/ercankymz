// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.ConstructedOctetStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class ConstructedOctetStream : BaseInputStream
{
  private readonly Asn1StreamParser m_parser;
  private bool m_first = true;
  private Stream m_currentStream;

  internal ConstructedOctetStream(Asn1StreamParser parser) => this.m_parser = parser;

  public override int Read(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (count < 1)
      return 0;
    if (this.m_currentStream == null)
    {
      if (!this.m_first)
        return 0;
      Asn1OctetStringParser nextParser = this.GetNextParser();
      if (nextParser == null)
        return 0;
      this.m_first = false;
      this.m_currentStream = nextParser.GetOctetStream();
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
      Asn1OctetStringParser nextParser = this.GetNextParser();
      if (nextParser != null)
        this.m_currentStream = nextParser.GetOctetStream();
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
      Asn1OctetStringParser nextParser = this.GetNextParser();
      if (nextParser == null)
        return -1;
      this.m_first = false;
      this.m_currentStream = nextParser.GetOctetStream();
    }
    int num;
    while (true)
    {
      num = this.m_currentStream.ReadByte();
      if (num < 0)
      {
        Asn1OctetStringParser nextParser = this.GetNextParser();
        if (nextParser != null)
          this.m_currentStream = nextParser.GetOctetStream();
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

  private Asn1OctetStringParser GetNextParser()
  {
    IAsn1Convertible asn1Convertible = this.m_parser.ReadObject();
    if (asn1Convertible == null)
      return (Asn1OctetStringParser) null;
    return asn1Convertible is Asn1OctetStringParser ? (Asn1OctetStringParser) asn1Convertible : throw new IOException("unknown object encountered: " + Platform.GetTypeName((object) asn1Convertible));
  }
}
