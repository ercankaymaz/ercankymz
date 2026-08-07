// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DLBitStringParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class DLBitStringParser : Asn1BitStringParser, IAsn1Convertible
{
  private readonly DefiniteLengthInputStream m_stream;
  private int m_padBits;

  internal DLBitStringParser(DefiniteLengthInputStream stream) => this.m_stream = stream;

  public Stream GetBitStream() => this.GetBitStream(false);

  public Stream GetOctetStream() => this.GetBitStream(true);

  public int PadBits => this.m_padBits;

  public Asn1Object ToAsn1Object()
  {
    try
    {
      return (Asn1Object) DerBitString.CreatePrimitive(this.m_stream.ToArray());
    }
    catch (IOException ex)
    {
      throw new Asn1ParsingException("IOException converting stream to byte array: " + ex.Message, (Exception) ex);
    }
  }

  private Stream GetBitStream(bool octetAligned)
  {
    int remaining = this.m_stream.Remaining;
    if (remaining < 1)
      throw new InvalidOperationException("content octets cannot be empty");
    this.m_padBits = this.m_stream.ReadByte();
    if (this.m_padBits > 0)
    {
      if (remaining < 2)
        throw new InvalidOperationException("zero length data with non-zero pad bits");
      if (this.m_padBits > 7)
        throw new InvalidOperationException("pad bits cannot be greater than 7 or less than 0");
      if (octetAligned)
        throw new IOException("expected octet-aligned bitstring, but found padBits: " + this.m_padBits.ToString());
    }
    return (Stream) this.m_stream;
  }
}
